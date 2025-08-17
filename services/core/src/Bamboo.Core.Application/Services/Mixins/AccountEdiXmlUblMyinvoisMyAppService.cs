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
    [Module("l10n_my_edi", Depends = new[] { "l10n_my", "l10n_my_ubl_pint", "account_edi_proxy_client" })]
    public class AccountEdiXmlUblMyinvoisMyAppService : ApplicationService, IAccountEdiXmlUblMyinvoisMyAppService
    {

        public AccountEdiXmlUblMyinvoisMyAppService() 
        {

        }

        public async Task<TEntity> AddConsolidatedInvoiceAccountingCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_consolidated_invoice_accounting_customer_party_nodes(self, document_node, vals):
            // document_node['cac:AccountingCustomerParty'] = {
            //     'cac:Party': self._get_consolidated_invoice_party_node({**vals, 'partner': vals['customer'], 'role': 'customer'}),
            // }
            */
            return default;
        }

        public async Task<TEntity> AddConsolidatedInvoiceAccountingSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_consolidated_invoice_accounting_supplier_party_nodes(self, document_node, vals):
            // document_node['cac:AccountingSupplierParty'] = {
            //     'cac:Party': self._get_consolidated_invoice_party_node({**vals, 'partner': vals['supplier'], 'role': 'supplier'}),
            // }
            */
            return default;
        }

        public async Task<TEntity> AddConsolidatedInvoiceBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_consolidated_invoice_base_lines_vals(self, vals):
            // AccountTax = self.env['account.tax']
            // consolidated_invoice = vals['consolidated_invoice']
            // consolidated_base_lines = []
            // orders_per_line = next(iter(consolidated_invoice._separate_orders_in_lines(consolidated_invoice.pos_order_ids).values()))  # Only one config in a same consolidated invoice
            // tax_data_fields = (
            //     'raw_base_amount_currency', 'raw_base_amount', 'raw_tax_amount_currency', 'raw_tax_amount',
            //     'base_amount_currency', 'base_amount', 'tax_amount_currency', 'tax_amount',
            // )
            // for index, orders in enumerate(orders_per_line):
            //     base_lines = []
            //     for order in orders:
            //         order_base_lines = order._prepare_tax_base_line_values()
            //         AccountTax._add_tax_details_in_base_lines(order_base_lines, consolidated_invoice.company_id)
            //         AccountTax._round_base_lines_tax_details(order_base_lines, consolidated_invoice.company_id)
            //         base_lines += order_base_lines
            // 
            //     # Aggregate the base lines into one.
            //     new_tax_details = {
            //         'raw_total_excluded_currency': 0.0,
            //         'total_excluded_currency': 0.0,
            //         'raw_total_excluded': 0.0,
            //         'total_excluded': 0.0,
            //         'raw_total_included_currency': 0.0,
            //         'total_included_currency': 0.0,
            //         'raw_total_included': 0.0,
            //         'total_included': 0.0,
            //         'delta_total_excluded_currency': 0.0,
            //         'delta_total_excluded': 0.0,
            //     }
            //     new_taxes_data_map = {}
            // 
            //     taxes = self.env['account.tax']
            //     for base_line in base_lines:
            //         tax_details = base_line['tax_details']
            //         sign = -1 if base_line['is_refund'] else 1
            //         for key in new_tax_details:
            //             new_tax_details[key] += sign * tax_details[key]
            //         for tax_data in tax_details['taxes_data']:
            //             tax = tax_data['tax']
            //             taxes |= tax
            //             if tax in new_taxes_data_map:
            //                 for key in tax_data_fields:
            //                     new_taxes_data_map[tax][key] += sign * tax_data[key]
            //             else:
            //                 new_taxes_data_map[tax] = dict(tax_data)
            //                 for key in tax_data_fields:
            //                     new_taxes_data_map[tax][key] = sign * tax_data[key]
            // 
            //     total_amount_discounted = new_tax_details['total_excluded'] + new_tax_details['delta_total_excluded']
            //     total_amount_discounted_currency = new_tax_details['total_excluded_currency'] + new_tax_details['delta_total_excluded_currency']
            //     total_amount = total_amount_currency = 0.0
            //     for base_line in base_lines:
            //         sign = -1 if base_line["is_refund"] else 1
            //         total_amount += sign * ((base_line['price_unit'] / base_line['rate']) * base_line['quantity'])
            //         total_amount_currency += sign * (base_line['price_unit'] * base_line['quantity'])
            // 
            //     new_base_line = AccountTax._prepare_base_line_for_taxes_computation(
            //         {},
            //         tax_ids=taxes,
            //         price_unit=total_amount_currency,
            //         discount_amount=total_amount - total_amount_discounted,
            //         discount_amount_currency=total_amount_currency - total_amount_discounted_currency,
            //         quantity=1.0,
            //         currency_id=consolidated_invoice.currency_id,
            //         tax_details={
            //             **new_tax_details,
            //             'taxes_data': list(new_taxes_data_map.values()),
            //         },
            //         line_name=f"{orders[0].name}-{orders[-1].name}" if len(orders) > 1 else orders[0].name
            //     )
            //     consolidated_base_lines.append(new_base_line)
            // 
            // vals['base_lines'] = consolidated_base_lines
            // # We aggregate multiple PoS orders into an UBL InvoiceLine.
            // # So any cash rounding will just be part of the line's amount.
            // vals['cash_rounding_base_lines'] = []
            */
            return default;
        }

        public async Task<TEntity> AddConsolidatedInvoiceConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_consolidated_invoice_config_vals(self, vals):
            // consolidated_invoice = vals['consolidated_invoice']
            // supplier = consolidated_invoice.company_id.partner_id.commercial_partner_id
            // # Use a search and not a ref in case the user create their own partner/...
            // general_public_customer = self.env["res.partner"].search(
            //     domain=[
            //         *self.env['res.partner']._check_company_domain(consolidated_invoice.company_id),
            //         '|',
            //         ('vat', '=', 'EI00000000010'),
            //         ('l10n_my_edi_malaysian_tin', '=', 'EI00000000010'),
            //     ],
            //     limit=1,
            // )
            // 
            // vals.update({
            //     'document_type': 'invoice',
            //     'document_type_code': '01',
            // 
            //     'document_name': consolidated_invoice.name,
            // 
            //     'supplier': supplier,
            //     'customer': general_public_customer,
            //     'partner_shipping': None,
            // 
            //     'currency_id': consolidated_invoice.currency_id,
            //     'company_currency_id': consolidated_invoice.company_id.currency_id,
            // 
            //     'use_company_currency': False,
            //     'fixed_taxes_as_allowance_charges': True,
            //     'export_custom_form_reference': consolidated_invoice.myinvois_custom_form_reference,
            // })
            */
            return default;
        }

        public async Task<TEntity> AddConsolidatedInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_consolidated_invoice_header_nodes(self, document_node, vals):
            // utc_now = datetime.now(tz=UTC)
            // 
            // document_node.update({
            //     'cbc:UBLVersionID': None,
            //     'cbc:ID': {'_text': vals['document_name']},
            //     # The issue date and time must be the current time set in the UTC time zone
            //     'cbc:IssueDate': {'_text': utc_now.strftime("%Y-%m-%d")},
            //     'cbc:IssueTime': {'_text': utc_now.strftime("%H:%M:%SZ")},
            //     'cbc:DueDate': None,
            // 
            //     # The current version is 1.1 (document with signature), the type code depends on the move type.
            //     'cbc:InvoiceTypeCode': {
            //         '_text': '01',
            //         'listVersionID': '1.1',
            //     },
            //     'cbc:DocumentCurrencyCode': {'_text': vals['currency_id'].name},
            //     'cac:OrderReference': None,
            //     'cac:AdditionalDocumentReference': {'cbc:ID': {'_text': vals['export_custom_form_reference']}},
            // })
            // 
            // if vals['currency_id'].name != 'MYR':
            //     # I couldn't find any information on maximum precision, so we will use the currency format.
            //     total_amount_in_company_currency = total_amount_in_currency = 0.0
            //     for base_line in vals['base_lines']:
            //         total_amount_in_company_currency += base_line['tax_details']['raw_total_included']
            //         total_amount_in_currency += base_line['tax_details']['raw_total_included_currency']
            //     rate = self.env.ref('base.MYR').round(abs(total_amount_in_company_currency) / (total_amount_in_currency or 1))
            //     # Exchange rate information must be provided if applicable
            //     document_node['cac:TaxExchangeRate'] = {
            //         'cbc:SourceCurrencyCode': {'_text': vals['currency_id'].name},
            //         'cbc:TargetCurrencyCode': {'_text': 'MYR'},
            //         'cbc:CalculationRate': {'_text': rate},
            //     }
            */
            return default;
        }

        public async Task<TEntity> AddConsolidatedInvoiceLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_consolidated_invoice_line_nodes(self, document_node, vals):
            // self._add_document_line_nodes(document_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddConsolidatedInvoiceMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_consolidated_invoice_monetary_total_nodes(self, document_node, vals):
            // self._add_document_monetary_total_nodes(document_node, vals)
            // currency_suffix = vals['currency_suffix']
            // 
            // amount_paid = vals[f'total_paid_amount{currency_suffix}']
            // document_node['cac:PrepaidPayment'] = {
            //     'cbc:PaidAmount': {
            //         '_text': self.format_float(amount_paid, vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            // monetary_total_tag = self._get_tags_for_document_type(vals)['monetary_total']
            // payable_amount = self.format_float(vals[f'tax_inclusive_amount{currency_suffix}'] - amount_paid, vals['currency_dp'])
            // document_node[monetary_total_tag]['cbc:PayableAmount']['_text'] = payable_amount
            */
            return default;
        }

        public async Task<TEntity> AddConsolidatedInvoiceMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_consolidated_invoice_monetary_total_vals(self, vals):
            // self._add_document_monetary_total_vals(vals)
            // consolidated_invoice = vals["consolidated_invoice"]
            // # Add the total amount paid.
            // vals.update({
            //     'total_paid_amount': sum(order.amount_paid / order.currency_rate for order in consolidated_invoice.pos_order_ids),
            //     'total_paid_amount_currency': sum(consolidated_invoice.pos_order_ids.mapped('amount_paid')),
            // })
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_document_line_amount_nodes(self, line_node, vals):
            // super()._add_document_line_amount_nodes(line_node, vals)
            // line_node.update({
            //     'cac:ItemPriceExtension': {
            //         'cbc:Amount': {
            //             '_text': self.format_float(vals[f"total_excluded{vals['currency_suffix']}"], vals['currency_dp']),
            //             'currencyID': vals['currency_name'],
            //         }
            //     }
            // })
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineGrossSubtotalAndDiscountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_document_line_gross_subtotal_and_discount_vals(self, vals):
            // """
            // As we group lines together, we lose the discount percentage in the process.
            // During the grouping, we stored the actual amount in the base line, se we will override here in order to use that
            // pre-computed amount.
            // """
            // super()._add_document_line_gross_subtotal_and_discount_vals(vals)
            // base_line = vals['base_line']
            // 
            // for currency_suffix in ['', '_currency']:
            //     discount_amount = base_line[f'discount_amount{currency_suffix}']
            // 
            //     vals[f'discount_amount{currency_suffix}'] = discount_amount
            //     vals[f'gross_price_unit{currency_suffix}'] += discount_amount
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_document_line_item_nodes(self, line_node, vals):
            // line_node['cac:Item'] = {
            //     'cbc:Description': {'_text': vals['base_line']['line_name']},
            //     'cbc:Name': {'_text': vals['base_line']['line_name']},
            //     'cac:CommodityClassification': {
            //         'cbc:ItemClassificationCode': {
            //             '_text': '004',
            //             'listID': 'CLASS',
            //         }
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> AddDocumentTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _add_document_tax_grouping_function_vals(self, vals):
            // def total_grouping_function(_base_line, _tax_data):
            //     return True
            // 
            // # Add the grouping functions for the tax totals
            // def tax_grouping_function(_base_line, tax_data):
            //     tax = tax_data and tax_data['tax']
            //     # Exclude fixed taxes if 'fixed_taxes_as_allowance_charges' is True
            //     if vals['fixed_taxes_as_allowance_charges'] and tax and tax.amount_type == 'fixed':
            //         return None
            // 
            //     return {
            //         'tax_category_code': tax.l10n_my_tax_type if tax else '06',
            //         'tax_exemption_reason': tax.l10n_my_tax_exemption_reason if tax and tax.l10n_my_tax_type == 'E' else None,
            //         'amount': tax.amount if tax else 0.0,
            //         'amount_type': tax.amount_type if tax else 'percent',
            //     }
            // 
            // vals['total_grouping_function'] = total_grouping_function
            // vals['tax_grouping_function'] = tax_grouping_function
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
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
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: account_edi_xml_ubl_my.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // # EXTENDS 'l10n_my_edi'
            // constraints = super()._export_invoice_constraints(invoice, vals)
            // # The classification check was only looking at the product, we also want to validate lines without product
            // for line in invoice.invoice_line_ids.filtered(lambda line: line.display_type not in ('line_note', 'line_section')):
            //     # If there are no products, we still expect a classification to be manually set.
            //     if not line.product_id and not line.l10n_my_edi_classification_code:
            //         self._l10n_my_edi_make_validation_error(constraints, 'class_code_required_line', line.id, line.display_name)
            //     # We allow invoicing a product with no classification when the classification has been manually provided.
            //     if f"myinvois_{line.product_id.id}_class_code_required" in constraints and line.l10n_my_edi_classification_code:
            //         del constraints[f"myinvois_{line.product_id.id}_class_code_required"]
            // 
            // return constraints
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // # EXTENDS 'l10n_my_edi'
            // constraints = super()._export_invoice_constraints(invoice, vals)
            // # Ignore classification code errors if invoicing to the general public; the code is fixed.
            // for line in invoice.invoice_line_ids.filtered(lambda invoice_line: invoice_line.display_type not in ('line_note', 'line_section')):
            //     to_general_public = vals['customer']._l10n_my_edi_get_tin_for_myinvois() == 'EI00000000010'
            //     if to_general_public:
            //         if f"myinvois_{line.product_id.id}_class_code_required" in constraints:
            //             del constraints[f"myinvois_{line.product_id.id}_class_code_required"]
            //         if f"myinvois_{line.product_id.id}_class_code_required_line" in constraints:
            //             del constraints[f"myinvois_{line.product_id.id}_class_code_required_line"]
            // 
            // if all(line_val['item_vals']['commodity_classification_vals'][0]['item_classification_code'] == '04' for line_val in vals['vals']['line_vals']):
            //     # consolidated invoices must use a specific customer VAT number.
            //     customer_vat = vals['vals']['accounting_customer_party_vals']['party_vals']['party_identification_vals'][0]['id']
            //     if customer_vat != 'EI00000000010':
            //         self._l10n_my_edi_make_validation_error(constraints, 'missing_general_public', vals['customer'].id, vals['customer'].name)
            // 
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _export_invoice_filename(self, invoice):
            // # OVERRIDE 'account_edi_ubl_cii'
            // return f"{invoice.name.replace('/', '_')}_myinvois.xml"
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
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
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: account_edi_xml_ubl_my.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS 'l10n_my_edi'
            // vals = super()._export_invoice_vals(invoice)
            // 
            // # For self billed documents (when sending in_xxx entries to the platform) the supplier and customer are reversed.
            // if self._is_self_billed(vals['vals']['document_type_code']):
            //     vals['vals']['accounting_supplier_party_vals']['party_vals'] = self._get_partner_party_vals(invoice.partner_id, role='supplier')
            //     vals['vals']['accounting_customer_party_vals']['party_vals'] = self._get_partner_party_vals(invoice.company_id.partner_id, role='customer')
            //     # /!\ For the company (regular invoices) it is the field on res.company that is used, and not the one on res.partner.
            //     # In master the behavior will be aligned and the classification information will be retrieved in _get_partner_party_vals
            //     vals['vals']['accounting_supplier_party_vals']['party_vals'].update({
            //         'industry_classification_code_attrs': {'name': invoice.partner_id.commercial_partner_id.l10n_my_edi_industrial_classification.name},
            //         'industry_classification_code': invoice.partner_id.commercial_partner_id.l10n_my_edi_industrial_classification.code,
            //     })
            //     # Self-billed invoices must use the number given by the supplier.
            //     if invoice.ref:
            //         vals['vals']['id'] = invoice.ref
            // # Sometimes, a foreign customer is also a supplier.
            // # To avoid needing to change the Generic TIN depending on what you do with your commercial partner, we will automatically switch
            // # depending on the context.
            // if self._is_self_billed(vals['vals']['document_type_code']):
            //     other_party = vals["vals"]["accounting_supplier_party_vals"]["party_vals"]
            //     opposite_generic_tin = 'EI00000000020'
            //     expected_generic_tin = 'EI00000000030'
            // else:
            //     other_party = vals["vals"]["accounting_customer_party_vals"]["party_vals"]
            //     opposite_generic_tin = 'EI00000000030'
            //     expected_generic_tin = 'EI00000000020'
            // # Switch the generic tin to the correct one when it makes sense (For example when a supplier has the buyer generic tin set)
            // for identification_val in other_party['party_identification_vals']:
            //     if identification_val.get('id_attrs', {}).get('schemeID') == 'TIN' and identification_val.get('id') == opposite_generic_tin:
            //         identification_val['id'] = expected_generic_tin
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._export_invoice_vals(invoice)
            // 
            // # Support the unlikely case where we invoice a refund of an order included in a consolidated invoice.
            // consolidated_invoice = self._is_consolidated_invoice_refund(invoice)
            // if consolidated_invoice:
            //     vals['vals'].update({
            //         'billing_reference_vals': {
            //             'id': consolidated_invoice.name,
            //             'uuid': consolidated_invoice.myinvois_external_uuid,
            //         },
            //     })
            //     # We also need to match the customer, so we change it to the same as the consolidated invoice (General Public)
            //     general_public = self.env["res.partner"].search(
            //         domain=[
            //             *self.env['res.partner']._check_company_domain(invoice.company_id),
            //             '|',
            //             ('vat', '=', 'EI00000000010'),
            //             ('l10n_my_edi_malaysian_tin', '=', 'EI00000000010'),
            //         ],
            //         limit=1,
            //     )
            //     if general_public:
            //         vals['customer'] = general_public
            //         vals['vals']['accounting_customer_party_vals']['party_vals'] = self._get_partner_party_vals(general_public, role='customer')
            //         vals['vals']['delivery_vals_list'] = [{
            //             'accounting_delivery_party_vals': self._l10n_my_edi_get_delivery_party_vals(general_public),
            //         }]
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_address_node(self, vals):
            // """ Generic helper to generate the Address node for a res.partner or res.bank. """
            // partner = vals['partner']
            // country_key = 'country' if partner._name == 'res.bank' else 'country_id'
            // state_key = 'state' if partner._name == 'res.bank' else 'state_id'
            // country = partner[country_key]
            // state = partner[state_key]
            // 
            // subentity_code = partner.state_id.code or ''
            // # The API does not expect the country code inside the state code, only the number part.
            // if f'{partner.country_id.code}-' in subentity_code:
            //     subentity_code = subentity_code.split('-')[1]
            // 
            // return {
            //     'cac:AddressLine': [
            //         {'cbc:Line': {'_text': partner.street or None}},
            //         {'cbc:Line': {'_text': partner.street2 or None}},
            //     ],
            //     'cbc:CityName': {'_text': partner.city},
            //     'cbc:PostalZone': {'_text': partner.zip},
            //     'cbc:CountrySubentity': {'_text': state.name},
            //     'cbc:CountrySubentityCode': {'_text': subentity_code},
            //     'cac:Country': {
            //         'cbc:IdentificationCode': {
            //             'listID': 'ISO3166-1',
            //             'listAgencyID': '6',
            //             '_text': COUNTRY_CODE_MAP.get(country.code),
            //         },
            //         'cbc:Name': {'_text': country.name},
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetConsolidatedInvoiceNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_consolidated_invoice_node(self, vals):
            // self._add_consolidated_invoice_config_vals(vals)
            // self._add_consolidated_invoice_base_lines_vals(vals)
            // self._add_document_currency_vals(vals)
            // self._add_document_tax_grouping_function_vals(vals)
            // self._add_consolidated_invoice_monetary_total_vals(vals)
            // 
            // document_node = {}
            // self._add_consolidated_invoice_header_nodes(document_node, vals)
            // self._add_consolidated_invoice_accounting_supplier_party_nodes(document_node, vals)
            // self._add_consolidated_invoice_accounting_customer_party_nodes(document_node, vals)
            // 
            // self._add_document_allowance_charge_nodes(document_node, vals)
            // self._add_document_tax_total_nodes(document_node, vals)
            // self._add_consolidated_invoice_monetary_total_nodes(document_node, vals)
            // self._add_consolidated_invoice_line_nodes(document_node, vals)
            // return document_node
            */
            return default;
        }

        public async Task<TEntity> GetConsolidatedInvoicePartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_consolidated_invoice_party_node(self, vals):
            // partner = vals["partner"]
            // role = vals["role"]
            // commercial_partner = partner.commercial_partner_id
            // 
            // party_identifications = [{
            //     'cbc:ID': {
            //         '_text': partner._l10n_my_edi_get_tin_for_myinvois(),
            //         'schemeID': 'TIN',
            //     }
            // }]
            // if partner.l10n_my_identification_type and partner.l10n_my_identification_number:
            //     party_identifications.append({
            //         'cbc:ID': {
            //             '_text': partner.l10n_my_identification_number,
            //             'schemeID': partner.l10n_my_identification_type,
            //         }
            //     })
            // if partner.sst_registration_number:
            //     # The supplier can input up to 2 SST numbers, in which case they need to separate both by a ;
            //     # They can do so in the existing field if they want.
            //     party_identifications.append({
            //         "cbc:ID": {
            //             "_text": partner.sst_registration_number,
            //             "schemeID": "SST",
            //         }
            //     })
            // if partner.ttx_registration_number:
            //     party_identifications.append({
            //         "cbc:ID": {
            //             "_text": partner.ttx_registration_number,
            //             "schemeID": "TTX",
            //         }
            //     })
            // 
            // return {
            //     "cac:PartyIdentification": party_identifications,
            //     "cbc:IndustryClassificationCode": {
            //         "_text": partner.commercial_partner_id.l10n_my_edi_industrial_classification.code,
            //         "name": partner.commercial_partner_id.l10n_my_edi_industrial_classification.name,
            //     } if role == "supplier" else None,
            //     "cac:PartyName": {
            //         "cbc:Name": {"_text": partner.display_name},
            //     },
            //     "cac:PostalAddress": self._get_address_node(vals),
            //     "cac:PartyTaxScheme": {
            //         "cbc:RegistrationName": {"_text": commercial_partner.name},
            //         "cbc:CompanyID": {"_text": commercial_partner.vat},
            //         "cac:RegistrationAddress": self._get_address_node(
            //             {**vals, "partner": commercial_partner}
            //         ),
            //         "cac:TaxScheme": {"cbc:ID": {"_text": "VAT"}},
            //     },
            //     "cac:PartyLegalEntity": {
            //         "cbc:RegistrationName": {"_text": commercial_partner.name},
            //         "cbc:CompanyID": {"_text": commercial_partner.vat},
            //         "cac:RegistrationAddress": self._get_address_node(
            //             {**vals, "partner": commercial_partner}
            //         ),
            //     },
            //     "cac:Contact": {
            //         "cbc:ID": {"_text": partner.id},
            //         "cbc:Name": {"_text": partner.name},
            //         "cbc:Telephone": {
            //             "_text": self._l10n_my_edi_get_formatted_phone_number(partner.phone)
            //         },
            //         "cbc:ElectronicMail": {"_text": partner.email},
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCountryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_delivery_vals_list(self, invoice):
            // # OVERRIDE 'account_edi_ubl_cii'
            // return [{
            //     'accounting_delivery_party_vals': self._l10n_my_edi_get_delivery_party_vals(invoice.partner_id),
            // }]
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_delivery_vals_list(self, invoice):
            // # OVERRIDE 'l10n_my_edi'
            // customer = invoice.company_id.partner_id if invoice.is_purchase_document() else invoice.partner_id
            // return [{
            //     'accounting_delivery_party_vals': self._l10n_my_edi_get_delivery_party_vals(customer),
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineItemValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
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
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_invoice_line_item_vals(self, line, taxes_vals):
            // # EXTENDS 'l10n_my_edi' to use the new field
            // vals = super()._get_invoice_line_item_vals(line, taxes_vals)
            // # Replace the code to get it from the line instead
            // vals['commodity_classification_vals'] = [{
            //     'item_classification_code': line.l10n_my_edi_classification_code,
            //     'item_classification_attrs': {'listID': 'CLASS'},
            // }]
            // return vals
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_invoice_line_item_vals(self, line, taxes_vals):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._get_invoice_line_item_vals(line, taxes_vals)
            // # When the invoice is sent for the general public (refunding an order in a consolidated invoice/...) the item code
            // # must be fixed to 004 (consolidated invoice) even if the product has something else set.
            // if line.partner_id._l10n_my_edi_get_tin_for_myinvois() == 'EI00000000010' or self._is_consolidated_invoice_refund(line.move_id):
            //     vals['commodity_classification_vals'][0]['item_classification_code'] = '004'
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, Guid line_id, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_invoice_line_vals(self, line, line_id, taxes_vals):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._get_invoice_line_vals(line, line_id, taxes_vals)
            // vals['item_price_extension_amount'] = line.price_subtotal
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetPartnerAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> GetPartnerContactValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_partner_contact_vals(self, partner):
            // # EXTENDS 'account_edi_ubl_cii'
            // res = super()._get_partner_contact_vals(partner)
            // res['telephone'] = self._l10n_my_edi_get_formatted_phone_number(res['telephone'])
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyIdentificationValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # OVERRIDE 'account_edi_ubl_cii'
            // # We only want to display the registration name here.
            // return [{
            //     'registration_name': partner.name,
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi, FILE: account_edi_xml_ubl_my.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // """ This information is not needed. Instead, the party identification vals must be filled. """
            // # OVERRIDE 'account_edi_ubl_cii'
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> GetTaxGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
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

        public async Task<TEntity> GetTaxUneceCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
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
            */
            return default;
        }

        public async Task<TEntity> ImportFillInvoiceFormInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
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
            */
            return default;
        }

        public async Task<TEntity> ImportRetrieveAndFillPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object name, object phone, object mail, object vat, object country_code, object id_type, object id_val, object sst, object ttx) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
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

        public async Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> IsConsolidatedInvoiceRefundInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_pos, FILE: account_edi_xml_ubl_my.py) ---
            // def _is_consolidated_invoice_refund(self, invoice):
            // """
            // Indicate if the invoice we are exporting is a refund/credit note regarding a consolidated invoice.
            // If yes, we return the consolidated invoice.
            // """
            // is_order_refund = invoice.move_type == 'out_refund' and invoice.pos_order_ids
            // if not is_order_refund:
            //     return False
            // 
            // refunded_order = invoice.pos_order_ids[0].refunded_order_id
            // consolidated_invoices = refunded_order and refunded_order._get_active_consolidated_invoice()
            // return consolidated_invoices
            */
            return default;
        }

        public async Task<TEntity> IsSelfBilledInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_code) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: account_edi_xml_ubl_my.py) ---
            // def _is_self_billed(self, document_code):
            // """ Small helper which returns True if a document code is for self billing.
            // To avoid repeating the check multiple time, risking to forget to update one or the other.
            // """
            // return document_code in {"11", "12", "13", "14"}
            */
            return default;
        }

        public async Task<TEntity> L10nMyEdiGetDeliveryPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
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

        public async Task<TEntity> L10nMyEdiGetDocumentTypeCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
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
            --- ODOO METHOD SOURCE (MODULE: l10n_my_edi_extended, FILE: account_edi_xml_ubl_my.py) ---
            // def _l10n_my_edi_get_document_type_code(self, invoice):
            // """ Override the super method to include self billed documents. """
            // # OVERRIDE 'l10n_my_edi'
            // super()._l10n_my_edi_get_document_type_code(invoice)
            // 
            // if 'debit_origin_id' in self.env['account.move']._fields and invoice.debit_origin_id:
            //     code = '03' if invoice.move_type == 'out_invoice' else '13'
            //     return code, invoice.debit_origin_id
            // elif invoice.move_type in ('out_refund', 'in_refund'):
            //     # We consider a credit note a refund if it is paid and fully reconciled with a payment or bank transaction.
            //     payment_terms = invoice.line_ids.filtered(lambda aml: aml.display_type == 'payment_term')
            //     counterpart_amls = payment_terms.matched_debit_ids.debit_move_id + payment_terms.matched_credit_ids.credit_move_id
            //     counterpart_move_type = 'out_invoice' if invoice.move_type == 'out_refund' else 'out_refund'
            //     has_payments = bool(counterpart_amls.move_id.filtered(lambda move: move.move_type != counterpart_move_type))
            //     is_paid = invoice.payment_state in ('in_payment', 'paid', 'reversed')
            //     if is_paid and has_payments:
            //         code = '04' if invoice.move_type == 'out_refund' else '14'
            //     else:
            //         code = '02' if invoice.move_type == 'out_refund' else '12'
            // 
            //     return code, invoice.reversed_entry_id
            // else:
            //     code = '01' if invoice.move_type == 'out_invoice' else '11'
            //     return code, None
            */
            return default;
        }

        public async Task<TEntity> L10nMyEdiGetFormattedPhoneNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object number) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
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

        public async Task<TEntity> L10nMyEdiGetTaxExchangeRateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
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

        public async Task<TEntity> L10nMyEdiMakeValidationErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object constraints, object code, object record_identifier, object record_name) where TEntity : IEntity<Guid>, IAccountEdiXmlUblMyinvoisMyable
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
    }
}