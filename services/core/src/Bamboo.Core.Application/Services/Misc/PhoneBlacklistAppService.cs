using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("PhoneValidation", Category = "Misc", Depends = new[] { "base", "mail" })]
    public partial class PhoneBlacklistAppService : GenericAppService<PhoneBlacklist>, IPhoneBlacklistAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        public PhoneBlacklistAppService(IRepository<PhoneBlacklist, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<PhoneBlacklist> AddAsync(PhoneBlacklistAddRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: add) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PhoneBlacklist> AddAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: action_add) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PhoneBlacklist> PhoneBlacklistRemoveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: phone_action_blacklist_remove) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PhoneBlacklist> RemoveAsync(PhoneBlacklistRemoveRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: remove) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}