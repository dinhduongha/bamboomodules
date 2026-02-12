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
    public partial class PurchaseOrderAppService
    {

        protected async Task<PurchaseOrder> ActivityCancelOnSaleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py, METHOD: _activity_cancel_on_sale) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> AddPickingInfoInternalAsync(object activity)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _add_picking_info) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> AddReferenceInternalAsync(object reference)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _add_reference) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> AddSupplierToProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _add_supplier_to_product) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> AmountAllInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _amount_all) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ApplyGridInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py, METHOD: _apply_grid) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ApprovalAllowedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _approval_allowed) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> CheckOrderLineCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _check_order_line_company_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeAccessUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeAmountTotalCcInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_amount_total_cc) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeDateCalendarStartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_date_calendar_start) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeDatePlannedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_date_planned) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeDefaultLocationDestIdIsSubcontractingLocInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: purchase.py, METHOD: _compute_default_location_dest_id_is_subcontracting_loc) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeDestAddressIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: purchase.py, METHOD: _compute_dest_address_id) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _compute_dest_address_id) ---
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py, METHOD: _compute_dest_address_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeDuplicatedOrderIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_duplicated_order_ids) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeEffectiveDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _compute_effective_date) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeIncomingPickingCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _compute_incoming_picking_count) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py, METHOD: _compute_incoming_picking_count) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_invoice) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeIsShippedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _compute_is_shipped) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeMrpProductionCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py, METHOD: _compute_mrp_production_count) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeOnTimeRatePercInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: purchase.py, METHOD: _compute_on_time_rate_perc) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputePickingIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputePurchaseWarningTextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_purchase_warning_text) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeReceiptReminderEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_receipt_reminder_email) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeReceiptStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _compute_receipt_status) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeRepairCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_repair, FILE: purchase_order.py, METHOD: _compute_repair_count) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py, METHOD: _compute_sale_order_count) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeShowComparisonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_show_comparison) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeSubcontractingResupplyPickingCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: purchase_order.py, METHOD: _compute_subcontracting_resupply_picking_count) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeTaxCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_country_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeTaxIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ComputeTaxTotalsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_totals) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> ConfirmationErrorMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _confirmation_error_message) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> CreateActivitySetDetailsInternalAsync(object body)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_order.py, METHOD: _create_activity_set_details) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> CreateDownpaymentsInternalAsync(object line_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _create_downpayments) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> CreatePickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _create_picking) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> CreateUpdateDateActivityInternalAsync(object updated_dates)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _create_update_date_activity) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _create_update_date_activity) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrder> DefaultPickingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _default_picking_type) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> FetchDuplicateOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _fetch_duplicate_orders) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetActionViewPickingInternalAsync(object pickings)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _get_action_view_picking) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetDefaultCreateSectionValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_default_create_section_values) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetDestinationLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: purchase.py, METHOD: _get_destination_location) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _get_destination_location) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetDomainIsLateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_domain_is_late) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _get_domain_is_late) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetEdiBuildersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_edi_builders) ---
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_order.py, METHOD: _get_edi_builders) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetEdiDecoderInternalAsync(object file_data, object @new)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_order.py, METHOD: _get_edi_decoder) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetFinalLocationRecordInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _get_final_location_record) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetImportFileTypeInternalAsync(object file_data)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_order.py, METHOD: _get_import_file_type) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_invoiced) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrder> GetLineValsListInternalAsync(object lines_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_order.py, METHOD: _get_line_vals_list) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetMatrixInternalAsync(object product_template)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py, METHOD: _get_matrix) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetMrpProductionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: purchase_order.py, METHOD: _get_mrp_productions) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py, METHOD: _get_mrp_productions) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrder> GetOrdersToRemindInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_orders_to_remind) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _get_orders_to_remind) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetParentFieldOnChildModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_parent_field_on_child_model) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrder> GetPickingTypeInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _get_picking_type) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetProductCatalogDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_domain) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetProductCatalogOrderLineInfoInternalAsync(List<Guid> product_ids, object child_field)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _get_product_catalog_order_line_info) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetProductPriceAndDataInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_price_and_data) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _get_product_price_and_data) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetReportBaseFilenameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_report_base_filename) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetSaleOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py, METHOD: _get_sale_orders) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py, METHOD: _get_sale_orders) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> GetSubcontractingResuppliesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: purchase_order.py, METHOD: _get_subcontracting_resupplies) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> IsDisplayStockInCatalogInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _is_display_stock_in_catalog) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> IsDropshippedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py, METHOD: _is_dropshipped) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> IsReadonlyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _is_readonly) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> LogDecreaseOrderedQuantityInternalAsync(object purchase_order_lines_quantities)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _log_decrease_ordered_quantity) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> MergeAlternativePoInternalAsync(object rfqs)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _merge_alternative_po) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: _merge_alternative_po) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> MustDeleteDatePlannedInternalAsync(object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _must_delete_date_planned) ---
            --- METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py, METHOD: _must_delete_date_planned) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> OnchangeRequisitionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: _onchange_requisition_id) ---
            --- METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: purchase.py, METHOD: _onchange_requisition_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareDownPaymentSectionValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_down_payment_section_values) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareGroupedDataInternalAsync(object rfq)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_grouped_data) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: _prepare_grouped_data) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _prepare_grouped_data) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_invoice) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _prepare_invoice) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> PreparePickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_purchase_stock, FILE: purchase_order.py, METHOD: _prepare_picking) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _prepare_picking) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareReferenceValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _prepare_reference_vals) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py, METHOD: _prepare_reference_vals) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> PrepareSupplierInfoInternalAsync(object partner, object line, object price, object currency)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_supplier_info) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> RemoveReferenceInternalAsync(object reference)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _remove_reference) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> SearchIsLateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _search_is_late) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> SendReminderMailInternalAsync(object send_single)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _send_reminder_mail) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> SendReminderOpenComposerInternalAsync(Guid template_id)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _send_reminder_open_composer) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> SetGridUpInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py, METHOD: _set_grid_up) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> UnlinkIfCancelledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _unlink_if_cancelled) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> UpdateDatePlannedForLinesInternalAsync(object updated_dates)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_date_planned_for_lines) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }

        protected async Task<PurchaseOrder> UpdateUpdateDateActivityInternalAsync(object updated_dates, object activity)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_update_date_activity) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: _update_update_date_activity) ---
            */
            return default;
        }
    }
}