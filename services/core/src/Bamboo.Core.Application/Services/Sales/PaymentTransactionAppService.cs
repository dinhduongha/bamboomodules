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
    public partial class PaymentTransactionAppService : GenericApplicationService<PaymentTransaction>, IPaymentTransactionAppService
    {

        public PaymentTransactionAppService(IRepository<PaymentTransaction, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<PaymentTransaction> AdyenCreateChildTxInternalAsync(object source_tx, object payment_data, object is_refund)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _adyen_create_child_tx(self, source_tx, payment_data, is_refund=False):
            // """Create a child transaction based on Adyen data.
            // 
            // :param payment.transaction source_tx: The source transaction for which a new operation is
            //                                       initiated.
            // :param dict payment_data: The payment data sent by the provider.
            // :return: The newly created child transaction.
            // :rtype: payment.transaction
            // """
            // provider_reference = payment_data.get('pspReference')
            // amount = payment_data.get('amount', {}).get('value')
            // if not provider_reference or amount is None:  # amount == 0 if success == False
            //     _logger.warning("Received data for child transaction with missing transaction values.")
            //     return self.env['payment.transaction']
            // 
            // converted_amount = payment_utils.to_major_currency_units(
            //     amount,
            //     source_tx.currency_id,
            //     arbitrary_decimal_number=const.CURRENCY_DECIMALS.get(self.currency_id.name),
            // )
            // return source_tx._create_child_transaction(
            //     converted_amount, is_refund=is_refund, provider_reference=provider_reference
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> ApplyUpdatesInternalAsync(object payment_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Update the transaction based on the payment data received from the provider.
            // 
            // The updates typically include the payment's state, the provider reference, and the selected
            // payment method.
            // 
            // This method should not be called directly; payment data should go through :meth:`_process`.
            // 
            // This method must be overridden by providers to update the transaction based on the payment
            // data.
            // 
            // Note: `self.ensure_one()` from :meth:`_process`
            // 
            // :param dict payment_data: The payment data sent by the provider.
            // :return: None
            // """
            // return
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of payment to update the transaction based on the payment data."""
            // if self.provider_code != 'adyen':
            //     return super()._apply_updates(payment_data)
            // 
            // # Extract or assume the event code. If none is provided, the feedback data originate from a
            // # direct payment request whose feedback data share the same payload as an 'AUTHORISATION'
            // # webhook notification.
            // event_code = payment_data.get('eventCode', 'AUTHORISATION')
            // 
            // # Update the provider reference. If the event code is 'CAPTURE' or 'CANCELLATION', we
            // # discard the pspReference as it is different from the original pspReference of the tx.
            // if 'pspReference' in payment_data and event_code in ['AUTHORISATION', 'REFUND']:
            //     self.provider_reference = payment_data.get('pspReference')
            // 
            // # Update the payment method.
            // payment_method_data = payment_data.get('paymentMethod', '')
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
            // payment_state = payment_data.get('resultCode')
            // refusal_reason = payment_data.get('refusalReason') or payment_data.get('reason')
            // if not payment_state:
            //     self._set_error(_("Received data with missing payment state."))
            // elif payment_state in const.RESULT_CODES_MAPPING['pending']:
            //     self._set_pending()
            // elif payment_state in const.RESULT_CODES_MAPPING['done']:
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
            //             "The transaction %s underwent an error. reason: %s.",
            //             self.reference, refusal_reason,
            //         )
            //         self._set_error(
            //             _("An error occurred during the processing of your payment. Please try again.")
            //         )
            //     elif event_code == 'CANCELLATION':
            //         _logger.warning(
            //             "The void of the transaction %s failed. reason: %s.",
            //             self.reference, refusal_reason,
            //         )
            //         if self.source_transaction_id:  # child tx => The event can't be retried.
            //             self._set_error(_("The void of the transaction %s failed.", self.reference))
            //         else:  # source tx with failed void stays in its state, could be voided again
            //             self._log_message_on_linked_documents(
            //                 _("The void of the transaction %s failed.", self.reference)
            //             )
            //     else:  # 'CAPTURE', 'CAPTURE_FAILED'
            //         _logger.warning(
            //             "The capture of the transaction %s failed. reason: %s.",
            //             self.reference, refusal_reason,
            //         )
            //         if self.source_transaction_id:  # child_tx => The event can't be retried.
            //             self._set_error(_(
            //                 "The capture of the transaction %s failed.", self.reference
            //             ))
            //         else:  # source tx with failed capture stays in its state, could be captured again
            //             self._log_message_on_linked_documents(_(
            //                 "The capture of the transaction %s failed.", self.reference
            //             ))
            // elif payment_state in const.RESULT_CODES_MAPPING['refused']:
            //     _logger.warning(
            //         "the transaction %s was refused. reason: %s",
            //         self.reference, refusal_reason
            //     )
            //     self._set_error(_("Your payment was refused. Please try again."))
            // else:  # Classify unsupported payment state as `error` tx state
            //     _logger.warning(
            //         "received data for transaction %s with invalid payment state: %s",
            //         self.reference, payment_state
            //     )
            //     self._set_error(
            //         "Adyen: " + _("Received data with invalid payment state: %s", payment_state)
            //     )
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment' to update the transaction based on the payment data."""
            // if self.provider_code != 'aps':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the provider reference.
            // self.provider_reference = payment_data.get('fort_id')
            // 
            // # Update the payment method.
            // payment_option = payment_data.get('payment_option', '')
            // payment_method = self.env['payment.method']._get_from_code(payment_option.lower())
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status = payment_data.get('status')
            // if not status:
            //     self._set_error(_("Received data with missing payment state."))
            // elif status in PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif status in PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // else:  # Classify unsupported payment state as `error` tx state.
            //     status_description = payment_data.get('response_message')
            //     _logger.info(
            //         "Received data with invalid payment status (%(status)s) and reason '%(reason)s' "
            //         "for transaction %(ref)s.",
            //         {'status': status, 'reason': status_description, 'ref': self.reference},
            //     )
            //     self._set_error(_(
            //         "Received invalid transaction status %(status)s and reason '%(reason)s'.",
            //         status=status, reason=status_description
            //     ))
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment' to update the transaction based on the payment data."""
            // if self.provider_code != 'asiapay':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the provider reference.
            // self.provider_reference = payment_data.get('PayRef')
            // 
            // # Update the payment method.
            // payment_method_code = payment_data.get('payMethod')
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // success_code = payment_data.get('successcode')
            // primary_response_code = payment_data.get('prc')
            // if not success_code:
            //     raise ValidationError(_("Received data with missing success code."))
            // if success_code in const.SUCCESS_CODE_MAPPING['done']:
            //     self._set_done()
            // elif success_code in const.SUCCESS_CODE_MAPPING['error']:
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (success code %(success_code)s; primary "
            //         "response code %(response_code)s). Please try again.", success_code=success_code, response_code=primary_response_code,
            //     ))
            // else:
            //     _logger.warning(
            //         "Received data with invalid success code (%s) for transaction with primary response"
            //         " code %s and reference %s.", success_code, primary_response_code, self.reference
            //     )
            //     self._set_error(_("Unknown success code: %s", success_code))
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'authorize':
            //     return super()._apply_updates(payment_data)
            // 
            // response_content = payment_data.get('response')
            // 
            // # Update the provider reference.
            // self.provider_reference = response_content.get('x_trans_id')
            // 
            // # Update the payment method.
            // payment_method_code = response_content.get('payment_method_code', '').lower()
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status_code = response_content.get('x_response_code', '3')
            // if status_code == '1':  # Approved
            //     status_type = response_content.get('x_type').lower()
            //     if status_type in ('auth_capture', 'prior_auth_capture'):
            //         self._set_done()
            //     elif status_type == 'auth_only':
            //         self._set_authorized()
            //         if self.operation == 'validation':
            //             self._void()  # In last step because it processes the response.
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
            //         "Received data with invalid status (%(status)s) and error code (%(err)s) for "
            //         "transaction %(ref)s.",
            //         {
            //             'status': status_code,
            //             'err': error_code,
            //             'ref': self.reference,
            //         },
            //     )
            //     self._set_error(_(
            //         "Received data with status code \"%(status)s\" and error code \"%(error)s\".",
            //         status=status_code, error=error_code
            //     ))
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'buckaroo':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the provider reference.
            // transaction_keys = payment_data.get('brq_transactions')
            // if not transaction_keys:
            //     self._set_error(_("Received data with missing transaction keys"))
            //     return
            // # BRQ_TRANSACTIONS can hold multiple, comma-separated, tx keys. In practice, it holds only
            // # one reference. So we split for semantic correctness and keep the first transaction key.
            // self.provider_reference = transaction_keys.split(',')[0]
            // 
            // # Update the payment method.
            // payment_method_code = payment_data.get('brq_payment_method')
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status_code = int(payment_data.get('brq_statuscode') or 0)
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
            //         "Received data with invalid payment status (%s) for transaction %s.",
            //         status_code, self.reference
            //     )
            //     self._set_error(_("Unknown status code: %s.", status_code))
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'custom':
            //     return super()._apply_updates(payment_data)
            // 
            // _logger.info(
            //     "Validated custom payment for transaction %s: set as pending.", self.reference
            // )
            // self._set_pending()
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'demo':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the provider reference.
            // self.provider_reference = f'demo-{self.reference}'
            // 
            // # Create the token.
            // if self.tokenize:
            //     # The reasons why we immediately tokenize the transaction instead of in `payment` are:
            //     # - To save the simulated state and payment details on the token while we have them.
            //     # - To allow customers to create tokens whose transactions will always end up in the
            //     #   said simulated state.
            //     self._tokenize(payment_data)
            // 
            // # Update the payment state.
            // state = payment_data['simulated_state']
            // if state == 'pending':
            //     self._set_pending()
            // elif state == 'done':
            //     if self.capture_manually and not payment_data.get('manual_capture'):
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
            --- ODOO METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'dpo':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the provider reference.
            // self.provider_reference = payment_data.get('TransID')
            // 
            // # Update the payment state.
            // status_code = payment_data.get('Result')
            // if status_code in const.PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif status_code in (
            //     const.PAYMENT_STATUS_MAPPING['authorized'] + const.PAYMENT_STATUS_MAPPING['done']
            // ):
            //     self._set_done()
            // elif status_code in const.PAYMENT_STATUS_MAPPING['cancel']:
            //     self._set_canceled()
            // elif status_code in const.PAYMENT_STATUS_MAPPING['error']:
            //     self._set_error(_(
            //         "An error occurred during processing of your payment (code %(code)s:"
            //         " %(explanation)s). Please try again.",
            //         code=status_code, explanation=payment_data.get('ResultExplanation'),
            //     ))
            // else:
            //     _logger.warning(
            //         "Received data with invalid payment status (%s) for transaction %s.",
            //         status_code, self.reference
            //     )
            //     self._set_error(_("Unknown status code: %s", status_code))
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'flutterwave':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the provider reference.
            // self.provider_reference = payment_data['id']
            // 
            // # Update payment method.
            // payment_method_type = payment_data.get('payment_type', '')
            // if payment_method_type == 'card':
            //     payment_method_type = payment_data.get('card', {}).get('type').lower()
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_type, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_status = payment_data['status'].lower()
            // if payment_status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     auth_url = payment_data.get('meta', {}).get('authorization', {}).get('redirect')
            //     if auth_url:
            //         # will be set back to the actual value after moving away from pending
            //         self.provider_reference = auth_url
            //     self._set_pending()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['cancel']:
            //     self._set_canceled()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['error']:
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (status %s). Please try "
            //         "again.", payment_status
            //     ))
            // else:
            //     _logger.warning(
            //         "Received data with invalid payment status (%s) for transaction %s.",
            //         payment_status, self.reference
            //     )
            //     self._set_error(_("Unknown payment status: %s", payment_status))
            --- ODOO METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of payment to update the transaction based on the payment data."""
            // if self.provider_code != 'iyzico':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the provider reference.
            // self.provider_reference = payment_data.get('paymentId')
            // 
            // # Update the payment method.
            // if bool(payment_data.get('cardType')):
            //     payment_method_code = payment_data.get('cardAssociation', '')
            //     payment_method = self.env['payment.method']._get_from_code(
            //         payment_method_code.lower(), mapping=const.PAYMENT_METHODS_MAPPING
            //     )
            // elif bool(payment_data.get('bankName')):
            //     payment_method = self.env.ref('payment.payment_method_bank_transfer')
            // else:
            //     payment_method = self.env.ref('payment.payment_method_unknown')
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status = payment_data.get('paymentStatus')
            // if status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif status in const.PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif status in const.PAYMENT_STATUS_MAPPING['error']:
            //     self._set_error(self.env._(
            //         "An error occurred during processing of your payment (code %(code)s:"
            //         " %(explanation)s). Please try again.",
            //         code=status, explanation=payment_data.get('errorMessage'),
            //     ))
            // else:
            //     _logger.warning(
            //         "Received data with invalid payment status (%s) for transaction with reference %s",
            //         status, self.reference
            //     )
            //     self._set_error(self.env._("Unknown status code: %s", status))
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'mercado_pago':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the provider reference.
            // payment_id = payment_data.get('id')
            // if not payment_id:
            //     self._set_error(_("Received data with missing payment id."))
            //     return
            // self.provider_reference = payment_id
            // 
            // # Update the payment method.
            // payment_method_type = payment_data.get('payment_type_id', '')
            // for odoo_code, mp_codes in const.PAYMENT_METHODS_MAPPING.items():
            //     if any(payment_method_type == mp_code for mp_code in mp_codes.split(',')):
            //         payment_method_type = odoo_code
            //         break
            // if payment_method_type == 'card':
            //     payment_method_code = payment_data.get('payment_method_id')
            // else:
            //     payment_method_code = payment_method_type
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // # Fall back to "unknown" if the payment method is not found (and if "unknown" is found), as
            // # the user might have picked a different payment method than on Odoo's payment form.
            // if not payment_method:
            //     payment_method = self.env['payment.method'].search([('code', '=', 'unknown')], limit=1)
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_status = payment_data.get('status')
            // if not payment_status:
            //     self._set_error(_("Received data with missing status."))
            //     return
            // 
            // if payment_status in const.TRANSACTION_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif payment_status in const.TRANSACTION_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif payment_status in const.TRANSACTION_STATUS_MAPPING['canceled']:
            //     self._set_canceled()
            // elif payment_status in const.TRANSACTION_STATUS_MAPPING['error']:
            //     status_detail = payment_data.get('status_detail')
            //     _logger.warning(
            //         "Received data for transaction %s with status %s and error code: %s.",
            //         self.reference, payment_status, status_detail
            //     )
            //     error_message = self._mercado_pago_get_error_msg(status_detail)
            //     self._set_error(error_message)
            // else:  # Classify unsupported payment status as the `error` tx state.
            //     _logger.warning(
            //         "Received data for transaction %s with invalid payment status: %s.",
            //         self.reference, payment_status
            //     )
            //     self._set_error(_("Received data with invalid status: %s.", payment_status))
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'mollie':
            //     return super()._apply_updates(payment_data)
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
            // if payment_status in ('pending', 'open'):
            //     self._set_pending()
            // elif payment_status == 'authorized':
            //     self._set_authorized()
            // elif payment_status == 'paid':
            //     self._set_done()
            // elif payment_status in ['expired', 'canceled', 'failed']:
            //     self._set_canceled(_("Cancelled payment with status: %s", payment_status))
            // else:
            //     _logger.info(
            //         "Received data with invalid payment status (%s) for transaction %s.",
            //         payment_status, self.reference
            //     )
            //     self._set_error(_("Received data with invalid payment status: %s.", payment_status))
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'nuvei':
            //     return super()._apply_updates(payment_data)
            // 
            // if not payment_data:
            //     self._set_canceled(state_message=_("The customer left the payment page."))
            //     return
            // 
            // # Update the provider reference.
            // self.provider_reference = payment_data.get('TransactionID')
            // 
            // # Update the payment method.
            // payment_option = payment_data.get('payment_method', '')
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_option, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status = payment_data.get('Status') or payment_data.get('ppp_status')
            // if not status:
            //     self._set_error(_("Received data with missing payment state."))
            //     return
            // status = status.lower()
            // if status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif status in const.PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif status in const.PAYMENT_STATUS_MAPPING['error']:
            //     failure_reason = payment_data.get('Reason') or payment_data.get('message')
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (%(reason)s). Please try"
            //         " again.", reason=failure_reason,
            //     ))
            // else:  # Classify unsupported payment states as the `error` tx state.
            //     status_description = payment_data.get('Reason')
            //     _logger.info(
            //         "Received data with invalid payment status (%(status)s) and reason '%(reason)s' "
            //         "for transaction %(ref)s.",
            //         {'status': status, 'reason': status_description, 'ref': self.reference},
            //     )
            //     self._set_error(_(
            //         "Received invalid transaction status %(status)s and reason '%(reason)s'.",
            //         status=status, reason=status_description
            //     ))
            --- ODOO METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'paymob':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the payment state.
            // if payment_data.get('pending') == 'true':
            //     self._set_pending()
            // elif payment_data.get('success') == 'true':
            //     self._set_done()
            // else:
            //     _logger.info(
            //         "Received data with unsuccessful payment status for transaction %s.",
            //         self.reference
            //     )
            //     message = payment_data.get('data.message')
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (%(msg)s). Please try"
            //         " again.", msg=message
            //     ))
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'paypal':
            //     return super()._apply_updates(payment_data)
            // 
            // if not payment_data:
            //     self._set_canceled(state_message=_("The customer left the payment page."))
            //     return
            // 
            // # Update the provider reference.
            // txn_id = payment_data.get('id')
            // txn_type = payment_data.get('txn_type')
            // if not all((txn_id, txn_type)):
            //     self._set_error(_(
            //         "Missing value for txn_id (%(txn_id)s) or txn_type (%(txn_type)s).",
            //         txn_id=txn_id, txn_type=txn_type
            //     ))
            //     return
            // self.provider_reference = txn_id
            // self.paypal_type = txn_type
            // 
            // # Force PayPal as the payment method if it exists.
            // self.payment_method_id = self.env['payment.method'].search(
            //     [('code', '=', 'paypal')], limit=1
            // ) or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_status = payment_data.get('status')
            // 
            // if payment_status in PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending(state_message=payment_data.get('pending_reason'))
            // elif payment_status in PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif payment_status in PAYMENT_STATUS_MAPPING['cancel']:
            //     self._set_canceled()
            // else:
            //     _logger.info(
            //         "Received data with invalid payment status (%s) for transaction %s.",
            //         payment_status, self.reference
            //     )
            //     self._set_error(_("Received data with invalid payment status: %s", payment_status))
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'razorpay':
            //     return super()._apply_updates(payment_data)
            // 
            // if 'id' in payment_data:  # We have the full entity data (S2S request or webhook).
            //     entity_data = payment_data
            // else:  # The payment data are not complete (Payments made by a token).
            //     # Fetch the full payment data.
            //     try:
            //         entity_data = self._send_api_request(
            //             'GET', f'payments/{payment_data["razorpay_payment_id"]}'
            //         )
            //     except ValidationError as e:
            //         self._set_error(str(e))
            //         return
            // 
            // # Update the provider reference.
            // entity_id = entity_data.get('id')
            // if not entity_id:
            //     self._set_error(_("Received data with missing entity id."))
            //     return
            // 
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
            //     self._set_error(_("Received data with missing status."))
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
            //         # In case the tokenization was requested on provider side not from odoo form.
            //         self.tokenize = True
            //     self._set_done()
            // 
            //     # Immediately post-process the transaction if it is a refund, as the post-processing
            //     # will not be triggered by a customer browsing the transaction from the portal.
            //     if self.operation == 'refund':
            //         self.env.ref('payment.cron_post_process_payment_tx')._trigger()
            // elif entity_status in const.PAYMENT_STATUS_MAPPING['error']:
            //     _logger.warning(
            //         "The transaction %s underwent an error. Reason: %s",
            //         self.reference, entity_data.get('error_description')
            //     )
            //     self._set_error(
            //         _("An error occurred during the processing of your payment. Please try again.")
            //     )
            // else:  # Classify unsupported payment status as the `error` tx state.
            //     _logger.warning(
            //         "Received data for transaction %s with invalid payment status: %s.",
            //         self.reference, entity_status
            //     )
            //     self._set_error(
            //         "Razorpay: " + _("Received data with invalid status: %s", entity_status)
            //     )
            --- ODOO METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment' to update the transaction based on the payment data."""
            // if self.provider_code != 'redsys':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the payment method.
            // card_brand = payment_data.get('Ds_Card_Brand')
            // payment_method = self.env['payment.method']._get_from_code(
            //     card_brand, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // status_code = payment_data['Ds_Response']
            // if status_code in const.PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif status_code in const.PAYMENT_STATUS_MAPPING['cancel']:
            //     self._set_canceled()
            // elif status_code in const.PAYMENT_STATUS_MAPPING['error']:
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (%s). Please try again.",
            //         payment_data.get('Ds_ErrorCode'),
            //     ))
            // else:
            //     _logger.warning("Received invalid payment status (%s).", status_code)
            //     self._set_error(_("Unknown status code: %s", status_code))
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'stripe':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the payment method.
            // payment_method = payment_data.get('payment_method')
            // if isinstance(payment_method, dict):  # capture/void/refund requests receive a string.
            //     payment_method_type = payment_method.get('type')
            //     if self.payment_method_id.code == payment_method_type == 'card':
            //         payment_method_type = payment_data['payment_method']['card']['brand']
            //     payment_method = self.env['payment.method']._get_from_code(
            //         payment_method_type, mapping=const.PAYMENT_METHODS_MAPPING
            //     )
            //     self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the provider reference and the payment state.
            // if self.operation == 'validation':
            //     self.provider_reference = payment_data['setup_intent']['id']
            //     status = payment_data['setup_intent']['status']
            // elif self.operation == 'refund':
            //     self.provider_reference = payment_data['refund']['id']
            //     status = payment_data['refund']['status']
            // else:  # 'online_direct', 'online_token', 'offline'
            //     self.provider_reference = payment_data['payment_intent']['id']
            //     status = payment_data['payment_intent']['status']
            // if not status:
            //     self._set_error(_("Received data with missing intent status."))
            // elif status in const.STATUS_MAPPING['draft']:
            //     pass
            // elif status in const.STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif status in const.STATUS_MAPPING['authorized']:
            //     self._set_authorized()
            // elif status in const.STATUS_MAPPING['done']:
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
            //         last_payment_error = payment_data.get('payment_intent', {}).get(
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
            //         "Received invalid payment status (%s) for transaction %s.",
            //         status, self.reference
            //     )
            //     self._set_error(_("Received data with invalid intent status: %s.", status))
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """ Override of `payment' to process the transaction based on Worldline data.
            // 
            // Note: self.ensure_one()
            // 
            // :param dict payment_data: The payment data sent by the provider.
            // :return: None
            // """
            // if self.provider_code != 'worldline':
            //     return super()._apply_updates(payment_data)
            // 
            // # In case of failed payment, paymentResult could be given as a separate key
            // payment_result = payment_data.get('paymentResult', payment_data)
            // payment_data = payment_result.get('payment', {})
            // 
            // # Update the provider reference.
            // self.provider_reference = payment_data.get('id', '').rsplit('_', 1)[0]
            // 
            // # Update the payment method.
            // payment_method_data = self._worldline_extract_payment_method_data(payment_data)
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
            //     self._set_error(_("Received data with missing payment state."))
            // elif status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     if status == 'AUTHORIZATION_REQUESTED' and self.operation in ('online_token', 'offline'):
            //         self._set_error(status)
            //     elif self.operation == 'validation' \
            //          and status in {'PENDING_CAPTURE', 'CAPTURE_REQUESTED'} \
            //          and has_token_data:
            //             self._set_done()
            //     else:
            //         self._set_pending()
            // elif status in const.PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // else:
            //     error_code = None
            //     if errors := payment_data.get('statusOutput', {}).get('errors'):
            //         error_code = errors[0].get('errorCode')
            //     if status in const.PAYMENT_STATUS_MAPPING['cancel']:
            //         self._set_canceled(_(
            //             "Transaction cancelled with error code %(error_code)s.",
            //             error_code=error_code,
            //         ))
            //     elif status in const.PAYMENT_STATUS_MAPPING['declined']:
            //         self._set_error(_(
            //             "Transaction declined with error code %(error_code)s.",
            //             error_code=error_code,
            //         ))
            //     else:  # Classify unsupported payment status as the `error` tx state.
            //         _logger.info(
            //             "Received data with invalid payment status (%(status)s) for transaction with "
            //             "reference %(ref)s.",
            //             {'status': status, 'ref': self.reference},
            //         )
            //         self._set_error(_(
            //             "Received invalid transaction status %(status)s with error code "
            //             "%(error_code)s.",
            //             status=status,
            //             error_code=error_code,
            //         ))
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _apply_updates(self, payment_data):
            // """Override of `payment` to update the transaction based on the payment data."""
            // if self.provider_code != 'xendit':
            //     return super()._apply_updates(payment_data)
            // 
            // # Update the provider reference.
            // self.provider_reference = payment_data.get('id')
            // 
            // # Update payment method.
            // payment_method_code = payment_data.get('payment_method', '')
            // payment_method = self.env['payment.method']._get_from_code(
            //     payment_method_code, mapping=const.PAYMENT_METHODS_MAPPING
            // )
            // self.payment_method_id = payment_method or self.payment_method_id
            // 
            // # Update the payment state.
            // payment_status = payment_data.get('status')
            // if payment_status in const.PAYMENT_STATUS_MAPPING['pending']:
            //     self._set_pending()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['done']:
            //     self._set_done()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['cancel']:
            //     self._set_canceled()
            // elif payment_status in const.PAYMENT_STATUS_MAPPING['error']:
            //     failure_reason = payment_data.get('failure_reason')
            //     self._set_error(_(
            //         "An error occurred during the processing of your payment (%s). Please try again.",
            //         failure_reason,
            //     ))
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

        protected async Task<PaymentTransaction> BuildActionFeedbackNotificationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _build_action_feedback_notification(self):
            // """Build a client notification to display the result of an action.
            // 
            // :return: The client notification.
            // :rtype: dict
            // """
            // if not (failed_txs := self.filtered(lambda tx: tx.state == 'error')):
            //     notification_type = 'success'
            //     msg = self.env._("Your payment operation has been successfully submitted.")
            // else:
            //     notification_type = 'danger'
            //     msg = self.env._(
            //         "Your payment operation could not be completed for following transactions:"
            //         " %(tx_refs)s", tx_refs=', '.join(failed_txs.mapped('reference'))
            //     )
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': notification_type,
            //         'message': msg,
            //         'next': {'type': 'ir.actions.act_window_close'},  # Close any open wizard.
            //     },
            // }
            */
            return default;
        }

        public async Task<PaymentTransaction> CaptureAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def action_capture(self):
            // """Open the partial capture wizard if it is supported by the related providers, otherwise
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
            //             'payment_backend_action': True,
            //         },
            //     }
            // else:
            //     captured_txs_sudo = self.env['payment.transaction'].sudo()
            //     for tx in self.filtered(lambda tx: tx.state == 'authorized'):
            //         # In sudo mode to read on provider fields.
            //         captured_txs_sudo |= tx.sudo().with_context(payment_backend_action=True)._capture()
            //     return captured_txs_sudo._build_action_feedback_notification()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentTransaction> CaptureInternalAsync(object amount_to_capture)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _capture(self, amount_to_capture=None):
            // """Capture the authorized amount.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param float amount_to_capture: The amount to capture.
            // :return: The capture transaction created to process the capture request.
            // :rtype: payment.transaction
            // """
            // self.ensure_one()
            // self._ensure_provider_is_not_disabled()
            // 
            // capture_tx = self._create_child_transaction(amount_to_capture or self.amount)
            // capture_tx._log_sent_message()
            // try:
            //     capture_tx._send_capture_request()
            // except ValidationError as e:
            //     capture_tx._set_error(str(e))
            // return capture_tx
            */
            return default;
        }

        protected async Task<PaymentTransaction> ChargeWithTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _charge_with_token(self):
            // """Pay the transaction with the given token.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: None
            // """
            // self.ensure_one()
            // self._ensure_provider_is_not_disabled()
            // self._log_sent_message()
            // try:
            //     self._send_payment_request()
            // except ValidationError as e:
            //     self._set_error(str(e))
            */
            return default;
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

        protected async Task<PaymentTransaction> ComputePrimaryPaymentMethodIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _compute_primary_payment_method_id(self):
            // for pm, txs in self.grouped('payment_method_id').items():
            //     txs.primary_payment_method_id = pm.primary_payment_method_id or pm
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
            //     prefix = self.sudo()._compute_reference_prefix(separator, **kwargs)
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
            //     prefix = self.sudo()._compute_reference_prefix(separator, **kwargs) or None
            // prefix = payment_utils.singularize_reference_prefix(prefix=prefix, max_length=35)
            // return super()._compute_reference(provider_code, prefix=prefix, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _compute_reference(self, provider_code, prefix=None, separator='-', **kwargs):
            // """Override of `payment` to satisfy Flutterwave requirements for references.
            // 
            // Flutterwave requirements for references are as follows:
            // - References must be unique at provider level for a given merchant account. This is
            //   satisfied by singularizing the prefix with the current datetime. If two transactions are
            //   created simultaneously, `_compute_reference` ensures the uniqueness of references by
            //   suffixing a sequence number.
            // 
            // :param str provider_code: The code of the provider handling the transaction
            // :param str prefix: The custom prefix used to compute the full reference
            // :param str separator: The custom separator used to separate the prefix from the suffix
            // :return: The unique reference for the transaction
            // :rtype: str
            // """
            // if provider_code == 'flutterwave':
            //     if not prefix:
            //         # If no prefix is provided, it could mean that a module has passed a kwarg intended
            //         # for the `_compute_reference_prefix` method, as it is only called if the prefix is
            //         # empty. We call it manually here because singularizing the prefix would generate a
            //         # default value if it was empty, hence preventing the method from ever being called
            //         # and the transaction from received a reference named after the related document.
            //         prefix = self.sudo()._compute_reference_prefix(separator, **kwargs) or None
            //     prefix = payment_utils.singularize_reference_prefix(prefix=prefix, separator=separator)
            // return super()._compute_reference(
            //     provider_code, prefix=prefix, separator=separator, **kwargs
            // )
            --- ODOO METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py) ---
            // def _compute_reference(self, provider_code, prefix=None, separator='-', **kwargs):
            // """ Override of `payment` to ensure that Paymob references are unique.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param str prefix: The custom prefix used to compute the full reference.
            // :param str separator: The custom separator used to separate the prefix from the suffix.
            // :return: The unique reference for the transaction.
            // :rtype: str
            // """
            // if provider_code == 'paymob':
            //     if not prefix:
            //         # If no prefix is provided, it could mean that a module has passed a kwarg intended
            //         # for the `_compute_reference_prefix` method, as it is only called if the prefix is
            //         # empty. We call it manually here because singularizing the prefix would generate a
            //         # default value if it was empty, hence preventing the method from ever being called
            //         # and the transaction from receiving a reference named after the related document.
            //         prefix = self.sudo()._compute_reference_prefix(separator, **kwargs) or None
            //     prefix = payment_utils.singularize_reference_prefix(prefix=prefix, separator=separator)
            // 
            // return super()._compute_reference(
            //     provider_code, prefix=prefix, separator=separator, **kwargs
            // )
            --- ODOO METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py) ---
            // def _compute_reference(self, provider_code, prefix=None, separator='-', **kwargs):
            // """Override of `payment` to ensure that Redsys' requirements for references are satisfied.
            // 
            // Redsys' requirements for transaction are as follows:
            // - References can only be made of alphanumeric characters.
            // - References must be minimum 9 characters and at most 12 characters long.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param str prefix: The custom prefix used to compute the full reference.
            // :param str separator: The custom separator used to separate the prefix from the suffix.
            // :return: The unique reference for the transaction.
            // :rtype: str
            // """
            // if provider_code != 'redsys':
            //     return super()._compute_reference(
            //         provider_code, prefix=prefix, separator=separator, **kwargs
            //     )
            // 
            // # Generate the prefix as the timestamp of the current time (10 chars).
            // # This leaves just enough room for the separator and the suffix in case of collisions.
            // prefix = str(int(fields.Datetime.now().timestamp()))[-10:]
            // 
            // return super()._compute_reference(provider_code, prefix=prefix, separator='S', **kwargs)
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

        protected async Task<PaymentTransaction> ComputeReferencePrefixInternalAsync(object separator)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py) ---
            // def _compute_reference_prefix(self, separator, **values):
            // """ Compute the reference prefix from the transaction values.
            // 
            // If the `values` parameter has an entry with 'invoice_ids' as key and a list of (4, id, O) or
            // (6, 0, ids) X2M command as value, the prefix is computed based on the invoice name(s).
            // Otherwise, an empty string is returned.
            // 
            // Note: This method should be called in sudo mode to give access to documents (INV, SO, ...).
            // 
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
            // return super()._compute_reference_prefix(separator, **values)
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _compute_reference_prefix(self, separator, **values):
            // """ Compute the reference prefix from the transaction values.
            // 
            // Note: This method should be called in sudo mode to give access to the documents (invoices,
            // sales orders) referenced in the transaction values.
            // 
            // :param str separator: The custom separator used to separate parts of the computed
            //                       reference prefix.
            // :param dict values: The transaction values used to compute the reference prefix.
            // :return: The computed reference prefix.
            // :rtype: str
            // """
            // return ''
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: payment_transaction.py) ---
            // def _compute_reference_prefix(self, separator, **values):
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
            // return super()._compute_reference_prefix(separator, **values)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py) ---
            // def _compute_reference_prefix(self, separator, **values):
            // """ Override of payment to compute the reference prefix based on Sales-specific values.
            // 
            // If the `values` parameter has an entry with 'sale_order_ids' as key and a list of (4, id, O)
            // or (6, 0, ids) X2M command as value, the prefix is computed based on the sales order name(s)
            // Otherwise, the computation is delegated to the super method.
            // 
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
            // return super()._compute_reference_prefix(separator, **values)
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

        public override async Task<PaymentTransaction> CreateAsync(PaymentTransaction entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def create(self, vals_list):
            // for values in vals_list:
            //     provider = self.env['payment.provider'].browse(values['provider_id'])
            // 
            //     if not values.get('reference'):
            //         values['reference'] = self._compute_reference(provider.code, **values)
            // 
            //     values['is_live'] = provider.state == 'enabled'
            // 
            //     # Duplicate partner values.
            //     partner = self.env['res.partner'].browse(values['partner_id'])
            //     partner_emails = email_normalize_all(partner.email)
            //     values.update({
            //         # Use the parent partner as fallback if the invoicing address has no name.
            //         'partner_name': partner.name or partner.parent_id.name,
            //         'partner_lang': partner.lang,
            //         'partner_email': partner_emails[0] if partner_emails else None,
            //         'partner_address': payment_utils.format_partner_address(
            //             partner.street, partner.street2
            //         ),
            //         'partner_zip': partner.zip,
            //         'partner_city': partner.city,
            //         'partner_state_id': partner.state_id.id,
            //         'partner_country_id': partner.country_id.id,
            //         'partner_phone': partner.phone,
            //     })
            // 
            //     # Include provider-specific create values
            //     values.update(self._get_specific_create_values(provider.code, values))
            // 
            // txs = super().create(vals_list)
            // 
            // # Monetary fields are rounded with the currency at creation time by the ORM. Sometimes, this
            // # can lead to inconsistent string representation of the amounts sent to the providers.
            // # E.g., tx.create(amount=1111.11) -> tx.amount == 1111.1100000000001
            // # To ensure a proper string representation, we invalidate this request's cache values of the
            // # `amount` field for the created transactions. This forces the ORM to read the values from
            // # the DB where there were stored using `float_repr`, which produces a result consistent with
            // # the format expected by providers.
            // # E.g., tx.create(amount=1111.11) ; tx.invalidate_recordset() -> tx.amount == 1111.11
            // txs.invalidate_recordset(['amount'])
            // 
            // return txs
            --- ODOO METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py) ---
            // def create(self, vals_list):
            // """Override of `payment` to set the Redsys-specific `provider_reference`."""
            // transactions = super().create(vals_list)
            // for tx in transactions.filtered(lambda t: t.provider_code == 'redsys'):
            //     tx.provider_reference = tx.reference
            // return transactions
            */
            return await base.CreateAsync(entity, fields);
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
            // reference = f'{self.reference} - {self.provider_reference or ""}'
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
            //             "An error occurred while post-processing transaction %s:\n%s",
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
            // payment_data = {'reference': self.reference, 'simulated_state': 'cancel'}
            // self._process('demo', payment_data)
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
            // payment_data = {'reference': self.reference, 'simulated_state': 'done'}
            // self._process('demo', payment_data)
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
            // payment_data = {'reference': self.reference, 'simulated_state': 'error'}
            // self._process('demo', payment_data)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentTransaction> DpoCreateTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py) ---
            // def _dpo_create_token(self):
            // """ Create a transaction token and return the response data.
            // 
            // The token is used to redirect the customer to the payment page.
            // 
            // :return: The transaction token data.
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // return_url = urls.urljoin(self.provider_id.get_base_url(), DPOController._return_url)
            // first_name, last_name = payment_utils.split_partner_name(self.partner_name)
            // create_date = self.create_date.strftime('%Y/%m/%d %H:%M')
            // payload = (
            //     f'<?xml version="1.0" encoding="utf-8"?>'
            //     f'<API3G>'
            //         f'<CompanyToken>{self.provider_id.dpo_company_token}</CompanyToken>'
            //         f'<Request>createToken</Request>'
            //         f'<Transaction>'
            //             f'<PaymentAmount>{self.amount}</PaymentAmount>'
            //             f'<PaymentCurrency>{self.currency_id.name}</PaymentCurrency>'
            //             f'<CompanyRef>{self.reference}</CompanyRef>'
            //             f'<RedirectURL>{return_url}</RedirectURL>'
            //             f'<BackURL>{return_url}</BackURL>'
            //             f'<customerEmail>{self.partner_email}</customerEmail>'
            //             f'<customerFirstName>{first_name}</customerFirstName>'
            //             f'<customerLastName>{last_name}</customerLastName>'
            //             f'<customerCity>{self.partner_city or ""}</customerCity>'
            //             f'<customerCountry>{self.partner_country_id.code or ""}</customerCountry>'
            //             f'<customerZip>{self.partner_zip or ""}</customerZip>'
            //         f'</Transaction>'
            //         f'<Services>'
            //             f'<Service>'
            //                 f'<ServiceType>{self.provider_id.dpo_service_ref}</ServiceType>'
            //                 f'<ServiceDescription>{self.reference}</ServiceDescription>'
            //                 f'<ServiceDate>{create_date}</ServiceDate>'
            //             f'</Service>'
            //         f'</Services>'
            //     f'</API3G>'
            // )
            // 
            // try:
            //     transaction_data = self._send_api_request('POST', '', data=payload)
            // except ValidationError as e:
            //     self._set_error(str(e))
            //     return None
            // return transaction_data.get('TransToken')
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

        protected async Task<PaymentTransaction> ExtractAmountDataInternalAsync(object payment_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Extract the amount, currency and rounding precision from the payment data.
            // 
            // This method must be overridden by providers to parse the amount data from the payment data.
            // If the provider returns `None`, the amount validation is skipped.
            // 
            // :param dict payment_data: The payment data sent by the provider.
            // :return: The amount data, in the {amount: float, currency_code: str, precision_digits: int}
            //          format.
            // :rtype: dict|None
            // """
            // return {}
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'adyen':
            //     return super()._extract_amount_data(payment_data)
            // 
            // # Redirection payments and 3DS challenges don't have the amount or currency in their
            // # payment_data, but processing them results in a pending transaction anyway, neither
            // # does payment refusal response which will result in an error transaction.
            // if (
            //     payment_data.get('action', {}).get('type') in ['redirect', 'threeDS2']
            //     or payment_data.get('resultCode') in const.RESULT_CODES_MAPPING['refused']
            // ):
            //     return None  # Skip the validation
            // 
            // amount_data = payment_data.get('amount', {})
            // amount = payment_utils.to_major_currency_units(
            //     amount_data.get('value', 0),
            //     self.currency_id,
            //     arbitrary_decimal_number=const.CURRENCY_DECIMALS.get(self.currency_id.name),
            // )
            // currency_code = amount_data.get('currency')
            // return {
            //     'amount': amount,
            //     'currency_code': currency_code,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'aps':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount = payment_utils.to_major_currency_units(
            //     float(payment_data.get('amount', 0)), self.currency_id
            // )
            // return {
            //     'amount': amount,
            //     'currency_code': payment_data.get('currency'),
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'asiapay':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount = payment_data.get('Amt')
            // # AsiaPay supports only one currency per account.
            // currency = self.provider_id.available_currency_ids  # The currency has not been removed from the provider.
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency.name,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'authorize':
            //     return super()._extract_amount_data(payment_data)
            // 
            // tx_details = AuthorizeAPI(self.provider_id).get_transaction_details(
            //     payment_data.get('response', {}).get('x_trans_id')
            // )
            // if 'err_code' in tx_details:  # Transaction details are missing when an API error occurs.
            //     return None  # Skip the validation
            // 
            // amount = tx_details.get('transaction', {}).get('authAmount')
            // # Authorize supports only one currency per account.
            // currency = self.provider_id.available_currency_ids  # The currency has not been removed from the provider.
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency.name,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'buckaroo':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount = payment_data.get('brq_amount')
            // currency_code = payment_data.get('brq_currency')
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency_code,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_custom, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to skip the amount validation for custom flows."""
            // if self.provider_code != 'custom':
            //     return super()._extract_amount_data(payment_data)
            // return None
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to skip the amount validation for demo flows."""
            // if self.provider_code != 'demo':
            //     return super()._extract_amount_data(payment_data)
            // return None
            --- ODOO METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'dpo':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount = payment_data.get('TransactionAmount')
            // currency_code = payment_data.get('TransactionCurrency')
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency_code,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'flutterwave':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount = payment_data.get('amount')
            // currency_code = payment_data.get('currency')
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency_code,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'iyzico':
            //     return super()._extract_amount_data(payment_data)
            // 
            // return {
            //     'amount': payment_data.get('price'),
            //     'currency_code': payment_data.get('currency'),
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of payment to extract the amount and currency from the payment data."""
            // if self.provider_code != 'mercado_pago':
            //     return super()._extract_amount_data(payment_data)
            // 
            // if self.operation in ('online_redirect', 'online_direct'):
            //     amount = payment_data.get('additional_info', {}).get('items', [{}])[0].get('unit_price')
            // else:  # 'online_token', 'offline'
            //     amount = payment_data.get('transaction_amount')
            // currency_code = payment_data.get('currency_id')
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency_code,
            //     'precision_digits': const.CURRENCY_DECIMALS.get(currency_code),
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'mollie':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount_data = payment_data.get('amount', {})
            // amount = amount_data.get('value')
            // currency_code = amount_data.get('currency')
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency_code,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'nuvei':
            //     return super()._extract_amount_data(payment_data)
            // 
            // # When a user declines to pay and leaves the payment page, no information
            // # is sent back to odoo via the endpoint. As such there is no currency or
            // # amount set so we return early. This only occurs in the leaving flow so
            // # no issue should arise leaving early.
            // if not payment_data:
            //     return
            // 
            // is_mandatory_integer_pm = self.payment_method_code in const.INTEGER_METHODS
            // rounding = 0 if is_mandatory_integer_pm else self.currency_id.decimal_places
            // 
            // amount = payment_data.get('totalAmount')
            // currency_code = payment_data.get('currency')
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency_code,
            //     'precision_digits': rounding,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of payment to extract the amount and currency from the payment data."""
            // if self.provider_code != 'paymob':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount_cents = float(payment_data.get('amount_cents'))
            // amount = payment_utils.to_major_currency_units(amount_cents, self.currency_id)
            // currency_code = payment_data.get('currency')
            // return {
            //     'amount': amount,
            //     'currency_code': currency_code,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of payment to extract the amount and currency from the payment data."""
            // if self.provider_code != 'paypal':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount_data = payment_data.get('amount', {})
            // amount = amount_data.get('value')
            // currency_code = amount_data.get('currency_code')
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency_code,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of payment to extract the amount and currency from the payment data."""
            // if self.provider_code != 'razorpay':
            //     return super()._extract_amount_data(payment_data)
            // 
            // # Amount and currency are not sent in the payment data when redirecting to the return route.
            // if 'amount' not in payment_data or 'currency' not in payment_data:
            //     return
            // 
            // amount = payment_utils.to_major_currency_units(
            //     payment_data['amount'], self.currency_id
            // )
            // return {
            //     'amount': amount,
            //     'currency_code': payment_data['currency'],
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of `payment` to extract the amount and currency from the payment data."""
            // if self.provider_code != 'redsys':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount = payment_utils.to_major_currency_units(
            //     float(payment_data.get('Ds_Amount', 0)), self.currency_id
            // )
            // currency = self.env['res.currency'].search([
            //     ('iso_numeric', '=', payment_data.get('Ds_Currency'))
            // ], limit=1).name
            // return {
            //     'amount': amount,
            //     'currency_code': currency,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of payment to extract the amount and currency from the payment data."""
            // if self.provider_code != 'stripe':
            //     return super()._extract_amount_data(payment_data)
            // 
            // if self.operation == 'refund':
            //     payment_data = payment_data['refund']
            // else:  # 'online_direct', 'online_token', 'offline'
            //     payment_data = payment_data['payment_intent']
            // amount = payment_utils.to_major_currency_units(
            //     payment_data.get('amount', 0),
            //     self.currency_id,
            //     arbitrary_decimal_number=const.CURRENCY_DECIMALS.get(self.currency_id.name),
            // )
            // currency_code = payment_data.get('currency', '').upper()
            // return {
            //     'amount': amount,
            //     'currency_code': currency_code,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of payment to extract the amount and currency from the payment data."""
            // if self.provider_code != 'worldline':
            //     return super()._extract_amount_data(payment_data)
            // 
            // # In case of failed payment, paymentResult could be given as a separate key
            // payment_result = payment_data.get('paymentResult', payment_data)
            // amount_of_money = payment_result.get('payment', {}).get('paymentOutput', {}).get(
            //     'amountOfMoney', {}
            // )
            // amount = payment_utils.to_major_currency_units(
            //     amount_of_money.get('amount', 0), self.currency_id
            // )
            // currency_code = amount_of_money.get('currencyCode')
            // return {
            //     'amount': amount,
            //     'currency_code': currency_code,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _extract_amount_data(self, payment_data):
            // """Override of payment to extract the amount and currency from the payment data."""
            // if self.provider_code != 'xendit':
            //     return super()._extract_amount_data(payment_data)
            // 
            // amount = payment_data.get('amount') or payment_data.get('authorized_amount')
            // currency_code = payment_data.get('currency')
            // return {
            //     'amount': float(amount),
            //     'currency_code': currency_code,
            //     'precision_digits': const.CURRENCY_DECIMALS.get(currency_code),
            // }
            */
            return default;
        }

        protected async Task<PaymentTransaction> ExtractReferenceInternalAsync(object provider_code, object payment_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Extract the transaction reference from the payment data.
            // 
            // This method must be overridden by providers to extract the reference from the payment data.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param dict payment_data: The payment data sent by the provider.
            // :return: The transaction reference.
            // :rtype: str
            // """
            // return payment_data.get('reference')
            --- ODOO METHOD SOURCE (MODULE: payment_aps, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the APS data."""
            // if provider_code != 'aps':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('merchant_reference')
            --- ODOO METHOD SOURCE (MODULE: payment_asiapay, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'asiapay':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('Ref')
            --- ODOO METHOD SOURCE (MODULE: payment_buckaroo, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'buckaroo':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('brq_invoicenumber')
            --- ODOO METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'dpo':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('CompanyRef')
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'flutterwave':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('tx_ref') or payment_data.get('txRef')
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'mercado_pago':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('external_reference')
            --- ODOO METHOD SOURCE (MODULE: payment_mollie, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'mollie':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('ref')
            --- ODOO METHOD SOURCE (MODULE: payment_nuvei, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'nuvei':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('invoice_id')
            --- ODOO METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'paymob':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('merchant_order_id')
            --- ODOO METHOD SOURCE (MODULE: payment_paypal, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'paypal':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('reference_id')
            --- ODOO METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'redsys':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('Ds_Order')
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'worldline':
            //     return super()._extract_reference(provider_code, payment_data)
            // 
            // # In case of failed payment, paymentResult could be given as a separate key
            // payment_result = payment_data.get('paymentResult', payment_data)
            // payment_output = payment_result.get('payment', {}).get('paymentOutput', {})
            // return payment_output.get('references', {}).get('merchantReference', '')
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _extract_reference(self, provider_code, payment_data):
            // """Override of `payment` to extract the reference from the payment data."""
            // if provider_code != 'xendit':
            //     return super()._extract_reference(provider_code, payment_data)
            // return payment_data.get('external_id')
            */
            return default;
        }

        protected async Task<PaymentTransaction> ExtractTokenValuesInternalAsync(object payment_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Extract the create values of a token from the payment data.
            // 
            // Providers can override this to supply their own token data based on the payment data.
            // 
            // Note: self.ensure_one() from :meth: `_tokenize`
            // 
            // :param dict payment_data: Data sent by the provider.
            // :return: Data to create a payment token.
            // :rtype: dict
            // """
            // return dict()
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Override of `payment` to extract the token values from the payment data."""
            // if self.provider_code != 'adyen':
            //     return super()._extract_token_values(payment_data)
            // 
            // additional_data = payment_data['additionalData']
            // 
            // if 'recurring.recurringDetailReference' not in additional_data:
            //     return {}
            // 
            // return {
            //     'provider_ref': additional_data['recurring.recurringDetailReference'],
            //     'payment_details': additional_data.get('cardSummary'),
            //     'adyen_shopper_reference': additional_data['recurring.shopperReference'],
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Override of `payment` to extract the token values from the payment data."""
            // if self.provider_code != 'authorize':
            //     return super()._extract_token_values(payment_data)
            // 
            // if self.token_id:
            //     return {}
            // 
            // authorize_API = AuthorizeAPI(self.provider_id)
            // cust_profile = authorize_API.create_customer_profile(
            //     self.partner_id, self.provider_reference
            // )
            // _logger.info(
            //     "create_customer_profile request response for transaction %s:\n%s",
            //     self.reference, pprint.pformat(cust_profile)
            // )
            // if not cust_profile or 'payment_profile_id' not in cust_profile:  # Failed to fetch data.
            //     return {}
            // 
            // return {
            //     'payment_details': cust_profile.get('payment_details'),
            //     'provider_ref': cust_profile['payment_profile_id'],
            //     'authorize_profile': cust_profile.get('profile_id'),
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Override of `payment` to extract the token values from the payment data."""
            // if self.provider_code != 'demo':
            //     return super()._extract_token_values(payment_data)
            // 
            // # Do not tokenize the transaction twice as `_update_from_payment_data` already does.
            // if self.state in ('done', 'authorized'):
            //     return {}
            // 
            // state = payment_data['simulated_state']
            // return {
            //     'payment_details': payment_data['payment_details'],
            //     'provider_ref': 'fake provider reference',
            //     'demo_simulated_state': state,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Override of `payment` to extract the token values from the payment data."""
            // if self.provider_code != 'flutterwave':
            //     return super()._extract_token_values(payment_data)
            // 
            // if 'token' not in payment_data.get('card', {}):
            //     return {}
            // 
            // return {
            //     'payment_details': payment_data['card']['last_4digits'],
            //     'provider_ref': payment_data['card']['token'],
            //     'flutterwave_customer_email': payment_data['customer']['email'],
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Override of `payment` to return token data based on payment data."""
            // if self.provider_code != 'mercado_pago':
            //     return super()._extract_token_values(payment_data)
            // 
            // # Fetch the customer id or create a new one.
            // email_data = {'email': payment_data['payer']['email']}
            // response_content = self._send_api_request('GET', '/v1/customers/search', params=email_data)
            // if customers_data := response_content['results']:
            //     customer_id = customers_data[0]['id']
            // else:  # No customer found.
            //     # Create a new customer.
            //     response_content = self._send_api_request('POST', '/v1/customers', json=email_data)
            //     customer_id = response_content['id']
            // 
            // # Fetch the card data.
            // payload = {
            //     'token': payment_data['token'],
            //     'issuer_id': int(payment_data['issuer_id']),
            //     'payment_method_id': payment_data['payment_method_id']
            // }
            // response_content = self._send_api_request(
            //     'POST', f'/v1/customers/{customer_id}/cards', json=payload
            // )
            // card_id = response_content['id']
            // last_four_digits = response_content['last_four_digits']
            // 
            // return {
            //     'mercado_pago_customer_id': customer_id,
            //     'payment_details': last_four_digits,
            //     'provider_ref': card_id,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Override of `payment` to return token data based on Razorpay data.
            // 
            // Note: self.ensure_one() from :meth: `_tokenize`
            // 
            // :param dict payment_data: The payment data sent by the provider.
            // :return: Data to create a token.
            // :rtype: dict
            // """
            // if self.provider_code != 'razorpay':
            //     return super()._extract_token_values(payment_data)
            // 
            // has_token_data = payment_data.get('token_id')
            // if self.token_id or not self.provider_id.allow_tokenization or not has_token_data:
            //     return {}
            // 
            // pm_code = (self.payment_method_id.primary_payment_method_id or self.payment_method_id).code
            // if pm_code == 'card':
            //     details = payment_data.get('card', {}).get('last4')
            // elif pm_code == 'upi':
            //     temp_vpa = payment_data.get('vpa')
            //     details = temp_vpa[temp_vpa.find('@') - 1:]
            // else:
            //     details = pm_code
            // return {
            //     'payment_details': details,
            //     # Razorpay requires both the customer ID and the token ID which are extracted from here.
            //     'provider_ref': f'{payment_data["customer_id"]},{payment_data["token_id"]}',
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Override of `payment` to return token data based on Stripe data.
            // 
            // Note: self.ensure_one() from :meth: `_tokenize`
            // 
            // :param dict payment_data: The payment data sent by the provider.
            // :return: Data to create a token.
            // :rtype: dict
            // """
            // if self.provider_code != 'stripe':
            //     return super()._extract_token_values(payment_data)
            // 
            // payment_method = payment_data.get('payment_method')
            // if not payment_method:
            //     _logger.warning("requested tokenization from payment data with missing payment method")
            //     return {}
            // 
            // mandate = None
            // # Extract the Stripe objects from the payment data.
            // if self.operation == 'online_direct':
            //     customer_id = payment_data['payment_intent']['customer']
            //     charges_data = payment_data['payment_intent']['charges']
            //     payment_method_details = charges_data['data'][0].get('payment_method_details')
            //     if payment_method_details:
            //         mandate = payment_method_details[payment_method_details['type']].get("mandate")
            // else:  # 'validation'
            //     customer_id = payment_data['setup_intent']['customer']
            // # Another payment method (e.g., SEPA) might have been generated.
            // if not payment_method[payment_method['type']]:
            //     try:
            //         payment_methods = self._send_api_request(
            //             'GET', f'customers/{customer_id}/payment_methods'
            //         )
            //     except ValidationError as e:
            //         self._set_error(str(e))
            //         return {}
            //     payment_method = payment_methods['data'][0]
            // 
            // return {
            //     'payment_details': payment_method[payment_method['type']].get('last4'),
            //     'provider_ref': customer_id,
            //     'stripe_payment_method': payment_method['id'],
            //     'stripe_mandate': mandate,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Override of `payment` to return token data based on Worldline data.
            // 
            // Note: self.ensure_one() from :meth: `_tokenize`
            // 
            // :param dict payment_data: The payment data sent by the provider.
            // :return: Data to create a token.
            // :rtype: dict
            // """
            // if self.provider_code != 'worldline':
            //     return super()._extract_token_values(payment_data)
            // 
            // payment_data = payment_data.get('payment', {})
            // payment_method_data = self._worldline_extract_payment_method_data(payment_data)
            // if 'token' not in payment_method_data:
            //     return {}
            // 
            // # Padded with *
            // payment_details = payment_method_data.get('card', {}).get('cardNumber', '')[-4:]
            // return {
            //     'payment_details': payment_details,
            //     'provider_ref': payment_method_data['token'],
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _extract_token_values(self, payment_data):
            // """Override of `payment` to return token data based on Xendit data.
            // 
            // Note: self.ensure_one() from :meth: `_tokenize`
            // 
            // :param dict payment_data: The payment data sent by the provider.
            // :return: Data to create a token.
            // :rtype: dict
            // """
            // if self.provider_code != 'xendit':
            //     return super()._extract_token_values(payment_data)
            // 
            // card_info = payment_data['masked_card_number'][-4:]  # Xendit pads details with X's.
            // 
            // return {
            //     'payment_details': card_info,
            //     'provider_ref': payment_data['credit_card_token_id'],
            // }
            */
            return default;
        }

        protected async Task<PaymentTransaction> FlutterwaveIsAuthorizationPendingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _flutterwave_is_authorization_pending(self):
            // """ Filter Flutterwave token transactions that are awaiting external authorization.
            // 
            // :return: Pending transactions awaiting authorization.
            // :rtype: recordset of `payment.transaction`
            // """
            // return self.filtered_domain([
            //     ('provider_code', '=', 'flutterwave'),
            //     ('operation', '=', 'online_token'),
            //     ('state', '=', 'pending'),
            //     ('provider_reference', 'ilike', 'https'),
            // ])
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
            // 
            // # Render the HTML form for the redirect flow if available.
            // if self.operation in ('online_redirect', 'validation'):
            //     redirect_form_view = self.provider_id._get_redirect_form_view(
            //         is_validation=self.operation == 'validation'
            //     )
            //     if redirect_form_view:  # Some providers don't need a redirect form.
            //         rendering_values = self._get_specific_rendering_values(processing_values)
            //         redirect_form_html = self.env['ir.qweb']._render(
            //             redirect_form_view.id, rendering_values
            //         )
            //         processing_values.update(redirect_form_html=redirect_form_html)
            // 
            // # Include the state and state message only after they might have been updated by calling the
            // # `_get_specific_rendering/processing_values` methods (due to possible external requests).
            // processing_values.update({
            //     'state': self.state,
            //     'state_message': self.state_message,
            // })
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
            // """Return the message to log to state that the transaction has been processed.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The message to log.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // if self.operation == 'validation':
            //     return None  # Don't log anything as the token is not yet created.
            // 
            // # Choose the message based on the transaction's state.
            // msg_values = {
            //     'tx_label': 'refund' if self.operation == 'refund' else 'transaction',
            //     'ref': self._get_html_link(),
            //     'formatted_amount': self.currency_id.format(self.amount),
            // }
            // match self.state:
            //     case 'pending':
            //         received_message = _(
            //             "The %(tx_label)s %(ref)s of %(formatted_amount)s is pending.",
            //             **msg_values,
            //         )
            //     case 'authorized':
            //         received_message = _(
            //             "The %(tx_label)s %(ref)s of %(formatted_amount)s has been authorized.",
            //             **msg_values,
            //         )
            //     case 'done':
            //         received_message = _(
            //             "The %(tx_label)s %(ref)s of %(formatted_amount)s has been confirmed.",
            //             **msg_values,
            //         )
            //     case 'cancel':
            //         received_message = _(
            //             "The %(tx_label)s %(ref)s of %(formatted_amount)s has been canceled.",
            //             **msg_values,
            //         )
            //     case 'error':
            //         received_message = _(
            //             "The %(tx_label)s %(ref)s of %(formatted_amount)s encountered an error.",
            //             **msg_values,
            //         )
            //     case _:
            //         received_message = None
            // 
            // # Append any state_message for cancel or error.
            // if self.state in {'cancel', 'error'} and self.state_message:
            //     received_message += Markup("<br/>") + self.state_message
            // 
            // return received_message
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetRoundedAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _get_rounded_amount(self):
            // decimal_places = const.CURRENCY_DECIMALS.get(
            //     self.currency_id.name, self.currency_id.decimal_places
            // )
            // return float_round(self.amount, decimal_places, rounding_method='DOWN')
            */
            return default;
        }

        protected async Task<PaymentTransaction> GetSentMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _get_sent_message(self):
            // """Return the message to log to state that the transaction has been created.
            // 
            // Note: `self.ensure_one()`
            // 
            // :return: The message to log.
            // :rtype: str
            // """
            // self.ensure_one()
            // 
            // # Choose the message based on the payment flow.
            // if self.operation in {'online_redirect', 'online_direct', 'online_token', 'offline'}:
            //     sent_message = _(
            //         "The transaction %(ref)s of %(formatted_amount)s has been initiated.",
            //         ref=self._get_html_link(), formatted_amount=self.currency_id.format(self.amount)
            //     )
            // elif self.operation == 'refund':
            //     sent_message = _(
            //         "The refund %(ref)s of %(formatted_amount)s has been initiated.",
            //         ref=self._get_html_link(), formatted_amount=self.currency_id.format(-self.amount)
            //     )
            // else:  # 'validation'
            //     sent_message = None  # No message to log for initiating validation transactions.
            // return sent_message
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
            // if self.provider_code != 'adyen':
            //     return super()._get_specific_processing_values(processing_values)
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
            // if self.provider_code != 'authorize':
            //     return super()._get_specific_processing_values(processing_values)
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
            // if not self._flutterwave_is_authorization_pending():
            //     return super()._get_specific_processing_values(processing_values)
            // 
            // return {'redirect_form_html': self.env['ir.qweb']._render(
            //     self.provider_id.redirect_form_view_id.id,
            //     {'auth_url': self.provider_reference},
            // )}
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
            // if self.provider_code != 'paypal':
            //     return super()._get_specific_processing_values(processing_values)
            // 
            // payload = self._paypal_prepare_order_payload()
            // 
            // idempotency_key = payment_utils.generate_idempotency_key(
            //     self, scope='payment_request_order'
            // )
            // try:
            //     order_data = self._send_api_request(
            //         'POST', '/v2/checkout/orders', json=payload, idempotency_key=idempotency_key
            //     )
            // except ValidationError as e:
            //     self._set_error(str(e))
            //     return {}
            // 
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
            // if self.provider_code != 'razorpay':
            //     return super()._get_specific_processing_values(processing_values)
            // 
            // if self.operation in ('online_token', 'offline'):
            //     return {}
            // 
            // customer_id = self._razorpay_create_customer().get('id')
            // order_id = self._razorpay_create_order(customer_id).get('id')
            // 
            // return {
            //     'razorpay_key_id': self.provider_id.razorpay_key_id,
            //     'razorpay_public_token': self.provider_id.razorpay_public_token,
            //     'razorpay_customer_id': customer_id,
            //     'is_tokenize_request': self.tokenize,
            //     'razorpay_order_id': order_id,
            //     'callback_url': url_join(
            //         self.provider_id.get_base_url(),
            //         f'{RazorpayController._return_url}?{url_encode({"reference": self.reference})}'
            //     ),
            //     'redirect': self.payment_method_id.code in const.REDIRECT_PAYMENT_METHOD_CODES,
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
            // if self.provider_code != 'stripe' or self.operation == 'online_token':
            //     return super()._get_specific_processing_values(processing_values)
            // 
            // intent = self._stripe_create_intent()
            // base_url = self.provider_id.get_base_url()
            // return {
            //     'client_secret': intent['client_secret'] if intent else '',
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
            //     return {'force_flow': 'redirect'}
            // return super()._get_specific_processing_values(processing_values)
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
            // if self.provider_code != 'xendit':
            //     return super()._get_specific_processing_values(processing_values)
            // 
            // return {
            //     'rounded_amount': self._get_rounded_amount(),
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
            // if self.provider_code != 'aps':
            //     return super()._get_specific_rendering_values(processing_values)
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
            //     'return_url': urls.urljoin(base_url, APSController._return_url),
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
            // if self.provider_code != 'asiapay':
            //     return super()._get_specific_rendering_values(processing_values)
            // 
            // base_url = self.provider_id.get_base_url()
            // # The lang is taken from the context rather than from the partner because it is not required
            // # to be logged in to make a payment, and because the lang is not always set on the partner.
            // lang = self.env.context.get('lang') or 'en_US'
            // rendering_values = {
            //     'merchant_id': self.provider_id.asiapay_merchant_id,
            //     'amount': self.amount,
            //     'reference': self.reference,
            //     'currency_code': const.CURRENCY_MAPPING[self.provider_id.available_currency_ids[0].name],
            //     'mps_mode': 'SCP',
            //     'return_url': urls.urljoin(base_url, AsiaPayController._return_url),
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
            // if self.provider_code != 'buckaroo':
            //     return super()._get_specific_rendering_values(processing_values)
            // 
            // return_url = urls.urljoin(self.provider_id.get_base_url(), BuckarooController._return_url)
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
            // if self.provider_code != 'custom':
            //     return super()._get_specific_rendering_values(processing_values)
            // 
            // return {
            //     'api_url': CustomController._process_url,
            //     'reference': self.reference,
            // }
            --- ODOO METHOD SOURCE (MODULE: payment_dpo, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of `payment` to return DPO-specific processing values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`.
            // 
            // :param dict processing_values: The generic processing values of the transaction.
            // :return: The dict of provider-specific processing values.
            // :rtype: dict
            // """
            // if self.provider_code != 'dpo':
            //     return super()._get_specific_rendering_values(processing_values)
            // 
            // transaction_token = self._dpo_create_token()
            // api_url = f'https://secure.3gdirectpay.com/payv2.php?ID={transaction_token}'
            // 
            // return {'api_url': api_url}
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
            //     'redirect_url': urls.urljoin(base_url, FlutterwaveController._return_url),
            //     'customer': {
            //         'email': self.partner_email,
            //         'name': self.partner_name,
            //         'phonenumber': self.partner_phone,
            //     },
            //     'customizations': {
            //         'title': self.company_id.name,
            //         'logo': urls.urljoin(base_url, f'web/image/res.company/{self.company_id.id}/logo'),
            //     },
            //     'payment_options': const.PAYMENT_METHODS_MAPPING.get(
            //         self.payment_method_code, self.payment_method_code
            //     ),
            // }
            // try:
            //     payment_link_data = self._send_api_request('POST', 'payments', json=payload)
            // except ValidationError as error:
            //     self._set_error(str(error))
            //     return {}
            // 
            // # Extract the payment link URL and embed it in the redirect form.
            // return {'api_url': payment_link_data['link']}
            --- ODOO METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, *args):
            // """Override of `payment` to return Iyzico specific rendering values.
            // 
            //  Note: `self.ensure_one()` from :meth:`_get_processing_values`
            // 
            // :return: The provider-specific processing values.
            // :rtype: dict
            // """
            // if self.provider_code != 'iyzico':
            //     return super()._get_specific_rendering_values(*args)
            // 
            // # Initiate the payment and retrieve the payment link data.
            // payload = self._iyzico_prepare_cf_initialize_payload()
            // try:
            //     payment_link_data = self._send_api_request(
            //         'POST',
            //         'payment/iyzipos/checkoutform/initialize/auth/ecom',
            //         json=payload,
            //     )
            // except ValidationError as error:
            //     self._set_error(str(error))
            //     return {}
            // 
            // # Extract the payment link URL and params and embed them in the redirect form.
            // api_url = payment_link_data['paymentPageUrl']
            // parsed_url = urls.url_parse(api_url)
            // url_params = urls.url_decode(parsed_url.query)
            // 
            // return {
            //     'api_url': api_url,
            //     'url_params': url_params,  # Encore the params as inputs to preserve them.
            // }
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
            // if self.provider_code != 'mercado_pago':
            //     return super()._get_specific_rendering_values(processing_values)
            // 
            // # Initiate the payment and retrieve the payment link data.
            // payload = self._mercado_pago_prepare_preference_request_payload()
            // try:
            //     response_content = self._send_api_request('POST', '/checkout/preferences', json=payload)
            // except ValidationError as error:
            //     self._set_error(str(error))
            //     return {}
            // 
            // api_url = response_content[
            //     'init_point' if self.provider_id.state == 'enabled' else 'sandbox_init_point'
            // ]
            // 
            // # Extract the payment link URL and params and embed them in the redirect form.
            // parsed_url = url_parse(api_url)
            // url_params = url_decode(parsed_url.query)
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
            // if self.provider_code != 'mollie':
            //     return super()._get_specific_rendering_values(processing_values)
            // 
            // payload = self._mollie_prepare_payment_request_payload()
            // try:
            //     payment_data = self._send_api_request('POST', '/payments', json=payload)
            // except ValidationError as error:
            //     self._set_error(str(error))
            //     return {}
            // 
            // # The provider reference is set now to allow fetching the payment status after redirection
            // self.provider_reference = payment_data.get('id')
            // 
            // # Extract the checkout URL from the payment data and add it with its query parameters to the
            // # rendering values. Passing the query parameters separately is necessary to prevent them
            // # from being stripped off when redirecting the user to the checkout URL, which can happen
            // # when only one payment method is enabled on Mollie and query parameters are provided.
            // checkout_url = payment_data['_links']['checkout']['href']
            // parsed_url = url_parse(checkout_url)
            // url_params = url_decode(parsed_url.query)
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
            // if self.provider_code != 'nuvei':
            //     return super()._get_specific_rendering_values(processing_values)
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
            //     'first_name': first_name[:30],
            //     'item_amount_1': rounded_amount,
            //     'item_name_1': self.reference,
            //     'item_quantity_1': 1,
            //     'invoice_id': self.reference,
            //     'last_name': last_name[:40],
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
            --- ODOO METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """ Override of `payment` to return Paymob-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`
            // 
            // :param dict processing_values: The generic and specific processing values of the
            //                                transaction.
            // :return: The dict of provider-specific rendering values.
            // :rtype: dict
            // """
            // if self.provider_code != 'paymob':
            //     return super()._get_specific_rendering_values(processing_values)
            // 
            // payload = self._paymob_prepare_payment_request_payload()
            // try:
            //     payment_data = self._send_api_request(
            //         'POST', '/v1/intention/', json=payload, is_client_request=True
            //     )
            // except ValidationError as error:
            //     self._set_error(str(error))
            //     return {}
            // 
            // # The provider reference is set to allow fetching the payment status after redirection.
            // self.provider_reference = payment_data.get('id')
            // paymob_client_secret = payment_data.get('client_secret')
            // 
            // paymob_url = self.provider_id._paymob_get_api_url()
            // api_url = f'{paymob_url}/unifiedcheckout/'
            // url_params = {
            //     'publicKey': self.provider_id.paymob_public_key,
            //     'clientSecret': paymob_client_secret,
            // }
            // return {'api_url': api_url, 'url_params': url_params}
            --- ODOO METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py) ---
            // def _get_specific_rendering_values(self, processing_values):
            // """Override of `payment` to return Redsys-specific rendering values.
            // 
            // Note: self.ensure_one() from `_get_processing_values`.
            // 
            // :param dict processing_values: The generic processing values of the transaction.
            // :return: The dict of provider-specific rendering values.
            // :rtype: dict
            // """
            // if self.provider_code != 'redsys':
            //     return super()._get_specific_rendering_values(processing_values)
            // 
            // merchant_parameters = self._redsys_prepare_merchant_parameters()
            // encoded_merchant_parameters = base64.b64encode(
            //     json.dumps(merchant_parameters).encode()
            // ).decode()
            // signature = self.provider_id._redsys_calculate_signature(
            //     encoded_merchant_parameters, self.reference, self.provider_id.redsys_secret_key
            // )
            // return {
            //     'api_url': self.provider_id._redsys_get_api_url(),
            //     'merchant_parameters': encoded_merchant_parameters,
            //     'signature': signature,
            //     'signature_version': 'HMAC_SHA256_V1',
            // }
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
            // if self.provider_code != 'worldline':
            //     return super()._get_specific_rendering_values(processing_values)
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
            // try:
            //     invoice_data = self._send_api_request('POST', 'v2/invoices', json=payload)
            // except ValidationError as error:
            //     self._set_error(str(error))
            //     return {}
            // 
            // # Extract the payment link URL and embed it in the redirect form.
            // rendering_values = {
            //     'api_url': invoice_data.get('invoice_url')
            // }
            // return rendering_values
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

        protected async Task<PaymentTransaction> IsSelfOrderPaymentConfirmedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: payment_transaction.py) ---
            // def _is_self_order_payment_confirmed(self):
            // self.ensure_one()
            // return (
            //     self.pos_order_id
            //     and self.state in ('authorized', 'done')
            //     and self.pos_order_id.source in ('mobile', 'kiosk')
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> IyzicoPrepareCfInitializePayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_iyzico, FILE: payment_transaction.py) ---
            // def _iyzico_prepare_cf_initialize_payload(self):
            // """Create the payload for the CF-initialize request based on the transaction values.
            // 
            // :return: The request payload.
            // :rtype: dict
            // """
            // base_url = self.provider_id.get_base_url()
            // first_name, last_name = payment_utils.split_partner_name(self.partner_name)
            // query_string_params = urls.url_encode({'tx_ref': self.reference})
            // return_url = f'{urljoin(base_url, const.PAYMENT_RETURN_ROUTE)}?{query_string_params}'
            // return {
            //     # Dummy basket item as it is required in Iyzico.
            //     'basketItems': [{
            //         'id': self.id,
            //         'price': self.amount,
            //         'name': 'Odoo purchase',
            //         'category1': 'Service',
            //         'itemType': 'VIRTUAL',
            //     }],
            //     'billingAddress': {
            //         'address': self.partner_address,
            //         'contactName': self.partner_name,
            //         'city': self.partner_city,
            //         'country': self.partner_country_id.name,
            //     },
            //     'buyer': {
            //         'id': self.partner_id.id,
            //         'name': first_name,
            //         'surname': last_name,
            //         'identityNumber': str(self.partner_id.id).zfill(5),
            //         'email': self.partner_email,
            //         'registrationAddress': self.partner_address,
            //         'city': self.partner_city,
            //         'country': self.partner_country_id.name,
            //         'ip': '0',
            //     },
            //     'callbackUrl': return_url,
            //     'conversationId': self.reference,
            //     'currency': self.currency_id.name,
            //     'locale': 'tr' if self.env.lang == 'tr_TR' else 'en',
            //     'paidPrice': self.amount,
            //     'paymentSource': 'ODOO',
            //     'price': self.amount,
            // }
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
            // if self.env.uid == SUPERUSER_ID or self.env.context.get('payment_backend_action'):
            //     author = self.env.user.partner_id
            // else:
            //     author = self.partner_id
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
            // if self.env.uid == SUPERUSER_ID or self.env.context.get('payment_backend_action'):
            //     author = self.env.user.partner_id
            // else:
            //     author = self.partner_id
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
            // """Log that the transactions have been processed in the chatter of relevant documents.
            // 
            // :return: None
            // """
            // for tx in self:
            //     if message := tx._get_received_message():
            //         tx._log_message_on_linked_documents(message)
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
            // """Log that the transactions have been created in the chatter of relevant documents.
            // 
            // :return: None
            // """
            // for tx in self:
            //     if message := tx._get_sent_message():
            //         tx._log_message_on_linked_documents(message)
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoConvertAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _mercado_pago_convert_amount(self):
            // """Convert the transaction amount according to Mercado Pago's currency requirements.
            // 
            // Mercado Pago requires certain currencies (COP, HNL, NIO) to be expressed as integers rather
            // than following the standard ISO 4217 decimal places. This method rounds down the amount to
            // the appropriate decimal places to ensure API compatibility.
            // 
            // :return: The transaction amount rounded to Mercado Pago's required decimal precision.
            // :rtype: float
            // """
            // unit_price = self.amount
            // decimal_places = const.CURRENCY_DECIMALS.get(self.currency_id.name)
            // if decimal_places is not None:
            //     unit_price = float_round(unit_price, decimal_places, rounding_method='DOWN')
            // return unit_price
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
            // return const.ERROR_MESSAGE_MAPPING.get(
            //     status_detail, const.ERROR_MESSAGE_MAPPING['cc_rejected_other_reason']
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoPrepareBaseRequestPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _mercado_pago_prepare_base_request_payload(self):
            // """ Create the base payload for requests based on the transaction values.
            // 
            // :return: The base request payload.
            // :rtype: dict
            // """
            // base_url = self.provider_id.get_base_url()
            // sanitized_reference = url_quote(self.reference)
            // # Append the reference to identify the transaction from the webhook payment data.
            // webhook_url = urljoin(base_url, f'{const.WEBHOOK_ROUTE}/{sanitized_reference}')
            // return {
            //     'external_reference': self.reference,
            //     'notification_url': webhook_url,
            // }
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoPreparePaymentRequestPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _mercado_pago_prepare_payment_request_payload(self):
            // """Create the payload for the direct payment request based on the transaction values.
            // 
            // :return: The payment request payload.
            // :rtype: dict
            // """
            // payload = self._mercado_pago_prepare_base_request_payload()
            // first_name, last_name = payment_utils.split_partner_name(self.partner_name)
            // payload.update({
            //     'additional_info': {
            //         'items': [{
            //             'title': self.reference,
            //             'quantity': 1,
            //             'unit_price': self._mercado_pago_convert_amount(),
            //         }],
            //     },
            //     'payer': {
            //         'first_name': first_name,
            //         'last_name': last_name,
            //         'email': self.partner_email,
            //     },
            // })
            // return payload
            */
            return default;
        }

        protected async Task<PaymentTransaction> MercadoPagoPreparePreferenceRequestPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _mercado_pago_prepare_preference_request_payload(self):
            // """Create the payload for the preference request based on the transaction values.
            // 
            // :return: The preference request payload.
            // :rtype: dict
            // """
            // payload = self._mercado_pago_prepare_base_request_payload()
            // 
            // base_url = self.provider_id.get_base_url()
            // return_url = urljoin(base_url, const.PAYMENT_RETURN_ROUTE)
            // payload.update({
            //     'auto_return': 'all',
            //     'back_urls': {
            //         'success': return_url,
            //         'pending': return_url,
            //         'failure': return_url,
            //     },
            //     'items': [{
            //         'title': self.reference,
            //         'quantity': 1,
            //         'currency_id': self.currency_id.name,
            //         'unit_price': self._mercado_pago_convert_amount(),
            //     }],
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
            // })
            // return payload
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
            // redirect_url = urls.urljoin(base_url, MollieController._return_url)
            // webhook_url = urls.urljoin(base_url, MollieController._webhook_url)
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

        protected async Task<PaymentTransaction> PaymobPreparePaymentRequestPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_paymob, FILE: payment_transaction.py) ---
            // def _paymob_prepare_payment_request_payload(self):
            // """ Create the payload for the payment request based on the transaction values.
            // 
            // :return: The request payload.
            // :rtype: dict
            // """
            // partner_first_name, partner_last_name = payment_utils.split_partner_name(self.partner_name)
            // payment_method_codes = [self.payment_method_code]
            // 
            // # If the user selects the Oman Net Payment Method to pay, Integration ID for both Card and
            // # Oman Net Integrations should be passed in the Intention API. The transaction will fail if
            // # you only pass Oman Net Integration ID.
            // if self.payment_method_code == 'omannet':
            //     payment_method_codes.append('card')
            // 
            // # Suffix to all payment methods with the environment.
            // environment = 'live' if self.provider_id.state == 'enabled' else 'test'
            // payment_method_codes = [
            //     f'{code.replace("_", "")}{environment}' for code in payment_method_codes
            // ]
            // 
            // base_url = self.get_base_url()
            // redirect_url = urls.urljoin(base_url, PaymobController._return_url)
            // webhook_url = urls.urljoin(base_url, PaymobController._webhook_url)
            // 
            // return {
            //     'special_reference': self.reference,
            //     'amount': payment_utils.to_minor_currency_units(self.amount, self.currency_id),
            //     'currency': self.currency_id.name,
            //     'payment_methods': payment_method_codes,
            //     'notification_url': webhook_url,
            //     'redirection_url': redirect_url,
            //     'billing_data': {
            //         'first_name': partner_first_name or partner_last_name or '',
            //         'last_name': partner_last_name or '',
            //         'email': self.partner_email or '',
            //         'street': self.partner_address or '',
            //         'state': self.partner_state_id.name or '',
            //         'phone_number': (self.partner_phone or '').replace(' ', ''),
            //         'country': self.partner_country_id.code or '',
            //     },
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
            //                 'email_address': self.provider_id.paypal_email_account,
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

        public async Task<PaymentTransaction> PostProcessAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def action_post_process(self):
            // """Trigger the post-processing of the transactions.
            // 
            // :return: A client action to soft-reload the view.
            // :rtype: dict
            // """
            // self._post_process()
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'soft_reload',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            //             "The payment related to transaction %(ref)s has been posted: %(link)s",
            //             ref=tx._get_html_link(),
            //             link=tx.payment_id._get_html_link(),
            //         )
            //         tx._log_message_on_linked_documents(message)
            // for tx in self.filtered(lambda t: t.state == 'cancel'):
            //     tx.payment_id.action_cancel()
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: payment_transaction.py) ---
            // def _post_process(self):
            // """ Override of `payment` to confirm orders with the cash_on_delivery payment method and
            // trigger a picking creation. """
            // cod_pending_txs = self.filtered(
            //     lambda tx: tx.provider_id.custom_mode == 'cash_on_delivery' and tx.state == 'pending'
            // )
            // cod_pending_txs.sale_order_ids.filtered(
            //     lambda so: so.state == 'draft'
            // ).with_context(send_email=True).action_confirm()
            // super()._post_process()
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
            //     if done_tx.operation != 'validation':
            //         confirmed_orders = done_tx._check_amount_and_confirm_order()
            //         (done_tx.sale_order_ids - confirmed_orders)._send_payment_succeeded_for_order_mail()
            // 
            //     auto_invoice = str2bool(
            //         self.env['ir.config_parameter'].sudo().get_param('sale.automatic_invoice')
            //     )
            //     if auto_invoice:
            //         # Invoice the sales orders of confirmed transactions instead of only confirmed
            //         # orders to create the invoice even if only a partial payment was made.
            //         done_tx._invoice_sale_orders()
            //     super(PaymentTransaction, done_tx)._post_process()  # Post the invoices.
            //     if auto_invoice and not self.env.context.get('skip_sale_auto_invoice_send'):
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

        protected async Task<PaymentTransaction> ProcessInternalAsync(object provider_code, object payment_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _process(self, provider_code, payment_data):
            // """Process the payment data received from the provider and update the transaction.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param dict payment_data: The payment data sent by the provider.
            // :return: The updated transaction.
            // :rtype: payment.transaction
            // """
            // tx = self or self._search_by_reference(provider_code, payment_data)
            // if tx:
            //     tx.ensure_one()
            //     previous_state = tx.state
            //     tx._validate_amount(payment_data)
            //     if tx.state == 'error' and tx.state != previous_state:
            //         return tx
            //     tx._apply_updates(payment_data)
            //     if tx.tokenize and tx.state in {'authorized', 'done'}:
            //         tx._tokenize(payment_data)
            // return tx
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: payment_transaction.py) ---
            // def _process(self, provider_code, payment_data):
            // tx = super()._process(provider_code, payment_data)
            // if tx._is_self_order_payment_confirmed():
            //     self.env.ref('payment.cron_post_process_payment_tx')._trigger()
            // return tx
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
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: payment_transaction.py) ---
            // def _process_pos_online_payment(self):
            // super()._process_pos_online_payment()
            // for tx in self:
            //     if tx and tx.pos_order_id and tx.state in ('authorized', 'done'):
            //         tx.pos_order_id._send_notification_online_payment_status('success')
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
            // customer_data = {}
            // try:
            //     customer_data = self._send_api_request('POST', 'customers', json=payload)
            // except ValidationError as e:
            //     self._set_error(str(e))
            // 
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
            // order_data = {}
            // try:
            //     order_data = self._send_api_request('POST', 'orders', json=payload)
            // except ValidationError as e:
            //     self._set_error(str(e))
            // return order_data
            */
            return default;
        }

        protected async Task<PaymentTransaction> RazorpayCreateRefundTxFromPaymentDataInternalAsync(object source_tx, object payment_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _razorpay_create_refund_tx_from_payment_data(self, source_tx, payment_data):
            // """ Create a refund transaction based on Razorpay data.
            // 
            // :param recordset source_tx: The source transaction for which a refund is initiated, as a
            //                             `payment.transaction` recordset.
            // :param dict payment_data: The payment data sent by the provider.
            // :return: The newly created refund transaction.
            // :rtype: payment.transaction
            // :raise ValidationError: If inconsistent data were received.
            // """
            // refund_provider_reference = payment_data.get('id')
            // amount_to_refund = payment_data.get('amount')
            // if not refund_provider_reference or not amount_to_refund:
            //     raise ValidationError(_("Received incomplete refund data."))
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

        protected async Task<PaymentTransaction> RedsysPrepareMerchantParametersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py) ---
            // def _redsys_prepare_merchant_parameters(self):
            // """Create the merchant parameters payload based on the transaction values.
            // 
            // :return: The merchant parameters.
            // :rtype: str
            // """
            // converted_amount = payment_utils.to_minor_currency_units(self.amount, self.currency_id)
            // base_url = self.provider_id.get_base_url()
            // return_url = urljoin(base_url, RedsysController._return_url)
            // webhook_url = urljoin(base_url, RedsysController._webhook_url)
            // merchant_parameters = {
            //     'DS_MERCHANT_AMOUNT': str(converted_amount),
            //     'DS_MERCHANT_CURRENCY': self.currency_id.iso_numeric,
            //     'DS_MERCHANT_MERCHANTCODE': self.provider_id.redsys_merchant_code,
            //     'DS_MERCHANT_TERMINAL': self.provider_id.redsys_merchant_terminal,
            //     'DS_MERCHANT_ORDER': self.reference,
            //     'DS_MERCHANT_MERCHANTURL': webhook_url,
            //     'DS_MERCHANT_TRANSACTIONTYPE': '0',  # Authorization
            //     'DS_MERCHANT_URLOK': return_url,
            //     'DS_MERCHANT_URLKO': return_url,
            //     'DS_MERCHANT_PAYMETHODS': const.PAYMENT_METHODS_MAPPING.get(
            //         self.payment_method_id.code, 'C'
            //     ),
            //     'DS_MERCHANT_EMV3DS': {
            //         'billAddrCity': self.partner_city,
            //         'billAddrCountry': COUNTRY_NUMERIC_CODES.get(self.partner_country_id.code, ''),
            //         'billAddrLine1': self.partner_address,
            //         'billAddrPostCode': self.partner_zip,
            //         'billAddrState': self.partner_state_id.code,
            //         'cardholderName': self.partner_name,
            //         'email': self.partner_email,
            //     }
            // }
            // return merchant_parameters
            */
            return default;
        }

        public async Task<PaymentTransaction> RefundAsync(Guid id, PaymentTransactionRefundRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def action_refund(self, amount_to_refund=None):
            // """Check the state of the transactions and request their refund.
            // 
            // :param float amount_to_refund: The amount to be refunded.
            // :return: None
            // """
            // payment_utils.check_rights_on_recordset(self)
            // 
            // if any(tx.state != 'done' for tx in self):
            //     raise ValidationError(_("Only confirmed transactions can be refunded."))
            // 
            // refunded_txs_sudo = self.env['payment.transaction'].sudo()
            // for tx in self:
            //     # In sudo mode to read on provider fields.
            //     refunded_txs_sudo |= tx.sudo().with_context(payment_backend_action=True)._refund(amount_to_refund=amount_to_refund)
            // return refunded_txs_sudo._build_action_feedback_notification()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentTransaction> RefundInternalAsync(object amount_to_refund)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _refund(self, amount_to_refund=None):
            // """Refund the transaction.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param float amount_to_refund: The amount to be refunded.
            // :return: The refund transaction created to process the refund request.
            // :rtype: payment.transaction
            // """
            // self.ensure_one()
            // self._ensure_provider_is_not_disabled()
            // 
            // refund_tx = self._create_child_transaction(amount_to_refund or self.amount, is_refund=True)
            // refund_tx._log_sent_message()
            // try:
            //     refund_tx._send_refund_request()
            // except ValidationError as e:
            //     refund_tx._set_error(str(e))
            // return refund_tx
            */
            return default;
        }

        protected async Task<PaymentTransaction> SearchByReferenceInternalAsync(object provider_code, object payment_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _search_by_reference(self, provider_code, payment_data):
            // """Search the transaction based on the payment data.
            // 
            // :param str provider_code: The code of the provider handling the transaction.
            // :param dict payment_data: The payment data sent by the provider.
            // :return: The transaction, if found.
            // :rtype: payment.transaction
            // """
            // reference = self._extract_reference(provider_code, payment_data)
            // if not reference:
            //     _logger.warning(
            //         "Received payment data from provider %s with missing reference", provider_code
            //     )
            //     return self
            // 
            // tx = self.search(
            //     Domain('reference', '=', reference) & Domain('provider_code', '=', provider_code)
            // )
            // if not tx:
            //     _logger.warning("No transaction found matching reference %s.", reference)
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _search_by_reference(self, provider_code, payment_data):
            // """Override of `payment` to search the transaction  with a specific logic for Adyen."""
            // if provider_code != 'adyen':
            //     return super()._search_by_reference(provider_code, payment_data)
            // 
            // tx = self
            // reference = payment_data.get('merchantReference')
            // if not reference:
            //     _logger.warning("Received data with missing reference.")
            //     return tx
            // 
            // event_code = payment_data.get('eventCode', 'AUTHORISATION')  # Fallback on auth if S2S.
            // provider_reference = payment_data.get('pspReference')
            // source_reference = payment_data.get('originalReference')
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
            //         payment_data_amount = payment_data.get('amount', {}).get('value')
            //         converted_notification_amount = payment_utils.to_major_currency_units(
            //             payment_data_amount,
            //             source_tx.currency_id,
            //             arbitrary_decimal_number=const.CURRENCY_DECIMALS.get(self.currency_id.name),
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
            //                 tx = self._adyen_create_child_tx(source_tx, payment_data)
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
            //             tx = self._adyen_create_child_tx(source_tx, payment_data, is_refund=True)
            //         else:  # The refund was initiated for an unknown source transaction
            //             pass  # Don't do anything with the refund notification
            // if not tx:
            //     _logger.warning("No transaction found matching reference %s.", reference)
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _search_by_reference(self, provider_code, payment_data):
            // """ Override of `payment` to find the transaction based on razorpay data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict payment_data: The normalized payment data sent by the provider
            // :return: The transaction if found
            // :rtype: payment.transaction
            // :raise: ValidationError if the data match no transaction
            // """
            // if provider_code != 'razorpay':
            //     return super()._search_by_reference(provider_code, payment_data)
            // 
            // entity_type = payment_data.get('entity_type', 'payment')
            // tx = self
            // if entity_type == 'payment':
            //     reference = payment_data.get('description')
            //     if not reference:
            //         _logger.warning("Received data with missing reference.")
            //         return tx
            //     tx = self.search([('reference', '=', reference), ('provider_code', '=', 'razorpay')])
            // else:  # 'refund'
            //     notes = payment_data.get('notes')
            //     reference = isinstance(notes, dict) and notes.get('reference')
            //     if reference:  # The refund was initiated from Odoo.
            //         tx = self.search([('reference', '=', reference), ('provider_code', '=', 'razorpay')])
            //     else:  # The refund was initiated from Razorpay.
            //         # Find the source transaction based on its provider reference.
            //         source_tx = self.search([
            //             ('provider_reference', '=', payment_data['payment_id']),
            //             ('provider_code', '=', 'razorpay'),
            //         ])
            //         if source_tx:
            //             # Manually create a refund transaction with a new reference.
            //             tx = self._razorpay_create_refund_tx_from_payment_data(
            //                 source_tx, payment_data
            //             )
            //         else:  # The refund was initiated for an unknown source transaction.
            //             pass  # Don't do anything with the refund notification.
            // return tx
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _search_by_reference(self, provider_code, payment_data):
            // """ Override of payment to find the transaction based on Stripe data.
            // 
            // :param str provider_code: The code of the provider that handled the transaction
            // :param dict payment_data: The payment data sent by the provider
            // :return: The transaction if found
            // :rtype: payment.transaction
            // """
            // if provider_code != 'stripe':
            //     return super()._search_by_reference(provider_code, payment_data)
            // 
            // reference = payment_data.get('reference')
            // if reference:
            //     tx = self.search([('reference', '=', reference), ('provider_code', '=', 'stripe')])
            // elif payment_data.get('event_type') == 'charge.refund.updated':
            //     # The webhook notifications sent for `charge.refund.updated` events only contain a
            //     # refund object that has no 'description' (the merchant reference) field. We thus search
            //     # the transaction by its provider reference which is the refund id for refund txs.
            //     refund_id = payment_data['object_id']  # The object is a refund.
            //     tx = self.search(
            //         [('provider_reference', '=', refund_id), ('provider_code', '=', 'stripe')]
            //     )
            // else:
            //     _logger.warning("Received data with missing merchant reference")
            //     tx = self
            // 
            // if not tx:
            //     _logger.warning("No transaction found matching reference %s.", reference)
            // 
            // return tx
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendApiRequestInternalAsync(object method, object endpoint)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _send_api_request(self, method, endpoint, *, params=None, data=None, json=None, **kwargs):
            // """Send a request to the API.
            // 
            // This method serves as a helper to:
            // 
            // 1. Pass the transaction reference to the provider's
            //    :meth:`~odoo.addons.payment.models.payment_provider.PaymentProvider._send_api_request`
            //    method.
            // 2. Set the transaction's state to `error` if the request fails, with the exception's message
            //    as the `state_message`.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param str method: The HTTP method of the request.
            // :param str endpoint: The endpoint of the API to reach with the request.
            // :param dict params: The query string parameters of the request.
            // :param dict|str data: The body of the request.
            // :param dict json: The JSON-formatted body of the request.
            // :param dict kwargs: Provider-specific data forwarded to the specialized helper methods.
            // :return: The formatted content of the response.
            // :rtype: dict|str
            // :raise ValidationError: If an HTTP error occurs.
            // """
            // self.ensure_one()
            // return self.provider_id._send_api_request(
            //     method,
            //     endpoint,
            //     params=params,
            //     data=data,
            //     json=json,
            //     reference=self.reference,
            //     **kwargs,
            // )
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendCaptureRequestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _send_capture_request(self):
            // """Request the provider handling the transaction to send a capture request.
            // 
            // For a provider to support authorization, it must override this method and send an API
            // request to capture the payment.
            // 
            // Note: `self.ensure_one()` from :meth:`_capture`
            // 
            // :return: None
            // """
            // return
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _send_capture_request(self):
            // """Override of `payment` to send a capture request to Adyen."""
            // if self.provider_code != 'adyen':
            //     return super()._send_capture_request()
            // 
            // # Send the capture request to Adyen.
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
            // }
            // 
            // response_content = self._send_api_request(
            //     'POST',
            //     '/payments/{}/captures',
            //     json=data,
            //     endpoint_param=self.provider_reference,
            // )
            // 
            // # Process the capture request response.
            // status = response_content.get('status')
            // formatted_amount = format_amount(self.env, self.amount, self.currency_id)
            // if status == 'received':
            //     self._log_message_on_linked_documents(_(
            //         "The capture request of %(amount)s for transaction %(ref)s has been sent.",
            //         amount=formatted_amount, ref=self.reference
            //     ))
            // 
            // # The PSP reference associated with this capture request is different from the PSP
            // # reference associated with the original payment request.
            // self.provider_reference = response_content.get('pspReference')
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _send_capture_request(self):
            // """Override of `payment` to send a capture request to Authorize."""
            // if self.provider_code != 'authorize':
            //     return super()._send_capture_request()
            // 
            // authorize_API = AuthorizeAPI(self.provider_id)
            // rounded_amount = round(self.amount, self.currency_id.decimal_places)
            // res_content = authorize_API.capture(
            //     self.source_transaction_id.provider_reference, rounded_amount
            // )
            // _logger.info(
            //     "capture request response for transaction %s:\n%s",
            //     self.reference, pprint.pformat(res_content)
            // )
            // self._process('authorize', {'response': res_content})
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _send_capture_request(self):
            // """Override of `payment` to simulate a capture request."""
            // if self.provider_code != 'demo':
            //     return super()._send_capture_request()
            // 
            // payment_data = {
            //     'reference': self.reference,
            //     'simulated_state': 'done',
            //     'manual_capture': True,  # Distinguish manual captures from regular one-step captures.
            // }
            // self._process('demo', payment_data)
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _send_capture_request(self):
            // """Override of `payment` to send a capture request to Razorpay."""
            // if self.provider_code != 'razorpay':
            //     return super()._send_capture_request()
            // 
            // converted_amount = payment_utils.to_minor_currency_units(self.amount, self.currency_id)
            // payload = {'amount': converted_amount, 'currency': self.currency_id.name}
            // response_content = self._send_api_request(
            //     'POST', f'payments/{self.provider_reference}/capture', json=payload
            // )
            // 
            // # Process the capture request response.
            // self._process('razorpay', response_content)
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _send_capture_request(self):
            // """Override of `payment` to send a capture request to Stripe."""
            // if self.provider_code != 'stripe':
            //     return super()._send_capture_request()
            // 
            // # Make the capture request to Stripe
            // payment_intent = self._send_api_request(
            //     'POST', f'payment_intents/{self.source_transaction_id.provider_reference}/capture'
            // )
            // 
            // # Process the capture request response.
            // payment_data = {'reference': self.reference}
            // StripeController._include_payment_intent_in_payment_data(
            //     payment_intent, payment_data
            // )
            // self._process('stripe', payment_data)
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
            //     body = self.env['ir.qweb'].with_context(lang=self.partner_id.lang)._render('website_payment.donation_mail_body', {
            //         'is_internal_notification': is_internal_notification,
            //         'tx': self,
            //         'comment': comment,
            //     }, minimal_qcontext=True)
            //     body = self.env['mail.render.mixin'].with_context(lang=self.partner_id.lang)._render_encapsulate(
            //         'mail.mail_notification_light',
            //         body,
            //         context_record=self,
            //     )
            //     self.env['mail.mail'].sudo().create({
            //         'author_id': self.partner_id.id,
            //         'body_html': body,
            //         'email_from': self.company_id.email_formatted,
            //         'email_to': recipient_email if is_internal_notification else self.partner_email,
            //         'subject': subject,
            //     }).send()
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
            //     tx.env['account.move.send']._generate_and_send_invoices(
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
            // """Request the provider handling the transaction to send a token payment request.
            // 
            // This method is exclusively used to make payments by token, which correspond to both the
            // `online_token` and the `offline` transaction's `operation` field.
            // 
            // For a provider to support tokenization, it must override this method and send an API request
            // to make a payment.
            // 
            // Note: `self.ensure_one()` from :meth:`_charge_with_token`
            // 
            // :return: None
            // """
            // return
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """Override of `payment` to send a payment request to Adyen."""
            // if self.provider_code != 'adyen':
            //     return super()._send_payment_request()
            // 
            // # Prepare the payment request to Adyen.
            // converted_amount = payment_utils.to_minor_currency_units(
            //     self.amount, self.currency_id, const.CURRENCY_DECIMALS.get(self.currency_id.name)
            // )
            // partner_country_code = (
            //     self.partner_country_id.code or self.provider_id.company_id.country_id.code or 'NL'
            // )
            // data = {
            //     'merchantAccount': self.provider_id.adyen_merchant_account,
            //     'amount': {
            //         'value': converted_amount,
            //         'currency': self.currency_id.name,
            //     },
            //     'applicationInfo': {
            //         'externalPlatform': {
            //             'name': 'Odoo',
            //             'version': release.version,
            //             'integrator': 'Odoo SA',
            //         }
            //     },
            //     'countryCode': partner_country_code,
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
            //     'lineItems': [{
            //         'amountIncludingTax': converted_amount,
            //         'quantity': '1',
            //         'description': self.reference,
            //     }],
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
            // # Send the payment request to Adyen.
            // response_content = self._send_api_request(
            //     'POST',
            //     '/payments',
            //     json=data,
            //     idempotency_key=payment_utils.generate_idempotency_key(
            //         self, scope='payment_request_token'
            //     )
            // )
            // self._process('adyen', response_content)
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """Override of `payment` to send a payment request to Authorize."""
            // if self.provider_code != 'authorize':
            //     return super()._send_payment_request()
            // 
            // authorize_API = AuthorizeAPI(self.provider_id)
            // if self.provider_id.capture_manually:
            //     res_content = authorize_API.authorize(self, token=self.token_id)
            //     _logger.info(
            //         "authorize request response for transaction %s:\n%s",
            //         self.reference, pprint.pformat(res_content)
            //     )
            // else:
            //     res_content = authorize_API.auth_and_capture(self, token=self.token_id)
            //     _logger.info(
            //         "auth_and_capture request response for transaction %s:\n%s",
            //         self.reference, pprint.pformat(res_content)
            //     )
            // self._process('authorize', {'response': res_content})
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """Override of `payment` to simulate a payment request."""
            // if self.provider_code != 'demo':
            //     return super()._send_payment_request()
            // 
            // simulated_state = self.token_id.demo_simulated_state
            // payment_data = {'reference': self.reference, 'simulated_state': simulated_state}
            // self._process('demo', payment_data)
            --- ODOO METHOD SOURCE (MODULE: payment_flutterwave, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """Override of `payment` to send a payment request to Flutterwave."""
            // if self.provider_code != 'flutterwave':
            //     return super()._send_payment_request()
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
            //     'redirect_url': urls.urljoin(base_url, FlutterwaveController._auth_return_url),
            // }
            // 
            // try:
            //     response_content = self._send_api_request('POST', 'tokenized-charges', json=data)
            // except ValidationError as error:
            //     self._set_error(str(error))
            // else:
            //     self._process('flutterwave', response_content)
            --- ODOO METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """Override of `payment` to send a payment request to Mercado Pago.
            // 
            // Note: `self.ensure_one()` from :meth:`_charge_with_token`
            // 
            // :rtype: None
            // """
            // if self.provider_code != 'mercado_pago':
            //     super()._send_payment_request()
            //     return
            // 
            // # A new token has to be generated based on 'card_id' for every payment.
            // response_content = self._send_api_request(
            //     'POST', '/v1/card_tokens', data={'card_id': self.token_id.provider_ref}
            // )
            // 
            // # Send the payment request to Mercado Pago.
            // data = {
            //     'transaction_amount': self._mercado_pago_convert_amount(),
            //     'token': response_content['id'],
            //     'installments': 1,
            //     'payer': {
            //         'type': 'customer',
            //         'id': self.token_id.mercado_pago_customer_id,
            //     },
            // }
            // response_content = self._send_api_request(
            //     'POST',
            //     endpoint='/v1/payments',
            //     json=data,
            //     idempotency_key=payment_utils.generate_idempotency_key(
            //         self, scope='token_payment'
            //     ),
            // )
            // self._process('mercado_pago', response_content)
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """Override of `payment` to send a payment request to Razorpay."""
            // if self.provider_code != 'razorpay':
            //     return super()._send_payment_request()
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
            //     self._set_error(_(
            //         "Your last payment %s will soon be processed. Please wait up to 24 hours before"
            //         " trying again, or use another payment method.", earlier_pending_tx.reference
            //     ))
            //     return
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
            //     recurring_payment_data = self._send_api_request(
            //         'POST', 'payments/create/recurring', json=payload
            //     )
            // except ValidationError as e:
            //     self._set_error(str(e))
            // else:
            //     self._process('razorpay', recurring_payment_data)
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """Override of `payment` to send a payment request to Stripe."""
            // if self.provider_code != 'stripe':
            //     return super()._send_payment_request()
            // 
            // # Send the payment request to Stripe.
            // payment_intent = self._stripe_create_intent()
            // 
            // if not payment_intent:  # The PI might be missing if Stripe failed to create it.
            //     return  # There is nothing to process; the transaction is in error at this point.
            // 
            // # Handle the payment request response
            // payment_data = {'reference': self.reference}
            // StripeController._include_payment_intent_in_payment_data(
            //     payment_intent, payment_data
            // )
            // self._process('stripe', payment_data)
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """Override of `payment` to send a payment request to Worldline."""
            // if self.provider_code != 'worldline':
            //     return super()._send_payment_request()
            // 
            // # Prepare the payment request to Worldline.
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
            // try:
            //     # Send the payment request to Worldline.
            //     response_content = self._send_api_request(
            //         'POST',
            //         'payments',
            //         json=payload,
            //         idempotency_key=payment_utils.generate_idempotency_key(
            //             self, scope='payment_request_token'
            //         )
            //     )
            // except ValidationError as e:
            //     self._set_error(str(e))
            // else:
            //     self._process('worldline', response_content)
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _send_payment_request(self):
            // """Override of `payment` to send a payment request to Xendit."""
            // if self.provider_code != 'xendit':
            //     return super()._send_payment_request()
            // 
            // self._xendit_create_charge(self.token_id.provider_ref)
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendRefundRequestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _send_refund_request(self):
            // """Request the provider handling the transaction to send a refund request.
            // 
            // For a provider to support refunds, it must override this method and send an API request to
            // make a refund.
            // 
            // Note: `self.ensure_one()` from :meth:`_refund`
            // 
            // :return: None
            // """
            // return
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _send_refund_request(self):
            // """Override of `payment` to send a refund request to Adyen."""
            // if self.provider_code != 'adyen':
            //     return super()._send_refund_request()
            // 
            // # Send the refund request to Adyen.
            // converted_amount = payment_utils.to_minor_currency_units(
            //     -self.amount,  # The amount is negative for refund transactions
            //     self.currency_id,
            //     arbitrary_decimal_number=const.CURRENCY_DECIMALS.get(self.currency_id.name)
            // )
            // data = {
            //     'merchantAccount': self.provider_id.adyen_merchant_account,
            //     'amount': {
            //         'value': converted_amount,
            //         'currency': self.currency_id.name,
            //     },
            //     'reference': self.reference,
            // }
            // response_content = self._send_api_request(
            //     'POST',
            //     '/payments/{}/refunds',
            //     json=data,
            //     endpoint_param=self.source_transaction_id.provider_reference,
            // )
            // 
            // # Process the refund request response.
            // psp_reference = response_content.get('pspReference')
            // status = response_content.get('status')
            // if psp_reference and status == 'received':
            //     # The PSP reference associated with this /refunds request is different from the psp
            //     # reference associated with the original payment request.
            //     self.provider_reference = psp_reference
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _send_refund_request(self):
            // """Override of `payment` to send a refund request to Authorize."""
            // if self.provider_code != 'authorize':
            //     return super()._send_refund_request()
            // 
            // authorize_api = AuthorizeAPI(self.provider_id)
            // tx_details = authorize_api.get_transaction_details(
            //     self.source_transaction_id.provider_reference
            // )
            // if 'err_code' in tx_details:  # Could not retrieve the transaction details.
            //     self._set_error(_(
            //         "Could not retrieve the transaction details. (error code: %(error_code)s; error_details: %(error_message)s)",
            //         error_code=tx_details['err_code'], error_message=tx_details.get('err_msg'),
            //     ))
            //     return
            // 
            // tx_status = tx_details.get('transaction', {}).get('transactionStatus')
            // if tx_status in const.TRANSACTION_STATUS_MAPPING['voided']:
            //     # The payment has been voided from Authorize.net side before we could refund it.
            //     self._set_canceled(extra_allowed_states=('done',))
            // elif tx_status in const.TRANSACTION_STATUS_MAPPING['refunded']:
            //     # The payment has been refunded from Authorize.net side before we could refund it. We
            //     # create a refund tx on Odoo to reflect the move of the funds.
            //     self._set_done()
            //     # Immediately post-process the transaction as the post-processing will not be
            //     # triggered by a customer browsing the transaction from the portal.
            //     self.env.ref('payment.cron_post_process_payment_tx')._trigger()
            // elif any(tx_status in const.TRANSACTION_STATUS_MAPPING[k] for k in ('authorized', 'captured')):
            //     if tx_status in const.TRANSACTION_STATUS_MAPPING['authorized']:
            //         # The payment has not been settled on Authorize.net yet. It must be voided rather
            //         # than refunded. Since the funds have not moved yet, we don't create a refund tx.
            //         res_content = authorize_api.void(self.source_transaction_id.provider_reference)
            //     else:
            //         # The payment has been settled on Authorize.net side. We can refund it.
            //         rounded_amount = round(self.amount, self.currency_id.decimal_places)
            //         res_content = authorize_api.refund(
            //             self.provider_reference, rounded_amount, tx_details
            //         )
            //     _logger.info(
            //         "refund request response for transaction %s:\n%s",
            //         self.reference, pprint.pformat(res_content)
            //     )
            //     data = {'reference': self.reference, 'response': res_content}
            //     self._process('authorize', data)
            // else:
            //     err_msg = _(
            //         "The transaction is not in a status to be refunded."
            //         " (status: %(status)s, details: %(message)s)",
            //         status=tx_status, message=tx_details.get('messages', {}).get('message'),
            //     )
            //     _logger.warning(err_msg)
            //     self._set_error(err_msg)
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _send_refund_request(self):
            // """Override of `payment` to simulate a refund."""
            // if self.provider_code != 'demo':
            //     return super()._send_refund_request()
            // 
            // payment_data = {'reference': self.reference, 'simulated_state': 'done'}
            // self._process('demo', payment_data)
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _send_refund_request(self):
            // """Override of `payment` to send a refund request to Razorpay."""
            // if self.provider_code != 'razorpay':
            //     return super()._send_refund_request()
            // 
            // # Send the refund request to Razorpay.
            // converted_amount = payment_utils.to_minor_currency_units(
            //     -self.amount, self.currency_id
            // )  # The amount is negative for refund transactions.
            // payload = {
            //     'amount': converted_amount,
            //     'notes': {
            //         'reference': self.reference,  # Allow retrieving the ref. from webhook data.
            //     },
            // }
            // response_content = self._send_api_request(
            //     'POST', f'payments/{self.provider_reference}/refund', json=payload
            // )
            // response_content.update(entity_type='refund')
            // self._process('razorpay', response_content)
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _send_refund_request(self):
            // """Override of `payment` to send a refund request to Stripe."""
            // if self.provider_code != 'stripe':
            //     return super()._send_refund_request()
            // 
            // # Send the refund request to Stripe.
            // data = self._send_api_request(
            //     'POST', 'refunds', data={
            //         'payment_intent': self.source_transaction_id.provider_reference,
            //         'amount': payment_utils.to_minor_currency_units(
            //             -self.amount,  # Refund transactions' amount is negative, inverse it.
            //             self.currency_id,
            //             arbitrary_decimal_number=const.CURRENCY_DECIMALS.get(self.currency_id.name),
            //         ),
            //     }
            // )
            // 
            // # Process the refund request response.
            // payment_data = {}
            // StripeController._include_refund_in_payment_data(data, payment_data)
            // self._process('stripe', payment_data)
            */
            return default;
        }

        protected async Task<PaymentTransaction> SendVoidRequestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _send_void_request(self):
            // """Request the provider handling the transaction to send a void request.
            // 
            // For a provider to support authorization, it must override this method and send an API
            // request to void the payment.
            // 
            // Note: `self.ensure_one()` from :meth:`_void`
            // 
            // :return: None
            // """
            // return
            --- ODOO METHOD SOURCE (MODULE: payment_adyen, FILE: payment_transaction.py) ---
            // def _send_void_request(self):
            // """Override of `payment` to send a void request to Adyen."""
            // if self.provider_code != 'adyen':
            //     return super()._send_void_request()
            // 
            // data = {
            //     'merchantAccount': self.provider_id.adyen_merchant_account,
            //     'reference': self.reference,
            // }
            // response_content = self._send_api_request(
            //     'POST',
            //     '/payments/{}/cancels',
            //     json=data,
            //     endpoint_param=self.provider_reference,
            // )
            // 
            // # Process the void request response.
            // status = response_content.get('status')
            // if status == 'received':
            //     self._log_message_on_linked_documents(_(
            //         "A request was sent to void the transaction %(reference)s.",
            //         reference=self.reference
            //     ))
            // 
            // # The PSP reference associated with this void request is different from the PSP
            // # reference associated with the original payment request.
            // self.provider_reference = response_content.get('pspReference')
            --- ODOO METHOD SOURCE (MODULE: payment_authorize, FILE: payment_transaction.py) ---
            // def _send_void_request(self):
            // """Override of `payment` to send a void request to Authorize."""
            // if self.provider_code != 'authorize':
            //     return super()._send_void_request()
            // 
            // authorize_API = AuthorizeAPI(self.provider_id)
            // res_content = authorize_API.void(self.provider_reference)
            // _logger.info(
            //     "void request response for transaction %s:\n%s",
            //     self.reference, pprint.pformat(res_content)
            // )
            // self._process('authorize', {'response': res_content})
            --- ODOO METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py) ---
            // def _send_void_request(self):
            // """Override of `payment` to simulate a void request."""
            // if self.provider_code != 'demo':
            //     return super()._send_void_request()
            // 
            // payment_data = {'reference': self.reference, 'simulated_state': 'cancel'}
            // self._process('demo', payment_data)
            --- ODOO METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_transaction.py) ---
            // def _send_void_request(self):
            // """Override of `payment` to explain that it is impossible to void a Razorpay transaction."""
            // if self.provider_code != 'razorpay':
            //     return super()._send_void_request()
            // 
            // raise UserError(_("Transactions processed by Razorpay can't be manually voided from Odoo."))
            --- ODOO METHOD SOURCE (MODULE: payment_stripe, FILE: payment_transaction.py) ---
            // def _send_void_request(self):
            // """Override of `payment` to send a void request to Stripe."""
            // if self.provider_code != 'stripe':
            //     return super()._send_void_request()
            // 
            // # Make the void request to Stripe
            // payment_intent = self._send_api_request(
            //     'POST', f'payment_intents/{self.source_transaction_id.provider_reference}/cancel'
            // )
            // 
            // # Process the void request response.
            // payment_data = {'reference': self.reference}
            // StripeController._include_payment_intent_in_payment_data(
            //     payment_intent, payment_data
            // )
            // self._process('stripe', payment_data)
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetAuthorizedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _set_authorized(self, *, state_message=None, extra_allowed_states=()):
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
            // txs_to_process._log_received_message()
            // txs_to_process._update_source_transaction_state()
            // return txs_to_process
            */
            return default;
        }

        protected async Task<PaymentTransaction> SetDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _set_done(self, *, state_message=None, extra_allowed_states=()):
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
            // txs_to_process._log_received_message()
            // txs_to_process._update_source_transaction_state()
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

        protected async Task<PaymentTransaction> SetPendingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _set_pending(self, *, state_message=None, extra_allowed_states=()):
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
            // customer = self._send_api_request(
            //     'POST', 'customers', data={
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
            // :return: The created PaymentIntent or SetupIntent object or None if creation failed.
            // :rtype: dict|None
            // """
            // try:
            //     if self.operation == 'validation':
            //         response = self._send_api_request(
            //             'POST', 'setup_intents', data=self._stripe_prepare_setup_intent_payload(),
            //         )
            //     else:  # 'online_direct', 'online_token', 'offline'.
            //         response = self._send_api_request(
            //             'POST',
            //             'payment_intents',
            //             data=self._stripe_prepare_payment_intent_payload(),
            //             offline=self.operation == 'offline',
            //             idempotency_key=payment_utils.generate_idempotency_key(
            //                 self, scope='payment_intents'
            //             ),
            //         )
            // except ValidationError as error:
            //     self._set_error(str(error))
            //     intent = None
            // else:
            //     intent = response
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
            //         mandate_values.get('amount', 15000),
            //         self.currency_id,
            //         arbitrary_decimal_number=const.CURRENCY_DECIMALS.get(self.currency_id.name),
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
            //     'amount': payment_utils.to_minor_currency_units(
            //         self.amount,
            //         self.currency_id,
            //         arbitrary_decimal_number=const.CURRENCY_DECIMALS.get(self.currency_id.name),
            //     ),
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

        protected async Task<PaymentTransaction> TokenizeInternalAsync(object payment_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _tokenize(self, payment_data):
            // """Create a new token based on the payment data.
            // 
            // :param dict payment_data: The payment data sent by the provider.
            // :return: None
            // """
            // self.ensure_one()
            // 
            // if not (token_values := self._extract_token_values(payment_data)):
            //     return
            // 
            // token = self.env['payment.token'].create({
            //     'provider_id': self.provider_id.id,
            //     'payment_method_id': self.payment_method_id.id,
            //     'partner_id': self.partner_id.id,
            //     **token_values,
            // })
            // self.write({
            //     'token_id': token,
            //     'tokenize': False,
            // })
            // _logger.info(
            //     "Token %(token_id)s created for partner %(partner_id)s from transaction %(ref)s.",
            //     {'token_id': token.id, 'partner_id': self.partner_id.id, 'ref': self.reference},
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
            //         fully_voided = all(tx.state == 'cancel' for tx in sibling_txs)
            //         target_state = 'cancel' if fully_voided else 'done'
            //         # Call `_update_state` directly instead of `_set_authorized` to avoid looping.
            //         child_tx.source_transaction_id._update_state(('authorized',), target_state, '')
            //         child_tx.source_transaction_id._log_received_message()
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
            //         "Skipped the update of transaction %(ref)s as it is already in state %(state)s.",
            //         {'ref': tx.reference, 'state': tx.state},
            //     )
            // for tx in txs_wrong_state:
            //     _logger.warning(
            //         "Refused to update transaction %(ref)s from state %(tx_state)s to state"
            //         " %(target_state)s; allowed source states are: %(allowed_states)s.",
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

        protected async Task<PaymentTransaction> ValidateAmountInternalAsync(object payment_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _validate_amount(self, payment_data):
            // """Ensure that the transaction's amount and currency match the ones from the payment data.
            // 
            // Validation transactions and transactions for which providers opt out of the amount check are
            // skipped.
            // 
            // :param dict payment_data: The payment data sent by the provider.
            // :return: None
            // """
            // self.ensure_one()
            // 
            // if self.operation == 'validation':
            //     return  # Skip validation for $0-auth transactions.
            // 
            // amount_data = self._extract_amount_data(payment_data)
            // if amount_data is None:
            //     return  # Skip validation for transactions where the provider opts out of amount check.
            // 
            // amount = amount_data['amount']
            // currency_code = amount_data['currency_code']
            // precision_digits = amount_data.get('precision_digits')
            // 
            // if not amount or not currency_code:
            //     error_message = _("The amount or currency is missing from the payment data.")
            //     self._set_error(error_message)
            //     return
            // 
            // # Negate the amount for refunds, as refunds have a negative amount in Odoo, but all
            // # providers send a positive one.
            // if self.operation == 'refund':
            //     amount = -amount
            // tx_amount = self.amount if precision_digits is None else float_round(
            //     self.amount, precision_digits=precision_digits, rounding_method='DOWN'
            // )
            // if self.currency_id.compare_amounts(amount, tx_amount) != 0:
            //     error_message = _(
            //         "The amount from the payment data doesn't match the one from the transaction."
            //     )
            //     self._set_error(error_message)
            //     return
            // 
            // if currency_code != self.currency_id.name:
            //     error_message = _(
            //         "The currency from the payment data doesn't match the one from the transaction."
            //     )
            //     self._set_error(error_message)
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
            // :returns: The formatted phone number.
            // :rtype: str
            // :raise ValidationError: If the phone number is missing or incorrect.
            // """
            // if not phone and self.tokenize:
            //     raise ValidationError(_("The phone number is missing."))
            // 
            // try:
            //     phone = self._phone_format(
            //         number=phone, country=self.partner_country_id, raise_exception=self.tokenize
            //     )
            // except Exception:
            //     raise ValidationError(_("The phone number is invalid."))
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
            // """Check the state of the transaction and request to have them voided."""
            // payment_utils.check_rights_on_recordset(self)
            // 
            // if any(tx.state != 'authorized' for tx in self):
            //     raise ValidationError(_("Only authorized transactions can be voided."))
            // 
            // voided_txs_sudo = self.env['payment.transaction'].sudo()
            // for tx in self:
            //     # Consider all the confirmed partial capture (same operation as parent) child txs.
            //     captured_amount = sum(child_tx.amount for child_tx in tx.child_transaction_ids.filtered(
            //         lambda t: t.state == 'done' and t.operation == tx.operation
            //     ))
            //     # In sudo mode to read on provider fields.
            //     voided_txs_sudo |= tx.sudo().with_context(payment_backend_action=True)._void(amount_to_void=tx.amount - captured_amount)
            // return voided_txs_sudo._build_action_feedback_notification()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PaymentTransaction> VoidInternalAsync(object amount_to_void)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py) ---
            // def _void(self, amount_to_void=None):
            // """Void the authorized amount.
            // 
            // Note: `self.ensure_one()`
            // 
            // :param float amount_to_void: The amount to be voided.
            // :return: The void transaction created to process the void request.
            // :rtype: payment.transaction
            // """
            // self.ensure_one()
            // self._ensure_provider_is_not_disabled()
            // 
            // void_tx = self._create_child_transaction(amount_to_void or self.amount)
            // void_tx._log_sent_message()
            // try:
            //     void_tx._send_void_request()
            // except ValidationError as e:
            //     void_tx._set_error(str(e))
            // return void_tx
            */
            return default;
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
            // return_url_params = url_encode({'provider_id': str(self.provider_id.id)})
            // return_url = f'{urls.urljoin(base_url, return_route)}?{return_url_params}'
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
            //         payload['hostedCheckoutSpecificInput']['paymentProductFilters'] = {
            //             'restrictTo': {
            //                 'groups': ['cards'],
            //             },
            //         }
            // 
            // checkout_session_data = self._send_api_request('POST', 'hostedcheckouts', json=payload)
            // 
            // return checkout_session_data
            */
            return default;
        }

        protected async Task<PaymentTransaction> WorldlineExtractPaymentMethodDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_worldline, FILE: payment_transaction.py) ---
            // def _worldline_extract_payment_method_data(payment_data):
            // payment_output = payment_data.get('paymentOutput', {})
            // if 'cardPaymentMethodSpecificOutput' in payment_output:
            //     payment_method_data = payment_output['cardPaymentMethodSpecificOutput']
            // else:
            //     payment_method_data = payment_output.get('redirectPaymentMethodSpecificOutput', {})
            // return payment_method_data
            */
            return default;
        }

        protected async Task<PaymentTransaction> XenditCreateChargeInternalAsync(object token_ref, Guid auth_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment_xendit, FILE: payment_transaction.py) ---
            // def _xendit_create_charge(self, token_ref, auth_id=None):
            // """ Create a charge on Xendit using the `credit_card_charges` endpoint.
            // 
            // :param str token_ref: The reference of the Xendit token to use to make the payment.
            // :param str auth_id: The authentication id to use to make the payment.
            // :return: None
            // """
            // payload = {
            //     'token_id': token_ref,
            //     'external_id': self.reference,
            //     'amount': self._get_rounded_amount(),
            //     'currency': self.currency_id.name,
            // }
            // if auth_id:  # The payment goes through an authentication.
            //     payload['authentication_id'] = auth_id
            // 
            // if self.token_id or self.tokenize:  # The tx uses a token or is tokenized.
            //     payload['is_recurring'] = True  # Ensure that next payments will not require 3DS.
            // 
            // try:
            //     charge_payment_data = self._send_api_request(
            //         'POST', 'credit_card_charges', json=payload
            //     )
            // except ValidationError as error:
            //     self._set_error(str(error))
            // else:
            //     self._process('xendit', charge_payment_data)
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
            // redirect_url = urljoin(base_url, XenditController._return_url)
            // access_token = payment_utils.generate_access_token(self.reference, self.amount)
            // success_url_params = urls.url_encode({
            //     'tx_ref': self.reference,
            //     'access_token': access_token,
            //     'success': 'true',
            // })
            // payload = {
            //     'external_id': self.reference,
            //     'amount': self._get_rounded_amount(),
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
            // if phone := self.partner_id.phone:
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
    }
}