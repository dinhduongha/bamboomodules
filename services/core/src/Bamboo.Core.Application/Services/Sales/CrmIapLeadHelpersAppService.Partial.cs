using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class CrmIapLeadHelpersAppService
    {

        [ApiModel]
        protected async Task<CrmIapLeadHelpers> FindStateIdInternalAsync(object state_code, Guid country_id)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_helpers.py, METHOD: _find_state_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmIapLeadHelpers> NotifyNoMoreCreditInternalAsync(object service_name, object model_name, object notification_parameter)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_helpers.py, METHOD: _notify_no_more_credit) ---
            */
            return default;
        }
    }
}