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
    public partial class MrpProductionAppService
    {

        protected async Task<MrpProduction> ActionCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_cancel) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ActionConfirmMoBackordersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_confirm_mo_backorders) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ActionGenerateBackorderWizardInternalAsync(object quantity_issues)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_generate_backorder_wizard) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ActionGenerateConsumptionWizardInternalAsync(object consumption_issues)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_generate_consumption_wizard) ---
            */
            return default;
        }

        protected async Task<MrpProduction> AddReferenceInternalAsync(object reference)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _add_reference) ---
            */
            return default;
        }

        protected async Task<MrpProduction> AreFinishedSerialsAlreadyProducedInternalAsync(object lots, object excluded_sml)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _are_finished_serials_already_produced) ---
            */
            return default;
        }

        protected async Task<MrpProduction> AutoProductionChecksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _auto_production_checks) ---
            */
            return default;
        }

        protected async Task<MrpProduction> AutoconfirmProductionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _autoconfirm_production) ---
            */
            return default;
        }

        protected async Task<MrpProduction> AutoprintGeneratedLotInternalAsync(Guid lot_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _autoprint_generated_lot) ---
            */
            return default;
        }

        protected async Task<MrpProduction> AutoprintMassGeneratedLotsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _autoprint_mass_generated_lots) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ButtonMarkDoneSanityChecksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _button_mark_done_sanity_checks) ---
            */
            return default;
        }

        protected async Task<MrpProduction> CalPriceInternalAsync(object consumed_moves)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _cal_price) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_production.py, METHOD: _cal_price) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_account, FILE: mrp_production.py, METHOD: _cal_price) ---
            */
            return default;
        }

        protected async Task<MrpProduction> CanProduceSerialNumbersInternalAsync(object sns)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _can_produce_serial_numbers) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ChangeProducingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _change_producing) ---
            */
            return default;
        }

        protected async Task<MrpProduction> CheckByproductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _check_byproducts) ---
            */
            return default;
        }

        protected async Task<MrpProduction> CheckExpiredLotsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_product_expiry, FILE: mrp_production.py, METHOD: _check_expired_lots) ---
            */
            return default;
        }

        protected async Task<MrpProduction> CheckLotProducingIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _check_lot_producing_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> CheckSnUniquenessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _check_sn_uniqueness) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeBomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_bom_id) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeBomProductIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: _compute_bom_product_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeComponentsAvailabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_components_availability) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeDateDeadlineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_date_deadline) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeDateFinishedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_date_finished) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeDelayAlertDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_delay_alert_date) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeDurationExpectedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_duration_expected) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeForecastedIssueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_forecasted_issue) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeHasAnalyticAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: mrp_production.py, METHOD: _compute_has_analytic_account) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeIsDelayedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_is_delayed) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeIsPlannedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_is_planned) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeJsonPopoverInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_json_popover) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_lines) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeLocationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_locations) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeMoveByproductIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_move_byproduct_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeMoveFinishedIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_move_finished_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeMoveLineRawIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: _compute_move_line_raw_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeMoveRawIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_move_raw_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeMrpProductionBackorderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_mrp_production_backorder) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeMrpProductionChildCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_mrp_production_child_count) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeMrpProductionSourceCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_mrp_production_source_count) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputePickingIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputePickingTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_picking_type_id) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_product_id) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_product_qty) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeProductUomQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_product_uom_qty) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeProductionCapacityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_production_capacity) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeProductionLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_production_location) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeProjectIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp, FILE: mrp_production.py, METHOD: _compute_project_id) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputePurchaseOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_production.py, METHOD: _compute_purchase_order_count) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeRepairCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: production.py, METHOD: _compute_repair_count) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeReservationStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_reservation_state) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: mrp_production.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeScrapMoveCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_scrap_move_count) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeSerialNumbersCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_serial_numbers_count) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeShowAllocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_allocation) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeShowGenerateBomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_generate_bom) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeShowLockInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_lock) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeShowLotIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_lot_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeShowLotsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_lots) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeShowProduceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_produce) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeShowValuationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_production.py, METHOD: _compute_show_valuation) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeUnbuildCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_unbuild_count) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeUnreserveVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_unreserve_visible) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_uom_id) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeWipMoveCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_production.py, METHOD: _compute_wip_move_count) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ComputeWorkorderIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_workorder_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> CreateUpdateMoveFinishedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _create_update_move_finished) ---
            */
            return default;
        }

        protected async Task<MrpProduction> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetAutoprintDoneReportActionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_autoprint_done_report_actions) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetBackorderMoValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_backorder_mo_vals) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_production.py, METHOD: _get_backorder_mo_vals) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetBomValuesInternalAsync(object ratio)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_bom_values) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetChildrenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_children) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetConsumptionIssuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_consumption_issues) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpProduction> GetDefaultDateFinishedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_date_finished) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpProduction> GetDefaultDateStartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_date_start) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpProduction> GetDefaultIsLockedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_is_locked) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpProduction> GetDefaultPickingTypeIdInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_picking_type_id) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetDocumentIterateKeyInternalAsync(Guid move_raw_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_document_iterate_key) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_production.py, METHOD: _get_document_iterate_key) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetExpiredContextInternalAsync(List<Guid> expired_lot_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_product_expiry, FILE: mrp_production.py, METHOD: _get_expired_context) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetMoveFinishedValuesInternalAsync(Guid product_id, object product_uom_qty, object product_uom, Guid operation_id, Guid byproduct_id, object cost_share)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_move_finished_values) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetMoveRawValuesInternalAsync(object product, object product_uom_qty, object product_uom, Guid operation_id, object bom_line)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_move_raw_values) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetMovesFinishedValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_moves_finished_values) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetMovesRawValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_moves_raw_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpProduction> GetNameBackorderInternalAsync(object name, object sequence)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_name_backorder) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetNewCatalogLineValuesInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_new_catalog_line_values) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetOriginInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_origin) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetProducedQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_produced_qty) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetProductCatalogDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_catalog_domain) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetProductPriceAndDataInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_price_and_data) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetPurchaseOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_production.py, METHOD: _get_purchase_orders) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetQuantityProducedIssuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_quantity_produced_issues) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetQuantityToBackorderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_quantity_to_backorder) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetRatioBetweenMoAndBomQuantitiesInternalAsync(object bom)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_ratio_between_mo_and_bom_quantities) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetReadyToProduceStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_ready_to_produce_state) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetSourcesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_sources) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetSubcontractMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: _get_subcontract_move) ---
            */
            return default;
        }

        protected async Task<MrpProduction> GetWriteableFieldsPortalUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: _get_writeable_fields_portal_user) ---
            */
            return default;
        }

        protected async Task<MrpProduction> HasWorkordersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _has_workorders) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: _has_workorders) ---
            */
            return default;
        }

        protected async Task<MrpProduction> InverseLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _inverse_lines) ---
            */
            return default;
        }

        protected async Task<MrpProduction> InverseMoveLineRawIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: _inverse_move_line_raw_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> IsDisplayStockInCatalogInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _is_display_stock_in_catalog) ---
            */
            return default;
        }

        protected async Task<MrpProduction> LinkBomInternalAsync(object bom)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _link_bom) ---
            */
            return default;
        }

        protected async Task<MrpProduction> LinkWorkordersAndMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _link_workorders_and_moves) ---
            */
            return default;
        }

        protected async Task<MrpProduction> LogDownsideManufacturedQuantityInternalAsync(object moves_modification, object cancel)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _log_downside_manufactured_quantity) ---
            */
            return default;
        }

        protected async Task<MrpProduction> LogManufactureExceptionInternalAsync(object documents, object cancel)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _log_manufacture_exception) ---
            */
            return default;
        }

        protected async Task<MrpProduction> MarkByproductsAsProducedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _mark_byproducts_as_produced) ---
            */
            return default;
        }

        protected async Task<MrpProduction> OnchangeLotProducingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _onchange_lot_producing) ---
            */
            return default;
        }

        protected async Task<MrpProduction> OnchangeQtyProducingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _onchange_qty_producing) ---
            */
            return default;
        }

        protected async Task<MrpProduction> PlanWorkordersInternalAsync(object replan)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _plan_workorders) ---
            */
            return default;
        }

        protected async Task<MrpProduction> PostInventoryInternalAsync(object cancel_backorder)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _post_inventory) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_production.py, METHOD: _post_inventory) ---
            */
            return default;
        }

        protected async Task<MrpProduction> PostLabourInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_production.py, METHOD: _post_labour) ---
            */
            return default;
        }

        protected async Task<MrpProduction> PostRunManufactureInternalAsync(object post_production_values)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _post_run_manufacture) ---
            */
            return default;
        }

        protected async Task<MrpProduction> PreActionSplitMergeHookInternalAsync(object merge, object split)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _pre_action_split_merge_hook) ---
            */
            return default;
        }

        protected async Task<MrpProduction> PrepareFinishedExtraValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _prepare_finished_extra_vals) ---
            */
            return default;
        }

        protected async Task<MrpProduction> PrepareMergeOrigLinksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _prepare_merge_orig_links) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: mrp_production.py, METHOD: _prepare_merge_orig_links) ---
            */
            return default;
        }

        protected async Task<MrpProduction> PrepareStockLotValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _prepare_stock_lot_values) ---
            */
            return default;
        }

        protected async Task<MrpProduction> RemoveReferenceInternalAsync(object reference)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _remove_reference) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ResequenceWorkordersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _resequence_workorders) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpProduction> SearchComponentsAvailabilityStateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_components_availability_state) ---
            */
            return default;
        }

        protected async Task<MrpProduction> SearchDateCategoryInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_date_category) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MrpProduction> SearchDelayAlertDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_delay_alert_date) ---
            */
            return default;
        }

        protected async Task<MrpProduction> SearchIsDelayedInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_is_delayed) ---
            */
            return default;
        }

        protected async Task<MrpProduction> SetMoveByproductIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _set_move_byproduct_ids) ---
            */
            return default;
        }

        protected async Task<MrpProduction> SetQtyProducingInternalAsync(object pick_manual_consumption_moves)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _set_qty_producing) ---
            */
            return default;
        }

        protected async Task<MrpProduction> SetQuantitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _set_quantities) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ShouldPostponeDateFinishedInternalAsync(object date_finished)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _should_postpone_date_finished) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: mrp_production.py, METHOD: _should_postpone_date_finished) ---
            */
            return default;
        }

        protected async Task<MrpProduction> ShouldReturnRecordsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _should_return_records) ---
            */
            return default;
        }

        protected async Task<MrpProduction> SplitProductionsInternalAsync(object amounts, object cancel_remaining_qty, object set_consumed_qty)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _split_productions) ---
            */
            return default;
        }

        protected async Task<MrpProduction> TrackGetFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _track_get_fields) ---
            */
            return default;
        }

        protected async Task<MrpProduction> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<MrpProduction> UnlinkExceptDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _unlink_except_done) ---
            */
            return default;
        }

        protected async Task<MrpProduction> UnlinkIfNotDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _unlink_if_not_done) ---
            */
            return default;
        }

        protected async Task<MrpProduction> UpdateCatalogLineQuantityInternalAsync(object line, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _update_catalog_line_quantity) ---
            */
            return default;
        }

        protected async Task<MrpProduction> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }

        protected async Task<MrpProduction> UpdateRawMovesInternalAsync(object factor)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _update_raw_moves) ---
            */
            return default;
        }
    }
}