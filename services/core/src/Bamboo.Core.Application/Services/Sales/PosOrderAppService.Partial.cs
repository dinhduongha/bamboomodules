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
    public partial class PosOrderAppService
    {

        protected async Task<PosOrder> AddMailAttachmentInternalAsync(object name, object ticket, object basic_receipt)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py, METHOD: _add_mail_attachment) ---
            */
            return default;
        }

        protected async Task<PosOrder> CheckExistingLoyaltyCardsInternalAsync(object coupon_data)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py, METHOD: _check_existing_loyalty_cards) ---
            */
            return default;
        }

        protected async Task<PosOrder> CheckNextOnlinePaymentAmountInternalAsync(object amount)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py, METHOD: _check_next_online_payment_amount) ---
            */
            return default;
        }

        protected async Task<PosOrder> CleanPaymentLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _clean_payment_lines) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py, METHOD: _clean_payment_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosOrder> CompleteValuesFromSessionInternalAsync(object session, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _complete_values_from_session) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _complete_values_from_session) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeAmountPaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_amount_paid) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeAttendeeCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py, METHOD: _compute_attendee_count) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeCashierInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_order.py, METHOD: _compute_cashier) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeContactDetailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_contact_details) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_currency_rate) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeHasRefundableLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_has_refundable_lines) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeInvoiceStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_invoice_status) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeIsEditedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_edited) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeIsInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_invoiced) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeIsTotalCostComputedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_total_cost_computed) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeMarginInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_margin) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeOnlinePaymentMethodIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py, METHOD: _compute_online_payment_method_id) ---
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py, METHOD: _compute_online_payment_method_id) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeOrderConfigIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_order_config_id) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeOrderNameInternalAsync(object session)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_order_name) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputePickingCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_picking_count) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputePricesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_prices) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeRefundRelatedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_refund_related_fields) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeTotalCostAtSessionClosingInternalAsync(object stock_moves)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_total_cost_at_session_closing) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeTotalCostInRealTimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_total_cost_in_real_time) ---
            */
            return default;
        }

        protected async Task<PosOrder> ComputeUseSelfOrderOnlinePaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py, METHOD: _compute_use_self_order_online_payment) ---
            */
            return default;
        }

        protected async Task<PosOrder> CountSaleOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _count_sale_order) ---
            */
            return default;
        }

        protected async Task<PosOrder> CreateInvoiceInternalAsync(object move_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_invoice) ---
            */
            return default;
        }

        protected async Task<PosOrder> CreateMiscReversalMoveInternalAsync(object payment_moves)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_misc_reversal_move) ---
            */
            return default;
        }

        protected async Task<PosOrder> CreateOrderPickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_order_picking) ---
            */
            return default;
        }

        protected async Task<PosOrder> CreatePmChangeLogInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_pm_change_log) ---
            */
            return default;
        }

        protected async Task<PosOrder> EnsureToKeepLastPreparationChangeInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _ensure_to_keep_last_preparation_change) ---
            */
            return default;
        }

        protected async Task<PosOrder> GeneratePosOrderInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _generate_pos_order_invoice) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetCheckedNextOnlinePaymentAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py, METHOD: _get_checked_next_online_payment_amount) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetFieldsForOrderLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py, METHOD: _get_fields_for_order_line) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _get_fields_for_order_line) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetInvoiceLinesValuesInternalAsync(object line_values, object pos_line, object move_type)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_invoice_lines_values) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _get_invoice_lines_values) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetInvoicePostContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_invoice_post_context) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetMailAttachmentsInternalAsync(object name, object ticket, object basic_ticket)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_mail_attachments) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetOpenOrderInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_open_order) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_order.py, METHOD: _get_open_order) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetOrderLogRepresentationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_order_log_representation) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetPartnerBankIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_partner_bank_id) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetPosAngloSaxonPriceUnitInternalAsync(object product, Guid partner_id, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_pos_anglo_saxon_price_unit) ---
            --- METHOD SOURCE (MODULE: pos_mrp, FILE: pos_order.py, METHOD: _get_pos_anglo_saxon_price_unit) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosOrder> GetRefundedOrdersInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_refunded_orders) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetRoundedAmountInternalAsync(object amount, object force_round)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_rounded_amount) ---
            */
            return default;
        }

        protected async Task<PosOrder> GetValidSessionInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_valid_session) ---
            */
            return default;
        }

        protected async Task<PosOrder> IsPosOrderPaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _is_pos_order_paid) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosOrder> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosOrder> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        protected async Task<PosOrder> LoadPosSelfDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py, METHOD: _load_pos_self_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: _load_pos_self_data_fields) ---
            */
            return default;
        }

        protected async Task<PosOrder> MarkupListMessageInternalAsync(object message)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _markup_list_message) ---
            */
            return default;
        }

        protected async Task<PosOrder> OnchangeAmountAllInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_amount_all) ---
            */
            return default;
        }

        protected async Task<PosOrder> OnchangePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        protected async Task<PosOrder> PrepareAmlValuesListPerNatureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_aml_values_list_per_nature) ---
            */
            return default;
        }

        protected async Task<PosOrder> PrepareInvoiceLinesInternalAsync(object move_type)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_invoice_lines) ---
            */
            return default;
        }

        protected async Task<PosOrder> PrepareInvoiceValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_invoice_vals) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _prepare_invoice_vals) ---
            */
            return default;
        }

        protected async Task<PosOrder> PrepareMailValuesInternalAsync(object email, object ticket, object basic_ticket)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_mail_values) ---
            */
            return default;
        }

        protected async Task<PosOrder> PrepareOrderLineInternalAsync(object order_line)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _prepare_order_line) ---
            */
            return default;
        }

        protected async Task<PosOrder> PreparePosLogInternalAsync(object body)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_pos_log) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_order.py, METHOD: _prepare_pos_log) ---
            */
            return default;
        }

        protected async Task<PosOrder> PrepareProductAmlDictInternalAsync(object base_line_vals, object update_base_line_vals, object rate, object sign)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_product_aml_dict) ---
            */
            return default;
        }

        protected async Task<PosOrder> PrepareRefundValuesInternalAsync(object current_session)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_refund_values) ---
            */
            return default;
        }

        protected async Task<PosOrder> PrepareTaxBaseLineValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_tax_base_line_values) ---
            */
            return default;
        }

        protected async Task<PosOrder> ProcessExistingGiftCardsInternalAsync(object coupon_data)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py, METHOD: _process_existing_gift_cards) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosOrder> ProcessOrderInternalAsync(object order, object existing_order)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_order) ---
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py, METHOD: _process_order) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py, METHOD: _process_order) ---
            */
            return default;
        }

        protected async Task<PosOrder> ProcessPaymentLinesInternalAsync(object pos_order, object order, object pos_session, object draft)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_payment_lines) ---
            */
            return default;
        }

        protected async Task<PosOrder> ProcessSavedOrderInternalAsync(object draft)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_saved_order) ---
            */
            return default;
        }

        protected async Task<PosOrder> ReconcileInvoicePaymentsInternalAsync(object invoice, object payment_moves)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _reconcile_invoice_payments) ---
            */
            return default;
        }

        protected async Task<PosOrder> RefundInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _refund) ---
            */
            return default;
        }

        protected async Task<PosOrder> RemoveDuplicateCouponDataInternalAsync(object coupon_data)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py, METHOD: _remove_duplicate_coupon_data) ---
            */
            return default;
        }

        protected async Task<PosOrder> SendNotificationInternalAsync(List<Guid> order_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: _send_notification) ---
            */
            return default;
        }

        protected async Task<PosOrder> SendNotificationOnlinePaymentStatusInternalAsync(object status)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py, METHOD: _send_notification_online_payment_status) ---
            */
            return default;
        }

        protected async Task<PosOrder> SendOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _send_order) ---
            */
            return default;
        }

        protected async Task<PosOrder> SendPaymentResultInternalAsync(object payment_result)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: _send_payment_result) ---
            */
            return default;
        }

        protected async Task<PosOrder> SendSelfOrderReceiptInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: _send_self_order_receipt) ---
            */
            return default;
        }

        protected async Task<PosOrder> ShouldCreatePickingRealTimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _should_create_picking_real_time) ---
            */
            return default;
        }

        protected async Task<PosOrder> UnlinkExceptDraftOrCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _unlink_except_draft_or_cancel) ---
            */
            return default;
        }

        protected async Task<PosOrder> UpdateSequenceNumberInternalAsync(object session, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _update_sequence_number) ---
            */
            return default;
        }
    }
}