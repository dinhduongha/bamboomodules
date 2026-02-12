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
    public partial class PaymentTransactionAppService
    {

        protected async Task<PaymentTransaction> AdyenCreateChildTxInternalAsync(object source_tx, object payment_data, object is_refund)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _adyen_create_child_tx) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ApplyUpdatesInternalAsync(object payment_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _apply_updates) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> AuthorizeCreateTransactionRequestInternalAsync(object opaque_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py, METHOD: _authorize_create_transaction_request) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> BuildActionFeedbackNotificationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _build_action_feedback_notification) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> CaptureInternalAsync(object amount_to_capture)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _capture) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ChargeWithTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _charge_with_token) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> CheckAmountAndConfirmOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: _check_amount_and_confirm_order) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> CheckStateAuthorizedSupportedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _check_state_authorized_supported) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> CheckTokenIsActiveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _check_token_is_active) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeInvoicesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py, METHOD: _compute_invoices_count) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputePrimaryPaymentMethodIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _compute_primary_payment_method_id) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeReferenceInternalAsync(object provider_code, object prefix, object separator)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _compute_reference) ---
            --- METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py, METHOD: _compute_reference) ---
            --- METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py, METHOD: _compute_reference) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py, METHOD: _compute_reference) ---
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py, METHOD: _compute_reference) ---
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py, METHOD: _compute_reference) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _compute_reference) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentTransaction> ComputeReferencePrefixInternalAsync(object separator)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py, METHOD: _compute_reference_prefix) ---
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _compute_reference_prefix) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: payment_transaction.py, METHOD: _compute_reference_prefix) ---
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: _compute_reference_prefix) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeRefundsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _compute_refunds_count) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeSaleOrderIdsNbrInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: _compute_sale_order_ids_nbr) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeSaleOrderReferenceInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: _compute_sale_order_reference) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> CreateChildTransactionInternalAsync(object amount, object is_refund)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _create_child_transaction) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> CreatePaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py, METHOD: _create_payment) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> CronPostProcessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _cron_post_process) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> CronSendInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: _cron_send_invoice) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> DpoCreateTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py, METHOD: _dpo_create_token) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> EnsureProviderIsNotDisabledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _ensure_provider_is_not_disabled) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ExtractAmountDataInternalAsync(object payment_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _extract_amount_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentTransaction> ExtractReferenceInternalAsync(object provider_code, object payment_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _extract_reference) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ExtractTokenValuesInternalAsync(object payment_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _extract_token_values) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> FlutterwaveIsAuthorizationPendingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py, METHOD: _flutterwave_is_authorization_pending) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetCommunicationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py, METHOD: _get_communication) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetInvoicesToNotifyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py, METHOD: _get_invoices_to_notify) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetLastInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _get_last) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetMandateValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _get_mandate_values) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetProcessingValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _get_processing_values) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetReceivedMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _get_received_message) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetRoundedAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _get_rounded_amount) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetSentMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _get_sent_message) ---
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py, METHOD: _get_sent_message) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentTransaction> GetSpecificCreateValuesInternalAsync(object provider_code, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _get_specific_create_values) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetSpecificProcessingValuesInternalAsync(object processing_values)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _get_specific_processing_values) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _get_specific_processing_values) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py, METHOD: _get_specific_processing_values) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py, METHOD: _get_specific_processing_values) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py, METHOD: _get_specific_processing_values) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _get_specific_processing_values) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _get_specific_processing_values) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _get_specific_processing_values) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _get_specific_processing_values) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetSpecificRenderingValuesInternalAsync(object processing_values)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _get_specific_rendering_values) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> InvoiceSaleOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: _invoice_sale_orders) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> IsSelfOrderPaymentConfirmedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: payment_transaction.py, METHOD: _is_self_order_payment_confirmed) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> IyzicoPrepareCfInitializePayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_transaction.py, METHOD: _iyzico_prepare_cf_initialize_payload) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentTransaction> LangGetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _lang_get) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> LogMessageOnLinkedDocumentsInternalAsync(object message)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py, METHOD: _log_message_on_linked_documents) ---
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _log_message_on_linked_documents) ---
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: _log_message_on_linked_documents) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> LogReceivedMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _log_received_message) ---
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py, METHOD: _log_received_message) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> LogSentMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _log_sent_message) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoConvertAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _mercado_pago_convert_amount) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentTransaction> MercadoPagoGetErrorMsgInternalAsync(object status_detail)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _mercado_pago_get_error_msg) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoPrepareBaseRequestPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _mercado_pago_prepare_base_request_payload) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoPreparePaymentRequestPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _mercado_pago_prepare_payment_request_payload) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoPreparePreferenceRequestPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _mercado_pago_prepare_preference_request_payload) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> MolliePreparePaymentRequestPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py, METHOD: _mollie_prepare_payment_request_payload) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> PaymobPreparePaymentRequestPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py, METHOD: _paymob_prepare_payment_request_payload) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> PaypalPrepareOrderPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py, METHOD: _paypal_prepare_order_payload) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> PostProcessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py, METHOD: _post_process) ---
            --- METHOD SOURCE (MODULE: delivery, FILE: payment_transaction.py, METHOD: _post_process) ---
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _post_process) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: payment_transaction.py, METHOD: _post_process) ---
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: _post_process) ---
            --- METHOD SOURCE (MODULE: website_payment, FILE: payment_transaction.py, METHOD: _post_process) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: payment_transaction.py, METHOD: _post_process) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ProcessInternalAsync(object provider_code, object payment_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _process) ---
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: payment_transaction.py, METHOD: _process) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ProcessPosOnlinePaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: payment_transaction.py, METHOD: _process_pos_online_payment) ---
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: payment_transaction.py, METHOD: _process_pos_online_payment) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentTransaction> RazorpayConvertInrToCurrencyInternalAsync(object amount, Guid currency_id)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _razorpay_convert_inr_to_currency) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayCreateCustomerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _razorpay_create_customer) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayCreateOrderInternalAsync(Guid customer_id)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _razorpay_create_order) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayCreateRefundTxFromPaymentDataInternalAsync(object source_tx, object payment_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _razorpay_create_refund_tx_from_payment_data) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayGetMandateMaxAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _razorpay_get_mandate_max_amount) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayPrepareOrderPayloadInternalAsync(Guid customer_id)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _razorpay_prepare_order_payload) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> RedsysPrepareMerchantParametersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py, METHOD: _redsys_prepare_merchant_parameters) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> RefundInternalAsync(object amount_to_refund)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _refund) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentTransaction> SearchByReferenceInternalAsync(object provider_code, object payment_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _search_by_reference) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _search_by_reference) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _search_by_reference) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _search_by_reference) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendApiRequestInternalAsync(object method, object endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _send_api_request) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendCaptureRequestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _send_capture_request) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _send_capture_request) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py, METHOD: _send_capture_request) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: _send_capture_request) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _send_capture_request) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _send_capture_request) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendDonationEmailInternalAsync(object is_internal_notification, object comment, object recipient_email)
        {
            /*
            --- METHOD SOURCE (MODULE: website_payment, FILE: payment_transaction.py, METHOD: _send_donation_email) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: _send_invoice) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendPaymentRequestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _send_payment_request) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendRefundRequestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _send_refund_request) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _send_refund_request) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py, METHOD: _send_refund_request) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: _send_refund_request) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _send_refund_request) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _send_refund_request) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendVoidRequestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _send_void_request) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py, METHOD: _send_void_request) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py, METHOD: _send_void_request) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: _send_void_request) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _send_void_request) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _send_void_request) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetAuthorizedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _set_authorized) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetCanceledInternalAsync(object state_message, object extra_allowed_states)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _set_canceled) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _set_done) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetErrorInternalAsync(object state_message, object extra_allowed_states)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _set_error) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetPendingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _set_pending) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripeCreateCustomerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _stripe_create_customer) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripeCreateIntentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _stripe_create_intent) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripePrepareMandateOptionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _stripe_prepare_mandate_options) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripePreparePaymentIntentPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _stripe_prepare_payment_intent_payload) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripePrepareSetupIntentPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py, METHOD: _stripe_prepare_setup_intent_payload) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> TokenizeInternalAsync(object payment_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _tokenize) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> UpdateSourceTransactionStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _update_source_transaction_state) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> UpdateStateInternalAsync(object allowed_states, object target_state, object state_message)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _update_state) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> ValidateAmountInternalAsync(object payment_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _validate_amount) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentTransaction> ValidatePhoneNumberInternalAsync(object phone)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py, METHOD: _validate_phone_number) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> VoidInternalAsync(object amount_to_void)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: _void) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> WorldlineCreateCheckoutSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _worldline_create_checkout_session) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> WorldlineExtractPaymentMethodDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py, METHOD: _worldline_extract_payment_method_data) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> XenditCreateChargeInternalAsync(object token_ref, Guid auth_id)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _xendit_create_charge) ---
            */
            return default;
        }

        protected async Task<PaymentTransaction> XenditPrepareInvoiceRequestPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py, METHOD: _xendit_prepare_invoice_request_payload) ---
            */
            return default;
        }
    }
}