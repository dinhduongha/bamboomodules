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
    public partial class CrmIapLeadHelpersAppService : GenericAppService<CrmIapLeadHelpers>, ICrmIapLeadHelpersAppService
    {

        public CrmIapLeadHelpersAppService(IRepository<CrmIapLeadHelpers, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<CrmIapLeadHelpers> LeadValsFromResponseAsync(CrmIapLeadHelpersLeadValsFromResponseRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_helpers.py, METHOD: lead_vals_from_response) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}