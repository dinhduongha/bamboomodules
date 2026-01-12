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
    [Module("account_edi_ubl_cii", Category = "Accounting", Depends = new[] { "account" })]
    public class AccountEdiXmlUblBis3AppService : ApplicationService, IAccountEdiXmlUblBis3AppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiXmlUblBis3AppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AddDocumentCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_document_currency_vals(self, vals):
            // super()._add_document_currency_vals(vals)
            // vals['currency_dp'] = 2
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> AddDocumentLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> AddDocumentLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> AddDocumentLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> AddDocumentLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_document_line_tax_total_nodes(self, line_node, vals):
            // # TaxTotal should not be used in BIS 3.0
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
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

        public async Task<TEntity> AddInvoicePaymentMeansNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // # EXTENDS account.edi.xml.ubl_bis3
            // constraints = super()._export_invoice_constraints(invoice, vals)
            // 
            // constraints.update({
            //     'bis3_de_supplier_telephone_required': self._check_required_fields(vals['supplier'], ['phone', 'mobile']),
            //     'bis3_de_supplier_electronic_mail_required': self._check_required_fields(vals['supplier'], 'email'),
            // })
            // 
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'eu.peppol.bis3.aunz.ubl:invoice:1.0.8',
            //     'credit_note': 'eu.peppol.bis3.aunz.ubl:creditnote:1.0.8',
            // }
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'eu.peppol.bis3:invoice:3.13.0',
            //     'credit_note': 'eu.peppol.bis3:creditnote:3.13.0',
            // }
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'org.simplerinvoicing:invoice:2.0.3.3',
            //     'credit_note': 'org.simplerinvoicing:creditnote:2.0.3.3',
            // }
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'eu.peppol.bis3.sg.ubl:invoice:1.0.3',
            //     'credit_note': 'eu.peppol.bis3.sg.ubl:creditnote:1.0.3',
            // }
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'de.xrechnung:ubl-invoice:2.2.0',
            //     'credit_note': 'de.xrechnung:ubl-creditnote:2.2.0',
            // }
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_a_nz.xml"
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_ubl_bis3.xml"
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_nlcius.xml"
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_sg.xml"
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_ubl_de.xml"
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object convert_fixed_taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_21
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals'].update({
            //     'customization_id': self._get_customization_ids()['ubl_a_nz'],
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals']['customization_id'] = self._get_customization_ids()['nlcius']
            // 
            // # [BR-NL-24] Use of previous invoice date ( IssueDate ) is not recommended.
            // # vals['vals'].pop('issue_date')  # careful, this causes other errors from the validator...
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals'].update({
            //     'customization_id': self._get_customization_ids()['ubl_sg'],
            // })
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._export_invoice_vals(invoice)
            // vals['vals']['customization_id'] = self._get_customization_ids()['xrechnung']
            // if not vals['vals'].get('buyer_reference'):
            //     vals['vals']['buyer_reference'] = 'N/A'
            // return vals
            */
            return default;
        }

        public async Task<TEntity> ExportOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _export_order(self, order):
            // vals = self._export_order_vals(order)
            // xml_content = self.env['ir.qweb']._render('purchase_edi_ubl_bis3.bis3_OrderType', vals)
            // return etree.tostring(cleanup_xml_node(xml_content), xml_declaration=True, encoding='UTF-8')
            */
            return default;
        }

        public async Task<TEntity> ExportOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _export_order_vals(self, order):
            // order_lines = self._get_order_lines(order)
            // anticipated_monetary_total_vals = self._get_anticipated_monetary_total_vals(order, order_lines)
            // 
            // supplier = order.partner_id
            // customer = order.company_id.partner_id.commercial_partner_id
            // customer_delivery_address = customer.child_ids.filtered(lambda child: child.type == 'delivery')
            // delivery = (
            //     order.dest_address_id
            //     or (customer_delivery_address and customer_delivery_address[0])
            //     or customer
            // )
            // 
            // vals = {
            //     'builder': self,
            //     'order': order,
            //     'supplier': supplier,
            //     'customer': customer,
            // 
            //     'format_float': self.format_float,
            // 
            //     'vals': {
            //         'id': order.name,
            //         'issue_date': order.create_date.date(),
            //         'note': html2plaintext(order.notes) if order.notes else False,
            //         'originator_document_reference': order.origin,
            //         'document_currency_code': order.currency_id.name.upper(),
            //         'delivery_party_vals': self._get_delivery_party_vals(delivery),
            //         'supplier_party_vals': self._get_partner_party_vals(supplier, role='supplier'),
            //         'customer_party_vals': self._get_partner_party_vals(customer, role='customer'),
            //         'payment_terms_vals': self._get_payment_terms_vals(order.payment_term_id),
            //         'anticipated_monetary_total_vals': anticipated_monetary_total_vals,
            //         'tax_amount': order.amount_tax,
            //         'order_lines': order_lines,
            //         'currency_dp': self._get_currency_decimal_places(order.currency_id),  # currency decimal places
            //         'currency_id': order.currency_id.name,
            //     },
            // }
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> ExportPurchaseOrderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object purchase_order) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _export_purchase_order_filename(self, purchase_order):
            // return f"{purchase_order.name.replace('/', '_')}_ubl_bis3.xml"
            */
            return default;
        }

        public async Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> GetAnticipatedMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object purchase_order, object order_lines) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_anticipated_monetary_total_vals(self, purchase_order, order_lines):
            // line_extension_amount = sum(line['line_extension_amount'] for line in order_lines)
            // allowance_total_amount = sum(line['price']['allowance_charge_vals']['amount'] for line in order_lines if 'allowance_charge_vals' in line['price'])
            // return {
            //     'currency': purchase_order.currency_id,
            //     'currency_dp': self._get_currency_decimal_places(purchase_order.currency_id),
            //     'line_extension_amount': line_extension_amount,
            //     'allowance_total_amount': allowance_total_amount,
            //     'tax_exclusive_amount': line_extension_amount - allowance_total_amount,
            //     'tax_inclusive_amount': purchase_order.amount_total,
            //     'payable_amount': purchase_order.amount_total,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCountryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_country_vals(self, country):
            // return {
            //     'country': country,
            // 
            //     'identification_code': country.code,
            //     'name': country.name,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object delivery) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_delivery_party_vals(self, delivery):
            // return {
            //     'party_name': delivery.display_name,
            //     'postal_address_vals': self._get_partner_address_vals(delivery),
            //     'contact_vals': self._get_partner_contact_vals(delivery),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> GetFinancialAccountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> GetFinancialInstitutionBranchValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bank) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> GetInvoiceLineAllowanceValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object tax_values_list) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_invoice_line_allowance_vals_list(self, line, tax_values_list=None):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_invoice_line_allowance_vals_list(line, tax_values_list=tax_values_list)
            // # [BR-NL-32] Use of Discount reason code ( AllowanceChargeReasonCode ) is not recommended.
            // # [BR-EN-34] Use of Charge reason code ( AllowanceChargeReasonCode ) is not recommended.
            // # Careful! [BR-42]-Each Invoice line allowance (BG-27) shall have an Invoice line allowance reason (BT-139)
            // # or an Invoice line allowance reason code (BT-140).
            // for vals in vals_list:
            //     if vals.get('allowance_charge_reason'):
            //         vals.pop('allowance_charge_reason_code')
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineItemValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, Guid line_id, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_invoice_payment_means_vals_list(invoice)
            // # [BR-NL-29] The use of a payment means text (cac:PaymentMeans/cbc:PaymentMeansCode/@name) is not recommended
            // for vals in vals_list:
            //     vals.pop('payment_means_code_attrs', None)
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // """ https://www.peppolguide.sg/billing/bis/#_payment_means_information
            // """
            // vals_list = super()._get_invoice_payment_means_vals_list(invoice)
            // for vals in vals_list:
            //     vals.update({
            //         'payment_means_code': 54,
            //         'payment_means_code_attrs': {'name': 'Credit Card'},
            //     })
            // 
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            */
            return default;
        }

        public async Task<TEntity> GetItemValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object order_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_item_vals(self, order, order_line):
            // product = order_line.product_id
            // variant_info = [{
            //     'name': value.attribute_id.name,
            //     'value': value.name
            // } for value in product.product_template_attribute_value_ids]
            // 
            // vals = {
            //     'name': product.name or order_line.name,
            //     'description': order_line.name or product.description,
            //     'standard_item_identification': product.barcode,
            //     'classified_tax_category_vals': self._get_tax_category_vals(order, order_line)
            // }
            // 
            // if len(variant_info) > 0:
            //     vals['variant_info'] = variant_info
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetLineAllowanceChargeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_line_allowance_charge_vals(self, line):
            // # Price subtotal with discount subtracted:
            // net_price_subtotal = line.price_subtotal
            // # Price subtotal without discount subtracted:
            // if line.discount == 100.0:
            //     gross_price_subtotal = 0.0
            // else:
            //     gross_price_subtotal = line.currency_id.round(net_price_subtotal / (1.0 - (line.discount or 0.0) / 100.0))
            // 
            // return {
            //     'charge_indicator': 'false',
            //     'allowance_charge_reason_code': '95',
            //     'allowance_charge_reason': _("Discount"),
            //     'currency_id': line.currency_id.name,
            //     'currency_dp': self._get_currency_decimal_places(line.currency_id),
            //     'amount': gross_price_subtotal - net_price_subtotal,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLineItemPriceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_line_item_price_vals(self, line):
            // """ Method used to fill the cac:Price node.
            // It provides information about the price applied for the goods and services.
            // """
            // # Price subtotal without discount:
            // net_price_subtotal = line.price_subtotal
            // # Price subtotal with discount:
            // if line.discount == 100.0:
            //     gross_price_subtotal = 0.0
            // else:
            //     gross_price_subtotal = net_price_subtotal / (1.0 - (line.discount or 0.0) / 100.0)
            // # Price subtotal with discount / quantity:
            // gross_price_unit = gross_price_subtotal / line.product_qty if line.product_qty else 0.0
            // 
            // uom = self._get_uom_unece_code(line.product_uom)
            // 
            // vals = {
            //     'currency_id': line.currency_id.name,
            //     'currency_dp': self._get_currency_decimal_places(line.currency_id),
            //     'price_amount': round(gross_price_unit, 10),
            //     'product_price_dp': self.env['decimal.precision'].precision_get('Product Price'),
            //     'base_quantity': 1,
            //     'base_quantity_unit_code': uom,
            // }
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _get_line_xpaths(self, document_type=None, qty_factor=1):
            // # Override account.edi.xml.ubl_bis3
            // return {
            //     **super()._get_line_xpaths(),
            //     'delivered_qty': ('./{*}Quantity'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_order_lines(self, order):
            // def _get_order_line_vals(order_line, order_line_id):
            //     return {
            //         'id': order_line_id,
            //         'quantity': order_line.product_qty,
            //         'quantity_unit_code': self._get_uom_unece_code(order_line.product_uom),
            //         'line_extension_amount': order_line.price_subtotal,
            //         'currency_id': order_line.currency_id.name,
            //         'currency_dp': self._get_currency_decimal_places(order_line.currency_id),
            //         'price': self._get_line_item_price_vals(order_line),
            //         'item': self._get_item_vals(order, order_line),
            //     }
            // return [_get_order_line_vals(line, line_id) for line_id, line in enumerate(
            //     order.order_line.filtered(lambda line: line.display_type not in ['line_note', 'line_section'])
            // , 1)]
            */
            return default;
        }

        public async Task<TEntity> GetPartnerAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_partner_address_vals(self, partner):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._get_partner_address_vals(partner)
            // # [BR-NL-28] The use of a country subdivision (cac:AccountingCustomerParty/cac:Party/cac:PostalAddress
            // # /cbc:CountrySubentity) is not recommended
            // vals.pop('country_subentity', None)
            // return vals
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_partner_address_vals(self, partner):
            // return {
            //     'street_name': partner.street,
            //     'additional_street_name': partner.street2,
            //     'city_name': partner.city,
            //     'postal_zone': partner.zip,
            //     'country_subentity': partner.state_id.name,
            //     'country_identification_code': partner.country_id.code
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPartnerContactValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_partner_contact_vals(self, partner):
            // return {
            //     'name': partner.name,
            //     'telephone': partner.phone or partner.mobile,
            //     'electronic_mail': partner.email,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyIdentificationValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_partner_party_legal_entity_vals(self, partner):
            // return {
            //     'registration_name': partner.name,
            //     'company_id': partner.vat,
            //     'registration_address_vals': self._get_partner_address_vals(partner),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_partner_party_legal_entity_vals_list(partner)
            // 
            // for vals in vals_list:
            //     if partner.country_code == 'AU' and partner.vat:
            //         vals.update({
            //             'company_id': partner.vat.replace(" ", ""),
            //             'company_id_attrs': {'schemeID': '0151'},
            //         })
            //     if partner.country_code == 'NZ':
            //         vals.update({
            //             'company_id': partner.company_registry,
            //             'company_id_attrs': {'schemeID': '0088'},
            //         })
            // return vals_list
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
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyTaxSchemeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_partner_party_tax_scheme_vals(self, partner):
            // return {
            //     'company_id': partner.vat,
            //     'tax_scheme_vals': {'id': 'VAT'},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_partner_party_tax_scheme_vals_list(partner, role)
            // 
            // for vals in vals_list:
            //     if partner.country_id.code == "AU" and partner.vat:
            //         vals['company_id'] = partner.vat.replace(" ", "")
            // 
            // return vals_list
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
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._get_partner_party_vals(partner, role)
            // 
            // if partner.country_code == 'AU' and partner.vat:
            //     vals['endpoint_id'] = partner.vat.replace(" ", "")
            // if partner.country_code == 'NZ':
            //     vals['endpoint_id'] = partner.company_registry
            // 
            // for party_tax_scheme in vals['party_tax_scheme_vals']:
            //     party_tax_scheme['tax_scheme_vals'] = {'id': 'GST'}
            // 
            // return vals
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._get_partner_party_vals(partner, role)
            // 
            // for party_tax_scheme in vals['party_tax_scheme_vals']:
            //     party_tax_scheme['tax_scheme_vals'] = {'id': 'GST'}
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._get_partner_party_vals(partner, role)
            // 
            // if not vals.get('endpoint_id') and partner.email:
            //     vals.update({
            //         'endpoint_id': partner.email,
            //         'endpoint_id_attrs': {'schemeID': 'EM'},
            //     })
            // 
            // return vals
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // vals = {
            //     'party_name': partner.display_name,
            //     'postal_address_vals': self._get_partner_address_vals(partner),
            //     'contact_vals': self._get_partner_contact_vals(partner),
            // }
            // if role == 'customer':
            //     vals['party_tax_scheme_vals'] = self._get_partner_party_tax_scheme_vals(partner.commercial_partner_id)
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> GetPaymentTermsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_term) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_payment_terms_vals(self, payment_term):
            // return {
            //     'note': payment_term.name
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // for vals in vals_list:
            //     vals['tax_scheme_vals'] = {'id': 'GST'}
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS account.edi.xml.ubl_21
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // 
            // for vals in vals_list:
            //     vals.pop('name', None)
            // 
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // for tax in vals_list:
            //     # [BR-NL-35] The use of a tax exemption reason code (cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory
            //     # /cbc:TaxExemptionReasonCode) is not recommended
            //     tax.pop('tax_exemption_reason_code', None)
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # OVERRIDE
            // res = []
            // for tax in taxes:
            //     res.append({
            //         'id': self._get_tax_sg_codes(tax),
            //         'percent': tax.amount if tax.amount_type == 'percent' else False,
            //         'tax_scheme_vals': {'id': 'GST'},
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> GetTaxCategoryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object order_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_tax_category_vals(self, order, order_line):
            // if not order_line.taxes_id:
            //     return None
            // tax = order_line.taxes_id[0]
            // customer = order.company_id.partner_id.commercial_partner_id
            // supplier = order.partner_id
            // tax_unece_codes = self._get_tax_unece_codes(customer, supplier, tax)
            // return {
            //     'id': tax_unece_codes.get('tax_category_code'),
            //     'percent': tax.amount if tax.amount_type == 'percent' else False,
            //     'tax_scheme_vals': {'id': 'VAT'},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxSgCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _get_tax_sg_codes(self, tax):
            // """ https://www.peppolguide.sg/billing/bis/#_gst_category_codes
            // """
            // tax_category_code = 'SR'
            // if tax.amount == 0:
            //     tax_category_code = 'ZR'
            // return tax_category_code
            */
            return default;
        }

        public async Task<TEntity> GetTaxSubtotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> ImportFillOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _import_fill_order(self, order, tree):
            // """ Fill order details by extracting details from xml tree.
            // 
            // param order: Order to fill details from xml tree.
            // param tree: Xml tree to extract details.
            // :return: list of logs to add warnig and information about data from xml.
            // """
            // logs = []
            // order_values = {}
            // partner, partner_logs = self._import_partner(
            //     order.company_id,
            //     **self._import_retrieve_partner_vals(tree, "BuyerCustomer"),
            // )
            // if partner:
            //     order_values['partner_id'] = partner.id
            // delivery_partner, delivery_partner_logs = self._import_delivery_partner(
            //     order,
            //     **self._import_retrieve_delivery_vals(tree),
            // )
            // if delivery_partner:
            //     order_values['partner_shipping_id'] = delivery_partner.id
            // order_values['currency_id'], currency_logs = self._import_currency(tree, './/{*}DocumentCurrencyCode')
            // 
            // order_values['date_order'] = tree.findtext('./{*}IssueDate')
            // order_values['client_order_ref'] = tree.findtext('./{*}ID')
            // order_values['note'] = self._import_description(tree, xpaths=['./{*}Note'])
            // order_values['origin'] = tree.findtext('./{*}OriginatorDocumentReference/{*}ID')
            // order_values['payment_term_id'] = self._import_payment_term_id(order, tree, './/cac:PaymentTerms/cbc:Note')
            // 
            // allowance_charges_line_vals, allowance_charges_logs = self._import_document_allowance_charges(tree, order, 'sale')
            // lines_vals, line_logs = self._import_order_lines(order, tree, './{*}OrderLine/{*}LineItem')
            // lines_vals += allowance_charges_line_vals
            // 
            // order_values = {
            //     **order_values,
            //     'order_line': [Command.create(line_vals) for line_vals in lines_vals],
            // }
            // order_values, order_logs = self._import_fill_order_prepare_vals(order, tree, order_values)
            // order.write(order_values)
            // logs += partner_logs + delivery_partner_logs + currency_logs + line_logs + allowance_charges_logs + order_logs
            // 
            // return logs
            */
            return default;
        }

        public async Task<TEntity> ImportFillOrderPrepareValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object order_values) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _import_fill_order_prepare_vals(self, order, tree, order_values):
            // """ Prepare order values before writing to the order.
            // 
            // :param order: Order to fill details from xml tree.
            // :param tree: Xml tree to extract details.
            // :param order_values: Values to write on the order.
            // :return: Tuple of order values and logs.
            // """
            // # Override this method if you need to add or modify values before writing
            // return order_values, []
            */
            return default;
        }

        public async Task<TEntity> ImportRetrieveDeliveryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _import_retrieve_delivery_vals(self, tree):
            // """ Returns a dict of values that will be used to retrieve the delivery address. """
            // return {
            //     'phone': self._find_value('.//cac:Delivery/cac:DeliveryParty//cbc:Telephone', tree),
            //     'email': self._find_value('.//cac:Delivery/cac:DeliveryParty//cbc:ElectronicMail', tree),
            //     'name': self._find_value('.//cac:Delivery/cac:DeliveryParty//cbc:Name', tree),
            // }
            */
            return default;
        }

        public async Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsCenEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> InvoiceConstraintsCenEn16931UblNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> InvoiceConstraintsPeppolEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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

        public async Task<TEntity> InvoiceConstraintsPeppolEn16931UblNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
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
    }
}