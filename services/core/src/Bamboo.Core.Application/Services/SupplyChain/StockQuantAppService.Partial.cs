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
    public partial class StockQuantAppService
    {

        protected async Task<StockQuant> ApplyInventoryInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _apply_inventory) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_quant.py, METHOD: _apply_inventory) ---
            */
            return default;
        }

        protected async Task<StockQuant> CheckKitsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_quant.py, METHOD: _check_kits) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> CheckSerialNumberInternalAsync(Guid product_id, Guid lot_id, Guid company_id, Guid source_location_id, Guid ref_doc_location_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _check_serial_number) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> CleanReservationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _clean_reservations) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeAvailableQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_quant.py, METHOD: _compute_available_quantity) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_available_quantity) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeCostMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_quant.py, METHOD: _compute_cost_method) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeInventoryDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_inventory_date) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeInventoryDiffQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_inventory_diff_quantity) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeInventoryQuantityAutoApplyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_inventory_quantity_auto_apply) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeInventoryQuantitySetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_inventory_quantity_set) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeIsOutdatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_is_outdated) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeLastCountDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_last_count_date) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeSnDuplicatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _compute_sn_duplicated) ---
            */
            return default;
        }

        protected async Task<StockQuant> ComputeValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_quant.py, METHOD: _compute_value) ---
            */
            return default;
        }

        protected async Task<StockQuant> DomainLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _domain_location_id) ---
            */
            return default;
        }

        protected async Task<StockQuant> DomainLotIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _domain_lot_id) ---
            */
            return default;
        }

        protected async Task<StockQuant> DomainProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _domain_product_id) ---
            */
            return default;
        }

        protected async Task<StockQuant> GatherInternalAsync(Guid product_id, Guid location_id, Guid lot_id, Guid package_id, Guid owner_id, object strict, object qty)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _gather) ---
            */
            return default;
        }

        protected async Task<StockQuant> GetAvailableQuantityInternalAsync(Guid product_id, Guid location_id, Guid lot_id, Guid package_id, Guid owner_id, object strict, object allow_negative)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_available_quantity) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> GetForbiddenFieldsWriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_forbidden_fields_write) ---
            */
            return default;
        }

        protected async Task<StockQuant> GetGatherDomainInternalAsync(Guid product_id, Guid location_id, Guid lot_id, Guid package_id, Guid owner_id, object strict)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_gather_domain) ---
            */
            return default;
        }

        protected async Task<StockQuant> GetGs1BarcodeInternalAsync(object gs1_quantity_rules_ai_by_uom)
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_quant.py, METHOD: _get_gs1_barcode) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_gs1_barcode) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> GetInventoryFieldsCreateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_inventory_fields_create) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> GetInventoryFieldsWriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_inventory_fields_write) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_quant.py, METHOD: _get_inventory_fields_write) ---
            */
            return default;
        }

        protected async Task<StockQuant> GetInventoryMoveValuesInternalAsync(object qty, Guid location_id, Guid location_dest_id, Guid package_id, Guid package_dest_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_inventory_move_values) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_quant.py, METHOD: _get_inventory_move_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> GetQuantsActionInternalAsync(object extend)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_quants_action) ---
            */
            return default;
        }

        protected async Task<StockQuant> GetQuantsByProductsLocationsInternalAsync(List<Guid> product_ids, List<Guid> location_ids, object extra_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_quants_by_products_locations) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> GetRemovalStrategyInternalAsync(Guid product_id, Guid location_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_removal_strategy) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> GetRemovalStrategyOrderInternalAsync(object removal_strategy)
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_quant.py, METHOD: _get_removal_strategy_order) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_removal_strategy_order) ---
            */
            return default;
        }

        protected async Task<StockQuant> GetReserveQuantityInternalAsync(Guid product_id, Guid location_id, object quantity, Guid uom_id, Guid lot_id, Guid package_id, Guid owner_id, object strict)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _get_reserve_quantity) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> IsInventoryModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _is_inventory_mode) ---
            */
            return default;
        }

        protected async Task<StockQuant> LoadRecordsCreateInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        protected async Task<StockQuant> LoadRecordsWriteInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _load_records_write) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> MergeQuantsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _merge_quants) ---
            */
            return default;
        }

        protected async Task<StockQuant> OnchangeInventoryQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _onchange_inventory_quantity) ---
            */
            return default;
        }

        protected async Task<StockQuant> OnchangeLocationOrProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _onchange_location_or_product_id) ---
            */
            return default;
        }

        protected async Task<StockQuant> OnchangeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        protected async Task<StockQuant> OnchangeSerialNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _onchange_serial_number) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> QuantTasksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _quant_tasks) ---
            */
            return default;
        }

        protected async Task<StockQuant> ReadGroupPostprocessAggregateInternalAsync(object aggregate_spec, object raw_values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_quant.py, METHOD: _read_group_postprocess_aggregate) ---
            */
            return default;
        }

        protected async Task<StockQuant> ReadGroupSelectInternalAsync(object aggregate_spec, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _read_group_select) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_quant.py, METHOD: _read_group_select) ---
            */
            return default;
        }

        protected async Task<StockQuant> RunLeastPackagesRemovalStrategyAstarInternalAsync(object domain, object qty)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _run_least_packages_removal_strategy_astar) ---
            */
            return default;
        }

        protected async Task<StockQuant> SearchInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<StockQuant> SearchIsOutdatedInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _search_is_outdated) ---
            */
            return default;
        }

        protected async Task<StockQuant> SearchIsSubcontractInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_quant.py, METHOD: _search_is_subcontract) ---
            */
            return default;
        }

        protected async Task<StockQuant> SearchOnHandInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _search_on_hand) ---
            */
            return default;
        }

        protected async Task<StockQuant> SetInventoryQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _set_inventory_quantity) ---
            */
            return default;
        }

        protected async Task<StockQuant> SetViewContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_quant.py, METHOD: _set_view_context) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _set_view_context) ---
            */
            return default;
        }

        protected async Task<StockQuant> ShouldBypassProductInternalAsync(object product, object location, object reserved_quantity, Guid lot_id, Guid package_id, Guid owner_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_quant.py, METHOD: _should_bypass_product) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _should_bypass_product) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> ShouldExcludeForValuationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_quant.py, METHOD: _should_exclude_for_valuation) ---
            */
            return default;
        }

        protected async Task<StockQuant> UnlinkExceptWrongPermissionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _unlink_except_wrong_permission) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> UnlinkZeroQuantsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _unlink_zero_quants) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> UpdateAvailableQuantityInternalAsync(Guid product_id, Guid location_id, object quantity, object reserved_quantity, Guid lot_id, Guid package_id, Guid owner_id, object in_date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _update_available_quantity) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockQuant> UpdateReservedQuantityInternalAsync(Guid product_id, Guid location_id, object quantity, Guid lot_id, Guid package_id, Guid owner_id, object strict)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: _update_reserved_quantity) ---
            */
            return default;
        }
    }
}