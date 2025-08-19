using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Users;

using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Services.Commons
{
    public class AuthorizationService : ITransientDependency
    {
        private readonly IRepository<IrModel, Guid> _modelRepository;
        private readonly IRepository<IrModelAccess, Guid> _modelAccessRepository;
        private readonly IRepository<IrModelFields, Guid> _fieldRepository;
        private readonly IRepository<IrModelFieldAccess, Guid> _fieldAccessRepository;
        private readonly IRepository<IrRule, Guid> _ruleRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<ResUsers, Guid> _resUserRepository;
        private readonly IRepository<ResGroups, Guid> _resGroupRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly DomainParser _domainParser;

        public AuthorizationService(
            IRepository<IrModel, Guid> modelRepository,
            IRepository<IrModelAccess, Guid> modelAccessRepository,
            IRepository<IrModelFields, Guid> fieldRepository,
            IRepository<IrModelFieldAccess, Guid> fieldAccessRepository,
            IRepository<IrRule, Guid> ruleRepository,
            ICurrentUser currentUser,
            IRepository<ResUsers, Guid> resUserRepository,
            IRepository<ResGroups, Guid> resGroupRepository,
            IMemoryCache memoryCache,
            DomainParser domainParser)
        {
            _modelRepository = modelRepository;
            _modelAccessRepository = modelAccessRepository;
            _fieldRepository = fieldRepository;
            _fieldAccessRepository = fieldAccessRepository;
            _ruleRepository = ruleRepository;
            _currentUser = currentUser;
            _resUserRepository = resUserRepository;
            _resGroupRepository = resGroupRepository;
            _memoryCache = memoryCache;
            _domainParser = domainParser;
        }

        public async Task CheckAccessAsync(string modelName, string operation)
        {
            return ;
            var cacheKey = $"ModelAccess_{modelName}_{operation}_{_currentUser.Id}";
            if (!_memoryCache.TryGetValue(cacheKey, out bool hasAccess))
            {
                var userGroups = await GetUserGroupsAsync();
                var modelId = await GetModelIdAsync(modelName);

                // Nếu group_id == null, tất cả mọi người đều được truy cập
                var access = (await _modelAccessRepository.GetQueryableAsync())
                    .Where(a => a.ModelId == modelId && (!a.GroupId.HasValue || userGroups.Contains(a.GroupId.Value)))
                    .FirstOrDefault();

                hasAccess = operation switch
                {
                    "read" => access?.PermRead ?? false,
                    "write" => access?.PermWrite ?? false,
                    "create" => access?.PermCreate ?? false,
                    "unlink" => access?.PermUnlink ?? false,
                    _ => throw new UserFriendlyException($"Unknown operation: {operation}")
                };

                _memoryCache.Set(cacheKey, hasAccess, TimeSpan.FromMinutes(10));
            }

            if (!hasAccess)
                throw new UserFriendlyException($"No {operation} permission for model {modelName}");
        }

        public async Task<IQueryable<TEntity>> ApplyRulesAsync<TEntity>(IQueryable<TEntity> query, string modelName)
            where TEntity : class, IEntity<Guid>
        {
            return query;
            var cacheKey = $"Rules_{modelName}_{_currentUser.Id}";
            if (!_memoryCache.TryGetValue(cacheKey, out List<IrRule> rules))
            {
                var userGroups = await GetUserGroupsAsync();
                var modelId = await GetModelIdAsync(modelName);

                rules = (await _ruleRepository.GetQueryableAsync())
                    .Where(r => r.ModelId == modelId && (r.Active == true) && r.Group.Any(g => userGroups.Contains(g.Id)))
                    .ToList();

                _memoryCache.Set(cacheKey, rules, TimeSpan.FromMinutes(10));
            }

            foreach (var rule in rules)
            {
                if (!string.IsNullOrEmpty(rule.DomainForce))
                {
                    query = _domainParser.ApplyDomain(query, rule.DomainForce);
                }
            }
            return query;
        }

        public async Task<Dictionary<string, bool>>? GetFieldAccessAsync(string modelName, string operation)
        {
            return null;
            var cacheKey = $"FieldAccess_{modelName}_{operation}_{_currentUser.Id}";
            if (!_memoryCache.TryGetValue(cacheKey, out Dictionary<string, bool> fieldAccess))
            {
                var userGroups = await GetUserGroupsAsync();
                var modelId = await GetModelIdAsync(modelName);

                fieldAccess = new Dictionary<string, bool>();
                var fields = (await _fieldRepository.GetQueryableAsync())
                    .Where(f => f.ModelId == modelId)
                    .ToList();

                var fieldAccessRecords = (await _fieldAccessRepository.GetQueryableAsync())
                    .Join(
                        fields,
                        a => a.FieldId,
                        f => f.Id,
                        (a, f) => new { Access = a, FieldName = f.Name }
                    )
                    .Where(x => x.Access.ModelId == modelId && (!x.Access.GroupId.HasValue || userGroups.Contains(x.Access.GroupId.Value)) && (x.Access.Active == true))
                    .ToList();

                foreach (var field in fields)
                {
                    var access = fieldAccessRecords.FirstOrDefault(x => x.FieldName == field.Name);
                    bool hasAccess = operation switch
                    {
                        "read" => access?.Access.PermRead ?? false, // Fallback to Readonly if no access record
                        "write" => access?.Access.PermWrite ?? false, // Fallback to Readonly if no access record
                        _ => throw new UserFriendlyException($"Unknown field operation: {operation}")
                    };
                    fieldAccess[field.Name] = hasAccess;
                }

                _memoryCache.Set(cacheKey, fieldAccess, TimeSpan.FromMinutes(10));
            }
            return fieldAccess;
        }

        private async Task<List<Guid>> GetUserGroupsAsync()
        {
            var cacheKey = $"UserGroups_{_currentUser.Id}";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Guid> groups))
            {
                var user = (await _resUserRepository.GetQueryableAsync())
                    .Where(u => u.Id == _currentUser.Id)
                    .FirstOrDefault();
                if (user == null)
                    return new List<Guid>();

                groups = user.Gids.Select(g => g.Id).ToList();
                _memoryCache.Set(cacheKey, groups, TimeSpan.FromMinutes(10));
            }
            return groups;
        }

        private async Task<Guid> GetModelIdAsync(string modelName)
        {
            var cacheKey = $"ModelId_{modelName}";
            if (!_memoryCache.TryGetValue(cacheKey, out Guid modelId))
            {
                var model = (await _modelRepository.GetQueryableAsync())
                    .Where(m => m.Model == modelName)
                    .Select(m => m.Id)
                    .FirstOrDefault();
                if (model == Guid.Empty)
                    throw new UserFriendlyException($"Model {modelName} not found");
                _memoryCache.Set(cacheKey, model, TimeSpan.FromHours(1));
                modelId = model;
            }
            return modelId;
        }
    }
}