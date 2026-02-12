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
    public partial class ProductCategoryAppService
    {

        protected async Task<ProductCategory> CheckCategoryRecursionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: _check_category_recursion) ---
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeAngloSaxonAccountingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_anglo_saxon_accounting) ---
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeParentRouteIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_parent_route_ids) ---
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeProductCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: _compute_product_count) ---
            */
            return default;
        }

        protected async Task<ProductCategory> ComputeTotalRouteIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_total_route_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductCategory> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_category.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<ProductCategory> SearchFilterForStockPutawayRuleInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_filter_for_stock_putaway_rule) ---
            */
            return default;
        }

        protected async Task<ProductCategory> SearchTotalRouteIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_total_route_ids) ---
            */
            return default;
        }

        protected async Task<ProductCategory> UnlinkExceptDeliveryCategoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: product_category.py, METHOD: _unlink_except_delivery_category) ---
            */
            return default;
        }
    }
}