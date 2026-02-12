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
    public partial class SaleOrderAppService
    {

        protected async Task<SaleOrder> ActionCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _action_cancel) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ActionConfirmInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _action_confirm) ---
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: _action_confirm) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _action_confirm) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _action_confirm) ---
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py, METHOD: _action_confirm) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _action_confirm) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: sale_order.py, METHOD: _action_confirm) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ActivityCancelOnPurchaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py, METHOD: _activity_cancel_on_purchase) ---
            */
            return default;
        }

        protected async Task<SaleOrder> AddBaseLinesForEarlyPaymentDiscountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _add_base_lines_for_early_payment_discount) ---
            */
            return default;
        }

        protected async Task<SaleOrder> AddLoyaltyHistoryLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _add_loyalty_history_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> AddPartnershipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: sale_order.py, METHOD: _add_partnership) ---
            */
            return default;
        }

        protected async Task<SaleOrder> AddPointsForCouponInternalAsync(object coupon_points)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _add_points_for_coupon) ---
            */
            return default;
        }

        protected async Task<SaleOrder> AddReferenceInternalAsync(object reference)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _add_reference) ---
            */
            return default;
        }

        protected async Task<SaleOrder> AllProductAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _all_product_available) ---
            */
            return default;
        }

        protected async Task<SaleOrder> AllowNominativeProgramsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _allow_nominative_programs) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _allow_nominative_programs) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ApplyGridInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_product_matrix, FILE: sale_order.py, METHOD: _apply_grid) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ApplyProgramRewardInternalAsync(object reward, object coupon)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _apply_program_reward) ---
            */
            return default;
        }

        protected async Task<SaleOrder> AutoApplyRewardsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _auto_apply_rewards) ---
            */
            return default;
        }

        protected async Task<SaleOrder> BestGlobalDiscountAlreadyAppliedInternalAsync(object current_reward, object new_reward, object discountable)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _best_global_discount_already_applied) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CanBeEditedOnPortalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _can_be_edited_on_portal) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CartAccessoriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _cart_accessories) ---
            */
            return default;
        }

        protected async Task<Dictionary<string, object>> CartAddInternalAsync(Guid product_id, float quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _cart_add) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CartFindProductLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth_sale, FILE: sale_order.py, METHOD: _cart_find_product_line) ---
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py, METHOD: _cart_find_product_line) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _cart_find_product_line) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _cart_find_product_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CartRecoveryEmailSendInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _cart_recovery_email_send) ---
            */
            return default;
        }

        protected async Task<Dictionary<string, object>> CartUpdateLineQuantityInternalAsync(Guid line_id, float quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _cart_update_line_quantity) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CartUpdateOrderLineInternalAsync(object order_line, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py, METHOD: _cart_update_order_line) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _cart_update_order_line) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _cart_update_order_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CheapestLineInternalAsync(object reward)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _cheapest_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CheckCartIsReadyToBePaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _check_cart_is_ready_to_be_paid) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _check_cart_is_ready_to_be_paid) ---
            --- METHOD SOURCE (MODULE: website_sale_mondialrelay, FILE: sale_order.py, METHOD: _check_cart_is_ready_to_be_paid) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _check_cart_is_ready_to_be_paid) ---
            */
            return default;
        }

        protected async Task<bool> CheckComboQuantitiesInternalAsync(object line)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _check_combo_quantities) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CheckOrderLineCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _check_order_line_company_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CheckPrepaymentPercentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _check_prepayment_percent) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CheckWarehouseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _check_warehouse) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAbandonedCartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _compute_abandoned_cart) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAccessUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountDeliveryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _compute_amount_delivery) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _compute_amount_invoiced) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_invoiced) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountPaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_paid) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountToInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _compute_amount_to_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_to_invoice) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountTotalWithoutDeliveryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _compute_amount_total_without_delivery) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py, METHOD: _compute_amount_total_without_delivery) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountUndiscountedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_undiscounted) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountUnpaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _compute_amount_unpaid) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAmountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amounts) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAttendeeCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py, METHOD: _compute_attendee_count) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAuthorizedTransactionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_authorized_transaction_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeAvailableQuotationDocumentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py, METHOD: _compute_available_quotation_document_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeCartInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _compute_cart_info) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _compute_cart_info) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeCompletedTaskPercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _compute_completed_task_percentage) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeDeliveryStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _compute_delivery_state) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeDeliveryStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _compute_delivery_status) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeDuplicatedOrderIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_duplicated_order_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeEffectiveDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _compute_effective_date) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeEventBoothCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order.py, METHOD: _compute_event_booth_count) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeExpectedDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_expected_date) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _compute_expected_date) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeExpenseCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: sale_order.py, METHOD: _compute_expense_count) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeFieldValueInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_field_value) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: _compute_field_value) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeFiscalPositionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_fiscal_position_id) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeGiftCardCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _compute_gift_card_count) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeHasActivePricelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_has_active_pricelist) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeHasArchivedProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_has_archived_products) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeInvoiceStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_invoice_status) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeIsExpiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_is_expired) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeIsPdfQuoteBuilderAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py, METHOD: _compute_is_pdf_quote_builder_available) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeIsProductMilestoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _compute_is_product_milestone) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeIsServiceProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _compute_is_service_products) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_journal_id) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeJsonPopoverInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _compute_json_popover) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeLateAvailabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _compute_late_availability) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeLoyaltyDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _compute_loyalty_data) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeMarginInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_margin, FILE: sale_order.py, METHOD: _compute_margin) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeMilestoneCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _compute_milestone_count) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeMrpProductionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order.py, METHOD: _compute_mrp_production_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeNoteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_note) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _compute_note) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePartnerCreditWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_credit_warning) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePartnerInvoiceIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_invoice_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePartnerShippingIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _compute_partner_shipping_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_shipping_id) ---
            --- METHOD SOURCE (MODULE: website_sale_mondialrelay, FILE: sale_order.py, METHOD: _compute_partner_shipping_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePartnershipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: sale_order.py, METHOD: _compute_partnership) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePaymentTermIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_payment_term_id) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _compute_payment_term_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePickingIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _compute_picking_ids) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePreferredPaymentMethodLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_preferred_payment_method_line_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePrepaymentPercentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_prepayment_percent) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _compute_prepayment_percent) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePricelistIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_pricelist_id) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _compute_pricelist_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeProjectIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _compute_project_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputePurchaseOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py, METHOD: _compute_purchase_order_count) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: sale_order.py, METHOD: _compute_purchase_order_count) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeRepairCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: _compute_repair_count) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeRequirePaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_require_payment) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _compute_require_payment) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeRequireSignatureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_require_signature) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _compute_require_signature) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _compute_require_signature) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeRewardTotalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _compute_reward_total) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeSaleOrderTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _compute_sale_order_template_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeSaleWarningTextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_sale_warning_text) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeShippingWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _compute_shipping_weight) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeShowHoursRecordedButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: _compute_show_hours_recorded_button) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeShowProjectAndTaskButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _compute_show_project_and_task_button) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTasksIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _compute_tasks_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTaxCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_tax_country_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTaxTotalsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_tax_totals) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTeamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTimesheetCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: _compute_timesheet_count) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTimesheetTotalDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: _compute_timesheet_total_duration) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeTypeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_type_name) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeUserIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_user_id) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeValidityDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_validity_date) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _compute_validity_date) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeVisibleProjectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _compute_visible_project) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _compute_warehouse_id) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _compute_warehouse_id) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _compute_warehouse_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ComputeWebsiteOrderLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _compute_website_order_line) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _compute_website_order_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ConfirmOrderOnGelatoInternalAsync(Guid gelato_order_id)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py, METHOD: _confirm_order_on_gelato) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ConfirmationErrorMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _confirmation_error_message) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ConstraintUniqueAssignedGradeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: sale_order.py, METHOD: _constraint_unique_assigned_grade) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CountPosOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _count_pos_order) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CreateAccountInvoicesInternalAsync(object invoice_vals_list, object final)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_account_invoices) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CreateActivitySetDetailsInternalAsync(object body)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py, METHOD: _create_activity_set_details) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CreateDeliveryLineInternalAsync(object carrier, object price_unit)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _create_delivery_line) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: sale_order.py, METHOD: _create_delivery_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CreateDownPaymentLinesFromBaseLinesInternalAsync(object down_payment_base_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_down_payment_lines_from_base_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CreateDownPaymentSectionLineIfNeededInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_down_payment_section_line_if_needed) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CreateInvoicesInternalAsync(object grouped, object final, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_invoices) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: _create_invoices) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CreateNewCartLineInternalAsync(Guid product_id, object quantity, Guid uom_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _create_new_cart_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CreateOrderOnGelatoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py, METHOD: _create_order_on_gelato) ---
            */
            return default;
        }

        protected async Task<SaleOrder> CreateUpsellActivityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_upsell_activity) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> CronSendPendingEmailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _cron_send_pending_emails) ---
            */
            return default;
        }

        protected async Task<SaleOrder> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        protected async Task<SaleOrder> DefaultQuotationDocumentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py, METHOD: _default_quotation_document_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> DefaultTeamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _default_team_id) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _default_team_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> DeleteOrderOnGelatoInternalAsync(Guid gelato_order_id)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py, METHOD: _delete_order_on_gelato) ---
            */
            return default;
        }

        protected async Task<SaleOrder> DiscardTrackingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _discard_tracking) ---
            */
            return default;
        }

        protected async Task<SaleOrder> DiscountableAmountInternalAsync(object rewards_to_ignore)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _discountable_amount) ---
            */
            return default;
        }

        protected async Task<SaleOrder> DiscountableCheapestInternalAsync(object reward)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _discountable_cheapest) ---
            */
            return default;
        }

        protected async Task<SaleOrder> DiscountableOrderInternalAsync(object reward)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _discountable_order) ---
            */
            return default;
        }

        protected async Task<SaleOrder> DiscountableSpecificInternalAsync(object reward)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _discountable_specific) ---
            */
            return default;
        }

        protected async Task<SaleOrder> EnsurePartnerAddressIsCompleteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py, METHOD: _ensure_partner_address_is_complete) ---
            */
            return default;
        }

        protected async Task<SaleOrder> FetchDuplicateOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _fetch_duplicate_orders) ---
            */
            return default;
        }

        protected async Task<SaleOrder> FilterCanSendAbandonedCartMailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py, METHOD: _filter_can_send_abandoned_cart_mail) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _filter_can_send_abandoned_cart_mail) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _filter_can_send_abandoned_cart_mail) ---
            */
            return default;
        }

        protected async Task<SaleOrder> FilterProductDocumentsInternalAsync(object documents)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _filter_product_documents) ---
            */
            return default;
        }

        protected async Task<SaleOrder> FindMailTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _find_mail_template) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ForceLinesToInvoicePolicyOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _force_lines_to_invoice_policy_order) ---
            */
            return default;
        }

        protected async Task<SaleOrder> FormatCurrencyAmountInternalAsync(object amount)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: sale_order.py, METHOD: _format_currency_amount) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GcAbandonedCouponsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _gc_abandoned_coupons) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GelatoPrepareItemsPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py, METHOD: _gelato_prepare_items_payload) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GenerateDownpaymentInvoicesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _generate_downpayment_invoices) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetActionViewPickingInternalAsync(object pickings)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _get_action_view_picking) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetAmountTotalExcludingDeliveryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _get_amount_total_excluding_delivery) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetApplicableProgramPointsInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_applicable_program_points) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetAppliedGlobalDiscountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_applied_global_discount) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetAppliedGlobalDiscountLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_applied_global_discount_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetAppliedProgramsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_applied_programs) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetCartAndFreeQtyInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _get_cart_and_free_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetCartQtyInternalAsync(Guid product_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _get_cart_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetCartRecoveryTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _get_cart_recovery_template) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetClaimableAndShowableRewardsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _get_claimable_and_showable_rewards) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetClaimableRewardsInternalAsync(object forced_coupons)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_claimable_rewards) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py, METHOD: _get_claimable_rewards) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetCommonProductLinesInternalAsync(Guid product_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _get_common_product_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetConfirmationTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_confirmation_template) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _get_confirmation_template) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _get_confirmation_template) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetConfirmedTxCreateDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_confirmed_tx_create_date) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetCopiableOrderLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_copiable_order_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetDefaultPaymentLinkValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_default_payment_link_values) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetDeliveryMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _get_delivery_methods) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetDiscountAmountInternalAsync(object reward, object discountable)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_discount_amount) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetEdiBuildersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_edi_builders) ---
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py, METHOD: _get_edi_builders) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetEdiDecoderInternalAsync(object file_data, object @new)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py, METHOD: _get_edi_decoder) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetEstimatedWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _get_estimated_weight) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetFreeQtyInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _get_free_qty) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetFreeShippingLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _get_free_shipping_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetImportFileTypeInternalAsync(object file_data)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py, METHOD: _get_import_file_type) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetInsufficientStockDataInternalAsync(Guid wh_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _get_insufficient_stock_data) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetInvoiceGroupingKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoice_grouping_keys) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetInvoiceableLinesInternalAsync(object final)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoiceable_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoiced) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetLangInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_lang) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _get_lang) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> GetLineValsListInternalAsync(object lines_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_order.py, METHOD: _get_line_vals_list) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetMatrixInternalAsync(object product_template)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_product_matrix, FILE: sale_order.py, METHOD: _get_matrix) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetNamePortalContentViewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_name_portal_content_view) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetNameTaxTotalsViewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_name_tax_totals_view) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetNoEffectOnThresholdLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_no_effect_on_threshold_lines) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py, METHOD: _get_no_effect_on_threshold_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetNonDeliveryLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _get_non_delivery_lines) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _get_non_delivery_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetNotRewardedOrderLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_not_rewarded_order_lines) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py, METHOD: _get_not_rewarded_order_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> GetNoteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_note_url) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _get_note_url) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetOrderLinePriceInternalAsync(object order_line, object price_type)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_order_line_price) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetOrderLinesToReportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_order_lines_to_report) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetOrderWithValidServiceProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: _get_order_with_valid_service_product) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetParentFieldOnChildModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_parent_field_on_child_model) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetPickupLocationsInternalAsync(object zip_code, object country)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _get_pickup_locations) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _get_pickup_locations) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetPointChangesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_point_changes) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetPointsProgramsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_points_programs) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetPortalReturnActionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_portal_return_action) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetPreferredDeliveryMethodInternalAsync(object available_delivery_methods)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _get_preferred_delivery_method) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetPrepaidServiceLinesToUpsellInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: _get_prepaid_service_lines_to_upsell) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetPrepaymentRequiredAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_prepayment_required_amount) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetPricedLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_priced_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetProductCatalogDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_domain) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetProductDocumentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_documents) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetProgramDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_program_domain) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _get_program_domain) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetProgramTimezoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_program_timezone) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _get_program_timezone) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetPurchaseOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py, METHOD: _get_purchase_orders) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: sale_order.py, METHOD: _get_purchase_orders) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetRealPointsForCouponInternalAsync(object coupon, object post_confirm)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_real_points_for_coupon) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetReportBaseFilenameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_report_base_filename) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardCouponsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_reward_coupons) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardLineValuesInternalAsync(object reward, object coupon)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_reward_line_values) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py, METHOD: _get_reward_line_values) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardProgramsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_reward_programs) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardValuesDiscountInternalAsync(object reward, object coupon)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_reward_values_discount) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardValuesFreeShippingInternalAsync(object reward, object coupon)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: sale_order.py, METHOD: _get_reward_values_free_shipping) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetRewardValuesProductInternalAsync(object reward, object coupon, object product)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_reward_values_product) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetShopWarehouseIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _get_shop_warehouse_id) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _get_shop_warehouse_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetShopWarningInternalAsync(object clear)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _get_shop_warning) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetSpecificDiscountableLinesInternalAsync(object reward)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_specific_discountable_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetTriggerDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _get_trigger_domain) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _get_trigger_domain) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetUnavailableQuantityFromKitsInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_mrp, FILE: sale_order.py, METHOD: _get_unavailable_quantity_from_kits) ---
            */
            return default;
        }

        protected async Task<SaleOrder> GetUpdatePricesLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _get_update_prices_lines) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_update_prices_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> HasDeliverableProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _has_deliverable_products) ---
            */
            return default;
        }

        protected async Task<SaleOrder> HasToBePaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _has_to_be_paid) ---
            */
            return default;
        }

        protected async Task<SaleOrder> HasToBeSignedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _has_to_be_signed) ---
            */
            return default;
        }

        protected async Task<SaleOrder> InitColumnInternalAsync(object column_name)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _init_column) ---
            */
            return default;
        }

        protected async Task<SaleOrder> IsAnonymousCartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _is_anonymous_cart) ---
            */
            return default;
        }

        protected async Task<SaleOrder> IsCartReadyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _is_cart_ready) ---
            */
            return default;
        }

        protected async Task<SaleOrder> IsConfirmationAmountReachedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_confirmation_amount_reached) ---
            */
            return default;
        }

        protected async Task<SaleOrder> IsDisplayStockInCatalogInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _is_display_stock_in_catalog) ---
            */
            return default;
        }

        protected async Task<SaleOrder> IsInStockInternalAsync(Guid wh_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _is_in_stock) ---
            */
            return default;
        }

        protected async Task<SaleOrder> IsPaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_paid) ---
            */
            return default;
        }

        protected async Task<SaleOrder> IsReadonlyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_readonly) ---
            */
            return default;
        }

        protected async Task<SaleOrder> IsReorderAllowedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _is_reorder_allowed) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<SaleOrder> LogDecreaseOrderedQuantityInternalAsync(object documents, object cancel)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _log_decrease_ordered_quantity) ---
            */
            return default;
        }

        protected async Task<SaleOrder> MailingGetDefaultDomainInternalAsync(object mailing)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sale, FILE: sale_order.py, METHOD: _mailing_get_default_domain) ---
            */
            return default;
        }

        protected async Task<SaleOrder> MessageMailAfterHookInternalAsync(object mails)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _message_mail_after_hook) ---
            */
            return default;
        }

        protected async Task<SaleOrder> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        protected async Task<SaleOrder> NeedsCustomerAddressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _needs_customer_address) ---
            */
            return default;
        }

        protected async Task<SaleOrder> NothingToInvoiceErrorMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _nothing_to_invoice_error_message) ---
            */
            return default;
        }

        protected async Task<SaleOrder> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        protected async Task<SaleOrder> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeCommitmentDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_commitment_date) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_company_id) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeCompanyIdWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_company_id_warning) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeFposIdShowUpdateFposInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_fpos_id_show_update_fpos) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeOrderLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_order_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangePartnerShippingIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _onchange_partner_shipping_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangePrepaymentPercentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_prepayment_percent) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangePricelistIdShowUpdatePricesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_pricelist_id_show_update_prices) ---
            */
            return default;
        }

        protected async Task<SaleOrder> OnchangeSaleOrderTemplateIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: _onchange_sale_order_template_id) ---
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py, METHOD: _onchange_sale_order_template_id) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PhoneGetNumberFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareAnalyticAccountDataInternalAsync(object prefix)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_analytic_account_data) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareConfirmationValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_confirmation_values) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareDeliveryLineValsInternalAsync(object carrier, object price_unit)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _prepare_delivery_line_vals) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareDownPaymentLineSectionValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_line_section_values) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareDownPaymentLineValuesFromBaseLineInternalAsync(object base_line)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: _prepare_down_payment_line_values_from_base_line) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_line_values_from_base_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareDownPaymentSectionLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_section_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareInStoreDefaultLocationDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _prepare_in_store_default_location_data) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_invoice) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _prepare_invoice) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareOrderLineUpdateValuesInternalAsync(object order_line, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth_sale, FILE: sale_order.py, METHOD: _prepare_order_line_update_values) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _prepare_order_line_update_values) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PrepareOrderLineValuesInternalAsync(Guid product_id, object quantity, Guid uom_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth_sale, FILE: sale_order.py, METHOD: _prepare_order_line_values) ---
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py, METHOD: _prepare_order_line_values) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _prepare_order_line_values) ---
            */
            return default;
        }

        protected async Task<SaleOrder> PreventMixingGelatoAndNonGelatoProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py, METHOD: _prevent_mixing_gelato_and_non_gelato_products) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ProgramCheckComputePointsInternalAsync(object programs)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _program_check_compute_points) ---
            */
            return default;
        }

        protected async Task<SaleOrder> RecNamesSearchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _rec_names_search) ---
            */
            return default;
        }

        protected async Task<SaleOrder> RecomputeCartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _recompute_cart) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _recompute_cart) ---
            */
            return default;
        }

        protected async Task<SaleOrder> RecomputePricesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _recompute_prices) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _recompute_prices) ---
            */
            return default;
        }

        protected async Task<SaleOrder> RecomputeTaxesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _recompute_taxes) ---
            */
            return default;
        }

        protected async Task<SaleOrder> RemoveDeliveryLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _remove_delivery_line) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _remove_delivery_line) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _remove_delivery_line) ---
            */
            return default;
        }

        protected async Task<SaleOrder> RemoveProgramFromPointsInternalAsync(object programs)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _remove_program_from_points) ---
            */
            return default;
        }

        protected async Task<SaleOrder> RemoveReferenceInternalAsync(object reference)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _remove_reference) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ResetHasDisplayedWarningUpsellOrderLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: _reset_has_displayed_warning_upsell_order_lines) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SearchAbandonedCartInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _search_abandoned_cart) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: sale_order.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SearchInvoiceIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _search_invoice_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SearchLateAvailabilityInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _search_late_availability) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SaleOrder> SearchTasksIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _search_tasks_ids) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SelectExpectedDateInternalAsync(object expected_dates)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _select_expected_date) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: _select_expected_date) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SendOrderConfirmationMailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_order_confirmation_mail) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SendOrderNotificationMailInternalAsync(object mail_template, object allow_deferred_sending)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_order_notification_mail) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SendPaymentSucceededForOrderMailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_payment_succeeded_for_order_mail) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _send_payment_succeeded_for_order_mail) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SendRewardCouponMailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _send_reward_coupon_mail) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SetDeliveryMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _set_delivery_method) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _set_delivery_method) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _set_delivery_method) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SetGridUpInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_product_matrix, FILE: sale_order.py, METHOD: _set_grid_up) ---
            */
            return default;
        }

        protected async Task<SaleOrder> SetPickupLocationInternalAsync(object pickup_location_data)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _set_pickup_location) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _set_pickup_location) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ShouldBeLockedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _should_be_locked) ---
            */
            return default;
        }

        protected async Task<SaleOrder> TasksIdsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: _tasks_ids_domain) ---
            */
            return default;
        }

        protected async Task<SaleOrder> TrackFinalizeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _track_finalize) ---
            */
            return default;
        }

        protected async Task<SaleOrder> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<SaleOrder> TryApplyCodeInternalAsync(object code)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _try_apply_code) ---
            */
            return default;
        }

        protected async Task<SaleOrder> TryApplyProgramInternalAsync(object program, object coupon)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _try_apply_program) ---
            */
            return default;
        }

        protected async Task<SaleOrder> TryPendingCouponInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _try_pending_coupon) ---
            */
            return default;
        }

        protected async Task<SaleOrder> UnlinkExceptDraftOrCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _unlink_except_draft_or_cancel) ---
            */
            return default;
        }

        protected async Task<SaleOrder> UpdateAddressInternalAsync(Guid partner_id, object fnames)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _update_address) ---
            */
            return default;
        }

        protected async Task<SaleOrder> UpdateLoyaltyHistoryInternalAsync(Guid coupon_id, object points)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _update_loyalty_history) ---
            */
            return default;
        }

        protected async Task<SaleOrder> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }

        protected async Task<SaleOrder> UpdateProgramsAndRewardsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _update_programs_and_rewards) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _update_programs_and_rewards) ---
            */
            return default;
        }

        protected async Task<SaleOrder> ValidateOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _validate_order) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _validate_order) ---
            */
            return default;
        }

        protected async Task<SaleOrder> VerifyCartAfterUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _verify_cart_after_update) ---
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: _verify_cart_after_update) ---
            */
            return default;
        }

        protected async Task<SaleOrder> VerifyCartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _verify_cart) ---
            */
            return default;
        }

        protected async Task<SaleOrder> VerifyUpdatedQuantityInternalAsync(object order_line, Guid product_id, object new_qty, Guid uom_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth_sale, FILE: sale_order.py, METHOD: _verify_updated_quantity) ---
            --- METHOD SOURCE (MODULE: website_event_sale, FILE: sale_order.py, METHOD: _verify_updated_quantity) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: _verify_updated_quantity) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: sale_order.py, METHOD: _verify_updated_quantity) ---
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: sale_order.py, METHOD: _verify_updated_quantity) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: sale_order.py, METHOD: _verify_updated_quantity) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: sale_order.py, METHOD: _verify_updated_quantity) ---
            */
            return default;
        }

        protected async Task<SaleOrder> WriteValsFromRewardValsInternalAsync(object reward_vals, object old_lines, object delete)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: _write_vals_from_reward_vals) ---
            */
            return default;
        }

        private async Task<SaleOrder> _TryApplyProgramInternalAsync(object program, object coupon, object status)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: __try_apply_program) ---
            */
            return default;
        }
    }
}