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
    public class PaymentTransactionAppService : GenericApplicationService<PaymentTransaction>, IPaymentTransactionAppService
    {

        public PaymentTransactionAppService(IRepository<PaymentTransaction, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<PaymentTransaction> AdyenCreateChildTxFromNotificationDataInternalAsync(object source_tx, object notification_data, object is_refund)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _adyen_create_child_tx_from_notification_data(
            //     self, source_tx, notification_data, is_refund=False
            // ):
            //     """ Create a child transaction based on Adyen data.
            // 
            //     :param payment.transaction source_tx: The source transaction for which a new operation is
            //                                           initiated.
            //     :param dict notification_data: The notification data sent by the provider
            //     :return: The newly created child transaction.
            //     :rtype: payment.transaction
            //     :raise ValidationError: If inconsistent data were received.
            //     """
            //     provider_reference = notification_data.get('pspReference')
            //     amount = notification_data.get('amount', {}).get('value')
            //     if not provider_reference or amount is None:  # amount == 0 if success == False
            //         raise ValidationError(
            //             "Adyen: " + _("Received data for child transaction with missing transaction values")
            //         )
            // 
            //     converted_amount = payment_utils.to_major_currency_units(amount, source_tx.currency_id)
            //     return source_tx._create_child_transaction(
            //         converted_amount, is_refund=is_refund, provider_reference=provider_reference
            //     )
            */
            return default;
        }

        protected async Task<PaymentTransaction> AdyenTokenizeFromNotificationDataInternalAsync(object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _adyen_tokenize_from_notification_data(self, notification_data):
            // """ Create a new token based on the notification data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider
            // :return: None
            // """
            // self.ensure_one()
            // 
            // additional_data = notification_data['additionalData']
            // token = self.env['payment.token'].create({
            //     'provider_id': self.provider_id.id,
            //     'payment_method_id': self.payment_method_id.id,
            //     'payment_details': additional_data.get('cardSummary'),
            //     'partner_id': self.partner_id.id,
            //     'provider_ref': additional_data['recurring.recurringDetailReference'],
            //     'adyen_shopper_reference': additional_data['recurring.shopperReference'],
            // })
            // self.write({
            //     'token_id': token,
            //     'tokenize': False,
            // })
            // _logger.info(
            //     "Created token with id %(token_id)s for partner with id %(partner_id)s from "
            //     "transaction with reference %(ref)s",
            //     {
            //         'token_id': token.id,
            //         'partner_id': self.partner_id.id,
            //         'ref': self.reference,
            //     },
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> AuthorizeCreateTransactionRequestInternalAsync(object opaque_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _authorize_create_transaction_request(self, opaque_data):
            // """ Create an Authorize.Net payment transaction request.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict opaque_data: The payment details obfuscated by Authorize.Net
            // :return:
            // """
            // self.ensure_one()
            // 
            // authorize_API = AuthorizeAPI(self.provider_id)
            // if self.provider_id.capture_manually or self.operation == 'validation':
            //     return authorize_API.authorize(self, opaque_data=opaque_data)
            // else:
            //     return authorize_API.auth_and_capture(self, opaque_data=opaque_data)
            */
            return default;
        }

        protected async Task<PaymentTransaction> AuthorizeTokenizeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _authorize_tokenize(self):
            // """ Create a token for the current transaction.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // """
            // self.ensure_one()
            // 
            // authorize_API = AuthorizeAPI(self.provider_id)
            // cust_profile = authorize_API.create_customer_profile(
            //     self.partner_id, self.provider_reference
            // )
            // _logger.info(
            //     "create_customer_profile request response for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(cust_profile)
            // )
            // if cust_profile:
            //     token = self.env['payment.token'].create({
            //         'provider_id': self.provider_id.id,
            //         'payment_method_id': self.payment_method_id.id,
            //         'payment_details': cust_profile.get('payment_details'),
            //         'partner_id': self.partner_id.id,
            //         'provider_ref': cust_profile.get('payment_profile_id'),
            //         'authorize_profile': cust_profile.get('profile_id'),
            //     })
            //     self.write({
            //         'token_id': token.id,
            //         'tokenize': False,
            //     })
            //     _logger.info(
            //         "created token with id %(token_id)s for partner with id %(partner_id)s from "
            //         "transaction with reference %(ref)s",
            //         {
            //             'token_id': token.id,
            //             'partner_id': self.partner_id.id,
            //             'ref': self.reference,
            //         },
            //     )
            */
            return default;
        }

        public async Task<PaymentTransaction> CaptureAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def action_capture(self):
            // """ Open the partial capture wizard if it is supported by the related providers, otherwise
            // capture the transactions immediately.
            // 
            // :return: The action to open the partial capture wizard, if supported.
            // :rtype: action.act_window|None
            // """
            // payment_utils.check_rights_on_recordset(self)
            // 
            // if any(tx.provider_id.sudo().support_manual_capture == 'partial' for tx in self):
            //     return {
            //         'name': _("Capture"),
            //         'type': 'ir.actions.act_window',
            //         'view_mode': 'form',
            //         'res_model': 'payment.capture.wizard',
            //         'target': 'new',
            //         'context': {
            //             'active_model': 'payment.transaction',
            //             # Consider also confirmed transactions to calculate the total authorized amount.
            //             'active_ids': self.filtered(lambda tx: tx.state in ['authorized', 'done']).ids,
            //         },
            //     }
            // else:
            //     for tx in self.filtered(lambda tx: tx.state == 'authorized'):
            //         # In sudo mode because we need to be able to read on provider fields.
            //         tx.sudo()._send_capture_request()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentTransaction> CheckAmountAndConfirmOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _check_amount_and_confirm_order(self):
            // """ Confirm the sales order based on the amount of a transaction.
            // 
            // Confirm the sales orders only if the transaction amount (or the sum of the partial
            // transaction amounts) is equal to or greater than the required amount for order confirmation
            // 
            // Grouped payments (paying multiple sales orders in one transaction) are not supported.
            // 
            // :return: The confirmed sales orders.
            // :rtype: a `sale.order` recordset
            // """
            // confirmed_orders = self.env['sale.order']
            // for tx in self:
            //     # We only support the flow where exactly one quotation is linked to a transaction.
            //     if len(tx.sale_order_ids) == 1:
            //         quotation = tx.sale_order_ids.filtered(lambda so: so.state in ('draft', 'sent'))
            //         if quotation and quotation._is_confirmation_amount_reached():
            //             quotation.with_context(send_email=True).action_confirm()
            //             confirmed_orders |= quotation
            // return confirmed_orders
            */
            return default;
        }

        protected async Task<PaymentTransaction> CheckStateAuthorizedSupportedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _check_state_authorized_supported(self):
            // """ Check that authorization is supported for a transaction in the `authorized` state. """
            // illegal_authorize_state_txs = self.filtered(
            //     lambda tx: tx.state == 'authorized' and not tx.provider_id.support_manual_capture
            // )
            // if illegal_authorize_state_txs:
            //     raise ValidationError(_(
            //         "Transaction authorization is not supported by the following payment providers: %s",
            //         ', '.join(set(illegal_authorize_state_txs.mapped('provider_id.name')))
            //     ))
            */
            return default;
        }

        protected async Task<PaymentTransaction> CheckTokenIsActiveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _check_token_is_active(self):
            // """ Check that the token used to create the transaction is active. """
            // if self.token_id and not self.token_id.active:
            //     raise ValidationError(_("Creating a transaction from an archived token is forbidden."))
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeInvoicesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py) ---
            // def _compute_invoices_count(self):
            // tx_data = {}
            // if self.ids:
            //     self.env.cr.execute(
            //         '''
            //         SELECT transaction_id, count(invoice_id)
            //         FROM account_invoice_transaction_rel
            //         WHERE transaction_id IN %s
            //         GROUP BY transaction_id
            //         ''',
            //         [tuple(self.ids)]
            //     )
            //     tx_data = dict(self.env.cr.fetchall())  # {id: count}
            // for tx in self:
            //     tx.invoices_count = tx_data.get(tx.id, 0)
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeReferenceInternalAsync(object provider_code, object prefix, object separator)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _compute_reference(self, provider_code, prefix=None, separator='-', **kwargs):
            // """ Compute a unique reference for the transaction.
            // 
            // The reference corresponds to the prefix if no other transaction with that prefix already
            // exists. Otherwise, it follows the pattern `{computed_prefix}{separator}{sequence_number}`
            // where:
            // 
            // - `{computed_prefix}` is:
            // 
            //   - The provided custom prefix, if any.
            //   - The computation result of :meth:`_compute_reference_prefix` if the custom prefix is not
            //     filled, but the kwargs are.
            //   - `'tx-{datetime}'` if neither the custom prefix nor the kwargs are filled.
            // 
            // - `{separator}` is the string that separates the prefix from the sequence number.
            // - `{sequence_number}` is the next integer in the sequence of references sharing the same
            //   prefix. The sequence starts with `1` if there is only one matching reference.
            // 
            // .. example::
            // 
            //    - Given the custom prefix `'example'` which has no match with an existing reference, the
            //      full reference will be `'example'`.
            //    - Given the custom prefix `'example'` which matches the existing reference `'example'`,
            //      and the custom separator `'-'`, the full reference will be `'example-1'`.
            //    - Given the kwargs `{'invoice_ids': [1, 2]}`, the custom separator `'-'` and no custom
            //      prefix, the full reference will be `'INV1-INV2'` (or similar) if no existing reference
            //      has the same prefix, or `'INV1-INV2-n'` if `n` existing references have the same
            //      prefix.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param str prefix: The custom prefix used to compute the full reference.
            // :param str separator: The custom separator used to separate the prefix from the suffix.
            // :param dict kwargs: Optional values passed to :meth:`_compute_reference_prefix` if no custom
            //                     prefix is provided.
            // :return: The unique reference for the transaction.
            // :rtype: str
            // """
            // # Compute the prefix.
            // if prefix:
            //     # Replace special characters by their ASCII alternative (é -> e ; ä -> a ; ...)
            //     prefix = unicodedata.normalize('NFKD', prefix).encode('ascii', 'ignore').decode('utf-8')
            // if not prefix:  # Prefix not provided or voided above, compute it based on the kwargs.
            //     prefix = self.sudo()._compute_reference_prefix(provider_code, separator, **kwargs)
            // if not prefix:  # Prefix not computed from the kwargs, fallback on time-based value
            //     prefix = payment_utils.singularize_reference_prefix()
            // 
            // # Compute the sequence number.
            // reference = prefix  # The first reference of a sequence has no sequence number.
            // if self.sudo().search_count([('reference', '=', prefix)], limit=1):  # The reference already has a match
            //     # We now execute a second search on `payment.transaction` to fetch all the references
            //     # starting with the given prefix. The load of these two searches is mitigated by the
            //     # index on `reference`. Although not ideal, this solution allows for quickly knowing
            //     # whether the sequence for a given prefix is already started or not, usually not. An SQL
            //     # query wouldn't help either as the selector is arbitrary and doing that would be an
            //     # open-door to SQL injections.
            //     same_prefix_references = self.sudo().search(
            //         [('reference', '=like', f'{prefix}{separator}%')]
            //     ).with_context(prefetch_fields=False).mapped('reference')
            // 
            //     # A final regex search is necessary to figure out the next sequence number. The previous
            //     # search could not rely on alphabetically sorting the reference to infer the largest
            //     # sequence number because both the prefix and the separator are arbitrary. A given
            //     # prefix could happen to be a substring of the reference from a different sequence.
            //     # For instance, the prefix 'example' is a valid match for the existing references
            //     # 'example', 'example-1' and 'example-ref', in that order. Trusting the order to infer
            //     # the sequence number would lead to a collision with 'example-1'.
            //     search_pattern = re.compile(rf'^{re.escape(prefix)}{separator}(\d+)$')
            //     max_sequence_number = 0  # If no match is found, start the sequence with this reference.
            //     for existing_reference in same_prefix_references:
            //         search_result = re.search(search_pattern, existing_reference)
            //         if search_result:  # The reference has the same prefix and is from the same sequence
            //             # Find the largest sequence number, if any.
            //             current_sequence = int(search_result.group(1))
            //             if current_sequence > max_sequence_number:
            //                 max_sequence_number = current_sequence
            // 
            //     # Compute the full reference.
            //     reference = f'{prefix}{separator}{max_sequence_number + 1}'
            // return reference
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py) ---
            // def _compute_reference(self, provider_code, prefix=None, separator='-', **kwargs):
            // """ Override of `payment` to ensure that APS' requirements for references are satisfied.
            // 
            // APS' requirements for transaction are as follows:
            // - References can only be made of alphanumeric characters and/or '-' and '_'.
            //   The prefix is generated with 'tx' as default. This prevents the prefix from being
            //   generated based on document names that may contain non-allowed characters
            //   (eg: INV/2020/...).
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param str prefix: The custom prefix used to compute the full reference.
            // :param str separator: The custom separator used to separate the prefix from the suffix.
            // :return: The unique reference for the transaction.
            // :rtype: str
            // """
            // if provider_code == 'aps':
            //     prefix = payment_utils.singularize_reference_prefix()
            // 
            // return super()._compute_reference(provider_code, prefix=prefix, separator=separator, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py) ---
            // def _compute_reference(self, provider_code, prefix=None, separator='-', **kwargs):
            // """ Override of `payment` to ensure that AsiaPay requirements for references are satisfied.
            // 
            // AsiaPay requirements for references are as follows:
            // - References must be unique at provider level for a given merchant account.
            //   This is satisfied by singularizing the prefix with the current datetime. If two
            //   transactions are created simultaneously, `_compute_reference` ensures the uniqueness of
            //   references by suffixing a sequence number.
            // - References must be at most 35 characters long.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param str prefix: The custom prefix used to compute the full reference.
            // :param str separator: The custom separator used to separate the prefix from the suffix.
            // :return: The unique reference for the transaction.
            // :rtype: str
            // """
            // if provider_code != 'asiapay':
            //     return super()._compute_reference(provider_code, prefix=prefix, **kwargs)
            // 
            // if not prefix:
            //     # If no prefix is provided, it could mean that a module has passed a kwarg intended for
            //     # the `_compute_reference_prefix` method, as it is only called if the prefix is empty.
            //     # We call it manually here because singularizing the prefix would generate a default
            //     # value if it was empty, hence preventing the method from ever being called and the
            //     # transaction from received a reference named after the related document.
            //     prefix = self.sudo()._compute_reference_prefix(provider_code, separator, **kwargs) or None
            // prefix = payment_utils.singularize_reference_prefix(prefix=prefix, max_length=35)
            // return super()._compute_reference(provider_code, prefix=prefix, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _compute_reference(self, provider_code, prefix=None, separator='-', **kwargs):
            // """ Override of `payment` to ensure that Worldline requirement for references is satisfied.
            // 
            // Worldline requires for references to be at most 30 characters long.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param str prefix: The custom prefix used to compute the full reference.
            // :param str separator: The custom separator used to separate the prefix from the suffix.
            // :return: The unique reference for the transaction.
            // :rtype: str
            // """
            // reference = super()._compute_reference(
            //     provider_code, prefix=prefix, separator=separator, **kwargs
            // )
            // if provider_code != 'worldline':
            //     return reference
            // 
            // if len(reference) <= 30:  # Worldline transaction merchantReference is limited to 30 chars
            //     return reference
            // 
            // prefix = payment_utils.singularize_reference_prefix(prefix='WL')
            // return super()._compute_reference(
            //     provider_code, prefix=prefix, separator=separator, **kwargs
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeReferencePrefixInternalAsync(object provider_code, object separator)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py) ---
            // def _compute_reference_prefix(self, provider_code, separator, **values):
            // """ Compute the reference prefix from the transaction values.
            // 
            // If the `values` parameter has an entry with 'invoice_ids' as key and a list of (4, id, O) or
            // (6, 0, ids) X2M command as value, the prefix is computed based on the invoice name(s).
            // Otherwise, an empty string is returned.
            // 
            // Note: This method should be called in sudo mode to give access to documents (INV, SO, ...).
            // 
            // :param str provider_code: The code of the provider handling the transaction
            // :param str separator: The custom separator used to separate data references
            // :param dict values: The transaction values used to compute the reference prefix. It should
            //                     have the structure {'invoice_ids': [(X2M command), ...], ...}.
            // :return: The computed reference prefix if invoice ids are found, an empty string otherwise
            // :rtype: str
            // """
            // command_list = values.get('invoice_ids')
            // if command_list:
            //     # Extract invoice id(s) from the X2M commands
            //     invoice_ids = self._fields['invoice_ids'].convert_to_cache(command_list, self)
            //     invoices = self.env['account.move'].browse(invoice_ids).exists()
            //     if len(invoices) == len(invoice_ids):  # All ids are valid
            //         prefix = separator.join(invoices.filtered(lambda inv: inv.name).mapped('name'))
            //         if name := values.get('name_next_installment'):
            //             prefix = name
            //         return prefix
            // return super()._compute_reference_prefix(provider_code, separator, **values)
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _compute_reference_prefix(self, provider_code, separator, **values):
            // """ Compute the reference prefix from the transaction values.
            // 
            // Note: This method should be called in sudo mode to give access to the documents (invoices,
            // sales orders) referenced in the transaction values.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param str separator: The custom separator used to separate parts of the computed
            //                       reference prefix.
            // :param dict values: The transaction values used to compute the reference prefix.
            // :return: The computed reference prefix.
            // :rtype: str
            // """
            // return ''
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: payment_transaction.py) ---
            // def _compute_reference_prefix(self, provider_code, separator, **values):
            // """ Override of payment to compute the reference prefix based on POS-specific values.
            // 
            // :return: The computed reference prefix if POS order id is found, the one of `super` otherwise
            // :rtype: str
            // """
            // pos_order_id = values.get('pos_order_id')
            // if pos_order_id:
            //     pos_order = self.env['pos.order'].sudo().browse(pos_order_id).exists()
            //     if pos_order:
            //         return pos_order.pos_reference
            // return super()._compute_reference_prefix(provider_code, separator, **values)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _compute_reference_prefix(self, provider_code, separator, **values):
            // """ Override of payment to compute the reference prefix based on Sales-specific values.
            // 
            // If the `values` parameter has an entry with 'sale_order_ids' as key and a list of (4, id, O)
            // or (6, 0, ids) X2M command as value, the prefix is computed based on the sales order name(s)
            // Otherwise, the computation is delegated to the super method.
            // 
            // :param str provider_code: The code of the provider handling the transaction
            // :param str separator: The custom separator used to separate data references
            // :param dict values: The transaction values used to compute the reference prefix. It should
            //                     have the structure {'sale_order_ids': [(X2M command), ...], ...}.
            // :return: The computed reference prefix if order ids are found, the one of `super` otherwise
            // :rtype: str
            // """
            // command_list = values.get('sale_order_ids')
            // if command_list:
            //     # Extract sales order id(s) from the X2M commands
            //     order_ids = self._fields['sale_order_ids'].convert_to_cache(command_list, self)
            //     orders = self.env['sale.order'].browse(order_ids).exists()
            //     if len(orders) == len(order_ids):  # All ids are valid
            //         return separator.join(orders.mapped('name'))
            // return super()._compute_reference_prefix(provider_code, separator, **values)
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeRefundsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _compute_refunds_count(self):
            // rg_data = self.env['payment.transaction']._read_group(
            //     domain=[('source_transaction_id', 'in', self.ids), ('operation', '=', 'refund')],
            //     groupby=['source_transaction_id'],
            //     aggregates=['__count'],
            // )
            // data = {source_transaction.id: count for source_transaction, count in rg_data}
            // for record in self:
            //     record.refunds_count = data.get(record.id, 0)
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeSaleOrderIdsNbrInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _compute_sale_order_ids_nbr(self):
            // for trans in self:
            //     trans.sale_order_ids_nbr = len(trans.sale_order_ids)
            */
            return default;
        }

        protected async Task<PaymentTransaction> ComputeSaleOrderReferenceInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _compute_sale_order_reference(self, order):
            // self.ensure_one()
            // if self.provider_id.so_reference_type == 'so_name':
            //     order_reference = order.name
            // elif self.provider_id.so_reference_type == 'partner':
            //     identification_number = order.partner_id.id
            //     order_reference = '%s/%s' % ('CUST', str(identification_number % 97).rjust(2, '0'))
            // else:
            //     # self.provider_id.so_reference_type is empty
            //     order_reference = False
            // 
            // invoice_journal = self.env['account.journal'].search([('type', '=', 'sale'), ('company_id', '=', self.env.company.id)], limit=1)
            // if invoice_journal:
            //     order_reference = invoice_journal._process_reference_for_sale_order(order_reference)
            // 
            // return order_reference
            */
            return default;
        }

        protected async Task<PaymentTransaction> CreateChildTransactionInternalAsync(object amount, object is_refund)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _create_child_transaction(self, amount, is_refund=False, **custom_create_values):
            // """ Create a new transaction with the current transaction as its parent transaction.
            // 
            // This happens only in case of a refund or a partial capture (where the initial transaction is
            // split between smaller transactions, either captured or voided).
            // 
            // Note: self.ensure_one()
            // 
            // :param float amount: The strictly positive amount of the child transaction, in the same
            //                      currency as the source transaction.
            // :param bool is_refund: Whether the child transaction is a refund.
            // :return: The created child transaction.
            // :rtype: payment.transaction
            // """
            // self.ensure_one()
            // 
            // if is_refund:
            //     reference_prefix = f'R-{self.reference}'
            //     amount = -amount
            //     operation = 'refund'
            // else:  # Partial capture or void.
            //     reference_prefix = f'P-{self.reference}'
            //     operation = self.operation
            // 
            // return self.create({
            //     'provider_id': self.provider_id.id,
            //     'payment_method_id': self.payment_method_id.id,
            //     'reference': self._compute_reference(self.provider_code, prefix=reference_prefix),
            //     'amount': amount,
            //     'currency_id': self.currency_id.id,
            //     'token_id': self.token_id.id,
            //     'operation': operation,
            //     'source_transaction_id': self.id,
            //     'partner_id': self.partner_id.id,
            //     **custom_create_values,
            // })
            */
            return default;
        }

        protected async Task<PaymentTransaction> CreatePaymentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py) ---
            // def _create_payment(self, **extra_create_values):
            // """Create an `account.payment` record for the current transaction.
            // 
            // If the transaction is linked to some invoices, their reconciliation is done automatically.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict extra_create_values: Optional extra create values
            // :return: The created payment
            // :rtype: recordset of `account.payment`
            // """
            // self.ensure_one()
            // 
            // reference = (f'{self.reference} - '
            //              f'{self.partner_id.display_name or ""} - '
            //              f'{self.provider_reference or ""}'
            //             )
            // 
            // payment_method_line = self.provider_id.journal_id.inbound_payment_method_line_ids\
            //     .filtered(lambda l: l.payment_provider_id == self.provider_id)
            // payment_values = {
            //     'amount': abs(self.amount),  # A tx may have a negative amount, but a payment must >= 0
            //     'payment_type': 'inbound' if self.amount > 0 else 'outbound',
            //     'currency_id': self.currency_id.id,
            //     'partner_id': self.partner_id.commercial_partner_id.id,
            //     'partner_type': 'customer',
            //     'journal_id': self.provider_id.journal_id.id,
            //     'company_id': self.provider_id.company_id.id,
            //     'payment_method_line_id': payment_method_line.id,
            //     'payment_token_id': self.token_id.id,
            //     'payment_transaction_id': self.id,
            //     'memo': reference,
            //     'write_off_line_vals': [],
            //     'invoice_ids': self.invoice_ids,
            //     **extra_create_values,
            // }
            // 
            // for invoice in self.invoice_ids:
            //     if invoice.state != 'posted':
            //         continue
            //     next_payment_values = invoice._get_invoice_next_payment_values()
            //     if next_payment_values['installment_state'] == 'epd' and self.amount == next_payment_values['amount_due']:
            //         aml = next_payment_values['epd_line']
            //         epd_aml_values_list = [({
            //             'aml': aml,
            //             'amount_currency': -aml.amount_residual_currency,
            //             'balance': -aml.balance,
            //         })]
            //         open_balance = next_payment_values['epd_discount_amount']
            //         early_payment_values = self.env['account.move']._get_invoice_counterpart_amls_for_early_payment_discount(epd_aml_values_list, open_balance)
            //         for aml_values_list in early_payment_values.values():
            //             if (aml_values_list):
            //                 aml_vl = aml_values_list[0]
            //                 aml_vl['partner_id'] = invoice.partner_id.id
            //                 payment_values['write_off_line_vals'] += [aml_vl]
            //         break
            // 
            // payment_term_lines = self.invoice_ids.line_ids.filtered(lambda line: line.display_type == 'payment_term')
            // if payment_term_lines:
            //     payment_values['destination_account_id'] = payment_term_lines[0].account_id.id
            // 
            // payment = self.env['account.payment'].create(payment_values)
            // payment.action_post()
            // 
            // # Track the payment to make a one2one.
            // self.payment_id = payment
            // 
            // # Reconcile the payment with the source transaction's invoices in case of a partial capture.
            // if self.operation == self.source_transaction_id.operation:
            //     invoices = self.source_transaction_id.invoice_ids
            // else:
            //     invoices = self.invoice_ids
            // invoices = invoices.filtered(lambda inv: inv.state != 'cancel')
            // if invoices:
            //     invoices.filtered(lambda inv: inv.state == 'draft').action_post()
            // 
            //     (payment.move_id.line_ids + invoices.line_ids).filtered(
            //         lambda line: line.account_id == payment.destination_account_id
            //         and not line.reconciled
            //     ).reconcile()
            // 
            // return payment
            */
            return default;
        }

        protected async Task<PaymentTransaction> CronPostProcessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _cron_post_process(self):
            // """ Trigger the post-processing of the transactions that were not handled by the client in
            // the `poll_status` controller method.
            // 
            // :return: None
            // """
            // txs_to_post_process = self
            // if not txs_to_post_process:
            //     # Don't try forever to post-process a transaction that doesn't go through. Set the limit
            //     # to 4 days because some providers (PayPal) need that much for the payment verification.
            //     retry_limit_date = datetime.now() - relativedelta.relativedelta(days=4)
            //     # Retrieve all transactions matching the criteria for post-processing
            //     txs_to_post_process = self.search(
            //         [('is_post_processed', '=', False), ('last_state_change', '>=', retry_limit_date)]
            //     )
            // for tx in txs_to_post_process:
            //     try:
            //         tx._post_process()
            //         self.env.cr.commit()
            //     except psycopg2.OperationalError:
            //         self.env.cr.rollback()  # Rollback and try later.
            //     except Exception as e:
            //         _logger.exception(
            //             "encountered an error while post-processing transaction with reference %s:\n%s",
            //             tx.reference, e
            //         )
            //         self.env.cr.rollback()
            */
            return default;
        }

        protected async Task<PaymentTransaction> CronSendInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _cron_send_invoice(self):
            // """
            //     Cron to send invoice that where not ready to be send directly after posting
            // """
            // if not self.env['ir.config_parameter'].sudo().get_param('sale.automatic_invoice'):
            //     return
            // 
            // # No need to retrieve old transactions
            // retry_limit_date = datetime.now() - relativedelta.relativedelta(days=2)
            // # Retrieve all transactions matching the criteria for post-processing
            // self.search([
            //     ('state', '=', 'done'),
            //     ('is_post_processed', '=', True),
            //     ('invoice_ids', 'in', self.env['account.move']._search([
            //         ('is_move_sent', '=', False),
            //         ('state', '=', 'posted'),
            //     ])),
            //     ('sale_order_ids.state', '=', 'sale'),
            //     ('last_state_change', '>=', retry_limit_date),
            // ])._send_invoice()
            */
            return default;
        }

        public async Task<PaymentTransaction> DemoSetCanceledAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def action_demo_set_canceled(self):
            // """ Set the state of the demo transaction to 'cancel'.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // """
            // self.ensure_one()
            // if self.provider_code != 'demo':
            //     return
            // 
            // notification_data = {'reference': self.reference, 'simulated_state': 'cancel'}
            // self._handle_notification_data('demo', notification_data)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PaymentTransaction> DemoSetDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def action_demo_set_done(self):
            // """ Set the state of the demo transaction to 'done'.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // """
            // self.ensure_one()
            // if self.provider_code != 'demo':
            //     return
            // 
            // notification_data = {'reference': self.reference, 'simulated_state': 'done'}
            // self._handle_notification_data('demo', notification_data)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PaymentTransaction> DemoSetErrorAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def action_demo_set_error(self):
            // """ Set the state of the demo transaction to 'error'.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // """
            // self.ensure_one()
            // if self.provider_code != 'demo':
            //     return
            // 
            // notification_data = {'reference': self.reference, 'simulated_state': 'error'}
            // self._handle_notification_data('demo', notification_data)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentTransaction> DemoTokenizeFromNotificationDataInternalAsync(object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _demo_tokenize_from_notification_data(self, notification_data):
            // """ Create a new token based on the notification data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The fake notification data to tokenize from.
            // :return: None
            // """
            // self.ensure_one()
            // 
            // state = notification_data['simulated_state']
            // token = self.env['payment.token'].create({
            //     'provider_id': self.provider_id.id,
            //     'payment_method_id': self.payment_method_id.id,
            //     'payment_details': notification_data['payment_details'],
            //     'partner_id': self.partner_id.id,
            //     'provider_ref': 'fake provider reference',
            //     'demo_simulated_state': state,
            // })
            // self.write({
            //     'token_id': token,
            //     'tokenize': False,
            // })
            // _logger.info(
            //     "Created token with id %s for partner with id %s.", token.id, self.partner_id.id
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> EnsureProviderIsNotDisabledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _ensure_provider_is_not_disabled(self):
            // """ Ensure that the provider's state is not `disabled` before sending a request to its
            // provider.
            // 
            // :return: None
            // :raise UserError: If the provider's state is `disabled`.
            // """
            // if self.provider_id.state == 'disabled':
            //     raise UserError(_(
            //         "Making a request to the provider is not possible because the provider is disabled."
            //     ))
            */
            return default;
        }

        protected async Task<PaymentTransaction> FlutterwaveIsAuthorizationPendingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _flutterwave_is_authorization_pending(self):
            // return self.filtered_domain([
            //     ('provider_code', '=', 'flutterwave'),
            //     ('operation', '=', 'online_token'),
            //     ('state', '=', 'pending'),
            //     ('provider_reference', 'ilike', 'https'),
            // ])
            */
            return default;
        }

        protected async Task<PaymentTransaction> FlutterwaveTokenizeFromNotificationDataInternalAsync(object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _flutterwave_tokenize_from_notification_data(self, notification_data):
            // """ Create a new token based on the notification data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // """
            // self.ensure_one()
            // 
            // token = self.env['payment.token'].create({
            //     'provider_id': self.provider_id.id,
            //     'payment_method_id': self.payment_method_id.id,
            //     'payment_details': notification_data['card']['last_4digits'],
            //     'partner_id': self.partner_id.id,
            //     'provider_ref': notification_data['card']['token'],
            //     'flutterwave_customer_email': notification_data['customer']['email'],
            // })
            // self.write({
            //     'token_id': token,
            //     'tokenize': False,
            // })
            // _logger.info(
            //     "created token with id %(token_id)s for partner with id %(partner_id)s from "
            //     "transaction with reference %(ref)s",
            //     {
            //         'token_id': token.id,
            //         'partner_id': self.partner_id.id,
            //         'ref': self.reference,
            //     },
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetCommunicationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py) ---
            // def _get_communication(self):
            // """ Return the communication the user should use for their transaction.
            // 
            // This communication might change according to the settings and the accounting localization.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The selected communication.
            // :rtype: str
            // """
            // self.ensure_one()
            // communication = ""
            // if hasattr(self, 'invoice_ids') and self.invoice_ids:
            //     communication = self.invoice_ids[0].payment_reference
            // elif hasattr(self, 'sale_order_ids') and self.sale_order_ids:
            //     communication = self.sale_order_ids[0].reference
            // return communication or self.reference
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetInvoicesToNotifyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py) ---
            // def _get_invoices_to_notify(self):
            // """ Return the invoices on which to log payment-related messages. """
            // return self.invoice_ids
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetLastInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_last(self):
            // """ Return the last transaction of the recordset.
            // 
            // :return: The last transaction of the recordset, sorted by id.
            // :rtype: recordset of `payment.transaction`
            // """
            // return self.filtered(lambda t: t.state != 'draft').sorted()[:1]
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetMandateValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_mandate_values(self):
            // """ Return a dict of module-specific values used to create a mandate.
            // 
            // For a module to add its own mandate values, it must overwrite this method and return a dict
            // of module-specific values.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The dict of module-specific mandate values.
            // :rtype: dict
            // """
            // self.ensure_one()
            // return dict()
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetProcessingValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_processing_values(self):
            // """ Return the values used to process the transaction.
            // 
            // The values are returned as a dict containing entries with the following keys:
            // 
            // - `provider_id`: The provider handling the transaction, as a `payment.provider` id.
            // - `provider_code`: The code of the provider.
            // - `reference`: The reference of the transaction.
            // - `amount`: The rounded amount of the transaction.
            // - `currency_id`: The currency of the transaction, as a `res.currency` id.
            // - `partner_id`: The partner making the transaction, as a `res.partner` id.
            // - `should_tokenize`: Whether this transaction should be tokenized.
            // - Additional provider-specific entries.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The processing values.
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // processing_values = {
            //     'provider_id': self.provider_id.id,
            //     'provider_code': self.provider_code,
            //     'reference': self.reference,
            //     'amount': self.amount,
            //     'currency_id': self.currency_id.id,
            //     'partner_id': self.partner_id.id,
            //     'should_tokenize': self.tokenize,
            // }
            // 
            // # Complete generic processing values with provider-specific values.
            // processing_values.update(self._get_specific_processing_values(processing_values))
            // secret_keys = self._get_specific_secret_keys()
            // logged_values = {k: v for k, v in processing_values.items() if k not in secret_keys}
            // _logger.info(
            //     "generic and provider-specific processing values for transaction with reference "
            //     "%(ref)s:\n%(values)s",
            //     {'ref': self.reference, 'values': pprint.pformat(logged_values)},
            // )
            // 
            // # Render the html form for the redirect flow if available.
            // if self.operation in ('online_redirect', 'validation'):
            //     redirect_form_view = self.provider_id._get_redirect_form_view(
            //         is_validation=self.operation == 'validation'
            //     )
            //     if redirect_form_view:  # Some provider don't need a redirect form.
            //         rendering_values = self._get_specific_rendering_values(processing_values)
            //         _logger.info(
            //             "provider-specific rendering values for transaction with reference "
            //             "%(ref)s:\n%(values)s",
            //             {'ref': self.reference, 'values': pprint.pformat(rendering_values)},
            //         )
            //         redirect_form_html = self.env['ir.qweb']._render(redirect_form_view.id, rendering_values)
            //         processing_values.update(redirect_form_html=redirect_form_html)
            // 
            // return processing_values
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetReceivedMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_received_message(self):
            // """ Return the message stating that the transaction has been received by the provider.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The 'transaction received' message.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // formatted_amount = format_amount(self.env, self.amount, self.currency_id)
            // if self.state == 'pending':
            //     message = _(
            //         ("The transaction with reference %(ref)s for %(amount)s "
            //         "is pending (%(provider_name)s)."),
            //         ref=self.reference,
            //         amount=formatted_amount,
            //         provider_name=self.provider_id.name
            //     )
            // elif self.state == 'authorized':
            //     message = _(
            //         "The transaction with reference %(ref)s for %(amount)s has been authorized "
            //         "(%(provider_name)s).", ref=self.reference, amount=formatted_amount,
            //         provider_name=self.provider_id.name
            //     )
            // elif self.state == 'done':
            //     message = _(
            //         "The transaction with reference %(ref)s for %(amount)s has been confirmed "
            //         "(%(provider_name)s).", ref=self.reference, amount=formatted_amount,
            //         provider_name=self.provider_id.name
            //     )
            // elif self.state == 'error':
            //     message = _(
            //         "The transaction with reference %(ref)s for %(amount)s encountered an error"
            //         " (%(provider_name)s).",
            //         ref=self.reference, amount=formatted_amount, provider_name=self.provider_id.name
            //     )
            //     if self.state_message:
            //         message += Markup("<br/>") + _("Error: %s", self.state_message)
            // else:
            //     message = _(
            //         ("The transaction with reference %(ref)s for %(amount)s is canceled "
            //         "(%(provider_name)s)."),
            //         ref=self.reference,
            //         amount=formatted_amount,
            //         provider_name=self.provider_id.name
            //     )
            //     if self.state_message:
            //         message += Markup("<br/>") + _("Reason: %s", self.state_message)
            // return message
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetSentMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_sent_message(self):
            // """ Return the message stating that the transaction has been requested.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The 'transaction sent' message.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // # Choose the message based on the payment flow.
            // if self.operation in ('online_redirect', 'online_direct'):
            //     message = _(
            //         "A transaction with reference %(ref)s has been initiated (%(provider_name)s).",
            //         ref=self.reference, provider_name=self.provider_id.name
            //     )
            // elif self.operation == 'refund':
            //     formatted_amount = format_amount(self.env, -self.amount, self.currency_id)
            //     message = _(
            //         "A refund request of %(amount)s has been sent. The payment will be created soon. "
            //         "Refund transaction reference: %(ref)s (%(provider_name)s).",
            //         amount=formatted_amount, ref=self.reference, provider_name=self.provider_id.name
            //     )
            // elif self.operation in ('online_token', 'offline'):
            //     message = _(
            //         "A transaction with reference %(ref)s has been initiated using the payment method "
            //         "%(token)s (%(provider_name)s).",
            //         ref=self.reference,
            //         token=self.token_id._build_display_name(),
            //         provider_name=self.provider_id.name
            //     )
            // else:  # 'validation'
            //     message = _(
            //         "A transaction with reference %(ref)s has been initiated to save a new payment "
            //         "method (%(provider_name)s)",
            //         ref=self.reference,
            //         provider_name=self.provider_id.name,
            //     )
            // return message
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py) ---
            // def _get_sent_message(self):
            // """ Override of payment to return a different message.
            // 
            // :return: The 'transaction sent' message
            // :rtype: str
            // """
            // message = super()._get_sent_message()
            // if self.provider_code == 'custom':
            //     message = _(
            //         "The customer has selected %(provider_name)s to make the payment.",
            //         provider_name=self.provider_id.name
            //     )
            // return message
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetSpecificCreateValuesInternalAsync(object provider_code, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_specific_create_values(self, provider_code, values):
            // """ Complete the values of the `create` method with provider-specific values.
            // 
            // For a provider to add its own create values, it must overwrite this method and return a dict
            // of values. Provider-specific values take precedence over those of the dict of generic create
            // values.
            // 
            // :param str provider_code: The code of the provider that handled the transaction.
            // :param dict values: The original create values.
            // :return: The dict of provider-specific create values.
            // :rtype: dict
            // """
            // return dict()
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetSpecificProcessingValuesInternalAsync(object processing_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_specific_processing_values(self, processing_values):
            // """ Return a dict of provider-specific values used to process the transaction.
            // 
            // For a provider to add its own processing values, it must overwrite this method and return a
            // dict of provider-specific values based on the generic values returned by this method.
            // Provider-specific values take precedence over those of the dict of generic processing
            // values.
            // 
            // :param dict processing_values: The generic processing values of the transaction.
            // :return: The dict of provider-specific processing values.
            // :rtype: dict
            // """
            // return dict()
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _get_specific_processing_values(self, processing_values):
            // """ Override of payment to return Adyen-specific processing values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic processing values of the transaction
            // :return: The dict of provider-specific processing values
            // :rtype: dict
            // """
            // res = super()._get_specific_processing_values(processing_values)
            // if self.provider_code != 'adyen':
            //     return res
            // 
            // converted_amount = payment_utils.to_minor_currency_units(
            //     self.amount, self.currency_id, const.CURRENCY_DECIMALS.get(self.currency_id.name)
            // )
            // return {
            //     'converted_amount': converted_amount,
            //     'access_token': payment_utils.generate_access_token(
            //         processing_values['reference'],
            //         converted_amount,
            //         self.currency_id.id,
            //         processing_values['partner_id']
            //     )
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _get_specific_processing_values(self, processing_values):
            // """ Override of payment to return an access token as provider-specific processing values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic processing values of the transaction
            // :return: The dict of provider-specific processing values
            // :rtype: dict
            // """
            // res = super()._get_specific_processing_values(processing_values)
            // if self.provider_code != 'authorize':
            //     return res
            // 
            // return {
            //     'access_token': payment_utils.generate_access_token(
            //         processing_values['reference'], processing_values['partner_id']
            //     )
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _get_specific_processing_values(self, processing_values):
            // """ Override of payment to redirect pending token-flow transactions.
            // 
            // If the financial institution insists on 3-D Secure authentication, this
            // override will redirect the user to the provided authorization page.
            // 
            // Note: `self.ensure_one()`
            // """
            // res = super()._get_specific_processing_values(processing_values)
            // if self._flutterwave_is_authorization_pending():
            //     res['redirect_form_html'] = self.env['ir.qweb']._render(
            //         self.provider_id.redirect_form_view_id.id,
            //         {'api_url': self.provider_reference},
            //     )
            // return res
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py) ---
            // def _get_specific_processing_values(self, processing_values):
            // """ Override of `payment` to return the Paypal-specific processing values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic and specific processing values of the
            //                                transaction.
            // :return: The dict of provider-specific processing values
            // :rtype: dict
            // """
            // res = super()._get_specific_processing_values(processing_values)
            // if self.provider_code != 'paypal':
            //     return res
            // 
            // payload = self._paypal_prepare_order_payload()
            // 
            // _logger.info(
            //     "Sending '/checkout/orders' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(payload)
            // )
            // idempotency_key = payment_utils.generate_idempotency_key(
            //     self, scope='payment_request_order'
            // )
            // order_data = self.provider_id._paypal_make_request(
            //     '/v2/checkout/orders', json_payload=payload, idempotency_key=idempotency_key
            // )
            // _logger.info(
            //     "Response of '/checkout/orders' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(order_data)
            // )
            // return {'order_id': order_data['id']}
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _get_specific_processing_values(self, processing_values):
            // """ Override of `payment` to return razorpay-specific processing values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic and specific processing values of the
            //                                transaction.
            // :return: The provider-specific processing values.
            // :rtype: dict
            // """
            // res = super()._get_specific_processing_values(processing_values)
            // if self.provider_code != 'razorpay':
            //     return res
            // 
            // if self.operation in ('online_token', 'offline'):
            //     return {}
            // 
            // customer_id = self._razorpay_create_customer()['id']
            // order_id = self._razorpay_create_order(customer_id)['id']
            // return {
            //     'razorpay_key_id': self.provider_id.razorpay_key_id,
            //     'razorpay_public_token': self.provider_id._razorpay_get_public_token(),
            //     'razorpay_customer_id': customer_id,
            //     'is_tokenize_request': self.tokenize,
            //     'razorpay_order_id': order_id,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _get_specific_processing_values(self, processing_values):
            // """ Override of payment to return Stripe-specific processing values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic processing values of the transaction
            // :return: The dict of provider-specific processing values
            // :rtype: dict
            // """
            // res = super()._get_specific_processing_values(processing_values)
            // if self.provider_code != 'stripe' or self.operation == 'online_token':
            //     return res
            // 
            // intent = self._stripe_create_intent()
            // base_url = self.provider_id.get_base_url()
            // return {
            //     'client_secret': intent['client_secret'],
            //     'return_url': url_join(
            //         base_url,
            //         f'{StripeController._return_url}?{url_encode({"reference": self.reference})}',
            //     ),
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _get_specific_processing_values(self, processing_values):
            // """ Override of `payment` to redirect failed token-flow transactions.
            // 
            // If the financial institution insists on user authentication,
            // this override will reset the transaction, and switch the flow to redirect.
            // 
            // Note: self.ensure_one() from `_get_processing_values`.
            // 
            // :param dict processing_values: The generic processing values of the transaction.
            // :return: The dict of provider-specific processing values.
            // :rtype: dict
            // """
            // res = super()._get_specific_processing_values(processing_values)
            // if (
            //     self.provider_code == 'worldline'
            //     and self.operation == 'online_token'
            //     and self.state == 'error'
            //     and self.state_message.endswith('AUTHORIZATION_REQUESTED')
            // ):
            //     # Tokenized payment failed due to 3-D Secure authentication request.
            //     # Reset transaction to draft and switch to redirect flow.
            //     self.write({
            //         'state': 'draft',
            //         'operation': 'online_redirect',
            //     })
            //     res['force_flow'] = 'redirect'
            // return res
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _get_specific_processing_values(self, processing_values):
            // """ Override of payment to return Xendit-specific processing values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic processing values of the transaction
            // :return: The dict of provider-specific processing values
            // :rtype: dict
            // """
            // res = super()._get_specific_processing_values(processing_values)
            // if self.provider_code != 'xendit':
            //     return res
            // 
            // if self.currency_id.name in const.CURRENCY_DECIMALS:
            //     rounding = const.CURRENCY_DECIMALS.get(self.currency_id.name)
            // else:
            //     rounding = self.currency_id.decimal_places
            // rounded_amount = float_round(self.amount, rounding, rounding_method='DOWN')
            // return {
            //     'rounded_amount': rounded_amount
            // }
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetSpecificRenderingValuesInternalAsync(object processing_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Return a dict of provider-specific values used to render the redirect form.
            // 
            // For a provider to add its own rendering values, it must overwrite this method and return a
            // dict of provider-specific values based on the processing values (provider-specific
            // processing values included).
            // 
            // :param dict processing_values: The processing values of the transaction.
            // :return: The dict of provider-specific rendering values.
            // :rtype: dict
            // """
            // return dict()
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of `payment` to return APS-specific processing values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic processing values of the transaction.
            // :return: The dict of provider-specific processing values.
            // :rtype: dict
            // """
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'aps':
            //     return res
            // 
            // converted_amount = payment_utils.to_minor_currency_units(self.amount, self.currency_id)
            // base_url = self.provider_id.get_base_url()
            // payment_option = aps_utils.get_payment_option(self.payment_method_id.code)
            // rendering_values = {
            //     'command': 'PURCHASE',
            //     'access_code': self.provider_id.aps_access_code,
            //     'merchant_identifier': self.provider_id.aps_merchant_identifier,
            //     'merchant_reference': self.reference,
            //     'amount': str(converted_amount),
            //     'currency': self.currency_id.name,
            //     'language': self.partner_lang[:2],
            //     'customer_email': self.partner_id.email_normalized,
            //     'return_url': urls.url_join(base_url, APSController._return_url),
            // }
            // if payment_option:  # Not included if the payment method is 'card'.
            //     rendering_values['payment_option'] = payment_option
            // rendering_values.update({
            //     'signature': self.provider_id._aps_calculate_signature(
            //         rendering_values, incoming=False
            //     ),
            //     'api_url': self.provider_id._aps_get_api_url(),
            // })
            // return rendering_values
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of `payment` to return AsiaPay-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`.
            // 
            // :param dict processing_values: The generic and specific processing values of the
            //                                transaction.
            // :return: The dict of provider-specific processing values.
            // :rtype: dict
            // """
            // def get_language_code(lang_):
            //     """ Return the language code corresponding to the provided lang.
            // 
            //     If the lang is not mapped to any language code, the country code is used instead. In
            //     case the country code has no match either, we fall back to English.
            // 
            //     :param str lang_: The lang, in IETF language tag format.
            //     :return: The corresponding language code.
            //     :rtype: str
            //     """
            //     language_code_ = const.LANGUAGE_CODES_MAPPING.get(lang_)
            //     if not language_code_:
            //         country_code_ = lang_.split('_')[0]
            //         language_code_ = const.LANGUAGE_CODES_MAPPING.get(country_code_)
            //     if not language_code_:
            //         language_code_ = const.LANGUAGE_CODES_MAPPING['en']
            //     return language_code_
            // 
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'asiapay':
            //     return res
            // 
            // base_url = self.provider_id.get_base_url()
            // # The lang is taken from the context rather than from the partner because it is not required
            // # to be logged in to make a payment, and because the lang is not always set on the partner.
            // lang = self._context.get('lang') or 'en_US'
            // rendering_values = {
            //     'merchant_id': self.provider_id.asiapay_merchant_id,
            //     'amount': self.amount,
            //     'reference': self.reference,
            //     'currency_code': const.CURRENCY_MAPPING[self.provider_id.available_currency_ids[0].name],
            //     'mps_mode': 'SCP',
            //     'return_url': urls.url_join(base_url, AsiaPayController._return_url),
            //     'payment_type': 'N',
            //     'language': get_language_code(lang),
            //     'payment_method': const.PAYMENT_METHODS_MAPPING.get(self.payment_method_id.code, 'ALL'),
            // }
            // rendering_values.update({
            //     'secure_hash': self.provider_id._asiapay_calculate_signature(
            //         rendering_values, incoming=False
            //     ),
            //     'api_url': self.provider_id._asiapay_get_api_url()
            // })
            // return rendering_values
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of payment to return Buckaroo-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic and specific processing values of the transaction
            // :return: The dict of provider-specific processing values
            // :rtype: dict
            // """
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'buckaroo':
            //     return res
            // 
            // return_url = urls.url_join(self.provider_id.get_base_url(), BuckarooController._return_url)
            // rendering_values = {
            //     'api_url': self.provider_id._buckaroo_get_api_url(),
            //     'Brq_websitekey': self.provider_id.buckaroo_website_key,
            //     'Brq_amount': self.amount,
            //     'Brq_currency': self.currency_id.name,
            //     'Brq_invoicenumber': self.reference,
            //     # Include all 4 URL keys despite they share the same value as they are part of the sig.
            //     'Brq_return': return_url,
            //     'Brq_returncancel': return_url,
            //     'Brq_returnerror': return_url,
            //     'Brq_returnreject': return_url,
            // }
            // if self.partner_lang:
            //     rendering_values['Brq_culture'] = self.partner_lang.replace('_', '-')
            // rendering_values['Brq_signature'] = self.provider_id._buckaroo_generate_digital_sign(
            //     rendering_values, incoming=False
            // )
            // return rendering_values
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of payment to return custom-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic and specific processing values of the transaction
            // :return: The dict of provider-specific processing values
            // :rtype: dict
            // """
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'custom':
            //     return res
            // 
            // return {
            //     'api_url': CustomController._process_url,
            //     'reference': self.reference,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of payment to return Flutterwave-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic and specific processing values of the transaction
            // :return: The dict of provider-specific processing values.
            // :rtype: dict
            // """
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'flutterwave':
            //     return res
            // 
            // # Initiate the payment and retrieve the payment link data.
            // base_url = self.provider_id.get_base_url()
            // payload = {
            //     'tx_ref': self.reference,
            //     'amount': self.amount,
            //     'currency': self.currency_id.name,
            //     'redirect_url': urls.url_join(base_url, FlutterwaveController._return_url),
            //     'customer': {
            //         'email': self.partner_email,
            //         'name': self.partner_name,
            //         'phonenumber': self.partner_phone,
            //     },
            //     'customizations': {
            //         'title': self.company_id.name,
            //         'logo': urls.url_join(base_url, f'web/image/res.company/{self.company_id.id}/logo'),
            //     },
            //     'payment_options': const.PAYMENT_METHODS_MAPPING.get(
            //         self.payment_method_code, self.payment_method_code
            //     ),
            // }
            // payment_link_data = self.provider_id._flutterwave_make_request('payments', payload=payload)
            // 
            // # Extract the payment link URL and embed it in the redirect form.
            // rendering_values = {
            //     'api_url': payment_link_data['data']['link'],
            // }
            // return rendering_values
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of `payment` to return Mercado Pago-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_rendering_values`.
            // 
            // :param dict processing_values: The generic and specific processing values of the transaction
            // :return: The dict of provider-specific processing values.
            // :rtype: dict
            // """
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'mercado_pago':
            //     return res
            // 
            // # Initiate the payment and retrieve the payment link data.
            // payload = self._mercado_pago_prepare_preference_request_payload()
            // _logger.info(
            //     "Sending '/checkout/preferences' request for link creation:\n%s",
            //     pprint.pformat(payload),
            // )
            // api_url = self.provider_id._mercado_pago_make_request(
            //     '/checkout/preferences', payload=payload
            // )['init_point' if self.provider_id.state == 'enabled' else 'sandbox_init_point']
            // 
            // # Extract the payment link URL and params and embed them in the redirect form.
            // parsed_url = urls.url_parse(api_url)
            // url_params = urls.url_decode(parsed_url.query)
            // rendering_values = {
            //     'api_url': api_url,
            //     'url_params': url_params,  # Encore the params as inputs to preserve them.
            // }
            // return rendering_values
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of payment to return Mollie-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic and specific processing values of the transaction
            // :return: The dict of provider-specific rendering values
            // :rtype: dict
            // """
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'mollie':
            //     return res
            // 
            // payload = self._mollie_prepare_payment_request_payload()
            // _logger.info("sending '/payments' request for link creation:\n%s", pprint.pformat(payload))
            // payment_data = self.provider_id._mollie_make_request('/payments', data=payload)
            // 
            // # The provider reference is set now to allow fetching the payment status after redirection
            // self.provider_reference = payment_data.get('id')
            // 
            // # Extract the checkout URL from the payment data and add it with its query parameters to the
            // # rendering values. Passing the query parameters separately is necessary to prevent them
            // # from being stripped off when redirecting the user to the checkout URL, which can happen
            // # when only one payment method is enabled on Mollie and query parameters are provided.
            // checkout_url = payment_data['_links']['checkout']['href']
            // parsed_url = urls.url_parse(checkout_url)
            // url_params = urls.url_decode(parsed_url.query)
            // return {'api_url': checkout_url, 'url_params': url_params}
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of `payment` to return Nuvei-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic and specific processing values of the
            //                                transaction.
            // :return: The dict of provider-specific rendering values.
            // :rtype: dict
            // """
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'nuvei':
            //     return res
            // 
            // first_name, last_name = payment_utils.split_partner_name(self.partner_name)
            // if self.payment_method_code in const.FULL_NAME_METHODS and not (first_name and last_name):
            //     raise UserError(
            //         "Nuvei: " + _(
            //             "%(payment_method)s requires both a first and last name.",
            //             payment_method=self.payment_method_id.name,
            //         )
            //     )
            // 
            // # Some payment methods don't support float values, even for currencies that does. Therefore,
            // # we must round them.
            // is_mandatory_integer_pm = self.payment_method_code in const.INTEGER_METHODS
            // rounding = 0 if is_mandatory_integer_pm else self.currency_id.decimal_places
            // rounded_amount = float_round(self.amount, rounding, rounding_method='DOWN')
            // 
            // # Phone numbers need to be standardized and validated.
            // phone_number = self.partner_phone and self._phone_format(
            //     number=self.partner_phone, country=self.partner_country_id, raise_exception=False
            // )
            // 
            // # When a parsing error occurs with Nuvei or the user cancels the order, they do not send the
            // # checksum back, as such we need to pass an access token token in the url.
            // base_url = self.provider_id.get_base_url()
            // return_url = base_url + NuveiController._return_url
            // cancel_error_url_params = {
            //     'tx_ref': self.reference,
            //     'error_access_token': payment_utils.generate_access_token(self.reference),
            // }
            // cancel_error_url = f'{return_url}?{urlencode(cancel_error_url_params)}'
            // 
            // url_params = {
            //     'address1': self.partner_address or '',
            //     'city': self.partner_city or '',
            //     'country': self.partner_country_id.code,
            //     'currency': self.currency_id.name,
            //     'email': self.partner_email or '',
            //     'encoding': 'UTF-8',
            //     'first_name': first_name,
            //     'item_amount_1': rounded_amount,
            //     'item_name_1': self.reference,
            //     'item_quantity_1': 1,
            //     'invoice_id': self.reference,
            //     'last_name': last_name,
            //     'merchantLocale': self.partner_lang,
            //     'merchant_id': self.provider_id.nuvei_merchant_identifier,
            //     'merchant_site_id': self.provider_id.nuvei_site_identifier,
            //     'payment_method_mode': 'filter',
            //     'payment_method': const.PAYMENT_METHODS_MAPPING.get(
            //         self.payment_method_code, self.payment_method_code
            //     ),
            //     'phone1': phone_number or '',
            //     'state': self.partner_state_id.code or '',
            //     'user_token_id': uuid4(),  # Random string due to some PMs requiring it but not used.
            //     'time_stamp': self.create_date.strftime('%Y-%m-%d.%H:%M:%S'),
            //     'total_amount': rounded_amount,
            //     'version': '4.0.0',
            //     'zip': self.partner_zip or '',
            //     'back_url': cancel_error_url,
            //     'error_url': cancel_error_url,
            //     'notify_url': base_url + NuveiController._webhook_url,
            //     'pending_url': return_url,
            //     'success_url': return_url,
            // }
            // 
            // checksum = self.provider_id._nuvei_calculate_signature(url_params, incoming=False)
            // rendering_values = {
            //     'api_url': self.provider_id._nuvei_get_api_url(),
            //     'checksum': checksum,
            //     'url_params': url_params,
            // }
            // return rendering_values
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of `payment` to return Worldline-specific processing values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`.
            // 
            // :param dict processing_values: The generic processing values of the transaction.
            // :return: The dict of provider-specific processing values.
            // :rtype: dict
            // """
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'worldline':
            //     return res
            // 
            // checkout_session_data = self._worldline_create_checkout_session()
            // return {'api_url': checkout_session_data['redirectUrl']}
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of `payment` to return Xendit-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic and specific processing values of the transaction
            // :return: The dict of provider-specific processing values.
            // :rtype: dict
            // """
            // res = super()._get_specific_rendering_values(processing_values)
            // if self.provider_code != 'xendit' or self.payment_method_code == 'card':
            //     return res
            // 
            // # Initiate the payment and retrieve the invoice data.
            // payload = self._xendit_prepare_invoice_request_payload()
            // _logger.info("Sending invoice request for link creation:\n%s", pprint.pformat(payload))
            // invoice_data = self.provider_id._xendit_make_request('v2/invoices', payload=payload)
            // _logger.info("Received invoice request response:\n%s", pprint.pformat(invoice_data))
            // 
            // # Extract the payment link URL and embed it in the redirect form.
            // rendering_values = {
            //     'api_url': invoice_data.get('invoice_url')
            // }
            // return rendering_values
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetSpecificSecretKeysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_specific_secret_keys(self):
            // """ Return dict keys of provider-specific values that should be hidden when logged.
            // 
            // :return: The provider-specific secret keys
            // :rtype: dict_keys
            // """
            // return dict().keys()
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _get_specific_secret_keys(self):
            // """ Override of payment to return Stripe-specific secret keys.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :return: The provider-specific secret keys
            // :rtype: dict_keys
            // """
            // if self.provider_code == 'stripe':
            //     return {'client_secret': None}.keys()
            // return super()._get_specific_secret_keys()
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetTxFromNotificationDataInternalAsync(object provider_code, object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Find the transaction based on the notification data.
            // 
            // For a provider to handle transaction processing, it must overwrite this method and return
            // the transaction matching the notification data.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction, if found.
            // :rtype: recordset of `payment.transaction`
            // """
            // return self
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of payment to find the transaction based on Adyen data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict notification_data: The notification data sent by the provider
            // :return: The transaction if found
            // :rtype: recordset of `payment.transaction`
            // :raise: ValidationError if inconsistent data were received
            // :raise: ValidationError if the data match no transaction
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'adyen' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('merchantReference')
            // if not reference:
            //     raise ValidationError("Adyen: " + _("Received data with missing merchant reference"))
            // 
            // event_code = notification_data.get('eventCode', 'AUTHORISATION')  # Fallback on auth if S2S.
            // provider_reference = notification_data.get('pspReference')
            // source_reference = notification_data.get('originalReference')
            // if event_code == 'AUTHORISATION':
            //     tx = self.search([('reference', '=', reference), ('provider_code', '=', 'adyen')])
            // elif event_code in ['CANCELLATION', 'CAPTURE', 'CAPTURE_FAILED']:
            //     # The capture/void may be initiated from Adyen, so we can't trust the reference.
            //     # We find the transaction based on the original provider reference since Adyen will have
            //     # two different references: one for the original transaction and one for the capture or
            //     # void. We keep the second one only for child transactions. For full capture/void, no
            //     # child transaction are created. Thus, we first look for the source transaction before
            //     # checking if we need to find/create a child transaction.
            //     source_tx = self.search(
            //         [('provider_reference', '=', source_reference), ('provider_code', '=', 'adyen')]
            //     )
            //     if source_tx:
            //         notification_data_amount = notification_data.get('amount', {}).get('value')
            //         converted_notification_amount = payment_utils.to_major_currency_units(
            //             notification_data_amount, source_tx.currency_id
            //         )
            //         if source_tx.amount == converted_notification_amount:  # Full capture/void.
            //             tx = source_tx
            //         else:  # Partial capture/void; we search for the child transaction instead.
            //             tx = self.search([
            //                 ('provider_reference', '=', provider_reference),
            //                 ('provider_code', '=', 'adyen'),
            //             ])
            //             if tx and tx.amount != converted_notification_amount:
            //                 # If the void was requested expecting a certain amount but, in the meantime,
            //                 # others captures that Odoo was unaware of were done, the amount voided will
            //                 # be different from the amount of the existing transaction.
            //                 tx._set_error(_(
            //                     "The amount processed by Adyen for the transaction %s is different than"
            //                     " the one requested. Another transaction is created with the correct"
            //                     " amount.", tx.reference
            //                 ))
            //                 tx = self.env['payment.transaction']
            //             if not tx:  # Partial capture/void initiated from Adyen or with a wrong amount.
            //                 # Manually create a child transaction with a new reference. The reference of
            //                 # the child transaction was personalized from Adyen and could be identical
            //                 # to that of an existing transaction.
            //                 tx = self._adyen_create_child_tx_from_notification_data(
            //                     source_tx, notification_data
            //                 )
            //     else:  # The capture/void was initiated for an unknown source transaction
            //         pass  # Don't do anything with the capture/void notification
            // else:  # 'REFUND'
            //     # The refund may be initiated from Adyen, so we can't trust the reference, which could
            //     # be identical to another existing transaction. We find the transaction based on the
            //     # provider reference.
            //     tx = self.search(
            //         [('provider_reference', '=', provider_reference), ('provider_code', '=', 'adyen')]
            //     )
            //     if not tx:  # The refund was initiated from Adyen
            //         # Find the source transaction based on the original reference
            //         source_tx = self.search(
            //             [('provider_reference', '=', source_reference), ('provider_code', '=', 'adyen')]
            //         )
            //         if source_tx:
            //             # Manually create a refund transaction with a new reference. The reference of
            //             # the refund transaction was personalized from Adyen and could be identical to
            //             # that of an existing transaction.
            //             tx = self._adyen_create_child_tx_from_notification_data(
            //                 source_tx, notification_data, is_refund=True
            //             )
            //         else:  # The refund was initiated for an unknown source transaction
            //             pass  # Don't do anything with the refund notification
            // 
            // if not tx:
            //     raise ValidationError(
            //         "Adyen: " + _("No transaction found matching reference %s.", reference)
            //     )
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of `payment` to find the transaction based on APS data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction if found.
            // :rtype: recordset of `payment.transaction`
            // :raise ValidationError: If inconsistent data are received.
            // :raise ValidationError: If the data match no transaction.
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'aps' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('merchant_reference')
            // if not reference:
            //     raise ValidationError(
            //         "APS: " + _("Received data with missing reference %(ref)s.", ref=reference)
            //     )
            // 
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'aps')])
            // if not tx:
            //     raise ValidationError(
            //         "APS: " + _("No transaction found matching reference %s.", reference)
            //     )
            // 
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of `payment` to find the transaction based on AsiaPay data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction if found.
            // :rtype: recordset of `payment.transaction`
            // :raise ValidationError: If inconsistent data are received.
            // :raise ValidationError: If the data match no transaction.
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'asiapay' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('Ref')
            // if not reference:
            //     raise ValidationError(
            //         "AsiaPay: " + _("Received data with missing reference %(ref)s.", ref=reference)
            //     )
            // 
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'asiapay')])
            // if not tx:
            //     raise ValidationError(
            //         "AsiaPay: " + _("No transaction found matching reference %s.", reference)
            //     )
            // 
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Find the transaction based on Authorize.net data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict notification_data: The notification data sent by the provider
            // :return: The transaction if found
            // :rtype: recordset of `payment.transaction`
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'authorize' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('reference')
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'authorize')])
            // if not tx:
            //     raise ValidationError(
            //         "Authorize.Net: " + _("No transaction found matching reference %s.", reference)
            //     )
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of payment to find the transaction based on Buckaroo data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict notification_data: The normalized notification data sent by the provider
            // :return: The transaction if found
            // :rtype: recordset of `payment.transaction`
            // :raise: ValidationError if the data match no transaction
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'buckaroo' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('brq_invoicenumber')
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'buckaroo')])
            // if not tx:
            //     raise ValidationError(
            //         "Buckaroo: " + _("No transaction found matching reference %s.", reference)
            //     )
            // 
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of payment to find the transaction based on custom data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict notification_data: The notification feedback data
            // :return: The transaction if found
            // :rtype: recordset of `payment.transaction`
            // :raise: ValidationError if the data match no transaction
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'custom' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('reference')
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'custom')])
            // if not tx:
            //     raise ValidationError(
            //         "Wire Transfer: " + _("No transaction found matching reference %s.", reference)
            //     )
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of payment to find the transaction based on dummy data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict notification_data: The dummy notification data
            // :return: The transaction if found
            // :rtype: recordset of `payment.transaction`
            // :raise: ValidationError if the data match no transaction
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'demo' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('reference')
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'demo')])
            // if not tx:
            //     raise ValidationError(
            //         "Demo: " + _("No transaction found matching reference %s.", reference)
            //     )
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of payment to find the transaction based on Flutterwave data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction if found.
            // :rtype: recordset of `payment.transaction`
            // :raise ValidationError: If inconsistent data were received.
            // :raise ValidationError: If the data match no transaction.
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'flutterwave' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('tx_ref') or notification_data.get('txRef')
            // if not reference:
            //     raise ValidationError("Flutterwave: " + _("Received data with missing reference."))
            // 
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'flutterwave')])
            // if not tx:
            //     raise ValidationError(
            //         "Flutterwave: " + _("No transaction found matching reference %s.", reference)
            //     )
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of `payment` to find the transaction based on Mercado Pago data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction if found.
            // :rtype: recordset of `payment.transaction`
            // :raise ValidationError: If inconsistent data were received.
            // :raise ValidationError: If the data match no transaction.
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'mercado_pago' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('external_reference')
            // if not reference:
            //     raise ValidationError("Mercado Pago: " + _("Received data with missing reference."))
            // 
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'mercado_pago')])
            // if not tx:
            //     raise ValidationError(
            //         "Mercado Pago: " + _("No transaction found matching reference %s.", reference)
            //     )
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of payment to find the transaction based on Mollie data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict notification_data: The notification data sent by the provider
            // :return: The transaction if found
            // :rtype: recordset of `payment.transaction`
            // :raise: ValidationError if the data match no transaction
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'mollie' or len(tx) == 1:
            //     return tx
            // 
            // tx = self.search(
            //     [('reference', '=', notification_data.get('ref')), ('provider_code', '=', 'mollie')]
            // )
            // if not tx:
            //     raise ValidationError("Mollie: " + _(
            //         "No transaction found matching reference %s.", notification_data.get('ref')
            //     ))
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of `payment` to find the transaction based on Nuvei data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction if found.
            // :rtype: payment.transaction
            // :raise ValidationError: If inconsistent data are received.
            // :raise ValidationError: If the data match no transaction.
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'nuvei' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('invoice_id')
            // if not reference:
            //     raise ValidationError(
            //         "Nuvei: " + _("Received data with missing reference.")
            //     )
            // 
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'nuvei')])
            // if not tx:
            //     raise ValidationError(
            //         "Nuvei: " + _("No transaction found matching reference %(ref)s.", ref=reference)
            //     )
            // 
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of `payment` to find the transaction based on Paypal data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction if found.
            // :rtype: payment.transaction
            // :raise ValidationError: If the data match no transaction.
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'paypal' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('reference_id')
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'paypal')])
            // if not tx:
            //     raise ValidationError(
            //         "PayPal: " + _("No transaction found matching reference %s.", reference)
            //     )
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of `payment` to find the transaction based on razorpay data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict notification_data: The normalized notification data sent by the provider
            // :return: The transaction if found
            // :rtype: recordset of `payment.transaction`
            // :raise: ValidationError if the data match no transaction
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'razorpay' or len(tx) == 1:
            //     return tx
            // 
            // entity_type = notification_data.get('entity_type', 'payment')
            // if entity_type == 'payment':
            //     reference = notification_data.get('description')
            //     if not reference:
            //         raise ValidationError("Razorpay: " + _("Received data with missing reference."))
            //     tx = self.search([('reference', '=', reference), ('provider_code', '=', 'razorpay')])
            // else:  # 'refund'
            //     notes = notification_data.get('notes')
            //     reference = isinstance(notes, dict) and notes.get('reference')
            //     if reference:  # The refund was initiated from Odoo.
            //         tx = self.search([('reference', '=', reference), ('provider_code', '=', 'razorpay')])
            //     else:  # The refund was initiated from Razorpay.
            //         # Find the source transaction based on its provider reference.
            //         source_tx = self.search([
            //             ('provider_reference', '=', notification_data['payment_id']),
            //             ('provider_code', '=', 'razorpay'),
            //         ])
            //         if source_tx:
            //             # Manually create a refund transaction with a new reference.
            //             tx = self._razorpay_create_refund_tx_from_notification_data(
            //                 source_tx, notification_data
            //             )
            //         else:  # The refund was initiated for an unknown source transaction.
            //             pass  # Don't do anything with the refund notification.
            // if not tx:
            //     raise ValidationError(
            //         "Razorpay: " + _("No transaction found matching reference %s.", reference)
            //     )
            // 
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of payment to find the transaction based on Stripe data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict notification_data: The notification data sent by the provider
            // :return: The transaction if found
            // :rtype: recordset of `payment.transaction`
            // :raise: ValidationError if inconsistent data were received
            // :raise: ValidationError if the data match no transaction
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'stripe' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('reference')
            // if reference:
            //     tx = self.search([('reference', '=', reference), ('provider_code', '=', 'stripe')])
            // elif notification_data.get('event_type') == 'charge.refund.updated':
            //     # The webhook notifications sent for `charge.refund.updated` events only contain a
            //     # refund object that has no 'description' (the merchant reference) field. We thus search
            //     # the transaction by its provider reference which is the refund id for refund txs.
            //     refund_id = notification_data['object_id']  # The object is a refund.
            //     tx = self.search(
            //         [('provider_reference', '=', refund_id), ('provider_code', '=', 'stripe')]
            //     )
            // else:
            //     raise ValidationError("Stripe: " + _("Received data with missing merchant reference"))
            // 
            // if not tx:
            //     raise ValidationError(
            //         "Stripe: " + _("No transaction found matching reference %s.", reference)
            //     )
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of `payment` to find the transaction based on Worldline data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction if found.
            // :rtype: payment.transaction
            // :raise ValidationError: If inconsistent data are received.
            // :raise ValidationError: If the data match no transaction.
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'worldline' or len(tx) == 1:
            //     return tx
            // 
            // # In case of failed payment, paymentResult could be given as a seperate key
            // payment_result = notification_data.get('paymentResult', notification_data)
            // payment_output = payment_result.get('payment', {}).get('paymentOutput', {})
            // reference = payment_output.get('references', {}).get('merchantReference', '')
            // if not reference:
            //     raise ValidationError(
            //         "Worldline: " + _("Received data with missing reference %(ref)s.", ref=reference)
            //     )
            // 
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'worldline')])
            // if not tx:
            //     raise ValidationError(
            //         "Worldline: " + _("No transaction found matching reference %s.", reference)
            //     )
            // 
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _get_tx_from_notification_data(self, provider_code, notification_data):
            // """ Override of `payment` to find the transaction based on the notification data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction if found.
            // :rtype: payment.transaction
            // :raise ValidationError: If inconsistent data were received.
            // :raise ValidationError: If the data match no transaction.
            // """
            // tx = super()._get_tx_from_notification_data(provider_code, notification_data)
            // if provider_code != 'xendit' or len(tx) == 1:
            //     return tx
            // 
            // reference = notification_data.get('external_id')
            // if not reference:
            //     raise ValidationError("Xendit: " + _("Received data with missing reference."))
            // 
            // tx = self.search([('reference', '=', reference), ('provider_code', '=', 'xendit')])
            // if not tx:
            //     raise ValidationError(
            //         "Xendit: " + _("No transaction found matching reference %s.", reference)
            //     )
            // return tx
            */
            return default;
        }

        protected async Task<PaymentTransaction> HandleNotificationDataInternalAsync(object provider_code, object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _handle_notification_data(self, provider_code, notification_data):
            // """ Match the transaction with the notification data, update its state and return it.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The transaction.
            // :rtype: recordset of `payment.transaction`
            // """
            // tx = self._get_tx_from_notification_data(provider_code, notification_data)
            // tx._process_notification_data(notification_data)
            // return tx
            */
            return default;
        }

        protected async Task<PaymentTransaction> InvoiceSaleOrdersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _invoice_sale_orders(self):
            // for tx in self.filtered(lambda tx: tx.sale_order_ids):
            //     tx = tx.with_company(tx.company_id)
            // 
            //     confirmed_orders = tx.sale_order_ids.filtered(lambda so: so.state == 'sale')
            //     if confirmed_orders:
            //         # Filter orders between those fully paid and those partially paid.
            //         fully_paid_orders = confirmed_orders.filtered(lambda so: so._is_paid())
            // 
            //         # Create a down payment invoice for partially paid orders
            //         downpayment_invoices = (
            //             confirmed_orders - fully_paid_orders
            //         )._generate_downpayment_invoices()
            // 
            //         # For fully paid orders create a final invoice.
            //         fully_paid_orders._force_lines_to_invoice_policy_order()
            //         final_invoices = fully_paid_orders.with_context(
            //             raise_if_nothing_to_invoice=False
            //         )._create_invoices(final=True)
            //         invoices = downpayment_invoices + final_invoices
            // 
            //         # Setup access token in advance to avoid serialization failure between
            //         # edi postprocessing of invoice and displaying the sale order on the portal
            //         for invoice in invoices:
            //             invoice._portal_ensure_token()
            //         tx.invoice_ids = [Command.set(invoices.ids)]
            */
            return default;
        }

        protected async Task<PaymentTransaction> LangGetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        protected async Task<PaymentTransaction> LogMessageOnLinkedDocumentsInternalAsync(object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py) ---
            // def _log_message_on_linked_documents(self, message):
            // """ Log a message on the payment and the invoices linked to the transaction.
            // 
            // For a module to implement payments and link documents to a transaction, it must override
            // this method and call super, then log the message on documents linked to the transaction.
            // 
            // Note: self.ensure_one()
            // 
            // :param str message: The message to be logged
            // :return: None
            // """
            // self.ensure_one()
            // author = self.env.user.partner_id if self.env.uid == SUPERUSER_ID else self.partner_id
            // if self.source_transaction_id:
            //     for invoice in self.source_transaction_id.invoice_ids:
            //         invoice.message_post(body=message, author_id=author.id)
            //     payment_id = self.source_transaction_id.payment_id
            //     if payment_id:
            //         payment_id.message_post(body=message, author_id=author.id)
            // for invoice in self._get_invoices_to_notify():
            //     invoice.message_post(body=message, author_id=author.id)
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _log_message_on_linked_documents(self, message):
            // """ Log a message on the records linked to the transaction.
            // 
            // For a module to implement payments and link documents to a transaction, it must override
            // this method and call it, then log the message on documents linked to the transaction.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param str message: The message to log.
            // :return: None
            // """
            // self.ensure_one()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _log_message_on_linked_documents(self, message):
            // """ Override of payment to log a message on the sales orders linked to the transaction.
            // 
            // Note: self.ensure_one()
            // 
            // :param str message: The message to be logged
            // :return: None
            // """
            // super()._log_message_on_linked_documents(message)
            // author = self.env.user.partner_id if self.env.uid == SUPERUSER_ID else self.partner_id
            // for order in self.sale_order_ids or self.source_transaction_id.sale_order_ids:
            //     order.message_post(body=message, author_id=author.id)
            */
            return default;
        }

        protected async Task<PaymentTransaction> LogReceivedMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _log_received_message(self):
            // """ Log that the transactions have been received in the chatter of relevant documents.
            // 
            // A transaction is 'received' when a payment status is received from the provider handling the
            // transaction.
            // 
            // :return: None
            // """
            // for tx in self:
            //     message = tx._get_received_message()
            //     tx._log_message_on_linked_documents(message)
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py) ---
            // def _log_received_message(self):
            // """ Override of `payment` to remove custom providers from the recordset.
            // 
            // :return: None
            // """
            // other_provider_txs = self.filtered(lambda t: t.provider_code != 'custom')
            // super(PaymentTransaction, other_provider_txs)._log_received_message()
            */
            return default;
        }

        protected async Task<PaymentTransaction> LogSentMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _log_sent_message(self):
            // """ Log that the transactions have been initiated in the chatter of relevant documents.
            // 
            // :return: None
            // """
            // for tx in self:
            //     message = tx._get_sent_message()
            //     tx._log_message_on_linked_documents(message)
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoGetErrorMsgInternalAsync(object status_detail)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _mercado_pago_get_error_msg(self, status_detail):
            // """ Return the error message corresponding to the payment status.
            // 
            // :param str status_detail: The status details sent by the provider.
            // :return: The error message.
            // :rtype: str
            // """
            // return "Mercado Pago: " + const.ERROR_MESSAGE_MAPPING.get(
            //     status_detail, const.ERROR_MESSAGE_MAPPING['cc_rejected_other_reason']
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoPreparePreferenceRequestPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _mercado_pago_prepare_preference_request_payload(self):
            // """ Create the payload for the preference request based on the transaction values.
            // 
            // :return: The request payload.
            // :rtype: dict
            // """
            // base_url = self.provider_id.get_base_url()
            // return_url = urls.url_join(base_url, MercadoPagoController._return_url)
            // sanitized_reference = url_quote(self.reference)
            // webhook_url = urls.url_join(
            //     base_url, f'{MercadoPagoController._webhook_url}/{sanitized_reference}'
            // )  # Append the reference to identify the transaction from the webhook notification data.
            // 
            // unit_price = self.amount
            // decimal_places = const.CURRENCY_DECIMALS.get(self.currency_id.name)
            // if decimal_places is not None:
            //     unit_price = float_round(unit_price, decimal_places, rounding_method='DOWN')
            // 
            // return {
            //     'auto_return': 'all',
            //     'back_urls': {
            //         'success': return_url,
            //         'pending': return_url,
            //         'failure': return_url,
            //     },
            //     'external_reference': self.reference,
            //     'items': [{
            //         'title': self.reference,
            //         'quantity': 1,
            //         'currency_id': self.currency_id.name,
            //         'unit_price': unit_price,
            //     }],
            //     'notification_url': webhook_url,
            //     'payer': {
            //         'name': self.partner_name,
            //         'email': self.partner_email,
            //         'phone': {
            //             'number': self.partner_phone,
            //         },
            //         'address': {
            //             'zip_code': self.partner_zip,
            //             'street_name': self.partner_address,
            //         },
            //     },
            //     'payment_methods': {
            //         'installments': 1,  # Prevent MP from proposing several installments for a payment.
            //     },
            // }
            */
            return default;
        }

        protected async Task<PaymentTransaction> MolliePreparePaymentRequestPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py) ---
            // def _mollie_prepare_payment_request_payload(self):
            // """ Create the payload for the payment request based on the transaction values.
            // 
            // :return: The request payload
            // :rtype: dict
            // """
            // user_lang = self.env.context.get('lang')
            // base_url = self.provider_id.get_base_url()
            // redirect_url = urls.url_join(base_url, MollieController._return_url)
            // webhook_url = urls.url_join(base_url, MollieController._webhook_url)
            // decimal_places = CURRENCY_MINOR_UNITS.get(
            //     self.currency_id.name, self.currency_id.decimal_places
            // )
            // 
            // return {
            //     'description': self.reference,
            //     'amount': {
            //         'currency': self.currency_id.name,
            //         'value': f"{self.amount:.{decimal_places}f}",
            //     },
            //     'locale': user_lang if user_lang in const.SUPPORTED_LOCALES else 'en_US',
            //     'method': [const.PAYMENT_METHODS_MAPPING.get(
            //         self.payment_method_code, self.payment_method_code
            //     )],
            //     # Since Mollie does not provide the transaction reference when returning from
            //     # redirection, we include it in the redirect URL to be able to match the transaction.
            //     'redirectUrl': f'{redirect_url}?ref={self.reference}',
            //     'webhookUrl': f'{webhook_url}?ref={self.reference}',
            // }
            */
            return default;
        }

        protected async Task<PaymentTransaction> PaypalPrepareOrderPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py) ---
            // def _paypal_prepare_order_payload(self):
            // """ Prepare the payload for the Paypal create order request.
            // 
            // :return: The requested payload to create a Paypal order.
            // :rtype: dict
            // """
            // partner_first_name, partner_last_name = payment_utils.split_partner_name(self.partner_name)
            // if self.partner_id.is_public:
            //     invoice_address_vals = {'address': {'country_code': self.company_id.country_code}}
            //     shipping_address_vals = {}
            // else:
            //     invoice_address_vals = paypal_utils.format_partner_address(self.partner_id)
            //     shipping_address_vals = paypal_utils.format_shipping_address(self)
            // shipping_preference = 'SET_PROVIDED_ADDRESS' if shipping_address_vals else 'NO_SHIPPING'
            // 
            // # See https://developer.paypal.com/docs/api/orders/v2/#orders_create!ct=application/json
            // payload = {
            //     'intent': 'CAPTURE',
            //     'purchase_units': [
            //         {
            //             'reference_id': self.reference,
            //             'description': f'{self.company_id.name}: {self.reference}',
            //             'amount': {
            //                 'currency_code': self.currency_id.name,
            //                 'value': self.amount,
            //             },
            //             'payee':  {
            //                 'display_data': {
            //                     'brand_name': self.provider_id.company_id.name,
            //                 },
            //                 'email_address': paypal_utils.get_normalized_email_account(self.provider_id)
            //             },
            //             **shipping_address_vals,
            //         },
            //     ],
            //     'payment_source': {
            //         'paypal': {
            //             'experience_context': {
            //                 'shipping_preference': shipping_preference,
            //             },
            //             'name': {
            //                 'given_name': partner_first_name,
            //                 'surname': partner_last_name,
            //             },
            //             **invoice_address_vals,
            //         },
            //     },
            // }
            // # PayPal does not accept None set to fields and to avoid users getting errors when email
            // # is not set on company we will add it conditionally since its not a required field.
            // if company_email := self.provider_id.company_id.email:
            //     payload['purchase_units'][0]['payee']['display_data']['business_email'] = company_email
            // 
            // return payload
            */
            return default;
        }

        protected async Task<PaymentTransaction> PostProcessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py) ---
            // def _post_process(self):
            // """ Override of `payment` to add account-specific logic to the post-processing.
            // 
            // In particular, for confirmed transactions we write a message in the chatter with the payment
            // and transaction references, post relevant fiscal documents, and create missing payments. For
            // cancelled transactions, we cancel the payment.
            // """
            // super()._post_process()
            // for tx in self.filtered(lambda t: t.state == 'done'):
            //     # Validate invoices automatically once the transaction is confirmed.
            //     self.invoice_ids.filtered(lambda inv: inv.state == 'draft').action_post()
            // 
            //     # Create and post missing payments.
            //     # As there is nothing to reconcile for validation transactions, no payment is created
            //     # for them. This is also true for validations with or without a validity check (transfer
            //     # of a small amount with immediate refund) because validation amounts are not included
            //     # in payouts. As the reconciliation is done in the child transactions for partial voids
            //     # and captures, no payment is created for their source transactions either.
            //     if (
            //         tx.operation != 'validation'
            //         and not tx.payment_id
            //         and not any(child.state in ['done', 'cancel'] for child in tx.child_transaction_ids)
            //     ):
            //         tx.with_company(tx.company_id)._create_payment()
            // 
            //     if tx.payment_id:
            //         message = _(
            //             "The payment related to the transaction with reference %(ref)s has been"
            //             " posted: %(link)s",
            //             ref=tx.reference,
            //             link=tx.payment_id._get_html_link(),
            //         )
            //         tx._log_message_on_linked_documents(message)
            // for tx in self.filtered(lambda t: t.state == 'cancel'):
            //     tx.payment_id.action_cancel()
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _post_process(self):
            // """ Post-process the transactions.
            // 
            // The generic post-processing only consists in flagging the transactions as post-processed.
            // For a module to add its own logic to the post-processing, it must overwrite this method and
            // apply its specific logic to the transactions, optionally after filtering them based on their
            // state.
            // 
            // :return: None
            // """
            // self.is_post_processed = True
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: payment_transaction.py) ---
            // def _post_process(self):
            // """ Override of payment to process POS online payments automatically. """
            // super()._post_process()
            // self._process_pos_online_payment()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _post_process(self):
            // """ Override of `payment` to add Sales-specific logic to the post-processing.
            // 
            // In particular, for pending transactions, we send the quotation by email; for authorized
            // transactions, we confirm the quotation; for confirmed transactions, we automatically confirm
            // the quotation and generate invoices.
            // """
            // for pending_tx in self.filtered(lambda tx: tx.state == 'pending'):
            //     super(PaymentTransaction, pending_tx)._post_process()
            //     sales_orders = pending_tx.sale_order_ids.filtered(
            //         lambda so: so.state in ['draft', 'sent']
            //     )
            //     sales_orders.filtered(
            //         lambda so: so.state == 'draft'
            //     ).with_context(tracking_disable=True).action_quotation_sent()
            // 
            //     if pending_tx.provider_id.code == 'custom':
            //         for order in pending_tx.sale_order_ids:
            //             order.reference = pending_tx._compute_sale_order_reference(order)
            // 
            //     if pending_tx.operation == 'validation':
            //         continue
            //     # Send the payment status email.
            //     # The transactions are manually cached while in a sudoed environment to prevent an
            //     # AccessError: In some circumstances, sending the mail would generate the report assets
            //     # during the rendering of the mail body, causing a cursor commit, a flush, and forcing
            //     # the re-computation of the pending computed fields of the `mail.compose.message`,
            //     # including part of the template. Since that template reads the order's transactions and
            //     # the re-computation of the field is not done with the same environment, reading fields
            //     # that were not already available in the cache could trigger an AccessError (e.g., if
            //     # the payment was initiated by a public user).
            //     sales_orders.mapped('transaction_ids')
            //     sales_orders._send_payment_succeeded_for_order_mail()
            // 
            // for authorized_tx in self.filtered(lambda tx: tx.state == 'authorized'):
            //     super(PaymentTransaction, authorized_tx)._post_process()
            //     confirmed_orders = authorized_tx._check_amount_and_confirm_order()
            //     if authorized_tx.operation == 'validation':
            //         continue
            //     if remaining_orders := (authorized_tx.sale_order_ids - confirmed_orders):
            //         remaining_orders._send_payment_succeeded_for_order_mail()
            // 
            // super(PaymentTransaction, self.filtered(
            //     lambda tx: tx.state not in ['pending', 'authorized', 'done'])
            // )._post_process()
            // 
            // for done_tx in self.filtered(lambda tx: tx.state == 'done'):
            //     confirmed_orders = done_tx._check_amount_and_confirm_order()
            //     if done_tx.operation == 'validation':
            //         continue
            //     (done_tx.sale_order_ids - confirmed_orders)._send_payment_succeeded_for_order_mail()
            // 
            //     auto_invoice = str2bool(
            //         self.env['ir.config_parameter'].sudo().get_param('sale.automatic_invoice')
            //     )
            //     if auto_invoice:
            //         # Invoice the sales orders of confirmed transactions instead of only confirmed
            //         # orders to create the invoice even if only a partial payment was made.
            //         done_tx._invoice_sale_orders()
            //     super(PaymentTransaction, done_tx)._post_process()  # Post the invoices.
            //     if auto_invoice:
            //         if (
            //             str2bool(self.env['ir.config_parameter'].sudo().get_param('sale.async_emails'))
            //             and (send_invoice_cron := self.env.ref('sale.send_invoice_cron', raise_if_not_found=False))
            //         ):
            //             send_invoice_cron._trigger()
            //         else:
            //             self._send_invoice()
            --- ODOO METHOD SOURCE (MODULE: website_payment, FILE: payment_transaction.py) ---
            // def _post_process(self):
            // super()._post_process()
            // for donation_tx in self.filtered(lambda tx: tx.state == 'done' and tx.is_donation):
            //     donation_tx._send_donation_email()
            //     msg = [_('Payment received from donation with following details:')]
            //     for field in ['company_id', 'partner_id', 'partner_name', 'partner_country_id', 'partner_email']:
            //         field_name = donation_tx._fields[field].string
            //         value = donation_tx[field]
            //         if value:
            //             if hasattr(value, 'name'):
            //                 value = value.name
            //             msg.append(Markup('<br/>- %s: %s') % (field_name, value))
            //     donation_tx.payment_id._message_log(body=Markup().join(msg))
            --- ODOO METHOD SOURCE (MODULE: website_sale_collect, FILE: payment_transaction.py) ---
            // def _post_process(self):
            // """ Override of `payment` to confirm orders with the on_site payment method and trigger
            // a picking creation. """
            // on_site_pending_txs = self.filtered(
            //     lambda tx: tx.provider_id.custom_mode == 'on_site' and tx.state == 'pending'
            // )
            // on_site_pending_txs.sale_order_ids.filtered(
            //     lambda so: so.state == 'draft'
            // ).with_context(send_email=True).action_confirm()
            // super()._post_process()
            */
            return default;
        }

        protected async Task<PaymentTransaction> ProcessNotificationDataInternalAsync(object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Update the transaction state and the provider reference based on the notification data.
            // 
            // This method should usually not be called directly. The correct method to call upon receiving
            // notification data is :meth:`_handle_notification_data`.
            // 
            // For a provider to handle transaction processing, it must overwrite this method and process
            // the notification data.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // """
            // self.ensure_one()
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of payment to process the transaction based on Adyen data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider
            // :return: None
            // :raise: ValidationError if inconsistent data were received
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'adyen':
            //     return
            // 
            // # Extract or assume the event code. If none is provided, the feedback data originate from a
            // # direct payment request whose feedback data share the same payload as an 'AUTHORISATION'
            // # webhook notification.
            // event_code = notification_data.get('eventCode', 'AUTHORISATION')
            // 
            // # Update the provider reference. If the event code is 'CAPTURE' or 'CANCELLATION', we
            // # discard the pspReference as it is different from the original pspReference of the tx.
            // if 'pspReference' in notification_data and event_code in ['AUTHORISATION', 'REFUND']:
            //     self.provider_reference = notification_data.get('pspReference')
            // 
            // # Update the payment method.
            // payment_method_data = notification_data.get('paymentMethod', '')
            // if isinstance(payment_method_data, dict):  # Not from webhook: the data contain the PM code.
            //     payment_method_type = payment_method_data['type']
            //     if payment_method_type == 'scheme':  # card
            //         payment_method_code = payment_method_data['brand']
            //     else:
            //         payment_method_code = payment_method_type
            // else:  # Sent from the webhook: the PM code is directly received as a string.
            //     payment_method_code = payment_method_data
            // 
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_state = notification_data.get('resultCode')
            // refusal_reason = notification_data.get('refusalReason') or notification_data.get('reason')
            // if not payment_state:
            //     raise ValidationError("Adyen: " + _("Received data with missing payment state."))
            // if payment_state in const.RESULT_CODES_MAPPING['pending']:
            //     self._set_pending()
            // elif payment_state in const.RESULT_CODES_MAPPING['done']:
            //     additional_data = notification_data.get('additionalData', {})
            //     has_token_data = 'recurring.recurringDetailReference' in additional_data
            //     if self.tokenize and has_token_data:
            //         self._adyen_tokenize_from_notification_data(notification_data)
            // 
            //     if not self.provider_id.capture_manually:
            //         self._set_done()
            //     else:  # The payment was configured for manual capture.
            //         # Differentiate the state based on the event code.
            //         if event_code == 'AUTHORISATION':
            //             self._set_authorized()
            //         else:  # 'CAPTURE'
            //             self._set_done()
            // 
            //     # Immediately post-process the transaction if it is a refund, as the post-processing
            //     # will not be triggered by a customer browsing the transaction from the portal.
            //     if self.operation == 'refund':
            //         self.env.ref('payment.cron_post_process_payment_tx')._trigger()
            // elif payment_state in const.RESULT_CODES_MAPPING['cancel']:
            //     self._set_canceled()
            // elif payment_state in const.RESULT_CODES_MAPPING['error']:
            //     if event_code in ['AUTHORISATION', 'REFUND']:
            //         _logger.warning(
            //             "the transaction with reference %s underwent an error. reason: %s",
            //             self.reference, refusal_reason,
            //         )
            //         self._set_error(
            //             _("An error occurred during the processing of your payment. Please try again.")
            //         )
            //     elif event_code == 'CANCELLATION':
            //         _logger.warning(
            //             "The void of the transaction with reference %s failed. reason: %s",
            //             self.reference, refusal_reason,
            //         )
            //         if self.source_transaction_id:  # child tx => The event can't be retried.
            //             self._set_error(
            //                 _("The void of the transaction with reference %s failed.", self.reference)
            //             )
            //         else:  # source tx with failed void stays in its state, could be voided again
            //             self._log_message_on_linked_documents(
            //                 _("The void of the transaction with reference %s failed.", self.reference)
            //             )
            //     else:  # 'CAPTURE', 'CAPTURE_FAILED'
            //         _logger.warning(
            //             "The capture of the transaction with reference %s failed. reason: %s",
            //             self.reference, refusal_reason,
            //         )
            //         if self.source_transaction_id:  # child_tx => The event can't be retried.
            //             self._set_error(_(
            //                 "The capture of the transaction with reference %s failed.", self.reference
            //             ))
            //         else:  # source tx with failed capture stays in its state, could be captured again
            //             self._log_message_on_linked_documents(_(
            //                 "The capture of the transaction with reference %s failed.", self.reference
            //             ))
            // elif payment_state in const.RESULT_CODES_MAPPING['refused']:
            //     _logger.warning(
            //         "the transaction with reference %s was refused. reason: %s",
            //         self.reference, refusal_reason
            //     )
            //     self._set_error(_("Your payment was refused. Please try again."))
            // else:  # Classify unsupported payment state as `error` tx state
            //     _logger.warning(
            //         "received data for transaction with reference %s with invalid payment state: %s",
            //         self.reference, payment_state
            //     )
            //     self._set_error(
            //         "Adyen: " + _("Received data with invalid payment state: %s", payment_state)
            //     )
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of `payment' to process the transaction based on APS data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // :raise ValidationError: If inconsistent data are received.
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'aps':
            //     return
            // 
            // # Update the provider reference.
            // self.provider_reference = notification_data.get('fort_id')
            // 
            // # Update the payment method.
            // payment_option = notification_data.get('payment_option', '')
            // payment_method = self.env['payment.method']._get_from_code(payment_option.lower())
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status = notification_data.get('status')
            // if not status:
            //     raise ValidationError("APS: " + _("Received data with missing payment state."))
            // if status in PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif status in PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // else:  # Classify unsupported payment state as `error` tx state.
            //     status_description = notification_data.get('response_message')
            //     _logger.info(
            //         "Received data with invalid payment status (%(status)s) and reason '%(reason)s' "
            //         "for transaction with reference %(ref)s",
            //         {'status': status, 'reason': status_description, 'ref': self.reference},
            //     )
            //     self._set_error("APS: " + _(
            //         "Received invalid transaction status %(status)s and reason '%(reason)s'.",
            //         status=status, reason=status_description
            //     ))
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of `payment' to process the transaction based on AsiaPay data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // :raise ValidationError: If inconsistent data are received.
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'asiapay':
            //     return
            // 
            // # Update the provider reference.
            // self.provider_reference = notification_data.get('PayRef')
            // 
            // # Update the payment method.
            // payment_method_code = notification_data.get('payMethod')
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // success_code = notification_data.get('successcode')
            // primary_response_code = notification_data.get('prc')
            // if not success_code:
            //     raise ValidationError("AsiaPay: " + _("Received data with missing success code."))
            // if success_code in const.SUCCESS_CODE_MAPPING['done']:
            //     self._set_done()
            // elif success_code in const.SUCCESS_CODE_MAPPING['error']:
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (success code %(success_code)s; primary "
            //         "response code %(response_code)s). Please try again.", success_code=success_code, response_code=primary_response_code,
            //     ))
            // else:
            //     _logger.warning(
            //         "Received data with invalid success code (%s) for transaction with primary response "
            //         "code %s and reference %s.", success_code, primary_response_code, self.reference
            //     )
            //     self._set_error("AsiaPay: " + _("Unknown success code: %s", success_code))
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of payment to process the transaction based on Authorize data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider
            // :return: None
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'authorize':
            //     return
            // 
            // response_content = notification_data.get('response')
            // 
            // # Update the provider reference.
            // self.provider_reference = response_content.get('x_trans_id')
            // 
            // # Update the payment method.
            // payment_method_code = response_content.get('payment_method_code', '').lower()
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status_code = response_content.get('x_response_code', '3')
            // if status_code == '1':  # Approved
            //     status_type = response_content.get('x_type').lower()
            //     if status_type in ('auth_capture', 'prior_auth_capture'):
            //         self._set_done()
            //         if self.tokenize and not self.token_id:
            //             self._authorize_tokenize()
            //     elif status_type == 'auth_only':
            //         self._set_authorized()
            //         if self.tokenize and not self.token_id:
            //             self._authorize_tokenize()
            //         if self.operation == 'validation':
            //             self._send_void_request()  # In last step because it processes the response.
            //     elif status_type == 'void':
            //         if self.operation == 'validation':  # Validation txs are authorized and then voided
            //             self._set_done()  # If the refund went through, the validation tx is confirmed
            //         else:
            //             self._set_canceled(extra_allowed_states=('done',))
            //     elif status_type == 'refund' and self.operation == 'refund':
            //         self._set_done()
            //         # Immediately post-process the transaction as the post-processing will not be
            //         # triggered by a customer browsing the transaction from the portal.
            //         self.env.ref('payment.cron_post_process_payment_tx')._trigger()
            // elif status_code == '2':  # Declined
            //     self._set_canceled(state_message=response_content.get('x_response_reason_text'))
            // elif status_code == '4':  # Held for Review
            //     self._set_pending()
            // else:  # Error / Unknown code
            //     error_code = response_content.get('x_response_reason_text')
            //     _logger.info(
            //         "received data with invalid status (%(status)s) and error code (%(err)s) for "
            //         "transaction with reference %(ref)s",
            //         {
            //             'status': status_code,
            //             'err': error_code,
            //             'ref': self.reference,
            //         },
            //     )
            //     self._set_error(
            //         "Authorize.Net: " + _(
            //             "Received data with status code \"%(status)s\" and error code \"%(error)s\"",
            //             status=status_code, error=error_code
            //         )
            //     )
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of payment to process the transaction based on Buckaroo data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The normalized notification data sent by the provider
            // :return: None
            // :raise: ValidationError if inconsistent data were received
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'buckaroo':
            //     return
            // 
            // # Update the provider reference.
            // transaction_keys = notification_data.get('brq_transactions')
            // if not transaction_keys:
            //     raise ValidationError("Buckaroo: " + _("Received data with missing transaction keys"))
            // # BRQ_TRANSACTIONS can hold multiple, comma-separated, tx keys. In practice, it holds only
            // # one reference. So we split for semantic correctness and keep the first transaction key.
            // self.provider_reference = transaction_keys.split(',')[0]
            // 
            // # Update the payment method.
            // payment_method_code = notification_data.get('brq_payment_method')
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status_code = int(notification_data.get('brq_statuscode') or 0)
            // if status_code in const.STATUS_CODES_MAPPING['pending']:
            //     self._set_pending()
            // elif status_code in const.STATUS_CODES_MAPPING['done']:
            //     self._set_done()
            // elif status_code in const.STATUS_CODES_MAPPING['cancel']:
            //     self._set_canceled()
            // elif status_code in const.STATUS_CODES_MAPPING['refused']:
            //     self._set_error(_("Your payment was refused (code %s). Please try again.", status_code))
            // elif status_code in const.STATUS_CODES_MAPPING['error']:
            //     self._set_error(_(
            //         "An error occurred during processing of your payment (code %s). Please try again.",
            //         status_code,
            //     ))
            // else:
            //     _logger.warning(
            //         "received data with invalid payment status (%s) for transaction with reference %s",
            //         status_code, self.reference
            //     )
            //     self._set_error("Buckaroo: " + _("Unknown status code: %s", status_code))
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of payment to process the transaction based on custom data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The custom data
            // :return: None
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'custom':
            //     return
            // 
            // _logger.info(
            //     "validated custom payment for transaction with reference %s: set as pending",
            //     self.reference
            // )
            // self._set_pending()
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of payment to process the transaction based on dummy data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The dummy notification data
            // :return: None
            // :raise: ValidationError if inconsistent data were received
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'demo':
            //     return
            // 
            // # Update the provider reference.
            // self.provider_reference = f'demo-{self.reference}'
            // 
            // # Create the token.
            // if self.tokenize:
            //     # The reasons why we immediately tokenize the transaction regardless of the state rather
            //     # than waiting for the payment method to be validated ('authorized' or 'done') like the
            //     # other payment providers do are:
            //     # - To save the simulated state and payment details on the token while we have them.
            //     # - To allow customers to create tokens whose transactions will always end up in the
            //     #   said simulated state.
            //     self._demo_tokenize_from_notification_data(notification_data)
            // 
            // # Update the payment state.
            // state = notification_data['simulated_state']
            // if state == 'pending':
            //     self._set_pending()
            // elif state == 'done':
            //     if self.capture_manually and not notification_data.get('manual_capture'):
            //         self._set_authorized()
            //     else:
            //         self._set_done()
            //         # Immediately post-process the transaction if it is a refund, as the post-processing
            //         # will not be triggered by a customer browsing the transaction from the portal.
            //         if self.operation == 'refund':
            //             self.env.ref('payment.cron_post_process_payment_tx')._trigger()
            // elif state == 'cancel':
            //     self._set_canceled()
            // else:  # Simulate an error state.
            //     self._set_error(_("You selected the following demo payment status: %s", state))
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of payment to process the transaction based on Flutterwave data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // :raise ValidationError: If inconsistent data were received.
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'flutterwave':
            //     return
            // 
            // # Verify the notification data.
            // verification_response_content = self.provider_id._flutterwave_make_request(
            //     'transactions/verify_by_reference', payload={'tx_ref': self.reference}, method='GET'
            // )
            // verified_data = verification_response_content['data']
            // 
            // # Update the provider reference.
            // self.provider_reference = verified_data['id']
            // 
            // # Update payment method.
            // payment_method_type = verified_data.get('payment_type', '')
            // if payment_method_type == 'card':
            //     payment_method_type = verified_data.get('card', {}).get('type').lower()
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_type, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_status = verified_data['status'].lower()
            // if payment_status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     auth_url = notification_data.get('meta', {}).get('authorization', {}).get('redirect')
            //     if auth_url:
            //         # will be set back to the actual value after moving away from pending
            //         self.provider_reference = auth_url
            //     self._set_pending()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            //     has_token_data = 'token' in verified_data.get('card', {})
            //     if self.tokenize and has_token_data:
            //         self._flutterwave_tokenize_from_notification_data(verified_data)
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['cancel']:
            //     self._set_canceled()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['error']:
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (status %s). Please try "
            //         "again.", payment_status
            //     ))
            // else:
            //     _logger.warning(
            //         "Received data with invalid payment status (%s) for transaction with reference %s.",
            //         payment_status, self.reference
            //     )
            //     self._set_error("Flutterwave: " + _("Unknown payment status: %s", payment_status))
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of `payment` to process the transaction based on Mercado Pago data.
            // 
            // Note: self.ensure_one() from `_process_notification_data`
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // :raise ValidationError: If inconsistent data were received.
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'mercado_pago':
            //     return
            // 
            // # Update the provider reference.
            // payment_id = notification_data.get('payment_id')
            // if not payment_id:
            //     raise ValidationError("Mercado Pago: " + _("Received data with missing payment id."))
            // self.provider_reference = payment_id
            // 
            // # Verify the notification data.
            // verified_payment_data = self.provider_id._mercado_pago_make_request(
            //     f'/v1/payments/{self.provider_reference}', method='GET'
            // )
            // 
            // # Update the payment method.
            // payment_method_type = verified_payment_data.get('payment_type_id', '')
            // for odoo_code, mp_codes in const.PAYMENT_METHODS_MAPPING.items():
            //     if any(payment_method_type == mp_code for mp_code in mp_codes.split(',')):
            //         payment_method_type = odoo_code
            //         break
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_type, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // # Fall back to "unknown" if the payment method is not found (and if "unknown" is found), as
            // # the user might have picked a different payment method than on Odoo's payment form.
            // if not payment_method:
            //     payment_method = self.env['payment.method'].search([('code', '=', 'unknown')], limit=1)
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_status = verified_payment_data.get('status')
            // if not payment_status:
            //     raise ValidationError("Mercado Pago: " + _("Received data with missing status."))
            // 
            // if payment_status in const.TRANSACTION_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif payment_status in const.TRANSACTION_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif payment_status in const.TRANSACTION_STATUS_MAPPING['canceled']:
            //     self._set_canceled()
            // elif payment_status in const.TRANSACTION_STATUS_MAPPING['error']:
            //     status_detail = verified_payment_data.get('status_detail')
            //     _logger.warning(
            //         "Received data for transaction with reference %s with status %s and error code: %s",
            //         self.reference, payment_status, status_detail
            //     )
            //     error_message = self._mercado_pago_get_error_msg(status_detail)
            //     self._set_error(error_message)
            // else:  # Classify unsupported payment status as the `error` tx state.
            //     _logger.warning(
            //         "Received data for transaction with reference %s with invalid payment status: %s",
            //         self.reference, payment_status
            //     )
            //     self._set_error(
            //         "Mercado Pago: " + _("Received data with invalid status: %s", payment_status)
            //     )
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of payment to process the transaction based on Mollie data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider
            // :return: None
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'mollie':
            //     return
            // 
            // payment_data = self.provider_id._mollie_make_request(
            //     f'/payments/{self.provider_reference}', method="GET"
            // )
            // 
            // # Update the payment method.
            // payment_method_type = payment_data.get('method', '')
            // if payment_method_type == 'creditcard':
            //     payment_method_type = payment_data.get('details', {}).get('cardLabel', '').lower()
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_type, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_status = payment_data.get('status')
            // if payment_status == 'pending':
            //     self._set_pending()
            // elif payment_status == 'authorized':
            //     self._set_authorized()
            // elif payment_status == 'paid':
            //     self._set_done()
            // elif payment_status in ['expired', 'canceled', 'failed']:
            //     self._set_canceled("Mollie: " + _("Cancelled payment with status: %s", payment_status))
            // else:
            //     _logger.info(
            //         "received data with invalid payment status (%s) for transaction with reference %s",
            //         payment_status, self.reference
            //     )
            //     self._set_error(
            //         "Mollie: " + _("Received data with invalid payment status: %s", payment_status)
            //     )
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of `payment` to process the transaction based on Nuvei data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // :raise ValidationError: If inconsistent data are received.
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'nuvei':
            //     return
            // 
            // if not notification_data:
            //     self._set_canceled(state_message=_("The customer left the payment page."))
            //     return
            // 
            // # Update the provider reference.
            // self.provider_reference = notification_data.get('TransactionID')
            // 
            // # Update the payment method.
            // payment_option = notification_data.get('payment_method', '')
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_option.lower(), mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status = notification_data.get('Status') or notification_data.get('ppp_status')
            // if not status:
            //     raise ValidationError("Nuvei: " + _("Received data with missing payment state."))
            // status = status.lower()
            // if status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif status in const.PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif status in const.PAYMENT_STATUS_MAPPING['error']:
            //     failure_reason = notification_data.get('Reason') or notification_data.get('message')
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (%(reason)s). Please try"
            //         " again.", reason=failure_reason,
            //     ))
            // else:  # Classify unsupported payment states as the `error` tx state.
            //     status_description = notification_data.get('Reason')
            //     _logger.info(
            //         "Received data with invalid payment status (%(status)s) and reason '%(reason)s' "
            //         "for transaction with reference %(ref)s",
            //         {'status': status, 'reason': status_description, 'ref': self.reference},
            //     )
            //     self._set_error("Nuvei: " + _(
            //         "Received invalid transaction status %(status)s and reason '%(reason)s'.",
            //         status=status, reason=status_description
            //     ))
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of `payment` to process the transaction based on Paypal data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // :raise ValidationError: If inconsistent data were received.
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'paypal':
            //     return
            // 
            // if not notification_data:
            //     self._set_canceled(state_message=_("The customer left the payment page."))
            //     return
            // 
            // amount = notification_data.get('amount').get('value')
            // currency_code = notification_data.get('amount').get('currency_code')
            // assert amount and currency_code, "PayPal: missing amount or currency"
            // assert self.currency_id.compare_amounts(float(amount), self.amount) == 0, \
            //     "PayPal: mismatching amounts"
            // assert currency_code == self.currency_id.name, "PayPal: mismatching currency codes"
            // 
            // # Update the provider reference.
            // txn_id = notification_data.get('id')
            // txn_type = notification_data.get('txn_type')
            // if not all((txn_id, txn_type)):
            //     raise ValidationError(
            //         "PayPal: " + _(
            //             "Missing value for txn_id (%(txn_id)s) or txn_type (%(txn_type)s).",
            //             txn_id=txn_id, txn_type=txn_type
            //         )
            //     )
            // self.provider_reference = txn_id
            // self.paypal_type = txn_type
            // 
            // # Force PayPal as the payment method if it exists.
            // self.payment_method_id = self.env['payment.method'].search(
            //     [('code', '=', 'paypal')], limit=1
            // ) or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_status = notification_data.get('status')
            // 
            // if payment_status in PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending(state_message=notification_data.get('pending_reason'))
            // elif payment_status in PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif payment_status in PAYMENT_STATUS_MAPPING['cancel']:
            //     self._set_canceled()
            // else:
            //     _logger.info(
            //         "received data with invalid payment status (%s) for transaction with reference %s",
            //         payment_status, self.reference
            //     )
            //     self._set_error(
            //         "PayPal: " + _("Received data with invalid payment status: %s", payment_status)
            //     )
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of `payment` to process the transaction based on Razorpay data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider
            // :return: None
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'razorpay':
            //     return
            // 
            // if 'id' in notification_data:  # We have the full entity data (S2S request or webhook).
            //     entity_data = notification_data
            // else:  # The payment data are not complete (Payments made by a token).
            //     # Fetch the full payment data.
            //     entity_data = self.provider_id._razorpay_make_request(
            //         f'payments/{notification_data["razorpay_payment_id"]}', method='GET'
            //     )
            //     _logger.info(
            //         "Response of '/payments' request for transaction with reference %s:\n%s",
            //         self.reference, pprint.pformat(entity_data)
            //     )
            // 
            // # Update the provider reference.
            // entity_id = entity_data.get('id')
            // if not entity_id:
            //     raise ValidationError("Razorpay: " + _("Received data with missing entity id."))
            // # One reference can have multiple entity ids as Razorpay allows retry on payment failure.
            // # Making sure the last entity id is the one we have in the provider reference.
            // allowed_to_modify = self.state not in ('done', 'authorized')
            // if allowed_to_modify:
            //     self.provider_reference = entity_id
            // 
            // # Update the payment method.
            // payment_method_type = entity_data.get('method', '')
            // if payment_method_type == 'card':
            //     payment_method_type = entity_data.get('card', {}).get('network', '').lower()
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_type, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // if allowed_to_modify and payment_method:
            //     self.payment_method_id = payment_method
            // 
            // # Update the payment state.
            // entity_status = entity_data.get('status')
            // if not entity_status:
            //     raise ValidationError("Razorpay: " + _("Received data with missing status."))
            // 
            // if entity_status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif entity_status in const.PAYMENT_STATUS_MAPPING['authorized']:
            //     if self.provider_id.capture_manually:
            //         self._set_authorized()
            // elif entity_status in const.PAYMENT_STATUS_MAPPING['done']:
            //     if (
            //         not self.token_id
            //         and entity_data.get('token_id')
            //         and self.provider_id.allow_tokenization
            //     ):
            //         self._razorpay_tokenize_from_notification_data(entity_data)
            //     self._set_done()
            // 
            //     # Immediately post-process the transaction if it is a refund, as the post-processing
            //     # will not be triggered by a customer browsing the transaction from the portal.
            //     if self.operation == 'refund':
            //         self.env.ref('payment.cron_post_process_payment_tx')._trigger()
            // elif entity_status in const.PAYMENT_STATUS_MAPPING['error']:
            //     _logger.warning(
            //         "The transaction with reference %s underwent an error. Reason: %s",
            //         self.reference, entity_data.get('error_description')
            //     )
            //     self._set_error(
            //         _("An error occurred during the processing of your payment. Please try again.")
            //     )
            // else:  # Classify unsupported payment status as the `error` tx state.
            //     _logger.warning(
            //         "Received data for transaction with reference %s with invalid payment status: %s",
            //         self.reference, entity_status
            //     )
            //     self._set_error(
            //         "Razorpay: " + _("Received data with invalid status: %s", entity_status)
            //     )
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of `payment` to process the transaction based on Stripe data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data build from information passed to the
            //                                return route. Depending on the operation of the transaction,
            //                                the entries with the keys 'payment_intent', 'setup_intent'
            //                                and 'payment_method' can be populated with their
            //                                corresponding Stripe API objects.
            // :return: None
            // :raise: ValidationError if inconsistent data were received
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'stripe':
            //     return
            // 
            // # Update the payment method.
            // payment_method = notification_data.get('payment_method')
            // if isinstance(payment_method, dict):  # capture/void/refund requests receive a string.
            //     payment_method_type = payment_method.get('type')
            //     if self.payment_method_id.code == payment_method_type == 'card':
            //         payment_method_type = notification_data['payment_method']['card']['brand']
            //     payment_method = self.env['payment.method']._get_from_code(
            //         payment_method_type, mapping=const.PAYMENT_METHODS_MAPPING
            //     )
            //     self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the provider reference and the payment state.
            // if self.operation == 'validation':
            //     self.provider_reference = notification_data['setup_intent']['id']
            //     status = notification_data['setup_intent']['status']
            // elif self.operation == 'refund':
            //     self.provider_reference = notification_data['refund']['id']
            //     status = notification_data['refund']['status']
            // else:  # 'online_direct', 'online_token', 'offline'
            //     self.provider_reference = notification_data['payment_intent']['id']
            //     status = notification_data['payment_intent']['status']
            // if not status:
            //     raise ValidationError(
            //         "Stripe: " + _("Received data with missing intent status.")
            //     )
            // if status in const.STATUS_MAPPING['draft']:
            //     pass
            // elif status in const.STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif status in const.STATUS_MAPPING['authorized']:
            //     if self.tokenize:
            //         self._stripe_tokenize_from_notification_data(notification_data)
            //     self._set_authorized()
            // elif status in const.STATUS_MAPPING['done']:
            //     if self.tokenize:
            //         self._stripe_tokenize_from_notification_data(notification_data)
            // 
            //     self._set_done()
            // 
            //     # Immediately post-process the transaction if it is a refund, as the post-processing
            //     # will not be triggered by a customer browsing the transaction from the portal.
            //     if self.operation == 'refund':
            //         self.env.ref('payment.cron_post_process_payment_tx')._trigger()
            // elif status in const.STATUS_MAPPING['cancel']:
            //     self._set_canceled()
            // elif status in const.STATUS_MAPPING['error']:
            //     if self.operation != 'refund':
            //         last_payment_error = notification_data.get('payment_intent', {}).get(
            //             'last_payment_error'
            //         )
            //         if last_payment_error:
            //             message = last_payment_error.get('message', {})
            //         else:
            //             message = _("The customer left the payment page.")
            //         self._set_error(message)
            //     else:
            //         self._set_error(_(
            //             "The refund did not go through. Please log into your Stripe Dashboard to get "
            //             "more information on that matter, and address any accounting discrepancies."
            //         ), extra_allowed_states=('done',))
            // else:  # Classify unknown intent statuses as `error` tx state
            //     _logger.warning(
            //         "received invalid payment status (%s) for transaction with reference %s",
            //         status, self.reference
            //     )
            //     self._set_error(_("Received data with invalid intent status: %s", status))
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of `payment' to process the transaction based on Worldline data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // :raise ValidationError: If inconsistent data are received.
            // """
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'worldline':
            //     return
            // 
            // # In case of failed payment, paymentResult could be given as a seperate key
            // payment_result = notification_data.get('paymentResult', notification_data)
            // payment_data = payment_result.get('payment', {})
            // 
            // # Update the provider reference.
            // self.provider_reference = payment_data.get('id', '').rsplit('_', 1)[0]
            // 
            // # Update the payment method.
            // payment_output = payment_data.get('paymentOutput', {})
            // if 'cardPaymentMethodSpecificOutput' in payment_output:
            //     payment_method_data = payment_output['cardPaymentMethodSpecificOutput']
            // else:
            //     payment_method_data = payment_output.get('redirectPaymentMethodSpecificOutput', {})
            // payment_method_code = payment_method_data.get('paymentProductId', '')
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status = payment_data.get('status')
            // has_token_data = 'token' in payment_method_data
            // if not status:
            //     raise ValidationError("Worldline: " + _("Received data with missing payment state."))
            // 
            // if status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     if status == 'AUTHORIZATION_REQUESTED':
            //         self._set_error("Worldline: " + status)
            //     elif self.operation == 'validation' \
            //          and status in {'PENDING_CAPTURE', 'CAPTURE_REQUESTED'} \
            //          and has_token_data:
            //             self._worldline_tokenize_from_notification_data(payment_method_data)
            //             self._set_done()
            //     else:
            //         self._set_pending()
            // elif status in const.PAYMENT_STATUS_MAPPING['done']:
            //     if self.tokenize and has_token_data:
            //         self._worldline_tokenize_from_notification_data(payment_method_data)
            //     self._set_done()
            // else:
            //     error_code = None
            //     if errors := payment_data.get('statusOutput', {}).get('errors'):
            //         error_code = errors[0].get('errorCode')
            //     if status in const.PAYMENT_STATUS_MAPPING['cancel']:
            //         self._set_canceled("Worldline: " + _(
            //             "Transaction cancelled with error code %(error_code)s.",
            //             error_code=error_code,
            //         ))
            //     elif status in const.PAYMENT_STATUS_MAPPING['declined']:
            //         self._set_error("Worldline: " + _(
            //             "Transaction declined with error code %(error_code)s.",
            //             error_code=error_code,
            //         ))
            //     else:  # Classify unsupported payment status as the `error` tx state.
            //         _logger.info(
            //             "Received data with invalid payment status (%(status)s) for transaction with "
            //             "reference %(ref)s.",
            //             {'status': status, 'ref': self.reference},
            //         )
            //         self._set_error("Worldline: " + _(
            //             "Received invalid transaction status %(status)s with error code "
            //             "%(error_code)s.",
            //             status=status,
            //             error_code=error_code,
            //         ))
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _process_notification_data(self, notification_data):
            // """ Override of `payment` to process the transaction based on Xendit data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict notification_data: The notification data sent by the provider.
            // :return: None
            // :raise ValidationError: If inconsistent data were received.
            // """
            // self.ensure_one()
            // 
            // super()._process_notification_data(notification_data)
            // if self.provider_code != 'xendit':
            //     return
            // 
            // # Update the provider reference.
            // self.provider_reference = notification_data.get('id')
            // 
            // # Update payment method.
            // payment_method_code = notification_data.get('payment_method', '')
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_status = notification_data.get('status')
            // if payment_status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['done']:
            //     if self.tokenize:
            //         self._xendit_tokenize_from_notification_data(notification_data)
            //     self._set_done()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['cancel']:
            //     self._set_canceled()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['error']:
            //     failure_reason = notification_data.get('failure_reason')
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (%s). Please try again.",
            //         failure_reason,
            //     ))
            */
            return default;
        }

        protected async Task<PaymentTransaction> ProcessPosOnlinePaymentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: payment_transaction.py) ---
            // def _process_pos_online_payment(self):
            // for tx in self:
            //     if tx and tx.pos_order_id and tx.state in ('authorized', 'done') and not tx.payment_id.pos_order_id:
            //         pos_order = tx.pos_order_id
            //         if tools.float_compare(tx.amount, 0.0, precision_rounding=pos_order.currency_id.rounding) <= 0:
            //             raise ValidationError(_('The payment transaction (%d) has a negative amount.', tx.id))
            // 
            //         if not tx.payment_id: # the payment could already have been created by account_payment module
            //             tx._create_payment()
            //         if not tx.payment_id:
            //             raise ValidationError(_('The POS online payment (tx.id=%d) could not be saved correctly', tx.id))
            // 
            //         payment_method = pos_order.online_payment_method_id
            //         if not payment_method:
            //             pos_config = pos_order.config_id
            //             payment_method = self.env['pos.payment.method'].sudo()._get_or_create_online_payment_method(pos_config.company_id.id, pos_config.id)
            //             if not payment_method:
            //                 raise ValidationError(_('The POS online payment (tx.id=%d) could not be saved correctly because the online payment method could not be found', tx.id))
            // 
            //         pos_order.add_payment({
            //             'amount': tx.amount,
            //             'payment_date': tx.last_state_change,
            //             'payment_method_id': payment_method.id,
            //             'online_account_payment_id': tx.payment_id.id,
            //             'pos_order_id': pos_order.id,
            //         })
            //         tx.payment_id.update({
            //             'pos_payment_method_id': payment_method.id,
            //             'pos_order_id': pos_order.id,
            //             'pos_session_id': pos_order.session_id.id,
            //         })
            //         if pos_order.state == 'draft' and pos_order._is_pos_order_paid():
            //             pos_order._process_saved_order(False)
            //         # The bus communication is only protected by the name of the channel.
            //         # Therefore, no sensitive information is sent through it, only a
            //         # notification to invite the local browser to do a safe RPC to
            //         # the server to check the new state of the order.
            //         pos_order.config_id._notify('ONLINE_PAYMENTS_NOTIFICATION', {'id': pos_order.id})
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayConvertInrToCurrencyInternalAsync(object amount, Guid currency_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _razorpay_convert_inr_to_currency(self, amount, currency_id):
            // """ Convert the amount from INR to the given currency.
            // 
            // :param float amount: The amount to converted, in INR.
            // :param currency_id: The currency to which the amount should be converted.
            // :return: The converted amount in the given currency.
            // :rtype: float
            // """
            // inr_currency = self.env['res.currency'].with_context(active_test=False).search([
            //     ('name', '=', 'INR'),
            // ], limit=1)
            // return inr_currency._convert(amount, currency_id)
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayCreateCustomerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _razorpay_create_customer(self):
            // """ Create and return a Customer object.
            // 
            // :return: The created Customer.
            // :rtype: dict
            // """
            // payload = {
            //     'name': self.partner_name,
            //     'email': self.partner_email or '',
            //     'contact': self.partner_phone and self._validate_phone_number(self.partner_phone) or '',
            //     'fail_existing': '0',  # Don't throw an error if the customer already exists.
            // }
            // _logger.info(
            //     "Sending '/customers' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(payload)
            // )
            // customer_data = self.provider_id._razorpay_make_request('customers', payload=payload)
            // _logger.info(
            //     "Response of '/customers' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(customer_data)
            // )
            // return customer_data
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayCreateOrderInternalAsync(Guid customer_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _razorpay_create_order(self, customer_id=None):
            // """ Create and return an Order object to initiate the payment.
            // 
            // :param str customer_id: The ID of the Customer object to assign to the Order for
            //                         non-subsequent payments.
            // :return: The created Order.
            // :rtype: dict
            // """
            // payload = self._razorpay_prepare_order_payload(customer_id=customer_id)
            // _logger.info(
            //     "Sending '/orders' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(payload)
            // )
            // order_data = self.provider_id._razorpay_make_request('orders', payload=payload)
            // _logger.info(
            //     "Response of '/orders' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(order_data)
            // )
            // return order_data
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayCreateRefundTxFromNotificationDataInternalAsync(object source_tx, object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _razorpay_create_refund_tx_from_notification_data(self, source_tx, notification_data):
            // """ Create a refund transaction based on Razorpay data.
            // 
            // :param recordset source_tx: The source transaction for which a refund is initiated, as a
            //                             `payment.transaction` recordset.
            // :param dict notification_data: The notification data sent by the provider.
            // :return: The newly created refund transaction.
            // :rtype: recordset of `payment.transaction`
            // :raise ValidationError: If inconsistent data were received.
            // """
            // refund_provider_reference = notification_data.get('id')
            // amount_to_refund = notification_data.get('amount')
            // if not refund_provider_reference or not amount_to_refund:
            //     raise ValidationError("Razorpay: " + _("Received incomplete refund data."))
            // 
            // converted_amount = payment_utils.to_major_currency_units(
            //     amount_to_refund, source_tx.currency_id
            // )
            // return source_tx._create_child_transaction(
            //     converted_amount, is_refund=True, provider_reference=refund_provider_reference
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayGetMandateMaxAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _razorpay_get_mandate_max_amount(self):
            // """ Return the eMandate's maximum amount to define.
            // 
            // :return: The eMandate's maximum amount.
            // :rtype: float
            // """
            // pm_code = (
            //     self.payment_method_id.primary_payment_method_id or self.payment_method_id
            // ).code
            // pm_max_amount_INR = const.MANDATE_MAX_AMOUNT.get(pm_code, 100000)
            // pm_max_amount = self._razorpay_convert_inr_to_currency(pm_max_amount_INR, self.currency_id)
            // mandate_values = self._get_mandate_values()  # The linked document's values.
            // if 'amount' in mandate_values and 'MRR' in mandate_values:
            //     max_amount = min(
            //         pm_max_amount, max(mandate_values['amount'] * 1.5, mandate_values['MRR'] * 5)
            //     )
            // else:
            //     max_amount = pm_max_amount
            // return max_amount
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayPrepareOrderPayloadInternalAsync(Guid customer_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _razorpay_prepare_order_payload(self, customer_id=None):
            // """ Prepare the payload for the order request based on the transaction values.
            // 
            // :param str customer_id: The ID of the Customer object to assign to the Order for
            //                         non-subsequent payments.
            // :return: The request payload.
            // :rtype: dict
            // """
            // converted_amount = payment_utils.to_minor_currency_units(self.amount, self.currency_id)
            // pm_code = (self.payment_method_id.primary_payment_method_id or self.payment_method_id).code
            // payload = {
            //     'amount': converted_amount,
            //     'currency': self.currency_id.name,
            //     **({'method': pm_code} if pm_code not in const.FALLBACK_PAYMENT_METHOD_CODES else {}),
            // }
            // if self.operation in ['online_direct', 'validation']:
            //     payload['customer_id'] = customer_id  # Required for only non-subsequent payments.
            //     if self.tokenize:
            //         payload['token'] = {
            //             'max_amount': payment_utils.to_minor_currency_units(
            //                 self._razorpay_get_mandate_max_amount(), self.currency_id
            //             ),
            //             'expire_at': time.mktime(
            //                 (datetime.today() + relativedelta(years=10)).timetuple()
            //             ),  # Don't expire the token before at least 10 years.
            //             'frequency': 'as_presented',
            //         }
            // else:  # 'online_token', 'offline'
            //     # Required for only subsequent payments.
            //     payload['payment_capture'] = not self.provider_id.capture_manually
            // if self.provider_id.capture_manually:  # The related payment must be only authorized.
            //     payload.update({
            //         'payment': {
            //             'capture': 'manual',
            //             'capture_options': {
            //                 'manual_expiry_period': 7200,  # The default value for this required option.
            //                 'refund_speed': 'normal',  # The default value for this required option.
            //             }
            //         },
            //     })
            // return payload
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayTokenizeFromNotificationDataInternalAsync(object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _razorpay_tokenize_from_notification_data(self, notification_data):
            // """ Create a new token based on the notification data.
            // 
            // :param dict notification_data: The notification data built with Razorpay objects.
            //                                See `_process_notification_data`.
            // :return: None
            // """
            // pm_code = (self.payment_method_id.primary_payment_method_id or self.payment_method_id).code
            // if pm_code == 'card':
            //     details = notification_data.get('card', {}).get('last4')
            // elif pm_code == 'upi':
            //     temp_vpa = notification_data.get('vpa')
            //     details = temp_vpa[temp_vpa.find('@') - 1:]
            // else:
            //     details = pm_code
            // 
            // token = self.env['payment.token'].create({
            //     'provider_id': self.provider_id.id,
            //     'payment_method_id': self.payment_method_id.id,
            //     'payment_details': details,
            //     'partner_id': self.partner_id.id,
            //     # Razorpay requires both the customer ID and the token ID which are extracted from here.
            //     'provider_ref': f'{notification_data["customer_id"]},{notification_data["token_id"]}',
            // })
            // self.write({
            //     'token_id': token,
            //     'tokenize': False,
            // })
            // _logger.info(
            //     "Created token with id %(token_id)s for partner with id %(partner_id)s from "
            //     "transaction with reference %(ref)s",
            //     {
            //         'token_id': token.id,
            //         'partner_id': self.partner_id.id,
            //         'ref': self.reference,
            //     },
            // )
            */
            return default;
        }

        public async Task<PaymentTransaction> RefundAsync(Guid id, PaymentTransactionRefundRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def action_refund(self, amount_to_refund=None):
            // """ Check the state of the transactions and request their refund.
            // 
            // :param float amount_to_refund: The amount to be refunded.
            // :return: None
            // """
            // if any(tx.state != 'done' for tx in self):
            //     raise ValidationError(_("Only confirmed transactions can be refunded."))
            // 
            // payment_utils.check_rights_on_recordset(self)
            // for tx in self:
            //     # In sudo mode because we need to be able to read on provider fields.
            //     tx.sudo()._send_refund_request(amount_to_refund=amount_to_refund)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentTransaction> SendCaptureRequestInternalAsync(object amount_to_capture)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _send_capture_request(self, amount_to_capture=None):
            // """ Request the provider handling the transaction to capture the payment.
            // 
            // For partial captures, create a child transaction linked to the source transaction.
            // 
            // For a provider to support authorization, it must override this method and make an API
            // request to capture the payment.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param float amount_to_capture: The amount to capture.
            // :return: The created capture child transaction, if any.
            // :rtype: `payment.transaction`
            // """
            // self.ensure_one()
            // self._ensure_provider_is_not_disabled()
            // 
            // if amount_to_capture and amount_to_capture != self.amount:
            //     return self._create_child_transaction(amount_to_capture)
            // return self.env['payment.transaction']
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _send_capture_request(self, amount_to_capture=None):
            // """ Override of `payment` to send a capture request to Adyen. """
            // capture_child_tx = super()._send_capture_request(amount_to_capture=amount_to_capture)
            // if self.provider_code != 'adyen':
            //     return capture_child_tx
            // 
            // amount_to_capture = amount_to_capture or self.amount
            // converted_amount = payment_utils.to_minor_currency_units(
            //     amount_to_capture, self.currency_id, const.CURRENCY_DECIMALS.get(self.currency_id.name)
            // )
            // data = {
            //     'merchantAccount': self.provider_id.adyen_merchant_account,
            //     'amount': {
            //         'value': converted_amount,
            //         'currency': self.currency_id.name,
            //     },
            //     'reference': self.reference,
            // }
            // response_content = self.provider_id._adyen_make_request(
            //     endpoint='/payments/{}/captures',
            //     endpoint_param=self.provider_reference,
            //     payload=data,
            //     method='POST',
            // )
            // _logger.info("capture request response:\n%s", pprint.pformat(response_content))
            // 
            // # Handle the capture request response
            // status = response_content.get('status')
            // formatted_amount = format_amount(self.env, amount_to_capture, self.currency_id)
            // if status == 'received':
            //     self._log_message_on_linked_documents(_(
            //         "The capture request of %(amount)s for the transaction with reference %(ref)s has "
            //         "been requested (%(provider_name)s).",
            //         amount=formatted_amount, ref=self.reference, provider_name=self.provider_id.name
            //     ))
            // 
            // if capture_child_tx:
            //     # The PSP reference associated with this capture request is different from the PSP
            //     # reference associated with the original payment request.
            //     capture_child_tx.provider_reference = response_content.get('pspReference')
            // 
            // return capture_child_tx
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _send_capture_request(self, amount_to_capture=None):
            // """ Override of `payment` to send a capture request to Authorize. """
            // child_capture_tx = super()._send_capture_request(amount_to_capture=amount_to_capture)
            // if self.provider_code != 'authorize':
            //     return child_capture_tx
            // 
            // authorize_API = AuthorizeAPI(self.provider_id)
            // rounded_amount = round(self.amount, self.currency_id.decimal_places)
            // res_content = authorize_API.capture(self.provider_reference, rounded_amount)
            // _logger.info(
            //     "capture request response for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(res_content)
            // )
            // self._handle_notification_data('authorize', {'response': res_content})
            // 
            // return child_capture_tx
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _send_capture_request(self, amount_to_capture=None):
            // """ Override of `payment` to simulate a capture request. """
            // child_capture_tx = super()._send_capture_request(amount_to_capture=amount_to_capture)
            // if self.provider_code != 'demo':
            //     return child_capture_tx
            // 
            // tx = child_capture_tx or self
            // notification_data = {
            //     'reference': tx.reference,
            //     'simulated_state': 'done',
            //     'manual_capture': True,  # Distinguish manual captures from regular one-step captures.
            // }
            // tx._handle_notification_data('demo', notification_data)
            // 
            // return child_capture_tx
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _send_capture_request(self, amount_to_capture=None):
            // """ Override of `payment` to send a capture request to Razorpay. """
            // child_capture_tx = super()._send_capture_request(amount_to_capture=amount_to_capture)
            // if self.provider_code != 'razorpay':
            //     return child_capture_tx
            // 
            // converted_amount = payment_utils.to_minor_currency_units(self.amount, self.currency_id)
            // payload = {'amount': converted_amount, 'currency': self.currency_id.name}
            // _logger.info(
            //     "Payload of '/payments/<id>/capture' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(payload)
            // )
            // response_content = self.provider_id._razorpay_make_request(
            //     f'payments/{self.provider_reference}/capture', payload=payload
            // )
            // _logger.info(
            //     "Response of '/payments/<id>/capture' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(response_content)
            // )
            // 
            // # Handle the capture request response.
            // self._handle_notification_data('razorpay', response_content)
            // 
            // return child_capture_tx
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _send_capture_request(self, amount_to_capture=None):
            // """ Override of `payment` to send a capture request to Stripe. """
            // child_capture_tx = super()._send_capture_request(amount_to_capture=amount_to_capture)
            // if self.provider_code != 'stripe':
            //     return child_capture_tx
            // 
            // # Make the capture request to Stripe
            // payment_intent = self.provider_id._stripe_make_request(
            //     f'payment_intents/{self.provider_reference}/capture'
            // )
            // _logger.info(
            //     "capture request response for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(payment_intent)
            // )
            // 
            // # Handle the capture request response
            // notification_data = {'reference': self.reference}
            // StripeController._include_payment_intent_in_notification_data(
            //     payment_intent, notification_data
            // )
            // self._handle_notification_data('stripe', notification_data)
            // 
            // return child_capture_tx
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendDonationEmailInternalAsync(object is_internal_notification, object comment, object recipient_email)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_payment, FILE: payment_transaction.py) ---
            // def _send_donation_email(self, is_internal_notification=False, comment=None, recipient_email=None):
            // self.ensure_one()
            // if is_internal_notification or self.state == 'done':
            //     subject = _('A donation has been made on your website') if is_internal_notification else _('Donation confirmation')
            //     body = self.env['ir.qweb']._render('website_payment.donation_mail_body', {
            //         'is_internal_notification': is_internal_notification,
            //         'tx': self,
            //         'comment': comment,
            //     }, minimal_qcontext=True)
            //     self.env.ref('website_payment.mail_template_donation').send_mail(
            //         self.id,
            //         email_layout_xmlid="mail.mail_notification_light",
            //         email_values={
            //             'email_to': recipient_email if is_internal_notification else self.partner_email,
            //             'email_from': self.company_id.email_formatted,
            //             'author_id': self.partner_id.id,
            //             'subject': subject,
            //             'body_html': body,
            //         },
            //         force_send=True,
            //     )
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _send_invoice(self):
            // # Send messages as OdooBot so that
            // #   * logged in users receive the invoice
            // #   * the mail and notifications are not sent by the public user
            // for tx in self.with_user(SUPERUSER_ID):
            //     tx = tx.with_company(tx.company_id).with_context(
            //         company_id=tx.company_id.id,
            //     )
            //     invoice_to_send = tx.invoice_ids.filtered(
            //         lambda i: not i.is_move_sent and i.state == 'posted' and i._is_ready_to_be_sent()
            //     )
            //     invoice_to_send.is_move_sent = True # Mark invoice as sent
            // 
            //     send_context = {'allow_raising': False, 'allow_fallback_pdf': True}
            //     default_template_param = (
            //         self.env['ir.config_parameter']
            //         .sudo()
            //         .get_param('sale.default_invoice_email_template', False)
            //     )
            //     if default_template_param:
            //         mail_template = self.env['mail.template'].sudo().browse(int(default_template_param))
            //         if mail_template.exists():
            //             send_context['mail_template'] = mail_template
            // 
            //     self.env['account.move.send']._generate_and_send_invoices(
            //         invoice_to_send,
            //         **send_context,
            //     )
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendPaymentRequestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """ Request the provider handling the transaction to make the payment.
            // 
            // This method is exclusively used to make payments by token, which correspond to both the
            // `online_token` and the `offline` transaction's `operation` field.
            // 
            // For a provider to support tokenization, it must override this method and make an API request
            // to make a payment.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: None
            // """
            // self.ensure_one()
            // self._ensure_provider_is_not_disabled()
            // self._log_sent_message()
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """ Override of payment to send a payment request to Adyen.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // :raise: UserError if the transaction is not linked to a token
            // """
            // super()._send_payment_request()
            // if self.provider_code != 'adyen':
            //     return
            // 
            // # Prepare the payment request to Adyen
            // if not self.token_id:
            //     raise UserError("Adyen: " + _("The transaction is not linked to a token."))
            // 
            // converted_amount = payment_utils.to_minor_currency_units(
            //     self.amount, self.currency_id, const.CURRENCY_DECIMALS.get(self.currency_id.name)
            // )
            // data = {
            //     'merchantAccount': self.provider_id.adyen_merchant_account,
            //     'amount': {
            //         'value': converted_amount,
            //         'currency': self.currency_id.name,
            //     },
            //     'reference': self.reference,
            //     'paymentMethod': {
            //         'storedPaymentMethodId': self.token_id.provider_ref,
            //     },
            //     'shopperReference': self.token_id.adyen_shopper_reference,
            //     'recurringProcessingModel': 'Subscription',
            //     'shopperIP': payment_utils.get_customer_ip_address(),
            //     'shopperInteraction': 'ContAuth',
            //     'shopperEmail': self.partner_email,
            //     'shopperName': adyen_utils.format_partner_name(self.partner_name),
            //     'telephoneNumber': self.partner_phone,
            //     **adyen_utils.include_partner_addresses(self),
            // }
            // 
            // # Force the capture delay on Adyen side if the provider is not configured for capturing
            // # payments manually. This is necessary because it's not possible to distinguish
            // # 'AUTHORISATION' events sent by Adyen with the merchant account's capture delay set to
            // # 'manual' from events with the capture delay set to 'immediate' or a number of hours. If
            // # the merchant account is configured to capture payments with a delay but the provider is
            // # not, we force the immediate capture to avoid considering authorized transactions as
            // # captured on Odoo.
            // if not self.provider_id.capture_manually:
            //     data.update(captureDelayHours=0)
            // 
            // # Make the payment request to Adyen
            // try:
            //     response_content = self.provider_id._adyen_make_request(
            //         endpoint='/payments',
            //         payload=data,
            //         method='POST',
            //         idempotency_key=payment_utils.generate_idempotency_key(
            //             self, scope='payment_request_token'
            //         )
            //     )
            // except ValidationError as e:
            //     if self.operation == 'offline':
            //         self._set_error(str(e))  # Log the error message on linked documents' chatter.
            //         return  # There is nothing to process.
            //     else:
            //         raise e
            // 
            // # Handle the payment request response
            // _logger.info(
            //     "payment request response for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(response_content)
            // )
            // self._handle_notification_data('adyen', response_content)
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """ Override of payment to send a payment request to Authorize.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // :raise: UserError if the transaction is not linked to a token
            // """
            // super()._send_payment_request()
            // if self.provider_code != 'authorize':
            //     return
            // 
            // if not self.token_id.authorize_profile:
            //     raise UserError("Authorize.Net: " + _("The transaction is not linked to a token."))
            // 
            // authorize_API = AuthorizeAPI(self.provider_id)
            // if self.provider_id.capture_manually:
            //     res_content = authorize_API.authorize(self, token=self.token_id)
            //     _logger.info(
            //         "authorize request response for transaction with reference %s:\n%s",
            //         self.reference, pprint.pformat(res_content)
            //     )
            // else:
            //     res_content = authorize_API.auth_and_capture(self, token=self.token_id)
            //     _logger.info(
            //         "auth_and_capture request response for transaction with reference %s:\n%s",
            //         self.reference, pprint.pformat(res_content)
            //     )
            // self._handle_notification_data('authorize', {'response': res_content})
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """ Override of payment to simulate a payment request.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // """
            // super()._send_payment_request()
            // if self.provider_code != 'demo':
            //     return
            // 
            // if not self.token_id:
            //     raise UserError("Demo: " + _("The transaction is not linked to a token."))
            // 
            // simulated_state = self.token_id.demo_simulated_state
            // notification_data = {'reference': self.reference, 'simulated_state': simulated_state}
            // self._handle_notification_data('demo', notification_data)
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """ Override of payment to send a payment request to Flutterwave.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // :raise UserError: If the transaction is not linked to a token.
            // """
            // super()._send_payment_request()
            // if self.provider_code != 'flutterwave':
            //     return
            // 
            // # Prepare the payment request to Flutterwave.
            // if not self.token_id:
            //     raise UserError("Flutterwave: " + _("The transaction is not linked to a token."))
            // 
            // first_name, last_name = payment_utils.split_partner_name(self.partner_name)
            // base_url = self.provider_id.get_base_url()
            // data = {
            //     'token': self.token_id.provider_ref,
            //     'email': self.token_id.flutterwave_customer_email,
            //     'amount': self.amount,
            //     'currency': self.currency_id.name,
            //     'country': self.company_id.country_id.code,
            //     'tx_ref': self.reference,
            //     'first_name': first_name,
            //     'last_name': last_name,
            //     'ip': payment_utils.get_customer_ip_address(),
            //     'redirect_url': urls.url_join(base_url, FlutterwaveController._auth_return_url),
            // }
            // 
            // # Make the payment request to Flutterwave.
            // response_content = self.provider_id._flutterwave_make_request(
            //     'tokenized-charges', payload=data
            // )
            // 
            // # Handle the payment request response.
            // _logger.info(
            //     "payment request response for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(response_content)
            // )
            // self._handle_notification_data('flutterwave', response_content['data'])
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """ Override of `payment` to send a payment request to Razorpay.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // :raise UserError: If the transaction is not linked to a token.
            // """
            // super()._send_payment_request()
            // if self.provider_code != 'razorpay':
            //     return
            // 
            // if not self.token_id:
            //     raise UserError("Razorpay: " + _("The transaction is not linked to a token."))
            // 
            // # Prevent multiple token payments for the same document within 36 hours. Another transaction
            // # with the same token could be pending processing due to Razorpay waiting 24 hours.
            // # See https://www.rbi.org.in/Scripts/NotificationUser.aspx?Id=11668.
            // # Remove every character after the last "-", "-" included
            // reference_prefix = re.sub(r'-(?!.*-).*$', '', self.reference) or self.reference
            // earlier_pending_tx = self.search([
            //     ('provider_code', '=', 'razorpay'),
            //     ('state', '=', 'pending'),
            //     ('token_id', '=', self.token_id.id),
            //     ('operation', 'in', ['online_token', 'offline']),
            //     ('reference', '=like', f'{reference_prefix}%'),
            //     ('create_date', '>=', fields.Datetime.now() - relativedelta(hours=36)),
            //     ('id', '!=', self.id),
            // ], limit=1)
            // if earlier_pending_tx:
            //     raise UserError(
            //         "Razorpay: " + _(
            //             "Your last payment with reference %s will soon be processed. Please wait up to"
            //             " 24 hours before trying again, or use another payment method.",
            //             earlier_pending_tx.reference
            //         )
            //     )
            // 
            // try:
            //     order_data = self._razorpay_create_order()
            //     phone = self._validate_phone_number(self.partner_phone)
            //     customer_id, token_id = self.token_id.provider_ref.split(',')
            //     payload = {
            //         'email': self.partner_email,
            //         'contact': phone,
            //         'amount': order_data['amount'],
            //         'currency': self.currency_id.name,
            //         'order_id': order_data['id'],
            //         'customer_id': customer_id,
            //         'token': token_id,
            //         'description': self.reference,
            //         'recurring': '1',
            //     }
            //     _logger.info(
            //         "Sending '/payments/create/recurring' request for transaction with reference %s:\n%s",
            //         self.reference, pprint.pformat(payload)
            //     )
            //     recurring_payment_data = self.provider_id._razorpay_make_request(
            //         'payments/create/recurring', payload=payload
            //     )
            //     _logger.info(
            //         "Response of '/payments/create/recurring' request for transaction with reference "
            //         "%s:\n%s", self.reference, pprint.pformat(recurring_payment_data)
            //     )
            //     self._handle_notification_data('razorpay', recurring_payment_data)
            // except ValidationError as e:
            //     if self.operation == 'offline':
            //         self._set_error(str(e))
            //     else:
            //         raise
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """ Override of payment to send a payment request to Stripe with a confirmed PaymentIntent.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // :raise: UserError if the transaction is not linked to a token
            // """
            // super()._send_payment_request()
            // if self.provider_code != 'stripe':
            //     return
            // 
            // if not self.token_id:
            //     raise UserError("Stripe: " + _("The transaction is not linked to a token."))
            // 
            // # Make the payment request to Stripe
            // payment_intent = self._stripe_create_intent()
            // _logger.info(
            //     "payment request response for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(payment_intent)
            // )
            // if not payment_intent:  # The PI might be missing if Stripe failed to create it.
            //     return  # There is nothing to process; the transaction is in error at this point.
            // 
            // # Handle the payment request response
            // notification_data = {'reference': self.reference}
            // StripeController._include_payment_intent_in_notification_data(
            //     payment_intent, notification_data
            // )
            // self._handle_notification_data('stripe', notification_data)
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """ Override of `payment` to send a payment request to Worldline.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // :raise UserError: If the transaction is not linked to a token.
            // """
            // super()._send_payment_request()
            // if self.provider_code != 'worldline':
            //     return
            // 
            // # Prepare the payment request to Worldline.
            // if not self.token_id:
            //     raise UserError("Worldline: " + _("The transaction is not linked to a token."))
            // 
            // payload = {
            //     'cardPaymentMethodSpecificInput': {
            //         'authorizationMode': 'SALE',  # Force the capture.
            //         'token': self.token_id.provider_ref,
            //         'unscheduledCardOnFileRequestor': 'merchantInitiated',
            //         'unscheduledCardOnFileSequenceIndicator': 'subsequent',
            //     },
            //     'order': {
            //         'amountOfMoney': {
            //             'amount': payment_utils.to_minor_currency_units(self.amount, self.currency_id),
            //             'currencyCode': self.currency_id.name,
            //         },
            //         'references': {
            //             'merchantReference': self.reference,
            //         },
            //     },
            // }
            // 
            // # Make the payment request to Worldline.
            // response_content = self.provider_id._worldline_make_request(
            //     'payments',
            //     payload=payload,
            //     idempotency_key=payment_utils.generate_idempotency_key(
            //         self, scope='payment_request_token'
            //     )
            // )
            // 
            // # Handle the payment request response.
            // _logger.info(
            //     "Response of /payment request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(response_content)
            // )
            // self._handle_notification_data('worldline', response_content)
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """ Override of `payment` to send a payment request to Xendit.
            // 
            // Note: self.ensure_one()
            // 
            // :return: None
            // :raise UserError: If the transaction is not linked to a token.
            // """
            // super()._send_payment_request()
            // if self.provider_code != 'xendit':
            //     return
            // 
            // if not self.token_id:
            //     raise ValidationError("Xendit: " + _("The transaction is not linked to a token."))
            // 
            // self._xendit_create_charge(self.token_id.provider_ref)
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendRefundRequestInternalAsync(object amount_to_refund)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _send_refund_request(self, amount_to_refund=None):
            // """ Request the provider handling the transaction to refund it.
            // 
            // For a provider to support refunds, it must override this method and make an API request to
            // make a refund.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param float amount_to_refund: The amount to be refunded.
            // :return: The refund transaction created to process the refund request.
            // :rtype: recordset of `payment.transaction`
            // """
            // self.ensure_one()
            // self._ensure_provider_is_not_disabled()
            // 
            // refund_tx = self._create_child_transaction(amount_to_refund or self.amount, is_refund=True)
            // refund_tx._log_sent_message()
            // return refund_tx
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _send_refund_request(self, amount_to_refund=None):
            // """ Override of payment to send a refund request to Adyen.
            // 
            // Note: self.ensure_one()
            // 
            // :param float amount_to_refund: The amount to refund
            // :return: The refund transaction created to process the refund request.
            // :rtype: recordset of `payment.transaction`
            // """
            // refund_tx = super()._send_refund_request(amount_to_refund=amount_to_refund)
            // if self.provider_code != 'adyen':
            //     return refund_tx
            // 
            // # Make the refund request to Adyen
            // converted_amount = payment_utils.to_minor_currency_units(
            //     -refund_tx.amount,  # The amount is negative for refund transactions
            //     refund_tx.currency_id,
            //     arbitrary_decimal_number=const.CURRENCY_DECIMALS.get(refund_tx.currency_id.name)
            // )
            // data = {
            //     'merchantAccount': self.provider_id.adyen_merchant_account,
            //     'amount': {
            //         'value': converted_amount,
            //         'currency': refund_tx.currency_id.name,
            //     },
            //     'reference': refund_tx.reference,
            // }
            // response_content = refund_tx.provider_id._adyen_make_request(
            //     endpoint='/payments/{}/refunds',
            //     endpoint_param=self.provider_reference,
            //     payload=data,
            //     method='POST'
            // )
            // _logger.info(
            //     "refund request response for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(response_content)
            // )
            // 
            // # Handle the refund request response
            // psp_reference = response_content.get('pspReference')
            // status = response_content.get('status')
            // if psp_reference and status == 'received':
            //     # The PSP reference associated with this /refunds request is different from the psp
            //     # reference associated with the original payment request.
            //     refund_tx.provider_reference = psp_reference
            // 
            // return refund_tx
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _send_refund_request(self, amount_to_refund=None):
            // """ Override of payment to send a refund request to Authorize.
            // 
            // Note: self.ensure_one()
            // 
            // :param float amount_to_refund: The amount to refund
            // :return: The refund transaction created to process the refund request.
            // :rtype: recordset of `payment.transaction`
            // """
            // self.ensure_one()
            // 
            // if self.provider_code != 'authorize':
            //     return super()._send_refund_request(amount_to_refund=amount_to_refund)
            // 
            // authorize_api = AuthorizeAPI(self.provider_id)
            // tx_details = authorize_api.get_transaction_details(self.provider_reference)
            // if 'err_code' in tx_details:  # Could not retrieve the transaction details.
            //     raise ValidationError("Authorize.Net: " + _(
            //         "Could not retrieve the transaction details. (error code: %(error_code)s; error_details: %(error_message)s)",
            //         error_code=tx_details['err_code'], error_message=tx_details.get('err_msg'),
            //     ))
            // 
            // refund_tx = self.env['payment.transaction']
            // tx_status = tx_details.get('transaction', {}).get('transactionStatus')
            // if tx_status in TRANSACTION_STATUS_MAPPING['voided']:
            //     # The payment has been voided from Authorize.net side before we could refund it.
            //     self._set_canceled(extra_allowed_states=('done',))
            // elif tx_status in TRANSACTION_STATUS_MAPPING['refunded']:
            //     # The payment has been refunded from Authorize.net side before we could refund it. We
            //     # create a refund tx on Odoo to reflect the move of the funds.
            //     refund_tx = super()._send_refund_request(amount_to_refund=amount_to_refund)
            //     refund_tx._set_done()
            //     # Immediately post-process the transaction as the post-processing will not be
            //     # triggered by a customer browsing the transaction from the portal.
            //     self.env.ref('payment.cron_post_process_payment_tx')._trigger()
            // elif any(tx_status in TRANSACTION_STATUS_MAPPING[k] for k in ('authorized', 'captured')):
            //     if tx_status in TRANSACTION_STATUS_MAPPING['authorized']:
            //         # The payment has not been settled on Authorize.net yet. It must be voided rather
            //         # than refunded. Since the funds have not moved yet, we don't create a refund tx.
            //         res_content = authorize_api.void(self.provider_reference)
            //         tx_to_process = self
            //     else:
            //         # The payment has been settled on Authorize.net side. We can refund it.
            //         refund_tx = super()._send_refund_request(amount_to_refund=amount_to_refund)
            //         rounded_amount = round(amount_to_refund, self.currency_id.decimal_places)
            //         res_content = authorize_api.refund(
            //             self.provider_reference, rounded_amount, tx_details
            //         )
            //         tx_to_process = refund_tx
            //     _logger.info(
            //         "refund request response for transaction with reference %s:\n%s",
            //         self.reference, pprint.pformat(res_content)
            //     )
            //     data = {'reference': tx_to_process.reference, 'response': res_content}
            //     tx_to_process._handle_notification_data('authorize', data)
            // else:
            //     raise ValidationError("Authorize.net: " + _(
            //         "The transaction is not in a status to be refunded. (status: %(status)s, details: %(message)s)",
            //         status=tx_status, message=tx_details.get('messages', {}).get('message'),
            //     ))
            // return refund_tx
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _send_refund_request(self, **kwargs):
            // """ Override of payment to simulate a refund.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict kwargs: The keyword arguments.
            // :return: The refund transaction created to process the refund request.
            // :rtype: recordset of `payment.transaction`
            // """
            // refund_tx = super()._send_refund_request(**kwargs)
            // if self.provider_code != 'demo':
            //     return refund_tx
            // 
            // notification_data = {'reference': refund_tx.reference, 'simulated_state': 'done'}
            // refund_tx._handle_notification_data('demo', notification_data)
            // 
            // return refund_tx
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _send_refund_request(self, amount_to_refund=None):
            // """ Override of `payment` to send a refund request to Razorpay.
            // 
            // Note: self.ensure_one()
            // 
            // :param float amount_to_refund: The amount to refund.
            // :return: The refund transaction created to process the refund request.
            // :rtype: recordset of `payment.transaction`
            // """
            // refund_tx = super()._send_refund_request(amount_to_refund=amount_to_refund)
            // if self.provider_code != 'razorpay':
            //     return refund_tx
            // 
            // # Make the refund request to Razorpay.
            // converted_amount = payment_utils.to_minor_currency_units(
            //     -refund_tx.amount, refund_tx.currency_id
            // )  # The amount is negative for refund transactions.
            // payload = {
            //     'amount': converted_amount,
            //     'notes': {
            //         'reference': refund_tx.reference,  # Allow retrieving the ref. from webhook data.
            //     },
            // }
            // _logger.info(
            //     "Payload of '/payments/<id>/refund' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(payload)
            // )
            // response_content = refund_tx.provider_id._razorpay_make_request(
            //     f'payments/{self.provider_reference}/refund', payload=payload
            // )
            // _logger.info(
            //     "Response of '/payments/<id>/refund' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(response_content)
            // )
            // response_content.update(entity_type='refund')
            // refund_tx._handle_notification_data('razorpay', response_content)
            // 
            // return refund_tx
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _send_refund_request(self, amount_to_refund=None):
            // """ Override of payment to send a refund request to Stripe.
            // 
            // Note: self.ensure_one()
            // 
            // :param float amount_to_refund: The amount to refund.
            // :return: The refund transaction created to process the refund request.
            // :rtype: recordset of `payment.transaction`
            // """
            // refund_tx = super()._send_refund_request(amount_to_refund=amount_to_refund)
            // if self.provider_code != 'stripe':
            //     return refund_tx
            // 
            // # Make the refund request to stripe.
            // data = self.provider_id._stripe_make_request(
            //     'refunds', payload={
            //         'payment_intent': self.provider_reference,
            //         'amount': payment_utils.to_minor_currency_units(
            //             -refund_tx.amount,  # Refund transactions' amount is negative, inverse it.
            //             refund_tx.currency_id,
            //         ),
            //     }
            // )
            // _logger.info(
            //     "Refund request response for transaction wih reference %s:\n%s",
            //     self.reference, pprint.pformat(data)
            // )
            // # Handle the refund request response.
            // notification_data = {}
            // StripeController._include_refund_in_notification_data(data, notification_data)
            // refund_tx._handle_notification_data('stripe', notification_data)
            // 
            // return refund_tx
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendVoidRequestInternalAsync(object amount_to_void)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _send_void_request(self, amount_to_void=None):
            // """ Request the provider handling the transaction to void the payment.
            // 
            // For partial voids, create a child transaction linked to the source transaction.
            // 
            // For a provider to support authorization, it must override this method and make an API
            // request to void the payment.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param float amount_to_void: The amount to be voided.
            // :return: The created void child transaction, if any.
            // :rtype: payment.transaction
            // """
            // self.ensure_one()
            // self._ensure_provider_is_not_disabled()
            // 
            // if amount_to_void and amount_to_void != self.amount:
            //     return self._create_child_transaction(amount_to_void)
            // 
            // return self.env['payment.transaction']
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _send_void_request(self, amount_to_void=None):
            // """ Override of `payment` to send a void request to Adyen. """
            // child_void_tx = super()._send_void_request(amount_to_void=amount_to_void)
            // if self.provider_code != 'adyen':
            //     return child_void_tx
            // 
            // data = {
            //     'merchantAccount': self.provider_id.adyen_merchant_account,
            //     'reference': self.reference,
            // }
            // response_content = self.provider_id._adyen_make_request(
            //     endpoint='/payments/{}/cancels',
            //     endpoint_param=self.provider_reference,
            //     payload=data,
            //     method='POST',
            // )
            // _logger.info("void request response:\n%s", pprint.pformat(response_content))
            // 
            // # Handle the void request response
            // status = response_content.get('status')
            // if status == 'received':
            //     self._log_message_on_linked_documents(_(
            //         "A request was sent to void the transaction with reference %(reference)s (%(provider)s).",
            //         reference=self.reference, provider=self.provider_id.name,
            //     ))
            // 
            // if child_void_tx:
            //     # The PSP reference associated with this void request is different from the PSP
            //     # reference associated with the original payment request.
            //     child_void_tx.provider_reference = response_content.get('pspReference')
            // 
            // return child_void_tx
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _send_void_request(self, amount_to_void=None):
            // """ Override of payment to send a void request to Authorize. """
            // child_void_tx = super()._send_void_request(amount_to_void=amount_to_void)
            // if self.provider_code != 'authorize':
            //     return child_void_tx
            // 
            // authorize_API = AuthorizeAPI(self.provider_id)
            // res_content = authorize_API.void(self.provider_reference)
            // _logger.info(
            //     "void request response for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(res_content)
            // )
            // self._handle_notification_data('authorize', {'response': res_content})
            // 
            // return child_void_tx
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _send_void_request(self, amount_to_void=None):
            // """ Override of `payment` to simulate a void request. """
            // child_void_tx = super()._send_void_request(amount_to_void=amount_to_void)
            // if self.provider_code != 'demo':
            //     return child_void_tx
            // 
            // tx = child_void_tx or self
            // notification_data = {'reference': tx.reference, 'simulated_state': 'cancel'}
            // tx._handle_notification_data('demo', notification_data)
            // 
            // return child_void_tx
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _send_void_request(self, amount_to_void=None):
            // """ Override of `payment` to explain that it is impossible to void a Razorpay transaction.
            // """
            // child_void_tx = super()._send_void_request(amount_to_void=amount_to_void)
            // if self.provider_code != 'razorpay':
            //     return child_void_tx
            // 
            // raise UserError(_("Transactions processed by Razorpay can't be manually voided from Odoo."))
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _send_void_request(self, amount_to_void=None):
            // """ Override of `payment` to send a void request to Stripe. """
            // child_void_tx = super()._send_void_request(amount_to_void=amount_to_void)
            // if self.provider_code != 'stripe':
            //     return child_void_tx
            // 
            // # Make the void request to Stripe
            // payment_intent = self.provider_id._stripe_make_request(
            //     f'payment_intents/{self.provider_reference}/cancel'
            // )
            // _logger.info(
            //     "void request response for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(payment_intent)
            // )
            // 
            // # Handle the void request response
            // notification_data = {'reference': self.reference}
            // StripeController._include_payment_intent_in_notification_data(
            //     payment_intent, notification_data
            // )
            // self._handle_notification_data('stripe', notification_data)
            // 
            // return child_void_tx
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetAuthorizedInternalAsync(object state_message, object extra_allowed_states)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _set_authorized(self, state_message=None, extra_allowed_states=()):
            // """ Update the transactions' state to `authorized`.
            // 
            // :param str state_message: The reason for setting the transactions in the state `authorized`.
            // :param tuple[str] extra_allowed_states: The extra states that should be considered allowed
            //                                         target states for the source state 'authorized'.
            // :return: The updated transactions.
            // :rtype: recordset of `payment.transaction`
            // """
            // allowed_states = ('draft', 'pending')
            // target_state = 'authorized'
            // txs_to_process = self._update_state(
            //     allowed_states + extra_allowed_states, target_state, state_message
            // )
            // txs_to_process._log_received_message()
            // return txs_to_process
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetCanceledInternalAsync(object state_message, object extra_allowed_states)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _set_canceled(self, state_message=None, extra_allowed_states=()):
            // """ Update the transactions' state to `cancel`.
            // 
            // :param str state_message: The reason for setting the transactions in the state `cancel`.
            // :param tuple[str] extra_allowed_states: The extra states that should be considered allowed
            //                                         target states for the source state 'canceled'.
            // :return: The updated transactions.
            // :rtype: recordset of `payment.transaction`
            // """
            // allowed_states = ('draft', 'pending', 'authorized')
            // target_state = 'cancel'
            // txs_to_process = self._update_state(
            //     allowed_states + extra_allowed_states, target_state, state_message
            // )
            // txs_to_process._update_source_transaction_state()
            // txs_to_process._log_received_message()
            // return txs_to_process
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetDoneInternalAsync(object state_message, object extra_allowed_states)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _set_done(self, state_message=None, extra_allowed_states=()):
            // """ Update the transactions' state to `done`.
            // 
            // :param str state_message: The reason for setting the transactions in the state `done`.
            // :param tuple[str] extra_allowed_states: The extra states that should be considered allowed
            //                                         target states for the source state 'done'.
            // :return: The updated transactions.
            // :rtype: recordset of `payment.transaction`
            // """
            // allowed_states = ('draft', 'pending', 'authorized', 'error')
            // target_state = 'done'
            // txs_to_process = self._update_state(
            //     allowed_states + extra_allowed_states, target_state, state_message
            // )
            // txs_to_process._update_source_transaction_state()
            // txs_to_process._log_received_message()
            // return txs_to_process
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetErrorInternalAsync(object state_message, object extra_allowed_states)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _set_error(self, state_message, extra_allowed_states=()):
            // """ Update the transactions' state to `error`.
            // 
            // :param str state_message: The reason for setting the transactions in the state `error`.
            // :param tuple[str] extra_allowed_states: The extra states that should be considered allowed
            //                                         target states for the source state 'error'.
            // :return: The updated transactions.
            // :rtype: recordset of `payment.transaction`
            // """
            // allowed_states = ('draft', 'pending', 'authorized')
            // target_state = 'error'
            // txs_to_process = self._update_state(
            //     allowed_states + extra_allowed_states, target_state, state_message
            // )
            // txs_to_process._log_received_message()
            // return txs_to_process
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetPendingInternalAsync(object state_message, object extra_allowed_states)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _set_pending(self, state_message=None, extra_allowed_states=()):
            // """ Update the transactions' state to `pending`.
            // 
            // :param str state_message: The reason for setting the transactions in the state `pending`.
            // :param tuple[str] extra_allowed_states: The extra states that should be considered allowed
            //                                         target states for the source state 'pending'.
            // :return: The updated transactions.
            // :rtype: recordset of `payment.transaction`
            // """
            // allowed_states = ('draft',)
            // target_state = 'pending'
            // txs_to_process = self._update_state(
            //     allowed_states + extra_allowed_states, target_state, state_message
            // )
            // txs_to_process._log_received_message()
            // return txs_to_process
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripeCreateCustomerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _stripe_create_customer(self):
            // """ Create and return a Customer.
            // 
            // :return: The Customer
            // :rtype: dict
            // """
            // customer = self.provider_id._stripe_make_request(
            //     'customers', payload={
            //         'address[city]': self.partner_city or None,
            //         'address[country]': self.partner_country_id.code or None,
            //         'address[line1]': self.partner_address or None,
            //         'address[postal_code]': self.partner_zip or None,
            //         'address[state]': self.partner_state_id.name or None,
            //         'description': f'Odoo Partner: {self.partner_id.name} (id: {self.partner_id.id})',
            //         'email': self.partner_email or None,
            //         'name': self.partner_name,
            //         'phone': self.partner_phone and self.partner_phone[:20] or None,
            //     }
            // )
            // return customer
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripeCreateIntentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _stripe_create_intent(self):
            // """ Create and return a PaymentIntent or a SetupIntent object, depending on the operation.
            // 
            // :return: The created PaymentIntent or SetupIntent object.
            // :rtype: dict
            // """
            // if self.operation == 'validation':
            //     response = self.provider_id._stripe_make_request(
            //         'setup_intents', payload=self._stripe_prepare_setup_intent_payload()
            //     )
            // else:  # 'online_direct', 'online_token', 'offline'.
            //     response = self.provider_id._stripe_make_request(
            //         'payment_intents',
            //         payload=self._stripe_prepare_payment_intent_payload(),
            //         offline=self.operation == 'offline',
            //         # Prevent multiple offline payments by token (e.g., due to a cursor rollback).
            //         idempotency_key=payment_utils.generate_idempotency_key(
            //             self, scope='payment_intents_token'
            //         ) if self.operation == 'offline' else None,
            //     )
            // 
            // if 'error' not in response:
            //     intent = response
            // else:  # A processing error was returned in place of the intent.
            //     # The request failed and no error was raised because we are in an offline payment flow.
            //     # Extract the error from the response, log it, and set the transaction in error to let
            //     # the calling module handle the issue without rolling back the cursor.
            //     error_msg = response['error'].get('message')
            //     _logger.warning(
            //         "The creation of the intent failed.\n"
            //         "Stripe gave us the following info about the problem:\n'%s'", error_msg
            //     )
            //     self._set_error("Stripe: " + _(
            //         "The communication with the API failed.\n"
            //         "Stripe gave us the following info about the problem:\n'%s'", error_msg
            //     ))  # Flag transaction as in error now, as the intent status might have a valid value.
            //     intent = response['error'].get('payment_intent') \
            //              or response['error'].get('setup_intent')  # Get the intent from the error.
            // 
            // return intent
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripePrepareMandateOptionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _stripe_prepare_mandate_options(self):
            // """ Prepare the configuration options for setting up an eMandate along with an intent.
            // 
            // :return: The Stripe-formatted payload for the mandate options.
            // :rtype: dict
            // """
            // mandate_values = self._get_mandate_values()
            // 
            // OPTION_PATH_PREFIX = 'payment_method_options[card][mandate_options]'
            // mandate_options = {
            //     f'{OPTION_PATH_PREFIX}[reference]': self.reference,
            //     f'{OPTION_PATH_PREFIX}[amount_type]': 'maximum',
            //     f'{OPTION_PATH_PREFIX}[amount]': payment_utils.to_minor_currency_units(
            //         mandate_values.get('amount', 15000), self.currency_id
            //     ),  # Use the specified amount, if any, or define the maximum amount of 15.000 INR.
            //     f'{OPTION_PATH_PREFIX}[start_date]': int(round(
            //         (mandate_values.get('start_datetime') or fields.Datetime.now()).timestamp()
            //     )),
            //     f'{OPTION_PATH_PREFIX}[interval]': 'sporadic',
            //     f'{OPTION_PATH_PREFIX}[supported_types][]': 'india',
            // }
            // if mandate_values.get('end_datetime'):
            //     mandate_options[f'{OPTION_PATH_PREFIX}[end_date]'] = int(round(
            //         mandate_values['end_datetime'].timestamp()
            //     ))
            // if mandate_values.get('recurrence_unit') and mandate_values.get('recurrence_duration'):
            //     mandate_options.update({
            //         f'{OPTION_PATH_PREFIX}[interval]': mandate_values['recurrence_unit'],
            //         f'{OPTION_PATH_PREFIX}[interval_count]': mandate_values['recurrence_duration'],
            //     })
            // if self.operation == 'validation':
            //     currency_name = self.provider_id.with_context(
            //         validation_pm=self.payment_method_id  # Will be converted to a kwarg in master.
            //     )._get_validation_currency().name.lower()
            //     mandate_options[f'{OPTION_PATH_PREFIX}[currency]'] = currency_name
            // 
            // return mandate_options
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripePreparePaymentIntentPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _stripe_prepare_payment_intent_payload(self):
            // """ Prepare the payload for the creation of a PaymentIntent object in Stripe format.
            // 
            // Note: This method serves as a hook for modules that would fully implement Stripe Connect.
            // 
            // :return: The Stripe-formatted payload for the PaymentIntent request.
            // :rtype: dict
            // """
            // ppm_code = self.payment_method_id.primary_payment_method_id.code
            // payment_method_type = ppm_code or self.payment_method_code
            // payment_intent_payload = {
            //     'amount': payment_utils.to_minor_currency_units(self.amount, self.currency_id),
            //     'currency': self.currency_id.name.lower(),
            //     'description': self.reference,
            //     'capture_method': 'manual' if self.provider_id.capture_manually else 'automatic',
            //     'payment_method_types[]': const.PAYMENT_METHODS_MAPPING.get(
            //         payment_method_type, payment_method_type
            //     ),
            //     'expand[]': 'payment_method',
            //     **stripe_utils.include_shipping_address(self),
            // }
            // if self.operation in ['online_token', 'offline']:
            //     if not self.token_id.stripe_payment_method:  # Pre-SCA token, migrate it.
            //         self.token_id._stripe_sca_migrate_customer()
            // 
            //     payment_intent_payload.update({
            //         'confirm': True,
            //         'customer': self.token_id.provider_ref,
            //         'off_session': True,
            //         'payment_method': self.token_id.stripe_payment_method,
            //         'mandate': self.token_id.stripe_mandate or None,
            //     })
            // else:
            //     customer = self._stripe_create_customer()
            //     payment_intent_payload['customer'] = customer['id']
            //     if self.tokenize:
            //         payment_intent_payload['setup_future_usage'] = 'off_session'
            //         if self.currency_id.name in const.INDIAN_MANDATES_SUPPORTED_CURRENCIES:
            //             payment_intent_payload.update(**self._stripe_prepare_mandate_options())
            // return payment_intent_payload
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripePrepareSetupIntentPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _stripe_prepare_setup_intent_payload(self):
            // """ Prepare the payload for the creation of a SetupIntent object in Stripe format.
            // 
            // Note: This method serves as a hook for modules that would fully implement Stripe Connect.
            // 
            // :return: The Stripe-formatted payload for the SetupIntent request.
            // :rtype: dict
            // """
            // customer = self._stripe_create_customer()
            // setup_intent_payload = {
            //     'customer': customer['id'],
            //     'description': self.reference,
            //     'payment_method_types[]': const.PAYMENT_METHODS_MAPPING.get(
            //         self.payment_method_code, self.payment_method_code
            //     ),
            // }
            // if self.currency_id.name in const.INDIAN_MANDATES_SUPPORTED_CURRENCIES:
            //     setup_intent_payload.update(**self._stripe_prepare_mandate_options())
            // return setup_intent_payload
            */
            return default;
        }

        protected async Task<PaymentTransaction> StripeTokenizeFromNotificationDataInternalAsync(object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _stripe_tokenize_from_notification_data(self, notification_data):
            // """ Create a new token based on the notification data.
            // 
            // :param dict notification_data: The notification data built with Stripe objects.
            //                                See `_process_notification_data`.
            // :return: None
            // """
            // payment_method = notification_data.get('payment_method')
            // if not payment_method:
            //     _logger.warning(
            //         "requested tokenization from notification data with missing payment method"
            //     )
            //     return
            // 
            // mandate = None
            // # Extract the Stripe objects from the notification data.
            // if self.operation == 'online_direct':
            //     customer_id = notification_data['payment_intent']['customer']
            //     charges_data = notification_data['payment_intent']['charges']
            //     payment_method_details = charges_data['data'][0].get('payment_method_details')
            //     if payment_method_details:
            //         mandate = payment_method_details[payment_method_details['type']].get("mandate")
            // else:  # 'validation'
            //     customer_id = notification_data['setup_intent']['customer']
            // # Another payment method (e.g., SEPA) might have been generated.
            // if not payment_method[payment_method['type']]:
            //     payment_methods = self.provider_id._stripe_make_request(
            //         f'customers/{customer_id}/payment_methods', method='GET'
            //     )
            //     _logger.info("Received payment_methods response:\n%s", pprint.pformat(payment_methods))
            //     payment_method = payment_methods['data'][0]
            // 
            // # Create the token.
            // token = self.env['payment.token'].create({
            //     'provider_id': self.provider_id.id,
            //     'payment_method_id': self.payment_method_id.id,
            //     'payment_details': payment_method[payment_method['type']].get('last4'),
            //     'partner_id': self.partner_id.id,
            //     'provider_ref': customer_id,
            //     'stripe_payment_method': payment_method['id'],
            //     'stripe_mandate': mandate,
            // })
            // self.write({
            //     'token_id': token,
            //     'tokenize': False,
            // })
            // _logger.info(
            //     "created token with id %(token_id)s for partner with id %(partner_id)s from "
            //     "transaction with reference %(ref)s",
            //     {
            //         'token_id': token.id,
            //         'partner_id': self.partner_id.id,
            //         'ref': self.reference,
            //     },
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> UpdateSourceTransactionStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _update_source_transaction_state(self):
            // """ Update the state of the source transactions for which all child transactions have
            // reached a final state.
            // 
            // :return: None
            // """
            // for child_tx in self.filtered('source_transaction_id'):
            //     sibling_txs = child_tx.source_transaction_id.child_transaction_ids.filtered(
            //         lambda tx: tx.state in ['done', 'cancel'] and tx.operation == child_tx.operation
            //     )
            //     processed_amount = round(
            //         sum(tx.amount for tx in sibling_txs), child_tx.currency_id.decimal_places
            //     )
            //     if child_tx.source_transaction_id.amount == processed_amount:
            //         state_message = _(
            //             "This transaction has been confirmed following the processing of its partial "
            //             "capture and partial void transactions (%(provider)s).",
            //             provider=child_tx.provider_id.name,
            //         )
            //         # Call `_update_state` directly instead of `_set_authorized` to avoid looping.
            //         child_tx.source_transaction_id._update_state(('authorized',), 'done', state_message)
            */
            return default;
        }

        protected async Task<PaymentTransaction> UpdateStateInternalAsync(object allowed_states, object target_state, object state_message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _update_state(self, allowed_states, target_state, state_message):
            // """ Update the transactions' state to the target state if the current state allows it.
            // 
            // If the current state is the same as the target state, the transaction is skipped and a log
            // with level INFO is created.
            // 
            // :param tuple[str] allowed_states: The allowed source states for the target state.
            // :param str target_state: The target state.
            // :param str state_message: The message to set as `state_message`.
            // :return: The recordset of transactions whose state was updated.
            // :rtype: recordset of `payment.transaction`
            // """
            // def classify_by_state(transactions_):
            //     """ Classify the transactions according to their current state.
            // 
            //     For each transaction of the current recordset, if:
            // 
            //     - The state is an allowed state: the transaction is flagged as `to process`.
            //     - The state is equal to the target state: the transaction is flagged as `processed`.
            //     - The state matches none of above: the transaction is flagged as `in wrong state`.
            // 
            //     :param recordset transactions_: The transactions to classify, as a `payment.transaction`
            //                                     recordset.
            //     :return: A 3-items tuple of recordsets of classified transactions, in this order:
            //              transactions `to process`, `processed`, and `in wrong state`.
            //     :rtype: tuple(recordset)
            //     """
            //     txs_to_process_ = transactions_.filtered(lambda _tx: _tx.state in allowed_states)
            //     txs_already_processed_ = transactions_.filtered(lambda _tx: _tx.state == target_state)
            //     txs_wrong_state_ = transactions_ - txs_to_process_ - txs_already_processed_
            // 
            //     return txs_to_process_, txs_already_processed_, txs_wrong_state_
            // 
            // txs_to_process, txs_already_processed, txs_wrong_state = classify_by_state(self)
            // for tx in txs_already_processed:
            //     _logger.info(
            //         "tried to write on transaction with reference %s with the same value for the "
            //         "state: %s",
            //         tx.reference, tx.state,
            //     )
            // for tx in txs_wrong_state:
            //     _logger.warning(
            //         "tried to write on transaction with reference %(ref)s with illegal value for the "
            //         "state (previous state: %(tx_state)s, target state: %(target_state)s, expected "
            //         "previous state to be in: %(allowed_states)s)",
            //         {
            //             'ref': tx.reference,
            //             'tx_state': tx.state,
            //             'target_state': target_state,
            //             'allowed_states': allowed_states,
            //         },
            //     )
            // txs_to_process.write({
            //     'state': target_state,
            //     'state_message': state_message,
            //     'last_state_change': fields.Datetime.now(),
            //     'is_post_processed': False,  # Reset to allow post-processing again for other states.
            // })
            // return txs_to_process
            */
            return default;
        }

        protected async Task<PaymentTransaction> ValidatePhoneNumberInternalAsync(object phone)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _validate_phone_number(self, phone):
            // """ Validate and format the phone number.
            // 
            // :param str phone: The phone number to validate.
            // :return str: The formatted phone number.
            // :raise ValidationError: If the phone number is missing or incorrect.
            // """
            // if not phone and self.tokenize:
            //     raise ValidationError("Razorpay: " + _("The phone number is missing."))
            // 
            // try:
            //     phone = self._phone_format(
            //         number=phone, country=self.partner_country_id, raise_exception=self.tokenize
            //     )
            // except Exception:
            //     raise ValidationError("Razorpay: " + _("The phone number is invalid."))
            // return phone
            */
            return default;
        }

        public async Task<PaymentTransaction> ViewInvoicesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py) ---
            // def action_view_invoices(self):
            // """ Return the action for the views of the invoices linked to the transaction.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The action
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // action = {
            //     'name': _("Invoices"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.move',
            //     'target': 'current',
            // }
            // invoice_ids = self.invoice_ids.ids
            // if len(invoice_ids) == 1:
            //     invoice = invoice_ids[0]
            //     action['res_id'] = invoice
            //     action['view_mode'] = 'form'
            //     action['views'] = [(self.env.ref('account.view_move_form').id, 'form')]
            // else:
            //     action['view_mode'] = 'list,form'
            //     action['domain'] = [('id', 'in', invoice_ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PaymentTransaction> ViewPosOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: payment_transaction.py) ---
            // def action_view_pos_order(self):
            // """ Return the action for the view of the pos order linked to the transaction.
            // """
            // self.ensure_one()
            // 
            // action = {
            //     'name': _("POS Order"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'pos.order',
            //     'target': 'current',
            //     'res_id': self.pos_order_id.id,
            //     'view_mode': 'form'
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PaymentTransaction> ViewRefundsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def action_view_refunds(self):
            // """ Return the windows action to browse the refund transactions linked to the transaction.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The window action to browse the refund transactions.
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // action = {
            //     'name': _("Refund"),
            //     'res_model': 'payment.transaction',
            //     'type': 'ir.actions.act_window',
            // }
            // if self.refunds_count == 1:
            //     refund_tx = self.env['payment.transaction'].search([
            //         ('source_transaction_id', '=', self.id),
            //     ])[0]
            //     action['res_id'] = refund_tx.id
            //     action['view_mode'] = 'form'
            // else:
            //     action['view_mode'] = 'list,form'
            //     action['domain'] = [('source_transaction_id', '=', self.id)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PaymentTransaction> ViewSalesOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def action_view_sales_orders(self):
            // action = {
            //     'name': _('Sales Order(s)'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'sale.order',
            //     'target': 'current',
            // }
            // sale_order_ids = self.sale_order_ids.ids
            // if len(sale_order_ids) == 1:
            //     action['res_id'] = sale_order_ids[0]
            //     action['view_mode'] = 'form'
            // else:
            //     action['view_mode'] = 'list,form'
            //     action['domain'] = [('id', 'in', sale_order_ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<PaymentTransaction> VoidAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def action_void(self):
            // """ Check the state of the transaction and request to have them voided. """
            // payment_utils.check_rights_on_recordset(self)
            // 
            // if any(tx.state != 'authorized' for tx in self):
            //     raise ValidationError(_("Only authorized transactions can be voided."))
            // 
            // for tx in self:
            //     # Consider all the confirmed partial capture (same operation as parent) child txs.
            //     captured_amount = sum(child_tx.amount for child_tx in tx.child_transaction_ids.filtered(
            //         lambda t: t.state == 'done' and t.operation == tx.operation
            //     ))
            //     # In sudo mode because we need to be able to read on provider fields.
            //     tx.sudo()._send_void_request(amount_to_void=tx.amount - captured_amount)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentTransaction> WorldlineCreateCheckoutSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _worldline_create_checkout_session(self):
            // """ Create a hosted checkout session and return the response data.
            // 
            // :return: The hosted checkout session data.
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // base_url = self.provider_id.get_base_url()
            // return_route = WorldlineController._return_url
            // return_url_params = urls.url_encode({'provider_id': str(self.provider_id.id)})
            // return_url = f'{urls.url_join(base_url, return_route)}?{return_url_params}'
            // first_name, last_name = payment_utils.split_partner_name(self.partner_name)
            // payload = {
            //     'hostedCheckoutSpecificInput': {
            //         'locale': self.partner_lang or '',
            //         'returnUrl': return_url,
            //         'showResultPage': False,
            //     },
            //     'order': {
            //         'amountOfMoney': {
            //             'amount': payment_utils.to_minor_currency_units(self.amount, self.currency_id),
            //             'currencyCode': self.currency_id.name,
            //         },
            //         'customer': {  # required to create a token and for some redirected payment methods
            //             'billingAddress': {
            //                 'city': self.partner_city or '',
            //                 'countryCode': self.partner_country_id.code or '',
            //                 'state': self.partner_state_id.name or '',
            //                 'street': self.partner_address or '',
            //                 'zip': self.partner_zip or '',
            //             },
            //             'contactDetails': {
            //                 'emailAddress': self.partner_email or '',
            //                 'phoneNumber': self.partner_phone or '',
            //             },
            //             'personalInformation': {
            //                 'name': {
            //                     'firstName': first_name or '',
            //                     'surname': last_name or '',
            //                 },
            //             },
            //         },
            //         'references': {
            //             'descriptor': self.reference,
            //             'merchantReference': self.reference,
            //         },
            //     },
            // }
            // if self.payment_method_id.code in const.REDIRECT_PAYMENT_METHODS:
            //     payload['redirectPaymentMethodSpecificInput'] = {
            //         'requiresApproval': False,  # Force the capture.
            //         'paymentProductId': const.PAYMENT_METHODS_MAPPING[self.payment_method_id.code],
            //         'redirectionData': {
            //             'returnUrl': return_url,
            //         },
            //     }
            // else:
            //     payload['cardPaymentMethodSpecificInput'] = {
            //         'authorizationMode': 'SALE',  # Force the capture.
            //         'tokenize': self.tokenize,
            //     }
            //     if not self.payment_method_id.brand_ids and self.payment_method_id.code != 'card':
            //         worldline_code = const.PAYMENT_METHODS_MAPPING.get(self.payment_method_id.code, 0)
            //         payload['cardPaymentMethodSpecificInput']['paymentProductId'] = worldline_code
            //     else:
            //         pm_codes = self.env['payment.method'].search([
            //             ('active', 'in', [True, False]),
            //             ('primary_payment_method_id', '=', self.payment_method_id.id),
            //         ]).mapped('code')
            //         worldline_codes = [
            //             const.PAYMENT_METHODS_MAPPING[code] for code in pm_codes
            //             if code in const.PAYMENT_METHODS_MAPPING
            //         ]
            //         payload['hostedCheckoutSpecificInput']['paymentProductFilters'] = {
            //             'restrictTo': {
            //                 'products': worldline_codes,
            //             },
            //         }
            // 
            // _logger.info(
            //     "Sending '/hostedcheckouts' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(payload)
            // )
            // checkout_session_data = self.provider_id._worldline_make_request(
            //     'hostedcheckouts', payload=payload
            // )
            // _logger.info(
            //     "Response of '/hostedcheckouts' request for transaction with reference %s:\n%s",
            //     self.reference, pprint.pformat(checkout_session_data)
            // )
            // return checkout_session_data
            */
            return default;
        }

        protected async Task<PaymentTransaction> WorldlineTokenizeFromNotificationDataInternalAsync(object pm_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _worldline_tokenize_from_notification_data(self, pm_data):
            // """ Create a new token based on the notification data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict pm_data: The payment method data sent by the provider
            // :return: None
            // """
            // self.ensure_one()
            // 
            // token = self.env['payment.token'].create({
            //     'provider_id': self.provider_id.id,
            //     'payment_method_id': self.payment_method_id.id,
            //     'payment_details': pm_data.get('card', {}).get('cardNumber', '')[-4:],  # Padded with *
            //     'partner_id': self.partner_id.id,
            //     'provider_ref': pm_data['token'],
            // })
            // self.write({
            //     'token_id': token,
            //     'tokenize': False,
            // })
            // _logger.info(
            //     "Created token with id %(token_id)s for partner with id %(partner_id)s from "
            //     "transaction with reference %(ref)s",
            //     {'token_id': token.id, 'partner_id': self.partner_id.id, 'ref': self.reference},
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> XenditCreateChargeInternalAsync(object token_ref)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _xendit_create_charge(self, token_ref):
            // """ Create a charge on Xendit using the `credit_card_charges` endpoint.
            // 
            // :param str token_ref: The reference of the Xendit token to use to make the payment.
            // :return: None
            // """
            // if self.currency_id.name in const.CURRENCY_DECIMALS:
            //     rounding = const.CURRENCY_DECIMALS.get(self.currency_id.name)
            // else:
            //     rounding = self.currency_id.decimal_places
            // rounded_amount = float_round(self.amount, rounding, rounding_method='DOWN')
            // payload = {
            //     'token_id': token_ref,
            //     'external_id': self.reference,
            //     'amount': rounded_amount,
            //     'currency': self.currency_id.name,
            // }
            // charge_notification_data = self.provider_id._xendit_make_request(
            //     'credit_card_charges', payload=payload
            // )
            // self._handle_notification_data('xendit', charge_notification_data)
            */
            return default;
        }

        protected async Task<PaymentTransaction> XenditPrepareInvoiceRequestPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _xendit_prepare_invoice_request_payload(self):
            // """ Create the payload for the invoice request based on the transaction values.
            // 
            // :return: The request payload.
            // :rtype: dict
            // """
            // base_url = self.provider_id.get_base_url()
            // redirect_url = urls.url_join(base_url, XenditController._return_url)
            // access_token = payment_utils.generate_access_token(self.reference, self.amount)
            // success_url_params = urls.url_encode({
            //     'tx_ref': self.reference,
            //     'access_token': access_token,
            //     'success': 'true',
            // })
            // payload = {
            //     'external_id': self.reference,
            //     'amount': self.amount,
            //     'description': self.reference,
            //     'customer': {
            //         'given_names': self.partner_name,
            //     },
            //     'success_redirect_url': f'{redirect_url}?{success_url_params}',
            //     'failure_redirect_url': redirect_url,
            //     'payment_methods': [const.PAYMENT_METHODS_MAPPING.get(
            //         self.payment_method_code, self.payment_method_code.upper())
            //     ],
            //     'currency': self.currency_id.name,
            // }
            // # Extra payload values that must not be included if empty.
            // if self.partner_email:
            //     payload['customer']['email'] = self.partner_email
            // if phone := self.partner_id.mobile or self.partner_id.phone:
            //     payload['customer']['mobile_number'] = phone
            // address_details = {}
            // if self.partner_city:
            //     address_details['city'] = self.partner_city
            // if self.partner_country_id.name:
            //     address_details['country'] = self.partner_country_id.name
            // if self.partner_zip:
            //     address_details['postal_code'] = self.partner_zip
            // if self.partner_state_id.name:
            //     address_details['state'] = self.partner_state_id.name
            // if self.partner_address:
            //     address_details['street_line1'] = self.partner_address
            // if address_details:
            //     payload['customer']['addresses'] = [address_details]
            // 
            // return payload
            */
            return default;
        }

        protected async Task<PaymentTransaction> XenditTokenizeFromNotificationDataInternalAsync(object notification_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _xendit_tokenize_from_notification_data(self, notification_data):
            // """ Create a new token based on the notification data.
            // 
            // :param dict notification_data: Xendit's response to a charge API request.
            // :return: None
            // """
            // card_info = notification_data['masked_card_number'][-4:]  # Xendit pads details with X's.
            // token_id = notification_data['credit_card_token_id']
            // token = self.env['payment.token'].create({
            //     "provider_id": self.provider_id.id,
            //     "payment_method_id": self.payment_method_id.id,
            //     "payment_details": card_info,
            //     "partner_id": self.partner_id.id,
            //     "provider_ref": token_id,
            // })
            // self.write({
            //     'token_id': token.id,
            //     'tokenize': False,
            // })
            // _logger.info(
            //     "created token with id %(token_id)s for partner with id %(partner_id)s from "
            //     "transaction with reference %(ref)s",
            //     {
            //         'token_id': token.id,
            //         'partner_id': self.partner_id.id,
            //         'ref': self.reference,
            //     },
            // )
            */
            return default;
        }
    }
}