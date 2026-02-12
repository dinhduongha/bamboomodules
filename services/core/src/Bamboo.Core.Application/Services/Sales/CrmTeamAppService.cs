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
    [Module("SalesTeam", Category = "Sales", Depends = new[] { "base", "mail" })]
    public partial class CrmTeamAppService : GenericAppService<CrmTeam>, ICrmTeamAppService
    {
        protected readonly IMailAliasMixinAppService _mailAliasMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public CrmTeamAppService(IRepository<CrmTeam, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailAliasMixinAppService mailAliasMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailAliasMixinAppService = mailAliasMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<CrmTeam> AssignLeadsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_assign_leads) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmTeam> GetAbandonedCartsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: crm_team.py, METHOD: get_abandoned_carts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmTeam> OpenLeadsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_open_leads) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmTeam> OpenUnassignedLeadsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_open_unassigned_leads) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CrmTeam> OpportunityForecastAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_opportunity_forecast) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmTeam> PrimaryChannelButtonAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_primary_channel_button) ---
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: action_primary_channel_button) ---
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_team.py, METHOD: action_primary_channel_button) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: action_primary_channel_button) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public async Task<CrmTeam> UpdateInvoicedTargetAsync(CrmTeamUpdateInvoicedTargetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: update_invoiced_target) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<CrmTeam> input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }

        [ApiModel]
        public async Task<CrmTeam> YourPipelineAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_your_pipeline) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}