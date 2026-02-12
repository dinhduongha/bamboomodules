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
    public partial class SaleOrderLineAppService
    {

        protected async Task<SaleOrderLine> ActionLaunchStockRuleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: _action_launch_stock_rule) ---
            --- METHOD SOURCE (MODULE: sale_gelato_stock, FILE: sale_order_line.py, METHOD: _action_launch_stock_rule) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _action_launch_stock_rule) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> AddPrecomputedValuesInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _add_precomputed_values) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> AdditionalNamePerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _additional_name_per_id) ---
            --- METHOD SOURCE (MODULE: sale_service, FILE: sale_order_line.py, METHOD: _additional_name_per_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> AutoInitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_service, FILE: sale_order_line.py, METHOD: _auto_init) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CanBeEditedOnPortalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _can_be_edited_on_portal) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: _can_be_edited_on_portal) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_line.py, METHOD: _can_be_edited_on_portal) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CanBeInvoicedAloneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order_line.py, METHOD: _can_be_invoiced_alone) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _can_be_invoiced_alone) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: _can_be_invoiced_alone) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CancelRepairOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: _cancel_repair_order) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CheckAvailabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order_line.py, METHOD: _check_availability) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CheckComboItemIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _check_combo_item_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CheckEventBoothRegistrationIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _check_event_booth_registration_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CheckEventRegistrationTicketInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _check_event_registration_ticket) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CheckLineUnlinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order_line.py, METHOD: _check_line_unlink) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _check_line_unlink) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CheckValidityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _check_validity) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_amount) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeAmountInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_amount_invoiced) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeAmountToInvoiceAtDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_amount_to_invoice_at_date) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeAmountToInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_amount_to_invoice) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _compute_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeAvailableProductDocumentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order_line.py, METHOD: _compute_available_product_document_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeCustomAttributeValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_custom_attribute_values) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeCustomerLeadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_customer_lead) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _compute_customer_lead) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeDiscountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_discount) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeEventBoothPendingIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _compute_event_booth_pending_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeEventIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _compute_event_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeEventRelatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _compute_event_related) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeInvoiceStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_invoice_status) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _compute_invoice_status) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeIsMtoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _compute_is_mto) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py, METHOD: _compute_is_mto) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeIsProductArchivedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_is_product_archived) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeIsRepairLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_repair, FILE: sale_order_line.py, METHOD: _compute_is_repair_line) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeIsRewardLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: _compute_is_reward_line) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeIsServiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_service, FILE: sale_order_line.py, METHOD: _compute_is_service) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeMarginInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_margin, FILE: sale_order_line.py, METHOD: _compute_margin) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_line.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeNameShortInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth_sale, FILE: sale_order_line.py, METHOD: _compute_name_short) ---
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order_line.py, METHOD: _compute_name_short) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _compute_name_short) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeNoVariantAttributeValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_no_variant_attribute_values) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_parent_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputePriceReduceTaxexclInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_price_reduce_taxexcl) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputePriceReduceTaxincInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_price_reduce_taxinc) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputePriceUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _compute_price_unit) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_price_unit) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputePricelistItemIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order_line.py, METHOD: _compute_pricelist_item_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_pricelist_item_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order_line.py, METHOD: _compute_product_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeProductTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_template_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeProductUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_uom_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeProductUomQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_uom_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeProductUomReadonlyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _compute_product_uom_readonly) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_uom_readonly) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeProductUpdatableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_updatable) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _compute_product_updatable) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _compute_product_updatable) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py, METHOD: _compute_product_updatable) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputePurchaseCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _compute_purchase_count) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputePurchasePriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense_margin, FILE: sale_order_line.py, METHOD: _compute_purchase_price) ---
            --- METHOD SOURCE (MODULE: sale_margin, FILE: sale_order_line.py, METHOD: _compute_purchase_price) ---
            --- METHOD SOURCE (MODULE: sale_stock_margin, FILE: sale_order_line.py, METHOD: _compute_purchase_price) ---
            --- METHOD SOURCE (MODULE: sale_timesheet_margin, FILE: sale_order_line.py, METHOD: _compute_purchase_price) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeQtyAtDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _compute_qty_at_date) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeQtyDeliveredAtDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_delivered_at_date) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeQtyDeliveredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _compute_qty_delivered) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_delivered) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _compute_qty_delivered) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _compute_qty_delivered) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _compute_qty_delivered) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeQtyDeliveredMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_delivered_method) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _compute_qty_delivered_method) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _compute_qty_delivered_method) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _compute_qty_delivered_method) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeQtyInvoicedAtDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_invoiced_at_date) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeQtyInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _compute_qty_invoiced) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_invoiced) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeQtyInvoicedPostedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_invoiced_posted) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeQtyToDeliverInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order_line.py, METHOD: _compute_qty_to_deliver) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _compute_qty_to_deliver) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeQtyToInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_to_invoice) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeRemainingHoursAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _compute_remaining_hours_available) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeRemainingHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _compute_remaining_hours) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeSaleLineWarnMsgInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_sale_line_warn_msg) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeTaxIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_tax_ids) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: _compute_tax_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeTranslatedProductNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_translated_product_name) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeUntaxedAmountInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _compute_untaxed_amount_invoiced) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_untaxed_amount_invoiced) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeUntaxedAmountToInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_untaxed_amount_to_invoice) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _compute_warehouse_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ConvertQtyCompanyHoursInternalAsync(object dest_company)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _convert_qty_company_hours) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _convert_qty_company_hours) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrderLine> ConvertQtyInternalAsync(object sale_line, object qty, object direction)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _convert_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ConvertToSolCurrencyInternalAsync(object amount, object currency)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _convert_to_sol_currency) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CreateProcurementsInternalAsync(object product_qty, object procurement_uom, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _create_procurements) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CreatePurchaseOrderInternalAsync(object supplierinfo)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _create_purchase_order) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> CreateRepairOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: _create_repair_order) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrderLine> DateInThePastInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _date_in_the_past) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> DomainProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _domain_product_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> DomainSaleLineServiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_service, FILE: sale_order_line.py, METHOD: _domain_sale_line_service) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ExpectedDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _expected_date) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetActionAddFromCatalogExtraContextInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetActionPerItemInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _get_action_per_item) ---
            --- METHOD SOURCE (MODULE: sale_project_stock, FILE: sale_order_line.py, METHOD: _get_action_per_item) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _get_action_per_item) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetAdditionalDomainForPurchaseOrderLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _get_additional_domain_for_purchase_order_line) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetBomComponentQtyInternalAsync(object bom)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order_line.py, METHOD: _get_bom_component_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetCartDisplayPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _get_cart_display_price) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetCombinationNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _get_combination_name) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetComboItemDisplayPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_combo_item_display_price) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetComboTotalsInternalAsync(object totals_field)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_combo_totals) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetCustomComputeTaxCacheKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_custom_compute_tax_cache_key) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetDeliveredQuantityByAnalyticInternalAsync(object additional_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_delivered_quantity_by_analytic) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetDiscountedPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_discounted_price) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetDisplayPriceIgnoreComboInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_display_price_ignore_combo) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetDisplayPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _get_display_price) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _get_display_price) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_display_price) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: _get_display_price) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetDisplayedQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _get_displayed_quantity) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetDisplayedUnitPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _get_displayed_unit_price) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetDownpaymentDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_downpayment_description) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetDownpaymentLinePriceUnitInternalAsync(object invoices)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _get_downpayment_line_price_unit) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_downpayment_line_price_unit) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetDownpaymentStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_downpayment_state) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetGroupedSectionSummaryInternalAsync(object display_taxes)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_grouped_section_summary) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrderLine> GetIncomingOutgoingMovesFilterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order_line.py, METHOD: _get_incoming_outgoing_moves_filter) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetInvalidDeliveryWeightLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order_line.py, METHOD: _get_invalid_delivery_weight_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetInvoiceLineSequenceInternalAsync(object @new, object old)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_invoice_line_sequence) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetInvoiceLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_invoice_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetLineHeaderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _get_line_header) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order_line.py, METHOD: _get_line_header) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetLinesWithPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_lines_with_price) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetLinkedLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_linked_line) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetLinkedLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_linked_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetLocationFinalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _get_location_final) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetMaxAvailableQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order_line.py, METHOD: _get_max_available_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetMaxLineQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order_line.py, METHOD: _get_max_line_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetOrderDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_order_date) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _get_order_date) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetOutgoingIncomingMovesInternalAsync(object strict)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _get_outgoing_incoming_moves) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetPartnerDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_partner_display) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetPricelistKwargsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_pricelist_kwargs) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetPricelistPriceBeforeDiscountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_pricelist_price_before_discount) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetPricelistPriceContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_pricelist_price_context) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetPricelistPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_pricelist_price) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetProductCatalogLinesDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_product_catalog_lines_data) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _get_product_catalog_lines_data) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetProductFromSolNameDomainInternalAsync(object product_name)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _get_product_from_sol_name_domain) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetProductPriceContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrderLine> GetProductServicePolicyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _get_product_service_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _get_product_service_policy) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetProtectedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_protected_fields) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetQtyProcurementInternalAsync(object previous_product_uom_qty)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order_line.py, METHOD: _get_qty_procurement) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _get_qty_procurement) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py, METHOD: _get_qty_procurement) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetSaleOrderFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _get_sale_order_fields) ---
            --- METHOD SOURCE (MODULE: pos_sale_loyalty, FILE: sale_order.py, METHOD: _get_sale_order_fields) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetSaleOrderLineMultilineDescriptionSaleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _get_sale_order_line_multiline_description_sale) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _get_sale_order_line_multiline_description_sale) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_sale_order_line_multiline_description_sale) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetSaleOrderLineMultilineDescriptionVariantsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_sale_order_line_multiline_description_variants) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetSaleOrderPartnerIdInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _get_sale_order_partner_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetSectionLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_section_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetSectionTotalsInternalAsync(object totals_field)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_section_totals) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetSelectedComboItemsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _get_selected_combo_items) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetShopWarningInternalAsync(object clear)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _get_shop_warning) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetSoLinesNewProjectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _get_so_lines_new_project) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> GetSoLinesTaskGlobalProjectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _get_so_lines_task_global_project) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> HandleMilestonesInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _handle_milestones) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> HasTaxesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _has_taxes) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> InitRegistrationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _init_registrations) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> InverseCustomerLeadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _inverse_customer_lead) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> InverseEventBoothPendingIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _inverse_event_booth_pending_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> IsDeliveryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order_line.py, METHOD: _is_delivery) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _is_delivery) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> IsDiscountLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _is_discount_line) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: _is_discount_line) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> IsGlobalDiscountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _is_global_discount) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> IsLineInSectionInternalAsync(object line)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _is_line_in_section) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> IsLineOptionalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_line.py, METHOD: _is_line_optional) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> IsReorderAllowedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order_line.py, METHOD: _is_reorder_allowed) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _is_reorder_allowed) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order_line.py, METHOD: _is_reorder_allowed) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: sale_order_line.py, METHOD: _is_reorder_allowed) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> IsSellableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _is_sellable) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order_line.py, METHOD: _is_sellable) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrderLine> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrderLine> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_repair, FILE: sale_order_line.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> MatchOrCreatePurchaseOrderInternalAsync(object supplierinfo)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _match_or_create_purchase_order) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> OnchangeEventIdBoothInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _onchange_event_id_booth) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> OnchangeProductIdBoothInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _onchange_product_id_booth) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> OnchangeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> OnchangeProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order_line.py, METHOD: _onchange_product) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> OnchangeServiceProductUomQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _onchange_service_product_uom_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PrepareBaseLineForTaxesComputationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PrepareInvoiceLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_invoice_line) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _prepare_invoice_line) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PrepareInvoiceLinesValsListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_invoice_lines_vals_list) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PrepareProcurementValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: sale_order.py, METHOD: _prepare_procurement_values) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PrepareQtyDeliveredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _prepare_qty_delivered) ---
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: _prepare_qty_delivered) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_qty_delivered) ---
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order_line.py, METHOD: _prepare_qty_delivered) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _prepare_qty_delivered) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _prepare_qty_delivered) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _prepare_qty_delivered) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PrepareQtyInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _prepare_qty_invoiced) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_qty_invoiced) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PrepareReferenceValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _prepare_reference_vals) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PrepareTaskTemplateValsInternalAsync(object template, object project)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _prepare_task_template_vals) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseDecreaseOrderedQtyInternalAsync(object new_qty, object origin_values)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_decrease_ordered_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseGetDateOrderInternalAsync(object supplierinfo)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_get_date_order) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseIncreaseOrderedQtyInternalAsync(object new_qty, object origin_values)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_increase_ordered_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseServiceCreateInternalAsync(object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_service_create) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseServiceGenerationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_service_generation) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseServiceGetCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_service_get_company) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseServiceGetPriceUnitAndTaxesInternalAsync(object supplierinfo, object purchase_order)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_service_get_price_unit_and_taxes) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseServiceGetProductNameInternalAsync(object supplierinfo, object purchase_order, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_service_get_product_name) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseServiceMatchPurchaseOrderInternalAsync(object partner, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_service_match_purchase_order) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseServiceMatchSupplierInternalAsync(object warning)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_service_match_supplier) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseServicePrepareLineValuesInternalAsync(object purchase_order, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_service_prepare_line_values) ---
            --- METHOD SOURCE (MODULE: sale_purchase_project, FILE: sale_order_line.py, METHOD: _purchase_service_prepare_line_values) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> PurchaseServicePrepareOrderValuesInternalAsync(object supplierinfo)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _purchase_service_prepare_order_values) ---
            --- METHOD SOURCE (MODULE: sale_purchase_project, FILE: sale_order_line.py, METHOD: _purchase_service_prepare_order_values) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py, METHOD: _purchase_service_prepare_order_values) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ReadQtiesInternalAsync(object date, object wh)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _read_qties) ---
            --- METHOD SOURCE (MODULE: sale_stock_product_expiry, FILE: sale_order_line.py, METHOD: _read_qties) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> RecomputeQtyToInvoiceInternalAsync(object start_date, object end_date)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _recompute_qty_to_invoice) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ResetLoyaltyInternalAsync(object complete)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: _reset_loyalty) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ResetPriceUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _reset_price_unit) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> RetrievePurchasePartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order_line.py, METHOD: _retrieve_purchase_partner) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> SearchEventBoothPendingIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _search_event_booth_pending_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> SearchProductTemplateIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _search_product_template_id) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> SellableLinesDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _sellable_lines_domain) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order_line.py, METHOD: _sellable_lines_domain) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> SetAnalyticDistributionInternalAsync(object inv_line_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _set_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> SetShopWarningStockInternalAsync(object desired_qty, object new_qty, object save)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order_line.py, METHOD: _set_shop_warning_stock) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ShouldShowStrikethroughPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order_line.py, METHOD: _should_show_strikethrough_price) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _should_show_strikethrough_price) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order_line.py, METHOD: _should_show_strikethrough_price) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ShowInCartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order_line.py, METHOD: _show_in_cart) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order_line.py, METHOD: _show_in_cart) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> TimesheetComputeDeliveredQuantityDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _timesheet_compute_delivered_quantity_domain) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> TimesheetCreateProjectAccountValsInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _timesheet_create_project_account_vals) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> TimesheetCreateProjectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _timesheet_create_project) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _timesheet_create_project) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> TimesheetCreateProjectPrepareValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _timesheet_create_project_prepare_values) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order_line.py, METHOD: _timesheet_create_project_prepare_values) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> TimesheetCreateTaskInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _timesheet_create_task) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> TimesheetCreateTaskPrepareValuesInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _timesheet_create_task_prepare_values) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> TimesheetServiceGenerationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order_line.py, METHOD: _timesheet_service_generation) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> UnlinkExceptConfirmedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _unlink_except_confirmed) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> UpdateEventBoothsInternalAsync(object set_paid)
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _update_event_booths) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> UpdateLineQuantityInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _update_line_quantity) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order_line.py, METHOD: _update_line_quantity) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> UseTemplateNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order_line.py, METHOD: _use_template_name) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order_line.py, METHOD: _use_template_name) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order_line.py, METHOD: _use_template_name) ---
            */
            return default;
        }

        protected async Task<SaleOrderLine> ValidateAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _validate_analytic_distribution) ---
            */
            return default;
        }
    }
}