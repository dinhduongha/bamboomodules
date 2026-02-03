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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Payment", Category = "Sales", Depends = new[] { "onboarding", "portal" })]
    public partial class PaymentTokenAppService : GenericAppService<PaymentToken>, IPaymentTokenAppService
    {

        public PaymentTokenAppService(IRepository<PaymentToken, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<PaymentToken> BuildDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_token.py) ---
            // def _build_display_name(self, *args, max_length=34, should_pad=True, **kwargs):
            // """ Build a token name of the desired maximum length with the format `•••• 1234`.
            // 
            // The payment details are padded on the left with up to four padding characters. The padding
            // is only added if there is enough room for it. If not, it is either reduced or not added at
            // all. If there is not enough room for the payment details either, they are trimmed from the
            // left.
            // 
            // For a module to customize the display name of a token, it must override this method and
            // return the customized display name.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param list args: The arguments passed by QWeb when calling this method.
            // :param int max_length: The desired maximum length of the token name. The default is `34` to
            //                        fit the largest IBANs.
            // :param bool should_pad: Whether the token should be padded.
            // :param dict kwargs: Optional data used in overrides of this method.
            // :return: The padded token name.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // if not self.create_date:
            //     return ''
            // 
            // padding_length = max_length - len(self.payment_details or '')
            // if not self.payment_details:
            //     create_date_str = self.create_date.strftime('%Y/%m/%d')
            //     display_name = _("Payment details saved on %(date)s", date=create_date_str)
            // elif padding_length >= 2:  # Enough room for padding.
            //     padding = '•' * min(padding_length - 1, 4) + ' ' if should_pad else ''
            //     display_name = ''.join([padding, self.payment_details])
            // elif padding_length > 0:  # Not enough room for padding.
            //     display_name = self.payment_details
            // else:  # Not enough room for neither padding nor the payment details.
            //     display_name = self.payment_details[-max_length:] if max_length > 0 else ''
            // return display_name
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_token.py) ---
            // def _build_display_name(self, *args, should_pad=True, **kwargs):
            // """ Override of `payment` to build the display name without padding.
            // 
            // Note: self.ensure_one()
            // 
            // :param list args: The arguments passed by QWeb when calling this method.
            // :param bool should_pad: Whether the token should be padded or not.
            // :param dict kwargs: Optional data.
            // :return: The demo token name.
            // :rtype: str
            // """
            // if self.provider_code != 'demo':
            //     return super()._build_display_name(*args, should_pad=should_pad, **kwargs)
            // return super()._build_display_name(*args, should_pad=False, **kwargs)
            */
            return default;
        }

        protected async Task<PaymentToken> CheckPartnerIsNeverPublicInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_token.py) ---
            // def _check_partner_is_never_public(self):
            // """ Check that the partner associated with the token is never public. """
            // for token in self:
            //     if token.partner_id.is_public:
            //         raise ValidationError(_("No token can be assigned to the public partner."))
            */
            return default;
        }

        protected async Task<PaymentToken> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_token.py) ---
            // def _compute_display_name(self):
            // for token in self:
            //     token.display_name = token._build_display_name()
            */
            return default;
        }

        protected async Task<PaymentToken> GetAvailableTokensInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_token.py) ---
            // def _get_available_tokens(self, providers_ids, partner_id, is_validation=False, **kwargs):
            // """ Return the available tokens linked to the given providers and partner.
            // 
            // For a module to retrieve the available tokens, it must override this method and add
            // information in the kwargs to define the context of the request.
            // 
            // :param list providers_ids: The ids of the providers available for the transaction.
            // :param int partner_id: The id of the partner.
            // :param bool is_validation: Whether the transaction is a validation operation.
            // :param dict kwargs: Locally unused keywords arguments.
            // :return: The available tokens.
            // :rtype: payment.token
            // """
            // if not is_validation:
            //     return self.env['payment.token'].search(
            //         [('provider_id', 'in', providers_ids), ('partner_id', '=', partner_id)]
            //     )
            // else:
            //     # Get all the tokens of the partner and of their commercial partner, regardless of
            //     # whether the providers are available.
            //     partner = self.env['res.partner'].browse(partner_id)
            //     return self.env['payment.token'].search(
            //         [('partner_id', 'in', [partner.id, partner.commercial_partner_id.id])]
            //     )
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: payment_token.py) ---
            // def _get_available_tokens(self, *args, is_express_checkout=False, **kwargs):
            // """ Override of `payment` not to return the tokens in case of express checkout.
            // 
            // :param dict args: Locally unused arguments.
            // :param bool is_express_checkout: Whether the payment is made through express checkout.
            // :param dict kwargs: Locally unused keywords arguments.
            // :return: The available tokens.
            // :rtype: payment.token
            // """
            // if is_express_checkout:
            //     return self.env['payment.token']
            // 
            // return super()._get_available_tokens(*args, **kwargs)
            */
            return default;
        }

        public async Task<PaymentToken> GetLinkedRecordsInfoAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_token.py) ---
            // def get_linked_records_info(self):
            // """ Return a list of information about records linked to the current token.
            // 
            // For a module to implement payments and link documents to a token, it must override this
            // method and add information about linked document records to the returned list.
            // 
            // The information must be structured as a dict with the following keys:
            // 
            // - `description`: The description of the record's model (e.g. "Subscription").
            // - `id`: The id of the record.
            // - `name`: The name of the record.
            // - `url`: The url to access the record.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The list of information about the linked document records.
            // :rtype: list
            // """
            // self.ensure_one()
            // return []
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        protected async Task<PaymentToken> GetSpecificCreateValuesInternalAsync(object provider_code, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_token.py) ---
            // def _get_specific_create_values(self, provider_code, values):
            // """ Complete the values of the `create` method with provider-specific values.
            // 
            // For a provider to add its own create values, it must overwrite this method and return a
            // dict of values. Provider-specific values take precedence over those of the dict of generic
            // create values.
            // 
            // :param str provider_code: The code of the provider managing the token.
            // :param dict values: The original create values.
            // :return: The dict of provider-specific create values.
            // :rtype: dict
            // """
            // return dict()
            */
            return default;
        }

        protected async Task<PaymentToken> HandleArchivingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_token.py) ---
            // def _handle_archiving(self):
            // """ Handle the archiving of tokens.
            // 
            // For a module to perform additional operations when a token is archived, it must override
            // this method.
            // 
            // :return: None
            // """
            // return
            */
            return default;
        }

        protected async Task<PaymentToken> RazorpayGetLimitExceedWarningInternalAsync(object amount, Guid currency_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_token.py) ---
            // def _razorpay_get_limit_exceed_warning(self, amount, currency_id):
            // """ Return a warning message when the maximum payment amount is exceeded.
            // 
            // :param float amount: The amount to be paid.
            // :param currency_id: The currency of the amount.
            // :return: A warning message when the maximum payment amount is exceeded.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // if not amount or self.provider_code != 'razorpay':
            //     return ""
            // 
            // # Try to get the maximum amount based on the transaction from which this token was created.
            // Transaction = self.env['payment.transaction']
            // primary_tx = Transaction.search(
            //     [('token_id', '=', self.id), ('operation', 'not in', ['offline', 'online_token'])],
            //     limit=1,
            // )
            // if primary_tx:
            //     mandate_max_amount = primary_tx._razorpay_get_mandate_max_amount()
            // else:  # Get the maximum amount based on the token's payment method code.
            //     pm = self.payment_method_id.primary_payment_method_id or self.payment_method_id
            //     mandate_max_amount_INR = const.MANDATE_MAX_AMOUNT.get(
            //         pm.code, const.MANDATE_MAX_AMOUNT['card']
            //     )
            //     mandate_max_amount = Transaction._razorpay_convert_inr_to_currency(
            //         mandate_max_amount_INR, currency_id
            //     )
            // 
            // # Return the warning message if the amount exceeds the maximum amount; else an empty string.
            // if amount > mandate_max_amount:
            //     return _(
            //         "You can not pay amounts greater than %(currency_symbol)s %(max_amount)s with this"
            //         " payment method",
            //         currency_symbol=currency_id.symbol,
            //         max_amount=float_round(mandate_max_amount, precision_digits=0),
            //     )
            // return ""
            */
            return default;
        }

        protected async Task<PaymentToken> StripeScaMigrateCustomerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_token.py) ---
            // def _stripe_sca_migrate_customer(self):
            // """ Migrate a token from the old implementation of Stripe to the SCA-compliant one.
            // 
            // In the old implementation, it was possible to create a Charge by giving only the customer id
            // and let Stripe use the default source (= default payment method). Stripe now requires to
            // specify the payment method for each new PaymentIntent. To do so, we fetch the payment method
            // associated to a customer and save its id on the token.
            // This migration happens once per token created with the old implementation.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // """
            // self.ensure_one()
            // 
            // # Fetch the available payment method of type 'card' for the given customer
            // response_content = self.provider_id._send_api_request(
            //     'GET',
            //     'payment_methods',
            //     data={
            //         'customer': self.provider_ref,
            //         'type': 'card',
            //         'limit': 1,  # A new customer is created for each new token. Never > 1 card.
            //     },
            // )
            // 
            // # Store the payment method ID on the token
            // payment_methods = response_content.get('data', [])
            // payment_method_id = payment_methods and payment_methods[0].get('id')
            // if not payment_method_id:
            //     raise ValidationError(_("Unable to convert payment token to new API."))
            // self.stripe_payment_method = payment_method_id
            // _logger.info("converted token with id %s to new API", self.id)
            */
            return default;
        }
    }
}