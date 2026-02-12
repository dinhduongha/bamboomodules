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
    public partial class StockMoveAppService
    {

        protected async Task<StockMove> ActionAssignInternalAsync(object force_qty)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _action_assign) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _action_assign) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py, METHOD: _action_assign) ---
            */
            return default;
        }

        protected async Task<StockMove> ActionCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py, METHOD: _action_cancel) ---
            */
            return default;
        }

        protected async Task<StockMove> ActionConfirmInternalAsync(object merge, object merge_into, object create_proc)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _action_confirm) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _action_confirm) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _action_confirm) ---
            */
            return default;
        }

        protected async Task<StockMove> ActionDoneInternalAsync(object cancel_backorder)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _action_done) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _action_done) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _action_done) ---
            */
            return default;
        }

        protected async Task<StockMove> ActionSynchOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _action_synch_order) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _action_synch_order) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _action_synch_order) ---
            */
            return default;
        }

        protected async Task<StockMove> AddMlsRelatedToOrderInternalAsync(object related_order_lines, object are_qties_done)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _add_mls_related_to_order) ---
            */
            return default;
        }

        protected async Task<StockMove> AddSerialMoveLineToValsListInternalAsync(object reserved_quant, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _add_serial_move_line_to_vals_list) ---
            */
            return default;
        }

        protected async Task<StockMove> AdjustProcureMethodInternalAsync(object picking_type_code)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _adjust_procure_method) ---
            */
            return default;
        }

        protected async Task<StockMove> AssignPickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _assign_picking) ---
            */
            return default;
        }

        protected async Task<StockMove> AssignPickingPostProcessInternalAsync(object @new)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _assign_picking_post_process) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _assign_picking_post_process) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py, METHOD: _assign_picking_post_process) ---
            */
            return default;
        }

        protected async Task<StockMove> AssignPickingValuesInternalAsync(object picking)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py, METHOD: _assign_picking_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _assign_picking_values) ---
            */
            return default;
        }

        protected async Task<StockMove> AutoInitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _auto_init) ---
            */
            return default;
        }

        protected async Task<StockMove> BreakMtoLinkInternalAsync(object parent_move)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _break_mto_link) ---
            */
            return default;
        }

        protected async Task<StockMove> CalMoveWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _cal_move_weight) ---
            */
            return default;
        }

        protected async Task<StockMove> CanCreateLotInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _can_create_lot) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _can_create_lot) ---
            */
            return default;
        }

        protected async Task<StockMove> CheckAccessIfSubcontractorInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _check_access_if_subcontractor) ---
            */
            return default;
        }

        protected async Task<StockMove> CheckNegativeQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _check_negative_quantity) ---
            */
            return default;
        }

        protected async Task<StockMove> CheckQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _check_quantity) ---
            */
            return default;
        }

        protected async Task<StockMove> CleanMergedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _clean_merged) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _clean_merged) ---
            */
            return default;
        }

        protected async Task<StockMove> CleanRepairSaleOrderLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _clean_repair_sale_order_line) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_allowed_uom_ids) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeDelayAlertDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_delay_alert_date) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeDescriptionPickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_description_picking) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _compute_description_picking) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _compute_description_picking) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_description_picking) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeDisplayAssignSerialInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_display_assign_serial) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_display_assign_serial) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeForecastInformationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _compute_forecast_information) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_forecast_information) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeHasLinesWithoutResultPackageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_has_lines_without_result_package) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsDateEditableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_is_date_editable) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsDropshipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _compute_is_dropship) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsInInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _compute_is_in) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsInitialDemandEditableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_is_initial_demand_editable) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsLockedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_is_locked) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_is_locked) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsOutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _compute_is_out) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsQuantityDoneEditableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _compute_is_quantity_done_editable) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_is_quantity_done_editable) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeIsValuedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _compute_is_valued) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeKitQuantitiesInternalAsync(Guid product_id, object kit_qty, object kit_bom, object filters)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_kit_quantities) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeLocationDestIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_location_dest_id) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _compute_location_dest_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_location_dest_id) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_location_id) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _compute_location_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeLotIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_lot_ids) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeManualConsumptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_manual_consumption) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeMoveLinesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_move_lines_count) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputePackageIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_package_ids) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputePackagingUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_packaging_uom_id) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _compute_packaging_uom_id) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _compute_packaging_uom_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_packaging_uom_id) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputePackagingUomQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_packaging_uom_qty) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _compute_partner_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputePickedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_picked) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputePickingTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_picking_type_id) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _compute_picking_type_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_picking_type_id) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputePriorityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_priority) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_priority) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeProductAvailabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_product_availability) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_product_qty) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeProductUomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_product_uom) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_quantity) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeReferenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_reference) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _compute_reference) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_reference) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeRemainingQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _compute_remaining_qty) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeRemainingValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _compute_remaining_value) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeReservationDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_reservation_date) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeShouldConsumeQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_should_consume_qty) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeShowDetailsVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_show_details_visible) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeShowInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_show_info) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _compute_show_info) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _compute_show_info) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeShowSubcontractingDetailsVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _compute_show_subcontracting_details_visible) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeUnitFactorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _compute_unit_factor) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeValueJustificationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _compute_value_justification) ---
            */
            return default;
        }

        protected async Task<StockMove> ComputeValueManualInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _compute_value_manual) ---
            */
            return default;
        }

        protected async Task<StockMove> ConvertStringIntoFieldDataInternalAsync(object @string, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py, METHOD: _convert_string_into_field_data) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _convert_string_into_field_data) ---
            */
            return default;
        }

        protected async Task<StockMove> CreateAccountMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _create_account_move) ---
            */
            return default;
        }

        protected async Task<StockMove> CreateAnalyticMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _create_analytic_move) ---
            */
            return default;
        }

        protected async Task<StockMove> CreateBackorderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _create_backorder) ---
            */
            return default;
        }

        protected async Task<StockMove> CreateLotIdsFromMoveLineValsInternalAsync(object vals_list, Guid product_id, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _create_lot_ids_from_move_line_vals) ---
            */
            return default;
        }

        protected async Task<StockMove> CreateProductionLotsForPosOrderInternalAsync(object lines)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _create_production_lots_for_pos_order) ---
            */
            return default;
        }

        protected async Task<StockMove> CreateRepairSaleOrderLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _create_repair_sale_order_line) ---
            */
            return default;
        }

        protected async Task<StockMove> DelayAlertGetDocumentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _delay_alert_get_documents) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _delay_alert_get_documents) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockMove> DetermineIsManualConsumptionInternalAsync(object bom_line)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _determine_is_manual_consumption) ---
            */
            return default;
        }

        protected async Task<StockMove> DoUnreserveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _do_unreserve) ---
            */
            return default;
        }

        protected async Task<StockMove> GenerateAllPhantomMovesInternalAsync(object exploded_lines_data)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _generate_all_phantom_moves) ---
            */
            return default;
        }

        protected async Task<StockMove> GenerateMovePhantomInternalAsync(object bom_line, object product_qty, object quantity_done)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _generate_move_phantom) ---
            */
            return default;
        }

        protected async Task<StockMove> GenerateSerialMoveLineCommandsInternalAsync(object field_data, Guid location_dest_id, object origin_move_line)
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py, METHOD: _generate_serial_move_line_commands) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _generate_serial_move_line_commands) ---
            */
            return default;
        }

        protected async Task<StockMove> GenerateSerialNumbersInternalAsync(object next_serial, object next_serial_count, Guid location_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _generate_serial_numbers) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _generate_serial_numbers) ---
            */
            return default;
        }

        protected async Task<StockMove> GetAccountMoveLineValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_account_move_line_vals) ---
            */
            return default;
        }

        protected async Task<StockMove> GetAllRelatedSmInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py, METHOD: _get_all_related_sm) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _get_all_related_sm) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _get_all_related_sm) ---
            */
            return default;
        }

        protected async Task<StockMove> GetAmlValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_account, FILE: stock_move.py, METHOD: _get_aml_value) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_aml_value) ---
            */
            return default;
        }

        protected async Task<StockMove> GetAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: stock_move.py, METHOD: _get_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: project_stock_account, FILE: stock_move.py, METHOD: _get_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<StockMove> GetAvailableMoveLinesInInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_available_move_lines_in) ---
            */
            return default;
        }

        protected async Task<StockMove> GetAvailableMoveLinesInternalAsync(List<Guid> assigned_moves_ids, List<Guid> partially_available_moves_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _get_available_move_lines) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_available_move_lines) ---
            */
            return default;
        }

        protected async Task<StockMove> GetAvailableMoveLinesOutInternalAsync(List<Guid> assigned_moves_ids, List<Guid> partially_available_moves_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_available_move_lines_out) ---
            */
            return default;
        }

        protected async Task<StockMove> GetAvailableQuantityInternalAsync(Guid location_id, Guid lot_id, Guid package_id, Guid owner_id, object strict, object allow_negative)
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py, METHOD: _get_available_quantity) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_available_quantity) ---
            */
            return default;
        }

        protected async Task<StockMove> GetBackorderMoveValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _get_backorder_move_vals) ---
            */
            return default;
        }

        protected async Task<StockMove> GetCostRatioInternalAsync(object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_move.py, METHOD: _get_cost_ratio) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _get_cost_ratio) ---
            */
            return default;
        }

        protected async Task<StockMove> GetDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _get_description) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: stock_move.py, METHOD: _get_description) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_description) ---
            */
            return default;
        }

        protected async Task<StockMove> GetForecastAvailabilityOutgoingInternalAsync(object warehouse, Guid location_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_forecast_availability_outgoing) ---
            */
            return default;
        }

        protected async Task<StockMove> GetFormatingOptionsInternalAsync(object strings)
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py, METHOD: _get_formating_options) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_formating_options) ---
            */
            return default;
        }

        protected async Task<StockMove> GetInMoveLinesInternalAsync(object lot)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_in_move_lines) ---
            */
            return default;
        }

        protected async Task<StockMove> GetKitPriceUnitInternalAsync(object product, object kit_bom, object valuated_quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py, METHOD: _get_kit_price_unit) ---
            */
            return default;
        }

        protected async Task<StockMove> GetLandedCostInternalAsync(object at_date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_move.py, METHOD: _get_landed_cost) ---
            */
            return default;
        }

        protected async Task<StockMove> GetLangInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_lang) ---
            */
            return default;
        }

        protected async Task<StockMove> GetManualValueInternalAsync(object quantity, object at_date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_manual_value) ---
            */
            return default;
        }

        protected async Task<StockMove> GetMoveDirectionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_move_directions) ---
            */
            return default;
        }

        protected async Task<StockMove> GetMtoProcurementDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_mto_procurement_date) ---
            */
            return default;
        }

        protected async Task<StockMove> GetNewPickingValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _get_new_picking_values) ---
            --- METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py, METHOD: _get_new_picking_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_new_picking_values) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _get_new_picking_values) ---
            */
            return default;
        }

        protected async Task<StockMove> GetOutMoveLinesInternalAsync(object lot)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_out_move_lines) ---
            */
            return default;
        }

        protected async Task<StockMove> GetPickedQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_picked_quantity) ---
            */
            return default;
        }

        protected async Task<StockMove> GetPriceUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: stock_move.py, METHOD: _get_price_unit) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_price_unit) ---
            */
            return default;
        }

        protected async Task<StockMove> GetProductCatalogLinesDataInternalAsync(object parent_record)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_product_catalog_lines_data) ---
            */
            return default;
        }

        protected async Task<StockMove> GetPurchaseLineAndPartnerFromChainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _get_purchase_line_and_partner_from_chain) ---
            */
            return default;
        }

        protected async Task<StockMove> GetRelatedInvoicesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _get_related_invoices) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _get_related_invoices) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_related_invoices) ---
            */
            return default;
        }

        protected async Task<StockMove> GetRelevantStateAmongMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _get_relevant_state_among_moves) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_relevant_state_among_moves) ---
            */
            return default;
        }

        protected async Task<StockMove> GetRepairLocationsInternalAsync(object repair_line_type, Guid repair_id)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _get_repair_locations) ---
            */
            return default;
        }

        protected async Task<StockMove> GetSaleOrderLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _get_sale_order_lines) ---
            */
            return default;
        }

        protected async Task<StockMove> GetSourceDocumentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _get_source_document) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _get_source_document) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _get_source_document) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _get_source_document) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_source_document) ---
            */
            return default;
        }

        protected async Task<StockMove> GetSubcontractBomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _get_subcontract_bom) ---
            */
            return default;
        }

        protected async Task<StockMove> GetSubcontractProductionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _get_subcontract_production) ---
            */
            return default;
        }

        protected async Task<StockMove> GetUpstreamDocumentsAndResponsiblesInternalAsync(object visited)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _get_upstream_documents_and_responsibles) ---
            --- METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: stock.py, METHOD: _get_upstream_documents_and_responsibles) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _get_upstream_documents_and_responsibles) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _get_upstream_documents_and_responsibles) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValidMovesDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_stock_account, FILE: stock_move.py, METHOD: _get_valid_moves_domain) ---
            --- METHOD SOURCE (MODULE: sale_project_stock_account, FILE: stock_move.py, METHOD: _get_valid_moves_domain) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValuationPriceAndQtyInternalAsync(object related_aml, object to_curr)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_move.py, METHOD: _get_valuation_price_and_qty) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValueDataInternalAsync(object forced_std_price, object at_date, object ignore_manual_update, object add_extra_value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_value_data) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromAccountMoveInternalAsync(object quantity, object at_date)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_move.py, METHOD: _get_value_from_account_move) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _get_value_from_account_move) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_value_from_account_move) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromExtraInternalAsync(object quantity, object at_date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_value_from_extra) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_move.py, METHOD: _get_value_from_extra) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromProductionInternalAsync(object quantity, object at_date)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: stock_move.py, METHOD: _get_value_from_production) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_value_from_production) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromQuotationInternalAsync(object quantity, object at_date)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _get_value_from_quotation) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_value_from_quotation) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromReturnsInternalAsync(object quantity, object at_date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_value_from_returns) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValueFromStdPriceInternalAsync(object quantity, object std_price, object at_date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_value_from_std_price) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValueInternalAsync(object forced_std_price, object at_date, object ignore_manual_update)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_value) ---
            */
            return default;
        }

        protected async Task<StockMove> GetValuedQtyInternalAsync(object lot)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_valued_qty) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockMove> GetValuedTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _get_valued_types) ---
            */
            return default;
        }

        protected async Task<StockMove> InverseDescriptionPickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _inverse_description_picking) ---
            */
            return default;
        }

        protected async Task<StockMove> InversePickedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _inverse_picked) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _inverse_picked) ---
            */
            return default;
        }

        protected async Task<StockMove> InverseValueManualInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _inverse_value_manual) ---
            */
            return default;
        }

        protected async Task<StockMove> IsConsumingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _is_consuming) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _is_consuming) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _is_consuming) ---
            */
            return default;
        }

        protected async Task<StockMove> IsDropshippedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_move.py, METHOD: _is_dropshipped) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _is_dropshipped) ---
            */
            return default;
        }

        protected async Task<StockMove> IsDropshippedReturnedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_move.py, METHOD: _is_dropshipped_returned) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _is_dropshipped_returned) ---
            */
            return default;
        }

        protected async Task<StockMove> IsInInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _is_in) ---
            */
            return default;
        }

        protected async Task<StockMove> IsIncomingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _is_incoming) ---
            */
            return default;
        }

        protected async Task<StockMove> IsManualConsumptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _is_manual_consumption) ---
            */
            return default;
        }

        protected async Task<StockMove> IsOutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _is_out) ---
            */
            return default;
        }

        protected async Task<StockMove> IsOutgoingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _is_outgoing) ---
            */
            return default;
        }

        protected async Task<StockMove> IsPurchaseReturnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_move.py, METHOD: _is_purchase_return) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_move.py, METHOD: _is_purchase_return) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _is_purchase_return) ---
            */
            return default;
        }

        protected async Task<StockMove> IsReturnedInternalAsync(object valued_type)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _is_returned) ---
            */
            return default;
        }

        protected async Task<StockMove> IsSubcontractReturnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _is_subcontract_return) ---
            */
            return default;
        }

        protected async Task<StockMove> KeyAssignPickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _key_assign_picking) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _key_assign_picking) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _key_assign_picking) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_move.py, METHOD: _key_assign_picking) ---
            */
            return default;
        }

        protected async Task<StockMove> MatchSearchedAvailabilityInternalAsync(object @operator, object @value, object get_comparison_date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _match_searched_availability) ---
            */
            return default;
        }

        protected async Task<StockMove> MergeMoveItemgetterInternalAsync(object distinct_fields, object excluded_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _merge_move_itemgetter) ---
            */
            return default;
        }

        protected async Task<StockMove> MergeMovesFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _merge_moves_fields) ---
            */
            return default;
        }

        protected async Task<StockMove> MergeMovesInternalAsync(object merge_into)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _merge_moves) ---
            */
            return default;
        }

        protected async Task<StockMove> OnchangeLotIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _onchange_lot_ids) ---
            */
            return default;
        }

        protected async Task<StockMove> OnchangeProductUomQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _onchange_product_uom_qty) ---
            */
            return default;
        }

        protected async Task<StockMove> OnchangeQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _onchange_quantity) ---
            */
            return default;
        }

        protected async Task<StockMove> PostProcessCreatedMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _post_process_created_moves) ---
            */
            return default;
        }

        protected async Task<StockMove> PrepareAnalyticLineValuesInternalAsync(object account_field_values, object amount, object unit_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: stock_move.py, METHOD: _prepare_analytic_line_values) ---
            --- METHOD SOURCE (MODULE: project_stock_account, FILE: stock_move.py, METHOD: _prepare_analytic_line_values) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _prepare_analytic_line_values) ---
            */
            return default;
        }

        protected async Task<StockMove> PrepareAnalyticLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: stock_move.py, METHOD: _prepare_analytic_lines) ---
            --- METHOD SOURCE (MODULE: project_stock_account, FILE: stock_move.py, METHOD: _prepare_analytic_lines) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _prepare_analytic_lines) ---
            */
            return default;
        }

        protected async Task<StockMove> PrepareExtraMoveValsInternalAsync(object qty)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _prepare_extra_move_vals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockMove> PrepareLinesDataDictInternalAsync(object order_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _prepare_lines_data_dict) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockMove> PrepareMergeMovesDistinctFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _prepare_merge_moves_distinct_fields) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _prepare_merge_moves_distinct_fields) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _prepare_merge_moves_distinct_fields) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _prepare_merge_moves_distinct_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockMove> PrepareMergeNegativeMovesExcludedDistinctFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _prepare_merge_negative_moves_excluded_distinct_fields) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _prepare_merge_negative_moves_excluded_distinct_fields) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _prepare_merge_negative_moves_excluded_distinct_fields) ---
            */
            return default;
        }

        protected async Task<StockMove> PrepareMoveLineValsInternalAsync(object quantity, object reserved_quant)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _prepare_move_line_vals) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _prepare_move_line_vals) ---
            */
            return default;
        }

        protected async Task<StockMove> PrepareMoveSplitValsInternalAsync(object qty)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _prepare_move_split_vals) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _prepare_move_split_vals) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _prepare_move_split_vals) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _prepare_move_split_vals) ---
            */
            return default;
        }

        protected async Task<StockMove> PreparePhantomLineValsInternalAsync(object bom_line, object qty)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py, METHOD: _prepare_phantom_line_vals) ---
            */
            return default;
        }

        protected async Task<StockMove> PreparePhantomMoveValuesInternalAsync(object bom_line, object product_qty, object quantity_done)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _prepare_phantom_move_values) ---
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: stock_move.py, METHOD: _prepare_phantom_move_values) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_move.py, METHOD: _prepare_phantom_move_values) ---
            */
            return default;
        }

        protected async Task<StockMove> PrepareProcurementOriginInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _prepare_procurement_origin) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _prepare_procurement_origin) ---
            */
            return default;
        }

        protected async Task<StockMove> PrepareProcurementQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _prepare_procurement_qty) ---
            */
            return default;
        }

        protected async Task<StockMove> PrepareProcurementValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: project_mrp, FILE: stock.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _prepare_procurement_values) ---
            */
            return default;
        }

        protected async Task<StockMove> PropagateDateLogNoteInternalAsync(object move_orig)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _propagate_date_log_note) ---
            */
            return default;
        }

        protected async Task<StockMove> PushApplyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _push_apply) ---
            */
            return default;
        }

        protected async Task<StockMove> QuantitySmlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _quantity_sml) ---
            */
            return default;
        }

        protected async Task<StockMove> ReassignSaleLinesInternalAsync(object sale_order)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _reassign_sale_lines) ---
            */
            return default;
        }

        protected async Task<StockMove> RecomputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _recompute_state) ---
            */
            return default;
        }

        protected async Task<StockMove> RollupMoveDestsFetchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _rollup_move_dests_fetch) ---
            */
            return default;
        }

        protected async Task<StockMove> RollupMoveDestsInternalAsync(object seen)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _rollup_move_dests) ---
            */
            return default;
        }

        protected async Task<StockMove> RollupMoveOrigsFetchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _rollup_move_origs_fetch) ---
            */
            return default;
        }

        protected async Task<StockMove> RollupMoveOrigsInternalAsync(object seen)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _rollup_move_origs) ---
            */
            return default;
        }

        protected async Task<StockMove> RollupMovesInternalAsync(object origin, object seen)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _rollup_moves) ---
            */
            return default;
        }

        protected async Task<StockMove> RunProcurementInternalAsync(object old_qties)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _run_procurement) ---
            */
            return default;
        }

        protected async Task<StockMove> SaleGetInvoicePriceInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py, METHOD: _sale_get_invoice_price) ---
            */
            return default;
        }

        protected async Task<StockMove> SalePrepareSaleLineValuesInternalAsync(object order, object price, object last_sequence)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project_stock, FILE: stock_move.py, METHOD: _sale_prepare_sale_line_values) ---
            */
            return default;
        }

        protected async Task<StockMove> SearchPickingForAssignationDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _search_picking_for_assignation_domain) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _search_picking_for_assignation_domain) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py, METHOD: _search_picking_for_assignation_domain) ---
            */
            return default;
        }

        protected async Task<StockMove> SearchPickingForAssignationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _search_picking_for_assignation) ---
            */
            return default;
        }

        protected async Task<StockMove> SetDateDeadlineInternalAsync(object new_deadline)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _set_date_deadline) ---
            */
            return default;
        }

        protected async Task<StockMove> SetLocationDestIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _set_location_dest_id) ---
            */
            return default;
        }

        protected async Task<StockMove> SetLotIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _set_lot_ids) ---
            */
            return default;
        }

        protected async Task<StockMove> SetProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _set_product_qty) ---
            */
            return default;
        }

        protected async Task<StockMove> SetQuantityDoneInternalAsync(object qty)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _set_quantity_done) ---
            */
            return default;
        }

        protected async Task<StockMove> SetQuantityDonePrepareValsInternalAsync(object qty)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _set_quantity_done_prepare_vals) ---
            */
            return default;
        }

        protected async Task<StockMove> SetQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _set_quantity) ---
            */
            return default;
        }

        protected async Task<StockMove> SetReferencesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _set_references) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _set_references) ---
            */
            return default;
        }

        protected async Task<StockMove> SetRepairLocationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _set_repair_locations) ---
            */
            return default;
        }

        protected async Task<StockMove> SetValueInternalAsync(object correction_quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _set_value) ---
            */
            return default;
        }

        protected async Task<StockMove> ShouldAssignAtConfirmInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _should_assign_at_confirm) ---
            */
            return default;
        }

        protected async Task<StockMove> ShouldBeAssignedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _should_be_assigned) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _should_be_assigned) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _should_be_assigned) ---
            */
            return default;
        }

        protected async Task<StockMove> ShouldBypassReservationInternalAsync(object forced_location)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _should_bypass_reservation) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _should_bypass_reservation) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _should_bypass_reservation) ---
            */
            return default;
        }

        protected async Task<StockMove> ShouldBypassSetQtyProducingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _should_bypass_set_qty_producing) ---
            */
            return default;
        }

        protected async Task<StockMove> ShouldCreateAccountMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _should_create_account_move) ---
            */
            return default;
        }

        protected async Task<StockMove> ShouldExcludeForValuationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: _should_exclude_for_valuation) ---
            */
            return default;
        }

        protected async Task<StockMove> ShouldIgnorePolPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_move.py, METHOD: _should_ignore_pol_price) ---
            */
            return default;
        }

        protected async Task<StockMove> SkipPushInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _skip_push) ---
            */
            return default;
        }

        protected async Task<StockMove> SplitInternalAsync(object qty, Guid restrict_partner_id)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _split) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _split) ---
            */
            return default;
        }

        protected async Task<StockMove> SyncSubcontractingProductionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: _sync_subcontracting_productions) ---
            */
            return default;
        }

        protected async Task<StockMove> TriggerAssignInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _trigger_assign) ---
            */
            return default;
        }

        protected async Task<StockMove> TriggerSchedulerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _trigger_scheduler) ---
            */
            return default;
        }

        protected async Task<StockMove> UnlinkIfDraftOrCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _unlink_if_draft_or_cancel) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _unlink_if_draft_or_cancel) ---
            */
            return default;
        }

        protected async Task<StockMove> UpdateCandidateMovesListInternalAsync(object candidate_moves_set)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: _update_candidate_moves_list) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _update_candidate_moves_list) ---
            */
            return default;
        }

        protected async Task<StockMove> UpdateOrderpointsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _update_orderpoints) ---
            */
            return default;
        }

        protected async Task<StockMove> UpdateRepairSaleOrderLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: _update_repair_sale_order_line) ---
            */
            return default;
        }

        protected async Task<StockMove> UpdateReservedQuantityInternalAsync(object need, Guid location_id, Guid lot_id, Guid package_id, Guid owner_id, object strict)
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py, METHOD: _update_reserved_quantity) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _update_reserved_quantity) ---
            */
            return default;
        }

        protected async Task<StockMove> UpdateReservedQuantityValsInternalAsync(object need, Guid location_id, Guid lot_id, Guid package_id, Guid owner_id, object strict)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _update_reserved_quantity_vals) ---
            */
            return default;
        }

        protected async Task<StockMove> VisibleQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: _visible_quantity) ---
            */
            return default;
        }
    }
}