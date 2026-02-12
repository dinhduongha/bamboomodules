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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class StockRouteAppService
    {

        protected async Task<StockRoute> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _check_company_consistency) ---
            */
            return default;
        }

        protected async Task<StockRoute> ComputeWarehousesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _compute_warehouses) ---
            */
            return default;
        }

        protected async Task<StockRoute> IsValidResupplyRouteForProductInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _is_valid_resupply_route_for_product) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _is_valid_resupply_route_for_product) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _is_valid_resupply_route_for_product) ---
            */
            return default;
        }

        protected async Task<StockRoute> OnchangeCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _onchange_company) ---
            */
            return default;
        }

        protected async Task<StockRoute> OnchangeWarehouseSelectableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _onchange_warehouse_selectable) ---
            */
            return default;
        }
    }
}