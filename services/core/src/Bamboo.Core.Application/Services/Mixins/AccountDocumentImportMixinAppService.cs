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
    [Module("account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountDocumentImportMixinAppService : ApplicationService, IAccountDocumentImportMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountDocumentImportMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionAcknowledgeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_acknowledge(self):
            // self.acknowledged = True
            */
            return default;
        }

        public async Task<TEntity> ActionActivateCurrencyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_activate_currency(self):
            // self.currency_id.filtered(lambda currency: not currency.active).write({'active': True})
            */
            return default;
        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def action_add_from_catalog(self):
            // res = super().action_add_from_catalog()
            // res['search_view_id'] = [self.env.ref('account.product_view_search_catalog').id, 'search']
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_add_from_catalog(self):
            // res = super().action_add_from_catalog()
            // kanban_view_id = self.env.ref('purchase.product_view_kanban_catalog_purchase_only').id
            // res['views'][0] = (kanban_view_id, 'kanban')
            // res['search_view_id'] = [self.env.ref('purchase.product_view_search_catalog').id, 'search']
            // res['context']['partner_id'] = self.partner_id.id
            // return res
            */
            return default;
        }

        public async Task<TEntity> ActionBillMatchingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            //         ('partner_id', 'in', (self.partner_id | self.partner_id.commercial_partner_id).ids),
            //         ('company_id', 'in', self.env.company.ids),
            //         ('purchase_order_id', 'in', [self.id, False]),
            //     ],
            //     'views': [(self.env.ref('purchase.purchase_bill_line_match_tree').id, 'list')],
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_cancel(self):
            // """ Cancel sales order and related draft invoices. """
            // if any(order.locked for order in self):
            //     raise UserError(_("You cannot cancel a locked order. Please unlock it first."))
            // return self._action_cancel()
            */
            return default;
        }

        public async Task<TEntity> ActionCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            // self.write(self._prepare_confirmation_values())
            // 
            // # Context key 'default_name' is sometimes propagated up to here.
            // # We don't need it and it creates issues in the creation of linked records.
            // context = self.env.context.copy()
            // context.pop('default_name', None)
            // context.pop('default_user_id', None)
            // 
            // self.with_context(context)._action_confirm()
            // self.filtered(lambda so: so._should_be_locked()).action_lock()
            // 
            // if self.env.context.get('send_email'):
            //     self._send_order_confirmation_mail()
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _action_confirm(self):
            // """ Implementation of additional mechanism of Sales Order confirmation.
            //     This method should be extended when the confirmation should generated
            //     other documents. In this method, the SO are in 'sale' state (not yet 'done').
            // """
            */
            return default;
        }

        public async Task<TEntity> ActionCreateInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_create_invoice(self, attachment_ids=False):
            // """Create the invoice associated to the PO.
            // """
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
            // 
            // # 1) Prepare invoice vals and clean-up the section lines
            // invoice_vals_list = []
            // sequence = 10
            // for order in self:
            //     order = order.with_company(order.company_id)
            //     pending_section = None
            //     # Invoice values.
            //     invoice_vals = order._prepare_invoice()
            //     # Invoice line values (keep only necessary sections).
            //     for line in order.order_line:
            //         if line.display_type in ('line_section', 'line_subsection'):
            //             pending_section = line
            //             continue
            //         if pending_section:
            //             line_vals = pending_section._prepare_account_move_line()
            //             line_vals.update({'sequence': sequence})
            //             invoice_vals['invoice_line_ids'].append((0, 0, line_vals))
            //             sequence += 1
            //             pending_section = None
            //         line_vals = line._prepare_account_move_line()
            //         line_vals.update({'sequence': sequence})
            //         invoice_vals['invoice_line_ids'].append((0, 0, line_vals))
            //         sequence += 1
            //     invoice_vals_list.append(invoice_vals)
            // 
            // # 2) group by (company_id, partner_id, currency_id) for batch creation
            // new_invoice_vals_list = []
            // for _grouping_keys, invoices in groupby(invoice_vals_list, key=lambda x: (x.get('company_id'), x.get('partner_id'), x.get('currency_id'))):
            //     origins = set()
            //     ref_invoice_vals = None
            //     for invoice_vals in invoices:
            //         if not ref_invoice_vals:
            //             ref_invoice_vals = invoice_vals
            //         else:
            //             ref_invoice_vals['invoice_line_ids'] += invoice_vals['invoice_line_ids']
            //         origins.add(invoice_vals['invoice_origin'])
            //     ref_invoice_vals.update({
            //         'invoice_origin': ', '.join(origins),
            //     })
            //     new_invoice_vals_list.append(ref_invoice_vals)
            // invoice_vals_list = new_invoice_vals_list
            // 
            // # 3) Create invoices.
            // invoices = self.env['account.move']
            // AccountMove = self.env['account.move'].with_context(default_move_type='in_invoice')
            // for vals in invoice_vals_list:
            //     invoices |= AccountMove.with_company(vals['company_id']).create(vals)
            // 
            // # 4) Some moves might actually be refunds: convert them if the total amount is negative
            // # We do this after the moves have been created since we need taxes, etc. to know if the total
            // # is actually negative or not
            // invoices.filtered(lambda m: m.currency_id.round(m.amount_total) < 0).action_switch_move_type()
            // 
            // # 5) Link the attachments to the invoice
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // if not attachments:
            //     return self.action_view_invoice(invoices)
            // 
            // if len(invoices) != 1:
            //     raise ValidationError(_("You can only upload a bill for a single vendor at a time."))
            // invoices.with_context(skip_is_manually_modified=True)._extend_with_attachments(
            //     invoices._to_files_data(attachments),
            //     new=True,
            // )
            // 
            // invoices.message_post(attachment_ids=attachments.ids)
            // 
            // attachments.write({'res_model': 'account.move', 'res_id': invoices.id})
            // return self.action_view_invoice(invoices)
            */
            return default;
        }

        public async Task<TEntity> ActionDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionForceRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionInvoiceDownloadPdfAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionInvoiceReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionInvoiceSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_lock(self):
            // self.locked = True
            */
            return default;
        }

        public async Task<TEntity> ActionMergeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            // merged_rfq_ids = []
            // 
            // for rfqs in bunches_of_rfq_to_be_merge:
            //     if len(rfqs) <= 1:
            //         continue
            //     oldest_rfq = min(rfqs, key=lambda r: r.date_order)
            //     if oldest_rfq:
            //         # Merge RFQs into the oldest purchase order
            //         rfqs -= oldest_rfq
            //         for rfq_line in rfqs.order_line:
            //             existing_line = oldest_rfq.order_line.filtered(lambda l: l.display_type not in ['line_section', 'line_subsection', 'line_note'] and
            //                                                                         l.product_id == rfq_line.product_id and
            //                                                                         l.product_uom_id == rfq_line.product_uom_id and
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
            //         # Keep the oldest RFQ IDs
            //         merged_rfq_ids.append(oldest_rfq.id)
            // 
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,kanban,form',
            //     'res_model': 'purchase.order',
            // }
            // if len(merged_rfq_ids) == 1:
            //     action['res_id'] = merged_rfq_ids[0]
            //     action['view_mode'] = 'form'
            // else:
            //     action['name'] = _("Merged RFQs")
            //     action['domain'] = [('id', 'in', merged_rfq_ids)]
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionMoveDownloadAllAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_open_business_doc(self):
            // self.ensure_one()
            // return {
            //     'name': _("Order"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'purchase.order',
            //     'res_id': self.id,
            //     'views': [(False, 'form')],
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

        public async Task<TEntity> ActionOpenDiscountWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionPostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionPreviewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionPrintPdfAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionPurchaseComparisonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def action_purchase_comparison(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("purchase.action_purchase_history")
            // action['domain'] = [('product_id', 'in', self.order_line.product_id.ids)]
            // action['display_name'] = _("Purchase Comparison for %s", self.display_name)
            // return action
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_quotation_send(self):
            // """ Opens a wizard to compose an email, with relevant mail template loaded by default """
            // self.filtered(lambda so: so.state in ('draft', 'sent')).order_line._validate_analytic_distribution()
            // 
            // ctx = {
            //     'default_model': 'sale.order',
            //     'default_res_ids': self.ids,
            //     'default_composition_mode': 'comment',
            //     'default_email_layout_xmlid': 'mail.mail_notification_layout_with_responsible_signature',
            //     'email_notification_allow_footer': True,
            //     'hide_mail_template_management_options': True,
            //     'proforma': self.env.context.get('proforma', False),
            // }
            // 
            // if len(self) > 1:
            //     ctx['default_composition_mode'] = 'mass_mail'
            // else:
            //     ctx.update({
            //         'force_email': True,
            //     })
            //     if not self.env.context.get('hide_default_template'):
            //         mail_template = self._find_mail_template()
            //         if mail_template:
            //             ctx.update({
            //                 'default_template_id': mail_template.id,
            //                 'mark_so_as_sent': True,
            //             })
            //     else:
            //         for order in self:
            //             order._portal_ensure_token()
            // 
            // action = {
            //     'name': _('Send'),
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

        public async Task<TEntity> ActionQuotationSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            // self.write({'state': 'sent'})
            */
            return default;
        }

        public async Task<TEntity> ActionRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionReverseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionRfqSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            //     'hide_mail_template_management_options': True,
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

        public async Task<TEntity> ActionSendAndPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionSwitchMoveTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionToggleBlockPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def action_unlock(self):
            // self.locked = False
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateFposValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionUpdatePricesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionUpdateTaxesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionValidateMovesWithConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ActionViewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object invoices) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
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
            // result['context'] = literal_eval(result['context'])
            // if len(self.partner_id) == 1:
            //     result['context']['default_partner_id'] = self.partner_id.id
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
            //     })
            // action['context'] = context
            // return action
            */
            return default;
        }

        public async Task<TEntity> AddBaseLinesForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            //     for line in self._get_priced_lines():
            //         line_amount_after_discount = (line.price_subtotal / 100) * percentage
            //         epd_lines.append(self.env['account.tax']._prepare_base_line_for_taxes_computation(
            //             record=self,
            //             price_unit=-line_amount_after_discount,
            //             quantity=1.0,
            //             currency_id=currency,
            //             sign=1,
            //             special_type='early_payment',
            //             tax_ids=line.tax_ids.flatten_taxes_hierarchy().filtered(lambda tax: tax.amount_type != 'fixed'),
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

        public async Task<TEntity> AddSupplierToProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            //         if line.product_id.product_tmpl_id.uom_id != line.product_uom_id:
            //             default_uom = line.product_id.product_tmpl_id.uom_id
            //             price = line.product_uom_id._compute_price(price, default_uom)
            // 
            //         supplierinfo = self._prepare_supplier_info(partner, line, price, line.currency_id)
            //         # In case the order partner is a contact address, a new supplierinfo is created on
            //         # the parent company. In this case, we keep the product name and code.
            //         if line.selected_seller_id:
            //             supplierinfo['product_name'] = line.selected_seller_id.product_name
            //             supplierinfo['product_code'] = line.selected_seller_id.product_code
            //             supplierinfo['product_uom_id'] = line.product_uom.id
            //         vals = {
            //             'seller_ids': [(0, 0, supplierinfo)],
            //         }
            //         # supplier info should be added regardless of the user access rights
            //         line.product_id.product_tmpl_id.sudo().write(vals)
            */
            return default;
        }

        public async Task<TEntity> AffectTaxReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _affect_tax_report(self):
            // return any(line._affect_tax_report() for line in (self.line_ids | self.invoice_line_ids))
            */
            return default;
        }

        public async Task<TEntity> AmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> ApplyDeltaRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object date_origin, object period) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ApprovalAllowedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> AssignAttachmentToGroupOfDifferentTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object incoming_file_data, object groups) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _assign_attachment_to_group_of_different_type(self, incoming_file_data, groups=[]):
            // """ Add the attachment to the group which doesn't yet have an attachment of the same root type
            // (however, attachments with no root type don't clash with each other).
            // If several groups are available, we choose the group which has the highest filename similarity.
            // """
            // incoming_type = incoming_file_data['import_file_type']
            // 
            // # If there are groups with different types, we choose the group which has the highest filename similarity.
            // if groups_with_different_type := [
            //     group
            //     for group in groups
            //     if not incoming_type or incoming_type not in (file_data['import_file_type'] for file_data in group)
            // ]:
            //     sorted_by_similarity = sorted(
            //         groups_with_different_type,
            //         key=lambda group: max(
            //             self._get_similarity_score(incoming_file_data['name'], file_data['name'])
            //             for file_data in group
            //         ),
            //         reverse=True,
            //     )
            //     sorted_by_similarity[0].append(incoming_file_data)
            //     return
            // 
            // # Otherwise, create a new group.
            // groups.append([incoming_file_data])
            */
            return default;
        }

        public async Task<TEntity> AssignAttachmentToGroupWithSameOriginAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object incoming_file_data, object groups) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _assign_attachment_to_group_with_same_origin_attachment(self, incoming_file_data, groups=[]):
            // """ Attachments that come from the same origin attachment are added to the same group. """
            // for group in groups:
            //     if any(
            //         incoming_file_data['origin_attachment'] == file_data['origin_attachment']
            //         for file_data in group
            //     ):
            //         group.append(incoming_file_data)
            //         return
            // groups.append([incoming_file_data])
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> AutopostBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> AutopostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_size) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> BuildCreditWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object current_amount, object exclude_current, object exclude_amount) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ButtonApproveAsync<TEntity>(IEnumerable<TEntity> entities, object force) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_approve(self, force=False):
            // self = self.filtered(lambda order: order._approval_allowed())
            // self.write({'state': 'purchase', 'date_approve': fields.Datetime.now()})
            // self.filtered(lambda p: p.lock_confirmed_po == 'lock').write({'locked': True})
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ButtonCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_cancel(self):
            // locked_purchase_orders = self.filtered(lambda po: po.locked)
            // if locked_purchase_orders:
            //     raise UserError(self.env._("Unable to cancel purchase order(s): %s. You must first unlock them.", locked_purchase_orders.mapped('display_name')))
            // 
            // purchase_orders_with_invoices = self.filtered(lambda po: any(i.state not in ('cancel', 'draft') for i in po.invoice_ids))
            // if purchase_orders_with_invoices:
            //     raise UserError(_("Unable to cancel purchase order(s): %s. You must first cancel their related vendor bills.", purchase_orders_with_invoices.mapped('display_name')))
            // self.write({'state': 'cancel'})
            */
            return default;
        }

        public async Task<TEntity> ButtonConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_confirm(self):
            // for order in self:
            //     if order.state not in ['draft', 'sent']:
            //         continue
            //     error_msg = order._confirmation_error_message()
            //     if error_msg:
            //         raise UserError(error_msg)
            //     order.order_line._validate_analytic_distribution()
            //     order._add_supplier_to_product()
            //     # Deal with double validation process
            //     if order._approval_allowed():
            //         order.button_approve()
            //     else:
            //         order.write({'state': 'to approve'})
            // return True
            */
            return default;
        }

        public async Task<TEntity> ButtonDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_draft(self):
            // self.write({'state': 'draft'})
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ButtonHashAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_hash(self):
            // self._hash_moves(force_hash=True)
            */
            return default;
        }

        public async Task<TEntity> ButtonLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_lock(self):
            // self.locked = True
            */
            return default;
        }

        public async Task<TEntity> ButtonRequestCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ButtonSetCheckedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def button_set_checked(self):
            // self.set_moves_checked()
            */
            return default;
        }

        public async Task<TEntity> ButtonUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def button_unlock(self):
            // self.locked = False
            */
            return default;
        }

        public async Task<TEntity> CalculateHashesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object previous_hash) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CanBeEditedOnPortalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _can_be_edited_on_portal(self):
            // self.ensure_one()
            // return self.state in ('draft', 'sent')
            */
            return default;
        }

        public async Task<TEntity> CanBeUnlinkedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CanForceCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CheckBalancedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CheckDraftableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CheckFiscalLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CheckInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CheckJournalMoveTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CheckMoveSequenceChainAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_move_sequence_chain(self):
            // return self.filtered(lambda move: move.name != '/')._is_end_of_seq_chain()
            */
            return default;
        }

        public async Task<TEntity> CheckOrderLineCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CheckPrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CheckSelectedMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def check_selected_moves(self):
            // self.env['account.move'].browse(self.env.context.get('active_ids', [])).set_moves_checked()
            */
            return default;
        }

        public async Task<TEntity> CheckTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_total) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> CleanupWriteOrmValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CollectTaxCashBasisValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeAbnormalWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_access_url(self):
            // super()._compute_access_url()
            // for move in self.filtered(lambda move: move.is_invoice()):
            //     move.access_url = '/my/invoices/%s' % (move.id)
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

        public async Task<TEntity> ComputeAdjustingEntriesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_adjusting_entries_count(self):
            // for move in self:
            //     move.adjusting_entries_count = len(move.adjusting_entries_move_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntryOriginLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeAdjustingEntryOriginMovesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_adjusting_entry_origin_moves_count(self):
            // for move in self:
            //     move.adjusting_entry_origin_moves_count = len(move.adjusting_entry_origin_move_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_alerts(self):
            // for move in self:
            //     move.alerts = move._get_alerts()
            */
            return default;
        }

        public async Task<TEntity> ComputeAlwaysTaxExigibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_invoiced(self):
            // for order in self:
            //     order.amount_invoiced = sum(order.order_line.mapped('amount_invoiced'))
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amount_to_invoice(self):
            // for order in self:
            //     order.amount_to_invoice = sum(order.order_line.mapped('amount_to_invoice'))
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalCcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_amount_total_cc(self):
            // for order in self:
            //     order.amount_total_cc = order.amount_total / order.currency_rate
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalWordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_amount_total_words(self):
            // for move in self:
            //     move.amount_total_words = move.currency_id.amount_to_text(move.amount_total).replace(',', '')
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountUndiscountedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_amounts(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     order_lines = order._get_priced_lines()
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

        public async Task<TEntity> ComputeAuthorizedTransactionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_authorized_transaction_ids(self):
            // for trans in self:
            //     trans.authorized_transaction_ids = trans.transaction_ids.filtered(lambda t: t.state == 'authorized')
            //     trans.has_authorized_transaction_ids = bool(trans.authorized_transaction_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeAutoPostUntilInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeBankPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeCheckedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_checked(self):
            // for move in self:
            //     move.checked = move.state == 'posted' and (move.journal_id.type == 'general' or move._is_user_able_to_review())
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_commercial_partner_id(self):
            // for move in self:
            //     move.commercial_partner_id = move.partner_id.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_company_id(self):
            // for move in self:
            //     if move.journal_id.company_id not in move.company_id.parent_ids:
            //         move.company_id = (move.journal_id.company_id or self.env.company)._accessible_branches()[:1]
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_currency_id(self):
            // for order in self:
            //     order = order.with_company(order.company_id)
            //     if not order.partner_id:
            //         order.currency_id = order.company_id.currency_id
            //     else:
            //         order.currency_id = order.partner_id.property_purchase_currency_id or order.company_id.currency_id
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_currency_id(self):
            // for order in self:
            //     order.currency_id = order.pricelist_id.currency_id or order.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
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

        public async Task<TEntity> ComputeDateCalendarStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_date_calendar_start(self):
            // for order in self:
            //     order.date_calendar_start = order.date_approve if (order.state == 'purchase') else order.date_order
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_delivery_date(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeDirectionSignInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeDisplayInactiveCurrencyWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_inactive_currency_warning(self):
            // for move in self.with_context(active_test=False):
            //     move.display_inactive_currency_warning = move.state == 'draft' and move.currency_id and not move.currency_id.active
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayLinkQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
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
            // if not self.env.context.get('sale_show_partner_name'):
            //     return super()._compute_display_name()
            // for order in self:
            //     name = order.name
            //     if order.partner_id.name:
            //         name = f'{name} - {order.partner_id.name}'
            //     order.display_name = name
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeDisplaySendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_display_send_button(self):
            // for move in self:
            //     move.display_send_button = move.is_sale_document() and move.state == 'posted'
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedOrderIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_duplicated_order_ids(self):
            // """Compute duplicated purchase orders based on key fields."""
            // draft_orders = self.filtered(lambda o: o.state == 'draft')
            // order_to_duplicate_orders = draft_orders._fetch_duplicate_orders()
            // for order in draft_orders:
            //     duplicate_ids = order_to_duplicate_orders.get(order.id, [])
            //     order.duplicated_order_ids = [Command.set(duplicate_ids)]
            // (self - draft_orders).duplicated_order_ids = False
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_duplicated_order_ids(self):
            // draft_orders = self.filtered(lambda o: o.state == 'draft')
            // order_to_duplicate_orders = draft_orders._fetch_duplicate_orders()
            // for order in draft_orders:
            //     order.duplicated_order_ids = [Command.set(order_to_duplicate_orders.get(order.id, []))]
            // (self - draft_orders).duplicated_order_ids = False
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedRefIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeExpectedCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_expected_date(self):
            // """ For service and combo (non-goods) products, we avoid computing the expected date. This method is extended in sale_stock to
            //     take the picking_policy of SO into account.
            // """
            // self.mapped("order_line")  # Prefetch indication
            // for order in self:
            //     if order.state == 'cancel':
            //         order.expected_date = False
            //         continue
            //     dates_list = order.order_line.filtered(
            //         lambda line: line.product_id.type == 'consu' and not line.display_type and not line._is_delivery()
            //     ).mapped(lambda line: line and line._expected_date())
            //     if dates_list:
            //         order.expected_date = order._select_expected_date(dates_list)
            //     else:
            //         order.expected_date = False
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeHasActivePricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeHasArchivedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeHasReconciledEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_has_reconciled_entries(self):
            // for move in self:
            //     move.has_reconciled_entries = len(move.line_ids._reconciled_lines()) > 1
            */
            return default;
        }

        public async Task<TEntity> ComputeHidePostButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeHighestNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_highest_name(self):
            // for record in self:
            //     record.highest_name = record._get_last_sequence()
            */
            return default;
        }

        public async Task<TEntity> ComputeHighlightSendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_highlight_send_button(self):
            // for move in self:
            //     move.highlight_send_button = not move.is_being_sent and not move.invoice_pdf_report_id
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeIncotermLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_incoterm_location(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeInvoiceDateDueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeInvoiceDefaultSalePersonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_filter_type_domain(self):
            // for move in self:
            //     move.invoice_filter_type_domain = self._get_invoice_filter_type_domain(move.move_type)
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceHasOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_has_outstanding(self):
            // for move in self:
            //     move.invoice_has_outstanding = bool(move.invoice_outstanding_credits_debits_widget)
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceIncotermPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_invoice_incoterm_placeholder(self):
            // for move in self:
            //     move.invoice_incoterm_placeholder = move.company_id.incoterm_id.display_name if move.company_id.incoterm_id else _('Define a default in the settings')
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeInvoicePartnerDisplayInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeInvoiceStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeIsBeingSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_being_sent(self):
            // for move in self:
            //     move.is_being_sent = bool(move.sending_data)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsExpiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeIsSaleInstalledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_is_sale_installed(self):
            // self.is_sale_installed = 'sale_management' in self.env['ir.module.module']._installed()
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeLinkedAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment_field, object binary_field) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeMoveSentValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def compute_move_sent_values(self):
            // for move in self:
            //     move.move_sent_values = 'sent' if move.is_move_sent else 'not_sent'
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeNamePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeNarrationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeNeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_need_cancel_request(self):
            // for move in self:
            //     move.need_cancel_request = move._need_cancel_request()
            */
            return default;
        }

        public async Task<TEntity> ComputeNeededTermsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_next_payment_date(self):
            // for move in self:
            //     move.next_payment_date = min([line.payment_date for line in move.line_ids.filtered(lambda l: l.payment_date and not l.reconciled)], default=False)
            */
            return default;
        }

        public async Task<TEntity> ComputeNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCreditWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePartnerInvoiceIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_partner_invoice_id(self):
            // for order in self:
            //     order.partner_invoice_id = order.partner_id.address_get(['invoice'])['invoice'] if order.partner_id else False
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShippingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePaymentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_payment_count(self):
            // for invoice in self:
            //     invoice.payment_count = len(invoice.reconciled_payment_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePaymentsWidgetReconciledInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePaymentsWidgetToReconcileInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePreferredPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_preferred_payment_method_line_id(self):
            // for order in self:
            //     order = order.with_company(order.company_id)
            //     order.preferred_payment_method_line_id = order.partner_id.property_inbound_payment_method_line_id
            */
            return default;
        }

        public async Task<TEntity> ComputePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_prepayment_percent(self):
            // for order in self:
            //     order.prepayment_percent = order.company_id.prepayment_percent
            */
            return default;
        }

        public async Task<TEntity> ComputePricelistIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputePurchaseWarningTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_purchase_warning_text(self):
            // if not self.env.user.has_group('purchase.group_warning_purchase'):
            //     self.purchase_warning_text = ''
            //     return
            // for order in self:
            //     warnings = OrderedSet()
            //     if partner_msg := order.partner_id.purchase_warn_msg:
            //         warnings.add((order.partner_id.name or order.partner_id.display_name) + ' - ' + partner_msg)
            //     for line in order.order_line:
            //         if product_msg := line.purchase_line_warn_msg:
            //             warnings.add(line.product_id.display_name + ' - ' + product_msg)
            //     order.purchase_warning_text = '\n'.join(warnings)
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEditModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeQuickEncodingValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_quick_encoding_vals(self):
            // for move in self:
            //     move.quick_encoding_vals = move._get_quick_edit_suggestions()
            */
            return default;
        }

        public async Task<TEntity> ComputeReceiptReminderEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeRequirePaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_require_payment(self):
            // for order in self:
            //     order.require_payment = order.company_id.portal_confirmation_pay
            */
            return default;
        }

        public async Task<TEntity> ComputeRequireSignatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_require_signature(self):
            // for order in self:
            //     order.require_signature = order.company_id.portal_confirmation_sign
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleWarningTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_sale_warning_text(self):
            // if not self.env.user.has_group('sale.group_warning_sale'):
            //     self.sale_warning_text = ''
            //     return
            // for order in self:
            //     warnings = OrderedSet()
            //     if partner_msg := order.partner_id.sale_warn_msg:
            //         warnings.add((order.partner_id.name or order.partner_id.display_name) + ' - ' + partner_msg)
            //     for line in order.order_line:
            //         if product_msg := line.sale_line_warn_msg:
            //             warnings.add(line.product_id.display_name + ' - ' + product_msg)
            //     order.sale_warning_text = '\n'.join(warnings)
            */
            return default;
        }

        public async Task<TEntity> ComputeSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_secured(self):
            // for move in self:
            //     move.secured = bool(move.inalterable_hash)
            */
            return default;
        }

        public async Task<TEntity> ComputeShowComparisonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _compute_show_comparison(self):
            // line_groupby_product = self.env['purchase.order.line']._read_group(
            //     [('product_id', 'in', self.order_line.product_id.ids), ('state', '=', 'purchase')],
            //     ['product_id'],
            //     ['order_id:array_agg']
            // )
            // 
            // order_by_product = {p: set(o_ids) for p, o_ids in line_groupby_product}
            // for record in self:
            //     record.show_comparison = any(set(record.ids) != order_by_product[p] for p in record.order_line.product_id if p in order_by_product)
            */
            return default;
        }

        public async Task<TEntity> ComputeShowDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_delivery_date(self):
            // for move in self:
            //     move.show_delivery_date = move.delivery_date and move.is_sale_document()
            */
            return default;
        }

        public async Task<TEntity> ComputeShowJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_journal(self):
            // for move in self:
            //     move.show_journal = len(move.suitable_journal_ids) > 1
            */
            return default;
        }

        public async Task<TEntity> ComputeShowPaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeShowResetToDraftButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeShowTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_show_taxable_supply_date(self):
            // for move in self:
            //     move.show_taxable_supply_date = False
            */
            return default;
        }

        public async Task<TEntity> ComputeStatusInPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_suitable_journal_ids(self):
            // for m in self:
            //     m.suitable_journal_ids = self._get_suitable_journal_ids(m.move_type, m.company_id)
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_tax_country_code(self):
            // for record in self:
            //     record.tax_country_code = record.tax_country_id.code
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeTaxIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeTaxLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            //         order.tax_totals['amount_total_cc'] = f"({formatLang(self.env, order.amount_total_cc, currency_obj=order.company_currency_id)})"
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_tax_totals(self):
            // AccountTax = self.env['account.tax']
            // for order in self:
            //     order_lines = order._get_priced_lines()
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

        public async Task<TEntity> ComputeTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_taxable_supply_date(self):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxableSupplyDatePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _compute_taxable_supply_date_placeholder(self):
            // for move in self:
            //     move.taxable_supply_date_placeholder = ''
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxesLegalNotesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _compute_team_id(self):
            // cached_teams = {}
            // for order in self:
            //     default_team_id = order._default_team_id()
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

        public async Task<TEntity> ComputeTypeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ComputeValidityDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ConditionalAddToComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object condition) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ConfirmationErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _confirmation_error_message(self):
            // """ Return whether order can be confirmed or not if not then return error message. """
            // self.ensure_one()
            // if any(
            //     not line.display_type
            //     and not line.is_downpayment
            //     and not line.product_id
            //     for line in self.order_line
            // ):
            //     return _("Some order lines are missing a product, you need to correct them before going further.")
            // 
            // return False
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
            //     return _("Some order lines are missing a product, you need to correct them before going further.")
            // 
            // return False
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def copy(self, default=None):
            // ctx = dict(self.env.context)
            // ctx.pop('default_product_id', None)
            // self = self.with_context(ctx)
            // new_pos = super().copy(default=default)
            // for line in new_pos.order_line:
            //     if line.product_id:
            //         line.date_planned = line._get_date_planned(line.selected_seller_id)
            // return new_pos
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CreateAccountInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_vals_list, object final) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def create(self, vals_list):
            // orders = self.browse()
            // for vals in vals_list:
            //     company_id = vals.get('company_id', self.default_get(['company_id'])['company_id'])
            //     # Ensures default picking type and currency are taken from the right company.
            //     self_comp = self.with_company(company_id)
            //     if vals.get('name', 'New') == 'New':
            //         seq_date = None
            //         if 'date_order' in vals:
            //             seq_date = fields.Datetime.context_timestamp(self, fields.Datetime.to_datetime(vals['date_order']))
            //         vals['name'] = self_comp.env['ir.sequence'].next_by_code('purchase.order', sequence_date=seq_date) or '/'
            //     orders |= super(PurchaseOrder, self_comp).create(vals)
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

        public async Task<TEntity> CreateDocumentFromAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def create_document_from_attachment(self, attachment_ids):
            // """ Create the purchase orders from given attachment_ids
            // and redirect newly create order view.
            // 
            // :param list attachment_ids: List of attachments process.
            // :return: An action redirecting to related sale order view.
            // :rtype: dict
            // """
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // if not attachments:
            //     raise UserError(_("No attachment was provided"))
            // 
            // orders = self.with_context(default_partner_id=self.env.user.partner_id.id)._create_records_from_attachments(attachments)
            // return orders._get_records_action(name=_("Generated Orders"))
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def create_document_from_attachment(self, attachment_ids):
            // """ Create the sale orders from given attachment_ids and redirect newly create order view.
            // 
            // :param list attachment_ids: List of attachments process.
            // :return: An action redirecting to related sale order view.
            // :rtype: dict
            // """
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // if not attachments:
            //     raise UserError(_("No attachment was provided"))
            // 
            // orders = self.with_context(default_partner_id=self.env.user.partner_id.id)._create_records_from_attachments(attachments)
            // 
            // return orders._get_records_action(name=_("Generated Orders"))
            */
            return default;
        }

        public async Task<TEntity> CreateDownPaymentLinesFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object down_payment_base_lines) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_down_payment_lines_from_base_lines(self, down_payment_base_lines):
            // """ Add the base lines passed as parameter as sale order lines into the current sale order.
            // 
            // :param down_payment_base_lines: A list of base lines
            //                                 (see '_prepare_base_line_for_taxes_computation').
            // :return The newly created SO lines.
            // """
            // self.ensure_one()
            // sequence = max(self.order_line.mapped('sequence') or [10]) + 1
            // return self.env['sale.order.line'] \
            //     .with_context(sale_no_log_for_new_lines=True) \
            //     .create([
            //         {
            //             **self._prepare_down_payment_line_values_from_base_line(base_line),
            //             'sequence': sequence + index,
            //         }
            //         for index, base_line in enumerate(down_payment_base_lines)
            //     ])
            */
            return default;
        }

        public async Task<TEntity> CreateDownPaymentSectionLineIfNeededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_down_payment_section_line_if_needed(self):
            // """ Add the down section line if not already there on the current SO.
            // 
            // :return The newly created SO line or None if the section was already there.
            // """
            // self.ensure_one()
            // # If a down payment is already there, then the section is not needed and
            // # has already been created.
            // if any(line.display_type and line.is_downpayment for line in self.order_line):
            //     return
            // 
            // sequence = max(self.order_line.mapped('sequence') or [10]) + 1
            // return self.env['sale.order.line'] \
            //     .with_context(sale_no_log_for_new_lines=True) \
            //     .create({
            //         **self._prepare_down_payment_line_section_values(),
            //         'sequence': sequence,
            //     })
            */
            return default;
        }

        public async Task<TEntity> CreateDownpaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_vals) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CreateInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grouped, object final, object date) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            //     if all(line.display_type for line in invoiceable_lines):
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
            // 
            //         optional_values = {'sequence': invoice_item_sequence}
            // 
            //         # When creating the final invoice, we want to express the lines representing
            //         # the full order but negate the already created down payment lines.
            //         # At this point, on the sale order, the down payment lines have a non-empty
            //         # 'extra_tax_data' containing a price unit greater than zero and a quantity of 0.0.
            //         if line.is_downpayment:
            //             optional_values['quantity'] = -1.0
            //             optional_values['extra_tax_data'] = self.env['account.tax']\
            //                 ._reverse_quantity_base_line_extra_tax_data(line.extra_tax_data)
            // 
            //         for vals in line._prepare_invoice_lines_vals_list(**optional_values):
            //             invoice_line_vals.append(Command.create(vals))
            // 
            //         invoice_item_sequence += 1
            // 
            //     invoice_vals['invoice_line_ids'] += invoice_line_vals
            //     invoice_vals_list.append(invoice_vals)
            // 
            // if not invoice_vals_list and self.env.context.get('raise_if_nothing_to_invoice', True):
            //     raise UserError(self._nothing_to_invoice_error_message())
            // 
            // # 2) Manage 'grouped' parameter: group by (partner_id, partner_shipping_id, currency_id).
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
            //     move.message_post_with_source(
            //         'mail.message_origin_link',
            //         render_values={'self': move, 'origin': move.line_ids.sale_line_ids.order_id},
            //         subtype_xmlid='mail.mt_note',
            //     )
            // return moves
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateRecordsFromAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments, object grouping_method) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _create_records_from_attachments(self, attachments, grouping_method=None):
            // """ For each attachment, create a corresponding record, and attempt to decode the
            //     attachment on the record.
            // 
            //     Some attachments (e.g. in some EDI formats) may contain multiple business
            //     documents; in that case, we attempt to separate them and create a new record for
            //     each business document.
            // 
            //     ⚠️ Because this method commits the cursor, try to:
            //     (1) do as much work as possible before calling this method, and
            //     (2) avoid triggering a SerializationError later in the request. If a SerializationError happens,
            //         `retrying` will cause the whole request to be retried, which may cause some things
            //         to be duplicated. That may be more or less undesirable, depending on what you're doing.
            // """
            // if grouping_method is None:
            //     grouping_method = self._group_files_data_by_origin_attachment
            // 
            // files_data = self._to_files_data(attachments)
            // 
            // # Extract embedded attachments
            // files_data.extend(self._unwrap_attachments(files_data))
            // 
            // # Perform a grouping to determine how many invoices to create
            // file_data_groups = grouping_method(files_data)
            // 
            // records = self.create([{}] * len(file_data_groups))
            // for record, file_data_group in zip(records, file_data_groups):
            //     attachment_records = self._from_files_data(file_data_group)
            //     attachment_records.write({
            //         'res_model': record._name,
            //         'res_id': record.id,
            //     })
            //     record.message_post(
            //         body=self.env._("This document was created from the following attachment(s)."),
            //         attachment_ids=attachment_records.ids
            //     )
            // 
            // # Call _extend_with_attachments at the end, because it commits the transaction.
            // for record, file_data_group in zip(records, file_data_groups):
            //     record._extend_with_attachments(file_data_group, new=True)
            // 
            // return records
            */
            return default;
        }

        public async Task<TEntity> CreateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> CreateUpsellActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _create_upsell_activity(self):
            // if not self:
            //     return
            // 
            // self.activity_unlink(['mail.mail_activity_data_todo'])
            // for order in self:
            //     order_ref = order._get_html_link()
            //     customer_ref = order.partner_id._get_html_link()
            //     order.activity_schedule(
            //         'mail.mail_activity_data_todo',
            //         user_id=order.user_id.id or order.partner_id.user_id.id,
            //         note=_("Upsell %(order)s for customer %(customer)s", order=order_ref, customer=customer_ref))
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _creation_subtype(self):
            // # EXTENDS mail mail.thread
            // if self.move_type in ('out_invoice', 'out_receipt'):
            //     return self.env.ref('account.mt_invoice_created')
            // else:
            //     return super()._creation_subtype()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronAccountMoveSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object job_count) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> CronSendPendingEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _cron_send_pending_emails(self):
            // """ Find and send pending order status emails asynchronously.
            // 
            // :return: None
            // """
            // pending_email_orders = self.search([('pending_email_template_id', '!=', False)])
            // self.env['ir.cron']._commit_progress(remaining=len(pending_email_orders))
            // for order in pending_email_orders:
            //     order = order[0]  # Avoid pre-fetching after each cache invalidation due to committing.
            //     order._send_order_notification_mail(
            //         order.pending_email_template_id, allow_deferred_sending=False
            //     )  # Resume the email sending.
            //     order.pending_email_template_id = None
            //     remaining_time = self.env['ir.cron']._commit_progress(processed=1)
            //     if not remaining_time:
            //         break
            */
            return default;
        }

        public async Task<TEntity> DefaultOrderLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> DefaultTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _default_team_id(self):
            // return self.env.context.get('default_team_id', False) or self.team_id.id
            */
            return default;
        }

        public async Task<TEntity> DetachAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> DisableDiscountPrecisionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> DisableRecursionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container, object key, object @default, object target) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> DiscardTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> EarlyPaymentDiscountMoveTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _early_payment_discount_move_types(self):
            // return ('out_invoice', 'out_receipt', 'in_invoice', 'in_receipt')
            */
            return default;
        }

        public async Task<TEntity> ExtendWithAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files_data, object @new) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _extend_with_attachments(self, files_data, new=False):
            // """ Extend/enhance a business document with one or more attachments.
            // 
            // Only the attachment with the highest priority will be used to extend the business document,
            // using the appropriate decoder.
            // 
            // The decoder may break Python and SQL constraints in difficult-to-predict ways.
            // This method calls the decoder in such a way that any exceptions instead roll back the transaction
            // and log a message on the invoice chatter.
            // 
            // This method will not extract embedded files for you - if you want embedded files to be
            // considered, you must pass them as part of the `attachments` recordset.
            // 
            // :param self:        An invoice on which to apply the attachments.
            // :param files_data:  A list of file_data dicts, each representing an in-DB or extracted attachment.
            // :param new:         If true, indicates that the invoice was newly created, will be passed to the decoder.
            // :return:            True if at least one document is successfully imported.
            // 
            // ⚠️ Because this method commits the cursor, try to:
            // (1) do as much work as possible before calling this method, and
            // (2) avoid triggering a SerializationError later in the request. If a SerializationError happens,
            //     `retrying` will cause the whole request to be retried, which may cause some things
            //     to be duplicated. That may be more or less undesirable, depending on what you're doing.
            // """
            // def _get_attachment_name(file_data):
            //     params = {
            //         'filename': file_data['name'],
            //         'root_filename': file_data['origin_attachment'].name,
            //         'type': file_data['import_file_type'],
            //     }
            //     if not file_data['attachment']:
            //         return self.env._("'%(filename)s' (extracted from '%(root_filename)s', type=%(type)s)", **params)
            //     else:
            //         return self.env._("'%(filename)s' (type=%(type)s)", **params)
            // 
            // self.ensure_one()
            // 
            // for file_data in files_data:
            //     if 'decoder_info' not in file_data:
            //         file_data['decoder_info'] = self._get_edi_decoder(file_data, new=new)
            // 
            // # Identify the attachment to decode.
            // sorted_files_data = sorted(
            //     files_data,
            //     key=lambda file_data: (
            //         file_data['decoder_info'] is not None,
            //         (file_data['decoder_info'] or {}).get('priority', 0),
            //     ),
            //     reverse=True,
            // )
            // 
            // file_data = sorted_files_data[0]
            // 
            // if file_data['decoder_info'] is None or file_data['decoder_info'].get('priority', 0) == 0:
            //     _logger.info(
            //         "Attachment(s) %s not imported: no suitable decoder found.",
            //         [file_data['name'] for file_data in files_data],
            //     )
            //     return
            // 
            // try:
            //     with rollbackable_transaction(self.env.cr):
            //         reason_cannot_decode = file_data['decoder_info']['decoder'](self, file_data, new)
            //         if reason_cannot_decode:
            //             self.message_post(
            //                 body=self.env._(
            //                     "Attachment %(filename)s not imported: %(reason)s",
            //                     filename=file_data['name'],
            //                     reason=reason_cannot_decode,
            //                 )
            //             )
            //             return
            // except RedirectWarning:
            //     raise
            // except (
            //     AccessError,
            //     UserError,
            //     ValidationError,
            //     psycopg2.errors.IntegrityError,
            //     psycopg2.errors.SerializationFailure,
            // ) as e:
            //     _logger.exception("Error importing attachment %s on record %s", file_data['name'], self)
            // 
            //     self.sudo().message_post(body=Markup("%s<br/><br/>%s<br/>%s") % (
            //         self.env._(
            //             "Error importing attachment %(filename)s:",
            //             filename=_get_attachment_name(file_data),
            //         ),
            //         self.env._("This specific error occurred during the import:"),
            //         str(e),
            //     ))
            //     return
            // return True
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

        public async Task<TEntity> FetchDuplicateOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _fetch_duplicate_orders(self):
            // """ Fetch duplicated orders.
            // 
            // :return: Dictionary mapping order to its related duplicated orders.
            // :rtype: dict
            // """
            // orders = self.filtered(lambda order: order.id and order.partner_ref)
            // if not orders:
            //     return {}
            // 
            // self.env['purchase.order'].flush_model(['company_id', 'partner_id', 'partner_ref', 'origin', 'state'])
            // 
            // result = self.env.execute_query(SQL("""
            //     SELECT
            //         po.id AS order_id,
            //         array_agg(duplicate_po.id) AS duplicate_ids
            //     FROM purchase_order po
            //     JOIN purchase_order AS duplicate_po
            //         ON po.company_id = duplicate_po.company_id
            //         AND po.id != duplicate_po.id
            //         AND duplicate_po.state != 'cancel'
            //         AND po.partner_id = duplicate_po.partner_id
            //         AND (
            //             po.origin = duplicate_po.name
            //             OR po.partner_ref = duplicate_po.partner_ref
            //         )
            //     WHERE po.id IN %(orders)s
            //     GROUP BY po.id
            // """, orders=tuple(orders.ids)))
            // 
            // return {order_id: set(duplicate_ids) for order_id, duplicate_ids in result}
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _fetch_duplicate_orders(self):
            // """ Fetch duplicated orders.
            // 
            // :return: Dictionary mapping order to its related duplicated orders.
            // :rtype: dict
            // """
            // orders = self.filtered(lambda order: order.id and order.client_order_ref)
            // if not orders:
            //     return {}
            // 
            // self.env['sale.order'].flush_model(['company_id', 'partner_id', 'client_order_ref', 'origin', 'state'])
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
            //          AND (
            //             sale_order.origin = duplicate_order.name
            //             OR sale_order.client_order_ref = duplicate_order.client_order_ref
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

        public async Task<TEntity> FetchDuplicateReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object matching_states) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string fname, object query) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FieldWillChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals, object field_name) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> FilterProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object documents) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> FindAndSetPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _find_and_set_purchase_orders(self, po_references, partner_id, amount_total, from_ocr=False, timeout=10):
            // # hook to be used with purchase, so that vendor bills are sync/autocompleted with purchase orders
            // self.ensure_one()
            */
            return default;
        }

        public async Task<TEntity> FindMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            // if self.env.context.get('proforma'):
            //     return self.env.ref('sale.email_template_proforma', raise_if_not_found=False)
            // elif self.state != 'sale':
            //     return self.env.ref('sale.email_template_edi_sale', raise_if_not_found=False)
            // else:
            //     return self._get_confirmation_template()
            */
            return default;
        }

        public async Task<TEntity> FixAttachmentsOnRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _fix_attachments_on_record(self, attachments):
            // """ Ensure that only attachments of certain types appear in `self`'s attachments.
            // 
            // This is to provide a consistent behaviour where only certain attachment types
            // appear in the chatter's attachments, to avoid cluttering the attachments view.
            // """
            // self.ensure_one()
            // attachments_to_attach = attachments.filtered(self._should_attach_to_record)
            // if attachments_to_attach:
            //     # No need to write to attachments that have the same res_model and res_id
            //     attachments_to_write = attachments_to_attach.filtered(lambda a: a.res_model != self._name or a.res_id != self.id)
            //     attachments_to_write.write({
            //         'res_model': self._name,
            //         'res_id': self.id,
            //     })
            // attachments_to_unattach = (attachments - attachments_to_attach).filtered(lambda a: a.res_model == self._name and not a.res_field)
            // if attachments_to_unattach:
            //     attachments_to_unattach.write({
            //         'res_model': False,
            //         'res_id': 0,
            //     })
            */
            return default;
        }

        public async Task<TEntity> ForceLinesToInvoicePolicyOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> FromFilesDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files_data) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _from_files_data(self, files_data):
            // """ Helper method to convert a `files_data` list-of-dicts back into an ir.attachment recordset.
            //     This only returns those elements in `files_data` which correspond to an ir.attachment
            //     (thus, embedded files that were never turned into ir.attachments are omitted).
            // """
            // return self.env['ir.attachment'].union(*(
            //     file_data['attachment']
            //     for file_data in files_data
            //     if file_data.get('attachment')
            // ))
            */
            return default;
        }

        public async Task<TEntity> GenerateAndSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_synchronous, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GenerateDownpaymentInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GeneratePortalPaymentQrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GenerateQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object silent_errors) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax, object lock_dates) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetAccountingDateSourceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_accounting_date_source(self):
            // self.ensure_one()
            // return self.invoice_date or self.date
            */
            return default;
        }

        public async Task<TEntity> GetAcknowledgeUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_acknowledge_url(self):
            // return self.get_portal_url(query_string='&acknowledge=True')
            */
            return default;
        }

        public async Task<TEntity> GetActionAddFromCatalogExtraContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // return {
            //     **super()._get_action_add_from_catalog_extra_context(),
            //     'precision': self.env['decimal.precision'].precision_get('Product Unit'),
            //     'product_catalog_currency_id': self.currency_id.id,
            //     'product_catalog_digits': self.order_line._fields['price_unit'].get_digits(self.env),
            //     'search_default_seller_ids': self.partner_id.name,
            //     'show_sections': bool(self.id),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_action_add_from_catalog_extra_context(self):
            // return {
            //     **super()._get_action_add_from_catalog_extra_context(),
            //     'product_catalog_currency_id': self.currency_id.id,
            //     'product_catalog_digits': self.order_line._fields['price_unit'].get_digits(self.env),
            //     'show_sections': bool(self.id),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetActionWithBaseDocumentLayoutConfiguratorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_action) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetAllReconciledInvoicePartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetAutomaticBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetAvailableActionReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_invoice_report) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetChainInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetChainsToHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object raise_if_gap, object raise_if_no_document, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetConfirmUrlAsync<TEntity>(IEnumerable<TEntity> entities, object confirm_type) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_confirm_url(self, confirm_type=None):
            // """Create url for confirm reminder or purchase reception email for sending
            // in mail. Unsuported anymore. We only use the acknowledge mechanism. Keep it
            // for backward compatibility"""
            // if confirm_type in ['reminder', 'reception', 'decline']:
            //     return self.get_acknowledge_url()
            // return self.get_portal_url()
            */
            return default;
        }

        public async Task<TEntity> GetConfirmationTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetCopiableOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_copiable_order_lines(self):
            // """Returns the order lines that can be copied to a new order."""
            // return self.order_line.filtered(lambda l: not l.is_downpayment)
            */
            return default;
        }

        public async Task<TEntity> GetCopyMessageContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid to_currency_id, object date) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetDefaultCreateSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_default_create_section_values(self):
            // """ Return the default values for creating a section line in the purchase order through
            // catalog.
            // 
            // :return: A dictionary with default values for creating a new section.
            // :rtype: dict
            // """
            // return {'product_qty': 0}
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPaymentLinkValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_default_payment_link_values(self):
            // """ Override of `payment` to compute the default values of the payment link wizard. """
            // self.ensure_one()
            // 
            // prepayment_amount = self._get_prepayment_required_amount()
            // remaining_balance = self.amount_total - self.amount_paid
            // if self.state in ('draft', 'sent') and self.require_payment:
            //     suggested_amount = prepayment_amount  # Suggest the amount needed to confirm the quote.
            // else:  # The order is confirmed or doesn't require payment.
            //     suggested_amount = remaining_balance
            // return {
            //     'currency_id': self.currency_id.id,
            //     'partner_id': self.partner_invoice_id.id,
            //     'amount': suggested_amount,
            //     'amount_max': remaining_balance,
            //     'amount_paid': self.amount_paid,
            //     'prepayment_amount': prepayment_amount,
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultReadFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_default_read_fields(self):
            // weirdos = {'needed_terms', 'quick_encoding_vals', 'payment_term_details'}
            // return [fname for fname in self.fields_get(attributes=()) if fname not in weirdos]
            */
            return default;
        }

        public async Task<TEntity> GetDiscountAllocationAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetDomainIsLateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_domain_is_late(self, operator, value):
            // return Domain([('state', '=', 'purchase'), ('date_planned', '<=', fields.Datetime.now())])
            */
            return default;
        }

        public async Task<TEntity> GetEdiBuildersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_edi_builders(self):
            // return []
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_edi_builders(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetEdiCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetEdiDecoderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_data, object @new) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _get_edi_decoder(self, file_data, new=False):
            // """ Main method that should be overridden to implement decoders for various file types.
            // 
            // :param file_data: A dict representing an attachment which should be decoded.
            // :param new:       (optional) whether the business document was newly created.
            // :return:          A dict with the following keys:
            //     - decoder:     The decoder function to use. This function should return either None
            //                    if decoding was successful, or a string explaining why decoding failed.
            //     - priority:    The priority of the decoder.
            // """
            // pass
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_empty_list_help(self, help_message):
            // self = self.with_context(
            //     empty_list_help_document_name=_("sale order"),
            // )
            // return super().get_empty_list_help(help_message)
            */
            return default;
        }

        public async Task<TEntity> GetExtraPrintItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetFieldsToCopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetFieldsToDetachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> GetFrequentAccountAndTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> GetImportFileTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_data) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _get_import_file_type(self, file_data):
            // """ Method to be overridden to identify a file's format. """
            // if 'pdf' in file_data['mimetype'] or file_data['name'].endswith('.pdf'):
            //     return 'pdf'
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Requests for Quotation'),
            //     'template': '/purchase/static/xls/requests_for_quotation_import_template.xlsx',
            // }]
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Quotations'),
            //     'template': '/sale/static/xls/quotations_import_template.xlsx',
            // }]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_inbound_types(self, include_receipts=True):
            // return ['out_invoice', 'in_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetInstallmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetIntegrityHashFieldsAndSubfieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_integrity_hash_fields_and_subfields(self):
            // return self._get_integrity_hash_fields() + [f'line_ids.{subfield}' for subfield in self.line_ids._get_integrity_hash_fields()]
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceComputedReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aml_values_list, object open_balance) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountPerPaymentTermLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceCurrencyRateDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> GetInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceGroupingKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_invoice_grouping_keys(self):
            // return ['company_id', 'partner_id', 'partner_shipping_id', 'currency_id', 'fiscal_position_id']
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceInPaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceLegalDocumentsAllInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allow_fallback) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceLegalDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filetype, object allow_fallback) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceNextPaymentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoicePdfProformaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoicePortalExtraValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceProformaPdfReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceReferenceEuroInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceReferenceEuroPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceReferenceNumberInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceReferenceNumberPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceReferenceOdooInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceReferenceOdooPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetInvoiceReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object extension, object report) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> GetInvoiceTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_invoice_types(self, include_receipts=False):
            // return self.get_sale_types(include_receipts) + self.get_purchase_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object final) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_invoiceable_lines(self, final=False):
            // """Return the invoiceable lines for order `self`."""
            // down_payment_line_ids = []
            // invoiceable_line_ids = []
            // section_line_ids = []
            // subsection_line_ids = []
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
            // 
            // for line in self.order_line:
            //     if line.display_type == 'line_section':
            //         section_line_ids = [line.id]  # Start a new section.
            //         subsection_line_ids = []
            //         continue
            //     if line.display_type == 'line_subsection':
            //         subsection_line_ids = [line.id]  # Start a new subsection.
            //         continue
            //     if line.display_type != 'line_note' and float_is_zero(line.qty_to_invoice, precision_digits=precision):
            //         continue
            //     if line.qty_to_invoice > 0 or (line.qty_to_invoice < 0 and final) or line.display_type == 'line_note':
            //         if line.is_downpayment:
            //             # Keep down payment lines separately, to put them together
            //             # at the end of the invoice, in a specific dedicated section.
            //             down_payment_line_ids.append(line.id)
            //             continue
            //         # If the invoicable line is under subsection
            //         if subsection_line_ids:
            //             if line.display_type:
            //                 subsection_line_ids.append(line.id)
            //                 continue
            //             # Extend the subsection lines too if altleast one invoicable line is under subsection
            //             invoiceable_line_ids.extend(section_line_ids + subsection_line_ids)
            //             subsection_line_ids = []
            //             section_line_ids = []
            //         # If the invoicable line is under section
            //         elif section_line_ids:
            //             if line.display_type:
            //                 section_line_ids.append(line.id)
            //                 continue
            //             invoiceable_line_ids.extend(section_line_ids)
            //             section_line_ids = []
            //             subsection_line_ids = []
            //         invoiceable_line_ids.append(line.id)
            // 
            // return self.env['sale.order.line'].browse(invoiceable_line_ids + down_payment_line_ids)
            */
            return default;
        }

        public async Task<TEntity> GetInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_invoiced(self):
            // precision = self.env['decimal.precision'].precision_get('Product Unit')
            // for order in self:
            //     if order.state != 'purchase':
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

        public async Task<TEntity> GetLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetLastSequenceDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object relaxed) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetLinesOnchangeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_lines_onchange_currency(self):
            // # Override needed for COGS
            // return self.line_ids
            */
            return default;
        }

        public async Task<TEntity> GetLocalizedDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities, object date_planned) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetMailThreadDataAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetMoveDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object show_ref) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> GetMoveHashDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object common_domain, object force_hash) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetMoveLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetMoveZipExportDocsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetMovesRequiringConfirmationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetNameInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetNamePortalContentViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetNameTaxTotalsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_name_tax_totals_view(self):
            // """ This method can be inherited by localizations who want to localize the taxes displayed on the portal and sale order report. """
            // return 'sale.document_tax_totals'
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNoteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_note_url(self):
            // return self.env.company.get_base_url()
            */
            return default;
        }

        public async Task<TEntity> GetOrderLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            //     if line.is_downpayment:
            //         return (
            //             # Only show the down payment section if down payments were posted
            //             (line.display_type and down_payment_lines)
            //             # Only show posted down payments
            //             or line in down_payment_lines
            //         )
            //     return (
            //         line.display_type == 'line_section'
            //         or not (
            //             line.parent_id.collapse_composition
            //             or line.parent_id.parent_id.collapse_composition
            //         )
            //     )
            // 
            // return self.order_line.filtered(show_line)
            */
            return default;
        }

        public async Task<TEntity> GetOrderTimezoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> GetOrdersToRemindInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_orders_to_remind(self):
            // """When auto sending a reminder mail, only send for unconfirmed purchase
            // order and not all products are service."""
            // return self.search([
            //     ('partner_id', '!=', False),
            //     ('state', '=', 'purchase'),
            //     ('acknowledged', '=', False),
            //     ('receipt_reminder_email', '=', True)
            // ]).filtered(lambda p: p.mapped('order_line.product_id.product_tmpl_id.type') != ['service'])
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOutboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_outbound_types(self, include_receipts=True):
            // return ['in_invoice', 'out_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetParentFieldOnChildModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_parent_field_on_child_model(self):
            // return 'move_id'
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_parent_field_on_child_model(self):
            // return 'order_id'
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_parent_field_on_child_model(self):
            // return 'order_id'
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCreditWarningExcludeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetPortalLastTransactionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def get_portal_last_transaction(self):
            // self.ensure_one()
            // return self.sudo().transaction_ids._get_last()
            */
            return default;
        }

        public async Task<TEntity> GetPortalPaymentLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetPortalReturnActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetPrepaymentRequiredAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_prepayment_required_amount(self):
            // """ Return the minimum amount needed to automatically confirm the quotation.
            // 
            // Note: self.ensure_one()
            // 
            // :return: The minimum amount needed to automatically confirm the quotation.
            // :rtype: float
            // """
            // self.ensure_one()
            // 
            // if not self.require_payment:
            //     return 0
            // else:
            //     return self.currency_id.round(self.amount_total * self.prepayment_percent)
            */
            return default;
        }

        public async Task<TEntity> GetPricedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_priced_lines(self):
            // return self.order_line.filtered(lambda x: not x.display_type)
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_catalog_domain(self):
            // return super()._get_product_catalog_domain() & Domain('purchase_ok', '=', True)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_catalog_domain(self):
            // return super()._get_product_catalog_domain() & Domain('sale_ok', '=', True)
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogOrderDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            // has_warning_group = self.env.user.has_group('sale.group_warning_sale')
            // for product in products:
            //     res[product.id]['price'] = pricelist.get(product.id)
            //     if product.sale_line_warn_msg and has_warning_group:
            //         res[product.id]['warning'] = product.sale_line_warn_msg
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogRecordLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_ids) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, *, section_id=None, **kwargs):
            // grouped_lines = defaultdict(lambda: self.env['purchase.order.line'])
            // if section_id is None:
            //     section_id = (
            //         self.order_line[:1].id
            //         if self.order_line[:1].display_type == 'line_section'
            //         else False
            //     )
            // for line in self.order_line:
            //     if (
            //         line.display_type
            //         or line.product_id.id not in product_ids
            //         or line.get_parent_section_line().id != section_id
            //     ):
            //         continue
            //     grouped_lines[line.product_id] |= line
            // return grouped_lines
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_product_catalog_record_lines(self, product_ids, *, section_id=None, **kwargs):
            // grouped_lines = defaultdict(lambda: self.env['sale.order.line'])
            // if section_id is None:
            //     section_id = (
            //         self.order_line[:1].id
            //         if self.order_line[:1].display_type == 'line_section'
            //         else False
            //     )
            // for line in self.order_line:
            //     if (
            //         line.display_type
            //         or line.product_id.id not in product_ids
            //         or line.get_parent_section_line().id != section_id
            //     ):
            //         continue
            //     grouped_lines[line.product_id] |= line
            // return grouped_lines
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetProductPriceAndDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            //     'uomDisplayName': product.uom_id.display_name
            // }
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
            //     product_uom = (seller.product_id or seller.product_tmpl_id).uom_id
            //     price = seller.price_discounted
            //     if seller.currency_id != self.currency_id:
            //         price = seller.currency_id._convert(price, self.currency_id)
            //     if seller.product_uom_id != product_uom:
            //         # The discounted price is expressed in the product's UoM, not in the vendor
            //         # price's UoM, so we need to convert it into to match the displayed UoM.
            //         price = product_uom._compute_price(price, seller.product_uom_id)
            //         product_infos.update(uomFactor=seller.product_uom_id.factor / product_uom.factor)
            //     product_infos.update(
            //         price=price,
            //         min_qty=seller.min_qty,
            //         uomDisplayName=seller.product_uom_id.display_name,
            //     )
            // 
            // return product_infos
            */
            return default;
        }

        public async Task<TEntity> GetProtectedValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object records) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> GetPurchaseTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_purchase_types(self, include_receipts=False):
            // return ['in_invoice', 'in_refund'] + (include_receipts and ['in_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetQuickEditSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetReconciledAmlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetReconciledInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_invoices(self):
            // """Helper used to retrieve the reconciled invoices on this journal entry"""
            // return self._get_reconciled_amls().move_id.filtered(lambda move: move.is_invoice(include_receipts=True))
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesPartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetReconciledPaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_payments(self):
            // """Helper used to retrieve the reconciled payments on this journal entry"""
            // return self._get_reconciled_amls().move_id.origin_payment_id
            */
            return default;
        }

        public async Task<TEntity> GetReconciledStatementLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _get_reconciled_statement_lines(self):
            // """Helper used to retrieve the reconciled statement lines on this journal entry"""
            // return self._get_reconciled_amls().move_id.statement_line_id
            */
            return default;
        }

        public async Task<TEntity> GetReportBaseFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetRoundedBaseAndTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object round_from_tax_lines) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> GetSaleTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def get_sale_types(self, include_receipts=False):
            // return ['out_invoice', 'out_refund'] + (include_receipts and ['out_receipt'] or [])
            */
            return default;
        }

        public async Task<TEntity> GetSequenceDateRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reset) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetSimilarityScoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filename1, object filename2) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _get_similarity_score(self, filename1, filename2):
            // """ Compute a similarity score between two filenames.
            //     This is used to group files with similar names together as much as possible
            //     when figuring out how to dispatch attachments received in a mail alias.
            // 
            //     Similarity is defined as the length of the largest common substring between
            //     the two filenames.
            // """
            // matcher = difflib.SequenceMatcher(a=filename1, b=filename2, autojunk=False)
            // return matcher.find_longest_match().size
            */
            return default;
        }

        public async Task<TEntity> GetStartingSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> GetSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type, object company) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetSyncStackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetUnbalancedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetUnlinkLoggerMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetUpdatePricesLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _get_update_prices_lines(self):
            // """ Hook to exclude specific lines which should not be updated based on price list recomputation """
            // return self.order_line.filtered(lambda line: not line.display_type)
            */
            return default;
        }

        public async Task<TEntity> GetUpdateUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetValidJournalTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> GetViolatedLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> GetXmlTreeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_data) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _get_xml_tree(self, file_data):
            // """ Parse file_data['raw'] into an lxml.etree.ElementTree.
            //     Can be overridden if custom decoding is needed.
            // """
            // if (
            //     # XML attachments received by mail have a 'text/plain' mimetype.
            //     'text/plain' in file_data['mimetype'] and (guess_mimetype(file_data['raw'] or b'').endswith('/xml') or file_data['name'].endswith('.xml'))
            //     or file_data['mimetype'].endswith('/xml')
            // ):
            //     try:
            //         return etree.fromstring(file_data['raw'])
            //     except etree.ParseError as e:
            //         _logger.info('Error when reading the xml file "%s": %s', file_data['name'], e)
            */
            return default;
        }

        public async Task<TEntity> GroupFilesDataByOriginAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files_data) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _group_files_data_by_origin_attachment(self, files_data):
            // """ A naive grouping method which does the following:
            // 
            //     - if a file_data has an 'origin_attachment', it is assigned to the same group as the 'origin_attachment'.
            //     - otherwise, it is assigned to a new group.
            // """
            // return [
            //     file_data_group
            //     for origin_attachment, file_data_group
            //     in groupby(files_data, lambda file_data: file_data['origin_attachment'])
            // ]
            */
            return default;
        }

        public async Task<TEntity> GroupFilesDataIntoGroupsOfMixedTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files_data) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _group_files_data_into_groups_of_mixed_types(self, files_data):
            // """ A grouping method with a heuristic that enables it to dispatch files of the same type to
            //     different groups, but files of different types to the same group.
            // 
            //     This makes it suitable for grouping attachments received through a journal mail alias.
            //     For example, receiving 5 PDFs will dispatch them into 5 groups (one per PDF),
            //     but receiving one PDF, one JPG and one XML will dispatch them all into a single group.
            // """
            // files_data_with_origin_attachment = []
            // files_data_without_origin_attachment = []
            // for file_data in files_data:
            //     if 'decoder_info' not in file_data:
            //         file_data['decoder_info'] = self._get_edi_decoder(file_data, new=True)
            // 
            //     if file_data['origin_attachment'] == file_data['attachment']:
            //         files_data_without_origin_attachment.append(file_data)
            //     else:
            //         files_data_with_origin_attachment.append(file_data)
            // 
            // groups = []
            // # First dispatch the files_data that don't have an origin_attachment.
            // sorted_files_data = sorted(
            //     files_data_without_origin_attachment,
            //     key=lambda file_data: (file_data['decoder_info'] or {}).get('priority', 0),
            //     reverse=True,
            // )
            // for file_data in sorted_files_data:
            //     self._assign_attachment_to_group_of_different_type(file_data, groups)
            // 
            // # Then dispatch the files_data that have an origin_attachment.
            // for file_data in files_data_with_origin_attachment:
            //     self._assign_attachment_to_group_with_same_origin_attachment(file_data, groups)
            // 
            // return groups
            */
            return default;
        }

        public async Task<TEntity> HasToBePaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> HasToBeSignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> HashMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InverseAmountTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InverseCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InverseInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InverseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InverseNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InversePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InversePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InverseTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> InvoicePaidHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _invoice_paid_hook(self):
            // ''' Hook to be overrided called when the invoice moves to the paid state. '''
            */
            return default;
        }

        public async Task<TEntity> IsActionReportAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action_report, object is_invoice_report) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> IsConfirmationAmountReachedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> IsDownpaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> IsEligibleForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object currency, object reference_date) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> IsEntryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_entry(self):
            // return self.move_type == 'entry'
            */
            return default;
        }

        public async Task<TEntity> IsInboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_inbound(self, include_receipts=True):
            // return self.move_type in self.get_inbound_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_invoice(self, include_receipts=False):
            // return self.is_sale_document(include_receipts) or self.is_purchase_document(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsLineValidForSectionLineCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> IsMoveRestrictedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object force_hash) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> IsOutboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_outbound(self, include_receipts=True):
            // return self.move_type in self.get_outbound_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> IsProtectedByAuditTrailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_protected_by_audit_trail(self):
            // return any(move.posted_before and move.company_id.restrictive_audit_trail for move in self)
            */
            return default;
        }

        public async Task<TEntity> IsPurchaseDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_purchase_document(self, include_receipts=False, move_type=False):
            // return (move_type or self.move_type) in self.get_purchase_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> IsReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> IsReceiptAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_receipt(self):
            // return self.move_type in ['out_receipt', 'in_receipt']
            */
            return default;
        }

        public async Task<TEntity> IsSaleDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def is_sale_document(self, include_receipts=False, move_type=False):
            // return (move_type or self.move_type) in self.get_sale_types(include_receipts)
            */
            return default;
        }

        public async Task<TEntity> IsUserAbleToReviewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _is_user_able_to_review(self):
            // # If only account is installed, we don't check user access rights.
            // return True
            */
            return default;
        }

        public async Task<TEntity> JsAssignOutstandingLineAsync<TEntity>(IEnumerable<TEntity> entities, Guid line_id) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> JsRemoveOutstandingPartialAsync<TEntity>(IEnumerable<TEntity> entities, Guid partial_id) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> LinkBillOriginToPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timeout) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> MailingGetDefaultDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mailing) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _mailing_get_default_domain(self, mailing):
            // return ['&', ('move_type', '=', 'out_invoice'), ('state', '=', 'posted')]
            */
            return default;
        }

        public async Task<TEntity> MergeAlternativePoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfqs) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _merge_alternative_po(self, rfqs):
            // pass
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_message, object message_values) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def message_post(self, **kwargs):
            // if self.env.context.get('mark_rfq_as_sent'):
            //     self.filtered(lambda o: o.state == 'draft').write({'state': 'sent'})
            //     kwargs['notify_author_mention'] = kwargs.get('notify_author_mention', True)
            // return super().message_post(**kwargs)
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def message_post(self, **kwargs):
            // if self.env.context.get('mark_so_as_sent'):
            //     self.filtered(lambda o: o.state == 'draft').with_context(tracking_disable=True).write({'state': 'sent'})
            //     kwargs['notify_author_mention'] = kwargs.get('notify_author_mention', True)
            // return super().message_post(**kwargs)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MoveDictToPreviewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals, Guid currency_id) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> MustCheckConstrainsDateSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _must_check_constrains_date_sequence(self):
            // # OVERRIDES sequence.mixin
            // return self.state == 'posted' and not self.quick_edit_mode
            */
            return default;
        }

        public async Task<TEntity> MustDeleteDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _must_delete_date_planned(self, field_name):
            // # To be overridden
            // return field_name == 'order_line'
            */
            return default;
        }

        public async Task<TEntity> NeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> NothingToInvoiceErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False,
            //                                            force_record_name=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals=msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang,
            //     force_record_name=force_record_name,
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
            //                                            force_email_company=False, force_email_lang=False,
            //                                            force_record_name=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals=msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang,
            //     force_record_name=force_record_name,
            // )
            // lang_code = render_context.get('lang')
            // record = render_context['record']
            // subtitles = [f"{record.name} - {record.partner_id.name}" if record.partner_id.name else record.name]
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

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // # Tweak 'view document' button for portal customers, calling directly routes for confirm specific to PO model.
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
            //     else:
            //         access_opt.update(
            //             title=_("View Quotation") if self.state in ('draft', 'sent') else _("View Order"),
            //             url=self.get_base_url() + self.get_confirm_url(),
            //         )
            // 
            // return groups
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // # Give access button to users and portal customer as portal is integrated
            // # in sale. Customer and portal group have probably no right to see
            // # the document so they don't have the access button.
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // if self.env.context.get('proforma'):
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

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, object values, object field_names, object fields_spec) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            // if not field_names:
            //     self_with_context = self.with_context(
            //         # Some warnings should not be displayed for the first onchange
            //         sale_onchange_first_call=True,
            //         # invoice & delivery address with higher `customer_rank` should take priority
            //         res_partner_search_mode='customer',
            //     )
            // return super(SaleOrder, self_with_context).onchange(values, field_names, fields_spec)
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommitmentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangeCompanyIdWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _onchange_date(self):
            // if not self.is_invoice(True):
            //     self.line_ids._inverse_amount_currency()
            */
            return default;
        }

        public async Task<TEntity> OnchangeDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def onchange_date_planned(self):
            // if self.date_planned:
            //     self.order_line.filtered(lambda line: not line.display_type).date_planned = self.date_planned
            */
            return default;
        }

        public async Task<TEntity> OnchangeFposIdShowUpdateFposInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangeInvoiceCashRoundingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangeInvoiceVendorBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangeNameWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangeOrderLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_order_line(self):
            // for index, line in enumerate(self.order_line):
            //     combo_item_lines = line._get_linked_lines().filtered('combo_item_id')
            //     if line.product_template_id.type != 'combo':
            //         if combo_item_lines:
            //             # Delete any linked combo item lines if the line's product is no longer a combo
            //             # product.
            //             self.order_line = [
            //                 Command.delete(linked_line.id) for linked_line in combo_item_lines
            //             ]
            //     elif line.selected_combo_items:
            //         selected_combo_items = json.loads(line.selected_combo_items)
            //         if (
            //             selected_combo_items
            //             and len(selected_combo_items) != len(line.product_template_id.sudo().combo_ids)
            //         ):
            //             raise ValidationError(_(
            //                 "The number of selected combo items must match the number of available"
            //                 " combo choices."
            //             ))
            // 
            //         # Delete any existing combo item lines.
            //         delete_commands = [Command.delete(linked_line.id) for linked_line in combo_item_lines]
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
            //             {'sequence': order_line.sequence + len(selected_combo_items)},
            //         ) for order_line in self.order_line if order_line.sequence > line.sequence]
            // 
            //         # Clear `selected_combo_items` to avoid applying the same changes multiple times.
            //         line.selected_combo_items = False
            //         self.order_line = delete_commands + create_commands + update_commands
            //     elif (
            //         combo_item_lines
            //         # Only update the combo item lines if the line's combo choices haven't changed.
            //         and combo_item_lines.combo_item_id.combo_id == line.product_template_id.combo_ids
            //     ):
            //         combo_item_lines.update({
            //             'product_uom_qty': line.product_uom_qty,
            //             'discount': line.discount,
            //         })
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def onchange_partner_id(self):
            // # Ensures all properties and fiscal positions
            // # are taken with the company of the order
            // # if not defined, with_company doesn't change anything.
            // self = self.with_company(self.company_id)
            // if not self.partner_id:
            //     self.fiscal_position_id = False
            // else:
            //     self.fiscal_position_id = self.env['account.fiscal.position']._get_fiscal_position(self.partner_id)
            //     self.payment_term_id = self.partner_id.property_supplier_payment_term_id.id
            //     if self.partner_id.buyer_id:
            //         self.user_id = self.partner_id.buyer_id
            // return {}
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_prepayment_percent(self):
            // if not self.prepayment_percent:
            //     self.require_payment = False
            */
            return default;
        }

        public async Task<TEntity> OnchangePricelistIdShowUpdatePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _onchange_pricelist_id_show_update_prices(self):
            // self.show_update_pricelist = bool(self.order_line)
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OnchangeQuickEditTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OpenAdjustingEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_adjusting_entries(self):
            // self.ensure_one()
            // return self.adjusting_entries_move_ids._get_records_action(name="Adjusting Entries")
            */
            return default;
        }

        public async Task<TEntity> OpenAdjustingEntryOriginMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OpenCreatedCabaEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> OpenPaymentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_payments(self):
            // payments = self.reconciled_payment_ids
            // return payments._get_records_action(name=_("Payments"))
            */
            return default;
        }

        public async Task<TEntity> OpenReconcileViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def open_reconcile_view(self):
            // return self.line_ids.open_reconcile_view()
            */
            return default;
        }

        public async Task<TEntity> PaymentActionCaptureAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def payment_action_capture(self):
            // """ Capture all transactions linked to this sale order. """
            // self.ensure_one()
            // payment_utils.check_rights_on_recordset(self)
            // 
            // # In sudo mode to bypass the checks on the rights on the transactions.
            // return self.sudo().transaction_ids.action_capture()
            */
            return default;
        }

        public async Task<TEntity> PaymentActionVoidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def payment_action_void(self):
            // """ Void all transactions linked to this sale order. """
            // payment_utils.check_rights_on_recordset(self)
            // 
            // # In sudo mode to bypass the checks on the rights on the transactions.
            // self.sudo().authorized_transaction_ids.action_void()
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareAnalyticAccountDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object prefix) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareCashRoundingBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_rounding_line) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareConfirmationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareDownPaymentLineSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_down_payment_line_section_values(self):
            // """ Prepare the values to create a section line for the down payment on the current SO.
            // 
            // :return: A dictionary to create a new SO section line.
            // """
            // self.ensure_one()
            // return {
            //     'order_id': self.id,
            //     'display_type': 'line_section',
            //     'is_downpayment': True,
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentLineValuesFromBaseLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _prepare_down_payment_line_values_from_base_line(self, base_line):
            // """ Convert the base line passed as parameter representing a down payment into a
            // dictionary to be converted into a sale order line in the current sale order.
            // 
            // :param base_line: A base line (see '_prepare_base_line_for_taxes_computation').
            // :return: A dictionary to create a new SO line.
            // """
            // self.ensure_one()
            // extra_tax_data = self.env['account.tax']._export_base_line_extra_tax_data(base_line)
            // return {
            //     'order_id': self.id,
            //     'is_downpayment': True,
            //     'product_uom_qty': 0.0,
            //     'price_unit': base_line['price_unit'],
            //     'tax_ids': [Command.set(base_line['tax_ids'].ids)],
            //     'analytic_distribution': base_line['analytic_distribution'],
            //     'extra_tax_data': extra_tax_data,
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentSectionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareDownPaymentSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareEdiValsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareEpdBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object epd_line) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareEpdBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareGroupedDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfq) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_grouped_data(self, rfq):
            // return (rfq.partner_id.id, rfq.currency_id.id, rfq.dest_address_id.id)
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceAggregatedTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filter_invl_to_apply, object filter_tax_values_to_apply, object grouping_key_generator, object round_from_tax_lines, object postfix_function) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _prepare_invoice(self):
            // """Prepare the dict of values to create the new invoice for a purchase order.
            // """
            // self.ensure_one()
            // move_type = self.env.context.get('default_move_type', 'in_invoice')
            // 
            // partner_invoice = self.env['res.partner'].browse(self.partner_id.address_get(['invoice'])['invoice'])
            // partner_bank_id = self.partner_id.commercial_partner_id.bank_ids.filtered_domain(['|', ('company_id', '=', False), ('company_id', '=', self.company_id.id)])[:1]
            // 
            // invoice_vals = {
            //     'move_type': move_type,
            //     'narration': self.note,
            //     'currency_id': self.currency_id.id,
            //     'partner_id': partner_invoice.id,
            //     'fiscal_position_id': (self.fiscal_position_id or self.fiscal_position_id._get_fiscal_position(partner_invoice)).id,
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
            // txs_to_be_linked = self.sudo().transaction_ids.filtered(
            //     lambda tx: (
            //         tx.state in ('pending', 'authorized')
            //         or (tx.state == 'done' and not tx.payment_id.is_reconciled)
            //     )
            // )
            // 
            // values = {
            //     'ref': self.client_order_ref or self.name,
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
            //     'preferred_payment_method_line_id': self.preferred_payment_method_line_id.id,
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

        public async Task<TEntity> PrepareNonDeductibleBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object non_deductible_line) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareNonDeductibleBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareProductBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_line) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareSupplierInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object line, object price, object currency) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareTaxLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_line) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrepareTaxLinesForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_amls, object round_from_tax_lines) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PreviewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> PrintQuotationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def print_quotation(self):
            // self.filtered(lambda po: po.state == 'draft').write({'state': "sent"})
            // return self.env.ref('purchase.report_purchase_quotation').report_action(self)
            */
            return default;
        }

        public async Task<TEntity> QuickEditModeSuggestInvoiceDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def read(self, fields=None, load='_classic_read'):
            // fields = fields or self._get_default_read_fields()
            // return super().read(fields, load)
            */
            return default;
        }

        public async Task<TEntity> ReasonCannotDecodeHasInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> RecNamesSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _rec_names_search(self):
            // if self.env.context.get('sale_show_partner_name'):
            //     return ['name', 'partner_id.name']
            // return ['name']
            */
            return default;
        }

        public async Task<TEntity> RecomputeCashRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> RecomputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> RecomputeTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _recompute_taxes(self):
            // lines_to_recompute = self.order_line.filtered(lambda line: not line.display_type)
            // lines_to_recompute._compute_tax_ids()
            // self.show_update_fpos = False
            */
            return default;
        }

        public async Task<TEntity> ReconcileReversedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse_moves, object move_reverse_cancel) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> RefreshInvoiceCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def refresh_invoice_currency_rate(self):
            // for move in self:
            //     move.invoice_currency_rate = move.expected_currency_rate
            */
            return default;
        }

        public async Task<TEntity> RefundsOriginRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _refunds_origin_required(self):
            // return False
            */
            return default;
        }

        public async Task<TEntity> RequireBillDateForAutopostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> RetrieveDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def retrieve_dashboard(self):
            // """ This function returns the values to populate the custom dashboard in
            //     the purchase order views.
            // """
            // if not self.env.user._is_internal():
            //     raise AccessDenied()
            // self.browse().check_access('read')
            // 
            // result = {
            //     'global': {
            //         'draft': {'all': 0, 'priority': 0},
            //         'sent':  {'all': 0, 'priority': 0},
            //         'late':  {'all': 0, 'priority': 0},
            //         'not_acknowledged': {'all': 0, 'priority': 0},
            //         'late_receipt': {'all': 0, 'priority': 0},
            //         'days_to_order': 0,
            //     },
            //     'my': {
            //         'draft': {'all': 0, 'priority': 0},
            //         'sent':  {'all': 0, 'priority': 0},
            //         'late':  {'all': 0, 'priority': 0},
            //         'not_acknowledged': {'all': 0, 'priority': 0},
            //         'late_receipt': {'all': 0, 'priority': 0},
            //         'days_to_order': 0,
            //     },
            //     'days_to_purchase': 0,
            // }
            // 
            // def _update(key, dict_to_update, group):
            //     for priority, user_id, count in group:
            //         my = user_id == self.env.user
            //         dict_to_update['global'][key]['all'] += count
            //         if priority != '0':
            //             dict_to_update['global'][key]['priority'] += count
            //         if not my:
            //             continue
            //         dict_to_update['my'][key]['all'] += count
            //         if priority != '0':
            //             dict_to_update['my'][key]['priority'] += count
            // 
            // # easy counts
            // groupby = ['priority', 'user_id']
            // aggregate = ['id:count_distinct']
            // rfq_draft_domain = [('state', '=', 'draft')]
            // rfq_draft_group = self.env['purchase.order']._read_group(rfq_draft_domain, groupby, aggregate)
            // _update('draft', result, rfq_draft_group)
            // 
            // rfq_sent_domain = [('state', '=', 'sent')]
            // rfq_sent_group = self.env['purchase.order']._read_group(rfq_sent_domain, groupby, aggregate)
            // _update('sent', result, rfq_sent_group)
            // 
            // rfq_late_domain = [('state', 'in', ['draft', 'sent', 'to approve']), ('date_order', '<', fields.Datetime.now())]
            // rfq_late_group = self.env['purchase.order']._read_group(rfq_late_domain, groupby, aggregate)
            // _update('late', result, rfq_late_group)
            // 
            // rfq_not_acknowledge = [('state', 'in', ['purchase', 'done']), ('acknowledged', '=', False)]
            // rfq_not_acknowledge_group = self.env['purchase.order']._read_group(rfq_not_acknowledge, groupby, aggregate)
            // _update('not_acknowledged', result, rfq_not_acknowledge_group)
            // 
            // rfq_late_receipt = [('state', 'in', ['purchase', 'done']), ('is_late', '=', True)]
            // rfq_late_receipt_group = self.env['purchase.order']._read_group(rfq_late_receipt, groupby, aggregate)
            // _update('late_receipt', result, rfq_late_receipt_group)
            // 
            // three_months_ago = fields.Datetime.to_string(fields.Datetime.now() - relativedelta(months=3))
            // 
            // purchases = self.env['purchase.order'].search_fetch(
            //     [('state', '=', 'purchase'), ('create_date', '>=', three_months_ago), ('date_approve', '!=', False)],
            //     ['create_date', 'date_approve', 'user_id'])
            // 
            // global_deliveries_seconds = 0
            // my_deliveries_seconds = 0
            // my_deliveries_count = 0
            // 
            // for po in purchases:
            //     delivery_seconds = (po.date_approve - po.create_date).total_seconds()
            //     global_deliveries_seconds += delivery_seconds
            //     if po.user_id == self.env.user:
            //         my_deliveries_seconds += delivery_seconds
            //         my_deliveries_count += 1
            // 
            // avg_global_deliveries_seconds = global_deliveries_seconds / len(purchases) if purchases else 0
            // avg_my_deliveries_seconds = my_deliveries_seconds / my_deliveries_count if my_deliveries_count else 0
            // result['global']['days_to_order'] = float_repr(avg_global_deliveries_seconds / 60 / 60 / 24, precision_digits=2)
            // result['my']['days_to_order'] = float_repr(avg_my_deliveries_seconds / 60 / 60 / 24, precision_digits=2)
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> ReverseMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_values_list, object cancel) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> RoutingCheckRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object route, object raise_exception) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SearchDefaultJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SearchInvoiceIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _search_invoice_ids(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // if operator == 'in' and value:
            //     falsy_domain = []
            //     if False in value:
            //         # special case for [('invoice_ids', '=', False)], i.e. "Invoices is not set"
            //         #
            //         # We cannot just search [('order_line.invoice_lines', '=', False)]
            //         # because it returns orders with uninvoiced lines, which is not
            //         # same "Invoices is not set" (some lines may have invoices and some
            //         # don't)
            //         #
            //         # A solution is using the 'not any' operators with inverted search first
            //         # ("orders with invoiced lines").
            //         falsy_domain = [('order_line', 'not any', [
            //             ('invoice_lines.move_id.move_type', 'in', ('out_invoice', 'out_refund'))
            //         ])]
            //         if len(value) == 1:
            //             return falsy_domain
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
            //     return [('id', 'in', so_ids)] + falsy_domain
            // return [('order_line.invoice_lines', 'any', [
            //     ('move_id.move_type', 'in', ('out_invoice', 'out_refund')),
            //     ('move_id', operator, value),
            // ])]
            */
            return default;
        }

        public async Task<TEntity> SearchIsLateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _search_is_late(self, operator, value):
            // if operator not in ["=", "!="]:
            //     raise ValidationError(self.env._("Unsupported operator"))
            // purchase_domain = self._get_domain_is_late(operator, value)
            // if operator == "=" and value or operator == "!=" and not value:
            //     purchase_lines_late = Domain('order_id', 'any', purchase_domain) & Domain.custom(
            //         to_sql=lambda model, alias, query: SQL(
            //             "%s < %s",
            //             model._field_to_sql(alias, 'qty_received', query),
            //             model._field_to_sql(alias, 'product_qty', query),
            //         )
            //     )
            //     return Domain('order_line', 'any', purchase_lines_late)
            // else:
            //     purchase_lines_on_time = Domain('order_id', 'any', purchase_domain) & Domain.custom(
            //         to_sql=lambda model, alias, query: SQL(
            //             "%s >= %s",
            //             model._field_to_sql(alias, 'qty_received', query),
            //             model._field_to_sql(alias, 'product_qty', query),
            //         )
            //     )
            //     return Domain('order_line', 'any', purchase_lines_on_time)
            */
            return default;
        }

        public async Task<TEntity> SearchJournalGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SearchMoveSentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SearchNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> SearchReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def search_read(self, domain=None, fields=None, offset=0, limit=None, order=None, **read_kwargs):
            // fields = fields or self._get_default_read_fields()
            // return super().search_read(domain, fields, offset, limit, order, **read_kwargs)
            */
            return default;
        }

        public async Task<TEntity> SearchReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SearchSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SelectExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expected_dates) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _select_expected_date(self, expected_dates):
            // self.ensure_one()
            // return min(expected_dates)
            */
            return default;
        }

        public async Task<TEntity> SendOnlyWhenReadyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SendOrderConfirmationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SendOrderNotificationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object allow_deferred_sending) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _send_order_notification_mail(self, mail_template, allow_deferred_sending=True):
            // """ Send a mail to the customer.
            // 
            // If the `sale.async_emails` ICP is set and `allow_deferred_sending` is true, order status
            // emails are sent asynchronously through a cron.
            // 
            // Note: self.ensure_one()
            // 
            // :param mail.template mail_template: the template used to generate the mail
            // :param bool allow_deferred_sending: Whether the email can be sent asynchronously.
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
            // async_send = str2bool(self.env['ir.config_parameter'].sudo().get_param('sale.async_emails'))
            // cron = self.env.ref('sale.send_pending_emails_cron', raise_if_not_found=False)
            // cron_enabled = cron and cron.sudo().active
            // if async_send and cron_enabled and allow_deferred_sending:
            //     # Schedule the email to be sent asynchronously.
            //     self.pending_email_template_id = mail_template
            //     cron._trigger()
            // else:  # Async emails are disabled, either by the user or we are in the cron job.
            //     # Send the email synchronously.
            //     self.with_context(force_send=True).message_post_with_source(
            //         mail_template,
            //         email_layout_xmlid='mail.mail_notification_layout_with_responsible_signature',
            //         subtype_xmlid='mail.mt_comment',
            //     )
            */
            return default;
        }

        public async Task<TEntity> SendPaymentSucceededForOrderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SendReminderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object send_single) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SendReminderOpenComposerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SendReminderPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SequenceFixedRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_fixed_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_fixed_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_monthly_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_monthly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_monthly_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_year_range_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_year_range_regex
            */
            return default;
        }

        public async Task<TEntity> SequenceYearlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def _sequence_yearly_regex(self):
            // return self.journal_id.sequence_override_regex or super()._sequence_yearly_regex
            */
            return default;
        }

        public async Task<TEntity> SetMovesCheckedAsync<TEntity>(IEnumerable<TEntity> entities, object is_checked) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move.py) ---
            // def set_moves_checked(self, is_checked=True):
            // for move in self.filtered(lambda m: m.state == 'posted'):
            //     move.checked = is_checked
            */
            return default;
        }

        public async Task<TEntity> SetNextMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities, bool made_gap) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SetReversedEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credit_note) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ShouldAttachToRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _should_attach_to_record(self, attachment):
            // """ Indicate whether a given attachment should be displayed in the record's attachments. """
            // return attachment and not attachment.res_field and attachment.mimetype in {
            //     'text/csv',
            //     'application/pdf',
            //     'application/vnd.ms-excel',
            //     'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
            //     'application/vnd.oasis.opendocument.spreadsheet',
            //     'application/msword',
            //     'application/vnd.openxmlformats-officedocument.wordprocessingml.document',
            //     'application/vnd.ms-powerpoint',
            //     'application/vnd.openxmlformats-officedocument.presentationml.presentation',
            //     'application/vnd.oasis.opendocument.presentation',
            // }
            */
            return default;
        }

        public async Task<TEntity> ShouldBeLockedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _should_be_locked(self):
            // self.ensure_one()
            // # Public user can confirm SO, so we check the group on any record creator.
            // return self.env['res.groups']._is_feature_enabled('sale.group_auto_done_setting')
            */
            return default;
        }

        public async Task<TEntity> ShowAutopostBillsWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> SplitXmlIntoNewAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_data, object tag) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _split_xml_into_new_attachments(self, file_data, tag):
            //     """ Helper method to split an XML file into multiple files on a given tag.
            // 
            //     In EDIs, some XMLs contain multiple business documents.
            //     In such cases, we often want any business document beyond the first to have its
            //     own attachment that can be decoded separately.
            //     This helper method looks whether the provided XML tree (given in `file_data`) has multiple
            //     instances of the given `tag`, and creates a new attachment for each tag beyond the first.
            //     The new attachment has the same XML structure as the original file, but only has one instance
            //     of the specified tag.
            // 
            //     :param file_data: The XML file to split
            //     :param tag: The tag which the XML file should be split on if there are multiple instances of it
            //     :return: a `files_data` list of files, for each business document beyond the first.
            // """
            //     new_files_data = []
            //     if len(file_data['xml_tree'].findall(f'.//{tag}')) > 1:
            //         # Create a new xml tree for each invoice beyond the first
            //         trees = split_etree_on_tag(file_data['xml_tree'], tag)
            //         filename_without_extension, _dummy, extension = file_data['name'].rpartition('.')
            //         attachment_vals = [
            //             {
            //                 'name': f'{filename_without_extension}_{filename_index}.{extension}',
            //                 'raw': etree.tostring(tree),
            //             }
            //             for filename_index, tree in enumerate(trees[1:], start=2)
            //         ]
            //         created_attachments = self.env['ir.attachment'].create(attachment_vals)
            // 
            //         new_files_data.extend(self._to_files_data(created_attachments))
            //     return new_files_data
            */
            return default;
        }

        public async Task<TEntity> StolenMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SyncDynamicLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object existing_key_fname, object needed_vals_fname, object needed_dirty_fname, object line_type, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
        public async Task<TEntity> SyncDynamicLineNeededValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SyncDynamicLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SyncInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SyncNonDeductibleBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SyncRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SyncTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SyncUnbalancedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> SynchronizeBusinessModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changed_fields) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> ToFilesDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _to_files_data(self, attachments):
            // """ Helper method to convert an ir.attachment recordset into an intermediate `files_data` format
            //     used by the import framework.
            // 
            //     :return: a list of dicts, each dict representing one of the attachments in `self`.
            // """
            // files_data = []
            // for attachment in attachments:
            //     file_data = {
            //         'name': attachment.name,
            //         'raw': attachment.raw,
            //         'mimetype': attachment.mimetype,
            //         'origin_attachment': attachment,
            //         'attachment': attachment,
            //     }
            //     file_data['xml_tree'] = self._get_xml_tree(file_data)
            //     file_data['import_file_type'] = self._get_import_file_type(file_data)
            //     file_data['origin_import_file_type'] = file_data['import_file_type']
            //     files_data.append(file_data)
            // return files_data
            */
            return default;
        }

        public async Task<TEntity> TrackFinalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'state' in init_values and self.state == 'purchase':
            //     if init_values['state'] == 'to approve':
            //         return self.env.ref('purchase.mt_rfq_approved')
            //     return self.env.ref('purchase.mt_rfq_confirmed')
            // elif 'state' in init_values and self.state == 'to approve':
            //     return self.env.ref('purchase.mt_rfq_confirmed')
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

        public async Task<TEntity> UnlinkAccountAuditTrailExceptOncePostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDraftOrCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> UnlinkForbidPartsOfChainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> UnlinkIfCancelledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> UnlinkOrReverseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        [ApiModel]
        public async Task<TEntity> UnwrapAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_data, object recurse) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _unwrap_attachment(self, file_data, recurse=True):
            // """ Unwrap a single attachment and return its embedded attachments.
            // 
            // This method can be overridden to implement custom unwrapping behaviours
            // (e.g. EDI formats which contain multiple business documents in a single file)
            // 
            // :param file_data: The file to be unwrapped.
            // :param recurse: if True, should return embedded-of-embedded attachments.
            // :return: a `files_data` list representation of the embedded attachements.
            // """
            // embedded = []
            // if file_data['import_file_type'] == 'pdf':
            //     for filename, content in extract_pdf_embedded_files(file_data['name'], file_data['raw']):
            //         embedded_file_data = {
            //             'name': filename,
            //             'raw': content,
            //             'mimetype': guess_mimetype(content),
            //             'attachment': None,
            //             'origin_attachment': file_data['origin_attachment'],
            //             'origin_import_file_type': file_data['origin_import_file_type'],
            //         }
            //         embedded_file_data['xml_tree'] = self._get_xml_tree(embedded_file_data)
            //         embedded_file_data['import_file_type'] = self._get_import_file_type(embedded_file_data)
            //         embedded.append(embedded_file_data)
            // 
            // if embedded and recurse:
            //     embedded.extend(self._unwrap_attachments(embedded))
            // 
            // return embedded
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> UnwrapAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files_data, object recurse) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_document_import_mixin.py) ---
            // def _unwrap_attachments(self, files_data, recurse=True):
            // """ Unwrap and return any embedded files.
            // 
            // :param files_data: The files to be unwrapped.
            // :param recurse: if True, embedded-of-embedded attachments will also be unwrapped and returned.
            // :return: a `files_data` list representation of the embedded attachments.
            // """
            // return list(itertools.chain(*(self._unwrap_attachment(file_data, recurse=recurse) for file_data in files_data)))
            */
            return default;
        }

        public async Task<TEntity> UpdateDatePlannedForLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> UpdateOrderLineInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py) ---
            // def _update_order_line_info(
            //     self, product_id, quantity, *, section_id=False, child_field='order_line', **kwargs
            // ):
            //     """ Update purchase order line information for a given product or create
            //     a new one if none exists yet.
            //     :param int product_id: The product, as a `product.product` id.
            //     :param int quantity: The quantity selected in the catalog.
            //     :param int section_id: The id of section selected in the catalog.
            //     :return: The unit price of the product, based on the pricelist of the
            //              purchase order and the quantity selected.
            //     :rtype: float
            //     """
            //     self.ensure_one()
            //     pol = self.order_line.filtered(
            //         lambda l: l.product_id.id == product_id
            //         and l.get_parent_section_line().id == section_id
            //     )
            //     if pol:
            //         if quantity != 0:
            //             pol.product_qty = quantity
            //         elif self.state in ['draft', 'sent']:
            //             price_unit = self._get_product_price_and_data(pol.product_id)['price']
            //             pol.unlink()
            //             return price_unit
            //         else:
            //             pol.product_qty = 0
            //     elif quantity > 0:
            //         pol = self.env['purchase.order.line'].create({
            //             'order_id': self.id,
            //             'product_id': product_id,
            //             'product_qty': quantity,
            //             'sequence': self._get_new_line_sequence(child_field, section_id),
            //         })
            //         if pol.selected_seller_id:
            //             # Fix the PO line's price on the seller's one.
            //             seller = pol.selected_seller_id
            //             price = seller.price
            //             if seller.currency_id != self.currency_id:
            //                 price = seller.currency_id._convert(price, self.currency_id)
            //             pol.price_unit = pol.technical_price_unit = price
            //             pol.discount = seller.discount
            //     return pol.price_unit_discounted
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _update_order_line_info(
            //     self, product_id, quantity, *, section_id=False, child_field='order_line', **kwargs
            // ):
            //     """ Update sale order line information for a given product or create a
            //     new one if none exists yet.
            //     :param int product_id: The product, as a `product.product` id.
            //     :param int quantity: The quantity selected in the catalog.
            //     :param int section_id: The id of section selected in the catalog.
            //     :return: The unit price of the product, based on the pricelist of the
            //              sale order and the quantity selected.
            //     :rtype: float
            //     """
            //     request.update_context(catalog_skip_tracking=True)
            //     sol = self.order_line.filtered(
            //         lambda l: l.product_id.id == product_id
            //         and l.get_parent_section_line().id == section_id,
            //     )
            //     if sol:
            //         if quantity != 0:
            //             sol.product_uom_qty = quantity
            //         elif self.state in ['draft', 'sent']:
            //             price_unit = self.pricelist_id._get_product_price(
            //                 product=sol.product_id,
            //                 quantity=1.0,
            //                 currency=self.currency_id,
            //                 date=self.date_order,
            //                 **kwargs,
            //             )
            //             sol.unlink()
            //             return price_unit
            //         else:
            //             sol.product_uom_qty = 0
            //     elif quantity > 0:
            //         sol = self.env['sale.order.line'].create({
            //             'order_id': self.id,
            //             'product_id': product_id,
            //             'product_uom_qty': quantity,
            //             'sequence': self._get_new_line_sequence(child_field, section_id),
            //         })
            //     else:  # quantity of 0, no line to update, return defaut pricelist price
            //         return self.pricelist_id._get_product_price(
            //             product=self.env['product.product'].browse(product_id),
            //             quantity=1.0,
            //             currency=self.currency_id,
            //             date=self.date_order,
            //             **kwargs,
            //         )
            // 
            //     return sol._get_discounted_price()
            */
            return default;
        }

        public async Task<TEntity> UpdateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates, object activity) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> ValidateOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def _validate_order(self):
            // """Confirm the sale order and send a confirmation email.
            // 
            // :return: None
            // """
            // self.with_context(send_email=True).action_confirm()
            */
            return default;
        }

        public async Task<TEntity> ValidateTaxesCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountDocumentImportMixinable
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
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: sale_order.py) ---
            // def write(self, vals):
            // if 'pricelist_id' in vals and any(so.state == 'sale' for so in self):
            //     raise UserError(_("You cannot change the pricelist of a confirmed order !"))
            // return super().write(vals)
            */
            return default;
        }
    }
}