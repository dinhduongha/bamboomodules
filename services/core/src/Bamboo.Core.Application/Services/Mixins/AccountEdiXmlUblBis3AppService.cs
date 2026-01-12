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

        public async Task<TEntity> AddInvoiceAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_allowance_charge_nodes(self, document_node, vals):
            // # OVERRIDE
            // ubl_values = vals['_ubl_values']
            // document_node['cac:AllowanceCharge'] = [
            //     self._ubl_get_allowance_charge_early_payment(vals, early_payment_values)
            //     for early_payment_values in ubl_values['allowance_charges_early_payment_currency']
            // ]
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_config_vals(self, vals):
            // super()._add_invoice_config_vals(vals)
            // invoice = vals['invoice']
            // vals['process_type'] = 'selfbilling' if invoice.is_purchase_document() and invoice.journal_id.is_self_billing else 'billing'
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
            // shipping_partner = vals['partner_shipping']
            // 
            // intracom_delivery = (
            //     customer.country_id.code in (economic_area := self.env.ref('base.europe').country_ids.mapped('code') + ['NO'])
            //     and supplier.country_id.code in economic_area
            //     and supplier.country_id != customer.country_id
            // )
            // delivery_date = invoice.invoice_date if intracom_delivery else invoice.delivery_date
            // 
            // document_node['cac:Delivery'] = {
            //     'cbc:ActualDeliveryDate': {'_text': delivery_date},
            //     'cac:DeliveryParty': {
            //         'cac:PartyName': {
            //             'cbc:Name': {'_text': shipping_partner.name or customer.name},
            //         }
            //     },
            //     'cac:DeliveryLocation': {
            //         'cac:Address': self._get_address_node({'partner': shipping_partner})
            //     },
            // }
            // # TODO master: clean that code a bit hacky, when the module account_add_gln is merged with account
            // if gln := 'global_location_number' in shipping_partner._fields and shipping_partner.global_location_number:
            //     document_node['cac:Delivery']['cac:DeliveryLocation'].update({
            //         'cbc:ID': {'schemeID': '0088', '_text': gln},
            //     })
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
            //     'cbc:CustomizationID': {'_text': self._get_customization_id(vals['process_type'])},
            //     'cbc:ProfileID': {'_text': f"urn:fdc:peppol.eu:2017:poacc:{vals['process_type']}:01:1.0"},
            //     'cbc:TaxCurrencyCode': {'_text': vals['tax_currency_code']},
            // })
            // # For B2G transactions in Germany: set the buyer_reference to the Leitweg-ID (code 0204)
            // if invoice.commercial_partner_id.peppol_eas == '0204':
            //     document_node.update({
            //         'cbc:BuyerReference': {'_text': invoice.commercial_partner_id.peppol_endpoint}
            //     })
            // 
            // # [NL-R-001] For suppliers in the Netherlands, if the document is a creditnote, the document MUST
            // # contain an invoice reference (cac:BillingReference/cac:InvoiceDocumentReference/cbc:ID)
            // if vals['supplier'].country_id.code == 'NL' and 'refund' in invoice.move_type:
            //     document_node['cac:BillingReference'] = {
            //         'cac:InvoiceDocumentReference': {
            //             'cbc:ID': {'_text': invoice.ref},
            //         }
            //     }
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _add_invoice_header_nodes(self, document_node, vals):
            // # EXTENDS account.edi.xml.ubl_bis3
            // super()._add_invoice_header_nodes(document_node, vals)
            // if not document_node['cbc:BuyerReference']['_text']:
            //     document_node['cbc:BuyerReference']['_text'] = 'N/A'
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_line_allowance_charge_nodes(self, line_node, vals):
            // # OVERRIDE
            // base_line = vals['base_line']
            // ubl_values = base_line['_ubl_values']
            // allowance_charges_nodes = line_node['cac:AllowanceCharge'] = []
            // 
            // # Discount.
            // discount_values = ubl_values['allowance_charge_discount_currency']
            // if discount_values:
            //     allowance_charges_nodes.append(self._ubl_get_line_allowance_charge_discount_node(vals, discount_values))
            // 
            // # Recycling contribution taxes.
            // for recycling_contribution_values in base_line['_ubl_values']['allowance_charges_recycling_contribution_currency']:
            //     allowance_charges_nodes.append(self._ubl_get_line_allowance_charge_recycling_contribution_node(vals, recycling_contribution_values))
            // 
            // # Excise taxes.
            // for excise_values in base_line['_ubl_values']['allowance_charges_excise_currency']:
            //     allowance_charges_nodes.append(self._ubl_get_line_allowance_charge_excise_node(vals, excise_values))
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_line_amount_nodes(self, line_node, vals):
            // # OVERRIDE
            // base_line = vals['base_line']
            // currency = vals['currency_id']
            // 
            // quantity_tag = self._get_tags_for_document_type(vals)['line_quantity']
            // 
            // line_node.update({
            //     quantity_tag: {
            //         '_text': base_line['quantity'],
            //         'unitCode': self._get_uom_unece_code(base_line['product_uom_id']),
            //     },
            //     'cbc:LineExtensionAmount': {
            //         '_text': FloatFmt(base_line['_ubl_values']['line_extension_amount'], min_dp=currency.decimal_places),
            //         'currencyID': currency.name,
            //     },
            // })
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_line_item_nodes(self, line_node, vals):
            // # OVERRIDE
            // item_values = vals['base_line']['_ubl_values']['item_currency']
            // line_node['cac:Item'] = self._ubl_get_line_item_node(vals, item_values)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_line_price_nodes(self, line_node, vals):
            // # OVERRIDE
            // base_line = vals['base_line']
            // ubl_values = base_line['_ubl_values']
            // 
            // line_node['cac:Price'] = {
            //     'cbc:PriceAmount': {
            //         '_text': FloatFmt(ubl_values['price_amount_currency'], min_dp=1, max_dp=6),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_line_tax_category_nodes(self, line_node, vals):
            // # OVERRIDE
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_line_tax_total_nodes(self, line_node, vals):
            // # OVERRIDE
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_line_vals(self, vals):
            // # OVERRIDE
            // # Those temporary values are wrongly computed and the similar data are added to the base lines in
            // # 'setup_base_lines' because we need to compute them on all lines at once instead of on each line
            // # separately.
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_monetary_total_nodes(self, document_node, vals):
            // monetary_total_tag = self._get_tags_for_document_type(vals)['monetary_total']
            // ubl_values = vals['_ubl_values']
            // invoice = vals['invoice']
            // line_tag = self._get_tags_for_document_type(vals)['document_line']
            // 
            // line_extension_amount = sum(
            //     line_node['cbc:LineExtensionAmount']['_text']
            //     for line_node in document_node[line_tag]
            // )
            // tax_amount = sum(
            //     tax_total['cbc:TaxAmount']['_text']
            //     for tax_total in document_node['cac:TaxTotal']
            //     if tax_total['cbc:TaxAmount']['currencyID'] == vals['currency_id'].name
            // )
            // total_allowance = sum(
            //     allowance_charge['cbc:Amount']['_text']
            //     for allowance_charge in document_node['cac:AllowanceCharge']
            //     if allowance_charge['cbc:ChargeIndicator']['_text'] == 'false'
            // )
            // total_charge = sum(
            //     allowance_charge['cbc:Amount']['_text']
            //     for allowance_charge in document_node['cac:AllowanceCharge']
            //     if allowance_charge['cbc:ChargeIndicator']['_text'] == 'true'
            // )
            // payable_rounding_amount = ubl_values['payable_rounding_amount_currency']
            // 
            // document_node[monetary_total_tag] = {
            //     'cbc:LineExtensionAmount': {
            //         '_text': FloatFmt(line_extension_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:TaxExclusiveAmount': {
            //         '_text': FloatFmt(line_extension_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:TaxInclusiveAmount': {
            //         '_text': FloatFmt(line_extension_amount + tax_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:AllowanceTotalAmount': {
            //         '_text': FloatFmt(total_allowance, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if total_allowance else None,
            //     'cbc:ChargeTotalAmount': {
            //         '_text': FloatFmt(total_charge, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if total_charge else None,
            //     'cbc:PrepaidAmount': {
            //         '_text': FloatFmt(invoice.amount_total - invoice.amount_residual, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:PayableRoundingAmount': {
            //         '_text': FloatFmt(payable_rounding_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if payable_rounding_amount else None,
            //     'cbc:PayableAmount': {
            //         '_text': FloatFmt(invoice.amount_residual, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_monetary_total_vals(self, vals):
            // # OVERRIDE
            // pass
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _add_invoice_payment_means_nodes(self, document_node, vals):
            // # EXTENDS account.edi.xml.ubl_bis3
            // super()._add_invoice_payment_means_nodes(document_node, vals)
            // # [BR-NL-29] The use of a payment means text (cac:PaymentMeans/cbc:PaymentMeansCode/@name) is not recommended
            // payment_means_node = document_node['cac:PaymentMeans']
            // if 'name' in payment_means_node['cbc:PaymentMeansCode']:
            //     payment_means_node['cbc:PaymentMeansCode']['name'] = None
            // if 'listID' in payment_means_node['cbc:PaymentMeansCode']:
            //     payment_means_node['cbc:PaymentMeansCode']['listID'] = None
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _add_invoice_payment_means_nodes(self, document_node, vals):
            // """ https://www.peppolguide.sg/billing/bis/#_payment_means_information """
            // super()._add_invoice_payment_means_nodes(document_node, vals)
            // document_node['cac:PaymentMeans']['cbc:PaymentMeansCode'] = {
            //     '_text': 54,
            //     'name': 'Credit Card',
            // }
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _add_invoice_tax_total_nodes(self, document_node, vals):
            // # OVERRIDE
            // document_node['cac:TaxTotal'] = [
            //     self._ubl_get_tax_total_node(vals, tax_total)
            //     for tax_total in vals['_ubl_values']['tax_totals_currency'].values()
            // ]
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _add_invoice_tax_total_nodes(self, document_node, vals):
            // # OVERRIDE
            // ubl_values = vals['_ubl_values']
            // company = vals['company']
            // company_currency = company.currency_id
            // currency = vals['currency_id']
            // 
            // tax_total_nodes = document_node['cac:TaxTotal'] = []
            // for tax_total in ubl_values['tax_totals_currency'].values():
            //     tax_total_node = self._ubl_get_tax_total_node(vals, tax_total)
            //     tax_total_nodes.append(tax_total_node)
            // 
            // # Only one subtotal expressed in foreign currency in case of multi currencies.
            // if currency != company_currency:
            //     for tax_total in ubl_values['tax_totals'].values():
            //         tax_total_node = self._ubl_get_tax_total_node(vals, tax_total)
            //         tax_total_node['cac:TaxSubtotal'] = []
            //         tax_total_nodes.append(tax_total_node)
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _add_invoice_tax_total_nodes(self, document_node, vals):
            // # OVERRIDE
            // document_node['cac:TaxTotal'] = [
            //     self._ubl_get_tax_total_node(vals, tax_total)
            //     for tax_total in vals['_ubl_values']['tax_totals_currency'].values()
            // ]
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _add_invoice_tax_total_nodes(self, document_node, vals):
            // # OVERRIDE
            // document_node['cac:TaxTotal'] = [
            //     self._ubl_get_tax_total_node(vals, tax_total)
            //     for tax_total in vals['_ubl_values']['tax_totals_currency'].values()
            // ]
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _add_invoice_tax_total_nodes(self, document_node, vals):
            // # OVERRIDE
            // document_node['cac:TaxTotal'] = [
            //     self._ubl_get_tax_total_node(vals, tax_total)
            //     for tax_total in vals['_ubl_values']['tax_totals_currency'].values()
            // ]
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_allowance_charge_nodes(self, document_node, vals):
            // # OVERRIDE
            // ubl_values = vals['_ubl_values']
            // document_node['cac:AllowanceCharge'] = [
            //     self._ubl_get_allowance_charge_early_payment(vals, early_payment_values)
            //     for early_payment_values in ubl_values['allowance_charges_early_payment_currency']
            // ]
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_base_lines_vals(self, vals):
            // purchase_order = vals['purchase_order']
            // AccountTax = self.env['account.tax']
            // 
            // base_lines = [line._prepare_base_line_for_taxes_computation() for line in purchase_order.order_line.filtered(lambda line: not line.display_type)]
            // AccountTax._add_tax_details_in_base_lines(base_lines, purchase_order.company_id)
            // AccountTax._round_base_lines_tax_details(base_lines, purchase_order.company_id)
            // 
            // vals['base_lines'] = base_lines
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderBuyerCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_buyer_customer_party_nodes(self, document_node, vals):
            // document_node['cac:BuyerCustomerParty'] = {
            //     'cac:Party': self._get_party_node({**vals, 'partner': vals['customer'], 'role': 'customer'})
            // }
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_config_vals(self, vals):
            // purchase_order = vals['purchase_order']
            // supplier = purchase_order.partner_id
            // customer = purchase_order.company_id.partner_id.commercial_partner_id
            // 
            // customer_delivery_address = customer.child_ids.filtered(lambda child: child.type == 'delivery')
            // partner_shipping = (
            //     purchase_order.dest_address_id
            //     or (customer_delivery_address and customer_delivery_address[0])
            //     or customer
            // )
            // 
            // vals.update({
            //     'document_type': 'order',
            // 
            //     'supplier': supplier,
            //     'customer': customer,
            //     'partner_shipping': partner_shipping,
            // 
            //     'company': purchase_order.company_id,
            //     'currency_id': purchase_order.currency_id,
            //     'company_currency_id': purchase_order.company_id.currency_id,
            // 
            //     'use_company_currency': False,  # If true, use the company currency for the amounts instead of the order currency
            //     'fixed_taxes_as_allowance_charges': True,  # If true, include fixed taxes as AllowanceCharges on lines instead of as taxes
            // })
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_currency_vals(self, vals):
            // self._add_document_currency_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_delivery_nodes(self, document_node, vals):
            // document_node['cac:Delivery'] = {
            //     'cac:DeliveryParty': self._get_party_node({**vals, 'partner': vals['partner_shipping'], 'role': 'delivery'})
            // }
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_header_nodes(self, document_node, vals):
            // purchase_order = vals['purchase_order']
            // document_node.update({
            //     'cbc:CustomizationID': {'_text': 'urn:fdc:peppol.eu:poacc:trns:order:3'},
            //     'cbc:ProfileID': {'_text': 'urn:fdc:peppol.eu:poacc:bis:ordering:3'},
            //     'cbc:ID': {'_text': purchase_order.name},
            //     'cbc:IssueDate': {'_text': purchase_order.create_date.date()},
            //     'cbc:OrderTypeCode': {'_text': '105'},
            //     'cbc:Note': {'_text': html2plaintext(purchase_order.note)} if purchase_order.note else None,
            //     'cbc:DocumentCurrencyCode': {'_text': vals['currency_name']},
            //     'cac:QuotationDocumentReference': {
            //         'cbc:ID': {'_text': purchase_order.partner_ref}
            //     },
            // })
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_line_allowance_charge_nodes(self, line_node, vals):
            // # OVERRIDE
            // base_line = vals['base_line']
            // ubl_values = base_line['_ubl_values']
            // allowance_charges_nodes = line_node['cac:AllowanceCharge'] = []
            // 
            // # Discount.
            // discount_values = ubl_values['allowance_charge_discount_currency']
            // if discount_values:
            //     allowance_charges_nodes.append(self._ubl_get_line_allowance_charge_discount_node(vals, discount_values))
            // 
            // # Recycling contribution taxes.
            // for recycling_contribution_values in base_line['_ubl_values']['allowance_charges_recycling_contribution_currency']:
            //     allowance_charges_nodes.append(self._ubl_get_line_allowance_charge_recycling_contribution_node(vals, recycling_contribution_values))
            // 
            // # Excise taxes.
            // for excise_values in base_line['_ubl_values']['allowance_charges_excise_currency']:
            //     allowance_charges_nodes.append(self._ubl_get_line_allowance_charge_excise_node(vals, excise_values))
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_line_amount_nodes(self, line_node, vals):
            // # OVERRIDE
            // base_line = vals['base_line']
            // currency = vals['currency_id']
            // 
            // quantity_tag = self._get_tags_for_document_type(vals)['line_quantity']
            // 
            // line_node.update({
            //     quantity_tag: {
            //         '_text': base_line['quantity'],
            //         'unitCode': self._get_uom_unece_code(base_line['product_uom_id']),
            //     },
            //     'cbc:LineExtensionAmount': {
            //         '_text': FloatFmt(base_line['_ubl_values']['line_extension_amount'], min_dp=currency.decimal_places),
            //         'currencyID': currency.name,
            //     },
            // })
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_line_id_nodes(self, line_node, vals):
            // self._add_document_line_id_nodes(line_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_line_item_nodes(self, line_node, vals):
            // # OVERRIDE
            // item_values = vals['base_line']['_ubl_values']['item_currency']
            // line_item_node = self._ubl_get_line_item_node(vals, item_values)
            // 
            // base_line = item_values['base_line']
            // product = base_line['product_id']
            // partner = base_line['partner_id']
            // supplier_info = product.variant_seller_ids.filtered(lambda s:
            //     s.partner_id == partner
            //     and (
            //         s.product_id == product
            //         or (not s.product_id and s.product_tmpl_id == product.product_tmpl_id)
            //     )
            //     and (s.product_code or s.product_name),
            // )[:1]
            // 
            // # Prefer the seller's product name over our (buyer) product name
            // if supplier_info.product_name:
            //     line_item_node['cbc:Name']['_text'] = supplier_info.product_name
            // 
            // # When generating purchase order (PO) we are not considered as the seller of the sale but
            // # buyer. The `SellersItemIdentification` is therefore the PO's partner product ID.
            // line_item_node['cac:SellersItemIdentification'] = {
            //     'cbc:ID': {'_text': supplier_info.product_code or None},
            // }
            // 
            // line_node['cac:Item'] = line_item_node
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_line_nodes(self, document_node, vals):
            // document_node['cac:OrderLine'] = order_line_nodes = []
            // 
            // line_idx = 1
            // for base_line in vals['base_lines']:
            //     line_vals = {
            //         **vals,
            //         'line_idx': line_idx,
            //         'base_line': base_line,
            //     }
            // 
            //     line_node = {}
            //     self._add_purchase_order_line_id_nodes(line_node, line_vals)
            //     self._add_purchase_order_line_amount_nodes(line_node, line_vals)
            //     self._add_purchase_order_line_allowance_charge_nodes(line_node, line_vals)
            //     self._add_purchase_order_line_item_nodes(line_node, line_vals)
            //     self._add_purchase_order_line_price_nodes(line_node, line_vals)
            // 
            //     order_line_nodes.append({
            //         'cac:LineItem': line_node,
            //     })
            //     line_idx += 1
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_line_price_nodes(self, line_node, vals):
            // # OVERRIDE
            // base_line = vals['base_line']
            // ubl_values = base_line['_ubl_values']
            // 
            // line_node['cac:Price'] = {
            //     'cbc:PriceAmount': {
            //         '_text': FloatFmt(ubl_values['price_amount_currency'], min_dp=1, max_dp=6),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_monetary_total_nodes(self, document_node, vals):
            // ubl_values = vals['_ubl_values']
            // line_tag = self._get_tags_for_document_type(vals)['document_line']
            // 
            // line_extension_amount = sum(
            //     line_node['cac:LineItem']['cbc:LineExtensionAmount']['_text']
            //     for line_node in document_node[line_tag]
            // )
            // tax_amount = sum(
            //     tax_total['cbc:TaxAmount']['_text']
            //     for tax_total in document_node['cac:TaxTotal']
            //     if tax_total['cbc:TaxAmount']['currencyID'] == vals['currency_id'].name
            // )
            // total_allowance = sum(
            //     allowance_charge['cbc:Amount']['_text']
            //     for allowance_charge in document_node['cac:AllowanceCharge']
            //     if allowance_charge['cbc:ChargeIndicator']['_text'] == 'false'
            // )
            // total_charge = sum(
            //     allowance_charge['cbc:Amount']['_text']
            //     for allowance_charge in document_node['cac:AllowanceCharge']
            //     if allowance_charge['cbc:ChargeIndicator']['_text'] == 'true'
            // )
            // payable_rounding_amount = ubl_values['payable_rounding_amount_currency']
            // 
            // document_node['cac:AnticipatedMonetaryTotal'] = {
            //     'cbc:LineExtensionAmount': {
            //         '_text': FloatFmt(line_extension_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:TaxExclusiveAmount': {
            //         '_text': FloatFmt(line_extension_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:TaxInclusiveAmount': {
            //         '_text': FloatFmt(line_extension_amount + tax_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:AllowanceTotalAmount': {
            //         '_text': FloatFmt(total_allowance, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if total_allowance else None,
            //     'cbc:ChargeTotalAmount': {
            //         '_text': FloatFmt(total_charge, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if total_charge else None,
            //     'cbc:PrepaidAmount': {
            //         '_text': FloatFmt(0.0, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:PayableRoundingAmount': {
            //         '_text': FloatFmt(payable_rounding_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if payable_rounding_amount else None,
            //     'cbc:PayableAmount': {
            //         '_text': FloatFmt(line_extension_amount + tax_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_monetary_totals_vals(self, vals):
            // self._add_document_monetary_total_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderPaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_payment_terms_nodes(self, document_node, vals):
            // purchase_order = vals['purchase_order']
            // if purchase_order.payment_term_id:
            //     document_node['cac:PaymentTerms'] = {
            //         'cbc:Note': {'_text': purchase_order.payment_term_id.name}
            //     }
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_seller_supplier_party_nodes(self, document_node, vals):
            // document_node['cac:SellerSupplierParty'] = {
            //     'cac:Party': self._get_party_node({**vals, 'partner': vals['supplier'], 'role': 'supplier'})
            // }
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_tax_grouping_function_vals(self, vals):
            // self._add_document_tax_grouping_function_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddPurchaseOrderTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _add_purchase_order_tax_total_nodes(self, document_node, vals):
            // # OVERRIDE
            // ubl_values = vals['_ubl_values']
            // company = vals['company']
            // company_currency = company.currency_id
            // currency = vals['currency_id']
            // 
            // tax_total_nodes = document_node['cac:TaxTotal'] = []
            // for tax_total in ubl_values['tax_totals_currency'].values():
            //     tax_total_node = self._ubl_get_tax_total_node(vals, tax_total)
            //     tax_total_nodes.append(tax_total_node)
            // 
            // # Only one subtotal expressed in foreign currency in case of multi currencies.
            // if currency != company_currency:
            //     for tax_total in ubl_values['tax_totals'].values():
            //         tax_total_node = self._ubl_get_tax_total_node(vals, tax_total)
            //         tax_total_node['cac:TaxSubtotal'] = []
            //         tax_total_nodes.append(tax_total_node)
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_allowance_charge_nodes(self, document_node, vals):
            // # OVERRIDE
            // ubl_values = vals['_ubl_values']
            // document_node['cac:AllowanceCharge'] = [
            //     self._ubl_get_allowance_charge_early_payment(vals, early_payment_values)
            //     for early_payment_values in ubl_values['allowance_charges_early_payment_currency']
            // ]
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_base_lines_vals(self, vals):
            // sale_order = vals['sale_order']
            // AccountTax = self.env['account.tax']
            // 
            // base_lines = [line._prepare_base_line_for_taxes_computation() for line in sale_order.order_line.filtered(lambda line: not line.display_type)]
            // AccountTax._add_tax_details_in_base_lines(base_lines, sale_order.company_id)
            // AccountTax._round_base_lines_tax_details(base_lines, sale_order.company_id)
            // 
            // vals['base_lines'] = base_lines
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderBuyerCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_buyer_customer_party_nodes(self, document_node, vals):
            // document_node['cac:BuyerCustomerParty'] = {
            //     'cac:Party': self._get_party_node({**vals, 'partner': vals['customer'], 'role': 'customer'})
            // }
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_config_vals(self, vals):
            // sale_order = vals['sale_order']
            // supplier = sale_order.company_id.partner_id.commercial_partner_id
            // customer = sale_order.partner_id
            // 
            // customer_delivery_address = customer.child_ids.filtered(lambda child: child.type == 'delivery')
            // partner_shipping = (
            //     sale_order.partner_shipping_id
            //     or (customer_delivery_address and customer_delivery_address[0])
            //     or customer
            // )
            // vals.update({
            //     'document_type': 'order',
            // 
            //     'supplier': supplier,
            //     'customer': customer,
            //     'partner_shipping': partner_shipping,
            // 
            //     'company': sale_order.company_id,
            //     'currency_id': sale_order.currency_id,
            //     'company_currency_id': sale_order.company_id.currency_id,
            // 
            //     'use_company_currency': False,  # If true, use the company currency for the amounts instead of the order currency
            //     'fixed_taxes_as_allowance_charges': True,  # If true, include fixed taxes as AllowanceCharges on lines instead of as taxes
            // })
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_currency_vals(self, vals):
            // self._add_document_currency_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_delivery_nodes(self, document_node, vals):
            // document_node['cac:Delivery'] = {
            //     'cac:DeliveryParty': self._get_party_node({**vals, 'partner': vals['partner_shipping'], 'role': 'delivery'})
            // }
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_header_nodes(self, document_node, vals):
            // sale_order = vals['sale_order']
            // document_node.update({
            //     'cbc:CustomizationID': {'_text': 'urn:fdc:peppol.eu:poacc:trns:order:3'},
            //     'cbc:ProfileID': {'_text': 'urn:fdc:peppol.eu:poacc:bis:ordering:3'},
            //     'cbc:ID': {'_text': sale_order.name},
            //     'cbc:IssueDate': {'_text': sale_order.create_date.date()},
            //     'cbc:OrderTypeCode': {'_text': '220'},
            //     'cbc:Note': {'_text': html2plaintext(sale_order.note)} if sale_order.note else None,
            //     'cbc:DocumentCurrencyCode': {'_text': vals['currency_name']},
            //     'cac:ValidityPeriod': {
            //         'cbc:EndDate': {'_text': sale_order.validity_date},
            //     },
            //     'cac:OriginatorDocumentReference': {
            //         'cbc:ID': {'_text': sale_order.client_order_ref}
            //     },
            // })
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_line_allowance_charge_nodes(self, line_node, vals):
            // # OVERRIDE
            // base_line = vals['base_line']
            // ubl_values = base_line['_ubl_values']
            // allowance_charges_nodes = line_node['cac:AllowanceCharge'] = []
            // 
            // # Discount.
            // discount_values = ubl_values['allowance_charge_discount_currency']
            // if discount_values:
            //     allowance_charges_nodes.append(self._ubl_get_line_allowance_charge_discount_node(vals, discount_values))
            // 
            // # Recycling contribution taxes.
            // for recycling_contribution_values in base_line['_ubl_values']['allowance_charges_recycling_contribution_currency']:
            //     allowance_charges_nodes.append(self._ubl_get_line_allowance_charge_recycling_contribution_node(vals, recycling_contribution_values))
            // 
            // # Excise taxes.
            // for excise_values in base_line['_ubl_values']['allowance_charges_excise_currency']:
            //     allowance_charges_nodes.append(self._ubl_get_line_allowance_charge_excise_node(vals, excise_values))
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_line_amount_nodes(self, line_node, vals):
            // # OVERRIDE
            // base_line = vals['base_line']
            // currency = vals['currency_id']
            // 
            // line_node.update({
            //     'cbc:Quantity': {
            //         '_text': base_line['quantity'],
            //         'unitCode': self._get_uom_unece_code(base_line['product_uom_id']),
            //     },
            //     'cbc:LineExtensionAmount': {
            //         '_text': FloatFmt(base_line['_ubl_values']['line_extension_amount'], min_dp=currency.decimal_places),
            //         'currencyID': currency.name,
            //     },
            // })
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_line_id_nodes(self, line_node, vals):
            // self._add_document_line_id_nodes(line_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_line_item_nodes(self, line_node, vals):
            // # OVERRIDE
            // item_values = vals['base_line']['_ubl_values']['item_currency']
            // line_node['cac:Item'] = self._ubl_get_line_item_node(vals, item_values)
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_line_nodes(self, document_node, vals):
            // document_node['cac:OrderLine'] = order_line_nodes = []
            // 
            // line_idx = 1
            // for base_line in vals['base_lines']:
            //     line_vals = {
            //         **vals,
            //         'line_idx': line_idx,
            //         'base_line': base_line,
            //     }
            //     self._add_sale_order_line_vals(line_vals)
            // 
            //     line_node = {}
            //     self._add_sale_order_line_id_nodes(line_node, line_vals)
            //     self._add_sale_order_line_amount_nodes(line_node, line_vals)
            //     self._add_sale_order_line_allowance_charge_nodes(line_node, line_vals)
            //     self._add_sale_order_line_item_nodes(line_node, line_vals)
            //     self._add_sale_order_line_price_nodes(line_node, line_vals)
            // 
            //     order_line_nodes.append({
            //         'cac:LineItem': line_node,
            //     })
            //     line_idx += 1
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_line_price_nodes(self, line_node, vals):
            // # OVERRIDE
            // base_line = vals['base_line']
            // ubl_values = base_line['_ubl_values']
            // 
            // line_node['cac:Price'] = {
            //     'cbc:PriceAmount': {
            //         '_text': FloatFmt(ubl_values['price_amount_currency'], min_dp=1, max_dp=6),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_line_vals(self, vals):
            // self._add_document_line_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_monetary_total_nodes(self, document_node, vals):
            // ubl_values = vals['_ubl_values']
            // sale_order = vals['sale_order']
            // 
            // line_extension_amount = sum(
            //     line_node['cac:LineItem']['cbc:LineExtensionAmount']['_text']
            //     for line_node in document_node['cac:OrderLine']
            // )
            // tax_amount = sum(
            //     tax_total['cbc:TaxAmount']['_text']
            //     for tax_total in document_node['cac:TaxTotal']
            //     if tax_total['cbc:TaxAmount']['currencyID'] == vals['currency_id'].name
            // )
            // total_allowance = sum(
            //     allowance_charge['cbc:Amount']['_text']
            //     for allowance_charge in document_node['cac:AllowanceCharge']
            //     if allowance_charge['cbc:ChargeIndicator']['_text'] == 'false'
            // )
            // total_charge = sum(
            //     allowance_charge['cbc:Amount']['_text']
            //     for allowance_charge in document_node['cac:AllowanceCharge']
            //     if allowance_charge['cbc:ChargeIndicator']['_text'] == 'true'
            // )
            // payable_rounding_amount = ubl_values['payable_rounding_amount_currency']
            // 
            // document_node['cac:AnticipatedMonetaryTotal'] = {
            //     'cbc:LineExtensionAmount': {
            //         '_text': FloatFmt(line_extension_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:TaxExclusiveAmount': {
            //         '_text': FloatFmt(line_extension_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:TaxInclusiveAmount': {
            //         '_text': FloatFmt(line_extension_amount + tax_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:AllowanceTotalAmount': {
            //         '_text': FloatFmt(total_allowance, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if total_allowance else None,
            //     'cbc:ChargeTotalAmount': {
            //         '_text': FloatFmt(total_charge, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if total_charge else None,
            //     'cbc:PrepaidAmount': {
            //         '_text': FloatFmt(sale_order.amount_paid, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:PayableRoundingAmount': {
            //         '_text': FloatFmt(payable_rounding_amount, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if payable_rounding_amount else None,
            //     'cbc:PayableAmount': {
            //         '_text': FloatFmt(sale_order.amount_total - sale_order.amount_paid, min_dp=vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_monetary_totals_vals(self, vals):
            // self._add_document_monetary_total_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderPaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_payment_terms_nodes(self, document_node, vals):
            // sale_order = vals['sale_order']
            // if sale_order.payment_term_id:
            //     document_node['cac:PaymentTerms'] = {
            //         'cbc:Note': {'_text': sale_order.payment_term_id.name}
            //     }
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_seller_supplier_party_nodes(self, document_node, vals):
            // document_node['cac:SellerSupplierParty'] = {
            //     'cac:Party': self._get_party_node({**vals, 'partner': vals['supplier'], 'role': 'supplier'})
            // }
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_tax_grouping_function_vals(self, vals):
            // self._add_document_tax_grouping_function_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddSaleOrderTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _add_sale_order_tax_total_nodes(self, document_node, vals):
            // # OVERRIDE
            // ubl_values = vals['_ubl_values']
            // company = vals['company']
            // company_currency = company.currency_id
            // currency = vals['currency_id']
            // 
            // tax_total_nodes = document_node['cac:TaxTotal'] = []
            // for tax_total in ubl_values['tax_totals_currency'].values():
            //     tax_total_node = self._ubl_get_tax_total_node(vals, tax_total)
            //     tax_total_nodes.append(tax_total_node)
            // 
            // # Only one subtotal expressed in foreign currency in case of multi currencies.
            // if currency != company_currency:
            //     for tax_total in ubl_values['tax_totals'].values():
            //         tax_total_node = self._ubl_get_tax_total_node(vals, tax_total)
            //         tax_total_node['cac:TaxSubtotal'] = []
            //         tax_total_nodes.append(tax_total_node)
            */
            return default;
        }

        public async Task<TEntity> CanExportSelfbillingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _can_export_selfbilling(self):
            // return bool(self._get_customization_id(process_type='selfbilling'))
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
            //     'bis3_de_supplier_telephone_required': self._check_required_fields(vals['supplier'], ['phone']),
            //     'bis3_de_supplier_electronic_mail_required': self._check_required_fields(vals['supplier'], 'email'),
            // })
            // 
            // return constraints
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

        public async Task<TEntity> ExportOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sale_order) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _export_order(self, purchase_order):
            // vals = {'purchase_order': purchase_order}
            // document_node = self._get_purchase_order_node(vals)
            // xml_content = dict_to_xml(document_node, template=Order, nsmap=self._get_document_nsmap(vals))
            // return etree.tostring(xml_content, xml_declaration=True, encoding='UTF-8')
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _export_order(self, sale_order):
            // vals = {'sale_order': sale_order}
            // document_node = self._get_sale_order_node(vals)
            // xml_content = dict_to_xml(document_node, template=Order, nsmap=self._get_document_nsmap(vals))
            // return etree.tostring(xml_content, xml_declaration=True, encoding='UTF-8')
            */
            return default;
        }

        public async Task<TEntity> ExportOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sale_order) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _export_order_vals(self, sale_order):
            // vals = super()._export_order_vals(sale_order)
            // 
            // customer = sale_order.partner_id
            // supplier = sale_order.company_id.partner_id
            // customer_delivery_address = customer.child_ids.filtered(lambda child: child.type == 'delivery')
            // delivery = (sale_order.partner_shipping_id
            //             or (customer_delivery_address and customer_delivery_address[0])
            //             or customer)
            // order_line_vals = self._get_order_line_vals(sale_order.order_line, customer, supplier)
            // 
            // vals['vals'].update({
            //     'order_type_code': 220,
            //     'validity_date': sale_order.validity_date,
            //     'originator_document_reference': sale_order.client_order_ref,
            //     'customer_party_vals': self._get_partner_party_vals(customer, role='customer'),
            //     'supplier_party_vals': self._get_partner_party_vals(supplier, role='supplier'),
            //     'delivery_party_vals': self._get_partner_party_vals(delivery, role='delivery'),
            //     'anticipated_monetary_total_vals': self._get_anticipated_monetary_total_vals(order_line_vals, sale_order.currency_id, sale_order.amount_total, sale_order.amount_paid),
            //     'order_lines': order_line_vals,
            // })
            // return vals
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_address_node(self, vals):
            // # EXTENDS account.edi.xml.ubl_bis3
            // address_node = super()._get_address_node(vals)
            // # [BR-NL-28] The use of a country subdivision (cac:AccountingCustomerParty/cac:Party/cac:PostalAddress
            // # /cbc:CountrySubentity) is not recommended
            // address_node['cbc:CountrySubentity'] = None
            // return address_node
            */
            return default;
        }

        public async Task<TEntity> GetCustomizationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object process_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _get_customization_id(self, process_type='billing'):
            // if process_type == 'billing':
            //     return 'urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:aunz:3.0'
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_customization_id(self, process_type: Literal['billing', 'selfbilling'] = 'billing'):
            // if process_type == 'billing':
            //     return 'urn:cen.eu:en16931:2017#compliant#urn:fdc:peppol.eu:2017:poacc:billing:3.0'
            // else:
            //     return 'urn:cen.eu:en16931:2017#compliant#urn:fdc:peppol.eu:2017:poacc:selfbilling:3.0'
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_customization_id(self, process_type='billing'):
            // if process_type == 'billing':
            //     return 'urn:cen.eu:en16931:2017#compliant#urn:fdc:nen.nl:nlcius:v1.0'
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _get_customization_id(self, process_type='billing'):
            // if process_type == 'billing':
            //     return 'urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:sg:3.0'
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _get_customization_id(self, process_type='billing'):
            // if process_type == 'billing':
            //     return 'urn:cen.eu:en16931:2017#compliant#urn:xeinkauf.de:kosit:xrechnung_3.0'
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
            //     if financial_account_node['cac:FinancialInstitutionBranch']['cbc:ID']:
            //         financial_account_node['cac:FinancialInstitutionBranch']['cbc:ID']['schemeID'] = None
            // 
            // return financial_account_node
            */
            return default;
        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _get_line_xpaths(self, document_type=False, qty_factor=1):
            // if document_type == 'order':
            //     return {
            //         **super()._get_line_xpaths(document_type=document_type, qty_factor=qty_factor),
            //         'delivered_qty': ('./{*}Quantity'),
            //     }
            // return super()._get_line_xpaths(document_type=document_type, qty_factor=qty_factor)
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _get_party_node(self, vals):
            // # EXTENDS account.edi.xml.ubl_bis3
            // party_node = super()._get_party_node(vals)
            // partner = vals['partner']
            // commercial_partner = partner.commercial_partner_id
            // 
            // if commercial_partner.country_code == 'AU' and commercial_partner.vat:
            //     vat = commercial_partner.vat.replace(" ", "")
            //     party_node['cbc:EndpointID']['_text'] = vat
            //     party_node['cac:PartyTaxScheme'][0]['cbc:CompanyID']['_text'] = vat
            //     party_node['cac:PartyLegalEntity']['cbc:CompanyID'] = {
            //         '_text': vat,
            //         'schemeID': '0151',
            //     }
            // 
            // elif commercial_partner.country_code == 'NZ':
            //     party_node['cbc:EndpointID']['_text'] = commercial_partner.company_registry
            //     party_node['cac:PartyTaxScheme'][0]['cbc:CompanyID']['_text'] = commercial_partner.company_registry
            //     party_node['cac:PartyLegalEntity']['cbc:CompanyID'] = {
            //         '_text': commercial_partner.company_registry,
            //         'schemeID': '0088',
            //     }
            // 
            // party_node['cac:PartyTaxScheme'][0]['cac:TaxScheme']['cbc:ID']['_text'] = 'GST'
            // 
            // return party_node
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
            // if commercial_partner.country_code == 'NL' and commercial_partner.peppol_endpoint:
            //     # [UBL-SR-16] Buyer identifier shall occur maximum once
            //     if role == 'customer':
            //         party_node['cac:PartyIdentification'] = [{'cbc:ID': {'_text': commercial_partner.peppol_endpoint}}]
            //     else:
            //         party_node['cac:PartyIdentification'] = [
            //             party_node['cac:PartyIdentification'],
            //             {
            //                 'cbc:ID': {'_text': commercial_partner.peppol_endpoint}
            //             }
            //         ]
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
            //         'schemeID': '0190' if nl_id and len(nl_id) == 20 else '0106'
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _get_party_node(self, vals):
            // # EXTENDS account.edi.xml.ubl_bis3
            // party_node = super()._get_party_node(vals)
            // party_node['cac:PartyTaxScheme'][0]['cac:TaxScheme']['cbc:ID']['_text'] = 'GST'
            // return party_node
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _get_party_node(self, vals):
            // # EXTENDS account.edi.xml.ubl_bis3
            // party_node = super()._get_party_node(vals)
            // partner = vals['partner']
            // if not party_node.get('cbc:EndpointID', {}).get('_text') and partner.email:
            //     party_node['cbc:EndpointID'] = {
            //         '_text': partner.email,
            //         'schemeID': 'EM'
            //     }
            // return party_node
            */
            return default;
        }

        public async Task<TEntity> GetProductXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _get_product_xpaths(self):
            // """Override of `account.edi.xml.ubl_bis3` to support the `ExtendedID` field used to
            // identify product variants."""
            // return {
            //     **super()._get_product_xpaths(),
            //     'variant_barcode': './cac:Item/cac:StandardItemIdentification/cbc:ExtendedID',
            //     'variant_default_code': './cac:Item/cac:SellersItemIdentification/cbc:ExtendedID',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPurchaseOrderNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _get_purchase_order_node(self, vals):
            // self._add_purchase_order_config_vals(vals)
            // self._add_purchase_order_base_lines_vals(vals)
            // self._add_purchase_order_currency_vals(vals)
            // self._add_purchase_order_tax_grouping_function_vals(vals)
            // self._setup_base_lines(vals)
            // self._add_purchase_order_monetary_totals_vals(vals)
            // 
            // document_node = {}
            // self._add_purchase_order_header_nodes(document_node, vals)
            // self._add_purchase_order_buyer_customer_party_nodes(document_node, vals)
            // self._add_purchase_order_seller_supplier_party_nodes(document_node, vals)
            // self._add_purchase_order_delivery_nodes(document_node, vals)
            // self._add_purchase_order_payment_terms_nodes(document_node, vals)
            // self._add_purchase_order_line_nodes(document_node, vals)
            // self._add_purchase_order_allowance_charge_nodes(document_node, vals)
            // self._add_purchase_order_tax_total_nodes(document_node, vals)
            // self._add_purchase_order_monetary_total_nodes(document_node, vals)
            // return document_node
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _get_sale_order_node(self, vals):
            // self._add_sale_order_config_vals(vals)
            // self._add_sale_order_base_lines_vals(vals)
            // self._add_sale_order_currency_vals(vals)
            // self._add_sale_order_tax_grouping_function_vals(vals)
            // self._setup_base_lines(vals)
            // self._add_sale_order_monetary_totals_vals(vals)
            // 
            // document_node = {}
            // self._add_sale_order_header_nodes(document_node, vals)
            // self._add_sale_order_buyer_customer_party_nodes(document_node, vals)
            // self._add_sale_order_seller_supplier_party_nodes(document_node, vals)
            // self._add_sale_order_delivery_nodes(document_node, vals)
            // self._add_sale_order_payment_terms_nodes(document_node, vals)
            // self._add_sale_order_line_nodes(document_node, vals)
            // self._add_sale_order_allowance_charge_nodes(document_node, vals)
            // self._add_sale_order_tax_total_nodes(document_node, vals)
            // self._add_sale_order_monetary_total_nodes(document_node, vals)
            // return document_node
            */
            return default;
        }

        public async Task<TEntity> ImportOrderPaymentTermsIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object tree, object xpath) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _import_order_payment_terms_id(self, company_id, tree, xpath):
            // """ Return payment term name from given tree and try to find a match. """
            // payment_term_name = self._find_value(xpath, tree)
            // if not payment_term_name:
            //     return False
            // payment_term_domain = self.env['account.payment.term']._check_company_domain(company_id)
            // payment_term_domain.append(('name', '=', payment_term_name))
            // return self.env['account.payment.term'].search(payment_term_domain, limit=1)
            */
            return default;
        }

        public async Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data, object @new) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _import_order_ubl(self, order, file_data, new):
            // """ Common importing method to extract order data from file_data.
            // :param order: Order to fill details from file_data.
            // :param file_data: File data to extract order related data from.
            // :return: True if there's no exception while extraction.
            // :rtype: Boolean
            // """
            // tree = file_data['xml_tree']
            // 
            // # Update the order.
            // order_vals, logs = self._retrieve_order_vals(order, tree)
            // if order:
            //     order.write(order_vals)
            //     order.message_post(body=Markup("<strong>%s</strong>") % _("Format used to import the document: %s", self._description))
            //     if logs:
            //         order._create_activity_set_details(Markup("<ul>%s</ul>") % Markup().join(Markup("<li>%s</li>") % l for l in logs))
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _import_order_ubl(self, order, file_data, new):
            // # Overriding the main method to recalculate the price unit and discount
            // res = super()._import_order_ubl(order, file_data, new)
            // lines_with_products = order.order_line.filtered('product_id')
            // # Recompute product price and discount according to sale price
            // lines_with_products._compute_price_unit()
            // lines_with_products._compute_discount()
            // 
            // return res
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
            //     if not (line_node['cac:Item']['cbc:Name'] or {}).get('_text'):
            //         # [BR-25]-Each Invoice line (BG-25) shall contain the Item name (BT-153).
            //         constraints.update({'cen_en16931_item_name': _("Each invoice line should have a product or a label.")})
            //         break
            // 
            // for line in invoice.invoice_line_ids.filtered(lambda x: x.display_type not in ('line_section', 'line_subsection', 'line_note')):
            //     if len(line.tax_ids.flatten_taxes_hierarchy().filtered(lambda t: t.amount_type not in ('fixed', 'code'))) != 1:
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

        public async Task<TEntity> IsCustomerBehindChorusProInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _is_customer_behind_chorus_pro(self, customer):
            // return customer.peppol_eas and customer.peppol_endpoint and f"{customer.peppol_eas}:{customer.peppol_endpoint}" == CHORUS_PRO_PEPPOL_ID
            */
            return default;
        }

        public async Task<TEntity> RetrieveOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _retrieve_order_vals(self, order, tree):
            // order_vals = {}
            // logs = []
            // 
            // order_vals['date_order'] = tree.findtext('.//{*}EndDate') or tree.findtext('.//{*}IssueDate')
            // order_vals['note'] = self._import_description(tree, xpaths=['./{*}Note'])
            // order_vals['payment_term_id'] = self._import_order_payment_terms_id(order.company_id, tree, './/cac:PaymentTerms/cbc:Note')
            // order_vals['currency_id'], currency_logs = self._import_currency(tree, './/{*}DocumentCurrencyCode')
            // 
            // logs += currency_logs
            // return order_vals, logs
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _retrieve_order_vals(self, order, tree):
            // """ Fill order details by extracting details from xml tree.
            // param order: Order to fill details from xml tree.
            // param tree: Xml tree to extract details.
            // :return: list of logs to add warning and information about data from xml.
            // """
            // order_vals, logs = super()._retrieve_order_vals(order, tree)
            // partner, partner_logs = self._import_partner(
            //     order.company_id,
            //     **self._import_retrieve_partner_vals(tree, 'SellerSupplier'),
            // )
            // if partner:
            //     order_vals['partner_id'] = partner.id
            // order_vals['partner_ref'] = tree.findtext('./{*}ID')
            // order_vals['origin'] = tree.findtext('./{*}OriginatorDocumentReference/{*}ID')
            // 
            // delivery_partner, delivery_logs = self._import_partner(
            //     order.company_id,
            //     **self._import_retrieve_partner_vals(tree, 'Delivery'),
            // )
            // if delivery_partner:
            //     order_vals['dest_address_id'] = delivery_partner.id
            // 
            // allowance_charges_line_vals, allowance_charges_logs = self._import_document_allowance_charges(tree, order, 'purchase')
            // lines_vals, line_logs = self._import_lines(order, tree, './{*}OrderLine/{*}LineItem', document_type='order', tax_type='purchase')
            // # adapt each line to purchase.order.line
            // for line in lines_vals:
            //     line['product_qty'] = line.pop('quantity')
            //     # remove invoice line fields
            //     line.pop('deferred_start_date', False)
            //     line.pop('deferred_end_date', False)
            //     if not line.get('product_id'):
            //         line_logs.append(_("Could not retrieve the product named: %(name)s", name=line['name']))
            // lines_vals += allowance_charges_line_vals
            // 
            // # Update order with lines excluding discounts
            // order_vals['order_line'] = [Command.create(line_vals) for line_vals in lines_vals]
            // logs += partner_logs + delivery_logs + line_logs + allowance_charges_logs
            // 
            // return order_vals, logs
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _retrieve_order_vals(self, order, tree):
            // """ Fill order details by extracting details from xml tree.
            // param order: Order to fill details from xml tree.
            // param tree: Xml tree to extract details.
            // :return: list of logs to add warning and information about data from xml.
            // """
            // order_vals, logs = super()._retrieve_order_vals(order, tree)
            // order_vals.pop('note', False)   # The SO Terms & Conditions take precedence over the PO's
            // partner, partner_logs = self._import_partner(
            //     order.company_id,
            //     **self._import_retrieve_partner_vals(tree, 'BuyerCustomer'),
            // )
            // if partner:
            //     order_vals['partner_id'] = partner.id
            // order_vals['client_order_ref'] = tree.findtext('./{*}ID')
            // order_vals['origin'] = tree.findtext('./{*}QuotationDocumentReference/{*}ID')
            // 
            // delivery_partner, delivery_logs = self._import_partner(
            //     order.company_id,
            //     **self._import_retrieve_partner_vals(tree, 'Delivery'),
            // )
            // if delivery_partner:
            //     order_vals['partner_shipping_id'] = delivery_partner.id
            // 
            // allowance_charges_line_vals, allowance_charges_logs = self._import_document_allowance_charges(tree, order, 'sale')
            // lines_vals, line_logs = self._import_lines(order, tree, './{*}OrderLine/{*}LineItem', document_type='order', tax_type='sale')
            // # adapt each line to sale.order.line
            // for line in lines_vals:
            //     line['product_uom_qty'] = line.pop('quantity')
            //     # remove invoice line fields
            //     line.pop('deferred_start_date', False)
            //     line.pop('deferred_end_date', False)
            //     if not line.get('product_id'):
            //         line_logs.append(_("Could not retrieve the product named: %(name)s", name=line['name']))
            //     if line.get('discount'):  # Exclude discounts
            //         line.pop('discount')
            // lines_vals += allowance_charges_line_vals
            // 
            // # Update order with lines excluding discounts
            // order_vals['order_line'] = [Command.create(line_vals) for line_vals in lines_vals]
            // logs += partner_logs + delivery_logs + line_logs + allowance_charges_logs
            // 
            // return order_vals, logs
            */
            return default;
        }

        public async Task<TEntity> SetupBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _setup_base_lines(self, vals):
            // # OVERRIDE
            // AccountTax = self.env['account.tax']
            // company = vals['company']
            // 
            // # Avoid negative unit price.
            // for base_line in vals['base_lines']:
            //     if base_line['price_unit'] < 0.0:
            //         base_line['quantity'] *= -1
            //         base_line['price_unit'] *= -1
            // 
            // # Manage taxes for emptying.
            // vals['base_lines'] = self._ubl_turn_emptying_taxes_as_new_base_lines(vals['base_lines'], company, vals)
            // 
            // vals['_ubl_values'] = {}
            // for base_line in vals['base_lines']:
            //     base_line['_ubl_values'] = {}
            // 
            // # Global rounding of tax_details using 6 digits.
            // AccountTax._round_raw_total_excluded(vals['base_lines'], company)
            // AccountTax._round_raw_total_excluded(vals['base_lines'], company, in_foreign_currency=False)
            // AccountTax._add_and_round_raw_gross_total_excluded_and_discount(vals['base_lines'], company)
            // AccountTax._add_and_round_raw_gross_total_excluded_and_discount(vals['base_lines'], company, in_foreign_currency=False)
            // 
            // # Turn recycling contribution taxes such as RECUPEL / AUVIBEL into allowance/charges.
            // self._ubl_add_base_line_ubl_values_allowance_charges_recycling_contribution(vals)
            // 
            // # Turn belgium excises taxes into allowance/charges.
            // self._ubl_add_base_line_ubl_values_allowance_charges_excise(vals)
            // 
            // # Turn 'discount' field into allowance/charges.
            // self._ubl_add_base_line_ubl_values_allowance_charges_discount(vals)
            // 
            // # Add 'line_extension_amount' being the total without tax.
            // self._ubl_add_base_line_ubl_values_line_extension_amount(vals)
            // 
            // # Add 'price_amount' being the original price unit without tax.
            // self._ubl_add_base_line_ubl_values_price(vals)
            // 
            // # Add 'item' being information about item taxes.
            // self._ubl_add_base_line_ubl_values_item(vals)
            // 
            // # Add 'tax_currency_code'.
            // self._ubl_add_values_tax_currency_code(vals)
            // 
            // # Add 'tax_totals'.
            // self._ubl_add_values_tax_totals(vals)
            // 
            // # Add 'payable_rounding_amount' to manage cash rounding.
            // self._ubl_add_values_payable_rounding_amount(vals)
            // 
            // # Extract cash rounding lines.
            // vals['base_lines'] = [
            //     base_line
            //     for base_line in vals['base_lines']
            //     if base_line not in vals['_ubl_values']['payable_rounding_base_lines']
            // ]
            // 
            // # Add 'allowance_charge_early_payment' to manage the early payment discount.
            // self._ubl_add_values_allowance_charge_early_payment(vals)
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _ubl_add_values_tax_currency_code(self, vals):
            // # OVERRIDE account.edi.xml.ubl_bis3
            // self._ubl_add_values_tax_currency_code_empty(vals)
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _ubl_add_values_tax_currency_code(self, vals):
            // # OVERRIDE account.edi.xml.ubl_bis3
            // self._ubl_add_values_tax_currency_code_empty(vals)
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _ubl_add_values_tax_currency_code(self, vals):
            // # OVERRIDE account.edi.xml.ubl_bis3
            // self._ubl_add_values_tax_currency_code_empty(vals)
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _ubl_add_values_tax_currency_code(self, vals):
            // # OVERRIDE account.edi.xml.ubl_bis3
            // self._ubl_add_values_tax_currency_code_empty(vals)
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data, object vals, object currency) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _ubl_default_tax_category_grouping_key(self, base_line, tax_data, vals, currency):
            // # EXTENDS account.edi.xml.ubl_bis3
            // grouping_key = super()._ubl_default_tax_category_grouping_key(base_line, tax_data, vals, currency)
            // if not grouping_key:
            //     return
            // 
            // grouping_key['scheme_id'] = 'GST'
            // return grouping_key
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _ubl_default_tax_category_grouping_key(self, base_line, tax_data, vals, currency):
            // # EXTENDS account.edi.xml.ubl_bis3
            // grouping_key = super()._ubl_default_tax_category_grouping_key(base_line, tax_data, vals, currency)
            // if not grouping_key:
            //     return
            // 
            // grouping_key['tax_exemption_reason_code'] = None
            // return grouping_key
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _ubl_default_tax_category_grouping_key(self, base_line, tax_data, vals, currency):
            // # EXTENDS account.edi.xml.ubl_bis3
            // grouping_key = super()._ubl_default_tax_category_grouping_key(base_line, tax_data, vals, currency)
            // if not grouping_key:
            //     return
            // 
            // grouping_key['scheme_id'] = 'GST'
            // grouping_key['tax_exemption_reason'] = None
            // grouping_key['tax_exemption_reason_code'] = None
            // 
            // # For reference: https://www.peppolguide.sg/billing/bis/#_gst_category_codes
            // if not tax_data or tax_data['tax'].amount == 0.0:
            //     grouping_key['tax_category_code'] = 'ZR'
            // else:
            //     grouping_key['tax_category_code'] = 'SR'
            // 
            // return grouping_key
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxSubtotalTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py) ---
            // def _ubl_default_tax_subtotal_tax_category_grouping_key(self, tax_grouping_key, vals):
            // # EXTENDS
            // return {
            //     **super()._ubl_default_tax_subtotal_tax_category_grouping_key(tax_grouping_key, vals),
            //     # Temporary solution to have withholding taxes merged with others until we know how to manage them.
            //     'is_withholding': False,
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiXmlUblBis3able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _ubl_get_line_allowance_charge_discount_node(self, vals, discount_values):
            // # EXTENDS account.edi.xml.ubl_bis3
            // discount_node = super()._ubl_get_line_allowance_charge_discount_node(vals, discount_values)
            // discount_node['cbc:AllowanceChargeReason'] = None
            // discount_node['cbc:MultiplierFactorNumeric'] = None
            // discount_node['cbc:BaseAmount'] = None
            // return discount_node
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _ubl_get_line_allowance_charge_discount_node(self, vals, discount_values):
            // # EXTENDS account.edi.xml.ubl_bis3
            // discount_node = super()._ubl_get_line_allowance_charge_discount_node(vals, discount_values)
            // discount_node['cbc:AllowanceChargeReasonCode'] = None
            // discount_node['cbc:MultiplierFactorNumeric'] = None
            // discount_node['cbc:BaseAmount'] = None
            // return discount_node
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _ubl_get_line_allowance_charge_discount_node(self, vals, discount_values):
            // # EXTENDS account.edi.xml.ubl_bis3
            // discount_node = super()._ubl_get_line_allowance_charge_discount_node(vals, discount_values)
            // discount_node['cbc:AllowanceChargeReason'] = None
            // discount_node['cbc:MultiplierFactorNumeric'] = None
            // discount_node['cbc:BaseAmount'] = None
            // return discount_node
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _ubl_get_line_allowance_charge_discount_node(self, vals, discount_values):
            // # EXTENDS account.edi.xml.ubl_bis3
            // discount_node = super()._ubl_get_line_allowance_charge_discount_node(vals, discount_values)
            // discount_node['cbc:AllowanceChargeReason'] = None
            // discount_node['cbc:MultiplierFactorNumeric'] = None
            // discount_node['cbc:BaseAmount'] = None
            // return discount_node
            --- ODOO METHOD SOURCE (MODULE: purchase_edi_ubl_bis3, FILE: purchase_edi_xml_ubl_bis3.py) ---
            // def _ubl_get_line_allowance_charge_discount_node(self, vals, discount_values):
            // # EXTENDS account.edi.xml.ubl_bis3
            // discount_node = super()._ubl_get_line_allowance_charge_discount_node(vals, discount_values)
            // discount_node['cbc:AllowanceChargeReason'] = None
            // discount_node['cbc:MultiplierFactorNumeric'] = None
            // discount_node['cbc:BaseAmount'] = None
            // return discount_node
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_xml_ubl_bis3.py) ---
            // def _ubl_get_line_allowance_charge_discount_node(self, vals, discount_values):
            // # EXTENDS account.edi.xml.ubl_bis3
            // discount_node = super()._ubl_get_line_allowance_charge_discount_node(vals, discount_values)
            // discount_node['cbc:AllowanceChargeReason'] = None
            // discount_node['cbc:MultiplierFactorNumeric'] = None
            // discount_node['cbc:BaseAmount'] = None
            // return discount_node
            */
            return default;
        }
    }
}