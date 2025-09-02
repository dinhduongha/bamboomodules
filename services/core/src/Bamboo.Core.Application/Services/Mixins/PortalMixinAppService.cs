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
    [Module("portal", Depends = new[] { "web", "web_editor", "http_routing", "mail", "auth_signup" })]
    public class PortalMixinAppService : ApplicationService, IPortalMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public PortalMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionActivateCurrencyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_activate_currency(self):
            // self.currency_id.filtered(lambda currency: not currency.active).write({'active': True})
            */
            return default;
        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_add_from_catalog(self):
            // res = super().action_add_from_catalog()
            // if res['context'].get('product_catalog_order_model') == 'account.move':
            //     res['search_view_id'] = [self.env.ref('account.product_view_search_catalog').id, 'search']
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_add_from_catalog(self):
            // res = super().action_add_from_catalog()
            // if res['context'].get('product_catalog_order_model') == 'purchase.order':
            //     res['search_view_id'] = [self.env.ref('purchase.product_view_search_catalog').id, 'search']
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_archive(self):
            // child_tasks = self.child_ids.filtered(lambda child_task: not child_task.display_in_project)
            // if child_tasks:
            //     child_tasks.action_archive()
            // self.filtered(lambda t: not t.display_in_project and t.parent_id).display_in_project = True
            // return super().action_archive()
            */
            return default;
        }

        public async Task<TEntity> ActionBillMatchingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_bill_matching(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Bill Matching"),
            //     'res_model': 'purchase.bill.line.match',
            //     'domain': [
            //         ('partner_id', '=', self.partner_id.id),
            //         ('company_id', 'in', self.env.company.ids),
            //         ('purchase_order_id', 'in', [self.id, False]),
            //     ],
            //     'views': [(self.env.ref('purchase.purchase_bill_line_match_tree').id, 'list')],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionConfigureBankJournalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def action_configure_bank_journal(self):
            // """ This function is called by the "configure" button of bank journals,
            // visible on dashboard if no bank statement source has been defined yet
            // """
            // # We simply call the setup bar function.
            // return self.env['res.company'].with_context(default_linked_journal_id=self.id).setting_init_bank_account_action()
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionConvertToSubtaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_convert_to_subtask(self):
            // self.ensure_one()
            // if self.project_id:
            //     return {
            //         'name': _('Convert to Task/Sub-Task'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'project.task',
            //         'res_id': self.id,
            //         'views': [(self.env.ref('project.project_task_convert_to_subtask_view_form', False).id, 'form')],
            //         'target': 'new',
            //     }
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'danger',
            //         'message': _('Private tasks cannot be converted into sub-tasks. Please set a project on the task to gain access to this feature.'),
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionCreateInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_create_invoice(self):
            // """Create the invoice associated to the PO.
            // """
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // 
            // # 1) Prepare invoice vals and clean-up the section lines
            // invoice_vals_list = []
            // sequence = 10
            // for order in self:
            //     if order.invoice_status != 'to invoice':
            //         continue
            // 
            //     order = order.with_company(order.company_id)
            //     pending_section = None
            //     # Invoice values.
            //     invoice_vals = order._prepare_invoice()
            //     # Invoice line values (keep only necessary sections).
            //     for line in order.order_line:
            //         if line.display_type == 'line_section':
            //             pending_section = line
            //             continue
            //         if not float_is_zero(line.qty_to_invoice, precision_digits=precision):
            //             if pending_section:
            //                 line_vals = pending_section._prepare_account_move_line()
            //                 line_vals.update({'sequence': sequence})
            //                 invoice_vals['invoice_line_ids'].append((0, 0, line_vals))
            //                 sequence += 1
            //                 pending_section = None
            //             line_vals = line._prepare_account_move_line()
            //             line_vals.update({'sequence': sequence})
            //             invoice_vals['invoice_line_ids'].append((0, 0, line_vals))
            //             sequence += 1
            //     invoice_vals_list.append(invoice_vals)
            // 
            // if not invoice_vals_list:
            //     raise UserError(_('There is no invoiceable line. If a product has a control policy based on received quantity, please make sure that a quantity has been received.'))
            // 
            // # 2) group by (company_id, partner_id, currency_id) for batch creation
            // new_invoice_vals_list = []
            // for grouping_keys, invoices in groupby(invoice_vals_list, key=lambda x: (x.get('company_id'), x.get('partner_id'), x.get('currency_id'))):
            //     origins = set()
            //     payment_refs = set()
            //     refs = set()
            //     ref_invoice_vals = None
            //     for invoice_vals in invoices:
            //         if not ref_invoice_vals:
            //             ref_invoice_vals = invoice_vals
            //         else:
            //             ref_invoice_vals['invoice_line_ids'] += invoice_vals['invoice_line_ids']
            //         origins.add(invoice_vals['invoice_origin'])
            //         payment_refs.add(invoice_vals['payment_reference'])
            //         refs.add(invoice_vals['ref'])
            //     ref_invoice_vals.update({
            //         'ref': ', '.join(refs)[:2000],
            //         'invoice_origin': ', '.join(origins),
            //         'payment_reference': len(payment_refs) == 1 and payment_refs.pop() or False,
            //     })
            //     new_invoice_vals_list.append(ref_invoice_vals)
            // invoice_vals_list = new_invoice_vals_list
            // 
            // # 3) Create invoices.
            // moves = self.env['account.move']
            // AccountMove = self.env['account.move'].with_context(default_move_type='in_invoice')
            // for vals in invoice_vals_list:
            //     moves |= AccountMove.with_company(vals['company_id']).create(vals)
            // 
            // # 4) Some moves might actually be refunds: convert them if the total amount is negative
            // # We do this after the moves have been created since we need taxes, etc. to know if the total
            // # is actually negative or not
            // moves.filtered(lambda m: m.currency_id.round(m.amount_total) < 0).action_switch_move_type()
            // 
            // return self.action_view_invoice(moves)
            */
            return default;
        }

        public async Task<TEntity> ActionDependentTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_dependent_tasks(self):
            // self.ensure_one()
            // return {
            //     'res_model': 'project.task',
            //     'type': 'ir.actions.act_window',
            //     'context': {**self._context, 'default_depend_on_ids': [Command.link(self.id)], 'show_project_update': False, 'search_default_open_tasks': True},
            //     'domain': [('depend_on_ids', '=', self.id)],
            //     'name': _('Dependent Tasks'),
            //     'view_mode': 'list,form,kanban,calendar,pivot,graph,activity',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionForceRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionGetListViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_get_list_view(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("%(name)s's Milestones", name=self.name),
            //     'domain': [('project_id', '=', self.id)],
            //     'res_model': 'project.milestone',
            //     'views': [(self.env.ref('project.project_milestone_view_tree').id, 'list')],
            //     'view_mode': 'list',
            //     'help': _("""
            //         <p class="o_view_nocontent_smiling_face">
            //             No milestones found. Let's create one!
            //         </p><p>
            //             Track major progress points that must be reached to achieve success.
            //         </p>
            //     """),
            //     'context': {
            //         'default_project_id': self.id,
            //         **self.env.context
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceDownloadPdfAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionInvoiceReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionInvoiceSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_lock(self):
            // self.locked = True
            */
            return default;
        }

        public async Task<TEntity> ActionMergeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_merge(self):
            // all_origin = []
            // all_vendor_references = []
            // rfq_to_merge = self.filtered(lambda r: r.state in ['draft', 'sent'])
            // 
            // # Group RFQs by vendor
            // if len(rfq_to_merge) < 2:
            //     raise UserError(_("Please select at least two purchase orders with state RFQ and RFQ sent to merge."))
            // 
            // rfqs_grouped = defaultdict(lambda: self.env['purchase.order'])
            // for rfq in rfq_to_merge:
            //     key = self._prepare_grouped_data(rfq)
            //     rfqs_grouped[key] += rfq
            // 
            // bunches_of_rfq_to_be_merge = list(rfqs_grouped.values())
            // if all(len(rfq_bunch) == 1 for rfq_bunch in list(bunches_of_rfq_to_be_merge)):
            //     raise UserError(_("In selected purchase order to merge these details must be same\nVendor, currency, destination, dropship address and agreement"))
            // bunches_of_rfq_to_be_merge = [rfqs for rfqs in bunches_of_rfq_to_be_merge if len(rfqs) > 1]
            // 
            // for rfqs in bunches_of_rfq_to_be_merge:
            //     if len(rfqs) <= 1:
            //         continue
            //     oldest_rfq = min(rfqs, key=lambda r: r.date_order)
            //     if oldest_rfq:
            //         # Merge RFQs into the oldest purchase order
            //         rfqs -= oldest_rfq
            //         for rfq_line in rfqs.order_line:
            //             existing_line = oldest_rfq.order_line.filtered(lambda l: l.display_type not in ['line_note', 'line_section'] and
            //                                                                         l.product_id == rfq_line.product_id and
            //                                                                         l.product_uom == rfq_line.product_uom and
            //                                                                         l.product_packaging_id == rfq_line.product_packaging_id and
            //                                                                         l.product_packaging_qty == rfq_line.product_packaging_qty and
            //                                                                         l.analytic_distribution == rfq_line.analytic_distribution and
            //                                                                         l.discount == rfq_line.discount and
            //                                                                         abs(l.date_planned - rfq_line.date_planned).total_seconds() <= 86400  # 24 hours in seconds
            //                                                                 )
            //             if len(existing_line) > 1:
            //                 existing_line[0].product_qty += sum(existing_line[1:].mapped('product_qty'))
            //                 existing_line[1:].unlink()
            //                 existing_line = existing_line[0]
            // 
            //             if existing_line:
            //                 existing_line._merge_po_line(rfq_line)
            //             else:
            //                 rfq_line.order_id = oldest_rfq
            // 
            //         # Merge source documents and vendor references
            //         all_origin = rfqs.mapped('origin')
            //         all_vendor_references = rfqs.mapped('partner_ref')
            // 
            //         oldest_rfq.origin = ', '.join(filter(None, [oldest_rfq.origin, *all_origin]))
            //         oldest_rfq.partner_ref = ', '.join(filter(None, [oldest_rfq.partner_ref, *all_vendor_references]))
            // 
            //         rfq_names = rfqs.mapped('name')
            //         merged_names = ", ".join(rfq_names)
            //         oldest_rfq_message = _("RFQ merged with %(oldest_rfq_name)s and %(cancelled_rfq)s", oldest_rfq_name=oldest_rfq.name, cancelled_rfq=merged_names)
            // 
            //         for rfq in rfqs:
            //             cancelled_rfq_message = _("RFQ merged with %s", oldest_rfq._get_html_link())
            //             rfq.message_post(body=cancelled_rfq_message)
            //         oldest_rfq.message_post(body=oldest_rfq_message)
            // 
            //         rfqs.filtered(lambda r: r.state != 'cancel').button_cancel()
            //         oldest_rfq._merge_alternative_po(rfqs)
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'message': _('purchase orders merged'),
            //         'next': {'type': 'ir.actions.act_window_close'},
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionOpenDiscountWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionOpenParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_parent_task(self):
            // return {
            //     'name': _('Parent Task'),
            //     'view_mode': 'form',
            //     'res_model': 'project.task',
            //     'res_id': self.parent_id.id,
            //     'type': 'ir.actions.act_window',
            //     'context': self._context
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_ratings(self):
            // self.ensure_one()
            // action = self.env['ir.actions.act_window']._for_xml_id('project.rating_rating_action_task')
            // if self.rating_count == 1:
            //     action['view_mode'] = 'form'
            //     action['res_id'] = self.rating_ids[0].id
            //     action['views'] = [[self.env.ref('project.rating_rating_view_form_project').id, 'form']]
            //     return action
            // else:
            //     return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenShareProjectWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_open_share_project_wizard(self):
            // template = self.env.ref('project.mail_template_project_sharing', raise_if_not_found=False)
            // 
            // local_context = self.env.context | {
            //     'default_template_id': template.id if template else False,
            //     'default_email_layout_xmlid': 'mail.mail_notification_light',
            //     'active_id': self.id,
            //     'active_model': 'project.project',
            // }
            // action = self.env["ir.actions.actions"]._for_xml_id("project.project_share_wizard_action")
            // if self.env.context.get('default_access_mode'):
            //     action['name'] = _("Share Project")
            // action['context'] = local_context
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_open_task(self):
            // return {
            //     'view_mode': 'form',
            //     'res_model': 'project.task',
            //     'res_id': self.id,
            //     'type': 'ir.actions.act_window',
            //     'context': self._context
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionPosOrderInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionPosOrderPaidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionPostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ActionPreviewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionPrintPdfAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_print_pdf(self):
            // self.ensure_one()
            // return self.env.ref('account.account_invoices').report_action(self.id)
            */
            return default;
        }

        public async Task<TEntity> ActionProfitabilityItemsAsync<TEntity>(IEnumerable<TEntity> entities, object section_name, object domain, Guid res_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenBlockingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_open_blocking(self):
            // self.ensure_one()
            // blockings = self.dependent_ids
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_sharing_project_task_action_blocking_tasks')
            // if len(blockings) == 1:
            //     action['view_mode'] = 'form'
            //     action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form']
            //     action['res_id'] = blockings.id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenSubtasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_open_subtasks(self):
            // self.ensure_one()
            // subtasks = self.env['project.task'].search([('id', 'child_of', self.id), ('id', '!=', self.id)])
            // if subtasks.project_id == self.project_id:
            //     action = self.env['ir.actions.act_window']._for_xml_id('project.project_sharing_project_task_action_sub_task')
            //     if len(subtasks) == 1:
            //         action['view_mode'] = 'form'
            //         action['views'] = [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form']
            //         action['res_id'] = subtasks.id
            //     return action
            // return {
            //     'name': 'Portal Sub-tasks',
            //     'type': 'ir.actions.act_url',
            //     'url': f'/my/projects/{self.project_id.id}/task/{self.id}/subtasks' if len(subtasks) > 1 else subtasks.get_portal_url(query_string='project_sharing=1'),
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_open_task(self):
            // action = self.action_open_task()
            // action['views'] = [[self.env.ref('project.project_sharing_project_task_view_form').id, 'form']]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_recurring_tasks(self):
            // self.ensure_one()
            // recurrent_tasks = self.env['project.task'].search([('recurrence_id', 'in', self.recurrence_id.ids)])
            // # If all the recurrent tasks are in the same project, open the list view in sharing mode.
            // if recurrent_tasks.project_id == self.project_id:
            //     action = self.env['ir.actions.act_window']._for_xml_id('project.project_sharing_project_task_recurring_tasks_action')
            //     action.update({
            //         'context': {'default_project_id': self.project_id.id},
            //         'domain': [
            //             ('project_id', '=', self.project_id.id),
            //             ('recurrence_id', 'in', self.recurrence_id.ids)
            //         ]
            //     })
            //     return action
            // # If at least one recurrent task belong to another project, open the portal page
            // return {
            //     'name': 'Portal Recurrent Tasks',
            //     'type': 'ir.actions.act_url',
            //     'url':  f'/my/projects/{self.project_id.id}/task/{self.id}/recurrent_tasks',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingViewParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_project_sharing_view_parent_task(self):
            // if self.parent_id.project_id != self.project_id and self.env.user._is_portal():
            //     project = self.parent_id.project_id._filtered_access('read')
            //     if project:
            //         url = f"/my/projects/{self.parent_id.project_id.id}/task/{self.parent_id.id}"
            //         if project._check_project_sharing_access():
            //             url = f"/my/projects/{self.parent_id.project_id.id}?task_id={self.parent_id.id}"
            //         return {
            //             "name": "Portal Parent Task",
            //             "type": "ir.actions.act_url",
            //             "url": url,
            //         }
            //     elif self.display_parent_task_button:
            //         return self.parent_id.get_portal_url()
            //     # The portal user has no access to the parent task, so normally the button should be invisible.
            //     return {}
            // action = self.with_context({
            //     'search_view_ref': 'project.project_sharing_project_task_view_search',
            // }).action_open_parent_task()
            // action['views'] = [(self.env.ref('project.project_sharing_project_task_view_form').id, 'form')]
            // action['search_view_id'] = self.env.ref("project.project_sharing_project_task_view_search").id
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionProjectTaskBurndownChartReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_project_task_burndown_chart_report(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.action_project_task_burndown_chart_report')
            // action['display_name'] = _("%(name)s's Burndown Chart", name=self.name)
            // context = action['context'].replace('active_id', str(self.id))
            // context = ast.literal_eval(context)
            // context.update({
            //     'stage_name_and_sequence_per_id': {
            //         stage.id: {
            //             'sequence': stage.sequence,
            //             'name': stage.name
            //         } for stage in self.type_ids
            //     }
            // })
            // action['context'] = context
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionQuotationSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_recurring_tasks(self):
            // return {
            //     'name': _('Tasks in Recurrence'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'project.task',
            //     'view_mode': 'list,form,kanban,calendar,pivot,graph,activity',
            //     'context': {'create': False},
            //     'domain': [('recurrence_id', 'in', self.recurrence_id.ids)],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToProjectTaskFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_redirect_to_project_task_form(self):
            // menu_id = self.env.ref('project.menu_project_management_all_tasks').id
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': f"/odoo/1/action-project.act_project_project_2_project_task_all/{self.id}?menu_id={menu_id}",
            //     'target': 'new',
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionReverseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionRfqSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_rfq_send(self):
            // '''
            // This function opens a window to compose an email, with the edi purchase template message loaded by default
            // '''
            // self.ensure_one()
            // ir_model_data = self.env['ir.model.data']
            // try:
            //     if self.env.context.get('send_rfq', False):
            //         template_id = ir_model_data._xmlid_lookup('purchase.email_template_edi_purchase')[1]
            //     else:
            //         template_id = ir_model_data._xmlid_lookup('purchase.email_template_edi_purchase_done')[1]
            // except ValueError:
            //     template_id = False
            // try:
            //     compose_form_id = ir_model_data._xmlid_lookup('mail.email_compose_message_wizard_form')[1]
            // except ValueError:
            //     compose_form_id = False
            // ctx = dict(self.env.context or {})
            // ctx.update({
            //     'default_model': 'purchase.order',
            //     'default_res_ids': self.ids,
            //     'default_template_id': template_id,
            //     'default_composition_mode': 'comment',
            //     'default_email_layout_xmlid': "mail.mail_notification_layout_with_responsible_signature",
            //     'email_notification_allow_footer': True,
            //     'force_email': True,
            //     'mark_rfq_as_sent': True,
            // })
            // 
            // # In the case of a RFQ or a PO, we want the "View..." button in line with the state of the
            // # object. Therefore, we pass the model description in the context, in the language in which
            // # the template is rendered.
            // lang = self.env.context.get('lang')
            // if {'default_template_id', 'default_model', 'default_res_id'} <= ctx.keys():
            //     template = self.env['mail.template'].browse(ctx['default_template_id'])
            //     if template and template.lang:
            //         lang = template._render_lang([ctx['default_res_id']])[ctx['default_res_id']]
            // 
            // self = self.with_context(lang=lang)
            // if self.state in ['draft', 'sent']:
            //     ctx['model_description'] = _('Request for Quotation')
            // else:
            //     ctx['model_description'] = _('Purchase Order')
            // 
            // return {
            //     'name': _('Compose Email'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'views': [(compose_form_id, 'form')],
            //     'view_id': compose_form_id,
            //     'target': 'new',
            //     'context': ctx,
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionSendAndPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionSendMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionSendReceiptAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket_image, object basic_image) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def action_send_receipt(self, email, ticket_image, basic_image):
            // self.env['mail.mail'].sudo().create(self._prepare_mail_values(email, ticket_image, basic_image)).send()
            // self.email = email
            */
            return default;
        }

        public async Task<TEntity> ActionShareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py) ---
            // def action_share(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("portal.portal_share_action")
            // action['context'] = {'active_id': self.env.context['active_id'],
            //                      'active_model': self.env.context['active_model'],
            //                      **literal_eval(action['context'])}
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionStockPickingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ActionSwitchMoveTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionToggleBlockPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionUnlinkRecurrenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def action_unlink_recurrence(self):
            // self.recurrence_id.task_ids.recurring_task = False
            // self.recurrence_id.unlink()
            */
            return default;
        }

        public async Task<TEntity> ActionUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_unlock(self):
            // self.locked = False
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateFposValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionUpdatePricesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionUpdateTaxesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionViewAllRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_all_rating(self):
            // """ return the action to see all the rating of the project and activate default filters"""
            // action = self.env['ir.actions.act_window']._for_xml_id('project.rating_rating_action_view_project_rating')
            // action['display_name'] = _("%(name)s's Rating", name=self.name)
            // action_context = ast.literal_eval(action['context']) if action['context'] else {}
            // action_context.update(self._context)
            // action_context['search_default_filter_write_date'] = 'custom_write_date_last_30_days'
            // action_context.pop('group_by', None)
            // action['domain'] = [('consumed', '=', True), ('parent_res_model', '=', 'project.project'), ('parent_res_id', '=', self.id)]
            // if self.rating_count == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'views': [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form'],
            //         'res_id': self.rating_ids[0].id, # [0] since rating_ids might be > then rating_count
            //     })
            // return dict(action, context=action_context)
            */
            return default;
        }

        public async Task<TEntity> ActionViewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object invoices) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_view_invoice(self, invoices=False):
            // """This function returns an action that display existing vendor bills of
            // given purchase order ids. When only one found, show the vendor bill
            // immediately.
            // """
            // if not invoices:
            //     self.invalidate_model(['invoice_ids'])
            //     invoices = self.invoice_ids
            // 
            // result = self.env['ir.actions.act_window']._for_xml_id('account.action_move_in_invoice_type')
            // # choose the view_mode accordingly
            // if len(invoices) > 1:
            //     result['domain'] = [('id', 'in', invoices.ids)]
            // elif len(invoices) == 1:
            //     res = self.env.ref('account.view_move_form', False)
            //     form_view = [(res and res.id or False, 'form')]
            //     if 'views' in result:
            //         result['views'] = form_view + [(state, view) for state, view in result['views'] if view != 'form']
            //     else:
            //         result['views'] = form_view
            //     result['res_id'] = invoices.id
            // else:
            //     result = {'type': 'ir.actions.act_window_close'}
            // 
            // return result
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

        public async Task<TEntity> ActionViewRefundOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionViewRefundedOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ActionViewTasksAnalysisAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks_analysis(self):
            // """ return the action to see the tasks analysis report of the project """
            // action = self.env['ir.actions.act_window']._for_xml_id('project.action_project_task_user_tree')
            // action['display_name'] = _("%(name)s's Tasks Analysis", name=self.name)
            // action_context = ast.literal_eval(action['context']) if action['context'] else {}
            // action_context['search_default_project_id'] = self.id
            // return dict(action, context=action_context)
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks(self):
            // action = self.env['ir.actions.act_window'].with_context(active_id=self.id)._for_xml_id('project.act_project_project_2_project_task_all')
            // action['display_name'] = self.name
            // context = action['context'].replace('active_id', str(self.id))
            // context = ast.literal_eval(context)
            // context.update({
            //     'create': self.active,
            //     'active_test': self.active
            //     })
            // action['context'] = context
            // return action
            */
            return default;
        }

        public async Task<TEntity> AddBaseLinesForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> AddCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners, object limited_access) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _add_collaborators(self, partners, limited_access=False):
            // self.ensure_one()
            // new_collaborators = self._get_new_collaborators(partners)
            // if not new_collaborators:
            //     # Then we have nothing to do
            //     return
            // self.write({'collaborator_ids': [
            //     Command.create({
            //         'partner_id': collaborator.id,
            //         'limited_access': limited_access,
            //     }) for collaborator in new_collaborators],
            // })
            */
            return default;
        }

        public async Task<TEntity> AddFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _add_followers(self, partners):
            // self.ensure_one()
            // self.message_subscribe(partners.ids)
            // 
            // dict_tasks_per_partner = {}
            // dict_partner_ids_to_subscribe_per_partner = {}
            // for task in self.task_ids:
            //     if task.partner_id in dict_tasks_per_partner:
            //         dict_tasks_per_partner[task.partner_id] |= task
            //     else:
            //         partner_ids_to_subscribe = [
            //             partner.id for partner in partners
            //             if partner == task.partner_id or partner in task.partner_id.child_ids
            //         ]
            //         if partner_ids_to_subscribe:
            //             dict_tasks_per_partner[task.partner_id] = task
            //             dict_partner_ids_to_subscribe_per_partner[task.partner_id] = partner_ids_to_subscribe
            // for partner, tasks in dict_tasks_per_partner.items():
            //     tasks.message_subscribe(dict_partner_ids_to_subscribe_per_partner[partner])
            */
            return default;
        }

        public async Task<TEntity> AddMailAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> AddPaymentAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> AddSupplierToProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _add_supplier_to_product(self):
            // # Add the partner in the supplier list of the product if the supplier is not registered for
            // # this product. We limit to 10 the number of suppliers for a product to avoid the mess that
            // # could be caused for some generic products ("Miscellaneous").
            // for line in self.order_line:
            //     # Do not add a contact as a supplier
            //     partner = self.partner_id if not self.partner_id.parent_id else self.partner_id.parent_id
            //     already_seller = (partner | self.partner_id) & line.product_id.seller_ids.mapped('partner_id')
            //     if line.product_id and not already_seller and len(line.product_id.seller_ids) <= 10:
            //         price = line.price_unit
            //         # Compute the price for the template's UoM, because the supplier's UoM is related to that UoM.
            //         if line.product_id.product_tmpl_id.uom_po_id != line.product_uom:
            //             default_uom = line.product_id.product_tmpl_id.uom_po_id
            //             price = line.product_uom._compute_price(price, default_uom)
            // 
            //         supplierinfo = self._prepare_supplier_info(partner, line, price, line.currency_id)
            //         # In case the order partner is a contact address, a new supplierinfo is created on
            //         # the parent company. In this case, we keep the product name and code.
            //         seller = line.product_id._select_seller(
            //             partner_id=line.partner_id,
            //             quantity=line.product_qty,
            //             date=line.order_id.date_order and line.order_id.date_order.date(),
            //             uom_id=line.product_uom)
            //         if seller:
            //             supplierinfo['product_name'] = seller.product_name
            //             supplierinfo['product_code'] = seller.product_code
            //         vals = {
            //             'seller_ids': [(0, 0, supplierinfo)],
            //         }
            //         # supplier info should be added regardless of the user access rights
            //         line.product_id.product_tmpl_id.sudo().write(vals)
            */
            return default;
        }

        public async Task<TEntity> AffectTaxReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _affect_tax_report(self):
            // return any(line._affect_tax_report() for line in (self.line_ids | self.invoice_line_ids))
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _alias_get_creation_values(self):
            // values = super()._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get_id('account.move')
            // if self.id:
            //     values['alias_name'] = self._alias_prepare_alias_name(self.alias_name, self.name, self.code, self.type, self.company_id)
            //     values['alias_defaults'] = defaults = literal_eval(self.alias_defaults or "{}")
            //     defaults['company_id'] = self.company_id.id
            //     defaults['move_type'] = {
            //         'purchase': 'in_invoice',
            //         'sale': 'out_invoice',
            //     }.get(self.type, 'entry')
            //     defaults['journal_id'] = self.id
            // return values
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _alias_get_creation_values(self):
            // values = super(Project, self)._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('project.task').id
            // if self.id:
            //     values['alias_defaults'] = defaults = ast.literal_eval(self.alias_defaults or "{}")
            //     defaults['project_id'] = self.id
            // return values
            */
            return default;
        }

        public async Task<TEntity> AliasPrepareAliasNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alias_name, object name, object code, object jtype, object company) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _alias_prepare_alias_name(self, alias_name, name, code, jtype, company):
            // """ Tool method generating standard journal alias, to ensure uniqueness
            // and readability;  reset for other journals than purchase / sale """
            // if jtype not in ('purchase', 'sale'):
            //     return False
            // 
            // alias_name = next(
            //     (
            //         string for string in (alias_name, name, code, jtype)
            //         if (string and self.env['mail.alias']._is_encodable(string) and
            //             self.env['mail.alias']._sanitize_alias_name(string))
            //     ), False
            // )
            // if company != self.env.ref('base.main_company'):
            //     company_identifier = self.env['mail.alias']._sanitize_alias_name(company.name) if self.env['mail.alias']._is_encodable(company.name) else company.id
            //     if f'-{company_identifier}' not in alias_name:
            //         alias_name = f"{alias_name}-{company_identifier}"
            // return self.env['mail.alias']._sanitize_alias_name(alias_name)
            */
            return default;
        }

        public async Task<TEntity> AmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _amount_all(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     order_lines = order.order_line.filtered(lambda x: not x.display_type)
            //     base_lines = [line._prepare_base_line_for_taxes_computation() for line in order_lines]
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
            //     order.amount_total_cc = tax_totals['total_amount']
            */
            return default;
        }

        public async Task<TEntity> ApplyDeltaRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object date_origin, object period) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ApplyInvoicePaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_reverse) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ApprovalAllowedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _approval_allowed(self):
            // """Returns whether the order qualifies to be approved by the current user"""
            // self.ensure_one()
            // return (
            //     self.company_id.po_double_validation == 'one_step'
            //     or (self.company_id.po_double_validation == 'two_step'
            //         and self.amount_total < self.env.company.currency_id._convert(
            //             self.company_id.po_double_validation_amount, self.currency_id, self.company_id,
            //             self.date_order or fields.Date.today()))
            //     or self.env.user.has_group('purchase.group_purchase_manager'))
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _auto_init(self):
            // super()._auto_init()
            // if not index_exists(self.env.cr, 'account_move_checked_idx'):
            //     self.env.cr.execute("""
            //         CREATE INDEX account_move_checked_idx
            //                   ON account_move(journal_id)
            //                WHERE checked = false
            //     """)
            // if not index_exists(self.env.cr, 'account_move_payment_idx'):
            //     self.env.cr.execute("""
            //         CREATE INDEX account_move_payment_idx
            //                   ON account_move(journal_id, state, payment_state, move_type, date)
            //     """)
            // if not index_exists(self.env.cr, 'account_move_unique_name'):
            //     self.env.cr.execute("""
            //         CREATE UNIQUE INDEX account_move_unique_name
            //                          ON account_move(name, journal_id)
            //                       WHERE (state = 'posted' AND name != '/')
            //     """)
            // 
            // if not column_exists(self.env.cr, "account_move", "preferred_payment_method_line_id"):
            //     create_column(self.env.cr, "account_move", "preferred_payment_method_line_id", "int4")
            */
            return default;
        }

        public async Task<TEntity> AutopostBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> AutopostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> BuildCreditWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object current_amount, object exclude_current, object exclude_amount) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ButtonApproveAsync<TEntity>(IEnumerable<TEntity> entities, object force) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_approve(self, force=False):
            // self = self.filtered(lambda order: order._approval_allowed())
            // self.write({'state': 'purchase', 'date_approve': fields.Datetime.now()})
            // self.filtered(lambda p: p.company_id.po_lock == 'lock').write({'state': 'done'})
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ButtonCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            // self.payment_ids.state = "canceled"
            // self.write({'auto_post': 'no', 'state': 'cancel'})
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_cancel(self):
            // purchase_orders_with_invoices = self.filtered(lambda po: any(i.state not in ('cancel', 'draft') for i in po.invoice_ids))
            // if purchase_orders_with_invoices:
            //     raise UserError(_("Unable to cancel purchase order(s): %s. You must first cancel their related vendor bills.", format_list(self.env, purchase_orders_with_invoices.mapped('display_name'))))
            // self.write({'state': 'cancel', 'mail_reminder_confirmed': False})
            */
            return default;
        }

        public async Task<TEntity> ButtonConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_confirm(self):
            // for order in self:
            //     if order.state not in ['draft', 'sent']:
            //         continue
            //     order.order_line._validate_analytic_distribution()
            //     order._add_supplier_to_product()
            //     # Deal with double validation process
            //     if order._approval_allowed():
            //         order.button_approve()
            //     else:
            //         order.write({'state': 'to approve'})
            //     if order.partner_id not in order.message_partner_ids:
            //         order.message_subscribe([order.partner_id.id])
            // return True
            */
            return default;
        }

        public async Task<TEntity> ButtonDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_done(self):
            // self.write({'state': 'done', 'priority': '0'})
            */
            return default;
        }

        public async Task<TEntity> ButtonDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            // self.mapped('line_ids').remove_move_reconcile()
            // self.state = 'draft'
            // 
            // self._detach_attachments()
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_draft(self):
            // self.write({'state': 'draft'})
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ButtonHashAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_hash(self):
            // self._hash_moves(force_hash=True)
            */
            return default;
        }

        public async Task<TEntity> ButtonRequestCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ButtonSetCheckedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_set_checked(self):
            // for move in self:
            //     move.checked = True
            */
            return default;
        }

        public async Task<TEntity> ButtonUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_unlock(self):
            // self.write({'state': 'purchase'})
            */
            return default;
        }

        public async Task<TEntity> CalculateHashesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object previous_hash) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CanBeUnlinkedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CanForceCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ChangePrivacyVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_visibility) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _change_privacy_visibility(self, new_visibility):
            // """
            // Unsubscribe non-internal users from the project and tasks if the project privacy visibility
            // goes from 'portal' to a different value.
            // If the privacy visibility is set to 'portal', subscribe back project and tasks partners.
            // """
            // for project in self:
            //     if project.privacy_visibility == new_visibility:
            //         continue
            //     if new_visibility == 'portal':
            //         project.message_subscribe(partner_ids=project.partner_id.ids)
            //         for task in project.task_ids.filtered('partner_id'):
            //             task.message_subscribe(partner_ids=task.partner_id.ids)
            //     elif project.privacy_visibility == 'portal':
            //         portal_users = project.message_partner_ids.user_ids.filtered('share')
            //         project.message_unsubscribe(partner_ids=portal_users.partner_id.ids)
            //         project.tasks._unsubscribe_portal_users()
            //         # revoke access_token since the project and its tasks are no longer accessible for portal/public users
            //         project.tasks.access_token = ''
            //         project.access_token = ''
            */
            return default;
        }

        public async Task<TEntity> CheckAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_account_id(self):
            // # Overriden from 'analytic.plan.fields.mixin'
            // pass
            */
            return default;
        }

        public async Task<TEntity> CheckAndDecodeAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CheckAutoPostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_auto_post_draft_entries(self):
            // # constraint should be tested just after archiving a journal, but shouldn't be raised when unarchiving a journal containing draft entries
            // for journal in self.filtered(lambda j: not j.active):
            //     pending_moves = self.env['account.move'].search([
            //         ('journal_id', '=', journal.id),
            //         ('state', '=', 'draft')
            //     ], limit=1)
            // 
            //     if pending_moves:
            //         raise ValidationError(_("You can not archive a journal containing draft journal entries.\n\n"
            //                                 "To proceed:\n"
            //                                 "1/ click on the top-right button 'Journal Entries' from this journal form\n"
            //                                 "2/ then filter on 'Draft' entries\n"
            //                                 "3/ select them all and post or delete them through the action menu"))
            */
            return default;
        }

        public async Task<TEntity> CheckBalancedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CheckBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_bank_account(self):
            // for journal in self:
            //     if journal.type == 'bank' and journal.bank_account_id:
            //         if journal.bank_account_id.company_id and journal.bank_account_id.company_id != journal.company_id:
            //             raise ValidationError(_('The bank account of a bank journal must belong to the same company (%s).', journal.company_id.name))
            //         # A bank account can belong to a customer/supplier, in which case their partner_id is the customer/supplier.
            //         # Or they are part of a bank journal and their partner_id must be the company's partner_id.
            //         if journal.bank_account_id.partner_id != journal.company_id.partner_id:
            //             raise ValidationError(_('The holder of a journal\'s bank account must be the company (%s).', journal.company_id.name))
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_company_consistency(self):
            // for company, journals in groupby(self, lambda journal: journal.company_id):
            //     if self.env['account.move'].search_count([
            //         ('journal_id', 'in', [journal.id for journal in journals]),
            //         '!', ('company_id', 'child_of', company.id)
            //     ], limit=1):
            //         raise UserError(_("You can't change the company of your journal since there are some journal entries linked to it."))
            */
            return default;
        }

        public async Task<TEntity> CheckDraftableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_field_access_rights(self, operation, field_names):
            // result = super().check_field_access_rights(operation, field_names)
            // if not field_names:
            //     weirdos = ['needed_terms', 'quick_encoding_vals', 'payment_term_details']
            //     result = [fname for fname in result if fname not in weirdos]
            // return result
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def check_field_access_rights(self, operation, field_names):
            // if field_names and operation in ('read', 'write'):
            //     self._ensure_fields_are_accessible(field_names, operation)
            // elif not field_names and not self.env.su and self.env.user._is_portal():
            //     valid_names = self.SELF_READABLE_FIELDS
            //     return [
            //         fname for fname in super().check_field_access_rights(operation, field_names)
            //         if fname in valid_names
            //     ]
            // return super().check_field_access_rights(operation, field_names)
            */
            return default;
        }

        public async Task<TEntity> CheckFiscalLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CheckJournalMoveTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CheckMoveSequenceChainAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_move_sequence_chain(self):
            // return self.filtered(lambda move: move.name != '/')._is_end_of_seq_chain()
            */
            return default;
        }

        public async Task<TEntity> CheckNoCyclicDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _check_no_cyclic_dependencies(self):
            // if self._has_cycle('depend_on_ids'):
            //     raise ValidationError(_("Two tasks cannot depend on each other."))
            */
            return default;
        }

        public async Task<TEntity> CheckOrderLineCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
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

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('Error! You cannot create a recursive hierarchy of tasks.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodLineIdsMultiplicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_payment_method_line_ids_multiplicity(self):
            // """
            // Check and ensure that the payment method lines multiplicity is respected.
            // """
            // results = self._get_journals_payment_method_information()
            // pay_methods = results['pay_methods']
            // manage_providers = results['manage_providers']
            // method_information_mapping = results['method_information_mapping']
            // providers_per_code = results['providers_per_code']
            // 
            // failing_unicity_payment_methods = self.env['account.payment.method']
            // for journal in self:
            //     company = journal.company_id
            // 
            //     # Exclude the 'unique' / 'electronic' values that are already set on the journal.
            //     protected_provider_ids = set()
            //     protected_payment_method_ids = set()
            //     for payment_type in ('inbound', 'outbound'):
            //         lines = journal[f'{payment_type}_payment_method_line_ids']
            // 
            //         # Ensure you don't have the same payment_method/name combination twice on the same journal.
            //         counter = {}
            //         for line in lines:
            //             if method_information_mapping.get(line.payment_method_id.id, {}).get('mode') not in ('electronic', 'unique'):
            //                 continue
            // 
            //             key = line.payment_method_id.id, line.name
            //             counter.setdefault(key, 0)
            //             counter[key] += 1
            //             if counter[key] > 1:
            //                 raise ValidationError(_(
            //                     "You can't have two payment method lines of the same payment type (%(payment_type)s) "
            //                     "and with the same name (%(name)s) on a single journal.",
            //                     payment_type=payment_type,
            //                     name=line.name,
            //                 ))
            // 
            //         for line in lines:
            //             if line.payment_method_id.id in method_information_mapping:
            //                 protected_payment_method_ids.add(line.payment_method_id.id)
            //                 if manage_providers and method_information_mapping[line.payment_method_id.id]['mode'] == 'electronic':
            //                     protected_provider_ids.add(line.payment_provider_id.id)
            // 
            //     for pay_method in pay_methods:
            //         values = method_information_mapping[pay_method.id]
            // 
            //         if values['mode'] == 'unique':
            //             # 'unique' are linked to a single journal per company.
            //             already_linked_journal_ids = values['company_journals'].get(company.id, [])
            //             if len(already_linked_journal_ids) > 1:
            //                 failing_unicity_payment_methods |= pay_method
            //         elif manage_providers and values['mode'] == 'electronic':
            //             # 'electronic' are linked to a single journal per company per provider.
            //             for provider_id in providers_per_code.get(company.id, {}).get(pay_method.code, set()):
            //                 already_linked_journal_ids = values['company_journals'].get(company.id, {}).get(provider_id, [])
            //                 if len(already_linked_journal_ids) > 1:
            //                     failing_unicity_payment_methods |= pay_method
            // 
            // if failing_unicity_payment_methods:
            //     raise ValidationError(_(
            //         "Some payment methods supposed to be unique already exists somewhere else.\n(%s)",
            //         ', '.join(failing_unicity_payment_methods.mapped('display_name')),
            //     ))
            */
            return default;
        }

        public async Task<TEntity> CheckPrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CheckProjectSharingAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_project_sharing_access(self):
            // self.ensure_one()
            // if self.privacy_visibility != 'portal':
            //     return False
            // if self.env.user._is_portal():
            //     return self.env['project.collaborator'].search([('project_id', '=', self.sudo().id), ('partner_id', '=', self.env.user.partner_id.id)])
            // return self.env.user._is_internal()
            */
            return default;
        }

        public async Task<TEntity> CheckTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_total) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CheckTypeDefaultAccountIdTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _check_type_default_account_id_type(self):
            // for journal in self:
            //     if journal.type in ('sale', 'purchase') and journal.default_account_id.account_type in ('asset_receivable', 'liability_payable'):
            //         raise ValidationError(_("The type of the journal's default credit/debit account shouldn't be 'receivable' or 'payable'."))
            */
            return default;
        }

        public async Task<TEntity> CleanPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _clean_payment_lines(self):
            // self.ensure_one()
            // self.payment_ids.unlink()
            */
            return default;
        }

        public async Task<TEntity> CleanupWriteOrmValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CollectTaxCashBasisValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CompleteValuesFromSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object values) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeAbnormalWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeAccessInstructionMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_instruction_message(self):
            // for project in self:
            //     if project.privacy_visibility == 'portal':
            //         project.access_instruction_message = _('Grant portal users access to your project by adding them as followers (the tasks of the project are not included). To grant access to tasks to a portal user, add them as followers for these tasks.')
            //     elif project.privacy_visibility == 'followers':
            //         project.access_instruction_message = _('Grant employees access to your project or tasks by adding them as followers. Employees automatically get access to the tasks they are assigned to.')
            //     else:
            //         project.access_instruction_message = ''
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for move in self.filtered(lambda move: move.is_invoice()):
            //     move.access_url = '/my/invoices/%s' % (move.id)
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py) ---
            // def _compute_access_url(self):
            // for record in self:
            //     record.access_url = '#'
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_url(self):
            // super(Project, self)._compute_access_url()
            // for project in self:
            //     project.access_url = f'/my/projects/{project.id}'
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_access_url(self):
            // super(Task, self)._compute_access_url()
            // for task in self:
            //     task.access_url = f'/my/tasks/{task.id}'
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_access_url(self):
            // super(PurchaseOrder, self)._compute_access_url()
            // for order in self:
            //     order.access_url = '/my/purchase/%s' % (order.id)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for order in self:
            //     order.access_url = f'/my/orders/{order.id}'
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py) ---
            // def _compute_access_warning(self):
            // for mixin in self:
            //     mixin.access_warning = ''
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_warning(self):
            // super(Project, self)._compute_access_warning()
            // for project in self.filtered(lambda x: x.privacy_visibility != 'portal'):
            //     project.access_warning = _(
            //         "This project is currently restricted to \"Invited internal users\". The project's visibility will be changed to \"invited portal users and all internal users (public)\" in order to make it accessible to the recipients.")
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_access_warning(self):
            // super(Task, self)._compute_access_warning()
            // for task in self.filtered(lambda x: x.project_id.privacy_visibility != 'portal'):
            //     visibility_field = self.env['ir.model.fields'].search([('model', '=', 'project.project'), ('name', '=', 'privacy_visibility')], limit=1)
            //     visibility_public = self.env['ir.model.fields.selection'].search([('field_id', '=', visibility_field.id), ('value', '=', 'portal')])
            //     task.access_warning = _(
            //         "The task cannot be shared with the recipient(s) because the privacy of the project is too restricted. Set the privacy of the project to '%(visibility)s' in order to make it accessible by the recipient(s).",
            //         visibility=visibility_public.name,
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_accounting_date(self):
            // move_date = self.env.context.get('move_date') or fields.Date.context_today(self)
            // has_tax = self.env.context.get('has_tax') or False
            // for journal in self:
            //     temp_move = self.env['account.move'].new({'journal_id': journal.id})
            //     journal.accounting_date = temp_move._get_accounting_date(move_date, has_tax)
            */
            return default;
        }

        public async Task<TEntity> ComputeAlwaysTaxExigibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_invoiced(self):
            // for order in self:
            //     order.amount_invoiced = sum(order.order_line.mapped('amount_invoiced'))
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_to_invoice(self):
            // for order in self:
            //     order.amount_to_invoice = sum(order.order_line.mapped('amount_to_invoice'))
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalCcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_amount_total_cc(self):
            // for order in self:
            //     order.amount_total_cc = order.amount_total / order.currency_rate
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalWordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_amount_total_words(self):
            // for move in self:
            //     move.amount_total_words = move.currency_id.amount_to_text(move.amount_total).replace(',', '')
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountUndiscountedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_attachment_ids(self):
            // for task in self:
            //     attachment_ids = self.env['ir.attachment'].search(task._get_attachments_search_domain()).ids
            //     message_attachment_ids = task.mapped('message_ids.attachment_ids').ids  # from mail_thread
            //     task.attachment_ids = [(6, 0, list(set(attachment_ids) - set(message_attachment_ids)))]
            */
            return default;
        }

        public async Task<TEntity> ComputeAuthorizedTransactionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_authorized_transaction_ids(self):
            // for trans in self:
            //     trans.authorized_transaction_ids = trans.transaction_ids.filtered(lambda t: t.state == 'authorized')
            */
            return default;
        }

        public async Task<TEntity> ComputeAutoPostUntilInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeAvailablePaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_available_payment_method_ids(self):
            // """
            // Compute the available payment methods id by respecting the following rules:
            //     Methods of mode 'unique' cannot be used twice on the same company.
            //     Methods of mode 'electronic' cannot be used twice on the same company for the same 'payment_provider_id'.
            //     Methods of mode 'multi' can be duplicated on the same journal.
            // """
            // results = self._get_journals_payment_method_information()
            // pay_methods = results['pay_methods']
            // manage_providers = results['manage_providers']
            // method_information_mapping = results['method_information_mapping']
            // providers_per_code = results['providers_per_code']
            // 
            // journal_bank_cash = self.filtered(lambda j: j.type in ('bank', 'cash', 'credit'))
            // journal_other = self - journal_bank_cash
            // journal_other.available_payment_method_ids = False
            // 
            // # Compute the candidates for each bank/cash journal.
            // for journal in journal_bank_cash:
            //     commands = [Command.clear()]
            //     company = journal.company_id
            // 
            //     # Exclude the 'unique' / 'electronic' values that are already set on the journal.
            //     protected_provider_ids = set()
            //     protected_payment_method_ids = set()
            //     for payment_type in ('inbound', 'outbound'):
            //         lines = journal[f'{payment_type}_payment_method_line_ids']
            //         for line in lines:
            //             if line.payment_method_id.id in method_information_mapping:
            //                 protected_payment_method_ids.add(line.payment_method_id.id)
            //                 if manage_providers and method_information_mapping.get(line.payment_method_id.id, {}).get('mode') == 'electronic':
            //                     protected_provider_ids.add(line.payment_provider_id.id)
            // 
            //     for pay_method in pay_methods:
            //         # Check the partial domain of the payment method to make sure the type matches the current journal
            //         if not journal._is_payment_method_available(pay_method.code, complete_domain=False):
            //             continue
            // 
            //         values = method_information_mapping[pay_method.id]
            // 
            //         if values['mode'] == 'unique':
            //             # 'unique' are linked to a single journal per company.
            //             already_linked_journal_ids = set(values['company_journals'].get(company.id, [])) - {journal._origin.id}
            //             if not already_linked_journal_ids and pay_method.id not in protected_payment_method_ids:
            //                 commands.append(Command.link(pay_method.id))
            //         elif manage_providers and values['mode'] == 'electronic':
            //             # 'electronic' are linked to a single journal per company per provider.
            //             for provider_id in providers_per_code.get(company.id, {}).get(pay_method.code, set()):
            //                 already_linked_journal_ids = set(values['company_journals'].get(company.id, {}).get(provider_id, [])) - {journal._origin.id}
            //                 if not already_linked_journal_ids and provider_id not in protected_provider_ids:
            //                     commands.append(Command.link(pay_method.id))
            //         elif values['mode'] == 'multi':
            //             # 'multi' are unlimited.
            //             commands.append(Command.link(pay_method.id))
            // 
            //     journal.available_payment_method_ids = commands
            */
            return default;
        }

        public async Task<TEntity> ComputeBankPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeClosedTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_closed_task_count(self):
            // self.__compute_task_count(
            //     count_field='closed_task_count',
            //     additional_domain=[('state', 'in', [*CLOSED_STATES])],
            // )
            */
            return default;
        }

        public async Task<TEntity> ComputeCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_code(self):
            // cache = defaultdict(list)
            // for record in self:
            //     if not record.code and record.type in ('bank', 'cash', 'credit'):
            //         record.code = self.get_next_bank_cash_default_code(
            //             record.type,
            //             record.company_id,
            //             cache.get(record.company_id)
            //         )
            //         cache[record.company_id].append(record.code)
            */
            return default;
        }

        public async Task<TEntity> ComputeCollaboratorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_collaborator_count(self):
            // project_sharings = self.filtered(lambda project: project.privacy_visibility == 'portal')
            // collaborator_read_group = self.env['project.collaborator']._read_group(
            //     [('project_id', 'in', project_sharings.ids)],
            //     ['project_id'],
            //     ['__count'],
            // )
            // collaborator_count_by_project = {project.id: count for project, count in collaborator_read_group}
            // for project in self:
            //     project.collaborator_count = collaborator_count_by_project.get(project.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_commercial_partner_id(self):
            // for move in self:
            //     move.commercial_partner_id = move.partner_id.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_company_id(self):
            // for move in self:
            //     if move.journal_id.company_id not in move.company_id.parent_ids:
            //         move.company_id = (move.journal_id.company_id or self.env.company)._accessible_branches()[:1]
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_company_id(self):
            // for project in self:
            //     # if a new restriction is put on the account or the customer, the restriction on the project is updated.
            //     if project.account_id.company_id:
            //         project.company_id = project.account_id.company_id
            //     if not project.company_id and project.partner_id.company_id:
            //         project.company_id = project.partner_id.company_id
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_company_id(self):
            // for task in self:
            //     if not task.parent_id and not task.project_id:
            //         continue
            //     task.company_id = task.project_id.company_id or task.parent_id.company_id
            */
            return default;
        }

        public async Task<TEntity> ComputeContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_currency_id(self):
            // default_currency_id = self.env.company.currency_id
            // for project in self:
            //     project.currency_id = project.company_id.currency_id or default_currency_id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_currency_id(self):
            // for order in self:
            //     order.currency_id = order.pricelist_id.currency_id or order.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_currency_rate(self):
            // for order in self:
            //     order.currency_rate = self.env['res.currency']._get_conversion_rate(order.company_id.currency_id, order.currency_id, order.company_id, order.date_order.date())
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_currency_rate(self):
            // for order in self:
            //     order.currency_rate = self.env['res.currency']._get_conversion_rate(
            //         from_currency=order.company_id.currency_id,
            //         to_currency=order.currency_id,
            //         company=order.company_id,
            //         date=(order.date_order or fields.Datetime.now()).date(),
            //     )
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

        public async Task<TEntity> ComputeCurrentUserSameCompanyPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_current_user_same_company_partner(self):
            // commercial_partner_id = self.env.user.partner_id.commercial_partner_id
            // for task in self:
            //     task.current_user_same_company_partner = task.partner_id and commercial_partner_id == task.partner_id.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeDateCalendarStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_date_calendar_start(self):
            // for order in self:
            //     order.date_calendar_start = order.date_approve if (order.state in ['purchase', 'done']) else order.date_order
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_date_planned(self):
            // """ date_planned = the earliest date_planned across all order lines. """
            // for order in self:
            //     dates_list = order.order_line.filtered(lambda x: not x.display_type and x.date_planned).mapped('date_planned')
            //     if dates_list:
            //         order.date_planned = min(dates_list)
            //     else:
            //         order.date_planned = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultAccountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_default_account_type(self):
            // default_account_id_types = {
            //     'bank': 'asset_cash',
            //     'cash': 'asset_cash',
            //     'sale': 'income%',
            //     'purchase': 'expense%',
            //     'credit': 'liability_credit_card',
            // }
            // 
            // for journal in self:
            //     journal.default_account_type = default_account_id_types.get(journal.type, '%')
            */
            return default;
        }

        public async Task<TEntity> ComputeDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_delivery_date(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeDependOnCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_depend_on_count(self):
            // tasks_with_dependency = self.filtered('allow_task_dependencies')
            // tasks_without_dependency = self - tasks_with_dependency
            // tasks_without_dependency.depend_on_count = 0
            // tasks_without_dependency.closed_depend_on_count = 0
            // if not any(self._ids):
            //     for task in self:
            //         task.depend_on_count = len(task.depend_on_ids)
            //         task.closed_depend_on_count = len(task.depend_on_ids.filtered(lambda r: r.state in CLOSED_STATES))
            //     return
            // if tasks_with_dependency:
            //     # need the sudo for project sharing
            //     total_and_closed_depend_on_count = {
            //         dependent_on.id: (count, sum(s in CLOSED_STATES for s in states))
            //         for dependent_on, states, count in self.env['project.task']._read_group(
            //             [('dependent_ids', 'in', tasks_with_dependency.ids)],
            //             ['dependent_ids'],
            //             ['state:array_agg', '__count'],
            //         )
            //     }
            //     for task in tasks_with_dependency:
            //         task.depend_on_count, task.closed_depend_on_count = total_and_closed_depend_on_count.get(task._origin.id or task.id, (0, 0))
            */
            return default;
        }

        public async Task<TEntity> ComputeDependentTasksCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_dependent_tasks_count(self):
            // tasks_with_dependency = self.filtered('allow_task_dependencies')
            // (self - tasks_with_dependency).dependent_tasks_count = 0
            // if tasks_with_dependency:
            //     group_dependent = self.env['project.task']._read_group([
            //         ('depend_on_ids', 'in', tasks_with_dependency.ids),
            //         ('is_closed', '=', False),
            //     ], ['depend_on_ids'], ['__count'])
            //     dependent_tasks_count_dict = {
            //         depend_on.id: count
            //         for depend_on, count in group_dependent
            //     }
            //     for task in tasks_with_dependency:
            //         task.dependent_tasks_count = dependent_tasks_count_dict.get(task.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeDirectionSignInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeDisplayAliasFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_display_alias_fields(self):
            // self.display_alias_fields = self.env['mail.alias.domain'].search_count([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayFollowButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_display_follow_button(self):
            // if not self.env.user.share:
            //     self.display_follow_button = False
            //     return
            // project_collaborator_read_group = self.env['project.collaborator']._read_group(
            //     [('project_id', 'in', self.project_id.ids), ('partner_id', '=', self.env.user.partner_id.id)],
            //     ['project_id'],
            //     ['limited_access:bool_and'],
            // )
            // limited_access_per_project_id = dict(project_collaborator_read_group)
            // for task in self:
            //     task.display_follow_button = not limited_access_per_project_id.get(task.project_id, True)
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_display_in_project(self):
            // self.filtered(
            //     lambda t: not t.display_in_project and (
            //         not t.project_id or t.project_id != t.parent_id.project_id
            //     )
            // ).display_in_project = True
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInactiveCurrencyWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_inactive_currency_warning(self):
            // for move in self.with_context(active_test=False):
            //     move.display_inactive_currency_warning = move.state == 'draft' and move.currency_id and not move.currency_id.active
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_display_name(self):
            // for journal in self:
            //     name = journal.name
            //     if journal.currency_id and journal.currency_id != journal.company_id.sudo().currency_id:
            //         name = f"{name} ({journal.currency_id.name})"
            //     journal.display_name = name
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_name(self):
            // for move in self:
            //     move.display_name = move._get_move_display_name(show_ref=True)
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_display_name(self):
            // for po in self:
            //     name = po.name
            //     if po.partner_ref:
            //         name += ' (' + po.partner_ref + ')'
            //     if self.env.context.get('show_total_amount') and po.amount_total:
            //         name += ': ' + formatLang(self.env, po.amount_total, currency_obj=po.currency_id)
            //     po.display_name = name
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

        public async Task<TEntity> ComputeDisplayParentTaskButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_display_parent_task_button(self):
            // accessible_parent_tasks = self.parent_id.with_user(self.env.user)._filtered_access('read')
            // for task in self:
            //     task.display_parent_task_button = task.parent_id in accessible_parent_tasks
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeDuplicatedOrderIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeDuplicatedRefIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeElapsedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_elapsed(self):
            // task_linked_to_calendar = self.filtered(
            //     lambda task: task.project_id.resource_calendar_id and task.create_date
            // )
            // for task in task_linked_to_calendar:
            //     dt_create_date = fields.Datetime.from_string(task.create_date)
            // 
            //     if task.date_assign:
            //         dt_date_assign = fields.Datetime.from_string(task.date_assign)
            //         duration_data = task.project_id.resource_calendar_id.get_work_duration_data(dt_create_date, dt_date_assign, compute_leaves=True)
            //         task.working_hours_open = duration_data['hours']
            //         task.working_days_open = duration_data['days']
            //     else:
            //         task.working_hours_open = 0.0
            //         task.working_days_open = 0.0
            // 
            //     if task.date_end:
            //         dt_date_end = fields.Datetime.from_string(task.date_end)
            //         duration_data = task.project_id.resource_calendar_id.get_work_duration_data(dt_create_date, dt_date_end, compute_leaves=True)
            //         task.working_hours_close = duration_data['hours']
            //         task.working_days_close = duration_data['days']
            //     else:
            //         task.working_hours_close = 0.0
            //         task.working_days_close = 0.0
            // 
            // (self - task_linked_to_calendar).update(dict.fromkeys(
            //     ['working_hours_open', 'working_hours_close', 'working_days_open', 'working_days_close'], 0.0))
            */
            return default;
        }

        public async Task<TEntity> ComputeExpectedCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_fiscal_position_id(self):
            // for move in self:
            //     delivery_partner = self.env['res.partner'].browse(
            //         move.partner_shipping_id.id
            //         or move.partner_id.address_get(['delivery'])['delivery']
            //     )
            //     move.fiscal_position_id = self.env['account.fiscal.position'].with_company(move.company_id)._get_fiscal_position(
            //         move.partner_id, delivery=delivery_partner)
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

        public async Task<TEntity> ComputeHasActivePricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeHasArchivedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_has_late_and_unreached_milestone(self):
            // if all(not task.allow_milestones for task in self):
            //     self.has_late_and_unreached_milestone = False
            //     return
            // late_milestones = self.env['project.milestone'].sudo()._search([  # sudo is needed for the portal user in Project Sharing.
            //     ('id', 'in', self.milestone_id.ids),
            //     ('is_reached', '=', False),
            //     ('deadline', '<=', fields.Date.today()),
            // ])
            // for task in self:
            //     task.has_late_and_unreached_milestone = task.allow_milestones and task.milestone_id.id in late_milestones
            */
            return default;
        }

        public async Task<TEntity> ComputeHasReconciledEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_has_reconciled_entries(self):
            // for move in self:
            //     move.has_reconciled_entries = len(move.line_ids._reconciled_lines()) > 1
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRefundableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeHidePostButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeHighestNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_highest_name(self):
            // for record in self:
            //     record.highest_name = record._get_last_sequence()
            */
            return default;
        }

        public async Task<TEntity> ComputeInboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_inbound_payment_method_line_ids(self):
            // for journal in self:
            //     pay_method_line_ids_commands = [Command.clear()]
            //     if journal.type in ('bank', 'cash', 'credit'):
            //         default_methods = journal._default_inbound_payment_methods()
            //         pay_method_line_ids_commands += [Command.create({
            //             'name': pay_method.name,
            //             'payment_method_id': pay_method.id,
            //         }) for pay_method in default_methods]
            //     journal.inbound_payment_method_line_ids = pay_method_line_ids_commands
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_incoterm_location(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeInvoiceDateDueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeInvoiceDefaultSalePersonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_invoice(self):
            // for order in self:
            //     invoices = order.mapped('order_line.invoice_lines.move_id')
            //     order.invoice_ids = invoices
            //     order.invoice_count = len(invoices)
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePartnerDisplayInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeInvoiceStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeIsBeingSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_being_sent(self):
            // for move in self:
            //     move.is_being_sent = bool(move.sending_data)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_is_closed(self):
            // for task in self:
            //     task.is_closed = task.state in CLOSED_STATES
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_is_edited(self):
            // for order in self:
            //     order.is_edited = any(order.lines.mapped('is_edited')) or order.has_deleted_line
            */
            return default;
        }

        public async Task<TEntity> ComputeIsExpiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_is_favorite(self):
            // for project in self:
            //     project.is_favorite = self.env.user in project.favorite_user_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_is_invoiced(self):
            // for order in self:
            //     order.is_invoiced = bool(order.account_move)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_is_milestone_exceeded(self):
            // today = fields.Date.context_today(self)
            // read_group = self.env['project.milestone']._read_group([
            //     ('project_id', 'in', self.filtered('allow_milestones').ids),
            //     ('is_reached', '=', False),
            //     ('deadline', '<=', today)], ['project_id'], ['__count'])
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.is_milestone_exceeded = bool(mapped_count.get(project.id, 0))
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_storno(self):
            // for move in self:
            //     move.is_storno = move.is_storno or (move.move_type in ('out_refund', 'in_refund') and move.company_id.account_storno)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTotalCostComputedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_is_total_cost_computed(self):
            // for order in self:
            //     order.is_total_cost_computed = not False in order.lines.mapped('is_total_cost_computed')
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_journal_id(self):
            // for move in self.filtered(lambda r: r.journal_id.type not in r._get_valid_journal_types()):
            //     move.journal_id = move._search_default_journal()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_journal_id(self):
            // self.journal_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_color(self):
            // for project in self:
            //     project.last_update_color = STATUS_COLOR[project.last_update_status]
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_status(self):
            // for project in self:
            //     project.last_update_status = project.last_update_id.status or 'to_define'
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkPreviewNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_link_preview_name(self):
            // for task in self:
            //     link_preview_name = task.display_name
            //     if task.project_id:
            //         link_preview_name += f' | {task.project_id.sudo().name}'
            //     task.link_preview_name = link_preview_name
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkedAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment_field, object binary_field) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeMarginInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeMilestoneCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_milestone_count(self):
            // read_group = self.env['project.milestone']._read_group([('project_id', 'in', self.ids)], ['project_id'], ['__count'])
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.milestone_count = mapped_count.get(project.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_milestone_id(self):
            // for task in self:
            //     if task.project_id != task.milestone_id.project_id:
            //         task.milestone_id = task.parent_id.project_id == task.project_id and task.parent_id.milestone_id
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneReachedCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_milestone_reached_count(self):
            // read_group = self.env['project.milestone']._read_group(
            //     [('project_id', 'in', self.ids), ('is_reached', '=', True)],
            //     ['project_id'],
            //     ['__count'],
            // )
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.milestone_count_reached = mapped_count.get(project.id, 0)
            //     project.milestone_progress = project.milestone_count and project.milestone_count_reached * 100 // project.milestone_count
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveSentValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def compute_move_sent_values(self):
            // for move in self:
            //     move.move_sent_values = 'sent' if move.is_move_sent else 'not_sent'
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ComputeNamePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeNarrationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeNeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_need_cancel_request(self):
            // for move in self:
            //     move.need_cancel_request = move._need_cancel_request()
            */
            return default;
        }

        public async Task<TEntity> ComputeNeededTermsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ComputeNextMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_next_milestone_id(self):
            // milestone_ids_per_project_id = {
            //     project.id: milestone_ids
            //     for project, milestone_ids in self.env['project.milestone']._read_group(
            //         [('project_id', 'in', self.ids), ('is_reached', '=', False)],
            //         ['project_id'],
            //         ['id:recordset'],
            //     )
            // }
            // for project in self:
            //     milestone = milestone_ids_per_project_id.get(project.id, self.env['project.milestone'])[:1]
            //     project.next_milestone_id = milestone
            //     project.can_mark_milestone_as_done = milestone.can_be_marked_as_done
            //     project.is_milestone_deadline_exceeded = milestone.is_deadline_exceeded
            */
            return default;
        }

        public async Task<TEntity> ComputeNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_next_payment_date(self):
            // for move in self:
            //     move.next_payment_date = min([line.payment_date for line in move.line_ids.filtered(lambda l: l.payment_date and not l.reconciled)], default=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeOpenTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_open_task_count(self):
            // self.__compute_task_count(
            //     count_field='open_task_count',
            //     additional_domain=[('state', 'in', self.env['project.task'].OPEN_STATES)],
            // )
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeOutboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_outbound_payment_method_line_ids(self):
            // for journal in self:
            //     pay_method_line_ids_commands = [Command.clear()]
            //     if journal.type in ('bank', 'cash', 'credit'):
            //         default_methods = journal._default_outbound_payment_methods()
            //         pay_method_line_ids_commands += [Command.create({
            //             'name': pay_method.name,
            //             'payment_method_id': pay_method.id,
            //         }) for pay_method in default_methods]
            //     journal.outbound_payment_method_line_ids = pay_method_line_ids_commands
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePartnerCreditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_partner_credit(self):
            // for move in self:
            //     move.partner_credit = move.partner_id.commercial_partner_id.credit
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCreditWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_partner_id(self):
            // """ Compute the partner_id when the tasks have no partner_id.
            // 
            //     Use the project partner_id if any, or else the parent task partner_id.
            // """
            // for task in self:
            //     if task.partner_id and not (task.project_id or task.parent_id):
            //         task.partner_id = False
            //         continue
            //     if not task.partner_id:
            //         task.partner_id = self._get_default_partner_id(task.project_id, task.parent_id)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerInvoiceIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_partner_invoice_id(self):
            // for order in self:
            //     order.partner_invoice_id = order.partner_id.address_get(['invoice'])['invoice'] if order.partner_id else False
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShippingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_partner_shipping_id(self):
            // for order in self:
            //     order.partner_shipping_id = order.partner_id.address_get(['delivery'])['delivery'] if order.partner_id else False
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_count(self):
            // for invoice in self:
            //     invoice.payment_count = len(invoice.matched_payment_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePaymentSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_payment_sequence(self):
            // for journal in self:
            //     journal.payment_sequence = journal.type in ('bank', 'cash', 'credit')
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePaymentsWidgetReconciledInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetToReconcileInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_personal_stage_id(self):
            // # An user may only access his own 'personal stage' and there can only be one pair (user, task_id)
            // personal_stages = self.env['project.task.stage.personal'].search([('user_id', '=', self.env.uid), ('task_id', 'in', self.ids)])
            // self.personal_stage_id = False
            // for personal_stage in personal_stages:
            //     personal_stage.task_id.personal_stage_id = personal_stage
            */
            return default;
        }

        public async Task<TEntity> ComputePersonalStageTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_personal_stage_type_id(self):
            // for task in self:
            //     task.personal_stage_type_id = task.personal_stage_id.stage_id
            */
            return default;
        }

        public async Task<TEntity> ComputePickingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_picking_count(self):
            // for order in self:
            //     order.picking_count = len(order.picking_ids)
            //     order.failed_pickings = bool(order.picking_ids.filtered(lambda p: p.state != 'done'))
            */
            return default;
        }

        public async Task<TEntity> ComputePortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_portal_user_names(self):
            // """ This compute method allows to see all the names of assigned users to each task contained in `self`.
            // 
            //     When we are in the project sharing feature, the `user_ids` contains only the users if we are a portal user.
            //     That is, only the users in the same company of the current user.
            //     So this compute method is a related of `user_ids.name` but with more records that the portal user
            //     can normally see.
            //     (In other words, this compute is only used in project sharing views to see all assignees for each task)
            // """
            // if self._origin:
            //     # fetch 'user_ids' in superuser mode (and override value in cache
            //     # browse is useful to avoid miscache because of the newIds contained in self
            //     self.invalidate_recordset(fnames=['user_ids'])
            //     self._origin.fetch(['user_ids'])
            // for task in self.with_context(prefetch_fields=False):
            //     task.portal_user_names = format_list(self.env, task.user_ids.mapped('name'))
            */
            return default;
        }

        public async Task<TEntity> ComputePreferredPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_prepayment_percent(self):
            // for order in self:
            //     order.prepayment_percent = order.company_id.prepayment_percent
            */
            return default;
        }

        public async Task<TEntity> ComputePricelistIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputePrivacyVisibilityWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_privacy_visibility_warning(self):
            // for project in self:
            //     if not project.ids:
            //         project.privacy_visibility_warning = ''
            //     elif project.privacy_visibility == 'portal' and project._origin.privacy_visibility != 'portal':
            //         project.privacy_visibility_warning = _('Customers will be added to the followers of their project and tasks.')
            //     elif project.privacy_visibility != 'portal' and project._origin.privacy_visibility == 'portal':
            //         project.privacy_visibility_warning = _('Portal users will be removed from the followers of the project and its tasks.')
            //     else:
            //         project.privacy_visibility_warning = ''
            */
            return default;
        }

        public async Task<TEntity> ComputeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_project_id(self):
            // self.env.remove_to_compute(self._fields['display_in_project'], self)
            // for task in self:
            //     if not task.display_in_project and task.parent_id and task.parent_id.project_id != task.project_id:
            //         task.project_id = task.parent_id.project_id
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEditModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeQuickEncodingValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_quick_encoding_vals(self):
            // for move in self:
            //     move.quick_encoding_vals = move._get_quick_edit_suggestions()
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingRequestDeadlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_rating_request_deadline(self):
            // periods = {'daily': 1, 'weekly': 7, 'bimonthly': 15, 'monthly': 30, 'quarterly': 90, 'yearly': 365}
            // for project in self:
            //     project.rating_request_deadline = fields.datetime.now() + timedelta(days=periods.get(project.rating_status_period, 0))
            */
            return default;
        }

        public async Task<TEntity> ComputeReceiptReminderEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_receipt_reminder_email(self):
            // for order in self:
            //     order.receipt_reminder_email = order.partner_id.with_company(order.company_id).receipt_reminder_email
            //     order.reminder_date_before_receipt = order.partner_id.with_company(order.company_id).reminder_date_before_receipt
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_recurring_count(self):
            // self.recurring_count = 0
            // recurring_tasks = self.filtered(lambda l: l.recurrence_id)
            // count = self.env['project.task']._read_group([('recurrence_id', 'in', recurring_tasks.recurrence_id.ids)], ['recurrence_id'], ['__count'])
            // tasks_count = {recurrence.id: count for recurrence, count in count}
            // for task in recurring_tasks:
            //     task.recurring_count = tasks_count.get(task.recurrence_id.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundRelatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeRefundSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_refund_sequence(self):
            // for journal in self:
            //     journal.refund_sequence = journal.type in ('sale', 'purchase')
            */
            return default;
        }

        public async Task<TEntity> ComputeRepeatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_repeat(self):
            // rec_fields = self._get_recurrence_fields()
            // defaults = self.default_get(rec_fields)
            // for task in self:
            //     for f in rec_fields:
            //         if task.recurrence_id:
            //             task[f] = task.recurrence_id.sudo()[f]
            //         else:
            //             if task.recurring_task:
            //                 task[f] = defaults.get(f)
            //             else:
            //                 task[f] = False
            */
            return default;
        }

        public async Task<TEntity> ComputeRequirePaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_require_payment(self):
            // for order in self:
            //     order.require_payment = order.company_id.portal_confirmation_pay
            */
            return default;
        }

        public async Task<TEntity> ComputeRequireSignatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_require_signature(self):
            // for order in self:
            //     order.require_signature = order.company_id.portal_confirmation_sign
            */
            return default;
        }

        public async Task<TEntity> ComputeResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_resource_calendar_id(self):
            // for project in self:
            //     project.resource_calendar_id = project.company_id.resource_calendar_id or self.env.company.resource_calendar_id
            */
            return default;
        }

        public async Task<TEntity> ComputeSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_secured(self):
            // for move in self:
            //     move.secured = bool(move.inalterable_hash)
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectedPaymentMethodCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_selected_payment_method_codes(self):
            // """
            // Set the selected payment method as a list of comma separated codes like: ,manual,check_printing,...
            // These will be then used to display or not payment method specific fields in the view.
            // """
            // for journal in self:
            //     codes = [line.code for line in journal.inbound_payment_method_line_ids + journal.outbound_payment_method_line_ids if line.code]
            //     journal.selected_payment_method_codes = ',' + ','.join(codes) + ','
            */
            return default;
        }

        public async Task<TEntity> ComputeShowDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_delivery_date(self):
            // for move in self:
            //     move.show_delivery_date = move.delivery_date and move.is_sale_document()
            */
            return default;
        }

        public async Task<TEntity> ComputeShowDisplayInProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_show_display_in_project(self):
            // for task in self:
            //     task.show_display_in_project = bool(task.parent_id) and task.project_id == task.parent_id.sudo().project_id
            */
            return default;
        }

        public async Task<TEntity> ComputeShowPaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeShowResetToDraftButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_stage_id(self):
            // for task in self:
            //     project = task.project_id or task.parent_id.project_id
            //     if project:
            //         if project not in task.stage_id.project_ids:
            //             task.stage_id = task.stage_find(project.id, [('fold', '=', False)])
            //     else:
            //         task.stage_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_state(self):
            // for task in self:
            //     dependent_open_tasks = []
            //     if task.allow_task_dependencies:
            //         dependent_open_tasks = [dependent_task for dependent_task in task.depend_on_ids if dependent_task.state not in CLOSED_STATES]
            //     # if one of the blocking task is in a blocking state
            //     if dependent_open_tasks:
            //         # here we check that the blocked task is not already in a closed state (if the task is already done we don't put it in waiting state)
            //         if task.state not in CLOSED_STATES:
            //             task.state = '04_waiting_normal'
            //     # if the task as no blocking dependencies and is in waiting_normal, the task goes back to in progress
            //     elif task.state not in CLOSED_STATES:
            //         task.state = '01_in_progress'
            */
            return default;
        }

        public async Task<TEntity> ComputeStatusInPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_status_in_payment(self):
            // for move in self:
            //     move.status_in_payment = move.state if move.state in ('draft', 'cancel') else move.payment_state
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskAllocatedHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_allocated_hours(self):
            // for task in self:
            //     task.subtask_allocated_hours = sum(task.child_ids.mapped('allocated_hours'))
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_completion_percentage(self):
            // for task in self:
            //     task.subtask_completion_percentage = task.subtask_count and task.closed_subtask_count / task.subtask_count
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _compute_subtask_count(self):
            // if not any(self._ids):
            //     for task in self:
            //         task.subtask_count, task.closed_subtask_count = len(task.child_ids), len(task.child_ids.filtered(lambda r: r.state in CLOSED_STATES))
            //     return
            // total_and_closed_subtask_count_per_parent_id = {
            //     parent.id: (count, sum(s in CLOSED_STATES for s in states))
            //     for parent, states, count in self.env['project.task']._read_group(
            //         [('parent_id', 'in', self.ids)],
            //         ['parent_id'],
            //         ['state:array_agg', '__count'],
            //     )
            // }
            // for task in self:
            //     task.subtask_count, task.closed_subtask_count = total_and_closed_subtask_count_per_parent_id.get(task.id, (0, 0))
            */
            return default;
        }

        public async Task<TEntity> ComputeSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeSuspenseAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _compute_suspense_account_id(self):
            // for journal in self:
            //     if journal.type not in ('bank', 'cash', 'credit'):
            //         journal.suspense_account_id = False
            //     elif journal.suspense_account_id:
            //         journal.suspense_account_id = journal.suspense_account_id
            //     elif journal.company_id.account_journal_suspense_account_id:
            //         journal.suspense_account_id = journal.company_id.account_journal_suspense_account_id
            //     else:
            //         journal.suspense_account_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_completion_percentage(self):
            // for task in self:
            //     task.task_completion_percentage = task.task_count and 1 - task.open_task_count / task.task_count
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_count(self):
            // self.__compute_task_count()
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_country_code(self):
            // for record in self:
            //     record.tax_country_code = record.tax_country_id.code
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_country_id(self):
            // foreign_vat_records = self.filtered(lambda r: r.fiscal_position_id.foreign_vat)
            // for fiscal_position_id, record_group in groupby(foreign_vat_records, key=lambda r: r.fiscal_position_id):
            //     self.env['account.move'].concat(*record_group).tax_country_id = fiscal_position_id.country_id
            // for company_id, record_group in groupby((self-foreign_vat_records), key=lambda r: r.company_id):
            //     self.env['account.move'].concat(*record_group).tax_country_id = company_id.account_fiscal_country_id
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_tax_country_id(self):
            // for record in self:
            //     if record.fiscal_position_id.foreign_vat:
            //         record.tax_country_id = record.fiscal_position_id.country_id
            //     else:
            //         record.tax_country_id = record.company_id.account_fiscal_country_id
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

        public async Task<TEntity> ComputeTaxIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_tax_id(self):
            // """
            // Trigger the recompute of the taxes if the fiscal position is changed on the PO.
            // """
            // self.order_line._compute_tax_id()
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_tax_totals(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     if not order.company_id:
            //         order.tax_totals = False
            //         continue
            //     order_lines = order.order_line.filtered(lambda x: not x.display_type)
            //     base_lines = [line._prepare_base_line_for_taxes_computation() for line in order_lines]
            //     AccountTax._add_tax_details_in_base_lines(base_lines, order.company_id)
            //     AccountTax._round_base_lines_tax_details(base_lines, order.company_id)
            //     order.tax_totals = AccountTax._get_tax_totals_summary(
            //         base_lines=base_lines,
            //         currency=order.currency_id or order.company_id.currency_id,
            //         company=order.company_id,
            //     )
            //     if order.currency_id != order.company_currency_id:
            //         order.tax_totals['amount_total_cc'] = f"({formatLang(self.env, order.amount_total_cc, currency_obj=self.company_currency_id)})"
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

        public async Task<TEntity> ComputeTaxesLegalNotesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
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

        public async Task<TEntity> ComputeTotalCostAtSessionClosingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stock_moves) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeTotalCostInRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeTotalUpdateIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_total_update_ids(self):
            // update_count_per_project = dict(
            //     self.env['project.update']._read_group(
            //         [('project_id', 'in', self.ids)],
            //         ['project_id'],
            //         ['id:count'],
            //     )
            // )
            // for project in self:
            //     project.update_count = update_count_per_project.get(project, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackingNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _compute_tracking_number(self):
            // for record in self:
            //     record.tracking_number = str((record.session_id.id % 10) * 100 + record.sequence_number % 100).zfill(3)
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ComputeValidityDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ConditionalAddToComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object condition) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ConfirmReceptionMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _confirm_reception_mail(self):
            // for order in self:
            //     if order.state in ['purchase', 'done'] and not order.mail_reception_confirmed:
            //         order.mail_reception_confirmed = True
            //         order.message_post(body=_("The order receipt has been acknowledged by %s.", order.partner_id.name))
            //     elif order.state == 'sent' and not order.mail_reception_confirmed:
            //         order.mail_reception_confirmed = True
            //         order.message_post(body=_("The RFQ has been acknowledged by %s.", order.partner_id.name))
            */
            return default;
        }

        public async Task<TEntity> ConfirmReminderMailAsync<TEntity>(IEnumerable<TEntity> entities, object confirmed_date) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def confirm_reminder_mail(self, confirmed_date=False):
            // for order in self:
            //     if order.state in ['purchase', 'done'] and not order.mail_reminder_confirmed:
            //         order.mail_reminder_confirmed = True
            //         date_planned = order.get_localized_date_planned(confirmed_date).date()
            //         order.message_post(body=_("%(vendor)s confirmed the receipt will take place on %(date)s.", vendor=order.partner_id.name, date=date_planned))
            */
            return default;
        }

        public async Task<TEntity> ConfirmationErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ConstrainsAccountControlIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _constrains_account_control_ids(self):
            // self.env['account.move.line'].flush_model(['account_id', 'journal_id', 'display_type'])
            // self.flush_recordset(['account_control_ids'])
            // self._cr.execute("""
            //     SELECT aml.id
            //     FROM account_move_line aml
            //     WHERE aml.journal_id in %s
            //     AND EXISTS (SELECT 1 FROM journal_account_control_rel rel WHERE rel.journal_id = aml.journal_id)
            //     AND NOT EXISTS (SELECT 1 FROM journal_account_control_rel rel WHERE rel.account_id = aml.account_id AND rel.journal_id = aml.journal_id)
            //     AND aml.display_type NOT IN ('line_section', 'line_note')
            // """, [tuple(self.ids)])
            // if self._cr.fetchone():
            //     raise ValidationError(_('Some journal items already exist in this journal but with other accounts than the allowed ones.'))
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def copy(self, default=None):
            // default = dict(default or {})
            // # Since we dont want to copy the milestones if the original project has the feature disabled, we set the milestones to False by default.
            // default['milestone_ids'] = False
            // copy_context = dict(
            //      self.env.context,
            //      mail_auto_subscribe_no_notify=True,
            //      mail_create_nosubscribe=True,
            //  )
            // copy_context.pop("default_stage_id", None)
            // new_projects = super(Project, self.with_context(copy_context)).copy(default=default)
            // if 'milestone_mapping' not in self.env.context:
            //     self = self.with_context(milestone_mapping={})
            // actions_per_project = dict(self.env['ir.embedded.actions']._read_group(
            //     domain=[
            //         ('parent_res_id', 'in', self.ids),
            //         ('parent_res_model', '=', 'project.project'),
            //         ('user_id', '=', False),
            //     ],
            //     groupby=['parent_res_id'],
            //     aggregates=['id:recordset'],
            // ))
            // for old_project, new_project in zip(self, new_projects):
            //     for follower in old_project.message_follower_ids:
            //         new_project.message_subscribe(partner_ids=follower.partner_id.ids, subtype_ids=follower.subtype_ids.ids)
            //     if old_project.allow_milestones:
            //         new_project.milestone_ids = self.milestone_ids.copy().ids
            //     if 'tasks' not in default:
            //         old_project.map_tasks(new_project.id)
            //     if not old_project.active:
            //         new_project.with_context(active_test=False).tasks.active = True
            //     # Copy the shared embedded actions in the new project
            //     shared_embedded_actions = actions_per_project.get(old_project.id)
            //     if shared_embedded_actions:
            //         copy_shared_embedded_actions = shared_embedded_actions.copy({'parent_res_id': new_project.id})
            //         for original_action, copied_action in zip(shared_embedded_actions, copy_shared_embedded_actions):
            //             copied_action.filter_ids = original_action.filter_ids.copy({'embedded_parent_res_id': new_project.id})
            // return new_projects
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def copy(self, default=None):
            // default = default or {}
            // default.update({
            //     'depend_on_ids': False,
            //     'dependent_ids': False,
            // })
            // copied_tasks = super(Task, self.with_context(
            //     mail_auto_subscribe_no_notify=True,
            //     mail_create_nosubscribe=True,
            //     mail_create_nolog=True,
            // )).copy(default=default)
            // 
            // task_mapping, task_dependencies = self._create_task_mapping(copied_tasks)
            // 
            // for original_task_id, (depend_on_ids, dependant_ids) in task_dependencies.items():
            //     # If one of the task_id in the dependencies mapping is also a key of the task_mapping, it means that this task was copied too.
            //     # In this case, we should exchange this id with the id of the corresponding copied task
            //     task_mapping[original_task_id].depend_on_ids = [
            //         task_id if task_id not in task_mapping else task_mapping[task_id].id
            //         for task_id in depend_on_ids
            //     ]
            //     task_mapping[original_task_id].dependent_ids = [
            //         task_id if task_id not in task_mapping else task_mapping[task_id].id
            //         for task_id in dependant_ids
            //     ]
            // 
            // return copied_tasks
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def copy(self, default=None):
            // ctx = dict(self.env.context)
            // ctx.pop('default_product_id', None)
            // self = self.with_context(ctx)
            // new_pos = super().copy(default=default)
            // for line in new_pos.order_line:
            //     if line.product_id:
            //         seller = line.product_id._select_seller(
            //             partner_id=line.partner_id, quantity=line.product_qty,
            //             date=line.order_id.date_order and line.order_id.date_order.date(), uom_id=line.product_uom)
            //         line.date_planned = line._get_date_planned(seller)
            // return new_pos
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default)
            // code_by_company_id = {
            //     company_id: set(self.env['account.journal'].with_context(active_test=False)._read_group(
            //         domain=self.env['account.journal']._check_company_domain(company_id),
            //         aggregates=['code:array_agg'],
            //     )[0][0])
            //     for company_id, _ in groupby(vals_list, lambda v: v['company_id'])
            // }
            // for journal, vals in zip(self, vals_list):
            //     # Find a unique code for the copied journal
            //     all_journal_codes = code_by_company_id[vals['company_id']]
            // 
            //     copy_code = vals['code']
            //     code_prefix = re.sub(r'\d+', '', copy_code).strip()
            //     counter = 1
            //     while counter <= len(all_journal_codes) and copy_code in all_journal_codes:
            //         counter_str = str(counter)
            //         copy_prefix = code_prefix[:journal._fields['code'].size - len(counter_str)]
            //         copy_code = "%s%s" % (copy_prefix, counter_str)
            //         counter += 1
            // 
            //     if counter > len(all_journal_codes):
            //         # Should never happen, but put there just in case.
            //         raise UserError(_("Could not compute any code for the copy automatically. Please create it manually."))
            // 
            //     vals.update(
            //         code=copy_code,
            //         name=_("%s (copy)", journal.name or ''))
            // return vals_list
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
            //         if 'partner_id' not in vals:
            //             vals['partner_id'] = False
            //     user_fiscal_lock_date = move.company_id._get_user_fiscal_lock_date(move.journal_id)
            //     if (default_date or move.date) <= user_fiscal_lock_date:
            //         vals['date'] = user_fiscal_lock_date + timedelta(days=1)
            //     if not move.journal_id.active and 'journal_id' in vals:
            //         del vals['journal_id']
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // if default and 'name' in default:
            //     return vals_list
            // return [dict(vals, name=self.env._("%s (copy)", project.name)) for project, vals in zip(self, vals_list)]
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // not_project_user = not self.env.user.has_group('project.group_project_user')
            // if not_project_user:
            //     vals_list = [{k: v for k, v in vals.items() if k in self.SELF_READABLE_FIELDS} for vals in vals_list]
            // 
            // milestone_mapping = self.env.context.get('milestone_mapping', {})
            // for task, vals in zip(self, vals_list):
            // 
            //     if not default.get('stage_id'):
            //         vals['stage_id'] = task.stage_id.id
            //     if 'active' not in default and not task['active'] and not self.env.context.get('copy_project'):
            //         vals['active'] = True
            //     vals['name'] = task.name if self.env.context.get('copy_project') else _("%s (copy)", task.name)
            //     if task.recurrence_id and not default.get('recurrence_id'):
            //         vals['recurrence_id'] = task.recurrence_id.copy().id
            //     if task.allow_milestones:
            //         vals['milestone_id'] = milestone_mapping.get(vals['milestone_id'], vals['milestone_id'])
            //     if task.child_ids and not default.get('child_ids'):
            //         default = {
            //             'depend_on_ids': False,
            //             'dependent_ids': False,
            //             'parent_id': False,
            //         }
            //         vals['child_ids'] = [Command.create(child_id.copy_data(default)[0]) for child_id in task.child_ids]
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

        public async Task<TEntity> CopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CreateAccountInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_vals_list, object final) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CreateAnalyticAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _create_analytic_account(self):
            // analytic_accounts_values = self._get_values_analytic_account_batch(self._read_format(['name', 'company_id', 'partner_id'], None))
            // analytic_accounts = self.env['account.analytic.account'].create(analytic_accounts_values)
            // for project, analytic_account in zip(self, analytic_accounts):
            //     project.account_id = analytic_account
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     # have to keep track of new journal codes when importing
            //     codes = [vals['code'] for vals in vals_list if 'code' in vals] if 'import_file' in self.env.context else False
            //     self._fill_missing_values(vals, protected_codes=codes)
            // 
            // journals = super(AccountJournal, self.with_context(mail_create_nolog=True)).create(vals_list)
            // 
            // for journal, vals in zip(journals, vals_list):
            //     # Create the bank_account_id if necessary
            //     if journal.type == 'bank' and not journal.bank_account_id and vals.get('bank_acc_number'):
            //         journal.set_bank_account(vals.get('bank_acc_number'), vals.get('bank_id'))
            // 
            // return journals
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
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     session = self.env['pos.session'].browse(vals['session_id'])
            //     vals = self._complete_values_from_session(session, vals)
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def create(self, vals_list):
            // # Prevent double project creation
            // self = self.with_context(mail_create_nosubscribe=True)
            // if any('label_tasks' in vals and not vals['label_tasks'] for vals in vals_list):
            //     task_label = _("Tasks")
            //     for vals in vals_list:
            //         if 'label_tasks' in vals and not vals['label_tasks']:
            //             vals['label_tasks'] = task_label
            // if self.env.user.has_group('project.group_project_stages'):
            //     if 'default_stage_id' in self._context:
            //         stage = self.env['project.project.stage'].browse(self._context['default_stage_id'])
            //         # The project's company_id must be the same as the stage's company_id
            //         if stage.company_id:
            //             for vals in vals_list:
            //                 if vals.get('stage_id'):
            //                     continue
            //                 vals['company_id'] = stage.company_id.id
            //     else:
            //         companies_ids = [vals.get('company_id', False) for vals in vals_list] + [False]
            //         stages = self.env['project.project.stage'].search([('company_id', 'in', companies_ids)])
            //         for vals in vals_list:
            //             if vals.get('stage_id'):
            //                 continue
            //             # Pick the stage with the lowest sequence with no company or project's company
            //             stage_domain = [False] if 'company_id' not in vals else [False, vals.get('company_id')]
            //             stage = stages.filtered(lambda s: s.company_id.id in stage_domain)[:1]
            //             vals['stage_id'] = stage.id
            // 
            // for vals in vals_list:
            //     if vals.pop('is_favorite', False):
            //         vals['favorite_user_ids'] = [self.env.uid]
            // projects = super().create(vals_list)
            // return projects
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def create(self, vals_list):
            // new_context = dict(self.env.context)
            // default_personal_stage = new_context.pop('default_personal_stage_type_ids', False)
            // default_project_id = new_context.get("default_project_id", False)
            // self = self.with_context(new_context)
            // 
            // is_portal_user = self.env.user._is_portal()
            // if is_portal_user:
            //     self.browse().check_access('create')
            // default_stage = dict()
            // for vals in vals_list:
            //     project_id = vals.get('project_id') or default_project_id
            // 
            //     if vals.get('user_ids'):
            //         vals['date_assign'] = fields.Datetime.now()
            //         if not (vals.get('parent_id') or project_id):
            //             user_ids = self._fields['user_ids'].convert_to_cache(vals.get('user_ids', []), self.env['project.task'])
            //             if self.env.user.id not in list(user_ids) + [SUPERUSER_ID]:
            //                 vals['user_ids'] = [Command.set(list(user_ids) + [self.env.user.id])]
            //     if default_personal_stage and 'personal_stage_type_id' not in vals:
            //         vals['personal_stage_type_id'] = default_personal_stage[0]
            //     if not vals.get('name') and vals.get('display_name'):
            //         vals['name'] = vals['display_name']
            //     if is_portal_user:
            //         self._ensure_fields_are_accessible(vals.keys(), operation='write', check_group_user=False)
            // 
            //     if project_id and not "company_id" in vals:
            //         vals["company_id"] = self.env["project.project"].browse(
            //             project_id
            //         ).company_id.id
            //     if not project_id and ("stage_id" in vals or self.env.context.get('default_stage_id')):
            //         vals["stage_id"] = False
            // 
            //     if project_id and "stage_id" not in vals:
            //         # 1) Allows keeping the batch creation of tasks
            //         # 2) Ensure the defaults are correct (and computed once by project),
            //         # by using default get (instead of _get_default_stage_id or _stage_find),
            //         if project_id not in default_stage:
            //             default_stage[project_id] = self.with_context(
            //                 default_project_id=project_id
            //             ).default_get(['stage_id']).get('stage_id')
            //         vals["stage_id"] = default_stage[project_id]
            // 
            //     # Stage change: Update date_end if folded stage and date_last_stage_update
            //     if vals.get('stage_id'):
            //         vals.update(self.update_date_end(vals['stage_id']))
            //         vals['date_last_stage_update'] = fields.Datetime.now()
            //     # recurrence
            //     rec_fields = vals.keys() & self._get_recurrence_fields()
            //     if rec_fields and vals.get('recurring_task') is True:
            //         rec_values = {rec_field: vals[rec_field] for rec_field in rec_fields}
            //         recurrence = self.env['project.task.recurrence'].create(rec_values)
            //         vals['recurrence_id'] = recurrence.id
            // # The sudo is required for a portal user as the record creation
            // # requires the read access on other models, as mail.template
            // # in order to compute the field tracking
            // was_in_sudo = self.env.su
            // if is_portal_user:
            //     vals_list_no_sudo, vals_list = zip(*(self._get_portal_sudo_vals(vals, defaults=True) for vals in vals_list))
            //     self_no_sudo, self = self, self.sudo().with_context(self._get_portal_sudo_context())
            // tasks = super(Task, self.with_context(mail_create_nosubscribe=True)).create(vals_list)
            // if is_portal_user:
            //     for task, vals in zip(tasks.with_env(self_no_sudo.env), vals_list_no_sudo):
            //         task.write(vals)
            // tasks._populate_missing_personal_stages()
            // self._task_message_auto_subscribe_notify({task: task.user_ids - self.env.user for task in tasks})
            // 
            // # in case we were already in sudo, we don't check the rights.
            // if is_portal_user and not was_in_sudo:
            //     # since we use sudo to create tasks, we need to check
            //     # if the portal user could really create the tasks based on the ir rule.
            //     tasks.browse().with_user(self.env.user).check_access('create')
            // current_partner = self.env.user.partner_id
            // 
            // all_partner_emails = []
            // for task in tasks:
            //     all_partner_emails += tools.email_split(task.email_cc)
            // partners = self.env['res.partner'].search([('email', 'in', all_partner_emails)])
            // partner_per_email = {
            //     partner.email: partner
            //     for partner in partners
            //     if not all(u.share for u in partner.user_ids)
            // }
            // if tasks.project_id:
            //     tasks.sudo()._set_stage_on_project_from_task()
            // for task in tasks:
            //     if task.project_id.privacy_visibility == 'portal':
            //         task._portal_ensure_token()
            //     for follower in task.parent_id.message_follower_ids:
            //         task.message_subscribe(follower.partner_id.ids, follower.subtype_ids.ids)
            //     if current_partner not in task.message_partner_ids:
            //         task.message_subscribe(current_partner.ids)
            //     if task.email_cc:
            //         partners_with_internal_user = self.env['res.partner']
            //         for email in tools.email_split(task.email_cc):
            //             new_partner = partner_per_email.get(email)
            //             if new_partner:
            //                 partners_with_internal_user |= new_partner
            //         if not partners_with_internal_user:
            //             continue
            //         task._send_email_notify_to_cc(partners_with_internal_user)
            //         task.message_subscribe(partners_with_internal_user.ids)
            // return tasks
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def create(self, vals_list):
            // orders = self.browse()
            // partner_vals_list = []
            // for vals in vals_list:
            //     company_id = vals.get('company_id', self.default_get(['company_id'])['company_id'])
            //     # Ensures default picking type and currency are taken from the right company.
            //     self_comp = self.with_company(company_id)
            //     if vals.get('name', 'New') == 'New':
            //         seq_date = None
            //         if 'date_order' in vals:
            //             seq_date = fields.Datetime.context_timestamp(self, fields.Datetime.to_datetime(vals['date_order']))
            //         vals['name'] = self_comp.env['ir.sequence'].next_by_code('purchase.order', sequence_date=seq_date) or '/'
            //     vals, partner_vals = self._write_partner_values(vals)
            //     partner_vals_list.append(partner_vals)
            //     orders |= super(PurchaseOrder, self_comp).create(vals)
            // for order, partner_vals in zip(orders, partner_vals_list):
            //     if partner_vals:
            //         order.sudo().write(partner_vals)  # Because the purchase user doesn't have write on `res.partner`
            // return orders
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

        public async Task<TEntity> CreateDefaultAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object journal_type, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _create_default_account(self, company, journal_type, vals):
            // # Don't get the digits on 'chart_template' since the chart template could be a custom one.
            // random_account = self.env['account.account'].with_company(company).search(
            //     self.env['account.account']._check_company_domain(company),
            //     limit=1,
            // )
            // digits = len(random_account.code) if random_account else 6
            // 
            // if journal_type in ('bank', 'credit'):
            //     account_prefix = company.bank_account_code_prefix or ''
            // elif journal_type == 'cash':
            //     account_prefix = company.cash_account_code_prefix or company.bank_account_code_prefix or ''
            // else:
            //     account_prefix = ''
            // 
            // start_code = account_prefix.ljust(digits, '0')
            // default_account_code = self.env['account.account'].with_company(company)._search_new_account_code(start_code)
            // 
            // if journal_type in ('bank', 'cash'):
            //     default_account_vals = self._prepare_liquidity_account_vals(company, default_account_code, vals)
            // elif journal_type == 'credit':
            //     default_account_vals = self._prepare_credit_account_vals(company, default_account_code, vals)
            // else:
            //     default_account_vals = {}
            // 
            // default_account = self.env['account.account'].create(default_account_vals)
            // if default_account:
            //     self.env['ir.model.data']._update_xmlids([
            //         {
            //             'xml_id': f"account.{company.id}_{journal_type}_journal_default_account_{default_account.id}",
            //             'record': default_account,
            //             'noupdate': True,
            //         }
            //     ])
            // return default_account.id
            */
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def create_document_from_attachment(self, attachment_ids):
            // """ Create the invoices from files.
            //  :return: A action redirecting to account.move list/form view.
            // """
            // invoices = self._create_document_from_attachment(attachment_ids)
            // action_vals = {
            //     'name': _('Generated Documents'),
            //     'domain': [('id', 'in', invoices.ids)],
            //     'res_model': 'account.move',
            //     'type': 'ir.actions.act_window',
            //     'context': self._context
            // }
            // if len(invoices) == 1:
            //     action_vals.update({
            //         'views': [[False, "form"]],
            //         'view_mode': 'form',
            //         'res_id': invoices[0].id,
            //     })
            // else:
            //     action_vals.update({
            //         'views': [[False, "list"], [False, "kanban"], [False, "form"]],
            //         'view_mode': 'list, kanban, form',
            //     })
            // return action_vals
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

        public async Task<TEntity> CreateDocumentFromAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _create_document_from_attachment(self, attachment_ids):
            // """ Create the invoices from files."""
            // if not self:
            //     self = self.env['account.journal'].browse(self._context.get("default_journal_id"))
            // move_type = self._context.get("default_move_type", "entry")
            // if not self:
            //     if move_type in self.env['account.move'].get_sale_types(include_receipts=True):
            //         journal_type = "sale"
            //     elif move_type in self.env['account.move'].get_purchase_types(include_receipts=True):
            //         journal_type = "purchase"
            //     else:
            //         raise UserError(_("The journal in which to upload the invoice is not specified. "))
            //     self = self.env['account.journal'].search([
            //         *self.env['account.journal']._check_company_domain(self.env.company),
            //         ('type', '=', journal_type),
            //     ], limit=1)
            // 
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // if not attachments:
            //     raise UserError(_("No attachment was provided"))
            // 
            // if not self:
            //     raise UserError(self.env['account.journal']._build_no_journal_error_msg(self.env.company.display_name, [journal_type]))
            // 
            // # As we are coming from the journal, we assume that each attachments
            // # will create an invoice with a tentative to enhance with EDI / OCR..
            // all_invoices = self.env['account.move']
            // for attachment in attachments:
            //     invoice = self.env['account.move'].with_context(skip_is_manually_modified=True).create({
            //         'journal_id': self.id,
            //         'move_type': move_type,
            //     })
            // 
            //     invoice.with_context(skip_is_manually_modified=True)._extend_with_attachments(attachment, new=True)
            // 
            //     all_invoices |= invoice
            // 
            //     invoice.with_context(
            //         account_predictive_bills_disable_prediction=True,
            //         no_new_invoice=True,
            //     ).message_post(attachment_ids=attachment.ids)
            // 
            //     attachment.write({'res_model': 'account.move', 'res_id': invoice.id})
            //     invoice._autopost_bill()
            // 
            // return all_invoices
            */
            return default;
        }

        public async Task<TEntity> CreateDownpaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _create_downpayments(self, line_vals):
            // self.ensure_one()
            // 
            // # create section
            // if not any(line.display_type and line.is_downpayment for line in self.order_line):
            //     section_line = self.order_line.create(self._prepare_down_payment_section_values())
            // else:
            //     section_line = self.order_line.filtered(lambda line: line.display_type and line.is_downpayment)
            // vals = [
            //     {
            //         **line_val,
            //         'sequence': section_line.sequence + i,
            //     }
            //     for i, line_val in enumerate(line_vals, start=1)
            // ]
            // downpayment_lines = self.env['purchase.order.line'].create(vals)
            // self.order_line = [
            //     Command.link(line_id)
            //     for line_id in downpayment_lines.ids
            // ]  # a simple concatenation would cause all order_line to recompute, we do not want it to happen
            // return downpayment_lines
            */
            return default;
        }

        public async Task<TEntity> CreateInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CreateInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grouped, object final, object date) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CreateMiscReversalMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_moves) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CreateOrderFromAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CreateOrderPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CreatePmChangeLogInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CreateTaskMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _create_task_mapping(self, copied_tasks):
            // """
            // Thanks to the way create and command.create is handled, when a task with 2 children is copied, we have the guarantee that the children of the
            // copied task will have the same index in the child_ids recordset. We can use this behavior to create a mapping containing all the original tasks and their copy.
            // :return:
            //     task_mapping: a dict containing the mapping of the original task ids and their copied task (k: original_task.id, v: new_task)
            //     task_dependencies: a dict containing the ids of the dependencies of the original task when they have one.
            //     (k: original_task_id, v: [original_task.depend_on_ids.ids, original_task.dependent_ids.ids]
            // """
            // task_mapping, task_dependencies = {}, {}
            // for original_task, copied_task in zip(self, copied_tasks):
            //     task_mapping[original_task.id] = copied_task
            //     if original_task.allow_task_dependencies and (original_task.depend_on_ids or original_task.dependent_ids):
            //         task_dependencies[original_task.id] = [original_task.depend_on_ids.ids, original_task.dependent_ids.ids]
            //     if original_task.child_ids:
            //         # If the task has children, we have to call the method create_task_mapping to get their ids and dependencies mapping too.
            //         children_mapping, children_dependencies = original_task.child_ids._create_task_mapping(copied_task.child_ids)
            //         task_mapping.update(children_mapping)
            //         task_dependencies.update(children_dependencies)
            // return task_mapping, task_dependencies
            */
            return default;
        }

        public async Task<TEntity> CreateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _create_update_date_activity(self, updated_dates):
            // note = Markup('<p>%s</p>\n') % _('%s modified receipt dates for the following products:', self.partner_id.name)
            // for line, date in updated_dates:
            //     note += Markup('<p> - %s</p>\n') % _(
            //         '%(product)s from %(original_receipt_date)s to %(new_receipt_date)s',
            //         product=line.product_id.display_name,
            //         original_receipt_date=line.date_planned.date(),
            //         new_receipt_date=date.date()
            //     )
            // activity = self.activity_schedule(
            //     'mail.mail_activity_data_warning',
            //     summary=_("Date Updated"),
            //     user_id=self.user_id.id
            // )
            // # add the note after we post the activity because the note can be soon
            // # changed when updating the date of the next PO line. So instead of
            // # sending a mail with incomplete note, we send one with no note.
            // activity.note = note
            // return activity
            */
            return default;
        }

        public async Task<TEntity> CreateUpsellActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _creation_message(self):
            // self.ensure_one()
            // if self.project_id:
            //     return _('A new task has been created in the "%(project_name)s" project.',
            //              project_name=self.project_id.display_name)
            // return _('A new task has been created and is not part of any project.')
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _creation_subtype(self):
            // # EXTENDS mail mail.thread
            // if self.move_type in ('out_invoice', 'out_receipt'):
            //     return self.env.ref('account.mt_invoice_created')
            // else:
            //     return super()._creation_subtype()
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('project.mt_task_new')
            */
            return default;
        }

        public async Task<TEntity> CronAccountMoveSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object job_count) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> DeclineReceptionMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _decline_reception_mail(self):
            // for order in self:
            //     if order.state in ['purchase', 'done'] and not order.mail_reception_declined:
            //         order.mail_reception_declined = True
            //         order.activity_schedule(
            //             'mail.mail_activity_data_todo',
            //             note=_('The vendor asked to decline this confirmed RfQ, if you agree on that, cancel this PO'))
            //         order.message_post(body=_("The order receipt has been declined by %s.", order.partner_id.name))
            //     elif order.state  == 'sent' and not order.mail_reception_declined:
            //         order.mail_reception_declined = True
            //         order.message_post(body=_("The RFQ has been declined by %s.", order.partner_id.name))
            */
            return default;
        }

        public async Task<TEntity> DefaultCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_company_id(self):
            // if self._context.get('default_project_id'):
            //     return self.env['project.project'].browse(self._context['default_project_id']).company_id
            // return False
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object default_fields) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def default_get(self, default_fields):
            // vals = super(Task, self).default_get(default_fields)
            // 
            // # prevent creating new task in the waiting state
            // if 'state' in default_fields and vals.get('state') == '04_waiting_normal':
            //     vals['state'] = '01_in_progress'
            // 
            // if 'repeat_until' in default_fields:
            //     vals['repeat_until'] = fields.Date.today() + timedelta(days=7)
            // 
            // if 'partner_id' in vals and not vals['partner_id']:
            //     # if the default_partner_id=False or no default_partner_id then we search the partner based on the project and parent
            //     project_id = vals.get('project_id')
            //     parent_id = vals.get('parent_id', self.env.context.get('default_parent_id'))
            //     if project_id or parent_id:
            //         partner_id = self._get_default_partner_id(
            //             project_id and self.env['project.project'].browse(project_id),
            //             parent_id and self.env['project.task'].browse(parent_id)
            //         )
            //         if partner_id:
            //             vals['partner_id'] = partner_id
            // project_id = vals.get('project_id', self.env.context.get('default_project_id'))
            // if project_id:
            //     project = self.env['project.project'].browse(project_id)
            //     if 'company_id' in default_fields and 'default_project_id' not in self.env.context:
            //         vals['company_id'] = project.sudo().company_id.id
            // elif 'default_user_ids' not in self.env.context and 'user_ids' in default_fields:
            //     user_ids = vals.get('user_ids', [])
            //     user_ids.append(Command.link(self.env.user.id))
            //     vals['user_ids'] = user_ids
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> DefaultInboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _default_inbound_payment_methods(self):
            // return self.env.ref('account.account_payment_method_manual_in')
            */
            return default;
        }

        public async Task<TEntity> DefaultInvoiceReferenceModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _default_invoice_reference_model(self):
            // """Get the invoice reference model according to the company's country."""
            // country_code = self.env.company.country_id.code
            // country_code = country_code and country_code.lower()
            // if country_code:
            //     for model in self._fields['invoice_reference_model'].get_values(self.env):
            //         if model.startswith(country_code):
            //             return model
            // return 'odoo'
            */
            return default;
        }

        public async Task<TEntity> DefaultOrderLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self.env['account.move.line']._get_product_catalog_lines_data()
            // return {**default_data, **new_default_data}
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self.env['purchase.order.line']._get_product_catalog_lines_data()
            // return {**default_data, **new_default_data}
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _default_order_line_values(self, child_field=False):
            // default_data = super()._default_order_line_values(child_field)
            // new_default_data = self.env['sale.order.line']._get_product_catalog_lines_data()
            // return {**default_data, **new_default_data}
            */
            return default;
        }

        public async Task<TEntity> DefaultOutboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _default_outbound_payment_methods(self):
            // return self.env.ref('account.account_payment_method_manual_out')
            */
            return default;
        }

        public async Task<TEntity> DefaultPersonalStageTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_personal_stage_type_id(self):
            // default_id = self.env.context.get('default_personal_stage_type_ids')
            // return (default_id or self.env['project.task.type'].search([('user_id', '=', self.env.user.id)], limit=1).ids or [False])[0]
            */
            return default;
        }

        public async Task<TEntity> DefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _default_stage_id(self):
            // # Since project stages are order by sequence first, this should fetch the one with the lowest sequence number.
            // return self.env['project.project.stage'].search([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _default_user_ids(self):
            // return self.env.context.keys() & {'default_personal_stage_type_ids', 'default_personal_stage_type_id'} and self.env.user
            */
            return default;
        }

        public async Task<TEntity> DetachAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> DetermineFieldsToFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names, object ignore_when_in_cache) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _determine_fields_to_fetch(self, field_names, ignore_when_in_cache=False):
            // if not self.env.su and self.env.user._is_portal():
            //     valid_names = self.SELF_READABLE_FIELDS
            //     field_names = [fname for fname in field_names if fname in valid_names]
            // return super()._determine_fields_to_fetch(field_names, ignore_when_in_cache)
            */
            return default;
        }

        public async Task<TEntity> DisableDiscountPrecisionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> DisableRecursionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container, object key, object @default, object target) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> DiscardTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> EmailSplitAsync<TEntity>(IEnumerable<TEntity> entities, object msg) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def email_split(self, msg):
            // email_list = tools.email_split((msg.get('to') or '') + ',' + (msg.get('cc') or ''))
            // # check left-part is not already an alias
            // aliases = self.mapped('project_id.alias_name')
            // return [x for x in email_list if x.split('@')[0] not in aliases]
            */
            return default;
        }

        public async Task<TEntity> EnsureCompanyConsistencyWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_company_consistency_with_partner(self):
            // """ Ensures that the company of the task is valid for the partner. """
            // for task in self:
            //     if task.partner_id and task.partner_id.company_id and task.company_id and task.company_id != task.partner_id.company_id:
            //         raise ValidationError(_('The task and the associated partner must be linked to the same company.'))
            */
            return default;
        }

        public async Task<TEntity> EnsureFieldsAreAccessibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object operation, object check_group_user) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_fields_are_accessible(self, fields, operation='read', check_group_user=True):
            // """" ensure all fields are accessible by the current user
            // 
            //     This method checks if the portal user can access to all fields given in parameter.
            //     By default, it checks if the current user is a portal user and then checks if all fields are accessible for this user.
            // 
            //     :param fields: list of fields to check if the current user can access.
            //     :param operation: contains either 'read' to check readable fields or 'write' to check writable fields.
            //     :param check_group_user: contains boolean value.
            //         - True, if the method has to check if the current user is a portal one.
            //         - False if we are sure the user is a portal user,
            // """
            // assert operation in ('read', 'write'), 'Invalid operation'
            // if fields and (not check_group_user or self.env.user._is_portal()) and not self.env.su:
            //     unauthorized_fields = set(fields) - (self.SELF_READABLE_FIELDS if operation == 'read' else self.SELF_WRITABLE_FIELDS)
            //     if unauthorized_fields:
            //         unauthorized_field_list = format_list(self.env, list(unauthorized_fields))
            //         if operation == 'read':
            //             error_message = _('You cannot read the following fields on tasks: %(field_list)s', field_list=unauthorized_field_list)
            //         else:
            //             error_message = _('You cannot write on the following fields on tasks: %(field_list)s', field_list=unauthorized_field_list)
            //         raise AccessError(error_message)
            */
            return default;
        }

        public async Task<TEntity> EnsurePersonalStagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_personal_stages(self):
            // user = self.env.user
            // ProjectTaskTypeSudo = self.env['project.task.type'].sudo()
            // # In the case no stages have been found, we create the default stages for the user
            // if not ProjectTaskTypeSudo.search_count([('user_id', '=', user.id)], limit=1):
            //     ProjectTaskTypeSudo.with_context(lang=user.lang, default_project_id=False).create(
            //         self.with_context(lang=user.lang)._get_default_personal_stage_create_vals(user.id)
            //     )
            */
            return default;
        }

        public async Task<TEntity> EnsureStageHasSameCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _ensure_stage_has_same_company(self):
            // for project in self:
            //     if project.stage_id.company_id and project.stage_id.company_id != project.company_id:
            //         raise UserError(
            //             _('This project is associated with %(project_company)s, whereas the selected stage belongs to %(stage_company)s. '
            //             'There are a couple of options to consider: either remove the company designation '
            //             'from the project or from the stage. Alternatively, you can update the company '
            //             'information for these records to align them under the same company.', project_company=project.company_id.name, stage_company=project.stage_id.company_id.name)
            //             if project.company_id else
            //             _('This project is not associated with any company, while the stage is associated with %s. '
            //             'There are a couple of options to consider: either change the project\'s company '
            //             'to align with the stage\'s company or remove the company designation from the stage', project.stage_id.company_id.name)
            //         )
            */
            return default;
        }

        public async Task<TEntity> EnsureSuperTaskIsNotPrivateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _ensure_super_task_is_not_private(self):
            // """ Ensures that the company of the task is valid for the partner. """
            // for task in self:
            //     if not task.project_id and task.subtask_count:
            //         raise ValidationError(_('This task has sub-tasks, so it can\'t be private.'))
            */
            return default;
        }

        public async Task<TEntity> EnsureUniqueAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object company) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _ensure_unique_alias(self, vals, company):
            // """ Check uniqueness of the alias name within the given alias domain.
            // :param vals: the values of the journal.
            // :return: a unique alias name.
            // """
            // alias_name = vals['alias_name']
            // alias_domain_name = company.alias_domain_id.name
            // 
            // domain = [('alias_name', '=', alias_name)]
            // if alias_domain_name:
            //     domain.append(('alias_domain', '=', alias_domain_name))
            // 
            // existing_alias = self.env['mail.alias'].search_count(domain, limit=1)
            // 
            // if existing_alias:
            //     alias_name = f"{alias_name}-{vals.get('code')}"
            // 
            // return self.env['mail.alias']._sanitize_alias_name(alias_name)
            */
            return default;
        }

        public async Task<TEntity> ExtendWithAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _extend_with_attachments(self, attachments, new=False):
            // """Main entry point to extend/enhance invoices with attachments.
            // 
            // Either coming from:
            // - The chatter when the user drops an attachment on an existing invoice.
            // - The journal when the user drops one or multiple attachments from the dashboard.
            // - The server mail alias when an alias is configured on the journal.
            // 
            // It will unwrap all attachments by priority then try to decode until it succeed.
            // 
            // :param attachments: A recordset of ir.attachment.
            // :param new:         Indicate if the current invoice is a fresh one or an existing one.
            // :returns:           True if at least one document is successfully imported
            // """
            // def close_file(file_data):
            //     if file_data.get('on_close'):
            //         file_data['on_close']()
            // 
            // def add_file_data_results(file_data, invoice):
            //     passed_file_data_list.append(file_data)
            //     attachment = file_data.get('attachment') or file_data.get('originator_pdf')
            //     if attachment:
            //         if attachments_by_invoice.get(attachment):
            //             attachments_by_invoice[attachment] |= invoice
            //         else:
            //             attachments_by_invoice[attachment] = invoice
            //         if not attachment.res_id:
            //             attachment.write({
            //                 'res_id': invoice.id,
            //                 'res_model': invoice._name,
            //             })
            // 
            // file_data_list = attachments._unwrap_edi_attachments()
            // attachments_by_invoice = {}
            // invoices = self
            // current_invoice = self
            // passed_file_data_list = []
            // for file_data in file_data_list:
            // 
            //     # Rogue binaries from mail alias are skipped and unlinked.
            //     if (
            //         file_data['type'] == 'binary'
            //         and self._context.get('from_alias')
            //         and not attachments_by_invoice.get(file_data['attachment'])
            //         and file_data['attachment'].mimetype not in ALLOWED_MIMETYPES
            //     ):
            //         close_file(file_data)
            //         continue
            // 
            //     # The invoice has already been decoded by an embedded file.
            //     if attachments_by_invoice.get(file_data['attachment']):
            //         add_file_data_results(file_data, attachments_by_invoice[file_data['attachment']])
            //         close_file(file_data)
            //         continue
            // 
            //     # When receiving multiple files, if they have a different type, we supposed they are all linked
            //     # to the same invoice.
            //     if (
            //         passed_file_data_list
            //         and passed_file_data_list[-1]['filename'] != file_data['filename']
            //         and passed_file_data_list[-1]['sort_weight'] != file_data['sort_weight']
            //     ):
            //         add_file_data_results(file_data, invoices[-1])
            //         close_file(file_data)
            //         continue
            // 
            //     if passed_file_data_list and not new:
            //         add_file_data_results(file_data, invoices[-1])
            //         close_file(file_data)
            //         continue
            // 
            //     extend_with_existing_lines = file_data.get('process_if_existing_lines', False)
            //     if current_invoice.invoice_line_ids and not extend_with_existing_lines:
            //         continue
            // 
            //     decoder = (current_invoice or current_invoice.new(self.default_get(['move_type', 'journal_id'])))._get_edi_decoder(file_data, new=new)
            //     current_invoice.flush_recordset()
            //     if decoder or file_data['type'] in ('pdf', 'binary'):
            //         try:
            //             with self.env.cr.savepoint():
            //                 invoice = current_invoice or self.create({})
            //                 existing_lines = invoice.invoice_line_ids
            //                 if not decoder and file_data['type'] in ('pdf', 'binary'):
            //                     success = False
            //                 else:
            //                     success = decoder(invoice, file_data, new)
            // 
            //                 if success or file_data['type'] == 'pdf' or file_data['attachment'].mimetype in ALLOWED_MIMETYPES:
            //                     (invoice.invoice_line_ids - existing_lines).is_imported = True
            //                     if not extend_with_existing_lines:
            //                         invoice._link_bill_origin_to_purchase_orders(timeout=4)
            //                     invoices |= invoice
            //                     current_invoice = self.env['account.move']
            //                     add_file_data_results(file_data, invoice)
            // 
            //         except RedirectWarning:
            //             raise
            //         except Exception as e:
            //             message = _(
            //                 "Error importing attachment '%(file_name)s' as invoice (decoder=%(decoder)s)",
            //                 file_name=file_data['filename'],
            //                 decoder=decoder.__name__,
            //             )
            //             _logger.exception(message)
            //             if isinstance(e, UserError):
            //                 message = Markup("%s<br/><br/>%s<br/>%s") % (
            //                     message,
            //                     _("This specific error occurred during the import:"),
            //                     str(e),
            //                 )
            //             current_invoice.sudo().message_post(body=message)
            // 
            //     passed_file_data_list.append(file_data)
            //     close_file(file_data)
            // 
            // return attachments_by_invoice
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

        public async Task<TEntity> ExtractPriorityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _extract_priority(self):
            // self.priority = "1"
            // priority_group = self._get_group_pattern()['priority']
            // self.display_name, dummy = re.subn(priority_group, '', self.display_name)
            */
            return default;
        }

        public async Task<TEntity> ExtractTagsAndUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _extract_tags_and_users(self):
            // tags = []
            // users = []
            // tags_and_users_group = self._get_group_pattern()['tags_and_users']
            // for word in re.findall(tags_and_users_group % '', self.display_name):
            //     (tags if word.startswith('#') else users).append(word[1:])
            // users_to_keep = []
            // user_ids = []
            // for user in users:
            //     matched_users = self.env['res.users'].name_search(user)
            //     if len(matched_users) == 1:
            //         user_ids.append(Command.link(matched_users[0][0]))
            //     else:
            //         users_to_keep.append(r'%s\b' % user)
            // self.user_ids = user_ids
            // if tags:
            //     domain = expression.OR([[('name', '=ilike', tag)] for tag in tags])
            //     existing_tags = self.env['project.tags'].search(domain)
            //     existing_tags_names = {tag.name.lower() for tag in existing_tags}
            //     new_tags_names = {tag for tag in tags if tag.lower() not in existing_tags_names}
            //     self.tag_ids = [Command.set(existing_tags.ids)] + [Command.create({'name': name}) for name in new_tags_names]
            // pattern = tags_and_users_group % ('(?!%s)' % ('|').join(users_to_keep) if users_to_keep else '')
            // self.display_name, dummy = re.subn(pattern, '', self.display_name)
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> FetchDuplicateReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object matching_states) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> FieldWillChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals, object field_name) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> FieldsGetAsync<TEntity>(IEnumerable<TEntity> entities, object allfields, object attributes) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def fields_get(self, allfields=None, attributes=None):
            // fields = super().fields_get(allfields=allfields, attributes=attributes)
            // if not self.env.user._is_portal():
            //     return fields
            // readable_fields = self.SELF_READABLE_FIELDS
            // public_fields = {field_name: description for field_name, description in fields.items() if field_name in readable_fields}
            // 
            // writable_fields = self.SELF_WRITABLE_FIELDS
            // for field_name, description in public_fields.items():
            //     if field_name not in writable_fields and not description.get('readonly', False):
            //         # If the field is not in Writable fields and it is not readonly then we force the readonly to True
            //         description['readonly'] = True
            // 
            // return public_fields
            */
            return default;
        }

        public async Task<TEntity> FillMissingValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object protected_codes) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _fill_missing_values(self, vals, protected_codes=False):
            // journal_type = vals.get('type')
            // is_import = 'import_file' in self.env.context
            // if is_import and not journal_type:
            //     vals['type'] = journal_type = 'general'
            // 
            // # 'type' field is required.
            // if not journal_type:
            //     return
            // 
            // # === Fill missing company ===
            // company = self.env['res.company'].browse(vals['company_id']) if vals.get('company_id') else self.env.company
            // vals['company_id'] = company.id
            // 
            // if journal_type in ('bank', 'cash'):
            //     has_liquidity_accounts = vals.get('default_account_id')
            //     has_profit_account = vals.get('profit_account_id')
            //     has_loss_account = vals.get('loss_account_id')
            // 
            //     # === Fill missing name ===
            //     vals['name'] = vals.get('name') or vals.get('bank_acc_number')
            // 
            //     # === Fill missing accounts ===
            //     if not has_liquidity_accounts:
            //         vals['default_account_id'] = self._create_default_account(company, journal_type, vals)
            //     if journal_type in ('cash', 'bank') and not has_profit_account:
            //         vals['profit_account_id'] = company.default_cash_difference_income_account_id.id
            //     if journal_type in ('cash', 'bank') and not has_loss_account:
            //         vals['loss_account_id'] = company.default_cash_difference_expense_account_id.id
            // 
            // if journal_type == 'credit':
            //     if not vals.get('default_account_id'):
            //         default_account_id = self.env['account.account'].with_company(company).search([
            //                 *self.env['account.account']._check_company_domain(company),
            //                 ('account_type', '=', 'liability_credit_card'),
            //             ],
            //             limit=1,
            //         ).id
            //         if not default_account_id:
            //             default_account_id = self._create_default_account(company, journal_type, vals)
            //         vals['default_account_id'] = default_account_id
            // 
            // if is_import and not vals.get('code'):
            //     code = vals['name'][:5]
            //     vals['code'] = code if not protected_codes or code not in protected_codes else self.get_next_bank_cash_default_code(journal_type, company, protected_codes)
            //     if not vals['code']:
            //         raise UserError(_("Cannot generate an unused journal code. Please change the name for journal %s.", vals['name']))
            // 
            // # === Fill missing alias name for sale / purchase, to force alias creation ===
            // if journal_type in {'sale', 'purchase'}:
            //     if 'alias_name' not in vals:
            //         vals['alias_name'] = self._alias_prepare_alias_name(
            //         False, vals.get('name'), vals.get('code'), journal_type, company
            //     )
            //     vals['alias_name'] = self._ensure_unique_alias(vals, company)
            */
            return default;
        }

        public async Task<TEntity> FilterProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object documents) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> FindAndSetPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _find_and_set_purchase_orders(self, po_references, partner_id, amount_total, from_ocr=False, timeout=10):
            // # hook to be used with purchase, so that vendor bills are sync/autocompleted with purchase orders
            // self.ensure_one()
            */
            return default;
        }

        public async Task<TEntity> FindMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ForceLinesToInvoicePolicyOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GenerateAndSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_synchronous, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GenerateDownpaymentInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GeneratePosOrderInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GenerateQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object silent_errors) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Instead of the classic form view, redirect to the online document for
            // portal users or if force_website=True. """
            // self.ensure_one()
            // 
            // user, record = self.env.user, self
            // if access_uid:
            //     try:
            //         record.check_access('read')
            //     except exceptions.AccessError:
            //         return super(PortalMixin, self)._get_access_action(
            //             access_uid=access_uid, force_website=force_website
            //         )
            //     user = self.env['res.users'].sudo().browse(access_uid)
            //     record = self.with_user(user)
            // if user.share or force_website:
            //     try:
            //         record.check_access('read')
            //     except exceptions.AccessError:
            //         if force_website:
            //             return {
            //                 'type': 'ir.actions.act_url',
            //                 'url': record.access_url,
            //                 'target': 'self',
            //                 'res_id': record.id,
            //             }
            //         else:
            //             pass
            //     else:
            //         return {
            //             'type': 'ir.actions.act_url',
            //             'url': record._get_share_url(),
            //             'target': 'self',
            //             'res_id': record.id,
            //         }
            // return super(PortalMixin, self)._get_access_action(
            //     access_uid=access_uid, force_website=force_website
            // )
            */
            return default;
        }

        public async Task<TEntity> GetAccountNodeContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_account_node_context(self, plan):
            // return {
            //     **super()._get_account_node_context(plan),
            //     'default_company_id': unquote('company_id'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax, object lock_dates) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetActionAddFromCatalogExtraContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // return {
            //     **super()._get_action_add_from_catalog_extra_context(),
            //     'display_uom': self.env.user.has_group('uom.group_uom'),
            //     'precision': self.env['decimal.precision'].precision_get('Product Unit of Measure'),
            //     'product_catalog_currency_id': self.currency_id.id,
            //     'product_catalog_digits': self.order_line._fields['price_unit'].get_digits(self.env),
            //     'search_default_seller_ids': self.partner_id.name,
            // }
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

        public async Task<TEntity> GetAllReconciledInvoicePartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetAllSubtasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_all_subtasks(self):
            // return self.browse(set.union(set(), *self._get_subtask_ids_per_task_id().values()))
            */
            return default;
        }

        public async Task<TEntity> GetAlreadyIncludedProfitabilityInvoiceLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_already_included_profitability_invoice_line_ids(self):
            // # To be extended to avoid account.move.line overlap between
            // # profitability reports.
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentsSearchDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_attachments_search_domain(self):
            // self.ensure_one()
            // return [('res_id', '=', self.id), ('res_model', '=', 'project.task')]
            */
            return default;
        }

        public async Task<TEntity> GetAutomaticBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetAvailablePaymentMethodLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_available_payment_method_lines(self, payment_type):
            // """
            // This getter is here to allow filtering the payment method lines if needed in other modules.
            // It does NOT serve as a general getter to get the lines.
            // 
            // For example, it'll be extended to filter out lines from inactive payment providers in the payment module.
            // :param payment_type: either inbound or outbound, used to know which lines to return
            // :return: Either the inbound or outbound payment method lines
            // """
            // if not self:
            //     return self.env['account.payment.method.line']
            // self.ensure_one()
            // if payment_type == 'inbound':
            //     return self.inbound_payment_method_line_ids
            // else:
            //     return self.outbound_payment_method_line_ids
            */
            return default;
        }

        public async Task<TEntity> GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_bank_statements_available_sources(self):
            // return self.__get_bank_statements_available_sources()
            */
            return default;
        }

        public async Task<TEntity> GetCannotStartWithPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_cannot_start_with_patterns(self):
            // return [r'(?![#!@\s])']
            */
            return default;
        }

        public async Task<TEntity> GetChainInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetChainsToHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object raise_if_gap, object raise_if_no_document, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetConfirmUrlAsync<TEntity>(IEnumerable<TEntity> entities, object confirm_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_confirm_url(self, confirm_type=None):
            // """Create url for confirm reminder or purchase reception email for sending
            // in mail."""
            // if confirm_type in ['reminder', 'reception', 'decline']:
            //     param = url_encode({
            //         'confirm': confirm_type,
            //         'confirmed_date': self.date_planned and self.date_planned.date(),
            //     })
            //     return self.get_portal_url(query_string='&%s' % param)
            // return self.get_portal_url()
            */
            return default;
        }

        public async Task<TEntity> GetConfirmationTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetCopiableOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_copiable_order_lines(self):
            // """Returns the order lines that can be copied to a new order."""
            // return self.order_line.filtered(lambda l: not l.is_downpayment)
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid to_currency_id, object date) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetDefaultAccountDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_default_account_domain(self):
            // return """[
            //     ('deprecated', '=', False),
            //     ('account_type', 'in', ('asset_cash', 'liability_credit_card') if type == 'bank'
            //                            else ('liability_credit_card',) if type == 'credit'
            //                            else ('asset_cash',) if type == 'cash'
            //                            else ('income', 'income_other') if type == 'sale'
            //                            else ('expense', 'expense_depreciation', 'expense_direct_cost') if type == 'purchase'
            //                            else ('asset_receivable', 'asset_cash', 'asset_current', 'asset_non_current',
            //                                  'asset_prepayments', 'asset_fixed', 'liability_payable',
            //                                  'liability_credit_card', 'liability_current', 'liability_non_current',
            //                                  'equity', 'equity_unaffected', 'income', 'income_other', 'expense',
            //                                  'expense_depreciation', 'expense_direct_cost', 'off_balance'))
            // ]"""
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project, object parent) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_default_partner_id(self, project=None, parent=None):
            // if parent and parent.partner_id:
            //     return parent.partner_id.id
            // if project and project.partner_id:
            //     return project.partner_id.id
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPaymentLinkValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetDefaultPersonalStageCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_default_personal_stage_create_vals(self, user_id):
            // return [
            //     {'sequence': 1, 'name': _('Inbox'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 2, 'name': _('Today'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 3, 'name': _('This Week'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 4, 'name': _('This Month'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 5, 'name': _('Later'), 'user_id': user_id, 'fold': False},
            //     {'sequence': 6, 'name': _('Done'), 'user_id': user_id, 'fold': True},
            //     {'sequence': 7, 'name': _('Cancelled'), 'user_id': user_id, 'fold': True},
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_default_stage_id(self):
            // """ Gives default stage_id """
            // project_id = self.env.context.get('default_project_id')
            // if not project_id:
            //     return False
            // return self.stage_find(project_id, order="fold, sequence, id")
            */
            return default;
        }

        public async Task<TEntity> GetDiscountAllocationAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetEdiBuildersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_edi_builders(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetEdiCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetEdiDecoderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_data, object @new) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_msg) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_empty_list_help(self, help):
            // tname = _("task")
            // project_id = self.env.context.get('default_project_id', False)
            // if project_id:
            //     name = self.env['project.project'].browse(project_id).label_tasks
            //     if name: tname = name.lower()
            // 
            // self = self.with_context(
            //     empty_list_help_id=self.env.context.get('default_project_id'),
            //     empty_list_help_model='project.project',
            //     empty_list_help_document_name=tname,
            // )
            // return super(Task, self).get_empty_list_help(help)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_empty_list_help(self, help_msg):
            // self = self.with_context(
            //     empty_list_help_document_name=_("sale order"),
            // )
            // return super().get_empty_list_help(help_msg)
            */
            return default;
        }

        public async Task<TEntity> GetExtraPrintItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToCopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetFieldsToDetachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetFrequentAccountAndTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetGroupPatternInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_group_pattern(self):
            // return {
            //     'tags_and_users': r'\s([#@]%s[^\s]+)',
            //     'priority': r'\s(!)',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_groups(self):
            // return [
            //     lambda task: task._extract_tags_and_users(),
            //     lambda task: task._extract_priority(),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetGroupsPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_groups_patterns(self):
            // return [
            //     r'(?:%s)*' % ('|').join(self._prepare_pattern_groups()),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetHidePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_hide_partner(self):
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetInboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_inbound_types(self, include_receipts=True):
            // return ['out_invoice', 'in_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetInstallmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetIntegrityHashFieldsAndSubfieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_integrity_hash_fields_and_subfields(self):
            // return self._get_integrity_hash_fields() + [f'line_ids.{subfield}' for subfield in self.line_ids._get_integrity_hash_fields()]
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceComputedReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aml_values_list, object open_balance) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountPerPaymentTermLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceCurrencyRateDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_invoice_currency_rate_date(self):
            // self.ensure_one()
            // return self.invoice_date or fields.Date.context_today(self)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceGroupingKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_invoice_grouping_keys(self):
            // return ['company_id', 'partner_id', 'currency_id']
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceInPaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceLegalDocumentsAllInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allow_fallback) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceLegalDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filetype, object allow_fallback) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLinesValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_values, object pos_order_line) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceNextPaymentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoicePdfProformaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoicePortalExtraValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoicePostContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_invoice_post_context(self):
            // return {"skip_invoice_sync": True}
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceProformaPdfReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceReferenceEuroInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceReferenceEuroPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceReferenceOdooInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceReferenceOdooPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object extension) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoiceTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_invoice_types(self, include_receipts=False):
            // return self.get_sale_types(include_receipts) + self.get_purchase_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object final) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_invoiced(self):
            // precision = self.env['decimal.precision'].precision_get('Product Unit of Measure')
            // for order in self:
            //     if order.state not in ('purchase', 'done'):
            //         order.invoice_status = 'no'
            //         continue
            // 
            //     if any(
            //         not float_is_zero(line.qty_to_invoice, precision_digits=precision)
            //         for line in order.order_line.filtered(lambda l: not l.display_type)
            //     ):
            //         order.invoice_status = 'to invoice'
            //     elif (
            //         all(
            //             float_is_zero(line.qty_to_invoice, precision_digits=precision)
            //             for line in order.order_line.filtered(lambda l: not l.display_type)
            //         )
            //         and order.invoice_ids
            //     ):
            //         order.invoice_status = 'invoiced'
            //     else:
            //         order.invoice_status = 'no'
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

        public async Task<TEntity> GetItemsFromAalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_items_from_aal(self, with_action=True):
            // return {
            //     'revenues': {'data': [], 'total': {'invoiced': 0.0, 'to_invoice': 0.0}},
            //     'costs': {'data': [], 'total': {'billed': 0.0, 'to_bill': 0.0}},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetJournalBankAccountBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_journal_bank_account_balance(self, domain=None):
            // r''' Get the bank balance of the current journal by filtering the journal items using the journal's accounts.
            // 
            // /!\ The current journal is not part of the applied domain. This is the expected behavior since we only want
            // a logic based on accounts.
            // 
            // :param domain:  An additional domain to be applied on the account.move.line model.
            // :return:        Tuple having balance expressed in journal's currency
            //                 along with the total number of move lines having the same account as of the journal's default account.
            // '''
            // self.ensure_one()
            // nb_lines, balance, amount_currency = self.env['account.move.line']._read_group(
            //     domain=([
            //         ('account_id', 'in', tuple(self.default_account_id.ids)),
            //         ('display_type', 'not in', ('line_section', 'line_note')),
            //         ('parent_state', '!=', 'cancel'),
            //     ] + (domain or [])),
            //     aggregates=('__count', 'balance:sum', 'amount_currency:sum'),
            // )[0]
            // 
            // company_currency = self.company_id.currency_id
            // journal_currency = self.currency_id if self.currency_id and self.currency_id != company_currency else False
            // return amount_currency if journal_currency else balance, nb_lines
            */
            return default;
        }

        public async Task<TEntity> GetJournalInboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_journal_inbound_outstanding_payment_accounts(self):
            // """
            // :return: A recordset with all the account.account used by this journal for inbound transactions.
            // """
            // self.ensure_one()
            // account_ids = set()
            // for line in self.inbound_payment_method_line_ids:
            //     account_ids.add(line.payment_account_id.id)
            // return self.env['account.account'].browse(account_ids)
            */
            return default;
        }

        public async Task<TEntity> GetJournalOutboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_journal_outbound_outstanding_payment_accounts(self):
            // """
            // :return: A recordset with all the account.account used by this journal for outbound transactions.
            // """
            // self.ensure_one()
            // account_ids = set()
            // for line in self.outbound_payment_method_line_ids:
            //     account_ids.add(line.payment_account_id.id)
            // return self.env['account.account'].browse(account_ids)
            */
            return default;
        }

        public async Task<TEntity> GetJournalsPaymentMethodInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _get_journals_payment_method_information(self):
            // method_information = self.env['account.payment.method']._get_payment_method_information()
            // unique_electronic_ids = set()
            // electronic_names = set()
            // pay_methods = self.env['account.payment.method'].sudo().search([('code', 'in', list(method_information.keys()))])
            // manage_providers = 'payment_provider_id' in self.env['account.payment.method.line']._fields
            // 
            // # Split the payment method information per id.
            // method_information_mapping = {}
            // for pay_method in pay_methods:
            //     code = pay_method.code
            //     values = method_information_mapping[pay_method.id] = {
            //         **method_information[code],
            //         'payment_method': pay_method,
            //         'company_journals': {},
            //     }
            //     if values['mode'] == 'unique':
            //         unique_electronic_ids.add(pay_method.id)
            //     elif manage_providers and values['mode'] == 'electronic':
            //         unique_electronic_ids.add(pay_method.id)
            //         electronic_names.add(pay_method.code)
            // 
            // # Load the provider to manage 'electronic' payment methods.
            // providers_per_code = {}
            // if manage_providers:
            //     providers = self.env['payment.provider'].sudo().search([
            //         *self.env['payment.provider']._check_company_domain(self.company_id),
            //         ('code', 'in', tuple(electronic_names)),
            //     ])
            //     for provider in providers:
            //         providers_per_code.setdefault(provider.company_id.id, {}).setdefault(provider._get_code(), set()).add(provider.id)
            // 
            // # Collect the existing unique/electronic payment method lines.
            // if unique_electronic_ids:
            //     fnames = ['payment_method_id', 'journal_id']
            //     if manage_providers:
            //         fnames.append('payment_provider_id')
            //     self.env['account.payment.method.line'].flush_model(fnames=fnames)
            // 
            //     self._cr.execute(
            //         f'''
            //             SELECT
            //                 apm.id,
            //                 journal.company_id,
            //                 journal.id,
            //                 {'apml.payment_provider_id' if manage_providers else 'NULL'}
            //             FROM account_payment_method_line apml
            //             JOIN account_journal journal ON journal.id = apml.journal_id
            //             JOIN account_payment_method apm ON apm.id = apml.payment_method_id
            //             WHERE apm.id IN %s
            //         ''',
            //         [tuple(unique_electronic_ids)],
            //     )
            //     for pay_method_id, company_id, journal_id, provider_id in self._cr.fetchall():
            //         values = method_information_mapping[pay_method_id]
            //         is_electronic = manage_providers and values['mode'] == 'electronic'
            //         if is_electronic:
            //             journal_ids = values['company_journals'].setdefault(company_id, {}).setdefault(provider_id, [])
            //         else:
            //             journal_ids = values['company_journals'].setdefault(company_id, [])
            //         journal_ids.append(journal_id)
            // return {
            //     'pay_methods': pay_methods,
            //     'manage_providers': manage_providers,
            //     'method_information_mapping': method_information_mapping,
            //     'providers_per_code': providers_per_code,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetLastSequenceDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object relaxed) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetLastUpdateOrDefaultAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_last_update_or_default(self):
            // self.ensure_one()
            // labels = dict(self._fields['last_update_status']._description_selection(self.env))
            // return {
            //     'status': labels.get(self.last_update_status, _('Set Status')),
            //     'color': self.last_update_color,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLinesOnchangeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_lines_onchange_currency(self):
            // # Override needed for COGS
            // return self.line_ids
            */
            return default;
        }

        public async Task<TEntity> GetLocalizedDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities, object date_planned) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_localized_date_planned(self, date_planned=False):
            // """Returns the localized date planned in the timezone of the order's user or the
            // company's partner or UTC if none of them are set."""
            // self.ensure_one()
            // date_planned = date_planned or self.date_planned
            // if not date_planned:
            //     return False
            // if isinstance(date_planned, str):
            //     date_planned = fields.Datetime.from_string(date_planned)
            // tz = self.get_order_timezone()
            // return date_planned.astimezone(tz)
            */
            return default;
        }

        public async Task<TEntity> GetLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetMailThreadDataAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_mention_suggestions(self, search, limit=8):
            // """Return the 'limit'-first followers of the given task or followers of its project matching
            // a 'search' string as a list of partner data (returned by `_to_store()`).
            // See similar method for all partners `get_mention_suggestions()`.
            // """
            // self.ensure_one()
            // project = self.project_id
            // if not (
            //     project
            //     and project._check_project_sharing_access()
            //     and project._get_thread_with_access(project.id)
            // ):
            //     return {}
            // # sudo: mail.followers - reading message_follower_ids on accessible task/project is allowed
            // followers = project.sudo().message_follower_ids | self.sudo().message_follower_ids
            // domain = expression.AND([
            //     self.env["res.partner"]._get_mention_suggestions_domain(search),
            //     [("id", "in", followers.partner_id.ids)],
            // ])
            // partners = self.env["res.partner"].sudo()._search_mention_suggestions(domain, limit)
            // return Store(partners).get_result()
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_milestones(self):
            // if self.env.user.has_group('project.group_project_user'):
            //     return self._get_milestones()
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_milestones(self):
            // self.ensure_one()
            // return {
            //     'data': self.milestone_ids._get_data_list(),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMoveDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object show_ref) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetMoveHashDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object common_domain, object force_hash) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetNameInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetNamePortalContentViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetNameTaxTotalsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_name_tax_totals_view(self):
            // """ This method can be inherited by localizations who want to localize the taxes displayed on the portal and sale order report. """
            // return 'sale.document_tax_totals'
            */
            return default;
        }

        public async Task<TEntity> GetNewCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_new_collaborators(self, partners):
            // self.ensure_one()
            // return partners.filtered(
            //     lambda partner:
            //         partner not in self.collaborator_ids.partner_id
            //         and partner.partner_share
            // )
            */
            return default;
        }

        public async Task<TEntity> GetNextBankCashDefaultCodeAsync<TEntity>(IEnumerable<TEntity> entities, object journal_type, object company, object cache, object protected_codes) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def get_next_bank_cash_default_code(self, journal_type, company, cache=None, protected_codes=False):
            // prefix_map = {'cash': 'CSH', 'general': 'GEN', 'bank': 'BNK', 'credit': 'CCD'}
            // journal_code_base = prefix_map.get(journal_type)
            // existing_codes = set(self.env['account.journal'].with_context(active_test=False).search([
            //     *self.env['account.journal']._check_company_domain(company),
            //     ('code', '=like', journal_code_base + '%'),
            // ]).mapped('code') + (cache or []))
            // 
            // for num in range(1, 100):
            //     # journal_code has a maximal size of 5, hence we can enforce the boundary num < 100
            //     journal_code = journal_code_base + str(num)
            //     if journal_code not in existing_codes and (protected_codes and journal_code not in protected_codes or not protected_codes):
            //         return journal_code
            */
            return default;
        }

        public async Task<TEntity> GetNoteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_note_url(self):
            // return self.env.company.get_base_url()
            */
            return default;
        }

        public async Task<TEntity> GetOpenOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_open_order(self, order):
            // return self.env["pos.order"].search([('uuid', '=', order.get('uuid'))], limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetOrderEdiDecoderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_data) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetOrderLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        protected async Task<object> GetOrderLogRepresentationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_order_log_representation(order):
            // return dict((k, order.get(k)) for k in ("name", "uuid"))
            */
            return default;
        }

        public async Task<TEntity> GetOrderTimezoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_order_timezone(self):
            // """ Returns the timezone of the order's user or the company's partner
            // or UTC if none of them are set. """
            // self.ensure_one()
            // return timezone(self.user_id.tz or self.company_id.partner_id.tz or 'UTC')
            */
            return default;
        }

        public async Task<TEntity> GetOrdersToRemindInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_orders_to_remind(self):
            // """When auto sending a reminder mail, only send for unconfirmed purchase
            // order and not all products are service."""
            // return self.search([
            //     ('partner_id', '!=', False),
            //     ('state', 'in', ['purchase', 'done']),
            //     ('mail_reminder_confirmed', '=', False)
            // ]).filtered(lambda p: p.partner_id.with_company(p.company_id).receipt_reminder_email and\
            //     p.mapped('order_line.product_id.product_tmpl_id.type') != ['service'])
            */
            return default;
        }

        public async Task<TEntity> GetOutboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_outbound_types(self, include_receipts=True):
            // return ['in_invoice', 'out_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetPanelDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_panel_data(self):
            // self.ensure_one()
            // if not self.env.user.has_group('project.group_project_user'):
            //     return {}
            // show_profitability = self._show_profitability()
            // panel_data = {
            //     'user': self._get_user_values(),
            //     'buttons': sorted(self._get_stat_buttons(), key=lambda k: k['sequence']),
            //     'currency_id': self.currency_id.id,
            //     'show_project_profitability_helper': show_profitability and self._show_profitability_helper(),
            //     'show_milestones': self.allow_milestones,
            // }
            // if self.allow_milestones:
            //     panel_data['milestones'] = self._get_milestones()
            // if show_profitability:
            //     profitability_items = self.with_context(active_test=False)._get_profitability_items()
            //     if self._get_profitability_sequence_per_invoice_type() and profitability_items and 'revenues' in profitability_items and 'costs' in profitability_items:  # sort the data values
            //         profitability_items['revenues']['data'] = sorted(profitability_items['revenues']['data'], key=lambda k: k['sequence'])
            //         profitability_items['costs']['data'] = sorted(profitability_items['costs']['data'], key=lambda k: k['sequence'])
            //     panel_data['profitability_items'] = profitability_items
            //     panel_data['profitability_labels'] = self._get_profitability_labels()
            // return panel_data
            */
            return default;
        }

        public async Task<TEntity> GetPartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetPartnerCreditWarningExcludeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetPlanDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_plan_domain(self, plan):
            // return AND([super()._get_plan_domain(plan), ['|', ('company_id', '=', False), ('company_id', '=?', unquote('company_id'))]])
            */
            return default;
        }

        public async Task<TEntity> GetPortalLastTransactionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_portal_last_transaction(self):
            // self.ensure_one()
            // return self.transaction_ids.sudo()._get_last()
            */
            return default;
        }

        public async Task<TEntity> GetPortalReturnActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetPortalSudoContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_portal_sudo_context(self):
            // return {
            //     key: value for key, value in self.env.context.items()
            //     if key == 'default_project_id'
            //     or key == 'default_user_ids' and value is False
            //     or not key.startswith('default_')
            //     or key[8:] in (field for field in self.SELF_WRITABLE_FIELDS if self._fields[field].type not in ('one2many', 'many2many'))
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPortalSudoValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object defaults) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_portal_sudo_vals(self, vals, defaults=False):
            // """ returns the values which must be written without and with sudo when a portal user creates / writes a task.
            //     :param vals: dict of {field: value}, the values to create/write
            //     :return: a tuple with 2 dicts:
            //         - the first with the values to write without sudo
            //         - the second with the values to write with sudo
            // """
            // vals_no_sudo = {key: val for key, val in vals.items() if self._fields[key].type in ('one2many', 'many2many')}
            // if defaults:
            //     vals_no_sudo.update({
            //         key[8:]: value
            //         for key, value in self.env.context.items()
            //         if key.startswith('default_') and key[8:] in self.SELF_WRITABLE_FIELDS and self._fields[key[8:]].type in ('one2many', 'many2many')
            //     })
            // vals_sudo = {key: val for key, val in vals.items() if key not in vals_no_sudo}
            // return vals_no_sudo, vals_sudo
            */
            return default;
        }

        public async Task<TEntity> GetPortalUrlAsync<TEntity>(IEnumerable<TEntity> entities, object suffix, object report_type, object download, object query_string, object anchor) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py) ---
            // def get_portal_url(self, suffix=None, report_type=None, download=None, query_string=None, anchor=None):
            // """
            //     Get a portal url for this model, including access_token.
            //     The associated route must handle the flags for them to have any effect.
            //     - suffix: string to append to the url, before the query string
            //     - report_type: report_type query string, often one of: html, pdf, text
            //     - download: set the download query string to true
            //     - query_string: additional query string
            //     - anchor: string to append after the anchor #
            // """
            // self.ensure_one()
            // url = self.access_url + '%s?access_token=%s%s%s%s%s' % (
            //     suffix if suffix else '',
            //     self._portal_ensure_token(),
            //     '&report_type=%s' % report_type if report_type else '',
            //     '&download=true' if download else '',
            //     query_string if query_string else '',
            //     '#%s' % anchor if anchor else ''
            // )
            // return url
            */
            return default;
        }

        public async Task<TEntity> GetPosAngloSaxonPriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, Guid partner_id, object quantity) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetPrepaymentRequiredAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetProductCatalogDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_catalog_domain(self):
            // if self.is_sale_document():
            //     return expression.AND([super()._get_product_catalog_domain(), [('sale_ok', '=', True)]])
            // elif self.is_purchase_document():
            //     return expression.AND([super()._get_product_catalog_domain(), [('purchase_ok', '=', True)]])
            // else:  # In case of an entry
            //     return super()._get_product_catalog_domain()
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_catalog_domain(self):
            // return expression.AND([super()._get_product_catalog_domain(), [('purchase_ok', '=', True)]])
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_catalog_domain(self):
            // return expression.AND([super()._get_product_catalog_domain(), [('sale_ok', '=', True)]])
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogOrderDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_catalog_order_data(self, products, **kwargs):
            // product_catalog = super()._get_product_catalog_order_data(products, **kwargs)
            // for product in products:
            //     product_catalog[product.id] |= self._get_product_price_and_data(product)
            // return product_catalog
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_catalog_order_data(self, products, **kwargs):
            // res = super()._get_product_catalog_order_data(products, **kwargs)
            // for product in products:
            //     res[product.id] |= self._get_product_price_and_data(product)
            // return res
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

        public async Task<TEntity> GetProductCatalogRecordLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, child_field=False):
            // grouped_lines = defaultdict(lambda: self.env['account.move.line'])
            // for line in self.line_ids:
            //     if line.display_type == 'product' and line.product_id.id in product_ids:
            //         grouped_lines[line.product_id] |= line
            // return grouped_lines
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, child_field=False):
            // grouped_lines = defaultdict(lambda: self.env['purchase.order.line'])
            // for line in self.order_line:
            //     if line.display_type or line.product_id.id not in product_ids:
            //         continue
            //     grouped_lines[line.product_id] |= line
            // return grouped_lines
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

        public async Task<TEntity> GetProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetProductPriceAndDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_price_and_data(self, product):
            // """ Fetch the product's data used by the purchase's catalog.
            // 
            // :return: the product's price and, if applicable, the minimum quantity to
            //          buy and the product's packaging data.
            // :rtype: dict
            // """
            // self.ensure_one()
            // product_infos = {
            //     'price': product.standard_price,
            //     'uom': {
            //         'display_name': product.uom_id.display_name,
            //         'id': product.uom_id.id,
            //     },
            // }
            // if product.purchase_line_warn_msg:
            //     product_infos['warning'] = product.purchase_line_warn_msg
            // if product.purchase_line_warn == "block":
            //     product_infos['readOnly'] = True
            // if product.uom_id != product.uom_po_id:
            //     product_infos['purchase_uom'] = {
            //         'display_name': product.uom_po_id.display_name,
            //         'id': product.uom_po_id.id,
            //     }
            // params = {'order_id': self}
            // # Check if there is a price and a minimum quantity for the order's vendor.
            // seller = product._select_seller(
            //     partner_id=self.partner_id,
            //     quantity=None,
            //     date=self.date_order and self.date_order.date(),
            //     uom_id=product.uom_id,
            //     ordered_by='min_qty',
            //     params=params
            // )
            // if seller:
            //     product_infos.update(
            //         price=seller.price_discounted,
            //         min_qty=seller.min_qty,
            //     )
            // # Check if the product uses some packaging.
            // packaging = self.env['product.packaging'].search(
            //     [('product_id', '=', product.id), ('purchase', '=', True)], limit=1
            // )
            // if packaging:
            //     qty = packaging.product_uom_id._compute_quantity(packaging.qty, product.uom_po_id)
            //     product_infos.update(
            //         packaging={
            //             'id': packaging.id,
            //             'name': packaging.display_name,
            //             'qty': qty,
            //         }
            //     )
            // return product_infos
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityAalDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_aal_domain(self):
            // return [('account_id', 'in', self.account_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // return self._get_items_from_aal(with_action)
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilitySequencePerInvoiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_projects_to_make_billable_domain(self):
            // return [('partner_id', '!=', False)]
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_projects_to_make_billable_domain(self, additional_domain=None):
            // return expression.AND([
            //     [('partner_id', '!=', False)],
            //     additional_domain or [],
            // ])
            */
            return default;
        }

        public async Task<TEntity> GetProtectedValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object records) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetPurchaseTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_purchase_types(self, include_receipts=False):
            // return ['in_invoice', 'in_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetQuickEditSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetReconciledAmlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetReconciledInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_invoices(self):
            // """Helper used to retrieve the reconciled invoices on this journal entry"""
            // return self._get_reconciled_amls().move_id.filtered(lambda move: move.is_invoice(include_receipts=True))
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesPartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetReconciledPaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_payments(self):
            // """Helper used to retrieve the reconciled payments on this journal entry"""
            // return self._get_reconciled_amls().move_id.origin_payment_id
            */
            return default;
        }

        public async Task<TEntity> GetReconciledStatementLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_statement_lines(self):
            // """Helper used to retrieve the reconciled statement lines on this journal entry"""
            // return self._get_reconciled_amls().move_id.statement_line_id
            */
            return default;
        }

        public async Task<TEntity> GetRecurrenceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_recurrence_fields(self):
            // return [
            //     'repeat_interval',
            //     'repeat_unit',
            //     'repeat_type',
            //     'repeat_until',
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetRefundedOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _get_refunded_orders(self, order):
            // refunded_orderline_ids = [line[2]['refunded_orderline_id'] for line in order['lines'] if line[0] in [0, 1] and line[2].get('refunded_orderline_id')]
            // return self.env['pos.order.line'].browse(refunded_orderline_ids).mapped('order_id')
            */
            return default;
        }

        public async Task<TEntity> GetReportBaseFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_report_base_filename(self):
            // return self._get_move_display_name()
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_report_base_filename(self):
            // self.ensure_one()
            // return 'Purchase Order-%s' % (self.name)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_report_base_filename(self):
            // self.ensure_one()
            // return f'{self.type_name} {self.name}'
            */
            return default;
        }

        public async Task<TEntity> GetRoundedAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object force_round) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetRoundedBaseAndTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object round_from_tax_lines) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetSaleTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_sale_types(self, include_receipts=False):
            // return ['out_invoice', 'out_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetSequenceDateRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reset) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object redirect, object signup_partner, object pid, object share_token) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py) ---
            // def _get_share_url(self, redirect=False, signup_partner=False, pid=None, share_token=True):
            // """
            // Build the url of the record  that will be sent by mail and adds additional parameters such as
            // access_token to bypass the recipient's rights,
            // signup_partner to allows the user to create easily an account,
            // hash token to allow the user to be authenticated in the chatter of the record portal view, if applicable
            // :param redirect : Send the redirect url instead of the direct portal share url
            // :param signup_partner: allows the user to create an account with pre-filled fields.
            // :param pid: = partner_id - when given, a hash is generated to allow the user to be authenticated
            //     in the portal chatter, if any in the target page,
            //     if the user is redirected to the portal instead of the backend.
            // :return: the url of the record with access parameters, if any.
            // """
            // self.ensure_one()
            // if redirect:
            //     # model / res_id used by mail/view to check access on record
            //     params = {
            //         'model': self._name,
            //         'res_id': self.id,
            //     }
            // else:
            //     params = {}
            // if share_token and hasattr(self, 'access_token'):
            //     params['access_token'] = self._portal_ensure_token()
            // if pid:
            //     params['pid'] = pid
            //     params['hash'] = self._sign_token(pid)
            // if signup_partner and hasattr(self, 'partner_id') and self.partner_id:
            //     params.update(self.partner_id.signup_get_auth_param()[self.partner_id.id])
            // 
            // return '%s?%s' % ('/mail/view' if redirect else self.access_url, url_encode(params))
            */
            return default;
        }

        public async Task<TEntity> GetStartingSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> GetStatButtonsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_stat_buttons(self):
            // self.ensure_one()
            // closed_task_count = self.task_count - self.open_task_count
            // if self.task_count:
            //     number = self.env._(
            //         "%(closed_task_count)s / %(task_count)s (%(closed_rate)s%%)",
            //         closed_task_count=closed_task_count,
            //         task_count=self.task_count,
            //         closed_rate=round(100 * closed_task_count / self.task_count),
            //     )
            // else:
            //     number = self.env._(
            //         "%(closed_task_count)s / %(task_count)s",
            //         closed_task_count=closed_task_count,
            //         task_count=self.task_count,
            //     )
            // buttons = [{
            //     'icon': 'check',
            //     'text': self.env._('Tasks'),
            //     'number': number,
            //     'action_type': 'object',
            //     'action': 'action_view_tasks',
            //     'show': True,
            //     'sequence': 1,
            // }]
            // if self.rating_count != 0 and self.env.user.has_group('project.group_project_rating'):
            //     if self.rating_avg >= rating_data.RATING_AVG_TOP:
            //         icon = 'smile-o text-success'
            //     elif self.rating_avg >= rating_data.RATING_AVG_OK:
            //         icon = 'meh-o text-warning'
            //     else:
            //         icon = 'frown-o text-danger'
            //     buttons.append({
            //         'icon': icon,
            //         'text': self.env._('Average Rating'),
            //         'number': f'{int(self.rating_avg) if self.rating_avg.is_integer() else round(self.rating_avg, 1)} / 5',
            //         'action_type': 'object',
            //         'action': 'action_view_all_rating',
            //         'show': self.rating_active,
            //         'sequence': 15,
            //     })
            // if self.env.user.has_group('project.group_project_user'):
            //     buttons.append({
            //         'icon': 'area-chart',
            //         'text': self.env._('Burndown Chart'),
            //         'action_type': 'action',
            //         'action': 'project.action_project_task_burndown_chart_report',
            //         'additional_context': json.dumps({
            //             'active_id': self.id,
            //             'stage_name_and_sequence_per_id': {
            //                 stage.id: {
            //                     'sequence': stage.sequence,
            //                     'name': stage.name
            //                 } for stage in self.type_ids
            //             },
            //         }),
            //         'show': True,
            //         'sequence': 60,
            //     })
            // return buttons
            */
            return default;
        }

        public async Task<TEntity> GetSubtaskIdsPerTaskIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_subtask_ids_per_task_id(self):
            // if not self:
            //     return {}
            // 
            // res = dict.fromkeys(self._ids, [])
            // if all(self._ids):
            //     self.env.cr.execute(
            //         """
            //  WITH RECURSIVE task_tree
            //              AS (
            //              SELECT id, id as supertask_id
            //                FROM project_task
            //               WHERE id IN %(ancestor_ids)s
            //               UNION
            //                  SELECT t.id, tree.supertask_id
            //                    FROM project_task t
            //                    JOIN task_tree tree
            //                      ON tree.id = t.parent_id
            //                     AND t.active in (TRUE, %(active)s)
            //                   WHERE t.parent_id IS NOT NULL
            //        ) SELECT supertask_id, ARRAY_AGG(id)
            //            FROM task_tree
            //           WHERE id != supertask_id
            //        GROUP BY supertask_id
            //         """,
            //         {
            //             "ancestor_ids": tuple(self.ids),
            //             "active": self._context.get('active_test', True),
            //         }
            //     )
            //     res.update(dict(self.env.cr.fetchall()))
            // else:
            //     res.update({
            //         task.id: task._get_subtasks_recursively().ids
            //         for task in self
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetSubtasksRecursivelyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_subtasks_recursively(self):
            // children = self.child_ids
            // if not children:
            //     return self.env['project.task']
            // return children + children._get_subtasks_recursively()
            */
            return default;
        }

        public async Task<TEntity> GetThreadWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid thread_id, object mode) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_thread_with_access(self, thread_id, mode="read", **kwargs):
            // if project_sharing_id := kwargs.get("project_sharing_id"):
            //     if token := ProjectSharingChatter._check_project_access_and_get_token(
            //         self, project_sharing_id, self._name, thread_id, kwargs.get("token")
            //     ):
            //         kwargs["token"] = token
            // return super()._get_thread_with_access(thread_id, mode, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> GetUnbalancedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetUnlinkLoggerMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def get_unusual_days(self, date_from, date_to=None):
            // calendar = self.env.company.resource_calendar_id
            // return calendar._get_unusual_days(
            //     datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=UTC),
            //     datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=UTC)
            // )
            */
            return default;
        }

        public async Task<TEntity> GetUpdatePricesLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_update_prices_lines(self):
            // """ Hook to exclude specific lines which should not be updated based on price list recomputation """
            // return self.order_line.filtered(lambda line: not line.display_type)
            */
            return default;
        }

        public async Task<TEntity> GetUpdateUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_update_url(self):
            // """Create portal url for user to update the scheduled date on purchase
            // order lines."""
            // update_param = url_encode({'update': 'True'})
            // return self.get_portal_url(query_string='&%s' % update_param)
            */
            return default;
        }

        public async Task<TEntity> GetUserValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_user_values(self):
            // return {
            //     'is_project_user': self.env.user.has_group('project.group_project_user'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetValidJournalTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetValidSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetValuesAnalyticAccountBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project_vals_list) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_values_analytic_account_batch(self, project_vals_list):
            // project_plan, _other_plans = self.env['account.analytic.plan']._get_all_plans()
            // return [{
            //     'name': project_vals.get('name', self.env._('Unknown Analytic Account')),
            //     'company_id': project_vals.get('company_id', False),
            //     'partner_id': project_vals.get('partner_id', False),
            //     'plan_id': project_plan.id,
            // } for project_vals in project_vals_list]
            */
            return default;
        }

        public async Task<TEntity> GetVersionedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_versioned_fields(self):
            // return [Task.description.name]
            */
            return default;
        }

        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _get_view_cache_key(self, view_id=None, view_type='form', **options):
            // """The override of fields_get making fields readonly for portal users
            // makes the view cache dependent on the fact the user has the group portal or not"""
            // key = super()._get_view_cache_key(view_id, view_type, **options)
            // return key + (self.env.user._is_portal(),)
            */
            return default;
        }

        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> GetViolatedLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> HasToBePaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> HasToBeSignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> HashMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def init(self):
            // super().init()
            // create_index(self.env.cr,
            //              indexname='account_move_journal_id_company_id_idx',
            //              tablename='account_move',
            //              expressions=['journal_id', 'company_id', 'date'])
            // create_index(
            //     self.env.cr,
            //     indexname='account_move_made_gaps',
            //     tablename='account_move',
            //     expressions=['journal_id', 'company_id', 'date'],
            //     where="made_sequence_gap = TRUE",
            // )  # used in <account.journal>._query_has_sequence_holes
            // create_index(
            //     self.env.cr,
            //     indexname='account_move_duplicate_bills_idx',
            //     tablename='account_move',
            //     expressions=['ref'],
            //     where="move_type IN ('in_invoice', 'in_refund')",
            // )
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def init(self):
            // create_index(self._cr, 'sale_order_date_order_id_idx', 'sale_order', ["date_order desc", "id desc"])
            */
            return default;
        }

        public async Task<TEntity> InverseAllowTaskDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_task_dependencies(self):
            // """ Reset state for waiting tasks in the project if the feature is disabled
            //     or recompute the tasks with dependencies if the project has the feature enabled again
            // """
            // project_with_task_dependencies_feature = self.filtered('allow_task_dependencies')
            // projects_without_task_dependencies_feature = self - project_with_task_dependencies_feature
            // ProjectTask = self.env['project.task']
            // if (
            //     project_with_task_dependencies_feature
            //     and (
            //         open_tasks_with_dependencies := ProjectTask.search([
            //             ('project_id', 'in', project_with_task_dependencies_feature.ids),
            //             ('depend_on_ids.state', 'in', ProjectTask.OPEN_STATES),
            //             ('state', 'in', ProjectTask.OPEN_STATES),
            //         ])
            //     )
            // ):
            //     open_tasks_with_dependencies.state = '04_waiting_normal'
            // if (
            //     projects_without_task_dependencies_feature
            //     and (
            //         waiting_tasks := ProjectTask.search([
            //             ('project_id', 'in', projects_without_task_dependencies_feature.ids),
            //             ('state', '=', '04_waiting_normal'),
            //         ])
            //     )
            // ):
            //     waiting_tasks.state = '01_in_progress'
            */
            return default;
        }

        public async Task<TEntity> InverseAmountTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_company_id(self):
            // """
            // Ensures that the new company of the project is valid for the account. If not set back the previous company, and raise a user Error.
            // Ensures that the new company of the project is valid for the partner
            // """
            // for project in self:
            //     account = project.account_id
            //     if project.partner_id and project.partner_id.company_id and project.company_id != project.partner_id.company_id:
            //         raise UserError(_('The project and the associated partner must be linked to the same company.'))
            //     if not account or not account.company_id:
            //         continue
            //     # if the account of the project has more than one company linked to it, or if it has aal, do not update the account, and set back the old company on the project.
            //     if (account.project_count > 1 or account.line_ids) and project.company_id != account.company_id:
            //         raise UserError(
            //             _("The project's company cannot be changed if its analytic account has analytic lines or if more than one project is linked to it."))
            //     account.company_id = project.company_id
            */
            return default;
        }

        public async Task<TEntity> InverseCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> InverseDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_display_name(self):
            // for task in self:
            //     pattern = re.compile(r'^%s.+?%s$' % (
            //         ('').join(task._get_cannot_start_with_patterns()),
            //         ('').join(task._get_groups_patterns()))
            //     )
            //     match = pattern.match(task.display_name)
            //     if match:
            //         for group, extract_data in enumerate(task._get_groups(), start=1):
            //             if match.group(group):
            //                 extract_data(task)
            //         task.name = task.display_name.strip()
            */
            return default;
        }

        public async Task<TEntity> InverseInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> InverseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> InversePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> InversePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> InversePersonalStageTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_personal_stage_type_id(self):
            // for task in self:
            //     task.personal_stage_id.stage_id = task.personal_stage_type_id
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _inverse_state(self):
            // last_task_id_per_recurrence_id = self.recurrence_id._get_last_task_id_per_recurrence_id()
            // for task in self:
            //     if task.state in CLOSED_STATES and task.id == last_task_id_per_recurrence_id.get(task.recurrence_id.id):
            //         task.recurrence_id._create_next_occurrence(task)
            */
            return default;
        }

        public async Task<TEntity> InverseTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> InvoicePaidHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _invoice_paid_hook(self):
            // ''' Hook to be overrided called when the invoice moves to the paid state. '''
            */
            return default;
        }

        public async Task<TEntity> IsBlockedByDependencesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def is_blocked_by_dependences(self):
            // return any(blocking_task.state not in CLOSED_STATES for blocking_task in self.depend_on_ids)
            */
            return default;
        }

        public async Task<TEntity> IsConfirmationAmountReachedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> IsDownpaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> IsEligibleForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object currency, object reference_date) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> IsEntryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_entry(self):
            // return self.move_type == 'entry'
            */
            return default;
        }

        public async Task<TEntity> IsInboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_inbound(self, include_receipts=True):
            // return self.move_type in self.get_inbound_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_invoice(self, include_receipts=False):
            // return self.is_sale_document(include_receipts) or self.is_purchase_document(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsMoveRestrictedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object force_hash) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> IsOutboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_outbound(self, include_receipts=True):
            // return self.move_type in self.get_outbound_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> IsPaymentMethodAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method_code, object complete_domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _is_payment_method_available(self, payment_method_code, complete_domain=True):
            // """ Check if the payment method is available on this journal. """
            // self.ensure_one()
            // method_domain = self.env['account.payment.method']._get_payment_method_domain(
            //     code=payment_method_code,
            //     with_country=complete_domain,
            //     with_currency=complete_domain,
            // )
            // return self.filtered_domain(method_domain)
            */
            return default;
        }

        public async Task<TEntity> IsPosOrderPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> IsProtectedByAuditTrailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_protected_by_audit_trail(self):
            // return any(move.posted_before and move.company_id.check_account_audit_trail for move in self)
            */
            return default;
        }

        public async Task<TEntity> IsPurchaseDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_purchase_document(self, include_receipts=False):
            // return self.move_type in self.get_purchase_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_readonly(self):
            // """
            //     Check if the move has been canceled
            // """
            // self.ensure_one()
            // return self.state == 'cancel'
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _is_readonly(self):
            // """ Return whether the purchase order is read-only or not based on the state.
            // A purchase order is considered read-only if its state is 'cancel'.
            // 
            // :return: Whether the purchase order is read-only or not.
            // :rtype: bool
            // """
            // self.ensure_one()
            // return self.state == 'cancel'
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

        public async Task<TEntity> IsReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> IsRecurrenceValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _is_recurrence_valid(self):
            // self.ensure_one()
            // return self.repeat_interval > 0 and\
            //         (self.repeat_type != 'until' or self.repeat_until and self.repeat_until > fields.Date.today())
            */
            return default;
        }

        public async Task<TEntity> IsSaleDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_sale_document(self, include_receipts=False):
            // return self.move_type in self.get_sale_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> JsAssignOutstandingLineAsync<TEntity>(IEnumerable<TEntity> entities, Guid line_id) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> JsRemoveOutstandingPartialAsync<TEntity>(IEnumerable<TEntity> entities, Guid partial_id) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> LinkBillOriginToPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timeout) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> LinkComboItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combo_child_uuids_by_parent_uuid) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('state', '=', 'draft'), ('session_id', '=', data['pos.session']['data'][0]['id'])]
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _load_records_create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('recurring_task'):
            //         if not vals.get('recurrence_id'):
            //             default_val = self.default_get(self._get_recurrence_fields())
            //             vals.update(**default_val)
            //     project_id = vals.get('project_id')
            //     if project_id:
            //         self = self.with_context(default_project_id=project_id)
            // tasks = super()._load_records_create(vals_list)
            // 
            // return tasks
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _mail_get_message_subtypes(self):
            // res = super()._mail_get_message_subtypes()
            // if not self.rating_active:
            //     res -= self.env.ref('project.mt_project_task_rating')
            // if len(self) == 1:
            //     waiting_subtype = self.env.ref('project.mt_project_task_waiting')
            //     if not self.allow_task_dependencies and waiting_subtype in res:
            //         res -= waiting_subtype
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _mail_get_message_subtypes(self):
            // res = super()._mail_get_message_subtypes()
            // if not self.project_id.rating_active:
            //     res -= self.env.ref('project.mt_task_rating')
            // if len(self) == 1:
            //     waiting_subtype = self.env.ref('project.mt_task_waiting')
            //     if ((self.project_id and not self.project_id.allow_task_dependencies)\
            //         or (not self.project_id and not self.env.user.has_group('project.group_project_task_dependencies')))\
            //         and waiting_subtype in res:
            //         res -= waiting_subtype
            // return res
            */
            return default;
        }

        public async Task<TEntity> MailingGetDefaultDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mailing) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _mailing_get_default_domain(self, mailing):
            // return ['&', ('move_type', '=', 'out_invoice'), ('state', '=', 'posted')]
            */
            return default;
        }

        public async Task<TEntity> MapTasksAsync<TEntity>(IEnumerable<TEntity> entities, Guid new_project_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def map_tasks(self, new_project_id):
            // """ copy and map tasks from old to new project """
            // project = self.browse(new_project_id)
            // new_tasks = self.env['project.task']
            // # We want to copy archived task, but do not propagate an active_test context key
            // tasks = self.env['project.task'].with_context(active_test=False).search([('project_id', '=', self.id), ('parent_id', '=', False)])
            // if self.allow_task_dependencies and 'task_mapping' not in self.env.context:
            //     self = self.with_context(task_mapping=dict())
            // # preserve task name and stage, normally altered during copy
            // defaults = self._map_tasks_default_values(project)
            // new_tasks = tasks.with_context(copy_project=True).copy(defaults)
            // all_subtasks = new_tasks._get_all_subtasks()
            // project.write({'tasks': [Command.set(new_tasks.ids)]})
            // subtasks_not_displayed = all_subtasks.filtered(
            //     lambda task: not task.display_in_project
            // )
            // all_subtasks.filtered(
            //     lambda child: child.project_id == self
            // ).write({
            //     'project_id': project.id
            // })
            // subtasks_not_displayed.write({
            //     'display_in_project': False
            // })
            // return True
            */
            return default;
        }

        public async Task<TEntity> MapTasksDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _map_tasks_default_values(self, project):
            // """ get the default value for the copied task on project duplication.
            // The stage_id, name field will be set for each task in the overwritten copy_data function in project.task """
            // return {
            //     'state': '01_in_progress',
            //     'company_id': project.company_id.id,
            //     'project_id': project.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> MarkupListMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> MergeAlternativePoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfqs) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _merge_alternative_po(self, rfqs):
            // pass
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> default_subtype_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _message_auto_subscribe_followers(self, updated_values, default_subtype_ids):
            // if 'user_ids' not in updated_values:
            //     return []
            // # Since the changes to user_ids becoming a m2m, the default implementation of this function
            // #  could not work anymore, override the function to keep the functionality.
            // new_followers = []
            // # Normalize input to tuple of ids
            // value = self._fields['user_ids'].convert_to_cache(updated_values.get('user_ids', []), self.env['project.task'], validate=False)
            // users = self.env['res.users'].browse(value)
            // for user in users:
            //     try:
            //         if user.partner_id:
            //             # The you have been assigned notification is handled separately
            //             new_followers.append((user.partner_id.id, default_subtype_ids, False))
            //     except Exception:
            //         pass
            // return new_followers
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     reason = _('Customer Email') if self.partner_id.email else _('Customer')
            //     self._message_add_suggested_recipient(recipients, partner=self.partner_id, reason=reason)
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

        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg, object custom_values) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // # EXTENDS mail mail.thread
            // # Add custom behavior when receiving a new invoice through the mail's gateway.
            // if (custom_values or {}).get('move_type', 'entry') not in ('out_invoice', 'in_invoice', 'entry'):
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
            // extra_domain = False
            // if custom_values.get('company_id'):
            //     extra_domain = ['|', ('company_id', '=', custom_values['company_id']), ('company_id', '=', False)]
            // 
            // # Search for partners in copy.
            // cc_mail_addresses = email_split(msg_dict.get('cc', ''))
            // followers = [partner for partner in self._mail_find_partner_from_emails(cc_mail_addresses, extra_domain=extra_domain) if partner]
            // 
            // # Search for partner that sent the mail.
            // from_mail_addresses = email_split(msg_dict.get('from', ''))
            // senders = partners = [partner for partner in self._mail_find_partner_from_emails(from_mail_addresses, extra_domain=extra_domain) if partner]
            // 
            // # Search for partners using the user.
            // if not senders:
            //     senders = partners = list(self._mail_search_on_user(from_mail_addresses))
            // 
            // if partners:
            //     # Check we are not in the case when an internal user forwarded the mail manually.
            //     if is_internal_partner(partners[0]):
            //         # Search for partners in the mail's body.
            //         body_mail_addresses = set(email_re.findall(msg_dict.get('body')))
            //         partners = [
            //             partner
            //             for partner in self._mail_find_partner_from_emails(body_mail_addresses, extra_domain=extra_domain)
            //             if not is_internal_partner(partner) and partner.company_id.id in (False, company.id)
            //         ]
            // # Little hack: Inject the mail's subject in the body.
            // if msg_dict.get('subject') and msg_dict.get('body'):
            //     msg_dict['body'] = Markup('<div><div><h3>%s</h3></div>%s</div>') % (msg_dict['subject'], msg_dict['body'])
            // 
            // # Create the invoice.
            // values = {
            //     'name': '/',  # we have to give the name otherwise it will be set to the mail's subject
            //     'invoice_source_email': from_mail_addresses[0],
            //     'partner_id': partners and partners[0].id or False,
            // }
            // move_ctx = self.with_context(default_move_type=custom_values['move_type'], default_journal_id=custom_values['journal_id'])
            // move = super(AccountMove, move_ctx).message_new(msg_dict, custom_values=values)
            // move._compute_name()  # because the name is given, we need to recompute in case it is the first invoice of the journal
            // 
            // # Assign followers.
            // all_followers_ids = set(partner.id for partner in followers + senders + partners if is_internal_partner(partner))
            // move.message_subscribe(list(all_followers_ids))
            // return move
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_new(self, msg, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
            // # remove default author when going through the mail gateway. Indeed we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // create_context = dict(self.env.context or {})
            // create_context['default_user_ids'] = False
            // create_context['mail_notify_author'] = True  # Allows sending stage updates to the author
            // if custom_values is None:
            //     custom_values = {}
            // # Auto create partner if not existant when the task is created from email
            // if not msg.get('author_id') and msg.get('email_from'):
            //     msg['author_id'] = self.env['res.partner'].create({
            //         'email': msg['email_from'],
            //         'name': msg['email_from'],
            //     }).id
            // 
            // defaults = {
            //     'name': msg.get('subject') or _("No Subject"),
            //     'allocated_hours': 0.0,
            //     'partner_id': msg.get('author_id'),
            // }
            // defaults.update(custom_values)
            // 
            // task = super(Task, self.with_context(create_context)).message_new(msg, custom_values=defaults)
            // email_list = task.email_split(msg)
            // partner_ids = [p.id for p in self.env['mail.thread']._mail_find_partner_from_emails(email_list, records=task, force_create=False) if p]
            // task.message_subscribe(partner_ids)
            // return task
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _message_post_after_hook(self, new_message, message_values):
            // # EXTENDS mail mail.thread
            // # When posting a message, check the attachment to see if it's an invoice and update with the imported data.
            // res = super()._message_post_after_hook(new_message, message_values)
            // if not self.env.user._is_internal():
            //     return res
            // 
            // attachments = new_message.attachment_ids
            // attachments_per_invoice = defaultdict(lambda: self.env['ir.attachment'])
            // 
            // checked_attachment = self._check_and_decode_attachment(attachments)
            // if not checked_attachment:
            //     return res
            // 
            // for attachment_in_res, invoices in checked_attachment.items():
            //     invoices = invoices or self
            //     for invoice in invoices:
            //         attachments_per_invoice[invoice] |= attachment_in_res
            // 
            // for invoice, attachments in attachments_per_invoice.items():
            //     if invoice == self:
            //         invoice.attachment_ids |= attachments
            //         new_message.attachment_ids = attachments.ids
            //         message_values.update({'res_id': self.id, 'attachment_ids': [Command.link(attachment.id) for attachment in attachments]})
            //         super(AccountMove, invoice)._message_post_after_hook(new_message, message_values)
            //     else:
            //         sub_new_message = new_message.copy({'attachment_ids': attachments.ids})
            //         sub_message_values = {
            //             **message_values,
            //             'res_id': invoice.id,
            //             'attachment_ids': [Command.link(attachment.id) for attachment in attachments],
            //         }
            //         invoice.attachment_ids |= attachments
            //         invoice.message_ids = [Command.set(sub_new_message.id)]
            //         super(AccountMove, invoice)._message_post_after_hook(sub_new_message, sub_message_values)
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if message.attachment_ids and not self.displayed_image_id:
            //     image_attachments = message.attachment_ids.filtered(lambda a: a.mimetype == 'image')
            //     if image_attachments:
            //         self.displayed_image_id = image_attachments[0]
            // 
            // # use the sanitized body of the email from the message thread to populate the task's description
            // if (
            //    not self.description
            //    and message.subtype_id == self._creation_subtype()
            //    and self.partner_id == message.author_id
            //    and msg_vals['message_type'] == 'email'
            // ):
            //     self.description = message.body
            // return super(Task, self)._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def message_post(self, **kwargs):
            // if self.env.context.get('mark_rfq_as_sent'):
            //     self.filtered(lambda o: o.state == 'draft').write({'state': 'sent'})
            // po_ctx = {'mail_post_autofollow': self.env.context.get('mail_post_autofollow', True)}
            // if self.env.context.get('mark_rfq_as_sent') and 'notify_author' not in kwargs:
            //     kwargs['notify_author'] = self.env.user.partner_id.id in (kwargs.get('partner_ids') or [])
            // return super(PurchaseOrder, self.with_context(**po_ctx)).message_post(**kwargs)
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

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def message_subscribe(self, partner_ids=None, subtype_ids=None):
            // """
            // Subscribe to newly created task but not all existing active task when subscribing to a project.
            // User update notification preference of project its propagated to all the tasks that the user is
            // currently following.
            // """
            // res = super(Project, self).message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // if subtype_ids:
            //     project_subtypes = self.env['mail.message.subtype'].browse(subtype_ids)
            //     task_subtypes = (project_subtypes.mapped('parent_id') | project_subtypes.filtered(lambda sub: sub.internal or sub.default)).ids
            //     if task_subtypes:
            //         for task in self.task_ids:
            //             partners = set(task.message_partner_ids.ids) & set(partner_ids)
            //             if partners:
            //                 task.message_subscribe(partner_ids=list(partners), subtype_ids=task_subtypes)
            //         self.update_ids.message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_subscribe(self, partner_ids=None, subtype_ids=None):
            // """ Set task notification based on project notification preference if user follow the project"""
            // if not subtype_ids:
            //     project_followers = self.project_id.sudo().message_follower_ids.filtered(lambda f: f.partner_id.id in partner_ids)
            //     for project_follower in project_followers:
            //         project_subtypes = project_follower.subtype_ids
            //         task_subtypes = (project_subtypes.mapped('parent_id') | project_subtypes.filtered(lambda sub: sub.internal or sub.default)).ids if project_subtypes else None
            //         partner_ids.remove(project_follower.partner_id.id)
            //         super().message_subscribe(project_follower.partner_id.ids, task_subtypes)
            // return super().message_subscribe(partner_ids, subtype_ids)
            */
            return default;
        }

        public async Task<TEntity> MessageUnsubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def message_unsubscribe(self, partner_ids=None):
            // super().message_unsubscribe(partner_ids=partner_ids)
            // if partner_ids:
            //     self.env['project.collaborator'].search([('partner_id', 'in', partner_ids), ('project_id', 'in', self.ids)]).unlink()
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg, object update_vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def message_update(self, msg, update_vals=None):
            // """ Override to update the task according to the email. """
            // email_list = self.email_split(msg)
            // partner_ids = [p.id for p in self.env['mail.thread']._mail_find_partner_from_emails(email_list, records=self, force_create=False) if p]
            // self.message_subscribe(partner_ids)
            // return super(Task, self).message_update(msg, update_vals=update_vals)
            */
            return default;
        }

        public async Task<TEntity> MoveDictToPreviewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals, Guid currency_id) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> MustCheckConstrainsDateSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _must_check_constrains_date_sequence(self):
            // # OVERRIDES sequence.mixin
            // return self.state == 'posted' and not self.quick_edit_mode
            */
            return default;
        }

        public async Task<TEntity> MustDeleteDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _must_delete_date_planned(self, field_name):
            // # To be overridden
            // return field_name == 'order_line'
            */
            return default;
        }

        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def name_create(self, name):
            // res = super().name_create(name)
            // if res:
            //     # We create a default stage `new` for projects created on the fly.
            //     self.browse(res[0]).type_ids += self.env['project.task.type'].sudo().create({'name': _('New')})
            // return res
            */
            return default;
        }

        public async Task<TEntity> NeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> NothingToInvoiceErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> NotifyByEmailGetHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object headers) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_by_email_get_headers(self, headers=None):
            // headers = super(Task, self)._notify_by_email_get_headers(headers=headers)
            // if self.project_id:
            //     current_objects = [h for h in headers.get('X-Odoo-Objects', '').split(',') if h]
            //     current_objects.insert(0, 'project.project-%s, ' % self.project_id.id)
            //     headers['X-Odoo-Objects'] = ','.join(current_objects)
            // if self.tag_ids:
            //     headers['X-Odoo-Tags'] = ','.join(self.tag_ids.mapped('name'))
            // return headers
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // # EXTENDS mail mail.thread
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // record = render_context['record']
            // subtitles = [f"{record.name} - {record.partner_id.name}" if record.partner_id else record.name]
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
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // if self.stage_id:
            //     render_context['subtitles'].append(_('Stage: %s', self.stage_id.name))
            // return render_context
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // subtitles = [render_context['record'].name]
            // # don't show price on RFQ mail
            // if self.state in ['draft', 'sent']:
            //     subtitles.append(_('Order\N{NO-BREAK SPACE}due\N{NO-BREAK SPACE}%(date)s',
            //         date=format_date(self.env, self.date_order, lang_code=render_context.get('lang'))
            //     ))
            // else:
            //     subtitles.append(format_amount(self.env, self.amount_total, self.currency_id, lang_code=render_context.get('lang')))
            // render_context['subtitles'] = subtitles
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

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
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
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Give access to the portal user/customer if the project visibility is portal. """
            // groups = super()._notify_get_recipients_groups(message, model_description, msg_vals=msg_vals)
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // portal_privacy = self.privacy_visibility == 'portal'
            // for group_name, _group_method, group_data in groups:
            //     if group_name in ['portal', 'portal_customer'] and not portal_privacy:
            //         group_data['has_button_access'] = False
            // return groups
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Handle project users and managers recipients that can assign
            // tasks and create new one directly from notification emails. Also give
            // access button to portal users and portal customers. If they are notified
            // they should probably have access to the document. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // 
            // project_user_group_id = self.env.ref('project.group_project_user').id
            // new_group = ('group_project_user', lambda pdata: pdata['type'] == 'user' and project_user_group_id in pdata['groups'], {})
            // groups = [new_group] + groups
            // 
            // if self.project_privacy_visibility == 'portal':
            //     groups.insert(0, (
            //         'allowed_portal_users',
            //         lambda pdata: pdata['type'] == 'portal',
            //         {
            //             'active': True,
            //             'has_button_access': True,
            //         }
            //     ))
            // portal_privacy = self.project_id.privacy_visibility == 'portal'
            // for group_name, _group_method, group_data in groups:
            //     if group_name in ('customer', 'user') or group_name == 'portal_customer' and not portal_privacy:
            //         group_data['has_button_access'] = False
            //     elif group_name == 'portal_customer' and portal_privacy:
            //         group_data['has_button_access'] = True
            // 
            // return groups
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Tweak 'view document' button for portal customers, calling directly
            // routes for confirm specific to PO model. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // try:
            //     customer_portal_group = next(group for group in groups if group[0] == 'portal_customer')
            // except StopIteration:
            //     pass
            // else:
            //     access_opt = customer_portal_group[2].setdefault('button_access', {})
            //     if self.env.context.get('is_reminder'):
            //         access_opt['title'] = _('View')
            //         actions = customer_portal_group[2].setdefault('actions', list())
            //         actions.extend([
            //             {'url': self.get_confirm_url(confirm_type='reminder'), 'title': _('Accept')},
            //             {'url': self.get_update_url(), 'title': _('Update Dates')},
            //         ])
            //     else:
            //         access_opt['title'] = _('View Quotation') if self.state in ('draft', 'sent') else _('View Order')
            //         access_opt['url'] = self.get_confirm_url()
            // 
            // return groups
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

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of tasks to their project if any. """
            // aliases = self.sudo().mapped('project_id')._notify_get_reply_to(default=default)
            // res = {task.id: aliases.get(task.project_id.id) for task in self}
            // leftover = self.filtered(lambda rec: not rec.project_id)
            // if leftover:
            //     res.update(super(Task, leftover)._notify_get_reply_to(default=default))
            // return res
            */
            return default;
        }

        public async Task<TEntity> OPENSTATESAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def OPEN_STATES(self):
            // """ Return a list of the technical names complementing the CLOSED_STATES, a.k.a the open states """
            // return list(set(self._fields['state'].get_values(self.env)) - set(CLOSED_STATES))
            */
            return default;
        }

        public async Task<TEntity> OnchangeAmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _onchange_amount_all(self):
            // self._compute_prices()
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, object values, object field_names, object fields_spec) where TEntity : IEntity<Guid>, IPortalMixinable
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
            // return super().onchange(values, field_names, fields_spec)
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def onchange(self, values, field_names, fields_spec):
            // """
            // Override onchange to NOT update all date_planned on PO lines when
            // date_planned on PO is updated by the change of date_planned on PO lines.
            // """
            // result = super().onchange(values, field_names, fields_spec)
            // if any(self._must_delete_date_planned(field) for field in field_names) and 'value' in result:
            //     for line in result['value'].get('order_line', []):
            //         if line[0] == Command.UPDATE and 'date_planned' in line[2]:
            //             del line[2]['date_planned']
            // return result
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def onchange(self, values, field_names, fields_spec):
            // self_with_context = self
            // if not field_names: # Some warnings should not be displayed for the first onchange
            //     self_with_context = self.with_context(sale_onchange_first_call=True)
            // return super(SaleOrder, self_with_context).onchange(values, field_names, fields_spec)
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommitmentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _onchange_company_id(self):
            // if (self.env.user.has_group('project.group_project_stages') and self.stage_id.company_id
            //         and self.stage_id.company_id != self.company_id):
            //     self.stage_id = self.env['project.project.stage'].search(
            //         [('company_id', 'in', [self.company_id.id, False])],
            //         order=f"sequence asc, {self.env['project.project.stage']._order}",
            //         limit=1,
            //     ).id
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

        public async Task<TEntity> OnchangeCompanyIdWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_date(self):
            // if not self.is_invoice(True):
            //     self.line_ids._inverse_amount_currency()
            */
            return default;
        }

        public async Task<TEntity> OnchangeDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def onchange_date_planned(self):
            // if self.date_planned:
            //     self.order_line.filtered(lambda line: not line.display_type).date_planned = self.date_planned
            */
            return default;
        }

        public async Task<TEntity> OnchangeFposIdShowUpdateFposInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_fpos_id_show_update_fpos(self):
            // self.show_update_fpos = self.line_ids and self._origin.fiscal_position_id != self.fiscal_position_id
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

        public async Task<TEntity> OnchangeInvoiceCashRoundingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangeInvoiceVendorBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangeNameWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangeOrderLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_parent_id(self):
            // if self.display_in_project:
            //     return
            // if not self.parent_id:
            //     self.display_in_project = True
            // elif self.project_id != self.parent_id.project_id:
            //     self.project_id = self.parent_id.project_id
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def onchange_partner_id(self):
            // # Ensures all properties and fiscal positions
            // # are taken with the company of the order
            // # if not defined, with_company doesn't change anything.
            // self = self.with_company(self.company_id)
            // default_currency = self._context.get("default_currency_id")
            // if not self.partner_id:
            //     self.fiscal_position_id = False
            //     self.currency_id = default_currency or self.env.company.currency_id.id
            // else:
            //     self.fiscal_position_id = self.env['account.fiscal.position']._get_fiscal_position(self.partner_id)
            //     self.payment_term_id = self.partner_id.property_supplier_payment_term_id.id
            //     self.currency_id = default_currency or self.partner_id.property_purchase_currency_id.id or self.env.company.currency_id.id
            //     if self.partner_id.buyer_id:
            //         self.user_id = self.partner_id.buyer_id
            // return {}
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _onchange_partner_id(self):
            // if self.partner_id:
            //     self.pricelist_id = self.partner_id.property_product_pricelist.id
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdWarningAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def onchange_partner_id_warning(self):
            // if not self.partner_id or not self.env.user.has_group('purchase.group_warning_purchase'):
            //     return
            // 
            // partner = self.partner_id
            // 
            // # If partner has no warning, check its company
            // if partner.purchase_warn == 'no-message' and partner.parent_id:
            //     partner = partner.parent_id
            // 
            // if partner.purchase_warn and partner.purchase_warn != 'no-message':
            //     # Block if partner only has warning but parent company is blocked
            //     if partner.purchase_warn != 'block' and partner.parent_id and partner.parent_id.purchase_warn == 'block':
            //         partner = partner.parent_id
            //     title = _("Warning for %s", partner.name)
            //     message = partner.purchase_warn_msg
            //     warning = {
            //         'title': title,
            //         'message': message
            //     }
            //     if partner.purchase_warn == 'block':
            //         self.update({'partner_id': False})
            //     return {'warning': warning}
            // return {}
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_prepayment_percent(self):
            // if not self.prepayment_percent:
            //     self.require_payment = False
            */
            return default;
        }

        public async Task<TEntity> OnchangePricelistIdShowUpdatePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_pricelist_id_show_update_prices(self):
            // self.show_update_pricelist = bool(self.order_line)
            */
            return default;
        }

        public async Task<TEntity> OnchangeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_project_id(self):
            // if self.state != '04_waiting_normal':
            //     self.state = '01_in_progress'
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangeQuickEditTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OnchangeTaskCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _onchange_task_company(self):
            // if self.project_id.company_id and self.project_id.company_id != self.company_id:
            //     self.project_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeForAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _onchange_type_for_alias(self):
            // self.filtered(lambda journal: journal.type not in {'sale', 'purchase'}).alias_name = False
            // for journal in self.filtered(lambda journal: (
            //     not journal.alias_name and journal.type in {'sale', 'purchase'})
            // ):
            //     journal.alias_name = self._alias_prepare_alias_name(
            //         False, journal.name, journal.code, journal.type, journal.company_id)
            */
            return default;
        }

        public async Task<TEntity> OpenCreatedCabaEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> OpenPaymentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_payments(self):
            // return self.matched_payment_ids._get_records_action(name=_("Payments"))
            */
            return default;
        }

        public async Task<TEntity> OpenReconcileViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_reconcile_view(self):
            // return self.line_ids.open_reconcile_view()
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _order_field_to_sql(self, alias, field_name, direction, nulls, query):
            // if field_name == 'is_favorite':
            //     sql_field = SQL(
            //         "%s IN (SELECT project_id FROM project_favorite_user_rel WHERE user_id = %s)",
            //         SQL.identifier(alias, 'id'), self.env.uid,
            //     )
            //     return SQL("%s %s %s", sql_field, direction, nulls)
            // 
            // return super()._order_field_to_sql(alias, field_name, direction, nulls, query)
            */
            return default;
        }

        public async Task<TEntity> PaymentActionCaptureAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PaymentActionVoidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _phone_get_number_fields(self):
            // """ No phone or mobile field is available on sale model. Instead SMS will
            // fallback on partner-based computation using ``_mail_get_partner_fields``. """
            // return []
            */
            return default;
        }

        public async Task<TEntity> PopulateMissingPersonalStagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _populate_missing_personal_stages(self):
            // # Assign the default personal stage for those that are missing
            // personal_stages_without_stage = self.env['project.task.stage.personal'].sudo().search([('task_id', 'in', self.ids), ('stage_id', '=', False)])
            // if personal_stages_without_stage:
            //     user_ids = personal_stages_without_stage.user_id
            //     personal_stage_by_user = defaultdict(lambda: self.env['project.task.stage.personal'])
            //     for personal_stage in personal_stages_without_stage:
            //         personal_stage_by_user[personal_stage.user_id] |= personal_stage
            //     for user_id in user_ids:
            //         stage = self.env['project.task.type'].sudo().search([('user_id', '=', user_id.id)], limit=1)
            //         # In the case no stages have been found, we create the default stages for the user
            //         if not stage:
            //             stages = self.env['project.task.type'].sudo().with_context(lang=user_id.partner_id.lang, default_project_ids=False).create(
            //                 self.with_context(lang=user_id.partner_id.lang)._get_default_personal_stage_create_vals(user_id.id)
            //             )
            //             stage = stages[0]
            //         personal_stage_by_user[user_id].sudo().write({'stage_id': stage.id})
            */
            return default;
        }

        public async Task<TEntity> PortalEnsureTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py) ---
            // def _portal_ensure_token(self):
            // """ Get the current record access token """
            // if not self.access_token:
            //     # we use a `write` to force the cache clearing otherwise `return self.access_token` will return False
            //     self.sudo().write({'access_token': str(uuid.uuid4())})
            // return self.access_token
            */
            return default;
        }

        public async Task<TEntity> PortalGetParentHashTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pid) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _portal_get_parent_hash_token(self, pid):
            // return self.project_id._sign_token(pid)
            */
            return default;
        }

        public async Task<TEntity> PostChatterMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _post_chatter_message(self, body):
            // self.message_post(body=body)
            */
            return default;
        }

        public async Task<TEntity> PostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft) where TEntity : IEntity<Guid>, IPortalMixinable
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
            // :param soft (bool): if True, future documents are not immediately posted,
            //     but are set to be auto posted automatically at the set accounting date.
            //     Nothing will be performed on those documents before the accounting date.
            // :return Model<account.move>: the documents that have been posted
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
            //             validation_msgs.add(_("The field 'Customer' is required, please complete it to validate the Customer Invoice."))
            //         elif invoice.is_purchase_document():
            //             validation_msgs.add(_("The field 'Vendor' is required, please complete it to validate the Vendor Bill."))
            // 
            //     # Handle case when the invoice_date is not set. In that case, the invoice_date is set at today and then,
            //     # lines are recomputed accordingly.
            //     if not invoice.invoice_date:
            //         if invoice.is_sale_document(include_receipts=True):
            //             invoice.invoice_date = fields.Date.context_today(self)
            //         elif invoice.is_purchase_document(include_receipts=True):
            //             validation_msgs.add(_("The Bill/Refund date is required to validate this document."))
            // 
            // for move in self:
            //     if move.state in ['posted', 'cancel']:
            //         validation_msgs.add(_('The entry %(name)s (id %(id)s) must be in draft.', name=move.name, id=move.id))
            //     if not move.line_ids.filtered(lambda line: line.display_type not in ('line_section', 'line_note')):
            //         validation_msgs.add(_('You need to add a line before posting.'))
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
            //     if move.line_ids.account_id.filtered(lambda account: account.deprecated) and not self._context.get('skip_account_deprecation_check'):
            //         validation_msgs.add(_("A line of this move is using a deprecated account, you cannot post it."))
            // 
            //     # If the field autocheck_on_post is set, we want the checked field on the move to be checked
            //     if move.journal_id.autocheck_on_post:
            //         move.checked = move.journal_id.autocheck_on_post
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
            //         move.date = move._get_accounting_date(move.invoice_date or move.date, affects_tax_report, lock_dates=lock_dates)
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
            //         and aml.display_type not in ('line_note', 'line_section')
            //     )
            //     if wrong_lines:
            //         wrong_lines.write({'partner_id': invoice.commercial_partner_id.id})
            // 
            // # reconcile if state is in draft and move has reversal_entry_id set
            // draft_reverse_moves = to_post.filtered(lambda move: move.reversed_entry_id and move.reversed_entry_id.state == 'posted')
            // 
            // to_post.write({
            //     'state': 'posted',
            //     'posted_before': True,
            // })
            // 
            // draft_reverse_moves.reversed_entry_id._reconcile_reversed_moves(draft_reverse_moves, self._context.get('move_reverse_cancel', False))
            // to_post.line_ids._reconcile_marked()
            // 
            // for invoice in to_post:
            //     partner_id = invoice.partner_id
            //     subscribers = [partner_id.id] if partner_id and partner_id not in invoice.sudo().message_partner_ids else None
            //     invoice.message_subscribe(subscribers)
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

        public async Task<TEntity> PrepareAmlValuesListPerNatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareAnalyticAccountDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object prefix) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareCashRoundingBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_rounding_line) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareComboLineUuidsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order_vals) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareConfirmationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareCreditAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _prepare_credit_account_vals(self, company, code, vals):
            // return {
            //     'name': vals.get('name'),
            //     'code': code,
            //     'account_type': 'liability_credit_card',
            //     'currency_id': vals.get('currency_id'),
            //     'company_ids': [Command.link(company.id)],
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentSectionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareDownPaymentSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_down_payment_section_values(self):
            // self.ensure_one()
            // context = {'lang': self.partner_id.lang}
            // res = {
            //     'product_qty': 0.0,
            //     'order_id': self.id,
            //     'display_type': 'line_section',
            //     'is_downpayment': True,
            //     'sequence': (self.order_line[-1:].sequence or 9) + 1,
            //     'name': _("Down Payments"),
            // }
            // del context
            // return res
            */
            return default;
        }

        public async Task<TEntity> PrepareEdiValsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareEpdBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object epd_line) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareEpdBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareGroupedDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfq) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_grouped_data(self, rfq):
            // return (rfq.partner_id.id, rfq.currency_id.id, rfq.dest_address_id.id)
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceAggregatedTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filter_invl_to_apply, object filter_tax_values_to_apply, object grouping_key_generator, object round_from_tax_lines, object postfix_function) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_invoice(self):
            // """Prepare the dict of values to create the new invoice for a purchase order.
            // """
            // self.ensure_one()
            // move_type = self._context.get('default_move_type', 'in_invoice')
            // 
            // partner_invoice = self.env['res.partner'].browse(self.partner_id.address_get(['invoice'])['invoice'])
            // partner_bank_id = self.partner_id.commercial_partner_id.bank_ids.filtered_domain(['|', ('company_id', '=', False), ('company_id', '=', self.company_id.id)])[:1]
            // 
            // invoice_vals = {
            //     'ref': self.partner_ref or '',
            //     'move_type': move_type,
            //     'narration': self.notes,
            //     'currency_id': self.currency_id.id,
            //     'partner_id': partner_invoice.id,
            //     'fiscal_position_id': (self.fiscal_position_id or self.fiscal_position_id._get_fiscal_position(partner_invoice)).id,
            //     'payment_reference': self.partner_ref or '',
            //     'partner_bank_id': partner_bank_id.id,
            //     'invoice_origin': self.name,
            //     'invoice_payment_term_id': self.payment_term_id.id,
            //     'invoice_line_ids': [],
            //     'company_id': self.company_id.id,
            // }
            // return invoice_vals
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

        public async Task<TEntity> PrepareInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareLiquidityAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _prepare_liquidity_account_vals(self, company, code, vals):
            // return {
            //     'name': vals.get('name'),
            //     'code': code,
            //     'account_type': 'asset_cash',
            //     'currency_id': vals.get('currency_id'),
            //     'company_ids': [Command.link(company.id)],
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareMailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PreparePatternGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _prepare_pattern_groups(self):
            // group = self._get_group_pattern()
            // return [
            //     group['tags_and_users'] % '',
            //     group['priority'],
            // ]
            */
            return default;
        }

        public async Task<TEntity> PrepareProductBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_line) where TEntity : IEntity<Guid>, IPortalMixinable
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
            */
            return default;
        }

        public async Task<TEntity> PrepareRefundValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object current_session) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareSupplierInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object line, object price, object currency) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_supplier_info(self, partner, line, price, currency):
            // # Prepare supplierinfo data when adding a product
            // return {
            //     'partner_id': partner.id,
            //     'sequence': max(line.product_id.seller_ids.mapped('sequence')) + 1 if line.product_id.seller_ids else 1,
            //     'min_qty': 1.0,
            //     'price': price,
            //     'currency_id': currency.id,
            //     'discount': line.discount,
            //     'delay': 0,
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxBaseLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareTaxLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_line) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrepareTaxLinesForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_amls, object round_from_tax_lines) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PreviewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> PrintQuotationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def print_quotation(self):
            // self.write({'state': "sent"})
            // return self.env.ref('purchase.report_purchase_quotation').report_action(self)
            */
            return default;
        }

        public async Task<TEntity> ProcessOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object existing_order) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ProcessPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pos_order, object order, object pos_session, object draft) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ProcessReferenceForSaleOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order_reference) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def _process_reference_for_sale_order(self, order_reference):
            // '''
            // returns the order reference to be used for the payment.
            // Hook to be overriden: see l10n_ch for an example.
            // '''
            // self.ensure_one()
            // return order_reference
            */
            return default;
        }

        public async Task<TEntity> ProcessSavedOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object draft) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ProjectSharingToggleIsFollowerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def project_sharing_toggle_is_follower(self):
            // self.ensure_one()
            // self.check_access('write')
            // is_follower = self.message_is_follower
            // if is_follower:
            //     self.sudo().message_unsubscribe(self.env.user.partner_id.ids)
            // else:
            //     self.sudo().message_subscribe(self.env.user.partner_id.ids)
            // return not is_follower
            */
            return default;
        }

        public async Task<TEntity> ProjectUpdateAllActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def project_update_all_action(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_update_all_action')
            // action['display_name'] = _("%(name)s Dashboard", name=self.name)
            // return action
            */
            return default;
        }

        public async Task<TEntity> QuickEditModeSuggestInvoiceDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RatingApplyAsync<TEntity>(IEnumerable<TEntity> entities, object rate, object token, object rating, object feedback, object subtype_xmlid, object notify_delay_send) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def rating_apply(self, rate, token=None, rating=None, feedback=None,
            //              subtype_xmlid=None, notify_delay_send=False):
            // rating = super(Task, self).rating_apply(
            //     rate, token=token, rating=rating, feedback=feedback,
            //     subtype_xmlid=subtype_xmlid, notify_delay_send=notify_delay_send)
            // if self.stage_id and self.stage_id.auto_validation_state:
            //     state = '03_approved' if rating.rating >= rating_data.RATING_LIMIT_SATISFIED else '02_changes_requested'
            //     self.write({'state': state})
            // return rating
            */
            return default;
        }

        public async Task<TEntity> RatingApplyGetDefaultSubtypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_apply_get_default_subtype_id(self):
            // return self.env['ir.model.data']._xmlid_to_res_id("project.mt_task_rating")
            */
            return default;
        }

        public async Task<TEntity> RatingGetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_operator(self):
            // """ Overwrite since we have user_ids and not user_id """
            // tasks_with_one_user = self.filtered(lambda task: len(task.user_ids) == 1 and task.user_ids.partner_id)
            // return tasks_with_one_user.user_ids.partner_id or self.env['res.partner']
            */
            return default;
        }

        public async Task<TEntity> RatingGetParentFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_parent_field_name(self):
            // return 'project_id'
            */
            return default;
        }

        public async Task<TEntity> RatingGetPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _rating_get_partner(self):
            // res = super(Task, self)._rating_get_partner()
            // if not res and self.project_id.partner_id:
            //     return self.project_id.partner_id
            // return res
            */
            return default;
        }

        public async Task<TEntity> ReadGroupAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object groupby, object offset, object limit, object @orderby, object lazy) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def read_group(self, domain, fields, groupby, offset=0, limit=None, orderby=False, lazy=True):
            // # A read_group can not be performed if records are grouped by personal_stage_type_id as it is a computed field.
            // # personal_stage_type_ids behaves like a M2O from the point of view of the user, we therefore use this field instead.
            // if 'personal_stage_type_id' in groupby and (not lazy or groupby[0] == 'personal_stage_type_id'):
            //     groupby = ["personal_stage_type_ids" if field == "personal_stage_type_id" else field for field in groupby] # limitation: problem when both personal_stage_type_id and personal_stage_type_ids appear in read_group, but this has no functional utility
            //     result = super().read_group(domain, fields, groupby, offset, limit, orderby, lazy)
            //     for group in result:
            //         group['personal_stage_type_id'] = group.pop('personal_stage_type_ids', False)
            //         group['personal_stage_type_id_count'] = group.pop('personal_stage_type_ids_count', 0)
            //     return result
            // return super().read_group(domain, fields, groupby, offset, limit, orderby, lazy)
            */
            return default;
        }

        public async Task<TEntity> ReadGroupPersonalStageTypeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group_personal_stage_type_ids(self, stages, domain):
            // return stages.search(['|', ('id', 'in', stages.ids), ('user_id', '=', self.env.user.id)])
            */
            return default;
        }

        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // search_domain = [('id', 'in', stages.ids)]
            // if 'default_project_id' in self.env.context and not self._context.get('subtask_action') and 'project_kanban' in self.env.context:
            //     search_domain = ['|', ('project_ids', '=', self.env.context['default_project_id'])] + search_domain
            // 
            // stage_ids = stages._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        public async Task<TEntity> ReadPosDataAsync<TEntity>(IEnumerable<TEntity> entities, object data, Guid config_id) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RecNamesSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RecomputeCashRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RecomputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RecomputeTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ReconcileReversedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse_moves, object move_reverse_cancel) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RefreshInvoiceCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def refresh_invoice_currency_rate(self):
            // for move in self:
            //     move.invoice_currency_rate = move.expected_currency_rate
            */
            return default;
        }

        public async Task<TEntity> RefundAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RefundInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RefundsOriginRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _refunds_origin_required(self):
            // return False
            */
            return default;
        }

        public async Task<TEntity> RemoveFromUiAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> server_ids) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RequireBillDateForAutopostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RetrieveDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def retrieve_dashboard(self):
            // """ This function returns the values to populate the custom dashboard in
            //     the purchase order views.
            // """
            // self.browse().check_access('read')
            // 
            // result = {
            //     'all_to_send': 0,
            //     'all_waiting': 0,
            //     'all_late': 0,
            //     'my_to_send': 0,
            //     'my_waiting': 0,
            //     'my_late': 0,
            //     'all_avg_order_value': 0,
            //     'all_avg_days_to_purchase': 0,
            //     'all_total_last_7_days': 0,
            //     'all_sent_rfqs': 0,
            //     'company_currency_symbol': self.env.company.currency_id.symbol
            // }
            // 
            // one_week_ago = fields.Datetime.to_string(fields.Datetime.now() - relativedelta(days=7))
            // 
            // query = """SELECT COUNT(1)
            //            FROM mail_message m
            //            JOIN purchase_order po ON (po.id = m.res_id)
            //            WHERE m.create_date >= %s
            //              AND m.model = 'purchase.order'
            //              AND m.message_type = 'notification'
            //              AND m.subtype_id = %s
            //              AND po.company_id = %s;
            //         """
            // 
            // self.env.cr.execute(query, (one_week_ago, self.env.ref('purchase.mt_rfq_sent').id, self.env.company.id))
            // res = self.env.cr.fetchone()
            // result['all_sent_rfqs'] = res[0] or 0
            // 
            // # easy counts
            // po = self.env['purchase.order']
            // result['all_to_send'] = po.search_count([('state', '=', 'draft')])
            // result['my_to_send'] = po.search_count([('state', '=', 'draft'), ('user_id', '=', self.env.uid)])
            // result['all_waiting'] = po.search_count([('state', '=', 'sent'), ('date_order', '>=', fields.Datetime.now())])
            // result['my_waiting'] = po.search_count([('state', '=', 'sent'), ('date_order', '>=', fields.Datetime.now()), ('user_id', '=', self.env.uid)])
            // result['all_late'] = po.search_count([('state', 'in', ['draft', 'sent', 'to approve']), ('date_order', '<', fields.Datetime.now())])
            // result['my_late'] = po.search_count([('state', 'in', ['draft', 'sent', 'to approve']), ('date_order', '<', fields.Datetime.now()), ('user_id', '=', self.env.uid)])
            // 
            // # Calculated values ('avg order value', 'avg days to purchase', and 'total last 7 days') note that 'avg order value' and
            // # 'total last 7 days' takes into account exchange rate and current company's currency's precision.
            // # This is done via SQL for scalability reasons
            // query = """SELECT AVG(COALESCE(po.amount_total / NULLIF(po.currency_rate, 0), po.amount_total)),
            //                   AVG(extract(epoch from age(po.date_approve,po.create_date)/(24*60*60)::decimal(16,2))),
            //                   SUM(CASE WHEN po.date_approve >= %s THEN COALESCE(po.amount_total / NULLIF(po.currency_rate, 0), po.amount_total) ELSE 0 END)
            //            FROM purchase_order po
            //            WHERE po.state in ('purchase', 'done')
            //              AND po.company_id = %s
            //         """
            // self._cr.execute(query, (one_week_ago, self.env.company.id))
            // res = self.env.cr.fetchone()
            // result['all_avg_days_to_purchase'] = round(res[1] or 0, 2)
            // currency = self.env.company.currency_id
            // result['all_avg_order_value'] = format_amount(self.env, res[0] or 0, currency)
            // result['all_total_last_7_days'] = format_amount(self.env, res[2] or 0, currency)
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> ReverseMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_values_list, object cancel) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> RoutingCheckRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object route, object raise_exception) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SELFREADABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return PROJECT_TASK_READABLE_FIELDS | self.SELF_WRITABLE_FIELDS
            */
            return default;
        }

        public async Task<TEntity> SELFWRITABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def SELF_WRITABLE_FIELDS(self):
            // return PROJECT_TASK_WRITABLE_FIELDS
            */
            return default;
        }

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SearchDefaultJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SearchHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_has_late_and_unreached_milestone(self, operator, value):
            // if operator not in ('=', '!=') or not isinstance(value, bool):
            //     raise NotImplementedError(_(
            //         "The search does not support operator %(operator)s or value %(value)s.",
            //         operator=operator,
            //         value=value,
            //     ))
            // domain = [
            //     ('allow_milestones', '=', True),
            //     ('milestone_id', '!=', False),
            //     ('milestone_id.is_reached', '=', False),
            //     ('milestone_id.deadline', '!=', False), ('milestone_id.deadline', '<', fields.Date.today())
            // ]
            // if (operator == '!=' and value) or (operator == '=' and not value):
            //     domain.insert(0, expression.NOT_OPERATOR)
            //     domain = expression.distribute_not(domain)
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchInvoiceIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SearchIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_is_closed(self, operator, value):
            // if operator not in ('=', '!=') or not isinstance(value, bool):
            //     raise NotImplementedError(_(
            //         "The search does not support operator %(operator)s or value %(value)s.",
            //         operator=operator,
            //         value=value,
            //     ))
            // if (operator == '!=' and value) or (operator == '=' and not value):
            //     searched_states = self.OPEN_STATES
            // else:
            //     searched_states = list(CLOSED_STATES.keys())
            // domain = [
            //     ('state', 'in', searched_states)
            // ]
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_favorite(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise NotImplementedError(_('Operation not supported'))
            // return [('favorite_user_ids', 'in' if (operator == '=') == value else 'not in', self.env.uid)]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_milestone_exceeded(self, operator, value):
            // if not isinstance(value, bool):
            //     raise ValueError(_('Invalid value: %s', value))
            // if operator not in ['=', '!=']:
            //     raise ValueError(_('Invalid operator: %s', operator))
            // 
            // sql = SQL("""(
            //     SELECT P.id
            //       FROM project_project P
            //  LEFT JOIN project_milestone M ON P.id = M.project_id
            //      WHERE M.is_reached IS false
            //        AND P.allow_milestones IS true
            //        AND M.deadline <= CAST(now() AS date)
            // )""")
            // if (operator == '=' and value is True) or (operator == '!=' and value is False):
            //     operator_new = 'in'
            // else:
            //     operator_new = 'not in'
            // return [('id', operator_new, sql)]
            */
            return default;
        }

        public async Task<TEntity> SearchJournalGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SearchNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SearchOnComodelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field, object comodel, object additional_domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_on_comodel(self, domain, field, comodel, additional_domain=None):
            // """ This method is called by `group_expand` methods, whose purpose is to add empty groups to the `read_group`
            //     (which otherwise returns groups containing records that match the domain).
            //     When specifically filtering on a comodel's field, the result of the `read_group` should contain all matching groups.
            //     However, if the search isn't filtered on any comodel's field, the result shouldn't be affected,
            //     which explains why we return `False` if `filtered_domain` is empty.
            // 
            //     Returns:
            //         False or recordset of the comodel given in parameter.
            // """
            // def _change_operator(domain):
            //     new_domain = []
            //     for dom in domain:
            //         if len(dom) == 3:
            //             _, op, value = dom
            //             op = "ilike" if op == "child_of" else op
            //             if isinstance(value, list) and all(isinstance(val, int) for val in value):
            //                 new_domain.append(("id", op, value))
            //             if isinstance(value, str) or (isinstance(value, list) and not all(isinstance(val, str) for val in value)):
            //                 new_domain.append(("name", op, value))
            //             if isinstance(value, int):
            //                 if op == "=":
            //                     op = "in"
            //                 if op == "!=":
            //                     op = "not in"
            //                 new_domain.append(("id", op, [value]))
            //         else:
            //             new_domain.append(dom)
            //     return new_domain
            // 
            // filtered_domain = filter_domain_leaf(domain, lambda field_to_check: field_to_check in [
            //     field,
            //     f"{field}.id",
            //     f"{field}.name",
            // ], {
            //     field: "name",
            //     f"{field}.id": "id",
            //     f"{field}.name": "name",
            // })
            // filtered_domain = _change_operator(filtered_domain)
            // if not filtered_domain:
            //     return self.env[comodel]
            // if additional_domain:
            //     filtered_domain = expression.AND([filtered_domain, additional_domain])
            // return self.env[comodel].search(filtered_domain)
            */
            return default;
        }

        public async Task<TEntity> SearchPaidOrderIdsAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object limit, object offset) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SearchPersonalStageTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_personal_stage_type_id(self, operator, value):
            // return [('personal_stage_type_ids', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchPortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _search_portal_user_names(self, operator, value):
            // if operator != 'ilike' and not isinstance(value, str):
            //     raise ValidationError(_('Not Implemented.'))
            // 
            // sql = SQL("""(
            //     SELECT task_user.task_id
            //       FROM project_task_user_rel task_user
            // INNER JOIN res_users users ON task_user.user_id = users.id
            // INNER JOIN res_partner partners ON partners.id = users.partner_id
            //      WHERE partners.name ILIKE %s
            // )""", f"%{value}%")
            // return [('id', 'in', sql)]
            */
            return default;
        }

        public async Task<TEntity> SearchSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SearchTrackingNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SelectExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expected_dates) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _select_expected_date(self, expected_dates):
            // self.ensure_one()
            // return min(expected_dates)
            */
            return default;
        }

        public async Task<TEntity> SendEmailNotifyToCcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to_notify) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _send_email_notify_to_cc(self, partners_to_notify):
            // self.ensure_one()
            // template_id = self.env['ir.model.data']._xmlid_to_res_id('project.task_invitation_follower', raise_if_not_found=False)
            // if not template_id:
            //     return
            // task_model_description = self.env['ir.model']._get(self._name).display_name
            // values = {
            //     'object': self,
            // }
            // for partner in partners_to_notify:
            //     values['partner_name'] = partner.name
            //     assignation_msg = self.env['ir.qweb']._render('project.task_invitation_follower', values, minimal_qcontext=True)
            //     self.message_notify(
            //         subject=_('You have been invited to follow %s', self.display_name),
            //         body=assignation_msg,
            //         partner_ids=partner.ids,
            //         record_name=self.display_name,
            //         email_layout_xmlid='mail.mail_notification_layout',
            //         model_description=task_model_description,
            //         mail_auto_delete=True,
            //     )
            */
            return default;
        }

        public async Task<TEntity> SendOnlyWhenReadyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SendOrderConfirmationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SendOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _send_order(self):
            // # This function is made to be overriden by pos_self_order_preparation_display
            // pass
            */
            return default;
        }

        public async Task<TEntity> SendOrderNotificationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SendPaymentSucceededForOrderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SendRatingAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _send_rating_all(self):
            // projects = self.search([
            //     ('rating_active', '=', True),
            //     ('rating_status', '=', 'periodic'),
            //     ('rating_request_deadline', '<=', fields.Datetime.now())
            // ])
            // for project in projects:
            //     project.task_ids._send_task_rating_mail()
            //     project._compute_rating_request_deadline()
            //     self.env.cr.commit()
            */
            return default;
        }

        public async Task<TEntity> SendReminderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object send_single) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _send_reminder_mail(self, send_single=False):
            // if not self.env.user.has_group('purchase.group_send_reminder'):
            //     return
            // 
            // template = self.env.ref('purchase.email_template_edi_purchase_reminder', raise_if_not_found=False)
            // if template:
            //     orders = self if send_single else self._get_orders_to_remind()
            //     for order in orders:
            //         date = order.date_planned
            //         if date and (send_single or (date - relativedelta(days=order.reminder_date_before_receipt)).date() == datetime.today().date()):
            //             if send_single:
            //                 return order._send_reminder_open_composer(template.id)
            //             else:
            //                 order.with_context(is_reminder=True).message_post_with_source(
            //                     template,
            //                     email_layout_xmlid="mail.mail_notification_layout_with_responsible_signature",
            //                     subtype_xmlid='mail.mt_comment',
            //                 )
            */
            return default;
        }

        public async Task<TEntity> SendReminderOpenComposerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _send_reminder_open_composer(self,template_id):
            // self.ensure_one()
            // try:
            //     compose_form_id = self.env['ir.model.data']._xmlid_lookup('mail.email_compose_message_wizard_form')[1]
            // except ValueError:
            //     compose_form_id = False
            // ctx = dict(self.env.context or {})
            // ctx.update({
            //     'default_model': 'purchase.order',
            //     'default_res_ids': self.ids,
            //     'default_template_id': template_id,
            //     'default_composition_mode': 'comment',
            //     'default_email_layout_xmlid': "mail.mail_notification_layout_with_responsible_signature",
            //     'force_email': True,
            //     'mark_rfq_as_sent': True,
            // })
            // lang = self.env.context.get('lang')
            // if {'default_template_id', 'default_model', 'default_res_id'} <= ctx.keys():
            //     template = self.env['mail.template'].browse(ctx['default_template_id'])
            //     if template and template.lang:
            //         lang = template._render_lang([ctx['default_res_id']])[ctx['default_res_id']]
            // self = self.with_context(lang=lang)
            // ctx['model_description'] = _('Purchase Order')
            // return {
            //     'name': _('Compose Email'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'views': [(compose_form_id, 'form')],
            //     'view_id': compose_form_id,
            //     'target': 'new',
            //     'context': ctx,
            // }
            */
            return default;
        }

        public async Task<TEntity> SendReminderPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def send_reminder_preview(self):
            // self.ensure_one()
            // if not self.env.user.has_group('purchase.group_send_reminder'):
            //     return
            // 
            // template = self.env.ref('purchase.email_template_edi_purchase_reminder', raise_if_not_found=False)
            // if template and self.env.user.email and self.id:
            //     template.with_context(is_reminder=True).send_mail(
            //         self.id,
            //         force_send=True,
            //         raise_exception=False,
            //         email_layout_xmlid="mail.mail_notification_layout_with_responsible_signature",
            //         email_values={'email_to': self.env.user.email, 'recipient_ids': []},
            //     )
            //     return {'toast_message': escape(_("A sample email has been sent to %s.", self.env.user.email))}
            */
            return default;
        }

        public async Task<TEntity> SendTaskRatingMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_send) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _send_task_rating_mail(self, force_send=False):
            // for task in self:
            //     rating_template = task.stage_id.rating_template_id
            //     partner = task.partner_id
            //     if rating_template and partner and partner != self.env.user.partner_id:
            //         task.rating_send_request(rating_template, lang=task.partner_id.lang, force_send=force_send)
            */
            return default;
        }

        public async Task<TEntity> SequenceFixedRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_fixed_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_fixed_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_monthly_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_monthly_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_yearly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_yearly_regex
            */
            return default;
        }

        public async Task<TEntity> SetBankAccountAsync<TEntity>(IEnumerable<TEntity> entities, object acc_number, Guid bank_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def set_bank_account(self, acc_number, bank_id=None):
            // """ Create a res.partner.bank (if not exists) and set it as value of the field bank_account_id """
            // self.ensure_one()
            // res_partner_bank = self.env['res.partner.bank'].search([
            //     ('sanitized_acc_number', '=', sanitize_account_number(acc_number)),
            //     ('partner_id', '=', self.company_id.partner_id.id),
            // ], limit=1)
            // if res_partner_bank:
            //     self.bank_account_id = res_partner_bank.id
            // else:
            //     self.bank_account_id = self.env['res.partner.bank'].create({
            //         'acc_number': acc_number,
            //         'bank_id': bank_id,
            //         'currency_id': self.currency_id.id,
            //         'partner_id': self.company_id.partner_id.id,
            //         'journal_id': self,
            //     }).id
            */
            return default;
        }

        public async Task<TEntity> SetFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_favorite) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _set_favorite_user_ids(self, is_favorite):
            // self_sudo = self.sudo() # To allow project users to set projects as favorite
            // if is_favorite:
            //     self_sudo.favorite_user_ids = [Command.link(self.env.uid)]
            // else:
            //     self_sudo.favorite_user_ids = [Command.unlink(self.env.uid)]
            */
            return default;
        }

        public async Task<TEntity> SetNextMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities, bool made_gap) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SetReversedEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credit_note) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SetStageOnProjectFromTaskInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _set_stage_on_project_from_task(self):
            // stage_ids_per_project = defaultdict(list)
            // for task in self:
            //     if task.stage_id and task.stage_id not in task.project_id.type_ids and task.stage_id.id not in stage_ids_per_project[task.project_id]:
            //         stage_ids_per_project[task.project_id].append(task.stage_id.id)
            // 
            // for project, stage_ids in stage_ids_per_project.items():
            //     project.write({'type_ids': [Command.link(stage_id) for stage_id in stage_ids]})
            */
            return default;
        }

        public async Task<TEntity> ShouldBeLockedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ShouldCreatePickingRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _should_create_picking_real_time(self):
            // return not self.session_id.update_stock_at_closing or (self.company_id.anglo_saxon_accounting and self.to_invoice)
            */
            return default;
        }

        public async Task<TEntity> ShowAutopostBillsWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ShowCancelWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ShowProfitabilityHelperInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability_helper(self):
            // return self.env.user.has_group('analytic.group_analytic_accounting')
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability(self):
            // self.ensure_one()
            // return True
            */
            return default;
        }

        public async Task<TEntity> StageFindAsync<TEntity>(IEnumerable<TEntity> entities, Guid section_id, object domain, object order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def stage_find(self, section_id, domain=[], order='sequence, id'):
            // """ Override of the base.stage method
            //     Parameter of the stage search taken from the lead:
            //     - section_id: if set, stages must belong to this section or
            //       be a default stage; if not set, stages must be default
            //       stages
            // """
            // # collect all section_ids
            // section_ids = []
            // if section_id:
            //     section_ids.append(section_id)
            // section_ids.extend(self.mapped('project_id').ids)
            // search_domain = []
            // if section_ids:
            //     search_domain = [('|')] * (len(section_ids) - 1)
            //     for section_id in section_ids:
            //         search_domain.append(('project_ids', '=', section_id))
            // search_domain += list(domain)
            // # perform search, return the first found
            // return self.env['project.task.type'].search(search_domain, order=order, limit=1).id
            */
            return default;
        }

        public async Task<TEntity> StolenMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SyncDynamicLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object existing_key_fname, object needed_vals_fname, object needed_dirty_fname, object line_type, object container) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SyncDynamicLineNeededValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SyncDynamicLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SyncFromUiAsync<TEntity>(IEnumerable<TEntity> entities, object orders) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SyncInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SyncRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SyncTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SyncUnbalancedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> SynchronizeBusinessModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changed_fields) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> TaskMessageAutoSubscribeNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users_per_task) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _task_message_auto_subscribe_notify(self, users_per_task):
            // if self.env.context.get('mail_auto_subscribe_no_notify'):
            //     return
            // # Utility method to send assignation notification upon writing/creation.
            // template_id = self.env['ir.model.data']._xmlid_to_res_id('project.project_message_user_assigned', raise_if_not_found=False)
            // if not template_id:
            //     return
            // task_model_description = self.env['ir.model']._get(self._name).display_name
            // for task, users in users_per_task.items():
            //     if not users:
            //         continue
            //     values = {
            //         'object': task,
            //         'model_description': task_model_description,
            //         'access_link': task._notify_get_action_link('view'),
            //     }
            //     for user in users:
            //         values.update(assignee_name=user.sudo().name)
            //         assignation_msg = self.env['ir.qweb']._render('project.project_message_user_assigned', values, minimal_qcontext=True)
            //         assignation_msg = self.env['mail.render.mixin']._replace_local_links(assignation_msg)
            //         task.message_notify(
            //             subject=_('You have been assigned to %s', task.display_name),
            //             body=assignation_msg,
            //             partner_ids=user.partner_id.ids,
            //             record_name=task.display_name,
            //             email_layout_xmlid='mail.mail_notification_layout',
            //             model_description=task_model_description,
            //             mail_auto_delete=False,
            //         )
            */
            return default;
        }

        protected async Task<object> ThreadToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _thread_to_store(self, store: Store, /, *, request_list=None, **kwargs):
            // super()._thread_to_store(store, request_list=request_list, **kwargs)
            // if request_list and "followers" in request_list:
            //     store.add(
            //         self,
            //         {"collaborator_ids": Store.many(self.collaborator_ids.partner_id, only_id=True)},
            //         as_thread=True,
            //     )
            */
            return default;
        }

        public async Task<TEntity> ToggleFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def toggle_favorite(self):
            // favorite_projects = not_fav_projects = self.env['project.project'].sudo()
            // for project in self:
            //     if self.env.user in project.favorite_user_ids:
            //         favorite_projects |= project
            //     else:
            //         not_fav_projects |= project
            // 
            // # Project User has no write access for project.
            // not_fav_projects.write({'favorite_user_ids': [(4, self.env.uid)]})
            // favorite_projects.write({'favorite_user_ids': [(3, self.env.uid)]})
            */
            return default;
        }

        public async Task<TEntity> TrackFinalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IPortalMixinable
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
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values:
            //     return self.env.ref('project.mt_project_stage_change')
            // return super()._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // mail_message_subtype_per_state = {
            //     '1_done': 'project.mt_task_done',
            //     '1_canceled': 'project.mt_task_canceled',
            //     '01_in_progress': 'project.mt_task_in_progress',
            //     '03_approved': 'project.mt_task_approved',
            //     '02_changes_requested': 'project.mt_task_changes_requested',
            //     '04_waiting_normal': 'project.mt_task_waiting',
            // }
            // 
            // if 'stage_id' in init_values:
            //     return self.env.ref('project.mt_task_stage')
            // elif 'state' in init_values and self.state in mail_message_subtype_per_state:
            //     return self.env.ref(mail_message_subtype_per_state[self.state])
            // return super(Task, self)._track_subtype(init_values)
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'state' in init_values and self.state == 'purchase':
            //     if init_values['state'] == 'to approve':
            //         return self.env.ref('purchase.mt_rfq_approved')
            //     return self.env.ref('purchase.mt_rfq_confirmed')
            // elif 'state' in init_values and self.state == 'to approve':
            //     return self.env.ref('purchase.mt_rfq_confirmed')
            // elif 'state' in init_values and self.state == 'done':
            //     return self.env.ref('purchase.mt_rfq_done')
            // elif 'state' in init_values and self.state == 'sent':
            //     return self.env.ref('purchase.mt_rfq_sent')
            // return super(PurchaseOrder, self)._track_subtype(init_values)
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

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _track_template(self, changes):
            // res = super()._track_template(changes)
            // project = self[0]
            // if self.env.user.has_group('project.group_project_stages') and 'stage_id' in changes and project.stage_id.mail_template_id:
            //     res['stage_id'] = (project.stage_id.mail_template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'mail.mail_notification_light',
            //     })
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _track_template(self, changes):
            // res = super(Task, self)._track_template(changes)
            // test_task = self[0]
            // if 'stage_id' in changes and test_task.stage_id.mail_template_id:
            //     res['stage_id'] = (test_task.stage_id.mail_template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'mail.mail_notification_light'
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkAccountAuditTrailExceptOncePostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def unlink(self):
            // bank_accounts = self.env['res.partner.bank'].browse()
            // for bank_account in self.mapped('bank_account_id'):
            //     accounts = self.search([('bank_account_id', '=', bank_account.id)])
            //     if accounts <= self:
            //         bank_accounts += bank_account
            // self.env['account.payment.method.line'].search([('journal_id', 'in', self.ids)]).unlink()
            // ret = super(AccountJournal, self).unlink()
            // bank_accounts.unlink()
            // return ret
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def unlink(self):
            // self._set_next_made_sequence_gap(True)
            // self = self.with_context(skip_invoice_sync=True, dynamic_unlink=True)  # no need to sync to delete everything
            // logger_message = self._get_unlink_logger_message()
            // self.line_ids.unlink()
            // res = super().unlink()
            // if logger_message:
            //     _logger.info(logger_message)
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def unlink(self):
            // # Delete the empty related analytic account
            // analytic_accounts_to_delete = self.env['account.analytic.account']
            // for project in self:
            //     if project.account_id and not project.account_id.line_ids:
            //         analytic_accounts_to_delete |= project.account_id
            // self.with_context(active_test=False).tasks.unlink()
            // result = super(Project, self).unlink()
            // analytic_accounts_to_delete.unlink()
            // return result
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def unlink(self):
            // # Add subtasks to batch of tasks to delete
            // self |= self._get_all_subtasks()
            // last_task_id_per_recurrence_id = self.recurrence_id._get_last_task_id_per_recurrence_id()
            // for task in self:
            //     if task.id == last_task_id_per_recurrence_id.get(task.recurrence_id.id):
            //         task.recurrence_id.unlink()
            // return super().unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDraftOrCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py) ---
            // def _unlink_except_draft_or_cancel(self):
            // for pos_order in self.filtered(lambda pos_order: pos_order.state not in ['draft', 'cancel']):
            //     raise UserError(_('In order to delete a sale, it must be new or cancelled.'))
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

        public async Task<TEntity> UnlinkForbidPartsOfChainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> UnlinkIfCancelledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _unlink_if_cancelled(self):
            // for order in self:
            //     if not order.state == 'cancel':
            //         raise UserError(_('In order to delete a purchase order, you must cancel it first.'))
            */
            return default;
        }

        public async Task<TEntity> UnlinkOrReverseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> UnsubscribePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def _unsubscribe_portal_users(self):
            // self.message_unsubscribe(partner_ids=self.message_partner_ids.filtered('user_ids.share').ids)
            */
            return default;
        }

        public async Task<TEntity> UpdateDateEndAsync<TEntity>(IEnumerable<TEntity> entities, Guid stage_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def update_date_end(self, stage_id):
            // project_task_type = self.env['project.task.type'].browse(stage_id)
            // if project_task_type.fold:
            //     return {'date_end': fields.Datetime.now()}
            // return {'date_end': False}
            */
            return default;
        }

        public async Task<TEntity> UpdateDatePlannedForLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _update_date_planned_for_lines(self, updated_dates):
            // # create or update the activity
            // activity = self.env['mail.activity'].search([
            //     ('summary', '=', _('Date Updated')),
            //     ('res_model_id', '=', 'purchase.order'),
            //     ('res_id', '=', self.id),
            //     ('user_id', '=', self.user_id.id)], limit=1)
            // if activity:
            //     self._update_update_date_activity(updated_dates, activity)
            // else:
            //     self._create_update_date_activity(updated_dates)
            // 
            // # update the date on PO line
            // for line, date in updated_dates:
            //     line._update_date_planned(date)
            */
            return default;
        }

        public async Task<TEntity> UpdateOrderLineInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _update_order_line_info(self, product_id, quantity, **kwargs):
            // """ Update account_move_line information for a given product or create a
            // new one if none exists yet.
            // :param int product_id: The product, as a `product.product` id.
            // :param int quantity: The quantity selected in the catalog
            // :return: The unit price of the product, based on the pricelist of the
            //          sale order and the quantity selected.
            // :rtype: float
            // """
            // move_line = self.line_ids.filtered(lambda line: line.product_id.id == product_id)
            // if move_line:
            //     if quantity != 0:
            //         move_line.quantity = quantity
            //     elif self.state in {'draft', 'sent'}:
            //         price_unit = self._get_product_price_and_data(move_line.product_id)['price']
            //         # The catalog is designed to allow the user to select products quickly.
            //         # Therefore, sometimes they may select the wrong product or decide to remove
            //         # some of them from the quotation. The unlink is there for that reason.
            //         move_line.unlink()
            //         return price_unit
            //     else:
            //         move_line.quantity = 0
            // elif quantity > 0:
            //     move_line = self.env['account.move.line'].create({
            //         'move_id': self.id,
            //         'quantity': quantity,
            //         'product_id': product_id,
            //     })
            // return move_line.price_unit
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _update_order_line_info(self, product_id, quantity, **kwargs):
            // """ Update purchase order line information for a given product or create
            // a new one if none exists yet.
            // :param int product_id: The product, as a `product.product` id.
            // :return: The unit price of the product, based on the pricelist of the
            //          purchase order and the quantity selected.
            // :rtype: float
            // """
            // self.ensure_one()
            // product_packaging_qty = kwargs.get('product_packaging_qty', False)
            // product_packaging_id = kwargs.get('product_packaging_id', False)
            // pol = self.order_line.filtered(lambda line: line.product_id.id == product_id)
            // if pol:
            //     if product_packaging_qty:
            //         pol.product_packaging_id = product_packaging_id
            //         pol.product_packaging_qty = product_packaging_qty
            //     elif quantity != 0:
            //         pol.product_qty = quantity
            //     elif self.state in ['draft', 'sent']:
            //         price_unit = self._get_product_price_and_data(pol.product_id)['price']
            //         pol.unlink()
            //         return price_unit
            //     else:
            //         pol.product_qty = 0
            // elif quantity > 0:
            //     pol = self.env['purchase.order.line'].create({
            //         'order_id': self.id,
            //         'product_id': product_id,
            //         'product_qty': quantity,
            //         'sequence': ((self.order_line and self.order_line[-1].sequence + 1) or 10),  # put it at the end of the order
            //     })
            //     seller = pol.product_id._select_seller(
            //         partner_id=pol.partner_id,
            //         quantity=pol.product_qty,
            //         date=pol.order_id.date_order and pol.order_id.date_order.date() or fields.Date.context_today(pol),
            //         uom_id=pol.product_uom)
            //     if seller:
            //         # Fix the PO line's price on the seller's one.
            //         pol.price_unit = seller.price_discounted
            // return pol.price_unit_discounted
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

        public async Task<TEntity> UpdateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates, object activity) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _update_update_date_activity(self, updated_dates, activity):
            // for line, date in updated_dates:
            //     activity.note += Markup('<p> - %s</p>\n') %  _(
            //         '%(product)s from %(original_receipt_date)s to %(new_receipt_date)s',
            //         product=line.product_id.display_name,
            //         original_receipt_date=line.date_planned.date(),
            //         new_receipt_date=date.date()
            //     )
            */
            return default;
        }

        public async Task<TEntity> ValidateOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> ValidateTaxesCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
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

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def write(self, vals):
            // # for journals, force a readable name instead of a sanitized name e.g. non ascii in journal names
            // if vals.get('alias_name') and 'type' not in vals:
            //     # will raise if writing name on more than 1 record, using self[0] is safe
            //     if (not self.env['mail.alias']._is_encodable(vals['alias_name']) or
            //         not self.env['mail.alias']._sanitize_alias_name(vals['alias_name'])):
            //         vals['alias_name'] = self._alias_prepare_alias_name(
            //             False, vals.get('name', self.name), vals.get('code', self.code), self[0].type, self[0].company_id)
            // 
            // for journal in self:
            //     company = journal.company_id
            //     if ('company_id' in vals and journal.company_id.id != vals['company_id']):
            //         company = self.env['res.company'].browse(vals['company_id'])
            //         if journal.bank_account_id.company_id and journal.bank_account_id.company_id != company:
            //             journal.bank_account_id.write({
            //                 'company_id': company.id,
            //                 'partner_id': company.partner_id.id,
            //             })
            //     if 'currency_id' in vals:
            //         if journal.bank_account_id:
            //             journal.bank_account_id.currency_id = vals['currency_id']
            //     if 'bank_account_id' in vals:
            //         if vals.get('bank_account_id'):
            //             bank_account = self.env['res.partner.bank'].browse(vals['bank_account_id'])
            //             if bank_account.partner_id != company.partner_id:
            //                 raise UserError(_("The partners of the journal's company and the related bank account mismatch."))
            //     if 'restrict_mode_hash_table' in vals and not vals.get('restrict_mode_hash_table'):
            //         domain = self.env['account.move']._get_move_hash_domain(
            //             common_domain=[('journal_id', '=', journal.id), ('inalterable_hash', '!=', False)]
            //         )
            //         journal_entry = self.env['account.move'].sudo().search_count(domain, limit=1)
            //         if journal_entry:
            //             field_string = self._fields['restrict_mode_hash_table'].get_description(self.env)['string']
            //             raise UserError(_("You cannot modify the field %s of a journal that already has accounting entries.", field_string))
            // result = super(AccountJournal, self).write(vals)
            // 
            // # Ensure alias coherency when changing type
            // if 'type' in vals and not self._context.get('account_journal_skip_alias_sync'):
            //     for journal in self:
            //         alias_vals = journal._alias_get_creation_values()
            //         alias_vals = {
            //             'alias_defaults': alias_vals['alias_defaults'],
            //             'alias_name': alias_vals['alias_name'],
            //         }
            //         journal.update(alias_vals)
            // 
            // # Ensure the liquidity accounts are sharing the same foreign currency.
            // if 'currency_id' in vals:
            //     for journal in self.filtered(lambda journal: journal.type in ('bank', 'cash', 'credit')):
            //         journal.default_account_id.currency_id = journal.currency_id
            // 
            // # Create the bank_account_id if necessary
            // if 'bank_acc_number' in vals:
            //     for journal in self.filtered(lambda r: r.type == 'bank' and not r.bank_account_id):
            //         journal.set_bank_account(vals.get('bank_acc_number'), vals.get('bank_id'))
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def write(self, vals):
            // if not vals:
            //     return True
            // self._sanitize_vals(vals)
            // 
            // for move in self:
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
            //     if not self._context.get('skip_readonly_check') and move_state == "posted" and readonly_fields:
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
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def write(self, vals):
            // if vals.get('access_token'):
            //     self.ensure_one()  # We are not supposed to add a single access token to multiple project
            //     if self.privacy_visibility != 'portal':
            //         vals['access_token'] = ''
            // 
            // # Here we modify the project's stage according to the selected company (selecting the first
            // # stage in sequence that is linked to the company).
            // company_id = vals.get('company_id')
            // if self.env.user.has_group('project.group_project_stages') and company_id:
            //     projects_already_with_company = self.filtered(lambda p: p.company_id.id == company_id)
            //     if projects_already_with_company:
            //         projects_already_with_company.write({key: value for key, value in vals.items() if key != 'company_id'})
            //         self -= projects_already_with_company
            //     if company_id not in (None, *self.company_id.ids) and self.stage_id.company_id:
            //         ProjectStage = self.env['project.project.stage']
            //         vals["stage_id"] = ProjectStage.search(
            //             [('company_id', 'in', (company_id, False))],
            //             order=f"sequence asc, {ProjectStage._order}",
            //             limit=1,
            //         ).id
            // 
            // # directly compute is_favorite to dodge allow write access right
            // if 'is_favorite' in vals:
            //     self._set_favorite_user_ids(vals.pop('is_favorite'))
            // 
            // if 'last_update_status' in vals and vals['last_update_status'] != 'to_define':
            //     for project in self:
            //         # This does not benefit from multi create, this is to allow the default description from being built.
            //         # This does seem ok since last_update_status should only be updated on one record at once.
            //         self.env['project.update'].with_context(default_project_id=project.id).create({
            //             'name': _('Status Update - %(date)s', date=fields.Date.today().strftime(get_lang(self.env).date_format)),
            //             'status': vals.get('last_update_status'),
            //         })
            //     vals.pop('last_update_status')
            // if vals.get('privacy_visibility'):
            //     self._change_privacy_visibility(vals['privacy_visibility'])
            // 
            // date_start = vals.get('date_start', True)
            // date_end = vals.get('date', True)
            // if not date_start or not date_end:
            //     vals['date_start'] = False
            //     vals['date'] = False
            // else:
            //     no_current_date_begin = not all(project.date_start for project in self)
            //     no_current_date_end = not all(project.date for project in self)
            //     date_start_update = 'date_start' in vals
            //     date_end_update = 'date' in vals
            //     if (date_start_update and no_current_date_end and not date_end_update):
            //         del vals['date_start']
            //     elif (date_end_update and no_current_date_begin and not date_start_update):
            //         del vals['date']
            // 
            // res = super(Project, self).write(vals) if vals else True
            // 
            // if 'allow_task_dependencies' in vals and not vals.get('allow_task_dependencies'):
            //     self.env['project.task'].search([('project_id', 'in', self.ids), ('state', '=', '04_waiting_normal')]).write({'state': '01_in_progress'})
            // 
            // if 'active' in vals:
            //     # archiving/unarchiving a project does it on its tasks, too
            //     self.with_context(active_test=False).mapped('tasks').write({'active': vals['active']})
            // if 'name' in vals and self.account_id:
            //     projects_read_group = self.env['project.project']._read_group(
            //         [('account_id', 'in', self.account_id.ids)],
            //         ['account_id'],
            //         having=[('__count', '=', 1)],
            //     )
            //     analytic_account_to_update = self.env['account.analytic.account'].browse([
            //         analytic_account.id for [analytic_account] in projects_read_group
            //     ])
            //     analytic_account_to_update.write({'name': self.name})
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_task.py) ---
            // def write(self, vals):
            // if len(self) == 1:
            //     handle_history_divergence(self, 'description', vals)
            // portal_can_write = False
            // project_link_per_task_id = {}
            // partner_ids = []
            // if self.env.user._is_portal() and not self.env.su:
            //     # Check if all fields in vals are in SELF_WRITABLE_FIELDS
            //     self._ensure_fields_are_accessible(vals.keys(), operation='write', check_group_user=False)
            //     self.check_access('write')
            //     portal_can_write = True
            // 
            // if 'milestone_id' in vals:
            //     # WARNING: has to be done after 'project_id' vals is written on subtasks
            //     milestone = self.env['project.milestone'].browse(vals['milestone_id'])
            // 
            //     # 1. Task for which the milestone is unvalid -> milestone_id is reset
            //     if 'project_id' not in vals:
            //         unvalid_milestone_tasks = self.filtered(lambda task: task.project_id != milestone.project_id) if vals['milestone_id'] else self.env['project.task']
            //     else:
            //         unvalid_milestone_tasks = self if not vals['milestone_id'] or milestone.project_id.id != vals['project_id'] else self.env['project.task']
            //     valid_milestone_tasks = self - unvalid_milestone_tasks
            //     if unvalid_milestone_tasks:
            //         unvalid_milestone_tasks.write({'milestone_id': False})
            //         if valid_milestone_tasks:
            //             valid_milestone_tasks.write({'milestone_id': vals['milestone_id']})
            //         del vals['milestone_id']
            // 
            //     # 2. Parent's milestone is set to subtask with no milestone recursively
            //     subtasks_to_update = valid_milestone_tasks.child_ids.filtered(
            //         lambda task: (task not in self and \
            //                       not task.milestone_id and \
            //                       task.project_id == milestone.project_id and \
            //                       task.state not in CLOSED_STATES))
            // 
            //     # 3. If parent and child task share the same milestone, child task's milestone is updated when the parent one is changed
            //     # No need to check if state is changed in vals as it won't affect the subtasks selected for update
            //     if 'project_id' not in vals:
            //         subtasks_to_update |= valid_milestone_tasks.child_ids.filtered(
            //             lambda task: (task not in self and \
            //                           task.milestone_id == task.parent_id.milestone_id and \
            //                           task.state not in CLOSED_STATES))
            //     else:
            //         subtasks_to_update |= valid_milestone_tasks.child_ids.filtered(
            //             lambda task: (task not in self and \
            //                           (not task.display_in_project or task.project_id.id == vals['project_id']) and \
            //                           task.milestone_id == task.parent_id.milestone_id  and \
            //                           task.state not in CLOSED_STATES))
            //     if subtasks_to_update:
            //         subtasks_to_update.write({'milestone_id': vals['milestone_id']})
            // 
            // if vals.get('parent_id') in self.ids:
            //     raise UserError(_("Sorry. You can't set a task as its parent task."))
            // 
            // # stage change: update date_last_stage_update
            // now = fields.Datetime.now()
            // if 'stage_id' in vals:
            //     if not 'project_id' in vals and self.filtered(lambda t: not t.project_id):
            //         raise UserError(_('You can only set a personal stage on a private task.'))
            // 
            //     vals.update(self.update_date_end(vals['stage_id']))
            //     vals['date_last_stage_update'] = now
            // task_ids_without_user_set = set()
            // if 'user_ids' in vals and 'date_assign' not in vals:
            //     # prepare update of date_assign after super call
            //     task_ids_without_user_set = {task.id for task in self if not task.user_ids}
            // 
            // # recurrence fields
            // rec_fields = vals.keys() & self._get_recurrence_fields()
            // if rec_fields:
            //     rec_values = {rec_field: vals[rec_field] for rec_field in rec_fields}
            //     for task in self:
            //         if task.recurrence_id:
            //             task.recurrence_id.write(rec_values)
            //         elif vals.get('recurring_task'):
            //             recurrence = self.env['project.task.recurrence'].create(rec_values)
            //             task.recurrence_id = recurrence.id
            // 
            // if not vals.get('recurring_task', True) and self.recurrence_id:
            //     tasks_in_recurrence = self.recurrence_id.task_ids
            //     self.recurrence_id.unlink()
            //     tasks_in_recurrence.write({'recurring_task': False})
            // 
            // # The sudo is required for a portal user as the record update
            // # requires the write access on others models, as rating.rating
            // # in order to keep the same name than the task.
            // if portal_can_write:
            //     self_no_sudo, self = self, self.sudo().with_context(self._get_portal_sudo_context())
            //     vals_no_sudo, vals = self._get_portal_sudo_vals(vals)
            // 
            // # Track user_ids to send assignment notifications
            // old_user_ids = {t: t.user_ids for t in self.sudo()}
            // 
            // if "personal_stage_type_id" in vals and not vals['personal_stage_type_id']:
            //     del vals['personal_stage_type_id']
            // 
            // # sends an email to the 'Task Creation' subtype subscribers
            // # When project_id is changed
            // if vals.get('project_id'):
            //     project = self.env['project.project'].browse(vals.get('project_id'))
            //     notification_subtype_id = self.env['ir.model.data']._xmlid_to_res_id('project.mt_project_task_new')
            //     partner_ids = project.message_follower_ids.filtered(lambda follower: notification_subtype_id in follower.subtype_ids.ids).partner_id.ids
            //     if partner_ids:
            //         link_per_project_id = {}
            //         for task in self:
            //             if task.project_id:
            //                 project_link = link_per_project_id.get(task.project_id.id)
            //                 if not project_link:
            //                     project_link = link_per_project_id[task.project_id.id] = task.project_id._get_html_link(title=task.project_id.display_name)
            //                 project_link_per_task_id[task.id] = project_link
            // if vals.get('parent_id') is False:
            //     vals['display_in_project'] = True
            // result = super().write(vals)
            // if portal_can_write:
            //     super(Task, self_no_sudo).write(vals_no_sudo)
            // 
            // if 'user_ids' in vals:
            //     self._populate_missing_personal_stages()
            // 
            // # user_ids change: update date_assign
            // if 'user_ids' in vals:
            //     for task in self:
            //         if not task.user_ids and task.date_assign:
            //             task.date_assign = False
            //         elif 'date_assign' not in vals and task.id in task_ids_without_user_set:
            //             task.date_assign = now
            // 
            // # rating on stage
            // if 'stage_id' in vals and vals.get('stage_id'):
            //     self.filtered(lambda x: x.project_id.rating_active and x.project_id.rating_status == 'stage')._send_task_rating_mail(force_send=True)
            // 
            // if 'state' in vals:
            //     # specific use case: when the blocked task goes from 'forced' done state to a not closed state, we fix the state back to waiting
            //     for task in self:
            //         if task.allow_task_dependencies:
            //             if task.is_blocked_by_dependences() and vals['state'] not in CLOSED_STATES and vals['state'] != '04_waiting_normal':
            //                 task.state = '04_waiting_normal'
            //         task.date_last_stage_update = now
            // elif 'project_id' in vals:
            //     self.filtered(lambda t: t.state != '04_waiting_normal').state = '01_in_progress'
            // 
            // self._task_message_auto_subscribe_notify({task: task.user_ids - old_user_ids[task] - self.env.user for task in self})
            // 
            // if partner_ids:
            //     for task in self:
            //         project_link = project_link_per_task_id.get(task.id)
            //         if project_link:
            //             body = _(
            //                 'Task Transferred from Project %(source_project)s to %(destination_project)s',
            //                 source_project=project_link,
            //                 destination_project=self.project_id._get_html_link(title=self.project_id.display_name),
            //             )
            //         else:
            //             body = _('Task Converted from To-Do')
            //         task.message_notify(
            //             body=body,
            //             partner_ids=partner_ids,
            //             email_layout_xmlid='mail.mail_notification_layout',
            //             record_name=task.display_name,
            //        )
            // return result
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def write(self, vals):
            // vals, partner_vals = self._write_partner_values(vals)
            // res = super().write(vals)
            // if partner_vals:
            //     self.partner_id.sudo().write(partner_vals)  # Because the purchase user doesn't have write on `res.partner`
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

        public async Task<TEntity> WritePartnerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _write_partner_values(self, vals):
            // partner_values = {}
            // if 'receipt_reminder_email' in vals:
            //     partner_values['receipt_reminder_email'] = vals.pop('receipt_reminder_email')
            // if 'reminder_date_before_receipt' in vals:
            //     partner_values['reminder_date_before_receipt'] = vals.pop('reminder_date_before_receipt')
            // return vals, partner_values
            */
            return default;
        }

        public async Task<TEntity> _ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object count_field, object additional_domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def __compute_task_count(self, count_field='task_count', additional_domain=None):
            // count_fields = {fname for fname in self._fields if 'count' in fname}
            // if count_field not in count_fields:
            //     raise ValueError(f"Parameter 'count_field' can only be one of {count_fields}, got {count_field} instead.")
            // domain = [('project_id', 'in', self.ids), ('display_in_project', '=', True)]
            // if additional_domain:
            //     domain = AND([domain, additional_domain])
            // tasks_count_by_project = dict(self.env['project.task'].with_context(
            //     active_test=any(project.active for project in self)
            // )._read_group(domain, ['project_id'], ['__count']))
            // for project in self:
            //     project.update({count_field: tasks_count_by_project.get(project, 0)})
            */
            return default;
        }

        public async Task<TEntity> _GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_journal.py) ---
            // def __get_bank_statements_available_sources(self):
            // return [('undefined', _('Undefined Yet'))]
            */
            return default;
        }
    }
}