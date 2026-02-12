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
    [Module("WebsiteCrmIapReveal", Category = "Sales", Depends = new[] { "iap_crm", "iap_mail", "crm_iap_mine", "website_crm" })]
    public partial class CrmRevealRuleAppService : GenericAppService<CrmRevealRule>, ICrmRevealRuleAppService
    {

        public CrmRevealRuleAppService(IRepository<CrmRevealRule, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<CrmRevealRule> GetLeadTreeViewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: action_get_lead_tree_view) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrmRevealRule> GetOpportunityTreeViewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_rule.py, METHOD: action_get_opportunity_tree_view) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}