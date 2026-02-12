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
    public partial class CrmRevealViewAppService
    {

        [ApiModel]
        protected async Task<CrmRevealView> CleanRevealViewsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_view.py, METHOD: _clean_reveal_views) ---
            */
            return default;
        }

        protected async Task<CrmRevealView> CreateRevealViewInternalAsync(Guid website_id, object url, object ip_address, object country_code, object state_code, object rules_excluded)
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_view.py, METHOD: _create_reveal_view) ---
            */
            return default;
        }
    }
}