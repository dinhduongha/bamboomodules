using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("analytic", Depends = new[] { "base", "mail", "uom" })]
    public class AnalyticMixinAppService : ApplicationService, IAnalyticMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AnalyticMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_add_from_catalog(self):
            // """ Will open the catalog view """
            // move = self.env['account.move'].browse(self.env.context.get('order_id'))
            // return move.action_add_from_catalog()
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def action_add_from_catalog(self):
            // order = self.env['purchase.order'].browse(self.env.context.get('order_id'))
            // return order.with_context(child_field='order_line').action_add_from_catalog()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def action_add_from_catalog(self):
            // order = self.env['sale.order'].browse(self.env.context.get('order_id'))
            // return order.with_context(child_field='order_line').action_add_from_catalog()
            */
            return default;
        }

        public async Task<TEntity> ActionApproveDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_approve_duplicates(self):
            // root = self.env['ir.model.data']._xmlid_to_res_id("base.partner_root")
            // for expense in self.duplicate_expense_ids:
            //     expense.message_post(
            //         body=_('%(user)s confirms this expense is not a duplicate with similar expense.', user=self.env.user.name),
            //         author_id=root,
            //     )
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_archive(self):
            // res = super().action_archive()
            // filtered_workcenters = ", ".join(workcenter.name for workcenter in self.filtered('routing_line_ids'))
            // if filtered_workcenters:
            //     return {
            //         'type': 'ir.actions.client',
            //         'tag': 'display_notification',
            //         'params': {
            //         'title': _("Note that archived work center(s): '%s' is/are still linked to active Bill of Materials, which means that operations can still be planned on it/them. "
            //                    "To prevent this, deletion of the work center is recommended instead.", filtered_workcenters),
            //         'type': 'warning',
            //         'sticky': True,  #True/False will display for few seconds if false
            //         'next': {'type': 'ir.actions.act_window_close'},
            //         },
            //     }
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionAutomaticEntryAsync<TEntity>(IEnumerable<TEntity> entities, object default_action) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_automatic_entry(self, default_action=None):
            // action = self.env['ir.actions.act_window']._for_xml_id('account.account_automatic_entry_wizard_action')
            // # Force the values of the move line in the context to avoid issues
            // ctx = dict(self.env.context)
            // ctx.pop('active_id', None)
            // ctx.pop('default_journal_id', None)
            // ctx['active_ids'] = self.ids
            // ctx['active_model'] = 'account.move.line'
            // if default_action:
            //     ctx['default_action'] = default_action
            // action['context'] = ctx
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionGetAttachmentViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_get_attachment_view(self):
            // self.ensure_one()
            // res = self.env['ir.actions.act_window']._for_xml_id('base.action_attachment')
            // res.update({
            //     'domain': [('res_model', '=', 'hr.expense'), ('res_id', 'in', self.ids)],
            //     'context': {'default_res_model': 'hr.expense', 'default_res_id': self.id},
            // })
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_open_business_doc(self):
            // return self.move_id.action_open_business_doc()
            */
            return default;
        }

        public async Task<TEntity> ActionOpenOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def action_open_order(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'purchase.order',
            //     'res_id': self.order_id.id,
            //     'view_mode': 'form',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionPaymentItemsRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_payment_items_register_payment(self):
            // return self.action_register_payment(ctx={'default_group_payment': True})
            */
            return default;
        }

        public async Task<TEntity> ActionPurchaseHistoryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def action_purchase_history(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("purchase.action_purchase_history")
            // action['domain'] = [('state', 'in', ['purchase', 'done']), ('product_id', '=', self.product_id.id)]
            // action['display_name'] = _("Purchase History for %s", self.product_id.display_name)
            // action['context'] = {
            //     'search_default_partner_id': self.partner_id.id
            // }
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionReadDistributionModelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py) ---
            // def action_read_distribution_model(self):
            // self.ensure_one()
            // return {
            //     'name': self.display_name,
            //     'type': 'ir.actions.act_window',
            //     'view_type': 'form',
            //     'view_mode': 'form',
            //     'res_model': 'account.analytic.distribution.model',
            //     'res_id': self.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities, object ctx) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_register_payment(self, ctx=None):
            // ''' Open the account.payment.register wizard to pay the selected journal items.
            // :return: An action opening the account.payment.register wizard.
            // '''
            // context = {
            //     'active_model': 'account.move.line',
            //     'active_ids': self.ids,
            // }
            // if ctx:
            //     context.update(ctx)
            // return {
            //     'name': _('Pay'),
            //     'res_model': 'account.payment.register',
            //     'view_mode': 'form',
            //     'views': [[False, 'form']],
            //     'context': context,
            //     'target': 'new',
            //     'type': 'ir.actions.act_window',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionShowOperationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_show_operations(self):
            // self.ensure_one()
            // action = self.env['ir.actions.actions']._for_xml_id('mrp.mrp_routing_action')
            // action['domain'] = [('workcenter_id', '=', self.id)]
            // action['context'] = {
            //     'default_workcenter_id': self.id,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionShowSameReceiptExpenseIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_show_same_receipt_expense_ids(self):
            // self.ensure_one()
            // return self.same_receipt_expense_ids._get_records_action(
            //     name=_("Expenses with a similar receipt to %(other_expense_name)s", other_expense_name=self.name),
            // )
            */
            return default;
        }

        public async Task<TEntity> ActionSplitWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_split_wizard(self):
            // self.ensure_one()
            // splits = self.env['hr.expense.split'].create(self._get_split_values())
            // 
            // wizard = self.env['hr.expense.split.wizard'].create({
            //     'expense_split_line_ids': splits.ids,
            //     'expense_id': self.id,
            // })
            // return {
            //     'name': _('Expense split'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'views': [[False, "form"]],
            //     'res_model': 'hr.expense.split.wizard',
            //     'res_id': wizard.id,
            //     'target': 'new',
            //     'context': self.env.context,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionSubmitExpensesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_submit_expenses(self):
            // sheets = self._create_sheets_from_expense()
            // return {
            //     'name': _('New Expense Reports'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.expense.sheet',
            //     'context': self.env.context,
            //     'views': [[False, "list"], [False, "form"]] if len(sheets) > 1 else [[False, "form"]],
            //     'domain': [('id', 'in', sheets.ids)],
            //     'res_id': sheets.id if len(sheets) == 1 else False,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionUnreconcileMatchEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_unreconcile_match_entries(self):
            // """ This method will do the unreconcile action in the list view of the moves """
            // active_ids = self._context.get('active_ids')
            // if active_ids:
            //     move_lines = self.env['account.move.line'].browse(active_ids)._all_reconciled_lines()
            //     move_lines.remove_move_reconcile()
            */
            return default;
        }

        public async Task<TEntity> ActionViewSheetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_view_sheet(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'views': [[False, "form"]],
            //     'res_model': 'hr.expense.sheet',
            //     'target': 'current',
            //     'res_id': self.sheet_id.id
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAlternativesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_work_order_alternatives(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.mrp_workorder_todo")
            // action['domain'] = ['|', ('workcenter_id', 'in', self.alternative_workcenter_ids.ids),
            //                     ('workcenter_id.alternative_workcenter_ids', '=', self.id)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def action_work_order(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mrp.action_work_orders")
            // return action
            */
            return default;
        }

        public async Task<TEntity> AddExchangeDifferenceCashBasisValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exchange_diff_vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _add_exchange_difference_cash_basis_vals(self, exchange_diff_vals):
            // """ Generate the exchange difference values used to create the journal items
            // in order to fix the cash basis lines using the transfer account in a multi-currencies
            // environment when this account is not a reconcile one.
            // When the tax cash basis journal entries are generated and all involved
            // transfer account set on taxes are all reconcilable, the account balance
            // will be reset to zero by the exchange difference journal items generated
            // above. However, this mechanism will not work if there is any transfer
            // accounts that are not reconcile and we are generating the cash basis
            // journal items in a foreign currency. In that specific case, we need to
            // generate extra journal items at the generation of the exchange difference
            // journal entry to ensure this balance is reset to zero and then, will not
            // appear on the tax report leading to erroneous tax base amount / tax amount.
            // :param exchange_diff_vals:  The current vals of the exchange difference journal entry created by the
            //                             '_prepare_exchange_difference_move_vals' method.
            // """
            // caba_lines_to_reconcile = defaultdict(lambda: self.env['account.move.line']) # in the form {(move, account, repartition_line): move_lines}
            // move_vals = exchange_diff_vals['move_values']
            // for move in self.move_id:
            //     account_vals_to_fix = {}
            // 
            //     move_values = move._collect_tax_cash_basis_values()
            // 
            //     # The cash basis doesn't need to be handled for this move because there is another payment term
            //     # line that is not yet fully paid.
            //     if not move_values or not move_values['is_fully_paid']:
            //         continue
            // 
            //     # ==========================================================================
            //     # Add the balance of all tax lines of the current move in order in order
            //     # to compute the residual amount for each of them.
            //     # ==========================================================================
            // 
            //     caba_rounding_diff_label = _("Cash basis rounding difference")
            //     move_vals['date'] = max(move_vals['date'], move.date)
            //     move_vals['journal_id'] = self.company_id.tax_cash_basis_journal_id.id
            //     for caba_treatment, line in move_values['to_process_lines']:
            // 
            //         vals = {
            //             'name': caba_rounding_diff_label,
            //             'currency_id': line.currency_id.id,
            //             'partner_id': line.partner_id.id,
            //             'tax_ids': [Command.set(line.tax_ids.ids)],
            //             'tax_tag_ids': [Command.set(line.tax_tag_ids.ids)],
            //             'debit': line.debit,
            //             'credit': line.credit,
            //             'amount_currency': line.amount_currency,
            //         }
            // 
            //         if caba_treatment == 'tax':
            //             # Tax line.
            //             grouping_key = self.env['account.partial.reconcile']._get_cash_basis_tax_line_grouping_key_from_record(line)
            //             if grouping_key in account_vals_to_fix:
            //                 debit = account_vals_to_fix[grouping_key]['debit'] + vals['debit']
            //                 credit = account_vals_to_fix[grouping_key]['credit'] + vals['credit']
            //                 balance = debit - credit
            // 
            //                 account_vals_to_fix[grouping_key].update({
            //                     'debit': balance if balance > 0 else 0,
            //                     'credit': -balance if balance < 0 else 0,
            //                     'tax_base_amount': account_vals_to_fix[grouping_key]['tax_base_amount'] + line.tax_base_amount,
            //                     'amount_currency': account_vals_to_fix[grouping_key]['amount_currency'] + line.amount_currency,
            //                 })
            //             else:
            //                 account_vals_to_fix[grouping_key] = {
            //                     **vals,
            //                     'account_id': line.account_id.id,
            //                     'tax_base_amount': line.tax_base_amount,
            //                     'tax_repartition_line_id': line.tax_repartition_line_id.id,
            //                 }
            // 
            //             if line.account_id.reconcile:
            //                 caba_lines_to_reconcile[(move, line.account_id, line.tax_repartition_line_id)] |= line
            // 
            //         elif caba_treatment == 'base':
            //             # Base line.
            //             account_to_fix = line.company_id.account_cash_basis_base_account_id
            //             if not account_to_fix:
            //                 continue
            // 
            //             grouping_key = self.env['account.partial.reconcile']._get_cash_basis_base_line_grouping_key_from_record(line, account=account_to_fix)
            // 
            //             if grouping_key not in account_vals_to_fix:
            //                 account_vals_to_fix[grouping_key] = {
            //                     **vals,
            //                     'account_id': account_to_fix.id,
            //                 }
            //             else:
            //                 # Multiple base lines could share the same key, if the same
            //                 # cash basis tax is used alone on several lines of the invoices
            //                 account_vals_to_fix[grouping_key]['debit'] += vals['debit']
            //                 account_vals_to_fix[grouping_key]['credit'] += vals['credit']
            //                 account_vals_to_fix[grouping_key]['amount_currency'] += vals['amount_currency']
            // 
            //     # ==========================================================================
            //     # Subtract the balance of all previously generated cash basis journal entries
            //     # in order to retrieve the residual balance of each involved transfer account.
            //     # ==========================================================================
            // 
            //     cash_basis_moves = self.env['account.move'].search([('tax_cash_basis_origin_move_id', '=', move.id)])
            //     caba_transition_accounts = self.env['account.account']
            //     for line in cash_basis_moves.line_ids:
            //         grouping_key = None
            //         if line.tax_repartition_line_id:
            //             # Tax line.
            //             transition_account = line.tax_line_id.cash_basis_transition_account_id
            //             grouping_key = self.env['account.partial.reconcile']._get_cash_basis_tax_line_grouping_key_from_record(
            //                 line,
            //                 account=transition_account,
            //             )
            //             caba_transition_accounts |= transition_account
            //         elif line.tax_ids:
            //             # Base line.
            //             grouping_key = self.env['account.partial.reconcile']._get_cash_basis_base_line_grouping_key_from_record(
            //                 line,
            //                 account=line.company_id.account_cash_basis_base_account_id,
            //             )
            // 
            //         if grouping_key not in account_vals_to_fix:
            //             continue
            // 
            //         account_vals_to_fix[grouping_key]['debit'] -= line.debit
            //         account_vals_to_fix[grouping_key]['credit'] -= line.credit
            //         account_vals_to_fix[grouping_key]['amount_currency'] -= line.amount_currency
            // 
            //     # Collect the caba lines affecting the transition account.
            //     for transition_line in filter(lambda x: x.account_id in caba_transition_accounts, cash_basis_moves.line_ids):
            //         caba_reconcile_key = (transition_line.move_id, transition_line.account_id, transition_line.tax_repartition_line_id)
            //         caba_lines_to_reconcile[caba_reconcile_key] |= transition_line
            // 
            //     # ==========================================================================
            //     # Generate the exchange difference journal items:
            //     # - to reset the balance of all transfer account to zero.
            //     # - fix rounding issues on the tax account/base tax account.
            //     # ==========================================================================
            // 
            //     currency = move_values['currency']
            // 
            //     # To know which rate to use for the adjustment, get the rate used by the most recent cash basis move
            //     last_caba_move = max(cash_basis_moves, key=lambda m: m.date) if cash_basis_moves else self.env['account.move']
            //     currency_line = last_caba_move.line_ids.filtered(lambda x: x.currency_id == currency)[:1]
            //     currency_rate = currency_line.balance / currency_line.amount_currency if currency_line.amount_currency else 1.0
            // 
            //     existing_line_vals_list = move_vals['line_ids']
            //     next_sequence = len(existing_line_vals_list)
            //     for grouping_key, values in account_vals_to_fix.items():
            // 
            //         if currency.is_zero(values['amount_currency']):
            //             continue
            // 
            //         # There is a rounding error due to multiple payments on the foreign currency amount
            //         balance = currency.round(currency_rate * values['amount_currency'])
            // 
            //         if values.get('tax_repartition_line_id'):
            //             # Tax line
            //             tax_repartition_line = self.env['account.tax.repartition.line'].browse(values['tax_repartition_line_id'])
            //             account = tax_repartition_line.account_id or self.env['account.account'].browse(values['account_id'])
            // 
            //             existing_line_vals_list.extend([
            //                 Command.create({
            //                     **values,
            //                     'debit': balance if balance > 0.0 else 0.0,
            //                     'credit': -balance if balance < 0.0 else 0.0,
            //                     'amount_currency': values['amount_currency'],
            //                     'account_id': account.id,
            //                     'sequence': next_sequence,
            //                 }),
            //                 Command.create({
            //                     **values,
            //                     'debit': -balance if balance < 0.0 else 0.0,
            //                     'credit': balance if balance > 0.0 else 0.0,
            //                     'amount_currency': -values['amount_currency'],
            //                     'account_id': values['account_id'],
            //                     'tax_ids': [],
            //                     'tax_tag_ids': [],
            //                     'tax_base_amount': 0,
            //                     'tax_repartition_line_id': False,
            //                     'sequence': next_sequence + 1,
            //                 }),
            //             ])
            //         else:
            //             # Base line
            //             existing_line_vals_list.extend([
            //                 Command.create({
            //                     **values,
            //                     'debit': balance if balance > 0.0 else 0.0,
            //                     'credit': -balance if balance < 0.0 else 0.0,
            //                     'amount_currency': values['amount_currency'],
            //                     'sequence': next_sequence,
            //                 }),
            //                 Command.create({
            //                     **values,
            //                     'debit': -balance if balance < 0.0 else 0.0,
            //                     'credit': balance if balance > 0.0 else 0.0,
            //                     'amount_currency': -values['amount_currency'],
            //                     'tax_ids': [],
            //                     'tax_tag_ids': [],
            //                     'sequence': next_sequence + 1,
            //                 }),
            //             ])
            // 
            //         next_sequence += 2
            // 
            // return caba_lines_to_reconcile
            */
            return default;
        }

        public async Task<TEntity> AddPrecomputedValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _add_precomputed_values(self, vals_list):
            // super()._add_precomputed_values(vals_list)
            // for vals in vals_list:
            //     if 'price_unit' in vals and 'technical_price_unit' not in vals:
            //         vals['technical_price_unit'] = vals['price_unit']
            */
            return default;
        }

        public async Task<TEntity> AdditionalNamePerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _additional_name_per_id(self):
            // return {
            //     so_line.id: so_line._get_partner_display()
            //     for so_line in self
            // }
            */
            return default;
        }

        public async Task<TEntity> AffectTaxReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _affect_tax_report(self):
            // self.ensure_one()
            // return self.tax_ids or self.tax_line_id or self.tax_tag_ids.filtered(lambda x: x.applicability == "taxes")
            */
            return default;
        }

        public async Task<TEntity> AllReconciledLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _all_reconciled_lines(self):
            // """Get all the the lines matched with the lines in self."""
            // return self._filter_reconciled_by_number(self._reconciled_by_number())
            */
            return default;
        }

        public async Task<TEntity> AmountResidualInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _amount_residual(self):
            // for rec in self:
            //     total_amount = 0.0
            //     for line in rec.depreciation_line_ids:
            //         if line.move_check:
            //             total_amount += line.amount
            //     rec.value_residual = rec.value - total_amount - rec.salvage_value
            */
            return default;
        }

        public async Task<TEntity> AttachDocumentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def attach_document(self, **kwargs):
            // """When an attachment is uploaded as a receipt, set it as the main attachment."""
            // self._message_set_main_attachment_id(self.env["ir.attachment"].browse(kwargs['attachment_ids'][-1:]), force=True)
            */
            return default;
        }

        public async Task<TEntity> CanBeInvoicedAloneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _can_be_invoiced_alone(self):
            // """ Whether a given line is meaningful to invoice alone.
            // 
            // It is generally meaningless/confusing or even wrong to invoice some specific SOlines
            // (delivery, discounts, rewards, ...) without others, unless they are the only left to invoice
            // in the SO.
            // """
            // self.ensure_one()
            // return self.product_id.id != self.company_id.sale_discount_product_id.id
            */
            return default;
        }

        public async Task<TEntity> CheckAlternativeWorkcenterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _check_alternative_workcenter(self):
            // for workcenter in self:
            //     if workcenter in workcenter.alternative_workcenter_ids:
            //         raise ValidationError(_("Workcenter %s cannot be an alternative of itself.", workcenter.name))
            */
            return default;
        }

        public async Task<TEntity> CheckAmlsExigibilityForReconciliationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_amls_exigibility_for_reconciliation(self, shadowed_aml_values=None):
            // """ Ensure the current journal items are eligible to be reconciled together.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // """
            // if not self:
            //     return
            // 
            // if any(aml.reconciled for aml in self):
            //     raise UserError(_("You are trying to reconcile some entries that are already reconciled."))
            // if any(aml.parent_state != 'posted' for aml in self):
            //     raise UserError(_("You can only reconcile posted entries."))
            // accounts = self.mapped(lambda x: x._get_reconciliation_aml_field_value('account_id', shadowed_aml_values))
            // if len(accounts) > 1:
            //     raise UserError(_(
            //         "Entries are not from the same account: %s",
            //         ", ".join(accounts.mapped('display_name')),
            //     ))
            // if len(self.company_id.root_id) > 1:
            //     raise UserError(_(
            //         "Entries don't belong to the same company: %s",
            //         ", ".join(self.company_id.mapped('display_name')),
            //     ))
            // if not accounts.reconcile and accounts.account_type not in ('asset_cash', 'liability_credit_card'):
            //     raise UserError(_(
            //         "Account %s does not allow reconciliation. First change the configuration of this account "
            //         "to allow it.",
            //         accounts.display_name,
            //     ))
            */
            return default;
        }

        public async Task<TEntity> CheckAmountNotZeroAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def check_amount_not_zero(self, vals):
            // error_msgs = []
            // if 'total_amount' in vals:
            //     if any(expense.company_currency_id.is_zero(vals['total_amount']) for expense in self):
            //         error_msgs.append(_("You cannot set the expense total to 0 if it's linked to a report."))
            // if 'total_amount_currency' in vals:
            //     if any(expense.currency_id.is_zero(vals['total_amount_currency']) for expense in self):
            //         error_msgs.append(_("You cannot set the expense total in currency to 0 if it's linked to a report."))
            // if error_msgs:
            //     raise UserError("\n".join(error_msgs))
            */
            return default;
        }

        public async Task<TEntity> CheckCabaNonCabaSharedTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_caba_non_caba_shared_tags(self):
            // """ When mixing cash basis and non cash basis taxes, it is important
            // that those taxes don't share tags on the repartition creating
            // a single account.move.line.
            // 
            // Shared tags in this context cannot work, as the tags would need to
            // be present on both the invoice and cash basis move, leading to the same
            // base amount to be taken into account twice; which is wrong.This is
            // why we don't support that. A workaround may be provided by the use of
            // a group of taxes, whose children are type_tax_use=None, and only one
            // of them uses the common tag.
            // 
            // Note that taxes of the same exigibility are allowed to share tags.
            // """
            // def get_base_repartition(base_aml, taxes):
            //     if not taxes:
            //         return self.env['account.tax.repartition.line']
            // 
            //     is_refund = base_aml.is_refund
            //     repartition_field = is_refund and 'refund_repartition_line_ids' or 'invoice_repartition_line_ids'
            //     return taxes.mapped(repartition_field)
            // 
            // for aml in self:
            //     caba_taxes = aml.tax_ids.filtered(lambda x: x.tax_exigibility == 'on_payment')
            //     non_caba_taxes = aml.tax_ids - caba_taxes
            // 
            //     caba_base_tags = get_base_repartition(aml, caba_taxes).filtered(lambda x: x.repartition_type == 'base').tag_ids
            //     non_caba_base_tags = get_base_repartition(aml, non_caba_taxes).filtered(lambda x: x.repartition_type == 'base').tag_ids
            // 
            //     common_tags = caba_base_tags & non_caba_base_tags
            // 
            //     if not common_tags:
            //         # When a tax is affecting another one with different tax exigibility, tags cannot be shared either.
            //         tax_tags = aml.tax_repartition_line_id.tag_ids
            //         comparison_tags = non_caba_base_tags if aml.tax_repartition_line_id.tax_id.tax_exigibility == 'on_payment' else caba_base_tags
            //         common_tags = tax_tags & comparison_tags
            // 
            //     if common_tags:
            //         raise ValidationError(_("Taxes exigible on payment and on invoice cannot be mixed on the same journal item if they share some tag."))
            */
            return default;
        }

        public async Task<TEntity> CheckCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _check_capacity(self):
            // if any(workcenter.default_capacity <= 0.0 for workcenter in self):
            //     raise exceptions.UserError(_('The capacity must be strictly positive.'))
            */
            return default;
        }

        public async Task<TEntity> CheckComboItemIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _check_combo_item_id(self):
            // """ `combo_item_id` should never be set manually. This constraint mainly serves to avoid
            // programming errors.
            // """
            // for line in self:
            //     linked_line = line._get_linked_line()
            //     allowed_combo_items = linked_line.product_template_id.combo_ids.combo_item_ids
            //     if line.combo_item_id and line.combo_item_id not in allowed_combo_items:
            //         raise ValidationError(_(
            //             "A sale order line's combo item must be among its linked line's available"
            //             " combo items."
            //         ))
            //     if line.combo_item_id and line.combo_item_id.product_id != line.product_id:
            //         raise ValidationError(_(
            //             "A sale order line's product must match its combo item's product."
            //         ))
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py) ---
            // def _check_company_accounts(self):
            // """Ensure accounts specific to a company isn't used in any distribution model that wouldn't be specific to the company"""
            // query = SQL(
            //     """
            //     SELECT model.id
            //       FROM account_analytic_distribution_model model
            //       JOIN account_analytic_account account
            //         ON ARRAY[account.id::text] && %s
            //      WHERE account.company_id IS NOT NULL AND model.id = ANY(%s)
            //        AND (model.company_id IS NULL 
            //         OR model.company_id != account.company_id)
            //     """,
            //     self._query_analytic_accounts('model'),
            //     self.ids,
            // )
            // self.flush_model(['company_id', 'analytic_distribution'])
            // self.env.cr.execute(query)
            // if self.env.cr.dictfetchone():
            //     raise UserError(_('You defined a distribution with analytic account(s) belonging to a specific company but a model shared between companies or with a different company'))
            */
            return default;
        }

        public async Task<TEntity> CheckConstrainsAccountIdJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_constrains_account_id_journal_id(self):
            // # Avoid using api.constrains for fields journal_id and account_id as in case of a write on
            // # account move and account move line in the same operation, the check would be done
            // # before all write are complete, causing a false positive
            // for line in self.filtered(lambda x: x.display_type not in ('line_section', 'line_note')):
            //     account = line.account_id
            //     journal = line.move_id.journal_id
            // 
            //     if account.deprecated and not self.env.context.get('skip_account_deprecation_check'):
            //         raise UserError(_('The account %(name)s (%(code)s) is deprecated.', name=account.name, code=account.code))
            // 
            //     account_currency = account.currency_id
            //     if account_currency and account_currency != line.company_currency_id and account_currency != line.currency_id:
            //         raise UserError(_('The account selected on your journal entry forces to provide a secondary currency. You should remove the secondary currency on the account.'))
            // 
            //     if account.allowed_journal_ids and journal not in account.allowed_journal_ids:
            //         raise UserError(_('You cannot use this account (%s) in this journal, check the field \'Allowed Journals\' on the related account.', account.display_name))
            // 
            //     if account in (journal.default_account_id, journal.suspense_account_id):
            //         continue
            // 
            //     is_account_control_ok = not journal.account_control_ids or account in journal.account_control_ids
            // 
            //     if not is_account_control_ok:
            //         raise UserError(_("You cannot use this account (%s) in this journal, check the section 'Control-Access' under "
            //                           "tab 'Advanced Settings' on the related journal.", account.display_name))
            */
            return default;
        }

        public async Task<TEntity> CheckEdiLineTaxRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_edi_line_tax_required(self):
            // return self.product_id.type != 'combo'
            */
            return default;
        }

        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def check_field_access_rights(self, operation, field_names):
            // result = super().check_field_access_rights(operation, field_names)
            // if not field_names:
            //     weirdos = ['term_key', 'epd_key', 'epd_needed', 'discount_allocation_key', 'discount_allocation_needed']
            //     result = [fname for fname in result if fname not in weirdos]
            // return result
            */
            return default;
        }

        public async Task<TEntity> CheckLineUnlinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _check_line_unlink(self):
            // """ Check whether given lines can be deleted or not.
            // 
            // * Lines cannot be deleted if the order is confirmed.
            // * Down payment lines who have not yet been invoiced bypass that exception.
            // * Sections and Notes can always be deleted.
            // 
            // :returns: Sales Order Lines that cannot be deleted
            // :rtype: `sale.order.line` recordset
            // """
            // return self.filtered(
            //     lambda line:
            //         line.state == 'sale'
            //         and (line.invoice_lines or not line.is_downpayment)
            //         and not line.display_type
            // )
            */
            return default;
        }

        public async Task<TEntity> CheckOffBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_off_balance(self):
            // for line in self.move_id.line_ids:
            //     if line.account_id.account_type == 'off_balance':
            //         if any(a.account_type != line.account_id.account_type for a in line.move_id.line_ids.account_id):
            //             raise UserError(_('If you want to use "Off-Balance Sheet" accounts, all the accounts of the journal entry must be of this type'))
            //         if line.tax_ids or line.tax_line_id:
            //             raise UserError(_('You cannot use taxes on lines with an Off-Balance account'))
            //         if line.reconciled:
            //             raise UserError(_('Lines from "Off-Balance Sheet" accounts cannot be reconciled'))
            */
            return default;
        }

        public async Task<TEntity> CheckPayableReceivableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_payable_receivable(self):
            // for line in self:
            //     account_type = line.account_id.account_type
            //     if line.move_id.is_sale_document(include_receipts=True):
            //         if account_type == 'liability_payable':
            //             raise UserError(_("Account %s is of payable type, but is used in a sale operation.", line.account_id.code))
            //         if (line.display_type == 'payment_term') ^ (account_type == 'asset_receivable'):
            //             raise UserError(_("Any journal item on a receivable account must have a due date and vice versa."))
            //     if line.move_id.is_purchase_document(include_receipts=True):
            //         if account_type == 'asset_receivable':
            //             raise UserError(_("Account %s is of receivable type, but is used in a purchase operation.", line.account_id.code))
            //         if (line.display_type == 'payment_term') ^ (account_type == 'liability_payable'):
            //             raise UserError(_("Any journal item on a payable account must have a due date and vice versa."))
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _check_payment_mode(self):
            // self.sheet_id._check_payment_mode()
            */
            return default;
        }

        public async Task<TEntity> CheckProductUomCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_product_uom_category_id(self):
            // for line in self:
            //     if line.product_uom_id and line.product_id and line.product_uom_id.category_id != line.product_id.product_tmpl_id.uom_id.category_id:
            //         raise UserError(_(
            //             "The Unit of Measure (UoM) '%(uom)s' you have selected for product '%(product)s', "
            //             "is incompatible with its category : %(category)s.",
            //             uom=line.product_uom_id.name,
            //             product=line.product_id.name,
            //             category=line.product_id.product_tmpl_id.uom_id.category_id.name
            //         ))
            */
            return default;
        }

        public async Task<TEntity> CheckProrataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _check_prorata(self):
            // if self.prorata and self.method_time != 'number':
            //     raise ValidationError(_('Prorata temporis can be applied only for the "number of depreciations" time method.'))
            */
            return default;
        }

        public async Task<TEntity> CheckReconciliationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_reconciliation(self):
            // for line in self:
            //     if line.matched_debit_ids or line.matched_credit_ids:
            //         raise UserError(_("You cannot do this modification on a reconciled journal entry. "
            //                           "You can just change some non legal fields or you must unreconcile first.\n"
            //                           "Journal Entry (id): %(entry)s (%(id)s)", entry=line.move_id.name, id=line.move_id.id))
            */
            return default;
        }

        public async Task<TEntity> CheckTaxLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _check_tax_lock_date(self):
            // for line in self:
            //     move = line.move_id
            //     if move.state != 'posted':
            //         continue
            //     violated_lock_dates = move.company_id._get_lock_date_violations(
            //         move.date,
            //         fiscalyear=False,
            //         sale=False,
            //         purchase=False,
            //         tax=True,
            //         hard=True,
            //     )
            //     if violated_lock_dates and line._affect_tax_report():
            //         raise UserError(_("The operation is refused as it would impact an already issued tax statement. "
            //                           "Please change the journal entry date or the following lock dates to proceed: %(lock_date_info)s.",
            //                           lock_date_info=self.env['res.company']._format_lock_dates(violated_lock_dates)))
            // return True
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_account_id(self):
            // term_lines = self.filtered(lambda line: line.display_type == 'payment_term')
            // if term_lines:
            //     moves = term_lines.move_id
            //     self.env.cr.execute("""
            //         WITH previous AS (
            //             SELECT DISTINCT ON (line.move_id)
            //                    'account.move' AS model,
            //                    line.move_id AS id,
            //                    NULL AS account_type,
            //                    line.account_id AS account_id
            //               FROM account_move_line line
            //              WHERE line.move_id = ANY(%(move_ids)s)
            //                AND line.display_type = 'payment_term'
            //                AND line.id != ANY(%(current_ids)s)
            //         ),
            //         fallback AS (
            //             SELECT DISTINCT ON (account_companies.res_company_id, account.account_type)
            //                    'res.company' AS model,
            //                    account_companies.res_company_id AS id,
            //                    account.account_type AS account_type,
            //                    account.id AS account_id
            //               FROM account_account account
            //               JOIN account_account_res_company_rel account_companies
            //                    ON account_companies.account_account_id = account.id
            //              WHERE account_companies.res_company_id = ANY(%(company_ids)s)
            //                AND account.account_type IN ('asset_receivable', 'liability_payable')
            //                AND account.deprecated = 'f'
            //         )
            //         SELECT * FROM previous
            //         UNION ALL
            //         SELECT * FROM fallback
            //     """, {
            //         'company_ids': moves.company_id.ids,
            //         'move_ids': moves.ids,
            //         'partners': [f'res.partner,{pid}' for pid in moves.commercial_partner_id.ids],
            //         'current_ids': term_lines.ids
            //     })
            //     accounts = {
            //         (model, id, account_type): account_id
            //         for model, id, account_type, account_id in self.env.cr.fetchall()
            //     }
            //     for line in term_lines:
            //         account_type = 'asset_receivable' if line.move_id.is_sale_document(include_receipts=True) else 'liability_payable'
            //         move = line.move_id
            //         account_id = (
            //             accounts.get(('account.move', move.id, None))
            //             or move.with_company(move.company_id).commercial_partner_id['property_account_receivable_id' if account_type == 'asset_receivable' else 'property_account_payable_id'].id
            //             or move.with_company(move.company_id).company_id.partner_id['property_account_receivable_id' if account_type == 'asset_receivable' else 'property_account_payable_id'].id
            //             or accounts.get(('res.company', move.company_id.id, account_type))
            //         )
            //         if line.move_id.fiscal_position_id:
            //             account_id = line.move_id.fiscal_position_id.map_account(self.env['account.account'].browse(account_id))
            //         line.account_id = account_id
            // 
            // product_lines = self.filtered(lambda line: line.display_type == 'product' and line.move_id.is_invoice(True))
            // for line in product_lines:
            //     if line.product_id:
            //         fiscal_position = line.move_id.fiscal_position_id
            //         accounts = line.with_company(line.company_id).product_id\
            //             .product_tmpl_id.get_product_accounts(fiscal_pos=fiscal_position)
            //         if line.move_id.is_sale_document(include_receipts=True):
            //             line.account_id = accounts['income'] or line.account_id
            //         elif line.move_id.is_purchase_document(include_receipts=True):
            //             line.account_id = accounts['expense'] or line.account_id
            //     elif line.partner_id:
            //         account_id = self.env['account.account']._get_most_frequent_account_for_partner(
            //             company_id=line.company_id.id,
            //             partner_id=line.partner_id.id,
            //             move_type=line.move_id.move_type,
            //             journal_id=line.journal_id.id,
            //         )
            //         if account_id:
            //             line.account_id = account_id
            // for line in self:
            //     if not line.account_id and line.display_type not in ('line_section', 'line_note'):
            //         previous_two_accounts = line.move_id.line_ids.filtered(
            //             lambda l: l.account_id and l.display_type == line.display_type
            //         )[-2:].account_id
            //         if len(previous_two_accounts) == 1 and len(line.move_id.line_ids) > 2:
            //             line.account_id = previous_two_accounts
            //         else:
            //             line.account_id = line.move_id.journal_id.default_account_id
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_account_id(self):
            // property_field = self.env['product.category']._fields['property_account_expense_categ_id']
            // for _expense in self:
            //     expense = _expense.with_company(_expense.company_id)
            //     if not expense.product_id:
            //         expense.account_id = property_field.get_company_dependent_fallback(self.env['product.category'])
            //         continue
            //     account = expense.product_id.product_tmpl_id._get_product_accounts()['expense']
            //     if account:
            //         expense.account_id = account
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_amount_currency(self):
            // for line in self:
            //     if line.amount_currency is False:
            //         line.amount_currency = line.currency_id.round(line.balance * line.currency_rate)
            //     if line.currency_id == line.company_id.currency_id:
            //         line.amount_currency = line.balance
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_amount(self):
            // for line in self:
            //     base_line = line._prepare_base_line_for_taxes_computation()
            //     self.env['account.tax']._add_tax_details_in_base_line(base_line, line.company_id)
            //     line.price_subtotal = base_line['tax_details']['raw_total_excluded_currency']
            //     line.price_total = base_line['tax_details']['raw_total_included_currency']
            //     line.price_tax = line.price_total - line.price_subtotal
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_amount(self):
            // for line in self:
            //     base_line = line._prepare_base_line_for_taxes_computation()
            //     self.env['account.tax']._add_tax_details_in_base_line(base_line, line.company_id)
            //     line.price_subtotal = base_line['tax_details']['raw_total_excluded_currency']
            //     line.price_total = base_line['tax_details']['raw_total_included_currency']
            //     line.price_tax = line.price_total - line.price_subtotal
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_amount_invoiced(self):
            // for line in self:
            //     amount_invoiced = 0.0
            //     for invoice_line in line._get_invoice_lines():
            //         invoice = invoice_line.move_id
            //         if invoice.state == 'posted' or invoice_line.move_id.payment_state == 'invoicing_legacy':
            //             invoice_date = invoice.invoice_date or fields.Date.context_today(self)
            //             amount_invoiced_unsigned = invoice_line.currency_id._convert(invoice_line.price_total, line.currency_id, line.company_id, invoice_date)
            //             amount_invoiced += amount_invoiced_unsigned * -invoice.direction_sign
            //     line.amount_invoiced = amount_invoiced
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountResidualInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_amount_residual(self):
            // """ Computes the residual amount of a move line from a reconcilable account in the company currency and the line's currency.
            //     This amount will be 0 for fully reconciled lines or lines from a non-reconcilable account, the original line amount
            //     for unreconciled lines, and something in-between for partially reconciled lines.
            // """
            // need_residual_lines = self.filtered(lambda x: x.account_id.reconcile or x.account_id.account_type in ('asset_cash', 'liability_credit_card'))
            // # Run the residual amount computation on all lines stored in the db. By
            // # using _origin, new records (with a NewId) are excluded and the
            // # computation works automagically for virtual onchange records as well.
            // stored_lines = need_residual_lines._origin
            // 
            // if stored_lines:
            //     self.env['account.partial.reconcile'].flush_model()
            //     self.env['res.currency'].flush_model(['decimal_places'])
            // 
            //     aml_ids = tuple(stored_lines.ids)
            //     self._cr.execute('''
            //         SELECT
            //             part.debit_move_id AS line_id,
            //             'debit' AS flag,
            //             COALESCE(SUM(part.amount), 0.0) AS amount,
            //             ROUND(SUM(part.debit_amount_currency), curr.decimal_places) AS amount_currency
            //         FROM account_partial_reconcile part
            //         JOIN res_currency curr ON curr.id = part.debit_currency_id
            //         WHERE part.debit_move_id IN %s
            //         GROUP BY part.debit_move_id, curr.decimal_places
            //         UNION ALL
            //         SELECT
            //             part.credit_move_id AS line_id,
            //             'credit' AS flag,
            //             COALESCE(SUM(part.amount), 0.0) AS amount,
            //             ROUND(SUM(part.credit_amount_currency), curr.decimal_places) AS amount_currency
            //         FROM account_partial_reconcile part
            //         JOIN res_currency curr ON curr.id = part.credit_currency_id
            //         WHERE part.credit_move_id IN %s
            //         GROUP BY part.credit_move_id, curr.decimal_places
            //     ''', [aml_ids, aml_ids])
            //     amounts_map = {
            //         (line_id, flag): (amount, amount_currency)
            //         for line_id, flag, amount, amount_currency in self.env.cr.fetchall()
            //     }
            // else:
            //     amounts_map = {}
            // 
            // # Lines that can't be reconciled with anything since the account doesn't allow that.
            // for line in self - need_residual_lines:
            //     line.amount_residual = 0.0
            //     line.amount_residual_currency = 0.0
            //     line.reconciled = False
            // 
            // for line in need_residual_lines:
            //     # Since this part could be call on 'new' records, 'company_currency_id'/'currency_id' could be not set.
            //     comp_curr = line.company_currency_id or self.env.company.currency_id
            //     foreign_curr = line.currency_id or comp_curr
            // 
            //     # Retrieve the amounts in both foreign/company currencies. If the record is 'new', the amounts_map is empty.
            //     debit_amount, debit_amount_currency = amounts_map.get((line._origin.id, 'debit'), (0.0, 0.0))
            //     credit_amount, credit_amount_currency = amounts_map.get((line._origin.id, 'credit'), (0.0, 0.0))
            // 
            //     # Subtract the values from the account.partial.reconcile to compute the residual amounts.
            //     line.amount_residual = comp_curr.round(line.balance - debit_amount + credit_amount)
            //     line.amount_residual_currency = foreign_curr.round(line.amount_currency - debit_amount_currency + credit_amount_currency)
            //     line.reconciled = (
            //         comp_curr.is_zero(line.amount_residual)
            //         and foreign_curr.is_zero(line.amount_residual_currency)
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_amount_to_invoice(self):
            // for line in self:
            //     if line.product_uom_qty:
            //         uom_qty_to_consider = line.qty_delivered if line.product_id.invoice_policy == 'delivery' else line.product_uom_qty
            //         qty_to_invoice = uom_qty_to_consider - line.qty_invoiced_posted
            //         unit_price_total = line.price_total / line.product_uom_qty
            //         line.amount_to_invoice = unit_price_total * qty_to_invoice
            //     else:
            //         line.amount_to_invoice = 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_amount_type(self):
            // for line in self:
            //     if line.rule_type == 'writeoff_button' and line.model_id.counterpart_type in ('sale', 'purchase'):
            //         line.amount_type = line.amount_type or 'percentage_st_line'
            //     else:
            //         line.amount_type = line.amount_type or 'percentage'
            */
            return default;
        }

        public async Task<TEntity> ComputeAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_analytic_distribution(self):
            // cache = {}
            // for line in self:
            //     if line.display_type == 'product' or not line.move_id.is_invoice(include_receipts=True):
            //         related_distribution = line._related_analytic_distribution()
            //         root_plans = self.env['account.analytic.account'].browse(
            //             list({int(account_id) for ids in related_distribution for account_id in ids.split(',')})
            //         ).exists().root_plan_id
            // 
            //         arguments = frozendict({
            //             "product_id": line.product_id.id,
            //             "product_categ_id": line.product_id.categ_id.id,
            //             "partner_id": line.partner_id.id,
            //             "partner_category_id": line.partner_id.category_id.ids,
            //             "account_prefix": line.account_id.code,
            //             "company_id": line.company_id.id,
            //             "related_root_plan_ids": root_plans,
            //         })
            //         if arguments not in cache:
            //             cache[arguments] = self.env['account.analytic.distribution.model']._get_distribution(arguments)
            //         line.analytic_distribution = related_distribution | cache[arguments] or line.analytic_distribution
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _compute_analytic_distribution(self):
            // pass
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_analytic_distribution(self):
            // for expense in self:
            //     distribution = self.env['account.analytic.distribution.model']._get_distribution({
            //         'product_id': expense.product_id.id,
            //         'product_categ_id': expense.product_id.categ_id.id,
            //         'partner_id': expense.employee_id.work_contact_id.id,
            //         'partner_category_id': expense.employee_id.work_contact_id.category_id.ids,
            //         'account_prefix': expense.account_id.code,
            //         'company_id': expense.company_id.id,
            //     })
            //     expense.analytic_distribution = distribution or expense.analytic_distribution
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_analytic_distribution(self):
            // for line in self:
            //     if not line.display_type:
            //         distribution = self.env['account.analytic.distribution.model']._get_distribution({
            //             "product_id": line.product_id.id,
            //             "product_categ_id": line.product_id.categ_id.id,
            //             "partner_id": line.order_id.partner_id.id,
            //             "partner_category_id": line.order_id.partner_id.category_id.ids,
            //             "company_id": line.company_id.id,
            //         })
            //         line.analytic_distribution = distribution or line.analytic_distribution
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_analytic_distribution(self):
            // for line in self:
            //     if not line.display_type:
            //         distribution = line.env['account.analytic.distribution.model']._get_distribution({
            //             "product_id": line.product_id.id,
            //             "product_categ_id": line.product_id.categ_id.id,
            //             "partner_id": line.order_id.partner_id.id,
            //             "partner_category_id": line.order_id.partner_id.category_id.ids,
            //             "company_id": line.company_id.id,
            //         })
            //         line.analytic_distribution = distribution or line.analytic_distribution
            */
            return default;
        }

        public async Task<TEntity> ComputeBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_balance(self):
            // for line in self:
            //     if line.display_type in ('line_section', 'line_note'):
            //         line.balance = False
            //     elif not line.move_id.is_invoice(include_receipts=True):
            //         # Only act as a default value when none of balance/debit/credit is specified
            //         # balance is always the written field because of `_sanitize_vals`.
            //         # Virtual record holds just the differences coming from the onchange
            //         # so we need to recover balance of stored lines to calculate correctly the
            //         # new line balance.
            //         active_line_ids = [lid for lid in self.env.context.get('line_ids', []) if isinstance(lid, int)]
            //         existing_lines = self.env['account.move.line'].browse(active_line_ids)
            //         outdated_lines = line.move_id.line_ids._origin
            //         new_lines = line.move_id.line_ids - line
            //         line.balance = -sum((existing_lines - outdated_lines + new_lines).mapped('balance'))
            //     else:
            //         line.balance = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeBlockedTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_blocked_time(self):
            // # TDE FIXME: productivity loss type should be only losses, probably count other time logs differently ??
            // data = self.env['mrp.workcenter.productivity']._read_group([
            //     ('date_start', '>=', fields.Datetime.to_string(datetime.now() - relativedelta.relativedelta(months=1))),
            //     ('workcenter_id', 'in', self.ids),
            //     ('date_end', '!=', False),
            //     ('loss_type', '!=', 'productive')],
            //     ['workcenter_id'], ['duration:sum'])
            // count_data = {workcenter.id: duration for workcenter, duration in data}
            // for workcenter in self:
            //     workcenter.blocked_time = count_data.get(workcenter.id, 0.0) / 60.0
            */
            return default;
        }

        public async Task<TEntity> ComputeBoardAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object residual_amount, object amount_to_depr, object undone_dotation_number, List<Guid> posted_depreciation_line_ids, object total_days, object depreciation_date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _compute_board_amount(self, sequence, residual_amount, amount_to_depr,
            //                       undone_dotation_number, posted_depreciation_line_ids,
            //                       total_days, depreciation_date):
            // amount = 0
            // if sequence == undone_dotation_number:
            //     amount = residual_amount
            // else:
            //     if self.method == 'linear':
            //         amount = amount_to_depr / (undone_dotation_number - len(posted_depreciation_line_ids))
            //         if self.prorata:
            //             amount = amount_to_depr / self.method_number
            //             if sequence == 1:
            //                 date = self.date
            //                 if self.method_period % 12 != 0:
            //                     month_days = calendar.monthrange(date.year, date.month)[1]
            //                     days = month_days - date.day + 1
            //                     amount = (amount_to_depr / self.method_number) / month_days * days
            //                 else:
            //                     days = (self.company_id.compute_fiscalyear_dates(date)['date_to'] - date).days + 1
            //                     amount = (amount_to_depr / self.method_number) / total_days * days
            //     elif self.method == 'degressive':
            //         amount = residual_amount * self.method_progress_factor
            //         if self.prorata:
            //             if sequence == 1:
            //                 date = self.date
            //                 if self.method_period % 12 != 0:
            //                     month_days = calendar.monthrange(date.year, date.month)[1]
            //                     days = month_days - date.day + 1
            //                     amount = (residual_amount * self.method_progress_factor) / month_days * days
            //                 else:
            //                     days = (self.company_id.compute_fiscalyear_dates(date)['date_to'] - date).days + 1
            //                     amount = (residual_amount * self.method_progress_factor) / total_days * days
            // return amount
            */
            return default;
        }

        public async Task<TEntity> ComputeBoardUndoneDotationNbInternalAsync<TEntity>(IEnumerable<TEntity> entities, object depreciation_date, object total_days) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _compute_board_undone_dotation_nb(self, depreciation_date, total_days):
            // undone_dotation_number = self.method_number
            // if self.method_time == 'end':
            //     end_date = self.method_end
            //     undone_dotation_number = 0
            //     while depreciation_date <= end_date:
            //         depreciation_date = date(depreciation_date.year, depreciation_date.month,
            //                                  depreciation_date.day) + relativedelta(months=+self.method_period)
            //         undone_dotation_number += 1
            // if self.prorata:
            //     undone_dotation_number += 1
            // return undone_dotation_number
            */
            return default;
        }

        public async Task<TEntity> ComputeCostsHourAccountIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workcenter.py) ---
            // def _compute_costs_hour_account_ids(self):
            // for record in self:
            //     record.costs_hour_account_ids = bool(record.analytic_distribution) and self.env['account.analytic.account'].browse(
            //         list({int(account_id) for ids in record.analytic_distribution for account_id in ids.split(",")})
            //     ).exists()
            */
            return default;
        }

        public async Task<TEntity> ComputeCumulatedBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_cumulated_balance(self):
            // if not self.env.context.get('order_cumulated_balance'):
            //     # We do not come from search_fetch, so we are not in a list view, so it doesn't make any sense to compute the cumulated balance
            //     self.cumulated_balance = 0
            //     return
            // 
            // # get the where clause
            // query = self._where_calc(list(self.env.context.get('domain_cumulated_balance') or []))
            // sql_order = self._order_to_sql(self.env.context.get('order_cumulated_balance'), query, reverse=True)
            // result = dict(self.env.execute_query(query.select(
            //     SQL.identifier(query.table, "id"),
            //     SQL(
            //         "SUM(%s) OVER (ORDER BY %s ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)",
            //         SQL.identifier(query.table, "balance"),
            //         sql_order,
            //     ),
            // )))
            // for record in self:
            //     record.cumulated_balance = result[record.id]
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_currency_id(self):
            // for line in self:
            //     if line.display_type == 'cogs':
            //         line.currency_id = line.company_currency_id
            //     elif line.move_id.is_invoice(include_receipts=True):
            //         line.currency_id = line.move_id.currency_id
            //     else:
            //         line.currency_id = line.currency_id or line.company_id.currency_id
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_currency_id(self):
            // for expense in self:
            //     if expense.product_has_cost and expense.state in {'draft', 'reported'}:
            //         expense.currency_id = expense.company_currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_currency_rate(self):
            // for line in self:
            //     if line.move_id.is_invoice(include_receipts=True):
            //         line.currency_rate = line.move_id.invoice_currency_rate
            //     elif line.currency_id:
            //         line.currency_rate = self.env['res.currency']._get_conversion_rate(
            //             from_currency=line.company_currency_id,
            //             to_currency=line.currency_id,
            //             company=line.company_id,
            //             date=line.move_id.invoice_date or line.move_id.date or fields.Date.context_today(line),
            //         )
            //     else:
            //         line.currency_rate = 1
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_currency_rate(self):
            // """
            //     We want the default odoo rate when the following change:
            //     - the currency of the expense
            //     - the total amount in foreign currency
            //     - the date of the expense
            //     this will cause the rate to be recomputed twice with possible changes but we don't have the required fields
            //     to store the override state in stable
            // """
            // date_today = fields.Date.context_today(self)
            // for expense in self:
            //     if expense.is_multiple_currency:
            //         if (
            //                 expense.currency_id != expense._origin.currency_id
            //                 or expense.total_amount_currency != expense._origin.total_amount_currency
            //                 or expense.date != expense._origin.date
            //         ):
            //             expense._set_expense_currency_rate(date_today=date_today)
            //         else:
            //             expense.currency_rate = expense.total_amount / expense.total_amount_currency if expense.total_amount_currency else 1.0
            //     else:  # Mono-currency case computation shortcut, no need for the label if there is no conversion
            //         expense.currency_rate = 1.0
            //         expense.label_currency_rate = False
            //         continue
            // 
            //     expense.label_currency_rate = _(
            //         '1 %(exp_cur)s = %(rate)s %(comp_cur)s',
            //         exp_cur=expense.currency_id.name,
            //         rate=float_repr(expense.currency_rate, 6),
            //         comp_cur=expense.company_currency_id.name,
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeCustomAttributeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_custom_attribute_values(self):
            // for line in self:
            //     if not line.product_id:
            //         line.product_custom_attribute_value_ids = False
            //         continue
            //     if not line.product_custom_attribute_value_ids:
            //         continue
            //     valid_values = line.product_id.product_tmpl_id.valid_product_template_attribute_line_ids.product_template_value_ids
            //     # remove the is_custom values that don't belong to this template
            //     for pacv in line.product_custom_attribute_value_ids:
            //         if pacv.custom_product_template_attribute_value_id not in valid_values:
            //             line.product_custom_attribute_value_ids -= pacv
            */
            return default;
        }

        public async Task<TEntity> ComputeCustomerLeadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_customer_lead(self):
            // self.customer_lead = 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputeDebitCreditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_debit_credit(self):
            // for line in self:
            //     if not line.is_storno:
            //         line.debit = line.balance if line.balance > 0.0 else 0.0
            //         line.credit = -line.balance if line.balance < 0.0 else 0.0
            //     else:
            //         line.debit = line.balance if line.balance < 0.0 else 0.0
            //         line.credit = -line.balance if line.balance > 0.0 else 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputeDepreciationBoardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def compute_depreciation_board(self):
            // self.ensure_one()
            // 
            // posted_depreciation_line_ids = self.depreciation_line_ids.filtered(lambda x: x.move_check).sorted(key=lambda l: l.depreciation_date)
            // unposted_depreciation_line_ids = self.depreciation_line_ids.filtered(lambda x: not x.move_check)
            // 
            // # Remove old unposted depreciation lines. We cannot use unlink() with One2many field
            // commands = [(2, line_id.id, False) for line_id in unposted_depreciation_line_ids]
            // 
            // if self.value_residual != 0.0:
            //     amount_to_depr = residual_amount = self.value_residual
            // 
            //     # if we already have some previous validated entries, starting date is last entry + method period
            //     if posted_depreciation_line_ids and posted_depreciation_line_ids[-1].depreciation_date:
            //         last_depreciation_date = fields.Date.from_string(posted_depreciation_line_ids[-1].depreciation_date)
            //         depreciation_date = last_depreciation_date + relativedelta(months=+self.method_period)
            //     else:
            //         # depreciation_date computed from the purchase date
            //         depreciation_date = self.date
            //         if self.date_first_depreciation == 'last_day_period':
            //             # depreciation_date = the last day of the month
            //             depreciation_date = depreciation_date + relativedelta(day=31)
            //             # ... or fiscalyear depending the number of period
            //             if self.method_period == 12:
            //                 depreciation_date = depreciation_date + relativedelta(month=int(self.company_id.fiscalyear_last_month))
            //                 depreciation_date = depreciation_date + relativedelta(day=int(self.company_id.fiscalyear_last_day))
            //                 if depreciation_date < self.date:
            //                     depreciation_date = depreciation_date + relativedelta(years=1)
            //         elif self.first_depreciation_manual_date and self.first_depreciation_manual_date != self.date:
            //             # depreciation_date set manually from the 'first_depreciation_manual_date' field
            //             depreciation_date = self.first_depreciation_manual_date
            //     total_days = (depreciation_date.year % 4) and 365 or 366
            //     month_day = depreciation_date.day
            //     undone_dotation_number = self._compute_board_undone_dotation_nb(depreciation_date, total_days)
            // 
            //     for x in range(len(posted_depreciation_line_ids), undone_dotation_number):
            //         sequence = x + 1
            //         amount = self._compute_board_amount(sequence, residual_amount, amount_to_depr,
            //                                             undone_dotation_number, posted_depreciation_line_ids,
            //                                             total_days, depreciation_date)
            //         amount = self.currency_id.round(amount)
            //         if float_is_zero(amount, precision_rounding=self.currency_id.rounding):
            //             continue
            //         residual_amount -= amount
            //         vals = {
            //             'amount': amount,
            //             'asset_id': self.id,
            //             'sequence': sequence,
            //             'name': (self.code or '') + '/' + str(sequence),
            //             'remaining_value': residual_amount,
            //             'depreciated_value': self.value - (self.salvage_value + residual_amount),
            //             'depreciation_date': depreciation_date,
            //         }
            //         commands.append((0, False, vals))
            // 
            //         depreciation_date = depreciation_date + relativedelta(months=+self.method_period)
            // 
            //         if month_day > 28 and self.date_first_depreciation == 'manual':
            //             max_day_in_month = calendar.monthrange(depreciation_date.year, depreciation_date.month)[1]
            //             depreciation_date = depreciation_date.replace(day=min(max_day_in_month, month_day))
            // 
            //         # datetime doesn't take into account that the number of days is not the same for each month
            //         if not self.prorata and self.method_period % 12 != 0 and self.date_first_depreciation == 'last_day_period':
            //             max_day_in_month = calendar.monthrange(depreciation_date.year, depreciation_date.month)[1]
            //             depreciation_date = depreciation_date.replace(day=max_day_in_month)
            // 
            // self.write({'depreciation_line_ids': commands})
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ComputeDiscountAllocationKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_discount_allocation_key(self):
            // for line in self:
            //     if line.display_type == 'discount':
            //         line.discount_allocation_key = frozendict({
            //             'account_id': line.account_id.id,
            //             'move_id': line.move_id.id,
            //             'currency_rate': line.currency_rate,
            //         })
            //     else:
            //         line.discount_allocation_key = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDiscountAllocationNeededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_discount_allocation_needed(self):
            // line2discounted_amount = {
            //     line: [
            //         (line.account_id, amount),
            //         (discount_allocation_account, -amount),
            //     ]
            //     for line in self.move_id.line_ids
            //     if line.display_type == 'product'
            //     and (discount_allocation_account := line.move_id._get_discount_allocation_account())
            //     and line.account_id != discount_allocation_account
            //     and (amount := line.currency_id.round(
            //         line.move_id.direction_sign * line.quantity * line.price_unit * line.discount / 100
            //     ))
            // }
            // 
            // distribution_totals = defaultdict(lambda: defaultdict(float))
            // for line, discounted_amounts in line2discounted_amount.items():
            //     for account, amount in discounted_amounts:
            //         for analytic_account_id in line.analytic_distribution or {}:
            //             distribution_totals[frozendict({
            //                 'move_id': line.move_id.id,
            //                 'account_id': account.id,
            //                 'currency_rate': line.currency_rate,
            //             })][analytic_account_id] += amount
            // 
            // for line in self:
            //     line.discount_allocation_dirty = True
            //     if line not in line2discounted_amount:
            //         line.discount_allocation_needed = False
            //         continue
            // 
            //     discount_allocation_needed = {}
            //     for account, amount in line2discounted_amount[line]:
            //         key = frozendict({
            //             'move_id': line.move_id.id,
            //             'account_id': account.id,
            //             'currency_rate': line.currency_rate,
            //         })
            //         dist = distribution_totals[key]
            //         total = sum(dist.values()) or 1  # avoid division by zero
            //         discount_allocation_needed[key] = frozendict({
            //             'display_type': 'discount',
            //             'name': _("Discount"),
            //             'amount_currency': amount,
            //             'analytic_distribution': {
            //                 account_id: 100 * value / total
            //                 for account_id, value in dist.items()
            //             }
            //         })
            //     line.discount_allocation_needed = discount_allocation_needed
            */
            return default;
        }

        public async Task<TEntity> ComputeDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_discount(self):
            // discount_enabled = self.env['product.pricelist.item']._is_discount_feature_enabled()
            // for line in self:
            //     if not line.product_id or line.display_type:
            //         line.discount = 0.0
            // 
            //     if not (line.order_id.pricelist_id and discount_enabled):
            //         continue
            // 
            //     line.discount = 0.0
            // 
            //     if not line.pricelist_item_id._show_discount():
            //         # No pricelist rule was found for the product
            //         # therefore, the pricelist didn't apply any discount/change
            //         # to the existing sales price.
            //         continue
            // 
            //     line = line.with_company(line.company_id)
            //     pricelist_price = line._get_pricelist_price()
            //     base_price = line._get_pricelist_price_before_discount()
            // 
            //     if base_price != 0:  # Avoid division by zero
            //         discount = (base_price - pricelist_price) / base_price * 100
            //         if (discount > 0 and base_price > 0) or (discount < 0 and base_price < 0):
            //             # only show negative discounts if price is negative
            //             # otherwise it's a surcharge which shouldn't be shown to the customer
            //             line.discount = discount
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_display_name(self):
            // for line in self:
            //     line.display_name = line._format_aml_name(line.name or line.product_id.display_name, line.ref, line.move_id.name)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_display_name(self):
            // name_per_id = self._additional_name_per_id()
            // for so_line in self.sudo():
            //     if so_line.order_partner_id.lang:
            //         so_line = so_line.with_context(lang=so_line.order_id._get_lang())
            //     if (product := so_line.product_id).display_name:
            //         default_name = so_line._get_sale_order_line_multiline_description_sale()
            //         if so_line.name == default_name:
            //             description = product.display_name
            //         else:
            //             parts = (so_line.name or "").split('\n', 2)
            //             description = parts[1] if len(parts) > 1 and parts[1] else product.display_name
            //     else:
            //         description = (so_line.name or "").split('\n', 1)[0]
            //     name = f"{so_line.order_id.name} - {description}"
            //     additional_name = name_per_id.get(so_line.id)
            //     if additional_name:
            //         name = f'{name} {additional_name}'
            //     so_line.display_name = name
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_display_type(self):
            // for line in self.filtered(lambda l: not l.display_type):
            //     # avoid cyclic dependencies with _compute_account_id
            //     account_set = self.env.cache.contains(line, line._fields['account_id'])
            //     tax_set = self.env.cache.contains(line, line._fields['tax_line_id'])
            //     line.display_type = (
            //         'tax' if tax_set and line.tax_line_id else
            //         'payment_term' if account_set and line.account_id.account_type in ['asset_receivable', 'liability_payable'] else
            //         'product'
            //     ) if line.move_id.is_invoice() else 'product'
            */
            return default;
        }

        public async Task<TEntity> ComputeDistributionAnalyticAccountIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _compute_distribution_analytic_account_ids(self):
            // all_ids = {int(_id) for rec in self for key in (rec.analytic_distribution or {}) for _id in key.split(',')}
            // existing_accounts_ids = set(self.env['account.analytic.account'].browse(all_ids).exists().ids)
            // for rec in self:
            //     ids = list(unique(int(_id) for key in (rec.analytic_distribution or {}) for _id in key.split(',') if int(_id) in existing_accounts_ids))
            //     rec.distribution_analytic_account_ids = self.env['account.analytic.account'].browse(ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicateExpenseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_duplicate_expense_ids(self):
            // self.duplicate_expense_ids = [Command.clear()]
            // 
            // expenses = self.filtered(lambda expense: expense.employee_id and expense.product_id and expense.total_amount_currency)
            // if expenses.ids:
            //     duplicates_query = """
            //       SELECT ARRAY_AGG(DISTINCT he.id)
            //         FROM hr_expense AS he
            //         JOIN hr_expense AS ex ON he.employee_id = ex.employee_id
            //                              AND he.product_id = ex.product_id
            //                              AND he.date = ex.date
            //                              AND he.total_amount_currency = ex.total_amount_currency
            //                              AND he.company_id = ex.company_id
            //                              AND he.currency_id = ex.currency_id
            //        WHERE ex.id in %(expense_ids)s
            //        GROUP BY he.employee_id, he.product_id, he.date, he.total_amount_currency, he.company_id, he.currency_id
            //       HAVING COUNT(he.id) > 1
            //     """
            //     self.env.cr.execute(duplicates_query, {'expense_ids': tuple(expenses.ids)})
            // 
            //     for duplicates_ids in (x[0] for x in self.env.cr.fetchall()):
            //         expenses_duplicates = expenses.filtered(lambda expense: expense.id in duplicates_ids)
            //         expenses_duplicates.duplicate_expense_ids = [Command.set(duplicates_ids)]
            //         expenses = expenses - expenses_duplicates
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_employee_id(self):
            // if not self.env.context.get('default_employee_id'):
            //     for expense in self:
            //         expense.employee_id = self.env.user.with_company(expense.company_id).employee_id
            */
            return default;
        }

        public async Task<TEntity> ComputeEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object group_entries) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _compute_entries(self, date, group_entries=False):
            // depreciation_ids = self.env['account.asset.depreciation.line'].search([
            //     ('asset_id', 'in', self.ids), ('depreciation_date', '<=', date),
            //     ('move_check', '=', False)])
            // if group_entries:
            //     return depreciation_ids.create_grouped_move()
            // return depreciation_ids.create_move()
            */
            return default;
        }

        public async Task<TEntity> ComputeEpdKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_epd_key(self):
            // for line in self:
            //     pay_term = line.move_id.invoice_payment_term_id
            //     if line.display_type == 'epd' and pay_term.early_discount and pay_term.early_pay_discount_computation == 'mixed':
            //         line.epd_key = frozendict({
            //             'account_id': line.account_id.id,
            //             'analytic_distribution': line.analytic_distribution,
            //             'tax_ids': [Command.set(line.tax_ids.ids)],
            //             'tax_tag_ids': [Command.set(line.tax_tag_ids.ids)],
            //             'move_id': line.move_id.id,
            //         })
            //     else:
            //         line.epd_key = False
            */
            return default;
        }

        public async Task<TEntity> ComputeEpdNeededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_epd_needed(self):
            // # TODO: The computation of early payment is weird because based on the 'price_subtotal'
            // # that already have it's own taxes computation (by design because the sync_dynamic lines only
            // # work when saving the record).
            // # However, the early payment lines also have some taxes and the sync_dynamic_line will compute the tax lines based on
            // # product base lines + epd base lines that could lead to a different amount when using the round globally.
            // for line in self:
            //     line.epd_dirty = True
            //     line.epd_needed = False
            //     has_epd = line.move_id.invoice_payment_term_id.early_discount
            //     discount_percentage = line.move_id.invoice_payment_term_id.discount_percentage
            // 
            //     if not has_epd or line.display_type != 'product' or not line.tax_ids.ids or line.move_id.invoice_payment_term_id.early_pay_discount_computation != 'mixed':
            //         continue
            //     discount_percentage_name = f"{discount_percentage}%"
            //     epd_needed = {}
            //     percentage = discount_percentage / 100
            //     taxes = line.tax_ids.filtered(lambda t: t.amount_type != 'fixed')
            //     epd_needed_vals = epd_needed.setdefault(
            //         frozendict({
            //             'move_id': line.move_id.id,
            //             'account_id': line.account_id.id,
            //             'analytic_distribution': line.analytic_distribution,
            //             'tax_ids': [Command.set(taxes.ids)],
            //             'display_type': 'epd',
            //         }),
            //         {
            //             'name': _("Early Payment Discount (%s)", discount_percentage_name),
            //             'amount_currency': 0.0,
            //             'balance': 0.0,
            //         },
            //     )
            //     sign = line.move_id.direction_sign
            //     rate = line.move_id.invoice_currency_rate
            //     amount_currency = line.currency_id.round(sign * line.price_subtotal * percentage)
            //     balance = line.company_currency_id.round(sign * line.price_subtotal * percentage / rate) if rate else 0.0
            //     epd_needed_vals['amount_currency'] -= amount_currency
            //     epd_needed_vals['balance'] -= balance
            //     epd_needed_vals = epd_needed.setdefault(
            //         frozendict({
            //             'move_id': line.move_id.id,
            //             'account_id': line.account_id.id,
            //             'display_type': 'epd',
            //         }),
            //         {
            //             'name': _("Early Payment Discount (%s)", discount_percentage_name),
            //             'amount_currency': 0.0,
            //             'balance': 0.0,
            //             'tax_ids': [Command.clear()],
            //         },
            //     )
            //     epd_needed_vals['amount_currency'] += amount_currency
            //     epd_needed_vals['balance'] += balance
            //     line.epd_needed = {k: frozendict(v) for k, v in epd_needed.items()}
            */
            return default;
        }

        public async Task<TEntity> ComputeFloatAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_float_amount(self):
            // for record in self:
            //     try:
            //         record.amount = float(record.amount_string)
            //     except ValueError:
            //         record.amount = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeFromProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_from_product(self):
            // for expense in self:
            //     expense.product_has_cost = expense.product_id and not expense.company_currency_id.is_zero(expense.product_id.standard_price)
            //     expense.product_has_tax = bool(expense.product_id.supplier_taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(expense.company_id)))
            */
            return default;
        }

        public async Task<TEntity> ComputeGeneratedEntriesAsync<TEntity>(IEnumerable<TEntity> entities, object date, object asset_type) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def compute_generated_entries(self, date, asset_type=None):
            // # Entries generated : one by grouped category and one by asset from ungrouped category
            // created_move_ids = []
            // type_domain = []
            // if asset_type:
            //     type_domain = [('type', '=', asset_type)]
            // 
            // ungrouped_assets = self.env['account.asset.asset'].search(type_domain + [('state', '=', 'open'), ('category_id.group_entries', '=', False)])
            // created_move_ids += ungrouped_assets._compute_entries(date, group_entries=False)
            // 
            // for grouped_category in self.env['account.asset.category'].search(type_domain + [('group_entries', '=', True)]):
            //     assets = self.env['account.asset.asset'].search([('state', '=', 'open'), ('category_id', '=', grouped_category.id)])
            //     created_move_ids += assets._compute_entries(date, group_entries=True)
            // return created_move_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRoutingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_has_routing_lines(self):
            // for workcenter in self:
            //     workcenter.has_routing_lines = self.env['mrp.routing.workcenter'].search_count([('workcenter_id', '=', workcenter.id)], limit=1)
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_invoice_status(self):
            // """
            // Compute the invoice status of a SO line. Possible statuses:
            // - no: if the SO is not in status 'sale', we consider that there is nothing to
            //   invoice. This is also the default value if the conditions of no other status is met.
            // - to invoice: we refer to the quantity to invoice of the line. Refer to method
            //   `_compute_qty_to_invoice()` for more information on how this quantity is calculated.
            // - upselling: this is possible only for a product invoiced on ordered quantities for which
            //   we delivered more than expected. The could arise if, for example, a project took more
            //   time than expected but we decided not to invoice the extra cost to the client. This
            //   occurs only in state 'sale', the upselling opportunity is removed from the list.
            // - invoiced: the quantity invoiced is larger or equal to the quantity ordered.
            // """
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // for line in self:
            //     if line.state != 'sale':
            //         line.invoice_status = 'no'
            //     elif line.is_downpayment and line.untaxed_amount_to_invoice == 0:
            //         line.invoice_status = 'invoiced'
            //     elif not float_is_zero(line.qty_to_invoice, precision_digits=precision):
            //         line.invoice_status = 'to invoice'
            //     elif line.state == 'sale' and line.product_id.invoice_policy == 'order' and\
            //             line.product_uom_qty >= 0.0 and\
            //             float_compare(line.qty_delivered, line.product_uom_qty, precision_digits=precision) == 1:
            //         line.invoice_status = 'upselling'
            //     elif float_compare(line.qty_invoiced, line.product_uom_qty, precision_digits=precision) >= 0:
            //         line.invoice_status = 'invoiced'
            //     else:
            //         line.invoice_status = 'no'
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_is_editable(self):
            // for expense in self:
            //     if expense.sheet_id:
            //         expense.is_editable = expense.sheet_id.is_editable
            //     else:
            //         expense.is_editable = True
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMultipleCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_is_multiple_currency(self):
            // for expense in self:
            //     expense.is_multiple_currency = expense.currency_id != expense.company_currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductArchivedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_is_product_archived(self):
            // for line in self:
            //     line.is_product_archived = line.product_id and not line.product_id.active
            */
            return default;
        }

        public async Task<TEntity> ComputeIsRefundInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_is_refund(self):
            // for line in self:
            //     is_refund = False
            //     if line.move_id.move_type in ('out_refund', 'in_refund'):
            //         is_refund = True
            //     elif line.move_id.move_type == 'entry':
            //         if line.tax_repartition_line_id:
            //             is_refund = line.tax_repartition_line_id.document_type == 'refund'
            //         else:
            //             tax_type = line.tax_ids[:1].type_tax_use
            //             if tax_type == 'sale' and line.credit == 0:
            //                 is_refund = True
            //             elif tax_type == 'purchase' and line.debit == 0:
            //                 is_refund = True
            // 
            //             if line.tax_ids and line.move_id.reversed_entry_id:
            //                 is_refund = not is_refund
            //     line.is_refund = is_refund
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_journal_id(self):
            // for line in self:
            //     if line.journal_id.type != line.model_id.counterpart_type:
            //         line.journal_id = None
            //     else:
            //         line.journal_id = line.journal_id
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanDashboardGraphInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_kanban_dashboard_graph(self):
            // week_range, date_start, date_stop = self._get_week_range_and_first_last_days()
            // load_data = self._get_workcenter_load_per_week(week_range, date_start, date_stop)
            // load_graph_data = self._prepare_graph_data(load_data, week_range)
            // for wc in self:
            //     wc.kanban_dashboard_graph = json.dumps(load_graph_data[wc.id])
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_name(self):
            // def get_name(line):
            //     values = []
            //     if line.partner_id.lang:
            //         product = line.product_id.with_context(lang=line.partner_id.lang)
            //     else:
            //         product = line.product_id
            //     if not product:
            //         return False
            // 
            //     if line.journal_id.type == 'sale':
            //         values.append(product.display_name)
            //         if product.description_sale:
            //             values.append(product.description_sale)
            //     elif line.journal_id.type == 'purchase':
            //         values.append(product.display_name)
            //         if product.description_purchase:
            //             values.append(product.description_purchase)
            //     return '\n'.join(values) if values else False
            // 
            // term_by_move = (self.move_id.line_ids | self).filtered(lambda l: l.display_type == 'payment_term').sorted(lambda l: l.date_maturity or date.max).grouped('move_id')
            // for line in self.filtered(lambda l: l.move_id.inalterable_hash is False):
            //     if line.display_type == 'payment_term':
            //         term_lines = term_by_move.get(line.move_id, self.env['account.move.line'])
            //         n_terms = len(line.move_id.invoice_payment_term_id.line_ids)
            //         if line.move_id.payment_reference and line.move_id.ref and line.move_id.payment_reference != line.move_id.ref:
            //             name = f'{line.move_id.ref} - {line.move_id.payment_reference}'
            //         else:
            //             name = line.move_id.payment_reference or False
            // 
            //         if n_terms > 1:
            //             index = term_lines._ids.index(line.id) if line in term_lines else len(term_lines)
            // 
            //             name = _('%(name)s installment #%(number)s', name=name if name else '', number=index + 1).lstrip()
            //         if n_terms > 1 or not line.name or line._origin.name == line._origin.move_id.payment_reference or (
            //             line._origin.move_id.payment_reference and line._origin.move_id.ref
            //             and line._origin.name == f'{line._origin.move_id.ref} - {line._origin.move_id.payment_reference}'
            //         ):
            //             line.name = name
            //     if not line.product_id or line.display_type in ('line_section', 'line_note'):
            //         continue
            // 
            //     if not line.name or line._origin.name == get_name(line._origin):
            //         line.name = get_name(line)
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_name(self):
            // for expense in self:
            //     expense.name = expense.name or expense.product_id.display_name
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_name(self):
            // for line in self:
            //     if not line.product_id and not line.is_downpayment:
            //         continue
            // 
            //     lang = line.order_id._get_lang()
            //     if lang != self.env.lang:
            //         line = line.with_context(lang=lang)
            // 
            //     if line.product_id:
            //         line.name = line._get_sale_order_line_multiline_description_sale()
            //         continue
            // 
            //     if line.is_downpayment:
            //         line.name = line._get_downpayment_description()
            */
            return default;
        }

        public async Task<TEntity> ComputeNbAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_nb_attachment(self):
            // attachment_data = self.env['ir.attachment']._read_group(
            //     [('res_model', '=', 'hr.expense'), ('res_id', 'in', self.ids)],
            //     ['res_id'],
            //     ['__count'],
            // )
            // attachment = dict(attachment_data)
            // for expense in self:
            //     expense.nb_attachment = attachment.get(expense._origin.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoVariantAttributeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_no_variant_attribute_values(self):
            // for line in self:
            //     if not line.product_id:
            //         line.product_no_variant_attribute_value_ids = False
            //         continue
            //     if not line.product_no_variant_attribute_value_ids:
            //         continue
            //     valid_values = line.product_id.product_tmpl_id.valid_product_template_attribute_line_ids.product_template_value_ids
            //     # remove the no_variant attributes that don't belong to this template
            //     for ptav in line.product_no_variant_attribute_value_ids:
            //         if ptav._origin not in valid_values:
            //             line.product_no_variant_attribute_value_ids -= ptav
            */
            return default;
        }

        public async Task<TEntity> ComputeOeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_oee(self):
            // for order in self:
            //     if order.productive_time:
            //         order.oee = round(order.productive_time * 100.0 / (order.productive_time + order.blocked_time), 2)
            //     else:
            //         order.oee = 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderedQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _compute_ordered_qty(self):
            // line_found = defaultdict(set)
            // for line in self:
            //     total = 0.0
            //     for po in line.requisition_id.purchase_ids.filtered(lambda purchase_order: purchase_order.state in ['purchase', 'done']):
            //         for po_line in po.order_line.filtered(lambda order_line: order_line.product_id == line.product_id):
            //             if po_line.product_uom != line.product_uom_id:
            //                 total += po_line.product_uom._compute_quantity(po_line.product_qty, line.product_uom_id)
            //             else:
            //                 total += po_line.product_qty
            //     if line.product_id not in line_found[line.requisition_id]:
            //         line.qty_ordered = total
            //         line_found[line.requisition_id].add(line.product_id)
            //     else:
            //         line.qty_ordered = 0
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_partner_id(self):
            // for line in self:
            //     line.partner_id = line.move_id.partner_id.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_payment_date(self):
            // for line in self:
            //     line.payment_date = line.discount_date if line.discount_date and date.today() <= line.discount_date else line.date_maturity
            */
            return default;
        }

        public async Task<TEntity> ComputePerformanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_performance(self):
            // wo_data = self.env['mrp.workorder']._read_group([
            //     ('date_start', '>=', fields.Datetime.to_string(datetime.now() - relativedelta.relativedelta(months=1))),
            //     ('workcenter_id', 'in', self.ids),
            //     ('state', '=', 'done')], ['workcenter_id'], ['duration_expected:sum', 'duration:sum'])
            // duration_expected = {workcenter.id: expected for workcenter, expected, __ in wo_data}
            // duration = {workcenter.id: duration for workcenter, __, duration in wo_data}
            // for workcenter in self:
            //     if duration.get(workcenter.id):
            //         workcenter.performance = 100 * duration_expected.get(workcenter.id, 0.0) / duration[workcenter.id]
            //     else:
            //         workcenter.performance = 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputePriceReduceTaxexclInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_price_reduce_taxexcl(self):
            // for line in self:
            //     line.price_reduce_taxexcl = line.price_subtotal / line.product_uom_qty if line.product_uom_qty else 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputePriceReduceTaxincInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_price_reduce_taxinc(self):
            // for line in self:
            //     line.price_reduce_taxinc = line.price_total / line.product_uom_qty if line.product_uom_qty else 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitAndDatePlannedAndNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_price_unit_and_date_planned_and_name(self):
            // for line in self:
            //     if not line.product_id or line.invoice_lines or not line.company_id:
            //         continue
            //     params = line._get_select_sellers_params()
            //     seller = line.product_id._select_seller(
            //         partner_id=line.partner_id,
            //         quantity=line.product_qty,
            //         date=line.order_id.date_order and line.order_id.date_order.date() or fields.Date.context_today(line),
            //         uom_id=line.product_uom,
            //         params=params)
            // 
            //     if seller or not line.date_planned:
            //         line.date_planned = line._get_date_planned(seller).strftime(DEFAULT_SERVER_DATETIME_FORMAT)
            // 
            //     # If not seller, use the standard price. It needs a proper currency conversion.
            //     if not seller:
            //         line.discount = 0
            //         unavailable_seller = line.product_id.seller_ids.filtered(
            //             lambda s: s.partner_id == line.order_id.partner_id)
            //         if not unavailable_seller and line.price_unit and line.product_uom == line._origin.product_uom:
            //             # Avoid to modify the price unit if there is no price list for this partner and
            //             # the line has already one to avoid to override unit price set manually.
            //             continue
            //         po_line_uom = line.product_uom or line.product_id.uom_po_id
            //         price_unit = line.env['account.tax']._fix_tax_included_price_company(
            //             line.product_id.uom_id._compute_price(line.product_id.standard_price, po_line_uom),
            //             line.product_id.supplier_taxes_id,
            //             line.taxes_id,
            //             line.company_id,
            //         )
            //         price_unit = line.product_id.cost_currency_id._convert(
            //             price_unit,
            //             line.currency_id,
            //             line.company_id,
            //             line.date_order or fields.Date.context_today(line),
            //             False
            //         )
            //         line.price_unit = float_round(price_unit, precision_digits=max(line.currency_id.decimal_places, self.env['decimal.precision'].precision_get('Product Price')))
            // 
            //     elif seller:
            //         price_unit = line.env['account.tax']._fix_tax_included_price_company(seller.price, line.product_id.supplier_taxes_id, line.taxes_id, line.company_id) if seller else 0.0
            //         price_unit = seller.currency_id._convert(price_unit, line.currency_id, line.company_id, line.date_order or fields.Date.context_today(line), False)
            //         price_unit = float_round(price_unit, precision_digits=max(line.currency_id.decimal_places, self.env['decimal.precision'].precision_get('Product Price')))
            //         line.price_unit = seller.product_uom._compute_price(price_unit, line.product_uom)
            //         line.discount = seller.discount or 0.0
            // 
            //     # record product names to avoid resetting custom descriptions
            //     default_names = []
            //     vendors = line.product_id._prepare_sellers(params=params)
            //     product_ctx = {'seller_id': None, 'partner_id': None, 'lang': get_lang(line.env, line.partner_id.lang).code}
            //     default_names.append(line._get_product_purchase_description(line.product_id.with_context(product_ctx)))
            //     for vendor in vendors:
            //         product_ctx = {'seller_id': vendor.id, 'lang': get_lang(line.env, line.partner_id.lang).code}
            //         default_names.append(line._get_product_purchase_description(line.product_id.with_context(product_ctx)))
            //     if not line.name or line.name in default_names:
            //         product_ctx = {'seller_id': seller.id, 'lang': get_lang(line.env, line.partner_id.lang).code}
            //         line.name = line._get_product_purchase_description(line.product_id.with_context(product_ctx))
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitDiscountedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_price_unit_discounted(self):
            // for line in self:
            //     line.price_unit_discounted = line.price_unit * (1 - line.discount / 100)
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_price_unit(self):
            // for line in self:
            //     if not line.product_id or line.display_type in ('line_section', 'line_note') or line.is_imported:
            //         continue
            //     if line.move_id.is_sale_document(include_receipts=True):
            //         document_type = 'sale'
            //     elif line.move_id.is_purchase_document(include_receipts=True):
            //         document_type = 'purchase'
            //     else:
            //         document_type = 'other'
            //     line.price_unit = line.product_id._get_tax_included_unit_price(
            //         line.move_id.company_id,
            //         line.move_id.currency_id,
            //         line.move_id.date,
            //         document_type,
            //         fiscal_position=line.move_id.fiscal_position_id,
            //         product_uom=line.product_uom_id,
            //     )
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_price_unit(self):
            // """
            //    The price_unit is the unit price of the product if no product is set and no attachment overrides it.
            //    Otherwise it is always computed from the total_amount and the quantity else it would break the vendor bill
            //    when edited after creation.
            // """
            // for expense in self:
            //     if expense.state not in {'draft', 'reported'}:
            //         continue
            //     product_id = expense.product_id
            //     if expense._needs_product_price_computation():
            //         expense.price_unit = product_id._price_compute(
            //             'standard_price',
            //             uom=expense.product_uom_id,
            //             company=expense.company_id,
            //         )[product_id.id]
            //     else:
            //         expense.price_unit = expense.company_currency_id.round(expense.total_amount / expense.quantity) if expense.quantity else 0.
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _compute_price_unit(self):
            // for line in self:
            //     if line.requisition_id.state != 'draft' or line.requisition_id.requisition_type != 'purchase_template' or not line.requisition_id.vendor_id or not line.product_id:
            //         continue
            //     seller = line.product_id._select_seller(
            //         partner_id=line.requisition_id.vendor_id, quantity=line.product_qty,
            //         date=line.requisition_id.date_start, uom_id=line.product_uom_id)
            //     line.price_unit = seller.price if seller else line.product_id.standard_price
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_price_unit(self):
            // for line in self:
            //     # Don't compute the price for deleted lines.
            //     if not line.order_id:
            //         continue
            //     # check if the price has been manually set or there is already invoiced amount.
            //     # if so, the price shouldn't change as it might have been manually edited.
            //     if (
            //         (line.technical_price_unit != line.price_unit and not line.env.context.get('force_price_recomputation'))
            //         or line.qty_invoiced > 0
            //         or (line.product_id.expense_policy == 'cost' and line.is_expense)
            //     ):
            //         continue
            //     line = line.with_context(sale_write_from_compute=True)
            //     if not line.product_uom or not line.product_id:
            //         line.price_unit = 0.0
            //         line.technical_price_unit = 0.0
            //     else:
            //         line._reset_price_unit()
            */
            return default;
        }

        public async Task<TEntity> ComputePricelistItemIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_pricelist_item_id(self):
            // for line in self:
            //     if not line.product_id or line.display_type or not line.order_id.pricelist_id:
            //         line.pricelist_item_id = False
            //     else:
            //         line.pricelist_item_id = line.order_id.pricelist_id._get_product_rule(
            //             line.product_id,
            //             quantity=line.product_uom_qty or 1.0,
            //             uom=line.product_uom,
            //             date=line._get_order_date(),
            //         )
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_product_description(self):
            // for expense in self:
            //     expense.product_description = not is_html_empty(expense.product_id.description) and expense.product_id.description
            */
            return default;
        }

        public async Task<TEntity> ComputeProductPackagingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_product_packaging_id(self):
            // for line in self:
            //     # remove packaging if not match the product
            //     if line.product_packaging_id.product_id != line.product_id:
            //         line.product_packaging_id = False
            //     # suggest biggest suitable packaging matching the PO's company
            //     if line.product_id and line.product_qty and line.product_uom:
            //         suggested_packaging = line.product_id.packaging_ids\
            //                 .filtered(lambda p: p.purchase and (p.product_id.company_id <= p.company_id <= line.company_id))\
            //                 ._find_suitable_product_packaging(line.product_qty, line.product_uom)
            //         line.product_packaging_id = suggested_packaging or line.product_packaging_id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_product_packaging_id(self):
            // for line in self:
            //     # remove packaging if not match the product
            //     if line.product_packaging_id.product_id != line.product_id:
            //         line.product_packaging_id = False
            //     # suggest biggest suitable packaging matching the SO's company
            //     if line.product_id and line.product_uom_qty and line.product_uom:
            //         suggested_packaging = line.product_id.packaging_ids\
            //                 .filtered(lambda p: p.sales and (p.product_id.company_id <= p.company_id <= line.company_id))\
            //                 ._find_suitable_product_packaging(line.product_uom_qty, line.product_uom)
            //         line.product_packaging_id = suggested_packaging or line.product_packaging_id
            */
            return default;
        }

        public async Task<TEntity> ComputeProductPackagingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_product_packaging_qty(self):
            // self.product_packaging_qty = 0
            // for line in self:
            //     if not line.product_packaging_id:
            //         continue
            //     line.product_packaging_qty = line.product_packaging_id._compute_qty(line.product_qty, line.product_uom)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_product_packaging_qty(self):
            // self.product_packaging_qty = 0
            // for line in self:
            //     if not line.product_packaging_id:
            //         continue
            //     line.product_packaging_qty = line.product_packaging_id._compute_qty(line.product_uom_qty, line.product_uom)
            */
            return default;
        }

        public async Task<TEntity> ComputeProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_product_qty(self):
            // for line in self:
            //     if line.product_packaging_id:
            //         packaging_uom = line.product_packaging_id.product_uom_id
            //         qty_per_packaging = line.product_packaging_id.qty
            //         product_qty = packaging_uom._compute_quantity(line.product_packaging_qty * qty_per_packaging, line.product_uom)
            //         if float_compare(product_qty, line.product_qty, precision_rounding=line.product_uom.rounding) != 0:
            //             line.product_qty = product_qty
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_product_template_id(self):
            // for line in self:
            //     line.product_template_id = line.product_id.product_tmpl_id
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_product_uom_id(self):
            // for line in self.filtered(lambda l: l.parent_state == 'draft'):
            //     # vendor bills should have the product purchase UOM
            //     if line.move_id.is_purchase_document():
            //         line.product_uom_id = line.product_id.uom_po_id
            //     else:
            //         line.product_uom_id = line.product_id.uom_id
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _compute_product_uom_id(self):
            // for line in self:
            //     line.product_uom_id = line.product_id.uom_id
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_product_uom(self):
            // for line in self:
            //     if not line.product_uom or (line.product_id.uom_id.id != line.product_uom.id):
            //         line.product_uom = line.product_id.uom_id
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_product_uom_qty(self):
            // for line in self:
            //     if line.product_id and line.product_id.uom_id != line.product_uom:
            //         line.product_uom_qty = line.product_uom._compute_quantity(line.product_qty, line.product_id.uom_id)
            //     else:
            //         line.product_uom_qty = line.product_qty
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_product_uom_qty(self):
            // for line in self:
            //     if line.display_type:
            //         line.product_uom_qty = 0.0
            //         continue
            // 
            //     if not line.product_packaging_id:
            //         continue
            //     packaging_uom = line.product_packaging_id.product_uom_id
            //     qty_per_packaging = line.product_packaging_id.qty
            //     product_uom_qty = packaging_uom._compute_quantity(
            //         line.product_packaging_qty * qty_per_packaging, line.product_uom)
            //     if float_compare(product_uom_qty, line.product_uom_qty, precision_rounding=line.product_uom.rounding) != 0:
            //         line.product_uom_qty = product_uom_qty
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_product_uom_readonly(self):
            // for line in self:
            //     # line.ids checks whether it's a new record not yet saved
            //     line.product_uom_readonly = line.ids and line.state in ['sale', 'cancel']
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUpdatableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_product_updatable(self):
            // self.product_updatable = True
            // for line in self:
            //     if (
            //         line.is_downpayment
            //         or line.state == 'cancel'
            //         or line.state == 'sale' and (
            //             line.order_id.locked
            //             or line.qty_invoiced > 0
            //             or line.qty_delivered > 0
            //         )
            //     ):
            //         line.product_updatable = False
            */
            return default;
        }

        public async Task<TEntity> ComputeProductiveTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_productive_time(self):
            // # TDE FIXME: productivity loss type should be only losses, probably count other time logs differently
            // data = self.env['mrp.workcenter.productivity']._read_group([
            //     ('date_start', '>=', fields.Datetime.to_string(datetime.now() - relativedelta.relativedelta(months=1))),
            //     ('workcenter_id', 'in', self.ids),
            //     ('date_end', '!=', False),
            //     ('loss_type', '=', 'productive')],
            //     ['workcenter_id'], ['duration:sum'])
            // count_data = {workcenter.id: duration for workcenter, duration in data}
            // for workcenter in self:
            //     workcenter.productive_time = count_data.get(workcenter.id, 0.0) / 60.0
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyDeliveredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_qty_delivered(self):
            // """ This method compute the delivered quantity of the SO lines: it covers the case provide by sale module, aka
            //     expense/vendor bills (sum of unit_amount of AAL), and manual case.
            //     This method should be overridden to provide other way to automatically compute delivered qty. Overrides should
            //     take their concerned so lines, compute and set the `qty_delivered` field, and call super with the remaining
            //     records.
            // """
            // # compute for analytic lines
            // lines_by_analytic = self.filtered(lambda sol: sol.qty_delivered_method == 'analytic')
            // mapping = lines_by_analytic._get_delivered_quantity_by_analytic([('amount', '<=', 0.0)])
            // for so_line in lines_by_analytic:
            //     so_line.qty_delivered = mapping.get(so_line.id or so_line._origin.id, 0.0)
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyDeliveredMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_qty_delivered_method(self):
            // """ Sale module compute delivered qty for product [('type', 'in', ['consu']), ('service_type', '=', 'manual')]
            //         - consu + expense_policy : analytic (sum of analytic unit_amount)
            //         - consu + no expense_policy : manual (set manually on SOL)
            //         - service (+ service_type='manual', the only available option) : manual
            // 
            //     This is true when only sale is installed: sale_stock redifine the behavior for 'consu' type,
            //     and sale_timesheet implements the behavior of 'service' + service_type=timesheet.
            // """
            // for line in self:
            //     if line.is_expense:
            //         line.qty_delivered_method = 'analytic'
            //     else:  # service and consu
            //         line.qty_delivered_method = 'manual'
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_invoiced(self):
            // for line in self:
            //     # compute qty_invoiced
            //     qty = 0.0
            //     for inv_line in line._get_invoice_lines():
            //         if inv_line.move_id.state not in ['cancel'] or inv_line.move_id.payment_state == 'invoicing_legacy':
            //             if inv_line.move_id.move_type == 'in_invoice':
            //                 qty += inv_line.product_uom_id._compute_quantity(inv_line.quantity, line.product_uom)
            //             elif inv_line.move_id.move_type == 'in_refund':
            //                 qty -= inv_line.product_uom_id._compute_quantity(inv_line.quantity, line.product_uom)
            //     line.qty_invoiced = qty
            // 
            //     # compute qty_to_invoice
            //     if line.order_id.state in ['purchase', 'done']:
            //         if line.product_id.purchase_method == 'purchase':
            //             line.qty_to_invoice = line.product_qty - line.qty_invoiced
            //         else:
            //             line.qty_to_invoice = line.qty_received - line.qty_invoiced
            //     else:
            //         line.qty_to_invoice = 0
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_qty_invoiced(self):
            // """
            // Compute the quantity invoiced. If case of a refund, the quantity invoiced is decreased. Note
            // that this is the case only if the refund is generated from the SO and that is intentional: if
            // a refund made would automatically decrease the invoiced quantity, then there is a risk of reinvoicing
            // it automatically, which may not be wanted at all. That's why the refund has to be created from the SO
            // """
            // for line in self:
            //     qty_invoiced = 0.0
            //     for invoice_line in line._get_invoice_lines():
            //         if invoice_line.move_id.state != 'cancel' or invoice_line.move_id.payment_state == 'invoicing_legacy':
            //             if invoice_line.move_id.move_type == 'out_invoice':
            //                 qty_invoiced += invoice_line.product_uom_id._compute_quantity(invoice_line.quantity, line.product_uom)
            //             elif invoice_line.move_id.move_type == 'out_refund':
            //                 qty_invoiced -= invoice_line.product_uom_id._compute_quantity(invoice_line.quantity, line.product_uom)
            //     line.qty_invoiced = qty_invoiced
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyInvoicedPostedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_qty_invoiced_posted(self):
            // """
            // This method is almost identical to '_compute_qty_invoiced()'. The only difference lies in the fact that
            // for accounting purposes, we only want the quantities of the posted invoices.
            // We need a dedicated computation because the triggers are different and could lead to incorrect values for
            // 'qty_invoiced' when computed together.
            // """
            // for line in self:
            //     qty_invoiced_posted = 0.0
            //     for invoice_line in line._get_invoice_lines():
            //         if invoice_line.move_id.state == 'posted' or invoice_line.move_id.payment_state == 'invoicing_legacy':
            //             qty_unsigned = invoice_line.product_uom_id._compute_quantity(invoice_line.quantity, line.product_uom)
            //             qty_signed = qty_unsigned * -invoice_line.move_id.direction_sign
            //             qty_invoiced_posted += qty_signed
            //     line.qty_invoiced_posted = qty_invoiced_posted
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_received(self):
            // for line in self:
            //     if line.qty_received_method == 'manual':
            //         line.qty_received = line.qty_received_manual or 0.0
            //     else:
            //         line.qty_received = 0.0
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyReceivedMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_received_method(self):
            // for line in self:
            //     if line.product_id and line.product_id.type in ['consu', 'service']:
            //         line.qty_received_method = 'manual'
            //     else:
            //         line.qty_received_method = False
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_qty_to_invoice(self):
            // """
            // Compute the quantity to invoice. If the invoice policy is order, the quantity to invoice is
            // calculated from the ordered quantity. Otherwise, the quantity delivered is used.
            // For combo product lines, compute the value if a linked combo item line gets recomputed,
            // and set `qty_to_invoice` only if at least one of its combo item lines is invoiceable.
            // """
            // combo_lines = set()
            // for line in self:
            //     if line.state == 'sale' and not line.display_type:
            //         if line.product_id.type == 'combo':
            //             combo_lines.add(line)
            //         elif line.product_id.invoice_policy == 'order':
            //             line.qty_to_invoice = line.product_uom_qty - line.qty_invoiced
            //         else:
            //             line.qty_to_invoice = line.qty_delivered - line.qty_invoiced
            //         if line.combo_item_id and line.linked_line_id:
            //             combo_lines.add(line.linked_line_id)
            //     else:
            //         line.qty_to_invoice = 0
            // for combo_line in combo_lines:
            //     if any(
            //         line.combo_item_id and line.qty_to_invoice
            //         for line in combo_line.linked_line_ids
            //     ):
            //         combo_line.qty_to_invoice = combo_line.product_uom_qty - combo_line.qty_invoiced
            //     else:
            //         combo_line.qty_to_invoice = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_quantity(self):
            // for line in self:
            //     if line.display_type == 'product':
            //         line.quantity = line.quantity if line.quantity else 1
            //     else:
            //         line.quantity = False
            */
            return default;
        }

        public async Task<TEntity> ComputeSameCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_same_currency(self):
            // for record in self:
            //     record.is_same_currency = record.currency_id == record.company_currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeSameReceiptExpenseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_same_receipt_expense_ids(self):
            // self.same_receipt_expense_ids = [Command.clear()]
            // 
            // expenses_with_attachments = self.filtered(lambda expense: expense.attachment_ids)
            // if not expenses_with_attachments:
            //     return
            // 
            // expenses_groupby_checksum = dict(self.env['ir.attachment']._read_group(domain=[
            //     ('res_model', '=', 'hr.expense'),
            //     ('checksum', 'in', expenses_with_attachments.attachment_ids.mapped('checksum'))],
            //     groupby=['checksum'],
            //     aggregates=['res_id:array_agg'],
            // ))
            // 
            // for expense in expenses_with_attachments:
            //     same_receipt_ids = set()
            //     for attachment in expense.attachment_ids:
            //         same_receipt_ids.update(expenses_groupby_checksum[attachment.checksum])
            //     same_receipt_ids.remove(expense.id)
            // 
            //     expense.same_receipt_expense_ids = [Command.set(list(same_receipt_ids))]
            */
            return default;
        }

        public async Task<TEntity> ComputeSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_sequence(self):
            // seq_map = {
            //     'tax': 10000,
            //     'rounding': 11000,
            //     'payment_term': 12000,
            // }
            // for line in self:
            //     line.sequence = seq_map.get(line.display_type, 100)
            */
            return default;
        }

        public async Task<TEntity> ComputeShowForceTaxIncludedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_show_force_tax_included(self):
            // for record in self:
            //     record.show_force_tax_included = False if len(record.tax_ids) != 1 else True
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_state(self):
            // for expense in self:
            //     if not expense.sheet_id:
            //         expense.state = 'draft'
            //     elif expense.sheet_id.state == 'draft':
            //         expense.state = 'reported'
            //     elif expense.sheet_id.state == 'cancel':
            //         expense.state = 'refused'
            //     elif expense.sheet_id.state in {'approve', 'post'}:
            //         expense.state = 'approved'
            //     elif not expense.sheet_id.account_move_ids:
            //         expense.state = 'submitted'
            //     else:
            //         expense.state = 'done'
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_tax_amount_currency(self):
            // """
            //      Note: as total_amount_currency can be set directly by the user (for product without cost)
            //      or needs to be computed (for product with cost), `untaxed_amount_currency` can't be computed in the same method as `total_amount_currency`.
            // """
            // AccountTax = self.env['account.tax']
            // for expense in self:
            //     base_line = expense._prepare_base_line_for_taxes_computation(
            //         price_unit=expense.total_amount_currency,
            //         quantity=1.0,
            //     )
            //     AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //     AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //     tax_details = base_line['tax_details']
            //     expense.tax_amount_currency = tax_details['total_included_currency'] - tax_details['total_excluded_currency']
            //     expense.untaxed_amount_currency = tax_details['total_excluded_currency']
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_tax_amount(self):
            // """
            //      Note: as total_amount can be set directly by the user when the currency_rate is overriden,
            //      the tax must be computed after the total_amount.
            // """
            // AccountTax = self.env['account.tax']
            // for expense in self:
            //     if expense.is_multiple_currency:
            //         base_line = expense._prepare_base_line_for_taxes_computation(
            //             price_unit=expense.total_amount,
            //             quantity=1.0,
            //             currency=expense.company_currency_id,
            //         )
            //         AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //         AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //         tax_details = base_line['tax_details']
            //         expense.tax_amount = tax_details['total_included_currency'] - tax_details['total_excluded_currency']
            //     else:  # Mono-currency case computation shortcut
            //         expense.tax_amount = expense.tax_amount_currency
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_tax_id(self):
            // for line in self:
            //     line = line.with_company(line.company_id)
            //     fpos = line.order_id.fiscal_position_id or line.order_id.fiscal_position_id._get_fiscal_position(line.order_id.partner_id)
            //     # filter taxes by company
            //     taxes = line.product_id.supplier_taxes_id._filter_taxes_by_company(line.company_id)
            //     line.taxes_id = fpos.map_tax(taxes)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_tax_id(self):
            // lines_by_company = defaultdict(lambda: self.env['sale.order.line'])
            // cached_taxes = {}
            // for line in self:
            //     if line.product_type == 'combo':
            //         line.tax_id = False
            //         continue
            //     lines_by_company[line.company_id] += line
            // for company, lines in lines_by_company.items():
            //     for line in lines.with_company(company):
            //         taxes = None
            //         if line.product_id:
            //             taxes = line.product_id.taxes_id._filter_taxes_by_company(company)
            //         if not line.product_id or not taxes:
            //             # Nothing to map
            //             line.tax_id = False
            //             continue
            //         fiscal_position = line.order_id.fiscal_position_id
            //         cache_key = (fiscal_position.id, company.id, tuple(taxes.ids))
            //         cache_key += line._get_custom_compute_tax_cache_key()
            //         if cache_key in cached_taxes:
            //             result = cached_taxes[cache_key]
            //         else:
            //             result = fiscal_position.map_tax(taxes)
            //             cached_taxes[cache_key] = result
            //         # If company_id is set, always filter taxes by the company
            //         line.tax_id = result
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_tax_ids(self):
            // for line in self:
            //     if line.display_type in ('line_section', 'line_note', 'payment_term') or line.is_imported:
            //         continue
            //     # /!\ Don't remove existing taxes if there is no explicit taxes set on the account.
            //     if line.product_id or (line.display_type != 'discount' and (line.account_id.tax_ids or not line.tax_ids)):
            //         line.tax_ids = line._get_computed_taxes()
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _compute_tax_ids(self):
            // for line in self:
            //     if line.rule_type == 'writeoff_button' and line.model_id.counterpart_type in ('sale', 'purchase'):
            //         line.tax_ids = line.tax_ids.filtered(lambda x: x.type_tax_use == line.model_id.counterpart_type)
            //         if not line.tax_ids:
            //             line.tax_ids = line.account_id.tax_ids.filtered(lambda x: x.type_tax_use == line.model_id.counterpart_type)
            //         if not line.tax_ids:
            //             if line.model_id.counterpart_type == 'purchase' and line.company_id.account_purchase_tax_id:
            //                 line.tax_ids = line.company_id.account_purchase_tax_id
            //             elif line.model_id.counterpart_type == 'sale' and line.company_id.account_sale_tax_id:
            //                 line.tax_ids = line.company_id.account_sale_tax_id
            //     else:
            //         line.tax_ids = line.tax_ids
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_tax_ids(self):
            // for _expense in self:
            //     expense = _expense.with_company(_expense.company_id)
            //     # taxes only from the same company
            //     expense.tax_ids = expense.product_id.supplier_taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(expense.company_id))
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxTagInvertInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_tax_tag_invert(self):
            // for record in self:
            //     origin_move_id = record.move_id.tax_cash_basis_origin_move_id or record.move_id
            //     if not record.tax_repartition_line_id and not record.tax_ids:
            //         # Invoices imported from other softwares might only have kept the tags, not the taxes.
            //         record.tax_tag_invert = record.tax_tag_ids and origin_move_id.is_inbound()
            // 
            //     elif origin_move_id.move_type == 'entry':
            //         # For misc operations, cash basis entries and write-offs from the bank reconciliation widget
            //         tax = record.tax_repartition_line_id.tax_id or record.tax_ids[:1]
            //         is_refund = record.is_refund
            //         tax_type = tax.type_tax_use
            //         if record.display_type == 'epd':  # In case of early payment, tax_tag_invert is independent of the balance of the line
            //             record.tax_tag_invert = tax_type == 'purchase'
            //         else:
            //             record.tax_tag_invert = (tax_type == 'purchase' and is_refund) or (tax_type == 'sale' and not is_refund)
            //     else:
            //         # For invoices with taxes
            //         record.tax_tag_invert = origin_move_id.is_inbound()
            */
            return default;
        }

        public async Task<TEntity> ComputeTermKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_term_key(self):
            // for line in self:
            //     if line.display_type == 'payment_term':
            //         line.term_key = frozendict({
            //             'move_id': line.move_id.id,
            //             'date_maturity': fields.Date.to_date(line.date_maturity),
            //             'discount_date': line.discount_date,
            //         })
            //     else:
            //         line.term_key = False
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_total_amount_currency(self):
            // AccountTax = self.env['account.tax']
            // for expense in self.filtered('product_has_cost'):
            //     base_line = expense._prepare_base_line_for_taxes_computation(price_unit=expense.price_unit, quantity=expense.quantity)
            //     AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //     AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //     expense.total_amount_currency = base_line['tax_details']['total_included_currency']
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_total_amount(self):
            // AccountTax = self.env['account.tax']
            // for expense in self:
            //     if expense.is_multiple_currency:
            //         base_line = expense._prepare_base_line_for_taxes_computation(
            //             price_unit=expense.total_amount_currency * expense.currency_rate,
            //             quantity=1.0,
            //             currency_id=expense.company_currency_id,
            //             rate=1.0,
            //         )
            //         AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //         AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //         expense.total_amount = base_line['tax_details']['total_included_currency']
            //     else:  # Mono-currency case computation shortcut
            //         expense.total_amount = expense.total_amount_currency
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_totals(self):
            // """ Compute 'price_subtotal' / 'price_total' outside of `_sync_tax_lines` because those values must be visible for the
            // user on the UI with draft moves and the dynamic lines are synchronized only when saving the record.
            // """
            // AccountTax = self.env['account.tax']
            // for line in self:
            //     # TODO remove the need of cogs lines to have a price_subtotal/price_total
            //     if line.display_type not in ('product', 'cogs'):
            //         line.price_total = line.price_subtotal = False
            //         continue
            // 
            //     base_line = line.move_id._prepare_product_base_line_for_taxes_computation(line)
            //     AccountTax._add_tax_details_in_base_line(base_line, line.company_id)
            //     line.price_subtotal = base_line['tax_details']['raw_total_excluded_currency']
            //     line.price_total = base_line['tax_details']['raw_total_included_currency']
            */
            return default;
        }

        public async Task<TEntity> ComputeTranslatedProductNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_translated_product_name(self):
            // for line in self:
            //     line.translated_product_name = line.product_id.with_context(
            //         lang=line.order_id._get_lang(),
            //     ).display_name
            */
            return default;
        }

        public async Task<TEntity> ComputeUntaxedAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_untaxed_amount_invoiced(self):
            // """ Compute the untaxed amount already invoiced from the sale order line, taking the refund attached
            //     the so line into account. This amount is computed as
            //         SUM(inv_line.price_subtotal) - SUM(ref_line.price_subtotal)
            //     where
            //         `inv_line` is a customer invoice line linked to the SO line
            //         `ref_line` is a customer credit note (refund) line linked to the SO line
            // """
            // for line in self:
            //     amount_invoiced = 0.0
            //     for invoice_line in line._get_invoice_lines():
            //         if invoice_line.move_id.state == 'posted' or invoice_line.move_id.payment_state == 'invoicing_legacy':
            //             invoice_date = invoice_line.move_id.invoice_date or fields.Date.today()
            //             if invoice_line.move_id.move_type == 'out_invoice':
            //                 amount_invoiced += invoice_line.currency_id._convert(invoice_line.price_subtotal, line.currency_id, line.company_id, invoice_date)
            //             elif invoice_line.move_id.move_type == 'out_refund':
            //                 amount_invoiced -= invoice_line.currency_id._convert(invoice_line.price_subtotal, line.currency_id, line.company_id, invoice_date)
            //     line.untaxed_amount_invoiced = amount_invoiced
            */
            return default;
        }

        public async Task<TEntity> ComputeUntaxedAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_untaxed_amount_to_invoice(self):
            // """ Total of remaining amount to invoice on the sale order line (taxes excl.) as
            //         total_sol - amount already invoiced
            //     where Total_sol depends on the invoice policy of the product.
            // 
            //     Note: Draft invoice are ignored on purpose, the 'to invoice' amount should
            //     come only from the SO lines.
            // """
            // for line in self:
            //     amount_to_invoice = 0.0
            //     if line.state == 'sale':
            //         # Note: do not use price_subtotal field as it returns zero when the ordered quantity is
            //         # zero. It causes problem for expense line (e.i.: ordered qty = 0, deli qty = 4,
            //         # price_unit = 20 ; subtotal is zero), but when you can invoice the line, you see an
            //         # amount and not zero. Since we compute untaxed amount, we can use directly the price
            //         # reduce (to include discount) without using `compute_all()` method on taxes.
            //         price_subtotal = 0.0
            //         uom_qty_to_consider = line.qty_delivered if line.product_id.invoice_policy == 'delivery' else line.product_uom_qty
            //         price_reduce = line.price_unit * (1 - (line.discount or 0.0) / 100.0)
            //         price_subtotal = price_reduce * uom_qty_to_consider
            //         if len(line.tax_id.filtered(lambda tax: tax.price_include)) > 0:
            //             # As included taxes are not excluded from the computed subtotal, `compute_all()` method
            //             # has to be called to retrieve the subtotal without them.
            //             # `price_reduce_taxexcl` cannot be used as it is computed from `price_subtotal` field. (see upper Note)
            //             price_subtotal = line.tax_id.compute_all(
            //                 price_reduce,
            //                 currency=line.currency_id,
            //                 quantity=uom_qty_to_consider,
            //                 product=line.product_id,
            //                 partner=line.order_id.partner_shipping_id)['total_excluded']
            //         inv_lines = line._get_invoice_lines()
            //         if any(inv_lines.mapped(lambda l: l.discount != line.discount)):
            //             # In case of re-invoicing with different discount we try to calculate manually the
            //             # remaining amount to invoice
            //             amount = 0
            //             for l in inv_lines:
            //                 if len(l.tax_ids.filtered(lambda tax: tax.price_include)) > 0:
            //                     amount += l.tax_ids.compute_all(l.currency_id._convert(l.price_unit, line.currency_id, line.company_id, l.date or fields.Date.today(), round=False) * l.quantity)['total_excluded']
            //                 else:
            //                     amount += l.currency_id._convert(l.price_unit, line.currency_id, line.company_id, l.date or fields.Date.today(), round=False) * l.quantity
            // 
            //             amount_to_invoice = max(price_subtotal - amount, 0)
            //         else:
            //             amount_to_invoice = price_subtotal - line.untaxed_amount_invoiced
            // 
            //     line.untaxed_amount_to_invoice = amount_to_invoice
            */
            return default;
        }

        public async Task<TEntity> ComputeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_uom_id(self):
            // for expense in self:
            //     expense.product_uom_id = expense.product_id.uom_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUomQtyAsync<TEntity>(IEnumerable<TEntity> entities, object new_qty, object stock_move, object rounding) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def compute_uom_qty(self, new_qty, stock_move, rounding=True):
            // return self.product_uom._compute_quantity(new_qty, stock_move.product_uom, rounding)
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkingStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_working_state(self):
            // for workcenter in self:
            //     # We search for a productivity line associated to this workcenter having no `date_end`.
            //     # If we do not find one, the workcenter is not currently being used. If we find one, according
            //     # to its `type_loss`, the workcenter is either being used or blocked.
            //     time_log = self.env['mrp.workcenter.productivity'].search([
            //         ('workcenter_id', '=', workcenter.id),
            //         ('date_end', '=', False)
            //     ], limit=1)
            //     if not time_log:
            //         # the workcenter is not being used
            //         workcenter.working_state = 'normal'
            //     elif time_log.loss_type in ('productive', 'performance'):
            //         # the productivity line has a `loss_type` that means the workcenter is being used
            //         workcenter.working_state = 'done'
            //     else:
            //         # the workcenter is blocked
            //         workcenter.working_state = 'blocked'
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkorderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_workorder_count(self):
            // MrpWorkorder = self.env['mrp.workorder']
            // result = {wid: {} for wid in self._ids}
            // result_duration_expected = {wid: 0 for wid in self._ids}
            // # Count Late Workorder
            // data = MrpWorkorder._read_group(
            //     [('workcenter_id', 'in', self.ids), ('state', 'in', ('pending', 'waiting', 'ready')), ('date_start', '<', datetime.now().strftime('%Y-%m-%d'))],
            //     ['workcenter_id'], ['__count'])
            // count_data = {workcenter.id: count for workcenter, count in data}
            // # Count All, Pending, Ready, Progress Workorder
            // res = MrpWorkorder._read_group(
            //     [('workcenter_id', 'in', self.ids)],
            //     ['workcenter_id', 'state'], ['duration_expected:sum', '__count'])
            // for workcenter, state, duration_sum, count in res:
            //     result[workcenter.id][state] = count
            //     if state in ('pending', 'waiting', 'ready', 'progress'):
            //         result_duration_expected[workcenter.id] += duration_sum
            // for workcenter in self:
            //     workcenter.workorder_count = sum(count for state, count in result[workcenter.id].items() if state not in ('done', 'cancel'))
            //     workcenter.workorder_pending_count = result[workcenter.id].get('pending', 0)
            //     workcenter.workcenter_load = result_duration_expected[workcenter.id]
            //     workcenter.workorder_ready_count = result[workcenter.id].get('ready', 0)
            //     workcenter.workorder_progress_count = result[workcenter.id].get('progress', 0)
            //     workcenter.workorder_late_count = count_data.get(workcenter.id, 0)
            */
            return default;
        }

        public async Task<object> ConditionToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string fname, string @operator, object @value, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _condition_to_sql(self, alias: str, fname: str, operator: str, value, query: Query) -> SQL:
            // # Don't use this override when account_report_analytic_groupby is truly in the context
            // # Indeed, when account_report_analytic_groupby is in the context it means that `analytic_distribution`
            // # doesn't have the same format and the table is a temporary one, see _prepare_lines_for_analytic_groupby
            // if fname != 'analytic_distribution' or self.env.context.get('account_report_analytic_groupby'):
            //     return super()._condition_to_sql(alias, fname, operator, value, query)
            // 
            // if operator not in ('=', '!=', 'ilike', 'not ilike', 'in', 'not in'):
            //     raise UserError(_('Operation not supported'))
            // 
            // if operator in ('=', '!=') and isinstance(value, bool):
            //     return super()._condition_to_sql(alias, fname, operator, value, query)
            // 
            // if isinstance(value, str) and operator in ('=', '!=', 'ilike', 'not ilike'):
            //     value = list(self.env['account.analytic.account']._search(
            //         [('display_name', '=' if operator in ('=', '!=') else 'ilike', value)]
            //     ))
            //     operator = 'in' if operator in ('=', 'ilike') else 'not in'
            // 
            // if isinstance(value, int) and operator in ('=', '!='):
            //     value = [value]
            //     operator = 'in' if operator == '=' else 'not in'
            // 
            // # keys can be comma-separated ids, we will split those into an array and then make an array comparison with the list of ids to check
            // analytic_accounts_query = self._query_analytic_accounts()
            // value = [str(id_) for id_ in value if id_]  # list of ids -> list of string
            // if operator == 'in':
            //     return SQL(
            //         "%s && %s",
            //         analytic_accounts_query,
            //         value,
            //     )
            // if operator == 'not in':
            //     return SQL(
            //         "(NOT %s && %s OR %s IS NULL)",
            //         analytic_accounts_query,
            //         value,
            //         self._field_to_sql(alias, 'analytic_distribution', query),
            //     )
            // raise UserError(_('Operation not supported'))
            */
            return default;
        }

        public async Task<TEntity> ConditionalAddToComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object condition) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _conditional_add_to_compute(self, fname, condition):
            // field = self._fields[fname]
            // to_reset = self.filtered(lambda line:
            //     condition(line)
            //     and not self.env.is_protected(field, line)
            // )
            // to_reset.invalidate_recordset([fname])
            // self.env.add_to_compute(field, to_reset)
            */
            return default;
        }

        public async Task<TEntity> ConstrainsMatchingNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _constrains_matching_number(self):
            // for line in self:
            //     if line.matching_number:
            //         if not re.match(r'^((P?\d+)|(I.+))$', line.matching_number):
            //             raise Exception("Invalid matching number format")
            //         elif line.matching_number.startswith('I') and (line.matched_debit_ids or line.matched_credit_ids):
            //             raise ValidationError(_("A temporary number can not be used in a real matching"))
            //         elif line.matching_number.startswith('P') and not (line.matched_debit_ids or line.matched_credit_ids):
            //             raise Exception("Should have partials")
            //         elif line.matching_number.startswith('P') and line.full_reconcile_id:
            //             raise Exception("Should not be partial number")
            //         elif line.matching_number.isdecimal() and not line.full_reconcile_id:
            //             raise Exception("Should not be full number")
            //         elif line.full_reconcile_id and line.matching_number != str(line.full_reconcile_id.id):
            //             raise Exception("Matching number should be the full reconcile")
            //     elif line.matched_debit_ids or line.matched_credit_ids:
            //         raise Exception("Should have number")
            */
            return default;
        }

        public async Task<TEntity> ConvertToMiddleOfDayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _convert_to_middle_of_day(self, date):
            // """Return a datetime which is the noon of the input date(time) according
            // to order user's time zone, convert to UTC time.
            // """
            // return self.order_id.get_order_timezone().localize(datetime.combine(date, time(12))).astimezone(UTC).replace(tzinfo=None)
            */
            return default;
        }

        public async Task<TEntity> ConvertToSolCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object currency) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _convert_to_sol_currency(self, amount, currency):
            // """Convert the given amount from the given currency to the SO(L) currency.
            // 
            // :param float amount: the amount to convert
            // :param currency: currency in which the given amount is expressed
            // :type currency: `res.currency` record
            // :returns: converted amount
            // :rtype: float
            // """
            // self.ensure_one()
            // to_currency = self.currency_id or self.order_id.currency_id
            // if currency and to_currency and currency != to_currency:
            //     conversion_date = self.order_id.date_order or fields.Date.context_today(self)
            //     company = self.company_id or self.order_id.company_id or self.env.company
            //     return currency._convert(
            //         from_amount=amount,
            //         to_currency=to_currency,
            //         company=company,
            //         date=conversion_date,
            //         round=False,
            //     )
            // return amount
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // 
            // for line, vals in zip(self, vals_list):
            //     # Don't copy the name of a payment term line.
            //     if line.display_type == 'payment_term' and line.move_id.is_invoice(True):
            //         del vals['name']
            //     # Don't copy restricted fields of notes
            //     if line.display_type in ('line_section', 'line_note'):
            //         del vals['balance']
            //         del vals['account_id']
            //     # Will be recomputed from the price_unit
            //     if line.display_type == 'product' and line.move_id.is_invoice(True):
            //         del vals['balance']
            //     if self._context.get('include_business_fields'):
            //         line._copy_data_extend_business_fields(vals)
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def copy_data(self, default=None):
            // if default is None:
            //     default = {}
            // default['name'] = self.name + _(' (copy)')
            // return super(AccountAssetAsset, self).copy_data(default)
            */
            return default;
        }

        public async Task<TEntity> CopyDataExtendBusinessFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _copy_data_extend_business_fields(self, values):
            // self.ensure_one()
            */
            return default;
        }

        public async Task<TEntity> CreateAnalyticLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _create_analytic_lines(self):
            // """ Create analytic items upon validation of an account.move.line having an analytic distribution.
            // """
            // self._validate_analytic_distribution()
            // analytic_line_vals = []
            // for line in self:
            //     analytic_line_vals.extend(line._prepare_analytic_lines())
            // 
            // context = dict(self.env.context)
            // context.pop('default_account_id', None)
            // context['skip_analytic_sync'] = True
            // self.env['account.analytic.line'].with_context(context).create(analytic_line_vals)
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def create(self, vals_list):
            // moves = self.env['account.move'].browse({vals['move_id'] for vals in vals_list})
            // container = {'records': self}
            // move_container = {'records': moves}
            // with moves._check_balanced(move_container),\
            //      ExitStack() as exit_stack,\
            //      moves._sync_dynamic_lines(move_container),\
            //      self._sync_invoice(container):
            //     lines = super().create([self._sanitize_vals(vals) for vals in vals_list])
            //     exit_stack.enter_context(self.env.protecting([protected for vals, line in zip(vals_list, lines) for protected in self.env['account.move']._get_protected_vals(vals, line)]))
            //     container['records'] = lines
            // 
            // lines._check_tax_lock_date()
            // 
            // if not self.env.context.get('tracking_disable'):
            //     # Log changes to move lines on each move
            //     tracked_fields = [fname for fname, f in self._fields.items() if hasattr(f, 'tracking') and f.tracking and not (hasattr(f, 'related') and f.related)]
            //     ref_fields = self.env['account.move.line'].fields_get(tracked_fields)
            //     empty_values = dict.fromkeys(tracked_fields)
            //     for move_id, modified_lines in lines.grouped('move_id').items():
            //         if not move_id.posted_before:
            //             continue
            //         for line in modified_lines:
            //             if tracking_value_ids := line._mail_track(ref_fields, empty_values)[1]:
            //                 line.move_id._message_log(
            //                     body=_("Journal Item %s created", line._get_html_link(title=f"#{line.id}")),
            //                     tracking_value_ids=tracking_value_ids
            //                 )
            // 
            // lines.move_id._synchronize_business_models(['line_ids'])
            // lines._check_constrains_account_id_journal_id()
            // return lines
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def create(self, vals_list):
            // """ Format the analytic_distribution float value, so equality on analytic_distribution can be done """
            // decimal_precision = self.env['decimal.precision'].precision_get('Percentage Analytic')
            // vals_list = [self._sanitize_values(vals, decimal_precision) for vals in vals_list]
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def create(self, vals_list):
            // expenses = super().create(vals_list)
            // if self.env.context.get('check_total_amount_not_zero'):
            //     for expense, vals in zip(expenses, vals_list):
            //         expense.check_amount_not_zero(vals)
            // return expenses
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def create(self, vals_list):
            // for values in vals_list:
            //     if values.get('display_type', self.default_get(['display_type'])['display_type']):
            //         values.update(product_id=False, price_unit=0, product_uom_qty=0, product_uom=False, date_planned=False)
            //     else:
            //         values.update(self._prepare_add_missing_fields(values))
            // 
            // lines = super().create(vals_list)
            // for line in lines:
            //     if line.product_id and line.order_id.state == 'purchase':
            //         msg = _("Extra line with %s ", line.product_id.display_name)
            //         line.order_id.message_post(body=msg)
            // return lines
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def create(self, vals_list):
            // lines = super().create(vals_list)
            // for line, vals in zip(lines, vals_list):
            //     if line.requisition_id.requisition_type == 'blanket_order' and line.requisition_id.state not in ['draft', 'cancel', 'done']:
            //         if vals['price_unit'] <= 0.0:
            //             raise UserError(_("You cannot have a negative or unit price of 0 for an already confirmed blanket order."))
            //         supplier_infos = self.env['product.supplierinfo'].search([
            //             ('product_id', '=', vals.get('product_id')),
            //             ('partner_id', '=', line.requisition_id.vendor_id.id),
            //         ])
            //         if not any(s.purchase_requisition_id for s in supplier_infos):
            //             line._create_supplier_info()
            // return lines
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('display_type') or self.default_get(['display_type']).get('display_type'):
            //         vals['product_uom_qty'] = 0.0
            // 
            //     if 'technical_price_unit' in vals and 'price_unit' not in vals:
            //         # price_unit field was set as readonly in the view (but technical_price_unit not)
            //         # the field is not sent by the client and expected to be recomputed, but isn't
            //         # because technical_price_unit is set.
            //         vals.pop('technical_price_unit')
            // 
            // lines = super().create(vals_list)
            // for line in lines:
            //     linked_line = line._get_linked_line()
            //     if linked_line:
            //         line.linked_line_id = linked_line
            // if self.env.context.get('sale_no_log_for_new_lines'):
            //     return lines
            // 
            // for line in lines:
            //     if line.product_id and line.state == 'sale':
            //         msg = _("Extra line with %s", line.product_id.display_name)
            //         line.order_id.message_post(body=msg)
            // 
            // return lines
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def create(self, vals_list):
            // assets = super(AccountAssetAsset, self.with_context(mail_create_nolog=True)).create(vals_list)
            // for asset in assets:
            //     asset.sudo().compute_depreciation_board()
            // return assets
            */
            return default;
        }

        public async Task<TEntity> CreateDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py) ---
            // def _create_domain(self, fname, value):
            // if fname == 'partner_category_id':
            //     value += [False]
            //     return [(fname, 'in', value)]
            // else:
            //     return [(fname, 'in', [value, False])]
            */
            return default;
        }

        public async Task<TEntity> CreateExchangeDifferenceMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exchange_diff_values_list) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _create_exchange_difference_moves(self, exchange_diff_values_list):
            // """ Create the exchange difference journal entry on the current journal items.
            // 
            // :param exchange_diff_values_list:   A list of values to create and reconcile the exchange differences
            //                                     See the '_prepare_exchange_difference_move_vals' method.
            // :return: An account.move recordset.
            // """
            // exchange_move_values_list = []
            // journal_ids = set()
            // for exchange_diff_values in exchange_diff_values_list:
            //     move_vals = exchange_diff_values['move_values']
            //     exchange_move_values_list.append(move_vals)
            // 
            //     if not move_vals['journal_id']:
            //         raise UserError(_(
            //             "You have to configure the 'Exchange Gain or Loss Journal' in your company settings, to manage"
            //             " automatically the booking of accounting entries related to differences between exchange rates."
            //         ))
            // 
            //     journal_ids.add(move_vals['journal_id'])
            // 
            // if not exchange_move_values_list:
            //     return self.env['account.move']
            // 
            // # ==== Check the config ====
            // journals = self.env['account.journal'].browse(list(journal_ids))
            // for journal in journals:
            //     if not journal.company_id.expense_currency_exchange_account_id:
            //         raise UserError(_(
            //             "You should configure the 'Loss Exchange Rate Account' in your company settings, to manage"
            //             " automatically the booking of accounting entries related to differences between exchange rates."
            //         ))
            //     if not journal.company_id.income_currency_exchange_account_id.id:
            //         raise UserError(_(
            //             "You should configure the 'Gain Exchange Rate Account' in your company settings, to manage"
            //             " automatically the booking of accounting entries related to differences between exchange rates."
            //         ))
            // 
            // # ==== Create the move ====
            // exchange_moves = self.env['account.move'].create(exchange_move_values_list)
            // exchange_moves._post(soft=False)
            // 
            // # ==== Reconcile ====
            // reconciliation_plan = []
            // for exchange_move, exchange_diff_values in zip(exchange_moves, exchange_diff_values_list):
            //     for source_line, sequence in exchange_diff_values['to_reconcile']:
            //         exchange_diff_line = exchange_move.line_ids[sequence]
            //         reconciliation_plan.append((source_line + exchange_diff_line))
            // 
            // self\
            //     .with_context(no_exchange_difference=True)\
            //     ._reconcile_plan(reconciliation_plan)
            // 
            // return exchange_moves
            */
            return default;
        }

        public async Task<TEntity> CreateExpenseFromAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids, object view_type) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def create_expense_from_attachments(self, attachment_ids=None, view_type='list'):
            // """
            //     Create the expenses from files.
            // 
            //     :return: An action redirecting to hr.expense list view.
            // """
            // if not attachment_ids:
            //     raise UserError(_("No attachment was provided"))
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // expenses = self.env['hr.expense']
            // 
            // if any(attachment.res_id or attachment.res_model != 'hr.expense' for attachment in attachments):
            //     raise UserError(_("Invalid attachments!"))
            // 
            // product = self.env['product.product'].search([('can_be_expensed', '=', True)])
            // if product:
            //     product = product.filtered(lambda p: p.default_code == "EXP_GEN")[:1] or product[0]
            // else:
            //     raise UserError(_("You need to have at least one category that can be expensed in your database to proceed!"))
            // 
            // for attachment in attachments:
            //     attachment_name = '.'.join(attachment.name.split('.')[:-1])
            //     vals = {
            //         'name': attachment_name,
            //         'price_unit': 0,
            //         'product_id': product.id,
            //     }
            //     if product.property_account_expense_id:
            //         vals['account_id'] = product.property_account_expense_id.id
            //     expense = self.env['hr.expense'].create(vals)
            //     attachment.write({'res_model': 'hr.expense', 'res_id': expense.id})
            // 
            //     expense._message_set_main_attachment_id(attachment, force=True)
            //     expenses += expense
            // return {
            //     'name': _('Generate Expenses'),
            //     'res_model': 'hr.expense',
            //     'type': 'ir.actions.act_window',
            //     'views': [[False, view_type], [False, "form"]],
            //     'domain': [('id', 'in', expenses.ids)],
            //     'context': self.env.context,
            // }
            */
            return default;
        }

        public async Task<TEntity> CreateReconciliationPartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _create_reconciliation_partials(self):
            // '''create the partial reconciliation between all the records in self
            //  :return: A recordset of account.partial.reconcile.
            // '''
            // partials_vals_list, exchange_data = self._prepare_reconciliation_partials([
            //     {
            //         'aml': line,
            //         'amount_residual': line.amount_residual,
            //         'amount_residual_currency': line.amount_residual_currency,
            //     }
            //     for line in self
            // ])
            // partials = self.env['account.partial.reconcile'].create(partials_vals_list)
            // 
            // # ==== Create exchange difference moves ====
            // for index, exchange_values in exchange_data.items():
            //     partials[index].exchange_move_id = self._create_exchange_difference_move(exchange_values)
            // 
            // return partials
            */
            return default;
        }

        public async Task<TEntity> CreateSheetsFromExpenseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _create_sheets_from_expense(self):
            // if self.filtered(lambda expense: not expense.is_editable):
            //     raise UserError(_('You are not authorized to edit this expense.'))
            // sheets = self.env['hr.expense.sheet'].create(self._get_default_expense_sheet_values())
            // return sheets
            */
            return default;
        }

        public async Task<TEntity> CreateSupplierInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _create_supplier_info(self):
            // self.ensure_one()
            // purchase_requisition = self.requisition_id
            // if purchase_requisition.requisition_type == 'blanket_order' and purchase_requisition.vendor_id:
            //     # create a supplier_info only in case of blanket order
            //     self.env['product.supplierinfo'].sudo().create({
            //         'partner_id': purchase_requisition.vendor_id.id,
            //         'product_id': self.product_id.id,
            //         'product_tmpl_id': self.product_id.product_tmpl_id.id,
            //         'price': self.price_unit,
            //         'currency_id': self.requisition_id.currency_id.id,
            //         'purchase_requisition_line_id': self.id,
            //     })
            */
            return default;
        }

        public async Task<TEntity> CronGenerateEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _cron_generate_entries(self):
            // self.compute_generated_entries(datetime.today())
            */
            return default;
        }

        public async Task<TEntity> DefaultEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _default_employee_id(self):
            // employee = self.env.user.employee_id
            // if not employee and not self.env.user.has_group('hr_expense.group_hr_expense_team_approver'):
            //     raise ValidationError(_('The current user has no related employee. Please, create one.'))
            // return employee
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields_list) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def default_get(self, fields_list):
            // defaults = super().default_get(fields_list)
            // quick_encode_suggestion = self.env.context.get('quick_encoding_vals')
            // if quick_encode_suggestion and self.env.context.get('default_display_type') not in ('line_section', 'line_note'):
            //     defaults['account_id'] = quick_encode_suggestion['account_id']
            //     defaults['price_unit'] = quick_encode_suggestion['price_unit']
            //     defaults['tax_ids'] = [Command.set(quick_encode_suggestion['tax_ids'])]
            // elif (journal := self.env['account.journal'].browse(self.env.context.get('journal_id'))) and journal.default_account_id:
            //     defaults['account_id'] = journal.default_account_id
            // return defaults
            */
            return default;
        }

        public async Task<TEntity> EntryCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _entry_count(self):
            // for asset in self:
            //     res = self.env['account.asset.depreciation.line'].search_count([('asset_id', '=', asset.id), ('move_id', '!=', False)])
            //     asset.entry_count = res or 0
            */
            return default;
        }

        public async Task<TEntity> ExceptHashedEntryLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _except_hashed_entry_lines(self):
            // """ Lines belonginig to a hashed (locked) entry should not be allowed to be deleted in order to protect the
            // hash chain.
            // """
            // for line in self:
            //     if line.move_id.inalterable_hash:
            //         raise UserError(_('You cannot delete journal items belonging to a locked journal entry.'))
            */
            return default;
        }

        public async Task<TEntity> ExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _expected_date(self):
            // self.ensure_one()
            // if self.state == 'sale' and self.order_id.date_order:
            //     order_date = self.order_id.date_order
            // else:
            //     order_date = fields.Datetime.now()
            // return order_date + timedelta(days=self.customer_lead or 0.0)
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string fname, object query, bool flush) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _field_to_sql(self, alias: str, fname: str, query: (Query | None) = None, flush: bool = True) -> SQL:
            // if fname != 'payment_date':
            //     return super()._field_to_sql(alias, fname, query, flush)
            // return SQL("""
            //     CASE
            //          WHEN %(discount_date)s >= %(today)s THEN %(discount_date)s
            //          ELSE %(date_maturity)s
            //     END""",
            //     today=fields.Date.context_today(self),
            //     discount_date=super()._field_to_sql(alias, "discount_date", query, flush),
            //     date_maturity=super()._field_to_sql(alias, "date_maturity", query, flush),
            // )
            */
            return default;
        }

        public async Task<TEntity> FilterAmlLotValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _filter_aml_lot_valuation(self):
            // """ Method used to filter the aml taken into account when computing the invoiced lot value in get_invoiced_lot_values
            // Intended to be overriden in localization.
            // """
            // self.ensure_one()
            // return self.move_id.state == 'posted'
            */
            return default;
        }

        public async Task<TEntity> FilterReconciledByNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> mapping) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _filter_reconciled_by_number(self, mapping: dict):
            // """Get all the the lines matched with the lines in self.
            // 
            // Uses a mapping built with `_reconciled_by_number` to avoid multiple calls to the database.
            // """
            // matching_numbers = [n for n in set(self.mapped('matching_number')) if n]
            // return self | self.browse([_id for number in matching_numbers for _id in mapping[number].ids])
            */
            return default;
        }

        public async Task<TEntity> FilteredDomainAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def filtered_domain(self, domain):
            // # Filter based on the accounts used (i.e. allowing a name_search) instead of the distribution
            // # A domain on a binary field doesn't make sense anymore outside of set or not; and it is still doable.
            // return super(AnalyticMixin, self.with_context(distribution_ids=True)).filtered_domain(domain)
            */
            return default;
        }

        public async Task<TEntity> FlushModelAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def flush_model(self, fnames=None):
            // return super().flush_model(self._parse_flush_fnames(fnames))
            */
            return default;
        }

        public async Task<TEntity> FlushRecordsetAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def flush_recordset(self, fnames=None):
            // return super().flush_recordset(self._parse_flush_fnames(fnames))
            */
            return default;
        }

        public async Task<TEntity> FormatAmlNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_name, object move_ref, object move_name) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _format_aml_name(self, line_name, move_ref, move_name=None):
            // ''' Format the display of an account.move.line record. As its very costly to fetch the account.move.line
            // records, only line_name, move_ref, move_name are passed as parameters to deal with sql-queries more easily.
            // 
            // :param line_name:   The name of the account.move.line record.
            // :param move_ref:    The reference of the account.move record.
            // :param move_name:   The name of the account.move record.
            // :return:            The formatted name of the account.move.line record.
            // '''
            // names = []
            // if move_name and move_name != '/':
            //     names.append(move_name)
            // if move_ref and move_ref != '/':
            //     names.append(f"({move_ref})")
            // if line_name and line_name not in ['/', move_name, f"{move_ref} - {move_name}"]:
            //     names.append(line_name)
            // name = ' '.join(names)
            // return name or _('Draft Entry')
            */
            return default;
        }

        public async Task<TEntity> GetApplicableModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py) ---
            // def _get_applicable_models(self, vals):
            // vals = self._get_default_search_domain_vals() | vals
            // domain = []
            // for fname, value in vals.items():
            //     domain += self._create_domain(fname, value)
            // return self.search(domain)
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentDomainsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_attachment_domains(self):
            // self.ensure_one()
            // domains = [[
            //     ('res_model', '=', 'account.move'),
            //     ('res_id', '=', self.move_id.id),
            //     ('res_field', 'in', (False, 'invoice_pdf_report_file')),
            // ]]
            // if self.statement_id:
            //     domains.append([('res_model', '=', 'account.bank.statement'), ('res_id', '=', self.statement_id.id)])
            // if self.payment_id:
            //     domains.append([('res_model', '=', 'account.payment'), ('res_id', '=', self.payment_id.id)])
            // return domains
            */
            return default;
        }

        public async Task<TEntity> GetBaseAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_base_account(self):
            // """
            // Returns the expense account or forces default values if none was found
            // We need to do this as the installation process may delete the original account, and it doesn't recompute properly after
            // Returned expense accounts are the first expense account encountered in the following list:
            // 1. expense account of the expense itself
            // 2. expense account of the product
            // 3. expense account of the product category
            // 4. expense account on the purchase journal for employee expense
            // """
            // 
            // # expense account of the expense itself
            // account = self.account_id
            // 
            // if account:
            //     return account
            // 
            // # expense account of the product then the product category
            // if self.product_id:
            //     account = self.product_id.product_tmpl_id._get_product_accounts()['expense']
            // else:
            //     field = self.env['product.category']._fields['property_account_expense_categ_id']
            //     account = field.get_company_dependent_fallback(self.env['product.category'])
            // 
            // if account:
            //     return account
            // 
            // # expense account on the purchase journal for employee expense
            // journal = self.sheet_id.journal_id
            // if journal.type == 'purchase':
            //     account = journal.default_account_id
            // 
            // return account
            */
            return default;
        }

        public async Task<TEntity> GetCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_capacity(self, product):
            // product_capacity = self.capacity_ids.filtered(lambda capacity: capacity.product_id == product)
            // return product_capacity.capacity if product_capacity else self.default_capacity
            */
            return default;
        }

        public async Task<TEntity> GetComboItemDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_combo_item_display_price(self):
            // """ Compute the display price of this SOL's combo item.
            // 
            // A combo item's price is a fraction of its combo product's price (i.e. the product of type
            // `combo` which is referenced in this SOL's linked line). It is independent of the combo
            // item's product (i.e. the product referenced in this SOL). The combo's `base_price` will be
            // used to prorate the price of this combo with respect to the other combos in the combo
            // product.
            // 
            // Note: this method will throw if this SOL has no combo item or no linked combo product.
            // """
            // self.ensure_one()
            // 
            // # Compute the combo product's price.
            // combo_line = self._get_linked_line()
            // combo_product_price = combo_line._get_display_price_ignore_combo()
            // # Compute the combos' base prices.
            // combo_base_prices = {
            //     combo_id: combo_id.currency_id._convert(
            //         from_amount=combo_id.base_price,
            //         to_currency=self.currency_id,
            //         company=self.company_id,
            //         date=self.order_id.date_order,
            //     ) for combo_id in combo_line.product_template_id.combo_ids
            // }
            // total_combo_base_price = sum(combo_base_prices.values())
            // # Compute the prorated combo prices.
            // combo_prices = {
            //     combo_id: self.currency_id.round(
            //         # Don't divide by total_combo_base_price if it's 0. This will make the prorating
            //         # wrong, but the delta will be fixed by combo_price_delta below.
            //         base_price * combo_product_price / (total_combo_base_price or 1)
            //     )
            //     for (combo_id, base_price) in combo_base_prices.items()
            // }
            // # Compute the delta between the combo product's price and the sum of its combo prices.
            // # Ideally, this should be 0, but division in python isn't perfect, so we may need to adjust
            // # the combo prices to make the delta 0.
            // combo_price_delta = combo_product_price - sum(combo_prices.values())
            // if combo_price_delta:
            //     combo_prices[combo_line.product_template_id.combo_ids[-1]] += combo_price_delta
            // # Add the extra price of this combo item, as well as the extra prices of any `no_variant`
            // # attributes to the combo price.
            // return (
            //     combo_prices[self.combo_item_id.combo_id]
            //     + self.combo_item_id.extra_price
            //     + self.product_id._get_no_variant_attributes_price_extra(
            //         self.product_no_variant_attribute_value_ids
            //     )
            // )
            */
            return default;
        }

        public async Task<TEntity> GetComputedTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_computed_taxes(self):
            // self.ensure_one()
            // 
            // company_domain = self.env['account.tax']._check_company_domain(self.move_id.company_id)
            // if self.move_id.is_sale_document(include_receipts=True):
            //     # Out invoice.
            //     filtered_taxes_id = self.product_id.taxes_id.filtered_domain(company_domain)
            //     tax_ids = filtered_taxes_id or self.account_id.tax_ids.filtered(lambda tax: tax.type_tax_use == 'sale')
            // 
            // elif self.move_id.is_purchase_document(include_receipts=True):
            //     # In invoice.
            //     filtered_supplier_taxes_id = self.product_id.supplier_taxes_id.filtered_domain(company_domain)
            //     tax_ids = filtered_supplier_taxes_id or self.account_id.tax_ids.filtered(lambda tax: tax.type_tax_use == 'purchase')
            // 
            // else:
            //     tax_ids = False if self.env.context.get('skip_computed_taxes') else self.account_id.tax_ids
            // 
            // if self.company_id and tax_ids:
            //     tax_ids = tax_ids._filter_taxes_by_company(self.company_id)
            // 
            // if tax_ids and self.move_id.fiscal_position_id:
            //     tax_ids = self.move_id.fiscal_position_id.map_tax(tax_ids)
            // 
            // return tax_ids
            */
            return default;
        }

        public async Task<TEntity> GetCountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _get_count_id(self, query):
            // ids = {
            //     'account_move_line': "move_id",
            //     'purchase_order_line': "order_id",
            //     'account_asset': "id",
            //     'hr_expense': "id",
            // }
            // if query.table not in ids:
            //     raise ValueError(f"{query.table} does not support analytic_distribution grouping.")
            // return SQL(ids.get(query.table))
            */
            return default;
        }

        public async Task<TEntity> GetCustomComputeTaxCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_custom_compute_tax_cache_key(self):
            // """Hook method to be able to set/get cached taxes while computing them"""
            // return tuple()
            */
            return default;
        }

        public async Task<TEntity> GetDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object seller, object po) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_date_planned(self, seller, po=False):
            // """Return the datetime value to use as Schedule Date (``date_planned``) for
            //    PO Lines that correspond to the given product.seller_ids,
            //    when ordered at `date_order_str`.
            // 
            //    :param Model seller: used to fetch the delivery delay (if no seller
            //                         is provided, the delay is 0)
            //    :param Model po: purchase.order, necessary only if the PO line is
            //                     not yet attached to a PO.
            //    :rtype: datetime
            //    :return: desired Schedule Date for the PO line
            // """
            // date_order = po.date_order if po else self.order_id.date_order
            // if date_order:
            //     return date_order + relativedelta(days=seller.delay if seller else 0)
            // else:
            //     return datetime.today() + relativedelta(days=seller.delay if seller else 0)
            */
            return default;
        }

        public async Task<TEntity> GetDefaultExpenseSheetValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_default_expense_sheet_values(self):
            // # If there is an expense with total_amount == 0, it means that expense has not been processed by OCR yet
            // expenses_with_amount = self.filtered(lambda expense: not (
            //     expense.currency_id.is_zero(expense.total_amount_currency)
            //     or expense.company_currency_id.is_zero(expense.total_amount)
            //     or (expense.product_id and not float_round(expense.quantity, precision_rounding=expense.product_uom_id.rounding))
            // ))
            // 
            // if any(expense.state != 'draft' or expense.sheet_id for expense in expenses_with_amount):
            //     raise UserError(_("You cannot report twice the same line!"))
            // if not expenses_with_amount:
            //     raise UserError(_("You cannot report the expenses without amount!"))
            // if len(expenses_with_amount.mapped('employee_id')) != 1:
            //     raise UserError(_("You cannot report expenses for different employees in the same report."))
            // if any(not expense.product_id for expense in expenses_with_amount):
            //     raise UserError(_("You can not create report without category."))
            // if len(self.company_id) != 1:
            //     raise UserError(_("You cannot report expenses for different companies in the same report."))
            // 
            // # Check if two reports should be created
            // own_expenses = expenses_with_amount.filtered(lambda x: x.payment_mode == 'own_account')
            // company_expenses = expenses_with_amount - own_expenses
            // create_two_reports = own_expenses and company_expenses
            // 
            // sheets = (own_expenses, company_expenses) if create_two_reports else (expenses_with_amount,)
            // values = []
            // 
            // # We use a fallback name only when several expense sheets are created,
            // # else we use the form view required name to force the user to set a name
            // for todo in sheets:
            //     paid_by = 'company' if todo[0].payment_mode == 'company_account' else 'employee'
            //     sheet_name = self.env['hr.expense.sheet']._get_default_sheet_name(todo)
            //     if not sheet_name and len(sheets) > 1:
            //         sheet_name = _("New Expense Report, paid by %(paid_by)s", paid_by=paid_by)
            //     values.append({
            //         'company_id': self.company_id.id,
            //         'employee_id': self[0].employee_id.id,
            //         'name': sheet_name,
            //         'expense_line_ids': [Command.set(todo.ids)],
            //         'state': 'draft',
            //     })
            // return values
            */
            return default;
        }

        public async Task<TEntity> GetDefaultSearchDomainValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py) ---
            // def _get_default_search_domain_vals(self):
            // return {
            //     'company_id': False,
            //     'partner_id': False,
            //     'partner_category_id': [],
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeliveredQuantityByAnalyticInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_delivered_quantity_by_analytic(self, additional_domain):
            // """ Compute and write the delivered quantity of current SO lines, based on their related
            //     analytic lines.
            //     :param additional_domain: domain to restrict AAL to include in computation (required since timesheet is an AAL with a project ...)
            // """
            // result = defaultdict(float)
            // 
            // # avoid recomputation if no SO lines concerned
            // if not self:
            //     return result
            // 
            // # group analytic lines by product uom and so line
            // domain = expression.AND([[('so_line', 'in', self.ids)], additional_domain])
            // data = self.env['account.analytic.line']._read_group(
            //     domain,
            //     ['product_uom_id', 'so_line'],
            //     ['unit_amount:sum', 'move_line_id:count_distinct', '__count'],
            // )
            // 
            // # convert uom and sum all unit_amount of analytic lines to get the delivered qty of SO lines
            // for uom, so_line, unit_amount_sum, move_line_id_count_distinct, count in data:
            //     if not uom:
            //         continue
            //     # avoid counting unit_amount twice when dealing with multiple analytic lines on the same move line
            //     if move_line_id_count_distinct == 1 and count > 1:
            //         qty = unit_amount_sum / count
            //     else:
            //         qty = unit_amount_sum
            //     if so_line.product_uom.category_id == uom.category_id:
            //         qty = uom._compute_quantity(qty, so_line.product_uom, rounding_method='HALF-UP')
            //     result[so_line.id] += qty
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetDisplayPriceIgnoreComboInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_display_price_ignore_combo(self):
            // """ This helper method allows to compute the display price of a SOL, while ignoring combo
            // logic.
            // 
            // I.e. this method returns the display price of a SOL as if it were neither a combo line nor a
            // combo item line.
            // """
            // self.ensure_one()
            // 
            // pricelist_price = self._get_pricelist_price()
            // 
            // if not self.pricelist_item_id._show_discount():
            //     # No pricelist rule found => no discount from pricelist
            //     return pricelist_price
            // 
            // base_price = self._get_pricelist_price_before_discount()
            // 
            // # negative discounts (= surcharge) are included in the display price
            // return max(base_price, pricelist_price)
            */
            return default;
        }

        public async Task<TEntity> GetDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_display_price(self):
            // """Compute the displayed unit price for a given line.
            // 
            // Overridden in custom flows:
            // * where the price is not specified by the pricelist
            // * where the discount is not specified by the pricelist
            // 
            // Note: self.ensure_one()
            // """
            // self.ensure_one()
            // 
            // if self.product_type == 'combo':
            //     return 0  # The display price of a combo line should always be 0.
            // if self.combo_item_id:
            //     return self._get_combo_item_display_price()
            // return self._get_display_price_ignore_combo()
            */
            return default;
        }

        public async Task<TEntity> GetDisposalMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _get_disposal_moves(self):
            // move_ids = []
            // for asset in self:
            //     unposted_depreciation_line_ids = asset.depreciation_line_ids.filtered(lambda x: not x.move_check)
            //     if unposted_depreciation_line_ids:
            //         old_values = {
            //             'method_end': asset.method_end,
            //             'method_number': asset.method_number,
            //         }
            // 
            //         # Remove all unposted depr. lines
            //         commands = [(2, line_id.id, False) for line_id in unposted_depreciation_line_ids]
            // 
            //         # Create a new depr. line with the residual amount and post it
            //         sequence = len(asset.depreciation_line_ids) - len(unposted_depreciation_line_ids) + 1
            //         today = fields.Datetime.today()
            //         vals = {
            //             'amount': asset.value_residual,
            //             'asset_id': asset.id,
            //             'sequence': sequence,
            //             'name': (asset.code or '') + '/' + str(sequence),
            //             'remaining_value': 0,
            //             'depreciated_value': asset.value - asset.salvage_value,  # the asset is completely depreciated
            //             'depreciation_date': today,
            //         }
            //         commands.append((0, False, vals))
            //         asset.write({'depreciation_line_ids': commands, 'method_end': today, 'method_number': sequence})
            //         tracked_fields = self.env['account.asset.asset'].fields_get(['method_number', 'method_end'])
            //         changes, tracking_value_ids = asset._mail_track(tracked_fields, old_values)
            //         if changes:
            //             asset.message_post(subject=_('Asset sold or disposed. Accounting entry awaiting for validation.'), tracking_value_ids=tracking_value_ids)
            //         move_ids += asset.depreciation_line_ids[-1].create_move(post_move=False)
            // 
            // return move_ids
            */
            return default;
        }

        public async Task<TEntity> GetDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py) ---
            // def _get_distribution(self, vals):
            // """ Returns the combined distribution from all matching models based on the vals dict provided
            //     This method should be called to prefill analytic distribution field on several models """
            // applicable_models = self._get_applicable_models({k: v for k, v in vals.items() if k != 'related_root_plan_ids'})
            // 
            // res = {}
            // applied_plans = vals.get('related_root_plan_ids', self.env['account.analytic.plan'])
            // for model in applicable_models:
            //     # ignore model if it contains an account having a root plan that was already applied
            //     if not applied_plans & model.distribution_analytic_account_ids.root_plan_id:
            //         res |= model.analytic_distribution or {}
            //         applied_plans += model.distribution_analytic_account_ids.root_plan_id
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetDownpaymentDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_downpayment_description(self):
            // self.ensure_one()
            // if self.display_type:
            //     return _("Down Payments")
            // 
            // dp_state = self._get_downpayment_state()
            // name = _("Down Payment")
            // if dp_state == 'draft':
            //     name = _(
            //         "Down Payment: %(date)s (Draft)",
            //         date=format_date(self.env, self.create_date.date()),
            //     )
            // elif dp_state == 'cancel':
            //     name = _("Down Payment (Cancelled)")
            // else:
            //     invoice = self._get_invoice_lines().filtered(
            //         lambda aml: aml.quantity >= 0
            //     ).move_id.filtered(lambda move: move.move_type == 'out_invoice')
            //     if len(invoice) == 1 and invoice.payment_reference and invoice.invoice_date:
            //         name = _(
            //             "Down Payment (ref: %(reference)s on %(date)s)",
            //             reference=invoice.payment_reference,
            //             date=format_date(self.env, invoice.invoice_date),
            //         )
            // 
            // return name
            */
            return default;
        }

        public async Task<TEntity> GetDownpaymentLinePriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_downpayment_line_price_unit(self, invoices):
            // return sum(
            //     l.price_unit if l.move_id.move_type == 'out_invoice' else -l.price_unit
            //     for l in self.invoice_lines
            //     if l.move_id.state == 'posted' and l.move_id not in invoices  # don't recompute with the final invoice
            // )
            */
            return default;
        }

        public async Task<TEntity> GetDownpaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_downpayment_lines(self):
            // ''' Return the downpayment move lines associated with the move line.
            // This method is overridden in the sale order module.
            // '''
            // return self.env['account.move.line']
            */
            return default;
        }

        public async Task<TEntity> GetDownpaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_downpayment_state(self):
            // self.ensure_one()
            // 
            // if self.display_type:
            //     return ''
            // 
            // invoice_lines = self._get_invoice_lines()
            // if all(line.parent_state == 'draft' for line in invoice_lines):
            //     return 'draft'
            // if all(line.parent_state == 'cancel' for line in invoice_lines):
            //     return 'cancel'
            // 
            // return ''
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeFromEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_employee_from_email(self, email_address):
            // employee = self.env['hr.employee'].search([
            //     ('user_id', '!=', False),
            //     '|',
            //     ('work_email', 'ilike', email_address),
            //     ('user_id.email', 'ilike', email_address),
            // ])
            // 
            // if len(employee) > 1:
            //     # Several employees can be linked to the same user.
            //     # In that case, we only keep the employee that matched the user's company.
            //     return employee.filtered(lambda e: e.company_id == e.user_id.company_id)
            // 
            // if not employee:
            //     # An employee does not always have a user.
            //     return self.env['hr.employee'].search([
            //         ('user_id', '=', False),
            //         ('work_email', 'ilike', email_address),
            //     ], limit=1)
            // 
            // return employee
            */
            return default;
        }

        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_empty_list_help(self, help_message):
            // return super().get_empty_list_help((help_message or '') + self._get_empty_list_mail_alias())
            */
            return default;
        }

        public async Task<TEntity> GetEmptyListMailAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_empty_list_mail_alias(self):
            // use_mailgateway = self.env['ir.config_parameter'].sudo().get_param('hr_expense.use_mailgateway')
            // expense_alias = self.env.ref('hr_expense.mail_alias_expense', raise_if_not_found=False) if use_mailgateway else False
            // if expense_alias and expense_alias.alias_domain and expense_alias.alias_name:
            //     # encode, but force %20 encoding for space instead of a + (URL / mailto difference)
            //     params = werkzeug.urls.url_encode({'subject': _("Lunch with customer $12.32")}).replace('+', '%20')
            //     return Markup(
            //         """<div class="text-muted mt-4">%(send_string)s <a class="text-body" href="mailto:%(alias_email)s?%(params)s">%(alias_email)s</a></div>"""
            //     ) % {
            //         'alias_email': expense_alias.display_name,
            //         'params': params,
            //         'send_string': _("Tip: try sending receipts by email"),
            //     }
            // return ""
            */
            return default;
        }

        public async Task<TEntity> GetExchangeAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object amount) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_exchange_account(self, company, amount):
            // if amount > 0.0:
            //     return company.expense_currency_exchange_account_id
            // return company.income_currency_exchange_account_id
            */
            return default;
        }

        public async Task<TEntity> GetExchangeJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_exchange_journal(self, company):
            // return company.currency_exchange_journal_id
            */
            return default;
        }

        public async Task<TEntity> GetExpectedDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_expected_duration(self, product_id):
            // """Compute the expected duration when using this work-center
            // Always use the startup / clean-up time from specific capacity if defined.
            // """
            // capacity = self.capacity_ids.filtered(lambda p: p.product_id == product_id)
            // return capacity.time_start + capacity.time_stop if capacity else self.time_start + self.time_stop
            */
            return default;
        }

        public async Task<TEntity> GetExpenseAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_expense_attachments(self):
            // return self.attachment_ids.mapped('image_src')
            */
            return default;
        }

        public async Task<TEntity> GetExpenseDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_expense_dashboard(self):
            // expense_state = {
            //     'to_submit': {
            //         'description': _('to submit'),
            //         'amount': 0.0,
            //         'currency': self.env.company.currency_id.id,
            //     },
            //     'submitted': {
            //         'description': _('under validation'),
            //         'amount': 0.0,
            //         'currency': self.env.company.currency_id.id,
            //     },
            //     'approved': {
            //         'description': _('to be reimbursed'),
            //         'amount': 0.0,
            //         'currency': self.env.company.currency_id.id,
            //     }
            // }
            // if not self.env.user.employee_ids:
            //     return expense_state
            // target_currency = self.env.company.currency_id
            // # Counting the expenses to display in the dashboard:
            // # - To submit: contains the expenses paid either by the employee or by the company, and that are draft or reported
            // # - Under validation: contains expenses paid by the employee or paid by the company, and that have been submitted but still need to be approved/refused
            // # - To be reimbursed: contains ONLY expenses paid by the employee that are approved, the payment has not yet been made
            // expenses = self._read_group(
            //     [
            //         ('employee_id', 'in', self.env.user.employee_ids.ids),
            //         '|', '&', ('payment_mode', 'in', ('own_account', 'company_account')), ('state', 'in', ('draft', 'reported', 'submitted')),
            //              '&', ('payment_mode', '=', 'own_account'), ('state', '=', 'approved')
            //     ], ['state'], ['total_amount:sum'])
            // for state, total_amount_sum in expenses:
            //     if state in {'draft', 'reported'}:  # Fuse the two states into only one "To Submit" state
            //         state = 'to_submit'
            //     expense_state[state]['amount'] += total_amount_sum
            // return expense_state
            */
            return default;
        }

        public async Task<TEntity> GetExpensesToSubmitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_expenses_to_submit(self):
            // # if there ere no records selected, then select all draft expenses for the user
            // if self:
            //     expenses = self.filtered(lambda expense: expense.state == 'draft' and not expense.sheet_id and expense.is_editable)
            // else:
            //     expenses = self.env['hr.expense'].search([
            //         ('state', '=', 'draft'),
            //         ('sheet_id', '=', False),
            //         ('employee_id', '=', self.env.user.employee_id.id),
            //     ]).filtered(lambda expense: expense.is_editable)
            // 
            // if not expenses:
            //     raise UserError(_('You have no expense to report'))
            // return expenses.action_submit_expenses()
            */
            return default;
        }

        public async Task<TEntity> GetFirstAvailableSlotInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object duration, object forward, object leaves_to_ignore, object extra_leaves_slots) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_first_available_slot(self, start_datetime, duration, forward=True, leaves_to_ignore=False, extra_leaves_slots=[]):
            // """Get the first available interval for the workcenter in `self`.
            // 
            // The available interval is disjoinct with all other workorders planned on this workcenter, but
            // can overlap the time-off of the related calendar (inverse of the working hours).
            // Return the first available interval (start datetime, end datetime) or,
            // if there is none before 700 days, a tuple error (False, 'error message').
            // 
            // :param duration: minutes needed to make the workorder (float)
            // :param start_datetime: begin the search at this datetime
            // :param forward: forward scheduling (search from start_datetime to 700 days after), or backward (from start_datetime to now)
            // :param leaves_to_ignore: typically, ignore allocated leave when re-planning a workorder
            // :param extra_leaves_slots: extra time slots (start, stop) to consider
            // :rtype: tuple
            // """
            // self.ensure_one()
            // resource = self.resource_id
            // start_datetime, revert = make_aware(start_datetime)
            // get_available_intervals = partial(self.resource_calendar_id._work_intervals_batch, resources=resource, tz=timezone(self.resource_calendar_id.tz))
            // workorder_intervals_leaves_domain = [('time_type', '=', 'other')]
            // if leaves_to_ignore:
            //     workorder_intervals_leaves_domain.append(('id', 'not in', leaves_to_ignore.ids))
            // get_workorder_intervals = partial(self.resource_calendar_id._leave_intervals_batch, domain=workorder_intervals_leaves_domain, resources=resource, tz=timezone(self.resource_calendar_id.tz))
            // extra_leaves_slots_intervals = Intervals([(make_aware(start)[0], make_aware(stop)[0], self.env['resource.calendar.attendance']) for start, stop in extra_leaves_slots])
            // 
            // remaining = duration
            // now = make_aware(datetime.now())[0]
            // delta = timedelta(days=14)
            // start_interval, stop_interval = None, None
            // for n in range(50):  # 50 * 14 = 700 days in advance (hardcoded)
            //     if forward:
            //         date_start = start_datetime + delta * n
            //         date_stop = date_start + delta
            //         available_intervals = get_available_intervals(date_start, date_stop)[resource.id]
            //         workorder_intervals = get_workorder_intervals(date_start, date_stop)[resource.id]
            //         for start, stop, _records in available_intervals:
            //             start_interval = start_interval or start
            //             interval_minutes = (stop - start).total_seconds() / 60
            //             while (interval := Intervals([(start_interval or start, start + timedelta(minutes=min(remaining, interval_minutes)), _records)])) \
            //               and (conflict := interval & workorder_intervals or interval & extra_leaves_slots_intervals):
            //                 (_start, start, _records) = conflict._items[0]  # restart available interval at conflicting interval stop
            //                 interval_minutes = (stop - start).total_seconds() / 60
            //                 start_interval, remaining = start if interval_minutes else None, duration
            //             if float_compare(interval_minutes, remaining, precision_digits=3) >= 0:
            //                 return revert(start_interval), revert(start + timedelta(minutes=remaining))
            //             remaining -= interval_minutes
            //     else:
            //         # same process but starting from end on reversed intervals
            //         date_stop = start_datetime - delta * n
            //         date_start = date_stop - delta
            //         available_intervals = get_available_intervals(date_start, date_stop)[resource.id]
            //         available_intervals = reversed(available_intervals)
            //         workorder_intervals = get_workorder_intervals(date_start, date_stop)[resource.id]
            //         for start, stop, _records in available_intervals:
            //             stop_interval = stop_interval or stop
            //             interval_minutes = (stop - start).total_seconds() / 60
            //             while (interval := Intervals([(stop - timedelta(minutes=min(remaining, interval_minutes)), stop_interval or stop, _records)])) \
            //               and (conflict := interval & workorder_intervals or interval & extra_leaves_slots_intervals):
            //                 (stop, _stop, _records) = conflict._items[0]  # restart available interval at conflicting interval start
            //                 interval_minutes = (stop - start).total_seconds() / 60
            //                 stop_interval, remaining = stop if interval_minutes else None, duration
            //             if float_compare(interval_minutes, remaining, precision_digits=3) >= 0:
            //                 return revert(stop - timedelta(minutes=remaining)), revert(stop_interval)
            //             remaining -= interval_minutes
            //         if date_start <= now:
            //             break
            // return False, 'No available slot 700 days after the planned start'
            */
            return default;
        }

        public async Task<TEntity> GetGrossPriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_gross_price_unit(self):
            // self.ensure_one()
            // price_unit = self.price_unit
            // if self.discount:
            //     price_unit = price_unit * (1 - self.discount / 100)
            // if self.taxes_id:
            //     qty = self.product_qty or 1
            //     price_unit = self.taxes_id.compute_all(
            //         price_unit,
            //         currency=self.order_id.currency_id,
            //         quantity=qty,
            //         rounding_method='round_globally',
            //     )['total_void']
            //     price_unit = price_unit / qty
            // if self.product_uom.id != self.product_id.uom_id.id:
            //     price_unit *= self.product_uom.factor / self.product_id.uom_id.factor
            // return price_unit
            */
            return default;
        }

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Journal Items'),
            //     'template': '/account/static/xls/aml_import_template.xlsx'
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetInstallmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_currency, object payment_date, object next_payment_date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_installments_data(self, payment_currency=None, payment_date=None, next_payment_date=None):
            // move = self.move_id
            // move.ensure_one()
            // 
            // payment_date = payment_date or fields.Date.context_today(self)
            // 
            // term_lines = self.sorted(key=lambda line: (line.date_maturity, line.date))
            // sign = move.direction_sign
            // installments = []
            // first_installment_mode = False
            // current_installment_mode = False
            // for i, line in enumerate(term_lines, start=1):
            //     installment = {
            //         'number': i,
            //         'line': line,
            //         'date_maturity': line.date_maturity or line.date,
            //         'amount_residual_currency': line.amount_residual_currency,
            //         'amount_residual': line.amount_residual,
            //         'amount_residual_currency_unsigned': -sign * line.amount_residual_currency,
            //         'amount_residual_unsigned': -sign * line.amount_residual,
            //         'type': 'other',
            //         'reconciled': line.reconciled,
            //     }
            //     installments.append(installment)
            // 
            //     # Already reconciled.
            //     if line.reconciled:
            //         continue
            // 
            //     # Early payment discount.
            //     # In that case, we want to report the difference of the epd and display it on the UI.
            //     if move._is_eligible_for_early_payment_discount(payment_currency or line.currency_id, payment_date):
            //         installment.update({
            //             'amount_residual_currency': line.discount_amount_currency,
            //             'amount_residual': line.discount_balance,
            //             'amount_residual_currency_unsigned': -sign * line.discount_amount_currency,
            //             'amount_residual_unsigned': -sign * line.discount_balance,
            //             'discount_amount_currency': line.amount_currency - line.discount_amount_currency,
            //             'discount_amount': line.balance - line.discount_balance,
            //             'type': 'early_payment_discount',
            //         })
            //         continue
            // 
            //     # Installments.
            //     # In case of overdue, all of them are sum as a default amount to be paid.
            //     # The next installment is added for the difference.
            //     if line.display_type == 'payment_term':
            //         if next_payment_date and (line.date_maturity or line.date) <= next_payment_date:
            //             current_installment_mode = 'before_date'
            //         elif (line.date_maturity or line.date) < payment_date:
            //             # Collect all overdue installments.
            //             first_installment_mode = current_installment_mode = 'overdue'
            //         elif not first_installment_mode:
            //             # Suggest the next installment in case of no overdue.
            //             first_installment_mode = 'next'
            //             current_installment_mode = 'next'
            //         elif current_installment_mode == 'overdue':
            //             # After an overdue, just add the next installment for the difference.
            //             current_installment_mode = 'next'
            //         installment['type'] = current_installment_mode
            // 
            // return installments
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_integrity_hash_fields(self):
            // # Use the new hash version by default, but keep the old one for backward compatibility when generating the integrity report.
            // hash_version = self._context.get('hash_version', MAX_HASH_VERSION)
            // if hash_version == 1:
            //     return ['debit', 'credit', 'account_id', 'partner_id']
            // elif hash_version in (2, 3, 4):
            //     return ['name', 'debit', 'credit', 'account_id', 'partner_id']
            // raise NotImplementedError(f"hash_version={hash_version} doesn't exist")
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @new, object old) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_invoice_line_sequence(self, new=0, old=0):
            // """
            // Method intended to be overridden in third-party module if we want to prevent the resequencing
            // of invoice lines.
            // 
            // :param int new:   the new line sequence
            // :param int old:   the old line sequence
            // 
            // :return:          the sequence of the SO line, by default the new one.
            // """
            // return new or old
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_invoice_lines(self):
            // self.ensure_one()
            // if self._context.get('accrual_entry_date'):
            //     return self.invoice_lines.filtered(
            //         lambda l: l.move_id.invoice_date and l.move_id.invoice_date <= self._context['accrual_entry_date']
            //     )
            // else:
            //     return self.invoice_lines
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_invoice_lines(self):
            // self.ensure_one()
            // if self._context.get('accrual_entry_date'):
            //     return self.invoice_lines.filtered(
            //         lambda l: l.move_id.invoice_date and l.move_id.invoice_date <= self._context['accrual_entry_date']
            //     )
            // else:
            //     return self.invoice_lines
            */
            return default;
        }

        public async Task<TEntity> GetInvoicedQtyPerProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_invoiced_qty_per_product(self):
            // qties = defaultdict(float)
            // for aml in self:
            //     qty = aml.product_uom_id._compute_quantity(aml.quantity, aml.product_id.uom_id)
            //     if aml.move_id.move_type == 'out_invoice':
            //         qties[aml.product_id] += qty
            //     elif aml.move_id.move_type == 'out_refund':
            //         qties[aml.product_id] -= qty
            // return qties
            */
            return default;
        }

        public async Task<TEntity> GetJournalItemsFullNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object display_name) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_journal_items_full_name(self, name, display_name):
            // return name if not display_name or display_name in name else f"{display_name} {name}"
            */
            return default;
        }

        public async Task<TEntity> GetLinesWithPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_lines_with_price(self):
            // """ A combo product line always has a zero price (by design). The actual price of the combo
            // product can be computed by summing the prices of its combo items (i.e. its linked lines).
            // """
            // return self.linked_line_ids if self.product_type == 'combo' else self
            */
            return default;
        }

        public async Task<TEntity> GetLinkedLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_linked_line(self):
            // """ Return the linked line of this line, if any.
            // 
            // This method relies on either `linked_line_id` or `linked_virtual_id` to retrieve the linked
            // line, depending on whether the linked line is saved in the DB.
            // """
            // self.ensure_one()
            // return self.linked_line_id or (
            //     self.linked_virtual_id and self.order_id.order_line.filtered(
            //         lambda line: line.virtual_id == self.linked_virtual_id
            //     ).ensure_one()
            // ) or self.env['sale.order.line']
            */
            return default;
        }

        public async Task<TEntity> GetLinkedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_linked_lines(self):
            // """ Return the linked lines of this line, if any.
            // 
            // This method relies on either `linked_line_id` or `linked_virtual_id` to retrieve the linked
            // lines, depending on whether this line is saved in the DB.
            // 
            // Note: we can't rely on `linked_line_ids` as it will only be populated when both this line
            // and its linked lines are saved in the DB, which we can't ensure.
            // """
            // self.ensure_one()
            // return (
            //     self._origin and self.order_id.order_line.filtered(
            //         lambda line: line.linked_line_id._origin == self._origin
            //     )
            // ) or (
            //     self.virtual_id and self.order_id.order_line.filtered(
            //         lambda line: line.linked_virtual_id == self.virtual_id
            //     )
            // ) or self.env['sale.order.line']
            */
            return default;
        }

        public async Task<TEntity> GetLockDateProtectedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_lock_date_protected_fields(self):
            // """ Returns the names of the fields that should be protected by the accounting fiscal year and tax lock dates
            // """
            // tax_fnames = ['balance', 'tax_line_id', 'tax_ids', 'tax_tag_ids']
            // fiscal_fnames = tax_fnames + ['account_id', 'journal_id', 'amount_currency', 'currency_id', 'partner_id']
            // reconciliation_fnames = ['account_id', 'date', 'balance', 'amount_currency', 'currency_id']
            // return {
            //     'tax': tax_fnames,
            //     'fiscal': fiscal_fnames,
            //     'reconciliation': reconciliation_fnames,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMoveLineNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_move_line_name(self):
            // """ Helper to get the name of the account move lines related to an expense """
            // self.ensure_one()
            // expense_name = self.name.split("\n")[0][:64]
            // return _('%(employee_name)s: %(expense_name)s', employee_name=self.employee_id.name, expense_name=expense_name)
            */
            return default;
        }

        public async Task<TEntity> GetOrderDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_order_date(self):
            // self.ensure_one()
            // return self.order_id.date_order
            */
            return default;
        }

        public async Task<TEntity> GetPartnerDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_partner_display(self):
            // self.ensure_one()
            // commercial_partner = self.sudo().order_partner_id.commercial_partner_id
            // return f'({commercial_partner.ref or commercial_partner.name})'
            */
            return default;
        }

        public async Task<TEntity> GetPricelistPriceBeforeDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_pricelist_price_before_discount(self):
            // """Compute the price used as base for the pricelist price computation.
            // 
            // :return: the product sales price in the order currency (without taxes)
            // :rtype: float
            // """
            // self.ensure_one()
            // self.product_id.ensure_one()
            // 
            // return self.pricelist_item_id._compute_price_before_discount(
            //     product=self.product_id.with_context(**self._get_product_price_context()),
            //     quantity=self.product_uom_qty or 1.0,
            //     uom=self.product_uom,
            //     date=self._get_order_date(),
            //     currency=self.currency_id,
            // )
            */
            return default;
        }

        public async Task<TEntity> GetPricelistPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_pricelist_price_context(self):
            // """DO NOT USE in new code, this contextual logic should be dropped or heavily refactored soon"""
            // self.ensure_one()
            // return {
            //     'pricelist': self.order_id.pricelist_id.id,
            //     'uom': self.product_uom.id,
            //     'quantity': self.product_uom_qty,
            //     'date': self._get_order_date(),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPricelistPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_pricelist_price(self):
            // """Compute the price given by the pricelist for the given line information.
            // 
            // :return: the product sales price in the order currency (without taxes)
            // :rtype: float
            // """
            // self.ensure_one()
            // self.product_id.ensure_one()
            // 
            // price = self.pricelist_item_id._compute_price(
            //     product=self.product_id.with_context(**self._get_product_price_context()),
            //     quantity=self.product_uom_qty or 1.0,
            //     uom=self.product_uom,
            //     date=self._get_order_date(),
            //     currency=self.currency_id,
            // )
            // 
            // return price
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogLinesDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_product_catalog_lines_data(self, **kwargs):
            // """
            // Return information about account_move_line in `self`.
            // If `self` is empty, this method returns only the default value(s) needed for the product
            // catalog. In this case, the quantity that equals 0.
            // Otherwise, it returns a quantity and a price based on the product of the move line(s) and whether
            // the product is read-only or not.
            // A product is considered read-only if the order is considered read-only or if `self` contains multiple records.
            // Note: This method cannot be called with multiple records that have different products linked.
            // 
            // :param products: Recordset of `product.product`.
            // :param dict kwargs: additional values given for inherited models.
            // :rtype: dict
            // :return: A dict with the following structure:
            //     {
            //         'quantity': float,
            //         'price': float,
            //         'readOnly': bool,
            //         'min_qty': int, (optional)
            //     }
            // """
            // if self:
            //     self.product_id.ensure_one()
            //     return {
            //         **self[0].move_id._get_product_price_and_data(self[0].product_id),
            //         'quantity': sum(
            //             self.mapped(
            //                 lambda line: line.product_uom_id._compute_quantity(
            //                     qty=line.quantity,
            //                     to_unit=line.product_id.uom_id,
            //                 )
            //             )
            //         ),
            //         'readOnly': self.move_id._is_readonly() or len(self) > 1,
            //     }
            // return {
            //     'quantity': 0,
            // }
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_product_catalog_lines_data(self, **kwargs):
            // """ Return information about purchase order lines in `self`.
            // 
            // If `self` is empty, this method returns only the default value(s) needed for the product
            // catalog. In this case, the quantity that equals 0.
            // 
            // Otherwise, it returns a quantity and a price based on the product of the POL(s) and whether
            // the product is read-only or not.
            // 
            // A product is considered read-only if the order is considered read-only (see
            // ``PurchaseOrder._is_readonly`` for more details) or if `self` contains multiple records
            // or if it has purchase_line_warn == "block".
            // 
            // Note: This method cannot be called with multiple records that have different products linked.
            // 
            // :raise odoo.exceptions.ValueError: ``len(self.product_id) != 1``
            // :rtype: dict
            // :return: A dict with the following structure:
            //     {
            //         'quantity': float,
            //         'price': float,
            //         'readOnly': bool,
            //         'uom': dict,
            //         'purchase_uom': dict,
            //         'packaging': dict,
            //         'warning': String,
            //     }
            // """
            // if len(self) == 1:
            //     catalog_info = self.order_id._get_product_price_and_data(self.product_id)
            //     uom = {
            //         'display_name': self.product_id.uom_id.display_name,
            //         'id': self.product_id.uom_id.id,
            //     }
            //     catalog_info.update(
            //         quantity=self.product_qty,
            //         price=self.price_unit * (1 - self.discount / 100),
            //         readOnly=self.order_id._is_readonly(),
            //         uom=uom,
            //     )
            //     if self.product_id.uom_id != self.product_uom:
            //         catalog_info['purchase_uom'] = {
            //         'display_name': self.product_uom.display_name,
            //         'id': self.product_uom.id,
            //     }
            //     if self.product_packaging_id:
            //         packaging = self.product_packaging_id
            //         catalog_info['packaging'] = {
            //             'id': packaging.id,
            //             'name': packaging.display_name,
            //             'qty': packaging.product_uom_id._compute_quantity(packaging.qty, self.product_uom),
            //         }
            //     return catalog_info
            // elif self:
            //     self.product_id.ensure_one()
            //     order_line = self[0]
            //     catalog_info = order_line.order_id._get_product_price_and_data(order_line.product_id)
            //     catalog_info['quantity'] = sum(self.mapped(
            //         lambda line: line.product_uom._compute_quantity(
            //             qty=line.product_qty,
            //             to_unit=line.product_id.uom_id,
            //     )))
            //     catalog_info['readOnly'] = True
            //     return catalog_info
            // return {'quantity': 0}
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_product_catalog_lines_data(self, **kwargs):
            // """ Return information about sale order lines in `self`.
            // 
            // If `self` is empty, this method returns only the default value(s) needed for the product
            // catalog. In this case, the quantity that equals 0.
            // 
            // Otherwise, it returns a quantity and a price based on the product of the SOL(s) and whether
            // the product is read-only or not.
            // 
            // A product is considered read-only if the order is considered read-only (see
            // ``SaleOrder._is_readonly`` for more details) or if `self` contains multiple records
            // or if it has sale_line_warn == "block".
            // 
            // Note: This method cannot be called with multiple records that have different products linked.
            // 
            // :raise odoo.exceptions.ValueError: ``len(self.product_id) != 1``
            // :rtype: dict
            // :return: A dict with the following structure:
            //     {
            //         'quantity': float,
            //         'price': float,
            //         'readOnly': bool,
            //         'warning': String
            //     }
            // """
            // if len(self) == 1:
            //     res = {
            //         'quantity': self.product_uom_qty,
            //         'price': self.price_unit,
            //         'readOnly': (
            //             self.order_id._is_readonly()
            //             or self.product_id.sale_line_warn == 'block'
            //             or bool(self.combo_item_id)
            //         ),
            //     }
            //     if self.product_id.sale_line_warn != 'no-message' and self.product_id.sale_line_warn_msg:
            //         res['warning'] = self.product_id.sale_line_warn_msg
            //     return res
            // elif self:
            //     self.product_id.ensure_one()
            //     order_line = self[0]
            //     order = order_line.order_id
            //     res = {
            //         'readOnly': True,
            //         'price': order.pricelist_id._get_product_price(
            //             product=order_line.product_id,
            //             quantity=1.0,
            //             currency=order.currency_id,
            //             date=order.date_order,
            //             **kwargs,
            //         ),
            //         'quantity': sum(
            //             self.mapped(
            //                 lambda line: line.product_uom._compute_quantity(
            //                     qty=line.product_uom_qty,
            //                     to_unit=line.product_id.uom_id,
            //                 )
            //             )
            //         )
            //     }
            //     if self.product_id.sale_line_warn != 'no-message' and self.product_id.sale_line_warn_msg:
            //         res['warning'] = self.product_id.sale_line_warn_msg
            //     return res
            // else:
            //     return {
            //         'quantity': 0,
            //         # price will be computed in batch with pricelist utils so not given here
            //     }
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_product_price_context(self):
            // """Gives the context for product price computation.
            // 
            // :return: additional context to consider extra prices from attributes in the base product price.
            // :rtype: dict
            // """
            // self.ensure_one()
            // return self.product_id._get_product_price_context(
            //     self.product_no_variant_attribute_value_ids,
            // )
            */
            return default;
        }

        public async Task<TEntity> GetProductPurchaseDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_lang) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_product_purchase_description(self, product_lang):
            // self.ensure_one()
            // name = product_lang.display_name
            // if product_lang.description_purchase:
            //     name += '\n' + product_lang.description_purchase
            // 
            // return name
            */
            return default;
        }

        public async Task<TEntity> GetProtectedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_protected_fields(self):
            // """ Give the fields that should not be modified on a locked SO.
            // 
            // :returns: list of field names
            // :rtype: list
            // """
            // return [
            //     'product_id', 'name', 'price_unit', 'product_uom', 'product_uom_qty',
            //     'tax_id', 'analytic_distribution'
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetRateDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_rate_date(self):
            // self.ensure_one()
            // return self.move_id.invoice_date or self.move_id.date or fields.Date.context_today(self)
            */
            return default;
        }

        public async Task<TEntity> GetReconciliationAmlFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_reconciliation_aml_field_value(self, field, shadowed_aml_values):
            // self.ensure_one()
            // if shadowed_aml_values and field in shadowed_aml_values.get(self, {}):
            //     return shadowed_aml_values[self][field]
            // else:
            //     return self[field]
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderLineMultilineDescriptionSaleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_sale_order_line_multiline_description_sale(self):
            // """ Compute a default multiline description for this sales order line.
            // 
            // In most cases the product description is enough but sometimes we need to append information that only
            // exists on the sale order line itself.
            // e.g:
            // - custom attributes and attributes that don't create variants, both introduced by the "product configurator"
            // - in event_sale we need to know specifically the sales order line as well as the product to generate the name:
            //   the product is not sufficient because we also need to know the event_id and the event_ticket_id (both which belong to the sale order line).
            // """
            // self.ensure_one()
            // description = (
            //     self.product_id.get_product_multiline_description_sale()
            //     + self._get_sale_order_line_multiline_description_variants()
            // )
            // if self.linked_line_id and not self.combo_item_id:
            //     description += "\n" + _("Option for: %s", self.linked_line_id.product_id.display_name)
            // if self.linked_line_ids and self.product_type != 'combo':
            //     description += "\n" + "\n".join([
            //         _("Option: %s", linked_line.product_id.display_name)
            //         for linked_line in self.linked_line_ids
            //     ])
            // return description
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderLineMultilineDescriptionVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_sale_order_line_multiline_description_variants(self):
            // """When using no_variant attributes or is_custom values, the product
            // itself is not sufficient to create the description: we need to add
            // information about those special attributes and values.
            // 
            // :return: the description related to special variant attributes/values
            // :rtype: string
            // """
            // no_variant_ptavs = self.product_no_variant_attribute_value_ids._origin.filtered(
            //     # Only describe the attributes where a choice was made by the customer
            //     lambda ptav: ptav.display_type == 'multi' or ptav.attribute_line_id.value_count > 1
            // )
            // if not self.product_custom_attribute_value_ids and not no_variant_ptavs:
            //     return ""
            // 
            // name = "\n"
            // 
            // custom_ptavs = self.product_custom_attribute_value_ids.custom_product_template_attribute_value_id
            // multi_ptavs = no_variant_ptavs.filtered(lambda ptav: ptav.display_type == 'multi').sorted()
            // 
            // # display the no_variant attributes, except those that are also
            // # displayed by a custom (avoid duplicate description)
            // for ptav in (no_variant_ptavs - multi_ptavs - custom_ptavs):
            //     name += "\n" + ptav.display_name
            // 
            // # display the selected values per attribute on a single for a multi checkbox
            // for pta, ptavs in groupby(multi_ptavs, lambda ptav: ptav.attribute_id):
            //     name += "\n" + _(
            //         "%(attribute)s: %(values)s",
            //         attribute=pta.name,
            //         values=", ".join(ptav.name for ptav in ptavs)
            //     )
            // 
            // # Sort the values according to _order settings, because it doesn't work for virtual records in onchange
            // sorted_custom_ptav = self.product_custom_attribute_value_ids.custom_product_template_attribute_value_id.sorted()
            // for patv in sorted_custom_ptav:
            //     pacv = self.product_custom_attribute_value_ids.filtered(lambda pcav: pcav.custom_product_template_attribute_value_id == patv)
            //     name += "\n" + pacv.display_name
            // 
            // return name
            */
            return default;
        }

        public async Task<TEntity> GetSelectSellersParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _get_select_sellers_params(self):
            // self.ensure_one()
            // return {
            //     "order_id": self.order_id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetSplitValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_split_values(self):
            // self.ensure_one()
            // half_price = self.total_amount_currency / 2
            // price_round_up = float_round(half_price, precision_digits=self.currency_id.decimal_places, rounding_method='UP')
            // price_round_down = float_round(half_price, precision_digits=self.currency_id.decimal_places, rounding_method='DOWN')
            // 
            // return [{
            //     'name': self.name,
            //     'product_id': self.product_id.id,
            //     'total_amount_currency': price,
            //     'tax_ids': self.tax_ids.ids,
            //     'currency_id': self.currency_id.id,
            //     'company_id': self.company_id.id,
            //     'analytic_distribution': self.analytic_distribution,
            //     'employee_id': self.employee_id.id,
            //     'expense_id': self.id,
            // } for price in (price_round_up, price_round_down)]
            */
            return default;
        }

        public async Task<TEntity> GetTaxExigibleDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_tax_exigible_domain(self):
            // """ Returns a domain to be used to identify the move lines that are allowed
            // to be taken into account in the tax report.
            // """
            // return [
            //     # Lines on moves without any payable or receivable line are always exigible
            //     '|', ('move_id.always_tax_exigible', '=', True),
            // 
            //     # Lines with only tags are always exigible
            //     '|', '&', ('tax_line_id', '=', False), ('tax_ids', '=', False),
            // 
            //     # Lines from CABA entries are always exigible
            //     '|', ('move_id.tax_cash_basis_rec_id', '!=', False),
            // 
            //     # Lines from non-CABA taxes are always exigible
            //     '|', ('tax_line_id.tax_exigibility', '!=', 'on_payment'),
            //     ('tax_ids.tax_exigibility', '!=', 'on_payment'), # So: exigible if at least one tax from tax_ids isn't on_payment
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetUnavailabilityIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object end_datetime) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_unavailability_intervals(self, start_datetime, end_datetime):
            // """Get the unavailabilities intervals for the workcenters in `self`.
            // 
            // Return the list of unavailabilities (a tuple of datetimes) indexed
            // by workcenter id.
            // 
            // :param start_datetime: filter unavailability with only slots after this start_datetime
            // :param end_datetime: filter unavailability with only slots before this end_datetime
            // :rtype: dict
            // """
            // unavailability_ressources = self.resource_id._get_unavailable_intervals(start_datetime, end_datetime)
            // return {wc.id: unavailability_ressources.get(wc.resource_id.id, []) for wc in self}
            */
            return default;
        }

        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_views(self, views, options=None):
            // res = super().get_views(views, options)
            // if res['views'].get('list') and self.env['ir.ui.view'].sudo().browse(res['views']['list']['id']).name == "account.move.line.payment.list":
            //     if toolbar := res['views']['list'].get('toolbar'):
            //         # We dont want any additionnal action in the "account.move.line.payment.list" view toolbar
            //         toolbar['action'] = []
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetWeekRangeAndFirstLastDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_week_range_and_first_last_days(self):
            // """ We calculate the delta between today and the previous monday,
            // then add it to the delta between monday and the previous first day
            // of the week as configured in the language settings.
            // We use the result to calculate the modulo of 7 to make sure that
            // we do not take the previous first day of the week from 2 weeks ago.
            // 
            // E.g. today is Thursday, the first of a week is a Tuesday.
            // The delta between today and Monday is 3 days.
            // The delta between Monday and the previous Tuesday is 6 days.
            // (3 + 6) % 7 = 2, so from today, the first day of the current week is 2 days ago.
            // """
            // week_range = {}
            // locale = get_lang(self.env).code
            // today = datetime.today()
            // delta_from_monday_to_today = (today - start_of(today, 'week')).days
            // first_week_day = int(get_lang(self.env).week_start) - 1
            // day_offset = ((7 - first_week_day) + delta_from_monday_to_today) % 7
            // 
            // for delta in range(-7, 28, 7):
            //     week_start = start_of(today + relativedelta.relativedelta(days=delta - day_offset), 'day')
            //     week_end = week_start + relativedelta.relativedelta(days=6)
            //     short_name = (format_date(week_start, 'd - ', locale=locale)
            //                   + format_date(week_end, 'd MMM', locale=locale))
            //     if not delta:
            //         short_name = _('This Week')
            //     week_range[week_start] = short_name
            // date_start = start_of(today + relativedelta.relativedelta(days=-7 - day_offset), 'day')
            // date_stop = end_of(today + relativedelta.relativedelta(days=27 - day_offset), 'day')
            // return week_range, date_start, date_stop
            */
            return default;
        }

        public async Task<TEntity> GetWorkcenterLoadPerWeekInternalAsync<TEntity>(IEnumerable<TEntity> entities, object week_range, object date_start, object date_stop) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_workcenter_load_per_week(self, week_range, date_start, date_stop):
            // load_data = {rec: {} for rec in self}
            // # demo data
            // if not self.order_ids:
            //     for wc in self:
            //         load_limit = 40     # default max load per week is 40 hours on a new workcenter
            //         load_data[wc] = {week_start: randint(0, int(load_limit * 2)) for week_start in week_range}
            //     return load_data
            // 
            // result = self.env['mrp.workorder']._read_group(
            //     [('workcenter_id', 'in', self.ids), ('state', 'in', ('pending', 'waiting', 'ready', 'progress')),
            //      ('production_date', '>=', date_start), ('production_date', '<=', date_stop)],
            //     ['workcenter_id', 'production_date:week'], ['duration_expected:sum'])
            // for r in result:
            //     load_in_hours = round(r[2] / 60, 1)
            //     load_data[r[0]].update({r[1]: load_in_hours})
            // return load_data
            */
            return default;
        }

        public async Task<TEntity> HasValuedMoveIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def has_valued_move_ids(self):
            // return self.move_ids
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def init(self):
            // """ change index on partner_id to a multi-column index on (partner_id, ref), the new index will behave in the
            //     same way when we search on partner_id, with the addition of being optimal when having a query that will
            //     search on partner_id and ref at the same time (which is the case when we open the bank reconciliation widget)
            // """
            // create_index(self._cr, 'account_move_line_partner_id_ref_idx', 'account_move_line', ["partner_id", "ref"])
            // create_index(self._cr, 'account_move_line_date_name_id_idx', 'account_move_line', ["date desc", "move_name desc", "id"])
            // # Match exactly how the ORM converts domains to ensure the query planner uses it
            // create_index(self._cr, 'account_move_line__unreconciled_index', 'account_move_line', ['account_id', 'partner_id'],
            //              where="(reconciled IS NULL OR reconciled = false OR reconciled IS NOT true) AND parent_state = 'posted'")
            // create_index(self.env.cr,
            //              indexname='account_move_line_journal_id_neg_amnt_residual_idx',
            //              tablename='account_move_line',
            //              expressions=['journal_id'],
            //              where="amount_residual < 0 AND parent_state = 'posted'")
            // # covers the standard index on account_id
            // create_index(self.env.cr,
            //              indexname='account_move_line_account_id_date_idx',
            //              tablename='account_move_line',
            //              expressions=['account_id', 'date'])
            // super().init()
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def init(self):
            // # Add a gin index for json search on the keys, on the models that actually have a table
            // query = ''' SELECT table_name
            //             FROM information_schema.tables
            //             WHERE table_name=%s '''
            // self.env.cr.execute(query, [self._table])
            // if self.env.cr.dictfetchone() and self._fields['analytic_distribution'].store:
            //     query = fr"""
            //         CREATE INDEX IF NOT EXISTS {self._table}_analytic_distribution_accounts_gin_index
            //                                 ON {self._table} USING gin(regexp_split_to_array(jsonb_path_query_array(analytic_distribution, '$.keyvalue()."key"')::text, '\D+'));
            //     """
            //     self.env.cr.execute(query)
            // super().init()
            */
            return default;
        }

        public async Task<TEntity> InvalidateModelAsync<TEntity>(IEnumerable<TEntity> entities, object fnames, object flush) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def invalidate_model(self, fnames=None, flush=True):
            // # Invalidate cache of related moves
            // if fnames is None or 'move_id' in fnames:
            //     field = self._fields['move_id']
            //     lines = self.env.cache.get_records(self, field)
            //     move_ids = {id_ for id_ in self.env.cache.get_values(lines, field) if id_}
            //     if move_ids:
            //         self.env['account.move'].browse(move_ids).invalidate_recordset()
            // return super().invalidate_model(fnames, flush)
            */
            return default;
        }

        public async Task<TEntity> InvalidateRecordsetAsync<TEntity>(IEnumerable<TEntity> entities, object fnames, object flush) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def invalidate_recordset(self, fnames=None, flush=True):
            // # Invalidate cache of related moves
            // if fnames is None or 'move_id' in fnames:
            //     field = self._fields['move_id']
            //     move_ids = {id_ for id_ in self.env.cache.get_values(self, field) if id_}
            //     if move_ids:
            //         self.env['account.move'].browse(move_ids).invalidate_recordset()
            // return super().invalidate_recordset(fnames, flush)
            */
            return default;
        }

        public async Task<TEntity> InverseAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_account_id(self):
            // self._inverse_analytic_distribution()
            // self._conditional_add_to_compute('tax_ids', lambda line: (
            //     line.account_id.tax_ids
            //     and not line.product_id.taxes_id.filtered(lambda tax: tax.company_id == line.company_id)
            // ))
            */
            return default;
        }

        public async Task<TEntity> InverseAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_amount_currency(self):
            // for line in self:
            //     if line.currency_id == line.company_id.currency_id and line.balance != line.amount_currency:
            //         line.balance = line.amount_currency
            //     elif (
            //         line.currency_id != line.company_id.currency_id
            //         and not line.move_id.is_invoice(True)
            //         and not self.env.is_protected(self._fields['balance'], line)
            //     ):
            //         line.balance = line.company_id.currency_id.round(line.amount_currency / line.currency_rate)
            */
            return default;
        }

        public async Task<TEntity> InverseAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_analytic_distribution(self):
            // """ Unlink and recreate analytic_lines when modifying the distribution."""
            // if self.env.context.get('skip_analytic_sync'):
            //     return
            // lines_to_modify = self.env['account.move.line'].browse([
            //     line.id for line in self if line.parent_state == "posted"
            // ]).with_context(skip_analytic_sync=True)
            // lines_to_modify.analytic_line_ids.unlink()
            // lines_to_modify._create_analytic_lines()
            */
            return default;
        }

        public async Task<TEntity> InverseCreditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_credit(self):
            // for line in self:
            //     if line.credit:
            //         line.debit = 0
            //     line.balance = line.debit - line.credit
            */
            return default;
        }

        public async Task<TEntity> InverseDebitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_debit(self):
            // for line in self:
            //     if line.debit:
            //         line.credit = 0
            //     line.balance = line.debit - line.credit
            */
            return default;
        }

        public async Task<TEntity> InversePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_partner_id(self):
            // self._conditional_add_to_compute('account_id', lambda line: (
            //     line.display_type == 'payment_term'  # recompute based on settings
            // ))
            */
            return default;
        }

        public async Task<TEntity> InverseProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_product_id(self):
            // if self.product_id or not self.account_id:
            //     self._conditional_add_to_compute('account_id', lambda line: (
            //         line.display_type == 'product' and line.move_id.is_invoice(True)
            //     ))
            */
            return default;
        }

        public async Task<TEntity> InverseQtyReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _inverse_qty_received(self):
            // """ When writing on qty_received, if the value should be modify manually (`qty_received_method` = 'manual' only),
            //     then we put the value in `qty_received_manual`. Otherwise, `qty_received_manual` should be False since the
            //     received qty is automatically compute by other mecanisms.
            // """
            // for line in self:
            //     if line.qty_received_method == 'manual':
            //         line.qty_received_manual = line.qty_received
            //     else:
            //         line.qty_received_manual = 0.0
            */
            return default;
        }

        public async Task<TEntity> InverseTotalAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _inverse_total_amount_currency(self):
            // for expense in self:
            //     if not expense.is_editable:
            //         raise UserError(_('You are not authorized to edit this expense.'))
            //     expense.price_unit = (expense.total_amount / expense.quantity) if expense.quantity != 0 else 0.
            */
            return default;
        }

        public async Task<TEntity> InverseTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _inverse_total_amount(self):
            // """ Allows to set a custom rate on the expense, and avoid the override when it makes no sense """
            // AccountTax = self.env['account.tax']
            // for expense in self:
            //     if expense.is_multiple_currency:
            //         base_line = expense._prepare_base_line_for_taxes_computation(
            //             price_unit=expense.total_amount,
            //             quantity=1.0,
            //             currency=expense.company_currency_id,
            //         )
            //         AccountTax._add_tax_details_in_base_line(base_line, expense.company_id)
            //         AccountTax._round_base_lines_tax_details([base_line], expense.company_id)
            //         tax_details = base_line['tax_details']
            //         expense.tax_amount = tax_details['total_included_currency'] - tax_details['total_excluded_currency']
            //     else:
            //         expense.total_amount_currency = expense.total_amount
            //         expense.tax_amount = expense.tax_amount_currency
            //     expense.currency_rate = expense.total_amount / expense.total_amount_currency if expense.total_amount_currency else 1.0
            //     expense.price_unit = expense.total_amount / expense.quantity if expense.quantity else expense.total_amount
            */
            return default;
        }

        public async Task<TEntity> IsDeliveryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _is_delivery(self):
            // self.ensure_one()
            // return False
            */
            return default;
        }

        public async Task<TEntity> IsNotSellableLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _is_not_sellable_line(self):
            // # True if the line is a computed line (reward, delivery, ...) that user cannot add manually
            // return False
            */
            return default;
        }

        public async Task<TEntity> MappedAsync<TEntity>(IEnumerable<TEntity> entities, object func) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def mapped(self, func):
            // # Get the related analytic accounts as a recordset instead of the distribution
            // if func == 'analytic_distribution' and self.env.context.get('distribution_ids'):
            //     return self.distribution_analytic_account_ids
            // return super().mapped(func)
            */
            return default;
        }

        public async Task<TEntity> MergePoLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfq_line) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _merge_po_line(self, rfq_line):
            // self.product_qty += rfq_line.product_qty
            // self.price_unit = min(self.price_unit, rfq_line.price_unit)
            */
            return default;
        }

        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // email_address = email_split(msg_dict.get('email_from', False))[0]
            // employee = self._get_employee_from_email(email_address)
            // 
            // if not employee:
            //     return super().message_new(msg_dict, custom_values=custom_values)
            // 
            // expense_description = msg_dict.get('subject', '')
            // 
            // if employee.user_id:
            //     company = employee.user_id.company_id
            //     currencies = company.currency_id | employee.user_id.company_ids.mapped('currency_id')
            // else:
            //     company = employee.company_id
            //     currencies = company.currency_id
            // 
            // if not company:  # ultimate fallback, since company_id is required on expense
            //     company = self.env.company
            // 
            // # The expenses alias is the same for all companies, we need to set the proper context
            // # To select the product account
            // self = self.with_company(company)
            // 
            // product, price, currency_id, expense_description = self._parse_expense_subject(expense_description, currencies)
            // vals = {
            //     'employee_id': employee.id,
            //     'name': expense_description,
            //     'total_amount_currency': price,
            //     'product_id': product.id if product else None,
            //     'product_uom_id': product.uom_id.id,
            //     'tax_ids': [Command.set(product.supplier_taxes_id.filtered(lambda r: r.company_id == company).ids)],
            //     'quantity': 1,
            //     'company_id': company.id,
            //     'currency_id': currency_id.id
            // }
            // 
            // account = product.product_tmpl_id._get_product_accounts()['expense']
            // if account:
            //     vals['account_id'] = account.id
            // 
            // expense = super().message_new(msg_dict, dict(custom_values or {}, **vals))
            // self._send_expense_success_mail(msg_dict, expense)
            // return expense
            */
            return default;
        }

        public async Task<TEntity> NeedsProductPriceComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _needs_product_price_computation(self):
            // # Hook to be overridden.
            // self.ensure_one()
            // return self.product_has_cost
            */
            return default;
        }

        public async Task<TEntity> OnchangeAccountAssetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_account_asset(self):
            // if self.type == "purchase":
            //     self.account_depreciation_id = self.account_asset_id
            // elif self.type == "sale":
            //     self.account_depreciation_expense_id = self.account_asset_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeAmountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _onchange_amount_type(self):
            // self.amount_string = ''
            // if self.amount_type in ('percentage', 'percentage_st_line'):
            //     self.amount_string = '100'
            // elif self.amount_type == 'regex':
            //     self.amount_string = r'([\d,]+)'
            */
            return default;
        }

        public async Task<TEntity> OnchangeCategoryIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_category_id(self):
            // vals = self.onchange_category_id_values(self.category_id.id)
            // # We cannot use 'write' on an object that doesn't exist yet
            // if vals:
            //     for k, v in vals['value'].items():
            //         setattr(self, k, v)
            */
            return default;
        }

        public async Task<TEntity> OnchangeCategoryIdValuesAsync<TEntity>(IEnumerable<TEntity> entities, Guid category_id) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_category_id_values(self, category_id):
            // if category_id:
            //     category = self.env['account.asset.category'].browse(category_id)
            //     return {
            //         'value': {
            //             'method': category.method,
            //             'method_number': category.method_number,
            //             'method_time': category.method_time,
            //             'method_period': category.method_period,
            //             'method_progress_factor': category.method_progress_factor,
            //             'method_end': category.method_end,
            //             'prorata': category.prorata,
            //             'date_first_depreciation': category.date_first_depreciation,
            //             'account_analytic_id': category.account_analytic_id.id,
            //             'analytic_distribution': category.analytic_distribution,
            //         }
            //     }
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_company_id(self):
            // self.currency_id = self.company_id.currency_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateFirstDepreciationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_date_first_depreciation(self):
            // for record in self:
            //     if record.date_first_depreciation == 'manual':
            //         record.first_depreciation_manual_date = record.date
            */
            return default;
        }

        public async Task<TEntity> OnchangeMethodTimeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_method_time(self):
            // if self.method_time != 'number':
            //     self.prorata = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeMethodTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _onchange_method_time(self):
            // if self.method_time != 'number':
            //     self.prorata = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductHasCostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _onchange_product_has_cost(self):
            // """ Reset quantity to 1, in case of 0-cost product. To make sure switching non-0-cost to 0-cost doesn't keep the quantity."""
            // if not self.product_has_cost and self.state in {'draft', 'reported'}:
            //     self.quantity = 1
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def onchange_product_id(self):
            // # TODO: Remove when onchanges are replaced with computes
            // if not self.product_id or (self.env.context.get('origin_po_id') and self.product_qty):
            //     return
            // 
            // # Reset date, price and quantity since _onchange_quantity will provide default values
            // self.price_unit = self.product_qty = 0.0
            // 
            // self._product_id_change()
            // 
            // self._suggest_quantity()
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _onchange_product_id(self):
            // if not self.product_id:
            //     return
            // self._reset_price_unit()
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductIdWarningAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def onchange_product_id_warning(self):
            // if not self.product_id or not self.env.user.has_group('purchase.group_warning_purchase'):
            //     return
            // warning = {}
            // title = False
            // message = False
            // 
            // product_info = self.product_id
            // 
            // if product_info.purchase_line_warn != 'no-message':
            //     title = _("Warning for %s", product_info.name)
            //     message = product_info.purchase_line_warn_msg
            //     warning['title'] = title
            //     warning['message'] = message
            //     if product_info.purchase_line_warn == 'block':
            //         self.product_id = False
            //     return {'warning': warning}
            // return {}
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductIdWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _onchange_product_id_warning(self):
            // if not self.product_id:
            //     return
            // 
            // product = self.product_id
            // if product.sale_line_warn != 'no-message':
            //     if product.sale_line_warn == 'block':
            //         self.product_id = False
            // 
            //     return {
            //         'warning': {
            //             'title': _("Warning for %s", product.name),
            //             'message': product.sale_line_warn_msg,
            //         }
            //     }
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductPackagingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _onchange_product_packaging_id(self):
            // if self.product_packaging_id and self.product_qty:
            //     newqty = self.product_packaging_id._check_qty(self.product_qty, self.product_uom, "UP")
            //     if float_compare(newqty, self.product_qty, precision_rounding=self.product_uom.rounding) != 0:
            //         return {
            //             'warning': {
            //                 'title': _('Warning'),
            //                 'message': _(
            //                     "This product is packaged by %(pack_size).2f %(pack_name)s. You should purchase %(quantity).2f %(unit)s.",
            //                     pack_size=self.product_packaging_id.qty,
            //                     pack_name=self.product_id.uom_id.name,
            //                     quantity=newqty,
            //                     unit=self.product_uom.name
            //                 ),
            //             },
            //         }
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _onchange_product_packaging_id(self):
            // if self.product_packaging_id and self.product_uom_qty:
            //     newqty = self.product_packaging_id._check_qty(self.product_uom_qty, self.product_uom, "UP")
            //     if float_compare(newqty, self.product_uom_qty, precision_rounding=self.product_uom.rounding) != 0:
            //         return {
            //             'warning': {
            //                 'title': _('Warning'),
            //                 'message': _(
            //                     "This product is packaged by %(pack_size).2f %(pack_name)s. You should sell %(quantity).2f %(unit)s.",
            //                     pack_size=self.product_packaging_id.qty,
            //                     pack_name=self.product_id.uom_id.name,
            //                     quantity=newqty,
            //                     unit=self.product_uom.name
            //                 ),
            //             },
            //         }
            */
            return default;
        }

        public async Task<TEntity> OnchangeTaxIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _onchange_tax_ids(self):
            // # Multiple taxes with force_tax_included results in wrong computation, so we
            // # only allow to set the force_tax_included field if we have one tax selected
            // if len(self.tax_ids) != 1:
            //     self.force_tax_included = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def onchange_type(self):
            // if self.type == 'sale':
            //     self.prorata = True
            //     self.method_period = 1
            // else:
            //     self.method_period = 12
            */
            return default;
        }

        public async Task<TEntity> OpenEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def open_entries(self):
            // move_ids = []
            // for asset in self:
            //     for depreciation_line in asset.depreciation_line_ids:
            //         if depreciation_line.move_id:
            //             move_ids.append(depreciation_line.move_id.id)
            // return {
            //     'name': _('Journal Entries'),
            //     'view_type': 'form',
            //     'view_mode': 'list,form',
            //     'res_model': 'account.move',
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            //     'domain': [('id', 'in', move_ids)],
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenReconcileViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def open_reconcile_view(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('account.action_account_moves_all_grouped_matching')
            // ids = self._all_reconciled_lines().filtered(lambda l: l.matched_debit_ids or l.matched_credit_ids).ids
            // action['domain'] = [('id', 'in', ids)]
            // return clean_action(action, self.env)
            */
            return default;
        }

        public async Task<TEntity> OptimizeReconciliationPlanInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reconciliation_plan, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _optimize_reconciliation_plan(self, reconciliation_plan, shadowed_aml_values=None):
            // """ Decode the initial reconciliation plan passed as parameter and converted it into a list of tree depicting
            // the way the reconciliation should be done.
            // Also, this method is responsible sorting the amls and splitting them by currency.
            // Then, this method checks the parameter to ensure we are not going to perform any invalid reconciliation like
            // a cross-account/cross-company partial.
            // 
            // The split by currencies is made as follows.
            // Suppose account.move.line(1, 2) are expressed in currency1 and account.move.line(3, 4) are expressed
            // in currency2.
            // If the reconciliation plan is [account.move.line(1, 2, 3, 4)], the optimizer will convert it into:
            // [[account.move.line(1, 2), account.move.line(3, 4)]]
            // 
            // :param reconciliation_plan: A list of reconciliation to perform.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :return: A list of dictionaries containing:
            //     * amls: A recordset.
            //     * aml_ids: The recordset ids.
            //     * nodes: A list of sub-nodes.
            // """
            // 
            // def process_amls(amls):
            //     if self._context.get('reduced_line_sorting'):
            //         sorted_amls = amls.sorted(key=lambda aml: (
            //             aml._get_reconciliation_aml_field_value('date_maturity', shadowed_aml_values)
            //                 or aml._get_reconciliation_aml_field_value('date', shadowed_aml_values),
            //             aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values),
            //         ))
            //     else:
            //         sorted_amls = amls.sorted(key=lambda aml: (
            //             aml._get_reconciliation_aml_field_value('date_maturity', shadowed_aml_values)
            //                 or aml._get_reconciliation_aml_field_value('date', shadowed_aml_values),
            //             aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values),
            //             aml._get_reconciliation_aml_field_value('amount_currency', shadowed_aml_values),
            //             aml._get_reconciliation_aml_field_value('balance', shadowed_aml_values),
            //         ))
            //     currencies = sorted_amls.mapped(lambda x: x._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values))
            //     results = {
            //         'amls': sorted_amls,
            //         'aml_ids': set(sorted_amls.ids),
            //     }
            // 
            //     if len(currencies) != 1:
            //         nodes = results['nodes'] = []
            //         for currency in currencies:
            //             amls_in_currency = sorted_amls\
            //                 .filtered(lambda x: x._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values) == currency)
            //             nodes.append({
            //                 'amls': amls_in_currency,
            //                 'aml_ids': set(amls_in_currency.ids),
            //             })
            //     return results
            // 
            // def process_children(children):
            //     node = {
            //         'nodes': [],
            //         'aml_ids': set(),
            //     }
            //     for child in children:
            //         results = process_leaf(child)
            //         if results:
            //             node['nodes'].append(results)
            //             node['aml_ids'].update(results['aml_ids'])
            //     node['amls'] = self.browse(node['aml_ids'])
            //     return node
            // 
            // def process_leaf(item):
            //     if not item:
            //         return
            // 
            //     if isinstance(item, models.BaseModel):
            //         # Group of amls to evaluate.
            //         return process_amls(item)
            //     else:
            //         # Sub plan to evaluate.
            //         return process_children(item)
            // 
            // plan_list = []
            // all_aml_ids = set()
            // for item in reconciliation_plan:
            //     plan_node = process_leaf(item)
            //     if not plan_node or not plan_node.get('amls'):
            //         continue
            // 
            //     # Check the amls to be reconciled all together.
            //     amls = plan_node['amls']
            //     amls._check_amls_exigibility_for_reconciliation(shadowed_aml_values=shadowed_aml_values)
            //     plan_list.append(plan_node)
            //     all_aml_ids.update(plan_node['aml_ids'])
            // 
            // return plan_list, self.browse(all_aml_ids)
            */
            return default;
        }

        public async Task<TEntity> ParseExpenseSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description, object currencies) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _parse_expense_subject(self, expense_description, currencies):
            // """
            //     Fetch product, price and currency info from mail subject.
            // 
            //     Product can be identified based on product name or product code.
            //     It can be passed between [] or it can be placed at start.
            // 
            //     When parsing, only consider currencies passed as parameter.
            //     This will fetch currency in symbol($) or ISO name (USD).
            // 
            //     Some valid examples:
            //         Travel by Air [TICKET] USD 1205.91
            //         TICKET $1205.91 Travel by Air
            //         Extra expenses 29.10EUR [EXTRA]
            // """
            // product, expense_description = self._parse_product(expense_description)
            // price, currency_id, expense_description = self._parse_price(expense_description, currencies)
            // 
            // return product, price, currency_id, expense_description
            */
            return default;
        }

        public async Task<TEntity> ParseFlushFnamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _parse_flush_fnames(self, fnames):
            // if fnames and {'balance', 'amount_currency'} & set(fnames):
            //     # flush the amount currency to avoid triggering check_amount_currency_balance_sign
            //     fnames = {'balance', 'amount_currency'} | set(fnames)
            // return fnames
            */
            return default;
        }

        public async Task<TEntity> ParsePriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description, object currencies) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _parse_price(self, expense_description, currencies):
            // """ Return price, currency and updated description """
            // symbols, symbols_pattern, float_pattern = [], '', r'[+-]?(\d+[.,]?\d*)'
            // price = 0.0
            // for currency in currencies:
            //     symbols += [re.escape(currency.symbol), re.escape(currency.name)]
            // symbols_pattern = '|'.join(symbols)
            // price_pattern = f'(({symbols_pattern})?\\s?{float_pattern}\\s?({symbols_pattern})?)'
            // matches = re.findall(price_pattern, expense_description)
            // currency = currencies[:1]
            // if matches:
            //     match = max(matches, key=lambda match: len([group for group in match if group]))
            //     # get the longest match. e.g. "2 chairs 120$" -> the price is 120$, not 2
            //     full_str = match[0]
            //     currency_str = match[1] or match[3]
            //     price = match[2].replace(',', '.')
            // 
            //     if currency_str and currencies:
            //         currencies = currencies.filtered(lambda c: currency_str in [c.symbol, c.name])
            //         currency = currencies[:1] or currency
            //     expense_description = expense_description.replace(full_str, ' ')  # remove price from description
            //     expense_description = re.sub(' +', ' ', expense_description.strip())
            // 
            // return float(price), currency, expense_description
            */
            return default;
        }

        public async Task<TEntity> ParseProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _parse_product(self, expense_description):
            // """
            //     Parse the subject to find the product.
            //     Product code should be the first word of expense_description
            //     Return product.product and updated description
            // """
            // product_code = expense_description.split(' ')[0]
            // product = self.env['product.product'].search([('can_be_expensed', '=', True), ('default_code', '=ilike', product_code)], limit=1)
            // if product:
            //     expense_description = expense_description.replace(product_code, '', 1)
            // 
            // return product, expense_description
            */
            return default;
        }

        public async Task<TEntity> PrepareAccountMoveLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_account_move_line(self, move=False):
            // self.ensure_one()
            // aml_currency = move and move.currency_id or self.currency_id
            // date = move and move.date or fields.Date.today()
            // 
            // res = {
            //     'display_type': self.display_type or 'product',
            //     'name': self.env['account.move.line']._get_journal_items_full_name(self.name, self.product_id.display_name),
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_uom.id,
            //     'quantity': self.qty_to_invoice,
            //     'discount': self.discount,
            //     'price_unit': self.currency_id._convert(self.price_unit, aml_currency, self.company_id, date, round=False),
            //     'tax_ids': [(6, 0, self.taxes_id.ids)],
            //     'purchase_line_id': self.id,
            //     'is_downpayment': self.is_downpayment,
            // }
            // return res
            */
            return default;
        }

        public async Task<TEntity> PrepareAddMissingFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_add_missing_fields(self, values):
            // """ Deduce missing required fields from the onchange """
            // res = {}
            // onchange_fields = ['name', 'price_unit', 'product_qty', 'product_uom', 'taxes_id', 'date_planned']
            // if values.get('order_id') and values.get('product_id') and any(f not in values for f in onchange_fields):
            //     line = self.new(values)
            //     line.onchange_product_id()
            //     for field in onchange_fields:
            //         if field not in values:
            //             res[field] = line._fields[field].convert_to_write(line[field], line)
            // return res
            */
            return default;
        }

        public async Task<TEntity> PrepareAnalyticDistributionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object distribution, List<Guid> account_ids, object distribution_on_each_plan) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_analytic_distribution_line(self, distribution, account_ids, distribution_on_each_plan):
            // """ Prepare the values used to create() an account.analytic.line upon validation of an account.move.line having
            //     analytic tags with analytic distribution.
            // """
            // self.ensure_one()
            // account_field_values = {}
            // decimal_precision = self.env['decimal.precision'].precision_get('Percentage Analytic')
            // amount = 0
            // for account in self.env['account.analytic.account'].browse(map(int, account_ids.split(","))).exists():
            //     distribution_plan = distribution_on_each_plan.get(account.root_plan_id, 0) + distribution
            //     if float_compare(distribution_plan, 100, precision_digits=decimal_precision) == 0:
            //         amount = -self.balance * (100 - distribution_on_each_plan.get(account.root_plan_id, 0)) / 100.0
            //     else:
            //         amount = -self.balance * distribution / 100.0
            //     distribution_on_each_plan[account.root_plan_id] = distribution_plan
            //     account_field_values[account.plan_id._column_name()] = account.id
            // default_name = self.name or (self.ref or '/' + ' -- ' + (self.partner_id and self.partner_id.name or '/'))
            // return {
            //     'name': default_name,
            //     'date': self.date,
            //     **account_field_values,
            //     'partner_id': self.partner_id.id,
            //     'unit_amount': self.quantity,
            //     'product_id': self.product_id and self.product_id.id or False,
            //     'product_uom_id': self.product_uom_id and self.product_uom_id.id or False,
            //     'amount': amount,
            //     'general_account_id': self.account_id.id,
            //     'ref': self.ref,
            //     'move_line_id': self.id,
            //     'user_id': self.move_id.invoice_user_id.id or self._uid,
            //     'company_id': self.company_id.id or self.env.company.id,
            //     'category': 'invoice' if self.move_id.is_sale_document() else 'vendor_bill' if self.move_id.is_purchase_document() else 'other',
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareAnalyticLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_analytic_lines(self):
            // self.ensure_one()
            // analytic_line_vals = []
            // if self.analytic_distribution:
            //     # distribution_on_each_plan corresponds to the proportion that is distributed to each plan to be able to
            //     # give the real amount when we achieve a 100% distribution
            //     distribution_on_each_plan = {}
            //     for account_ids, distribution in self.analytic_distribution.items():
            //         line_values = self._prepare_analytic_distribution_line(float(distribution), account_ids, distribution_on_each_plan)
            //         if not self.currency_id.is_zero(line_values.get('amount')):
            //             analytic_line_vals.append(line_values)
            // return analytic_line_vals
            */
            return default;
        }

        public async Task<TEntity> PrepareBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _prepare_base_line_for_taxes_computation(self, **kwargs):
            // self.ensure_one()
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     self,
            //     **{
            //         'partner_id': self.vendor_id,
            //         'special_mode': 'total_included',
            //         'rate': self.currency_rate,
            //         **kwargs,
            //     },
            // )
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_base_line_for_taxes_computation(self):
            // """ Convert the current record to a dictionary in order to use the generic taxes computation method
            // defined on account.tax.
            // 
            // :return: A python dictionary.
            // """
            // self.ensure_one()
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     self,
            //     tax_ids=self.taxes_id,
            //     quantity=self.product_qty,
            //     partner_id=self.order_id.partner_id,
            //     currency_id=self.order_id.currency_id or self.order_id.company_id.currency_id,
            //     rate=self.order_id.currency_rate,
            // )
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _prepare_base_line_for_taxes_computation(self, **kwargs):
            // """ Convert the current record to a dictionary in order to use the generic taxes computation method
            // defined on account.tax.
            // 
            // :return: A python dictionary.
            // """
            // self.ensure_one()
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     self,
            //     **{
            //         'tax_ids': self.tax_id,
            //         'quantity': self.product_uom_qty,
            //         'partner_id': self.order_id.partner_id,
            //         'currency_id': self.order_id.currency_id or self.order_id.company_id.currency_id,
            //         'rate': self.order_id.currency_rate,
            //         **kwargs,
            //     },
            // )
            */
            return default;
        }

        public async Task<TEntity> PrepareCreateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_create_values(self, vals_list):
            // result_vals_list = super()._prepare_create_values(vals_list)
            // for init_vals, res_vals in zip(vals_list, result_vals_list):
            //     # Allow computing the balance based on the amount_currency if it wasn't specified in the create vals.
            //     if (
            //         'amount_currency' in init_vals
            //         and 'balance' not in init_vals
            //         and 'debit' not in init_vals
            //         and 'credit' not in init_vals
            //     ):
            //         res_vals.pop('balance', 0)
            //         res_vals.pop('debit', 0)
            //         res_vals.pop('credit', 0)
            // 
            //     if res_vals['display_type'] in ('line_section', 'line_note'):
            //         res_vals.pop('account_id')
            // 
            // return result_vals_list
            */
            return default;
        }

        public async Task<TEntity> PrepareEdiValsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_edi_vals_to_export(self):
            // ''' The purpose of this helper is the same as '_prepare_edi_vals_to_export' but for a single invoice line.
            // This includes the computation of the tax details for each invoice line or the management of the discount.
            // Indeed, in some EDI, we need to provide extra values depending the discount such as:
            // - the discount as an amount instead of a percentage.
            // - the price_unit but after subtraction of the discount.
            // 
            // :return: A python dict containing default pre-processed values.
            // '''
            // self.ensure_one()
            // 
            // if self.discount == 100.0:
            //     gross_price_subtotal = self.currency_id.round(self.price_unit * self.quantity)
            // else:
            //     gross_price_subtotal = self.currency_id.round(self.price_subtotal / (1 - self.discount / 100.0))
            // 
            // res = {
            //     'line': self,
            //     'price_unit_after_discount': self.currency_id.round(self.price_unit * (1 - (self.discount / 100.0))),
            //     'price_subtotal_before_discount': gross_price_subtotal,
            //     'price_subtotal_unit': self.currency_id.round(self.price_subtotal / self.quantity) if self.quantity else 0.0,
            //     'price_total_unit': self.currency_id.round(self.price_total / self.quantity) if self.quantity else 0.0,
            //     'price_discount': gross_price_subtotal - self.price_subtotal,
            //     'price_discount_unit': (gross_price_subtotal - self.price_subtotal) / self.quantity if self.quantity else 0.0,
            //     'gross_price_total_unit': self.currency_id.round(gross_price_subtotal / self.quantity) if self.quantity else 0.0,
            //     'unece_uom_code': self.product_id.product_tmpl_id.uom_id._get_unece_code(),
            // }
            // return res
            */
            return default;
        }

        public async Task<TEntity> PrepareExchangeDifferenceMoveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amounts_list, object company, object exchange_date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_exchange_difference_move_vals(self, amounts_list, company=None, exchange_date=None, **kwargs):
            // """ Prepare values to create later the exchange difference journal entry.
            // The exchange difference journal entry is there to fix the debit/credit of lines when the journal items are
            // fully reconciled in foreign currency.
            // :param amounts_list:    A list of dict, one for each aml.
            // :param company:         The company in case there is no aml in self.
            // :param exchange_date:   Optional date object providing the date to consider for the exchange difference.
            // :return:                A python dictionary containing:
            //     * move_vals:    A dictionary to be passed to the account.move.create method.
            //     * to_reconcile: A list of tuple <move_line, sequence> in order to perform the reconciliation after the move
            //                     creation.
            // """
            // company = (
            //     (self.move_id.filtered(lambda m: m.is_invoice(True)) or self.move_id).company_id
            //     or company
            // )[:1]
            // if not company:
            //     return
            // 
            // journal = self._get_exchange_journal(company)
            // accounting_exchange_date = journal.with_context(move_date=exchange_date).accounting_date if journal else date.min
            // 
            // move_vals = {
            //     'move_type': 'entry',
            //     'name': '/', # do not trigger the compute name before posting as it will most likely be posted immediately after
            //     'date': accounting_exchange_date,
            //     'journal_id': journal.id,
            //     'line_ids': [],
            //     'always_tax_exigible': True,
            // }
            // to_reconcile = []
            // 
            // for line, amounts in zip(self, amounts_list):
            //     move_vals['date'] = max(move_vals['date'], line.date)
            // 
            //     if 'amount_residual' in amounts:
            //         amount_residual = amounts['amount_residual']
            //         amount_residual_currency = 0.0
            //         if line.currency_id == line.company_id.currency_id:
            //             amount_residual_currency = amount_residual
            //         amount_residual_to_fix = amount_residual
            //         if line.company_currency_id.is_zero(amount_residual):
            //             continue
            //     elif 'amount_residual_currency' in amounts:
            //         amount_residual = 0.0
            //         amount_residual_currency = amounts['amount_residual_currency']
            //         amount_residual_to_fix = amount_residual_currency
            //         if line.currency_id.is_zero(amount_residual_currency):
            //             continue
            //     else:
            //         continue
            // 
            //     exchange_line_account = self._get_exchange_account(company, amount_residual_to_fix)
            // 
            //     sequence = len(move_vals['line_ids'])
            //     line_vals = [
            //         {
            //             'name': _('Currency exchange rate difference'),
            //             'debit': -amount_residual if amount_residual < 0.0 else 0.0,
            //             'credit': amount_residual if amount_residual > 0.0 else 0.0,
            //             'amount_currency': -amount_residual_currency,
            //             'full_reconcile_id': line.full_reconcile_id.id,
            //             'account_id': line.account_id.id,
            //             'currency_id': line.currency_id.id,
            //             'partner_id': line.partner_id.id,
            //             'sequence': sequence,
            //         },
            //         {
            //             'name': _('Currency exchange rate difference'),
            //             'debit': amount_residual if amount_residual > 0.0 else 0.0,
            //             'credit': -amount_residual if amount_residual < 0.0 else 0.0,
            //             'amount_currency': amount_residual_currency,
            //             'account_id': exchange_line_account.id,
            //             'currency_id': line.currency_id.id,
            //             'partner_id': line.partner_id.id,
            //             'sequence': sequence + 1,
            //         },
            //     ]
            // 
            //     if kwargs.get('exchange_analytic_distribution'):
            //         line_vals[1].update({'analytic_distribution': kwargs['exchange_analytic_distribution']})
            // 
            //     move_vals['line_ids'] += [Command.create(vals) for vals in line_vals]
            //     to_reconcile.append((line, sequence))
            // 
            // return {'move_values': move_vals, 'to_reconcile': to_reconcile}
            */
            return default;
        }

        public async Task<TEntity> PrepareGraphDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object load_data, object week_range) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _prepare_graph_data(self, load_data, week_range):
            // graph_data = {wid: [] for wid in self._ids}
            // for workcenter in self:
            //     load_limit = sum(workcenter.resource_calendar_id.attendance_ids.mapped('duration_hours'))
            //     wc_data = {'is_sample_data': not self.order_ids, 'labels': list(week_range.values())}
            //     load_bar = []
            //     excess_bar = []
            //     for week_start in week_range:
            //         load_bar.append(min(load_data[workcenter].get(week_start, 0), load_limit))
            //         excess_bar.append(max(float_round(load_data[workcenter].get(week_start, 0) - load_limit, precision_digits=1, rounding_method='HALF-UP'), 0))
            //     wc_data['values'] = [load_bar, load_limit, excess_bar]
            //     graph_data[workcenter.id].append(wc_data)
            // return graph_data
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _prepare_invoice_line(self, **optional_values):
            // """Prepare the values to create the new invoice line for a sales order line.
            // 
            // :param optional_values: any parameter that should be added to the returned invoice line
            // :rtype: dict
            // """
            // self.ensure_one()
            // 
            // if self.product_id.type == 'combo':
            //     # If the quantity to invoice is a whole number, format it as an integer (with no decimal point)
            //     qty_to_invoice = int(self.qty_to_invoice) if self.qty_to_invoice == int(self.qty_to_invoice) else self.qty_to_invoice
            //     return {
            //         'display_type': 'line_section',
            //         'sequence': self.sequence,
            //         'name': f'{self.product_id.name} x {qty_to_invoice}',
            //         'product_uom_id': self.product_uom.id,
            //         'quantity': self.qty_to_invoice,
            //         'sale_line_ids': [Command.link(self.id)],
            //         **optional_values,
            //     }
            // res = {
            //     'display_type': self.display_type or 'product',
            //     'sequence': self.sequence,
            //     'name': self.env['account.move.line']._get_journal_items_full_name(self.name, self.product_id.display_name),
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_uom.id,
            //     'quantity': self.qty_to_invoice,
            //     'discount': self.discount,
            //     'price_unit': self.price_unit,
            //     'tax_ids': [Command.set(self.tax_id.ids)],
            //     'sale_line_ids': [Command.link(self.id)],
            //     'is_downpayment': self.is_downpayment,
            // }
            // downpayment_lines = self.invoice_lines.filtered('is_downpayment')
            // if self.is_downpayment and downpayment_lines:
            //     res['account_id'] = downpayment_lines.account_id[:1].id
            // if optional_values:
            //     res.update(optional_values)
            // if self.display_type:
            //     res['account_id'] = False
            // return res
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveLineResidualAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aml_values, object counterpart_currency, object shadowed_aml_values, object other_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_move_line_residual_amounts(self, aml_values, counterpart_currency, shadowed_aml_values=None, other_aml_values=None):
            // """ Prepare the available residual amounts for each currency.
            // :param aml_values: The values of account.move.line to consider.
            // :param counterpart_currency: The currency of the opposite line this line will be reconciled with.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :param other_aml_values:    The other aml values to be reconciled with the current one.
            // :return: A mapping currency -> dictionary containing:
            //     * residual: The residual amount left for this currency.
            //     * rate:     The rate applied regarding the company's currency.
            // """
            // 
            // def is_payment(aml):
            //     return aml.move_id.origin_payment_id or aml.move_id.statement_line_id
            // 
            // def get_odoo_rate(aml, other_aml, currency):
            //     if forced_rate := self._context.get('forced_rate_from_register_payment'):
            //         return forced_rate
            //     if other_aml and not is_payment(aml) and is_payment(other_aml):
            //         return get_accounting_rate(other_aml, currency)
            //     if aml.move_id.is_invoice(include_receipts=True):
            //         exchange_rate_date = aml.move_id.invoice_date
            //     else:
            //         exchange_rate_date = aml._get_reconciliation_aml_field_value('date', shadowed_aml_values)
            //     return currency._get_conversion_rate(aml.company_currency_id, currency, aml.company_id, exchange_rate_date)
            // 
            // def get_accounting_rate(aml, currency):
            //     balance = aml._get_reconciliation_aml_field_value('balance', shadowed_aml_values)
            //     amount_currency = aml._get_reconciliation_aml_field_value('amount_currency', shadowed_aml_values)
            //     if not aml.company_currency_id.is_zero(balance) and not currency.is_zero(amount_currency):
            //         return abs(amount_currency / balance)
            // 
            // aml = aml_values['aml']
            // other_aml = (other_aml_values or {}).get('aml')
            // remaining_amount_curr = aml_values['amount_residual_currency']
            // remaining_amount = aml_values['amount_residual']
            // company_currency = aml.company_currency_id
            // currency = aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values)
            // account = aml._get_reconciliation_aml_field_value('account_id', shadowed_aml_values)
            // has_zero_residual = company_currency.is_zero(remaining_amount)
            // has_zero_residual_currency = currency.is_zero(remaining_amount_curr)
            // is_rec_pay_account = account.account_type in ('asset_receivable', 'liability_payable')
            // 
            // available_residual_per_currency = {}
            // 
            // if not has_zero_residual:
            //     available_residual_per_currency[company_currency] = {
            //         'residual': remaining_amount,
            //         'rate': 1,
            //     }
            // if currency != company_currency and not has_zero_residual_currency:
            //     available_residual_per_currency[currency] = {
            //         'residual': remaining_amount_curr,
            //         'rate': get_accounting_rate(aml, currency),
            //     }
            // 
            // if currency == company_currency \
            //     and is_rec_pay_account \
            //     and not has_zero_residual \
            //     and counterpart_currency != company_currency:
            //     rate = get_odoo_rate(aml, other_aml, counterpart_currency)
            //     residual_in_foreign_curr = counterpart_currency.round(remaining_amount * rate)
            //     if not counterpart_currency.is_zero(residual_in_foreign_curr):
            //         available_residual_per_currency[counterpart_currency] = {
            //             'residual': residual_in_foreign_curr,
            //             'rate': rate,
            //         }
            // elif currency == counterpart_currency \
            //     and currency != company_currency \
            //     and not has_zero_residual_currency:
            //     available_residual_per_currency[counterpart_currency] = {
            //         'residual': remaining_amount_curr,
            //         'rate': get_accounting_rate(aml, currency),
            //     }
            // return available_residual_per_currency
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _prepare_move_lines_vals(self):
            // self.ensure_one()
            // account = self._get_base_account()
            // 
            // return {
            //     'name': self._get_move_line_name(),
            //     'account_id': account.id,
            //     'quantity': self.quantity or 1,
            //     'price_unit': self.price_unit,
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_uom_id.id,
            //     'analytic_distribution': self.analytic_distribution,
            //     'expense_id': self.id,
            //     'partner_id': False if self.payment_mode == 'company_account' else self.employee_id.sudo().work_contact_id.id,
            //     'tax_ids': [Command.set(self.tax_ids.ids)],
            // }
            */
            return default;
        }

        public async Task<TEntity> PreparePaymentsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _prepare_payments_vals(self):
            // self.ensure_one()
            // 
            // journal = self.sheet_id.journal_id
            // payment_method_line = self.sheet_id.payment_method_line_id
            // if not payment_method_line:
            //     raise UserError(_("You need to add a manual payment method on the journal (%s)", journal.name))
            // 
            // AccountTax = self.env['account.tax']
            // rate = abs(self.total_amount_currency / self.total_amount) if self.total_amount else 0.0
            // base_line = self._prepare_base_line_for_taxes_computation(
            //     price_unit=self.total_amount_currency,
            //     quantity=1.0,
            //     account_id=self._get_base_account(),
            //     rate=rate,
            // )
            // base_lines = [base_line]
            // AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            // AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, self.company_id, include_caba_tags=self.payment_mode == 'company_account')
            // tax_results = AccountTax._prepare_tax_lines(base_lines, self.company_id)
            // 
            // # Base line.
            // move_lines = []
            // for base_line, to_update in tax_results['base_lines_to_update']:
            //     base_move_line = {
            //         'name': self._get_move_line_name(),
            //         'account_id': base_line['account_id'].id,
            //         'product_id': base_line['product_id'].id,
            //         'analytic_distribution': base_line['analytic_distribution'],
            //         'expense_id': self.id,
            //         'tax_ids': [Command.set(base_line['tax_ids'].ids)],
            //         'tax_tag_ids': to_update['tax_tag_ids'],
            //         'amount_currency': to_update['amount_currency'],
            //         'balance': to_update['balance'],
            //         'currency_id': base_line['currency_id'].id,
            //         'partner_id': self.vendor_id.id,
            //         'quantity': self.quantity,
            //     }
            //     move_lines.append(base_move_line)
            // 
            // # Tax lines.
            // total_tax_line_balance = 0.0
            // for tax_line in tax_results['tax_lines_to_add']:
            //     total_tax_line_balance += tax_line['balance']
            //     move_lines.append(tax_line)
            // base_move_line['balance'] = self.total_amount - total_tax_line_balance
            // 
            // # Outstanding payment line.
            // move_lines.append({
            //     'name': self._get_move_line_name(),
            //     'account_id': self.sheet_id._get_expense_account_destination(),
            //     'balance': -self.total_amount,
            //     'amount_currency': self.currency_id.round(-self.total_amount_currency),
            //     'currency_id': self.currency_id.id,
            //     'partner_id': self.vendor_id.id,
            // })
            // payment_vals = {
            //     'date': self.date,
            //     'memo': self.name,
            //     'journal_id': journal.id,
            //     'amount': self.total_amount_currency,
            //     'payment_type': 'outbound',
            //     'partner_type': 'supplier',
            //     'partner_id': self.vendor_id.id,
            //     'currency_id': self.currency_id.id,
            //     'payment_method_line_id': payment_method_line.id,
            //     'company_id': self.company_id.id,
            // }
            // move_vals = {
            //     **self.sheet_id._prepare_move_vals(),
            //     'ref': self.name,
            //     'date': self.date,  # Overidden from self.sheet_id._prepare_move_vals() so we can use the expense date for the account move date
            //     'journal_id': journal.id,
            //     'partner_id': self.vendor_id.id,
            //     'currency_id': self.currency_id.id,
            //     'line_ids': [Command.create(line) for line in move_lines],
            //     'attachment_ids': [
            //         Command.create(attachment.copy_data({'res_model': 'account.move', 'res_id': False, 'raw': attachment.raw})[0])
            //         for attachment in self.message_main_attachment_id]
            // }
            // return move_vals, payment_vals
            */
            return default;
        }

        public async Task<TEntity> PrepareProcurementValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid group_id) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _prepare_procurement_values(self, group_id=False):
            // """ Prepare specific key for moves or other components that will be created from a stock rule
            // coming from a sale order line. This method could be override in order to add other custom key that could
            // be used in move/po creation.
            // """
            // return {}
            */
            return default;
        }

        public async Task<TEntity> PreparePurchaseOrderLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object product_qty, object price_unit, List<Guid> taxes_ids) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_purchase_order_line(self, product_id, product_qty, product_uom, company_id, supplier, po):
            // partner = supplier.partner_id
            // uom_po_qty = product_uom._compute_quantity(product_qty, product_id.uom_po_id, rounding_method='HALF-UP')
            // # _select_seller is used if the supplier have different price depending
            // # the quantities ordered.
            // today = fields.Date.today()
            // seller = product_id.with_company(company_id)._select_seller(
            //     partner_id=partner,
            //     quantity=uom_po_qty,
            //     date=po.date_order and max(po.date_order.date(), today) or today,
            //     uom_id=product_id.uom_po_id)
            // 
            // product_taxes = product_id.supplier_taxes_id.filtered(lambda x: x.company_id in company_id.parent_ids)
            // taxes = po.fiscal_position_id.map_tax(product_taxes)
            // 
            // price_unit = self.env['account.tax']._fix_tax_included_price_company(
            //     seller.price, product_taxes, taxes, company_id) if seller else 0
            // if price_unit and seller and po.currency_id and seller.currency_id != po.currency_id:
            //     price_unit = seller.currency_id._convert(
            //         price_unit, po.currency_id, po.company_id, po.date_order or fields.Date.today())
            // 
            // product_lang = product_id.with_prefetch().with_context(
            //     lang=partner.lang,
            //     partner_id=partner.id,
            // )
            // name = product_lang.with_context(seller_id=seller.id).display_name
            // if product_lang.description_purchase:
            //     name += '\n' + product_lang.description_purchase
            // 
            // date_planned = self.order_id.date_planned or self._get_date_planned(seller, po=po)
            // discount = seller.discount or 0.0
            // 
            // return {
            //     'name': name,
            //     'product_qty': uom_po_qty,
            //     'product_id': product_id.id,
            //     'product_uom': product_id.uom_po_id.id,
            //     'price_unit': price_unit,
            //     'date_planned': date_planned,
            //     'taxes_id': [(6, 0, taxes.ids)],
            //     'order_id': po.id,
            //     'discount': discount,
            // }
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _prepare_purchase_order_line(self, name, product_qty=0.0, price_unit=0.0, taxes_ids=False):
            // self.ensure_one()
            // if self.product_description_variants:
            //     name += '\n' + self.product_description_variants
            // date_planned = fields.Datetime.now()
            // if self.requisition_id.date_start:
            //     date_planned = max(date_planned, fields.Datetime.to_datetime(self.requisition_id.date_start))
            // return {
            //     'name': name,
            //     'product_id': self.product_id.id,
            //     'product_uom': self.product_id.uom_po_id.id,
            //     'product_qty': product_qty,
            //     'price_unit': price_unit,
            //     'taxes_id': [(6, 0, taxes_ids)],
            //     'date_planned': date_planned,
            //     'analytic_distribution': self.analytic_distribution,
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareReconciliationAmlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_reconciliation_amls(self, values_list, shadowed_aml_values=None):
            // """ Prepare the partials on the current journal items to perform the reconciliation.
            // Note: The order of records in self is important because the journal items will be reconciled using this order.
            // 
            // :param values_list: A list of dictionaries, one for each aml.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :return: a tuple of
            //     1) list of vals for partial reconciliation creation,
            //     2) the list of vals for the exchange difference entries to be created
            // """
            // debit_values_list = iter([
            //     x
            //     for x in values_list
            //     if x['aml']._get_reconciliation_aml_field_value('balance', shadowed_aml_values) > 0.0
            //        or x['aml']._get_reconciliation_aml_field_value('amount_currency', shadowed_aml_values) > 0.0
            // ])
            // credit_values_list = iter([
            //     x
            //     for x in values_list
            //     if x['aml']._get_reconciliation_aml_field_value('balance', shadowed_aml_values) < 0.0
            //        or x['aml']._get_reconciliation_aml_field_value('amount_currency', shadowed_aml_values) < 0.0
            // ])
            // debit_values = None
            // credit_values = None
            // fully_reconciled_aml_ids = set()
            // 
            // all_results = []
            // while True:
            // 
            //     # ==== Find the next available lines ====
            //     # For performance reasons, the partials are created all at once meaning the residual amounts can't be
            //     # trusted from one iteration to another. That's the reason why all residual amounts are kept as variables
            //     # and reduced "manually" every time we append a dictionary to 'partials_values_list'.
            // 
            //     # Move to the next available debit line.
            //     if not debit_values:
            //         debit_values = next(debit_values_list, None)
            //         if not debit_values:
            //             break
            // 
            //     # Move to the next available credit line.
            //     if not credit_values:
            //         credit_values = next(credit_values_list, None)
            //         if not credit_values:
            //             break
            // 
            //     # ==== Compute the amounts to reconcile ====
            // 
            //     results = self._prepare_reconciliation_single_partial(
            //         debit_values,
            //         credit_values,
            //         shadowed_aml_values=shadowed_aml_values,
            //     )
            //     if results.get('partial_values'):
            //         all_results.append(results)
            //     if results['debit_values'] is None:
            //         fully_reconciled_aml_ids.add(debit_values['aml'].id)
            //         debit_values = None
            //     if results['credit_values'] is None:
            //         fully_reconciled_aml_ids.add(credit_values['aml'].id)
            //         credit_values = None
            // 
            // return all_results, fully_reconciled_aml_ids
            */
            return default;
        }

        public async Task<TEntity> PrepareReconciliationPlanInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan, object amls_values_map, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_reconciliation_plan(self, plan, amls_values_map, shadowed_aml_values=None):
            // """ Perform virtually the reconciliation of the plan passed as parameter.
            // 
            // :param plan: The plan to know which lines to reconcile in which order.
            // :param amls_values_map: A mapping aml => amount_residual/amount_residual_currency
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :return: A list of all results returned by the '_prepare_reconciliation_amls' method.
            // """
            // all_fully_reconciled_aml_ids = set()
            // all_results = []
            // 
            // def process_amls(amls):
            //     remaining_amls = amls.filtered(lambda aml: aml.id not in all_fully_reconciled_aml_ids)
            //     amls_results, fully_reconciled_aml_ids = self._prepare_reconciliation_amls(
            //         [
            //             amls_values_map[aml]
            //             for aml in remaining_amls
            //         ],
            //         shadowed_aml_values=shadowed_aml_values,
            //     )
            //     all_fully_reconciled_aml_ids.update(fully_reconciled_aml_ids)
            //     for amls_result in amls_results:
            //         all_results.append(amls_result)
            // 
            // def process_leaf(plan_node):
            //     # Sub plan to evaluate.
            //     for child_node in plan_node.get('nodes', []):
            //         process_leaf(child_node)
            // 
            //     # Group of amls to evaluate.
            //     process_amls(plan_node['amls'])
            // 
            // process_leaf(plan)
            // return all_results
            */
            return default;
        }

        public async Task<TEntity> PrepareReconciliationSinglePartialInternalAsync<TEntity>(IEnumerable<TEntity> entities, object debit_values, object credit_values, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prepare_reconciliation_single_partial(self, debit_values, credit_values, shadowed_aml_values=None):
            // """ Prepare the values to create an account.partial.reconcile later when reconciling the dictionaries passed
            // as parameters, each one representing an account.move.line.
            // :param debit_values:  The values of account.move.line to consider for a debit line.
            // :param credit_values: The values of account.move.line to consider for a credit line.
            // :param shadowed_aml_values: A mapping aml -> dictionary to replace some original aml values to something else.
            //                             This is usefull if you want to preview the reconciliation before doing some changes
            //                             on amls like changing a date or an account.
            // :return: A dictionary:
            //     * debit_values:     None if the line has nothing left to reconcile.
            //     * credit_values:    None if the line has nothing left to reconcile.
            //     * partial_values:   The newly computed values for the partial.
            //     * exchange_values:  The values to create an exchange difference linked to this partial.
            // """
            // # ==== Determine the currency in which the reconciliation will be done ====
            // # In this part, we retrieve the residual amounts, check if they are zero or not and determine in which
            // # currency and at which rate the reconciliation will be done.
            // res = {
            //     'debit_values': debit_values,
            //     'credit_values': credit_values,
            // }
            // debit_aml = debit_values['aml']
            // credit_aml = credit_values['aml']
            // debit_currency = debit_aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values)
            // credit_currency = credit_aml._get_reconciliation_aml_field_value('currency_id', shadowed_aml_values)
            // company_currency = debit_aml.company_currency_id
            // 
            // remaining_debit_amount_curr = debit_values['amount_residual_currency']
            // remaining_credit_amount_curr = credit_values['amount_residual_currency']
            // remaining_debit_amount = debit_values['amount_residual']
            // remaining_credit_amount = credit_values['amount_residual']
            // 
            // debit_available_residual_amounts = self._prepare_move_line_residual_amounts(
            //     debit_values,
            //     credit_currency,
            //     shadowed_aml_values=shadowed_aml_values,
            //     other_aml_values=credit_values,
            // )
            // credit_available_residual_amounts = self._prepare_move_line_residual_amounts(
            //     credit_values,
            //     debit_currency,
            //     shadowed_aml_values=shadowed_aml_values,
            //     other_aml_values=debit_values,
            // )
            // 
            // if debit_currency != company_currency \
            //     and debit_currency in debit_available_residual_amounts \
            //     and debit_currency in credit_available_residual_amounts:
            //     recon_currency = debit_currency
            // elif credit_currency != company_currency \
            //     and credit_currency in debit_available_residual_amounts \
            //     and credit_currency in credit_available_residual_amounts:
            //     recon_currency = credit_currency
            // else:
            //     recon_currency = company_currency
            // 
            // debit_recon_values = debit_available_residual_amounts.get(recon_currency)
            // credit_recon_values = credit_available_residual_amounts.get(recon_currency)
            // 
            // # Check if there is something left to reconcile. Move to the next loop iteration if not.
            // skip_reconciliation = False
            // if not debit_recon_values:
            //     res['debit_values'] = None
            //     skip_reconciliation = True
            // if not credit_recon_values:
            //     res['credit_values'] = None
            //     skip_reconciliation = True
            // if skip_reconciliation:
            //     return res
            // 
            // recon_debit_amount = debit_recon_values['residual']
            // recon_credit_amount = -credit_recon_values['residual']
            // 
            // # ==== Match both lines together and compute amounts to reconcile ====
            // 
            // # Special case for exchange difference lines. In that case, both lines are sharing the same foreign
            // # currency but at least one has no amount in foreign currency.
            // # In that case, we don't want a rate for the opposite line because the exchange difference is supposed
            // # to reduce only the amount in company currency but not the foreign one.
            // exchange_line_mode = \
            //     recon_currency == company_currency \
            //     and debit_currency == credit_currency \
            //     and (
            //         not debit_available_residual_amounts.get(debit_currency)
            //         or not credit_available_residual_amounts.get(credit_currency)
            //     )
            // 
            // # Determine which line is fully matched by the other.
            // compare_amounts = recon_currency.compare_amounts(recon_debit_amount, recon_credit_amount)
            // min_recon_amount = min(recon_debit_amount, recon_credit_amount)
            // debit_fully_matched = compare_amounts <= 0
            // credit_fully_matched = compare_amounts >= 0
            // 
            // def get_amount_range_after_rate(currency_from, currency_to, amount, rate):
            //     # Suppose balance=1000, rate=12.
            //     # 1000.0 could be the result of a rounding of [999.995, 1000.0049999999999].
            //     # Let's say the target currency could be [999.995 * 12, 1000.005 * 12] = [11999.94, 12000.06]
            //     # instead of just 120000.
            //     if not rate:
            //         return 0.0, 0.0, 0.0
            //     half_rounding = currency_from.rounding / 2
            //     return (
            //         currency_to.round((amount - half_rounding) * rate),
            //         currency_to.round(amount * rate),
            //         currency_to.round((amount + half_rounding) * rate),
            //     )
            // 
            // # ==== Computation of partial amounts ====
            // if recon_currency == company_currency:
            //     if exchange_line_mode:
            //         debit_rate = None
            //         credit_rate = None
            //     else:
            //         debit_rate = debit_available_residual_amounts.get(debit_currency, {}).get('rate')
            //         credit_rate = credit_available_residual_amounts.get(credit_currency, {}).get('rate')
            // 
            //     # Compute the partial amount expressed in company currency.
            //     partial_amount = min_recon_amount
            // 
            //     # Compute the partial amount expressed in foreign currency.
            //     if debit_rate:
            //         partial_debit_amount_currency = debit_currency.round(debit_rate * min_recon_amount)
            //         partial_debit_amount_currency = min(partial_debit_amount_currency, remaining_debit_amount_curr)
            //     else:
            //         partial_debit_amount_currency = 0.0
            //     if credit_rate:
            //         partial_credit_amount_currency = credit_currency.round(credit_rate * min_recon_amount)
            //         partial_credit_amount_currency = min(partial_credit_amount_currency, -remaining_credit_amount_curr)
            //     else:
            //         partial_credit_amount_currency = 0.0
            // 
            // else:
            //     # recon_currency != company_currency
            //     if exchange_line_mode:
            //         debit_rate = None
            //         credit_rate = None
            //     else:
            //         debit_rate = debit_recon_values['rate']
            //         credit_rate = credit_recon_values['rate']
            // 
            //     # Compute the partial amount expressed in foreign currency.
            //     partial_debit_amount_range = get_amount_range_after_rate(
            //         currency_from=debit_currency,
            //         currency_to=company_currency,
            //         amount=min_recon_amount,
            //         rate=(1 / debit_rate) if debit_rate else 0.0,
            //     )
            //     partial_debit_amount = partial_debit_amount_range[1]
            //     partial_debit_amount = min(partial_debit_amount, remaining_debit_amount)
            //     partial_credit_amount_range = get_amount_range_after_rate(
            //         currency_from=credit_currency,
            //         currency_to=company_currency,
            //         amount=min_recon_amount,
            //         rate=(1 / credit_rate) if credit_rate else 0.0,
            //     )
            //     partial_credit_amount = partial_credit_amount_range[1]
            //     partial_credit_amount = min(partial_credit_amount, -remaining_credit_amount)
            //     partial_amount = min(partial_debit_amount, partial_credit_amount)
            // 
            //     # Prevent exchange differences if amounts are close enough to be a rounding issue
            //     # after applying the exchange rate and then, rounding amounts to store them into
            //     # the monetary fields.
            //     # Suppose 2 lines:
            //     # l1: balance=377554.0, amount_currency=20000.0
            //     # l2: balance=-5314.62, amount_currency=-281.53
            //     # ... computing min_recon_amount = min(20000.0, 281.53) = 281.53 in foreign currency to reconcile.
            //     # The equivalent of 281.53 for l1 in company currency is 5314.64 that could be the result of rounding any value
            //     # between [5314.54, 5314.7300000000005]
            //     # ... considering the rate of 0.05297255491929631 and the rounding applied to reach this value.
            //     # For l2, it will be 5314.62 in the range [5314.53, 5314.71].
            //     #
            //     # ---------
            //     # | 5314.73         ---------       <- max amount
            //     # |                 5314.71  |
            //     # |                          |
            //     # | 5314.64                  |
            //     # |                 5314.62  |      Every number between the min and the max are considered as valid to be the partial amount.
            //     # |                          |      Depending on the one we choose, we can avoid to create an exchange difference entry or
            //     # |                          |      we could also prevent to let an unnecessary open residual amount.
            //     # | 5314.54                  |
            //     # ---------         5314.53  |      <- min amount
            //     #                   ---------
            //     if (
            //         company_currency.compare_amounts(partial_debit_amount, partial_credit_amount_range[2]) <= 0
            //         and company_currency.compare_amounts(partial_debit_amount, partial_credit_amount_range[0]) >= 0
            //         and company_currency.compare_amounts(partial_credit_amount, partial_debit_amount_range[2]) <= 0
            //         and company_currency.compare_amounts(partial_credit_amount, partial_debit_amount_range[0]) >= 0
            //     ):
            //         if debit_fully_matched:
            //             partial_amount = remaining_debit_amount
            //         else:
            //             partial_amount = -remaining_credit_amount
            //         partial_debit_amount = partial_amount
            //         partial_credit_amount = partial_amount
            // 
            //     # Compute the partial amount expressed in foreign currency.
            //     # Take care to handle the case when a line expressed in company currency is mimicking the foreign
            //     # currency of the opposite line.
            //     if debit_currency == company_currency:
            //         partial_debit_amount_currency = partial_amount
            //     else:
            //         partial_debit_amount_currency = min_recon_amount
            //     if credit_currency == company_currency:
            //         partial_credit_amount_currency = partial_amount
            //     else:
            //         partial_credit_amount_currency = min_recon_amount
            // 
            // # Computation of the partial exchange difference. You can skip this part using the
            // # `no_exchange_difference` context key (when reconciling an exchange difference for example).
            // if not self._context.get('no_exchange_difference') and not self._context.get('no_exchange_difference_no_recursive'):
            //     exchange_lines_to_fix = self.env['account.move.line']
            //     amounts_list = []
            //     if recon_currency == company_currency:
            //         if debit_fully_matched:
            //             debit_exchange_amount = remaining_debit_amount_curr - partial_debit_amount_currency
            //             if not debit_currency.is_zero(debit_exchange_amount):
            //                 exchange_lines_to_fix += debit_aml
            //                 amounts_list.append({'amount_residual_currency': debit_exchange_amount})
            //                 remaining_debit_amount_curr -= debit_exchange_amount
            //         if credit_fully_matched:
            //             credit_exchange_amount = remaining_credit_amount_curr + partial_credit_amount_currency
            //             if not credit_currency.is_zero(credit_exchange_amount):
            //                 exchange_lines_to_fix += credit_aml
            //                 amounts_list.append({'amount_residual_currency': credit_exchange_amount})
            //                 remaining_credit_amount_curr += credit_exchange_amount
            // 
            //     else:
            //         if debit_fully_matched:
            //             # Create an exchange difference on the remaining amount expressed in company's currency.
            //             debit_exchange_amount = remaining_debit_amount - partial_amount
            //             if not company_currency.is_zero(debit_exchange_amount):
            //                 exchange_lines_to_fix += debit_aml
            //                 amounts_list.append({'amount_residual': debit_exchange_amount})
            //                 remaining_debit_amount -= debit_exchange_amount
            //                 if debit_currency == company_currency:
            //                     remaining_debit_amount_curr -= debit_exchange_amount
            //         else:
            //             # Create an exchange difference ensuring the rate between the residual amounts expressed in
            //             # both foreign and company's currency is still consistent regarding the rate between
            //             # 'amount_currency' & 'balance'.
            //             debit_exchange_amount = partial_debit_amount - partial_amount
            //             if company_currency.compare_amounts(debit_exchange_amount, 0.0) > 0:
            //                 exchange_lines_to_fix += debit_aml
            //                 amounts_list.append({'amount_residual': debit_exchange_amount})
            //                 remaining_debit_amount -= debit_exchange_amount
            //                 if debit_currency == company_currency:
            //                     remaining_debit_amount_curr -= debit_exchange_amount
            // 
            //         if credit_fully_matched:
            //             # Create an exchange difference on the remaining amount expressed in company's currency.
            //             credit_exchange_amount = remaining_credit_amount + partial_amount
            //             if not company_currency.is_zero(credit_exchange_amount):
            //                 exchange_lines_to_fix += credit_aml
            //                 amounts_list.append({'amount_residual': credit_exchange_amount})
            //                 remaining_credit_amount -= credit_exchange_amount
            //                 if credit_currency == company_currency:
            //                     remaining_credit_amount_curr -= credit_exchange_amount
            //         else:
            //             # Create an exchange difference ensuring the rate between the residual amounts expressed in
            //             # both foreign and company's currency is still consistent regarding the rate between
            //             # 'amount_currency' & 'balance'.
            //             credit_exchange_amount = partial_amount - partial_credit_amount
            //             if company_currency.compare_amounts(credit_exchange_amount, 0.0) < 0:
            //                 exchange_lines_to_fix += credit_aml
            //                 amounts_list.append({'amount_residual': credit_exchange_amount})
            //                 remaining_credit_amount -= credit_exchange_amount
            //                 if credit_currency == company_currency:
            //                     remaining_credit_amount_curr -= credit_exchange_amount
            // 
            //     if exchange_lines_to_fix:
            //         res['exchange_values'] = exchange_lines_to_fix._prepare_exchange_difference_move_vals(
            //             amounts_list,
            //             exchange_date=max(
            //                 debit_aml._get_reconciliation_aml_field_value('date', shadowed_aml_values),
            //                 credit_aml._get_reconciliation_aml_field_value('date', shadowed_aml_values),
            //             ),
            //         )
            // 
            // # ==== Create partials ====
            // 
            // remaining_debit_amount -= partial_amount
            // remaining_credit_amount += partial_amount
            // remaining_debit_amount_curr -= partial_debit_amount_currency
            // remaining_credit_amount_curr += partial_credit_amount_currency
            // 
            // res['partial_values'] = {
            //     'amount': partial_amount,
            //     'debit_amount_currency': partial_debit_amount_currency,
            //     'credit_amount_currency': partial_credit_amount_currency,
            //     'debit_move_id': debit_aml.id,
            //     'credit_move_id': credit_aml.id,
            // }
            // 
            // debit_values['amount_residual'] = remaining_debit_amount
            // debit_values['amount_residual_currency'] = remaining_debit_amount_curr
            // credit_values['amount_residual'] = remaining_credit_amount
            // credit_values['amount_residual_currency'] = remaining_credit_amount_curr
            // 
            // if (
            //     debit_currency.is_zero(debit_values['amount_residual_currency'])
            //     and company_currency.is_zero(debit_values['amount_residual'])
            // ):
            //     res['debit_values'] = None
            // if (
            //     credit_currency.is_zero(credit_values['amount_residual_currency'])
            //     and company_currency.is_zero(credit_values['amount_residual'])
            // ):
            //     res['credit_values'] = None
            // return res
            */
            return default;
        }

        public async Task<TEntity> PreventAutomaticLineDeletionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _prevent_automatic_line_deletion(self):
            // if not self.env.context.get('dynamic_unlink'):
            //     for line in self:
            //         if line.display_type == 'tax' and line.move_id.line_ids.tax_ids:
            //             raise ValidationError(_(
            //                 "You cannot delete a tax line as it would impact the tax report"
            //             ))
            //         elif line.display_type == 'payment_term':
            //             raise ValidationError(_(
            //                 "You cannot delete a payable/receivable line as it would not be consistent "
            //                 "with the payment terms"
            //             ))
            */
            return default;
        }

        public async Task<TEntity> ProductIdChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _product_id_change(self):
            // if not self.product_id:
            //     return
            // 
            // self.product_uom = self.product_id.uom_po_id or self.product_id.uom_id
            // product_lang = self.product_id.with_context(
            //     lang=get_lang(self.env, self.partner_id.lang).code,
            //     partner_id=None,
            //     company_id=self.company_id.id,
            // )
            // self.name = self._get_product_purchase_description(product_lang)
            // 
            // self._compute_tax_id()
            */
            return default;
        }

        public async Task<TEntity> QueryAnalyticAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object table) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _query_analytic_accounts(self, table=False):
            // return SQL(
            //     r"""regexp_split_to_array(jsonb_path_query_array(%s, '$.keyvalue()."key"')::text, '\D+')""",
            //     self._field_to_sql(table or self._table, 'analytic_distribution'),
            // )
            */
            return default;
        }

        public async Task<TEntity> ReadGroupAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object groupby, object offset, object limit, object @orderby, object lazy) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def read_group(self, domain, fields, groupby, offset=0, limit=None, orderby=False, lazy=True):
            // # Hide total amount_currency from read_group when view is not grouped by currency_id. Avoids mix of currencies
            // res = super().read_group(domain, fields, groupby, offset=offset, limit=limit, orderby=orderby, lazy=lazy)
            // if 'currency_id' not in groupby and 'amount_currency:sum' in fields:
            //     for group_line in res:
            //         group_line['amount_currency'] = False
            // return res
            */
            return default;
        }

        public async Task<object> ReadGroupGroupbyInternalAsync<TEntity>(IEnumerable<TEntity> entities, string groupby_spec, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _read_group_groupby(self, groupby_spec: str, query: Query) -> SQL:
            // """To group by `analytic_distribution`, we first need to separate the analytic_ids and associate them with the ids to be counted
            // Do note that only '__count' can be passed in the `aggregates`"""
            // if groupby_spec == 'analytic_distribution':
            //     query._tables = {
            //         'distribution': SQL(
            //             r"""(SELECT DISTINCT %s, (regexp_matches(jsonb_object_keys(%s), '\d+', 'g'))[1]::int AS account_id FROM %s WHERE %s)""",
            //             self._get_count_id(query),
            //             self._field_to_sql(self._table, 'analytic_distribution', query),
            //             query.from_clause,
            //             query.where_clause,
            //         )
            //     }
            // 
            //     # After using the from and where clauses in the nested query, they are no longer needed in the main one
            //     query._joins = {}
            //     query._where_clauses = []
            //     return SQL("account_id")
            // 
            // return super()._read_group_groupby(groupby_spec, query)
            */
            return default;
        }

        public async Task<object> ReadGroupSelectInternalAsync<TEntity>(IEnumerable<TEntity> entities, string aggregate_spec, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _read_group_select(self, aggregate_spec: str, query: Query) -> SQL:
            // if query.table == 'distribution' and aggregate_spec != '__count':
            //     raise ValueError(f"analytic_distribution grouping does not accept {aggregate_spec} as aggregate.")
            // return super()._read_group_select(aggregate_spec, query)
            */
            return default;
        }

        public async Task<TEntity> ReconcileAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def reconcile(self):
            // """ Reconcile the current move lines all together. """
            // return self._reconcile_plan([self])
            */
            return default;
        }

        public async Task<TEntity> ReconcileMarkedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_marked(self):
            // """Process the pending reconciliation of entries marked (i.e. uring imports).
            // 
            // The entries can be marked using the string `I*` as matching number where `*` can be anything.
            // Once all the entries using identical numbers are posted, this function proceeds to do the real matching.
            // """
            // temp_numbers = list({
            //     line.matching_number
            //     for line in self
            //     if line.matching_number and line.matching_number.startswith('I')
            // })
            // if temp_numbers:
            //     for _matching_number, account, lines in self._read_group(
            //         domain=[('matching_number', 'in', temp_numbers)],
            //         groupby=['matching_number', 'account_id'],
            //         aggregates=['id:recordset'],
            //     ):
            //         if all(move.state == 'posted' for move in lines.move_id):
            //             if not account.reconcile:
            //                 _logger.info("%s has reconciled lines, changing the config", account.display_name)
            //                 account.reconcile = True
            //             lines.with_context(no_exchange_difference=True, no_cash_basis=True).reconcile()
            */
            return default;
        }

        public async Task<TEntity> ReconcilePlanInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reconciliation_plan) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_plan(self, reconciliation_plan):
            // """ Reconcile the amls following the reconciliation plan.
            // The plan passed as parameter is a list of either a recordset of amls, either another plan.
            // 
            // For example:
            // [account.move.line(1, 2), account.move.line(3, 4)] means:
            // - account.move.line(1, 2) will be reconciled first.
            // - account.move.line(3, 4) will be reconciled after.
            // 
            // [[account.move.line(1, 2), account.move.line(3, 4)]] means:
            // - account.move.line(1, 2) will be reconciled first.
            // - account.move.line(3, 4) will be reconciled after.
            // - account.move.line(1, 2, 3, 4).filtered(lambda x: not x.reconciled) will be reconciled at the end.
            // 
            // :param reconciliation_plan: A list of reconciliation to perform.
            // """
            // # ==== Prepare the reconciliation ====
            // # Batch the amls all together to know what should be reconciled and when.
            // plan_list, all_amls = self._optimize_reconciliation_plan(reconciliation_plan)
            // move_container = {'records': all_amls.move_id}
            // with all_amls.move_id._check_balanced(move_container),\
            //      all_amls.move_id._sync_dynamic_lines(move_container):
            //     self._reconcile_plan_with_sync(plan_list, all_amls)
            */
            return default;
        }

        public async Task<TEntity> ReconcilePlanWithSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan_list, object all_amls) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_plan_with_sync(self, plan_list, all_amls):
            // # Parameter allowing to disable the exchange journal entries on partials.
            // disable_partial_exchange_diff = bool(self.env['ir.config_parameter'].sudo().get_param('account.disable_partial_exchange_diff'))
            // 
            // # ==== Prefetch the fields all at once to speedup the reconciliation ====
            // # All of those fields will be cached by the orm. Since the amls are split into multiple batches, the orm is not
            // # able to prefetch the data for all of them at once. For that reason, we force the orm to populate the cache
            // # before doing anything.
            // all_amls.move_id
            // all_amls.matched_debit_ids
            // all_amls.matched_credit_ids
            // 
            // # ==== Track the invoice's state to call the hook when they become paid ====
            // pre_hook_data = all_amls._reconcile_pre_hook()
            // 
            // # ==== Collect amls data ====
            // # All residual amounts are collected and updated until the creation of partials in batch.
            // # This is done that way to minimize the orm time for fields invalidation/mark as recompute and
            // # recomputation.
            // aml_values_map = {
            //     aml: {
            //         'aml': aml,
            //         'amount_residual': aml.amount_residual,
            //         'amount_residual_currency': aml.amount_residual_currency,
            //     }
            //     for aml in all_amls
            // }
            // 
            // # ==== Prepare the partials ====
            // partials_values_list = []
            // exchange_diff_values_list = []
            // exchange_diff_partial_index = []
            // all_plan_results = []
            // partial_index = 0
            // for plan in plan_list:
            //     plan_results = self\
            //         .with_context(
            //             no_exchange_difference=self._context.get('no_exchange_difference') or disable_partial_exchange_diff,
            //             no_exchange_difference_no_recursive=self._context.get('no_exchange_difference_no_recursive', False),
            //         )\
            //         ._prepare_reconciliation_plan(plan, aml_values_map)
            //     all_plan_results.append(plan_results)
            //     for results in plan_results:
            //         partials_values_list.append(results['partial_values'])
            //         if results.get('exchange_values') and results['exchange_values']['move_values']['line_ids']:
            //             exchange_diff_values_list.append(results['exchange_values'])
            //             exchange_diff_partial_index.append(partial_index)
            //             partial_index += 1
            // 
            // # ==== Create the partials ====
            // # Link the newly created partials to the plan. There are needed later for caba exchange entries.
            // partials = self.env['account.partial.reconcile'].create(partials_values_list)
            // start_range = 0
            // for plan_results, plan in zip(all_plan_results, plan_list):
            //     size = len(plan_results)
            //     plan['partials'] = partials[start_range:start_range + size]
            //     start_range += size
            // 
            // # ==== Create the partial exchange journal entries ====
            // exchange_moves = self._create_exchange_difference_moves(exchange_diff_values_list)
            // for index, exchange_move in zip(exchange_diff_partial_index, exchange_moves):
            //     partials[index].exchange_move_id = exchange_move
            // 
            // # ==== Create entries for cash basis taxes ====
            // def is_cash_basis_needed(amls):
            //     return any(amls.company_id.mapped('tax_exigibility')) \
            //         and amls.account_id.account_type in ('asset_receivable', 'liability_payable')
            // 
            // if not self._context.get('move_reverse_cancel') and not self._context.get('no_cash_basis'):
            //     for plan in plan_list:
            //         if is_cash_basis_needed(plan['amls']):
            //             plan['partials'].with_context(no_exchange_difference_no_recursive=False)._create_tax_cash_basis_moves()
            // 
            // # ==== Prepare full reconcile creation ====
            // # First, we need to find all sub-set of amls that are candidates for a full.
            // 
            // def is_line_reconciled(aml, has_multiple_currencies):
            //     # Check if the journal item passed as parameter is now fully reconciled.
            //     if aml.reconciled:
            //         return True
            //     if not aml.matched_debit_ids and not aml.matched_credit_ids:
            //         # Suppose a journal item having balance = 0 but an amount_currency like an exchange difference.
            //         return False
            //     if has_multiple_currencies:
            //         return aml.company_currency_id.is_zero(aml.amount_residual)
            //     else:
            //         return aml.currency_id.is_zero(aml.amount_residual_currency)
            // 
            // full_batches = []
            // all_aml_ids = set()
            // number2lines = all_amls._reconciled_by_number()
            // for plan in plan_list:
            //     for aml in plan['amls']:
            //         if 'full_batch_index' in aml_values_map[aml]:
            //             continue
            // 
            //         involved_amls = plan['amls']._filter_reconciled_by_number(number2lines)
            //         all_aml_ids.update(involved_amls.ids)
            //         full_batch_index = len(full_batches)
            //         has_multiple_currencies = len(involved_amls.currency_id) > 1
            //         is_fully_reconciled = all(
            //             is_line_reconciled(involved_aml, has_multiple_currencies)
            //             for involved_aml in involved_amls
            //         )
            //         full_batches.append({
            //             'amls': involved_amls,
            //             'is_fully_reconciled': is_fully_reconciled,
            //         })
            //         for involved_aml in involved_amls:
            //             if aml_values_map.get(involved_aml):
            //                 aml_values_map[involved_aml]['full_batch_index'] = full_batch_index
            // 
            // # ==== Prefetch the fields all at once to speedup the reconciliation ====
            // # Again, we do the same optimization for the prefetching. We need to do it again since most of the values have
            // # been invalidated with the creation of the account.partial.reconcile records.
            // all_amls = self.browse(list(all_aml_ids))
            // all_amls.move_id
            // all_amls.matched_debit_ids
            // all_amls.matched_credit_ids
            // 
            // # ==== Prepare the full exchange journal entries ====
            // # This part could be bypassed using the 'no_exchange_difference' key inside the context. This is useful
            // # when importing a full accounting including the reconciliation like Winbooks.
            // 
            // exchange_diff_values_list = []
            // exchange_diff_full_batch_index = []
            // if not self._context.get('no_exchange_difference'):
            //     for full_batch_index, full_batch in enumerate(full_batches):
            //         involved_amls = full_batch['amls']
            //         if not full_batch['is_fully_reconciled']:
            //             continue
            // 
            //         # In normal cases, the exchange differences are already generated by the partial at this point meaning
            //         # there is no journal item left with a zero amount residual in one currency but not in the other.
            //         # However, after a migration coming from an older version with an older partial reconciliation or due to
            //         # some rounding issues (when dealing with different decimal places for example), we could need an extra
            //         # exchange difference journal entry to handle them.
            //         exchange_lines_to_fix = self.env['account.move.line']
            //         amounts_list = []
            //         exchange_max_date = date.min
            //         for aml in involved_amls:
            //             if not aml.company_currency_id.is_zero(aml.amount_residual):
            //                 exchange_lines_to_fix += aml
            //                 amounts_list.append({'amount_residual': aml.amount_residual})
            //             elif not aml.currency_id.is_zero(aml.amount_residual_currency):
            //                 exchange_lines_to_fix += aml
            //                 amounts_list.append({'amount_residual_currency': aml.amount_residual_currency})
            //             exchange_max_date = max(exchange_max_date, aml.date)
            //         exchange_diff_values = exchange_lines_to_fix._prepare_exchange_difference_move_vals(
            //             amounts_list,
            //             company=involved_amls.company_id,
            //             exchange_date=exchange_max_date,
            //         )
            // 
            //         # Exchange difference for cash basis entries.
            //         # If we are fully reversing the entry, no need to fix anything since the journal entry
            //         # is exactly the mirror of the source journal entry.
            //         caba_lines_to_reconcile = None
            //         if is_cash_basis_needed(involved_amls) and not self._context.get('move_reverse_cancel') and not self._context.get('no_cash_basis'):
            //             caba_lines_to_reconcile = involved_amls._add_exchange_difference_cash_basis_vals(exchange_diff_values)
            // 
            //         # Prepare the exchange difference.
            //         if exchange_diff_values['move_values']['line_ids']:
            //             exchange_diff_full_batch_index.append(full_batch_index)
            //             exchange_diff_values_list.append(exchange_diff_values)
            //             full_batch['caba_lines_to_reconcile'] = caba_lines_to_reconcile
            // 
            // # ==== Create the full exchange journal entries ====
            // exchange_moves = self._create_exchange_difference_moves(exchange_diff_values_list)
            // for full_batch_index, exchange_move in zip(exchange_diff_full_batch_index, exchange_moves):
            //     full_batch = full_batches[full_batch_index]
            //     amls = full_batch['amls']
            //     full_batch['exchange_move'] = exchange_move
            //     exchange_move_lines = exchange_move.line_ids.filtered(lambda line: line.account_id == amls.account_id)
            //     full_batch['amls'] |= exchange_move_lines
            // 
            // # ==== Create the full reconcile ====
            // # Note we are using Command.link and not Command.set because Command.set is triggering an unlink that is
            // # slowing down the assignation of the co-fields. Indeed, unlink is forcing a flush.
            // full_reconcile_values_list = []
            // full_reconcile_full_batch_index = []
            // for full_batch_index, full_batch in enumerate(full_batches):
            //     amls = full_batch['amls']
            //     involved_partials = amls.matched_debit_ids + amls.matched_credit_ids
            //     if full_batch['is_fully_reconciled']:
            //         full_reconcile_values_list.append({
            //             'exchange_move_id': full_batch.get('exchange_move') and full_batch['exchange_move'].id,
            //             'partial_reconcile_ids': [Command.link(partial.id) for partial in involved_partials],
            //             'reconciled_line_ids': [Command.link(aml.id) for aml in amls],
            //         })
            //         full_reconcile_full_batch_index.append(full_batch_index)
            // 
            // self.env['account.full.reconcile'].create(full_reconcile_values_list)
            // 
            // # === Cash basis rounding autoreconciliation ===
            // # In case a cash basis rounding difference line got created for the transition account, we reconcile it with the corresponding lines
            // # on the cash basis moves (so that it reaches full reconciliation and creates an exchange difference entry for this account as well)
            // for full_batch in full_batches:
            //     if not full_batch.get('caba_lines_to_reconcile'):
            //         continue
            // 
            //     caba_lines_to_reconcile = full_batch['caba_lines_to_reconcile']
            //     exchange_move = full_batch['exchange_move']
            //     for (dummy, account, repartition_line), amls_to_reconcile in caba_lines_to_reconcile.items():
            //         if not account.reconcile:
            //             continue
            // 
            //         exchange_line = exchange_move.line_ids.filtered(
            //             lambda l: l.account_id == account and l.tax_repartition_line_id == repartition_line
            //         )
            // 
            //         (exchange_line + amls_to_reconcile)\
            //             .filtered(lambda l: not l.reconciled)\
            //             .reconcile()
            // 
            // all_amls._reconcile_post_hook(pre_hook_data)
            */
            return default;
        }

        public async Task<TEntity> ReconcilePostHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_post_hook(self, data):
            // (
            //     data['not_paid_invoices'].filtered(lambda inv: inv.payment_state in ('paid', 'in_payment'))
            //     + data['in_payment_invoices'].filtered(lambda inv: inv.payment_state == 'paid')
            // )._invoice_paid_hook()
            */
            return default;
        }

        public async Task<TEntity> ReconcilePreHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconcile_pre_hook(self):
            // invoices = self.move_id.filtered(lambda move: move.is_invoice(include_receipts=True))
            // return {
            //     'not_paid_invoices': invoices.filtered(lambda inv: inv.payment_state not in ('paid', 'in_payment')),
            //     'in_payment_invoices': invoices.filtered(lambda inv: inv.payment_state == 'in_payment'),
            // }
            */
            return default;
        }

        public async Task<Dictionary<string, object>> ReconciledByNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconciled_by_number(self) -> dict:
            // """Get the mapping of all the lines matched with the lines in self grouped by matching number."""
            // matching_numbers = [n for n in set(self.mapped('matching_number')) if n]
            // if matching_numbers:
            //     return dict(self._read_group(
            //         domain=[('matching_number', 'in', matching_numbers)],
            //         groupby=['matching_number'],
            //         aggregates=['id:recordset'],
            //     ))
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ReconciledLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _reconciled_lines(self):
            // ids = []
            // for aml in self.filtered('reconciled'):
            //     ids.extend([r.debit_move_id.id for r in aml.matched_debit_ids] if aml.credit > 0 else [r.credit_move_id.id for r in aml.matched_credit_ids])
            //     ids.append(aml.id)
            // return ids
            */
            return default;
        }

        public async Task<TEntity> RelatedAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _related_analytic_distribution(self):
            // """ Returns the analytic distribution set on the record which triggered the creation of this line. """
            // return {}
            */
            return default;
        }

        public async Task<TEntity> RemoveMoveReconcileAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def remove_move_reconcile(self):
            // """ Undo a reconciliation """
            // (self.matched_debit_ids + self.matched_credit_ids).unlink()
            */
            return default;
        }

        public async Task<TEntity> ResetPriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _reset_price_unit(self):
            // self.ensure_one()
            // 
            // line = self.with_company(self.company_id)
            // price = line._get_display_price()
            // product_taxes = line.product_id.taxes_id._filter_taxes_by_company(line.company_id)
            // price_unit = line.product_id._get_tax_included_unit_price_from_price(
            //     price,
            //     product_taxes=product_taxes,
            //     fiscal_position=line.order_id.fiscal_position_id,
            // )
            // line.update({
            //     'price_unit': price_unit,
            //     'technical_price_unit': price_unit,
            // })
            */
            return default;
        }

        public async Task<TEntity> ReturnDisposalViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> move_ids) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def _return_disposal_view(self, move_ids):
            // name = _('Disposal Move')
            // view_mode = 'form'
            // if len(move_ids) > 1:
            //     name = _('Disposal Moves')
            //     view_mode = 'tree,form'
            // return {
            //     'name': name,
            //     'view_type': 'form',
            //     'view_mode': view_mode,
            //     'res_model': 'account.move',
            //     'type': 'ir.actions.act_window',
            //     'target': 'current',
            //     'res_id': move_ids[0],
            // }
            */
            return default;
        }

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _sanitize_vals(self, vals):
            // if 'debit' in vals or 'credit' in vals:
            //     vals = vals.copy()
            //     if 'balance' in vals:
            //         vals.pop('debit', None)
            //         vals.pop('credit', None)
            //     else:
            //         vals['balance'] = vals.pop('debit', 0) - vals.pop('credit', 0)
            // if (
            //     vals.get('matching_number')
            //     and not vals['matching_number'].startswith('I')
            //     and not self.env.context.get('skip_matching_number_check')
            // ):
            //     vals['matching_number'] = f"I{vals['matching_number']}"
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> SanitizeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object decimal_precision) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _sanitize_values(self, vals, decimal_precision):
            // """ Normalize the float of the distribution """
            // if 'analytic_distribution' in vals:
            //     vals['analytic_distribution'] = vals.get('analytic_distribution') and {
            //         account_id: float_round(distribution, decimal_precision) for account_id, distribution in vals['analytic_distribution'].items()}
            // return vals
            */
            return default;
        }

        public async Task<TEntity> SearchDistributionAnalyticAccountIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _search_distribution_analytic_account_ids(self, operator, value):
            // return [('analytic_distribution', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // def to_tuple(t):
            //     return tuple(map(to_tuple, t)) if isinstance(t, (list, tuple)) else t
            // order = (order or self._order)
            // if not re.search(r'\bid\b', order):
            //     # Make an explicit order because we will need to reverse it
            //     order += ', id'
            // # Add the domain and order by in order to compute the cumulated balance in _compute_cumulated_balance
            // contextualized = self.with_context(
            //     domain_cumulated_balance=to_tuple(domain or []),
            //     order_cumulated_balance=order,
            // )
            // return super(AccountMoveLine, contextualized).search_fetch(domain, field_names, offset, limit, order)
            */
            return default;
        }

        public async Task<TEntity> SearchJournalGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _search_journal_group_id(self, operator, value):
            // field = 'name' if 'like' in operator else 'id'
            // journal_groups = self.env['account.journal.group'].search([(field, operator, value)])
            // return [('journal_id', 'not in', journal_groups.excluded_journal_ids.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchPanelDomainImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object domain, object set_count, object limit) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _search_panel_domain_image(self, field_name, domain, set_count=False, limit=False):
            // if field_name != 'account_root_id' or set_count:
            //     return super()._search_panel_domain_image(field_name, domain, set_count, limit)
            // 
            // # if domain is logically equivalent to false
            // if expression.is_false(self, domain):
            //     return {}
            // 
            // # Override in order to not read the complete move line table and use the index instead
            // query_account = self.env['account.account']._search([('company_ids', 'in', self.env.companies.ids), ('code', '!=', False)])
            // account_code_alias = self.env['account.account']._field_to_sql('account_account', 'code', query_account)
            // 
            // query_line = self._search(domain, limit=1)
            // query_line.add_where('account_account.id = account_move_line.account_id')
            // 
            // account_codes = self.env.execute_query(SQL(
            //     """
            //     SELECT %(account_code_alias)s AS code
            //       FROM %(account_table)s
            //      WHERE EXISTS(%(line_select)s)
            //        AND %(where_clause)s
            //     """,
            //     account_code_alias=account_code_alias,
            //     account_table=query_account.from_clause,
            //     line_select=query_line.select(),
            //     where_clause=query_account.where_clause,
            // ))
            // return {
            //     (root := self.env['account.root']._from_account_code(code)).id: {'id': root.id, 'display_name': root.display_name}
            //     for code, in account_codes
            // }
            */
            return default;
        }

        public async Task<TEntity> SearchPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _search_payment_date(self, operator, value):
            // if operator == '=':
            //     operator = '<='
            // return [
            //         '|',
            //         '|',
            //         '&', ('discount_date', '>=', str(date.today())), ('discount_date', operator, value),
            //         '&', ('discount_date', '<', str(date.today())), ('date_maturity', operator, value),
            //         '&', ('discount_date', '=', False), ('date_maturity', operator, value),
            //     ]
            */
            return default;
        }

        public async Task<TEntity> SearchProductTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _search_product_template_id(self, operator, value):
            // return [('product_id.product_tmpl_id', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SellableLinesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _sellable_lines_domain(self):
            // discount_products_ids = self.env.companies.sale_discount_product_id.ids
            // domain = [('is_downpayment', '=', False)]
            // if discount_products_ids:
            //     domain = expression.AND([
            //         domain,
            //         [('product_id', 'not in', discount_products_ids)],
            //     ])
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SendExpenseSuccessMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object expense) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _send_expense_success_mail(self, msg_dict, expense):
            // if expense.employee_id.user_id:
            //     mail_template_id = 'hr_expense.hr_expense_template_register'
            // else:
            //     mail_template_id = 'hr_expense.hr_expense_template_register_no_user'
            // rendered_body = self.env['ir.qweb']._render(mail_template_id, {'expense': expense})
            // body = self.env['mail.render.mixin']._replace_local_links(rendered_body)
            // if expense.employee_id.user_id.partner_id:
            //     expense.message_post(
            //         body=body,
            //         email_layout_xmlid='mail.mail_notification_light',
            //         partner_ids=expense.employee_id.user_id.partner_id.ids,
            //         subject=f'Re: {msg_dict.get("subject", "")}',
            //         subtype_xmlid='mail.mt_note',
            //     )
            // else:
            //     self.env['mail.mail'].sudo().create({
            //         'author_id': self.env.user.partner_id.id,
            //         'auto_delete': True,
            //         'body_html': body,
            //         'email_from': self.env.user.email_formatted,
            //         'email_to': msg_dict.get('email_from', False),
            //         'references': msg_dict.get('message_id'),
            //         'subject': f'Re: {msg_dict.get("subject", "")}',
            //     }).send()
            */
            return default;
        }

        public async Task<TEntity> SetAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object inv_line_vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _set_analytic_distribution(self, inv_line_vals, **optional_values):
            // if self.analytic_distribution and not self.display_type:
            //     inv_line_vals['analytic_distribution'] = self.analytic_distribution
            */
            return default;
        }

        public async Task<TEntity> SetExpenseCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_today) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _set_expense_currency_rate(self, date_today):
            // for expense in self:
            //     expense.currency_rate = expense.env['res.currency']._get_conversion_rate(
            //         from_currency=expense.currency_id,
            //         to_currency=expense.company_currency_id,
            //         company=expense.company_id,
            //         date=expense.date or date_today,
            //     )
            */
            return default;
        }

        public async Task<TEntity> SetToCloseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def set_to_close(self):
            // move_ids = self._get_disposal_moves()
            // if move_ids:
            //     return self._return_disposal_view(move_ids)
            // # Fallback, as if we just clicked on the smartbutton
            // return self.open_entries()
            */
            return default;
        }

        public async Task<TEntity> SetToDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def set_to_draft(self):
            // self.write({'state': 'draft'})
            */
            return default;
        }

        public async Task<TEntity> SuggestQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _suggest_quantity(self):
            // '''
            // Suggest a minimal quantity based on the seller
            // '''
            // if not self.product_id:
            //     return
            // seller_min_qty = self.product_id._select_seller(
            //     partner_id=self.order_id.partner_id,
            //     quantity=None,
            //     date=self.order_id.date_order and self.order_id.date_order.date() or fields.Date.context_today(self),
            //     params=self._get_select_sellers_params(),
            // )
            // if seller_min_qty:
            //     self.product_qty = seller_min_qty[0].min_qty or 1.0
            //     self.product_uom = seller_min_qty[0].product_uom
            // else:
            //     self.product_qty = 1.0
            */
            return default;
        }

        public async Task<TEntity> SyncInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _sync_invoice(self, container):
            // if container['records'].env.context.get('skip_invoice_line_sync'):
            //     yield
            //     return  # avoid infinite recursion
            // 
            // def existing():
            //     return {
            //         line: {
            //             'amount_currency': line.currency_id.round(line.amount_currency),
            //             'balance': line.company_id.currency_id.round(line.balance),
            //             'currency_rate': line.currency_rate,
            //             'price_subtotal': line.currency_id.round(line.price_subtotal),
            //             'move_type': line.move_id.move_type,
            //         } for line in container['records'].with_context(
            //             skip_invoice_line_sync=True,
            //         ).filtered(lambda l: l.move_id.is_invoice(True))
            //     }
            // 
            // def changed(fname):
            //     return line not in before or before[line][fname] != after[line][fname]
            // 
            // before = existing()
            // yield
            // after = existing()
            // for line in after:
            //     if (
            //         (changed('amount_currency') or changed('currency_rate') or changed('move_type'))
            //         and not self.env.is_protected(self._fields['balance'], line)
            //         and (not changed('balance') or (line not in before and not line.balance))
            //     ):
            //         balance = line.company_id.currency_id.round(line.amount_currency / line.currency_rate)
            //         line.balance = balance
            // 
            // # Since this method is called during the sync, inside of `create`/`write`, these fields
            // # already have been computed and marked as so. But this method should re-trigger it since
            // # it changes the dependencies.
            // self.env.add_to_compute(self._fields['debit'], container['records'])
            // self.env.add_to_compute(self._fields['credit'], container['records'])
            */
            return default;
        }

        public async Task<TEntity> TrackQtyReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_qty) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _track_qty_received(self, new_qty):
            // self.ensure_one()
            // # don't track anything when coming from the accrued expense entry wizard, as it is only computing fields at a past date to get relevant amounts
            // # and doesn't actually change anything to the current record
            // if  self.env.context.get('accrual_entry_date'):
            //     return
            // if new_qty != self.qty_received and self.order_id.state == 'purchase':
            //     self.order_id.message_post_with_source(
            //         'purchase.track_po_line_qty_received_template',
            //         render_values={'line': self, 'qty_received': new_qty},
            //         subtype_xmlid='mail.mt_note',
            //     )
            */
            return default;
        }

        public async Task<TEntity> UnblockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def unblock(self):
            // self.ensure_one()
            // if self.working_state != 'blocked':
            //     raise exceptions.UserError(_("It has already been unblocked."))
            // times = self.env['mrp.workcenter.productivity'].search([('workcenter_id', '=', self.id), ('date_end', '=', False)])
            // times.write({'date_end': datetime.now()})
            // return True
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def unlink(self):
            // if not self:
            //     return True
            // 
            // # Check the lines are not reconciled (partially or not).
            // self._check_reconciliation()
            // 
            // # Check the lock date. (Only relevant if the move is posted)
            // self.move_id.filtered(lambda m: m.state == 'posted')._check_fiscal_lock_dates()
            // 
            // # Check the tax lock date.
            // self._check_tax_lock_date()
            // 
            // if not self.env.context.get('tracking_disable'):
            //     # Log changes to move lines on each move
            //     tracked_fields = [fname for fname, f in self._fields.items() if hasattr(f, 'tracking') and f.tracking and not (hasattr(f, 'related') and f.related)]
            //     ref_fields = self.env['account.move.line'].fields_get(tracked_fields)
            //     empty_line = self.browse([False])  # all falsy fields but not failing `ensure_one` checks
            //     for move_id, modified_lines in self.grouped('move_id').items():
            //         if not move_id.posted_before:
            //             continue
            //         for line in modified_lines:
            //             if tracking_value_ids := empty_line._mail_track(ref_fields, line)[1]:
            //                 line.move_id._message_log(
            //                     body=_("Journal Item %s deleted", line._get_html_link(title=f"#{line.id}")),
            //                     tracking_value_ids=tracking_value_ids
            //                 )
            // 
            // move_container = {'records': self.move_id}
            // with self.move_id._check_balanced(move_container),\
            //      self.move_id._sync_dynamic_lines(move_container):
            //     res = super().unlink()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def unlink(self):
            // attachments_to_unlink = self.env['ir.attachment']
            // for sheet in self.sheet_id:
            //     checksums = set((sheet.expense_line_ids.attachment_ids & self.attachment_ids).mapped('checksum'))
            //     attachments_to_unlink += sheet.attachment_ids.filtered(lambda att: att.checksum in checksums)
            // attachments_to_unlink.with_context(sync_attachment=False).unlink()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def unlink(self):
            // to_unlink = self.filtered(lambda r: r.requisition_id.state not in ['draft', 'cancel', 'done'])
            // to_unlink.supplier_info_ids.unlink()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def unlink(self):
            // for asset in self:
            //     if asset.state in ['open', 'close']:
            //         raise UserError(_('You cannot delete a document that is in %s state.') % (asset.state,))
            //     for depreciation_line in asset.depreciation_line_ids:
            //         if depreciation_line.move_id:
            //             raise UserError(_('You cannot delete a document that contains posted entries.'))
            // return super(AccountAssetAsset, self).unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptConfirmedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _unlink_except_confirmed(self):
            // if self._check_line_unlink():
            //     raise UserError(_("Once a sales order is confirmed, you can't remove one of its lines (we need to track if something gets invoiced or delivered).\n\
            //         Set the quantity to 0 instead."))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptPostedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _unlink_except_posted(self):
            // # Prevent deleting lines on posted entries
            // if not self._context.get('force_delete') and any(m.state == 'posted' for m in self.move_id):
            //     raise UserError(_("You can't delete a posted journal item. Don’t play games with your accounting records; reset the journal entry to draft before deleting it."))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptPostedOrApprovedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _unlink_except_posted_or_approved(self):
            // for expense in self:
            //     if expense.state in {'done', 'approved'}:
            //         raise UserError(_('You cannot delete a posted or approved expense.'))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptPurchaseOrDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _unlink_except_purchase_or_done(self):
            // for line in self:
            //     if line.order_id.state in ['purchase', 'done'] and line.display_type not in ['line_note', 'line_section']:
            //         state_description = {state_desc[0]: state_desc[1] for state_desc in self._fields['state']._description_selection(self.env)}
            //         raise UserError(_('Cannot delete a purchase order line which is in state “%s”.', state_description.get(line.state)))
            */
            return default;
        }

        public async Task<TEntity> UpdateAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _update_analytic_distribution(self):
            // if self.env.context.get('skip_analytic_sync'):
            //     return
            // for line in self:
            //     line.with_context(skip_analytic_sync=True).analytic_distribution = {
            //         analytic_line._get_distribution_key(): -analytic_line.amount / line.balance * 100
            //         for analytic_line in line.analytic_line_ids
            //     }
            */
            return default;
        }

        public async Task<TEntity> UpdateDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _update_date_planned(self, updated_date):
            // self.date_planned = updated_date
            */
            return default;
        }

        public async Task<TEntity> UpdateLineQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _update_line_quantity(self, values):
            // orders = self.mapped('order_id')
            // for order in orders:
            //     order_lines = self.filtered(lambda x: x.order_id == order)
            //     msg = Markup("<b>%s</b><ul>") % _("The ordered quantity has been updated.")
            //     for line in order_lines:
            //         if 'product_id' in values and values['product_id'] != line.product_id.id:
            //             # tracking is meaningless if the product is changed as well.
            //             continue
            //         msg += Markup("<li> %s: <br/>") % line.product_id.display_name
            //         msg += _(
            //             "Ordered Quantity: %(old_qty)s -> %(new_qty)s",
            //             old_qty=line.product_uom_qty,
            //             new_qty=values["product_uom_qty"]
            //         ) + Markup("<br/>")
            //         if line.product_id.type == 'consu':
            //             msg += _("Delivered Quantity: %s", line.qty_delivered) + Markup("<br/>")
            //         msg += _("Invoiced Quantity: %s", line.qty_invoiced) + Markup("<br/>")
            //     msg += Markup("</ul>")
            //     order.message_post(body=msg)
            */
            return default;
        }

        public async Task<TEntity> ValidFieldParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object name) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _valid_field_parameter(self, field, name):
            // # EXTENDS models
            // return name == 'tracking' or super()._valid_field_parameter(field, name)
            */
            return default;
        }

        public async Task<TEntity> ValidateAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def _validate_amount(self):
            // for record in self:
            //     if record.amount_type == 'fixed' and record.amount == 0:
            //         raise UserError(_("The amount is not a number"))
            //     if record.amount_type == 'percentage_st_line' and record.amount == 0:
            //         raise UserError(_("Balance percentage can't be 0"))
            //     if record.amount_type == 'percentage' and record.amount == 0:
            //         raise UserError(_("Statement line percentage can't be 0"))
            //     if record.amount_type == 'regex':
            //         try:
            //             re.compile(record.amount_string)
            //         except re.error:
            //             raise UserError(_('The regex is not valid'))
            */
            return default;
        }

        public async Task<TEntity> ValidateAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _validate_analytic_distribution(self):
            // lines_with_missing_analytic_distribution = self.env['account.move.line']
            // for line in self.filtered(lambda line: line.display_type == 'product'):
            //     try:
            //         line._validate_distribution(
            //             company_id=line.company_id.id,
            //             product=line.product_id.id,
            //             account=line.account_id.id,
            //             business_domain=(
            //                 'invoice' if line.move_id.is_sale_document(True)
            //                 else 'bill' if line.move_id.is_purchase_document(True)
            //                 else 'general'
            //             ),
            //         )
            //     except ValidationError:
            //         lines_with_missing_analytic_distribution += line
            // if lines_with_missing_analytic_distribution:
            //     msg = _("One or more lines require a 100% analytic distribution.")
            //     if len(self.move_id) == 1:
            //         raise ValidationError(msg)
            //     raise RedirectWarning(
            //         message=msg,
            //         action={
            //             'view_mode': 'list',
            //             'name': _('Items With Missing Analytic Distribution'),
            //             'res_model': 'account.move.line',
            //             'type': 'ir.actions.act_window',
            //             'domain': [('id', 'in', lines_with_missing_analytic_distribution.ids)],
            //             'views': [(self.env.ref('account.view_move_line_tree').id, 'list')],
            //         },
            //         button_text=_("See items"),
            //     )
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _validate_analytic_distribution(self):
            // for line in self:
            //     if line.display_type:
            //         continue
            //     line._validate_distribution(
            //         product=line.product_id.id,
            //         business_domain='purchase_order',
            //         company_id=line.company_id.id,
            //     )
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _validate_analytic_distribution(self):
            // for line in self.filtered(lambda l: not l.display_type and l.state in ['draft', 'sent']):
            //     line._validate_distribution(**{
            //         'product': line.product_id.id,
            //         'business_domain': 'sale_order',
            //         'company_id': line.company_id.id,
            //     })
            */
            return default;
        }

        public async Task<TEntity> ValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def validate(self):
            // self.write({'state': 'open'})
            // fields = [
            //     'method',
            //     'method_number',
            //     'method_period',
            //     'method_end',
            //     'method_progress_factor',
            //     'method_time',
            //     'salvage_value',
            //     'invoice_id',
            // ]
            // ref_tracked_fields = self.env['account.asset.asset'].fields_get(fields)
            // for asset in self:
            //     tracked_fields = ref_tracked_fields.copy()
            //     if asset.method == 'linear':
            //         del(tracked_fields['method_progress_factor'])
            //     if asset.method_time != 'end':
            //         del(tracked_fields['method_end'])
            //     else:
            //         del(tracked_fields['method_number'])
            //     dummy, tracking_value_ids = asset._mail_track(tracked_fields, dict.fromkeys(fields))
            //     asset.message_post(subject=_('Asset created'), tracking_value_ids=tracking_value_ids)
            */
            return default;
        }

        public async Task<TEntity> ValidateDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _validate_distribution(self, **kwargs):
            // if self.env.context.get('validate_analytic', False):
            //     mandatory_plans_ids = [plan['id'] for plan in self.env['account.analytic.plan'].sudo().with_company(self.company_id).get_relevant_plans(**kwargs) if plan['applicability'] == 'mandatory']
            //     if not mandatory_plans_ids:
            //         return
            //     decimal_precision = self.env['decimal.precision'].precision_get('Percentage Analytic')
            //     distribution_by_root_plan = {}
            //     for analytic_account_ids, percentage in (self.analytic_distribution or {}).items():
            //         for analytic_account in self.env['account.analytic.account'].browse(map(int, analytic_account_ids.split(","))).exists():
            //             root_plan = analytic_account.root_plan_id
            //             distribution_by_root_plan[root_plan.id] = distribution_by_root_plan.get(root_plan.id, 0) + percentage
            // 
            //     for plan_id in mandatory_plans_ids:
            //         if float_compare(distribution_by_root_plan.get(plan_id, 0), 100, precision_digits=decimal_precision) != 0:
            //             raise ValidationError(_("One or more lines require a 100% analytic distribution."))
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def write(self, vals):
            // if not vals:
            //     return True
            // protected_fields = self._get_lock_date_protected_fields()
            // account_to_write = self.env['account.account'].browse(vals['account_id']) if 'account_id' in vals else None
            // 
            // # Check writing a deprecated account.
            // if account_to_write and account_to_write.deprecated:
            //     raise UserError(_('You cannot use a deprecated account.'))
            // 
            // inalterable_fields = set(self._get_integrity_hash_fields()).union({'inalterable_hash'})
            // hashed_moves = self.move_id.filtered('inalterable_hash')
            // violated_fields = set(vals) & inalterable_fields
            // if hashed_moves and violated_fields:
            //     raise UserError(_(
            //         "You cannot edit the following fields: %(fields)s.\n"
            //         "The following entries are already hashed:\n%(entries)s",
            //         fields=format_list(self.env, [f['string'] for f in self.fields_get(violated_fields).values()]),
            //         entries='\n'.join(hashed_moves.mapped('name')),
            //     ))
            // 
            // line_to_write = self
            // vals = self._sanitize_vals(vals)
            // matching2lines = None
            // for line in self:
            //     if not any(self.env['account.move']._field_will_change(line, vals, field_name) for field_name in vals):
            //         line_to_write -= line
            //         continue
            // 
            //     if line.parent_state == 'posted' and any(self.env['account.move']._field_will_change(line, vals, field_name) for field_name in ('tax_ids', 'tax_line_id')):
            //         raise UserError(_('You cannot modify the taxes related to a posted journal item, you should reset the journal entry to draft to do so.'))
            // 
            //     # Check the lock date.
            //     if line.parent_state == 'posted' and any(self.env['account.move']._field_will_change(line, vals, field_name) for field_name in protected_fields['fiscal']):
            //         line.move_id._check_fiscal_lock_dates()
            // 
            //     # Check the tax lock date.
            //     if line.parent_state == 'posted' and any(self.env['account.move']._field_will_change(line, vals, field_name) for field_name in protected_fields['tax']):
            //         line._check_tax_lock_date()
            // 
            //     # Check the reconciliation.
            //     if changing_fields := {
            //         field_name
            //         for field_name in protected_fields['reconciliation']
            //         if self.env['account.move']._field_will_change(line, vals, field_name)
            //     }:
            //         matching2lines = dict(self.env['account.move.line'].sudo()._read_group(
            //             domain=[('matching_number', 'in', [n for n in self.mapped('matching_number') if n])],
            //             groupby=['matching_number'],
            //             aggregates=['id:recordset']
            //         )) if matching2lines is None and line.matching_number else matching2lines
            //         if (
            //             # allow changing the account on all the lines of a reconciliation together
            //             changing_fields - {'account_id'}
            //             or line.matching_number and not all(reconciled_line in self for reconciled_line in matching2lines[line.matching_number])
            //         ):
            //             line._check_reconciliation()
            // 
            // move_container = {'records': self.move_id}
            // with self.move_id._check_balanced(move_container),\
            //      self.env.protecting(self.env['account.move']._get_protected_vals(vals, self)),\
            //      self.move_id._sync_dynamic_lines(move_container),\
            //      self._sync_invoice({'records': self}):
            //     self = line_to_write
            //     if not self:
            //         return True
            //     # Tracking stuff can be skipped for perfs using tracking_disable context key
            //     if not self.env.context.get('tracking_disable', False):
            //         # Get all tracked fields (without related fields because these fields must be manage on their own model)
            //         tracking_fields = []
            //         for value in vals:
            //             field = self._fields[value]
            //             if hasattr(field, 'related') and field.related:
            //                 continue # We don't want to track related field.
            //             if hasattr(field, 'tracking') and field.tracking:
            //                 tracking_fields.append(value)
            //         ref_fields = self.env['account.move.line'].fields_get(tracking_fields)
            // 
            //         # Get initial values for each line
            //         move_initial_values = {}
            //         for line in self.filtered(lambda l: l.move_id.posted_before): # Only lines with posted once move.
            //             for field in tracking_fields:
            //                 # Group initial values by move_id
            //                 if line.move_id.id not in move_initial_values:
            //                     move_initial_values[line.move_id.id] = {}
            //                 move_initial_values[line.move_id.id].update({field: line[field]})
            // 
            //     result = super().write(vals)
            //     self.move_id._synchronize_business_models(['line_ids'])
            //     if any(field in vals for field in ['account_id', 'currency_id']):
            //         self._check_constrains_account_id_journal_id()
            // 
            //     if not self.env.context.get('tracking_disable', False):
            //         # Log changes to move lines on each move
            //         for move_id, modified_lines in move_initial_values.items():
            //             for line in self.filtered(lambda l: l.move_id.id == move_id):
            //                 tracking_value_ids = line._mail_track(ref_fields, modified_lines)[1]
            //                 if tracking_value_ids:
            //                     msg = _("Journal Item %s updated", line._get_html_link(title=f"#{line.id}"))
            //                     line.move_id._message_log(
            //                         body=msg,
            //                         tracking_value_ids=tracking_value_ids
            //                     )
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def write(self, vals):
            // """ Format the analytic_distribution float value, so equality on analytic_distribution can be done """
            // decimal_precision = self.env['decimal.precision'].precision_get('Percentage Analytic')
            // vals = self._sanitize_values(vals, decimal_precision)
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def write(self, vals):
            // if (
            //         'state' in vals
            //         and vals['state'] != 'submitted'
            //         and not (self.env.user.has_group('hr_expense.group_hr_expense_manager') or self.env.su)
            //         and any(state == 'draft' for state in self.mapped('state'))
            // ):
            //     raise UserError(_("You don't have the rights to bypass the validation process of this expense."))
            // expense_to_previous_sheet = {}
            // if 'sheet_id' in vals:
            //     # Check access rights on the sheet
            //     self.env['hr.expense.sheet'].browse(vals['sheet_id']).check_access('write')
            // 
            //     # Store the previous sheet of the expenses to unlink the attachments later if needed
            //     for expense in self:
            //         expense_to_previous_sheet[expense] = expense.sheet_id
            // 
            //     # If the sheet_id is modified, we need to check that the expenses are not set to 0,
            //     # unless it's to unlink the sheet
            //     enforced_non_zero_expenses = self.env['hr.expense']
            //     if vals.get('sheet_id'):  # If sheet is linked, we need to check all the newly linked expenses in self
            //         enforced_non_zero_expenses = self
            // else:  # If sheet_id is not modified, we need to check all the expenses in self linked to a sheet
            //     enforced_non_zero_expenses = self.filtered('sheet_id')
            // 
            // if 'tax_ids' in vals or 'analytic_distribution' in vals or 'account_id' in vals:
            //     if any(not expense.is_editable for expense in self):
            //         raise UserError(_('You are not authorized to edit this expense report.'))
            // 
            // if enforced_non_zero_expenses:
            //     enforced_non_zero_expenses.check_amount_not_zero(vals)
            // 
            // res = super().write(vals)
            // 
            // if 'currency_id' in vals:
            //     self._set_expense_currency_rate(date_today=fields.Date.context_today(self))
            //     for expense in self:
            //         expense.total_amount = expense.total_amount_currency * expense.currency_rate
            // 
            // if 'employee_id' in vals:
            //     # In case expense has sheet which has only one expense_line_ids,
            //     # then changing the expense.employee_id triggers changing the sheet.employee_id too.
            //     # Otherwise we unlink the expense line from sheet, (so that the user can create a new report).
            //     if self.sheet_id:
            //         employees = self.sheet_id.expense_line_ids.mapped('employee_id')
            //         if len(employees) == 1:
            //             self.sheet_id.write({'employee_id': vals['employee_id']})
            //         elif len(employees) > 1:
            //             self.sheet_id = False
            // if 'sheet_id' in vals:
            //     # The sheet_id has been modified, either by an explicit write on sheet_id of the expense,
            //     # or by processing a command on the sheet's expense_line_ids.
            //     # We need to delete the attachments on the previous sheet coming from the expenses that were modified,
            //     # and copy the attachments of the expenses to the new sheet,
            //     # if it's a no-op (writing same sheet_id as the current sheet_id of the expense),
            //     # nothing should be done (no unlink then copy of the same attachments)
            //     attachments_to_unlink = self.env['ir.attachment']
            //     for expense in self:
            //         previous_sheet = expense_to_previous_sheet[expense]
            //         checksums = set((expense.attachment_ids - previous_sheet.expense_line_ids.attachment_ids).mapped('checksum'))
            //         attachments_to_unlink += previous_sheet.attachment_ids.filtered(lambda att: att.checksum in checksums)
            //         if vals['sheet_id'] and expense.sheet_id != previous_sheet:
            //             for attachment in expense.attachment_ids.with_context(sync_attachment=False):
            //                 attachment.copy({
            //                     'res_model': 'hr.expense.sheet',
            //                     'res_id': vals['sheet_id'],
            //                 })
            //     attachments_to_unlink.with_context(sync_attachment=False).unlink()
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def write(self, values):
            // if 'display_type' in values and self.filtered(lambda line: line.display_type != values.get('display_type')):
            //     raise UserError(_("You cannot change the type of a purchase order line. Instead you should delete the current line and create a new line of the proper type."))
            // 
            // if 'product_qty' in values:
            //     precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            //     for line in self:
            //         if (
            //             line.order_id.state == "purchase"
            //             and float_compare(line.product_qty, values["product_qty"], precision_digits=precision) != 0
            //         ):
            //             line.order_id.message_post_with_source(
            //                 'purchase.track_po_line_template',
            //                 render_values={'line': line, 'product_qty': values['product_qty']},
            //                 subtype_xmlid='mail.mt_note',
            //             )
            // 
            // if 'qty_received' in values:
            //     for line in self:
            //         line._track_qty_received(values['qty_received'])
            // return super(PurchaseOrderLine, self).write(values)
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'price_unit' not in vals:
            //     return res
            // if vals['price_unit'] <= 0.0 and any(
            //         requisition.requisition_type == 'blanket_order' and
            //         requisition.state not in ['draft', 'cancel', 'done'] for requisition in self.mapped('requisition_id')):
            //     raise UserError(_("You cannot have a negative or unit price of 0 for an already confirmed blanket order."))
            // # If the price is updated, we have to update the related SupplierInfo
            // self.supplier_info_ids.write({'price': vals['price_unit']})
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def write(self, values):
            // if 'display_type' in values and self.filtered(lambda line: line.display_type != values.get('display_type')):
            //     raise UserError(_("You cannot change the type of a sale order line. Instead you should delete the current line and create a new line of the proper type."))
            // 
            // if 'product_id' in values and any(
            //     sol.product_id.id != values['product_id']
            //     and not sol.product_updatable
            //     for sol in self
            // ):
            //     raise UserError(_("You cannot modify the product of this order line."))
            // 
            // if 'product_uom_qty' in values:
            //     precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            //     self.filtered(
            //         lambda r: r.state == 'sale' and float_compare(r.product_uom_qty, values['product_uom_qty'], precision_digits=precision) != 0)._update_line_quantity(values)
            // 
            // if (
            //     'technical_price_unit' in values
            //     and 'price_unit' not in values
            //     and not self.env.context.get('sale_write_from_compute')
            // ):
            //     # price_unit field was set as readonly in the view (but technical_price_unit not)
            //     # the field is not sent by the client and expected to be recomputed, but isn't
            //     # because technical_price_unit is set.
            //     values.pop('technical_price_unit')
            // 
            // # Prevent writing on a locked SO.
            // protected_fields = self._get_protected_fields()
            // if any(self.order_id.mapped('locked')) and any(f in values.keys() for f in protected_fields):
            //     protected_fields_modified = list(set(protected_fields) & set(values.keys()))
            // 
            //     if 'name' in protected_fields_modified and all(self.mapped('is_downpayment')):
            //         protected_fields_modified.remove('name')
            // 
            //     fields = self.env['ir.model.fields'].sudo().search([
            //         ('name', 'in', protected_fields_modified), ('model', '=', self._name)
            //     ])
            //     if fields:
            //         raise UserError(
            //             _('It is forbidden to modify the following fields in a locked order:\n%s',
            //               '\n'.join(fields.mapped('field_description')))
            //         )
            // 
            // result = super().write(values)
            // 
            // # Don't recompute the package_id if we are setting the quantity of the items and the quantity of packages
            // if 'product_uom_qty' in values and 'product_packaging_qty' in values and 'product_packaging_id' not in values:
            //     self.env.remove_to_compute(self._fields['product_packaging_id'], self)
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py) ---
            // def write(self, vals):
            // res = super(AccountAssetAsset, self).write(vals)
            // if 'depreciation_line_ids' not in vals and 'state' not in vals:
            //     for rec in self:
            //         rec.compute_depreciation_board()
            // return res
            */
            return default;
        }
    }
}