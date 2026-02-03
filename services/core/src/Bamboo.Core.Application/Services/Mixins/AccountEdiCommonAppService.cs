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
    public partial class AccountEdiCommonAppService : ApplicationService, IAccountEdiCommonAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiCommonAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AddLogsImportInvoiceUblCiiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_logs) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _add_logs_import_invoice_ubl_cii(self, invoice, invoice_logs=None):
            // invoice.ensure_one()
            // if invoice_logs is None:
            //     invoice_logs = []
            // format_log = self.env._("Format: %s", self.env['ir.model']._get(self._name).name)
            // return [format_log] + invoice_logs
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_edi_common.py) ---
            // def _add_logs_import_invoice_ubl_cii(self, invoice, invoice_logs=None):
            // # EXTENDS 'account_edi_ubl_cii'
            // logs = super()._add_logs_import_invoice_ubl_cii(invoice, invoice_logs=invoice_logs)
            // if uuid := invoice.peppol_message_uuid:
            //     logs = [self.env._("Peppol document UUID: %s", uuid)] + logs
            // return logs
            */
            return default;
        }

        public async Task<TEntity> CheckNon0RateTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _check_non_0_rate_tax(self, vals):
            // for line_vals in vals['tax_details']['tax_details_per_record']:
            //     tax_rate_list = line_vals.tax_ids.flatten_taxes_hierarchy().mapped("amount")
            //     if not any([rate > 0 for rate in tax_rate_list]):
            //         return _("When the Canary Island General Indirect Tax (IGIC) applies, the tax rate on "
            //                  "each invoice line should be greater than 0.")
            */
            return default;
        }

        public async Task<TEntity> CheckRequiredFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_names, object custom_warning_message) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _check_required_fields(self, record, field_names, custom_warning_message=""):
            // """Check if at least one of the field_names are set on the record/dict
            // 
            // :param record: either a recordSet or a dict
            // :param field_names: The field name or list of field name that has to
            //                     be checked. If a list is provided, check that at
            //                     least one of them is set.
            // :return: an Error message or None
            // """
            // if not record:
            //     return custom_warning_message or _("The element %(record)s is required on %(field_list)s.", record=record, field_list=field_names)
            // 
            // if not isinstance(field_names, (list, tuple)):
            //     field_names = (field_names,)
            // 
            // has_values = any((field_name in record and record[field_name]) for field_name in field_names)
            // # field is present
            // if has_values:
            //     return
            // 
            // # field is not present
            // if custom_warning_message or isinstance(record, dict):
            //     return custom_warning_message or _(
            //         "The element %(record)s is required on %(field_list)s.",
            //         record=record,
            //         field_list=field_names,
            //     )
            // 
            // display_field_names = record.fields_get(field_names)
            // if len(field_names) == 1:
            //     display_field = f"'{display_field_names[field_names[0]]['string']}'"
            //     return _("The field %(field)s is required on %(record)s.", field=display_field, record=record.display_name)
            // else:
            //     display_fields = [f"'{display_field_names[x]['string']}'" for x in display_field_names]
            //     return _("At least one of the following fields %(field_list)s is required on %(record)s.", field_list=display_fields, record=record.display_name)
            */
            return default;
        }

        public async Task<TEntity> CheckRequiredTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _check_required_tax(self, vals):
            // for line_vals in vals['invoice_line_vals_list']:
            //     line = line_vals['line']
            //     if not vals['tax_details']['tax_details_per_record'][line]['tax_details']:
            //         return _("You should include at least one tax per invoice line. [BR-CO-04]-Each Invoice line (BG-25) "
            //                  "shall be categorized with an Invoiced item VAT category code (BT-151).")
            */
            return default;
        }

        public async Task<TEntity> CorrectInvoiceTaxAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _correct_invoice_tax_amount(self, tree, invoice):
            // pass
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // constraints = self._invoice_constraints_common(invoice)
            // if invoice.move_type == 'out_invoice':
            //     # [BR-DE-1] An Invoice must contain information on "PAYMENT INSTRUCTIONS" (BG-16)
            //     # first check that a partner_bank_id exists, then check that there is an account number
            //     constraints.update({
            //         'seller_payment_instructions_1': self._check_required_fields(
            //             vals['record'], 'partner_bank_id'
            //         ),
            //         'seller_payment_instructions_2': self._check_required_fields(
            //             vals['record']['partner_bank_id'], 'sanitized_acc_number',
            //             _("The field 'Sanitized Account Number' is required on the Recipient Bank.")
            //         ),
            //     })
            // constraints.update({
            //     # [BR-08]-An Invoice shall contain the Seller postal address (BG-5).
            //     # [BR-09]-The Seller postal address (BG-5) shall contain a Seller country code (BT-40).
            //     'seller_postal_address': self._check_required_fields(
            //         vals['record']['company_id']['partner_id']['commercial_partner_id'], 'country_id'
            //     ),
            //     # [BR-CO-26]-In order for the buyer to automatically identify a supplier, the Seller identifier (BT-29),
            //     # the Seller legal registration identifier (BT-30) and/or the Seller VAT identifier (BT-31) shall be present.
            //     'seller_identifier': self._check_required_fields(
            //         vals['record']['company_id'], ['vat']  # 'siret'
            //     ),
            //     # [BR-DE-6] The element "Seller contact telephone number" (BT-42) must be transmitted.
            //     'seller_phone': self._check_required_fields(
            //         vals['record']['company_id']['partner_id']['commercial_partner_id'], ['phone'],
            //     ),
            //     # [BR-DE-7] The element "Seller contact email address" (BT-43) must be transmitted.
            //     'seller_email': self._check_required_fields(
            //         vals['record']['company_id'], 'email'
            //     ),
            //     # [BR-CO-04]-Each Invoice line (BG-25) shall be categorized with an Invoiced item VAT category code (BT-151).
            //     'tax_invoice_line': self._check_required_tax(vals),
            //     # [BR-IC-02]-An Invoice that contains an Invoice line (BG-25) where the Invoiced item VAT category code (BT-151)
            //     # is "Intra-community supply" shall contain the Seller VAT Identifier (BT-31) or the Seller tax representative
            //     # VAT identifier (BT-63) and the Buyer VAT identifier (BT-48).
            //     'intracom_seller_vat': self._check_required_fields(vals['record']['company_id'], 'vat') if vals['intracom_delivery'] else None,
            //     'intracom_buyer_vat': self._check_required_fields(vals['record']['commercial_partner_id'], 'vat') if vals['intracom_delivery'] else None,
            //     # [BR-IG-05]-In an Invoice line (BG-25) where the Invoiced item VAT category code (BT-151) is "IGIC" the
            //     # invoiced item VAT rate (BT-152) shall be greater than 0 (zero).
            //     'igic_tax_rate': self._check_non_0_rate_tax(vals)
            //         if vals['record']['partner_id']['country_id']['code'] == 'ES'
            //             and vals['record']['partner_id']['zip']
            //             and vals['record']['partner_id']['zip'][:2] in ['35', '38'] else None,
            // })
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'de.xrechnung:cii:2.2.0',
            //     'credit_note': 'de.xrechnung:cii:2.2.0',
            // }
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_factur_x.xml"
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _export_invoice(self, invoice):
            // vals = self._export_invoice_vals(invoice.with_context(lang=invoice.partner_id.lang))
            // errors = [constraint for constraint in self._export_invoice_constraints(invoice, vals).values() if constraint]
            // xml_content = self.env['ir.qweb']._render('account_edi_ubl_cii.account_invoice_facturx_export_22', vals)
            // return etree.tostring(cleanup_xml_node(xml_content), xml_declaration=True, encoding='UTF-8'), set(errors)
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _export_invoice_vals(self, invoice):
            // customer = invoice.partner_id
            // supplier = invoice.company_id.partner_id.commercial_partner_id
            // 
            // def format_date(dt):
            //     # Format the date in the Factur-x standard.
            //     dt = dt or datetime.now()
            //     return dt.strftime(DEFAULT_FACTURX_DATE_FORMAT)
            // 
            // def format_monetary(number, decimal_places=2):
            //     # Facturx requires the monetary values to be rounded to 2 decimal values
            //     return float_repr(number, decimal_places)
            // 
            // def grouping_key_generator(base_line, tax_data):
            //     tax = tax_data['tax']
            //     grouping_key = {
            //         'tax_category_code': self._get_tax_category_code(customer.commercial_partner_id, supplier, tax),
            //         **self._get_tax_exemption_reason(customer.commercial_partner_id, supplier, tax),
            //         'amount': tax.amount,
            //         'amount_type': tax.amount_type,
            //     }
            //     # If the tax is fixed, we want to have one group per tax
            //     # s.t. when the invoice is imported, we can try to guess the fixed taxes
            //     if tax.amount_type == 'fixed':
            //         grouping_key['tax_name'] = tax.name
            //     return grouping_key
            // 
            // # Validate the structure of the taxes
            // self._validate_taxes(invoice.invoice_line_ids.tax_ids)
            // 
            // # Create file content.
            // tax_details = invoice._prepare_invoice_aggregated_taxes(grouping_key_generator=grouping_key_generator)
            // 
            // # Fixed Taxes: filter them on the document level, and adapt the totals
            // # Fixed taxes are not supposed to be taxes in real live. However, this is the way in Odoo to manage recupel
            // # taxes in Belgium. Since only one tax is allowed, the fixed tax is removed from totals of lines but added
            // # as an extra charge/allowance.
            // fixed_taxes_keys = [k for k in tax_details['tax_details'] if k['amount_type'] == 'fixed']
            // for key in fixed_taxes_keys:
            //     fixed_tax_details = tax_details['tax_details'].pop(key)
            //     tax_details['tax_amount_currency'] -= fixed_tax_details['tax_amount_currency']
            //     tax_details['tax_amount'] -= fixed_tax_details['tax_amount']
            //     tax_details['base_amount_currency'] += fixed_tax_details['tax_amount_currency']
            //     tax_details['base_amount'] += fixed_tax_details['tax_amount']
            // 
            // template_values = {
            //     **invoice._prepare_edi_vals_to_export(),
            //     'tax_details': tax_details,
            //     'format_date': format_date,
            //     'format_monetary': format_monetary,
            //     'is_html_empty': is_html_empty,
            //     'scheduled_delivery_time': self._get_scheduled_delivery_time(invoice),
            //     'intracom_delivery': False,
            //     'ExchangedDocument_vals': self._get_exchanged_document_vals(invoice),
            //     'seller_specified_legal_organization': invoice.company_id.company_registry,
            //     'buyer_specified_legal_organization': invoice.commercial_partner_id.company_registry,
            //     'ship_to_trade_party': invoice.partner_shipping_id if 'partner_shipping_id' in invoice._fields and invoice.partner_shipping_id
            //         else invoice.commercial_partner_id,
            //     # Chorus Pro fields
            //     'buyer_reference': invoice.buyer_reference if 'buyer_reference' in invoice._fields
            //         and invoice.buyer_reference else invoice.commercial_partner_id.ref,
            //     'purchase_order_reference': invoice.purchase_order_reference if 'purchase_order_reference' in invoice._fields
            //         and invoice.purchase_order_reference else invoice.ref or invoice.name,
            //     'contract_reference': invoice.contract_reference if 'contract_reference' in invoice._fields and invoice.contract_reference else '',
            //     'document_context_id': "urn:cen.eu:en16931:2017#conformant#urn:factur-x.eu:1p0:extended",
            // }
            // 
            // # data used for IncludedSupplyChainTradeLineItem / SpecifiedLineTradeSettlement
            // for line_vals in template_values['invoice_line_vals_list']:
            //     line = line_vals['line']
            //     line_vals['unece_uom_code'] = self._get_uom_unece_code(line.product_uom_id)
            // 
            //     if line._fields.get('deferred_start_date') and (line.deferred_start_date or line.deferred_end_date):
            //         line_vals['billing_start'] = line.deferred_start_date
            //         line_vals['billing_end'] = line.deferred_end_date
            // 
            // # [BR - IC - 11] - In an Invoice with a VAT breakdown (BG-23) where the VAT category code (BT-118) is
            // # "Intra-community supply" the Actual delivery date (BT-72) or the Invoicing period (BG-14) shall not be blank.
            // billing_start_dates = [invoice.invoice_date] if invoice.invoice_date else []
            // billing_start_dates += [line_vals['billing_start'] for line_vals in template_values['invoice_line_vals_list'] if line_vals.get('billing_start')]
            // billing_end_dates = [invoice.invoice_date_due] if invoice.invoice_date_due else []
            // billing_end_dates += [line_vals['billing_end'] for line_vals in template_values['invoice_line_vals_list'] if line_vals.get('billing_end')]
            // if billing_start_dates:
            //     template_values['billing_start'] = min(billing_start_dates)
            // if billing_end_dates:
            //     template_values['billing_end'] = max(billing_end_dates)
            // 
            // # data used for ApplicableHeaderTradeSettlement / ApplicableTradeTax (at the end of the xml)
            // for tax_detail_vals in template_values['tax_details']['tax_details'].values():
            //     # /!\ -0.0 == 0.0 in python but not in XSLT, so it can raise a fatal error when validating the XML
            //     # if 0.0 is expected and -0.0 is given.
            //     amount_currency = tax_detail_vals['tax_amount_currency']
            //     tax_detail_vals['calculated_amount'] = amount_currency if not invoice.currency_id.is_zero(amount_currency) else 0
            // 
            //     if tax_detail_vals.get('tax_category_code') == 'K':
            //         template_values['intracom_delivery'] = True
            // 
            // # Fixed taxes: add them as charges on the invoice lines
            // for line_vals in template_values['invoice_line_vals_list']:
            //     line_vals['allowance_charge_vals_list'] = []
            //     for grouping_key, tax_detail in tax_details['tax_details_per_record'][line_vals['line']]['tax_details'].items():
            //         if grouping_key['amount_type'] == 'fixed':
            //             line_vals['allowance_charge_vals_list'].append({
            //                 'indicator': 'true',
            //                 'reason': tax_detail['tax_name'],
            //                 'reason_code': 'AEO',
            //                 'amount': tax_detail['tax_amount_currency'],
            //             })
            //     sum_fixed_taxes = sum(x['amount'] for x in line_vals['allowance_charge_vals_list'])
            //     line_vals['line_total_amount'] = line_vals['line'].price_subtotal + sum_fixed_taxes
            // 
            //     # The quantity is the line.quantity since we keep the unece_uom_code!
            //     line_vals['quantity'] = line_vals['line'].quantity
            // 
            //     # Invert the quantity and the gross_price_total_unit if a line has a negative price total
            //     if line_vals['line'].currency_id.compare_amounts(line_vals['gross_price_total_unit'], 0) == -1:
            //         line_vals['quantity'] *= -1
            //         line_vals['gross_price_total_unit'] *= -1
            //         line_vals['price_subtotal_unit'] *= -1
            // 
            // # Fixed taxes: set the total adjusted amounts on the document level
            // template_values['tax_basis_total_amount'] = tax_details['base_amount_currency']
            // template_values['tax_total_amount'] = tax_details['tax_amount_currency']
            // 
            // if self.env['account.payment']._fields.get('sdd_mandate_id') and invoice.reconciled_payment_ids.sdd_mandate_id:
            //     template_values['payment_means_code'] = PAYMENT_MEAN_CODES['SEPA direct debit']
            // else:
            //     template_values['payment_means_code'] = PAYMENT_MEAN_CODES['Payment to bank account']
            // 
            // return template_values
            */
            return default;
        }

        public async Task<TEntity> FindValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xpath, object tree, object nsmap) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _find_value(self, xpaths, tree, nsmap=False):
            // """ Iteratively queries the tree using the xpaths and returns a result as soon as one is found """
            // if not isinstance(xpaths, (tuple, list)):
            //     xpaths = [xpaths]
            // for xpath in xpaths:
            //     # functions from ElementTree like "findtext" do not fully implement xpath, use "xpath" (from lxml) instead
            //     # (e.g. "//node[string-length(text()) > 5]" raises an invalidPredicate exception with "findtext")
            //     val = find_xml_value(xpath, tree, nsmap)
            //     if val:
            //         return val
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _find_value(self, xpath, tree, nsmap=False):
            // # EXTENDS account.edi.common
            // return super()._find_value(xpath, tree, CII_NAMESPACES)
            */
            return default;
        }

        public async Task<TEntity> FormatFloatAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object precision_digits) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def format_float(self, amount, precision_digits):
            // if amount is None:
            //     return None
            // return float_repr(float_round(amount, precision_digits), precision_digits)
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyDecimalPlacesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid currency_id) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_currency_decimal_places(self, currency_id):
            // # Allows other documents to easily override in case there is a flat max precision number
            // return currency_id.decimal_places
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_document_allowance_charge_xpaths(self):
            // # OVERRIDE
            // pass
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_document_allowance_charge_xpaths(self):
            // return {
            //     'root': './{*}SupplyChainTradeTransaction/{*}ApplicableHeaderTradeSettlement/{*}SpecifiedTradeAllowanceCharge',
            //     'charge_indicator': './{*}ChargeIndicator/{*}Indicator',
            //     'base_amount': './{*}BasisAmount',
            //     'amount': './{*}ActualAmount',
            //     'reason': './{*}Reason',
            //     'percentage': './{*}CalculationPercent',
            //     'tax_percentage': './{*}CategoryTradeTax/{*}RateApplicablePercent',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetExchangedDocumentValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_exchanged_document_vals(self, invoice):
            // return {
            //     'id': invoice.name,
            //     'type_code': '380' if invoice.move_type == 'out_invoice' else '381',
            //     'issue_date_time': invoice.invoice_date,
            //     'included_note': html2plaintext(invoice.narration) if invoice.narration else "",
            // }
            */
            return default;
        }

        public async Task<TEntity> GetImportDocumentAmountSignInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_import_document_amount_sign(self, tree):
            // """
            // In factur-x, an invoice has code 380 and a credit note has code 381. However, a credit note can be expressed
            // as an invoice with negative amounts. For this case, we need a factor to take the opposite of each quantity
            // in the invoice.
            // """
            // move_type_code = tree.find('.//{*}ExchangedDocument/{*}TypeCode')
            // if move_type_code is None:
            //     return None, None
            // if move_type_code.text == '381':
            //     return 'refund', 1
            // if move_type_code.text == '380':
            //     amount_node = tree.find('.//{*}SpecifiedTradeSettlementHeaderMonetarySummation/{*}TaxBasisTotalAmount')
            //     if amount_node is not None and float(amount_node.text) < 0:
            //         return 'refund', -1
            //     return 'invoice', 1
            // return None, None
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_invoice_line_xpaths(self, invoice_line, qty_factor):
            // # OVERRIDE
            // pass
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_invoice_line_xpaths(self, document_type=False, qty_factor=1):
            // return {
            //     'deferred_start_date': './{*}SpecifiedLineTradeSettlement/{*}BillingSpecifiedPeriod/{*}StartDateTime/{*}DateTimeString',
            //     'deferred_end_date': './{*}SpecifiedLineTradeSettlement/{*}BillingSpecifiedPeriod/{*}EndDateTime/{*}DateTimeString',
            //     'date_format': DEFAULT_FACTURX_DATE_FORMAT,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoicingPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_invoicing_period(self, invoice):
            // # get the Invoicing period (BG-14): a list of dates covered by the invoice
            // # don't create a bridge to get the date range from the timesheet_ids
            // return [invoice.invoice_date]
            */
            return default;
        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_line_xpaths(self, document_type=False, qty_factor=1):
            // return {
            //     'basis_qty': (
            //         './ram:SpecifiedLineTradeAgreement/ram:GrossPriceProductTradePrice/ram:BasisQuantity',
            //         './ram:SpecifiedLineTradeAgreement/ram:NetPriceProductTradePrice/ram:BasisQuantity',
            //     ),
            //     'gross_price_unit': './{*}SpecifiedLineTradeAgreement/{*}GrossPriceProductTradePrice/{*}ChargeAmount',
            //     'rebate': './{*}SpecifiedLineTradeAgreement/{*}GrossPriceProductTradePrice/{*}AppliedTradeAllowanceCharge/{*}ActualAmount',
            //     'net_price_unit': './{*}SpecifiedLineTradeAgreement/{*}NetPriceProductTradePrice/{*}ChargeAmount',
            //     'delivered_qty': './{*}SpecifiedLineTradeDelivery/{*}BilledQuantity',
            //     'allowance_charge': './/{*}SpecifiedLineTradeSettlement/{*}SpecifiedTradeAllowanceCharge',
            //     'allowance_charge_indicator': './{*}ChargeIndicator/{*}Indicator',
            //     'allowance_charge_amount': './{*}ActualAmount',
            //     'allowance_charge_reason': './{*}Reason',
            //     'allowance_charge_reason_code': './{*}ReasonCode',
            //     'line_total_amount': './{*}SpecifiedLineTradeSettlement/{*}SpecifiedTradeSettlementLineMonetarySummation/{*}LineTotalAmount',
            //     'name': [
            //         './ram:SpecifiedTradeProduct/ram:Name',
            //     ],
            //     'product': {
            //         'default_code': './ram:SpecifiedTradeProduct/ram:SellerAssignedID',
            //         'name': './ram:SpecifiedTradeProduct/ram:Name',
            //         'barcode': './ram:SpecifiedTradeProduct/ram:GlobalID',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPostalAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_postal_address(self, tree, role):
            // return {
            //     'country_code': self._find_value(f'.//ram:{role}/ram:PostalTradeAddress//ram:CountryID', tree),
            //     'street': self._find_value(f'.//ram:{role}/ram:PostalTradeAddress//ram:LineOne', tree),
            //     'additional_street': self._find_value(f'.//ram:{role}/ram:PostalTradeAddress//ram:LineTwo', tree),
            //     'city': self._find_value(f'.//ram:{role}/ram:PostalTradeAddress//ram:CityName', tree),
            //     'zip': self._find_value(f'.//ram:{role}/ram:PostalTradeAddress//ram:PostcodeCode', tree),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetScheduledDeliveryTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_scheduled_delivery_time(self, invoice):
            // # don't create a bridge only to get line.sale_line_ids.order_id.picking_ids.date_done
            // # line.sale_line_ids.order_id.picking_ids.scheduled_date or line.sale_line_ids.order_id.commitment_date
            // return invoice.delivery_date or invoice.invoice_date
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_tax_category_code(self, customer, supplier, tax):
            // """
            // Predicts the tax category code for a tax applied to a given base line.
            // If the tax has a defined category code, it is returned.
            // Otherwise, a reasonable default is provided, though it may not always be accurate.
            // 
            // Source: doc of Peppol (but the CEF norm is also used by factur-x, yet not detailed)
            // https://docs.peppol.eu/poacc/billing/3.0/syntax/ubl-invoice/cac-TaxTotal/cac-TaxSubtotal/cac-TaxCategory/cbc-TaxExemptionReasonCode/
            // https://docs.peppol.eu/poacc/billing/3.0/codelist/vatex/
            // https://docs.peppol.eu/poacc/billing/3.0/codelist/UNCL5305/
            // """
            // # add Norway, Iceland, Liechtenstein
            // european_economic_area = self.env.ref('base.europe').country_ids.mapped('code') + ['NO', 'IS', 'LI']
            // 
            // if not tax:
            //     return 'E'
            // 
            // if tax.ubl_cii_tax_category_code:
            //     return tax.ubl_cii_tax_category_code
            // 
            // if customer.country_id.code == 'ES' and customer.zip:
            //     if customer.zip[:2] in ('35', '38'):  # Canary
            //         # [BR-IG-10]-A VAT breakdown (BG-23) with VAT Category code (BT-118) "IGIC" shall not have a VAT
            //         # exemption reason code (BT-121) or VAT exemption reason text (BT-120).
            //         return 'L'
            //     if customer.zip[:2] in ('51', '52'):
            //         return 'M'  # Ceuta & Mellila
            // 
            // if supplier.country_id == customer.country_id:
            //     if not tax or tax.amount == 0:
            //         # in theory, you should indicate the precise law article
            //         return 'E'
            //     elif tax.has_negative_factor:
            //         # Special case: Purchase reverse-charge taxes for self-billed invoices.
            //         # From the buyer's perspective, this is a standard tax with a non-zero percentage but
            //         # two tax repartition lines that cancel each other out.
            //         # But from the seller's perspective, this is a zero-percent tax (VAT liability is deferred
            //         # to the buyer).
            //         # For a self-billed invoice we, the buyer, create the invoice on behalf of the seller.
            //         # So in the XML we put the zero-percent tax with code 'AE' that the seller would have used.
            //         return 'AE'
            //     else:
            //         return 'S'  # standard VAT
            // 
            // if supplier.country_id.code in european_economic_area and supplier.vat:
            //     if tax.amount != 0 and not tax.has_negative_factor:
            //         # Special case: Purchase reverse-charge taxes for self-billed invoices.
            //         # See explanation above.
            //         # In the XML we put the zero-percent tax with code 'G' or 'K' that the buyer would have used.
            //         return 'S'
            //     if customer.country_id.code not in european_economic_area:
            //         return 'G'
            //     if customer.country_id.code in european_economic_area:
            //         return 'K'
            // 
            // if tax.amount != 0:
            //     return 'S'
            // else:
            //     return 'E'
            */
            return default;
        }

        public async Task<TEntity> GetTaxExemptionReasonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_tax_exemption_reason(self, customer, supplier, tax):
            // """ Returns the reason and code from the tax if available.
            //     If not, it falls back to the default tax exemption reason defined for the respective tax category code.
            // 
            //     Note: In Peppol, taxes should be grouped by tax category code but *not* by
            //     exemption reason, see https://docs.peppol.eu/poacc/billing/3.0/bis/#_calculation_of_vat
            // """
            // 
            // if tax and (code := tax.ubl_cii_tax_exemption_reason_code):
            //     return {
            //         'tax_exemption_reason_code': code,
            //         'tax_exemption_reason': TAX_EXEMPTION_MAPPING.get(code, _("Exempt from tax") if tax.ubl_cii_requires_exemption_reason else None),
            //     }
            // 
            // tax_category_code = self._get_tax_category_code(customer, supplier, tax)
            // tax_exemption_reason = tax_exemption_reason_code = None
            // 
            // if not tax:
            //     tax_exemption_reason = _("Exempt from tax")
            // elif tax_category_code == 'E':
            //     tax_exemption_reason = _('Articles 226 items 11 to 15 Directive 2006/112/EN')
            // elif tax_category_code == 'G':
            //     tax_exemption_reason = _('Export outside the EU')
            //     tax_exemption_reason_code = 'VATEX-EU-G'
            // elif tax_category_code == 'K':
            //     tax_exemption_reason = _('Intra-Community supply')
            //     tax_exemption_reason_code = 'VATEX-EU-IC'
            // 
            // return {
            //     'tax_exemption_reason': tax_exemption_reason,
            //     'tax_exemption_reason_code': tax_exemption_reason_code,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_tax_nodes(self, tree):
            // return tree.findall('.//{*}ApplicableTradeTax/{*}RateApplicablePercent')
            */
            return default;
        }

        public async Task<TEntity> GetUomUneceCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uom) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_uom_unece_code(self, uom):
            // """
            // list of codes: https://docs.peppol.eu/poacc/billing/3.0/codelist/UNECERec20/
            // or https://unece.org/fileadmin/DAM/cefact/recommendations/bkup_htm/add2c.htm (sorted by letter)
            // """
            // xmlid = uom.get_external_id()
            // if xmlid and uom.id in xmlid:
            //     return UOM_TO_UNECE_CODE.get(xmlid[uom.id], 'C62')
            // return 'C62'
            */
            return default;
        }

        public async Task<TEntity> ImportAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_attachments(self, invoice, tree):
            // # Import the embedded documents in the xml if some are found
            // attachments = self.env['ir.attachment']
            // additional_docs = tree.findall('./{*}AdditionalDocumentReference')
            // for document in additional_docs:
            //     attachment_name = document.find('{*}ID')
            //     attachment_data = document.find('{*}Attachment/{*}EmbeddedDocumentBinaryObject')
            //     if attachment_name is not None and attachment_data is not None:
            //         mimetype = attachment_data.attrib.get('mimeCode')
            //         if not (extension := SUPPORTED_FILE_TYPES.get(mimetype)):
            //             continue
            //         text = attachment_data.text
            //         # Normalize the name of the file : some e-fff emitters put the full path of the file
            //         # (Windows or Linux style) and/or the name of the xml instead of the pdf.
            //         # Get only the filename with the right extension.
            //         name = (attachment_name.text or 'invoice').split('\\')[-1].split('/')[-1].split('.')[0] + extension
            //         attachment = self.env['ir.attachment'].create({
            //             'name': name,
            //             'res_id': invoice.id,
            //             'res_model': 'account.move',
            //             'datas': text + '=' * (len(text) % 3),  # Fix incorrect padding
            //             'type': 'binary',
            //             'mimetype': mimetype,
            //         })
            //         # Upon receiving an email (containing an xml) with a configured alias to create invoice, the xml is
            //         # set as the main_attachment. To be rendered in the form view, the pdf should be the main_attachment.
            //         if invoice.message_main_attachment_id and \
            //                 invoice.message_main_attachment_id.name.endswith('.xml') and \
            //                 'pdf' not in invoice.message_main_attachment_id.mimetype and \
            //                 mimetype == 'application/pdf':
            //             invoice._message_set_main_attachment_id(attachment, force=True, filter_xml=False)
            //         attachments |= attachment
            // 
            // return attachments
            */
            return default;
        }

        public async Task<TEntity> ImportCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object xpath) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_currency(self, tree, xpath):
            // logs = []
            // currency_name = tree.findtext(xpath)
            // currency = self.env.company.currency_id
            // if currency_name is not None:
            //     currency = currency.with_context(active_test=False).search([
            //         ('name', '=', currency_name),
            //     ], limit=1)
            //     if currency:
            //         if not currency.active:
            //             logs.append(_("The currency '%s' is not active.", currency.name))
            //     else:
            //         logs.append(_("Could not retrieve currency: %s. Did you enable the multicurrency option "
            //                       "and activate the currency?", currency_name))
            // return currency.id, logs
            */
            return default;
        }

        public async Task<TEntity> ImportDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object xpaths) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_description(self, tree, xpaths):
            // description = ""
            // for xpath in xpaths:
            //     note = tree.findtext(xpath)
            //     if note:
            //         description += f"<p>{html_escape(note)}</p>"
            // return description
            */
            return default;
        }

        public async Task<TEntity> ImportDocumentAllowanceChargesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object record, object tax_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_document_allowance_charges(self, tree, record, tax_type, qty_factor=1):
            // logs = []
            // xpaths = self._get_document_allowance_charge_xpaths()
            // line_vals = []
            // for allow_el in tree.iterfind(xpaths['root']):
            //     name = allow_el.findtext(xpaths['reason']) or ""
            //     # Charge indicator factor: -1 for discount, 1 for charge
            //     charge_indicator = -1 if allow_el.findtext(xpaths['charge_indicator']).lower() == 'false' else 1
            //     amount = float(allow_el.findtext(xpaths['amount']) or 0)
            //     base_amount = float(allow_el.findtext(xpaths['base_amount']) or 0)
            //     if base_amount:
            //         price_unit = base_amount * charge_indicator * qty_factor
            //         percentage = float(allow_el.findtext(xpaths['percentage']) or 100)
            //         quantity = percentage / 100
            //     else:
            //         price_unit = amount * charge_indicator * qty_factor
            //         quantity = 1
            // 
            //     # Taxes
            //     tax_ids = []
            //     for tax_percent_node in allow_el.iterfind(xpaths['tax_percentage']):
            //         tax_amount = float(tax_percent_node.text)
            //         tax = self.env['account.tax'].search([
            //             *self.env['account.tax']._check_company_domain(record.company_id),
            //             ('amount', '=', tax_amount),
            //             ('amount_type', '=', 'percent'),
            //             ('type_tax_use', '=', tax_type),
            //         ], limit=1)
            //         if tax:
            //             tax_ids += tax.ids
            //         elif name:
            //             logs.append(_(
            //                 "Could not retrieve the tax: %(tax_percentage)s %% for line '%(line)s'.",
            //                 tax_percentage=tax_amount,
            //                 line=name,
            //             ))
            //         else:
            //             logs.append(
            //                 _("Could not retrieve the tax: %s for the document level allowance/charge.", tax_amount))
            // 
            //     line_vals.append([name, quantity, price_unit, tax_ids])
            // return record._get_line_vals_list(line_vals), logs
            */
            return default;
        }

        public async Task<TEntity> ImportFillInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _import_fill_invoice(self, invoice, tree, qty_factor):
            // logs = []
            // invoice_values = {}
            // if qty_factor == -1:
            //     logs.append(_("The invoice has been converted into a credit note and the quantities have been reverted."))
            // role = 'SellerTradeParty' if invoice.journal_id.type == 'purchase' else 'BuyerTradeParty'
            // partner, partner_logs = self._import_partner(invoice.company_id, **self._import_retrieve_partner_vals(tree, role))
            // # Need to set partner before to compute bank and lines properly
            // invoice.partner_id = partner.id
            // invoice_values['currency_id'], currency_logs = self._import_currency(tree, './/{*}InvoiceCurrencyCode')
            // 
            // # ==== partner_bank_id ====
            // bank_detail_nodes = tree.findall('.//{*}SpecifiedTradeSettlementPaymentMeans')
            // bank_details = [
            //     bank_detail_node.findtext('{*}PayeePartyCreditorFinancialAccount/{*}IBANID')
            //     or bank_detail_node.findtext('{*}PayeePartyCreditorFinancialAccount/{*}ProprietaryID')
            //     for bank_detail_node in bank_detail_nodes
            // ]
            // if bank_details:
            //     self._import_partner_bank(invoice, bank_details=bank_details)
            // 
            // # ==== ref, invoice_origin, narration, payment_reference ====
            // invoice_values['ref'] = tree.findtext('./{*}ExchangedDocument/{*}ID')
            // invoice_values['invoice_origin'] = tree.findtext(
            //     './/{*}BuyerOrderReferencedDocument/{*}IssuerAssignedID'
            // )
            // invoice_values['narration'] = self._import_description(tree, xpaths=[
            //     './{*}ExchangedDocument/{*}IncludedNote/{*}Content',
            //     './/{*}SpecifiedTradePaymentTerms/{*}Description',
            // ])
            // invoice_values['payment_reference'] = tree.findtext(
            //     './{*}SupplyChainTradeTransaction/{*}ApplicableHeaderTradeSettlement/{*}PaymentReference'
            // )
            // 
            // # ==== invoice_date, invoice_date_due ====
            // issue_date = tree.findtext('./{*}ExchangedDocument/{*}IssueDateTime/{*}DateTimeString')
            // if issue_date:
            //     invoice_values['invoice_date'] = datetime.strptime(issue_date.strip(), DEFAULT_FACTURX_DATE_FORMAT)
            // due_date = tree.findtext('.//{*}SpecifiedTradePaymentTerms/{*}DueDateDateTime/{*}DateTimeString')
            // if due_date:
            //     invoice_values['invoice_date_due'] = datetime.strptime(due_date.strip(), DEFAULT_FACTURX_DATE_FORMAT)
            // 
            // # ==== Document level AllowanceCharge, Prepaid Amounts, Invoice Lines ====
            // allowance_charges_line_vals, allowance_charges_logs = self._import_document_allowance_charges(
            //     tree, invoice, invoice.journal_id.type, qty_factor,
            // )
            // logs += self._import_prepaid_amount(invoice, tree, './/{*}ApplicableHeaderTradeSettlement/{*}SpecifiedTradeSettlementHeaderMonetarySummation/{*}TotalPrepaidAmount', qty_factor)
            // invoice_line_vals, line_logs = self._import_lines(invoice, tree, './{*}SupplyChainTradeTransaction/{*}IncludedSupplyChainTradeLineItem',
            //                                                   document_type=invoice.move_type, tax_type=invoice.journal_id.type, qty_factor=qty_factor)
            // line_vals = allowance_charges_line_vals + invoice_line_vals
            // 
            // invoice_values = {
            //     **invoice_values,
            //     'invoice_line_ids': [Command.create(line_value) for line_value in line_vals],
            // }
            // invoice.write(invoice_values)
            // logs += partner_logs + currency_logs + line_logs + allowance_charges_logs
            // return logs
            */
            return default;
        }

        public async Task<TEntity> ImportInvoiceUblCiiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object file_data, object @new) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_invoice_ubl_cii(self, invoice, file_data, new=False):
            // invoice.ensure_one()
            // if invoice.invoice_line_ids:
            //     return invoice._reason_cannot_decode_has_invoice_lines()
            // 
            // tree = file_data['xml_tree']
            // 
            // # Not able to decode the move_type from the xml.
            // move_type, qty_factor = self._get_import_document_amount_sign(tree)
            // if not move_type:
            //     return
            // 
            // # Check for inconsistent move_type.
            // journal = invoice.journal_id
            // if journal.type == 'sale':
            //     move_type = 'out_' + move_type
            // elif journal.type == 'purchase':
            //     move_type = 'in_' + move_type
            // else:
            //     return
            // if not new and invoice.move_type != move_type:
            //     # with an email alias to create account_move, first the move is created (using alias_defaults, which
            //     # contains move_type = 'out_invoice') then the attachment is decoded, if it represents a credit note,
            //     # the move type needs to be changed to 'out_refund'
            //     types = {move_type, invoice.move_type}
            //     if types == {'out_invoice', 'out_refund'} or types == {'in_invoice', 'in_refund'}:
            //         invoice.move_type = move_type
            //     else:
            //         return
            // 
            // # Update the invoice.
            // invoice.move_type = move_type
            // with invoice._get_edi_creation() as invoice:
            //     fill_invoice_logs = self._import_fill_invoice(invoice, tree, qty_factor)
            // 
            // # For UBL, we should override the computed tax amount if it is less than 0.05 different of the one in the xml.
            // # In order to support use case where the tax total is adapted for rounding purpose.
            // # This has to be done after the first import in order to let Odoo compute the taxes before overriding if needed.
            // with invoice._get_edi_creation() as invoice:
            //     self._correct_invoice_tax_amount(tree, invoice)
            // 
            // source_attachment = file_data['attachment'] or self.env['ir.attachment']
            // attachments = source_attachment + self._import_attachments(invoice, tree)
            // 
            // self._log_import_invoice_ubl_cii(invoice, invoice_logs=fill_invoice_logs, attachments=attachments)
            */
            return default;
        }

        public async Task<TEntity> ImportLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object tree, object xpath, object document_type, object tax_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_lines(self, record, tree, xpath, document_type=False, tax_type=False, qty_factor=1):
            // logs = []
            // lines_values = []
            // for line_tree in tree.iterfind(xpath):
            //     line_values = self.with_company(record.company_id)._retrieve_invoice_line_vals(line_tree, document_type, qty_factor)
            //     line_values['tax_ids'], tax_logs = self._retrieve_taxes(record, line_values, tax_type)
            //     logs += tax_logs
            //     if not line_values['product_uom_id']:
            //         line_values.pop('product_uom_id')  # if no uom, pop it so it's inferred from the product_id
            //     lines_values.append(line_values)
            //     lines_values += self._retrieve_line_charges(record, line_values, line_values['tax_ids'])
            // return lines_values, logs
            */
            return default;
        }

        public async Task<TEntity> ImportPartnerBankInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object bank_details) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_partner_bank(self, invoice, bank_details):
            // """ Retrieve the bank account, if no matching bank account is found, create it """
            // # clear the context, because creation of partner when importing should not depend on the context default values
            // ResPartnerBank = self.env['res.partner.bank'].with_env(self.env(context=clean_context(self.env.context)))
            // bank_details = list(set(map(sanitize_account_number, bank_details)))
            // partner = self.env.company.partner_id if invoice.is_inbound() else invoice.partner_id
            // banks_to_create = []
            // acc_number_partner_bank_dict = {
            //     bank.sanitized_acc_number: bank
            //     for bank in ResPartnerBank.with_context(active_test=False).search(
            //         [('company_id', 'in', [False, invoice.company_id.id]), ('acc_number', 'in', bank_details)]
            //     )
            // }
            // for account_number in bank_details:
            //     partner_bank = acc_number_partner_bank_dict.get(account_number, ResPartnerBank)
            //     if partner_bank.partner_id == partner:
            //         if not partner_bank.active:
            //             partner_bank.active = True
            //         invoice.partner_bank_id = partner_bank
            //         return
            //     elif not partner_bank and account_number:
            //         banks_to_create.append({
            //             'acc_number': account_number,
            //             'partner_id': partner.id,
            //         })
            // if banks_to_create:
            //     invoice.partner_bank_id = ResPartnerBank.create(banks_to_create)[0]
            */
            return default;
        }

        public async Task<TEntity> ImportPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object name, object phone, object email, object vat) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_partner(self, company_id, name, phone, email, vat, *, peppol_eas=False, peppol_endpoint=False, postal_address={}, **kwargs):
            // """ Retrieve the partner, if no matching partner is found, create it (only if he has a vat and a name) """
            // logs = []
            // if peppol_eas and peppol_endpoint:
            //     domain = [('peppol_eas', '=', peppol_eas), ('peppol_endpoint', '=', peppol_endpoint)]
            // else:
            //     domain = False
            // partner = self.env['res.partner'] \
            //     .with_company(company_id) \
            //     ._retrieve_partner(name=name, phone=phone, email=email, vat=vat, domain=domain)
            // country_code = postal_address.get('country_code')
            // country = self.env['res.country'].search([('code', '=', country_code.upper())]) if country_code else self.env['res.country']
            // state_code = postal_address.get('state_code')
            // state = self.env['res.country.state'].search(
            //     [('country_id', '=', country.id), ('code', '=', state_code)],
            //     limit=1,
            // ) if state_code and country else self.env['res.country.state']
            // if not partner and name and vat:
            //     partner_vals = {'name': name, 'email': email, 'phone': phone, 'is_company': True}
            //     if peppol_eas and peppol_endpoint:
            //         partner_vals.update({'peppol_eas': peppol_eas, 'peppol_endpoint': peppol_endpoint})
            //     partner = self.env['res.partner'].create(partner_vals)
            //     if vat:
            //         partner.vat, _country_code = self.env['res.partner']._run_vat_checks(country, vat, validation='setnull')
            //     logs.append(_("Could not retrieve a partner corresponding to '%s'. A new partner was created.", name))
            // elif not partner and not logs:
            //     logs.append(_("Could not retrieve partner with details: Name: %(name)s, Vat: %(vat)s, Phone: %(phone)s, Email: %(email)s",
            //           name=name, vat=vat, phone=phone, email=email))
            // if not partner.country_id and not partner.street and not partner.street2 and not partner.city and not partner.zip and not partner.state_id:
            //     partner.write({
            //         'country_id': country.id,
            //         'street': postal_address.get('street'),
            //         'street2': postal_address.get('additional_street'),
            //         'city': postal_address.get('city'),
            //         'zip': postal_address.get('zip'),
            //         'state_id': state.id,
            //     })
            // return partner, logs
            */
            return default;
        }

        public async Task<TEntity> ImportPrepaidAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object xpath, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_prepaid_amount(self, invoice, tree, xpath, qty_factor):
            // logs = []
            // prepaid_amount = float(tree.findtext(xpath) or 0)
            // if not invoice.currency_id.is_zero(prepaid_amount):
            //     amount = prepaid_amount * qty_factor
            //     formatted_amount = formatLang(self.env, amount, currency_obj=invoice.currency_id)
            //     logs.append(_("A payment of %s was detected.", formatted_amount))
            // return logs
            */
            return default;
        }

        public async Task<TEntity> ImportProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_product(self, **product_vals):
            // return self.env['product.product']._retrieve_product(**product_vals)
            */
            return default;
        }

        public async Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _import_retrieve_partner_vals(self, tree, role):
            // return {
            //     'vat': self._find_value(f".//ram:{role}/ram:SpecifiedTaxRegistration/ram:ID[string-length(text()) > 5]", tree),
            //     'name': self._find_value(f".//ram:{role}/ram:Name", tree),
            //     'phone': self._find_value(f".//ram:{role}/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication/ram:CompleteNumber", tree),
            //     'email': self._find_value(f".//ram:{role}//ram:EmailURIUniversalCommunication/ram:URIID", tree),
            //     'postal_address': self._get_postal_address(tree, role),
            // }
            */
            return default;
        }

        public async Task<TEntity> ImportRoundingAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object xpath, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_rounding_amount(self, invoice, tree, xpath, document_type=False, qty_factor=1):
            // """
            // Add an invoice line representing the rounding amount given in the document.
            // - The amount is assumed to be in document currency
            // """
            // logs = []
            // lines_values = []
            // 
            // currency = invoice.currency_id
            // rounding_amount_currency = currency.round(qty_factor * float(tree.findtext(xpath) or 0))
            // 
            // if invoice.currency_id.is_zero(rounding_amount_currency):
            //     return lines_values, logs
            // 
            // inverse_rate = abs(invoice.amount_total_signed) / invoice.amount_total if invoice.amount_total else 0
            // rounding_amount = invoice.company_id.currency_id.round(rounding_amount_currency * inverse_rate)
            // 
            // lines_values.append({
            //     'display_type': 'product',
            //     'name': _('Rounding'),
            //     'quantity': 1,
            //     'product_id': False,
            //     'price_unit': rounding_amount_currency,
            //     'amount_currency': invoice.direction_sign * rounding_amount_currency,
            //     'balance': invoice.direction_sign * rounding_amount,
            //     'company_id': invoice.company_id.id,
            //     'move_id': invoice.id,
            //     'tax_ids': False,
            // })
            // 
            // formatted_amount = formatLang(self.env, rounding_amount_currency, currency_obj=currency)
            // logs.append(_("A rounding amount of %s was detected.", formatted_amount))
            // 
            // return lines_values, logs
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsCommonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _invoice_constraints_common(self, invoice):
            // # check that there is a tax on each line
            // for line in invoice.invoice_line_ids.filtered(lambda x: x.display_type not in ('line_section', 'line_subsection', 'line_note') and x._check_edi_line_tax_required()):
            //     if not line.tax_ids:
            //         return {'tax_on_line': _("Each invoice line should have at least one tax.")}
            // return {}
            */
            return default;
        }

        public async Task<TEntity> LogImportInvoiceUblCiiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object title_logs, object invoice_logs, object attachments) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _log_import_invoice_ubl_cii(self, invoice, title_logs=None, invoice_logs=None, attachments=None):
            // invoice.ensure_one()
            // body = Markup("<strong>%s</strong>") % (title_logs or self.env._("Invoice imported"))
            // if invoice_logs := self._add_logs_import_invoice_ubl_cii(invoice, invoice_logs=invoice_logs):
            //     body += Markup("<ul>%s</ul>") % \
            //             Markup().join(Markup("<li>%s</li>") % l for l in invoice_logs)
            // invoice.message_post(body=body, attachment_ids=attachments.ids if attachments else None)
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: account_edi_common.py) ---
            // def _log_import_invoice_ubl_cii(self, invoice, title_logs=None, invoice_logs=None, attachments=None):
            // # EXTENDS 'account_edi_ubl_cii'
            // if invoice.peppol_message_uuid:
            //     title_logs = self.env._("Peppol invoice received")
            // super()._log_import_invoice_ubl_cii(invoice, title_logs=title_logs, invoice_logs=invoice_logs, attachments=attachments)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrieveChargeAllowanceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object xpath_dict, object quantity) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _retrieve_charge_allowance_vals(self, tree, xpath_dict, quantity):
            // charges = []
            // discount_amount = 0
            // for allowance_charge_node in tree.iterfind(xpath_dict['allowance_charge']):
            //     charge_indicator = allowance_charge_node.findtext(xpath_dict['allowance_charge_indicator'])
            //     amount = float(allowance_charge_node.findtext(xpath_dict['allowance_charge_amount'], default='0'))
            //     reason_code = allowance_charge_node.findtext(xpath_dict['allowance_charge_reason_code'], default='')
            //     reason = allowance_charge_node.findtext(xpath_dict['allowance_charge_reason'], default='')
            //     if charge_indicator.lower() == 'true':
            //         charges.append({
            //             'amount': amount,
            //             'line_quantity': quantity,
            //             'reason': reason,
            //             'reason_code': reason_code,
            //         })
            //     else:
            //         discount_amount += amount
            // return discount_amount, charges
            */
            return default;
        }

        public async Task<TEntity> RetrieveFixedTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object fixed_tax_vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _retrieve_fixed_tax(self, company_id, fixed_tax_vals):
            // """ Retrieve the fixed tax at import, iteratively search for a tax:
            // 1. not price_include matching the name and the amount
            // 2. not price_include matching the amount
            // 3. price_include matching the name and the amount
            // 4. price_include matching the amount
            // """
            // base_domain = [
            //     *self.env['account.journal']._check_company_domain(company_id),
            //     ('amount_type', '=', 'fixed'),
            //     ('amount', '=', fixed_tax_vals['amount']),
            // ]
            // for price_include in (False, True):
            //     for name in (fixed_tax_vals['reason'], False):
            //         domain = base_domain + [('price_include', '=', price_include)]
            //         if name:
            //             domain.append(('name', '=', name))
            //         tax = self.env['account.tax'].search(domain, limit=1)
            //         if tax:
            //             return tax
            // return self.env['account.tax']
            */
            return default;
        }

        public async Task<TEntity> RetrieveInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _retrieve_invoice_line_vals(self, tree, document_type=False, qty_factor=1):
            // # Start and End date (enterprise fields)
            // xpath_dict = self._get_invoice_line_xpaths(document_type, qty_factor)
            // deferred_values = {}
            // start_date = end_date = None
            // if self.env['account.move.line']._fields.get('deferred_start_date'):
            //     start_date_node = tree.find(xpath_dict['deferred_start_date'])
            //     end_date_node = tree.find(xpath_dict['deferred_end_date'])
            //     if start_date_node is not None and end_date_node is not None:  # there is a constraint forcing none or the two to be set
            //         start_date = datetime.strptime(start_date_node.text.strip(), xpath_dict['date_format'])
            //         end_date = datetime.strptime(end_date_node.text.strip(), xpath_dict['date_format'])
            //     deferred_values = {
            //         'deferred_start_date': start_date,
            //         'deferred_end_date': end_date,
            //     }
            // 
            // return {
            //     **self._retrieve_line_vals(tree, document_type, qty_factor),
            //     **deferred_values,
            // }
            */
            return default;
        }

        public async Task<TEntity> RetrieveLineChargesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object line_values, object taxes) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _retrieve_line_charges(self, record, line_values, taxes):
            // """
            // Handle the charges on the document line at import.
            // 
            // For each charge on the line, it creates a new aml.
            // Special case: if the ReasonCode == 'AEO', there is a high chance the xml was produced by Odoo and the
            // corresponding line had a fixed tax, so it first tries to find a matching fixed tax to apply to the current aml.
            // """
            // charges_vals = []
            // for charge in line_values.pop('charges'):
            //     if charge['reason_code'] == 'AEO':
            //         # a 1 eur fixed tax on a line with quantity=2 will yield an AllowanceCharge with amount = 2
            //         charge_copy = charge.copy()
            //         charge_copy['amount'] /= charge_copy['line_quantity']
            //         if tax := self._retrieve_fixed_tax(record.company_id, charge_copy):
            //             taxes.append(tax.id)
            //             if tax.price_include:
            //                 line_values['price_unit'] += tax.amount
            //             continue
            //     charges_vals.append([
            //         charge['reason_code'] + " " + charge['reason'],
            //         1,
            //         charge['amount'],
            //         taxes,
            //     ])
            // return record._get_line_vals_list(charges_vals)
            */
            return default;
        }

        public async Task<TEntity> RetrieveLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _retrieve_line_vals(self, tree, document_type=False, qty_factor=1):
            // """
            // Read the xml invoice, extract the invoice line values, compute the odoo values
            // to fill an invoice line form: quantity, price_unit, discount, product_uom_id.
            // 
            // The way of computing invoice line is quite complicated:
            // https://docs.peppol.eu/poacc/billing/3.0/bis/#_calculation_on_line_level (same as in factur-x documentation)
            // 
            // line_net_subtotal = ( gross_unit_price - rebate ) * (delivered_qty / basis_qty) - allow_charge_amount
            // 
            // with (UBL | CII):
            //     * net_unit_price = 'Price/PriceAmount' | 'NetPriceProductTradePrice' (mandatory) (BT-146)
            //     * gross_unit_price = 'Price/AllowanceCharge/BaseAmount' | 'GrossPriceProductTradePrice' (optional) (BT-148)
            //     * basis_qty = 'Price/BaseQuantity' | 'BasisQuantity' (optional, either below net_price node or
            //         gross_price node) (BT-149)
            //     * delivered_qty = 'InvoicedQuantity' (invoice) | 'BilledQuantity' (bill) | 'Quantity' (order) (mandatory) (BT-129)
            //     * allow_charge_amount = sum of 'AllowanceCharge' | 'SpecifiedTradeAllowanceCharge' (same level as Price)
            //         ON THE LINE level (optional) (BT-136 / BT-141)
            //     * line_net_subtotal = 'LineExtensionAmount' | 'LineTotalAmount' (mandatory) (BT-131)
            //     * rebate = 'Price/AllowanceCharge' | 'AppliedTradeAllowanceCharge' below gross_price node ! (BT-147)
            //         "item price discount" which is different from the usual allow_charge_amount
            //         gross_unit_price (BT-148) - rebate (BT-147) = net_unit_price (BT-146)
            // 
            // In Odoo, we obtain:
            // (1) = price_unit  =  gross_price_unit / basis_qty  =  (net_price_unit + rebate) / basis_qty
            // (2) = quantity  =  delivered_qty
            // (3) = discount (converted into a percentage)  =  100 * (1 - price_subtotal / (delivered_qty * price_unit))
            // (4) = price_subtotal
            // 
            // Alternatively, we could also set: quantity = delivered_qty/basis_qty
            // 
            // WARNING, the basis quantity parameter is annoying, for instance, an invoice with a line:
            //     item A  | price per unit of measure/unit price: 30  | uom = 3 pieces | billed qty = 3 | rebate = 2  | untaxed total = 28
            // Indeed, 30 $ / 3 pieces = 10 $ / piece => 10 * 3 (billed quantity) - 2 (rebate) = 28
            // 
            // UBL ROUNDING: "the result of Item line net
            //     amount = ((Item net price (BT-146)÷Item price base quantity (BT-149))×(Invoiced Quantity (BT-129))
            // must be rounded to two decimals, and the allowance/charge amounts are also rounded separately."
            // It is not possible to do it in Odoo.
            // """
            // xpath_dict = self._get_line_xpaths(document_type, qty_factor)
            // # basis_qty (optional)
            // basis_qty = float(self._find_value(xpath_dict['basis_qty'], tree) or 1) or 1.0
            // 
            // # gross_price_unit (optional)
            // gross_price_unit = None
            // gross_price_unit_node = tree.find(xpath_dict['gross_price_unit'])
            // if gross_price_unit_node is not None:
            //     gross_price_unit = float(gross_price_unit_node.text)
            // 
            // # net_price_unit (mandatory)
            // net_price_unit = None
            // net_price_unit_node = tree.find(xpath_dict['net_price_unit'])
            // if net_price_unit_node is not None:
            //     net_price_unit = float(net_price_unit_node.text)
            // 
            // # delivered_qty (mandatory)
            // delivered_qty = 1
            // product_vals = {k: self._find_value(v, tree) for k, v in xpath_dict['product'].items()}
            // product = self._import_product(**product_vals)
            // product_uom = self.env['uom.uom']
            // quantity_node = tree.find(xpath_dict['delivered_qty'])
            // if quantity_node is not None:
            //     delivered_qty = float(quantity_node.text)
            //     uom_xml = quantity_node.attrib.get('unitCode')
            //     if uom_xml:
            //         uom_infered_xmlid = [
            //             odoo_xmlid for odoo_xmlid, uom_unece in UOM_TO_UNECE_CODE.items() if uom_unece == uom_xml
            //         ]
            //         if uom_infered_xmlid:
            //             product_uom = self.env.ref(uom_infered_xmlid[0], raise_if_not_found=False) or self.env['uom.uom']
            // if product and product_uom and not product_uom._has_common_reference(product.product_tmpl_id.uom_id):
            //     # uom incompatibility
            //     product_uom = self.env['uom.uom']
            // 
            // # line_net_subtotal (mandatory)
            // price_subtotal = None
            // line_total_amount_node = tree.find(xpath_dict['line_total_amount'])
            // if line_total_amount_node is not None:
            //     price_subtotal = float(line_total_amount_node.text)
            // 
            // # quantity
            // quantity = delivered_qty * qty_factor
            // 
            // # rebate (optional)
            // rebate = self._retrieve_rebate_val(tree, xpath_dict, quantity)
            // 
            // # Charges are collected (they are used to create new lines), Allowances are transformed into discounts
            // discount_amount, charges = self._retrieve_charge_allowance_vals(tree, xpath_dict, quantity)
            // 
            // # price_unit
            // charge_amount = sum(d['amount'] for d in charges)
            // allow_charge_amount = discount_amount - charge_amount
            // if gross_price_unit is not None:
            //     price_unit = gross_price_unit / basis_qty
            // elif net_price_unit is not None:
            //     price_unit = (net_price_unit + rebate) / basis_qty
            // elif price_subtotal is not None:
            //     price_unit = (price_subtotal + allow_charge_amount) / (delivered_qty or 1)
            // else:
            //     raise UserError(_("No gross price, net price nor line subtotal amount found for line in xml"))
            // 
            // # discount
            // discount = 0
            // currency = self.env.company.currency_id
            // if not float_is_zero(delivered_qty * price_unit, currency.decimal_places) and price_subtotal is not None:
            //     inferred_discount = 100 * (1 - (price_subtotal - charge_amount) / currency.round(delivered_qty * price_unit))
            //     discount = inferred_discount if not float_is_zero(inferred_discount, currency.decimal_places) else 0.0
            // 
            // # Sometimes, the xml received is very bad; e.g.:
            // #   * unit price = 0, qty = 0, but price_subtotal = -200
            // #   * unit price = 0, qty = 1, but price_subtotal = -200
            // #   * unit price = 1, qty = 0, but price_subtotal = -200
            // # for instance, when filling a down payment as an document line. The equation in the docstring is not
            // # respected, and the result will not be correct, so we just follow the simple rule below:
            // if net_price_unit is not None and price_subtotal != net_price_unit * (delivered_qty / basis_qty) - allow_charge_amount:
            //     if net_price_unit == 0 and delivered_qty == 0:
            //         quantity = 1
            //         price_unit = price_subtotal
            //     elif net_price_unit == 0:
            //         price_unit = price_subtotal / delivered_qty
            //     elif delivered_qty == 0:
            //         quantity = price_subtotal / price_unit
            // 
            // return {
            //     # vals to be written on the document line
            //     'name': self._find_value(xpath_dict['name'], tree),
            //     'product_id': product.id,
            //     'product_uom_id': product_uom.id,
            //     'price_unit': price_unit,
            //     'quantity': quantity,
            //     'discount': discount,
            //     'tax_nodes': self._get_tax_nodes(tree),  # see `_retrieve_taxes`
            //     'charges': charges,  # see `_retrieve_line_charges`
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrieveRebateValInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object xpath_dict, object quantity) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _retrieve_rebate_val(self, tree, xpath_dict, quantity):
            // # Discount. /!\ as no percent discount can be set on a line, need to infer the percentage
            // # from the amount of the actual amount of the discount (the allowance charge)
            // rebate = 0
            // rebate_node = tree.find(xpath_dict['rebate'])
            // net_price_unit_node = tree.find(xpath_dict['net_price_unit'])
            // gross_price_unit_node = tree.find(xpath_dict['gross_price_unit'])
            // if rebate_node is not None:
            //     rebate = float(rebate_node.text)
            // elif net_price_unit_node is not None and gross_price_unit_node is not None:
            //     rebate = float(gross_price_unit_node.text) - float(net_price_unit_node.text)
            // return rebate
            */
            return default;
        }

        public async Task<TEntity> RetrieveTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object line_values, object tax_type, object tax_exigibility) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _retrieve_taxes(self, record, line_values, tax_type, tax_exigibility=False):
            // """
            // Retrieve the taxes on the document line at import.
            // 
            // In a UBL/CII xml, the Odoo "price_include" concept does not exist. Hence, first look for a price_include=False,
            // if it is unsuccessful, look for a price_include=True.
            // """
            // # Taxes: all amounts are tax excluded, so first try to fetch price_include=False taxes,
            // # if no results, try to fetch the price_include=True taxes. If results, need to adapt the price_unit.
            // logs = []
            // taxes = []
            // for tax_node in line_values.pop('tax_nodes'):
            //     amount = float(tax_node.text)
            //     domain = [
            //         *self.env['account.journal']._check_company_domain(record.company_id),
            //         ('amount_type', '=', 'percent'),
            //         ('type_tax_use', '=', tax_type),
            //         ('amount', '=', amount),
            //     ]
            //     tax = self.env['account.tax']
            //     if hasattr(record, '_get_specific_tax'):
            //         tax = record._get_specific_tax(line_values['name'], 'percent', amount, tax_type)
            //     if tax_exigibility:
            //         if not tax and tax_exigibility:
            //             tax = self.env['account.tax'].search(domain + [('price_include', '=', False), ('tax_exigibility', '=', tax_exigibility)], limit=1)
            //         if not tax and tax_exigibility:
            //             tax = self.env['account.tax'].search(domain + [('price_include', '=', True), ('tax_exigibility', '=', tax_exigibility)], limit=1)
            //         if not tax:
            //             logs.append(
            //                 _("Tax with matching exigibility could not be retrieved: '%(exigibility)s' for line '%(line)s'.",
            //                 exigibility=tax_exigibility,
            //                 line=line_values['name']),
            //             )
            //     if not tax:
            //         tax = self.env['account.tax'].search(domain + [('price_include', '=', False)], limit=1)
            //     if not tax:
            //         tax = self.env['account.tax'].search(domain + [('price_include', '=', True)], limit=1)
            // 
            //     if not tax:
            //         logs.append(
            //             _("Could not retrieve the tax: %(amount)s %% for line '%(line)s'.",
            //             amount=amount,
            //             line=line_values['name']),
            //         )
            //     else:
            //         taxes.append(tax.id)
            //         if tax.price_include:
            //             line_values['price_unit'] *= (1 + tax.amount / 100)
            // return taxes, logs
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesAllowanceChargesDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_base_line_ubl_values_allowance_charges_discount(self, vals):
            // """ Extract the amount implies by a discount. This amount will be turned into an allowances/charge
            // into 'base_line' -> '_ubl_values' -> 'allowance_charge_discount'.
            // 
            // From a 'base_line' having
            //     price_unit = 100
            //     quantity = 5
            //     discount = 20
            //     total_excluded_currency = (5 * 100) * 0.8 = 400
            // ... compute an 'allowance_charge_discount' or (5 * 100) - 400 = 100:
            // 
            // :param vals:        Some custom data.
            // """
            // base_lines = vals['base_lines']
            // company = vals['company']
            // company_currency = company.currency_id
            // currency = vals['currency_id']
            // 
            // for base_line in base_lines:
            //     ubl_values = base_line['_ubl_values']
            //     tax_details = base_line['tax_details']
            //     raw_discount_amount_currency = tax_details['raw_discount_amount_currency']
            //     raw_discount_amount = tax_details['raw_discount_amount']
            // 
            //     if (
            //         base_line['currency_id'].is_zero(raw_discount_amount_currency)
            //         and company.currency_id.is_zero(raw_discount_amount)
            //     ):
            //         ubl_values['allowance_charge_discount'] = None
            //         ubl_values['allowance_charge_discount_currency'] = None
            //     else:
            //         ubl_values['allowance_charge_discount'] = {
            //             'currency': company_currency,
            //             'percent': base_line['discount'],
            //             'amount': raw_discount_amount,
            //             'base_amount': tax_details['raw_gross_total_excluded'],
            //         }
            //         ubl_values['allowance_charge_discount_currency'] = {
            //             'currency': currency,
            //             'percent': base_line['discount'],
            //             'amount': raw_discount_amount_currency,
            //             'base_amount': tax_details['raw_gross_total_excluded_currency'],
            //         }
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesAllowanceChargesExciseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_base_line_ubl_values_allowance_charges_excise(self, vals):
            // """ Extract excise taxes from the current base lines.
            // Instead, add them under 'base_line' -> '_ubl_values' -> 'allowance_charges_excise'
            // to be reported as allowances/charges.
            // 
            // From a 'base_line' having
            //     price_unit = 99
            //     tax_ids = EXCISE of 1 + 21% tax
            //     total_excluded_currency = 99
            //     total_included_currency = 121
            //     taxes_data = [1, 21]
            //     recycling_contribution_data = []
            // ... turn it to:
            //     price_unit = 99
            //     tax_ids = 21% tax
            //     total_excluded_currency = 99
            //     total_included_currency = 121
            //     taxes_data = [21]
            //     recycling_contribution_data = [1]
            // 
            // :param vals:        Some custom data.
            // """
            // base_lines = vals['base_lines']
            // company = vals['company']
            // company_currency = company.currency_id
            // currency = vals['currency_id']
            // 
            // for base_line in base_lines:
            //     ubl_values = base_line['_ubl_values']
            //     tax_details = base_line['tax_details']
            //     taxes_data = tax_details['taxes_data']
            // 
            //     allowance_charges_excise = ubl_values['allowance_charges_excise'] = []
            //     allowance_charges_excise_currency = ubl_values['allowance_charges_excise_currency'] = []
            //     for tax_data in taxes_data:
            //         if self._ubl_is_excise_tax(tax_data):
            //             allowance_charges_excise.append({
            //                 'tax': tax_data['tax'],
            //                 'amount': tax_data['tax_amount'],
            //                 'currency': company_currency,
            //             })
            //             allowance_charges_excise_currency.append({
            //                 'tax': tax_data['tax'],
            //                 'amount': tax_data['tax_amount_currency'],
            //                 'currency': currency,
            //             })
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesAllowanceChargesRecyclingContributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_base_line_ubl_values_allowance_charges_recycling_contribution(self, vals):
            // """ Extract recycling contribution taxes such as RECUPEL, AUVIBEL, etc from the current base lines.
            // Instead, add them under 'base_line' -> '_ubl_values' -> 'allowance_charges_recycling_contribution'
            // to be reported as allowances/charges.
            // 
            // From a 'base_line' having
            //     price_unit = 99
            //     tax_ids = RECUPEL of 1 + 21% tax
            //     total_excluded_currency = 99
            //     total_included_currency = 121
            //     taxes_data = [1, 21]
            //     recycling_contribution_data = []
            // ... turn it to:
            //     price_unit = 99
            //     tax_ids = 21% tax
            //     total_excluded_currency = 99
            //     total_included_currency = 121
            //     taxes_data = [21]
            //     recycling_contribution_data = [1]
            // 
            // :param vals:        Some custom data.
            // """
            // base_lines = vals['base_lines']
            // company = vals['company']
            // company_currency = company.currency_id
            // currency = vals['currency_id']
            // 
            // for base_line in base_lines:
            //     ubl_values = base_line['_ubl_values']
            //     tax_details = base_line['tax_details']
            //     taxes_data = tax_details['taxes_data']
            // 
            //     allowance_charges_recycling_contribution = ubl_values['allowance_charges_recycling_contribution'] = []
            //     allowance_charges_recycling_contribution_currency = ubl_values['allowance_charges_recycling_contribution_currency'] = []
            //     for tax_data in taxes_data:
            //         if self._ubl_is_recycling_contribution_tax(tax_data):
            //             allowance_charges_recycling_contribution.append({
            //                 'tax': tax_data['tax'],
            //                 'amount': tax_data['tax_amount'],
            //                 'currency': company_currency,
            //             })
            //             allowance_charges_recycling_contribution_currency.append({
            //                 'tax': tax_data['tax'],
            //                 'amount': tax_data['tax_amount_currency'],
            //                 'currency': currency,
            //             })
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesItemInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_base_line_ubl_values_item(self, vals):
            // """ Add 'base_line' -> '_ubl_values' -> 'item'.
            // 
            // :param vals:        Some custom data.
            // """
            // AccountTax = self.env['account.tax']
            // base_lines = vals['base_lines']
            // company = vals['company']
            // company_currency = company.currency_id
            // currency = vals['currency_id']
            // 
            // for sub_currency, suffix in ((currency, '_currency'), (company_currency, '')):
            //     base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(
            //         base_lines=base_lines,
            //         grouping_function=lambda base_line, tax_data: self._ubl_default_tax_category_grouping_key(
            //             base_line,
            //             tax_data,
            //             vals,
            //             sub_currency,
            //         ),
            //     )
            //     for base_line, aggregated_values in base_lines_aggregated_values:
            //         item = base_line['_ubl_values'][f'item{suffix}'] = {
            //             'currency': sub_currency,
            //             'base_line': base_line,
            //             'classified_tax_categories': {},
            //         }
            //         for grouping_key, values in aggregated_values.items():
            //             if grouping_key:
            //                 item['classified_tax_categories'][grouping_key] = {
            //                     **grouping_key,
            //                     'base_amount': values[f'base_amount{suffix}'],
            //                     'tax_amount': values[f'tax_amount{suffix}'],
            //                 }
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesLineExtensionAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object use_company_currency) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_base_line_ubl_values_line_extension_amount(self, vals, use_company_currency=False):
            // """ Add 'base_line' -> '_ubl_values' -> 'line_extension_amount[_currency]'.
            // 
            // 'line_extension_amount' is the subtotal of the line but without tax plus charges.
            // 
            // :param vals:                    Some custom data.
            // :param use_company_currency:    Express the amount in company currency.
            // """
            // base_lines = vals['base_lines']
            // suffix = '' if use_company_currency else '_currency'
            // 
            // for base_line in base_lines:
            //     tax_details = base_line['tax_details']
            //     ubl_values = base_line['_ubl_values']
            //     amount = (
            //         tax_details[f'total_excluded{suffix}']
            //         + tax_details[f'delta_total_excluded{suffix}']
            //         + sum(
            //             allowance_charges_recycling_contribution['amount']
            //             for allowance_charges_recycling_contribution in ubl_values[f'allowance_charges_recycling_contribution{suffix}']
            //         )
            //         + sum(
            //             allowance_charges_excise['amount']
            //             for allowance_charges_excise in ubl_values[f'allowance_charges_excise{suffix}']
            //         )
            //         + (
            //             ubl_values[f'allowance_charge_discount{suffix}']['amount']
            //             if (
            //                 ubl_values[f'allowance_charge_discount{suffix}']
            //                 and ubl_values[f'allowance_charge_discount{suffix}']['amount'] < 0.0
            //             )
            //             else 0.0
            //         )
            //     )
            //     ubl_values['line_extension_amount'] = amount
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_base_line_ubl_values_price(self, vals):
            // """ Add 'price_amount' under 'base_line' -> '_ubl_values' -> 'price_amount[_currency]'.
            // 
            // 'price_amount' is price unit of a single unit of the product.
            // 
            // :param vals:        Some custom data.
            // """
            // base_lines = vals['base_lines']
            // 
            // for base_line in base_lines:
            //     tax_details = base_line['tax_details']
            //     ubl_values = base_line['_ubl_values']
            //     for currency_suffix in ('_currency', ''):
            //         ubl_values[f'price_amount{currency_suffix}'] = tax_details[f'raw_gross_price_unit{currency_suffix}']
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesAllowanceChargeEarlyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_values_allowance_charge_early_payment(self, vals):
            // """ Add 'vals' -> '_ubl_values' -> 'allowance_charges_early_payment' representing the allowance/charges
            // corresponding to a 'mixed' early payment.
            // 
            // Suppose an invoice with a base amount of 100 and a 21% tax.
            // The total of your invoice is 121.
            // With a 'mixed' early payment of 5%, 2 additional lines are added to the invoice:
            // One line having a negative amount of -5 with 21% tax.
            // Another line having a positive amount of 5 with no tax.
            // It means the 21% tax line will now be based on 95 instead of 100 leading to
            // - an untaxed amount of 95.0
            // - a tax amount of 95 * 0.21 = 19.95
            // - a total amount of 114.95
            // 
            // In the UBL, an allowance is added with an amount of 5 and 21% tax applied on it plus a charge with an amount of 5.
            // Basically, it's like you had a discount on the full amount but we put back the discount you get on the base as a charge
            // to only get the discount regarding the tax amount.
            // 
            // :param vals:        Some custom data.
            // """
            // AccountTax = self.env['account.tax']
            // base_lines = vals['base_lines']
            // company = vals['company']
            // company_currency = company.currency_id
            // currency = vals['currency_id']
            // 
            // ubl_values = vals['_ubl_values']
            // 
            // def grouping_function(base_line, tax_data, sub_currency):
            //     if self._ubl_is_early_payment_base_line(base_line):
            //         return self._ubl_default_tax_category_grouping_key(base_line, tax_data, vals, sub_currency)
            // 
            // for sub_currency, suffix in ((currency, '_currency'), (company_currency, '')):
            //     base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(
            //         base_lines=base_lines,
            //         grouping_function=lambda base_line, tax_data: grouping_function(base_line, tax_data, sub_currency),
            //     )
            //     values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            // 
            //     allowance_charges_early_payment = ubl_values[f'allowance_charges_early_payment{suffix}'] = []
            //     for grouping_key, values in values_per_grouping_key.items():
            //         if not grouping_key:
            //             continue
            // 
            //         allowance_charges_early_payment.append({
            //             'currency': sub_currency,
            //             'amount': values[f'total_excluded{suffix}'],
            //             'tax_categories': {
            //                 grouping_key: {
            //                     **grouping_key,
            //                     'base_amount': values[f'base_amount{suffix}'],
            //                     'tax_amount': values[f'tax_amount{suffix}'],
            //                 },
            //             },
            //         })
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesPayableRoundingAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_values_payable_rounding_amount(self, vals):
            // """ Add
            //     'vals' -> '_ubl_values' -> 'payable_rounding_amount[_currency]'.
            //     'vals' -> '_ubl_values' -> 'payable_rounding_base_lines'.
            // 
            // 'payable_rounding_amount' is rounding amount to be added to the total in case of a cash rounding.
            // 'payable_rounding_base_lines' are the rounding base lines.
            // 
            // :param vals:        Some custom data.
            // """
            // AccountTax = self.env['account.tax']
            // base_lines = vals['base_lines']
            // 
            // def grouping_function(base_line, tax_data):
            //     return base_line['special_type'] == 'cash_rounding'
            // 
            // base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(base_lines, grouping_function)
            // values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            // ubl_values = vals['_ubl_values']
            // ubl_values['payable_rounding_amount'] = 0.0
            // ubl_values['payable_rounding_amount_currency'] = 0.0
            // ubl_values['payable_rounding_base_lines'] = []
            // for grouping_key, values in values_per_grouping_key.items():
            //     if not grouping_key:
            //         continue
            // 
            //     ubl_values['payable_rounding_amount_currency'] += values['total_excluded_currency']
            //     ubl_values['payable_rounding_amount'] += values['total_excluded']
            //     for base_line, _taxes_data in values['base_line_x_taxes_data']:
            //         ubl_values['payable_rounding_base_lines'].append(base_line)
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeCompanyCurrencyIfForeignCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_values_tax_currency_code_company_currency_if_foreign_currency(self, vals):
            // """ Add 'vals' -> '_ubl_values' -> 'tax_currency_code'
            // 
            // The value is set only at the company currency when there is a foreign currency.
            // 
            // :param vals:    Some custom data.
            // """
            // company = vals['company']
            // currency = vals['currency_id']
            // vals['tax_currency_code'] = None if currency == company.currency_id else company.currency_id.name
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_values_tax_currency_code_company_currency(self, vals):
            // """ Add 'vals' -> '_ubl_values' -> 'tax_currency_code'
            // 
            // The company currency will always be set on it.
            // 
            // :param vals:    Some custom data.
            // """
            // vals['tax_currency_code'] = vals['company'].currency_id.name
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_values_tax_currency_code_empty(self, vals):
            // """ Add 'vals' -> '_ubl_values' -> 'tax_currency_code'
            // 
            // The value is empty.
            // 
            // :param vals:    Some custom data.
            // """
            // vals['tax_currency_code'] = None
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_values_tax_currency_code(self, vals):
            // """ Add 'vals' -> '_ubl_values' -> 'tax_currency_code'
            // 
            // :param vals:    Some custom data.
            // """
            // self._ubl_add_values_tax_currency_code_company_currency_if_foreign_currency(vals)
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_add_values_tax_totals(self, vals):
            // """ Add
            //     'vals' -> '_ubl_values' -> 'tax_totals'
            //     'vals' -> '_ubl_values' -> 'withholding_tax_totals'
            // 
            // 'tax_totals' will contain the total and subtotals for not-withholding taxes.
            // 'withholding_tax_totals' will contain the total and subtotals for withholding taxes.
            // 
            // :param vals:                        Some custom data.
            // """
            // AccountTax = self.env['account.tax']
            // base_lines = vals['base_lines']
            // company = vals['company']
            // company_currency = company.currency_id
            // currency = vals['currency_id']
            // 
            // ubl_values = vals['_ubl_values']
            // ubl_values['tax_totals'] = {}
            // ubl_values['tax_totals_currency'] = {}
            // ubl_values['withholding_tax_totals'] = {}
            // ubl_values['withholding_tax_totals_currency'] = {}
            // 
            // def tax_category_grouping_function(base_line, tax_data, sub_currency):
            //     tax_grouping_key = self._ubl_default_tax_category_grouping_key(base_line, tax_data, vals, sub_currency)
            //     if not tax_grouping_key:
            //         return
            //     return self._ubl_default_tax_subtotal_tax_category_grouping_key(tax_grouping_key, vals)
            // 
            // def tax_subtotal_grouping_function(base_line, tax_data, sub_currency):
            //     tax_category_grouping_key = tax_category_grouping_function(base_line, tax_data, sub_currency)
            //     if not tax_category_grouping_key:
            //         return
            //     return self._ubl_default_tax_subtotal_grouping_key(tax_category_grouping_key, vals)
            // 
            // def tax_totals_grouping_function(base_line, tax_data, sub_currency):
            //     tax_subtotal_grouping_key = tax_subtotal_grouping_function(base_line, tax_data, sub_currency)
            //     if not tax_subtotal_grouping_key:
            //         return
            //     return self._ubl_default_tax_total_grouping_key(tax_subtotal_grouping_key, vals)
            // 
            // for sub_currency, suffix in ((currency, '_currency'), (company_currency, '')):
            // 
            //     # tax_totals / withholding_tax_totals
            // 
            //     base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(
            //         base_lines=base_lines,
            //         grouping_function=lambda base_line, tax_data: tax_totals_grouping_function(base_line, tax_data, sub_currency),
            //     )
            //     values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            //     for grouping_key, values in values_per_grouping_key.items():
            //         if not grouping_key:
            //             continue
            // 
            //         if grouping_key['is_withholding']:
            //             target_key = f'withholding_tax_totals{suffix}'
            //             sign = -1
            //         else:
            //             target_key = f'tax_totals{suffix}'
            //             sign = 1
            // 
            //         ubl_values[target_key][frozendict(grouping_key)] = {
            //             **grouping_key,
            //             'amount': sign * values[f'tax_amount{suffix}'],
            //             'subtotals': {},
            //         }
            // 
            //     # tax_subtotals
            // 
            //     base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(
            //         base_lines=base_lines,
            //         grouping_function=lambda base_line, tax_data: tax_subtotal_grouping_function(base_line, tax_data, sub_currency),
            //     )
            //     values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            //     for grouping_key, values in values_per_grouping_key.items():
            //         if not grouping_key:
            //             continue
            // 
            //         if grouping_key['is_withholding']:
            //             target_key = f'withholding_tax_totals{suffix}'
            //             sign = -1
            //         else:
            //             target_key = f'tax_totals{suffix}'
            //             sign = 1
            // 
            //         tax_total_grouping_key = self._ubl_default_tax_total_grouping_key(grouping_key, vals)
            //         if not tax_total_grouping_key:
            //             continue
            // 
            //         tax_total_values = ubl_values[target_key][frozendict(tax_total_grouping_key)]
            //         tax_total_values['subtotals'][frozendict(grouping_key)] = {
            //             **grouping_key,
            //             'base_amount': values[f'base_amount{suffix}'],
            //             'tax_amount': sign * values[f'tax_amount{suffix}'],
            //             'tax_categories': {},
            //         }
            // 
            //     # tax_categories
            // 
            //     base_lines_aggregated_values = AccountTax._aggregate_base_lines_tax_details(
            //         base_lines=base_lines,
            //         grouping_function=lambda base_line, tax_data: tax_category_grouping_function(base_line, tax_data, sub_currency),
            //     )
            //     values_per_grouping_key = AccountTax._aggregate_base_lines_aggregated_values(base_lines_aggregated_values)
            //     for grouping_key, values in values_per_grouping_key.items():
            //         if not grouping_key:
            //             continue
            // 
            //         if grouping_key['is_withholding']:
            //             target_key = f'withholding_tax_totals{suffix}'
            //             sign = -1
            //         else:
            //             target_key = f'tax_totals{suffix}'
            //             sign = 1
            // 
            //         tax_subtotal_grouping_key = self._ubl_default_tax_subtotal_grouping_key(grouping_key, vals)
            //         if not tax_subtotal_grouping_key:
            //             continue
            // 
            //         tax_total_grouping_key = self._ubl_default_tax_total_grouping_key(tax_subtotal_grouping_key, vals)
            //         if not tax_total_grouping_key:
            //             continue
            // 
            //         tax_total_values = ubl_values[target_key][frozendict(tax_total_grouping_key)]
            //         tax_total_values['subtotals'][frozendict(tax_subtotal_grouping_key)]['tax_categories'][frozendict(grouping_key)] = {
            //             **grouping_key,
            //             'base_amount': values[f'base_amount{suffix}'],
            //             'tax_amount': sign * values[f'tax_amount{suffix}'],
            //         }
            // 
            //     for key in (f'withholding_tax_totals{suffix}', f'tax_totals{suffix}'):
            //         if not ubl_values[key]:
            //             ubl_values[key][None] = {
            //                 'currency': sub_currency,
            //                 'amount': 0.0,
            //                 'subtotals': {},
            //             }
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data, object vals, object currency) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_default_tax_category_grouping_key(self, base_line, tax_data, vals, currency):
            // """ Give the values about the tax category for a given tax.
            // 
            // :param base_line:   A base line (see '_prepare_base_line_for_taxes_computation').
            // :param tax_data:    One of the tax data in base_line['tax_details']['taxes_data'].
            // :param vals:        Some custom data.
            // :param currency:    The currency for which the grouping key is expressed.
            // :return:            A dictionary that could be used as a grouping key for the taxes helpers.
            // """
            // customer = vals['customer']
            // supplier = vals['supplier']
            // if tax_data and (
            //     tax_data['tax'].amount_type != 'percent'
            //     or self._ubl_is_recycling_contribution_tax(tax_data)
            //     or self._ubl_is_excise_tax(tax_data)
            // ):
            //     return
            // elif tax_data:
            //     tax = tax_data['tax']
            //     return {
            //         'tax_category_code': self._get_tax_category_code(customer.commercial_partner_id, supplier, tax),
            //         **self._get_tax_exemption_reason(customer.commercial_partner_id, supplier, tax),
            //         'percent': tax.amount,
            //         'scheme_id': 'VAT',
            //         'is_withholding': tax.amount < 0.0,
            //         'currency': currency,
            //     }
            // else:
            //     return {
            //         'tax_category_code': self._get_tax_category_code(customer.commercial_partner_id, supplier, self.env['account.tax']),
            //         **self._get_tax_exemption_reason(customer.commercial_partner_id, supplier, self.env['account.tax']),
            //         'percent': 0.0,
            //         'scheme_id': 'VAT',
            //         'is_withholding': False,
            //         'currency': currency,
            //     }
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxSubtotalGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_category_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_default_tax_subtotal_grouping_key(self, tax_category_grouping_key, vals):
            // """ Give the values about how taxes are grouped together in TaxTotal -> TaxSubtotal
            // (or WithholdingTaxTotal depending on 'is_withholding').
            // 
            // :param tax_category_grouping_key:   The grouping key returned by '_ubl_default_tax_subtotal_tax_category_grouping_key'.
            // :param vals:                        Some custom data.
            // :return:                            A dictionary that could be used as a grouping key for the taxes helpers.
            // """
            // return dict(tax_category_grouping_key)
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxSubtotalTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_default_tax_subtotal_tax_category_grouping_key(self, tax_grouping_key, vals):
            // """ Give the values about how taxes are grouped together in TaxTotal -> TaxSubtotal -> TaxCategory
            // (or WithholdingTaxTotal depending on 'is_withholding').
            // 
            // :param tax_grouping_key:            The grouping key returned by '_ubl_default_tax_category_grouping_key'.
            // :param vals:                        Some custom data.
            // :return:                            A dictionary that could be used as a grouping key for the taxes helpers.
            // """
            // return dict(tax_grouping_key)
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxTotalGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_subtotal_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_default_tax_total_grouping_key(self, tax_subtotal_grouping_key, vals):
            // """ Give the values about how taxes are grouped together in TaxTotal
            // (or WithholdingTaxTotal depending on 'is_withholding').
            // 
            // :param tax_subtotal_grouping_key:   The grouping key returned by '_ubl_default_tax_subtotal_grouping_key'.
            // :param vals:                        Some custom data.
            // :return:                            A dictionary that could be used as a grouping key for the taxes helpers.
            // """
            // return {
            //     'is_withholding': tax_subtotal_grouping_key['is_withholding'],
            //     'currency': tax_subtotal_grouping_key['currency'],
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetAllowanceChargeEarlyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object early_payment_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_allowance_charge_early_payment(self, vals, early_payment_values):
            // currency = early_payment_values['currency']
            // amount = early_payment_values['amount']
            // is_charge = amount > 0.0
            // return {
            //     '_currency': currency,
            //     'cbc:ChargeIndicator': {'_text': 'true' if is_charge else 'false'},
            //     'cbc:AllowanceChargeReasonCode': {'_text': 'ZZZ' if is_charge else '66'},
            //     'cbc:AllowanceChargeReason': {'_text': _("Conditional cash/payment discount")},
            //     'cbc:Amount': {
            //         '_text': currency.round(abs(amount)),
            //         'currencyID': currency.name,
            //     },
            //     'cac:TaxCategory': [
            //         self._ubl_get_allowance_charge_early_payment_tax_category_node(vals, tax_category)
            //         for tax_category in early_payment_values['tax_categories'].values()
            //     ],
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetAllowanceChargeEarlyPaymentTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_category) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_allowance_charge_early_payment_tax_category_node(self, vals, tax_category):
            // return {
            //     'cbc:ID': {'_text': tax_category['tax_category_code']},
            //     'cbc:Percent': {'_text': tax_category['percent']},
            //     'cac:TaxScheme': {
            //         'cbc:ID': {'_text': tax_category['scheme_id']},
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_line_allowance_charge_discount_node(self, vals, discount_values):
            // currency = discount_values['currency']
            // amount = discount_values['amount']
            // base_amount = discount_values['base_amount']
            // percent = discount_values['percent']
            // return {
            //     '_currency': currency,
            //     'cbc:ChargeIndicator': {'_text': 'true' if amount < 0.0 else 'false'},
            //     'cbc:MultiplierFactorNumeric': {'_text': abs(percent)},
            //     'cbc:AllowanceChargeReasonCode': {'_text': '95'},
            //     'cbc:AllowanceChargeReason': {'_text': _("Discount")},
            //     'cbc:Amount': {
            //         '_text': FloatFmt(abs(amount), max_dp=currency.decimal_places),
            //         'currencyID': currency.name,
            //     },
            //     'cbc:BaseAmount': {
            //         '_text': FloatFmt(abs(base_amount), max_dp=currency.decimal_places),
            //         'currencyID': currency.name,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeExciseNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object excise_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_line_allowance_charge_excise_node(self, vals, excise_values):
            // currency = excise_values['currency']
            // amount = excise_values['amount']
            // tax = excise_values['tax']
            // return {
            //     '_currency': currency,
            //     'cbc:ChargeIndicator': {'_text': 'true' if amount > 0.0 else 'false'},
            //     'cbc:AllowanceChargeReason': {'_text': tax.name},
            //     'cbc:Amount': {
            //         '_text': FloatFmt(abs(amount), max_dp=currency.decimal_places),
            //         'currencyID': currency.name,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeRecyclingContributionNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object recycling_contribution_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_line_allowance_charge_recycling_contribution_node(self, vals, recycling_contribution_values):
            // currency = recycling_contribution_values['currency']
            // amount = recycling_contribution_values['amount']
            // tax = recycling_contribution_values['tax']
            // return {
            //     '_currency': currency,
            //     'cbc:ChargeIndicator': {'_text': 'true' if amount > 0.0 else 'false'},
            //     'cbc:AllowanceChargeReasonCode': {'_text': 'AEO'},
            //     'cbc:AllowanceChargeReason': {'_text': tax.name},
            //     'cbc:Amount': {
            //         '_text': FloatFmt(abs(amount), max_dp=currency.decimal_places),
            //         'currencyID': currency.name,
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetLineItemNodeClassifiedTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_category) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_line_item_node_classified_tax_category_node(self, vals, tax_category):
            // """ Generate the node 'cac:ClassifiedTaxCategory' in 'cac:Item'.
            // 
            // :param vals:            Some custom data.
            // :param tax_category:    An entry of vals['_ubl_values']['item_classified_tax_categories']
            //                         containing all the necessary data to build the node.
            // :return:                A new node in 'cac:Item' -> 'cac:ClassifiedTaxCategory'.
            // """
            // return {
            //     'cbc:ID': {'_text': tax_category['tax_category_code']},
            //     'cbc:Percent': {'_text': tax_category['percent']},
            //     'cac:TaxScheme': {
            //         'cbc:ID': {'_text': tax_category['scheme_id']},
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetLineItemNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object item_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_line_item_node(self, vals, item_values):
            // item_node = {}
            // base_line = item_values['base_line']
            // product = base_line['product_id']
            // 
            // if product.default_code:
            //     item_node['cac:SellersItemIdentification'] = {
            //         'cbc:ID': {'_text': product.default_code},
            //     }
            // else:
            //     item_node['cac:SellersItemIdentification'] = None
            // if product.barcode:
            //     item_node['cac:StandardItemIdentification'] = {
            //         'cbc:ID': {
            //             '_text': product.barcode,
            //             'schemeID': '0160',  # GTIN
            //         },
            //     }
            // else:
            //     item_node['cac:StandardItemIdentification'] = None
            // item_node['cac:AdditionalItemProperty'] = [
            //     {
            //         'cbc:Name': {'_text': value.attribute_id.name},
            //         'cbc:Value': {'_text': value.name},
            //     }
            //     for value in product.product_template_attribute_value_ids
            // ]
            // 
            // if base_line.get('_removed_tax_data'):
            //     # Emptying tax extra line.
            //     name = description = base_line['_removed_tax_data']['tax'].name
            // else:
            //     name = product.name or ''
            //     if line_name := base_line.get('name'):
            //         # Regular business line.
            //         description = line_name
            //         if not name:
            //             name = line_name
            //     else:
            //         # Undefined line.
            //         description = product.description_sale or ''
            // 
            // if description:
            //     item_node['cbc:Description'] = {'_text': description}
            // else:
            //     item_node['cbc:Description'] = None
            // 
            // if name:
            //     item_node['cbc:Name'] = {'_text': name}
            // else:
            //     item_node['cbc:Name'] = None
            // 
            // item_node['cac:ClassifiedTaxCategory'] = [
            //     self._ubl_get_line_item_node_classified_tax_category_node(vals, tax_category)
            //     for tax_category in item_values['classified_tax_categories'].values()
            // ]
            // return item_node
            */
            return default;
        }

        public async Task<TEntity> UblGetTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_category) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_tax_category_node(self, vals, tax_category):
            // """ Generate the node 'cac:TaxCategory' in 'cac:SubTotal'.
            // 
            // :param vals:            Some custom data.
            // :param tax_category:    An entry of vals['_ubl_values'](['tax_totals']|['withholding_tax_totals'])['tax_subtotals']
            //                         containing all the necessary data to build the node.
            // :return:                A new node in 'cac:TaxTotal'.
            // """
            // return {
            //     'cbc:ID': {'_text': tax_category['tax_category_code']},
            //     'cbc:Percent': {'_text': tax_category['percent']},
            //     'cbc:TaxExemptionReasonCode': {'_text': tax_category.get('tax_exemption_reason_code')},
            //     'cbc:TaxExemptionReason': {'_text': tax_category.get('tax_exemption_reason')},
            //     'cac:TaxScheme': {
            //         'cbc:ID': {'_text': tax_category['scheme_id']},
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetTaxSubtotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_subtotal) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_tax_subtotal_node(self, vals, tax_subtotal):
            // """ Generate the node 'cac:SubTotal' in 'cac:TaxTotal'/'cac:WithholdingTaxTotal'.
            // 
            // Note: 'cac:TaxCategory' is managed by '_ubl_get_tax_category_node'.
            // 
            // :param vals:            Some custom data.
            // :param tax_subtotal:    An entry of vals['_ubl_values'](['tax_totals']|['withholding_tax_totals'])['tax_subtotals']
            //                         containing all the necessary data to build the node.
            // :return:                A new node in 'cac:TaxTotal'.
            // """
            // currency = tax_subtotal['currency']
            // return {
            //     'cbc:TaxableAmount': {
            //         '_text': FloatFmt(tax_subtotal['base_amount'], min_dp=currency.decimal_places),
            //         'currencyID': currency.name
            //     },
            //     'cbc:TaxAmount': {
            //         '_text': FloatFmt(tax_subtotal['tax_amount'], min_dp=currency.decimal_places),
            //         'currencyID': currency.name
            //     },
            //     'cac:TaxCategory': [
            //         self._ubl_get_tax_category_node(vals, tax_category)
            //         for tax_category in tax_subtotal['tax_categories'].values()
            //     ],
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetTaxTotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_total) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_tax_total_node(self, vals, tax_total):
            // """ Generate the node 'cac:TaxTotal'.
            // 
            // Note: 'cac:Subtotal' is managed by '_ubl_get_tax_subtotal_node'.
            // 
            // :param vals:            Some custom data.
            // :param tax_total:       An entry of vals['_ubl_values']['tax_totals'] containing all the necessary data to build the node.
            // :return:                A new node in 'cac:TaxTotal'.
            // """
            // currency = tax_total['currency']
            // return {
            //     '_currency': currency,
            //     'cbc:TaxAmount': {
            //         '_text': FloatFmt(tax_total['amount'], min_dp=currency.decimal_places),
            //         'currencyID': currency.name
            //     },
            //     'cac:TaxSubtotal': [
            //         self._ubl_get_tax_subtotal_node(vals, subtotal)
            //         for subtotal in tax_total['subtotals'].values()
            //     ],
            // }
            */
            return default;
        }

        public async Task<TEntity> UblGetWithholdingTaxTotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_total) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_get_withholding_tax_total_node(self, vals, tax_total):
            // """ Generate the node 'cac:WithholdingTaxTotal'.
            // 
            // Note: 'cac:Subtotal' is managed by '_ubl_get_tax_subtotal_node'.
            // 
            // :param vals:            Some custom data.
            // :param tax_total:       An entry of vals['_ubl_values']['withholding_tax_totals'] containing all the necessary data to build the node.
            // :return:                A new node in 'cac:WithholdingTaxTotal'.
            // """
            // return self._ubl_get_tax_total_node(vals, tax_total)
            */
            return default;
        }

        public async Task<TEntity> UblIsEarlyPaymentBaseLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_is_early_payment_base_line(self, base_line):
            // """ Indicate if the 'base_line' passed as parameter has been generated by an 'mixed' early payment.
            // 
            // :param base_line: A base line (see '_prepare_base_line_for_taxes_computation').
            // :return: True if the 'base_line' is a 'mixed' early payment line, False otherwise.
            // """
            // return base_line['special_type'] == 'early_payment'
            */
            return default;
        }

        public async Task<TEntity> UblIsExciseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_data) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_is_excise_tax(self, tax_data):
            // """ Indicate if the 'tax_data' passed as parameter is an excise tax.
            // 
            // :param tax_data:    One of the tax data in base_line['tax_details']['taxes_data'].
            // :return:            True if tax_data['tax'] is an excise tax, False otherwise.
            // """
            // if not tax_data:
            //     return False
            // 
            // tax = tax_data['tax']
            // return tax.amount_type == 'code' and tax.include_base_amount
            */
            return default;
        }

        public async Task<TEntity> UblIsRecyclingContributionTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_data) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_is_recycling_contribution_tax(self, tax_data):
            // """ Indicate if the 'tax_data' passed as parameter is a recycling contribution tax.
            // 
            // :param tax_data:    One of the tax data in base_line['tax_details']['taxes_data'].
            // :return:            True if tax_data['tax'] is a recycling contribution tax, False otherwise.
            // """
            // if not tax_data:
            //     return False
            // 
            // tax = tax_data['tax']
            // return tax.amount_type == 'fixed' and tax.include_base_amount
            */
            return default;
        }

        public async Task<TEntity> UblTurnEmptyingTaxesAsNewBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py) ---
            // def _ubl_turn_emptying_taxes_as_new_base_lines(self, base_lines, company, vals):
            // """ Extract emptying taxes such as "Vidanges" on bottles from the current base lines and turn them into
            // additional base lines.
            // 
            // :param base_lines:  The original 'base_lines' of the document.
            // :param company:     The company owning the 'base_lines'.
            // :param vals:        Some custom data.
            // """
            // AccountTax = self.env['account.tax']
            // 
            // def exclude_function(base_line, tax_data):
            //     if not tax_data:
            //         return
            // 
            //     tax = tax_data['tax']
            //     return tax.amount_type in ('fixed', 'code') and not tax.include_base_amount
            // 
            // new_base_lines = AccountTax._dispatch_taxes_into_new_base_lines(base_lines, company, exclude_function)
            // 
            // def aggregate_function(target_base_line, base_line):
            //     target_base_line.setdefault('_aggregated_quantity', 0.0)
            //     target_base_line['_aggregated_quantity'] += base_line['quantity']
            // 
            // extra_base_lines = AccountTax._turn_removed_taxes_into_new_base_lines(
            //     base_lines=new_base_lines,
            //     company=company,
            //     aggregate_function=aggregate_function,
            // )
            // 
            // # Restore back the values per quantity.
            // for base_line in extra_base_lines:
            //     base_line['quantity'] = base_line['_aggregated_quantity']
            //     base_line['price_unit'] /= base_line['_aggregated_quantity']
            //     base_line['product_id'] = self.env['product.product']
            // 
            // return new_base_lines + extra_base_lines
            */
            return default;
        }

        public async Task<TEntity> ValidateTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> tax_ids) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _validate_taxes(self, tax_ids):
            // """ Validate the structure of the tax repartition lines (invalid structure could lead to unexpected results) """
            // for tax in tax_ids:
            //     try:
            //         tax._validate_repartition_lines()
            //     except ValidationError as e:
            //         error_msg = _("Tax '%(tax_name)s' is invalid: %(error_message)s", tax_name=tax.name, error_message=e.args[0])  # args[0] gives the error message
            //         raise ValidationError(error_msg)
            */
            return default;
        }
    }
}