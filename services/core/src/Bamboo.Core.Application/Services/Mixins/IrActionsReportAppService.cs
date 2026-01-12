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
    [Module("base", Category = "Base")]
    public class IrActionsReportAppService : ApplicationService, IIrActionsReportAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrActionsReportAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionConfigureExternalReportLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_action, Guid xml_id) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _action_configure_external_report_layout(self, report_action, xml_id="web.action_base_document_layout_configurator"):
            // action = self.env["ir.actions.actions"]._for_xml_id(xml_id)
            // py_ctx = json.loads(action.get('context', {}))
            // report_action['close_on_report_download'] = True
            // py_ctx['report_action'] = report_action
            // action['context'] = py_ctx
            // return action
            */
            return default;
        }

        public async Task<TEntity> AddPagesToWriterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object writer, object document, object prefix) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py) ---
            // def _add_pages_to_writer(self, writer, document, prefix=None):
            // """Add a PDF doc to the writer and fill the form text fields present in the pages if needed.
            // 
            // :param PdfFileWriter writer: the writer to which pages needs to be added
            // :param bytes document: the document to add in the final pdf
            // :param str prefix: the prefix needed to update existing form field name, if any, to be able
            //                    to add the correct values in fields with the same name but on different
            //                    documents, either customizable fields or dynamic fields of different sale
            //                    order lines. (optional)
            // :return: None
            // """
            // reader = PdfFileReader(io.BytesIO(document), strict=False)
            // 
            // field_names = set()
            // if prefix:
            //     field_names = reader.getFormTextFields()
            // 
            // for page_id in range(reader.getNumPages()):
            //     page = reader.getPage(page_id)
            //     if prefix and page.get('/Annots'):
            //         # Modifying the annots that hold every information about the form fields
            //         for j in range(len(page['/Annots'])):
            //             reader_annot = page['/Annots'][j].getObject()
            //             if reader_annot.get('/T') in field_names:
            //                 # Prefix all form fields in the document with the document identifier.
            //                 # This is necessary to know which value needs to be taken when filling the forms.
            //                 form_key = reader_annot.get('/T')
            //                 new_key = prefix + form_key
            // 
            //                 # Modifying the form flags to force some characteristics
            //                 # 1. make all text fields read-only
            //                 # 2. make all text fields support multiline
            //                 form_flags = reader_annot.get('/Ff', 0)
            //                 readonly_flag = 1  # 1st bit sets readonly
            //                 multiline_flag = 1 << 12  # 13th bit sets multiline text
            //                 new_flags = form_flags | readonly_flag | multiline_flag
            // 
            //                 reader_annot.update({
            //                     NameObject("/T"): createStringObject(new_key),
            //                     NameObject("/Ff"): NumberObject(new_flags),
            //                 })
            //     writer.addPage(page)
            */
            return default;
        }

        public async Task<TEntity> AssociatedViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def associated_view(self):
            // """Used in the ir.actions.report form view in order to search naively after the view(s)
            // used in the rendering.
            // """
            // self.ensure_one()
            // action_ref = self.env.ref('base.action_ui_view')
            // if not action_ref or len(self.report_name.split('.')) < 2:
            //     return False
            // action_data = action_ref.read()[0]
            // action_data['domain'] = [('name', 'ilike', self.report_name.split('.')[1]), ('type', '=', 'qweb')]
            // return action_data
            */
            return default;
        }

        public async Task<TEntity> BarcodeAsync<TEntity>(IEnumerable<TEntity> entities, object barcode_type, object @value) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def barcode(self, barcode_type, value, **kwargs):
            // defaults = {
            //     'width': (600, int),
            //     'height': (100, int),
            //     'humanreadable': (False, lambda x: bool(int(x))),
            //     'quiet': (True, lambda x: bool(int(x))),
            //     'mask': (None, lambda x: x),
            //     'barBorder': (4, int),
            //     # The QR code can have different layouts depending on the Error Correction Level
            //     # See: https://en.wikipedia.org/wiki/QR_code#Error_correction
            //     # Level 'L' – up to 7% damage   (default)
            //     # Level 'M' – up to 15% damage  (i.e. required by l10n_ch QR bill)
            //     # Level 'Q' – up to 25% damage
            //     # Level 'H' – up to 30% damage
            //     'barLevel': ('L', lambda x: x in ('L', 'M', 'Q', 'H') and x or 'L'),
            // }
            // kwargs = {k: validator(kwargs.get(k, v)) for k, (v, validator) in defaults.items()}
            // kwargs['humanReadable'] = kwargs.pop('humanreadable')
            // if kwargs['humanReadable']:
            //     kwargs['fontName'] = get_barcode_font()
            // 
            // if kwargs['width'] * kwargs['height'] > 1200000 or max(kwargs['width'], kwargs['height']) > 10000:
            //     raise ValueError("Barcode too large")
            // 
            // if barcode_type == 'UPCA' and len(value) in (11, 12, 13):
            //     barcode_type = 'EAN13'
            //     if len(value) in (11, 12):
            //         value = '0%s' % value
            // elif barcode_type == 'auto':
            //     symbology_guess = {8: 'EAN8', 13: 'EAN13'}
            //     barcode_type = symbology_guess.get(len(value), 'Code128')
            // elif barcode_type == 'QR':
            //     # for `QR` type, `quiet` is not supported. And is simply ignored.
            //     # But we can use `barBorder` to get a similar behaviour.
            //     # quiet=True & barBorder=4 by default cf above, remove border only if quiet=False
            //     if not kwargs['quiet']:
            //         kwargs['barBorder'] = 0
            // 
            // if barcode_type in ('EAN8', 'EAN13') and not check_barcode_encoding(value, barcode_type):
            //     # If the barcode does not respect the encoding specifications, convert its type into Code128.
            //     # Otherwise, the report-lab method may return a barcode different from its value. For instance,
            //     # if the barcode type is EAN-8 and the value 11111111, the report-lab method will take the first
            //     # seven digits and will compute the check digit, which gives: 11111115 -> the barcode does not
            //     # match the expected value.
            //     barcode_type = 'Code128'
            // 
            // try:
            //     barcode = createBarcodeDrawing(barcode_type, value=value, format='png', **kwargs)
            // 
            //     # If a mask is asked and it is available, call its function to
            //     # post-process the generated QR-code image
            //     if kwargs['mask']:
            //         available_masks = self.get_available_barcode_masks()
            //         mask_to_apply = available_masks.get(kwargs['mask'])
            //         if mask_to_apply:
            //             mask_to_apply(kwargs['width'], kwargs['height'], barcode)
            // 
            //     return barcode.asString('png')
            // except (ValueError, AttributeError):
            //     if barcode_type == 'Code128':
            //         raise ValueError("Cannot convert into barcode.")
            //     elif barcode_type == 'QR':
            //         raise ValueError("Cannot convert into QR code.")
            //     else:
            //         return self.barcode('Code128', value, **kwargs)
            */
            return default;
        }

        public async Task<TEntity> BuildWkhtmltopdfArgsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid paperformat_id, object landscape, object specific_paperformat_args, object set_viewport_size) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _build_wkhtmltopdf_args(
            //     self,
            //     paperformat_id,
            //     landscape,
            //     specific_paperformat_args=None,
            //     set_viewport_size=False):
            // '''Build arguments understandable by wkhtmltopdf bin.
            // 
            // :param paperformat_id: A report.paperformat record.
            // :param landscape: Force the report orientation to be landscape.
            // :param specific_paperformat_args: A dictionary containing prioritized wkhtmltopdf arguments.
            // :param set_viewport_size: Enable a viewport sized '1024x1280' or '1280x1024' depending of landscape arg.
            // :return: A list of string representing the wkhtmltopdf process command args.
            // '''
            // if landscape is None and specific_paperformat_args and specific_paperformat_args.get('data-report-landscape'):
            //     landscape = specific_paperformat_args.get('data-report-landscape')
            // 
            // command_args = ['--disable-local-file-access']
            // if set_viewport_size:
            //     command_args.extend(['--viewport-size', landscape and '1024x1280' or '1280x1024'])
            // 
            // # Less verbose error messages
            // command_args.extend(['--quiet'])
            // 
            // # Build paperformat args
            // if paperformat_id:
            //     if paperformat_id.format and paperformat_id.format != 'custom':
            //         command_args.extend(['--page-size', paperformat_id.format])
            // 
            //     if paperformat_id.page_height and paperformat_id.page_width and paperformat_id.format == 'custom':
            //         command_args.extend(['--page-width', str(paperformat_id.page_width) + 'mm'])
            //         command_args.extend(['--page-height', str(paperformat_id.page_height) + 'mm'])
            // 
            //     if specific_paperformat_args and 'data-report-margin-top' in specific_paperformat_args:
            //         command_args.extend(['--margin-top', str(specific_paperformat_args['data-report-margin-top'])])
            //     else:
            //         command_args.extend(['--margin-top', str(paperformat_id.margin_top)])
            // 
            //     dpi = None
            //     if specific_paperformat_args and specific_paperformat_args.get('data-report-dpi'):
            //         dpi = int(specific_paperformat_args['data-report-dpi'])
            //     elif paperformat_id.dpi:
            //         if os.name == 'nt' and int(paperformat_id.dpi) <= 95:
            //             _logger.info("Generating PDF on Windows platform require DPI >= 96. Using 96 instead.")
            //             dpi = 96
            //         else:
            //             dpi = paperformat_id.dpi
            //     if dpi:
            //         command_args.extend(['--dpi', str(dpi)])
            //         if _wkhtml().dpi_zoom_ratio:
            //             command_args.extend(['--zoom', str(96.0 / dpi)])
            // 
            //     if specific_paperformat_args and 'data-report-header-spacing' in specific_paperformat_args:
            //         command_args.extend(['--header-spacing', str(specific_paperformat_args['data-report-header-spacing'])])
            //     elif paperformat_id.header_spacing:
            //         command_args.extend(['--header-spacing', str(paperformat_id.header_spacing)])
            // 
            //     command_args.extend(['--margin-left', str(paperformat_id.margin_left)])
            // 
            //     if specific_paperformat_args and 'data-report-margin-bottom' in specific_paperformat_args:
            //         command_args.extend(['--margin-bottom', str(specific_paperformat_args['data-report-margin-bottom'])])
            //     else:
            //         command_args.extend(['--margin-bottom', str(paperformat_id.margin_bottom)])
            // 
            //     command_args.extend(['--margin-right', str(paperformat_id.margin_right)])
            //     if not landscape and paperformat_id.orientation:
            //         command_args.extend(['--orientation', str(paperformat_id.orientation)])
            //     if paperformat_id.header_line:
            //         command_args.extend(['--header-line'])
            //     if paperformat_id.disable_shrinking:
            //         command_args.extend(['--disable-smart-shrinking'])
            // 
            // # Add extra time to allow the page to render
            // delay = self.env['ir.config_parameter'].sudo().get_param('report.print_delay', '1000')
            // command_args.extend(['--javascript-delay', delay])
            // 
            // if landscape:
            //     command_args.extend(['--orientation', 'landscape'])
            // 
            // return command_args
            */
            return default;
        }

        public async Task<TEntity> ComputeModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _compute_model_id(self):
            // for action in self:
            //     action.model_id = self.env['ir.model']._get(action.model).id
            */
            return default;
        }

        public async Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def create_action(self):
            // """ Create a contextual action for each report. """
            // for report in self:
            //     model = self.env['ir.model']._get(report.model)
            //     report.write({'binding_model_id': model.id, 'binding_type': 'report'})
            // return True
            */
            return default;
        }

        public async Task<TEntity> GetAvailableBarcodeMasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_available_barcode_masks(self):
            // """ Hook for extension.
            // 
            // This function returns the available QR-code masks, in the form of a
            // list of (code, mask_function) elements, where code is a string identifying
            // the mask uniquely, and mask_function is a function returning a reportlab
            // Drawing object with the result of the mask, and taking as parameters:
            // 
            //     - width of the QR-code, in pixels
            //     - height of the QR-code, in pixels
            //     - reportlab Drawing object containing the barcode to apply the mask on
            // """
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetCustomValueFromOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document, object form_field_name, object order, object order_line) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py) ---
            // def _get_custom_value_from_order(self, document, form_field_name, order, order_line):
            // """ Get the custom value of a form field directly from the order.
            // 
            // :param recordset document: the document that needs to be added to the writer and get its
            //                            form fields mapped. Either a quotation.document or a
            //                            product.document.
            // :param str form_field_name: the name of the form field as present in the PDF.
            // :param recordset order: the sale order from where to take the existing mapping.
            // :param recordset order_line: the sale order line linked to the document (optional)
            // :return: value that need to be shown in the final pdf.
            // :rtype: str
            // """
            // existing_mapping = json.loads(order.customizable_pdf_form_fields or '{}')
            // if order_line:
            //     base_values = existing_mapping.get('line', {}).get(str(order_line.id), {})
            // elif document.document_type == 'header':
            //     base_values = existing_mapping.get('header', {})
            // else:
            //     base_values = existing_mapping.get('footer', {})
            // custom_form_fields = base_values.get(str(document.id), {}).get('custom_form_fields', {})
            // return custom_form_fields.get(form_field_name, "")
            */
            return default;
        }

        public async Task<TEntity> GetLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_layout(self):
            // return self.env.ref('web.minimal_layout', raise_if_not_found=False)
            */
            return default;
        }

        public async Task<TEntity> GetPaperformatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: ir_actions_report.py) ---
            // def get_paperformat(self):
            // # force the right format (euro/A4) when sending letters, only if we are not using the l10n_DE layout
            // res = super().get_paperformat()
            // if self.env.context.get('snailmail_layout') and res != self.env.ref('l10n_de.paperformat_euro_din', False):
            //     paperformat_id = self.env.ref('base.paperformat_euro')
            //     return paperformat_id
            // else:
            //     return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_paperformat(self):
            // return self.paperformat_id or self.env.company.paperformat_id
            */
            return default;
        }

        public async Task<TEntity> GetPaperformatByXmlidAsync<TEntity>(IEnumerable<TEntity> entities, Guid xml_id) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_paperformat_by_xmlid(self, xml_id):
            // return self.env.ref(xml_id).get_paperformat() if xml_id else self.env.company.paperformat_id
            */
            return default;
        }

        public async Task<TEntity> GetReadableFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_readable_fields(self):
            // return super()._get_readable_fields() | {
            //     "report_name", "report_type", "target",
            //     # these two are not real fields of ir.actions.report but are
            //     # expected in the route /report/<converter>/<reportname> and must
            //     # not be removed by clean_action
            //     "context", "data",
            //     # and this one is used by the frontend later on.
            //     "close_on_report_download",
            //     "domain",
            // }
            */
            return default;
        }

        public async Task<TEntity> GetRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py) ---
            // def _get_rendering_context(self, report, docids, data):
            // data = super()._get_rendering_context(report, docids, data)
            // if self.env.context.get('proforma_invoice'):
            //     data['proforma'] = True
            // return data
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: ir_actions_report.py) ---
            // def _get_rendering_context(self, report, docids, data):
            // data = super()._get_rendering_context(report, docids, data)
            // if report.report_name == 'stock.report_reception_report_label' and not docids:
            //     docids = data['docids']
            //     docs = self.env[report.model].browse(docids)
            //     data.update({
            //         'doc_ids': docids,
            //         'docs': docs,
            //     })
            // return data
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_rendering_context(self, report, docids, data):
            // # If the report is using a custom model to render its html, we must use it.
            // # Otherwise, fallback on the generic html rendering.
            // report_model = self._get_rendering_context_model(report)
            // 
            // data = data and dict(data) or {}
            // 
            // if report_model is not None:
            //     data.update(report_model._get_report_values(docids, data=data))
            // else:
            //     docs = self.env[report.model].browse(docids)
            //     data.update({
            //         'doc_ids': docids,
            //         'doc_model': report.model,
            //         'docs': docs,
            //     })
            // data['is_html_empty'] = is_html_empty
            // return data
            */
            return default;
        }

        public async Task<TEntity> GetRenderingContextModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_rendering_context_model(self, report):
            // report_model_name = 'report.%s' % report.report_name
            // return self.env.get(report_model_name)
            */
            return default;
        }

        public async Task<TEntity> GetReportFromNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_name) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_report_from_name(self, report_name):
            // """Get the first record of ir.actions.report having the ``report_name`` as value for
            // the field report_name.
            // """
            // report_obj = self.env['ir.actions.report']
            // conditions = [('report_name', '=', report_name)]
            // context = self.env['res.users'].context_get()
            // return report_obj.with_context(context).sudo().search(conditions, limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_report(self, report_ref):
            // """Get the report (with sudo) from a reference
            // 
            // :param report_ref: can be one of
            // 
            //     - ir.actions.report id
            //     - ir.actions.report record
            //     - ir.model.data reference to ir.actions.report
            //     - ir.actions.report report_name
            // """
            // ReportSudo = self.env['ir.actions.report'].sudo()
            // if isinstance(report_ref, int):
            //     return ReportSudo.browse(report_ref)
            // if isinstance(report_ref, models.Model):
            //     if report_ref._name != self._name:
            //         raise ValueError("Expected report of type %s, got %s" % (self._name, report_ref._name))
            //     return report_ref.sudo()
            // report = ReportSudo.search([('report_name', '=', report_ref)], limit=1)
            // if report:
            //     return report
            // report = self.env.ref(report_ref)
            // if report:
            //     if report._name != "ir.actions.report":
            //         raise ValueError("Fetching report %r: type %s, expected ir.actions.report" % (report_ref, report._name))
            //     return report.sudo()
            // raise ValueError("Fetching report %r: report not found" % report_ref)
            */
            return default;
        }

        public async Task<TEntity> GetReportUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _get_report_url(self, layout=None):
            // report_url = self.env['ir.config_parameter'].sudo().get_param('report.url')
            // return report_url or (layout or self._get_layout() or self).get_base_url()
            */
            return default;
        }

        public async Task<TEntity> GetSplittedReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object content, object report_type) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py) ---
            // def _get_splitted_report(self, report_ref, content, report_type):
            // if report_type == 'html':
            //     report = self._get_report(report_ref)
            //     bodies, res_ids, *_unused = self._prepare_html(content, report_model=report.model)
            //     return {res_id: str(body).encode() for res_id, body in zip(res_ids, bodies)}
            // elif report_type == 'pdf':
            //     pdf_dict = {res_id: stream['stream'].getvalue() for res_id, stream in content.items()}
            //     for stream in content.values():
            //         stream['stream'].close()
            //     return pdf_dict
            */
            return default;
        }

        public async Task<TEntity> GetValidActionReportsAsync<TEntity>(IEnumerable<TEntity> entities, object model, List<Guid> record_ids) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_valid_action_reports(self, model, record_ids):
            // """ Return the list of ids of actions for which the domain is
            // satisfied by at least one record in record_ids.
            // :param model: the model of the records to validate
            // :param record_ids: list of ids of records to validate
            // """
            // records = self.env[model].browse(record_ids)
            // actions_with_domain = self.filtered('domain')
            // valid_action_report_ids = (self - actions_with_domain).ids  # actions without domain are always valid
            // for action in actions_with_domain:
            //     if records.filtered_domain(literal_eval(action.domain)):
            //         valid_action_report_ids.append(action.id)
            // return valid_action_report_ids
            */
            return default;
        }

        public async Task<TEntity> GetValueFromPathInternalAsync<TEntity>(IEnumerable<TEntity> entities, object form_field, object order, object order_line) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py) ---
            // def _get_value_from_path(self, form_field, order, order_line=None):
            // """ Get the string value by following the path indicated in the record form_field.
            // 
            // :param recordset form_field: sale.pdf.form.field that has a valid path.
            // :param recordset order: sale.order from where the values and timezone need to be taken
            // :param recordset order_line: sale.order.line from where the values need to be taken
            //                              (optional, only for product.document)
            // :return: value that need to be shown in the final pdf. Multiple values are joined by ', '
            // :rtype: str
            // """
            // tz = order.partner_id.tz or order.env.user.tz or 'UTC'
            // base_record = order_line or order
            // path = form_field.path
            // 
            // # If path = 'order_id.order_line.product_id.name'
            // path = path.split('.')  # ['order_id', 'order_line', 'product_id', 'name']
            // # Sudo to be able to follow the path set by the admin
            // records = base_record.sudo().mapped('.'.join(path[:-1]))  # product.product(id1, id2, ...)
            // field_name = path[-1]  # 'name'
            // 
            // def _get_formatted_value(self):
            //     # self must be named so to be considered in the translation logic
            //     field_ = records._fields[field_name]
            //     field_type_ = field_.type
            //     for record_ in records:
            //         value_ = record_[field_name]
            //         if field_type_ == 'boolean':
            //             formatted_value_ = _("Yes") if value_ else _("No")
            //         elif field_type_ == 'monetary':
            //             currency_id_ = record_[field_.get_currency_field(record_)]
            //             formatted_value_ = format_amount(
            //                 self.env, value_, currency_id_ or order.currency_id
            //             )
            //         elif not value_ and field_type_ not in {'integer', 'float'}:
            //             formatted_value_ = ''
            //         elif field_type_ == 'date':
            //             formatted_value_ = format_date(self.env, value_)
            //         elif field_type_ == 'datetime':
            //             formatted_value_ = format_datetime(self.env, value_, tz=tz, dt_format=False)
            //         elif field_type_ == 'selection' and value_:
            //             formatted_value_ = dict(field_._description_selection(self.env))[value_]
            //         elif field_type_ in {'one2many', 'many2one', 'many2many'}:
            //             formatted_value_ = ', '.join([v.display_name for v in value_])
            //         else:
            //             formatted_value_ = str(value_)
            // 
            //         yield formatted_value_
            // 
            // return ', '.join(_get_formatted_value(self))
            */
            return default;
        }

        public async Task<TEntity> GetWkhtmltopdfStateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def get_wkhtmltopdf_state(self):
            // '''Get the current state of wkhtmltopdf: install, ok, upgrade, workers or broken.
            // * install: Starting state.
            // * upgrade: The binary is an older version (< 0.12.0).
            // * ok: A binary was found with a recent version (>= 0.12.0).
            // * workers: Not enough workers found to perform the pdf rendering process (< 2 workers).
            // * broken: A binary was found but not responding.
            // 
            // :return: wkhtmltopdf_state
            // '''
            // return _wkhtml().state
            */
            return default;
        }

        public async Task<TEntity> HandleMergePdfsErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error, object error_stream) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _handle_merge_pdfs_error(self, error=None, error_stream=None):
            // raise UserError(_("Odoo is unable to merge the generated PDFs."))
            */
            return default;
        }

        public async Task<TEntity> IsInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py) ---
            // def _is_invoice_report(self, report_ref):
            // report = self._get_report(report_ref)
            // return (report.is_invoice_report and report.model == 'account.move') or report.report_name == 'account.report_invoice'
            */
            return default;
        }

        public async Task<TEntity> IsPurchaseOrderReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: ir_actions_report.py) ---
            // def _is_purchase_order_report(self, report_ref):
            // return self._get_report(report_ref).report_name in (
            //     'purchase.report_purchasequotation',
            //     'purchase.report_purchaseorder'
            // )
            */
            return default;
        }

        public async Task<TEntity> IsSaleOrderReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: ir_actions_report.py) ---
            // def _is_sale_order_report(self, report_ref):
            // return self._get_report(report_ref).report_name in (
            //     'sale.report_saleorder_document',
            //     'sale.report_saleorder',
            //     'sale.report_saleorder_raw',
            // )
            */
            return default;
        }

        public async Task<TEntity> MergePdfsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object streams, object handle_error) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _merge_pdfs(self, streams, handle_error=_handle_merge_pdfs_error):
            // writer = PdfFileWriter()
            // for stream in streams:
            //     try:
            //         reader = PdfFileReader(stream)
            //         writer.appendPagesFromReader(reader)
            //     except (PdfReadError, TypeError, NotImplementedError, ValueError) as e:
            //         handle_error(error=e, error_stream=stream)
            // result_stream = io.BytesIO()
            // streams.append(result_stream)
            // try:
            //     writer.write(result_stream)
            // except PdfReadError:
            //     raise UserError(_("Odoo is unable to merge the generated PDFs."))
            // return result_stream
            */
            return default;
        }

        public async Task<TEntity> PreRenderQwebPdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py) ---
            // def _pre_render_qweb_pdf(self, report_ref, res_ids=None, data=None):
            // # Check for reports only available for invoices.
            // # + append context data with the display_name_in_footer parameter
            // if self._is_invoice_report(report_ref):
            //     invoices = self.env['account.move'].browse(res_ids)
            //     if self.env['ir.config_parameter'].sudo().get_param('account.display_name_in_footer'):
            //         data = data and dict(data) or {}
            //         data.update({'display_name_in_footer': True})
            //     if any(x.move_type == 'entry' for x in invoices):
            //         raise UserError(_("Only invoices could be printed."))
            // 
            // return super()._pre_render_qweb_pdf(report_ref, res_ids=res_ids, data=data)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _pre_render_qweb_pdf(self, report_ref, res_ids=None, data=None):
            // if not data:
            //     data = {}
            // if isinstance(res_ids, int):
            //     res_ids = [res_ids]
            // data.setdefault('report_type', 'pdf')
            // # In case of test environment without enough workers to perform calls to wkhtmltopdf,
            // # fallback to render_html.
            // if (modules.module.current_test or tools.config['test_enable']) and not self.env.context.get('force_report_rendering'):
            //     return self._render_qweb_html(report_ref, res_ids, data=data)
            // 
            // self = self.with_context(webp_as_jpg=True)
            // return self._render_qweb_pdf_prepare_streams(report_ref, data, res_ids=res_ids), 'pdf'
            */
            return default;
        }

        public async Task<TEntity> PrepareHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object report_model) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _prepare_html(self, html, report_model=False):
            // '''Divide and recreate the header/footer html by merging all found in html.
            // The bodies are extracted and added to a list. Then, extract the specific_paperformat_args.
            // The idea is to put all headers/footers together. Then, we will use a javascript trick
            // (see minimal_layout template) to set the right header/footer during the processing of wkhtmltopdf.
            // This allows the computation of multiple reports in a single call to wkhtmltopdf.
            // '''
            // 
            // # Return empty dictionary if 'web.minimal_layout' not found.
            // layout = self._get_layout()
            // if not layout:
            //     return {}
            // base_url = self._get_report_url(layout=layout)
            // 
            // root = lxml.html.fromstring(html, parser=lxml.html.HTMLParser(encoding='utf-8'))
            // match_klass = "//div[contains(concat(' ', normalize-space(@class), ' '), ' {} ')]"
            // 
            // header_node = etree.Element('div', id='minimal_layout_report_headers')
            // footer_node = etree.Element('div', id='minimal_layout_report_footers')
            // bodies = []
            // res_ids = []
            // 
            // body_parent = root.xpath('//main')[0]
            // # Retrieve headers
            // for node in root.xpath(match_klass.format('header')):
            //     body_parent = node.getparent()
            //     node.getparent().remove(node)
            //     header_node.append(node)
            // 
            // # Retrieve footers
            // for node in root.xpath(match_klass.format('footer')):
            //     body_parent = node.getparent()
            //     node.getparent().remove(node)
            //     footer_node.append(node)
            // 
            // # Retrieve bodies
            // for node in root.xpath(match_klass.format('article')):
            //     # set context language to body language
            //     IrQweb = self.env['ir.qweb']
            //     if node.get('data-oe-lang'):
            //         IrQweb = IrQweb.with_context(lang=node.get('data-oe-lang'))
            //     body = IrQweb._render(layout.id, {
            //             'subst': False,
            //             'body': Markup(lxml.html.tostring(node, encoding='unicode')),
            //             'base_url': base_url,
            //             'report_xml_id': self.xml_id,
            //             'debug': self.env.context.get("debug"),
            //         }, raise_if_not_found=False)
            //     bodies.append(body)
            //     if node.get('data-oe-model') == report_model:
            //         res_ids.append(int(node.get('data-oe-id', 0)))
            //     else:
            //         res_ids.append(None)
            // 
            // if not bodies:
            //     body = ''.join(lxml.html.tostring(c, encoding='unicode') for c in body_parent.getchildren())
            //     bodies.append(body)
            // 
            // # Get paperformat arguments set in the root html tag. They are prioritized over
            // # paperformat-record arguments.
            // specific_paperformat_args = {}
            // for attribute in root.items():
            //     if attribute[0].startswith('data-report-'):
            //         specific_paperformat_args[attribute[0]] = attribute[1]
            // 
            // header = self.env['ir.qweb']._render(layout.id, {
            //     'subst': True,
            //     'body': Markup(lxml.html.tostring(header_node, encoding='unicode')),
            //     'base_url': base_url,
            //     'report_xml_id': self.xml_id,
            //     'debug': self.env.context.get("debug"),
            // })
            // footer = self.env['ir.qweb']._render(layout.id, {
            //     'subst': True,
            //     'body': Markup(lxml.html.tostring(footer_node, encoding='unicode')),
            //     'base_url': base_url,
            //     'report_xml_id': self.xml_id,
            //     'debug': self.env.context.get("debug"),
            // })
            // 
            // return bodies, res_ids, header, footer, specific_paperformat_args
            */
            return default;
        }

        public async Task<TEntity> PrepareLocalAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _prepare_local_attachments(self, attachments):
            // for attachment in attachments:
            //     if attachment._is_remote_source():
            //         try:
            //             attachment._migrate_remote_to_local()
            //         except (ValidationError, requests.exceptions.RequestException) as e:
            //             _logger.error("Failed to migrate attachment %s to local: %s", attachment.id, e)
            // return attachments.filtered(lambda a: not a._is_remote_source())
            */
            return default;
        }

        public async Task<TEntity> PreparePdfReportAttachmentValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report, object streams) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _prepare_pdf_report_attachment_vals_list(self, report, streams):
            // """Hook to prepare attachment values needed for attachments creation
            // during the pdf report generation.
            // 
            // :param report: The report (with sudo) from a reference report_ref.
            // :param streams: Dict of streams for each report containing the pdf content and existing attachments.
            // :return: attachment values list needed for attachments creation.
            // """
            // attachment_vals_list = []
            // for res_id, stream_data in streams.items():
            //     # An attachment already exists.
            //     if stream_data['attachment']:
            //         continue
            // 
            //     # if res_id is false
            //     # we are unable to fetch the record, it won't be saved as we can't split the documents unambiguously
            //     if not res_id or not stream_data['stream']:
            //         _logger.warning(
            //             "These documents were not saved as an attachment because the template of %s doesn't "
            //             "have any headers seperating different instances of it. If you want it saved,"
            //             "please print the documents separately", report.report_name)
            //         continue
            //     record = self.env[report.model].browse(res_id)
            //     attachment_name = safe_eval(report.attachment, {'object': record, 'time': time})
            // 
            //     # Unable to compute a name for the attachment.
            //     if not attachment_name:
            //         continue
            // 
            //     attachment_vals_list.append({
            //         'name': attachment_name,
            //         'raw': stream_data['stream'].getvalue(),
            //         'res_model': report.model,
            //         'res_id': record.id,
            //         'type': 'binary',
            //     })
            // return attachment_vals_list
            */
            return default;
        }

        public async Task<TEntity> RenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render(self, report_ref, res_ids, data=None):
            // report = self._get_report(report_ref)
            // report_type = report.report_type.lower().replace('-', '_')
            // render_func = getattr(self, '_render_' + report_type, None)
            // if not render_func:
            //     return None
            // return render_func(report_ref, res_ids, data=data)
            */
            return default;
        }

        public async Task<TEntity> RenderQwebHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_qweb_html(self, report_ref, docids, data=None):
            // if not data:
            //     data = {}
            // data.setdefault('report_type', 'html')
            // report = self._get_report(report_ref)
            // data = self._get_rendering_context(report, docids, data)
            // return self._render_template(report.report_name, data), 'html'
            */
            return default;
        }

        public async Task<TEntity> RenderQwebPdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, List<Guid> res_ids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf(self, report_ref, res_ids=None, data=None):
            // if not data:
            //     data = {}
            // if isinstance(res_ids, int):
            //     res_ids = [res_ids]
            // data.setdefault('report_type', 'pdf')
            // 
            // collected_streams, report_type = self._pre_render_qweb_pdf(report_ref, res_ids=res_ids, data=data)
            // if report_type != 'pdf':
            //     return collected_streams, report_type
            // 
            // has_duplicated_ids = res_ids and len(res_ids) != len(set(res_ids))
            // 
            // # access the report details with sudo() but keep evaluation context as current user
            // report_sudo = self._get_report(report_ref)
            // 
            // # Generate the ir.attachment if needed.
            // if not has_duplicated_ids and report_sudo.attachment and not self.env.context.get("report_pdf_no_attachment"):
            //     attachment_vals_list = self._prepare_pdf_report_attachment_vals_list(report_sudo, collected_streams)
            //     if attachment_vals_list:
            //         attachment_names = ', '.join(x['name'] for x in attachment_vals_list)
            //         try:
            //             self.env['ir.attachment'].create(attachment_vals_list)
            //         except AccessError:
            //             _logger.info("Cannot save PDF report %r attachments for user %r", attachment_names, self.env.user.display_name)
            //         else:
            //             _logger.info("The PDF documents %r are now saved in the database", attachment_names)
            // 
            // def custom_handle_merge_pdfs_error(error, error_stream):
            //     error_record_ids.append(stream_to_ids[error_stream])
            // 
            // stream_to_ids = {v['stream']: k for k, v in collected_streams.items() if v['stream']}
            // # Merge all streams together for a single record.
            // streams_to_merge = list(stream_to_ids.keys())
            // error_record_ids = []
            // 
            // if len(streams_to_merge) == 1:
            //     pdf_content = streams_to_merge[0].getvalue()
            // else:
            //     with self._merge_pdfs(streams_to_merge, custom_handle_merge_pdfs_error) as pdf_merged_stream:
            //         pdf_content = pdf_merged_stream.getvalue()
            // 
            // if error_record_ids:
            //     action = {
            //         'type': 'ir.actions.act_window',
            //         'name': _('Problematic record(s)'),
            //         'res_model': report_sudo.model,
            //         'domain': [('id', 'in', error_record_ids)],
            //         'views': [(False, 'list'), (False, 'form')],
            //     }
            //     num_errors = len(error_record_ids)
            //     if num_errors == 1:
            //         action.update({
            //             'views': [(False, 'form')],
            //             'res_id': error_record_ids[0],
            //         })
            //     raise RedirectWarning(
            //         message=_('Odoo is unable to merge the generated PDFs because of %(num_errors)s corrupted file(s)', num_errors=num_errors),
            //         action=action,
            //         button_text=_('View Problematic Record(s)'),
            //     )
            // 
            // for stream in streams_to_merge:
            //     stream.close()
            // 
            // if res_ids:
            //     _logger.info("The PDF report has been generated for model: %s, records %s.", report_sudo.model, str(res_ids))
            // 
            // return pdf_content, 'pdf'
            */
            return default;
        }

        public async Task<TEntity> RenderQwebPdfPrepareStreamsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object data, List<Guid> res_ids) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf_prepare_streams(self, report_ref, data, res_ids=None):
            // # Custom behavior for 'account.report_original_vendor_bill'.
            // if self._get_report(report_ref).report_name != 'account.report_original_vendor_bill':
            //     return super()._render_qweb_pdf_prepare_streams(report_ref, data, res_ids=res_ids)
            // 
            // invoices = self.env['account.move'].browse(res_ids)
            // original_attachments = invoices.message_main_attachment_id
            // if not original_attachments:
            //     raise UserError(_("No original purchase document could be found for any of the selected purchase documents."))
            // 
            // collected_streams = OrderedDict()
            // for invoice in invoices:
            //     attachment = self._prepare_local_attachments(invoice.message_main_attachment_id)
            //     if attachment:
            //         stream = pdf.to_pdf_stream(attachment)
            //         if stream:
            //             record = self.env[attachment.res_model].browse(attachment.res_id)
            //             try:
            //                 stream = pdf.add_banner(stream, record.name or '', logo=True)
            //             except (ValueError, pdf.PdfReadError, TypeError, zlib_error, NotImplementedError, pdf.DependencyError, ArithmeticError):
            //                 record._message_log(body=_(
            //                     "There was an error when trying to add the banner to the original PDF.\n"
            //                     "Please make sure the source file is valid."
            //                 ))
            //         collected_streams[invoice.id] = {
            //             'stream': stream,
            //             'attachment': attachment,
            //         }
            // return collected_streams
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf_prepare_streams(self, report_ref, data, res_ids=None):
            // # EXTENDS base
            // collected_streams = super()._render_qweb_pdf_prepare_streams(report_ref, data, res_ids=res_ids)
            // 
            // if collected_streams \
            //         and res_ids \
            //         and len(res_ids) == 1 \
            //         and self._is_invoice_report(report_ref):
            //     invoice = self.env['account.move'].browse(res_ids)
            //     if invoice.is_sale_document() and invoice.state != 'draft':
            //         to_embed = invoice.edi_document_ids
            //         # Add the attachments to the pdf file
            //         if to_embed:
            //             pdf_stream = collected_streams[invoice.id]['stream']
            // 
            //             # Read pdf content.
            //             pdf_content = pdf_stream.getvalue()
            //             reader_buffer = io.BytesIO(pdf_content)
            //             reader = OdooPdfFileReader(reader_buffer, strict=False)
            // 
            //             # Post-process and embed the additional files.
            //             writer = OdooPdfFileWriter()
            //             writer.cloneReaderDocumentRoot(reader)
            //             for edi_document in to_embed:
            //                 # The attachements on the edi documents are only system readable
            //                 # because they don't have res_id and res_model, here we are sure that
            //                 # the user has access to the invoice and edi document
            //                 edi_document.edi_format_id._prepare_invoice_report(writer, edi_document)
            // 
            //             # Replace the current content.
            //             pdf_stream.close()
            //             new_pdf_stream = io.BytesIO()
            //             writer.write(new_pdf_stream)
            //             collected_streams[invoice.id]['stream'] = new_pdf_stream
            // 
            // return collected_streams
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf_prepare_streams(self, report_ref, data, res_ids=None):
            // # EXTENDS base
            // collected_streams = super()._render_qweb_pdf_prepare_streams(report_ref, data, res_ids)
            // 
            // # allows to add factur-x.xml to custom PDF templates (comma separated list of template names)
            // custom_templates = self.env['ir.config_parameter'].sudo().get_param('account.custom_templates_facturx_list', '')
            // custom_templates = [report.strip() for report in custom_templates.split(',')]
            // 
            // if (
            //     collected_streams
            //     and res_ids
            //     and len(res_ids) == 1
            //     and self._get_report(report_ref).report_name in custom_templates
            // ):
            //     # Generate and embed Factur-X
            //     invoice = self.env['account.move'].browse(res_ids)
            //     if invoice.is_sale_document() and invoice.state == 'posted':
            //         pdf_stream = collected_streams[invoice.id]['stream']
            //         invoice_data = {'pdf_attachment_values': {'raw': pdf_stream.getvalue()}}
            //         self.env['account.move.send'].with_context(custom_template_facturx=True)._hook_invoice_document_after_pdf_report_render(invoice, invoice_data)
            //         collected_streams[invoice.id]['stream'] = io.BytesIO(invoice_data['pdf_attachment_values']['raw'])
            // return collected_streams
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf_prepare_streams(self, report_ref, data, res_ids=None):
            // # OVERRIDE
            // res = super()._render_qweb_pdf_prepare_streams(report_ref, data, res_ids)
            // if not res_ids:
            //     return res
            // report = self._get_report(report_ref)
            // if report.report_name == 'hr_expense.report_expense':
            //     for expense in self.env['hr.expense'].browse(res_ids):
            //         # Will contains the expense
            //         stream_list = []
            //         stream = res[expense.id]['stream']
            //         stream_list.append(stream)
            //         attachments = self.env['ir.attachment'].search([('res_id', 'in', expense.ids), ('res_model', '=', 'hr.expense')])
            //         expense_report = OdooPdfFileReader(stream, strict=False)
            //         output_pdf = OdooPdfFileWriter()
            //         output_pdf.appendPagesFromReader(expense_report)
            //         for attachment in self._prepare_local_attachments(attachments):
            //             if attachment.mimetype == 'application/pdf':
            //                 attachment_stream = pdf.to_pdf_stream(attachment)
            //             else:
            //                 # In case the attachment is not a pdf we will create a new PDF from the template "report_expense_img"
            //                 # And then append to the stream. By doing so, the attachment is put on a new page with the name of the expense
            //                 # associated to the attachment
            //                 data['attachment'] = attachment
            //                 attachment_prep_stream = self._render_qweb_pdf_prepare_streams('hr_expense.report_expense_img', data, res_ids=res_ids)
            //                 attachment_stream = attachment_prep_stream[expense.id]['stream']
            //             attachment_reader = OdooPdfFileReader(attachment_stream, strict=False)
            //             output_pdf.appendPagesFromReader(attachment_reader)
            //             stream_list.append(attachment_stream)
            // 
            //         new_pdf_stream = io.BytesIO()
            //         output_pdf.write(new_pdf_stream)
            //         res[expense.id]['stream'] = new_pdf_stream
            // 
            //         for stream in stream_list:
            //             stream.close()
            // return res
            --- ODOO METHOD SOURCE (MODULE: purchase, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf_prepare_streams(self, report_ref, data, res_ids=None):
            // # EXTENDS base
            // collected_streams = super()._render_qweb_pdf_prepare_streams(report_ref, data, res_ids=res_ids)
            // 
            // if (
            //     collected_streams
            //     and res_ids
            //     and len(res_ids) == 1
            //     and self._is_purchase_order_report(report_ref)
            // ):
            //     purchase_order = self.env['purchase.order'].browse(res_ids)
            //     builders = purchase_order._get_edi_builders()
            // 
            //     if len(builders) == 0:
            //         return collected_streams
            // 
            //     # Read pdf content.
            //     pdf_stream = collected_streams[purchase_order.id]['stream']
            //     pdf_content = pdf_stream.getvalue()
            //     reader_buffer = io.BytesIO(pdf_content)
            //     reader = OdooPdfFileReader(reader_buffer, strict=False)
            //     writer = OdooPdfFileWriter()
            //     writer.cloneReaderDocumentRoot(reader)
            // 
            //     # Generate and attach EDI documents from each builder
            //     for builder in builders:
            //         xml_content = builder._export_order(purchase_order)
            // 
            //         writer.addAttachment(
            //             builder._export_invoice_filename(purchase_order),  # works even if it's a SO or PO
            //             xml_content,
            //             subtype='text/xml'
            //         )
            // 
            //     # Replace the current content.
            //     pdf_stream.close()
            //     new_pdf_stream = io.BytesIO()
            //     writer.write(new_pdf_stream)
            //     collected_streams[purchase_order.id]['stream'] = new_pdf_stream
            // 
            // return collected_streams
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf_prepare_streams(self, report_ref, data, res_ids=None):
            // # EXTENDS base
            // collected_streams = super()._render_qweb_pdf_prepare_streams(report_ref, data, res_ids=res_ids)
            // 
            // if (
            //     collected_streams
            //     and res_ids
            //     and len(res_ids) == 1
            //     and self._is_sale_order_report(report_ref)
            // ):
            //     sale_order = self.env['sale.order'].browse(res_ids)
            //     builders = sale_order._get_edi_builders()
            //     if len(builders) == 0:
            //         return collected_streams
            // 
            //     # Read pdf content.
            //     pdf_stream = collected_streams[sale_order.id]['stream']
            //     pdf_content = pdf_stream.getvalue()
            //     reader_buffer = io.BytesIO(pdf_content)
            //     reader = OdooPdfFileReader(reader_buffer, strict=False)
            //     writer = OdooPdfFileWriter()
            //     writer.cloneReaderDocumentRoot(reader)
            // 
            //     # Generate and attach EDI documents from each builder
            //     for builder in builders:
            //         xml_content = builder._export_order(sale_order)
            // 
            //         writer.addAttachment(
            //             builder._export_invoice_filename(sale_order),  # works even if it's a SO or PO
            //             xml_content,
            //             subtype='text/xml'
            //         )
            // 
            //     # Replace the current content.
            //     pdf_stream.close()
            //     new_pdf_stream = io.BytesIO()
            //     writer.write(new_pdf_stream)
            //     collected_streams[sale_order.id]['stream'] = new_pdf_stream
            // 
            // return collected_streams
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf_prepare_streams(self, report_ref, data, res_ids=None):
            // """Override to add and fill headers, footers and product documents to the sale quotation."""
            // result = super()._render_qweb_pdf_prepare_streams(report_ref, data, res_ids=res_ids)
            // if self._get_report(report_ref).report_name != 'sale.report_saleorder':
            //     return result
            // 
            // ICP = self.env['ir.config_parameter'].sudo()
            // always_include = str2bool(ICP.get_param('sale.always_include_selected_documents'))
            // orders = self.env['sale.order'].browse(res_ids)
            // 
            // for order in orders:
            //     if (
            //         (order.state != 'sale' or always_include)
            //         and (initial_stream := result.get(order.id, {}).get('stream'))
            //     ):
            //         quotation_documents = order.quotation_document_ids
            //         headers = quotation_documents.filtered(lambda doc: doc.document_type == 'header')
            //         footers = quotation_documents - headers
            //         has_product_document = any(line.product_document_ids for line in order.order_line)
            // 
            //         if not headers and not has_product_document and not footers:
            //             continue
            // 
            //         form_fields_values_mapping = {}
            //         writer = PdfFileWriter()
            // 
            //         self_with_order_context = self.with_context(
            //             use_babel=True, lang=order._get_lang() or self.env.user.lang
            //         )
            // 
            //         if headers:
            //             for header in headers:
            //                 prefix = f'quotation_document_id_{header.id}__'
            //                 self_with_order_context._update_mapping_and_add_pages_to_writer(
            //                     writer, header, form_fields_values_mapping, prefix, order
            //                 )
            //         if has_product_document:
            //             for line in order.order_line:
            //                 for doc in line.product_document_ids:
            //                     # Use both the id of the line and the doc as variants could use the same
            //                     # document.
            //                     prefix = f'sol_id_{line.id}_product_document_id_{doc.id}__'
            //                     self_with_order_context._update_mapping_and_add_pages_to_writer(
            //                         writer, doc, form_fields_values_mapping, prefix, order, line
            //                     )
            //         self._add_pages_to_writer(writer, initial_stream.getvalue())
            //         if footers:
            //             for footer in footers:
            //                 prefix = f'quotation_document_id_{footer.id}__'
            //                 self_with_order_context._update_mapping_and_add_pages_to_writer(
            //                     writer, footer, form_fields_values_mapping, prefix, order
            //                 )
            //         pdf.fill_form_fields_pdf(writer, form_fields=form_fields_values_mapping)
            //         with io.BytesIO() as _buffer:
            //             writer.write(_buffer)
            //             stream = io.BytesIO(_buffer.getvalue())
            //         result[order.id].update({'stream': stream})
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_qweb_pdf_prepare_streams(self, report_ref, data, res_ids=None):
            // if not data:
            //     data = {}
            // data.setdefault('report_type', 'pdf')
            // 
            // # access the report details with sudo() but evaluation context as current user
            // report_sudo = self._get_report(report_ref)
            // has_duplicated_ids = res_ids and len(res_ids) != len(set(res_ids))
            // 
            // collected_streams = OrderedDict()
            // 
            // # Fetch the existing attachments from the database for later use.
            // # Reload the stream from the attachment in case of 'attachment_use'.
            // if res_ids:
            //     records = self.env[report_sudo.model].browse(res_ids)
            //     for record in records:
            //         res_id = record.id
            //         if res_id in collected_streams:
            //             continue
            // 
            //         stream = None
            //         attachment = None
            //         if not has_duplicated_ids and report_sudo.attachment and not self.env.context.get("report_pdf_no_attachment"):
            //             attachment = report_sudo.retrieve_attachment(record)
            // 
            //             # Extract the stream from the attachment.
            //             if attachment and report_sudo.attachment_use:
            //                 stream = io.BytesIO(attachment.raw)
            // 
            //                 # Ensure the stream can be saved in Image.
            //                 if attachment.mimetype.startswith('image'):
            //                     img = Image.open(stream)
            //                     new_stream = io.BytesIO()
            //                     img.convert("RGB").save(new_stream, format="pdf")
            //                     stream.close()
            //                     stream = new_stream
            // 
            //         collected_streams[res_id] = {
            //             'stream': stream,
            //             'attachment': attachment,
            //         }
            // 
            // # Call 'wkhtmltopdf' to generate the missing streams.
            // res_ids_wo_stream = [res_id for res_id, stream_data in collected_streams.items() if not stream_data['stream']]
            // all_res_ids_wo_stream = res_ids if has_duplicated_ids else res_ids_wo_stream
            // is_whtmltopdf_needed = not res_ids or res_ids_wo_stream
            // 
            // if is_whtmltopdf_needed:
            // 
            //     if self.get_wkhtmltopdf_state() == 'install':
            //         # wkhtmltopdf is not installed
            //         # the call should be catched before (cf /report/check_wkhtmltopdf) but
            //         # if get_pdf is called manually (email template), the check could be
            //         # bypassed
            //         raise UserError(_("Unable to find Wkhtmltopdf on this system. The PDF can not be created."))
            // 
            //     # Disable the debug mode in the PDF rendering in order to not split the assets bundle
            //     # into separated files to load. This is done because of an issue in wkhtmltopdf
            //     # failing to load the CSS/Javascript resources in time.
            //     # Without this, the header/footer of the reports randomly disappear
            //     # because the resources files are not loaded in time.
            //     # https://github.com/wkhtmltopdf/wkhtmltopdf/issues/2083
            //     additional_context = {'debug': False}
            //     data.setdefault("debug", False)
            // 
            //     html = self.with_context(**additional_context)._render_qweb_html(report_ref, all_res_ids_wo_stream, data=data)[0]
            // 
            //     bodies, html_ids, header, footer, specific_paperformat_args = report_sudo.with_context(**additional_context)._prepare_html(html, report_model=report_sudo.model)
            // 
            //     if not has_duplicated_ids and report_sudo.attachment and set(res_ids_wo_stream) != set(html_ids):
            //         raise UserError(_(
            //             "Report template “%s” has an issue, please contact your administrator. \n\n"
            //             "Cannot separate file to save as attachment because the report's template does not contain the"
            //             " attributes 'data-oe-model' and 'data-oe-id' as part of the div with 'article' classname.",
            //             report_sudo.name,
            //         ))
            // 
            //     pdf_content = self._run_wkhtmltopdf(
            //         bodies,
            //         report_ref=report_ref,
            //         header=header,
            //         footer=footer,
            //         landscape=self.env.context.get('landscape'),
            //         specific_paperformat_args=specific_paperformat_args,
            //         set_viewport_size=self.env.context.get('set_viewport_size'),
            //     )
            //     pdf_content_stream = io.BytesIO(pdf_content)
            // 
            //     # Printing a PDF report without any records. The content could be returned directly.
            //     if has_duplicated_ids or not res_ids:
            //         return {
            //             False: {
            //                 'stream': pdf_content_stream,
            //                 'attachment': None,
            //             }
            //         }
            // 
            //     # Split the pdf for each record using the PDF outlines.
            // 
            //     # Only one record: append the whole PDF.
            //     if len(res_ids_wo_stream) == 1:
            //         collected_streams[res_ids_wo_stream[0]]['stream'] = pdf_content_stream
            //         return collected_streams
            // 
            //     # In case of multiple docs, we need to split the pdf according the records.
            //     # In the simplest case of 1 res_id == 1 page, we use the PDFReader to print the
            //     # pages one by one.
            //     html_ids_wo_none = [x for x in html_ids if x]
            //     reader = PdfFileReader(pdf_content_stream)
            //     if reader.numPages == len(res_ids_wo_stream):
            //         for i in range(reader.numPages):
            //             attachment_writer = PdfFileWriter()
            //             attachment_writer.addPage(reader.getPage(i))
            //             stream = io.BytesIO()
            //             attachment_writer.write(stream)
            //             collected_streams[res_ids_wo_stream[i]]['stream'] = stream
            //         return collected_streams
            // 
            //     # In cases where the number of res_ids != the number of pages,
            //     # we split the pdf based on top outlines computed by wkhtmltopdf.
            //     # An outline is a <h?> html tag found on the document. To retrieve this table,
            //     # we look on the pdf structure using pypdf to compute the outlines_pages from
            //     # the top level heading in /Outlines.
            //     if len(res_ids_wo_stream) > 1 and set(res_ids_wo_stream) == set(html_ids_wo_none):
            //         root = reader.trailer['/Root']
            //         has_valid_outlines = '/Outlines' in root and '/First' in root['/Outlines']
            //         if not has_valid_outlines:
            //             return {False: {
            //                 'report_action': self,
            //                 'stream': pdf_content_stream,
            //                 'attachment': None,
            //             }}
            // 
            //         outlines_pages = []
            //         node = root['/Outlines']['/First']
            //         while True:
            //             outlines_pages.append(root['/Dests'][node['/Dest']][0])
            //             if '/Next' not in node:
            //                 break
            //             node = node['/Next']
            //         outlines_pages = sorted(set(outlines_pages))
            // 
            //         # The number of outlines must be equal to the number of records to be able to split the document.
            //         has_same_number_of_outlines = len(outlines_pages) == len(res_ids_wo_stream)
            // 
            //         # There should be a top-level heading on first page
            //         has_top_level_heading = outlines_pages[0] == 0
            // 
            //         if has_same_number_of_outlines and has_top_level_heading:
            //             # Split the PDF according to outlines.
            //             for i, num in enumerate(outlines_pages):
            //                 to = outlines_pages[i + 1] if i + 1 < len(outlines_pages) else reader.numPages
            //                 attachment_writer = PdfFileWriter()
            //                 for j in range(num, to):
            //                     attachment_writer.addPage(reader.getPage(j))
            //                 stream = io.BytesIO()
            //                 attachment_writer.write(stream)
            //                 collected_streams[res_ids_wo_stream[i]]['stream'] = stream
            //             return collected_streams
            //         else:
            //             for res_id in res_ids_wo_stream:
            //                 individual_collected_stream = self._render_qweb_pdf_prepare_streams(report_ref=report_ref, data=data, res_ids=[res_id])
            //                 collected_streams[res_id]['stream'] = individual_collected_stream[res_id]['stream']
            //     collected_streams[False] = {'stream': pdf_content_stream, 'attachment': None}
            // 
            // return collected_streams
            */
            return default;
        }

        public async Task<TEntity> RenderQwebTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_ref, object docids, object data) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_qweb_text(self, report_ref, docids, data=None):
            // if not data:
            //     data = {}
            // data.setdefault('report_type', 'text')
            // report = self._get_report(report_ref)
            // data = self._get_rendering_context(report, docids, data)
            // return self._render_template(report.report_name, data), 'text'
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template, object values) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _render_template(self, template, values=None):
            // """Allow to render a QWeb template python-side. This function returns the 'ir.ui.view'
            // render but embellish it with some variables/methods used in reports.
            // :param values: additional methods/variables used in the rendering
            // :returns: html representation of the template
            // :rtype: bytes
            // """
            // if values is None:
            //     values = {}
            // 
            // # Browse the user instead of using the sudo self.env.user
            // user = self.env['res.users'].browse(self.env.uid)
            // view_obj = self.env['ir.ui.view'].with_context(inherit_branding=False)
            // values.update(
            //     time=time,
            //     context_timestamp=lambda t: fields.Datetime.context_timestamp(self.with_context(tz=user.tz), t),
            //     user=user,
            //     res_company=self.env.company,
            //     web_base_url=self.env['ir.config_parameter'].sudo().get_param('web.base.url', default=''),
            // )
            // return view_obj._render_template(template, values).encode()
            */
            return default;
        }

        public async Task<TEntity> ReportActionAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data, object config) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def report_action(self, docids, data=None, config=True):
            // """Return an action of type ir.actions.report.
            // 
            // :param docids: id/ids/browse record of the records to print (if not used, pass an empty list)
            // :param data:
            // :param bool config:
            // :rtype: bytes
            // """
            // context = self.env.context
            // if docids:
            //     if isinstance(docids, models.Model):
            //         active_ids = docids.ids
            //     elif isinstance(docids, int):
            //         active_ids = [docids]
            //     elif isinstance(docids, list):
            //         active_ids = docids
            //     context = dict(self.env.context, active_ids=active_ids)
            // 
            // report_action = {
            //     'context': context,
            //     'data': data,
            //     'type': 'ir.actions.report',
            //     'report_name': self.report_name,
            //     'report_type': self.report_type,
            //     'report_file': self.report_file,
            //     'name': self.name,
            // }
            // 
            // discard_logo_check = self.env.context.get('discard_logo_check')
            // if self.env.is_admin() and not self.env.company.external_report_layout_id and config and not discard_logo_check:
            //     return self._action_configure_external_report_layout(report_action)
            // 
            // return report_action
            */
            return default;
        }

        public async Task<TEntity> RetrieveAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: ir_actions_report.py) ---
            // def retrieve_attachment(self, record):
            // # Override this method in order to force to re-render the pdf in case of
            // # using snailmail
            // if self.env.context.get('snailmail_layout'):
            //     return False
            // return super().retrieve_attachment(record)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def retrieve_attachment(self, record):
            // '''Retrieve an attachment for a specific record.
            // 
            // :param record: The record owning of the attachment.
            // :return: A recordset of length <=1 or None
            // '''
            // attachment_name = safe_eval(self.attachment, {'object': record, 'time': time}) if self.attachment else ''
            // if not attachment_name:
            //     return None
            // return self.env['ir.attachment'].search([
            //         ('name', '=', attachment_name),
            //         ('res_model', '=', self.model),
            //         ('res_id', '=', record.id)
            // ], limit=1)
            */
            return default;
        }

        public async Task<List<object>> RunWkhtmltoimageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bodies, object width, object height, object image_format) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _run_wkhtmltoimage(self, bodies, width, height, image_format="jpg") -> list[bytes | None]:
            // """
            // :param str bodies: valid html documents as strings
            // :param int width: width in pixels
            // :param int height: height in pixels
            // :param image_format: format of the image
            // :type image_format: typing.Literal['jpg', 'png']
            // """
            // if modules.module.current_test:
            //     return [None] * len(bodies)
            // wkhtmltoimage_version = _wkhtml().wkhtmltoimage_version
            // if not wkhtmltoimage_version or wkhtmltoimage_version < parse_version('0.12.0'):
            //     raise UserError(_('wkhtmltoimage 0.12.0^ is required in order to render images from html'))
            // command_args = [
            //     '--disable-local-file-access', '--disable-javascript',
            //     '--quiet',
            //     '--width', str(width), '--height', str(height),
            //     '--format', image_format,
            // ]
            // with ExitStack() as stack:
            //     files = []
            //     for body in bodies:
            //         (input_fd, input_path) = tempfile.mkstemp(suffix='.html', prefix='report_image_html_input.tmp.')
            //         (output_fd, output_path) = tempfile.mkstemp(suffix=f'.{image_format}', prefix='report_image_output.tmp.')
            //         stack.callback(os.remove, input_path)
            //         stack.callback(os.remove, output_path)
            //         os.close(output_fd)
            //         with closing(os.fdopen(input_fd, 'wb')) as input_file:
            //             input_file.write(body.encode())
            //         files.append((input_path, output_path))
            //     output_images = []
            //     for (input_path, output_path) in files:
            //         wkhtmltoimage = [_wkhtml().wkhtmltoimage_bin, *command_args, input_path, output_path]
            //         # start and block, no need for parallelism for now
            //         completed_process = subprocess.run(wkhtmltoimage, stdout=subprocess.DEVNULL, stderr=subprocess.PIPE, check=False, encoding='utf-8')
            //         if completed_process.returncode:
            //             message = _(
            //                 'Wkhtmltoimage failed (error code: %(error_code)s). Message: %(error_message_end)s',
            //                 error_code=completed_process.returncode,
            //                 error_message_end=completed_process.stderr[-1000:],
            //             )
            //             _logger.warning(message)
            //             output_images.append(None)
            //         else:
            //             with open(output_path, 'rb') as output_file:
            //                 output_images.append(output_file.read())
            // return output_images
            */
            return default;
        }

        public async Task<TEntity> RunWkhtmltopdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bodies, object report_ref, object header, object footer, object landscape, object specific_paperformat_args, object set_viewport_size) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _run_wkhtmltopdf(
            //     self,
            //     bodies,
            //     report_ref=False,
            //     header=None,
            //     footer=None,
            //     landscape=False,
            //     specific_paperformat_args=None,
            //     set_viewport_size=False):
            // '''Execute wkhtmltopdf as a subprocess in order to convert html given in input into a pdf
            // document.
            // 
            // :param Iterable[str] bodies: The html bodies of the report, one per page.
            // :param report_ref: report reference that is needed to get report paperformat.
            // :param str header: The html header of the report containing all headers.
            // :param str footer: The html footer of the report containing all footers.
            // :param landscape: Force the pdf to be rendered under a landscape format.
            // :param specific_paperformat_args: dict of prioritized paperformat arguments.
            // :param set_viewport_size: Enable a viewport sized '1024x1280' or '1280x1024' depending of landscape arg.
            // :return: Content of the pdf as bytes
            // :rtype: bytes
            // '''
            // paperformat_id = self._get_report(report_ref).get_paperformat() if report_ref else self.get_paperformat()
            // 
            // # Build the base command args for wkhtmltopdf bin
            // command_args = self._build_wkhtmltopdf_args(
            //     paperformat_id,
            //     landscape,
            //     specific_paperformat_args=specific_paperformat_args,
            //     set_viewport_size=set_viewport_size)
            // 
            // files_command_args = []
            // 
            // def delete_file(file_path):
            //     try:
            //         os.unlink(file_path)
            //     except OSError:
            //         _logger.error('Error when trying to remove file %s', file_path)
            // 
            // with ExitStack() as stack:
            // 
            //     # Passing the cookie to wkhtmltopdf in order to resolve internal links.
            //     if request and request.db:
            //         # Create a temporary session which will not create device logs
            //         temp_session = root.session_store.new()
            //         temp_session.update({
            //             **request.session,
            //             'debug': '',
            //             '_trace_disable': True,
            //         })
            //         if temp_session.uid:
            //             temp_session.session_token = security.compute_session_token(temp_session, self.env)
            //         root.session_store.save(temp_session)
            //         stack.callback(root.session_store.delete, temp_session)
            // 
            //         base_url = self._get_report_url()
            //         domain = urlparse(base_url).hostname
            //         cookie = f'session_id={temp_session.sid}; HttpOnly; domain={domain}; path=/;'
            //         cookie_jar_file_fd, cookie_jar_file_path = tempfile.mkstemp(suffix='.txt', prefix='report.cookie_jar.tmp.')
            //         stack.callback(delete_file, cookie_jar_file_path)
            //         with closing(os.fdopen(cookie_jar_file_fd, 'wb')) as cookie_jar_file:
            //             cookie_jar_file.write(cookie.encode())
            //         command_args.extend(['--cookie-jar', cookie_jar_file_path])
            // 
            //     if header:
            //         head_file_fd, head_file_path = tempfile.mkstemp(suffix='.html', prefix='report.header.tmp.')
            //         with closing(os.fdopen(head_file_fd, 'wb')) as head_file:
            //             head_file.write(header.encode())
            //         stack.callback(delete_file, head_file_path)
            //         files_command_args.extend(['--header-html', head_file_path])
            //     if footer:
            //         foot_file_fd, foot_file_path = tempfile.mkstemp(suffix='.html', prefix='report.footer.tmp.')
            //         with closing(os.fdopen(foot_file_fd, 'wb')) as foot_file:
            //             foot_file.write(footer.encode())
            //         stack.callback(delete_file, foot_file_path)
            //         files_command_args.extend(['--footer-html', foot_file_path])
            // 
            //     paths = []
            //     body_idx = 0
            //     for body_idx, body in enumerate(bodies):
            //         prefix = f'report.body.tmp.{body_idx}.'
            //         body_file_fd, body_file_path = tempfile.mkstemp(suffix='.html', prefix=prefix)
            //         with closing(os.fdopen(body_file_fd, 'wb')) as body_file:
            //             # HACK: wkhtmltopdf doesn't like big table at all and the
            //             #       processing time become exponential with the number
            //             #       of rows (like 1H for 250k rows).
            //             #
            //             #       So we split the table into multiple tables containing
            //             #       500 rows each. This reduce the processing time to 1min
            //             #       for 250k rows. The number 500 was taken from opw-1689673
            //             if len(body) < 4 * 1024 * 1024:  # 4Mib
            //                 body_file.write(body.encode())
            //             else:
            //                 tree = lxml.html.fromstring(body)
            //                 _split_table(tree, 500)
            //                 body_file.write(lxml.html.tostring(tree))
            //         paths.append(body_file_path)
            //         stack.callback(delete_file, body_file_path)
            // 
            //     pdf_report_fd, pdf_report_path = tempfile.mkstemp(suffix='.pdf', prefix='report.tmp.')
            //     os.close(pdf_report_fd)
            //     stack.callback(delete_file, pdf_report_path)
            // 
            //     process = _run_wkhtmltopdf(command_args + files_command_args + paths + [pdf_report_path])
            //     err = process.stderr
            // 
            //     match process.returncode:
            //         case 0:
            //             pass
            //         case 1:
            //             if body_idx:
            //                 if not _wkhtml().is_patched_qt:
            //                     if modules.module.current_test:
            //                         raise unittest.SkipTest("Unable to convert multiple documents via wkhtmltopdf using unpatched QT")
            //                     raise UserError(_("Tried to convert multiple documents in wkhtmltopdf using unpatched QT"))
            // 
            //             _logger.warning("wkhtmltopdf: %s", err)
            //         case c:
            //             message = _(
            //                 'Wkhtmltopdf failed (error code: %(error_code)s). Memory limit too low or maximum file number of subprocess reached. Message : %(message)s',
            //                 error_code=c,
            //                 message=err[-1000:],
            //             ) if c == -11 else _(
            //                 'Wkhtmltopdf failed (error code: %(error_code)s). Message: %(message)s',
            //                 error_code=c,
            //                 message=err[-1000:],
            //             )
            //             _logger.warning(message)
            //             raise UserError(message)
            // 
            //     with open(pdf_report_path, 'rb') as pdf_document:
            //         pdf_content = pdf_document.read()
            // 
            // return pdf_content
            */
            return default;
        }

        public async Task<TEntity> SearchModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def _search_model_id(self, operator, value):
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // models = self.env['ir.model']
            // if isinstance(value, str):
            //     models = models.search(Domain('display_name', operator, value))
            // elif isinstance(value, Domain):
            //     models = models.search(value)
            // elif operator == 'any!':
            //     models = models.sudo().search(Domain('id', operator, value))
            // elif operator == 'any' or isinstance(value, int):
            //     models = models.search(Domain('id', operator, value))
            // elif operator == 'in':
            //     models = models.search(Domain.OR(
            //         Domain('id' if isinstance(v, int) else 'display_name', operator, v)
            //         for v in value
            //         if v
            //     ))
            // return Domain('model', 'in', models.mapped('model'))
            */
            return default;
        }

        public async Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions_report.py) ---
            // def unlink_action(self):
            // """ Remove the contextual actions created for the reports. """
            // self.check_access('write')
            // self.filtered('binding_model_id').write({'binding_model_id': False})
            // return True
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptMasterTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_actions_report.py) ---
            // def _unlink_except_master_tags(self):
            // master_xmlids = [
            //     "account_invoices",
            //     "action_account_original_vendor_bill"
            //     "account_invoices_without_payment",
            //     "action_report_journal",
            //     "action_report_payment_receipt",
            //     "action_report_account_statement",
            //     "action_report_account_hash_integrity",
            // ]
            // for master_xmlid in master_xmlids:
            //     master_report = self.env.ref(f"account.{master_xmlid}", raise_if_not_found=False)
            //     if master_report and master_report in self:
            //         raise UserError(_("You cannot delete this report (%s), it is used by the accounting PDF generation engine.", master_report.name))
            */
            return default;
        }

        public async Task<TEntity> UpdateMappingAndAddPagesToWriterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object writer, object document, object form_fields_values_mapping, object prefix, object order, object order_line) where TEntity : IEntity<Guid>, IIrActionsReportable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: ir_actions_report.py) ---
            // def _update_mapping_and_add_pages_to_writer(
            //     self, writer, document, form_fields_values_mapping, prefix, order, order_line=None
            // ):
            //     """ Update the mapping with the field-value of the document, and add the doc to the writer.
            // 
            //     Note: document.ensure_one(), order.ensure_one(), order_line and order_line.ensure_one()
            // 
            //     :param PdfFileWriter writer: the writer to which pages needs to be added
            //     :param recordset document: the document that needs to be added to the writer and get its
            //                                form fields mapped. Either a quotation.document or a
            //                                product.document.
            //     :param dict form_fields_values_mapping: the existing prefixed form field names - values that
            //                                             will be updated to add those of the current document
            //     :param str prefix: the prefix needed to update existing form field name, to be able to add
            //                        the correct values in fields with the same name but on different
            //                        documents, either customizable fields or dynamic fields of different sale
            //                        order lines.
            //     :param recordset order: the sale order from where to take the values
            //     :param recordset order_line: the sale order line from where to take the values (optional)
            //     :return: None
            //     """
            //     document.ensure_one()
            //     order.ensure_one()
            //     order_line and order_line.ensure_one()
            // 
            //     for form_field in document.form_field_ids:
            //         if form_field.path:  # Dynamic field
            //             field_value = self._get_value_from_path(form_field, order, order_line)
            //         else:  # Customizable field
            //             field_value = self._get_custom_value_from_order(
            //                 document, form_field.name, order, order_line
            //             )
            //         form_fields_values_mapping[prefix + form_field.name] = field_value
            // 
            //     # Avoid useless update of the pdf when no form field and just add the pdf
            //     prefix = prefix if document.form_field_ids else None
            //     decoded_document = base64.b64decode(document.datas)
            //     self._add_pages_to_writer(writer, decoded_document, prefix)
            */
            return default;
        }
    }
}