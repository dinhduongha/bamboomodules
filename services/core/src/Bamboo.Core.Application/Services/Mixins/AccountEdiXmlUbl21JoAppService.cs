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
    [Module("l10n_jo_edi", Depends = new[] { "account_edi_ubl_cii", "l10n_jo" })]
    public class AccountEdiXmlUbl21JoAppService : ApplicationService, IAccountEdiXmlUbl21JoAppService
    {

        public AccountEdiXmlUbl21JoAppService() 
        {

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

        public async Task<TEntity> ExportInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
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

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> ExtractBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> FormatFloatAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object precision_digits) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> GetAdditionalDocumentReferenceListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_additional_document_reference_list(self, invoice):
            // return [{
            //     'id': 'ICV',
            //     'uuid': invoice.id,
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetBillingReferenceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> GetCountryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_country_vals(self, country):
            // return {
            //     'identification_code': country.code,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyDecimalPlacesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid currency_id) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_currency_decimal_places(self, currency_id=None):
            // # Invoices are always reported in JOD
            // return self.env.ref('base.JOD').decimal_places
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_delivery_vals_list(self, invoice):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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
            */
            return default;
        }

        public async Task<TEntity> GetEmptyPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> GetInvoiceLineAllowanceValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_line_allowance_vals_list(self, line, taxes_vals):
            // return [{
            //     'charge_indicator': 'false',
            //     'allowance_charge_reason': 'DISCOUNT',
            //     'currency_name': JO_CURRENCY.name,
            //     'currency_dp': self._get_currency_decimal_places(),
            //     'amount': self._get_line_discount_jod(self._extract_base_lines(taxes_vals)[0]),
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineItemValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_line_item_vals(self, line, taxes_vals):
            // product = line.product_id
            // description = (line.name or '').replace('\n', ', ')
            // return {
            //     'name': product.name or description,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLinePriceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> GetInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, Guid line_id, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals, object line_extension_amount, object allowance_total_amount, object charge_total_amount) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentTermsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_invoice_payment_terms_vals_list(self, invoice):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTaxTotalsValsHelperInternalAsync<TEntity>(IEnumerable<TEntity> entities, object taxes_vals, object is_single_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> GetInvoiceTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> GetLineAmountBeforeDiscountJodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> GetLineDiscountJodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_line_discount_jod(self, base_line):
            // line = base_line['record']
            // return self._get_line_amount_before_discount_jod(base_line) * line.discount / 100
            */
            return default;
        }

        public async Task<TEntity> GetLineEdiIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, Guid default_id) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> GetLineTaxAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> GetLineTaxableAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_line_taxable_amount(self, base_line):
            // line = base_line['record']
            // return self._get_line_unit_price_jod(base_line) * line.quantity - self._get_line_discount_jod(base_line)
            */
            return default;
        }

        public async Task<TEntity> GetLineUnitPriceJodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_line_unit_price_jod(self, base_line):
            // line = base_line['record']
            // return self._get_line_amount_before_discount_jod(base_line) / line.quantity
            */
            return default;
        }

        public async Task<TEntity> GetPartnerAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_address_vals(self, partner):
            // return {
            //     'postal_zone': partner.zip,
            //     'country_subentity_code': partner.state_id.code,
            //     'country_vals': self._get_country_vals(partner.country_id),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPartnerContactValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_contact_vals(self, partner):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyIdentificationValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_party_identification_vals_list(self, partner):
            // return [{
            //     'id_attrs': {'schemeID': 'TN' if partner.country_code == 'JO' else 'PN'},
            //     'id': partner.vat if partner.vat and partner.vat != '/' else 'NO_VAT',
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // return [{
            //     'registration_name': partner.name,
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // return [{
            //     'company_id': partner.vat,
            //     'tax_scheme_vals': {'id': 'VAT'},
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // vals = super()._get_partner_party_vals(partner, role)
            // vals['party_name_vals'] = []
            // if role == 'supplier':
            //     vals['party_identification_vals'] = []
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetPaymentMethodCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_payment_method_code(self, invoice):
            // return invoice._get_invoice_scope_code() + invoice._get_invoice_payment_method_code() + invoice._get_invoice_tax_payer_type_code()
            */
            return default;
        }

        public async Task<TEntity> GetSellerSupplierPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> GetUomUneceCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _get_uom_unece_code(self, line=None):
            // return "PCE"
            */
            return default;
        }

        public async Task<TEntity> RoundMaxDpInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @value) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_jo_edi, FILE: account_edi_xml_ubl_21_jo.py) ---
            // def _round_max_dp(self, value):
            // return float_round(value, JO_MAX_DP)
            */
            return default;
        }

        public async Task<TEntity> SumMaxDpInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iterable) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21Joable
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