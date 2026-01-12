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
    public class AccountMoveSendAppService : ApplicationService, IAccountMoveSendAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountMoveSendAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionWhatIsPeppolActivateAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def action_what_is_peppol_activate(self, moves):
            // companies = moves.company_id
            // if len(companies) == 1 and not companies.peppol_can_send:
            //     action = self.env['peppol.registration']._action_open_peppol_form()
            //     action['context'] = {
            //         'active_model': "account.move",
            //         'active_ids': moves.ids,
            //         'dialog_size': 'medium',
            //         **action['context'],
            //     }
            //     return action
            // else:
            //     # go back to previous (send and print) action
            //     # to avoid doing participant SML lookup again, we don't go through action_send_and_print
            //     return {
            //         'name': _("Send"),
            //         'type': 'ir.actions.act_window',
            //         'view_mode': 'form',
            //         'res_model': 'account.move.send.wizard' if len(moves) == 1 else 'account.move.send.batch.wizard',
            //         'target': 'new',
            //         'context': {
            //             'active_model': 'account.move',
            //             'active_ids': moves.ids
            //         },
            //     }
            */
            return default;
        }

        public async Task<TEntity> CallWebServiceAfterInvoicePdfRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _call_web_service_after_invoice_pdf_render(self, invoices_data):
            // # TO OVERRIDE
            // # call a web service after the pdfs are rendered
            // return
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _call_web_service_after_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_after_invoice_pdf_render(invoices_data)
            // 
            // params = {'documents': []}
            // invoices_data_peppol = {}
            // for invoice, invoice_data in invoices_data.items():
            //     partner = invoice.partner_id.commercial_partner_id.with_company(invoice.company_id)
            //     if 'peppol' in invoice_data['sending_methods'] and self._is_applicable_to_move('peppol', invoice, **invoice_data):
            // 
            //         if invoice_data.get('ubl_cii_xml_attachment_values'):
            //             xml_file = invoice_data['ubl_cii_xml_attachment_values']['raw']
            //             filename = invoice_data['ubl_cii_xml_attachment_values']['name']
            //         elif invoice.ubl_cii_xml_id and invoice.peppol_move_state not in ('processing', 'done'):
            //             xml_file = invoice.ubl_cii_xml_id.raw
            //             filename = invoice.ubl_cii_xml_id.name
            //         else:
            //             invoice.peppol_move_state = 'error'
            //             builder = invoice.partner_id.commercial_partner_id._get_edi_builder(invoice_data['invoice_edi_format'])
            //             invoice_data['error'] = _(
            //                 "Errors occurred while creating the EDI document (format: %s):",
            //                 builder._description
            //             )
            //             continue
            // 
            //         if len(xml_file) > 64000000:
            //             invoice_data['error'] = _("Invoice %s is too big to send via peppol (64MB limit)", invoice.name)
            //             continue
            // 
            //         receiver_identification = f"{partner.peppol_eas}:{partner.peppol_endpoint}"
            //         params['documents'].append({
            //             'filename': filename,
            //             'receiver': receiver_identification,
            //             'ubl': b64encode(xml_file).decode(),
            //         })
            //         invoices_data_peppol[invoice] = invoice_data
            // 
            // if not params['documents']:
            //     return
            // 
            // edi_user = next(iter(invoices_data)).company_id.account_peppol_edi_user
            // 
            // try:
            //     response = edi_user._call_peppol_proxy(
            //         "/api/peppol/1/send_document",
            //         params=params,
            //     )
            // except AccountEdiProxyError as e:
            //     for invoice, invoice_data in invoices_data_peppol.items():
            //         invoice.peppol_move_state = 'error'
            //         invoice_data['error'] = {'error_title': e.message}
            // else:
            //     if error_vals := response.get('error'):
            //         # at the moment the only error that can happen here is ParticipantNotReady error
            //         for invoice, invoice_data in invoices_data_peppol.items():
            //             invoice.peppol_move_state = 'error'
            //             invoice_data['error'] = {
            //                 'error_title': edi_user._get_peppol_error_message(error_vals),
            //             }
            //     else:
            //         # the response only contains message uuids,
            //         # so we have to rely on the order to connect peppol messages to account.move
            //         attachments_linked_message = _("The invoice has been sent to the Peppol Access Point. The following attachments were sent with the XML:")
            //         attachments_not_linked_message = _("Some attachments could not be sent with the XML:")
            //         for message, (invoice, invoice_data) in zip(response['messages'], invoices_data_peppol.items()):
            //             invoice.peppol_message_uuid = message['message_uuid']
            //             invoice.peppol_move_state = 'processing'
            //             attachments_linked, attachments_not_linked = self._get_ubl_available_attachments(
            //                 invoice_data.get('mail_attachments_widget', []),
            //                 invoice_data['invoice_edi_format']
            //             )
            //             if attachments_not_linked:
            //                 invoice._message_log(body=attachments_not_linked_message, attachment_ids=attachments_not_linked.mapped('id'))
            // 
            //             base_attachments = [
            //                 (invoice_data[key]['name'], invoice_data[key]['raw'])
            //                 for key in ['pdf_attachment_values', 'ubl_cii_xml_attachment_values']
            //                 if invoice_data.get(key)
            //             ]
            // 
            //             attachments_embedded = [
            //                 (attachment.name, attachment.raw)
            //                 for attachment in attachments_linked
            //             ] + base_attachments
            // 
            //             invoice.message_post(
            //                 body=attachments_linked_message,
            //                 attachments=attachments_embedded
            //             )
            //         self.env.ref('account_peppol.ir_cron_peppol_get_message_status')._trigger(at=fields.Datetime.now() + timedelta(minutes=5))
            // 
            // if self._can_commit():
            //     self.env.cr.commit()
            */
            return default;
        }

        public async Task<TEntity> CallWebServiceBeforeInvoicePdfRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _call_web_service_before_invoice_pdf_render(self, invoices_data):
            // # TO OVERRIDE
            // # call a web service before the pdfs are rendered
            // return
            */
            return default;
        }

        public async Task<TEntity> CanCommitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _can_commit(self):
            // """ Helper to know if we can commit the current transaction or not.
            // :return: True if commit is accepted, False otherwise.
            // """
            // return not (tools.config['test_enable'] or modules.module.current_test)
            */
            return default;
        }

        public async Task<TEntity> CheckInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _check_invoice_report(self, moves, **custom_settings):
            // if ((
            //         custom_settings.get('pdf_report')
            //         and any(not move._is_action_report_available(custom_settings['pdf_report']) for move in moves)
            //     )
            //     or any(not self._get_default_pdf_report_id(move).is_invoice_report for move in moves)
            // ):
            //     raise UserError(_("The sending of invoices is not set up properly, make sure the report used is set for invoices."))
            */
            return default;
        }

        public async Task<TEntity> CheckMoveConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _check_move_constraints(self, moves):
            // for move in moves:
            //     if move_constraints := self._get_move_constraints(move):
            //         raise UserError(next(iter(move_constraints.values()), None))
            */
            return default;
        }

        public async Task<TEntity> CheckSendingDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _check_sending_data(self, moves, **custom_settings):
            // """Assert the data provided to _generate_and_send_invoices are correct.
            // This is a security in case the method is called directly without going through the wizards.
            // """
            // self._check_move_constraints(moves)
            // self._check_invoice_report(moves, **custom_settings)
            // assert all(
            //     sending_method in dict(self.env['res.partner']._fields['invoice_sending_method'].selection)
            //     for sending_method in custom_settings.get('sending_methods', [])
            // ) if 'sending_methods' in custom_settings else True
            */
            return default;
        }

        public async Task<TEntity> DisplayAttachmentsWidgetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_format, object sending_methods) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _display_attachments_widget(self, edi_format, sending_methods):
            // return 'email' in sending_methods
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _display_attachments_widget(self, edi_format, sending_methods):
            // ubl_format_info = self.env['res.partner']._get_ubl_cii_formats_info()
            // return (
            //     super()._display_attachments_widget(edi_format, sending_methods)
            //     or ubl_format_info.get(edi_format, {}).get('embed_attachments')
            // )
            */
            return default;
        }

        public async Task<TEntity> DoPeppolPreSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _do_peppol_pre_send(self, moves):
            // if len(moves.company_id) == 1:
            //     if not moves.company_id.peppol_can_send:
            //         return self.env['peppol.registration'].with_context(default_company_id=moves.company_id.id)._action_open_peppol_form(reopen=False)
            // 
            // for move in moves:
            //     if move.peppol_move_state in ('ready', False):
            //         move.peppol_move_state = 'to_send'
            */
            return default;
        }

        public async Task<TEntity> FormatErrorHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _format_error_html(self, error):
            // """ Format the error that can be a dict (complex format needed)
            // 
            // :param error: the error to format.
            // :return: a html formatted error.
            // """
            // if 'errors' not in error:
            //     return error['error_title']
            // errors = Markup().join(Markup("<li>%s</li>") % error for error in error['errors'])
            // return Markup("%s<ul>%s</ul>") % (error['error_title'], errors)
            */
            return default;
        }

        public async Task<TEntity> FormatErrorTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _format_error_text(self, error):
            // """ Format the error that can be a dict (complex format needed)
            // 
            // :param error: the error to format.
            // :return: a text formatted error.
            // """
            // errors = '\n- '.join(error.get('errors', ''))
            // return f"{error['error_title']}\n- {errors}" if errors else error['error_title']
            */
            return default;
        }

        public async Task<TEntity> GenerateAndSendInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves, object from_cron, object allow_raising, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _generate_and_send_invoices(self, moves, from_cron=False, allow_raising=True, allow_fallback_pdf=False, **custom_settings):
            // """ Generate and send the moves given custom_settings if provided, else their default configuration set on related partner/company.
            // :param moves: account.move to process
            // :param from_cron: whether the processing comes from a cron.
            // :param allow_raising: whether the process can raise errors, or should log them on the move's chatter.
            // :param allow_fallback_pdf:  In case of error when generating the documents for invoices, generate a proforma PDF report instead.
            // :param custom_settings: settings to apply instead of related partner's defaults settings.
            // """
            // self._check_sending_data(moves, **custom_settings)
            // moves_data = {
            //     move.sudo(): {
            //         **self._get_default_sending_settings(move, from_cron=from_cron, **custom_settings),
            //     }
            //     for move in moves
            // }
            // 
            // # Generate all invoice documents (PDF and electronic documents if relevant).
            // self._generate_invoice_documents(moves_data, allow_fallback_pdf=allow_fallback_pdf)
            // 
            // # Manage errors.
            // errors = {move: move_data for move, move_data in moves_data.items() if move_data.get('error')}
            // if errors:
            //     self._hook_if_errors(errors, allow_raising=not from_cron and not allow_fallback_pdf and allow_raising)
            // 
            // # Fallback in case of error.
            // errors = {move: move_data for move, move_data in moves_data.items() if move_data.get('error')}
            // if allow_fallback_pdf and errors:
            //     self._generate_invoice_fallback_documents(errors)
            // 
            // # Successfully generated a PDF - Process sending.
            // success = {move: move_data for move, move_data in moves_data.items() if not move_data.get('error')}
            // if success:
            //     self._hook_if_success(success, from_cron=from_cron)
            // 
            // # Update sending data of moves
            // for move, move_data in moves_data.items():
            //     # We keep the sending_data, so it will be retried
            //     if from_cron and move_data.get('error', {}).get('retry'):
            //         continue
            //     move.sending_data = False
            // 
            // # Return generated attachments.
            // attachments = self.env['ir.attachment']
            // for move, move_data in success.items():
            //     attachments += self._get_invoice_extra_attachments(move) or move_data['proforma_pdf_attachment']
            // 
            // return attachments
            */
            return default;
        }

        public async Task<TEntity> GenerateDynamicReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _generate_dynamic_reports(self, moves_data):
            // for move, move_data in moves_data.items():
            //     mail_attachments_widget = move_data.get('mail_attachments_widget', [])
            // 
            //     dynamic_reports = [
            //         attachment_widget
            //         for attachment_widget in mail_attachments_widget
            //         if attachment_widget.get('dynamic_report')
            //         and not attachment_widget.get('skip')
            //     ]
            // 
            //     attachments_to_create = []
            //     for dynamic_report in dynamic_reports:
            //         content, _report_format = self.env['ir.actions.report']\
            //         .with_company(move.company_id)\
            //         .with_context(from_account_move_send=True)\
            //         ._render(dynamic_report['dynamic_report'], move.ids)
            // 
            //         attachments_to_create.append({
            //             'raw': content,
            //             'name': dynamic_report['name'],
            //             'mimetype': 'application/pdf',
            //             'res_model': move._name,
            //             'res_id': move.id,
            //         })
            // 
            //     attachments = self.env['ir.attachment'].create(attachments_to_create)
            //     mail_attachments_widget += [{
            //         'id': attachment.id,
            //         'name': attachment.name,
            //         'mimetype': 'application/pdf',
            //         'placeholder': False,
            //         'protect_from_deletion': True,
            //     } for attachment in attachments]
            */
            return default;
        }

        public async Task<TEntity> GenerateInvoiceDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _generate_invoice_documents(self, invoices_data, allow_fallback_pdf=False):
            // """ Generate the invoice PDF and electronic documents.
            // :param invoices_data:   The collected data for invoices so far.
            // :param allow_fallback_pdf:  In case of error when generating the documents for invoices, generate a
            //                             proforma PDF report instead.
            // """
            // for invoice, invoice_data in invoices_data.items():
            //     self._hook_invoice_document_before_pdf_report_render(invoice, invoice_data)
            //     invoice_data['blocking_error'] = invoice_data.get('error') \
            //                                      and not (allow_fallback_pdf and invoice_data.get('error_but_continue'))
            //     invoice_data['error_but_continue'] = allow_fallback_pdf and invoice_data.get('error_but_continue')
            // 
            // invoices_data_web_service = {
            //     invoice: invoice_data
            //     for invoice, invoice_data in invoices_data.items()
            //     if not invoice_data.get('error')
            // }
            // if invoices_data_web_service:
            //     self._call_web_service_before_invoice_pdf_render(invoices_data_web_service)
            // 
            // invoices_data_pdf = {
            //     invoice: invoice_data
            //     for invoice, invoice_data in invoices_data.items()
            //     if not invoice_data.get('error') or invoice_data.get('error_but_continue')
            // }
            // 
            // # Use batch to avoid memory error
            // batch_size = self.env['ir.config_parameter'].sudo().get_param('account.pdf_generation_batch', '80')
            // batches = []
            // pdf_to_generate = {}
            // for invoice, invoice_data in invoices_data_pdf.items():
            //     if not invoice_data.get('error') and not invoice.invoice_pdf_report_id:  # we don't regenerate pdf if it already exists
            //         pdf_to_generate[invoice] = invoice_data
            // 
            //         if (len(pdf_to_generate) > int(batch_size)):
            //             batches.append(pdf_to_generate)
            //             pdf_to_generate = {}
            // 
            // if pdf_to_generate:
            //     batches.append(pdf_to_generate)
            // 
            // for batch in batches:
            //     self._prepare_invoice_pdf_report(batch)
            // 
            // for invoice, invoice_data in invoices_data_pdf.items():
            //     if not invoice_data.get('error') and not invoice.invoice_pdf_report_id:
            //         self._hook_invoice_document_after_pdf_report_render(invoice, invoice_data)
            // 
            // # Cleanup the error if we don't want to block the regular pdf generation.
            // if allow_fallback_pdf:
            //     invoices_data_pdf_error = {
            //         invoice: invoice_data
            //         for invoice, invoice_data in invoices_data.items()
            //         if invoice_data.get('pdf_attachment_values') and invoice_data.get('error')
            //     }
            //     if invoices_data_pdf_error:
            //         self._hook_if_errors(invoices_data_pdf_error, allow_raising=not allow_fallback_pdf)
            // 
            // # Web-service after the PDF generation.
            // invoices_data_web_service = {
            //     invoice: invoice_data
            //     for invoice, invoice_data in invoices_data.items()
            //     if not invoice_data.get('error')
            // }
            // if invoices_data_web_service:
            //     self._call_web_service_after_invoice_pdf_render(invoices_data_web_service)
            // 
            // # Create and link the generated documents to the invoice if the web-service didn't failed.
            // invoices_to_link = {
            //     invoice: invoice_data
            //     for invoice, invoice_data in invoices_data_web_service.items()
            //     if not invoice_data.get('error') or allow_fallback_pdf
            // }
            // self._link_invoice_documents(invoices_to_link)
            */
            return default;
        }

        public async Task<TEntity> GenerateInvoiceFallbackDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _generate_invoice_fallback_documents(self, invoices_data):
            // """ Generate the invoice PDF and electronic documents.
            // :param invoices_data:   The collected data for invoices so far.
            // """
            // for invoice, invoice_data in invoices_data.items():
            //     if not invoice.invoice_pdf_report_id and invoice_data.get('error'):
            //         invoice_data.pop('error')
            //         self._prepare_invoice_proforma_pdf_report(invoice, invoice_data)
            //         self._hook_invoice_document_after_pdf_report_render(invoice, invoice_data)
            //         invoice_data['proforma_pdf_attachment'] = self.env['ir.attachment']\
            //             .create(invoice_data.pop('proforma_pdf_attachment_values'))
            */
            return default;
        }

        public async Task<TEntity> GetAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // """ Returns a dict of all alerts corresponding to moves with the given context (sending method,
            // edi format to generate, extra_edi to generate).
            // An alert can have some information:
            // - level (danger, info, warning, ...)  (! danger alerts are considered blocking and will be raised)
            // - message to display
            // - action_text for the text to show on the clickable link
            // - action the action to run when the link is clicked
            // """
            // alerts = {}
            // 
            // # Filter moves that are trying to send via email
            // email_moves = moves.filtered(lambda m: 'email' in moves_data[m]['sending_methods'])
            // if email_moves:
            //     # Identify partners without email depending on batch/single send
            //     if is_batch := len(moves) > 1:
            //         # Batch sending
            //         partners_without_mail = email_moves.filtered(lambda m: not m.partner_id.email).mapped('partner_id')
            //     else:
            //         # Single sending
            //         partners_without_mail = moves_data[email_moves]['mail_partner_ids'].filtered(lambda p: not p.email)
            // 
            //     # If there are partners without email, add an alert
            //     if partners_without_mail:
            //         alerts['account_missing_email'] = {
            //             'level': 'warning' if is_batch else 'danger',
            //             'message': _("Partner(s) should have an email address."),
            //             'action_text': _("View Partner(s)") if is_batch else False,
            //             'action': (
            //                 partners_without_mail._get_records_action(name=_("Check Partner(s) Email(s)"))
            //                 if is_batch else False
            //             ),
            //         }
            // 
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // 
            // peppol_formats = set(self.env['res.partner']._get_peppol_formats())
            // if peppol_format_moves := moves.filtered(lambda m: moves_data[m]['invoice_edi_format'] in peppol_formats):
            //     not_configured_company_partners = peppol_format_moves.company_id.partner_id.filtered(
            //         lambda partner: not (partner.peppol_eas and partner.peppol_endpoint)
            //     )
            //     if not_configured_company_partners:
            //         alerts['account_edi_ubl_cii_configure_company'] = {
            //             'message': _("Please fill in your company's VAT or Peppol Address to generate a complete XML file."),
            //             'level': 'info',
            //             'action_text': _("Configure"),
            //             'action': not_configured_company_partners._get_records_action(),
            //         }
            //     not_configured_partners = peppol_format_moves.partner_id.commercial_partner_id.filtered(
            //         lambda partner: not (partner.peppol_eas and partner.peppol_endpoint)
            //     )
            //     if not_configured_partners:
            //         alerts['account_edi_ubl_cii_configure_partner'] = {
            //             'message': _("Please fill in partner's VAT or Peppol Address."),
            //             'level': 'info',
            //             'action_text': _("View Partner(s)"),
            //             'action': not_configured_partners._get_records_action(name=_("Check Partner(s)"))
            //         }
            // 
            //     if any(
            //             self.env['account.edi.xml.ubl_bis3']._is_customer_behind_chorus_pro(partner)
            //             for partner in peppol_format_moves.partner_id.commercial_partner_id
            //         ):
            //         chorus_pro = self.env['ir.module.module'].sudo().search([('name', '=', 'l10n_fr_facturx_chorus_pro')], limit=1)
            //         if chorus_pro and chorus_pro.state != 'installed':
            //             alerts['account_edi_ubl_cii_chorus_pro_install'] = {
            //                 'message': _("Please install the french Chorus pro module to have all the specific rules."),
            //                 'level': 'info',
            //                 'action': chorus_pro._get_records_action(),
            //                 'action_text': _("Install Chorus Pro"),
            //             }
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // def peppol_partner(moves):
            //     return moves.partner_id.commercial_partner_id
            // 
            // def filter_peppol_state(moves, states):
            //     return peppol_partner(
            //         moves.filtered(lambda m: peppol_partner(m).peppol_verification_state in states)
            //     )
            // 
            // alerts = super()._get_alerts(moves, moves_data)
            // # Check for invalid peppol partners.
            // peppol_moves = moves.filtered(lambda m: 'peppol' in moves_data[m]['sending_methods'])
            // invalid_partners = filter_peppol_state(peppol_moves, ['not_valid_format'])
            // if invalid_partners and not 'account_edi_ubl_cii_configure_partner' in alerts:
            //     alerts['account_peppol_warning_partner'] = {
            //         'message': _("Customer is on Peppol but did not enable receiving documents."),
            //         'action_text': _("View Partner(s)"),
            //         'action': invalid_partners._get_records_action(name=_("Check Partner(s)")),
            //     }
            // not_peppol_moves = moves.filtered(lambda m: 'peppol' not in moves_data[m]['sending_methods'])
            // what_is_peppol_alert = {
            //     'level': 'info',
            //     'action_text': _("Why should you use it ?"),
            //     'action': {
            //         'name': _("Why should I use PEPPOL ?"),
            //         'type': 'ir.actions.client',
            //         'tag': 'account_peppol.what_is_peppol',
            //         'target': 'new',
            //         'context': {
            //             'footer': False,
            //             'dialog_size': 'medium',
            //             'action_on_activate': self.action_what_is_peppol_activate(moves),
            //         },
            //     },
            // }
            // info_always_on_countries = {'BE', 'FI', 'LU', 'LV', 'NL', 'NO', 'SE'}
            // any_moves_not_sent_peppol = any(move.peppol_move_state not in ('processing', 'done') for move in moves)
            // always_on_companies = moves.company_id.filtered(
            //     lambda c: c.country_code in info_always_on_countries and not c.peppol_can_send
            // )
            // if all((
            //     always_on_companies,
            //     any_moves_not_sent_peppol,
            //     not filter_peppol_state(moves, ['not_valid', 'not_verified']),
            // )):
            //     alerts.pop('account_edi_ubl_cii_configure_company', False)
            //     alerts['account_peppol_what_is_peppol'] = {
            //         'message': _("You can send this invoice electronically via Peppol."),
            //         **what_is_peppol_alert,
            //     }
            // elif all((
            //     (peppol_not_selected_partners := filter_peppol_state(not_peppol_moves, ['valid'])),
            //     any_moves_not_sent_peppol,
            //     len(peppol_not_selected_partners) == 1,  # Check for not peppol partners that are on the network
            // )):
            //     alerts['account_peppol_partner_want_peppol'] = {
            //         'message': _(
            //             "%s has requested electronic invoices reception on Peppol.",
            //             peppol_not_selected_partners.display_name
            //         ),
            //         **what_is_peppol_alert,
            //     }
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: snailmail_account, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // if snailmail_moves_without_valid_address := moves.filtered(
            //     lambda m: 'snailmail' in moves_data[m]['sending_methods'] and not self.env['snailmail.letter']._is_valid_address(m.partner_id)
            // ):
            //     alerts['snailmail_account_partner_invalid_address'] = {
            //         'level': 'danger' if len(snailmail_moves_without_valid_address) == 1 else 'warning',
            //         'message': _(
            //             "The partners on the following invoices have no valid address, "
            //             "so those invoices will not be sent: %s",
            //             ", ".join(snailmail_moves_without_valid_address.mapped('name'))
            //         ),
            //         'action_text': _("View Invoice(s)"),
            //         'action': snailmail_moves_without_valid_address._get_records_action(name=_("Check Invoice(s)")),
            //     }
            // return alerts
            */
            return default;
        }

        public async Task<Dictionary<string, object>> GetAllExtraEdisInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // """ Returns a dict representing EDI data such as:
            // { 'edi_key': {'label': 'EDI label', 'is_applicable': function, 'help': 'optional help'} }
            // """
            // return {}
            */
            return default;
        }

        public async Task<object> GetDefaultExtraEdisInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_extra_edis(self, move) -> set:
            // """ By default, we use all applicable extra EDIs. """
            // extra_edis = self._get_all_extra_edis()
            // return {edi_key for edi_key, edi_vals in extra_edis.items() if edi_vals['is_applicable'](move)}
            */
            return default;
        }

        public async Task<string> GetDefaultInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_invoice_edi_format(self, move, **kwargs) -> str:
            // """ By default, we generate the EDI format set on partner. """
            // return move.commercial_partner_id.with_company(move.company_id).invoice_edi_format
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _get_default_invoice_edi_format(self, move, **kwargs) -> str:
            // # EXTENDS 'account' - default on bis3 if Peppol is set but no format on the partner
            // invoice_edi_format = super()._get_default_invoice_edi_format(move, **kwargs)
            // if 'peppol' in kwargs.get('sending_methods', []):
            //     return move.partner_id.with_company(move.company_id)._get_peppol_edi_format()
            // return invoice_edi_format
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailAttachmentsWidgetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object invoice_edi_format, object extra_edis, object pdf_report) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_mail_attachments_widget(self, move, mail_template, invoice_edi_format=None, extra_edis=None, pdf_report=None):
            // return self._get_placeholder_mail_attachments_data(move, invoice_edi_format=invoice_edi_format, extra_edis=extra_edis, pdf_report=pdf_report) \
            //     + self._get_placeholder_mail_template_dynamic_attachments_data(move, mail_template, pdf_report=pdf_report) \
            //     + self._get_invoice_extra_attachments_data(move) \
            //     + self._get_mail_template_attachments_data(mail_template)
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object mail_lang) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_mail_body(self, move, mail_template, mail_lang):
            // return self._get_mail_default_field_value_from_template(
            //     mail_template,
            //     mail_lang,
            //     move,
            //     'body_html',
            //     options={'post_process': True},
            // )
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_mail_lang(self, move, mail_template):
            // return mail_template._render_lang([move.id]).get(move.id)
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object mail_lang) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_mail_partner_ids(self, move, mail_template, mail_lang):
            // # TDE FIXME: this should use standard composer / template code to be sure
            // # it is aligned with standard recipients management. Todo later
            // partners = self.env['res.partner'].with_company(move.company_id)
            // if mail_template.use_default_to:
            //     defaults = move._message_get_default_recipients()[move.id]
            //     email_cc = defaults['email_to']
            //     email_to = defaults['email_to']
            //     partners |= partners.browse(defaults['partner_ids'])
            // else:
            //     if mail_template.email_cc:
            //         email_cc = self._get_mail_default_field_value_from_template(mail_template, mail_lang, move, 'email_cc')
            //     else:
            //         email_cc = ''
            //     if mail_template.email_to:
            //         email_to = self._get_mail_default_field_value_from_template(mail_template, mail_lang, move, 'email_to')
            //     else:
            //         email_to = ''
            // 
            // partners |= move._partner_find_from_emails_single(
            //     tools.email_split(email_cc or '') + tools.email_split(email_to or ''),
            //     no_create=False,
            // )
            // 
            // if not mail_template.use_default_to and mail_template.partner_to:
            //     partner_to = self._get_mail_default_field_value_from_template(mail_template, mail_lang, move, 'partner_to')
            //     partner_ids = mail_template._parse_partner_to(partner_to)
            //     partners |= self.env['res.partner'].sudo().browse(partner_ids).exists()
            // return partners if self.env.context.get('allow_partners_without_mail') else partners.filtered('email')
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object mail_lang) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_mail_subject(self, move, mail_template, mail_lang):
            // return self._get_mail_default_field_value_from_template(
            //     mail_template,
            //     mail_lang,
            //     move,
            //     'subject',
            // )
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_mail_template_id(self, move):
            // return move._get_mail_template()
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_pdf_report_id(self, move):
            // if partner_default_template := move.commercial_partner_id.with_company(move.company_id).invoice_template_pdf_report_id:
            //     return partner_default_template
            // 
            // if journal_default_template := move.journal_id.with_company(move.company_id).invoice_template_pdf_report_id:
            //     return journal_default_template
            // 
            // action_report = self.env.ref('account.account_invoices')
            // 
            // if move._is_action_report_available(action_report):
            //     return action_report
            // 
            // raise UserError(_("There is no template that applies to this move type."))
            */
            return default;
        }

        public async Task<object> GetDefaultSendingMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_sending_methods(self, move) -> set:
            // """ By default, we use the sending method set on the partner or email. """
            // return {move.commercial_partner_id.with_company(move.company_id).invoice_sending_method or 'email'}
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _get_default_sending_methods(self, move) -> set:
            // """ By default, we use the sending method set on the partner or email and peppol. """
            // # EXTENDS 'account'
            // default_sending_methods = super()._get_default_sending_methods(move)
            // if self._is_applicable_to_move('peppol', move):
            //     default_sending_methods.add('peppol')
            // return default_sending_methods
            */
            return default;
        }

        public async Task<TEntity> GetDefaultSendingSettingsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object from_cron) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_sending_settings(self, move, from_cron=False, **custom_settings):
            // """ Returns a dict with all the necessary data to generate and send invoices.
            // Either takes the provided custom_settings, or the default value.
            // """
            // def get_setting(key, from_cron=False, default_value=None):
            //     return custom_settings.get(key) if key in custom_settings else move.sending_data.get(key) if from_cron else default_value
            // 
            // vals = {
            //     'sending_methods': get_setting('sending_methods', default_value=self._get_default_sending_methods(move)) or {},
            //     'extra_edis': get_setting('extra_edis', default_value=self._get_default_extra_edis(move)) or {},
            //     'pdf_report': get_setting('pdf_report') or self._get_default_pdf_report_id(move),
            //     'author_user_id': get_setting('author_user_id', from_cron=from_cron) or self.env.user.id,
            //     'author_partner_id': get_setting('author_partner_id', from_cron=from_cron) or self.env.user.partner_id.id,
            // }
            // vals['invoice_edi_format'] = get_setting('invoice_edi_format', default_value=self._get_default_invoice_edi_format(move, sending_methods=vals['sending_methods']))
            // mail_template = get_setting('mail_template') or self._get_default_mail_template_id(move)
            // if 'email' in vals['sending_methods']:
            //     mail_lang = get_setting('mail_lang') or self._get_default_mail_lang(move, mail_template)
            //     vals.update({
            //         'mail_template': mail_template,
            //         'mail_lang': mail_lang,
            //         'mail_body': get_setting('mail_body', default_value=self._get_default_mail_body(move, mail_template, mail_lang)),
            //         'mail_subject': get_setting('mail_subject', default_value=self._get_default_mail_subject(move, mail_template, mail_lang)),
            //         'mail_partner_ids': get_setting('mail_partner_ids', default_value=self._get_default_mail_partner_ids(move, mail_template, mail_lang).ids),
            //     })
            // # Add mail attachments if sending methods support them
            // if self._display_attachments_widget(vals['invoice_edi_format'], vals['sending_methods']):
            //     mail_attachments_widget = self._get_default_mail_attachments_widget(
            //         move,
            //         mail_template,
            //         invoice_edi_format=vals['invoice_edi_format'],
            //         extra_edis=vals['extra_edis'],
            //         pdf_report=vals['pdf_report'],
            //     )
            //     vals['mail_attachments_widget'] = get_setting('mail_attachments_widget', default_value=mail_attachments_widget)
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceExtraAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments_data(self, move):
            // return [
            //     {
            //         'id': attachment.id,
            //         'name': attachment.name,
            //         'mimetype': attachment.mimetype,
            //         'placeholder': False,
            //         'protect_from_deletion': True,
            //     }
            //     for attachment in self._get_invoice_extra_attachments(move)
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceExtraAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, move):
            // return move.invoice_pdf_report_id
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, move):
            // # EXTENDS 'account'
            // result = super()._get_invoice_extra_attachments(move)
            // for doc in move.edi_document_ids:
            //     result += self._get_mail_attachment_from_doc(doc)
            // return result
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, move):
            // # EXTENDS 'account'
            // return super()._get_invoice_extra_attachments(move) + move.ubl_cii_xml_id
            */
            return default;
        }

        public async Task<TEntity> GetMailAttachmentFromDocInternalAsync<TEntity>(IEnumerable<TEntity> entities, object doc) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: account_move_send.py) ---
            // def _get_mail_attachment_from_doc(self, doc):
            // attachment_sudo = doc.sudo().attachment_id
            // if attachment_sudo.res_model and attachment_sudo.res_id:
            //     return attachment_sudo
            // return self.env['ir.attachment']
            */
            return default;
        }

        public async Task<TEntity> GetMailDefaultFieldValueFromTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object lang, object move, object field) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_mail_default_field_value_from_template(self, mail_template, lang, move, field, **kwargs):
            // if not mail_template:
            //     return
            // return mail_template.sudo()\
            //     .with_context(lang=lang)\
            //     ._render_field(field, move.ids, **kwargs)[move._origin.id]
            */
            return default;
        }

        public async Task<TEntity> GetMailLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_mail_layout(self):
            // return 'mail.mail_notification_layout_with_responsible_signature'
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _get_mail_layout(self):
            // # OVERRIDE 'account'
            // return 'account_peppol.mail_notification_layout_with_responsible_signature_and_peppol'
            */
            return default;
        }

        public async Task<TEntity> GetMailParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object move_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_mail_params(self, move, move_data):
            // # We must ensure the newly created PDF are added. At this point, the PDF has been generated but not added
            // # to 'mail_attachments_widget'.
            // mail_attachments_widget = move_data.get('mail_attachments_widget')
            // seen_attachment_ids = set()
            // to_exclude = {x['name'] for x in mail_attachments_widget if x.get('skip')}
            // for attachment_data in self._get_invoice_extra_attachments_data(move) + mail_attachments_widget:
            //     if attachment_data['name'] in to_exclude and not attachment_data.get('manual'):
            //         continue
            // 
            //     try:
            //         attachment_id = int(attachment_data['id'])
            //     except ValueError:
            //         continue
            // 
            //     seen_attachment_ids.add(attachment_id)
            // 
            // mail_attachments = [
            //     (attachment.name, attachment.raw)
            //     for attachment in self.env['ir.attachment'].browse(list(seen_attachment_ids)).exists()
            // ]
            // 
            // return {
            //     'author_id': move_data['author_partner_id'],
            //     'body': move_data['mail_body'],
            //     'subject': move_data['mail_subject'],
            //     'partner_ids': move_data['mail_partner_ids'],
            //     'attachments': mail_attachments,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMailTemplateAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_mail_template_attachments_data(self, mail_template):
            // """ Returns all mail template data. """
            // return [
            //     {
            //         'id': attachment.id,
            //         'name': attachment.name,
            //         'mimetype': attachment.mimetype,
            //         'placeholder': False,
            //         'mail_template_id': mail_template.id,
            //         'protect_from_deletion': True,
            //     }
            //     for attachment in mail_template.attachment_ids
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetMoveConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_move_constraints(self, move):
            // constraints = {}
            // if move.state != 'posted':
            //     constraints['not_posted'] = _("You can't generate invoices that are not posted.")
            // if not move.is_sale_document(include_receipts=True):
            //     constraints['not_sale_document'] = _("You can only generate sales documents.")
            // return constraints
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _get_move_constraints(self, move):
            // constraints = super()._get_move_constraints(move)
            // if move._is_exportable_as_self_invoice():
            //     constraints.pop('not_sale_document', None)
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderMailAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object invoice_edi_format, object extra_edis, object pdf_report) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_placeholder_mail_attachments_data(self, move, invoice_edi_format=None, extra_edis=None, pdf_report=None):
            // """ Returns all the placeholder data.
            // Should be extended to add placeholder based on the sending method.
            // :param: move:       The current move.
            // :returns: A list of dictionary for each placeholder.
            // * id:               str: The (fake) id of the attachment, this is needed in rendering in t-key.
            // * name:             str: The name of the attachment.
            // * mimetype:         str: The mimetype of the attachment.
            // * placeholder       bool: Should be true to prevent download / deletion.
            // """
            // if move.invoice_pdf_report_id:
            //     return []
            // filename = move._get_invoice_report_filename(report=pdf_report)
            // return [{
            //     'id': f'placeholder_{filename}',
            //     'name': filename,
            //     'mimetype': 'application/pdf',
            //     'placeholder': True,
            // }]
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _get_placeholder_mail_attachments_data(self, move, invoice_edi_format=None, extra_edis=None, pdf_report=None):
            // # EXTENDS 'account'
            // results = super()._get_placeholder_mail_attachments_data(move, invoice_edi_format=invoice_edi_format, extra_edis=extra_edis, pdf_report=pdf_report)
            // if move._need_ubl_cii_xml(invoice_edi_format):
            //     builder = move.partner_id.commercial_partner_id._get_edi_builder(invoice_edi_format)
            //     filename = builder._export_invoice_filename(move)
            //     results.append({
            //         'id': f'placeholder_{filename}',
            //         'name': filename,
            //         'mimetype': 'application/xml',
            //         'placeholder': True,
            //     })
            // return results
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderMailTemplateDynamicAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object pdf_report) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_placeholder_mail_template_dynamic_attachments_data(self, move, mail_template, pdf_report=None):
            // """
            // This method returns the placeholder data for the dynamic attachments.
            // :param move:            The current move we are generating documents for.
            // :param mail_template:   The mail template used to get dynamic attachments for the move.
            // :param pdf_report:      The 'ir.actions.report' used for the move.
            //                         Usually it will be the generic 'account.account_invoices' but the user can customize it
            //                         from the Send Wizard interface.
            // :return:                A list of dictionary, one for each placeholder.
            // """
            // # The Send wizard will generate a legal PDF based on a specific ir.actions.report.
            // # In case the report selected to do so is also added in dynamic attachments of the mail template, we need to
            // # filter them out to avoid duplicated placeholders, since they are already added in the
            // # _get_placeholder_mail_attachments_data method.
            // pdf_report = pdf_report or self._get_default_pdf_report_id(move)
            // invoice_template = pdf_report | self.env.ref('account.account_invoices')
            // extra_mail_templates = mail_template.report_template_ids - invoice_template
            // filename = move._get_invoice_report_filename(report=pdf_report)
            // return [
            //     {
            //         'id': f'placeholder_{extra_mail_template.name.lower()}_{filename}',
            //         'name': f'{extra_mail_template.name.lower()}_{filename}',
            //         'mimetype': 'application/pdf',
            //         'placeholder': True,
            //         'dynamic_report': extra_mail_template.report_name,
            //     } for extra_mail_template in extra_mail_templates
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetUblAvailableAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_attachments_widget, object invoice_edi_format) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _get_ubl_available_attachments(self, mail_attachments_widget, invoice_edi_format):
            // if not invoice_edi_format or not mail_attachments_widget:
            //     return self.env['ir.attachment'], self.env['ir.attachment']
            // attachment_ids = [values['id'] for values in mail_attachments_widget if values.get('manual')]
            // attachments = self.env['ir.attachment'].browse(attachment_ids)
            // 
            // ubl_format_info = self.env['res.partner']._get_ubl_cii_formats_info().get(invoice_edi_format, {})
            // if not ubl_format_info.get('embed_attachments'):
            //     return self.env['ir.attachment'], attachments
            // 
            // accepted_attachments = attachments.filtered(lambda attachment: attachment.mimetype in SUPPORTED_FILE_TYPES)
            // return accepted_attachments, attachments - accepted_attachments
            */
            return default;
        }

        public async Task<TEntity> HookIfErrorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data, object allow_raising) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _hook_if_errors(self, moves_data, allow_raising=True):
            // """ Process errors found so far when generating the documents. """
            // group_by_partner = defaultdict(list)
            // for move, move_data in moves_data.items():
            //     error = move_data['error']
            //     if allow_raising:
            //         raise UserError(self._format_error_text(error))
            //     group_by_partner[move_data['author_partner_id']].append(move.id)
            //     move.message_post(body=self._format_error_html(error))
            // self._send_notifications_to_partners(group_by_partner, is_success=False)
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _hook_if_errors(self, moves_data, allow_raising=True):
            // # EXTENDS 'account'
            // # to update `peppol_move_state` as `error` to show users that something went wrong
            // # because those moves that failed XML/PDF files generation are not sent via Peppol
            // moves_failed_file_generation = self.env['account.move']
            // for move, move_data in moves_data.items():
            //     if 'peppol' in move_data['sending_methods'] and move_data.get('blocking_error'):
            //         moves_failed_file_generation |= move
            // 
            // moves_failed_file_generation.peppol_move_state = 'error'
            // 
            // return super()._hook_if_errors(moves_data, allow_raising=allow_raising)
            */
            return default;
        }

        public async Task<TEntity> HookIfSuccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data, object from_cron) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _hook_if_success(self, moves_data, from_cron=False):
            // """ Process (typically send) successful documents."""
            // group_by_partner = defaultdict(list)
            // to_send_mail = {}
            // for move, move_data in moves_data.items():
            //     if from_cron:
            //         group_by_partner[move_data['author_partner_id']].append(move.id)
            //     if 'email' in move_data['sending_methods'] and self._is_applicable_to_move('email', move, **move_data):
            //         to_send_mail[move] = move_data
            // self._send_mails(to_send_mail)
            // self._send_notifications_to_partners(group_by_partner)
            // 
            // # Notify subscribers.
            // for move, move_data in moves_data.items():
            //     if not move.is_invoice(include_receipts=True):
            //         continue
            // 
            //     try:
            //         move.journal_id._notify_invoice_subscribers(
            //             invoice=move,
            //             mail_params={
            //                 'attachment_ids': [
            //                     Command.create({'name': attachment.name, 'raw': attachment.raw, 'mimetype': attachment.mimetype})
            //                     for attachment in self._get_invoice_extra_attachments(move)
            //                 ]
            //             },
            //         )
            //     except Exception:
            //         _logger.exception("Failed notifying subscribers for move %s", move.id)
            --- ODOO METHOD SOURCE (MODULE: snailmail_account, FILE: account_move_send.py) ---
            // def _hook_if_success(self, moves_data, from_cron=False):
            // # EXTENDS 'account'
            // to_send = {
            //     move: move_data
            //     for move, move_data in moves_data.items()
            //     if 'snailmail' in move_data['sending_methods'] and self._is_applicable_to_move('snailmail', move, **move_data)
            // }
            // if to_send:
            //     self.env['snailmail.letter'].create([
            //         {
            //             'user_id': move_data.get('author_user_id') or self.env.user.id,
            //             **self._prepare_snailmail_letter_values(move),
            //         }
            //         for move, move_data in to_send.items()
            //     ])\
            //     ._snailmail_print(immediate=False)
            // super()._hook_if_success(moves_data, from_cron)
            */
            return default;
        }

        public async Task<TEntity> HookInvoiceDocumentAfterPdfReportRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _hook_invoice_document_after_pdf_report_render(self, invoice, invoice_data):
            // """ Hook allowing to add some extra data for the invoice passed as parameter after the rendering of the
            // (proforma) pdf report.
            // :param invoice:         An account.move record.
            // :param invoice_data:    The collected data for the invoice so far.
            // """
            // return
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _hook_invoice_document_after_pdf_report_render(self, invoice, invoice_data):
            // # EXTENDS 'account'
            // super()._hook_invoice_document_after_pdf_report_render(invoice, invoice_data)
            // 
            // # Add PDF to XML
            // if 'ubl_cii_xml_options' in invoice_data and invoice_data['ubl_cii_xml_options']['ubl_cii_format'] != 'facturx':
            //     self._postprocess_invoice_ubl_xml(invoice, invoice_data)
            // 
            // # Always silently generate a Factur-X and embed it inside the PDF for inter-portability
            // if invoice_data.get('ubl_cii_xml_options', {}).get('ubl_cii_format') == 'facturx':
            //     xml_facturx = invoice_data['ubl_cii_xml_attachment_values']['raw']
            // else:
            //     xml_facturx = self.env['account.edi.xml.cii']._export_invoice(invoice)[0]
            // 
            // # during tests, no wkhtmltopdf, create the attachment for test purposes
            // if tools.config['test_enable']:
            //     self.env['ir.attachment'].sudo().create({
            //         'name': 'factur-x.xml',
            //         'raw': xml_facturx,
            //         'res_id': invoice.id,
            //         'res_model': 'account.move',
            //     })
            //     return
            // 
            // # Read pdf content.
            // pdf_values = (not self.env.context.get('custom_template_facturx') and invoice.invoice_pdf_report_id) or \
            //     invoice_data.get('pdf_attachment_values') or invoice_data['proforma_pdf_attachment_values']
            // reader_buffer = io.BytesIO(pdf_values['raw'])
            // reader = OdooPdfFileReader(reader_buffer, strict=False)
            // 
            // # Post-process.
            // writer = OdooPdfFileWriter()
            // writer.cloneReaderDocumentRoot(reader)
            // 
            // writer.addAttachment('factur-x.xml', xml_facturx, subtype='text/xml')
            // 
            // # PDF-A.
            // if invoice_data.get('ubl_cii_xml_options', {}).get('ubl_cii_format') == 'facturx' \
            //         and not writer.is_pdfa:
            //     try:
            //         writer.convert_to_pdfa()
            //     except Exception:
            //         _logger.exception("Error while converting to PDF/A")
            // 
            //     # Extra metadata to be Factur-x PDF-A compliant.
            //     content = self.env['ir.qweb']._render(
            //         'account_edi_ubl_cii.account_invoice_pdfa_3_facturx_metadata',
            //         {
            //             'title': invoice.name,
            //             'date': fields.Date.context_today(self),
            //         },
            //     )
            //     writer.add_file_metadata(content.encode())
            // 
            // # Replace the current content.
            // writer_buffer = io.BytesIO()
            // writer.write(writer_buffer)
            // pdf_values['raw'] = writer_buffer.getvalue()
            // reader_buffer.close()
            // writer_buffer.close()
            */
            return default;
        }

        public async Task<TEntity> HookInvoiceDocumentBeforePdfReportRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _hook_invoice_document_before_pdf_report_render(self, invoice, invoice_data):
            // """ Hook allowing to add some extra data for the invoice passed as parameter before the rendering of the pdf
            // report.
            // :param invoice:         An account.move record.
            // :param invoice_data:    The collected data for the invoice so far.
            // """
            // return
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _hook_invoice_document_before_pdf_report_render(self, invoice, invoice_data):
            // # EXTENDS 'account'
            // super()._hook_invoice_document_before_pdf_report_render(invoice, invoice_data)
            // 
            // if invoice._need_ubl_cii_xml(invoice_data['invoice_edi_format']):
            //     builder = invoice.partner_id.commercial_partner_id._get_edi_builder(invoice_data['invoice_edi_format'])
            //     xml_content, errors = builder._export_invoice(invoice)
            //     filename = builder._export_invoice_filename(invoice)
            // 
            //     # Failed.
            //     if errors:
            //         invoice_data['error'] = {
            //             'error_title': _("Errors occurred while creating the EDI document (format: %s):", builder._description),
            //             'errors': errors,
            //         }
            //         invoice_data['error_but_continue'] = True
            //     else:
            //         invoice_data['ubl_cii_xml_attachment_values'] = {
            //             'name': filename,
            //             'raw': xml_content,
            //             'mimetype': 'application/xml',
            //             'res_model': invoice._name,
            //             'res_id': invoice.id,
            //             'res_field': 'ubl_cii_xml_file',  # Binary field
            //         }
            //         invoice_data['ubl_cii_xml_options'] = {
            //             'ubl_cii_format': invoice_data['invoice_edi_format'],
            //             'builder': builder,
            //         }
            */
            return default;
        }

        public async Task<TEntity> IsApplicableToCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object method, object company) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _is_applicable_to_company(self, method, company):
            // """ TO OVERRIDE - used to determine if we should display the sending method in the selection."""
            // return True
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _is_applicable_to_company(self, method, company):
            // # EXTENDS 'account'
            // if method == 'peppol':
            //     return company.country_code in PEPPOL_LIST and company.account_peppol_proxy_state != 'rejected'
            // else:
            //     return super()._is_applicable_to_company(method, company)
            */
            return default;
        }

        public async Task<TEntity> IsApplicableToMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object method, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _is_applicable_to_move(self, method, move, **move_data):
            // """ TO OVERRIDE - """
            // if method == 'email' and 'mail_partner_ids' in move_data:
            //     return bool(move_data['mail_partner_ids'])
            // return True
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _is_applicable_to_move(self, method, move, **move_data):
            // # EXTENDS 'account'
            // if method == 'peppol':
            //     partner = move.partner_id.commercial_partner_id.with_company(move.company_id)
            //     invoice_edi_format = move_data.get('invoice_edi_format') or partner._get_peppol_edi_format()
            //     if partner.peppol_verification_state == 'not_verified':
            //         partner.button_account_peppol_check_partner_endpoint(company=move.company_id)
            //     return all([
            //         partner.country_code in PEPPOL_LIST,
            //         self._is_applicable_to_company(method, move.company_id),
            //         partner.peppol_verification_state == 'valid',
            //         move.company_id.account_peppol_proxy_state != 'rejected',
            //         move._need_ubl_cii_xml(invoice_edi_format)
            //         or move.ubl_cii_xml_id and move.peppol_move_state not in ('processing', 'done'),
            //     ])
            // else:
            //     return super()._is_applicable_to_move(method, move, **move_data)
            --- ODOO METHOD SOURCE (MODULE: snailmail_account, FILE: account_move_send.py) ---
            // def _is_applicable_to_move(self, method, move, **move_data):
            // # EXTENDS 'account'
            // if method == 'snailmail':
            //     return self.env['snailmail.letter']._is_valid_address(move.partner_id)
            // else:
            //     return super()._is_applicable_to_move(method, move, **move_data)
            */
            return default;
        }

        public async Task<TEntity> LinkInvoiceDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _link_invoice_documents(self, invoices_data):
            // """ Create the attachments containing the pdf/electronic documents for the invoice passed as parameter.
            // :param invoice:         An account.move record.
            // :param invoice_data:    The collected data for the invoice so far.
            // """
            // # create an attachment that will become 'invoice_pdf_report_file'
            // # note: Binary is used for security reason
            // attachment_to_create = [invoice_data['pdf_attachment_values'] for invoice_data in invoices_data.values() if invoice_data.get('pdf_attachment_values')]
            // if not attachment_to_create:
            //     return
            // 
            // attachments = self.sudo().env['ir.attachment'].create(attachment_to_create)
            // res_id_to_attachment = {attachment.res_id: attachment for attachment in attachments}
            // 
            // for invoice, invoice_data in invoices_data.items():
            //     if attachment := res_id_to_attachment.get(invoice.id):
            //         invoice.message_main_attachment_id = attachment
            //         invoice.invalidate_recordset(fnames=['invoice_pdf_report_id', 'invoice_pdf_report_file'])
            //         invoice.is_move_sent = True
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _link_invoice_documents(self, invoices_data):
            // # EXTENDS 'account'
            // super()._link_invoice_documents(invoices_data)
            // 
            // attachments_vals = [
            //     invoice_data.get('ubl_cii_xml_attachment_values')
            //     for invoice_data in invoices_data.values()
            //     if invoice_data.get('ubl_cii_xml_attachment_values')
            // ]
            // if attachments_vals:
            //     attachments = self.env['ir.attachment'].with_user(SUPERUSER_ID).create(attachments_vals)
            //     res_ids = attachments.mapped('res_id')
            //     self.env['account.move'].browse(res_ids).invalidate_recordset(fnames=['ubl_cii_xml_id', 'ubl_cii_xml_file'])
            */
            return default;
        }

        public async Task<TEntity> PostprocessInvoiceUblXmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _postprocess_invoice_ubl_xml(self, invoice, invoice_data):
            // """
            // Include the PDF in the UBL as an AdditionalDocumentReference element.
            // 
            // According to UBL 2.1 standard, the AdditionalDocumentReference element should be
            // placed above ProjectReference which isn't usually in xml files.
            // So usually it's set above AccountingSupplierParty. Here, we try to find a suitable anchor point among
            // the available element to insert our PDF attachment. If none of these are found, we
            // skip adding the attachment to avoid breaking the XML structure.
            // Inside CreditNote, the ProjectReference element is not used in xml.
            // So we look for OriginatorDocumentReference instead.
            // """
            // tree = etree.fromstring(invoice_data['ubl_cii_xml_attachment_values']['raw'])
            // 
            // localname = etree.QName(tree).localname
            // anchor_xpath = {
            //     'Invoice': "//*[local-name()='ProjectReference' or local-name()='Signature' or local-name()='AccountingSupplierParty']",
            //     'CreditNote': "//*[local-name()='StatementDocumentReference' or local-name()='OriginatorDocumentReference' or local-name()='Signature' or local-name()='AccountingSupplierParty']",
            //     'DebitNote': "//*[local-name()='Signature' or local-name()='AccountingSupplierParty']",
            // }.get(localname)
            // 
            // anchor_elements = tree.xpath(anchor_xpath)
            // 
            // if not anchor_elements:
            //     return
            // 
            // anchor_index = tree.index(anchor_elements[0])
            // pdf_values = invoice.invoice_pdf_report_id or invoice_data.get('pdf_attachment_values') or invoice_data['proforma_pdf_attachment_values']
            // 
            // edi_model = invoice_data["ubl_cii_xml_options"]["builder"]
            // doc_type_code_node = edi_model._get_document_type_code_node(invoice, invoice_data)
            // vals = {'invoice': invoice}
            // edi_model._add_invoice_config_vals(vals)
            // nsmap = edi_model._get_document_nsmap(vals)
            // 
            // attachments_to_embed = [
            //     {
            //         'filename': attachment.name,
            //         'raw': attachment.raw,
            //         'mimetype': attachment.mimetype,
            //     }
            //     for attachment in self._get_ubl_available_attachments(
            //         invoice_data['mail_attachments_widget'],
            //         invoice_data['invoice_edi_format']
            //     )[0]
            // ] if invoice_data.get('mail_attachments_widget') else []
            // attachments_to_embed.append({
            //     'filename': pdf_values['name'],
            //     'raw': pdf_values['raw'],
            //     'mimetype': pdf_values['mimetype'],
            //     'document_type_node': doc_type_code_node,
            // })
            // 
            // for attachment_values in attachments_to_embed:
            //     additional_document_reference_node = {
            //         '_tag': 'cac:AdditionalDocumentReference',
            //         'cbc:ID': {'_text': attachment_values['filename']},
            //         'cbc:DocumentTypeCode': attachment_values.get('document_type_node'),
            //         'cac:Attachment': {
            //             'cbc:EmbeddedDocumentBinaryObject': {
            //                 '_text': base64.b64encode(attachment_values['raw']).decode(),
            //                 'mimeCode': attachment_values['mimetype'],
            //                 'filename': attachment_values['filename']
            //             }
            //         }
            //     }
            //     tree.insert(anchor_index, dict_to_xml(additional_document_reference_node, nsmap=nsmap))
            // 
            // invoice_data['ubl_cii_xml_attachment_values']['raw'] = etree.tostring(
            //     cleanup_xml_node(tree), xml_declaration=True, encoding='UTF-8'
            // )
            #endif
            return default;
        }

        public async Task<TEntity> PrepareInvoicePdfReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _prepare_invoice_pdf_report(self, invoices_data):
            // """ Prepare the pdf report for the invoice passed as parameter.
            // :param invoice:         An account.move record.
            // :param invoice_data:    The collected data for the invoice so far.
            // """
            // 
            // company_id = next(iter(invoices_data)).company_id
            // grouped_invoices_by_report = defaultdict(dict)
            // for invoice, invoice_data in invoices_data.items():
            //     grouped_invoices_by_report[invoice_data['pdf_report']][invoice] = invoice_data
            // 
            // for pdf_report, group_invoices_data in grouped_invoices_by_report.items():
            //     ids = [inv.id for inv in group_invoices_data]
            // 
            //     content, report_type = self.env['ir.actions.report'].with_company(company_id)._pre_render_qweb_pdf(pdf_report.report_name, res_ids=ids)
            //     content_by_id = self.env['ir.actions.report']._get_splitted_report(pdf_report.report_name, content, report_type)
            //     if len(content_by_id) == 1 and False in content_by_id:
            //         raise ValidationError(_("Cannot identify the invoices in the generated PDF: %s", ids))
            // 
            //     for invoice, invoice_data in group_invoices_data.items():
            //         invoice_data['pdf_attachment_values'] = {
            //             'name': invoice._get_invoice_report_filename(report=pdf_report),
            //             'raw': content_by_id[invoice.id],
            //             'mimetype': 'application/pdf',
            //             'res_model': invoice._name,
            //             'res_id': invoice.id,
            //             'res_field': 'invoice_pdf_report_file',  # Binary field
            //         }
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceProformaPdfReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _prepare_invoice_proforma_pdf_report(self, invoice, invoice_data):
            // """ Prepare the proforma pdf report for the invoice passed as parameter.
            // :param invoice:         An account.move record.
            // :param invoice_data:    The collected data for the invoice so far.
            // """
            // pdf_report = invoice_data['pdf_report']
            // content, report_type = self.env['ir.actions.report'].with_company(invoice.company_id)._pre_render_qweb_pdf(pdf_report.report_name, invoice.ids, data={'proforma': True})
            // content_by_id = self.env['ir.actions.report']._get_splitted_report(pdf_report.report_name, content, report_type)
            // 
            // invoice_data['proforma_pdf_attachment_values'] = {
            //     'raw': content_by_id[invoice.id],
            //     'name': invoice._get_invoice_proforma_pdf_report_filename(),
            //     'mimetype': 'application/pdf',
            //     'res_model': invoice._name,
            //     'res_id': invoice.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareSnailmailLetterValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail_account, FILE: account_move_send.py) ---
            // def _prepare_snailmail_letter_values(self, move):
            // return {
            //     'partner_id': move.partner_id.id,
            //     'model': 'account.move',
            //     'res_id': move.id,
            //     'company_id': move.company_id.id,
            //     'report_template': self.env['ir.actions.report']._get_report('account.account_invoices').id
            // }
            */
            return default;
        }

        public async Task<TEntity> RaiseDangerAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alerts) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _raise_danger_alerts(self, alerts):
            // danger_alert_messages = [alert['message'] for _key, alert in alerts.items() if alert.get('level') == 'danger']
            // if danger_alert_messages:
            //     raise UserError('\n'.join(danger_alert_messages))
            */
            return default;
        }

        public async Task<TEntity> SendMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _send_mail(self, move, mail_template, **kwargs):
            // """ Send the journal entry passed as parameter by mail. """
            // new_message = move.with_context(
            //     email_notification_allow_footer=True,
            //     disable_attachment_import=True,
            //     no_document=True,
            // ).message_post(
            //     message_type='comment',
            //     **kwargs,
            //     **{  # noqa: PIE804
            //         'email_layout_xmlid': self._get_mail_layout(),
            //         'email_add_signature': not mail_template,
            //         'mail_auto_delete': mail_template.auto_delete,
            //         'mail_server_id': mail_template.mail_server_id.id,
            //         'reply_to_force_new': False,
            //     }
            // )
            // 
            // # Prevent duplicated attachments linked to the invoice.
            // new_message.attachment_ids.invalidate_recordset(['res_id', 'res_model'], flush=False)
            // if new_message.attachment_ids.ids:
            //     self.env.cr.execute("UPDATE ir_attachment SET res_id = NULL WHERE id IN %s", [tuple(new_message.attachment_ids.ids)])
            // new_message.attachment_ids.write({
            //     'res_model': new_message._name,
            //     'res_id': new_message.id,
            // })
            */
            return default;
        }

        public async Task<TEntity> SendMailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _send_mails(self, moves_data):
            // subtype = self.env.ref('mail.mt_comment')
            // 
            // self._generate_dynamic_reports(moves_data)
            // 
            // for move, move_data in [
            //     (move, move_data)
            //     for move, move_data in moves_data.items()
            //     if move.partner_id.email or move_data.get('mail_partner_ids')
            // ]:
            //     mail_template = move_data['mail_template']
            //     mail_lang = move_data['mail_lang']
            //     mail_params = self._get_mail_params(move, move_data)
            //     if not mail_params:
            //         continue
            // 
            //     if move_data.get('proforma_pdf_attachment'):
            //         attachment = move_data['proforma_pdf_attachment']
            //         mail_params['attachments'].append((attachment.name, attachment.raw))
            // 
            //     # synchronize author / email_from, as account.move.send wizard computes
            //     # a bit too much stuff
            //     author_id = mail_params.pop('author_id', False)
            //     email_from = self._get_mail_default_field_value_from_template(mail_template, mail_lang, move, 'email_from')
            //     if email_from or not author_id:
            //         author_id, email_from = move._message_compute_author(email_from=email_from)
            //     model_description = move.with_context(lang=mail_lang).type_name
            // 
            //     self._send_mail(
            //         move,
            //         mail_template,
            //         author_id=author_id,
            //         subtype_id=subtype.id,
            //         model_description=model_description,
            //         notify_author_mention=True,
            //         email_from=email_from,
            //         **mail_params,
            //     )
            */
            return default;
        }

        public async Task<TEntity> SendNotificationsToPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid moves_grouped_by_author_partner_id, object is_success) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _send_notifications_to_partners(self, moves_grouped_by_author_partner_id, is_success=True):
            // if not moves_grouped_by_author_partner_id:
            //     return
            // 
            // def get_account_notification(move_ids, is_success: bool):
            //     _ = self.env._
            //     return [
            //         'account_notification',
            //         {
            //             'type': 'success' if is_success else 'warning',
            //             'title': _("Invoices sent") if is_success else _("Invoices in error"),
            //             'message': _("Invoices sent successfully.") if is_success else _(
            //                 "One or more invoices couldn't be processed."),
            //             'action_button': {
            //                 'name': _('Open'),
            //                 'action_name': _("Sent invoices") if is_success else _("Invoices in error"),
            //                 'model': 'account.move',
            //                 'res_ids': move_ids,
            //             },
            //         },
            //     ]
            // ResPartner = self.env['res.partner']
            // for partner_id, move_ids in moves_grouped_by_author_partner_id.items():
            //     partner = ResPartner.browse(partner_id)
            //     partner._bus_send(*get_account_notification(move_ids, is_success))
            */
            return default;
        }
    }
}