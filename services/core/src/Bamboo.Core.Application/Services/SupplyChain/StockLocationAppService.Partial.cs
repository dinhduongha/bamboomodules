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
    public partial class StockLocationAppService
    {

        protected async Task<StockLocation> CheckAccessPutawayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_location.py, METHOD: _check_access_putaway) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _check_access_putaway) ---
            */
            return default;
        }

        protected async Task<StockLocation> CheckCanBeUsedInternalAsync(object product, object quantity, object package, object location_qty)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _check_can_be_used) ---
            */
            return default;
        }

        protected async Task<StockLocation> CheckReplenishLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _check_replenish_location) ---
            */
            return default;
        }

        protected async Task<StockLocation> CheckScrapLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _check_scrap_location) ---
            */
            return default;
        }

        protected async Task<StockLocation> CheckSubcontractingLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_location.py, METHOD: _check_subcontracting_location) ---
            */
            return default;
        }

        protected async Task<StockLocation> ChildOfInternalAsync(object other_location)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _child_of) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeChildInternalLocationIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _compute_child_internal_location_ids) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeEquipmentCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_maintenance, FILE: stock_location.py, METHOD: _compute_equipment_count) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeIsEmptyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _compute_is_empty) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeIsValuedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_location.py, METHOD: _compute_is_valued) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeNextInventoryDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _compute_next_inventory_date) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeReplenishLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _compute_replenish_location) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _compute_warehouse_id) ---
            */
            return default;
        }

        protected async Task<StockLocation> ComputeWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        protected async Task<StockLocation> GetNextInventoryDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _get_next_inventory_date) ---
            */
            return default;
        }

        protected async Task<StockLocation> GetPutawayStrategyInternalAsync(object product, object quantity, object package, object packaging, object additional_qty)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _get_putaway_strategy) ---
            */
            return default;
        }

        protected async Task<StockLocation> GetWeightInternalAsync(List<Guid> excluded_sml_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _get_weight) ---
            */
            return default;
        }

        protected async Task<StockLocation> IsOutgoingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _is_outgoing) ---
            */
            return default;
        }

        protected async Task<StockLocation> SearchIsEmptyInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _search_is_empty) ---
            */
            return default;
        }

        protected async Task<StockLocation> SearchIsValuedInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_location.py, METHOD: _search_is_valued) ---
            */
            return default;
        }

        protected async Task<StockLocation> ShouldBeValuedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_location.py, METHOD: _should_be_valued) ---
            */
            return default;
        }

        protected async Task<StockLocation> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_location.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }
    }
}