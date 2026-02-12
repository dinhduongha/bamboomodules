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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("CrmIapMine", Category = "Sales", Depends = new[] { "iap_crm", "iap_mail" })]
    public partial class CrmIapLeadMiningRequestAppService : GenericAppService<CrmIapLeadMiningRequest>, ICrmIapLeadMiningRequestAppService
    {

        public CrmIapLeadMiningRequestAppService(IRepository<CrmIapLeadMiningRequest, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<CrmIapLeadMiningRequest> BuyCreditsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: action_buy_credits) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmIapLeadMiningRequest> DraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: action_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CrmIapLeadMiningRequest> GetEmptyListHelpAsync(CrmIapLeadMiningRequestGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmIapLeadMiningRequest> GetLeadActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: action_get_lead_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmIapLeadMiningRequest> GetOpportunityActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: action_get_opportunity_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmIapLeadMiningRequest> SubmitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py, METHOD: action_submit) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}