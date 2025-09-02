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
    [Module("utm", Depends = new[] { "base", "web" })]
    public class UtmMixinAppService : ApplicationService, IUtmMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public UtmMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionActivateCurrencyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_activate_currency(self):
            // self.currency_id.filtered(lambda currency: not currency.active).write({'active': True})
            */
            return default;
        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_add_from_catalog(self):
            // res = super().action_add_from_catalog()
            // if res['context'].get('product_catalog_order_model') == 'account.move':
            //     res['search_view_id'] = [self.env.ref('account.product_view_search_catalog').id, 'search']
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_cancel(self):
            // """ Cancel SO after showing the cancel wizard when needed. (cfr :meth:`_show_cancel_wizard`)
            // 
            // For post-cancel operations, please only override :meth:`_action_cancel`.
            // 
            // note: self.ensure_one() if the wizard is shown.
            // """
            // if any(order.locked for order in self):
            //     raise UserError(_("You cannot cancel a locked order. Please unlock it first."))
            // cancel_warning = self._show_cancel_wizard()
            // if cancel_warning:
            //     self.ensure_one()
            //     template_id = self.env['ir.model.data']._xmlid_to_res_id(
            //         'sale.mail_template_sale_cancellation', raise_if_not_found=False
            //     )
            //     lang = self.env.context.get('lang')
            //     template = self.env['mail.template'].browse(template_id)
            //     if template.lang:
            //         lang = template._render_lang(self.ids)[self.id]
            //     ctx = {
            //         'default_template_id': template_id,
            //         'default_order_id': self.id,
            //         'mark_so_as_canceled': True,
            //         'default_email_layout_xmlid': "mail.mail_notification_layout_with_responsible_signature",
            //         'model_description': self.with_context(lang=lang).type_name,
            //     }
            //     return {
            //         'name': _('Cancel %s', self.type_name),
            //         'view_mode': 'form',
            //         'res_model': 'sale.order.cancel',
            //         'view_id': self.env.ref('sale.sale_order_cancel_view_form').id,
            //         'type': 'ir.actions.act_window',
            //         'context': ctx,
            //         'target': 'new'
            //     }
            // else:
            //     return self._action_cancel()
            */
            return default;
        }

        public async Task<TEntity> ActionCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _action_cancel(self):
            // inv = self.invoice_ids.filtered(lambda inv: inv.state == 'draft')
            // inv.button_cancel()
            // return self.write({'state': 'cancel'})
            */
            return default;
        }

        public async Task<TEntity> ActionCancelPeppolDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py) ---
            // def action_cancel_peppol_documents(self):
            // # if the peppol_move_state is processing/done
            // # then it means it has been already sent to peppol proxy and we can't cancel
            // if any(move.peppol_move_state in {'processing', 'done'} for move in self):
            //     raise UserError(_("Cannot cancel an entry that has already been sent to PEPPOL"))
            // self.peppol_move_state = False
            // self.sending_data = False
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_confirm(self):
            // """ Confirm the given quotation(s) and set their confirmation date.
            // 
            // If the corresponding setting is enabled, also locks the Sale Order.
            // 
            // :return: True
            // :rtype: bool
            // :raise: UserError if trying to confirm cancelled SO's
            // """
            // for order in self:
            //     error_msg = order._confirmation_error_message()
            //     if error_msg:
            //         raise UserError(error_msg)
            // 
            // self.order_line._validate_analytic_distribution()
            // 
            // for order in self:
            //     if order.partner_id in order.message_partner_ids:
            //         continue
            //     order.message_subscribe([order.partner_id.id])
            // 
            // self.write(self._prepare_confirmation_values())
            // 
            // # Context key 'default_name' is sometimes propagated up to here.
            // # We don't need it and it creates issues in the creation of linked records.
            // context = self._context.copy()
            // context.pop('default_name', None)
            // context.pop('default_user_id', None)
            // 
            // self.with_context(context)._action_confirm()
            // user = self[:1].create_uid
            // if user and user.sudo().has_group('sale.group_auto_done_setting'):
            //     # Public user can confirm SO, so we check the group on any record creator.
            //     self.action_lock()
            // 
            // if self.env.context.get('send_email'):
            //     self._send_order_confirmation_mail()
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _action_confirm(self):
            // """ Implementation of additional mechanism of Sales Order confirmation.
            //     This method should be extended when the confirmation should generated
            //     other documents. In this method, the SO are in 'sale' state (not yet 'done').
            // """
            // pass
            */
            return default;
        }

        public async Task<TEntity> ActionCreateMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //     'default_candidate_id': self.candidate_id.id,
            //     'default_partner_ids': partners.ids,
            //     'default_user_id': self.env.uid,
            //     'default_name': self.partner_name,
            //     'attachment_ids': self.attachment_ids.ids
            // }
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionDebitNoteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def action_debit_note(self):
            // action = self.env.ref('account_debit_note.action_view_account_move_debit')._get_action_dict()
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_draft(self):
            // orders = self.filtered(lambda s: s.state in ['cancel', 'sent'])
            // return orders.write({
            //     'state': 'draft',
            //     'signature': False,
            //     'signed_by': False,
            //     'signed_on': False,
            // })
            */
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ActionForceRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ActionInvoiceDownloadPdfAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_invoice_download_pdf(self):
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': f'/account/download_invoice_documents/{",".join(map(str, self.ids))}/pdf',
            //     'target': 'download',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceDownloadUblAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def action_invoice_download_ubl(self):
            // if invoices_with_ubl := self.filtered('ubl_cii_xml_id'):
            //     return {
            //         'type': 'ir.actions.act_url',
            //         'url': f'/account/download_invoice_documents/{",".join(map(str, invoices_with_ubl.ids))}/ubl',
            //         'target': 'download',
            //     }
            // return False
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _action_invoice_ready_to_be_sent(self):
            // # OVERRIDE
            // # Make sure the send invoice CRON is called when an invoice becomes ready to be sent by mail.
            // res = super()._action_invoice_ready_to_be_sent()
            // 
            // send_invoice_cron = self.env.ref('sale.send_invoice_cron', raise_if_not_found=False)
            // if send_invoice_cron:
            //     send_invoice_cron._trigger()
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_invoice_sent(self):
            // """ Open a window to compose an email, with the edi invoice template
            //     message loaded by default
            // """
            // self.ensure_one()
            // 
            // report_action = self.action_send_and_print()
            // if self.env.is_admin() and not self.env.company.external_report_layout_id and not self.env.context.get('discard_logo_check'):
            //     report_action = self.env['ir.actions.report']._action_configure_external_report_layout(report_action, "account.action_base_document_layout_configurator")
            //     report_action['context']['default_from_invoice'] = self.move_type == 'out_invoice'
            // 
            // return report_action
            */
            return default;
        }

        public async Task<TEntity> ActionLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_lock(self):
            // self.locked = True
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_open_business_doc(self):
            // self.ensure_one()
            // return {
            //     'name': _("Order"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'sale.order',
            //     'res_id': self.id,
            //     'views': [(False, 'form')],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDiscountWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_open_discount_wizard(self):
            // self.ensure_one()
            // return {
            //     'name': _("Discount"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'sale.order.discount',
            //     'view_mode': 'form',
            //     'target': 'new',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_employee(self):
            // self.ensure_one()
            // return self.candidate_id.action_open_employee()
            */
            return default;
        }

        public async Task<TEntity> ActionOpenExpenseReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def action_open_expense_report(self):
            // self.ensure_one()
            // return {
            //     'name': self.expense_sheet_id.name,
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'views': [(False, 'form')],
            //     'res_model': 'hr.expense.sheet',
            //     'res_id': self.expense_sheet_id.id
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenOtherApplicationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_other_applications(self):
            // self.ensure_one()
            // similar_candidates = (
            //     self.env["hr.candidate"]
            //     .with_context(active_test=False)
            //     .search(self.candidate_id._get_similar_candidates_domain())
            //     - self.candidate_id
            // )
            // return {
            //     'name': _('Other Applications'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.applicant',
            //     'view_mode': 'list,kanban,form,pivot,graph,calendar,activity',
            //     'domain': [('id', 'in', (self.candidate_id.applicant_ids + similar_candidates.applicant_ids).ids)],
            //     'context': {
            //         'active_test': False,
            //         'search_default_stage': 1,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionPostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def action_post(self):
            // # inherit of the function from account.move to validate a new tax and the priceunit of a downpayment
            // res = super(AccountMove, self).action_post()
            // 
            // # We cannot change lines content on locked SO, changes on invoices are not forwarded to the SO if the SO is locked
            // dp_lines = self.line_ids.sale_line_ids.filtered(lambda l: l.is_downpayment and not l.display_type)
            // dp_lines._compute_name()  # Update the description of DP lines (Draft -> Posted)
            // downpayment_lines = dp_lines.filtered(lambda sol: not sol.order_id.locked)
            // other_so_lines = downpayment_lines.order_id.order_line - downpayment_lines
            // real_invoices = set(other_so_lines.invoice_lines.move_id)
            // for so_dpl in downpayment_lines:
            //     so_dpl.price_unit = so_dpl._get_downpayment_line_price_unit(real_invoices)
            //     so_dpl.tax_id = so_dpl.invoice_lines.tax_ids
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionPreviewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_preview_sale_order(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': self.get_portal_url(),
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionPrintPdfAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_print_pdf(self):
            // self.ensure_one()
            // return self.env.ref('account.account_invoices').report_action(self.id)
            */
            return default;
        }

        public async Task<TEntity> ActionProcessEdiWebServicesAsync<TEntity>(IEnumerable<TEntity> entities, object with_commit) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def action_process_edi_web_services(self, with_commit=True):
            // docs = self.edi_document_ids.filtered(lambda d: d.state in ('to_send', 'to_cancel') and d.blocking_level != 'error')
            // docs._process_documents_web_services(with_commit=with_commit)
            */
            return default;
        }

        public async Task<TEntity> ActionPurchaseMatchingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def action_purchase_matching(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Purchase Matching"),
            //     'res_model': 'purchase.bill.line.match',
            //     'domain': [
            //         ('partner_id', 'in', (self.partner_id | self.partner_id.commercial_partner_id).ids),
            //         ('company_id', 'in', self.env.company.ids),
            //         ('account_move_id', 'in', [self.id, False]),
            //     ],
            //     'views': [(self.env.ref('purchase.purchase_bill_line_match_tree').id, 'list')],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_quotation_send(self):
            // """ Opens a wizard to compose an email, with relevant mail template loaded by default """
            // self.filtered(lambda so: so.state in ('draft', 'sent')).order_line._validate_analytic_distribution()
            // lang = self.env.context.get('lang')
            // 
            // ctx = {
            //     'default_model': 'sale.order',
            //     'default_res_ids': self.ids,
            //     'default_composition_mode': 'comment',
            //     'default_email_layout_xmlid': 'mail.mail_notification_layout_with_responsible_signature',
            //     'email_notification_allow_footer': True,
            //     'proforma': self.env.context.get('proforma', False),
            // }
            // 
            // if len(self) > 1:
            //     ctx['default_composition_mode'] = 'mass_mail'
            // else:
            //     ctx.update({
            //         'force_email': True,
            //         'model_description': self.with_context(lang=lang).type_name,
            //     })
            //     if not self.env.context.get('hide_default_template'):
            //         mail_template = self._find_mail_template()
            //         if mail_template:
            //             ctx.update({
            //                 'default_template_id': mail_template.id,
            //                 'mark_so_as_sent': True,
            //             })
            //         if mail_template and mail_template.lang:
            //             lang = mail_template._render_lang(self.ids)[self.id]
            //     else:
            //         for order in self:
            //             order._portal_ensure_token()
            // 
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'views': [(False, 'form')],
            //     'view_id': False,
            //     'target': 'new',
            //     'context': ctx,
            // }
            // if (
            //     self.env.context.get('check_document_layout')
            //     and not self.env.context.get('discard_logo_check')
            //     and self.env.is_admin()
            //     and not self.env.company.external_report_layout_id
            // ):
            //     layout_action = self.env['ir.actions.report']._action_configure_external_report_layout(
            //         action,
            //     )
            //     # Need to remove this context for windows action
            //     action.pop('close_on_report_download', None)
            //     layout_action['context']['dialog_size'] = 'extra-large'
            //     return layout_action
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_quotation_sent(self):
            // """ Mark the given draft quotation(s) as sent.
            // 
            // :raise: UserError if any given SO is not in draft state.
            // """
            // if any(order.state != 'draft' for order in self):
            //     raise UserError(_("Only draft orders can be marked as sent directly."))
            // 
            // for order in self:
            //     order.message_subscribe(partner_ids=order.partner_id.ids)
            // 
            // self.write({'state': 'sent'})
            */
            return default;
        }

        public async Task<TEntity> ActionRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ActionRescheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_reschedule_meeting(self):
            // self.ensure_one()
            // action = self.action_schedule_meeting(smart_calendar=False)
            // next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // if next_activity.calendar_event_id:
            //     action['context']['initial_date'] = next_activity.calendar_event_id.start
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionRetryEdiDocumentsErrorAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def action_retry_edi_documents_error(self):
            // self._retry_edi_documents_error_hook()
            // self.edi_document_ids.write({'error': False, 'blocking_level': False})
            // self.action_process_edi_web_services()
            */
            return default;
        }

        public async Task<TEntity> ActionReverseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ActionScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object smart_calendar) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_schedule_meeting(self, smart_calendar=True):
            // """ Open meeting's calendar view to schedule meeting on current opportunity.
            // 
            //     :param smart_calendar: boolean, to set to False if the view should not try to choose relevant
            //       mode and initial date for calendar view, see ``_get_opportunity_meeting_view_parameters``
            //     :return dict: dictionary value for created Meeting view
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("calendar.action_calendar_event")
            // partner_ids = self.env.user.partner_id.ids
            // if self.partner_id:
            //     partner_ids.append(self.partner_id.id)
            // current_opportunity_id = self.id if self.type == 'opportunity' else False
            // action['context'] = {
            //     'search_default_opportunity_id': current_opportunity_id,
            //     'default_opportunity_id': current_opportunity_id,
            //     'default_partner_id': self.partner_id.id,
            //     'default_partner_ids': partner_ids,
            //     'default_team_id': self.team_id.id,
            //     'default_name': self.name,
            // }
            // 
            // # 'Smart' calendar view : get the most relevant time period to display to the user.
            // if current_opportunity_id and smart_calendar:
            //     mode, initial_date = self._get_opportunity_meeting_view_parameters()
            //     action['context'].update({'default_mode': mode, 'initial_date': initial_date})
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionSendAndPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_send_and_print(self):
            // self.env['account.move.send']._check_move_constrains(self)
            // return {
            //     'name': _("Print & Send"),
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

        public async Task<TEntity> ActionSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ActionSetAutomatedProbabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_automated_probability(self):
            // self.write({'probability': self.automated_probability})
            */
            return default;
        }

        public async Task<TEntity> ActionSetLostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_lost(self, **additional_values):
            // """ Lost semantic: probability = 0 or active = False """
            // res = self.action_archive()
            // if additional_values:
            //     self.write(dict(additional_values))
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won(self):
            // """ Won semantic: probability = 100 (active untouched) """
            // self.action_unarchive()
            // # group the leads by team_id, in order to write once by values couple (each write leads to frequency increment)
            // leads_by_won_stage = {}
            // for lead in self:
            //     won_stages = self._stage_find(domain=[('is_won', '=', True)], limit=None)
            //     # ABD : We could have a mixed pipeline, with "won" stages being separated by "standard"
            //     # stages. In the future, we may want to prevent any "standard" stage to have a higher
            //     # sequence than any "won" stage. But while this is not the case, searching
            //     # for the "won" stage while alterning the sequence order (see below) will correctly
            //     # handle such a case :
            //     #       stage sequence : [x] [x (won)] [y] [y (won)] [z] [z (won)]
            //     #       when in stage [y] and marked as "won", should go to the stage [y (won)],
            //     #       not in [x (won)] nor [z (won)]
            //     stage_id = next((stage for stage in won_stages if stage.sequence > lead.stage_id.sequence), None)
            //     if not stage_id:
            //         stage_id = next((stage for stage in reversed(won_stages) if stage.sequence <= lead.stage_id.sequence), won_stages)
            //     if stage_id in leads_by_won_stage:
            //         leads_by_won_stage[stage_id] += lead
            //     else:
            //         leads_by_won_stage[stage_id] = lead
            // for won_stage_id, leads in leads_by_won_stage.items():
            //     leads.write({'stage_id': won_stage_id.id, 'probability': 100})
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonRainbowmanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won_rainbowman(self):
            // self.ensure_one()
            // self.action_set_won()
            // 
            // message = self._get_rainbowman_message()
            // if message:
            //     return {
            //         'effect': {
            //             'fadeout': 'slow',
            //             'message': message,
            //             'img_url': '/web/image/%s/%s/image_1024' % (self.team_id.user_id._name, self.team_id.user_id.id) if self.team_id.user_id.image_1024 else '/web/static/img/smile.svg',
            //             'type': 'rainbow_man',
            //         }
            //     }
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionShowPotentialDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_show_potential_duplicates(self):
            // """ Open kanban view to display duplicate leads or opportunity.
            //     :return dict: dictionary value for created kanban view
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("crm.crm_lead_opportunities")
            // action['domain'] = [('id', 'in', self.duplicate_lead_ids.ids)]
            // action['context'] = {
            //     'active_test': False,
            //     'create': False
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionSnoozeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_snooze(self):
            // self.ensure_one()
            // my_next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // my_next_activity.action_snooze()
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionSwitchMoveTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_switch_move_type(self):
            // if any(move.posted_before for move in self):
            //     raise ValidationError(_("You cannot switch the type of a document which has been posted once."))
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
            //         move.write({
            //             'line_ids': [
            //                 Command.update(line.id, {'quantity': -line.quantity})
            //                 for line in move.line_ids
            //                 if line.display_type == 'product'
            //             ]
            //         })
            */
            return default;
        }

        public async Task<TEntity> ActionToggleBlockPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ActionUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_unlock(self):
            // self.locked = False
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateFposValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_update_fpos_values(self):
            // self.invoice_line_ids._compute_price_unit()
            // self.invoice_line_ids._compute_tax_ids()
            // self.line_ids._compute_account_id()
            */
            return default;
        }

        public async Task<TEntity> ActionUpdatePricesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_update_prices(self):
            // self.ensure_one()
            // 
            // self._recompute_prices()
            // 
            // if self.pricelist_id:
            //     message = _("Product prices have been recomputed according to pricelist %s.",
            //         self.pricelist_id._get_html_link())
            // else:
            //     message = _("Product prices have been recomputed.")
            // self.message_post(body=message)
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateTaxesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_update_taxes(self):
            // self.ensure_one()
            // 
            // self._recompute_taxes()
            // 
            // if self.partner_id:
            //     self.message_post(body=_("Product taxes have been recomputed according to fiscal position %s.",
            //         self.fiscal_position_id._get_html_link() if self.fiscal_position_id else "")
            //     )
            */
            return default;
        }

        public async Task<TEntity> ActionViewDebitNotesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def action_view_debit_notes(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Debit Notes'),
            //     'res_model': 'account.move',
            //     'view_mode': 'list,form',
            //     'domain': [('debit_origin_id', '=', self.id)],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object invoices) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_view_invoice(self, invoices=False):
            // if not invoices:
            //     invoices = self.mapped('invoice_ids')
            // action = self.env['ir.actions.actions']._for_xml_id('account.action_move_out_invoice_type')
            // if len(invoices) > 1:
            //     action['domain'] = [('id', 'in', invoices.ids)]
            // elif len(invoices) == 1:
            //     form_view = [(self.env.ref('account.view_move_form').id, 'form')]
            //     if 'views' in action:
            //         action['views'] = form_view + [(state,view) for state,view in action['views'] if view != 'form']
            //     else:
            //         action['views'] = form_view
            //     action['res_id'] = invoices.id
            // else:
            //     action = {'type': 'ir.actions.act_window_close'}
            // 
            // context = {
            //     'default_move_type': 'out_invoice',
            // }
            // if len(self) == 1:
            //     context.update({
            //         'default_partner_id': self.partner_id.id,
            //         'default_partner_shipping_id': self.partner_shipping_id.id,
            //         'default_invoice_payment_term_id': self.payment_term_id.id or self.partner_id.property_payment_term_id.id or self.env['account.move'].default_get(['invoice_payment_term_id']).get('invoice_payment_term_id'),
            //         'default_invoice_origin': self.name,
            //     })
            // action['context'] = context
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewLandedCostsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def action_view_landed_costs(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("stock_landed_costs.action_stock_landed_cost")
            // domain = [('id', 'in', self.landed_costs_ids.ids)]
            // context = dict(self.env.context, default_vendor_bill_id=self.id)
            // views = [(self.env.ref('stock_landed_costs.view_stock_landed_cost_tree2').id, 'list'), (False, 'form'), (False, 'kanban')]
            // return dict(action, domain=domain, context=context, views=views)
            */
            return default;
        }

        public async Task<TEntity> ActionViewPaymentTransactionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def action_view_payment_transactions(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('payment.action_payment_transaction')
            // 
            // if len(self.transaction_ids) == 1:
            //     action['view_mode'] = 'form'
            //     action['res_id'] = self.transaction_ids.id
            //     action['views'] = []
            // else:
            //     action['domain'] = [('id', 'in', self.transaction_ids.ids)]
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewSourcePurchaseOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def action_view_source_purchase_orders(self):
            // self.ensure_one()
            // source_orders = self.line_ids.purchase_line_id.order_id
            // result = self.env['ir.actions.act_window']._for_xml_id('purchase.purchase_form_action')
            // if len(source_orders) > 1:
            //     result['domain'] = [('id', 'in', source_orders.ids)]
            // elif len(source_orders) == 1:
            //     result['views'] = [(self.env.ref('purchase.purchase_order_form', False).id, 'form')]
            //     result['res_id'] = source_orders.id
            // else:
            //     result = {'type': 'ir.actions.act_window_close'}
            // return result
            */
            return default;
        }

        public async Task<TEntity> ActionViewSourceSaleOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def action_view_source_sale_orders(self):
            // self.ensure_one()
            // source_orders = self.line_ids.sale_line_ids.order_id
            // result = self.env['ir.actions.act_window']._for_xml_id('sale.action_orders')
            // if len(source_orders) > 1:
            //     result['domain'] = [('id', 'in', source_orders.ids)]
            // elif len(source_orders) == 1:
            //     result['views'] = [(self.env.ref('sale.view_order_form', False).id, 'form')]
            //     result['res_id'] = source_orders.id
            // else:
            //     result = {'type': 'ir.actions.act_window_close'}
            // return result
            */
            return default;
        }

        public async Task<TEntity> ActionViewStatisticsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def action_view_statistics(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('link_tracker.link_tracker_click_action_statistics')
            // action['domain'] = [('link_id', '=', self.id)]
            // action['context'] = dict(self._context, create=False)
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionViewTimesheetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def action_view_timesheet(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Timesheets'),
            //     'domain': [('project_id', '!=', False)],
            //     'res_model': 'account.analytic.line',
            //     'view_id': False,
            //     'view_mode': 'list,form',
            //     'help': _("""
            //         <p class="o_view_nocontent_smiling_face">
            //             Record timesheets
            //         </p><p>
            //             You can register and track your workings hours by project every
            //             day. Every time spent on a project will become a cost and can be re-invoiced to
            //             customers if required.
            //         </p>
            //     """),
            //     'limit': 80,
            //     'context': {
            //         'default_project_id': self.id,
            //         'search_default_project_id': [self.id]
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionViewWipProductionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: account_move.py) ---
            // def action_view_wip_production(self):
            // self.ensure_one()
            // action = {
            //     'res_model': 'mrp.production',
            //     'type': 'ir.actions.act_window',
            // }
            // if len(self.wip_production_ids) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': self.wip_production_ids.id,
            //     })
            // else:
            //     action.update({
            //         'name': _("WIP MOs of %s", self.name),
            //         'domain': [('id', 'in', self.wip_production_ids.ids)],
            //         'view_mode': 'list,form',
            //     })
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionVisitPageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def action_visit_page(self):
            // return {
            //     'name': _("Visit Webpage"),
            //     'type': 'ir.actions.act_url',
            //     'url': self.url,
            //     'target': 'new',
            // }
            */
            return default;
        }

        public async Task<TEntity> AddBaseLinesForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _add_base_lines_for_early_payment_discount(self):
            // """
            // When applying a payment term with an early payment discount, and when said payment term computes the tax on the
            // 'mixed' setting, the tax computation is always based on the discounted amount untaxed.
            // Creates the necessary line for this behavior to be displayed.
            // :returns: array containing the necessary lines or empty array if the payment term isn't epd mixed
            // """
            // self.ensure_one()
            // epd_lines = []
            // if (
            //     self.payment_term_id.early_discount
            //     and self.payment_term_id.early_pay_discount_computation == 'mixed'
            //     and self.payment_term_id.discount_percentage
            // ):
            //     percentage = self.payment_term_id.discount_percentage
            //     currency = self.currency_id or self.company_id.currency_id
            //     for line in self.order_line.filtered(lambda x: not x.display_type):
            //         line_amount_after_discount = (line.price_subtotal / 100) * percentage
            //         epd_lines.append(self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //             record=self,
            //             price_unit=-line_amount_after_discount,
            //             quantity=1.0,
            //             currency_id=currency,
            //             sign=1,
            //             special_type='early_payment',
            //             tax_ids=line.tax_id,
            //         ))
            //         epd_lines.append(self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //             record=self,
            //             price_unit=line_amount_after_discount,
            //             quantity=1.0,
            //             currency_id=currency,
            //             sign=1,
            //             special_type='early_payment',
            //         ))
            // return epd_lines
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object purchase_order_lines) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _add_purchase_order_lines(self, purchase_order_lines):
            // """ Creates new invoice lines from purchase order lines """
            // self.ensure_one()
            // new_line_ids = self.env['account.move.line']
            // 
            // for po_line in purchase_order_lines:
            //     new_line_values = po_line._prepare_account_move_line(self)
            //     new_line_ids += self.env['account.move.line'].new(new_line_values)
            // 
            // self.invoice_line_ids += new_line_ids
            */
            return default;
        }

        public async Task<TEntity> AffectTaxReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _affect_tax_report(self):
            // return any(line._affect_tax_report() for line in (self.line_ids | self.invoice_line_ids))
            */
            return default;
        }

        public async Task<TEntity> ApplyDeltaRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object date_origin, object period) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ArchiveApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //     'context': {'default_applicant_ids': self.ids, 'active_test': False},
            //     'views': [[False, 'form']]
            // }
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _auto_init(self):
            // super()._auto_init()
            // tools.create_index(self._cr, 'crm_lead_user_id_team_id_type_index',
            //                    self._table, ['user_id', 'team_id', 'type'])
            // tools.create_index(self._cr, 'crm_lead_create_date_team_id_idx',
            //                    self._table, ['create_date', 'team_id'])
            */
            return default;
        }

        public async Task<TEntity> AutopostBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> AutopostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _autopost_draft_entries(self):
            // ''' This method is called from a cron job.
            // It is used to post entries such as those created by the module
            // account_asset and recurring entries created in _post().
            // '''
            // moves = self.search([
            //     ('state', '=', 'draft'),
            //     ('date', '<=', fields.Date.context_today(self)),
            //     ('auto_post', '!=', 'no'),
            //     '|', ('checked', '=', True), ('journal_id.autocheck_on_post', '=', True)
            // ], limit=100)
            // 
            // try:  # try posting in batch
            //     with self.env.cr.savepoint():
            //         moves._post()
            // except UserError:  # if at least one move cannot be posted, handle moves one by one
            //     for move in moves:
            //         try:
            //             with self.env.cr.savepoint():
            //                 move._post()
            //         except UserError as e:
            //             move.checked = False
            //             move.auto_post = 'no'
            //             msg = _('The move could not be posted for the following reason: %(error_message)s', error_message=e)
            //             move.message_post(body=msg, message_type='comment')
            // 
            // if len(moves) == 100:  # assumes there are more whenever search hits limit
            //     self.env.ref('account.ir_cron_auto_post_draft_entry')._trigger()
            */
            return default;
        }

        public async Task<TEntity> BuildCreditWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object current_amount, object exclude_current, object exclude_amount) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _build_credit_warning_message(self, record, current_amount=0.0, exclude_current=False, exclude_amount=0.0):
            // """ Build the warning message that will be displayed in a yellow banner on top of the current record
            //     if the partner exceeds a credit limit (set on the company or the partner itself).
            //     :param record:                  The record where the warning will appear (Invoice, Sales Order...).
            //     :param current_amount (float):  The partner's outstanding credit amount from the current document.
            //     :param exclude_current (bool):  DEPRECATED in favor of parameter `exclude_amount`:
            //                                     Whether to exclude `current_amount` from the credit to invoice.
            //     :param exclude_amount (float):  The amount to subtract from the partner's `credit_to_invoice`.
            //                                     Consider the warning on a draft invoice created from a sales order.
            //                                     After confirming the invoice the (partial) amount (on the invoice)
            //                                     stemming from sales orders will be substracted from the `credit_to_invoice`.
            //                                     This will reduce the total credit of the partner.
            //                                     This parameter is used to reflect this amount.
            //     :return (str):                  The warning message to be showed.
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

        public async Task<TEntity> ButtonAbandonCancelPostedPostedMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_abandon_cancel_posted_posted_moves(self):
            // '''Cancel the request for cancellation of the EDI.
            // '''
            // documents = self.env['account.edi.document']
            // for move in self:
            //     is_move_marked = False
            //     for doc in move.edi_document_ids:
            //         move_applicability = doc.edi_format_id._get_move_applicability(move)
            //         if doc.state == 'to_cancel' and move_applicability and move_applicability.get('cancel'):
            //             documents |= doc
            //             is_move_marked = True
            //     if is_move_marked:
            //         move.message_post(body=_("A request for cancellation of the EDI has been called off."))
            // 
            // documents.write({'state': 'sent', 'error': False, 'blocking_level': False})
            */
            return default;
        }

        public async Task<TEntity> ButtonCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def button_cancel(self):
            // res = super().button_cancel()
            // 
            // self.line_ids.filtered('is_downpayment').sale_line_ids.filtered(
            //     lambda sol: not sol.display_type)._compute_name()
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> ButtonCancelPostedMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_cancel_posted_moves(self):
            // '''Mark the edi.document related to this move to be canceled.
            // '''
            // to_cancel_documents = self.env['account.edi.document']
            // for move in self:
            //     move._check_fiscal_lock_dates()
            //     is_move_marked = False
            //     for doc in move.edi_document_ids:
            //         move_applicability = doc.edi_format_id._get_move_applicability(move)
            //         if doc.edi_format_id._needs_web_services() \
            //                 and doc.state == 'sent' \
            //                 and move_applicability \
            //                 and move_applicability.get('cancel'):
            //             to_cancel_documents |= doc
            //             is_move_marked = True
            //     if is_move_marked:
            //         move.message_post(body=_("A cancellation of the EDI has been requested."))
            // 
            // to_cancel_documents.write({'state': 'to_cancel', 'error': False, 'blocking_level': False})
            */
            return default;
        }

        public async Task<TEntity> ButtonCreateLandedCostsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def button_create_landed_costs(self):
            // """Create a `stock.landed.cost` record associated to the account move of `self`, each
            // `stock.landed.costs` lines mirroring the current `account.move.line` of self.
            // """
            // self.ensure_one()
            // landed_costs_lines = self.line_ids.filtered(lambda line: line.is_landed_costs_line)
            // 
            // sign = -1 if self.move_type in ['in_refund'] else 1
            // landed_costs = self.env['stock.landed.cost'].with_company(self.company_id).create({
            //     'vendor_bill_id': self.id,
            //     'cost_lines': [(0, 0, {
            //         'product_id': l.product_id.id,
            //         'name': l.product_id.name,
            //         'account_id': l.product_id.product_tmpl_id.get_product_accounts()['stock_input'].id,
            //         'price_unit': sign * l.currency_id._convert(l.price_subtotal, l.company_currency_id, l.company_id, self.invoice_date or fields.Date.context_today(l)),
            //         'split_method': l.product_id.split_method_landed_cost or 'equal',
            //     }) for l in landed_costs_lines],
            // })
            // action = self.env["ir.actions.actions"]._for_xml_id("stock_landed_costs.action_stock_landed_cost")
            // return dict(action, view_mode='form', res_id=landed_costs.id, views=[(False, 'form')])
            */
            return default;
        }

        public async Task<TEntity> ButtonDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def button_draft(self):
            // res = super().button_draft()
            // 
            // self.line_ids.filtered('is_downpayment').sale_line_ids.filtered(
            //     lambda sol: not sol.display_type)._compute_name()
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> ButtonForceCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_force_cancel(self):
            // """ Cancel the invoice without waiting for the cancellation request to succeed.
            // """
            // for move in self:
            //     to_cancel_edi_documents = move.edi_document_ids.filtered(lambda doc: doc.state == 'to_cancel')
            //     move.message_post(body=_("This invoice was canceled while the EDIs %s still had a pending cancellation request.", ", ".join(to_cancel_edi_documents.mapped('edi_format_id.name'))))
            // self.button_cancel()
            */
            return default;
        }

        public async Task<TEntity> ButtonHashAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_hash(self):
            // self._hash_moves(force_hash=True)
            */
            return default;
        }

        public async Task<TEntity> ButtonProcessEdiWebServicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def button_process_edi_web_services(self):
            // self.ensure_one()
            // self.action_process_edi_web_services(with_commit=False)
            */
            return default;
        }

        public async Task<TEntity> ButtonRequestCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_request_cancel(self):
            // """ Hook allowing the localizations to request a cancellation from the government before cancelling the invoice. """
            // self.ensure_one()
            // if not self.need_cancel_request:
            //     raise UserError(_("You can only request a cancellation for invoice sent to the government."))
            */
            return default;
        }

        public async Task<TEntity> ButtonSetCheckedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_set_checked(self):
            // for move in self:
            //     move.checked = True
            */
            return default;
        }

        public async Task<TEntity> CalculateHashesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object previous_hash) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _calculate_hashes(self, previous_hash):
            // """
            // :return: dict of move_id: hash
            // """
            // hash_version = self._context.get('hash_version', MAX_HASH_VERSION)
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

        public async Task<TEntity> CanBeUnlinkedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _can_be_unlinked(self):
            // self.ensure_one()
            // lock_date = self.company_id._get_user_fiscal_lock_date(self.journal_id)
            // return not self.inalterable_hash and self.date > lock_date
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
            // return not tools.config['test_enable'] and not modules.module.current_test
            */
            return default;
        }

        public async Task<TEntity> CanForceCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> CheckAndDecodeAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_and_decode_attachment(self, attachments):
            // if not attachments or self.env.context.get('no_new_invoice'):
            //     return False
            // if self.state != 'draft':
            //     self.with_user(SUPERUSER_ID).message_post(
            //         body=_('The invoice is not a draft, it was not updated from the attachment.'),
            //         message_type='comment',
            //     )
            //     return False
            // 
            // # As we are coming from the mail, we assume that ONE of the attachments
            // # will enhance the invoice thanks to EDI / OCR / .. capabilities
            // move_per_decodable_attachment = self._extend_with_attachments(attachments, new=bool(self._context.get('from_alias')))
            // if self.invoice_line_ids and not move_per_decodable_attachment:
            //     self.with_user(SUPERUSER_ID).message_post(
            //         body=_('The invoice already contains lines, it was not updated from the attachment.'),
            //         message_type='comment',
            //     )
            //     return False
            // attachments_in_invoices = self.env['ir.attachment']
            // for attachment in move_per_decodable_attachment:
            //     attachments_in_invoices += attachment
            // # Unlink the unused attachments (prevents storing marketing images sent with emails)
            // if self._context.get('from_alias'):
            //     (attachments - attachments_in_invoices).unlink()
            // return move_per_decodable_attachment
            */
            return default;
        }

        public async Task<TEntity> CheckBalancedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //         raise UserError("The entry is not balanced.")
            // 
            //     error_msg = _("The following entries are unbalanced:\n\n")
            //     for move in unbalanced_moves:
            //         error_msg += f"  - {self.browse(move[0]).name}\n"
            //         raise UserError(error_msg)
            */
            return default;
        }

        public async Task<TEntity> CheckDraftableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_draftable(self):
            // exchange_move_ids = set()
            // if self:
            //     self.env['account.full.reconcile'].flush_model(['exchange_move_id'])
            //     self.env['account.partial.reconcile'].flush_model(['exchange_move_id'])
            //     sql = SQL(
            //         """
            //             SELECT DISTINCT sub.exchange_move_id
            //             FROM (
            //                 SELECT exchange_move_id
            //                 FROM account_full_reconcile
            //                 WHERE exchange_move_id IN %s
            // 
            //                 UNION ALL
            // 
            //                 SELECT exchange_move_id
            //                 FROM account_partial_reconcile
            //                 WHERE exchange_move_id IN %s
            //             ) AS sub
            //         """,
            //         tuple(self.ids), tuple(self.ids),
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

        public async Task<TEntity> CheckEdiDocumentsForResetToDraftInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _check_edi_documents_for_reset_to_draft(self):
            // self.ensure_one()
            // for doc in self.edi_document_ids:
            //     move_applicability = doc.edi_format_id._get_move_applicability(self)
            //     if doc.edi_format_id._needs_web_services() \
            //         and doc.state in ('sent', 'to_cancel') \
            //         and move_applicability \
            //         and move_applicability.get('cancel'):
            //         return False
            // return True
            */
            return default;
        }

        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_field_access_rights(self, operation, field_names):
            // result = super().check_field_access_rights(operation, field_names)
            // if not field_names:
            //     weirdos = ['needed_terms', 'quick_encoding_vals', 'payment_term_details']
            //     result = [fname for fname in result if fname not in weirdos]
            // return result
            */
            return default;
        }

        public async Task<TEntity> CheckFiscalLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> CheckJournalMoveTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _check_journal_move_type(self):
            // for move in self:
            //     if move.is_purchase_document(include_receipts=True) and move.journal_id.type != 'purchase':
            //         raise ValidationError(_("Cannot create a purchase document in a non purchase journal"))
            //     if move.is_sale_document(include_receipts=True) and move.journal_id.type != 'sale':
            //         raise ValidationError(_("Cannot create a sale document in a non sale journal"))
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _check_journal_move_type(self):
            // return super(AccountMove, self.filtered(lambda x: not x.expense_sheet_id))._check_journal_move_type()
            */
            return default;
        }

        public async Task<TEntity> CheckMoveSequenceChainAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_move_sequence_chain(self):
            // return self.filtered(lambda move: move.name != '/')._is_end_of_seq_chain()
            */
            return default;
        }

        public async Task<TEntity> CheckOrderLineCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _check_order_line_company_id(self):
            // for order in self:
            //     invalid_companies = order.order_line.product_id.company_id.filtered(
            //         lambda c: order.company_id not in c._accessible_branches()
            //     )
            //     if invalid_companies:
            //         bad_products = order.order_line.product_id.filtered(
            //             lambda p: p.company_id and p.company_id in invalid_companies
            //         )
            //         raise ValidationError(_(
            //             "Your quotation contains products from company %(product_company)s whereas your quotation belongs to company %(quote_company)s. \n Please change the company of your quotation or remove the products from other companies (%(bad_products)s).",
            //             product_company=', '.join(invalid_companies.sudo().mapped('display_name')),
            //             quote_company=order.company_id.display_name,
            //             bad_products=', '.join(bad_products.mapped('display_name')),
            //         ))
            */
            return default;
        }

        public async Task<TEntity> CheckPrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _check_prepayment_percent(self):
            // for order in self:
            //     if order.require_payment and not (0 < order.prepayment_percent <= 1.0):
            //         raise ValidationError(_("Prepayment percentage must be a valid percentage."))
            */
            return default;
        }

        public async Task<TEntity> CheckTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_total) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> CheckUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _check_unicity(self):
            // """Check that the link trackers are unique."""
            // def _format_value(tracker, field_name):
            //     if field_name == 'label' and not tracker[field_name]:
            //         return False
            //     return tracker[field_name]
            // 
            // # build a query to fetch all needed link trackers at once
            // search_query = expression.OR([
            //     expression.AND([
            //         [('url', '=', tracker.url)],
            //         [('campaign_id', '=', tracker.campaign_id.id)],
            //         [('medium_id', '=', tracker.medium_id.id)],
            //         [('source_id', '=', tracker.source_id.id)],
            //         [('label', '=', tracker.label) if tracker.label else ('label', 'in', (False, ''))],
            //     ])
            //     for tracker in self
            // ])
            // 
            // # Can not be implemented with a SQL constraint because we care about null values.
            // potential_duplicates = self.search(search_query)
            // duplicates = self.browse()
            // seen = set()
            // for tracker in potential_duplicates:
            //     unique_fields = tuple(_format_value(tracker, field_name) for field_name in LINK_TRACKER_UNIQUE_FIELDS)
            //     if unique_fields in seen or seen.add(unique_fields):
            //         duplicates += tracker
            // if duplicates:
            //     error_lines = '\n- '.join(
            //         str((tracker.url, tracker.campaign_id.name, tracker.medium_id.name, tracker.source_id.name, tracker.label or '""'))
            //         for tracker in duplicates
            //     )
            //     raise UserError(
            //         _('Combinations of Link Tracker values (URL, campaign, medium, source, and label) must be unique.\n'
            //           'The following combinations are already used: \n- %(error_lines)s', error_lines=error_lines))
            */
            return default;
        }

        public async Task<TEntity> CleanupWriteOrmValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> CollectTaxCashBasisValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeAbnormalWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeAbsoluteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _compute_absolute_url(self):
            // for tracker in self:
            //     url = urls.url_parse(tracker.url)
            //     if url.scheme:
            //         tracker.absolute_url = tracker.url
            //     else:
            //         tracker.absolute_url = urls.url_join(tracker.get_base_url(), url)
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for order in self:
            //     order.access_url = f'/my/orders/{order.id}'
            */
            return default;
        }

        public async Task<TEntity> ComputeAlwaysTaxExigibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _compute_always_tax_exigible(self):
            // super()._compute_always_tax_exigible()
            // # The pos closing move does not create caba entries (anymore); we set the tax values directly on the closing move.
            // # (But there may still be old closing moves that used caba entries from previous versions.)
            // for move in self:
            //     if move.always_tax_exigible or move.tax_cash_basis_created_move_ids:
            //         continue
            //     if move.pos_session_ids:
            //         move.always_tax_exigible = True
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_amount(self):
            // for move in self:
            //     total_untaxed, total_untaxed_currency = 0.0, 0.0
            //     total_tax, total_tax_currency = 0.0, 0.0
            //     total_residual, total_residual_currency = 0.0, 0.0
            //     total, total_currency = 0.0, 0.0
            // 
            //     for line in move.line_ids:
            //         if move.is_invoice(True):
            //             # === Invoices ===
            //             if line.display_type == 'tax' or (line.display_type == 'rounding' and line.tax_repartition_line_id):
            //                 # Tax amount.
            //                 total_tax += line.balance
            //                 total_tax_currency += line.amount_currency
            //                 total += line.balance
            //                 total_currency += line.amount_currency
            //             elif line.display_type in ('product', 'rounding'):
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
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _compute_amount(self):
            // super()._compute_amount()
            // for move in self:
            //     if move.move_type == 'entry' and move.reversed_pos_order_id:
            //         move.amount_total_signed = move.amount_total_signed * -1
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_invoiced(self):
            // for order in self:
            //     order.amount_invoiced = sum(order.order_line.mapped('amount_invoiced'))
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_paid(self):
            // """ Sum of the amount paid through all transactions for this SO. """
            // for order in self:
            //     order.amount_paid = sum(
            //         tx.amount for tx in order.transaction_ids if tx.state in ('authorized', 'done')
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_to_invoice(self):
            // for order in self:
            //     order.amount_to_invoice = sum(order.order_line.mapped('amount_to_invoice'))
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalWordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_amount_total_words(self):
            // for move in self:
            //     move.amount_total_words = move.currency_id.amount_to_text(move.amount_total).replace(',', '')
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountUndiscountedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_undiscounted(self):
            // for order in self:
            //     total = 0.0
            //     for line in order.order_line:
            //         total += (line.price_subtotal * 100)/(100-line.discount) if line.discount != 100 else (line.price_unit * line.product_uom_qty)
            //     order.amount_undiscounted = total
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amounts(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     order_lines = order.order_line.filtered(lambda x: not x.display_type)
            //     base_lines = [line._prepare_base_line_for_taxes_computation() for line in order_lines]
            //     base_lines += order._add_base_lines_for_early_payment_discount()
            //     AccountTax._add_tax_details_in_base_lines(base_lines, order.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, order.company_id)
            //     tax_totals = AccountTax._get_tax_totals_summary(
            //         base_lines=base_lines,
            //         currency=order.currency_id or order.company_id.currency_id,
            //         company=order.company_id,
            //     )
            //     order.amount_untaxed = tax_totals['base_amount_currency']
            //     order.amount_tax = tax_totals['tax_amount_currency']
            //     order.amount_total = tax_totals['total_amount_currency']
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeAuthorizedTransactionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_authorized_transaction_ids(self):
            // for trans in self:
            //     trans.authorized_transaction_ids = trans.transaction_ids.filtered(lambda t: t.state == 'authorized')
            */
            return default;
        }

        public async Task<TEntity> ComputeAutoPostUntilInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeBankPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeCategIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_categ_ids(self):
            // for applicant in self:
            //     applicant.categ_ids = applicant.candidate_id.categ_ids.ids + applicant.categ_ids.ids
            */
            return default;
        }

        public async Task<TEntity> ComputeCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _compute_code(self):
            // for tracker in self:
            //     record = self.env['link.tracker.code'].search([('link_id', '=', tracker.id)], limit=1, order='id DESC')
            //     tracker.code = record.code
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_commercial_partner_id(self):
            // for move in self:
            //     move.commercial_partner_id = move.partner_id.commercial_partner_id
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _compute_commercial_partner_id(self):
            // own_expense_moves = self.filtered(lambda move: move.sudo().expense_sheet_id.payment_mode == 'own_account')
            // for move in own_expense_moves:
            //     if move.expense_sheet_id.payment_mode == 'own_account':
            //         move.commercial_partner_id = (
            //             move.partner_id.commercial_partner_id
            //             if move.partner_id.commercial_partner_id != move.company_id.partner_id
            //             else move.partner_id
            //         )
            // super(AccountMove, self - own_expense_moves)._compute_commercial_partner_id()
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_currency(self):
            // for lead in self:
            //     if not lead.company_id:
            //         lead.company_currency = self.env.company.currency_id
            //     else:
            //         lead.company_currency = lead.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_id(self):
            // """ Compute company_id coherency. """
            // for lead in self:
            //     proposal = lead.company_id
            // 
            //     # invalidate wrong configuration
            //     if proposal:
            //         # company not in responsible companies
            //         if lead.user_id and proposal not in lead.user_id.company_ids:
            //             proposal = False
            //         # inconsistent
            //         elif lead.team_id.company_id and proposal != lead.team_id.company_id:
            //             proposal = False
            //         # void company on team and no assignee
            //         elif lead.team_id and not lead.team_id.company_id and not lead.user_id:
            //             proposal = False
            //         # no user and no team -> void company and let assignment do its job
            //         # unless customer has a company
            //         elif not lead.team_id and not lead.user_id and \
            //                 (not lead.partner_id or lead.partner_id.company_id != proposal):
            //             proposal = False
            // 
            //     # propose a new company based on team > user (respecting context) > partner
            //     if not proposal:
            //         if lead.team_id.company_id:
            //             lead.company_id = lead.team_id.company_id
            //         elif lead.user_id:
            //             if self.env.company in lead.user_id.company_ids:
            //                 lead.company_id = self.env.company
            //             else:
            //                 lead.company_id = lead.user_id.company_id & self.env.companies
            //         elif lead.partner_id:
            //             lead.company_id = lead.partner_id.company_id
            //         else:
            //             lead.company_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeContactNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_contact_name(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     lead.update(lead._prepare_contact_name_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputeCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _compute_count(self):
            // clicks_data = self.env['link.tracker.click']._read_group(
            //     [('link_id', 'in', self.ids)],
            //     ['link_id'],
            //     ['__count'],
            // )
            // mapped_data = {link.id: count for link, count in clicks_data}
            // for tracker in self:
            //     tracker.count = mapped_data.get(tracker.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_currency_id(self):
            // for order in self:
            //     order.currency_id = order.pricelist_id.currency_id or order.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_currency_rate(self):
            // for order in self:
            //     order.currency_rate = self.env['res.currency']._get_conversion_rate(
            //         from_currency=order.company_id.currency_id,
            //         to_currency=order.currency_id,
            //         company=order.company_id,
            //         date=(order.date_order or fields.Datetime.now()).date(),
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeDateClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_date_closed(self):
            // for applicant in self:
            //     if applicant.stage_id and applicant.stage_id.hired_stage and not applicant.date_closed:
            //         applicant.date_closed = fields.datetime.now()
            //     if not applicant.stage_id.hired_stage:
            //         applicant.date_closed = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_date(self):
            // for move in self:
            //     if not move.invoice_date or not move.is_invoice(include_receipts=True):
            //         if not move.date:
            //             move.date = fields.Date.context_today(self)
            //         continue
            //     accounting_date = move.invoice_date
            //     if not move.is_sale_document(include_receipts=True):
            //         accounting_date = move._get_accounting_date(move.invoice_date, move._affect_tax_report())
            //     if accounting_date and accounting_date != move.date:
            //         move.date = accounting_date
            //         # _affect_tax_report may trigger premature recompute of line_ids.date
            //         self.env.add_to_compute(move.line_ids._fields['date'], move.line_ids)
            //         # might be protected because `_get_accounting_date` requires the `name`
            //         self.env.add_to_compute(self._fields['name'], move)
            */
            return default;
        }

        public async Task<TEntity> ComputeDateLastStageUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_last_stage_update(self):
            // for lead in self:
            //     if not lead.date_last_stage_update:
            //         lead.date_last_stage_update = self.env.cr.now()
            */
            return default;
        }

        public async Task<TEntity> ComputeDateOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_open(self):
            // for lead in self:
            //     if not lead.date_open and lead.user_id:
            //         lead.date_open = self.env.cr.now()
            */
            return default;
        }

        public async Task<TEntity> ComputeDayCloseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_close(self):
            // """ Compute difference between current date and log date """
            // leads = self.filtered(lambda l: l.date_closed and l.create_date)
            // others = self - leads
            // others.day_close = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date)
            //     date_close = fields.Datetime.from_string(lead.date_closed)
            //     lead.day_close = abs((date_close - date_create).days)
            */
            return default;
        }

        public async Task<TEntity> ComputeDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeDayOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_open(self):
            // """ Compute difference between create date and open date """
            // leads = self.filtered(lambda l: l.date_open and l.create_date)
            // others = self - leads
            // others.day_open = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date).replace(microsecond=0)
            //     date_open = fields.Datetime.from_string(lead.date_open)
            //     lead.day_open = abs((date_open - date_create).days)
            */
            return default;
        }

        public async Task<TEntity> ComputeDebitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def _compute_debit_count(self):
            // debit_data = self.env['account.move']._read_group([('debit_origin_id', 'in', self.ids)],
            //                                                 ['debit_origin_id'], ['__count'])
            // data_map = {debit_origin.id: count for debit_origin, count in debit_data}
            // for inv in self:
            //     inv.debit_note_count = data_map.get(inv.id, 0.0)
            */
            return default;
        }

        public async Task<TEntity> ComputeDelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_delivery_date(self):
            // pass
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _compute_delivery_date(self):
            // # EXTENDS 'account'
            // super()._compute_delivery_date()
            // for move in self:
            //     sale_order_effective_date = list(filter(None, move.line_ids.sale_line_ids.order_id.mapped('effective_date')))
            //     effective_date_res = max(sale_order_effective_date) if sale_order_effective_date else False
            //     # if multiple sale order we take the bigger effective_date
            //     if effective_date_res:
            //         move.delivery_date = effective_date_res
            */
            return default;
        }

        public async Task<TEntity> ComputeDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_department(self):
            // for applicant in self:
            //     applicant.department_id = applicant.job_id.department_id.id
            */
            return default;
        }

        public async Task<TEntity> ComputeDirectionSignInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeDisplayInactiveCurrencyWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_inactive_currency_warning(self):
            // for move in self.with_context(active_test=False):
            //     move.display_inactive_currency_warning = move.state == 'draft' and move.currency_id and not move.currency_id.active
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_display_name(self):
            // if not self.env.context.get('show_partner_name'):
            //     return super()._compute_display_name()
            // for applicant in self:
            //     applicant.display_name = applicant.partner_name or applicant.name
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_display_name(self):
            // if not self._context.get('sale_show_partner_name'):
            //     return super()._compute_display_name()
            // for order in self:
            //     name = order.name
            //     if order.partner_id.name:
            //         name = f'{name} - {order.partner_id.name}'
            //     order.display_name = name
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeDuplicatedOrderIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_duplicated_order_ids(self):
            // order_to_duplicate_orders = self._fetch_duplicate_orders()
            // for order in self:
            //     order.duplicated_order_ids = [Command.set(order_to_duplicate_orders.get(order.id, []))]
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedRefIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeEdiErrorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_error_count(self):
            // for move in self:
            //     move.edi_error_count = len(move.edi_document_ids.filtered(lambda d: d.error))
            */
            return default;
        }

        public async Task<TEntity> ComputeEdiErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_error_message(self):
            // for move in self:
            //     if move.edi_error_count == 0:
            //         move.edi_error_message = None
            //         move.edi_blocking_level = None
            //     elif move.edi_error_count == 1:
            //         error_doc = move.edi_document_ids.filtered(lambda d: d.error)
            //         move.edi_error_message = error_doc.error
            //         move.edi_blocking_level = error_doc.blocking_level
            //     else:
            //         error_levels = set([doc.blocking_level for doc in move.edi_document_ids])
            //         count = str(move.edi_error_count)
            //         if 'error' in error_levels:
            //             move.edi_error_message = _("%(count)s Electronic invoicing error(s)", count=count)
            //             move.edi_blocking_level = 'error'
            //         elif 'warning' in error_levels:
            //             move.edi_error_message = _("%(count)s Electronic invoicing warning(s)", count=count)
            //             move.edi_blocking_level = 'warning'
            //         else:
            //             move.edi_error_message = _("%(count)s Electronic invoicing info(s)", count=count)
            //             move.edi_blocking_level = 'info'
            */
            return default;
        }

        public async Task<TEntity> ComputeEdiShowAbandonCancelButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_show_abandon_cancel_button(self):
            // for move in self:
            //     move.edi_show_abandon_cancel_button = False
            //     for doc in move.sudo().edi_document_ids:
            //         move_applicability = doc.edi_format_id._get_move_applicability(move)
            //         if doc.edi_format_id._needs_web_services() \
            //             and doc.state == 'to_cancel' \
            //             and move_applicability \
            //             and move_applicability.get('cancel'):
            //             move.edi_show_abandon_cancel_button = True
            //             break
            */
            return default;
        }

        public async Task<TEntity> ComputeEdiShowCancelButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_show_cancel_button(self):
            // for move in self:
            //     if move.state != 'posted':
            //         move.edi_show_cancel_button = False
            //         continue
            // 
            //     move.edi_show_cancel_button = False
            //     for doc in move.edi_document_ids:
            //         move_applicability = doc.edi_format_id._get_move_applicability(move)
            //         if doc.edi_format_id._needs_web_services() \
            //             and doc.state == 'sent' \
            //             and move_applicability \
            //             and move_applicability.get('cancel'):
            //             move.edi_show_cancel_button = True
            //             break
            */
            return default;
        }

        public async Task<TEntity> ComputeEdiShowForceCancelButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_show_force_cancel_button(self):
            // for move in self:
            //     move.edi_show_force_cancel_button = move._can_force_cancel()
            */
            return default;
        }

        public async Task<TEntity> ComputeEdiStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_state(self):
            // for move in self:
            //     all_states = set(move.edi_document_ids.filtered(lambda d: d.edi_format_id._needs_web_services()).mapped('state'))
            //     if all_states == {'sent'}:
            //         move.edi_state = 'sent'
            //     elif all_states == {'cancelled'}:
            //         move.edi_state = 'cancelled'
            //     elif 'to_send' in all_states:
            //         move.edi_state = 'to_send'
            //     elif 'to_cancel' in all_states:
            //         move.edi_state = 'to_cancel'
            //     else:
            //         move.edi_state = False
            */
            return default;
        }

        public async Task<TEntity> ComputeEdiWebServicesToProcessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_edi_web_services_to_process(self):
            // for move in self:
            //     to_process = move.edi_document_ids.filtered(lambda d: d.state in ['to_send', 'to_cancel'] and d.blocking_level != 'error')
            //     format_web_services = to_process.edi_format_id.filtered(lambda f: f._needs_web_services())
            //     move.edi_web_services_to_process = ', '.join(f.name for f in format_web_services)
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailDomainCriterionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_domain_criterion(self):
            // self.email_domain_criterion = False
            // for lead in self.filtered('email_normalized'):
            //     lead.email_domain_criterion = iap_tools.mail_prepare_for_domain_search(
            //         lead.email_normalized
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_from(self):
            // for lead in self:
            //     if lead.partner_id.email and lead._get_partner_email_update():
            //         lead.email_from = lead.partner_id.email
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_state(self):
            // for lead in self:
            //     email_state = False
            //     if lead.email_from:
            //         email_state = 'incorrect'
            //         for email in email_split(lead.email_from):
            //             if mail_validation.mail_validate(email):
            //                 email_state = 'correct'
            //                 break
            //     lead.email_state = email_state
            */
            return default;
        }

        public async Task<TEntity> ComputeExpectedCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_expected_date(self):
            // """ For service and consumable, we only take the min dates. This method is extended in sale_stock to
            //     take the picking_policy of SO into account.
            // """
            // self.mapped("order_line")  # Prefetch indication
            // for order in self:
            //     if order.state == 'cancel':
            //         order.expected_date = False
            //         continue
            //     dates_list = order.order_line.filtered(
            //         lambda line: not line.display_type and not line._is_delivery()
            //     ).mapped(lambda line: line and line._expected_date())
            //     if dates_list:
            //         order.expected_date = order._select_expected_date(dates_list)
            //     else:
            //         order.expected_date = False
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_field_value(self, field):
            // if field.name != 'invoice_status' or self.env.context.get('mail_activity_automation_skip'):
            //     return super()._compute_field_value(field)
            // 
            // filtered_self = self.filtered(
            //     lambda so: so.ids
            //         and (so.user_id or so.partner_id.user_id)
            //         and so._origin.invoice_status != 'upselling')
            // super()._compute_field_value(field)
            // 
            // upselling_orders = filtered_self.filtered(lambda so: so.invoice_status == 'upselling')
            // upselling_orders._create_upsell_activity()
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_fiscal_position_id(self):
            // """
            // Trigger the change of fiscal position when the shipping address is modified.
            // """
            // cache = {}
            // for order in self:
            //     if not order.partner_id:
            //         order.fiscal_position_id = False
            //         continue
            //     fpos_id_before = order.fiscal_position_id.id
            //     key = (order.company_id.id, order.partner_id.id, order.partner_shipping_id.id)
            //     if key not in cache:
            //         cache[key] = self.env['account.fiscal.position'].with_company(
            //             order.company_id
            //         )._get_fiscal_position(order.partner_id, order.partner_shipping_id).id
            //     if fpos_id_before != cache[key] and order.order_line:
            //         order.show_update_fpos = True
            //     order.fiscal_position_id = cache[key]
            */
            return default;
        }

        public async Task<TEntity> ComputeFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_function(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.function or lead.partner_id.function:
            //         lead.function = lead.partner_id.function
            */
            return default;
        }

        public async Task<TEntity> ComputeHasActivePricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_has_active_pricelist(self):
            // for order in self:
            //     order.has_active_pricelist = bool(self.env['product.pricelist'].search(
            //         [('company_id', 'in', (False, order.company_id.id)), ('active', '=', True)],
            //         limit=1,
            //     ))
            */
            return default;
        }

        public async Task<TEntity> ComputeHasArchivedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_has_archived_products(self):
            // for order in self:
            //     order.has_archived_products = any(
            //         not product.active for product in order.order_line.product_id
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeHasReconciledEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_has_reconciled_entries(self):
            // for move in self:
            //     move.has_reconciled_entries = len(move.line_ids._reconciled_lines()) > 1
            */
            return default;
        }

        public async Task<TEntity> ComputeHidePostButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeHighestNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_highest_name(self):
            // for record in self:
            //     record.highest_name = record._get_last_sequence()
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_incoterm_location(self):
            // pass
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py) ---
            // def _compute_incoterm_location(self):
            // super()._compute_incoterm_location()
            // for move in self:
            //     purchase_locations = move.line_ids.purchase_line_id.order_id.mapped('incoterm_location')
            //     incoterm_res = next((incoterm for incoterm in purchase_locations if incoterm), False)
            //     # if multiple purchase order we take an incoterm that is not false
            //     if incoterm_res:
            //         move.incoterm_location = incoterm_res
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _compute_incoterm_location(self):
            // super()._compute_incoterm_location()
            // for move in self:
            //     sale_locations = move.line_ids.sale_line_ids.order_id.mapped('incoterm_location')
            //     incoterm_res = next((incoterm for incoterm in sale_locations if incoterm), False)
            //     # if multiple purchase order we take an incoterm that is not false
            //     if incoterm_res:
            //         move.incoterm_location = incoterm_res
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeInvoiceDateDueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeInvoiceDefaultSalePersonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_filter_type_domain(self):
            // for move in self:
            //     if move.is_sale_document(include_receipts=True):
            //         move.invoice_filter_type_domain = 'sale'
            //     elif move.is_purchase_document(include_receipts=True):
            //         move.invoice_filter_type_domain = 'purchase'
            //     else:
            //         move.invoice_filter_type_domain = False
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePartnerDisplayInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeInvoiceStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_invoice_status(self):
            // """
            // Compute the invoice status of a SO. Possible statuses:
            // - no: if the SO is not in status 'sale' or 'done', we consider that there is nothing to
            //   invoice. This is also the default value if the conditions of no other status is met.
            // - to invoice: if any SO line is 'to invoice', the whole SO is 'to invoice'
            // - invoiced: if all SO lines are invoiced, the SO is invoiced.
            // - upselling: if all SO lines are invoiced or upselling, the status is upselling.
            // """
            // confirmed_orders = self.filtered(lambda so: so.state == 'sale')
            // (self - confirmed_orders).invoice_status = 'no'
            // if not confirmed_orders:
            //     return
            // lines_domain = [('is_downpayment', '=', False), ('display_type', '=', False)]
            // line_invoice_status_all = [
            //     (order.id, invoice_status)
            //     for order, invoice_status in self.env['sale.order.line']._read_group(
            //         lines_domain + [('order_id', 'in', confirmed_orders.ids)],
            //         ['order_id', 'invoice_status']
            //     )
            // ]
            // for order in confirmed_orders:
            //     line_invoice_status = [d[1] for d in line_invoice_status_all if d[0] == order.id]
            //     if order.state != 'sale':
            //         order.invoice_status = 'no'
            //     elif any(invoice_status == 'to invoice' for invoice_status in line_invoice_status):
            //         if any(invoice_status == 'no' for invoice_status in line_invoice_status):
            //             # If only discount/delivery/promotion lines can be invoiced, the SO should not
            //             # be invoiceable.
            //             invoiceable_domain = lines_domain + [('invoice_status', '=', 'to invoice')]
            //             invoiceable_lines = order.order_line.filtered_domain(invoiceable_domain)
            //             special_lines = invoiceable_lines.filtered(
            //                 lambda sol: not sol._can_be_invoiced_alone()
            //             )
            //             if invoiceable_lines == special_lines:
            //                 order.invoice_status = 'no'
            //             else:
            //                 order.invoice_status = 'to invoice'
            //         else:
            //             order.invoice_status = 'to invoice'
            //     elif line_invoice_status and all(invoice_status == 'invoiced' for invoice_status in line_invoice_status):
            //         order.invoice_status = 'invoiced'
            //     elif line_invoice_status and all(invoice_status in ('invoiced', 'upselling') for invoice_status in line_invoice_status):
            //         order.invoice_status = 'upselling'
            //     else:
            //         order.invoice_status = 'no'
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAutomatedProbabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_automated_probability(self):
            // """ If probability and automated_probability are equal probability computation
            // is considered as automatic, aka probability is sync with automated_probability """
            // for lead in self:
            //     lead.is_automated_probability = tools.float_compare(lead.probability, lead.automated_probability, 2) == 0
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBeingSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_being_sent(self):
            // for move in self:
            //     move.is_being_sent = bool(move.sending_data)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsExpiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_is_expired(self):
            // today = fields.Date.today()
            // for order in self:
            //     order.is_expired = (
            //         order.state in ('draft', 'sent')
            //         and order.validity_date
            //         and order.validity_date < today
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPartnerVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_partner_visible(self):
            // """ When the crm.lead is of type 'lead', we don't want to display the "Customer" field on the form view
            // unless it's set (or debug mode).
            // 
            // Indeed, most of the times leads will not have this information set, since when we assign a Customer we
            // usually convert the lead to an opportunity as well.
            // 
            // This means that on the lead form, we don't want to display this field since it may be misleading for the
            // end user.
            // When it's set however, we want to display it, mainly because there are a few automatic synchronizations between
            // the lead and its partner (phone and email for examples), and this needs to be clear that modifying
            // one of those fields will in turn modify the linked partner."""
            // is_debug_mode = self.env.user.has_group('base.group_no_one')
            // for lead in self:
            //     lead.is_partner_visible = bool(lead.type == 'opportunity' or lead.partner_id or is_debug_mode)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPurchaseMatchedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _compute_is_purchase_matched(self):
            // for move in self:
            //     if any(il.display_type == 'product' and not bool(il.purchase_line_id) for il in move.invoice_line_ids):
            //         move.is_purchase_matched = False
            //         continue
            //     move.is_purchase_matched = True
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_storno(self):
            // for move in self:
            //     move.is_storno = move.is_storno or (move.move_type in ('out_refund', 'in_refund') and move.company_id.account_storno)
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_journal_id(self):
            // self.journal_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeLandedCostsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py) ---
            // def _compute_landed_costs_visible(self):
            // for account_move in self:
            //     if account_move.landed_costs_ids:
            //         account_move.landed_costs_visible = False
            //     else:
            //         account_move.landed_costs_visible = any(line.is_landed_costs_line for line in account_move.line_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeLangActiveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_active_count(self):
            // self.lang_active_count = len(self.env['res.lang'].get_installed())
            */
            return default;
        }

        public async Task<TEntity> ComputeLangIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_id(self):
            // """ compute the lang based on partner, erase any value to force the partner
            // one if set. """
            // # prepare cache
            // lang_codes = [code for code in self.mapped('partner_id.lang') if code]
            // if lang_codes:
            //     lang_id_by_code = dict(
            //         (code, self.env['res.lang']._get_data(code=code).id)
            //         for code in lang_codes
            //     )
            // else:
            //     lang_id_by_code = {}
            // for lead in self.filtered('partner_id'):
            //     lead.lang_id = lang_id_by_code.get(lead.partner_id.lang, False)
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkedAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment_field, object binary_field) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeMeetingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_meeting_display(self):
            // now = fields.Datetime.now()
            // meeting_data = self.env['calendar.event'].sudo()._read_group([
            //     ('opportunity_id', 'in', self.ids),
            // ], ['opportunity_id'], ['start:array_agg', 'start:max'])
            // mapped_data = {
            //     lead: {
            //         'last_meeting_date': last_meeting_date,
            //         'next_meeting_date': min([dt for dt in meeting_start_dates if dt > now] or [False]),
            //     } for lead, meeting_start_dates, last_meeting_date in meeting_data
            // }
            // for lead in self:
            //     lead_meeting_info = mapped_data.get(lead)
            //     if not lead_meeting_info:
            //         lead.meeting_display_date = False
            //         lead.meeting_display_label = _('No Meeting')
            //     elif lead_meeting_info['next_meeting_date']:
            //         lead.meeting_display_date = lead_meeting_info['next_meeting_date']
            //         lead.meeting_display_label = _('Next Meeting')
            //     else:
            //         lead.meeting_display_date = lead_meeting_info['last_meeting_date']
            //         lead.meeting_display_label = _('Last Meeting')
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

        public async Task<TEntity> ComputeMobileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_mobile(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.mobile or lead.partner_id.mobile:
            //         lead.mobile = lead.partner_id.mobile
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveSentValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def compute_move_sent_values(self):
            // for move in self:
            //     move.move_sent_values = 'sent' if move.is_move_sent else 'not_sent'
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_name(self):
            // for lead in self:
            //     if not lead.name and lead.partner_id and lead.partner_id.name:
            //         lead.name = _("%s's opportunity") % lead.partner_id.name
            */
            return default;
        }

        public async Task<TEntity> ComputeNamePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeNarrationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeNeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_need_cancel_request(self):
            // for move in self:
            //     move.need_cancel_request = move._need_cancel_request()
            */
            return default;
        }

        public async Task<TEntity> ComputeNeededTermsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //                 for base_line, to_update in tax_results['base_lines_to_update']:
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
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _compute_needed_terms(self):
            // # EXTENDS account
            // # We want to set the account destination based on the 'payment_mode'.
            // super()._compute_needed_terms()
            // for move in self:
            //     if move.expense_sheet_id and move.expense_sheet_id.payment_mode == 'company_account':
            //         term_lines = move.line_ids.filtered(lambda l: l.display_type != 'payment_term')
            //         move.needed_terms = {
            //             frozendict(
            //                 {
            //                     "move_id": move.id,
            //                     "date_maturity": move.expense_sheet_id.accounting_date or fields.Date.context_today(move.expense_sheet_id),
            //                 }
            //             ): {
            //                 "balance": -sum(term_lines.mapped("balance")),
            //                 "amount_currency": -sum(term_lines.mapped("amount_currency")),
            //                 "name": "",
            //                 "account_id": move.expense_sheet_id._get_expense_account_destination(),
            //             }
            //         }
            */
            return default;
        }

        public async Task<TEntity> ComputeNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_next_payment_date(self):
            // for move in self:
            //     move.next_payment_date = min([line.payment_date for line in move.line_ids.filtered(lambda l: l.payment_date and not l.reconciled)], default=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_note(self):
            // use_invoice_terms = self.env['ir.config_parameter'].sudo().get_param('account.use_invoice_terms')
            // if not use_invoice_terms:
            //     return
            // for order in self:
            //     order = order.with_company(order.company_id)
            //     if order.terms_type == 'html' and self.env.company.invoice_terms_html:
            //         baseurl = html_keep_url(order._get_note_url() + '/terms')
            //         context = {'lang': order.partner_id.lang or self.env.user.lang}
            //         order.note = _('Terms & Conditions: %s', baseurl)
            //         del context
            //     elif not is_html_empty(self.env.company.invoice_terms):
            //         if order.partner_id.lang:
            //             order = order.with_context(lang=order.partner_id.lang)
            //         order.note = order.env.company.invoice_terms
            */
            return default;
        }

        public async Task<TEntity> ComputeOriginPoCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _compute_origin_po_count(self):
            // for move in self:
            //     move.purchase_order_count = len(move.line_ids.purchase_line_id.order_id)
            */
            return default;
        }

        public async Task<TEntity> ComputeOriginSoCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _compute_origin_so_count(self):
            // for move in self:
            //     move.sale_order_count = len(move.line_ids.sale_line_ids.order_id)
            */
            return default;
        }

        public async Task<TEntity> ComputeOtherApplicationsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_other_applications_count(self):
            // for applicant in self:
            //     same_candidate_applications = max(len(applicant.with_context(active_test=False).candidate_id.applicant_ids) - 1, 0)
            //     if applicant.candidate_id:
            //         domain = applicant.candidate_id._get_similar_candidates_domain()
            //         similar_candidates = self.env['hr.candidate'].with_context(active_test=False).search(domain) - applicant.candidate_id
            //         similar_candidate_applications = sum(len(candidate.applicant_ids) for candidate in similar_candidates)
            //         applicant.other_applications_count = similar_candidate_applications + same_candidate_applications
            //     else:
            //         applicant.other_applications_count = same_candidate_applications
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_address_values(self):
            // """ Sync all or none of address fields """
            // for lead in self:
            //     lead.update(lead._prepare_address_values_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_partner_bank_id(self):
            // for move in self:
            //     # This will get the bank account from the partner in an order with the trusted first
            //     bank_ids = move.bank_partner_id.bank_ids.filtered(
            //         lambda bank: not bank.company_id or bank.company_id == move.company_id
            //     ).sorted(lambda bank: not bank.allow_out_payment)
            //     move.partner_bank_id = bank_ids[:1]
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCreditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _compute_partner_credit(self):
            // super()._compute_partner_credit()
            // for move in self.filtered(lambda m: m.is_invoice(include_receipts=True)):
            //     sale_orders = move.line_ids.sale_line_ids.order_id
            //     amount_total_currency = move.tax_totals['total_amount_currency']
            //     amount_to_invoice_currency = sum(
            //         sale_order.currency_id._convert(
            //             sale_order.amount_to_invoice,
            //             move.company_currency_id,
            //             move.company_id,
            //             move.date
            //         ) for sale_order in sale_orders
            //     )
            //     move.partner_credit += max(amount_total_currency - amount_to_invoice_currency, 0.0)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCreditWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_partner_credit_warning(self):
            // for order in self:
            //     order.with_company(order.company_id)
            //     order.partner_credit_warning = ''
            //     show_warning = order.state in ('draft', 'sent') and \
            //                    order.company_id.account_use_credit_limit
            //     if show_warning:
            //         order.partner_credit_warning = self.env['account.move']._build_credit_warning_message(
            //             order.sudo(),  # ensure access to `credit` & `credit_limit` fields
            //             current_amount=(order.amount_total / order.currency_rate),
            //         )
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_email_update(self):
            // for lead in self:
            //     lead.partner_email_update = lead._get_partner_email_update(force_void=False)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerInvoiceIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_partner_invoice_id(self):
            // for order in self:
            //     order.partner_invoice_id = order.partner_id.address_get(['invoice'])['invoice'] if order.partner_id else False
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_name(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     lead.update(lead._prepare_partner_name_from_partner(lead.partner_id))
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_partner_name(self):
            // for applicant in self:
            //     applicant.partner_name = applicant.candidate_id.partner_name
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_phone_update(self):
            // for lead in self:
            //     lead.partner_phone_update = lead._get_partner_phone_update(force_void=False)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShippingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_partner_shipping_id(self):
            // for order in self:
            //     order.partner_shipping_id = order.partner_id.address_get(['delivery'])['delivery'] if order.partner_id else False
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_count(self):
            // for invoice in self:
            //     invoice.payment_count = len(invoice.matched_payment_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputePaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_state(self):
            // groups = self.grouped(lambda move:
            //     'legacy' if move.payment_state == 'invoicing_legacy' else
            //     'posted_invoice' if move.state == 'posted' and move.is_invoice(True) else
            //     'blocked' if move.payment_state == 'blocked' else
            //     'unpaid'
            // )
            // groups.get('unpaid', self.browse()).payment_state = 'not_paid'
            // posted_invoices = groups.get('posted_invoice', self.browse())
            // 
            // stored_ids = tuple(posted_invoices.ids)
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
            // for invoice in posted_invoices:
            //     currencies = invoice._get_lines_onchange_currency().currency_id
            //     currency = currencies if len(currencies) == 1 else invoice.company_id.currency_id
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
            //     elif invoice.matched_payment_ids.filtered(lambda p: not p.move_id and p.state == 'in_process'):
            //         new_pmt_state = invoice._get_invoice_in_payment_state()
            //     elif reconciliation_vals:
            //         new_pmt_state = 'partial'
            //     elif invoice.matched_payment_ids.filtered(lambda p: not p.move_id and p.state == 'paid'):
            //         new_pmt_state = invoice._get_invoice_in_payment_state()
            //     invoice.payment_state = new_pmt_state
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_payment_term_id(self):
            // for order in self:
            //     order = order.with_company(order.company_id)
            //     order.payment_term_id = order.partner_id.property_payment_term_id
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetReconciledInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payments_widget_reconciled_info(self):
            // for move in self:
            //     payments_widget_vals = {'title': _('Less Payment'), 'outstanding': False, 'content': []}
            // 
            //     if move.state == 'posted' and move.is_invoice(include_receipts=True):
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
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _compute_payments_widget_reconciled_info(self):
            // """Add pos_payment_name field in the reconciled vals to be able to show the payment method in the invoice."""
            // super()._compute_payments_widget_reconciled_info()
            // for move in self:
            //     if move.invoice_payments_widget:
            //         if move.state == 'posted' and move.is_invoice(include_receipts=True):
            //             reconciled_partials = move._get_all_reconciled_invoice_partials()
            //             for i, reconciled_partial in enumerate(reconciled_partials):
            //                 counterpart_line = reconciled_partial['aml']
            //                 pos_payment = counterpart_line.move_id.sudo().pos_payment_ids[:1]
            //                 move.invoice_payments_widget['content'][i].update({
            //                     'pos_payment_name': pos_payment.payment_method_id.name,
            //                 })
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetToReconcileInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payments_widget_to_reconcile_info(self):
            // for move in self:
            //     move.invoice_outstanding_credits_debits_widget = False
            //     move.invoice_has_outstanding = False
            // 
            //     if move.state != 'posted' \
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
            //         '|', ('amount_residual', '!=', 0.0), ('amount_residual_currency', '!=', 0.0),
            //     ]
            // 
            //     payments_widget_vals = {'outstanding': True, 'content': [], 'move_id': move.id}
            // 
            //     if move.is_inbound():
            //         domain.append(('balance', '<', 0.0))
            //         payments_widget_vals['title'] = _('Outstanding credits')
            //     else:
            //         domain.append(('balance', '>', 0.0))
            //         payments_widget_vals['title'] = _('Outstanding debits')
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
            //     if not payments_widget_vals['content']:
            //         continue
            // 
            //     move.invoice_outstanding_credits_debits_widget = payments_widget_vals
            //     move.invoice_has_outstanding = True
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolMoveStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py) ---
            // def _compute_peppol_move_state(self):
            // can_send = self.env['account_edi_proxy_client.user']._get_can_send_domain()
            // for move in self:
            //     if all([
            //         move.company_id.account_peppol_proxy_state in can_send,
            //         move.commercial_partner_id.peppol_verification_state == 'valid',
            //         move.state == 'posted',
            //         move.is_sale_document(include_receipts=True),
            //         not move.peppol_move_state,
            //     ]):
            //         move.peppol_move_state = 'ready'
            //     elif (
            //         move.state == 'draft'
            //         and move.is_sale_document(include_receipts=True)
            //         and move.peppol_move_state not in ('processing', 'done')
            //     ):
            //         move.peppol_move_state = False
            //     else:
            //         move.peppol_move_state = move.peppol_move_state
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone(self):
            // for lead in self:
            //     if lead.partner_id.phone and lead._get_partner_phone_update():
            //         lead.phone = lead.partner_id.phone
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone_state(self):
            // for lead in self:
            //     phone_status = False
            //     if lead.phone:
            //         country_code = lead.country_id.code if lead.country_id and lead.country_id.code else None
            //         try:
            //             if phone_validation.phone_parse(lead.phone, country_code):  # otherwise library not installed
            //                 phone_status = 'correct'
            //         except UserError:
            //             phone_status = 'incorrect'
            //     lead.phone_state = phone_status
            */
            return default;
        }

        public async Task<TEntity> ComputePotentialLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_potential_lead_duplicates(self):
            // """ Override potential lead duplicates computation to be more efficient
            // with high lead volume.
            // Criterions:
            //   * email domain exact match;
            //   * phone_sanitized exact match;
            //   * same commercial entity;
            // """
            // SEARCH_RESULT_LIMIT = 21
            // 
            // def return_if_relevant(model_name, domain):
            //     """ Returns the recordset obtained by performing a search on the provided
            //     model with the provided domain if the cardinality of that recordset is
            //     below a given threshold (i.e: `SEARCH_RESULT_LIMIT`). Otherwise, returns
            //     an empty recordset of the provided model as it indicates search term
            //     was not relevant.
            //     Note: The function will use the administrator privileges to guarantee
            //     that a maximum amount of leads will be included in the search results
            //     and transcend multi-company record rules. It also includes archived
            //     records. Idea is that counter indicates duplicates are present and
            //     the lead could be escalated to managers.
            //     """
            //     model = self.env[model_name].sudo().with_context(active_test=False)
            //     res = model.search(domain, limit=SEARCH_RESULT_LIMIT)
            //     return res if len(res) < SEARCH_RESULT_LIMIT else model
            // 
            // for lead in self:
            //     lead_id = lead._origin.id if isinstance(lead.id, models.NewId) else lead.id
            //     common_lead_domain = [
            //         ('id', '!=', lead_id)
            //     ]
            // 
            //     duplicate_lead_ids = self.env['crm.lead']
            // 
            //     # check the "company" email domain duplicates
            //     if lead.email_domain_criterion:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('email_domain_criterion', '=', lead.email_domain_criterion)
            //         ])
            //     # check for "same commercial entity" duplicates
            //     if lead.partner_id and lead.partner_id.commercial_partner_id:
            //         duplicate_lead_ids |= lead.with_context(active_test=False).search(common_lead_domain + [
            //             ("partner_id", "child_of", lead.partner_id.commercial_partner_id.ids)
            //         ])
            //     # check the phone number duplicates, based on phone_sanitized. Only
            //     # exact matches are found, and the single one stored in phone_sanitized
            //     # in case phone and mobile are both set.
            //     if lead.phone_sanitized:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('phone_sanitized', '=', lead.phone_sanitized)
            //         ])
            // 
            //     lead.duplicate_lead_ids = duplicate_lead_ids + lead
            //     lead.duplicate_lead_count = len(duplicate_lead_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePreferredPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_prepayment_percent(self):
            // for order in self:
            //     order.prepayment_percent = order.company_id.prepayment_percent
            */
            return default;
        }

        public async Task<TEntity> ComputePricelistIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_pricelist_id(self):
            // for order in self:
            //     if order.state != 'draft':
            //         continue
            //     if not order.partner_id:
            //         order.pricelist_id = False
            //         continue
            //     order = order.with_company(order.company_id)
            //     order.pricelist_id = order.partner_id.property_product_pricelist
            */
            return default;
        }

        public async Task<TEntity> ComputeProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_probabilities(self):
            // lead_probabilities = self._pls_get_naive_bayes_probabilities()
            // for lead in self:
            //     if lead.id in lead_probabilities:
            //         was_automated = lead.active and lead.is_automated_probability
            //         lead.automated_probability = lead_probabilities[lead.id]
            //         if was_automated:
            //             lead.probability = lead.automated_probability
            */
            return default;
        }

        public async Task<TEntity> ComputeProratedRevenueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_prorated_revenue(self):
            // for lead in self:
            //     lead.prorated_revenue = round((lead.expected_revenue or 0.0) * (lead.probability or 0) / 100.0, 2)
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOrderNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _compute_purchase_order_name(self):
            // for move in self:
            //     if move.purchase_order_count == 1:
            //         move.purchase_order_name = move.invoice_line_ids.purchase_order_id.display_name
            //     else:
            //         move.purchase_order_name = False
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEditModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeQuickEncodingValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_quick_encoding_vals(self):
            // for move in self:
            //     move.quick_encoding_vals = move._get_quick_edit_suggestions()
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly = (lead.recurring_revenue or 0.0) / (lead.recurring_plan.number_of_months or 1)
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly_prorated = (lead.recurring_revenue_monthly or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_prorated = (lead.recurring_revenue or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        public async Task<TEntity> ComputeRedirectedUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _compute_redirected_url(self):
            // """Compute the URL to which we will redirect the user.
            // 
            // By default, add UTM values as GET parameters. But if the system parameter
            // `link_tracker.no_external_tracking` is set, we add the UTM values in the URL
            // *only* for URLs that redirect to the local website (base URL).
            // """
            // no_external_tracking = self.env['ir.config_parameter'].sudo().get_param('link_tracker.no_external_tracking')
            // 
            // for tracker in self:
            //     base_domain = urls.url_parse(tracker.get_base_url()).netloc
            //     parsed = urls.url_parse(tracker.url)
            //     if no_external_tracking and parsed.netloc and parsed.netloc != base_domain:
            //         tracker.redirected_url = parsed.to_url()
            //         continue
            // 
            //     query = parsed.decode_query()
            //     for key, field_name, cook in self.env['utm.mixin'].tracking_fields():
            //         field = self._fields[field_name]
            //         attr = tracker[field_name]
            //         if field.type == 'many2one':
            //             attr = attr.name
            //         if attr:
            //             query[key] = attr
            //     tracker.redirected_url = parsed.replace(query=urls.url_encode(query)).to_url()
            */
            return default;
        }

        public async Task<TEntity> ComputeRequirePaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_require_payment(self):
            // for order in self:
            //     order.require_payment = order.company_id.portal_confirmation_pay
            */
            return default;
        }

        public async Task<TEntity> ComputeRequireSignatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_require_signature(self):
            // for order in self:
            //     order.require_signature = order.company_id.portal_confirmation_sign
            */
            return default;
        }

        public async Task<TEntity> ComputeSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_secured(self):
            // for move in self:
            //     move.secured = bool(move.inalterable_hash)
            */
            return default;
        }

        public async Task<TEntity> ComputeShortUrlHostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _compute_short_url_host(self):
            // for tracker in self:
            //     tracker.short_url_host = tracker.get_base_url() + '/r/'
            */
            return default;
        }

        public async Task<TEntity> ComputeShortUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _compute_short_url(self):
            // for tracker in self:
            //     tracker.short_url = urls.url_join(tracker.short_url_host or '', tracker.code or '')
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCommercialPartnerWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _compute_show_commercial_partner_warning(self):
            // for move in self:
            //     move.show_commercial_partner_warning = (
            //             move.commercial_partner_id == self.env.company.partner_id
            //             and move.move_type == 'in_invoice'
            //             and move.partner_id.sudo().employee_ids
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeShowDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_delivery_date(self):
            // for move in self:
            //     move.show_delivery_date = move.delivery_date and move.is_sale_document()
            */
            return default;
        }

        public async Task<TEntity> ComputeShowPaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //     if invoice.move_type in ('out_invoice', 'out_receipt', 'in_invoice', 'in_receipt') and invoice.payment_state in ('not_paid', 'partial'):
            //         payment_term_lines = invoice.line_ids.filtered(lambda l: l.display_type == 'payment_term')
            //         invoice.show_discount_details = invoice.invoice_payment_term_id.early_discount
            //         invoice.show_payment_term_details = len(payment_term_lines) > 1 or invoice.show_discount_details
            //     else:
            //         invoice.show_discount_details = False
            //         invoice.show_payment_term_details = False
            */
            return default;
        }

        public async Task<TEntity> ComputeShowResetToDraftButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _compute_show_reset_to_draft_button(self):
            // # OVERRIDE
            // super()._compute_show_reset_to_draft_button()
            // for move in self:
            //     if not move._check_edi_documents_for_reset_to_draft():
            //         move.show_reset_to_draft_button = False
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _compute_show_reset_to_draft_button(self):
            // super()._compute_show_reset_to_draft_button()
            // for move in self:
            //     if move.sudo().line_ids.stock_valuation_layer_ids:
            //         move.show_reset_to_draft_button = False
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_stage_id(self):
            // for lead in self:
            //     if not lead.stage_id:
            //         lead.stage_id = lead._stage_find(domain=[('fold', '=', False)]).id
            */
            return default;
        }

        public async Task<TEntity> ComputeStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeStatusInPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_status_in_payment(self):
            // for move in self:
            //     move.status_in_payment = move.state if move.state in ('draft', 'cancel') else move.payment_state
            */
            return default;
        }

        public async Task<TEntity> ComputeSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_suitable_journal_ids(self):
            // for m in self:
            //     journal_type = m.invoice_filter_type_domain or 'general'
            //     company = m.company_id or self.env.company
            //     m.suitable_journal_ids = self.env['account.journal'].search([
            //         *self.env['account.journal']._check_company_domain(company),
            //         ('type', '=', journal_type),
            //     ])
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_country_code(self):
            // for record in self:
            //     record.tax_country_code = record.tax_country_id.code
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_tax_country_id(self):
            // for record in self:
            //     if record.fiscal_position_id.foreign_vat:
            //         record.tax_country_id = record.fiscal_position_id.country_id
            //     else:
            //         record.tax_country_id = record.company_id.account_fiscal_country_id
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_tax_totals(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     order_lines = order.order_line.filtered(lambda x: not x.display_type)
            //     base_lines = [line._prepare_base_line_for_taxes_computation() for line in order_lines]
            //     base_lines += order._add_base_lines_for_early_payment_discount()
            //     AccountTax._add_tax_details_in_base_lines(base_lines, order.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, order.company_id)
            //     order.tax_totals = AccountTax._get_tax_totals_summary(
            //         base_lines=base_lines,
            //         currency=order.currency_id or order.company_id.currency_id,
            //         company=order.company_id,
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxesLegalNotesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_team_id(self):
            // """ When changing the user, also set a team_id or restrict team id
            // to the ones user_id is member of. """
            // for lead in self:
            //     # setting user as void should not trigger a new team computation
            //     if not lead.user_id:
            //         continue
            //     user = lead.user_id
            //     if lead.team_id and user in (lead.team_id.member_ids | lead.team_id.user_id):
            //         continue
            //     team_domain = [('use_leads', '=', True)] if lead.type == 'lead' else [('use_opportunities', '=', True)]
            //     team = self.env['crm.team']._get_default_team_id(user_id=user.id, domain=team_domain)
            //     if lead.team_id != team:
            //         lead.team_id = team.id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _compute_team_id(self):
            // sale_moves = self.filtered(lambda move: move.is_sale_document(include_receipts=True))
            // for ((user_id, company_id), moves) in groupby(
            //     sale_moves,
            //     key=lambda m: (m.invoice_user_id.id, m.company_id.id)
            // ):
            //     self.env['account.move'].concat(*moves).team_id = self.env['crm.team'].with_context(
            //         allowed_company_ids=[company_id],
            //     )._get_default_team_id(
            //         user_id=user_id,
            //     )
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_team_id(self):
            // cached_teams = {}
            // for order in self:
            //     default_team_id = self.env.context.get('default_team_id', False) or order.team_id.id
            //     user_id = order.user_id.id
            //     company_id = order.company_id.id
            //     key = (default_team_id, user_id, company_id)
            //     if key not in cached_teams:
            //         cached_teams[key] = self.env['crm.team'].with_context(
            //             default_team_id=default_team_id,
            //         )._get_default_team_id(
            //             user_id=user_id,
            //             domain=self.env['crm.team']._check_company_domain(company_id),
            //         )
            //     order.team_id = cached_teams[key]
            */
            return default;
        }

        public async Task<TEntity> ComputeTimesheetCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def _compute_timesheet_count(self):
            // timesheet_data = self.env['account.analytic.line']._read_group([('timesheet_invoice_id', 'in', self.ids)], ['timesheet_invoice_id'], ['__count'])
            // mapped_data = {timesheet_invoice.id: count for timesheet_invoice, count in timesheet_data}
            // for invoice in self:
            //     invoice.timesheet_count = mapped_data.get(invoice.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeTimesheetTotalDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def _compute_timesheet_total_duration(self):
            // if not self.env.user.has_group('hr_timesheet.group_hr_timesheet_user'):
            //     self.timesheet_total_duration = 0
            //     return
            // group_data = self.env['account.analytic.line']._read_group([
            //     ('timesheet_invoice_id', 'in', self.ids)
            // ], ['timesheet_invoice_id'], ['unit_amount:sum'])
            // timesheet_unit_amount_dict = defaultdict(float)
            // timesheet_unit_amount_dict.update({timesheet_invoice.id: amount for timesheet_invoice, amount in group_data})
            // for invoice in self:
            //     total_time = invoice.company_id.project_time_mode_id._compute_quantity(
            //         timesheet_unit_amount_dict[invoice.id],
            //         invoice.timesheet_encode_uom_id,
            //         rounding_method='HALF-UP',
            //     )
            //     invoice.timesheet_total_duration = round(total_time)
            */
            return default;
        }

        public async Task<TEntity> ComputeTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_title(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.title or lead.partner_id.title:
            //         lead.title = lead.partner_id.title
            */
            return default;
        }

        public async Task<TEntity> ComputeTransactionCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def _compute_transaction_count(self):
            // for invoice in self:
            //     invoice.transaction_count = len(invoice.transaction_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_type_name(self):
            // for record in self:
            //     if record.state in ('draft', 'sent', 'cancel'):
            //         record.type_name = _("Quotation")
            //     else:
            //         record.type_name = _("Sales Order")
            */
            return default;
        }

        public async Task<TEntity> ComputeUserCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_user_company_ids(self):
            // all_companies = self.env['res.company'].search([])
            // for lead in self:
            //     if not lead.company_id:
            //         lead.user_company_ids = all_companies
            //     else:
            //         lead.user_company_ids = lead.company_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_user_id(self):
            // for order in self:
            //     if order.partner_id and not (order._origin.id and order.user_id):
            //         # Recompute the salesman on partner change
            //         #   * if partner is set (is required anyway, so it will be set sooner or later)
            //         #   * if the order is not saved or has no salesman already
            //         order.user_id = (
            //             order.partner_id.user_id
            //             or order.partner_id.commercial_partner_id.user_id
            //             or (self.env.user.has_group('sales_team.group_sale_salesman') and self.env.user)
            //         )
            */
            return default;
        }

        public async Task<TEntity> ComputeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_user(self):
            // for applicant in self:
            //     applicant.user_id = applicant.job_id.user_id.id
            */
            return default;
        }

        public async Task<TEntity> ComputeValidityDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_validity_date(self):
            // today = fields.Date.context_today(self)
            // for order in self:
            //     days = order.company_id.quotation_validity_days
            //     if days > 0:
            //         order.validity_date = today + timedelta(days)
            //     else:
            //         order.validity_date = False
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: account_move.py) ---
            // def _compute_website_id(self):
            // for move in self:
            //     source_websites = move.line_ids.sale_line_ids.order_id.website_id
            //     if len(source_websites) == 1:
            //         move.website_id = source_websites
            //     else:
            //         move.website_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_website(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.website or lead.partner_id.website:
            //         lead.website = lead.partner_id.website
            */
            return default;
        }

        public async Task<TEntity> ComputeWipProductionCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_account, FILE: account_move.py) ---
            // def _compute_wip_production_count(self):
            // for account in self:
            //     account.wip_production_count = len(account.wip_production_ids)
            */
            return default;
        }

        public async Task<TEntity> ConditionalAddToComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object condition) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ConfirmationErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _confirmation_error_message(self):
            // """ Return whether order can be confirmed or not if not then returm error message. """
            // self.ensure_one()
            // if self.state not in {'draft', 'sent'}:
            //     return _("Some orders are not in a state requiring confirmation.")
            // if any(
            //     not line.display_type
            //     and not line.is_downpayment
            //     and not line.product_id
            //     for line in self.order_line
            // ):
            //     return _("A line on these orders missing a product, you cannot confirm it.")
            // 
            // return False
            */
            return default;
        }

        public async Task<TEntity> ConvertLinksAsync<TEntity>(IEnumerable<TEntity> entities, object html, object vals, object blacklist) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def convert_links(self, html, vals, blacklist=None):
            // raise NotImplementedError('Moved on mail.render.mixin')
            */
            return default;
        }

        public async Task<TEntity> ConvertLinksTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body, object vals, object blacklist) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _convert_links_text(self, body, vals, blacklist=None):
            // raise NotImplementedError('Moved on mail.render.mixin')
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, object partner, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def convert_opportunity(self, partner, user_ids=False, team_id=False):
            // customer = partner if partner else self.env['res.partner']
            // for lead in self:
            //     if not lead.active or lead.probability == 100:
            //         continue
            //     vals = lead._convert_opportunity_data(customer, team_id)
            //     lead.write(vals)
            // 
            // if user_ids or team_id:
            //     self._handle_salesmen_assignment(user_ids=user_ids, team_id=team_id)
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, Guid team_id) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _convert_opportunity_data(self, customer, team_id=False):
            // """ Extract the data from a lead to create the opportunity
            //     :param customer : res.partner record
            //     :param team_id : identifier of the Sales Team to determine the stage
            // """
            // new_team_id = team_id if team_id else self.team_id.id
            // upd_values = {
            //     'type': 'opportunity',
            //     'date_conversion': self.env.cr.now(),
            // }
            // if customer != self.partner_id:
            //     upd_values['partner_id'] = customer.id if customer else False
            // if not self.stage_id:
            //     stage = self._stage_find(team_id=new_team_id)
            //     upd_values['stage_id'] = stage.id
            // return upd_values
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //     message_content = _('This entry has been reversed from %s', old_move._get_html_link()) if default.get('reversed_entry_id') else _('This entry has been duplicated from %s', old_move._get_html_link())
            //     bodies[new_move.id] = message_content + message_origin
            // new_moves._message_log_batch(bodies=bodies)
            // return new_moves
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def copy_data(self, default=None):
            // # set default value in context, if not already set (Put stage to 'new' stage)
            // # Set date_open to today if it is an opp
            // default = dict(default or {})
            // if not self.env.user.has_group('crm.group_use_recurring_revenues'):
            //     default['recurring_revenue'] = 0
            //     default['recurring_plan'] = False
            // vals_list = super().copy_data(default=default)
            // now = self.env.cr.now()
            // for lead, vals in zip(self, vals_list):
            //     vals.setdefault('type', lead.type)
            //     vals.setdefault('team_id', lead.team_id.id)
            //     vals['date_open'] = now if lead.type == 'opportunity' else False
            //     if not lead.user_id.active:
            //         vals['user_id'] = False
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // default_has_no_order_line = 'order_line' not in default
            // default.setdefault('order_line', [])
            // vals_list = super().copy_data(default=default)
            // if default_has_no_order_line:
            //     for order, vals in zip(self, vals_list):
            //         vals['order_line'] = [
            //             Command.create(line_vals)
            //             for line_vals in order._get_copiable_order_lines().copy_data()
            //         ]
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> CopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> CreateAccountInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_vals_list, object final) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_account_invoices(self, invoice_vals_list, final):
            // """Small method to allow overriding the behavior right after an invoice is created."""
            // # Manage the creation of invoices in sudo because a salesperson must be able to generate an invoice from a
            // # sale order without "billing" access rights. However, he should not be able to create an invoice from scratch.
            // return self.env['account.move'].sudo().with_context(default_move_type='out_invoice').create(invoice_vals_list)
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('website'):
            //         vals['website'] = self.env['res.partner']._clean_website(vals['website'])
            // leads = super(Lead, self).create(vals_list)
            // 
            // for lead, values in zip(leads, vals_list):
            //     if any(field in ['active', 'stage_id'] for field in values):
            //         lead._handle_won_lost(values)
            // 
            // return leads
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
            //             record_name=applicant.display_name,
            //             model_description="Applicant",
            //         )
            // # Copy CV from candidate to applicant at record creation
            // attachments_result = self.env['ir.attachment'].read_group([
            //     ('res_id', 'in', applicants.candidate_id.ids),
            //     ('res_model', '=', "hr.candidate")
            // ], ['ids:array_agg(id)'], groupby=['res_id'])
            // attachments_by_candidate = {e['res_id']: e['ids'] for e in attachments_result}
            // for applicant in applicants:
            //     if applicant.candidate_id.company_id and applicant.company_id != applicant.candidate_id.company_id:
            //         raise ValidationError(_("You cannot create an applicant in a different company than the candidate"))
            //     candidate_id = applicant.candidate_id.id
            //     if candidate_id not in attachments_by_candidate:
            //         continue
            //     self.env['ir.attachment'].browse(attachments_by_candidate[candidate_id]).copy({
            //         'res_id': applicant.id,
            //         'res_model': 'hr.applicant'
            //     })
            // return applicants
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def create(self, vals_list):
            // vals_list = [vals.copy() for vals in vals_list]
            // for vals in vals_list:
            //     if 'url' not in vals:
            //         raise ValueError(_('Creating a Link Tracker without URL is not possible'))
            // 
            //     if vals['url'].startswith(('?', '#')):
            //         raise UserError(_("“%s” is not a valid link, links cannot redirect to the current page.", vals['url']))
            //     vals['url'] = validate_url(vals['url'])
            // 
            //     if not vals.get('title'):
            //         vals['title'] = self._get_title_from_url(vals['url'])
            // 
            //     # Prevent the UTMs to be set by the values of UTM cookies
            //     for (__, fname, __) in self.env['utm.mixin'].tracking_fields():
            //         if fname not in vals:
            //             vals[fname] = False
            // 
            // links = super(LinkTracker, self).create(vals_list)
            // 
            // link_tracker_codes = self.env['link.tracker.code']._get_random_code_strings(len(vals_list))
            // 
            // self.env['link.tracker.code'].sudo().create([
            //     {
            //         'code': code,
            //         'link_id': link.id,
            //     } for link, code in zip(links, link_tracker_codes)
            // ])
            // 
            // return links
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('name', _("New")) == _("New"):
            //         seq_date = fields.Datetime.context_timestamp(
            //             self, fields.Datetime.to_datetime(vals['date_order'])
            //         ) if 'date_order' in vals else None
            //         vals['name'] = self.env['ir.sequence'].with_company(vals.get('company_id')).next_by_code(
            //             'sale.order', sequence_date=seq_date) or _("New")
            // 
            // return super().create(vals_list)
            */
            return default;
        }

        public async Task<TEntity> CreateCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _create_customer(self):
            // """ Create a partner from lead data and link it to the lead.
            // 
            // :return: newly-created partner browse record
            // """
            // Partner = self.env['res.partner']
            // contact_name = self.contact_name
            // if not contact_name:
            //     contact_name = parse_contact_from_email(self.email_from)[0] if self.email_from else False
            // 
            // if self.partner_name:
            //     partner_company = Partner.create(self._prepare_customer_values(self.partner_name, is_company=True))
            // elif self.partner_id:
            //     partner_company = self.partner_id
            // else:
            //     partner_company = None
            // 
            // if contact_name:
            //     return Partner.create(self._prepare_customer_values(contact_name, is_company=False, parent_id=partner_company.id if partner_company else False))
            // 
            // if partner_company:
            //     return partner_company
            // return Partner.create(self._prepare_customer_values(self.name, is_company=False))
            */
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def create_document_from_attachment(self, attachment_ids):
            // """ Create the sale orders from given attachment_ids and redirect newly create order view.
            // 
            // :param list attachment_ids: List of attachments process.
            // :return: An action redirecting to related sale order view.
            // :rtype: dict
            // """
            // orders = self._create_order_from_attachment(attachment_ids)
            // return orders._get_records_action(name=_("Generated Orders"))
            */
            return default;
        }

        public async Task<TEntity> CreateEmployeeFromApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def create_employee_from_applicant(self):
            // self.ensure_one()
            // action = self.candidate_id.with_context(clean_context(self.env.context)).create_employee_from_candidate()
            // employee = self.env['hr.employee'].browse(action['res_id'])
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

        public async Task<TEntity> CreateInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grouped, object final, object date) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_invoices(self, grouped=False, final=False, date=None):
            // """ Create invoice(s) for the given Sales Order(s).
            // 
            // :param bool grouped: if True, invoices are grouped by SO id.
            //     If False, invoices are grouped by keys returned by :meth:`_get_invoice_grouping_keys`
            // :param bool final: if True, refunds will be generated if necessary
            // :param date: unused parameter
            // :returns: created invoices
            // :rtype: `account.move` recordset
            // :raises: UserError if one of the orders has no invoiceable lines.
            // """
            // if not self.env['account.move'].has_access('create'):
            //     try:
            //         self.check_access('write')
            //     except AccessError:
            //         return self.env['account.move']
            // 
            // # 1) Create invoices.
            // invoice_vals_list = []
            // invoice_item_sequence = 0 # Incremental sequencing to keep the lines order on the invoice.
            // for order in self:
            //     if order.partner_invoice_id.lang:
            //         order = order.with_context(lang=order.partner_invoice_id.lang)
            //     order = order.with_company(order.company_id)
            // 
            //     invoice_vals = order._prepare_invoice()
            //     invoiceable_lines = order._get_invoiceable_lines(final)
            // 
            //     if not any(not line.display_type for line in invoiceable_lines):
            //         continue
            // 
            //     invoice_line_vals = []
            //     down_payment_section_added = False
            //     for line in invoiceable_lines:
            //         if not down_payment_section_added and line.is_downpayment:
            //             # Create a dedicated section for the down payments
            //             # (put at the end of the invoiceable_lines)
            //             invoice_line_vals.append(
            //                 Command.create(
            //                     order._prepare_down_payment_section_line(sequence=invoice_item_sequence)
            //                 ),
            //             )
            //             down_payment_section_added = True
            //             invoice_item_sequence += 1
            //         invoice_line_vals.append(
            //             Command.create(
            //                 line._prepare_invoice_line(sequence=invoice_item_sequence)
            //             ),
            //         )
            //         invoice_item_sequence += 1
            // 
            //     invoice_vals['invoice_line_ids'] += invoice_line_vals
            //     invoice_vals_list.append(invoice_vals)
            // 
            // if not invoice_vals_list and self._context.get('raise_if_nothing_to_invoice', True):
            //     raise UserError(self._nothing_to_invoice_error_message())
            // 
            // # 2) Manage 'grouped' parameter: group by (partner_id, currency_id).
            // if not grouped:
            //     new_invoice_vals_list = []
            //     invoice_grouping_keys = self._get_invoice_grouping_keys()
            //     invoice_vals_list = sorted(
            //         invoice_vals_list,
            //         key=lambda x: [
            //             x.get(grouping_key) for grouping_key in invoice_grouping_keys
            //         ]
            //     )
            //     for _grouping_keys, invoices in groupby(invoice_vals_list, key=lambda x: [x.get(grouping_key) for grouping_key in invoice_grouping_keys]):
            //         origins = set()
            //         payment_refs = set()
            //         refs = set()
            //         ref_invoice_vals = None
            //         for invoice_vals in invoices:
            //             if not ref_invoice_vals:
            //                 ref_invoice_vals = invoice_vals
            //             else:
            //                 ref_invoice_vals['invoice_line_ids'] += invoice_vals['invoice_line_ids']
            //             origins.add(invoice_vals['invoice_origin'])
            //             payment_refs.add(invoice_vals['payment_reference'])
            //             refs.add(invoice_vals['ref'])
            //         ref_invoice_vals.update({
            //             'ref': ', '.join(refs)[:2000],
            //             'invoice_origin': ', '.join(origins),
            //             'payment_reference': len(payment_refs) == 1 and payment_refs.pop() or False,
            //         })
            //         new_invoice_vals_list.append(ref_invoice_vals)
            //     invoice_vals_list = new_invoice_vals_list
            // 
            // # 3) Create invoices.
            // 
            // # As part of the invoice creation, we make sure the sequence of multiple SO do not interfere
            // # in a single invoice. Example:
            // # SO 1:
            // # - Section A (sequence: 10)
            // # - Product A (sequence: 11)
            // # SO 2:
            // # - Section B (sequence: 10)
            // # - Product B (sequence: 11)
            // #
            // # If SO 1 & 2 are grouped in the same invoice, the result will be:
            // # - Section A (sequence: 10)
            // # - Section B (sequence: 10)
            // # - Product A (sequence: 11)
            // # - Product B (sequence: 11)
            // #
            // # Resequencing should be safe, however we resequence only if there are less invoices than
            // # orders, meaning a grouping might have been done. This could also mean that only a part
            // # of the selected SO are invoiceable, but resequencing in this case shouldn't be an issue.
            // if len(invoice_vals_list) < len(self):
            //     SaleOrderLine = self.env['sale.order.line']
            //     for invoice in invoice_vals_list:
            //         sequence = 1
            //         for line in invoice['invoice_line_ids']:
            //             line[2]['sequence'] = SaleOrderLine._get_invoice_line_sequence(new=sequence, old=line[2]['sequence'])
            //             sequence += 1
            // 
            // moves = self._create_account_invoices(invoice_vals_list, final)
            // 
            // # 4) Some moves might actually be refunds: convert them if the total amount is negative
            // # We do this after the moves have been created since we need taxes, etc. to know if the total
            // # is actually negative or not
            // if final and (moves_to_switch := moves.sudo().filtered(lambda m: m.amount_total < 0)):
            //     with self.env.protecting([moves._fields['team_id']], moves_to_switch):
            //         moves_to_switch.action_switch_move_type()
            //         self.invoice_ids._set_reversed_entry(moves_to_switch)
            // 
            // for move in moves:
            //     if final:
            //         # Downpayment might have been determined by a fixed amount set by the user.
            //         # This amount is tax included. This can lead to rounding issues.
            //         # E.g. a user wants a 100€ DP on a product with 21% tax.
            //         # 100 / 1.21 = 82.64, 82.64 * 1,21 = 99.99
            //         # This is already corrected by adding/removing the missing cents on the DP invoice,
            //         # but must also be accounted for on the final invoice.
            // 
            //         delta_amount = 0
            //         for order_line in self.order_line:
            //             if not order_line.is_downpayment:
            //                 continue
            //             inv_amt = order_amt = 0
            //             for invoice_line in order_line.invoice_lines:
            //                 sign = 1 if invoice_line.move_id.is_inbound() else -1
            //                 if invoice_line.move_id == move:
            //                     inv_amt += invoice_line.price_total * sign
            //                 elif invoice_line.move_id.state != 'cancel':  # filter out canceled dp lines
            //                     order_amt += invoice_line.price_total * sign
            //             if inv_amt and order_amt:
            //                 # if not inv_amt, this order line is not related to current move
            //                 # if no order_amt, dp order line was not invoiced
            //                 delta_amount += inv_amt + order_amt
            // 
            //         if not move.currency_id.is_zero(delta_amount):
            //             receivable_line = move.line_ids.filtered(
            //                 lambda aml: aml.account_id.account_type == 'asset_receivable')[:1]
            //             product_lines = move.line_ids.filtered(
            //                 lambda aml: aml.display_type == 'product' and aml.is_downpayment)
            //             tax_lines = move.line_ids.filtered(
            //                 lambda aml: aml.tax_line_id.amount_type not in (False, 'fixed'))
            //             if tax_lines and product_lines and receivable_line:
            //                 line_commands = [Command.update(receivable_line.id, {
            //                     'amount_currency': receivable_line.amount_currency + delta_amount,
            //                 })]
            //                 delta_sign = 1 if delta_amount > 0 else -1
            //                 for lines, attr, sign in (
            //                     (product_lines, 'price_total', -1 if move.is_inbound() else 1),
            //                     (tax_lines, 'amount_currency', 1),
            //                 ):
            //                     remaining = delta_amount
            //                     lines_len = len(lines)
            //                     for line in lines:
            //                         if move.currency_id.compare_amounts(remaining, 0) != delta_sign:
            //                             break
            //                         amt = delta_sign * max(
            //                             move.currency_id.rounding,
            //                             abs(move.currency_id.round(remaining / lines_len)),
            //                         )
            //                         remaining -= amt
            //                         line_commands.append(Command.update(line.id, {attr: line[attr] + amt * sign}))
            //                 move.line_ids = line_commands
            // 
            //     move.message_post_with_source(
            //         'mail.message_origin_link',
            //         render_values={'self': move, 'origin': move.line_ids.sale_line_ids.order_id},
            //         subtype_xmlid='mail.mt_note',
            //     )
            // return moves
            */
            return default;
        }

        public async Task<TEntity> CreateOrderFromAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_order_from_attachment(self, attachment_ids):
            // """ Create the sale orders from given attachment_ids and fill data by extracting detail
            // from attachments and return generated orders.
            // 
            // :param list attachment_ids: List of attachments process.
            // :return: Recordset of order.
            // """
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // if not attachments:
            //     raise UserError(_("No attachment was provided"))
            // 
            // orders = self.browse()
            // for attachment in attachments:
            //     order = self.create({
            //         'partner_id': self.env.user.partner_id.id,
            //     })
            //     order._extend_with_attachments(attachment)
            //     orders |= order
            //     order.message_post(attachment_ids=attachment.ids)
            //     attachment.write({'res_model': self._name, 'res_id': order.id})
            // 
            // return orders
            */
            return default;
        }

        public async Task<TEntity> CreateUpsellActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_upsell_activity(self):
            // if not self:
            //     return
            // 
            // self.activity_unlink(['sale.mail_act_sale_upsell'])
            // for order in self:
            //     order_ref = order._get_html_link()
            //     customer_ref = order.partner_id._get_html_link()
            //     order.activity_schedule(
            //         'sale.mail_act_sale_upsell',
            //         user_id=order.user_id.id or order.partner_id.user_id.id,
            //         note=_("Upsell %(order)s for customer %(customer)s", order=order_ref, customer=customer_ref))
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_message(self):
            // self.ensure_one()
            // if self.team_id:
            //     return _('A new lead has been created for the team "%(team_name)s".', team_name=self.team_id.display_name)
            // return _('A new lead has been created and is not assigned to any team.')
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('crm.mt_lead_create')
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('hr_recruitment.mt_applicant_new')
            */
            return default;
        }

        public async Task<TEntity> CronAccountMoveSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object job_count) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _cron_account_move_send(self, job_count=10):
            // """ Process invoices generation and sending asynchronously.
            // :param job_count: maximum number of jobs to process if specified.
            // """
            // def get_account_notification(moves, is_success: bool):
            //     _ = self.env._
            //     return [
            //         'account_notification',
            //         {
            //             'type': 'success' if is_success else 'warning',
            //             'title': _('Invoices sent') if is_success else _('Invoices in error'),
            //             'message': _('Invoices sent successfully.') if is_success else _(
            //                 "One or more invoices couldn't be processed."),
            //             'action_button': {
            //                 'name': _('Open'),
            //                 'action_name': _('Sent invoices') if is_success else _('Invoices in error'),
            //                 'model': 'account.move',
            //                 'res_ids': moves.ids,
            //             },
            //         },
            //     ]
            // 
            // limit = job_count + 1
            // to_process = self.env['account.move'].search(
            //     [('sending_data', '!=', False)],
            //     limit=limit,
            // )
            // total_to_process = self.env['account.move'].search_count(
            //     [('sending_data', '!=', False)],
            // )
            // 
            // need_retrigger = len(to_process) > job_count
            // if not to_process:
            //     return
            // 
            // to_process = to_process[:job_count]
            // if not self.env['res.company']._with_locked_records(to_process, allow_raising=False):
            //     return
            // 
            // # Collect moves by res.partner that executed the Send & Print wizard, must be done before the _process
            // # that modify sending_data.
            // moves_by_partner = to_process.grouped(lambda m: m.sending_data['author_partner_id'])
            // 
            // self.env['account.move.send']._generate_and_send_invoices(
            //     to_process,
            //     from_cron=True,
            // )
            // self.env['ir.cron']._notify_progress(done=len(to_process),
            //                                      remaining=total_to_process - len(to_process))
            // 
            // for partner_id, partner_moves in moves_by_partner.items():
            //     partner = self.env['res.partner'].browse(partner_id)
            //     partner_moves_error = partner_moves.filtered(lambda m: m.sending_data and m.sending_data.get('error'))
            //     if partner_moves_error:
            //         partner._bus_send(*get_account_notification(partner_moves_error, False))
            //     partner_moves_success = partner_moves - partner_moves_error
            //     if partner_moves_success:
            //         partner._bus_send(*get_account_notification(partner_moves_success, True))
            //     partner_moves_error.sending_data = False
            // 
            // if need_retrigger:
            //     self.env.ref('account.ir_cron_account_move_send')._trigger()
            */
            return default;
        }

        public async Task<TEntity> CronUpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _cron_update_automated_probabilities(self):
            // """ This cron will :
            //   - rebuild the lead scoring frequency table
            //   - recompute all the automated_probability and align probability if both were aligned
            // """
            // cron_start_date = datetime.now()
            // self._rebuild_pls_frequency_table()
            // self._update_automated_probabilities()
            // _logger.info("Predictive Lead Scoring : Cron duration = %d seconds" % ((datetime.now() - cron_start_date).total_seconds()))
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_mixin.py) ---
            // def default_get(self, fields):
            // values = super(UtmMixin, self).default_get(fields)
            // 
            // # We ignore UTM for salesmen, except some requests that could be done as superuser_id to bypass access rights.
            // if not self.env.is_superuser() and self.env.user.has_group('sales_team.group_sale_salesman'):
            //     return values
            // 
            // for url_param, field_name, cookie_name in self.env['utm.mixin'].tracking_fields():
            //     if field_name in fields:
            //         field = self._fields[field_name]
            //         value = False
            //         if request:
            //             # ir_http dispatch saves the url params in a cookie
            //             value = request.cookies.get(cookie_name)
            //         # if we receive a string for a many2one, we search/create the id
            //         if field.type == 'many2one' and isinstance(value, str) and value:
            //             record = self._find_or_create_record(field.comodel_name, value)
            //             value = record.id
            //         if value:
            //             values[field_name] = value
            // return values
            */
            return default;
        }

        public async Task<TEntity> DefaultOrderLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self.env['sale.order.line']._get_product_catalog_lines_data()
            // return {**default_data, **new_default_data}
            */
            return default;
        }

        public async Task<TEntity> DetachAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> DisableDiscountPrecisionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> DisableRecursionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container, object key, object @default, object target) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> DiscardTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _discard_tracking(self):
            // self.ensure_one()
            // return (
            //     self.state == 'draft'
            //     and request and request.env.context.get('catalog_skip_tracking')
            // )
            */
            return default;
        }

        public async Task<TEntity> EdiAllowButtonDraftInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _edi_allow_button_draft(self):
            // self.ensure_one()
            // return not self.edi_show_cancel_button
            */
            return default;
        }

        public async Task<TEntity> ExtendWithAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _extend_with_attachments(self, attachment):
            // """ Main entry point to extend/enhance order with attachment.
            // 
            // :param attachment: A recordset of ir.attachment.
            // :returns: None
            // """
            // self.ensure_one()
            // 
            // file_data = attachment._unwrap_edi_attachments()[0]
            // decoder = self._get_order_edi_decoder(file_data)
            // if decoder:
            //     try:
            //         with self.env.cr.savepoint():
            //             decoder(self, file_data)
            //     except RedirectWarning:
            //         raise
            //     except Exception:
            //         message = _(
            //             "Error importing attachment '%(file_name)s' as order (decoder=%(decoder)s)",
            //             file_name=file_data['filename'],
            //             decoder=decoder.__name__,
            //         )
            //         self.with_user(SUPERUSER_ID).message_post(body=message)
            //         _logger.exception(message)
            // 
            // if file_data.get('on_close'):
            //     file_data['on_close']()
            // return True
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _fetch_duplicate_orders(self):
            // """ Fectch duplicated orders.
            // 
            // :return: Dictionary mapping order to it's related duplicated orders.
            // :rtype: dict
            // """
            // orders = self.filtered(lambda order: order.id and order.client_order_ref)
            // if not orders:
            //     return {}
            // 
            // used_fields = (
            //     'company_id',
            //     'partner_id',
            //     'client_order_ref',
            //     'origin',
            //     'date_order',
            //     'state',
            // )
            // self.env['sale.order'].flush_model(used_fields)
            // 
            // result = self.env.execute_query(SQL("""
            //     SELECT
            //         sale_order.id AS order_id,
            //         array_agg(duplicate_order.id) AS duplicate_ids
            //       FROM sale_order
            //       JOIN sale_order AS duplicate_order
            //         ON sale_order.company_id = duplicate_order.company_id
            //          AND sale_order.id != duplicate_order.id
            //          AND duplicate_order.state != 'cancel'
            //          AND sale_order.partner_id = duplicate_order.partner_id
            //          AND sale_order.date_order = duplicate_order.date_order
            //          AND sale_order.client_order_ref = duplicate_order.client_order_ref
            //          AND (
            //             sale_order.origin = duplicate_order.origin
            //             OR (sale_order.origin IS NULL AND duplicate_order.origin IS NULL)
            //         )
            //      WHERE sale_order.id IN %(orders)s
            //      GROUP BY sale_order.id
            //     """,
            //     orders=tuple(orders.ids),
            // ))
            // return {
            //     order_id: set(duplicate_ids)
            //     for order_id, duplicate_ids in result
            // }
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object matching_states) where TEntity : IEntity<Guid>, IUtmMixinable
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
            // if not moves[0].id:  # check if record is under creation/edition in UI
            //     # New record aren't searchable in the DB and record in edition aren't up to date yet
            //     # Replace the table by safely injecting the values in the query
            //     values = {
            //         field_name: moves._fields[field_name].convert_to_write(moves[field_name], moves) or None
            //         for field_name in used_fields
            //     }
            //     values["id"] = moves._origin.id or 0
            //     # The amount total depends on the field line_ids and is calculated upon saving, we needed a way to get it even when the
            //     # invoices has not been saved yet.
            //     values['amount_total'] = self.tax_totals.get('total_amount_currency', 0)
            //     casted_values = SQL(', ').join(
            //         SQL("%s::%s", value, SQL.identifier(moves._fields[field_name].column_type[0]))
            //         for field_name, value in values.items()
            //     )
            //     column_names = SQL(', ').join(SQL.identifier(field_name) for field_name in values)
            //     move_table_and_alias = SQL("(VALUES (%s)) AS move(%s)", casted_values, column_names)
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
            */
            return default;
        }

        public async Task<TEntity> FieldWillChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals, object field_name) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> FilterProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object documents) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _filter_product_documents(self, documents):
            // return documents.filtered(
            //     lambda document:
            //         document.attached_on_sale == 'quotation'
            //         or (self.state == 'sale' and document.attached_on_sale == 'sale_order')
            // )
            */
            return default;
        }

        public async Task<TEntity> FindAndSetPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _find_and_set_purchase_orders(self, po_references, partner_id, amount_total, from_ocr=False, timeout=10):
            // # hook to be used with purchase, so that vendor bills are sync/autocompleted with purchase orders
            // self.ensure_one()
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _find_and_set_purchase_orders(self, po_references, partner_id, amount_total, from_ocr=False, timeout=10):
            // """Finds related purchase orders that (partially) match the vendor bill and links the matching lines on this
            // vendor bill.
            // 
            // :param po_references: a list of potential purchase order references/names
            // :param partner_id: the vendor id matched on the vendor bill
            // :param amount_total: the total amount of the vendor bill
            // :param from_ocr: indicates whether this vendor bill was created from an OCR scan (less reliable)
            // :param timeout: the max time the line matching algorithm can take before timing out
            // """
            // self.ensure_one()
            // 
            // method, matched_po_lines, matched_inv_lines = self._match_purchase_orders(
            //     po_references, partner_id, amount_total, from_ocr, timeout
            // )
            // 
            // if method in ('total_match', 'po_match'):
            //     # The purchase order reference(s) and total amounts match perfectly or there is only one purchase order
            //     # reference that matches with an OCR invoice. We replace the invoice lines with the purchase order lines.
            //     self._set_purchase_orders(matched_po_lines.order_id, force_write=True)
            // 
            // elif method == 'subset_total_match':
            //     # A subset of the referenced purchase order lines matches the total amount of this invoice.
            //     # We keep the invoice lines, but add all the lines from the partially matched purchase orders:
            //     #   * "naively" matched purchase order lines keep their quantity
            //     #   * unmatched purchase order lines are added with their quantity set to 0
            //     self._set_purchase_orders(matched_po_lines.order_id, force_write=False)
            // 
            //     with self._get_edi_creation() as invoice:
            //         unmatched_lines = invoice.invoice_line_ids.filtered(
            //             lambda l: l.purchase_line_id and l.purchase_line_id not in matched_po_lines)
            //         invoice.invoice_line_ids = [Command.update(line.id, {'quantity': 0}) for line in unmatched_lines]
            // 
            // elif method == 'subset_match':
            //     # A subset of the referenced purchase order lines matches a subset of the invoice lines.
            //     # We add the purchase order lines, but adjust the quantity to the quantities in the invoice.
            //     # The original invoice lines that correspond with a purchase order line are removed.
            //     self._set_purchase_orders(matched_po_lines.order_id, force_write=False)
            // 
            //     with self._get_edi_creation() as invoice:
            //         unmatched_lines = invoice.invoice_line_ids.filtered(
            //             lambda l: l.purchase_line_id and l.purchase_line_id not in matched_po_lines)
            //         invoice.invoice_line_ids = [Command.delete(line.id) for line in unmatched_lines]
            // 
            //         # We remove the original matched invoice lines and apply their quantities and taxes to the matched
            //         # purchase order lines.
            //         inv_and_po_lines = list(map(lambda line: (
            //                 invoice.invoice_line_ids.filtered(
            //                     lambda l: l.purchase_line_id and l.purchase_line_id.id == line[0]),
            //                 invoice.invoice_line_ids.filtered(
            //                     lambda l: l in line[1])
            //             ),
            //             matched_inv_lines
            //         ))
            //         invoice.invoice_line_ids = [
            //             Command.update(po_line.id, {'quantity': inv_line.quantity, 'tax_ids': inv_line.tax_ids})
            //             for po_line, inv_line in inv_and_po_lines
            //         ]
            //         invoice.invoice_line_ids = [Command.delete(inv_line.id) for dummy, inv_line in inv_and_po_lines]
            // 
            //         # If there are lines left not linked to a purchase order, we add a header
            //         unmatched_lines = invoice.invoice_line_ids.filtered(lambda l: not l.purchase_line_id)
            //         if len(unmatched_lines) > 0:
            //             invoice.invoice_line_ids = [Command.create({
            //                 'display_type': 'line_section',
            //                 'name': _('From Electronic Document'),
            //                 'sequence': -1,
            //             })]
            */
            return default;
        }

        public async Task<TEntity> FindMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _find_mail_template(self):
            // """ Get the appropriate mail template for the current sales order based on its state.
            // 
            // If the SO is confirmed, we return the mail template for the sale confirmation.
            // Otherwise, we return the quotation email template.
            // 
            // :return: The correct mail template based on the current status
            // :rtype: record of `mail.template` or `None` if not found
            // """
            // self.ensure_one()
            // if self.env.context.get('proforma') or self.state != 'sale':
            //     return self.env.ref('sale.email_template_edi_sale', raise_if_not_found=False)
            // else:
            //     return self._get_confirmation_template()
            */
            return default;
        }

        public async Task<TEntity> FindMatchingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_only) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _find_matching_partner(self, email_only=False):
            // """ Try to find a matching partner with available information on the
            // lead, using notably customer's name, email, ...
            // 
            // :param email_only: Only find a matching based on the email. To use
            //     for automatic process where ilike based on name can be too dangerous
            // :return: partner browse record
            // """
            // self.ensure_one()
            // partner = self.partner_id
            // 
            // if not partner and self.email_from:
            //     partner = self.env['res.partner'].search([('email', '=', self.email_from)], limit=1)
            // 
            // if not partner and not email_only:
            //     # search through the existing partners based on the lead's partner or contact name
            //     # to be aligned with _create_customer, search on lead's name as last possibility
            //     for customer_potential_name in [self[field_name] for field_name in ['partner_name', 'contact_name', 'name'] if self[field_name]]:
            //         partner = self.env['res.partner'].search([('name', 'ilike', customer_potential_name)], limit=1)
            //         if partner:
            //             break
            // 
            // return partner
            */
            return default;
        }

        public async Task<TEntity> FindMatchingPoAndInvLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_lines, object inv_lines, object timeout) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _find_matching_po_and_inv_lines(self, po_lines, inv_lines, timeout):
            // """Finds purchase order lines that match some of the invoice lines.
            // 
            // We try to find a purchase order line for every invoice line matching on the unit price and having at least
            // the same quantity to invoice.
            // 
            // :param po_lines: list of purchase order lines that can be matched
            // :param inv_lines: list of invoice lines to be matched
            // :param timeout: how long this function can run before we consider it too long
            // :return: a tuple (list, list) containing:
            //     * matched 'purchase.order.line'
            //     * tuple of purchase order line ids and their matched 'account.move.line'
            // """
            // # Sort the invoice lines by unit price and quantity to speed up matching
            // invoice_lines = sorted(inv_lines, key=lambda line: (line.price_unit, line.quantity), reverse=True)
            // # Sort the purchase order lines by unit price and remaining quantity to speed up matching
            // purchase_lines = sorted(
            //     po_lines,
            //     key=lambda line: (line.price_unit, line.product_qty - line.qty_invoiced),
            //     reverse=True
            // )
            // matched_po_lines = []
            // matched_inv_lines = []
            // try:
            //     start_time = time.time()
            //     for invoice_line in invoice_lines:
            //         # There are no purchase order lines left. We are done matching.
            //         if not purchase_lines:
            //             break
            //         # A dict of purchase lines mapping to a diff score for the name
            //         purchase_line_candidates = {}
            //         for purchase_line in purchase_lines:
            //             if time.time() - start_time > timeout:
            //                 raise TimeoutError
            // 
            //             # The lists are sorted by unit price descendingly.
            //             # When the unit price of the purchase line is lower than the unit price of the invoice line,
            //             # we cannot get a match anymore.
            //             if purchase_line.price_unit < invoice_line.price_unit:
            //                 break
            // 
            //             if (invoice_line.price_unit == purchase_line.price_unit
            //                     and invoice_line.quantity <= purchase_line.product_qty - purchase_line.qty_invoiced):
            //                 # The current purchase line is a possible match for the current invoice line.
            //                 # We calculate the name match ratio and continue with other possible matches.
            //                 #
            //                 # We could match on more fields coming from an EDI invoice, but that requires extending the
            //                 # account.move.line model with the extra matching fields and extending the EDI extraction
            //                 # logic to fill these new fields.
            //                 purchase_line_candidates[purchase_line] = difflib.SequenceMatcher(
            //                     None, invoice_line.name, purchase_line.name).ratio()
            // 
            //         if len(purchase_line_candidates) > 0:
            //             # We take the best match based on the name.
            //             purchase_line_match = max(purchase_line_candidates, key=purchase_line_candidates.get)
            //             if purchase_line_match:
            //                 # We found a match. We remove the purchase order line so it does not get matched twice.
            //                 purchase_lines.remove(purchase_line_match)
            //                 matched_po_lines.append(purchase_line_match)
            //                 matched_inv_lines.append((purchase_line_match.id, invoice_line))
            // 
            //     return (matched_po_lines, matched_inv_lines)
            // 
            // except TimeoutError:
            //     _logger.warning('Timed out during search of matching purchase order lines')
            //     return ([], [])
            */
            return default;
        }

        public async Task<TEntity> FindMatchingSubsetPoLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_lines_with_amount, object goal_total, object timeout) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _find_matching_subset_po_lines(self, po_lines_with_amount, goal_total, timeout):
            // """Finds the purchase order lines adding up to the goal amount.
            // 
            // The problem of finding the subset of `po_lines_with_amount` which sums up to `goal_total` reduces to
            // the 0-1 Knapsack problem. The dynamic programming approach to solve this problem is most of the time slower
            // than this because identical sub-problems don't arise often enough. It returns the list of purchase order lines
            // which sum up to `goal_total` or an empty list if multiple or no solutions were found.
            // 
            // :param po_lines_with_amount: a dict (str: float|recordset) containing:
            //     * line: an `purchase.order.line`
            //     * amount_to_invoice: the remaining amount to be invoiced of the line
            // :param goal_total: the total amount to match with a subset of purchase order lines
            // :param timeout: the max time the line matching algorithm can take before timing out
            // :return: list of `purchase.order.line` whose remaining sum matches `goal_total`
            // """
            // def find_matching_subset_po_lines(lines, goal):
            //     if time.time() - start_time > timeout:
            //         raise TimeoutError
            //     solutions = []
            //     for i, line in enumerate(lines):
            //         if line['amount_to_invoice'] < goal - TOLERANCE:
            //             # The amount to invoice of the current purchase order line is less than the amount we still need on
            //             # the vendor bill.
            //             # We try finding purchase order lines that match the remaining vendor bill amount minus the amount
            //             # to invoice of the current purchase order line. We only look in the purchase order lines that we
            //             # haven't passed yet.
            //             sub_solutions = find_matching_subset_po_lines(lines[i + 1:], goal - line['amount_to_invoice'])
            //             # We add all possible sub-solutions' purchase order lines in a tuple together with our current
            //             # purchase order line.
            //             solutions.extend((line['line'], *solution) for solution in sub_solutions)
            //         elif goal - TOLERANCE <= line['amount_to_invoice'] <= goal + TOLERANCE:
            //             # The amount to invoice of the current purchase order line matches the remaining vendor bill amount.
            //             # We add this purchase order line to our list of solutions.
            //             solutions.append([line['line']])
            //         if len(solutions) > 1:
            //             # More than one solution was found. We can't know for sure which is the correct one, so we don't
            //             # return any solution.
            //             return []
            //     return solutions
            // start_time = time.time()
            // try:
            //     subsets = find_matching_subset_po_lines(
            //         sorted(po_lines_with_amount, key=lambda line: line['amount_to_invoice'], reverse=True),
            //         goal_total
            //     )
            //     return subsets[0] if subsets else []
            // except TimeoutError:
            //     _logger.warning("Timed out during search of a matching subset of purchase order lines")
            //     return []
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateRecordAsync<TEntity>(IEnumerable<TEntity> entities, object model_name, object name) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_mixin.py) ---
            // def find_or_create_record(self, model_name, name):
            // """ Version of ``_find_or_create_record`` used in frontend notably in
            // website_links. For UTM models it calls _find_or_create_record. For other
            // models (as through inheritance custom models could be used notably in
            // website links) it simply calls a create. In the end it relies on
            // standard ACLs, and is mainly a wrapper for UTM models.
            // 
            // :return: id of newly created or found record. As the magic of call_kw
            // for create is not called anymore we have to manually return an id
            // instead of a recordset. """
            // if model_name in self._tracking_models():
            //     record = self._find_or_create_record(model_name, name)
            // else:
            //     record = self.env[model_name].create({self.env[model_name]._rec_name: name})
            // return {'id': record.id, 'name': record.display_name}
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model_name, object name) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_mixin.py) ---
            // def _find_or_create_record(self, model_name, name):
            // """Based on the model name and on the name of the record, retrieve the corresponding record or create it."""
            // Model = self.env[model_name]
            // 
            // cleaned_name = name.strip()
            // if cleaned_name:
            //     record = Model.with_context(active_test=False).search([('name', '=ilike', cleaned_name)], limit=1)
            // 
            // if not record:
            //     # No record found, create a new one
            //     record_values = {'name': cleaned_name}
            //     if 'is_auto_campaign' in record._fields:
            //         record_values['is_auto_campaign'] = True
            //     record = Model.create(record_values)
            // 
            // return record
            */
            return default;
        }

        public async Task<TEntity> ForceLinesToInvoicePolicyOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _force_lines_to_invoice_policy_order(self):
            // """Force the qty_to_invoice to be computed as if the invoice_policy
            // was set to "Ordered quantities", independently of the product configuration.
            // 
            // This is needed for the automatic invoice logic, as we want to automatically
            // invoice the full SO when it's paid.
            // """
            // for line in self.order_line:
            //     if line.state == 'sale':
            //         # No need to set 0 as it is already the standard logic in the compute method.
            //         line.qty_to_invoice = line.product_uom_qty - line.qty_invoiced
            */
            return default;
        }

        public async Task<TEntity> FormatPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _format_properties(self):
            // """Format the properties to build the merge message.
            // 
            // Return a list of dict containing the label, and a value key if there's only
            // one value, or a "values" key if we have multiple values (e.g. many2many, tags).
            // 
            // E.G.
            //     [{
            //         'label': 'My Partner',
            //         'value': 'Alice',
            //     }, {
            //         'label': 'My Partners',
            //         'values': [
            //             {'name': 'Alice'},
            //             {'name': 'Bob'},
            //         ],
            //     }, {
            //         'label': 'My Tags',
            //         'values': [
            //             {'name': 'A', 'color': 1},
            //             {'name': 'C', 'color': 3},
            //         ],
            //     }]
            // """
            // self.ensure_one()
            // # read to have the display names already in the value
            // properties = self.read(['lead_properties'])[0]['lead_properties']
            // 
            // formatted = []
            // for definition in properties:
            //     label = definition.get('string')
            //     value = definition.get('value')
            //     property_type = definition['type']
            //     if not value and property_type != 'boolean':
            //         continue
            // 
            //     property_dict = {'label': label}
            //     if property_type == 'boolean':
            //         property_dict['value'] = _('Yes') if value else _('No')
            //     elif value and property_type == 'many2one':
            //         property_dict['value'] = value[1]
            //     elif value and property_type == 'many2many':
            //         # show many2many in badge
            //         property_dict['values'] = [{'name': rec[1]} for rec in value]
            //     elif value and property_type in ['selection', 'tags']:
            //         # retrieve the option label from the value
            //         options = {
            //             option[0]: option[1:]
            //             for option in (definition.get(property_type) or [])
            //         }
            //         if property_type == 'selection':
            //             value = options.get(value)
            //             property_dict['value'] = value[0] if value else None
            //         else:
            //             property_dict['values'] = [{
            //                 'name': options[tag][0],
            //                 'color': options[tag][1],
            //                 } for tag in value if tag in options
            //             ]
            //     else:
            //         property_dict['value'] = value
            // 
            //     formatted.append(property_dict)
            // 
            // return formatted
            */
            return default;
        }

        public async Task<TEntity> GenerateAndSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_synchronous, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GenerateDownpaymentInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _generate_downpayment_invoices(self):
            // """ Generate invoices as down payments for sale order.
            // 
            // :return: The generated down payment invoices.
            // :rtype: recordset of `account.move`
            // """
            // generated_invoices = self.env['account.move']
            // 
            // for order in self:
            //     downpayment_wizard = order.env['sale.advance.payment.inv'].create({
            //         'sale_order_ids': order,
            //         'advance_payment_method': 'fixed',
            //         'fixed_amount': order.amount_paid,
            //     })
            //     generated_invoices |= downpayment_wizard._create_invoices(order)
            // 
            // return generated_invoices
            */
            return default;
        }

        public async Task<TEntity> GenerateQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object silent_errors) where TEntity : IEntity<Guid>, IUtmMixinable
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
            // unstruct_ref = self.ref if self.ref else self.name
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

        public async Task<TEntity> GetAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax, object lock_dates) where TEntity : IEntity<Guid>, IUtmMixinable
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
            // :return (datetime.date):
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

        public async Task<TEntity> GetActionAddFromCatalogExtraContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // return {
            //     **super()._get_action_add_from_catalog_extra_context(),
            //     'product_catalog_currency_id': self.currency_id.id,
            //     'product_catalog_digits': self.order_line._fields['price_unit'].get_digits(self.env),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetActionPerItemInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_project, FILE: account_move.py) ---
            // def _get_action_per_item(self):
            // action = self.env.ref('account.action_move_out_invoice_type').id
            // return {invoice.id: action for invoice in self}
            */
            return default;
        }

        public async Task<TEntity> GetAllReconciledInvoicePartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_all_reconciled_invoice_partials(self):
            // self.ensure_one()
            // reconciled_lines = self.line_ids.filtered(lambda line: line.account_id.account_type in ('asset_receivable', 'liability_payable'))
            // if not reconciled_lines:
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

        public async Task<TEntity> GetAngloSaxonPriceCtxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _get_anglo_saxon_price_ctx(self):
            // ctx = super()._get_anglo_saxon_price_ctx()
            // move_is_downpayment = self.invoice_line_ids.filtered(
            //     lambda line: any(line.sale_line_ids.mapped("is_downpayment"))
            // )
            // return dict(ctx, move_is_downpayment=move_is_downpayment)
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_anglo_saxon_price_ctx(self):
            // """ To be overriden in modules overriding _stock_account_get_anglo_saxon_price_unit
            // to optimize computations that only depend on account.move and not account.move.line
            // """
            // return self.env.context
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetAutomaticBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetChainInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_chain_info(self, force_hash=False, include_pre_last_hash=False, early_stop=False):
            // """All records in `self` must belong to the same journal and sequence_prefix
            // """
            // if not self:
            //     return False
            // last_move_in_chain = max(self, key=lambda m: m.sequence_number)
            // journal = last_move_in_chain.journal_id
            // if not self._is_move_restricted(last_move_in_chain, force_hash=force_hash):
            //     return False
            // 
            // common_domain = [
            //     ('journal_id', '=', journal.id),
            //     ('sequence_prefix', '=', last_move_in_chain.sequence_prefix),
            // ]
            // last_move_hashed = self.env['account.move'].search([
            //     *common_domain,
            //     ('inalterable_hash', '!=', False),
            // ], order='sequence_number desc', limit=1)
            // 
            // domain = self.env['account.move']._get_move_hash_domain([
            //     *common_domain,
            //     ('sequence_number', '<=', last_move_in_chain.sequence_number),
            //     ('inalterable_hash', '=', False),
            // ], force_hash=True)
            // if last_move_hashed and not include_pre_last_hash:
            //     # Hash moves only after the last hashed move, not the ones that may have been posted before the journal was set on restrict mode
            //     domain.extend([('sequence_number', '>', last_move_hashed.sequence_number)])
            // 
            // # On the accounting dashboard, we are only interested on whether there are documents to hash or not
            // # so we can stop the computation early if we find at least one document to hash
            // if early_stop:
            //     return self.env['account.move'].sudo().search_count(domain, limit=1)
            // moves_to_hash = self.env['account.move'].sudo().search(domain, order='sequence_number')
            // warnings = set()
            // if moves_to_hash:
            //     # gap warning
            //     if last_move_hashed:
            //         first = last_move_hashed.sequence_number
            //         difference = len(moves_to_hash)
            //     else:
            //         first = moves_to_hash[0].sequence_number
            //         difference = len(moves_to_hash) - 1
            //     last = moves_to_hash[-1].sequence_number
            //     if first + difference != last:
            //         warnings.add('gap')
            // 
            //     # unreconciled warning
            //     unreconciled = False in moves_to_hash.statement_line_ids.mapped('is_reconciled')
            //     if unreconciled:
            //         warnings.add('unreconciled')
            // else:
            //     warnings.add('no_document')
            // moves = moves_to_hash.sudo(False)
            // return {
            //     'previous_hash': last_move_hashed.inalterable_hash,
            //     'last_move_hashed': last_move_hashed,
            //     'moves': moves,
            //     'remaining_moves': self - moves,
            //     'warnings': warnings,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetChainsToHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object raise_if_gap, object raise_if_no_document, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetConfirmationTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_confirmation_template(self):
            // """ Get the mail template sent on SO confirmation (or for confirmed SO's).
            // 
            // :return: `mail.template` record or None if default template wasn't found
            // """
            // self.ensure_one()
            // default_confirmation_template_id = self.env['ir.config_parameter'].sudo().get_param(
            //     'sale.default_confirmation_template'
            // )
            // default_confirmation_template = default_confirmation_template_id \
            //     and self.env['mail.template'].browse(int(default_confirmation_template_id)).exists()
            // if default_confirmation_template:
            //     return default_confirmation_template
            // else:
            //     return self.env.ref('sale.mail_template_sale_confirmation', raise_if_not_found=False)
            */
            return default;
        }

        public async Task<TEntity> GetCopiableOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_copiable_order_lines(self):
            // """Returns the order lines that can be copied to a new order."""
            // return self.order_line.filtered(lambda l: not l.is_downpayment)
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid to_currency_id, object date) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_customer_information(self):
            // email_normalized_to_values = super()._get_customer_information()
            // Partner = self.env['res.partner']
            // 
            // for record in self.filtered('email_normalized'):
            //     values = email_normalized_to_values.setdefault(record.email_normalized, {})
            //     contact_name = record.contact_name or record.partner_name or parse_contact_from_email(record.email_from)[0] or record.email_from
            //     # Note that we don't attempt to create the parent company even if partner name is set
            //     values.update(record._prepare_customer_values(contact_name, is_company=False))
            //     values['company_name'] = record.partner_name
            //     if contact_name == record.partner_name:
            //         values['company_type'] = 'company'
            // return email_normalized_to_values
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPaymentLinkValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_default_payment_link_values(self):
            // self.ensure_one()
            // amount_max = self.amount_total - self.amount_paid
            // 
            // # Always default to the minimum value needed to confirm the order:
            // # - order is not confirmed yet
            // # - can be confirmed online
            // # - we have still not paid enough for confirmation.
            // prepayment_amount = self._get_prepayment_required_amount()
            // if (
            //     self.state in ('draft', 'sent')
            //     and self.require_payment
            //     and self.currency_id.compare_amounts(prepayment_amount, self.amount_paid) > 0
            // ):
            //     amount = prepayment_amount - self.amount_paid
            // else:
            //     amount = amount_max
            // 
            // return {
            //     'currency_id': self.currency_id.id,
            //     'partner_id': self.partner_invoice_id.id,
            //     'amount': amount,
            //     'amount_max': amount_max,
            //     'amount_paid': self.amount_paid,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDiscountAllocationAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetDurationFromTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object trackings) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetEdiAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_format) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _get_edi_attachment(self, edi_format):
            // return self._get_edi_document(edi_format).sudo().attachment_id
            */
            return default;
        }

        public async Task<TEntity> GetEdiCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetEdiDecoderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_data, object @new) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_edi_decoder(self, file_data, new=False):
            // """To be extended with decoding capabilities.
            // :returns:  Function to be later used to import the file.
            //            Function' args:
            //            - invoice: account.move
            //            - file_data: attachemnt information / value
            //            - new: whether the invoice is newly created
            //            returns True if was able to process the invoice
            // """
            // return None
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_edi_decoder(self, file_data, new=False):
            // # EXTENDS 'account'
            // if file_data['type'] == 'xml':
            //     if etree.QName(file_data['xml_tree']).localname == 'AttachedDocument':
            //         file_data['xml_tree'] = self._ubl_parse_attached_document(file_data['xml_tree'])
            //     ubl_cii_xml_builder = self._get_ubl_cii_builder_from_xml_tree(file_data['xml_tree'])
            //     if ubl_cii_xml_builder is not None:
            //         return ubl_cii_xml_builder._import_invoice_ubl_cii
            // 
            // return super()._get_edi_decoder(file_data, new=new)
            */
            return default;
        }

        public async Task<TEntity> GetEdiDocumentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_format) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _get_edi_document(self, edi_format):
            // return self.edi_document_ids.filtered(lambda d: d.edi_format_id == edi_format)
            */
            return default;
        }

        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_msg) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_empty_list_help(self, help_message):
            // """ This method returns the action helpers for the leads. If help is already provided
            //     on the action, the same is returned. Otherwise, we build the help message which
            //     contains the alias responsible for creating the lead (if available) and return it.
            // """
            // if not is_html_empty(help_message):
            //     return help_message
            // 
            // help_title, sub_title = "", ""
            // if self._context.get('default_type') == 'lead':
            //     help_title = _('Create a new lead')
            // else:
            //     help_title = _('Create an opportunity to start playing with your pipeline.')
            // alias_domain = [
            //     ('company_id', 'in', [self.env.company.id, False]),
            //     ('alias_id.alias_name', '!=', False),
            //     ('alias_id.alias_name', '!=', ''),
            //     ('alias_id.alias_model_id.model', '=', 'crm.lead'),
            // ]
            // # sort by use_leads, then by our membership of the team
            // alias_records = self.env['crm.team'].search(alias_domain).sorted(
            //     lambda r: (r.use_leads, self.env.user in r.member_ids), reverse=True
            // )
            // alias_record = alias_records[0] if alias_records else None
            // if alias_record and alias_record.alias_domain and alias_record.alias_name:
            //     sub_title = Markup(_('Use the <i>New</i> button, or send an email to %(email_link)s to test the email gateway.')) % {
            //         'email_link': Markup("<b><a href='mailto:%s'>%s</a></b>") % (alias_record.alias_email, alias_record.alias_email),
            //     }
            // return super().get_empty_list_help(
            //     f'<p class="o_view_nocontent_smiling_face">{help_title}</p><p class="oe_view_nocontent_alias">{sub_title}</p>'
            // )
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
            //             'help_title': _("No application found. Let's create one !"),
            //         }
            // 
            //         if hr_job:
            //             pattern = r'(.*)<a>(.*?)<\/a>(.*)'
            //             match = re.fullmatch(pattern, _('Have you tried to <a>add skills to your job position</a> and search into the Reserve ?'))
            //             nocontent_body += Markup("""
            // <p>%(para_1)s<a href="%(link)s">%(para_2)s</a>%(para_3)s</p>""") % {
            //             'para_1': match[1],
            //             'para_2': match[2],
            //             'para_3': match[3],
            //             'link': f'/odoo/recruitment/{hr_job.id}',
            //         }
            // 
            //         if hr_job.alias_email:
            //             nocontent_body += Markup('<p class="o_copy_paste_email oe_view_nocontent_alias">%(helper_email)s <a href="mailto:%(email)s">%(email)s</a></p>') % {
            //                 'helper_email': _("Try creating an application by sending an email to"),
            //                 'email': hr_job.alias_email,
            //             }
            // 
            //         return super().get_empty_list_help(nocontent_body)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_empty_list_help(self, help_msg):
            // self = self.with_context(
            //     empty_list_help_document_name=_("sale order"),
            // )
            // return super().get_empty_list_help(help_msg)
            */
            return default;
        }

        public async Task<TEntity> GetExtraPrintItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_extra_print_items(self):
            // """ Helper to dynamically add items in the 'Print' menu of list and form of account.move.
            // This is necessary to avoid the re-generation of the PDF through the action_report.
            // Indeed, once a legal PDF is generated, it should be used and not re-generated.
            // """
            // return [{
            //     'key': 'download_pdf',
            //     'description': _('PDF'),
            //     **self.action_invoice_download_pdf()
            // }]
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def get_extra_print_items(self):
            // print_items = super().get_extra_print_items()
            // if self.ubl_cii_xml_id:
            //     print_items.append({
            //         'key': 'download_ubl',
            //         'description': _('XML UBL'),
            //         **self.action_invoice_download_ubl(),
            //     })
            // return print_items
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToCopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetFieldsToDetachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_fields_to_detach(self):
            // """"
            // Returns a list of field names to detach on resetting an invoice to draft. Can be overridden by other modules to
            // add more fields.
            // """
            // return ['invoice_pdf_report_file']
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_fields_to_detach(self):
            // # EXTENDS account
            // fields_list = super()._get_fields_to_detach()
            // fields_list.append("ubl_cii_xml_file")
            // return fields_list
            */
            return default;
        }

        public async Task<TEntity> GetFrequentAccountAndTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //     ('account_id.deprecated', '=', False),
            //     ('date', '>=', date.today() - timedelta(days=365 * 2)),
            // ]
            // if move_type in self.env['account.move'].get_inbound_types(include_receipts=True):
            //     domain.append(('account_id.internal_group', '=', 'income'))
            // elif move_type in self.env['account.move'].get_outbound_types(include_receipts=True):
            //     domain.append(('account_id.internal_group', '=', 'expense'))
            // 
            // query = self.env['account.move.line']._where_calc(domain)
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

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Leads & Opportunities'),
            //     'template': '/crm/static/xls/crm_lead.xls'
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetInboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_inbound_types(self, include_receipts=True):
            // return ['out_invoice', 'in_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetInstallmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetIntegrityHashFieldsAndSubfieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_integrity_hash_fields_and_subfields(self):
            // return self._get_integrity_hash_fields() + [f'line_ids.{subfield}' for subfield in self.line_ids._get_integrity_hash_fields()]
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_integrity_hash_fields(self):
            // # Use the latest hash version by default, but keep the old one for backward compatibility when generating the integrity report.
            // hash_version = self._context.get('hash_version', MAX_HASH_VERSION)
            // if hash_version == 1:
            //     return ['date', 'journal_id', 'company_id']
            // elif hash_version in (2, 3, 4):
            //     return ['name', 'date', 'journal_id', 'company_id']
            // raise NotImplementedError(f"hash_version={hash_version} doesn't exist")
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceComputedReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_computed_reference(self):
            // self.ensure_one()
            // if self.journal_id.invoice_reference_type == 'none':
            //     return ''
            // ref_function = getattr(self, f'_get_invoice_reference_{self.journal_id.invoice_reference_model}_{self.journal_id.invoice_reference_type}', None)
            // if ref_function is None:
            //     raise UserError(_("The combination of reference model and reference type on the journal is not implemented"))
            // return ref_function()
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aml_values_list, object open_balance) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //                 'display_type': 'epd',  # Used to compute tax_tag_invert for early payment discount lines
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

        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountPerPaymentTermLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //             'analytic_distribution': base_line['analytic_distribution'],
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
            //     }
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCurrencyRateDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_currency_rate_date(self):
            // self.ensure_one()
            // return self.invoice_date or fields.Date.context_today(self)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceGroupingKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_invoice_grouping_keys(self):
            // return ['company_id', 'partner_id', 'currency_id']
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceInPaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_in_payment_state(self):
            // ''' Hook to give the state when the invoice becomes fully paid. This is necessary because the users working
            // with only invoicing don't want to see the 'in_payment' state. Then, this method will be overridden in the
            // accountant module to enable the 'in_payment' state. '''
            // return 'paid'
            --- ODOO METHOD SOURCE (MODULE: om_account_accountant, FILE: account_move.py) ---
            // def _get_invoice_in_payment_state(self):
            // return 'in_payment'
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLegalDocumentsAllInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allow_fallback) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetInvoiceLegalDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filetype, object allow_fallback) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_legal_documents(self, filetype, allow_fallback=False):
            // """ Retrieve the invoice legal document of type filetype.
            // :param filetype: the type of legal document to retrieve. Example: 'pdf', 'all'.
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
            // elif filetype == 'all':
            //     return self._get_invoice_legal_documents_all(allow_fallback=allow_fallback)
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_invoice_legal_documents(self, filetype, allow_fallback=False):
            // # EXTENDS account
            // if filetype == 'ubl':
            //     if ubl_attachment := self.ubl_cii_xml_id:
            //         return {
            //             'filename': ubl_attachment.name,
            //             'filetype': 'xml',
            //             'content': ubl_attachment.raw,
            //         }
            // return super()._get_invoice_legal_documents(filetype, allow_fallback=allow_fallback)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetInvoiceNextPaymentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetInvoicePdfProformaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetInvoicePortalExtraValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetInvoiceProformaPdfReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetInvoiceReferenceEuroInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_reference_euro_invoice(self):
            // """ This computes the reference based on the RF Creditor Reference.
            //     The data of the reference is the database id number of the invoice.
            //     For instance, if an invoice is issued with id 43, the check number
            //     is 07 so the reference will be 'RF07 43'.
            // """
            // self.ensure_one()
            // return format_structured_reference_iso(self.id)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceEuroPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            // partner_ref = self.partner_id.ref
            // partner_ref_nr = re.sub(r'\D', '', partner_ref or '')[-21:] or str(self.partner_id.id)[-21:]
            // partner_ref_nr = partner_ref_nr[-21:]
            // return format_structured_reference_iso(partner_ref_nr)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _get_invoice_reference(self):
            // self.ensure_one()
            // vendor_refs = [ref for ref in set(self.invoice_line_ids.mapped('purchase_line_id.order_id.partner_ref')) if ref]
            // if self.ref:
            //     return [ref for ref in self.ref.split(', ') if ref and ref not in vendor_refs] + vendor_refs
            // return vendor_refs
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceOdooInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetInvoiceReferenceOdooPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetInvoiceReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object extension) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_report_filename(self, extension='pdf'):
            // """ Get the filename of the generated invoice report with extension file. """
            // self.ensure_one()
            // return f"{self.name.replace('/', '_')}.{extension}"
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_invoice_types(self, include_receipts=False):
            // return self.get_sale_types(include_receipts) + self.get_purchase_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object final) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_invoiceable_lines(self, final=False):
            // """Return the invoiceable lines for order `self`."""
            // down_payment_line_ids = []
            // invoiceable_line_ids = []
            // pending_section = None
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // 
            // for line in self.order_line:
            //     if line.display_type == 'line_section':
            //         # Only invoice the section if one of its lines is invoiceable
            //         pending_section = line
            //         continue
            //     if line.display_type != 'line_note' and float_is_zero(line.qty_to_invoice, precision_digits=precision):
            //         continue
            //     if line.qty_to_invoice > 0 or (line.qty_to_invoice < 0 and final) or line.display_type == 'line_note':
            //         if line.is_downpayment:
            //             # Keep down payment lines separately, to put them together
            //             # at the end of the invoice, in a specific dedicated section.
            //             down_payment_line_ids.append(line.id)
            //             continue
            //         if pending_section:
            //             invoiceable_line_ids.append(pending_section.id)
            //             pending_section = None
            //         invoiceable_line_ids.append(line.id)
            // 
            // return self.env['sale.order.line'].browse(invoiceable_line_ids + down_payment_line_ids)
            */
            return default;
        }

        public async Task<TEntity> GetInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_invoiced(self):
            // # The invoice_ids are obtained thanks to the invoice lines of the SO
            // # lines, and we also search for possible refunds created directly from
            // # existing invoices. This is necessary since such a refund is not
            // # directly linked to the SO.
            // for order in self:
            //     invoices = order.order_line.invoice_lines.move_id.filtered(lambda r: r.move_type in ('out_invoice', 'out_refund'))
            //     order.invoice_ids = invoices
            //     order.invoice_count = len(invoices)
            */
            return default;
        }

        public async Task<TEntity> GetInvoicedLotValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _get_invoiced_lot_values(self):
            // self.ensure_one()
            // 
            // lot_values = super(AccountMove, self)._get_invoiced_lot_values()
            // 
            // if self.state == 'draft':
            //     return lot_values
            // 
            // # user may not have access to POS orders, but it's ok if they have
            // # access to the invoice
            // for order in self.sudo().pos_order_ids:
            //     for line in order.lines:
            //         lots = line.pack_lot_ids or False
            //         if lots:
            //             for lot in lots:
            //                 lot_values.append({
            //                     'product_name': lot.product_id.name,
            //                     'quantity': line.qty if lot.product_id.tracking == 'lot' else 1.0,
            //                     'uom_name': line.product_uom_id.name,
            //                     'lot_name': lot.lot_name,
            //                     'pos_lot_id': lot.id,
            //                 })
            // 
            // return lot_values
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _get_invoiced_lot_values(self):
            // """ Get and prepare data to show a table of invoiced lot on the invoice's report. """
            // self.ensure_one()
            // 
            // res = super(AccountMove, self)._get_invoiced_lot_values()
            // 
            // if self.state == 'draft' or not self.invoice_date or self.move_type not in ('out_invoice', 'out_refund'):
            //     return res
            // 
            // current_invoice_amls = self.invoice_line_ids.filtered(lambda aml: aml.display_type == 'product' and aml.product_id and aml.product_id.type == 'consu' and aml.quantity)
            // all_invoices_amls = current_invoice_amls.sale_line_ids.invoice_lines.filtered(lambda aml: aml._filter_aml_lot_valuation()).sorted(lambda aml: (aml.date, aml.move_name, aml.id))
            // index = all_invoices_amls.ids.index(current_invoice_amls[:1].id) if current_invoice_amls[:1] in all_invoices_amls else 0
            // previous_amls = all_invoices_amls[:index]
            // invoiced_qties = current_invoice_amls._get_invoiced_qty_per_product()
            // invoiced_products = invoiced_qties.keys()
            // 
            // if self.move_type == 'out_invoice':
            //     # filter out the invoices that have been fully refund and re-invoice otherwise, the quantities would be
            //     # consumed by the reversed invoice and won't be print on the new draft invoice
            //     previous_amls = previous_amls.filtered(lambda aml: aml.move_id.payment_state != 'reversed')
            // 
            // previous_qties_invoiced = previous_amls._get_invoiced_qty_per_product()
            // 
            // if self.move_type == 'out_refund':
            //     # we swap the sign because it's a refund, and it would print negative number otherwise
            //     for p in previous_qties_invoiced:
            //         previous_qties_invoiced[p] = -previous_qties_invoiced[p]
            //     for p in invoiced_qties:
            //         invoiced_qties[p] = -invoiced_qties[p]
            // 
            // qties_per_lot = defaultdict(float)
            // previous_qties_delivered = defaultdict(float)
            // stock_move_lines = current_invoice_amls.sale_line_ids.move_ids.move_line_ids.filtered(lambda sml: sml.state == 'done' and sml.lot_id).sorted(lambda sml: (sml.date, sml.id))
            // for sml in stock_move_lines:
            //     if sml.product_id not in invoiced_products or not sml._should_show_lot_in_invoice():
            //         continue
            //     product = sml.product_id
            //     product_uom = product.uom_id
            //     quantity = sml.product_uom_id._compute_quantity(sml.quantity, product_uom)
            // 
            //     # is it a stock return considering the document type (should it be it thought of as positively or negatively?)
            //     is_stock_return = (
            //             self.move_type == 'out_invoice' and (sml.location_id.usage, sml.location_dest_id.usage) == ('customer', 'internal')
            //             or
            //             self.move_type == 'out_refund' and (sml.location_id.usage, sml.location_dest_id.usage) == ('internal', 'customer')
            //     )
            //     if is_stock_return:
            //         returned_qty = min(qties_per_lot[sml.lot_id], quantity)
            //         qties_per_lot[sml.lot_id] -= returned_qty
            //         quantity = returned_qty - quantity
            // 
            //     previous_qty_invoiced = previous_qties_invoiced[product]
            //     previous_qty_delivered = previous_qties_delivered[product]
            //     # If we return more than currently delivered (i.e., quantity < 0), we remove the surplus
            //     # from the previously delivered (and quantity becomes zero). If it's a delivery, we first
            //     # try to reach the previous_qty_invoiced
            //     if float_compare(quantity, 0, precision_rounding=product_uom.rounding) < 0 or \
            //             float_compare(previous_qty_delivered, previous_qty_invoiced, precision_rounding=product_uom.rounding) < 0:
            //         previously_done = quantity if is_stock_return else min(previous_qty_invoiced - previous_qty_delivered, quantity)
            //         previous_qties_delivered[product] += previously_done
            //         quantity -= previously_done
            // 
            //     qties_per_lot[sml.lot_id] += quantity
            // 
            // for lot, qty in qties_per_lot.items():
            //     # access the lot as a superuser in order to avoid an error
            //     # when a user prints an invoice without having the stock access
            //     lot = lot.sudo()
            //     if float_is_zero(invoiced_qties[lot.product_id], precision_rounding=lot.product_uom_id.rounding) \
            //             or float_compare(qty, 0, precision_rounding=lot.product_uom_id.rounding) <= 0:
            //         continue
            //     invoiced_lot_qty = min(qty, invoiced_qties[lot.product_id])
            //     invoiced_qties[lot.product_id] -= invoiced_lot_qty
            //     res.append({
            //         'product_name': lot.product_id.display_name,
            //         'quantity': formatLang(self.env, invoiced_lot_qty, dp='Product Unit of Measure'),
            //         'uom_name': lot.product_uom_id.name,
            //         'lot_name': lot.name,
            //         # The lot id is needed by localizations to inherit the method and add custom fields on the invoice's report.
            //         'lot_id': lot.id,
            //     })
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_invoiced_lot_values(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_lang(self):
            // self.ensure_one()
            // 
            // if self.partner_id.lang and not self.partner_id.is_public:
            //     return self.partner_id.lang
            // 
            // return self.env.lang
            */
            return default;
        }

        public async Task<TEntity> GetLastSequenceDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object relaxed) where TEntity : IEntity<Guid>, IUtmMixinable
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
            // return where_string, param
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def _get_last_sequence_domain(self, relaxed=False):
            // where_string, param = super()._get_last_sequence_domain(relaxed)
            // if self.journal_id.debit_sequence:
            //     where_string += " AND debit_origin_id IS " + ("NOT NULL" if self.debit_origin_id else "NULL")
            // return where_string, param
            */
            return default;
        }

        public async Task<TEntity> GetLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object email, object include_lost) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_lead_duplicates(self, partner=None, email=None, include_lost=False):
            // """ Search for leads that seem duplicated based on partner / email.
            // 
            // :param partner : optional customer when searching duplicated
            // :param email: email (possibly formatted) to search
            // :param boolean include_lost: if True, search includes archived opportunities
            //   (still only active leads are considered). If False, search for active
            //   and not won leads and opportunities;
            // """
            // if not email and not partner:
            //     return self.env['crm.lead']
            // 
            // domain = []
            // for normalized_email in [tools.email_normalize(email) for email in tools.email_split(email)]:
            //     domain.append(('email_normalized', '=', normalized_email))
            // if partner:
            //     domain.append(('partner_id', '=', partner.id))
            // 
            // if not domain:
            //     return self.env['crm.lead']
            // 
            // domain = ['|'] * (len(domain) - 1) + domain
            // if include_lost:
            //     domain += ['|', ('type', '=', 'opportunity'), ('active', '=', True)]
            // else:
            //     domain += ['&', ('active', '=', True), '|', ('stage_id', '=', False), ('stage_id.is_won', '=', False)]
            // 
            // return self.with_context(active_test=False).search(domain)
            */
            return default;
        }

        public async Task<TEntity> GetLineValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lines_vals) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_line_vals_list(self, lines_vals):
            // """ Get invoice line values list.
            // 
            // param list line_vals: List of values [name, qty, price, tax].
            // :return: List of invoice line values.
            // """
            // return [{
            //     'sequence': 0,  # be sure to put these lines above the 'real' invoice lines
            //     'name': name,
            //     'quantity': quantity,
            //     'price_unit': price_unit,
            //     'tax_ids': [Command.set(tax_ids)],
            // } for name, quantity, price_unit, tax_ids in lines_vals]
            */
            return default;
        }

        public async Task<TEntity> GetLinesOnchangeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_lines_onchange_currency(self):
            // # Override needed for COGS
            // return self.line_ids
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _get_lines_onchange_currency(self):
            // # OVERRIDE
            // return self.line_ids.filtered(lambda l: l.display_type != 'cogs')
            */
            return default;
        }

        public async Task<TEntity> GetLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_mail_template(self):
            // """
            // :return: the correct mail template based on the current move type
            // """
            // return self.env.ref(
            //     'account.email_template_edi_credit_note'
            //     if all(move.move_type == 'out_refund' for move in self)
            //     else 'account.email_template_edi_invoice'
            // )
            */
            return default;
        }

        public async Task<TEntity> GetMailThreadDataAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetMoveDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object show_ref) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetMoveHashDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object common_domain, object force_hash) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_move_hash_domain(self, common_domain=False, force_hash=False):
            // """
            // Returns a search domain on model account.move checking whether they should be hashed.
            // :param common_domain: a search domain that will be included in the returned domain in any case
            // :param force_hash: if True, we'll check all moves posted, independently of journal settings
            // """
            // common_domain = expression.AND([
            //     common_domain or [],
            //     [('state', '=', 'posted')],
            // ])
            // if force_hash:
            //     return common_domain
            // return expression.AND([
            //     common_domain,
            //     [('restrict_mode_hash_table', '=', True)],
            // ])
            */
            return default;
        }

        public async Task<TEntity> GetNameInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetNamePortalContentViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_name_portal_content_view(self):
            // """ This method can be inherited by localizations who want to localize the online quotation view. """
            // self.ensure_one()
            // return 'sale.sale_order_portal_content'
            */
            return default;
        }

        public async Task<TEntity> GetNameTaxTotalsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_name_tax_totals_view(self):
            // """ This method can be inherited by localizations who want to localize the taxes displayed on the portal and sale order report. """
            // return 'sale.document_tax_totals'
            */
            return default;
        }

        public async Task<TEntity> GetNoteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_note_url(self):
            // return self.env.company.get_base_url()
            */
            return default;
        }

        public async Task<TEntity> GetOnlinePaymentErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_payment, FILE: account_move.py) ---
            // def _get_online_payment_error(self):
            // """
            // Returns the appropriate error message to be displayed if _has_to_be_paid() method returns False.
            // """
            // self.ensure_one()
            // transactions = self.transaction_ids.filtered(lambda tx: tx.state in ('pending', 'authorized', 'done'))
            // pending_transactions = transactions.filtered(
            //     lambda tx: tx.state in {'pending', 'authorized'}
            //                and tx.provider_code not in {'none', 'custom'})
            // enabled_feature = str2bool(
            //     self.env['ir.config_parameter'].sudo().get_param(
            //         'account_payment.enable_portal_payment'
            //     )
            // )
            // errors = []
            // if not enabled_feature:
            //     errors.append(_("This invoice cannot be paid online."))
            // if transactions or self.currency_id.is_zero(self.amount_residual):
            //     errors.append(_("There is no amount to be paid."))
            // if self.state != 'posted':
            //     errors.append(_("This invoice isn't posted."))
            // if self.currency_id.is_zero(self.amount_residual):
            //     errors.append(_("This invoice has already been paid."))
            // if self.move_type != 'out_invoice':
            //     errors.append(_("This is not an outgoing invoice."))
            // if pending_transactions:
            //     errors.append(_("There are pending transactions for this invoice."))
            // return '\n'.join(errors)
            */
            return default;
        }

        public async Task<TEntity> GetOpportunityMeetingViewParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_opportunity_meeting_view_parameters(self):
            // """ Return the most relevant parameters for calendar view when viewing meetings linked to an opportunity.
            //     If there are any meetings that are not finished yet, only consider those meetings,
            //     since the user would prefer no to see past meetings. Otherwise, consider all meetings.
            //     Allday events datetimes are used without taking tz into account.
            //     -If there is no event, return week mode and false (The calendar will target 'now' by default)
            //     -If there is only one, return week mode and date of the start of the event.
            //     -If there are several events entirely on the same week, return week mode and start of first event.
            //     -Else, return month mode and the date of the start of first event as initial date. (If they are
            //     on the same month, this will display that month and therefore show all of them, which is expected)
            // 
            //     :return tuple(mode, initial_date)
            //         - mode: selected mode of the calendar view, 'week' or 'month'
            //         - initial_date: date of the start of the first relevant meeting. The calendar will target that date.
            // """
            // self.ensure_one()
            // meeting_results = self.env["calendar.event"].search_read([('opportunity_id', '=', self.id)], ['start', 'stop', 'allday'])
            // if not meeting_results:
            //     return "week", False
            // 
            // user_tz = self.env.user.tz or self.env.context.get('tz')
            // user_pytz = pytz.timezone(user_tz) if user_tz else pytz.utc
            // 
            // # meeting_dts will contain one tuple of datetimes per meeting : (Start, Stop)
            // # meetings_dts and now_dt are as per user time zone.
            // meeting_dts = []
            // now_dt = datetime.now().astimezone(user_pytz).replace(tzinfo=None)
            // 
            // # When creating an allday meeting, whatever the TZ, it will be stored the same e.g. 00.00.00->23.59.59 in utc or
            // # 08.00.00->18.00.00. Therefore we must not put it back in the user tz but take it raw.
            // for meeting in meeting_results:
            //     if meeting.get('allday'):
            //         meeting_dts.append((meeting.get('start'), meeting.get('stop')))
            //     else:
            //         meeting_dts.append((meeting.get('start').astimezone(user_pytz).replace(tzinfo=None),
            //                            meeting.get('stop').astimezone(user_pytz).replace(tzinfo=None)))
            // 
            // # If there are meetings that are still ongoing or to come, only take those.
            // unfinished_meeting_dts = [meeting_dt for meeting_dt in meeting_dts if meeting_dt[1] >= now_dt]
            // relevant_meeting_dts = unfinished_meeting_dts if unfinished_meeting_dts else meeting_dts
            // relevant_meeting_count = len(relevant_meeting_dts)
            // 
            // if relevant_meeting_count == 1:
            //     return "week", relevant_meeting_dts[0][0].date()
            // else:
            //     # Range of meetings
            //     earliest_start_dt = min(relevant_meeting_dt[0] for relevant_meeting_dt in relevant_meeting_dts)
            //     latest_stop_dt = max(relevant_meeting_dt[1] for relevant_meeting_dt in relevant_meeting_dts)
            // 
            //     # The week start day depends on language. We fetch the week_start of user's language. 1 is monday.
            //     lang_week_start = self.env["res.lang"].search_read([('code', '=', self.env.user.lang)], ['week_start'])
            //     # We substract one to make week_start_index range 0-6 instead of 1-7
            //     week_start_index = int(lang_week_start[0].get('week_start', '1')) - 1
            // 
            //     # We compute the weekday of earliest_start_dt according to week_start_index. earliest_start_dt_index will be 0 if we are on the
            //     # first day of the week and 6 on the last. weekday() returns 0 for monday and 6 for sunday. For instance, Tuesday in UK is the
            //     # third day of the week, so earliest_start_dt_index is 2, and remaining_days_in_week includes tuesday, so it will be 5.
            //     # The first term 7 is there to avoid negative left side on the modulo, improving readability.
            //     earliest_start_dt_weekday = (7 + earliest_start_dt.weekday() - week_start_index) % 7
            //     remaining_days_in_week = 7 - earliest_start_dt_weekday
            // 
            //     # We compute the start of the week following the one containing the start of the first meeting.
            //     next_week_start_date = earliest_start_dt.date() + timedelta(days=remaining_days_in_week)
            // 
            //     # Latest_stop_dt must be before the start of following week. Limit is therefore set at midnight of first day, included.
            //     meetings_in_same_week = latest_stop_dt <= datetime(next_week_start_date.year, next_week_start_date.month, next_week_start_date.day, 0, 0, 0)
            // 
            //     if meetings_in_same_week:
            //         return "week", earliest_start_dt.date()
            //     else:
            //         return "month", earliest_start_dt.date()
            */
            return default;
        }

        public async Task<TEntity> GetOrderEdiDecoderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_data) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_order_edi_decoder(self, file_data):
            // """ To be extended with decoding capabilities of order data from file data.
            // 
            // :returns:  Function to be later used to import the file.
            //            Function' args:
            //            - order: sale.order
            //            - file_data: attachemnt information / value
            //            returns True if was able to process the order
            // """
            // if file_data['type'] in ('pdf', 'binary'):
            //     return lambda *args: False
            // return
            */
            return default;
        }

        public async Task<TEntity> GetOrderLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_order_lines_to_report(self):
            // down_payment_lines = self.order_line.filtered(lambda line:
            //     line.is_downpayment
            //     and not line.display_type
            //     and not line._get_downpayment_state()
            // )
            // 
            // def show_line(line):
            //     if not line.is_downpayment:
            //         return True
            //     elif line.display_type and down_payment_lines:
            //         return True  # Only show the down payment section if down payments were posted
            //     elif line in down_payment_lines:
            //         return True  # Only show posted down payments
            //     else:
            //         return False
            // 
            // return self.order_line.filtered(show_line)
            */
            return default;
        }

        public async Task<TEntity> GetOutboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_outbound_types(self, include_receipts=True):
            // return ['in_invoice', 'out_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCreditWarningExcludeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _get_partner_credit_warning_exclude_amount(self):
            // # EXTENDS module 'account'
            // # Consider the warning on a draft invoice created from a sales order.
            // # After confirming the invoice the (partial) amount (on the invoice)
            // # stemming from sales orders will be substracted from the credit_to_invoice.
            // # This will reduce the total credit of the partner.
            // # The computation should reflect the change of credit_to_invoice from 'res.partner'.
            // # (see _compute_credit_to_invoice and _compute_amount_to_invoice from 'sale.order' )
            // exclude_amount = super()._get_partner_credit_warning_exclude_amount()
            // for order in self.line_ids.sale_line_ids.order_id:
            //     order_amount = min(self._get_sale_order_invoiced_amount(order), order.amount_to_invoice)
            //     order_amount_company = order.currency_id._convert(
            //         max(order_amount, 0),
            //         self.company_id.currency_id,
            //         self.company_id,
            //         fields.Date.context_today(self)
            //     )
            //     exclude_amount += order_amount_company
            // return exclude_amount
            */
            return default;
        }

        public async Task<TEntity> GetPartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_email_update(self, force_void=True):
            // """Calculate if we should write the email on the related partner. When
            // the email of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of email update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void email value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.email_from) and self.email_from != self.partner_id.email:
            //     lead_email_normalized = tools.email_normalize(self.email_from) or self.email_from or False
            //     partner_email_normalized = tools.email_normalize(self.partner_id.email) or self.partner_id.email or False
            //     return lead_email_normalized != partner_email_normalized
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_phone_update(self, force_void=True):
            // """Calculate if we should write the phone on the related partner. When
            // the phone of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of phone update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void phone value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.phone) and self.phone != self.partner_id.phone:
            //     lead_phone_formatted = self._phone_format(fname='phone') or self.phone or False
            //     partner_phone_formatted = self.partner_id._phone_format(fname='phone') or self.partner_id.phone or False
            //     return lead_phone_formatted != partner_phone_formatted
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetPortalLastTransactionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_portal_last_transaction(self):
            // self.ensure_one()
            // return self.transaction_ids.sudo()._get_last()
            */
            return default;
        }

        public async Task<TEntity> GetPortalReturnActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_portal_return_action(self):
            // """ Return the action used to display orders when returning from customer portal. """
            // self.ensure_one()
            // return self.env.ref('sale.action_quotations_with_onboarding')
            */
            return default;
        }

        public async Task<TEntity> GetPrepaymentRequiredAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_prepayment_required_amount(self):
            // """ Return the minimum amount needed to confirm automatically the quotation.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The minimum amount needed to confirm automatically the quotation.
            // :rtype: float
            // """
            // self.ensure_one()
            // if self.prepayment_percent == 1.0 or not self.require_payment:
            //     return self.amount_total
            // else:
            //     return self.currency_id.round(self.amount_total * self.prepayment_percent)
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_catalog_domain(self):
            // return expression.AND([super()._get_product_catalog_domain(), [('sale_ok', '=', True)]])
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogOrderDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_catalog_order_data(self, products, **kwargs):
            // pricelist = self.pricelist_id._get_products_price(
            //     quantity=1.0,
            //     products=products,
            //     currency=self.currency_id,
            //     date=self.date_order,
            //     **kwargs,
            // )
            // res = super()._get_product_catalog_order_data(products, **kwargs)
            // for product in products:
            //     res[product.id]['price'] = pricelist.get(product.id)
            //     if product.sale_line_warn != 'no-message' and product.sale_line_warn_msg:
            //         res[product.id]['warning'] = product.sale_line_warn_msg
            //     if product.sale_line_warn == "block":
            //         res[product.id]['readOnly'] = True
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogRecordLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_ids) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, **kwargs):
            // grouped_lines = defaultdict(lambda: self.env['sale.order.line'])
            // for line in self.order_line:
            //     if line.display_type or line.product_id.id not in product_ids:
            //         continue
            //     grouped_lines[line.product_id] |= line
            // return grouped_lines
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_documents(self):
            // self.ensure_one()
            // 
            // documents = (
            //     self.order_line.product_id.product_document_ids
            //     | self.order_line.product_template_id.product_document_ids
            // )
            // return self._filter_product_documents(documents).sorted()
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceAndDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetProtectedValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object records) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetPurchaseTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_purchase_types(self, include_receipts=False):
            // return ['in_invoice', 'in_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetQuickEditSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetRainbowmanMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_rainbowman_message(self):
            // self.ensure_one()
            // if self.stage_id.is_won:
            //     return self._get_rainbowman_message()
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_rainbowman_message(self):
            // if not self.user_id or not self.team_id:
            //     return False
            // if not self.expected_revenue:
            //     # Show rainbow man for the first won lead of a salesman, even if expected revenue is not set. It is not
            //     # very often that leads without revenues are marked won, so simply get count using ORM instead of query
            //     today = fields.Datetime.today()
            //     user_won_leads_count = self.search_count([
            //         ('type', '=', 'opportunity'),
            //         ('user_id', '=', self.user_id.id),
            //         ('probability', '=', 100),
            //         ('date_closed', '>=', date_utils.start_of(today, 'year')),
            //         ('date_closed', '<', date_utils.end_of(today, 'year')),
            //     ])
            //     if user_won_leads_count == 1:
            //         return _('Go, go, go! Congrats for your first deal.')
            //     return False
            // 
            // self.flush_model()  # flush fields to make sure DB is up to date
            // query = """
            //     SELECT
            //         SUM(CASE WHEN user_id = %(user_id)s THEN 1 ELSE 0 END) as total_won,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_7,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_7
            //     FROM crm_lead
            //     WHERE
            //         type = 'opportunity'
            //     AND
            //         active = True
            //     AND
            //         probability = 100
            //     AND
            //         DATE_TRUNC('year', date_closed) = DATE_TRUNC('year', CURRENT_DATE)
            //     AND
            //         (user_id = %(user_id)s OR team_id = %(team_id)s)
            // """
            // self.env.cr.execute(query, {'user_id': self.user_id.id,
            //                             'team_id': self.team_id.id})
            // query_result = self.env.cr.dictfetchone()
            // 
            // message = False
            // if query_result['total_won'] == 1:
            //     message = _('Go, go, go! Congrats for your first deal.')
            // elif query_result['max_team_30'] == self.expected_revenue:
            //     message = _('Boom! Team record for the past 30 days.')
            // elif query_result['max_team_7'] == self.expected_revenue:
            //     message = _('Yeah! Deal of the last 7 days for the team.')
            // elif query_result['max_user_30'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 30 days.')
            // elif query_result['max_user_7'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 7 days.')
            // return message
            */
            return default;
        }

        public async Task<TEntity> GetRangeDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def _get_range_dates(self, order):
            // # A method that can be overridden
            // # to set the start and end dates according to order values
            // return None, None
            */
            return default;
        }

        public async Task<TEntity> GetReconciledAmlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetReconciledInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_invoices(self):
            // """Helper used to retrieve the reconciled invoices on this journal entry"""
            // return self._get_reconciled_amls().move_id.filtered(lambda move: move.is_invoice(include_receipts=True))
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesPartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetReconciledPaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_payments(self):
            // """Helper used to retrieve the reconciled payments on this journal entry"""
            // return self._get_reconciled_amls().move_id.origin_payment_id
            */
            return default;
        }

        public async Task<TEntity> GetReconciledStatementLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_statement_lines(self):
            // """Helper used to retrieve the reconciled statement lines on this journal entry"""
            // return self._get_reconciled_amls().move_id.statement_line_id
            */
            return default;
        }

        public async Task<TEntity> GetReportBaseFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_report_base_filename(self):
            // self.ensure_one()
            // return f'{self.type_name} {self.name}'
            */
            return default;
        }

        public async Task<TEntity> GetRoundedBaseAndTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object round_from_tax_lines) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     tax_amls = self.line_ids.filtered('tax_repartition_line_id')
            //     tax_lines = [self._prepare_tax_line_for_taxes_computation(tax_line) for tax_line in tax_amls]
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id, tax_lines=tax_lines if round_from_tax_lines else [])
            // else:
            //     # The move is not stored yet so the only thing we have is the invoice lines.
            //     base_lines += self._prepare_epd_base_lines_for_taxes_computation_from_base_lines(base_amls)
            //     AccountTax._add_tax_details_in_base_lines(base_lines, self.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, self.company_id)
            // return base_lines, tax_lines
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderInvoicedAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _get_sale_order_invoiced_amount(self, order):
            // """
            // Consider all lines on any invoice in self that stem from the sales order `order`. (All those invoices belong to order.company_id)
            // This function returns the sum of the totals of all those lines.
            // Note that this amount may be bigger than `order.amount_total`.
            // """
            // order_amount = 0
            // for invoice in self:
            //     prices = sum(invoice.line_ids.filtered(lambda x: order in x.sale_line_ids.order_id).mapped('price_total'))
            //     order_amount += invoice.currency_id._convert(
            //         prices * -invoice.direction_sign,
            //         order.currency_id,
            //         invoice.company_id,
            //         invoice.date,
            //     )
            // return order_amount
            */
            return default;
        }

        public async Task<TEntity> GetSaleTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_sale_types(self, include_receipts=False):
            // return ['out_invoice', 'out_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetSequenceDateRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reset) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetSpecificTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object amount_type, object amount, object tax_type) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_specific_tax(self, name, amount_type, amount, tax_type):
            // AccountMoveLine = self.env['account.move.line']
            // if hasattr(AccountMoveLine, '_predict_specific_tax'):
            //     # company check is already done in the prediction query
            //     predicted_tax_id = AccountMoveLine._predict_specific_tax(
            //         self, name, self.partner_id, amount_type, amount, tax_type,
            //     )
            //     return self.env['account.tax'].browse(predicted_tax_id)
            // return self.env['account.tax']
            */
            return default;
        }

        public async Task<TEntity> GetStartingSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //     starting_sequence = "%s/%s/%02d/0000" % (self.journal_id.code, year_part, move_date.month)
            // if self.journal_id.refund_sequence and self.move_type in ('out_refund', 'in_refund'):
            //     starting_sequence = "R" + starting_sequence
            // if self.journal_id.payment_sequence and self.origin_payment_id or self.env.context.get('is_payment'):
            //     starting_sequence = "P" + starting_sequence
            // return starting_sequence
            --- ODOO METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py) ---
            // def _get_starting_sequence(self):
            // starting_sequence = super()._get_starting_sequence()
            // if (
            //     self.journal_id.debit_sequence
            //     and self.debit_origin_id
            //     and self.move_type in ("in_invoice", "out_invoice")
            // ):
            //     starting_sequence = "D" + starting_sequence
            // return starting_sequence
            */
            return default;
        }

        public async Task<TEntity> GetTitleFromUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _get_title_from_url(self, url):
            // preview = link_preview.get_link_preview_from_url(url)
            // if preview and preview.get('og_title'):
            //     return preview['og_title']
            // return url
            */
            return default;
        }

        public async Task<TEntity> GetUblCiiBuilderFromXmlTreeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _get_ubl_cii_builder_from_xml_tree(self, tree):
            // customization_id = tree.find('{*}CustomizationID')
            // if tree.tag == '{urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100}CrossIndustryInvoice':
            //     return self.env['account.edi.xml.cii']
            // ubl_version = tree.find('{*}UBLVersionID')
            // if ubl_version is not None:
            //     if ubl_version.text == '2.0':
            //         return self.env['account.edi.xml.ubl_20']
            //     if ubl_version.text in ('2.1', '2.2', '2.3'):
            //         return self.env['account.edi.xml.ubl_21']
            // if customization_id is not None:
            //     if 'xrechnung' in customization_id.text:
            //         return self.env['account.edi.xml.ubl_de']
            //     if customization_id.text == 'urn:cen.eu:en16931:2017#compliant#urn:fdc:nen.nl:nlcius:v1.0':
            //         return self.env['account.edi.xml.ubl_nl']
            //     if customization_id.text == 'urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:aunz:3.0':
            //         return self.env['account.edi.xml.ubl_a_nz']
            //     if customization_id.text == 'urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:sg:3.0':
            //         return self.env['account.edi.xml.ubl_sg']
            //     if 'urn:cen.eu:en16931:2017' in customization_id.text:
            //         return self.env['account.edi.xml.ubl_bis3']
            */
            return default;
        }

        public async Task<TEntity> GetUnbalancedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetUniqueNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model_name, object names) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_mixin.py) ---
            // def _get_unique_names(self, model_name, names):
            // """Generate unique names for the given model.
            // 
            // Take a list of names and return for each names, the new names to set
            // in the same order (with a counter added if needed).
            // 
            // E.G.
            //     The name "test" already exists in database
            //     Input: ['test', 'test [3]', 'bob', 'test', 'test']
            //     Output: ['test [2]', 'test [3]', 'bob', 'test [4]', 'test [5]']
            // 
            // :param model_name: name of the model for which we will generate unique names
            // :param names: list of names, we will ensure that each name will be unique
            // :return: a list of new values for each name, in the same order
            // """
            // # Avoid conflicting with itself, otherwise each check at update automatically
            // # increments counters
            // skip_record_ids = self.env.context.get("utm_check_skip_record_ids") or []
            // # Remove potential counter part in each names
            // names_without_counter = {self._split_name_and_count(name)[0] for name in names}
            // 
            // # Retrieve existing similar names
            // search_domain = expression.OR([[('name', 'ilike', name)] for name in names_without_counter])
            // if skip_record_ids:
            //     search_domain = expression.AND([
            //         [('id', 'not in', skip_record_ids)],
            //         search_domain
            //     ])
            // existing_names = {vals['name'] for vals in self.env[model_name].search_read(search_domain, ['name'])}
            // 
            // # Counter for each names, based on the names list given in argument
            // # and the record names in database
            // used_counters_per_name = {
            //     name: {
            //         self._split_name_and_count(existing_name)[1]
            //         for existing_name in existing_names
            //         if existing_name == name or existing_name.startswith(f'{name} [')
            //     } for name in names_without_counter
            // }
            // # Automatically incrementing counters for each name, will be used
            // # to fill holes in used_counters_per_name
            // current_counter_per_name = defaultdict(lambda: itertools.count(1))
            // 
            // result = []
            // for name in names:
            //     if not name:
            //         result.append(False)
            //         continue
            // 
            //     name_without_counter, asked_counter = self._split_name_and_count(name)
            //     existing = used_counters_per_name.get(name_without_counter, set())
            //     if asked_counter and asked_counter not in existing:
            //         count = asked_counter
            //     else:
            //         # keep going until the count is not already used
            //         for count in current_counter_per_name[name_without_counter]:
            //             if count not in existing:
            //                 break
            //     existing.add(count)
            //     result.append(f'{name_without_counter} [{count}]' if count > 1 else name_without_counter)
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetUnlinkLoggerMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_unlink_logger_message(self):
            // """ Before unlink, get a log message for audit trail if it's enabled.
            // Logger is added here because in api ondelete, account.move.line is deleted, and we can't get total amount """
            // if not self._context.get('force_delete'):
            //     pass
            // 
            // moves_details = []
            // for move in self.filtered(lambda m: m.posted_before and m.company_id.check_account_audit_trail):
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

        public async Task<TEntity> GetUpdatePricesLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_update_prices_lines(self):
            // """ Hook to exclude specific lines which should not be updated based on price list recomputation """
            // return self.order_line.filtered(lambda line: not line.display_type)
            */
            return default;
        }

        public async Task<TEntity> GetUrlFromCodeAsync<TEntity>(IEnumerable<TEntity> entities, object code) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def get_url_from_code(self, code):
            // code_rec = self.env['link.tracker.code'].sudo().search([('code', '=', code)])
            // 
            // if not code_rec:
            //     return None
            // 
            // return code_rec.link_id.redirected_url
            */
            return default;
        }

        public async Task<TEntity> GetValidJournalTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // if view_type == 'form' and self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer')\
            //     and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     view_id = self.env.ref('hr_recruitment.hr_applicant_view_form_interviewer').id
            // return super().get_view(view_id, view_type, **options)
            */
            return default;
        }

        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // arch, view = super()._get_view(view_id, view_type, **options)
            // if view_type == 'form':
            //     if name_node := arch.xpath("""//field[@name="name"][@invisible="name == '/' and not posted_before and not quick_edit_mode"]"""):
            //         name_node[0].set('invisible', "not (name or name_placeholder or quick_edit_mode)")
            //     if draft_node := arch.xpath("""//span[@invisible="name == '/' and not posted_before and not quick_edit_mode"]"""):
            //         draft_node[0].set('invisible', "name or name_placeholder or quick_edit_mode")
            // return arch, view
            */
            return default;
        }

        public async Task<TEntity> GetViolatedLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> HandlePartnerAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid force_partner_id, object create_missing) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_partner_assignment(self, force_partner_id=False, create_missing=True):
            // """ Update customer (partner_id) of leads. Purpose is to set the same
            // partner on most leads; either through a newly created partner either
            // through a given partner_id.
            // 
            // :param int force_partner_id: if set, update all leads to that customer;
            // :param create_missing: for leads without customer, create a new one
            //   based on lead information;
            // """
            // for lead in self:
            //     if force_partner_id:
            //         lead.partner_id = force_partner_id
            //     if not lead.partner_id and create_missing:
            //         partner = lead._create_customer()
            //         lead.partner_id = partner.id
            */
            return default;
        }

        public async Task<TEntity> HandleSalesmenAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_salesmen_assignment(self, user_ids=False, team_id=False):
            // """ Assign salesmen and salesteam to a batch of leads.  If there are more
            // leads than salesmen, these salesmen will be assigned in round-robin. E.g.
            // 4 salesmen (S1, S2, S3, S4) for 6 leads (L1, L2, ... L6) will assigned as
            // following: L1 - S1, L2 - S2, L3 - S3, L4 - S4, L5 - S1, L6 - S2.
            // 
            // :param list user_ids: salesmen to assign
            // :param int team_id: salesteam to assign
            // """
            // update_vals = {'team_id': team_id} if team_id else {}
            // if not user_ids and team_id:
            //     self.write(update_vals)
            // else:
            //     lead_ids = self.ids
            //     steps = len(user_ids)
            //     # pass 1 : lead_ids[0:6:3] = [L1,L4]
            //     # pass 2 : lead_ids[1:6:3] = [L2,L5]
            //     # pass 3 : lead_ids[2:6:3] = [L3,L6]
            //     # ...
            //     for idx in range(0, steps):
            //         subset_ids = lead_ids[idx:len(lead_ids):steps]
            //         update_vals['user_id'] = user_ids[idx]
            //         self.env['crm.lead'].browse(subset_ids).write(update_vals)
            */
            return default;
        }

        public async Task<TEntity> HandleWonLostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_won_lost(self, vals):
            // """ This method handle the state changes :
            // - To lost : We need to increment corresponding lost count in scoring frequency table
            // - To won : We need to increment corresponding won count in scoring frequency table
            // - From lost to Won : We need to decrement corresponding lost count + increment corresponding won count
            // in scoring frequency table.
            // - From won to lost : We need to decrement corresponding won count + increment corresponding lost count
            // in scoring frequency table."""
            // Lead = self.env['crm.lead']
            // leads_reach_won = Lead
            // leads_leave_won = Lead
            // leads_reach_lost = Lead
            // leads_leave_lost = Lead
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead in self:
            //     if 'stage_id' in vals:
            //         if vals['stage_id'] in won_stage_ids:
            //             if lead.probability == 0:
            //                 leads_leave_lost += lead
            //             leads_reach_won += lead
            //         elif lead.stage_id.id in won_stage_ids and lead.active:  # a lead can be lost at won_stage
            //             leads_leave_won += lead
            //     if 'active' in vals:
            //         if not vals['active'] and lead.active:  # archive lead
            //             if lead.stage_id.id in won_stage_ids and lead not in leads_leave_won:
            //                 leads_leave_won += lead
            //             leads_reach_lost += lead
            //         elif vals['active'] and not lead.active:  # restore lead
            //             leads_leave_lost += lead
            // 
            // leads_reach_won._pls_increment_frequencies(to_state='won')
            // leads_leave_won._pls_increment_frequencies(from_state='won')
            // leads_reach_lost._pls_increment_frequencies(to_state='lost')
            // leads_leave_lost._pls_increment_frequencies(from_state='lost')
            */
            return default;
        }

        public async Task<TEntity> HasToBePaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _has_to_be_paid(self):
            // """A sale order has to be paid when:
            // - its state is 'draft' or `sent`;
            // - it's not expired;
            // - it requires a payment;
            // - the last transaction's state isn't `done`;
            // - the total amount is strictly positive.
            // - confirmation amount is not reached
            // 
            // Note: self.ensure_one()
            // 
            // :return: Whether the sale order has to be paid.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return (
            //     self.state in ['draft', 'sent']
            //     and not self.is_expired
            //     and self.require_payment
            //     and self.amount_total > 0
            //     and not self._is_confirmation_amount_reached()
            // )
            */
            return default;
        }

        public async Task<TEntity> HasToBeSignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _has_to_be_signed(self):
            // """A sale order has to be signed when:
            // - its state is 'draft' or `sent`
            // - it's not expired;
            // - it requires a signature;
            // - it's not already signed.
            // 
            // Note: self.ensure_one()
            // 
            // :return: Whether the sale order has to be signed.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return (
            //     self.state in ['draft', 'sent']
            //     and not self.is_expired
            //     and self.require_signature
            //     and not self.signature
            // )
            */
            return default;
        }

        public async Task<TEntity> HashMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _hash_moves(self, **kwargs):
            // chains_to_hash = self._get_chains_to_hash(**kwargs)
            // grant_secure_group_access = False
            // for chain in chains_to_hash:
            //     move_hashes = chain['moves']._calculate_hashes(chain['previous_hash'])
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

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def init(self):
            // super().init()
            // self.env.cr.execute("""
            //     CREATE INDEX IF NOT EXISTS hr_applicant_job_id_stage_id_idx
            //     ON hr_applicant(job_id, stage_id)
            //     WHERE active IS TRUE
            // """)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def init(self):
            // create_index(self._cr, 'sale_order_date_order_id_idx', 'sale_order', ["date_order desc", "id desc"])
            */
            return default;
        }

        public async Task<TEntity> InverseAmountTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> InverseCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _inverse_code(self):
            // self.ensure_one()
            // if not self.code:
            //     return
            // record = self.env['link.tracker.code'].search([('link_id', '=', self.id)], limit=1, order='id DESC')
            // if record:
            //     record.code = self.code
            */
            return default;
        }

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> InverseCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> InverseEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_email_from(self):
            // for lead in self:
            //     if lead._get_partner_email_update(force_void=False):
            //         lead.partner_id.email = lead.email_from
            */
            return default;
        }

        public async Task<TEntity> InverseInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> InverseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _inverse_name(self):
            // for applicant in self:
            //     if applicant.partner_name and not applicant.candidate_id:
            //         applicant.candidate_id = self.env['hr.candidate'].create({'partner_name': applicant.partner_name})
            //     else:
            //         applicant.candidate_id.partner_name = applicant.partner_name
            */
            return default;
        }

        public async Task<TEntity> InversePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> InversePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> InversePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_phone(self):
            // for lead in self:
            //     if lead._get_partner_phone_update(force_void=False):
            //         lead.partner_id.phone = lead.phone
            */
            return default;
        }

        public async Task<TEntity> InverseTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //                     delta_amount = tax_group_old_amount * sign - tax_group['tax_amount_currency']
            // 
            //                     if not move.currency_id.is_zero(delta_amount):
            //                         first_tax_line.amount_currency -= delta_amount * sign
            //     self._compute_amount()
            */
            return default;
        }

        public async Task<TEntity> InvoicePaidHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _invoice_paid_hook(self):
            // # OVERRIDE
            // res = super(AccountMove, self)._invoice_paid_hook()
            // todo = set()
            // for invoice in self.filtered(lambda move: move.is_invoice()):
            //     for line in invoice.invoice_line_ids:
            //         for sale_line in line.sale_line_ids:
            //             todo.add((sale_line.order_id, invoice.name))
            // for (order, name) in todo:
            //     order.message_post(body=_("Invoice %s paid", name))
            // return res
            */
            return default;
        }

        public async Task<TEntity> InvoiceValidateSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product_email_template, FILE: account_move.py) ---
            // def invoice_validate_send_email(self):
            // if self.env.su:
            //     # sending mail in sudo was meant for it being sent from superuser
            //     self = self.with_user(SUPERUSER_ID)
            // for invoice in self.filtered(lambda x: x.move_type == 'out_invoice'):
            //     # send template only on customer invoice
            //     # subscribe the partner to the invoice
            //     if invoice.partner_id not in invoice.message_partner_ids:
            //         invoice.message_subscribe([invoice.partner_id.id])
            //     comment_subtype_id = self.env['ir.model.data']._xmlid_to_res_id('mail.mt_comment')
            //     for line in invoice.invoice_line_ids:
            //         if line.product_id.email_template_id:
            //             invoice.message_post_with_source(
            //                 line.product_id.email_template_id,
            //                 email_layout_xmlid="mail.mail_notification_light",
            //                 subtype_id=comment_subtype_id,
            //             )
            // return True
            */
            return default;
        }

        public async Task<TEntity> IsConfirmationAmountReachedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _is_confirmation_amount_reached(self):
            // """ Return whether `self.amount_paid` is higher than the prepayment required amount.
            // 
            // Note: self.ensure_one()
            // 
            // :return: Whether `self.amount_paid` is higher than the prepayment required amount.
            // :rtype: bool
            // """
            // self.ensure_one()
            // amount_comparison = self.currency_id.compare_amounts(
            //     self._get_prepayment_required_amount(), self.amount_paid,
            // )
            // return amount_comparison <= 0
            */
            return default;
        }

        public async Task<TEntity> IsDownpaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _is_downpayment(self):
            // # OVERRIDE
            // self.ensure_one()
            // return self.line_ids.sale_line_ids and all(sale_line.is_downpayment for sale_line in self.line_ids.sale_line_ids) or False
            */
            return default;
        }

        public async Task<TEntity> IsEligibleForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object currency, object reference_date) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_eligible_for_early_payment_discount(self, currency, reference_date):
            // self.ensure_one()
            // payment_terms = self.line_ids.filtered(lambda line: line.display_type == 'payment_term')
            // return self.currency_id == currency \
            //     and self.move_type in ('out_invoice', 'out_receipt', 'in_invoice', 'in_receipt') \
            //     and self.invoice_payment_term_id.early_discount \
            //     and (
            //         not reference_date
            //         or not self.invoice_date
            //         or reference_date <= self.invoice_payment_term_id._get_last_discount_date(self.invoice_date)
            //     ) \
            //     and not (payment_terms.sudo().matched_debit_ids + payment_terms.sudo().matched_credit_ids)
            */
            return default;
        }

        public async Task<TEntity> IsEntryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_entry(self):
            // return self.move_type == 'entry'
            */
            return default;
        }

        public async Task<TEntity> IsInboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_inbound(self, include_receipts=True):
            // return self.move_type in self.get_inbound_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_invoice(self, include_receipts=False):
            // return self.is_sale_document(include_receipts) or self.is_purchase_document(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsMoveRestrictedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object force_hash) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> IsOutboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_outbound(self, include_receipts=True):
            // return self.move_type in self.get_outbound_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _is_paid(self):
            // """ Return whether the sale order is paid or not based on the linked transactions.
            // 
            // A sale order is considered paid if the sum of all the linked transaction is equal to or
            // higher than `self.amount_total`.
            // 
            // :return: Whether the sale order is paid or not.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return self.currency_id.compare_amounts(self.amount_paid, self.amount_total) >= 0
            */
            return default;
        }

        public async Task<TEntity> IsProtectedByAuditTrailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_protected_by_audit_trail(self):
            // return any(move.posted_before and move.company_id.check_account_audit_trail for move in self)
            */
            return default;
        }

        public async Task<TEntity> IsPurchaseDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_purchase_document(self, include_receipts=False):
            // return self.move_type in self.get_purchase_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _is_readonly(self):
            // """ Return Whether the sale order is read-only or not based on the state or the lock status.
            // 
            // A sale order is considered read-only if its state is 'cancel' or if the sale order is
            // locked.
            // 
            // :return: Whether the sale order is read-only or not.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return self.state == 'cancel' or self.locked
            */
            return default;
        }

        public async Task<TEntity> IsReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _is_ready_to_be_sent(self):
            // # OVERRIDE
            // # Prevent a mail to be sent to the customer if the EDI document is not sent.
            // res = super()._is_ready_to_be_sent()
            // 
            // if not res:
            //     return False
            // 
            // edi_documents_to_send = self.edi_document_ids.filtered(lambda x: x.state == 'to_send')
            // return not bool(edi_documents_to_send)
            */
            return default;
        }

        public async Task<TEntity> IsSaleDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_sale_document(self, include_receipts=False):
            // return self.move_type in self.get_sale_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> JsAssignOutstandingLineAsync<TEntity>(IEnumerable<TEntity> entities, Guid line_id) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> JsRemoveOutstandingPartialAsync<TEntity>(IEnumerable<TEntity> entities, Guid partial_id) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> LinkBillOriginToPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timeout) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _link_bill_origin_to_purchase_orders(self, timeout=10):
            // for move in self.filtered(lambda m: m.move_type in self.get_purchase_types()):
            //     references = [move.invoice_origin] if move.invoice_origin else []
            //     move._find_and_set_purchase_orders(references, move.partner_id.id, move.amount_total, timeout=timeout)
            // return self
            */
            return default;
        }

        public async Task<TEntity> LinkTimesheetsToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py) ---
            // def _link_timesheets_to_invoice(self, start_date=None, end_date=None):
            // """ Search timesheets from given period and link this timesheets to the invoice
            // 
            //     When we create an invoice from a sale order, we need to
            //     link the timesheets in this sale order to the invoice.
            //     Then, we can know which timesheets are invoiced in the sale order.
            //     :param start_date: the start date of the period
            //     :param end_date: the end date of the period
            // """
            // for line in self.filtered(lambda i: i.move_type == 'out_invoice' and i.state == 'draft').invoice_line_ids:
            //     sale_line_delivery = line.sale_line_ids.filtered(lambda sol: sol.product_id.invoice_policy == 'delivery' and sol.product_id.service_type == 'timesheet')
            //     if not start_date and not end_date:
            //         start_date, end_date = self._get_range_dates(sale_line_delivery.order_id)
            //     if sale_line_delivery:
            //         domain = line._timesheet_domain_get_invoiced_lines(sale_line_delivery)
            //         if start_date:
            //             domain = expression.AND([domain, [('date', '>=', start_date)]])
            //         if end_date:
            //             domain = expression.AND([domain, [('date', '<=', end_date)]])
            //         timesheets = self.env['account.analytic.line'].sudo().search(domain)
            //         timesheets.write({'timesheet_invoice_id': line.move_id.id})
            */
            return default;
        }

        public async Task<TEntity> LogMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object meeting) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def log_meeting(self, meeting):
            // """ Log the meeting info with a link to it in the chatter
            // :param record meeting: the meeting we want to log
            // """
            // if not meeting.duration:
            //     duration = _('unknown')
            // else:
            //     duration = self.env['ir.qweb.field.duration'].value_to_html(meeting.duration, {'unit': 'hour'})
            // meeting_usertime = fields.Datetime.to_string(fields.Datetime.context_timestamp(self, meeting.start))
            // meeting_time = Markup("<time datetime='%(meeting_start)s+00:00'>%(meeting_user_time)s</time>") % {
            //     'meeting_start': meeting.start,
            //     'meeting_user_time': meeting_usertime,
            // }
            // message = Markup("<p>%(meeting)s<br/>%(subject_string)s %(subject_link)s<br/>%(duration)s<p>") % {
            //     'meeting': _("Meeting scheduled at %s", meeting_time),
            //     'subject_string': _("Subject: "),
            //     'subject_link': meeting._get_html_link(),
            //     'duration': _("Duration: %s", duration),
            // }
            // return self.message_post(body=message)
            */
            return default;
        }

        public async Task<TEntity> MailingGetDefaultDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mailing) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _mailing_get_default_domain(self, mailing):
            // return ['&', ('move_type', '=', 'out_invoice'), ('state', '=', 'posted')]
            */
            return default;
        }

        public async Task<TEntity> MatchPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _match_purchase_orders(self, po_references, partner_id, amount_total, from_ocr, timeout):
            // """Tries to match open purchase order lines with this invoice given the information we have.
            // 
            // :param po_references: a list of potential purchase order references/names
            // :param partner_id: the vendor id inferred from the vendor bill
            // :param amount_total: the total amount of the vendor bill
            // :param from_ocr: indicates whether this vendor bill was created from an OCR scan (less reliable)
            // :param timeout: the max time the line matching algorithm can take before timing out
            // :return: tuple (str, recordset, dict) containing:
            //     * the match method:
            //         * `total_match`: purchase order reference(s) and total amounts match perfectly
            //         * `subset_total_match`: a subset of the referenced purchase orders' lines matches the total amount of
            //             this invoice (OCR only)
            //         * `po_match`: only the purchase order reference matches (OCR only)
            //         * `subset_match`: a subset of the referenced purchase orders' lines matches a subset of the invoice
            //             lines based on unit prices (EDI only)
            //         * `no_match`: no result found
            //     * recordset of `purchase.order.line` containing purchase order lines matched with an invoice line
            //     * list of tuple containing every `purchase.order.line` id and its related `account.move.line`
            // """
            // 
            // common_domain = [
            //     ('company_id', '=', self.company_id.id),
            //     ('state', 'in', ('purchase', 'done')),
            //     ('invoice_status', 'in', ('to invoice', 'no'))
            // ]
            // 
            // matching_purchase_orders = self.env['purchase.order']
            // 
            // # We have purchase order references in our vendor bill and a total amount.
            // if po_references and amount_total:
            //     # We first try looking for purchase orders whose names match one of the purchase order references in the
            //     # vendor bill.
            //     matching_purchase_orders |= self.env['purchase.order'].search(
            //         common_domain + [('name', 'in', po_references)])
            // 
            //     if not matching_purchase_orders:
            //         # If not found, we try looking for purchase orders whose `partner_ref` field matches one of the
            //         # purchase order references in the vendor bill.
            //         matching_purchase_orders |= self.env['purchase.order'].search(
            //             common_domain + [('partner_ref', 'in', po_references)])
            // 
            //     if matching_purchase_orders:
            //         # We found matching purchase orders and are extracting all purchase order lines together with their
            //         # amounts still to be invoiced.
            //         po_lines = [line for line in matching_purchase_orders.order_line if line.product_qty]
            //         po_lines_with_amount = [{
            //             'line': line,
            //             'amount_to_invoice': (1 - line.qty_invoiced / line.product_qty) * line.price_total,
            //         } for line in po_lines]
            // 
            //         # If the sum of all remaining amounts to be invoiced for these purchase orders' lines is within a
            //         # tolerance from the vendor bill total, we have a total match. We return all purchase order lines
            //         # summing up to this vendor bill's total (could be from multiple purchase orders).
            //         if (amount_total - TOLERANCE
            //                 < sum(line['amount_to_invoice'] for line in po_lines_with_amount)
            //                 < amount_total + TOLERANCE):
            //             return 'total_match', matching_purchase_orders.order_line, None
            // 
            //         elif from_ocr:
            //             # The invoice comes from an OCR scan.
            //             # We try to match the invoice total with purchase order lines.
            //             matching_po_lines = self._find_matching_subset_po_lines(
            //                 po_lines_with_amount, amount_total, timeout)
            //             if matching_po_lines:
            //                 return 'subset_total_match', self.env['purchase.order.line'].union(*matching_po_lines), None
            //             else:
            //                 # We did not find a match for the invoice total.
            //                 # We return all purchase order lines based only on the purchase order reference(s) in the
            //                 # vendor bill.
            //                 return 'po_match', matching_purchase_orders.order_line, None
            // 
            //         else:
            //             # We have an invoice from an EDI document, so we try to match individual invoice lines with
            //             # individual purchase order lines from referenced purchase orders.
            //             matching_po_lines, matching_inv_lines = self._find_matching_po_and_inv_lines(
            //                 po_lines, self.invoice_line_ids, timeout)
            // 
            //             if matching_po_lines:
            //                 # We found a subset of purchase order lines that match a subset of the vendor bill lines.
            //                 # We return the matching purchase order lines and vendor bill lines.
            //                 return ('subset_match',
            //                         self.env['purchase.order.line'].union(*matching_po_lines),
            //                         matching_inv_lines)
            // 
            // # As a last resort we try matching a purchase order by vendor and total amount.
            // if partner_id and amount_total:
            //     purchase_id_domain = common_domain + [
            //         ('partner_id', 'child_of', [partner_id]),
            //         ('amount_total', '>=', amount_total - TOLERANCE),
            //         ('amount_total', '<=', amount_total + TOLERANCE)
            //     ]
            //     matching_purchase_orders = self.env['purchase.order'].search(purchase_id_domain)
            //     if len(matching_purchase_orders) == 1:
            //         # We found exactly one match on vendor and total amount (within tolerance).
            //         # We return all purchase order lines of the purchase order whose total amount matched our vendor bill.
            //         return 'total_match', matching_purchase_orders.order_line, None
            // 
            // # We couldn't find anything, so we return no lines.
            // return ('no_match', matching_purchase_orders.order_line, None)
            */
            return default;
        }

        public async Task<TEntity> MergeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_data(self, fnames=None):
            // """ Prepare lead/opp data into a dictionary for merging. Different types
            //     of fields are processed in different ways:
            //         - text: all the values are concatenated
            //         - m2m and o2m: those fields aren't processed
            //         - m2o: the first not null value prevails (the other are dropped)
            //         - any other type of field: same as m2o
            // 
            //     :param fields: list of fields to process
            //     :return dict data: contains the merged values of the new opportunity
            // """
            // if fnames is None:
            //     fnames = self._merge_get_fields()
            // fcallables = self._merge_get_fields_specific()
            // address_values = self._merge_get_fields_address()
            // 
            // # helpers
            // def _get_first_not_null(attr, opportunities):
            //     value = False
            //     for opp in opportunities:
            //         if opp[attr]:
            //             value = opp[attr].id if isinstance(opp[attr], models.BaseModel) else opp[attr]
            //             break
            //     return value
            // 
            // # process the field's values
            // data = {}
            // for field_name in fnames:
            //     field = self._fields.get(field_name)
            //     if field is None:
            //         continue
            // 
            //     fcallable = fcallables.get(field_name)
            //     if fcallable and callable(fcallable):
            //         data[field_name] = fcallable(field_name, self)
            //     elif field_name in address_values:
            //         data[field_name] = address_values[field_name]
            //     elif not fcallable and field.type in ('many2many', 'one2many'):
            //         continue
            //     else:
            //         data[field_name] = _get_first_not_null(field_name, self)  # take the first not null
            // 
            // return data
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_attachments(self, opportunities):
            // """ Move attachments of given opportunities to the current one `self`, and rename
            //     the attachments having same name than native ones.
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // 
            // all_attachments = self.env['ir.attachment'].search([
            //     ('res_model', '=', self._name),
            //     ('res_id', 'in', opportunities.ids)
            // ])
            // 
            // for opportunity in opportunities:
            //     attachments = all_attachments.filtered(lambda attach: attach.res_id == opportunity.id)
            //     for attachment in attachments:
            //         attachment.write({
            //             'res_id': self.id,
            //             'name': _("%(attach_name)s (from %(lead_name)s)",
            //                       attach_name=attachment.name,
            //                       lead_name=opportunity.name[:20]
            //                      )
            //         })
            // return True
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_calendar_events(self, opportunities):
            // """ Move calender.event from the given opportunities to the current one. `self` is the
            //     crm.lead record destination for event of `opportunities`.
            // :param opportunities: see ``merge_dependences``
            // """
            // self.ensure_one()
            // meetings = self.env['calendar.event'].search([('opportunity_id', 'in', opportunities.ids)])
            // return meetings.write({
            //     'res_id': self.id,
            //     'opportunity_id': self.id,
            // })
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_history(self, opportunities):
            // """ Move history from the given opportunities to the current one. `self`
            // is the crm.lead record destination for message of `opportunities`.
            // 
            // This method moves
            //   * messages
            //   * activities
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // # sudo usage: because we want to go through all messages, whatever the real ACLs
            // # current user has on them
            // for opportunity_su in opportunities.sudo():
            //     for message_su in opportunity_su.message_ids:
            //         if message_su.subject:
            //             subject = _("From %(source_name)s: %(source_subject)s", source_name=opportunity_su.name, source_subject=message_su.subject)
            //         else:
            //             subject = _("From %(source_name)s", source_name=opportunity_su.name)
            //         message_su.write({
            //             'res_id': self.id,
            //             'subject': subject,
            //         })
            // opportunities.activity_ids.write({
            //     'res_id': self.id,
            // })
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences(self, opportunities):
            // """ Merge dependences (messages, attachments,activities, calendar events,
            // ...). These dependences will be transfered to `self` considered as the
            // master lead.
            // 
            // :param opportunities : recordset of opportunities to transfer. Does not
            //   include `self` which is the target crm.lead being the result of the
            //   merge;
            // """
            // self.ensure_one()
            // self._merge_dependences_history(opportunities)
            // self._merge_dependences_attachments(opportunities)
            // self._merge_dependences_calendar_events(opportunities)
            */
            return default;
        }

        public async Task<TEntity> MergeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_followers(self, opportunities):
            // """Add the followers into the destination lead if they post a message in the last 30 days.
            // 
            // :param opportunities : Record<crm.lead> of opportunities to transfer
            // :return: {old_lead_id: Record<mail.followers>} Followers which have been added in
            //     the destination lead grouped by source lead ID.
            // """
            // self.ensure_one()
            // 
            // self.env['mail.message'].flush_model()
            // self.env['mail.followers'].flush_model()
            // 
            // # Get the active followers (followers whose partner post a message on the
            // # leads in the last 30 days) which should be moved on the destination lead
            // self.env.cr.execute(
            //     '''
            //     SELECT MAX(mf.id) AS id
            //       FROM mail_followers AS mf
            //       JOIN mail_message AS mm
            //         ON mm.author_id = mf.partner_id
            //        AND mm.res_id = mf.res_id
            //        AND mm.model = 'crm.lead'
            //        AND mm.date > NOW() - INTERVAL '30 DAY'
            //            /* Check if the partner is already
            //               following the destination lead */
            //  LEFT JOIN mail_followers AS destf
            //         ON destf.res_model = 'crm.lead'
            //        AND destf.res_id = %(lead_id)s
            //        AND destf.partner_id = mf.partner_id
            //            /* Select only once each partner
            //               to not create duplicated followers */
            //      WHERE mf.res_model = 'crm.lead'
            //        AND mf.res_id IN %(lead_ids)s
            //        AND destf IS NULL
            //   GROUP BY mf.partner_id
            //     ''',
            //     {'lead_ids': tuple(opportunities.ids), 'lead_id': self.id},
            // )
            // followers_to_update = [r[0] for r in self.env.cr.fetchall()]
            // followers_to_update = self.env['mail.followers'].browse(followers_to_update).sudo()
            // followers_by_old_lead = dict(groupby(followers_to_update, lambda f: f.res_id))
            // followers_to_update.write({'res_id': self.id})
            // return followers_by_old_lead
            #endif
            return default;
        }

        public async Task<TEntity> MergeGetFieldsAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_address(self):
            // """The address fields are propagated as a whole.
            // 
            // The address is taken from the lead with the most non-empty address field
            // (sorted by highest rank if multiple lead have the same amount of non-empty
            // fields).
            // """
            // source_lead = max(self, key=lambda lead: len(list(
            //     lead[field] for field in PARTNER_ADDRESS_FIELDS_TO_SYNC
            //     if lead[field]
            // )))
            // return {fname: source_lead[fname] for fname in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // return (
            //     CRM_LEAD_FIELDS_TO_MERGE
            //     + list(self._merge_get_fields_specific().keys())
            //     + PARTNER_ADDRESS_FIELDS_TO_SYNC
            // )
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsSpecificInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_specific(self):
            // return {
            //     'description': lambda fname, leads: '<br/><br/>'.join(desc for desc in leads.mapped('description') if not is_html_empty(desc)),
            //     'type': lambda fname, leads: 'opportunity' if any(lead.type == 'opportunity' for lead in leads) else 'lead',
            //     'priority': lambda fname, leads: max(priorities) if (priorities := leads.filtered('priority').mapped('priority')) else False,
            //     'tag_ids': lambda fname, leads: leads.mapped('tag_ids'),
            //     'lost_reason_id': lambda fname, leads:
            //         False if leads and leads[0].probability
            //         else next((lead.lost_reason_id for lead in leads if lead.lost_reason_id), False),
            // }
            */
            return default;
        }

        public async Task<TEntity> MergeLogSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object merged_followers, object opportunities_tail) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_log_summary(self, merged_followers, opportunities_tail):
            // """Log the merge message on the lead."""
            // self.ensure_one()
            // self.message_post_with_source(
            //     "crm.crm_lead_merge_summary",
            //     render_values={
            //         "merged_followers": merged_followers,
            //         "opportunities": opportunities_tail,
            //         "is_html_empty": is_html_empty,
            //     },
            //     subtype_xmlid='mail.mt_note',
            // )
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True):
            // """ Merge opportunities in one. Different cases of merge:
            //         - merge leads together = 1 new lead
            //         - merge at least 1 opp with anything else (lead or opp) = 1 new opp
            //     The resulting lead/opportunity will be the most important one (based on its confidence level)
            //     updated with values from other opportunities to merge.
            // 
            // :param user_id : the id of the saleperson. If not given, will be determined by `_merge_data`.
            // :param team : the id of the Sales Team. If not given, will be determined by `_merge_data`.
            // 
            // :return crm.lead record resulting of th merge
            // """
            // return self._merge_opportunity(user_id=user_id, team_id=team_id, auto_unlink=auto_unlink)
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink, object max_length) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True, max_length=5):
            // """ Private merging method. This one allows to relax rules on record set
            // length allowing to merge more than 5 opportunities at once if requested.
            // This should not be called by action buttons.
            // 
            // See ``merge_opportunity`` for more details. """
            // if len(self.ids) <= 1:
            //     raise UserError(_('Select at least two Leads/Opportunities from the list to merge them.'))
            // 
            // if max_length and len(self.ids) > max_length and not self.env.is_superuser():
            //     raise UserError(_("To prevent data loss, Leads and Opportunities can only be merged by groups of %(max_length)s.", max_length=max_length))
            // 
            // opportunities = self._sort_by_confidence_level(reverse=True)
            // 
            // # get SORTED recordset of head and tail, and complete list
            // opportunities_head = opportunities[0]
            // opportunities_tail = opportunities[1:]
            // 
            // # merge all the sorted opportunity. This means the value of
            // # the first (head opp) will be a priority.
            // merged_data = opportunities._merge_data(self._merge_get_fields())
            // 
            // # force value for saleperson and Sales Team
            // if user_id:
            //     merged_data['user_id'] = user_id
            // if team_id:
            //     merged_data['team_id'] = team_id
            // 
            // merged_followers = opportunities_head._merge_followers(opportunities_tail)
            // 
            // # log merge message
            // opportunities_head._merge_log_summary(merged_followers, opportunities_tail)
            // # merge other data (mail.message, attachments, ...) from tail into head
            // opportunities_head._merge_dependences(opportunities_tail)
            // 
            // # check if the stage is in the stages of the Sales Team. If not, assign the stage with the lowest sequence
            // if merged_data.get('team_id'):
            //     team_stage_ids = self.env['crm.stage'].search(['|', ('team_id', '=', merged_data['team_id']), ('team_id', '=', False)], order='sequence, id')
            //     if merged_data.get('stage_id') not in team_stage_ids.ids:
            //         merged_data['stage_id'] = team_stage_ids[0].id if team_stage_ids else False
            // 
            // # write merged data into first opportunity; remove some keys if already
            // # set on opp to avoid useless recomputes
            // if 'user_id' in merged_data and opportunities_head.user_id.id == merged_data['user_id']:
            //     merged_data.pop('user_id')
            // if 'team_id' in merged_data and opportunities_head.team_id.id == merged_data['team_id']:
            //     merged_data.pop('team_id')
            // opportunities_head.write(merged_data)
            // 
            // # delete tail opportunities
            // # we use the SUPERUSER to avoid access rights issues because as the user had the rights to see the records it should be safe to do so
            // if auto_unlink:
            //     opportunities_tail.sudo().unlink()
            // 
            // return opportunities_head
            */
            return default;
        }

        public async Task<TEntity> MessageGetDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_default_recipients(self):
            // return {
            //     r.id: {
            //         'partner_ids': [],
            //         'email_to': ','.join(tools.email_normalize_all(r.email_from)) or r.email_from,
            //         'email_cc': False,
            //     } for r in self
            // }
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // try:
            //     # check if that language is correctly installed (and active) before using it
            //     lang_code = self.env['res.lang']._get_data(code=self.lang_code).code or None
            //     if self.partner_id:
            //         self._message_add_suggested_recipient(
            //             recipients, partner=self.partner_id, lang=lang_code, reason=_('Customer'))
            //     elif self.email_from:
            //         self._message_add_suggested_recipient(
            //             recipients, email=self.email_from, lang=lang_code, reason=_('Customer Email'))
            // except AccessError:  # no read access rights -> just ignore suggested recipients because this imply modifying followers
            //     pass
            // return recipients
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     self._message_add_suggested_recipient(recipients, partner=self.partner_id.sudo(), reason=_('Contact'))
            // elif self.email_from:
            //     email_from = tools.email_normalize(self.email_from)
            //     if email_from and self.partner_name:
            //         email_from = tools.formataddr((self.partner_name, email_from))
            //         self._message_add_suggested_recipient(recipients, email=email_from, reason=_('Contact Email'))
            // return recipients
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     self._message_add_suggested_recipient(
            //         recipients, partner=self.partner_id, reason=_("Customer")
            //     )
            // return recipients
            */
            return default;
        }

        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg, object custom_values) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
            // # remove default author when going through the mail gateway. Indeed we
            // # do not want to explicitly set an user as responsible. We prefer that
            // # assignment is done automatically (scoring) or manually. Otherwise it
            // # would always be root (gateway user). It also allows to exclude portal
            // # and public users.
            // self = self.with_context(default_user_id=False)
            // 
            // if custom_values is None:
            //     custom_values = {}
            // defaults = {
            //     'name':  msg_dict.get('subject') or _("No Subject"),
            //     'email_from': msg_dict.get('from'),
            //     'partner_id': msg_dict.get('author_id', False),
            // }
            // if msg_dict.get('priority') in dict(crm_stage.AVAILABLE_PRIORITIES):
            //     defaults['priority'] = msg_dict.get('priority')
            // defaults.update(custom_values)
            // 
            // return super(Lead, self).message_new(msg_dict, custom_values=defaults)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def message_new(self, msg, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
            // # Remove default author when going through the mail gateway. Indeed, we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // self = self.with_context(default_user_id=False, mail_notify_author=True)  # Allows sending stage updates to the author
            // stage = False
            // candidate_defaults = {}
            // partner_name, email_from_normalized = tools.parse_contact_from_email(msg.get('from'))
            // candidate_domain = [
            //     ("email_from", "=", email_from_normalized),
            // ]
            // if custom_values and 'job_id' in custom_values:
            //     job = self.env['hr.job'].browse(custom_values['job_id'])
            //     stage = job._get_first_stage()
            //     candidate_defaults['company_id'] = job.company_id.id
            //     candidate_domain = expression.AND([candidate_domain, [("company_id", "in", [job.company_id.id, False])]])
            // 
            // candidate = self.env["hr.candidate"].search(candidate_domain, limit=1)\
            //     or self.env["hr.candidate"].create({
            //         "partner_name": partner_name or email_from_normalized,
            //         **candidate_defaults,
            //     })
            // 
            // defaults = {
            //     'candidate_id': candidate.id,
            //     'partner_name': partner_name,
            // }
            // job_platform = self.env['hr.job.platform'].search([('email', '=', email_from_normalized)], limit=1)
            // if msg.get('from') and not job_platform:
            //     candidate.email_from = msg.get('from')
            //     candidate.partner_id = msg.get('author_id', False)
            // if msg.get('email_from') and job_platform:
            //     subject_pattern = re.compile(job_platform.regex or '')
            //     regex_results = re.findall(subject_pattern, msg.get('subject')) + re.findall(subject_pattern, msg.get('body'))
            //     candidate.partner_name = regex_results[0] if regex_results else partner_name
            //     defaults["partner_name"] = candidate.partner_name
            //     del msg['email_from']
            // if msg.get('priority'):
            //     defaults['priority'] = msg.get('priority')
            // if stage and stage.id:
            //     defaults['stage_id'] = stage.id
            // if custom_values:
            //     defaults.update(custom_values)
            // res = super().message_new(msg, custom_values=defaults)
            // candidate._compute_partner_phone_email()
            // return res
            */
            return default;
        }

        public async Task<TEntity> MessagePartnerInfoFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object link_mail) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_partner_info_from_emails(self, emails, link_mail=False):
            // """ Try to propose a better recipient when having only an email by populating
            // it with the partner_name / contact_name field of the lead e.g. if lead
            // contact_name is "Raoul" and email is "raoul@raoul.fr", suggest
            // "Raoul" <raoul@raoul.fr> as recipient. """
            // result = super(Lead, self)._message_partner_info_from_emails(emails, link_mail=link_mail)
            // if not (self.partner_name or self.contact_name) or not self.email_from:
            //     return result
            // for email, partner_info in zip(emails, result):
            //     if partner_info.get('partner_id') or not email:
            //         continue
            //     # reformat email if no name information
            //     name_emails = tools.mail.email_split_tuples(email)
            //     name_from_email = name_emails[0][0] if name_emails else False
            //     if name_from_email:
            //         continue  # already containing name + email
            //     name_from_email = self.partner_name or self.contact_name
            //     emails_normalized = tools.email_normalize_all(email)
            //     email_normalized = emails_normalized[0] if emails_normalized else False
            //     if email.lower() == self.email_from.lower() or (email_normalized and self.email_normalized == email_normalized):
            //         partner_info['full_name'] = tools.formataddr((
            //             name_from_email,
            //             ','.join(emails_normalized) if emails_normalized else email))
            //         break
            // return result
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email_from and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email_from or (self.email_normalized and partner.email_normalized == self.email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email_normalized', '=', new_partner[0].email_normalized)
            //         else:
            //             email_domain = ('email_from', '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('stage_id.fold', '=', False)
            //         ]).write({'partner_id': new_partner[0].id})
            // return super(Lead, self)._message_post_after_hook(message, msg_vals)
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
            // return super(Applicant, self)._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def message_post(self, **kwargs):
            // if self.env.context.get('mark_so_as_sent'):
            //     self.filtered(lambda o: o.state == 'draft').with_context(tracking_disable=True).write({'state': 'sent'})
            // so_ctx = {'mail_post_autofollow': self.env.context.get('mail_post_autofollow', True)}
            // if self.env.context.get('mark_so_as_sent') and 'mail_notify_author' not in kwargs:
            //     kwargs['notify_author'] = self.env.user.partner_id.id in (kwargs.get('partner_ids') or [])
            // return super(SaleOrder, self.with_context(**so_ctx)).message_post(**kwargs)
            */
            return default;
        }

        public async Task<TEntity> MessageSetMainAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments, object force, object filter_xml) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _message_set_main_attachment_id(self, attachments, force=False, filter_xml=True):
            // if not force and len(attachments) > 1 and self.message_main_attachment_id in self.edi_document_ids.attachment_id:
            //     force = True
            // super()._message_set_main_attachment_id(attachments, force=force, filter_xml=filter_xml)
            */
            return default;
        }

        public async Task<TEntity> MoveDictToPreviewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals, Guid currency_id) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> MustCheckConstrainsDateSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _must_check_constrains_date_sequence(self):
            // # OVERRIDES sequence.mixin
            // return self.state == 'posted' and not self.quick_edit_mode
            */
            return default;
        }

        public async Task<TEntity> MustDeleteAllExpenseEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _must_delete_all_expense_entries(self):
            // if self.expense_sheet_id and self.expense_sheet_id.account_move_ids - self:  # If not all the payments are to be deleted
            //     raise UserError(_("You cannot delete only some entries linked to an expense report. All entries must be deleted at the same time."))
            */
            return default;
        }

        public async Task<TEntity> NeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> NeedUblCiiXmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ubl_cii_format) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _need_ubl_cii_xml(self, ubl_cii_format):
            // self.ensure_one()
            // return not self.ubl_cii_xml_id \
            //     and self.is_sale_document() \
            //     and ubl_cii_format in self.env['res.partner']._get_ubl_cii_formats()
            */
            return default;
        }

        public async Task<TEntity> NothingToInvoiceErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _nothing_to_invoice_error_message(self):
            // return _(
            //     "Cannot create an invoice. No items are available to invoice.\n\n"
            //     "To resolve this issue, please ensure that:\n"
            //     "   \u2022 The products have been delivered before attempting to invoice them.\n"
            //     "   \u2022 The invoicing policy of the product is configured correctly.\n\n"
            //     "If you want to invoice based on ordered quantities instead:\n"
            //     "   \u2022 For consumable or storable products, open the product, go to the 'General Information' tab and change the 'Invoicing Policy' from 'Delivered Quantities' to 'Ordered Quantities'.\n"
            //     "   \u2022 For services (and other products), change the 'Invoicing Policy' to 'Prepaid/Fixed Price'.\n"
            // )
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // if self.date_deadline:
            //     render_context['subtitles'].append(
            //         _('Deadline: %s', self.date_deadline.strftime(get_lang(self.env).date_format)))
            // return render_context
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // lang_code = render_context.get('lang')
            // record = render_context['record']
            // subtitles = [f"{record.name} - {record.partner_id.name}" if record.partner_id else record.name]
            // if self.amount_total:
            //     # Do not show the price in subtitles if zero (e.g. e-commerce orders are created empty)
            //     subtitles.append(
            //         format_amount(self.env, self.amount_total, self.currency_id, lang_code=lang_code),
            //     )
            // 
            // render_context['subtitles'] = subtitles
            // return render_context
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Handle salesman recipients that can convert leads into opportunities
            // and set opportunities as won / lost. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // local_msg_vals = dict(msg_vals or {})
            // 
            // self.ensure_one()
            // if self.type == 'lead':
            //     convert_action = self._notify_get_action_link('controller', controller='/lead/convert', **local_msg_vals)
            //     salesman_actions = [{'url': convert_action, 'title': _('Convert to opportunity')}]
            // else:
            //     won_action = self._notify_get_action_link('controller', controller='/lead/case_mark_won', **local_msg_vals)
            //     lost_action = self._notify_get_action_link('controller', controller='/lead/case_mark_lost', **local_msg_vals)
            //     salesman_actions = [
            //         {'url': won_action, 'title': _('Mark Won')},
            //         {'url': lost_action, 'title': _('Mark Lost')}]
            // 
            // salesman_group_id = self.env.ref('sales_team.group_sale_salesman').id
            // new_group = (
            //     'group_sale_salesman',
            //     lambda pdata: pdata['type'] == 'user' and salesman_group_id in pdata['groups'],
            //     {
            //         'actions': salesman_actions,
            //         'active': True,
            //         'has_button_access': True,
            //     }
            // )
            // 
            // return [new_group] + groups
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Give access button to users and portal customer as portal is integrated
            // in sale. Customer and portal group have probably no right to see
            // the document so they don't have the access button. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // if self._context.get('proforma'):
            //     for group in [g for g in groups if g[0] in ('portal_customer', 'portal', 'follower', 'customer')]:
            //         group[2]['has_button_access'] = False
            //     return groups
            // local_msg_vals = dict(msg_vals or {})
            // 
            // # portal customers have full access (existence not granted, depending on partner_id)
            // try:
            //     customer_portal_group = next(group for group in groups if group[0] == 'portal_customer')
            // except StopIteration:
            //     pass
            // else:
            //     access_opt = customer_portal_group[2].setdefault('button_access', {})
            //     is_tx_pending = self.get_portal_last_transaction().state == 'pending'
            //     if self._has_to_be_signed():
            //         if self._has_to_be_paid():
            //             access_opt['title'] = _("View Quotation") if is_tx_pending else _("Sign & Pay Quotation")
            //         else:
            //             access_opt['title'] = _("Accept & Sign Quotation")
            //     elif self._has_to_be_paid() and not is_tx_pending:
            //         access_opt['title'] = _("Accept & Pay Quotation")
            //     elif self.state in ('draft', 'sent'):
            //         access_opt['title'] = _("View Quotation")
            // 
            // return groups
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of lead and opportunities to their sales team if any. """
            // aliases = self.mapped('team_id').sudo()._notify_get_reply_to(default=default)
            // res = {lead.id: aliases.get(lead.team_id.id) for lead in self}
            // leftover = self.filtered(lambda rec: not rec.team_id)
            // if leftover:
            //     res.update(super(Lead, leftover)._notify_get_reply_to(default=default))
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of applicants to their job definition if any. """
            // aliases = self.mapped('job_id')._notify_get_reply_to(default=default)
            // res = {app.id: aliases.get(app.job_id.id) for app in self}
            // leftover = self.filtered(lambda rec: not rec.job_id)
            // if leftover:
            //     res.update(super(Applicant, leftover)._notify_get_reply_to(default=default))
            // return res
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, object values, object field_names, object fields_spec) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def onchange(self, values, field_names, fields_spec):
            // self_with_context = self
            // if not field_names: # Some warnings should not be displayed for the first onchange
            //     self_with_context = self.with_context(sale_onchange_first_call=True)
            // return super(SaleOrder, self_with_context).onchange(values, field_names, fields_spec)
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommitmentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_commitment_date(self):
            // """ Warn if the commitment dates is sooner than the expected date """
            // if self.commitment_date and self.expected_date and self.commitment_date < self.expected_date:
            //     return {
            //         'warning': {
            //             'title': _('Requested date is too soon.'),
            //             'message': _("The delivery date is sooner than the expected date."
            //                          " You may be unable to honor the delivery date.")
            //         }
            //     }
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_company_id(self):
            // for order in self:
            //     # This can't be caught by a python constraint as it is only triggered at save
            //     # and a compute methodd needs this data to be set correctly before saving
            //     if not order.company_id:
            //         raise ValidationError(_("The company is required, please select one before making any other changes to the sale order."))
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_company_id_warning(self):
            // self.show_update_pricelist = True
            // if self.env.context.get('sale_onchange_first_call'):
            //     return
            // if self.order_line and self.state == 'draft':
            //     return {
            //         'warning': {
            //             'title': _("Warning for the change of your quotation's company"),
            //             'message': _("Changing the company of an existing quotation might need some "
            //                          "manual adjustments in the details of the lines. You might "
            //                          "consider updating the prices."),
            //         }
            //     }
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_date(self):
            // if not self.is_invoice(True):
            //     self.line_ids._inverse_amount_currency()
            */
            return default;
        }

        public async Task<TEntity> OnchangeFposIdShowUpdateFposInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_fpos_id_show_update_fpos(self):
            // if self.order_line and (
            //     not self.fiscal_position_id
            //     or (self.fiscal_position_id and self._origin.fiscal_position_id != self.fiscal_position_id)
            // ):
            //     self.show_update_fpos = True
            */
            return default;
        }

        public async Task<TEntity> OnchangeInvoiceCashRoundingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> OnchangeInvoiceVendorBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> OnchangeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> OnchangeMobileValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_mobile_validation(self):
            // if self.mobile:
            //     self.mobile = self._phone_format(fname='mobile', force_format='INTERNATIONAL') or self.mobile
            */
            return default;
        }

        public async Task<TEntity> OnchangeNameWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> OnchangeOrderLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_order_line(self):
            // for index, line in enumerate(self.order_line):
            //     if line.product_type == 'combo' and line.selected_combo_items:
            //         linked_lines = line._get_linked_lines()
            //         selected_combo_items = json.loads(line.selected_combo_items)
            //         if (
            //             selected_combo_items
            //             and len(selected_combo_items) != len(line.product_template_id.combo_ids)
            //         ):
            //             raise ValidationError(_(
            //                 "The number of selected combo items must match the number of available"
            //                 " combo choices."
            //             ))
            // 
            //         # Delete any existing combo item lines.
            //         delete_commands = [Command.delete(linked_line.id) for linked_line in linked_lines]
            //         # Create a new combo item line for each selected combo item.
            //         create_commands = [Command.create({
            //             'product_id': combo_item['product_id'],
            //             'product_uom_qty': line.product_uom_qty,
            //             'combo_item_id': combo_item['combo_item_id'],
            //             'product_no_variant_attribute_value_ids': [
            //                 Command.set(combo_item['no_variant_attribute_value_ids'])
            //             ],
            //             'product_custom_attribute_value_ids': [Command.clear()] + [
            //                 Command.create(attribute_value)
            //                 for attribute_value in combo_item['product_custom_attribute_values']
            //             ],
            //             # Combo item lines should come directly after their combo product line.
            //             'sequence': line.sequence + item_index + 1,
            //             # If the linked line exists in DB, populate linked_line_id, otherwise populate
            //             # linked_virtual_id.
            //             'linked_line_id': line.id if line._origin else False,
            //             'linked_virtual_id': line.virtual_id if not line._origin else False,
            //         }) for item_index, combo_item in enumerate(selected_combo_items)]
            //         # Shift any lines coming after the combo product line so that the combo item lines
            //         # come first.
            //         update_commands = [Command.update(
            //             order_line.id,
            //             {'sequence': line.sequence + len(selected_combo_items) + line_index - index},
            //         ) for line_index, order_line in enumerate(self.order_line) if line_index > index]
            // 
            //         # Clear `selected_combo_items` to avoid applying the same changes multiple times.
            //         line.selected_combo_items = False
            //         self.order_line = delete_commands + create_commands + update_commands
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_partner_id(self):
            // self = self.with_company((self.journal_id.company_id or self.env.company)._accessible_branches()[:1])
            // 
            // warning = {}
            // if self.partner_id:
            //     rec_account = self.partner_id.property_account_receivable_id
            //     pay_account = self.partner_id.property_account_payable_id
            //     if not rec_account and not pay_account:
            //         action = self.env.ref('account.action_account_config')
            //         msg = _('Cannot find a chart of accounts for this company, You should configure it. \nPlease go to Account Configuration.')
            //         raise RedirectWarning(msg, action.id, _('Go to the configuration panel'))
            //     p = self.partner_id
            //     if p.invoice_warn == 'no-message' and p.parent_id:
            //         p = p.parent_id
            //     if p.invoice_warn and p.invoice_warn != 'no-message':
            //         # Block if partner only has warning but parent company is blocked
            //         if p.invoice_warn != 'block' and p.parent_id and p.parent_id.invoice_warn == 'block':
            //             p = p.parent_id
            //         warning = {
            //             'title': _("Warning for %s", p.name),
            //             'message': p.invoice_warn_msg
            //         }
            //         if p.invoice_warn == 'block':
            //             self.partner_id = False
            //         return {'warning': warning}
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _onchange_partner_id(self):
            // res = super(AccountMove, self)._onchange_partner_id()
            // 
            // currency_id = (
            //         self.partner_id.property_purchase_currency_id
            //         or self.env['res.currency'].browse(self.env.context.get("default_currency_id"))
            //         or self.currency_id
            // )
            // 
            // if self.partner_id and self.move_type in ['in_invoice', 'in_refund'] and self.currency_id != currency_id:
            //     if not self.env.context.get('default_journal_id'):
            //         journal_domain = [
            //             *self.env['account.journal']._check_company_domain(self.company_id),
            //             ('type', '=', 'purchase'),
            //             ('currency_id', '=', currency_id.id),
            //         ]
            //         default_journal_id = self.env['account.journal'].search(journal_domain, limit=1)
            //         if default_journal_id:
            //             self.journal_id = default_journal_id
            // 
            //     self.currency_id = currency_id
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_partner_id_warning(self):
            // if not self.partner_id:
            //     return
            // 
            // partner = self.partner_id
            // 
            // # If partner has no warning, check its company
            // if partner.sale_warn == 'no-message' and partner.parent_id:
            //     partner = partner.parent_id
            // 
            // if partner.sale_warn and partner.sale_warn != 'no-message':
            //     # Block if partner only has warning but parent company is blocked
            //     if partner.sale_warn != 'block' and partner.parent_id and partner.parent_id.sale_warn == 'block':
            //         partner = partner.parent_id
            // 
            //     if partner.sale_warn == 'block':
            //         self.partner_id = False
            // 
            //     return {
            //         'warning': {
            //             'title': _("Warning for %s", partner.name),
            //             'message': partner.sale_warn_msg,
            //         }
            //     }
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_phone_validation(self):
            // if self.phone:
            //     self.phone = self._phone_format(fname='phone', force_format='INTERNATIONAL') or self.phone
            */
            return default;
        }

        public async Task<TEntity> OnchangePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_prepayment_percent(self):
            // if not self.prepayment_percent:
            //     self.require_payment = False
            */
            return default;
        }

        public async Task<TEntity> OnchangePricelistIdShowUpdatePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_pricelist_id_show_update_prices(self):
            // self.show_update_pricelist = bool(self.order_line)
            */
            return default;
        }

        public async Task<TEntity> OnchangePurchaseAutoCompleteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _onchange_purchase_auto_complete(self):
            // r''' Load from either an old purchase order, either an old vendor bill.
            // 
            // When setting a 'purchase.bill.union' in 'purchase_vendor_bill_id':
            // * If it's a vendor bill, 'invoice_vendor_bill_id' is set and the loading is done by '_onchange_invoice_vendor_bill'.
            // * If it's a purchase order, 'purchase_id' is set and this method will load lines.
            // 
            // /!\ All this not-stored fields must be empty at the end of this function.
            // '''
            // if self.purchase_vendor_bill_id.vendor_bill_id:
            //     self.invoice_vendor_bill_id = self.purchase_vendor_bill_id.vendor_bill_id
            //     self._onchange_invoice_vendor_bill()
            // elif self.purchase_vendor_bill_id.purchase_order_id:
            //     self.purchase_id = self.purchase_vendor_bill_id.purchase_order_id
            // self.purchase_vendor_bill_id = False
            // 
            // if not self.purchase_id:
            //     return
            // 
            // # Copy data from PO
            // invoice_vals = self.purchase_id.with_company(self.purchase_id.company_id)._prepare_invoice()
            // has_invoice_lines = bool(self.invoice_line_ids.filtered(lambda x: x.display_type not in ('line_note', 'line_section')))
            // new_currency_id = self.currency_id if has_invoice_lines else invoice_vals.get('currency_id')
            // del invoice_vals['ref'], invoice_vals['payment_reference']
            // del invoice_vals['company_id']  # avoid recomputing the currency
            // if self.move_type == invoice_vals['move_type']:
            //     del invoice_vals['move_type'] # no need to be updated if it's same value, to avoid recomputes
            // self.update(invoice_vals)
            // self.currency_id = new_currency_id
            // 
            // # Copy purchase lines.
            // po_lines = self.purchase_id.order_line - self.invoice_line_ids.mapped('purchase_line_id')
            // self._add_purchase_order_lines(po_lines)
            // 
            // # Compute invoice_origin.
            // origins = set(self.invoice_line_ids.mapped('purchase_line_id.order_id.name'))
            // self.invoice_origin = ','.join(list(origins))
            // 
            // # Compute ref.
            // refs = self._get_invoice_reference()
            // self.ref = ', '.join(refs)
            // 
            // # Compute payment_reference.
            // if not self.payment_reference:
            //     if len(refs) == 1:
            //         self.payment_reference = refs[0]
            //     elif len(refs) > 1:
            //         self.payment_reference = refs[-1]
            // 
            // # Copy company_id (only changes if the id is of a child company (branch))
            // if self.company_id != self.purchase_id.company_id:
            //     self.company_id = self.purchase_id.company_id
            // 
            // self.purchase_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> OnchangeQuickEditTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> OpenCreatedCabaEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> OpenPaymentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_payments(self):
            // return self.matched_payment_ids._get_records_action(name=_("Payments"))
            */
            return default;
        }

        public async Task<TEntity> OpenReconcileViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_reconcile_view(self):
            // return self.line_ids.open_reconcile_view()
            */
            return default;
        }

        public async Task<TEntity> PaymentActionCaptureAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def payment_action_capture(self):
            // """ Capture all transactions linked to this sale order. """
            // self.ensure_one()
            // payment_utils.check_rights_on_recordset(self)
            // 
            // # In sudo mode to bypass the checks on the rights on the transactions.
            // return self.transaction_ids.sudo().action_capture()
            */
            return default;
        }

        public async Task<TEntity> PaymentActionVoidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def payment_action_void(self):
            // """ Void all transactions linked to this sale order. """
            // payment_utils.check_rights_on_recordset(self)
            // 
            // # In sudo mode to bypass the checks on the rights on the transactions.
            // self.authorized_transaction_ids.sudo().action_void()
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _phone_get_number_fields(self):
            // """ This method returns the fields to use to find the number to use to
            // send an SMS on a record. """
            // return ['partner_phone']
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _phone_get_number_fields(self):
            // """ No phone or mobile field is available on sale model. Instead SMS will
            // fallback on partner-based computation using ``_mail_get_partner_fields``. """
            // return []
            */
            return default;
        }

        public async Task<TEntity> PlsGetLeadPlsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_lead_pls_values(self, domain=[]):
            // """
            // This methods builds a dict where, for each lead in self or matching the given domain,
            // we will get a list of field/value couple.
            // Due to onchange and create, we don't always have the id of the lead to recompute.
            // When we update few records (one, typically) with onchanges, we build the lead_values (= couple field/value)
            // using the ORM.
            // To speed up the computation and avoid making too much DB read inside loops,
            // we can give a domain to make sql queries to bypass the ORM.
            // This domain will be used in sql queries to get the values for every lead matching the domain.
            // :param domain: If set, we get all the leads values via unique sql queries (one for tags, one for other fields),
            //                     using the given domain on leads.
            //                If not set, get lead values lead by lead using the ORM.
            // :return: {lead_id: [(field1: value1), (field2: value2), ...], ...}
            // """
            // leads_values_dict = OrderedDict()
            // pls_fields = ["stage_id", "team_id"] + self._pls_get_safe_fields()
            // 
            // # Check if tag_ids is in the pls_fields and removed it from the list. The tags will be managed separately.
            // use_tags = 'tag_ids' in pls_fields
            // if use_tags:
            //     pls_fields.remove('tag_ids')
            // 
            // if domain:
            //     # Get leads values
            //     self.flush_model()
            //     # active_test = False as domain should take active into 'active' field it self
            //     query = self.env['crm.lead'].with_context(active_test=False)._where_calc(domain)
            //     table = query.table
            //     query.order = SQL("%(table)s.team_id asc, %(table)s.id desc", table=SQL.identifier(table))
            //     sql_fields = [SQL.identifier(field) for field in pls_fields]
            //     self._cr.execute(query.select(
            //         SQL("id"),
            //         SQL("probability"),
            //         *sql_fields,
            //     ))
            //     lead_results = self._cr.dictfetchall()
            // 
            //     if use_tags:
            //         # Get tags values
            //         tag_rel_alias = query.left_join(table, 'id', 'crm_tag_rel', 'lead_id', 'crm_tag_rel')
            //         tag_alias = query.left_join(tag_rel_alias, 'tag_id', 'crm_tag', 'id', 'crm_tag')
            //         self._cr.execute(query.select(
            //             SQL("%s AS lead_id", SQL.identifier(table, "id")),
            //             SQL("%s AS tag_id", SQL.identifier(tag_alias, "id")),
            //         ))
            //         tag_results = self._cr.dictfetchall()
            //     else:
            //         tag_results = []
            // 
            //     # get all (variable, value) couple for all in self
            //     for lead in lead_results:
            //         lead_values = []
            //         for field in pls_fields + ['probability']:  # add probability as used in _pls_prepare_frequencies (needed in rebuild mode)
            //             value = lead[field]
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             if value or field == 'probability':  # 0 is a correct value for probability
            //                 lead_values.append((field, value))
            //             elif field in ('email_state', 'phone_state'):  # As ORM reads 'None' as 'False', do the same here
            //                 lead_values.append((field, False))
            //             leads_values_dict[lead['id']] = {'values': lead_values, 'team_id': lead['team_id'] or 0}
            // 
            //     for tag in tag_results:
            //         if tag['tag_id']:
            //             leads_values_dict[tag['lead_id']]['values'].append(('tag_id', tag['tag_id']))
            //     return leads_values_dict
            // else:
            //     for lead in self:
            //         lead_values = []
            //         for field in pls_fields:
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             value = lead[field].id if isinstance(lead[field], models.BaseModel) else lead[field]
            //             if value or field in ('email_state', 'phone_state'):
            //                 lead_values.append((field, value))
            //         if use_tags:
            //             for tag in lead.tag_ids:
            //                 lead_values.append(('tag_id', tag.id))
            //         leads_values_dict[lead.id] = {'values': lead_values, 'team_id': lead['team_id'].id}
            //     return leads_values_dict
            */
            return default;
        }

        public async Task<TEntity> PlsGetNaiveBayesProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_mode) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_naive_bayes_probabilities(self, batch_mode=False):
            // """
            // In machine learning, naive Bayes classifiers (NBC) are a family of simple "probabilistic classifiers" based on
            // applying Bayes theorem with strong (naive) independence assumptions between the variables taken into account.
            // E.g: will TDE eat m&m's depending on his sleep status, the amount of work he has and the fullness of his stomach?
            // As we use experience to compute the statistics, every day, we will register the variables state + the result.
            // As the days pass, we will be able to determine, with more and more precision, if TDE will eat m&m's
            // for a specific combination :
            //     - did sleep very well, a lot of work and stomach full > Will never happen !
            //     - didn't sleep at all, no work at all and empty stomach > for sure !
            // Following Bayes' Theorem: the probability that an event occurs (to win) under certain conditions is proportional
            // to the probability to win under each condition separately and the probability to win. We compute a 'Win score'
            // -> P(Won | A∩B) ∝ P(A∩B | Won)*P(Won) OR S(Won | A∩B) = P(A∩B | Won)*P(Won)
            // To compute a percentage of probability to win, we also compute the 'Lost score' that is proportional to the
            // probability to lose under each condition separately and the probability to lose.
            // -> Probability =  S(Won | A∩B) / ( S(Won | A∩B) + S(Lost | A∩B) )
            // See https://www.youtube.com/watch?v=CPqOCI0ahss can help to get a quick and simple example.
            // One issue about NBC is when a event occurence is never observed.
            // E.g: if when TDE has an empty stomach, he always eat m&m's, than the "not eating m&m's when empty stomach' event
            // will never be observed.
            // This is called 'zero frequency' and that leads to division (or at least multiplication) by zero.
            // To avoid this, we add 0.1 in each frequency. With few data, the computation is than not really realistic.
            // The more we have records to analyse, the more the estimation will be precise.
            // :return: probability in percent (and integer rounded) that the lead will be won at the current stage.
            // """
            // lead_probabilities = {}
            // if not self:
            //     return lead_probabilities
            // 
            // # Get all leads values, no matter the team_id
            // domain = []
            // if batch_mode:
            //     domain = [
            //         '&',
            //             ('active', '=', True), ('id', 'in', self.ids),
            //             '|',
            //                 ('probability', '=', None),
            //                 '&',
            //                     ('probability', '<', 100), ('probability', '>', 0)
            //     ]
            // leads_values_dict = self._pls_get_lead_pls_values(domain=domain)
            // 
            // if not leads_values_dict:
            //     return lead_probabilities
            // 
            // # Get unique couples to search in frequency table and won leads.
            // leads_fields = set()  # keep unique fields, as a lead can have multiple tag_ids
            // won_leads = set()
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead_id, values in leads_values_dict.items():
            //     for field, value in values['values']:
            //         if field == 'stage_id' and value in won_stage_ids:
            //             won_leads.add(lead_id)
            //         leads_fields.add(field)
            // leads_fields = sorted(leads_fields)
            // # get all variable related records from frequency table, no matter the team_id
            // frequencies = self.env['crm.lead.scoring.frequency'].search([('variable', 'in', list(leads_fields))], order="team_id asc, id")
            // 
            // # get all team_ids from frequencies
            // frequency_teams = frequencies.mapped('team_id')
            // frequency_team_ids = [team.id for team in frequency_teams]
            // 
            // # 1. Compute each variable value count individually
            // # regroup each variable to be able to compute their own probabilities
            // # As all the variable does not enter into account (as we reject unset values in the process)
            // # each value probability must be computed only with their own variable related total count
            // # special case: for lead for which team_id is not in frequency table or lead with no team_id,
            // # we consider all the records, independently from team_id (this is why we add a result[-1])
            // result = dict((team_id, dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)) for team_id in frequency_team_ids)
            // result[-1] = dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)
            // for frequency in frequencies:
            //     field = frequency['variable']
            //     value = frequency['value']
            // 
            //     # To avoid that a tag take too much importance if its subset is too small,
            //     # we ignore the tag frequencies if we have less than 50 won or lost for this tag.
            //     if field == 'tag_id' and (frequency['won_count'] + frequency['lost_count']) < 50:
            //         continue
            // 
            //     if frequency.team_id:
            //         team_result = result[frequency.team_id.id]
            //         team_result[field][value] = {'won': frequency['won_count'], 'lost': frequency['lost_count']}
            //         team_result[field]['won_total'] += frequency['won_count']
            //         team_result[field]['lost_total'] += frequency['lost_count']
            // 
            //     if value not in result[-1][field]:
            //         result[-1][field][value] = {'won': 0, 'lost': 0}
            //     result[-1][field][value]['won'] += frequency['won_count']
            //     result[-1][field][value]['lost'] += frequency['lost_count']
            //     result[-1][field]['won_total'] += frequency['won_count']
            //     result[-1][field]['lost_total'] += frequency['lost_count']
            // 
            // # Get all won, lost and total count for all records in frequencies per team_id
            // for team_id in result:
            //     result[team_id]['team_won'], \
            //     result[team_id]['team_lost'], \
            //     result[team_id]['team_total'] = self._pls_get_won_lost_total_count(result[team_id])
            // 
            // save_team_id = None
            // p_won, p_lost = 1, 1
            // for lead_id, lead_values in leads_values_dict.items():
            //     # if stage_id is null, return 0 and bypass computation
            //     lead_fields = [value[0] for value in lead_values.get('values', [])]
            //     if not 'stage_id' in lead_fields:
            //         lead_probabilities[lead_id] = 0
            //         continue
            //     # if lead stage is won, return 100
            //     elif lead_id in won_leads:
            //         lead_probabilities[lead_id] = 100
            //         continue
            // 
            //     # team_id not in frequency Table -> convert to -1
            //     lead_team_id = lead_values['team_id'] if lead_values['team_id'] in result else -1
            //     if lead_team_id != save_team_id:
            //         save_team_id = lead_team_id
            //         team_won = result[save_team_id]['team_won']
            //         team_lost = result[save_team_id]['team_lost']
            //         team_total = result[save_team_id]['team_total']
            //         # if one count = 0, we cannot compute lead probability
            //         if not team_won or not team_lost:
            //             continue
            //         p_won = team_won / team_total
            //         p_lost = team_lost / team_total
            // 
            //     # 2. Compute won and lost score using each variable's individual probability
            //     s_lead_won, s_lead_lost = p_won, p_lost
            //     for field, value in lead_values['values']:
            //         field_result = result.get(save_team_id, {}).get(field)
            //         value = value.origin if hasattr(value, 'origin') else value
            //         value_result = field_result.get(str(value)) if field_result else False
            //         if value_result:
            //             total_won = team_won if field == 'stage_id' else field_result['won_total']
            //             total_lost = team_lost if field == 'stage_id' else field_result['lost_total']
            // 
            //             # if one count = 0, we cannot compute lead probability
            //             if not total_won or not total_lost:
            //                 continue
            //             s_lead_won *= value_result['won'] / total_won
            //             s_lead_lost *= value_result['lost'] / total_lost
            // 
            //     # 3. Compute Probability to win
            //     probability = s_lead_won / (s_lead_won + s_lead_lost)
            //     lead_probabilities[lead_id] = min(max(round(100 * probability, 2), 0.01), 99.99)
            // return lead_probabilities
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_fields(self):
            // """ As config_parameters does not accept M2M field,
            //     we the fields from the formated string stored into the Char config field.
            //     To avoid sql injections when using that list, we return only the fields
            //     that are defined on the model. """
            // pls_fields_config = self.env['ir.config_parameter'].sudo().get_param('crm.pls_fields')
            // pls_fields = pls_fields_config.split(',') if pls_fields_config else []
            // pls_safe_fields = [field for field in pls_fields if field in self._fields.keys()]
            // return pls_safe_fields
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_start_date(self):
            // """ As config_parameters does not accept Date field,
            //     we get directly the date formated string stored into the Char config field,
            //     as we directly use this string in the sql queries.
            //     To avoid sql injections when using this config param,
            //     we ensure the date string can be effectively a date."""
            // str_date = self.env['ir.config_parameter'].sudo().get_param('crm.pls_start_date')
            // if not fields.Date.to_date(str_date):
            //     return False
            // return str_date
            */
            return default;
        }

        public async Task<TEntity> PlsGetWonLostTotalCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object team_results) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_won_lost_total_count(self, team_results):
            // """ Get all won and all lost + total :
            //        first stage can be used to know how many lost and won there is
            //        as won count are equals for all stage
            //        and first stage is always incremented in lost_count
            // :param frequencies: lead_scoring_frequencies
            // :return: won count, lost count and total count for all records in frequencies
            // """
            // # TODO : check if we need to handle specific team_id stages [for lost count] (if first stage in sequence is team_specific)
            // first_stage_id = self.env['crm.stage'].search([('team_id', '=', False)], order='sequence, id', limit=1)
            // if str(first_stage_id.id) not in team_results.get('stage_id', []):
            //     return 0, 0, 0
            // stage_result = team_results['stage_id'][str(first_stage_id.id)]
            // return stage_result['won'], stage_result['lost'], stage_result['won'] + stage_result['lost']
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_state, object to_state) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequencies(self, from_state=None, to_state=None):
            // """
            // When losing or winning a lead, this method is called to increment each PLS parameter related to the lead
            // in won_count (if won) or in lost_count (if lost).
            // 
            // This method is also used when reactivating a mistakenly lost lead (using the decrement argument).
            // In this case, the lost count should be de-increment by 1 for each PLS parameter linked to the lead.
            // 
            // Live increment must be done before writing the new values because we need to know the state change (from and to).
            // This would not be an issue for the reach won or reach lost as we just need to increment the frequencies with the
            // final state of the lead.
            // This issue is when the lead leaves a closed state because once the new values have been writen, we do not know
            // what was the previous state that we need to decrement.
            // This is why 'is_won' and 'decrement' parameters are used to describe the from / to change of its state.
            // """
            // new_frequencies_by_team, existing_frequencies_by_team = self._pls_prepare_update_frequency_table(target_state=from_state or to_state)
            // 
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1 if to_state else -1,
            //                                  existing_frequencies_by_team=existing_frequencies_by_team)
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequencyDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object frequencies, object field, object @value, object won, object lost) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequency_dict(self, frequencies, field, value, won, lost):
            // value = str(value)  # Ensure we will always compare strings.
            // if value not in frequencies[field]:
            //     frequencies[field][value] = {'won': won, 'lost': lost}
            // else:
            //     frequencies[field][value]['won'] += won
            //     frequencies[field][value]['lost'] += lost
            // return frequencies
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_values, object leads_pls_fields, object target_state) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_frequencies(self, lead_values, leads_pls_fields, target_state=None):
            // """new state is used when getting frequencies for leads that are changing to lost or won.
            // Stays none if we are checking frequencies for leads already won or lost."""
            // pls_fields = leads_pls_fields.copy()
            // frequencies = dict((field, {}) for field in pls_fields)
            // 
            // stage_ids = self.env['crm.stage'].search_read([], ['sequence', 'name', 'id'], order='sequence, id')
            // stage_sequences = {stage['id']: stage['sequence'] for stage in stage_ids}
            // 
            // # Increment won / lost frequencies by criteria (field / value couple)
            // for values in lead_values:
            //     if target_state:  # ignore probability values if target state (as probability is the old value)
            //         won_count = values['count'] if target_state == 'won' else 0
            //         lost_count = values['count'] if target_state == 'lost' else 0
            //     else:
            //         won_count = values['count'] if values.get('probability', 0) == 100 else 0
            //         lost_count = values['count'] if values.get('probability', 1) == 0  else 0
            // 
            //     if 'tag_id' in values:
            //         frequencies = self._pls_increment_frequency_dict(frequencies, 'tag_id', values['tag_id'], won_count, lost_count)
            //         continue
            // 
            //     # Else, treat other fields
            //     if 'tag_id' in pls_fields:  # tag_id already treated here above.
            //         pls_fields.remove('tag_id')
            //     for field in pls_fields:
            //         if field not in values:
            //             continue
            //         value = values[field]
            //         if value or field in ('email_state', 'phone_state'):
            //             if field == 'stage_id':
            //                 if won_count:  # increment all stages if won
            //                     stages_to_increment = [stage['id'] for stage in stage_ids]
            //                 else:  # increment only current + previous stages if lost
            //                     current_stage_sequence = stage_sequences[value]
            //                     stages_to_increment = [stage['id'] for stage in stage_ids if stage['sequence'] <= current_stage_sequence]
            //                 for stage_id in stages_to_increment:
            //                     frequencies = self._pls_increment_frequency_dict(frequencies, field, stage_id, won_count, lost_count)
            //             else:
            //                 frequencies = self._pls_increment_frequency_dict(frequencies, field, value, won_count, lost_count)
            // 
            // return frequencies
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rebuild, object target_state) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_update_frequency_table(self, rebuild=False, target_state=False):
            // """
            // This method is common to Live Increment or Full Rebuild mode, as it shares the main steps.
            // This method will prepare the frequency dict needed to update the frequency table:
            //     - New frequencies: frequencies that we need to add in the frequency table.
            //     - Existing frequencies: frequencies that are already in the frequency table.
            // In rebuild mode, only the new frequencies are needed as existing frequencies are truncated.
            // For each team, each dict contains the frequency in won and lost for each field/value couple
            // of the target leads.
            // Target leads are :
            //     - in Live increment mode : given ongoing leads (self)
            //     - in Full rebuild mode : all the closed (won and lost) leads in the DB.
            // During the frequencies update, with both new and existing frequencies, we can split frequencies to update
            // and frequencies to add. If a field/value couple already exists in the frequency table, we just update it.
            // Otherwise, we need to insert a new one.
            // """
            // # Keep eligible leads
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return {}, {}
            // 
            // if rebuild:  # rebuild will treat every closed lead in DB, increment will treat current ongoing leads
            //     pls_leads = self
            // else:
            //     # Only treat leads created after the PLS start Date
            //     pls_leads = self.filtered(
            //         lambda lead: fields.Date.to_date(pls_start_date) <= fields.Date.to_date(lead.create_date))
            //     if not pls_leads:
            //         return {}, {}
            // 
            // # Extract target leads values
            // if rebuild:  # rebuild is ok
            //     domain = [
            //         '&',
            //             ('create_date', '>=', pls_start_date),
            //             '|',
            //                 ('probability', '=', 100),
            //                 '&',
            //                     ('probability', '=', 0), ('active', '=', False)
            //       ]
            //     team_ids = self.env['crm.team'].with_context(active_test=False).search([]).ids + [0]  # If team_id is unset, consider it as team 0
            // else:  # increment
            //     domain = [('id', 'in', pls_leads.ids)]
            //     team_ids = pls_leads.mapped('team_id').ids + [0]
            // 
            // leads_values_dict = pls_leads._pls_get_lead_pls_values(domain=domain)
            // 
            // # split leads values by team_id
            // # get current frequencies related to the target leads
            // leads_frequency_values_by_team = dict((team_id, []) for team_id in team_ids)
            // leads_pls_fields = set()  # ensure to keep each field unique (can have multiple tag_id leads_values_dict)
            // for lead_id, values in leads_values_dict.items():
            //     team_id = values.get('team_id', 0)  # If team_id is unset, consider it as team 0
            //     lead_frequency_values = {'count': 1}
            //     for field, value in values['values']:
            //         if field != "probability":  # was added to lead values in batch mode to know won/lost state, but is not a pls fields.
            //             leads_pls_fields.add(field)
            //         else:  # extract lead probability - needed to increment tag_id frequency. (proba always before tag_id)
            //             lead_probability = value
            //         if field == 'tag_id':  # handle tag_id separatelly (as in One Shot rebuild mode)
            //             leads_frequency_values_by_team[team_id].append({field: value, 'count': 1, 'probability': lead_probability})
            //         else:
            //             lead_frequency_values[field] = value
            //     leads_frequency_values_by_team[team_id].append(lead_frequency_values)
            // leads_pls_fields = sorted(leads_pls_fields)
            // 
            // # get new frequencies
            // new_frequencies_by_team = {}
            // for team_id in team_ids:
            //     # prepare fields and tag values for leads by team
            //     new_frequencies_by_team[team_id] = self._pls_prepare_frequencies(
            //         leads_frequency_values_by_team[team_id], leads_pls_fields, target_state=target_state)
            // 
            // # get existing frequencies
            // existing_frequencies_by_team = {}
            // if not rebuild:  # there is no existing frequency in rebuild mode as they were all deleted.
            //     # read all fields to get everything in memory in one query (instead of having query + prefetch)
            //     existing_frequencies = self.env['crm.lead.scoring.frequency'].search_read(
            //         ['&', ('variable', 'in', leads_pls_fields),
            //               '|', ('team_id', 'in', pls_leads.mapped('team_id').ids), ('team_id', '=', False)])
            //     for frequency in existing_frequencies:
            //         team_id = frequency['team_id'][0] if frequency.get('team_id') else 0
            //         if team_id not in existing_frequencies_by_team:
            //             existing_frequencies_by_team[team_id] = dict((field, {}) for field in leads_pls_fields)
            // 
            //         existing_frequencies_by_team[team_id][frequency['variable']][frequency['value']] = {
            //             'frequency_id': frequency['id'],
            //             'won': frequency['won_count'],
            //             'lost': frequency['lost_count']
            //         }
            // 
            // return new_frequencies_by_team, existing_frequencies_by_team
            */
            return default;
        }

        public async Task<TEntity> PlsUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_frequencies_by_team, object step, object existing_frequencies_by_team) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_update_frequency_table(self, new_frequencies_by_team, step, existing_frequencies_by_team=None):
            // """ Create / update the frequency table in a cross company way, per team_id"""
            // values_to_update = {}
            // values_to_create = []
            // if not existing_frequencies_by_team:
            //     existing_frequencies_by_team = {}
            // # build the create multi + frequencies to update
            // for team_id, new_frequencies in new_frequencies_by_team.items():
            //     for field, value in new_frequencies.items():
            //         # frequency already present ?
            //         current_frequencies = existing_frequencies_by_team.get(team_id, {})
            //         for param, result in value.items():
            //             current_frequency_for_couple = current_frequencies.get(field, {}).get(param, {})
            //             # If frequency already present : UPDATE IT
            //             if current_frequency_for_couple:
            //                 new_won = current_frequency_for_couple['won'] + (result['won'] * step)
            //                 new_lost = current_frequency_for_couple['lost'] + (result['lost'] * step)
            //                 # ensure to have always positive frequencies
            //                 values_to_update[current_frequency_for_couple['frequency_id']] = {
            //                     'won_count': new_won if new_won > 0 else 0.1,
            //                     'lost_count': new_lost if new_lost > 0 else 0.1
            //                 }
            //                 continue
            // 
            //             # Else, CREATE a new frequency record.
            //             # We add + 0.1 in won and lost counts to avoid zero frequency issues
            //             # should be +1 but it weights too much on small recordset.
            //             values_to_create.append({
            //                 'variable': field,
            //                 'value': param,
            //                 'won_count': result['won'] + 0.1,
            //                 'lost_count': result['lost'] + 0.1,
            //                 'team_id': team_id if team_id else None  # team_id = 0 means no team_id
            //             })
            // 
            // LeadScoringFrequency = self.env['crm.lead.scoring.frequency'].sudo()
            // for frequency_id, values in values_to_update.items():
            //     LeadScoringFrequency.browse(frequency_id).write(values)
            // 
            // if values_to_create:
            //     LeadScoringFrequency.create(values_to_create)
            */
            return default;
        }

        public async Task<TEntity> PostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _post(self, soft=True):
            // # OVERRIDE
            // # Auto-reconcile the invoice with payments coming from transactions.
            // # It's useful when you have a "paid" sale order (using a payment transaction) and you invoice it later.
            // posted = super()._post(soft)
            // 
            // for invoice in posted.filtered(lambda move: move.is_invoice()):
            //     payments = invoice.mapped('transaction_ids.payment_id').filtered(lambda x: x.state == 'in_process')
            //     move_lines = payments.move_id.line_ids.filtered(lambda line: line.account_type in ('asset_receivable', 'liability_payable') and not line.reconciled)
            //     for line in move_lines:
            //         invoice.js_assign_outstanding_line(line.id)
            // return posted
            */
            return default;
        }

        public async Task<TEntity> PrepareAddressValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_address_values_from_partner(self, partner):
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // if any(partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC):
            //     values = {f: partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // else:
            //     values = {f: self[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // return values
            */
            return default;
        }

        public async Task<TEntity> PrepareAnalyticAccountDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object prefix) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_analytic_account_data(self, prefix=None):
            // """ Prepare SO analytic account creation values.
            // 
            // :return: `account.analytic.account` creation values
            // :rtype: dict
            // """
            // self.ensure_one()
            // name = self.name
            // if prefix:
            //     name = prefix + ": " + self.name
            // project_plan, _other_plans = self.env['account.analytic.plan']._get_all_plans()
            // return {
            //     'name': name,
            //     'code': self.client_order_ref,
            //     'company_id': self.company_id.id,
            //     'plan_id': project_plan.id,
            //     'partner_id': self.partner_id.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareCashRoundingBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_rounding_line) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> PrepareConfirmationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_confirmation_values(self):
            // """ Prepare the sales order confirmation values.
            // 
            // Note: self can contain multiple records.
            // 
            // :return: Sales Order confirmation values
            // :rtype: dict
            // """
            // return {
            //     'state': 'sale',
            //     'date_order': fields.Datetime.now()
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareContactNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_contact_name_from_partner(self, partner):
            // contact_name = False if partner.is_company else partner.name
            // return {'contact_name': contact_name or self.contact_name}
            */
            return default;
        }

        public async Task<TEntity> PrepareCustomerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_name, object is_company, Guid parent_id) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_customer_values(self, partner_name, is_company=False, parent_id=False):
            // """ Extract data from lead to create a partner.
            // 
            // :param name : furtur name of the partner
            // :param is_company : True if the partner is a company
            // :param parent_id : id of the parent partner (False if no parent)
            // 
            // :return: dictionary of values to give at res_partner.create()
            // """
            // email_parts = tools.email_split(self.email_from)
            // res = {
            //     'name': partner_name,
            //     'user_id': self.env.context.get('default_user_id') or self.user_id.id,
            //     'comment': self.description,
            //     'parent_id': parent_id,
            //     'phone': self.phone,
            //     'mobile': self.mobile,
            //     'email': email_parts[0] if email_parts else False,
            //     'title': self.title.id,
            //     'function': self.function,
            //     'street': self.street,
            //     'street2': self.street2,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country_id': self.country_id.id,
            //     'state_id': self.state_id.id,
            //     'website': self.website,
            //     'is_company': is_company,
            //     'type': 'contact'
            // }
            // if self.lang_id.active:
            //     res['lang'] = self.lang_id.code
            // return res
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentSectionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_down_payment_section_line(self, **optional_values):
            // """ Prepare the values to create a new down payment section.
            // 
            // :param dict optional_values: any parameter that should be added to the returned down payment section
            // :return: `account.move.line` creation values
            // :rtype: dict
            // """
            // self.ensure_one()
            // context = {'lang': self.partner_id.lang}
            // down_payments_section_line = {
            //     'display_type': 'line_section',
            //     'name': _("Down Payments"),
            //     'product_id': False,
            //     'product_uom_id': False,
            //     'quantity': 0,
            //     'discount': 0,
            //     'price_unit': 0,
            //     'account_id': False,
            //     **optional_values
            // }
            // del context
            // return down_payments_section_line
            */
            return default;
        }

        public async Task<TEntity> PrepareEdiTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filter_to_apply, object filter_invl_to_apply, object grouping_key_generator) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _prepare_edi_tax_details(self, filter_to_apply=None, filter_invl_to_apply=None, grouping_key_generator=None):
            // ''' Compute amounts related to taxes for the current invoice.
            // 
            // :param filter_to_apply:         Optional filter to exclude some tax values from the final results.
            //                                 The filter is defined as a method getting a dictionary as parameter
            //                                 representing the tax values for a single repartition line.
            //                                 This dictionary contains:
            // 
            //     'base_line_id':             An account.move.line record.
            //     'tax_id':                   An account.tax record.
            //     'tax_repartition_line_id':  An account.tax.repartition.line record.
            //     'base_amount':              The tax base amount expressed in company currency.
            //     'tax_amount':               The tax amount expressed in company currency.
            //     'base_amount_currency':     The tax base amount expressed in foreign currency.
            //     'tax_amount_currency':      The tax amount expressed in foreign currency.
            // 
            //                                 If the filter is returning False, it means the current tax values will be
            //                                 ignored when computing the final results.
            // 
            // :param filter_invl_to_apply:    Optional filter to exclude some invoice lines.
            // 
            // :param grouping_key_generator:  Optional method used to group tax values together. By default, the tax values
            //                                 are grouped by tax. This parameter is a method getting a dictionary as parameter
            //                                 (same signature as 'filter_to_apply').
            // 
            //                                 This method must returns a dictionary where values will be used to create the
            //                                 grouping_key to aggregate tax values together. The returned dictionary is added
            //                                 to each tax details in order to retrieve the full grouping_key later.
            // 
            // :return:                        The full tax details for the current invoice and for each invoice line
            //                                 separately. The returned dictionary is the following:
            // 
            //     'base_amount':              The total tax base amount in company currency for the whole invoice.
            //     'tax_amount':               The total tax amount in company currency for the whole invoice.
            //     'base_amount_currency':     The total tax base amount in foreign currency for the whole invoice.
            //     'tax_amount_currency':      The total tax amount in foreign currency for the whole invoice.
            //     'tax_details':              A mapping of each grouping key (see 'grouping_key_generator') to a dictionary
            //                                 containing:
            // 
            //         'base_amount':              The tax base amount in company currency for the current group.
            //         'tax_amount':               The tax amount in company currency for the current group.
            //         'base_amount_currency':     The tax base amount in foreign currency for the current group.
            //         'tax_amount_currency':      The tax amount in foreign currency for the current group.
            //         'group_tax_details':        The list of all tax values aggregated into this group.
            // 
            //     'tax_details_per_record': A mapping of each invoice line to a dictionary containing:
            // 
            //         'base_amount':          The total tax base amount in company currency for the whole invoice line.
            //         'tax_amount':           The total tax amount in company currency for the whole invoice line.
            //         'base_amount_currency': The total tax base amount in foreign currency for the whole invoice line.
            //         'tax_amount_currency':  The total tax amount in foreign currency for the whole invoice line.
            //         'tax_details':          A mapping of each grouping key (see 'grouping_key_generator') to a dictionary
            //                                 containing:
            // 
            //             'base_amount':          The tax base amount in company currency for the current group.
            //             'tax_amount':           The tax amount in company currency for the current group.
            //             'base_amount_currency': The tax base amount in foreign currency for the current group.
            //             'tax_amount_currency':  The tax amount in foreign currency for the current group.
            //             'group_tax_details':    The list of all tax values aggregated into this group.
            // 
            // '''
            // return self._prepare_invoice_aggregated_taxes(
            //     filter_invl_to_apply=filter_invl_to_apply,
            //     filter_tax_values_to_apply=filter_to_apply,
            //     grouping_key_generator=grouping_key_generator,
            // )
            */
            return default;
        }

        public async Task<TEntity> PrepareEdiValsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> PrepareEpdBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object epd_line) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> PrepareEpdBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> PrepareInvoiceAggregatedTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filter_invl_to_apply, object filter_tax_values_to_apply, object grouping_key_generator, object round_from_tax_lines, object postfix_function) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> PrepareInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_invoice(self):
            // """
            // Prepare the dict of values to create the new invoice for a sales order. This method may be
            // overridden to implement custom invoice generation (making sure to call super() to establish
            // a clean extension chain).
            // """
            // self.ensure_one()
            // 
            // txs_to_be_linked = self.transaction_ids.sudo().filtered(
            //     lambda tx: (
            //         tx.state in ('pending', 'authorized')
            //         or tx.state == 'done' and not (tx.payment_id and tx.payment_id.is_reconciled)
            //     )
            // )
            // 
            // values = {
            //     'ref': self.client_order_ref or '',
            //     'move_type': 'out_invoice',
            //     'narration': self.note,
            //     'currency_id': self.currency_id.id,
            //     'campaign_id': self.campaign_id.id,
            //     'medium_id': self.medium_id.id,
            //     'source_id': self.source_id.id,
            //     'team_id': self.team_id.id,
            //     'partner_id': self.partner_invoice_id.id,
            //     'partner_shipping_id': self.partner_shipping_id.id,
            //     'fiscal_position_id': (self.fiscal_position_id or self.fiscal_position_id._get_fiscal_position(self.partner_invoice_id)).id,
            //     'invoice_origin': self.name,
            //     'invoice_payment_term_id': self.payment_term_id.id,
            //     'invoice_user_id': self.user_id.id,
            //     'payment_reference': self.reference,
            //     'transaction_ids': [Command.set(txs_to_be_linked.ids)],
            //     'company_id': self.company_id.id,
            //     'invoice_line_ids': [],
            //     'user_id': self.user_id.id,
            // }
            // if self.journal_id:
            //     values['journal_id'] = self.journal_id.id
            // return values
            */
            return default;
        }

        public async Task<TEntity> PreparePartnerNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_partner_name_from_partner(self, partner):
            // """ Company name: name of partner parent (if set) or name of partner
            // (if company) or company_name of partner (if not a company). """
            // partner_name = partner.parent_id.name
            // if not partner_name and partner.is_company:
            //     partner_name = partner.name
            // elif not partner_name and partner.company_name:
            //     partner_name = partner.company_name
            // return {'partner_name': partner_name or self.partner_name}
            */
            return default;
        }

        public async Task<TEntity> PrepareProductBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_line) where TEntity : IEntity<Guid>, IUtmMixinable
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
            // )
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py) ---
            // def _prepare_product_base_line_for_taxes_computation(self, product_line):
            // # EXTENDS 'account'
            // results = super()._prepare_product_base_line_for_taxes_computation(product_line)
            // if product_line.expense_id:
            //     results['special_mode'] = 'total_included'
            // return results
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_line) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> PrepareTaxLinesForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_amls, object round_from_tax_lines) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> PrepareValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_values_from_partner(self, partner):
            // """ Get a dictionary with values coming from partner information to
            // copy on a lead. Non-address fields get the current lead
            // values to avoid being reset if partner has no value for them. """
            // 
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // values = self._prepare_address_values_from_partner(partner)
            // 
            // # For other fields, get the info from the partner, but only if set
            // values.update({f: partner[f] or self[f] for f in PARTNER_FIELDS_TO_SYNC if f != 'lang'})
            // if partner.lang:
            //     values['lang_id'] = self.env['res.lang']._get_data(code=partner.lang).id
            // 
            // # Fields with specific logic
            // values.update(self._prepare_contact_name_from_partner(partner))
            // values.update(self._prepare_partner_name_from_partner(partner))
            // 
            // return self._convert_to_write(values)
            */
            return default;
        }

        public async Task<TEntity> PreviewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: account_move.py) ---
            // def preview_invoice(self):
            // action = super().preview_invoice()
            // if action['url'].startswith('/'):
            //     # URL should always be relative, safety check
            //     action['url'] = f'/@{action["url"]}'
            // return action
            */
            return default;
        }

        public async Task<TEntity> ProcessAttachmentsForTemplatePostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _process_attachments_for_template_post(self, mail_template):
            // """ Add Edi attachments to templates. """
            // result = super()._process_attachments_for_template_post(mail_template)
            // for move in self.filtered('edi_document_ids'):
            //     move_result = result.setdefault(move.id, {})
            //     for edi_doc in move.edi_document_ids:
            //         edi_attachments = edi_doc._filter_edi_attachments_for_mailing()
            //         move_result.setdefault('attachment_ids', []).extend(edi_attachments.get('attachment_ids', []))
            //         move_result.setdefault('attachments', []).extend(edi_attachments.get('attachments', []))
            // return result
            */
            return default;
        }

        public async Task<TEntity> QuickEditModeSuggestInvoiceDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve team_id from the context and write the domain
            // # - ('id', 'in', stages.ids): add columns that should be present
            // # - OR ('fold', '=', False): add default columns that are not folded
            // # - OR ('team_ids', '=', team_id), ('fold', '=', False) if team_id: add team columns that are not folded
            // team_id = self._context.get('default_team_id')
            // if team_id:
            //     search_domain = ['|', ('id', 'in', stages.ids), '|', ('team_id', '=', False), ('team_id', '=', team_id)]
            // else:
            //     search_domain = ['|', ('id', 'in', stages.ids), ('team_id', '=', False)]
            // 
            // # perform search
            // stage_ids = stages.sudo()._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve job_id from the context and write the domain: ids + contextual columns (job or default)
            // job_id = self._context.get('default_job_id')
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

        public async Task<TEntity> RebuildPlsFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _rebuild_pls_frequency_table(self):
            // # Clear the frequencies table (in sql to speed up the cron)
            // try:
            //     self.browse().check_access('unlink')
            // except AccessError:
            //     raise UserError(_("You don't have the access needed to run this cron."))
            // else:
            //     self._cr.execute('TRUNCATE TABLE crm_lead_scoring_frequency')
            // 
            // new_frequencies_by_team, unused = self._pls_prepare_update_frequency_table(rebuild=True)
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1)
            // 
            // _logger.info("Predictive Lead Scoring : crm.lead.scoring.frequency table rebuilt")
            */
            return default;
        }

        public async Task<TEntity> RecNamesSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _rec_names_search(self):
            // if self._context.get('sale_show_partner_name'):
            //     return ['name', 'partner_id.name']
            // return ['name']
            */
            return default;
        }

        public async Task<TEntity> RecentLinksAsync<TEntity>(IEnumerable<TEntity> entities, object filter, object limit) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def recent_links(self, filter, limit):
            // if filter == 'newest':
            //     return self.search_read([], order='create_date DESC, id DESC', limit=limit)
            // elif filter == 'most-clicked':
            //     return self.search_read([('count', '!=', 0)], order='count DESC, id DESC', limit=limit)
            // elif filter == 'recently-used':
            //     return self.search_read([('count', '!=', 0)], order='write_date DESC, id DESC', limit=limit)
            // else:
            //     return {'Error': "This filter doesn't exist."}
            */
            return default;
        }

        public async Task<TEntity> RecomputeCashRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> RecomputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _recompute_prices(self):
            // lines_to_recompute = self._get_update_prices_lines()
            // lines_to_recompute.invalidate_recordset(['pricelist_item_id'])
            // lines_to_recompute.with_context(force_price_recomputation=True)._compute_price_unit()
            // # Special case: we want to overwrite the existing discount on _recompute_prices call
            // # i.e. to make sure the discount is correctly reset
            // # if pricelist rule is different than when the price was first computed.
            // lines_to_recompute.discount = 0.0
            // lines_to_recompute._compute_discount()
            // self.show_update_pricelist = False
            */
            return default;
        }

        public async Task<TEntity> RecomputeTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _recompute_taxes(self):
            // lines_to_recompute = self.order_line.filtered(lambda line: not line.display_type)
            // lines_to_recompute._compute_tax_id()
            // self.show_update_fpos = False
            */
            return default;
        }

        public async Task<TEntity> ReconcileReversedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse_moves, object move_reverse_cancel) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> RedirectLeadOpportunityViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def redirect_lead_opportunity_view(self):
            // self.ensure_one()
            // return {
            //     'name': _('Lead or Opportunity'),
            //     'view_mode': 'form',
            //     'res_model': 'crm.lead',
            //     'domain': [('type', '=', self.type)],
            //     'res_id': self.id,
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            //     'context': {'default_type': self.type}
            // }
            */
            return default;
        }

        public async Task<TEntity> RefreshInvoiceCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def refresh_invoice_currency_rate(self):
            // for move in self:
            //     move.invoice_currency_rate = move.expected_currency_rate
            */
            return default;
        }

        public async Task<TEntity> RefundCleanupLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lines) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py) ---
            // def _refund_cleanup_lines(self, lines):
            // result = super(AccountMove, self)._refund_cleanup_lines(lines)
            // for i, line in enumerate(lines):
            //     for name, field in line._fields.items():
            //         if name == 'asset_category_id':
            //             result[i][2][name] = False
            //             break
            // return result
            */
            return default;
        }

        public async Task<TEntity> RefundsOriginRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _refunds_origin_required(self):
            // return False
            */
            return default;
        }

        public async Task<TEntity> RequireBillDateForAutopostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ResetApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> RetryEdiDocumentsErrorHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move.py) ---
            // def _retry_edi_documents_error_hook(self):
            // ''' Hook called when edi_documents are retried. For example, when it's needed to clean a field.
            // TO OVERRIDE
            // '''
            // return
            */
            return default;
        }

        public async Task<TEntity> ReverseMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_values_list, object cancel) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def _reverse_moves(self, default_values_list=None, cancel=False):
            // # OVERRIDE
            // if not default_values_list:
            //     default_values_list = [{} for move in self]
            // for move, default_values in zip(self, default_values_list):
            //     default_values.update({
            //         'campaign_id': move.campaign_id.id,
            //         'medium_id': move.medium_id.id,
            //         'source_id': move.source_id.id,
            //     })
            // return super()._reverse_moves(default_values_list=default_values_list, cancel=cancel)
            */
            return default;
        }

        public async Task<TEntity> RoutingCheckRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object route, object raise_exception) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _routing_check_route(self, message, message_dict, route, raise_exception=True):
            // if route[0] == 'account.move' and len(message_dict['attachments']) < 1:
            //     # Don't create the move if no attachment.
            //     body = self.env['ir.qweb']._render('account.email_template_mail_gateway_failed', {
            //         'company_email': self.env.company.email,
            //         'company_name': self.env.company.name,
            //     })
            //     self._routing_create_bounce_email(
            //         message_dict['from'], body, message,
            //         references=f'{message_dict["message_id"]} {generate_tracking_message_id("loop-detection-bounce-email")}')
            //     return ()
            // return super()._routing_check_route(message, message_dict, route, raise_exception=raise_exception)
            */
            return default;
        }

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> SearchApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_application_status(self, operator, value):
            // supported_operators = ['=', '!=', 'in', 'not in']
            // if operator not in supported_operators:
            //     raise UserError(_('Operation not supported'))
            // 
            // # Normalize value to be a list to simplify processing
            // if isinstance(value, (str, bool)):
            //     value = [value]
            // 
            // # Ensure all values are either correct strings or False
            // valid_statuses = ['ongoing', 'hired', 'refused', 'archived']
            // if not all(v in valid_statuses or v is False for v in value):
            //     raise UserError(_('Some values do not exist in the application status'))
            // 
            // # Map statuses to domain filters
            // for status in value:
            //     if status == 'refused':
            //         domain = [('refuse_reason_id', '!=', None)]
            //     elif status == 'hired':
            //         domain = [('date_closed', '!=', False)]
            //     elif status == 'archived' or status is False:
            //         domain = [('active', '=', False)]
            //     elif status == 'ongoing':
            //         domain = ['&', ('active', '=', True), ('date_closed', '=', False)]
            // 
            // # Invert the domain for '!=' and 'not in' operators
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     domain.insert(0, expression.NOT_OPERATOR)
            //     domain = expression.distribute_not(domain)
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchDefaultJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //     currency_id = self.currency_id.id or self._context.get('default_currency_id')
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

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // """ Override to support ordering on my_activity_date_deadline.
            // 
            // Ordering through web client calls search_read() with an order parameter
            // set. Method search_read() then calls search_fetch(). Here we override
            // search_fetch() to intercept a search with an order on field
            // my_activity_date_deadline. In that case we do the search in two steps.
            // 
            // First step: fill with deadline-based results
            // 
            //   * Perform a read_group on my activities to get a mapping lead_id / deadline
            //     Remember date_deadline is required, we always have a value for it. Only
            //     the earliest deadline per lead is kept.
            //   * Search leads linked to those activities that also match the asked domain
            //     and order from the original search request.
            //   * Results of that search will be at the top of returned results. Use limit
            //     None because we have to search all leads linked to activities as ordering
            //     on deadline is done in post processing.
            //   * Reorder them according to deadline asc or desc depending on original
            //     search ordering. Finally take only a subset of those leads to fill with
            //     results matching asked offset / limit.
            // 
            // Second step: fill with other results. If first step does not gives results
            // enough to match offset and limit parameters we fill with a search on other
            // leads. We keep the asked domain and ordering while filtering out already
            // scanned leads to keep a coherent results.
            // 
            // All other search and search_read are left untouched by this override to avoid
            // side effects. Search_count is not affected by this override.
            // """
            // if not order or 'my_activity_date_deadline' not in order:
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // order_items = [order_item.strip().lower() for order_item in (order or self._order).split(',')]
            // 
            // # Perform a read_group on my activities to get a mapping lead_id / deadline
            // # Remember date_deadline is required, we always have a value for it. Only
            // # the earliest deadline per lead is kept.
            // activity_asc = any('my_activity_date_deadline asc' in item for item in order_items)
            // my_lead_activities = self.env['mail.activity']._read_group(
            //     [('res_model', '=', self._name), ('user_id', '=', self.env.uid)],
            //     ['res_id'],
            //     ['date_deadline:min'],
            //     order='date_deadline:min ASC, res_id',
            // )
            // my_lead_mapping = dict(my_lead_activities)
            // my_lead_ids = list(my_lead_mapping.keys())
            // my_lead_domain = expression.AND([[('id', 'in', my_lead_ids)], domain])
            // my_lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // # Search leads linked to those activities and order them. See docstring
            // # of this method for more details.
            // search_res = super().search_fetch(my_lead_domain, field_names, order=my_lead_order)
            // my_lead_ids_ordered = sorted(search_res.ids, key=lambda lead_id: my_lead_mapping[lead_id], reverse=not activity_asc)
            // # keep only requested window (offset + limit, or offset+)
            // my_lead_ids_keep = my_lead_ids_ordered[offset:(offset + limit)] if limit else my_lead_ids_ordered[offset:]
            // # keep list of already skipped lead ids to exclude them from future search
            // my_lead_ids_skip = my_lead_ids_ordered[:(offset + limit)] if limit else my_lead_ids_ordered
            // 
            // # do not go further if limit is achieved
            // if limit and len(my_lead_ids_keep) >= limit:
            //     return self.browse(my_lead_ids_keep)
            // 
            // # Fill with remaining leads. If a limit is given, simply remove count of
            // # already fetched. Otherwise keep none. If an offset is set we have to
            // # reduce it by already fetch results hereabove. Order is updated to exclude
            // # my_activity_date_deadline when calling super() .
            // lead_limit = (limit - len(my_lead_ids_keep)) if limit else None
            // if offset:
            //     lead_offset = max((offset - len(search_res), 0))
            // else:
            //     lead_offset = 0
            // lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // other_lead_res = super().search_fetch(
            //     expression.AND([[('id', 'not in', my_lead_ids_skip)], domain]),
            //     field_names, lead_offset, lead_limit, lead_order,
            // )
            // return self.browse(my_lead_ids_keep) + other_lead_res
            */
            return default;
        }

        public async Task<TEntity> SearchInvoiceIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _search_invoice_ids(self, operator, value):
            // if operator == 'in' and value:
            //     self.env.cr.execute("""
            //         SELECT array_agg(so.id)
            //             FROM sale_order so
            //             JOIN sale_order_line sol ON sol.order_id = so.id
            //             JOIN sale_order_line_invoice_rel soli_rel ON soli_rel.order_line_id = sol.id
            //             JOIN account_move_line aml ON aml.id = soli_rel.invoice_line_id
            //             JOIN account_move am ON am.id = aml.move_id
            //         WHERE
            //             am.move_type in ('out_invoice', 'out_refund') AND
            //             am.id = ANY(%s)
            //     """, (list(value),))
            //     so_ids = self.env.cr.fetchone()[0] or []
            //     return [('id', 'in', so_ids)]
            // elif operator == '=' and not value:
            //     # special case for [('invoice_ids', '=', False)], i.e. "Invoices is not set"
            //     #
            //     # We cannot just search [('order_line.invoice_lines', '=', False)]
            //     # because it returns orders with uninvoiced lines, which is not
            //     # same "Invoices is not set" (some lines may have invoices and some
            //     # doesn't)
            //     #
            //     # A solution is making inverted search first ("orders with invoiced
            //     # lines") and then invert results ("get all other orders")
            //     #
            //     # Domain below returns subset of ('order_line.invoice_lines', '!=', False)
            //     order_ids = self._search([
            //         ('order_line.invoice_lines.move_id.move_type', 'in', ('out_invoice', 'out_refund'))
            //     ])
            //     return [('id', 'not in', order_ids)]
            // return [
            //     ('order_line.invoice_lines.move_id.move_type', 'in', ('out_invoice', 'out_refund')),
            //     ('order_line.invoice_lines.move_id', operator, value),
            // ]
            */
            return default;
        }

        public async Task<TEntity> SearchJournalGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_journal_group_id(self, operator, value):
            // field = 'name' if 'like' in operator else 'id'
            // journal_groups = self.env['account.journal.group'].search([(field, operator, value)])
            // return [('journal_id', 'not in', journal_groups.excluded_journal_ids.ids)]
            */
            return default;
        }

        public async Task<TEntity> SearchNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_next_payment_date(self, operator, value):
            // if operator not in ('=', '<', '<='):
            //     raise UserError(self.env._('Operation not supported'))
            // return [('line_ids', 'any', [('reconciled', '=', False), ('payment_date', operator, value)])]
            */
            return default;
        }

        public async Task<TEntity> SearchOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def search_or_create(self, vals_list):
            // """Get existing or newly created records matching vals_list items in preserved order supporting duplicates."""
            // if not isinstance(vals_list, list):
            //     _logger.warning("Deprecated usage of LinkTracker.search_or_create which now expects a list of dictionaries as input.")
            //     vals_list = [vals_list]
            // 
            // def _format_key(obj):
            //     """Generate unique 'key' of trackers, allowing to find duplicates."""
            //     return tuple(
            //         (field_name, obj[field_name].id if isinstance(obj[field_name], models.BaseModel) else obj[field_name])
            //         for field_name in LINK_TRACKER_UNIQUE_FIELDS
            //     )
            // 
            // def _format_key_domain(field_values):
            //     """Handle "label" being False / '' and be defensive."""
            //     return expression.AND([
            //         [(field_name, '=', value) if value or field_name != 'label' else ('label', 'in', (False, ''))]
            //         for field_name, value in field_values
            //     ])
            // 
            // errors = set()
            // for vals in vals_list:
            //     if 'url' not in vals:
            //         raise ValueError(_('Creating a Link Tracker without URL is not possible'))
            //     if vals['url'].startswith(('?', '#')):
            //         errors.add(_("“%s” is not a valid link, links cannot redirect to the current page.", vals['url']))
            //     vals['url'] = validate_url(vals['url'])
            //     # fill vals to use direct accessor in _format_key
            //     self._add_missing_default_values(vals)
            //     vals.update({key: False for key in LINK_TRACKER_UNIQUE_FIELDS if not vals.get(key)})
            // if errors:
            //     raise UserError("\n".join(errors))
            // 
            // # Find unique keys of trackers, then fetch existing trackers
            // unique_keys = {_format_key(vals) for vals in vals_list}
            // found_trackers = self.search(expression.OR([_format_key_domain(key) for key in unique_keys]))
            // key_to_trackers_map = {_format_key(tracker): tracker for tracker in found_trackers}
            // 
            // if len(unique_keys) != len(found_trackers):
            //     # Create trackers for values with unique keys not found
            //     seen_keys = set(key_to_trackers_map.keys())
            //     new_trackers = self.create([
            //         vals for vals in vals_list
            //         if (key := _format_key(vals)) not in seen_keys and not seen_keys.add(key)
            //     ])
            //     key_to_trackers_map.update((_format_key(tracker), tracker) for tracker in new_trackers)
            // 
            // # Build final recordset following input order
            // return self.browse([key_to_trackers_map[_format_key(vals)].id for vals in vals_list])
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_partner_name(self, operator, value):
            // return [('candidate_id.partner_name', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _search_secured(self, operator, value):
            // if operator not in ['=', '!='] or value not in [True, False]:
            //     raise UserError(_('Operation not supported'))
            // 
            // want_secured = (operator == '=') == value
            // return [('inalterable_hash', '!=' if want_secured else '=', False)]
            */
            return default;
        }

        public async Task<TEntity> SelectExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expected_dates) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _select_expected_date(self, expected_dates):
            // self.ensure_one()
            // return min(expected_dates)
            */
            return default;
        }

        public async Task<TEntity> SendOnlyWhenReadyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> SendOrderConfirmationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _send_order_confirmation_mail(self):
            // """ Send a mail to the SO customer to inform them that their order has been confirmed.
            // 
            // :return: None
            // """
            // for order in self:
            //     mail_template = order._get_confirmation_template()
            //     order._send_order_notification_mail(mail_template)
            */
            return default;
        }

        public async Task<TEntity> SendOrderNotificationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _send_order_notification_mail(self, mail_template):
            // """ Send a mail to the customer
            // 
            // Note: self.ensure_one()
            // 
            // :param mail.template mail_template: the template used to generate the mail
            // :return: None
            // """
            // self.ensure_one()
            // 
            // if not mail_template:
            //     return
            // 
            // if self.env.su:
            //     # sending mail in sudo was meant for it being sent from superuser
            //     self = self.with_user(SUPERUSER_ID)
            // 
            // self.with_context(force_send=True).message_post_with_source(
            //     mail_template,
            //     email_layout_xmlid='mail.mail_notification_layout_with_responsible_signature',
            //     subtype_xmlid='mail.mt_comment',
            // )
            */
            return default;
        }

        public async Task<TEntity> SendPaymentSucceededForOrderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _send_payment_succeeded_for_order_mail(self):
            // """ Send a mail to the SO customer to inform them that a payment has been initiated.
            // 
            // :return: None
            // """
            // mail_template = self.env.ref(
            //     'sale.mail_template_sale_payment_executed', raise_if_not_found=False
            // )
            // for order in self:
            //     order._send_order_notification_mail(mail_template)
            */
            return default;
        }

        public async Task<TEntity> SequenceFixedRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_fixed_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_fixed_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_monthly_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_monthly_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_yearly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_yearly_regex
            */
            return default;
        }

        public async Task<TEntity> SetNextMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities, bool made_gap) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> SetPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object purchase_orders, object force_write) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py) ---
            // def _set_purchase_orders(self, purchase_orders, force_write=True):
            // """Link the given purchase orders to this vendor bill and add their lines as invoice lines.
            // 
            // :param purchase_orders: a list of purchase orders to be linked to this vendor bill
            // :param force_write: whether to delete all existing invoice lines before adding the vendor bill lines
            // """
            // with self.env.cr.savepoint():
            //     with self._get_edi_creation() as invoice:
            //         if force_write and invoice.line_ids:
            //             invoice.invoice_line_ids = [Command.clear()]
            //         for purchase_order in purchase_orders:
            //             invoice.invoice_line_ids = [Command.create({
            //                 'display_type': 'line_section',
            //                 'name': _('From %s', purchase_order.name)
            //             })]
            //             invoice.purchase_id = purchase_order
            //             invoice._onchange_purchase_auto_complete()
            */
            return default;
        }

        public async Task<TEntity> SetReversedEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credit_note) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ShouldBeLockedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _should_be_locked(self):
            // self.ensure_one()
            // # Public user can confirm SO, so we check the group on any record creator.
            // user = self[:1].create_uid
            // return user and user.sudo().has_group('sale.group_auto_done_setting')
            */
            return default;
        }

        public async Task<TEntity> ShowAutopostBillsWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> ShowCancelWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _show_cancel_wizard(self):
            // """ Decide whether the sale.order.cancel wizard should be shown to cancel specified orders.
            // 
            // :return: True if there is any non-draft order in the given orders
            // :rtype: bool
            // """
            // if self.env.context.get('disable_cancel_warning'):
            //     return False
            // return any(so.state != 'draft' for so in self)
            */
            return default;
        }

        public async Task<TEntity> SortByConfidenceLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _sort_by_confidence_level(self, reverse=False):
            // """ Sorting the leads/opps according to the confidence level to it
            // being won. It is sorted following this incremental heuristics :
            // 
            //   * "not lost" first (inactive leads are lost); normally all leads
            //     should be active but in case lost one, they are always last.
            //     Inactive opportunities are considered as valid;
            //   * opportunity is more reliable than a lead which is a pre-stage
            //     used mainly for first classification;
            //   * stage sequence: the higher the better as it indicates we are moving
            //     towards won stage;
            //   * probability: the higher the better as it is more likely to be won;
            //   * ID: the higher the better when all other parameters are equal. We
            //     consider newer leads to be more reliable;
            // """
            // def opps_key(opportunity):
            //     return opportunity.type == 'opportunity' or opportunity.active,  \
            //         opportunity.type == 'opportunity', \
            //         opportunity.stage_id.sequence, \
            //         opportunity.probability, \
            //         -opportunity._origin.id
            // 
            // return self.sorted(key=opps_key, reverse=reverse)
            */
            return default;
        }

        protected async Task<object> SplitNameAndCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_mixin.py) ---
            // def _split_name_and_count(name):
            // """
            // Return the name part and the counter based on the given name.
            // 
            // e.g.
            //     "Medium" -> "Medium", 1
            //     "Medium [1234]" -> "Medium", 1234
            // """
            // name = name or ''
            // name_counter_re = r'(.*)\s+\[([0-9]+)\]'
            // match = re.match(name_counter_re, name)
            // if match:
            //     return match.group(1), int(match.group(2) or '1')
            // return name, 1
            */
            return default;
        }

        public async Task<TEntity> StageFindInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid team_id, object domain, object order, object limit) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _stage_find(self, team_id=False, domain=None, order='sequence, id', limit=1):
            // """ Determine the stage of the current lead with its teams, the given domain and the given team_id
            //     :param team_id
            //     :param domain : base search domain for stage
            //     :param order : base search order for stage
            //     :param limit : base search limit for stage
            //     :returns crm.stage recordset
            // """
            // # collect all team_ids by adding given one, and the ones related to the current leads
            // team_ids = set()
            // if team_id:
            //     team_ids.add(team_id)
            // for lead in self:
            //     if lead.team_id:
            //         team_ids.add(lead.team_id.id)
            // # generate the domain
            // if team_ids:
            //     search_domain = ['|', ('team_id', '=', False), ('team_id', 'in', list(team_ids))]
            // else:
            //     search_domain = [('team_id', '=', False)]
            // # AND with the domain in parameter
            // if domain:
            //     search_domain += list(domain)
            // # perform search, return the first found
            // return self.env['crm.stage'].search(search_domain, order=order, limit=limit)
            */
            return default;
        }

        public async Task<TEntity> StockAccountAngloSaxonReconcileValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _stock_account_anglo_saxon_reconcile_valuation(self, product=False):
            // """ Reconciles the entries made in the interim accounts in anglosaxon accounting,
            // reconciling stock valuation move lines with the invoice's.
            // """
            // reconcile_plan = []
            // no_exchange_reconcile_plan = []
            // for move in self:
            //     if not move.is_invoice():
            //         continue
            //     if not move.company_id.anglo_saxon_accounting:
            //         continue
            // 
            //     stock_moves = move._stock_account_get_last_step_stock_moves()
            //     # In case we return a return, we have to provide the related AMLs so all can be reconciled
            //     stock_moves |= stock_moves.origin_returned_move_id
            // 
            //     if not stock_moves:
            //         continue
            // 
            //     products = product or move.mapped('invoice_line_ids.product_id')
            //     for prod in products:
            //         if prod.valuation != 'real_time':
            //             continue
            // 
            //         # We first get the invoices move lines (taking the invoice and the previous ones into account)...
            //         product_accounts = prod.product_tmpl_id._get_product_accounts()
            //         if move.is_sale_document():
            //             product_interim_account = product_accounts['stock_output']
            //         else:
            //             product_interim_account = product_accounts['stock_input']
            // 
            //         if product_interim_account.reconcile:
            //             # Search for anglo-saxon lines linked to the product in the journal entry.
            //             product_account_moves = move.line_ids.filtered(
            //                 lambda line: line.product_id == prod and line.account_id == product_interim_account and not line.reconciled)
            // 
            //             # Search for anglo-saxon lines linked to the product in the stock moves.
            //             product_stock_moves = stock_moves._get_all_related_sm(prod)
            //             product_account_moves |= product_stock_moves._get_all_related_aml().filtered(
            //                 lambda line: line.account_id == product_interim_account and not line.reconciled and line.move_id.state == "posted"
            //             )
            // 
            //             correction_amls = product_account_moves.filtered(
            //                 lambda aml: aml.move_id.sudo().stock_valuation_layer_ids.stock_valuation_layer_id or (aml.display_type == 'cogs' and not aml.quantity)
            //             )
            //             invoice_aml = product_account_moves.filtered(lambda aml: aml not in correction_amls and aml.move_id == move)
            //             stock_aml = product_account_moves - correction_amls - invoice_aml
            // 
            //             # Reconcile:
            //             # In case there is a move with correcting lines that has not been posted
            //             # (e.g., it's dated for some time in the future) we should defer any
            //             # reconciliation with exchange difference.
            //             if correction_amls or 'draft' in move.line_ids.sudo().stock_valuation_layer_ids.account_move_id.mapped('state'):
            //                 if sum(correction_amls.mapped('balance')) > 0 or all(aml.is_same_currency for aml in correction_amls):
            //                     no_exchange_reconcile_plan += [product_account_moves]
            //                 else:
            //                     no_exchange_reconcile_plan += [invoice_aml | correction_amls]
            //                     moves_to_reconcile = (invoice_aml.filtered(lambda aml: not aml.reconciled) | stock_aml)
            //                     if moves_to_reconcile:
            //                         no_exchange_reconcile_plan += [moves_to_reconcile]
            //             else:
            //                 reconcile_plan += [product_account_moves]
            // self.env['account.move.line']._reconcile_plan(reconcile_plan)
            // no_exchange_reconcile_plan = [amls.filtered(lambda aml: not aml.reconciled) for amls in no_exchange_reconcile_plan]
            // self.env['account.move.line'].with_context(no_exchange_difference=True)._reconcile_plan(no_exchange_reconcile_plan)
            */
            return default;
        }

        public async Task<TEntity> StockAccountGetLastStepStockMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py) ---
            // def _stock_account_get_last_step_stock_moves(self):
            // stock_moves = super(AccountMove, self)._stock_account_get_last_step_stock_moves()
            // for invoice in self.filtered(lambda x: x.move_type == 'out_invoice'):
            //     stock_moves += invoice.sudo().mapped('pos_order_ids.picking_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_dest_id.usage == 'customer')
            // for invoice in self.filtered(lambda x: x.move_type == 'out_refund'):
            //     stock_moves += invoice.sudo().mapped('pos_order_ids.picking_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_id.usage == 'customer')
            // return stock_moves
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py) ---
            // def _stock_account_get_last_step_stock_moves(self):
            // """ Overridden from stock_account.
            // Returns the stock moves associated to this invoice."""
            // rslt = super(AccountMove, self)._stock_account_get_last_step_stock_moves()
            // for invoice in self.filtered(lambda x: x.move_type == 'in_invoice'):
            //     rslt += invoice.mapped('invoice_line_ids.purchase_line_id.move_ids').filtered(lambda x: x.state == 'done' and x.location_id.usage == 'supplier')
            // for invoice in self.filtered(lambda x: x.move_type == 'in_refund'):
            //     rslt += invoice.mapped('invoice_line_ids.purchase_line_id.move_ids').filtered(lambda x: x.state == 'done' and x.location_dest_id.usage == 'supplier')
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py) ---
            // def _stock_account_get_last_step_stock_moves(self):
            // """ Overridden from stock_account.
            // Returns the stock moves associated to this invoice."""
            // rslt = super(AccountMove, self)._stock_account_get_last_step_stock_moves()
            // for invoice in self:
            //     if invoice.move_type not in ['out_invoice', 'out_refund']:
            //         continue
            //     if (invoice.move_type == 'out_invoice' or (
            //         invoice.move_type == 'out_refund' and any(invoice.invoice_line_ids.sale_line_ids.mapped('is_downpayment')))
            //     ):
            //         rslt += invoice.mapped('invoice_line_ids.sale_line_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_dest_id.usage == 'customer')
            //     else:
            //         rslt += invoice.mapped('reversed_entry_id.invoice_line_ids.sale_line_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_id.usage == 'customer')
            //         # Add refunds generated from the SO
            //         rslt += invoice.mapped('invoice_line_ids.sale_line_ids.move_ids').filtered(lambda x: x.state == 'done' and x.location_id.usage == 'customer')
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _stock_account_get_last_step_stock_moves(self):
            // """ To be overridden for customer invoices and vendor bills in order to
            // return the stock moves related to the invoices in self.
            // """
            // return self.env['stock.move']
            */
            return default;
        }

        public async Task<TEntity> StockAccountPrepareAngloSaxonInLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py) ---
            // def _stock_account_prepare_anglo_saxon_in_lines_vals(self):
            // ''' Prepare values used to create the journal items (account.move.line) corresponding to the price difference
            //  lines for vendor bills. It only concerns the quantities that have been delivered before the bill
            // Example:
            // Buy a product having a cost of 9 and a supplier price of 10 and being a storable product and having a perpetual
            // valuation in FIFO. Deliver the product and then post the bill. The vendor bill's journal entries looks like:
            // Account                                     | Debit | Credit
            // ---------------------------------------------------------------
            // 101120 Stock Interim Account (Received)     | 10.0  |
            // ---------------------------------------------------------------
            // 101100 Account Payable                      |       | 10.0
            // ---------------------------------------------------------------
            // This method computes values used to make two additional journal items:
            // ---------------------------------------------------------------
            // 101120 Stock Interim Account (Received)     |       | 1.0
            // ---------------------------------------------------------------
            // xxxxxx Expenses                             | 1.0   |
            // ---------------------------------------------------------------
            // :return: A list of Python dictionary to be passed to env['account.move.line'].create.
            // '''
            // lines_vals_list = []
            // price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            // 
            // for move in self:
            //     if move.move_type not in ('in_invoice', 'in_refund', 'in_receipt') or not move.company_id.anglo_saxon_accounting:
            //         continue
            // 
            //     move = move.with_company(move.company_id)
            //     for line in move.invoice_line_ids:
            //         # Filter out lines being not eligible for price difference.
            //         # Moreover, this function is used for standard cost method only.
            //         if not line._eligible_for_cogs() or line.product_id.cost_method != 'standard':
            //             continue
            // 
            //         # Retrieve accounts needed to generate the price difference.
            //         debit_pdiff_account = False
            //         if line.product_id.cost_method == 'standard':
            //             debit_pdiff_account = line.product_id.property_account_creditor_price_difference \
            //                 or line.product_id.categ_id.property_account_creditor_price_difference_categ
            //             debit_pdiff_account = move.fiscal_position_id.map_account(debit_pdiff_account)
            //         else:
            //             debit_pdiff_account = line.product_id.product_tmpl_id.get_product_accounts(fiscal_pos=move.fiscal_position_id)['expense']
            //         if not debit_pdiff_account:
            //             continue
            // 
            //         price_unit_val_dif, relevant_qty = line._get_price_unit_val_dif_and_relevant_qty()
            //         price_subtotal = relevant_qty * price_unit_val_dif
            // 
            //         # We consider there is a price difference if the subtotal is not zero. In case a
            //         # discount has been applied, we can't round the price unit anymore, and hence we
            //         # can't compare them.
            //         if (
            //             not move.currency_id.is_zero(price_subtotal)
            //             and float_compare(line["price_unit"], line.price_unit, precision_digits=price_unit_prec) == 0
            //         ):
            // 
            //             # Add price difference account line.
            //             vals = {
            //                 'name': line.name[:64],
            //                 'move_id': move.id,
            //                 'partner_id': line.partner_id.id or move.commercial_partner_id.id,
            //                 'currency_id': line.currency_id.id,
            //                 'product_id': line.product_id.id,
            //                 'product_uom_id': line.product_uom_id.id,
            //                 'quantity': relevant_qty,
            //                 'price_unit': price_unit_val_dif,
            //                 'price_subtotal': relevant_qty * price_unit_val_dif,
            //                 'amount_currency': relevant_qty * price_unit_val_dif * line.move_id.direction_sign,
            //                 'balance': line.currency_id._convert(
            //                     relevant_qty * price_unit_val_dif * line.move_id.direction_sign,
            //                     line.company_currency_id,
            //                     line.company_id, fields.Date.today(),
            //                 ),
            //                 'account_id': debit_pdiff_account.id,
            //                 'analytic_distribution': line.analytic_distribution,
            //                 'display_type': 'cogs',
            //             }
            //             lines_vals_list.append(vals)
            // 
            //             # Correct the amount of the current line.
            //             vals = {
            //                 'name': line.name[:64],
            //                 'move_id': move.id,
            //                 'partner_id': line.partner_id.id or move.commercial_partner_id.id,
            //                 'currency_id': line.currency_id.id,
            //                 'product_id': line.product_id.id,
            //                 'product_uom_id': line.product_uom_id.id,
            //                 'quantity': relevant_qty,
            //                 'price_unit': -price_unit_val_dif,
            //                 'price_subtotal': relevant_qty * -price_unit_val_dif,
            //                 'amount_currency': relevant_qty * -price_unit_val_dif * line.move_id.direction_sign,
            //                 'balance': line.currency_id._convert(
            //                     relevant_qty * -price_unit_val_dif * line.move_id.direction_sign,
            //                     line.company_currency_id,
            //                     line.company_id, fields.Date.today(),
            //                 ),
            //                 'account_id': line.account_id.id,
            //                 'analytic_distribution': line.analytic_distribution,
            //                 'display_type': 'cogs',
            //             }
            //             lines_vals_list.append(vals)
            // return lines_vals_list
            */
            return default;
        }

        public async Task<TEntity> StockAccountPrepareAngloSaxonOutLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_account, FILE: account_move.py) ---
            // def _stock_account_prepare_anglo_saxon_out_lines_vals(self):
            // ''' Prepare values used to create the journal items (account.move.line) corresponding to the Cost of Good Sold
            // lines (COGS) for customer invoices.
            // 
            // Example:
            // 
            // Buy a product having a cost of 9 being a storable product and having a perpetual valuation in FIFO.
            // Sell this product at a price of 10. The customer invoice's journal entries looks like:
            // 
            // Account                                     | Debit | Credit
            // ---------------------------------------------------------------
            // 200000 Product Sales                        |       | 10.0
            // ---------------------------------------------------------------
            // 101200 Account Receivable                   | 10.0  |
            // ---------------------------------------------------------------
            // 
            // This method computes values used to make two additional journal items:
            // 
            // ---------------------------------------------------------------
            // 220000 Expenses                             | 9.0   |
            // ---------------------------------------------------------------
            // 101130 Stock Interim Account (Delivered)    |       | 9.0
            // ---------------------------------------------------------------
            // 
            // Note: COGS are only generated for customer invoices except refund made to cancel an invoice.
            // 
            // :return: A list of Python dictionary to be passed to env['account.move.line'].create.
            // '''
            // lines_vals_list = []
            // price_unit_prec = self.env['decimal.precision'].precision_get('Product Price')
            // for move in self:
            //     # Make the loop multi-company safe when accessing models like product.product
            //     move = move.with_company(move.company_id)
            // 
            //     if not move.is_sale_document(include_receipts=True) or not move.company_id.anglo_saxon_accounting:
            //         continue
            // 
            //     anglo_saxon_price_ctx = move._get_anglo_saxon_price_ctx()
            // 
            //     for line in move.invoice_line_ids:
            // 
            //         # Filter out lines being not eligible for COGS.
            //         if not line._eligible_for_cogs():
            //             continue
            // 
            //         # Retrieve accounts needed to generate the COGS.
            //         accounts = line.product_id.product_tmpl_id.get_product_accounts(fiscal_pos=move.fiscal_position_id)
            //         debit_interim_account = accounts['stock_output']
            //         credit_expense_account = accounts['expense'] or move.journal_id.default_account_id
            //         if not debit_interim_account or not credit_expense_account:
            //             continue
            // 
            //         # Compute accounting fields.
            //         sign = -1 if move.move_type == 'out_refund' else 1
            //         price_unit = line.with_context(anglo_saxon_price_ctx)._stock_account_get_anglo_saxon_price_unit()
            //         amount_currency = sign * line.quantity * price_unit
            // 
            //         if move.currency_id.is_zero(amount_currency) or float_is_zero(price_unit, precision_digits=price_unit_prec):
            //             continue
            // 
            //         # Add interim account line.
            //         lines_vals_list.append({
            //             'name': line.name[:64],
            //             'move_id': move.id,
            //             'partner_id': move.commercial_partner_id.id,
            //             'product_id': line.product_id.id,
            //             'product_uom_id': line.product_uom_id.id,
            //             'quantity': line.quantity,
            //             'price_unit': price_unit,
            //             'amount_currency': -amount_currency,
            //             'account_id': debit_interim_account.id,
            //             'display_type': 'cogs',
            //             'tax_ids': [],
            //             'cogs_origin_id': line.id,
            //         })
            // 
            //         # Add expense account line.
            //         lines_vals_list.append({
            //             'name': line.name[:64],
            //             'move_id': move.id,
            //             'partner_id': move.commercial_partner_id.id,
            //             'product_id': line.product_id.id,
            //             'product_uom_id': line.product_uom_id.id,
            //             'quantity': line.quantity,
            //             'price_unit': -price_unit,
            //             'amount_currency': amount_currency,
            //             'account_id': credit_expense_account.id,
            //             'analytic_distribution': line.analytic_distribution,
            //             'display_type': 'cogs',
            //             'tax_ids': [],
            //             'cogs_origin_id': line.id,
            //         })
            // return lines_vals_list
            */
            return default;
        }

        public async Task<TEntity> StolenMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> SyncDynamicLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object existing_key_fname, object needed_vals_fname, object needed_dirty_fname, object line_type, object container) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> SyncDynamicLineNeededValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> SyncDynamicLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_dynamic_lines(self, container):
            // with self._disable_recursion(container, 'skip_invoice_sync') as disabled:
            //     if disabled:
            //         yield
            //         return
            //     def update_containers():
            //         # Only invoice-like and journal entries in "auto tax mode" are synced
            //         tax_container['records'] = container['records'].filtered(lambda m: m.is_invoice(True) or m.line_ids.tax_ids or m.line_ids.tax_repartition_line_id)
            //         invoice_container['records'] = container['records'].filtered(lambda m: m.is_invoice(True))
            //         misc_container['records'] = container['records'].filtered(lambda m: m.is_entry() and not m.tax_cash_basis_origin_move_id)
            // 
            //     tax_container, invoice_container, misc_container = ({} for __ in range(3))
            //     update_containers()
            //     with ExitStack() as stack:
            //         stack.enter_context(self._sync_dynamic_line(
            //             existing_key_fname='term_key',
            //             needed_vals_fname='needed_terms',
            //             needed_dirty_fname='needed_terms_dirty',
            //             line_type='payment_term',
            //             container=invoice_container,
            //         ))
            //         stack.enter_context(self._sync_unbalanced_lines(misc_container))
            //         stack.enter_context(self._sync_rounding_lines(invoice_container))
            //         stack.enter_context(self._sync_dynamic_line(
            //             existing_key_fname='discount_allocation_key',
            //             needed_vals_fname='line_ids.discount_allocation_needed',
            //             needed_dirty_fname='line_ids.discount_allocation_dirty',
            //             line_type='discount',
            //             container=invoice_container,
            //         ))
            //         stack.enter_context(self._sync_tax_lines(tax_container))
            //         stack.enter_context(self._sync_dynamic_line(
            //             existing_key_fname='epd_key',
            //             needed_vals_fname='line_ids.epd_needed',
            //             needed_dirty_fname='line_ids.epd_dirty',
            //             line_type='epd',
            //             container=invoice_container,
            //         ))
            //         stack.enter_context(self._sync_invoice(invoice_container))
            //         line_container = {'records': self.line_ids}
            //         with self.line_ids._sync_invoice(line_container):
            //             yield
            //             line_container['records'] = self.line_ids
            //         update_containers()
            */
            return default;
        }

        public async Task<TEntity> SyncInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> SyncRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> SyncTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sync_tax_lines(self, container):
            // AccountTax = self.env['account.tax']
            // fake_base_line = AccountTax._prepare_base_line_for_taxes_computation(None)
            // 
            // def get_base_lines(move):
            //     return move.line_ids.filtered(lambda line: line.display_type in ('product', 'epd', 'rounding', 'cogs'))
            // 
            // def get_tax_lines(move):
            //     return move.line_ids.filtered('tax_repartition_line_id')
            // 
            // def get_value(record, field):
            //     return self.env['account.move.line']._fields[field].convert_to_write(record[field], record)
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
            //         for field in ('currency_id', 'partner_id', 'move_type')
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
            //     elif any(line not in base_lines for line, values in move_base_lines_values_before.items() if values['tax_ids']):
            //         # Removed a base line affecting the taxes.
            //         round_from_tax_lines = any_field_has_changed(move_tax_lines_values_before, tax_lines)
            //     else:
            //         continue
            // 
            //     base_lines_values, tax_lines_values = move._get_rounded_base_and_tax_lines(round_from_tax_lines=round_from_tax_lines)
            //     AccountTax._add_accounting_data_in_base_lines_tax_details(base_lines_values, move.company_id, include_caba_tags=move.always_tax_exigible)
            //     tax_results = AccountTax._prepare_tax_lines(base_lines_values, move.company_id, tax_lines=tax_lines_values)
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
            //     for tax_line_vals, grouping_key, to_update in tax_results['tax_lines_to_update']:
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

        public async Task<TEntity> SyncUnbalancedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> SynchronizeBusinessModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changed_fields) where TEntity : IEntity<Guid>, IUtmMixinable
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
            // if self._context.get('skip_account_move_synchronization'):
            //     return
            // 
            // self_sudo = self.sudo()
            // self_sudo.statement_line_id._synchronize_from_moves(changed_fields)
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def toggle_active(self):
            // """ When archiving: mark probability as 0. When re-activating
            // update probability again, for leads and opportunities. """
            // res = super(Lead, self).toggle_active()
            // activated = self.filtered(lambda lead: lead.active)
            // archived = self.filtered(lambda lead: not lead.active)
            // if activated:
            //     activated.write({'lost_reason_id': False})
            //     activated._compute_probabilities()
            // if archived:
            //     archived.write({'probability': 0, 'automated_probability': 0})
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def toggle_active(self):
            // self = self.with_context(just_unarchived=True)
            // res = super(Applicant, self).toggle_active()
            // active_applicants = self.filtered(lambda applicant: applicant.active)
            // if active_applicants:
            //     active_applicants.reset_applicant()
            // return res
            */
            return default;
        }

        public async Task<TEntity> TrackFinalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _track_finalize(self):
            // """ Override of `mail` to prevent logging changes when the SO is in a draft state. """
            // if (len(self) == 1
            //     # The method _track_finalize is sometimes called too early or too late and it
            //     # might cause a desynchronization with the cache, thus this condition is needed.
            //     and self.env.cache.contains(self, self._fields['state']) and self._discard_tracking()):
            //     self.env.cr.precommit.data.pop(f'mail.tracking.{self._name}', {})
            //     self.env.flush_all()
            //     return
            // return super()._track_finalize()
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values and self.probability == 100 and self.stage_id:
            //     return self.env.ref('crm.mt_lead_won')
            // elif 'lost_reason_id' in init_values and self.lost_reason_id:
            //     return self.env.ref('crm.mt_lead_lost')
            // elif 'stage_id' in init_values:
            //     return self.env.ref('crm.mt_lead_stage')
            // elif 'active' in init_values and self.active:
            //     return self.env.ref('crm.mt_lead_restored')
            // elif 'active' in init_values and not self.active:
            //     return self.env.ref('crm.mt_lead_lost')
            // return super(Lead, self)._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_subtype(self, init_values):
            // record = self[0]
            // if 'stage_id' in init_values and record.stage_id:
            //     return self.env.ref('hr_recruitment.mt_applicant_stage_changed')
            // return super(Applicant, self)._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'state' in init_values and self.state == 'sale':
            //     return self.env.ref('sale.mt_order_confirmed')
            // elif 'state' in init_values and self.state == 'sent':
            //     return self.env.ref('sale.mt_order_sent')
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_template(self, changes):
            // res = super(Applicant, self)._track_template(changes)
            // applicant = self[0]
            // # When applcant is unarchived, they are put back to the default stage automatically. In this case,
            // # don't post automated message related to the stage change.
            // if 'stage_id' in changes and applicant.exists()\
            //     and applicant.stage_id.template_id\
            //     and not applicant._context.get('just_moved')\
            //     and not applicant._context.get('just_unarchived'):
            //     res['stage_id'] = (applicant.stage_id.template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'hr_recruitment.mail_notification_light_without_background'
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> TrackingFieldsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_mixin.py) ---
            // def tracking_fields(self):
            // # This function cannot be overridden in a model which inherit utm.mixin
            // # Limitation by the heritage on AbstractModel
            // # record_crm_lead.tracking_fields() will call tracking_fields() from module utm.mixin (if not overridden on crm.lead)
            // # instead of the overridden method from utm.mixin.
            // # To force the call of overridden method, we use self.env['utm.mixin'].tracking_fields() which respects overridden
            // # methods of utm.mixin, but will ignore overridden method on crm.lead
            // return [
            //     # ("URL_PARAMETER", "FIELD_NAME_MIXIN", "NAME_IN_COOKIES")
            //     ('utm_campaign', 'campaign_id', 'odoo_utm_campaign'),
            //     ('utm_source', 'source_id', 'odoo_utm_source'),
            //     ('utm_medium', 'medium_id', 'odoo_utm_medium'),
            // ]
            */
            return default;
        }

        public async Task<TEntity> TrackingModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_mixin.py) ---
            // def _tracking_models(self):
            // fnames = {fname for _, fname, _ in self.tracking_fields()}
            // return {
            //     self._fields[fname].comodel_name
            //     for fname in fnames
            //     if fname in self._fields and self._fields[fname].type == "many2one"
            // }
            */
            return default;
        }

        public async Task<TEntity> UblParseAttachedDocumentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py) ---
            // def _ubl_parse_attached_document(self, tree):
            // """
            // In UBL, an AttachedDocument file is a wrapper around multiple different UBL files.
            // According to the specifications the original document is stored within the top most
            // Attachment node either as an Attachment/EmbeddedDocumentBinaryObject or (in special cases)
            // a CDATA string stored in Attachment/ExternalReference/Description.
            // 
            // We must parse this before passing the original file to the decoder to figure out how best
            // to handle it.
            // """
            // attachment_node = tree.find('{*}Attachment')
            // if attachment_node is None:
            //     return tree
            // 
            // attachment_binary_data = attachment_node.find('./{*}EmbeddedDocumentBinaryObject')
            // if attachment_binary_data is not None \
            //         and attachment_binary_data.attrib.get('mimeCode') in ('application/xml', 'text/xml'):
            //     with suppress(etree.XMLSyntaxError, binascii.Error):
            //         text = b64decode(attachment_binary_data.text)
            //         return etree.fromstring(text)
            // 
            // external_reference = attachment_node.find('./{*}ExternalReference')
            // if external_reference is not None:
            //     description = external_reference.findtext('./{*}Description')
            //     mime_code = external_reference.findtext('./{*}MimeCode')
            // 
            //     if description and mime_code in ('application/xml', 'text/xml'):
            //         with suppress(etree.XMLSyntaxError):
            //             return etree.fromstring(description.encode('utf-8'))
            // return tree
            */
            return default;
        }

        public async Task<TEntity> UnlinkAccountAuditTrailExceptOncePostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _unlink_account_audit_trail_except_once_post(self):
            // if not self._context.get('force_delete') and any(
            //         move.posted_before and move.company_id.check_account_audit_trail
            //         for move in self
            // ):
            //     raise UserError(_(
            //         "To keep the audit trail, you can not delete journal entries once they have been posted.\n"
            //         "Instead, you can cancel the journal entry."
            //     ))
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def unlink(self):
            // """ Update meetings when removing opportunities, otherwise you have
            // a link to a record that does not lead anywhere. """
            // meetings = self.env['calendar.event'].search([
            //     ('res_id', 'in', self.ids),
            //     ('res_model', '=', self._name),
            // ])
            // if meetings:
            //     meetings.write({
            //         'res_id': False,
            //         'res_model_id': False,
            //     })
            // return super(Lead, self).unlink()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: account_move.py) ---
            // def unlink(self):
            // downpayment_lines = self.mapped('line_ids.sale_line_ids').filtered(lambda line: line.is_downpayment and line.invoice_lines <= self.mapped('line_ids'))
            // res = super(AccountMove, self).unlink()
            // if downpayment_lines:
            //     downpayment_lines.unlink()
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDraftOrCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _unlink_except_draft_or_cancel(self):
            // for order in self:
            //     if order.state not in ('draft', 'cancel'):
            //         raise UserError(_(
            //             "You can not delete a sent quotation or a confirmed sales order."
            //             " You must first cancel it."))
            */
            return default;
        }

        public async Task<TEntity> UnlinkForbidPartsOfChainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            //     or self._context.get('force_delete')
            //     or self.check_move_sequence_chain()
            // ):
            //     raise UserError(_(
            //         "You cannot delete this entry, as it has already consumed a sequence number and is not the last one in the chain. "
            //         "You should probably revert it instead."
            //     ))
            */
            return default;
        }

        public async Task<TEntity> UnlinkOrReverseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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
            // to_cancel.button_cancel()
            // return to_reverse._reverse_moves(cancel=True)
            */
            return default;
        }

        public async Task<TEntity> UpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _update_automated_probabilities(self):
            // """ Recompute all the automated_probability (and align probability if both were aligned) for all the leads
            // that are active (not won, nor lost).
            // 
            // For performance matter, as there can be a huge amount of leads to recompute, this cron proceed by batch.
            // Each batch is performed into its own transaction, in order to minimise the lock time on the lead table
            // (and to avoid complete lock if there was only 1 transaction that would last for too long -> several minutes).
            // If a concurrent update occurs, it will simply be put in the queue to get the lock.
            // """
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return
            // 
            // # 1. Get all the leads to recompute created after pls_start_date that are nor won nor lost
            // # (Won : probability = 100 | Lost : probability = 0 or inactive. Here, inactive won't be returned anyway)
            // # Get also all the lead without probability --> These are the new leads. Activate auto probability on them.
            // pending_lead_domain = [
            //     '&',
            //         '&',
            //             ('stage_id', '!=', False), ('create_date', '>=', pls_start_date),
            //         '|',
            //             ('probability', '=', False),
            //             '&',
            //                 ('probability', '<', 100), ('probability', '>', 0)
            // ]
            // leads_to_update = self.env['crm.lead'].search(pending_lead_domain)
            // leads_to_update_count = len(leads_to_update)
            // 
            // # 2. Compute by batch to avoid memory error
            // lead_probabilities = {}
            // for i in range(0, leads_to_update_count, PLS_COMPUTE_BATCH_STEP):
            //     leads_to_update_part = leads_to_update[i:i + PLS_COMPUTE_BATCH_STEP]
            //     lead_probabilities.update(leads_to_update_part._pls_get_naive_bayes_probabilities(batch_mode=True))
            // _logger.info("Predictive Lead Scoring : New automated probabilities computed")
            // 
            // # 3. Group by new probability to reduce server roundtrips when executing the update
            // probability_leads = defaultdict(list)
            // for lead_id, probability in sorted(lead_probabilities.items()):
            //     probability_leads[probability].append(lead_id)
            // 
            // # 4. Update automated_probability (+ probability if both were equal)
            // update_sql = """UPDATE crm_lead
            //                 SET automated_probability = %s,
            //                     probability = CASE WHEN (probability = automated_probability OR probability is null)
            //                                        THEN (%s)
            //                                        ELSE (probability)
            //                                   END
            //                 WHERE id in %s"""
            // 
            // # Update by a maximum number of leads at the same time, one batch by transaction :
            // # - avoid memory errors
            // # - avoid blocking the table for too long with a too big transaction
            // transactions_count, transactions_failed_count = 0, 0
            // cron_update_lead_start_date = datetime.now()
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
            // self.flush_model()
            // for probability, probability_lead_ids in probability_leads.items():
            //     for lead_ids_current in tools.split_every(PLS_UPDATE_BATCH_STEP, probability_lead_ids):
            //         transactions_count += 1
            //         try:
            //             self.env.cr.execute(update_sql, (probability, probability, tuple(lead_ids_current)))
            //             # auto-commit except in testing mode
            //             if auto_commit:
            //                 self.env.cr.commit()
            //         except Exception as e:
            //             _logger.warning("Predictive Lead Scoring : update transaction failed. Error: %s" % e)
            //             transactions_failed_count += 1
            // self.invalidate_model()
            // 
            // _logger.info(
            //     "Predictive Lead Scoring : All automated probabilities updated (%d leads / %d transactions (%d failed) / %d seconds)" % (
            //         leads_to_update_count,
            //         transactions_count,
            //         transactions_failed_count,
            //         (datetime.now() - cron_update_lead_start_date).total_seconds(),
            //     )
            // )
            */
            return default;
        }

        public async Task<TEntity> UpdateOrderLineInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _update_order_line_info(self, product_id, quantity, **kwargs):
            // """ Update sale order line information for a given product or create a
            // new one if none exists yet.
            // :param int product_id: The product, as a `product.product` id.
            // :return: The unit price of the product, based on the pricelist of the
            //          sale order and the quantity selected.
            // :rtype: float
            // """
            // request.update_context(catalog_skip_tracking=True)
            // sol = self.order_line.filtered(lambda line: line.product_id.id == product_id)
            // if sol:
            //     if quantity != 0:
            //         sol.product_uom_qty = quantity
            //     elif self.state in ['draft', 'sent']:
            //         price_unit = self.pricelist_id._get_product_price(
            //             product=sol.product_id,
            //             quantity=1.0,
            //             currency=self.currency_id,
            //             date=self.date_order,
            //             **kwargs,
            //         )
            //         sol.unlink()
            //         return price_unit
            //     else:
            //         sol.product_uom_qty = 0
            // elif quantity > 0:
            //     sol = self.env['sale.order.line'].create({
            //         'order_id': self.id,
            //         'product_id': product_id,
            //         'product_uom_qty': quantity,
            //         'sequence': ((self.order_line and self.order_line[-1].sequence + 1) or 10),  # put it at the end of the order
            //     })
            // return sol.price_unit * (1-(sol.discount or 0.0)/100.0)
            */
            return default;
        }

        public async Task<TEntity> ValidateOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _validate_order(self):
            // """
            // Confirm the sale order and send a confirmation email.
            // 
            // :return: None
            // """
            // self.with_context(send_email=True).action_confirm()
            */
            return default;
        }

        public async Task<TEntity> ValidateTaxesCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmMixinable
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

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IUtmMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def write(self, vals):
            // if vals.get('website'):
            //     vals['website'] = self.env['res.partner']._clean_website(vals['website'])
            // 
            // now = self.env.cr.now()
            // stage_updated, stage_is_won = False, False
            // # stage change (or reset): update date_last_stage_update if at least one
            // # lead does not have the same stage
            // if 'stage_id' in vals:
            //     stage_updated = any(lead.stage_id.id != vals['stage_id'] for lead in self)
            //     if stage_updated:
            //         vals['date_last_stage_update'] = now
            //     if stage_updated and vals.get('stage_id'):
            //         stage = self.env['crm.stage'].browse(vals['stage_id'])
            //         if stage.is_won:
            //             vals.update({'probability': 100, 'automated_probability': 100})
            //             stage_is_won = True
            // # user change; update date_open if at least one lead does not
            // # have the same user
            // if 'user_id' in vals and not vals.get('user_id'):
            //     vals['date_open'] = False
            // elif vals.get('user_id'):
            //     user_updated = any(lead.user_id.id != vals['user_id'] for lead in self)
            //     if user_updated:
            //         vals['date_open'] = now
            // 
            // # stage change with new stage: update probability and date_closed
            // if vals.get('probability', 0) >= 100 or not vals.get('active', True):
            //     vals['date_closed'] = fields.Datetime.now()
            // elif vals.get('probability', 0) > 0:
            //     vals['date_closed'] = False
            // elif stage_updated and not stage_is_won and not 'probability' in vals:
            //     vals['date_closed'] = False
            // 
            // if any(field in ['active', 'stage_id'] for field in vals):
            //     self._handle_won_lost(vals)
            // 
            // if not stage_is_won:
            //     return super(Lead, self).write(vals)
            // 
            // # stage change between two won stages: does not change the date_closed
            // leads_already_won = self.filtered(lambda lead: lead.stage_id.is_won)
            // remaining = self - leads_already_won
            // if remaining:
            //     result = super(Lead, remaining).write(vals)
            // if leads_already_won:
            //     vals.pop('date_closed', False)
            //     result = super(Lead, leads_already_won).write(vals)
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
            //         res = super().write(vals)
            // else:
            //     res = super().write(vals)
            // if 'interviewer_ids' in vals:
            //     interviewers_to_clean = old_interviewers - self.interviewer_ids
            //     interviewers_to_clean._remove_recruitment_interviewers()
            //     self.sudo().interviewer_ids._create_recruitment_interviewers()
            //     self.message_unsubscribe(partner_ids=interviewers_to_clean.partner_id.ids)
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
            //                 record_name=applicant.display_name,
            //                 model_description="Applicant",
            //             )
            // if vals.get('date_closed'):
            //     for applicant in self:
            //         if applicant.job_id.date_to:
            //             applicant.candidate_id.availability = applicant.job_id.date_to + relativedelta(days=1)
            // 
            // if vals.get("company_id") and not self.env.context.get('do_not_propagate_company', False):
            //     self.candidate_id.with_context(do_not_propagate_company=True).write({"company_id": vals["company_id"]})
            //     self.candidate_id.applicant_ids.with_context(do_not_propagate_company=True).write({"company_id": vals["company_id"]})
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def write(self, vals):
            // if 'pricelist_id' in vals and any(so.state == 'sale' for so in self):
            //     raise UserError(_("You cannot change the pricelist of a confirmed order !"))
            // res = super().write(vals)
            // if vals.get('partner_id'):
            //     self.filtered(lambda so: so.state in ('sent', 'sale')).message_subscribe(
            //         partner_ids=[vals['partner_id']],
            //     )
            // return res
            */
            return default;
        }
    }
}