using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("account", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountMoveSendAppService : ApplicationService, IAccountMoveSendAppService
    {

        public AccountMoveSendAppService() 
        {

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
            //     if 'peppol' in invoice_data['sending_methods']:
            //         if not partner.peppol_eas or not partner.peppol_endpoint:
            //             invoice.peppol_move_state = 'error'
            //             invoice_data['error'] = _('The partner is missing Peppol EAS and/or Endpoint identifier.')
            //             continue
            // 
            //         if self.env['res.partner']._get_peppol_verification_state(partner.peppol_endpoint, partner.peppol_eas, invoice_data['invoice_edi_format']) != 'valid':
            //             invoice.peppol_move_state = 'error'
            //             invoice_data['error'] = _('Please verify partner configuration in partner settings.')
            //             continue
            // 
            //         if not self._is_applicable_to_move('peppol', invoice, **invoice_data):
            //             continue
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
            // edi_user = next(iter(invoices_data)).company_id.account_edi_proxy_client_ids.filtered(
            //     lambda u: u.proxy_type == 'peppol')
            // 
            // try:
            //     response = edi_user._call_peppol_proxy(
            //         "/api/peppol/1/send_document",
            //         params=params,
            //     )
            // except AccountEdiProxyError as e:
            //     for invoice, invoice_data in invoices_data_peppol.items():
            //         invoice.peppol_move_state = 'error'
            //         invoice_data['error'] = e.message
            // else:
            //     if response.get('error'):
            //         # at the moment the only error that can happen here is ParticipantNotReady error
            //         for invoice, invoice_data in invoices_data_peppol.items():
            //             invoice.peppol_move_state = 'error'
            //             invoice_data['error'] = response['error']['message']
            //     else:
            //         # the response only contains message uuids,
            //         # so we have to rely on the order to connect peppol messages to account.move
            //         invoices = self.env['account.move']
            //         for message, (invoice, invoice_data) in zip(response['messages'], invoices_data_peppol.items()):
            //             invoice.peppol_message_uuid = message['message_uuid']
            //             invoice.peppol_move_state = 'processing'
            //             invoices |= invoice
            //         log_message = _('The document has been sent to the Peppol Access Point for processing')
            //         invoices._message_log_batch(bodies={invoice.id: log_message for invoice in invoices})
            //         self.env.ref('account_peppol.ir_cron_peppol_get_message_status')._trigger(at=fields.Datetime.now() + timedelta(minutes=5))
            // 
            // if self._can_commit():
            //     self._cr.commit()
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: account_move_send.py) ---
            // def _call_web_service_after_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_after_invoice_pdf_render(invoices_data)
            // attachments_vals = {}
            // moves = self.env['account.move']
            // for move, move_data in invoices_data.items():
            //     if 'it_edi_send' in move_data['extra_edis']:
            //         if attachment := move.l10n_it_edi_attachment_id:
            //             attachments_vals[move] = {'name': attachment.name, 'raw': attachment.raw}
            //             moves |= move
            //         elif edi_values := move_data.get('l10n_it_edi_values'):
            //             attachments_vals[move] = edi_values
            //             moves |= move
            // moves._l10n_it_edi_send(attachments_vals)
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_move_send.py) ---
            // def _call_web_service_after_invoice_pdf_render(self, invoices_data):
            // """
            // We need to get the submission status (valid, invalid) now for the flow to make sense.
            // If we follow their documentation, the status should be available near instantly (in 2s of the submission) which
            // means that it should be there in the time we get the submission response back and generate the invoice(s) pdf.
            // 
            // We will try up to three time with a 2s delay to make it happen. It should cover most of the use cases, as long as
            // there are no network issues/...
            // 
            // If after three time the invoice still has not been processed, we will move on and leave the update to the
            // scheduled action that fetches new incoming invoices and update statuses at the same time.
            // """
            // # EXTENDS 'account'
            // super()._call_web_service_after_invoice_pdf_render(invoices_data)
            // 
            // moves_in_progress = self.env['account.move']
            // for move, move_data in invoices_data.items():
            //     if 'my_myinvois_send' not in move_data['extra_edis'] or move.l10n_my_edi_state != 'in_progress':
            //         continue
            // 
            //     moves_in_progress |= move
            // 
            // # We want to ensure that we do not do anything more for moves which failed basic validations.
            // if moves_in_progress:
            //     # This update can fail, but we don't consider that as a blocking error.
            //     # If the api request fails (timeout, validation not finished, ...) it'll be retried in the cron `ir_cron_myinvois_sync`.
            //     retry = 0
            //     errors, any_in_progress = moves_in_progress._l10n_my_edi_fetch_updated_statuses()
            //     while any_in_progress and retry < 2:
            //         time.sleep(1)  # We wait a second before retrying.
            //         errors, any_in_progress = moves_in_progress._l10n_my_edi_fetch_updated_statuses()
            //         retry += 1
            // 
            //     # While technically an in_progress status is not an error, it won't hurt much to display it as such.
            //     # The "error" message in this case should be clear enough.
            //     if errors:
            //         for move, move_data in invoices_data.items():
            //             if move in errors:
            //                 move_data['error'] = {
            //                     'error_title': _('Error when fetching statuses from the E-invoicing service.'),
            //                     'errors': errors[move],
            //                 }
            // 
            //     # We commit again if possible, to ensure that the invoice status is set in the database in case of errors later.
            //     if self._can_commit():
            //         self._cr.commit()
            --- ODOO METHOD SOURCE (MODULE: l10n_ro_edi, FILE: account_move_send.py) ---
            // def _call_web_service_after_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_after_invoice_pdf_render(invoices_data)
            // 
            // for invoice, invoice_data in invoices_data.items():
            //     if 'ro_edi' in invoice_data['extra_edis']:
            //         build_errors = None
            //         if invoice_data.get('ubl_cii_xml_attachment_values'):
            //             xml_data = invoice_data['ubl_cii_xml_attachment_values']['raw']
            //         elif invoice.l10n_ro_edi_document_ids:
            //             # If a document is on the invoice but the invoice's l10n_ro_edi_state is False,
            //             # this means that the previously sent XML are invalid and have to be rebuilt
            //             xml_data, build_errors = self.env['account.edi.xml.ubl_ro']._export_invoice(invoice)
            //         elif invoice.ubl_cii_xml_id:
            //             xml_data = invoice.ubl_cii_xml_id.raw
            //         else:
            //             xml_data, build_errors = self.env['account.edi.xml.ubl_ro']._export_invoice(invoice)
            // 
            //         if build_errors:
            //             invoice_data['error'] = {
            //                 'error_title': _("Error when building the CIUS-RO E-Factura XML"),
            //                 'errors': build_errors,
            //             }
            //             continue
            // 
            //         if self._can_commit():
            //             self.env.cr.commit()
            // 
            //         invoice._l10n_ro_edi_send_invoice(xml_data)
            // 
            //         if self._can_commit():
            //             self.env.cr.commit()
            // 
            //         active_document = invoice.l10n_ro_edi_document_ids.sorted()[0]
            // 
            //         if active_document.state == 'invoice_sending_failed':
            //             invoice_data['error'] = {
            //                 'error_title': _("Error when sending CIUS-RO E-Factura to the SPV"),
            //                 'errors': active_document.message.split('\n'),
            //             }
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_move_send.py) ---
            // def _call_web_service_after_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_after_invoice_pdf_render(invoices_data)
            // for invoice, invoice_data in invoices_data.items():
            //     # Not all invoices may need EDI.
            //     if 'rs_edi' not in invoice_data['extra_edis']:
            //         continue
            //     if not invoice.company_id.l10n_rs_edi_api_key:
            //         invoice_data["error"] = {
            //             "error_title": _("eFaktura API Key is missing."),
            //             "errors": [_("Please configure the eFaktura API Key in the company settings.")],
            //         }
            //         continue
            //     send_to_cir = 'rs_cir_checkbox' in invoice_data['extra_edis']
            //     xml, error = invoice._l10n_rs_edi_send(send_to_cir)
            //     if error:
            //         invoice_data["error"] = {
            //             "error_title": _("Errors when submitting the e-invoice to eFaktura:"),
            //             "errors": [error],
            //         }
            //         continue
            //     invoice_data['l10n_rs_edi_attachment_values'] = invoice._l10n_rs_edi_get_attachment_values(xml)
            // 
            //     if self._can_commit():
            //         self._cr.commit()
            --- ODOO METHOD SOURCE (MODULE: l10n_vn_edi_viettel, FILE: account_move_send.py) ---
            // def _call_web_service_after_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_after_invoice_pdf_render(invoices_data)
            // for invoice, invoice_data in invoices_data.items():
            //     # Handle the json file, and create it if it does not yet exist. This can be done without sending to the EDI.
            //     json_file_data = [file for file in invoice_data.get('sinvoice_attachments', []) if file['mimetype'] == 'application/json']
            // 
            //     if not invoice.l10n_vn_edi_sinvoice_file and json_file_data:
            //         self.env['ir.attachment'].with_user(SUPERUSER_ID).create(json_file_data)
            //         invoice.invalidate_recordset(fnames=[
            //             'l10n_vn_edi_sinvoice_file_id',
            //             'l10n_vn_edi_sinvoice_file',
            //         ])
            // 
            //     if invoice.l10n_vn_edi_invoice_state != 'sent':
            //         continue
            // 
            //     # Download SInvoice documents in order to attach them to the email we sent to the customer.
            //     # If the email is not being sent, we will still get the files and attach them to the invoice.
            //     xml_data, xml_error_message = invoice._l10n_vn_edi_fetch_invoice_xml_file_data()
            //     pdf_data, pdf_error_message = invoice._l10n_vn_edi_fetch_invoice_pdf_file_data()
            //     if xml_error_message or pdf_error_message:
            //         invoice_data['error'] = {
            //             'error_title': _('Error when receiving SInvoice files.'),
            //             'errors': [error_message for error_message in [xml_error_message, pdf_error_message] if error_message],
            //         }
            // 
            //     # Not using _link_invoice_documents for these because it depends on _need_invoice_document and I can't get it to work
            //     # well while allowing users to download the files before sending.
            //     attachments_data = []
            //     for file, error in [(xml_data, xml_error_message), (pdf_data, pdf_error_message)]:
            //         if error:
            //             continue
            // 
            //         attachments_data.append({
            //             'name': file['name'],
            //             'raw': file['raw'],
            //             'mimetype': file['mimetype'],
            //             'res_model': invoice._name,
            //             'res_id': invoice.id,
            //             'res_field': file['res_field'],  # Binary field
            //         })
            // 
            //     if attachments_data:
            //         attachments = self.env['ir.attachment'].with_user(SUPERUSER_ID).create(attachments_data)
            //         invoice.invalidate_recordset(fnames=[
            //             'l10n_vn_edi_sinvoice_xml_file_id',
            //             'l10n_vn_edi_sinvoice_xml_file',
            //             'l10n_vn_edi_sinvoice_pdf_file_id',
            //             'l10n_vn_edi_sinvoice_pdf_file',
            //         ])
            // 
            //         # Log the new attachment in the chatter for reference. Make sure to add the JSON file.
            //         invoice.with_context(no_new_invoice=True).message_post(
            //             body=_('Invoice sent to SInvoice'),
            //             attachment_ids=attachments.ids + invoice.l10n_vn_edi_sinvoice_file_id.ids,
            //         )
            // 
            //     if self._can_commit():
            //         self._cr.commit()
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
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_tbai, FILE: account_move_send.py) ---
            // def _call_web_service_before_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_before_invoice_pdf_render(invoices_data)
            // 
            // for invoice, invoice_data in invoices_data.items():
            // 
            //     if 'es_tbai' in invoice_data['extra_edis']:
            //         error = invoice._l10n_es_tbai_post()
            // 
            //         if error:
            //             invoice_data['error'] = {
            //                 'error_title': _("Error when sending the invoice to TicketBAI:"),
            //                 'errors': [error],
            //             }
            // 
            //         if self._can_commit():
            //             self._cr.commit()
            --- ODOO METHOD SOURCE (MODULE: l10n_gr_edi, FILE: account_move_send.py) ---
            // def _call_web_service_before_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_before_invoice_pdf_render(invoices_data)
            // 
            // invoices = self.env['account.move']
            // for invoice, invoice_data in invoices_data.items():
            //     if 'gr_edi' in invoice_data['extra_edis']:
            //         invoices |= invoice
            // 
            // # Send multiple invoice at once (if available) in one batch
            // if invoices:
            //     invoices.l10n_gr_edi_try_send_invoices()
            // 
            // for invoice, invoice_data in invoices_data.items():
            //     if invoice in invoices and invoice.l10n_gr_edi_state != 'invoice_sent':
            //         invoice_data['error'] = {
            //             'error_title': _("Error when sending invoice to myDATA"),
            //             'errors': [invoice.l10n_gr_edi_document_ids.sorted()[0].message],
            //         }
            --- ODOO METHOD SOURCE (MODULE: l10n_hu_edi, FILE: account_move_send.py) ---
            // def _call_web_service_before_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_before_invoice_pdf_render(invoices_data)
            // 
            // invoices_hu = self.env['account.move'].browse([
            //     invoice.id
            //     for invoice, invoice_data in invoices_data.items()
            //     if 'hu_nav_30' in invoice_data['extra_edis']
            //        and 'upload' in invoice._l10n_hu_edi_get_valid_actions()
            // ])
            // 
            // if not invoices_hu:
            //     return
            // 
            // # Pre-emptively acquire write lock on all invoices to be processed
            // # Otherwise, we will get a serialization error later
            // # (bad, because Odoo will try to retry the entire request, leading to duplicate sending to NAV)
            // invoices_hu._l10n_hu_edi_acquire_lock()
            // 
            // # STEP 1: Generate and send the invoice XMLs.
            // invoices_to_upload = invoices_hu.filtered(lambda m: 'upload' in m._l10n_hu_edi_get_valid_actions())
            // 
            // # If we need to re-generate the PDF, break the link between the existing attachment and the 'invoice_pdf_report_file' field.
            // # The existing PDF will remain linked to the invoice, but no longer as primary attachment.
            // invoices_to_upload.invoice_pdf_report_id.write({'res_field': False})
            // invoices_to_upload.invalidate_recordset(fnames=['invoice_pdf_report_id', 'invoice_pdf_report_file'])
            // 
            // with L10nHuEdiConnection(self.env) as connection:
            //     invoices_to_upload._l10n_hu_edi_upload(connection)
            //     if self._can_commit():
            //         self.env.cr.commit()
            // 
            //     if any(m.l10n_hu_edi_state == 'sent' for m in invoices_hu):
            //         # If any invoices were just sent, wait so that NAV has enough time to process them
            //         time.sleep(2)
            // 
            //     # STEP 2: Query status
            //     invoices_hu.filtered(lambda m: 'query_status' in m._l10n_hu_edi_get_valid_actions())._l10n_hu_edi_query_status(connection)
            // 
            // # STEP 3: Schedule update status of pending invoices in 10 minutes.
            // if any(m.l10n_hu_edi_state not in [False, 'confirmed', 'confirmed_warning', 'rejected'] for m in invoices_hu):
            //     self.env.ref('l10n_hu_edi.ir_cron_update_status')._trigger(at=fields.Datetime.now() + timedelta(minutes=10))
            // 
            // # STEP 4: Error / success handling.
            // for invoice in invoices_hu:
            //     # Log outcome in chatter
            //     formatted_message = self._format_error_html(invoice.l10n_hu_edi_messages)
            //     invoice.with_context(no_new_invoice=True).message_post(body=formatted_message)
            // 
            //     # Update invoice_data with errors
            //     blocking_level = invoice.l10n_hu_edi_messages.get('blocking_level')
            //     if blocking_level == 'error':
            //         invoices_data[invoice]['error'] = invoice.l10n_hu_edi_messages
            // 
            // if self._can_commit():
            //     self.env.cr.commit()
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_move_send.py) ---
            // def _call_web_service_before_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_before_invoice_pdf_render(invoices_data)
            // 
            // for invoice, invoice_data in invoices_data.items():
            //     if 'jo_edi' in invoice_data['extra_edis']:
            //         if error_message := invoice.with_company(invoice.company_id)._l10n_jo_edi_send():
            //             invoice_data["error"] = {
            //                 "error_title": _("Errors when submitting the JoFotara e-invoice:"),
            //                 "errors": [error_message],
            //             }
            // 
            //         if self._can_commit():
            //             self._cr.commit()
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_move_send.py) ---
            // def _call_web_service_before_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_before_invoice_pdf_render(invoices_data)
            // 
            // xml_contents = defaultdict(list)
            // moves = self.env['account.move']
            // # This step is skipped if the move was sent, but not validated.
            // for move, move_data in invoices_data.items():
            //     if 'my_myinvois_send' not in move_data['extra_edis']:
            //         continue
            // 
            //     moves |= move
            //     if 'myinvois_attachments' in move_data:
            //         xml_content = move_data['myinvois_attachments'][0]['raw'].decode('utf-8')
            //     # If the invoice was downloaded but not sent, the json file could already be there.
            //     elif move.l10n_my_edi_file:
            //         xml_content = base64.b64decode(move.l10n_my_edi_file).decode('utf-8')
            //     # If we don't have the file data and the file, we will regenerate it.
            //     else:
            //         self._l10n_my_edi_generate_myinvois_xml(move, move_data)
            //         if 'myinvois_attachments' not in move_data:
            //             continue  # If an error occurred, it'll be in move_data['error'] so we can skip this invoice
            //         xml_content = move_data['myinvois_attachments'][0]['raw'].decode('utf-8')
            //     xml_contents[move] = xml_content
            // 
            // if moves and xml_contents:
            //     errors = moves._l10n_my_edi_submit_documents(xml_contents)
            // 
            //     if errors:
            //         for move, move_data in invoices_data.items():
            //             if move in errors:
            //                 move_data['error'] = {
            //                     'error_title': _('Error when sending the invoices to the E-invoicing service.'),
            //                     'errors': errors[move],
            //                 }
            // 
            //     # Whatever happened, we need to commit once at this point, because another api call is done later on
            //     # And in case of single invoice, a request error could raise => We would lose the uuid etc.
            //     if self._can_commit():
            //         self._cr.commit()
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_move_send.py) ---
            // def _call_web_service_before_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_before_invoice_pdf_render(invoices_data)
            // 
            // to_process = self.env['account.move']
            // for invoice, invoice_data in invoices_data.items():
            //     if 'sa_edi' in invoice_data['extra_edis']:
            //         to_process |= invoice
            // to_process.action_process_edi_web_services()
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_move_send.py) ---
            // def _call_web_service_before_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_before_invoice_pdf_render(invoices_data)
            // 
            // for invoice, invoice_data in invoices_data.items():
            //     if 'tr_nilvera' in invoice_data['extra_edis']:
            //         if attachment_values := invoice_data.get('ubl_cii_xml_attachment_values'):
            //             xml_file = BytesIO(attachment_values.get('raw'))
            //             xml_file.name = attachment_values['name']
            //         else:
            //             xml_file = BytesIO(invoice.ubl_cii_xml_id.raw or b'')
            //             xml_file.name = invoice.ubl_cii_xml_id.name or ''
            // 
            //         if not invoice.partner_id.l10n_tr_nilvera_customer_alias_id:
            //             # If no alias is saved, the user is either an E-Archive user or we haven't checked before. Check again
            //             # just in case.
            //             invoice.partner_id.check_nilvera_customer()
            //         customer_alias = invoice.partner_id.l10n_tr_nilvera_customer_alias_id.name
            //         if customer_alias:  # E-Invoice
            //             invoice._l10n_tr_nilvera_submit_einvoice(xml_file, customer_alias)
            //         else:   # E-Archive
            //             invoice._l10n_tr_nilvera_submit_earchive(xml_file)
            --- ODOO METHOD SOURCE (MODULE: l10n_vn_edi_viettel, FILE: account_move_send.py) ---
            // def _call_web_service_before_invoice_pdf_render(self, invoices_data):
            // # EXTENDS 'account'
            // super()._call_web_service_before_invoice_pdf_render(invoices_data)
            // for invoice, invoice_data in invoices_data.items():
            //     if 'vn_sinvoice_send' in invoice_data['extra_edis']:
            //         errors = invoice._l10n_vn_edi_check_invoice_configuration()
            //         if not errors:
            //             if 'sinvoice_attachments' in invoice_data:
            //                 json_data = json.loads(invoice_data['sinvoice_attachments'][0]['raw'].decode('utf-8'))
            //             # If the invoice was downloaded but not sent, the json file could already be there.
            //             elif invoice.l10n_vn_edi_sinvoice_file:
            //                 json_data = json.loads(base64.b64decode(invoice.l10n_vn_edi_sinvoice_file).decode('utf-8'))
            //             # If we don't have the file data and the file, we will regenerate it.
            //             else:
            //                 self._generate_sinvoice_file_date(invoice, invoice_data)
            //                 # In case the above call ended in an error, we skip setting json_data
            //                 if 'sinvoice_attachments' not in invoice_data:
            //                     continue
            //                 json_data = json.loads(invoice_data['sinvoice_attachments'][0]['raw'].decode('utf-8'))
            //             if json_data:
            //                 errors = invoice._l10n_vn_edi_send_invoice(json_data)
            // 
            //         if errors:
            //             invoice_data['error'] = {
            //                 'error_title': _('Error when sending to SInvoice'),
            //                 'errors': errors,
            //             }
            // 
            //         if self._can_commit():
            //             self._cr.commit()
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
            // return not modules.module.current_test
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
            //         and not custom_settings['pdf_report'].is_invoice_report
            //     )
            //     or any(not self._get_default_pdf_report_id(move).is_invoice_report for move in moves)
            // ):
            //     raise UserError(_("The sending of invoices is not set up properly, make sure the report used is set for invoices."))
            */
            return default;
        }

        public async Task<TEntity> CheckMoveConstrainsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _check_move_constrains(self, moves):
            // if any(move.state != 'posted' for move in moves):
            //     raise UserError(_("You can't generate invoices that are not posted."))
            // if any(not move.is_sale_document(include_receipts=True) for move in moves):
            //     raise UserError(_("You can only generate sales documents."))
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
            // self._check_move_constrains(moves)
            // self._check_invoice_report(moves, **custom_settings)
            // assert all(
            //     sending_method in dict(self.env['res.partner']._fields['invoice_sending_method'].selection)
            //     for sending_method in custom_settings.get('sending_methods', [])
            // ) if 'sending_methods' in custom_settings else True
            */
            return default;
        }

        public async Task<TEntity> DoPeppolPreSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _do_peppol_pre_send(self, moves):
            // if len(moves.company_id) == 1:
            //     can_send = self.env['account_edi_proxy_client.user']._get_can_send_domain()
            //     if moves.company_id.account_peppol_proxy_state not in can_send:
            //         registration_wizard = self.env['peppol.registration'].create({'company_id': moves.company_id.id})
            //         return registration_wizard._action_open_peppol_form(reopen=False)
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
            // """ Format the error that can be either a dict (complex format needed) or a string (simple format) into a
            // valid html format.
            // 
            // :param error: the error to format.
            // :return: a html formatted error.
            // """
            // if isinstance(error, dict):
            //     errors = Markup().join(Markup("<li>%s</li>") % error for error in error['errors'])
            //     return Markup("%s<ul>%s</ul>") % (error['error_title'], errors)
            // else:
            //     return error
            */
            return default;
        }

        public async Task<TEntity> FormatErrorTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _format_error_text(self, error):
            // """ Format the error that can be either a dict (complex format needed) or a string (simple format) into a
            // regular string.
            // 
            // :param error: the error to format.
            // :return: a text formatted error.
            // """
            // if isinstance(error, dict):
            //     errors = '\n- '.join(error['errors'])
            //     return f"{error['error_title']}\n- {errors}" if errors else error['error_title']
            // else:
            //     return error
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
            //     self._hook_if_success(success)
            // 
            // # Update sending data of moves
            // for move, move_data in moves_data.items():
            //     if from_cron and move_data.get('error'):
            //         move.sending_data = {'error': True}
            //     else:
            //         move.sending_data = False
            // 
            // # Return generated attachments.
            // attachments = self.env['ir.attachment']
            // for move, move_data in success.items():
            //     attachments += self._get_invoice_extra_attachments(move) or move_data['proforma_pdf_attachment']
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

        public async Task<TEntity> GenerateSinvoiceFileDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_vn_edi_viettel, FILE: account_move_send.py) ---
            // def _generate_sinvoice_file_date(self, invoice, invoice_data):
            // # Ensure that we still generate the file if 'generate' is ul10n_vn_edi_invoice_transaction_id-checked but send it.
            // need_file = (
            //     (invoice_data['invoice_edi_format'] == 'vn_sinvoice' and invoice._l10n_vn_edi_get_credentials_company())
            //     or 'vn_sinvoice_send' in invoice_data['extra_edis']
            // )
            // # In case we already have a json file existing on the invoice, we skip regenerating it.
            // if need_file and not invoice.l10n_vn_edi_sinvoice_file:
            //     errors = invoice._l10n_vn_edi_check_invoice_configuration()
            //     if not errors:
            //         json_data = invoice._l10n_vn_edi_generate_invoice_json()
            //         invoice_data['sinvoice_attachments'] = [{
            //             'name': f'{invoice.name.replace("/", "_")}_sinvoice.json',
            //             'raw': json.dumps(json_data, ensure_ascii=False).encode('utf8'),
            //             'mimetype': 'application/json',
            //             'res_model': invoice._name,
            //             'res_id': invoice.id,
            //             'res_field': 'l10n_vn_edi_sinvoice_file',  # Binary field
            //         }]
            //     else:
            //         invoice_data['error'] = {
            //             'error_title': _('Error when generating SInvoice file.'),
            //             'errors': errors,
            //         }
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
            // if len(moves) > 1 and (partners_without_mail := moves.filtered(
            //         lambda m: 'email' in moves_data[m]['sending_methods'] and not m.partner_id.email).partner_id
            // ):
            //     # should only appear in mass invoice sending
            //     alerts['account_missing_email'] = {
            //         'level': 'warning',
            //         'message': _("Partner(s) should have an email address."),
            //         'action_text': _("View Partner(s)"),
            //         'action': partners_without_mail._get_records_action(name=_("Check Partner(s) Email(s)")),
            //     }
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
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // def peppol_partner(moves):
            //     return moves.partner_id.commercial_partner_id
            // 
            // def filter_peppol_state(moves, states):
            //     return peppol_partner(moves.filtered(
            //         lambda m: self.env['res.partner']._get_peppol_verification_state(
            //             peppol_partner(m).peppol_endpoint,
            //             peppol_partner(m).peppol_eas,
            //             moves_data[m]['invoice_edi_format']) in states))
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
            // can_send = self.env['account_edi_proxy_client.user']._get_can_send_domain()
            // any_moves_not_sent_peppol = any(move.peppol_move_state not in ('processing', 'done') for move in moves)
            // always_on_companies = moves.company_id.filtered(
            //     lambda c: c.country_code in info_always_on_countries and c.account_peppol_proxy_state not in can_send
            // )
            // if always_on_companies and any_moves_not_sent_peppol and not filter_peppol_state(moves, ['not_valid', 'not_verified']):
            //     alerts.pop('account_edi_ubl_cii_configure_company', False)
            //     alerts['account_peppol_what_is_peppol'] = {
            //         'message': _("You can send this invoice electronically via Peppol."),
            //         **what_is_peppol_alert,
            //     }
            // elif (peppol_not_selected_partners := filter_peppol_state(not_peppol_moves, ['valid'])) and any_moves_not_sent_peppol:
            //     # Check for not peppol partners that are on the network.
            //     if len(peppol_not_selected_partners) == 1:
            //         alerts['account_peppol_partner_want_peppol'] = {
            //             'message': _(
            //                 "%s has requested electronic invoices reception on Peppol.",
            //                 peppol_not_selected_partners.display_name
            //             ),
            //             **what_is_peppol_alert,
            //         }
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: l10n_gr_edi, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // invoices_with_alert = moves.filtered('l10n_gr_edi_alerts')
            // 
            // if len(invoices_with_alert) == 1:
            //     alerts = invoices_with_alert.l10n_gr_edi_alerts
            // elif len(invoices_with_alert) > 1:
            //     alerts['l10n_gr_edi_not_ready_invoice'] = {
            //         'message': _("The following invoice(s) are not ready to be sent to myDATA: \n%s",
            //                      '\n'.join(f"- {move.display_name}" for move in invoices_with_alert)),
            //         'action_text': _("View Invoice(s)"),
            //         'action': invoices_with_alert._get_records_action(name=_("Check Invoice(s)")),
            //     }
            // 
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: l10n_hu_edi, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // hu_moves = moves.filtered(lambda m: 'hu_nav_30' in moves_data[m]['extra_edis'])
            // enabled_moves = moves.filtered(lambda m: 'upload' in m._l10n_hu_edi_get_valid_actions())._origin
            // if hu_moves - enabled_moves:
            //     alerts['l10n_hu_edi_checkbox_not_ticked'] = {
            //         'message': _("Invoices issued in Hungary must, with few exceptions, be reported to the NAV's Online-Invoice system.")
            //     }
            // else:
            //     alerts.update(enabled_moves._l10n_hu_edi_check_invoices())
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // if it_moves := moves.filtered(lambda m: 'it_edi_send' in moves_data[m]['extra_edis'] or moves_data[m]['invoice_edi_format'] == 'it_edi_xml'):
            //     if it_alerts := it_moves._l10n_it_edi_export_data_check():
            //         alerts.update(**it_alerts)
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // if non_eligible_jo_moves := moves.filtered(lambda m: 'jo_edi' in moves_data[m]['extra_edis'] and not self._l10n_jo_is_edi_applicable(m)):
            //     alerts['l10n_jo_edi_non_eligible_moves'] = {
            //         'message': _(
            //             "JoFotara e-invoicing was enabled but the following invoices cannot be e-invoiced:\n%(moves)s\n",
            //             moves="\n".join(f"- {move.display_name}" for move in non_eligible_jo_moves),
            //         ),
            //         'action_text': _("View Invoice(s)"),
            //         'action': non_eligible_jo_moves._get_records_action(name=_("Check Invoice(s)")),
            //     }
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi_extended, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // if self.env.company.l10n_jo_edi_demo_mode:
            //     alerts['l10n_jo_edi_demo_mode'] = {
            //         'level': 'info',
            //         'message': _("Demo mode is enabled."),
            //     }
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: l10n_ke_edi_tremol, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // if warning_moves := self._get_l10n_ke_edi_tremol_warning_moves(moves):
            //     alerts['l10n_ke_edi_tremol_warning_moves'] = {
            //         'message': self._get_l10n_ke_edi_tremol_warning_message(warning_moves),
            //         'action_text': _("View Invoice(s)"),
            //         'action': warning_moves._get_records_action(name=_("Check Invoice(s)")),
            //     }
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // if waiting_moves := moves.filtered(lambda m: m.l10n_my_edi_state == 'in_progress'):
            //     alerts['l10n_my_edi_warning_waiting_moves'] = {
            //         'message': _(
            //             "The following invoice(s) are waiting for validation from MyInvois: %(move_name_list)s."
            //             "Their status will be updated later on, or you can do it manually from the form view.",
            //             move_name_list=', '.join(waiting_moves.mapped('name'))
            //         ),
            //         'action_text': _("View Invoice(s)"),
            //         'action': waiting_moves._get_records_action(name=_("Check Invoice(s)")),
            //     }
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: l10n_ro_edi, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // # EXTENDS 'account'
            // alerts = super()._get_alerts(moves, moves_data)
            // if waiting_moves := moves.filtered(lambda m: m.l10n_ro_edi_state == 'invoice_sent'):
            //     alerts['l10n_ro_edi_warning_waiting_moves'] = {
            //         'message': _(
            //             "The following invoice(s) are waiting for answer from the Romanian SPV: %s."
            //             "We won't send them again.",
            //             ', '.join(waiting_moves.mapped('name'))
            //         ),
            //         'action_text': _("View Invoice(s)"),
            //         'action': waiting_moves._get_records_action(name=_("Check Invoice(s)")),
            //     }
            // return alerts
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_move_send.py) ---
            // def _get_alerts(self, moves, moves_data):
            // alerts = super()._get_alerts(moves, moves_data)
            // if tr_partners_missing_address := moves.filtered(
            //         lambda m: 'tr_nilvera' in moves_data[m]['extra_edis'] and (m.partner_id.country_code != 'TR' or not m.partner_id.city or not m.partner_id.state_id or not m.partner_id.street)
            // ).partner_id:
            //     alerts["partner_data_missing"] = {
            //         "message": _("The following partner(s) are either not Turkish or are missing one of those fields: city, state and street."),
            //         "action_text": _("View Partner(s)"),
            //         "action": tr_partners_missing_address._get_records_action(name=_("Check data on Partner(s)")),
            //     }
            // 
            // if tr_invalid_subscription_dates := moves.filtered(
            //     lambda move: move._l10n_tr_nilvera_einvoice_check_invalid_subscription_dates()
            // ):
            //     alerts["critical_invalid_subscription_dates"] = {
            //         "message": _("The following invoice(s) need to have the same Start Date and End Date on all their respective Invoice Lines."),
            //         "action_text": _("View Invoice(s)"),
            //         "action": tr_invalid_subscription_dates._get_records_action(
            //             name=_("Check data on Invoice(s)"),
            //         ),
            //         "level": "danger",
            //     }
            // 
            // if tr_einvoice_partners_missing_ref := moves.partner_id.filtered(
            //     lambda p: p.l10n_tr_nilvera_customer_status == "einvoice" and not p.ref
            // ):
            //     alerts["critical_partner_data_missing"] = {
            //         "message": _("The following E-Invoice partner(s) must have the reference field set to the tax office name."),
            //         "action_text": _("View Partner(s)"),
            //         "action": tr_einvoice_partners_missing_ref._get_records_action(name=_("Check reference on Partner(s)")
            //         ),
            //         "level": "danger",
            //     }
            // 
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
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_tbai, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'es_tbai': {'label': _("TicketBAI"), 'is_applicable': self._is_tbai_applicable, 'help': _('Send the e-invoice to the Basque Government.')}})
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_gr_edi, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res['gr_edi'] = {'label': _("myDATA"), 'is_applicable': self._is_gr_edi_applicable}
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_hu_edi, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'hu_nav_30': {'label': _("NAV 3.0"), 'is_applicable': self._is_hu_edi_applicable}})
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'it_edi_send': {'label': _("Send to Tax Agency"), 'is_applicable': self._is_it_edi_applicable, 'help': _("Send the e-invoice XML to the Italian Tax Agency.")}})
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'jo_edi': {'label': _("JoFotara (Jordan EDI)"), 'is_applicable': self._l10n_jo_is_edi_applicable}})
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self):
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'my_myinvois_send': {'label': _("Send to MyInvois"), 'is_applicable': self._is_my_edi_applicable}})
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_ro_edi, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'ro_edi': {'label': _("Send E-Factura to SPV"), 'is_applicable': self._is_ro_edi_applicable}})
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'rs_edi': {'label': 'eFaktura', 'is_applicable': self._is_rs_edi_applicable, 'help': 'Send the E-Invoice to Government via eFaktura'}})
            // res.update({'rs_cir_checkbox': {'is_applicable': self._is_rs_edi_applicable, 'label': _("Send to CIR"), 'help': _("Send to Central Invoice Register(For B2G and the public sector)")}})
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'sa_edi': {'label': _("Send to Zatca"), 'is_applicable': self._is_sa_edi_applicable}})
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'tr_nilvera': {'label': _("Send E-Invoice to Nilvera"), 'is_applicable': self._is_tr_nilvera_applicable}})
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_vn_edi_viettel, FILE: account_move_send.py) ---
            // def _get_all_extra_edis(self) -> dict:
            // # EXTENDS 'account'
            // res = super()._get_all_extra_edis()
            // res.update({'vn_sinvoice_send': {'label': _("Send to SInvoice"), 'is_applicable': self._is_vn_edi_applicable}})
            // return res
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
            // return move.partner_id.with_company(move.company_id).invoice_edi_format
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
            // return self._get_placeholder_mail_attachments_data(move, invoice_edi_format=invoice_edi_format, extra_edis=extra_edis) \
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
            // partners = self.env['res.partner'].with_company(move.company_id)
            // if mail_template.email_to:
            //     email_to = self._get_mail_default_field_value_from_template(mail_template, mail_lang, move, 'email_to')
            //     for mail_data in tools.email_split(email_to):
            //         partners |= partners.find_or_create(mail_data)
            // if mail_template.email_cc:
            //     email_cc = self._get_mail_default_field_value_from_template(mail_template, mail_lang, move, 'email_cc')
            //     for mail_data in tools.email_split(email_cc):
            //         partners |= partners.find_or_create(mail_data)
            // if mail_template.partner_to:
            //     partner_to = self._get_mail_default_field_value_from_template(mail_template, mail_lang, move, 'partner_to')
            //     partner_ids = mail_template._parse_partner_to(partner_to)
            //     partners |= self.env['res.partner'].sudo().browse(partner_ids).exists()
            // return partners.filtered('email')
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
            // return move.partner_id.with_company(move.company_id).invoice_template_pdf_report_id or self.env.ref('account.account_invoices')
            */
            return default;
        }

        public async Task<object> GetDefaultSendingMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_default_sending_method(self, move) -> set:
            // """ By default, we use the sending method set on the partner or email. """
            // return move.partner_id.with_company(move.company_id).invoice_sending_method or 'email'
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
            //     'sending_methods': get_setting('sending_methods', default_value={self._get_default_sending_method(move)}) or {},
            //     'extra_edis': get_setting('extra_edis', default_value=self._get_default_extra_edis(move)) or {},
            //     'pdf_report': get_setting('pdf_report') or self._get_default_pdf_report_id(move),
            //     'author_user_id': get_setting('author_user_id', from_cron=from_cron) or self.env.user.id,
            //     'author_partner_id': get_setting('author_partner_id', from_cron=from_cron) or self.env.user.partner_id.id,
            // }
            // vals['invoice_edi_format'] = get_setting('invoice_edi_format', default_value=self._get_default_invoice_edi_format(move, sending_methods=vals['sending_methods']))
            // if 'email' in vals['sending_methods']:
            //     mail_template = get_setting('mail_template') or self._get_default_mail_template_id(move)
            //     mail_lang = get_setting('mail_lang') or self._get_default_mail_lang(move, mail_template)
            //     mail_attachments_widget = self._get_default_mail_attachments_widget(
            //         move,
            //         mail_template,
            //         invoice_edi_format=vals['invoice_edi_format'],
            //         extra_edis=vals['extra_edis'],
            //         pdf_report=vals['pdf_report'],
            //     )
            //     vals.update({
            //         'mail_template': mail_template,
            //         'mail_lang': mail_lang,
            //         'mail_body': get_setting('mail_body', default_value=self._get_default_mail_body(move, mail_template, mail_lang)),
            //         'mail_subject': get_setting('mail_subject', default_value=self._get_default_mail_subject(move, mail_template, mail_lang)),
            //         'mail_partner_ids': get_setting('mail_partner_ids', default_value=self._get_default_mail_partner_ids(move, mail_template, mail_lang).ids),
            //         'mail_attachments_widget': get_setting('mail_attachments_widget', default_value=mail_attachments_widget),
            //     })
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
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_facturae, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, move):
            // # EXTENDS 'account'
            // return super()._get_invoice_extra_attachments(move) + move.l10n_es_edi_facturae_xml_id
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_tbai, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, move):
            // # EXTENDS 'account'
            // return super()._get_invoice_extra_attachments(move) + move.l10n_es_tbai_post_document_id.xml_attachment_id
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, invoice):
            // # EXTENDS 'account'
            // return super()._get_invoice_extra_attachments(invoice) + invoice.l10n_it_edi_attachment_id
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, move):
            // # EXTENDS 'account'
            // return super()._get_invoice_extra_attachments(move) + move.l10n_jo_edi_xml_attachment_id
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, move):
            // """ We are required to either:
            //     - Attach a QR code to the invoice PDF, that points to the e-invoice on the MyInvois platform
            //     - Attach the XML file we generated
            // We will use to later for simplicity. It is unclear if the shared xml should be digitally signed or not.
            // """
            // # EXTENDS 'account'
            // return (
            //     super()._get_invoice_extra_attachments(move)
            //     + move.l10n_my_edi_file_id
            // )
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, invoice):
            // # EXTENDS 'account'
            // return super()._get_invoice_extra_attachments(invoice) + invoice.l10n_rs_edi_attachment_id
            --- ODOO METHOD SOURCE (MODULE: l10n_vn_edi_viettel, FILE: account_move_send.py) ---
            // def _get_invoice_extra_attachments(self, move):
            // # EXTENDS 'account'
            // # we require these to be downloadable for a better UX. It was also said that the xml and pdf files are
            // # important files that needs to be shared with the customer.
            // return (
            //     super()._get_invoice_extra_attachments(move)
            //     + move.l10n_vn_edi_sinvoice_xml_file_id
            //     + move.l10n_vn_edi_sinvoice_pdf_file_id
            // )
            */
            return default;
        }

        public async Task<TEntity> GetL10nKeEdiTremolWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object warning_moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ke_edi_tremol, FILE: account_move_send.py) ---
            // def _get_l10n_ke_edi_tremol_warning_message(self, warning_moves):
            // return '\n'.join([
            //     _("The following documents have no details related to the fiscal device."),
            //     *(warning_moves.mapped('name'))
            // ])
            */
            return default;
        }

        public async Task<TEntity> GetL10nKeEdiTremolWarningMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ke_edi_tremol, FILE: account_move_send.py) ---
            // def _get_l10n_ke_edi_tremol_warning_moves(self, moves):
            // return moves.filtered(lambda m: m.country_code == 'KE' and not m._l10n_ke_fiscal_device_details_filled())
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
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_sii, FILE: account_move_send.py) ---
            // def _get_mail_attachment_from_doc(self, doc):
            // if doc.name == 'jsondump.json' and doc.edi_format_id.code == 'es_sii':
            //     return self.env['ir.attachment']
            // return super()._get_mail_attachment_from_doc(doc)
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
            // return mail_template\
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
            // # EXTENDS 'account'
            // # TODO remove the fallback in master
            // if self.env.ref('account_peppol.mail_notification_layout_with_responsible_signature_and_peppol',
            //                 raise_if_not_found=False):
            //     return 'account_peppol.mail_notification_layout_with_responsible_signature_and_peppol'
            // return super()._get_mail_layout()
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

        public async Task<TEntity> GetPlaceholderMailAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object invoice_edi_format, object extra_edis) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _get_placeholder_mail_attachments_data(self, move, invoice_edi_format=None, extra_edis=None):
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
            // 
            // filename = move._get_invoice_report_filename()
            // return [{
            //     'id': f'placeholder_{filename}',
            //     'name': filename,
            //     'mimetype': 'application/pdf',
            //     'placeholder': True,
            // }]
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _get_placeholder_mail_attachments_data(self, move, invoice_edi_format=None, extra_edis=None):
            // # EXTENDS 'account'
            // results = super()._get_placeholder_mail_attachments_data(move, invoice_edi_format=invoice_edi_format, extra_edis=extra_edis)
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
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_facturae, FILE: account_move_send.py) ---
            // def _get_placeholder_mail_attachments_data(self, move, invoice_edi_format=None, extra_edis=None):
            // # EXTENDS 'account'
            // results = super()._get_placeholder_mail_attachments_data(move, invoice_edi_format=invoice_edi_format, extra_edis=extra_edis)
            // 
            // if invoice_edi_format == 'es_facturae' and move._l10n_es_edi_facturae_get_default_enable():
            //     filename = f'{move.name.replace("/", "_")}_facturae_signed.xml'
            //     results.append({
            //         'id': f'placeholder_{filename}',
            //         'name': filename,
            //         'mimetype': 'application/xml',
            //         'placeholder': True,
            //     })
            // 
            // return results
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_tbai, FILE: account_move_send.py) ---
            // def _get_placeholder_mail_attachments_data(self, move, invoice_edi_format=None, extra_edis=None):
            // # EXTENDS 'account'
            // results = super()._get_placeholder_mail_attachments_data(move, invoice_edi_format=invoice_edi_format, extra_edis=extra_edis)
            // 
            // if (
            //     not move.l10n_es_tbai_post_document_id.xml_attachment_id
            //     and 'es_tbai' in extra_edis
            // ):
            //     filename = move._l10n_es_tbai_get_attachment_name()
            //     results.append({
            //         'id': f'placeholder_{filename}',
            //         'name': filename,
            //         'mimetype': 'application/xml',
            //         'placeholder': True,
            //     })
            // 
            // return results
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_move_send.py) ---
            // def _get_placeholder_mail_attachments_data(self, move, invoice_edi_format=None, extra_edis=None):
            // # EXTENDS 'account'
            // res = super()._get_placeholder_mail_attachments_data(move, invoice_edi_format=invoice_edi_format, extra_edis=extra_edis)
            // 
            // if not move.l10n_jo_edi_xml_attachment_id and 'jo_edi' in extra_edis:
            //     attachment_name = move._l10n_jo_edi_get_xml_attachment_name()
            //     res.append(
            //         {
            //             "id": f"placeholder_{attachment_name}",
            //             "name": attachment_name,
            //             "mimetype": "application/xml",
            //             "placeholder": True,
            //         }
            //     )
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_vn_edi_viettel, FILE: account_move_send.py) ---
            // def _get_placeholder_mail_attachments_data(self, move, invoice_edi_format=None, extra_edis=None):
            // # EXTENDS 'account'
            // results = super()._get_placeholder_mail_attachments_data(move, invoice_edi_format=invoice_edi_format, extra_edis=extra_edis)
            // if invoice_edi_format == 'vn_sinvoice' and move._l10n_vn_edi_get_credentials_company():
            //     results.extend([{
            //         'id': 'placeholder_sinvoice.pdf',
            //         'name': f'{move.company_id.vat}-{move.l10n_vn_edi_invoice_symbol.name}101.pdf',
            //         'mimetype': 'application/pdf',
            //         'placeholder': True,
            //     }, {
            //         'id': 'placeholder_sinvoice.xml',
            //         'name': f'{move.company_id.vat}-{move.l10n_vn_edi_invoice_symbol.name}101.xml',
            //         'mimetype': 'application/xml',
            //         'placeholder': True,
            //     }])
            // 
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
            // invoice_template = (pdf_report or self._get_default_pdf_report_id(move)) + self.env.ref('account.account_invoices')
            // extra_mail_templates = mail_template.report_template_ids - invoice_template
            // filename = move._get_invoice_report_filename()
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

        public async Task<TEntity> HookIfErrorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data, object allow_raising) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _hook_if_errors(self, moves_data, allow_raising=True):
            // """ Process errors found so far when generating the documents.
            // :param from_cron:   Flag indicating if the method is called from a cron. In that case, we avoid raising any
            //                     error.
            // :param allow_fallback_pdf:  In case of error when generating the documents for invoices, generate a
            //                             proforma PDF report instead.
            // """
            // for move, move_data in moves_data.items():
            //     error = move_data['error']
            //     if allow_raising:
            //         raise UserError(self._format_error_text(error))
            // 
            //     move.with_context(no_document=True, no_new_invoice=True).message_post(body=self._format_error_html(error))
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

        public async Task<TEntity> HookIfSuccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_move_send.py) ---
            // def _hook_if_success(self, moves_data):
            // """ Process (typically send) successful documents."""
            // to_send_mail = {
            //     move: move_data
            //     for move, move_data in moves_data.items()
            //     if 'email' in move_data['sending_methods'] and self._is_applicable_to_move('email', move, **move_data)
            // }
            // self._send_mails(to_send_mail)
            --- ODOO METHOD SOURCE (MODULE: snailmail_account, FILE: account_move_send.py) ---
            // def _hook_if_success(self, moves_data):
            // # EXTENDS 'account'
            // super()._hook_if_success(moves_data)
            // 
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
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: account_move_send.py) ---
            // def _hook_invoice_document_after_pdf_report_render(self, invoice, invoice_data):
            // # EXTENDS 'account'
            // super()._hook_invoice_document_after_pdf_report_render(invoice, invoice_data)
            // if (
            //     invoice_data.get('pdf_attachment_values')
            //     and (
            //         ('it_edi_send' in invoice_data['extra_edis'] and not invoice.l10n_it_edi_attachment_id)
            //         or (invoice_data['invoice_edi_format'] == 'it_edi_xml' and invoice._l10n_it_edi_ready_for_xml_export())
            //     )
            // ):
            //     invoice_data['l10n_it_edi_values'] = invoice._l10n_it_edi_get_attachment_values(
            //         pdf_values=invoice_data['pdf_attachment_values'])
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
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_facturae, FILE: account_move_send.py) ---
            // def _hook_invoice_document_before_pdf_report_render(self, invoice, invoice_data):
            // # EXTENDS 'account'
            // super()._hook_invoice_document_before_pdf_report_render(invoice, invoice_data)
            // 
            // if invoice_data['invoice_edi_format'] == 'es_facturae' and invoice._l10n_es_edi_facturae_get_default_enable():
            //     try:
            //         xml_content, errors = invoice._l10n_es_edi_facturae_render_facturae()
            //         if errors:
            //             invoice_data['error'] = {
            //                 'error_title': _("Errors occurred while creating the EDI document (format: %s):", "Facturae"),
            //                 'errors': errors,
            //             }
            //         else:
            //             invoice_data['l10n_es_edi_facturae_attachment_values'] = {
            //                 'name': invoice._l10n_es_edi_facturae_get_filename(),
            //                 'raw': xml_content,
            //                 'mimetype': 'application/xml',
            //                 'res_model': invoice._name,
            //                 'res_id': invoice.id,
            //                 'res_field': 'l10n_es_edi_facturae_xml_file',  # Binary field
            //             }
            //     except UserError as e:
            //         if self.env.context.get('forced_invoice'):
            //             _logger.warning(
            //                 'An error occured during generation of Facturae EDI of %s: %s',
            //                 invoice.name,
            //                 e.args[0]
            //             )
            //         else:
            //             raise
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: account_move_send.py) ---
            // def _hook_invoice_document_before_pdf_report_render(self, invoice, invoice_data):
            // # EXTENDS 'account'
            // super()._hook_invoice_document_before_pdf_report_render(invoice, invoice_data)
            // if (
            //         ('it_edi_send' in invoice_data['extra_edis'] and not invoice.l10n_it_edi_attachment_id)
            //         or (invoice_data['invoice_edi_format'] == 'it_edi_xml' and invoice._l10n_it_edi_ready_for_xml_export())
            // ):
            //     if errors := invoice._l10n_it_edi_export_data_check():
            //         invoice_data['error'] = {
            //             'error_title': _("Errors occurred while creating the e-invoice file:"),
            //             'errors': [error['message'] for error in errors.values()],
            //         }
            --- ODOO METHOD SOURCE (MODULE: l10n_ke_edi_tremol, FILE: account_move_send.py) ---
            // def _hook_invoice_document_before_pdf_report_render(self, invoice, invoice_data):
            // # EXTENDS account
            // super()._hook_invoice_document_before_pdf_report_render(invoice, invoice_data)
            // if invoice.country_code == 'KE' and not invoice._l10n_ke_fiscal_device_details_filled():
            //     invoice_data['error'] = _(
            //         "This document does not have details related to the fiscal device, a proforma invoice will be used."
            //     )
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_move_send.py) ---
            // def _hook_invoice_document_before_pdf_report_render(self, invoice, invoice_data):
            // # EXTENDS 'account'
            // super()._hook_invoice_document_before_pdf_report_render(invoice, invoice_data)
            // self._l10n_my_edi_generate_myinvois_xml(invoice, invoice_data)
            --- ODOO METHOD SOURCE (MODULE: l10n_vn_edi_viettel, FILE: account_move_send.py) ---
            // def _hook_invoice_document_before_pdf_report_render(self, invoice, invoice_data):
            // # EXTENDS 'account'
            // super()._hook_invoice_document_before_pdf_report_render(invoice, invoice_data)
            // self._generate_sinvoice_file_date(invoice, invoice_data)
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
            //     return all([
            //         self._is_applicable_to_company(method, move.company_id),
            //         self.env['res.partner']._get_peppol_verification_state(partner.peppol_endpoint, partner.peppol_eas, invoice_edi_format) == 'valid',
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

        public async Task<TEntity> IsGrEdiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_gr_edi, FILE: account_move_send.py) ---
            // def _is_gr_edi_applicable(self, move):
            // return move.l10n_gr_edi_enable_send_invoices
            */
            return default;
        }

        public async Task<TEntity> IsHuEdiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hu_edi, FILE: account_move_send.py) ---
            // def _is_hu_edi_applicable(self, move):
            // return 'upload' in move._origin._l10n_hu_edi_get_valid_actions()
            */
            return default;
        }

        public async Task<TEntity> IsItEdiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: account_move_send.py) ---
            // def _is_it_edi_applicable(self, move):
            // return all([
            //     move.company_id.account_fiscal_country_id.code == 'IT'
            //     and move._l10n_it_edi_ready_for_xml_export()
            //     and move.l10n_it_edi_state != 'rejected'
            // ])
            */
            return default;
        }

        public async Task<TEntity> IsMyEdiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_move_send.py) ---
            // def _is_my_edi_applicable(self, move):
            // return (move.is_invoice()
            //         and move.state == 'posted'
            //         and move.country_code == 'MY'
            //         and not move.l10n_my_edi_state
            //         and move.company_id.l10n_my_edi_proxy_user_id)
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: account_move_send.py) ---
            // def _is_my_edi_applicable(self, move):
            // """ Override to disable the usage of MyInvois in the Send & Print wizard.
            // It is not fully compatible with the QR flow and thus, we intend to send the file to MyInvois separately.
            // """
            // is_applicable = super()._is_my_edi_applicable(move)
            // disabled = str2bool(self.env['ir.config_parameter'].sudo().get_param('l10n_my_edi.disable.send_and_print.first', 'True'))
            // return is_applicable and not disabled
            */
            return default;
        }

        public async Task<TEntity> IsRoEdiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_ro_edi, FILE: account_move_send.py) ---
            // def _is_ro_edi_applicable(self, move):
            // return all([
            //     move._need_ubl_cii_xml('ciusro') or move.ubl_cii_xml_id,
            //     move.country_code == 'RO',
            //     not move.l10n_ro_edi_state,
            // ])
            */
            return default;
        }

        public async Task<TEntity> IsRsEdiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_move_send.py) ---
            // def _is_rs_edi_applicable(self, move):
            // return move.l10n_rs_edi_is_eligible
            */
            return default;
        }

        public async Task<TEntity> IsSaEdiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_move_send.py) ---
            // def _is_sa_edi_applicable(self, move):
            // zatca_document = move.edi_document_ids.filtered(lambda d: d.edi_format_id.code == 'sa_zatca' and d.state == 'to_send')
            // return move.country_code == 'SA' and move.move_type in ('out_invoice', 'out_refund') and zatca_document and move.state != 'draft'
            */
            return default;
        }

        public async Task<TEntity> IsTbaiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_tbai, FILE: account_move_send.py) ---
            // def _is_tbai_applicable(self, move):
            // return move.l10n_es_tbai_is_required and move.l10n_es_tbai_state == 'to_send'
            */
            return default;
        }

        public async Task<TEntity> IsTrNilveraApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_move_send.py) ---
            // def _is_tr_nilvera_applicable(self, move):
            // return move.l10n_tr_nilvera_send_status == 'not_sent' and move.is_invoice(include_receipts=True) and move.country_code == 'TR'
            */
            return default;
        }

        public async Task<TEntity> IsVnEdiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_vn_edi_viettel, FILE: account_move_send.py) ---
            // def _is_vn_edi_applicable(self, move):
            // return bool(move.l10n_vn_edi_invoice_state == 'ready_to_send' and move._l10n_vn_edi_get_credentials_company())
            */
            return default;
        }

        public async Task<TEntity> L10nHuEdiCronUpdateStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_hu_edi, FILE: account_move_send.py) ---
            // def _l10n_hu_edi_cron_update_status(self):
            // final_states = [False, 'confirmed', 'confirmed_warning', 'rejected', 'cancel_pending', 'cancelled']
            // invoices_pending = self.env['account.move'].search([('l10n_hu_edi_state', 'not in', final_states)])
            // invoices_pending.l10n_hu_edi_button_update_status(from_cron=True)
            // 
            // if any(m.state not in final_states for m in invoices_pending):
            //     # Trigger cron again in 10 minutes.
            //     self.env.ref('l10n_hu_edi.ir_cron_update_status')._trigger(at=fields.Datetime.now() + timedelta(minutes=10))
            */
            return default;
        }

        public async Task<TEntity> L10nJoIsEdiApplicableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_move_send.py) ---
            // def _l10n_jo_is_edi_applicable(self, move):
            // return move.l10n_jo_edi_is_needed and move.l10n_jo_edi_state not in move._l10n_jo_edi_state_sent_options()
            */
            return default;
        }

        public async Task<TEntity> L10nMyEdiGenerateMyinvoisXmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_move_send.py) ---
            // def _l10n_my_edi_generate_myinvois_xml(self, invoice, invoice_data):
            // need_file = (
            //     (invoice_data['invoice_edi_format'] == 'my_myinvois' and invoice.company_id.l10n_my_edi_proxy_user_id)
            //     or 'my_myinvois_send' in invoice_data['extra_edis']
            // )
            // # It should always be generated when sending.
            // if need_file:
            //     # We don't pre-check the configuration, the ubl export will handle that part.
            //     xml_content, errors = invoice._l10n_my_edi_generate_invoice_xml()
            //     if errors:
            //         invoice_data['error'] = {
            //             'error_title': _('Error when generating MyInvois file:'),
            //             'errors': errors,
            //         }
            //     else:
            //         invoice_data['myinvois_attachments'] = [{
            //             'name': f'{invoice.name.replace("/", "_")}_myinvois.xml',
            //             'raw': xml_content,
            //             'mimetype': 'application/xml',
            //             'res_model': invoice._name,
            //             'res_id': invoice.id,
            //             'res_field': 'l10n_my_edi_file',  # Binary field
            //         }]
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
            --- ODOO METHOD SOURCE (MODULE: l10n_es_edi_facturae, FILE: account_move_send.py) ---
            // def _link_invoice_documents(self, invoices_data):
            // # EXTENDS 'account'
            // super()._link_invoice_documents(invoices_data)
            // 
            // attachments_vals = [
            //     invoice_data.get('l10n_es_edi_facturae_attachment_values')
            //     for invoice_data in invoices_data.values()
            //     if invoice_data.get('l10n_es_edi_facturae_attachment_values')
            // ]
            // if attachments_vals:
            //     attachments = self.env['ir.attachment'].with_user(SUPERUSER_ID).create(attachments_vals)
            //     res_ids = attachments.mapped('res_id')
            //     self.env['account.move'].browse(res_ids).invalidate_recordset(fnames=['l10n_es_edi_facturae_xml_id', 'l10n_es_edi_facturae_xml_file'])
            --- ODOO METHOD SOURCE (MODULE: l10n_it_edi, FILE: account_move_send.py) ---
            // def _link_invoice_documents(self, invoices_data):
            // # EXTENDS 'account'
            // super()._link_invoice_documents(invoices_data)
            // 
            // attachments_vals = [
            //     invoice_data.get('l10n_it_edi_values')
            //     for invoice_data in invoices_data.values()
            //     if invoice_data.get('l10n_it_edi_values')
            // ]
            // if attachments_vals:
            //     attachments = self.env['ir.attachment'].sudo().create(attachments_vals)
            //     res_ids = attachments.mapped('res_id')
            //     self.env['account.move'].browse(res_ids).invalidate_recordset(fnames=['l10n_it_edi_attachment_id', 'l10n_it_edi_attachment_file'])
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_move_send.py) ---
            // def _link_invoice_documents(self, invoices_data):
            // # EXTENDS 'account'
            // super()._link_invoice_documents(invoices_data)
            // 
            // attachments_vals = []
            // for invoice_data in invoices_data.values():
            //     attachments_vals.extend(invoice_data.get('myinvois_attachments', []))
            // 
            // if attachments_vals:
            //     attachments = self.env['ir.attachment'].sudo().create(invoice_data.get('myinvois_attachments'))
            //     res_ids = attachments.mapped('res_id')
            //     self.env['account.move'].browse(res_ids).invalidate_recordset(fnames=['l10n_my_edi_file_id', 'l10n_my_edi_file'])
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_move_send.py) ---
            // def _link_invoice_documents(self, invoices_data):
            // # EXTENDS 'account'
            // super()._link_invoice_documents(invoices_data)
            // attachments_vals = [
            //     invoice_data.get('l10n_rs_edi_attachment_values')
            //     for invoice_data in invoices_data.values()
            //     if invoice_data.get('l10n_rs_edi_attachment_values')
            // ]
            // if attachments_vals:
            //     attachments = self.env['ir.attachment'].with_user(SUPERUSER_ID).create(attachments_vals)
            //     res_ids = [attachment.res_id for attachment in attachments]
            //     self.env['account.move'].browse(res_ids).invalidate_recordset(fnames=['l10n_rs_edi_attachment_id', 'l10n_rs_edi_attachment_file'])
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_move_send.py) ---
            // def _link_invoice_documents(self, invoices_data):
            // # EXTENDS 'account'
            // super()._link_invoice_documents(invoices_data)
            // # The move needs to be put as sent only if sent by Nilvera
            // for invoice, invoice_data in invoices_data.items():
            //     if invoice.company_id.country_code == 'TR':
            //         invoice.is_move_sent = invoice.l10n_tr_nilvera_send_status == 'sent'
            */
            return default;
        }

        public async Task<TEntity> PostprocessInvoiceUblXmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py) ---
            // def _postprocess_invoice_ubl_xml(self, invoice, invoice_data):
            // # Adding the PDF to the XML
            // tree = etree.fromstring(invoice_data['ubl_cii_xml_attachment_values']['raw'])
            // anchor_elements = tree.xpath("//*[local-name()='AccountingSupplierParty']")
            // if not anchor_elements:
            //     return
            // 
            // xmlns_move_type = 'Invoice' if invoice.move_type == 'out_invoice' else 'CreditNote'
            // pdf_values = invoice.invoice_pdf_report_id or invoice_data.get('pdf_attachment_values') or invoice_data['proforma_pdf_attachment_values']
            // filename = pdf_values['name']
            // content = pdf_values['raw']
            // 
            // doc_type_node = ""
            // edi_model = invoice_data["ubl_cii_xml_options"]["builder"]
            // doc_type_code_vals = edi_model._get_document_type_code_vals(invoice, invoice_data)
            // if doc_type_code_vals['value']:
            //     doc_type_code_attrs = " ".join(f'{name}="{value}"' for name, value in doc_type_code_vals['attrs'].items())
            //     doc_type_node = f"<cbc:DocumentTypeCode {doc_type_code_attrs}>{doc_type_code_vals['value']}</cbc:DocumentTypeCode>"
            // to_inject = f'''
            //     <cac:AdditionalDocumentReference
            //         xmlns="urn:oasis:names:specification:ubl:schema:xsd:{xmlns_move_type}-2"
            //         xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
            //         xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2">
            //         <cbc:ID>{escape(filename)}</cbc:ID>
            //         {doc_type_node}
            //         <cac:Attachment>
            //             <cbc:EmbeddedDocumentBinaryObject
            //                 mimeCode="application/pdf"
            //                 filename={quoteattr(filename)}>
            //                 {base64.b64encode(content).decode()}
            //             </cbc:EmbeddedDocumentBinaryObject>
            //         </cac:Attachment>
            //     </cac:AdditionalDocumentReference>
            // '''
            // 
            // anchor_index = tree.index(anchor_elements[0])
            // tree.insert(anchor_index, etree.fromstring(to_inject))
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
            //             'name': invoice._get_invoice_report_filename(),
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
            // partner_ids = kwargs.get('partner_ids', [])
            // author_id = kwargs.pop('author_id')
            // 
            // new_message = move\
            //     .with_context(
            //         no_document=True,
            //         no_new_invoice=True,
            //         mail_notify_author=author_id in partner_ids,
            //         email_notification_allow_footer=True,
            //     ).message_post(
            //         message_type='comment',
            //         **kwargs,
            //         **{  # noqa: PIE804
            //             'email_layout_xmlid': self._get_mail_layout(),
            //             'email_add_signature': not mail_template,
            //             'mail_auto_delete': mail_template.auto_delete,
            //             'mail_server_id': mail_template.mail_server_id.id,
            //             'reply_to_force_new': False,
            //         }
            //     )
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
            //     email_from = self._get_mail_default_field_value_from_template(mail_template, mail_lang, move, 'email_from')
            //     model_description = move.with_context(lang=mail_lang).type_name
            // 
            //     self._send_mail(
            //         move,
            //         mail_template,
            //         subtype_id=subtype.id,
            //         model_description=model_description,
            //         email_from=email_from,
            //         **mail_params,
            //     )
            */
            return default;
        }

        public async Task<TEntity> WhatIsPeppolActivateAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py) ---
            // def action_what_is_peppol_activate(self, moves):
            // companies = moves.company_id
            // can_send = self.env['account_edi_proxy_client.user']._get_can_send_domain()
            // if len(companies) == 1 and companies.account_peppol_proxy_state not in can_send:
            //     action = self.env['peppol.registration']._action_open_peppol_form()
            //     action['context'].update({
            //         'active_model': 'account.move',
            //         'active_ids': moves.ids,
            //         'dialog_size': 'medium',
            //     })
            //     return action
            // else:
            //     return moves.action_send_and_print()
            */
            return default;
        }
    }
}