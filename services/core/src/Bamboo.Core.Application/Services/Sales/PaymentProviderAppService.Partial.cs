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
    public partial class PaymentProviderAppService
    {

        protected async Task<PaymentProvider> ActivateDefaultPmsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _activate_default_pms) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> AdyenComputeShopperReferenceInternalAsync(Guid partner_id)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: _adyen_compute_shopper_reference) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentProvider> AdyenExtractPrefixFromApiUrlInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: _adyen_extract_prefix_from_api_url) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> AdyenGetFormattedAmountInternalAsync(object amount, object currency)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: _adyen_get_formatted_amount) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> AdyenGetInlineFormValuesInternalAsync(object pm_code, object amount, object currency)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: _adyen_get_inline_form_values) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ApsCalculateSignatureInternalAsync(object data, object incoming)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_aps, FILE: payment_provider.py, METHOD: _aps_calculate_signature) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ApsGetApiUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_aps, FILE: payment_provider.py, METHOD: _aps_get_api_url) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ArchiveLinkedTokensInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _archive_linked_tokens) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> AsiapayCalculateSignatureInternalAsync(object data, object incoming)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_provider.py, METHOD: _asiapay_calculate_signature) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> AsiapayGetApiUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_provider.py, METHOD: _asiapay_get_api_url) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> AuthorizeGetInlineFormValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py, METHOD: _authorize_get_inline_form_values) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> BuckarooGenerateDigitalSignInternalAsync(object values, object incoming)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_provider.py, METHOD: _buckaroo_generate_digital_sign) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> BuckarooGetApiUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_provider.py, METHOD: _buckaroo_get_api_url) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> BuildRequestAuthInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _build_request_auth) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: _build_request_auth) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _build_request_auth) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py, METHOD: _build_request_auth) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> BuildRequestHeadersInternalAsync(object method, object endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_dpo, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py, METHOD: _build_request_headers) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> BuildRequestUrlInternalAsync(object endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_dpo, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py, METHOD: _build_request_url) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py, METHOD: _build_request_url) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckAvailableCountryCurrencyIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _check_available_country_currency_ids) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckExistingPaymentInternalAsync(object payment_method)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py, METHOD: _check_existing_payment) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckManualCaptureSupportedByPaymentMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _check_manual_capture_supported_by_payment_methods) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckMercadoPagoCredentialsAreSetBeforeAllowingTokenizationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _check_mercado_pago_credentials_are_set_before_allowing_tokenization) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckMercadoPagoCredentialsAreSetBeforeEnablingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _check_mercado_pago_credentials_are_set_before_enabling) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckOnboardingOfEnabledProviderIsCompletedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _check_onboarding_of_enabled_provider_is_completed) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckProviderStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_provider.py, METHOD: _check_provider_state) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckRazorpayCredentialsAreSetBeforeEnablingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _check_razorpay_credentials_are_set_before_enabling) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckRequiredIfProviderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _check_required_if_provider) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckStateOfConnectedAccountIsNeverTestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _check_state_of_connected_account_is_never_test) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ComputeAvailableCurrencyIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _compute_available_currency_ids) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ComputeColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _compute_color) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ComputeFeatureSupportFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py, METHOD: _compute_feature_support_fields) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ComputeJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ComputeMercadoPagoIsOauthSupportedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _compute_mercado_pago_is_oauth_supported) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> DeactivateUnsupportedPaymentMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _deactivate_unsupported_payment_methods) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> EnsurePaymentMethodLineInternalAsync(object allow_create)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py, METHOD: _ensure_payment_method_line) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_code) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentProvider> GetCompatibleProvidersInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: payment_provider.py, METHOD: _get_compatible_providers) ---
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_compatible_providers) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py, METHOD: _get_compatible_providers) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _get_compatible_providers) ---
            --- METHOD SOURCE (MODULE: website_payment, FILE: payment_provider.py, METHOD: _get_compatible_providers) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: payment_provider.py, METHOD: _get_compatible_providers) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetDefaultPaymentMethodCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_aps, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_dpo, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: payment_provider.py, METHOD: _get_default_payment_method_codes) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetPaymentMethodOutstandingAccountIdInternalAsync(Guid payment_method_id)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py, METHOD: _get_payment_method_outstanding_account_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentProvider> GetProviderDomainInternalAsync(object provider_code)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_provider_domain) ---
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py, METHOD: _get_provider_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentProvider> GetProviderPaymentMethodInternalAsync(object code)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py, METHOD: _get_provider_payment_method) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetRedirectFormViewInternalAsync(object is_validation)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_redirect_form_view) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py, METHOD: _get_redirect_form_view) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentProvider> GetRemovalValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_removal_values) ---
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py, METHOD: _get_removal_values) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetResetValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_reset_values) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _get_reset_values) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _get_reset_values) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetStatusMessageInternalAsync(object status)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_status_message) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetStripeExtraRequestHeadersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _get_stripe_extra_request_headers) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetStripeWebhookUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _get_stripe_webhook_url) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetSupportedCurrenciesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_supported_currencies) ---
            --- METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_provider.py, METHOD: _get_supported_currencies) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py, METHOD: _get_supported_currencies) ---
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_provider.py, METHOD: _get_supported_currencies) ---
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_provider.py, METHOD: _get_supported_currencies) ---
            --- METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_provider.py, METHOD: _get_supported_currencies) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: _get_supported_currencies) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _get_supported_currencies) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py, METHOD: _get_supported_currencies) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetValidationAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_validation_amount) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py, METHOD: _get_validation_amount) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _get_validation_amount) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> GetValidationCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _get_validation_currency) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> InverseJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py, METHOD: _inverse_journal_id) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> InverseMercadoPagoAccountCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _inverse_mercado_pago_account_country_id) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> InversePaymobAccountCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _inverse_paymob_account_country_id) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> IsTokenizationRequiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _is_tokenization_required) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> IyzicoCalculateSignatureInternalAsync(object endpoint, object payload, object random_string)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_provider.py, METHOD: _iyzico_calculate_signature) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> LimitAvailableCurrencyIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_provider.py, METHOD: _limit_available_currency_ids) ---
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py, METHOD: _limit_available_currency_ids) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> LogRequestInternalAsync(object method, object url, object payload)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _log_request) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> LogResponseInternalAsync(object response)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _log_response) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> MatchPaymobPaymentMethodsInternalAsync(object paymob_gateways_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _match_paymob_payment_methods) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> MercadoPagoFetchAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _mercado_pago_fetch_access_token) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> MercadoPagoGetInlineFormValuesInternalAsync(Guid partner_id)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _mercado_pago_get_inline_form_values) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> NuveiCalculateSignatureInternalAsync(object data, object incoming)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_provider.py, METHOD: _nuvei_calculate_signature) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> NuveiGetApiUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_provider.py, METHOD: _nuvei_get_api_url) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> OnchangeCompanyBlockIfExistingTransactionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _onchange_company_block_if_existing_transactions) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> OnchangeStateSwitchIsPublishedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _onchange_state_switch_is_published) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> OnchangeStateWarnBeforeDisablingTokensInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _onchange_state_warn_before_disabling_tokens) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ParseProxyResponseInternalAsync(object response)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _parse_proxy_response) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ParseResponseContentInternalAsync(object response)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _parse_response_content) ---
            --- METHOD SOURCE (MODULE: payment_dpo, FILE: payment_provider.py, METHOD: _parse_response_content) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py, METHOD: _parse_response_content) ---
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_provider.py, METHOD: _parse_response_content) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _parse_response_content) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _parse_response_content) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _parse_response_content) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ParseResponseErrorInternalAsync(object response)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_mollie, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            --- METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py, METHOD: _parse_response_error) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> PaymobFetchAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _paymob_fetch_access_token) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> PaymobGetApiUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _paymob_get_api_url) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> PaypalFetchAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: _paypal_fetch_access_token) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> PaypalGetApiUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: _paypal_get_api_url) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> PaypalGetInlineFormValuesInternalAsync(object currency)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: _paypal_get_inline_form_values) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> PrepareJsonRpcPayloadInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _prepare_json_rpc_payload) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _prepare_json_rpc_payload) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> RazorpayCalculateSignatureInternalAsync(object data, object is_redirect)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _razorpay_calculate_signature) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> RazorpayRefreshAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: _razorpay_refresh_access_token) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> RedsysCalculateSignatureInternalAsync(object merchant_parameters, object reference, object secret_key)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_provider.py, METHOD: _redsys_calculate_signature) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> RedsysGetApiUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_provider.py, METHOD: _redsys_get_api_url) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentProvider> RemoveProviderInternalAsync(object provider_code)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py, METHOD: _remove_provider) ---
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _remove_provider) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> SendApiRequestInternalAsync(object method, object endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _send_api_request) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentProvider> SetupPaymentMethodInternalAsync(object code)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py, METHOD: _setup_payment_method) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentProvider> SetupProviderInternalAsync(object provider_code)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py, METHOD: _setup_provider) ---
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _setup_provider) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ShouldBuildInlineFormInternalAsync(object is_validation)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _should_build_inline_form) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeCreateAccountLinkInternalAsync(Guid connected_account_id, Guid menu_id)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _stripe_create_account_link) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeFetchOrCreateConnectedAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _stripe_fetch_or_create_connected_account) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeGetCountryInternalAsync(object country_code)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _stripe_get_country) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeGetInlineFormValuesInternalAsync(object amount, object currency, Guid partner_id, object is_validation, object payment_method_sudo)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _stripe_get_inline_form_values) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeGetPublishableKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _stripe_get_publishable_key) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeHasConnectedAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _stripe_has_connected_account) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeOnboardingIsOngoingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _stripe_onboarding_is_ongoing) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> StripePrepareConnectAccountPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _stripe_prepare_connect_account_payload) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> StripePrepareProxyDataInternalAsync(object stripe_payload)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: _stripe_prepare_proxy_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PaymentProvider> TogglePostProcessingCronInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _toggle_post_processing_cron) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> TransferEnsurePendingMsgIsSetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py, METHOD: _transfer_ensure_pending_msg_is_set) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> UpdatePaymentMethodIntegrationNamesInternalAsync(object matched_gateways_data)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: _update_payment_method_integration_names) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> ValidFieldParameterInternalAsync(object field, object name)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: _valid_field_parameter) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> WorldlineCalculateSignatureInternalAsync(object method, object endpoint, object content_type, object dt_rfc, object idempotency_key)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py, METHOD: _worldline_calculate_signature) ---
            */
            return default;
        }

        protected async Task<PaymentProvider> WorldlineGetApiUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py, METHOD: _worldline_get_api_url) ---
            */
            return default;
        }
    }
}