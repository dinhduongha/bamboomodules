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
    public partial class ResGroupsAppService : GenericAppService<ResGroups>, IResGroupsAppService
    {
        protected readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public ResGroupsAppService(IRepository<ResGroups, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        public async Task<ResGroups> CopyDataAsync(ResGroupsCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ResGroups> CreateAsync(CreateRequestDto<ResGroups> input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<ResGroups> GetApplicationGroupsAsync(ResGroupsGetApplicationGroupsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_users.py, METHOD: get_application_groups) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResGroups> ShowAllUsersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: action_show_all_users) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ResGroups> input)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_groups.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_groups.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_groups.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}