using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Distributed;

using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectMapping;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Application.Dtos;

using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Dtos;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Logging;

namespace Bamboo.Core.Application
{
    // 'create', 'write', 'unlink', 'read', 'search', 'search_count', 'search_read', 'copy'
    // 'default_get', 'fields_get', 'name_get', 'name_search', 'name_create', 'read_group', 'onchange', 'ondelete', 
    // 'check_access_rights', 'check_access_rule', 'check_field_access_rights'
    // browse search search_count search_fetch fetch read - 
    // exists ensure_one get_metadata filtered filtered_domain mapped sorted grouped


    //public class GenericAppService<TEntity> : ApplicationService, IGenericApplicationService<TEntity>
    public class GenericAppService<TEntity> : CrudAppService<TEntity, TEntity, Guid>, IGenericAppService<TEntity>, IApplicationService
        where TEntity : class, IEntity<Guid>
    {
        //protected readonly IRepository<TEntity, Guid> Repository;
        //protected readonly IRepository<TEntity, Guid> Repository;
        protected readonly IAuthorizationService _authorizationService;
        protected readonly IDomainParser _domainParser;
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IModelTypeRegistry _modelTypeRegistry;
        protected readonly IDataFilter _dataFilter;
        protected readonly IObjectMapper _objectMapper;
        protected readonly IDistributedCache _cache;
        private readonly bool _filterFieldAccess = false;
        protected readonly ICurrentTenant _currentTenant;

        protected static readonly bool IsMultiTenant = typeof(IMultiTenant).IsAssignableFrom(typeof(TEntity));
        public GenericAppService(
            IRepository<TEntity, Guid> repository,
            IServiceProvider serviceProvider,
            IDataFilter dataFilter,
            IObjectMapper objectMapper,
            IDistributedCache cache,
            IAuthorizationService authorizationService,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository)
        {
            //Repository = repository;
            //Repository = repository;
            _serviceProvider = serviceProvider;
            _authorizationService = authorizationService;
            _domainParser = domainParser;
            _modelTypeRegistry = modelTypeRegistry;
            _dataFilter = dataFilter;
            _objectMapper = objectMapper;
            _cache = cache;

            _currentTenant = _serviceProvider.GetRequiredService<ICurrentTenant>();
            if (!_currentTenant.Id.HasValue)
            {
                _dataFilter.Disable<IMultiTenant>();
            }
        }

        private async Task<List<string>> GetAllowedFieldsAsync(string modelName, string operation, List<string>? fields = null)
        {
            if (!_filterFieldAccess)
            {
                return typeof(TEntity)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(p => p.CanRead)
                        .Select(p => p.Name)
                        .ToList();
            }

            var cacheKey = $"FieldAccess_{modelName}_{operation}";
            Dictionary<string, bool>? fieldPermissions;
            // if (!_cache.TryGetValue(cacheKey, out Dictionary<string, bool> fieldPermissions))
            // {
            //     fieldPermissions = await _authorizationService.GetFieldAccessAsync(modelName, operation);
            //     _cache.Set(cacheKey, fieldPermissions, TimeSpan.FromMinutes(10));
            // }
            var cachedValue = await _cache.GetStringAsync(cacheKey);
            if (cachedValue == null)
            {
                fieldPermissions = await _authorizationService
                    .GetFieldAccessAsync(modelName, operation);

                await _cache.SetStringAsync(
                    cacheKey,
                    JsonSerializer.Serialize(fieldPermissions),
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                    }
                );
            }
            else
            {
                fieldPermissions =
                    JsonSerializer.Deserialize<Dictionary<string, bool>>(cachedValue)
                    ?? new Dictionary<string, bool>();
            }

            if (fields == null || !fields.Any())
            {
                return typeof(TEntity)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && fieldPermissions.ContainsKey(p.Name) && fieldPermissions[p.Name])
                    .Select(p => p.Name)
                    .ToList();
            }
            var allowedFields = fields.Where(f => fieldPermissions.ContainsKey(f) && fieldPermissions[f]).ToList();
            if (!allowedFields.Any())
                throw new UserFriendlyException($"No {operation} fields available");
            return allowedFields;
        }

        private Dictionary<string, string> GetRelationFields()
        {
            var relationFields = new Dictionary<string, string>();
            foreach (var prop in typeof(TEntity).GetProperties())
            {
                var attr = prop.GetCustomAttribute<RelationFieldAttribute>();
                if (attr != null)
                    relationFields[prop.Name] = attr.Model;
            }
            return relationFields;
        }

        public virtual async Task<List<Guid>> SearchAsync(SearchRequestDto input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "read");
            JsonElement? domain = input.Domain;
            long offset = input.Offset;
            var limit = input.Limit;
            var order = input.Order;

            var query = await Repository.GetQueryableAsync();
            query = await _authorizationService.ApplyRulesAsync(query, modelName);
            query = await _domainParser.ApplyDomain(query, domain);
            return query.Select(x => x.Id).Skip((int)offset).Take(limit).ToList();
        }

        public virtual async Task<List<object>> ReadAsync(ReadRequestDto input)
        {
            List<Guid> ids = input.Ids;
            List<string> fields = input.Fields;
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "read");

            var allowedFields = await GetAllowedFieldsAsync(modelName, "read", fields);
            var relationFields = GetRelationFields();
            var query = await Repository.GetQueryableAsync();
            query = await _authorizationService.ApplyRulesAsync(query, modelName);
            query = query.Where(e => ids.Contains(e.Id));
            return query.Cast<object>().ToList();

            var dynamicSelect = new List<string>();
            var dynamicParameters = new List<object>();
            foreach (var field in allowedFields)
            {
                if (relationFields.ContainsKey(field))
                {
                    var relatedModel = relationFields[field];
                    var service = GetServiceForModel(relatedModel);
                    var relatedIds = query.Select($"it.{field}").Cast<Guid>().Distinct().ToList();
                    var relatedData = await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameGetAsync", relatedIds);
                    dynamicSelect.Add($"new {{ Id = {field}, Name = @0.FirstOrDefault(x => x.Id == {field})?.Name ?? \"\" }} as {field}");
                    dynamicParameters.Add(relatedData);
                }
                else
                {
                    dynamicSelect.Add($"{field} as {field}");
                }
            }

            var result = query.Select($"new {{ {string.Join(", ", dynamicSelect)} }}", dynamicParameters.ToArray()).ToDynamicList();
            return result.Select(r =>
            {
                var dict = _objectMapper.Map<object, Dictionary<string, object>>(r);
                foreach (var field in allowedFields.Where(f => relationFields.ContainsKey(f)))
                {
                    if (dict[field] is Dictionary<string, object> fieldDict && fieldDict["Id"] is Guid id && id != Guid.Empty)
                        dict[field] = new object[] { id, fieldDict["Name"] };
                    else
                        dict[field] = false;
                    dict.Remove($"{field}.Name");
                }
                return dict;
            }).ToList();
        }

        public virtual async Task<List<object>> SearchReadAsync(SearchReadRequestDto input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "read");
            JsonElement? domain = input.Domain;
            long offset = input.Offset;
            var limit = input.Limit;
            var order = input.Order;
            List<string>? fields = input.Fields;

            var allowedFields = await GetAllowedFieldsAsync(modelName, "read", fields);
            var relationFields = GetRelationFields();
            var query = await Repository.GetQueryableAsync();
            query = await _authorizationService.ApplyRulesAsync(query, modelName);
            query = await _domainParser.ApplyDomain(query, domain);
            var queryResult = query.Cast<object>().Skip((int)offset).Take((int)limit).ToList();
            Logger.LogInformation($"Result {modelName} SearchReadAsync");
            return queryResult;

            var dynamicSelect = new List<string>();
            var dynamicParameters = new List<object>();
            foreach (var field in allowedFields)
            {
                if (relationFields.ContainsKey(field))
                {
                    var relatedModel = relationFields[field];
                    var service = GetServiceForModel(relatedModel);
                    var relatedIds = query.Select($"it.{field}").Cast<Guid>().Distinct().ToList();
                    var relatedData = await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameGetAsync", relatedIds);
                    dynamicSelect.Add($"new {{ Id = {field}, Name = @0.FirstOrDefault(x => x.Id == {field})?.Name ?? \"\" }} as {field}");
                    dynamicParameters.Add(relatedData);
                }
                else
                {
                    dynamicSelect.Add($"{field} as {field}");
                }
            }

            var result = query.Select($"new {{ {string.Join(", ", dynamicSelect)} }}", dynamicParameters.ToArray()).ToDynamicList();
            return result.Select(r =>
            {
                var dict = _objectMapper.Map<object, Dictionary<string, object>>(r);
                foreach (var field in allowedFields.Where(f => relationFields.ContainsKey(f)))
                {
                    if (dict[field] is Dictionary<string, object> fieldDict && fieldDict["Id"] is Guid id && id != Guid.Empty)
                        dict[field] = new object[] { id, fieldDict["Name"] };
                    else
                        dict[field] = false;
                    dict.Remove($"{field}.Name");
                }
                return dict;
            }).ToList();
        }

        public virtual async Task<long> SearchCountAsync(SearchCountRequestDto input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "read");
            JsonElement? domain = input.Domain;
            long offset = input.Offset;
            var limit = input.Limit;
            var order = input.Order;
            List<string>? fields = input.Fields;

            var allowedFields = await GetAllowedFieldsAsync(modelName, "read", fields);
            var relationFields = GetRelationFields();
            var query = await Repository.GetQueryableAsync();
            query = await _authorizationService.ApplyRulesAsync(query, modelName);
            query = await _domainParser.ApplyDomain(query, domain);
            return query.LongCount();
            //return query.Cast<object>().Skip((int)offset).Take((int)limit).ToList();

            // var dynamicSelect = new List<string>();
            // var dynamicParameters = new List<object>();
            // foreach (var field in allowedFields)
            // {
            //     if (relationFields.ContainsKey(field))
            //     {
            //         var relatedModel = relationFields[field];
            //         var service = GetServiceForModel(relatedModel);
            //         var relatedIds = query.Select($"it.{field}").Cast<Guid>().Distinct().ToList();
            //         var relatedData = await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameGetAsync", relatedIds);
            //         dynamicSelect.Add($"new {{ Id = {field}, Name = @0.FirstOrDefault(x => x.Id == {field})?.Name ?? \"\" }} as {field}");
            //         dynamicParameters.Add(relatedData);
            //     }
            //     else
            //     {
            //         dynamicSelect.Add($"{field} as {field}");
            //     }
            // }

            // var result = query.Select($"new {{ {string.Join(", ", dynamicSelect)} }}", dynamicParameters.ToArray()).ToDynamicList();
            // return result.Select(r =>
            // {
            //     var dict = _objectMapper.Map<object, Dictionary<string, object>>(r);
            //     foreach (var field in allowedFields.Where(f => relationFields.ContainsKey(f)))
            //     {
            //         if (dict[field] is Dictionary<string, object> fieldDict && fieldDict["Id"] is Guid id && id != Guid.Empty)
            //             dict[field] = new object[] { id, fieldDict["Name"] };
            //         else
            //             dict[field] = false;
            //         dict.Remove($"{field}.Name");
            //     }
            //     return dict;
            // }).ToList();
        }


        public virtual async Task<TEntity> CreateAsync(CreateRequestDto<TEntity> input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "create");
            List<string> fields = input.Fields;
            var entity = input.Entity;

            var allowedFields = await GetAllowedFieldsAsync(modelName, "write", fields);
            var relationFields = GetRelationFields();
            var entityType = typeof(TEntity);
            var newEntity = Activator.CreateInstance<TEntity>();

            foreach (var field in allowedFields)
            {
                var property = entityType.GetProperty(field, BindingFlags.Public | BindingFlags.DeclaredOnly);
                if (property != null && property.CanWrite)
                {
                    var value = property.GetValue(entity);
                    if (relationFields.ContainsKey(field) && value is List<object> relValue)
                    {
                        if (relValue[0] is int command && command == 6) // [6, 0, [ids]] for many2many
                        {
                            value = relValue[2]; // List of IDs
                        }
                    }
                    property.SetValue(newEntity, value);
                }
            }

            return await Repository.InsertAsync(newEntity);
            var readFieldPermissions = await _authorizationService.GetFieldAccessAsync(modelName, "read");
            var returnFields = readFieldPermissions == null ? allowedFields : allowedFields.Where(f => readFieldPermissions.ContainsKey(f) && readFieldPermissions[f]).ToList();
            var dynamicSelect = new List<string>();
            var dynamicParameters = new List<object>();
            foreach (var field in returnFields)
            {
                if (relationFields.ContainsKey(field))
                {
                    var relatedModel = relationFields[field];
                    var service = GetServiceForModel(relatedModel);
                    var relatedIds = new List<Guid> { (Guid)entityType.GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(newEntity) };
                    var relatedData = await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameGetAsync", relatedIds);
                    dynamicSelect.Add($"new {{ Id = {field}, Name = @0.FirstOrDefault(x => x.Id == {field})?.Name ?? \"\" }} as {field}");
                    dynamicParameters.Add(relatedData);
                }
                else
                {
                    dynamicSelect.Add($"{field} as {field}");
                }
            }

            var query = (await Repository.GetQueryableAsync()).Where(e => e.Id == newEntity.Id);
            var result = query.Select($"new {{ {string.Join(", ", dynamicSelect)} }}", dynamicParameters.ToArray())
                .ToDynamicList()
                .FirstOrDefault();
            var dict = _objectMapper.Map<object, Dictionary<string, object>>(result);
            foreach (var field in returnFields.Where(f => relationFields.ContainsKey(f)))
            {
                if (dict[field] is Dictionary<string, object> fieldDict && fieldDict["Id"] is Guid id && id != Guid.Empty)
                    dict[field] = new object[] { id, fieldDict["Name"] };
                else
                    dict[field] = false;
                dict.Remove($"{field}.Name");
            }
            return dict;
        }

        public virtual async Task<List<object>> WriteAsync(UpdateRequestDto<TEntity> input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "write");
            List<Guid> ids = input.Ids;
            TEntity? entity = input.Entity;
            List<string> fields = input.Fields;

            var allowedFields = await GetAllowedFieldsAsync(modelName, "write", fields);
            var relationFields = GetRelationFields();
            var query = await Repository.GetQueryableAsync();
            query = await _authorizationService.ApplyRulesAsync(query, modelName);
            var entities = query.Where(e => ids.Contains(e.Id)).ToList();
            if (entities.Count != ids.Count)
                throw new UserFriendlyException("Some entities not found or access denied");

            var entityType = typeof(TEntity);
            foreach (var existingEntity in entities)
            {
                foreach (var field in allowedFields)
                {
                    var property = entityType.GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    if (property != null && property.CanWrite)
                    {
                        var value = property.GetValue(entity);
                        if (relationFields.ContainsKey(field) && value is List<object> relValue)
                        {
                            if (relValue[0] is int command && command == 6) // [6, 0, [ids]] for many2many
                            {
                                value = relValue[2]; // List of IDs
                            }
                        }
                        property.SetValue(existingEntity, value);
                    }
                }
                await Repository.UpdateAsync(existingEntity);
            }

            var readFieldPermissions = await _authorizationService.GetFieldAccessAsync(modelName, "read");
            var returnFields = readFieldPermissions == null ? allowedFields : allowedFields.Where(f => readFieldPermissions.ContainsKey(f) && readFieldPermissions[f]).ToList();
            var dynamicSelect = new List<string>();
            var dynamicParameters = new List<object>();
            foreach (var field in returnFields)
            {
                if (relationFields.ContainsKey(field))
                {
                    var relatedModel = relationFields[field];
                    var service = GetServiceForModel(relatedModel);
                    var relatedIds = entities.Select(e => (Guid)e.GetType().GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(e)).Distinct().ToList();
                    var relatedData = await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameGetAsync", relatedIds);
                    dynamicSelect.Add($"new {{ Id = {field}, Name = @0.FirstOrDefault(x => x.Id == {field})?.Name ?? \"\" }} as {field}");
                    dynamicParameters.Add(relatedData);
                }
                else
                {
                    dynamicSelect.Add($"{field} as {field}");
                }
            }

            var result = query.Where(e => ids.Contains(e.Id))
                .Select($"new {{ {string.Join(", ", dynamicSelect)} }}", dynamicParameters.ToArray())
                .ToDynamicList();
            return result.Select(r =>
            {
                //var dict = _objectMapper.Map<object, Dictionary<string, object>>(r);
                var dict = _objectMapper.Map<object, Dictionary<string, object>>(r);
                foreach (var field in returnFields.Where(f => relationFields.ContainsKey(f)))
                {
                    if (dict[field] is Dictionary<string, object> fieldDict && fieldDict["Id"] is Guid id && id != Guid.Empty)
                        dict[field] = new object[] { id, fieldDict["Name"] };
                    else
                        dict[field] = false;
                    dict.Remove($"{field}.Name");
                }
                return dict;
            }).ToList();
        }

        public async Task<object> UpdateJsonAsync(UpdateJsonRequestDto input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "write");
            //if (!await _accessControlService.CheckAccess(_modelName, "write"))
            //    throw new AbpAuthorizationException($"No write permission on {_modelName}");

            List<Guid> ids = input.Ids;
            string jsonField = input.JsonField;
            Dictionary<string, object> jsonValue = input.Dict; // Values
            string action = input.Action ?? "update";

            var prop = typeof(TEntity).GetProperty(jsonField);
            if (prop == null || prop.PropertyType != typeof(Dictionary<string, object>))
                throw new AbpException($"Field {jsonField} is not a valid jsonb field in {modelName}");

            var query = await Repository.GetQueryableAsync();
            //var entities = await query.Where(e => ids.Contains(((dynamic)e).Id)).ToListAsync();
            var entities = await query.Where(e => ids.Contains((e.Id))).ToDynamicListAsync();
            if (!entities.Any())
                throw new AbpException($"No records found with IDs {string.Join(", ", ids)}");

            foreach (var entity in entities)
            {
                var currentDict = (Dictionary<string, object>)prop.GetValue(entity) ?? new Dictionary<string, object>();

                switch (action.ToLower())
                {
                    case "update":
                        foreach (var kvp in jsonValue)
                        {
                            currentDict[kvp.Key] = kvp.Value;
                        }
                        break;
                    case "delete":
                        foreach (var key in jsonValue.Keys)
                        {
                            currentDict.Remove(key);
                        }
                        break;
                    case "add":
                        foreach (var kvp in jsonValue)
                        {
                            if (!currentDict.ContainsKey(kvp.Key))
                            {
                                currentDict[kvp.Key] = kvp.Value;
                            }
                        }
                        break;
                    default:
                        throw new AbpException($"Invalid action: {action}. Supported actions: update, delete, add.");
                }

                prop.SetValue(entity, currentDict);
                await Repository.UpdateAsync(entity);
            }

            return entities.Select(entity => (object)JsonSerializer.SerializeToElement(entity)).ToList();
        }
        public virtual async Task DeleteAsync(List<Guid> ids)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "unlink");

            var query = await Repository.GetQueryableAsync();
            query = await _authorizationService.ApplyRulesAsync(query, modelName);
            var entity = query.Where(e => ids.Contains(e.Id)).FirstOrDefault();
            if (entity == null)
                throw new UserFriendlyException("Entity not found or access denied");
            await Repository.DeleteManyAsync(ids);
        }

        public virtual async Task<object> UnlinkAsync(List<Guid> ids)
        {
            // var modelName = typeof(TEntity).Name;
            // await _authorizationService.CheckAccessAsync(modelName, "unlink");

            // var query = await Repository.GetQueryableAsync();
            // query = await _authorizationService.ApplyRulesAsync(query, modelName);
            // var entity = query.Where(e => ids.Contains(e.Id)).FirstOrDefault();
            // if (entity == null)
            //     throw new UserFriendlyException("Entity not found or access denied");
            // Repository.DeleteManyAsync(ids);
            return default;
        }

        public virtual async Task<TEntity> CopyAsync(CopyRequestDto<TEntity> input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "create");
            Guid id = input.Ids[0];
            List<string> fields = input.Fields;
            TEntity defaultValues = input.DefaultValues;

            var query = await Repository.GetQueryableAsync();
            query = await _authorizationService.ApplyRulesAsync(query, modelName);
            var entity = query.Where(e => e.Id == id).FirstOrDefault();
            if (entity == null)
                throw new UserFriendlyException("Entity not found or access denied");

            var allowedFields = await GetAllowedFieldsAsync(modelName, "write", fields);
            var relationFields = GetRelationFields();
            var entityType = typeof(TEntity);
            var newEntity = Activator.CreateInstance<TEntity>();

            foreach (var field in allowedFields)
            {
                var property = entityType.GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (property != null && property.CanWrite)
                {
                    var value = property.GetValue(entity);
                    if (defaultValues != null)
                    {
                        var defaultValue = property.GetValue(defaultValues);
                        if (defaultValue != null)
                            value = defaultValue;
                    }
                    if (relationFields.ContainsKey(field) && value is List<object> relValue)
                    {
                        if (relValue[0] is int command && command == 6) // [6, 0, [ids]] for many2many
                        {
                            value = relValue[2]; // List of IDs
                        }
                    }
                    property.SetValue(newEntity, value);
                }
            }

            await Repository.InsertAsync(newEntity);
            var readFieldPermissions = await _authorizationService.GetFieldAccessAsync(modelName, "read");
            var returnFields = readFieldPermissions == null ? allowedFields : allowedFields.Where(f => readFieldPermissions.ContainsKey(f) && readFieldPermissions[f]).ToList();
            var dynamicSelect = new List<string>();
            var dynamicParameters = new List<object>();
            foreach (var field in returnFields)
            {
                if (relationFields.ContainsKey(field))
                {
                    var relatedModel = relationFields[field];
                    var service = GetServiceForModel(relatedModel);
                    var relatedIds = new List<Guid> { (Guid)entityType.GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(newEntity) };
                    var relatedData = await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameGetAsync", relatedIds);
                    dynamicSelect.Add($"new {{ Id = {field}, Name = @0.FirstOrDefault(x => x.Id == {field})?.Name ?? \"\" }} as {field}");
                    dynamicParameters.Add(relatedData);
                }
                else
                {
                    dynamicSelect.Add($"{field} as {field}");
                }
            }

            var result = (await Repository.GetQueryableAsync())
                .Where(e => e.Id == newEntity.Id)
                .Select($"new {{ {string.Join(", ", dynamicSelect)} }}", dynamicParameters.ToArray())
                .ToDynamicList()
                .FirstOrDefault();
            var dict = _objectMapper.Map<object, Dictionary<string, object>>(result);
            foreach (var field in returnFields.Where(f => relationFields.ContainsKey(f)))
            {
                if (dict[field] is Dictionary<string, object> fieldDict && fieldDict["Id"] is Guid idTmp && idTmp != Guid.Empty)
                    dict[field] = new object[] { idTmp, fieldDict["Name"] };
                else
                    dict[field] = false;
                dict.Remove($"{field}.Name");
            }
            return dict;
        }

        public virtual async Task<TEntity> NameCreateAsync(NameCreateRequestDto input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "read");
            string name = input.Name;

            var allowedFields = await GetAllowedFieldsAsync(modelName, "write", null);
            if (!allowedFields.Contains("Name"))
            {
                throw new UserFriendlyException("Entity not found or access denied");
            }
            var entityType = typeof(TEntity);
            var newEntity = Activator.CreateInstance<TEntity>();
            var property = entityType.GetProperty("Name");
            if (property.PropertyType == typeof(StringDictionary))
            {
                var value = new StringDictionary
                {
                    { "en_US", name }
                };
                property.SetValue(newEntity, value);
            }
            return await Repository.InsertAsync(newEntity);
        }

        public virtual async Task<List<(Guid Id, string Name)>> NameGetAsync(NameGetRequestDto input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "read");
            List<Guid> ids = input.Ids;

            var query = await Repository.GetQueryableAsync();
            query = await _authorizationService.ApplyRulesAsync(query, modelName);
            query = query.Where(e => ids.Contains(e.Id));

            var result = query.Select(e => new { e.Id, Name = e.ToString() }).ToList();
            return result.Select(r => (r.Id, r.Name)).ToList();
        }

        public virtual async Task<List<(Guid Id, string Name)>> NameSearchAsync(NameSearchRequestDto input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "read");
            string name = input.Name;
            JsonElement? domain = input.Domain;
            string @operator = "ilike";
            int limit = input.Limit ?? 100;

            var query = await Repository.GetQueryableAsync();
            query = await _authorizationService.ApplyRulesAsync(query, modelName);
            query = await _domainParser.ApplyDomain(query, domain);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where($"it.ToString().ToLower().Contains(@0)", name.ToLower());
            }

            var result = query.Take(limit).Select(e => new { e.Id, Name = e.ToString() }).ToList();
            return result.Select(r => (r.Id, r.Name)).ToList();
        }


        // object values, object field_names, object fields_spec
        public virtual async Task<object> OnChangeAsync(OnChangeRequestDto<TEntity> input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "read");

            List<string> changedFields = input.ChangedFields;
            TEntity values = input.Values;
            Dictionary<string, object> fieldInfo = input.FieldInfos;

            var result = new OnchangeResultDto
            {
                Value = new Dictionary<string, object>(),
                Warning = null
            };

            var allowedFields = await GetAllowedFieldsAsync(modelName, "read", null);
            var relationFields = GetRelationFields();
            var entityType = typeof(TEntity);

            foreach (var field in changedFields)
            {
                if (allowedFields.Contains(field))
                {
                    var property = entityType.GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    if (property != null && property.CanRead)
                    {
                        var value = property.GetValue(values);
                        if (relationFields.ContainsKey(field) && value is Guid id && id != Guid.Empty)
                        {
                            var relatedModel = relationFields[field];
                            var service = GetServiceForModel(relatedModel);
                            var relatedData = await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameGetAsync", new List<Guid> { id });
                            result.Value[field] = relatedData.Any() ? new object[] { id, relatedData[0].Name } : false;
                        }
                        else
                        {
                            result.Value[field] = value;
                        }
                    }
                }
            }

            if (changedFields.Contains("product_id") && modelName == "SaleOrderLine")
            {
                var productIdObj = fieldInfo.ContainsKey("product_id") ? fieldInfo["product_id"] : null;
                if (productIdObj is List<object> productInfo && productInfo.Count == 2 && productInfo[0].ToString() == "product.product")
                {
                    var productId = Guid.Parse(productInfo[1].ToString());
                    var productService = GetServiceForModel("product.product");
                    var product = await CallServiceMethodAsync<List<object>>(productService, "ReadAsync", new List<Guid> { productId }, new List<string> { "list_price", "name" });
                    if (product != null && product.Any())
                    {
                        var productData = product[0] as Dictionary<string, object>;
                        result.Value["price_unit"] = productData["list_price"];
                        result.Value["name"] = productData["name"];
                    }
                    result.Warning = new Dictionary<string, string>
                    {
                        { "title", "Warning" },
                        { "message", "Price and name updated based on selected product." }
                    };
                }
            }

            return result;
        }

        public virtual async Task<TEntity> DefaultGetAsync(object fields)
        {
            throw new UserFriendlyException("Not implemented");
        }

        public virtual async Task<TEntity> DefaultGetAsync(DefaultGetRequestDto input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "create");
            List<string> fields = input.Fields;

            var allowedFields = await GetAllowedFieldsAsync(modelName, "write", fields);
            var result = new Dictionary<string, object>();

            var entityType = typeof(TEntity);
            var defaultEntity = Activator.CreateInstance<TEntity>();

            foreach (var field in allowedFields)
            {
                var property = entityType.GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (property != null)
                {
                    var value = property.GetValue(defaultEntity);
                    result[field] = value ?? false;
                }
            }

            if (modelName == "SaleOrderLine")
            {
                result["price_unit"] = 0.0m;
                result["name"] = "";
            }

            //return result;
            return default;
        }

        public virtual async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(FieldsGetRequestDto input)
        {
            var modelName = typeof(TEntity).Name;
            await _authorizationService.CheckAccessAsync(modelName, "read");
            List<string> fields = input.Fields;
            Dictionary<string, List<string>> attributes = input.Attributes;

            var cacheKey = $"FieldsMetadata_{modelName}";
            Dictionary<string, Dictionary<string, object>> metadata;
            var cachedValue = await _cache.GetStringAsync(cacheKey);

            //if (!_memoryCache.TryGetValue(cacheKey, out Dictionary<string, Dictionary<string, object>> metadata))
            if (cachedValue == null)
            {
                metadata = new Dictionary<string, Dictionary<string, object>>();
                var allowedFields = await GetAllowedFieldsAsync(modelName, "read", fields);
                var relationFields = GetRelationFields();
                var entityType = typeof(TEntity);

                foreach (var field in allowedFields)
                {
                    var property = entityType.GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    if (property == null)
                        continue;

                    var fieldInfo = new Dictionary<string, object>
                    {
                        { "type", GetFieldType(property, relationFields.ContainsKey(field) ? relationFields[field] : null) },
                        { "string", field },
                        { "required", property.GetCustomAttribute<RequiredAttribute>() != null },
                        { "readonly", !property.CanWrite }
                    };

                    if (relationFields.ContainsKey(field))
                    {
                        fieldInfo["relation"] = relationFields[field];
                    }

                    if (attributes != null && attributes.ContainsKey(field))
                    {
                        foreach (var attr in attributes[field])
                        {
                            if (!fieldInfo.ContainsKey(attr))
                                fieldInfo[attr] = true;
                        }
                    }

                    metadata[field] = fieldInfo;
                }
                await _cache.SetStringAsync(
                    cacheKey,
                    JsonSerializer.Serialize(metadata),
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                    }
                );
                //_memoryCache.Set(cacheKey, metadata, TimeSpan.FromMinutes(30));
            }
            else
            {
                metadata =
                    JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(cachedValue)
                    ?? new Dictionary<string, Dictionary<string, object>>();
            }

            return metadata;
        }

        private string GetFieldType(PropertyInfo property, string relatedModel)
        {
            if (relatedModel != null)
            {
                var attr = property.GetCustomAttribute<RelationFieldAttribute>();
                return attr?.Type ?? "many2one";
            }

            var type = property.PropertyType;
            if (type == typeof(string)) return "char";
            if (type == typeof(int) || type == typeof(long)) return "integer";
            if (type == typeof(decimal) || type == typeof(double) || type == typeof(float)) return "float";
            if (type == typeof(bool)) return "boolean";
            if (type == typeof(DateTime)) return "datetime";
            if (type == typeof(Dictionary<string, object>)) return "jsonb";
            return "char";
        }

        private object GetServiceForModel(string modelName)
        {
            var entityType = _modelTypeRegistry.GetEntityType(modelName);
            var serviceType = typeof(IGenericAppService<>).MakeGenericType(entityType);
            return _serviceProvider.GetService(serviceType)
                ?? throw new UserFriendlyException($"Service for {modelName} not found");
        }

        private async Task<TResult> CallServiceMethodAsync<TResult>(object service, string methodName, params object[] args)
        {
            var method = service.GetType().GetMethod(methodName);
            if (method == null)
                throw new UserFriendlyException($"Method {methodName} not found");

            var result = method.Invoke(service, args);
            if (result is Task<TResult> task)
                return await task;
            return (TResult)result;
        }

        public virtual async Task<object> WebSearchReadAsync(WebSearchReadRequestDto input)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<object> WebReadAsync(WebReadRequestDto input)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<object> WebReadGroupAsync(WebReadGroupRequestDto input)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<object> WebSaveAsync(WebSaveRequestDto input)
        {
            throw new NotImplementedException();
        }

        public override async Task<TEntity> GetAsync(Guid id)
        {
            return await base.GetAsync(id);
        }

        public override async Task<PagedResultDto<TEntity>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await base.GetListAsync(input);
        }

        public override async Task<TEntity> CreateAsync(TEntity input)
        {
            return await base.CreateAsync(input);
            //throw new NotImplementedException();
        }

        public override async Task<TEntity> UpdateAsync(Guid id, TEntity input)
        {
            var entity = base.GetAsync(id);
            if (entity != null)
            {
                //return await base.UpdateAsync(id, input);
            }
            throw new NotImplementedException();
        }

        public override async Task DeleteAsync(Guid id)
        {
            //await base.DeleteAsync(id);
            throw new NotImplementedException();
        }
    }
}