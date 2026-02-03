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
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailThreadMainAttachmentAppService : ApplicationService, IMailThreadMainAttachmentAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public MailThreadMainAttachmentAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionActivateCurrencyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_activate_currency(self):
            // self.currency_id.filtered(lambda currency: not currency.active).write({'active': True})
            */
            return default;
        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_add_from_catalog(self):
            // res = super().action_add_from_catalog()
            // res['search_view_id'] = [self.env.ref('account.product_view_search_catalog').id, 'search']
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionApproveAsync<TEntity>(IEnumerable<TEntity> entities, object check_state) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_approve(self, check_state=True):
            // current_employee = self.env.user.employee_id
            // leave_to_approve = self.env['hr.leave']
            // leave_to_validate = self.env['hr.leave']
            // for leave in self:
            //     if check_state and leave.can_validate or not check_state and leave.validation_type != "both":
            //         leave_to_validate += leave
            //     elif check_state and leave.can_approve or not check_state and leave.validation_type == 'both':
            //         leave_to_approve += leave
            //     else:
            //         raise UserError(self.env._('You cannot approve this leave.'))
            // leave_to_approve.write({'state': 'validate1', 'first_approver_id': current_employee.id})
            // leave_to_validate._action_validate(check_state)
            // if not self.env.context.get('leave_fast_create'):
            //     self.activity_update()
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionApproveDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_archive(self):
            // archived_employees = self.filtered('active')
            // res = super().action_archive()
            // if archived_employees:
            //     # Empty links to this employees (example: manager, coach, time off responsible, ...)
            //     employee_fields_to_empty = self._get_employee_m2o_to_empty_on_archived_employees()
            //     user_fields_to_empty = self._get_user_m2o_to_empty_on_archived_employees()
            //     employee_domain = Domain.OR(Domain(field, 'in', archived_employees.ids) for field in employee_fields_to_empty)
            //     user_domain = Domain.OR(Domain(field, 'in', archived_employees.user_id.ids) for field in user_fields_to_empty)
            //     employees = self.env['hr.employee'].search(employee_domain | user_domain)
            //     for employee in employees:
            //         for field in employee_fields_to_empty:
            //             if employee[field] in archived_employees:
            //                 employee[field] = False
            //         for field in user_fields_to_empty:
            //             if employee[field] in archived_employees.user_id:
            //                 employee[field] = False
            // 
            //     if len(archived_employees) == 1 and not self.env.context.get('no_wizard', False):
            //         return {
            //             'type': 'ir.actions.act_window',
            //             'name': _('Register Departure'),
            //             'res_model': 'hr.departure.wizard',
            //             'view_mode': 'form',
            //             'target': 'new',
            //             'context': {'active_id': self.id},
            //             'views': [[False, 'form']]
            //         }
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_archive(self):
            // return super(HrApplicant, self.with_context(just_unarchived=True)).action_archive()
            */
            return default;
        }

        public async Task<TEntity> ActionBackToApprovalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_back_to_approval(self):
            // self.filtered(lambda l: l.can_back_to_approve)._move_validate_leave_to_confirm()
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_cancel(self):
            // self.state = 'canceled'
            // draft_moves = self.move_id.filtered(lambda m: m.state == 'draft')
            // draft_moves.unlink()
            // (self.move_id - draft_moves).button_cancel()
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_cancel(self):
            // self.ensure_one()
            // 
            // return {
            //     'name': _('Cancel Time Off'),
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'res_model': 'hr.holidays.cancel.leave',
            //     'view_mode': 'form',
            //     'views': [[False, 'form']],
            //     'context': {
            //         'default_leave_id': self.id,
            //         'dialog_size': "medium",
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionCreateMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_create_meeting(self):
            // """ This opens Meeting's calendar view to schedule meeting on current applicant
            //     @return: Dictionary value for created Meeting view
            // """
            // self.ensure_one()
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('You must define a Contact Name for this applicant.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // partners = self.partner_id | self.department_id.manager_id.user_id.partner_id
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     partners |= self.env.user.partner_id
            // else:
            //     partners |= self.user_id.partner_id
            // 
            // res = self.env['ir.actions.act_window']._for_xml_id('calendar.action_calendar_event')
            // # As we are redirected from the hr.applicant, calendar checks rules on "hr.applicant",
            // # in order to decide whether to allow creation of a meeting.
            // # As interviewer does not have create right on the hr.applicant, in order to allow them
            // # to create a meeting for an applicant, we pass 'create': True to the context.
            // res['context'] = {
            //     'create': True,
            //     'default_applicant_id': self.id,
            //     'default_partner_ids': partners.ids,
            //     'default_user_id': self.env.uid,
            //     'default_name': self.partner_name,
            //     'attachment_ids': self.attachment_ids.ids
            // }
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUserAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_user(self):
            // self.ensure_one()
            // if self.user_id:
            //     raise ValidationError(_("This employee already has an user."))
            // return {
            //     'name': _('Create User'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.users',
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('hr.view_users_simple_form').id,
            //     'target': 'new',
            //     'context': {
            //         **self.env.context,
            //         'default_create_employee_id': self.id,
            //         'default_name': self.name,
            //         'default_phone': self.work_phone,
            //         'default_mobile': self.mobile_phone,
            //         'default_login': self.work_email,
            //         'default_partner_id': self.work_contact_id.id,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_users(self):
            // def _get_user_creation_notification_action(message, message_type, next_action):
            //     return {
            //             'type': 'ir.actions.client',
            //             'tag': 'display_notification',
            //             'params': {
            //                 'title': self.env._("User Creation Notification"),
            //                 'type': message_type,
            //                 'message': message,
            //                 'next': next_action
            //             }
            //         }
            // 
            // employee_emails = [
            //     normalized_email
            //     for employee in self
            //     for normalized_email in tools.mail.email_normalize_all(employee.work_email)
            // ]
            // conflicting_users = self.env['res.users']
            // if employee_emails:
            //     conflicting_users = self.env['res.users'].search([
            //         '|', ('email_normalized', 'in', employee_emails),
            //         ('login', 'in', employee_emails),
            //     ])
            // old_users = []
            // new_users = []
            // users_without_emails = []
            // users_with_invalid_emails = []
            // users_with_existing_email = []
            // for employee in self:
            //     if employee.user_id:
            //         old_users.append(employee.name)
            //         continue
            //     if not employee.work_email:
            //         users_without_emails.append(employee.name)
            //         continue
            //     if not tools.email_normalize(employee.work_email):
            //         users_with_invalid_emails.append(employee.name)
            //         continue
            //     if email_normalize(employee.work_email) in conflicting_users.mapped('email_normalized'):
            //         users_with_existing_email.append(employee.name)
            //         continue
            //     new_users.append({
            //         'create_employee_id': employee.id,
            //         'name': employee.name,
            //         'phone': employee.work_phone,
            //         'login': tools.email_normalize(employee.work_email),
            //         'partner_id': employee.work_contact_id.id,
            //     })
            // 
            // next_action = {'type': 'ir.actions.act_window_close'}
            // if new_users:
            //     self.env['res.users'].create(new_users)
            //     message = _('Users %s creation successful', ', '.join([user['name'] for user in new_users]))
            //     next_action = _get_user_creation_notification_action(message, 'success', {
            //         "type": "ir.actions.client",
            //         "tag": "soft_reload",
            //         "params": {"next": next_action},
            //     })
            // 
            // if old_users:
            //     message = _('User already exists for Those Employees %s', ', '.join(old_users))
            //     next_action = _get_user_creation_notification_action(message, 'warning', next_action)
            // 
            // if users_without_emails:
            //     message = _("You need to set the work email address for %s", ', '.join(users_without_emails))
            //     next_action = _get_user_creation_notification_action(message, 'danger', next_action)
            // 
            // if users_with_invalid_emails:
            //     message = _("You need to set a valid work email address for %s", ', '.join(users_with_invalid_emails))
            //     next_action = _get_user_creation_notification_action(message, 'danger', next_action)
            // 
            // if users_with_existing_email:
            //     message = _('User already exists with the same email for Employees %s', ', '.join(users_with_existing_email))
            //     next_action = _get_user_creation_notification_action(message, 'warning', next_action)
            // 
            // return next_action
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_users_confirmation(self):
            // raise RedirectWarning(
            //         message=_("You're about to invite new users. %s users will be created with the default user template's rights. "
            //         "Adding new users may increase your subscription cost. Do you wish to continue?", len(self.ids)),
            //         action=self.env.ref('hr.action_hr_employee_create_users').id,
            //         button_text=_('Confirm'),
            //         additional_context={
            //             'selected_ids': self.ids,
            //         },
            //     )
            */
            return default;
        }

        public async Task<TEntity> ActionDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_documents(self):
            // domain = [('id', 'in', self.attachment_ids.ids)]
            // return {
            //     'name': _("Supporting Documents"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'context': {'create': False},
            //     'view_mode': 'kanban',
            //     'domain': domain
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_draft(self):
            // self.state = 'draft'
            // self.move_id.button_draft()
            */
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_duplicate(self):
            // # offer the possibility to duplicate thanks to a button instead of a hidden menu, which is more visible
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_move_journal_line")
            // action['context'] = dict(self.env.context)
            // action['context']['view_no_maturity'] = False
            // action['views'] = [(self.env.ref('account.view_move_form').id, 'form')]
            // action['res_id'] = self.copy().id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionForceRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_force_register_payment(self):
            // if any(m.move_type == 'entry' for m in self):
            //     raise UserError(_("You cannot register payments for miscellaneous entries."))
            // return self.line_ids.action_register_payment()
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceDownloadPdfAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_invoice_download_pdf(self, target = "download"):
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': f'/account/download_invoice_documents/{",".join(map(str, self.ids))}/pdf',
            //     'target': target,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _action_invoice_ready_to_be_sent(self):
            // """ Hook allowing custom code when an invoice becomes ready to be sent by mail to the customer.
            // For example, when an EDI document must be sent to the government and be signed by it.
            // """
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_invoice_sent(self):
            // """ Open a window to compose an email, with the edi invoice template
            //     message loaded by default
            // """
            // self.ensure_one()
            // report_action = self.action_send_and_print()
            // report_action['context'].update({'allow_partners_without_mail': True})
            // return self._get_action_with_base_document_layout_configurator(report_action)
            */
            return default;
        }

        public async Task<TEntity> ActionJobAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_job_add_applicants(self):
            // return {
            //     "name": _("Create Applications"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "job.add.applicants",
            //     "target": "new",
            //     "views": [[False, "form"]],
            //     "context": {
            //         "is_modal": True,
            //         "dialog_size": "medium",
            //         "default_applicant_ids": self.ids
            //         or self.env.context.get("default_applicant_ids"),
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionMoveDownloadAllAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_move_download_all(self):
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': f'/account/download_move_attachments/{",".join(str(move_id) for move_id in self.ids)}',
            //     'target': 'download',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAccountMoveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ActionOpenAllocationWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_open_allocation_wizard(self):
            // self.ensure_one()
            // wizard = self.env['hr.bank.account.allocation.wizard'].create({
            //     'employee_id': self.id,
            // })
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': self.env._('Bank Account Allocation'),
            //     'res_model': 'hr.bank.account.allocation.wizard',
            //     'res_id': wizard.id,
            //     'view_mode': 'form',
            //     'target': 'new',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenApplicationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_applications(self):
            // self.ensure_one()
            // similar_applicants = (
            //     self.env["hr.applicant"]
            //     .with_context(active_test=False)
            //     .search(
            //         self._get_similar_applicants_domain(ignore_talent=True),
            //     )
            // )
            // return {
            //     "name": _("Applications"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "hr.applicant",
            //     "view_mode": "list,form",
            //     "domain": [("id", "in", similar_applicants.ids)],
            //     "context": {
            //         "active_test": False,
            //         "search_default_stage": 1,
            //         "default_applicant_ids": self.ids,
            //         "no_create_application_button": True,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_attachments(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'name': _('Documents'),
            //     'context': {
            //         'default_res_model': 'hr.applicant',
            //         'default_res_id': self.ids[0],
            //         'show_partner_name': 1,
            //     },
            //     'view_mode': 'list,form',
            //     'views': [
            //         (self.env.ref('hr_recruitment.ir_attachment_hr_recruitment_list_view').id, 'list'),
            //         (False, 'form'),
            //     ],
            //     'search_view_id': self.env.ref('hr_recruitment.ir_attachment_view_search_inherit_hr_recruitment').ids,
            //     'domain': [('res_model', '=', 'hr.applicant'), ('res_id', 'in', self.ids), ],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_open_business_doc(self):
            // self.ensure_one()
            // if self.origin_payment_id:
            //     name = _("Payment")
            //     res_model = 'account.payment'
            //     res_id = self.origin_payment_id.id
            // elif self.statement_line_id:
            //     name = _("Bank Transaction")
            //     res_model = 'account.bank.statement.line'
            //     res_id = self.statement_line_id.id
            // else:
            //     name = _("Journal Entry")
            //     res_model = 'account.move'
            //     res_id = self.id
            // 
            // return {
            //     'name': name,
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'views': [(False, 'form')],
            //     'res_model': res_model,
            //     'res_id': res_id,
            //     'target': 'current',
            // }
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_open_business_doc(self):
            // return {
            //     'name': _("Payment"),
            //     'type': 'ir.actions.act_window',
            //     'views': [(False, 'form')],
            //     'res_model': 'account.payment',
            //     'res_id': self.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_employee(self):
            // self.ensure_one()
            // return {
            //     'name': _('Employee'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.employee',
            //     'view_mode': 'form',
            //     'res_id': self.employee_id.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSplitExpenseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ActionOpenVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_open_versions(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': self.employee_id.name + self.env._(' Records'),
            //     'path': 'versions',
            //     'res_model': 'hr.version',
            //     'view_mode': 'list,graph,pivot',
            //     'views': [(self.env.ref('hr.hr_version_list_view').id, 'list'), (False, 'graph'), (False, 'pivot')],
            //     'domain': [('employee_id', '=', self.employee_id.id)],
            //     'search_view_id': self.env.ref('hr.hr_version_search_view').id
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionPayAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ActionPostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_post(self):
            // # Disabled by default to avoid breaking automated action flow
            // if (
            //     not self.env.context.get('disable_abnormal_invoice_detection', True)
            //     and self.filtered(lambda m: m.abnormal_amount_warning or m.abnormal_date_warning)
            // ):
            //     wizard = self.env['validate.account.move'].create({
            //         'move_ids': [Command.set(self.ids)],
            //     })
            //     return {
            //         'name': _("Confirm Entries"),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'validate.account.move',
            //         'res_id': wizard.id,
            //         'view_mode': 'form',
            //         'target': 'new',
            //     }
            // if self:
            //     self._post(soft=False)
            // if autopost_bills_wizard := self._show_autopost_bills_wizard():
            //     return autopost_bills_wizard
            // return False
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_post(self):
            // ''' draft -> posted '''
            // # Do not allow posting if the account is required but not trusted
            // for payment in self:
            //     if (
            //         payment.require_partner_bank_account
            //         and not payment.partner_bank_id.allow_out_payment
            //         and payment.payment_type == 'outbound'
            //     ):
            //         raise UserError(_(
            //             "To record payments with %(method_name)s, the recipient bank account must be manually validated. "
            //             "You should go on the partner bank account of %(partner)s in order to validate it.",
            //             method_name=self.payment_method_line_id.name,
            //             partner=payment.partner_id.display_name,
            //         ))
            // self.filtered(lambda pay: pay.outstanding_account_id.account_type == 'asset_cash').state = 'paid'
            // # Avoid going back one state when clicking on the confirm action in the payment list view and having paid expenses selected
            // # We need to set values to each payment to avoid recomputation later
            // self.filtered(lambda pay: pay.state in {False, 'draft', 'in_process'}).state = 'in_process'
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

        public async Task<TEntity> ActionPrintPdfAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_print_pdf(self):
            // self.ensure_one()
            // invoice_template = self.env['account.move.send']._get_default_pdf_report_id(self)
            // report_action = invoice_template.report_action(self.id, config=False)
            // return self._get_action_with_base_document_layout_configurator(report_action)
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def action_refuse(self):
            // """ Refuse an expense with a reason """
            // self._check_can_refuse()
            // return self.env["ir.actions.act_window"]._for_xml_id('hr_expense.hr_expense_refuse_wizard_action')
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_refuse(self):
            // current_employee = self.env.user.employee_id
            // if any(holiday.state not in ['confirm', 'validate', 'validate1'] for holiday in self):
            //     raise UserError(_('Time off request must be confirmed or validated in order to refuse it.'))
            // 
            // self._notify_manager()
            // validated_holidays = self.filtered(lambda hol: hol.state == 'validate1')
            // validated_holidays.write({'state': 'refuse', 'first_approver_id': current_employee.id})
            // (self - validated_holidays).write({'state': 'refuse', 'second_approver_id': current_employee.id})
            // # Delete the meeting
            // self.mapped('meeting_id').write({'active': False})
            // # Post a second message, more verbose than the tracking message
            // for holiday in self:
            //     if holiday.employee_id.user_id:
            //         holiday.message_post(
            //             body=_('Your %(leave_type)s planned on %(date)s has been refused', leave_type=holiday.holiday_status_id.display_name, date=holiday.date_from),
            //             partner_ids=holiday.employee_id.user_id.partner_id.ids)
            // 
            // self.activity_update()
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_register_payment(self):
            // if any(m.state != 'posted' for m in self):
            //     raise UserError(_("You can only register payment for posted journal entries."))
            // return self.action_force_register_payment()
            */
            return default;
        }

        public async Task<TEntity> ActionRejectAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_reject(self):
            // self.state = 'rejected'
            */
            return default;
        }

        public async Task<TEntity> ActionRelatedContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_related_contacts(self):
            // related_partners = self._get_related_partners()
            // action = {
            //     'name': _("Related Contacts"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.partner',
            //     'view_mode': 'form',
            // }
            // if len(related_partners) > 1:
            //     action['view_mode'] = 'kanban,list,form'
            //     action['domain'] = [('id', 'in', related_partners.ids)]
            //     return action
            // else:
            //     action['res_id'] = related_partners.id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionResetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ActionReverseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_reverse(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("account.action_view_account_move_reversal")
            // 
            // if self.is_invoice():
            //     action['name'] = _('Credit Note')
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionSendAndPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_send_and_print(self):
            // self.env['account.move.send']._check_move_constraints(self)
            // return {
            //     'name': _("Send"),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'account.move.send.wizard' if len(self) == 1 else 'account.move.send.batch.wizard',
            //     'target': 'new',
            //     'context': {
            //         'active_model': 'account.move',
            //         'active_ids': self.ids,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_send_email(self):
            // return {
            //     'name': _('Send Email'),
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'res_model': 'applicant.send.mail',
            //     'context': {
            //         'default_applicant_ids': self.ids,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionShowSameReceiptExpenseIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ActionSplitWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ActionSubmitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ActionSwitchMoveTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_switch_move_type(self):
            // if any(move.posted_before for move in self):
            //     raise ValidationError(_("Once a document has been posted once, its type is set in stone and you can't change it anymore."))
            // if any(move.move_type == "entry" for move in self):
            //     raise ValidationError(_("This action isn't available for this document."))
            // 
            // for move in self:
            //     in_out, old_move_type = move.move_type.split('_')
            //     new_move_type = f"{in_out}_{'invoice' if old_move_type == 'refund' else 'refund'}"
            //     move.name = False
            //     move.write({
            //         'move_type': new_move_type,
            //         'currency_id': move.currency_id.id,
            //         'fiscal_position_id': move.fiscal_position_id.id,
            //     })
            //     if move.amount_total < 0:
            //         line_ids_commands = []
            //         for line in move.line_ids:
            //             if line.display_type != 'product':
            //                 continue
            //             line_ids_commands.append(Command.update(line.id, {
            //                 'quantity': -line.quantity,
            //                 'extra_tax_data': self.env['account.tax']._reverse_quantity_base_line_extra_tax_data(line.extra_tax_data),
            //             }))
            //         move.write({'line_ids': line_ids_commands})
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_talent_pool_add_applicants(self):
            // return {
            //     "name": _("Add applicant(s) to the pool"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "talent.pool.add.applicants",
            //     "target": "new",
            //     "views": [[False, "form"]],
            //     "context": {
            //         "is_modal": True,
            //         "dialog_size": "medium",
            //         "default_talent_pool_ids": self.env.context.get(
            //             "default_talent_pool_ids"
            //         )
            //         or [],
            //         "default_applicant_ids": self.ids,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolStatButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_talent_pool_stat_button(self):
            // self.ensure_one()
            // # If the applicant has other applications linked to pool but for some
            // # reason this applicant is not linked to that account then link it
            // if not self.pool_applicant_id:
            //     self.link_applicant_to_talent()
            // return {
            //     "type": "ir.actions.act_window",
            //     "res_model": "hr.applicant",
            //     "view_mode": "form",
            //     "target": "current",
            //     "res_id": self.pool_applicant_id.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionToggleBlockPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_toggle_block_payment(self):
            // self.ensure_one()
            // if self.payment_state == 'blocked':
            //     self.payment_state = 'not_paid'
            //     self.env.add_to_compute(self._fields['payment_state'], self)
            // else:
            //     if self.payment_state in ('paid', 'in_payment'):
            //         raise UserError(_("You can't block a paid invoice."))
            //     self.payment_state = 'blocked'
            */
            return default;
        }

        public async Task<TEntity> ActionTogglePrimaryBankAccountTrustAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_toggle_primary_bank_account_trust(self):
            // self.ensure_one()
            // current_val = self.primary_bank_account_id.allow_out_payment
            // self.primary_bank_account_id.allow_out_payment = not current_val
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_unarchive(self):
            // res = super().action_unarchive()
            // self.write({
            //     'departure_reason_id': False,
            //     'departure_description': False,
            //     'departure_date': False
            // })
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_unarchive(self):
            // res = super(HrApplicant, self.with_context(just_unarchived=True)).action_unarchive()
            // self.reset_applicant()
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateFposValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_update_fpos_values(self):
            // lines_to_recompute = self.env['account.move.line']
            // for line in self.invoice_line_ids:
            //     if line.display_type in ('line_section', 'line_note'):
            //         continue
            //     if not line.price_unit:
            //         lines_to_recompute |= line
            //         continue
            //     new_taxes = line._get_computed_taxes()
            //     if line.tax_ids.filtered('price_include') != new_taxes.filtered('price_include'):
            //         line.price_unit = line.product_id._get_tax_included_unit_price_from_price(
            //             line.price_unit,
            //             line.tax_ids,
            //             fiscal_position=line.move_id.fiscal_position_id,
            //             product_taxes_after_fp=new_taxes,
            //         )
            // lines_to_recompute._compute_price_unit()
            // self.invoice_line_ids._compute_tax_ids()
            // self.line_ids._compute_account_id()
            */
            return default;
        }

        public async Task<TEntity> ActionUserCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reason) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _action_user_cancel(self, reason=None):
            // self.ensure_one()
            // if not self.can_cancel:
            //     raise ValidationError(_('This time off cannot be cancelled.'))
            // 
            // self._force_cancel(reason, 'mail.mt_note')
            */
            return default;
        }

        public async Task<TEntity> ActionValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def action_validate(self):
            // self.state = 'paid'
            */
            return default;
        }

        public async Task<TEntity> ActionValidateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object check_state) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _action_validate(self, check_state=True):
            // current_employee = self.env.user.employee_id
            // leaves = self._get_leaves_on_public_holiday()
            // if check_state and any(not holiday.can_validate for holiday in self):
            //     raise UserError(_('You can\'t validate this leave.'))
            // if leaves:
            //     raise ValidationError(_('The following employees are not supposed to work during that period:\n %s') % ','.join(leaves.mapped('employee_id.name')))
            // 
            // self.write({'state': 'validate'})
            // 
            // leaves_second_approver = self.env['hr.leave']
            // leaves_first_approver = self.env['hr.leave']
            // 
            // for leave in self:
            //     if leave.validation_type == 'both':
            //         leaves_second_approver += leave
            //     else:
            //         leaves_first_approver += leave
            // 
            // leaves_second_approver.write({'second_approver_id': current_employee.id})
            // leaves_first_approver.write({'first_approver_id': current_employee.id})
            // 
            // self._validate_leave_request()
            // if not self.env.context.get('leave_fast_create'):
            //     self.filtered(lambda holiday: holiday.validation_type != 'no_validation').activity_update()
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionValidateMovesWithConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_validate_moves_with_confirmation(self):
            // """
            // If 'restrict_mode_hash_table' is enabled or future-dated moves, open a confirmation wizard;
            // otherwise, validate moves directly.
            // """
            // draft_moves = self.filtered(lambda m: m.state == 'draft' and m.line_ids)
            // if not draft_moves:
            //     raise UserError(_('There are no journal items in the draft state to post.'))
            // 
            // need_confirmation_moves = draft_moves._get_moves_requiring_confirmation()
            // 
            // direct_validate_moves = draft_moves - need_confirmation_moves
            // if direct_validate_moves:
            //     direct_validate_moves._post(soft=False)
            // if need_confirmation_moves:
            //     wizard = self.env['validate.account.move'].create({
            //         'move_ids': [Command.set(need_confirmation_moves.ids)],
            //     })
            //     return {
            //         'name': _("Confirm Entries"),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'validate.account.move',
            //         'res_id': wizard.id,
            //         'view_mode': 'form',
            //         'view_id': self.env.ref('account.validate_account_move_view').id,
            //         'target': 'new',
            //     }
            // return False
            */
            return default;
        }

        public async Task<TEntity> ActivityUpdateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def activity_update(self):
            // if self.env.context.get('mail_activity_automation_skip'):
            //     return
            // 
            // to_clean, to_do, to_do_confirm_activity = self.env['hr.leave'], self.env['hr.leave'], self.env['hr.leave']
            // activity_vals = []
            // today = fields.Date.today()
            // model_id = self.env['ir.model']._get_id('hr.leave')
            // confirm_activity = self.env.ref('hr_holidays.mail_act_leave_approval')
            // approval_activity = self.env.ref('hr_holidays.mail_act_leave_second_approval')
            // for holiday in self:
            //     if holiday.state in ['confirm', 'validate1']:
            //         if holiday.holiday_status_id.leave_validation_type != 'no_validation':
            //             if holiday.state == 'confirm':
            //                 activity_type = confirm_activity
            //                 note = _(
            //                     'New %(leave_type)s Request created by %(user)s',
            //                     leave_type=holiday.holiday_status_id.name,
            //                     user=holiday.create_uid.name,
            //                 )
            //             else:
            //                 activity_type = approval_activity
            //                 note = _(
            //                     'Second approval request for %(leave_type)s',
            //                     leave_type=holiday.holiday_status_id.name,
            //                 )
            //                 to_do_confirm_activity += holiday
            //             user_ids = holiday.sudo()._get_responsible_for_approval().ids
            //             for user_id in user_ids:
            //                 date_deadline = (
            //                     (holiday.date_from -
            //                      relativedelta(**{activity_type.delay_unit or 'days': activity_type.delay_count or 0})).date()
            //                     if holiday.date_from else today)
            //                 if date_deadline < today:
            //                     date_deadline = today
            //                 activity_vals.append({
            //                     'activity_type_id': activity_type.id,
            //                     'automated': True,
            //                     'date_deadline': date_deadline,
            //                     'note': note,
            //                     'user_id': user_id,
            //                     'res_id': holiday.id,
            //                     'res_model_id': model_id,
            //                 })
            //     elif holiday.state == 'validate':
            //         to_do |= holiday
            //     elif holiday.state in ['refuse', 'cancel']:
            //         to_clean |= holiday
            // if to_clean:
            //     to_clean.activity_unlink(self._get_to_clean_activities(), only_automated=False)
            // if to_do_confirm_activity:
            //     to_do_confirm_activity.activity_feedback(['hr_holidays.mail_act_leave_approval'])
            // if to_do:
            //     to_do.activity_feedback(['hr_holidays.mail_act_leave_approval', 'hr_holidays.mail_act_leave_second_approval'])
            // self.env['mail.activity'].with_context(short_name=False).create(activity_vals)
            */
            return default;
        }

        public async Task<TEntity> AddFollowerAsync<TEntity>(IEnumerable<TEntity> entities, Guid employee_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def add_follower(self, employee_id):
            // employee = self.env['hr.employee'].browse(employee_id)
            // if employee.user_id:
            //     self.message_subscribe(partner_ids=employee.user_id.partner_id.ids)
            */
            return default;
        }

        public async Task<TEntity> AffectTaxReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _affect_tax_report(self):
            // return any(line._affect_tax_report() for line in (self.line_ids | self.invoice_line_ids))
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyDeltaRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object date_origin, object period) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _apply_delta_recurring_entries(self, date, date_origin, period):
            // '''Advances date by `period` months, maintaining original day of the month if possible.'''
            // deltas = {'monthly': 1, 'quarterly': 3, 'yearly': 12}
            // prev_months = (date.year - date_origin.year) * 12 + date.month - date_origin.month
            // return date_origin + relativedelta(months=deltas[period] + prev_months)
            */
            return default;
        }

        public async Task<TEntity> ArchiveApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def archive_applicant(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Refuse Reason'),
            //     'res_model': 'applicant.get.refuse.reason',
            //     'view_mode': 'form',
            //     'target': 'new',
            //     'context': {
            //         'default_applicant_ids': self.ids,
            //         'active_test': False,
            //         'hide_mail_template_management_options': True,
            //     },
            //     'views': [[False, 'form']]
            // }
            */
            return default;
        }

        public async Task<TEntity> AttachDocumentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def attach_document(self, **kwargs):
            // """When an attachment is uploaded as a receipt, set it as the main attachment."""
            // self._message_set_main_attachment_id(self.env["ir.attachment"].browse(kwargs['attachment_ids'][-1:]), force=True)
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _auto_init(self):
            // super()._auto_init()
            // if not column_exists(self.env.cr, "account_move", "preferred_payment_method_line_id"):
            //     create_column(self.env.cr, "account_move", "preferred_payment_method_line_id", "int4")
            */
            return default;
        }

        public async Task<TEntity> AutopostBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _autopost_bill(self):
            // # Verify if the bill should be autoposted, if so, post it
            // self.ensure_one()
            // if (
            //     self.company_id.autopost_bills
            //     and self.partner_id
            //     and self.is_purchase_document(include_receipts=True)
            //     and self.partner_id.autopost_bills == 'always'
            //     and not self.abnormal_amount_warning
            //     and not self.restrict_mode_hash_table
            // ):
            //     if self.duplicated_ref_ids:
            //         self.message_post(body=_("Auto-post was disabled on this invoice because a potential duplicate was detected."))
            //     else:
            //         self.action_post()
            */
            return default;
        }

        public async Task<TEntity> AutopostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_size) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _autopost_draft_entries(self, batch_size=100):
            // ''' This method is called from a cron job.
            // It is used to post entries such as those created by the module
            // account_asset and recurring entries created in _post().
            // '''
            // domain = [
            //     ('state', '=', 'draft'),
            //     ('date', '<=', fields.Date.context_today(self)),
            //     ('auto_post', '!=', 'no'),
            // ]
            // moves = self.search(domain, limit=batch_size)
            // remaining = len(moves) if len(moves) < batch_size else self.search_count(domain)
            // self.env['ir.cron']._commit_progress(remaining=remaining)
            // 
            // try:  # try posting in batch
            //     moves._post()
            //     self.env['ir.cron']._commit_progress(len(moves))
            //     return
            // except UserError:  # if at least one move cannot be posted, handle moves one by one
            //     self.env.cr.rollback()
            // 
            // for move in moves:
            //     try:
            //         move = move.try_lock_for_update().filtered_domain(domain)
            //         if not move:
            //             continue
            //         move._post()
            //         self.env['ir.cron']._commit_progress(1)
            //     except UserError as e:
            //         self.env.cr.rollback()
            //         msg = _('The move could not be posted for the following reason: %(error_message)s', error_message=e)
            //         move.message_post(body=msg, message_type='comment')
            //         self.env['ir.cron']._commit_progress()
            */
            return default;
        }

        public async Task<TEntity> BuildCreditWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object current_amount, object exclude_current, object exclude_amount) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _build_credit_warning_message(self, record, current_amount=0.0, exclude_current=False, exclude_amount=0.0):
            // """ Build the warning message that will be displayed in a yellow banner on top of the current record
            //     if the partner exceeds a credit limit (set on the company or the partner itself).
            //     :param record:                  The record where the warning will appear (Invoice, Sales Order...).
            //     :param float current_amount:    The partner's outstanding credit amount from the current document.
            //     :param bool exclude_current:    DEPRECATED in favor of parameter `exclude_amount`:
            //                                     Whether to exclude `current_amount` from the credit to invoice.
            //     :param float exclude_amount:    The amount to subtract from the partner's `credit_to_invoice`.
            //                                     Consider the warning on a draft invoice created from a sales order.
            //                                     After confirming the invoice the (partial) amount (on the invoice)
            //                                     stemming from sales orders will be substracted from the `credit_to_invoice`.
            //                                     This will reduce the total credit of the partner.
            //                                     This parameter is used to reflect this amount.
            //     :return:                        The warning message to be showed.
            //     :rtype: str
            // """
            // partner_id = record.partner_id.commercial_partner_id
            // credit_to_invoice = partner_id.credit_to_invoice - exclude_amount
            // total_credit = partner_id.credit + credit_to_invoice + current_amount
            // if not partner_id.credit_limit or total_credit <= partner_id.credit_limit:
            //     return ''
            // msg = _(
            //     '%(partner_name)s has reached its credit limit of: %(credit_limit)s',
            //     partner_name=partner_id.name,
            //     credit_limit=formatLang(self.env, partner_id.credit_limit, currency_obj=record.company_id.currency_id)
            // )
            // total_credit_formatted = formatLang(self.env, total_credit, currency_obj=record.company_id.currency_id)
            // if credit_to_invoice > 0 and current_amount > 0:
            //     return msg + '\n' + _(
            //         'Total amount due (including sales orders and this document): %(total_credit)s',
            //         total_credit=total_credit_formatted
            //     )
            // elif credit_to_invoice > 0:
            //     return msg + '\n' + _(
            //         'Total amount due (including sales orders): %(total_credit)s',
            //         total_credit=total_credit_formatted
            //     )
            // elif current_amount > 0:
            //     return msg + '\n' + _(
            //         'Total amount due (including this document): %(total_credit)s',
            //         total_credit=total_credit_formatted
            //     )
            // else:
            //     return msg + '\n' + _(
            //         'Total amount due: %(total_credit)s',
            //         total_credit=total_credit_formatted
            //     )
            */
            return default;
        }

        public async Task<TEntity> ButtonCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_cancel(self):
            // # Shortcut to move from posted to cancelled directly. This is useful for E-invoices that must not be changed
            // # when sent to the government.
            // moves_to_reset_draft = self.filtered(lambda x: x.state == 'posted')
            // if moves_to_reset_draft:
            //     moves_to_reset_draft.button_draft()
            // 
            // if any(move.state != 'draft' for move in self):
            //     raise UserError(_("Only draft journal entries can be cancelled."))
            // 
            // self.line_ids.remove_move_reconcile()
            // self.payment_ids.state = "canceled"
            // self.write({'auto_post': 'no', 'state': 'cancel'})
            */
            return default;
        }

        public async Task<TEntity> ButtonDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_draft(self):
            // if any(move.state not in ('cancel', 'posted') for move in self):
            //     raise UserError(_("Only posted/cancelled journal entries can be reset to draft."))
            // if any(move.need_cancel_request for move in self):
            //     raise UserError(_("You can't reset to draft those journal entries. You need to request a cancellation instead."))
            // 
            // self._check_draftable()
            // # We remove all the analytics entries for this journal
            // self.line_ids.analytic_line_ids.with_context(skip_analytic_sync=True).unlink()
            // self.state = 'draft'
            // self.sending_data = False
            // 
            // self._detach_attachments()
            */
            return default;
        }

        public async Task<TEntity> ButtonHashAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_hash(self):
            // self._hash_moves(force_hash=True)
            */
            return default;
        }

        public async Task<TEntity> ButtonOpenBillsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_open_bills(self):
            // ''' Redirect the user to the bill(s) paid by this payment.
            // :return:    An action on account.move.
            // '''
            // self.ensure_one()
            // 
            // action = {
            //     'name': _("Paid Bills"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.move',
            //     'context': {'create': False},
            // }
            // if len(self.reconciled_bill_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.reconciled_bill_ids.id,
            //     })
            // else:
            //     action.update({
            //         'view_mode': 'list,form',
            //         'domain': [('id', 'in', self.reconciled_bill_ids.ids)],
            //     })
            // return action
            */
            return default;
        }

        public async Task<TEntity> ButtonOpenInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_open_invoices(self):
            // ''' Redirect the user to the invoice(s) paid by this payment.
            // :return:    An action on account.move.
            // '''
            // self.ensure_one()
            // return self.reconciled_invoice_ids.with_context(
            //     create=False
            // )._get_records_action(
            //     name=_("Paid Invoices"),
            // )
            */
            return default;
        }

        public async Task<TEntity> ButtonOpenJournalEntryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_open_journal_entry(self):
            // ''' Redirect the user to this payment journal.
            // :return:    An action on account.move.
            // '''
            // self.ensure_one()
            // return {
            //     'name': _("Journal Entry"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.move',
            //     'context': {'create': False},
            //     'view_mode': 'form',
            //     'res_id': self.move_id.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> ButtonOpenStatementLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_open_statement_lines(self):
            // ''' Redirect the user to the statement line(s) reconciled to this payment.
            // :return:    An action on account.move.
            // '''
            // self.ensure_one()
            // 
            // action = {
            //     'name': _("Matched Transactions"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.bank.statement.line',
            //     'context': {'create': False},
            // }
            // if len(self.reconciled_statement_line_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.reconciled_statement_line_ids.id,
            //     })
            // else:
            //     action.update({
            //         'view_mode': 'list,form',
            //         'domain': [('id', 'in', self.reconciled_statement_line_ids.ids)],
            //     })
            // return action
            */
            return default;
        }

        public async Task<TEntity> ButtonRequestCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_request_cancel(self):
            // """ Hook allowing the localizations to request a cancellation from the government before cancelling the invoice. """
            // self.ensure_one()
            // if not self.need_cancel_request:
            //     raise UserError(_("You can only request a cancellation for invoice sent to the government."))
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def button_request_cancel(self):
            // return self.move_id.button_request_cancel()
            */
            return default;
        }

        public async Task<TEntity> ButtonSetCheckedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_set_checked(self):
            // self.set_moves_checked()
            */
            return default;
        }

        public async Task<TEntity> CalculateHashesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object previous_hash) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _calculate_hashes(self, previous_hash):
            // """
            // :return: dict of move_id: hash
            // """
            // hash_version = self.env.context.get('hash_version', MAX_HASH_VERSION)
            // 
            // def _getattrstring(obj, field_name):
            //     field_value = obj[field_name]
            //     if obj._fields[field_name].type == 'many2one':
            //         field_value = field_value.id
            //     if obj._fields[field_name].type == 'monetary' and hash_version >= 3:
            //         return float_repr(field_value, obj.currency_id.decimal_places)
            //     return str(field_value)
            // 
            // move2hash = {}
            // previous_hash = previous_hash or ''
            // 
            // for move in self:
            //     if previous_hash and previous_hash.startswith("$"):
            //         previous_hash = previous_hash.split("$")[2]  # The hash version is not used for the computation of the next hash
            //     values = {}
            //     for fname in move._get_integrity_hash_fields():
            //         values[fname] = _getattrstring(move, fname)
            // 
            //     for line in move.line_ids:
            //         for fname in line._get_integrity_hash_fields():
            //             k = 'line_%d_%s' % (line.id, fname)
            //             values[k] = _getattrstring(line, fname)
            //     current_record = dumps(values, sort_keys=True, ensure_ascii=True, indent=None, separators=(',', ':'))
            //     hash_string = sha256((previous_hash + current_record).encode('utf-8')).hexdigest()
            //     move2hash[move] = f"${hash_version}${hash_string}" if hash_version >= 4 else hash_string
            //     previous_hash = move2hash[move]
            // return move2hash
            */
            return default;
        }

        public async Task<TEntity> CanBeAutovalidatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> CanBeUnlinkedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _can_be_unlinked(self):
            // self.ensure_one()
            // lock_date = self.company_id._get_user_fiscal_lock_date(self.journal_id)
            // posted_caba_entry = self.state == 'posted' and (self.tax_cash_basis_rec_id or self.tax_cash_basis_origin_move_id)
            // posted_exchange_diff_entry = self.state == 'posted' and self.exchange_diff_partial_ids
            // return not self.inalterable_hash and self.date > lock_date and not posted_caba_entry and not posted_exchange_diff_entry
            */
            return default;
        }

        protected async Task<object> CanCommitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _can_commit():
            // """ Helper to know if we can commit the current transaction or not.
            // 
            // :returns: True if commit is acceptable, False otherwise.
            // """
            // return not modules.module.current_test
            */
            return default;
        }

        public async Task<TEntity> CanForceCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _can_force_cancel(self):
            // """ Hook to indicate whether it should be possible to force-cancel this invoice,
            // that is, cancel it without waiting for the cancellation request to succeed.
            // """
            // self.ensure_one()
            // return False
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CancelInvalidLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _cancel_invalid_leaves(self):
            // inspected_date = fields.Date.today() + timedelta(days=31)
            // start_datetime = datetime.combine(fields.Date.today(), datetime.min.time())
            // end_datetime = datetime.combine(inspected_date, datetime.max.time())
            // concerned_leaves = self.search([
            //     ('date_from', '>=', start_datetime),
            //     ('date_from', '<=', end_datetime),
            //     ('state', 'in', ['confirm', 'validate1', 'validate']),
            // ], order='date_from desc')
            // accrual_allocations = self.env['hr.leave.allocation'].search([
            //     ('employee_id', 'in', concerned_leaves.employee_id.ids),
            //     ('holiday_status_id', 'in', concerned_leaves.holiday_status_id.ids),
            //     ('allocation_type', '=', 'accrual'),
            //     ('date_from', '<=', end_datetime),
            //     '|',
            //     ('date_to', '>=', start_datetime),
            //     ('date_to', '=', False),
            // ])
            // # only take leaves linked to accruals
            // concerned_leaves = concerned_leaves\
            //     .filtered(lambda leave: leave.holiday_status_id in accrual_allocations.holiday_status_id)\
            //     .sorted('date_from', reverse=True)
            // reason = _("the accruated amount is insufficient for that duration.")
            // for leave in concerned_leaves:
            //     leave_type = leave.holiday_status_id
            //     date = leave.date_from.date()
            //     leave_type_data = leave_type.get_allocation_data(leave.employee_id, date)
            //     exceeding_duration = leave_type_data[leave.employee_id][0][1]['total_virtual_excess']
            //     excess_limit = leave_type.max_allowed_negative if leave_type.allows_negative else 0
            //     if exceeding_duration <= excess_limit:
            //         continue
            //     leave._force_cancel(reason, 'mail.mt_note')
            */
            return default;
        }

        public async Task<TEntity> CheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object operation) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_access(self, operation):
            // # This method override provides read access to 'hr.employee' in some
            // # situations, like setting a many2many field to comodel 'hr.employee'.
            // # Since Odoo 19, one must have read access to the comodel to modify the
            // # relation.
            // if operation == 'read' and self.env.context.get('_allow_read_hr_employee') is _ALLOW_READ_HR_EMPLOYEE:
            //     return None
            // 
            // return super()._check_access(operation)
            */
            return default;
        }

        public async Task<TEntity> CheckApprovalUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object state, object raise_if_not_possible) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_approval_update(self, state, raise_if_not_possible=True):
            //         """ Check if target state is achievable. """
            //         if self.env.is_superuser():
            //             return True
            // 
            //         is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // 
            //         for holiday in self:
            //             is_time_off_manager = holiday.employee_id.leave_manager_id == self.env.user
            //             dict_all_possible_state = holiday._get_next_states_by_state()
            //             validation_type = holiday.validation_type
            //             error_message = ""
            //             # Standard Check
            //             if holiday.state == state:
            //                 error_message = self.env._('You can\'t do the same action twice.')
            //             elif state == 'validate1' and validation_type != 'both':
            //                 error_message = self.env._('Not possible state. State Approve is only used for leave needed 2 approvals')
            //             elif holiday.state == 'cancel':
            //                 error_message = self.env._('A cancelled leave cannot be modified.')
            //             elif state not in dict_all_possible_state.get(holiday.state, {}):
            //                 if state == 'cancel':
            //                     error_message = self.env._('You can only cancel your own leave. You can cancel a leave only if this leave \
            // is approved, validated or refused.')
            //                 elif state == 'confirm':
            //                     error_message = self.env._('You can\'t reset a leave. Cancel/delete this one and create an other')
            //                 elif state == 'validate1':
            //                     if not is_time_off_manager:
            //                         error_message = self.env._('Only a Time Off Officer/Manager can approve a leave.')
            //                     else:
            //                         error_message = self.env._('You can\'t approve a validated leave.')
            //                 elif state == "validate":
            //                     if not is_time_off_manager:
            //                         error_message = self.env._('Only a Time Off Officer/Manager can validate a leave.')
            //                     elif holiday.state == "refuse":
            //                         error_message = self.env._('You can\'t approve this refused leave.')
            //                     else:
            //                         error_message = self.env._('You can only validate a leave with validation by Time Off Manager.')
            //                 elif state == "refuse":
            //                     if not is_time_off_manager:
            //                         error_message = self.env._('Only a Time Off Officer/Manager can refuse a leave.')
            //                     else:
            //                         error_message = self.env._('You can\'t refuse a leave with validation by Time Off Officer.')
            //             elif state != "cancel":
            //                 try:
            //                     holiday.check_access('write')
            //                 except UserError as e:
            //                     if raise_if_not_possible:
            //                         raise UserError(e)
            //                     return False
            //                 else:
            //                     continue
            //             if error_message:
            //                 if raise_if_not_possible:
            //                     raise UserError(error_message)
            //                 return False
            //         return True
            */
            return default;
        }

        public async Task<TEntity> CheckBalancedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_balanced(self, container):
            // ''' Assert the move is fully balanced debit = credit.
            // An error is raised if it's not the case.
            // '''
            // with self._disable_recursion(container, 'check_move_validity', default=True, target=False) as disabled:
            //     yield
            //     if disabled:
            //         return
            // 
            // if unbalanced_moves := self._get_unbalanced_moves(container):
            //     if len(unbalanced_moves) == 1:
            //         raise UserError(_("The entry is not balanced."))
            // 
            //     error_msg = _("The following entries are unbalanced:\n\n")
            //     for move in unbalanced_moves:
            //         error_msg += f"  - {self.browse(move[0]).name}\n"
            // 
            //     raise UserError(error_msg)
            */
            return default;
        }

        public async Task<TEntity> CheckCanApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> CheckCanCreateMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> CheckCanRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> CheckCanResetApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> CheckContractsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_contracts(self):
            //         """
            //             A leave cannot be set across multiple contracts.
            //             Note: a leave can be across multiple contracts despite this constraint.
            //             It happens if a leave is correctly created (not across multiple contracts) but
            //             contracts are later modifed/created in the middle of the leave.
            //         """
            //         for holiday in self.filtered('employee_id'):
            //             versions = holiday._get_overlapping_contracts()
            //             if len(versions.resource_calendar_id) > 1:
            //                 raise ValidationError(
            //                     self.env._("""A leave cannot be set across multiple versions with different working schedules.
            // 
            // Please create one time off for each version period.
            // 
            // Time off:
            // %(time_off)s
            // 
            // Versions:
            // %(versions)s""",
            //                       time_off=holiday.display_name,
            //                       versions='\n'.join(_(
            //                           "- '%(version)s' from %(start_date)s to %(end_date)s",
            //                           version=version.name or version.employee_id.name,
            //                           start_date=format_date(self.env, version.date_start),
            //                           end_date=format_date(self.env, version.date_end) if version.date_end else self.env._("undefined"),
            //                       ) for version in versions)))
            */
            return default;
        }

        public async Task<TEntity> CheckDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_date(self):
            // if self.env.context.get('leave_skip_date_check', False):
            //     return
            // for holiday in self:
            //     if holiday.dashboard_warning_message:
            //         raise ValidationError(holiday.dashboard_warning_message)
            */
            return default;
        }

        public async Task<TEntity> CheckDateStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_date_state(self):
            // if self.env.context.get('leave_skip_state_check'):
            //     return
            // for holiday in self:
            //     if holiday.state in ['validate1', 'validate']:
            //         raise ValidationError(_("This modification is not allowed in the current state."))
            */
            return default;
        }

        public async Task<TEntity> CheckDoubleValidationRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object employees, object state) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_double_validation_rules(self, employees, state):
            // if self.env.user.has_group('hr_holidays.group_hr_holidays_manager'):
            //     return
            // 
            // is_leave_user = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // if state == 'validate1':
            //     employees = employees.filtered(lambda employee: employee.leave_manager_id != self.env.user)
            //     if employees and not is_leave_user:
            //         raise AccessError(_('You cannot first approve a time off for %s, because you are not his time off manager', employees[0].name))
            // elif state == 'validate' and not is_leave_user:
            //     # Is probably handled via ir.rule
            //     raise AccessError(_('You don\'t have the rights to apply second approval on a time off request'))
            */
            return default;
        }

        public async Task<TEntity> CheckDraftableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_draftable(self):
            // exchange_move_ids = set()
            // if self:
            //     self.env['account.partial.reconcile'].flush_model(['exchange_move_id'])
            //     sql = SQL(
            //         """
            //             SELECT DISTINCT exchange_move_id
            //             FROM account_partial_reconcile
            //             WHERE exchange_move_id IN %s
            //         """,
            //         tuple(self.ids),
            //     )
            //     exchange_move_ids = {id_ for id_, in self.env.execute_query(sql)}
            // 
            // for move in self:
            //     if move.id in exchange_move_ids:
            //         raise UserError(_('You cannot reset to draft an exchange difference journal entry.'))
            //     if move.tax_cash_basis_rec_id or move.tax_cash_basis_origin_move_id:
            //         # If the reconciliation was undone, move.tax_cash_basis_rec_id will be empty;
            //         # but we still don't want to allow setting the caba entry to draft
            //         # (it'll have been reversed automatically, so no manual intervention is required),
            //         # so we also check tax_cash_basis_origin_move_id, which stays unchanged
            //         # (we need both, as tax_cash_basis_origin_move_id did not exist in older versions).
            //         raise UserError(_('You cannot reset to draft a tax cash basis journal entry.'))
            //     if move.inalterable_hash:
            //         raise UserError(_('You cannot reset to draft a locked journal entry.'))
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_field_access_rights(self, operation, field_names):
            // result = super().check_field_access_rights(operation, field_names)
            // if not field_names:
            //     weirdos = ['needed_terms', 'quick_encoding_vals', 'payment_term_details']
            //     result = [fname for fname in result if fname not in weirdos]
            // return result
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def check_field_access_rights(self, operation, field_names):
            // # DISCLAIMER: Dirty hack to avoid having to create a bridge module to override only a
            // # groups on a field which is not prefetched (because not stored) but would crash anyway
            // # if we try to read them directly (very uncommon use case). Don't add your field on this
            // # list if you can specify the group on the field directly (as all the other fields).
            // result = super().check_field_access_rights(operation, field_names)
            // if not self.env.user.has_group("hr.group_hr_user"):
            //     result = [field for field in result if field not in ['activity_calendar_event_id', 'rating_ids', 'website_message_ids', 'message_has_sms_error']]
            // return result
            */
            return default;
        }

        public async Task<TEntity> CheckFiscalLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_fiscal_lock_dates(self):
            // if self.env.context.get('bypass_lock_check') is BYPASS_LOCK_CHECK:
            //     return
            // for move in self:
            //     journal = move.journal_id
            //     violated_lock_dates = move.company_id._get_lock_date_violations(
            //         move.date,
            //         fiscalyear=True,
            //         sale=journal and journal.type == 'sale',
            //         purchase=journal and journal.type == 'purchase',
            //         tax=False,
            //         hard=True,
            //     )
            //     if violated_lock_dates:
            //         message = _("You cannot add/modify entries prior to and inclusive of: %(lock_date_info)s.",
            //                     lock_date_info=self.env['res.company']._format_lock_dates(violated_lock_dates))
            //         raise UserError(message)
            // return True
            */
            return default;
        }

        public async Task<TEntity> CheckInterviewerAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _check_interviewer_access(self):
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     raise UserError(_('You are not allowed to perform this action.'))
            */
            return default;
        }

        public async Task<TEntity> CheckInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_invoice_currency_rate(self):
            // """Ensure the currency rate is strictly positive when invoice currency differs from company currency."""
            // for move in self:
            //     if (
            //         move.currency_id
            //         and move.company_id
            //         and move.currency_id != move.company_id.currency_id
            //         and move.is_invoice(include_receipts=True)
            //         and move.invoice_currency_rate <= 0
            //     ):
            //         raise ValidationError(_("The currency rate must be strictly positive."))
            */
            return default;
        }

        public async Task<TEntity> CheckJournalMoveTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_journal_move_type(self):
            // for move in self:
            //     if move.is_purchase_document(include_receipts=True) and move.journal_id.type != 'purchase':
            //         raise ValidationError(_("Cannot create a purchase document in a non purchase journal"))
            //     if move.is_sale_document(include_receipts=True) and move.journal_id.type != 'sale':
            //         raise ValidationError(_("Cannot create a sale document in a non sale journal"))
            */
            return default;
        }

        public async Task<TEntity> CheckMoveIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _check_move_id(self):
            // for payment in self:
            //     if (
            //         payment.state not in ('draft', 'canceled')
            //         and not payment.move_id
            //         and payment.outstanding_account_id
            //     ):
            //         raise ValidationError(_("A payment with an outstanding account cannot be confirmed without having a journal entry."))
            */
            return default;
        }

        public async Task<TEntity> CheckMoveSequenceChainAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_move_sequence_chain(self):
            // return self.filtered(lambda move: move.name != '/')._is_end_of_seq_chain()
            */
            return default;
        }

        public async Task<TEntity> CheckNoExistingContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def check_no_existing_contract(self, date):
            // if isinstance(date, str):
            //     date = fields.Date.from_string(date)
            // if self._is_in_contract(date):
            //     raise ValidationError(self.env._("The employee is already in contract on %s. "
            //                                      "Please select a date outside existing contracts",
            //                                      format_date_abbr(self.env, date)))
            */
            return default;
        }

        public async Task<TEntity> CheckNonZeroInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> CheckO2oPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> CheckPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _check_payment_method_line_id(self):
            // ''' Ensure the 'payment_method_line_id' field is not null.
            // Can't be done using the regular 'required=True' because the field is a computed editable stored one.
            // '''
            // for pay in self:
            //     if not pay.payment_method_line_id:
            //         raise ValidationError(_("Please define a payment method line on your payment."))
            //     elif pay.payment_method_line_id.journal_id and pay.payment_method_line_id.journal_id != pay.journal_id:
            //         raise ValidationError(_("The selected payment method is not available for this payment, please select the payment method again."))
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_private_fields(self, field_names):
            // """ Check whether ``field_names`` contain private fields. """
            // public_fields = self.env['hr.employee.public']._fields
            // private_fields = [fname for fname in field_names if fname not in public_fields]
            // if private_fields:
            //     raise AccessError(_('The fields “%s”, which you are trying to read, are not available for employee public profiles.', ','.join(private_fields)))
            */
            return default;
        }

        public async Task<TEntity> CheckSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_salary_distribution(self):
            // for employee in self:
            //     dist = employee.salary_distribution
            //     if not dist:
            //         continue
            // 
            //     total = 0
            //     check_total = False
            //     for ba_values in dist.values():
            //         amount = ba_values.get('amount')
            //         is_percentage = ba_values.get('amount_is_percentage', True)
            //         if is_percentage and (not isinstance(amount, (float, int)) or not (0 <= amount <= 100)):
            //             raise ValidationError(self.env._("Each amount percentage must be a number between 0 and 100."))
            //         if is_percentage:
            //             check_total = True
            //             total += amount
            // 
            //     if check_total and not float_is_zero(total - 100.0, precision_digits=4):
            //         raise ValidationError(self.env._("Total salary distribution on bank accounts must be exactly 100%."))
            */
            return default;
        }

        public async Task<TEntity> CheckSelectedMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_selected_moves(self):
            // self.env['account.move'].browse(self.env.context.get('active_ids', [])).set_moves_checked()
            */
            return default;
        }

        public async Task<TEntity> CheckTalentPoolRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _check_talent_pool_required(self):
            // for talent in self:
            //     if talent.pool_applicant_id == talent and not talent.talent_pool_ids:
            //         raise ValidationError(self.env._("Talent must belong to at least one Talent Pool."))
            */
            return default;
        }

        public async Task<TEntity> CheckTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_total) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_total_amount(self, amount_total):
            // """
            // Verifies that the total amount corresponds to the quick total amount chosen as some
            // rounding errors may appear. In such a case, we round up the tax such that the total
            // is equal to the quick total amount set
            // E.g.: 100€ including 21% tax: base = 82.64, tax = 17.35, total = 99.99
            // The tax will be set to 17.36 in order to have a total of 100.00
            // """
            // if not self.tax_totals or not amount_total:
            //     return
            // totals = self.tax_totals
            // tax_amount_rounding_error = amount_total - totals['total_amount_currency']
            // if not float_is_zero(tax_amount_rounding_error, precision_rounding=self.currency_id.rounding):
            //     for subtotal in totals['subtotals']:
            //         if _('Untaxed Amount') == subtotal['name']:
            //             if subtotal['tax_groups']:
            //                 subtotal['tax_groups'][0]['tax_amount_currency'] += tax_amount_rounding_error
            //             totals['total_amount_currency'] = amount_total
            //             self.tax_totals = totals
            //             break
            */
            return default;
        }

        public async Task<TEntity> CheckValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_validity(self):
            // sorted_leaves = defaultdict(lambda: self.env['hr.leave'])
            // for leave in self:
            //     sorted_leaves[(leave.holiday_status_id, leave.date_from.date())] |= leave
            // for (leave_type, date_from), leaves in sorted_leaves.items():
            //     if not leave_type.requires_allocation:
            //         continue
            //     employees = leaves.employee_id
            //     leave_data = leave_type.get_allocation_data(employees, date_from)
            //     if leave_type.allows_negative:
            //         max_excess = leave_type.max_allowed_negative
            //         for employee in employees:
            //             if not leave_data[employee]:
            //                 raise ValidationError(_("You do not have any allocation for this time off type.\n"
            //                                         "Please request an allocation before submitting your time off request."))
            //             if leave_data[employee] and leave_data[employee][0][1]['virtual_remaining_leaves'] < -max_excess:
            //                 raise ValidationError(_("There is no valid allocation to cover that request."))
            //         continue
            // 
            //     previous_leave_data = leave_type.with_context(
            //         ignored_leave_ids=leaves.ids
            //     ).get_allocation_data(employees, date_from)
            //     for employee in employees:
            //         previous_emp_data = previous_leave_data[employee] and previous_leave_data[employee][0][1]['virtual_excess_data']
            //         emp_data = leave_data[employee] and leave_data[employee][0][1]['virtual_excess_data']
            //         if not leave_data[employee]:
            //             raise ValidationError(_("You do not have any allocation for this time off type.\n"
            //                                     "Please request an allocation before submitting your time off request."))
            //         if not previous_emp_data and not emp_data:
            //             continue
            //         if previous_emp_data != emp_data and len(emp_data) >= len(previous_emp_data):
            //             raise ValidationError(_("There is no valid allocation to cover that request."))
            // is_leave_user = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // if not is_leave_user and any(leave.has_mandatory_day for leave in self):
            //     raise ValidationError(_('You are not allowed to request time off on a Mandatory Day'))
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CleanupWriteOrmValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _cleanup_write_orm_values(self, record, vals):
            // cleaned_vals = dict(vals)
            // for field_name in vals.keys():
            //     if not self._field_will_change(record, vals, field_name):
            //         del cleaned_vals[field_name]
            // return cleaned_vals
            */
            return default;
        }

        public async Task<TEntity> CollectTaxCashBasisValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _collect_tax_cash_basis_values(self):
            // ''' Collect all information needed to create the tax cash basis journal entries:
            // - Determine if a tax cash basis journal entry is needed.
            // - Compute the lines to be processed and the amounts needed to compute a percentage.
            // :return: A dictionary:
            //     * move:                     The current account.move record passed as parameter.
            //     * to_process_lines:         A tuple (caba_treatment, line) where:
            //                                     - caba_treatment is either 'tax' or 'base', depending on what should
            //                                       be considered on the line when generating the caba entry.
            //                                       For example, a line with tax_ids=caba and tax_line_id=non_caba
            //                                       will have a 'base' caba treatment, as we only want to treat its base
            //                                       part in the caba entry (the tax part is already exigible on the invoice)
            // 
            //                                     - line is an account.move.line record being not exigible on the tax report.
            //     * currency:                 The currency on which the percentage has been computed.
            //     * total_balance:            sum(payment_term_lines.mapped('balance').
            //     * total_residual:           sum(payment_term_lines.mapped('amount_residual').
            //     * total_amount_currency:    sum(payment_term_lines.mapped('amount_currency').
            //     * total_residual_currency:  sum(payment_term_lines.mapped('amount_residual_currency').
            //     * is_fully_paid:            A flag indicating the current move is now fully paid.
            // '''
            // self.ensure_one()
            // 
            // values = {
            //     'move': self,
            //     'to_process_lines': [],
            //     'total_balance': 0.0,
            //     'total_residual': 0.0,
            //     'total_amount_currency': 0.0,
            //     'total_residual_currency': 0.0,
            // }
            // 
            // currencies = set()
            // has_term_lines = False
            // for line in self.line_ids:
            //     if line.account_type in ('asset_receivable', 'liability_payable'):
            //         sign = 1 if line.balance > 0.0 else -1
            // 
            //         currencies.add(line.currency_id)
            //         has_term_lines = True
            //         values['total_balance'] += sign * line.balance
            //         values['total_residual'] += sign * line.amount_residual
            //         values['total_amount_currency'] += sign * line.amount_currency
            //         values['total_residual_currency'] += sign * line.amount_residual_currency
            // 
            //     elif line.tax_line_id.tax_exigibility == 'on_payment':
            //         values['to_process_lines'].append(('tax', line))
            //         currencies.add(line.currency_id)
            // 
            //     elif 'on_payment' in line.tax_ids.flatten_taxes_hierarchy().mapped('tax_exigibility'):
            //         values['to_process_lines'].append(('base', line))
            //         currencies.add(line.currency_id)
            // 
            // if not values['to_process_lines'] or not has_term_lines:
            //     return None
            // 
            // # Compute the currency on which made the percentage.
            // if len(currencies) == 1:
            //     values['currency'] = list(currencies)[0]
            // else:
            //     # Don't support the case where there is multiple involved currencies.
            //     return None
            // 
            // # Determine whether the move is now fully paid.
            // values['is_fully_paid'] = self.company_id.currency_id.is_zero(values['total_residual']) \
            //                           or values['currency'].is_zero(values['total_residual_currency'])
            // 
            // return values
            */
            return default;
        }

        public async Task<TEntity> ComputeAbnormalWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_abnormal_warnings(self):
            // """Assign warning fields based on historical data.
            // 
            // The last invoices (between 10 and 30) are used to compute the normal distribution.
            // If the amount or days between invoices of the current invoice falls outside of the boundaries
            // of the Bell curve, we warn the user.
            // """
            // if self.env.context.get('disable_abnormal_invoice_detection'):
            //     draft_invoices = self.browse()
            // else:
            //     draft_invoices = self.filtered(lambda m:
            //         m.is_purchase_document()
            //         and m.state == 'draft'
            //         and m.amount_total
            //         and not (m.partner_id.ignore_abnormal_invoice_date and m.partner_id.ignore_abnormal_invoice_amount)
            //     )
            // other_moves = self - draft_invoices
            // other_moves.abnormal_amount_warning = False
            // other_moves.abnormal_date_warning = False
            // if not draft_invoices:
            //     return
            // draft_invoices.flush_recordset(['invoice_date', 'date', 'amount_total', 'partner_id', 'move_type', 'company_id'])
            // today = fields.Date.context_today(self)
            // self.env.cr.execute("""
            //     WITH previous_invoices AS (
            //           SELECT this.id,
            //                  other.invoice_date,
            //                  other.amount_total,
            //                  LAG(other.invoice_date) OVER invoice - other.invoice_date AS date_diff
            //             FROM account_move this
            //             JOIN account_move other USING (partner_id, move_type, company_id, currency_id)
            //            WHERE other.state = 'posted'
            //              AND other.invoice_date <= COALESCE(this.invoice_date, this.date, %(today)s)
            //              AND this.id = ANY(%(move_ids)s)
            //              AND this.id != other.id
            //           WINDOW invoice AS (PARTITION BY this.id ORDER BY other.invoice_date DESC)
            //     ), stats AS (
            //           SELECT id,
            //                  MAX(invoice_date)          OVER invoice AS last_invoice_date,
            //                  AVG(date_diff)             OVER invoice AS date_diff_mean,
            //                  STDDEV_SAMP(date_diff)     OVER invoice AS date_diff_deviation,
            //                  AVG(amount_total)          OVER invoice AS amount_mean,
            //                  STDDEV_SAMP(amount_total)  OVER invoice AS amount_deviation,
            //                  ROW_NUMBER()               OVER invoice AS row_number
            //             FROM previous_invoices
            //           WINDOW invoice AS (PARTITION BY id ORDER BY invoice_date DESC)
            //     )
            //       SELECT id, last_invoice_date, date_diff_mean, date_diff_deviation, amount_mean, amount_deviation
            //         FROM stats
            //        WHERE row_number BETWEEN 10 AND 30
            //     ORDER BY row_number ASC
            // """, {
            //     'today': today,
            //     'move_ids': draft_invoices.ids,
            // })
            // result = {invoice: vals for invoice, *vals in self.env.cr.fetchall()}
            // for move in draft_invoices:
            //     invoice_date = move.invoice_date or today
            //     (
            //         last_invoice_date, date_diff_mean, date_diff_deviation,
            //         amount_mean, amount_deviation,
            //     ) = result.get(move._origin.id, (invoice_date, 0, 10000000000, 0, 10000000000))
            // 
            //     if date_diff_mean > 25:
            //         # Correct for varying days per month and leap years
            //         # If we have a recurring invoice every month, the mean will be ~30.5 days, and the deviation ~1 day.
            //         # We need to add some wiggle room for the month of February otherwise it will trigger because 28 days is outside of the range
            //         date_diff_deviation += 1
            // 
            //     wiggle_room_date = 2 * date_diff_deviation
            //     move.abnormal_date_warning = (
            //         not move.partner_id.ignore_abnormal_invoice_date
            //         and (invoice_date - last_invoice_date).days < int(date_diff_mean - wiggle_room_date)
            //     ) and _(
            //         "The billing frequency for %(partner_name)s appears unusual. Based on your historical data, "
            //         "the expected next invoice date is not before %(expected_date)s (every %(mean)s (± %(wiggle)s) days).\n"
            //         "Please verify if this date is accurate.",
            //         partner_name=move.partner_id.display_name,
            //         expected_date=format_date(self.env, fields.Date.add(last_invoice_date, days=int(date_diff_mean - wiggle_room_date))),
            //         mean=int(date_diff_mean),
            //         wiggle=int(wiggle_room_date),
            //     )
            // 
            //     wiggle_room_amount = 2 * amount_deviation
            //     move.abnormal_amount_warning = (
            //         not move.partner_id.ignore_abnormal_invoice_amount
            //         and not (amount_mean - wiggle_room_amount <= move.amount_total <= amount_mean + wiggle_room_amount)
            //     ) and _(
            //         "The amount for %(partner_name)s appears unusual. Based on your historical data, the expected amount is %(mean)s (± %(wiggle)s).\n"
            //         "Please verify if this amount is accurate.",
            //         partner_name=move.partner_id.display_name,
            //         mean=move.currency_id.format(amount_mean),
            //         wiggle=move.currency_id.format(wiggle_room_amount),
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for move in self.filtered(lambda move: move.is_invoice()):
            //     move.access_url = '/my/invoices/%s' % (move.id)
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
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

        public async Task<TEntity> ComputeAdjustingEntriesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_adjusting_entries_count(self):
            // for move in self:
            //     move.adjusting_entries_count = len(move.adjusting_entries_move_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntryOriginLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_adjusting_entry_origin_label(self):
            // for move in self:
            //     if len(move.adjusting_entry_origin_move_ids) == 1:
            //         move.adjusting_entry_origin_label = dict(self._fields['move_type'].selection)[move.adjusting_entry_origin_move_ids.move_type]
            //     else:
            //         move.adjusting_entry_origin_label = False
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntryOriginMovesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_adjusting_entry_origin_moves_count(self):
            // for move in self:
            //     move.adjusting_entry_origin_moves_count = len(move.adjusting_entry_origin_move_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_alerts(self):
            // for move in self:
            //     move.alerts = move._get_alerts()
            */
            return default;
        }

        public async Task<TEntity> ComputeAlwaysTaxExigibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_always_tax_exigible(self):
            // for record in self.with_context(prefetch_fields=False):
            //     # We need to check is_invoice as well because always_tax_exigible is used to
            //     # set the tags as well, during the encoding. So, if no receivable/payable
            //     # line has been created yet, the invoice would be detected as always exigible,
            //     # and set the tags on some lines ; which would be wrong.
            //     record.always_tax_exigible = not record.is_invoice(True) \
            //                                  and not record._collect_tax_cash_basis_values()
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountCompanyCurrencySignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_amount_company_currency_signed(self):
            // for payment in self:
            //     if payment.move_id:
            //         liquidity_lines = payment._seek_for_lines()[0]
            //         payment.amount_company_currency_signed = sum(liquidity_lines.mapped('balance'))
            //     else:
            //         payment.amount_company_currency_signed = payment.currency_id._convert(
            //             from_amount=payment.amount_signed,
            //             to_currency=payment.company_currency_id,
            //             company=payment.company_id,
            //             date=payment.date,
            //         )
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_amount(self):
            // self.line_ids.fetch([
            //     'debit',
            //     'balance',
            //     'amount_currency',
            //     'amount_residual',
            //     'amount_residual_currency',
            //     'display_type',
            //     'tax_repartition_line_id'
            // ])
            // for move in self:
            //     total_untaxed, total_untaxed_currency = 0.0, 0.0
            //     total_tax, total_tax_currency = 0.0, 0.0
            //     total_residual, total_residual_currency = 0.0, 0.0
            //     total, total_currency = 0.0, 0.0
            // 
            //     for line in move.line_ids:
            //         if move.is_invoice(True):
            //             # === Invoices ===
            //             if line.display_type in ('tax', 'non_deductible_tax') or (line.display_type == 'rounding' and line.tax_repartition_line_id):
            //                 # Tax amount.
            //                 total_tax += line.balance
            //                 total_tax_currency += line.amount_currency
            //                 total += line.balance
            //                 total_currency += line.amount_currency
            //             elif line.display_type in ('product', 'rounding', 'non_deductible_product', 'non_deductible_product_total'):
            //                 # Untaxed amount.
            //                 total_untaxed += line.balance
            //                 total_untaxed_currency += line.amount_currency
            //                 total += line.balance
            //                 total_currency += line.amount_currency
            //             elif line.display_type == 'payment_term':
            //                 # Residual amount.
            //                 total_residual += line.amount_residual
            //                 total_residual_currency += line.amount_residual_currency
            //         else:
            //             # === Miscellaneous journal entry ===
            //             if line.debit:
            //                 total += line.balance
            //                 total_currency += line.amount_currency
            // 
            //     sign = move.direction_sign
            //     move.amount_untaxed = sign * total_untaxed_currency
            //     move.amount_tax = sign * total_tax_currency
            //     move.amount_total = sign * total_currency
            //     move.amount_residual = -sign * total_residual_currency
            //     move.amount_untaxed_signed = -total_untaxed
            //     move.amount_untaxed_in_currency_signed = -total_untaxed_currency
            //     move.amount_tax_signed = -total_tax
            //     move.amount_total_signed = abs(total) if move.move_type == 'entry' else -total
            //     move.amount_residual_signed = total_residual
            //     move.amount_total_in_currency_signed = abs(move.amount_total) if move.move_type == 'entry' else -(sign * move.amount_total)
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountSignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_amount_signed(self):
            // for payment in self:
            //     if payment.payment_type == 'outbound':
            //         payment.amount_signed = -payment.amount
            //     else:
            //         payment.amount_signed = payment.amount
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalWordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_amount_total_words(self):
            // for move in self:
            //     move.amount_total_words = move.currency_id.amount_to_text(move.amount_total).replace(',', '')
            */
            return default;
        }

        public async Task<TEntity> ComputeAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_application_count(self):
            // """
            // This method will calculate the number of applications that are either
            // directly or indirectly linked to the current application(s)
            // - An application is considered directly linked if it shares the same
            //   pool_applicant_id
            // - An application is considered indirectly_linked if it has the same
            //   value as the current application(s) in any of the following field:
            //   email, phone number or linkedin
            // 
            // Note: If self has pool_applicant_id, email, phone number or linkedin set
            // this method will include self in the returned count
            // """
            // all_emails = {a.email_normalized for a in self if a.email_normalized}
            // all_phones = {a.partner_phone_sanitized for a in self if a.partner_phone_sanitized}
            // all_linkedins = {a.linkedin_profile for a in self if a.linkedin_profile}
            // all_pool_applicants = {a.pool_applicant_id.id for a in self if a.pool_applicant_id}
            // 
            // domain = Domain.FALSE
            // if all_emails:
            //     domain |= Domain("email_normalized", "in", list(all_emails))
            // if all_phones:
            //     domain |= Domain("partner_phone_sanitized", "in", list(all_phones))
            // if all_linkedins:
            //     domain |= Domain("linkedin_profile", "in", list(all_linkedins))
            // if all_pool_applicants:
            //     domain |= Domain("pool_applicant_id", "in", list(all_pool_applicants))
            // 
            // domain &= Domain("talent_pool_ids", "=", False)
            // matching_applicants = self.env["hr.applicant"].with_context(active_test=False).search(domain)
            // 
            // email_map = defaultdict(set)
            // phone_map = defaultdict(set)
            // linkedin_map = defaultdict(set)
            // pool_applicant_map = defaultdict(set)
            // for app in matching_applicants:
            //     if app.email_normalized:
            //         email_map[app.email_normalized].add(app.id)
            //     if app.partner_phone_sanitized:
            //         phone_map[app.partner_phone_sanitized].add(app.id)
            //     if app.linkedin_profile:
            //         linkedin_map[app.linkedin_profile].add(app.id)
            //     if app.pool_applicant_id:
            //         pool_applicant_map[app.pool_applicant_id].add(app.id)
            // 
            // for applicant in self:
            //     related_ids = set()
            //     if applicant.email_normalized:
            //         related_ids.update(email_map.get(applicant.email_normalized, set()))
            //     if applicant.partner_phone_sanitized:
            //         related_ids.update(phone_map.get(applicant.partner_phone_sanitized, set()))
            //     if applicant.linkedin_profile:
            //         related_ids.update(linkedin_map.get(applicant.linkedin_profile, set()))
            //     if applicant.pool_applicant_id:
            //         related_ids.update(pool_applicant_map.get(applicant.pool_applicant_id, set()))
            // 
            //     count = len(related_ids)
            // 
            //     applicant.application_count = max(0, count)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_application_status(self):
            // for applicant in self:
            //     if applicant.refuse_reason_id:
            //         applicant.application_status = 'refused'
            //     elif not applicant.active:
            //         applicant.application_status = 'archived'
            //     elif applicant.date_closed:
            //         applicant.application_status = 'hired'
            //     else:
            //         applicant.application_status = 'ongoing'
            */
            return default;
        }

        public async Task<TEntity> ComputeAutoPostUntilInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_auto_post_until(self):
            // for record in self:
            //     if record.auto_post in ('no', 'at_date'):
            //         record.auto_post_until = False
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_available_journal_ids(self):
            // """
            // Get all journals having at least one payment method for inbound/outbound depending on the payment_type.
            // """
            // journals = self.env['account.journal'].search([
            //     '|',
            //     ('company_id', 'parent_of', self.env.company.id),
            //     ('company_id', 'child_of', self.env.company.id),
            //     ('type', 'in', ('bank', 'cash', 'credit')),
            // ])
            // for pay in self:
            //     if pay.payment_type == 'inbound':
            //         pay.available_journal_ids = journals.filtered('inbound_payment_method_line_ids')
            //     else:
            //         pay.available_journal_ids = journals.filtered('outbound_payment_method_line_ids')
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePartnerBankIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_available_partner_bank_ids(self):
            // for pay in self:
            //     if pay.payment_type == 'inbound':
            //         pay.available_partner_bank_ids = pay.journal_id.bank_account_id
            //     else:
            //         pay.available_partner_bank_ids = pay.partner_id.bank_ids\
            //                 .filtered(lambda x: x.company_id.id in (False, pay.company_id.id))._origin
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // employee_wo_user_and_image = self.env['hr.employee']
            // for employee in self:
            //     if not employee.user_id and not employee._origin[image_field]:
            //         employee_wo_user_and_image += employee
            //         continue
            //     avatar = employee._origin[image_field]
            //     if not avatar and employee.user_id:
            //         avatar = employee.user_id.sudo()[avatar_field]
            //     employee[avatar_field] = avatar
            // super(HrEmployee, employee_wo_user_and_image)._compute_avatar(avatar_field, image_field)
            */
            return default;
        }

        public async Task<TEntity> ComputeBankPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_bank_partner_id(self):
            // for move in self:
            //     if move.is_inbound():
            //         move.bank_partner_id = move.company_id.partner_id
            //     else:
            //         move.bank_partner_id = move.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeBirthdayPublicDisplayStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_birthday_public_display_string(self):
            // for employee in self:
            //     if employee.birthday and employee.birthday_public_display:
            //         employee.birthday_public_display_string = datetime.strftime(employee.birthday, "%d %B")
            //     else:
            //         employee.birthday_public_display_string = "hidden"
            */
            return default;
        }

        public async Task<TEntity> ComputeCanApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_can_approve(self):
            // cannot_reason_per_record_id = self._get_cannot_approve_reason()
            // for expense in self:
            //     expense.can_approve = not cannot_reason_per_record_id[expense.id]
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_approve(self):
            // for holiday in self:
            //     holiday.can_approve = holiday._check_approval_update('validate1', raise_if_not_possible=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBackToApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_back_to_approve(self):
            // for holiday in self:
            //     holiday.can_back_to_approve = holiday.state == 'validate' and holiday._check_approval_update('confirm', raise_if_not_possible=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_cancel(self):
            // for holiday in self:
            //     holiday.can_cancel = holiday._check_approval_update('cancel', raise_if_not_possible=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_refuse(self):
            // for holiday in self:
            //     holiday.can_refuse = holiday._check_approval_update('refuse', raise_if_not_possible=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanResetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeCanValidateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_validate(self):
            // for holiday in self:
            //     holiday.can_validate = holiday._check_approval_update('validate', raise_if_not_possible=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeCheckedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_checked(self):
            // for move in self:
            //     move.checked = move.state == 'posted' and (move.journal_id.type == 'general' or move._is_user_able_to_review())
            */
            return default;
        }

        public async Task<TEntity> ComputeCoachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_coach(self):
            // for version in self:
            //     manager = version.parent_id
            //     previous_manager = version._origin.parent_id
            //     if manager and (version.coach_id == previous_manager or not version.coach_id):
            //         version.coach_id = manager
            //     elif not version.coach_id:
            //         version.coach_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_commercial_partner_id(self):
            // for move in self:
            //     move.commercial_partner_id = move.partner_id.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_company_id(self):
            // for move in self:
            //     if move.journal_id.company_id not in move.company_id.parent_ids:
            //         move.company_id = (move.journal_id.company_id or self.env.company)._accessible_branches()[:1]
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_company_id(self):
            // for payment in self:
            //     if payment.journal_id.company_id not in payment.company_id.parent_ids:
            //         payment.company_id = (payment.journal_id.company_id or self.env.company)._accessible_branches()[:1]
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_company_id(self):
            // for holiday in self:
            //     holiday.company_id = holiday.employee_company_id or holiday.department_id.company_id or self.env.company
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_company(self):
            // for applicant in self:
            //     company_id = False
            //     if applicant.department_id:
            //         company_id = applicant.department_id.company_id.id
            //     if not company_id and applicant.job_id:
            //         company_id = applicant.job_id.company_id.id
            //     applicant.company_id = company_id or self.env.company.id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_currency_id(self):
            // for invoice in self:
            //     currency = (
            //         invoice.statement_line_id.foreign_currency_id
            //         or invoice.journal_id.currency_id
            //         or invoice.currency_id
            //         or invoice.journal_id.company_id.currency_id
            //     )
            //     invoice.currency_id = currency
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_currency_id(self):
            // for pay in self:
            //     pay.currency_id = pay.journal_id.currency_id or pay.journal_id.company_id.currency_id
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_currency_id(self):
            // for expense in self:
            //     if expense.product_has_cost and expense.state == 'draft':
            //         expense.currency_id = expense.company_currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
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

        public async Task<TEntity> ComputeCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_current_version_id(self):
            // for employee in self:
            //     version = self.env['hr.version'].search(
            //         [('employee_id', 'in', employee.ids), ('date_version', '<=', fields.Date.today())],
            //         order='date_version desc',
            //         limit=1,
            //     )
            //     new_current_version = False
            //     if version:
            //         new_current_version = version
            //     elif employee.version_ids:
            //         new_current_version = employee.version_ids[0]
            //     # To not trigger computed properties if still the same version
            //     if employee.current_version_id != new_current_version:
            //         employee.current_version_id = new_current_version
            */
            return default;
        }

        public async Task<TEntity> ComputeDashboardWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_dashboard_warning_message(self):
            // all_leaves = self.search([
            //     ('date_from', '<', max(self.mapped('date_to'))),
            //     ('date_to', '>', min(self.mapped('date_from'))),
            //     ('employee_id', 'in', self.employee_id.ids),
            //     ('holiday_status_id.allow_request_on_top', '=', False),
            //     ('state', 'not in', ['cancel', 'refuse']),
            // ])
            // self.filtered(lambda self: self.state in ['cancel', 'refuse']).dashboard_warning_message = False
            // for holiday in self.filtered(lambda self: self.state not in ['cancel', 'refuse']):
            //     conflicting_holidays = all_leaves.filtered_domain([
            //         ('employee_id', 'in', holiday.employee_id.ids),
            //         ('date_from', '<', holiday.date_to),
            //         ('date_to', '>', holiday.date_from),
            //         ('id', 'not in', holiday.ids),
            //     ])
            //     if not conflicting_holidays:
            //         holiday.dashboard_warning_message = False
            //         continue
            // 
            //     conflicting_holidays_list = []
            //     # Do not display the name of the employee if the conflicting holidays have an employee_id.user_id equivalent to the user id
            //     holidays_only_have_uid = bool(holiday.employee_id)
            //     holiday_states = dict(conflicting_holidays.fields_get(allfields=['state'])['state']['selection'])
            //     for conflicting_holiday in conflicting_holidays:
            //         conflicting_holiday_data = {
            //             'employee_name': conflicting_holiday.employee_id.name,
            //             'date_from': format_date(self.env, min(conflicting_holiday.mapped('date_from'))),
            //             'date_to': format_date(self.env, min(conflicting_holiday.mapped('date_to'))),
            //             'state': holiday_states[conflicting_holiday.state]
            //         }
            //         if conflicting_holiday.employee_id.user_id.id != self.env.uid:
            //             holidays_only_have_uid = False
            //         if conflicting_holiday_data not in conflicting_holidays_list:
            //             conflicting_holidays_list.append(conflicting_holiday_data)
            // 
            //     msg = ""
            //     if holidays_only_have_uid:
            //         msg = self.env._('You\'ve already booked time off which overlaps with this period:')
            //     else:
            //         msg = self.env._('An employee already booked time off which overlaps with this period:')
            // 
            //     holiday.dashboard_warning_message = msg + "".join(
            //         ('\n\t' + self.env._('%(employee_name)s from %(date_from)s to %(date_to)s - %(state)s')) % {
            //             'employee_name': conflicting_holiday_data['employee_name'] if not holidays_only_have_uid else "",
            //             'date_from': conflicting_holiday_data['date_from'],
            //             'date_to': conflicting_holiday_data['date_to'],
            //             'state': conflicting_holiday_data['state']
            //         } for conflicting_holiday_data in conflicting_holidays_list
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeDateClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_date_closed(self):
            // for applicant in self:
            //     if applicant.stage_id and applicant.stage_id.hired_stage and not applicant.date_closed:
            //         applicant.date_closed = fields.Datetime.now()
            //     if not applicant.stage_id.hired_stage:
            //         applicant.date_closed = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDateFromToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_date_from_to(self):
            // for holiday in self:
            //     if not holiday.request_date_from:
            //         holiday.date_from = False
            //         continue
            // 
            //     if not holiday.request_date_to:
            //         holiday.date_to = False
            //         continue
            // 
            //     if holiday.request_unit_hours:
            //         hour_from = holiday.request_hour_from
            //         hour_to = holiday.request_hour_to
            //         if not hour_from or not hour_to:
            //             computed_from, computed_to = holiday._get_hour_from_to(holiday.request_date_from, holiday.request_date_to)
            //             hour_from = hour_from or computed_from
            //             hour_to = hour_to or computed_to
            // 
            //     elif holiday.request_unit_half:
            //         period_map = {'am': 'morning', 'pm': 'afternoon'}
            //         from_period = period_map.get(holiday.request_date_from_period)
            //         to_period = period_map.get(holiday.request_date_to_period)
            //         if holiday.request_date_from == holiday.request_date_to:
            //             day_period = from_period if from_period == to_period else None
            //             hour_from, hour_to = holiday._get_hour_from_to(holiday.request_date_from, holiday.request_date_to,
            //                 day_period)
            //         else:
            //             hour_from, _ = holiday._get_hour_from_to(holiday.request_date_from, holiday.request_date_from, from_period)
            //             _, hour_to = holiday._get_hour_from_to(holiday.request_date_to, holiday.request_date_to, to_period)
            // 
            //     else:
            //         hour_from, hour_to = holiday._get_hour_from_to(holiday.request_date_from, holiday.request_date_to)
            // 
            //     holiday.date_from = self._to_utc(holiday.request_date_from, hour_from, holiday.employee_id or holiday)
            //     holiday.date_to = self._to_utc(holiday.request_date_to, hour_to, holiday.employee_id or holiday)
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_date(self):
            // for move in self:
            //     accounting_date = move._get_accounting_date_source()
            //     if not accounting_date or not move.is_invoice(include_receipts=True):
            //         if not move.date:
            //             move.date = fields.Date.context_today(self)
            //         continue
            //     if not move.is_sale_document(include_receipts=True):
            //         accounting_date = move._get_accounting_date(accounting_date, move._affect_tax_report())
            //     if accounting_date and accounting_date != move.date:
            //         move.date = accounting_date
            //         # _affect_tax_report may trigger premature recompute of line_ids.date
            //         self.env.add_to_compute(move.line_ids._fields['date'], move.line_ids)
            //         # might be protected because `_get_accounting_date` requires the `name`
            //         self.env.add_to_compute(self._fields['name'], move)
            */
            return default;
        }

        public async Task<TEntity> ComputeDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_day(self):
            // for applicant in self:
            //     if applicant.date_open:
            //         date_create = applicant.create_date
            //         date_open = applicant.date_open
            //         applicant.day_open = (date_open - date_create).total_seconds() / (24.0 * 3600)
            //     else:
            //         applicant.day_open = False
            //     if applicant.date_closed:
            //         date_create = applicant.create_date
            //         date_closed = applicant.date_closed
            //         applicant.day_close = (date_closed - date_create).total_seconds() / (24.0 * 3600)
            //     else:
            //         applicant.day_close = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_delay(self):
            // for applicant in self:
            //     if applicant.date_open and applicant.day_close:
            //         applicant.delay_close = applicant.day_close - applicant.day_open
            //     else:
            //         applicant.delay_close = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_delivery_date(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeDepartmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_department_id(self):
            // for holiday in self:
            //     holiday.department_id = holiday.employee_id.department_id
            */
            return default;
        }

        public async Task<TEntity> ComputeDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_department(self):
            // for applicant in self:
            //     applicant.department_id = applicant.job_id.department_id.id
            */
            return default;
        }

        public async Task<TEntity> ComputeDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_description(self):
            // self.check_access('read')
            // 
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // 
            // for leave in self:
            //     if is_officer or leave.user_id == self.env.user or leave.employee_id.leave_manager_id == self.env.user:
            //         leave.name = leave.sudo().private_name
            //     else:
            //         leave.name = '*****'
            */
            return default;
        }

        public async Task<TEntity> ComputeDestinationAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_destination_account_id(self):
            // self.destination_account_id = False
            // for pay in self:
            //     if pay.partner_type == 'customer':
            //         # Receive money from invoice or send money to refund it.
            //         if pay.partner_id:
            //             pay.destination_account_id = pay.partner_id.with_company(pay.company_id).property_account_receivable_id
            //         else:
            //             pay.destination_account_id = self.env['account.account'].with_company(pay.company_id).search([
            //                 *self.env['account.account']._check_company_domain(pay.company_id),
            //                 ('account_type', '=', 'asset_receivable'),
            //             ], limit=1)
            //     elif pay.partner_type == 'supplier':
            //         # Send money to pay a bill or receive money to refund it.
            //         if pay.partner_id:
            //             pay.destination_account_id = pay.partner_id.with_company(pay.company_id).property_account_payable_id
            //         else:
            //             pay.destination_account_id = self.env['account.account'].with_company(pay.company_id).search([
            //                 *self.env['account.account']._check_company_domain(pay.company_id),
            //                 ('account_type', '=', 'liability_payable'),
            //             ], limit=1)
            */
            return default;
        }

        public async Task<TEntity> ComputeDirectionSignInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_direction_sign(self):
            // for invoice in self:
            //     if invoice.move_type == 'entry' or invoice.is_outbound():
            //         invoice.direction_sign = 1
            //     else:
            //         invoice.direction_sign = -1
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInactiveCurrencyWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_inactive_currency_warning(self):
            // for move in self.with_context(active_test=False):
            //     move.display_inactive_currency_warning = move.state == 'draft' and move.currency_id and not move.currency_id.active
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayLinkQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_link_qr_code(self):
            // for move in self:
            //     move.display_link_qr_code = (
            //         move.move_type in ('out_invoice', 'out_receipt', 'in_invoice', 'in_receipt')
            //         and move.company_id.link_qr_code
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_name(self):
            // for move in self:
            //     move.display_name = move._get_move_display_name(show_ref=True)
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_display_name(self):
            // for payment in self:
            //     payment.display_name = payment.name or _('Draft Payment')
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_display_name(self):
            // if self.browse().has_access('read'):
            //     return super()._compute_display_name()
            // for employee_private, employee_public in zip(self, self.env['hr.employee.public'].browse(self.ids)):
            //     employee_private.display_name = employee_public.display_name
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_display_name(self):
            // for leave in self:
            //     user_tz = pytz.timezone(leave.tz)
            //     date_from_utc = leave.date_from and leave.date_from.astimezone(user_tz).date()
            //     date_to_utc = leave.date_to and leave.date_to.astimezone(user_tz).date()
            //     time_off_type_display = leave.holiday_status_id.name
            //     if self.env.context.get('short_name'):
            //         short_leave_name = leave.name or time_off_type_display or _('Time Off')
            //         leave.display_name = _("%(name)s: %(duration)s", name=short_leave_name, duration=leave.duration_display)
            //     else:
            //         target = leave.employee_id.name or ""
            //         display_date = format_date(self.env, date_from_utc) or ""
            //         if leave.number_of_days > 1 and date_from_utc and date_to_utc:
            //             display_date += _(' to %(date_to_utc)s',
            //                 date_to_utc=format_date(self.env, date_to_utc) or ""
            //             )
            //         if not target or self.env.context.get('hide_employee_name') and 'employee_id' in self.env.context.get('group_by', []):
            //             leave.display_name = _("%(leave_type)s: %(duration)s (%(start)s)",
            //                 leave_type=time_off_type_display,
            //                 duration=leave.duration_display,
            //                 start=display_date,
            //             )
            //         elif not time_off_type_display:
            //             leave.display_name = _("%(person)s: %(duration)s (%(start)s)",
            //                 person=target,
            //                 duration=leave.duration_display,
            //                 start=display_date,
            //             )
            //         else:
            //             leave.display_name = _("%(person)s on %(leave_type)s: %(duration)s (%(start)s)",
            //                 person=target,
            //                 leave_type=time_off_type_display,
            //                 duration=leave.duration_display,
            //                 start=display_date,
            //             )
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_display_name(self):
            // if not self.env.context.get('show_partner_name'):
            //     return super()._compute_display_name()
            // for applicant in self:
            //     applicant.display_name = applicant.partner_name
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_qr_code(self):
            // for move in self:
            //     move.display_qr_code = (
            //         move.move_type in ('out_invoice', 'out_receipt', 'in_invoice', 'in_receipt')
            //         and move.company_id.qr_code
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplaySendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_send_button(self):
            // for move in self:
            //     move.display_send_button = move.is_sale_document() and move.state == 'posted'
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicateExpenseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeDuplicatePaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_duplicate_payment_ids(self):
            // """ Retrieve move ids with same partner_id, amount and date as the current payment """
            // payment_to_duplicate_move = self._fetch_duplicate_reference()
            // for payment in self:
            //     # Uses payment._origin.id to handle records in edition/existing records and 0 for new records
            //     payment.duplicate_payment_ids = payment_to_duplicate_move.get(payment._origin.id, self.env['account.payment'])
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedRefIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_duplicated_ref_ids(self):
            // move_to_duplicate_move = self._fetch_duplicate_reference()
            // for move in self:
            //     # Uses move._origin.id to handle records in edition/existing records and 0 for new records
            //     move.duplicated_ref_ids = move_to_duplicate_move.get(move._origin, self.env['account.move'])
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_duration_display(self):
            // for leave in self:
            //     duration = leave.number_of_days
            //     unit = _('days')
            //     display = "%g %s" % (float_round(duration, precision_digits=2), unit)
            //     if leave.leave_type_request_unit == "hour":
            //         hours, minutes = divmod(abs(leave.number_of_hours) * 60, 60)
            //         minutes = round(minutes)
            //         if minutes == 60:
            //             minutes = 0
            //             hours += 1
            //         duration = '%d:%02d' % (hours, minutes)
            //         unit = _("hours")
            //         display = f"{duration} {unit}"
            //     leave.duration_display = display
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_duration(self):
            // durations = self._get_durations()
            // for leave in self:
            //     days, hours = durations[leave.id]
            //     leave.number_of_hours = hours
            //     leave.number_of_days = days
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeExpectedCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_expected_currency_rate(self):
            // for move in self:
            //     if move.currency_id:
            //         move.expected_currency_rate = move.env['res.currency']._get_conversion_rate(
            //             from_currency=move.company_currency_id,
            //             to_currency=move.currency_id,
            //             company=move.company_id,
            //             date=move._get_invoice_currency_rate_date(),
            //         )
            //     else:
            //         move.expected_currency_rate = 1
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_fiscal_position_id(self):
            // for move in self:
            //     receipt_fiscal_position = {
            //         'in_receipt': move.company_id.account_purchase_receipt_fiscal_position_id,
            //     }.get(move.move_type)
            //     if receipt_fiscal_position:
            //         move.fiscal_position_id = receipt_fiscal_position
            //         continue
            //     delivery_partner = self.env['res.partner'].browse(
            //         move.partner_shipping_id.id
            //         or move.partner_id.address_get(['delivery'])['delivery']
            //     )
            //     move.fiscal_position_id = self.env['account.fiscal.position'].with_company(move.company_id)._get_fiscal_position(
            //         move.partner_id, delivery=delivery_partner)
            */
            return default;
        }

        public async Task<TEntity> ComputeFromEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_from_employee_id(self):
            // for expense in self:
            //     expense.department_id = expense.employee_id.department_id
            //     expense.manager_id = expense._get_default_responsible_for_approval()
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_from_employee_id(self):
            // for holiday in self:
            //     if not holiday.holiday_status_id.requires_allocation:
            //         continue
            //     if not holiday.employee_id:
            //         holiday.holiday_status_id = False
            //     elif holiday.employee_id.user_id != self.env.user and holiday._origin.employee_id != holiday.employee_id:
            //         if holiday.employee_id and not holiday.holiday_status_id.with_context(employee_id=holiday.employee_id.id).has_valid_allocation:
            //             holiday.holiday_status_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeFromProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeHasMandatoryDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_has_mandatory_day(self):
            // date_from, date_to = min(self.mapped('date_from')), max(self.mapped('date_to'))
            // if date_from and date_to:
            //     # Sudo to get access to version fields on employee (job_id)
            //     mandatory_days = self.employee_id.sudo()._get_mandatory_days(
            //         date_from.date(),
            //         date_to.date())
            // 
            //     for leave in self:
            //         department_ids = leave.employee_id.department_id.ids
            //         domain = [
            //             ('start_date', '<=', leave.date_to.date()),
            //             ('end_date', '>=', leave.date_from.date()),
            //             '|',
            //                 ('resource_calendar_id', '=', False),
            //                 ('resource_calendar_id', '=', leave.resource_calendar_id.id),
            //         ]
            //         if department_ids:
            //             domain += [
            //                 '|',
            //                 ('department_ids', '=', False),
            //                 ('department_ids', 'parent_of', department_ids),
            //             ]
            //         else:
            //             domain += [('department_ids', '=', False)]
            // 
            //         if leave.holiday_status_id.company_id:
            //             domain += [('company_id', '=', leave.holiday_status_id.company_id.id)]
            //         leave.has_mandatory_day = leave.date_from and leave.date_to and mandatory_days.filtered_domain(domain)
            // else:
            //     self.has_mandatory_day = False
            */
            return default;
        }

        public async Task<TEntity> ComputeHasMultipleBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_has_multiple_bank_accounts(self):
            // for employee in self:
            //     if employee.bank_account_ids and len(employee.bank_account_ids) > 1:
            //         employee.has_multiple_bank_accounts = True
            //     else:
            //         employee.has_multiple_bank_accounts = False
            */
            return default;
        }

        public async Task<TEntity> ComputeHasReconciledEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_has_reconciled_entries(self):
            // for move in self:
            //     move.has_reconciled_entries = len(move.line_ids._reconciled_lines()) > 1
            */
            return default;
        }

        public async Task<TEntity> ComputeHidePostButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_hide_post_button(self):
            // for record in self:
            //     record.hide_post_button = record.state != 'draft' \
            //         or record.auto_post != 'no' and \
            //         record.date and record.date > fields.Date.context_today(record)
            */
            return default;
        }

        public async Task<TEntity> ComputeHighestNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_highest_name(self):
            // for record in self:
            //     record.highest_name = record._get_last_sequence()
            */
            return default;
        }

        public async Task<TEntity> ComputeHighlightSendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_highlight_send_button(self):
            // for move in self:
            //     move.highlight_send_button = not move.is_being_sent and not move.invoice_pdf_report_id
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_incoterm(self):
            // for move in self:
            //     if move.move_type.startswith('out_'):
            //         move.invoice_incoterm_id = move.company_id.incoterm_id
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_incoterm_location(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_currency_rate(self):
            // for move in self:
            //     if move.is_invoice(include_receipts=True):
            //         move.invoice_currency_rate = move.expected_currency_rate
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceDateDueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_date_due(self):
            // today = fields.Date.context_today(self)
            // for move in self:
            //     move.invoice_date_due = move.needed_terms and max(
            //         (k['date_maturity'] for k in move.needed_terms.keys() if k),
            //         default=False,
            //     ) or move.invoice_date_due or today
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceDefaultSalePersonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_default_sale_person(self):
            // # We want to modify the sale person only when we don't have one and if the move type corresponds to this condition
            // # If the move doesn't correspond, we remove the sale person
            // for move in self:
            //     if move.is_sale_document(include_receipts=True):
            //         if move.partner_id:
            //             move.invoice_user_id = (
            //                 move.invoice_user_id
            //                 or move.partner_id.user_id
            //                 or move.partner_id.commercial_partner_id.user_id
            //                 or self.env.user
            //             )
            //     else:
            //         move.invoice_user_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_filter_type_domain(self):
            // for move in self:
            //     move.invoice_filter_type_domain = self._get_invoice_filter_type_domain(move.move_type)
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceHasOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_has_outstanding(self):
            // for move in self:
            //     move.invoice_has_outstanding = bool(move.invoice_outstanding_credits_debits_widget)
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceIncotermPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_incoterm_placeholder(self):
            // for move in self:
            //     move.invoice_incoterm_placeholder = move.company_id.incoterm_id.display_name if move.company_id.incoterm_id else _('Define a default in the settings')
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePartnerDisplayInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_partner_display_info(self):
            // for move in self:
            //     vendor_display_name = move.partner_id.display_name
            //     if not vendor_display_name:
            //         if move.invoice_source_email:
            //             vendor_display_name = _('@From: %(email)s', email=move.invoice_source_email)
            //         else:
            //             vendor_display_name = _('#Created by: %s', move.sudo().create_uid.name or self.env.user.name)
            //     move.invoice_partner_display_name = vendor_display_name
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_payment_term_id(self):
            // for move in self:
            //     move = move.with_company(move.company_id)
            //     if move.is_sale_document(include_receipts=True) and move.partner_id.property_payment_term_id:
            //         move.invoice_payment_term_id = move.partner_id.property_payment_term_id
            //     elif move.is_purchase_document(include_receipts=True) and move.partner_id.property_supplier_payment_term_id:
            //         move.invoice_payment_term_id = move.partner_id.property_supplier_payment_term_id
            //     else:
            //         move.invoice_payment_term_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_is_applicant_in_pool(self):
            // """
            // Computes if an application is linked to a talent pool or not.
            // An application can either be directly or indirectly linked to a talent pool.
            // Direct link:
            //     - 1. Application has talent_pool_ids set, meaning this application
            //         is a talent pool application, or talent for short.
            //     - 2. Application has pool_applicant_id set, meaning this application
            //     is a copy or directly linked to a talent (scenario 1)
            // 
            // Indirect link:
            //     - 3. Application shares a phone number, email, or linkedin with a
            //         direclty linked application.
            // 
            // Note: While possible, linking an application to a pool through linking
            // it to an indirect link is currently excluded from the implementation
            // for technical reasons.
            // """
            // direct = self.filtered(lambda a: a.talent_pool_ids or a.pool_applicant_id)
            // direct.is_applicant_in_pool = True
            // indirect = self - direct
            // 
            // if not indirect:
            //     return
            // 
            // all_emails = {a.email_normalized for a in indirect if a.email_normalized}
            // all_phones = {a.partner_phone_sanitized for a in indirect if a.partner_phone_sanitized}
            // all_linkedins = {a.linkedin_profile for a in indirect if a.linkedin_profile}
            // 
            // epl_domain = Domain.FALSE
            // if all_emails:
            //     epl_domain |= Domain("email_normalized", "in", list(all_emails))
            // if all_phones:
            //     epl_domain |= Domain("partner_phone_sanitized", "in", list(all_phones))
            // if all_linkedins:
            //     epl_domain |= Domain("linkedin_profile", "in", list(all_linkedins))
            // 
            // pool_domain = Domain(["|", ("talent_pool_ids", "!=", False), ("pool_applicant_id", "!=", False)])
            // domain = pool_domain & epl_domain
            // in_pool_applicants = self.env["hr.applicant"].with_context(active_test=True).search(domain)
            // in_pool_data = {"emails": set(), "phones": set(), "linkedins": set()}
            // 
            // for applicant in in_pool_applicants:
            //     if applicant.email_normalized:
            //         in_pool_data["emails"].add(applicant.email_normalized)
            //     if applicant.partner_phone_sanitized:
            //         in_pool_data["phones"].add(applicant.partner_phone_sanitized)
            //     if applicant.linkedin_profile:
            //         in_pool_data["linkedins"].add(applicant.linkedin_profile)
            // 
            // for applicant in indirect:
            //     applicant.is_applicant_in_pool = (
            //         applicant.email_normalized in in_pool_data["emails"]
            //         or applicant.partner_phone_sanitized in in_pool_data["phones"]
            //         or applicant.linkedin_profile in in_pool_data["linkedins"]
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBeingSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_being_sent(self):
            // for move in self:
            //     move.is_being_sent = bool(move.sending_data)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeIsHatchedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_is_hatched(self):
            // for holiday in self:
            //     holiday.is_striked = holiday.state == 'refuse'
            //     holiday.is_hatched = holiday.state not in ['refuse', 'validate']
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMultipleCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeIsPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_is_pool(self):
            // for applicant in self:
            //     applicant.is_pool_applicant = applicant.talent_pool_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSaleInstalledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_sale_installed(self):
            // self.is_sale_installed = 'sale_management' in self.env['ir.module.module']._installed()
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_storno(self):
            // for move in self:
            //     is_refund = move.move_type in ('out_refund', 'in_refund')
            //     move.is_storno = move.is_storno or (is_refund and move.company_id.account_storno)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTrustedBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_is_trusted_bank_account(self):
            // for employee in self:
            //     employee.is_trusted_bank_account = employee.primary_bank_account_id.allow_out_payment
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_journal_id(self):
            // for move in self.filtered(lambda r: r.journal_id.type not in r._get_valid_journal_types()):
            //     move.journal_id = move._search_default_journal()
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_journal_id(self):
            // for payment in self:
            //     # default customer payment method logic
            //     partner = payment.partner_id
            //     payment_type = payment.payment_type if payment.payment_type in ('inbound', 'outbound') else None
            //     if not bool(payment._origin) and (partner or payment_type):
            //         field_name = f'property_{payment_type}_payment_method_line_id'
            //         default_payment_method_line = payment.partner_id.with_company(payment.company_id)[field_name]
            //         journal = default_payment_method_line.journal_id
            //         if journal:
            //             payment.journal_id = journal
            //             continue
            // 
            //     company = payment.company_id or self.env.company
            //     if not payment.journal_id or company != payment.journal_id.company_id:
            //         payment.journal_id = self.env['account.journal'].search([
            //             *self.env['account.journal']._check_company_domain(company),
            //             ('type', 'in', ['bank', 'cash', 'credit']),
            //         ], limit=1)
            */
            return default;
        }

        public async Task<TEntity> ComputeLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_last_activity(self):
            // for employee in self:
            //     tz = employee.tz
            //     # sudo: res.users - can access presence of accessible user
            //     if last_presence := employee.user_id.sudo().presence_ids.last_presence:
            //         last_activity_datetime = last_presence.replace(tzinfo=UTC).astimezone(timezone(tz)).replace(tzinfo=None)
            //         employee.last_activity = last_activity_datetime.date()
            //         if employee.last_activity == fields.Date.today():
            //             employee.last_activity_time = format_time(self.env, last_presence, time_format='short')
            //         else:
            //             employee.last_activity_time = False
            //     else:
            //         employee.last_activity = False
            //         employee.last_activity_time = False
            */
            return default;
        }

        public async Task<TEntity> ComputeLastSeveralDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_last_several_days(self):
            // for holiday in self:
            //     holiday.last_several_days = holiday.number_of_days > 1
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveTypeIncreasesDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_leave_type_increases_duration(self):
            // durations = self._get_durations(check_leave_type=False)
            // for leave in self:
            //     days = durations[leave.id][0]
            //     if leave.leave_type_request_unit == 'day' and leave.holiday_status_requires_allocation and days < leave.number_of_days:
            //         leave.leave_type_increases_duration = self.env._("According to your working schedule you are expected to work"
            //         " %(days)s days in this period, but %(nb_days)s days will be used because this leave"
            //         " %(leave_type_name)s can only be taken by days.",
            //         days=days, nb_days=leave.number_of_days, leave_type_name=leave.holiday_status_id.name)
            //     else:
            //         leave.leave_type_increases_duration = ''
            */
            return default;
        }

        public async Task<TEntity> ComputeLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_leaves(self):
            // date_from = fields.Date.from_string(self.env.context['default_request_date_from']) if 'default_request_date_from' in self.env.context else fields.Date.today()
            // employee_days_per_allocation = self.employee_id._get_consumed_leaves(self.holiday_status_id, date_from)[0]
            // for leave in self:
            //     virtual_remaining_leaves = 0
            //     max_leaves = 0
            //     for allocation, allocation_dict in employee_days_per_allocation[leave.employee_id][leave.holiday_status_id].items():
            //         if allocation and (not allocation.date_to or allocation.date_to >= date_from):
            //             max_leaves += allocation_dict['max_leaves']
            //             virtual_remaining_leaves += allocation_dict['virtual_remaining_leaves']
            //     leave.virtual_remaining_leaves = virtual_remaining_leaves
            //     leave.max_leaves = max_leaves
            */
            return default;
        }

        public async Task<TEntity> ComputeLegalNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_legal_name(self):
            // for employee in self:
            //     if not employee.legal_name:
            //         employee.legal_name = employee.name
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkedAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment_field, object binary_field) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_linked_attachment_id(self, attachment_field, binary_field):
            // """Helper to retreive Attachment from Binary fields
            // This is needed because fields.Many2one('ir.attachment') makes all
            // attachments available to the user.
            // """
            // attachments = self.env['ir.attachment'].search([
            //     ('res_model', '=', self._name),
            //     ('res_id', 'in', self.ids),
            //     ('res_field', '=', binary_field)
            // ])
            // move_vals = {att.res_id: att for att in attachments}
            // for move in self:
            //     move[attachment_field] = move_vals.get(move._origin.id, False)
            */
            return default;
        }

        public async Task<TEntity> ComputeMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_made_sequence_gap(self):
            // unposted = self.filtered(lambda move: move.sequence_number != 0 and move.state != 'posted')
            // unposted.made_sequence_gap = True
            // for (journal, prefix), moves in (self - unposted).grouped(lambda m: (m.journal_id, m.sequence_prefix)).items():
            //     previous_numbers = set(self.env['account.move'].sudo().search([
            //         ('journal_id', '=', journal.id),
            //         ('sequence_prefix', '=', prefix),
            //         ('sequence_number', '>=', min(moves.mapped('sequence_number')) - 1),
            //         ('sequence_number', '<=', max(moves.mapped('sequence_number')) - 1),
            //     ]).mapped('sequence_number'))
            //     for move in moves:
            //         move.made_sequence_gap = move.sequence_number > 1 and (move.sequence_number - 1) not in previous_numbers
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_meeting_display(self):
            // applicant_with_meetings = self.filtered('meeting_ids')
            // (self - applicant_with_meetings).update({
            //     'meeting_display_text': _('No Meeting'),
            //     'meeting_display_date': ''
            // })
            // today = fields.Date.today()
            // for applicant in applicant_with_meetings:
            //     count = len(applicant.meeting_ids)
            //     dates = applicant.meeting_ids.mapped('start')
            //     min_date, max_date = min(dates).date(), max(dates).date()
            //     if min_date >= today:
            //         applicant.meeting_display_date = min_date
            //     else:
            //         applicant.meeting_display_date = max_date
            //     if count == 1:
            //         applicant.meeting_display_text = _('1 Meeting')
            //     elif applicant.meeting_display_date >= today:
            //         applicant.meeting_display_text = _('Next Meeting')
            //     else:
            //         applicant.meeting_display_text = _('Last Meeting')
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveSentValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def compute_move_sent_values(self):
            // for move in self:
            //     move.move_sent_values = 'sent' if move.is_move_sent else 'not_sent'
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_name(self):
            // self = self.sorted(lambda m: (m.date, m.ref or '', m._origin.id))
            // 
            // for move in self:
            //     if move.state == 'cancel':
            //         continue
            // 
            //     move_has_name = move.name and move.name != '/'
            //     if not move.posted_before and not move._sequence_matches_date():
            //         # The name does not match the date and the move is not the first in the period:
            //         # Reset to draft
            //         move.name = False
            //         continue
            //     if move.date and not move_has_name and move.state != 'draft':
            //         move._set_next_sequence()
            // 
            // self._inverse_name()
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_name(self):
            // for payment in self:
            //     if payment.id and (not payment.name or payment.move_id and payment.name != payment.move_id.name) and payment.state in ('in_process', 'paid'):
            //         payment.name = (
            //             payment.move_id.name
            //             or self.env['ir.sequence'].with_company(payment.company_id).next_by_code(
            //                 'account.payment',
            //                 sequence_date=payment.date,
            //             )
            //         )
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_name(self):
            // for expense in self:
            //     expense.name = expense.name or expense.product_id.display_name
            */
            return default;
        }

        public async Task<TEntity> ComputeNamePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_name_placeholder(self):
            // for move in self:
            //     if (not move.name or move.name == '/') and move.date and not move._get_last_sequence():
            //         sequence_format_string, sequence_format_values = move._get_next_sequence_format()
            //         sequence_format_values['seq'] = sequence_format_values['seq'] + 1
            //         move.name_placeholder = sequence_format_string.format(**sequence_format_values)
            //     else:
            //         move.name_placeholder = False
            */
            return default;
        }

        public async Task<TEntity> ComputeNarrationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_narration(self):
            // use_invoice_terms = self.env['ir.config_parameter'].sudo().get_param('account.use_invoice_terms')
            // invoice_to_update_terms = self.filtered(lambda m: use_invoice_terms and m.is_sale_document(include_receipts=True))
            // for move in invoice_to_update_terms:
            //     lang = move.partner_id.lang or self.env.user.lang
            //     if move.company_id.terms_type != 'html':
            //         narration = move.company_id.with_context(lang=lang).invoice_terms if not is_html_empty(move.company_id.invoice_terms) else ''
            //     else:
            //         baseurl = self.env.company.get_base_url() + '/terms'
            //         context = {'lang': lang}
            //         narration = _('Terms & Conditions: %s', baseurl)
            //         del context
            //     move.narration = narration or False
            */
            return default;
        }

        public async Task<TEntity> ComputeNbAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeNeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_need_cancel_request(self):
            // for move in self:
            //     move.need_cancel_request = move._need_cancel_request()
            */
            return default;
        }

        public async Task<TEntity> ComputeNeededTermsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_needed_terms(self):
            // AccountTax = self.env['account.tax']
            // for invoice in self.with_context(bin_size=False):
            //     is_draft = invoice.id != invoice._origin.id
            //     invoice.needed_terms = {}
            //     invoice.needed_terms_dirty = True
            //     sign = 1 if invoice.is_inbound(include_receipts=True) else -1
            //     if invoice.is_invoice(True) and invoice.invoice_line_ids:
            //         if invoice.invoice_payment_term_id:
            //             if is_draft:
            //                 tax_amount_currency = 0.0
            //                 tax_amount = tax_amount_currency
            //                 untaxed_amount_currency = 0.0
            //                 untaxed_amount = untaxed_amount_currency
            //                 sign = invoice.direction_sign
            //                 base_lines, _tax_lines = invoice._get_rounded_base_and_tax_lines(round_from_tax_lines=False)
            //                 AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, invoice.company_id, include_caba_tags=invoice.always_tax_exigible)
            //                 tax_results = AccountTax._prepare_tax_lines(base_lines, invoice.company_id)
            //                 for _base_line, to_update in tax_results['base_lines_to_update']:
            //                     untaxed_amount_currency += sign * to_update['amount_currency']
            //                     untaxed_amount += sign * to_update['balance']
            //                 for tax_line_vals in tax_results['tax_lines_to_add']:
            //                     tax_amount_currency += sign * tax_line_vals['amount_currency']
            //                     tax_amount += sign * tax_line_vals['balance']
            //             else:
            //                 tax_amount_currency = invoice.amount_tax * sign
            //                 tax_amount = invoice.amount_tax_signed
            //                 untaxed_amount_currency = invoice.amount_untaxed * sign
            //                 untaxed_amount = invoice.amount_untaxed_signed
            //             invoice_payment_terms = invoice.invoice_payment_term_id._compute_terms(
            //                 date_ref=invoice.invoice_date or invoice.date or fields.Date.context_today(invoice),
            //                 currency=invoice.currency_id,
            //                 tax_amount_currency=tax_amount_currency,
            //                 tax_amount=tax_amount,
            //                 untaxed_amount_currency=untaxed_amount_currency,
            //                 untaxed_amount=untaxed_amount,
            //                 company=invoice.company_id,
            //                 cash_rounding=invoice.invoice_cash_rounding_id,
            //                 sign=sign
            //             )
            //             for term_line in invoice_payment_terms['line_ids']:
            //                 key = frozendict({
            //                     'move_id': invoice.id,
            //                     'date_maturity': fields.Date.to_date(term_line.get('date')),
            //                     'discount_date': invoice_payment_terms.get('discount_date'),
            //                 })
            //                 values = {
            //                     'balance': term_line['company_amount'],
            //                     'amount_currency': term_line['foreign_amount'],
            //                     'discount_date': invoice_payment_terms.get('discount_date'),
            //                     'discount_balance': invoice_payment_terms.get('discount_balance') or 0.0,
            //                     'discount_amount_currency': invoice_payment_terms.get('discount_amount_currency') or 0.0,
            //                 }
            //                 if key not in invoice.needed_terms:
            //                     invoice.needed_terms[key] = values
            //                 else:
            //                     invoice.needed_terms[key]['balance'] += values['balance']
            //                     invoice.needed_terms[key]['amount_currency'] += values['amount_currency']
            //         else:
            //             invoice.needed_terms[frozendict({
            //                 'move_id': invoice.id,
            //                 'date_maturity': fields.Date.to_date(invoice.invoice_date_due),
            //                 'discount_date': False,
            //                 'discount_balance': 0.0,
            //                 'discount_amount_currency': 0.0
            //             })] = {
            //                 'balance': invoice.amount_total_signed,
            //                 'amount_currency': invoice.amount_total_in_currency_signed,
            //             }
            */
            return default;
        }

        public async Task<TEntity> ComputeNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_newly_hired(self):
            // new_hire_field = self._get_new_hire_field()
            // new_hire_date = fields.Datetime.now() - timedelta(days=90)
            // for employee in self:
            //     if not employee[new_hire_field]:
            //         employee.newly_hired = False
            //     elif not isinstance(employee[new_hire_field], datetime):
            //         employee.newly_hired = employee[new_hire_field] > new_hire_date.date()
            //     else:
            //         employee.newly_hired = employee[new_hire_field] > new_hire_date
            */
            return default;
        }

        public async Task<TEntity> ComputeNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_next_payment_date(self):
            // for move in self:
            //     move.next_payment_date = min([line.payment_date for line in move.line_ids.filtered(lambda l: l.payment_date and not l.reconciled)], default=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_no_followup(self):
            // for move in self:
            //     if move.is_invoice():
            //         lines = move.line_ids.filtered(
            //             lambda line: line.account_type in ('asset_receivable', 'liability_payable'),
            //         )
            //         move.no_followup = lines[0].no_followup if lines else True
            //     else:
            //         move.no_followup = True
            */
            return default;
        }

        public async Task<TEntity> ComputeOutstandingAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_outstanding_account_id(self):
            // for pay in self:
            //     pay.outstanding_account_id = pay.payment_method_line_id.payment_account_id
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_partner_bank_id(self):
            // def _bank_selection_key(bank):
            //     """Sorting priority:
            //     0. Same currency as the move or no currency
            //     1. Different currency
            //     Then: prefer banks allowing outgoing payments (trusted ones)
            //     """
            //     if bank.currency_id == move.currency_id or not bank.currency_id:
            //         currency_priority = 0
            //     else:
            //         currency_priority = 1
            //     return (currency_priority, not bank.allow_out_payment)
            // 
            // for move in self:
            //     if move.is_inbound() and (
            //         payment_method := (
            //             move.preferred_payment_method_line_id
            //             or move.bank_partner_id.property_inbound_payment_method_line_id
            //         )
            //     ) and payment_method.journal_id:
            //         move.partner_bank_id = payment_method.journal_id.bank_account_id
            //         continue
            // 
            //     move.partner_bank_id = move.bank_partner_id.bank_ids.filtered(
            //         lambda bank: not bank.company_id or bank.company_id == move.company_id
            //     ).sorted(key=_bank_selection_key)[:1]
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_partner_bank_id(self):
            // ''' The default partner_bank_id will be the first available on the partner. '''
            // for pay in self:
            //     if pay.partner_bank_id not in pay.available_partner_bank_ids:
            //         pay.partner_bank_id = pay.available_partner_bank_ids[:1]._origin
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCreditWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_partner_credit_warning(self):
            // for move in self:
            //     move.with_company(move.company_id)
            //     move.partner_credit_warning = ''
            //     show_warning = move.state == 'draft' and \
            //                    move.move_type == 'out_invoice' and \
            //                    move.company_id.account_use_credit_limit
            //     if show_warning:
            //         total_field = 'total_amount_currency' if move.currency_id == move.company_currency_id else 'total_amount'
            //         current_amount = move.tax_totals[total_field]
            //         move.partner_credit_warning = self._build_credit_warning_message(
            //             move,
            //             current_amount=current_amount,
            //             exclude_amount=move._get_partner_credit_warning_exclude_amount(),
            //         )
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_partner_phone_email(self):
            // for applicant in self:
            //     if not applicant.partner_id:
            //         continue
            //     applicant.email_from = applicant.partner_id.email
            //     if not applicant.partner_phone:
            //         applicant.partner_phone = applicant.partner_id.phone
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneSanitizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_partner_phone_sanitized(self):
            // for applicant in self:
            //     applicant.partner_phone_sanitized = (
            //         applicant._phone_format(fname="partner_phone") or applicant.partner_phone
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShippingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_partner_shipping_id(self):
            // for move in self:
            //     if move.is_invoice(include_receipts=True):
            //         addr = move.partner_id.address_get(['delivery'])
            //         move.partner_shipping_id = addr and addr.get('delivery')
            //     else:
            //         move.partner_shipping_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_count(self):
            // for invoice in self:
            //     invoice.payment_count = len(invoice.reconciled_payment_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentMethodLineFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_payment_method_line_fields(self):
            // for pay in self:
            //     pay.available_payment_method_line_ids = pay.journal_id._get_available_payment_method_lines(pay.payment_type)
            //     to_exclude = pay._get_payment_method_codes_to_exclude()
            //     if to_exclude:
            //         pay.available_payment_method_line_ids = pay.available_payment_method_line_ids.filtered(lambda x: x.code not in to_exclude)
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_payment_method_line_id(self):
            // ''' Compute the 'payment_method_line_id' field.
            // This field is not computed in '_compute_payment_method_line_fields' because it's a stored editable one.
            // '''
            // for pay in self:
            //     available_payment_method_lines = pay.available_payment_method_line_ids
            //     inbound_payment_method = pay.partner_id.property_inbound_payment_method_line_id
            //     outbound_payment_method = pay.partner_id.property_outbound_payment_method_line_id
            //     if pay.payment_type == 'inbound' and inbound_payment_method.id in available_payment_method_lines.ids:
            //         pay.payment_method_line_id = inbound_payment_method
            //     elif pay.payment_type == 'outbound' and outbound_payment_method.id in available_payment_method_lines.ids:
            //         pay.payment_method_line_id = outbound_payment_method
            //     elif pay.payment_method_line_id.id in available_payment_method_lines.ids:
            //         pay.payment_method_line_id = pay.payment_method_line_id
            //     elif available_payment_method_lines:
            //         pay.payment_method_line_id = available_payment_method_lines[0]._origin
            //     else:
            //         pay.payment_method_line_id = False
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_payment_method_line_id(self):
            // for expense in self:
            //     expense.payment_method_line_id = expense.selectable_payment_method_line_ids[:1]
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentReceiptTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_payment_receipt_title(self):
            // """ To override in order to change the title displayed on the payment receipt report """
            // self.payment_receipt_title = _('Payment Receipt')
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_reference(self):
            // for move in self.filtered(lambda m: (
            //     m.state == 'posted'
            //     and m.move_type == 'out_invoice'
            //     and not m.payment_reference
            // )):
            //     move.payment_reference = move._get_invoice_computed_reference()
            // self._inverse_payment_reference()
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_state(self):
            // def _invoice_qualifies(move):
            //     currency = move.currency_id or move.company_id.currency_id or self.env.company.currency_id
            //     return move.is_invoice(True) and (
            //         move.state == 'posted'
            //         or (move.state == 'draft' and not currency.is_zero(move.amount_total))
            //     )
            // 
            // groups = self.grouped(lambda move:
            //     'legacy' if move.payment_state == 'invoicing_legacy' else
            //     'blocked' if move.payment_state == 'blocked' else
            //     'invoices' if _invoice_qualifies(move) else
            //     'unpaid'
            // )
            // groups.get('unpaid', self.browse()).payment_state = 'not_paid'
            // invoices = groups.get('invoices', self.browse())
            // 
            // stored_ids = tuple(invoices.ids)
            // if stored_ids:
            //     self.env['account.partial.reconcile'].flush_model()
            //     self.env['account.payment'].flush_model(['is_matched'])
            // 
            //     queries = []
            //     for source_field, counterpart_field in (
            //         ('debit_move_id', 'credit_move_id'),
            //         ('credit_move_id', 'debit_move_id'),
            //     ):
            //         queries.append(SQL('''
            //             SELECT
            //                 source_line.id AS source_line_id,
            //                 source_line.move_id AS source_move_id,
            //                 account.account_type AS source_line_account_type,
            //                 ARRAY_AGG(counterpart_move.move_type) AS counterpart_move_types,
            //                 COALESCE(BOOL_AND(COALESCE(pay.is_matched, FALSE))
            //                     FILTER (WHERE counterpart_move.origin_payment_id IS NOT NULL), TRUE) AS all_payments_matched,
            //                 BOOL_OR(COALESCE(BOOL(pay.id), FALSE)) as has_payment,
            //                 BOOL_OR(COALESCE(BOOL(counterpart_move.statement_line_id), FALSE)) as has_st_line
            //             FROM account_partial_reconcile part
            //             JOIN account_move_line source_line ON source_line.id = part.%s
            //             JOIN account_account account ON account.id = source_line.account_id
            //             JOIN account_move_line counterpart_line ON counterpart_line.id = part.%s
            //             JOIN account_move counterpart_move ON counterpart_move.id = counterpart_line.move_id
            //             LEFT JOIN account_payment pay ON pay.id = counterpart_move.origin_payment_id
            //             WHERE source_line.move_id IN %s AND counterpart_line.move_id != source_line.move_id
            //             GROUP BY source_line.id, source_line.move_id, account.account_type
            //         ''', SQL.identifier(source_field), SQL.identifier(counterpart_field), stored_ids))
            // 
            //     payment_data = defaultdict(list)
            //     for row in self.env.execute_query_dict(SQL(" UNION ALL ").join(queries)):
            //         payment_data[row['source_move_id']].append(row)
            // else:
            //     payment_data = {}
            // 
            // for invoice in invoices:
            //     currency = invoice.currency_id or invoice.company_id.currency_id or self.env.company.currency_id
            //     reconciliation_vals = payment_data.get(invoice.id, [])
            // 
            //     # Restrict on 'receivable'/'payable' lines for invoices/expense entries.
            //     reconciliation_vals = [x for x in reconciliation_vals if x['source_line_account_type'] in ('asset_receivable', 'liability_payable')]
            // 
            //     new_pmt_state = 'not_paid'
            //     if currency.is_zero(invoice.amount_residual):
            //         if any(x['has_payment'] or x['has_st_line'] for x in reconciliation_vals):
            // 
            //             # Check if the invoice/expense entry is fully paid or 'in_payment'.
            //             if all(x['all_payments_matched'] for x in reconciliation_vals):
            //                 new_pmt_state = 'paid'
            //             else:
            //                 new_pmt_state = invoice._get_invoice_in_payment_state()
            // 
            //         else:
            //             new_pmt_state = 'paid'
            // 
            //             reverse_move_types = set()
            //             for x in reconciliation_vals:
            //                 for move_type in x['counterpart_move_types']:
            //                     reverse_move_types.add(move_type)
            // 
            //             in_reverse = (invoice.move_type in ('in_invoice', 'in_receipt')
            //                             and (reverse_move_types == {'in_refund'} or reverse_move_types == {'in_refund', 'entry'}))
            //             out_reverse = (invoice.move_type in ('out_invoice', 'out_receipt')
            //                             and (reverse_move_types == {'out_refund'} or reverse_move_types == {'out_refund', 'entry'}))
            //             misc_reverse = (invoice.move_type in ('entry', 'out_refund', 'in_refund')
            //                             and reverse_move_types == {'entry'})
            //             if in_reverse or out_reverse or misc_reverse:
            //                 new_pmt_state = 'reversed'
            //     elif invoice.state == 'posted' and invoice.matched_payment_ids.filtered(lambda p: not p.move_id and p.state == 'in_process'):
            //         new_pmt_state = invoice._get_invoice_in_payment_state()
            //     elif reconciliation_vals:
            //         new_pmt_state = 'partial'
            //     elif invoice.state == 'posted' and invoice.matched_payment_ids.filtered(lambda p: not p.move_id and p.state == 'paid'):
            //         new_pmt_state = invoice._get_invoice_in_payment_state()
            //     invoice.payment_state = new_pmt_state
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_term_details(self):
            // '''
            // Returns an [] containing the payment term's information to be displayed on the invoice's PDF.
            // '''
            // for invoice in self:
            //     invoice.payment_term_details = False
            //     if invoice.show_payment_term_details:
            //         sign = 1 if invoice.is_inbound(include_receipts=True) else -1
            //         payment_term_details = []
            //         for line in invoice.line_ids.filtered(lambda l: l.display_type == 'payment_term').sorted('date_maturity'):
            //             payment_term_details.append({
            //                 'date': format_date(self.env, line.date_maturity),
            //                 'amount': sign * line.amount_currency,
            //             })
            //         invoice.payment_term_details = payment_term_details
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetReconciledInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payments_widget_reconciled_info(self):
            // for move in self:
            //     payments_widget_vals = {'title': _('Less Payment'), 'outstanding': False, 'content': []}
            // 
            //     if move.state in {'draft', 'posted'} and move.is_invoice(include_receipts=True):
            //         reconciled_vals = []
            //         reconciled_partials = move.sudo()._get_all_reconciled_invoice_partials()
            //         for reconciled_partial in reconciled_partials:
            //             counterpart_line = reconciled_partial['aml']
            //             if counterpart_line.move_id.ref:
            //                 reconciliation_ref = '%s (%s)' % (counterpart_line.move_id.name, counterpart_line.move_id.ref)
            //             else:
            //                 reconciliation_ref = counterpart_line.move_id.name
            //             if counterpart_line.amount_currency and counterpart_line.currency_id != counterpart_line.company_id.currency_id:
            //                 foreign_currency = counterpart_line.currency_id
            //             else:
            //                 foreign_currency = False
            // 
            //             reconciled_vals.append({
            //                 'name': counterpart_line.name,
            //                 'journal_name': counterpart_line.journal_id.name,
            //                 'company_name': counterpart_line.journal_id.company_id.name if counterpart_line.journal_id.company_id != move.company_id else False,
            //                 'amount': reconciled_partial['amount'],
            //                 'currency_id': move.company_id.currency_id.id if reconciled_partial['is_exchange'] else reconciled_partial['currency'].id,
            //                 'date': counterpart_line.date,
            //                 'partial_id': reconciled_partial['partial_id'],
            //                 'account_payment_id': counterpart_line.payment_id.id,
            //                 'payment_method_name': counterpart_line.payment_id.payment_method_line_id.name,
            //                 'move_id': counterpart_line.move_id.id,
            //                 'is_refund': counterpart_line.move_id.move_type in ['in_refund', 'out_refund'],
            //                 'ref': reconciliation_ref,
            //                 # these are necessary for the views to change depending on the values
            //                 'is_exchange': reconciled_partial['is_exchange'],
            //                 'amount_company_currency': formatLang(self.env, abs(counterpart_line.balance), currency_obj=counterpart_line.company_id.currency_id),
            //                 'amount_foreign_currency': foreign_currency and formatLang(self.env, abs(counterpart_line.amount_currency), currency_obj=foreign_currency)
            //             })
            //         payments_widget_vals['content'] = reconciled_vals
            // 
            //     if payments_widget_vals['content']:
            //         move.invoice_payments_widget = payments_widget_vals
            //     else:
            //         move.invoice_payments_widget = False
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetToReconcileInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payments_widget_to_reconcile_info(self):
            // 
            // for move in self:
            //     move.invoice_outstanding_credits_debits_widget = False
            // 
            //     if move.state not in {'draft', 'posted'} \
            //             or move.payment_state not in ('not_paid', 'partial') \
            //             or not move.is_invoice(include_receipts=True):
            //         continue
            // 
            //     pay_term_lines = move.line_ids\
            //         .filtered(lambda line: line.account_id.account_type in ('asset_receivable', 'liability_payable'))
            // 
            //     domain = [
            //         ('account_id', 'in', pay_term_lines.account_id.ids),
            //         ('parent_state', '=', 'posted'),
            //         ('partner_id', '=', move.commercial_partner_id.id),
            //         ('reconciled', '=', False),
            //         ('balance', '<' if move.is_inbound() else '>', 0.0),
            //         '|', ('amount_residual', '!=', 0.0), ('amount_residual_currency', '!=', 0.0),
            //     ]
            // 
            //     payments_widget_vals = {
            //         'outstanding': True,
            //         'content': [],
            //         'move_id': move.id,
            //         'title': _('Outstanding credits') if move.is_inbound() else _('Outstanding debits')
            //     }
            // 
            //     for line in self.env['account.move.line'].search(domain):
            // 
            //         if line.currency_id == move.currency_id:
            //             # Same foreign currency.
            //             amount = abs(line.amount_residual_currency)
            //         else:
            //             # Different foreign currencies.
            //             amount = line.company_currency_id._convert(
            //                 abs(line.amount_residual),
            //                 move.currency_id,
            //                 move.company_id,
            //                 line.date,
            //             )
            // 
            //         if move.currency_id.is_zero(amount):
            //             continue
            // 
            //         payments_widget_vals['content'].append({
            //             'journal_name': line.ref or line.move_id.name,
            //             'amount': amount,
            //             'currency_id': move.currency_id.id,
            //             'id': line.id,
            //             'move_id': line.move_id.id,
            //             'date': fields.Date.to_string(line.date),
            //             'account_payment_id': line.payment_id.id,
            //         })
            // 
            //     if payments_widget_vals['content']:
            //         move.invoice_outstanding_credits_debits_widget = payments_widget_vals
            */
            return default;
        }

        public async Task<TEntity> ComputePreferredPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_preferred_payment_method_line_id(self):
            // for move in self:
            //     partner = move.partner_id.with_company(move.company_id)
            //     if move.is_sale_document():
            //         move.preferred_payment_method_line_id = partner.property_inbound_payment_method_line_id
            //     else:
            //         move.preferred_payment_method_line_id = partner.property_outbound_payment_method_line_id
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceIconInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_presence_icon(self):
            // """
            // This method compute the state defining the display icon in the kanban view.
            // It can be overriden to add other possibilities, like time off or attendances recordings.
            // """
            // for employee in self:
            //     employee.hr_icon_display = 'presence_' + employee.hr_presence_state
            //     employee.show_hr_icon_display = bool(employee.user_id)
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_presence_state(self):
            // """
            // This method is overritten in several other modules which add additional
            // presence criterions. e.g. hr_attendance, hr_holidays
            // """
            // # sudo: res.users - can access presence of accessible user
            // employee_to_check_working = self.filtered(
            //     lambda e: (e.user_id.sudo().presence_ids.status or "offline") == "offline"
            // )
            // working_now_list = employee_to_check_working._get_employee_working_now()
            // for employee in self:
            //     state = 'out_of_working_hour'
            //     if employee.company_id.sudo().hr_presence_control_login:
            //         # sudo: res.users - can access presence of accessible user
            //         presence_status = employee.user_id.sudo().presence_ids.status or "offline"
            //         if presence_status == "online":
            //             state = 'present'
            //         elif presence_status == "offline" and employee.id in working_now_list:
            //             state = 'absent'
            //     if not employee.active:
            //         state = 'archive'
            //     employee.hr_presence_state = state
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> ComputePrimaryBankAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_primary_bank_account_id(self):
            // for employee in self:
            //     if employee.bank_account_ids:
            //         primary_account = min(
            //             employee.bank_account_ids,
            //             key=lambda acc: employee.salary_distribution.get(str(acc.id), {}).get("sequence", float("inf")),
            //         )
            //         employee.primary_bank_account_id = primary_account
            //     else:
            //         employee.primary_bank_account_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_product_description(self):
            // for expense in self:
            //     expense.product_description = not is_html_empty(expense.product_id.description) and expense.product_id.description
            */
            return default;
        }

        public async Task<TEntity> ComputeQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_qr_code(self):
            // for pay in self:
            //     if pay.state in ('draft', 'in_process') \
            //         and pay.partner_bank_id \
            //         and pay.partner_bank_id.allow_out_payment \
            //         and pay.payment_method_line_id.code == 'manual' \
            //         and pay.payment_type == 'outbound' \
            //         and pay.currency_id:
            // 
            //         if pay.partner_bank_id:
            //             qr_code = pay.partner_bank_id.build_qr_code_base64(pay.amount, pay.memo, pay.memo, pay.currency_id, pay.partner_id)
            //         else:
            //             qr_code = None
            // 
            //         if qr_code:
            //             pay.qr_code = '''
            //                 <br/>
            //                 <img class="border border-dark rounded" src="{qr_code}"/>
            //                 <br/>
            //                 <strong class="text-center">{txt}</strong>
            //                 '''.format(txt = _('Scan me with your banking app.'),
            //                            qr_code = qr_code)
            //             continue
            // 
            //     pay.qr_code = None
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEditModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_quick_edit_mode(self):
            // for move in self:
            //     quick_edit_mode = move.company_id.quick_edit_mode
            //     if move.journal_id.type == 'sale':
            //         move.quick_edit_mode = quick_edit_mode in ('out_invoices', 'out_and_in_invoices')
            //     elif move.journal_id.type == 'purchase':
            //         move.quick_edit_mode = quick_edit_mode in ('in_invoices', 'out_and_in_invoices')
            //     else:
            //         move.quick_edit_mode = False
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEncodingValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_quick_encoding_vals(self):
            // for move in self:
            //     move.quick_encoding_vals = move._get_quick_edit_suggestions()
            */
            return default;
        }

        public async Task<TEntity> ComputeReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_reconciled_payment_ids(self):
            // ''' Retrieve the payments reconciled to the invoices through the reconciliation (account.partial.reconcile) '''
            // self.env['account.payment'].flush_model(fnames=['move_id'])
            // self.env['account.move'].flush_model(fnames=['move_type'])
            // self.env['account.move.line'].flush_model(fnames=['move_id', 'account_id'])
            // self.env['account.partial.reconcile'].flush_model(fnames=['debit_move_id', 'credit_move_id'])
            // self.env['account.account'].flush_model(fnames=['account_type'])
            // 
            // invoice_payment_links = dict(self.env.execute_query(SQL(
            //     """
            //     SELECT
            //         invoice.id,
            //         ARRAY_AGG(DISTINCT payment.id) AS payment_ids
            //     FROM account_payment payment
            //     JOIN account_move move ON move.id = payment.move_id
            //     JOIN account_move_line line ON line.move_id = move.id
            //     JOIN account_partial_reconcile part ON
            //         part.debit_move_id = line.id
            //         OR
            //         part.credit_move_id = line.id
            //     JOIN account_move_line counterpart_line ON
            //         part.debit_move_id = counterpart_line.id
            //         OR
            //         part.credit_move_id = counterpart_line.id
            //     JOIN account_move invoice ON invoice.id = counterpart_line.move_id
            //     JOIN account_account account ON account.id = line.account_id
            //     WHERE account.account_type IN ('asset_receivable', 'liability_payable')
            //         AND invoice.id IN %(invoice_ids)s
            //         AND line.id != counterpart_line.id
            //     GROUP BY invoice.id, invoice.move_type
            //     """,
            //     invoice_ids=tuple(self.ids),
            // ))) if self.ids else {}
            // for move in self:
            //     move.reconciled_payment_ids = self.env['account.payment'].browse(invoice_payment_links.get(move.id)) | move.matched_payment_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeReconciliationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_reconciliation_status(self):
            // ''' Compute the field indicating if the payments are already reconciled with something.
            // This field is used for display purpose (e.g. display the 'reconcile' button redirecting to the reconciliation
            // widget).
            // '''
            // for pay in self:
            //     liquidity_lines, counterpart_lines, writeoff_lines = pay._seek_for_lines()
            // 
            //     if not pay.outstanding_account_id:
            //         pay.is_reconciled = False
            //         pay.is_matched = pay.state == 'paid'
            //     elif not pay.currency_id or not pay.id or not pay.move_id:
            //         pay.is_reconciled = False
            //         pay.is_matched = False
            //     elif pay.currency_id.is_zero(pay.amount):
            //         pay.is_reconciled = True
            //         pay.is_matched = True
            //     else:
            //         residual_field = 'amount_residual' if pay.currency_id == pay.company_id.currency_id else 'amount_residual_currency'
            //         if pay.journal_id.default_account_id and pay.journal_id.default_account_id in liquidity_lines.account_id:
            //             # Allow user managing payments without any statement lines by using the bank account directly.
            //             # In that case, the user manages transactions only using the register payment wizard.
            //             pay.is_matched = True
            //         else:
            //             pay.is_matched = pay.currency_id.is_zero(sum(liquidity_lines.mapped(residual_field)))
            // 
            //         reconcile_lines = (counterpart_lines + writeoff_lines).filtered(lambda line: line.account_id.reconcile)
            //         pay.is_reconciled = pay.currency_id.is_zero(sum(reconcile_lines.mapped(residual_field)))
            */
            return default;
        }

        public async Task<TEntity> ComputeRelatedPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_related_partners_count(self):
            // self.related_partners_count = len(self._get_related_partners())
            */
            return default;
        }

        public async Task<TEntity> ComputeRequestHourFromToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_request_hour_from_to(self):
            // env_company_calendar = self.env.company.resource_calendar_id
            // for leave in self:
            //     calendar = leave.resource_calendar_id or env_company_calendar
            //     if (not leave.request_unit_hours
            //             and leave.employee_id
            //             and leave.request_date_from
            //             and leave.request_date_to
            //             and calendar):
            //         hour_from, hour_to = leave._get_hour_from_to(leave.request_date_from, leave.request_date_to)
            //         leave.request_hour_from = hour_from
            //         leave.request_hour_to = hour_to
            */
            return default;
        }

        public async Task<TEntity> ComputeRequestUnitHalfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_request_unit_half(self):
            // for holiday in self:
            //     holiday.request_unit_half = holiday.leave_type_request_unit == 'half_day'
            */
            return default;
        }

        public async Task<TEntity> ComputeRequestUnitHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_request_unit_hours(self):
            // for holiday in self:
            //     holiday.request_unit_hours = holiday.leave_type_request_unit == 'hour'
            */
            return default;
        }

        public async Task<TEntity> ComputeResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_resource_calendar_id(self):
            // leaves_without_emp_or_date = self.filtered(
            //     lambda leave: not (leave.employee_id and leave.request_date_from and leave.request_date_to)
            // )
            // valid_leaves = self - leaves_without_emp_or_date
            // leaves_without_emp_or_date.resource_calendar_id = self.env.company.resource_calendar_id
            // if not valid_leaves:
            //     return
            // employees_by_dates = defaultdict(lambda: self.env['hr.employee'])
            // contracts_by_employee = dict(
            //     self.env['hr.version']._read_group(
            //         domain=[('employee_id', 'in', self.employee_id.ids)],
            //         groupby=['employee_id'],
            //         aggregates=['id:recordset']
            //     )
            // )
            // for leave in valid_leaves:
            //     employees_by_dates[leave.request_date_from] += leave.employee_id
            // calendar_by_dates = {date_from: employees._get_calendars(date_from) for date_from, employees in employees_by_dates.items()}
            // for leave in valid_leaves:
            //     calendar = calendar_by_dates.get(leave.request_date_from, {}).get(leave.employee_id.id) \
            //                 or self.env.company.resource_calendar_id
            //     # We use the request dates to find the contracts, because date_from
            //     # and date_to are not set yet at this point. Since these dates are
            //     # used to get the contracts for which these leaves apply and
            //     # contract start- and end-dates are just dates (and not datetimes)
            //     # these dates are comparable.
            //     contracts = contracts_by_employee.get(leave.employee_id, self.env['hr.version']).filtered(
            //         lambda c: c.date_start <= leave.request_date_to and
            //                   (not c.date_end or c.date_end >= leave.request_date_from))
            //     if contracts:
            //         # If there are more than one contract they should all have the
            //         # same calendar, otherwise a constraint is violated.
            //         calendar = contracts[:1].resource_calendar_id
            //     leave.resource_calendar_id = calendar
            */
            return default;
        }

        public async Task<TEntity> ComputeSameReceiptExpenseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_secured(self):
            // for move in self:
            //     move.secured = bool(move.inalterable_hash)
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectablePaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeShowDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_delivery_date(self):
            // for move in self:
            //     move.show_delivery_date = move.delivery_date and move.is_sale_document()
            */
            return default;
        }

        public async Task<TEntity> ComputeShowJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_journal(self):
            // for move in self:
            //     move.show_journal = len(move.suitable_journal_ids) > 1
            */
            return default;
        }

        public async Task<TEntity> ComputeShowPaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_payment_term_details(self):
            // '''
            // Determines :
            // - whether or not an additional table should be added at the end of the invoice to display the various
            // - whether or not there is an early pay discount in this invoice that should be displayed
            // '''
            // for invoice in self:
            //     if invoice.move_type in self._early_payment_discount_move_types() and invoice.payment_state in ('not_paid', 'partial'):
            //         payment_term_lines = invoice.line_ids.filtered(lambda l: l.display_type == 'payment_term')
            //         invoice.show_discount_details = invoice.invoice_payment_term_id.early_discount
            //         invoice.show_payment_term_details = len(payment_term_lines) > 1 or invoice.show_discount_details
            //     else:
            //         invoice.show_discount_details = False
            //         invoice.show_payment_term_details = False
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRequirePartnerBankInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_show_require_partner_bank(self):
            // """ Computes if the destination bank account must be displayed in the payment form view. By default, it
            // won't be displayed but some modules might change that, depending on the payment type."""
            // for payment in self:
            //     if payment.journal_id.type == 'cash':
            //         payment.show_partner_bank_account = False
            //     else:
            //         payment.show_partner_bank_account = payment.payment_method_code in self._get_method_codes_using_bank_account()
            //     payment.require_partner_bank_account = payment.state == 'draft' and payment.payment_method_code in self._get_method_codes_needing_bank_account()
            */
            return default;
        }

        public async Task<TEntity> ComputeShowResetToDraftButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_reset_to_draft_button(self):
            // for move in self:
            //     move.show_reset_to_draft_button = (
            //         not self._is_move_restricted(move) \
            //         and not move.inalterable_hash
            //         and (move.state == 'cancel' or (move.state == 'posted' and not move.need_cancel_request))
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeShowTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_taxable_supply_date(self):
            // for move in self:
            //     move.show_taxable_supply_date = False
            */
            return default;
        }

        public async Task<TEntity> ComputeStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_stage(self):
            // for applicant in self:
            //     if applicant.job_id:
            //         if not applicant.stage_id:
            //             stage_ids = self.env['hr.recruitment.stage'].search([
            //                 '|',
            //                 ('job_ids', '=', False),
            //                 ('job_ids', '=', applicant.job_id.id),
            //                 ('fold', '=', False)
            //             ], order='sequence asc', limit=1).ids
            //             applicant.stage_id = stage_ids[0] if stage_ids else False
            //     else:
            //         applicant.stage_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeStatButtonsFromReconciliationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_stat_buttons_from_reconciliation(self):
            // ''' Retrieve the invoices reconciled to the payments through the reconciliation (account.partial.reconcile). '''
            // stored_payments = self.filtered('id')
            // if not stored_payments:
            //     self.reconciled_invoice_ids = False
            //     self.reconciled_invoices_count = 0
            //     self.reconciled_invoices_type = False
            //     self.reconciled_bill_ids = False
            //     self.reconciled_bills_count = 0
            //     self.reconciled_statement_line_ids = False
            //     self.reconciled_statement_lines_count = 0
            //     return
            // 
            // self.env['account.payment'].flush_model(fnames=['move_id', 'outstanding_account_id'])
            // self.env['account.move'].flush_model(fnames=['move_type', 'origin_payment_id', 'statement_line_id'])
            // self.env['account.move.line'].flush_model(fnames=['move_id', 'account_id', 'statement_line_id'])
            // self.env['account.partial.reconcile'].flush_model(fnames=['debit_move_id', 'credit_move_id'])
            // 
            // self.env.cr.execute('''
            //     SELECT
            //         payment.id,
            //         ARRAY_AGG(DISTINCT invoice.id) AS invoice_ids,
            //         invoice.move_type
            //     FROM account_payment payment
            //     JOIN account_move move ON move.id = payment.move_id
            //     JOIN account_move_line line ON line.move_id = move.id
            //     JOIN account_partial_reconcile part ON
            //         part.debit_move_id = line.id
            //         OR
            //         part.credit_move_id = line.id
            //     JOIN account_move_line counterpart_line ON
            //         part.debit_move_id = counterpart_line.id
            //         OR
            //         part.credit_move_id = counterpart_line.id
            //     JOIN account_move invoice ON invoice.id = counterpart_line.move_id
            //     JOIN account_account account ON account.id = line.account_id
            //     WHERE account.account_type IN ('asset_receivable', 'liability_payable')
            //         AND payment.id IN %(payment_ids)s
            //         AND line.id != counterpart_line.id
            //         AND invoice.move_type in ('out_invoice', 'out_refund', 'in_invoice', 'in_refund', 'out_receipt', 'in_receipt')
            //     GROUP BY payment.id, invoice.move_type
            // ''', {
            //     'payment_ids': tuple(stored_payments.ids)
            // })
            // query_res = self.env.cr.dictfetchall()
            // 
            // for pay in self:
            //     pay.reconciled_invoice_ids = pay.invoice_ids.filtered(lambda m: m.is_sale_document(True))
            //     pay.reconciled_bill_ids = pay.invoice_ids.filtered(lambda m: m.is_purchase_document(True))
            // 
            // for res in query_res:
            //     pay = self.browse(res['id'])
            //     if res['move_type'] in self.env['account.move'].get_sale_types(True):
            //         pay.reconciled_invoice_ids |= self.env['account.move'].browse(res.get('invoice_ids', []))
            //     else:
            //         pay.reconciled_bill_ids |= self.env['account.move'].browse(res.get('invoice_ids', []))
            // 
            // for pay in self:
            //     pay.reconciled_invoices_count = len(pay.reconciled_invoice_ids)
            //     pay.reconciled_bills_count = len(pay.reconciled_bill_ids)
            // 
            // query_res = dict(self.env.execute_query(SQL('''
            //     SELECT
            //         payment.id,
            //         ARRAY_AGG(DISTINCT counterpart_line.statement_line_id) AS statement_line_ids
            //     FROM account_payment payment
            //     JOIN account_move move ON move.id = payment.move_id
            //     JOIN account_move_line line ON line.move_id = move.id
            //     JOIN account_account account ON account.id = line.account_id
            //     JOIN account_partial_reconcile part ON
            //         part.debit_move_id = line.id
            //         OR
            //         part.credit_move_id = line.id
            //     JOIN account_move_line counterpart_line ON
            //         part.debit_move_id = counterpart_line.id
            //         OR
            //         part.credit_move_id = counterpart_line.id
            //     WHERE account.id = payment.outstanding_account_id
            //         AND payment.id IN %(payment_ids)s
            //         AND line.id != counterpart_line.id
            //         AND counterpart_line.statement_line_id IS NOT NULL
            //     GROUP BY payment.id
            // ''', payment_ids=tuple(stored_payments.ids)
            // )))
            // 
            // for pay in self:
            //     statement_line_ids = query_res.get(pay.id, [])
            //     pay.reconciled_statement_line_ids = [Command.set(statement_line_ids)]
            //     pay.reconciled_statement_lines_count = len(statement_line_ids)
            //     if len(pay.reconciled_invoice_ids.mapped('move_type')) == 1 and pay.reconciled_invoice_ids[0].move_type == 'out_refund':
            //         pay.reconciled_invoices_type = 'credit_note'
            //     else:
            //         pay.reconciled_invoices_type = 'invoice'
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _compute_state(self):
            // for payment in self:
            //     if not payment.state:
            //         payment.state = 'draft'
            //     # in_process --> paid
            //     if (move := payment.move_id) and payment.state in ('paid', 'in_process'):
            //         liquidity, _counterpart, _writeoff = payment._seek_for_lines()
            //         payment.state = (
            //             'paid'
            //             if move.company_currency_id.is_zero(sum(liquidity.mapped('amount_residual'))) or not any(liquidity.account_id.mapped('reconcile')) else
            //             'in_process'
            //         )
            //     if payment.state == 'in_process' and payment.reconciled_invoice_ids and all(invoice.payment_state == 'paid' for invoice in payment.reconciled_invoice_ids):
            //         payment.state = 'paid'
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

        public async Task<TEntity> ComputeStatusInPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_status_in_payment(self):
            // for move in self:
            //     if move.state == 'posted':
            //         if move.payment_state in ('partial', 'in_payment', 'paid', 'reversed'):
            //             move.status_in_payment = move.payment_state
            //         elif move.is_move_sent:
            //             move.status_in_payment = 'sent'
            //     elif move.state == 'draft':
            //         if move.payment_state in ('partial', 'in_payment', 'paid'):
            //             move.status_in_payment = move.payment_state
            // 
            //     if not move.status_in_payment:
            //         move.status_in_payment = move.state
            */
            return default;
        }

        public async Task<TEntity> ComputeSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_suitable_journal_ids(self):
            // for m in self:
            //     m.suitable_journal_ids = self._get_suitable_journal_ids(m.move_type, m.company_id)
            */
            return default;
        }

        public async Task<TEntity> ComputeSupportedAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_supported_attachment_ids(self):
            // for holiday in self:
            //     holiday.supported_attachment_ids = holiday.attachment_ids
            //     holiday.supported_attachment_ids_count = len(holiday.attachment_ids.ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeTalentPoolCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_talent_pool_count(self):
            // """
            // This method will find the amount of talent pools the current application is associated with.
            // An application can either be associated directly with a talent pool through talent_pool_ids
            // and/or pool_applicant_id.talent_pool_ids or indirectly by having the same email, phone
            // number or linkedin as a directly linked application.
            // """
            // pool_applicants = self.filtered("is_applicant_in_pool")
            // (self - pool_applicants).talent_pool_count = 0
            // 
            // if not pool_applicants:
            //     return
            // 
            // directly_linked = pool_applicants.filtered("pool_applicant_id")
            // for applicant in directly_linked:
            //     # All talents(applications with talent_pool_ids set) have a pool_applicant_id set to
            //     # themselves which is the reason we only look for that instead of searching for all
            //     # applications with talent_pool_ids and all applications with pool_applicant_id seperately
            //     applicant.talent_pool_count = len(applicant.pool_applicant_id.talent_pool_ids)
            // 
            // indirectly_linked = pool_applicants - directly_linked
            // if not indirectly_linked:
            //     return
            // 
            // all_emails = {a.email_normalized for a in indirectly_linked if a.email_normalized}
            // all_phones = {a.partner_phone_sanitized for a in indirectly_linked if a.partner_phone_sanitized}
            // all_linkedins = {a.linkedin_profile for a in indirectly_linked if a.linkedin_profile}
            // 
            // epl_domain = Domain.FALSE
            // if all_emails:
            //     epl_domain |= Domain("email_normalized", "in", list(all_emails))
            // if all_phones:
            //     epl_domain |= Domain("partner_phone_sanitized", "in", list(all_phones))
            // if all_linkedins:
            //     epl_domain |= Domain("linkedin_profile", "in", list(all_linkedins))
            // 
            // pool_domain = Domain(["|", ("talent_pool_ids", "!=", False), ("pool_applicant_id", "!=", False)])
            // domain = pool_domain & epl_domain
            // in_pool_applicants = self.env["hr.applicant"].with_context(active_test=True).search(domain)
            // 
            // in_pool_emails = defaultdict(int)
            // in_pool_phones = defaultdict(int)
            // in_pool_linkedins = defaultdict(int)
            // 
            // for applicant in in_pool_applicants:
            //     talent_pool_count = len(applicant.pool_applicant_id.talent_pool_ids)
            //     if applicant.email_normalized:
            //         in_pool_emails[applicant.email_normalized] = talent_pool_count
            //     if applicant.partner_phone_sanitized:
            //         in_pool_phones[applicant.partner_phone_sanitized] = talent_pool_count
            //     if applicant.linkedin_profile:
            //         in_pool_linkedins[applicant.linkedin_profile] = talent_pool_count
            // 
            // for applicant in indirectly_linked:
            //     if applicant.email_from and in_pool_emails[applicant.email_normalized]:
            //         applicant.talent_pool_count = in_pool_emails[applicant.email_normalized]
            //     elif applicant.partner_phone_sanitized and in_pool_phones[applicant.partner_phone_sanitized]:
            //         applicant.talent_pool_count = in_pool_phones[applicant.partner_phone_sanitized]
            //     elif applicant.linkedin_profile and in_pool_linkedins[applicant.linkedin_profile]:
            //         applicant.talent_pool_count = in_pool_linkedins[applicant.linkedin_profile]
            //     else:
            //         applicant.talent_pool_count = 0
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeTaxAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeTaxCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_country_code(self):
            // for record in self:
            //     record.tax_country_code = record.tax_country_id.code
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_country_id(self):
            // self.fetch(['fiscal_position_id', 'company_id'])
            // foreign_vat_records = self.filtered(lambda r: r.fiscal_position_id.foreign_vat)
            // for fiscal_position_id, record_group in groupby(foreign_vat_records, key=lambda r: r.fiscal_position_id):
            //     self.env['account.move'].concat(*record_group).tax_country_id = fiscal_position_id.country_id
            // for company_id, record_group in groupby((self-foreign_vat_records), key=lambda r: r.company_id):
            //     self.env['account.move'].concat(*record_group).tax_country_id = company_id.account_fiscal_country_id
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_tax_ids(self):
            // for _expense in self.filtered('company_id'):   # Avoid a traceback, the field is required anyway
            //     expense = _expense.with_company(_expense.company_id)
            //     # taxes only from the same company
            //     expense.tax_ids = expense.product_id.supplier_taxes_id.filtered_domain(self.env['account.tax']._check_company_domain(expense.company_id))
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_lock_date_message(self):
            // for move in self:
            //     accounting_date = move.date or fields.Date.context_today(move)
            //     affects_tax_report = move._affect_tax_report()
            //     move.tax_lock_date_message = move._get_lock_date_message(accounting_date, affects_tax_report)
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_totals(self):
            // """ Computed field used for custom widget's rendering.
            //     Only set on invoices.
            // """
            // for move in self:
            //     if move.is_invoice(include_receipts=True):
            //         base_lines, _tax_lines = move._get_rounded_base_and_tax_lines()
            //         move.tax_totals = self.env['account.tax']._get_tax_totals_summary(
            //             base_lines=base_lines,
            //             currency=move.currency_id,
            //             company=move.company_id,
            //             cash_rounding=move.invoice_cash_rounding_id,
            //         )
            //         move.tax_totals['display_in_company_currency'] = (
            //             move.company_id.display_invoice_tax_company_currency
            //             and move.company_currency_id != move.currency_id
            //             and move.tax_totals['has_tax_groups']
            //             and move.is_sale_document(include_receipts=True)
            //         )
            //     else:
            //         # Non-invoice moves don't support that field (because of multicurrency: all lines of the invoice share the same currency)
            //         move.tax_totals = None
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_taxable_supply_date(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxableSupplyDatePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_taxable_supply_date_placeholder(self):
            // for move in self:
            //     move.taxable_supply_date_placeholder = ''
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxesLegalNotesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_taxes_legal_notes(self):
            // for move in self:
            //     move.taxes_legal_notes = ''.join(
            //         tax.invoice_legal_notes
            //         for tax in OrderedSet(move.line_ids.tax_ids)
            //         if not is_html_empty(tax.invoice_legal_notes)
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> ComputeTypeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_type_name(self):
            // type_name_mapping = dict(
            //     self._fields['move_type']._description_selection(self.env),
            //     out_invoice=_('Invoice'),
            //     out_refund=_('Credit Note'),
            // )
            // 
            // for record in self:
            //     record.type_name = type_name_mapping[record.move_type]
            */
            return default;
        }

        public async Task<TEntity> ComputeTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_tz(self):
            // for leave in self:
            //     leave.tz = leave.resource_calendar_id.tz or self.env.company.resource_calendar_id.tz or self.env.user.tz or 'UTC'
            */
            return default;
        }

        public async Task<TEntity> ComputeTzMismatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_tz_mismatch(self):
            // for leave in self:
            //     leave.tz_mismatch = leave.tz != self.env.user.tz
            */
            return default;
        }

        public async Task<TEntity> ComputeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _compute_uom_id(self):
            // for expense in self:
            //     expense.product_uom_id = expense.product_id.uom_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_user(self):
            // for applicant in self:
            //     applicant.user_id = applicant.job_id.user_id.id
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_version_id(self):
            // context_version_id = self.env.context.get('version_id', False)
            // context_version = self.env['hr.version'].browse(context_version_id).exists() if context_version_id else self.env['hr.version']
            // 
            // for employee in self:
            //     if context_version.employee_id == self:
            //         version = context_version
            //     else:
            //         version = employee.current_version_id
            //     employee.version_id = version
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_versions_count(self):
            // version_count_per_employee = dict(
            //     self.env['hr.version']._read_group(
            //         [('employee_id', 'in', self.ids)],
            //         ['employee_id'],
            //         ['id:count'],
            //     ),
            // )
            // for employee in self:
            //     employee.versions_count = version_count_per_employee.get(employee, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_contact_details(self):
            // for employee in self:
            //     if employee.work_contact_id:
            //         if len(employee.work_contact_id.employee_ids) <= 1:
            //             employee.work_phone = employee.work_contact_id.phone
            //             employee.work_email = employee.work_contact_id.email
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_location_name(self):
            // for employee in self:
            //     employee.work_location_name = employee.version_id.work_location_id.name or None
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_location_type(self):
            // for employee in self:
            //     employee.work_location_type = employee.version_id.work_location_id.location_type or 'other'
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkPermitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_permit_name(self):
            // for employee in self:
            //     name = employee.name.replace(' ', '_') + '_' if employee.name else ''
            //     permit_no = '_' + employee.permit_no if employee.permit_no else ''
            //     employee.work_permit_name = "%swork_permit%s" % (name, permit_no)
            */
            return default;
        }

        public async Task<TEntity> ConditionalAddToComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object condition) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _conditional_add_to_compute(self, fname, condition):
            // field = self._fields[fname]
            // to_reset = self.filtered(lambda move:
            //     condition(move)
            //     and not self.env.is_protected(field, move._origin)
            //     and (move._origin or not move[fname])
            // )
            // to_reset.invalidate_recordset([fname])
            // self.env.add_to_compute(field, to_reset)
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def copy(self, default=None):
            // default = dict(default or {})
            // new_moves = super().copy(default)
            // bodies = {}
            // for old_move, new_move in zip(self, new_moves):
            //     message_origin = '' if not new_move.auto_post_origin_id else \
            //         (Markup('<br/>') + _('This recurring entry originated from %s', new_move.auto_post_origin_id._get_html_link()))
            //     message_content = old_move._get_copy_message_content(default)
            //     bodies[new_move.id] = message_content + message_origin
            // new_moves._message_log_batch(bodies=bodies)
            // return new_moves
            */
            return default;
        }

        public async Task<TEntity> CopyCacheFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @public, object field_names) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _copy_cache_from(self, public, field_names):
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // for fname in field_names:
            //     values = self.env.cache.get_values(public, public._fields[fname])
            //     if self._fields[fname].translate:
            //         values = [(value.copy() if value else None) for value in values]
            //     self.env.cache.update_raw(self, self._fields[fname], values)
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default)
            // default_date = fields.Date.to_date(default.get('date'))
            // for move, vals in zip(self, vals_list):
            //     if move.move_type in ('out_invoice', 'in_invoice'):
            //         vals['line_ids'] = [
            //             (command, _id, line_vals)
            //             for command, _id, line_vals in vals['line_ids']
            //             if command == Command.CREATE
            //         ]
            //     elif move.move_type == 'entry':
            //         if 'partner_id' not in vals or not self.env.context.get('move_reverse_cancel', False):
            //             vals['partner_id'] = False
            //     user_fiscal_lock_date = move.company_id._get_user_fiscal_lock_date(move.journal_id)
            //     if (default_date or move.date) <= user_fiscal_lock_date:
            //         vals['date'] = user_fiscal_lock_date + timedelta(days=1)
            //     if not move.journal_id.active and 'journal_id' in vals:
            //         del vals['journal_id']
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default)
            // for payment, vals in zip(self, vals_list):
            //     vals.update({
            //         'journal_id': payment.journal_id.id,
            //         'payment_method_line_id': payment.payment_method_line_id.id,
            //         **(vals or {}),
            //     })
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // if self.env.context.get('skip_copy_check'):
            //     return vals_list
            // if all(leave.state in ['cancel', 'refuse'] for leave in self):  # No overlap constraint in these cases
            //     return vals_list
            // raise UserError(_('A time off cannot be duplicated.'))
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // 
            // # Avoid adding `(copy)` to partner_name when an applicant is created trough the talent pool mechanism
            // if not self.env.context.get("no_copy_in_partner_name"):
            //     vals_list = [
            //         dict(vals, partner_name=self.env._("%s (copy)", applicant.partner_name))
            //         for applicant, vals in zip(self, vals_list)
            //     ]
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> CopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _copy_recurring_entries(self):
            // ''' Creates a copy of a recurring (periodic) entry and adjusts its dates for the next period.
            // Meant to be called right after posting a periodic entry.
            // Copies extra fields as defined by _get_fields_to_copy_recurring_entries().
            // '''
            // for record in self:
            //     record.auto_post_origin_id = record.auto_post_origin_id or record  # original entry references itself
            //     next_date = self._apply_delta_recurring_entries(record.date, record.auto_post_origin_id.date, record.auto_post)
            // 
            //     if not record.auto_post_until or next_date <= record.auto_post_until:  # recurrence continues
            //         record.copy(default=record._get_fields_to_copy_recurring_entries({'date': next_date}))
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def create(self, vals_list):
            // if any('state' in vals and vals.get('state') == 'posted' for vals in vals_list):
            //     raise UserError(_('You cannot create a move already in the posted state. Please create a draft move and post it after.'))
            // container = {'records': self}
            // with self._check_balanced(container):
            //     with ExitStack() as exit_stack, self._sync_dynamic_lines(container):
            //         for vals in vals_list:
            //             self._sanitize_vals(vals)
            //         stolen_moves = self.browse(set(move for vals in vals_list for move in self._stolen_move(vals)))
            //         moves = super().create(vals_list)
            //         exit_stack.enter_context(self.env.protecting([protected for vals, move in zip(vals_list, moves) for protected in self._get_protected_vals(vals, move)]))
            //         container['records'] = moves | stolen_moves
            //     for move, vals in zip(moves, vals_list):
            //         if 'tax_totals' in vals:
            //             move.tax_totals = vals['tax_totals']
            //     moves.is_manually_modified = False
            // return moves
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def create(self, vals_list):
            // # OVERRIDE
            // write_off_line_vals_list = []
            // force_balance_vals_list = []
            // linecomplete_line_vals_list = []
            // 
            // for vals in vals_list:
            // 
            //     # Hack to add a custom write-off line.
            //     write_off_line_vals_list.append(vals.pop('write_off_line_vals', None))
            // 
            //     # Hack to force a custom balance.
            //     force_balance_vals_list.append(vals.pop('force_balance', None))
            // 
            //     # Hack to add a custom line.
            //     linecomplete_line_vals_list.append(vals.pop('line_ids', None))
            // 
            // payments = super().create(vals_list)
            // 
            // # Outstanding account should be set on the payment in community edition to force the generation of journal entries on the payment
            // # This is required because no reconciliation is possible in community, which would prevent the user to reconcile the bank statement with the invoice
            // accounting_installed = self.env['account.move']._get_invoice_in_payment_state() == 'in_payment'
            // 
            // for i, (pay, vals) in enumerate(zip(payments, vals_list)):
            //     if (not accounting_installed and not pay.outstanding_account_id) or self.env.context.get('force_payment_move'):
            //         outstanding_account = pay._get_outstanding_account(pay.payment_type)
            //         pay.outstanding_account_id = outstanding_account.id
            // 
            //     if (
            //         write_off_line_vals_list[i] is not None
            //         or force_balance_vals_list[i] is not None
            //         or linecomplete_line_vals_list[i] is not None
            //     ):
            //         pay._generate_journal_entry(
            //             write_off_line_vals=write_off_line_vals_list[i],
            //             force_balance=force_balance_vals_list[i],
            //             line_ids=linecomplete_line_vals_list[i],
            //         )
            //         # propagate the related fields to the move as it is being created after the payment
            //         if move_vals := {
            //             fname: value
            //             for fname, value in vals.items()
            //             if self._fields[fname].related and (self._fields[fname].related or '').split('.')[0] == 'move_id'
            //         }:
            //             pay.move_id.write(move_vals)
            // return payments
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // vals_per_company = defaultdict(list)
            // for idx, vals in enumerate(vals_list):
            //     if vals.get('user_id'):
            //         user = self.env['res.users'].browse(vals['user_id'])
            //         vals.update(self._sync_user(user, bool(vals.get('image_1920'))))
            //         vals['name'] = vals.get('name', user.name)
            //         self._remove_work_contact_id(user, vals.get('company_id'))
            //     # Having one create per company is necessary to pass the company in the context to correctly set it in
            //     # the underlying version created by the framework
            //     vals_per_company[vals.get('company_id', self.env.company)].append((idx, vals))
            // index_per_employee = {}
            // employees = self.env['hr.employee']
            // for company, vals_list in vals_per_company.items():
            //     idxs, vals_list = zip(*vals_list)
            //     new_employees = super(HrEmployee, self.with_company(company)).create(vals_list)
            //     index_per_employee.update(dict(zip(new_employees, idxs)))
            //     employees |= new_employees
            // # As we do a custom batch by company, we must reorder the records to respect the original order.
            // employees = employees.sorted(key=lambda employee: index_per_employee[employee])
            // # Sudo in case HR officer doesn't have the Contact Creation group
            // employees.filtered(lambda e: not e.work_contact_id).sudo()._create_work_contacts()
            // for employee_sudo in employees.sudo():
            //     # creating 'svg/xml' attachments requires specific rights
            //     if not employee_sudo.image_1920 and self.env['ir.ui.view'].sudo(False).has_access('write'):
            //         employee_sudo.image_1920 = employee_sudo._avatar_generate_svg()
            //         employee_sudo.work_contact_id.image_1920 = employee_sudo.image_1920
            // if self.env.context.get('salary_simulation'):
            //     return employees
            // employee_departments = employees.department_id
            // if employee_departments:
            //     self.env['discuss.channel'].sudo().search([
            //         ('subscription_department_ids', 'in', employee_departments.ids)
            //     ])._subscribe_users_automatically()
            // onboarding_notes_bodies = {}
            // hr_root_menu = self.env.ref('hr.menu_hr_root')
            // for employee in employees:
            //     # Launch onboarding plans
            //     url = '/odoo/%s/action-hr.plan_wizard_action?active_model=hr.employee&menu_id=%s' % (employee.id, hr_root_menu.id)
            //     onboarding_notes_bodies[employee.id] = Markup(_(
            //         '<b>Congratulations!</b> May I recommend you to setup an <a href="%s">onboarding plan?</a>',
            //     )) % url
            // employees._message_log_batch(onboarding_notes_bodies)
            // employees.invalidate_recordset()
            // return employees
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def create(self, vals_list):
            // expenses = super().create(vals_list)
            // expenses.update_activities_and_mails()
            // return expenses
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def create(self, vals_list):
            // # Override to avoid automatic logging of creation
            // if not self.env.context.get('leave_fast_create'):
            //     leave_types = self.env['hr.leave.type'].browse([values.get('holiday_status_id') for values in vals_list if values.get('holiday_status_id')])
            //     mapped_validation_type = {leave_type.id: leave_type.leave_validation_type for leave_type in leave_types}
            // 
            //     for values in vals_list:
            //         employee_id = values.get('employee_id', False)
            //         leave_type_id = values.get('holiday_status_id')
            // 
            //         # Handle double validation
            //         if mapped_validation_type[leave_type_id] == 'both':
            //             self._check_double_validation_rules(employee_id, values.get('state', False))
            // 
            // if any(not vals.get('employee_id') for vals in vals_list):
            //     raise UserError(_("There is no employee set on the time off. Please make sure you're logged in the correct company."))
            // holidays = super(HrLeave, self.with_context(mail_create_nosubscribe=True)).create(vals_list)
            // holidays._check_validity()
            // self.env['hr.leave.allocation'].invalidate_model(['leaves_taken', 'max_leaves'])  # missing dependency on compute
            // 
            // for holiday in holidays:
            //     if not self.env.context.get('leave_fast_create'):
            //         # Everything that is done here must be done using sudo because we might
            //         # have different create and write rights
            //         # eg : holidays_user can create a leave request with validation_type = 'manager' for someone else
            //         # but they can only write on it if they are leave_manager_id
            //         holiday_sudo = holiday.sudo()
            //         holiday_sudo.add_follower(holiday.employee_id.id)
            //         if holiday.validation_type == 'manager':
            //             holiday_sudo.message_subscribe(partner_ids=holiday.employee_id.leave_manager_id.partner_id.ids)
            //         if holiday.validation_type == 'no_validation':
            //             # Automatic validation should be done in sudo, because user might not have the rights to do it by himself
            //             holiday_sudo.action_approve()
            //             holiday_sudo.message_subscribe(partner_ids=holiday._get_responsible_for_approval().partner_id.ids)
            //             holiday_sudo.message_post(body=_("The time off has been automatically approved"), subtype_xmlid="mail.mt_comment") # Message from OdooBot (sudo)
            //         elif not self.env.context.get('import_file'):
            //             holiday_sudo.activity_update()
            // return holidays
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('user_id'):
            //         vals['date_open'] = fields.Datetime.now()
            //     if vals.get('email_from'):
            //         vals['email_from'] = vals['email_from'].strip()
            // applicants = super().create(vals_list)
            // applicants.sudo().interviewer_ids._create_recruitment_interviewers()
            // 
            // for applicant in applicants:
            //     if applicant.talent_pool_ids and not applicant.pool_applicant_id:
            //         applicant.pool_applicant_id = applicant
            // 
            // if (applicants.interviewer_ids.partner_id - self.env.user.partner_id):
            //     for applicant in applicants:
            //         interviewers_to_notify = applicant.interviewer_ids.partner_id - self.env.user.partner_id
            //         notification_subject = _("You have been assigned as an interviewer for %s", applicant.display_name)
            //         notification_body = _("You have been assigned as an interviewer for the Applicant %s", applicant.partner_name)
            //         applicant.message_notify(
            //             res_id=applicant.id,
            //             model=applicant._name,
            //             partner_ids=interviewers_to_notify.ids,
            //             author_id=self.env.user.partner_id.id,
            //             email_from=self.env.user.email_formatted,
            //             subject=notification_subject,
            //             body=notification_body,
            //             email_layout_xmlid="mail.mail_notification_layout",
            //             model_description="Applicant",
            //         )
            // return applicants
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyPaidMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> CreateContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create_contract(self, date):
            // # Here we can assume that there is no existing contract on the date given
            // self.ensure_one()
            // if date and isinstance(date, str):
            //     date = fields.Date.to_date(date)
            // 
            // contracts = self._get_contract_versions(date)[self.id]
            // future_contract_dates = [d for d in list(contracts.keys()) if d > date]
            // new_contract_date_end = min(future_contract_dates) + relativedelta(days=-1) if future_contract_dates else False
            // 
            // # There is already a version but with no contract defined on it so we simply write on it the dates
            // if version_same_date := self.version_ids.filtered(lambda v: v.date_version == date):
            //     version_same_date.write({
            //         'contract_date_start': date,
            //         'contract_date_end': new_contract_date_end
            //     })
            //     return version_same_date
            // 
            // return self.create_version({
            //     'date_version': date,
            //     'contract_date_start': date,
            //     'contract_date_end': new_contract_date_end
            // })
            */
            return default;
        }

        public async Task<TEntity> CreateEmployeeFromApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def create_employee_from_applicant(self):
            // """ Create an employee from applicant """
            // self.ensure_one()
            // self._check_interviewer_access()
            // 
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('Please provide an applicant name.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // action = self.env['ir.actions.act_window']._for_xml_id('hr.open_view_employee_list')
            // employee = self.env['hr.employee'].with_context(clean_context(self.env.context)).create(self._get_employee_create_vals())
            // action['res_id'] = employee.id
            // employee_attachments = self.env['ir.attachment'].search([('res_model', '=','hr.employee'), ('res_id', '=', employee.id)])
            // unique_attachments = self.attachment_ids.filtered(
            //     lambda attachment: attachment.datas not in employee_attachments.mapped('datas')
            // )
            // unique_attachments.copy({'res_model': 'hr.employee', 'res_id': employee.id})
            // employee.write({
            //     'job_id': self.job_id.id,
            //     'job_title': self.job_id.name,
            //     'department_id': self.department_id.id,
            //     'work_email': self.department_id.company_id.email or self.email_from, # To have a valid email address by default
            //     'work_phone': self.department_id.company_id.phone,
            // })
            // return action
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateExpenseFromAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids, object view_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        [ApiModel]
        public async Task<TEntity> CreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_list) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _create(self, data_list):
            // versions = [vals['stored'].pop('version_id', None) for vals in data_list]
            // result = super()._create(data_list)
            // for (employee, version_id, vals) in zip(result, versions, data_list):
            //     version = self.env['hr.version'].browse(version_id)
            //     version.employee_id = employee.id
            //     version.write({**vals.get('inherited', {})['hr.version'], 'employee_id': employee.id})
            // return result
            */
            return default;
        }

        public async Task<TEntity> CreateResourceLeaveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _create_resource_leave(self):
            // """ This method will create entry in resource calendar time off object at the time of holidays validated
            // :returns: created `resource.calendar.leaves`
            // """
            // vals_list = [leave._prepare_resource_leave_vals() for leave in self]
            // return self.env['resource.calendar.leaves'].sudo().create(vals_list)
            */
            return default;
        }

        public async Task<TEntity> CreateVersionAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create_version(self, values):
            // self.ensure_one()
            // 
            // date = values.get('date_version', False)
            // if not date:
            //     raise ValueError("date_version is required")
            // 
            // if isinstance(date, str):
            //     date = fields.Date.to_date(date)
            // elif isinstance(date, datetime):
            //     date = date.date()
            // 
            // version_to_copy = self._get_version(date)
            // if not version_to_copy:
            //     version_to_copy = self.env['hr.version'].search([('employee_id', '=', self.id)], limit=1)
            // if version_to_copy.date_version == date:
            //     return version_to_copy
            // 
            // date_from, date_to = self.sudo()._get_contract_dates(date)
            // contract_date_start = values.get('contract_date_start', date_from)
            // contract_date_end = values.get('contract_date_end', date_to)
            // employee_id = values.get('employee_id', self.id)
            // 
            // if isinstance(contract_date_start, str):
            //     contract_date_start = fields.Date.to_date(contract_date_start)
            // if isinstance(contract_date_end, str):
            //     contract_date_end = fields.Date.to_date(contract_date_end)
            // 
            // if contract_date_start == date_from and contract_date_end != date_to:
            //     versions_sudo_to_sync = self.env['hr.version'].with_context(sync_contract_dates=True).sudo().search([
            //         ('employee_id', '=', employee_id),
            //         ('contract_date_start', '=', date_from),
            //     ])
            //     if versions_sudo_to_sync:
            //         versions_sudo_to_sync.write({
            //             'contract_date_end': contract_date_end,
            //         })
            // self.check_access('write')
            // version_to_copy.check_access('write')
            // # to be sure even if the user has no access to certain fields, we can still copy the verison without any issues.
            // copy_vals = {
            //     'date_version': date,
            //     'employee_id': employee_id,
            //     'contract_date_start': contract_date_start,
            //     'contract_date_end': contract_date_end,
            // }
            // if 'active' in values:
            //     copy_vals['active'] = values['active']
            // if calendar_id := values.get('resource_calendar_id'):
            //     copy_vals['resource_calendar_id'] = calendar_id
            // # apply the changes on the new versions.
            // new_version_vals = {
            //     field_name: field_value
            //     for field_name, field_value in values.items()
            //     if field_name not in copy_vals
            // }
            // version_fields = self.env['hr.version']._fields
            // copy_vals = {
            //     k: v
            //     for k, v in version_to_copy.sudo().copy_data()[0].items()
            //     if not (k in new_version_vals and version_fields[k].type in ['one2many', 'many2many'])
            // } | copy_vals
            // new_version = self.env['hr.version'].sudo().create(copy_vals).sudo(False)
            // with self.env.protecting([f for f_name, f in version_fields.items() if f_name not in new_version_vals and f.copy], new_version):
            //     properties_fields_vals = {
            //         field_name: field_value
            //         for field_name, field_value in copy_vals.items()
            //         if version_fields[field_name].type == 'properties' and field_name not in new_version_vals
            //     }
            //     if properties_fields_vals:  # make sure properties vals are correctly copied.
            //         new_version.sudo().write(properties_fields_vals)
            //     new_version.write(new_version_vals)
            // return new_version
            */
            return default;
        }

        public async Task<TEntity> CreateWorkContactsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _create_work_contacts(self):
            // if any(employee.work_contact_id for employee in self):
            //     raise UserError(_('Some employee already have a work contact'))
            // work_contacts = self.env['res.partner'].create([{
            //     'email': employee.work_email,
            //     'phone': employee.work_phone,
            //     'name': employee.name,
            //     'image_1920': employee.image_1920,
            //     'company_id': employee.company_id.id
            // } for employee in self])
            // for employee, work_contact in zip(self, work_contacts):
            //     employee.work_contact_id = work_contact
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _creation_message(self):
            // # EXTENDS mail mail.thread
            // if not self.is_invoice(include_receipts=True):
            //     return super()._creation_message()
            // return {
            //     'out_invoice': _('Invoice Created'),
            //     'out_refund': _('Credit Note Created'),
            //     'in_invoice': _('Vendor Bill Created'),
            //     'in_refund': _('Refund Created'),
            //     'out_receipt': _('Sales Receipt Created'),
            //     'in_receipt': _('Purchase Receipt Created'),
            // }[self.move_type]
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _creation_message(self):
            // if self.env.context.get('from_split_wizard'):
            //     return _("Expense created from a split.")
            // return super()._creation_message()
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _creation_subtype(self):
            // # EXTENDS mail mail.thread
            // if self.move_type in ('out_invoice', 'out_receipt'):
            //     return self.env.ref('account.mt_invoice_created')
            // else:
            //     return super()._creation_subtype()
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _creation_subtype(self):
            // self.ensure_one()
            // if self.is_pool_applicant:
            //     return self.env.ref('hr_recruitment.mt_talent_new', raise_if_not_found=False)
            // return self.env.ref('hr_recruitment.mt_applicant_new')
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronAccountMoveSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object job_count) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _cron_account_move_send(self, job_count=10):
            // """ Process invoices generation and sending asynchronously.
            // :param job_count: maximum number of jobs to process if specified.
            // """
            // domain = [
            //     ('sending_data', '!=', False),
            //     ('state', '=', 'posted'),
            // ]
            // to_process = self.search(
            //     domain,
            //     order='date asc, invoice_date asc, sequence_number asc, id asc',
            //     limit=job_count)
            // to_process.try_lock_for_update()
            // if not to_process:
            //     return
            // 
            // self.env['account.move.send']._generate_and_send_invoices(
            //     to_process,
            //     from_cron=True,
            // )
            // self.env['ir.cron']._commit_progress(len(to_process), remaining=self.search_count(domain))
            */
            return default;
        }

        public async Task<TEntity> CronUpdateCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _cron_update_current_version_id(self):
            // self.search([])._compute_current_version_id()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def default_get(self, fields):
            // defaults = super().default_get(fields)
            // defaults = self._default_get_request_dates(defaults)
            // if self.env.context.get('holiday_status_display_name', True) and 'holiday_status_id' in fields and not defaults.get('holiday_status_id'):
            //     domain = ['|', ('requires_allocation', '=', False), ('has_valid_allocation', '=', True)]
            //     defaults['holiday_status_id'] = False
            //     leave_types = self.env['hr.leave.type'].search(domain, order='sequence')
            //     selected_leave_type = next(
            //         (
            //             leave_type for leave_type in leave_types
            //             if (defaults.get('request_unit_hours') and leave_type['request_unit'] == 'hour') or (not defaults.get('request_unit_hours'))
            //         ),
            //         leave_types[0] if leave_types else None,
            //     )
            //     if selected_leave_type:
            //         defaults['holiday_status_id'] = selected_leave_type.id
            //         defaults['request_unit_hours'] = (selected_leave_type.request_unit == 'hour')
            // 
            // if 'request_date_from' in fields and 'request_date_from' not in defaults:
            //     defaults['request_date_from'] = Date.today()
            // if 'request_date_to' in fields and 'request_date_to' not in defaults:
            //     defaults['request_date_to'] = Date.today()
            // 
            // return defaults
            */
            return default;
        }

        public async Task<TEntity> DefaultGetRequestDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _default_get_request_dates(self, values):
            // # The UI views initialize date_{from,to} due to how calendar views work.
            // # However it is request_date_{from,to} that should be used instead.
            // # Instead of overwriting all the javascript methods to use
            // # request_date_{from,to} instead of date_{from,to}, we just convert
            // # date_{from,to} to request_date_{from,to} here.
            // 
            // # Request dates are determined during an onchange scenario.
            // # To ensure that the values are correct in the client context (UI),
            // # the timezone must be applied (because no processing is carried out
            // # when these dates are received on the frontend).
            // # Note:
            // # Without the application of the timezone, days based on UTC datetimes
            // # will be returned (and will therefore not be correct for the client).
            // client_tz = self.env.tz
            // if values.get('date_from'):
            //     if not values.get('request_date_from'):
            //         values['request_date_from'] = pytz.utc.localize(values['date_from']).astimezone(client_tz)
            //     del values['date_from']
            // if values.get('date_to'):
            //     if not values.get('request_date_to'):
            //         values['request_date_to'] = pytz.utc.localize(values['date_to']).astimezone(client_tz)
            //     del values['date_to']
            // return values
            */
            return default;
        }

        public async Task<TEntity> DefaultOrderLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self.env['account.move.line']._get_product_catalog_lines_data()
            // return {**default_data, **new_default_data}
            */
            return default;
        }

        public async Task<TEntity> DetachAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _detach_attachments(self):
            // """
            // Called by button_draft to detach specific attachments for the current journal entries to allow regeneration.
            // """
            // files_to_detach = self.sudo().env['ir.attachment'].search([
            //     ('res_model', '=', 'account.move'),
            //     ('res_id', 'in', self.ids),
            //     ('res_field', 'in', self._get_fields_to_detach()),
            // ])
            // if files_to_detach:
            //     files_to_detach.res_field = False
            //     today = format_date(self.env, fields.Date.context_today(self))
            //     for attachment in files_to_detach:
            //         attachment_name, attachment_extension = os.path.splitext(attachment.name)
            //         attachment.name = _(
            //             '%(attachment_name)s (detached by %(user)s on %(date)s)%(attachment_extension)s',
            //             attachment_name=attachment_name,
            //             attachment_extension=attachment_extension,
            //             user=self.env.user.name,
            //             date=today,
            //         )
            */
            return default;
        }

        public async Task<TEntity> DisableDiscountPrecisionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _disable_discount_precision(self):
            // """Disable the user defined precision for discounts.
            // 
            // This is useful for importing documents coming from other softwares and providers.
            // The reasonning is that if the document that we are importing has a discount, it
            // shouldn't be rounded to the local settings.
            // """
            // with self._disable_recursion({'records': self}, 'ignore_discount_precision'):
            //     yield
            */
            return default;
        }

        public async Task<TEntity> DisableRecursionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container, object key, object @default, object target) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _disable_recursion(self, container, key, default=None, target=True):
            // """Apply the context key to all environments inside this context manager.
            // 
            // If the value linked to the key is the same as the target, yield `True`.
            // Check for the key both in the record's context and in the recursion stack.
            // 
            // :param container: deprecated, not used anymore
            // :param key: The context key to apply to the recordsets.
            // :param default: the default value of the context key, if it isn't defined
            //                 yet in the context
            // :param target: the value of the context key meaning that we shouldn't
            //                recurse
            // :return: True iff we should just exit the context manager
            // """
            // 
            // stack = self.env.cr.cache.setdefault('account_disable_recursion_stack', StackMap())
            // try:
            //     current_val = stack[key]
            // except KeyError:
            //     current_val = self.env.context.get(key, default)
            // 
            // disabled = current_val == target
            // stack.pushmap({key: target})
            // try:
            //     yield disabled
            // finally:
            //     stack.popmap()
            */
            return default;
        }

        public async Task<TEntity> DoApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object check) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> DoRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reason) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> DoResetApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _do_reset_approval(self):
            // self.sudo().write({'approval_state': False, 'approval_date': False, 'account_move_id': False})
            // self.update_activities_and_mails()
            */
            return default;
        }

        public async Task<TEntity> EarlyPaymentDiscountMoveTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _early_payment_discount_move_types(self):
            // return ('out_invoice', 'out_receipt', 'in_invoice', 'in_receipt')
            */
            return default;
        }

        public async Task<TEntity> EmployeeAttendanceIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object lunch) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _employee_attendance_intervals(self, start, stop, lunch=False):
            // self.ensure_one()
            // if not lunch:
            //     return self._get_expected_attendances(start, stop)
            // else:
            //     valid_versions = self.sudo()._get_versions_with_contract_overlap_with_period(start.date(), stop.date())
            //     if not valid_versions:
            //         calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //         return calendar._attendance_intervals_batch(start, stop, self.resource_id, lunch=True)[self.resource_id.id]
            //     employee_tz = timezone(self.tz) if self.tz else None
            //     duration_data = Intervals()
            //     for version in valid_versions:
            //         version_start = datetime.combine(version.date_start, time.min, employee_tz)
            //         version_end = datetime.combine(version.date_end or date.max, time.max, employee_tz)
            //         calendar = version.resource_calendar_id or version.company_id.resource_calendar_id
            //         lunch_intervals = calendar._attendance_intervals_batch(
            //             max(start, version_start),
            //             min(stop, version_end),
            //             resources=self.resource_id,
            //             lunch=True)[self.resource_id.id]
            //         duration_data = duration_data | lunch_intervals
            //     return duration_data
            */
            return default;
        }

        public async Task<TEntity> ExtendWithAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files_data, object @new) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _extend_with_attachments(self, files_data, new=False):
            // existing_lines = self.invoice_line_ids
            // res = super()._extend_with_attachments(files_data, new)
            // 
            // if new_lines := (self.invoice_line_ids - existing_lines):
            //     new_lines.is_imported = True
            //     if not existing_lines:
            //         self.with_context(default_move_type=self.move_type)._link_bill_origin_to_purchase_orders(timeout=4)
            // 
            // if new and res:
            //     try:
            //         attachments = self._from_files_data(files_data + self._unwrap_attachments(files_data))
            //         self.journal_id._notify_invoice_subscribers(
            //             invoice=self,
            //             mail_params={
            //                 'attachment_ids': [
            //                     Command.create({
            //                         'name': f"MAIL_{attachment['name']}",
            //                         'mimetype': attachment['mimetype'],
            //                         'raw': attachment['raw'],
            //                     }) for attachment in attachments
            //                 ]
            //             },
            //         )
            //     except Exception:
            //         _logger.exception("Failed to notify invoice subscribers after EDI import.")
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def fetch(self, field_names=None):
            // if self.browse().has_access('read'):
            //     return super().fetch(field_names)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // if field_names is None:
            //     field_names = [field.name for field in self._determine_fields_to_fetch()]
            // field_names = [f_name for f_name in field_names if f_name != 'current_version_id']
            // self._check_private_fields(field_names)
            // self.flush_recordset(field_names)
            // public = self.env['hr.employee.public'].browse(self._ids)
            // public.fetch(field_names)
            // # make sure all related fields from employee are in cache
            // for field_name in field_names:
            //     public_field = self.env['hr.employee.public']._fields[field_name]
            //     private_field = self.env['hr.employee']._fields[field_name]
            //     if (public_field.related and public_field.related_field.model_name == 'hr.employee'
            //             or private_field.inherited and private_field.inherited_field.model_name == 'hr.version'):
            //         public.mapped(field_name)
            // self._copy_cache_from(public, field_names)
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object matching_states) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _fetch_duplicate_reference(self, matching_states=('draft', 'posted')):
            // moves = self.filtered(lambda m: m.is_sale_document() or m.is_purchase_document() and m.ref)
            // 
            // if not moves:
            //     return {}
            // 
            // used_fields = ("company_id", "partner_id", "commercial_partner_id", "ref", "move_type", "invoice_date", "state", "amount_total")
            // 
            // self.env["account.move"].flush_model(used_fields)
            // 
            // move_table_and_alias = SQL("account_move AS move")
            // if not all(move.id for move in moves):  # check if record is under creation/edition in UI
            //     # New record aren't searchable in the DB and record in edition aren't up to date yet
            //     # Replace the table by safely injecting the values in the query
            //     all_values = []
            //     for move in moves:
            //         values = {
            //             field_name: move._fields[field_name].convert_to_write(move[field_name], move) or None
            //             for field_name in used_fields
            //         }
            //         values["id"] = move._origin.id or 0
            //         # The amount total depends on the field line_ids and is calculated upon saving,
            //         # we needed a way to get it even when the invoices has not been saved yet.
            //         values['amount_total'] = move.tax_totals.get('total_amount_currency', 0)
            //         casted_values = SQL(', ').join(
            //             SQL("%s::%s", value, SQL.identifier(move._fields[field_name].column_type[0]))
            //             for field_name, value in values.items()
            //         )
            //         all_values.append(SQL("(%s)", casted_values))
            //     column_names = SQL(', ').join(SQL.identifier(field_name) for field_name in used_fields + ("id",))
            //     move_table_and_alias = SQL("(VALUES %s) AS move(%s)", SQL(', ').join(all_values), column_names)
            // 
            // to_query = []
            // out_moves = moves.filtered(lambda m: m.move_type in ('out_invoice', 'out_refund'))
            // if out_moves:
            //     out_moves_sql_condition = SQL("""
            //         move.move_type in ('out_invoice', 'out_refund')
            //         AND (
            //            move.amount_total = duplicate_move.amount_total
            //            AND move.invoice_date = duplicate_move.invoice_date
            //         )
            //     """)
            //     to_query.append((out_moves, out_moves_sql_condition))
            // 
            // in_moves = moves.filtered(lambda m: m.move_type in ('in_invoice', 'in_refund'))
            // if in_moves:
            //     in_moves_sql_condition = SQL("""
            //         move.move_type in ('in_invoice', 'in_refund')
            //         AND duplicate_move.move_type in ('in_invoice', 'in_refund')
            //         AND (
            //            move.ref = duplicate_move.ref
            //            AND (
            //                move.invoice_date IS NULL
            //                OR
            //                duplicate_move.invoice_date IS NULL
            //                OR
            //                date_part('year', move.invoice_date) = date_part('year', duplicate_move.invoice_date)
            //            )
            //         )
            //     """)
            //     to_query.append((in_moves, in_moves_sql_condition))
            // 
            // result = []
            // for moves, move_type_sql_condition in to_query:
            //     result.extend(self.env.execute_query(SQL("""
            //         SELECT move.id AS move_id,
            //                array_agg(duplicate_move.id) AS duplicate_ids
            //           FROM %(move_table_and_alias)s
            //           JOIN account_move AS duplicate_move
            //             ON move.company_id = duplicate_move.company_id
            //            AND move.id != duplicate_move.id
            //            AND duplicate_move.state IN %(matching_states)s
            //            AND move.move_type = duplicate_move.move_type
            //            AND (
            //                    move.commercial_partner_id = duplicate_move.commercial_partner_id
            //                    OR (move.commercial_partner_id IS NULL AND duplicate_move.state = 'draft')
            //                )
            //            AND (%(move_type_sql_condition)s)
            //          WHERE move.id IN %(moves)s
            //          GROUP BY move.id
            //         """,
            //         matching_states=tuple(matching_states),
            //         moves=tuple(moves.ids or [0]),
            //         move_table_and_alias=move_table_and_alias,
            //         move_type_sql_condition=move_type_sql_condition,
            //     )))
            // return {
            //     self.env['account.move'].browse(move_id): self.env['account.move'].browse(duplicate_ids)
            //     for move_id, duplicate_ids in result
            // }
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _fetch_duplicate_reference(self, matching_states=('draft', 'in_process')):
            // """ Retrieve move ids for possible duplicates of payments. Duplicates moves:
            // - Have the same partner_id, amount and date as the payment
            // - Are not reconciled
            // - Represent a credit in the same account receivable or a debit in the same account payable as the payment, or
            // - Represent a credit in outstanding receipts or debit in outstanding payments, so bank statement lines with an
            //  outstanding counterpart can be matched, or
            // - Are in the suspense account
            // """
            // # Does not perform unnecessary check if partner_id or amount are not set, nor if payment is posted
            // payments = self.filtered(lambda p: p.partner_id and p.amount and p.state != 'in_process')
            // if not payments:
            //     return {}
            // 
            // # Update tables involved in the query
            // used_fields = ("company_id", "partner_id", "date", "state", "amount", 'payment_type')
            // self.flush_model(used_fields)
            // 
            // payment_table_and_alias = SQL("account_payment AS payment")
            // if not self[0].id:  # if record is under creation/edition in UI, safely inject values in the query
            //     # Necessary since new record aren't searchable in the DB and record in edition aren't up to date yet
            //     values = {
            //         field_name: self._fields[field_name].convert_to_write(self[field_name], self) or None
            //         for field_name in used_fields
            //     }
            //     values["id"] = self._origin.id or 0
            //     # The amount total depends on the field line_ids and is calculated upon saving, we needed a way to get it even when the
            //     # invoices has not been saved yet.
            //     casted_values = SQL(', ').join(
            //         SQL("%s::%s", value, SQL.identifier(self._fields[field_name].column_type[0]))
            //         for field_name, value in values.items()
            //     )
            //     column_names = SQL(', ').join(SQL.identifier(field_name) for field_name in values)
            //     payment_table_and_alias = SQL("(VALUES (%s)) AS payment(%s)", casted_values, column_names)
            // 
            // query = SQL(
            //     """
            //         SELECT payment.id AS payment_id,
            //                ARRAY_AGG(DISTINCT duplicate_payment.id) AS duplicate_payment_ids
            //           FROM %(payment_table_and_alias)s
            //           JOIN account_payment AS duplicate_payment ON payment.id != duplicate_payment.id
            //                                                    AND payment.partner_id = duplicate_payment.partner_id
            //                                                    AND payment.company_id = duplicate_payment.company_id
            //                                                    AND payment.date = duplicate_payment.date
            //                                                    AND payment.payment_type = duplicate_payment.payment_type
            //                                                    AND payment.amount = duplicate_payment.amount
            //                                                    AND duplicate_payment.state IN %(matching_states)s
            //          WHERE payment.id = ANY(%(payments)s)
            //       GROUP BY payment.id
            //     """,
            //     payment_table_and_alias=payment_table_and_alias,
            //     matching_states=tuple(matching_states),
            //     payments=payments.ids or [0],
            // )
            // 
            // return {
            //     payment_id: self.env['account.payment'].browse(duplicate_ids)
            //     for payment_id, duplicate_ids in self.env.execute_query(query)
            // }
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string field_expr, object query) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _field_to_sql(self, alias: str, fname: str, query=None) -> SQL:
            // if fname == 'status_in_payment':
            //     return SQL(
            //         "CASE "
            //         f"WHEN {alias}.state = 'draft' THEN 'draft' "
            //         f"WHEN {alias}.state = 'cancel' THEN 'cancel' "
            //         f"ELSE {alias}.payment_state "
            //         "END"
            //     )
            // elif fname == 'move_sent_values':
            //     return SQL(
            //         "CASE "
            //         f"WHEN {alias}.is_move_sent THEN 'sent' "
            //         f"ELSE 'not_sent' "
            //         "END"
            //     )
            // return super()._field_to_sql(alias, fname, query=query)
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _field_to_sql(self, alias: str, field_expr: str, query: (Query | None) = None) -> SQL:
            // """This is required to search for the related fields of version_id as version_id is not stored"""
            // if field_expr == 'version_id':
            //     field_expr = 'current_version_id'
            // return super()._field_to_sql(alias, field_expr, query)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FieldWillChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals, object field_name) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _field_will_change(self, record, vals, field_name):
            // if field_name not in vals:
            //     return False
            // field = record._fields[field_name]
            // if field.type == 'many2one':
            //     return record[field_name].id != vals[field_name]
            // if field.type == 'many2many':
            //     current_ids = set(record[field_name].ids)
            //     after_write_ids = set(record.new({field_name: vals[field_name]})[field_name].ids)
            //     return current_ids != after_write_ids
            // if field.type == 'one2many':
            //     return True
            // if field.type == 'monetary' and record[field.get_currency_field(record)]:
            //     return not record[field.get_currency_field(record)].is_zero(record[field_name] - vals[field_name])
            // if field.type == 'float':
            //     record_value = field.convert_to_cache(record[field_name], record)
            //     to_write_value = field.convert_to_cache(vals[field_name], record)
            //     return record_value != to_write_value
            // return record[field_name] != vals[field_name]
            */
            return default;
        }

        public async Task<TEntity> FindAndSetPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _find_and_set_purchase_orders(self, po_references, partner_id, amount_total, from_ocr=False, timeout=10):
            // # hook to be used with purchase, so that vendor bills are sync/autocompleted with purchase orders
            // self.ensure_one()
            */
            return default;
        }

        public async Task<TEntity> ForceCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reason, object msg_subtype, object notify_responsibles) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _force_cancel(self, reason=None, msg_subtype='mail.mt_comment', notify_responsibles=True):
            // leaves = self.browse() if self.env.context.get(MODULE_UNINSTALL_FLAG) else self
            // if reason:
            //     model_description = self.env['ir.model']._get('hr.holidays').display_name
            //     for leave in leaves:
            //         body = self.env._(
            //             "The time off request has been cancelled for the following reason:%(reason)s",
            //             reason=Markup("<p>{reason}</p>").format(reason=reason)
            //         )
            //         leave.message_post(
            //             body=body,
            //             subtype_xmlid=msg_subtype
            //         )
            // 
            //         if not notify_responsibles:
            //             continue
            // 
            //         responsibles = self.env['res.partner']
            //         # manager
            //         if (leave.holiday_status_id.leave_validation_type == 'manager' and leave.state == 'validate') or (leave.holiday_status_id.leave_validation_type == 'both' and leave.state == 'validate1'):
            //             responsibles = leave.employee_id.leave_manager_id.partner_id
            //         # officer
            //         elif leave.holiday_status_id.leave_validation_type == 'hr' and leave.state == 'validate':
            //             responsibles = leave.holiday_status_id.responsible_ids.partner_id
            //         # both
            //         elif leave.holiday_status_id.leave_validation_type == 'both' and leave.state == 'validate':
            //             responsibles = leave.employee_id.leave_manager_id.partner_id
            //             responsibles |= leave.holiday_status_id.responsible_ids.partner_id
            // 
            //         if responsibles:
            //             body = self.env._(
            //                 "%(leave_name)s has been cancelled for the following reason: %(reason)s",
            //                 leave_name=leave.display_name,
            //                 reason=Markup("<blockquote>{reason}</blockquote>").format(reason=reason),
            //             )
            //             leave.message_notify(
            //                 partner_ids=responsibles.ids,
            //                 model_description=model_description,
            //                 subject=self.env._('Cancelled Time Off'),
            //                 body=body,
            //                 email_layout_xmlid="mail.mail_notification_layout",
            //                 subtitles=[leave.display_name],
            //             )
            // leave_sudo = self.sudo()
            // leave_sudo.state = "cancel"
            // leave_sudo.activity_update()
            // leave_sudo._post_leave_cancel()
            */
            return default;
        }

        public async Task<TEntity> GenerateAndSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_synchronous, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _generate_and_send(self, force_synchronous=True, allow_fallback_pdf=True, **custom_settings):
            // """ Generate the pdf and electronic format(s) for the current invoices and send them given default settings
            // (on partner or company) or given provided custom_settings.
            // :param force_synchronous: whether to process (as)synchronously (! only relevant for batch sending (multiple invoices))
            // :param allow_fallback_pdf:  In case of error when generating the documents for invoices, generate a
            //                             proforma PDF report instead.
            // :param custom_settings: custom settings to create the wizard (! only relevant for single sending (one invoice))
            // (Since default settings are use for batch sending.
            // If you are looking for something more flexible, directly call env[account.move.send]._generate_and_send_invoices method.)
            // """
            // if not self:
            //     return
            // if len(self) == 1:
            //     wizard = self.env['account.move.send.wizard'].with_context(
            //         active_model='account.move',
            //         active_ids=self.ids,
            //     ).create(custom_settings)
            //     wizard.action_send_and_print(allow_fallback_pdf=allow_fallback_pdf)
            // else:
            //     wizard = self.env['account.move.send.batch.wizard'].with_context(
            //         active_model='account.move',
            //         active_ids=self.ids,
            //     ).create({})
            //     wizard.action_send_and_print(force_synchronous=force_synchronous)
            // return wizard
            */
            return default;
        }

        public async Task<TEntity> GenerateJournalEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object write_off_line_vals, object force_balance, List<Guid> line_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _generate_journal_entry(self, write_off_line_vals=None, force_balance=None, line_ids=None):
            // need_move = self.filtered(lambda p: not p.move_id and p.outstanding_account_id)
            // assert len(self) == 1 or (not write_off_line_vals and not force_balance and not line_ids)
            // 
            // move_vals = [
            //     pay._generate_move_vals(write_off_line_vals, force_balance, line_ids)
            //     for pay in need_move
            // ]
            // moves = self.env['account.move'].create(move_vals)
            // for pay, move in zip(need_move, moves):
            //     pay.write({'move_id': move.id, 'state': 'in_process'})
            */
            return default;
        }

        public async Task<TEntity> GenerateMoveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object write_off_line_vals, object force_balance, List<Guid> line_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _generate_move_vals(self, write_off_line_vals=None, force_balance=None, line_ids=None):
            // """ Prepare the values needed to create a move for self. """
            // self.ensure_one()
            // return {
            //     'move_type': 'entry',
            //     'ref': self.memo,
            //     'date': self.date,
            //     'journal_id': self.journal_id.id,
            //     'company_id': self.company_id.id,
            //     'partner_id': self.partner_id.id,
            //     'currency_id': self.currency_id.id,
            //     'partner_bank_id': self.partner_bank_id.id,
            //     'line_ids': line_ids or [
            //         Command.create(line_vals)
            //         for line_vals in self._prepare_move_line_default_vals(
            //             write_off_line_vals=write_off_line_vals,
            //             force_balance=force_balance,
            //         )
            //     ],
            //     'origin_payment_id': self.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> GeneratePortalPaymentQrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _generate_portal_payment_qr(self):
            // # This method is designed to prevent traceback.
            // # Scenario: A traceback occurs when `account.payment` is not installed, and the user attempts to
            // # preview or print the invoice.
            // self.ensure_one()
            // return None
            */
            return default;
        }

        public async Task<TEntity> GenerateQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object silent_errors) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _generate_qr_code(self, silent_errors=False):
            // """ Generates and returns a QR-code generation URL for this invoice,
            // raising an error message if something is misconfigured.
            // 
            // The chosen QR generation method is the one set in qr_method field if there is one,
            // or the first eligible one found. If this search had to be performed and
            // and eligible method was found, qr_method field is set to this method before
            // returning the URL. If no eligible QR method could be found, we return None.
            // """
            // self.ensure_one()
            // 
            // if not self.display_qr_code:
            //     return None
            // 
            // qr_code_method = self.qr_code_method
            // if qr_code_method:
            //     # If the user set a qr code generator manually, we check that we can use it
            //     error_msg = self.partner_bank_id._get_error_messages_for_qr(self.qr_code_method, self.partner_id, self.currency_id)
            //     if error_msg:
            //         raise UserError(error_msg)
            // else:
            //     # Else we find one that's eligible and assign it to the invoice
            //     for candidate_method, _candidate_name in self.env['res.partner.bank'].get_available_qr_methods_in_sequence():
            //         error_msg = self.partner_bank_id._get_error_messages_for_qr(candidate_method, self.partner_id, self.currency_id)
            //         if not error_msg:
            //             qr_code_method = candidate_method
            //             break
            // 
            // if not qr_code_method:
            //     # No eligible method could be found; we can't generate the QR-code
            //     return None
            // 
            // unstruct_ref = self.payment_reference or self.name
            // rslt = self.partner_bank_id.build_qr_code_base64(self.amount_residual, unstruct_ref, self.payment_reference, self.currency_id, self.partner_id, qr_code_method, silent_errors=silent_errors)
            // 
            // # We only set qr_code_method after generating the url; otherwise, it
            // # could be set even in case of a failure in the QR code generation
            // # (which would change the field, but not refresh UI, making the displayed data inconsistent with db)
            // self.qr_code_method = qr_code_method
            // 
            // return rslt
            */
            return default;
        }

        public async Task<TEntity> GenerateRandomBarcodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def generate_random_barcode(self):
            // for employee in self:
            //     employee.barcode = '041'+"".join(choice(digits) for i in range(9))
            */
            return default;
        }

        public async Task<TEntity> GetAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax, object lock_dates) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_accounting_date(self, invoice_date, has_tax, lock_dates=None):
            // """Get correct accounting date for previous periods, taking tax lock date and affected journal into account.
            // When registering an invoice in the past, we still want the sequence to be increasing.
            // We then take the last day of the period, depending on the sequence format.
            // 
            // If there is a tax lock date and there are taxes involved, we register the invoice at the
            // last date of the first open period.
            // :param invoice_date (datetime.date): The invoice date
            // :param has_tax (bool): Iff any taxes are involved in the lines of the invoice
            // :param lock_dates: Like result from `_get_violated_lock_dates`;
            //                    Can be used to avoid recomputing them in case they are already known.
            // :rtype: datetime.date
            // """
            // self.ensure_one()
            // lock_dates = lock_dates or self._get_violated_lock_dates(invoice_date, has_tax)
            // today = fields.Date.context_today(self)
            // highest_name = self.highest_name or self._get_last_sequence(relaxed=True)
            // number_reset = self._deduce_sequence_number_reset(highest_name)
            // if lock_dates:
            //     invoice_date = lock_dates[-1][0] + timedelta(days=1)
            // if self.is_sale_document(include_receipts=True):
            //     if lock_dates:
            //         if not highest_name or number_reset == 'month':
            //             return min(today, date_utils.get_month(invoice_date)[1])
            //         elif number_reset == 'year':
            //             return min(today, date_utils.end_of(invoice_date, 'year'))
            // else:
            //     if not highest_name or number_reset in ('month', 'year_range_month'):
            //         if (today.year, today.month) > (invoice_date.year, invoice_date.month):
            //             return date_utils.get_month(invoice_date)[1]
            //         else:
            //             return max(invoice_date, today)
            //     elif number_reset == 'year':
            //         if today.year > invoice_date.year:
            //             return date(invoice_date.year, 12, 31)
            //         else:
            //             return max(invoice_date, today)
            // return invoice_date
            */
            return default;
        }

        public async Task<TEntity> GetAccountingDateSourceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_accounting_date_source(self):
            // self.ensure_one()
            // return self.invoice_date or self.date
            */
            return default;
        }

        public async Task<TEntity> GetAccountsWithFixedAllocationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_accounts_with_fixed_allocations(self):
            // self.ensure_one()
            // return self.bank_account_ids.filtered(
            //     lambda a: not self.salary_distribution.get(str(a.id), {}).get('amount_is_percentage', True)
            // )
            */
            return default;
        }

        public async Task<TEntity> GetActionAddFromCatalogExtraContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // res = super()._get_action_add_from_catalog_extra_context()
            // if self.is_purchase_document() and self.partner_id:
            //     res['search_default_seller_ids'] = self.partner_id.name
            // 
            // res['product_catalog_currency_id'] = self.currency_id.id
            // res['product_catalog_digits'] = self.line_ids._fields['price_unit'].get_digits(self.env)
            // res['show_sections'] = bool(self.id)
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetActionWithBaseDocumentLayoutConfiguratorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_action) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_action_with_base_document_layout_configurator(self, report_action):
            // if (
            //     self.env.is_admin()
            //     and not self.env.company.external_report_layout_id
            //     and not self.env.context.get('discard_logo_check')
            // ):
            //     report_action = self.env['ir.actions.report']._action_configure_external_report_layout(
            //         report_action,
            //         "account.action_base_document_layout_configurator",
            //     )
            //     report_action['context']['default_from_invoice'] = self.move_type == 'out_invoice'
            // return report_action
            */
            return default;
        }

        public async Task<TEntity> GetAgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_age(self, target_date=None):
            // self.ensure_one()
            // if target_date is None:
            //     target_date = fields.Date.context_today(self.env.user)
            // return relativedelta(target_date, self.birthday).years if self.birthday else 0
            */
            return default;
        }

        public async Task<TEntity> GetAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_alerts(self):
            // self.ensure_one()
            // alerts = {}
            // has_account_group = self.env.user.has_groups('account.group_account_readonly,account.group_account_invoice')
            // 
            // if self.state == 'draft':
            //     if has_account_group and self.tax_lock_date_message:
            //         alerts['account_tax_lock_date'] = {
            //             'level': 'warning',
            //             'message': self.tax_lock_date_message,
            //         }
            //     if self.auto_post == 'at_date':
            //         alerts['account_auto_post_at_date'] = {
            //             'level': 'info',
            //             'message': _("This move is configured to be posted automatically at the accounting date: %s.", self.date),
            //         }
            //     if self.auto_post in ('yearly', 'quarterly', 'monthly'):
            //         message = _(
            //             "%(auto_post_name)s auto-posting enabled. Next accounting date: %(move_date)s.",
            //             auto_post_name=self.auto_post,
            //             move_date=self.date,
            //         )
            //         if self.auto_post_until:
            //             message += " "
            //             message += _("The recurrence will end on %s (included).", self.auto_post_until)
            //         alerts['account_auto_post_on_period'] = {
            //             'level': 'info',
            //             'message': message,
            //         }
            //     if (
            //         self.is_purchase_document(include_receipts=True)
            //         and (zero_lines := self.invoice_line_ids.filtered(lambda line: line.price_total == 0))
            //         and len(zero_lines) >= 2
            //     ):
            //         alerts['account_remove_empty_lines'] = {
            //             'level': 'info',
            //             'message': _("We've noticed some empty lines on your invoice."),
            //             'action_text': _("Remove empty lines"),
            //             'action_call': ('account.move.line', 'unlink', zero_lines.ids),
            //         }
            // 
            // if self.is_being_sent:
            //     alerts['account_is_being_sent'] = {
            //         'level': 'info',
            //         'message': _("This invoice is being sent in the background."),
            //     }
            // if has_account_group and self.partner_credit_warning:
            //     alerts['account_partner_credit_warning'] = {
            //         'level': 'warning',
            //         'message': self.partner_credit_warning,
            //     }
            // if self.abnormal_amount_warning:
            //     alerts['account_abnormal_amount_warning'] = {
            //         'level': 'warning',
            //         'message': self.abnormal_amount_warning,
            //     }
            // if self.abnormal_date_warning:
            //     alerts['account_abnormal_date_warning'] = {
            //         'level': 'warning',
            //         'message': self.abnormal_date_warning,
            //     }
            // 
            // return alerts
            */
            return default;
        }

        public async Task<TEntity> GetAllContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_all_contract_dates(self):
            // """
            // Return a list of intervals (date_from, date_to) where the employee is in contract.
            // For a permanent contract, the interval is (date_from, False).
            // """
            // self.ensure_one()
            // return self.env['hr.version']._read_group(
            //     [('employee_id', '=', self.id), ('contract_date_start', '!=', False)],
            //     ['contract_date_start:day', 'contract_date_end:day'])
            */
            return default;
        }

        public async Task<TEntity> GetAllReconciledInvoicePartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_all_reconciled_invoice_partials(self):
            // self.ensure_one()
            // reconciled_lines = self.line_ids.filtered(lambda line: line.account_id.account_type in ('asset_receivable', 'liability_payable'))
            // if not reconciled_lines.ids:
            //     return {}
            // 
            // self.env['account.partial.reconcile'].flush_model([
            //     'credit_amount_currency', 'credit_move_id', 'debit_amount_currency',
            //     'debit_move_id', 'exchange_move_id',
            // ])
            // sql = SQL('''
            //     SELECT
            //         part.id,
            //         part.exchange_move_id,
            //         part.debit_amount_currency AS amount,
            //         part.credit_move_id AS counterpart_line_id
            //     FROM account_partial_reconcile part
            //     WHERE part.debit_move_id IN %(line_ids)s
            // 
            //     UNION ALL
            // 
            //     SELECT
            //         part.id,
            //         part.exchange_move_id,
            //         part.credit_amount_currency AS amount,
            //         part.debit_move_id AS counterpart_line_id
            //     FROM account_partial_reconcile part
            //     WHERE part.credit_move_id IN %(line_ids)s
            // ''', line_ids=tuple(reconciled_lines.ids))
            // 
            // partial_values_list = []
            // counterpart_line_ids = set()
            // exchange_move_ids = set()
            // for values in self.env.execute_query_dict(sql):
            //     partial_values_list.append({
            //         'aml_id': values['counterpart_line_id'],
            //         'partial_id': values['id'],
            //         'amount': values['amount'],
            //         'currency': self.currency_id,
            //     })
            //     counterpart_line_ids.add(values['counterpart_line_id'])
            //     if values['exchange_move_id']:
            //         exchange_move_ids.add(values['exchange_move_id'])
            // 
            // if exchange_move_ids:
            //     self.env['account.move.line'].flush_model(['move_id'])
            //     sql = SQL('''
            //         SELECT
            //             part.id,
            //             part.credit_move_id AS counterpart_line_id
            //         FROM account_partial_reconcile part
            //         JOIN account_move_line credit_line ON credit_line.id = part.credit_move_id
            //         WHERE credit_line.move_id IN %(exchange_move_ids)s AND part.debit_move_id IN %(counterpart_line_ids)s
            // 
            //         UNION ALL
            // 
            //         SELECT
            //             part.id,
            //             part.debit_move_id AS counterpart_line_id
            //         FROM account_partial_reconcile part
            //         JOIN account_move_line debit_line ON debit_line.id = part.debit_move_id
            //         WHERE debit_line.move_id IN %(exchange_move_ids)s AND part.credit_move_id IN %(counterpart_line_ids)s
            //     ''', exchange_move_ids=tuple(exchange_move_ids), counterpart_line_ids=tuple(counterpart_line_ids))
            // 
            //     for part_id, line_ids in self.env.execute_query(sql):
            //         counterpart_line_ids.add(line_ids)
            //         partial_values_list.append({
            //             'aml_id': line_ids,
            //             'partial_id': part_id,
            //             'currency': self.company_id.currency_id,
            //         })
            // 
            // counterpart_lines = {x.id: x for x in self.env['account.move.line'].browse(counterpart_line_ids)}
            // for partial_values in partial_values_list:
            //     partial_values['aml'] = counterpart_lines[partial_values['aml_id']]
            //     partial_values['is_exchange'] = partial_values['aml'].move_id.id in exchange_move_ids
            //     if partial_values['is_exchange']:
            //         partial_values['amount'] = abs(partial_values['aml'].balance)
            // 
            // return partial_values_list
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_all_versions_with_contract_overlap_with_period(self, date_from, date_to):
            // """
            // Returns the versions of all employees between date_from and date_to
            // that have at least 1 day in contract during that period
            // """
            // all_employees = self.search(['|', ('active', '=', True), ('active', '=', False)])
            // return all_employees._get_versions_with_contract_overlap_with_period(date_from, date_to)
            */
            return default;
        }

        public async Task<TEntity> GetAmlDefaultDisplayNameListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_aml_default_display_name_list(self):
            // """ Hook allowing custom values when constructing the default label to set on the journal items.
            // 
            // :return: A list of terms to concatenate all together. E.g.
            //     [
            //         ('label', "Greg's Card"),
            //         ('sep', ": "),
            //         ('memo', "New Computer"),
            //     ]
            // """
            // self.ensure_one()
            // label = self.payment_method_line_id.name if self.payment_method_line_id else _("No Payment Method")
            // 
            // if self.memo:
            //     return [
            //         ('label', label),
            //         ('sep', ": "),
            //         ('memo', self.memo),
            //     ]
            // return [
            //     ('label', label),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_attachment_number(self):
            // read_group_res = self.env['ir.attachment']._read_group(
            //     [('res_model', '=', 'hr.applicant'), ('res_id', 'in', self.ids)],
            //     ['res_id'], ['__count'])
            // attach_data = dict(read_group_res)
            // for record in self:
            //     record.attachment_number = attach_data.get(record.id, 0)
            */
            return default;
        }

        public async Task<TEntity> GetAutomaticBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_automatic_balancing_account(self):
            // """ Small helper for special cases where we want to auto balance a move with a specific account. """
            // self.ensure_one()
            // if self.journal_id.default_account_id:
            //     return self.journal_id.default_account_id.id
            // return self.company_id.account_journal_suspense_account_id.id
            */
            return default;
        }

        public async Task<TEntity> GetAvailableActionReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_invoice_report) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_available_action_reports(self, is_invoice_report=True):
            // domain = [('model', '=', 'account.move')]
            // 
            // if is_invoice_report:
            //     domain += [('is_invoice_report', '=', 'True')]
            // 
            // model_reports = self.env['ir.actions.report'].search(domain)
            // 
            // available_reports = model_reports.filtered(
            //     lambda model_template: len(self.filtered_domain(ast.literal_eval(model_template.domain or '[]'))) == len(self)
            // )
            // 
            // return available_reports
            */
            return default;
        }

        public async Task<TEntity> GetAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_available_invoice_template_pdf_report_ids(self):
            // """
            // Helper to get available invoice template pdf reports
            // """
            // moves = self
            // 
            // for move_type in ['out_invoice', 'out_refund', 'out_receipt']:
            //     moves += self.new({'move_type': move_type})
            // 
            // available_reports = moves._get_available_action_reports()
            // 
            // if not available_reports:
            //     raise UserError(_("There is no template that applies to invoices."))
            // 
            // return available_reports
            */
            return default;
        }

        public async Task<TEntity> GetAvatarCardDataAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_avatar_card_data(self, fields):
            // return self.read(fields)
            */
            return default;
        }

        public async Task<TEntity> GetBankAccountSalaryAllocationAsync<TEntity>(IEnumerable<TEntity> entities, Guid account_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_bank_account_salary_allocation(self, account_id):
            // ba_info = self.salary_distribution.get(str(account_id), {})
            // return ba_info.get('amount', 0), ba_info.get('amount_is_percentage')
            */
            return default;
        }

        public async Task<TEntity> GetBaseAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> GetCalendarAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_attendances(self, date_from, date_to):
            // self.ensure_one()
            // valid_versions = self.sudo()._get_versions_with_contract_overlap_with_period(date_from.date(), date_to.date())
            // employee_tz = timezone(self.tz) if self.tz else None
            // if not valid_versions:
            //     calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //     return calendar.with_context(employee_timezone=employee_tz).get_work_duration_data(
            //         date_from,
            //         date_to,
            //         domain=[('company_id', 'in', [False, self.company_id.id])])
            // duration_data = {'days': 0, 'hours': 0}
            // for version in valid_versions:
            //     version_start = datetime.combine(version.date_start, time.min, employee_tz)
            //     version_end = datetime.combine(version.date_end or date.max, time.max, employee_tz)
            //     calendar = version.resource_calendar_id or version.company_id.resource_calendar_id
            //     version_duration_data = calendar\
            //         .with_context(employee_timezone=employee_tz)\
            //         .get_work_duration_data(
            //             max(date_from, version_start),
            //             min(date_to, version_end),
            //             domain=[('company_id', 'in', [False, version.company_id.id])])
            //     duration_data['days'] += version_duration_data['days']
            //     duration_data['hours'] += version_duration_data['hours']
            // return duration_data
            */
            return default;
        }

        public async Task<TEntity> GetCalendarPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object check_contract) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_periods(self, start, stop, check_contract=True):
            // """
            // :param datetime start: the start of the period
            // :param datetime stop: the stop of the period
            // """
            // return self.sudo()._get_version_periods(start, stop, 'resource_calendar_id', check_contract)
            */
            return default;
        }

        public async Task<TEntity> GetCalendarTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dt) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_tz_batch(self, dt=None):
            // """ Return a mapping { employee id : employee's effective schedule's (at dt) timezone }
            // """
            // employees_by_id = self.grouped('id')
            // if not dt:
            //     calendars = self._get_calendars()
            //     return {
            //         emp_id: calendar.sudo().tz or employees_by_id[emp_id].tz \
            //             for emp_id, calendar in calendars.items()
            //     }
            // 
            // employees_by_tz = self.grouped(lambda emp: emp._get_tz())
            // 
            // employee_timezones = {}
            // for tz, employee_ids in employees_by_tz.items():
            //     date_at = timezone(tz).localize(dt).date()
            //     calendars = self._get_calendars(date_at)
            //     employee_timezones |= {
            //         emp_id: cal.sudo().tz or employees_by_id[emp_id].tz \
            //             for emp_id, cal in calendars.items()
            //     }
            // return employee_timezones
            */
            return default;
        }

        public async Task<TEntity> GetCalendarsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendars(self, date_from=None):
            // res = super()._get_calendars(date_from=date_from)
            // if not date_from:
            //     return res
            // 
            // date_from = fields.Date.to_date(date_from)
            // for employee in self:
            //     employee_versions_sudo = employee.sudo().version_ids.filtered(lambda v: v._is_in_contract(date_from))
            //     if employee_versions_sudo:
            //         res[employee.id] = employee_versions_sudo[0].resource_calendar_id.sudo(False)
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetCannotApproveReasonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        [ApiModel]
        public async Task<TEntity> GetCertificateSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_certificate_selection(self):
            // return [
            //     ('graduate', self.env._('Graduate')),
            //     ('bachelor', self.env._('Bachelor')),
            //     ('master', self.env._('Master')),
            //     ('doctor', self.env._('Doctor')),
            //     ('other', self.env._('Other')),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetChainInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_chain_info(self, force_hash=False, include_pre_last_hash=False, early_stop=False):
            // """All records in `self` must belong to the same journal and sequence_prefix
            // """
            // if not self:
            //     return False
            // 
            // # Delegate to the database, instead of max(self, key=lambda m: m.sequence_number)
            // last_move_in_chain = (
            //     self.env['account.move']
            //     .sudo()
            //     .search_fetch(
            //         domain=[('id', 'in', self.ids)],
            //         field_names=[
            //             'sequence_prefix',
            //             'sequence_number',
            //             'journal_id',
            //             # Pre-emptive fetching for `_is_move_restricted`
            //             'state',
            //             'restrict_mode_hash_table',
            //         ],
            //         order='sequence_number desc',
            //         limit=1,
            //     )
            // )
            // journal = last_move_in_chain.journal_id
            // if not self._is_move_restricted(last_move_in_chain, force_hash=force_hash):
            //     return False
            // 
            // common_domain = [
            //     ('journal_id', '=', journal.id),
            //     ('sequence_prefix', '=', last_move_in_chain.sequence_prefix),
            // ]
            // last_move_hashed = self.env['account.move'].search_fetch([
            //     *common_domain,
            //     ('inalterable_hash', '!=', False),
            // ], ['sequence_number', 'inalterable_hash'], order='sequence_number desc', limit=1)
            // 
            // domain = self.env['account.move']._get_move_hash_domain([
            //     *common_domain,
            //     ('sequence_number', '<=', last_move_in_chain.sequence_number),
            //     ('inalterable_hash', '=', False),
            // ], force_hash=True)
            // if last_move_hashed and not include_pre_last_hash:
            //     # Hash moves only after the last hashed move, not the ones that may have been posted before the journal was set on restrict mode
            //     domain &= Domain('sequence_number', '>', last_move_hashed.sequence_number)
            // 
            // # On the accounting dashboard, we are only interested on whether there are documents to hash or not
            // # so we can stop the computation early if we find at least one document to hash
            // if early_stop:
            //     return self.env['account.move'].sudo().search_count(domain, limit=1)
            // moves_to_hash = self.env['account.move'].sudo().search_fetch(domain, ['sequence_number'], order='sequence_number')
            // info = {
            //     'previous_hash': last_move_hashed.inalterable_hash,
            //     'last_move_hashed': last_move_hashed,
            // }
            // if self.env.context.get('chain_info_warnings', True):
            //     warnings = set()
            //     if moves_to_hash:
            //         # gap warning
            //         if last_move_hashed:
            //             first = last_move_hashed.sequence_number
            //             difference = len(moves_to_hash)
            //         else:
            //             first = moves_to_hash[0].sequence_number
            //             difference = len(moves_to_hash) - 1
            //         last = moves_to_hash[-1].sequence_number
            //         if first + difference != last:
            //             warnings.add('gap')
            // 
            //         # unreconciled warning
            //         has_unreconciled = bool(self.env['account.bank.statement.line'].search_count([
            //             ('move_id', 'in', moves_to_hash.ids),
            //             ('is_reconciled', '=', False),
            //         ], limit=1))
            //         if has_unreconciled:
            //             warnings.add('unreconciled')
            //     else:
            //         warnings.add('no_document')
            // 
            //     info['warnings'] = warnings
            // 
            // moves = moves_to_hash.sudo(False)
            // info.update({
            //     'moves': moves,
            //     'remaining_moves': self - moves,
            // })
            // return info
            */
            return default;
        }

        public async Task<TEntity> GetChainsToHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object raise_if_gap, object raise_if_no_document, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_chains_to_hash(self, force_hash=False, raise_if_gap=True, raise_if_no_document=True, include_pre_last_hash=False, early_stop=False):
            // """
            // From a recordset of moves, retrieve the chains of moves that need to be hashed by taking
            // into account the last move of each chain of the recordset.
            // So if we have INV/1, INV/2, INV/3, INV4 that are not hashed yet in the database
            // but self contains INV/2, INV/3, we will return INV/1, INV/2 and INV/3. Not INV/4.
            // :param force_hash: if True, we'll check all moves posted, independently of journal settings
            // :param raise_if_gap: if True, we'll raise an error if a gap is detected in the sequence
            // :param raise_if_no_document: if True, we'll raise an error if no document needs to be hashed
            // :param include_pre_last_hash: if True, we'll include the moves not hashed that are previous to the last hashed move
            // :param early_stop: if True, we'll stop the computation as soon as we find at least one document to hash
            // :return bool when early_stop else a list of dictionaries (each dict generated by `_get_chain_info`)
            // """
            // res = []
            // for journal, journal_moves in self.grouped('journal_id').items():
            //     for chain_moves in journal_moves.grouped('sequence_prefix').values():
            //         chain_info = chain_moves._get_chain_info(
            //             force_hash=force_hash, include_pre_last_hash=include_pre_last_hash, early_stop=early_stop
            //         )
            // 
            //         if not chain_info:
            //             continue
            //         if early_stop:
            //             return True
            //         chain_info['journal_restrict_mode'] = journal.restrict_mode_hash_table
            // 
            //         if 'unreconciled' in chain_info['warnings']:
            //             raise UserError(_("An error occurred when computing the inalterability. All entries have to be reconciled."))
            // 
            //         if raise_if_no_document and 'no_document' in chain_info['warnings']:
            //             raise UserError(_(
            //                 "This move could not be locked either because "
            //                 "some move with the same sequence prefix has a higher number. You may need to resequence it."
            //             ))
            //         if raise_if_gap and 'gap' in chain_info['warnings']:
            //             raise UserError(_(
            //                 "An error occurred when computing the inalterability. A gap has been detected in the sequence."
            //             ))
            // 
            //         res.append(chain_info)
            // if early_stop:
            //     return False
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_contract_dates(self, date):
            // """
            // Return a tuple (date_from, date_to) of the contract at the date given.
            // (False, False) if the employee is not in contract at that date.
            // """
            // self.ensure_one()
            // for date_from, date_to in self._get_all_contract_dates():
            //     if date_from <= date and (date_to is False or date_to >= date):
            //         return date_from, date_to
            // return False, False
            */
            return default;
        }

        public async Task<TEntity> GetContractVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object domain) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_contract_versions(self, date_start=None, date_end=None, domain=None):
            // """
            // Retrieves contract versions for employees within the specified date range and
            // domain. The function constructs a dynamic domain to filter contracts based on
            // the provided arguments and retrieves grouped results. The grouping ensures
            // organization by employee and date, and the results are stored in a structured
            // format for ease of use.
            // 
            // Args:
            //     date_start (datetime.date | None): The start date for filtering contracts.
            //     date_end (datetime.date | None): The end date for filtering contracts.
            //     domain (list | None): Additional domain constraints for filtering.
            // 
            // Returns:
            //     dict: A dictionary where keys are employee IDs and values are lists of
            //           contract version records organized by contract date start and date
            //           range.
            // """
            // version_domain = Domain('contract_date_start', '!=', False)
            // if self.ids:
            //     version_domain &= Domain('employee_id', 'in', self.ids)
            // elif not any(self._ids):  # onchange
            //     version_domain &= Domain('employee_id', 'in', self._origin.ids)
            // if date_start:
            //     version_domain &= Domain('contract_date_end', '=', False) | Domain('contract_date_end', '>=', date_start)
            // if date_end:
            //     version_domain &= Domain('contract_date_start', '<=', date_end)
            // if domain:
            //     version_domain &= domain
            // all_versions = self.env['hr.version']._read_group(
            //     domain=version_domain,
            //     groupby=['employee_id', 'date_version:day'],
            //     aggregates=['id:recordset'],
            // )
            // contract_versions_by_employee = defaultdict(lambda: defaultdict(lambda: self.env["hr.version"]))
            // for employee, _date_version, version in all_versions:
            //     first_version = next(iter(version), version)
            //     contract_versions_by_employee[employee.id][first_version.contract_date_start] |= version
            // return contract_versions_by_employee
            */
            return default;
        }

        public async Task<TEntity> GetContractsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object use_latest_version, object domain) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_contracts(self, date_start=None, date_end=None, use_latest_version=True, domain=None):
            // """
            // Retrieve the contracts for employees within a specified date range and based
            // on specified criteria, such as domain filtering and version selection.
            // 
            // This method is used to collect and organize employee contracts based on their
            // versions, date ranges, and other specified options. The resulting contracts are
            // grouped by employee, and their selection logic depends on whether the latest
            // version should be used or not. It supports flexibility in contract retrieval by
            // allowing optional filters for date range and domain.
            // 
            // Args:
            //     date_start (Optional[datetime.date]): The start date to filter the contracts
            //         by. If provided, only contract versions <= this date are considered
            //         based on the selection logic.
            //     date_end (Optional[datetime.date]): The end date to filter the contracts by.
            //         Only contract versions within the range will be retrieved. Defaults to
            //         None if not specified.
            //     domain (Optional[dict]): A dictionary representing additional filters or
            //         constraints to apply to the contract versions retrieved. Defaults to
            //         None.
            //     use_latest_version (bool): Indicates whether to retrieve the version
            //     effective at the end of the contract (or before the date_end) for each employee (True) or
            //     at the start of the contract (before the date_start) (False). Defaults to True.
            // 
            // Returns:
            //     collections.defaultdict: A dictionary mapping each employee's identifier
            //     (employee.id) to a set of their corresponding contracts. Each set contains
            //     version records retrieved and filtered based on the specified criteria.
            // """
            // contract_versions_by_employee = self._get_contract_versions(date_start, date_end, domain)
            // contracts_by_employee = defaultdict(lambda: self.env["hr.version"])
            // for employee_id in contract_versions_by_employee:
            //     for contract_versions in contract_versions_by_employee[employee_id].values():
            //         effective_date = date_end if use_latest_version else date_start
            //         if use_latest_version:
            //             if effective_date:
            //                 correct_versions = contract_versions.filtered(lambda v: v.date_version <= effective_date)
            //                 contracts_by_employee[employee_id] |= correct_versions[-1] if correct_versions else contract_versions[0]
            //             else:
            //                 contracts_by_employee[employee_id] |= contract_versions[-1] if use_latest_version else contract_versions[0]
            // return contracts_by_employee
            */
            return default;
        }

        public async Task<TEntity> GetCopyMessageContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_copy_message_content(self, default):
            // """Hook method to customize the message content when copying a move.
            // This method can be overridden by other modules to add custom logic.
            // :param default: The default values dict passed to copy method
            // :return: The message content string
            // """
            // return _('This entry has been reversed from %s', self._get_html_link()) if default.get('reversed_entry_id') else _('This entry has been duplicated from %s', self._get_html_link())
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid to_currency_id, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_currency_rate(self, company_id, to_currency_id, date):
            // company = self.env['res.company'].browse(company_id)
            // to_currency = self.env['res.currency'].browse(to_currency_id)
            // 
            // return self.env['res.currency']._get_conversion_rate(
            //     from_currency=company.currency_id,
            //     to_currency=to_currency,
            //     company=company,
            //     date=date,
            // )
            */
            return default;
        }

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_customer_information(self):
            // email_keys_to_values = super()._get_customer_information()
            // 
            // for applicant in self:
            //     email_key = tools.email_normalize(applicant.email_from) or applicant.email_from
            //     # do not fill Falsy with random data, unless monorecord (= always correct)
            //     if not email_key and len(self) > 1:
            //         continue
            //     email_keys_to_values.setdefault(email_key, {}).update({
            //         'name': applicant.partner_name or tools.parse_contact_from_email(applicant.email_from)[0] or applicant.email_from,
            //         'phone': applicant.partner_phone,
            //     })
            // return email_keys_to_values
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultReadFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_default_read_fields(self):
            // weirdos = {'needed_terms', 'quick_encoding_vals', 'payment_term_details'}
            // return [fname for fname in self.fields_get(attributes=()) if fname not in weirdos]
            */
            return default;
        }

        public async Task<TEntity> GetDefaultResponsibleForApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> GetDepartureDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_departure_date(self):
            // # Primarily used in the archive wizard
            // # to pick a good default for the departure date
            // self.ensure_one()
            // if self.date_end and self.date_end < fields.Date.today():
            //     return self.departure_date
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetDiscountAllocationAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_discount_allocation_account(self):
            // if self.is_sale_document(include_receipts=True) and self.company_id.account_discount_expense_allocation_id:
            //     return self.company_id.account_discount_expense_allocation_id
            // if self.is_purchase_document(include_receipts=True) and self.company_id.account_discount_income_allocation_id:
            //     return self.company_id.account_discount_income_allocation_id
            // return None
            */
            return default;
        }

        public async Task<TEntity> GetDurationFromTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object trackings) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_duration_from_tracking(self, trackings):
            // json = super()._get_duration_from_tracking(trackings)
            // now = datetime.now()
            // for applicant in self:
            //     if applicant.refuse_reason_id and applicant.refuse_date:
            //         json[applicant.stage_id.id] -= (now - applicant.refuse_date).total_seconds()
            // return json
            */
            return default;
        }

        public async Task<TEntity> GetDurationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object check_leave_type, object resource_calendar) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_durations(self, check_leave_type=True, resource_calendar=None):
            // """
            // This method is factored out into a separate method from
            // _compute_duration so it can be hooked and called without necessarily
            // modifying the fields and triggering more computes of fields that
            // depend on number_of_hours or number_of_days.
            // """
            // result = {}
            // employee_leaves = self.filtered('employee_id')
            // employees_by_dates_calendar = defaultdict(lambda: self.env['hr.employee'])
            // for leave in employee_leaves:
            //     if not leave.date_from or not leave.date_to:
            //         continue
            //     employees_by_dates_calendar[(leave.date_from, leave.date_to, leave.holiday_status_id.include_public_holidays_in_duration, resource_calendar or leave.resource_calendar_id)] += leave.employee_id
            // # We force the company in the domain as we are more than likely in a compute_sudo
            // domain = [('time_type', '=', 'leave'),
            //           ('company_id', 'in', self.env.companies.ids + self.env.context.get('allowed_company_ids', [])),
            //           # When searching for resource leave intervals, we exclude the one that
            //           # is related to the leave we're currently trying to compute for.
            //           '|', ('holiday_id', '=', False), ('holiday_id', 'not in', employee_leaves.ids)]
            // # Precompute values in batch for performance purposes
            // work_time_per_day_mapped = {
            //     (date_from, date_to, include_public_holidays_in_duration, calendar): employees.with_context(
            //             compute_leaves=not include_public_holidays_in_duration)._list_work_time_per_day(date_from, date_to, domain=domain, calendar=calendar)
            //     for (date_from, date_to, include_public_holidays_in_duration, calendar), employees in employees_by_dates_calendar.items()
            // }
            // work_days_data_mapped = {
            //     (date_from, date_to, include_public_holidays_in_duration, calendar): employees._get_work_days_data_batch(date_from, date_to, compute_leaves=not include_public_holidays_in_duration, domain=domain, calendar=calendar)
            //     for (date_from, date_to, include_public_holidays_in_duration, calendar), employees in employees_by_dates_calendar.items()
            // }
            // for leave in self:
            //     calendar = resource_calendar or leave.resource_calendar_id
            //     if not leave.date_from or not leave.date_to or (not calendar and not leave.employee_id):
            //         result[leave.id] = (0, 0)
            //         continue
            //     hours, days = (0, 0)
            //     if leave.employee_id:
            //         # For flexible employees, if it's a single day leave, we force it to the real duration since the virtual intervals might not match reality on that day, especially for custom hours
            //         # sudo as is_flexible is on version model and employee does not have access to it.
            //         if leave.employee_id.sudo().is_flexible and leave.request_date_to == leave.request_date_from:
            //             public_holidays = self.env['resource.calendar.leaves'].search([
            //                 ('resource_id', '=', False),
            //                 ('date_from', '<', leave.date_to),
            //                 ('date_to', '>', leave.date_from),
            //                 ('calendar_id', 'in', [False, calendar.id]),
            //                 ('company_id', '=', leave.company_id.id)
            //             ])
            //             if public_holidays:
            //                 public_holidays_intervals = Intervals([(ph.date_from, ph.date_to, ph) for ph in public_holidays])
            //                 leave_intervals = Intervals([(leave.date_from, leave.date_to, leave)])
            //                 real_leave_intervals = leave_intervals - public_holidays_intervals
            //                 hours = 0
            //                 for start, stop, meta in real_leave_intervals:
            //                     hours += (stop - start).total_seconds() / 3600
            //             else:
            //                 hours = (leave.date_to - leave.date_from).total_seconds() / 3600
            //             if not leave.request_unit_hours and not public_holidays:
            //                 days = 1 if not leave.request_unit_half or leave.request_date_from_period != leave.request_date_to_period else 0.5
            //             else:
            //                 days = hours / 24
            //         elif leave.leave_type_request_unit == 'day' and check_leave_type:
            //             # list of tuples (day, hours)
            //             work_time_per_day_list = work_time_per_day_mapped[leave.date_from, leave.date_to, leave.holiday_status_id.include_public_holidays_in_duration, calendar][leave.employee_id.id]
            //             days = len(work_time_per_day_list)
            //             hours = sum(map(lambda t: t[1], work_time_per_day_list))
            //         else:
            //             work_days_data = work_days_data_mapped[leave.date_from, leave.date_to, leave.holiday_status_id.include_public_holidays_in_duration, calendar][leave.employee_id.id]
            //             hours, days = work_days_data['hours'], work_days_data['days']
            //     else:
            //         today_hours = calendar.get_work_hours_count(
            //             datetime.combine(leave.date_from.date(), time.min),
            //             datetime.combine(leave.date_from.date(), time.max),
            //             False)
            //         hours = calendar.get_work_hours_count(leave.date_from, leave.date_to, compute_leaves=not leave.holiday_status_id.include_public_holidays_in_duration)
            //         days = hours / (today_hours or HOURS_PER_DAY)
            //     if leave.leave_type_request_unit == 'day' and check_leave_type:
            //         days = ceil(days)
            //     result[leave.id] = (days, hours)
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetEdiCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_edi_creation(self):
            // """Get an environment to import documents from other sources.
            // 
            // Allow to edit the current move or create a new one.
            // This will prevent computing the dynamic lines at each invoice line added and only
            // compute everything at the end.
            // """
            // container = {'records': self}
            // with self._check_balanced(container),\
            //      self._disable_discount_precision(),\
            //      self._sync_dynamic_lines(container):
            //     move = self or self.create({})
            //     yield move
            //     container['records'] = move
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_employee_create_vals(self):
            // self.ensure_one()
            // address_id = self.partner_id.address_get(['contact'])['contact']
            // address_sudo = self.env['res.partner'].sudo().browse(address_id)
            // return {
            //     'name': self.partner_name or self.partner_id.display_name,
            //     'work_contact_id': self.partner_id.id,
            //     'job_id': self.job_id.id,
            //     'job_title': self.job_id.name,
            //     'private_street': address_sudo.street,
            //     'private_street2': address_sudo.street2,
            //     'private_city': address_sudo.city,
            //     'private_state_id': address_sudo.state_id.id,
            //     'private_zip': address_sudo.zip,
            //     'private_country_id': address_sudo.country_id.id,
            //     'private_phone': address_sudo.phone,
            //     'private_email': address_sudo.email,
            //     'lang': address_sudo.lang,
            //     'department_id': self.department_id.id,
            //     'address_id': self.company_id.partner_id.id,
            //     'work_email': self.department_id.company_id.email or self.email_from,  # To have a valid email address by default
            //     'work_phone': self.department_id.company_id.phone,
            //     'applicant_ids': self.ids,
            //     'phone': self.partner_phone
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_employee_domain(self):
            // domain = [
            //     ('active', '=', True),
            //     ('company_id', 'in', self.env.companies.ids),
            // ]
            // if not self.env.user.has_group('hr_holidays.group_hr_holidays_user'):
            //     domain += [
            //         '|',
            //         ('user_id', '=', self.env.uid),
            //         ('leave_manager_id', '=', self.env.uid),
            //     ]
            // return domain
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmployeeFromEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_employee_m2o_to_empty_on_archived_employees(self):
            // return ['parent_id', 'coach_id']
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmployeeWorkingNowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_employee_working_now(self):
            // """ Sudo needed to get resource_calendar_id as its normally only accessible by hr_users on version model
            // (accessible on employee by inherits)."""
            // working_now = []
            // # We loop over all the employee tz and the resource calendar_id to detect working hours in batch.
            // all_employee_tz = set(self.mapped('tz'))
            // for tz in all_employee_tz:
            //     employee_ids = self.filtered(lambda e: e.tz == tz)
            //     resource_calendar_ids = employee_ids.sudo().mapped('resource_calendar_id')
            //     for calendar_id in resource_calendar_ids:
            //         res_employee_ids = employee_ids.sudo().filtered(lambda e: e.resource_calendar_id.id == calendar_id.id)
            //         start_dt = fields.Datetime.now()
            //         stop_dt = start_dt + timedelta(hours=1)
            //         from_datetime = utc.localize(start_dt).astimezone(timezone(tz or 'UTC'))
            //         to_datetime = utc.localize(stop_dt).astimezone(timezone(tz or 'UTC'))
            //         # Getting work interval of the first is working. Functions called on resource_calendar_id
            //         # are waiting for singleton
            //         work_interval = res_employee_ids[0].resource_calendar_id._work_intervals_batch(from_datetime, to_datetime)[False]
            //         # Employee that is not supposed to work have empty items.
            //         if len(work_interval._items) > 0:
            //             # The employees should be working now according to their work schedule
            //             working_now += res_employee_ids.ids
            // return working_now
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def get_empty_list_help(self, help_message):
            // return super().get_empty_list_help((help_message or '') + self._get_empty_list_mail_alias())
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def get_empty_list_help(self, help_message):
            //         if 'active_id' in self.env.context and self.env.context.get('active_model') == 'hr.job':
            //             hr_job = self.env['hr.job'].browse(self.env.context['active_id'])
            //         elif self.env.context.get('default_job_id'):
            //             hr_job = self.env['hr.job'].browse(self.env.context['default_job_id'])
            //         else:
            //             hr_job = self.env['hr.job']
            // 
            //         nocontent_body = Markup("""
            // <p class="o_view_nocontent_smiling_face">%(help_title)s</p>
            // """) % {
            //             'help_title': _("No applications found."),
            //         }
            // 
            //         if hr_job.alias_email:
            //             nocontent_body += Markup('<p class="o_copy_paste_email oe_view_nocontent_alias">%(helper_email)s <a href="mailto:%(email)s">%(email)s</a></p>') % {
            //                 'helper_email': _("Send applications to"),
            //                 'email': hr_job.alias_email,
            //             }
            // 
            //         return super().get_empty_list_help(nocontent_body)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListMailAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> GetExpectedAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_expected_attendances(self, date_from, date_to):
            // self.ensure_one()
            // valid_versions = self.sudo()._get_versions_with_contract_overlap_with_period(date_from.date(), date_to.date())
            // employee_tz = timezone(self.tz) if self.tz else None
            // if not valid_versions:
            //     calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            //     calendar_intervals = calendar._work_intervals_batch(
            //         date_from,
            //         date_to,
            //         tz=employee_tz,
            //         resources=self.resource_id,
            //         compute_leaves=True,
            //         domain=[('company_id', 'in', [False, self.company_id.id])])[self.resource_id.id]
            //     return calendar_intervals
            // duration_data = Intervals()
            // version_prev = datetime.combine(valid_versions[0].date_start, time.min, employee_tz)
            // for version in valid_versions:
            //     version_start = datetime.combine(version.date_start, time.min, employee_tz)
            //     contract_start = datetime.combine(version.contract_date_start, time.min, employee_tz)
            //     version_end = datetime.combine(version.date_end or date.max, time.max, employee_tz)
            //     calendar = version.resource_calendar_id or version.company_id.resource_calendar_id
            //     start_date = version_start if version_prev < version_start else contract_start
            //     version_intervals = calendar._work_intervals_batch(
            //                             max(date_from, start_date),
            //                             min(date_to, version_end),
            //                             tz=employee_tz,
            //                             resources=self.resource_id,
            //                             compute_leaves=True,
            //                             domain=[('company_id', 'in', [False, self.company_id.id]), ('time_type', '=', 'leave')])[self.resource_id.id]
            //     duration_data = duration_data | version_intervals
            // return duration_data
            */
            return default;
        }

        public async Task<TEntity> GetExpenseAccountDestinationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        [ApiModel]
        public async Task<TEntity> GetExpenseDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> GetExtraPrintItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_extra_print_items(self):
            // """ Helper to dynamically add items in the 'Print' menu of list and form of account.move.
            // """
            // if moves_to_export := self.filtered(lambda m: m._get_move_zip_export_docs()):
            //     return [
            //         {
            //             'key': 'download_all',
            //             'description': _("Export ZIP"),
            //             **moves_to_export.action_move_download_all(),
            //         },
            //     ]
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToCopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_fields_to_copy_recurring_entries(self, values):
            // ''' Determines which extra fields to copy when copying a recurring entry.
            // To be extended by modules that add fields with copy=False (implicit or explicit)
            // whenever the opposite behavior is expected for recurring invoices.
            // '''
            // values.update({
            //     'auto_post': self.auto_post,  # copy=False to avoid mistakes but should be the same in recurring copies
            //     'auto_post_until': self.auto_post_until,  # same as above
            //     'auto_post_origin_id': self.auto_post_origin_id.id,  # same as above
            //     'invoice_user_id': self.invoice_user_id.id,  # otherwise user would be OdooBot
            // })
            // if self.invoice_date:
            //     values.update({'invoice_date': self._apply_delta_recurring_entries(self.invoice_date, self.auto_post_origin_id.invoice_date, self.auto_post)})
            // if not self.invoice_payment_term_id and self.invoice_date_due:
            //     # no payment terms: maintain timedelta between due date and accounting date
            //     values.update({'invoice_date_due': values['date'] + (self.invoice_date_due - self.date)})
            // return values
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToDetachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_fields_to_detach(self):
            // """"
            // Returns a list of field names to detach on resetting an invoice to draft. Can be overridden by other modules to
            // add more fields.
            // """
            // return ['invoice_pdf_report_file']
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object no_gap) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_first_version_date(self, no_gap=True):
            // self.ensure_one()
            // if not self.env.su and not self.env.user.has_group("hr.group_hr_user"):
            //     raise AccessError(_("Only HR users can access first version date on an employee."))
            // 
            // def remove_gap(versions):
            //     # We do not consider a gap of more than 4 days to be a same occupation
            //     # versions are considered to be ordered correctly
            //     if not versions:
            //         return self.env['hr.version']
            //     if len(versions) == 1:
            //         return versions
            //     current_version = versions[0]
            //     older_versions = versions[1:]
            //     current_date = current_version.date_start
            //     for i, other_version in enumerate(older_versions):
            //         # Consider current_version.date_end being false as an error and cut the loop
            //         gap = (current_date - (other_version.date_end or date(2100, 1, 1))).days
            //         current_date = other_version.date_start
            //         if gap >= 4:
            //             return older_versions[0:i] + current_version
            //     return older_versions + current_version
            // 
            // versions = self._get_first_versions().sorted('date_start', reverse=True)
            // if no_gap:
            //     versions = remove_gap(versions)
            // return min(versions.mapped('date_start')) if versions else False
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_first_versions(self):
            // self.ensure_one()
            // versions = self.version_ids
            // if self.env.context.get('before_date'):
            //     versions = versions.filtered(lambda c: c.date_start <= self.env.context['before_date'])
            // return versions
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_action(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // res = super().get_formview_action(access_uid=access_uid)
            // user = self.env.user
            // if access_uid:
            //     user = self.env['res.users'].browse(access_uid).sudo()
            // 
            // if not user.has_group('hr.group_hr_user'):
            //     res['res_model'] = 'hr.employee.public'
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_id(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // user = self.env.user
            // if access_uid:
            //     user = self.env['res.users'].browse(access_uid).sudo()
            // 
            // if user.has_group('hr.group_hr_user'):
            //     return super().get_formview_id(access_uid=access_uid)
            // # Hardcode the form view for public employee
            // return self.env.ref('hr.hr_employee_public_view_form').id
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFrequentAccountAndTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_frequent_account_and_taxes(self, company_id, partner_id, move_type):
            // """
            // Returns the most used accounts and taxes for a given partner and company,
            // eventually filtered according to the move type.
            // """
            // if not partner_id:
            //     return 0, False, False
            // domain = [
            //     *self.env['account.move.line']._check_company_domain(company_id),
            //     ('partner_id', '=', partner_id),
            //     ('date', '>=', date.today() - timedelta(days=365 * 2)),
            // ]
            // if move_type in self.env['account.move'].get_inbound_types(include_receipts=True):
            //     domain.append(('account_id.internal_group', '=', 'income'))
            // elif move_type in self.env['account.move'].get_outbound_types(include_receipts=True):
            //     domain.append(('account_id.internal_group', '=', 'expense'))
            // 
            // query = self.env['account.move.line']._search(domain, bypass_access=True)
            // account_code = self.env['account.account']._field_to_sql('account_move_line__account_id', 'code', query)
            // rows = self.env.execute_query(SQL("""
            //     SELECT COUNT(foo.id), foo.account_id, foo.taxes
            //       FROM (
            //                  SELECT account_move_line__account_id.id AS account_id,
            //                         %(account_code)s AS code,
            //                         account_move_line.id,
            //                         ARRAY_AGG(tax_rel.account_tax_id) FILTER (WHERE tax_rel.account_tax_id IS NOT NULL) AS taxes
            //                    FROM %(from_clause)s
            //               LEFT JOIN account_move_line_account_tax_rel tax_rel ON account_move_line.id = tax_rel.account_move_line_id
            //                   WHERE %(where_clause)s
            //                GROUP BY account_move_line__account_id.id,
            //                         %(account_code)s,
            //                         account_move_line.id
            //            ) AS foo
            //   GROUP BY foo.account_id, foo.taxes
            //   ORDER BY COUNT(foo.id) DESC, taxes ASC NULLS LAST
            //      LIMIT 1
            //     """,
            //     account_code=account_code,
            //     from_clause=query.from_clause,
            //     where_clause=query.where_clause or SQL("TRUE"),
            // ))
            // return rows[0] if rows else (0, False, False)
            */
            return default;
        }

        public async Task<TEntity> GetHourFromToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request_date_from, object request_date_to, object day_period) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_hour_from_to(self, request_date_from, request_date_to, day_period=None):
            // """
            // Return the hour_from and hour_to for the given request dates, based on
            // the resource calendar.
            // 
            // If there are no attendances on the exact days of the request, return
            // the earliest hour_from and latest hour_to that exist in the schedule.
            // """
            // calendar = self.resource_calendar_id
            // if not calendar:
            //     return (0, 24)
            // calendar.ensure_one()
            // 
            // hour_from, _ = calendar._get_hours_for_date(request_date_from, day_period)
            // _, hour_to = calendar._get_hours_for_date(request_date_to, day_period)
            // 
            // return (hour_from, hour_to)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_import_templates(self):
            // move_type = self.env.context.get('default_move_type')
            // match move_type:
            //     case 'entry':
            //         return [{
            //             'label': _('Import Template for Misc. Operations'),
            //             'template': '/account/static/xls/misc_operations_import_template.xlsx',
            //         }]
            //     case 'out_invoice':
            //         return [{
            //             'label': _('Import Template for Invoices'),
            //             'template': '/account/static/xls/customer_invoices_credit_notes_import_template.xlsx',
            //         }]
            //     case 'out_refund':
            //         return [{
            //             'label': _('Import Template for Credit Notes'),
            //             'template': '/account/static/xls/customer_invoices_credit_notes_import_template.xlsx',
            //         }]
            //     case 'in_invoice':
            //         return [{
            //             'label': _('Import Template for Bills'),
            //             'template': '/account/static/xls/vendor_bills_refunds_import_template.xlsx',
            //         }]
            //     case 'in_refund':
            //         return [{
            //             'label': _('Import Template for Refunds'),
            //             'template': '/account/static/xls/vendor_bills_refunds_import_template.xlsx',
            //         }]
            //     case _:
            //         return []
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Employees'),
            //     'template': '/hr/static/xls/hr_employee.xls'
            // }]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_inbound_types(self, include_receipts=True):
            // return ['out_invoice', 'in_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetInstallmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_installments_data(self):
            // self.ensure_one()
            // term_lines = self.line_ids.filtered(lambda l: l.display_type == 'payment_term')
            // return term_lines._get_installments_data()
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsAndSubfieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_integrity_hash_fields_and_subfields(self):
            // return self._get_integrity_hash_fields() + [f'line_ids.{subfield}' for subfield in self.line_ids._get_integrity_hash_fields()]
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_integrity_hash_fields(self):
            // # Use the latest hash version by default, but keep the old one for backward compatibility when generating the integrity report.
            // hash_version = self.env.context.get('hash_version', MAX_HASH_VERSION)
            // if hash_version == 1:
            //     return ['date', 'journal_id', 'company_id']
            // elif hash_version in (2, 3, 4):
            //     return ['name', 'date', 'journal_id', 'company_id']
            // raise NotImplementedError(f"hash_version={hash_version} doesn't exist")
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceComputedReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_computed_reference(self):
            // self.ensure_one()
            // ref_function = getattr(self, f'_get_invoice_reference_{self.journal_id.invoice_reference_model}_{self.journal_id.invoice_reference_type}', None)
            // if ref_function is None:
            //     raise UserError(_("The combination of reference model and reference type on the journal is not implemented"))
            // return ref_function()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aml_values_list, object open_balance) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_counterpart_amls_for_early_payment_discount(self, aml_values_list, open_balance):
            // """ Helper to get the values to create the counterpart journal items on the register payment wizard and the
            // bank reconciliation widget in case of an early payment discount by taking care of the payment term lines we
            // are matching and the exchange difference in case of multi-currencies.
            // 
            // :param aml_values_list: A list of dictionaries containing:
            //     * aml:              The payment term line we match.
            //     * amount_currency:  The matched amount_currency for this line.
            //     * balance:          The matched balance for this line (could be different in case of multi-currencies).
            // :param open_balance:    The current open balance to be covered by the early payment discount.
            // :return: A list of values to create the counterpart journal items split in 3 categories:
            //     * term_lines:       The journal items containing the discount amounts for each receivable line when the
            //                         discount computation is excluded / mixed.
            //     * tax_lines:        The journal items acting as tax lines when the discount computation is included.
            //     * base_lines:       The journal items acting as base for tax lines when the discount computation is included.
            //     * exchange_lines:   The journal items representing the exchange differences in case of multi-currencies.
            // """
            // res = {
            //     'base_lines': {},
            //     'tax_lines': {},
            //     'term_lines': {},
            //     'exchange_lines': {},
            // }
            // 
            // res_per_invoice = {}
            // for aml_values in aml_values_list:
            //     aml = aml_values['aml']
            //     invoice = aml.move_id
            // 
            //     if invoice not in res_per_invoice:
            //         res_per_invoice[invoice] = invoice._get_invoice_counterpart_amls_for_early_payment_discount_per_payment_term_line()
            // 
            //     for key in ('base_lines', 'tax_lines', 'term_lines'):
            //         for grouping_dict, vals in res_per_invoice[invoice][key][aml].items():
            //             line_vals = res[key].setdefault(grouping_dict, {
            //                 **vals,
            //                 'amount_currency': 0.0,
            //                 'balance': 0.0,
            //             })
            //             line_vals['amount_currency'] += vals['amount_currency']
            //             line_vals['balance'] += vals['balance']
            // 
            //             # Track the balance to handle the exchange difference.
            //             open_balance -= vals['balance']
            // 
            // exchange_diff_sign = aml.company_currency_id.compare_amounts(open_balance, 0.0)
            // if exchange_diff_sign != 0.0:
            // 
            //     if exchange_diff_sign > 0.0:
            //         exchange_line_account = aml.company_id.expense_currency_exchange_account_id
            //     else:
            //         exchange_line_account = aml.company_id.income_currency_exchange_account_id
            // 
            //     grouping_dict = {
            //         'account_id': exchange_line_account.id,
            //         'currency_id': aml.currency_id.id,
            //         'partner_id': aml.partner_id.id,
            //     }
            //     line_vals = res['exchange_lines'].setdefault(frozendict(grouping_dict), {
            //         **grouping_dict,
            //         'name': _("Early Payment Discount (Exchange Difference)"),
            //         'amount_currency': 0.0,
            //         'balance': 0.0,
            //     })
            //     line_vals['balance'] += open_balance
            // 
            // return {
            //     key: [
            //         {
            //             **grouping_dict,
            //             **vals,
            //         }
            //         for grouping_dict, vals in mapping.items()
            //     ]
            //     for key, mapping in res.items()
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountPerPaymentTermLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_counterpart_amls_for_early_payment_discount_per_payment_term_line(self):
            // """ Helper to get the values to create the counterpart journal items on the register payment wizard and the
            // bank reconciliation widget in case of an early payment discount. When the early payment discount computation
            // is included, we need to compute the base amounts / tax amounts for each receivable / payable but we need to
            // take care about the rounding issues. For others computations, we need to balance the discount you get.
            // 
            // :return: A list of values to create the counterpart journal items split in 3 categories:
            //     * term_lines:   The journal items containing the discount amounts for each receivable line when the
            //                     discount computation is excluded / mixed.
            //     * tax_lines:    The journal items acting as tax lines when the discount computation is included.
            //     * base_lines:   The journal items acting as base for tax lines when the discount computation is included.
            // """
            // self.ensure_one()
            // 
            // def inverse_tax_rep(tax_rep):
            //     tax = tax_rep.tax_id
            //     index = list(tax.invoice_repartition_line_ids).index(tax_rep)
            //     return tax.refund_repartition_line_ids[index]
            // 
            // company = self.company_id
            // payment_term_line = self.line_ids.filtered(lambda x: x.display_type == 'payment_term')
            // tax_lines = self.line_ids.filtered('tax_repartition_line_id')
            // invoice_lines = self.line_ids.filtered(lambda x: x.display_type == 'product')
            // payment_term = self.invoice_payment_term_id
            // early_pay_discount_computation = payment_term.early_pay_discount_computation
            // discount_percentage = payment_term.discount_percentage
            // 
            // res = {
            //     'term_lines': defaultdict(lambda: {}),
            //     'tax_lines': defaultdict(lambda: {}),
            //     'base_lines': defaultdict(lambda: {}),
            // }
            // if not discount_percentage:
            //     return res
            // 
            // # Get the current tax amounts in the current invoice.
            // tax_amounts = {
            //     inverse_tax_rep(line.tax_repartition_line_id).id: {
            //         'amount_currency': line.amount_currency,
            //         'balance': line.balance,
            //     }
            //     for line in tax_lines
            // }
            // 
            // base_lines = [
            //     {
            //         **self._prepare_product_base_line_for_taxes_computation(line),
            //         'is_refund': True,
            //     }
            //     for line in invoice_lines
            // ]
            // for base_line in base_lines:
            //     base_line['tax_ids'] = base_line['tax_ids'].filtered(lambda t: t.amount_type != 'fixed')
            // 
            //     if early_pay_discount_computation == 'included':
            //         remaining_part_to_consider = (100 - discount_percentage) / 100.0
            //         base_line['price_unit'] *= remaining_part_to_consider
            // AccountTax = self.env['account.tax']
            // AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            // AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines, self.company_id)
            // 
            // if self.is_inbound(include_receipts=True):
            //     cash_discount_account = company.account_journal_early_pay_discount_loss_account_id
            // else:
            //     cash_discount_account = company.account_journal_early_pay_discount_gain_account_id
            // 
            // epd_analytic_distribution = self.env['account.analytic.distribution.model']._get_distribution({
            //     'account_prefix': cash_discount_account.code,
            //     'company_id': self.company_id.id,
            //     'partner_id': self.commercial_partner_id.id,
            //     'partner_category_id': self.partner_id.category_id.ids,
            // })
            // 
            // bases_details = {}
            // 
            // term_amount_currency = payment_term_line.amount_currency - payment_term_line.discount_amount_currency
            // term_balance = payment_term_line.balance - payment_term_line.discount_balance
            // if early_pay_discount_computation == 'included' and invoice_lines.tax_ids:
            //     # Compute the base amounts.
            //     resulting_delta_base_details = {}
            //     resulting_delta_tax_details = {}
            //     for base_line in base_lines:
            //         tax_details = base_line['tax_details']
            //         invoice_line = base_line['record']
            // 
            //         grouping_dict = {
            //             'tax_ids': [Command.set(base_line['tax_ids'].ids)],
            //             'tax_tag_ids': [Command.set(base_line['tax_tag_ids'].ids)],
            //             'partner_id': base_line['partner_id'].id,
            //             'currency_id': base_line['currency_id'].id,
            //             'account_id': cash_discount_account.id,
            //             'analytic_distribution': base_line['analytic_distribution'] or epd_analytic_distribution,
            //         }
            //         base_detail = resulting_delta_base_details.setdefault(frozendict(grouping_dict), {
            //             'balance': 0.0,
            //             'amount_currency': 0.0,
            //         })
            // 
            //         amount_currency = self.currency_id\
            //             .round(self.direction_sign * tax_details['total_excluded_currency'] - invoice_line.amount_currency)
            //         balance = self.company_currency_id\
            //             .round(self.direction_sign * tax_details['total_excluded'] - invoice_line.balance)
            // 
            //         base_detail['balance'] += balance
            //         base_detail['amount_currency'] += amount_currency
            // 
            //         bases_details[frozendict(grouping_dict)] = base_detail
            // 
            //     # Compute the tax amounts.
            //     tax_results = AccountTax._prepare_tax_lines(base_lines, self.company_id)
            //     for tax_line_vals in tax_results['tax_lines_to_add']:
            //         tax_amount_without_epd = tax_amounts.get(tax_line_vals['tax_repartition_line_id'])
            //         if tax_amount_without_epd:
            //             resulting_delta_tax_details[tax_line_vals['tax_repartition_line_id']] = {
            //                 **tax_line_vals,
            //                 'amount_currency': tax_line_vals['amount_currency'] - tax_amount_without_epd['amount_currency'],
            //                 'balance': tax_line_vals['balance'] - tax_amount_without_epd['balance'],
            //             }
            // 
            //     # Multiply the amount by the percentage
            //     percentage_paid = abs(payment_term_line.amount_residual_currency / self.amount_total)
            //     for tax_line_vals in resulting_delta_tax_details.values():
            //         tax_rep = self.env['account.tax.repartition.line'].browse(tax_line_vals['tax_repartition_line_id'])
            //         tax = tax_rep.tax_id
            // 
            //         grouping_dict = {
            //             'account_id': tax_line_vals['account_id'],
            //             'partner_id': tax_line_vals['partner_id'],
            //             'currency_id': tax_line_vals['currency_id'],
            //             'analytic_distribution': tax_line_vals['analytic_distribution'],
            //             'tax_repartition_line_id': tax_rep.id,
            //             'tax_ids': tax_line_vals['tax_ids'],
            //             'tax_tag_ids': tax_line_vals['tax_tag_ids'],
            //             'group_tax_id': tax_line_vals['group_tax_id'],
            //         }
            // 
            //         res['tax_lines'][payment_term_line][frozendict(grouping_dict)] = {
            //             'name': _("Early Payment Discount (%s)", tax.name),
            //             'amount_currency': payment_term_line.currency_id.round(tax_line_vals['amount_currency'] * percentage_paid),
            //             'balance': payment_term_line.company_currency_id.round(tax_line_vals['balance'] * percentage_paid),
            //         }
            // 
            //     for grouping_dict, base_detail in bases_details.items():
            //         res['base_lines'][payment_term_line][grouping_dict] = {
            //             'name': _("Early Payment Discount"),
            //             'amount_currency': payment_term_line.currency_id.round(base_detail['amount_currency'] * percentage_paid),
            //             'balance': payment_term_line.company_currency_id.round(base_detail['balance'] * percentage_paid),
            //         }
            // 
            //     # Fix the rounding issue if any.
            //     delta_amount_currency = term_amount_currency \
            //                             - sum(x['amount_currency'] for x in res['base_lines'][payment_term_line].values()) \
            //                             - sum(x['amount_currency'] for x in res['tax_lines'][payment_term_line].values())
            //     delta_balance = term_balance \
            //                     - sum(x['balance'] for x in res['base_lines'][payment_term_line].values()) \
            //                     - sum(x['balance'] for x in res['tax_lines'][payment_term_line].values())
            // 
            //     biggest_base_line = max(list(res['base_lines'][payment_term_line].values()), key=lambda x: x['amount_currency'])
            //     biggest_base_line['amount_currency'] += delta_amount_currency
            //     biggest_base_line['balance'] += delta_balance
            // 
            // else:
            //     grouping_dict = {'account_id': cash_discount_account.id}
            // 
            //     res['term_lines'][payment_term_line][frozendict(grouping_dict)] = {
            //         'name': _("Early Payment Discount"),
            //         'partner_id': payment_term_line.partner_id.id,
            //         'currency_id': payment_term_line.currency_id.id,
            //         'amount_currency': term_amount_currency,
            //         'balance': term_balance,
            //         'analytic_distribution': epd_analytic_distribution,
            //     }
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCurrencyRateDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_currency_rate_date(self):
            // self.ensure_one()
            // return self.invoice_date or fields.Date.context_today(self)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_filter_type_domain(self, move_type):
            // if self.is_sale_document(include_receipts=True, move_type=move_type):
            //     return 'sale'
            // elif self.is_purchase_document(include_receipts=True, move_type=move_type):
            //     return 'purchase'
            // else:
            //     return False
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceInPaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_in_payment_state(self):
            // ''' Hook to give the state when the invoice becomes fully paid. This is necessary because the users working
            // with only invoicing don't want to see the 'in_payment' state. Then, this method will be overridden in the
            // accountant module to enable the 'in_payment' state. '''
            // return 'paid'
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLegalDocumentsAllInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allow_fallback) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_legal_documents_all(self, allow_fallback=False):
            // """ Retrieve the invoice legal attachments: PDF, XML, ...
            // :param bool allow_fallback: if True, returns a Proforma if the PDF invoice doesn't exist.
            // :return list: a list of the attachments data such as
            // [{'filename': 'INV_2024_0001.pdf', 'filetype': 'pdf', 'content': ...}, ...]
            // """
            // self.ensure_one()
            // if self.invoice_pdf_report_id:
            //     attachments = self.env['account.move.send']._get_invoice_extra_attachments(self)
            //     return [
            //         {
            //             'filename': attachment.name,
            //             'filetype': attachment.mimetype,
            //             'content': attachment.raw,
            //         }
            //         for attachment in attachments
            //     ]
            // elif allow_fallback:
            //     return [self._get_invoice_pdf_proforma()]
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLegalDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filetype, object allow_fallback) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_legal_documents(self, filetype, allow_fallback=False):
            // """ Retrieve the invoice legal document of type filetype.
            // :param filetype: the type of legal document to retrieve. Example: 'pdf'.
            // :param bool allow_fallback: if True, returns a Proforma if the PDF invoice doesn't exist.
            // :return dict: the invoice PDF data such as
            // {'filename': 'INV_2024_0001.pdf', 'filetype': 'pdf', 'content':...}
            // To extend to add more supported filetypes.
            // """
            // self.ensure_one()
            // if filetype == 'pdf':
            //     if invoice_pdf := self.invoice_pdf_report_id:
            //         return {
            //             'filename': invoice_pdf.name,
            //             'filetype': invoice_pdf.mimetype,
            //             'content': invoice_pdf.raw,
            //         }
            //     elif allow_fallback:
            //         return self._get_invoice_pdf_proforma()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_invoice_localisation_fields_required_to_invoice(self, country_id):
            // """ Returns the list of fields that needs to be filled when creating an invoice for the selected country.
            // This is required for some flows that would allow a user to request an invoice from the portal.
            // Using these, we can get their information and dynamically create form inputs based for the fields required legally for the company country_id.
            // The returned fields must be of type ir.model.fields in order to handle translations
            // 
            // :param country_id: The country for which we want the fields.
            // :return: an array of ir.model.fields for which the user should provide values.
            // """
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceNextPaymentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_next_payment_values(self, custom_amount=None):
            // self.ensure_one()
            // term_lines = self.line_ids.filtered(lambda line: line.display_type == 'payment_term')
            // if not term_lines:
            //     return {}
            // installments = term_lines._get_installments_data()
            // not_reconciled_installments = [x for x in installments if not x['reconciled']]
            // overdue_installments = [x for x in not_reconciled_installments if x['type'] == 'overdue']
            // # Early payment discounts can only have one installment at most
            // epd_installment = next((installment for installment in installments if installment['type'] == 'early_payment_discount'), {})
            // show_installments = len(installments) > 1
            // additional_info = {}
            // 
            // if show_installments and overdue_installments:
            //     installment_state = 'overdue'
            //     amount_due = self.amount_residual
            //     next_amount_to_pay = sum(x['amount_residual_currency_unsigned'] for x in overdue_installments)
            //     next_payment_reference = f"{self.name}-{overdue_installments[0]['number']}"
            //     next_due_date = overdue_installments[0]['date_maturity']
            // elif show_installments and not_reconciled_installments:
            //     installment_state = 'next'
            //     amount_due = self.amount_residual
            //     next_amount_to_pay = not_reconciled_installments[0]['amount_residual_currency_unsigned']
            //     next_payment_reference = f"{self.name}-{not_reconciled_installments[0]['number']}"
            //     next_due_date = not_reconciled_installments[0]['date_maturity']
            // elif epd_installment:
            //     installment_state = 'epd'
            //     amount_due = epd_installment['amount_residual_currency_unsigned']
            //     next_amount_to_pay = self.amount_residual
            //     next_payment_reference = self.name
            //     next_due_date = epd_installment['date_maturity']
            //     discount_date = epd_installment['line'].discount_date or fields.Date.context_today(self)
            //     discount_amount_currency = epd_installment['discount_amount_currency']
            //     days_left = max(0, (discount_date - fields.Date.context_today(self)).days)  # should never be lower than 0 since epd is valid
            //     if days_left > 0:
            //         discount_msg = _(
            //             "Discount of %(amount)s if paid within %(days)s days",
            //             amount=self.currency_id.format(discount_amount_currency),
            //             days=days_left,
            //         )
            //     else:
            //         discount_msg = _(
            //             "Discount of %(amount)s if paid today",
            //             amount=self.currency_id.format(discount_amount_currency),
            //         )
            // 
            //     additional_info.update({
            //         'epd_discount_amount_currency': discount_amount_currency,
            //         'epd_discount_amount': epd_installment['discount_amount'],
            //         'discount_date': fields.Date.to_string(discount_date),
            //         'epd_days_left': days_left,
            //         'epd_line': epd_installment['line'],
            //         'epd_discount_msg': discount_msg,
            //     })
            // else:
            //     installment_state = None
            //     amount_due = self.amount_residual
            //     next_amount_to_pay = self.amount_residual
            //     next_payment_reference = self.name
            //     next_due_date = self.invoice_date_due
            // 
            // if custom_amount is not None:
            //     is_custom_amount_same_as_next_amount = self.currency_id.is_zero(custom_amount - next_amount_to_pay)
            //     is_custom_amount_same_as_epd_discounted_amount = installment_state == 'epd' and self.currency_id.is_zero(custom_amount - amount_due)
            //     if not is_custom_amount_same_as_next_amount and not is_custom_amount_same_as_epd_discounted_amount:
            //         installment_state = 'next'
            //         next_amount_to_pay = custom_amount
            //         next_payment_reference = self.name
            //         next_due_date = installments[0]['date_maturity']
            // 
            // return {
            //     'payment_state': self.payment_state,
            //     'installment_state': installment_state,
            //     'next_amount_to_pay': next_amount_to_pay,
            //     'next_payment_reference': next_payment_reference,
            //     'amount_paid': self.amount_total - self.amount_residual,
            //     'amount_due': amount_due,
            //     'next_due_date': next_due_date,
            //     'due_date': self.invoice_date_due,
            //     'not_reconciled_installments': not_reconciled_installments,
            //     'is_last_installment': len(not_reconciled_installments) == 1,
            //     **additional_info,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePdfProformaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_pdf_proforma(self):
            // """ Generate the Proforma of the invoice.
            // :return dict: the Proforma's data such as
            // {'filename': 'INV_2024_0001_proforma.pdf', 'filetype': 'pdf', 'content': ...}
            // """
            // self.ensure_one()
            // filename = self._get_invoice_proforma_pdf_report_filename()
            // content, report_type = self.env['ir.actions.report']._pre_render_qweb_pdf('account.account_invoices', self.ids, data={'proforma': True})
            // content_by_id = self.env['ir.actions.report']._get_splitted_report('account.account_invoices', content, report_type)
            // return {
            //     'filename': filename,
            //     'filetype': 'pdf',
            //     'content': content_by_id[self.id],
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePortalExtraValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_portal_extra_values(self, custom_amount=None):
            // self.ensure_one()
            // return {
            //     'invoice': self,
            //     'currency': self.currency_id,
            //     **self._get_invoice_next_payment_values(custom_amount=custom_amount),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceProformaPdfReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_proforma_pdf_report_filename(self):
            // """ Get the filename of the generated proforma PDF invoice report. """
            // self.ensure_one()
            // return f"{self._get_move_display_name().replace(' ', '_').replace('/', '_')}_proforma.pdf"
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceEuroInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_euro_invoice(self):
            // """ This computes the reference based on the RF Creditor Reference.
            //     The data of the reference is the journal short code and the database
            //     id number of the invoice. For instance, if a journal code is INV and
            //     an invoice is issued with id 37, the check number is 67 so the
            //     reference will be 'RF67 INV0 0003 7'.
            // """
            // self.ensure_one()
            // journal_identifier = self.journal_id.code if self.journal_id.code.isascii() and self.journal_id.code.isalnum() else self.journal_id.id
            // return format_structured_reference_iso(f'{journal_identifier}{str(self.id).zfill(6)}')
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceEuroPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_euro_partner(self):
            // """ This computes the reference based on the RF Creditor Reference.
            //     The data of the reference is the user defined reference of the
            //     partner or the database id number of the parter.
            //     For instance, if an invoice is issued for the partner with internal
            //     reference 'food buyer 654', the digits will be extracted and used as
            //     the data. This will lead to a check number equal to 00 and the
            //     reference will be 'RF00 654'.
            //     If no reference is set for the partner, its id in the database will
            //     be used.
            // """
            // self.ensure_one()
            // journal_identifier = self.journal_id.code if self.journal_id.code.isascii() and self.journal_id.code.isalnum() else self.journal_id.id
            // partner_ref = self.partner_id.ref
            // partner_ref_nr = re.sub(r'\D', '', partner_ref or '')[-21:] or str(self.partner_id.id)[-21:]
            // partner_ref_nr = f'{journal_identifier}{partner_ref_nr}'[-21:]
            // return format_structured_reference_iso(partner_ref_nr)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceNumberInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_number_invoice(self):
            // """ This computes the reference based on the Number format.
            //     Return the number of the invoice, defined on the journal sequence.
            // """
            // ref = self._get_invoice_reference_odoo_invoice() or ''
            // return ''.join(char for char in ref if char.isdigit())
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceNumberPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_number_partner(self):
            // """ This computes the reference based on the Number format.
            //     The data used is the reference set on the partner or its database
            //     id otherwise. For instance if the reference of the customer is
            //     'customer 97', the reference will be '97'.
            // """
            // ref = self._get_invoice_reference_odoo_partner()
            // return ''.join(char for char in ref if char.isdigit())
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceOdooInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_odoo_invoice(self):
            // """ This computes the reference based on the Odoo format.
            //     We simply return the number of the invoice, defined on the journal
            //     sequence.
            // """
            // self.ensure_one()
            // return self.name
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceOdooPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_odoo_partner(self):
            // """ This computes the reference based on the Odoo format.
            //     The data used is the reference set on the partner or its database
            //     id otherwise. For instance if the reference of the customer is
            //     'dumb customer 97', the reference will be 'CUST/dumb customer 97'.
            // """
            // ref = self.partner_id.ref or str(self.partner_id.id)
            // prefix = _('CUST')
            // return '%s/%s' % (prefix, ref)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object extension, object report) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_report_filename(self, extension='pdf', report=None):
            // """ Get the filename of the generated invoice report with extension file. """
            // self.ensure_one()
            // if not report:
            //     report = self.partner_id.invoice_template_pdf_report_id or self.env.ref('account.account_invoices')
            // if report.print_report_name and isinstance(report.print_report_name, str):
            //     file_name = safe_eval(report.print_report_name, {'object': self})
            // else:
            //     file_name = self.name
            // return f"{file_name.replace('/', '_')}.{extension}"
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_invoice_types(self, include_receipts=False):
            // return self.get_sale_types(include_receipts) + self.get_purchase_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> GetLastSequenceDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object relaxed) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_last_sequence_domain(self, relaxed=False):
            // #pylint: disable=sql-injection
            // # EXTENDS account sequence.mixin
            // self.ensure_one()
            // if not self.date or not self.journal_id:
            //     return "WHERE FALSE", {}
            // where_string = "WHERE journal_id = %(journal_id)s AND name != '/'"
            // param = {'journal_id': self.journal_id.id}
            // is_payment = self.origin_payment_id or self.env.context.get('is_payment')
            // 
            // if not relaxed:
            //     domain = [('journal_id', '=', self.journal_id.id), ('id', '!=', self.id or self._origin.id), ('name', 'not in', ('/', '', False))]
            //     if self.journal_id.refund_sequence:
            //         refund_types = ('out_refund', 'in_refund')
            //         domain += [('move_type', 'in' if self.move_type in refund_types else 'not in', refund_types)]
            //     if self.journal_id.payment_sequence:
            //         domain += [('origin_payment_id', '!=' if is_payment else '=', False)]
            //     if self.journal_id.is_self_billing:
            //         if self.partner_id:
            //             domain += [('commercial_partner_id', '=', self.partner_id.commercial_partner_id.id)]
            //         else:
            //             # If the partner id is not set, we can't compute the sequence, so we force a sequence reset.
            //             domain += [(0, '=', 1)]
            //     reference_move_name = self.sudo().search(domain + [('date', '<=', self.date)], order='date desc', limit=1).name
            //     if not reference_move_name:
            //         reference_move_name = self.sudo().search(domain, order='date asc', limit=1).name
            //     sequence_number_reset = self._deduce_sequence_number_reset(reference_move_name)
            //     date_start, date_end, *_ = self._get_sequence_date_range(sequence_number_reset)
            //     where_string += """ AND date BETWEEN %(date_start)s AND %(date_end)s"""
            //     param['date_start'] = date_start
            //     param['date_end'] = date_end
            // 
            //     # Some regex are catching more sequence formats than we want, so we
            //     # need to exclude them:
            //     #
            //     #                    |                 Regex type                                 |
            //     # Move Name Format   | Fixed | Yearly | Monthly | Year Range | Year range Monthly |
            //     # ------------------ | ----- | ------ | ------- | ---------- | ------------------ |
            //     # Fixed              |   X   |        |         |            |                    |
            //     # Yearly             |   X   |   X    |         |            |                    |
            //     # Monthly            |   X   |   X    |    X    |     X      |                    |
            //     # Year Range         |   X   |   X    |         |     X      |                    |
            //     # Year range Monthly |   X   |   X    |    X    |     X      |          X         |
            //     if sequence_number_reset in ('year', 'year_range'):
            //         param['anti_regex'] = self._make_regex_non_capturing(self._sequence_monthly_regex.split('(?P<seq>')[0]) + '$'
            //     elif sequence_number_reset == 'never':
            //         # Excluding yearly will also exclude "monthly", "year range" and
            //         # "year range monthly"
            //         param['anti_regex'] = self._make_regex_non_capturing(self._sequence_yearly_regex.split('(?P<seq>')[0]) + '$'
            // 
            //     if param.get('anti_regex') and not self.journal_id.sequence_override_regex:
            //         where_string += " AND sequence_prefix !~ %(anti_regex)s "
            // 
            // if self.journal_id.refund_sequence:
            //     if self.move_type in ('out_refund', 'in_refund'):
            //         where_string += " AND move_type IN ('out_refund', 'in_refund') "
            //     else:
            //         where_string += " AND move_type NOT IN ('out_refund', 'in_refund') "
            // elif self.journal_id.payment_sequence:
            //     if is_payment:
            //         where_string += " AND origin_payment_id IS NOT NULL "
            //     else:
            //         where_string += " AND origin_payment_id IS NULL "
            // 
            // if self.journal_id.is_self_billing:
            //     if self.partner_id:
            //         where_string += " AND commercial_partner_id = %(partner_id)s "
            //         param['partner_id'] = self.partner_id.commercial_partner_id.id
            //     else:
            //         where_string += " AND false "
            // return where_string, param
            */
            return default;
        }

        public async Task<TEntity> GetLeavesOnPublicHolidayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_leaves_on_public_holiday(self):
            // return self.filtered(lambda l: l.employee_id and not l.number_of_days)
            */
            return default;
        }

        public async Task<TEntity> GetLinesOnchangeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_lines_onchange_currency(self):
            // # Override needed for COGS
            // return self.line_ids
            */
            return default;
        }

        public async Task<TEntity> GetLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_lock_date_message(self, invoice_date, has_tax):
            // """Get a message describing the latest lock date affecting the specified date.
            // :param invoice_date: The date to be checked
            // :param has_tax: If any taxes are involved in the lines of the invoice
            // :return: a message describing the latest lock date affecting this move and the date it will be
            //          accounted on if posted, or False if no lock dates affect this move.
            // """
            // lock_dates = self._get_violated_lock_dates(invoice_date, has_tax)
            // if lock_dates:
            //     invoice_date = self._get_accounting_date(invoice_date, has_tax, lock_dates=lock_dates)
            //     tax_lock_date_message = _(
            //         "The date is being set prior to: %(lock_date_info)s. "
            //         "The Journal Entry will be accounted on %(invoice_date)s upon posting.",
            //         lock_date_info=self.env['res.company']._format_lock_dates(lock_dates),
            //         invoice_date=format_date(self.env, invoice_date))
            //     return tax_lock_date_message
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_mail_template(self):
            // """
            // :return: the correct mail template based on the current move type
            // """
            // template_xmlid = 'account.email_template_edi_invoice'
            // if all(move.move_type == 'out_refund' for move in self):
            //     template_xmlid = 'account.email_template_edi_credit_note'
            // elif all(move.move_type == 'in_invoice' and move.journal_id.is_self_billing for move in self):
            //     template_xmlid = 'account.email_template_edi_self_billing_invoice'
            // elif all(move.move_type == 'in_refund' and move.journal_id.is_self_billing for move in self):
            //     template_xmlid = 'account.email_template_edi_self_billing_credit_note'
            // return self.env.ref(template_xmlid)
            */
            return default;
        }

        public async Task<TEntity> GetMailThreadDataAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_mail_thread_data_attachments(self):
            // res = super()._get_mail_thread_data_attachments()
            // # else, attachments with 'res_field' get excluded
            // return res | self.env['account.move.send']._get_invoice_extra_attachments(self)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMethodCodesNeedingBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_method_codes_needing_bank_account(self):
            // return []
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMethodCodesUsingBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_method_codes_using_bank_account(self):
            // return ['manual']
            */
            return default;
        }

        public async Task<TEntity> GetMoveDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object show_ref) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_move_display_name(self, show_ref=False):
            // ''' Helper to get the display name of an invoice depending of its type.
            // :param show_ref:    A flag indicating of the display name must include or not the journal entry reference.
            // :return:            A string representing the invoice.
            // '''
            // self.ensure_one()
            // if self.env.context.get('name_as_amount_total'):
            //     currency_amount = self.currency_id.format(self.amount_total)
            //     if self.state == 'posted':
            //         return _("%(ref)s (%(currency_amount)s)", ref=(self.ref or self.name), currency_amount=currency_amount)
            //     else:
            //         return _("Draft (%(currency_amount)s)", currency_amount=currency_amount)
            // name = ''
            // if self.state == 'draft':
            //     name += {
            //         'out_invoice': _('Draft Invoice'),
            //         'out_refund': _('Draft Credit Note'),
            //         'in_invoice': _('Draft Bill'),
            //         'in_refund': _('Draft Vendor Credit Note'),
            //         'out_receipt': _('Draft Sales Receipt'),
            //         'in_receipt': _('Draft Purchase Receipt'),
            //         'entry': _('Draft Entry'),
            //     }[self.move_type]
            // if self.name and self.name != '/':
            //     name = f"{name} {self.name}".strip()
            //     if self.env.context.get('input_full_display_name'):
            //         if self.partner_id:
            //             name += f', {self.partner_id.name}'
            //         if self.date:
            //             name += f', {format_date(self.env, self.date)}'
            // return name + (f" ({shorten(self.ref, width=50)})" if show_ref and self.ref else '')
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMoveHashDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object common_domain, object force_hash) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_move_hash_domain(self, common_domain=False, force_hash=False):
            // """
            // Returns a search domain on model account.move checking whether they should be hashed.
            // :param common_domain: a search domain that will be included in the returned domain in any case
            // :param force_hash: if True, we'll check all moves posted, independently of journal settings
            // """
            // domain = Domain(common_domain or Domain.TRUE) & Domain('state', '=', 'posted')
            // if force_hash:
            //     return domain
            // return domain & Domain('restrict_mode_hash_table', '=', True)
            */
            return default;
        }

        public async Task<TEntity> GetMoveLineNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> GetMoveLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_move_lines_to_report(self):
            // def show_line(line):
            //     return (
            //         line.display_type == 'line_section'
            //         or (
            //             not any([line.parent_id.collapse_composition, line.parent_id.parent_id.collapse_composition]) and
            //             not any([line.parent_id.collapse_prices, line.parent_id.parent_id.collapse_prices])
            //         )
            //     )
            // 
            // return self.invoice_line_ids.filtered(show_line).sorted('sequence')
            */
            return default;
        }

        public async Task<TEntity> GetMoveZipExportDocsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_move_zip_export_docs(self):
            // self.ensure_one()
            // 
            // if self.state != 'posted':
            //     return []
            // 
            // if self.is_purchase_document(include_receipts=True):
            //     attachment = self.message_main_attachment_id
            //     return [{
            //         'filename': attachment.name,
            //         'filetype': attachment.mimetype,
            //         'content': attachment.raw,
            //     }] if attachment else []
            // 
            // return self._get_invoice_legal_documents_all()
            */
            return default;
        }

        public async Task<TEntity> GetMovesRequiringConfirmationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_moves_requiring_confirmation(self):
            // """Return the subset of moves that require confirmation before validation."""
            // return self.filtered(
            //     lambda move: (move.date or move.invoice_date) > fields.Date.context_today(self)
            //     or move.restrict_mode_hash_table,
            // )
            */
            return default;
        }

        public async Task<TEntity> GetNameInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_name_invoice_report(self):
            // """ This method need to be inherit by the localizations if they want to print a custom invoice report instead of
            // the default one. For example please review the l10n_ar module """
            // self.ensure_one()
            // return 'account.report_invoice_document'
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNewHireFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_new_hire_field(self):
            // return 'create_date'
            */
            return default;
        }

        public async Task<TEntity> GetNextStatesByStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_next_states_by_state(self):
            // self.ensure_one()
            // state_result = {
            //     'confirm': set(),
            //     'validate1': set(),
            //     'validate': set(),
            //     'refuse': set(),
            //     'cancel': set()
            // }
            // validation_type = self.validation_type
            // 
            // user_employees = self.env.user.employee_ids
            // is_own_leave = self.employee_id in user_employees
            // is_in_past = self.date_from and self.date_from.date() < fields.Date.today()
            // 
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // is_time_off_manager = self.employee_id.leave_manager_id == self.env.user
            // 
            // if is_own_leave and (not is_in_past or is_officer):
            //     state_result['validate1'].add('cancel')
            //     state_result['validate'].add('cancel')
            //     state_result['refuse'].add('cancel')
            // 
            // if is_officer:
            //     if validation_type == 'both':
            //         state_result['confirm'].add('validate1')
            //         state_result['refuse'].add('validate1')
            //         state_result['cancel'].add('validate1')
            //     state_result['confirm'].update({'validate', 'refuse'})
            //     state_result['validate1'].update({'confirm', 'validate', 'refuse'})
            //     state_result['validate'].update({'confirm', 'refuse'})
            //     state_result['refuse'].update({'confirm', 'validate'})
            //     state_result['cancel'].update({'confirm', 'validate', 'refuse'})
            // elif is_time_off_manager:
            //     if validation_type != 'hr':
            //         state_result['confirm'].add('refuse')
            //         state_result['validate'].add('refuse')
            //     if validation_type == 'both':
            //         state_result['confirm'].add('validate1')
            //         state_result['validate1'].add('refuse')
            //     elif validation_type == 'manager':
            //         state_result['confirm'].add('validate')
            //         state_result['refuse'].add('validate')
            // 
            // return state_result
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOutboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_outbound_types(self, include_receipts=True):
            // return ['in_invoice', 'out_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetOutstandingAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> GetOutstandingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_outstanding_account(self, payment_type):
            // account_ref = 'account_journal_payment_debit_account_id' if payment_type == 'inbound' else 'account_journal_payment_credit_account_id'
            // chart_template = self.with_context(allowed_company_ids=self.company_id.root_id.ids).env['account.chart.template']
            // outstanding_account = (
            //     chart_template.ref(account_ref, raise_if_not_found=False)
            //     or self.company_id.transfer_account_id
            // )
            // if not outstanding_account:
            //     raise UserError(_("No outstanding account could be found to make the payment"))
            // return outstanding_account
            */
            return default;
        }

        public async Task<TEntity> GetOverlappingContractsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_overlapping_contracts(self):
            // self.ensure_one()
            // domain = Domain.AND([
            //     Domain('employee_id', '=', self.employee_id.id),
            //     Domain('contract_date_start', '<=', self.date_to),
            //     Domain.OR([
            //         Domain('contract_date_end', '>=', self.date_from),
            //         Domain('contract_date_end', '=', False),
            //     ])
            // ])
            // versions = self.env['hr.version'].sudo().search(domain)
            // return versions.filtered(lambda v: v._is_overlapping_period(self.date_from.date(), self.date_to.date()))
            */
            return default;
        }

        public async Task<TEntity> GetParentFieldOnChildModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_parent_field_on_child_model(self):
            // return 'move_id'
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCountDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_partner_count_depends(self):
            // return ['user_id']
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCreditWarningExcludeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_partner_credit_warning_exclude_amount(self):
            // # to extend in module 'sale'; see there for details
            // self.ensure_one()
            // return 0
            */
            return default;
        }

        public async Task<TEntity> GetPaymentMethodCodesToExcludeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_payment_method_codes_to_exclude(self):
            // # can be overriden to exclude payment methods based on the payment characteristics
            // self.ensure_one()
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetPaymentReceiptReportValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_payment_receipt_report_values(self):
            // """ Get the extra values when rendering the Payment Receipt PDF report.
            // 
            // :return: A dictionary:
            //     * display_invoices: Display the invoices table.
            //     * display_payment_method: Display the payment method value.
            // """
            // self.ensure_one()
            // return {
            //     'display_invoices': True,
            //     'display_payment_method': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPortalPaymentLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_portal_payment_link(self):
            // # This method is designed to prevent traceback.
            // # Scenario: A traceback occurs when `account.payment` is not installed, and the user attempts to
            // # preview or print the invoice.
            // self.ensure_one()
            // return None
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_catalog_domain(self):
            // domain = super()._get_product_catalog_domain()
            // if self.is_sale_document():
            //     return domain & Domain('sale_ok', '=', True)
            // elif self.is_purchase_document():
            //     return domain & Domain('purchase_ok', '=', True)
            // else:  # In case of an entry
            //     return domain
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogOrderDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_catalog_order_data(self, products, **kwargs):
            // product_catalog = super()._get_product_catalog_order_data(products, **kwargs)
            // for product in products:
            //     product_catalog[product.id] |= self._get_product_price_and_data(product)
            // return product_catalog
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogRecordLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, *, section_id=None, **kwargs):
            // grouped_lines = defaultdict(lambda: self.env['account.move.line'])
            // if section_id is None:
            //     section_id = (
            //         self.line_ids[:1].id
            //         if self.line_ids[:1].display_type == 'line_section'
            //         else False
            //     )
            // for line in self.line_ids:
            //     if (
            //         line.get_parent_section_line().id == section_id
            //         and line.display_type == 'product'
            //         and line.product_id.id in product_ids
            //     ):
            //         grouped_lines[line.product_id] |= line
            // return grouped_lines
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceAndDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_price_and_data(self, product):
            // """
            //     This function will return a dict containing the price of the product. If the product is a sale document then
            //     we return the list price (which is the "Sales Price" in a product) otherwise we return the standard_price
            //     (which is the "Cost" in a product).
            //     In case of a purchase document, it's possible that we have special price for certain partner.
            //     We will check the sellers set on the product and update the price and min_qty for it if needed.
            // """
            // self.ensure_one()
            // product_infos = {'price': product.list_price if self.is_sale_document() else product.standard_price}
            // 
            // # Check if there is a price and a minimum quantity for the order's vendor.
            // if self.is_purchase_document() and self.partner_id:
            //     seller = product._select_seller(
            //         partner_id=self.partner_id,
            //         quantity=None,
            //         date=self.invoice_date,
            //         uom_id=product.uom_id,
            //         ordered_by='min_qty',
            //         params={'order_id': self}
            //     )
            //     if seller:
            //         product_infos.update(
            //             price=seller.price,
            //             min_qty=seller.min_qty,
            //         )
            // return product_infos
            */
            return default;
        }

        public async Task<TEntity> GetProtectedValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object records) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_protected_vals(self, vals, records):
            // protected = set()
            // for fname in vals:
            //     field = records._fields[fname]
            //     if field.inverse or (field.compute and not field.readonly):
            //         protected.update(self.pool.field_computed.get(field, [field]))
            // return [(protected, rec) for rec in records] if protected else []
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPurchaseTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_purchase_types(self, include_receipts=False):
            // return ['in_invoice', 'in_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetQuickEditSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_quick_edit_suggestions(self):
            // """
            // Returns a dictionnary containing the suggested values when creating a new
            // line with the quick_edit_total_amount set. We will compute the price_unit
            // that has to be set with the correct that in order to match this total amount.
            // If the vendor/customer is set, we will suggest the most frequently used account
            // for that partner as the default one, otherwise the default of the journal.
            // """
            // self.ensure_one()
            // if not self.quick_edit_mode or not self.quick_edit_total_amount:
            //     return False
            // count, account_id, tax_ids = self._get_frequent_account_and_taxes(
            //     self.company_id.id,
            //     self.partner_id.id,
            //     self.move_type,
            // )
            // if count:
            //     taxes = self.env['account.tax'].browse(tax_ids)
            // else:
            //     account_id = self.journal_id.default_account_id.id
            //     if self.is_sale_document(include_receipts=True):
            //         taxes = self.journal_id.default_account_id.tax_ids.filtered(lambda tax: tax.type_tax_use == 'sale')
            //     else:
            //         taxes = self.journal_id.default_account_id.tax_ids.filtered(lambda tax: tax.type_tax_use == 'purchase')
            //     if not taxes:
            //         taxes = (
            //             self.journal_id.company_id.account_sale_tax_id
            //             if self.journal_id.type == 'sale' else
            //             self.journal_id.company_id.account_purchase_tax_id
            //         )
            //     taxes = self.fiscal_position_id.map_tax(taxes)
            // 
            // # When a payment term has an early payment discount with the epd computation set to 'mixed', recomputing
            // # the untaxed amount should take in consideration the discount percentage otherwise we'd get a wrong value.
            // # We check that we have only one percentage tax as computing from multiple taxes with different types can get complicated.
            // # In one example: let's say: base = 100, discount = 2%, tax = 21%
            // # the total will be calculated as: total = base + (base * (1 - discount)) * tax
            // # If we manipulate the equation to get the base from the total, we'll have base = total / ((1 - discount) * tax + 1)
            // term = self.invoice_payment_term_id
            // discount_percentage = term.discount_percentage if term.early_discount else 0
            // remaining_amount = self.quick_edit_total_amount - self.tax_totals['total_amount_currency']
            // 
            // if (
            //         discount_percentage
            //         and term.early_pay_discount_computation == 'mixed'
            //         and len(taxes) == 1
            //         and taxes.amount_type == 'percent'
            // ):
            //     price_untaxed = self.currency_id.round(
            //         remaining_amount / (((1.0 - discount_percentage / 100.0) * (taxes.amount / 100.0)) + 1.0))
            // else:
            //     price_untaxed = taxes.with_context(force_price_include=True).compute_all(remaining_amount)['total_excluded']
            // return {'account_id': account_id, 'tax_ids': taxes.ids, 'price_unit': price_untaxed}
            */
            return default;
        }

        public async Task<TEntity> GetReconciledAmlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_amls(self):
            // """Helper used to retrieve the reconciled move lines on this journal entry"""
            // reconciled_lines = self.line_ids.filtered(lambda line: line.account_id.account_type in ('asset_receivable', 'liability_payable'))
            // return reconciled_lines.mapped('matched_debit_ids.debit_move_id') + reconciled_lines.mapped('matched_credit_ids.credit_move_id')
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_invoices(self):
            // """Helper used to retrieve the reconciled invoices on this journal entry"""
            // return self._get_reconciled_amls().move_id.filtered(lambda move: move.is_invoice(include_receipts=True))
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesPartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_invoices_partials(self):
            // ''' Helper to retrieve the details about reconciled invoices.
            // :return A list of tuple (partial, amount, invoice_line).
            // '''
            // self.ensure_one()
            // pay_term_lines = self.line_ids\
            //     .filtered(lambda line: line.account_type in ('asset_receivable', 'liability_payable'))
            // invoice_partials = []
            // exchange_diff_moves = []
            // 
            // for partial in pay_term_lines.matched_debit_ids:
            //     invoice_partials.append((partial, partial.credit_amount_currency, partial.debit_move_id))
            //     if partial.exchange_move_id:
            //         exchange_diff_moves.append(partial.exchange_move_id.id)
            // for partial in pay_term_lines.matched_credit_ids:
            //     invoice_partials.append((partial, partial.debit_amount_currency, partial.credit_move_id))
            //     if partial.exchange_move_id:
            //         exchange_diff_moves.append(partial.exchange_move_id.id)
            // return invoice_partials, exchange_diff_moves
            */
            return default;
        }

        public async Task<TEntity> GetReconciledPaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_payments(self):
            // """Helper used to retrieve the reconciled payments on this journal entry"""
            // return self._get_reconciled_amls().move_id.origin_payment_id
            */
            return default;
        }

        public async Task<TEntity> GetReconciledStatementLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_statement_lines(self):
            // """Helper used to retrieve the reconciled statement lines on this journal entry"""
            // return self._get_reconciled_amls().move_id.statement_line_id
            */
            return default;
        }

        public async Task<TEntity> GetRedirectSuggestedCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_redirect_suggested_company(self):
            // return self.holiday_status_id.company_id
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_related_partners(self):
            // return self.work_contact_id | self.user_id.partner_id
            */
            return default;
        }

        public async Task<TEntity> GetRemainingPercentageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_remaining_percentage(self):
            // self.ensure_one()
            // distribution = self.salary_distribution or {}
            // allocated = 0.0
            // 
            // for ba_id, vals in distribution.items():
            //     if vals.get('amount_is_percentage'):
            //         allocated += vals.get('amount', 0.0)
            // 
            // remaining = 100.0 - allocated
            // return max(0.0, remaining)
            */
            return default;
        }

        public async Task<TEntity> GetReportBaseFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_report_base_filename(self):
            // return self._get_move_display_name()
            */
            return default;
        }

        public async Task<TEntity> GetResponsibleForApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_responsible_for_approval(self):
            // self.ensure_one()
            // 
            // responsible = self.env['res.users']
            // if self.validation_type == 'manager' or (self.validation_type == 'both' and self.state == 'confirm'):
            //     if self.employee_id.leave_manager_id:
            //         responsible = self.employee_id.leave_manager_id
            //     elif self.employee_id.parent_id.user_id:
            //         responsible = self.employee_id.parent_id.user_id
            // elif self.validation_type == 'hr' or (self.validation_type == 'both' and self.state == 'validate1'):
            //     if self.holiday_status_id.responsible_ids:
            //         responsible = self.holiday_status_id.responsible_ids
            // return responsible
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_rotting_depends_fields(self):
            // return super()._get_rotting_depends_fields() + ['application_status', 'date_closed']
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_rotting_domain(self):
            // return super()._get_rotting_domain() & Domain([
            //     ('application_status', '=', 'ongoing'),
            //     ('date_closed', '=', False),
            // ])
            */
            return default;
        }

        public async Task<TEntity> GetRoundedBaseAndTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object round_from_tax_lines) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_rounded_base_and_tax_lines(self, round_from_tax_lines=True):
            // """ Small helper to extract the base and tax lines for the taxes computation from the current move.
            // The move could be stored or not and could have some features generating extra journal items acting as
            // base lines for the taxes computation (e.g. epd, rounding lines).
            // 
            // :param round_from_tax_lines:    Indicate if the manual tax amounts of tax journal items should be kept or not.
            //                                 It only works when the move is stored.
            // :return:                        A tuple <base_lines, tax_lines> for the taxes computation.
            // """
            // self.ensure_one()
            // AccountTax = self.env['account.tax']
            // is_invoice = self.is_invoice(include_receipts=True)
            // 
            // if self.id or not is_invoice:
            //     base_amls = self.line_ids.filtered(lambda line: line.display_type == 'product')
            // else:
            //     base_amls = self.invoice_line_ids.filtered(lambda line: line.display_type == 'product')
            // base_lines = [self._prepare_product_base_line_for_taxes_computation(line) for line in base_amls]
            // 
            // tax_lines = []
            // if self.id:
            //     # The move is stored so we can add the early payment discount lines directly to reduce the
            //     # tax amount without touching the untaxed amount.
            //     epd_amls = self.line_ids.filtered(lambda line: line.display_type == 'epd')
            //     base_lines += [self._prepare_epd_base_line_for_taxes_computation(line) for line in epd_amls]
            //     cash_rounding_amls = self.line_ids \
            //         .filtered(lambda line: line.display_type == 'rounding' and not line.tax_repartition_line_id)
            //     base_lines += [self._prepare_cash_rounding_base_line_for_taxes_computation(line) for line in cash_rounding_amls]
            //     non_deductible_base_lines = self.line_ids.filtered(lambda line: line.display_type in ('non_deductible_product', 'non_deductible_product_total'))
            //     base_lines += [self._prepare_non_deductible_base_line_for_taxes_computation(line) for line in non_deductible_base_lines]
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     tax_amls = self.line_ids.filtered('tax_repartition_line_id')
            //     tax_lines = [self._prepare_tax_line_for_taxes_computation(tax_line) for tax_line in tax_amls]
            //     if round_from_tax_lines == 'reapply_currency_rate':
            //         for tax_line in tax_lines:
            //             rate = tax_line['record'].currency_rate
            //             if rate:
            //                 tax_line['balance'] = self.company_currency_id.round(tax_line['amount_currency'] / rate)
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id, tax_lines=tax_lines if round_from_tax_lines else [])
            // else:
            //     # The move is not stored yet so the only thing we have is the invoice lines.
            //     base_lines += self._prepare_epd_base_lines_for_taxes_computation_from_base_lines(base_amls)
            //     base_lines += self._prepare_non_deductible_base_lines_for_taxes_computation_from_base_lines(base_amls)
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // return base_lines, tax_lines
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_sale_types(self, include_receipts=False):
            // return ['out_invoice', 'out_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetSequenceDateRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reset) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_sequence_date_range(self, reset):
            // if reset not in ('year_range', 'year_range_month'):
            //     return super()._get_sequence_date_range(reset)
            // 
            // fiscalyear_last_day = self.company_id.fiscalyear_last_day
            // fiscalyear_last_month = int(self.company_id.fiscalyear_last_month)
            // date_start, date_end = date_utils.get_fiscal_year(self.date, day=fiscalyear_last_day, month=fiscalyear_last_month)
            // 
            // if reset == 'year_range':
            //     return (date_start, date_end) + (None, None)
            // 
            // forced_year_range = (date_start.year, date_end.year)
            // month_range = date_utils.get_month(self.date)
            // fiscalyear_last_month_max_day = calendar.monthrange(self.date.year, fiscalyear_last_month)[1]
            // # We need to truncate the month if:
            // # - the fiscal year does not end on the last day of the month
            // # - and the move date is part of that month
            // # The sequence date range will be something like 2020-11-01 to
            // # 2020-11-30. But the sequence should be 2019-2020/11/0001 (or
            // # 2020-2021/11/0001), not 2020-2020/11/0001.
            // if fiscalyear_last_day < fiscalyear_last_month_max_day and fiscalyear_last_month == self.date.month:
            //     if self.date.day <= fiscalyear_last_day:
            //         return (month_range[0], month_range[1].replace(day=fiscalyear_last_day)) + forced_year_range
            //     else:
            //         return (month_range[0].replace(day=fiscalyear_last_day + 1), month_range[1]) + forced_year_range
            // else:
            //     return month_range + forced_year_range
            */
            return default;
        }

        public async Task<TEntity> GetSimilarApplicantsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ignore_talent, object only_talent) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_similar_applicants_domain(self, ignore_talent=False, only_talent=False):
            // """
            // This method returns a domain for the applicants whitch match with the
            // current applicant according to email_from, partner_phone or linkedin_profile.
            // Thus, search on the domain will return the current applicant as well
            // if any of the following fields are filled.
            // 
            // Args:
            //     ignore_talent: if you want the domain to only include applicants not belonging to a talent pool
            //     only_talent: if you want the domain to only include applicants belonging to a talent pool
            // 
            // Returns:
            //     Domain()
            // """
            // domain = Domain.AND([
            //     Domain('company_id', 'in', self.mapped('company_id.id')),
            //     Domain.OR([
            //         Domain("id", "in", self.ids),
            //         Domain("email_normalized", "in", [email for email in self.mapped("email_normalized") if email]),
            //         Domain("partner_phone_sanitized", "in", [phone for phone in self.mapped("partner_phone_sanitized") if phone]),
            //         Domain("linkedin_profile", "in", [linkedin_profile for linkedin_profile in self.mapped("linkedin_profile") if linkedin_profile]),
            //         Domain("pool_applicant_id", "in", [pool_applicant.id for pool_applicant in self.mapped("pool_applicant_id") if pool_applicant]),
            //     ])
            // ])
            // if ignore_talent:
            //     domain &= Domain("talent_pool_ids", "=", False)
            // if only_talent:
            //     domain &= Domain("talent_pool_ids", "!=", False)
            // return domain
            */
            return default;
        }

        public async Task<TEntity> GetSplitValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> GetStartingSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_starting_sequence(self):
            // # EXTENDS account sequence.mixin
            // self.ensure_one()
            // move_date = self.date or self.invoice_date or fields.Date.context_today(self)
            // year_part = "%04d" % move_date.year
            // last_day = int(self.company_id.fiscalyear_last_day)
            // last_month = int(self.company_id.fiscalyear_last_month)
            // is_staggered_year = last_month != 12 or last_day != 31
            // if is_staggered_year:
            //     max_last_day = calendar.monthrange(move_date.year, last_month)[1]
            //     last_day = min(last_day, max_last_day)
            //     if move_date > date(move_date.year, last_month, last_day):
            //         year_part = "%s-%s" % (move_date.strftime('%y'), (move_date + relativedelta(years=1)).strftime('%y'))
            //     else:
            //         year_part = "%s-%s" % ((move_date + relativedelta(years=-1)).strftime('%y'), move_date.strftime('%y'))
            // # Arbitrarily use annual sequence for sales documents, but monthly
            // # sequence for other documents
            // if self.journal_id.type in ['sale', 'bank', 'cash', 'credit']:
            //     # We reduce short code to 4 characters (0000) in case of staggered
            //     # year to avoid too long sequences (see Indian GST rule 46(b) for
            //     # example). Note that it's already the case for monthly sequences.
            //     starting_sequence = "%s/%s/%s" % (self.journal_id.code, year_part, '0000' if is_staggered_year else '00000')
            // else:
            //     if self.journal_id.is_self_billing:
            //         partner_identifier = str(self.partner_id.commercial_partner_id.id) if self.partner_id else _('[Partner id]')
            //         starting_sequence = "%s%s/%s/%02d/0000" % (
            //             self.journal_id.code,
            //             partner_identifier.zfill(5),
            //             year_part,
            //             move_date.month,
            //         )
            //     else:
            //         starting_sequence = "%s/%s/%02d/0000" % (self.journal_id.code, year_part, move_date.month)
            // 
            // if self.journal_id.refund_sequence and self.move_type in ('out_refund', 'in_refund'):
            //     starting_sequence = "R" + starting_sequence
            // if self.journal_id.payment_sequence and self.origin_payment_id or self.env.context.get('is_payment'):
            //     starting_sequence = "P" + starting_sequence
            // return starting_sequence
            */
            return default;
        }

        public async Task<TEntity> GetStoreAvatarCardFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_store_avatar_card_fields(self, target):
            // employee_fields = [
            //     "company_id",
            //     Store.One("department_id", ["name"]),
            //     "work_email",
            //     Store.One("work_location_id", ["location_type", "name"]),
            //     "work_phone",
            // ]
            // user = target.get_user(self.env)
            // if user.has_group("hr.group_hr_user"):
            //     # job_title is not a field of hr.employee.public, but it is a field of hr.employee
            //     employee_fields.append("job_title")
            // # HACK: fetch the employee fields from employees to retrieve hr.employee.public fields if no access to hr.employee
            // if len(self) > 0:
            //     self.fetch([
            //         field.field_name if isinstance(field, Store.Attr) else field
            //         for field in employee_fields
            //     ])
            // return employee_fields
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type, object company) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_suitable_journal_ids(self, move_type, company=False):
            // """Return the suitable journals for the given move type and company (current company if False)."""
            // journal_type = self._get_invoice_filter_type_domain(move_type) or 'general'
            // return self.env['account.journal'].search([
            //     *self.env['account.journal']._check_company_domain(company or self.env.company),
            //     ('type', '=', journal_type),
            // ])
            */
            return default;
        }

        public async Task<TEntity> GetSyncStackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_sync_stack(self, container):
            // tax_container, invoice_container, misc_container = ({} for _ in range(3))
            // 
            // def update_containers():
            //     # Only invoice-like and journal entries in "auto tax mode" are synced
            //     tax_container['records'] = container['records'].filtered(lambda m: m.is_invoice(True) or m.line_ids.tax_ids or m.line_ids.tax_repartition_line_id)
            //     invoice_container['records'] = container['records'].filtered(lambda m: m.is_invoice(True))
            //     misc_container['records'] = container['records'].filtered(lambda m: m.is_entry() and not m.tax_cash_basis_origin_move_id)
            // 
            //     return tax_container, invoice_container, misc_container
            // 
            // update_containers()
            // 
            // stack = [
            //     (10, self._sync_dynamic_line(
            //             existing_key_fname='term_key',
            //             needed_vals_fname='needed_terms',
            //             needed_dirty_fname='needed_terms_dirty',
            //             line_type='payment_term',
            //             container=invoice_container,
            //         )),
            //     (20, self._sync_unbalanced_lines(misc_container)),
            //     (30, self._sync_rounding_lines(invoice_container)),
            //     (40, self._sync_dynamic_line(
            //             existing_key_fname='discount_allocation_key',
            //             needed_vals_fname='line_ids.discount_allocation_needed',
            //             needed_dirty_fname='line_ids.discount_allocation_dirty',
            //             line_type='discount',
            //             container=invoice_container,
            //         )),
            //     (50, self._sync_tax_lines(tax_container)),
            //     (60, self._sync_non_deductible_base_lines(invoice_container)),
            //     (70, self._sync_dynamic_line(
            //             existing_key_fname='epd_key',
            //             needed_vals_fname='line_ids.epd_needed',
            //             needed_dirty_fname='line_ids.epd_dirty',
            //             line_type='epd',
            //             container=invoice_container,
            //         )),
            //     (80, self._sync_invoice(invoice_container)),
            // ]
            // 
            // return stack, update_containers
            */
            return default;
        }

        public async Task<TEntity> GetToCleanActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_to_clean_activities(self):
            // return ['hr_holidays.mail_act_leave_approval', 'hr_holidays.mail_act_leave_second_approval']
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTriggerFieldsToSynchronizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_trigger_fields_to_synchronize(self):
            // return (
            //     'date', 'amount', 'payment_type', 'partner_type', 'payment_reference',
            //     'currency_id', 'partner_id', 'destination_account_id', 'partner_bank_id', 'journal_id'
            // )
            */
            return default;
        }

        public async Task<TEntity> GetTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_tz_batch(self):
            // # Finds the first valid timezone in his tz, his work hours tz,
            // #  the company calendar tz or UTC
            // # Returns a dict {employee_id: tz}
            // return {emp.id: emp._get_tz() for emp in self}
            */
            return default;
        }

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_tz(self):
            // self.ensure_one()
            // return self.resource_calendar_id.tz or\
            //        self.tz or\
            //        self.company_id.resource_calendar_id.tz or\
            //        'UTC'
            */
            return default;
        }

        public async Task<TEntity> GetUnbalancedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_unbalanced_moves(self, container):
            // moves = container['records'].filtered(lambda move: move.line_ids)
            // if not moves:
            //     return
            // 
            // # /!\ As this method is called in create / write, we can't make the assumption the computed stored fields
            // # are already done. Then, this query MUST NOT depend on computed stored fields.
            // # It happens as the ORM calls create() with the 'no_recompute' statement.
            // self.env['account.move.line'].flush_model(['debit', 'credit', 'balance', 'currency_id', 'move_id'])
            // return self.env.execute_query(SQL('''
            //     SELECT line.move_id,
            //            ROUND(SUM(line.debit), currency.decimal_places) debit,
            //            ROUND(SUM(line.credit), currency.decimal_places) credit
            //       FROM account_move_line line
            //       JOIN account_move move ON move.id = line.move_id
            //       JOIN res_company company ON company.id = move.company_id
            //       JOIN res_currency currency ON currency.id = company.currency_id
            //      WHERE line.move_id IN %s
            //   GROUP BY line.move_id, currency.decimal_places
            //     HAVING ROUND(SUM(line.balance), currency.decimal_places) != 0
            // ''', tuple(moves.ids)))
            */
            return default;
        }

        public async Task<TEntity> GetUnlinkLoggerMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_unlink_logger_message(self):
            // """ Before unlink, get a log message for audit trail if restricted.
            // Logger is added here because in api ondelete, account.move.line is deleted, and we can't get total amount """
            // if not self.env.context.get('force_delete'):
            //     pass
            // 
            // moves_details = []
            // for move in self.filtered(lambda m: m.posted_before and m.company_id.restrictive_audit_trail):
            //     entry_details = f"{move.name} ({move.id}) amount {move.amount_total} {move.currency_id.name} and partner {move.partner_id.display_name}"
            //     account_balances_per_account = defaultdict(float)
            //     for line in move.line_ids:
            //         account_balances_per_account[line.account_id] += line.balance
            //     account_details = "\n".join(
            //         f"- {account.name} ({account.id}) with balance {balance} {move.currency_id.name}"
            //         for account, balance in account_balances_per_account.items()
            //     )
            //     moves_details.append(f"{entry_details}\n{account_details}")
            // 
            // if moves_details:
            //     return "\nForce deleted Journal Entries by {user_name} ({user_id})\nEntries\n{moves_details}".format(
            //         user_name=self.env.user.name,
            //         user_id=self.env.user.id,
            //         moves_details="\n".join(moves_details),
            //     )
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUntitledExpenseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _get_untitled_expense_name(self, *args):
            // """ Done in a specific function to be called by hr_expense_extract to keep the same translation """
            // return _("Untitled Expense %s", *args)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def get_unusual_days(self, date_from, date_to=None):
            // employee_id = self.env.context.get('employee_id', False)
            // employee = self.env['hr.employee'].browse(employee_id) if employee_id else self.env.user.employee_id
            // return employee.sudo(False)._get_unusual_days(date_from, date_to)
            */
            return default;
        }

        public async Task<TEntity> GetUnusualDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_unusual_days(self, date_from, date_to=None):
            // date_from_date = datetime.strptime(date_from, '%Y-%m-%d %H:%M:%S').date()
            // date_to_date = datetime.strptime(date_to, '%Y-%m-%d %H:%M:%S').date() if date_to else None
            // employee_versions = self.env['hr.version'].sudo().search([('employee_id', '=', self.id)]).filtered(
            //     lambda v: v._is_overlapping_period(date_from_date, date_to_date))
            // if not employee_versions:
            //     # Checking the calendar directly allows to not grey out the leaves taken
            //     # by the employee or fallback to the company calendar
            //     return (self.resource_calendar_id or self.env.company.resource_calendar_id)._get_unusual_days(
            //         datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=UTC),
            //         datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=UTC),
            //         self.company_id,
            //     )
            // unusual_days = {}
            // for version in employee_versions:
            //     tmp_date_from = max(date_from_date, version.date_start)
            //     tmp_date_to = min(date_to_date, version.date_end) if version.date_end else date_to_date
            //     unusual_days.update(version.resource_calendar_id.sudo(False)._get_unusual_days(
            //         datetime.combine(fields.Date.from_string(tmp_date_from), time.min).replace(tzinfo=UTC),
            //         datetime.combine(fields.Date.from_string(tmp_date_to), time.max).replace(tzinfo=UTC),
            //         self.company_id,
            //     ))
            // return unusual_days
            */
            return default;
        }

        public async Task<TEntity> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_user_m2o_to_empty_on_archived_employees(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetValidJournalTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_valid_journal_types(self):
            // if self.is_sale_document(include_receipts=True):
            //     return ['sale']
            // elif self.is_purchase_document(include_receipts=True):
            //     return ['purchase']
            // elif self.origin_payment_id or self.statement_line_id or self.env.context.get('is_payment') or self.env.context.get('is_statement_line'):
            //     return ['bank', 'cash', 'credit']
            // return ['general']
            */
            return default;
        }

        public async Task<TEntity> GetValidLiquidityAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_valid_liquidity_accounts(self):
            // return (
            //     self.journal_id.default_account_id |
            //     self.payment_method_line_id.payment_account_id |
            //     self.journal_id.inbound_payment_method_line_ids.payment_account_id |
            //     self.journal_id.outbound_payment_method_line_ids.payment_account_id |
            //     self.outstanding_account_id
            // )
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetValidPaymentAccountTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _get_valid_payment_account_types(self):
            // return ['asset_receivable', 'liability_payable']
            */
            return default;
        }

        public async Task<TEntity> GetVersionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_version(self, date=fields.Date.today()):
            // """
            // Return the version that should be used for the given date.
            // If no valid version is found, we return the very first version of the employee.
            // """
            // self.ensure_one()
            // versions = self.version_ids.filtered_domain([('date_version', '<=', date)])
            // return max(versions, key=lambda v: v.date_version) if versions else self.version_ids[0]
            */
            return default;
        }

        public async Task<TEntity> GetVersionPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object field, object check_contract) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_version_periods(self, start, stop, field=None, check_contract=False):
            // if field and field not in self:
            //     raise UserError(self.env._(
            //         "This field %(field_name)s doesn't exist on this model (hr.version).",
            //         field_name=field
            //     ))
            // version_periods_by_employee = defaultdict(list)
            // if check_contract:
            //     versions = self._get_versions_with_contract_overlap_with_period(start.date(), stop.date())
            // else:
            //     versions = self.version_ids.filtered_domain([
            //         ('date_start', '<=', stop),
            //         '|',
            //             ('date_end', '=', False),
            //             ('date_end', '>=', start)
            //     ])
            // for version in versions:
            //     # if employee is under fully flexible contract, use timezone of the employee
            //     calendar_tz = timezone(version.resource_calendar_id.tz) if version.resource_calendar_id else timezone(version.employee_id.resource_id.tz)
            //     date_start = datetime.combine(version.date_start, time.min).replace(tzinfo=calendar_tz).astimezone(utc)
            //     end_date = version.date_end
            //     if end_date:
            //         date_end = datetime.combine(
            //             end_date + relativedelta(days=1),
            //             time.min,
            //         ).replace(tzinfo=calendar_tz).astimezone(utc)
            //     else:
            //         date_end = stop
            //     version_periods_by_employee[version.employee_id].append(
            //         (max(date_start, start), min(date_end, stop), version[field] if field else version))
            // return version_periods_by_employee
            */
            return default;
        }

        public async Task<TEntity> GetVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_versions_with_contract_overlap_with_period(self, date_from, date_to):
            // """
            // Returns the versions of the employee between date_from and date_to
            // that have at least 1 day in contract during that period
            // """
            // return self.version_ids.filtered_domain([
            //     ('contract_date_start', '!=', False), ('contract_date_start', '<=', date_to),
            //     '|', ('contract_date_end', '>=', date_from), ('contract_date_end', '=', False),
            // ])
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // if self.browse().has_access('read'):
            //     return super().get_view(view_id, view_type, **options)
            // return self.env['hr.employee.public'].get_view(view_id, view_type, **options)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // if view_type == 'form' and self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer')\
            //     and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     view_id = self.env.ref('hr_recruitment.hr_applicant_view_form_interviewer').id
            // return super().get_view(view_id, view_type, **options)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_views(self, views, options=None):
            //         if self.browse().has_access('read'):
            //             return super().get_views(views, options)
            //         # returning public employee data would cause a traceback when building
            //         # the private employee xml view
            //         raise RedirectWarning(
            //             message=_(
            //             """You are not allowed to access "Employee" (hr.employee) records.
            // We can redirect you to the public employee list."""
            //             ),
            //             action=self.env.ref('hr.hr_employee_public_action').id,
            //             button_text=_("Employees profile"),
            //         )
            */
            return default;
        }

        public async Task<TEntity> GetViolatedLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_violated_lock_dates(self, invoice_date, has_tax):
            // """Get all the lock dates affecting the current invoice_date.
            // :param invoice_date: The invoice date
            // :param has_tax: If any taxes are involved in the lines of the invoice
            // :return: a list of tuples containing the lock dates affecting this move, ordered chronologically.
            // """
            // self.ensure_one()
            // return self.company_id._get_violated_lock_dates(invoice_date, has_tax, self.journal_id)
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _has_field_access(self, field, operation):
            // # DISCLAIMER: Dirty hack to avoid having to create a bridge module to override only a
            // # groups on a field which is not prefetched (because not stored) but would crash anyway
            // # if we try to read them directly (very uncommon use case). Don't add your field on this
            // # list if you can specify the group on the field directly (as all the other fields).
            // return super()._has_field_access(field, operation) and (
            //     self.env.su
            //     or self.env.user.has_group("hr.group_hr_user")
            //     or field.name not in ('activity_calendar_event_id', 'rating_ids', 'website_message_ids', 'message_has_sms_error')
            // )
            */
            return default;
        }

        public async Task<TEntity> HashMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _hash_moves(self, **kwargs):
            // chains_to_hash = self._get_chains_to_hash(**kwargs)
            // grant_secure_group_access = False
            // for chain in chains_to_hash:
            //     move_hashes = chain['moves'].sudo()._calculate_hashes(chain['previous_hash'])
            //     for move, move_hash in move_hashes.items():
            //         move.inalterable_hash = move_hash
            //     # If any secured entries belong to journals without 'hash on post', the user should be granted access rights
            //     if not chain['journal_restrict_mode']:
            //         grant_secure_group_access = True
            //     chain['moves']._message_log_batch(bodies={m.id: self.env._("This journal entry has been secured.") for m in chain['moves']})
            // if grant_secure_group_access:
            //     self.env['res.groups']._activate_group_account_secured()
            */
            return default;
        }

        public async Task<TEntity> InverseAmountTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_amount_total(self):
            // for move in self:
            //     if len(move.line_ids) != 2 or move.is_invoice(include_receipts=True):
            //         continue
            // 
            //     to_write = []
            // 
            //     amount_currency = abs(move.amount_total)
            //     balance = move.currency_id._convert(amount_currency, move.company_currency_id, move.company_id, move.invoice_date or move.date)
            // 
            //     for line in move.line_ids:
            //         if not line.currency_id.is_zero(balance - abs(line.balance)):
            //             to_write.append((1, line.id, {
            //                 'debit': line.balance > 0.0 and balance or 0.0,
            //                 'credit': line.balance < 0.0 and balance or 0.0,
            //                 'amount_currency': line.balance > 0.0 and amount_currency or -amount_currency,
            //             }))
            // 
            //     move.write({'line_ids': to_write})
            */
            return default;
        }

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_company_id(self):
            // for move in self:
            //     # This can't be caught by a python constraint as it is only triggered at save and the compute method that
            //     # needs this data to be set correctly before saving
            //     if not move.company_id:
            //         raise ValidationError(_("We can't leave this document without any company. Please select a company for this document."))
            // self._conditional_add_to_compute('journal_id', lambda m: (
            //     not m.journal_id.filtered_domain(self.env['account.journal']._check_company_domain(m.company_id))
            // ))
            */
            return default;
        }

        public async Task<TEntity> InverseCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_currency_id(self):
            // (self.line_ids | self.invoice_line_ids)._conditional_add_to_compute('currency_id', lambda l: (
            //     l.move_id.is_invoice(True)
            //     and l.move_id.currency_id != l.currency_id
            // ))
            */
            return default;
        }

        public async Task<TEntity> InverseDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _inverse_description(self):
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // 
            // for leave in self:
            //     if is_officer or leave.user_id == self.env.user or leave.employee_id.leave_manager_id == self.env.user:
            //         leave.sudo().private_name = leave.name
            */
            return default;
        }

        public async Task<TEntity> InverseInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_invoice_payment_term_id(self):
            // self.line_ids._conditional_add_to_compute('name', lambda l: (
            //     l.display_type == 'payment_term'
            // ))
            */
            return default;
        }

        public async Task<TEntity> InverseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_journal_id(self):
            // self._conditional_add_to_compute('company_id', lambda m: (
            //     not m.company_id
            //     or m.company_id != m.journal_id.company_id
            // ))
            // self._conditional_add_to_compute('currency_id', lambda m: (
            //     not m.currency_id
            //     or m.journal_id.currency_id and m.currency_id != m.journal_id.currency_id
            // ))
            */
            return default;
        }

        public async Task<TEntity> InverseMemoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _inverse_memo(self):
            // for payment in self:
            //     move = payment.move_id
            //     if move:
            //         move.ref = payment.memo
            */
            return default;
        }

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_name(self):
            // self._conditional_add_to_compute('payment_reference', lambda move: (
            //     move.name and move.name != '/'
            // ))
            // self._set_next_made_sequence_gap(False)
            */
            return default;
        }

        public async Task<TEntity> InverseNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_no_followup(self):
            // for move in self:
            //     if move.is_invoice():
            //         move.line_ids.filtered(
            //             lambda line: line.account_type in ('asset_receivable', 'liability_payable'),
            //         ).no_followup = move.no_followup
            */
            return default;
        }

        public async Task<TEntity> InversePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _inverse_partner_email(self):
            // for applicant in self:
            //     email_normalized = tools.email_normalize(applicant.email_from or '')
            //     if not email_normalized:
            //         continue
            //     if not applicant.partner_id:
            //         if not applicant.partner_name:
            //             raise UserError(_("You must define a Contact Name for this applicant."))
            //         applicant.partner_id = applicant._partner_find_from_emails_single(
            //             [applicant.email_from], no_create=False,
            //             additional_values={
            //                 email_normalized: {'lang': self.env.lang}
            //             },
            //         )
            //     if applicant.partner_name and applicant.partner_name != applicant.partner_id.name:
            //         applicant.partner_id.name = applicant.partner_name
            //     if email_normalized and email_normalized != applicant.partner_id.email:
            //         applicant.partner_id.email = applicant.email_from
            //     if applicant.partner_phone and applicant.partner_phone != applicant.partner_id.phone:
            //         applicant.partner_id.phone = applicant.partner_phone
            */
            return default;
        }

        public async Task<TEntity> InversePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_partner_id(self):
            // for invoice in self:
            //     if invoice.is_invoice(True):
            //         for line in invoice.line_ids + invoice.invoice_line_ids:
            //             if line.partner_id != invoice.commercial_partner_id:
            //                 line.partner_id = invoice.commercial_partner_id
            //                 line._inverse_partner_id()
            */
            return default;
        }

        public async Task<TEntity> InversePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_payment_reference(self):
            // self.line_ids._conditional_add_to_compute('name', lambda line: (
            //     line.display_type == 'payment_term'
            // ))
            */
            return default;
        }

        public async Task<TEntity> InverseSupportedAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _inverse_supported_attachment_ids(self):
            // for holiday in self:
            //     holiday.attachment_ids = holiday.supported_attachment_ids
            // self.invalidate_recordset(['attachment_ids'])
            */
            return default;
        }

        public async Task<TEntity> InverseTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _inverse_tax_totals(self):
            // with self._disable_recursion({'records': self}, 'skip_invoice_sync') as disabled:
            //     if disabled:
            //         return
            // with self._sync_dynamic_line(
            //     existing_key_fname='term_key',
            //     needed_vals_fname='needed_terms',
            //     needed_dirty_fname='needed_terms_dirty',
            //     line_type='payment_term',
            //     container={'records': self},
            // ):
            //     for move in self:
            //         if not move.is_invoice(include_receipts=True):
            //             continue
            //         invoice_totals = move.tax_totals
            // 
            //         for subtotal in invoice_totals['subtotals']:
            //             for tax_group in subtotal['tax_groups']:
            //                 tax_lines = move.line_ids.filtered(lambda line: line.tax_group_id.id == tax_group['id'])
            // 
            //                 if tax_lines:
            //                     first_tax_line = tax_lines[0]
            //                     tax_group_old_amount = sum(tax_lines.mapped('amount_currency'))
            //                     sign = -1 if move.is_inbound() else 1
            //                     delta_amount = (tax_group_old_amount - tax_group.get('non_deductible_tax_amount_currency', 0.0)) * sign - tax_group['tax_amount_currency']
            // 
            //                     if not move.currency_id.is_zero(delta_amount):
            //                         first_tax_line.amount_currency -= delta_amount * sign
            //     self._compute_amount()
            */
            return default;
        }

        public async Task<TEntity> InverseTotalAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> InverseTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> InverseWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _inverse_work_contact_details(self):
            // employees_without_work_contact = self.env['hr.employee']
            // for employee in self:
            //     if not employee.work_contact_id:
            //         employees_without_work_contact += employee
            //     else:
            //         if len(employee.work_contact_id.employee_ids) <= 1:
            //             employee.work_contact_id.sudo().write({
            //                 'email': employee.work_email,
            //                 'phone': employee.work_phone,
            //             })
            // if employees_without_work_contact:
            //     employees_without_work_contact.sudo()._create_work_contacts()
            */
            return default;
        }

        public async Task<TEntity> InvoicePaidHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _invoice_paid_hook(self):
            // ''' Hook to be overrided called when the invoice moves to the paid state. '''
            */
            return default;
        }

        public async Task<TEntity> IsActionReportAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action_report, object is_invoice_report) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_action_report_available(self, action_report, is_invoice_report=True):
            // assert len(action_report) == 1
            // 
            // self.ensure_one()
            // 
            // if available_report := action_report.filtered(lambda available_report: not (is_invoice_report^available_report.is_invoice_report)):
            //     return bool(self.filtered_domain(ast.literal_eval(available_report.domain or '[]')))
            // 
            // return False
            */
            return default;
        }

        public async Task<TEntity> IsDownpaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_downpayment(self):
            // ''' Return true if the invoice is a downpayment.
            // Down-payments can be created from a sale order. This method is overridden in the sale order module.
            // '''
            // return False
            */
            return default;
        }

        public async Task<TEntity> IsEligibleForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object currency, object reference_date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_eligible_for_early_payment_discount(self, currency, reference_date):
            // self.ensure_one()
            // payment_terms = self.line_ids.filtered(lambda line: line.display_type == 'payment_term')
            // return self.currency_id == currency \
            //     and self.move_type in self._early_payment_discount_move_types() \
            //     and self.invoice_payment_term_id.early_discount \
            //     and (
            //         not reference_date
            //         or not self.invoice_date
            //         or (
            //             (existing_discount_date := next(iter(payment_terms)).discount_date)
            //             and
            //             reference_date <= existing_discount_date
            //         )
            //     ) \
            //     and not (payment_terms.sudo().matched_debit_ids + payment_terms.sudo().matched_credit_ids)
            */
            return default;
        }

        public async Task<TEntity> IsEntryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_entry(self):
            // return self.move_type == 'entry'
            */
            return default;
        }

        public async Task<TEntity> IsInContractInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _is_in_contract(self, date):
            // return self._get_contract_dates(date) != (False, False)
            */
            return default;
        }

        public async Task<TEntity> IsInboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_inbound(self, include_receipts=True):
            // return self.move_type in self.get_inbound_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_invoice(self, include_receipts=False):
            // return self.is_sale_document(include_receipts) or self.is_purchase_document(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsLineValidForSectionLineCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_line_valid_for_section_line_count(self, line):
            // """Check if a line is valid for inclusion in the section's line count.
            // 
            // :param recordset line: A record of a move line.
            // :return: True if this line is a valid, else False.
            // :rtype: bool
            // """
            // return (
            //     line.product_id
            //     and line.product_id.product_tmpl_id.type != 'combo'
            //     and line.quantity > 0
            // )
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsMoveRestrictedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object force_hash) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_move_restricted(self, move, force_hash=False):
            // """
            // Returns whether a move should be hashed (depending on journal settings)
            // :param move: the account.move we check
            // :param force_hash: if True, we'll check all moves posted, independently of journal settings
            // """
            // return move.filtered_domain(self._get_move_hash_domain(force_hash=force_hash))
            */
            return default;
        }

        public async Task<TEntity> IsOutboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_outbound(self, include_receipts=True):
            // return self.move_type in self.get_outbound_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsProtectedByAuditTrailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_protected_by_audit_trail(self):
            // return any(move.posted_before and move.company_id.restrictive_audit_trail for move in self)
            */
            return default;
        }

        public async Task<TEntity> IsPurchaseDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_purchase_document(self, include_receipts=False, move_type=False):
            // return (move_type or self.move_type) in self.get_purchase_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_readonly(self):
            // """
            //     Check if the move has been canceled
            // """
            // self.ensure_one()
            // return self.state == 'cancel'
            */
            return default;
        }

        public async Task<TEntity> IsReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_ready_to_be_sent(self):
            // """ Helper telling if a journal entry is ready to be sent by mail to the customer.
            // 
            // :return: True if the invoice is ready, False otherwise.
            // """
            // self.ensure_one()
            // return True
            */
            return default;
        }

        public async Task<TEntity> IsReceiptAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_receipt(self):
            // return self.move_type in ['out_receipt', 'in_receipt']
            */
            return default;
        }

        public async Task<TEntity> IsSaleDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_sale_document(self, include_receipts=False, move_type=False):
            // return (move_type or self.move_type) in self.get_sale_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsUserAbleToReviewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_user_able_to_review(self):
            // # If only account is installed, we don't check user access rights.
            // return True
            */
            return default;
        }

        public async Task<TEntity> JsAssignOutstandingLineAsync<TEntity>(IEnumerable<TEntity> entities, Guid line_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def js_assign_outstanding_line(self, line_id):
            // ''' Called by the 'payment' widget to reconcile a suggested journal item to the present
            // invoice.
            // 
            // :param line_id: The id of the line to reconcile with the current invoice.
            // '''
            // self.ensure_one()
            // lines = self.env['account.move.line'].browse(line_id)
            // lines += self.line_ids.filtered(lambda line: line.account_id == lines[0].account_id and not line.reconciled)
            // return lines.reconcile()
            */
            return default;
        }

        public async Task<TEntity> JsRemoveOutstandingPartialAsync<TEntity>(IEnumerable<TEntity> entities, Guid partial_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def js_remove_outstanding_partial(self, partial_id):
            // ''' Called by the 'payment' widget to remove a reconciled entry to the present invoice.
            // 
            // :param partial_id: The id of an existing partial reconciled with the current invoice.
            // '''
            // self.ensure_one()
            // partial = self.env['account.partial.reconcile'].browse(partial_id)
            // return partial.unlink()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        public async Task<TEntity> LinkApplicantToTalentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def link_applicant_to_talent(self):
            // talent = self.env["hr.applicant"].search(domain=self._get_similar_applicants_domain(only_talent=True))
            // self.pool_applicant_id = talent
            */
            return default;
        }

        public async Task<TEntity> LinkBillOriginToPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timeout) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _link_bill_origin_to_purchase_orders(self, timeout=10):
            // for move in self.filtered(lambda m: m.move_type in self.get_purchase_types()):
            //     references = [ref.strip() for ref in re.split(r"[ ,]+", move.invoice_origin)] if move.invoice_origin else []
            //     move._find_and_set_purchase_orders(references, move.partner_id.id, move.amount_total, timeout=timeout)
            // return self
            */
            return default;
        }

        public async Task<TEntity> LoadDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _load_demo_data(self):
            // dep_rd = self.env.ref('hr.dep_rd', raise_if_not_found=False)
            // action_reload = {
            //     'type': 'ir.actions.client',
            //     'tag': 'reload',
            // }
            // if dep_rd:
            //     return action_reload
            // convert.convert_file(env=self.sudo().env, module='hr', filename='data/scenarios/hr_scenario.xml', idref=None, mode='init')
            // if 'resume_line_ids' in self:
            //     convert.convert_file(env=self.env, module='hr_skills', filename='data/scenarios/hr_skills_scenario.xml', idref=None, mode='init')
            // return action_reload
            */
            return default;
        }

        public async Task<TEntity> LoadScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _load_scenario(self):
            // demo_tag = self.env.ref('hr.employee_category_demo', raise_if_not_found=False)
            // if demo_tag:
            //     return
            // convert.convert_file(self.env, 'hr', 'data/scenarios/hr_scenario.xml', None, mode='init')
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['work_contact_id', 'user_partner_id']
            */
            return default;
        }

        public async Task<TEntity> MailingGetDefaultDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mailing) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _mailing_get_default_domain(self, mailing):
            // return ['&', ('move_type', '=', 'out_invoice'), ('state', '=', 'posted')]
            */
            return default;
        }

        public async Task<TEntity> MarkAsSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def mark_as_sent(self):
            // self.write({'is_sent': True})
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> MessageMailAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mails) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _message_mail_after_hook(self, mails):
            // for payment, mail in zip(self, mails):
            //     if (
            //         not payment.message_main_attachment_id
            //         and (attachments_to_link := mail.attachment_ids.filtered(lambda a: a.res_model == 'mail.message'))
            //     ):
            //         attachments_to_link.write({'res_model': self._name, 'res_id': payment.id})
            // return super()._message_mail_after_hook(mails)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // # EXTENDS mail mail.thread
            // custom_values = custom_values or {}
            // # Add custom behavior when receiving a new invoice through the mail's gateway.
            // if custom_values.get('move_type', 'entry') not in ('out_invoice', 'in_invoice', 'entry'):
            //     return super().message_new(msg_dict, custom_values=custom_values)
            // 
            // self = self.with_context(skip_is_manually_modified=True)  # noqa: PLW0642
            // 
            // company = self.env['res.company'].browse(custom_values['company_id']) if custom_values.get('company_id') else self.env.company
            // 
            // def is_internal_partner(partner):
            //     # Helper to know if the partner is an internal one.
            //     return (
            //             company.partner_id in (partner | partner.parent_id)
            //             or (partner.user_ids and all(user._is_internal() for user in partner.user_ids))
            //     )
            // 
            // def is_right_company(partner):
            //     if company:
            //         return partner.company_id.id in [False, company.id]
            //     return True
            // 
            // # Search for partner that sent the mail.
            // from_mail_addresses = email_split(msg_dict.get('from', ''))
            // partners = self._partner_find_from_emails_single(
            //     from_mail_addresses, filter_found=lambda p: is_right_company(p) or not p.partner_share, no_create=True,
            // )
            // # if we are in the case when an internal user forwarded the mail manually
            // # search for partners in mail's body
            // if partners and is_internal_partner(partners[0]):
            //     # Search for partners in the mail's body.
            //     body_mail_addresses = set(email_re.findall(msg_dict.get('body')))
            //     partners = self._partner_find_from_emails_single(
            //         body_mail_addresses, filter_found=lambda p: is_right_company(p) or p.partner_share, no_create=True,
            //     ) if body_mail_addresses else self.env['res.partner']
            // 
            // # Little hack: Inject the mail's subject in the body.
            // if msg_dict.get('subject') and msg_dict.get('body'):
            //     msg_dict['body'] = Markup('<div><div><h3>%s</h3></div>%s</div>') % (msg_dict['subject'], msg_dict['body'])
            // 
            // # Create the invoice.
            // values = {
            //     'name': '/',  # we have to give the name otherwise it will be set to the mail's subject
            //     'invoice_source_email': from_mail_addresses[0],
            //     'partner_id': partners[0].id if partners else False,
            // }
            // move_ctx = self.with_context(
            //     from_alias=True,
            //     default_move_type=custom_values.get('move_type', 'entry'),
            //     default_journal_id=custom_values.get('journal_id'),
            //     default_company_id=company.id,
            // )
            // move = super(AccountMove, move_ctx).message_new(msg_dict, custom_values=values)
            // move._compute_name()  # because the name is given, we need to recompute in case it is the first invoice of the journal
            // 
            // return move
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
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // # Remove default author when going through the mail gateway. Indeed, we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // self = self.with_context(default_user_id=False)
            // stage = False
            // if custom_values and 'job_id' in custom_values:
            //     job = self.env['hr.job'].browse(custom_values['job_id'])
            //     stage = job._get_first_stage()
            // 
            // partner_name, email_from_normalized = tools.parse_contact_from_email(msg_dict.get('from'))
            // 
            // defaults = {
            //     'partner_name': partner_name,
            // }
            // job_platform = self.env['hr.job.platform'].search([('email', '=', email_from_normalized)], limit=1)
            // 
            // if msg_dict.get('from') and not job_platform:
            //     defaults['email_from'] = msg_dict.get('from')
            //     defaults['partner_id'] = msg_dict.get('author_id', False)
            // if msg_dict.get('email_from') and job_platform:
            //     subject_pattern = re.compile(job_platform.regex or '')
            //     regex_results = re.findall(subject_pattern, msg_dict.get('subject')) + re.findall(subject_pattern, msg_dict.get('body'))
            //     defaults['partner_name'] = regex_results[0] if regex_results else partner_name
            //     del msg_dict['email_from']
            // if msg_dict.get('priority'):
            //     defaults['priority'] = msg_dict.get('priority')
            // if stage and stage.id:
            //     defaults['stage_id'] = stage.id
            // if custom_values:
            //     defaults.update(custom_values)
            // res = super().message_new(msg_dict, custom_values=defaults)
            // res._compute_partner_phone_email()
            // return res
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _message_post_after_hook(self, new_message, message_values):
            // """ This method processes the attachments of a new mail.message. It handles the 3 following situations:
            //     (1) receiving an e-mail from a mail alias. In that case, we potentially want to split the attachments into several invoices.
            //     (2) receiving an e-mail / posting a message on an existing invoice via the webclient:
            //         (2)(a): If the poster is an internal user, we enhance the invoice with the attachments.
            //         (2)(b): Otherwise, we don't do any further processing.
            //     (3) posting a message on an invoice in application code. In that case, don't do anything.
            // 
            //     Furthermore, in cases (1) and (2), we decide for each attachment whether to add it as an attachment on the invoice,
            //     based on its mimetype.
            // """
            // # EXTENDS mail mail.thread
            // attachments = new_message.attachment_ids
            // 
            // if not attachments or new_message.message_type not in {'email', 'comment'} or self.env.context.get('disable_attachment_import'):
            //     # No attachments, or the message was created in application code, so don't do anything.
            //     return super()._message_post_after_hook(new_message, message_values)
            // 
            // files_data = self._to_files_data(attachments)
            // 
            // # Extract embedded files. Note that `_unwrap_attachments` may create ir.attachment records - for example
            // # see l10n_{es,it}_edi, so to retrieve those attachments you should use the `_from_files_data` method.
            // files_data.extend(self._unwrap_attachments(files_data))
            // 
            // if self.env.context.get('from_alias'):
            //     # This is a newly-created invoice from a mail alias.
            //     # So dispatch the attachments into groups, and create a new invoice for each group beyond the first.
            //     valid_files_data = []
            //     extra_files_data = []
            //     for file_data in files_data:
            //         if self._should_attach_to_record(file_data['attachment']) or file_data['xml_tree'] is not None:
            //             valid_files_data.append(file_data)
            //         else:
            //             extra_files_data.append(file_data)
            // 
            //     file_data_groups = self._group_files_data_into_groups_of_mixed_types(valid_files_data) or [[]]
            //     invoices = self
            //     if len(file_data_groups) > 1:
            //         create_vals = (len(file_data_groups) - 1) * self.copy_data()
            //         invoices |= self.with_context(skip_is_manually_modified=True).create(create_vals)
            // 
            //     for invoice, file_data_group in zip(invoices, file_data_groups):
            //         attachment_records = self._from_files_data(file_data_group)
            //         if invoice == self:
            //             attachment_records |= self._from_files_data(extra_files_data)
            //             new_message.attachment_ids = [Command.set(attachment_records.ids)]
            //             message_values['attachment_ids'] = [Command.link(attachment.id) for attachment in attachment_records]
            //             res = super()._message_post_after_hook(new_message, message_values)
            //         else:
            //             sub_new_message = new_message.copy({
            //                 'res_id': invoice.id,
            //                 'attachment_ids': [Command.set(attachment_records.ids)],
            //             })
            //             sub_message_values = {
            //                 **message_values,
            //                 'res_id': invoice.id,
            //                 'attachment_ids': [Command.link(attachment.id) for attachment in attachment_records],
            //             }
            //             super(AccountMove, invoice)._message_post_after_hook(sub_new_message, sub_message_values)
            //         invoice._fix_attachments_on_record(attachment_records)
            // 
            //     for invoice, file_data_group in zip(invoices, file_data_groups):
            //         if file_data_group:
            //             invoice._extend_with_attachments(file_data_group, new=True)
            // 
            //     return res
            // 
            // else:
            //     # This is an existing invoice on which a message was posted either by e-mail or via the webclient.
            //     attachment_records = self._from_files_data(files_data)
            //     self._fix_attachments_on_record(attachment_records)
            // 
            //     # Only trigger decoding if the message was sent by an active internal user (note OdooBot is always inactive).
            //     if self.env.user.active and self.env.user._is_internal():
            //         self._extend_with_attachments(files_data)
            // 
            //     new_message.attachment_ids = [Command.set(attachment_records.ids)]
            //     message_values['attachment_ids'] = [Command.link(attachment.id) for attachment in attachment_records]
            //     return super()._message_post_after_hook(new_message, message_values)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email_from and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     email_normalized = tools.email_normalize(self.email_from)
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email_from or (email_normalized and partner.email_normalized == email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].create_date.date() == fields.Date.today():
            //             new_partner[0].write({
            //                 'name': self.partner_name or self.email_from,
            //             })
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email_from', 'in', [new_partner[0].email, new_partner[0].email_normalized])
            //         else:
            //             email_domain = ('email_from', '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('stage_id.fold', '=', False)
            //         ]).write({'partner_id': new_partner[0].id})
            // return super()._message_post_after_hook(message, msg_vals)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_main_attachment.py) ---
            // def _message_post_after_hook(self, message, msg_values):
            // """ Set main attachment field if necessary """
            // super()._message_post_after_hook(message, msg_values)
            // self.sudo()._message_set_main_attachment_id(
            //     self.env["ir.attachment"].browse([
            //         attachment_command[1]
            //         for attachment_command in (msg_values['attachment_ids'] or [])
            //     ])
            // )
            */
            return default;
        }

        public async Task<TEntity> MessageSetMainAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments, object force, object filter_xml) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_main_attachment.py) ---
            // def _message_set_main_attachment_id(self, attachments, force=False, filter_xml=True):
            // """ Update 'main' attachment.
            // 
            // :param list attachments: new main attachment IDS; if several attachments
            //   are given, we search for pdf or image first;
            // :param boolean force: if set, replace an existing attachment; otherwise
            //   update is skipped;
            // :param filter_xml: filters out xml (and octet-stream) attachments, as in
            //   most cases you don't want that kind of file to end up as main attachment
            //   of records;
            // """
            // if attachments and (force or not self.message_main_attachment_id):
            //     # we filter out attachment with 'xml' and 'octet' types
            //     if filter_xml:
            //         attachments = attachments.filtered(
            //             lambda r: not r.mimetype.endswith('xml') and not r.mimetype.endswith('application/octet-stream')
            //         )
            // 
            //     # Assign one of the attachments as the main according to the following priority: pdf, image, other types.
            //     if attachments:
            //         self.with_context(tracking_disable=True).message_main_attachment_id = max(
            //             attachments,
            //             key=lambda r: (r.mimetype.endswith('pdf'), r.mimetype.startswith('image'))
            //         ).id
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def message_subscribe(self, partner_ids=None, subtype_ids=None):
            // # due to record rule can not allow to add follower and mention on validated leave so subscribe through sudo
            // if any(holiday.state in ['validate', 'validate1'] for holiday in self):
            //     self.check_access('read')
            //     return super(HrLeave, self.sudo()).message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // return super().message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MoveDictToPreviewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals, Guid currency_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _move_dict_to_preview_vals(self, move_vals, currency_id=None):
            // preview_vals = {
            //     'group_name': "%s, %s" % (format_date(self.env, move_vals['date']) or _('[Not set]'), move_vals['ref']),
            //     'items_vals': move_vals['line_ids'],
            // }
            // for line in preview_vals['items_vals']:
            //     if 'partner_id' in line[2]:
            //         # sudo is needed to compute display_name in a multi companies environment
            //         line[2]['partner_id'] = self.env['res.partner'].browse(line[2]['partner_id']).sudo().display_name
            //     line[2]['account_id'] = self.env['account.account'].browse(line[2]['account_id']).display_name or _('Destination Account')
            //     line[2]['debit'] = currency_id and formatLang(self.env, line[2]['debit'], currency_obj=currency_id) or line[2]['debit']
            //     line[2]['credit'] = currency_id and formatLang(self.env, line[2]['credit'], currency_obj=currency_id) or line[2]['debit']
            // return preview_vals
            */
            return default;
        }

        public async Task<TEntity> MoveValidateLeaveToConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _move_validate_leave_to_confirm(self):
            // self.write({'state': 'confirm'})
            // self.activity_update()
            // self._post_leave_cancel()
            */
            return default;
        }

        public async Task<TEntity> MustCheckConstrainsDateSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _must_check_constrains_date_sequence(self):
            // # OVERRIDES sequence.mixin
            // return self.state == 'posted' and not self.quick_edit_mode
            */
            return default;
        }

        public async Task<TEntity> NeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _need_cancel_request(self):
            // """ Hook allowing a localization to prevent the user to reset draft an invoice that has been already sent
            // to the government and thus, must remain untouched except if its cancellation is approved.
            // 
            // :return: True if the cancel button is displayed instead of draft button, False otherwise.
            // """
            // self.ensure_one()
            // return False
            */
            return default;
        }

        public async Task<TEntity> NeedsProductPriceComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        [ApiModel]
        public async Task<TEntity> NewAsync<TEntity>(IEnumerable<TEntity> entities, object values, object origin, object @ref) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def new(self, values=None, origin=None, ref=None):
            // if not values:
            //     values = {}
            // new_vals = values.copy()
            // version_vals = {val: new_vals.pop(val) for val in values if val in self._fields and self._fields[val].inherited}
            // 
            // employee = super().new(new_vals, origin, ref)
            // version_vals['employee_id'] = employee
            // self.env['hr.version'].new({
            //     f_name: value
            //     for f_name, value in version_vals.items()
            //     if self.env['hr.version']._has_field_access(self.env['hr.version']._fields[f_name], 'read')
            // })
            // return employee
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False,
            //                                            force_record_name=False):
            // # EXTENDS mail mail.thread
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals=msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang,
            //     force_record_name=force_record_name,
            // )
            // record = render_context['record']
            // subtitles = [f"{record.name} - {record.partner_id.name}" if record.partner_id.name else record.name]
            // if self.is_invoice(include_receipts=True):
            //     # Only show the amount in emails for non-miscellaneous moves. It might confuse recipients otherwise.
            //     if self.invoice_date_due and self.payment_state not in ('in_payment', 'paid'):
            //         subtitles.append(_(
            //             '%(amount)s due\N{NO-BREAK SPACE}%(date)s',
            //             amount=format_amount(self.env, self.amount_total, self.currency_id, lang_code=render_context.get('lang')),
            //             date=format_date(self.env, self.invoice_date_due, lang_code=render_context.get('lang')),
            //         ))
            //     else:
            //         subtitles.append(format_amount(self.env, self.amount_total, self.currency_id, lang_code=render_context.get('lang')))
            // render_context['subtitles'] = subtitles
            // return render_context
            */
            return default;
        }

        public async Task<TEntity> NotifyChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object subtype_xmlid) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _notify_change(self, message, subtype_xmlid='mail.mt_note'):
            // for leave in self:
            //     leave.message_post(body=message, subtype_xmlid=subtype_xmlid)
            // 
            //     recipient = None
            //     if leave.user_id:
            //         recipient = leave.user_id.partner_id.id
            //     elif leave.employee_id:
            //         recipient = leave.employee_id.work_contact_id.id
            // 
            //     if recipient:
            //         self.env['mail.thread'].sudo().message_notify(
            //             body=message,
            //             partner_ids=[recipient],
            //             subject=_('Your Time Off'),
            //         )
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NotifyExpiringContractWorkPermitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def notify_expiring_contract_work_permit(self):
            // companies = self.env['res.company'].search([])
            // employees_contract_expiring = self.env['hr.employee']
            // employees_work_permit_expiring = self.env['hr.employee']
            // 
            // for company in companies:
            //     employees_contract_expiring += self.env['hr.employee'].search([
            //         ('company_id', '=', company.id),
            //         ('contract_date_start', '!=', False),
            //         ('contract_date_start', '<', fields.Date.today()),
            //         ('contract_date_end', '=', fields.Date.today() + relativedelta(days=company.contract_expiration_notice_period)),
            //     ])
            // 
            //     employees_work_permit_expiring += self.env['hr.employee'].search([
            //         ('company_id', '=', company.id),
            //         ('work_permit_expiration_date', '!=', False),
            //         ('work_permit_expiration_date', '=', fields.Date.today() + relativedelta(days=company.work_permit_expiration_notice_period)),
            //     ])
            // 
            // for employee in employees_contract_expiring:
            //     employee.with_context(mail_activity_quick_update=True).activity_schedule(
            //         'mail.mail_activity_data_todo', employee.contract_date_end,
            //         _("The contract of %s is about to expire.", employee.name),
            //         user_id=employee.hr_responsible_id.id or self.env.uid)
            // 
            // for employee in employees_work_permit_expiring:
            //     employee.with_context(mail_activity_quick_update=True).activity_schedule(
            //         'mail.mail_activity_data_todo', employee.work_permit_expiration_date,
            //         _("The work permit of %s is about to expire.", employee.name),
            //         user_id=employee.hr_responsible_id.id or self.env.uid)
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // groups = super()._notify_get_recipients_groups(message, model_description, msg_vals=msg_vals)
            // self.ensure_one()
            // 
            // if self.move_type != 'entry':
            //     local_msg_vals = dict(msg_vals or {})
            //     partner_ids = local_msg_vals.get('partner_ids', []) if 'partner_ids' in local_msg_vals else message.partner_ids.ids
            //     self._portal_ensure_token()
            //     access_link = self._notify_get_action_link('view', **local_msg_vals, access_token=self.access_token)
            // 
            //     # Create a new group for partners that have been manually added as recipients.
            //     # Those partners should have access to the invoice.
            //     button_access = {'url': access_link} if access_link else {}
            //     recipient_group = (
            //         'additional_intended_recipient',
            //         lambda pdata: pdata['id'] in partner_ids and pdata['id'] != self.partner_id.id and pdata['type'] != 'user',
            //         {
            //             'has_button_access': True,
            //             'button_access': button_access,
            //         }
            //     )
            //     groups.insert(0, recipient_group)
            // 
            // return groups
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _notify_get_reply_to(self, default=None, author_id=False):
            // """ Override to set alias of applicants to their job definition if any. """
            // aliases = self.mapped('job_id')._notify_get_reply_to(default=default, author_id=author_id)
            // res = {app.id: aliases.get(app.job_id.id) for app in self}
            // leftover = self.filtered(lambda rec: not rec.job_id)
            // if leftover:
            //     res.update(super(HrApplicant, leftover)._notify_get_reply_to(default=default, author_id=author_id))
            // return res
            */
            return default;
        }

        public async Task<TEntity> NotifyManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _notify_manager(self):
            // leaves = self.filtered(lambda hol: (hol.validation_type == 'both' and hol.state in ['validate1', 'validate']) or (hol.validation_type == 'manager' and hol.state == 'validate'))
            // model_description = self.env['ir.model']._get('hr.holidays').name
            // for holiday in leaves:
            //     responsible = holiday.employee_id.leave_manager_id.partner_id.ids
            //     if responsible:
            //         holiday.sudo().message_notify(
            //             partner_ids=responsible,
            //             model_description=model_description,
            //             subject=_('Refused Time Off'),
            //             body=_(
            //                 '%(holiday_name)s has been refused.',
            //                 holiday_name=holiday.display_name,
            //             ),
            //             email_layout_xmlid="mail.mail_notification_layout",
            //             subtitles=[holiday.display_name],
            //         )
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, object values, object field_names, object fields_spec) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def onchange(self, values, field_names, fields_spec):
            // # Since only one field can be changed at the same time (the record is
            // # saved when changing tabs) we can avoid building the snapshots for the
            // # other field
            // if 'line_ids' in field_names:
            //     values = {key: val for key, val in values.items() if key != 'invoice_line_ids'}
            //     fields_spec = {key: val for key, val in fields_spec.items() if key != 'invoice_line_ids'}
            // elif 'invoice_line_ids' in field_names:
            //     values = {key: val for key, val in values.items() if key != 'line_ids'}
            //     fields_spec = {key: val for key, val in fields_spec.items() if key != 'line_ids'}
            //     # When product_id and price_unit are in values, values is reordered to make sure
            //     # that product_id is before price_unit because product_id is triggering an onchange
            //     # of price_unit that could override the one defined here if the product_id is set
            //     # after price_unit
            //     invoice_line_ids = values.get('invoice_line_ids')
            //     for invoice_line_idx, invoice_line in enumerate(invoice_line_ids):
            //         if (len(invoice_line) == 3 and invoice_line[0] == 1 and isinstance(invoice_line[2], dict) and
            //             'product_id' in invoice_line[2] and 'price_unit' in invoice_line[2]
            //         ):
            //             if isinstance(invoice_line, tuple):
            //                 invoice_line_ids[invoice_line_idx] = invoice_line = list(invoice_line)
            //             invoice_line[2] = dict(sorted(invoice_line[2].items(), key=lambda item: item[0] != 'product_id'))
            // return super().onchange(values, field_names, fields_spec)
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def onchange(self, values, field_names, fields_spec):
            // # Try to force the leave_type display_name when creating new records
            // # This is called right after pressing create and returns the display_name for
            // # most fields in the view.
            // if values and 'employee_id' in fields_spec and 'employee_id' not in self.env.context:
            //     employee_id = get_employee_from_context(values, self.env.context, self.env.user.employee_id.id)
            //     self = self.with_context(employee_id=employee_id)
            // return super().onchange(values, field_names, fields_spec)
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_company_id(self):
            // if self._origin:
            //     return {'warning': {
            //         'title': _("Warning"),
            //         'message': _("To avoid multi company issues (losing the access to your previous contracts, leaves, ...), you should create another employee in the new company instead.")
            //     }}
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractDateStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_contract_date_start(self):
            // if not self.contract_date_start:
            //     self.contract_date_end = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_contract_template_id(self):
            // if self.contract_template_id:
            //     whitelist = self.env['hr.version']._get_whitelist_fields_from_template()
            //     for field in self.contract_template_id._fields:
            //         if field in whitelist and not self.env['hr.version']._fields[field].related:
            //             self[field] = self.contract_template_id[field]
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_date(self):
            // if not self.is_invoice(True):
            //     self.line_ids._inverse_amount_currency()
            */
            return default;
        }

        public async Task<TEntity> OnchangeFposIdShowUpdateFposInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_fpos_id_show_update_fpos(self):
            // self.show_update_fpos = self.line_ids and self._origin.fiscal_position_id != self.fiscal_position_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _onchange_hours(self):
            // # avoid negative or after midnight
            // self.request_hour_from = min(max(self.request_hour_from, 0.0), 23.99)
            // self.request_hour_to = min(max(self.request_hour_to, 0.0), 24)
            */
            return default;
        }

        public async Task<TEntity> OnchangeInvoiceCashRoundingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_invoice_cash_rounding_id(self):
            // for move in self:
            //     if move.invoice_cash_rounding_id.strategy == 'add_invoice_line' and not move.invoice_cash_rounding_id.profit_account_id:
            //         return {'warning': {
            //             'title': _("Warning for Cash Rounding Method: %s", move.invoice_cash_rounding_id.name),
            //             'message': _("You must specify the Profit Account (company dependent)")
            //         }}
            */
            return default;
        }

        public async Task<TEntity> OnchangeInvoiceVendorBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_invoice_vendor_bill(self):
            // if self.invoice_vendor_bill_id:
            //     # Copy invoice lines.
            //     for line in self.invoice_vendor_bill_id.invoice_line_ids:
            //         copied_vals = line.copy_data()[0]
            //         self.invoice_line_ids += self.env['account.move.line'].new(copied_vals)
            // 
            //     self.currency_id = self.invoice_vendor_bill_id.currency_id
            //     self.fiscal_position_id = self.invoice_vendor_bill_id.fiscal_position_id
            // 
            //     # Reset
            //     self.invoice_vendor_bill_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_journal_id(self):
            // if not self.quick_edit_mode:
            //     self.name = False
            //     self._compute_name()
            */
            return default;
        }

        public async Task<TEntity> OnchangeNameWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_name_warning(self):
            // if self.name and self.name != '/' and self.name <= (self.highest_name or '') and not self.quick_edit_mode:
            //     self.show_name_warning = True
            // else:
            //     self.show_name_warning = False
            // 
            // origin_name = self._origin.name
            // if not origin_name or origin_name == '/':
            //     origin_name = self.highest_name
            // if (
            //     self.name and self.name != '/'
            //     and origin_name and origin_name != '/'
            //     and self.date == self._origin.date
            //     and self.journal_id == self._origin.journal_id
            // ):
            //     new_format, new_format_values = self._get_sequence_format_param(self.name)
            //     origin_format, origin_format_values = self._get_sequence_format_param(origin_name)
            // 
            //     if (
            //         new_format != origin_format
            //         or dict(new_format_values, year=0, month=0, seq=0) != dict(origin_format_values, year=0, month=0, seq=0)
            //     ):
            //         changed = _(
            //             "It was previously '%(previous)s' and it is now '%(current)s'.",
            //             previous=origin_name,
            //             current=self.name,
            //         )
            //         reset = self._deduce_sequence_number_reset(self.name)
            //         if reset == 'month':
            //             detected = _(
            //                 "The sequence will restart at 1 at the start of every month.\n"
            //                 "The year detected here is '%(year)s' and the month is '%(month)s'.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         elif reset == 'year':
            //             detected = _(
            //                 "The sequence will restart at 1 at the start of every year.\n"
            //                 "The year detected here is '%(year)s'.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         elif reset == 'year_range':
            //             detected = _(
            //                 "The sequence will restart at 1 at the start of every financial year.\n"
            //                 "The financial start year detected here is '%(year)s'.\n"
            //                 "The financial end year detected here is '%(year_end)s'.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         elif reset == 'year_range_month':
            //             detected = _(
            //                 "The sequence will restart at 1 at the start of every month.\n"
            //                 "The financial start year detected here is '%(year)s'.\n"
            //                 "The financial end year detected here is '%(year_end)s'.\n"
            //                 "The month detected here is '%(month)s'.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         else:
            //             detected = _(
            //                 "The sequence will never restart.\n"
            //                 "The incrementing number in this case is '%(formatted_seq)s'."
            //             )
            //         new_format_values['formatted_seq'] = "{seq:0{seq_length}d}".format(**new_format_values)
            //         detected = detected % new_format_values
            //         return {'warning': {
            //             'title': _("The sequence format has changed."),
            //             'message': "%s\n\n%s" % (changed, detected)
            //         }}
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_partner_id(self):
            // self = self.with_company((self.journal_id.company_id or self.env.company)._accessible_branches()[:1])
            // 
            // if self.partner_id:
            //     rec_account = self.partner_id.property_account_receivable_id
            //     pay_account = self.partner_id.property_account_payable_id
            //     if not rec_account and not pay_account:
            //         action = self.env.ref('account.action_account_config')
            //         msg = _('Cannot find a chart of accounts for this company, You should configure it. \nPlease go to Account Configuration.')
            //         raise RedirectWarning(msg, action.id, _('Go to the configuration panel'))
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_phone_validation_employee(self):
            // if self.work_phone:
            //     self.work_phone = self._phone_format(number=self.work_phone, force_format='INTERNATIONAL') or self.work_phone
            // if self.mobile_phone:
            //     self.mobile_phone = self._phone_format(number=self.mobile_phone, force_format='INTERNATIONAL') or self.mobile_phone
            */
            return default;
        }

        public async Task<TEntity> OnchangePrivateStateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_private_state_id(self):
            // if self.private_state_id:
            //     self.private_country_id = self.private_state_id.country_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductHasCostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> OnchangeQuickEditLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_quick_edit_line_ids(self):
            // quick_encode_suggestion = self.env.context.get('quick_encoding_vals')
            // if (
            //     not self.quick_edit_total_amount
            //     or not self.quick_edit_mode
            //     or not self.invoice_line_ids
            //     or not quick_encode_suggestion
            //     or not quick_encode_suggestion['price_unit'] == self.invoice_line_ids[-1].price_unit
            // ):
            //     return
            // self._check_total_amount(self.quick_edit_total_amount)
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_quick_edit_total_amount(self):
            // """
            // Creates a new line with the suggested values (for the account, the price_unit,
            // and the tax) such that the total amount matches the quick total amount.
            // """
            // if (
            //     not self.quick_edit_total_amount
            //     or not self.quick_edit_mode
            //     or len(self.invoice_line_ids) > 0
            // ):
            //     return
            // suggestions = self.quick_encoding_vals
            // self.invoice_line_ids = [Command.clear()]
            // self.invoice_line_ids += self.env['account.move.line'].new({
            //     'partner_id': self.partner_id,
            //     'account_id': suggestions['account_id'],
            //     'currency_id': self.currency_id.id,
            //     'price_unit': suggestions['price_unit'],
            //     'tax_ids': [Command.set(suggestions['tax_ids'])],
            // })
            // self._check_total_amount(self.quick_edit_total_amount)
            */
            return default;
        }

        public async Task<TEntity> OnchangeTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_timezone(self):
            // if self.resource_calendar_id and not self.tz:
            //     self.tz = self.resource_calendar_id.tz
            */
            return default;
        }

        public async Task<TEntity> OnchangeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_user(self):
            // self.update(self._sync_user(self.user_id, (bool(self.image_1920))))
            // if not self.name:
            //     self.name = self.user_id.name
            */
            return default;
        }

        public async Task<TEntity> OpenAdjustingEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_adjusting_entries(self):
            // self.ensure_one()
            // return self.adjusting_entries_move_ids._get_records_action(name="Adjusting Entries")
            */
            return default;
        }

        public async Task<TEntity> OpenAdjustingEntryOriginMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_adjusting_entry_origin_moves(self):
            // self.ensure_one()
            // label = self.adjusting_entry_origin_label if len(self.adjusting_entries_move_ids) == 1 else 'Invoices'
            // return self.adjusting_entry_origin_move_ids._get_records_action(name=label)
            */
            return default;
        }

        public async Task<TEntity> OpenCreatedCabaEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_created_caba_entries(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Cash Basis Entries"),
            //     'res_model': 'account.move',
            //     'view_mode': 'form',
            //     'domain': [('id', 'in', self.tax_cash_basis_created_move_ids.ids)],
            //     'views': [(self.env.ref('account.view_move_tree').id, 'list'), (False, 'form')],
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenPaymentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_payments(self):
            // payments = self.reconciled_payment_ids
            // return payments._get_records_action(name=_("Payments"))
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OpenPendingRequestsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def open_pending_requests(self):
            // user_employee = self.env.user.employee_id
            // employee = self.env['hr.employee']._get_contextual_employee()
            // context = {'search_default_approve': True, 'search_default_second_approval': True}
            // domain = []
            // if employee != user_employee:
            //     view_name = 'hr_holidays.hr_leave_allocation_view_tree'
            //     context.update({'search_default_employee_id': employee.id})
            // else:
            //     view_name = 'hr_holidays.hr_leave_allocation_view_tree_my'
            //     domain = [('employee_id', '=', employee.id)]
            // return {
            //     'name': _('Allocation Requests'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.leave.allocation',
            //     'views': [[self.env.ref(view_name).id, 'list']],
            //     'domain': domain,
            //     'context': context,
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenReconcileViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_reconcile_view(self):
            // return self.line_ids.open_reconcile_view()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ParseExpenseSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description, object currencies) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        [ApiModel]
        public async Task<TEntity> ParsePriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description, object currencies) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        [ApiModel]
        public async Task<TEntity> ParseProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _phone_get_number_fields(self):
            // return ['mobile_phone']
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _phone_get_number_fields(self):
            // """ This method returns the fields to use to find the number to use to
            // send an SMS on a record. """
            // return ['partner_phone']
            */
            return default;
        }

        public async Task<TEntity> PostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _post(self, soft=True):
            // """Post/Validate the documents.
            // 
            // Posting the documents will give it a number, and check that the document is
            // complete (some fields might not be required if not posted but are required
            // otherwise).
            // If the journal is locked with a hash table, it will be impossible to change
            // some fields afterwards.
            // 
            // :param bool soft: if True, future documents are not immediately posted,
            //     but are set to be auto posted automatically at the set accounting date.
            //     Nothing will be performed on those documents before the accounting date.
            // :returns: the Model<account.move> documents that have been posted
            // """
            // if not self.env.su and not self.env.user.has_group('account.group_account_invoice'):
            //     raise AccessError(_("You don't have the access rights to post an invoice."))
            // 
            // # Avoid marking is_manually_modified as True when posting an invoice
            // self = self.with_context(skip_is_manually_modified=True)  # noqa: PLW0642
            // 
            // validation_msgs = set()
            // 
            // for invoice in self.filtered(lambda move: move.is_invoice(include_receipts=True)):
            //     if (
            //         invoice.quick_edit_mode
            //         and invoice.quick_edit_total_amount
            //         and invoice.currency_id.compare_amounts(invoice.quick_edit_total_amount, invoice.amount_total) != 0
            //     ):
            //         validation_msgs.add(_(
            //             "The current total is %(current_total)s but the expected total is %(expected_total)s. In order to post the invoice/bill, "
            //             "you can adjust its lines or the expected Total (tax inc.).",
            //             current_total=formatLang(self.env, invoice.amount_total, currency_obj=invoice.currency_id),
            //             expected_total=formatLang(self.env, invoice.quick_edit_total_amount, currency_obj=invoice.currency_id),
            //         ))
            //     if invoice.partner_bank_id and not invoice.partner_bank_id.active:
            //         validation_msgs.add(_(
            //             "The recipient bank account linked to this invoice is archived.\n"
            //             "So you cannot confirm the invoice."
            //         ))
            //     if float_compare(invoice.amount_total, 0.0, precision_rounding=invoice.currency_id.rounding) < 0:
            //         validation_msgs.add(_(
            //             "You cannot validate an invoice with a negative total amount. "
            //             "You should create a credit note instead. "
            //             "Use the action menu to transform it into a credit note or refund."
            //         ))
            // 
            //     if not invoice.partner_id:
            //         if invoice.is_sale_document():
            //             validation_msgs.add(_(
            //                 "The 'Customer' field is required to validate the invoice.\n"
            //                 "You probably don't want to explain to your auditor that you invoiced an invisible man :)"
            //             ))
            //         elif invoice.is_purchase_document():
            //             validation_msgs.add(_("The field 'Vendor' is required, please complete it to validate the Vendor Bill."))
            // 
            //     # Handle case when the invoice_date is not set. In that case, the invoice_date is set at today and then,
            //     # lines are recomputed accordingly (if the user didnt' change the rate manually)
            //     if not invoice.invoice_date:
            //         if invoice.is_sale_document(include_receipts=True):
            //             is_manual_rate = invoice.invoice_currency_rate != invoice.expected_currency_rate
            //             # keep the rate set by the user
            //             with self.env.protecting([self._fields['invoice_currency_rate']], invoice) if is_manual_rate else nullcontext():
            //                 invoice.invoice_date = fields.Date.context_today(self)
            //         elif invoice.is_purchase_document(include_receipts=True):
            //             validation_msgs.add(_("The Bill/Refund date is required to validate this document."))
            // 
            // for move in self:
            //     if move.state in ['posted', 'cancel']:
            //         validation_msgs.add(_('The entry %(name)s (id %(id)s) must be in draft.', name=move.name, id=move.id))
            //     if not move.line_ids.filtered(lambda line: line.display_type not in ('line_section', 'line_subsection', 'line_note')):
            //         validation_msgs.add(_("Even magicians can't post nothing!"))
            //     if not soft and move.auto_post != 'no' and move.date > fields.Date.context_today(self):
            //         date_msg = move.date.strftime(get_lang(self.env).date_format)
            //         validation_msgs.add(_("This move is configured to be auto-posted on %(date)s", date=date_msg))
            //     if not move.journal_id.active:
            //         validation_msgs.add(_(
            //             "You cannot post an entry in an archived journal (%(journal)s)",
            //             journal=move.journal_id.display_name,
            //         ))
            //     if move.display_inactive_currency_warning:
            //         validation_msgs.add(_(
            //             "You cannot validate a document with an inactive currency: %s",
            //             move.currency_id.name
            //         ))
            // 
            //     if move.line_ids.account_id.filtered(lambda account: not account.active) and not self.env.context.get('skip_account_deprecation_check'):
            //         validation_msgs.add(_("A line of this move is using a archived account, you cannot post it."))
            // 
            // if validation_msgs:
            //     msg = "\n".join([line for line in validation_msgs])
            //     raise UserError(msg)
            // 
            // if soft:
            //     future_moves = self.filtered(lambda move: move.date > fields.Date.context_today(self))
            //     for move in future_moves:
            //         if move.auto_post == 'no':
            //             move.auto_post = 'at_date'
            //         msg = _('This move will be posted at the accounting date: %(date)s', date=format_date(self.env, move.date))
            //         move.message_post(body=msg)
            //     to_post = self - future_moves
            // else:
            //     to_post = self
            // 
            // for move in to_post:
            //     affects_tax_report = move._affect_tax_report()
            //     lock_dates = move._get_violated_lock_dates(move.date, affects_tax_report)
            //     if lock_dates:
            //         move.date = move._get_accounting_date(move._get_accounting_date_source(), affects_tax_report, lock_dates=lock_dates)
            // 
            // # Create the analytic lines in batch is faster as it leads to less cache invalidation.
            // to_post.line_ids._create_analytic_lines()
            // 
            // # Trigger copying for recurring invoices
            // to_post.filtered(lambda m: m.auto_post not in ('no', 'at_date'))._copy_recurring_entries()
            // 
            // for invoice in to_post:
            //     # Fix inconsistencies that may occure if the OCR has been editing the invoice at the same time of a user. We force the
            //     # partner on the lines to be the same as the one on the move, because that's the only one the user can see/edit.
            //     wrong_lines = invoice.is_invoice() and invoice.line_ids.filtered(lambda aml:
            //         aml.partner_id != invoice.commercial_partner_id
            //         and aml.display_type not in ('line_section', 'line_subsection', 'line_note')
            //     )
            //     if wrong_lines:
            //         wrong_lines.write({'partner_id': invoice.commercial_partner_id.id})
            // 
            // # reconcile if state is in draft and move has reversal_entry_id set
            // draft_reverse_moves = to_post.filtered(lambda move: move.reversed_entry_id and move.reversed_entry_id.state == 'posted')
            // 
            // # deal with the eventually related draft moves to the ones we want to post
            // partials_to_unlink = self.env['account.partial.reconcile']
            // 
            // for aml in self.line_ids:
            //     for partials, counterpart_field in [(aml.matched_debit_ids, 'debit_move_id'), (aml.matched_credit_ids, 'credit_move_id')]:
            //         for partial in partials:
            //             counterpart_move =  partial[counterpart_field].move_id
            //             if counterpart_move.state == 'posted' or counterpart_move in to_post:
            //                 if partial.exchange_move_id:
            //                     to_post |= partial.exchange_move_id
            //                     # If the draft invoice changed since it was reconciled, in a way that would affect the exchange diff,
            //                     # any existing reconcilation and draft exchange move would be deleted already (to force the user to
            //                     # re-do the reconciliation).
            //                     # This is ensured by the the checks in env['account.move.line'].write():
            //                     #     see env[account.move.line]._get_lock_date_protected_fields()['reconciliation']
            // 
            //                 if partial._get_draft_caba_move_vals() != partial.draft_caba_move_vals:
            //                     # draft invoice changed since it was reconciled, the cash basis entry isn't correct anymore
            //                     # and the user has to re-do the reconciliation. Existing draft cash basis move will be unlinked
            //                     partials_to_unlink |= partial
            // 
            //                 elif move.tax_cash_basis_created_move_ids:
            //                     to_post |= move.tax_cash_basis_created_move_ids.filtered(lambda m: m.tax_cash_basis_rec_id == partial)
            //                 elif counterpart_move.tax_cash_basis_created_move_ids:
            //                     to_post |= counterpart_move.tax_cash_basis_created_move_ids.filtered(lambda m: m.tax_cash_basis_rec_id == partial)
            // 
            // if partials_to_unlink:
            //     partials_to_unlink.unlink()
            // 
            // to_post.write({
            //     'state': 'posted',
            //     'posted_before': True,
            // })
            // 
            // if not self.env.user.has_group('account.group_partial_purchase_deductibility') and \
            //         self.filtered(lambda move: move.move_type == 'in_invoice' and move.invoice_line_ids.filtered(lambda l: l.deductible_amount != 100)):
            //     self.env.user.sudo().group_ids = [Command.link(self.env.ref('account.group_partial_purchase_deductibility').id)]
            // 
            // # Add the move number to the non_deductible lines for easier auditing
            // if non_deductible_lines := self.line_ids.filtered(lambda line: (line.display_type in ('non_deductible_product_total', 'non_deductible_tax'))):
            //     for line in non_deductible_lines:
            //         line.name = (
            //             _('%s - private part', line.move_id.name)
            //             if line.display_type == 'non_deductible_product_total'
            //             else _('%s - private part (taxes)', line.move_id.name)
            //         )
            // 
            // draft_reverse_moves.reversed_entry_id._reconcile_reversed_moves(draft_reverse_moves, self.env.context.get('move_reverse_cancel', False))
            // to_post.line_ids._reconcile_marked()
            // 
            // customer_count, supplier_count = defaultdict(int), defaultdict(int)
            // for invoice in to_post:
            //     if invoice.is_sale_document():
            //         customer_count[invoice.partner_id] += 1
            //     elif invoice.is_purchase_document():
            //         supplier_count[invoice.partner_id] += 1
            //     elif invoice.move_type == 'entry':
            //         sale_amls = invoice.line_ids.filtered(lambda line: line.partner_id and line.account_id.account_type == 'asset_receivable')
            //         for partner in sale_amls.mapped('partner_id'):
            //             customer_count[partner] += 1
            //         purchase_amls = invoice.line_ids.filtered(lambda line: line.partner_id and line.account_id.account_type == 'liability_payable')
            //         for partner in purchase_amls.mapped('partner_id'):
            //             supplier_count[partner] += 1
            // for partner, count in customer_count.items():
            //     (partner | partner.commercial_partner_id)._increase_rank('customer_rank', count)
            // for partner, count in supplier_count.items():
            //     (partner | partner.commercial_partner_id)._increase_rank('supplier_rank', count)
            // 
            // # Trigger action for paid invoices if amount is zero
            // to_post.filtered(
            //     lambda m: m.is_invoice(include_receipts=True) and m.currency_id.is_zero(m.amount_total)
            // )._invoice_paid_hook()
            // 
            // return to_post
            */
            return default;
        }

        public async Task<TEntity> PostLeaveCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _post_leave_cancel(self):
            // self.meeting_id.active = False
            // self._remove_resource_leave()
            */
            return default;
        }

        public async Task<TEntity> PostWithoutWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> PostWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> PrepareBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py) ---
            // def _prepare_base_line_for_taxes_computation(self, **kwargs):
            // self.ensure_one()
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     self,
            //     **{'partner_id': self.vendor_id, 'special_mode': 'total_included', 'rate': self.currency_rate, **kwargs},
            // )
            */
            return default;
        }

        public async Task<TEntity> PrepareCashRoundingBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_rounding_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_cash_rounding_base_line_for_taxes_computation(self, cash_rounding_line):
            // """ Convert an account.move.line having display_type='rounding' into a base line for the taxes computation.
            // 
            // :param cash_rounding_line: An account.move.line.
            // :return: A base line returned by '_prepare_base_line_for_taxes_computation'.
            // """
            // self.ensure_one()
            // sign = self.direction_sign
            // rate = self.invoice_currency_rate
            // 
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     cash_rounding_line,
            //     price_unit=sign * cash_rounding_line.amount_currency,
            //     quantity=1.0,
            //     sign=sign,
            //     special_mode='total_excluded',
            //     special_type='cash_rounding',
            // 
            //     is_refund=self.move_type in ('out_refund', 'in_refund'),
            //     rate=rate,
            // )
            */
            return default;
        }

        public async Task<TEntity> PrepareCreateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _prepare_create_values(self, vals_list):
            // result = super()._prepare_create_values(vals_list)
            // new_vals_list = []
            // Version = self.env['hr.version']
            // version_fields = [fname for fname, field in Version._fields.items() if Version._has_field_access(field, 'write')]
            // for vals in result:
            //     employee_vals = {}
            //     version_vals = {}
            //     for fname, value in vals.items():
            //         employee_field = self._fields.get(fname)
            //         if not (employee_field and employee_field.inherited and employee_field.related_field.model_name == 'hr.version'):
            //             employee_vals[fname] = value
            //         else:
            //             version_vals[fname] = value
            //     new_vals_list.append({
            //         **employee_vals,
            //         **{k: v for k, v in version_vals.items() if k in version_fields},
            //     })
            // return new_vals_list
            */
            return default;
        }

        public async Task<TEntity> PrepareEdiValsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_edi_vals_to_export(self):
            // ''' The purpose of this helper is to prepare values in order to export an invoice through the EDI system.
            // This includes the computation of the tax details for each invoice line that could be very difficult to
            // handle regarding the computation of the base amount.
            // 
            // :return: A python dict containing default pre-processed values.
            // '''
            // self.ensure_one()
            // 
            // res = {
            //     'record': self,
            //     'balance_multiplicator': -1 if self.is_inbound() else 1,
            //     'invoice_line_vals_list': [],
            // }
            // 
            // # Invoice lines details.
            // for index, line in enumerate(self.invoice_line_ids.filtered(lambda line: line.display_type == 'product'), start=1):
            //     line_vals = line._prepare_edi_vals_to_export()
            //     line_vals['index'] = index
            //     res['invoice_line_vals_list'].append(line_vals)
            // 
            // # Totals.
            // res.update({
            //     'total_price_subtotal_before_discount': sum(x['price_subtotal_before_discount'] for x in res['invoice_line_vals_list']),
            //     'total_price_discount': sum(x['price_discount'] for x in res['invoice_line_vals_list']),
            // })
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> PrepareEpdBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object epd_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_epd_base_line_for_taxes_computation(self, epd_line):
            // """ Convert an account.move.line having display_type='epd' into a base line for the taxes computation.
            // 
            // :param epd_line: An account.move.line.
            // :return: A base line returned by '_prepare_base_line_for_taxes_computation'.
            // """
            // self.ensure_one()
            // sign = self.direction_sign
            // rate = self.invoice_currency_rate
            // 
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     epd_line,
            //     price_unit=sign * epd_line.amount_currency,
            //     quantity=1.0,
            //     sign=sign,
            //     special_mode='total_excluded',
            //     special_type='early_payment',
            // 
            //     is_refund=self.move_type in ('out_refund', 'in_refund'),
            //     rate=rate,
            // )
            */
            return default;
        }

        public async Task<TEntity> PrepareEpdBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_epd_base_lines_for_taxes_computation_from_base_lines(self, base_lines):
            // """ Anticipate the epd lines to be generated from the base lines passed as parameter.
            // When the record is in draft (not saved), the accounting items are not there so we can't
            // call '_prepare_epd_base_line_for_taxes_computation'.
            // 
            // :param base_lines: The base lines generated by '_prepare_product_base_line_for_taxes_computation'.
            // :return: A list of base lines representing the epd lines.
            // """
            // self.ensure_one()
            // aggregated_results = self._sync_dynamic_line_needed_values(base_lines.mapped('epd_needed'))
            // sign = self.direction_sign
            // rate = self.invoice_currency_rate
            // epd_lines = []
            // for grouping_key, values in aggregated_results.items():
            //     all_values = {**grouping_key, **values}
            //     epd_lines.append(self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //         all_values,
            //         id=grouping_key,
            //         tax_ids=self.env['account.tax'].browse(all_values['tax_ids'][0][2]),
            //         price_unit=sign * values['amount_currency'],
            //         quantity=1.0,
            //         currency_id=self.currency_id,
            //         sign=1,
            //         special_mode='total_excluded',
            //         special_type='early_payment',
            // 
            //         partner_id=self.commercial_partner_id,
            //         account_id=self.env['account.account'].browse(all_values['account_id']),
            //         is_refund=self.move_type in ('out_refund', 'in_refund'),
            //         rate=rate,
            //     ))
            // return epd_lines
            */
            return default;
        }

        public async Task<TEntity> PrepareHolidaysMeetingValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _prepare_holidays_meeting_values(self):
            // result = defaultdict(list)
            // for holiday in self:
            //     user = holiday.user_id
            //     meeting_name = _(
            //         "%(employee)s on Time Off : %(duration)s",
            //         employee=holiday.employee_id.name or holiday.category_id.name,
            //         duration=holiday.duration_display)
            //     allday_value = not holiday.request_unit_half
            //     if holiday.leave_type_request_unit == 'hour':
            //         allday_value = float_compare(holiday.number_of_days, 1.0, 1) >= 0
            // 
            //     leave_tz = pytz.timezone(holiday.tz) if holiday.tz else pytz.UTC
            //     start_value = pytz.UTC.localize(holiday.date_from).astimezone(leave_tz).replace(tzinfo=None)
            //     stop_value = pytz.UTC.localize(holiday.date_to).astimezone(leave_tz).replace(tzinfo=None)
            // 
            //     meeting_values = {
            //         'name': meeting_name,
            //         'duration': holiday.number_of_days * (holiday.resource_calendar_id.hours_per_day or HOURS_PER_DAY),
            //         'description': holiday.notes,
            //         'user_id': user.id,
            //         'start': start_value,
            //         'stop': stop_value,
            //         'allday': allday_value,
            //         'privacy': 'confidential',
            //         'event_tz': user.tz,
            //         'activity_ids': [(5, 0, 0)],
            //         'res_id': holiday.id,
            //     }
            //     # Add the partner_id (if exist) as an attendee
            //     partner_id = (user and user.partner_id) or (holiday.employee_id and holiday.employee_id.work_contact_id)
            //     if partner_id:
            //         meeting_values['partner_ids'] = [(4, partner_id.id)]
            //     result[user.id].append(meeting_values)
            // return result
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceAggregatedTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filter_invl_to_apply, object filter_tax_values_to_apply, object grouping_key_generator, object round_from_tax_lines, object postfix_function) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_invoice_aggregated_taxes(
            //     self,
            //     filter_invl_to_apply=None,
            //     filter_tax_values_to_apply=None,
            //     grouping_key_generator=None,
            //     round_from_tax_lines=None,
            //     postfix_function=None,
            // ):
            //     """ This method is deprecated and will be removed in the next version.
            //     Use the following pattern instead:
            // 
            //     base_amls = self.line_ids.filtered(lambda x: x.display_type == 'product')
            //     base_lines = [self._prepare_product_base_line_for_taxes_computation(x) for x in base_amls]
            //     tax_amls = self.line_ids.filtered('tax_repartition_line_id')
            //     tax_lines = [self._prepare_tax_line_for_taxes_computation(x) for x in tax_amls]
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id, tax_lines=tax_lines)
            // 
            //     def grouping_function(base_line, tax_data):
            //         ...
            // 
            //     base_lines_aggregated_values = self._aggregate_base_lines_tax_details(base_lines, grouping_function)
            //     values_per_grouping_key = self._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            //     """
            //     self.ensure_one()
            //     AccountTax = self.env['account.tax']
            //     if round_from_tax_lines is None:
            //         round_from_tax_lines = filter_tax_values_to_apply or filter_invl_to_apply
            // 
            //     base_amls = self.line_ids.filtered(lambda x: x.display_type == 'product' and (not filter_invl_to_apply or filter_invl_to_apply(x)))
            //     base_lines = [self._prepare_product_base_line_for_taxes_computation(x) for x in base_amls]
            //     tax_amls = self.line_ids.filtered('tax_repartition_line_id')
            //     tax_lines = self._prepare_tax_lines_for_taxes_computation(tax_amls, round_from_tax_lines)
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     if postfix_function:
            //         postfix_function(base_lines)
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id, tax_lines=tax_lines)
            // 
            //     # Retro-compatibility with previous aggregator.
            //     results = {
            //         'base_amount_currency': 0.0,
            //         'base_amount': 0.0,
            //         'tax_amount_currency': 0.0,
            //         'tax_amount': 0.0,
            //         'tax_details_per_record': defaultdict(lambda: {
            //             'base_amount_currency': 0.0,
            //             'base_amount': 0.0,
            //             'tax_amount_currency': 0.0,
            //             'tax_amount': 0.0,
            //         }),
            //         'base_lines': base_lines,
            //     }
            // 
            //     def total_grouping_function(base_line, tax_data):
            //         if tax_data:
            //             return not filter_tax_values_to_apply or filter_tax_values_to_apply(base_line, tax_data)
            // 
            //     # Report the total amounts.
            //     base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(base_lines, total_grouping_function)
            //     for base_line, aggregated_values in base_lines_aggregated_values:
            //         record = base_line['record']
            //         base_line_results = results['tax_details_per_record'][record]
            //         base_line_results['base_line'] = base_line
            //         for grouping_key, values in aggregated_values.items():
            //             if grouping_key:
            //                 for key in ('base_amount', 'base_amount_currency', 'tax_amount', 'tax_amount_currency'):
            //                     base_line_results[key] += values[key]
            // 
            //     values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            //     for grouping_key, values in values_per_grouping_key.items():
            //         if grouping_key:
            //             for key in ('base_amount', 'base_amount_currency', 'tax_amount', 'tax_amount_currency'):
            //                 results[key] += values[key]
            // 
            //     # Same with the custom grouping_key passed as parameter.
            //     def tax_details_grouping_function(base_line, tax_data):
            //         if not total_grouping_function(base_line, tax_data):
            //             return None
            //         if grouping_key_generator:
            //             grouping_key = grouping_key_generator(base_line, tax_data)
            //             assert grouping_key is not None  # None must be kept for inner-grouping.
            //             return grouping_key
            //         return tax_data['tax']
            // 
            //     base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(base_lines, tax_details_grouping_function)
            //     for base_line, aggregated_values in base_lines_aggregated_values:
            //         record = base_line['record']
            //         base_line_results = results['tax_details_per_record'][record]
            //         base_line_results['tax_details'] = tax_details = {}
            //         for grouping_key, values in aggregated_values.items():
            //             if not grouping_key:
            //                 continue
            //             if isinstance(grouping_key, dict):
            //                 values.update(grouping_key)
            //             tax_details[grouping_key] = values
            // 
            //     values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            //     results['tax_details'] = tax_details = {}
            //     for grouping_key, values in values_per_grouping_key.items():
            //         if not grouping_key:
            //             continue
            //         if isinstance(grouping_key, dict):
            //             values.update(grouping_key)
            //         tax_details[grouping_key] = values
            // 
            //     return results
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveLineDefaultValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object write_off_line_vals, object force_balance) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _prepare_move_line_default_vals(self, write_off_line_vals=None, force_balance=None):
            // ''' Prepare the dictionary to create the default account.move.lines for the current payment.
            // :param write_off_line_vals: Optional list of dictionaries to create a write-off account.move.line easily containing:
            //     * amount:       The amount to be added to the counterpart amount.
            //     * name:         The label to set on the line.
            //     * account_id:   The account on which create the write-off.
            // :param force_balance: Optional balance.
            // :return: A list of python dictionary to be passed to the account.move.line's 'create' method.
            // '''
            // self.ensure_one()
            // write_off_line_vals = write_off_line_vals or []
            // 
            // if not self.outstanding_account_id:
            //     raise UserError(_(
            //         "You can't create a new payment without an outstanding payments/receipts account set either on the company or the %(payment_method)s payment method in the %(journal)s journal.",
            //         payment_method=self.payment_method_line_id.name, journal=self.journal_id.display_name))
            // 
            // # Compute amounts.
            // write_off_line_vals_list = write_off_line_vals or []
            // write_off_amount_currency = sum(x['amount_currency'] for x in write_off_line_vals_list)
            // write_off_balance = sum(x['balance'] for x in write_off_line_vals_list)
            // 
            // if self.payment_type == 'inbound':
            //     # Receive money.
            //     liquidity_amount_currency = self.amount
            // elif self.payment_type == 'outbound':
            //     # Send money.
            //     liquidity_amount_currency = -self.amount
            // else:
            //     liquidity_amount_currency = 0.0
            // 
            // if not write_off_line_vals and force_balance is not None:
            //     sign = 1 if liquidity_amount_currency > 0 else -1
            //     liquidity_balance = sign * abs(force_balance)
            // else:
            //     liquidity_balance = self.currency_id._convert(
            //         liquidity_amount_currency,
            //         self.company_id.currency_id,
            //         self.company_id,
            //         self.date,
            //     )
            // counterpart_amount_currency = -liquidity_amount_currency - write_off_amount_currency
            // counterpart_balance = -liquidity_balance - write_off_balance
            // currency_id = self.currency_id.id
            // 
            // # Compute a default label to set on the journal items.
            // liquidity_line_name = ''.join(x[1] for x in self._get_aml_default_display_name_list() if x[1])
            // counterpart_line_name = liquidity_line_name
            // 
            // line_vals_list = [
            //     # Liquidity line.
            //     {
            //         'name': liquidity_line_name,
            //         'date_maturity': self.date,
            //         'amount_currency': liquidity_amount_currency,
            //         'currency_id': currency_id,
            //         'debit': liquidity_balance if liquidity_balance > 0.0 else 0.0,
            //         'credit': -liquidity_balance if liquidity_balance < 0.0 else 0.0,
            //         'partner_id': self.partner_id.id,
            //         'account_id': self.outstanding_account_id.id,
            //     },
            //     # Receivable / Payable.
            //     {
            //         'name': counterpart_line_name,
            //         'date_maturity': self.date,
            //         'amount_currency': counterpart_amount_currency,
            //         'currency_id': currency_id,
            //         'debit': counterpart_balance if counterpart_balance > 0.0 else 0.0,
            //         'credit': -counterpart_balance if counterpart_balance < 0.0 else 0.0,
            //         'partner_id': self.partner_id.id,
            //         'account_id': self.destination_account_id.id,
            //     },
            // ]
            // return line_vals_list + write_off_line_vals_list
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> PrepareMoveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> PrepareNonDeductibleBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object non_deductible_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_non_deductible_base_line_for_taxes_computation(self, non_deductible_line):
            // """ Convert an account.move.line having display_type='non_deductible' into a base line for the taxes computation.
            // 
            // :param non_deductible_line: An account.move.line.
            // :return: A base line returned by '_prepare_base_line_for_taxes_computation'.
            // """
            // self.ensure_one()
            // sign = self.direction_sign
            // rate = self.invoice_currency_rate
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     non_deductible_line,
            //     price_unit=sign * non_deductible_line.amount_currency,
            //     quantity=1.0,
            //     sign=sign,
            //     special_mode='total_excluded',
            //     special_type='non_deductible',
            // 
            //     is_refund=self.move_type in ('out_refund', 'in_refund'),
            //     rate=rate,
            // )
            */
            return default;
        }

        public async Task<TEntity> PrepareNonDeductibleBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_non_deductible_base_lines_for_taxes_computation_from_base_lines(self, base_lines):
            // """ Anticipate the non deductible lines to be generated from the base lines passed as parameter.
            // When the record is in draft (not saved), the accounting items are not there so we can't
            // call '_prepare_non_deductible_base_line_for_taxes_computation'.
            // 
            // :param base_lines: The base lines generated by '_prepare_product_base_line_for_taxes_computation'.
            // :return: A list of base lines representing the non deductible lines.
            // """
            // self.ensure_one()
            // non_deductible_product_lines = base_lines.filtered(lambda line: line.display_type == 'product' and float_compare(line.deductible_amount, 100, precision_digits=2))
            // if not non_deductible_product_lines:
            //     return []
            // 
            // sign = self.direction_sign
            // rate = self.invoice_currency_rate
            // 
            // non_deductible_lines_base_total_currency = 0.0
            // non_deductible_lines = []
            // for line in non_deductible_product_lines:
            //     percentage = 1 - line.deductible_amount / 100
            //     non_deductible_subtotal = line.currency_id.round(line.price_subtotal * percentage)
            //     non_deductible_base_currency = line.company_currency_id.round(sign * non_deductible_subtotal / rate) if rate else 0.0
            //     non_deductible_lines_base_total_currency += non_deductible_base_currency
            // 
            //     non_deductible_lines += [
            //         self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //             None,
            //             price_unit=-non_deductible_base_currency,
            //             quantity=1.0,
            //             sign=1,
            //             special_mode='total_excluded',
            //             special_type='non_deductible',
            //             tax_ids=line.tax_ids.filtered(lambda tax: tax.amount_type != 'fixed'),
            //             currency_id=self.currency_id,
            //         )
            //     ]
            // non_deductible_lines += [
            //     self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //         None,
            //         price_unit=non_deductible_lines_base_total_currency,
            //         quantity=1.0,
            //         sign=1,
            //         special_mode='total_excluded',
            //         special_type=False,
            //         currency_id=self.currency_id,
            //     )
            // ]
            // return non_deductible_lines
            */
            return default;
        }

        public async Task<TEntity> PreparePaymentsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> PrepareProductBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_product_base_line_for_taxes_computation(self, product_line):
            // """ Convert an account.move.line having display_type='product' into a base line for the taxes computation.
            // 
            // :param product_line: An account.move.line.
            // :return: A base line returned by '_prepare_base_line_for_taxes_computation'.
            // """
            // self.ensure_one()
            // is_invoice = self.is_invoice(include_receipts=True)
            // sign = self.direction_sign if is_invoice else 1
            // if is_invoice:
            //     rate = self.invoice_currency_rate
            // else:
            //     rate = (abs(product_line.amount_currency) / abs(product_line.balance)) if product_line.balance else 0.0
            // 
            // return self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //     product_line,
            //     price_unit=product_line.price_unit if is_invoice else product_line.amount_currency,
            //     quantity=product_line.quantity if is_invoice else 1.0,
            //     discount=product_line.discount if is_invoice else 0.0,
            //     rate=rate,
            //     sign=sign,
            //     special_mode=False if is_invoice else 'total_excluded',
            //     name=product_line.name,
            // )
            */
            return default;
        }

        public async Task<TEntity> PrepareReceiptsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> PrepareResourceLeaveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _prepare_resource_leave_vals(self):
            // """Hook method for others to inject data
            // """
            // self.ensure_one()
            // return {
            //     'name': _("%s: Time Off", self.employee_id.name),
            //     'date_from': self.date_from,
            //     'holiday_id': self.id,
            //     'date_to': self.date_to,
            //     'resource_id': self.employee_id.resource_id.id,
            //     'calendar_id': self.resource_calendar_id.id,
            //     'time_type': self.holiday_status_id.time_type,
            //     'elligible_for_accrual_rate': self.holiday_status_id.elligible_for_accrual_rate,
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareResourceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tz) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _prepare_resource_values(self, vals, tz):
            // resource_vals = super()._prepare_resource_values(vals, tz)
            // vals.pop('name')  # Already considered by super call but no popped
            // # We need to pop it to avoid useless resource update (& write) call
            // # on every newly created resource (with the correct name already)
            // user_id = vals.pop('user_id', None)
            // if user_id:
            //     resource_vals['user_id'] = user_id
            // active_status = vals.get('active')
            // if active_status is not None:
            //     resource_vals['active'] = active_status
            // return resource_vals
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_tax_line_for_taxes_computation(self, tax_line):
            // """ Convert an account.move.line having display_type='tax' into a tax line for the taxes computation.
            // 
            // :param tax_line: An account.move.line.
            // :return: A tax line returned by '_prepare_tax_line_for_taxes_computation'.
            // """
            // self.ensure_one()
            // return self.env['account.tax']._prepare_tax_line_for_taxes_computation(
            //     tax_line,
            //     sign=self.direction_sign,
            // )
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxLinesForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_amls, object round_from_tax_lines) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _prepare_tax_lines_for_taxes_computation(self, tax_amls, round_from_tax_lines):
            // if round_from_tax_lines:
            //     return [self._prepare_tax_line_for_taxes_computation(x) for x in tax_amls]
            // return []
            */
            return default;
        }

        public async Task<TEntity> PreviewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def preview_invoice(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': self.get_portal_url(),
            // }
            */
            return default;
        }

        public async Task<TEntity> QuickEditModeSuggestInvoiceDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _quick_edit_mode_suggest_invoice_date(self):
            // """Suggest the Customer Invoice/Vendor Bill date based on previous invoice and lock dates"""
            // for record in self:
            //     if record.quick_edit_mode and not record.invoice_date:
            //         invoice_date = fields.Date.context_today(self)
            //         prev_move = self.search([('state', '=', 'posted'),
            //                                  ('journal_id', '=', record.journal_id.id),
            //                                  ('company_id', '=', record.company_id.id),
            //                                  ('invoice_date', '!=', False)],
            //                                 limit=1)
            //         if prev_move:
            //             invoice_date = self._get_accounting_date(prev_move.invoice_date, False)
            //         record.invoice_date = invoice_date
            */
            return default;
        }

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def read(self, fields=None, load='_classic_read'):
            // fields = fields or self._get_default_read_fields()
            // return super().read(fields, load)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve job_id from the context and write the domain: ids + contextual columns (job or default)
            // job_id = self.env.context.get('default_job_id')
            // search_domain = [('job_ids', '=', False)]
            // if job_id:
            //     search_domain = ['|', ('job_ids', '=', job_id)] + search_domain
            // if stages:
            //     search_domain = ['|', ('id', 'in', stages.ids)] + search_domain
            // 
            // stage_ids = stages.sudo()._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        public async Task<TEntity> ReasonCannotDecodeHasInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _reason_cannot_decode_has_invoice_lines(self):
            // """ Helper to get a reason why an invoice cannot be decoded if it has invoice lines. """
            // if self.invoice_line_ids:
            //     return self.env._("The invoice already contains lines.")
            */
            return default;
        }

        public async Task<TEntity> RecomputeCashRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _recompute_cash_rounding_lines(self):
            // ''' Handle the cash rounding feature on invoices.
            // 
            // In some countries, the smallest coins do not exist. For example, in Switzerland, there is no coin for 0.01 CHF.
            // For this reason, if invoices are paid in cash, you have to round their total amount to the smallest coin that
            // exists in the currency. For the CHF, the smallest coin is 0.05 CHF.
            // 
            // There are two strategies for the rounding:
            // 
            // 1) Add a line on the invoice for the rounding: The cash rounding line is added as a new invoice line.
            // 2) Add the rounding in the biggest tax amount: The cash rounding line is added as a new tax line on the tax
            // having the biggest balance.
            // '''
            // self.ensure_one()
            // def _compute_cash_rounding(self, total_amount_currency):
            //     ''' Compute the amount differences due to the cash rounding.
            //     :param self:                    The current account.move record.
            //     :param total_amount_currency:   The invoice's total in invoice's currency.
            //     :return:                        The amount differences both in company's currency & invoice's currency.
            //     '''
            //     difference = self.invoice_cash_rounding_id.compute_difference(self.currency_id, total_amount_currency)
            //     if self.currency_id == self.company_id.currency_id:
            //         diff_amount_currency = diff_balance = difference
            //     else:
            //         diff_amount_currency = difference
            //         diff_balance = self.currency_id._convert(diff_amount_currency, self.company_id.currency_id, self.company_id, self.invoice_date or self.date)
            //     return diff_balance, diff_amount_currency
            // 
            // def _apply_cash_rounding(self, diff_balance, diff_amount_currency, cash_rounding_line):
            //     ''' Apply the cash rounding.
            //     :param self:                    The current account.move record.
            //     :param diff_balance:            The computed balance to set on the new rounding line.
            //     :param diff_amount_currency:    The computed amount in invoice's currency to set on the new rounding line.
            //     :param cash_rounding_line:      The existing cash rounding line.
            //     :return:                        The newly created rounding line.
            //     '''
            //     rounding_line_vals = {
            //         'balance': diff_balance,
            //         'amount_currency': diff_amount_currency,
            //         'partner_id': self.partner_id.id,
            //         'move_id': self.id,
            //         'currency_id': self.currency_id.id,
            //         'company_id': self.company_id.id,
            //         'company_currency_id': self.company_id.currency_id.id,
            //         'display_type': 'rounding',
            //     }
            // 
            //     if self.invoice_cash_rounding_id.strategy == 'biggest_tax':
            //         biggest_tax_line = None
            //         for tax_line in self.line_ids.filtered('tax_repartition_line_id'):
            //             if not biggest_tax_line or abs(tax_line.balance) > abs(biggest_tax_line.balance):
            //                 biggest_tax_line = tax_line
            // 
            //         # No tax found.
            //         if not biggest_tax_line:
            //             return
            // 
            //         rounding_line_vals.update({
            //             'name': _("%(tax_name)s (rounding)", tax_name=biggest_tax_line.name),
            //             'account_id': biggest_tax_line.account_id.id,
            //             'tax_repartition_line_id': biggest_tax_line.tax_repartition_line_id.id,
            //             'tax_tag_ids': [(6, 0, biggest_tax_line.tax_tag_ids.ids)],
            //             'tax_ids': [Command.set(biggest_tax_line.tax_ids.ids)]
            //         })
            // 
            //     elif self.invoice_cash_rounding_id.strategy == 'add_invoice_line':
            //         if diff_balance > 0.0 and self.invoice_cash_rounding_id.loss_account_id:
            //             account_id = self.invoice_cash_rounding_id.loss_account_id.id
            //         else:
            //             account_id = self.invoice_cash_rounding_id.profit_account_id.id
            //         rounding_line_vals.update({
            //             'name': self.invoice_cash_rounding_id.name,
            //             'account_id': account_id,
            //             'tax_ids': [Command.clear()]
            //         })
            // 
            //     # Create or update the cash rounding line.
            //     if cash_rounding_line:
            //         cash_rounding_line.write(rounding_line_vals)
            //     else:
            //         cash_rounding_line = self.env['account.move.line'].create(rounding_line_vals)
            // 
            // existing_cash_rounding_line = self.line_ids.filtered(lambda line: line.display_type == 'rounding')
            // 
            // # The cash rounding has been removed.
            // if not self.invoice_cash_rounding_id:
            //     existing_cash_rounding_line.unlink()
            //     # self.line_ids -= existing_cash_rounding_line
            //     return
            // 
            // # The cash rounding strategy has changed.
            // if self.invoice_cash_rounding_id and existing_cash_rounding_line:
            //     strategy = self.invoice_cash_rounding_id.strategy
            //     old_strategy = 'biggest_tax' if existing_cash_rounding_line.tax_line_id else 'add_invoice_line'
            //     if strategy != old_strategy:
            //         # self.line_ids -= existing_cash_rounding_line
            //         existing_cash_rounding_line.unlink()
            //         existing_cash_rounding_line = self.env['account.move.line']
            // 
            // others_lines = self.line_ids.filtered(lambda line: line.account_id.account_type not in ('asset_receivable', 'liability_payable'))
            // others_lines -= existing_cash_rounding_line
            // total_amount_currency = sum(others_lines.mapped('amount_currency'))
            // 
            // diff_balance, diff_amount_currency = _compute_cash_rounding(self, total_amount_currency)
            // 
            // # The invoice is already rounded.
            // if self.currency_id.is_zero(diff_balance) and self.currency_id.is_zero(diff_amount_currency):
            //     existing_cash_rounding_line.unlink()
            //     # self.line_ids -= existing_cash_rounding_line
            //     return
            // 
            // # No update needed
            // if existing_cash_rounding_line \
            //     and float_compare(existing_cash_rounding_line.balance, diff_balance, precision_rounding=self.currency_id.rounding) == 0 \
            //     and float_compare(existing_cash_rounding_line.amount_currency, diff_amount_currency, precision_rounding=self.currency_id.rounding) == 0:
            //     return
            // 
            // _apply_cash_rounding(self, diff_balance, diff_amount_currency, existing_cash_rounding_line)
            */
            return default;
        }

        public async Task<TEntity> ReconcileReversedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse_moves, object move_reverse_cancel) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _reconcile_reversed_moves(self, reverse_moves, move_reverse_cancel):
            // ''' Reconciles moves in self and reverse moves
            // :param move_reverse_cancel: parameter used when lines are reconciled
            //                             will determine whether the tax cash basis journal entries should be created
            // :param reverse_moves:       An account.move recordset, reverse of the current self.
            // :return:                    An account.move recordset, reverse of the current self.
            // '''
            // for move, reverse_move in zip(self, reverse_moves):
            //     group = (move.line_ids + reverse_move.line_ids) \
            //         .filtered(lambda l: not l.reconciled) \
            //         .sorted(lambda l: l.account_type not in ('asset_receivable', 'liability_payable')) \
            //         .grouped(lambda l: (l.account_id, l.currency_id))
            //     for (account, _currency), lines in group.items():
            //         if (
            //             all(not line.reconciled for line in lines) # if it was reconciled due to a previous group
            //             and account.reconcile or account.account_type in ('asset_cash', 'liability_credit_card')
            //         ):
            //             lines.with_context(move_reverse_cancel=move_reverse_cancel).reconcile()
            // return reverse_moves
            */
            return default;
        }

        public async Task<TEntity> RefreshInvoiceCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def refresh_invoice_currency_rate(self):
            // for move in self:
            //     move.invoice_currency_rate = move.expected_currency_rate
            */
            return default;
        }

        public async Task<TEntity> RefundsOriginRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _refunds_origin_required(self):
            // return False
            */
            return default;
        }

        public async Task<TEntity> RemoveResourceLeaveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _remove_resource_leave(self):
            // """ This method will create entry in resource calendar time off object at the time of holidays cancel/removed """
            // return self.env['resource.calendar.leaves'].search([('holiday_id', 'in', self.ids)]).unlink()
            */
            return default;
        }

        public async Task<TEntity> RemoveWorkContactIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_company) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _remove_work_contact_id(self, user, employee_company):
            // """ Remove work_contact_id for previous employee if the user is assigned to a new employee """
            // employee_company = employee_company or self.company_id.id
            // # For employees with a user_id, the constraint (user can't be linked to multiple employees) is triggered
            // old_partner_employee_ids = user.partner_id.employee_ids.filtered(lambda e:
            //     not e.user_id
            //     and e.company_id.id == employee_company
            //     and e != self
            // )
            // old_partner_employee_ids.work_contact_id = None
            */
            return default;
        }

        public async Task<TEntity> RequireBillDateForAutopostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _require_bill_date_for_autopost(self):
            // """Vendor bills must have an invoice date set to be posted. Require it for auto-posted bills."""
            // for record in self:
            //     if record.auto_post != 'no' and record.is_purchase_document() and not record.invoice_date:
            //         raise ValidationError(_("For this entry to be automatically posted, it required a bill date."))
            */
            return default;
        }

        public async Task<TEntity> ResetApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def reset_applicant(self):
            // """ Reinsert the applicant into the recruitment pipe in the first stage"""
            // default_stage = dict()
            // for job_id in self.mapped('job_id'):
            //     default_stage[job_id.id] = self.env['hr.recruitment.stage'].search(
            //         [
            //             '|',
            //             ('job_ids', '=', False),
            //             ('job_ids', '=', job_id.id),
            //             ('fold', '=', False)
            //         ], order='sequence asc', limit=1).id
            // for applicant in self:
            //     applicant.write(
            //         {'stage_id': applicant.job_id.id and default_stage[applicant.job_id.id],
            //          'refuse_reason_id': False})
            */
            return default;
        }

        public async Task<TEntity> ReverseMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_values_list, object cancel) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _reverse_moves(self, default_values_list=None, cancel=False):
            // ''' Reverse a recordset of account.move.
            // If cancel parameter is true, the reconcilable or liquidity lines
            // of each original move will be reconciled with its reverse's.
            // :param default_values_list: A list of default values to consider per move.
            //                             ('type' & 'reversed_entry_id' are computed in the method).
            // :return:                    An account.move recordset, reverse of the current self.
            // '''
            // if not default_values_list:
            //     default_values_list = [{} for move in self]
            // 
            // if cancel:
            //     lines = self.mapped('line_ids')
            //     # Avoid maximum recursion depth.
            //     if lines:
            //         lines.remove_move_reconcile()
            // 
            // reverse_moves = self.env['account.move']
            // for move, default_values in zip(self, default_values_list):
            //     default_values.update({
            //         'move_type': TYPE_REVERSE_MAP[move.move_type],
            //         'reversed_entry_id': move.id,
            //         'partner_id': move.partner_id.id,
            //     })
            //     reverse_moves += move.with_context(
            //         move_reverse_cancel=cancel,
            //         include_business_fields=True,
            //         skip_invoice_sync=move.move_type == 'entry',
            //     ).copy(default_values)
            // 
            // reverse_moves.with_context(skip_invoice_sync=cancel).write({'line_ids': [
            //     Command.update(line.id, {
            //         'balance': -line.balance,
            //         'amount_currency': -line.amount_currency,
            //         **({'is_storno': not line.is_storno} if line.company_id.account_storno else {}),
            //     })
            //     for line in reverse_moves.line_ids
            //     if line.move_id.move_type == 'entry' or line.display_type == 'cogs'
            // ]})
            // 
            // # Reconcile moves together to cancel the previous one.
            // if cancel:
            //     reverse_moves.with_context(move_reverse_cancel=cancel)._post(soft=False)
            // 
            // return reverse_moves
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoutingCheckRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object route, object raise_exception) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _routing_check_route(self, message, message_dict, route, raise_exception=True):
            // if route[0] == 'account.move' and len(message_dict['attachments']) < 1:
            //     # Don't create the move if no attachment.
            //     company_id = route[2].get('company_id', self.env.company.id)
            //     if not isinstance(company_id, int):
            //         raise ValueError(_("Default value for 'company_id' for %(record)s is not an integer",
            //                           record=route[4]))
            //     journal_alias_company = self.env['res.company'].search([['id', '=', company_id]])
            //     body = self.env['ir.qweb']._render('account.email_template_mail_gateway_failed', {
            //         'company_email': journal_alias_company.email or self.env.company.email,
            //         'company_name': journal_alias_company.name or self.env.company.name,
            //     })
            //     self._routing_create_bounce_email(
            //         message_dict['from'], body, message,
            //         references=f'{message_dict["message_id"]} {generate_tracking_message_id("loop-detection-bounce-email")}')
            //     return ()
            // return super()._routing_check_route(message, message_dict, route, raise_exception=raise_exception)
            */
            return default;
        }

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sanitize_vals(self, vals):
            // if vals.get('invoice_line_ids') and vals.get('line_ids'):
            //     # values can sometimes be in only one of the two fields, sometimes in
            //     # both fields, sometimes one field can be explicitely empty while the other
            //     # one is not, sometimes not...
            //     update_vals = {
            //         line_id: line_vals[0]
            //         for command, line_id, *line_vals in vals['invoice_line_ids']
            //         if command == Command.UPDATE
            //     }
            //     for command, line_id, *line_vals in vals['line_ids']:
            //         if command == Command.UPDATE and line_id in update_vals:
            //             line_vals[0].update(update_vals.pop(line_id))
            //     for line_id, line_vals in update_vals.items():
            //         vals['line_ids'] += [Command.update(line_id, line_vals)]
            //     for command, line_id, *line_vals in vals['invoice_line_ids']:
            //         assert command not in (Command.SET, Command.CLEAR)
            //         if [command, line_id, *line_vals] not in vals['line_ids']:
            //             vals['line_ids'] += [(command, line_id, *line_vals)]
            //     del vals['invoice_line_ids']
            // return vals
            */
            return default;
        }

        public async Task<TEntity> SearchApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_application_status(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // domains = []
            // # Map statuses to domain filters
            // if 'refused' in value:
            //     domains.append([('active', '=', True), ('refuse_reason_id', '!=', None)])
            // if 'hired' in value:
            //     domains.append([('active', '=', True), ('date_closed', '!=', False)])
            // if 'archived' in value or False in value:
            //     domains.append([('active', '=', False)])
            // if 'ongoing' in value:
            //     domains.append([('active', '=', True), ('date_closed', '=', False)])
            // 
            // return Domain.OR(domains)
            */
            return default;
        }

        public async Task<TEntity> SearchDefaultJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_default_journal(self):
            // if self.statement_line_ids.statement_id.journal_id:
            //     return self.statement_line_ids.statement_id.journal_id[:1]
            // 
            // journal_types = self._get_valid_journal_types()
            // company = self.company_id or self.env.company
            // domain = [
            //     *self.env['account.journal']._check_company_domain(company),
            //     ('type', 'in', journal_types),
            // ]
            // 
            // journal = None
            // # the currency is not a hard dependence, it triggers via manual add_to_compute
            // # avoid computing the currency before all it's dependences are set (like the journal...)
            // if self.env.cache.contains(self, self._fields['currency_id']):
            //     currency_id = self.currency_id.id or self.env.context.get('default_currency_id')
            //     if currency_id and currency_id != company.currency_id.id:
            //         currency_domain = domain + [('currency_id', '=', currency_id)]
            //         journal = self.env['account.journal'].search(currency_domain, limit=1)
            // 
            // if not journal:
            //     journal = self.env['account.journal'].search(domain, limit=1)
            // 
            // if not journal:
            //     error_msg = self.env['account.journal']._build_no_journal_error_msg(company.display_name, journal_types)
            //     raise UserError(error_msg)
            // 
            // return journal
            */
            return default;
        }

        public async Task<TEntity> SearchDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _search_description(self, operator, value):
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // domain = Domain('private_name', operator, value)
            // 
            // if not is_officer:
            //     domain &= Domain('user_id', '=', self.env.user.id)
            // query = self.sudo()._search(domain)
            // return Domain('id', 'in', query)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def search_fetch(self, domain, field_names=None, offset=0, limit=None, order=None):
            // if self.browse().has_access('read'):
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // if field_names is None:
            //     field_names = [field.name for field in self._determine_fields_to_fetch()]
            // field_names = [f_name for f_name in field_names if f_name != 'current_version_id']
            // self._check_private_fields(field_names)
            // self.flush_model(field_names)
            // public = self.env['hr.employee.public'].search_fetch(domain, field_names, offset, limit, order)
            // employees = self.browse(public._ids)
            // employees._copy_cache_from(public, field_names)
            // return employees
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None, *, bypass_access=False, **kwargs):
            // """
            //     We override the _search because it is the method that checks the access rights
            //     This is correct to override the _search. That way we enforce the fact that calling
            //     search on an hr.employee returns a hr.employee recordset, even if you don't have access
            //     to this model, as the result of _search (the ids of the public employees) is to be
            //     browsed on the hr.employee model. This can be trusted as the ids of the public
            //     employees exactly match the ids of the related hr.employee.
            // """
            // if self.browse().has_access('read') or bypass_access:
            //     return super()._search(domain, offset, limit, order, bypass_access=bypass_access, **kwargs)
            // domain = Domain(domain)
            // # HACK Some fields are inherited from the `current_version_id` and may have been already
            // # optimized, showing current_version_id in the domain, but public employee does not have
            // # that field and may have fields directly on the model, just change the condition to `id` in
            // # that case.
            // domain = domain.map_conditions(lambda cond: Domain('id', cond.operator, cond.value) if cond.field_expr == 'current_version_id' else cond)
            // try:
            //     ids = self.env['hr.employee.public']._search(domain, offset, limit, order, **kwargs)
            // except ValueError as e:
            //     raise AccessError(self.env._('You do not have access to this document.')) from e
            // # the result is expected from this table, so we should link tables
            // return super(HrEmployee, self.sudo())._search([('id', 'in', ids)], order=order)
            */
            return default;
        }

        public async Task<TEntity> SearchIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_is_applicant_in_pool(self, operator, value):
            // """
            // This function is needed to hide duplicates when adding applicants/talents to a talent pool.
            // All applications that have either talent_pool_ids or pool_applicant_id set are considered
            // directly in a pool. Furthermore, any application with the same phone number, email or linkedin
            // as the first applications, that are directly in the pool, are also considered to belong to
            // the same talent pool.
            // 
            // Returns:
            //     returns a domain with ids of applications that are either directly or indirectly linked to a pool
            // """
            // if operator != 'in':
            //     return NotImplemented
            // 
            // return [('id', 'in', SQL("""
            //         WITH talent_pool_applicants AS (
            //             SELECT
            //                    a.id as id,
            //                    email_normalized,
            //                    partner_phone_sanitized,
            //                    linkedin_profile
            //               FROM hr_applicant a
            //          LEFT JOIN hr_applicant_hr_talent_pool_rel rel
            //                 ON a.id = rel.hr_applicant_id
            //              WHERE pool_applicant_id IS NOT NULL
            //                 OR hr_talent_pool_id IS NOT NULL
            //         )
            //         SELECT a.id
            //         FROM hr_applicant a
            //         WHERE
            //             -- Check if directly linked to a pool
            //             (a.id IN (
            //                 SELECT DISTINCT id
            //                 from talent_pool_applicants
            //             ))
            //             OR
            //             -- Check if email matches any talent pool applicant
            //             (a.email_normalized IN (
            //                 SELECT DISTINCT email_normalized
            //                 FROM talent_pool_applicants
            //                 WHERE email_normalized IS NOT NULL
            //             ))
            //             OR
            //             -- Check if phone matches any talent pool applicant
            //             (a.partner_phone_sanitized IN (
            //                 SELECT DISTINCT partner_phone_sanitized
            //                 FROM talent_pool_applicants
            //                 WHERE partner_phone_sanitized IS NOT NULL
            //             ))
            //             OR
            //             -- Check if LinkedIn profile matches any talent pool applicant
            //             (a.linkedin_profile IN (
            //                 SELECT DISTINCT linkedin_profile
            //                 FROM talent_pool_applicants
            //                 WHERE linkedin_profile IS NOT NULL
            //             ))
            // """))]
            */
            return default;
        }

        public async Task<TEntity> SearchJournalGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_journal_group_id(self, operator, value):
            // field = 'name' if 'like' in operator else 'id'
            // journal_groups = self.env['account.journal.group'].search([(field, operator, value)])
            // return Domain.OR([
            //     Domain('journal_id', 'not in', group.excluded_journal_ids.ids)
            //     & Domain('journal_id.company_id', '=?', group.company_id.id)
            //     for group in journal_groups
            // ])
            */
            return default;
        }

        public async Task<TEntity> SearchMoveSentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_move_sent_values(self, operator, value):
            // if operator != 'in' or value - {'sent', 'not_sent'}:
            //     return NotImplemented
            // return [('is_move_sent', 'in', [elem == 'sent' for elem in value])]
            */
            return default;
        }

        public async Task<TEntity> SearchNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search_newly_hired(self, operator, value):
            // if operator not in ('in', 'not in'):
            //     return NotImplemented
            // new_hire_field = self._get_new_hire_field()
            // new_hires = self.env['hr.employee'].sudo().search([
            //     (new_hire_field, '>', fields.Datetime.now() - timedelta(days=90))
            // ])
            // return [('id', operator, new_hires.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_next_payment_date(self, operator, value):
            // if operator not in ('in', '<', '<='):
            //     return NotImplemented
            // return [('line_ids', 'any', [('reconciled', '=', False), ('payment_date', operator, value)])]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def search_read(self, domain=None, fields=None, offset=0, limit=None, order=None, **read_kwargs):
            // fields = fields or self._get_default_read_fields()
            // return super().search_read(domain, fields, offset, limit, order, **read_kwargs)
            */
            return default;
        }

        public async Task<TEntity> SearchReconciledInvoiceIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _search_reconciled_invoice_ids(self, operator, value):
            // if operator not in ('in', '='):
            //     return NotImplemented
            // move_ids = self.env['account.move'].browse(value).reconciled_payment_ids.ids
            // return [('id', 'in', move_ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_reconciled_payment_ids(self, operator, value):
            // if operator not in ('in', '='):
            //     return NotImplemented
            // payment_ids = self.env['account.payment'].browse(value).reconciled_invoice_ids.ids
            // return [('id', 'in', payment_ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_secured(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // assert list(value) == [True]
            // return [('inalterable_hash', '!=', False)]
            */
            return default;
        }

        public async Task<TEntity> SearchVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search_version_id(self, operator, value):
            // if operator in ('any', 'any!'):
            //     return Domain('current_version_id', operator, value)
            // domain = Domain('id', operator, value)
            // return Domain('id', 'in', self.env['hr.version']._search(domain).select('employee_id'))
            */
            return default;
        }

        public async Task<TEntity> SeekForLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _seek_for_lines(self):
            // ''' Helper used to dispatch the journal items between:
            // - The lines using the temporary liquidity account.
            // - The lines using the counterpart account.
            // - The lines being the write-off lines.
            // :return: (liquidity_lines, counterpart_lines, writeoff_lines)
            // '''
            // self.ensure_one()
            // 
            // # liquidity_lines, counterpart_lines, writeoff_lines
            // lines = [self.env['account.move.line'] for _dummy in range(3)]
            // valid_account_types = self._get_valid_payment_account_types()
            // for line in self.move_id.line_ids:
            //     if line.account_id in self._get_valid_liquidity_accounts():
            //         lines[0] += line  # liquidity_lines
            //     elif line.account_id.account_type in valid_account_types or line.account_id == line.company_id.transfer_account_id:
            //         lines[1] += line  # counterpart_lines
            //     else:
            //         lines[2] += line  # writeoff_lines
            // 
            // # In some case, there is no liquidity or counterpart line (after changing an outstanding account on the journal for example)
            // # In that case, and if there is one writeoff line, we take this line and set it as liquidity/counterpart line
            // if len(lines[2]) == 1:
            //     for i in (0, 1):
            //         if not lines[i]:
            //             lines[i] = lines[2]
            //             lines[2] -= lines[2]
            // 
            // return lines
            */
            return default;
        }

        public async Task<TEntity> SendExpenseSuccessMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object expense) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> SendOnlyWhenReadyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _send_only_when_ready(self):
            // moves_not_ready = self.filtered(lambda x: not x._is_ready_to_be_sent())
            // 
            // try:
            //     yield
            // finally:
            //     moves_now_ready = moves_not_ready.filtered(lambda x: x._is_ready_to_be_sent())
            //     if moves_now_ready:
            //         moves_now_ready._action_invoice_ready_to_be_sent()
            */
            return default;
        }

        public async Task<TEntity> SequenceFixedRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_fixed_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_fixed_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_monthly_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_monthly_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_yearly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_yearly_regex
            */
            return default;
        }

        public async Task<TEntity> SetExpenseCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_today) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> SetMovesCheckedAsync<TEntity>(IEnumerable<TEntity> entities, object is_checked) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def set_moves_checked(self, is_checked=True):
            // for move in self.filtered(lambda m: m.state == 'posted'):
            //     move.checked = is_checked
            */
            return default;
        }

        public async Task<TEntity> SetNextMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities, bool made_gap) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _set_next_made_sequence_gap(self, made_gap: bool):
            // """Update the field made_sequence_gap on the next moves of the current ones.
            // 
            // Either:
            // - we changed something related to the sequence on the current moves, so we need to set the
            //   sequence as broken on the next moves before updating (made_gap=True)
            // - we are filling a gap, so we need to update the next move to remove the flag (made_gap=False)
            // """
            // next_moves = self.browse()
            // named = self.filtered(lambda m: m.name and m.name != '/')
            // for (journal, prefix), moves in named.grouped(lambda move: (move.journal_id, move.sequence_prefix)).items():
            //     next_moves += self.env['account.move'].sudo().search([
            //         ('journal_id', '=', journal.id),
            //         ('sequence_prefix', '=', prefix),
            //         ('sequence_number', 'in', [move.sequence_number + 1 for move in moves]),
            //     ])
            // next_moves.made_sequence_gap = made_gap
            */
            return default;
        }

        public async Task<TEntity> SetReversedEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credit_note) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _set_reversed_entry(self, credit_note):
            // """ Try to find the original invoice for a single credit_note. """
            // if len(credit_note) != 1 or credit_note.move_type != 'out_refund':
            //     return
            // 
            // original_invoice = self.filtered(lambda inv: inv.move_type == 'out_invoice'
            //                                  and credit_note.invoice_line_ids.sale_line_ids in inv.invoice_line_ids.sale_line_ids)
            // if len(original_invoice) == 1 and original_invoice._refunds_origin_required():
            //     credit_note.reversed_entry_id = original_invoice.id
            */
            return default;
        }

        public async Task<TEntity> ShowAutopostBillsWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _show_autopost_bills_wizard(self):
            // if (
            //     len(self) != 1
            //     or self.state != "posted"
            //     or not self.is_purchase_document(include_receipts=True)
            //     or self.restrict_mode_hash_table
            //     or all(not l.is_imported for l in self.line_ids)
            //     or not self.partner_id
            //     or self.partner_id.autopost_bills != "ask"
            //     or not self.company_id.autopost_bills
            //     or self.is_manually_modified
            // ):
            //     return False
            // prev_bills_same_partner = self.search([
            //     ('id', '!=', self.id),
            //     ('partner_id', '=', self.partner_id.id),
            //     ('state', '=', 'posted'),
            //     ('move_type', 'in', self.get_purchase_types(include_receipts=True)),
            // ], order="create_date DESC", limit=10)
            // nb_unmodified_bills = 1  # +1 for current bill that hasn't been modified either
            // for move in prev_bills_same_partner:
            //     if move.is_manually_modified:
            //         break
            //     nb_unmodified_bills += 1
            // if nb_unmodified_bills < 3:
            //     return False
            // wizard = self.env['account.autopost.bills.wizard'].create({
            //     'partner_id': self.partner_id.id,
            //     'nb_unmodified_bills': nb_unmodified_bills,
            // })
            // return {
            //     'name': _("Autopost Bills"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.autopost.bills.wizard',
            //     'res_id': wizard.id,
            //     'views': [(False, 'form')],
            //     'target': 'new',
            // }
            */
            return default;
        }

        public async Task<TEntity> SplitLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object split_date_from, object split_date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _split_leaves(self, split_date_from, split_date_to=False):
            // """
            // This method splits an original leave in two leaves and returns the new one for each leave in self.
            // E.g. (start, stop) -> (start, split_date_from - 1day), (split_date_to, stop)
            // :param split_date_from: The starting date of the splicing interval (includes)
            // :param split_date_to: The ending date of the splicing interval. (not includes)
            // :param changes_message: The message will be translated and posted in the first leave's chatter
            // 
            // If split_date_to is not set; the splicing interval will be equals to [split_date_form, split_date_from -1]
            // to avoid one day leave.
            // """
            // new_leaves_vals = []
            // if not split_date_to:
            //     split_date_to = split_date_from
            // 
            // # Only leaves that span a period outside of the split interval need
            // # to be split.
            // multi_day_leaves = self.filtered(lambda l: l.request_date_from < split_date_from or l.request_date_to >= split_date_to)
            // for leave in multi_day_leaves:
            //     new_leave_vals = []
            //     target_leave_vals = []
            //     if leave.request_date_from < split_date_from:
            //         new_leave_vals.append(leave.with_context(skip_copy_check=True).copy_data({
            //             'request_date_to': split_date_from + timedelta(days=-1),
            //             'state': leave.state
            //         })[0])
            // 
            //     # Do the same for the new leave after the split
            //     if leave.request_date_to >= split_date_to:
            //         new_leave_vals.append(leave.with_context(skip_copy_check=True).copy_data({
            //             'request_date_from': split_date_to,
            //             'state': leave.state
            //         })[0])
            // 
            //     # For those two new leaves, only create them if they actually have a non-zero duration.
            //     for leave_vals in new_leave_vals:
            //         new_leave = self.env['hr.leave'].new(leave_vals)
            //         new_leave._compute_date_from_to()
            //         if new_leave.date_from < new_leave.date_to:
            //             target_leave_vals.append(new_leave._convert_to_write(new_leave._cache))
            // 
            //     if target_leave_vals:
            //         vals = target_leave_vals.pop(0)
            //         leave.with_context(leave_skip_state_check=True).write({
            //             'request_date_from': vals['request_date_from'],
            //             'request_date_to': vals['request_date_to'],
            //         })
            //         if target_leave_vals:
            //             new_leaves_vals.extend(target_leave_vals)
            // 
            // if not new_leaves_vals:
            //     return self.env['hr.leave']
            // return self.env['hr.leave'].with_context(
            //     tracking_disable=True,
            //     mail_activity_automation_skip=True,
            //     leave_fast_create=True,
            //     leave_skip_state_check=True
            // ).create(new_leaves_vals)
            */
            return default;
        }

        public async Task<TEntity> StolenMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _stolen_move(self, vals):
            // for command in vals.get('line_ids', ()):
            //     if command[0] == Command.LINK:
            //         yield self.env['account.move.line'].browse(command[1]).move_id.id
            //     if command[0] == Command.SET:
            //         yield from self.env['account.move.line'].browse(command[2]).move_id.ids
            */
            return default;
        }

        public async Task<TEntity> SyncDynamicLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object existing_key_fname, object needed_vals_fname, object needed_dirty_fname, object line_type, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_dynamic_line(self, existing_key_fname, needed_vals_fname, needed_dirty_fname, line_type, container):
            // def existing():
            //     return {
            //         line: line[existing_key_fname]
            //         for line in container['records'].line_ids
            //         if line[existing_key_fname]
            //     }
            // 
            // def needed():
            //     return self._sync_dynamic_line_needed_values(container['records'].mapped(needed_vals_fname))
            // 
            // def dirty():
            //     *path, dirty_fname = needed_dirty_fname.split('.')
            //     eligible_recs = container['records'].mapped('.'.join(path))
            //     if eligible_recs._name == 'account.move.line':
            //         eligible_recs = eligible_recs.filtered(lambda l: l.display_type != 'cogs')
            //     dirty_recs = eligible_recs.filtered(dirty_fname)
            //     return dirty_recs, dirty_fname
            // 
            // def filter_trivial(mapping):
            //     return {k: v for k, v in mapping.items() if 'id' not in v}
            // 
            // inv_existing_before = existing()
            // needed_before = needed()
            // dirty_recs_before, dirty_fname = dirty()
            // dirty_recs_before[dirty_fname] = False
            // yield
            // dirty_recs_after, dirty_fname = dirty()
            // if not dirty_recs_after:  # TODO improve filter
            //     return
            // inv_existing_after = existing()
            // needed_after = needed()
            // 
            // # Filter out deleted lines from `needed_before` to not recompute lines if not necessary or wanted
            // line_ids = set(self.env['account.move.line'].browse(k['id'] for k in needed_before if 'id' in k).exists().ids)
            // needed_before = {k: v for k, v in needed_before.items() if 'id' not in k or k['id'] in line_ids}
            // 
            // # old key to new key for the same line
            // before2after = {
            //     before: inv_existing_after[bline]
            //     for bline, before in inv_existing_before.items()
            //     if bline in inv_existing_after
            // }
            // 
            // if needed_after == needed_before:
            //     return  # do not modify user input if nothing changed in the needs
            // if not needed_before and (filter_trivial(inv_existing_after) != filter_trivial(inv_existing_before)):
            //     return  # do not modify user input if already created manually
            // 
            // existing_after = defaultdict(list)
            // for k, v in inv_existing_after.items():
            //     existing_after[v].append(k)
            // to_delete = [
            //     line.id
            //     for line, key in inv_existing_before.items()
            //     if key not in needed_after
            //     and key in existing_after
            //     and before2after[key] not in needed_after
            // ]
            // to_delete_set = set(to_delete)
            // to_delete.extend(line.id
            //     for line, key in inv_existing_after.items()
            //     if key not in needed_after and line.id not in to_delete_set
            // )
            // to_create = {
            //     key: values
            //     for key, values in needed_after.items()
            //     if key not in existing_after
            // }
            // to_write = {
            //     line: values
            //     for key, values in needed_after.items()
            //     for line in existing_after[key]
            //     if any(
            //         self.env['account.move.line']._fields[fname].convert_to_write(line[fname], self)
            //         != values[fname]
            //         for fname in values
            //     )
            // }
            // 
            // while to_delete and to_create:
            //     key, values = to_create.popitem()
            //     line_id = to_delete.pop()
            //     self.env['account.move.line'].browse(line_id).write(
            //         {**key, **values, 'display_type': line_type}
            //     )
            // if to_delete:
            //     self.env['account.move.line'].browse(to_delete).with_context(dynamic_unlink=True).unlink()
            // if to_create:
            //     self.env['account.move.line'].with_context(clean_context(self.env.context)).create([
            //         {**key, **values, 'display_type': line_type}
            //         for key, values in to_create.items()
            //     ])
            // if to_write:
            //     for line, values in to_write.items():
            //         line.write(values)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncDynamicLineNeededValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_dynamic_line_needed_values(self, values_list):
            // res = {}
            // for computed_needed in values_list:
            //     if computed_needed is False:
            //         continue  # there was an invalidation, let's hope nothing needed to be changed...
            //     for key, values in computed_needed.items():
            //         if key not in res:
            //             res[key] = dict(values)
            //         else:
            //             ignore = True
            //             for fname in res[key]:
            //                 if self.env['account.move.line']._fields[fname].type == 'monetary':
            //                     res[key][fname] += values[fname]
            //                     if res[key][fname]:
            //                         ignore = False
            //             if ignore:
            //                 del res[key]
            // 
            // # Convert float values to their "ORM cache" one to prevent different rounding calculations
            // for key, values in res.items():
            //     move_id = key.get('move_id')
            //     if not move_id:
            //         continue
            //     record = self.env['account.move'].browse(move_id)
            //     for fname, current_value in values.items():
            //         field = self.env['account.move.line']._fields[fname]
            //         if isinstance(current_value, float):
            //             values[fname] = field.convert_to_cache(current_value, record)
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> SyncDynamicLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_dynamic_lines(self, container):
            // with self._disable_recursion(container, 'skip_invoice_sync') as disabled:
            //     if disabled:
            //         yield
            //         return
            // 
            //     stack_list, update_containers = self._get_sync_stack(container)
            //     update_containers()
            //     with ExitStack() as stack:
            //         stack_list.sort()
            //         for _seq, contextmgr in stack_list:
            //             stack.enter_context(contextmgr)
            // 
            //         line_container = {'records': self.line_ids}
            //         with self.line_ids._sync_invoice(line_container):
            //             yield
            //             line_container['records'] = self.line_ids
            //         update_containers()
            */
            return default;
        }

        public async Task<TEntity> SyncInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_invoice(self, container):
            // def existing():
            //     return {
            //         move: {
            //             'commercial_partner_id': move.commercial_partner_id,
            //         }
            //         for move in container['records'].filtered(lambda m: m.is_invoice(True))
            //     }
            // 
            // def changed(fname):
            //     return move not in before or before[move][fname] != after[move][fname]
            // 
            // before = existing()
            // yield
            // after = existing()
            // 
            // for move in after:
            //     if changed('commercial_partner_id'):
            //         move.line_ids.partner_id = after[move]['commercial_partner_id']
            */
            return default;
        }

        public async Task<TEntity> SyncNonDeductibleBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_non_deductible_base_lines(self, container):
            // def has_non_deductible_lines(move):
            //     return (
            //         move.state == 'draft'
            //         and move.is_purchase_document()
            //         and any(move.line_ids.filtered(lambda line: line.display_type == 'product' and line.deductible_amount < 100))
            //     )
            // 
            // # Collect data to avoid recomputing value unecessarily
            // product_lines_before = {
            //     move: Counter(
            //         (line.name, line.price_subtotal, line.tax_ids, line.deductible_amount, line.account_id)
            //         for line in move.line_ids
            //         if line.display_type == 'product'
            //     )
            //     for move in container['records']
            // }
            // 
            // yield
            // 
            // to_delete = []
            // to_create = []
            // for move in container['records']:
            //     product_lines_now = Counter(
            //         (line.name, line.price_subtotal, line.tax_ids, line.deductible_amount, line.account_id)
            //         for line in move.line_ids
            //         if line.display_type == 'product'
            //     )
            // 
            //     has_changed_product_lines = bool(
            //         product_lines_before.get(move, Counter()) - product_lines_now
            //         or product_lines_now - product_lines_before.get(move, Counter())
            //     )
            //     if not has_changed_product_lines:
            //         # No difference between before and now, then nothing to do
            //         continue
            // 
            //     non_deductible_base_lines = move.line_ids.filtered(lambda line: line.display_type in ('non_deductible_product', 'non_deductible_product_total'))
            //     to_delete += non_deductible_base_lines.ids
            // 
            //     if not has_non_deductible_lines(move):
            //         continue
            // 
            //     non_deductible_base_total = 0.0
            //     non_deductible_base_currency_total = 0.0
            // 
            //     sign = move.direction_sign
            //     rate = move.invoice_currency_rate
            // 
            //     for line in move.line_ids.filtered(lambda line: line.display_type == 'product'):
            //         if float_compare(line.deductible_amount, 100, precision_rounding=2) == 0:
            //             continue
            // 
            //         percentage = (1 - line.deductible_amount / 100)
            //         non_deductible_subtotal = line.currency_id.round(line.price_subtotal * percentage)
            //         non_deductible_base = line.currency_id.round(sign * non_deductible_subtotal)
            //         non_deductible_base_currency = line.company_currency_id.round(sign * non_deductible_subtotal / rate) if rate else 0.0
            //         non_deductible_base_total += non_deductible_base
            //         non_deductible_base_currency_total += non_deductible_base_currency
            // 
            //         to_create.append({
            //             'move_id': move.id,
            //             'account_id': line.account_id.id,
            //             'display_type': 'non_deductible_product',
            //             'name': line.name,
            //             'balance': -1 * non_deductible_base,
            //             'amount_currency': -1 * non_deductible_base_currency,
            //             'tax_ids': [Command.set(line.tax_ids.filtered(lambda tax: tax.amount_type != 'fixed').ids)],
            //             'sequence': line.sequence + 1,
            //         })
            // 
            //     to_create.append({
            //         'move_id': move.id,
            //         'account_id': (
            //             move.journal_id.non_deductible_account_id
            //             or move.journal_id.default_account_id
            //         ).id,
            //         'display_type': 'non_deductible_product_total',
            //         'name': _('private part'),
            //         'balance': non_deductible_base_total,
            //         'amount_currency': non_deductible_base_currency_total,
            //         'tax_ids': [Command.clear()],
            //         'sequence': max(move.line_ids.mapped('sequence')) + 1,
            //     })
            // 
            // while to_create and to_delete:
            //     line_data = to_create.pop()
            //     line_id = to_delete.pop()
            //     self.env['account.move.line'].browse(line_id).write(line_data)
            // if to_create:
            //     self.env['account.move.line'].create(to_create)
            // if to_delete:
            //     self.env['account.move.line'].browse(to_delete).with_context(dynamic_unlink=True).unlink()
            */
            return default;
        }

        public async Task<TEntity> SyncRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_rounding_lines(self, container):
            // yield
            // for invoice in container['records']:
            //     if invoice.state != 'posted':
            //         invoice._recompute_cash_rounding_lines()
            */
            return default;
        }

        public async Task<TEntity> SyncSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _sync_salary_distribution(self):
            // for employee in self:
            //     current_salary_distribution = employee.salary_distribution or {}
            //     current_ids = set(map(int, current_salary_distribution.keys()))
            //     account_ids = set(employee.bank_account_ids.ids)
            // 
            //     added_ids = account_ids - current_ids
            //     removed_ids = current_ids - account_ids
            //     unchanged_ids = account_ids & current_ids
            // 
            //     # Preserve existing data and order
            //     ordered = sorted([
            //         (int(i), data) for i, data in current_salary_distribution.items()
            //         if int(i) in unchanged_ids
            //     ], key=lambda x: (not x[1].get('amount_is_percentage'), x[1].get('sequence', float('inf'))))
            // 
            //     new_salary_distribution = {str(i): data for i, data in ordered}
            // 
            //     # Redistribute removed % to first item
            //     removed_percentage = sum(current_salary_distribution[str(i)]['amount']
            //         for i in removed_ids if str(i) in current_salary_distribution and current_salary_distribution[str(i)]['amount_is_percentage'])
            //     if removed_percentage and ordered:
            //         first_id = str(ordered[0][0])
            //         if new_salary_distribution[first_id]['amount_is_percentage']:
            //             new_salary_distribution[first_id]['amount'] += removed_percentage
            // 
            //     # Add new entries with remaining %
            //     total_allocated = sum(d['amount'] for d in new_salary_distribution.values() if d['amount_is_percentage'])
            //     remaining = max(0.0, 100.0 - total_allocated)
            //     seq = max((d.get('sequence', 0) for d in new_salary_distribution.values()), default=0)
            //     amount = employee.currency_id.round(remaining / len(added_ids)) if added_ids else 0.0
            //     for i, new_id in enumerate(added_ids):
            //         seq += 1
            //         if i == len(added_ids) - 1:
            //             amount = remaining
            //         new_salary_distribution[str(new_id)] = {
            //             'amount': amount,
            //             'amount_is_percentage': True,
            //             'sequence': seq,
            //         }
            //         remaining -= amount
            // 
            //     employee.salary_distribution = new_salary_distribution
            */
            return default;
        }

        public async Task<TEntity> SyncTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_tax_lines(self, container):
            // AccountTax = self.env['account.tax']
            // fake_base_line = AccountTax._prepare_base_line_for_taxes_computation(None)
            // 
            // def get_base_lines(move):
            //     return move.line_ids.filtered(lambda line: line.display_type in ('product', 'epd', 'rounding', 'cogs', 'non_deductible_product'))
            // 
            // def get_tax_lines(move):
            //     return move.line_ids.filtered('tax_repartition_line_id')
            // 
            // def get_value(record, field):
            //     return record._fields[field].convert_to_write(record[field], record)
            // 
            // def get_tax_line_tracked_fields(line):
            //     return ('amount_currency', 'balance', 'analytic_distribution')
            // 
            // def get_base_line_tracked_fields(line):
            //     grouping_key = AccountTax._prepare_base_line_grouping_key(fake_base_line)
            //     if line.move_id.is_invoice(include_receipts=True):
            //         extra_fields = ['price_unit', 'quantity', 'discount']
            //     else:
            //         extra_fields = ['amount_currency']
            //     return list(grouping_key.keys()) + extra_fields
            // 
            // def field_has_changed(values, record, field):
            //     return get_value(record, field) != values.get(record, {}).get(field)
            // 
            // def get_changed_lines(values, records, fields=None):
            //     return (
            //         record
            //         for record in records
            //         if record not in values
            //         or any(field_has_changed(values, record, field) for field in values[record] if not fields or field in fields)
            //     )
            // 
            // def any_field_has_changed(values, records, fields=None):
            //     return any(record for record in get_changed_lines(values, records, fields))
            // 
            // def is_write_needed(line, values):
            //     return any(
            //         self.env['account.move.line']._fields[fname].convert_to_write(line[fname], self) != values[fname]
            //         for fname in values
            //     )
            // 
            // moves_values_before = {
            //     move: {
            //         field: get_value(move, field)
            //         for field in ('currency_id', 'partner_id', 'move_type', 'invoice_currency_rate', 'invoice_date')
            //     }
            //     for move in container['records']
            //     if move.state == 'draft'
            // }
            // base_lines_values_before = {
            //     move: {
            //         line: {
            //             field: get_value(line, field)
            //             for field in get_base_line_tracked_fields(line)
            //         }
            //         for line in get_base_lines(move)
            //     }
            //     for move in container['records']
            // }
            // tax_lines_values_before = {
            //     move: {
            //         line: {
            //             field: get_value(line, field)
            //             for field in get_tax_line_tracked_fields(line)
            //         }
            //         for line in get_tax_lines(move)
            //     }
            //     for move in container['records']
            // }
            // yield
            // 
            // to_delete = []
            // to_create = []
            // for move in container['records']:
            //     if move.state != 'draft':
            //         continue
            // 
            //     tax_lines = get_tax_lines(move)
            //     base_lines = get_base_lines(move)
            //     move_tax_lines_values_before = tax_lines_values_before.get(move, {})
            //     move_base_lines_values_before = base_lines_values_before.get(move, {})
            //     if (
            //         move.is_invoice(include_receipts=True)
            //         and (
            //             field_has_changed(moves_values_before, move, 'currency_id')
            //             or field_has_changed(moves_values_before, move, 'move_type')
            //         )
            //     ):
            //         # Changing the type of an invoice using 'switch to refund' feature or just changing the currency.
            //         round_from_tax_lines = False
            //     elif any(line not in base_lines for line, values in move_base_lines_values_before.items() if values['tax_ids']):
            //         # Removed a base line affecting the taxes.
            //         round_from_tax_lines = any_field_has_changed(move_tax_lines_values_before, tax_lines)
            //     elif field_has_changed(moves_values_before, move, 'invoice_currency_rate') and not field_has_changed(moves_values_before, move, 'invoice_date'):
            //         # Changing the rate should preserve the tax amounts in foreign currency but reapply the currency rate.
            //         round_from_tax_lines = 'reapply_currency_rate'
            //     elif changed_lines := list(get_changed_lines(move_base_lines_values_before, base_lines)):
            //         # A base line has been modified.
            //         round_from_tax_lines = (
            //             # The changed lines don't affect the taxes.
            //             all(
            //                 not line.tax_ids and not move_base_lines_values_before.get(line, {}).get('tax_ids')
            //                 for line in changed_lines
            //             )
            //             # Keep the tax lines amounts if an amount has been manually computed.
            //             or (
            //                 list(move_tax_lines_values_before) != list(tax_lines)
            //                 or any(
            //                     self.env.is_protected(line._fields[fname], line)
            //                     for line in tax_lines
            //                     for fname in move_tax_lines_values_before[line]
            //                 )
            //             )
            //         )
            // 
            //         # If the move has been created with all lines including the tax ones and the balance/amount_currency are provided on
            //         # base lines, we don't need to recompute anything.
            //         if (
            //             round_from_tax_lines
            //             and any(line[field] for line in changed_lines for field in ('amount_currency', 'balance'))
            //         ):
            //             continue
            //     else:
            //         continue
            // 
            //     base_lines_values, tax_lines_values = move._get_rounded_base_and_tax_lines(round_from_tax_lines=round_from_tax_lines)
            //     AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines_values, move.company_id, include_caba_tags=move.always_tax_exigible)
            //     tax_results = AccountTax._prepare_tax_lines(base_lines_values, move.company_id, tax_lines=tax_lines_values)
            // 
            //     non_deductible_tax_line = move.line_ids.filtered(lambda line: line.display_type == 'non_deductible_tax')
            //     non_deductible_lines_values = [
            //         line_values
            //         for line_values in base_lines_values
            //         if line_values['special_type'] == 'non_deductible'
            //         and line_values['tax_ids']
            //     ]
            // 
            //     if not non_deductible_lines_values and non_deductible_tax_line:
            //         to_delete.append(non_deductible_tax_line.id)
            // 
            //     elif non_deductible_lines_values:
            //         non_deductible_tax_values = {
            //             'tax_amount': 0.0,
            //             'tax_amount_currency': 0.0,
            //         }
            //         for line_values in non_deductible_lines_values:
            //             non_deductible_tax_values['tax_amount'] += -line_values['sign'] * (line_values['tax_details']['total_included'] - line_values['tax_details']['total_excluded'])
            //             non_deductible_tax_values['tax_amount_currency'] += -line_values['sign'] * (line_values['tax_details']['total_included_currency'] - line_values['tax_details']['total_excluded_currency'])
            // 
            //         # Update the non-deductible tax lines values
            //         non_deductable_tax_line_values = {
            //             'move_id': move.id,
            //             'account_id': (
            //                 non_deductible_tax_line.account_id
            //                 or move.journal_id.non_deductible_account_id
            //                 or move.journal_id.default_account_id
            //             ).id,
            //             'display_type': 'non_deductible_tax',
            //             'name': _('private part (taxes)'),
            //             'balance': non_deductible_tax_values['tax_amount'],
            //             'amount_currency': non_deductible_tax_values['tax_amount_currency'],
            //             'sequence': max(move.line_ids.mapped('sequence')) + 1,
            //         }
            //         if non_deductible_tax_line:
            //             tax_results['tax_lines_to_update'].append((
            //                 {'record': non_deductible_tax_line},
            //                 'unused_grouping_key',
            //                 {
            //                     'amount_currency': non_deductable_tax_line_values['amount_currency'],
            //                     'balance': non_deductable_tax_line_values['balance'],
            //                 }
            //             ))
            //         else:
            //             to_create.append(non_deductable_tax_line_values)
            // 
            //     for base_line, to_update in tax_results['base_lines_to_update']:
            //         line = base_line['record']
            //         if is_write_needed(line, to_update):
            //             line.write(to_update)
            // 
            //     for tax_line_vals in tax_results['tax_lines_to_delete']:
            //         to_delete.append(tax_line_vals['record'].id)
            // 
            //     for tax_line_vals in tax_results['tax_lines_to_add']:
            //         to_create.append({
            //             **tax_line_vals,
            //             'display_type': 'tax',
            //             'move_id': move.id,
            //         })
            // 
            //     for tax_line_vals, _grouping_key, to_update in tax_results['tax_lines_to_update']:
            //         line = tax_line_vals['record']
            //         if is_write_needed(line, to_update):
            //             line.write(to_update)
            // 
            // if to_delete:
            //     self.env['account.move.line'].browse(to_delete).with_context(dynamic_unlink=True).unlink()
            // if to_create:
            //     self.env['account.move.line'].create(to_create)
            */
            return default;
        }

        public async Task<TEntity> SyncUnbalancedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_unbalanced_lines(self, container):
            // def has_tax(move):
            //     return bool(move.line_ids.tax_ids)
            // 
            // move_had_tax = {move: has_tax(move) for move in container['records']}
            // yield
            // # Skip posted moves.
            // for move in (x for x in container['records'] if x.state != 'posted'):
            //     if not has_tax(move) and not move_had_tax.get(move):
            //         continue  # only manage automatically unbalanced when taxes are involved
            //     if move_had_tax.get(move) and not has_tax(move):
            //         # taxes have been removed, the tax sync is deactivated so we need to clear everything here
            //         move.line_ids.filtered('tax_line_id').unlink()
            //         move.line_ids.tax_tag_ids = [Command.set([])]
            // 
            //     # Set the balancing line's balance and amount_currency to zero,
            //     # so that it does not interfere with _get_unbalanced_moves() below.
            //     balance_name = _('Automatic Balancing Line')
            //     existing_balancing_line = move.line_ids.filtered(lambda line: line.name == balance_name)
            //     if existing_balancing_line:
            //         existing_balancing_line.balance = existing_balancing_line.amount_currency = 0.0
            // 
            //     # Create an automatic balancing line to make sure the entry can be saved/posted.
            //     # If such a line already exists, we simply update its amounts.
            //     unbalanced_moves = self._get_unbalanced_moves({'records': move})
            //     if isinstance(unbalanced_moves, list) and len(unbalanced_moves) == 1:
            //         dummy, debit, credit = unbalanced_moves[0]
            // 
            //         vals = {'balance': credit - debit}
            //         if existing_balancing_line:
            //             existing_balancing_line.write(vals)
            //         else:
            //             vals.update({
            //                 'name': balance_name,
            //                 'move_id': move.id,
            //                 'account_id': move._get_automatic_balancing_account(),
            //                 'currency_id': move.currency_id.id,
            //                 # A balancing line should never have default taxes applied to it, it doesn't work well and wouldn't make much sense.
            //                 'tax_ids': False,
            //             })
            //             self.env['account.move.line'].create(vals)
            */
            return default;
        }

        public async Task<TEntity> SyncUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_has_image) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _sync_user(self, user, employee_has_image=False):
            // vals = dict(
            //     work_contact_id=user.partner_id.id if user else self.work_contact_id.id,
            //     user_id=user.id,
            // )
            // if not employee_has_image:
            //     vals['image_1920'] = user.image_1920
            // if user.tz:
            //     vals['tz'] = user.tz
            // return vals
            */
            return default;
        }

        public async Task<TEntity> SynchronizeBusinessModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changed_fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _synchronize_business_models(self, changed_fields):
            // ''' Ensure the consistency between:
            // account.payment & account.move
            // account.bank.statement.line & account.move
            // 
            // The idea is to call the method performing the synchronization of the business
            // models regarding their related journal entries. To avoid cycling, the
            // 'skip_account_move_synchronization' key is used through the context.
            // 
            // :param changed_fields: A set containing all modified fields on account.move.
            // '''
            // if self.env.context.get('skip_account_move_synchronization'):
            //     return
            // 
            // self_sudo = self.sudo()
            // self_sudo.statement_line_id._synchronize_from_moves(changed_fields)
            */
            return default;
        }

        public async Task<TEntity> SynchronizeToMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changed_fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _synchronize_to_moves(self, changed_fields):
            // '''
            //     Update the account.move regarding the modified account.payment.
            //     :param changed_fields: A list containing all modified fields on account.payment.
            // '''
            // if not any(field_name in changed_fields for field_name in self._get_trigger_fields_to_synchronize()):
            //     return
            // 
            // for pay in self:
            //     if pay.move_id.state == 'posted':
            //         continue
            //     liquidity_lines, counterpart_lines, writeoff_lines = pay._seek_for_lines()
            //     # Make sure to preserve the write-off amount.
            //     # This allows to create a new payment with custom 'line_ids'.
            //     write_off_line_vals = []
            //     if liquidity_lines and counterpart_lines and writeoff_lines:
            //         write_off_line_vals.append({
            //             'name': writeoff_lines[0].name,
            //             'account_id': writeoff_lines[0].account_id.id,
            //             'partner_id': writeoff_lines[0].partner_id.id,
            //             'currency_id': writeoff_lines[0].currency_id.id,
            //             'amount_currency': sum(writeoff_lines.mapped('amount_currency')),
            //             'balance': sum(writeoff_lines.mapped('balance')),
            //         })
            //     line_vals_list = pay._prepare_move_line_default_vals(write_off_line_vals=write_off_line_vals)
            //     line_ids_commands = [
            //         Command.update(liquidity_lines.id, line_vals_list[0]) if liquidity_lines else Command.create(line_vals_list[0]),
            //         Command.update(counterpart_lines.id, line_vals_list[1]) if counterpart_lines else Command.create(line_vals_list[1])
            //     ]
            //     for line in writeoff_lines:
            //         line_ids_commands.append((2, line.id))
            //     for extra_line_vals in line_vals_list[2:]:
            //         line_ids_commands.append((0, 0, extra_line_vals))
            //     # Update the existing journal items.
            //     # If dealing with multiple write-off lines, they are dropped and a new one is generated.
            //     to_write = {
            //         'date': pay.date,
            //         'partner_id': pay.partner_id.id,
            //         'currency_id': pay.currency_id.id,
            //         'partner_bank_id': pay.partner_bank_id.id,
            //         'line_ids': line_ids_commands,
            //     }
            //     if 'journal_id' in changed_fields:
            //         to_write.update({
            //             'name': '/',  # Set the name to '/' to allow it to be changed
            //             'journal_id': pay.journal_id.id
            //         })
            //     pay.move_id.with_context(skip_invoice_sync=True).write(to_write)
            */
            return default;
        }

        public async Task<TEntity> ThreadToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_thread_main_attachment.py) ---
            // def _thread_to_store(self, store: Store, fields, *, request_list=None):
            // super()._thread_to_store(store, fields, request_list=request_list)
            // if request_list and "attachments" in request_list:
            //     store.add(
            //         self,
            //         Store.One("message_main_attachment_id", []),
            //         as_thread=True,
            //     )
            */
            return default;
        }

        public async Task<TEntity> ToUtcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object hour, object resource) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _to_utc(self, date, hour, resource):
            // hour = float_to_time(float(hour))
            // holiday_tz = pytz.timezone(resource.tz or self.env.user.tz or 'UTC')
            // return holiday_tz.localize(datetime.combine(date, hour)).astimezone(pytz.UTC).replace(tzinfo=None)
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _track_subtype(self, init_values):
            // # EXTENDS mail mail.thread
            // # add custom subtype depending of the state.
            // self.ensure_one()
            // 
            // if not self.is_invoice(include_receipts=True):
            //     if self.origin_payment_id and 'state' in init_values:
            //         self.origin_payment_id._message_track(['state'], {self.origin_payment_id.id: init_values})
            //     return super()._track_subtype(init_values)
            // 
            // if 'payment_state' in init_values and self.payment_state == 'paid':
            //     return self.env.ref('account.mt_invoice_paid')
            // elif 'state' in init_values and self.state == 'posted' and self.is_sale_document(include_receipts=True):
            //     return self.env.ref('account.mt_invoice_validated')
            // return super()._track_subtype(init_values)
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
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _track_subtype(self, init_values):
            // if 'state' in init_values and self.state == 'validate':
            //     leave_notif_subtype = self.holiday_status_id.leave_notif_subtype_id
            //     return leave_notif_subtype or self.env.ref('hr_holidays.mt_leave')
            // return super()._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_subtype(self, init_values):
            // record = self[0]
            // if 'stage_id' in init_values and record.stage_id:
            //     return self.env.ref('hr_recruitment.mt_applicant_stage_changed')
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_template(self, changes):
            // res = super()._track_template(changes)
            // applicant = self[0]
            // # When applcant is unarchived, they are put back to the default stage automatically. In this case,
            // # don't post automated message related to the stage change.
            // if 'stage_id' in changes and applicant.exists()\
            //     and applicant.stage_id.template_id\
            //     and not applicant.env.context.get('just_moved')\
            //     and not applicant.env.context.get('just_unarchived'):
            //     res['stage_id'] = (applicant.stage_id.template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'hr_recruitment.mail_notification_light_without_background'
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkAccountAuditTrailExceptOncePostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _unlink_account_audit_trail_except_once_post(self):
            // if not self.env.context.get('force_delete') and any(
            //         move.posted_before and move.company_id.restrictive_audit_trail
            //         for move in self
            // ):
            //     raise UserError(_(
            //         "To keep the restrictive audit trail, you can not delete journal entries once they have been posted.\n"
            //         "Instead, you can cancel the journal entry."
            //     ))
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def unlink(self):
            // self._set_next_made_sequence_gap(True)
            // self = self.with_context(skip_invoice_sync=True, dynamic_unlink=True)  # no need to sync to delete everything
            // logger_message = self._get_unlink_logger_message()
            // self.line_ids.remove_move_reconcile()
            // self.line_ids.unlink()
            // res = super().unlink()
            // if logger_message:
            //     _logger.info(logger_message)
            // return res
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def unlink(self):
            // self.move_id.filtered(lambda m: m.state != 'draft').button_draft()
            // self.move_id.unlink()
            // 
            // linked_invoices = self.reconciled_invoice_ids
            // res = super().unlink()
            // self.env.add_to_compute(linked_invoices._fields['payment_state'], linked_invoices)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def unlink(self):
            // resources = self.mapped('resource_id')
            // super().unlink()
            // return resources.unlink()
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def unlink(self):
            // self.sudo()._post_leave_cancel()
            // self.env['hr.leave.allocation'].invalidate_model(['leaves_taken', 'max_leaves'])  # missing dependency on compute
            // return super(HrLeave, self.with_context(leave_skip_date_check=True)).unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptApprovedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> UnlinkForbidPartsOfChainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _unlink_forbid_parts_of_chain(self):
            // """ For a user with Billing/Bookkeeper rights, when the fidu mode is deactivated,
            // moves with a sequence number can only be deleted if they are the last element of a chain of sequence.
            // If they are not, deleting them would create a gap. If the user really wants to do this, he still can
            // explicitly empty the 'name' field of the move; but we discourage that practice.
            // If a user is a Billing Administrator/Accountant or if fidu mode is activated, we show a warning,
            // but they can delete the moves even if it creates a sequence gap.
            // """
            // if not (
            //     self.env.user.has_group('account.group_account_manager')
            //     or any(self.company_id.mapped('quick_edit_mode'))
            //     or self.env.context.get('force_delete')
            //     or self.check_move_sequence_chain()
            // ):
            //     raise UserError(_(
            //         "You cannot delete this entry, as it has already consumed a sequence number and is not the last one in the chain. "
            //         "You should probably revert it instead."
            //     ))
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfCorrectStatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _unlink_if_correct_states(self):
            // error_message = self.env._('Oops! %(state)s Time-Off requests can only be deleted by Administrators.')
            // state_description_values = {elem[0]: elem[1] for elem in self._fields['state']._description_selection(self.env)}
            // now = fields.Datetime.now().date()
            // 
            // if not self.env.user.has_group('hr_holidays.group_hr_holidays_user'):
            //     for hol in self:
            //         if hol.state not in ['confirm', 'validate1', 'cancel']:
            //             raise UserError(error_message % {'state': state_description_values.get(self[:1].state)})
            //         if hol.date_from.date() < now:
            //             raise UserError(_("You can't delete a time off request that is in the past."))
            // elif not self.env.user.has_group('hr_holidays.group_hr_holidays_manager'):
            //     for holiday in self.filtered(lambda holiday: holiday.state not in ['cancel', 'confirm']):
            //         error_message = self.env._('Oops! %(state)s Time-Off requests can only be deleted by Administrators.')
            //         raise UserError(error_message % {'state': state_description_values.get(holiday.state)})
            */
            return default;
        }

        public async Task<TEntity> UnlinkOrReverseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _unlink_or_reverse(self):
            // if not self:
            //     return
            // to_unlink = self.env['account.move']
            // to_cancel = self.env['account.move']
            // to_reverse = self.env['account.move']
            // for move in self:
            //     if not move._can_be_unlinked():
            //         to_reverse += move
            //     elif move._is_protected_by_audit_trail():
            //         to_cancel += move
            //     else:
            //         to_unlink += move
            // to_unlink.filtered(lambda m: m.state in ('posted', 'cancel')).button_draft()
            // to_unlink.filtered(lambda m: m.state == 'draft').unlink()
            // to_cancel.filtered(lambda m: m.state != 'cancel').button_cancel()
            // return to_reverse._reverse_moves(cancel=True)
            */
            return default;
        }

        public async Task<TEntity> UnmarkAsSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def unmark_as_sent(self):
            // self.write({'is_sent': False})
            */
            return default;
        }

        public async Task<TEntity> UpdateActivitiesAndMailsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
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

        public async Task<TEntity> UpdateOrderLineInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _update_order_line_info(
            //     self, product_id, quantity, *, section_id=False, child_field='line_ids', **kwargs
            // ):
            //     """ Update account_move_line information for a given product or create a
            //     new one if none exists yet.
            //     :param int product_id: The product, as a `product.product` id.
            //     :param int quantity: The quantity selected in the catalog
            //     :param int section_id: The id of section selected in the catalog.
            //     :return: The unit price of the product, based on the pricelist of the
            //              sale order and the quantity selected.
            //     :rtype: float
            //     """
            //     move_line = self.line_ids.filtered(
            //         lambda line: line.product_id.id == product_id
            //         and line.get_parent_section_line().id == section_id,
            //     )
            //     if move_line:
            //         if quantity != 0:
            //             move_line.quantity = quantity
            //         elif self.state in {'draft', 'sent'}:
            //             price_unit = self._get_product_price_and_data(move_line.product_id)['price']
            //             # The catalog is designed to allow the user to select products quickly.
            //             # Therefore, sometimes they may select the wrong product or decide to remove
            //             # some of them from the quotation. The unlink is there for that reason.
            //             move_line.unlink()
            //             return price_unit
            //         else:
            //             move_line.quantity = 0
            //     elif quantity > 0:
            //         move_line = self.env['account.move.line'].create({
            //             'move_id': self.id,
            //             'quantity': quantity,
            //             'product_id': product_id,
            //             'sequence': self._get_new_line_sequence(child_field, section_id),
            //         })
            //     return move_line.price_unit
            */
            return default;
        }

        public async Task<TEntity> ValidPaymentStatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def _valid_payment_states(self):
            // """ This method is used to know in which edition we are: Community or Enterprise
            //     and fetch the payment states accordingly.
            // """
            // return ['in_process', 'paid'] if self.env['account.move']._get_invoice_in_payment_state() == 'paid' else ['in_process']
            */
            return default;
        }

        public async Task<TEntity> ValidateLeaveRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _validate_leave_request(self):
            // """ Validate time off requests
            // by creating a calendar event and a resource time off. """
            // holidays = self.filtered("employee_id")
            // holidays._create_resource_leave()
            // meeting_holidays = holidays.filtered(lambda l: l.holiday_status_id.create_calendar_meeting)
            // meetings = self.env['calendar.event']
            // if meeting_holidays:
            //     Meeting = self.env['calendar.event']
            //     Meeting.check_access('create')
            //     meeting_values_for_user_id = meeting_holidays._prepare_holidays_meeting_values()
            //     Meeting = self.env['calendar.event']
            //     for user_id, meeting_values in meeting_values_for_user_id.items():
            //         meetings += Meeting.with_user(user_id or self.env.uid).sudo().with_context(clean_context({**self.env.context, **dict(
            //                         allowed_company_ids=[],
            //                         no_mail_to_attendees=True,
            //                         calendar_no_videocall=True,
            //                         active_model=self._name
            //                     )})).create(meeting_values)
            // Holiday = self.env['hr.leave']
            // for meeting in meetings:
            //     Holiday.browse(meeting.res_id).meeting_id = meeting
            // 
            // for holiday in holidays:
            //     user_tz = pytz.timezone(holiday.tz)
            //     utc_tz = pytz.utc.localize(holiday.date_from).astimezone(user_tz)
            //     notify_partner_ids = holiday.employee_id.user_id.partner_id.ids
            //     holiday.message_post(
            //         body=_(
            //             'Your %(leave_type)s planned on %(date)s has been accepted',
            //             leave_type=holiday.holiday_status_id.display_name,
            //             date=utc_tz.replace(tzinfo=None)
            //         ),
            //         partner_ids=notify_partner_ids)
            */
            return default;
        }

        public async Task<TEntity> ValidateTaxesCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _validate_taxes_country(self):
            // """ By playing with the fiscal position in the form view, it is possible to keep taxes on the invoices from
            // a different country than the one allowed by the fiscal country or the fiscal position.
            // This contrains ensure such account.move cannot be kept, as they could generate inconsistencies in the reports.
            // """
            // self._compute_tax_country_id() # We need to ensure this field has been computed, as we use it in our check
            // for record in self:
            //     amls = record.line_ids
            //     impacted_countries = amls.tax_ids.country_id | amls.tax_line_id.country_id
            //     if impacted_countries and impacted_countries != record.tax_country_id:
            //         if record.fiscal_position_id and impacted_countries != record.fiscal_position_id.country_id:
            //             raise ValidationError(_("This entry contains taxes that are not compatible with your fiscal position. Check the country set in fiscal position and in your tax configuration."))
            //         raise ValidationError(_("This entry contains one or more taxes that are incompatible with your fiscal country. Check company fiscal country in the settings and tax country in taxes configuration."))
            */
            return default;
        }

        public async Task<TEntity> VerifyBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _verify_barcode(self):
            // for employee in self:
            //     if employee.barcode:
            //         if not (re.match(r'^[A-Za-z0-9]+$', employee.barcode) and len(employee.barcode) <= 18):
            //             raise ValidationError(_("The Badge ID must be alphanumeric without any accents and no longer than 18 characters."))
            */
            return default;
        }

        public async Task<TEntity> VerifyPinInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _verify_pin(self):
            // for employee in self:
            //     if employee.pin and not employee.pin.isdigit():
            //         raise ValidationError(_("The PIN must be a sequence of digits."))
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def write(self, vals):
            // if not vals:
            //     return True
            // self._sanitize_vals(vals)
            // 
            // for move in self:
            //     if vals.get('checked') and not move._is_user_able_to_review():
            //         raise AccessError(_("You don't have the access rights to perform this action."))
            //     if vals.get('state') == 'draft' and move.checked and not move._is_user_able_to_review():
            //         raise ValidationError(_("Validated entries can only be changed by your accountant."))
            // 
            //     violated_fields = set(vals).intersection(move._get_integrity_hash_fields() + ['inalterable_hash'])
            //     if move.inalterable_hash and violated_fields:
            //         raise UserError(_(
            //             "This document is protected by a hash. "
            //             "Therefore, you cannot edit the following fields: %s.",
            //             ', '.join(f['string'] for f in self.fields_get(violated_fields).values())
            //         ))
            //     if (
            //             move.posted_before
            //             and 'journal_id' in vals and move.journal_id.id != vals['journal_id']
            //             and not (move.name == '/' or not move.name or ('name' in vals and (vals['name'] == '/' or not vals['name'])))
            //     ):
            //         raise UserError(_('You cannot edit the journal of an account move if it has been posted once, unless the name is removed or set to "/". This might create a gap in the sequence.'))
            //     if (
            //             move.name and move.name != '/'
            //             and move.sequence_number not in (0, 1)
            //             and 'journal_id' in vals and move.journal_id.id != vals['journal_id']
            //             and not move.quick_edit_mode
            //             and not ('name' in vals and (vals['name'] == '/' or not vals['name']))
            //     ):
            //         raise UserError(_('You cannot edit the journal of an account move with a sequence number assigned, unless the name is removed or set to "/". This might create a gap in the sequence.'))
            // 
            //     # You can't change the date or name of a move being inside a locked period.
            //     if move.state == "posted" and (
            //             ('name' in vals and move.name != vals['name'])
            //             or ('date' in vals and move.date != vals['date'])
            //     ):
            //         move._check_fiscal_lock_dates()
            //         move.line_ids._check_tax_lock_date()
            // 
            //     # You can't post subtract a move to a locked period.
            //     if 'state' in vals and move.state == 'posted' and vals['state'] != 'posted':
            //         move._check_fiscal_lock_dates()
            //         move.line_ids._check_tax_lock_date()
            // 
            //     # Disallow modifying readonly fields on a posted move
            //     move_state = vals.get('state', move.state)
            //     unmodifiable_fields = (
            //         'invoice_line_ids', 'line_ids', 'invoice_date', 'date', 'partner_id',
            //         'invoice_payment_term_id', 'currency_id', 'fiscal_position_id', 'invoice_cash_rounding_id')
            //     readonly_fields = [val for val in vals if val in unmodifiable_fields]
            //     if not self.env.context.get('skip_readonly_check') and move_state == "posted" and readonly_fields:
            //         raise UserError(_("You cannot modify the following readonly fields on a posted move: %s", ', '.join(readonly_fields)))
            // 
            //     if move.journal_id.sequence_override_regex and vals.get('name') and vals['name'] != '/' and not re.match(move.journal_id.sequence_override_regex, vals['name']):
            //         if not self.env.user.has_group('account.group_account_manager'):
            //             raise UserError(_('The Journal Entry sequence is not conform to the current format. Only the Accountant can change it.'))
            //         move.journal_id.sequence_override_regex = False
            // 
            // if {'sequence_prefix', 'sequence_number', 'journal_id', 'name'} & vals.keys():
            //     self._set_next_made_sequence_gap(True)
            // 
            // stolen_moves = self.browse(set(move for move in self._stolen_move(vals)))
            // container = {'records': self | stolen_moves}
            // with self.env.protecting(self._get_protected_vals(vals, self)), self._check_balanced(container):
            //     with self._sync_dynamic_lines(container):
            //         if 'is_manually_modified' not in vals and not self.env.context.get('skip_is_manually_modified'):
            //             vals['is_manually_modified'] = True
            // 
            //         res = super(AccountMove, self.with_context(
            //             skip_account_move_synchronization=True,
            //         )).write(vals)
            // 
            //         # Reset the name of draft moves when changing the journal.
            //         # Protected against holes in the pre-validation checks.
            //         if 'journal_id' in vals and 'name' not in vals:
            //             draft_move = self.filtered(lambda m: not m.posted_before)
            //             draft_move.name = False
            //             draft_move._compute_name()
            // 
            //         # You can't change the date of a not-locked move to a locked period.
            //         # You can't post a new journal entry inside a locked period.
            //         if 'date' in vals or 'state' in vals:
            //             posted_move = self.filtered(lambda m: m.state == 'posted')
            //             posted_move._check_fiscal_lock_dates()
            //             posted_move.line_ids._check_tax_lock_date()
            // 
            //         if vals.get('state') == 'posted':
            //             self.flush_recordset()  # Ensure that the name is correctly computed
            //             self._hash_moves()
            // 
            //     self._synchronize_business_models(set(vals.keys()))
            // 
            //     # Apply the rounding on the Quick Edit mode only when adding a new line
            //     for move in self:
            //         if 'tax_totals' in vals:
            //             super(AccountMove, move).write({'tax_totals': vals['tax_totals']})
            // 
            // if any(field in vals for field in ['journal_id', 'currency_id']):
            //     self.line_ids._check_constrains_account_id_journal_id()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_payment.py) ---
            // def write(self, vals):
            // if vals.get('state') in ('in_process', 'paid') and not vals.get('move_id'):
            //     self.filtered(lambda p: not p.move_id)._generate_journal_entry()
            //     self.move_id.filtered(lambda m: m.state == 'draft').action_post()
            // 
            // res = super().write(vals)
            // if self.move_id:
            //     self._synchronize_to_moves(set(vals.keys()))
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if 'work_contact_id' in vals:
            //     self.message_unsubscribe(self.work_contact_id.ids)
            // if 'user_id' in vals:
            //     # Update the profile pictures with user, except if provided
            //     user = self.env['res.users'].browse(vals['user_id'])
            //     vals.update(self._sync_user(user, (bool(all(emp.image_1920 for emp in self)))))
            //     self._remove_work_contact_id(user, vals.get('company_id'))
            // if 'work_permit_expiration_date' in vals:
            //     vals['work_permit_scheduled_activity'] = False
            // if vals.get('tz'):
            //     users_to_update = self.env['res.users']
            //     for employee in self:
            //         if employee.user_id and employee.company_id == employee.user_id.company_id and vals['tz'] != employee.user_id.tz:
            //             users_to_update |= employee.user_id
            //     if users_to_update:
            //         users_to_update.write({'tz': vals['tz']})
            // if vals.get('department_id') or vals.get('user_id'):
            //     department_id = vals['department_id'] if vals.get('department_id') else self[:1].department_id.id
            //     # When added to a department or changing user, subscribe to the channels auto-subscribed by department
            //     self.env['discuss.channel'].sudo().search([
            //         ('subscription_department_ids', 'in', department_id)
            //     ])._subscribe_users_automatically()
            // if vals.get('departure_description'):
            //     for employee in self:
            //         employee.message_post(body=_(
            //             'Additional Information: \n %(description)s',
            //             description=vals.get('departure_description')))
            // # Only one write call for all the fields from hr.version
            // new_vals = vals.copy()
            // version_vals = {val: new_vals.pop(val) for val in vals if val in self._fields and self._fields[val].inherited}
            // res = super().write(new_vals)
            // if 'work_contact_id' in vals:
            //     account_ids = self.bank_account_ids.ids
            //     if account_ids:
            //         bank_accounts = self.env['res.partner.bank'].sudo().browse(account_ids)
            //         for bank_account in bank_accounts:
            //             if vals['work_contact_id'] != bank_account.partner_id.id:
            //                 if bank_account.allow_out_payment:
            //                     bank_account.allow_out_payment = False
            //                 if vals['work_contact_id']:
            //                     bank_account.partner_id = vals['work_contact_id']
            // if version_vals:
            //     version_vals['last_modified_date'] = fields.Datetime.now()
            //     version_vals['last_modified_uid'] = self.env.uid
            //     self.version_id.write(version_vals)
            // 
            //     for employee in self:
            //         employee._track_set_log_message(Markup("<b>Modified on the Version '%s'</b>") % employee.version_id.display_name)
            // if res and 'resource_calendar_id' in vals:
            //     resources_per_calendar_id = defaultdict(lambda: self.env['resource.resource'])
            //     for employee in self:
            //         if employee.version_id == employee.current_version_id:
            //             resources_per_calendar_id[employee.resource_calendar_id.id] += employee.resource_id
            //     for calendar_id, resources in resources_per_calendar_id.items():
            //         resources.write({'calendar_id': calendar_id})
            // return res
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
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def write(self, vals):
            // values = vals
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user') or self.env.is_superuser()
            // if not is_officer and values.keys() - {'attachment_ids', 'supported_attachment_ids', 'message_main_attachment_id'}:
            //     if any(hol.date_from.date() < fields.Date.today() and hol.employee_id.leave_manager_id != self.env.user
            //            and hol.state not in ('confirm', 'draft') for hol in self):
            //         raise UserError(_('You must have manager rights to modify/validate a time off that already begun'))
            //     if any(leave.state == 'cancel' for leave in self):
            //         raise UserError(_('Only a manager can modify a canceled leave.'))
            // 
            // # Unlink existing resource.calendar.leaves for validated time off
            // if 'state' in values and values['state'] != 'validate':
            //     validated_leaves = self.filtered(lambda l: l.state == 'validate')
            //     validated_leaves._remove_resource_leave()
            // 
            // employee_id = values.get('employee_id', False)
            // if not self.env.context.get('leave_fast_create'):
            //     if values.get('state'):
            //         self._check_approval_update(values['state'])
            //         if any(holiday.validation_type == 'both' for holiday in self):
            //             if values.get('employee_id'):
            //                 employees = self.env['hr.employee'].browse(values.get('employee_id'))
            //             else:
            //                 employees = self.mapped('employee_id')
            //             self._check_double_validation_rules(employees, values['state'])
            //     if 'date_from' in values:
            //         values['request_date_from'] = values['date_from']
            //     if 'date_to' in values:
            //         values['request_date_to'] = values['date_to']
            // result = super().write(values)
            // if any(field in values for field in ['request_date_from', 'date_from', 'request_date_from', 'date_to', 'holiday_status_id', 'employee_id', 'state']):
            //     self._check_validity()
            //     self.env['hr.leave.allocation'].invalidate_model(['leaves_taken', 'max_leaves'])  # missing dependency on compute
            // if not self.env.context.get('leave_fast_create'):
            //     for holiday in self:
            //         if employee_id:
            //             holiday.add_follower(employee_id)
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def write(self, vals):
            // # user_id change: update date_open
            // if vals.get('user_id'):
            //     vals['date_open'] = fields.Datetime.now()
            // old_interviewers = self.interviewer_ids
            // # stage_id: track last stage before update
            // if 'stage_id' in vals:
            //     vals['date_last_stage_update'] = fields.Datetime.now()
            //     if 'kanban_state' not in vals:
            //         vals['kanban_state'] = 'normal'
            //     for applicant in self:
            //         vals['last_stage_id'] = applicant.stage_id.id
            //         new_stage = self.env['hr.recruitment.stage'].browse(vals['stage_id'])
            //         if new_stage.hired_stage and not applicant.stage_id.hired_stage:
            //             if applicant.job_id.no_of_recruitment > 0:
            //                 applicant.job_id.no_of_recruitment -= 1
            //         elif not new_stage.hired_stage and applicant.stage_id.hired_stage:
            //             applicant.job_id.no_of_recruitment += 1
            // # kanban_state: also set date_last_stage_update
            // if 'kanban_state' in vals:
            //     vals['date_last_stage_update'] = fields.Datetime.now()
            // res = super().write(vals)
            // 
            // for applicant in self:
            //     if applicant.pool_applicant_id and applicant != applicant.pool_applicant_id and (not applicant.is_pool_applicant):
            //         if 'email_from' in vals:
            //             applicant.pool_applicant_id.email_from = vals['email_from']
            //         if 'partner_phone' in vals:
            //             applicant.pool_applicant_id.partner_phone = vals['partner_phone']
            //         if 'linkedin_profile' in vals:
            //             applicant.pool_applicant_id.linkedin_profile = vals['linkedin_profile']
            //         if 'type_id' in vals:
            //             applicant.pool_applicant_id.type_id = vals['type_id']
            // 
            // if 'interviewer_ids' in vals:
            //     interviewers_to_clean = old_interviewers - self.interviewer_ids
            //     interviewers_to_clean._remove_recruitment_interviewers()
            //     self.sudo().interviewer_ids._create_recruitment_interviewers()
            // 
            //     new_interviewers = self.interviewer_ids - old_interviewers - self.env.user
            //     if new_interviewers:
            //         for applicant in self:
            //             notification_subject = _("You have been assigned as an interviewer for %s", applicant.display_name)
            //             notification_body = _("You have been assigned as an interviewer for the Applicant %s", applicant.partner_name)
            //             applicant.message_notify(
            //                 res_id=applicant.id,
            //                 model=applicant._name,
            //                 partner_ids=new_interviewers.partner_id.ids,
            //                 author_id=self.env.user.partner_id.id,
            //                 email_from=self.env.user.email_formatted,
            //                 subject=notification_subject,
            //                 body=notification_body,
            //                 email_layout_xmlid="mail.mail_notification_layout",
            //                 model_description="Applicant",
            //             )
            // return res
            */
            return default;
        }
    }
}