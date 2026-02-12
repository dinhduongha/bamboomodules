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
    public partial class SaleOrderOptionAppService
    {

        protected async Task<SaleOrderOption> ComputeDiscountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py, METHOD: _compute_discount) ---
            */
            return default;
        }

        protected async Task<SaleOrderOption> ComputeIsPresentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py, METHOD: _compute_is_present) ---
            */
            return default;
        }

        protected async Task<SaleOrderOption> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<SaleOrderOption> ComputePriceUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py, METHOD: _compute_price_unit) ---
            */
            return default;
        }

        protected async Task<SaleOrderOption> ComputeUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py, METHOD: _compute_uom_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderOption> GetValuesToAddToOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py, METHOD: _get_values_to_add_to_order) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrderOption> ProductIdDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py, METHOD: _product_id_domain) ---
            */
            return default;
        }

        protected async Task<SaleOrderOption> SearchIsPresentInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_option.py, METHOD: _search_is_present) ---
            */
            return default;
        }
    }
}