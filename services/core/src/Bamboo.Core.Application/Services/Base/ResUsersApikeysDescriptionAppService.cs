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
    [Module("BaseModule", Category = "Base")]
    public partial class ResUsersApikeysDescriptionAppService : GenericAppService<ResUsersApikeysDescription>, IResUsersApikeysDescriptionAppService
    {

        public ResUsersApikeysDescriptionAppService(IRepository<ResUsersApikeysDescription, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<ResUsersApikeysDescription> CheckAccessMakeKeyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: res_users_apikeys_description.py, METHOD: check_access_make_key) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: check_access_make_key) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResUsersApikeysDescription> MakeKeyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_users.py, METHOD: make_key) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}