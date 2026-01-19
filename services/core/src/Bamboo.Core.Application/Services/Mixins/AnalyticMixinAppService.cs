using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("analytic", Category = "Accounting", Depends = new[] { "base", "mail", "uom" })]
    public partial class AnalyticMixinAppService : ApplicationService, IAnalyticMixinAppService
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
            // return move.with_context(child_field='line_ids').action_add_from_catalog()
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

        public async Task<TEntity> ActionApproveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_approve(self):
            // """ Approve an expense, pops a wizard if a duplicated expense is found to confirm they are all valid expenses """
            // self._check_can_approve()
            // for expense in self:
            //     expense._validate_distribution(
            //         account=expense.account_id.id,
            //         product=expense.product_id.id,
            //         business_domain='expense',
            //         company_id=expense.company_id.id,
            //     )
            // 
            // duplicates = self.duplicate_expense_ids.filtered(lambda exp: exp.state in {'submitted', 'approved', 'posted', 'paid', 'in_payment'})
            // if duplicates:
            //     action = self.env["ir.actions.act_window"]._for_xml_id('hr_expense.hr_expense_approve_duplicate_action')
            //     action['context'] = {'default_expense_ids': duplicates.ids}
            //     return action
            // self._do_approve(False)
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

        public async Task<TEntity> ActionOpenAccountMoveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_open_account_move(self):
            // self.ensure_one()
            // if self.payment_mode == 'own_account':
            //     res_model = 'account.move'
            //     record_id = self.account_move_id
            // else:
            //     res_model = 'account.payment'
            //     record_id = self.account_move_id.origin_payment_id
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': res_model,
            //     'name': record_id.name,
            //     'view_mode': 'form',
            //     'res_id': record_id.id,
            //     'views': [(False, 'form')],
            // }
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

        public async Task<TEntity> ActionOpenSplitExpenseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_open_split_expense(self):
            // self.ensure_one()
            // split_expense_ids = self.search([('split_expense_origin_id', '=', self.split_expense_origin_id.id)])
            // return split_expense_ids._get_records_action(name=_("Split Expenses"))
            */
            return default;
        }

        public async Task<TEntity> ActionPayAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_pay(self):
            // """ Register payment shortcut on the expense form view """
            // return self.account_move_id.with_context(default_partner_bank_id=(
            //     self.account_move_id.partner_bank_id.id if len(self.account_move_id.partner_bank_id) <= 1 else None
            // )).action_register_payment()
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

        public async Task<TEntity> ActionPostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_post(self):
            // """
            // Post the expense, following one of those two options:
            //     - Company-paid expenses: Create and post a payment, with an accounting entry
            //     - Employee-paid expenses: Through a wizard, create and post a receipt
            // """
            // # When a move has been deleted
            // self._check_can_create_move()
            // 
            // company_expenses = self.filtered(lambda expense: expense.payment_mode == 'company_account')
            // employee_expenses = self - company_expenses
            // if len(employee_expenses.company_id) > 1:
            //     raise UserError(_("You can't post simultaneously employee-paid expenses belonging to different companies"))
            // 
            // if company_expenses:
            //     company_expenses._create_company_paid_moves()
            //     # Post the company-paid expense through the payment, to post both at the same time
            //     company_expenses.account_move_id.origin_payment_id.action_post()
            // 
            // if employee_expenses:
            //     return employee_expenses.with_context(company_paid_move_ids=company_expenses.account_move_id.ids)._post_wizard()
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_refuse(self):
            // """ Refuse an expense with a reason """
            // self._check_can_refuse()
            // return self.env["ir.actions.act_window"]._for_xml_id('hr_expense.hr_expense_refuse_wizard_action')
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

        public async Task<TEntity> ActionResetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_reset(self):
            // """  Reset an expense to draft state, reversing the accounting entries if needed """
            // self._check_can_reset_approval()
            // self = self.with_context(clean_context(self.env.context))
            // moves_sudo = self.sudo().account_move_id
            // draft_moves_sudo = moves_sudo.filtered(lambda m: m.state == 'draft')
            // non_draft_moves_sudo = moves_sudo - draft_moves_sudo
            // non_draft_moves_sudo._reverse_moves(
            //     default_values_list=[{'invoice_date': fields.Date.context_today(move_sudo)} for move_sudo in non_draft_moves_sudo],
            //     cancel=True
            // )
            // draft_moves_sudo.unlink()
            // self._do_reset_approval()
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
            // if self.filtered(lambda expense: expense.state in {'posted', 'paid', 'in_payment'}):
            //     raise UserError(_("You cannot split an expense that is already posted."))
            // if not self.is_editable:
            //     raise UserError(_("You do not have the rights to edit this expense."))
            // 
            // splits = self.env['hr.expense.split'].create(self._get_split_values())
            // 
            // wizard = self.env['hr.expense.split.wizard'].create([{
            //     'expense_split_line_ids': splits.ids,
            //     'expense_id': self.id,
            // }])
            // return {
            //     'name': _("Expense split"),
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

        public async Task<TEntity> ActionSubmitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_submit(self):
            // """ Submit a draft expense to an approve, may skip to the approval step if no approver on the employee nor the expense """
            // user = self.env.user
            // for expense in self:
            //     if user.employee_id != expense.employee_id and not expense.can_approve:
            //         raise UserError(_("You do not have the required permission to submit this expense."))
            //     if not expense.product_id:
            //         raise UserError(_("You can not submit an expense without a category."))
            //     if not expense.manager_id:
            //         expense.sudo().manager_id = expense._get_default_responsible_for_approval()
            // expenses_autovalidated = self.filtered(lambda expense: expense._can_be_autovalidated())
            // (self - expenses_autovalidated).approval_state = 'submitted'
            // if expenses_autovalidated:  # Note, this will and should bypass the duplicate check. May be changed later
            //     expenses_autovalidated._do_approve(check=False)
            // self.sudo().update_activities_and_mails()
            */
            return default;
        }

        public async Task<TEntity> ActionUnreconcileMatchEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def action_unreconcile_match_entries(self):
            // """ This method will do the unreconcile action in the list view of the moves """
            // active_ids = self.env.context.get('active_ids')
            // if active_ids:
            //     move_lines = self.env['account.move.line'].browse(active_ids)._all_reconciled_lines()
            //     move_lines.remove_move_reconcile()
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

        public async Task<TEntity> CanBeAutovalidatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _can_be_autovalidated(self):
            // """ Check whether the given expenses can be auto-validated (no approver) """
            // self.ensure_one()
            // return (not self.manager_id and not self.employee_id.expense_manager_id) or self.manager_id == self.employee_id.user_id
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedOnPortalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _can_be_edited_on_portal(self):
            // self.ensure_one()
            // return self.order_id._can_be_edited_on_portal() and not self.combo_item_id
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
            // not_reconciled_partial_matching_numbers = set(self
            //     .filtered(lambda aml: not aml.reconciled and aml.matching_number and aml.matching_number.startswith('P'))
            //     .mapped('matching_number')
            // )
            // self = self.filtered(lambda aml: not aml.reconciled or aml.matching_number not in not_reconciled_partial_matching_numbers)
            // 
            // if not self:
            //     return
            // 
            // if any(aml.reconciled for aml in self):
            //     raise UserError(_("You are trying to reconcile some entries that are already reconciled."))
            // if any(aml.parent_state == 'cancel' for aml in self):
            //     raise UserError(_("You can not reconcile cancelled entries."))
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

        public async Task<TEntity> CheckCanApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _check_can_approve(self):
            // if not all(self.mapped('can_approve')):
            //     reasons_list = tuple(reason for reason in self._get_cannot_approve_reason().values() if reason)
            //     reasons = _("You cannot approve:\n %(reasons)s", reasons="\n".join(reasons_list))
            //     raise UserError(reasons)
            */
            return default;
        }

        public async Task<TEntity> CheckCanCreateMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _check_can_create_move(self):
            // if any(expense.state != 'approved' for expense in self):
            //     raise UserError(_("You can only generate an accounting entry for approved expense(s)."))
            // 
            // if False in self.mapped('payment_mode'):
            //     raise UserError(_("Please specify if the expenses were paid by the company, or the employee."))
            */
            return default;
        }

        public async Task<TEntity> CheckCanRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _check_can_refuse(self):
            // if not all(self.mapped('can_approve')):
            //     reasons = _("You cannot refuse:\n %(reasons)s", reasons="\n".join(self._get_cannot_approve_reason().values()))
            //     raise UserError(reasons)
            */
            return default;
        }

        public async Task<TEntity> CheckCanResetApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _check_can_reset_approval(self):
            // if not all(self.mapped('can_reset')):
            //     raise UserError(_("Only HR Officers, accountants, or the concerned employee can reset to draft."))
            // if any(state not in {False, 'draft'} for state in self.account_move_id.mapped('state')):
            //     raise UserError(_("You cannot reset to draft an expense linked to a posted journal entry."))
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
            // for line in self.filtered(lambda x: x.display_type not in ('line_section', 'line_subsection', 'line_note')):
            //     account = line.account_id
            //     journal = line.move_id.journal_id
            // 
            //     if not (account.active or line.is_imported or self.env.context.get('skip_account_deprecation_check')):
            //         raise UserError(_('The account %(name)s (%(code)s) is archived.', name=account.name, code=account.code))
            // 
            //     account_currency = account.currency_id
            //     if account_currency and account_currency != line.company_currency_id and account_currency != line.currency_id:
            //         raise UserError(_('The account selected on your journal entry forces to provide a secondary currency. You should remove the secondary currency on the account.'))
            // 
            //     if account in (journal.default_account_id, journal.suspense_account_id):
            //         continue
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

        public async Task<TEntity> CheckNonZeroInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _check_non_zero(self):
            // """ Helper to raise when we should ensure that an expense isn't approved  """
            // for expense in self:
            //     total_amount_is_zero = expense.company_currency_id.is_zero(expense.total_amount)
            //     total_amount_currency_is_zero = expense.currency_id.is_zero(expense.total_amount_currency)
            //     if (expense.state != 'draft' or expense.approval_state != False) and (total_amount_is_zero or total_amount_currency_is_zero):
            //         raise ValidationError(_("Only draft expenses can have a total of 0."))
            */
            return default;
        }

        public async Task<TEntity> CheckO2oPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _check_o2o_payment(self):
            // for expense in self:
            //     if len(expense.account_move_id.origin_payment_id.expense_ids) > 1:
            //         raise ValidationError(_("Only one expense can be linked to a particular payment"))
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
            // for line in self.filtered(lambda x: x.parent_state == 'posted'):
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
            //                AND account.active = 't'
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
            //         )
            //         if account_id:
            //             line.account_id = account_id
            // for line in self:
            //     if not line.account_id and line.display_type not in ('line_section', 'line_subsection', 'line_note'):
            //         previous_two_accounts = line.move_id.line_ids.filtered(
            //             lambda l: l.account_id and l.display_type == line.display_type
            //         )[-2:].account_id
            //         if len(previous_two_accounts) == 1 and len(line.move_id.line_ids) > 2:
            //             line.account_id = previous_two_accounts
            //         else:
            //             line.account_id = line.move_id.journal_id.default_account_id
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_account_id(self):
            // for _expense in self:
            //     expense = _expense.with_company(_expense.company_id)
            //     if not expense.product_id:
            //         expense.account_id = _expense.company_id.expense_account_id
            //         continue
            //     account = expense.product_id.product_tmpl_id._get_product_accounts()['expense']
            //     if account:
            //         expense.account_id = account
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedUomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_allowed_uom_ids(self):
            // for line in self:
            //     line.allowed_uom_ids = line.product_id.uom_id | line.product_id.uom_ids
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_allowed_uom_ids(self):
            // for line in self:
            //     line.allowed_uom_ids = line.product_id.uom_id | line.product_id.uom_ids | line.product_id.seller_ids.product_uom_id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_allowed_uom_ids(self):
            // for line in self:
            //     line.allowed_uom_ids = line.product_id.uom_id | line.product_id.uom_ids
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
            //     if line.currency_id == line.company_id.currency_id and not line.move_id.is_invoice(True):
            //         line.amount_currency = line.balance
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_amount(self):
            // AccountTax = self.env['account.tax']
            // for line in self:
            //     company = line.company_id or self.env.company
            //     base_line = line._prepare_base_line_for_taxes_computation()
            //     AccountTax._add_tax_details_in_base_line(base_line, company)
            //     AccountTax._round_base_lines_tax_details([base_line], company)
            //     line.price_subtotal = base_line['tax_details']['total_excluded_currency']
            //     line.price_total = base_line['tax_details']['total_included_currency']
            //     line.price_tax = line.price_total - line.price_subtotal
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_amount(self):
            // AccountTax = self.env['account.tax']
            // for line in self:
            //     company = line.company_id or self.env.company
            //     base_line = line._prepare_base_line_for_taxes_computation()
            //     AccountTax._add_tax_details_in_base_line(base_line, company)
            //     AccountTax._round_base_lines_tax_details([base_line], company)
            //     line.price_subtotal = base_line['tax_details']['total_excluded_currency']
            //     line.price_total = base_line['tax_details']['total_included_currency']
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
            //     self.env.cr.execute('''
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

        public async Task<TEntity> ComputeAmountToInvoiceAtDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_amount_to_invoice_at_date(self):
            // for line in self:
            //     line.amount_to_invoice_at_date = (line.qty_received_at_date - line.qty_invoiced_at_date) * line.price_unit
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_amount_to_invoice_at_date(self):
            // for line in self:
            //     line.amount_to_invoice_at_date = (line.qty_delivered_at_date - line.qty_invoiced_at_date) * line.price_unit
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
            //             list({int(account_id) for ids in related_distribution for account_id in ids.split(',') if account_id.strip()})
            //         ).exists().root_plan_id
            // 
            //         arguments = frozendict(line._get_analytic_distribution_arguments(root_plans))
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
            //     if line.display_type in ('line_section', 'line_subsection', 'line_note'):
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

        public async Task<TEntity> ComputeCanApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_can_approve(self):
            // cannot_reason_per_record_id = self._get_cannot_approve_reason()
            // for expense in self:
            //     expense.can_approve = not cannot_reason_per_record_id[expense.id]
            */
            return default;
        }

        public async Task<TEntity> ComputeCanResetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_can_reset(self):
            // user = self.env.user
            // is_team_approver = user.has_group('hr_expense.group_hr_expense_team_approver') or self.env.su
            // is_all_approver = user.has_groups('hr_expense.group_hr_expense_user,hr_expense.group_hr_expense_manager') or self.env.su
            // 
            // valid_company_ids = set(self.env.companies.ids)
            // expenses_employee_ids_under_user_ones = set()
            // if is_team_approver:  # We don't need to search if the user has not the required rights
            //     expenses_employee_ids_under_user_ones = set(self.env['hr.employee'].sudo().search([
            //         ('id', 'in', self.employee_id.ids),
            //         ('id', 'child_of', user.employee_ids.ids),
            //         ('id', 'not in', user.employee_ids.ids),
            //     ]).ids)
            // 
            // for expense in self:
            //     expense.can_reset = (
            //         expense.company_id.id in valid_company_ids
            //         and (
            //                 is_all_approver
            //                 or expense.employee_id.id in expenses_employee_ids_under_user_ones
            //                 or expense.employee_id.expense_manager_id == user
            //                 or (expense.state in {'draft', 'submitted'} and expense.employee_id.user_id == user)
            //         )
            //     )
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
            // query = self._search(self.env.context.get('domain_cumulated_balance') or [], bypass_access=True)
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
            //     if expense.product_has_cost and expense.state == 'draft':
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
            //         line.currency_rate = line.move_id.invoice_currency_rate or 1.0
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
            //     company_currency = expense.company_currency_id or expense.env.company.currency_id
            //     expense.label_currency_rate = _(
            //         '1 %(exp_cur)s = %(rate)s %(comp_cur)s',
            //         exp_cur=(expense.currency_id or company_currency).name,
            //         rate=float_repr(expense.currency_rate, 6),
            //         comp_cur=company_currency.name,
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
            //     if line.combo_item_id:
            //         line.discount = line._get_linked_line().discount
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
            // all_ids = {int(_id) for rec in self for key in (rec.analytic_distribution or {}) for _id in key.split(',') if _id.isdigit()}
            // existing_accounts_ids = set(self.env['account.analytic.account'].browse(all_ids).exists().ids)
            // for rec in self:
            //     ids = list(unique(int(_id) for key in (rec.analytic_distribution or {}) for _id in key.split(',') if _id.isdigit() and int(_id) in existing_accounts_ids))
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

        public async Task<TEntity> ComputeFromEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_from_employee_id(self):
            // for expense in self:
            //     expense.department_id = expense.employee_id.department_id
            //     expense.manager_id = expense._get_default_responsible_for_approval()
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

        public async Task<TEntity> ComputeHasInvalidAnalyticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_has_invalid_analytics(self):
            // SKIPPED_ACCOUNT_TYPES = {'asset_receivable', 'liability_payable', 'asset_cash', 'liability_credit_card'}
            // lines_to_validate = self.filtered(lambda line: (
            //     line.display_type == 'product' and
            //     line.account_id.account_type not in SKIPPED_ACCOUNT_TYPES
            // ))
            // (self - lines_to_validate).has_invalid_analytics = False
            // for line in lines_to_validate:
            //     line.has_invalid_analytics = False
            //     try:
            //         business_domain = (
            //             'invoice' if line.move_id.is_sale_document(True)
            //             else 'bill' if line.move_id.is_purchase_document(True)
            //             else 'general'
            //         )
            //         line.with_context(validate_analytic=True)._validate_distribution(
            //             company_id=line.company_id.id,
            //             product=line.product_id.id,
            //             account=line.account_id.id,
            //             business_domain=business_domain,
            //         )
            //     except ValidationError:
            //         line.has_invalid_analytics = True
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRoutingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_has_routing_lines(self):
            // for workcenter in self:
            //     workcenter.has_routing_lines = self.env['mrp.routing.workcenter'].search_count([('workcenter_id', 'in', workcenter.ids)], limit=1)
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
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
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
            // is_hr_admin = (
            //     self.env.user.has_group('hr_expense.group_hr_expense_manager')
            //     or self.env.su
            // )
            // is_team_approver = self.env.user.has_group('hr_expense.group_hr_expense_team_approver')
            // is_all_approver = self.env.user.has_group('hr_expense.group_hr_expense_user')
            // 
            // expenses_employee_ids_under_user_ones = set()
            // if is_team_approver:
            //     expenses_employee_ids_under_user_ones = set(
            //         self.env['hr.employee'].sudo().search(
            //             [
            //                 ('id', 'in', self.employee_id.ids),
            //                 ('id', 'child_of', self.env.user.employee_ids.ids),
            //                 ('id', 'not in', self.env.user.employee_ids.ids),
            //             ]
            //         ).ids
            //     )
            // for expense in self:
            //     if not expense.company_id:
            //         # This would be happening when emptying the required company_id field, triggering the "onchange"s.
            //         # This would lead to fields being set as editable, instead of using the env company,
            //         # recomputing the interface just to be blocked when trying to save we choose not to recompute anything
            //         # and wait for a proper company to be inputted.
            //         continue
            //     if expense.state not in {'draft', 'submitted', 'approved'} and not self.env.su:
            //         # Not editable
            //         expense.is_editable = False
            //         continue
            // 
            //     if is_hr_admin:
            //         # Administrator-level users are not restricted, they can edit their own expenses
            //         expense.is_editable = True
            //         continue
            // 
            //     employee = expense.employee_id
            //     is_own_expense = employee.user_id == self.env.user
            //     if is_own_expense and expense.state == 'draft':
            //         # Anyone can edit their own draft expense
            //         expense.is_editable = True
            //         continue
            // 
            //     managers = (
            //         expense.manager_id
            //         | employee.expense_manager_id
            //         | employee.sudo().department_id.manager_id.user_id.sudo(self.env.su)
            //     )
            //     if is_all_approver:
            //         managers |= self.env.user
            //     if expense.employee_id.id in expenses_employee_ids_under_user_ones:
            //             managers |= self.env.user
            //     if not is_own_expense and self.env.user in managers:
            //         # If Approver-level or designated manager, can edit other people expense
            //         expense.is_editable = True
            //         continue
            //     expense.is_editable = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMultipleCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_is_multiple_currency(self):
            // for expense in self:
            //     expense_currency = expense.currency_id or expense.company_currency_id or expense.env.company.currency_id
            //     expense_company_currency = expense.company_currency_id or expense.env.company.currency_id
            //     expense.is_multiple_currency = expense_currency != expense_company_currency
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
            //             # If we have both purchase and sale taxes on a line (which can happen in bank rec).
            //             # We choose invoice by default
            //             tax_type = line.tax_ids.mapped('type_tax_use')
            //             if 'sale' in tax_type and 'purchase' in tax_type:
            //                 is_refund = line.credit == 0
            //             else:
            //                 tax_type = line.tax_ids[:1].type_tax_use
            //                 if (tax_type == 'sale' and line.credit == 0) or (tax_type == 'purchase' and line.debit == 0):
            //                     is_refund = True
            // 
            //             if line.tax_ids and line.move_id.reversed_entry_id:
            //                 is_refund = not is_refund
            //     line.is_refund = is_refund
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_is_storno(self):
            // for line in self:
            //     if not line.company_id.account_storno:
            //         continue
            //     line.is_storno = (line.is_storno or line.move_id.is_storno) and line.move_type not in ('in_invoice', 'out_invoice')
            // 
            //     # For invoice lines, we want to set is_storno based on the sign of the line if the entire move is not storno (not refund)
            //     # This allows setting is_storno to true or false depending on quantity and price_unit
            //     if not line.move_id.is_storno and line in line.move_id.invoice_line_ids and line.quantity * line.price_unit:
            //         line.is_storno = line.quantity * line.price_unit < 0
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
            //         if name:
            //             line.name = name
            //     if not line.product_id or line.display_type in ('line_section', 'line_subsection', 'line_note'):
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

        public async Task<TEntity> ComputeNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_no_followup(self):
            // for aml in self:
            //     aml.no_followup = aml.move_id.is_entry() and not aml.move_id.origin_payment_id
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
            // time_data = self.env['mrp.workcenter.productivity']._read_group(
            //     domain=[
            //         ('date_start', '>=', fields.Datetime.to_string(datetime.now() - relativedelta.relativedelta(months=1))),
            //         ('workcenter_id', 'in', self.ids),
            //         ('date_end', '!=', False),
            //     ],
            //     groupby=['workcenter_id', 'loss_type'],
            //     aggregates=['duration:sum'],
            // )
            // time_by_workcenter = defaultdict(lambda: {'productive_time': 0.0, 'blocked_time': 0.0})
            // for data in time_data:
            //     workcenter, loss_type, duration = data
            //     time_to_update = 'productive_time' if loss_type == 'productive' else 'blocked_time'
            //     time_by_workcenter[workcenter.id][time_to_update] += duration
            // for workcenter in self:
            //     workcenter_time = time_by_workcenter[workcenter.id]
            //     productive_time = workcenter_time['productive_time']
            //     if productive_time:
            //         blocked_time = workcenter_time['blocked_time']
            //         workcenter.oee = float_round(productive_time * 100.0 / (productive_time + blocked_time), precision_digits=2)
            //     else:
            //         workcenter.oee = 0.0
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
            //     for po in line.requisition_id.purchase_ids.filtered(lambda purchase_order: purchase_order.state == 'purchase'):
            //         for po_line in po.order_line.filtered(lambda order_line: order_line.product_id == line.product_id):
            //             if po_line.product_uom_id != line.product_uom_id:
            //                 total += po_line.product_uom_id._compute_quantity(po_line.product_qty, line.product_uom_id)
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

        public async Task<TEntity> ComputeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_parent_id(self):
            // parent_id_vals_to_lines = defaultdict(list)
            // for move, lines in self.grouped('move_id').items():
            //     if not move:
            //         parent_id_vals_to_lines[False].extend(lines._ids)
            //         continue
            //     last_section = False
            //     last_sub = False
            //     for line in move.line_ids.sorted('sequence'):
            //         value = False
            //         if line.display_type == 'line_section':
            //             last_section = line
            //             value = False
            //             last_sub = False
            //         elif line.display_type == 'line_subsection':
            //             value = last_section
            //             last_sub = line
            //         elif line.display_type in {'line_note', 'product'}:
            //             value = last_sub or last_section
            //         else:
            //             value = False
            //         parent_id_vals_to_lines[value].append(line.id)
            // 
            // for val, record_ids in parent_id_vals_to_lines.items():
            //     self.browse(record_ids).parent_id = val
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_parent_id(self):
            // purchase_order_lines = set(self)
            // for order, lines in self.grouped('order_id').items():
            //     if not order:
            //         lines.parent_id = False
            //         continue
            //     last_section = False
            //     last_sub = False
            //     for line in order.order_line.sorted('sequence'):
            //         if line.display_type == 'line_section':
            //             last_section = line
            //             if line in purchase_order_lines:
            //                 line.parent_id = False
            //             last_sub = False
            //         elif line.display_type == 'line_subsection':
            //             if line in purchase_order_lines:
            //                 line.parent_id = last_section
            //             last_sub = line
            //         elif line in purchase_order_lines:
            //             line.parent_id = last_sub or last_section
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_parent_id(self):
            // sale_order_lines = set(self)
            // for order, lines in self.grouped('order_id').items():
            //     if not order:
            //         lines.parent_id = False
            //         continue
            //     last_section = False
            //     last_sub = False
            //     for line in order.order_line.sorted('sequence'):
            //         if line.display_type == 'line_section':
            //             last_section = line
            //             if line in sale_order_lines:
            //                 line.parent_id = False
            //             last_sub = False
            //         elif line.display_type == 'line_subsection':
            //             if line in sale_order_lines:
            //                 line.parent_id = last_section
            //             last_sub = line
            //         elif line in sale_order_lines:
            //             line.parent_id = last_sub or last_section
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

        public async Task<TEntity> ComputePaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_payment_method_line_id(self):
            // for expense in self:
            //     expense.payment_method_line_id = expense.selectable_payment_method_line_ids[:1]
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
            //     if not line.product_id or line.invoice_lines or not line.company_id or self.env.context.get('skip_uom_conversion') or (line.technical_price_unit != line.price_unit):
            //         continue
            //     params = line._get_select_sellers_params()
            // 
            //     if line.selected_seller_id or not line.date_planned:
            //         line.date_planned = line._get_date_planned(line.selected_seller_id).strftime(DEFAULT_SERVER_DATETIME_FORMAT)
            // 
            //     # If not seller, use the standard price. It needs a proper currency conversion.
            //     if not line.selected_seller_id:
            //         unavailable_seller = line.product_id.seller_ids.filtered(
            //             lambda s: s.partner_id == line.order_id.partner_id)
            //         if not unavailable_seller and line.price_unit and line.product_uom_id == line._origin.product_uom_id:
            //             # Avoid to modify the price unit if there is no price list for this partner and
            //             # the line has already one to avoid to override unit price set manually.
            //             continue
            //         line.discount = 0
            //         po_line_uom = line.product_uom_id or line.product_id.uom_id
            //         price_unit = line.env['account.tax']._fix_tax_included_price_company(
            //             line.product_id.uom_id._compute_price(line.product_id.standard_price, po_line_uom),
            //             line.product_id.supplier_taxes_id,
            //             line.tax_ids,
            //             line.company_id,
            //         )
            //         price_unit = line.product_id.cost_currency_id._convert(
            //             price_unit,
            //             line.currency_id,
            //             line.company_id,
            //             line.date_order or fields.Date.context_today(line),
            //             False
            //         )
            //         line.price_unit = line.technical_price_unit = float_round(price_unit, precision_digits=max(line.currency_id.decimal_places, self.env['decimal.precision'].precision_get('Product Price')))
            // 
            //     elif line.selected_seller_id:
            //         price_unit = line.env['account.tax']._fix_tax_included_price_company(line.selected_seller_id.price, line.product_id.supplier_taxes_id, line.tax_ids, line.company_id) if line.selected_seller_id else 0.0
            //         price_unit = line.selected_seller_id.currency_id._convert(price_unit, line.currency_id, line.company_id, line.date_order or fields.Date.context_today(line), False)
            //         price_unit = float_round(price_unit, precision_digits=max(line.currency_id.decimal_places, self.env['decimal.precision'].precision_get('Product Price')))
            //         line.price_unit = line.technical_price_unit = line.selected_seller_id.product_uom_id._compute_price(price_unit, line.product_uom_id)
            //         line.discount = line.selected_seller_id.discount or 0.0
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
            //         product_ctx = {'seller_id': line.selected_seller_id.id, 'lang': get_lang(line.env, line.partner_id.lang).code}
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
            //     if not line.product_id or line.display_type in ('line_section', 'line_subsection', 'line_note') or line.is_imported:
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
            //    Otherwise it is always computed from the total_amount and the quantity else it would break the Receipt Entry
            //    when edited after creation.
            // """
            // for expense in self:
            //     if expense.state != 'draft':
            //         continue
            // 
            //     if not expense.company_id:
            //         # This would be happening when emptying the required company_id field, triggering the "onchange"s.
            //         # A traceback would occur because company_currency_id would be set to False.
            //         # Instead of using the env company, recomputing the interface just to be blocked when trying to save
            //         # we choose not to recompute anything and wait for a proper company to be inputted.
            //         continue
            // 
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
            // def has_manual_price(line):
            //     # `line.currency_id` can be False for NewId records
            //     currency = (
            //         line.currency_id
            //         or line.company_id.currency_id
            //         or line.env.company.currency_id
            //     )
            //     return currency.compare_amounts(line.technical_price_unit, line.price_unit)
            // 
            // force_recompute = self.env.context.get('force_price_recomputation')
            // for line in self:
            //     # Don't compute the price for deleted lines or lines for which the
            //     # price unit doesn't come from the product.
            //     if not line.order_id or line.is_downpayment or line._is_global_discount():
            //         continue
            // 
            //     # check if the price has been manually set or there is already invoiced amount.
            //     # if so, the price shouldn't change as it might have been manually edited.
            //     if (
            //         (not force_recompute and has_manual_price(line))
            //         or line.qty_invoiced > 0
            //         or (line.product_id.expense_policy == 'cost' and line.is_expense)
            //     ):
            //         continue
            //     line = line.with_context(sale_write_from_compute=True)
            //     if not line.product_uom_id or not line.product_id:
            //         line.price_unit = 0.0
            //         line.technical_price_unit = 0.0
            //     else:
            //         line._reset_price_unit()
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitProductUomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_price_unit_product_uom(self):
            // for line in self:
            //     line.price_unit_product_uom = not line.display_type and line.product_uom_id._compute_price(line.price_unit, line.product_id.uom_id)
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
            //             # No need for the price context, we're not considering the price here
            //             product=line.product_id,
            //             **line._get_pricelist_kwargs(),
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
            //         seller_ids = line.product_id.seller_ids._get_filtered_supplier(line.company_id, line.product_id, False)
            //         line.product_uom_id = seller_ids[:1].product_uom_id or line.product_id.uom_id
            //     else:
            //         line.product_uom_id = line.product_id.uom_id
            --- ODOO METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py) ---
            // def _compute_product_uom_id(self):
            // for line in self:
            //     line.product_uom_id = line.product_id.uom_id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_product_uom_id(self):
            // for line in self:
            //     if not line.product_uom_id or (line.product_id.uom_id.id != line.product_uom_id.id):
            //         line.product_uom_id = line.product_id.uom_id
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_product_uom_qty(self):
            // for line in self:
            //     if line.product_id and line.product_id.uom_id != line.product_uom_id:
            //         line.product_uom_qty = line.product_uom_id._compute_quantity(line.product_qty, line.product_id.uom_id)
            //     else:
            //         line.product_uom_qty = line.product_qty
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_product_uom_qty(self):
            // for line in self:
            //     if line.display_type:
            //         line.product_uom_qty = 0.0
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

        public async Task<TEntity> ComputePurchaseLineWarnMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_purchase_line_warn_msg(self):
            // has_warning_group = self.env.user.has_group('purchase.group_warning_purchase')
            // for line in self:
            //     line.purchase_line_warn_msg = line.product_id.purchase_line_warn_msg if has_warning_group else ""
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyDeliveredAtDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_qty_delivered_at_date(self):
            // if not self._date_in_the_past():
            //     # Avoid useless compute if we don't look in the past.
            //     for line in self:
            //         line.qty_delivered_at_date = line.qty_delivered
            //     return
            // delivered_qties = self._prepare_qty_delivered()
            // for line in self:
            //     line.qty_delivered_at_date = delivered_qties[line]
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
            // delivered_qties = self._prepare_qty_delivered()
            // for so_line in self:
            //     if not so_line.qty_delivered or so_line in delivered_qties:
            //         so_line.qty_delivered = delivered_qties[so_line]
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

        public async Task<TEntity> ComputeQtyInvoicedAtDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_invoiced_at_date(self):
            // if not self._date_in_the_past():
            //     for line in self:
            //         line.qty_invoiced_at_date = line.qty_invoiced
            //     return
            // invoiced_quantities = self._prepare_qty_invoiced()
            // for line in self:
            //     line.qty_invoiced_at_date = invoiced_quantities[line]
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_qty_invoiced_at_date(self):
            // if not self._date_in_the_past():
            //     # Avoid useless compute if we don't look in the past.
            //     for line in self:
            //         line.qty_invoiced_at_date = line.qty_invoiced
            //     return
            // invoiced_quantities = self._prepare_qty_invoiced()
            // for line in self:
            //     line.qty_invoiced_at_date = invoiced_quantities[line]
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_invoiced(self):
            // invoiced_quantities = self._prepare_qty_invoiced()
            // for line in self:
            //     line.qty_invoiced = invoiced_quantities[line]
            // 
            //     # compute qty_to_invoice
            //     if line.order_id.state == 'purchase':
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
            // invoiced_quantities = self._prepare_qty_invoiced()
            // for line in self:
            //     line.qty_invoiced = invoiced_quantities[line]
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
            //             qty_unsigned = invoice_line.product_uom_id._compute_quantity(invoice_line.quantity, line.product_uom_id)
            //             qty_signed = qty_unsigned * -invoice_line.move_id.direction_sign
            //             qty_invoiced_posted += qty_signed
            //     line.qty_invoiced_posted = qty_invoiced_posted
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyReceivedAtDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_received_at_date(self):
            // if not self._date_in_the_past():
            //     for line in self:
            //         line.qty_received_at_date = line.qty_received
            //     return
            // received_quantities = self._prepare_qty_received()
            // for line in self:
            //     line.qty_received_at_date = received_quantities[line]
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_qty_received(self):
            // received_qties = self._prepare_qty_received()
            // for line in self:
            //     if not line.qty_received or line in received_qties:
            //         line.qty_received = received_qties[line]
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

        public async Task<TEntity> ComputeReconciledLinesExcludingExchangeDiffIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_reconciled_lines_excluding_exchange_diff_ids(self):
            // for line in self:
            //     all_lines = line.matched_debit_ids.debit_move_id + line.matched_credit_ids.credit_move_id
            //     excluded_ids = (
            //         line.matched_debit_ids.exchange_move_id.line_ids +
            //         line.matched_credit_ids.exchange_move_id.line_ids
            //     )
            //     line.reconciled_lines_excluding_exchange_diff_ids = all_lines - excluded_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeReconciledLinesIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_reconciled_lines_ids(self):
            // for line in self:
            //     line.reconciled_lines_ids = line.matched_debit_ids.debit_move_id + line.matched_credit_ids.credit_move_id
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleLineWarnMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_sale_line_warn_msg(self):
            // has_warning_group = self.env.user.has_group('sale.group_warning_sale')
            // for line in self:
            //     line.sale_line_warn_msg = line.product_id.sale_line_warn_msg if has_warning_group else ""
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
            // expenses_with_attachments = self.filtered(lambda expense: expense.attachment_ids and not expense.split_expense_origin_id)
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

        public async Task<TEntity> ComputeSelectablePaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_selectable_payment_method_line_ids(self):
            // for expense in self:
            //     allowed_method_line_ids = expense.company_id.company_expense_allowed_payment_method_line_ids
            //     if allowed_method_line_ids:
            //         expense.selectable_payment_method_line_ids = allowed_method_line_ids
            //     else:
            //         expense.selectable_payment_method_line_ids = self.env['account.payment.method.line'].search([
            //             # The journal is the source of the payment method line company
            //             *self.env['account.journal']._check_company_domain(expense.company_id),
            //             ('payment_type', '=', 'outbound'),
            //         ])
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectedSellerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _compute_selected_seller_id(self):
            // for line in self:
            //     if line.product_id:
            //         params = line._get_select_sellers_params()
            //         seller = line.product_id._select_seller(
            //             partner_id=line.partner_id,
            //             quantity=abs(line.product_qty),
            //             date=line.order_id.date_order and line.order_id.date_order.date() or fields.Date.context_today(line),
            //             uom_id=line.product_uom_id,
            //             params=params)
            //         line.selected_seller_id = seller.id if seller else False
            //     else:
            //         line.selected_seller_id = False
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

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_state(self):
            // """
            // Compute the states of the expense as such (priority is given to the last matching state of the list):
            //     - draft: By default
            //     - submitted: When the approval_state is 'submitted'
            //     - approved: When the approval_state is 'approved'
            //     - refused: When the approval_state is 'refused'
            //     - paid: When it is a company paid expense or the move state is neither 'draft' nor 'posted'
            //     - in_payment (or paid): When the move state is 'posted' and it's 'payment_state' is 'in_payment' or 'paid'
            //                             or ('partial' and there is a residual amount)
            //     - posted: When the linked move state is 'draft', or if it is 'posted' and it's 'payment_state' is 'not_paid'
            // """
            // for expense in self:
            //     move = expense.account_move_id
            //     if move.state == 'cancel':
            //         expense.state = 'paid'
            //         continue
            //     if move:
            //         if expense.payment_mode == 'company_account':
            //             # Shortcut to paid, as it's already paid, but we may not have the bank statement yet
            //             expense.state = 'paid'
            //         elif move.state == 'draft':
            //             expense.state = 'posted'
            //         elif move.payment_state == 'not_paid':
            //             expense.state = 'posted'
            //         elif (
            //                 move.payment_state == 'in_payment'
            //                 or (move.payment_state == 'partial' and not expense.company_currency_id.is_zero(expense.amount_residual))
            //         ):
            //             expense.state = self.env['account.move']._get_invoice_in_payment_state()
            //         else:  # Partial, reversed or in_payment
            //             expense.state = 'paid'
            //         continue
            //     expense.state = expense.approval_state or 'draft'
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
            //     if not expense.company_id:
            //         # This would be happening when emptying the required company_id field, triggering the "onchange"s.
            //         # A traceback would occur because company_currency_id would be set to False.
            //         # Instead of using the env company, recomputing the interface just to be blocked when trying to save
            //         # we choose not to recompute anything and wait for a proper company to be inputted.
            //         continue
            // 
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
            //      Note: as total_amount can be set directly by the user when the currency_rate is overridden,
            //      the tax must be computed after the total_amount.
            // """
            // AccountTax = self.env['account.tax']
            // for expense in self:
            //     if not expense.company_id:
            //         # This would be happening when emptying the required company_id field, triggering the "onchange"s.
            //         # A traceback would occur because company_currency_id would be set to False.
            //         # Instead of using the env company, recomputing the interface just to be blocked when trying to save
            //         # we choose not to recompute anything and wait for a proper company to be inputted.
            //         continue
            // 
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
            //         expense.untaxed_amount = tax_details['total_excluded_currency']
            //     else:  # Mono-currency case computation shortcut
            //         expense.tax_amount = expense.tax_amount_currency
            //         expense.untaxed_amount = expense.untaxed_amount_currency
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
            //     line.tax_ids = fpos.map_tax(taxes)
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _compute_tax_ids(self):
            // for line in self:
            //     if line.display_type in ('line_section', 'line_subsection', 'line_note', 'payment_term') or line.is_imported:
            //         continue
            //     # /!\ Don't remove existing taxes if there is no explicit taxes set on the account.
            //     if line.product_id or (line.display_type != 'discount' and (line.account_id.tax_ids or not line.tax_ids)):
            //         line.tax_ids = line._get_computed_taxes()
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_tax_ids(self):
            // for _expense in self.filtered('company_id'):   # Avoid a traceback, the field is required anyway
            //     expense = _expense.with_company(_expense.company_id)
            //     # taxes only from the same company
            //     expense.tax_ids = expense.product_id.supplier_taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(expense.company_id))
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _compute_tax_ids(self):
            // lines_by_company = defaultdict(lambda: self.env['sale.order.line'])
            // cached_taxes = {}
            // for line in self:
            //     if line.product_type == 'combo':
            //         line.tax_ids = False
            //         continue
            //     lines_by_company[line.company_id] += line
            // for company, lines in lines_by_company.items():
            //     for line in lines.with_company(company):
            //         taxes = None
            //         if line.product_id:
            //             taxes = line.product_id.taxes_id._filter_taxes_by_company(company)
            //         if not line.product_id or not taxes:
            //             # Nothing to map
            //             line.tax_ids = False
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
            //         line.tax_ids = result
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
            //     if not expense.company_id:
            //         # This would be happening when emptying the required company_id field, triggering the "onchange"s.
            //         # A traceback would occur because company_currency_id would be set to False.
            //         # Instead of using the env company, recomputing the interface just to be blocked when trying to save
            //         # we choose not to recompute anything and wait for a proper company to be inputted.
            //         continue
            // 
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
            //     if line.display_type not in ('product', 'cogs', 'non_deductible_product', 'non_deductible_product_total') or not line.move_id:
            //         line.price_total = line.price_subtotal = False
            //         continue
            // 
            //     company = line.company_id or self.env.company
            //     base_line = line.move_id._prepare_product_base_line_for_taxes_computation(line)
            //     AccountTax._add_tax_details_in_base_line(base_line, company)
            //     AccountTax._round_base_lines_tax_details([base_line], company)
            //     line.price_subtotal = base_line['tax_details']['total_excluded_currency']
            //     line.price_total = base_line['tax_details']['total_included_currency']
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
            //         if len(line.tax_ids.filtered(lambda tax: tax.price_include)) > 0:
            //             # As included taxes are not excluded from the computed subtotal, `compute_all()` method
            //             # has to be called to retrieve the subtotal without them.
            //             # `price_reduce_taxexcl` cannot be used as it is computed from `price_subtotal` field. (see upper Note)
            //             price_subtotal = line.tax_ids.compute_all(
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
            // return self.product_uom_id._compute_quantity(new_qty, stock_move.product_uom, rounding)
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkingStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _compute_working_state(self):
            // # We search for a productivity line associated to this workcenter having no `date_end`.
            // # If we do not find one, the workcenter is not currently being used. If we find one, according
            // # to its `type_loss`, the workcenter is either being used or blocked.
            // time_log_by_workcenter = {}
            // for time_log in self.env['mrp.workcenter.productivity'].search([
            //     ('workcenter_id', 'in', self.ids),
            //     ('date_end', '=', False),
            // ]):
            //     wc = time_log.workcenter_id
            //     if wc not in time_log_by_workcenter:
            //         time_log_by_workcenter[wc] = time_log
            // 
            // for workcenter in self:
            //     time_log = time_log_by_workcenter.get(workcenter._origin)
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
            //     [('workcenter_id', 'in', self.ids), ('state', 'in', ('blocked', 'ready')), ('date_start', '<', datetime.now().strftime('%Y-%m-%d'))],
            //     ['workcenter_id'], ['__count'])
            // count_data = {workcenter.id: count for workcenter, count in data}
            // # Count All, Pending, Ready, Progress Workorder
            // res = MrpWorkorder._read_group(
            //     [('workcenter_id', 'in', self.ids)],
            //     ['workcenter_id', 'state'], ['duration_expected:sum', '__count'])
            // for workcenter, state, duration_sum, count in res:
            //     result[workcenter.id][state] = count
            //     if state in ('blocked', 'ready', 'progress'):
            //         result_duration_expected[workcenter.id] += duration_sum
            // for workcenter in self:
            //     workcenter.workorder_count = sum(count for state, count in result[workcenter.id].items() if state not in ('done', 'cancel'))
            //     workcenter.workorder_blocked_count = result[workcenter.id].get('blocked', 0)
            //     workcenter.workcenter_load = result_duration_expected[workcenter.id]
            //     workcenter.workorder_ready_count = result[workcenter.id].get('ready', 0)
            //     workcenter.workorder_progress_count = result[workcenter.id].get('progress', 0)
            //     workcenter.workorder_late_count = count_data.get(workcenter.id, 0)
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

        public async Task<TEntity> ConstrainsDeductibleAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _constrains_deductible_amount(self):
            // for line in self:
            //     if not line.move_id.is_purchase_document() and float_compare(line.deductible_amount, 100, precision_digits=2):
            //         raise ValidationError(_("Only vendor bills allow for deductibility of product/services."))
            //     if line.deductible_amount < 0 or line.deductible_amount > 100:
            //         raise ValidationError(_("The deductibility must be a value between 0 and 100."))
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
            //     if line.display_type in ('line_section', 'line_subsection', 'line_note'):
            //         del vals['balance']
            //         del vals['account_id']
            //     # Will be recomputed from the price_unit
            //     if line.display_type == 'product' and line.move_id.is_invoice(True):
            //         del vals['balance']
            //     if self.env.context.get('include_business_fields'):
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
            //      self.env.protecting(self.env['account.move']._get_protected_vals({}, moves)), \
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
            // # Remove analytic lines created for draft AMLs, after analytic_distribution has been updated
            // lines.filtered(lambda l: l.parent_state == 'draft').analytic_line_ids.with_context(skip_analytic_sync=True).unlink()
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
            // expenses.update_activities_and_mails()
            // return expenses
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def create(self, vals_list):
            // for values in vals_list:
            //     if values.get('display_type', self.default_get(['display_type'])['display_type']):
            //         values.update(product_id=False, price_unit=0, product_uom_qty=0, product_uom_id=False, date_planned=False)
            //     else:
            //         values.update(self._prepare_add_missing_fields(values))
            //     if values.get('price_unit') and not values.get('technical_price_unit'):
            //         values['technical_price_unit'] = values['price_unit']
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

        public async Task<TEntity> CreateCompanyPaidMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _create_company_paid_moves(self):
            // """
            // Creation of the account moves for the company paid expenses.
            // -> Create an account payment (we only "log" the already paid expense so it can be reconciled)
            // """
            // self = self.with_context(clean_context(self.env.context))  # remove default_*
            // company_account_expenses = self.filtered(lambda expense: expense.payment_mode == 'company_account')
            // moves_sudo = self.env['account.move'].sudo()
            // 
            // if company_account_expenses:
            //     move_vals_list, payment_vals_list = zip(*[expense._prepare_payments_vals() for expense in company_account_expenses])
            // 
            //     payment_moves_sudo = self.env['account.move'].sudo().create(move_vals_list)
            //     for payment_vals, move in zip(payment_vals_list, payment_moves_sudo):
            //         payment_vals['move_id'] = move.id
            // 
            //     payments_sudo = self.env['account.payment'].sudo().create(payment_vals_list)
            //     for payment_sudo, move_sudo in zip(payments_sudo, payment_moves_sudo):
            //         move_sudo.update({
            //             'origin_payment_id': payment_sudo.id,
            //             # We need to put the journal_id because editing origin_payment_id triggers a re-computation chain
            //             # that voids the company_currency_id of the lines
            //             'journal_id': move_sudo.journal_id.id,
            //         })
            // 
            //     moves_sudo |= payment_moves_sudo
            // 
            // # returning the move with the superuser flag set back as it was at the origin of the call
            // return moves_sudo.sudo(self.env.su)
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
            // # early return to prevent endless recursive computation of reconcile plan
            // if not exchange_diff_values_list:
            //     return self.env['account.move']
            // 
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
            // # ==== Create the moves ====
            // exchange_moves = self.env['account.move'].with_context(no_exchange_difference=True).create(exchange_move_values_list)
            // # The reconciliation of exchange moves is now dealt thanks to the reconciled_lines_ids field
            // 
            // # ==== See if the exchange moves need to be posted or not ====
            // exchange_moves_to_post = self.env['account.move']
            // for exchange_move, vals in zip(exchange_moves, exchange_diff_values_list):
            //     if vals['to_post']:
            //         exchange_moves_to_post |= exchange_move
            // 
            // if exchange_moves_to_post:
            //     exchange_moves_to_post._post(soft=False)
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
            //     vals = {
            //         'name': self._get_untitled_expense_name(format_date(self.env, fields.Date.context_today(self))),
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
            // return expenses.ids
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
            //         'product_uom_id': self.product_uom_id.id,
            //         'product_tmpl_id': self.product_id.product_tmpl_id.id,
            //         'price': self.price_unit,
            //         'currency_id': self.requisition_id.currency_id.id,
            //         'purchase_requisition_line_id': self.id,
            //     })
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _creation_message(self):
            // if self.env.context.get('from_split_wizard'):
            //     return _("Expense created from a split.")
            // return super()._creation_message()
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

        public async Task<TEntity> DateInThePastInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _date_in_the_past(self):
            // if not 'accrual_entry_date' in self.env.context:
            //     return False
            // accrual_date = fields.Date.from_string(self.env.context['accrual_entry_date'])
            // return accrual_date < fields.Date.today()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _date_in_the_past(self):
            // if not 'accrual_entry_date' in self.env.context:
            //     return False
            // accrual_date = fields.Date.from_string(self.env.context['accrual_entry_date'])
            // return accrual_date < fields.Date.today()
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

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def default_get(self, fields):
            // defaults = super().default_get(fields)
            // quick_encode_suggestion = self.env.context.get('quick_encoding_vals')
            // if quick_encode_suggestion and self.env.context.get('default_display_type') not in ('line_section', 'line_subsection', 'line_note'):
            //     defaults['account_id'] = quick_encode_suggestion['account_id']
            //     defaults['price_unit'] = quick_encode_suggestion['price_unit']
            //     defaults['tax_ids'] = [Command.set(quick_encode_suggestion['tax_ids'])]
            // elif (journal := self.env['account.journal'].browse(self.env.context.get('journal_id'))) and journal.default_account_id:
            //     defaults['account_id'] = journal.default_account_id
            // return defaults
            */
            return default;
        }

        public async Task<TEntity> DoApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object check) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _do_approve(self, check=True):
            // if check:
            //     self._check_can_approve()
            // expenses_to_approve = self.filtered(lambda s: s.state in {'submitted', 'draft'})
            // for expense in expenses_to_approve:
            //     expense.write({
            //         'approval_state': 'approved',
            //         'manager_id': self.env.user.id,
            //         'approval_date': fields.Datetime().now(),
            //     })
            // self.update_activities_and_mails()
            */
            return default;
        }

        public async Task<TEntity> DoRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reason) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _do_refuse(self, reason):
            // # Sudoed as approvers may not be accountants
            // draft_moves_sudo = self.sudo().account_move_id.filtered(lambda move: move.state == 'draft')
            // if self.sudo().account_move_id - draft_moves_sudo:
            //     raise UserError(_("You cannot cancel an expense linked to a posted journal entry"))
            // 
            // if draft_moves_sudo:
            //     draft_moves_sudo.unlink()  # Else we have lingering moves
            // 
            // self.approval_state = 'refused'
            // subtype_id = self.env['ir.model.data']._xmlid_to_res_id('mail.mt_comment')
            // for expense in self:
            //     expense.message_post_with_source(
            //         'hr_expense.hr_expense_template_refuse_reason',
            //         subtype_id=subtype_id,
            //         render_values={'reason': reason, 'name': expense.name},
            //     )
            // self.update_activities_and_mails()
            */
            return default;
        }

        public async Task<TEntity> DoResetApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _do_reset_approval(self):
            // self.sudo().write({'approval_state': False, 'approval_date': False, 'account_move_id': False})
            // self.update_activities_and_mails()
            */
            return default;
        }

        public async Task<TEntity> DomainProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _domain_product_id(self):
            // return [('sale_ok', '=', True)]
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

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string field_expr, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _field_to_sql(self, alias: str, field_expr: str, query: (Query | None) = None) -> SQL:
            // fname, property_name = fields.parse_field_expr(field_expr)
            // if fname != 'payment_date':
            //     return super()._field_to_sql(alias, field_expr, query)
            // sql = SQL("""
            //     CASE
            //          WHEN %(discount_date)s >= %(today)s THEN %(discount_date)s
            //          ELSE %(date_maturity)s
            //     END""",
            //     today=fields.Date.context_today(self),
            //     discount_date=super()._field_to_sql(alias, "discount_date", query),
            //     date_maturity=super()._field_to_sql(alias, "date_maturity", query),
            // )
            // if property_name:
            //     sql = self._field[fname].property_to_sql(sql, property_name, self, alias, query)
            // return sql
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
            // # We ignore Import matching numbers as they are not truly reconciled yet
            // matching_numbers = [n for n in set(self.mapped('matching_number')) if n and not n.startswith('I')]
            // 
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
            // # Hack to filter using another field.
            // domain = Domain(domain).map_conditions(lambda cond: Domain('distribution_analytic_account_ids', cond.operator, cond.value) if cond.field_expr == 'analytic_distribution' else cond)
            // return super().filtered_domain(domain)
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

        public async Task<TEntity> GetAmlValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_aml_values(self, **kwargs):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'account_id': self.account_id.id,
            //     'currency_id': self.currency_id.id,
            //     'amount_currency': self.amount_currency,
            //     'balance': self.balance,
            //     'reconcile_model_id': self.reconcile_model_id.id,
            //     'analytic_distribution': self.analytic_distribution,
            //     'tax_repartition_line_id': self.tax_repartition_line_id.id,
            //     'tax_ids': [Command.set(self.tax_ids.ids)] + kwargs.pop('tax_ids', []),
            //     'tax_tag_ids': [Command.set(self.tax_tag_ids.ids)],
            //     'group_tax_id': self.group_tax_id.id,
            //     'partner_id': self.partner_id.id,
            //     **kwargs,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAnalyticAccountIdsFromDistributionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object distributions) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _get_analytic_account_ids_from_distributions(self, distributions):
            // if not distributions:
            //     return []
            // 
            // if isinstance(distributions, (list, tuple, set)):
            //     return {int(_id) for distribution in distributions for key in (distribution or {}) for _id in key.split(',')}
            // else:
            //     return {int(_id) for key in (distributions or {}) for _id in key.split(',')}
            */
            return default;
        }

        public async Task<TEntity> GetAnalyticDistributionArgumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object root_plans) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_analytic_distribution_arguments(self, root_plans):
            // """
            // Get arguments to determine analytic distribution.
            // This function aims to be overridden by partner submodules
            // :param root_plans: account.analytic.plan recordset
            // :return: dict
            // """
            // arguments = {
            //     "product_id": self.product_id.id,
            //     "product_categ_id": self.product_id.categ_id.id,
            //     "partner_id": self.partner_id.id,
            //     "partner_category_id": self.partner_id.category_id.ids,
            //     "account_prefix": self.account_id.code,
            //     "company_id": self.company_id.id,
            //     "related_root_plan_ids": root_plans,
            // }
            // return arguments
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

        public async Task<TEntity> GetAttachmentByRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object id_model2attachments, object move_line) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_attachment_by_record(self, id_model2attachments, move_line):
            // return (
            //     id_model2attachments.get(('account.move', move_line.move_id.id))
            //     or id_model2attachments.get(('account.bank.statement', move_line.statement_id.id))
            //     or id_model2attachments.get(('account.payment', move_line.payment_id.id))
            // )
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentDomainsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_attachment_domains(self):
            // domains = [[
            //     ('res_model', '=', 'account.move'),
            //     ('res_id', 'in', self.move_id.ids),
            //     ('res_field', 'in', (False, 'invoice_pdf_report_file')),
            // ]]
            // if self.statement_id:
            //     domains.append([('res_model', '=', 'account.bank.statement'), ('res_id', 'in', self.statement_id.ids)])
            // if self.payment_id:
            //     domains.append([('res_model', '=', 'account.payment'), ('res_id', 'in', self.payment_id.ids)])
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
            // 3. expense account of the company
            // 4. expense account on the purchase journal for employee expense
            // """
            // 
            // # expense account of the expense itself
            // account = self.account_id
            // if account:
            //     return account
            // 
            // # expense account of the product then the product category
            // if self.product_id:
            //     account = self.product_id.product_tmpl_id._get_product_accounts()['expense']
            // else:
            //     account = self.env.company.expense_account_id
            // 
            // if account:
            //     return account
            // 
            // # expense account on the purchase journal for employee expense
            // journal = self.journal_id
            // if journal.type == 'purchase':
            //     account = journal.default_account_id
            // 
            // if not account:
            //     raise UserError(self.env._(
            //         "Odoo had a look at your expense, its product, your company and the journal but came back with empty hands.\n"
            //         "Give Odoo a hand to find an account by setting up an expense account.\n"
            //         "%(expense)s %(expense_name)s.\n",
            //         expense=self,
            //         expense_name=self.name,
            //     ))
            // return account
            */
            return default;
        }

        public async Task<TEntity> GetCannotApproveReasonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_cannot_approve_reason(self):
            // """ Returns the reason why the user cannot approve the expense """
            // is_team_approver = self.env.user.has_group('hr_expense.group_hr_expense_team_approver') or self.env.su
            // is_approver = self.env.user.has_group('hr_expense.group_hr_expense_user') or self.env.su
            // is_hr_admin = self.env.user.has_group('hr_expense.group_hr_expense_manager') or self.env.su
            // 
            // valid_company_ids = set(self.env.companies.ids)
            // 
            // expenses_employee_ids_under_user_ones = set()
            // if is_team_approver:  # We don't need to search if the user has not the required rights
            //     expenses_employee_ids_under_user_ones = set(
            //         self.env['hr.employee'].sudo().search([
            //             ('id', 'in', self.employee_id.ids),
            //             ('id', 'child_of', self.env.user.employee_ids.ids),
            //             ('id', 'not in', self.env.user.employee_ids.ids),
            //         ]).ids
            //     )
            // reasons_per_record_id = {}
            // for expense in self:
            //     reason = False
            //     expense_employee = expense.employee_id
            //     is_expense_team_approver = (
            //             is_team_approver  # Admins are team approvers, not necessarily direct parents
            //             or expense_employee.id in expenses_employee_ids_under_user_ones
            //             or (expense_employee.expense_manager_id == self.env.user)
            //     )
            //     if expense.company_id.id not in valid_company_ids:
            //         reason = _(
            //             "%(expense_name)s: Your are neither a Manager nor a HR Officer of this expense's company",
            //             expense_name=expense.name,
            //         )
            // 
            //     elif not is_expense_team_approver:
            //         reason = _("%(expense_name)s: You are neither a Manager nor a HR Officer", expense_name=expense.name)
            // 
            //     elif not is_hr_admin:
            //         current_managers = (
            //                 expense_employee.expense_manager_id
            //                 | expense_employee.sudo().department_id.manager_id.user_id.sudo(self.env.su)
            //                 | expense.manager_id
            //         )
            //         if expense_employee.id in expenses_employee_ids_under_user_ones:
            //             current_managers |= self.env.user
            // 
            //         if expense_employee.user_id == self.env.user:
            //             reason = _("%(expense_name)s: It is your own expense", expense_name=expense.name)
            // 
            //         elif self.env.user not in current_managers and not is_approver:
            //             reason = _("%(expense_name)s: It is not from your department", expense_name=expense.name)
            //     reasons_per_record_id[expense.id] = reason
            // return reasons_per_record_id
            */
            return default;
        }

        public async Task<TEntity> GetCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object unit, object default_capacity) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py) ---
            // def _get_capacity(self, product, unit, default_capacity=1):
            // capacity = self.capacity_ids.sorted(lambda c: (
            //     not (c.product_id == product and c.product_uom_id == product.uom_id),
            //     not (not c.product_id and c.product_uom_id == unit),
            //     not (not c.product_id and c.product_uom_id == product.uom_id),
            // ))[:1]
            // if capacity and capacity.product_id in [product, self.env['product.product']] and capacity.product_uom_id in [product.uom_id, unit]:
            //     if float_is_zero(capacity.capacity, 0):
            //         return (default_capacity, capacity.time_start, capacity.time_stop)
            //     return (capacity.product_uom_id._compute_quantity(capacity.capacity, unit), capacity.time_start, capacity.time_stop)
            // return (default_capacity, self.time_start, self.time_stop)
            */
            return default;
        }

        public async Task<TEntity> GetChildLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_child_lines(self):
            // """
            // Return a tax-wise summary of account move lines linked to section.
            // Groups lines by their tax IDs and computes subtotal and total for each group.
            // """
            // self.ensure_one()
            // 
            // section_lines = self.move_id.invoice_line_ids.filtered(lambda l: (l.parent_id == self or l.parent_id.parent_id == self))
            // result = []
            // for taxes, lines_for_tax_group in groupby(section_lines, key=lambda l: l.tax_ids):
            //     lines_for_tax_group = sum(lines_for_tax_group, start=self.env['account.move.line'])
            //     tax_labels = [tax.tax_label for tax in taxes if tax.tax_label]
            //     for section_line, move_lines in lines_for_tax_group.sorted('sequence').grouped('parent_id').items():
            //         lines_to_sum = move_lines if section_line != self else lines_for_tax_group
            //         subtotal = sum(l.price_subtotal for l in lines_to_sum)
            //         total = sum(l.price_total for l in lines_to_sum)
            //         if not subtotal and not tax_labels:
            //             continue
            //         elif section_line.collapse_composition or section_line.parent_id.collapse_composition:
            //             result.append({
            //                 'name': section_line.name,
            //                 'taxes': tax_labels if not section_line.parent_id.collapse_prices else [],
            //                 'price_subtotal': subtotal,
            //                 'price_total': total,
            //                 'display_type': 'product',
            //                 'quantity': 1,
            //                 'line_uom': False,
            //                 'product_uom': False,
            //                 'discount': 0.0,
            //             })
            //         else:
            //             for line in (section_line | move_lines):
            //                 result.append({
            //                     'name': line.name,
            //                     'taxes': tax_labels if line == self else [],
            //                     'price_subtotal': subtotal if line == section_line else line.price_subtotal,
            //                     'price_total': total if line == section_line else line.price_total,
            //                     'display_type': line.display_type,
            //                     'quantity': line.quantity,
            //                     'line_uom': line.product_uom_id,
            //                     'product_uom': line.product_id.uom_id,
            //                     'discount': line.discount,
            //                 })
            // 
            // return result or [{
            //     'name': self.name,
            //     'taxes': [],
            //     'price_subtotal': 0.0,
            //     'price_total': 0.0,
            //     'quantity': 0,
            //     'display_type': 'product',
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetColumnToExcludeForColspanCalculationAsync<TEntity>(IEnumerable<TEntity> entities, object taxes) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_column_to_exclude_for_colspan_calculation(self, taxes=None):
            // return False
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
            //     ) for combo_id in combo_line.product_template_id.sudo().combo_ids
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
            //     combo_prices[combo_line.product_template_id.sudo().combo_ids[-1]] += combo_price_delta
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

        public async Task<TEntity> GetComboTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object totals_field) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_combo_totals(self, totals_field):
            // """Return the total/subtotal amount sale order lines linked to combo."""
            // self.ensure_one()
            // combo_item_lines = self.order_id.order_line.filtered(
            //     lambda line: line.linked_line_id == self and line.combo_item_id,
            // )
            // return sum(combo_item_lines.mapped(totals_field))
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
            // elif self.env.context.get('account_default_taxes'):
            //     tax_ids = self.account_id.tax_ids
            // 
            // else:
            //     tax_ids = False if self.env.context.get('skip_computed_taxes') or self.move_id.is_entry() else self.account_id.tax_ids
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

        public async Task<TEntity> GetDefaultReadFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_default_read_fields(self):
            // weirdos = {'term_key', 'epd_key', 'epd_needed', 'discount_allocation_key', 'discount_allocation_needed'}
            // return [fname for fname in self.fields_get(attributes=()) if fname not in weirdos]
            */
            return default;
        }

        public async Task<TEntity> GetDefaultResponsibleForApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_default_responsible_for_approval(self):
            // self.ensure_one()
            // approver_group = 'hr_expense.group_hr_expense_team_approver'
            // 
            // employee = self.employee_id.sudo()
            // expense_manager = employee.expense_manager_id - employee.user_id
            // if expense_manager:
            //     return expense_manager.sudo(False)
            // 
            // department_manager = employee.department_id.manager_id.user_id - employee.user_id
            // if department_manager and department_manager.has_groups(approver_group):
            //     return department_manager.sudo(False)
            // 
            // employee_team_leader = employee.parent_id.user_id
            // if employee_team_leader:
            //     return employee_team_leader.sudo(False)
            // 
            // return self.env['res.users']
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
            // """ Compute and return the delivered quantity of current SO lines,
            //     based on their related analytic lines.
            //     :param additional_domain: domain to restrict AAL to include in computation (required since timesheet is an AAL with a project ...)
            // """
            // result = defaultdict(float)
            // 
            // # avoid recomputation if no SO lines concerned
            // if not self:
            //     return result
            // 
            // # group analytic lines by product uom and so line
            // domain = Domain.AND([[('so_line', 'in', self.ids)], additional_domain])
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
            //     qty = uom._compute_quantity(qty, so_line.product_uom_id, rounding_method='HALF-UP')
            //     result[so_line.id] += qty
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetDiscountedPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_discounted_price(self):
            // self.ensure_one()
            // return self.price_unit * (1 - (self.discount or 0.0) / 100.0)
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
            // if not email_address:
            //     return self.env['hr.employee']
            // employee = self.env['hr.employee'].search([
            //     ('user_id', '!=', False), '|', ('work_email', 'ilike', email_address), ('user_id.email', 'ilike', email_address),
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

        public async Task<TEntity> GetExpenseAccountDestinationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_expense_account_destination(self):
            // # account.move used to allow having several expenses with payment_mode = 'company_account'.
            // # This method needs to support processing several expenses to allow reconciliation of old account.move.line
            // ids = set()
            // for expense in self:
            //     if expense.payment_mode == 'company_account':
            //         account_dest = expense.payment_method_line_id.payment_account_id or expense._get_outstanding_account_id()
            //     elif not expense.employee_id.sudo().work_contact_id:
            //         raise UserError(self.env._(
            //             "No work contact found for the employee %(name)s, please configure one.",
            //             name=expense.employee_id.name,
            //         ))
            //     else:
            //         partner = expense.employee_id.sudo().work_contact_id.with_company(expense.company_id)
            //         account_dest = partner.property_account_payable_id or partner.parent_id.property_account_payable_id
            //     ids.add(account_dest.id)
            // 
            // # mimics <account.account>.id
            // if not ids:
            //     return False
            // if len(ids) > 1:
            //     raise UserError(self.env._(
            //         "The following expenses payment method leads to several accounts payable and this isn't supported:\n%(expenses)s",
            //         expenses=self.browse(ids),
            //     ))
            // return ids.pop()
            */
            return default;
        }

        public async Task<TEntity> GetExpenseDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_expense_dashboard(self):
            // expense_state = {
            //     'draft': {
            //         'description': _("To Submit"),
            //         'amount': 0.0,
            //         'currency': self.env.company.currency_id.id,
            //     },
            //     'submitted': {
            //         'description': _("Waiting Approval"),
            //         'amount': 0.0,
            //         'currency': self.env.company.currency_id.id,
            //     },
            //     'approved': {
            //         'description': _("Waiting Reimbursement"),
            //         'amount': 0.0,
            //         'currency': self.env.company.currency_id.id,
            //     }
            // }
            // if not self.env.user.employee_ids:
            //     return expense_state
            // # Counting the expenses to display in the dashboard:
            // # - To Submit: contains the expenses paid either by the employee or by the company, and that are draft or reported
            // # - Waiting approval: contains expenses paid by the employee or paid by the company, and that have been submitted but still need to be approved/refused
            // # - To be reimbursed: contains ONLY expenses paid by the employee that are approved, the payment has not yet been made
            // fetched_expenses = self._read_group(
            //     [
            //         ('employee_id', 'in', self.env.user.employee_ids.ids),
            //         '|', ('state', 'in', ('draft', 'submitted')),
            //              '&', ('payment_mode', '=', 'own_account'), ('state', '=', 'approved')
            //     ], ['state'], ['total_amount:sum'])
            // for state, total_amount_sum in fetched_expenses:
            //     expense_state[state]['amount'] += total_amount_sum
            // return expense_state
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
            // ICP = self.env['ir.config_parameter'].sudo()
            // max_planning_iterations = max(int(ICP.get_param('mrp.workcenter_max_planning_iterations', '50')), 1)
            // resource = self.resource_id
            // revert = to_timezone(start_datetime.tzinfo)
            // start_datetime = localized(start_datetime)
            // get_available_intervals = partial(self.resource_calendar_id._work_intervals_batch, resources=resource, tz=timezone(self.resource_calendar_id.tz))
            // workorder_intervals_leaves_domain = [('time_type', '=', 'other')]
            // if leaves_to_ignore:
            //     workorder_intervals_leaves_domain.append(('id', 'not in', leaves_to_ignore.ids))
            // get_workorder_intervals = partial(self.resource_calendar_id._leave_intervals_batch, domain=workorder_intervals_leaves_domain, resources=resource, tz=timezone(self.resource_calendar_id.tz))
            // extra_leaves_slots_intervals = Intervals([(localized(start), localized(stop), self.env['resource.calendar.attendance']) for start, stop in extra_leaves_slots])
            // 
            // remaining = duration = max(duration, 1 / 60)
            // now = localized(datetime.now())
            // delta = timedelta(days=14)
            // start_interval, stop_interval = None, None
            // for n in range(max_planning_iterations):  # 50 * 14 = 700 days in advance
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
            // if self.tax_ids:
            //     qty = self.product_qty or 1
            //     price_unit = self.tax_ids.compute_all(
            //         price_unit,
            //         currency=self.order_id.currency_id,
            //         quantity=qty,
            //         rounding_method='round_globally',
            //     )['total_void']
            //     price_unit = price_unit / qty
            // if self.product_uom_id.id != self.product_id.uom_id.id:
            //     price_unit *= self.product_id.uom_id.factor / self.product_uom_id.factor
            // return price_unit
            */
            return default;
        }

        public async Task<TEntity> GetGroupedSectionSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object display_taxes) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_grouped_section_summary(self, display_taxes=True):
            // """Return a tax-wise summary of sales order lines linked to section.
            // 
            // Group lines by their tax IDs and computes subtotal and total for each group.
            // """
            // self.ensure_one()
            // 
            // section_lines = self.order_id.order_line.filtered(self._is_line_in_section)
            // 
            // if display_taxes:
            //     res = [
            //         {
            //             'tax_labels': [tax.tax_label for tax in taxes if tax.tax_label],
            //             'price_subtotal': sum(lines.mapped('price_subtotal')),
            //             'price_total': sum(lines.mapped('price_total')),
            //         }
            //         for taxes, lines in section_lines.grouped('tax_ids').items()
            //     ]
            // else:
            //     res = [{
            //         'tax_labels': [],
            //         'price_subtotal': sum(section_lines.mapped('price_subtotal')),
            //         'price_total': sum(section_lines.mapped('price_total')),
            //     }]
            // return res or [{
            //     'tax_labels': [],
            //     'price_subtotal': 0.0,
            //     'price_total': 0.0,
            // }]
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
            // term_lines = self.sorted(key=lambda line: (line.date_maturity or date.max, line.date))
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
            // hash_version = self.env.context.get('hash_version', MAX_HASH_VERSION)
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
            // if self.env.context.get('accrual_entry_date'):
            //     accrual_date = fields.Date.from_string(self.env.context['accrual_entry_date'])
            //     return self.invoice_lines.filtered(
            //         lambda l: l.move_id.invoice_date and l.move_id.invoice_date <= accrual_date
            //     )
            // else:
            //     return self.invoice_lines
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_invoice_lines(self):
            // self.ensure_one()
            // if self.env.context.get('accrual_entry_date'):
            //     accrual_date = fields.Date.from_string(self.env.context['accrual_entry_date'])
            //     return self.invoice_lines.filtered(
            //         lambda l: l.move_id.invoice_date and l.move_id.invoice_date <= accrual_date
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
            // return name if not display_name or display_name in name else f"{display_name}\n{name}"
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
            // if self.product_type == 'combo':
            //     # Only consider combo item lines (not optional product lines)
            //     return self.linked_line_ids.filtered('combo_item_id')
            // return self
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

        public async Task<TEntity> GetMatchedMoveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_matched_move_ids(self):
            // """ Return a record set with both self.matched_debit_ids & self.matched_credit_ids """
            // return self.matched_debit_ids | self.matched_credit_ids
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

        public async Task<TEntity> GetOutstandingAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_outstanding_account_id(self):
            // account_ref = 'account_journal_payment_debit_account_id' if self.payment_method_line_id.payment_type == 'inbound' else 'account_journal_payment_credit_account_id'
            // chart_template = self.with_context(allowed_company_ids=self.company_id.root_id.ids).env['account.chart.template']
            // outstanding_account = chart_template.ref(account_ref, raise_if_not_found=False)
            // if not outstanding_account:
            //     bank_prefix = self.company_id.bank_account_code_prefix
            //     first_account = self.env['account.account'].search([('company_ids', 'in', self.company_id.id)], limit=1)
            //     code_digits = len(first_account.code or '') or 6
            //     chart_template._create_outstanding_accounts(self.company_id, bank_prefix, code_digits)
            //     outstanding_account = chart_template.ref(account_ref, raise_if_not_found=False)
            // if not outstanding_account.active:
            //     raise RedirectWarning(
            //         message=_("The account %(name)s (%(code)s) is archived. Activate it to continue", name=outstanding_account.name, code=outstanding_account.code),
            //         action=outstanding_account._get_records_action(),
            //         button_text=_("Go to Account"),
            //     )
            // return outstanding_account
            */
            return default;
        }

        public async Task<TEntity> GetParentSectionLineAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_parent_section_line(self):
            // if self.display_type == 'product' and self.parent_id.display_type == 'line_subsection':
            //     return self.parent_id.parent_id
            // 
            // return self.parent_id
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def get_parent_section_line(self):
            // if not self.display_type and self.parent_id.display_type == 'line_subsection':
            //     return self.parent_id.parent_id
            // 
            // return self.parent_id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def get_parent_section_line(self):
            // if not self.display_type and self.parent_id.display_type == 'line_subsection':
            //     return self.parent_id.parent_id
            // 
            // return self.parent_id
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

        public async Task<TEntity> GetPricelistKwargsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_pricelist_kwargs(self):
            // return {
            //     'quantity': self.product_uom_qty or 1.0,
            //     'uom': self.product_uom_id,
            //     'date': self._get_order_date(),
            //     'currency': self.currency_id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPricelistPriceBeforeDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_pricelist_price_before_discount(self):
            // """Compute the price used as base for the pricelist price computation.
            // :return: the product sales price in the order currency (without taxes)
            // :rtype: float
            // """
            // self.ensure_one()
            // self.product_id.ensure_one()
            // 
            // return self.pricelist_item_id._compute_price_before_discount(
            //     product=self.product_id.with_context(**self._get_product_price_context()),
            //     **self._get_pricelist_kwargs()
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
            //     'uom': self.product_uom_id.id,
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
            // return self.pricelist_item_id._compute_price(
            //     product=self.product_id.with_context(**self._get_product_price_context()),
            //     **self._get_pricelist_kwargs(),
            // )
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
            //         'uomDisplayName': len(self) == 1 and self.product_uom_id.display_name or self.product_id.uom_id.display_name,
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
            // ``PurchaseOrder._is_readonly`` for more details) or if `self` contains multiple records.
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
            //         'uomDisplayName': String,
            //         'packaging': dict,
            //         'warning': String,
            //     }
            // """
            // if len(self) == 1:
            //     catalog_info = self.order_id._get_product_price_and_data(self.product_id)
            //     catalog_info.update(
            //         quantity=self.product_qty,
            //         price=self.price_unit * (1 - self.discount / 100),
            //         readOnly=self.order_id._is_readonly(),
            //     )
            //     if self.product_id.uom_id != self.product_uom_id:
            //         catalog_info['uomDisplayName'] = self.product_uom_id.display_name
            //     return catalog_info
            // elif self:
            //     self.product_id.ensure_one()
            //     order_line = self[0]
            //     catalog_info = order_line.order_id._get_product_price_and_data(order_line.product_id)
            //     catalog_info['quantity'] = sum(self.mapped(
            //         lambda line: line.product_uom_id._compute_quantity(
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
            // ``SaleOrder._is_readonly`` for more details) or if `self` contains multiple records.
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
            //         'uomDisplayName': String,
            //     }
            // """
            // if len(self) == 1:
            //     return {
            //         'quantity': self.product_uom_qty,
            //         'price': self._get_discounted_price(),
            //         'readOnly': (
            //             self.order_id._is_readonly()
            //             or bool(self.combo_item_id)
            //         ),
            //         'uomDisplayName': self.product_uom_id.display_name,
            //     }
            // elif self:
            //     self.product_id.ensure_one()
            //     order_line = self[0]
            //     order = order_line.order_id
            //     return {
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
            //                 lambda line: line.product_uom_id._compute_quantity(
            //                     qty=line.product_uom_qty,
            //                     to_unit=line.product_id.uom_id,
            //                 )
            //             )
            //         ),
            //         'uomDisplayName': self.product_id.uom_id.display_name,
            //     }
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
            //     'product_id', 'name', 'price_unit', 'product_uom_id', 'product_uom_qty',
            //     'tax_ids', 'analytic_distribution', 'discount'
            // ]
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
            //     description += "\n" + _(
            //         "Option for: %s",
            //         self.linked_line_id.product_id.with_context(display_default_code=False).display_name
            //     )
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
            // name = ""
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

        public async Task<TEntity> GetSectionLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _get_section_lines(self):
            // self.ensure_one()
            // return self.move_id.invoice_line_ids.filtered(self._is_line_in_section)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_section_lines(self):
            // self.ensure_one()
            // return self.order_id.order_line.filtered(self._is_line_in_section)
            */
            return default;
        }

        public async Task<TEntity> GetSectionSubtotalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def get_section_subtotal(self):
            // section_lines = self._get_section_lines()
            // return sum(section_lines.mapped('price_subtotal'))
            */
            return default;
        }

        public async Task<TEntity> GetSectionTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object totals_field) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _get_section_totals(self, totals_field):
            // """Return the total/subtotal amount sale order lines linked to section."""
            // self.ensure_one()
            // section_lines = self._get_section_lines()
            // return sum(section_lines.mapped(totals_field))
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
            //     "force_uom": True,
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
            //     'approval_state': self.approval_state,
            //     'approval_date': self.approval_date,
            //     'manager_id': self.manager_id.id,
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
            // return Domain([
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
            // ])
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

        public async Task<TEntity> GetUntitledExpenseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_untitled_expense_name(self, *args):
            // """ Done in a specific function to be called by hr_expense_extract to keep the same translation """
            // return _("Untitled Expense %s", *args)
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

        public async Task<TEntity> HasTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _has_taxes(self):
            // """Check if a line has taxes or not. For (sub)sections, check if any child line has taxes."""
            // self.ensure_one()
            // return bool(
            //     self.tax_ids
            //     or (self.display_type and any(line._has_taxes() for line in self._get_section_lines())),
            // )
            */
            return default;
        }

        public async Task<TEntity> HasValuedMoveIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def has_valued_move_ids(self):
            // return None
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
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
            // old_distributions = dict(self.env.execute_query(SQL(
            //     "SELECT id, analytic_distribution FROM account_move_line WHERE id = ANY(%s)",
            //     self.ids,
            // )))
            // for line in self:
            //     line.analytic_distribution = self._merge_distribution(
            //         old_distribution=old_distributions.get(line._origin.id) or {},
            //         new_distribution=line.analytic_distribution or {},
            //     )
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
            //     line.is_storno = line.credit < 0
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
            //     line.is_storno = line.debit < 0
            //     if line.debit:
            //         line.credit = 0
            //     line.balance = line.debit - line.credit
            */
            return default;
        }

        public async Task<TEntity> InverseNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_no_followup(self):
            // # If one line of an invoice gets excluded from or included in the follow up report, we want all
            // # payable/receivable lines of that invoice to do the same.
            // for aml in self:
            //     move = aml.move_id
            //     if move.is_invoice():
            //         move.no_followup = aml.no_followup
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

        public async Task<TEntity> InverseReconciledLinesIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _inverse_reconciled_lines_ids(self):
            // self._reconcile_plan([
            //     line + line.reconciled_lines_ids
            //     for line in self
            // ])
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
            //         raise UserError(_(
            //             "Uh-oh! You can’t edit this expense.\n\n"
            //             "Reach out to the administrators, flash your best smile, and see if they'll grant you the magical access you seek."
            //         ))
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
            //         expense.untaxed_amount =  tax_details['total_excluded_currency']
            //     else:
            //         expense.total_amount_currency = expense.total_amount
            //         expense.tax_amount = expense.tax_amount_currency
            //         expense.untaxed_amount = expense.untaxed_amount_currency
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

        public async Task<TEntity> IsDiscountLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _is_discount_line(self):
            // self.ensure_one()
            // return self.product_id in self.company_id.sale_discount_product_id
            */
            return default;
        }

        public async Task<TEntity> IsGlobalDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _is_global_discount(self):
            // self.ensure_one()
            // return self.extra_tax_data and self.extra_tax_data.get('computation_key', '').startswith('global_discount,')
            */
            return default;
        }

        public async Task<TEntity> IsLineInSectionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _is_line_in_section(self, line):
            // """Return whether the line is a direct or indirect child of the section."""
            // self.ensure_one()
            // is_direct_child = line.parent_id == self
            // is_indirect_child = (
            //     self.display_type == 'line_section'
            //     and line.parent_id
            //     and line.parent_id.display_type == 'line_subsection'
            //     and line.parent_id.parent_id == self
            // )
            // return is_direct_child or is_indirect_child
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _is_line_in_section(self, line):
            // """Return whether the line is a direct or indirect child of the section."""
            // self.ensure_one()
            // is_direct_child = line.parent_id == self and not line.display_type
            // is_indirect_child = (
            //     self.display_type == 'line_section'
            //     and line.parent_id
            //     and line.parent_id.display_type == 'line_subsection'
            //     and line.parent_id.parent_id == self
            // )
            // return is_direct_child or is_indirect_child
            */
            return default;
        }

        public async Task<Dictionary<string, object>> MergeDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> old_distribution, Dictionary<string, object> new_distribution) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _merge_distribution(self, old_distribution: dict, new_distribution: dict) -> dict:
            // if '__update__' not in new_distribution:
            //     return new_distribution  # update everything by default
            // 
            // non_changing_values, changing_values, non_changing_amount, changing_amount = self._modifiying_distribution_values(
            //     old_distribution,
            //     new_distribution,
            // )
            // if non_changing_amount > changing_amount:
            //     ratio = changing_amount / non_changing_amount
            //     additional_vals = {
            //         ','.join(map(str, old_key)): old_val * (1 - ratio)
            //         for old_key, old_val in non_changing_values.items()
            //         if old_key
            //     }
            //     ratio = 1
            // elif changing_amount > non_changing_amount:
            //     ratio = non_changing_amount / changing_amount
            //     additional_vals = {
            //         ','.join(map(str, new_key)): new_val * (1 - ratio)
            //         for new_key, new_val in changing_values.items()
            //         if new_key
            //     }
            // else:
            //     ratio = 1
            //     additional_vals = {}
            // 
            // return {
            //     ','.join(map(str, old_key + new_key)): ratio * old_val * new_val / non_changing_amount
            //     for old_key, old_val in non_changing_values.items()
            //     for new_key, new_val in changing_values.items()
            // } | additional_vals
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

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _message_auto_subscribe_followers(self, updated_values, subtype_ids):
            // res = super()._message_auto_subscribe_followers(updated_values, subtype_ids)
            // if updated_values.get('employee_id'):
            //     employee_user = self.env['hr.employee'].browse(updated_values['employee_id']).user_id
            //     if employee_user:
            //         res.append((employee_user.partner_id.id, subtype_ids, False))
            // return res
            */
            return default;
        }

        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // email_address = email_normalize(msg_dict.get('email_from'))
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

        public async Task<TEntity> ModifiyingDistributionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_distribution, object new_distribution) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _modifiying_distribution_values(self, old_distribution, new_distribution):
            // fnames_to_update = set(new_distribution.pop('__update__', ()))
            // if old_distribution:
            //     old_distribution.pop('__update__', None)  # might be set before in `create`
            // project_plan, other_plans = self.env['account.analytic.plan']._get_all_plans()
            // non_changing_plans = {
            //     plan
            //     for plan in project_plan + other_plans
            //     if plan._column_name() not in fnames_to_update
            // }
            // 
            // non_changing_values = defaultdict(float)
            // non_changing_amount = 0
            // for old_key, old_val in old_distribution.items():
            //     remaining_key = tuple(sorted(
            //         account.id
            //         for account in self.env['account.analytic.account'].browse(int(aid) for aid in old_key.split(','))
            //         if account.plan_id.root_id in non_changing_plans
            //     ))
            //     if remaining_key:
            //         non_changing_values[remaining_key] += old_val
            //         non_changing_amount += old_val
            // 
            // changing_values = defaultdict(float)
            // changing_amount = 0
            // for new_key, new_val in new_distribution.items():
            //     remaining_key = tuple(sorted(
            //         account.id
            //         for account in self.env['account.analytic.account'].browse(int(aid) for aid in new_key.split(','))
            //         if account.plan_id.root_id not in non_changing_plans
            //     ))
            //     if remaining_key:
            //         changing_values[remaining_key] += new_val
            //         changing_amount += new_val
            // 
            // return non_changing_values, changing_values, non_changing_amount, changing_amount
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
            // elif self.amount_type in ('regex', 'from_transaction_details'):
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
            // if not self.product_has_cost and self.state == 'draft':
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
            // self.price_unit = self.product_qty = self.technical_price_unit = 0.0
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
            //     if self.env.context.get('reduced_line_sorting'):
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

        public async Task<TEntity> PostWithoutWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _post_without_wizard(self):
            // """ Post an employee expense without any direct call for the wizard, should never be called unless in very specific flows """
            // # When a move has been deleted
            // self._check_can_create_move()
            // today = fields.Date.context_today(self)
            // employee_expenses = self.filtered(lambda expense: expense.payment_mode == 'own_account')
            // 
            // for company, expenses in employee_expenses.grouped('company_id').items():
            //     expenses = expenses.with_company(company)
            //     company_domain = self.env['account.journal']._check_company_domain(company)
            //     journal = (
            //             company.expense_journal_id
            //             or expenses.env['account.journal'].search([*company_domain, ('type', '=', 'purchase')], limit=1))
            //     expense_receipt_vals_list = [
            //         {
            //             **new_receipt_vals,
            //             'journal_id': journal.id,
            //             'invoice_date': today,
            //         }
            //         for new_receipt_vals in expenses._prepare_receipts_vals()
            //     ]
            //     moves = self.env['account.move'].sudo().create(expense_receipt_vals_list)
            //     for move in moves:
            //         move._message_set_main_attachment_id(move.attachment_ids, force=True, filter_xml=False)
            //     moves.action_post()
            */
            return default;
        }

        public async Task<TEntity> PostWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _post_wizard(self):
            // if 'company_account' in set(self.mapped('payment_mode')):
            //     raise UserError(_("Only expense paid by the employee can be posted with the wizard"))
            // 
            // wizard_name = (
            //     _("Post expenses paid by the employee")
            //     if self.env.context.get('company_paid_move_ids')
            //     else _("Post expenses")
            // )
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': wizard_name,
            //     'view_mode': 'form',
            //     'views': [(False, "form")],
            //     'res_model': 'hr.expense.post.wizard',
            //     'res_id': self.env['hr.expense.post.wizard'].create({}).id,
            //     'target': 'new',
            //     'context': self.with_context(active_ids=self.ids).env.context,
            // }
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
            //     'product_uom_id': self.product_uom_id.id,
            //     'quantity': -self.qty_to_invoice if move and move.move_type == 'in_refund' else self.qty_to_invoice,
            //     'discount': self.discount,
            //     'price_unit': self.currency_id._convert(self.price_unit, aml_currency, self.company_id, date, round=False),
            //     'tax_ids': [(6, 0, self.tax_ids.ids)],
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
            // onchange_fields = ['name', 'price_unit', 'product_qty', 'product_uom_id', 'tax_ids', 'date_planned']
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
            //     'user_id': self.move_id.invoice_user_id.id or self.env.uid,
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
            //         if not self.company_currency_id.is_zero(line_values.get('amount')):
            //             analytic_line_vals.append(line_values)
            // 
            //     self._round_analytic_distribution_line(analytic_line_vals)
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
            //     **{'partner_id': self.vendor_id, 'special_mode': 'total_included', 'rate': self.currency_rate, **kwargs},
            // )
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_base_line_for_taxes_computation(self):
            // """ Convert the current record to a dictionary in order to use the generic taxes computation method
            // defined on account.tax.
            // 
            // :return: A python dictionary.
            // """
            // self.ensure_one()
            // company = self.order_id.company_id or self.env.company
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     self,
            //     tax_ids=self.tax_ids,
            //     quantity=self.product_qty,
            //     partner_id=self.order_id.partner_id,
            //     currency_id=self.order_id.currency_id or company.currency_id,
            //     rate=self.order_id.currency_rate,
            //     name=self.name,
            // )
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _prepare_base_line_for_taxes_computation(self, **kwargs):
            // """ Convert the current record to a dictionary in order to use the generic taxes computation method
            // defined on account.tax.
            // 
            // :return: A python dictionary.
            // """
            // self.ensure_one()
            // company = self.order_id.company_id or self.env.company
            // base_values = {
            //     'tax_ids': self.tax_ids,
            //     'quantity': self.product_uom_qty,
            //     'partner_id': self.order_id.partner_id,
            //     'currency_id': self.order_id.currency_id or company.currency_id,
            //     'rate': self.order_id.currency_rate,
            //     'name': self.name,
            // }
            // if self._is_global_discount():
            //     base_values['special_type'] = 'global_discount'
            // elif self.is_downpayment:
            //     base_values['special_type'] = 'down_payment'
            // base_values.update(kwargs)
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(self, **base_values)
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
            //     if res_vals['display_type'] in ('line_section', 'line_subsection', 'line_note'):
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
            // for line, amounts in zip(self, amounts_list):
            // 
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
            //             'reconciled_lines_ids': [Command.set(line.ids)],
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
            //         'product_uom_id': self.product_uom_id.id,
            //         'quantity': self.qty_to_invoice,
            //         'sale_line_ids': [Command.link(self.id)],
            //         'collapse_prices': self.collapse_prices,
            //         'collapse_composition': self.collapse_composition,
            //         **optional_values,
            //     }
            // res = {
            //     'display_type': self.display_type or 'product',
            //     'sequence': self.sequence,
            //     'name': self.env['account.move.line']._get_journal_items_full_name(self.name, self.product_id.display_name),
            //     'product_id': self.product_id.id,
            //     'product_uom_id': self.product_uom_id.id,
            //     'quantity': self.qty_to_invoice,
            //     'discount': self.discount,
            //     'price_unit': self.price_unit,
            //     'tax_ids': [Command.set(self.tax_ids.ids)],
            //     'sale_line_ids': [Command.link(self.id)],
            //     'is_downpayment': self.is_downpayment,
            //     'extra_tax_data': self.extra_tax_data,
            //     'collapse_prices': self.collapse_prices,
            //     'collapse_composition': self.collapse_composition,
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

        public async Task<TEntity> PrepareInvoiceLinesValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _prepare_invoice_lines_vals_list(self, **optional_values):
            // return [self._prepare_invoice_line(**optional_values)]
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
            //     if forced_rate := self.env.context.get('forced_rate_from_register_payment'):
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
            // return {
            //     'name': self._get_move_line_name(),
            //     'account_id': self._get_base_account().id,
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

        public async Task<TEntity> PrepareMoveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _prepare_move_vals(self):
            // return {
            //     # force the name to the default value, to avoid an eventual 'default_name' in the context
            //     # that would set it to '' which would then cause no number to be given to the account.move
            //     # when it is posted.
            //     'name': '/',
            //     'expense_ids': [Command.set(self.ids)],
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
            // journal = self.journal_id
            // payment_method_line = self.payment_method_line_id
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
            // base_move_line = {}
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
            //     'account_id': self._get_expense_account_destination(),
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
            //     **self._prepare_move_vals(),
            //     'date': self.date or fields.Date.context_today(self),
            //     'ref': self.name,
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

        public async Task<TEntity> PrepareProcurementValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _prepare_procurement_values(self):
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
            // def _prepare_purchase_order_line(self, product_id, product_qty, product_uom, company_id, partner_id, po):
            // values = self.env.context.get('procurement_values', {})
            // uom_po_qty = product_uom._compute_quantity(product_qty, product_id.uom_id, rounding_method='HALF-UP')
            // # _select_seller is used if the supplier have different price depending
            // # the quantities ordered.
            // today = fields.Date.today()
            // seller = product_id.with_company(company_id)._select_seller(
            //     partner_id=partner_id,
            //     quantity=product_qty if values.get('force_uom') else uom_po_qty,
            //     date=po.date_order and max(po.date_order.date(), today) or today,
            //     uom_id=product_uom if values.get('force_uom') else product_id.uom_id,
            //     params={'force_uom': values.get('force_uom')}
            // )
            // if seller and (seller.product_uom_id or seller.product_tmpl_id.uom_id) != product_uom:
            //     uom_po_qty = product_id.uom_id._compute_quantity(uom_po_qty, seller.product_uom_id, rounding_method='HALF-UP')
            // 
            // tax_domain = self.env['account.tax']._check_company_domain(company_id)
            // product_taxes = product_id.supplier_taxes_id.filtered_domain(tax_domain)
            // taxes = po.fiscal_position_id.map_tax(product_taxes)
            // 
            // if seller:
            //     price_unit = (seller.product_uom_id._compute_price(seller.price, product_uom) if product_uom else seller.price)
            //     price_unit = self.env['account.tax']._fix_tax_included_price_company(
            //     price_unit, product_taxes, taxes, company_id)
            // else:
            //     price_unit = 0
            // if price_unit and seller and po.currency_id and seller.currency_id != po.currency_id:
            //     price_unit = seller.currency_id._convert(
            //         price_unit, po.currency_id, po.company_id, po.date_order or fields.Date.today())
            // 
            // product_lang = product_id.with_prefetch().with_context(
            //     lang=partner_id.lang,
            //     partner_id=partner_id.id,
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
            //     'product_qty': product_qty if product_uom else uom_po_qty,
            //     'product_id': product_id.id,
            //     'product_uom_id': product_uom.id or seller.product_uom_id.id,
            //     'price_unit': price_unit,
            //     'date_planned': date_planned,
            //     'tax_ids': [(6, 0, taxes.ids)],
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
            //     'product_uom_id': self.product_uom_id.id,
            //     'product_qty': product_qty,
            //     'price_unit': price_unit,
            //     'tax_ids': [(6, 0, taxes_ids)],
            //     'date_planned': date_planned,
            //     'analytic_distribution': self.analytic_distribution,
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareQtyDeliveredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _prepare_qty_delivered(self):
            // # compute for analytic lines
            // delivered_qties = defaultdict(float)
            // lines_by_analytic = self.filtered(lambda sol: sol.qty_delivered_method == 'analytic')
            // mapping = lines_by_analytic._get_delivered_quantity_by_analytic([('amount', '<=', 0.0)])
            // for so_line in lines_by_analytic:
            //     delivered_qties[so_line] = mapping.get(so_line.id or so_line._origin.id, 0.0)
            // return delivered_qties
            */
            return default;
        }

        public async Task<TEntity> PrepareQtyInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_qty_invoiced(self):
            // # Compute qty_invoiced
            // invoiced_qties = defaultdict(float)
            // for line in self:
            //     for inv_line in line._get_invoice_lines():
            //         if inv_line.move_id.state not in ['cancel'] or inv_line.move_id.payment_state == 'invoicing_legacy':
            //             if inv_line.move_id.move_type == 'in_invoice':
            //                 invoiced_qties[line] += inv_line.product_uom_id._compute_quantity(inv_line.quantity, line.product_uom_id)
            //             elif inv_line.move_id.move_type == 'in_refund':
            //                 invoiced_qties[line] -= inv_line.product_uom_id._compute_quantity(inv_line.quantity, line.product_uom_id)
            // return invoiced_qties
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _prepare_qty_invoiced(self):
            // invoiced_qties = defaultdict(float)
            // for line in self:
            //     for invoice_line in line._get_invoice_lines():
            //         if invoice_line.move_id.state != 'cancel' or invoice_line.move_id.payment_state == 'invoicing_legacy':
            //             invoice_qty = invoice_line.product_uom_id._compute_quantity(invoice_line.quantity, line.product_uom_id)
            //             if invoice_line.move_id.move_type == 'out_invoice':
            //                 invoiced_qties[line] += invoice_qty
            //             elif invoice_line.move_id.move_type == 'out_refund':
            //                 invoiced_qties[line] -= invoice_qty
            // return invoiced_qties
            */
            return default;
        }

        public async Task<TEntity> PrepareQtyReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _prepare_qty_received(self):
            // received_qties = defaultdict(float)
            // for line in self:
            //     if line.qty_received_method == 'manual':
            //         received_qties[line] = line.qty_received_manual or 0.0
            //     else:
            //         received_qties[line] = 0.0
            // return received_qties
            */
            return default;
        }

        public async Task<TEntity> PrepareReceiptsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _prepare_receipts_vals(self):
            // attachments_data = []
            // for attachment in self.message_main_attachment_id:
            //     attachments_data.append(
            //         Command.create(attachment.copy_data({'res_model': 'account.move', 'res_id': False, 'raw': attachment.raw})[0])
            //     )
            // 
            // return_vals = []
            // for employee_sudo, expenses_sudo in self.sudo().grouped('employee_id').items():
            //     multiple_expenses_name = _("Expenses of %(employee)s", employee=employee_sudo.name)
            //     move_ref = expenses_sudo.name if len(expenses_sudo) == 1 else multiple_expenses_name
            //     return_vals.append({
            //     **expenses_sudo._prepare_move_vals(),
            //         'ref': move_ref,
            //         'move_type': 'in_receipt',
            //         'partner_id': employee_sudo.work_contact_id.id,
            //         'commercial_partner_id': employee_sudo.user_partner_id.id,
            //         'currency_id': expenses_sudo.company_currency_id.id,
            //         'line_ids': [Command.create(expense_sudo._prepare_move_lines_vals()) for expense_sudo in expenses_sudo],
            //         'partner_bank_id': employee_sudo.primary_bank_account_id.id,
            //         'attachment_ids': attachments_data,
            //     })
            // return return_vals
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
            //     if len(remaining_amls.mapped('partner_id')) > 1:
            //         remaining_amls = remaining_amls.sorted(lambda aml: (aml.partner_id and aml.partner_id.id) or False)
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
            //         partial_amount = min(remaining_debit_amount, -remaining_credit_amount)
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
            // if not self.env.context.get('no_exchange_difference') and not self.env.context.get('no_exchange_difference_no_recursive'):
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
            //         res['exchange_values']['to_post'] = debit_aml.parent_state == 'posted' and credit_aml.parent_state == 'posted'
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
            // self.product_uom_id = self.product_id.uom_id
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

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def read(self, fields=None, load='_classic_read'):
            // fields = fields or self._get_default_read_fields()
            // return super().read(fields, load)
            */
            return default;
        }

        public async Task<object> ReadGroupGroupbyInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string groupby_spec, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _read_group_groupby(self, alias: str, groupby_spec: str, query: Query) -> SQL:
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
            // return super()._read_group_groupby(alias, groupby_spec, query)
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
            //         'parent_state': aml.parent_state,
            //     }
            //     for aml in all_amls
            // }
            // 
            // # ==== Prepare the partials ====
            // partials_values_list = []
            // exchange_diff_values_list = []
            // all_plan_results = []
            // for plan in plan_list:
            //     plan_results = self\
            //         .with_context(
            //             no_exchange_difference=self.env.context.get('no_exchange_difference'),
            //             no_exchange_difference_no_recursive=self.env.context.get('no_exchange_difference_no_recursive', False),
            //         )\
            //         ._prepare_reconciliation_plan(plan, aml_values_map)
            //     all_plan_results.append(plan_results)
            //     for results in plan_results:
            //         partials_values_list.append(results['partial_values'])
            //         if results.get('exchange_values') and results['exchange_values']['move_values']['line_ids']:
            //             exchange_diff_values_list.append(results['exchange_values'])
            // 
            // # ==== Create the partials ====
            // # Link the newly created partials to the plan. There are needed later for caba exchange entries.
            // partials = self.env['account.partial.reconcile'].create(partials_values_list)
            // if self.env.context.get('add_caba_vals'):
            //     partials._set_draft_caba_move_vals()
            // start_range = 0
            // for plan_results, plan in zip(all_plan_results, plan_list):
            //     size = len(plan_results)
            //     plan['partials'] = partials[start_range:start_range + size]
            //     start_range += size
            // 
            // # ==== Create the partial exchange journal entries ====
            // exchange_moves = self._create_exchange_difference_moves(exchange_diff_values_list)
            // used_exchange_moves = set()
            // used_partials = set()
            // 
            // for partial in partials:
            //     for exchange_move in exchange_moves:
            //         linked_move_lines = exchange_move.line_ids.reconciled_lines_ids
            // 
            //         if (
            //             any(line == partial.debit_move_id or line == partial.credit_move_id for line in linked_move_lines)
            //             and exchange_move not in used_exchange_moves
            //             and partial not in used_partials
            //         ):
            //             partial.exchange_move_id = exchange_move
            //             used_exchange_moves.add(exchange_move)
            //             used_partials.add(partial)
            // 
            // # ==== Create entries for cash basis taxes ====
            // def is_cash_basis_needed(amls):
            //     return any(amls.company_id.mapped('tax_exigibility')) \
            //         and amls.account_id.account_type in ('asset_receivable', 'liability_payable')
            // 
            // if not self.env.context.get('move_reverse_cancel') and not self.env.context.get('no_cash_basis'):
            //     for plan in plan_list:
            //         if is_cash_basis_needed(plan['amls']):
            //             plan['partials'].with_context(no_exchange_difference_no_recursive=False)._create_tax_cash_basis_moves()
            //             plan['partials']._set_draft_caba_move_vals()
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
            //     for (_dummy, account, repartition_line), amls_to_reconcile in caba_lines_to_reconcile.items():
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
            //     return {number: lines.with_env(self.env) for number, lines in self.sudo()._read_group(
            //         domain=[('matching_number', 'in', matching_numbers)],
            //         groupby=['matching_number'],
            //         aggregates=['id:recordset'],
            //     )}
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

        public async Task<TEntity> RoundAnalyticDistributionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object analytic_lines_vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _round_analytic_distribution_line(self, analytic_lines_vals):
            // """ Round the analytic lines amount, and cancel the rounding error. """
            // if not analytic_lines_vals:
            //     return
            // 
            // rounding_error = 0
            // for line in analytic_lines_vals:
            //     rounded_amount = self.company_currency_id.round(line['amount'])
            //     rounding_error += rounded_amount - line['amount']
            //     line['amount'] = rounded_amount
            // 
            // # distributing the rounding error
            // for line in analytic_lines_vals:
            //     if self.company_currency_id.is_zero(rounding_error):
            //         break
            //     amt = max(
            //         self.company_currency_id.rounding,
            //         abs(self.company_currency_id.round(rounding_error / len(analytic_lines_vals)))
            //     )
            //     if rounding_error < 0.0:
            //         line['amount'] += amt
            //         rounding_error += amt
            //     else:
            //         line['amount'] -= amt
            //         rounding_error -= amt
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
            // 
            //     # This is used for negative amounts in debit/credit for manual inputs (to stay in same debit/credit as input)
            //     if vals.get('move_id') and self.env['account.move'].browse(vals['move_id']).company_id.account_storno:
            //         vals['is_storno'] = vals.get('is_storno', False) or (vals.get('debit', 0) < 0 or vals.get('credit', 0) < 0)
            // 
            //     debit = vals.pop('debit', 0)
            //     credit = vals.pop('credit', 0)
            //     if 'balance' not in vals:
            //         vals['balance'] = debit - credit
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
            //         account_id: float_round(distribution, decimal_precision) if account_id != '__update__' else distribution
            //         for account_id, distribution in vals['analytic_distribution'].items()
            //     }
            // return vals
            */
            return default;
        }

        public async Task<TEntity> SearchAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def _search_account_id(self, operator, value):
            // """
            // Search method that can be a drop-in replacement for searching on `account_id`.
            // Resolves the domain and inlines the resulting ids to yield better final queries
            // and avoids joining on the `account.account` model.
            // This should be a net positive on average, under the assertion that the cardinality of
            // `account.account` doesn't grow too large. (e.g. <10k rows)
            // """
            // if (
            //     operator in ('in', 'not in', 'any', 'not any')
            //     and not isinstance(value, (tuple, list, OrderedSet))
            // ):
            //     if operator in ('any', 'not any'):
            //         operator = {'any': 'in', 'not any': 'not in'}[operator]
            // 
            //     if isinstance(value, (Query, SQL)):
            //         query_value = value.select() if isinstance(value, Query) else value
            //         value = [row[0] for row in self.env.execute_query(query_value)]
            //     else:  # isinstance(value, Domain) is True
            //         # sudo reason: ignore ir.rules, `account_id` is with `bypass_search_access=True`
            //         value = self.env['account.account'].sudo()._search(value).get_result_ids()
            // 
            // return [('account_id', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py) ---
            // def _search_analytic_distribution(self, operator, value):
            // # Don't use this override when account_report_analytic_groupby is truly in the context
            // # Indeed, when account_report_analytic_groupby is in the context it means that `analytic_distribution`
            // # doesn't have the same format and the table is a temporary one, see _prepare_lines_for_analytic_groupby
            // if self.env.context.get('account_report_analytic_groupby'):
            //     return Domain('analytic_distribution', operator, value)
            // 
            // def search_value(value: str, exact: bool):
            //     return list(self.env['account.analytic.account']._search(
            //         [('display_name', ('=' if exact else 'ilike'), value)]
            //     ))
            // 
            // # reformulate the condition as <field> in/not in <ids>
            // if operator in ('in', 'not in'):
            //     ids = [
            //         r
            //         for v in value
            //         for r in (search_value(v, exact=True) if isinstance(value, str) else [v])
            //     ]
            // elif operator in ('ilike', 'not ilike'):
            //     ids = search_value(value, exact=False)
            //     operator = 'not in' if operator.startswith('not') else 'in'
            // else:
            //     raise UserError(_('Operation not supported'))
            // 
            // if not ids:
            //     # not ids found, just let it optimize to a constant
            //     return Domain(operator == 'not in')
            // 
            // # keys can be comma-separated ids, we will split those into an array and then make an array comparison with the list of ids to check
            // ids = [str(id_) for id_ in ids if id_]  # list of ids -> list of string
            // if operator == 'in':
            //     return Domain.custom(to_sql=lambda model, alias, query: SQL(
            //         "%s && %s",
            //         self._query_analytic_accounts(alias),
            //         ids,
            //     ))
            // else:
            //     return Domain.custom(to_sql=lambda model, alias, query: SQL(
            //         "(NOT %s && %s OR %s IS NULL)",
            //         self._query_analytic_accounts(alias),
            //         ids,
            //         model._field_to_sql(alias, 'analytic_distribution', query),
            //     ))
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
            // def search_fetch(self, domain, field_names=None, offset=0, limit=None, order=None):
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
            // return self.env['account.move']._search_journal_group_id(operator, value)
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
            // domain = Domain(domain)
            // if domain.is_false():
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
            // if operator == 'in':
            //     # recursive call with operator '='
            //     return Domain.OR(self._search_payment_date('=', v) for v in value)
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
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

        public async Task<TEntity> SearchReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_line.py) ---
            // def search_read(self, domain=None, fields=None, offset=0, limit=None, order=None, **read_kwargs):
            // fields = fields or self._get_default_read_fields()
            // return super().search_read(domain, fields, offset, limit, order, **read_kwargs)
            */
            return default;
        }

        public async Task<TEntity> SellableLinesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py) ---
            // def _sellable_lines_domain(self):
            // discount_products_ids = self.env.companies.sale_discount_product_id.ids
            // domain = Domain('is_downpayment', '=', False)
            // if discount_products_ids:
            //     domain &= Domain('product_id', 'not in', discount_products_ids)
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SendExpenseSuccessMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object expense) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _send_expense_success_mail(self, msg_dict, expense):
            // """ Send a confirmation mail to the employee that an expense has been created by their previous mail """
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
            //     company_currency = expense.company_currency_id or self.env.company.currency_id
            //     expense.currency_rate = expense.env['res.currency']._get_conversion_rate(
            //         from_currency=expense.currency_id or company_currency,
            //         to_currency=company_currency,
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
            // ''' Suggest a minimal quantity based on the seller
            // '''
            // if not self.product_id:
            //     return
            // date = self.order_id.date_order and self.order_id.date_order.date() or fields.Date.context_today(self)
            // seller_min_qty = self.product_id.seller_ids\
            //     .filtered(lambda r: r.partner_id == self.order_id.partner_id and
            //               (not r.product_id or r.product_id == self.product_id) and
            //               (not r.date_start or r.date_start <= date) and
            //               (not r.date_end or r.date_end >= date))\
            //     .sorted(key=lambda r: r.min_qty)
            // if seller_min_qty:
            //     self.product_qty = seller_min_qty[0].min_qty or 1.0
            //     self.product_uom_id = seller_min_qty[0].product_uom_id
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
            //         (changed('balance') or changed('move_type'))
            //          and not self.env.is_protected(self._fields['amount_currency'], line)
            //          and (not changed('amount_currency') or (line not in before and not line.amount_currency))
            //          and line.currency_id == line.company_id.currency_id
            //     ):
            //         line.amount_currency = line.balance
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

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'state' not in init_values:
            //     return super()._track_subtype(init_values)
            // 
            // match self.state:
            //     case 'draft':
            //         return self.env.ref('hr_expense.mt_expense_reset')
            //     case 'cancel':
            //         return self.env.ref('hr_expense.mt_expense_refused')
            //     case 'paid':
            //         return self.env.ref('hr_expense.mt_expense_paid')
            //     case 'approved':
            //         if init_values['state'] in {'posted', 'in_payment', 'paid'}:  # Reverting state
            //             subtype = 'hr_expense.mt_expense_entry_draft' if self.account_move_id else 'hr_expense.mt_expense_entry_delete'
            //             return self.env.ref(subtype)
            //         return self.env.ref('hr_expense.mt_expense_approved')
            //     case _:
            //         return super()._track_subtype(init_values)
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
            // self.remove_move_reconcile()
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

        public async Task<TEntity> UnlinkExceptApprovedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _unlink_except_approved(self):
            // for expense in self:
            //     if expense.state in {'approved', 'posted', 'in_payment', 'paid'}:
            //         raise UserError(_('You cannot delete a posted or approved expense.'))
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
            // if not self.env.context.get('force_delete') and any(m.state == 'posted' for m in self.move_id):
            //     raise UserError(_("You can't delete a posted journal item. Don’t play games with your accounting records; reset the journal entry to draft before deleting it."))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def _unlink_except_purchase(self):
            // for line in self:
            //     if line.order_id.state == 'purchase' and line.display_type not in ['line_section', 'line_subsection', 'line_note']:
            //         state_description = {state_desc[0]: state_desc[1] for state_desc in self._fields['state']._description_selection(self.env)}
            //         raise UserError(_('Cannot delete a purchase order line which is in state “%s”.', state_description.get(line.state)))
            */
            return default;
        }

        public async Task<TEntity> UpdateActivitiesAndMailsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def update_activities_and_mails(self):
            // """ Update the "Review this expense" activity with the new state of the expense, also sends mail to approver to ask them to act """
            // expenses_activity_done = self.env['hr.expense']
            // expenses_activity_unlink = self.env['hr.expense']
            // expenses_submitted_to_review = self.env['hr.expense']
            // for expense in self:
            //     if expense.state == 'submitted':
            //         expense.activity_schedule(
            //             'hr_expense.mail_act_expense_approval',
            //             user_id=expense.manager_id.id or
            //             expense.sudo()._get_default_responsible_for_approval().id or
            //             self.env.user.id
            //         )
            //         expenses_submitted_to_review |= expense
            //     elif expense.state == 'approved':
            //         expenses_activity_done |= expense
            //     elif expense.state in {'draft', 'refused'}:
            //         expenses_activity_unlink |= expense
            // 
            // # Batched actions
            // if expenses_activity_done:
            //     expenses_activity_done.activity_feedback(['hr_expense.mail_act_expense_approval'])
            // if expenses_activity_unlink:
            //     expenses_activity_unlink.activity_unlink(['hr_expense.mail_act_expense_approval'])
            // # Avoid sending yourself mails
            // expenses_submitted_to_review = expenses_submitted_to_review.filtered(lambda expense: expense.manager_id != self.env.user)
            // if expenses_submitted_to_review:
            //     new_mails = []
            //     for company, expenses_submitted_per_company in expenses_submitted_to_review.grouped('company_id').items():
            //         parent_company_mails = company.parent_ids[::-1].mapped('email_formatted')
            //         mail_from = (
            //                 self.env.user.email
            //                 or company.email_formatted
            //                 or (parent_company_mails and parent_company_mails[0])
            //         )
            // 
            //         if not mail_from:  # We can't send a mail without sender
            //             _logger.warning(_("Failed to send mails for submitted expenses. No valid email was found for the company"))
            //             continue
            // 
            //         for manager, expenses_submitted in expenses_submitted_per_company.grouped('manager_id').items():
            //             manager_langs = tuple(lang for lang in manager.partner_id.mapped('lang') if lang)
            //             mail_lang = (manager_langs and manager_langs[0]) or self.env.lang or 'en_US'
            //             body = self.env['ir.qweb']._render(
            //                 template='hr_expense.hr_expense_template_submitted_expenses',
            //                 values={'manager_name': manager.name, 'url': '/expenses-to-approve'},
            //                 lang=mail_lang,
            //             )
            //             new_mails.append({
            //                 'author_id': self.env.user.partner_id.id,
            //                 'auto_delete': True,
            //                 'body_html': body,
            //                 'email_from': mail_from,
            //                 'email_to': manager.employee_id.work_email or manager.email,
            //                 'subject': _("New expenses waiting for your approval"),
            //             })
            //         if new_mails:
            //             self.env['mail.mail'].sudo().create(new_mails).send()
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
            //         if line.balance else 100
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
            // # Check writing a archived account.
            // if account_to_write and not account_to_write.active:
            //     raise UserError(_('You cannot use an archived account.'))
            // 
            // inalterable_fields = set(self._get_integrity_hash_fields()).union({'inalterable_hash'})
            // hashed_moves = self.move_id.filtered('inalterable_hash')
            // violated_fields = set(vals) & inalterable_fields
            // if hashed_moves and violated_fields:
            //     raise UserError(_(
            //         "You cannot edit the following fields: %(fields)s.\n"
            //         "The following entries are already hashed:\n%(entries)s",
            //         fields=[f['string'] for f in self.fields_get(violated_fields).values()],
            //         entries='\n'.join(hashed_moves.mapped('name')),
            //     ))
            // 
            // line_to_write = self
            // vals = self._sanitize_vals(vals)
            // matching2lines = None  # lazy cache
            // lines_to_unreconcile = self.env['account.move.line']
            // st_lines_to_unreconcile = self.env['account.bank.statement.line']
            // tax_lock_check_ids = []
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
            //         tax_lock_check_ids.append(line.id)
            // 
            //     # Break the reconciliation.
            //     if (
            //         line.matching_number
            //         and (changing_fields := {
            //             field_name
            //             for field_name in protected_fields['reconciliation']
            //             if self.env['account.move']._field_will_change(line, vals, field_name)
            //         })
            //     ):
            //         matching2lines = self._reconciled_by_number() if matching2lines is None else matching2lines
            //         if (
            //             # allow changing the account on all the lines of a reconciliation together
            //             changing_fields - {'account_id'}
            //             or not all(reconciled_line in self for reconciled_line in matching2lines[line.matching_number])
            //         ):
            //             lines_to_unreconcile += line
            //             st_lines_to_unreconcile += (line.matched_debit_ids.debit_move_id + line.matched_credit_ids.credit_move_id).statement_line_id
            // 
            // lines_to_unreconcile.remove_move_reconcile()
            // for st_line in st_lines_to_unreconcile:
            //     try:
            //         st_line.move_id._check_fiscal_lock_dates()
            //         st_line.move_id.line_ids._check_tax_lock_date()
            //     except UserError:
            //         st_lines_to_unreconcile -= st_line
            // st_lines_to_unreconcile.action_undo_reconciliation()
            // 
            // self.browse(tax_lock_check_ids)._check_tax_lock_date()
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
            //     # double check modified lines in case a tax field was changed on a line that didn't previously affect tax
            //     self.browse(tax_lock_check_ids)._check_tax_lock_date()
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
            //     if 'analytic_line_ids' in vals:
            //         self.filtered(lambda l: l.parent_state == 'draft').analytic_line_ids.with_context(skip_analytic_sync=True).unlink()
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
            // if any(field in vals for field in {'is_editable', 'can_approve', 'can_refuse'}):
            //     raise UserError(_("You cannot edit the security fields of an expense manually"))
            // 
            // if any(field in vals for field in {'tax_ids', 'analytic_distribution', 'account_id', 'manager_id'}):
            //     if any((not expense.is_editable and not self.env.su) for expense in self):
            //         raise UserError(_(
            //             "Uh-oh! You can’t edit this expense.\n\n"
            //             "Reach out to the administrators, flash your best smile, and see if they'll grant you the magical access you seek."
            //         ))
            // 
            // res = super().write(vals)
            // 
            // if vals.get('state') == 'approved' or vals.get('approval_state') == 'approved':
            //     self._check_can_approve()
            // elif vals.get('state') == 'refused' or vals.get('approval_state') == 'refused':
            //     self._check_can_refuse()
            // 
            // if 'currency_id' in vals:
            //     self._set_expense_currency_rate(date_today=fields.Date.context_today(self))
            //     for expense in self:
            //         expense.total_amount = expense.total_amount_currency * expense.currency_rate
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py) ---
            // def write(self, vals):
            // values = vals
            // if 'display_type' in values and self.filtered(lambda line: line.display_type != values.get('display_type')):
            //     raise UserError(_("You cannot change the type of a purchase order line. Instead you should delete the current line and create a new line of the proper type."))
            // 
            // if 'product_qty' in values:
            //     precision = self.env['decimal.precision'].precision_get('Product Unit')
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
            // return super().write(values)
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
            // def write(self, vals):
            // values = vals
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
            //     precision = self.env['decimal.precision'].precision_get('Product Unit')
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
            // return super().write(values)
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