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
    public partial class StockPickingAppService
    {

        protected async Task<StockPicking> ActionDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _action_done) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _action_done) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _action_done) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _action_done) ---
            */
            return default;
        }

        protected async Task<StockPicking> ActionGenerateBackorderWizardInternalAsync(object show_transfers)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _action_generate_backorder_wizard) ---
            */
            return default;
        }

        protected async Task<StockPicking> ActionGenerateExpiredWizardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_picking.py, METHOD: _action_generate_expired_wizard) ---
            */
            return default;
        }

        protected async Task<StockPicking> ActionGenerateWarnSmsWizardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_sms, FILE: stock_picking.py, METHOD: _action_generate_warn_sms_wizard) ---
            */
            return default;
        }

        protected async Task<StockPicking> AddDeliveryCostToSoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _add_delivery_cost_to_so) ---
            */
            return default;
        }

        protected async Task<StockPicking> AddReferenceInternalAsync(object reference)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _add_reference) ---
            */
            return default;
        }

        protected async Task<StockPicking> AddToWavePostPickingSplitHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _add_to_wave_post_picking_split_hook) ---
            */
            return default;
        }

        protected async Task<StockPicking> AttachSignInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _attach_sign) ---
            */
            return default;
        }

        protected async Task<StockPicking> AutoInitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _auto_init) ---
            */
            return default;
        }

        protected async Task<StockPicking> AutoconfirmPickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _autoconfirm_picking) ---
            */
            return default;
        }

        protected async Task<StockPicking> CalWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _cal_weight) ---
            */
            return default;
        }

        protected async Task<StockPicking> CanReturnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _can_return) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _can_return) ---
            */
            return default;
        }

        protected async Task<StockPicking> CarrierExceptionNoteInternalAsync(object exception)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _carrier_exception_note) ---
            */
            return default;
        }

        protected async Task<StockPicking> CheckBackdateAllowedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_picking.py, METHOD: _check_backdate_allowed) ---
            */
            return default;
        }

        protected async Task<StockPicking> CheckBackorderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _check_backorder) ---
            */
            return default;
        }

        protected async Task<StockPicking> CheckCarrierDetailsComplianceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _check_carrier_details_compliance) ---
            */
            return default;
        }

        protected async Task<StockPicking> CheckEntirePackInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _check_entire_pack) ---
            */
            return default;
        }

        protected async Task<StockPicking> CheckExpiredLotsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_picking.py, METHOD: _check_expired_lots) ---
            */
            return default;
        }

        protected async Task<StockPicking> CheckMoveLinesMapQuantPackageInternalAsync(object package)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _check_move_lines_map_quant_package) ---
            */
            return default;
        }

        protected async Task<StockPicking> CheckWarnSmsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_sms, FILE: stock_picking.py, METHOD: _check_warn_sms) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeAllowedCarrierIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _compute_allowed_carrier_ids) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeBulkWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_bulk_weight) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeCarrierTrackingUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _compute_carrier_tracking_url) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeDateDeadlineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_date_deadline) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeDateOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_date_order) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeDelayAlertDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_delay_alert_date) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeEffectiveDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_effective_date) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeHasDeadlineIssueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_has_deadline_issue) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeHasKitsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: _compute_has_kits) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeHasTrackingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_has_tracking) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeIsDateEditableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_is_date_editable) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_picking.py, METHOD: _compute_is_date_editable) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeIsDropshipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_picking.py, METHOD: _compute_is_dropship) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _compute_is_dropship) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeIsSignedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_is_signed) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeJsonPopoverInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_json_popover) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _compute_location_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeMoveTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _compute_move_type) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_move_type) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeMrpProductionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: _compute_mrp_production_ids) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeNbrRepairsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: _compute_nbr_repairs) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputePackagesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_packages_count) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputePickingWarningTextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_picking_warning_text) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeProductsAvailabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_products_availability) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeReturnCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_return_count) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeReturnLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _compute_return_label) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeReturnPickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _compute_return_picking) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeSaleIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _compute_sale_id) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeScheduledDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_scheduled_date) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShippingVolumeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_shipping_volume) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShippingWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_shipping_weight) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowAllocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_show_allocation) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowCheckAvailabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_show_check_availability) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowLotsTextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _compute_show_lots_text) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_show_lots_text) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowNextPickingsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_show_next_pickings) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeShowSubcontractingDetailsVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _compute_show_subcontracting_details_visible) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeSubcontractingSourcePurchaseCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_picking.py, METHOD: _compute_subcontracting_source_purchase_count) ---
            */
            return default;
        }

        protected async Task<StockPicking> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        protected async Task<StockPicking> CreateBackorderInternalAsync(object backorder_moves)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _create_backorder) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _create_backorder) ---
            */
            return default;
        }

        protected async Task<StockPicking> CreateBackorderPickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _create_backorder_picking) ---
            */
            return default;
        }

        protected async Task<StockPicking> CreateMoveFromPosOrderLinesInternalAsync(object lines)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _create_move_from_pos_order_lines) ---
            --- METHOD SOURCE (MODULE: pos_repair, FILE: stock_picking.py, METHOD: _create_move_from_pos_order_lines) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: stock_picking.py, METHOD: _create_move_from_pos_order_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPicking> CreatePickingFromPosOrderLinesInternalAsync(Guid location_dest_id, object lines, object picking_type, object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _create_picking_from_pos_order_lines) ---
            */
            return default;
        }

        protected async Task<StockPicking> DefaultPickingTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _default_picking_type_id) ---
            */
            return default;
        }

        protected async Task<StockPicking> FindAutoBatchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _find_auto_batch) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetActionInternalAsync(object action_xmlid)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_action) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetAutoBatchDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py, METHOD: _get_auto_batch_description) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _get_auto_batch_description) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetAutoprintReportActionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_autoprint_report_actions) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetDefaultWeightUomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _get_default_weight_uom) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetEntirePackLocationDestInternalAsync(List<Guid> move_line_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_entire_pack_location_dest) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetEstimatedWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _get_estimated_weight) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetImpactedPickingsInternalAsync(object moves)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_impacted_pickings) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetLotMoveLinesForSanityCheckInternalAsync(List<Guid> none_done_picking_ids, object separate_pickings)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_lot_move_lines_for_sanity_check) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetMatchingDeliveryLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _get_matching_delivery_lines) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetMovesToBackorderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_moves_to_backorder) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetNextTransfersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_next_transfers) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetPackagesForPrintInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_packages_for_print) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetPossibleBatchesDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py, METHOD: _get_possible_batches_domain) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _get_possible_batches_domain) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetPossiblePickingsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py, METHOD: _get_possible_pickings_domain) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _get_possible_pickings_domain) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetReportLangInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_report_lang) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetShowAllocationInternalAsync(Guid picking_type_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_show_allocation) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetSubcontractMoConfirmationCtxInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _get_subcontract_mo_confirmation_ctx) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_picking.py, METHOD: _get_subcontract_mo_confirmation_ctx) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetSubcontractProductionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _get_subcontract_production) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetSubcontractingSourcePurchaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_picking.py, METHOD: _get_subcontracting_source_purchase) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetWarehouseInternalAsync(object subcontract_move)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _get_warehouse) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_picking.py, METHOD: _get_warehouse) ---
            */
            return default;
        }

        protected async Task<StockPicking> GetWithoutQuantitiesErrorMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_without_quantities_error_message) ---
            */
            return default;
        }

        protected async Task<StockPicking> HasScrapMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _has_scrap_move) ---
            */
            return default;
        }

        protected async Task<StockPicking> IsAutoBatchableInternalAsync(object picking)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_stock_picking_batch, FILE: stock_picking.py, METHOD: _is_auto_batchable) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _is_auto_batchable) ---
            */
            return default;
        }

        protected async Task<StockPicking> IsDateInLockPeriodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_picking.py, METHOD: _is_date_in_lock_period) ---
            */
            return default;
        }

        protected async Task<StockPicking> IsSingleTransferInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _is_single_transfer) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _is_single_transfer) ---
            */
            return default;
        }

        protected async Task<StockPicking> IsSubcontractInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _is_subcontract) ---
            */
            return default;
        }

        protected async Task<StockPicking> IsToExternalLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _is_to_external_location) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _is_to_external_location) ---
            */
            return default;
        }

        protected async Task<StockPicking> LessQuantitiesThanExpectedAddDocumentsInternalAsync(object moves, object documents)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: _less_quantities_than_expected_add_documents) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _less_quantities_than_expected_add_documents) ---
            */
            return default;
        }

        protected async Task<StockPicking> LinkOwnerOnReturnPickingInternalAsync(object lines)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _link_owner_on_return_picking) ---
            */
            return default;
        }

        protected async Task<StockPicking> LogActivityGetDocumentsInternalAsync(object orig_obj_changes, object stream_field, object stream, object groupby_method)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _log_activity_get_documents) ---
            */
            return default;
        }

        protected async Task<StockPicking> LogActivityInternalAsync(object render_method, object documents)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _log_activity) ---
            */
            return default;
        }

        protected async Task<StockPicking> LogLessQuantitiesThanExpectedInternalAsync(object moves)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _log_less_quantities_than_expected) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _log_less_quantities_than_expected) ---
            */
            return default;
        }

        protected async Task<StockPicking> OnchangeLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _onchange_location_id) ---
            */
            return default;
        }

        protected async Task<StockPicking> OnchangePickingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _onchange_picking_type) ---
            */
            return default;
        }

        protected async Task<StockPicking> PreActionDoneHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_picking.py, METHOD: _pre_action_done_hook) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _pre_action_done_hook) ---
            --- METHOD SOURCE (MODULE: stock_sms, FILE: stock_picking.py, METHOD: _pre_action_done_hook) ---
            */
            return default;
        }

        protected async Task<StockPicking> PrepareEntirePackMoveLineValsInternalAsync(object packages)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _prepare_entire_pack_move_line_vals) ---
            */
            return default;
        }

        protected async Task<StockPicking> PreparePickingValsInternalAsync(object partner, object picking_type, Guid location_id, Guid location_dest_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _prepare_picking_vals) ---
            */
            return default;
        }

        protected async Task<StockPicking> PrepareSaleDeliveryLineValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _prepare_sale_delivery_line_vals) ---
            */
            return default;
        }

        protected async Task<StockPicking> PrepareStockMoveValsInternalAsync(object first_line, object order_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _prepare_stock_move_vals) ---
            */
            return default;
        }

        protected async Task<StockPicking> PrepareSubcontractMoValsInternalAsync(object subcontract_move, object bom)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _prepare_subcontract_mo_vals) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_picking.py, METHOD: _prepare_subcontract_mo_vals) ---
            */
            return default;
        }

        protected async Task<StockPicking> RemoveReferenceInternalAsync(object reference)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _remove_reference) ---
            */
            return default;
        }

        protected async Task<StockPicking> ResetLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking.py, METHOD: _reset_location) ---
            */
            return default;
        }

        protected async Task<StockPicking> SanityCheckInternalAsync(object separate_pickings)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _sanity_check) ---
            */
            return default;
        }

        protected async Task<StockPicking> SearchDateCategoryInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _search_date_category) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPicking> SearchDaysToArriveInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _search_days_to_arrive) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPicking> SearchDelayAlertDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _search_delay_alert_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockPicking> SearchDelayPassInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _search_delay_pass) ---
            */
            return default;
        }

        protected async Task<StockPicking> SearchProductsAvailabilityStateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _search_products_availability_state) ---
            */
            return default;
        }

        protected async Task<StockPicking> SearchZipInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_fleet, FILE: stock_picking.py, METHOD: _search_zip) ---
            */
            return default;
        }

        protected async Task<StockPicking> SendConfirmationEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: stock_picking.py, METHOD: _send_confirmation_email) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _send_confirmation_email) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _send_confirmation_email) ---
            --- METHOD SOURCE (MODULE: stock_sms, FILE: stock_picking.py, METHOD: _send_confirmation_email) ---
            */
            return default;
        }

        protected async Task<StockPicking> SetSaleIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _set_sale_id) ---
            */
            return default;
        }

        protected async Task<StockPicking> SetScheduledDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _set_scheduled_date) ---
            */
            return default;
        }

        protected async Task<StockPicking> ShouldGenerateCommercialInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_picking.py, METHOD: _should_generate_commercial_invoice) ---
            */
            return default;
        }

        protected async Task<StockPicking> ShouldIgnoreBackordersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _should_ignore_backorders) ---
            */
            return default;
        }

        protected async Task<StockPicking> ShouldShowTransfersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _should_show_transfers) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: _should_show_transfers) ---
            */
            return default;
        }

        protected async Task<StockPicking> SubcontractedProduceInternalAsync(object subcontract_details)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_picking.py, METHOD: _subcontracted_produce) ---
            */
            return default;
        }
    }
}