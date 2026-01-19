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
    [Module("PointOfSale", Category = "Sales", Depends = new[] { "resource", "stock_account", "barcodes", "html_editor", "digest", "phone_validation", "partner_autocomplete", "iot_base", "google_address_autocomplete" })]
    public partial class PosPaymentAppService : GenericApplicationService<PosPayment>, IPosPaymentAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosPaymentAppService(IRepository<PosPayment, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<PosPayment> AdyenCaptureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_payment.py) ---
            // def _adyen_capture(self):
            // data = {
            //     'originalReference': self.transaction_id,
            //     'modificationAmount': {
            //         'value': int(self.amount * 10**self.currency_id.decimal_places),
            //         'currency': self.currency_id.name,
            //     },
            //     'merchantAccount': self.payment_method_id.adyen_merchant_account,
            // }
            // 
            // return self.payment_method_id.proxy_adyen_request(data, 'capture')
            */
            return default;
        }

        protected async Task<PosPayment> CheckAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py) ---
            // def _check_amount(self):
            // for payment in self:
            //     if payment.pos_order_id.state == 'done' or payment.pos_order_id.account_move:
            //         raise ValidationError(_('You cannot edit a payment for a posted order.'))
            */
            return default;
        }

        protected async Task<PosPayment> CheckPaymentMethodIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py) ---
            // def _check_payment_method_id(self):
            // for payment in self:
            //     if payment.payment_method_id not in payment.session_id.config_id.payment_method_ids:
            //         raise ValidationError(_('The payment method selected is not allowed in the config of the POS session.'))
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment.py) ---
            // def _check_payment_method_id(self):
            // bypass_check_payments = self.filtered('payment_method_id.is_online_payment')
            // if any(payment.payment_method_id != payment.pos_order_id.online_payment_method_id for payment in bypass_check_payments):
            //     # An online payment must always be saved for the POS, even if the online payment method is no longer configured/allowed in the pos.config, because in any case it is saved by account_payment and payment modules.
            //     _logger.warning("Allow to save a POS online payment with an unexpected online payment method")
            // 
            // super(PosPayment, self - bypass_check_payments)._check_payment_method_id()
            */
            return default;
        }

        protected async Task<PosPayment> ComputeCashierInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_hr, FILE: pos_payment.py) ---
            // def _compute_cashier(self):
            // for order in self:
            //     if order.employee_id:
            //         order.cashier = order.employee_id.name
            //     else:
            //         order.cashier = order.user_id.name
            */
            return default;
        }

        protected async Task<PosPayment> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py) ---
            // def _compute_display_name(self):
            // for payment in self:
            //     if payment.name:
            //         payment.display_name = f'{payment.name} {formatLang(self.env, payment.amount, currency_obj=payment.currency_id)}'
            //     else:
            //         payment.display_name = formatLang(self.env, payment.amount, currency_obj=payment.currency_id)
            */
            return default;
        }

        public override async Task<PosPayment> CreateAsync(PosPayment entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment.py) ---
            // def create(self, vals_list):
            // online_account_payments_by_pm = {}
            // for vals in vals_list:
            //     pm_id = vals['payment_method_id']
            //     if pm_id not in online_account_payments_by_pm:
            //         online_account_payments_by_pm[pm_id] = set()
            //     online_account_payments_by_pm[pm_id].add(vals.get('online_account_payment_id') or None)
            // 
            // opms_read_id = self.env['pos.payment.method'].search_read(['&', ('id', 'in', list(online_account_payments_by_pm.keys())), ('is_online_payment', '=', True)], ["id"])
            // opms_id = {opm_read_id['id'] for opm_read_id in opms_read_id}
            // online_account_payments_to_check_id = set()
            // 
            // for pm_id, oaps_id in online_account_payments_by_pm.items():
            //     if pm_id in opms_id:
            //         if None in oaps_id:
            //             raise UserError(_("Cannot create a POS online payment without an accounting payment."))
            //         else:
            //             online_account_payments_to_check_id.update(oaps_id)
            //     elif any(oaps_id):
            //         raise UserError(_("Cannot create a POS payment with a not online payment method and an online accounting payment."))
            // 
            // if online_account_payments_to_check_id:
            //     valid_oap_amount = self.env['account.payment'].search_count([('id', 'in', list(online_account_payments_to_check_id))])
            //     if valid_oap_amount != len(online_account_payments_to_check_id):
            //         raise UserError(_("Cannot create a POS online payment without an accounting payment."))
            // 
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<PosPayment> CreatePaymentMovesInternalAsync(object is_reverse)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py) ---
            // def _create_payment_moves(self, is_reverse=False):
            // result = self.env['account.move']
            // change_payment = self.filtered(lambda p: p.is_change and p.payment_method_id.type == 'cash')
            // payment_to_change = self.filtered(lambda p: not p.is_change and p.payment_method_id.type == 'cash')[:1]
            // for payment in self - change_payment:
            //     order = payment.pos_order_id
            //     payment_method = payment.payment_method_id
            //     if payment_method.type == 'pay_later' or float_is_zero(payment.amount, precision_rounding=order.currency_id.rounding):
            //         continue
            //     accounting_partner = self.env["res.partner"]._find_accounting_partner(payment.partner_id)
            //     pos_session = order.session_id
            //     journal = pos_session.config_id.journal_id
            //     if change_payment and payment == payment_to_change:
            //         pos_payment_ids = payment.ids + change_payment.ids
            //         payment_amount = payment.amount + change_payment.amount
            //     else:
            //         pos_payment_ids = payment.ids
            //         payment_amount = payment.amount
            //     payment_move = self.env['account.move'].with_context(default_journal_id=journal.id).create({
            //         'journal_id': journal.id,
            //         'date': fields.Date.context_today(order, order.date_order),
            //         'ref': _('Invoice payment for %(order)s (%(account_move)s) using %(payment_method)s', order=order.name, account_move=order.account_move.name, payment_method=payment_method.name),
            //         'pos_payment_ids': pos_payment_ids,
            //     })
            //     result |= payment_move
            //     payment.write({'account_move_id': payment_move.id})
            //     amounts = pos_session._update_amounts({'amount': 0, 'amount_converted': 0}, {'amount': payment_amount}, payment.payment_date)
            //     credit_line_vals = pos_session._credit_amounts({
            //         'account_id': accounting_partner.with_company(order.company_id).property_account_receivable_id.id,  # The field being company dependant, we need to make sure the right value is received.
            //         'partner_id': accounting_partner.id,
            //         'move_id': payment_move.id,
            //         'no_followup': False,
            //     }, amounts['amount'], amounts['amount_converted'])
            //     is_split_transaction = payment.payment_method_id.split_transactions
            //     if is_split_transaction and is_reverse:
            //         reversed_move_receivable_account_id = accounting_partner.with_company(order.company_id).property_account_receivable_id.id
            //     elif is_reverse:
            //         reversed_move_receivable_account_id = payment.payment_method_id.receivable_account_id.id or self.company_id.account_default_pos_receivable_account_id.id
            //     else:
            //         reversed_move_receivable_account_id = self.company_id.account_default_pos_receivable_account_id.id
            //     debit_line_vals = pos_session._debit_amounts({
            //         'account_id': reversed_move_receivable_account_id,
            //         'move_id': payment_move.id,
            //         'partner_id': accounting_partner.id if is_split_transaction and is_reverse else False,
            //         'no_followup': False,
            //     }, amounts['amount'], amounts['amount_converted'])
            //     self.env['account.move.line'].create([credit_line_vals, debit_line_vals])
            //     payment_move._post()
            // return result
            */
            return default;
        }

        protected async Task<PosPayment> GetReceivableLinesForInvoiceReconciliationInternalAsync(object receivable_account)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py) ---
            // def _get_receivable_lines_for_invoice_reconciliation(self, receivable_account):
            // """
            // If this payment is linked to an account.move, this returns the corresponding receivable lines
            // that should be reconciled with the invoice's receivable lines.
            // The introduced heuristics here is important for cases where the pos receivable account is the same
            // as the receivable account of the customer.
            // 
            // - positive payment -> negative balance lines
            // - negative payment -> positive balance lines
            // """
            // 
            // result = self.env['account.move.line']
            // for payment in self:
            //     if not payment.account_move_id:
            //         continue
            // 
            //     currency = payment.currency_id
            //     is_positive_amount = currency.compare_amounts(payment.amount, 0) > 0
            // 
            //     for line in payment.account_move_id.line_ids:
            //         if currency.compare_amounts(line.balance, 0) == 0 or line.account_id != receivable_account or line.reconciled:
            //             continue
            // 
            //         if is_positive_amount:
            //             if currency.compare_amounts(line.balance, 0) < 0:
            //                 result |= line
            //         else:
            //             if currency.compare_amounts(line.balance, 0) > 0:
            //                 result |= line
            // 
            // return result
            */
            return default;
        }

        protected async Task<PosPayment> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('pos_order_id', 'in', [order['id'] for order in data['pos.order']])]
            */
            return default;
        }

        protected async Task<PosPayment> UpdatePaymentLineForTipInternalAsync(object tip_amount)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_payment.py) ---
            // def _update_payment_line_for_tip(self, tip_amount):
            // """Inherit this method to perform reauthorization or capture on electronic payment."""
            // self.ensure_one()
            // self.write({
            //     "amount": self.amount + tip_amount,
            // })
            --- ODOO METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_payment.py) ---
            // def _update_payment_line_for_tip(self, tip_amount):
            // """Capture the payment when a tip is set."""
            // res = super(PosPayment, self)._update_payment_line_for_tip(tip_amount)
            // if self.payment_method_id.use_payment_terminal == 'adyen':
            //     self._adyen_capture()
            // return res
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, PosPayment entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment.py) ---
            // def write(self, vals):
            // if vals.keys() & ('amount', 'payment_date', 'payment_method_id', 'online_account_payment_id', 'pos_order_id') and any(payment.online_account_payment_id or payment.payment_method_id.is_online_payment for payment in self):
            //     raise UserError(_("Cannot edit a POS online payment essential data."))
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}