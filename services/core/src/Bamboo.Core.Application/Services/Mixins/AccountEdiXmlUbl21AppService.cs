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
    [Module("account_edi_ubl_cii", Depends = new[] { "account" })]
    public class AccountEdiXmlUbl21AppService : ApplicationService, IAccountEdiXmlUbl21AppService
    {

        public AccountEdiXmlUbl21AppService() 
        {

        }

        public async Task<TEntity> AddDocumentAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py) ---
            // def _add_document_allowance_charge_nodes(self, document_node, vals):
            // super()._add_document_allowance_charge_nodes(document_node, vals)
            // 
            // # AllowanceCharge exists in debit notes only in UBL 2.1
            // if vals['document_type'] == 'debit_note':
            //     document_node['cac:AllowanceCharge'] = []
            //     for base_line in vals['base_lines']:
            //         if self._is_document_allowance_charge(base_line):
            //             document_node['cac:AllowanceCharge'].append(
            //                 self._get_document_allowance_charge_node({
            //                     **vals,
            //                     'base_line': base_line,
            //                 })
            //             )
            */
            return default;
        }

        public async Task<TEntity> AddDocumentCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_document_currency_vals(self, vals):
            // super()._add_document_currency_vals(vals)
            // vals['currency_dp'] = 2
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py) ---
            // def _add_document_line_allowance_charge_nodes(self, line_node, vals):
            // line_node['cac:AllowanceCharge'] = [self._get_line_discount_allowance_charge_node(vals)]
            // if vals['fixed_taxes_as_allowance_charges']:
            //     line_node['cac:AllowanceCharge'].extend(self._get_line_fixed_tax_allowance_charge_nodes(vals))
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_document_line_amount_nodes(self, line_node, vals):
            // super()._add_document_line_amount_nodes(line_node, vals)
            // # We can't have negative unit prices, so we invert the signs of
            // # the unit price and quantity, resulting in the same amount in the end
            // quantity_tag = self._get_tags_for_document_type(vals)['line_quantity']
            // if vals['base_line']['price_unit'] < 0.0:
            //     line_node[quantity_tag]['_text'] = -vals['base_line']['quantity']
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_document_line_item_nodes(self, line_node, vals):
            // super()._add_document_line_item_nodes(line_node, vals)
            // product = vals['base_line']['product_id']
            // line_node['cac:Item']['cac:SellersItemIdentification'] = {
            //     'cbc:ID': {'_text': product.code},
            // }
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_document_line_price_nodes(self, line_node, vals):
            // super()._add_document_line_price_nodes(line_node, vals)
            // if vals['base_line']['price_unit'] < 0.0:
            //     line_node['cac:Price']['cbc:PriceAmount']['_text'] = -line_node['cac:Price']['cbc:PriceAmount']['_text']
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_document_line_tax_category_nodes(self, line_node, vals):
            // base_line = vals['base_line']
            // aggregated_tax_details = self.env['account.tax']._aggregate_base_line_tax_details(base_line, vals['tax_grouping_function'])
            // 
            // line_node['cac:Item']['cac:ClassifiedTaxCategory'] = [
            //     # [UBL-CR-600] A UBL invoice should not include the InvoiceLine Item ClassifiedTaxCategory TaxExemptionReasonCode
            //     # [UBL-CR-601] TaxExemptionReason must not appear in InvoiceLine Item ClassifiedTaxCategory
            //     # [BR-E-10] TaxExemptionReason must only appear in TaxTotal TaxSubtotal TaxCategory
            //     self._get_tax_category_node({
            //         **vals,
            //         'grouping_key': {
            //             **grouping_key,
            //             'tax_exemption_reason_code': None,
            //             'tax_exemption_reason': None,
            //         }
            //     })
            //     for grouping_key in aggregated_tax_details
            //     if grouping_key
            // ]
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_document_line_tax_total_nodes(self, line_node, vals):
            // # TaxTotal should not be used in BIS 3.0
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_delivery_nodes(self, document_node, vals):
            // """ [BR-IC-12]-In an Invoice with a VAT breakdown (BG-23) where the VAT category code (BT-118) is
            // "Intra-community supply" the Deliver to country code (BT-80) shall not be blank.
            // 
            // [BR-IC-11]-In an Invoice with a VAT breakdown (BG-23) where the VAT category code (BT-118) is
            // "Intra-community supply" the Actual delivery date (BT-72) or the Invoicing period (BG-14)
            // shall not be blank.
            // """
            // super()._add_invoice_delivery_nodes(document_node, vals)
            // 
            // invoice = vals['invoice']
            // customer = vals['customer']
            // supplier = vals['supplier']
            // intracom_delivery = (
            //     customer.country_id.code in (economic_area := self.env.ref('base.europe').country_ids.mapped('code') + ['NO'])
            //     and supplier.country_id.code in economic_area
            //     and supplier.country_id != customer.country_id
            // )
            // if intracom_delivery:
            //     document_node['cac:Delivery'] = {
            //         'cbc:ActualDeliveryDate': {'_text': invoice.invoice_date},
            //         'cac:DeliveryLocation': {
            //             'cac:Address': self._get_address_node({'partner': vals['partner_shipping']})
            //         },
            //     }
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py) ---
            // def _add_invoice_header_nodes(self, document_node, vals):
            // super()._add_invoice_header_nodes(document_node, vals)
            // 
            // invoice = vals['invoice']
            // document_node.update({
            //     'cbc:UBLVersionID': {'_text': '2.1'},
            //     'cbc:DueDate': {'_text': invoice.invoice_date_due} if vals['document_type'] == 'invoice' else None,
            //     'cbc:CreditNoteTypeCode': {'_text': 381} if vals['document_type'] == 'credit_note' else None,
            //     'cbc:BuyerReference': {'_text': invoice.commercial_partner_id.ref},
            // })
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_header_nodes(self, document_node, vals):
            // # Call the parent method from UBL 2.1
            // super()._add_invoice_header_nodes(document_node, vals)
            // invoice = vals['invoice']
            // 
            // # Override specific BIS3 values
            // document_node.update({
            //     'cbc:UBLVersionID': None,
            //     'cbc:CustomizationID': {'_text': self._get_customization_ids()['ubl_bis3']},
            //     'cbc:ProfileID': {'_text': 'urn:fdc:peppol.eu:2017:poacc:billing:01:1.0'},
            // })
            // 
            // # [NL-R-001] For suppliers in the Netherlands, if the document is a creditnote, the document MUST
            // # contain an invoice reference (cac:BillingReference/cac:InvoiceDocumentReference/cbc:ID)
            // if vals['supplier'].country_id.code == 'NL' and 'refund' in invoice.move_type:
            //     document_node['cac:BillingReference'] = {
            //         'cac:InvoiceDocumentReference': {
            //             'cbc:ID': {'_text': invoice.ref},
            //         }
            //     }
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePeriodNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py) ---
            // def _add_invoice_line_period_nodes(self, line_node, vals):
            // base_line = vals['base_line']
            // 
            // # deferred_start_date & deferred_end_date are enterprise-only fields
            // if (
            //     vals['document_type'] in {'invoice', 'credit_note'}
            //     and (base_line.get('deferred_start_date') or base_line.get('deferred_end_date'))
            // ):
            //     line_node['cac:InvoicePeriod'] = {
            //         'cbc:StartDate': {'_text': base_line['deferred_start_date']},
            //         'cbc:EndDate': {'_text': base_line['deferred_end_date']},
            //     }
            */
            return default;
        }

        public async Task<TEntity> AddInvoicePaymentMeansNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_payment_means_nodes(self, document_node, vals):
            // super()._add_invoice_payment_means_nodes(document_node, vals)
            // document_node['cac:PaymentMeans']['cbc:PaymentDueDate'] = None
            // document_node['cac:PaymentMeans']['cbc:InstructionID'] = None
            */
            return default;
        }

        public async Task<TEntity> ApplyInvoiceLineFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _apply_invoice_line_filter(self, invoice_line):
            // """ Override to filter out down payment lines """
            // if not invoice_line.move_id._is_downpayment():
            //     return not invoice_line._get_downpayment_lines()
            // return True
            */
            return default;
        }

        public async Task<TEntity> ApplyInvoiceTaxFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_values) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _apply_invoice_tax_filter(self, base_line, tax_values):
            // """ Override to filter out withholding tax """
            // tax_id = tax_values['tax']
            // res = not tax_id.l10n_sa_is_retention
            // # If the move that is being sent is not a down payment invoice, and the sale module is installed
            // # we need to make sure the line is neither retention, nor a down payment line
            // if not base_line['record'].move_id._is_downpayment():
            //     return not tax_id.l10n_sa_is_retention and not base_line['record']._get_downpayment_lines()
            // return res
            */
            return default;
        }

        public async Task<object> ApproximateAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def approximate(func):
            // """Decorator that rounds the return value of a method."""
            // @wraps(func)
            // def wrapper(self, *args, **kwargs):
            //     result = func(self, *args, **kwargs)
            //     return self._round_max_dp(result)
            // return wrapper
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // # EXTENDS account.edi.xml.ubl_21
            // constraints = super()._export_invoice_constraints(invoice, vals)
            // 
            // constraints.update(
            //     self._invoice_constraints_peppol_en16931_ubl(invoice, vals)
            // )
            // constraints.update(
            //     self._invoice_constraints_cen_en16931_ubl(invoice, vals)
            // )
            // 
            // return constraints
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // # EXTENDS 'account_edi_ubl_cii'
            // constraints = super()._export_invoice_constraints(invoice, vals)
            // 
            // # In malaysia, tax on good is paid at the manufacturer level. It is thus common to invoice without taxes,
            // # unless invoicing for a service.
            // constraints.pop('tax_on_line', '')
            // constraints.pop('cen_en16931_tax_line', '')
            // 
            // if not invoice.company_id.l10n_my_edi_industrial_classification:
            //     self._l10n_my_edi_make_validation_error(constraints, 'industrial_classification_required', 'company', invoice.company_id.display_name)
            // 
            // for partner_type in ('supplier', 'customer'):
            //     partner = vals[partner_type]
            //     phone_number = partner.phone or partner.mobile
            //     # 'NA' is a valid value in some cases, e.g. consolidated invoices.
            //     if phone_number != 'NA':
            //         phone = self._l10n_my_edi_get_formatted_phone_number(phone_number)
            //         if E_164_REGEX.match(phone) is None:
            //             self._l10n_my_edi_make_validation_error(constraints, 'phone_number_format', partner_type, partner.display_name)
            //     elif not phone_number:
            //         self._l10n_my_edi_make_validation_error(constraints, 'phone_number_required', partner_type, partner.display_name)
            // 
            //     # We need to provide both l10n_my_identification_type and l10n_my_identification_number
            //     if not partner.commercial_partner_id.l10n_my_identification_type or not partner.commercial_partner_id.l10n_my_identification_number:
            //         self._l10n_my_edi_make_validation_error(constraints, 'required_id', partner_type, partner.commercial_partner_id.display_name)
            // 
            //     if not partner.state_id:
            //         self._l10n_my_edi_make_validation_error(constraints, 'no_state', partner_type, partner.display_name)
            //     if not partner.city:
            //         self._l10n_my_edi_make_validation_error(constraints, 'no_city', partner_type, partner.display_name)
            //     if not partner.country_id:
            //         self._l10n_my_edi_make_validation_error(constraints, 'no_country', partner_type, partner.display_name)
            //     if not partner.street:
            //         self._l10n_my_edi_make_validation_error(constraints, 'no_street', partner_type, partner.display_name)
            // 
            //     if partner.commercial_partner_id.sst_registration_number and len(partner.commercial_partner_id.sst_registration_number.split(';')) > 2:
            //         self._l10n_my_edi_make_validation_error(constraints, 'too_many_sst', partner_type, partner.commercial_partner_id.display_name)
            // 
            // for line in invoice.invoice_line_ids.filtered(lambda line: line.display_type not in ('line_note', 'line_section')):
            //     if line.product_id and not line.product_id.product_tmpl_id.l10n_my_edi_classification_code:
            //         self._l10n_my_edi_make_validation_error(constraints, 'class_code_required', line.product_id.id, line.product_id.display_name)
            //     if not line.tax_ids:
            //         self._l10n_my_edi_make_validation_error(constraints, 'tax_ids_required', line.id, line.display_name)
            //     elif any(tax.l10n_my_tax_type == 'E' for tax in line.tax_ids) and not invoice.l10n_my_edi_exemption_reason:
            //         self._l10n_my_edi_make_validation_error(constraints, 'tax_exemption_required', invoice.id, invoice.display_name)
            // 
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _export_invoice_constraints_new(self, invoice, vals):
            // constraints = super()._export_invoice_constraints(invoice, vals)
            // constraints.update(
            //     self._invoice_constraints_peppol_en16931_ubl_new(invoice, vals)
            // )
            // constraints.update(
            //     self._invoice_constraints_cen_en16931_ubl_new(invoice, vals)
            // )
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'org.oasis-open:invoice:2.1',
            //     'credit_note': 'org.oasis-open:creditnote:2.1',
            // }
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'eu.peppol.bis3:invoice:3.13.0',
            //     'credit_note': 'eu.peppol.bis3:creditnote:3.13.0',
            // }
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_ubl_21.xml"
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_ubl_bis3.xml"
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _export_invoice_filename(self, invoice):
            // # OVERRIDE 'account_edi_ubl_cii'
            // return f"{invoice.name.replace('/', '_')}_myinvois.xml"
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _export_invoice_filename(self, invoice):
            // """
            //     Generate the name of the invoice XML file according to ZATCA business rules:
            //     Seller Vat Number (BT-31), Date (BT-2), Time (KSA-25), Invoice Number (BT-1)
            // """
            // vat = invoice.company_id.partner_id.commercial_partner_id.vat
            // invoice_number = re.sub(r'[^a-zA-Z0-9 -]+', '-', invoice.name)
            // invoice_date = fields.Datetime.context_timestamp(self.with_context(tz='Asia/Riyadh'), invoice.l10n_sa_confirmation_datetime)
            // file_name = f"{vat}_{invoice_date.strftime('%Y%m%dT%H%M%S')}_{invoice_number}"
            // file_format = self.env.context.get('l10n_sa_file_format', 'xml')
            // if file_format:
            //     file_name = f'{file_name}.{file_format}'
            // return file_name
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _export_invoice_filename(self, invoice):
            // # EXTENDS account_edi_ubl_cii
            // return '%s_einvoice.xml' % invoice.name.replace("/", "_")
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _export_invoice(self, invoice, convert_fixed_taxes=True):
            // # Only for BIS3 invoices: if the 'account_edi_ubl_cii.use_new_dict_to_xml_helpers' param is set,
            // # use the new dict_to_xml helpers.
            // if self._name == 'account.edi.xml.ubl_bis3' and self.env['ir.config_parameter'].sudo().get_param('account_edi_ubl_cii.use_new_dict_to_xml_helpers'):
            //     return self._export_invoice_new(invoice)
            // 
            // return super()._export_invoice(invoice, convert_fixed_taxes=convert_fixed_taxes)
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _export_invoice(self, invoice):
            // # EXTENDS account.edi.xml.ubl_21
            // # _export_invoice normally cleans up the xml to remove empty nodes.
            // # However, in the JO UBL version, we always want the PartyIdentification with ID nodes, even if empty.
            // # We'll replace the empty value by a dummy one so that the node doesn't get cleaned up and remove its content after the file generation.
            // xml, errors = super()._export_invoice(invoice)
            // xml_root = etree.fromstring(xml)
            // party_identification_id_elements = xml_root.findall('.//cac:PartyIdentification/cbc:ID', namespaces=xml_root.nsmap)
            // for element in party_identification_id_elements:
            //     if element.text == 'NO_VAT':
            //         element.text = ''
            // # method='html' is used to keep the element un-shortened ("<a></a>" instead of <a/>)
            // return etree.tostring(xml_root, method='html'), errors
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_20
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals.update({
            //     'AddressType_template': 'account_edi_ubl_cii.ubl_21_AddressType',
            //     'PaymentTermsType_template': 'account_edi_ubl_cii.ubl_21_PaymentTermsType',
            //     'PartyType_template': 'account_edi_ubl_cii.ubl_21_PartyType',
            //     'InvoiceLineType_template': 'account_edi_ubl_cii.ubl_21_InvoiceLineType',
            //     'CreditNoteLineType_template': 'account_edi_ubl_cii.ubl_21_CreditNoteLineType',
            //     'DebitNoteLineType_template': 'account_edi_ubl_cii.ubl_21_DebitNoteLineType',
            //     'InvoiceType_template': 'account_edi_ubl_cii.ubl_21_InvoiceType',
            //     'CreditNoteType_template': 'account_edi_ubl_cii.ubl_21_CreditNoteType',
            //     'DebitNoteType_template': 'account_edi_ubl_cii.ubl_21_DebitNoteType',
            // })
            // 
            // vals['vals'].update({
            //     'ubl_version_id': 2.1,
            //     'buyer_reference': invoice.commercial_partner_id.ref,
            // })
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals'].update({
            //     'customization_id': self._get_customization_ids()['ubl_bis3'],
            //     'profile_id': 'urn:fdc:peppol.eu:2017:poacc:billing:01:1.0',
            //     'currency_dp': 2,
            //     'ubl_version_id': None,
            // })
            // vals['vals']['monetary_total_vals']['currency_dp'] = 2
            // 
            // # [NL-R-001] For suppliers in the Netherlands, if the document is a creditnote, the document MUST
            // # contain an invoice reference (cac:BillingReference/cac:InvoiceDocumentReference/cbc:ID)
            // if vals['supplier'].country_id.code == 'NL' and 'refund' in invoice.move_type:
            //     vals['vals'].update({
            //         'billing_reference_vals': {
            //             'id': invoice.ref,
            //             'issue_date': None,
            //         }
            //     })
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _export_invoice_vals(self, invoice):
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals.update({
            //     'main_template': 'l10n_jo_edi.ubl_jo_Invoice',
            //     'InvoiceType_template': 'l10n_jo_edi.ubl_jo_InvoiceType',
            //     'PaymentMeansType_template': 'l10n_jo_edi.ubl_jo_PaymentMeansType',
            //     'InvoiceLineType_template': 'l10n_jo_edi.ubl_jo_InvoiceLineType',
            //     'TaxTotalType_template': 'l10n_jo_edi.ubl_jo_TaxTotalType',
            // })
            // 
            // customer = invoice.partner_id
            // is_refund = invoice.move_type == 'out_refund'
            // 
            // vals['vals'].update({
            //     'ubl_version_id': '',
            //     'order_reference': '',
            //     'sales_order_id': '',
            //     'profile_id': 'reporting:1.0',
            //     'id': invoice.name.replace('/', '_'),
            //     'uuid': invoice.l10n_jo_edi_uuid,
            //     'document_currency_code': invoice.currency_id.name,
            //     'tax_currency_code': invoice.currency_id.name,
            //     'document_type_code_attrs': {'name': self._get_payment_method_code(invoice)},
            //     'document_type_code': "381" if is_refund else "388",
            //     'accounting_customer_party_vals': {
            //         'party_vals': self._get_empty_party_vals() if is_refund else self._get_partner_party_vals(customer, role='customer'),
            //         'accounting_contact': {
            //             'telephone': '' if is_refund else invoice.partner_id.phone or invoice.partner_id.mobile,
            //         },
            //     },
            //     'seller_supplier_party_vals': {
            //         'party_vals': self._get_seller_supplier_party_vals(invoice),
            //     },
            //     'billing_reference_vals': self._get_billing_reference_vals(invoice),
            //     'additional_document_reference_list': self._get_additional_document_reference_list(invoice),
            // })
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals.update({
            //     # MyInvois integration requires some template changes. All documents use the same template (Invoice)
            //     'InvoiceType_template': 'l10n_my_edi.ubl_21_InvoiceType_my',
            //     'CreditNoteType_template': 'l10n_my_edi.ubl_21_InvoiceType_my',
            //     'DebitNoteType_template': 'l10n_my_edi.ubl_21_InvoiceType_my',
            //     'main_template': 'account_edi_ubl_cii.ubl_20_Invoice',
            // 
            //     'InvoiceLineType_template': 'l10n_my_edi.ubl_20_InvoiceLineType_my',
            //     'CreditNoteLineType_template': 'l10n_my_edi.ubl_20_InvoiceLineType_my',
            //     'DebitNoteLineType_template': 'l10n_my_edi.ubl_20_InvoiceLineType_my',
            // 
            //     'DeliveryType_template': 'l10n_my_edi.ubl_20_DeliveryType_my',
            // })
            // 
            // document_type_code, original_document = self._l10n_my_edi_get_document_type_code(invoice)
            // vals['vals'].update({
            //     # These data are not in the API description and thus removed to avoid issues.
            //     'customization_id': None,
            //     'profile_id': None,
            //     'ubl_version_id': None,
            //     'due_date': None,
            //     'order_reference': None,
            //     # The current version is 1.1 (document with signature), the type code depends on the move type.
            //     'document_type_code_attrs': {'listVersionID': 1.1},
            //     'document_type_code': document_type_code,
            //     # The issue date and time must be the current time set in the UTC time zone
            //     'issue_date': datetime.now(tz=UTC).strftime("%Y-%m-%d"),
            //     'issue_time': datetime.now(tz=UTC).strftime("%H:%M:%SZ"),
            //     # Exchange rate information must be provided if applicable
            //     'tax_exchange_rate': self._l10n_my_edi_get_tax_exchange_rate(invoice),
            //     'invoice_incoterm_code': invoice.invoice_incoterm_id.code,
            //     # Depending on the move type, it will either be about exports (invoices) or imports (bills)
            //     'custom_form_reference': invoice.l10n_my_edi_custom_form_reference if document_type_code in {"11", "12", "13", "14"} else None,
            //     'export_custom_form_reference': invoice.l10n_my_edi_custom_form_reference if document_type_code in {"01", "02", "03", "04"} else None,
            // })
            // 
            // # these are optional, and since we can't have the correct one at the time of generating, we avoid adding them.
            // vals['vals'].pop('payment_means_vals_list', None)
            // 
            // # We add the company industrial classification to the supplier vals.
            // vals['vals']['accounting_supplier_party_vals']['party_vals'].update({
            //     'industry_classification_code_attrs': {'name': invoice.company_id.l10n_my_edi_industrial_classification.name},
            //     'industry_classification_code': invoice.company_id.l10n_my_edi_industrial_classification.code,
            // })
            // # We ensure that the customer does not have their ttx set (it could be on the record if they're also supplier)
            // customer_identification_vals = [
            //     vals for vals in vals['vals']['accounting_customer_party_vals']['party_vals']['party_identification_vals'] if vals.get('id_attrs', {}) != {'schemeID': 'TTX'}
            // ]
            // vals['vals']['accounting_customer_party_vals']['party_vals']['party_identification_vals'] = customer_identification_vals
            // 
            // # Debit/Credit note original invoice ref.
            // # Applies to credit notes, debit notes, refunds for both invoices and self-billed invoices.
            // # The original document is mandatory; but in some specific cases it will be empty (sending a credit note for an invoice
            // # managed outside Odoo/...)
            // if document_type_code in ('02', '03', '04', '12', '13', '14'):
            //     vals['vals'].update({
            //         'billing_reference_vals': {
            //             'id': (original_document and original_document.name) or 'NA',
            //             'uuid': (original_document and original_document.l10n_my_edi_external_uuid) or 'NA',
            //         },
            //     })
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals'].update({
            //     'customization_id': self._get_customization_ids()['efaktura_rs'],
            //     'billing_reference_vals': self._l10n_rs_get_billing_reference(invoice),
            // })
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _export_invoice_vals(self, invoice):
            // """ Override to include/update values specific to ZATCA's UBL 2.1 specs """
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals.update({
            //     'main_template': 'account_edi_ubl_cii.ubl_20_Invoice',
            //     'InvoiceType_template': 'l10n_sa_edi.ubl_21_InvoiceType_zatca',
            //     'CreditNoteType_template': 'l10n_sa_edi.ubl_21_CreditNoteType_zatca',
            //     'DebitNoteType_template': 'l10n_sa_edi.ubl_21_DebitNoteType_zatca',
            //     'InvoiceLineType_template': 'l10n_sa_edi.ubl_21_InvoiceLineType_zatca',
            //     'CreditNoteLineType_template': 'l10n_sa_edi.ubl_21_CreditNoteLineType_zatca',
            //     'DebitNoteLineType_template': 'l10n_sa_edi.ubl_21_DebitNoteLineType_zatca',
            //     'AddressType_template': 'l10n_sa_edi.ubl_21_AddressType_zatca',
            //     'PartyType_template': 'l10n_sa_edi.ubl_21_PartyType_zatca',
            //     'TaxTotalType_template': 'l10n_sa_edi.ubl_21_TaxTotalType_zatca',
            //     'PaymentMeansType_template': 'l10n_sa_edi.ubl_21_PaymentMeansType_zatca',
            // })
            // 
            // vals['vals'].update({
            //     'profile_id': 'reporting:1.0',
            //     'document_type_code_attrs': {'name': self._l10n_sa_get_invoice_transaction_code(invoice)},
            //     'document_type_code': self._l10n_sa_get_invoice_type(invoice),
            //     'tax_currency_code': invoice.company_currency_id.name,
            //     'issue_date': fields.Datetime.context_timestamp(self.with_context(tz='Asia/Riyadh'),
            //                                                     invoice.l10n_sa_confirmation_datetime),
            //     'previous_invoice_hash': self._l10n_sa_get_previous_invoice_hash(invoice),
            //     'billing_reference_vals': self._l10n_sa_get_billing_reference_vals(invoice),
            //     'tax_total_vals': self._l10n_sa_get_additional_tax_total_vals(invoice, vals),
            //     # Due date is not required for ZATCA UBL 2.1
            //     'due_date': None,
            // })
            // 
            // vals['vals']['monetary_total_vals'].update(self._l10n_sa_get_monetary_vals(invoice, vals))
            // self._l10n_sa_postprocess_line_vals(vals)
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _export_invoice_vals(self, invoice):
            // def _get_formatted_id(invoice):
            //     # For now, we assume that the sequence is going to be in the format {prefix}/{year}/{invoice_number}.
            //     # To send an invoice to Nlvera, the format needs to follow ABC2009123456789.
            //     parts = invoice.name.split('/')
            //     prefix, year, number = parts[0], parts[1], parts[2].zfill(9)
            //     return f"{prefix.upper()}{year}{number}"
            // 
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._export_invoice_vals(invoice)
            // 
            // # Check the customer status if it hasn't been done before as it's needed for profile_id
            // if invoice.partner_id.l10n_tr_nilvera_customer_status == 'not_checked':
            //     invoice.partner_id.check_nilvera_customer()
            // 
            // vals['vals'].update({
            //     'id': _get_formatted_id(invoice),
            //     'customization_id': 'TR1.2',
            //     'profile_id': 'TEMELFATURA' if invoice.partner_id.l10n_tr_nilvera_customer_status == 'einvoice' else 'EARSIVFATURA',
            //     'copy_indicator': 'false',
            //     'uuid': invoice.l10n_tr_nilvera_uuid,
            //     'document_type_code': 'SATIS' if invoice.move_type == 'out_invoice' else 'IADE',
            //     'due_date': False,
            //     'line_count_numeric': len(invoice.line_ids),
            //     'order_issue_date': invoice.invoice_date,
            //     'pricing_currency_code': invoice.currency_id.name.upper() if invoice.currency_id != invoice.company_id.currency_id else False,
            //     'currency_dp': 2,
            // })
            // # Nilvera will reject any <BuyerReference> tag, so remove it
            // if vals['vals'].get('buyer_reference'):
            //     del vals['vals']['buyer_reference']
            // 
            // vals['vals']['note_vals'].append({'note': self._l10n_tr_get_amount_integer_partn_text_note(invoice.amount_residual_signed, self.env.ref('base.TRY')), 'note_attrs': {}})
            // if vals['invoice'].currency_id.name != 'TRY':
            //     vals['vals']['note_vals'].append({'note': self._l10n_tr_get_amount_integer_partn_text_note(invoice.amount_residual, vals['invoice'].currency_id), 'note_attrs': {}})
            // return vals
            */
            return default;
        }

        public async Task<TEntity> ExtractBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _extract_base_lines(self, taxes_vals):
            // if 'base_lines' in taxes_vals:  # whole invoice
            //     return taxes_vals['base_lines']
            // elif 'base_line_x_taxes_data' in taxes_vals:  # some lines grouped by tax
            //     return [x[0] for x in taxes_vals['base_line_x_taxes_data']]
            // elif 'base_line' in taxes_vals:  # single invoice line
            //     return [taxes_vals['base_line']]
            */
            return default;
        }

        public async Task<TEntity> FormatFloatAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object precision_digits) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def format_float(self, amount, precision_digits):
            // if amount is None:
            //     return None
            // 
            // rounded_amount = float_repr(self._round_max_dp(amount), JO_MAX_DP).rstrip('0').rstrip('.')
            // decimal_places = len(rounded_amount.split('.')[1]) if '.' in rounded_amount else 0
            // if decimal_places < precision_digits:
            //     rounded_amount = float_repr(float(rounded_amount), precision_digits)
            // return rounded_amount
            */
            return default;
        }

        public async Task<TEntity> GetAdditionalDocumentReferenceListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_additional_document_reference_list(self, invoice):
            // return [{
            //     'id': 'ICV',
            //     'uuid': invoice.id,
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_additional_document_reference_list(self, invoice):
            // # EXTENDS account.edi.xml.ubl_20
            // additional_document_reference_list = super()._get_additional_document_reference_list(invoice)
            // if invoice.partner_id.l10n_tr_nilvera_customer_status == 'earchive':
            //     additional_document_reference_list.append({
            //         'id': "ELEKTRONIK",
            //         'issue_date': invoice.invoice_date,
            //         'document_type_code': "SEND_TYPE",
            //     })
            // return additional_document_reference_list
            */
            return default;
        }

        public async Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_address_node(self, vals):
            // # schematron/openpeppol/3.13.0/xslt/CEN-EN16931-UBL.xslt
            // # [UBL-CR-225]-A UBL invoice should not include the AccountingCustomerParty Party PostalAddress CountrySubentityCode
            // address_node = super()._get_address_node(vals)
            // address_node['cbc:CountrySubentityCode'] = None
            // address_node['cac:Country']['cbc:Name'] = None
            // return address_node
            */
            return default;
        }

        public async Task<TEntity> GetBillingReferenceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_billing_reference_vals(self, invoice):
            // if not invoice.reversed_entry_id:
            //     return {}
            // 
            // return {
            //     'id': (invoice.reversed_entry_id.name or '').replace('/', '_'),
            //     'uuid': invoice.reversed_entry_id.l10n_jo_edi_uuid,
            //     'document_description': self.format_float(abs(invoice.reversed_entry_id.amount_total), self._get_currency_decimal_places()),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCountryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_country_vals(self, country):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_country_vals(country)
            // 
            // vals.pop('name', None)
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_country_vals(self, country):
            // return {
            //     'identification_code': country.code,
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_country_vals(self, country):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._get_country_vals(country)
            // vals.update({
            //     'identification_code_attrs': {
            //         'listID': 'ISO3166-1',
            //         'listAgencyID': '6',
            //     },
            //     'identification_code': COUNTRY_CODE_MAP.get(country.code),
            // })
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_country_vals(self, country):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_country_vals(country)
            // vals['name'] = country.with_context(lang='tr_TR').name
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyDecimalPlacesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid currency_id) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_currency_decimal_places(self, currency_id=None):
            // # Invoices are always reported in JOD
            // return self.env.ref('base.JOD').decimal_places
            */
            return default;
        }

        public async Task<TEntity> GetCustomizationIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py) ---
            // def _get_customization_ids(self):
            // return {
            //     'ubl_bis3': 'urn:cen.eu:en16931:2017#compliant#urn:fdc:peppol.eu:2017:poacc:billing:3.0',
            //     'nlcius': 'urn:cen.eu:en16931:2017#compliant#urn:fdc:nen.nl:nlcius:v1.0',
            //     'ubl_sg': 'urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:sg:3.0',
            //     'xrechnung': 'urn:cen.eu:en16931:2017#compliant#urn:xeinkauf.de:kosit:xrechnung_3.0',
            //     'ubl_a_nz': 'urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:aunz:3.0',
            //     'pint_jp': 'urn:peppol:pint:billing-1@jp-1',
            //     'pint_sg': 'urn:peppol:pint:billing-1@sg-1',
            //     'pint_my': 'urn:peppol:pint:billing-1@my-1',
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_customization_ids(self):
            // vals = super()._get_customization_ids()
            // vals['efaktura_rs'] = 'urn:cen.eu:en16931:2017#compliant#urn:mfin.gov.rs:srbdt:2022#conformant#urn:mfin.gov.rs:srbdtext:2022'
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_delivery_vals_list(self, invoice):
            // # EXTENDS account.edi.xml.ubl_21
            // supplier = invoice.company_id.partner_id.commercial_partner_id
            // customer = invoice.partner_id
            // 
            // economic_area = self.env.ref('base.europe').country_ids.mapped('code') + ['NO']
            // intracom_delivery = (customer.country_id.code in economic_area
            //                      and supplier.country_id.code in economic_area
            //                      and supplier.country_id != customer.country_id)
            // 
            // # [BR-IC-12]-In an Invoice with a VAT breakdown (BG-23) where the VAT category code (BT-118) is
            // # "Intra-community supply" the Deliver to country code (BT-80) shall not be blank.
            // 
            // # [BR-IC-11]-In an Invoice with a VAT breakdown (BG-23) where the VAT category code (BT-118) is
            // # "Intra-community supply" the Actual delivery date (BT-72) or the Invoicing period (BG-14)
            // # shall not be blank.
            // 
            // if intracom_delivery:
            //     partner_shipping = invoice.partner_shipping_id or customer
            // 
            //     return [{
            //         'actual_delivery_date': invoice.invoice_date,
            //         'delivery_location_vals': {
            //             'delivery_address_vals': self._get_partner_address_vals(partner_shipping),
            //         },
            //     }]
            // 
            // return super()._get_delivery_vals_list(invoice)
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_delivery_vals_list(self, invoice):
            // return []
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_delivery_vals_list(self, invoice):
            // # OVERRIDE 'account_edi_ubl_cii'
            // return [{
            //     'accounting_delivery_party_vals': self._l10n_my_edi_get_delivery_party_vals(invoice.partner_id),
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_delivery_vals_list(self, invoice):
            // """ Override to include/update values specific to ZATCA's UBL 2.1 specs """
            // shipping_address = invoice.partner_shipping_id
            // return [{'actual_delivery_date': invoice.delivery_date or invoice.invoice_date,
            //          'delivery_address_vals': self._get_partner_address_vals(shipping_address) if shipping_address else {},}]
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_delivery_vals_list(self, invoice):
            // # EXTENDS account.edi.xml.ubl_21
            // delivery_vals = super()._get_delivery_vals_list(invoice)
            // if 'picking_ids' in invoice._fields and invoice.picking_ids:
            //     delivery_vals[0]['delivery_id'] = invoice.picking_ids[0].name
            //     return delivery_vals
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_document_allowance_charge_node(self, vals):
            // allowance_charge_node = super()._get_document_allowance_charge_node(vals)
            // allowance_charge_node['cbc:MultiplierFactorNumeric'] = None
            // return allowance_charge_node
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_document_allowance_charge_vals_list(self, invoice, taxes_vals):
            // """ For JO UBL the document allowance charge vals needs to be the sum of the line discounts. """
            // discount_amount = 0
            // for base_line in self._extract_base_lines(taxes_vals):
            //     discount_amount += self._get_line_discount_jod(base_line)
            // return [{
            //     'charge_indicator': 'false',
            //     'allowance_charge_reason': 'discount',
            //     'currency_name': JO_CURRENCY.name,
            //     'currency_dp': self._get_currency_decimal_places(),
            //     'amount': discount_amount,
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_document_allowance_charge_vals_list(self, invoice, taxes_vals=None):
            // """
            // Charge Reasons & Codes (As per ZATCA):
            // https://unece.org/fileadmin/DAM/trade/untdid/d16b/tred/tred5189.htm
            // As far as ZATCA is concerned, we calculate Allowance/Charge vals for global discounts as
            // a document level allowance, and we do not include any other charges or allowances
            // """
            // res = super()._get_document_allowance_charge_vals_list(invoice)
            // for line in invoice.invoice_line_ids.filtered(lambda l: l._is_global_discount_line()):
            //     taxes = line.tax_ids.flatten_taxes_hierarchy().filtered(lambda t: t.amount_type != 'fixed')
            //     customer = invoice.commercial_partner_id
            //     supplier = invoice.company_id.partner_id.commercial_partner_id
            //     res.append({
            //         'charge_indicator': 'false',
            //         'allowance_charge_reason_code': "95",
            //         'allowance_charge_reason': "Discount",
            //         'amount': abs(line.price_subtotal),
            //         'currency_dp': 2,
            //         'currency_name': invoice.currency_id.name,
            //         'tax_category_vals': [{
            //             'id': tax['id'],
            //             'percent': tax['percent'],
            //             'tax_scheme_vals': {'id': 'VAT'},
            //         } for tax in self._get_tax_category_list(customer, supplier, taxes)],
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetEmptyPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_empty_party_vals(self):
            // return {
            //     'postal_address_vals': {'country_vals': {'identification_code': 'JO'}},
            //     'party_tax_scheme_vals': [{'tax_scheme_vals': {'id': 'VAT'}}],
            // }
            */
            return default;
        }

        public async Task<TEntity> GetFinancialAccountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_financial_account_node(self, vals):
            // # schematron/openpeppol/3.13.0/xslt/CEN-EN16931-UBL.xslt
            // # [UBL-CR-664]-A UBL invoice should not include the FinancialInstitutionBranch FinancialInstitution
            // # xpath test: not(//cac:FinancialInstitution)
            // financial_account_node = super()._get_financial_account_node(vals)
            // 
            // if financial_account_node['cac:FinancialInstitutionBranch']:
            //     financial_account_node['cac:FinancialInstitutionBranch']['cac:FinancialInstitution'] = None
            // 
            // return financial_account_node
            */
            return default;
        }

        public async Task<TEntity> GetFinancialInstitutionBranchValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bank) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_financial_institution_branch_vals(self, bank):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_financial_institution_branch_vals(bank)
            // # schematron/openpeppol/3.13.0/xslt/CEN-EN16931-UBL.xslt
            // # [UBL-CR-664]-A UBL invoice should not include the FinancialInstitutionBranch FinancialInstitution
            // # xpath test: not(//cac:FinancialInstitution)
            // vals.pop('id_attrs', None)
            // vals.pop('financial_institution_vals', None)
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineAllowanceValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object tax_values_list) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_invoice_line_allowance_vals_list(self, line, tax_values_list=None):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_invoice_line_allowance_vals_list(line, tax_values_list=tax_values_list)
            // 
            // for vals in vals_list:
            //     vals['currency_dp'] = 2
            // 
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_line_allowance_vals_list(self, line, taxes_vals):
            // return [{
            //     'charge_indicator': 'false',
            //     'allowance_charge_reason': 'DISCOUNT',
            //     'currency_name': JO_CURRENCY.name,
            //     'currency_dp': self._get_currency_decimal_places(),
            //     'amount': self._get_line_discount_jod(self._extract_base_lines(taxes_vals)[0]),
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_invoice_line_allowance_vals_list(self, line, tax_values_list=None):
            // # EXTENDS account.edi.xml.ubl_20
            // vals_list = super()._get_invoice_line_allowance_vals_list(line, tax_values_list)
            // for vals in vals_list:
            //     vals.pop('allowance_charge_reason_code', None)
            //     vals['currency_dp'] = 2
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineItemValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_invoice_line_item_vals(self, line, taxes_vals):
            // # EXTENDS account.edi.xml.ubl_21
            // line_item_vals = super()._get_invoice_line_item_vals(line, taxes_vals)
            // 
            // for val in line_item_vals['classified_tax_category_vals']:
            //     # [UBL-CR-600] A UBL invoice should not include the InvoiceLine Item ClassifiedTaxCategory TaxExemptionReasonCode
            //     val.pop('tax_exemption_reason_code', None)
            //     # [UBL-CR-601] TaxExemptionReason must not appear in InvoiceLine Item ClassifiedTaxCategory
            //     # [BR-E-10] TaxExemptionReason must only appear in TaxTotal TaxSubtotal TaxCategory
            //     val.pop('tax_exemption_reason', None)
            // 
            // return line_item_vals
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_line_item_vals(self, line, taxes_vals):
            // product = line.product_id
            // description = (line.name or '').replace('\n', ', ')
            // return {
            //     'name': product.name or description,
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_invoice_line_item_vals(self, line, taxes_vals):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._get_invoice_line_item_vals(line, taxes_vals)
            // vals['commodity_classification_vals'] = [{
            //     'item_classification_code': line.product_id.product_tmpl_id.l10n_my_edi_classification_code,
            //     'item_classification_attrs': {'listID': 'CLASS'},
            // }]
            // # User the tax_details in order to fill the classified_tax_category_vals as would be expected.
            // for tax_detail in taxes_vals['tax_details']:
            //     tax_category_vals = tax_detail['_tax_category_vals_']
            //     for classified_tax_category_vals in vals['classified_tax_category_vals']:
            //         if tax_category_vals['id'] == classified_tax_category_vals['id']:
            //             classified_tax_category_vals['name'] = tax_category_vals['name']
            //             classified_tax_category_vals['tax_exemption_reason'] = tax_category_vals['tax_exemption_reason']
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_invoice_line_item_vals(self, line, taxes_vals):
            // """ Override to include/update values specific to ZATCA's UBL 2.1 specs """
            // vals = super()._get_invoice_line_item_vals(line, taxes_vals)
            // vals['sellers_item_identification_vals'] = {'id': line.product_id.code or line.product_id.default_code}
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_invoice_line_item_vals(self, line, taxes_vals):
            // # EXTENDS account.edi.xml.ubl_21
            // line_item_vals = super()._get_invoice_line_item_vals(line, taxes_vals)
            // line_item_vals['classified_tax_category_vals'] = False
            // return line_item_vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLinePriceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_line_price_vals(self, line, taxes_vals):
            // return {
            //     'currency': JO_CURRENCY,
            //     'currency_dp': self._get_currency_decimal_places(),
            //     'price_amount': self._get_line_unit_price_jod(self._extract_base_lines(taxes_vals)[0]),
            //     'product_price_dp': self._get_currency_decimal_places(),
            //     'allowance_charge_vals': self._get_invoice_line_allowance_vals_list(line, taxes_vals),
            //     'base_quantity': None,
            //     'base_quantity_attrs': {'unitCode': self._get_uom_unece_code()},
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_invoice_line_price_vals(self, line):
            // # EXTEND 'account.edi.common'
            // invoice_line_price_vals = super()._get_invoice_line_price_vals(line)
            // invoice_line_price_vals['base_quantity_attrs'] = {'unitCode': line.product_uom_id._get_unece_code()}
            // invoice_line_price_vals['currency_dp'] = 2
            // return invoice_line_price_vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_line_tax_totals_vals_list(self, line, taxes_vals):
            // # Tax unregistered companies should have no tax values
            // if line.move_id.company_id.l10n_jo_edi_taxpayer_type == 'income':
            //     return []
            // 
            // vals = self._get_invoice_tax_totals_vals_helper(taxes_vals, is_single_line=True)
            // taxable_amount = self._get_line_taxable_amount(self._extract_base_lines(taxes_vals)[0])
            // vals['rounding_amount'] = taxable_amount + vals['tax_amount']
            // for grouping_key, tax_details_vals in taxes_vals['tax_details'].items():
            //     if grouping_key['tax_amount_type'] == 'fixed':
            //         special_tax_subtotal = {
            //             'currency': JO_CURRENCY,
            //             'currency_dp': self._get_currency_decimal_places(),
            //             'taxable_amount': taxable_amount,
            //             'tax_amount': tax_details_vals['raw_tax_amount_currency'],
            //             'tax_category_vals': tax_details_vals['_tax_category_vals_'],
            //         }
            //         vals['rounding_amount'] += self._round_max_dp(tax_details_vals['raw_tax_amount_currency'])
            //         vals['tax_subtotal_vals'].insert(0, special_tax_subtotal)
            //         # Because we want the following:
            //         # 1. The special tax amount should be accounted for in the taxable amount used to calculate general tax amount.
            //         # 2. The special tax amount should not be included in the reported taxable amount of either subtotals (general or special).
            //         # We do the following in the general tax subtotal:
            //         # 1. Taxable amount is first calculated as (line taxable amount + line special tax amount)
            //         # 2. This taxable amount is used to calculate general tax amount, and is reported in the general tax subtotal itself
            //         # 3. If special tax was found on the line, the reported taxable amount in the general tax subtotal is overridden here
            //         #       to remove special tax amount from it
            //         vals['tax_subtotal_vals'][1]['taxable_amount'] = taxable_amount
            // return [vals]
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, Guid line_id, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_invoice_line_vals(self, line, line_id, taxes_vals):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_invoice_line_vals(line, line_id, taxes_vals)
            // 
            // vals.pop('tax_total_vals', None)
            // 
            // vals['currency_dp'] = 2
            // vals['price_vals']['currency_dp'] = 2
            // 
            // if line.currency_id.compare_amounts(vals['price_vals']['price_amount'], 0) == -1:
            //     # We can't have negative unit prices, so we invert the signs of
            //     # the unit price and quantity, resulting in the same amount in the end
            //     vals['price_vals']['price_amount'] *= -1
            //     vals['line_quantity'] *= -1
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_line_vals(self, line, line_id, taxes_vals):
            // return {
            //     'currency': JO_CURRENCY,
            //     'currency_dp': self._get_currency_decimal_places(),
            //     'id': self._get_line_edi_id(line, default_id=line_id + 1),
            //     'line_quantity': line.quantity,
            //     'line_quantity_attrs': {'unitCode': self._get_uom_unece_code()},
            //     'line_extension_amount': self._get_line_taxable_amount(self._extract_base_lines(taxes_vals)[0]),
            //     'tax_total_vals': self._get_invoice_line_tax_totals_vals_list(line, taxes_vals),
            //     'item_vals': self._get_invoice_line_item_vals(line, taxes_vals),
            //     'price_vals': self._get_invoice_line_price_vals(line, taxes_vals),
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_invoice_line_vals(self, line, line_id, taxes_vals):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._get_invoice_line_vals(line, line_id, taxes_vals)
            // vals['item_price_extension_amount'] = line.price_subtotal
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_invoice_line_vals(self, line, line_id, taxes_vals):
            // """ Override to include/update values specific to ZATCA's UBL 2.1 specs """
            // 
            // def grouping_key_generator(base_line, tax_data):
            //     tax = tax_data['tax']
            //     customer = line.move_id.commercial_partner_id
            //     supplier = line.move_id.company_id.partner_id.commercial_partner_id
            //     tax_category_vals = next(iter(self._get_tax_category_list(customer, supplier, tax)), {})
            //     grouping_key = {
            //         'tax_category_id': tax_category_vals.get('id'),
            //         'tax_category_percent': tax_category_vals.get('percent'),
            //         '_tax_category_vals_': tax_category_vals,
            //         'tax_amount_type': tax.amount_type,
            //     }
            //     if tax.amount_type == 'fixed':
            //         grouping_key['tax_name'] = tax.name
            //     return grouping_key
            // 
            // if not line.move_id._is_downpayment() and line._get_downpayment_lines():
            //     # When we initially calculate the taxes_vals, we filter out the down payment lines, which means we have no
            //     # values to set in the TaxableAmount and TaxAmount nodes on the InvoiceLine for the down payment.
            //     # This means ZATCA will return a warning message for the BR-KSA-80 rule since it cannot calculate the
            //     # TaxableAmount and the TaxAmount nodes correctly. To avoid this, we re-caclculate the taxes_vals just before
            //     # we set the values for the down payment line.
            //     line_taxes = line.move_id._prepare_invoice_aggregated_taxes(
            //         filter_tax_values_to_apply=lambda l, t: not t["tax"].l10n_sa_is_retention,
            //         grouping_key_generator=grouping_key_generator
            //     )
            //     taxes_vals = line_taxes['tax_details_per_record'][line]
            // 
            // line_vals = super()._get_invoice_line_vals(line, line_id, taxes_vals)
            // total_amount_sa = abs(taxes_vals['tax_amount_currency'] + taxes_vals['base_amount_currency'])
            // extension_amount = abs(line_vals['line_extension_amount'])
            // if not line.move_id._is_downpayment() and line._get_downpayment_lines():
            //     total_amount_sa = extension_amount = 0
            //     line_vals['price_vals']['price_amount'] = 0
            //     line_vals['tax_total_vals'][0]['tax_amount'] = 0
            //     line_vals['prepayment_vals'] = self._l10n_sa_get_line_prepayment_vals(line, taxes_vals)
            // else:
            //     # - BR-KSA-80: only down-payment lines should have a tax subtotal breakdown, as that is
            //     # used during computation of prepaid amount as ZATCA sums up tax amount/taxable amount of all lines
            //     # irrespective of whether they are down-payment lines.
            //     line_vals['tax_total_vals'][0].pop('tax_subtotal_vals', None)
            // line_vals['tax_total_vals'][0]['total_amount_sa'] = total_amount_sa
            // line_vals['line_quantity'] = abs(line_vals['line_quantity'])
            // line_vals['line_extension_amount'] = extension_amount
            // 
            // return line_vals
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_invoice_line_vals(self, line, line_id, taxes_vals):
            // invoice_line_vals = super()._get_invoice_line_vals(line, line_id, taxes_vals)
            // invoice_line_vals['line_quantity_attrs'] = {'unitCode': line.product_uom_id._get_unece_code()}
            // invoice_line_vals['currency_dp'] = 2
            // invoice_line_vals.pop('invoice_period_vals_list', None)
            // return invoice_line_vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals, object line_extension_amount, object allowance_total_amount, object charge_total_amount) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_monetary_total_vals(self, invoice, taxes_vals, line_extension_amount, allowance_total_amount, charge_total_amount):
            // base_lines = self._extract_base_lines(taxes_vals)
            // tax_inclusive_amount = self._sum_max_dp(self._get_line_taxable_amount(base_line) +
            //                                         self._get_line_tax_amount(base_line, 'percent') +
            //                                         self._get_line_tax_amount(base_line, 'fixed')
            //                                         for base_line in base_lines)
            // tax_exclusive_amount = self._sum_max_dp(self._get_line_unit_price_jod(base_line) * base_line['record'].quantity for base_line in base_lines)
            // return {
            //     'currency': JO_CURRENCY,
            //     'currency_dp': self._get_currency_decimal_places(),
            //     'allowance_total_amount': allowance_total_amount,
            //     'prepaid_amount': 0 if invoice._is_sales_refund() else None,
            //     'tax_inclusive_amount': tax_inclusive_amount,
            //     'payable_amount': tax_inclusive_amount,
            //     'tax_exclusive_amount': tax_exclusive_amount,
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_invoice_monetary_total_vals(self, invoice, taxes_vals, line_extension_amount, allowance_total_amount, charge_total_amount):
            // # EXTENDS account.edi.xml.ubl_20
            // vals = super()._get_invoice_monetary_total_vals(invoice, taxes_vals, line_extension_amount, allowance_total_amount, charge_total_amount)
            // # allowance_total_amount needs to have a value even if 0.0 otherwise it's blank in the Nilvera PDF.
            // vals['allowance_total_amount'] = allowance_total_amount
            // if invoice.currency_id.is_zero(vals.get('prepaid_amount', 1)):
            //     del vals['prepaid_amount']
            // vals['currency_dp'] = 2
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py) ---
            // def _get_invoice_node(self, vals):
            // document_node = super()._get_invoice_node(vals)
            // 
            // if vals['document_type'] != 'invoice':
            //     # In UBL 2.1, Delivery, PaymentMeans, PaymentTerms exist also in DebitNote and CreditNote
            //     self._add_invoice_delivery_nodes(document_node, vals)
            //     self._add_invoice_payment_means_nodes(document_node, vals)
            //     self._add_invoice_payment_terms_nodes(document_node, vals)
            // 
            // return document_node
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_invoice_payment_means_vals_list(invoice)
            // 
            // for vals in vals_list:
            //     vals.pop('payment_due_date', None)
            //     vals.pop('instruction_id', None)
            //     if vals.get('payment_id_vals'):
            //         vals['payment_id_vals'] = vals['payment_id_vals'][:1]
            // 
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // if invoice.move_type == 'out_refund':
            //     return [{
            //         'payment_means_code': 10,
            //         'payment_means_code_attrs': {'listID': "UN/ECE 4461"},
            //         'instruction_note': (invoice.ref or '').replace('/', '_'),
            //     }]
            // else:
            //     return []
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // """ Override to include/update values specific to ZATCA's UBL 2.1 specs """
            // res = super()._get_invoice_payment_means_vals_list(invoice)
            // res[0]['payment_means_code'] = PAYMENT_MEANS_CODE.get(self._l10n_sa_get_payment_means_code(invoice), PAYMENT_MEANS_CODE['unknown'])
            // res[0]['payment_means_code_attrs'] = {'listID': 'UN/ECE 4461'}
            // res[0]['adjustment_reason'] = invoice.ref
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_invoice_payment_means_vals_list(invoice)
            // for vals in vals_list:
            //     vals.pop('instruction_id', None)
            //     vals.pop('payment_id_vals', None)
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentTermsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_payment_terms_vals_list(self, invoice):
            // return []
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_invoice_payment_terms_vals_list(self, invoice):
            // """ Override to include/update values specific to ZATCA's UBL 2.1 specs """
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePeriodValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_invoice_period_vals_list(self, invoice):
            // # EXTENDS account_edi_ubl_cii
            // vals_list = super()._get_invoice_period_vals_list(invoice)
            // vals_list.append({
            //     'description_code': '0' if invoice.move_type == 'out_refund' else invoice.l10n_rs_tax_date_obligations_code,
            // })
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_invoice_period_vals_list(self, invoice):
            // if invoice.invoice_line_ids._fields.get('deferred_start_date'):
            //     # Returns the start and end date of first invoice line since it is required that all lines must have
            //     # the same start and end date.
            //     line_ids = invoice.invoice_line_ids.filtered(lambda line: line.display_type == 'product' and line.deferred_start_date)
            //     if line_ids:
            //         return [
            //             {
            //                 'start_date': line_ids[0].deferred_start_date,
            //                 'end_date': line_ids[0].deferred_end_date,
            //             },
            //         ]
            // return super()._get_invoice_period_vals_list(invoice)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTaxTotalsValsHelperInternalAsync<TEntity>(IEnumerable<TEntity> entities, object taxes_vals, object is_single_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_tax_totals_vals_helper(self, taxes_vals, is_single_line):
            // tax_totals_vals = {
            //     'currency': JO_CURRENCY,
            //     'currency_dp': self._get_currency_decimal_places(),
            //     'tax_amount': 0,
            //     'tax_subtotal_vals': [],
            // }
            // for grouping_key, vals in taxes_vals['tax_details'].items():
            //     if grouping_key['tax_amount_type'] != 'fixed':
            //         # taxable amount (on which general tax is calculated) = line taxable amount + special (fixed) tax amount
            //         taxable_amount = self._sum_max_dp(self._get_line_taxable_amount(base_line) + self._get_line_tax_amount(base_line, 'fixed')
            //                              for base_line in self._extract_base_lines(taxes_vals if is_single_line else vals))
            //         subtotal = {
            //             'currency': JO_CURRENCY,
            //             'currency_dp': self._get_currency_decimal_places(),
            //             'taxable_amount': taxable_amount,
            //             'tax_amount': self._round_max_dp(taxable_amount * vals['tax_category_percent'] / 100),
            //             'tax_category_vals': vals['_tax_category_vals_'],
            //         }
            //         tax_totals_vals['tax_subtotal_vals'].append(subtotal)
            //         tax_totals_vals['tax_amount'] += subtotal['tax_amount']
            // 
            // return tax_totals_vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_invoice_tax_totals_vals_list(self, invoice, taxes_vals):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_invoice_tax_totals_vals_list(invoice, taxes_vals)
            // 
            // for vals in vals_list:
            //     vals['currency_dp'] = 2
            //     for subtotal_vals in vals.get('tax_subtotal_vals', []):
            //         subtotal_vals.pop('percent', None)
            //         subtotal_vals['currency_dp'] = 2
            // 
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_tax_totals_vals_list(self, invoice, taxes_vals):
            // # Tax unregistered companies should have no tax values
            // if invoice.company_id.l10n_jo_edi_taxpayer_type == 'income':
            //     return []
            // 
            // vals = self._get_invoice_tax_totals_vals_helper(taxes_vals, is_single_line=False)
            // if not invoice._is_sales_refund():
            //     vals['tax_subtotal_vals'] = []
            // return [vals]
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_invoice_tax_totals_vals_list(self, invoice, taxes_vals):
            // """
            //     Override to include/update values specific to ZATCA's UBL 2.1 specs.
            //     In this case, we make sure the tax amounts are always absolute (no negative values)
            // """
            // res = [{
            //     'currency': invoice.currency_id,
            //     'currency_dp': invoice.currency_id.decimal_places,
            //     'tax_amount': abs(taxes_vals['tax_amount_currency']),
            //     'tax_subtotal_vals': [{
            //         'currency': invoice.currency_id,
            //         'currency_dp': invoice.currency_id.decimal_places,
            //         'taxable_amount': abs(vals['base_amount_currency']),
            //         'tax_amount': abs(vals['tax_amount_currency']),
            //         'percent': vals['_tax_category_vals_']['percent'],
            //         'tax_category_vals': vals['_tax_category_vals_'],
            //     } for vals in taxes_vals['tax_details'].values()],
            // }]
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_invoice_tax_totals_vals_list(self, invoice, taxes_vals):
            // # EXTENDS account.edi.xml.ubl_21
            // tax_totals_vals = super()._get_invoice_tax_totals_vals_list(invoice, taxes_vals)
            // 
            // for vals in tax_totals_vals:
            //     vals['currency_dp'] = 2
            //     for subtotal_vals in vals.get('tax_subtotal_vals', []):
            //         subtotal_vals['currency_dp'] = 2
            //         subtotal_vals.get('tax_category_vals', {})['id'] = False
            //         subtotal_vals.get('tax_category_vals', {})['percent'] = False
            // 
            // return tax_totals_vals
            */
            return default;
        }

        public async Task<TEntity> GetLineAmountBeforeDiscountJodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_line_amount_before_discount_jod(self, base_line):
            // line = base_line['record']
            // if line.discount < 100:
            //     amount_after_discount = base_line['tax_details']['raw_total_excluded_currency']
            //     return amount_after_discount / (1 - line.discount / 100)
            // else:
            //     # reported numbers won't matter if discount is 100%
            //     return line.price_unit * line.quantity
            */
            return default;
        }

        public async Task<TEntity> GetLineDiscountJodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_line_discount_jod(self, base_line):
            // line = base_line['record']
            // return self._get_line_amount_before_discount_jod(base_line) * line.discount / 100
            */
            return default;
        }

        public async Task<TEntity> GetLineEdiIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, Guid default_id) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_line_edi_id(self, line, default_id):
            // if not line.is_refund:  # in case it's invoice not credit note
            //     return default_id
            // 
            // refund_move = line.move_id
            // invoice_move = refund_move.reversed_entry_id
            // invoice_lines = invoice_move.invoice_line_ids.filtered(lambda line: line.display_type not in ('line_note', 'line_section'))
            // n = len(invoice_lines)
            // 
            // line_id = -1
            // for invoice_line_id, invoice_line in enumerate(invoice_lines, 1):
            //     if line.product_id == invoice_line.product_id \
            //             and line.name == invoice_line.name \
            //             and line.price_unit == invoice_line.price_unit \
            //             and line.discount == invoice_line.discount:
            //         line_id = invoice_line_id
            //         break
            // if line_id == -1:
            //     line_id = n + default_id
            // 
            // return line_id
            */
            return default;
        }

        public async Task<TEntity> GetLineTaxAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_line_tax_amount(self, base_line, tax_type):
            // """
            // tax_type possible values:
            // 'percent' -> general tax
            // 'fixed'   -> special tax
            // """
            // tax_data = next(filter(lambda tax_data: tax_data['tax'].amount_type == tax_type, base_line['tax_details']['taxes_data']), None)
            // if not tax_data:
            //     return 0
            // if tax_type == 'fixed':
            //     return tax_data['raw_tax_amount_currency']
            // else:
            //     # general tax amount = (taxable amount + special (fixed) tax mount) * tax percent
            //     return (self._get_line_taxable_amount(base_line) + self._get_line_tax_amount(base_line, 'fixed')) * tax_data['tax'].amount / 100
            */
            return default;
        }

        public async Task<TEntity> GetLineTaxableAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_line_taxable_amount(self, base_line):
            // line = base_line['record']
            // return self._get_line_unit_price_jod(base_line) * line.quantity - self._get_line_discount_jod(base_line)
            */
            return default;
        }

        public async Task<TEntity> GetLineUnitPriceJodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_line_unit_price_jod(self, base_line):
            // line = base_line['record']
            // return self._get_line_amount_before_discount_jod(base_line) / line.quantity
            */
            return default;
        }

        public async Task<TEntity> GetPartnerAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_partner_address_vals(self, partner):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_partner_address_vals(partner)
            // # schematron/openpeppol/3.13.0/xslt/CEN-EN16931-UBL.xslt
            // # [UBL-CR-225]-A UBL invoice should not include the AccountingCustomerParty Party PostalAddress CountrySubentityCode
            // vals.pop('country_subentity_code', None)
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_address_vals(self, partner):
            // return {
            //     'postal_zone': partner.zip,
            //     'country_subentity_code': partner.state_id.code,
            //     'country_vals': self._get_country_vals(partner.country_id),
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_partner_address_vals(self, partner):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._get_partner_address_vals(partner)
            // # We do not want to display the streets, but instead use the AddressLine element.
            // vals.pop('street_name', None)
            // vals.pop('additional_street_name', None)
            // 
            // # The API expects the iso3166-2 code for the state, in the same way as it expects the iso3166 code for the countries.
            // # In Odoo, we mostly use these (although there is no standard format) so we'll try to use what Odoo gives us.
            // # For malaysia, the codes where updated, but we use a mapping to ensure that outdated data will still end up correct.
            // subentity_code = partner.state_id.code or ''
            // 
            // if partner.country_id.code == 'MY' and partner.state_id.code in MALAYSIAN_SUBDIVISION_CODES:
            //     subentity_code = MALAYSIAN_SUBDIVISION_CODES[partner.state_id.code]
            // 
            // # The API does not expect the country code inside the state code, only the number part.
            // if f'{partner.country_id.code}-' in subentity_code:
            //     subentity_code = subentity_code.split('-')[1]
            // 
            // vals.update({
            //     'address_lines': [partner.street or '', partner.street2 or ''],
            //     'country_subentity_code': subentity_code,
            // })
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_partner_address_vals(self, partner):
            // """ Override to include/update values specific to ZATCA's UBL 2.1 specs """
            // return {
            //     **super()._get_partner_address_vals(partner),
            //     'building_number': partner.l10n_sa_edi_building_number,
            //     'city_subdivision_name ': partner.street2,
            //     'plot_identification': partner.l10n_sa_edi_plot_identification,
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_partner_address_vals(self, partner):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_partner_address_vals(partner)
            // vals.update({
            //     'city_subdivision_name ': partner.city,
            //     'city_name': partner.state_id.name,
            //     'country_subentity': False,
            //     'country_subentity_code': False,
            // })
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetPartnerContactValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_partner_contact_vals(self, partner):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_partner_contact_vals(partner)
            // 
            // vals.pop('id', None)
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_contact_vals(self, partner):
            // return {}
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_partner_contact_vals(self, partner):
            // # EXTENDS 'account_edi_ubl_cii'
            // res = super()._get_partner_contact_vals(partner)
            // res['telephone'] = self._l10n_my_edi_get_formatted_phone_number(res['telephone'])
            // return res
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_partner_contact_vals(self, partner):
            // res = super()._get_partner_contact_vals(partner)
            // if res.get('telephone'):
            //     res['telephone'] = re.sub(r"[^+\d]", '', res['telephone'])
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyIdentificationValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_partner_party_identification_vals_list(self, partner):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_partner_party_identification_vals_list(partner)
            // 
            // if partner.country_code == 'NL':
            //     vals.append({
            //         'id': partner.peppol_endpoint,
            //     })
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_party_identification_vals_list(self, partner):
            // return [{
            //     'id_attrs': {'schemeID': 'TN' if partner.country_code == 'JO' else 'PN'},
            //     'id': partner.vat if partner.vat and partner.vat != '/' else 'NO_VAT',
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_partner_party_identification_vals_list(self, partner):
            // """ The id vals list must be filled with two values.
            // The TIN, and then one of either:
            //     - Business registration number (BNR)
            //     - MyKad/MyTentera identification number (NRIC)
            //     - Passport number or MyPR/MyKAS identification number (PASSPORT)
            //     - (ARMY)
            // Additionally, companies registered to use SST (sales & services tax) must provide their SST number.
            // Finally, if a supplier is using TTX (tourism tax), once again that number must be provided.
            // """
            // # OVERRIDE 'account_edi_ubl_cii'
            // vals = [{
            //     'id_attrs': {'schemeID': 'TIN'},
            //     'id': partner._l10n_my_edi_get_tin_for_myinvois(),
            // }]
            // 
            // if partner.l10n_my_identification_type and partner.l10n_my_identification_number:
            //     vals.append({
            //         'id_attrs': {'schemeID': partner.l10n_my_identification_type},
            //         'id': partner.l10n_my_identification_number,
            //     })
            //     if partner.sst_registration_number:
            //         # The supplier can input up to 2 SST numbers, in which case they need to separate both by a ;
            //         # They can do so in the existing field if they want.
            //         vals.append({
            //             'id_attrs': {'schemeID': 'SST'},
            //             'id': partner.sst_registration_number,
            //         })
            //     if partner.ttx_registration_number:
            //         vals.append({
            //             'id_attrs': {'schemeID': 'TTX'},
            //             'id': partner.ttx_registration_number,
            //         })
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_partner_party_identification_vals_list(self, partner):
            // vals_list = super()._get_partner_party_identification_vals_list(partner)
            // if partner.country_code == 'RS' and partner.l10n_rs_edi_public_funds:
            //     vals_list.append({
            //         'id': f'JBKJS: {partner.l10n_rs_edi_public_funds}',
            //     })
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_partner_party_identification_vals_list(self, partner):
            // """ Override to include/update values specific to ZATCA's UBL 2.1 specs """
            // return [{
            //     'id_attrs': {'schemeID': partner.l10n_sa_additional_identification_scheme},
            //     'id': (
            //         partner.l10n_sa_additional_identification_number
            //         if partner.l10n_sa_additional_identification_scheme != 'TIN' and partner.country_code == 'SA'
            //         else partner.vat
            //     ),
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_partner_party_identification_vals_list(self, partner):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_partner_party_identification_vals_list(partner)
            // # Nilvera will reject any <ID> without a <schemeID>, so remove all items not
            // # having the following structure : {'id': '...', 'id_attrs': {'schemeID': '...'}}
            // vals = [v for v in vals if v.get('id') and v.get('id_attrs', {}).get('schemeID')]
            // vals.append({
            //     'id_attrs': {
            //         'schemeID': 'VKN' if partner.is_company else 'TCKN',
            //     },
            //     'id': partner.vat,
            // })
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_partner_party_legal_entity_vals_list(partner)
            // 
            // for vals in vals_list:
            //     vals.pop('registration_address_vals', None)
            //     if partner.country_code == 'NL':
            //         # For NL, VAT can be used as a Peppol endpoint, but KVK/OIN has to be used as PartyLegalEntity/CompanyID
            //         # To implement a workaround on stable, company_registry field is used without recording whether
            //         # the number is a KVK or OIN, and the length of the number (8 = KVK, 9 = OIN) is used to determine the type
            //         nl_id = partner.company_registry if partner.peppol_eas not in ('0106', '0190') else partner.peppol_endpoint
            //         vals.update({
            //             'company_id': nl_id,
            //             'company_id_attrs': {'schemeID': '0190' if nl_id and len(nl_id) == 9 else '0106'},
            //         })
            //     if partner.country_id.code == "LU":
            //         if 'l10n_lu_peppol_identifier' in partner._fields and partner.l10n_lu_peppol_identifier:
            //             vals['company_id'] = partner.l10n_lu_peppol_identifier
            //         elif partner.company_registry:
            //             vals['company_id'] = partner.company_registry
            //     if partner.country_id.code == 'DK':
            //         # DK-R-014: For Danish Suppliers it is mandatory to specify schemeID as "0184" (DK CVR-number) when
            //         # PartyLegalEntity/CompanyID is used for AccountingSupplierParty
            //         vals['company_id_attrs'] = {'schemeID': '0184'}
            //     if partner.country_code == 'SE' and partner.company_registry:
            //         vals['company_id'] = ''.join(char for char in partner.company_registry if char.isdigit())
            //     if not vals['company_id']:
            //         vals['company_id'] = partner.peppol_endpoint
            // 
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // return [{
            //     'registration_name': partner.name,
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # OVERRIDE 'account_edi_ubl_cii'
            // # We only want to display the registration name here.
            // return [{
            //     'registration_name': partner.name,
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals_list = super()._get_partner_party_legal_entity_vals_list(partner)
            // for vals in vals_list:
            //     vals['company_id'] = partner.l10n_rs_edi_registration_number
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # EXTEND 'account.edi.xml.ubl_20'
            // partners_party_legal = super()._get_partner_party_legal_entity_vals_list(partner)
            // for partner_party_legal in partners_party_legal:
            //     if partner_party_legal['commercial_partner'].country_code != 'SA':
            //         partner_party_legal['company_id'] = False
            // 
            // return partners_party_legal
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_partner_party_legal_entity_vals_list(partner)
            // for vals in vals_list:
            //     vals.pop('registration_address_vals', None)
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_partner_party_tax_scheme_vals_list(partner, role)
            // 
            // if not partner.vat:
            //     return [{
            //         'company_id': partner.peppol_endpoint,
            //         'tax_scheme_vals': {'id': partner.peppol_eas},
            //     }]
            // 
            // for vals in vals_list:
            //     vals.pop('registration_name', None)
            //     vals.pop('registration_address_vals', None)
            // 
            // # sources:
            // #  https://anskaffelser.dev/postaward/g3/spec/current/billing-3.0/norway/#_applying_foretaksregisteret
            // #  https://docs.peppol.eu/poacc/billing/3.0/bis/#national_rules (NO-R-002 (warning))
            // if partner.country_id.code == "NO" and role == 'supplier':
            //     vals_list.append({
            //         'company_id': "Foretaksregisteret",
            //         'tax_scheme_vals': {'id': 'TAX'},
            //     })
            // 
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // return [{
            //     'company_id': partner.vat,
            //     'tax_scheme_vals': {'id': 'VAT'},
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // """ This information is not needed. Instead, the party identification vals must be filled. """
            // # OVERRIDE 'account_edi_ubl_cii'
            // return []
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals_list = super()._get_partner_party_tax_scheme_vals_list(partner, role)
            // 
            // for vals in vals_list:
            //     vat_country, vat_number = partner._split_vat(partner.vat)
            //     if vat_country.isnumeric():
            //         vat_country = 'RS'
            //         vat_number = partner.vat
            //     if vat_country == 'RS' and partner.simple_vat_check(vat_country, vat_number):
            //         vals['company_id'] = vat_country + vat_number
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // """
            //     Override to return an empty list if the partner is a customer and their country is not KSA.
            //     This is according to KSA Business Rule BR-KSA-46 which states that in the case of Export Invoices,
            //     the buyer VAT registration number or buyer group VAT registration number must not exist in the Invoice
            // """
            // if role != 'customer' or partner.country_id.code == 'SA':
            //     vals_list = super()._get_partner_party_tax_scheme_vals_list(partner, role)
            //     for vals in vals_list:
            //         vals['tax_scheme_vals'] = {'id': 'VAT'}
            //     return vals_list
            // return []
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_partner_party_tax_scheme_vals_list(partner, role)
            // for vals in vals_list:
            //     vals.pop('registration_address_vals', None)
            //     vals["tax_scheme_vals"].update(
            //         {
            //             "id": "",
            //             "name": partner.ref,
            //         }
            //     )
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._get_partner_party_vals(partner, role)
            // 
            // partner = partner.commercial_partner_id
            // vals.update({
            //     'endpoint_id': partner.peppol_endpoint,
            //     'endpoint_id_attrs': {'schemeID': partner.peppol_eas},
            // })
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // vals = super()._get_partner_party_vals(partner, role)
            // vals['party_name_vals'] = []
            // if role == 'supplier':
            //     vals['party_identification_vals'] = []
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // vals = super()._get_partner_party_vals(partner, role)
            // vat_country, vat_number = partner._split_vat(partner.vat)
            // if vat_country.isnumeric():
            //     vat_number = partner.vat
            // vals.update({
            //     'endpoint_id': vat_number,
            //     'endpoint_id_attrs': {
            //         'schemeID': '9948',
            //     },
            // })
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPersonValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_partner_person_vals(self, partner):
            // if not partner.is_company:
            //     name_parts = partner.name.split(' ', 1)
            //     return {
            //         'first_name': name_parts[0],
            //         # If no family name is present, use a zero-width space (U+200B) to ensure the XML tag is rendered. This is required by Nilvera.
            //         'family_name': name_parts[1] if len(name_parts) > 1 else '\u200B',
            //     }
            // return super()._get_partner_person_vals(partner)
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_party_node(self, vals):
            // party_node = super()._get_party_node(vals)
            // 
            // partner = vals['partner']
            // role = vals['role']
            // commercial_partner = partner.commercial_partner_id
            // 
            // if commercial_partner.peppol_endpoint:
            //     party_node['cbc:EndpointID'] = {
            //         '_text': commercial_partner.peppol_endpoint,
            //         'schemeID': commercial_partner.peppol_eas
            //     }
            // 
            // if commercial_partner.country_code == 'NL':
            //     party_node['cac:PartyIdentification'] = [
            //         party_node['cac:PartyIdentification'],
            //         {
            //             'cbc:ID': {'_text': commercial_partner.peppol_endpoint}
            //         }
            //     ]
            // 
            // party_node['cac:PartyTaxScheme'] = party_tax_scheme = [
            //     {
            //         'cbc:CompanyID': {'_text': commercial_partner.vat or commercial_partner.peppol_endpoint},
            //         'cac:TaxScheme': {
            //             # [BR-CO-09] if the PartyTaxScheme/TaxScheme/ID == 'VAT', CompanyID must start with a country code prefix.
            //             # In some countries however, the CompanyID can be with or without country code prefix and still be perfectly
            //             # valid (RO, HU, non-EU countries).
            //             # We have to handle their cases by changing the TaxScheme/ID to 'something other than VAT',
            //             # preventing the trigger of the rule.
            //             'cbc:ID': {'_text': (
            //                 'NOT_EU_VAT' if commercial_partner.country_id and commercial_partner.vat and not commercial_partner.vat[:2].isalpha()
            //                 else 'VAT' if commercial_partner.vat
            //                 else commercial_partner.peppol_eas
            //             )},
            //         },
            //     }
            // ]
            // if partner.country_id.code == "NO" and role == 'supplier':
            //     party_tax_scheme.append({
            //         'cbc:CompanyID': {'_text': "Foretaksregisteret"},
            //         'cac:TaxScheme': {'cbc:ID': {'_text': 'TAX'}},
            //     })
            // 
            // if commercial_partner.country_code == 'NL':
            //     # For NL, VAT can be used as a Peppol endpoint, but KVK/OIN has to be used as PartyLegalEntity/CompanyID
            //     # To implement a workaround on stable, company_registry field is used without recording whether
            //     # the number is a KVK or OIN, and the length of the number (8 = KVK, 9 = OIN) is used to determine the type
            //     nl_id = commercial_partner.company_registry if commercial_partner.peppol_eas not in ('0106', '0190') else commercial_partner.peppol_endpoint
            //     party_node['cac:PartyLegalEntity']['cbc:CompanyID'] = {
            //         '_text': nl_id,
            //         'schemeID': '0190' if nl_id and len(nl_id) == 9 else '0106'
            //     }
            // elif commercial_partner.country_id.code == 'LU' and commercial_partner.company_registry:
            //     party_node['cac:PartyLegalEntity']['cbc:CompanyID'] = {
            //         '_text': commercial_partner.company_registry
            //     }
            // elif commercial_partner.country_code == 'SE' and commercial_partner.company_registry:
            //     party_node['cac:PartyLegalEntity']['cbc:CompanyID'] = {
            //         '_text': ''.join(char for char in commercial_partner.company_registry if char.isdigit
            //         ())
            //     }
            // else:
            //     party_node['cac:PartyLegalEntity']['cbc:CompanyID'] = {
            //         '_text': commercial_partner.vat or commercial_partner.peppol_endpoint,
            //         # DK-R-014: For Danish Suppliers it is mandatory to specify schemeID as "0184" (DK CVR-number) when
            //         # PartyLegalEntity/CompanyID is used for AccountingSupplierParty
            //         'schemeID': '0184' if commercial_partner.country_id.code == 'DK' else None
            //     }
            // 
            // party_node['cac:PartyLegalEntity']['cac:RegistrationAddress'] = None
            // 
            // party_node['cac:Contact']['cbc:ID'] = None
            // return party_node
            */
            return default;
        }

        public async Task<TEntity> GetPaymentMethodCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_payment_method_code(self, invoice):
            // return invoice._get_invoice_scope_code() + invoice._get_invoice_payment_method_code() + invoice._get_invoice_tax_payer_type_code()
            */
            return default;
        }

        public async Task<TEntity> GetPricingExchangeRateValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_pricing_exchange_rate_vals_list(self, invoice):
            // # EXTENDS 'account.edi.xml.ubl_20'
            // if invoice.currency_id != invoice.company_id.currency_id:
            //     return [{
            //         'source_currency_code': invoice.currency_id.name.upper(),
            //         'target_currency_code': invoice.company_id.currency_id.name.upper(),
            //         'calculation_rate': round(invoice.currency_id._get_conversion_rate(invoice.currency_id, invoice.company_id.currency_id, invoice.company_id, invoice.invoice_date), 6),
            //         'date': invoice.invoice_date,
            //     }]
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetSellerSupplierPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_seller_supplier_party_vals(self, invoice):
            // return {
            //     'party_identification_vals': [{'id': invoice.company_id.l10n_jo_edi_sequence_income_source}],
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // 
            // for vals in vals_list:
            //     vals.pop('name', None)
            // 
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_tax_category_list(self, customer, supplier, tax):
            // def get_tax_jo_ubl_code(tax):
            //     if tax._l10n_jo_is_exempt_tax():
            //         return "Z"
            //     if tax.amount:
            //         return "S"
            //     return "O"
            // 
            // def get_jo_tax_type(tax):
            //     if tax.amount_type == 'percent':
            //         return 'general'
            //     elif tax.amount_type == 'fixed':
            //         return 'special'
            // 
            // tax_type = get_jo_tax_type(tax)
            // tax_code = get_tax_jo_ubl_code(tax)
            // return [{
            //     'id': tax_code,
            //     'id_attrs': {'schemeAgencyID': '6', 'schemeID': 'UN/ECE 5305'},
            //     'percent': tax.amount if tax_type == 'general' else '',
            //     'tax_scheme_vals': {
            //         'id': 'VAT' if tax_type == 'general' else 'OTH',
            //         'id_attrs': {
            //             'schemeAgencyID': '6',
            //             'schemeID': 'UN/ECE 5153',
            //         },
            //     },
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // 
            // for vals in vals_list:
            //     vals['tax_scheme_vals']['id'] = 'OTH'
            //     vals['tax_scheme_vals']['id_attrs'] = {'schemeID': 'UN/ECE 5153', 'schemeAgencyID': '6'}
            // 
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // """ Override to filter out withholding taxes """
            // non_retention_taxes = taxes.filtered(lambda t: not t.l10n_sa_is_retention)
            // return super()._get_tax_category_list(customer, supplier, non_retention_taxes)
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # OVERRIDES account.edi.common
            // res = []
            // for tax in taxes:
            //     is_withholding = tax.amount < 0
            //     tax_type_code = '9015' if is_withholding else '0015'
            //     tax_scheme_name = 'KDV Tevkifatı' if is_withholding else 'Gerçek Usulde KDV'
            //     res.append({
            //         'id': tax_type_code,
            //         'percent': tax.amount if tax.amount_type == 'percent' else False,
            //         'tax_scheme_vals': {'name': tax_scheme_name, 'tax_type_code': tax_type_code},
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_tax_category_node(self, vals):
            // grouping_key = vals['grouping_key']
            // return {
            //     'cbc:ID': {'_text': grouping_key['tax_category_code']},
            //     'cbc:Percent': {'_text': grouping_key['amount']},
            //     'cbc:TaxExemptionReasonCode': {'_text': grouping_key.get('tax_exemption_reason_code')},
            //     'cbc:TaxExemptionReason': {'_text': grouping_key.get('tax_exemption_reason')},
            //     'cac:TaxScheme': {
            //         'cbc:ID': {'_text': 'VAT'}
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_tax_grouping_key(self, base_line, tax_data):
            // # EXTENDS 'account_edi_ubl_cii'
            // grouping_key = super()._get_tax_grouping_key(base_line, tax_data)
            // # Add the tax exemption here as well to ensure consistency.
            // tax = tax_data['tax']
            // invoice = base_line['record'].move_id
            // grouping_key['_tax_category_vals_']['name'] = invoice.l10n_my_edi_exemption_reason if tax.l10n_my_tax_type == 'E' else None
            // grouping_key['_tax_category_vals_']['tax_exemption_reason'] = invoice.l10n_my_edi_exemption_reason if tax.l10n_my_tax_type == 'E' else None
            // return grouping_key
            */
            return default;
        }

        public async Task<TEntity> GetTaxSubtotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_tax_subtotal_node(self, vals):
            // # Compute total tax amount
            // tax_subtotal_node = super()._get_tax_subtotal_node(vals)
            // tax_subtotal_node['cbc:Percent'] = None
            // return tax_subtotal_node
            */
            return default;
        }

        public async Task<TEntity> GetTaxUneceCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_tax_unece_codes(self, customer, supplier, tax):
            // # OVERRIDE 'account_edi_ubl_cii'
            // return {
            //     'tax_category_code': tax.l10n_my_tax_type,
            //     'tax_exemption_reason_code': None,  # Unused in this file.
            //     'tax_exemption_reason': None,  # Should be set here but we no longer have access to the invoice info...
            // }
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _get_tax_unece_codes(self, customer, supplier, tax):
            // """ Override to include/update values specific to ZATCA's UBL 2.1 specs """
            // 
            // def _exemption_reason(code, reason):
            //     return {
            //         'tax_category_code': code,
            //         'tax_exemption_reason_code': reason or "VATEX-SA-OOS",
            //         'tax_exemption_reason': (
            //             exemption_codes[reason].split(reason)[1].lstrip()
            //             if reason else "Not subject to VAT"
            //         )
            //     }
            // 
            // if supplier.country_id.code == 'SA':
            //     if not tax or tax.amount == 0:
            //         exemption_codes = dict(tax._fields["l10n_sa_exemption_reason_code"]._description_selection(self.env))
            //         if tax.l10n_sa_exemption_reason_code in TAX_EXEMPTION_CODES:
            //             return _exemption_reason('E', tax.l10n_sa_exemption_reason_code)
            //         elif tax.l10n_sa_exemption_reason_code in TAX_ZERO_RATE_CODES:
            //             return _exemption_reason('Z', tax.l10n_sa_exemption_reason_code)
            //         else:
            //             return _exemption_reason('O', tax.l10n_sa_exemption_reason_code)
            //     else:
            //         return {
            //             'tax_category_code': 'S',
            //             'tax_exemption_reason_code': None,
            //             'tax_exemption_reason': None,
            //         }
            // return super()._get_tax_unece_codes(customer, supplier, tax)
            */
            return default;
        }

        public async Task<TEntity> GetUomUneceCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_uom_unece_code(self, line=None):
            // return "PCE"
            */
            return default;
        }

        public async Task<TEntity> ImportFillInvoiceFormInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _import_fill_invoice_form(self, invoice, tree, qty_factor):
            // # EXTENDS 'account_edi_ubl_cii'
            // logs = super()._import_fill_invoice_form(invoice, tree, qty_factor)
            // # We get the incoterm
            // incoterm_code = self._find_value('./cac:AdditionalDocumentReference[not(descendant::cbc:DocumentType)]/cbc:ID', tree)
            // if incoterm_code is not None:
            //     invoice.invoice_incoterm_id = self.env['account.incoterms'].search([('code', '=', incoterm_code)], limit=1)
            // custom_form_ref = self._find_value('./cac:AdditionalDocumentReference[descendant::cbc:DocumentType[text()="CustomsImportForm"]]/cbc:ID', tree)
            // invoice.l10n_my_edi_custom_form_reference = custom_form_ref
            // 
            // # So that we can find the original invoice in case of debit/credit note.
            // invoice_type = self._find_value('./cbc:InvoiceTypeCode', tree)
            // origin_uuid = self._find_value('.//cac:InvoiceDocumentReference[descendant::cbc:ID[text()="Document Internal ID"]]/cbc:UUID', tree)
            // if invoice_type == '02':
            //     invoice.reversed_entry_id = self.env['account.move'].search([('l10n_my_edi_external_uuid', '=', origin_uuid)], limit=1)
            // elif invoice_type == '03' and 'debit_origin_id' in self.env['account.move']._fields:
            //     invoice.debit_origin_id = self.env['account.move'].search([('l10n_my_edi_external_uuid', '=', origin_uuid)], limit=1)
            // return logs
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _import_fill_invoice_form(self, invoice, tree, qty_factor):
            // # EXTENDS account.edi.xml.ubl_20
            // logs = super()._import_fill_invoice_form(invoice, tree, qty_factor)
            // 
            // # ==== Nilvera UUID ====
            // if uuid_node := tree.findtext('./{*}UUID'):
            //     invoice.l10n_tr_nilvera_uuid = uuid_node
            // 
            // return logs
            */
            return default;
        }

        public async Task<TEntity> ImportRetrieveAndFillPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object name, object phone, object mail, object vat, object country_code, object id_type, object id_val, object sst, object ttx) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _import_retrieve_and_fill_partner(self, invoice, name, phone, mail, vat, country_code, id_type, id_val, sst=False, ttx=False):
            // """ In addition to the basic values, we need to fill the identifiers of the partner and eventual tax codes. """
            // # OVERRIDE 'account_edi_ubl_cii'
            // 
            // # I consider that the standard _retrieve_partner should be enough to match.
            // invoice.partner_id = self.env['res.partner'].with_company(invoice.company_id)._retrieve_partner(name=name, phone=phone, mail=mail, vat=vat)
            // 
            // if not invoice.partner_id and name and vat:
            //     partner_vals = {
            //         'name': name,
            //         'email': mail,
            //         'phone': phone,
            //         'sst_registration_number': sst,
            //         'ttx_registration_number': ttx,
            //         'l10n_my_identification_type': id_type,
            //         'l10n_my_identification_number': id_val,
            //     }
            //     country = self.env.ref(f'base.{country_code.lower()}', raise_if_not_found=False)
            //     if country:
            //         partner_vals['country_id'] = country.id
            //     invoice.partner_id = self.env['res.partner'].create(partner_vals)
            //     if vat and self.env['res.partner']._run_vat_test(vat, country, invoice.partner_id.is_company):
            //         invoice.partner_id.vat = vat
            */
            return default;
        }

        public async Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _import_retrieve_partner_vals(self, tree, role):
            // # EXTENDS account.edi.xml.ubl_20
            // partner_vals = super()._import_retrieve_partner_vals(tree, role)
            // endpoint_node = tree.find(f'.//cac:{role}Party/cac:Party/cbc:EndpointID', UBL_NAMESPACES)
            // if endpoint_node is not None:
            //     peppol_eas = endpoint_node.attrib.get('schemeID')
            //     peppol_endpoint = endpoint_node.text
            //     if peppol_eas and peppol_endpoint:
            //         # include the EAS and endpoint in the search domain when retrieving the partner
            //         partner_vals.update({
            //             'peppol_eas': peppol_eas,
            //             'peppol_endpoint': peppol_endpoint,
            //         })
            // return partner_vals
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _import_retrieve_partner_vals(self, tree, role):
            // """ Returns a dict of values that will be used to retrieve the partner """
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._import_retrieve_partner_vals(tree, role)
            // # We invert the country map to get the country code.
            // country_map = {v: k for k, v in COUNTRY_CODE_MAP.items()}
            // # We can't use _find_value for the identifier since we need to get the attribute.
            // vals.update({
            //     # Update some values to be correct.
            //     'vat': self._find_value(f'.//cac:Accounting{role}Party/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID="TIN"]', tree),
            //     'country_code': country_map.get(self._find_value(f'.//cac:Accounting{role}Party/cac:Party//cac:Country//cbc:IdentificationCode', tree)),
            //     'name': self._find_value(f'.//cac:Accounting{role}Party/cac:Party//cbc:RegistrationName', tree),
            //     # And add new ones that are expected.
            //     'sst': self._find_value(f'.//cac:Accounting{role}Party/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID="SST"]', tree),
            //     'ttx': self._find_value(f'.//cac:Accounting{role}Party/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID="TTX"]', tree),
            // })
            // 
            // identifier = tree.xpath(f'.//cac:Accounting{role}Party/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID="NRIC" or @schemeID="PASSPORT" or @schemeID="BRN" or @schemeID="ARMY"]', namespaces=UBL_NAMESPACES)
            // if identifier:  # Technically it's required, but to be safe...
            //     vals.update({
            //         'id_type': identifier[0].attrib['schemeID'],
            //         'id_val': identifier[0].text,
            //     })
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _import_retrieve_partner_vals(self, tree, role):
            // # EXTENDS account.edi.xml.ubl_20
            // partner_vals = super()._import_retrieve_partner_vals(tree, role)
            // partner_vals.update({
            //     'vat': self._find_value(f'.//cac:Accounting{role}Party/cac:Party//cac:PartyIdentification//cbc:ID[string-length(text()) > 5]', tree),
            // })
            // return partner_vals
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsCenEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _invoice_constraints_cen_en16931_ubl(self, invoice, vals):
            // """
            // corresponds to the errors raised by ' schematron/openpeppol/3.13.0/xslt/CEN-EN16931-UBL.xslt' for invoices.
            // This xslt was obtained by transforming the corresponding sch
            // https://docs.peppol.eu/poacc/billing/3.0/files/CEN-EN16931-UBL.sch.
            // """
            // eu_countries = self.env.ref('base.europe').country_ids
            // intracom_delivery = (vals['customer'].country_id in eu_countries
            //                      and vals['supplier'].country_id in eu_countries
            //                      and vals['customer'].country_id != vals['supplier'].country_id)
            // 
            // constraints = {
            //     # [BR-61]-If the Payment means type code (BT-81) means SEPA credit transfer, Local credit transfer or
            //     # Non-SEPA international credit transfer, the Payment account identifier (BT-84) shall be present.
            //     # note: Payment account identifier is <cac:PayeeFinancialAccount>
            //     # note: no need to check account_number, because it's a required field for a partner_bank
            //     'cen_en16931_payment_account_identifier': self._check_required_fields(
            //         invoice, 'partner_bank_id'
            //     ) if vals['vals']['payment_means_vals_list'][0]['payment_means_code'] in (30, 58) else None,
            //     # [BR-IC-12]-In an Invoice with a VAT breakdown (BG-23) where the VAT category code (BT-118) is
            //     # "Intra-community supply" the Deliver to country code (BT-80) shall not be blank.
            //     'cen_en16931_delivery_country_code': self._check_required_fields(
            //         vals['vals']['delivery_vals_list'][0], 'delivery_location_vals',
            //         _("For intracommunity supply, the delivery address should be included.")
            //     ) if intracom_delivery else None,
            // 
            //     # [BR-IC-11]-In an Invoice with a VAT breakdown (BG-23) where the VAT category code (BT-118) is
            //     # "Intra-community supply" the Actual delivery date (BT-72) or the Invoicing period (BG-14)
            //     # shall not be blank.
            //     'cen_en16931_delivery_date_invoicing_period': self._check_required_fields(
            //         vals['vals']['delivery_vals_list'][0], 'actual_delivery_date',
            //         _("For intracommunity supply, the actual delivery date or the invoicing period should be included.")
            //     ) and self._check_required_fields(
            //         vals['vals']['invoice_period_vals_list'][0], ['start_date', 'end_date'],
            //         _("For intracommunity supply, the actual delivery date or the invoicing period should be included.")
            //     ) if intracom_delivery else None,
            // }
            // 
            // for line_vals in vals['vals']['line_vals']:
            //     if not line_vals['item_vals'].get('name'):
            //         # [BR-25]-Each Invoice line (BG-25) shall contain the Item name (BT-153).
            //         constraints.update({'cen_en16931_item_name': _("Each invoice line should have a product or a label.")})
            //         break
            // 
            // for line in invoice.invoice_line_ids.filtered(lambda x: x.display_type not in ('line_note', 'line_section')):
            //     if len(line.tax_ids.flatten_taxes_hierarchy().filtered(lambda t: t.amount_type != 'fixed')) != 1:
            //         # [UBL-SR-48]-Invoice lines shall have one and only one classified tax category.
            //         # /!\ exception: possible to have any number of ecotaxes (fixed tax) with a regular percentage tax
            //         constraints.update({'cen_en16931_tax_line': _("Each invoice line shall have one and only one tax.")})
            // 
            // for role in ('supplier', 'customer'):
            //     constraints[f'cen_en16931_{role}_country'] = self._check_required_fields(
            //         vals['vals'][f'accounting_{role}_party_vals']['party_vals']['postal_address_vals']['country_vals'],
            //         'identification_code',
            //         _("The country is required for the %s.", role)
            //     )
            //     scheme_vals = vals['vals'][f'accounting_{role}_party_vals']['party_vals']['party_tax_scheme_vals'][-1:]
            //     if (
            //         not (scheme_vals and scheme_vals[0]['company_id'] and scheme_vals[0]['company_id'][:2].isalpha())
            //         and (scheme_vals and scheme_vals[0]['tax_scheme_vals'].get('id') == 'VAT')
            //         and self._name in ('account.edi.xml.ubl_bis3', 'account.edi.xml.ubl_nl', 'account.edi.xml.ubl_de')
            //     ):
            //         # [BR-CO-09]-The Seller VAT identifier (BT-31), the Seller tax representative VAT identifier (BT-63)
            //         # and the Buyer VAT identifier (BT-48) shall have a prefix in accordance with ISO code ISO 3166-1
            //         # alpha-2 by which the country of issue may be identified. Nevertheless, Greece may use the prefix ‘EL’.
            //         constraints.update({f'cen_en16931_{role}_vat_country_code': _(
            //             "The VAT of the %s should be prefixed with its country code.", role)})
            // 
            // if invoice.partner_shipping_id:
            //     # [BR-57]-Each Deliver to address (BG-15) shall contain a Deliver to country code (BT-80).
            //     constraints['cen_en16931_delivery_address'] = self._check_required_fields(invoice.partner_shipping_id, 'country_id')
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsCenEn16931UblNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _invoice_constraints_cen_en16931_ubl_new(self, invoice, vals):
            // """
            // corresponds to the errors raised by ' schematron/openpeppol/3.13.0/xslt/CEN-EN16931-UBL.xslt' for invoices.
            // This xslt was obtained by transforming the corresponding sch
            // https://docs.peppol.eu/poacc/billing/3.0/files/CEN-EN16931-UBL.sch.
            // """
            // eu_countries = self.env.ref('base.europe').country_ids
            // intracom_delivery = (vals['customer'].country_id in eu_countries
            //                      and vals['supplier'].country_id in eu_countries
            //                      and vals['customer'].country_id != vals['supplier'].country_id)
            // 
            // nsmap = self._get_document_nsmap(vals)
            // 
            // constraints = {
            //     # [BR-61]-If the Payment means type code (BT-81) means SEPA credit transfer, Local credit transfer or
            //     # Non-SEPA international credit transfer, the Payment account identifier (BT-84) shall be present.
            //     # note: Payment account identifier is <cac:PayeeFinancialAccount>
            //     # note: no need to check account_number, because it's a required field for a partner_bank
            //     'cen_en16931_payment_account_identifier': self._check_required_fields(
            //         invoice, 'partner_bank_id'
            //     ) if vals['document_node']['cac:PaymentMeans']['cbc:PaymentMeansCode']['_text'] in (30, 58) else None,
            //     # [BR-IC-12]-In an Invoice with a VAT breakdown (BG-23) where the VAT category code (BT-118) is
            //     # "Intra-community supply" the Deliver to country code (BT-80) shall not be blank.
            //     'cen_en16931_delivery_country_code': (
            //         _("For intracommunity supply, the delivery address should be included.")
            //     ) if intracom_delivery and dict_to_xml(vals['document_node']['cac:Delivery']['cac:DeliveryLocation'], nsmap=nsmap, tag='cac:DeliveryLocation') is None else None,
            // 
            //     # [BR-IC-11]-In an Invoice with a VAT breakdown (BG-23) where the VAT category code (BT-118) is
            //     # "Intra-community supply" the Actual delivery date (BT-72) or the Invoicing period (BG-14)
            //     # shall not be blank.
            //     'cen_en16931_delivery_date_invoicing_period': (
            //         _("For intracommunity supply, the actual delivery date or the invoicing period should be included.")
            //         if (
            //             intracom_delivery
            //             and dict_to_xml(vals['document_node']['cac:Delivery']['cbc:ActualDeliveryDate'], nsmap=nsmap, tag='cbc:ActualDeliveryDate') is None
            //             and dict_to_xml(vals['document_node']['cac:InvoicePeriod'], nsmap=nsmap, tag='cac:InvoicePeriod') is None
            //         )
            //         else None
            //     )
            // }
            // 
            // line_tag = self._get_tags_for_document_type(vals)['document_line']
            // line_nodes = vals['document_node'][line_tag]
            // 
            // for line_node in line_nodes:
            //     if not line_node['cac:Item']['cbc:Name']['_text']:
            //         # [BR-25]-Each Invoice line (BG-25) shall contain the Item name (BT-153).
            //         constraints.update({'cen_en16931_item_name': _("Each invoice line should have a product or a label.")})
            //         break
            // 
            // for line in invoice.invoice_line_ids.filtered(lambda x: x.display_type not in ('line_note', 'line_section')):
            //     if len(line.tax_ids.flatten_taxes_hierarchy().filtered(lambda t: t.amount_type != 'fixed')) != 1:
            //         # [UBL-SR-48]-Invoice lines shall have one and only one classified tax category.
            //         # /!\ exception: possible to have any number of ecotaxes (fixed tax) with a regular percentage tax
            //         constraints.update({'cen_en16931_tax_line': _("Each invoice line shall have one and only one tax.")})
            // 
            // for role in ('supplier', 'customer'):
            //     party_node = vals['document_node']['cac:AccountingCustomerParty'] if role == 'customer' else vals['document_node']['cac:AccountingSupplierParty']
            //     constraints[f'cen_en16931_{role}_country'] = (
            //         _("The country is required for the %s.", role)
            //         if not party_node['cac:Party']['cac:PostalAddress']['cac:Country']['cbc:IdentificationCode']['_text']
            //         else None
            //     )
            //     tax_scheme_node = party_node['cac:Party']['cac:PartyTaxScheme']
            //     if tax_scheme_node and (
            //         self._name in ('account.edi.xml.ubl_bis3', 'account.edi.xml.ubl_nl', 'account.edi.xml.ubl_de')
            //         and (tax_scheme_node[0]['cac:TaxScheme']['cbc:ID']['_text'] == 'VAT')
            //         and not (tax_scheme_node[0]['cbc:CompanyID']['_text'][:2].isalpha())
            //     ):
            //         # [BR-CO-09]-The Seller VAT identifier (BT-31), the Seller tax representative VAT identifier (BT-63)
            //         # and the Buyer VAT identifier (BT-48) shall have a prefix in accordance with ISO code ISO 3166-1
            //         # alpha-2 by which the country of issue may be identified. Nevertheless, Greece may use the prefix 'EL'.
            //         constraints.update({f'cen_en16931_{role}_vat_country_code': _(
            //             "The VAT of the %s should be prefixed with its country code.", role)})
            // 
            // if invoice.partner_shipping_id:
            //     # [BR-57]-Each Deliver to address (BG-15) shall contain a Deliver to country code (BT-80).
            //     constraints['cen_en16931_delivery_address'] = self._check_required_fields(invoice.partner_shipping_id, 'country_id')
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsPeppolEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _invoice_constraints_peppol_en16931_ubl(self, invoice, vals):
            // """
            // corresponds to the errors raised by 'schematron/openpeppol/3.13.0/xslt/PEPPOL-EN16931-UBL.xslt' for
            // invoices in ecosio. This xslt was obtained by transforming the corresponding sch
            // https://docs.peppol.eu/poacc/billing/3.0/files/PEPPOL-EN16931-UBL.sch.
            // 
            // The national rules (https://docs.peppol.eu/poacc/billing/3.0/bis/#national_rules) are included in this file.
            // They always refer to the supplier's country.
            // """
            // constraints = {
            //     # PEPPOL-EN16931-R003: A buyer reference or purchase order reference MUST be provided.
            //     'peppol_en16931_ubl_buyer_ref_po_ref':
            //         "A buyer reference or purchase order reference must be provided." if self._check_required_fields(
            //             vals['vals'], 'buyer_reference'
            //         ) and self._check_required_fields(vals['vals'], 'order_reference') else None,
            // }
            // 
            // if vals['supplier'].country_id.code == 'NL':
            //     constraints.update({
            //         # [NL-R-001] For suppliers in the Netherlands, if the document is a creditnote, the document MUST contain
            //         # an invoice reference (cac:BillingReference/cac:InvoiceDocumentReference/cbc:ID)
            //         'nl_r_001': self._check_required_fields(invoice, 'ref') if 'refund' in invoice.move_type else '',
            // 
            //         # [NL-R-002] For suppliers in the Netherlands the supplier’s address (cac:AccountingSupplierParty/cac:Party
            //         # /cac:PostalAddress) MUST contain street name (cbc:StreetName), city (cbc:CityName) and post code (cbc:PostalZone)
            //         'nl_r_002_street': self._check_required_fields(vals['supplier'], 'street'),
            //         'nl_r_002_zip': self._check_required_fields(vals['supplier'], 'zip'),
            //         'nl_r_002_city': self._check_required_fields(vals['supplier'], 'city'),
            // 
            //         # [NL-R-003] For suppliers in the Netherlands, the legal entity identifier MUST be either a
            //         # KVK or OIN number (schemeID 0106 or 0190)
            //         'nl_r_003': _(
            //             "%s should have a KVK or OIN number set in Company ID field or as Peppol e-address (EAS code 0106 or 0190).",
            //             vals['supplier'].display_name
            //         ) if (
            //             not vals['supplier'].peppol_eas in ('0106', '0190') and
            //             (not vals['supplier'].company_registry or len(vals['supplier'].company_registry) not in (8, 9))
            //         ) else '',
            // 
            //         # [NL-R-007] For suppliers in the Netherlands, the supplier MUST provide a means of payment
            //         # (cac:PaymentMeans) if the payment is from customer to supplier
            //         'nl_r_007': self._check_required_fields(invoice, 'partner_bank_id')
            //     })
            // 
            //     if vals['customer'].country_id.code == 'NL':
            //         constraints.update({
            //             # [NL-R-004] For suppliers in the Netherlands, if the customer is in the Netherlands, the customer
            //             # address (cac:AccountingCustomerParty/cac:Party/cac:PostalAddress) MUST contain the street name
            //             # (cbc:StreetName), the city (cbc:CityName) and post code (cbc:PostalZone)
            //             'nl_r_004_street': self._check_required_fields(vals['customer'], 'street'),
            //             'nl_r_004_city': self._check_required_fields(vals['customer'], 'city'),
            //             'nl_r_004_zip': self._check_required_fields(vals['customer'], 'zip'),
            // 
            //             # [NL-R-005] For suppliers in the Netherlands, if the customer is in the Netherlands,
            //             # the customer’s legal entity identifier MUST be either a KVK or OIN number (schemeID 0106 or 0190)
            //             'nl_r_005': _(
            //                 "%s should have a KVK or OIN number set in Company ID field or as Peppol e-address (EAS code 0106 or 0190).",
            //                 vals['customer'].display_name
            //             ) if (
            //                 not vals['customer'].commercial_partner_id.peppol_eas in ('0106', '0190') and
            //                 (not vals['customer'].commercial_partner_id.company_registry or len(vals['customer'].commercial_partner_id.company_registry) not in (8, 9))
            //             ) else '',
            //         })
            // 
            // if vals['supplier'].country_id.code == 'NO':
            //     vat = vals['supplier'].vat
            //     constraints.update({
            //         # NO-R-001: For Norwegian suppliers, a VAT number MUST be the country code prefix NO followed by a
            //         # valid Norwegian organization number (nine numbers) followed by the letters MVA.
            //         # Note: mva.is_valid("179728982MVA") is True while it lacks the NO prefix
            //         'no_r_001': _(
            //             "The VAT number of the supplier does not seem to be valid. It should be of the form: NO179728982MVA."
            //         ) if not mva.is_valid(vat) or len(vat) != 14 or vat[:2] != 'NO' or vat[-3:] != 'MVA' else "",
            //     })
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsPeppolEn16931UblNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _invoice_constraints_peppol_en16931_ubl_new(self, invoice, vals):
            // """
            // corresponds to the errors raised by 'schematron/openpeppol/3.13.0/xslt/PEPPOL-EN16931-UBL.xslt' for
            // invoices in ecosio. This xslt was obtained by transforming the corresponding sch
            // https://docs.peppol.eu/poacc/billing/3.0/files/PEPPOL-EN16931-UBL.sch.
            // 
            // The national rules (https://docs.peppol.eu/poacc/billing/3.0/bis/#national_rules) are included in this file.
            // They always refer to the supplier's country.
            // """
            // nsmap = self._get_document_nsmap(vals)
            // constraints = {
            //     # PEPPOL-EN16931-R003: A buyer reference or purchase order reference MUST be provided.
            //     'peppol_en16931_ubl_buyer_ref_po_ref':
            //         "A buyer reference or purchase order reference must be provided." if (
            //             dict_to_xml(vals['document_node']['cbc:BuyerReference'], nsmap=nsmap, tag='cbc:BuyerReference') is None
            //             and dict_to_xml(vals['document_node']['cac:OrderReference'], nsmap=nsmap, tag='cac:OrderReference') is None
            //         ) else None,
            // }
            // 
            // if vals['supplier'].country_id.code == 'NL':
            //     constraints.update({
            //         # [NL-R-001] For suppliers in the Netherlands, if the document is a creditnote, the document MUST contain
            //         # an invoice reference (cac:BillingReference/cac:InvoiceDocumentReference/cbc:ID)
            //         'nl_r_001': self._check_required_fields(invoice, 'ref') if 'refund' in invoice.move_type else '',
            // 
            //         # [NL-R-002] For suppliers in the Netherlands the supplier's address (cac:AccountingSupplierParty/cac:Party
            //         # /cac:PostalAddress) MUST contain street name (cbc:StreetName), city (cbc:CityName) and post code (cbc:PostalZone)
            //         'nl_r_002_street': self._check_required_fields(vals['supplier'], 'street'),
            //         'nl_r_002_zip': self._check_required_fields(vals['supplier'], 'zip'),
            //         'nl_r_002_city': self._check_required_fields(vals['supplier'], 'city'),
            // 
            //         # [NL-R-003] For suppliers in the Netherlands, the legal entity identifier MUST be either a
            //         # KVK or OIN number (schemeID 0106 or 0190)
            //         'nl_r_003': _(
            //             "%s should have a KVK or OIN number set in Company ID field or as Peppol e-address (EAS code 0106 or 0190).",
            //             vals['supplier'].display_name
            //         ) if (
            //             not vals['supplier'].peppol_eas in ('0106', '0190') and
            //             (not vals['supplier'].company_registry or len(vals['supplier'].company_registry) not in (8, 9))
            //         ) else '',
            // 
            //         # [NL-R-007] For suppliers in the Netherlands, the supplier MUST provide a means of payment
            //         # (cac:PaymentMeans) if the payment is from customer to supplier
            //         'nl_r_007': self._check_required_fields(invoice, 'partner_bank_id')
            //     })
            // 
            //     if vals['customer'].country_id.code == 'NL':
            //         constraints.update({
            //             # [NL-R-004] For suppliers in the Netherlands, if the customer is in the Netherlands, the customer
            //             # address (cac:AccountingCustomerParty/cac:Party/cac:PostalAddress) MUST contain the street name
            //             # (cbc:StreetName), the city (cbc:CityName) and post code (cbc:PostalZone)
            //             'nl_r_004_street': self._check_required_fields(vals['customer'], 'street'),
            //             'nl_r_004_city': self._check_required_fields(vals['customer'], 'city'),
            //             'nl_r_004_zip': self._check_required_fields(vals['customer'], 'zip'),
            // 
            //             # [NL-R-005] For suppliers in the Netherlands, if the customer is in the Netherlands,
            //             # the customer's legal entity identifier MUST be either a KVK or OIN number (schemeID 0106 or 0190)
            //             'nl_r_005': _(
            //                 "%s should have a KVK or OIN number set in Company ID field or as Peppol e-address (EAS code 0106 or 0190).",
            //                 vals['customer'].display_name
            //             ) if (
            //                 not vals['customer'].commercial_partner_id.peppol_eas in ('0106', '0190') and
            //                 (not vals['customer'].commercial_partner_id.company_registry or len(vals['customer'].commercial_partner_id.company_registry) not in (8, 9))
            //             ) else '',
            //         })
            // 
            // if vals['supplier'].country_id.code == 'NO':
            //     vat = vals['supplier'].vat
            //     constraints.update({
            //         # NO-R-001: For Norwegian suppliers, a VAT number MUST be the country code prefix NO followed by a
            //         # valid Norwegian organization number (nine numbers) followed by the letters MVA.
            //         # Note: mva.is_valid("179728982MVA") is True while it lacks the NO prefix
            //         'no_r_001': _(
            //             "The VAT number of the supplier does not seem to be valid. It should be of the form: NO179728982MVA."
            //         ) if not mva.is_valid(vat) or len(vat) != 14 or vat[:2] != 'NO' or vat[-3:] != 'MVA' else "",
            //     })
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> L10nMyEdiGetDeliveryPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _l10n_my_edi_get_delivery_party_vals(self, partner):
            // """ Returns the vals required to display the delivery information in the invoice. """
            // return {
            //     'partner': partner,
            //     'party_identification_vals': self._get_partner_party_identification_vals_list(partner.commercial_partner_id),
            //     'postal_address_vals': self._get_partner_address_vals(partner),
            //     'party_legal_entity_vals': self._get_partner_party_legal_entity_vals_list(partner.commercial_partner_id),
            // }
            */
            return default;
        }

        public async Task<TEntity> L10nMyEdiGetDocumentTypeCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _l10n_my_edi_get_document_type_code(self, invoice):
            // """ Returns the code matching the invoice type, as well as the original document if any. """
            // if 'debit_origin_id' in self.env['account.move']._fields and invoice.debit_origin_id:
            //     return '03', invoice.debit_origin_id
            // elif invoice.move_type == 'out_refund':
            //     return '02', invoice.reversed_entry_id
            // else:
            //     return '01', None
            */
            return default;
        }

        public async Task<TEntity> L10nMyEdiGetFormattedPhoneNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object number) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _l10n_my_edi_get_formatted_phone_number(self, number):
            // # the phone number MUST follow the E.164 format.
            // # Don't try to reformat too much, we don't want to risk messing it up
            // if not number:
            //     return ''  # This wouldn't happen in the file as it's caught in the validation errors, but the vals are exported before these checks are done.
            // return number.replace(' ', '').replace('(', '').replace(')', '').replace('-', '')
            */
            return default;
        }

        public async Task<TEntity> L10nMyEdiGetTaxExchangeRateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _l10n_my_edi_get_tax_exchange_rate(self, invoice):
            // """ Returns the tax exchange rate if applicable. We will compute it based on the invoice totals.
            // This should be the rate to convert a foreign currency into MYR.
            // """
            // if invoice.currency_id.name != "MYR":
            //     # I couldn't find any information on maximum precision, so we will use the currency format.
            //     return self.env.ref('base.MYR').round(abs(invoice.amount_total_signed) / (invoice.amount_total or 1))
            // return ''
            */
            return default;
        }

        public async Task<TEntity> L10nMyEdiMakeValidationErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object constraints, object code, object record_identifier, object record_name) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _l10n_my_edi_make_validation_error(self, constraints, code, record_identifier, record_name):
            // """ Small helper that add new constrains into provided constrains dict.
            // This helper is mainly there to keep the check method tidy, and focused on its purpose (validating data)
            // """
            // message_mapping = {
            //     'industrial_classification_required': _(
            //         "The industrial classification must be defined on company: %(company_name)s",
            //         company_name=record_name
            //     ),
            //     'phone_number_format': _(
            //         "The following partner's phone number should follow the E.164 format: %(partner_name)s",
            //         partner_name=record_name
            //     ),
            //     'phone_number_required': _(
            //         "The following partner's phone number is missing: %(partner_name)s",
            //         partner_name=record_name)
            //     ,
            //     'required_id': _(
            //         "The following partner's identification type or number is missing: %(partner_name)s",
            //         partner_name=record_name
            //     ),
            //     'no_state': _(
            //         "The following partner's state is missing: %(partner_name)s",
            //         partner_name=record_name
            //     ),
            //     'no_city': _(
            //         "The following partner's city is missing: %(partner_name)s",
            //         partner_name=record_name
            //     ),
            //     'no_country': _(
            //         "The following partner's country is missing: %(partner_name)s",
            //         partner_name=record_name
            //     ),
            //     'no_street': _(
            //         "The following partner's street is missing: %(partner_name)s",
            //         partner_name=record_name
            //     ),
            //     'class_code_required': _(
            //         "The following product must have their item classification code set: %(product_name)s",
            //         product_name=record_name
            //     ),
            //     'class_code_required_line': _(
            //         "The following line must have their item classification code set: %(line_name)s",
            //         line_name=record_name
            //     ),
            //     'adjustment_origin': _(
            //         "You cannot send a debit / credit note for invoice %(invoice_number)s as it has not yet been sent to MyInvois.",
            //         invoice_number=record_name
            //     ),
            //     'too_many_sst': _(
            //         "The following partner's should have at most two SST numbers, separated by a semicolon : %(partner_name)s",
            //         partner_name=record_name
            //     ),
            //     'tax_ids_required': _(
            //         "You must set a tax on the line : %(line_name)s.\nIf taxes are not applicable, please set a 0%% tax with a tax type 'Not Applicable'.",
            //         line_name=record_name
            //     ),
            //     'tax_exemption_required': _(
            //         "You must set a Tax Exemption Reason on the invoice : %(invoice_name)s as some taxes have the type 'Tax exemption' without a reason set.",
            //         invoice_name=record_name
            //     ),
            //     'tax_exemption_required_on_tax': _(
            //         "You must set a Tax Exemption Reason on each tax exempt taxes in order to use them in a Myinvois Document.",
            //     ),
            //     'missing_general_public': _(
            //         "You must have a commercial partner named 'General Public' with a VAT number set to 'EI00000000010' in order to proceed.",
            //     ),
            // }
            // 
            // constraints[f'myinvois_{record_identifier}_{code}'] = message_mapping[code]
            */
            return default;
        }

        public async Task<TEntity> L10nRsGetBillingReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _l10n_rs_get_billing_reference(self, invoice):
            // # Billing Reference values for Credit Note
            // if invoice.move_type == 'out_refund' and invoice.reversed_entry_id:
            //     return {
            //         'id': invoice.reversed_entry_id.name,
            //         'issue_date': invoice.reversed_entry_id.invoice_date,
            //     }
            // return {}
            */
            return default;
        }

        public async Task<TEntity> L10nSaGenerateInvoiceXmlHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xml_content, object mode) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_generate_invoice_xml_hash(self, xml_content, mode='hexdigest'):
            // """
            //     Generate the b64 encoded sha256 hash of a given xml string:
            //         - First: Transform the xml content using a pre-hash_invoice.xsl file
            //         - Second: Canonicalize the transformed xml content using the c14n method
            //         - Third: hash the canonicalized content using the sha256 algorithm then encode it into b64 format
            // """
            // xml_sha = self._l10n_sa_generate_invoice_xml_sha(xml_content)
            // if mode == 'hexdigest':
            //     xml_hash = xml_sha.hexdigest().encode()
            // elif mode == 'digest':
            //     xml_hash = xml_sha.digest()
            // return b64encode(xml_hash)
            */
            return default;
        }

        public async Task<TEntity> L10nSaGenerateInvoiceXmlShaInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xml_content) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_generate_invoice_xml_sha(self, xml_content):
            // """
            //     Transform, canonicalize then hash the invoice xml content using the SHA256 algorithm,
            //     then return the hashed content
            // """
            // 
            // def _canonicalize_xml(content):
            //     """
            //         Canonicalize XML content using the c14n method. The specs mention using the c14n11 canonicalization,
            //         which is simply calling etree.tostring and setting the method argument to 'c14n'. There are minor
            //         differences between c14n11 and c14n canonicalization algorithms, but for the purpose of ZATCA signing,
            //         c14n is enough
            //     """
            //     return etree.tostring(content, method="c14n", exclusive=False, with_comments=False,
            //                           inclusive_ns_prefixes=self._l10n_sa_get_namespaces())
            // 
            // def _transform_and_canonicalize_xml(content):
            //     """ Transform XML content to remove certain elements and signatures using an XSL template """
            //     invoice_xsl = etree.parse(file_path('l10n_sa_edi/data/pre-hash_invoice.xsl'))
            //     transform = etree.XSLT(invoice_xsl)
            //     return _canonicalize_xml(transform(content))
            // 
            // root = etree.fromstring(xml_content)
            // # Transform & canonicalize the XML content
            // transformed_xml = _transform_and_canonicalize_xml(root)
            // # Get the SHA256 hashed value of the XML content
            // return sha256(transformed_xml)
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetAdditionalTaxTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_additional_tax_total_vals(self, invoice, vals):
            // """
            //     For ZATCA, an additional TaxTotal element needs to be included in the UBL file
            //     (Only for the Invoice, not the lines)
            // 
            //     If the invoice is in a different currency from the one set on the company (SAR), then the additional
            //     TaxAmount element needs to hold the tax amount converted to the company's currency.
            // 
            //     Business Rules: BT-110 & BT-111
            // """
            // curr_amount = abs(vals['taxes_vals']['tax_amount_currency'])
            // if invoice.currency_id != invoice.company_currency_id:
            //     curr_amount = abs(vals['taxes_vals']['tax_amount'])
            // return vals['vals']['tax_total_vals'] + [{
            //     'currency': invoice.company_currency_id,
            //     'currency_dp': invoice.company_currency_id.decimal_places,
            //     'tax_amount': curr_amount,
            // }]
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetBillingReferenceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_billing_reference_vals(self, invoice):
            // """ Get the billing reference vals required to render the BillingReference for credit/debit notes """
            // if self._l10n_sa_get_invoice_type(invoice) != 388:
            //     return {
            //         'id': (invoice.reversed_entry_id.name or invoice.ref) if invoice.move_type == 'out_refund' else invoice.debit_origin_id.name,
            //         'issue_date': None,
            //     }
            // return {}
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetInvoiceTransactionCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_invoice_transaction_code(self, invoice):
            // """
            //     Returns the transaction code string to be inserted in the UBL file follows the following format:
            //         - NNPNESB, in compliance with KSA Business Rule KSA-2, where:
            //             - NN (positions 1 and 2) = invoice subtype:
            //                 - 01 for tax invoice
            //                 - 02 for simplified tax invoice
            //             - E (position 5) = Exports invoice transaction, 0 for false, 1 for true
            // """
            // return '0%s00%s00' % (
            //     '2' if invoice._l10n_sa_is_simplified() else '1',
            //     '1' if invoice.commercial_partner_id.country_id != invoice.company_id.country_id and not invoice._l10n_sa_is_simplified() else '0'
            // )
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetInvoiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_invoice_type(self, invoice):
            // """
            //     Returns the invoice type string to be inserted in the UBL file
            //         - 383: Debit Note
            //         - 381: Credit Note
            //         - 388: Invoice
            // """
            // return (
            //     383 if invoice.debit_origin_id else
            //     381 if invoice.move_type == 'out_refund' else
            //     386 if invoice._is_downpayment() else 388
            // )
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetLinePrepaymentValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_line_prepayment_vals(self, line, taxes_vals):
            // """
            //     If an invoice line is linked to a down payment invoice, we need to return the proper values
            //     to be included in the UBL
            // """
            // if not line.move_id._is_downpayment() and line.sale_line_ids and all(sale_line.is_downpayment for sale_line in line.sale_line_ids):
            //     prepayment_move_id = line.sale_line_ids.invoice_lines.move_id.filtered(lambda m: m.move_type == 'out_invoice' and m._is_downpayment())
            //     return {
            //         'prepayment_id': prepayment_move_id.name,
            //         'issue_date': fields.Datetime.context_timestamp(self.with_context(tz='Asia/Riyadh'),
            //                                                         prepayment_move_id.l10n_sa_confirmation_datetime),
            //         'document_type_code': 386
            //     }
            // return {}
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetMonetaryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_monetary_vals(self, invoice, vals):
            // """ Calculate the invoice monteray amount values, including prepaid amounts (down payment) """
            // # We use base_amount_currency + tax_amount_currency instead of amount_total because we do not want to include
            // # withholding tax amounts in our calculations
            // total_amount = abs(vals['taxes_vals']['base_amount_currency'] + vals['taxes_vals']['tax_amount_currency'])
            // line_extension_amount = vals['vals']['monetary_total_vals']['line_extension_amount']
            // tax_inclusive_amount = total_amount
            // tax_exclusive_amount = abs(vals['taxes_vals']['base_amount_currency'])
            // prepaid_amount = 0
            // payable_amount = total_amount
            // # - When we calculate the tax values, we filter out taxes and invoice lines linked to downpayments.
            // #   As such, when we calculate the TaxInclusiveAmount, it already accounts for the tax amount of the downpayment
            // #   Same goes for the TaxExclusiveAmount, and we do not need to add the Tax amount of the downpayment
            // # - The payable amount does not account for the tax amount of the downpayment, so we add it
            // downpayment_vals = self._l10n_sa_get_prepaid_amount(invoice, vals)
            // allowance_charge_vals = vals['vals']['allowance_charge_vals']
            // allowance_total_amount = sum(a['amount'] for a in allowance_charge_vals if a['charge_indicator'] == 'false')
            // if downpayment_vals:
            //     # - BR-KSA-80: To calculate payable amount, we deduct prepaid amount from total tax inclusive amount
            //     prepaid_amount = downpayment_vals['total_amount']
            //     payable_amount = tax_inclusive_amount - prepaid_amount
            // return {
            //     'line_extension_amount': line_extension_amount - allowance_total_amount,
            //     'tax_inclusive_amount': tax_inclusive_amount,
            //     'tax_exclusive_amount': tax_exclusive_amount,
            //     'prepaid_amount': prepaid_amount,
            //     'payable_amount': payable_amount,
            //     'allowance_total_amount': allowance_total_amount
            // }
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetNamespacesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_namespaces(self):
            // """
            //     Namespaces used in the final UBL declaration, required to canonalize the finalized XML document of the Invoice
            // """
            // return {
            //     'cac': 'urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2',
            //     'cbc': 'urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2',
            //     'ext': 'urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2',
            //     'sig': 'urn:oasis:names:specification:ubl:schema:xsd:CommonSignatureComponents-2',
            //     'sac': 'urn:oasis:names:specification:ubl:schema:xsd:SignatureAggregateComponents-2',
            //     'sbc': 'urn:oasis:names:specification:ubl:schema:xsd:SignatureBasicComponents-2',
            //     'ds': 'http://www.w3.org/2000/09/xmldsig#',
            //     'xades': 'http://uri.etsi.org/01903/v1.3.2#'
            // }
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetPaymentMeansCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_payment_means_code(self, invoice):
            // """ Return payment means code to be used to set the value on the XML file """
            // return 'unknown'
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetPrepaidAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_prepaid_amount(self, invoice, vals):
            // """ Calculate the down-payment amount according to ZATCA rules """
            // downpayment_lines = False if invoice._is_downpayment() else invoice.line_ids.filtered(lambda l: l._get_downpayment_lines())
            // if downpayment_lines:
            //     tax_vals = invoice._prepare_invoice_aggregated_taxes(
            //         filter_tax_values_to_apply=lambda l, t: not self.env['account.tax'].browse(t.get('id')).l10n_sa_is_retention
            //     )
            //     base_amount = abs(sum(tax_vals['tax_details_per_record'][l]['base_amount_currency'] for l in downpayment_lines))
            //     tax_amount = abs(sum(tax_vals['tax_details_per_record'][l]['tax_amount_currency'] for l in downpayment_lines))
            //     return {
            //         'total_amount': base_amount + tax_amount,
            //         'base_amount': base_amount,
            //         'tax_amount': tax_amount
            //     }
            */
            return default;
        }

        public async Task<TEntity> L10nSaGetPreviousInvoiceHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_get_previous_invoice_hash(self, invoice):
            // """ Function that returns the Base 64 encoded SHA256 hash of the previously submitted invoice """
            // if invoice.company_id.l10n_sa_api_mode == 'sandbox' or not invoice.journal_id.l10n_sa_latest_submission_hash:
            //     # If no invoice, or if using Sandbox, return the b64 encoded SHA256 value of the '0' character
            //     return "NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ=="
            // return invoice.journal_id.l10n_sa_latest_submission_hash
            */
            return default;
        }

        public async Task<TEntity> L10nSaPostprocessLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sa_edi, FILE: account_edi_xml_ubl_21_zatca.py) ---
            // def _l10n_sa_postprocess_line_vals(self, vals):
            // """
            //     Postprocess vals to remove negative line amounts, as those will be used to compute
            //     document level allowances (global discounts)
            // """
            // final_line_vals = []
            // for line_vals in vals['vals']['line_vals']:
            //     if line_vals['price_vals']['price_amount'] >= 0:
            //         final_line_vals.append(line_vals)
            // vals['vals'][('line_vals')] = final_line_vals
            */
            return default;
        }

        public async Task<TEntity> L10nTrGetAmountIntegerPartnTextNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object currency) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_tr_nilvera_einvoice, FILE: account_edi_xml_ubl_tr.py) ---
            // def _l10n_tr_get_amount_integer_partn_text_note(self, amount, currency):
            // sign = math.copysign(1.0, amount)
            // amount_integer_part, amount_decimal_part = divmod(abs(amount), 1)
            // amount_decimal_part = int(amount_decimal_part * 100)
            // 
            // text_i = num2words(amount_integer_part * sign, lang="tr") or 'Sifir'
            // text_d = num2words(amount_decimal_part * sign, lang="tr") or 'Sifir'
            // return f'YALNIZ : {text_i} {currency.name} {text_d} {currency.currency_subunit_label}'.upper()
            */
            return default;
        }

        public async Task<TEntity> RoundMaxDpInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @value) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _round_max_dp(self, value):
            // return float_round(value, JO_MAX_DP)
            */
            return default;
        }

        public async Task<TEntity> SumMaxDpInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iterable) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _sum_max_dp(self, iterable):
            // return sum(self._round_max_dp(element) for element in iterable)
            */
            return default;
        }
    }
}