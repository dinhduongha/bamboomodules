using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("point_of_sale", Depends = new[] { "stock_account", "barcodes", "web_editor", "digest", "phone_validation" })]
    public class PosBusMixinAppService : ApplicationService, IPosBusMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public PosBusMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AccumulateAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _accumulate_amounts(self, data):
            // # Accumulate the amounts for each accounting lines group
            // # Each dict maps `key` -> `amounts`, where `key` is the group key.
            // # E.g. `combine_receivables_bank` is derived from pos.payment records
            // # in the self.order_ids with group key of the `payment_method_id`
            // # field of the pos.payment record.
            // AccountTax = self.env['account.tax']
            // amounts = lambda: {'amount': 0.0, 'amount_converted': 0.0}
            // tax_amounts = lambda: {'amount': 0.0, 'amount_converted': 0.0, 'base_amount': 0.0, 'base_amount_converted': 0.0}
            // split_receivables_bank = defaultdict(amounts)
            // split_receivables_cash = defaultdict(amounts)
            // split_receivables_pay_later = defaultdict(amounts)
            // combine_receivables_bank = defaultdict(amounts)
            // combine_receivables_cash = defaultdict(amounts)
            // combine_receivables_pay_later = defaultdict(amounts)
            // combine_invoice_receivables = defaultdict(amounts)
            // split_invoice_receivables = defaultdict(amounts)
            // sales = defaultdict(amounts)
            // taxes = defaultdict(tax_amounts)
            // stock_expense = defaultdict(amounts)
            // stock_return = defaultdict(amounts)
            // stock_output = defaultdict(amounts)
            // rounding_difference = {'amount': 0.0, 'amount_converted': 0.0}
            // # Track the receivable lines of the order's invoice payment moves for reconciliation
            // # These receivable lines are reconciled to the corresponding invoice receivable lines
            // # of this session's move_id.
            // combine_inv_payment_receivable_lines = defaultdict(lambda: self.env['account.move.line'])
            // split_inv_payment_receivable_lines = defaultdict(lambda: self.env['account.move.line'])
            // pos_receivable_account = self.company_id.account_default_pos_receivable_account_id
            // currency_rounding = self.currency_id.rounding
            // closed_orders = self._get_closed_orders()
            // for order in closed_orders:
            //     order_is_invoiced = order.is_invoiced
            //     for payment in order.payment_ids:
            //         amount = payment.amount
            //         if float_is_zero(amount, precision_rounding=currency_rounding):
            //             continue
            //         date = payment.payment_date
            //         payment_method = payment.payment_method_id
            //         is_split_payment = payment.payment_method_id.split_transactions
            //         payment_type = payment_method.type
            // 
            //         # If not pay_later, we create the receivable vals for both invoiced and uninvoiced orders.
            //         #   Separate the split and aggregated payments.
            //         # Moreover, if the order is invoiced, we create the pos receivable vals that will balance the
            //         # pos receivable lines from the invoice payments.
            //         if payment_type != 'pay_later':
            //             if is_split_payment and payment_type == 'cash':
            //                 split_receivables_cash[payment] = self._update_amounts(split_receivables_cash[payment], {'amount': amount}, date)
            //             elif not is_split_payment and payment_type == 'cash':
            //                 combine_receivables_cash[payment_method] = self._update_amounts(combine_receivables_cash[payment_method], {'amount': amount}, date)
            //             elif is_split_payment and payment_type == 'bank':
            //                 split_receivables_bank[payment] = self._update_amounts(split_receivables_bank[payment], {'amount': amount}, date)
            //             elif not is_split_payment and payment_type == 'bank':
            //                 combine_receivables_bank[payment_method] = self._update_amounts(combine_receivables_bank[payment_method], {'amount': amount}, date)
            // 
            //             # Create the vals to create the pos receivables that will balance the pos receivables from invoice payment moves.
            //             if order_is_invoiced:
            //                 if is_split_payment:
            //                     split_inv_payment_receivable_lines[payment] |= payment.account_move_id.line_ids.filtered(lambda line: line.account_id == pos_receivable_account)
            //                     split_invoice_receivables[payment] = self._update_amounts(split_invoice_receivables[payment], {'amount': payment.amount}, order.date_order)
            //                 else:
            //                     combine_inv_payment_receivable_lines[payment_method] |= payment.account_move_id.line_ids.filtered(lambda line: line.account_id == pos_receivable_account)
            //                     combine_invoice_receivables[payment_method] = self._update_amounts(combine_invoice_receivables[payment_method], {'amount': payment.amount}, order.date_order)
            // 
            //         # If pay_later, we create the receivable lines.
            //         #   if split, with partner
            //         #   Otherwise, it's aggregated (combined)
            //         # But only do if order is *not* invoiced because no account move is created for pay later invoice payments.
            //         if payment_type == 'pay_later' and not order_is_invoiced:
            //             if is_split_payment:
            //                 split_receivables_pay_later[payment] = self._update_amounts(split_receivables_pay_later[payment], {'amount': amount}, date)
            //             elif not is_split_payment:
            //                 combine_receivables_pay_later[payment_method] = self._update_amounts(combine_receivables_pay_later[payment_method], {'amount': amount}, date)
            // 
            //     if not order_is_invoiced:
            //         base_lines = order.with_context(linked_to_pos=True)._prepare_tax_base_line_values()
            //         AccountTax._add_tax_details_in_base_lines(base_lines, order.company_id)
            //         AccountTax._round_base_lines_tax_details(base_lines, order.company_id)
            //         AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, order.company_id, include_caba_tags=True)
            //         tax_results = AccountTax._prepare_tax_lines(base_lines, order.company_id)
            //         total_amount_currency = 0.0
            //         for base_line, to_update in tax_results['base_lines_to_update']:
            //             # Combine sales/refund lines
            //             sale_key = (
            //                 # account
            //                 base_line['account_id'].id,
            //                 # sign
            //                 -1 if base_line['is_refund'] else 1,
            //                 # for taxes
            //                 tuple(base_line['record'].tax_ids_after_fiscal_position.flatten_taxes_hierarchy().ids),
            //                 tuple(base_line['tax_tag_ids'].ids),
            //                 base_line['product_id'].id if self.config_id.is_closing_entry_by_product else False,
            //             )
            //             total_amount_currency += to_update['amount_currency']
            //             sales[sale_key] = self._update_amounts(
            //                 sales[sale_key],
            //                 {
            //                     'amount': to_update['amount_currency'],
            //                     'amount_converted': to_update['balance'],
            //                 },
            //                 order.date_order,
            //             )
            //             if self.config_id.is_closing_entry_by_product:
            //                 sales[sale_key] = self._update_quantities(sales[sale_key], base_line['quantity'])
            // 
            //         # Combine tax lines
            //         for tax_line in tax_results['tax_lines_to_add']:
            //             tax_key = (
            //                 tax_line['account_id'],
            //                 tax_line['tax_repartition_line_id'],
            //                 tuple(tax_line['tax_tag_ids'][0][2]),
            //             )
            //             total_amount_currency += tax_line['amount_currency']
            //             taxes[tax_key] = self._update_amounts(
            //                 taxes[tax_key],
            //                 {
            //                     'amount': tax_line['amount_currency'],
            //                     'amount_converted': tax_line['balance'],
            //                     'base_amount': tax_line['tax_base_amount']
            //                 },
            //                 order.date_order,
            //             )
            // 
            //         if self.config_id.cash_rounding:
            //             diff = order.amount_paid + total_amount_currency
            //             rounding_difference = self._update_amounts(rounding_difference, {'amount': diff}, order.date_order)
            // 
            //         # Increasing current partner's customer_rank
            //         partners = (order.partner_id | order.partner_id.commercial_partner_id)
            //         partners._increase_rank('customer_rank')
            // 
            // if self.company_id.anglo_saxon_accounting:
            //     all_picking_ids = self.order_ids.filtered(lambda p: not p.is_invoiced and not p.shipping_date).picking_ids.ids + self.picking_ids.filtered(lambda p: not p.pos_order_id).ids
            //     if all_picking_ids:
            //         # Combine stock lines
            //         stock_move_sudo = self.env['stock.move'].sudo()
            //         stock_moves = stock_move_sudo.search([
            //             ('picking_id', 'in', all_picking_ids),
            //             ('company_id.anglo_saxon_accounting', '=', True),
            //             ('product_id.categ_id.property_valuation', '=', 'real_time'),
            //             ('product_id.is_storable', '=', True),
            //         ])
            //         for stock_moves_split in self.env.cr.split_for_in_conditions(stock_moves.ids):
            //             stock_moves_batch = stock_move_sudo.browse(stock_moves_split)
            //             candidates = stock_moves_batch\
            //                 .filtered(lambda m: not bool(m.origin_returned_move_id and sum(m.stock_valuation_layer_ids.mapped('quantity')) >= 0))\
            //                 .mapped('stock_valuation_layer_ids')
            //             for move in stock_moves_batch.with_context(candidates_prefetch_ids=candidates._prefetch_ids):
            //                 exp_key = move.product_id._get_product_accounts()['expense']
            //                 out_key = move.product_id.categ_id.property_stock_account_output_categ_id
            //                 signed_product_qty = move.product_qty
            //                 if move._is_in():
            //                     signed_product_qty *= -1
            //                 amount = signed_product_qty * move.product_id._compute_average_price(0, move.quantity, move)
            //                 stock_expense[exp_key] = self._update_amounts(stock_expense[exp_key], {'amount': amount}, move.picking_id.date, force_company_currency=True)
            //                 if move._is_in():
            //                     stock_return[out_key] = self._update_amounts(stock_return[out_key], {'amount': amount}, move.picking_id.date, force_company_currency=True)
            //                 else:
            //                     stock_output[out_key] = self._update_amounts(stock_output[out_key], {'amount': amount}, move.picking_id.date, force_company_currency=True)
            // MoveLine = self.env['account.move.line'].with_context(check_move_validity=False, skip_invoice_sync=True)
            // 
            // data.update({
            //     'taxes':                               taxes,
            //     'sales':                               sales,
            //     'stock_expense':                       stock_expense,
            //     'split_receivables_bank':              split_receivables_bank,
            //     'combine_receivables_bank':            combine_receivables_bank,
            //     'split_receivables_cash':              split_receivables_cash,
            //     'combine_receivables_cash':            combine_receivables_cash,
            //     'combine_invoice_receivables':         combine_invoice_receivables,
            //     'split_receivables_pay_later':         split_receivables_pay_later,
            //     'combine_receivables_pay_later':       combine_receivables_pay_later,
            //     'stock_return':                        stock_return,
            //     'stock_output':                        stock_output,
            //     'combine_inv_payment_receivable_lines': combine_inv_payment_receivable_lines,
            //     'rounding_difference':                 rounding_difference,
            //     'MoveLine':                            MoveLine,
            //     'split_invoice_receivables': split_invoice_receivables,
            //     'split_inv_payment_receivable_lines': split_inv_payment_receivable_lines,
            // })
            // return data
            */
            return default;
        }

        public async Task<TEntity> ActionPosConfigModalEditAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def action_pos_config_modal_edit(self):
            // return {
            //     'view_mode': 'form',
            //     'res_model': 'pos.config',
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'res_id': self.id,
            //     'context': {'pos_config_open_modal': True},
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_pos_order_cancel(self):
            // cancellable_orders = self.filtered(lambda order: order.state == 'draft')
            // cancellable_orders.write({'state': 'cancel'})
            // return {
            //     'pos.order': cancellable_orders.read(self._load_pos_data_fields(self.config_id.ids[0]), load=False)
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_pos_order_invoice(self):
            // if len(self.company_id) > 1:
            //     raise UserError(_("You cannot invoice orders belonging to different companies."))
            // self.write({'to_invoice': True})
            // if self.company_id.anglo_saxon_accounting and self.session_id.update_stock_at_closing and self.session_id.state != 'closed':
            //     self._create_order_picking()
            // return self._generate_pos_order_invoice()
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderPaidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_pos_order_paid(self):
            // self.ensure_one()
            // 
            // # TODO: add support for mix of cash and non-cash payments when both cash_rounding and only_round_cash_method are True
            // if not self.config_id.cash_rounding \
            //    or self.config_id.only_round_cash_method \
            //    and not any(p.payment_method_id.is_cash_count for p in self.payment_ids):
            //     total = self.amount_total
            // else:
            //     total = float_round(self.amount_total, precision_rounding=self.config_id.rounding_method.rounding, rounding_method=self.config_id.rounding_method.rounding_method)
            // 
            // isPaid = float_is_zero(total - self.amount_paid, precision_rounding=self.currency_id.rounding)
            // 
            // if not isPaid and not self.config_id.cash_rounding:
            //     raise UserError(_("Order %s is not fully paid.", self.name))
            // elif not isPaid and self.config_id.cash_rounding:
            //     currency = self.currency_id
            //     if self.config_id.rounding_method.rounding_method == "HALF-UP":
            //         maxDiff = currency.round(self.config_id.rounding_method.rounding / 2)
            //     else:
            //         maxDiff = currency.round(self.config_id.rounding_method.rounding)
            // 
            //     diff = currency.round(self.amount_total - self.amount_paid)
            //     if not abs(diff) <= maxDiff:
            //         raise UserError(_("Order %s is not fully paid.", self.name))
            // 
            // self.write({'state': 'paid'})
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionCloseAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def action_pos_session_close(self, balancing_account=False, amount_to_balance=0, bank_payment_method_diffs=None):
            // bank_payment_method_diffs = bank_payment_method_diffs or {}
            // # Session without cash payment method will not have a cash register.
            // # However, there could be other payment methods, thus, session still
            // # needs to be validated.
            // return self._validate_session(balancing_account, amount_to_balance, bank_payment_method_diffs)
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionClosingControlAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def action_pos_session_closing_control(self, balancing_account=False, amount_to_balance=0, bank_payment_method_diffs=None):
            // bank_payment_method_diffs = bank_payment_method_diffs or {}
            // for session in self:
            //     if any(order.state == 'draft' for order in self.get_session_orders()):
            //         raise UserError(_("You cannot close the POS when orders are still in draft"))
            //     if session.state == 'closed':
            //         raise UserError(_('This session is already closed.'))
            //     stop_at = self.stop_at or fields.Datetime.now()
            //     session.write({'state': 'closing_control', 'stop_at': stop_at})
            //     if not session.config_id.cash_control:
            //         return session.action_pos_session_close(balancing_account, amount_to_balance, bank_payment_method_diffs)
            //     # If the session is in rescue, we only compute the payments in the cash register
            //     # It is not yet possible to close a rescue session through the front end, see `close_session_from_ui`
            //     if session.rescue and session.config_id.cash_control:
            //         default_cash_payment_method_id = self.payment_method_ids.filtered(lambda pm: pm.type == 'cash')[0]
            //         orders = self._get_closed_orders()
            //         total_cash = sum(
            //             orders.payment_ids.filtered(lambda p: p.payment_method_id == default_cash_payment_method_id).mapped('amount')
            //         ) + self.cash_register_balance_start
            // 
            //         session.cash_register_balance_end_real = total_cash
            // 
            //     return session.action_pos_session_validate(balancing_account, amount_to_balance, bank_payment_method_diffs)
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def action_pos_session_open(self):
            // # we only open sessions that haven't already been opened
            // for session in self.filtered(lambda session: session.state == 'opening_control'):
            //     values = {}
            //     if session.config_id.cash_control and not session.rescue:
            //         last_session = self.search([('config_id', '=', session.config_id.id), ('id', '!=', session.id)], limit=1)
            //         session.cash_register_balance_start = last_session.cash_register_balance_end_real  # defaults to 0 if lastsession is empty
            //     session.write(values)
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionValidateAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def action_pos_session_validate(self, balancing_account=False, amount_to_balance=0, bank_payment_method_diffs=None):
            // bank_payment_method_diffs = bank_payment_method_diffs or {}
            // return self.action_pos_session_close(balancing_account, amount_to_balance, bank_payment_method_diffs)
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_send_mail(self):
            // template_id = self.env['ir.model.data']._xmlid_to_res_id('point_of_sale.pos_email_marketing_template', raise_if_not_found=False)
            // return {
            //     'name': _('Send Email'),
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'type': 'ir.actions.act_window',
            //     'context': {'default_composition_mode': 'mass_mail', 'default_template_id': template_id},
            //     'target': 'new'
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionSendReceiptAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket_image, object basic_image) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_send_receipt(self, email, ticket_image, basic_image):
            // self.env['mail.mail'].sudo().create(self._prepare_mail_values(email, ticket_image, basic_image)).send()
            // self.email = email
            */
            return default;
        }

        public async Task<TEntity> ActionShowPaymentsListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def action_show_payments_list(self):
            // return {
            //     'name': _('Payments'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'pos.payment',
            //     'view_mode': 'list,form',
            //     'domain': self._get_captured_payments_domain(),
            //     'context': {'search_default_group_by_payment_method': 1}
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionStockPickingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_stock_picking(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('stock.action_picking_tree_ready')
            // action['display_name'] = _('Pickings')
            // action['context'] = {}
            // action['domain'] = [('id', 'in', self.picking_ids.ids)]
            // return action
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def action_stock_picking(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('stock.action_picking_tree_ready')
            // action['display_name'] = _('Pickings')
            // action['context'] = {}
            // action['domain'] = [('id', 'in', self.picking_ids.ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionToOpenUiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _action_to_open_ui(self):
            // if not self.current_session_id:
            //     self.env['pos.session'].create({'user_id': self.env.uid, 'config_id': self.id})
            // path = '/pos/web' if self._force_http() else '/pos/ui'
            // pos_url = path + '?config_id=%d&from_backend=True' % self.id
            // debug = request and request.session.debug
            // if debug:
            //     pos_url += '&debug=%s' % debug
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': pos_url,
            //     'target': 'self',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_view_invoice(self):
            // return {
            //     'name': _('Customer Invoice'),
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('account.view_move_form').id,
            //     'res_model': 'account.move',
            //     'context': "{'move_type':'out_invoice'}",
            //     'type': 'ir.actions.act_window',
            //     'res_id': self.account_move.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def action_view_order(self):
            // return {
            //     'name': _('Orders'),
            //     'res_model': 'pos.order',
            //     'view_mode': 'list,form',
            //     'views': [
            //         (self.env.ref('point_of_sale.view_pos_order_tree_no_session_id').id, 'list'),
            //         (self.env.ref('point_of_sale.view_pos_pos_form').id, 'form'),
            //         ],
            //     'type': 'ir.actions.act_window',
            //     'domain': [('session_id', 'in', self.ids)],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewRefundOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_view_refund_orders(self):
            // return {
            //     'name': _('Refund Orders'),
            //     'view_mode': 'list,form',
            //     'res_model': 'pos.order',
            //     'type': 'ir.actions.act_window',
            //     'domain': [('id', 'in', self.mapped('lines.refund_orderline_ids.order_id').ids)],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewRefundedOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_view_refunded_order(self):
            // return {
            //     'name': _('Refunded Order'),
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('point_of_sale.view_pos_pos_form').id,
            //     'res_model': 'pos.order',
            //     'type': 'ir.actions.act_window',
            //     'res_id': self.refunded_order_id.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> AddMailAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _add_mail_attachment(self, name, ticket, basic_ticket):
            // attachment = []
            // filename = 'Receipt-' + name + '.jpg'
            // receipt = self.env['ir.attachment'].create({
            //     'name': filename,
            //     'type': 'binary',
            //     'datas': ticket,
            //     'res_model': 'pos.order',
            //     'res_id': self.ids[0],
            //     'mimetype': 'image/jpeg',
            // })
            // attachment += [(4, receipt.id)]
            // if basic_ticket:
            //     filename = 'Receipt-' + name + '-1' + '.jpg'
            //     basic_receipt = self.env['ir.attachment'].create({
            //         'name': filename,
            //         'type': 'binary',
            //         'datas': basic_ticket,
            //         'res_model': 'pos.order',
            //         'res_id': self.ids[0],
            //         'mimetype': 'image/jpeg',
            //     })
            //     attachment += [(4, basic_receipt.id)]
            // 
            // 
            // if self.mapped('account_move'):
            //     report = self.env['ir.actions.report']._render_qweb_pdf("account.account_invoices", self.account_move.ids[0])
            //     filename = name + '.pdf'
            //     invoice = self.env['ir.attachment'].create({
            //         'name': filename,
            //         'type': 'binary',
            //         'datas': base64.b64encode(report[0]),
            //         'res_model': 'pos.order',
            //         'res_id': self.ids[0],
            //         'mimetype': 'application/x-pdf'
            //     })
            //     attachment += [(4, invoice.id)]
            // 
            // return attachment
            */
            return default;
        }

        public async Task<TEntity> AddPaymentAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def add_payment(self, data):
            // """Create a new payment for the order"""
            // self.ensure_one()
            // self.env['pos.payment'].create(data)
            // self.amount_paid = sum(self.payment_ids.mapped('amount'))
            */
            return default;
        }

        public async Task<TEntity> AddTrustedConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _add_trusted_config_id(self, config_id):
            // self.trusted_config_ids += config_id
            */
            return default;
        }

        public async Task<TEntity> AlertOldSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _alert_old_session(self):
            // # If the session is open for more then one week,
            // # log a next activity to close the session.
            // sessions = self.sudo().search([('start_at', '<=', (fields.datetime.now() - timedelta(days=7))), ('state', '!=', 'closed')])
            // for session in sessions:
            //     if self.env['mail.activity'].search_count([('res_id', '=', session.id), ('res_model', '=', 'pos.session')]) == 0:
            //         session.activity_schedule(
            //             'point_of_sale.mail_activity_old_session',
            //             user_id=session.user_id.id,
            //             note=_(
            //                 "Your PoS Session is open since %(date)s, we advise you to close it and to create a new one.",
            //                 date=session.start_at,
            //             )
            //         )
            */
            return default;
        }

        public async Task<TEntity> AmountConverterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object date, object round) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _amount_converter(self, amount, date, round):
            // # self should be single record as this method is only called in the subfunctions of self._validate_session
            // return self.currency_id._convert(amount, self.company_id.currency_id, self.company_id, date, round=round)
            */
            return default;
        }

        public async Task<TEntity> ApplyDiffOnAccountPaymentMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_payment, object payment_method, object diff_amount) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _apply_diff_on_account_payment_move(self, account_payment, payment_method, diff_amount):
            // diff_vals = self._get_diff_vals(payment_method.id, diff_amount, account_payment.outstanding_account_id)
            // if not diff_vals:
            //     return
            // source_vals, dest_vals = diff_vals
            // outstanding_line = account_payment.move_id.line_ids.filtered(lambda line: line.account_id.id == source_vals['account_id'])
            // new_balance = outstanding_line.balance + self._amount_converter(diff_amount, self.stop_at, False)
            // new_balance_compare_to_zero = self.currency_id.compare_amounts(new_balance, 0)
            // account_payment.move_id.button_draft()
            // account_payment.move_id.write({
            //     'line_ids': [
            //         Command.create(dest_vals),
            //         Command.update(outstanding_line.id, {
            //             'debit': new_balance_compare_to_zero > 0 and new_balance or 0.0,
            //             'credit': new_balance_compare_to_zero < 0 and -new_balance or 0.0
            //         })
            //     ]
            // })
            // account_payment.write({
            //     'amount': abs(new_balance),
            // })
            // account_payment.move_id.action_post()
            */
            return default;
        }

        public async Task<TEntity> ApplyInvoicePaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_reverse) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _apply_invoice_payments(self, is_reverse=False):
            // receivable_account = self.env["res.partner"]._find_accounting_partner(self.partner_id).with_company(self.company_id).property_account_receivable_id
            // payment_moves = self.payment_ids.sudo().with_company(self.company_id)._create_payment_moves(is_reverse)
            // if receivable_account.reconcile:
            //     invoice_receivables = self.account_move.line_ids.filtered(lambda line: line.account_id == receivable_account and not line.reconciled)
            //     if invoice_receivables:
            //         credit_line_ids = payment_moves._context.get('credit_line_ids', None)
            //         payment_receivables = payment_moves.mapped('line_ids').filtered(
            //             lambda line: (
            //                 (credit_line_ids and line.id in credit_line_ids) or
            //                 (not credit_line_ids and line.account_id == receivable_account and line.partner_id)
            //             )
            //         )
            //         (invoice_receivables | payment_receivables).sudo().with_company(self.company_id).reconcile()
            // return payment_moves
            */
            return default;
        }

        public async Task<TEntity> CannotCloseSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _cannot_close_session(self, bank_payment_method_diffs=None):
            // """
            // Add check in this method if you want to return or raise an error when trying to either post cash details
            // or close the session. Raising an error will always redirect the user to the back end.
            // It should return {'successful': False, 'message': str, 'redirect': bool} if we can't close the session
            // """
            // bank_payment_method_diffs = bank_payment_method_diffs or {}
            // if any(order.state == 'draft' for order in self.get_session_orders()):
            //     return {'successful': False, 'message': _("You cannot close the POS when orders are still in draft"), 'redirect': False}
            // if self.state == 'closed':
            //     return {
            //         'successful': False,
            //         'type': 'alert',
            //         'title': 'Session already closed',
            //         'message': _("The session has been already closed by another User. "
            //                     "All sales completed in the meantime have been saved in a "
            //                     "Rescue Session, which can be reviewed anytime and posted "
            //                     "to Accounting from Point of Sale's dashboard."),
            //         'redirect': True
            //     }
            // if bank_payment_method_diffs:
            //     no_loss_account = self.env['account.journal']
            //     no_profit_account = self.env['account.journal']
            //     for payment_method in self.env['pos.payment.method'].browse(bank_payment_method_diffs.keys()):
            //         journal = payment_method.journal_id
            //         compare_to_zero = self.currency_id.compare_amounts(bank_payment_method_diffs.get(payment_method.id), 0)
            //         if compare_to_zero == -1 and not journal.loss_account_id:
            //             no_loss_account |= journal
            //         elif compare_to_zero == 1 and not journal.profit_account_id:
            //             no_profit_account |= journal
            //     message = ''
            //     if no_loss_account:
            //         message += _("Need loss account for the following journals to post the lost amount: %s\n", ', '.join(no_loss_account.mapped('name')))
            //     if no_profit_account:
            //         message += _("Need profit account for the following journals to post the gained amount: %s", ', '.join(no_profit_account.mapped('name')))
            //     if message:
            //         return {'successful': False, 'message': message, 'redirect': False}
            */
            return default;
        }

        public async Task<TEntity> CheckBeforeCreatingNewSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_before_creating_new_session(self):
            // self._check_company_has_template()
            // self._check_pricelists()
            // self._check_company_payment()
            // self._check_currencies()
            // self._check_profit_loss_cash_journal()
            // self._check_payment_method_ids()
            */
            return default;
        }

        public async Task<TEntity> CheckCompaniesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_companies(self):
            // for config in self:
            //     if any(pricelist.company_id.id not in [False, config.company_id.id] for pricelist in config.available_pricelist_ids):
            //         raise ValidationError(_("The selected pricelists must belong to no company or the company of the point of sale."))
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyHasTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_company_has_template(self):
            // self.ensure_one()
            // if not self.company_has_template:
            //     raise ValidationError(_("No chart of account configured, go to the \"configuration / settings\" menu, and "
            //                             "install one from the Invoicing tab."))
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_company_payment(self):
            // for config in self:
            //     if self.env['pos.payment.method'].search_count([('id', 'in', config.payment_method_ids.ids), ('company_id', '!=', config.company_id.id)]):
            //         raise ValidationError(_("The payment methods for the point of sale %s must belong to its company.", self.name))
            */
            return default;
        }

        public async Task<TEntity> CheckCurrenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_currencies(self):
            // for config in self:
            //     if config.use_pricelist and config.pricelist_id and config.pricelist_id not in config.available_pricelist_ids:
            //         raise ValidationError(_("The default pricelist must be included in the available pricelists."))
            // 
            //     # Check if the config's payment methods are compatible with its currency
            //     for pm in config.payment_method_ids:
            //         if pm.journal_id and pm.journal_id.currency_id and pm.journal_id.currency_id != config.currency_id:
            //             raise ValidationError(_("All payment methods must be in the same currency as the Sales Journal or the company currency if that is not set."))
            // 
            //     if config.use_pricelist and any(config.available_pricelist_ids.mapped(lambda pricelist: pricelist.currency_id != config.currency_id)):
            //         raise ValidationError(_("All available pricelists must be in the same currency as the company or"
            //                                 " as the Sales Journal set on this point of sale if you use"
            //                                 " the Accounting application."))
            //     if config.invoice_journal_id.currency_id and config.invoice_journal_id.currency_id != config.currency_id:
            //         raise ValidationError(_("The invoice journal must be in the same currency as the Sales Journal or the company currency if that is not set."))
            */
            return default;
        }

        public async Task<TEntity> CheckCustomerDisplayTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_customer_display_type(self):
            // for config in self:
            //     if config.customer_display_type == 'proxy' and (not config.is_posbox or not config.proxy_ip):
            //         raise UserError(_("You must set the iot box's IP address to use an IoT-connected screen. You'll find the field under the 'IoT Box' option."))
            */
            return default;
        }

        public async Task<TEntity> CheckGroupsImpliedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_groups_implied(self):
            // for pos_config in self:
            //     for field_name in [f for f in pos_config._fields if f.startswith('group_')]:
            //         field = pos_config._fields[field_name]
            //         if field.type in ('boolean', 'selection') and hasattr(field, 'implied_group'):
            //             field_group_xmlids = getattr(field, 'group', 'base.group_user').split(',')
            //             field_groups = self.env['res.groups'].concat(*(self.env.ref(it) for it in field_group_xmlids))
            //             field_groups.write({'implied_ids': [(4, self.env.ref(field.implied_group).id)]})
            */
            return default;
        }

        public async Task<TEntity> CheckHeaderFooterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_header_footer(self, values):
            // if not self.env.is_admin() and {'is_header_or_footer', 'receipt_header', 'receipt_footer'} & values.keys():
            //     raise AccessError(_('Only administrators can edit receipt headers and footers'))
            */
            return default;
        }

        public async Task<TEntity> CheckIfNoDraftOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _check_if_no_draft_orders(self):
            // draft_orders = self.get_session_orders().filtered(lambda order: order.state == 'draft')
            // if draft_orders:
            //     raise UserError(_(
            //             'There are still orders in draft state in the session. '
            //             'Pay or cancel the following orders to validate the session:\n%s',
            //             ', '.join(draft_orders.mapped('name'))
            //     ))
            // return True
            */
            return default;
        }

        public async Task<TEntity> CheckInvoicesArePostedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _check_invoices_are_posted(self):
            // unposted_invoices = self._get_closed_orders().sudo().with_company(self.company_id).account_move.filtered(lambda x: x.state != 'posted')
            // if unposted_invoices:
            //     raise UserError(_(
            //         'You cannot close the POS when invoices are not posted.\nInvoices: %s',
            //         '\n'.join(f'{invoice.name} - {invoice.state}' for invoice in unposted_invoices)
            //     ))
            */
            return default;
        }

        public async Task<TEntity> CheckModulesToInstallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_modules_to_install(self):
            // # determine modules to install
            // expected = [
            //     fname[7:]           # 'module_account' -> 'account'
            //     for fname in self._fields
            //     if fname.startswith('module_')
            //     if any(pos_config[fname] for pos_config in self)
            // ]
            // if expected:
            //     STATES = ('installed', 'to install', 'to upgrade')
            //     modules = self.env['ir.module.module'].sudo().search([('name', 'in', expected)])
            //     modules = modules.filtered(lambda module: module.state not in STATES)
            //     if modules:
            //         modules.button_immediate_install()
            //         # just in case we want to do something if we install a module. (like a refresh ...)
            //         return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_payment_method_ids(self):
            // self.ensure_one()
            // if not self.payment_method_ids:
            //     raise ValidationError(
            //         _("You must have at least one payment method configured to launch a session.")
            //     )
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodIdsJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_payment_method_ids_journal(self):
            // for cash_method in self.payment_method_ids.filtered(lambda m: m.journal_id.type == 'cash'):
            //     if self.env['pos.config'].search_count([('id', '!=', self.id), ('payment_method_ids', 'in', cash_method.ids)], limit=1):
            //         raise ValidationError(_("This cash payment method is already used in another Point of Sale.\n"
            //                                 "A new cash payment method should be created for this Point of Sale."))
            //     if len(cash_method.journal_id.pos_payment_method_ids) > 1:
            //         raise ValidationError(_("You cannot use the same journal on multiples cash payment methods."))
            */
            return default;
        }

        public async Task<TEntity> CheckPosConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _check_pos_config(self):
            // onboarding_creation = self.env.context.get('onboarding_creation', False)
            // if not onboarding_creation and self.search_count([
            //         ('state', '!=', 'closed'),
            //         ('config_id', '=', self.config_id.id),
            //         ('rescue', '=', False)
            //     ]) > 1:
            //     raise ValidationError(_("Another session is already opened for this point of sale."))
            */
            return default;
        }

        public async Task<TEntity> CheckPricelistsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_pricelists(self):
            // self._check_companies()
            // self = self.sudo()
            // if self.pricelist_id.company_id and self.pricelist_id.company_id != self.company_id:
            //     raise ValidationError(
            //         _("The default pricelist must belong to no company or the company of the point of sale."))
            */
            return default;
        }

        public async Task<TEntity> CheckProfitLossCashJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_profit_loss_cash_journal(self):
            // if self.cash_control and self.payment_method_ids:
            //     for method in self.payment_method_ids:
            //         if method.is_cash_count and (not method.journal_id.loss_account_id or not method.journal_id.profit_account_id):
            //             raise ValidationError(_("You need a loss and profit account on your cash journal."))
            */
            return default;
        }

        public async Task<TEntity> CheckRoundingMethodStrategyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_rounding_method_strategy(self):
            // for config in self:
            //     if config.cash_rounding and config.rounding_method.strategy != 'add_invoice_line':
            //         selection_value = "Add a rounding line"
            //         for key, val in self.env["account.cash.rounding"]._fields["strategy"]._description_selection(config.env):
            //             if key == "add_invoice_line":
            //                 selection_value = val
            //                 break
            //         raise ValidationError(_(
            //             "The cash rounding strategy of the point of sale %(pos)s must be: '%(value)s'",
            //             pos=config.name,
            //             value=selection_value,
            //         ))
            */
            return default;
        }

        public async Task<TEntity> CheckStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _check_start_date(self):
            // for record in self:
            //     journal = record.config_id.journal_id
            //     company = journal.company_id
            //     start_date = record.start_at.date()
            //     violated_lock_dates = company._get_violated_lock_dates(start_date, True, journal)
            //     if violated_lock_dates:
            //         raise ValidationError(_("You cannot create a session starting before: %(lock_date_info)s",
            //                                 lock_date_info=self.env['res.company']._format_lock_dates(violated_lock_dates)))
            */
            return default;
        }

        public async Task<TEntity> CheckTrustedConfigIdsCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _check_trusted_config_ids_currency(self):
            // for config in self:
            //     for trusted_config in config.trusted_config_ids:
            //         if trusted_config.currency_id != config.currency_id:
            //             raise ValidationError(_("You cannot share open orders with configuration that does not use the same currency."))
            */
            return default;
        }

        public async Task<TEntity> CleanPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _clean_payment_lines(self):
            // self.ensure_one()
            // self.payment_ids.unlink()
            */
            return default;
        }

        public async Task<TEntity> CloseSessionActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_to_balance) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _close_session_action(self, amount_to_balance):
            // # NOTE This can't handle `bank_payment_method_diffs` because there is no field in the wizard that can carry it.
            // default_account = self._get_balancing_account()
            // wizard = self.env['pos.close.session.wizard'].create({
            //     'amount_to_balance': amount_to_balance,
            //     'account_id': default_account.id,
            //     'account_readonly': not self.env.user.has_group('account.group_account_readonly'),
            //     'message': _("There is a difference between the amounts to post and the amounts of the orders, it is probably caused by taxes or accounting configurations changes.")
            // })
            // return {
            //     'name': _("Force Close Session"),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'pos.close.session.wizard',
            //     'res_id': wizard.id,
            //     'target': 'new',
            //     'context': {**self.env.context, 'active_ids': self.ids, 'active_model': 'pos.session'},
            // }
            */
            return default;
        }

        public async Task<TEntity> CloseSessionFromUiAsync<TEntity>(IEnumerable<TEntity> entities, object bank_payment_method_diff_pairs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def close_session_from_ui(self, bank_payment_method_diff_pairs=None):
            // """Calling this method will try to close the session.
            // 
            // param bank_payment_method_diff_pairs: list[(int, float)]
            //     Pairs of payment_method_id and diff_amount which will be used to post
            //     loss/profit when closing the session.
            // 
            // If successful, it returns {'successful': True}
            // Otherwise, it returns {'successful': False, 'message': str, 'redirect': bool}.
            // 'redirect' is a boolean used to know whether we redirect the user to the back end or not.
            // When necessary, error (i.e. UserError, AccessError) is raised which should redirect the user to the back end.
            // """
            // bank_payment_method_diffs = dict(bank_payment_method_diff_pairs or [])
            // self.ensure_one()
            // # Even if this is called in `post_closing_cash_details`, we need to call this here too for case
            // # where cash_control = False
            // open_order_ids = self.get_session_orders().filtered(lambda o: o.state == 'draft').ids
            // check_closing_session = self._cannot_close_session(bank_payment_method_diffs)
            // if check_closing_session:
            //     check_closing_session['open_order_ids'] = open_order_ids
            //     return check_closing_session
            // 
            // validate_result = self.action_pos_session_closing_control(bank_payment_method_diffs=bank_payment_method_diffs)
            // 
            // # If an error is raised, the user will still be redirected to the back end to manually close the session.
            // # If the return result is a dict, this means that normally we have a redirection or a wizard => we redirect the user
            // if isinstance(validate_result, dict):
            //     # imbalance accounting entry
            //     return {
            //         'open_order_ids': open_order_ids,
            //         'successful': False,
            //         'message': validate_result.get('name'),
            //         'redirect': True
            //     }
            // 
            // self.post_close_register_message()
            // return {'successful': True}
            */
            return default;
        }

        public async Task<TEntity> CompleteValuesFromSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object values) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _complete_values_from_session(self, session, values):
            // values.setdefault('pricelist_id', session.config_id.pricelist_id.id)
            // values.setdefault('fiscal_position_id', session.config_id.default_fiscal_position_id.id)
            // values.setdefault('company_id', session.config_id.company_id.id)
            // return values
            */
            return default;
        }

        public async Task<TEntity> ComputeCashBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _compute_cash_balance(self):
            // for session in self:
            //     cash_payment_method = session.payment_method_ids.filtered('is_cash_count')[:1]
            //     if cash_payment_method:
            //         total_cash_payment = 0.0
            //         captured_cash_payments_domain = AND([session._get_captured_payments_domain(),[('payment_method_id', '=', cash_payment_method.id)]])
            //         result = self.env['pos.payment']._read_group(captured_cash_payments_domain, aggregates=['amount:sum'])
            //         total_cash_payment = result[0][0] or 0.0
            //         if session.state == 'closed':
            //             total_cash = session.cash_real_transaction + total_cash_payment
            //         else:
            //             total_cash = sum(session.statement_line_ids.mapped('amount')) + total_cash_payment
            // 
            //         session.cash_register_balance_end = session.cash_register_balance_start + total_cash
            //         session.cash_register_difference = session.cash_register_balance_end_real - session.cash_register_balance_end
            //     else:
            //         session.cash_register_balance_end = 0.0
            //         session.cash_register_difference = 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputeCashControlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_cash_control(self):
            // for config in self:
            //     config.cash_control = bool(config.payment_method_ids.filtered('is_cash_count'))
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _compute_cash_control(self):
            // # Only one cash register is supported by point_of_sale.
            // for session in self:
            //     if session.cash_journal_id:
            //         session.cash_control = session.config_id.cash_control
            //     else:
            //         session.cash_control = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCashJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _compute_cash_journal(self):
            // # Only one cash register is supported by point_of_sale.
            // for session in self:
            //     cash_journal = session.payment_method_ids.filtered('is_cash_count')[:1].journal_id
            //     session.cash_journal_id = cash_journal
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyHasTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_company_has_template(self):
            // for config in self:
            //     config.company_has_template = config.company_id.root_id.sudo()._existing_accounting() or config.company_id.chart_template
            */
            return default;
        }

        public async Task<TEntity> ComputeContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_contact_details(self):
            // for order in self:
            //     order.email = order.partner_id.email or ""
            //     order.mobile = order._phone_format(number=order.partner_id.mobile or order.partner_id.phone or "",
            //                 country=order.partner_id.country_id)
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_currency(self):
            // for pos_config in self:
            //     if pos_config.journal_id:
            //         pos_config.currency_id = pos_config.journal_id.currency_id.id or pos_config.journal_id.company_id.sudo().currency_id.id
            //     else:
            //         pos_config.currency_id = pos_config.company_id.sudo().currency_id.id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_currency_rate(self):
            // for order in self:
            //     order.currency_rate = self.env['res.currency']._get_conversion_rate(order.company_id.currency_id, order.currency_id, order.company_id, order.date_order.date())
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_current_session(self):
            // """If there is an open session, store it to current_session_id / current_session_State.
            // """
            // self.session_ids.fetch(["state"])
            // for pos_config in self:
            //     opened_sessions = pos_config.session_ids.filtered(lambda s: s.state != 'closed')
            //     rescue_sessions = opened_sessions.filtered('rescue')
            //     session = pos_config.session_ids.filtered(lambda s: s.state != 'closed' and not s.rescue)
            //     # sessions ordered by id desc
            //     pos_config.has_active_session = opened_sessions and True or False
            //     pos_config.current_session_id = session and session[0].id or False
            //     pos_config.current_session_state = session and session[0].state or False
            //     pos_config.number_of_rescue_session = len(rescue_sessions)
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentSessionUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_current_session_user(self):
            // for pos_config in self:
            //     session = pos_config.session_ids.filtered(lambda s: s.state in ['opening_control', 'opened', 'closing_control'] and not s.rescue)
            //     if session:
            //         pos_config.pos_session_username = session[0].user_id.sudo().name
            //         pos_config.pos_session_state = session[0].state
            //         pos_config.pos_session_duration = (
            //             datetime.now() - session[0].start_at
            //         ).days if session[0].start_at else 0
            //         pos_config.current_user_id = session[0].user_id
            //     else:
            //         pos_config.pos_session_username = False
            //         pos_config.pos_session_state = False
            //         pos_config.pos_session_duration = 0
            //         pos_config.current_user_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRefundableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_has_refundable_lines(self):
            // digits = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // for order in self:
            //     order.has_refundable_lines = any([float_compare(line.qty, line.refunded_qty, digits) > 0 for line in order.lines])
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_is_edited(self):
            // for order in self:
            //     order.is_edited = any(order.lines.mapped('is_edited')) or order.has_deleted_line
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _compute_is_in_company_currency(self):
            // for session in self:
            //     session.is_in_company_currency = session.currency_id == session.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInstalledAccountAccountantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_is_installed_account_accountant(self):
            // account_accountant = self.env['ir.module.module'].sudo().search([('name', '=', 'account_accountant'), ('state', '=', 'installed')])
            // for pos_config in self:
            //     pos_config.is_installed_account_accountant = account_accountant and account_accountant.id
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_is_invoiced(self):
            // for order in self:
            //     order.is_invoiced = bool(order.account_move)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTotalCostComputedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_is_total_cost_computed(self):
            // for order in self:
            //     order.is_total_cost_computed = not False in order.lines.mapped('is_total_cost_computed')
            */
            return default;
        }

        public async Task<TEntity> ComputeLastSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _compute_last_session(self):
            // PosSession = self.env['pos.session']
            // for pos_config in self:
            //     session = PosSession.search_read(
            //         [('config_id', '=', pos_config.id), ('state', '=', 'closed')],
            //         ['cash_register_balance_end_real', 'stop_at'],
            //         order="stop_at desc", limit=1)
            //     if session:
            //         timezone = pytz.timezone(self._context.get('tz') or self.env.user.tz or 'UTC')
            //         pos_config.last_session_closing_date = session[0]['stop_at'].astimezone(timezone).date()
            //         pos_config.last_session_closing_cash = session[0]['cash_register_balance_end_real']
            //     else:
            //         pos_config.last_session_closing_cash = 0
            //         pos_config.last_session_closing_date = False
            */
            return default;
        }

        public async Task<TEntity> ComputeMarginInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_margin(self):
            // for order in self:
            //     if order.is_total_cost_computed:
            //         order.margin = sum(order.lines.mapped('margin'))
            //         amount_untaxed = order.currency_id.round(sum(line.price_subtotal for line in order.lines))
            //         order.margin_percent = not float_is_zero(amount_untaxed, precision_rounding=order.currency_id.rounding) and order.margin / amount_untaxed or 0
            //     else:
            //         order.margin = 0
            //         order.margin_percent = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _compute_order_count(self):
            // orders_data = self.env['pos.order']._read_group([('session_id', 'in', self.ids)], ['session_id'], ['__count'])
            // sessions_data = {session.id: count for session, count in orders_data}
            // for session in self:
            //     session.order_count = sessions_data.get(session.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_order_name(self, session=None):
            // session = session or self.session_id
            // if self.refunded_order_id.exists():
            //     return _('%(refunded_order)s REFUND', refunded_order=self.refunded_order_id.name)
            // else:
            //     return session.config_id.sequence_id._next()
            */
            return default;
        }

        public async Task<TEntity> ComputePickingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_picking_count(self):
            // for order in self:
            //     order.picking_count = len(order.picking_ids)
            //     order.failed_pickings = bool(order.picking_ids.filtered(lambda p: p.state != 'done'))
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _compute_picking_count(self):
            // for session in self:
            //     session.picking_count = self.env['stock.picking'].search_count([('pos_session_id', '=', session.id)])
            //     session.failed_pickings = bool(self.env['stock.picking'].search([('pos_session_id', '=', session.id), ('state', '!=', 'done')], limit=1))
            */
            return default;
        }

        public async Task<TEntity> ComputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_prices(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     if not order.currency_id:
            //         raise UserError(_("You can't: create a pos order from the backend interface, or unset the pricelist, or create a pos.order in a python test with Form tool, or edit the form view in studio if no PoS order exist"))
            //     order.amount_paid = sum(payment.amount for payment in order.payment_ids)
            //     order.amount_return = -sum(payment.amount < 0 and payment.amount or 0 for payment in order.payment_ids)
            // 
            //     base_lines = order.lines._prepare_tax_base_line_values()
            //     AccountTax._add_tax_details_in_base_lines(base_lines, order.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, order.company_id)
            // 
            //     cash_rounding = None
            //     if (
            //         order.config_id.cash_rounding
            //         and not order.config_id.only_round_cash_method
            //         and order.config_id.rounding_method
            //     ):
            //         cash_rounding = order.config_id.rounding_method
            // 
            //     tax_totals = AccountTax._get_tax_totals_summary(
            //         base_lines=base_lines,
            //         currency=order.currency_id,
            //         company=order.company_id,
            //         cash_rounding=cash_rounding,
            //     )
            //     refund_factor = -1 if (order.amount_total < 0.0) else 1
            //     order.amount_tax = refund_factor * tax_totals['tax_amount_currency']
            //     order.amount_total = refund_factor * tax_totals['total_amount_currency']
            //     order.amount_difference = order.amount_paid - order.amount_total
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundRelatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_refund_related_fields(self):
            // for order in self:
            //     order.refund_orders_count = len(order.mapped('lines.refund_orderline_ids.order_id'))
            //     order.refunded_order_id = order.lines.refunded_orderline_id.order_id
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalCostAtSessionClosingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stock_moves) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_total_cost_at_session_closing(self, stock_moves):
            // """
            // Compute the margin at the end of the session. This method should be called to compute the remaining lines margin
            // containing a storable product with a fifo/avco cost method and then compute the order margin
            // """
            // for order in self:
            //     storable_fifo_avco_lines = order.lines.filtered(lambda l: l._is_product_storable_fifo_avco())
            //     storable_fifo_avco_lines._compute_total_cost(stock_moves)
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalCostInRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_total_cost_in_real_time(self):
            // """
            // Compute the total cost of the order when it's processed by the server. It will compute the total cost of all the lines
            // if it's possible. If a margin of one of the order's lines cannot be computed (because of session_id.update_stock_at_closing),
            // then the margin of said order is not computed (it will be computed when closing the session).
            // """
            // for order in self:
            //     lines = order.lines
            //     if not order._should_create_picking_real_time():
            //         storable_fifo_avco_lines = lines.filtered(lambda l: l._is_product_storable_fifo_avco())
            //         lines -= storable_fifo_avco_lines
            //     stock_moves = order.picking_ids.move_ids
            //     lines._compute_total_cost(stock_moves)
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalPaymentsAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _compute_total_payments_amount(self):
            // result = self.env['pos.payment']._read_group(self._get_captured_payments_domain(), ['session_id'], ['amount:sum'])
            // session_amount_map = {session.id: amount for session, amount in result}
            // for session in self:
            //     session.total_payments_amount = session_amount_map.get(session.id) or 0
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackingNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_tracking_number(self):
            // for record in self:
            //     record.tracking_number = str((record.session_id.id % 10) * 100 + record.sequence_number % 100).zfill(3)
            */
            return default;
        }

        public async Task<TEntity> ConfigSequenceImplementationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _config_sequence_implementation(self):
            // return 'standard'
            */
            return default;
        }

        public async Task<TEntity> CreateAccountMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_account_move(self, balancing_account=False, amount_to_balance=0, bank_payment_method_diffs=None):
            // """ Create account.move and account.move.line records for this session.
            // 
            // Side-effects include:
            //     - setting self.move_id to the created account.move record
            //     - reconciling cash receivable lines, invoice receivable lines and stock output lines
            // """
            // account_move = self.env['account.move'].create({
            //     'journal_id': self.config_id.journal_id.id,
            //     'date': fields.Date.context_today(self),
            //     'ref': self.name,
            // })
            // self.write({'move_id': account_move.id})
            // 
            // data = {'bank_payment_method_diffs': bank_payment_method_diffs or {}}
            // data = self._accumulate_amounts(data)
            // data = self._create_non_reconciliable_move_lines(data)
            // data = self._create_bank_payment_moves(data)
            // data = self._create_pay_later_receivable_lines(data)
            // data = self._create_cash_statement_lines_and_cash_move_lines(data)
            // data = self._create_invoice_receivable_lines(data)
            // data = self._create_stock_output_lines(data)
            // if balancing_account and amount_to_balance:
            //     data = self._create_balancing_line(data, balancing_account, amount_to_balance)
            // 
            // return data
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_bus_mixin.py) ---
            // def create(self, vals_list):
            // records = super().create(vals_list)
            // for record in records:
            //     record._ensure_access_token()
            // return records
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     self._check_header_footer(vals)
            //     IrSequence = self.env['ir.sequence'].sudo()
            //     val = {
            //         'name': _('POS Order %s', vals['name']),
            //         'padding': 4,
            //         'prefix': "%s/" % vals['name'],
            //         'code': "pos.order",
            //         'company_id': vals.get('company_id', False),
            //         'implementation': self._config_sequence_implementation(),
            //     }
            //     # force sequence_id field to new pos.order sequence
            //     vals['sequence_id'] = IrSequence.create(val).id
            // 
            //     val.update(name=_('POS order line %s', vals['name']), code='pos.order.line')
            //     vals['sequence_line_id'] = IrSequence.create(val).id
            // pos_configs = super().create(vals_list)
            // pos_configs.sudo()._check_modules_to_install()
            // pos_configs.sudo()._check_groups_implied()
            // pos_configs._update_preparation_printers_menuitem_visibility()
            // # If you plan to add something after this, use a new environment. The one above is no longer valid after the modules install.
            // return pos_configs
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     session = self.env['pos.session'].browse(vals['session_id'])
            //     vals = self._complete_values_from_session(session, vals)
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     config_id = vals.get('config_id') or self.env.context.get('default_config_id')
            //     if not config_id:
            //         raise UserError(_("You should assign a Point of Sale to your session."))
            // 
            //     name_counter = 0
            //     if not vals.get('rescue'):
            //         config_name = self.env['pos.config'].browse(config_id).name
            //         vals['name'] = config_name + '/'
            //         sessions = self.sudo().search_read([('name', 'ilike', vals['name'])], ['name'], order='name desc', limit=1)
            //         if len(sessions):
            //             name_counter = int(sessions[0]['name'].split('/')[-1]) + 1
            // 
            //         vals['name'] += str(name_counter).zfill(5)
            //     # journal_id is not required on the pos_config because it does not
            //     # exists at the installation. If nothing is configured at the
            //     # installation we do the minimal configuration. Impossible to do in
            //     # the .xml files as the CoA is not yet installed.
            //     pos_config = self.env['pos.config'].browse(config_id)
            // 
            //     update_stock_at_closing = pos_config.company_id.point_of_sale_update_stock_quantities == "closing"
            // 
            //     vals.update({
            //         'config_id': config_id,
            //         'update_stock_at_closing': update_stock_at_closing,
            //     })
            // 
            // if self.env.user.has_group('point_of_sale.group_pos_user'):
            //     sessions = super(PosSession, self.sudo()).create(vals_list)
            // else:
            //     sessions = super().create(vals_list)
            // sessions.action_pos_session_open()
            // 
            // return sessions
            */
            return default;
        }

        public async Task<TEntity> CreateBalancingLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object balancing_account, object amount_to_balance) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_balancing_line(self, data, balancing_account, amount_to_balance):
            // if not self.company_id.currency_id.is_zero(amount_to_balance):
            //     balancing_vals = self._prepare_balancing_line_vals(amount_to_balance, self.move_id, balancing_account)
            //     MoveLine = data.get('MoveLine')
            //     MoveLine.create(balancing_vals)
            // return data
            */
            return default;
        }

        public async Task<TEntity> CreateBankPaymentMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_bank_payment_moves(self, data):
            // combine_receivables_bank = data.get('combine_receivables_bank')
            // split_receivables_bank = data.get('split_receivables_bank')
            // bank_payment_method_diffs = data.get('bank_payment_method_diffs')
            // MoveLine = data.get('MoveLine')
            // payment_method_to_receivable_lines = {}
            // payment_to_receivable_lines = {}
            // for payment_method, amounts in combine_receivables_bank.items():
            //     combine_receivable_line = MoveLine.create(self._get_combine_receivable_vals(payment_method, amounts['amount'], amounts['amount_converted']))
            //     payment_receivable_line = self._create_combine_account_payment(payment_method, amounts, diff_amount=bank_payment_method_diffs.get(payment_method.id) or 0)
            //     payment_method_to_receivable_lines[payment_method] = combine_receivable_line | payment_receivable_line
            // 
            // for payment, amounts in split_receivables_bank.items():
            //     split_receivable_line = MoveLine.create(self._get_split_receivable_vals(payment, amounts['amount'], amounts['amount_converted']))
            //     payment_receivable_line = self._create_split_account_payment(payment, amounts)
            //     payment_to_receivable_lines[payment] = split_receivable_line | payment_receivable_line
            // 
            // for bank_payment_method in self.payment_method_ids.filtered(lambda pm: pm.type == 'bank' and pm.split_transactions):
            //     self._create_diff_account_move_for_split_payment_method(bank_payment_method, bank_payment_method_diffs.get(bank_payment_method.id) or 0)
            // 
            // data['payment_method_to_receivable_lines'] = payment_method_to_receivable_lines
            // data['payment_to_receivable_lines'] = payment_to_receivable_lines
            // return data
            */
            return default;
        }

        public async Task<TEntity> CreateCashPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_journal_vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _create_cash_payment_method(self, cash_journal_vals=None):
            // if cash_journal_vals is None:
            //     cash_journal_vals = {}
            // journal_vals = {
            //     'name': _('Cash'),
            //     'type': 'cash',
            //     'company_id': self.env.company.id,
            //     **cash_journal_vals,
            // }
            // 
            // default_cash_account = self.env['account.account'].with_context(lang='en_US').search([
            //     ('account_type', '=', 'asset_cash'),
            //     ('name', '=', 'Cash'),
            //     ('company_ids', 'in', self.env.company.root_id.id)
            // ], limit=1)
            // 
            // if default_cash_account:
            //     journal_vals['default_account_id'] = default_cash_account.id
            // 
            // cash_journal = self.env['account.journal'].create(journal_vals)
            // return self.env['pos.payment.method'].create({
            //     'name': _('Cash'),
            //     'journal_id': cash_journal.id,
            //     'company_id': self.env.company.id,
            // })
            */
            return default;
        }

        public async Task<TEntity> CreateCashStatementLinesAndCashMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_cash_statement_lines_and_cash_move_lines(self, data):
            // # Create the split and combine cash statement lines and account move lines.
            // # `split_cash_statement_lines` maps `journal` -> split cash statement lines
            // # `combine_cash_statement_lines` maps `journal` -> combine cash statement lines
            // # `split_cash_receivable_lines` maps `journal` -> split cash receivable lines
            // # `combine_cash_receivable_lines` maps `journal` -> combine cash receivable lines
            // MoveLine = data.get('MoveLine')
            // split_receivables_cash = data.get('split_receivables_cash')
            // combine_receivables_cash = data.get('combine_receivables_cash')
            // 
            // # handle split cash payments
            // split_cash_statement_line_vals = []
            // split_cash_receivable_vals = []
            // for payment, amounts in split_receivables_cash.items():
            //     journal_id = payment.payment_method_id.journal_id.id
            //     split_cash_statement_line_vals.append(
            //         self._get_split_statement_line_vals(
            //             journal_id,
            //             amounts['amount'],
            //             payment
            //         )
            //     )
            //     split_cash_receivable_vals.append(
            //         self._get_split_receivable_vals(
            //             payment,
            //             amounts['amount'],
            //             amounts['amount_converted']
            //         )
            //     )
            // # handle combine cash payments
            // combine_cash_statement_line_vals = []
            // combine_cash_receivable_vals = []
            // for payment_method, amounts in combine_receivables_cash.items():
            //     if not float_is_zero(amounts['amount'] , precision_rounding=self.currency_id.rounding):
            //         combine_cash_statement_line_vals.append(
            //             self._get_combine_statement_line_vals(
            //                 payment_method.journal_id.id,
            //                 amounts['amount'],
            //                 payment_method
            //             )
            //         )
            //         combine_cash_receivable_vals.append(
            //             self._get_combine_receivable_vals(
            //                 payment_method,
            //                 amounts['amount'],
            //                 amounts['amount_converted']
            //             )
            //         )
            // 
            // # create the statement lines and account move lines
            // BankStatementLine = self.env['account.bank.statement.line']
            // split_cash_statement_lines = {}
            // combine_cash_statement_lines = {}
            // split_cash_receivable_lines = {}
            // combine_cash_receivable_lines = {}
            // split_cash_statement_lines = BankStatementLine.create(split_cash_statement_line_vals).mapped('move_id.line_ids').filtered(lambda line: line.account_id.account_type == 'asset_receivable')
            // combine_cash_statement_lines = BankStatementLine.create(combine_cash_statement_line_vals).mapped('move_id.line_ids').filtered(lambda line: line.account_id.account_type == 'asset_receivable')
            // split_cash_receivable_lines = MoveLine.create(split_cash_receivable_vals)
            // combine_cash_receivable_lines = MoveLine.create(combine_cash_receivable_vals)
            // 
            // data.update(
            //     {'split_cash_statement_lines':    split_cash_statement_lines,
            //      'combine_cash_statement_lines':  combine_cash_statement_lines,
            //      'split_cash_receivable_lines':   split_cash_receivable_lines,
            //      'combine_cash_receivable_lines': combine_cash_receivable_lines
            //      })
            // return data
            */
            return default;
        }

        public async Task<TEntity> CreateCombineAccountPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method, object amounts, object diff_amount) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_combine_account_payment(self, payment_method, amounts, diff_amount):
            // outstanding_account = payment_method.outstanding_account_id
            // destination_account = self._get_receivable_account(payment_method)
            // 
            // account_payment = self.env['account.payment'].with_context(pos_payment=True).create({
            //     'amount': abs(amounts['amount']),
            //     'journal_id': payment_method.journal_id.id,
            //     'force_outstanding_account_id': outstanding_account.id,
            //     'destination_account_id': destination_account.id,
            //     'memo': _('Combine %(payment_method)s POS payments from %(session)s', payment_method=payment_method.name, session=self.name),
            //     'pos_payment_method_id': payment_method.id,
            //     'pos_session_id': self.id,
            //     'company_id': self.company_id.id,
            // })
            // 
            // # In community the outstanding account is computed on the creation of account.payment records
            // accounting_installed = self.env['account.move']._get_invoice_in_payment_state() == 'in_payment'
            // if not account_payment.outstanding_account_id and accounting_installed:
            //     account_payment.outstanding_account_id = account_payment._get_outstanding_account(account_payment.payment_type)
            // 
            // if float_compare(amounts['amount'], 0, precision_rounding=self.currency_id.rounding) < 0:
            //     # revert the accounts because account.payment doesn't accept negative amount.
            //     account_payment.write({
            //         'outstanding_account_id': account_payment.destination_account_id,
            //         'destination_account_id': account_payment.outstanding_account_id,
            //         'payment_type': 'outbound',
            //     })
            // 
            // account_payment.action_post()
            // 
            // diff_amount_compare_to_zero = self.currency_id.compare_amounts(diff_amount, 0)
            // if diff_amount_compare_to_zero != 0:
            //     self._apply_diff_on_account_payment_move(account_payment, payment_method, diff_amount)
            // 
            // return account_payment.move_id.line_ids.filtered(lambda line: line.account_id == self._get_receivable_account(payment_method))
            */
            return default;
        }

        public async Task<TEntity> CreateDiffAccountMoveForSplitPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method, object diff_amount) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_diff_account_move_for_split_payment_method(self, payment_method, diff_amount):
            // self.ensure_one()
            // 
            // get_diff_vals_result = self._get_diff_vals(payment_method.id, diff_amount)
            // if not get_diff_vals_result:
            //     return
            // 
            // source_vals, dest_vals = get_diff_vals_result
            // diff_move = self.env['account.move'].create({
            //     'journal_id': payment_method.journal_id.id,
            //     'date': fields.Date.context_today(self),
            //     'ref': self._get_diff_account_move_ref(payment_method),
            //     'line_ids': [Command.create(source_vals), Command.create(dest_vals)]
            // })
            // diff_move._post()
            */
            return default;
        }

        public async Task<TEntity> CreateInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _create_invoice(self, move_vals):
            // self.ensure_one()
            // invoice = self.env['account.move'].sudo()\
            //     .with_company(self.company_id)\
            //     .with_context(default_move_type=move_vals['move_type'], linked_to_pos=True)\
            //     .create(move_vals)
            // 
            // if self.config_id.cash_rounding:
            //     line_ids_commands = []
            //     rate = invoice.invoice_currency_rate
            //     sign = invoice.direction_sign
            //     amount_paid = (-1 if self.amount_total < 0.0 else 1) * self.amount_paid
            //     difference_currency = sign * (amount_paid - invoice.amount_total)
            //     difference_balance = invoice.company_currency_id.round(difference_currency / rate) if rate else 0.0
            //     if not self.currency_id.is_zero(difference_currency):
            //         rounding_line = invoice.line_ids.filtered(lambda line: line.display_type == 'rounding' and not line.tax_line_id)
            //         if rounding_line:
            //             line_ids_commands.append(Command.update(rounding_line.id, {
            //                 'amount_currency': rounding_line.amount_currency + difference_currency,
            //                 'balance': rounding_line.balance + difference_balance,
            //             }))
            //         else:
            //             if difference_currency > 0.0:
            //                 account = invoice.invoice_cash_rounding_id.loss_account_id
            //             else:
            //                 account = invoice.invoice_cash_rounding_id.profit_account_id
            //             line_ids_commands.append(Command.create({
            //                 'name': invoice.invoice_cash_rounding_id.name,
            //                 'amount_currency': difference_currency,
            //                 'balance': difference_balance,
            //                 'currency_id': invoice.currency_id.id,
            //                 'display_type': 'rounding',
            //                 'account_id': account.id,
            //             }))
            //         existing_terms_line = invoice.line_ids\
            //             .filtered(lambda line: line.display_type == 'payment_term')\
            //             .sorted(lambda line: -abs(line.amount_currency))[:1]
            //         line_ids_commands.append(Command.update(existing_terms_line.id, {
            //             'amount_currency': existing_terms_line.amount_currency - difference_currency,
            //             'balance': existing_terms_line.balance - difference_balance,
            //         }))
            //         with self.env['account.move']._check_balanced({'records': invoice}):
            //             invoice.with_context(skip_invoice_sync=True).line_ids = line_ids_commands
            // invoice.message_post(body=_("This invoice has been created from the point of sale session: %s", self._get_html_link()))
            // return invoice
            */
            return default;
        }

        public async Task<TEntity> CreateInvoiceReceivableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_invoice_receivable_lines(self, data):
            // # Create invoice receivable lines for this session's move_id.
            // # Keep reference of the invoice receivable lines because
            // # they are reconciled with the lines in combine_inv_payment_receivable_lines
            // MoveLine = data.get('MoveLine')
            // combine_invoice_receivables = data.get('combine_invoice_receivables')
            // split_invoice_receivables = data.get('split_invoice_receivables')
            // 
            // combine_invoice_receivable_vals = defaultdict(list)
            // split_invoice_receivable_vals = defaultdict(list)
            // combine_invoice_receivable_lines = {}
            // split_invoice_receivable_lines = {}
            // for payment_method, amounts in combine_invoice_receivables.items():
            //     combine_invoice_receivable_vals[payment_method].append(self._get_invoice_receivable_vals(amounts['amount'], amounts['amount_converted']))
            // for payment, amounts in split_invoice_receivables.items():
            //     split_invoice_receivable_vals[payment].append(self._get_invoice_receivable_vals(amounts['amount'], amounts['amount_converted']))
            // for payment_method, vals in combine_invoice_receivable_vals.items():
            //     receivable_lines = MoveLine.create(vals)
            //     combine_invoice_receivable_lines[payment_method] = receivable_lines
            // for payment, vals in split_invoice_receivable_vals.items():
            //     receivable_lines = MoveLine.create(vals)
            //     split_invoice_receivable_lines[payment] = receivable_lines
            // 
            // data.update({'combine_invoice_receivable_lines': combine_invoice_receivable_lines})
            // data.update({'split_invoice_receivable_lines': split_invoice_receivable_lines})
            // return data
            */
            return default;
        }

        public async Task<TEntity> CreateJournalAndPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_ref, object cash_journal_vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _create_journal_and_payment_methods(self, cash_ref=None, cash_journal_vals=None):
            // """This should only be called at creation of a new pos.config."""
            // 
            // journal = self.env['account.journal']._ensure_company_account_journal()
            // payment_methods = self.env['pos.payment.method']
            // 
            // # create cash payment method per config
            // cash_pm_from_ref = cash_ref and self.env.ref(cash_ref, raise_if_not_found=False)
            // if cash_pm_from_ref:
            //     try:
            //         cash_pm_from_ref.check_access('read')
            //         cash_pm = cash_pm_from_ref
            //     except AccessError:
            //         cash_pm = self._create_cash_payment_method(cash_journal_vals)
            // else:
            //     cash_pm = self._create_cash_payment_method(cash_journal_vals)
            // 
            // if cash_ref and cash_pm != cash_pm_from_ref:
            //     self.env['ir.model.data']._update_xmlids([{
            //         'xml_id': cash_ref,
            //         'record': cash_pm,
            //         'noupdate': True,
            //     }])
            // 
            // payment_methods |= cash_pm
            // 
            // # only create bank and customer account payment methods per company
            // bank_pm = self.env['pos.payment.method'].search([('journal_id.type', '=', 'bank'), ('company_id', 'in', self.env.company.parent_ids.ids)])
            // if not bank_pm:
            //     bank_journal = self.env['account.journal'].search([('type', '=', 'bank'), ('company_id', 'in', self.env.company.parent_ids.ids)], limit=1)
            //     if not bank_journal:
            //         raise UserError(_('Ensure that there is an existing bank journal. Check if chart of accounts is installed in your company.'))
            //     bank_pm = self.env['pos.payment.method'].create({
            //         'name': _('Card'),
            //         'journal_id': bank_journal.id,
            //         'company_id': self.env.company.id,
            //         'sequence': 1,
            //     })
            // 
            // payment_methods |= bank_pm
            // 
            // pay_later_pm = self.env['pos.payment.method'].search([('journal_id', '=', False), ('company_id', 'in', self.env.company.parent_ids.ids)])
            // if not pay_later_pm:
            //     pay_later_pm = self.env['pos.payment.method'].create({
            //         'name': _('Customer Account'),
            //         'company_id': self.env.company.id,
            //         'split_transactions': True,
            //         'sequence': 2,
            //     })
            // 
            // payment_methods |= pay_later_pm
            // 
            // return journal, payment_methods.ids
            */
            return default;
        }

        public async Task<TEntity> CreateMiscReversalMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_moves) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _create_misc_reversal_move(self, payment_moves):
            // """ Create a misc move to reverse this POS order and "remove" it from the POS closing entry.
            // This is done by taking data from the order and using it to somewhat replicate the resulting entry in order to
            // reverse partially the movements done ine the POS closing entry.
            // """
            // aml_values_list_per_nature = self._prepare_aml_values_list_per_nature()
            // move_lines = []
            // for aml_values_list in aml_values_list_per_nature.values():
            //     for aml_values in aml_values_list:
            //         aml_values['balance'] = -aml_values['balance']
            //         aml_values['amount_currency'] = -aml_values['amount_currency']
            //         move_lines.append(aml_values)
            // 
            // # Make a move with all the lines.
            // reversal_entry = self.env['account.move'].with_context(
            //     default_journal_id=self.config_id.journal_id.id,
            //     skip_invoice_sync=True,
            //     skip_invoice_line_sync=True,
            // ).create({
            //     'journal_id': self.config_id.journal_id.id,
            //     'date': fields.Date.context_today(self),
            //     'ref': _('Reversal of POS closing entry %(entry)s for order %(order)s from session %(session)s', entry=self.session_move_id.name, order=self.name, session=self.session_id.name),
            //     'line_ids': [(0, 0, aml_value) for aml_value in move_lines],
            //     'reversed_pos_order_id': self.id
            // })
            // reversal_entry.action_post()
            // 
            // pos_account_receivable = self.company_id.account_default_pos_receivable_account_id
            // account_receivable = self.payment_ids.payment_method_id.receivable_account_id
            // reversal_entry_receivable = reversal_entry.line_ids.filtered(lambda l: l.account_id in (pos_account_receivable + account_receivable))
            // payment_receivable = payment_moves.line_ids.filtered(lambda l: l.account_id in (pos_account_receivable + account_receivable))
            // lines_to_reconcile = defaultdict(lambda: self.env['account.move.line'])
            // for line in (reversal_entry_receivable | payment_receivable):
            //     lines_to_reconcile[line.account_id] |= line
            // for line in lines_to_reconcile.values():
            //     line.filtered(lambda l: not l.reconciled).reconcile()
            */
            return default;
        }

        public async Task<TEntity> CreateNonReconciliableMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_non_reconciliable_move_lines(self, data):
            // # Create account.move.line records for
            // #   - sales
            // #   - taxes
            // #   - stock expense
            // #   - non-cash split receivables (not for automatic reconciliation)
            // #   - non-cash combine receivables (not for automatic reconciliation)
            // taxes = data.get('taxes')
            // sales = data.get('sales')
            // stock_expense = data.get('stock_expense')
            // rounding_difference = data.get('rounding_difference')
            // MoveLine = data.get('MoveLine')
            // 
            // tax_vals = [self._get_tax_vals(key, amounts['amount'], amounts['amount_converted'], amounts['base_amount_converted']) for key, amounts in taxes.items()]
            // # Check if all taxes lines have account_id assigned. If not, there are repartition lines of the tax that have no account_id.
            // tax_names_no_account = [line['name'] for line in tax_vals if not line['account_id']]
            // if tax_names_no_account:
            //     raise UserError(_(
            //         'Unable to close and validate the session.\n'
            //         'Please set corresponding tax account in each repartition line of the following taxes: \n%s',
            //         ', '.join(tax_names_no_account)
            //     ))
            // rounding_vals = []
            // 
            // if not float_is_zero(rounding_difference['amount'], precision_rounding=self.currency_id.rounding) or not float_is_zero(rounding_difference['amount_converted'], precision_rounding=self.currency_id.rounding):
            //     rounding_vals = [self._get_rounding_difference_vals(rounding_difference['amount'], rounding_difference['amount_converted'])]
            // 
            // MoveLine.create(tax_vals)
            // move_line_ids = MoveLine.create(list(starmap(self._get_sale_vals, sales.items())))
            // for key, ml_id in zip(sales.keys(), move_line_ids.ids):
            //     sales[key]['move_line_id'] = ml_id
            // MoveLine.create(
            //     [self._get_stock_expense_vals(key, amounts['amount'], amounts['amount_converted']) for key, amounts in stock_expense.items()]
            //     + rounding_vals
            // )
            // 
            // return data
            */
            return default;
        }

        public async Task<TEntity> CreateOrderPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _create_order_picking(self):
            // self.ensure_one()
            // if self.shipping_date:
            //     self.sudo().lines._launch_stock_rule_from_pos_order_lines()
            // else:
            //     if self._should_create_picking_real_time():
            //         picking_type = self.config_id.picking_type_id
            //         if self.partner_id.property_stock_customer:
            //             destination_id = self.partner_id.property_stock_customer.id
            //         elif not picking_type or not picking_type.default_location_dest_id:
            //             destination_id = self.env['stock.warehouse']._get_partner_locations()[0].id
            //         else:
            //             destination_id = picking_type.default_location_dest_id.id
            // 
            //         pickings = self.env['stock.picking']._create_picking_from_pos_order_lines(destination_id, self.lines, picking_type, self.partner_id)
            //         pickings.write({'pos_session_id': self.session_id.id, 'pos_order_id': self.id, 'origin': self.name})
            */
            return default;
        }

        public async Task<TEntity> CreatePayLaterReceivableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_pay_later_receivable_lines(self, data):
            // MoveLine = data.get('MoveLine')
            // combine_receivables_pay_later = data.get('combine_receivables_pay_later')
            // split_receivables_pay_later = data.get('split_receivables_pay_later')
            // vals = []
            // for payment_method, amounts in combine_receivables_pay_later.items():
            //     vals.append(self._get_combine_receivable_vals(payment_method, amounts['amount'], amounts['amount_converted']))
            // for payment, amounts in split_receivables_pay_later.items():
            //     vals.append(self._get_split_receivable_vals(payment, amounts['amount'], amounts['amount_converted']))
            // data['pay_later_move_lines'] = MoveLine.create(vals)
            // return data
            */
            return default;
        }

        public async Task<TEntity> CreatePickingAtEndOfSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_picking_at_end_of_session(self):
            // self.ensure_one()
            // lines_grouped_by_dest_location = {}
            // picking_type = self.config_id.picking_type_id
            // 
            // if not picking_type or not picking_type.default_location_dest_id:
            //     session_destination_id = self.env['stock.warehouse']._get_partner_locations()[0].id
            // else:
            //     session_destination_id = picking_type.default_location_dest_id.id
            // 
            // for order in self._get_closed_orders():
            //     if order.company_id.anglo_saxon_accounting and order.is_invoiced or order.shipping_date:
            //         continue
            //     destination_id = order.partner_id.property_stock_customer.id or session_destination_id
            //     if destination_id in lines_grouped_by_dest_location:
            //         lines_grouped_by_dest_location[destination_id] |= order.lines
            //     else:
            //         lines_grouped_by_dest_location[destination_id] = order.lines
            // 
            // for location_dest_id, lines in lines_grouped_by_dest_location.items():
            //     pickings = self.env['stock.picking']._create_picking_from_pos_order_lines(location_dest_id, lines, picking_type)
            //     pickings.write({'pos_session_id': self.id, 'origin': self.name})
            */
            return default;
        }

        public async Task<TEntity> CreatePmChangeLogInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _create_pm_change_log(self, vals):
            // if not vals.get('payment_ids'):
            //     return []
            // 
            // message_list = []
            // new_pms = vals.get('payment_ids', [])
            // for new_pm in new_pms:
            //     orm_command = new_pm[0]
            // 
            //     if orm_command == 0:
            //         payment_method_id = self.env['pos.payment.method'].browse(new_pm[2].get('payment_method_id'))
            //         amount = formatLang(self.env, new_pm[2].get('amount'), currency_obj=self.currency_id)
            //         message_list.append(_("Added %(payment_method)s with %(amount)s",
            //             payment_method=payment_method_id.name,
            //             amount=amount))
            //     elif orm_command == 1:
            //         pm_id = self.env['pos.payment'].browse(new_pm[1])
            //         old_pm = pm_id.payment_method_id.name
            //         old_amount = formatLang(self.env, pm_id.amount, currency_obj=pm_id.currency_id)
            //         new_amount = False
            //         new_payment_method = False
            // 
            //         if new_pm[2].get('payment_method_id'):
            //             new_payment_method = self.env['pos.payment.method'].browse(new_pm[2].get('payment_method_id'))
            //         if new_pm[2].get('amount'):
            //             new_amount = formatLang(self.env, new_pm[2].get('amount'), currency_obj=pm_id.currency_id)
            // 
            //         if new_payment_method and new_amount:
            //             message_list.append(_("%(old_pm)s changed to %(new_pm)s and from %(old_amount)s to %(new_amount)s",
            //                 old_pm=old_pm,
            //                 new_pm=new_payment_method.name,
            //                 old_amount=old_amount,
            //                 new_amount=new_amount))
            //         elif new_payment_method:
            //             message_list.append(_("%(old_pm)s changed to %(new_pm)s for %(old_amount)s",
            //                 old_pm=old_pm,
            //                 new_pm=new_payment_method.name,
            //                 old_amount=old_amount))
            //         elif new_amount:
            //             message_list.append(_("Amount for %(old_pm)s changed from %(old_amount)s to %(new_amount)s",
            //                 old_amount=old_amount,
            //                 new_amount=new_amount,
            //                 old_pm=old_pm))
            //     elif orm_command == 2:
            //         pm_id = self.env['pos.payment'].browse(new_pm[1])
            //         amount = formatLang(self.env, pm_id.amount, currency_obj=pm_id.currency_id)
            //         message_list.append(_("Removed %(payment_method)s with %(amount)s",
            //             payment_method=pm_id.payment_method_id.name,
            //             amount=amount))
            // 
            // return message_list
            */
            return default;
        }

        public async Task<TEntity> CreateSplitAccountPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment, object amounts) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_split_account_payment(self, payment, amounts):
            // payment_method = payment.payment_method_id
            // if not payment_method.journal_id:
            //     return self.env['account.move.line']
            // outstanding_account = payment_method.outstanding_account_id
            // accounting_partner = self.env["res.partner"]._find_accounting_partner(payment.partner_id)
            // destination_account = accounting_partner.property_account_receivable_id
            // 
            // if float_compare(amounts['amount'], 0, precision_rounding=self.currency_id.rounding) < 0:
            //     # revert the accounts because account.payment doesn't accept negative amount.
            //     outstanding_account, destination_account = destination_account, outstanding_account
            // 
            // account_payment = self.env['account.payment'].create({
            //     'amount': abs(amounts['amount']),
            //     'partner_id': payment.partner_id.id,
            //     'journal_id': payment_method.journal_id.id,
            //     'force_outstanding_account_id': outstanding_account.id,
            //     'destination_account_id': destination_account.id,
            //     'memo': _('%(payment_method)s POS payment of %(partner)s in %(session)s', payment_method=payment_method.name, partner=payment.partner_id.display_name, session=self.name),
            //     'pos_payment_method_id': payment_method.id,
            //     'pos_session_id': self.id,
            // })
            // account_payment.action_post()
            // return account_payment.move_id.line_ids.filtered(lambda line: line.account_id == accounting_partner.property_account_receivable_id)
            */
            return default;
        }

        public async Task<TEntity> CreateStockOutputLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _create_stock_output_lines(self, data):
            // # Keep reference to the stock output lines because
            // # they are reconciled with output lines in the stock.move's account.move.line
            // MoveLine = data.get('MoveLine')
            // stock_output = data.get('stock_output')
            // stock_return = data.get('stock_return')
            // 
            // stock_output_vals = defaultdict(list)
            // stock_output_lines = {}
            // for stock_moves in [stock_output, stock_return]:
            //     for account, amounts in stock_moves.items():
            //         stock_output_vals[account].append(self._get_stock_output_vals(account, amounts['amount'], amounts['amount_converted']))
            // 
            // for output_account, vals in stock_output_vals.items():
            //     stock_output_lines[output_account] = MoveLine.create(vals)
            // 
            // data.update({'stock_output_lines': stock_output_lines})
            // return data
            */
            return default;
        }

        public async Task<TEntity> CreditAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partial_move_line_vals, object amount, object amount_converted, object force_company_currency) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _credit_amounts(self, partial_move_line_vals, amount, amount_converted, force_company_currency=False):
            // """ `partial_move_line_vals` is completed by `credit`ing the given amounts.
            // 
            // NOTE Amounts in PoS are in the currency of journal_id in the session.config_id.
            // This means that amount fields in any pos record are actually equivalent to amount_currency
            // in account module. Understanding this basic is important in correctly assigning values for
            // 'amount' and 'amount_currency' in the account.move.line record.
            // 
            // :param partial_move_line_vals dict:
            //     initial values in creating account.move.line
            // :param amount float:
            //     amount derived from pos.payment, pos.order, or pos.order.line records
            // :param amount_converted float:
            //     converted value of `amount` from the given `session_currency` to company currency
            // 
            // :return dict: complete values for creating 'amount.move.line' record
            // """
            // if self.is_in_company_currency or force_company_currency:
            //     additional_field = {}
            // else:
            //     additional_field = {
            //         'amount_currency': -amount,
            //         'currency_id': self.currency_id.id,
            //     }
            // return {
            //     'debit': -amount_converted if amount_converted < 0.0 else 0.0,
            //     'credit': amount_converted if amount_converted > 0.0 else 0.0,
            //     **partial_move_line_vals,
            //     **additional_field,
            // }
            */
            return default;
        }

        public async Task<TEntity> DebitAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partial_move_line_vals, object amount, object amount_converted, object force_company_currency) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _debit_amounts(self, partial_move_line_vals, amount, amount_converted, force_company_currency=False):
            // """ `partial_move_line_vals` is completed by `debit`ing the given amounts.
            // 
            // See _credit_amounts docs for more details.
            // """
            // if self.is_in_company_currency or force_company_currency:
            //     additional_field = {}
            // else:
            //     additional_field = {
            //         'amount_currency': amount,
            //         'currency_id': self.currency_id.id,
            //     }
            // return {
            //     'debit': amount_converted if amount_converted > 0.0 else 0.0,
            //     'credit': -amount_converted if amount_converted < 0.0 else 0.0,
            //     **partial_move_line_vals,
            //     **additional_field,
            // }
            */
            return default;
        }

        public async Task<TEntity> DefaultInvoiceJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_invoice_journal(self):
            // return self.env['account.journal'].search([
            //     *self.env['account.journal']._check_company_domain(self.env.company),
            //     ('type', '=', 'sale'),
            // ], limit=1)
            */
            return default;
        }

        public async Task<TEntity> DefaultPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_payment_methods(self):
            // """ Should only default to payment methods that are compatible to this config's company and currency.
            // """
            // domain = [
            //     *self.env['pos.payment.method']._check_company_domain(self.env.company),
            //     ('split_transactions', '=', False),
            //     '|',
            //         ('journal_id', '=', False),
            //         ('journal_id.currency_id', 'in', (False, self.env.company.currency_id.id)),
            // ]
            // non_cash_pm = self.env['pos.payment.method'].search(domain + [('is_cash_count', '=', False)])
            // available_cash_pm = self.env['pos.payment.method'].search(domain + [('is_cash_count', '=', True),
            //                                                                     ('config_ids', '=', False)], limit=1)
            // if not (non_cash_pm or available_cash_pm):
            //     _dummy, payment_methods = self._create_journal_and_payment_methods()
            //     return self.env['pos.payment.method'].browse(payment_methods)
            // return non_cash_pm | available_cash_pm
            */
            return default;
        }

        public async Task<TEntity> DefaultPickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_picking_type_id(self):
            // return self.env['stock.warehouse'].search(self.env['stock.warehouse']._check_company_domain(self.env.company), limit=1).pos_type_id.id
            */
            return default;
        }

        public async Task<TEntity> DefaultSaleJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_sale_journal(self):
            // journal = self.env['account.journal']._ensure_company_account_journal()
            // return journal
            */
            return default;
        }

        public async Task<TEntity> DefaultWarehouseIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _default_warehouse_id(self):
            // warehouse = self.env['stock.warehouse'].search(self.env['stock.warehouse']._check_company_domain(self.env.company), limit=1).id
            // if not warehouse:
            //     self.env['stock.warehouse']._warehouse_redirect_warning()
            // return warehouse
            */
            return default;
        }

        public async Task<TEntity> DeleteOpeningControlSessionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def delete_opening_control_session(self):
            // self.ensure_one()
            // if not self.exists():
            //     return {
            //         'status': 'success',
            //     }
            // if self.state != 'opening_control' or len(self.order_ids) > 0:
            //     raise UserError(_("You can only cancel a session that is in opening control state and has no orders."))
            // self.sudo().unlink()
            // return {
            //     'status': 'success',
            // }
            */
            return default;
        }

        public async Task<TEntity> EnsureAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_bus_mixin.py) ---
            // def _ensure_access_token(self):
            // if self.access_token:
            //     return self.access_token
            // token = self.access_token = str(uuid.uuid4())
            // return token
            */
            return default;
        }

        public async Task<TEntity> ExecuteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def execute(self):
            // return {
            //      'type': 'ir.actions.client',
            //      'tag': 'reload',
            //  }
            */
            return default;
        }

        public async Task<TEntity> FindProductByBarcodeAsync<TEntity>(IEnumerable<TEntity> entities, object barcode, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def find_product_by_barcode(self, barcode, config_id):
            // product_fields = self.env['product.product']._load_pos_data_fields(config_id)
            // product_packaging_fields = self.env['product.packaging']._load_pos_data_fields(config_id)
            // product_context = {**self.env.context, 'display_default_code': False}
            // product = self.env['product.product'].search([
            //     ('barcode', '=', barcode),
            //     ('sale_ok', '=', True),
            //     ('available_in_pos', '=', True),
            // ])
            // if product:
            //     return {'product.product': product.with_context(product_context).read(product_fields, load=False)}
            // 
            // domain = [('barcode', 'not in', ['', False])]
            // loaded_data = self._context.get('loaded_data')
            // if loaded_data:
            //     loaded_product_ids = [x['id'] for x in loaded_data['product.product']]
            //     domain = AND([domain, [('product_id', 'in', [x['id'] for x in self._context.get('loaded_data')['product.product']])]]) if self._context.get('loaded_data') else []
            //     domain = AND([domain, [('product_id', 'in', loaded_product_ids)]])
            // packaging_params = {
            //     'search_params': {
            //         'domain': domain,
            //         'fields': ['name', 'barcode', 'product_id', 'qty'],
            //     },
            // }
            // packaging_params['search_params']['domain'] = [['barcode', '=', barcode]]
            // packaging = self.env['product.packaging'].search(packaging_params['search_params']['domain'])
            // 
            // if packaging and packaging.product_id:
            //     return {'product.product': packaging.product_id.with_context(product_context).read(product_fields, load=False), 'product.packaging': packaging.read(product_packaging_fields, load=False)}
            // else:
            //     return {
            //         'product.product': [],
            //         'product.packaging': [],
            //     }
            */
            return default;
        }

        public async Task<TEntity> ForceHttpInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _force_http(self):
            // enforce_https = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.enforce_https')
            // if not enforce_https and (self.other_devices or self.printer_ids.filtered(lambda pt: pt.printer_type == 'epson_epos')):
            //     return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> GeneratePosOrderInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _generate_pos_order_invoice(self):
            // moves = self.env['account.move']
            // 
            // for order in self:
            //     # Force company for all SUPERUSER_ID action
            //     if order.account_move:
            //         moves += order.account_move
            //         continue
            // 
            //     if not order.partner_id:
            //         raise UserError(_('Please provide a partner for the sale.'))
            // 
            //     move_vals = order._prepare_invoice_vals()
            //     new_move = order._create_invoice(move_vals)
            // 
            //     order.state = 'invoiced'
            //     new_move.sudo().with_company(order.company_id).with_context(**order._get_invoice_post_context())._post()
            // 
            //     moves += new_move
            //     payment_moves = order._apply_invoice_payments(order.session_id.state == 'closed')
            // 
            //     # Send and Print
            //     if self.env.context.get('generate_pdf', True):
            //         new_move.with_context(skip_invoice_sync=True)._generate_and_send()
            // 
            //     if order.session_id.state == 'closed':  # If the session isn't closed this isn't needed.
            //         # If a client requires the invoice later, we need to revers the amount from the closing entry, by making a new entry for that.
            //         order._create_misc_reversal_move(payment_moves)
            // 
            // if not moves:
            //     return {}
            // 
            // return {
            //     'name': _('Customer Invoice'),
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('account.view_move_form').id,
            //     'res_model': 'account.move',
            //     'context': "{'move_type':'out_invoice'}",
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            //     'res_id': moves and moves.ids[0] or False,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAttributesByPtalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_attributes_by_ptal_id(self):
            // # performance trick: prefetch fields with search_fetch() and fetch()
            // product_attributes = self.env['product.attribute'].search_fetch(
            //     [('create_variant', '=', 'no_variant')],
            //     ['name', 'display_type'],
            // )
            // product_template_attribute_values = self.env['product.template.attribute.value'].search_fetch(
            //     [('attribute_id', 'in', product_attributes.ids)],
            //     ['attribute_id', 'attribute_line_id', 'product_attribute_value_id', 'price_extra'],
            // )
            // product_template_attribute_values.product_attribute_value_id.fetch(['name', 'is_custom', 'html_color', 'image'])
            // 
            // key1 = lambda ptav: (ptav.attribute_line_id.id, ptav.attribute_id.id)
            // key2 = lambda ptav: (ptav.attribute_line_id.id, ptav.attribute_id)
            // res = {}
            // for key, group in groupby(sorted(product_template_attribute_values, key=key1), key=key2):
            //     attribute_line_id, attribute = key
            //     values = [{**ptav.product_attribute_value_id.read(['name', 'is_custom', 'html_color', 'image'])[0],
            //                'price_extra': ptav.price_extra,
            //                # id of a value should be from the "product.template.attribute.value" record
            //                'id': ptav.id,
            //                } for ptav in list(group)]
            //     res[attribute_line_id] = {
            //         'id': attribute_line_id,
            //         'name': attribute.name,
            //         'display_type': attribute.display_type,
            //         'values': values,
            //         'sequence': attribute.sequence,
            //     }
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetAvailableCategoriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_available_categories(self):
            // return (
            //     self.env["pos.category"]
            //     .search(
            //         [
            //             *(
            //                 self.limit_categories
            //                 and self.iface_available_categ_ids
            //                 and [("id", "in", self.iface_available_categ_ids._get_descendants().ids)]
            //                 or []
            //             ),
            //         ],
            //         order="sequence",
            //     )
            // )
            */
            return default;
        }

        public async Task<TEntity> GetAvailablePricelistsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_available_pricelists(self):
            // self.ensure_one()
            // return self.available_pricelist_ids if self.use_pricelist else self.pricelist_id
            */
            return default;
        }

        public async Task<TEntity> GetAvailableProductDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_available_product_domain(self):
            // domain = [
            //     *self.env['product.product']._check_company_domain(self.company_id),
            //     ('active', '=', True),
            //     ('available_in_pos', '=', True),
            //     ('sale_ok', '=', True),
            // ]
            // if self.limit_categories and self.iface_available_categ_ids:
            //     domain.append(('pos_categ_ids', 'in', self._get_available_categories().ids))
            // return domain
            */
            return default;
        }

        public async Task<TEntity> GetBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_balancing_account(self):
            // return (
            //     self.company_id.account_default_pos_receivable_account_id
            //     or self.env['res.partner']._fields['property_account_receivable_id'].get_company_dependent_fallback(self.env['res.partner'])
            //     or self.env['account.account']
            // )
            */
            return default;
        }

        public async Task<TEntity> GetCapturedPaymentsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_captured_payments_domain(self):
            // return [('session_id', 'in', self.ids), ('pos_order_id.state', 'in', ['paid', 'invoiced', 'done'])]
            */
            return default;
        }

        public async Task<TEntity> GetCategoriesAsync<TEntity>(IEnumerable<TEntity> entities, object categories) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_categories(self, categories):
            // # filters out unavailable external id
            // return [self.env.ref(category).id for category in categories if self.env.ref(category, raise_if_not_found=False)]
            */
            return default;
        }

        public async Task<TEntity> GetClosedOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_closed_orders(self):
            // return self.order_ids.filtered(lambda o: o.state not in ['draft', 'cancel'])
            */
            return default;
        }

        public async Task<TEntity> GetClosingControlDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def get_closing_control_data(self):
            // if not self.env.user.has_group('point_of_sale.group_pos_user'):
            //     raise AccessError(_("You don't have the access rights to get the point of sale closing control data."))
            // self.ensure_one()
            // orders = self._get_closed_orders()
            // payments = orders.payment_ids.filtered(lambda p: p.payment_method_id.type != "pay_later")
            // cash_payment_method_ids = self.payment_method_ids.filtered(lambda pm: pm.type == 'cash')
            // default_cash_payment_method_id = cash_payment_method_ids[0] if cash_payment_method_ids else None
            // default_cash_payments = payments.filtered(lambda p: p.payment_method_id == default_cash_payment_method_id) if default_cash_payment_method_id else []
            // total_default_cash_payment_amount = sum(default_cash_payments.mapped('amount')) if default_cash_payment_method_id else 0
            // non_cash_payment_method_ids = self.payment_method_ids - default_cash_payment_method_id if default_cash_payment_method_id else self.payment_method_ids
            // non_cash_payments_grouped_by_method_id = {pm: orders.payment_ids.filtered(lambda p: p.payment_method_id == pm) for pm in non_cash_payment_method_ids}
            // 
            // cash_in_count = 0
            // cash_out_count = 0
            // cash_in_out_list = []
            // for cash_move in self.sudo().statement_line_ids.sorted('create_date'):
            //     if cash_move.amount > 0:
            //         cash_in_count += 1
            //         name = f'Cash in {cash_in_count}'
            //     else:
            //         cash_out_count += 1
            //         name = f'Cash out {cash_out_count}'
            //     cash_in_out_list.append({
            //         'name': cash_move.payment_ref if cash_move.payment_ref else name,
            //         'amount': cash_move.amount
            //     })
            // 
            // return {
            //     'orders_details': {
            //         'quantity': len(orders),
            //         'amount': sum(orders.mapped('amount_total'))
            //     },
            //     'opening_notes': self.opening_notes,
            //     'default_cash_details': {
            //         'name': default_cash_payment_method_id.name,
            //         'amount': self.cash_register_balance_start
            //                   + total_default_cash_payment_amount
            //                   + sum(self.sudo().statement_line_ids.mapped('amount')),
            //         'opening': self.cash_register_balance_start,
            //         'payment_amount': total_default_cash_payment_amount,
            //         'moves': cash_in_out_list,
            //         'id': default_cash_payment_method_id.id
            //     } if default_cash_payment_method_id else {},
            //     'non_cash_payment_methods': [{
            //         'name': pm.name,
            //         'amount': sum(non_cash_payments_grouped_by_method_id[pm].mapped('amount')),
            //         'number': len(non_cash_payments_grouped_by_method_id[pm]),
            //         'id': pm.id,
            //         'type': pm.type,
            //     } for pm in non_cash_payment_method_ids],
            //     'is_manager': self.env.user.has_group("point_of_sale.group_pos_manager"),
            //     'amount_authorized_diff': self.config_id.amount_authorized_diff if self.config_id.set_maximum_difference else None
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCombineReceivableValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_combine_receivable_vals(self, payment_method, amount, amount_converted):
            // partial_vals = {
            //     'account_id': self._get_receivable_account(payment_method).id,
            //     'move_id': self.move_id.id,
            //     'name': '%s - %s' % (self.name, payment_method.name),
            //     'display_type': 'payment_term',
            // }
            // return self._debit_amounts(partial_vals, amount, amount_converted)
            */
            return default;
        }

        public async Task<TEntity> GetCombineStatementLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid journal_id, object amount, object payment_method) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_combine_statement_line_vals(self, journal_id, amount, payment_method):
            // return {
            //     'date': fields.Date.context_today(self),
            //     'amount': amount,
            //     'payment_ref': self.name,
            //     'pos_session_id': self.id,
            //     'journal_id': journal_id,
            //     'counterpart_account_id': self._get_receivable_account(payment_method).id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCustomerDisplayDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_customer_display_data(self):
            // self.ensure_one()
            // return {
            //     'config_id': self.id,
            //     'access_token': self.access_token,
            //     'type': self.customer_display_type,
            //     'has_bg_img': bool(self.customer_display_bg_img),
            //     'company_id': self.company_id.id,
            //     **({'proxy_ip': self._get_display_device_ip()} if self.customer_display_type != 'none' else {}),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCustomerDisplayTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_customer_display_types(self):
            // return [('none', 'None'), ('local', 'The same device'), ('remote', 'Another device'), ('proxy', 'An IOT-connected screen')]
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTipProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_default_tip_product(self):
            // tip_product_id = self.env.ref("point_of_sale.product_product_tip", raise_if_not_found=False)
            // if not tip_product_id or (tip_product_id.sudo().company_id and tip_product_id.sudo().company_id != self.env.company):
            //     tip_product_id = self.env['product.product'].search([('default_code', '=', 'TIPS')], limit=1)
            // return tip_product_id
            */
            return default;
        }

        public async Task<TEntity> GetDiffAccountMoveRefInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_diff_account_move_ref(self, payment_method):
            // return _('Closing difference in %(payment_method)s (%(session)s)', payment_method=payment_method.name, session=self.name)
            */
            return default;
        }

        public async Task<TEntity> GetDiffValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid payment_method_id, object diff_amount, object outstanding_account) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_diff_vals(self, payment_method_id, diff_amount, outstanding_account=False):
            // payment_method = self.env['pos.payment.method'].browse(payment_method_id)
            // diff_compare_to_zero = self.currency_id.compare_amounts(diff_amount, 0)
            // source_account = payment_method.outstanding_account_id or outstanding_account
            // destination_account = self.env['account.account']
            // 
            // if (diff_compare_to_zero > 0):
            //     destination_account = payment_method.journal_id.profit_account_id
            // elif (diff_compare_to_zero < 0):
            //     destination_account = payment_method.journal_id.loss_account_id
            // 
            // if (diff_compare_to_zero == 0 or not source_account):
            //     return False
            // 
            // amounts = self._update_amounts({'amount': 0, 'amount_converted': 0}, {'amount': diff_amount}, self.stop_at)
            // source_vals = self._debit_amounts({'account_id': source_account.id}, amounts['amount'], amounts['amount_converted'])
            // dest_vals = self._credit_amounts({'account_id': destination_account.id}, amounts['amount'], amounts['amount_converted'])
            // return [source_vals, dest_vals]
            */
            return default;
        }

        public async Task<TEntity> GetDisplayDeviceIpInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_display_device_ip(self):
            // self.ensure_one()
            // return self.proxy_ip
            */
            return default;
        }

        public async Task<TEntity> GetForbiddenChangeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_forbidden_change_fields(self):
            // forbidden_keys = ['module_pos_hr', 'module_pos_restaurant', 'available_pricelist_ids',
            //                   'limit_categories', 'iface_available_categ_ids', 'use_pricelist', 'module_pos_discount',
            //                   'payment_method_ids', 'iface_tipproduc']
            // return forbidden_keys
            */
            return default;
        }

        public async Task<TEntity> GetGroupPosManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_group_pos_manager(self):
            // return self.env.ref('point_of_sale.group_pos_manager')
            */
            return default;
        }

        public async Task<TEntity> GetGroupPosUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_group_pos_user(self):
            // return self.env.ref('point_of_sale.group_pos_user')
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLinesValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_values, object pos_order_line) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_invoice_lines_values(self, line_values, pos_order_line):
            // return {
            //     'product_id': line_values['product_id'].id,
            //     'quantity': line_values['quantity'],
            //     'discount': line_values['discount'],
            //     'price_unit': line_values['price_unit'],
            //     'name': line_values['name'],
            //     'tax_ids': [(6, 0, line_values['tax_ids'].ids)],
            //     'product_uom_id': line_values['uom_id'].id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePostContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_invoice_post_context(self):
            // return {"skip_invoice_sync": True}
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReceivableValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_invoice_receivable_vals(self, amount, amount_converted):
            // partial_vals = {
            //     'account_id': self.company_id.account_default_pos_receivable_account_id.id,
            //     'move_id': self.move_id.id,
            //     'name': _('From invoice payments'),
            //     'display_type': 'payment_term',
            // }
            // return self._credit_amounts(partial_vals, amount, amount_converted)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTotalListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_invoice_total_list(self):
            // invoice_list = []
            // for order in self.order_ids.filtered(lambda o: o.is_invoiced):
            //     invoice = {
            //         'total': order.account_move.amount_total,
            //         'name': order.account_move.name,
            //         'order_ref': order.pos_reference,
            //     }
            //     invoice_list.append(invoice)
            // 
            // return invoice_list
            */
            return default;
        }

        public async Task<TEntity> GetLimitedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_limited_partner_count(self):
            // default_limit = 100
            // config_param = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.limited_customer_count', default_limit)
            // try:
            //     return int(config_param)
            // except (TypeError, ValueError, OverflowError):
            //     return default_limit
            */
            return default;
        }

        public async Task<TEntity> GetLimitedPartnersLoadingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_limited_partners_loading(self):
            // return self.env.execute_query(SQL("""
            //     WITH pm AS
            //     (
            //              SELECT   partner_id,
            //                       Count(partner_id) order_count
            //              FROM     pos_order
            //              GROUP BY partner_id)
            //     SELECT    id
            //     FROM      res_partner AS partner
            //     LEFT JOIN pm
            //     ON        (
            //                         partner.id = pm.partner_id)
            //     WHERE (
            //         partner.company_id=%s OR partner.company_id IS NULL
            //     )
            //     ORDER BY  COALESCE(pm.order_count, 0) DESC,
            //               NAME limit %s;
            // """, self.company_id.id, self._get_limited_partner_count()))
            */
            return default;
        }

        public async Task<TEntity> GetLimitedProductCountAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_limited_product_count(self):
            // default_limit = 20000
            // config_param = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.limited_product_count', default_limit)
            // try:
            //     return int(config_param)
            // except (TypeError, ValueError, OverflowError):
            //     return default_limit
            */
            return default;
        }

        public async Task<TEntity> GetLimitedProductsLoadingAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_limited_products_loading(self, fields):
            // query = self.env['product.product']._where_calc(
            //     self._get_available_product_domain()
            // )
            // sql = SQL(
            //     """
            //     WITH pm AS (
            //           SELECT product_id,
            //                  MAX(write_date) date
            //             FROM stock_move_line
            //         GROUP BY product_id
            //     )
            //        SELECT product_product.id
            //          FROM %s
            //     LEFT JOIN pm ON product_product.id=pm.product_id
            //         WHERE %s
            //      ORDER BY product_product__product_tmpl_id.is_favorite DESC,
            //               CASE WHEN product_product__product_tmpl_id.type = 'service' THEN 1 ELSE 0 END DESC,
            //               pm.date DESC NULLS LAST,
            //               product_product.write_date DESC
            //         LIMIT %s
            //     """,
            //     query.from_clause,
            //     query.where_clause or SQL("TRUE"),
            //     self.get_limited_product_count(),
            // )
            // product_ids = [r[0] for r in self.env.execute_query(sql)]
            // product_ids.extend(self._get_special_products().ids)
            // products = self.env['product.product'].search([('id', 'in', product_ids)])
            // # sort products by product_ids order
            // id_to_index = {pid: index for index, pid in enumerate(product_ids)}
            // products = products.sorted(key=lambda p: id_to_index[p.id])
            // product_combo = products.filtered(lambda p: p['type'] == 'combo')
            // product_in_combo = product_combo.combo_ids.combo_item_ids.product_id
            // products_available = products | product_in_combo
            // return products_available.read(fields, load=False)
            */
            return default;
        }

        public async Task<TEntity> GetOpenOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_open_order(self, order):
            // return self.env["pos.order"].search([('uuid', '=', order.get('uuid'))], limit=1)
            */
            return default;
        }

        protected async Task<object> GetOrderLogRepresentationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_order_log_representation(order):
            // return dict((k, order.get(k)) for k in ("name", "uuid"))
            */
            return default;
        }

        public async Task<TEntity> GetOtherRelatedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_other_related_moves(self):
            // # TODO This is not an ideal way to get the diff account.move's for
            // # the session. It would be better if there is a relation field where
            // # these moves are saved.
            // 
            // # Unfortunately, the 'ref' of account.move is not indexed, so
            // # we are querying over the account.move.line because its 'ref' is indexed.
            // # And yes, we are only concern for split bank payment methods.
            // diff_lines_ref = [self._get_diff_account_move_ref(pm) for pm in self.payment_method_ids if pm.type == 'bank' and pm.split_transactions]
            // cost_move_lines = ['pos_order_'+str(rec.id) for rec in self._get_closed_orders()]
            // return self.env['account.move.line'].search([('ref', 'in', diff_lines_ref + cost_move_lines)]).mapped('move_id')
            */
            return default;
        }

        public async Task<TEntity> GetPartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_partner_bank_id(self):
            // bank_partner_id = False
            // if self.amount_total <= 0 and self.partner_id.bank_ids:
            //     bank_partner_id = self.partner_id.bank_ids[0].id
            // elif self.amount_total >= 0 and self.company_id.partner_id.bank_ids:
            //     bank_partner_id = self.company_id.partner_id.bank_ids[0].id
            // return bank_partner_id
            */
            return default;
        }

        public async Task<TEntity> GetPartnersDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_partners_domain(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_payment_method(self, payment_type):
            // for pm in self.payment_method_ids:
            //     if pm.type == payment_type:
            //         return pm
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetPosAngloSaxonPriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, Guid partner_id, object quantity) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_pos_anglo_saxon_price_unit(self, product, partner_id, quantity):
            // moves = self.filtered(lambda o: o.partner_id.id == partner_id)\
            //     .mapped('picking_ids.move_ids')\
            //     ._filter_anglo_saxon_moves(product)\
            //     .sorted(lambda x: x.date)
            // price_unit = product.with_company(self.company_id)._compute_average_price(0, quantity, moves)
            // return price_unit
            */
            return default;
        }

        public async Task<TEntity> GetPosFallbackNomenclatureIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_pos_fallback_nomenclature_id(self):
            // """
            // Retrieve the fallback barcode nomenclature.
            // If a fallback_nomenclature_id is specified in the config parameters,
            // it retrieves the nomenclature with that ID. Otherwise, it retrieves
            // the first non-GS1 nomenclature if the main nomenclature is GS1.
            // """
            // def convert_to_int(string_value):
            //     try:
            //         return int(string_value)
            //     except (TypeError, ValueError, OverflowError):
            //         return None
            // 
            // fallback_nomenclature_id = self.env['ir.config_parameter'].sudo().get_param('point_of_sale.fallback_nomenclature_id')
            // 
            // if not self.company_id.nomenclature_id.is_gs1_nomenclature and not fallback_nomenclature_id:
            //     return None
            // 
            // if fallback_nomenclature_id:
            //     fallback_nomenclature_id = convert_to_int(fallback_nomenclature_id)
            //     if not fallback_nomenclature_id or self.company_id.nomenclature_id.id == fallback_nomenclature_id:
            //         return None
            //     domain = [('id', '=', fallback_nomenclature_id)]
            // else:
            //     domain = [('is_gs1_nomenclature', '=', False)]
            // 
            // record = self.env['barcode.nomenclature'].search(domain=domain, limit=1)
            // 
            // return record.id if record else None
            */
            return default;
        }

        public async Task<TEntity> GetPosKanbanViewStateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_pos_kanban_view_state(self):
            // has_pos_config = bool(self.env['pos.config'].search_count(
            //     self._check_company_domain(self.env.company)
            // ))
            // has_chart_template = bool(self.env.company.chart_template)
            // main_company = self.env.ref('base.main_company', raise_if_not_found=False)
            // return {
            //     "has_pos_config": has_pos_config,
            //     "has_chart_template": has_chart_template,
            //     "is_restaurant_installed": bool(self.env['ir.module.module'].search_count([('name', '=', 'pos_restaurant'), ('state', '=', 'installed')])),
            //     "is_main_company": main_company and self.env.company.id == main_company.id or False
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPosUiProductPricelistItemByProductAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_tmpl_ids, List<Guid> product_ids, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def get_pos_ui_product_pricelist_item_by_product(self, product_tmpl_ids, product_ids, config_id):
            // pricelist_item_fields = self.env['product.pricelist.item']._load_pos_data_fields(config_id)
            // 
            // pricelist_item_domain = [
            //     '&',
            //     ('pricelist_id', 'in', self.config_id._get_available_pricelists().ids),
            //     *self.env['product.pricelist.item']._check_company_domain(self.company_id),
            //     '|',
            //     '&', ('product_id', '=', False), ('product_tmpl_id', 'in', product_tmpl_ids),
            //     ('product_id', 'in', product_ids)
            // ]
            // 
            // pricelist_item = self.env['product.pricelist.item'].search(pricelist_item_domain)
            // 
            // return {'product.pricelist.item': pricelist_item.read(pricelist_item_fields, load=False)}
            */
            return default;
        }

        public async Task<TEntity> GetReceivableAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_receivable_account(self, payment_method):
            // """Returns the default pos receivable account if no receivable_account_id is set on the payment method."""
            // return payment_method.receivable_account_id or self.company_id.account_default_pos_receivable_account_id
            */
            return default;
        }

        public async Task<TEntity> GetRecordsAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def get_records(self, data):
            // records = {}
            // for model, ids in data.items():
            //     records[model] = self.env[model].browse(ids).read(self.env[model]._load_pos_data_fields(self.id), load=False)
            // return records
            */
            return default;
        }

        public async Task<TEntity> GetRefundedOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_refunded_orders(self, order):
            // refunded_orderline_ids = [line[2]['refunded_orderline_id'] for line in order['lines'] if line[0] in [0, 1] and line[2].get('refunded_orderline_id')]
            // return self.env['pos.order.line'].browse(refunded_orderline_ids).mapped('order_id')
            */
            return default;
        }

        public async Task<TEntity> GetRelatedAccountMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_related_account_moves(self):
            // pickings = self.picking_ids | self._get_closed_orders().mapped('picking_ids')
            // invoices = self.mapped('order_ids.account_move')
            // invoice_payments = self.mapped('order_ids.payment_ids.account_move_id')
            // stock_account_moves = pickings.mapped('move_ids.account_move_ids')
            // cash_moves = self.statement_line_ids.mapped('move_id')
            // bank_payment_moves = self.bank_payment_ids.mapped('move_id')
            // other_related_moves = self._get_other_related_moves()
            // return invoices | invoice_payments | self.move_id | stock_account_moves | cash_moves | bank_payment_moves | other_related_moves
            */
            return default;
        }

        public async Task<TEntity> GetRoundedAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object force_round) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_rounded_amount(self, amount, force_round=False):
            // # TODO: add support for mix of cash and non-cash payments when both cash_rounding and only_round_cash_method are True
            // if self.config_id.cash_rounding \
            //    and (force_round or (not self.config_id.only_round_cash_method \
            //    or any(p.payment_method_id.is_cash_count for p in self.payment_ids))):
            //     amount = float_round(amount, precision_rounding=self.config_id.rounding_method.rounding, rounding_method=self.config_id.rounding_method.rounding_method)
            // currency = self.currency_id
            // return currency.round(amount) if currency else amount
            */
            return default;
        }

        public async Task<TEntity> GetRoundingDifferenceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_rounding_difference_vals(self, amount, amount_converted):
            // if self.config_id.cash_rounding:
            //     partial_args = {
            //         'name': 'Rounding line',
            //         'move_id': self.move_id.id,
            //     }
            //     if float_compare(0.0, amount, precision_rounding=self.currency_id.rounding) > 0:    # loss
            //         partial_args['account_id'] = self.config_id.rounding_method.loss_account_id.id
            //         return self._debit_amounts(partial_args, -amount, -amount_converted)
            // 
            //     if float_compare(0.0, amount, precision_rounding=self.currency_id.rounding) < 0:   # profit
            //         partial_args['account_id'] = self.config_id.rounding_method.profit_account_id.id
            //         return self._credit_amounts(partial_args, amount, amount_converted)
            */
            return default;
        }

        public async Task<TEntity> GetSaleValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key, object sale_vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_sale_vals(self, key, sale_vals):
            // account_id, sign, tax_ids, base_tag_ids, product_id = key
            // amount = sale_vals['amount']
            // amount_converted = sale_vals['amount_converted']
            // applied_taxes = self.env['account.tax'].browse(tax_ids)
            // if product_id:
            //     product = self.env['product.product'].browse(product_id)
            //     product_name = product.display_name
            //     product_uom = product.uom_id.id
            // else:
            //     product_name = ""
            //     product_uom = False
            // title = _('Sales') if sign == 1 else _('Refund')
            // name = _('%s untaxed', title)
            // if applied_taxes:
            //     name = _('%(title)s %(product_name)s with %(taxes)s', title=title, product_name=product_name, taxes=', '.join([tax.name for tax in applied_taxes]))
            // partial_vals = {
            //     'name': name,
            //     'account_id': account_id,
            //     'move_id': self.move_id.id,
            //     'tax_ids': [(6, 0, tax_ids)],
            //     'tax_tag_ids': [(6, 0, base_tag_ids)],
            //     'product_id': product_id,
            //     'display_type': 'product',
            //     'product_uom_id': product_uom,
            //     'currency_id': self.currency_id.id,
            //     'amount_currency': amount,
            //     'balance': amount_converted,
            // }
            // if partial_vals.get('product_id'):
            //     partial_vals['quantity'] = sale_vals.get('quantity', 1.00) * sign
            // return partial_vals
            */
            return default;
        }

        public async Task<TEntity> GetSessionOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def get_session_orders(self):
            // return self.order_ids
            */
            return default;
        }

        public async Task<TEntity> GetSpecialProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_special_products(self):
            // return self.env.ref('point_of_sale.product_product_tip', raise_if_not_found=False) or self.env['product.product']
            */
            return default;
        }

        public async Task<TEntity> GetSplitReceivableValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_split_receivable_vals(self, payment, amount, amount_converted):
            // accounting_partner = self.env["res.partner"]._find_accounting_partner(payment.partner_id)
            // if not accounting_partner:
            //     raise UserError(_("You have enabled the \"Identify Customer\" option for %(payment_method)s payment method,"
            //                       "but the order %(order)s does not contain a customer.",
            //                       payment_method=payment.payment_method_id.name,
            //                       order=payment.pos_order_id.name))
            // partial_vals = {
            //     'account_id': accounting_partner.property_account_receivable_id.id,
            //     'move_id': self.move_id.id,
            //     'partner_id': accounting_partner.id,
            //     'name': '%s - %s' % (self.name, payment.payment_method_id.name),
            // }
            // return self._debit_amounts(partial_vals, amount, amount_converted)
            */
            return default;
        }

        public async Task<TEntity> GetSplitStatementLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid journal_id, object amount, object payment) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_split_statement_line_vals(self, journal_id, amount, payment):
            // accounting_partner = self.env["res.partner"]._find_accounting_partner(payment.partner_id)
            // return {
            //     'date': fields.Date.context_today(self, timestamp=payment.payment_date),
            //     'amount': amount,
            //     'payment_ref': payment.name,
            //     'pos_session_id': self.id,
            //     'journal_id': journal_id,
            //     'counterpart_account_id': accounting_partner.property_account_receivable_id.id,
            //     'partner_id': accounting_partner.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetStockExpenseValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exp_account, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_stock_expense_vals(self, exp_account, amount, amount_converted):
            // partial_args = {'account_id': exp_account.id, 'move_id': self.move_id.id}
            // return self._debit_amounts(partial_args, amount, amount_converted, force_company_currency=True)
            */
            return default;
        }

        public async Task<TEntity> GetStockOutputValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object out_account, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_stock_output_vals(self, out_account, amount, amount_converted):
            // partial_args = {'account_id': out_account.id, 'move_id': self.move_id.id}
            // return self._credit_amounts(partial_args, amount, amount_converted, force_company_currency=True)
            */
            return default;
        }

        public async Task<TEntity> GetSuffixedRefNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ref_name) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _get_suffixed_ref_name(self, ref_name):
            // """Suffix the given ref_name with the id of the current company if it's not the main company."""
            // main_company = self.env.ref('base.main_company', raise_if_not_found=False)
            // if main_company and self.env.company.id == main_company.id:
            //     return ref_name
            // else:
            //     return f"{ref_name}_{self.env.company.id}"
            */
            return default;
        }

        public async Task<TEntity> GetTaxValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key, object amount, object amount_converted, object base_amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_tax_vals(self, key, amount, amount_converted, base_amount_converted):
            // account_id, repartition_line_id, tag_ids = key
            // tax_rep = self.env['account.tax.repartition.line'].browse(repartition_line_id)
            // tax = tax_rep.tax_id
            // return {
            //     'name': tax.name,
            //     'account_id': account_id,
            //     'move_id': self.move_id.id,
            //     'tax_base_amount': abs(base_amount_converted),
            //     'tax_repartition_line_id': repartition_line_id,
            //     'tax_tag_ids': [(6, 0, tag_ids)],
            //     'display_type': 'tax',
            //     'currency_id': self.currency_id.id,
            //     'amount_currency': amount,
            //     'balance': amount_converted,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTotalDiscountAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def get_total_discount(self):
            // amount = 0
            // for line in self.env['pos.order.line'].search([('order_id', 'in', self._get_closed_orders().ids), ('discount', '>', 0)]):
            //     amount += line._get_discount_amount()
            // 
            // return amount
            */
            return default;
        }

        public async Task<TEntity> GetTotalInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _get_total_invoice(self):
            // amount = 0
            // for order in self.order_ids.filtered(lambda o: o.is_invoiced):
            //     amount += order.amount_paid
            // 
            // return amount
            */
            return default;
        }

        public async Task<TEntity> GetValidSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_valid_session(self, order):
            // PosSession = self.env['pos.session']
            // closed_session = PosSession.browse(order['session_id'])
            // 
            // _logger.warning('Session %s (ID: %s) was closed but received order %s (total: %s) belonging to it',
            //                 closed_session.name,
            //                 closed_session.id,
            //                 order['name'],
            //                 order['amount_total'])
            // 
            // open_session = PosSession.search([
            //     ('state', 'not in', ('closed', 'closing_control')),
            //     ('config_id', '=', closed_session.config_id.id)
            // ], limit=1)
            // 
            // if open_session:
            //     _logger.warning('Using open session %s for saving order %s', open_session.name, order['name'])
            //     return open_session
            // 
            // raise UserError(_('No open session available. Please open a new session to capture the order.'))
            */
            return default;
        }

        public async Task<TEntity> InstallPosRestaurantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def install_pos_restaurant(self):
            // pos_restaurant_module = self.env['ir.module.module'].search([('name', '=', 'pos_restaurant')])
            // pos_restaurant_module.button_immediate_install()
            // return {'installed_with_demo': pos_restaurant_module.demo}
            */
            return default;
        }

        public async Task<TEntity> IsJournalExistInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal_code, object name, Guid company_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _is_journal_exist(self, journal_code, name, company_id):
            // account_journal = self.env['account.journal']
            // existing_journal = account_journal.search([
            //     ('name', '=', name),
            //     ('code', '=', journal_code),
            //     ('company_id', '=', company_id),
            // ], limit=1)
            // 
            // return existing_journal.id or account_journal.create({
            //     'name': name,
            //     'code': journal_code,
            //     'type': 'cash',
            //     'company_id': company_id,
            // }).id
            */
            return default;
        }

        public async Task<TEntity> IsPosOrderPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _is_pos_order_paid(self):
            // amount_total = self.amount_total
            // # If we are checking if a refund was paid and if it was a total refund, we take into account the amount paid on
            // # the original order. For a pertial refund, we take into account the value of the items returned.
            // if float_is_zero(self.refunded_order_id.amount_total + amount_total, precision_rounding=self.currency_id.rounding):
            //     amount_total = -self.refunded_order_id.amount_paid
            // return float_is_zero(self._get_rounded_amount(amount_total) - self.amount_paid, precision_rounding=self.currency_id.rounding)
            */
            return default;
        }

        public async Task<TEntity> IsPosPmExistInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid journal_id, Guid company_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _is_pos_pm_exist(self, name, journal_id, company_id):
            // pos_payment = self.env['pos.payment.method']
            // existing_pos_cash_pm = pos_payment.search([
            //     ('name', '=', name),
            //     ('journal_id', '=', journal_id),
            //     ('company_id', '=', company_id),
            // ], limit=1)
            // 
            // return existing_pos_cash_pm.id or pos_payment.create({
            //     'name': name,
            //     'journal_id': journal_id,
            //     'company_id': company_id,
            // }).id
            */
            return default;
        }

        public async Task<TEntity> KeepNewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _keep_new_vals(self, vals):
            // """ Keep values in vals that are different than
            // self's values.
            // """
            // from_settings_view = self.env.context.get('from_settings_view')
            // if not from_settings_view:
            //     return vals
            // new_vals = {}
            // for field, val in vals.items():
            //     config_field = self._fields.get(field)
            //     if config_field:
            //         cache_value = config_field.convert_to_cache(val, self)
            //         record_value = config_field.convert_to_record(cache_value, self)
            //         if record_value != self[field]:
            //             new_vals[field] = val
            // return new_vals
            */
            return default;
        }

        public async Task<TEntity> LinkComboItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combo_child_uuids_by_parent_uuid) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _link_combo_items(self, combo_child_uuids_by_parent_uuid):
            // self.ensure_one()
            // 
            // for parent_uuid, child_uuids in combo_child_uuids_by_parent_uuid.items():
            //     parent_line = self.lines.filtered(lambda line: line.uuid == parent_uuid)
            //     if not parent_line:
            //         continue
            //     parent_line.combo_line_ids = [(6, 0, self.lines.filtered(lambda line: line.uuid in child_uuids).ids)]
            */
            return default;
        }

        public async Task<TEntity> LinkSameNonCashPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source_config) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _link_same_non_cash_payment_methods(self, source_config):
            // pms = source_config.payment_method_ids.filtered(lambda pm: not pm.is_cash_count)
            // if pms:
            //     self.payment_method_ids = [Command.link(pm.id) for pm in pms]
            */
            return default;
        }

        public async Task<TEntity> LoadDataAsync<TEntity>(IEnumerable<TEntity> entities, object models_to_load, object only_data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def load_data(self, models_to_load, only_data=False):
            // response = {}
            // response['pos.session'] = self._load_pos_data(response)
            // self._load_pos_data_relations('pos.session', response)
            // 
            // for model in self._load_pos_data_models(self.config_id.id):
            //     if models_to_load and model not in models_to_load:
            //         continue
            // 
            //     try:
            //         response[model] = self.env[model]._load_pos_data(response)
            //     except AccessError as e:
            //         response[model] = {
            //             'data': [],
            //             'fields': self.env[model]._load_pos_data_fields(response['pos.config']['data'][0]['id']),
            //             'error': e.args[0]
            //         }
            // 
            //     if not only_data:
            //         self._load_pos_data_relations(model, response)
            // 
            // return response
            */
            return default;
        }

        public async Task<TEntity> LoadFurnitureDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_furniture_data(self):
            // if not self.env.user.has_group('base.group_system'):
            //     raise AccessError(_("You must have 'Administration Settings' access to load furniture data."))
            // product_module = self.env['ir.module.module'].search([('name', '=', 'product')])
            // if not product_module.demo:
            //     convert.convert_file(self.env, 'product', 'data/product_category_demo.xml', None, noupdate=True, mode='init', kind='data')
            //     convert.convert_file(self.env, 'product', 'data/product_attribute_demo.xml', None, noupdate=True, mode='init', kind='data')
            //     convert.convert_file(self.env, 'product', 'data/product_demo.xml', None, noupdate=True, mode='init', kind='data')
            // 
            // convert.convert_file(self.env, 'point_of_sale', 'data/scenarios/furniture_data.xml', None, noupdate=True, mode='init', kind='data')
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingBakeryScenarioAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_bakery_scenario(self):
            // ref_name = 'point_of_sale.pos_config_bakery'
            // if not self.env.ref(ref_name, raise_if_not_found=False):
            //     convert.convert_file(self.env, 'point_of_sale', 'data/scenarios/bakery_data.xml', None, mode='init', noupdate=True, kind='data')
            // 
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(cash_journal_vals={'name': _("Cash Bakery"), 'show_on_dashboard': False})
            // bakery_categories = self.get_categories([
            //     'point_of_sale.pos_category_breads',
            //     'point_of_sale.pos_category_pastries',
            // ])
            // config = self.env['pos.config'].create({
            //     'name': _('Bakery Shop'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'limit_categories': True,
            //     'iface_available_categ_ids': bakery_categories,
            // })
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name(ref_name),
            //     'record': config,
            //     'noupdate': True,
            // }])
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingClothesScenarioAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_clothes_scenario(self):
            // if not self.env.user.has_group('base.group_system'):
            //     raise AccessError(_("You must have 'Administration Settings' access to load clothes data."))
            // ref_name = 'point_of_sale.pos_config_clothes'
            // if not self.env.ref(ref_name, raise_if_not_found=False):
            //     convert.convert_file(self.env, 'point_of_sale', 'data/scenarios/clothes_data.xml', None, noupdate=True, mode='init', kind='data')
            // 
            // clothes_categories = self.get_categories([
            //     'point_of_sale.pos_category_upper',
            //     'point_of_sale.pos_category_lower',
            //     'point_of_sale.pos_category_others'
            // ])
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(cash_journal_vals={'name': _("Cash Clothes Shop"), 'show_on_dashboard': False})
            // config = self.env['pos.config'].create([{
            //     'name': _('Clothes Shop'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'limit_categories': True,
            //     'iface_available_categ_ids': clothes_categories,
            // }])
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name(ref_name),
            //     'record': config,
            //     'noupdate': True,
            // }])
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingFurnitureScenarioAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def load_onboarding_furniture_scenario(self):
            // ref_name = 'point_of_sale.pos_config_main'
            // if not self.env.ref(ref_name, raise_if_not_found=False):
            //     self._load_furniture_data()
            // 
            // journal, payment_methods_ids = self._create_journal_and_payment_methods(
            //     cash_ref='point_of_sale.cash_payment_method_furniture',
            //     cash_journal_vals={'name': _("Cash Furn. Shop"), 'show_on_dashboard': False},
            // )
            // furniture_categories = self.get_categories([
            //     'point_of_sale.pos_category_miscellaneous',
            //     'point_of_sale.pos_category_desks',
            //     'point_of_sale.pos_category_chairs'
            // ])
            // config = self.env['pos.config'].create([{
            //     'name': _('Furniture Shop'),
            //     'company_id': self.env.company.id,
            //     'journal_id': journal.id,
            //     'payment_method_ids': payment_methods_ids,
            //     'limit_categories': True,
            //     'iface_available_categ_ids': furniture_categories,
            // }])
            // self.env['ir.model.data']._update_xmlids([{
            //     'xml_id': self._get_suffixed_ref_name(ref_name),
            //     'record': config,
            //     'noupdate': True,
            // }])
            // if self.env.company.id == self.env.ref('base.main_company').id:
            //     existing_session = self.env.ref('point_of_sale.pos_closed_session_2', raise_if_not_found=False)
            //     if not existing_session:
            //         convert.convert_file(self.env, 'point_of_sale', 'data/orders_demo.xml', None, noupdate=True, mode='init', kind='data')
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('id', '=', data['pos.session']['data'][0]['config_id'])]
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('state', '=', 'draft'), ('session_id', '=', data['pos.session']['data'][0]['id'])]
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('id', '=', self.id)]
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return [
            //     'id', 'name', 'user_id', 'config_id', 'start_at', 'stop_at', 'sequence_number', 'login_number',
            //     'payment_method_ids', 'state', 'update_stock_at_closing', 'cash_register_balance_start', 'access_token'
            // ]
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _load_pos_data(self, data):
            // domain = self._load_pos_data_domain(data)
            // fields = self._load_pos_data_fields(self.id)
            // data = self.search_read(domain, fields, load=False)
            // 
            // if not data[0]['use_pricelist']:
            //     data[0]['pricelist_id'] = False
            // 
            // return {
            //     'data': data,
            //     'fields': fields,
            // }
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _load_pos_data(self, data):
            // domain = self._load_pos_data_domain(data)
            // fields = self._load_pos_data_fields(self.config_id.id)
            // data = self.search_read(domain, fields, load=False, limit=1)
            // data[0]['_partner_commercial_fields'] = self.env['res.partner']._commercial_fields()
            // data[0]['_server_version'] = exp_version()
            // data[0]['_base_url'] = self.get_base_url()
            // data[0]['_has_cash_move_perm'] = self.env.user.has_group('account.group_account_invoice')
            // data[0]['_has_available_products'] = self._pos_has_valid_product()
            // data[0]['_pos_special_products_ids'] = self.env['pos.config']._get_special_products().ids
            // return {
            //     'data': data,
            //     'fields': fields
            // }
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _load_pos_data_models(self, config_id):
            // return ['pos.config', 'pos.order', 'pos.order.line', 'pos.pack.operation.lot', 'pos.payment', 'pos.payment.method', 'pos.printer',
            //                 'pos.category', 'pos.bill', 'res.company', 'account.tax', 'account.tax.group', 'product.product', 'product.template.attribute.line', 'product.attribute',
            //     'product.attribute.custom.value', 'product.template.attribute.value', 'product.combo', 'product.combo.item', 'product.packaging', 'res.users', 'res.partner',
            //     'decimal.precision', 'uom.uom', 'uom.category', 'res.country', 'res.country.state', 'res.lang', 'product.pricelist', 'product.pricelist.item', 'product.category',
            //     'account.cash.rounding', 'account.fiscal.position', 'account.fiscal.position.tax', 'stock.picking.type', 'res.currency', 'pos.note', 'ir.ui.view', 'product.tag', 'ir.module.module']
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataRelationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object response) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _load_pos_data_relations(self, model, response):
            // model_fields = self.env[model]._fields
            // 
            // if not response[model].get('relations'):
            //     response[model]['relations'] = {}
            // 
            // for name, params in model_fields.items():
            //     fields_count = len(response[model]['fields'])
            //     if (fields_count and name not in response[model]['fields']) or (params.manual and not fields_count):
            //         continue
            // 
            //     if params.comodel_name:
            //         response[model]['relations'][name] = {
            //             'name': name,
            //             'model': params.model_name,
            //             'compute': bool(params.compute),
            //             'related': bool(params.related),
            //             'relation': params.comodel_name,
            //             'type': params.type,
            //         }
            //         if params.type == 'one2many' and params.inverse_name:
            //             response[model]['relations'][name]['inverse_name'] = params.inverse_name
            //         if params.type == 'many2many':
            //             response[model]['relations'][name]['relation_table'] = self.env[model]._fields[name].relation
            //     else:
            //         response[model]['relations'][name] = {
            //             'name': name,
            //             'type': params.type,
            //             'compute': bool(params.compute),
            //             'related': bool(params.related),
            //         }
            */
            return default;
        }

        public async Task<TEntity> LogPartnerMessageAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id, object action, object message_type) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def log_partner_message(self, partner_id, action, message_type):
            // if message_type == 'ACTION_CANCELLED':
            //     body = 'Action cancelled ({ACTION})'.format(ACTION=action)
            // elif message_type == 'CASH_DRAWER_ACTION':
            //     body = 'Cash drawer opened ({ACTION})'.format(ACTION=action)
            // 
            // self.message_post(body=body, author_id=partner_id)
            */
            return default;
        }

        public async Task<TEntity> LoginAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def login(self):
            // self.ensure_one()
            // # FIX for stable version, we cannot modify the actual login_number field
            // code = f"pos.session.login_number{self.id}"
            // session_seq = self.env['ir.sequence'].search_count([('code', '=', code)])
            // if not session_seq:
            //     self.env['ir.sequence'].create({
            //         'name': f"POS Session {self.id}",
            //         'code': code,
            //         'company_id': self.company_id.id,
            //     })
            // return self.env['ir.sequence'].next_by_code(code)
            */
            return default;
        }

        public async Task<TEntity> MarkupListMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _markup_list_message(self, message):
            // body = Markup("<ul>")
            // for line in message:
            //     body += Markup("<li>")
            //     body += line
            //     body += Markup("</li>")
            // body += Markup("</ul>")
            // return body
            */
            return default;
        }

        public async Task<TEntity> NotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_bus_mixin.py) ---
            // def _notify(self, *notifications, private=True) -> None:
            // """ Send a notification to the bus.
            // ex: one notification: ``self._notify('STATUS', {'status': 'closed'})``
            // multiple notifications: ``self._notify(('STATUS', {'status': 'closed'}), ('TABLE_ORDER_COUNT', {'count': 2}))``
            // """
            // self.ensure_one()
            // self._ensure_access_token()
            // if isinstance(notifications[0], str):
            //     if len(notifications) != 2:
            //         raise ValueError("If you want to send a single notification, you must provide a name: str and a message: any")
            //     notifications = [notifications]
            // for name, message in notifications:
            //     self.env["bus.bus"]._sendone(
            //         self.access_token, f"{self.access_token}-{name}" if private else name, message
            //     )
            */
            return default;
        }

        public async Task<TEntity> NotifySynchronisationAsync<TEntity>(IEnumerable<TEntity> entities, Guid session_id, object login_number, object records) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def notify_synchronisation(self, session_id, login_number, records={}):
            // static_records = {}
            // 
            // for model, ids in records.items():
            //     fields = self.env[model]._load_pos_data_fields(self.id)
            //     static_records[model] = self.env[model].browse(ids).read(fields, load=False)
            // 
            // self._notify('SYNCHRONISATION', {
            //     'static_records': static_records,
            //     'session_id': session_id,
            //     'login_number': login_number,
            //     'records': records
            // })
            // 
            // for config in self.trusted_config_ids:
            //     config._notify('SYNCHRONISATION', {
            //         'static_records': static_records,
            //         'session_id': config.current_session_id.id,
            //         'login_number': 0,
            //         'records': records
            //     })
            */
            return default;
        }

        public async Task<TEntity> OnchangeAmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _onchange_amount_all(self):
            // self._compute_prices()
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _onchange_partner_id(self):
            // if self.partner_id:
            //     self.pricelist_id = self.partner_id.property_product_pricelist.id
            */
            return default;
        }

        public async Task<TEntity> OpenExistingSessionCbAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def open_existing_session_cb(self):
            // """ close session button
            // 
            // access session form to validate entries
            // """
            // self.ensure_one()
            // return self._open_session(self.current_session_id.id)
            */
            return default;
        }

        public async Task<TEntity> OpenFrontendCbAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def open_frontend_cb(self):
            // """Open the pos interface with config_id as an extra argument.
            // 
            // In vanilla PoS each user can only have one active session, therefore it was not needed to pass the config_id
            // on opening a session. It is also possible to login to sessions created by other users.
            // 
            // :returns: dict
            // """
            // if not self.ids:
            //     return {}
            // return self.config_id.open_ui()
            */
            return default;
        }

        public async Task<TEntity> OpenOpenedRescueSessionFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def open_opened_rescue_session_form(self):
            // rescue_session_ids = self.session_ids.filtered(lambda s: s.state != 'closed' and s.rescue)
            // 
            // if len(rescue_session_ids) == 1:
            //     return {
            //         'res_model': 'pos.session',
            //         'view_mode': 'form',
            //         'res_id': rescue_session_ids.id,
            //         'type': 'ir.actions.act_window',
            //     }
            // else:
            //     return {
            //         'name': _('Rescue Sessions'),
            //         'res_model': 'pos.session',
            //         'view_mode': 'list,form',
            //         'domain': [('id', 'in', rescue_session_ids.ids)],
            //         'type': 'ir.actions.act_window',
            //     }
            */
            return default;
        }

        public async Task<TEntity> OpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid session_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _open_session(self, session_id):
            // self._check_pricelists()  # The pricelist company might have changed after the first opening of the session
            // return {
            //     'name': _('Session'),
            //     'view_mode': 'form,list',
            //     'res_model': 'pos.session',
            //     'res_id': session_id,
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenUiAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def open_ui(self):
            // """Open the pos interface with config_id as an extra argument.
            // 
            // In vanilla PoS each user can only have one active session, therefore it was not needed to pass the config_id
            // on opening a session. It is also possible to login to sessions created by other users.
            // 
            // :returns: dict
            // """
            // self.ensure_one()
            // # In case of test environment, don't create the pdf
            // if self.env.uid == SUPERUSER_ID and not tools.config['test_enable']:
            //     raise UserError(_("You do not have permission to open a POS session. Please try opening a session with a different user"))
            // 
            // if not self.current_session_id:
            //     self._check_before_creating_new_session()
            // self._validate_fields(self._fields)
            // 
            // return self._action_to_open_ui()
            */
            return default;
        }

        public async Task<TEntity> PosHasValidProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _pos_has_valid_product(self):
            // return self.env['product.product'].sudo().search_count([('available_in_pos', '=', True), ('list_price', '>=', 0), ('id', 'not in', self.env['pos.config']._get_special_products().ids), '|', ('active', '=', False), ('active', '=', True)], limit=1) > 0
            */
            return default;
        }

        public async Task<TEntity> PostCashDetailsMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object state, object expected, object difference, object notes) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _post_cash_details_message(self, state, expected, difference, notes):
            // message = (state + " difference: " + self.currency_id.format(difference) + '\n' +
            //    state + " expected: " + self.currency_id.format(expected) + '\n' +
            //    state + " counted: " + self.currency_id.format(expected + difference) + '\n')
            // 
            // if notes:
            //     message += _('Opening control message: ')
            //     message += notes
            // if message:
            //     self.message_post(body=plaintext2html(message))
            */
            return default;
        }

        public async Task<TEntity> PostChatterMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _post_chatter_message(self, body):
            // self.message_post(body=body)
            */
            return default;
        }

        public async Task<TEntity> PostCloseRegisterMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def post_close_register_message(self):
            // self.message_post(body=_('Closed Register'))
            */
            return default;
        }

        public async Task<TEntity> PostClosingCashDetailsAsync<TEntity>(IEnumerable<TEntity> entities, object counted_cash) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def post_closing_cash_details(self, counted_cash):
            // """
            // Calling this method will try store the cash details during the session closing.
            // 
            // :param counted_cash: float, the total cash the user counted from its cash register
            // If successful, it returns {'successful': True}
            // Otherwise, it returns {'successful': False, 'message': str, 'redirect': bool}.
            // 'redirect' is a boolean used to know whether we redirect the user to the back end or not.
            // When necessary, error (i.e. UserError, AccessError) is raised which should redirect the user to the back end.
            // """
            // self.ensure_one()
            // check_closing_session = self._cannot_close_session()
            // if check_closing_session:
            //     open_order_ids = self.get_session_orders().filtered(lambda o: o.state == 'draft').ids
            //     check_closing_session['open_order_ids'] = open_order_ids
            //     return check_closing_session
            // 
            // if not self.cash_journal_id:
            //     # The user is blocked anyway, this user error is mostly for developers that try to call this function
            //     raise UserError(_("There is no cash register in this session."))
            // 
            // self.cash_register_balance_end_real = counted_cash
            // 
            // return {'successful': True}
            */
            return default;
        }

        public async Task<TEntity> PostStatementDifferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _post_statement_difference(self, amount):
            // if amount:
            //     if self.config_id.cash_control:
            //         st_line_vals = {
            //             'journal_id': self.cash_journal_id.id,
            //             'amount': amount,
            //             'date': self.statement_line_ids.sorted()[-1:].date or fields.Date.context_today(self),
            //             'pos_session_id': self.id,
            //         }
            // 
            //     if amount < 0.0:
            //         if not self.cash_journal_id.loss_account_id:
            //             raise UserError(
            //                 _('Please go on the %s journal and define a Loss Account. This account will be used to record cash difference.',
            //                   self.cash_journal_id.name))
            // 
            //         st_line_vals['payment_ref'] = _("Cash difference observed during the counting (Loss) - closing")
            //         st_line_vals['counterpart_account_id'] = self.cash_journal_id.loss_account_id.id
            //     else:
            //         # self.cash_register_difference  > 0.0
            //         if not self.cash_journal_id.profit_account_id:
            //             raise UserError(
            //                 _('Please go on the %s journal and define a Profit Account. This account will be used to record cash difference.',
            //                   self.cash_journal_id.name))
            // 
            //         st_line_vals['payment_ref'] = _("Cash difference observed during the counting (Profit) - closing")
            //         st_line_vals['counterpart_account_id'] = self.cash_journal_id.profit_account_id.id
            // 
            //     created_line = self.env['account.bank.statement.line'].create(st_line_vals)
            // 
            //     if created_line:
            //         created_line.move_id.message_post(body=_(
            //             "Related Session: %(link)s",
            //             link=self._get_html_link()
            //         ))
            */
            return default;
        }

        public async Task<TEntity> PrepareAccountBankStatementLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object sign, object amount, object reason, object extras) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _prepare_account_bank_statement_line_vals(self, session, sign, amount, reason, extras):
            // return {
            //     'pos_session_id': session.id,
            //     'journal_id': session.cash_journal_id.id,
            //     'amount': sign * amount,
            //     'date': fields.Date.context_today(self),
            //     'payment_ref': '-'.join([session.name, extras['translatedType'], reason]),
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareAmlValuesListPerNatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_aml_values_list_per_nature(self):
            // self.ensure_one()
            // AccountTax = self.env['account.tax']
            // sign = 1 if self.amount_total < 0 else -1
            // commercial_partner = self.partner_id.commercial_partner_id
            // company_currency = self.company_id.currency_id
            // rate = self.currency_id._get_conversion_rate(self.currency_id, company_currency, self.company_id, self.date_order)
            // 
            // # Concert each order line to a dictionary containing business values. Also, prepare for taxes computation.
            // base_lines = self._prepare_tax_base_line_values()
            // AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            // AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, self.company_id)
            // tax_results = AccountTax._prepare_tax_lines(base_lines, self.company_id)
            // 
            // total_balance = 0.0
            // total_amount_currency = 0.0
            // aml_vals_list_per_nature = defaultdict(list)
            // 
            // # Create the tax lines
            // for tax_line in tax_results['tax_lines_to_add']:
            //     tax_rep = self.env['account.tax.repartition.line'].browse(tax_line['tax_repartition_line_id'])
            //     aml_vals_list_per_nature['tax'].append({
            //         **tax_line,
            //         'tax_tag_invert': tax_rep.document_type == 'invoice',
            //     })
            //     total_amount_currency += tax_line['amount_currency']
            //     total_balance += tax_line['balance']
            // 
            // # Create the aml values for order lines.
            // for base_line_vals, update_base_line_vals in tax_results['base_lines_to_update']:
            //     order_line = base_line_vals['record']
            //     amount_currency = update_base_line_vals['amount_currency']
            //     balance = company_currency.round(amount_currency * rate)
            //     aml_vals_list_per_nature['product'].append({
            //         'name': order_line.full_product_name,
            //         'product_id': order_line.product_id.id,
            //         'quantity': order_line.qty * sign,
            //         'account_id': base_line_vals['account_id'].id,
            //         'partner_id': base_line_vals['partner_id'].id,
            //         'currency_id': base_line_vals['currency_id'].id,
            //         'tax_ids': [(6, 0, base_line_vals['tax_ids'].ids)],
            //         'tax_tag_ids': update_base_line_vals['tax_tag_ids'],
            //         'amount_currency': amount_currency,
            //         'balance': balance,
            //         'tax_tag_invert': not base_line_vals['is_refund'],
            //     })
            //     total_amount_currency += amount_currency
            //     total_balance += balance
            // 
            // # Cash rounding.
            // cash_rounding = self.config_id.rounding_method
            // if self.config_id.cash_rounding and cash_rounding and (not self.config_id.only_round_cash_method or any(p.payment_method_id.is_cash_count for p in self.payment_ids)):
            //     amount_currency = cash_rounding.compute_difference(self.currency_id, total_amount_currency)
            //     if not self.currency_id.is_zero(amount_currency):
            //         balance = company_currency.round(amount_currency * rate)
            // 
            //         if cash_rounding.strategy == 'biggest_tax':
            //             biggest_tax_aml_vals = None
            //             for aml_vals in aml_vals_list_per_nature['tax']:
            //                 if not biggest_tax_aml_vals or float_compare(-sign * aml_vals['amount_currency'], -sign * biggest_tax_aml_vals['amount_currency'], precision_rounding=self.currency_id.rounding) > 0:
            //                     biggest_tax_aml_vals = aml_vals
            //             if biggest_tax_aml_vals:
            //                 biggest_tax_aml_vals['amount_currency'] += amount_currency
            //                 biggest_tax_aml_vals['balance'] += balance
            //         elif cash_rounding.strategy == 'add_invoice_line':
            //             if -sign * amount_currency > 0.0 and cash_rounding.loss_account_id:
            //                 account_id = cash_rounding.loss_account_id.id
            //             else:
            //                 account_id = cash_rounding.profit_account_id.id
            //             aml_vals_list_per_nature['cash_rounding'].append({
            //                 'name': cash_rounding.name,
            //                 'account_id': account_id,
            //                 'partner_id': commercial_partner.id,
            //                 'currency_id': self.currency_id.id,
            //                 'amount_currency': amount_currency,
            //                 'balance': balance,
            //                 'display_type': 'rounding',
            //             })
            // 
            // # Stock.
            // if self.company_id.anglo_saxon_accounting and self.picking_ids.ids:
            //     stock_moves = self.env['stock.move'].sudo().search([
            //         ('picking_id', 'in', self.picking_ids.ids),
            //         ('product_id.categ_id.property_valuation', '=', 'real_time')
            //     ])
            //     for stock_move in stock_moves:
            //         expense_account = stock_move.product_id._get_product_accounts()['expense']
            //         stock_output_account = stock_move.product_id.categ_id.property_stock_account_output_categ_id
            //         balance = -sum(stock_move.stock_valuation_layer_ids.mapped('value'))
            //         aml_vals_list_per_nature['stock'].append({
            //             'name': _("Stock input for %s", stock_move.product_id.name),
            //             'account_id': expense_account.id,
            //             'partner_id': commercial_partner.id,
            //             'currency_id': self.company_id.currency_id.id,
            //             'amount_currency': balance,
            //             'balance': balance,
            //         })
            //         aml_vals_list_per_nature['stock'].append({
            //             'name': _("Stock output for %s", stock_move.product_id.name),
            //             'account_id': stock_output_account.id,
            //             'partner_id': commercial_partner.id,
            //             'currency_id': self.company_id.currency_id.id,
            //             'amount_currency': -balance,
            //             'balance': -balance,
            //         })
            // 
            // # sort self.payment_ids by is_split_transaction:
            // for payment_id in self.payment_ids:
            //     is_split_transaction = payment_id.payment_method_id.split_transactions
            //     if is_split_transaction:
            //         reversed_move_receivable_account_id = self.partner_id.property_account_receivable_id
            //     else:
            //         reversed_move_receivable_account_id = payment_id.payment_method_id.receivable_account_id or self.company_id.account_default_pos_receivable_account_id
            // 
            //     aml_vals_entry_found = [aml_entry for aml_entry in aml_vals_list_per_nature['payment_terms']
            //                             if aml_entry['account_id'] == reversed_move_receivable_account_id.id
            //                             and not aml_entry['partner_id']]
            // 
            //     if aml_vals_entry_found and not is_split_transaction:
            //         aml_vals_entry_found[0]['amount_currency'] += self.session_id._amount_converter(payment_id.amount, self.date_order, False)
            //         aml_vals_entry_found[0]['balance'] += payment_id.amount
            //     else:
            //         aml_vals_list_per_nature['payment_terms'].append({
            //             'partner_id': commercial_partner.id if is_split_transaction else False,
            //             'name': f"{reversed_move_receivable_account_id.code} {reversed_move_receivable_account_id.code}",
            //             'account_id': reversed_move_receivable_account_id.id,
            //             'currency_id': self.currency_id.id,
            //             'amount_currency': payment_id.amount,
            //             'balance': self.session_id._amount_converter(payment_id.amount, self.date_order, False),
            //         })
            // 
            // return aml_vals_list_per_nature
            */
            return default;
        }

        public async Task<TEntity> PrepareBalancingLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object imbalance_amount, object move, object balancing_account) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _prepare_balancing_line_vals(self, imbalance_amount, move, balancing_account):
            // partial_vals = {
            //     'name': _('Difference at closing PoS session'),
            //     'account_id': balancing_account.id,
            //     'move_id': move.id,
            //     'partner_id': False,
            // }
            // # `imbalance_amount` is already in terms of company currency so it is the amount_converted
            // # param when calling `_credit_amounts`. amount param will be the converted value of
            // # `imbalance_amount` from company currency to the session currency.
            // imbalance_amount_session = 0
            // if (not self.is_in_company_currency):
            //     imbalance_amount_session = self.company_id.currency_id._convert(imbalance_amount, self.currency_id, self.company_id, fields.Date.context_today(self))
            // return self._credit_amounts(partial_vals, imbalance_amount_session, imbalance_amount)
            */
            return default;
        }

        public async Task<TEntity> PrepareComboLineUuidsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order_vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_combo_line_uuids(self, order_vals):
            // acc = {}
            // lines = [line[2] for line in order_vals['lines'] if line[0] in [0, 1]]
            // 
            // for line in lines:
            //     if combo_line_ids := line.get('combo_line_ids'):
            //         acc[line['uuid']] = [l['uuid'] for l in lines if l.get('id') in combo_line_ids]
            // 
            //     line['combo_line_ids'] = False
            //     line['combo_parent_id'] = False
            // 
            // return acc
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_invoice_lines(self):
            // """ Prepare a list of orm commands containing the dictionaries to fill the
            // 'invoice_line_ids' field when creating an invoice.
            // 
            // :return: A list of Command.create to fill 'invoice_line_ids' when calling account.move.create.
            // """
            // line_values_list = self._prepare_tax_base_line_values()
            // invoice_lines = []
            // for line_values in line_values_list:
            //     line = line_values['record']
            //     invoice_lines_values = self._get_invoice_lines_values(line_values, line)
            //     if line.product_id.type == 'combo':
            //         quantity = int(invoice_lines_values['quantity']) if invoice_lines_values['quantity'] == int(invoice_lines_values['quantity']) else invoice_lines_values['quantity']
            //         invoice_lines.append(Command.create({
            //             'display_type': 'line_section',
            //             'name': f'{line.product_id.name} x {quantity}',
            //         }))
            //         continue
            // 
            //     invoice_lines.append((0, None, invoice_lines_values))
            //     is_percentage = self.pricelist_id and any(
            //         self.pricelist_id.item_ids.filtered(
            //             lambda rule: rule.compute_price == "percentage")
            //     )
            //     if is_percentage and float_compare(line.price_unit, line.product_id.lst_price, precision_rounding=self.currency_id.rounding) < 0:
            //         invoice_lines.append((0, None, {
            //             'name': _('Price discount from %(original_price)s to %(discounted_price)s',
            //                       original_price=float_repr(line.product_id.lst_price, self.currency_id.decimal_places),
            //                       discounted_price=float_repr(line.price_unit, self.currency_id.decimal_places)),
            //             'display_type': 'line_note',
            //         }))
            //     if line.customer_note:
            //         invoice_lines.append((0, None, {
            //             'name': line.customer_note,
            //             'display_type': 'line_note',
            //         }))
            // 
            // return invoice_lines
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_invoice_vals(self):
            // self.ensure_one()
            // timezone = pytz.timezone(self._context.get('tz') or self.env.user.tz or 'UTC')
            // invoice_date = fields.Datetime.now() if self.session_id.state == 'closed' else self.date_order
            // pos_refunded_invoice_ids = []
            // for orderline in self.lines:
            //     if orderline.refunded_orderline_id and orderline.refunded_orderline_id.order_id.account_move:
            //         pos_refunded_invoice_ids.append(orderline.refunded_orderline_id.order_id.account_move.id)
            // 
            // vals = {
            //     'invoice_origin': self.name,
            //     'pos_refunded_invoice_ids': pos_refunded_invoice_ids,
            //     'pos_order_ids': self.ids,
            //     'journal_id': self.session_id.config_id.invoice_journal_id.id,
            //     'move_type': 'out_invoice' if self.amount_total >= 0 else 'out_refund',
            //     'ref': self.name,
            //     'partner_id': self.partner_id.address_get(['invoice'])['invoice'],
            //     'partner_bank_id': self._get_partner_bank_id(),
            //     'currency_id': self.currency_id.id,
            //     'invoice_user_id': self.user_id.id,
            //     'invoice_date': invoice_date.astimezone(timezone).date(),
            //     'fiscal_position_id': self.fiscal_position_id.id,
            //     'invoice_line_ids': self._prepare_invoice_lines(),
            //     'invoice_payment_term_id': False,
            //     'invoice_cash_rounding_id': self.config_id.rounding_method.id,
            // }
            // if self.refunded_order_id.account_move:
            //     vals['ref'] = _('Reversal of: %s', self.refunded_order_id.account_move.name)
            //     vals['reversed_entry_id'] = self.refunded_order_id.account_move.id
            // if self.floating_order_name:
            //     vals.update({'narration': self.floating_order_name})
            // return vals
            */
            return default;
        }

        public async Task<TEntity> PrepareMailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_mail_values(self, email, ticket, basic_ticket):
            // message = Markup(
            //     _("<p>Dear %(client_name)s,<br/>Here is your Receipt %(is_invoiced)sfor \
            //     %(pos_name)s amounting in %(amount)s from %(company_name)s. </p>")
            // ) % {
            //     'client_name': self.partner_id.name or _('Customer'),
            //     'pos_name': self.name,
            //     'amount': self.currency_id.format(self.amount_total),
            //     'company_name': self.company_id.name,
            //     'is_invoiced': "and Invoice " if self.account_move else "",
            // }
            // 
            // return {
            //     'subject': _('Receipt %s', self.name),
            //     'body_html': message,
            //     'author_id': self.env.user.partner_id.id,
            //     'email_from': self.env.company.email or self.env.user.email_formatted,
            //     'email_to': email,
            //     'attachment_ids': self._add_mail_attachment(self.name, ticket, basic_ticket),
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareRefundValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object current_session) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_refund_values(self, current_session):
            // self.ensure_one()
            // return {
            //     'name': _('%(name)s REFUND', name=self.name),
            //     'session_id': current_session.id,
            //     'date_order': fields.Datetime.now(),
            //     'pos_reference': self.pos_reference,
            //     'lines': False,
            //     'amount_tax': -self.amount_tax,
            //     'amount_total': -self.amount_total,
            //     'amount_paid': 0,
            //     'is_total_cost_computed': False
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxBaseLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _prepare_tax_base_line_values(self):
            // """ Convert pos order lines into dictionaries that would be used to compute taxes later.
            // 
            // :param sign: An optional parameter to force the sign of amounts.
            // :return: A list of python dictionaries (see '_prepare_base_line_for_taxes_computation' in account.tax).
            // """
            // self.ensure_one()
            // return self.lines._prepare_tax_base_line_values()
            */
            return default;
        }

        public async Task<TEntity> PreprocessX2manyValsFromSettingsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _preprocess_x2many_vals_from_settings_view(self, vals):
            // """ From the res.config.settings view, changes in the x2many fields always result to an array of link commands or a single set command.
            //     - As a result, the items that should be unlinked are not properly unlinked.
            //     - So before doing the write, we inspect the commands to determine which records should be unlinked.
            //     - We only care about the link command.
            //     - We can consider set command as absolute as it will replace all.
            // """
            // from_settings_view = self.env.context.get('from_settings_view')
            // if not from_settings_view:
            //     # If vals is not from the settings view, we don't need to preprocess.
            //     return
            // 
            // # Only ensure one when write is from settings view.
            // self.ensure_one()
            // 
            // fields_to_preprocess = []
            // for f in self.fields_get([]).values():
            //     if f['type'] in ['many2many', 'one2many']:
            //         fields_to_preprocess.append(f['name'])
            // 
            // for x2many_field in fields_to_preprocess:
            //     if x2many_field in vals:
            //         linked_ids = set(self[x2many_field].ids)
            // 
            //         for command in vals[x2many_field]:
            //             if command[0] == 4:
            //                 _id = command[1]
            //                 if _id in linked_ids:
            //                     linked_ids.remove(_id)
            // 
            //         # Remaining items in linked_ids should be unlinked.
            //         unlink_commands = [Command.unlink(_id) for _id in linked_ids]
            // 
            //         vals[x2many_field] = unlink_commands + vals[x2many_field]
            */
            return default;
        }

        public async Task<TEntity> ProcessOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object existing_order) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _process_order(self, order, existing_order):
            // """Create or update an pos.order from a given dictionary.
            // 
            // :param dict order: dictionary representing the order.
            // :param existing_order: order to be updated or False.
            // :type existing_order: pos.order.
            // :returns: id of created/updated pos.order
            // :rtype: int
            // """
            // draft = True if order.get('state') == 'draft' else False
            // pos_session = self.env['pos.session'].browse(order['session_id'])
            // if pos_session.state == 'closing_control' or pos_session.state == 'closed':
            //     order['session_id'] = self._get_valid_session(order).id
            // 
            // if order.get('partner_id'):
            //     partner_id = self.env['res.partner'].browse(order['partner_id'])
            //     if not partner_id.exists():
            //         order.update({
            //             "partner_id": False,
            //             "to_invoice": False,
            //         })
            // 
            // pos_order = False
            // combo_child_uuids_by_parent_uuid = self._prepare_combo_line_uuids(order)
            // 
            // if not existing_order:
            //     pos_order = self.create({
            //         **{key: value for key, value in order.items() if key != 'name'},
            //         'pos_reference': order.get('name')
            //     })
            //     pos_order = pos_order.with_company(pos_order.company_id)
            // else:
            //     pos_order = existing_order
            // 
            //     # If the order is belonging to another session, it must be moved to the current session first
            //     if order.get('session_id') and order['session_id'] != pos_order.session_id.id:
            //         pos_order.write({'session_id': order['session_id']})
            // 
            //     # Save lines and payments before to avoid exception if a line is deleted
            //     # when vals change the state to 'paid'
            //     for field in ['lines', 'payment_ids']:
            //         if order.get(field):
            //             existing_record_ids = self.env[pos_order[field]._name].browse([r[1] for r in order[field] if r[1] != 0]).exists().ids
            //             existing_records_vals = [r for r in order[field] if r[0] not in [1, 2, 3, 4] or r[1] in existing_record_ids]
            //             pos_order.write({field: existing_records_vals})
            //             order[field] = []
            // 
            //     del order['uuid']
            //     del order['access_token']
            //     pos_order.write(order)
            // 
            // pos_order._link_combo_items(combo_child_uuids_by_parent_uuid)
            // self = self.with_company(pos_order.company_id)
            // self._process_payment_lines(order, pos_order, pos_session, draft)
            // return pos_order._process_saved_order(draft)
            */
            return default;
        }

        public async Task<TEntity> ProcessPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pos_order, object order, object pos_session, object draft) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _process_payment_lines(self, pos_order, order, pos_session, draft):
            // """Create account.bank.statement.lines from the dictionary given to the parent function.
            // 
            // If the payment_line is an updated version of an existing one, the existing payment_line will first be
            // removed before making a new one.
            // :param pos_order: dictionary representing the order.
            // :type pos_order: dict.
            // :param order: Order object the payment lines should belong to.
            // :type order: pos.order
            // :param pos_session: PoS session the order was created in.
            // :type pos_session: pos.session
            // :param draft: Indicate that the pos_order is not validated yet.
            // :type draft: bool.
            // """
            // prec_acc = order.currency_id.decimal_places
            // 
            // # Recompute amount paid because we don't trust the client
            // order.with_context(backend_recomputation=True).write({'amount_paid': sum(order.payment_ids.mapped('amount'))})
            // 
            // if not draft and not float_is_zero(pos_order['amount_return'], prec_acc):
            //     cash_payment_method = pos_session.payment_method_ids.filtered('is_cash_count')[:1]
            //     if not cash_payment_method:
            //         raise UserError(_("No cash statement found for this session. Unable to record returned cash."))
            //     return_payment_vals = {
            //         'name': _('return'),
            //         'pos_order_id': order.id,
            //         'amount': -pos_order['amount_return'],
            //         'payment_date': fields.Datetime.now(),
            //         'payment_method_id': cash_payment_method.id,
            //         'is_change': True,
            //     }
            //     order.add_payment(return_payment_vals)
            //     order._compute_prices()
            */
            return default;
        }

        public async Task<TEntity> ProcessSavedOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object draft) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _process_saved_order(self, draft):
            // self.ensure_one()
            // if not draft and self.state != 'cancel':
            //     try:
            //         self.action_pos_order_paid()
            //     except psycopg2.DatabaseError:
            //         # do not hide transactional errors, the order(s) won't be saved!
            //         raise
            //     except Exception as e:
            //         _logger.error('Could not fully process the POS Order: %s', tools.exception_to_unicode(e))
            //     self._create_order_picking()
            //     self._compute_total_cost_in_real_time()
            // 
            // if self.to_invoice and self.state == 'paid':
            //     self._generate_pos_order_invoice()
            // 
            // return self.id
            */
            return default;
        }

        public async Task<TEntity> ReadConfigOpenOrdersAsync<TEntity>(IEnumerable<TEntity> entities, object domain, List<Guid> record_ids) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def read_config_open_orders(self, domain, record_ids=[]):
            // delete_record_ids = {}
            // dynamic_records = {}
            // 
            // for model, domain in domain.items():
            //     ids = record_ids[model]
            //     delete_record_ids[model] = [id for id in ids if not self.env[model].browse(id).exists()]
            //     dynamic_records[model] = self.env[model].search(domain)
            // 
            // pos_order_data = dynamic_records.get('pos.order') or self.env['pos.order']
            // data = pos_order_data.read_pos_data([], self.id)
            // 
            // for key, records in dynamic_records.items():
            //     fields = self.env[key]._load_pos_data_fields(self.id)
            //     ids = list(set(records.ids + [record['id'] for record in data.get(key, [])]))
            //     dynamic_records[key] = self.env[key].browse(ids).read(fields, load=False)
            // 
            // for key, value in data.items():
            //     if key not in dynamic_records:
            //         dynamic_records[key] = value
            // 
            // return {
            //     'dynamic_records': dynamic_records,
            //     'deleted_record_ids': delete_record_ids,
            // }
            */
            return default;
        }

        public async Task<TEntity> ReadPosDataAsync<TEntity>(IEnumerable<TEntity> entities, object data, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def read_pos_data(self, data, config_id):
            // # If the previous session is closed, the order will get a new session_id due to _get_valid_session in _process_order
            // session_ids = set({order.get('session_id') for order in data})
            // is_new_session = any(order.get('session_id') not in session_ids for order in data)
            // 
            // return {
            //     'pos.order': self.read(self._load_pos_data_fields(config_id), load=False) if config_id else [],
            //     'pos.session': self.session_id._load_pos_data({})['data'] if config_id and is_new_session else [],
            //     'pos.payment': self.payment_ids.read(self.payment_ids._load_pos_data_fields(config_id), load=False) if config_id else [],
            //     'pos.order.line': self.lines.read(self.lines._load_pos_data_fields(config_id), load=False) if config_id else [],
            //     'pos.pack.operation.lot': self.lines.pack_lot_ids.read(self.lines.pack_lot_ids._load_pos_data_fields(config_id), load=False) if config_id else [],
            //     "product.attribute.custom.value": self.lines.custom_attribute_value_ids.read(self.lines.custom_attribute_value_ids._load_pos_data_fields(config_id), load=False) if config_id else [],
            // }
            */
            return default;
        }

        public async Task<TEntity> ReconcileAccountMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _reconcile_account_move_lines(self, data):
            // # reconcile cash receivable lines
            // split_cash_statement_lines = data.get('split_cash_statement_lines')
            // combine_cash_statement_lines = data.get('combine_cash_statement_lines')
            // split_cash_receivable_lines = data.get('split_cash_receivable_lines')
            // combine_cash_receivable_lines = data.get('combine_cash_receivable_lines')
            // combine_inv_payment_receivable_lines = data.get('combine_inv_payment_receivable_lines')
            // split_inv_payment_receivable_lines = data.get('split_inv_payment_receivable_lines')
            // combine_invoice_receivable_lines = data.get('combine_invoice_receivable_lines')
            // split_invoice_receivable_lines = data.get('split_invoice_receivable_lines')
            // stock_output_lines = data.get('stock_output_lines')
            // payment_method_to_receivable_lines = data.get('payment_method_to_receivable_lines')
            // payment_to_receivable_lines = data.get('payment_to_receivable_lines')
            // 
            // all_lines = (
            //       split_cash_statement_lines
            //     | combine_cash_statement_lines
            //     | split_cash_receivable_lines
            //     | combine_cash_receivable_lines
            // )
            // all_lines.filtered(lambda line: line.move_id.state != 'posted').move_id._post(soft=False)
            // 
            // accounts = all_lines.mapped('account_id')
            // lines_by_account = [all_lines.filtered(lambda l: l.account_id == account and not l.reconciled) for account in accounts if account.reconcile]
            // for lines in lines_by_account:
            //     lines.with_context(no_cash_basis=True).reconcile()
            // 
            // 
            // for payment_method, lines in payment_method_to_receivable_lines.items():
            //     receivable_account = self._get_receivable_account(payment_method)
            //     if receivable_account.reconcile:
            //         lines.filtered(lambda line: not line.reconciled).with_context(no_cash_basis=True).reconcile()
            // 
            // for payment, lines in payment_to_receivable_lines.items():
            //     if payment.partner_id.property_account_receivable_id.reconcile:
            //         lines.filtered(lambda line: not line.reconciled).with_context(no_cash_basis=True).reconcile()
            // 
            // # Reconcile invoice payments' receivable lines. But we only do when the account is reconcilable.
            // # Though `account_default_pos_receivable_account_id` should be of type receivable, there is currently
            // # no constraint for it. Therefore, it is possible to put set a non-reconcilable account to it.
            // if self.company_id.account_default_pos_receivable_account_id.reconcile:
            //     for payment_method in combine_inv_payment_receivable_lines:
            //         lines = combine_inv_payment_receivable_lines[payment_method] | combine_invoice_receivable_lines.get(payment_method, self.env['account.move.line'])
            //         lines.filtered(lambda line: not line.reconciled).with_context(no_cash_basis=True).reconcile()
            // 
            //     for payment in split_inv_payment_receivable_lines:
            //         lines = split_inv_payment_receivable_lines[payment] | split_invoice_receivable_lines.get(payment, self.env['account.move.line'])
            //         lines.filtered(lambda line: not line.reconciled).with_context(no_cash_basis=True).reconcile()
            // 
            // # reconcile stock output lines
            // pickings = self.picking_ids.filtered(lambda p: not p.pos_order_id)
            // pickings |= self._get_closed_orders().filtered(lambda o: not o.is_invoiced).mapped('picking_ids')
            // stock_moves = self.env['stock.move'].search([('picking_id', 'in', pickings.ids)])
            // stock_account_move_lines = self.env['account.move'].search([('stock_move_id', 'in', stock_moves.ids)]).mapped('line_ids')
            // for account_id in stock_output_lines:
            //     ( stock_output_lines[account_id]
            //     | stock_account_move_lines.filtered(lambda aml: aml.account_id == account_id)
            //     ).filtered(lambda aml: not aml.reconciled).with_context(no_cash_basis=True).reconcile()
            // return data
            */
            return default;
        }

        public async Task<TEntity> RefundAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def refund(self):
            // return {
            //     'name': _('Return Products'),
            //     'view_mode': 'form',
            //     'res_model': 'pos.order',
            //     'res_id': self._refund().ids[0],
            //     'view_id': False,
            //     'context': self.env.context,
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            // }
            */
            return default;
        }

        public async Task<TEntity> RefundInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _refund(self):
            // """ Create a copy of order to refund them.
            // 
            // return The newly created refund orders.
            // """
            // refund_orders = self.env['pos.order']
            // for order in self:
            //     # When a refund is performed, we are creating it in a session having the same config as the original
            //     # order. It can be the same session, or if it has been closed the new one that has been opened.
            //     current_session = order.session_id.config_id.current_session_id
            //     if not current_session:
            //         raise UserError(_('To return product(s), you need to open a session in the POS %s', order.session_id.config_id.display_name))
            //     refund_order = order.copy(
            //         order._prepare_refund_values(current_session)
            //     )
            //     for line in order.lines:
            //         PosOrderLineLot = self.env['pos.pack.operation.lot']
            //         for pack_lot in line.pack_lot_ids:
            //             PosOrderLineLot += pack_lot.copy()
            //         line.copy(line._prepare_refund_data(refund_order, PosOrderLineLot))
            //     refund_orders |= refund_order
            // return refund_orders
            */
            return default;
        }

        public async Task<TEntity> RemoveFromUiAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> server_ids) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def remove_from_ui(self, server_ids):
            // """ Remove orders from the frontend PoS application
            // 
            // Remove orders from the server by id.
            // :param server_ids: list of the id's of orders to remove from the server.
            // :type server_ids: list.
            // :returns: list -- list of db-ids for the removed orders.
            // """
            // orders = self.search([('id', 'in', server_ids), ('state', '=', 'draft')])
            // orders.write({'state': 'cancel'})
            // # TODO Looks like delete cascade is a better solution.
            // orders.mapped('payment_ids').sudo().unlink()
            // orders.sudo().unlink()
            // return orders.ids
            */
            return default;
        }

        public async Task<TEntity> RemoveTrustedConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _remove_trusted_config_id(self, config_id):
            // self.trusted_config_ids -= config_id
            */
            return default;
        }

        public async Task<TEntity> ResetDefaultOnValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _reset_default_on_vals(self, vals):
            // if 'tip_product_id' in vals and not vals['tip_product_id'] and 'iface_tipproduct' in vals and vals['iface_tipproduct']:
            //     default_product = self.env.ref('point_of_sale.product_product_tip', False)
            //     if default_product:
            //         vals['tip_product_id'] = default_product.id
            //     else:
            //         raise UserError(_('The default tip product is missing. Please manually specify the tip product. (See Tips field.)'))
            */
            return default;
        }

        public async Task<TEntity> RoundAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amounts) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _round_amounts(self, amounts):
            // new_amounts = {}
            // for key, amount in amounts.items():
            //     if key == 'amount_converted':
            //         # round the amount_converted using the company currency.
            //         new_amounts[key] = self.company_id.currency_id.round(amount)
            //     else:
            //         new_amounts[key] = self.currency_id.round(amount)
            // return new_amounts
            */
            return default;
        }

        public async Task<TEntity> SearchPaidOrderIdsAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object limit, object offset) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def search_paid_order_ids(self, config_id, domain, limit, offset):
            // """Search for 'paid' orders that satisfy the given domain, limit and offset."""
            // default_domain = [('state', '!=', 'draft'), ('state', '!=', 'cancel')]
            // if domain == []:
            //     real_domain = AND([[['config_id', '=', config_id]], default_domain])
            // else:
            //     real_domain = AND([domain, default_domain])
            // orders = self.search(real_domain, limit=limit, offset=offset, order='create_date desc')
            // # We clean here the orders that does not have the same currency.
            // # As we cannot use currency_id in the domain (because it is not a stored field),
            // # we must do it after the search.
            // pos_config = self.env['pos.config'].browse(config_id)
            // orders = orders.filtered(lambda order: order.currency_id == pos_config.currency_id)
            // orderlines = self.env['pos.order.line'].search(['|', ('refunded_orderline_id.order_id', 'in', orders.ids), ('order_id', 'in', orders.ids)])
            // 
            // # We will return to the frontend the ids and the date of their last modification
            // # so that it can compare to the last time it fetched the orders and can ask to fetch
            // # orders that are not up-to-date.
            // # The date of their last modification is either the last time one of its orderline has changed,
            // # or the last time a refunded orderline related to it has changed.
            // orders_info = defaultdict(lambda: datetime.min)
            // for orderline in orderlines:
            //     key_order = orderline.order_id.id if orderline.order_id in orders \
            //                     else orderline.refunded_orderline_id.order_id.id
            //     if orders_info[key_order] < orderline.write_date:
            //         orders_info[key_order] = orderline.write_date
            // totalCount = self.search_count(real_domain)
            // return {'ordersInfo': list(orders_info.items())[::-1], 'totalCount': totalCount}
            */
            return default;
        }

        public async Task<TEntity> SearchTrackingNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _search_tracking_number(self, operator, value):
            // #search is made over the pos_reference field
            // #The pos_reference field is like 'Order 00001-001-0001'
            // if operator in ['ilike', '='] and isinstance(value, str):
            //     if value[0] == '%' and value[-1] == '%':
            //         value = value[1:-1]
            //     value = value.zfill(3)
            //     search = '% ____' + value[0] + '-___-__' + value[1:]
            //     return [('pos_reference', operator, search or '')]
            // else:
            //     raise NotImplementedError(_("Unsupported search operation"))
            */
            return default;
        }

        public async Task<TEntity> SendOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _send_order(self):
            // # This function is made to be overriden by pos_self_order_preparation_display
            // pass
            */
            return default;
        }

        public async Task<TEntity> SetDefaultPosLoadLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _set_default_pos_load_limit(self):
            // param_model = self.env["ir.config_parameter"]
            // if not param_model.get_param("point_of_sale.limited_product_count"):
            //     param_model.set_param("point_of_sale.limited_product_count", 20000)
            // 
            // if not param_model.get_param("point_of_sale.limited_customer_count"):
            //     param_model.set_param("point_of_sale.limited_customer_count", 100)
            */
            return default;
        }

        public async Task<TEntity> SetFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _set_fiscal_position(self):
            // for config in self:
            //     if config.tax_regime_selection and config.default_fiscal_position_id and (config.default_fiscal_position_id.id not in config.fiscal_position_ids.ids):
            //         config.fiscal_position_ids = [(4, config.default_fiscal_position_id.id)]
            //     elif not config.tax_regime_selection and config.fiscal_position_ids.ids:
            //         config.fiscal_position_ids = [(5, 0, 0)]
            */
            return default;
        }

        public async Task<TEntity> SetOpeningControlAsync<TEntity>(IEnumerable<TEntity> entities, int cashbox_value, string notes) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def set_opening_control(self, cashbox_value: int, notes: str):
            // if self.state != 'opening_control':
            //     return
            // self.state = 'opened'
            // self.start_at = fields.Datetime.now()
            // if not self.rescue:
            //     self.name = self.env['ir.sequence'].with_context(company_id=self.config_id.company_id.id).next_by_code('pos.session')
            // 
            // cash_payment_method_ids = self.config_id.payment_method_ids.filtered(lambda pm: pm.is_cash_count)
            // if cash_payment_method_ids:
            //     self.opening_notes = notes
            //     difference = cashbox_value - self.cash_register_balance_start
            //     self._post_cash_details_message('Opening cash', self.cash_register_balance_start, difference, notes)
            //     self.cash_register_balance_start = cashbox_value
            // elif notes:
            //     message = _('Opening control message: ')
            //     message += notes
            //     self.message_post(body=plaintext2html(message))
            */
            return default;
        }

        public async Task<TEntity> ShouldCreatePickingRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _should_create_picking_real_time(self):
            // return not self.session_id.update_stock_at_closing or (self.company_id.anglo_saxon_accounting and self.to_invoice)
            */
            return default;
        }

        public async Task<TEntity> ShowCashRegisterAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def show_cash_register(self):
            // return {
            //     'name': _('Cash register'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.bank.statement.line',
            //     'view_mode': 'list,kanban',
            //     'domain': [('id', 'in', self.statement_line_ids.ids)],
            // }
            */
            return default;
        }

        public async Task<TEntity> ShowJournalItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def show_journal_items(self):
            // self.ensure_one()
            // all_related_moves = self._get_related_account_moves()
            // return {
            //     'name': _('Journal Items'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.move.line',
            //     'view_mode': 'list',
            //     'view_id':self.env.ref('account.view_move_line_tree').id,
            //     'domain': [('id', 'in', all_related_moves.mapped('line_ids').ids)],
            //     'context': {
            //         'journal_type':'general',
            //         'search_default_group_by_move': 1,
            //         'group_by':'move_id', 'search_default_posted':1,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> SyncFromUiAsync<TEntity>(IEnumerable<TEntity> entities, object orders) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def sync_from_ui(self, orders):
            // """ Create and update Orders from the frontend PoS application.
            // 
            // Create new orders and update orders that are in draft status. If an order already exists with a status
            // different from 'draft' it will be discarded, otherwise it will be saved to the database. If saved with
            // 'draft' status the order can be overwritten later by this function.
            // 
            // :param orders: dictionary with the orders to be created.
            // :type orders: dict.
            // :param draft: Indicate if the orders are meant to be finalized or temporarily saved.
            // :type draft: bool.
            // :Returns: list -- list of db-ids for the created and updated orders.
            // """
            // sync_token = randrange(100_000_000)  # Use to differentiate 2 parallels calls to this function in the logs
            // _logger.info("PoS synchronisation #%d started for PoS orders references: %s", sync_token, [self._get_order_log_representation(order) for order in orders])
            // order_ids = []
            // for order in orders:
            //     order_log_name = self._get_order_log_representation(order)
            //     _logger.debug("PoS synchronisation #%d processing order %s order full data: %s", sync_token, order_log_name, pformat(order))
            // 
            //     if len(self._get_refunded_orders(order)) > 1:
            //         raise ValidationError(_('You can only refund products from the same order.'))
            // 
            //     existing_order = self._get_open_order(order)
            //     if existing_order and existing_order.state == 'draft':
            //         order_ids.append(self._process_order(order, existing_order))
            //         _logger.info("PoS synchronisation #%d order %s updated pos.order #%d", sync_token, order_log_name, order_ids[-1])
            //     elif not existing_order:
            //         order_ids.append(self._process_order(order, False))
            //         _logger.info("PoS synchronisation #%d order %s created pos.order #%d", sync_token, order_log_name, order_ids[-1])
            //     else:
            //         # In theory, this situation is unintended
            //         # In practice it can happen when "Tip later" option is used
            //         order_ids.append(existing_order.id)
            //         _logger.info("PoS synchronisation #%d order %s sync ignored for existing PoS order %s (state: %s)", sync_token, order_log_name, existing_order, existing_order.state)
            // 
            // # Sometime pos_orders_ids can be empty.
            // pos_order_ids = self.env['pos.order'].browse(order_ids)
            // config_id = pos_order_ids.config_id.ids[0] if pos_order_ids else False
            // 
            // for order in pos_order_ids:
            //     order._ensure_access_token()
            //     if not self.env.context.get('preparation'):
            //         order.config_id.notify_synchronisation(order.config_id.current_session_id.id, self.env.context.get('login_number', 0))
            // 
            // _logger.info("PoS synchronisation #%d finished", sync_token)
            // return pos_order_ids.read_pos_data(orders, config_id)
            */
            return default;
        }

        public async Task<TEntity> TryCashInOutAsync<TEntity>(IEnumerable<TEntity> entities, object _type, object amount, object reason, object extras) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def try_cash_in_out(self, _type, amount, reason, extras):
            // sign = 1 if _type == 'in' else -1
            // sessions = self.filtered('cash_journal_id')
            // if not sessions:
            //     raise UserError(_("There is no cash payment method for this PoS Session"))
            // 
            // vals_list = [
            //     self._prepare_account_bank_statement_line_vals(session, sign, amount, reason, extras)
            //     for session in sessions
            // ]
            // 
            // self.env['account.bank.statement.line'].create(vals_list)
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def unlink(self):
            // # Delete the pos.config records first then delete the sequences linked to them
            // sequences_to_delete = self.sequence_id | self.sequence_line_id
            // res = super(PosConfig, self).unlink()
            // sequences_to_delete.unlink()
            // return res
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def unlink(self):
            // self.statement_line_ids.unlink()
            // return super(PosSession, self).unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDraftOrCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _unlink_except_draft_or_cancel(self):
            // for pos_order in self.filtered(lambda pos_order: pos_order.state not in ['draft', 'cancel']):
            //     raise UserError(_('In order to delete a sale, it must be new or cancelled.'))
            */
            return default;
        }

        public async Task<TEntity> UpdateAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_amounts, object amounts_to_add, object date, object round, object force_company_currency) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _update_amounts(self, old_amounts, amounts_to_add, date, round=True, force_company_currency=False):
            // """Responsible for adding `amounts_to_add` to `old_amounts` considering the currency of the session.
            // 
            //     old_amounts {                                                       new_amounts {
            //         amount                         amounts_to_add {                     amount
            //         amount_converted        +          amount               ->          amount_converted
            //        [base_amount                       [base_amount]                    [base_amount
            //         base_amount_converted]        }                                     base_amount_converted]
            //     }                                                                   }
            // 
            // NOTE:
            //     - Notice that `amounts_to_add` does not have `amount_converted` field.
            //         This function is responsible in calculating the `amount_converted` from the
            //         `amount` of `amounts_to_add` which is used to update the values of `old_amounts`.
            //     - Values of `amount` and/or `base_amount` should always be in session's currency [1].
            //     - Value of `amount_converted` should be in company's currency
            // 
            // [1] Except when `force_company_currency` = True. It means that values in `amounts_to_add`
            //     is in company currency.
            // 
            // :params old_amounts dict:
            //     Amounts to update
            // :params amounts_to_add dict:
            //     Amounts used to update the old_amounts
            // :params date date:
            //     Date used for conversion
            // :params round bool:
            //     Same as round parameter of `res.currency._convert`.
            //     Defaults to True because that is the default of `res.currency._convert`.
            //     We put it to False if we want to round globally.
            // :params force_company_currency bool:
            //     If True, the values in amounts_to_add are in company's currency.
            //     Defaults to False because it is only used to anglo-saxon lines.
            // 
            // :return dict: new amounts combining the values of `old_amounts` and `amounts_to_add`.
            // """
            // # make a copy of the old amounts
            // new_amounts = { **old_amounts }
            // 
            // amount = amounts_to_add.get('amount')
            // if self.is_in_company_currency or force_company_currency:
            //     amount_converted = amount
            // else:
            //     amount_converted = self._amount_converter(amount, date, round)
            // 
            // # update amount and amount converted
            // new_amounts['amount'] += amount
            // new_amounts['amount_converted'] += amount_converted
            // 
            // # consider base_amount if present
            // 
            // if amounts_to_add.get('base_amount'):
            //     base_amount = amounts_to_add.get('base_amount')
            // 
            //     # update base_amount and base_amount_converted
            //     new_amounts['base_amount'] += base_amount
            //     new_amounts['base_amount_converted'] += base_amount
            // 
            // return new_amounts
            */
            return default;
        }

        public async Task<TEntity> UpdateClosingControlStateSessionAsync<TEntity>(IEnumerable<TEntity> entities, object notes) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def update_closing_control_state_session(self, notes):
            // # Prevent closing the session again if it was already closed
            // if self.state == 'closed':
            //     raise UserError(_('This session is already closed.'))
            // # Prevent the session to be opened again.
            // self.write({'state': 'closing_control', 'stop_at': fields.Datetime.now(), 'closing_notes': notes})
            // self._post_cash_details_message('Closing', self.cash_register_balance_end, self.cash_register_difference, notes)
            */
            return default;
        }

        public async Task<TEntity> UpdateCustomerDisplayAsync<TEntity>(IEnumerable<TEntity> entities, object order, object access_token) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def update_customer_display(self, order, access_token):
            // self.ensure_one()
            // if not access_token or not secrets.compare_digest(self.access_token, access_token):
            //     return
            // self._notify("UPDATE_CUSTOMER_DISPLAY", order)
            */
            return default;
        }

        public async Task<TEntity> UpdatePreparationPrintersMenuitemVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def _update_preparation_printers_menuitem_visibility(self):
            // prepa_printers_menuitem = self.sudo().env.ref('point_of_sale.menu_pos_preparation_printer', raise_if_not_found=False)
            // if prepa_printers_menuitem:
            //     prepa_printers_menuitem.active = self.sudo().env['pos.config'].search_count([('is_order_printer', '=', True)], limit=1) > 0
            */
            return default;
        }

        public async Task<TEntity> UpdateQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object qty_to_add) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _update_quantities(self, vals, qty_to_add):
            // vals.setdefault('quantity', 0)
            // # update quantity
            // vals['quantity'] += qty_to_add
            // return vals
            */
            return default;
        }

        public async Task<TEntity> UpdateSessionInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session_info) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _update_session_info(self, session_info):
            // session_info['user_context']['allowed_company_ids'] = self.company_id.ids
            // session_info['user_companies'] = {'current_company': self.company_id.id, 'allowed_companies': {self.company_id.id: session_info['user_companies']['allowed_companies'][self.company_id.id]}}
            // session_info['nomenclature_id'] = self.company_id.nomenclature_id.id
            // session_info['fallback_nomenclature_id'] = self._get_pos_fallback_nomenclature_id()
            // return session_info
            */
            return default;
        }

        public async Task<TEntity> ValidateSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def _validate_session(self, balancing_account=False, amount_to_balance=0, bank_payment_method_diffs=None):
            // bank_payment_method_diffs = bank_payment_method_diffs or {}
            // self.ensure_one()
            // data = {}
            // sudo = self.env.user.has_group('point_of_sale.group_pos_user')
            // if self.get_session_orders().filtered(lambda o: o.state != 'cancel') or self.sudo().statement_line_ids:
            //     self.cash_real_transaction = sum(self.sudo().statement_line_ids.mapped('amount'))
            //     if self.state == 'closed':
            //         raise UserError(_('This session is already closed.'))
            //     self._check_if_no_draft_orders()
            //     self._check_invoices_are_posted()
            //     cash_difference_before_statements = self.cash_register_difference
            //     if self.update_stock_at_closing:
            //         self._create_picking_at_end_of_session()
            //         self._get_closed_orders().filtered(lambda o: not o.is_total_cost_computed)._compute_total_cost_at_session_closing(self.picking_ids.move_ids)
            //     try:
            //         with self.env.cr.savepoint():
            //             data = self.with_company(self.company_id).with_context(check_move_validity=False, skip_invoice_sync=True)._create_account_move(balancing_account, amount_to_balance, bank_payment_method_diffs)
            //     except AccessError as e:
            //         if sudo:
            //             data = self.sudo().with_company(self.company_id).with_context(check_move_validity=False, skip_invoice_sync=True)._create_account_move(balancing_account, amount_to_balance, bank_payment_method_diffs)
            //         else:
            //             raise e
            // 
            //     balance = sum(self.move_id.line_ids.mapped('balance'))
            //     try:
            //         with self.move_id._check_balanced({'records': self.move_id.sudo()}):
            //             pass
            //     except UserError:
            //         # Creating the account move is just part of a big database transaction
            //         # when closing a session. There are other database changes that will happen
            //         # before attempting to create the account move, such as, creating the picking
            //         # records.
            //         # We don't, however, want them to be committed when the account move creation
            //         # failed; therefore, we need to roll back this transaction before showing the
            //         # close session wizard.
            //         self.env.cr.rollback()
            //         return self._close_session_action(balance)
            // 
            //     self.sudo()._post_statement_difference(cash_difference_before_statements)
            //     if self.move_id.line_ids:
            //         self.move_id.sudo().with_company(self.company_id)._post()
            //         # Set the uninvoiced orders' state to 'done'
            //         self.env['pos.order'].search([('session_id', '=', self.id), ('state', '=', 'paid')]).write({'state': 'done'})
            //     else:
            //         self.move_id.sudo().unlink()
            //     self.sudo().with_company(self.company_id)._reconcile_account_move_lines(data)
            // else:
            //     self.sudo()._post_statement_difference(self.cash_register_difference)
            // 
            // if self.config_id.order_edit_tracking:
            //     edited_orders = self.get_session_orders().filtered(lambda o: o.is_edited)
            //     if len(edited_orders) > 0:
            //         body = _("Edited order(s) during the session:%s",
            //             Markup("<br/><ul>%s</ul>") % Markup().join(Markup("<li>%s</li>") % order._get_html_link() for order in edited_orders)
            //         )
            //         self.message_post(body=body)
            // 
            // # Make sure to trigger reordering rules
            // self.picking_ids.move_ids.sudo()._trigger_scheduler()
            // 
            // self.write({'state': 'closed'})
            // return True
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py) ---
            // def write(self, vals):
            // self._check_header_footer(vals)
            // self._reset_default_on_vals(vals)
            // if ('is_order_printer' in vals and not vals['is_order_printer']):
            //     vals['printer_ids'] = [fields.Command.clear()]
            // 
            // bypass_categories_forbidden_change = self.env.context.get('bypass_categories_forbidden_change', False)
            // bypass_payment_method_ids_forbidden_change = self.env.context.get('bypass_payment_method_ids_forbidden_change', False)
            // 
            // self._preprocess_x2many_vals_from_settings_view(vals)
            // vals = self._keep_new_vals(vals)
            // opened_session = self.mapped('session_ids').filtered(lambda s: s.state != 'closed')
            // if opened_session:
            //     forbidden_fields = []
            //     for key in self._get_forbidden_change_fields():
            //         if key in vals.keys():
            //             if bypass_categories_forbidden_change and key in ('limit_categories', 'iface_available_categ_ids'):
            //                 continue
            //             if bypass_payment_method_ids_forbidden_change and key == 'payment_method_ids':
            //                 continue
            //             if key == 'use_pricelist' and vals[key]:
            //                 continue
            //             if key == 'available_pricelist_ids':
            //                 will_unlink_a_pricelist = \
            //                     (
            //                         (not isinstance(vals[key], list) or len(vals[key]) == 0)
            //                         and self.available_pricelist_ids
            //                     ) or (
            //                         isinstance(vals[key], list) and any(
            //                             (
            //                                 len(cmd) >= 1
            //                                 and cmd[0] == Command.CLEAR
            //                                 and self.available_pricelist_ids
            //                             ) or (
            //                                 len(cmd) >= 2
            //                                 and cmd[0] in {Command.UNLINK, Command.DELETE}
            //                                 and cmd[1] in self.available_pricelist_ids.ids
            //                             ) or (
            //                                 len(cmd) == 3
            //                                 and cmd[0] == Command.SET
            //                                 and set(self.available_pricelist_ids.ids) - set(cmd[2])
            //                             )
            //                             for cmd in vals[key]
            //                         )
            //                     )
            // 
            //                 if not will_unlink_a_pricelist:
            //                     continue
            //             field_name = self._fields[key].get_description(self.env)["string"]
            //             forbidden_fields.append(field_name)
            //     if len(forbidden_fields) > 0:
            //         raise UserError(_(
            //             "Unable to modify this PoS Configuration because you can't modify %s while a session is open.",
            //             ", ".join(forbidden_fields)
            //         ))
            // 
            // result = super(PosConfig, self).write(vals)
            // 
            // self.sudo()._set_fiscal_position()
            // self.sudo()._check_modules_to_install()
            // self.sudo()._check_groups_implied()
            // if 'is_order_printer' in vals:
            //     self._update_preparation_printers_menuitem_visibility()
            // return result
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def write(self, vals):
            // for order in self:
            //     if vals.get('state') and vals['state'] == 'paid' and order.name == '/':
            //         vals['name'] = self._compute_order_name()
            //     if vals.get('mobile'):
            //         vals['mobile'] = order._phone_format(number=vals.get('mobile'),
            //                 country=order.partner_id.country_id or self.env.company.country_id)
            //     if vals.get('has_deleted_line') is not None and self.has_deleted_line:
            //         del vals['has_deleted_line']
            //     allowed_vals = ['paid', 'done', 'invoiced']
            //     if vals.get('state') and vals['state'] not in allowed_vals and order.state in allowed_vals:
            //         raise UserError(_('This order has already been paid. You cannot set it back to draft or edit it.'))
            // 
            // list_line = self._create_pm_change_log(vals)
            // res = super().write(vals)
            // for order in self:
            //     if vals.get('payment_ids'):
            //         order.with_context(backend_recomputation=True)._compute_prices()
            //         totally_paid_or_more = float_compare(order.amount_paid, self._get_rounded_amount(order.amount_total), precision_rounding=order.currency_id.rounding)
            //         if totally_paid_or_more < 0 and order.state in ['paid', 'done', 'invoiced']:
            //             raise UserError(_('The paid amount is different from the total amount of the order.'))
            //         elif totally_paid_or_more > 0 and order.state == 'paid':
            //             list_line.append(_("Warning, the paid amount is higher than the total amount. (Difference: %s)", formatLang(self.env, order.amount_paid - order.amount_total, currency_obj=order.currency_id)))
            //         if order.nb_print > 0 and vals.get('payment_ids'):
            //             raise UserError(_('You cannot change the payment of a printed order.'))
            // 
            // if len(list_line) > 0:
            //     body = _("Payment changes:")
            //     body += self._markup_list_message(list_line)
            //     for order in self:
            //         if vals.get('payment_ids'):
            //             order.message_post(body=body)
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py) ---
            // def write(self, vals):
            // if vals.get('state') == 'closed':
            //     for record in self:
            //         record.config_id._notify(('CLOSING_SESSION', {'login_number': self.env.context.get('login_number', False)}))
            // return super().write(vals)
            */
            return default;
        }
    }
}