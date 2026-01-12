using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Payment", Category = "Sales", Depends = new[] { "onboarding", "portal" })]
    public class PaymentProviderAppService : GenericApplicationService<PaymentProvider>, IPaymentProviderAppService
    {

        public PaymentProviderAppService(IRepository<PaymentProvider, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<PaymentProvider> ActivateDefaultPmsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _activate_default_pms(self):
            // """ Activate the default payment methods of the provider.
            // 
            // :return: None
            // """
            // for provider in self:
            //     pm_codes = provider._get_default_payment_method_codes()
            //     pms = provider.with_context(active_test=False).payment_method_ids
            //     (pms + pms.brand_ids).filtered(lambda pm: pm.code in pm_codes).active = True
            */
            return default;
        }

        protected async Task<PaymentProvider> AdyenComputeShopperReferenceInternalAsync(Guid partner_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py) ---
            // def _adyen_compute_shopper_reference(self, partner_id):
            // """ Compute a unique reference of the partner for Adyen.
            // 
            // This is used for the `shopperReference` field in communications with Adyen and stored in the
            // `adyen_shopper_reference` field on `payment.token` if the payment method is tokenized.
            // 
            // :param recordset partner_id: The partner making the transaction, as a `res.partner` id
            // :return: The unique reference for the partner
            // :rtype: str
            // """
            // return f'ODOO_PARTNER_{partner_id}'
            */
            return default;
        }

        protected async Task<PaymentProvider> AdyenExtractPrefixFromApiUrlInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py) ---
            // def _adyen_extract_prefix_from_api_url(self, values):
            // """ Update the create or write values with the prefix extracted from the API URL.
            // 
            // :param dict values: The create or write values.
            // :return: None
            // """
            // if values.get('adyen_api_url_prefix'):  # Test if we're duplicating a provider.
            //     values['adyen_api_url_prefix'] = re.sub(
            //         r'(?:https://)?(\w+-\w+).*', r'\1', values['adyen_api_url_prefix']
            //     )
            */
            return default;
        }

        protected async Task<PaymentProvider> AdyenGetFormattedAmountInternalAsync(object amount, object currency)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py) ---
            // def _adyen_get_formatted_amount(self, amount=None, currency=None):
            // """ Return the amount in the format required by Adyen.
            // 
            // The formatted amount is a dict with keys 'value' and 'currency'.
            // 
            // :param float amount: The transaction amount.
            // :param res.currency currency: The transaction currency.
            // :return: The Adyen-formatted amount.
            // :rtype: dict
            // """
            // currency_code = currency and currency.name
            // converted_amount = amount and currency_code and payment_utils.to_minor_currency_units(
            //     amount, currency, const.CURRENCY_DECIMALS.get(currency_code)
            // )
            // return {
            //     'value': converted_amount,
            //     'currency': currency_code,
            // }
            */
            return default;
        }

        protected async Task<PaymentProvider> AdyenGetInlineFormValuesInternalAsync(object pm_code, object amount, object currency)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py) ---
            // def _adyen_get_inline_form_values(self, pm_code, amount=None, currency=None):
            // """ Return a serialized JSON of the required values to render the inline form.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param str pm_code: The code of the payment method whose inline form to render.
            // :param float amount: The transaction amount.
            // :param res.currency currency: The transaction currency.
            // :return: The JSON serial of the required values to render the inline form.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // inline_form_values = {
            //     'client_key': self.adyen_client_key,
            //     'adyen_pm_code': const.PAYMENT_METHODS_MAPPING.get(pm_code, pm_code),
            //     'formatted_amount': self._adyen_get_formatted_amount(amount, currency),
            // }
            // return json.dumps(inline_form_values)
            */
            return default;
        }

        protected async Task<PaymentProvider> AdyenMakeRequestInternalAsync(object endpoint, object endpoint_param, object payload, object method, object idempotency_key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py) ---
            // def _adyen_make_request(self, endpoint, endpoint_param=None, payload=None, method='POST', idempotency_key=None):
            // """ Make a request to Adyen API at the specified endpoint.
            // 
            // Note: self.ensure_one()
            // 
            // :param str endpoint: The endpoint to be reached by the request
            // :param str endpoint_param: A variable required by some endpoints which are interpolated with
            //                            it if provided. For example, the provider reference of the source
            //                            transaction for the '/payments/{}/refunds' endpoint.
            // :param dict payload: The payload of the request
            // :param str method: The HTTP method of the request
            // :param str idempotency_key: The idempotency key to pass in the request.
            // :return: The JSON-formatted content of the response
            // :rtype: dict
            // :raise: ValidationError if an HTTP error occurs
            // """
            // 
            // def _build_url(prefix_, version_, endpoint_):
            //     """ Build an API URL by appending the version and endpoint to a base URL.
            // 
            //     The final URL follows this pattern: `<_base>/V<_version>/<_endpoint>`.
            // 
            //     :param str prefix_: The API URL prefix of the account.
            //     :param int version_: The version of the endpoint.
            //     :param str endpoint_: The endpoint of the URL.
            //     :return: The final URL.
            //     :rtype: str
            //     """
            //     prefix_ = prefix_.rstrip('/')  # Remove potential trailing slash
            //     endpoint_ = endpoint_.lstrip('/')  # Remove potential leading slash
            //     test_mode_ = self.state == 'test'
            //     prefix_ = f'{prefix_}.adyen' if test_mode_ else f'{prefix_}-checkout-live.adyenpayments'
            //     return f'https://{prefix_}.com/checkout/V{version_}/{endpoint_}'
            // 
            // self.ensure_one()
            // 
            // version = const.API_ENDPOINT_VERSIONS[endpoint]
            // endpoint = endpoint if not endpoint_param else endpoint.format(endpoint_param)
            // url = _build_url(self.adyen_api_url_prefix, version, endpoint)
            // headers = {'X-API-Key': self.adyen_api_key}
            // if method == 'POST' and idempotency_key:
            //     headers['idempotency-key'] = idempotency_key
            // try:
            //     response = requests.request(method, url, json=payload, headers=headers, timeout=60)
            //     try:
            //         response.raise_for_status()
            //     except requests.exceptions.HTTPError:
            //         _logger.exception(
            //             "invalid API request at %s with data %s: %s", url, payload, response.text
            //         )
            //         msg = response.json().get('message', '')
            //         raise ValidationError(
            //             "Adyen: " + _("The communication with the API failed. Details: %s", msg)
            //         )
            // except requests.exceptions.ConnectionError:
            //     _logger.exception("unable to reach endpoint at %s", url)
            //     raise ValidationError("Adyen: " + _("Could not establish the connection to the API."))
            // return response.json()
            */
            return default;
        }

        protected async Task<PaymentProvider> ApsCalculateSignatureInternalAsync(object data, object incoming)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_provider.py) ---
            // def _aps_calculate_signature(self, data, incoming=True):
            // """ Compute the signature for the provided data according to the APS documentation.
            // 
            // :param dict data: The data to sign.
            // :param bool incoming: Whether the signature must be generated for an incoming (APS to Odoo)
            //                       or outgoing (Odoo to APS) communication.
            // :return: The calculated signature.
            // :rtype: str
            // """
            // sign_data = ''.join([f'{k}={v}' for k, v in sorted(data.items()) if k != 'signature'])
            // key = self.aps_sha_response if incoming else self.aps_sha_request
            // signing_string = ''.join([key, sign_data, key])
            // return hashlib.sha256(signing_string.encode()).hexdigest()
            */
            return default;
        }

        protected async Task<PaymentProvider> ApsGetApiUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_provider.py) ---
            // def _aps_get_api_url(self):
            // if self.state == 'enabled':
            //     return 'https://checkout.payfort.com/FortAPI/paymentPage'
            // else:  # 'test'
            //     return 'https://sbcheckout.payfort.com/FortAPI/paymentPage'
            */
            return default;
        }

        protected async Task<PaymentProvider> ArchiveLinkedTokensInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _archive_linked_tokens(self):
            // """ Archive all the payment tokens linked to the providers.
            // 
            // :return: None
            // """
            // self.env['payment.token'].search([('provider_id', 'in', self.ids)]).write({'active': False})
            */
            return default;
        }

        protected async Task<PaymentProvider> AsiapayCalculateSignatureInternalAsync(object data, object incoming)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_provider.py) ---
            // def _asiapay_calculate_signature(self, data, incoming=True):
            // """ Compute the signature for the provided data according to the AsiaPay documentation.
            // 
            // :param dict data: The data to sign.
            // :param bool incoming: Whether the signature must be generated for an incoming (AsiaPay to
            //                       Odoo) or outgoing (Odoo to AsiaPay) communication.
            // :return: The calculated signature.
            // :rtype: str
            // """
            // signature_keys = const.SIGNATURE_KEYS['incoming' if incoming else 'outgoing']
            // data_to_sign = [str(data[k]) for k in signature_keys] + [self.asiapay_secure_hash_secret]
            // signing_string = '|'.join(data_to_sign)
            // shasign = hashnew(self.asiapay_secure_hash_function)
            // shasign.update(signing_string.encode())
            // return shasign.hexdigest()
            */
            return default;
        }

        protected async Task<PaymentProvider> AsiapayGetApiUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_provider.py) ---
            // def _asiapay_get_api_url(self):
            // """ Return the URL of the API corresponding to the provider's state.
            // 
            // :return: The API URL.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // environment = 'production' if self.state == 'enabled' else 'test'
            // api_urls = const.API_URLS[environment]
            // return api_urls.get(self.asiapay_brand, api_urls['paydollar'])
            */
            return default;
        }

        protected async Task<PaymentProvider> AuthorizeGetInlineFormValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py) ---
            // def _authorize_get_inline_form_values(self):
            // """ Return a serialized JSON of the required values to render the inline form.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The JSON serial of the required values to render the inline form.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // inline_form_values = {
            //     'state': self.state,
            //     'login_id': self.authorize_login,
            //     'client_key': self.authorize_client_key,
            // }
            // return json.dumps(inline_form_values)
            */
            return default;
        }

        protected async Task<PaymentProvider> BuckarooGenerateDigitalSignInternalAsync(object values, object incoming)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_provider.py) ---
            // def _buckaroo_generate_digital_sign(self, values, incoming=True):
            // """ Generate the shasign for incoming or outgoing communications.
            // 
            // :param dict values: The values used to generate the signature
            // :param bool incoming: Whether the signature must be generated for an incoming (Buckaroo to
            //                       Odoo) or outgoing (Odoo to Buckaroo) communication.
            // :return: The shasign
            // :rtype: str
            // """
            // if incoming:
            //     # Incoming communication values must be URL-decoded before checking the signature. The
            //     # key 'brq_signature' must be ignored.
            //     items = [
            //         (k, urls.url_unquote_plus(v)) for k, v in values.items()
            //         if k.lower() != 'brq_signature'
            //     ]
            // else:
            //     items = values.items()
            // # Only use items whose key starts with 'add_', 'brq_', or 'cust_' (case insensitive)
            // filtered_items = [
            //     (k, v) for k, v in items
            //     if any(k.lower().startswith(key_prefix) for key_prefix in ('add_', 'brq_', 'cust_'))
            // ]
            // # Sort parameters by lower-cased key. Not upper-case because ord('A') < ord('_') < ord('a').
            // sorted_items = sorted(filtered_items, key=lambda pair: pair[0].lower())
            // # Build the signing string by concatenating all parameters
            // sign_string = ''.join(f'{k}={v or ""}' for k, v in sorted_items)
            // # Append the pre-shared secret key to the signing string
            // sign_string += self.buckaroo_secret_key
            // # Calculate the SHA-1 hash over the signing string
            // return sha1(sign_string.encode('utf-8')).hexdigest()
            */
            return default;
        }

        protected async Task<PaymentProvider> BuckarooGetApiUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_provider.py) ---
            // def _buckaroo_get_api_url(self):
            // """ Return the API URL according to the state.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The API URL
            // :rtype: str
            // """
            // self.ensure_one()
            // if self.state == 'enabled':
            //     return 'https://checkout.buckaroo.nl/html/'
            // else:
            //     return 'https://testcheckout.buckaroo.nl/html/'
            */
            return default;
        }

        public async Task<PaymentProvider> ButtonImmediateInstallAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def button_immediate_install(self):
            // """ Install the module and reload the page.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The action to reload the page.
            // :rtype: dict
            // """
            // if self.module_id and self.module_state != 'installed':
            //     self.module_id.button_immediate_install()
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'reload',
            //     }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> CheckExistingPaymentInternalAsync(object payment_method)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py) ---
            // def _check_existing_payment(self, payment_method):
            // existing_payment_count = self.env['account.payment'].search_count([('payment_method_id', '=', payment_method.id)], limit=1)
            // return bool(existing_payment_count)
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckOnboardingOfEnabledProviderIsCompletedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _check_onboarding_of_enabled_provider_is_completed(self):
            // """ Check that the provider cannot be set to 'enabled' if the onboarding is ongoing.
            // 
            // This constraint is defined in the present module to allow the export of the translation
            // string of the `ValidationError` should it be raised by modules that would fully implement
            // Stripe Connect.
            // 
            // :return: None
            // :raise ValidationError: If the provider of a connected account is set in state 'enabled'
            //                         while the onboarding is not finished.
            // """
            // for provider in self:
            //     if provider.state == 'enabled' and provider._stripe_onboarding_is_ongoing():
            //         raise ValidationError(_(
            //             "You cannot set the provider state to Enabled until your onboarding to Stripe "
            //             "is completed."
            //         ))
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckProviderStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_provider.py) ---
            // def _check_provider_state(self):
            // if self.filtered(lambda p: p.code == 'demo' and p.state not in ('test', 'disabled')):
            //     raise UserError(_("Demo providers should never be enabled."))
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckRequiredIfProviderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _check_required_if_provider(self):
            // """ Check that provider-specific required fields have been filled.
            // 
            // The fields that have the `required_if_provider='<provider_code>'` attribute are made
            // required for all `payment.provider` records with the `code` field equal to `<provider_code>`
            // and with the `state` field equal to `'enabled'` or `'test'`.
            // 
            // Provider-specific views should make the form fields required under the same conditions.
            // 
            // :return: None
            // :raise ValidationError: If a provider-specific required field is empty.
            // """
            // field_names = []
            // enabled_providers = self.filtered(lambda p: p.state in ['enabled', 'test'])
            // for field_name, field in self._fields.items():
            //     required_for_provider_code = getattr(field, 'required_if_provider', None)
            //     if required_for_provider_code and any(
            //         required_for_provider_code == provider._get_code() and not provider[field_name]
            //         for provider in enabled_providers
            //     ):
            //         ir_field = self.env['ir.model.fields']._get(self._name, field_name)
            //         field_names.append(ir_field.field_description)
            // if field_names:
            //     raise ValidationError(
            //         _("The following fields must be filled: %s", ", ".join(field_names))
            //     )
            */
            return default;
        }

        protected async Task<PaymentProvider> CheckStateOfConnectedAccountIsNeverTestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _check_state_of_connected_account_is_never_test(self):
            // """ Check that the provider of a connected account can never been set to 'test'.
            // 
            // This constraint is defined in the present module to allow the export of the translation
            // string of the `ValidationError` should it be raised by modules that would fully implement
            // Stripe Connect.
            // 
            // Additionally, the field `state` is used as a trigger for this constraint to allow those
            // modules to indirectly trigger it when writing on custom fields. Indeed, by always writing on
            // `state` together with writing on those custom fields, the constraint would be triggered.
            // 
            // :return: None
            // :raise ValidationError: If the provider of a connected account is set in state 'test'.
            // """
            // for provider in self:
            //     if provider.state == 'test' and provider._stripe_has_connected_account():
            //         raise ValidationError(_(
            //             "You cannot set the provider to Test Mode while it is linked with your Stripe "
            //             "account."
            //         ))
            */
            return default;
        }

        protected async Task<PaymentProvider> ComputeAvailableCurrencyIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _compute_available_currency_ids(self):
            // """ Compute the available currencies based on their support by the providers.
            // 
            // If the provider does not filter out any currency, the field is left empty for UX reasons.
            // 
            // :return: None
            // """
            // all_currencies = self.env['res.currency'].with_context(active_test=False).search([])
            // for provider in self:
            //     supported_currencies = provider._get_supported_currencies()
            //     if supported_currencies < all_currencies:  # Some currencies have been filtered out.
            //         provider.available_currency_ids = supported_currencies
            //     else:
            //         provider.available_currency_ids = None
            */
            return default;
        }

        protected async Task<PaymentProvider> ComputeColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _compute_color(self):
            // """ Update the color of the kanban card based on the state of the provider.
            // 
            // :return: None
            // """
            // for provider in self:
            //     if provider.module_id and not provider.module_state == 'installed':
            //         provider.color = 4  # blue
            //     elif provider.state == 'disabled':
            //         provider.color = 3  # yellow
            //     elif provider.state == 'test':
            //         provider.color = 2  # orange
            //     elif provider.state == 'enabled':
            //         provider.color = 7
            */
            return default;
        }

        protected async Task<PaymentProvider> ComputeFeatureSupportFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _compute_feature_support_fields(self):
            // """ Compute the feature support fields based on the provider.
            // 
            // Feature support fields are used to specify which additional features are supported by a
            // given provider. These fields are as follows:
            // 
            // - `support_express_checkout`: Whether the "express checkout" feature is supported. `False`
            //   by default.
            // - `support_manual_capture`: Whether the "manual capture" feature is supported. `False` by
            //   default.
            // - `support_refund`: Which type of the "refunds" feature is supported: `None`,
            //   `'full_only'`, or `'partial'`. `None` by default.
            // - `support_tokenization`: Whether the "tokenization feature" is supported. `False` by
            //   default.
            // 
            // For a provider to specify that it supports additional features, it must override this method
            // and set the related feature support fields to the desired value on the appropriate
            // `payment.provider` records.
            // 
            // :return: None
            // """
            // self.update({
            //     'support_express_checkout': None,
            //     'support_manual_capture': None,
            //     'support_tokenization': None,
            //     'support_refund': 'none',
            // })
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py) ---
            // def _compute_feature_support_fields(self):
            // """ Override of `payment` to enable additional features. """
            // super()._compute_feature_support_fields()
            // self.filtered(lambda p: p.code == 'adyen').update({
            //     'support_manual_capture': 'partial',
            //     'support_refund': 'partial',
            //     'support_tokenization': True,
            // })
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py) ---
            // def _compute_feature_support_fields(self):
            // """ Override of `payment` to enable additional features. """
            // super()._compute_feature_support_fields()
            // self.filtered(lambda p: p.code == 'authorize').update({
            //     'support_manual_capture': 'full_only',
            //     'support_refund': 'full_only',
            //     'support_tokenization': True,
            // })
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_provider.py) ---
            // def _compute_feature_support_fields(self):
            // """ Override of `payment` to enable additional features. """
            // super()._compute_feature_support_fields()
            // self.filtered(lambda p: p.code == 'demo').update({
            //     'support_express_checkout': True,
            //     'support_manual_capture': 'partial',
            //     'support_refund': 'partial',
            //     'support_tokenization': True,
            // })
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py) ---
            // def _compute_feature_support_fields(self):
            // """ Override of `payment` to enable additional features. """
            // super()._compute_feature_support_fields()
            // self.filtered(lambda p: p.code == 'flutterwave').update({
            //     'support_tokenization': True,
            // })
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py) ---
            // def _compute_feature_support_fields(self):
            // """ Override of `payment` to enable additional features. """
            // super()._compute_feature_support_fields()
            // self.filtered(lambda p: p.code == 'razorpay').update({
            //     'support_manual_capture': 'full_only',
            //     'support_refund': 'partial',
            //     'support_tokenization': True,
            // })
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _compute_feature_support_fields(self):
            // """ Override of `payment` to enable additional features. """
            // super()._compute_feature_support_fields()
            // self.filtered(lambda p: p.code == 'stripe').update({
            //     'support_express_checkout': True,
            //     'support_manual_capture': 'full_only',
            //     'support_refund': 'partial',
            //     'support_tokenization': True,
            // })
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py) ---
            // def _compute_feature_support_fields(self):
            // """ Override of `payment` to enable additional features. """
            // super()._compute_feature_support_fields()
            // self.filtered(lambda p: p.code == 'worldline').update({
            //     'support_tokenization': True,
            // })
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py) ---
            // def _compute_feature_support_fields(self):
            // """ Override of `payment` to enable additional features. """
            // super()._compute_feature_support_fields()
            // self.filtered(lambda p: p.code == 'xendit').support_tokenization = True
            */
            return default;
        }

        protected async Task<PaymentProvider> ComputeJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py) ---
            // def _compute_journal_id(self):
            // for provider in self:
            //     pay_method_line = self.env['account.payment.method.line'].search([
            //         ('payment_provider_id', '=', provider._origin.id),
            //         ('journal_id', '!=', False),
            //     ], limit=1)
            // 
            //     if pay_method_line:
            //         provider.journal_id = pay_method_line.journal_id
            //     elif provider.state in ('enabled', 'test'):
            //         provider.journal_id = self.env['account.journal'].search(
            //             [
            //                 ('company_id', '=', provider.company_id.id),
            //                 ('type', '=', 'bank'),
            //             ],
            //             limit=1,
            //         )
            //         if provider.id:
            //             provider._ensure_payment_method_line()
            */
            return default;
        }

        public override async Task<PaymentProvider> CopyAsync(Guid id, List<string> fields, PaymentProvider defaultValues = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_payment, FILE: payment_provider.py) ---
            // def copy(self, default=None):
            // res = super().copy(default=default)
            // if self._context.get('stripe_connect_onboarding'):
            //     res.website_id = False
            // return res
            */
            return await base.CopyAsync(id, fields, defaultValues);
        }

        public override async Task<PaymentProvider> CreateAsync(PaymentProvider entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def create(self, values_list):
            // providers = super().create(values_list)
            // providers._check_required_if_provider()
            // if any(provider.state != 'disabled' for provider in providers):
            //     self._toggle_post_processing_cron()
            // return providers
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py) ---
            // def create(self, values_list):
            // for values in values_list:
            //     self._adyen_extract_prefix_from_api_url(values)
            // return super().create(values_list)
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py) ---
            // def create(self, values_list):
            // providers = super().create(values_list)
            // providers.filtered(lambda p: p.custom_mode == 'wire_transfer').pending_msg = None
            // return providers
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<PaymentProvider> DeactivateUnsupportedPaymentMethodsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _deactivate_unsupported_payment_methods(self):
            // """ Deactivate payment methods linked to only disabled providers.
            // 
            // :return: None
            // """
            // unsupported_pms = self.payment_method_ids.filtered(
            //     lambda pm: all(p.state == 'disabled' for p in pm.provider_ids)
            // )
            // (unsupported_pms + unsupported_pms.brand_ids).active = False
            */
            return default;
        }

        protected async Task<PaymentProvider> EnsurePaymentMethodLineInternalAsync(object allow_create)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py) ---
            // def _ensure_payment_method_line(self, allow_create=True):
            // self.ensure_one()
            // if not self.id:
            //     return
            // 
            // default_payment_method = self._get_provider_payment_method(self._get_code())
            // if not default_payment_method:
            //     return
            // 
            // pay_method_line = self.env['account.payment.method.line'].search([
            //     ('payment_provider_id', '=', self.id),
            //     ('journal_id', '!=', False),
            // ], limit=1)
            // 
            // if not self.journal_id:
            //     if pay_method_line:
            //         pay_method_line.unlink()
            //         return
            // 
            // if not pay_method_line:
            //     pay_method_line = self.env['account.payment.method.line'].search(
            //         [
            //             *self.env['account.payment.method.line']._check_company_domain(self.company_id),
            //             ('code', '=', self._get_code()),
            //             ('payment_provider_id', '=', False),
            //             ('journal_id', '!=', False),
            //         ],
            //         limit=1,
            //     )
            // if pay_method_line:
            //     pay_method_line.payment_provider_id = self
            //     pay_method_line.journal_id = self.journal_id
            //     pay_method_line.name = self.name
            // elif allow_create:
            //     create_values = {
            //         'name': self.name,
            //         'payment_method_id': default_payment_method.id,
            //         'journal_id': self.journal_id.id,
            //         'payment_provider_id': self.id,
            //         'payment_account_id': self._get_payment_method_outstanding_account_id(default_payment_method)
            //     }
            //     pay_method_line_same_code = self.env['account.payment.method.line'].search(
            //         [
            //             *self.env['account.payment.method.line']._check_company_domain(self.company_id),
            //             ('code', '=', self._get_code()),
            //         ],
            //         limit=1,
            //     )
            //     if pay_method_line_same_code:
            //         create_values['payment_account_id'] = pay_method_line_same_code.payment_account_id.id
            //     self.env['account.payment.method.line'].create(create_values)
            */
            return default;
        }

        protected async Task<PaymentProvider> FlutterwaveMakeRequestInternalAsync(object endpoint, object payload, object method)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py) ---
            // def _flutterwave_make_request(self, endpoint, payload=None, method='POST'):
            // """ Make a request to Flutterwave API at the specified endpoint.
            // 
            // Note: self.ensure_one()
            // 
            // :param str endpoint: The endpoint to be reached by the request.
            // :param dict payload: The payload of the request.
            // :param str method: The HTTP method of the request.
            // :return The JSON-formatted content of the response.
            // :rtype: dict
            // :raise ValidationError: If an HTTP error occurs.
            // """
            // self.ensure_one()
            // 
            // url = url_join('https://api.flutterwave.com/v3/', endpoint)
            // headers = {'Authorization': f'Bearer {self.flutterwave_secret_key}'}
            // try:
            //     if method == 'GET':
            //         response = requests.get(url, params=payload, headers=headers, timeout=10)
            //     else:
            //         response = requests.post(url, json=payload, headers=headers, timeout=10)
            //     try:
            //         response.raise_for_status()
            //     except requests.exceptions.HTTPError:
            //         _logger.exception(
            //             "Invalid API request at %s with data:\n%s", url, pprint.pformat(payload),
            //         )
            //         raise ValidationError("Flutterwave: " + _(
            //             "The communication with the API failed. Flutterwave gave us the following "
            //             "information: '%s'", response.json().get('message', '')
            //         ))
            // except (requests.exceptions.ConnectionError, requests.exceptions.Timeout):
            //     _logger.exception("Unable to reach endpoint at %s", url)
            //     raise ValidationError(
            //         "Flutterwave: " + _("Could not establish the connection to the API.")
            //     )
            // return response.json()
            */
            return default;
        }

        public async Task<PaymentProvider> GetBaseUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_payment, FILE: payment_provider.py) ---
            // def get_base_url(self):
            // # Give priority to url_root to handle multi-website cases
            // if request and request.httprequest.url_root:
            //     # Some domain names can use non-Latin script or alphabet or the Latin
            //     # alphabet-based characters with diacritics or ligatures. They are
            //     # stored as ASCII strings using Punycode transcription in the DNS
            //     # system and need to be converted to send to external APIs.
            //     return iri_to_uri(request.httprequest.url_root)
            // return super().get_base_url()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> GetCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_code(self):
            // """ Return the code of the provider.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The code of the provider.
            // :rtype: str
            // """
            // self.ensure_one()
            // return self.code
            */
            return default;
        }

        protected async Task<PaymentProvider> GetCompatibleProvidersInternalAsync(Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_compatible_providers(
            //     self, company_id, partner_id, amount, currency_id=None, force_tokenization=False,
            //     is_express_checkout=False, is_validation=False, report=None, **kwargs
            // ):
            //     """ Search and return the providers matching the compatibility criteria.
            // 
            //     The compatibility criteria are that providers must: not be disabled; be in the company that
            //     is provided; support the country of the partner if it exists; be compatible with the
            //     currency if provided. If provided, the optional keyword arguments further refine the
            //     criteria.
            // 
            //     :param int company_id: The company to which providers must belong, as a `res.company` id.
            //     :param int partner_id: The partner making the payment, as a `res.partner` id.
            //     :param float amount: The amount to pay. `0` for validation transactions.
            //     :param int currency_id: The payment currency, if known beforehand, as a `res.currency` id.
            //     :param bool force_tokenization: Whether only providers allowing tokenization can be matched.
            //     :param bool is_express_checkout: Whether the payment is made through express checkout.
            //     :param bool is_validation: Whether the operation is a validation.
            //     :param dict report: The report in which each provider's availability status and reason must
            //                         be logged.
            //     :param dict kwargs: Optional data. This parameter is not used here.
            //     :return: The compatible providers.
            //     :rtype: payment.provider
            //     """
            //     # Search compatible providers with the base domain.
            //     providers = self.env['payment.provider'].search([
            //         *self.env['payment.provider']._check_company_domain(company_id),
            //         ('state', 'in', ['enabled', 'test']),
            //     ])
            //     payment_utils.add_to_report(report, providers)
            // 
            //     # Filter by `is_published` state.
            //     if not self.env.user._is_internal():
            //         providers = providers.filtered('is_published')
            // 
            //     # Handle the partner country; allow all countries if the list is empty.
            //     partner = self.env['res.partner'].browse(partner_id)
            //     if partner.country_id:  # The partner country must either not be set or be supported.
            //         unfiltered_providers = providers
            //         providers = providers.filtered(
            //             lambda p: (
            //                 not p.available_country_ids
            //                 or partner.country_id.id in p.available_country_ids.ids
            //             )
            //         )
            //         payment_utils.add_to_report(
            //             report,
            //             unfiltered_providers - providers,
            //             available=False,
            //             reason=REPORT_REASONS_MAPPING['incompatible_country'],
            //         )
            // 
            //     # Handle the maximum amount.
            //     currency = self.env['res.currency'].browse(currency_id).exists()
            //     if not is_validation and currency:  # The currency is required to convert the amount.
            //         company = self.env['res.company'].browse(company_id).exists()
            //         date = fields.Date.context_today(self)
            //         converted_amount = currency._convert(amount, company.currency_id, company, date)
            //         unfiltered_providers = providers
            //         providers = providers.filtered(
            //             lambda p: (
            //                 not p.maximum_amount
            //                 or currency.compare_amounts(p.maximum_amount, converted_amount) != -1
            //             )
            //         )
            //         payment_utils.add_to_report(
            //             report,
            //             unfiltered_providers - providers,
            //             available=False,
            //             reason=REPORT_REASONS_MAPPING['exceed_max_amount'],
            //         )
            // 
            //     # Handle the available currencies; allow all currencies if the list is empty.
            //     if currency:
            //         unfiltered_providers = providers
            //         providers = providers.filtered(
            //             lambda p: (
            //                 not p.available_currency_ids
            //                 or currency.id in p.available_currency_ids.ids
            //             )
            //         )
            //         payment_utils.add_to_report(
            //             report,
            //             unfiltered_providers - providers,
            //             available=False,
            //             reason=REPORT_REASONS_MAPPING['incompatible_currency'],
            //         )
            // 
            //     # Handle tokenization support requirements.
            //     if force_tokenization or self._is_tokenization_required(**kwargs):
            //         unfiltered_providers = providers
            //         providers = providers.filtered('allow_tokenization')
            //         payment_utils.add_to_report(
            //             report,
            //             unfiltered_providers - providers,
            //             available=False,
            //             reason=REPORT_REASONS_MAPPING['tokenization_not_supported'],
            //         )
            // 
            //     # Handle express checkout.
            //     if is_express_checkout:
            //         unfiltered_providers = providers
            //         providers = providers.filtered('allow_express_checkout')
            //         payment_utils.add_to_report(
            //             report,
            //             unfiltered_providers - providers,
            //             available=False,
            //             reason=REPORT_REASONS_MAPPING['express_checkout_not_supported'],
            //         )
            // 
            //     return providers
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py) ---
            // def _get_compatible_providers(self, *args, is_validation=False, report=None, **kwargs):
            // """ Override of `payment` to filter out Flutterwave providers for validation operations. """
            // providers = super()._get_compatible_providers(
            //     *args, is_validation=is_validation, report=report, **kwargs
            // )
            // 
            // if is_validation:
            //     unfiltered_providers = providers
            //     providers = providers.filtered(lambda p: p.code != 'flutterwave')
            //     payment_utils.add_to_report(
            //         report,
            //         unfiltered_providers - providers,
            //         available=False,
            //         reason=REPORT_REASONS_MAPPING['validation_not_supported'],
            //     )
            // 
            // return providers
            --- ODOO METHOD SOURCE (MODULE: website_payment, FILE: payment_provider.py) ---
            // def _get_compatible_providers(self, *args, website_id=None, report=None, **kwargs):
            // """ Override of `payment` to only return providers matching website-specific criteria.
            // 
            // In addition to the base criteria, the website must either not be set or be the same as the
            // one provided in the kwargs.
            // 
            // :param int website_id: The provided website, as a `website` id.
            // :param dict report: The availability report.
            // :return: The compatible providers.
            // :rtype: payment.provider
            // """
            // providers = super()._get_compatible_providers(
            //     *args, website_id=website_id, report=report, **kwargs
            // )
            // if website_id:
            //     unfiltered_providers = providers
            //     providers = providers.filtered(
            //         lambda p: not p.website_id or p.website_id.id == website_id
            //     )
            //     payment_utils.add_to_report(
            //         report,
            //         unfiltered_providers - providers,
            //         available=False,
            //         reason=REPORT_REASONS_MAPPING['incompatible_website'],
            //     )
            // return providers
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: payment_provider.py) ---
            // def _get_compatible_providers(
            //     self, company_id, *args, sale_order_id=None, website_id=None, report=None, **kwargs
            // ):
            //     """ Override of payment to exclude on-site payment providers if the delivery method is not
            //     pick up in store.
            // 
            //     :param int company_id: The company to which providers must belong, as a `res.company` id
            //     :param int sale_order_id: The sale order to be paid, if any, as a `sale.order` id
            //     :param int website_id: The provided website, as a `website` id
            //     :param dict report: The availability report.
            //     :return: The compatible providers
            //     :rtype: recordset of `payment.provider`
            //     """
            //     compatible_providers = super()._get_compatible_providers(
            //         company_id,
            //         *args,
            //         sale_order_id=sale_order_id,
            //         website_id=website_id,
            //         report=report,
            //         **kwargs,
            //     )
            //     order = self.env['sale.order'].browse(sale_order_id).exists()
            // 
            //     # Show on-site payment providers only if in-store delivery methods exist and the order
            //     # contains physical products.
            //     if order.carrier_id.delivery_type != 'in_store' or not any(
            //         product.type == 'consu' for product in order.order_line.product_id
            //     ):
            //         unfiltered_providers = compatible_providers
            //         compatible_providers = compatible_providers.filtered(
            //             lambda p: p.code != 'custom' or p.custom_mode != 'on_site'
            //         )
            //         payment_utils.add_to_report(
            //             report,
            //             unfiltered_providers - compatible_providers,
            //             available=False,
            //             reason=_("no in-store delivery methods available"),
            //         )
            // 
            //     return compatible_providers
            */
            return default;
        }

        protected async Task<PaymentProvider> GetDefaultPaymentMethodCodesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Return the default payment methods for this provider.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The default payment method codes.
            // :rtype: set
            // """
            // self.ensure_one()
            // return set()
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'adyen':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'aps':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'asiapay':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'authorize':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'buckaroo':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'custom' or self.custom_mode != 'wire_transfer':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'demo':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'flutterwave':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'mercado_pago':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'mollie':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'nuvei':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'paypal':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'razorpay':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'stripe':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'worldline':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.code != 'xendit':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: payment_provider.py) ---
            // def _get_default_payment_method_codes(self):
            // """ Override of `payment` to return the default payment method codes. """
            // default_codes = super()._get_default_payment_method_codes()
            // if self.custom_mode != 'on_site':
            //     return default_codes
            // return const.DEFAULT_PAYMENT_METHOD_CODES
            */
            return default;
        }

        protected async Task<PaymentProvider> GetPaymentMethodOutstandingAccountIdInternalAsync(Guid payment_method_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py) ---
            // def _get_payment_method_outstanding_account_id(self, payment_method_id):
            // if self.code == 'custom':
            //     return False
            // account_ref = 'account_journal_payment_debit_account_id' if payment_method_id.payment_type == 'inbound' else 'account_journal_payment_credit_account_id'
            // chart_template = self.with_context(allowed_company_ids=self.company_id.root_id.ids).env['account.chart.template']
            // outstanding_account_id = (
            //     chart_template.ref(account_ref, raise_if_not_found=False)
            //     or self.company_id.transfer_account_id
            // ).id
            // return outstanding_account_id
            */
            return default;
        }

        protected async Task<PaymentProvider> GetProviderNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_provider_name(self):
            // """ Return the translated name of the provider.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The translated name of the provider.
            // :rtype: str
            // """
            // self.ensure_one()
            // return dict(self._fields['code']._description_selection(self.env))[self.code]
            */
            return default;
        }

        protected async Task<PaymentProvider> GetProviderPaymentMethodInternalAsync(object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py) ---
            // def _get_provider_payment_method(self, code):
            // return self.env['account.payment.method'].search([('code', '=', code)], limit=1)
            */
            return default;
        }

        protected async Task<PaymentProvider> GetRedirectFormViewInternalAsync(object is_validation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_redirect_form_view(self, is_validation=False):
            // """ Return the view of the template used to render the redirect form.
            // 
            // For a provider to return a different view depending on whether the operation is a
            // validation, it must override this method and return the appropriate view.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param bool is_validation: Whether the operation is a validation.
            // :return: The view of the redirect form template.
            // :rtype: record of `ir.ui.view`
            // """
            // self.ensure_one()
            // return self.redirect_form_view_id
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py) ---
            // def _get_redirect_form_view(self, is_validation=False):
            // """ Override of `payment` to avoid rendering the form view for validation operations.
            // 
            // Unlike other compatible payment methods in Xendit, `Card` is implemented using a direct
            // flow. To avoid rendering a useless template, and also to avoid computing wrong values, this
            // method returns `None` for Xendit's validation operations (Card is and will always be the
            // sole tokenizable payment method for Xendit).
            // 
            // Note: `self.ensure_one()`
            // 
            // :param bool is_validation: Whether the operation is a validation.
            // :return: The view of the redirect form template or None.
            // :rtype: ir.ui.view | None
            // """
            // self.ensure_one()
            // 
            // if self.code == 'xendit' and is_validation:
            //     return None
            // return super()._get_redirect_form_view(is_validation)
            */
            return default;
        }

        protected async Task<PaymentProvider> GetRemovalDomainInternalAsync(object provider_code, object custom_mode)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_removal_domain(self, provider_code, **kwargs):
            // return [('code', '=', provider_code)]
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py) ---
            // def _get_removal_domain(self, provider_code, custom_mode='', **kwargs):
            // res = super()._get_removal_domain(provider_code, custom_mode=custom_mode, **kwargs)
            // if provider_code == 'custom' and custom_mode:
            //     return AND([res, [('custom_mode', '=', custom_mode)]])
            // return res
            */
            return default;
        }

        protected async Task<PaymentProvider> GetRemovalValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_removal_values(self):
            // """ Return the values to update a provider with when its module is uninstalled.
            // 
            // For a module to specify additional removal values, it must override this method and complete
            // the generic values with its specific values.
            // 
            // :return: The removal values to update the removed provider with.
            // :rtype: dict
            // """
            // return {
            //     'code': 'none',
            //     'state': 'disabled',
            //     'is_published': False,
            //     'redirect_form_view_id': None,
            //     'inline_form_view_id': None,
            //     'token_inline_form_view_id': None,
            //     'express_checkout_form_view_id': None,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py) ---
            // def _get_removal_values(self):
            // """ Override of `payment` to nullify the `custom_mode` field. """
            // res = super()._get_removal_values()
            // res['custom_mode'] = None
            // return res
            */
            return default;
        }

        protected async Task<PaymentProvider> GetStripeExtraRequestHeadersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _get_stripe_extra_request_headers(self):
            // """ Return the extra headers for the Stripe API request.
            // 
            // Note: This method serves as a hook for modules that would fully implement Stripe Connect.
            // 
            // :return: The extra request headers.
            // :rtype: dict
            // """
            // return {}
            */
            return default;
        }

        protected async Task<PaymentProvider> GetStripeWebhookUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _get_stripe_webhook_url(self):
            // return url_join(self.get_base_url(), StripeController._webhook_url)
            */
            return default;
        }

        protected async Task<PaymentProvider> GetSupportedCurrenciesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_supported_currencies(self):
            // """ Return the supported currencies for the payment provider.
            // 
            // By default, all currencies are considered supported, including the inactive ones. For a
            // provider to filter out specific currencies, it must override this method and return the
            // subset of supported currencies.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The supported currencies.
            // :rtype: res.currency
            // """
            // self.ensure_one()
            // return self.env['res.currency'].with_context(active_test=False).search([])
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_provider.py) ---
            // def _get_supported_currencies(self):
            // """ Override of `payment` to return the supported currencies. """
            // supported_currencies = super()._get_supported_currencies()
            // if self.code == 'buckaroo':
            //     supported_currencies = supported_currencies.filtered(
            //         lambda c: c.name in const.SUPPORTED_CURRENCIES
            //     )
            // return supported_currencies
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_provider.py) ---
            // def _get_supported_currencies(self):
            // """ Override of `payment` to return the supported currencies. """
            // supported_currencies = super()._get_supported_currencies()
            // if self.code == 'flutterwave':
            //     supported_currencies = supported_currencies.filtered(
            //         lambda c: c.name in const.SUPPORTED_CURRENCIES
            //     )
            // return supported_currencies
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py) ---
            // def _get_supported_currencies(self):
            // """ Override of `payment` to return the supported currencies. """
            // supported_currencies = super()._get_supported_currencies()
            // if self.code == 'mercado_pago':
            //     supported_currencies = supported_currencies.filtered(
            //         lambda c: c.name in const.SUPPORTED_CURRENCIES
            //     )
            // return supported_currencies
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_provider.py) ---
            // def _get_supported_currencies(self):
            // """ Override of `payment` to return the supported currencies. """
            // supported_currencies = super()._get_supported_currencies()
            // if self.code == 'mollie':
            //     supported_currencies = supported_currencies.filtered(
            //         lambda c: c.name in const.SUPPORTED_CURRENCIES
            //     )
            // return supported_currencies
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_provider.py) ---
            // def _get_supported_currencies(self):
            // """ Override of `payment` to return the supported currencies. """
            // supported_currencies = super()._get_supported_currencies()
            // if self.code == 'nuvei':
            //     supported_currencies = supported_currencies.filtered(
            //         lambda c: c.name in const.SUPPORTED_CURRENCIES
            //     )
            // return supported_currencies
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py) ---
            // def _get_supported_currencies(self):
            // """ Override of `payment` to return the supported currencies. """
            // supported_currencies = super()._get_supported_currencies()
            // if self.code == 'paypal':
            //     supported_currencies = supported_currencies.filtered(
            //         lambda c: c.name in const.SUPPORTED_CURRENCIES
            //     )
            // return supported_currencies
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py) ---
            // def _get_supported_currencies(self):
            // """ Override of `payment` to return the supported currencies. """
            // supported_currencies = super()._get_supported_currencies()
            // if self.code == 'razorpay':
            //     supported_currencies = supported_currencies.filtered(
            //         lambda c: c.name in const.SUPPORTED_CURRENCIES
            //     )
            // return supported_currencies
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py) ---
            // def _get_supported_currencies(self):
            // """ Override of `payment` to return the supported currencies. """
            // supported_currencies = super()._get_supported_currencies()
            // if self.code == 'xendit':
            //     supported_currencies = supported_currencies.filtered(
            //         lambda c: c.name in const.SUPPORTED_CURRENCIES
            //     )
            // return supported_currencies
            */
            return default;
        }

        protected async Task<PaymentProvider> GetValidationAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_validation_amount(self):
            // """ Return the amount to use for validation operations.
            // 
            // For a provider to support tokenization, it must override this method and return the
            // validation amount. If it is `0`, it is not necessary to create the override.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The validation amount.
            // :rtype: float
            // """
            // self.ensure_one()
            // return 0.0
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py) ---
            // def _get_validation_amount(self):
            // """ Override of payment to return the amount for Authorize.Net validation operations.
            // 
            // :return: The validation amount
            // :rtype: float
            // """
            // res = super()._get_validation_amount()
            // if self.code != 'authorize':
            //     return res
            // 
            // return 0.01
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py) ---
            // def _get_validation_amount(self):
            // """ Override of `payment` to return the amount for Razorpay validation operations.
            // 
            // :return: The validation amount.
            // :rtype: float
            // """
            // res = super()._get_validation_amount()
            // if self.code != 'razorpay':
            //     return res
            // 
            // return 1.0
            */
            return default;
        }

        protected async Task<PaymentProvider> GetValidationCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _get_validation_currency(self):
            // """ Return the currency to use for validation operations.
            // 
            // The validation currency must be supported by both the provider and the payment method. If
            // the payment method is not passed, only the provider's supported currencies are considered.
            // If no suitable currency is found, the provider's company's currency is returned instead.
            // 
            // For a provider to support tokenization and specify a different validation currency, it must
            // override this method and return the appropriate validation currency.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The validation currency.
            // :rtype: recordset of `res.currency`
            // """
            // self.ensure_one()
            // 
            // # Find the validation currency at the intersection of the provider's and payment method's
            // # supported currencies. An empty recordset means that all currencies are supported.
            // provider_currencies = self.available_currency_ids
            // pm = self.env.context.get('validation_pm')
            // pm_currencies = self.env['res.currency'] if not pm else pm.supported_currency_ids
            // validation_currency = None
            // if provider_currencies and pm_currencies:
            //     validation_currency = (provider_currencies & pm_currencies)[:1]
            // elif provider_currencies and not pm_currencies:
            //     validation_currency = provider_currencies[:1]
            // elif not provider_currencies and pm_currencies:
            //     validation_currency = pm_currencies[:1]
            // if not validation_currency:  # All currencies are supported, or no suitable one was found.
            //     validation_currency = self.company_id.currency_id
            // return validation_currency
            */
            return default;
        }

        protected async Task<PaymentProvider> InverseJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py) ---
            // def _inverse_journal_id(self):
            // for provider in self:
            //     provider._ensure_payment_method_line()
            */
            return default;
        }

        protected async Task<PaymentProvider> IsTokenizationRequiredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _is_tokenization_required(self, **kwargs):
            // """ Return whether tokenizing the transaction is required given its context.
            // 
            // For a module to make the tokenization required based on the payment context, it must
            // override this method and return whether it is required.
            // 
            // :param dict kwargs: The payment context. This parameter is not used here.
            // :return: Whether tokenizing the transaction is required.
            // :rtype: bool
            // """
            // return False
            */
            return default;
        }

        protected async Task<PaymentProvider> LimitAvailableCurrencyIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_provider.py) ---
            // def _limit_available_currency_ids(self):
            // allowed_codes = set(const.CURRENCY_MAPPING.keys())
            // for provider in self.filtered(lambda p: p.code == 'asiapay'):
            //     if len(provider.available_currency_ids) > 1 and provider.state != 'disabled':
            //         raise ValidationError(_("Only one currency can be selected by AsiaPay account."))
            // 
            //     unsupported_currency_codes = [
            //         currency.name
            //         for currency in provider.available_currency_ids
            //         if currency.name not in allowed_codes
            //     ]
            //     if provider.available_currency_ids.filtered(lambda c: c.name not in allowed_codes):
            //         raise ValidationError(_(
            //             "AsiaPay does not support the following currencies: %(currencies)s.",
            //             currencies=", ".join(unsupported_currency_codes),
            //         ))
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py) ---
            // def _limit_available_currency_ids(self):
            // for provider in self.filtered(lambda p: p.code == 'authorize'):
            //     if len(provider.available_currency_ids) > 1 and provider.state != 'disabled':
            //         raise ValidationError(
            //             _("Only one currency can be selected by Authorize.Net account.")
            //         )
            */
            return default;
        }

        protected async Task<PaymentProvider> MercadoPagoMakeRequestInternalAsync(object endpoint, object payload, object method)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py) ---
            // def _mercado_pago_make_request(self, endpoint, payload=None, method='POST'):
            // """ Make a request to Mercado Pago API at the specified endpoint.
            // 
            // Note: self.ensure_one()
            // 
            // :param str endpoint: The endpoint to be reached by the request.
            // :param dict payload: The payload of the request.
            // :param str method: The HTTP method of the request.
            // :return The JSON-formatted content of the response.
            // :rtype: dict
            // :raise ValidationError: If an HTTP error occurs.
            // """
            // self.ensure_one()
            // 
            // url = urls.url_join('https://api.mercadopago.com', endpoint)
            // headers = {
            //     'Authorization': f'Bearer {self.mercado_pago_access_token}',
            //     'X-Platform-Id': 'dev_cdf1cfac242111ef9fdebe8d845d0987',
            // }
            // try:
            //     if method == 'GET':
            //         response = requests.get(url, params=payload, headers=headers, timeout=10)
            //     else:
            //         response = requests.post(url, json=payload, headers=headers, timeout=10)
            //         try:
            //             response.raise_for_status()
            //         except requests.exceptions.HTTPError:
            //             _logger.exception(
            //                 "Invalid API request at %s with data:\n%s", url, pprint.pformat(payload),
            //             )
            //             try:
            //                 response_content = response.json()
            //                 error_code = response_content.get('error')
            //                 error_message = response_content.get('message')
            //                 raise ValidationError("Mercado Pago: " + _(
            //                     "The communication with the API failed. Mercado Pago gave us the"
            //                     " following information: '%(error_message)s' (code %(error_code)s)",
            //                     error_message=error_message, error_code=error_code,
            //                 ))
            //             except ValueError:  # The response can be empty when the access token is wrong.
            //                 raise ValidationError("Mercado Pago: " + _(
            //                     "The communication with the API failed. The response is empty. Please"
            //                     " verify your access token."
            //                 ))
            // except (requests.exceptions.ConnectionError, requests.exceptions.Timeout):
            //     _logger.exception("Unable to reach endpoint at %s", url)
            //     raise ValidationError(
            //         "Mercado Pago: " + _("Could not establish the connection to the API.")
            //     )
            // return response.json()
            */
            return default;
        }

        protected async Task<PaymentProvider> MollieMakeRequestInternalAsync(object endpoint, object data, object method)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_provider.py) ---
            // def _mollie_make_request(self, endpoint, data=None, method='POST'):
            // """ Make a request at mollie endpoint.
            // 
            // Note: self.ensure_one()
            // 
            // :param str endpoint: The endpoint to be reached by the request
            // :param dict data: The payload of the request
            // :param str method: The HTTP method of the request
            // :return The JSON-formatted content of the response
            // :rtype: dict
            // :raise: ValidationError if an HTTP error occurs
            // """
            // self.ensure_one()
            // endpoint = f'/v2/{endpoint.strip("/")}'
            // url = urls.url_join('https://api.mollie.com/', endpoint)
            // 
            // odoo_version = service.common.exp_version()['server_version']
            // module_version = self.env.ref('base.module_payment_mollie').installed_version
            // headers = {
            //     "Accept": "application/json",
            //     "Authorization": f'Bearer {self.mollie_api_key}',
            //     "Content-Type": "application/json",
            //     # See https://docs.mollie.com/integration-partners/user-agent-strings
            //     "User-Agent": f'Odoo/{odoo_version} MollieNativeOdoo/{module_version}',
            // }
            // 
            // try:
            //     response = requests.request(method, url, json=data, headers=headers, timeout=60)
            //     try:
            //         response.raise_for_status()
            //     except requests.exceptions.HTTPError:
            //         _logger.exception(
            //             "Invalid API request at %s with data:\n%s", url, pprint.pformat(data)
            //         )
            //         raise ValidationError(
            //             "Mollie: " + _(
            //                 "The communication with the API failed. Mollie gave us the following "
            //                 "information: %s", response.json().get('detail', '')
            //             ))
            // except (requests.exceptions.ConnectionError, requests.exceptions.Timeout):
            //     _logger.exception("Unable to reach endpoint at %s", url)
            //     raise ValidationError(
            //         "Mollie: " + _("Could not establish the connection to the API.")
            //     )
            // return response.json()
            */
            return default;
        }

        protected async Task<PaymentProvider> NuveiCalculateSignatureInternalAsync(object data, object incoming)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_provider.py) ---
            // def _nuvei_calculate_signature(self, data, incoming=True):
            // """ Compute the signature for the provided data according to the Nuvei documentation.
            // 
            // :param dict data: The data to sign.
            // :param bool incoming: If the signature must be generated for an incoming (Nuvei to Odoo) or
            //                       outgoing (Odoo to Nuvei) communication.
            // :return: The calculated signature.
            // :rtype: str
            // """
            // self.ensure_one()
            // signature_keys = const.SIGNATURE_KEYS if incoming else data.keys()
            // sign_data = ''.join([str(data.get(k, '')) for k in signature_keys])
            // key = self.nuvei_secret_key
            // signing_string = f'{key}{sign_data}'
            // return hashlib.sha256(signing_string.encode()).hexdigest()
            */
            return default;
        }

        protected async Task<PaymentProvider> NuveiGetApiUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_provider.py) ---
            // def _nuvei_get_api_url(self):
            // if self.state == 'enabled':
            //     return 'https://secure.safecharge.com/ppp/purchase.do'
            // else:  # 'test'
            //     return 'https://ppp-test.safecharge.com/ppp/purchase.do'
            */
            return default;
        }

        protected async Task<PaymentProvider> OnchangeCompanyBlockIfExistingTransactionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _onchange_company_block_if_existing_transactions(self):
            // """ Raise a user error when the company is changed and linked transactions exist.
            // 
            // :return: None
            // :raise UserError: If transactions are linked to the provider.
            // """
            // if self._origin.company_id != self.company_id and self.env['payment.transaction'].search_count(
            //     [('provider_id', '=', self._origin.id)], limit=1
            // ):
            //     raise UserError(_(
            //         "You cannot change the company of a payment provider with existing transactions."
            //     ))
            */
            return default;
        }

        protected async Task<PaymentProvider> OnchangeStateSwitchIsPublishedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _onchange_state_switch_is_published(self):
            // """ Automatically publish or unpublish the provider depending on its state.
            // 
            // :return: None
            // """
            // self.is_published = self.state == 'enabled'
            */
            return default;
        }

        protected async Task<PaymentProvider> OnchangeStateWarnBeforeDisablingTokensInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _onchange_state_warn_before_disabling_tokens(self):
            // """ Display a warning about the consequences of disabling a provider.
            // 
            // Let the user know that tokens related to a provider get archived if it is disabled or if its
            // state is changed from 'test' to 'enabled', and vice versa.
            // 
            // :return: A client action with the warning message, if any.
            // :rtype: dict
            // """
            // if self._origin.state in ('test', 'enabled') and self._origin.state != self.state:
            //     related_tokens = self.env['payment.token'].search(
            //         [('provider_id', '=', self._origin.id)]
            //     )
            //     if related_tokens:
            //         return {
            //             'warning': {
            //                 'title': _("Warning"),
            //                 'message': _(
            //                     "This action will also archive %s tokens that are registered with this "
            //                     "provider. ", len(related_tokens)
            //                 )
            //             }
            //         }
            */
            return default;
        }

        public async Task<PaymentProvider> PaypalCreateWebhookAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py) ---
            // def action_paypal_create_webhook(self):
            // """ Create a new webhook.
            // 
            // Note: This action only works for instances using a public URL.
            // 
            // :return: None
            // :raise UserError: If the base URL is not in HTTPS.
            // """
            // base_url = self.get_base_url()
            // if 'localhost' in base_url:
            //     raise UserError(
            //         "PayPal: " + _("You must have an HTTPS connection to generate a webhook.")
            //     )
            // data = {
            //     'url': urls.url_join(base_url, PaypalController._webhook_url),
            //     'event_types': [{'name': event_type} for event_type in const.HANDLED_WEBHOOK_EVENTS]
            // }
            // webhook_data = self._paypal_make_request('/v1/notifications/webhooks', json_payload=data)
            // self.paypal_webhook_id = webhook_data.get('id')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> PaypalFetchAccessTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py) ---
            // def _paypal_fetch_access_token(self):
            // """ Generate a new access token if it's expired, otherwise return the existing access token.
            // 
            // :return: A valid access token.
            // :rtype: str
            // :raise ValidationError: If the access token can not be fetched.
            // """
            // if fields.Datetime.now() > self.paypal_access_token_expiry - timedelta(minutes=5):
            //     response_content = self._paypal_make_request(
            //         '/v1/oauth2/token',
            //         data={'grant_type': 'client_credentials'},
            //         auth=(self.paypal_client_id, self.paypal_client_secret),
            //         is_refresh_token_request=True,
            //     )
            //     access_token = response_content['access_token']
            //     if not access_token:
            //         raise ValidationError("PayPal: " + _("Could not generate a new access token."))
            //     self.write({
            //         'paypal_access_token': access_token,
            //         'paypal_access_token_expiry': fields.Datetime.now() + timedelta(
            //             seconds=response_content['expires_in']
            //         ),
            //     })
            // return self.paypal_access_token
            */
            return default;
        }

        protected async Task<PaymentProvider> PaypalGetApiUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py) ---
            // def _paypal_get_api_url(self):
            // """ Return the API URL according to the provider state.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The API URL
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // if self.state == 'enabled':
            //     return 'https://api-m.paypal.com'
            // else:
            //     return 'https://api-m.sandbox.paypal.com'
            */
            return default;
        }

        protected async Task<PaymentProvider> PaypalGetInlineFormValuesInternalAsync(object currency)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py) ---
            // def _paypal_get_inline_form_values(self, currency=None):
            // """ Return a serialized JSON of the required values to render the inline form.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param res.currency currency: The transaction currency.
            // :return: The JSON serial of the required values to render the inline form.
            // :rtype: str
            // """
            // inline_form_values = {
            //     'provider_id': self.id,
            //     'client_id': self.paypal_client_id,
            //     'currency_code': currency and currency.name,
            // }
            // return json.dumps(inline_form_values)
            */
            return default;
        }

        protected async Task<PaymentProvider> PaypalMakeRequestInternalAsync(object endpoint, object data, object json_payload, object auth, object is_refresh_token_request, object idempotency_key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py) ---
            // def _paypal_make_request(
            //     self, endpoint, data=None, json_payload=None, auth=None, is_refresh_token_request=False,
            //     idempotency_key=None,
            // ):
            //     """ Make a request to Paypal API at the specified endpoint.
            // 
            //     Note: self.ensure_one()
            // 
            //     :param str endpoint: The endpoint to be reached by the request.
            //     :param dict data: The string payload of the request.
            //     :param dict json_payload: The JSON-formatted payload of the request.
            //     :param tuple auth: The authentication data.
            //     :param bool is_refresh_token_request: Whether the request is for refreshing the access
            //                                           token.
            //     :param str idempotency_key: The idempotency key to pass in the request.
            //     :return: The JSON-formatted content of the response.
            //     :rtype: dict
            //     :raise ValidationError: If an HTTP error occurs.
            //     """
            //     url = self._paypal_get_api_url() + endpoint
            //     headers = {'Content-Type': 'application/json'}  # PayPal always wants JSON content-type.
            //     if idempotency_key:
            //         headers['PayPal-Request-Id'] = idempotency_key
            //     if not is_refresh_token_request:
            //         headers['Authorization'] = f'Bearer {self._paypal_fetch_access_token()}'
            //     try:
            //         response = requests.post(
            //             url, headers=headers, data=data, json=json_payload, auth=auth, timeout=10
            //         )
            //         try:
            //             response.raise_for_status()
            //         except requests.exceptions.HTTPError:
            //             payload = data or json_payload
            //             # PayPal errors https://developer.paypal.com/api/rest/reference/orders/v2/errors/
            //             _logger.exception(
            //                 "Invalid API request at %s with data:\n%s", url, pprint.pformat(payload)
            //             )
            //             msg = response.json().get('message', '')
            //             raise ValidationError(
            //                 "PayPal: " + _("The communication with the API failed. Details: %s", msg)
            //             )
            //     except (requests.exceptions.ConnectionError, requests.exceptions.Timeout):
            //         _logger.exception("Unable to reach endpoint at %s", url)
            //         raise ValidationError("PayPal: " + _("Could not establish the connection to the API."))
            //     return response.json()
            */
            return default;
        }

        protected async Task<PaymentProvider> RazorpayCalculateSignatureInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py) ---
            // def _razorpay_calculate_signature(self, data):
            // """ Compute the signature for the request's data according to the Razorpay documentation.
            // 
            // See https://razorpay.com/docs/webhooks/validate-test#validate-webhooks.
            // 
            // :param bytes data: The data to sign.
            // :return: The calculated signature.
            // :rtype: str
            // """
            // secret = self.razorpay_webhook_secret
            // if not secret:
            //     _logger.warning("Missing webhook secret; aborting signature calculation.")
            //     return None
            // return hmac.new(secret.encode(), msg=data, digestmod=hashlib.sha256).hexdigest()
            */
            return default;
        }

        public async Task<PaymentProvider> RazorpayCreateWebhookAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay_oauth, FILE: payment_provider.py) ---
            // def action_razorpay_create_webhook(self):
            // """ Create a webhook and display a toast notification.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The feedback notification.
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // webhook_secret = uuid.uuid4().hex  # Generate a random webhook secret.
            // payload = {
            //     'url': f'{self.get_base_url()}/payment/razorpay/webhook',
            //     'alert_email': self.env.user.partner_id.email,
            //     'secret': webhook_secret,
            //     'events': const.HANDLED_WEBHOOK_EVENTS,
            // }
            // _logger.info(
            //     "Sending '/accounts/%(account_id)s/webhooks' request:\n%(payload)s",
            //     {'account_id': self.razorpay_account_id, 'payload': pprint.pformat(payload)},
            // )
            // webhook_data = self.with_context(razorpay_api_version='v2')._razorpay_make_request(
            //     f'accounts/{self.razorpay_account_id}/webhooks', payload=payload
            // )
            // _logger.info(
            //     "Response of '/accounts/%(account_id)s/webhooks' request:\n%(response)s",
            //     {'account_id': self.razorpay_account_id, 'response': pprint.pformat(webhook_data)},
            // )
            // self.razorpay_webhook_secret = webhook_secret
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'message': _("Your Razorpay webhook was successfully set up!"),
            //         'next': {'type': 'ir.actions.client', 'tag': 'soft_reload'},
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> RazorpayGetAccessTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py) ---
            // def _razorpay_get_access_token(self):  # TODO: remove in master
            // self.ensure_one()
            // return None
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay_oauth, FILE: payment_provider.py) ---
            // def _razorpay_get_access_token(self):
            // self.ensure_one()
            // 
            // if self.razorpay_access_token and self.razorpay_access_token_expiry < fields.Datetime.now():
            //     self._razorpay_refresh_access_token()
            // return self.razorpay_access_token
            */
            return default;
        }

        protected async Task<PaymentProvider> RazorpayGetPublicTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py) ---
            // def _razorpay_get_public_token(self):  # TODO: remove in master
            // self.ensure_one()
            // return None
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay_oauth, FILE: payment_provider.py) ---
            // def _razorpay_get_public_token(self):
            // self.ensure_one()
            // 
            // return self.razorpay_public_token
            */
            return default;
        }

        protected async Task<PaymentProvider> RazorpayMakeProxyRequestInternalAsync(object endpoint, object payload)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay_oauth, FILE: payment_provider.py) ---
            // def _razorpay_make_proxy_request(self, endpoint, payload=None):
            // """ Make a request to the Razorpay proxy at the specified endpoint.
            // 
            // :param str endpoint: The proxy endpoint to be reached by the request; prefixed with '/'.
            // :param dict payload: The payload of the request.
            // :return The JSON-formatted content of the response.
            // :rtype: dict
            // :raise ValidationError: If an HTTP error occurs.
            // """
            // proxy_payload = {
            //     'jsonrpc': '2.0',
            //     'id': uuid.uuid4().hex,
            //     'method': 'call',
            //     'params': payload,
            // }
            // url = f'{oauth_const.OAUTH_URL}{endpoint}'
            // try:
            //     response = requests.post(url, json=proxy_payload, timeout=10)
            //     response.raise_for_status()
            // except (requests.exceptions.ConnectionError, requests.exceptions.Timeout):
            //     _logger.exception("Unable to reach endpoint at %s", url)
            //     raise ValidationError("Razorpay Proxy: " + _("Could not establish the connection."))
            // except requests.exceptions.HTTPError:
            //     _logger.exception(
            //         "Invalid API request at %s with data %s", url, pprint.pformat(payload)
            //     )
            //     raise ValidationError(
            //         "Razorpay Proxy: " + _("An error occurred when communicating with the proxy.")
            //     )
            // 
            // # Razorpay proxy endpoints always respond with HTTP 200 as they implement JSON-RPC 2.0.
            // response_content = response.json()
            // if response_content.get('error'):  # An exception was raised on the proxy side.
            //     error_message = response_content['error']['data']['message']
            //     _logger.exception("Request forwarded with error: %s", error_message)
            //     raise ValidationError(f"Razorpay Proxy: {error_message}")
            // 
            // return response_content['result']
            */
            return default;
        }

        protected async Task<PaymentProvider> RazorpayMakeRequestInternalAsync(object endpoint, object payload, object method)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py) ---
            // def _razorpay_make_request(self, endpoint, payload=None, method='POST'):
            // """ Make a request to Razorpay API at the specified endpoint.
            // 
            // Note: self.ensure_one()
            // 
            // :param str endpoint: The endpoint to be reached by the request.
            // :param dict payload: The payload of the request.
            // :param str method: The HTTP method of the request.
            // :return The JSON-formatted content of the response.
            // :rtype: dict
            // :raise ValidationError: If an HTTP error occurs.
            // """
            // self.ensure_one()
            // 
            // # TODO: Make api_version a kwarg in master.
            // api_version = self.env.context.get('razorpay_api_version', 'v1')
            // url = f'https://api.razorpay.com/{api_version}/{endpoint}'
            // headers = None
            // if access_token := self._razorpay_get_access_token():
            //     headers = {'Authorization': f'Bearer {access_token}'}
            // auth = (self.razorpay_key_id, self.razorpay_key_secret) if self.razorpay_key_id else None
            // try:
            //     if method == 'GET':
            //         response = requests.get(
            //             url,
            //             params=payload,
            //             headers=headers,
            //             auth=auth,
            //             timeout=10,
            //         )
            //     else:
            //         response = requests.post(
            //             url,
            //             json=payload,
            //             headers=headers,
            //             auth=auth,
            //             timeout=10,
            //         )
            //     try:
            //         response.raise_for_status()
            //     except requests.exceptions.HTTPError:
            //         _logger.exception(
            //             "Invalid API request at %s with data:\n%s", url, pprint.pformat(payload),
            //         )
            //         raise ValidationError("Razorpay: " + _(
            //             "Razorpay gave us the following information: '%s'",
            //             response.json().get('error', {}).get('description')
            //         ))
            // except (requests.exceptions.ConnectionError, requests.exceptions.Timeout):
            //     _logger.exception("Unable to reach endpoint at %s", url)
            //     raise ValidationError(
            //         "Razorpay: " + _("Could not establish the connection to the API.")
            //     )
            // return response.json()
            */
            return default;
        }

        public async Task<PaymentProvider> RazorpayRedirectToOauthUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay_oauth, FILE: payment_provider.py) ---
            // def action_razorpay_redirect_to_oauth_url(self):
            // """ Redirect to the Razorpay OAuth URL.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: An URL action to redirect to the Razorpay OAuth URL.
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // if self.company_id.currency_id.name not in const.SUPPORTED_CURRENCIES:
            //     raise RedirectWarning(
            //         _(
            //             "Razorpay is not available in your country; please use another payment"
            //             " provider."
            //         ),
            //         self.env.ref('payment.action_payment_provider').id,
            //         _("Other Payment Providers"),
            //     )
            // 
            // params = {
            //     'return_url': f'{self.get_base_url()}{RazorpayController.OAUTH_RETURN_URL}',
            //     'provider_id': self.id,
            //     'csrf_token': request.csrf_token(),
            // }
            // authorization_url = f'{oauth_const.OAUTH_URL}/authorize?{urlencode(params)}'
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': authorization_url,
            //     'target': 'self',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> RazorpayRefreshAccessTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay_oauth, FILE: payment_provider.py) ---
            // def _razorpay_refresh_access_token(self):
            // """ Refresh the access token.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: dict
            // """
            // self.ensure_one()
            // 
            // response_content = self._razorpay_make_proxy_request(
            //     '/refresh_access_token', payload={'refresh_token': self.razorpay_refresh_token}
            // )
            // if response_content.get('access_token'):
            //     expiry = fields.Datetime.now() + timedelta(seconds=int(response_content['expires_in']))
            //     self.write({
            //         'razorpay_public_token': response_content['public_token'],
            //         'razorpay_refresh_token': response_content['refresh_token'],
            //         'razorpay_access_token': response_content['access_token'],
            //         'razorpay_access_token_expiry': expiry,
            //     })
            */
            return default;
        }

        public async Task<PaymentProvider> RazorpayResetOauthAccountAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay_oauth, FILE: payment_provider.py) ---
            // def action_razorpay_reset_oauth_account(self):
            // """ Reset the Razorpay OAuth account.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // """
            // self.ensure_one()
            // 
            // return self.write({
            //     'razorpay_account_id': None,
            //     'razorpay_public_token': None,
            //     'razorpay_refresh_token': None,
            //     'razorpay_access_token': None,
            //     'razorpay_access_token_expiry': None,
            //     'state': 'disabled',
            //     'is_published': False,
            // })
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PaymentProvider> RecomputePendingMsgAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py) ---
            // def action_recompute_pending_msg(self):
            // """ Recompute the pending message to include the existing bank accounts. """
            // account_payment_module = self.env['ir.module.module']._get('account_payment')
            // if account_payment_module.state == 'installed':
            //     for provider in self.filtered(lambda p: p.custom_mode == 'wire_transfer'):
            //         company_id = provider.company_id.id
            //         accounts = self.env['account.journal'].search([
            //             *self.env['account.journal']._check_company_domain(company_id),
            //             ('type', '=', 'bank'),
            //         ]).bank_account_id
            //         account_names = "".join(f"<li><pre>{account.display_name}</pre></li>" for account in accounts)
            //         provider.pending_msg = f'<div>' \
            //             f'<h5>{_("Please use the following transfer details")}</h5>' \
            //             f'<p><br></p>' \
            //             f'<h6>{_("Bank Account") if len(accounts) == 1 else _("Bank Accounts")}</h6>' \
            //             f'<ul>{account_names}</ul>'\
            //             f'<p><br></p>' \
            //             f'</div>'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> RemoveProviderInternalAsync(object provider_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py) ---
            // def _remove_provider(self, code, **kwargs):
            // """ Override of `payment` to delete the payment method of the provider. """
            // payment_method = self._get_provider_payment_method(code)
            // # If the payment method is used by any payments, we block the uninstallation of the module.
            // if self._check_existing_payment(payment_method):
            //     raise UserError(_("You cannot uninstall this module as payments using this payment method already exist."))
            // super()._remove_provider(code, **kwargs)
            // payment_method.unlink()
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _remove_provider(self, provider_code, **kwargs):
            // """ Remove the module-specific data of the given provider.
            // 
            // :param str provider_code: The code of the provider whose data to remove.
            // :return: None
            // """
            // providers = self.search(self._get_removal_domain(provider_code, **kwargs))
            // providers.write(self._get_removal_values())
            */
            return default;
        }

        protected async Task<PaymentProvider> SetupPaymentMethodInternalAsync(object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py) ---
            // def _setup_payment_method(self, code):
            // if code not in ('none', 'custom') and not self._get_provider_payment_method(code):
            //     providers_description = dict(self._fields['code']._description_selection(self.env))
            //     self.env['account.payment.method'].sudo().create({
            //         'name': providers_description[code],
            //         'code': code,
            //         'payment_type': 'inbound',
            //     })
            */
            return default;
        }

        protected async Task<PaymentProvider> SetupProviderInternalAsync(object provider_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_provider.py) ---
            // def _setup_provider(self, code):
            // """ Override of `payment` to create the payment method of the provider. """
            // super()._setup_provider(code)
            // self._setup_payment_method(code)
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _setup_provider(self, provider_code):
            // """ Perform module-specific setup steps for the provider.
            // 
            // This method is called after the module of a provider is installed, with its code passed as
            // `provider_code`.
            // 
            // :param str provider_code: The code of the provider to setup.
            // :return: None
            // """
            // return
            */
            return default;
        }

        protected async Task<PaymentProvider> ShouldBuildInlineFormInternalAsync(object is_validation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _should_build_inline_form(self, is_validation=False):
            // """ Return whether the inline payment form should be instantiated.
            // 
            // For a provider to handle both direct payments and payments with redirection, it must
            // override this method and return whether the inline payment form should be instantiated (i.e.
            // if the payment should be direct) based on the operation (online payment or validation).
            // 
            // :param bool is_validation: Whether the operation is a validation.
            // :return: Whether the inline form should be instantiated.
            // :rtype: bool
            // """
            // return True
            */
            return default;
        }

        public async Task<PaymentProvider> StripeConnectAccountAsync(Guid id, PaymentProviderStripeConnectAccountRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def action_stripe_connect_account(self, menu_id=None):
            // """ Create a Stripe Connect account and redirect the user to the next onboarding step.
            // 
            // If the provider is already enabled, close the current window. Otherwise, generate a Stripe
            // Connect onboarding link and redirect the user to it. If provided, the menu id is included in
            // the URL the user is redirected to when coming back on Odoo after the onboarding. If the link
            // generation failed, redirect the user to the provider form.
            // 
            // Note: This method serves as a hook for modules that would fully implement Stripe Connect.
            // Note: self.ensure_one()
            // 
            // :param int menu_id: The menu from which the user started the onboarding step, as an
            //                     `ir.ui.menu` id.
            // :return: The next step action
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // if self.env.company.country_id.code not in const.SUPPORTED_COUNTRIES:
            //     raise RedirectWarning(
            //         _(
            //             "Stripe Connect is not available in your country, please use another payment"
            //             " provider."
            //         ),
            //         self.env.ref('payment.action_payment_provider').id,
            //         _("Other Payment Providers"),
            //     )
            // 
            // if self.state == 'enabled':
            //     self.env['onboarding.onboarding.step'].action_validate_step_payment_provider()
            //     action = {'type': 'ir.actions.act_window_close'}
            // else:
            //     # Account creation
            //     connected_account = self._stripe_fetch_or_create_connected_account()
            // 
            //     # Link generation
            //     if not menu_id:
            //         # Fall back on `account_payment`'s menu if it is installed. If not, the user is
            //         # redirected to the provider's form view but without any menu in the breadcrumb.
            //         menu = self.env.ref('account_payment.payment_provider_menu', False)
            //         menu_id = menu and menu.id  # Only set if `account_payment` is installed.
            // 
            //     account_link_url = self._stripe_create_account_link(connected_account['id'], menu_id)
            //     if account_link_url:
            //         action = {
            //             'type': 'ir.actions.act_url',
            //             'url': account_link_url,
            //             'target': 'self',
            //         }
            //     else:
            //         action = {
            //             'type': 'ir.actions.act_window',
            //             'model': 'payment.provider',
            //             'views': [[False, 'form']],
            //             'res_id': self.id,
            //         }
            // 
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> StripeCreateAccountLinkInternalAsync(Guid connected_account_id, Guid menu_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_create_account_link(self, connected_account_id, menu_id):
            // """ Create an account link and return its URL.
            // 
            // An account link url is the beginning URL of Stripe Onboarding.
            // This URL is only valid once, and can only be used once.
            // 
            // Note: self.ensure_one()
            // 
            // :param str connected_account_id: The id of the connected account.
            // :param int menu_id: The menu from which the user started the onboarding step, as an
            //                     `ir.ui.menu` id
            // :return: The account link URL
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // base_url = self.company_id.get_base_url()
            // return_url = OnboardingController._onboarding_return_url
            // refresh_url = OnboardingController._onboarding_refresh_url
            // return_params = dict(provider_id=self.id, menu_id=menu_id)
            // refresh_params = dict(**return_params, account_id=connected_account_id)
            // 
            // account_link = self._stripe_make_proxy_request('account_links', payload={
            //     'account': connected_account_id,
            //     'return_url': f'{url_join(base_url, return_url)}?{url_encode(return_params)}',
            //     'refresh_url': f'{url_join(base_url, refresh_url)}?{url_encode(refresh_params)}',
            //     'type': 'account_onboarding',
            // })
            // return account_link['url']
            */
            return default;
        }

        public async Task<PaymentProvider> StripeCreateWebhookAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def action_stripe_create_webhook(self):
            // """ Create a webhook and return a feedback notification.
            // 
            // Note: This action only works for instances using a public URL
            // 
            // :return: The feedback notification
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // if self.stripe_webhook_secret:
            //     message = _("Your Stripe Webhook is already set up.")
            //     notification_type = 'warning'
            // elif not self.stripe_secret_key:
            //     message = _("You cannot create a Stripe Webhook if your Stripe Secret Key is not set.")
            //     notification_type = 'danger'
            // else:
            //     webhook = self._stripe_make_request(
            //         'webhook_endpoints', payload={
            //             'url': self._get_stripe_webhook_url(),
            //             'enabled_events[]': const.HANDLED_WEBHOOK_EVENTS,
            //             'api_version': const.API_VERSION,
            //         }
            //     )
            //     self.stripe_webhook_secret = webhook.get('secret')
            //     message = _("You Stripe Webhook was successfully set up!")
            //     notification_type = 'info'
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'message': message,
            //         'sticky': False,
            //         'type': notification_type,
            //         'next': {'type': 'ir.actions.act_window_close'},  # Refresh the form to show the key
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> StripeFetchOrCreateConnectedAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_fetch_or_create_connected_account(self):
            // """ Fetch the connected Stripe account and create one if not already done.
            // 
            // Note: This method serves as a hook for modules that would fully implement Stripe Connect.
            // 
            // :return: The connected account
            // :rtype: dict
            // """
            // return self._stripe_make_proxy_request(
            //     'accounts', payload=self._stripe_prepare_connect_account_payload()
            // )
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeGetCountryInternalAsync(object country_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_get_country(self, country_code):
            // """ Return the mapped country code of the company.
            // 
            // Businesses in supported outlying territories should register for a Stripe account with the
            // parent territory selected as the Country.
            // 
            // :param str country_code: The country code of the company.
            // :return: The mapped country code.
            // :rtype: str
            // """
            // return const.COUNTRY_MAPPING.get(country_code, country_code)
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeGetInlineFormValuesInternalAsync(object amount, object currency, Guid partner_id, object is_validation, object payment_method_sudo)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_get_inline_form_values(
            //     self, amount, currency, partner_id, is_validation, payment_method_sudo=None, **kwargs
            // ):
            //     """ Return a serialized JSON of the required values to render the inline form.
            // 
            //     Note: `self.ensure_one()`
            // 
            //     :param float amount: The amount in major units, to convert in minor units.
            //     :param res.currency currency: The currency of the transaction.
            //     :param int partner_id: The partner of the transaction, as a `res.partner` id.
            //     :param bool is_validation: Whether the operation is a validation.
            //     :param payment.method payment_method_sudo: The sudoed payment method record to which the
            //                                                inline form belongs.
            //     :return: The JSON serial of the required values to render the inline form.
            //     :rtype: str
            //     """
            //     self.ensure_one()
            // 
            //     if not is_validation:
            //         currency_name = currency and currency.name.lower()
            //     else:
            //         currency_name = self.with_context(
            //             validation_pm=payment_method_sudo  # Will be converted to a kwarg in master.
            //         )._get_validation_currency().name.lower()
            //     partner = self.env['res.partner'].with_context(show_address=1).browse(partner_id).exists()
            //     inline_form_values = {
            //         'publishable_key': self._stripe_get_publishable_key(),
            //         'currency_name': currency_name,
            //         'minor_amount': amount and payment_utils.to_minor_currency_units(amount, currency),
            //         'capture_method': 'manual' if self.capture_manually else 'automatic',
            //         'billing_details': {
            //             'name': partner.name or '',
            //             'email': partner.email or '',
            //             'phone': partner.phone or '',
            //             'address': {
            //                 'line1': partner.street or '',
            //                 'line2': partner.street2 or '',
            //                 'city': partner.city or '',
            //                 'state': partner.state_id.code or '',
            //                 'country': partner.country_id.code or '',
            //                 'postal_code': partner.zip or '',
            //             },
            //         },
            //         'is_tokenization_required': (
            //             self.allow_tokenization
            //             and self._is_tokenization_required(**kwargs)
            //             and payment_method_sudo.support_tokenization
            //         ),
            //         'payment_methods_mapping': const.PAYMENT_METHODS_MAPPING,
            //     }
            //     return json.dumps(inline_form_values)
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeGetPublishableKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_get_publishable_key(self):
            // """ Return the publishable key of the provider.
            // 
            // This getter allows fetching the publishable key from a QWeb template and through Stripe's
            // utils.
            // 
            // Note: `self.ensure_one()
            // 
            // :return: The publishable key.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // return stripe_utils.get_publishable_key(self.sudo())
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeHasConnectedAccountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_has_connected_account(self):
            // """ Return whether the provider is linked to a connected Stripe account.
            // 
            // Note: This method serves as a hook for modules that would fully implement Stripe Connect.
            // Note: self.ensure_one()
            // 
            // :return: Whether the provider is linked to a connected Stripe account
            // :rtype: bool
            // """
            // self.ensure_one()
            // return False
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeMakeProxyRequestInternalAsync(object endpoint, object payload, object version)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_make_proxy_request(self, endpoint, payload=None, version=1):
            // """ Make a request to the Stripe proxy at the specified endpoint.
            // 
            // :param str endpoint: The proxy endpoint to be reached by the request
            // :param dict payload: The payload of the request
            // :param int version: The proxy version used
            // :return The JSON-formatted content of the response
            // :rtype: dict
            // :raise: ValidationError if an HTTP error occurs
            // """
            // proxy_payload = {
            //     'jsonrpc': '2.0',
            //     'id': uuid.uuid4().hex,
            //     'method': 'call',
            //     'params': {
            //         'payload': payload,  # Stripe data.
            //         'proxy_data': self._stripe_prepare_proxy_data(stripe_payload=payload),
            //     },
            // }
            // url = url_join(const.PROXY_URL, f'{version}/{endpoint}')
            // try:
            //     response = requests.post(url=url, json=proxy_payload, timeout=60)
            //     response.raise_for_status()
            // except requests.exceptions.ConnectionError:
            //     _logger.exception("unable to reach endpoint at %s", url)
            //     raise ValidationError(_("Stripe Proxy: Could not establish the connection."))
            // except requests.exceptions.HTTPError:
            //     _logger.exception("invalid API request at %s with data %s", url, payload)
            //     raise ValidationError(
            //         _("Stripe Proxy: An error occurred when communicating with the proxy.")
            //     )
            // 
            // # Stripe proxy endpoints always respond with HTTP 200 as they implement JSON-RPC 2.0
            // response_content = response.json()
            // if response_content.get('error'):  # An exception was raised on the proxy
            //     error_data = response_content['error']['data']
            //     _logger.warning("request forwarded with error: %s", error_data['message'])
            //     raise ValidationError(_("Stripe Proxy error: %(error)s", error=error_data['message']))
            // 
            // return response_content.get('result', {})
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeMakeRequestInternalAsync(object endpoint, object payload, object method, object offline, object idempotency_key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_make_request(
            //     self, endpoint, payload=None, method='POST', offline=False, idempotency_key=None
            // ):
            //     """ Make a request to Stripe API at the specified endpoint.
            // 
            //     Note: self.ensure_one()
            // 
            //     :param str endpoint: The endpoint to be reached by the request
            //     :param dict payload: The payload of the request
            //     :param str method: The HTTP method of the request
            //     :param bool offline: Whether the operation of the transaction being processed is 'offline'
            //     :param str idempotency_key: The idempotency key to pass in the request.
            //     :return The JSON-formatted content of the response
            //     :rtype: dict
            //     :raise: ValidationError if an HTTP error occurs
            //     """
            //     self.ensure_one()
            // 
            //     url = url_join('https://api.stripe.com/v1/', endpoint)
            //     headers = {
            //         'AUTHORIZATION': f'Bearer {stripe_utils.get_secret_key(self)}',
            //         'Stripe-Version': const.API_VERSION,  # SetupIntent requires a specific version.
            //         **self._get_stripe_extra_request_headers(),
            //     }
            //     if method == 'POST' and idempotency_key:
            //         headers['Idempotency-Key'] = idempotency_key
            //     try:
            //         response = requests.request(method, url, data=payload, headers=headers, timeout=60)
            //         # Stripe can send 4XX errors for payment failures (not only for badly-formed requests).
            //         # Check if an error code is present in the response content and raise only if not.
            //         # See https://stripe.com/docs/error-codes.
            //         # If the request originates from an offline operation, don't raise to avoid a cursor
            //         # rollback and return the response as-is for flow-specific handling.
            //         if not response.ok \
            //                 and not offline \
            //                 and 400 <= response.status_code < 500 \
            //                 and response.json().get('error'):  # The 'code' entry is sometimes missing
            //             try:
            //                 response.raise_for_status()
            //             except requests.exceptions.HTTPError:
            //                 _logger.exception("invalid API request at %s with data %s", url, payload)
            //                 error_msg = response.json().get('error', {}).get('message', '')
            //                 raise ValidationError(
            //                     "Stripe: " + _(
            //                         "The communication with the API failed.\n"
            //                         "Stripe gave us the following info about the problem:\n'%s'", error_msg
            //                     )
            //                 )
            //     except requests.exceptions.ConnectionError:
            //         _logger.exception("unable to reach endpoint at %s", url)
            //         raise ValidationError("Stripe: " + _("Could not establish the connection to the API."))
            //     return response.json()
            */
            return default;
        }

        protected async Task<PaymentProvider> StripeOnboardingIsOngoingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_onboarding_is_ongoing(self):
            // """ Return whether the provider is linked to an ongoing onboarding to Stripe Connect.
            // 
            // Note: This method serves as a hook for modules that would fully implement Stripe Connect.
            // Note: self.ensure_one()
            // 
            // :return: Whether the provider is linked to an ongoing onboarding to Stripe Connect
            // :rtype: bool
            // """
            // self.ensure_one()
            // return False
            */
            return default;
        }

        protected async Task<PaymentProvider> StripePrepareConnectAccountPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_prepare_connect_account_payload(self):
            // """ Prepare the payload for the creation of a connected account in Stripe format.
            // 
            // Note: This method serves as a hook for modules that would fully implement Stripe Connect.
            // Note: self.ensure_one()
            // 
            // :return: The Stripe-formatted payload for the creation request
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // return {
            //     'type': 'standard',
            //     'country': self._stripe_get_country(self.company_id.country_id.code),
            //     'email': self.company_id.email,
            //     'business_type': 'company',
            //     'company[address][city]': self.company_id.city or '',
            //     'company[address][country]': self._stripe_get_country(self.company_id.country_id.code),
            //     'company[address][line1]': self.company_id.street or '',
            //     'company[address][line2]': self.company_id.street2 or '',
            //     'company[address][postal_code]': self.company_id.zip or '',
            //     'company[address][state]': self.company_id.state_id.name or '',
            //     'company[name]': self.company_id.name,
            //     'business_profile[name]': self.company_id.name,
            // }
            */
            return default;
        }

        protected async Task<PaymentProvider> StripePrepareProxyDataInternalAsync(object stripe_payload)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def _stripe_prepare_proxy_data(self, stripe_payload=None):
            // """ Prepare the contextual data passed to the proxy when making a request.
            // 
            // Note: This method serves as a hook for modules that would fully implement Stripe Connect.
            // Note: self.ensure_one()
            // 
            // :param dict stripe_payload: The part of the request payload to be forwarded to Stripe.
            // :return: The proxy data.
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // return {}
            */
            return default;
        }

        public async Task<PaymentProvider> StripeVerifyApplePayDomainAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py) ---
            // def action_stripe_verify_apple_pay_domain(self):
            // """ Verify the web domain with Stripe to enable Apple Pay.
            // 
            // The domain is sent to Stripe API for them to verify that it is valid by making a request to
            // the `/.well-known/apple-developer-merchantid-domain-association` route. If the domain is
            // valid, it is registered to use with Apple Pay.
            // See https://stripe.com/docs/stripe-js/elements/payment-request-button#verifying-your-domain-with-apple-pay.
            // 
            // :return dict: A client action with a success message.
            // :raise UserError: If test keys are used to make the request.
            // """
            // self.ensure_one()
            // 
            // web_domain = url_parse(self.get_base_url()).netloc
            // response_content = self._stripe_make_request('apple_pay/domains', payload={
            //     'domain_name': web_domain
            // })
            // if not response_content['livemode']:
            //     # If test keys are used to make the request, Stripe will respond with an HTTP 200 but
            //     # will not register the domain. Ask the user to use live credentials.
            //     raise UserError(_("Please use live credentials to enable Apple Pay."))
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'message': _("Your web domain was successfully verified."),
            //         'type': 'success',
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PaymentProvider> ToggleIsPublishedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def action_toggle_is_published(self):
            // """ Toggle the field `is_published`.
            // 
            // :return: None
            // :raise UserError: If the provider is disabled.
            // """
            // if self.state != 'disabled':
            //     self.is_published = not self.is_published
            // else:
            //     raise UserError(_("You cannot publish a disabled provider."))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> TogglePostProcessingCronInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _toggle_post_processing_cron(self):
            // """ Enable the post-processing cron if some providers are enabled; disable it otherwise.
            // 
            // This allows for saving resources on the cron's wake-up overhead when it has nothing to do.
            // 
            // :return: None
            // """
            // post_processing_cron = self.env.ref(
            //     'payment.cron_post_process_payment_tx', raise_if_not_found=False
            // )
            // if post_processing_cron:
            //     any_active_provider = bool(
            //         self.sudo().search_count([('state', '!=', 'disabled')], limit=1)
            //     )
            //     post_processing_cron.active = any_active_provider
            */
            return default;
        }

        protected async Task<PaymentProvider> TransferEnsurePendingMsgIsSetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py) ---
            // def _transfer_ensure_pending_msg_is_set(self):
            // transfer_providers_without_msg = self.filtered(
            //     lambda p: p.custom_mode == 'wire_transfer' and not p.pending_msg
            // )
            // if transfer_providers_without_msg:
            //     transfer_providers_without_msg.action_recompute_pending_msg()
            */
            return default;
        }

        protected async Task<PaymentProvider> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _unlink_except_master_data(self):
            // """ Prevent the deletion of the payment provider if it has an xmlid. """
            // external_ids = self.get_external_id()
            // for provider in self:
            //     external_id = external_ids[provider.id]
            //     if external_id and not external_id.startswith('__export__'):
            //         raise UserError(_(
            //             "You cannot delete the payment provider %s; disable it or uninstall it"
            //             " instead.", provider.name
            //         ))
            */
            return default;
        }

        public async Task<PaymentProvider> UpdateMerchantDetailsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py) ---
            // def action_update_merchant_details(self):
            // """ Fetch the merchant details to update the client key and the account currency. """
            // self.ensure_one()
            // 
            // if self.state == 'disabled':
            //     raise UserError(_("This action cannot be performed while the provider is disabled."))
            // 
            // authorize_API = AuthorizeAPI(self)
            // 
            // # Validate the API Login ID and Transaction Key
            // res_content = authorize_API.test_authenticate()
            // _logger.info("test_authenticate request response:\n%s", pprint.pformat(res_content))
            // if res_content.get('err_msg'):
            //     raise UserError(_("Failed to authenticate.\n%s", res_content['err_msg']))
            // 
            // # Update the merchant details
            // res_content = authorize_API.merchant_details()
            // _logger.info("merchant_details request response:\n%s", pprint.pformat(res_content))
            // if res_content.get('err_msg'):
            //     raise UserError(_("Could not fetch merchant details:\n%s", res_content['err_msg']))
            // 
            // currency = self.env['res.currency'].search([('name', 'in', res_content.get('currencies'))])
            // self.available_currency_ids = [Command.set(currency.ids)]
            // self.authorize_client_key = res_content.get('publicClientKey')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> ValidFieldParameterInternalAsync(object field, object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def _valid_field_parameter(self, field, name):
            // return name == 'required_if_provider' or super()._valid_field_parameter(field, name)
            */
            return default;
        }

        public async Task<PaymentProvider> ViewPaymentMethodsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def action_view_payment_methods(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Payment Methods"),
            //     'res_model': 'payment.method',
            //     'view_mode': 'list,kanban,form',
            //     'domain': [('id', 'in', self.with_context(active_test=False).payment_method_ids.ids)],
            //     'context': {'active_test': False, 'create': False},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentProvider> WorldlineCalculateSignatureInternalAsync(object method, object endpoint, object content_type, object dt_rfc, object idempotency_key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py) ---
            // def _worldline_calculate_signature(
            //     self, method, endpoint, content_type, dt_rfc, idempotency_key=None
            // ):
            //     """ Compute the signature for the provided data.
            // 
            //     See https://docs.direct.worldline-solutions.com/en/integration/api-developer-guide/authentication.
            // 
            //     :param str method: The HTTP method of the request
            //     :param str endpoint: The endpoint to be reached by the request.
            //     :param str content_type: The 'Content-Type' header of the request.
            //     :param datetime.datetime dt_rfc: The timestamp of the request, in RFC1123 format.
            //     :param str idempotency_key: The idempotency key to pass in the request.
            //     :return: The calculated signature.
            //     :rtype: str
            //     """
            //     # specific order required: method, content_type, date, custom headers, endpoint
            //     values_to_sign = [method, content_type, dt_rfc]
            //     if idempotency_key:
            //         values_to_sign.append(f'x-gcs-idempotence-key:{idempotency_key}')
            //     values_to_sign.append(f'/v2/{self.worldline_pspid}/{endpoint}')
            // 
            //     signing_str = '\n'.join(values_to_sign) + '\n'
            //     signature = hmac.new(
            //         self.worldline_api_secret.encode(), signing_str.encode(), hashlib.sha256
            //     )
            //     return base64.b64encode(signature.digest()).decode('utf-8')
            */
            return default;
        }

        protected async Task<PaymentProvider> WorldlineGetApiUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py) ---
            // def _worldline_get_api_url(self):
            // """ Return the URL of the API corresponding to the provider's state.
            // 
            // :return: The API URL.
            // :rtype: str
            // """
            // if self.state == 'enabled':
            //     return 'https://payment.direct.worldline-solutions.com'
            // else:  # 'test'
            //     return 'https://payment.preprod.direct.worldline-solutions.com'
            */
            return default;
        }

        protected async Task<PaymentProvider> WorldlineMakeRequestInternalAsync(object endpoint, object payload, object method, object idempotency_key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_provider.py) ---
            // def _worldline_make_request(self, endpoint, payload=None, method='POST', idempotency_key=None):
            // """ Make a request to Worldline API at the specified endpoint.
            // 
            // Note: self.ensure_one()
            // 
            // :param str endpoint: The endpoint to be reached by the request.
            // :param dict payload: The payload of the request.
            // :param str method: The HTTP method of the request.
            // :param str idempotency_key: The idempotency key to pass in the request.
            // :return: The JSON-formatted content of the response.
            // :rtype: dict
            // :raise ValidationError: If an HTTP error occurs.
            // """
            // self.ensure_one()
            // 
            // api_url = self._worldline_get_api_url()
            // url = f'{api_url}/v2/{self.worldline_pspid}/{endpoint}'
            // content_type = 'application/json; charset=utf-8' if method == 'POST' else ''
            // dt = format_date_time(Datetime.now().timestamp())  # Datetime in locale-independent RFC1123
            // signature = self._worldline_calculate_signature(
            //     method, endpoint, content_type, dt, idempotency_key=idempotency_key
            // )
            // authorization_header = f'GCS v1HMAC:{self.worldline_api_key}:{signature}'
            // headers = {
            //     'Authorization': authorization_header,
            //     'Date': dt,
            //     'Content-Type': content_type,
            // }
            // if method == 'POST' and idempotency_key:
            //     headers['X-GCS-Idempotence-Key'] = idempotency_key
            // try:
            //     response = requests.request(method, url, json=payload, headers=headers, timeout=10)
            //     try:
            //         if response.status_code not in const.VALID_RESPONSE_CODES:
            //             response.raise_for_status()
            //     except requests.exceptions.HTTPError:
            //         _logger.exception(
            //             "Invalid API request at %s with data:\n%s", url, pprint.pformat(payload)
            //         )
            //         msg = ', '.join(
            //             [error.get('message', '') for error in response.json().get('errors', [])]
            //         )
            //         raise ValidationError(
            //             "Worldline: " + _("The communication with the API failed. Details: %s", msg)
            //         )
            // except (requests.exceptions.ConnectionError, requests.exceptions.Timeout):
            //     _logger.exception("Unable to reach endpoint at %s", url)
            //     raise ValidationError(
            //         "Worldline: " + _("Could not establish the connection to the API.")
            //     )
            // return response.json()
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, PaymentProvider entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_provider.py) ---
            // def write(self, values):
            // # Handle provider state changes.
            // deactivated_providers = self.env['payment.provider']
            // activated_providers = self.env['payment.provider']
            // if 'state' in values:
            //     state_changed_providers = self.filtered(
            //         lambda p: p.state not in ('disabled', values['state'])
            //     )  # Don't handle providers being enabled or whose state is not updated.
            //     state_changed_providers._archive_linked_tokens()
            //     if values['state'] == 'disabled':
            //         deactivated_providers = state_changed_providers
            //     else:  # 'enabled' or 'test'
            //         activated_providers = self.filtered(lambda p: p.state == 'disabled')
            // 
            // result = super().write(values)
            // self._check_required_if_provider()
            // 
            // deactivated_providers._deactivate_unsupported_payment_methods()
            // activated_providers._activate_default_pms()
            // if activated_providers or deactivated_providers:
            //     self._toggle_post_processing_cron()
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py) ---
            // def write(self, values):
            // self._adyen_extract_prefix_from_api_url(values)
            // return super().write(values)
            */
            return await base.WriteAsync(ids, entity, fields);
        }

        protected async Task<PaymentProvider> XenditMakeRequestInternalAsync(object endpoint, object payload)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_provider.py) ---
            // def _xendit_make_request(self, endpoint, payload=None):
            // """ Make a request to Xendit API and return the JSON-formatted content of the response.
            // 
            // Note: self.ensure_one()
            // 
            // :param str endpoint: The endpoint to be reached by the request.
            // :param dict payload: The payload of the request.
            // :return The JSON-formatted content of the response.
            // :rtype: dict
            // :raise ValidationError: If an HTTP error occurs.
            // """
            // self.ensure_one()
            // 
            // url = f'https://api.xendit.co/{endpoint}'
            // auth = (self.xendit_secret_key, '')
            // try:
            //     response = requests.post(url, json=payload, auth=auth, timeout=10)
            //     response.raise_for_status()
            // except (requests.exceptions.ConnectionError, requests.exceptions.Timeout):
            //     _logger.exception("Unable to reach endpoint at %s", url)
            //     raise ValidationError("Xendit: " + _("Could not establish the connection to the API."))
            // except requests.exceptions.HTTPError as err:
            //     error_message = err.response.json().get('message')
            //     _logger.exception(
            //         "Invalid API request at %s with data:\n%s", url, pprint.pformat(payload)
            //     )
            //     raise ValidationError(
            //         "Xendit: " + _(
            //             "The communication with the API failed. Xendit gave us the following"
            //             " information: '%s'", error_message
            //         )
            //     )
            // return response.json()
            */
            return default;
        }
    }
}