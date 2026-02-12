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
    public partial class PosPaymentMethodAppService
    {

        protected async Task<PosPaymentMethod> BearerTokenInternalAsync(object session)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _bearer_token) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CallVivaComInternalAsync(object endpoint, object action, object data, object should_retry)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _call_viva_com) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckAdyenTerminalIdentifierInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _check_adyen_terminal_identifier) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckPaymentMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _check_payment_method) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckPineLabsTerminalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py, METHOD: _check_pine_labs_terminal) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckQfpayTerminalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_qfpay, FILE: pos_payment_method.py, METHOD: _check_qfpay_terminal) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckRazorpayTerminalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py, METHOD: _check_razorpay_terminal) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckSpecialAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: _check_special_access) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckStripeSerialNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py, METHOD: _check_stripe_serial_number) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> CheckVivaComCredentialsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _check_viva_com_credentials) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeHasAnOnlinePaymentProviderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _compute_has_an_online_payment_provider) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeHideQrCodeMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _compute_hide_qr_code_method) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeHideUsePaymentTerminalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _compute_hide_use_payment_terminal) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _compute_hide_use_payment_terminal) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeIsCashCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _compute_is_cash_count) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeOpenSessionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _compute_open_session_ids) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeQrInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _compute_qr) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _compute_type) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _compute_type) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ComputeVivaComWebhookEndpointInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _compute_viva_com_webhook_endpoint) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> DpopayHeadersInternalAsync(object token_expired)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_dpopay, FILE: pos_payment_method.py, METHOD: _dpopay_headers) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ExecuteDpopayApiRequestInternalAsync(object payload, object endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_dpopay, FILE: pos_payment_method.py, METHOD: _execute_dpopay_api_request) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> FindTerminalInternalAsync(object token, object point_smart)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: _find_terminal) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ForceOnlinePaymentValuesInternalAsync(object if_present)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _force_online_payment_values) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ForcePaymentMethodTypeValuesInternalAsync(object payment_method_type, object if_present)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _force_payment_method_type_values) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GenerateDpopayTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_dpopay, FILE: pos_payment_method.py, METHOD: _generate_dpopay_token) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetAdyenEndpointsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _get_adyen_endpoints) ---
            --- METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_payment_method.py, METHOD: _get_adyen_endpoints) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetDpopayBaseUrlInternalAsync(object is_token)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_dpopay, FILE: pos_payment_method.py, METHOD: _get_dpopay_base_url) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetExpectedMessageHeaderInternalAsync(object expected_message_category)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _get_expected_message_header) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetExpectedPaymentRequestInternalAsync(object with_acquirer_data)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _get_expected_payment_request) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPaymentMethod> GetHmacInternalAsync(Guid sale_id, Guid service_id, Guid poi_id, Guid sale_transaction_id)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _get_hmac) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetOnlinePaymentProvidersInternalAsync(Guid pos_config_id, object error_if_invalid)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _get_online_payment_providers) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPaymentMethod> GetOrCreateOnlinePaymentMethodInternalAsync(Guid company_id, Guid pos_config_id)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _get_or_create_online_payment_method) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetPaymentMethodTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _get_payment_method_type) ---
            --- METHOD SOURCE (MODULE: pos_glory_cash, FILE: pos_payment_method.py, METHOD: _get_payment_method_type) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetPaymentTerminalSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            --- METHOD SOURCE (MODULE: pos_dpopay, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            --- METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            --- METHOD SOURCE (MODULE: pos_qfpay, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            --- METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            --- METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _get_payment_terminal_selection) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetStripePaymentProviderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py, METHOD: _get_stripe_payment_provider) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> GetTransactionTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_dpopay, FILE: pos_payment_method.py, METHOD: _get_transaction_type) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPaymentMethod> GetValidAcquirerDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _get_valid_acquirer_data) ---
            --- METHOD SOURCE (MODULE: pos_self_order_adyen, FILE: pos_payment_method.py, METHOD: _get_valid_acquirer_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPaymentMethod> IsValidAdyenRequestDataInternalAsync(object provided_data, object expected_data)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _is_valid_adyen_request_data) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> IsWriteForbiddenInternalAsync(object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _is_write_forbidden) ---
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _is_write_forbidden) ---
            --- METHOD SOURCE (MODULE: pos_dpopay, FILE: pos_payment_method.py, METHOD: _is_write_forbidden) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _is_write_forbidden) ---
            --- METHOD SOURCE (MODULE: pos_qfpay, FILE: pos_payment_method.py, METHOD: _is_write_forbidden) ---
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _is_write_forbidden) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPaymentMethod> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_glory_cash, FILE: pos_payment_method.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_qfpay, FILE: pos_payment_method.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_payment_method.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPaymentMethod> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_payment_method.py, METHOD: _load_pos_self_data_domain) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_payment_method.py, METHOD: _load_pos_self_data_domain) ---
            --- METHOD SOURCE (MODULE: pos_self_order_adyen, FILE: pos_payment_method.py, METHOD: _load_pos_self_data_domain) ---
            --- METHOD SOURCE (MODULE: pos_self_order_pine_labs, FILE: pos_payment_method.py, METHOD: _load_pos_self_data_domain) ---
            --- METHOD SOURCE (MODULE: pos_self_order_qfpay, FILE: pos_payment_method.py, METHOD: _load_pos_self_data_domain) ---
            --- METHOD SOURCE (MODULE: pos_self_order_razorpay, FILE: pos_payment_method.py, METHOD: _load_pos_self_data_domain) ---
            --- METHOD SOURCE (MODULE: pos_self_order_stripe, FILE: pos_payment_method.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> OnchangeIsOnlinePaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: _onchange_is_online_payment) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> OnchangeJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _onchange_journal_id) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> OnchangePaymentMethodTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _onchange_payment_method_type) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> OnchangeUsePaymentTerminalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: _onchange_use_payment_terminal) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> PaymentRequestFromKioskInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_payment_method.py, METHOD: _payment_request_from_kiosk) ---
            --- METHOD SOURCE (MODULE: pos_self_order_adyen, FILE: pos_payment_method.py, METHOD: _payment_request_from_kiosk) ---
            --- METHOD SOURCE (MODULE: pos_self_order_pine_labs, FILE: pos_payment_method.py, METHOD: _payment_request_from_kiosk) ---
            --- METHOD SOURCE (MODULE: pos_self_order_razorpay, FILE: pos_payment_method.py, METHOD: _payment_request_from_kiosk) ---
            --- METHOD SOURCE (MODULE: pos_self_order_stripe, FILE: pos_payment_method.py, METHOD: _payment_request_from_kiosk) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> ProxyAdyenRequestDirectInternalAsync(object data, object operation)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: _proxy_adyen_request_direct) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPaymentMethod> QfpayHandleWebhookInternalAsync(object config, object data, object uuid)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_qfpay, FILE: pos_payment_method.py, METHOD: _qfpay_handle_webhook) ---
            --- METHOD SOURCE (MODULE: pos_self_order_qfpay, FILE: pos_payment_method.py, METHOD: _qfpay_handle_webhook) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> RetrieveSessionIdInternalAsync(object data_webhook)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _retrieve_session_id) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> SendNotificationInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _send_notification) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> StripeCalculateAmountInternalAsync(object amount)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py, METHOD: _stripe_calculate_amount) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> VivaComAccountGetEndpointInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _viva_com_account_get_endpoint) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> VivaComApiGetEndpointInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _viva_com_api_get_endpoint) ---
            */
            return default;
        }

        protected async Task<PosPaymentMethod> VivaComWebhookGetEndpointInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: _viva_com_webhook_get_endpoint) ---
            */
            return default;
        }
    }
}