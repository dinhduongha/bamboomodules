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
    public partial class StockMoveLineAppService
    {

        protected async Task<StockMoveLine> ActionDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _action_done) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> AddToWaveInternalAsync(object wave, object description)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _add_to_wave) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ApplyPutawayStrategyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _apply_putaway_strategy) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> AutoInitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move_line.py, METHOD: _auto_init) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> AutoWaveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _auto_wave) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> AutoWaveLinesIntoExistingWavesInternalAsync(object nearest_parent_locations)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _auto_wave_lines_into_existing_waves) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> AutoWaveLinesIntoNewWavesInternalAsync(object nearest_parent_locations)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _auto_wave_lines_into_new_waves) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> CheckDestinationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _check_destinations) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> CheckLotProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _check_lot_product) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> CheckPositiveQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _check_positive_quantity) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeExpirationDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move_line.py, METHOD: _compute_expiration_date) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeLotsVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _compute_lots_visible) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputePickedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _compute_picked) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputePickingTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: _compute_picking_type_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _compute_picking_type_id) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeProductUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _compute_product_uom_id) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _compute_quantity) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeQuantityProductUomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _compute_quantity_product_uom) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeRemovalDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move_line.py, METHOD: _compute_removal_date) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ComputeSalePriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: stock_move_line.py, METHOD: _compute_sale_price) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _compute_sale_price) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _compute_sale_price) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> CopyQuantInfoInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _copy_quant_info) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> CreateAndAssignProductionLotInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _create_and_assign_production_lot) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ExcludeRequiringLotInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: _exclude_requiring_lot) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _exclude_requiring_lot) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> FreeReservationInternalAsync(Guid product_id, Guid location_id, object quantity, Guid lot_id, Guid package_id, Guid owner_id, object ml_ids_to_ignore)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _free_reservation) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetAggregatedProductQuantitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: _get_aggregated_product_quantities) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _get_aggregated_product_quantities) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _get_aggregated_product_quantities) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetAggregatedPropertiesInternalAsync(object move_line, object move)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: _get_aggregated_properties) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _get_aggregated_properties) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetAutoWaveDescriptionInternalAsync(object nearest_parent_location)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _get_auto_wave_description) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetDefaultDestLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _get_default_dest_location) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetLinesAndPackagesToPackInternalAsync(object picked_first)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _get_lines_and_packages_to_pack) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetLinesNotEntirePackInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _get_lines_not_entire_pack) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetLinkableMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: _get_linkable_moves) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _get_linkable_moves) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetPackageCarrierTypeForPackInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _get_package_carrier_type_for_pack) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetPotentialExistingWavesExtraDomainInternalAsync(object domain_list, object picking_type)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _get_potential_existing_waves_extra_domain) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetPotentialNewWavesExtraDomainInternalAsync(object domain_list, object picking_type)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _get_potential_new_waves_extra_domain) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetPutawayAdditionalQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _get_putaway_additional_qty) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetRevertInventoryMoveValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _get_revert_inventory_move_values) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> GetSimilarMoveLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: _get_similar_move_lines) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _get_similar_move_lines) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> IsAutoWaveableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _is_auto_waveable) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> IsNewPotentialLineExtraInternalAsync(object potential_line)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _is_new_potential_line_extra) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> IsPotentialExistingWaveExtraInternalAsync(object wave)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: _is_potential_existing_wave_extra) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> LogMessageInternalAsync(object record, object move, object template, object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _log_message) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> OnchangeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> OnchangePutawayLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _onchange_putaway_location) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> OnchangeQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _onchange_quantity) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> OnchangeSerialNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move_line.py, METHOD: _onchange_serial_number) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _onchange_serial_number) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> PostPutInPackHookInternalAsync(object package)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _post_put_in_pack_hook) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _post_put_in_pack_hook) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> PrePutInPackHookInternalAsync(object all_lines, Guid package_id, Guid package_type_id, object package_name, object from_package_wizard)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _pre_put_in_pack_hook) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _pre_put_in_pack_hook) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> PrepareNewLotValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move_line.py, METHOD: _prepare_new_lot_vals) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _prepare_new_lot_vals) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> PreparePackageHistoryValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _prepare_package_history_vals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockMoveLine> PrepareStockMoveValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: _prepare_stock_move_vals) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _prepare_stock_move_vals) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> PutInPackInternalAsync(Guid package_id, Guid package_type_id, object package_name)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _put_in_pack) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> SearchPickingTypeIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: _search_picking_type_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _search_picking_type_id) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ShouldDisplayPutInPackWizardInternalAsync(Guid package_id, Guid package_type_id, object package_name, object from_package_wizard)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _should_display_put_in_pack_wizard) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockMoveLine> ShouldExcludeForValuationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py, METHOD: _should_exclude_for_valuation) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ShouldSetPackageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _should_set_package) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _should_set_package) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> ShouldShowLotInInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move_line.py, METHOD: _should_show_lot_in_invoice) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _should_show_lot_in_invoice) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> SynchronizeQuantInternalAsync(object quantity, object location, object action, object in_date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _synchronize_quant) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> UnlinkExceptDoneOrCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: _unlink_except_done_or_cancel) ---
            */
            return default;
        }

        protected async Task<StockMoveLine> UpdateStockMoveValueInternalAsync(object old_qty_by_ml)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py, METHOD: _update_stock_move_value) ---
            */
            return default;
        }
    }
}