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
    [Module("HrExpenseModule", Category = "HumanResources", Depends = new[] { "account", "web_tour", "hr" })]
    public class HrExpenseSheetAppService : GenericApplicationService<HrExpenseSheet>, IHrExpenseSheetAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        public HrExpenseSheetAppService(IRepository<HrExpenseSheet, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
        }

        public async Task<HrExpenseSheet> ActivityUpdateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def activity_update(self):
            // reports_requiring_feedback = self.env['hr.expense.sheet']
            // reports_activity_unlink = self.env['hr.expense.sheet']
            // for expense_report in self:
            //     if expense_report.state == 'submit':
            //         expense_report.activity_schedule(
            //             'hr_expense.mail_act_expense_approval',
            //             user_id=expense_report.sudo()._get_responsible_for_approval().id or self.env.user.id)
            //     elif expense_report.state == 'approve':
            //         reports_requiring_feedback |= expense_report
            //     elif expense_report.state in {'draft', 'cancel'}:
            //         reports_activity_unlink |= expense_report
            // if reports_requiring_feedback:
            //     reports_requiring_feedback.activity_feedback(['hr_expense.mail_act_expense_approval'])
            // if reports_activity_unlink:
            //     reports_activity_unlink.activity_unlink(['hr_expense.mail_act_expense_approval'])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpenseSheet> ApproveExpenseSheetsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def action_approve_expense_sheets(self):
            // self._check_can_approve()
            // self._validate_analytic_distribution()
            // duplicates = self.expense_line_ids.duplicate_expense_ids.filtered(lambda exp: exp.state in {'approved', 'done'})
            // if duplicates:
            //     action = self.env["ir.actions.act_window"]._for_xml_id('hr_expense.hr_expense_approve_duplicate_action')
            //     action['context'] = {'default_sheet_ids': self.ids, 'default_expense_ids': duplicates.ids}
            //     return action
            // self._do_approve()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpenseSheet> CalculateDefaultAccountingDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _calculate_default_accounting_date(self):
            // """
            // Calculate the default accounting date for the expenses paid by employees
            // """
            // self.ensure_one()
            // today = fields.Date.context_today(self)
            // start_month = fields.Date.start_of(today, "month")
            // end_month = fields.Date.end_of(today, "month")
            // most_recent_expense = max(self.expense_line_ids.filtered(lambda exp: exp.date).mapped('date'), default=today)
            // 
            // if most_recent_expense > end_month:
            //     return most_recent_expense
            // 
            // if most_recent_expense >= start_month:
            //     return today
            // 
            // lock_date = self.company_id._get_user_fiscal_lock_date(self.journal_id)
            // 
            // return min(
            //     max(
            //         fields.Date.end_of(most_recent_expense, "month"),
            //         fields.Date.end_of(fields.Date.add(lock_date, months=1), "month")
            //     ),
            //     today
            // )
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckCanApproveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _check_can_approve(self):
            // if not all(self.mapped('can_approve')):
            //     reasons = _("You cannot approve:\n %s", "\n".join(self.mapped('cannot_approve_reason')))
            //     raise UserError(reasons)
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckCanCreateMoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _check_can_create_move(self):
            // if any(not sheet.expense_line_ids for sheet in self):
            //     raise UserError(_("You cannot create accounting entries for an expense report without expenses."))
            // 
            // if any(sheet.state != 'submit' for sheet in self):
            //     raise UserError(_("You can only generate an accounting entry for approved expense(s)."))
            // 
            // if any(not sheet.journal_id for sheet in self):
            //     raise UserError(_("Please specify an expense journal in order to generate accounting entries."))
            // 
            // if False in self.mapped('payment_mode'):
            //     raise UserError(_(
            //         "Please specify if the expenses for this report were paid by the company, or the employee"
            //     ))
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckCanRefuseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _check_can_refuse(self):
            // if not all(self.mapped('can_approve')):
            //     reasons = _("You cannot refuse:\n %s", "\n".join(self.mapped('cannot_approve_reason')))
            //     raise UserError(reasons)
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckCanResetApprovalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _check_can_reset_approval(self):
            // if not all(self.mapped('can_reset')):
            //     raise UserError(_("Only HR Officers or the concerned employee can reset to draft."))
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckEmployeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _check_employee(self):
            // for sheet in self:
            //     if sheet.expense_line_ids.employee_id - sheet.employee_id:
            //         raise ValidationError(_('You cannot add expenses of another employee.'))
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckExpenseLinesCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _check_expense_lines_company(self):
            // for sheet in self:
            //     if sheet.expense_line_ids.company_id - sheet.company_id:
            //         raise ValidationError(_('An expense report must contain only lines from the same company.'))
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckPaymentModeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _check_payment_mode(self):
            // for sheet in self:
            //     expense_lines = sheet.mapped('expense_line_ids')
            //     if expense_lines and any(expense.payment_mode != expense_lines[:1].payment_mode for expense in expense_lines):
            //         raise ValidationError(_("All expenses in an expense report must have the same \"paid by\" criteria."))
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_amount(self):
            // for sheet in self:
            //     sheet.total_amount = sum(sheet.expense_line_ids.mapped('total_amount'))
            //     sheet.total_tax_amount = sum(sheet.expense_line_ids.mapped('tax_amount'))
            //     sheet.untaxed_amount = sheet.total_amount - sheet.total_tax_amount
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeCanApproveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_can_approve(self):
            // is_team_approver = self.env.user.has_group('hr_expense.group_hr_expense_team_approver') or self.env.su
            // is_approver = self.env.user.has_group('hr_expense.group_hr_expense_user') or self.env.su
            // is_hr_admin = self.env.user.has_group('hr_expense.group_hr_expense_manager') or self.env.su
            // 
            // for sheet in self:
            //     reason = False
            //     if not is_team_approver:
            //         reason = _("%s: Your are not a Manager or HR Officer", sheet.name)
            // 
            //     elif not is_hr_admin:
            //         sheet_employee = sheet.employee_id
            //         current_managers = sheet_employee.expense_manager_id \
            //                            | sheet_employee.parent_id.user_id \
            //                            | sheet_employee.department_id.manager_id.user_id \
            //                            | sheet.user_id
            // 
            //         if sheet_employee.user_id == self.env.user:
            //             reason = _("%s: It is your own expense", sheet.name)
            // 
            //         elif self.env.user not in current_managers and not is_approver and sheet_employee.expense_manager_id.id != self.env.user.id:
            //             reason = _("%s: It is not from your department", sheet.name)
            // 
            //     sheet.can_approve = not reason
            //     sheet.cannot_approve_reason = reason
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeCanResetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_can_reset(self):
            // is_expense_user = self.env.user.has_group('hr_expense.group_hr_expense_team_approver')
            // for sheet in self:
            //     sheet.can_reset = is_expense_user if is_expense_user else sheet.employee_id.user_id == self.env.user
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_currency_id(self):
            // for sheet in self:
            //     if not sheet.expense_line_ids or sheet.is_multiple_currency or sheet.payment_mode == 'own_account':
            //         sheet.currency_id = sheet.company_currency_id
            //     else:
            //         sheet.currency_id = sheet.expense_line_ids[:1].currency_id
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeFromAccountMoveIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_from_account_move_ids(self):
            // for sheet in self:
            //     if sheet.payment_mode == 'company_account':
            //         if sheet.account_move_ids.filtered(lambda move: move.state != 'draft'):
            //             # when the sheet is paid by the company, the state/amount of the related account_move_ids are not relevant
            //             # unless all moves have been reversed
            //             sheet.amount_residual = 0.
            //             if sheet.account_move_ids - sheet.account_move_ids.filtered('reversal_move_ids'):
            //                 sheet.payment_state = 'paid'
            //             else:
            //                 sheet.payment_state = 'reversed'
            //         else:
            //             sheet.amount_residual = sum(sheet.account_move_ids.mapped('amount_residual'))
            //             payment_states = set(sheet.account_move_ids.mapped('payment_state'))
            //             if len(payment_states) <= 1:  # If only 1 move or only one state
            //                 sheet.payment_state = payment_states.pop() if payment_states else 'not_paid'
            //             elif 'partial' in payment_states or 'paid' in payment_states:  # else if any are (partially) paid
            //                 sheet.payment_state = 'partial'
            //             else:
            //                 sheet.payment_state = 'not_paid'
            //     else:
            //         # Only one move is created when the expenses are paid by the employee
            //         if sheet.account_move_ids.filtered(lambda move: move.state == 'posted'):
            //             sheet.amount_residual = sum(sheet.account_move_ids.mapped('amount_residual'))
            //             sheet.payment_state = sheet.account_move_ids[:1].payment_state
            //         else:
            //             sheet.amount_residual = 0.0
            //             sheet.payment_state = 'not_paid'
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeFromEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_from_employee_id(self):
            // for sheet in self:
            //     sheet.department_id = sheet.employee_id.department_id
            //     sheet.user_id = sheet.employee_id.expense_manager_id or sheet.employee_id.parent_id.user_id
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeIsEditableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_is_editable(self):
            // is_hr_admin = (
            //         self.env.user.has_group('hr_expense.group_hr_expense_manager')
            //         or self.env.user.has_group('base.group_system')
            // )
            // is_approver = self.env.user.has_group('hr_expense.group_hr_expense_user')
            // for sheet in self:
            //     if sheet.state not in {'draft', 'submit', 'approve'}:
            //         # Not editable
            //         sheet.is_editable = False
            //         continue
            // 
            //     if is_hr_admin or self.env.su:
            //         # Administrator-level users are not restricted
            //         sheet.is_editable = True
            //         continue
            // 
            //     employee = sheet.employee_id
            // 
            //     is_own_sheet = employee.user_id == self.env.user
            //     if is_own_sheet and sheet.state == 'draft':
            //         # Anyone can edit their own draft sheet
            //         sheet.is_editable = True
            //         continue
            // 
            //     managers = employee.expense_manager_id | employee.parent_id.user_id | employee.department_id.manager_id.user_id
            //     if is_approver:
            //         managers |= self.env.user
            //     if not is_own_sheet and self.env.user in managers:
            //         # If Approver-level or designated manager, can edit other people sheet
            //         sheet.is_editable = True
            //         continue
            //     sheet.is_editable = False
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeIsMultipleCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_is_multiple_currency(self):
            // for sheet in self:
            //     sheet.is_multiple_currency = any(sheet.expense_line_ids.mapped('is_multiple_currency')) \
            //                                  or len(sheet.expense_line_ids.mapped('currency_id')) > 1
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_journal_id(self):
            // for sheet in self:
            //     if sheet.payment_mode == 'company_account':
            //         sheet.journal_id = sheet.payment_method_line_id.journal_id
            //     else:
            //         sheet.journal_id = sheet.employee_journal_id
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeMainAttachmentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_main_attachment(self):
            // for sheet in self:
            //     attachments = sheet.attachment_ids
            //     if not sheet.message_main_attachment_id or sheet.message_main_attachment_id not in attachments:
            //         expenses = sheet.expense_line_ids
            //         expenses_mma_checksums = expenses.message_main_attachment_id.mapped('checksum')
            //         sheet.message_main_attachment_id = attachments.filtered(
            //             lambda att: att.checksum in expenses_mma_checksums
            //         )[:1] or attachments[:1]
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeNbAccountMoveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_nb_account_move(self):
            // for sheet in self:
            //     sheet.nb_account_move = len(sheet.account_move_ids)
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeNbExpenseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_nb_expense(self):
            // for sheet in self:
            //     sheet.nb_expense = len(sheet.expense_line_ids)
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputePaymentMethodLineIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_payment_method_line_id(self):
            // for sheet in self:
            //     sheet.payment_method_line_id = sheet.selectable_payment_method_line_ids[:1]
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeProductIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_product_ids(self):
            // for sheet in self:
            //     sheet.product_ids = sheet.expense_line_ids.mapped('product_id')
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_sale_order_count(self):
            // for sheet in self:
            //     sheet.sale_order_count = len(sheet.expense_line_ids.sale_order_id)
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeSelectablePaymentMethodLineIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_selectable_payment_method_line_ids(self):
            // for sheet in self:
            //     allowed_method_line_ids = sheet.company_id.company_expense_allowed_payment_method_line_ids
            //     if allowed_method_line_ids:
            //         sheet.selectable_payment_method_line_ids = allowed_method_line_ids
            //     else:
            //         sheet.selectable_payment_method_line_ids = self.env['account.payment.method.line'].search([
            //             ('payment_type', '=', 'outbound'),
            //             ('company_id', 'parent_of', sheet.company_id.id)
            //         ])
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _compute_state(self):
            // for sheet in self:
            //     move_ids = sheet.account_move_ids
            //     if not sheet.approval_state:
            //         sheet.state = 'draft'
            //     elif sheet.approval_state == 'cancel':
            //         sheet.state = 'cancel'
            //     elif move_ids:
            //         if sheet.payment_state != 'not_paid':
            //             sheet.state = 'done'
            //         elif all(move_ids.mapped(lambda move: move.state == 'draft')):
            //             sheet.state = 'approve'
            //         else:
            //             sheet.state = 'post'
            //     else:
            //         sheet.state = sheet.approval_state
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DefaultEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _default_employee_id(self):
            // return self.env.user.employee_id
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DefaultJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _default_journal_id(self):
            // """
            //      The journal is determining the company of the accounting entries generated from expense.
            //      We need to force journal company and expense sheet company to be the same.
            // """
            // company_journal_id = self.env.company.expense_journal_id
            // if company_journal_id:
            //     return company_journal_id.id
            // default_company_id = self.default_get(['company_id'])['company_id']
            // journal = self.env['account.journal'].search([
            //     *self.env['account.journal']._check_company_domain(default_company_id),
            //     ('type', '=', 'purchase'),
            // ], limit=1)
            // return journal.id
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoApproveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _do_approve(self):
            // sheets_to_approve = self.filtered(lambda s: s.state in {'submit', 'draft'})
            // sheets_to_approve._check_can_create_move()
            // sheets_to_approve._do_create_moves()
            // for sheet in sheets_to_approve:
            //     sheet.write({
            //         'approval_state': 'approve',
            //         'user_id': sheet.user_id.id or self.env.user.id,
            //         'approval_date': fields.Date.context_today(sheet),
            //     })
            // self.activity_update()
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoCreateMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _do_create_moves(self):
            // """
            // Creation of the account moves for the expenses report. Sudo-ed as they are created in draft and the manager may not have
            // the accounting rights (and there is no reason to give them those rights).
            // There are two main flows at play:
            //     - Expense paid by the company -> Create an account payment (we only "log" the already paid expense so it can be reconciled)
            //     - Expense paid by he employee's own account -> As it should be reimbursed to them, it creates a vendor bill.
            // """
            // self = self.with_context(clean_context(self.env.context))  # remove default_*
            // own_account_sheets = self.filtered(lambda sheet: sheet.payment_mode == 'own_account')
            // company_account_sheets = self - own_account_sheets
            // 
            // for sheet in own_account_sheets:
            //     sheet.accounting_date = sheet.accounting_date or sheet._calculate_default_accounting_date()
            // moves_sudo = self.env['account.move'].sudo().create([sheet._prepare_bills_vals() for sheet in own_account_sheets])
            // for move_sudo in moves_sudo:
            //     move_sudo._message_set_main_attachment_id(move_sudo.attachment_ids, force=True, filter_xml=False)
            // if company_account_sheets:
            //     move_vals_list, payment_vals_list = zip(*[
            //         expense._prepare_payments_vals()
            //         for expense in company_account_sheets.expense_line_ids
            //     ])
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
            // # returning the move with the super user flag set back as it was at the origin of the call
            // return moves_sudo.sudo(self.env.su)
            --- ODOO METHOD SOURCE (MODULE: project_sale_expense, FILE: hr_expense_sheet.py) ---
            // def _do_create_moves(self):
            // """ When creating the move of the expense, if the AA is given in the project of the SO, we take it as reference in the distribution.
            //     Otherwise, we create a AA for the project of the SO and set the distribution to it.
            // """
            // for expense in self.expense_line_ids:
            //     project = expense.sale_order_id.project_id
            //     if not project or expense.analytic_distribution:
            //         continue
            //     if not project.account_id:
            //         project._create_analytic_account()
            //     expense.analytic_distribution = project._get_analytic_distribution()
            // return super()._do_create_moves()
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py) ---
            // def _do_create_moves(self):
            // """ When posting expense, we need the analytic entries to be generated, so a AA is required to reinvoice.
            //     We then ensure a AA is given in the distribution and if not, we create a AA et set the distribution to it.
            // """
            // for expense in self.expense_line_ids:
            //     if expense.sale_order_id and not expense.analytic_distribution:
            //         analytic_account = self.env['account.analytic.account'].create(expense.sale_order_id._prepare_analytic_account_data())
            //         expense.analytic_distribution = {analytic_account.id: 100}
            // return super()._do_create_moves()
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoRefuseInternalAsync(object reason)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _do_refuse(self, reason):
            // # Sudoed as approvers may not be accountants
            // draft_moves_sudo = self.sudo().account_move_ids.filtered(lambda move: move.state == 'draft')
            // if self.sudo().account_move_ids - draft_moves_sudo:
            //     raise UserError(_("You cannot cancel an expense sheet linked to a posted journal entry"))
            // 
            // if draft_moves_sudo:
            //     draft_moves_sudo.unlink()  # Else we have lingering moves
            // 
            // self.approval_state = 'cancel'
            // subtype_id = self.env['ir.model.data']._xmlid_to_res_id('mail.mt_comment')
            // for sheet in self:
            //     sheet.message_post_with_source(
            //         'hr_expense.hr_expense_template_refuse_reason',
            //         subtype_id=subtype_id,
            //         render_values={'reason': reason, 'name': sheet.name},
            //     )
            // self.activity_update()
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoResetApprovalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _do_reset_approval(self):
            // self.sudo().write({'approval_state': False, 'approval_date': False, 'accounting_date': False})
            // self.activity_update()
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoReverseMovesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _do_reverse_moves(self):
            // self = self.with_context(clean_context(self.env.context))
            // moves_sudo = self.sudo().account_move_ids
            // if moves_sudo:
            //     draft_moves_sudo = moves_sudo.filtered(lambda m: m.state == 'draft')
            //     non_draft_moves_sudo = moves_sudo - draft_moves_sudo
            //     non_draft_moves_sudo._reverse_moves(
            //         default_values_list=[{'invoice_date': fields.Date.context_today(move), 'ref': False} for move in non_draft_moves_sudo],
            //         cancel=True
            //     )
            //     draft_moves_sudo.unlink()
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoSubmitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _do_submit(self):
            // self.approval_state = 'submit'
            // self.sudo().activity_update()
            */
            return default;
        }

        protected async Task<HrExpenseSheet> GetDefaultSheetNameInternalAsync(object expenses_to_report)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _get_default_sheet_name(self, expenses_to_report):
            // """ Computes the default name for a new expense sheet from the expenses name or dates """
            // if len(expenses_to_report) == 1:
            //     sheet_name = expenses_to_report.name
            // else:
            //     dates = expenses_to_report.mapped('date')
            //     if False in dates:  # If at least one date isn't set, we don't set a default name
            //         return False
            //     min_date = format_date(self.env, min(dates))
            //     max_date = format_date(self.env, max(dates))
            //     if min_date == max_date:
            //         sheet_name = min_date
            //     else:
            //         sheet_name = _("%(date_from)s - %(date_to)s", date_from=min_date, date_to=max_date)
            // return sheet_name
            */
            return default;
        }

        protected async Task<HrExpenseSheet> GetExpenseAccountDestinationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _get_expense_account_destination(self):
            // self.ensure_one()
            // if self.payment_mode == 'company_account':
            //     journal = self.payment_method_line_id.journal_id
            //     account_dest = (
            //         self.payment_method_line_id.payment_account_id
            //         or journal.company_id.expense_outstanding_account_id
            //     )
            //     if not account_dest:
            //         error_msg = _(
            //             "A default outstanding account must be defined in the settings for company-paid expenses. "
            //             "Or specify one in the Journal for the %(method)s payment method.",
            //             method=self.payment_method_line_id.display_name,
            //         )
            //         if self.env['res.config.settings'].has_access('write'):
            //             action = self.env.ref('hr_expense.action_hr_expense_configuration')
            //             raise RedirectWarning(error_msg, action=action.id, button_text=_("Go to settings"))
            //         else:
            //             raise UserError(error_msg)
            // else:
            //     if not self.employee_id.sudo().work_contact_id:
            //         raise UserError(_("No work contact found for the employee %s, please configure one.", self.employee_id.name))
            //     partner = self.employee_id.sudo().work_contact_id.with_company(self.company_id)
            //     account_dest = partner.property_account_payable_id or partner.parent_id.property_account_payable_id
            // return account_dest.id
            */
            return default;
        }

        protected async Task<HrExpenseSheet> GetResponsibleForApprovalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _get_responsible_for_approval(self):
            // if self.user_id:
            //     return self.user_id
            // if self.employee_id.parent_id.user_id:
            //     return self.employee_id.parent_id.user_id
            // if self.employee_id.department_id.manager_id.user_id:
            //     return self.employee_id.department_id.manager_id.user_id
            // return self.env['res.users']
            */
            return default;
        }

        protected async Task<HrExpenseSheet> GetSaleOrderLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py) ---
            // def _get_sale_order_lines(self):
            // """
            //     This method is used to try to find the sale order lines created by expense sheets.
            //     It is used to reset the quantities of the sale order lines when the expense sheet is reset.
            //     It uses several shared fields to try to find the sale order lines:
            //         - order_id
            //         - product_id
            //         - product_uom_qty
            //         - sale order line's price_unit (computed from the product_id, then rounded to the currency's rounding)
            //         - name
            // """
            // # Get the product account move lines created by an expense
            // expensed_amls = self.account_move_ids.line_ids.filtered(lambda aml: aml.expense_id.sale_order_id and aml.balance >= 0 and not aml.tax_line_id)
            // if not expensed_amls:
            //     return self.env['sale.order.line']
            // 
            // # Get the sale orders linked to the related expenses
            // aml_to_so_map = expensed_amls._sale_determine_order()
            // 
            // self.env['sale.order.line'].flush_model(['order_id', 'product_id', 'product_uom_qty', 'price_unit', 'name'])
            // self.env['res.company'].flush_model(['currency_id'])
            // self.env['res.currency'].flush_model(['rounding'])
            // query = """
            //       WITH aml(key_id, key_count, order_id, product_id, product_uom_qty, price_unit, name) AS (VALUES %s)
            //     SELECT ARRAY_AGG(sol.id ORDER BY sol.id), aml.key_count
            //       FROM aml,
            //            sale_order_line AS sol
            //       JOIN res_company AS company ON sol.company_id = company.id
            //       JOIN res_currency AS company_currency ON company.currency_id = company_currency.id
            //  LEFT JOIN res_currency AS currency ON sol.currency_id = currency.id
            //      WHERE sol.is_expense = TRUE
            //        AND sol.order_id = aml.order_id
            //        AND sol.product_id = aml.product_id
            //        AND sol.product_uom_qty = aml.product_uom_qty
            //        AND sol.name = aml.name
            //        AND ROUND(sol.price_unit::numeric, COALESCE(currency.rounding, company_currency.rounding)::int)
            //            = ROUND(aml.price_unit::numeric, COALESCE(currency.rounding, company_currency.rounding)::int)
            //        GROUP BY aml.key_id, aml.key_count
            // """
            // 
            // # Get the keys used to fetch the corresponding sale order lines, and the number of times they are used
            // # We need the occurrences count to filter out the sale order lines so that we keep exactly one per expense
            // expense_keys_counter = Counter(expensed_amls.mapped(lambda aml: (
            //     aml.expense_id.sale_order_id.id,
            //     aml.product_id.id,
            //     aml.quantity,
            //     aml.currency_id.round(aml._sale_get_invoice_price(aml_to_so_map[aml.id])),
            //     aml.name,
            // )))
            // expensed_amls_keys_and_count = tuple(
            //     (key_id, key_count, *key) for key_id, (key, key_count) in enumerate(expense_keys_counter.items())
            // )
            // self.env.cr.execute_values(query, expensed_amls_keys_and_count)
            // 
            // # Filters out the sale order lines so that we only keep one per expense
            // sol_ids = []
            // for all_sol_ids_per_key, expense_count_per_key in self.env.cr.fetchall():
            //     sol_ids += all_sol_ids_per_key[:expense_count_per_key]
            // return self.env['sale.order.line'].browse(sol_ids)
            */
            return default;
        }

        protected async Task<HrExpenseSheet> MessageAutoSubscribeFollowersInternalAsync(object updated_values, List<Guid> subtype_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
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

        public async Task<HrExpenseSheet> OpenAccountMovesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def action_open_account_moves(self):
            // self.ensure_one()
            // if self.payment_mode == 'own_account':
            //     res_model = 'account.move'
            //     record_ids = self.account_move_ids
            // else:
            //     res_model = 'account.payment'
            //     record_ids = self.account_move_ids.origin_payment_id
            // 
            // action = {'type': 'ir.actions.act_window', 'res_model': res_model}
            // if len(self.account_move_ids) == 1:
            //     action.update({
            //         'name': record_ids.name,
            //         'view_mode': 'form',
            //         'res_id': record_ids.id,
            //         'views': [(False, 'form')],
            //     })
            // else:
            //     action.update({
            //         'name': _("Journal entries"),
            //         'view_mode': 'list',
            //         'domain': [('id', 'in', record_ids.ids)],
            //         'views': [(False, 'list'), (False, 'form')],
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpenseSheet> OpenExpenseViewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def action_open_expense_view(self):
            // self.ensure_one()
            // if self.nb_expense == 1:
            //     return {
            //         'type': 'ir.actions.act_window',
            //         'view_mode': 'form',
            //         'res_model': 'hr.expense',
            //         'res_id': self.expense_line_ids.id,
            //     }
            // return {
            //     'name': _('Expenses'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,form',
            //     'views': [[False, "list"], [False, "form"]],
            //     'res_model': 'hr.expense',
            //     'domain': [('id', 'in', self.expense_line_ids.ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpenseSheet> OpenSaleOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py) ---
            // def action_open_sale_orders(self):
            // self.ensure_one()
            // if self.sale_order_count == 1:
            //     return {
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'sale.order',
            //         'views': [(self.env.ref("sale.view_order_form").id, 'form')],
            //         'view_mode': 'form',
            //         'target': 'current',
            //         'name': self.expense_line_ids.sale_order_id.display_name,
            //         'res_id': self.expense_line_ids.sale_order_id.id,
            //     }
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'sale.order',
            //     'views': [(self.env.ref('sale.view_order_tree').id, 'list'), (self.env.ref("sale.view_order_form").id, 'form')],
            //     'view_mode': 'list,form',
            //     'target': 'current',
            //     'name': _('Reinvoiced Sales Orders'),
            //     'domain': [('id', 'in', self.expense_line_ids.sale_order_id.ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpenseSheet> PrepareBillsValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _prepare_bills_vals(self):
            // self.ensure_one()
            // move_vals = self._prepare_move_vals()
            // if self.employee_id.sudo().bank_account_id:
            //     move_vals['partner_bank_id'] = self.employee_id.sudo().bank_account_id.id
            // return {
            //     **move_vals,
            //     'journal_id': self.journal_id.id,
            //     'ref': self.name,
            //     'move_type': 'in_invoice',
            //     'partner_id': self.employee_id.sudo().work_contact_id.id,
            //     'commercial_partner_id': self.employee_id.user_partner_id.id,
            //     'currency_id': self.currency_id.id,
            //     'line_ids': [Command.create(expense._prepare_move_lines_vals()) for expense in self.expense_line_ids],
            //     'attachment_ids': [
            //         Command.create(attachment.copy_data({'res_model': 'account.move', 'res_id': False, 'raw': attachment.raw})[0])
            //         for attachment in self.expense_line_ids.message_main_attachment_id
            //     ],
            // }
            */
            return default;
        }

        protected async Task<HrExpenseSheet> PrepareMoveValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _prepare_move_vals(self):
            // self.ensure_one()
            // to_return = {
            //     # force the name to the default value, to avoid an eventual 'default_name' in the context
            //     # to set it to '' which cause no number to be given to the account.move when posted.
            //     'name': '/',
            //     'expense_sheet_id': self.id,
            // }
            // 
            // today = fields.Date.context_today(self)
            // most_recent_expense = max(self.expense_line_ids.filtered(lambda exp: exp.date).mapped('date'), default=today)
            // 
            // if self.payment_mode == 'company_account':
            //     to_return['date'] = most_recent_expense
            // else:
            //     to_return['invoice_date'] = self.accounting_date
            // 
            // return to_return
            */
            return default;
        }

        public async Task<HrExpenseSheet> RefuseExpenseSheetsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def action_refuse_expense_sheets(self):
            // self._check_can_refuse()
            // return self.env["ir.actions.act_window"]._for_xml_id('hr_expense.hr_expense_refuse_wizard_action')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpenseSheet> RegisterPaymentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def action_register_payment(self):
            // ''' Open the account.payment.register wizard to pay the selected journal entries.
            // There can be more than one bank_account_id in the expense sheet when registering payment for multiple expenses.
            // The default_partner_bank_id is set only if there is one available, if more than one the field is left empty.
            // :return: An action opening the account.payment.register wizard.
            // '''
            // return self.account_move_ids.with_context(default_partner_bank_id=(
            //     self.account_move_ids.partner_bank_id.id if len(self.account_move_ids.partner_bank_id.ids) <= 1 else None
            // )).action_register_payment()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpenseSheet> ResetExpenseSheetsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def action_reset_expense_sheets(self):
            // self.filtered(lambda sheet: sheet.state not in {'draft', 'submit'})._check_can_reset_approval()
            // self.sudo()._do_reverse_moves()
            // self._do_reset_approval()
            // self.sudo().account_move_ids = [Command.clear()]
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py) ---
            // def action_reset_expense_sheets(self):
            // super().action_reset_expense_sheets()
            // self.sudo()._sale_expense_reset_sol_quantities()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpenseSheet> SaleExpenseResetSolQuantitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py) ---
            // def _sale_expense_reset_sol_quantities(self):
            // sale_order_lines = self._get_sale_order_lines()
            // sale_order_lines.write({'qty_delivered': 0.0, 'product_uom_qty': 0.0})
            */
            return default;
        }

        protected async Task<HrExpenseSheet> SearchProductIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _search_product_ids(self, operator, value):
            // if operator == 'in' and not isinstance(value, list):
            //     value = [value]
            // return [('expense_line_ids.product_id', operator, value)]
            */
            return default;
        }

        public async Task<HrExpenseSheet> SetToPaidAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def set_to_paid(self):
            // # hook used in other modules to bypass payment registration
            // self.write({'state': 'done'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpenseSheet> SetToPostedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def set_to_posted(self):
            // # hook used in other modules to bypass move creation
            // self.write({'state': 'post'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpenseSheet> SheetMovePostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def action_sheet_move_post(self):
            // # When a move has been deleted
            // self.filtered(lambda sheet: not sheet.account_move_ids)._do_create_moves()
            // 
            // company_sheets = self.filtered(lambda sheet: sheet.payment_mode == 'company_account')
            // employee_sheets = self - company_sheets
            // 
            // # Post the employee-paid expenses moves
            // employee_sheets.account_move_ids.action_post()
            // 
            // # Post the company-paid expense through the payment instead, to post both at the same time
            // company_sheets.account_move_ids.origin_payment_id.action_post()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrExpenseSheet> SubmitSheetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def action_submit_sheet(self):
            // self._do_submit()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrExpenseSheet> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
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
            //     case 'done':
            //         return self.env.ref('hr_expense.mt_expense_paid')
            //     case 'approve':
            //         if init_values['state'] in {'post', 'done'}:  # Reverting state
            //             subtype = 'hr_expense.mt_expense_entry_draft' if self.account_move_ids else 'hr_expense.mt_expense_entry_delete'
            //             return self.env.ref(subtype)
            //         return self.env.ref('hr_expense.mt_expense_approved')
            //     case _:
            //         return super()._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<HrExpenseSheet> UnlinkExceptPostedOrPaidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _unlink_except_posted_or_paid(self):
            // for expense in self:
            //     if expense.state in {'post', 'done'}:
            //         raise UserError(_('You cannot delete a posted or paid expense.'))
            */
            return default;
        }

        protected async Task<HrExpenseSheet> UpdateSheetNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _update_sheet_name(self):
            // """ Set the sheet name to the computed default sheet name when no name is specified. """
            // expense_lines = self.expense_line_ids
            // if not self.name and expense_lines:
            //     self.name = self._get_default_sheet_name(expense_lines)
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ValidateAnalyticDistributionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py) ---
            // def _validate_analytic_distribution(self):
            // for line in self.expense_line_ids:
            //     line._validate_distribution(account=line.account_id.id, product=line.product_id.id, business_domain='expense', company_id=line.company_id.id)
            */
            return default;
        }
    }
}