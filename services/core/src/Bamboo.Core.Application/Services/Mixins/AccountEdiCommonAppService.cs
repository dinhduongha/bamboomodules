using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("account_edi_ubl_cii", Depends = new[] { "account" })]
    public class AccountEdiCommonAppService : ApplicationService, IAccountEdiCommonAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiCommonAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AddDocumentAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_allowance_charge_nodes(self, document_node, vals):
            // """ Generic helper to fill the AllowanceCharge nodes for a document given a list of base_lines. """
            // # AllowanceCharge doesn't exist in debit notes in UBL 2.0
            // if vals['document_type'] != 'debit_note':
            //     document_node['cac:AllowanceCharge'] = []
            //     for base_line in vals['base_lines']:
            //         if self._is_document_allowance_charge(base_line):
            //             document_node['cac:AllowanceCharge'].append(
            //                 self._get_document_allowance_charge_node({**vals, 'base_line': base_line})
            //             )
            */
            return default;
        }

        public async Task<TEntity> AddDocumentCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_currency_vals(self, vals):
            // """ Add the 'currency_suffix', 'currency_dp' and 'currency_name'. """
            // vals['currency_suffix'] = '' if vals['use_company_currency'] else '_currency'
            // 
            // currency = vals['company_currency_id'] if vals['use_company_currency'] else vals['currency_id']
            // vals['currency_dp'] = self._get_currency_decimal_places(currency)
            // vals['currency_name'] = currency.name
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_allowance_charge_nodes(self, line_node, vals):
            // if vals['document_type'] not in {'credit_note', 'debit_note'}:
            //     line_node['cac:AllowanceCharge'] = [self._get_line_discount_allowance_charge_node(vals)]
            //     if vals['fixed_taxes_as_allowance_charges']:
            //         line_node['cac:AllowanceCharge'].extend(self._get_line_fixed_tax_allowance_charge_nodes(vals))
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_amount_nodes(self, line_node, vals):
            // currency_suffix = vals['currency_suffix']
            // base_line = vals['base_line']
            // 
            // quantity_tag = self._get_tags_for_document_type(vals)['line_quantity']
            // 
            // line_node.update({
            //     quantity_tag: {
            //         '_text': base_line['quantity'],
            //         'unitCode': self._get_uom_unece_code(base_line['product_uom_id']),
            //     },
            //     'cbc:LineExtensionAmount': {
            //         '_text': self.format_float(vals[f'total_excluded{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            // })
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineGrossSubtotalAndDiscountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_gross_subtotal_and_discount_vals(self, vals):
            // base_line = vals['base_line']
            // company_currency = vals['company_currency_id']
            // 
            // discount_factor = 1 - (base_line['discount'] / 100.0)
            // 
            // if discount_factor != 0.0:
            //     gross_subtotal_currency = base_line['currency_id'].round(base_line['tax_details']['raw_total_excluded_currency'] / discount_factor)
            //     gross_subtotal = company_currency.round(base_line['tax_details']['raw_total_excluded'] / discount_factor)
            // else:
            //     gross_subtotal_currency = base_line['currency_id'].round(base_line['price_unit'] * base_line['quantity'])
            //     gross_subtotal = company_currency.round(gross_subtotal_currency / base_line['rate'])
            // 
            // if base_line['quantity'] == 0.0 or discount_factor == 0.0:
            //     gross_price_unit_currency = base_line['price_unit']
            //     gross_price_unit = company_currency.round(base_line['price_unit'] / base_line['rate'])
            // else:
            //     gross_price_unit_currency = gross_subtotal_currency / base_line['quantity']
            //     gross_price_unit = gross_subtotal / base_line['quantity']
            // 
            // discount_amount_currency = gross_subtotal_currency - base_line['tax_details']['total_excluded_currency']
            // discount_amount = gross_subtotal - base_line['tax_details']['total_excluded']
            // 
            // vals.update({
            //     'discount_amount_currency': discount_amount_currency,
            //     'discount_amount': discount_amount,
            //     'gross_subtotal_currency': gross_subtotal_currency,
            //     'gross_subtotal': gross_subtotal,
            //     'gross_price_unit_currency': gross_price_unit_currency,
            //     'gross_price_unit': gross_price_unit,
            // })
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_id_nodes(self, line_node, vals):
            // line_node['cbc:ID'] = {'_text': vals['line_idx']}
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_item_nodes(self, line_node, vals):
            // product = vals['base_line']['product_id']
            // 
            // line_node['cac:Item'] = {
            //     'cbc:Description': {'_text': product.description_sale},
            //     'cbc:Name': {'_text': product.name},
            //     'cac:StandardItemIdentification': {
            //         'cbc:ID': {
            //             '_text': product.barcode,
            //             'schemeID': '0160',  # GTIN
            //         },
            //     },
            //     'cac:AdditionalItemProperty': [
            //         {
            //             'cbc:Name': {'_text': value.attribute_id.name},
            //             'cbc:Value': {'_text': value.name},
            //         } for value in product.product_template_attribute_value_ids
            //     ],
            // }
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_nodes(self, document_node, vals):
            // line_idx = 1
            // 
            // line_tag = self._get_tags_for_document_type(vals)['document_line']
            // document_node[line_tag] = line_nodes = []
            // for base_line in vals['base_lines']:
            //     if not self._is_document_allowance_charge(base_line):
            //         line_vals = {
            //             **vals,
            //             'line_idx': line_idx,
            //             'base_line': base_line,
            //         }
            //         line_node = self._get_document_line_node(line_vals)
            //         line_nodes.append(line_node)
            //         line_idx += 1
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineNoteNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_note_nodes(self, line_node, vals):
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLinePeriodNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_period_nodes(self, line_node, vals):
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_price_nodes(self, line_node, vals):
            // currency_suffix = vals['currency_suffix']
            // product_price_dp = self.env['decimal.precision'].precision_get('Product Price')
            // 
            // line_node['cac:Price'] = {
            //     'cbc:PriceAmount': {
            //         '_text': float_round(
            //             vals[f'gross_price_unit{currency_suffix}'],
            //             precision_digits=product_price_dp,
            //         ),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLinePricingReferenceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_pricing_reference_nodes(self, line_node, vals):
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_tax_category_nodes(self, line_node, vals):
            // base_line = vals['base_line']
            // aggregated_tax_details = self.env['account.tax']._aggregate_base_line_tax_details(base_line, vals['tax_grouping_function'])
            // line_node.setdefault('cac:Item', {})['cac:ClassifiedTaxCategory'] = [
            //     self._get_tax_category_node({**vals, 'grouping_key': grouping_key})
            //     for grouping_key in aggregated_tax_details
            //     if grouping_key
            // ]
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_tax_total_nodes(self, line_node, vals):
            // base_line = vals['base_line']
            // aggregated_tax_details = self.env['account.tax']._aggregate_base_line_tax_details(base_line, vals['tax_grouping_function'])
            // line_node['cac:TaxTotal'] = self._get_tax_total_node({**vals, 'aggregated_tax_details': aggregated_tax_details, 'role': 'line'})
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_total_vals(self, vals):
            // base_line = vals['base_line']
            // 
            // def fixed_total_grouping_function(base_line, tax_data):
            //     if vals['fixed_taxes_as_allowance_charges'] and tax_data and tax_data['tax'].amount_type == 'fixed':
            //         return vals['total_grouping_function'](base_line, tax_data)
            // 
            // aggregated_tax_details = self.env['account.tax']._aggregate_base_line_tax_details(base_line, fixed_total_grouping_function)
            // 
            // for currency_suffix in ['', '_currency']:
            //     vals[f'total_fixed_taxes{currency_suffix}'] = sum(
            //         tax_details[f'tax_amount{currency_suffix}']
            //         for grouping_key, tax_details in aggregated_tax_details.items()
            //         if grouping_key
            //     )
            // 
            //     vals[f'total_excluded{currency_suffix}'] = \
            //         base_line['tax_details'][f'total_excluded{currency_suffix}'] \
            //         + base_line['tax_details'][f'delta_total_excluded{currency_suffix}'] \
            //         + vals[f'total_fixed_taxes{currency_suffix}']
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_line_vals(self, vals):
            // """ Generic helper to calculate the amounts for a document line. """
            // self._add_document_line_total_vals(vals)
            // self._add_document_line_gross_subtotal_and_discount_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddDocumentMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_monetary_total_nodes(self, document_node, vals):
            // """ Generic helper to fill the MonetaryTotal node for a document given a list of base_lines. """
            // monetary_total_tag = self._get_tags_for_document_type(vals)['monetary_total']
            // currency_suffix = vals['currency_suffix']
            // 
            // document_node[monetary_total_tag] = {
            //     'cbc:LineExtensionAmount': {
            //         '_text': self.format_float(vals[f'total_lines{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:TaxExclusiveAmount': {
            //         '_text': self.format_float(vals[f'tax_exclusive_amount{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:TaxInclusiveAmount': {
            //         '_text': self.format_float(vals[f'tax_inclusive_amount{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:AllowanceTotalAmount': {
            //         '_text': self.format_float(vals[f'total_allowance{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if vals[f'total_allowance{currency_suffix}'] else None,
            //     'cbc:ChargeTotalAmount': {
            //         '_text': self.format_float(vals[f'total_charge{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if vals[f'total_charge{currency_suffix}'] else None,
            //     'cbc:PrepaidAmount': {
            //         '_text': self.format_float(0.0, vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:PayableRoundingAmount': {
            //         '_text': self.format_float(vals[f'cash_rounding_base_amount{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if vals[f'cash_rounding_base_amount{currency_suffix}'] else None,
            //     'cbc:PayableAmount': {
            //         '_text': self.format_float(vals[f'tax_inclusive_amount{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> AddDocumentMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_monetary_total_vals(self, vals):
            // # Compute the monetary totals for the document
            // def fixed_total_grouping_function(base_line, tax_data):
            //     if vals['fixed_taxes_as_allowance_charges'] and tax_data and tax_data['tax'].amount_type == 'fixed':
            //         return vals['total_grouping_function'](base_line, tax_data)
            // 
            // for currency_suffix in ['', '_currency']:
            //     for key in ['total_allowance', 'total_charge', 'total_lines']:
            //         vals[f'{key}{currency_suffix}'] = 0.0
            // 
            // for base_line in vals['base_lines']:
            //     aggregated_tax_details = self.env['account.tax']._aggregate_base_line_tax_details(base_line, fixed_total_grouping_function)
            // 
            //     for currency_suffix in ['', '_currency']:
            //         base_line_total_excluded = \
            //             base_line['tax_details'][f'total_excluded{currency_suffix}'] \
            //             + base_line['tax_details'][f'delta_total_excluded{currency_suffix}'] \
            //             + sum(
            //                 tax_details[f'tax_amount{currency_suffix}']
            //                 for grouping_key, tax_details in aggregated_tax_details.items()
            //                 if grouping_key
            //             )
            // 
            //         if self._is_document_allowance_charge(base_line):
            //             if base_line_total_excluded < 0.0:
            //                 vals[f'total_allowance{currency_suffix}'] += -base_line_total_excluded
            //             else:
            //                 vals[f'total_charge{currency_suffix}'] += base_line_total_excluded
            //         else:
            //             vals[f'total_lines{currency_suffix}'] += base_line_total_excluded
            // 
            // for currency_suffix in ['', '_currency']:
            //     vals[f'tax_exclusive_amount{currency_suffix}'] = vals[f'total_lines{currency_suffix}'] \
            //         + vals[f'total_charge{currency_suffix}'] \
            //         - vals[f'total_allowance{currency_suffix}']
            // 
            // def non_fixed_total_grouping_function(base_line, tax_data):
            //     if vals['fixed_taxes_as_allowance_charges'] and tax_data and tax_data['tax'].amount_type == 'fixed':
            //         return None
            //     return vals['total_grouping_function'](base_line, tax_data)
            // 
            // base_lines_aggregated_tax_details = self.env['account.tax']._aggregate_base_lines_tax_details(vals['base_lines'], non_fixed_total_grouping_function)
            // aggregated_tax_details = self.env['account.tax']._aggregate_base_lines_aggregated_values(base_lines_aggregated_tax_details)
            // for currency_suffix in ['', '_currency']:
            //     vals[f'tax_inclusive_amount{currency_suffix}'] = vals[f'tax_exclusive_amount{currency_suffix}'] \
            //         + sum(
            //             tax_details[f'tax_amount{currency_suffix}']
            //             for grouping_key, tax_details in aggregated_tax_details.items()
            //             if grouping_key
            //         )
            // 
            // # Cash rounding for 'add_invoice_line' cash rounding strategy
            // # (For the 'biggest_tax' strategy the amounts are directly included in the tax amounts.)
            // for currency_suffix in ['', '_currency']:
            //     vals[f'cash_rounding_base_amount{currency_suffix}'] = 0.0
            //     for base_line in vals.setdefault('cash_rounding_base_lines', []):
            //         tax_details = base_line['tax_details']
            //         vals[f'cash_rounding_base_amount{currency_suffix}'] += tax_details[f'total_excluded{currency_suffix}']
            */
            return default;
        }

        public async Task<TEntity> AddDocumentTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_tax_grouping_function_vals(self, vals):
            // # Add the grouping functions for the monetary totals and tax totals
            // customer = vals['customer']
            // supplier = vals['supplier']
            // 
            // # This function will be used when computing the monetary totals on the document level.
            // # It should return True for all taxes which should be included in the total.
            // def total_grouping_function(base_line, tax_data):
            //     return True
            // 
            // # This function will be used when computing the tax totals on the document and line level.
            // # It should group taxes together according to the tax catagory with which they will be reported.
            // # Any taxes that should be included in the tax totals should be included.
            // def tax_grouping_function(base_line, tax_data):
            //     tax = tax_data and tax_data['tax']
            //     # Exclude fixed taxes if 'fixed_taxes_as_allowance_charges' is True
            //     if vals['fixed_taxes_as_allowance_charges'] and tax and tax.amount_type == 'fixed':
            //         return None
            //     return {
            //         'tax_category_code': self._get_tax_category_code(customer.commercial_partner_id, supplier, tax),
            //         **self._get_tax_exemption_reason(customer.commercial_partner_id, supplier, tax),
            //         'amount': tax.amount if tax else 0.0,
            //         'amount_type': tax.amount_type if tax else 'percent',
            //     }
            // 
            // vals['total_grouping_function'] = total_grouping_function
            // vals['tax_grouping_function'] = tax_grouping_function
            */
            return default;
        }

        public async Task<TEntity> AddDocumentTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_document_tax_total_nodes(self, document_node, vals):
            // """ Generic helper to fill the TaxTotal and WithholdingTaxTotal nodes for a document. """
            // base_lines_aggregated_tax_details = self.env['account.tax']._aggregate_base_lines_tax_details(vals['base_lines'], vals['tax_grouping_function'])
            // aggregated_tax_details = self.env['account.tax']._aggregate_base_lines_aggregated_values(base_lines_aggregated_tax_details)
            // document_node['cac:TaxTotal'] = self._get_tax_total_node({**vals, 'aggregated_tax_details': aggregated_tax_details, 'role': 'document'})
            // document_node['cac:WithholdingTaxTotal'] = None
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceAccountingCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_accounting_customer_party_nodes(self, document_node, vals):
            // document_node['cac:AccountingCustomerParty'] = {
            //     'cac:Party': self._get_party_node({**vals, 'partner': vals['customer'], 'role': 'customer'}),
            // }
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceAccountingSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_accounting_supplier_party_nodes(self, document_node, vals):
            // document_node['cac:AccountingSupplierParty'] = {
            //     'cac:Party': self._get_party_node({**vals, 'partner': vals['supplier'], 'role': 'supplier'}),
            // }
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_allowance_charge_nodes(self, document_node, vals):
            // self._add_document_allowance_charge_nodes(document_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_base_lines_vals(self, vals):
            // invoice = vals['invoice']
            // base_lines, _tax_lines = invoice._get_rounded_base_and_tax_lines()
            // vals['base_lines'] = [base_line for base_line in base_lines if base_line['special_type'] != 'cash_rounding']
            // vals['cash_rounding_base_lines'] = [base_line for base_line in base_lines if base_line['special_type'] == 'cash_rounding']
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_config_vals(self, vals):
            // invoice = vals['invoice']
            // supplier = invoice.company_id.partner_id.commercial_partner_id
            // customer = invoice.partner_id
            // 
            // vals.update({
            //     'document_type': 'debit_note' if 'debit_origin_id' in self.env['account.move']._fields and invoice.debit_origin_id
            //         else 'credit_note' if invoice.move_type == 'out_refund'
            //         else 'invoice',
            // 
            //     'supplier': supplier,
            //     'customer': customer,
            //     'partner_shipping': invoice.partner_shipping_id or invoice.partner_id,
            // 
            //     'currency_id': invoice.currency_id,
            //     'company_currency_id': invoice.company_id.currency_id,
            // 
            //     'use_company_currency': False,  # If true, use the company currency for the amounts instead of the invoice currency
            //     'fixed_taxes_as_allowance_charges': True,  # If true, include fixed taxes as AllowanceCharges on lines instead of as taxes
            // })
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_currency_vals(self, vals):
            // self._add_document_currency_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_delivery_nodes(self, document_node, vals):
            // invoice = vals['invoice']
            // document_node['cac:Delivery'] = {
            //     'cbc:ActualDeliveryDate': {'_text': invoice.delivery_date},
            //     'cac:DeliveryLocation': {
            //         'cac:Address': self._get_address_node({'partner': vals['partner_shipping']})
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceExchangeRateNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_exchange_rate_nodes(self, document_node, vals):
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_header_nodes(self, document_node, vals):
            // invoice = vals['invoice']
            // document_node.update({
            //     'cbc:UBLVersionID': {'_text': '2.0'},
            //     'cbc:ID': {'_text': invoice.name},
            //     'cbc:IssueDate': {'_text': invoice.invoice_date},
            //     'cbc:InvoiceTypeCode': {'_text': 380} if vals['document_type'] == 'invoice' else None,
            //     'cbc:Note': {'_text': html2plaintext(invoice.narration)} if invoice.narration else None,
            //     'cbc:DocumentCurrencyCode': {'_text': invoice.currency_id.name},
            //     'cac:OrderReference': {
            //         # OrderReference/ID (order_reference) is mandatory inside the OrderReference node
            //         'cbc:ID': {'_text': invoice.ref or invoice.name},
            //         # OrderReference/SalesOrderID (sales_order_id) is optional
            //         'cbc:SalesOrderID': {
            //             '_text': ",".join(invoice.invoice_line_ids.sale_line_ids.order_id.mapped('name'))
            //         } if 'sale_line_ids' in invoice.invoice_line_ids._fields else None,
            //     }
            // })
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_allowance_charge_nodes(self, line_node, vals):
            // self._add_document_line_allowance_charge_nodes(line_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_amount_nodes(self, line_node, vals):
            // self._add_document_line_amount_nodes(line_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_id_nodes(self, line_node, vals):
            // self._add_document_line_id_nodes(line_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_item_nodes(self, line_node, vals):
            // self._add_document_line_item_nodes(line_node, vals)
            // 
            // line = vals['base_line']['record']
            // if line_name := line.name and line.name.replace('\n', ' '):
            //     line_node['cac:Item']['cbc:Description']['_text'] = line_name
            //     if not line_node['cac:Item']['cbc:Name']['_text']:
            //         line_node['cac:Item']['cbc:Name']['_text'] = line_name
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_nodes(self, document_node, vals):
            // line_idx = 1
            // 
            // line_tag = self._get_tags_for_document_type(vals)['document_line']
            // document_node[line_tag] = line_nodes = []
            // for base_line in vals['base_lines']:
            //     # Only use product lines to generate the UBL InvoiceLines.
            //     # Other lines should be represented as AllowanceCharges.
            //     if not self._is_document_allowance_charge(base_line):
            //         line_vals = {
            //             **vals,
            //             'line_idx': line_idx,
            //             'base_line': base_line,
            //         }
            //         line_node = self._get_invoice_line_node(line_vals)
            //         line_nodes.append(line_node)
            //         line_idx += 1
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineNoteNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_note_nodes(self, line_node, vals):
            // self._add_document_line_note_nodes(line_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePeriodNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_period_nodes(self, line_node, vals):
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_price_nodes(self, line_node, vals):
            // self._add_document_line_price_nodes(line_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePricingReferenceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_pricing_reference_nodes(self, line_node, vals):
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_tax_category_nodes(self, line_node, vals):
            // self._add_document_line_tax_category_nodes(line_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_tax_total_nodes(self, line_node, vals):
            // self._add_document_line_tax_total_nodes(line_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_line_vals(self, vals):
            // self._add_document_line_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_monetary_total_nodes(self, document_node, vals):
            // self._add_document_monetary_total_nodes(document_node, vals)
            // monetary_total_tag = self._get_tags_for_document_type(vals)['monetary_total']
            // invoice = vals['invoice']
            // document_node[monetary_total_tag].update({
            //     'cbc:PrepaidAmount': {
            //         '_text': self.format_float(invoice.amount_total - invoice.amount_residual, vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            //     'cbc:PayableRoundingAmount': {
            //         '_text': self.format_float(vals['cash_rounding_base_amount_currency'], vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     } if vals['cash_rounding_base_amount_currency'] else None,
            //     'cbc:PayableAmount': {
            //         '_text': self.format_float(invoice.amount_residual, vals['currency_dp']),
            //         'currencyID': vals['currency_name'],
            //     },
            // })
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_monetary_totals_vals(self, vals):
            // self._add_document_monetary_total_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoicePaymentMeansNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_payment_means_nodes(self, document_node, vals):
            // invoice = vals['invoice']
            // if invoice.move_type == 'out_invoice':
            //     if invoice.partner_bank_id:
            //         payment_means_code, payment_means_name = 30, 'credit transfer'
            //     else:
            //         payment_means_code, payment_means_name = 'ZZZ', 'mutually defined'
            // else:
            //     payment_means_code, payment_means_name = 57, 'standing agreement'
            // 
            // # in Denmark payment code 30 is not allowed. we hardcode it to 1 ("unknown") for now
            // # as we cannot deduce this information from the invoice
            // if invoice.partner_id.country_code == 'DK':
            //     payment_means_code, payment_means_name = 1, 'unknown'
            // 
            // document_node['cac:PaymentMeans'] = {
            //     'cbc:PaymentMeansCode': {
            //         '_text': payment_means_code,
            //         'name': payment_means_name,
            //     },
            //     'cbc:PaymentDueDate': {'_text': invoice.invoice_date_due or invoice.invoice_date},
            //     'cbc:InstructionID': {'_text': invoice.payment_reference},
            //     'cbc:PaymentID': {'_text': invoice.payment_reference or invoice.name},
            //     'cac:PayeeFinancialAccount': self._get_financial_account_node({
            //         **vals, 'partner_bank': invoice.partner_bank_id
            //     }) if invoice.partner_bank_id else None
            // }
            */
            return default;
        }

        public async Task<TEntity> AddInvoicePaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_payment_terms_nodes(self, document_node, vals):
            // invoice = vals['invoice']
            // payment_term = invoice.invoice_payment_term_id
            // if payment_term:
            //     document_node['cac:PaymentTerms'] = {
            //         # The payment term's note is automatically embedded in a <p> tag in Odoo
            //         'cbc:Note': {'_text': html2plaintext(payment_term.note)}
            //     }
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_seller_supplier_party_nodes(self, document_node, vals):
            // pass
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_tax_grouping_function_vals(self, vals):
            // self._add_document_tax_grouping_function_vals(vals)
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_invoice_tax_total_nodes(self, document_node, vals):
            // self._add_document_tax_total_nodes(document_node, vals)
            */
            return default;
        }

        public async Task<TEntity> AddTaxTotalNodeInCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _add_tax_total_node_in_company_currency(self, document_node, vals):
            // """ Generic helper to add a TaxTotal section in the company currency. """
            // company_currency = vals['invoice'].company_id.currency_id
            // base_lines_aggregated_tax_details = self.env['account.tax']._aggregate_base_lines_tax_details(vals['base_lines'], vals['tax_grouping_function'])
            // aggregated_tax_details = self.env['account.tax']._aggregate_base_lines_aggregated_values(base_lines_aggregated_tax_details)
            // tax_total_node_in_company_currency = self._get_tax_total_node({
            //     **vals,
            //     'aggregated_tax_details': aggregated_tax_details,
            //     'currency_suffix': '',
            //     'currency_dp': self._get_currency_decimal_places(company_currency),
            //     'currency_name': company_currency.name,
            //     'role': 'document'
            // })
            // document_node['cac:TaxTotal'].append(tax_total_node_in_company_currency)
            */
            return default;
        }

        public async Task<TEntity> ApplyInvoiceLineFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_line) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _apply_invoice_line_filter(self, invoice_line):
            // """
            //     To be overridden to apply a specific invoice line filter
            // """
            // return True
            */
            return default;
        }

        public async Task<TEntity> ApplyInvoiceTaxFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _apply_invoice_tax_filter(self, base_line, tax_values):
            // """
            //     To be overridden to apply a specific tax filter
            // """
            // return True
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
            //     return custom_warning_message or _("The element %(record)s is required on %(field_list)s.", record=record, field_list=format_list(self.env, field_names))
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
            //         field_list=format_list(self.env, field_names),
            //     )
            // 
            // display_field_names = record.fields_get(field_names)
            // if len(field_names) == 1:
            //     display_field = f"'{display_field_names[field_names[0]]['string']}'"
            //     return _("The field %(field)s is required on %(record)s.", field=display_field, record=record.display_name)
            // else:
            //     display_fields = format_list(self.env, [f"'{display_field_names[x]['string']}'" for x in display_field_names])
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _correct_invoice_tax_amount(self, tree, invoice):
            // """ The tax total may have been modified for rounding purpose, if so we should use the imported tax and not
            //  the computed one """
            // currency = invoice.currency_id
            // # For each tax in our tax total, get the amount as well as the total in the xml.
            // # Negative tax amounts may appear in invoices; they have to be inverted (since they are credit notes).
            // document_amount_sign = self._get_import_document_amount_sign(tree)[1] or 1
            // # We only search for `TaxTotal/TaxSubtotal` in the "root" element (i.e. not in `InvoiceLine` elements).
            // for elem in tree.findall('./{*}TaxTotal/{*}TaxSubtotal'):
            //     percentage = elem.find('.//{*}TaxCategory/{*}Percent')
            //     if percentage is None:
            //         percentage = elem.find('.//{*}Percent')
            //     amount = elem.find('.//{*}TaxAmount')
            //     if (percentage is not None and percentage.text is not None) and (amount is not None and amount.text is not None):
            //         tax_percent = float(percentage.text)
            //         # Compare the result with our tax total on the invoice, and apply correction if needed.
            //         # First look for taxes matching the percentage in the xml.
            //         taxes = invoice.line_ids.tax_line_id.filtered(lambda tax: tax.amount == tax_percent)
            //         # If we found taxes with the correct amount, look for a tax line using it, and correct it as needed.
            //         if taxes:
            //             tax_total = document_amount_sign * float(amount.text)
            //             # Sometimes we have multiple lines for the same tax.
            //             tax_lines = invoice.line_ids.filtered(lambda line: line.tax_line_id in taxes)
            //             if tax_lines:
            //                 sign = -1 if invoice.is_inbound(include_receipts=True) else 1
            //                 tax_lines_total = currency.round(sign * sum(tax_lines.mapped('amount_currency')))
            //                 difference = currency.round(tax_total - tax_lines_total)
            //                 if not currency.is_zero(difference):
            //                     tax_lines[0].amount_currency += sign * difference
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
            //         vals['record']['company_id']['partner_id']['commercial_partner_id'], ['phone', 'mobile'],
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // constraints = self._invoice_constraints_common(invoice)
            // constraints.update({
            //     'ubl20_supplier_name_required': self._check_required_fields(vals['supplier'], 'name'),
            //     'ubl20_customer_name_required': self._check_required_fields(vals['customer'].commercial_partner_id, 'name'),
            //     'ubl20_invoice_name_required': self._check_required_fields(invoice, 'name'),
            //     'ubl20_invoice_date_required': self._check_required_fields(invoice, 'invoice_date'),
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'org.oasis-open:invoice:2.0',
            //     'credit_note': 'org.oasis-open:creditnote:2.0',
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_ubl_20.xml"
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object convert_fixed_taxes) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _export_invoice(self, invoice):
            // vals = self._export_invoice_vals(invoice.with_context(lang=invoice.partner_id.lang))
            // errors = [constraint for constraint in self._export_invoice_constraints(invoice, vals).values() if constraint]
            // xml_content = self.env['ir.qweb']._render('account_edi_ubl_cii.account_invoice_facturx_export_22', vals)
            // return etree.tostring(cleanup_xml_node(xml_content), xml_declaration=True, encoding='UTF-8'), set(errors)
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _export_invoice(self, invoice, convert_fixed_taxes=True):
            // """ Generates an UBL 2.0 xml for a given invoice.
            // :param convert_fixed_taxes: whether the fixed taxes are converted into AllowanceCharges on the InvoiceLines
            // """
            // vals = self \
            //     .with_context(convert_fixed_taxes=convert_fixed_taxes) \
            //     ._export_invoice_vals(invoice.with_context(lang=invoice.partner_id.lang))
            // errors = [constraint for constraint in self._export_invoice_constraints(invoice, vals).values() if constraint]
            // xml_content = self.env['ir.qweb']._render(vals['main_template'], vals)
            // return etree.tostring(cleanup_xml_node(xml_content), xml_declaration=True, encoding='UTF-8'), set(errors)
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceNewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _export_invoice_new(self, invoice):
            // """ Generates an UBL 2.0 xml for a given invoice, using the new dict_to_xml helpers. """
            // # 1. Validate the structure of the taxes
            // self._validate_taxes(invoice.invoice_line_ids.tax_ids)
            // 
            // # 2. Instantiate the XML builder
            // vals = {'invoice': invoice.with_context(lang=invoice.partner_id.lang)}
            // document_node = self._get_invoice_node(vals)
            // 
            // # 3. Run constraints
            // vals['document_node'] = document_node
            // errors = [constraint for constraint in self._export_invoice_constraints_new(invoice, vals).values() if constraint]
            // 
            // template = self._get_document_template(vals)
            // nsmap = self._get_document_nsmap(vals)
            // 
            // # 4. Render the XML
            // xml_content = dict_to_xml(document_node, nsmap=nsmap, template=template)
            // 
            // # 5. Format the XML
            // return etree.tostring(xml_content, xml_declaration=True, encoding='UTF-8'), set(errors)
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _export_invoice_vals(self, invoice):
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
            //     customer = invoice.commercial_partner_id
            //     supplier = invoice.company_id.partner_id.commercial_partner_id
            //     grouping_key = {
            //         **self._get_tax_unece_codes(customer, supplier, tax),
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
            // if 'siret' in invoice.company_id._fields and invoice.company_id.siret:
            //     seller_siret = invoice.company_id.siret
            // else:
            //     seller_siret = invoice.company_id.company_registry
            // 
            // buyer_siret = invoice.commercial_partner_id.company_registry
            // if 'siret' in invoice.commercial_partner_id._fields and invoice.commercial_partner_id.siret:
            //     buyer_siret = invoice.commercial_partner_id.siret
            // template_values = {
            //     **invoice._prepare_edi_vals_to_export(),
            //     'tax_details': tax_details,
            //     'format_date': format_date,
            //     'format_monetary': format_monetary,
            //     'is_html_empty': is_html_empty,
            //     'scheduled_delivery_time': self._get_scheduled_delivery_time(invoice),
            //     'intracom_delivery': False,
            //     'ExchangedDocument_vals': self._get_exchanged_document_vals(invoice),
            //     'seller_specified_legal_organization': seller_siret,
            //     'buyer_specified_legal_organization': buyer_siret,
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
            // if self.env['account.payment']._fields.get('sdd_mandate_id') and invoice.matched_payment_ids.sdd_mandate_id:
            //     template_values['payment_means_code'] = PAYMENT_MEAN_CODES['SEPA direct debit']
            // else:
            //     template_values['payment_means_code'] = PAYMENT_MEAN_CODES['Payment to bank account']
            // 
            // return template_values
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _export_invoice_vals(self, invoice):
            // # Validate the structure of the taxes
            // self._validate_taxes(invoice.invoice_line_ids.tax_ids)
            // 
            // # Compute the tax details for the whole invoice and each invoice line separately.
            // taxes_vals = invoice._prepare_invoice_aggregated_taxes(
            //     grouping_key_generator=self._get_tax_grouping_key,
            //     filter_tax_values_to_apply=self._apply_invoice_tax_filter,
            //     filter_invl_to_apply=self._apply_invoice_line_filter,
            //     round_from_tax_lines=True,
            // )
            // 
            // # Fixed Taxes: filter them on the document level, and adapt the totals
            // # Fixed taxes are not supposed to be taxes in real live. However, this is the way in Odoo to manage recupel
            // # taxes in Belgium. Since only one tax is allowed, the fixed tax is removed from totals of lines but added
            // # as an extra charge/allowance.
            // if self._context.get('convert_fixed_taxes'):
            //     fixed_taxes_keys = [k for k in taxes_vals['tax_details'] if k['tax_amount_type'] == 'fixed']
            //     for key in fixed_taxes_keys:
            //         fixed_tax_details = taxes_vals['tax_details'].pop(key)
            //         taxes_vals['tax_amount_currency'] -= fixed_tax_details['tax_amount_currency']
            //         taxes_vals['tax_amount'] -= fixed_tax_details['tax_amount']
            //         taxes_vals['base_amount_currency'] += fixed_tax_details['tax_amount_currency']
            //         taxes_vals['base_amount'] += fixed_tax_details['tax_amount']
            // 
            // # Compute values for invoice lines.
            // line_extension_amount = 0.0
            // 
            // invoice_lines = invoice.invoice_line_ids.filtered(lambda line: line.display_type not in ('line_note', 'line_section') and line._check_edi_line_tax_required())
            // document_allowance_charge_vals_list = self._get_document_allowance_charge_vals_list(invoice, taxes_vals)
            // invoice_line_vals_list = []
            // for line_id, line in enumerate(invoice_lines):
            //     line_taxes_vals = taxes_vals['tax_details_per_record'][line]
            //     line_vals = self._get_invoice_line_vals(line, line_id, {**line_taxes_vals, 'invoice_line': line})
            //     invoice_line_vals_list.append(line_vals)
            // 
            //     line_extension_amount += line_vals['line_extension_amount']
            // 
            // # Compute the total allowance/charge amounts.
            // allowance_total_amount = 0.0
            // charge_total_amount = 0.0
            // for allowance_charge_vals in document_allowance_charge_vals_list:
            //     if allowance_charge_vals['charge_indicator'] == 'false':
            //         allowance_total_amount += allowance_charge_vals['amount']
            //     else:
            //         charge_total_amount += allowance_charge_vals['amount']
            // 
            // supplier = invoice.company_id.partner_id.commercial_partner_id
            // customer = invoice.partner_id
            // 
            // # OrderReference/SalesOrderID (sales_order_id) is optional
            // sales_order_id = 'sale_line_ids' in invoice.invoice_line_ids._fields \
            //                  and ",".join(invoice.invoice_line_ids.sale_line_ids.order_id.mapped('name'))
            // # OrderReference/ID (order_reference) is mandatory inside the OrderReference node !
            // order_reference = invoice.ref or invoice.name
            // 
            // vals = {
            //     'builder': self,
            //     'invoice': invoice,
            //     'supplier': supplier,
            //     'customer': customer,
            // 
            //     'taxes_vals': taxes_vals,
            // 
            //     'format_float': self.format_float,
            //     'AddressType_template': 'account_edi_ubl_cii.ubl_20_AddressType',
            //     'ContactType_template': 'account_edi_ubl_cii.ubl_20_ContactType',
            //     'PartyType_template': 'account_edi_ubl_cii.ubl_20_PartyType',
            //     'PaymentMeansType_template': 'account_edi_ubl_cii.ubl_20_PaymentMeansType',
            //     'PaymentTermsType_template': 'account_edi_ubl_cii.ubl_20_PaymentTermsType',
            //     'TaxCategoryType_template': 'account_edi_ubl_cii.ubl_20_TaxCategoryType',
            //     'TaxTotalType_template': 'account_edi_ubl_cii.ubl_20_TaxTotalType',
            //     'AllowanceChargeType_template': 'account_edi_ubl_cii.ubl_20_AllowanceChargeType',
            //     'SignatureType_template': 'account_edi_ubl_cii.ubl_20_SignatureType',
            //     'ResponseType_template': 'account_edi_ubl_cii.ubl_20_ResponseType',
            //     'DeliveryType_template': 'account_edi_ubl_cii.ubl_20_DeliveryType',
            //     'InvoicePeriodType_template': 'account_edi_ubl_cii.ubl_20_InvoicePeriodType',
            //     'MonetaryTotalType_template': 'account_edi_ubl_cii.ubl_20_MonetaryTotalType',
            //     'InvoiceLineType_template': 'account_edi_ubl_cii.ubl_20_InvoiceLineType',
            //     'CreditNoteLineType_template': 'account_edi_ubl_cii.ubl_20_CreditNoteLineType',
            //     'DebitNoteLineType_template': 'account_edi_ubl_cii.ubl_20_DebitNoteLineType',
            //     'InvoiceType_template': 'account_edi_ubl_cii.ubl_20_InvoiceType',
            //     'CreditNoteType_template': 'account_edi_ubl_cii.ubl_20_CreditNoteType',
            //     'DebitNoteType_template': 'account_edi_ubl_cii.ubl_20_DebitNoteType',
            //     'ExchangeRateType_template': 'account_edi_ubl_cii.ubl_20_ExchangeRateType',
            // 
            //     'vals': {
            //         'ubl_version_id': 2.0,
            //         'id': invoice.name,
            //         'issue_date': invoice.invoice_date,
            //         'due_date': invoice.invoice_date_due,
            //         'note_vals': self._get_note_vals_list(invoice),
            //         'document_currency_code': invoice.currency_id.name,
            //         'order_reference': order_reference,
            //         'sales_order_id': sales_order_id,
            //         'accounting_supplier_party_vals': {
            //             'party_vals': self._get_partner_party_vals(supplier, role='supplier'),
            //         },
            //         'accounting_customer_party_vals': {
            //             'party_vals': self._get_partner_party_vals(customer, role='customer'),
            //         },
            //         'invoice_period_vals_list': self._get_invoice_period_vals_list(invoice),
            //         'additional_document_reference_list': self._get_additional_document_reference_list(invoice),
            //         'delivery_vals_list': self._get_delivery_vals_list(invoice),
            //         'payment_means_vals_list': self._get_invoice_payment_means_vals_list(invoice),
            //         'payment_terms_vals': self._get_invoice_payment_terms_vals_list(invoice),
            //         # allowances at the document level, the allowances on invoices (eg. discount) are on line_vals
            //         'allowance_charge_vals': document_allowance_charge_vals_list,
            //         'tax_total_vals': self._get_invoice_tax_totals_vals_list(invoice, taxes_vals),
            //         'monetary_total_vals': self._get_invoice_monetary_total_vals(
            //             invoice,
            //             taxes_vals,
            //             line_extension_amount,
            //             allowance_total_amount,
            //             charge_total_amount,
            //         ),
            //         'line_vals': invoice_line_vals_list,
            //         'currency_dp': self._get_currency_decimal_places(invoice.currency_id),  # currency decimal places
            //         'pricing_exchange_rate_vals_list': self._get_pricing_exchange_rate_vals_list(invoice),
            //     },
            // }
            // 
            // # Document type specific settings
            // if 'debit_origin_id' in self.env['account.move']._fields and invoice.debit_origin_id:
            //     vals['document_type'] = 'debit_note'
            //     vals['main_template'] = 'account_edi_ubl_cii.ubl_20_DebitNote'
            //     vals['vals']['document_type_code'] = 383
            // elif invoice.move_type == 'out_refund':
            //     vals['document_type'] = 'credit_note'
            //     vals['main_template'] = 'account_edi_ubl_cii.ubl_20_CreditNote'
            //     vals['vals']['document_type_code'] = 381
            // else: # invoice.move_type == 'out_invoice'
            //     vals['document_type'] = 'invoice'
            //     vals['main_template'] = 'account_edi_ubl_cii.ubl_20_Invoice'
            //     vals['vals']['document_type_code'] = 380
            // 
            // return vals
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _find_value(self, xpath, tree, nsmap=False):
            // # EXTENDS account.edi.common
            // return super()._find_value(xpath, tree, UBL_NAMESPACES)
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

        public async Task<TEntity> GetAdditionalDocumentReferenceListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_additional_document_reference_list(self, invoice):
            // """
            // This is optional and meant to be overridden when required under the form:
            // {
            //     'id': str,
            //     'issue_date': str,
            //     'document_type_code': str,
            //     'document_type': str,
            //     'document_description': str,
            // }.
            // Should return a list.
            // """
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_address_node(self, vals):
            // """ Generic helper to generate the Address node for a res.partner or res.bank. """
            // partner = vals['partner']
            // country_key = 'country' if partner._name == 'res.bank' else 'country_id'
            // state_key = 'state' if partner._name == 'res.bank' else 'state_id'
            // country = partner[country_key]
            // state = partner[state_key]
            // 
            // return {
            //     'cbc:StreetName': {'_text': partner.street},
            //     'cbc:AdditionalStreetName': {'_text': partner.street2},
            //     'cbc:CityName': {'_text': partner.city},
            //     'cbc:PostalZone': {'_text': partner.zip},
            //     'cbc:CountrySubentity': {'_text': state.name},
            //     'cbc:CountrySubentityCode': {'_text': state.code},
            //     'cac:Country': {
            //         'cbc:IdentificationCode': {'_text': country.code},
            //         'cbc:Name': {'_text': country.name},
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetBankAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bank) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_bank_address_vals(self, bank):
            // return {
            //     'street_name': bank.street,
            //     'additional_street_name': bank.street2,
            //     'city_name': bank.city,
            //     'postal_zone': bank.zip,
            //     'country_subentity': bank.state.name,
            //     'country_subentity_code': bank.state.code,
            //     'country_vals': self._get_country_vals(bank.country),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetCountryValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
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

        public async Task<TEntity> GetDeliveryValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_delivery_vals_list(self, invoice):
            // # the data is optional, except for ubl bis3 (see the override, where we need to set a default delivery address)
            // return [{
            //     'actual_delivery_date': invoice.delivery_date,
            //     'delivery_location_vals': {
            //         'delivery_address_vals': self._get_partner_address_vals(invoice.partner_shipping_id),
            //     },
            //     'delivery_party_vals': self._get_partner_party_vals(invoice.partner_shipping_id, 'delivery') if invoice.partner_shipping_id else {},
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_document_allowance_charge_node(self, vals):
            // """ Generic helper to generate a document-level AllowanceCharge node given a base_line. """
            // base_line = vals['base_line']
            // currency_suffix = vals['currency_suffix']
            // aggregated_tax_details = self.env['account.tax']._aggregate_base_line_tax_details(base_line, vals['tax_grouping_function'])
            // base_amount = base_line['tax_details'][f'total_excluded{currency_suffix}']
            // return {
            //     'cbc:ChargeIndicator': {'_text': 'false' if base_amount < 0.0 else 'true'},
            //     'cbc:AllowanceChargeReasonCode': {'_text': '66' if base_amount < 0.0 else 'ZZZ'},
            //     'cbc:AllowanceChargeReason': {'_text': _("Conditional cash/payment discount")},
            //     'cbc:Amount': {
            //         '_text': self.format_float(abs(base_amount), vals['currency_dp']),
            //         'currencyID': vals['currency_name']
            //     },
            //     'cac:TaxCategory': [
            //         self._get_tax_category_node({**vals, 'grouping_key': grouping_key})
            //         for grouping_key in aggregated_tax_details
            //         if grouping_key
            //     ]
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_document_allowance_charge_vals_list(self, invoice, taxes_vals=None):
            // """
            // https://docs.peppol.eu/poacc/billing/3.0/bis/#_document_level_allowance_or_charge
            // Usage for early payment discounts:
            // * Add one document level Allowance per tax rate (VAT included)
            // * Add one document level Charge (VAT excluded) with amount = the total sum of the early payment discount
            // The difference between these is the cash discount in case of early payment.
            // """
            // vals_list = []
            // # Early Payment Discount
            // epd_tax_to_discount = self._get_early_payment_discount_grouped_by_tax_rate(invoice)
            // if epd_tax_to_discount:
            //     # One Allowance per tax rate (VAT included)
            //     for tax_amount, discount_amount in epd_tax_to_discount.items():
            //         vals_list.append({
            //             'charge_indicator': 'false',
            //             'allowance_charge_reason_code': '66',
            //             'allowance_charge_reason': _("Conditional cash/payment discount"),
            //             'amount': discount_amount,
            //             'currency_dp': 2,
            //             'currency_name': invoice.currency_id.name,
            //             'tax_category_vals': [{
            //                 'id': 'S',
            //                 'percent': tax_amount,
            //                 'tax_scheme_vals': {'id': 'VAT'},
            //             }],
            //         })
            //     # One global Charge (VAT exempted)
            //     vals_list.append({
            //         'charge_indicator': 'true',
            //         'allowance_charge_reason_code': 'ZZZ',
            //         'allowance_charge_reason': _("Conditional cash/payment discount"),
            //         'amount': sum(epd_tax_to_discount.values()),
            //         'currency_dp': 2,
            //         'currency_name': invoice.currency_id.name,
            //         'tax_category_vals': [{
            //             'id': 'E',
            //             'percent': 0.0,
            //             'tax_scheme_vals': {'id': 'VAT'},
            //         }],
            //     })
            // return vals_list
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_document_allowance_charge_xpaths(self):
            // return {
            //     'root': './{*}AllowanceCharge',
            //     'charge_indicator': './{*}ChargeIndicator',
            //     'base_amount': './{*}BaseAmount',
            //     'amount': './{*}Amount',
            //     'reason': './{*}AllowanceChargeReason',
            //     'percentage': './{*}MultiplierFactorNumeric',
            //     'tax_percentage': './{*}TaxCategory/{*}Percent',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDocumentLineNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_document_line_node(self, vals):
            // self._add_document_line_vals(vals)
            // 
            // line_node = {}
            // self._add_document_line_id_nodes(line_node, vals)
            // self._add_document_line_note_nodes(line_node, vals)
            // self._add_document_line_amount_nodes(line_node, vals)
            // self._add_document_line_period_nodes(line_node, vals)
            // self._add_document_line_allowance_charge_nodes(line_node, vals)
            // self._add_document_line_tax_total_nodes(line_node, vals)
            // self._add_document_line_item_nodes(line_node, vals)
            // self._add_document_line_tax_category_nodes(line_node, vals)
            // self._add_document_line_price_nodes(line_node, vals)
            // self._add_document_line_pricing_reference_nodes(line_node, vals)
            // return line_node
            */
            return default;
        }

        public async Task<TEntity> GetDocumentNsmapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_document_nsmap(self, vals):
            // return {
            //     None: {
            //         'invoice': "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2",
            //         'credit_note': "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2",
            //         'debit_note': "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2",
            //         'order': "urn:oasis:names:specification:ubl:schema:xsd:Order-2",
            //     }[vals['document_type']],
            //     'cac': "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2",
            //     'cbc': "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2",
            //     'ext': "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2",
            // }
            */
            return default;
        }

        public async Task<TEntity> GetDocumentTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_document_template(self, vals):
            // return {
            //     'invoice': Invoice,
            //     'credit_note': CreditNote,
            //     'debit_note': DebitNote,
            // }[vals['document_type']]
            */
            return default;
        }

        public async Task<TEntity> GetDocumentTypeCodeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_document_type_code_vals(self, invoice, invoice_data):
            // """Returns the values used for the `DocumentTypeCode` node"""
            // # To be overriden by custom format if required
            // return {'attrs': {}, 'value': None}
            */
            return default;
        }

        public async Task<TEntity> GetEarlyPaymentDiscountGroupedByTaxRateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_early_payment_discount_grouped_by_tax_rate(self, invoice):
            // """
            // Get the early payment discounts grouped by the tax rate of the product it is linked to
            // :returns {float: float}: mapping tax amounts to early payment discount amounts
            // """
            // if invoice.invoice_payment_term_id.early_pay_discount_computation != 'mixed':
            //     return {}
            // tax_to_discount = defaultdict(lambda: 0)
            // for line in invoice.line_ids.filtered(lambda l: l.display_type == 'epd'):
            //     for tax in line.tax_ids:
            //         tax_to_discount[tax.amount] += line.amount_currency
            // return tax_to_discount
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

        public async Task<TEntity> GetFinancialAccountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_financial_account_node(self, vals):
            // """ Generic helper to generate the FinancialAccount node for a res.partner.bank """
            // partner_bank = vals['partner_bank']
            // bank = partner_bank.bank_id
            // financial_institution_branch = None
            // if bank:
            //     financial_institution_branch = {
            //         'cbc:ID': {
            //             '_text': bank.bic,
            //             'schemeID': 'BIC'
            //         },
            //         'cac:FinancialInstitution': {
            //             'cbc:ID': {
            //                 '_text': bank.bic,
            //                 'schemeID': 'BIC'
            //             },
            //             'cbc:Name': {'_text': bank.name},
            //             'cac:Address': self._get_address_node({**vals, 'partner': bank})
            //         }
            //     }
            // return {
            //     'cbc:ID': {'_text': partner_bank.acc_number.replace(' ', '')},
            //     'cac:FinancialInstitutionBranch': financial_institution_branch
            // }
            */
            return default;
        }

        public async Task<TEntity> GetFinancialAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_bank) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_financial_account_vals(self, partner_bank):
            // vals = {
            //     'bank_account': partner_bank,
            //     'id': partner_bank.acc_number.replace(' ', ''),
            // }
            // 
            // if partner_bank.bank_id:
            //     vals['financial_institution_branch_vals'] = self._get_financial_institution_branch_vals(partner_bank.bank_id)
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetFinancialInstitutionBranchValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bank) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_financial_institution_branch_vals(self, bank):
            // return {
            //     'bank': bank,
            //     'id': bank.bic,
            //     'id_attrs': {'schemeID': 'BIC'},
            //     'financial_institution_vals': self._get_financial_institution_vals(bank),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetFinancialInstitutionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bank) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_financial_institution_vals(self, bank):
            // return {
            //     'bank': bank,
            //     'id': bank.bic,
            //     'id_attrs': {'schemeID': 'BIC'},
            //     'name': bank.name,
            //     'address_vals': self._get_bank_address_vals(bank),
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_import_document_amount_sign(self, tree):
            // """
            // In UBL, an invoice has tag 'Invoice' and a credit note has tag 'CreditNote'. However, a credit note can be
            // expressed as an invoice with negative amounts. For this case, we need a factor to take the opposite
            // of each quantity in the invoice.
            // """
            // if tree.tag == '{urn:oasis:names:specification:ubl:schema:xsd:Invoice-2}Invoice':
            //     amount_node = tree.find('.//{*}LegalMonetaryTotal/{*}TaxExclusiveAmount')
            //     if amount_node is not None and float(amount_node.text) < 0:
            //         return 'refund', -1
            //     return 'invoice', 1
            // if tree.tag == '{urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2}CreditNote':
            //     return 'refund', 1
            // return None, None
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineAllowanceValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object tax_values_list) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_line_allowance_vals_list(self, line, tax_values_list=None):
            // """ Method used to fill the cac:{Invoice,CreditNote,DebitNote}Line>cac:AllowanceCharge node.
            // 
            // Allowances are distinguished from charges using the ChargeIndicator node with 'false' as value.
            // 
            // Note that allowance charges do not exist for credit notes in UBL 2.0, so if we apply discount in Odoo
            // the net price will not be consistent with the unit price, but we cannot do anything about it
            // 
            // :param line:    An invoice line.
            // :return:        A list of python dictionaries.
            // """
            // fixed_tax_charge_vals_list = []
            // if self._context.get('convert_fixed_taxes'):
            //     for grouping_key, tax_details in tax_values_list['tax_details'].items():
            //         if grouping_key['tax_amount_type'] == 'fixed':
            //             fixed_tax_charge_vals_list.append({
            //                 'currency_name': line.currency_id.name,
            //                 'currency_dp': self._get_currency_decimal_places(line.currency_id),
            //                 'charge_indicator': 'true',
            //                 'allowance_charge_reason_code': 'AEO',
            //                 'allowance_charge_reason': grouping_key['tax_name'],
            //                 'amount': tax_details['tax_amount_currency'],
            //             })
            // 
            //     if not line.discount:
            //         return fixed_tax_charge_vals_list
            // 
            // # Price subtotal with discount subtracted:
            // net_price_subtotal = line.price_subtotal
            // # Price subtotal without discount subtracted:
            // if line.discount == 100.0:
            //     gross_price_subtotal = 0.0
            // else:
            //     gross_price_subtotal = line.currency_id.round(net_price_subtotal / (1.0 - (line.discount or 0.0) / 100.0))
            // 
            // allowance_vals = {
            //     'currency_name': line.currency_id.name,
            //     'currency_dp': self._get_currency_decimal_places(line.currency_id),
            // 
            //     # Must be 'false' since this method is for allowances.
            //     'charge_indicator': 'false',
            // 
            //     # A reason should be provided. In Odoo, we only manage discounts.
            //     # Full code list is available here:
            //     # https://docs.peppol.eu/poacc/billing/3.0/codelist/UNCL5189/
            //     'allowance_charge_reason_code': 95,
            // 
            //     # The discount should be provided as an amount.
            //     'amount': gross_price_subtotal - net_price_subtotal,
            // }
            // 
            // return [allowance_vals] + fixed_tax_charge_vals_list
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineItemValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_line_item_vals(self, line, taxes_vals):
            // """ Method used to fill the cac:InvoiceLine/cac:Item node.
            // It provides information about what the product you are selling.
            // 
            // :param line:        An invoice line.
            // :param taxes_vals:  The tax details for the current invoice line.
            // :return:            A python dictionary.
            // """
            // product = line.product_id
            // taxes = line.tax_ids.flatten_taxes_hierarchy()
            // if self._context.get('convert_fixed_taxes'):
            //     taxes = taxes.filtered(lambda t: t.amount_type != 'fixed')
            // customer = line.move_id.commercial_partner_id
            // supplier = line.move_id.company_id.partner_id.commercial_partner_id
            // tax_category_vals_list = self._get_tax_category_list(customer, supplier, taxes)
            // description = line.name and line.name.replace('\n', ' ')
            // return {
            //     'description': description,
            //     'name': product.name or description,
            //     'sellers_item_identification_vals': {'id': product.code},
            //     'classified_tax_category_vals': tax_category_vals_list,
            //     'standard_item_identification_vals': {
            //         'id': product.barcode,
            //         'id_attrs': {'schemeID': '0160'},  # GTIN
            //     } if product.barcode else {},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_line_node(self, vals):
            // self._add_invoice_line_vals(vals)
            // 
            // line_node = {}
            // self._add_invoice_line_id_nodes(line_node, vals)
            // self._add_invoice_line_note_nodes(line_node, vals)
            // self._add_invoice_line_amount_nodes(line_node, vals)
            // self._add_invoice_line_period_nodes(line_node, vals)
            // self._add_invoice_line_allowance_charge_nodes(line_node, vals)
            // self._add_invoice_line_tax_total_nodes(line_node, vals)
            // self._add_invoice_line_item_nodes(line_node, vals)
            // self._add_invoice_line_tax_category_nodes(line_node, vals)
            // self._add_invoice_line_price_nodes(line_node, vals)
            // self._add_invoice_line_pricing_reference_nodes(line_node, vals)
            // return line_node
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLinePriceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_line_price_vals(self, line):
            // """ Method used to fill the cac:InvoiceLine/cac:Price node.
            // It provides information about the price applied for the goods and services invoiced.
            // 
            // :param line:    An invoice line.
            // :return:        A python dictionary.
            // """
            // # Price subtotal without discount:
            // net_price_subtotal = line.price_subtotal
            // # Price subtotal with discount:
            // if line.discount == 100.0:
            //     gross_price_subtotal = 0.0
            // else:
            //     gross_price_subtotal = net_price_subtotal / (1.0 - (line.discount or 0.0) / 100.0)
            // # Price subtotal with discount / quantity:
            // gross_price_unit = gross_price_subtotal / line.quantity if line.quantity else 0.0
            // 
            // uom = self._get_uom_unece_code(line.product_uom_id)
            // 
            // return {
            //     'currency': line.currency_id,
            //     'currency_dp': self._get_currency_decimal_places(line.currency_id),
            // 
            //     # The price of an item, exclusive of VAT, after subtracting item price discount.
            //     'price_amount': round(gross_price_unit, 10),
            //     'product_price_dp': self.env['decimal.precision'].precision_get('Product Price'),
            // 
            //     # The number of item units to which the price applies.
            //     # setting to None -> the xml will not comprise the BaseQuantity (it's not mandatory)
            //     'base_quantity': None,
            //     'base_quantity_attrs': {'unitCode': uom},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_line_tax_totals_vals_list(self, line, taxes_vals):
            // """ Method used to fill the cac:TaxTotal node on a line level.
            // Uses the same method as the invoice TaxTotal, but can be overridden in other formats.
            // """
            // return self._get_invoice_tax_totals_vals_list(line.move_id, taxes_vals)
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, Guid line_id, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_line_vals(self, line, line_id, taxes_vals):
            // """ Method used to fill the cac:{Invoice,CreditNote,DebitNote}Line node.
            // It provides information about the document line.
            // 
            // :param line:    A document line.
            // :return:        A python dictionary.
            // """
            // allowance_charge_vals_list = self._get_invoice_line_allowance_vals_list(line, tax_values_list=taxes_vals)
            // 
            // uom = self._get_uom_unece_code(line.product_uom_id)
            // total_fixed_tax_amount = sum(
            //     vals['amount']
            //     for vals in allowance_charge_vals_list
            //     if vals.get('charge_indicator') == 'true'
            // )
            // period_vals = {}
            // # deferred_start_date & deferred_end_date are enterprise-only fields
            // if line._fields.get('deferred_start_date') and (line.deferred_start_date or line.deferred_end_date):
            //     period_vals.update({'start_date': line.deferred_start_date})
            //     period_vals.update({'end_date': line.deferred_end_date})
            // return {
            //     'currency': line.currency_id,
            //     'currency_dp': self._get_currency_decimal_places(line.currency_id),
            //     'id': line_id + 1,
            //     'line_quantity': line.quantity,
            //     'line_quantity_attrs': {'unitCode': uom},
            //     'line_extension_amount': line.price_subtotal + total_fixed_tax_amount,
            //     'allowance_charge_vals': allowance_charge_vals_list,
            //     'tax_total_vals': self._get_invoice_line_tax_totals_vals_list(line, taxes_vals),
            //     'item_vals': self._get_invoice_line_item_vals(line, taxes_vals),
            //     'price_vals': self._get_invoice_line_price_vals(line),
            //     'invoice_period_vals_list': [period_vals] if period_vals else []
            // }
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_line_xpaths(self, document_type=False, qty_factor=1):
            // return {
            //     'deferred_start_date': './{*}InvoicePeriod/{*}StartDate',
            //     'deferred_end_date': './{*}InvoicePeriod/{*}EndDate',
            //     'date_format': '%Y-%m-%d',
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals, object line_extension_amount, object allowance_total_amount, object charge_total_amount) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_monetary_total_vals(self, invoice, taxes_vals, line_extension_amount, allowance_total_amount, charge_total_amount):
            // """ Method used to fill the cac:{Legal,Requested}MonetaryTotal node"""
            // # We only handle rounding amounts that do not belong to any tax ('add_invoice_line' cash rounding strategy).
            // # Rounding amounts belonging to a tax ('biggest_tax' strategy) are included already in the tax amounts.
            // rounding_amls = invoice.line_ids.filtered(lambda line: line.display_type == 'rounding' and not line.tax_line_id)
            // payable_rounding_amount = invoice.direction_sign * sum(rounding_amls.mapped('amount_currency'))
            // return {
            //     'currency': invoice.currency_id,
            //     'currency_dp': self._get_currency_decimal_places(invoice.currency_id),
            //     'line_extension_amount': line_extension_amount,
            //     'tax_exclusive_amount': taxes_vals['base_amount_currency'],
            //     'tax_inclusive_amount': invoice.amount_total - payable_rounding_amount,
            //     'allowance_total_amount': allowance_total_amount or None,
            //     'charge_total_amount': charge_total_amount or None,
            //     'prepaid_amount': invoice.amount_total - invoice.amount_residual,
            //     'payable_rounding_amount': payable_rounding_amount or None,
            //     'payable_amount': invoice.amount_residual,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_node(self, vals):
            // self._add_invoice_config_vals(vals)
            // self._add_invoice_base_lines_vals(vals)
            // self._add_invoice_currency_vals(vals)
            // self._add_invoice_tax_grouping_function_vals(vals)
            // self._add_invoice_monetary_totals_vals(vals)
            // 
            // document_node = {}
            // self._add_invoice_header_nodes(document_node, vals)
            // self._add_invoice_accounting_supplier_party_nodes(document_node, vals)
            // self._add_invoice_accounting_customer_party_nodes(document_node, vals)
            // self._add_invoice_seller_supplier_party_nodes(document_node, vals)
            // 
            // if vals['document_type'] == 'invoice':
            //     self._add_invoice_delivery_nodes(document_node, vals)
            //     self._add_invoice_payment_means_nodes(document_node, vals)
            //     self._add_invoice_payment_terms_nodes(document_node, vals)
            // 
            // self._add_invoice_allowance_charge_nodes(document_node, vals)
            // self._add_invoice_exchange_rate_nodes(document_node, vals)
            // self._add_invoice_tax_total_nodes(document_node, vals)
            // self._add_invoice_monetary_total_nodes(document_node, vals)
            // self._add_invoice_line_nodes(document_node, vals)
            // return document_node
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // if invoice.move_type == 'out_invoice':
            //     if invoice.partner_bank_id:
            //         payment_means_code, payment_means_name = (30, 'credit transfer')
            //     else:
            //         payment_means_code, payment_means_name = ('ZZZ', 'mutually defined')
            // else:
            //     payment_means_code, payment_means_name = (57, 'standing agreement')
            // 
            // # in Denmark payment code 30 is not allowed. we hardcode it to 1 ("unknown") for now
            // # as we cannot deduce this information from the invoice
            // if invoice.partner_id.country_code == 'DK':
            //     payment_means_code, payment_means_name = 1, 'unknown'
            // 
            // vals = {
            //     'payment_means_code': payment_means_code,
            //     'payment_means_code_attrs': {'name': payment_means_name},
            //     'payment_due_date': invoice.invoice_date_due or invoice.invoice_date,
            //     'instruction_id': invoice.payment_reference,
            //     'payment_id_vals': [invoice.payment_reference or invoice.name],
            // }
            // 
            // if invoice.partner_bank_id:
            //     vals['payee_financial_account_vals'] = self._get_financial_account_vals(invoice.partner_bank_id)
            // 
            // return [vals]
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentTermsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_payment_terms_vals_list(self, invoice):
            // payment_term = invoice.invoice_payment_term_id
            // if payment_term:
            //     # The payment term's note is automatically embedded in a <p> tag in Odoo
            //     return [{'note_vals': [{'note': html2plaintext(payment_term.note)}]}]
            // else:
            //     return []
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePeriodValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_period_vals_list(self, invoice):
            // """
            // For now, we cannot fill this data from an invoice
            // This corresponds to the 'delivery or invoice period'. For UBL Bis 3, in the case of intra-community supply,
            // the Actual delivery date (BT-72) or the Invoicing period (BG-14) should be present under the form:
            // {
            //     'start_date': str,
            //     'end_date': str,
            // }.
            // """
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_invoice_tax_totals_vals_list(self, invoice, taxes_vals):
            // tax_totals_vals = {
            //     'currency': invoice.currency_id,
            //     'currency_dp': self._get_currency_decimal_places(invoice.currency_id),
            //     'tax_amount': taxes_vals['tax_amount_currency'],
            //     'tax_subtotal_vals': [],
            // }
            // 
            // # If it's not on the whole invoice, don't manage the EPD.
            // epd_tax_to_discount = {}
            // if not taxes_vals.get('invoice_line'):
            //     epd_tax_to_discount = self._get_early_payment_discount_grouped_by_tax_rate(invoice)
            //     epd_base_tax_amounts = defaultdict(lambda: {
            //         'base_amount_currency': 0.0,
            //         'tax_amount_currency': 0.0,
            //     })
            //     if epd_tax_to_discount:
            //         for percentage, base_amount_currency in epd_tax_to_discount.items():
            //             epd_base_tax_amounts[percentage]['base_amount_currency'] += base_amount_currency
            //         epd_accounted_tax_amount = 0.0
            //         for percentage, amounts in epd_base_tax_amounts.items():
            //             amounts['tax_amount_currency'] = invoice.currency_id.round(
            //                 amounts['base_amount_currency'] * percentage / 100.0)
            //             epd_accounted_tax_amount += amounts['tax_amount_currency']
            // 
            // for grouping_key, vals in taxes_vals['tax_details'].items():
            //     if grouping_key['tax_amount_type'] != 'fixed' or not self._context.get('convert_fixed_taxes'):
            //         subtotal = {
            //             'currency': invoice.currency_id,
            //             'currency_dp': self._get_currency_decimal_places(invoice.currency_id),
            //             'taxable_amount': vals['base_amount_currency'],
            //             'tax_amount': vals['tax_amount_currency'],
            //             'percent': vals['tax_category_percent'],
            //             'tax_category_vals': vals['_tax_category_vals_'],
            //         }
            //         if epd_tax_to_discount:
            //             # early payment discounts: need to recompute the tax/taxable amounts
            //             epd_base_amount = epd_base_tax_amounts.get(subtotal['percent'], {}).get('base_amount_currency', 0.0)
            //             taxable_amount_after_epd = subtotal['taxable_amount'] - epd_base_amount
            //             subtotal.update({
            //                 'taxable_amount': taxable_amount_after_epd,
            //             })
            //         tax_totals_vals['tax_subtotal_vals'].append(subtotal)
            // 
            // if epd_tax_to_discount:
            //     # early payment discounts: hence, need to add a subtotal section
            //     tax_totals_vals['tax_subtotal_vals'].append({
            //         'currency': invoice.currency_id,
            //         'currency_dp': invoice.currency_id.decimal_places,
            //         'taxable_amount': sum(epd_tax_to_discount.values()),
            //         'tax_amount': 0.0,
            //         'tax_category_vals': {
            //             'id': 'E',
            //             'percent': 0.0,
            //             'tax_scheme_vals': {
            //                 'id': "VAT",
            //             },
            //             'tax_exemption_reason': "Exempt from tax",
            //         },
            //     })
            // return [tax_totals_vals]
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

        public async Task<TEntity> GetLineDiscountAllowanceChargeNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_line_discount_allowance_charge_node(self, vals):
            // currency_suffix = vals['currency_suffix']
            // if float_is_zero(vals[f'discount_amount{currency_suffix}'], precision_digits=vals['currency_dp']):
            //     return None
            // 
            // return {
            //     'cbc:ChargeIndicator': {'_text': 'false' if vals[f'discount_amount{currency_suffix}'] > 0 else 'true'},
            //     'cbc:AllowanceChargeReasonCode': {'_text': '95'},
            //     'cbc:Amount': {
            //         '_text': self.format_float(
            //             abs(vals[f'discount_amount{currency_suffix}']),
            //             vals['currency_dp'],
            //         ),
            //         'currencyID': vals['currency_name'],
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLineFixedTaxAggregatedTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_line_fixed_tax_aggregated_tax_details(self, vals):
            // base_line = vals['base_line']
            // 
            // def fixed_tax_grouping_function(base_line, tax_data):
            //     tax = tax_data and tax_data['tax']
            //     if not tax or tax.amount_type != 'fixed':
            //         return None
            //     return tax.name
            // 
            // return self.env['account.tax']._aggregate_base_line_tax_details(base_line, fixed_tax_grouping_function)
            */
            return default;
        }

        public async Task<TEntity> GetLineFixedTaxAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_line_fixed_tax_allowance_charge_nodes(self, vals):
            // fixed_tax_aggregated_tax_details = self._get_line_fixed_tax_aggregated_tax_details(vals)
            // currency_suffix = vals['currency_suffix']
            // 
            // allowance_charge_nodes = []
            // for grouping_key, tax_details in fixed_tax_aggregated_tax_details.items():
            //     if grouping_key:
            //         allowance_charge_nodes.append({
            //             'cbc:ChargeIndicator': {'_text': 'true' if tax_details[f'tax_amount{currency_suffix}'] > 0 else 'false'},
            //             'cbc:AllowanceChargeReasonCode': {'_text': 'AEO'},
            //             'cbc:AllowanceChargeReason': {'_text': grouping_key},
            //             'cbc:Amount': {
            //                 '_text': self.format_float(
            //                     abs(tax_details[f'tax_amount{currency_suffix}']),
            //                     vals['currency_dp'],
            //                 ),
            //                 'currencyID': vals['currency_name'],
            //             },
            //         })
            // return allowance_charge_nodes
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
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_line_xpaths(self, document_type=False, qty_factor=1):
            // return {
            //     'basis_qty': './cac:Price/cbc:BaseQuantity',
            //     'gross_price_unit': './{*}Price/{*}AllowanceCharge/{*}BaseAmount',
            //     'rebate': './{*}Price/{*}AllowanceCharge/{*}Amount',
            //     'net_price_unit': './{*}Price/{*}PriceAmount',
            //     'delivered_qty': (
            //         './{*}InvoicedQuantity'
            //         if document_type and document_type in ('in_invoice', 'out_invoice') or qty_factor == -1
            //         else './{*}CreditedQuantity'
            //     ),
            //     'allowance_charge': './/{*}AllowanceCharge',
            //     'allowance_charge_indicator': './{*}ChargeIndicator',
            //     'allowance_charge_amount': './{*}Amount',
            //     'allowance_charge_reason': './{*}AllowanceChargeReason',
            //     'allowance_charge_reason_code': './{*}AllowanceChargeReasonCode',
            //     'line_total_amount': './{*}LineExtensionAmount',
            //     'name': [
            //         './cac:Item/cbc:Description',
            //         './cac:Item/cbc:Name',
            //     ],
            //     'product': {
            //         'default_code': './cac:Item/cac:SellersItemIdentification/cbc:ID',
            //         'name': './cac:Item/cbc:Name',
            //         'barcode': './cac:Item/cac:StandardItemIdentification/cbc:ID[@schemeID="0160"]',
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNoteValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_note_vals_list(self, invoice):
            // return [{'note': html2plaintext(invoice.narration)}] if invoice.narration else []
            */
            return default;
        }

        public async Task<TEntity> GetPartnerAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_partner_address_vals(self, partner):
            // return {
            //     'street_name': partner.street,
            //     'additional_street_name': partner.street2,
            //     'city_name': partner.city,
            //     'postal_zone': partner.zip,
            //     'country_subentity': partner.state_id.name,
            //     'country_subentity_code': partner.state_id.code,
            //     'country_vals': self._get_country_vals(partner.country_id),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPartnerContactValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_partner_contact_vals(self, partner):
            // return {
            //     'id': partner.id,
            //     'name': partner.name,
            //     'telephone': partner.phone or partner.mobile,
            //     'electronic_mail': partner.email,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPartnerDetailStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _get_partner_detail_str(self, name, phone=False, email=False, vat=False):
            // """ Return partner details string to help user find or create proper contact with details.
            // """
            // partner_details = _("Name: %(name)s, Vat: %(vat)s", name=name, vat=vat)
            // if phone:
            //     partner_details += _(", Phone: %(phone)s", phone=phone)
            // if email:
            //     partner_details += _(", Email: %(email)s", email=email)
            // 
            // return partner_details
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyIdentificationValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_partner_party_identification_vals_list(self, partner):
            // if partner.ref:
            //     return [{'id': partner.ref}]
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // return [{
            //     'commercial_partner': partner,
            //     'registration_name': partner.name,
            //     'company_id': partner.vat,
            //     'registration_address_vals': self._get_partner_address_vals(partner),
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // # [BR-CO-09] if the PartyTaxScheme/TaxScheme/ID == 'VAT', CompanyID must start with a country code prefix.
            // # In some countries however, the CompanyID can be with or without country code prefix and still be perfectly
            // # valid (RO, HU, non-EU countries).
            // # We have to handle their cases by changing the TaxScheme/ID to 'something other than VAT',
            // # preventing the trigger of the rule.
            // tax_scheme_id = 'VAT'
            // if (
            //     partner.country_id
            //     and partner.vat and not partner.vat[:2].isalpha()
            // ):
            //     tax_scheme_id = 'NOT_EU_VAT'
            // return [{
            //     'registration_name': partner.name,
            //     'company_id': partner.vat,
            //     'registration_address_vals': self._get_partner_address_vals(partner),
            //     'tax_scheme_vals': {'id': tax_scheme_id},
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // return {
            //     'partner': partner,
            //     'party_identification_vals': self._get_partner_party_identification_vals_list(partner.commercial_partner_id),
            //     'party_name_vals': [{'name': partner.display_name}],
            //     'postal_address_vals': self._get_partner_address_vals(partner),
            //     'party_tax_scheme_vals': self._get_partner_party_tax_scheme_vals_list(partner.commercial_partner_id, role),
            //     'party_legal_entity_vals': self._get_partner_party_legal_entity_vals_list(partner.commercial_partner_id),
            //     'contact_vals': self._get_partner_contact_vals(partner),
            //     'person_vals': self._get_partner_person_vals(partner),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPersonValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_partner_person_vals(self, partner):
            // """
            // This is optional and meant to be overridden when required under the form:
            // {
            //     'first_name': str,
            //     'family_name': str,
            // }.
            // Should return a dict.
            // """
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_party_node(self, vals):
            // """ Generic helper to generate the Party node for a res.partner. """
            // partner = vals['partner']
            // commercial_partner = partner.commercial_partner_id
            // return {
            //     'cac:PartyIdentification': {
            //         'cbc:ID': {'_text': commercial_partner.ref},
            //     },
            //     'cac:PartyName': {
            //         'cbc:Name': {'_text': partner.display_name},
            //     },
            //     'cac:PostalAddress': self._get_address_node(vals),
            //     'cac:PartyTaxScheme': {
            //         'cbc:RegistrationName': {'_text': commercial_partner.name},
            //         'cbc:CompanyID': {'_text': commercial_partner.vat},
            //         'cac:RegistrationAddress': self._get_address_node({**vals, 'partner': commercial_partner}),
            //         'cac:TaxScheme': {
            //             'cbc:ID': {
            //                 '_text': ('NOT_EU_VAT' if commercial_partner.country_id and
            //                         commercial_partner.vat and
            //                         not commercial_partner.vat[:2].isalpha() else 'VAT')
            //             }
            //         },
            //     },
            //     'cac:PartyLegalEntity': {
            //         'cbc:RegistrationName': {'_text': commercial_partner.name},
            //         'cbc:CompanyID': {'_text': commercial_partner.vat},
            //         'cac:RegistrationAddress': self._get_address_node({**vals, 'partner': commercial_partner}),
            //     },
            //     'cac:Contact': {
            //         'cbc:ID': {'_text': partner.id},
            //         'cbc:Name': {'_text': partner.name},
            //         'cbc:Telephone': {'_text': partner.phone},
            //         'cbc:ElectronicMail': {'_text': partner.email},
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> GetPricingExchangeRateValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_pricing_exchange_rate_vals_list(self, invoice):
            // """ To be overridden if needed to fill the PricingExchangeRate node.
            // 
            // This is used when the currency of the 'Exchange' (e.g.: an invoice) is not the same as the Document currency.
            // 
            // If used, it should return a list of dict, following this format: [{
            //     'source_currency_code': str,  (required)
            //     'target_currency_code': str,  (required)
            //     'calculation_rate': float,
            //     'date': date,
            // }]
            // """
            // return []
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

        public async Task<TEntity> GetTagsForDocumentTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_tags_for_document_type(self, vals):
            // return {
            //     'document_type_code': {
            //         'invoice': 'cbc:InvoiceTypeCode',
            //         'credit_note': 'cbc:CreditNoteTypeCode',
            //         'debit_note': None,
            //         'order': 'cbc:OrderTypeCode',
            //     }[vals['document_type']],
            //     'monetary_total': {
            //         'invoice': 'cac:LegalMonetaryTotal',
            //         'credit_note': 'cac:LegalMonetaryTotal',
            //         'debit_note': 'cac:RequestedMonetaryTotal',
            //         'order': 'cac:AnticipatedMonetaryTotal',
            //     }[vals['document_type']],
            //     'document_line': {
            //         'invoice': 'cac:InvoiceLine',
            //         'credit_note': 'cac:CreditNoteLine',
            //         'debit_note': 'cac:DebitNoteLine',
            //         'order': 'cac:OrderLine',
            //     }[vals['document_type']],
            //     'line_quantity': {
            //         'invoice': 'cbc:InvoicedQuantity',
            //         'credit_note': 'cbc:CreditedQuantity',
            //         'debit_note': 'cbc:DebitedQuantity',
            //         'order': 'cbc:Quantity',
            //     }[vals['document_type']]
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_tax_category_code(self, customer, supplier, tax):
            // if not tax:
            //     return 'E'
            // return self._get_tax_unece_codes(customer, supplier, tax).get('tax_category_code')
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // """ Full list: https://unece.org/fileadmin/DAM/trade/untdid/d16b/tred/tred5305.htm
            // Subset: https://docs.peppol.eu/poacc/billing/3.0/codelist/UNCL5305/
            // 
            // :param taxes:   account.tax records.
            // :return:        A list of values to fill the TaxCategory foreach template.
            // """
            // res = []
            // for tax in taxes:
            //     tax_unece_codes = self._get_tax_unece_codes(customer, supplier, tax)
            //     res.append({
            //         'id': tax_unece_codes.get('tax_category_code'),
            //         'percent': tax.amount if tax.amount_type == 'percent' else False,
            //         'name': tax_unece_codes.get('tax_exemption_reason'),
            //         'tax_scheme_vals': {'id': 'VAT'},
            //         **tax_unece_codes,
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_tax_category_node(self, vals):
            // """ Generic helper to generate a TaxCategory node given a tax grouping key dict. """
            // grouping_key = vals['grouping_key']
            // return {
            //     'cbc:ID': {'_text': grouping_key['tax_category_code']},
            //     'cbc:Name': {'_text': grouping_key.get('name')},
            //     'cbc:Percent': {'_text': grouping_key['amount']} if grouping_key['amount_type'] == 'percent' else None,
            //     'cbc:TaxExemptionReasonCode': {'_text': grouping_key.get('tax_exemption_reason_code')},
            //     'cbc:TaxExemptionReason': {'_text': grouping_key.get('tax_exemption_reason')},
            //     'cac:TaxScheme': {
            //         'cbc:ID': {'_text': 'VAT'},
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxExemptionReasonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_tax_exemption_reason(self, customer, supplier, tax):
            // if not tax:
            //     return {
            //         'tax_exemption_reason': _("Exempt from tax"),
            //         'tax_exemption_reason_code': None,
            //     }
            // res = self._get_tax_unece_codes(customer, supplier, tax)
            // return {
            //     'tax_exemption_reason': res.get('tax_exemption_reason'),
            //     'tax_exemption_reason_code': res.get('tax_exemption_reason_code'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_tax_grouping_key(self, base_line, tax_data):
            // tax = tax_data['tax']
            // customer = base_line['record'].move_id.commercial_partner_id
            // supplier = base_line['record'].move_id.company_id.partner_id.commercial_partner_id
            // tax_category_vals = self._get_tax_category_list(customer, supplier, tax)[0]
            // grouping_key = {
            //     'tax_category_id': tax_category_vals['id'],
            //     'tax_category_percent': tax_category_vals['percent'],
            //     '_tax_category_vals_': tax_category_vals,
            //     'tax_amount_type': tax.amount_type,
            // }
            // # If the tax is fixed, we want to have one group per tax
            // # s.t. when the invoice is imported, we can try to guess the fixed taxes
            // if tax.amount_type == 'fixed':
            //     grouping_key['tax_name'] = tax.name
            // return grouping_key
            */
            return default;
        }

        public async Task<TEntity> GetTaxNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py) ---
            // def _get_tax_nodes(self, tree):
            // return tree.findall('.//{*}ApplicableTradeTax/{*}RateApplicablePercent')
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_tax_nodes(self, tree):
            // tax_nodes = tree.findall('.//{*}Item/{*}ClassifiedTaxCategory/{*}Percent')
            // if not tax_nodes:
            //     for elem in tree.findall('.//{*}TaxTotal'):
            //         percentage_nodes = elem.findall('.//{*}TaxSubtotal/{*}TaxCategory/{*}Percent')
            //         if not percentage_nodes:
            //             percentage_nodes = elem.findall('.//{*}TaxSubtotal/{*}Percent')
            //         tax_nodes += percentage_nodes
            // return tax_nodes
            */
            return default;
        }

        public async Task<TEntity> GetTaxSubtotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_tax_subtotal_node(self, vals):
            // """ Generic helper to generate a TaxSubtotal node given a tax grouping key dict and associated tax values. """
            // tax_details = vals['tax_details']
            // grouping_key = vals['grouping_key']
            // sign = vals.get('sign', 1)
            // currency_suffix = vals['currency_suffix']
            // return {
            //     'cbc:TaxableAmount': {
            //         '_text': self.format_float(tax_details[f'base_amount{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name']
            //     },
            //     'cbc:TaxAmount': {
            //         '_text': self.format_float(sign * tax_details[f'tax_amount{currency_suffix}'], vals['currency_dp']),
            //         'currencyID': vals['currency_name']
            //     },
            //     'cbc:Percent': {'_text': grouping_key['amount']} if grouping_key['amount_type'] == 'percent' else None,
            //     'cac:TaxCategory': self._get_tax_category_node({**vals, 'grouping_key': grouping_key})
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxTotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _get_tax_total_node(self, vals):
            // """ Generic helper to generate a TaxTotal node given a dict of aggregated tax details. """
            // aggregated_tax_details = vals['aggregated_tax_details']
            // currency_suffix = vals['currency_suffix']
            // sign = vals.get('sign', 1)
            // total_tax_amount = sum(
            //     values[f'tax_amount{currency_suffix}']
            //     for grouping_key, values in aggregated_tax_details.items()
            //     if grouping_key
            // )
            // return {
            //     'cbc:TaxAmount': {
            //         '_text': self.format_float(sign * total_tax_amount, vals['currency_dp']),
            //         'currencyID': vals['currency_name']
            //     },
            //     'cac:TaxSubtotal': [
            //         self._get_tax_subtotal_node({
            //             **vals,
            //             'tax_details': tax_details,
            //             'grouping_key': grouping_key,
            //         })
            //         for grouping_key, tax_details in aggregated_tax_details.items()
            //         if grouping_key
            //     ]
            // }
            */
            return default;
        }

        public async Task<TEntity> GetTaxUneceCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _get_tax_unece_codes(self, customer, supplier, tax):
            // """
            // Source: doc of Peppol (but the CEF norm is also used by factur-x, yet not detailed)
            // https://docs.peppol.eu/poacc/billing/3.0/syntax/ubl-invoice/cac-TaxTotal/cac-TaxSubtotal/cac-TaxCategory/cbc-TaxExemptionReasonCode/
            // https://docs.peppol.eu/poacc/billing/3.0/codelist/vatex/
            // https://docs.peppol.eu/poacc/billing/3.0/codelist/UNCL5305/
            // :returns: {
            //     tax_category_code: str,
            //     tax_exemption_reason_code: str,
            //     tax_exemption_reason: str,
            // }
            // """
            // 
            // def create_dict(tax_category_code=None, tax_exemption_reason_code=None, tax_exemption_reason=None):
            //     return {
            //         'tax_category_code': tax_category_code,
            //         'tax_exemption_reason_code': tax_exemption_reason_code,
            //         'tax_exemption_reason': tax_exemption_reason,
            //     }
            // 
            // # add Norway, Iceland, Liechtenstein
            // european_economic_area = self.env.ref('base.europe').country_ids.mapped('code') + ['NO', 'IS', 'LI']
            // 
            // if customer.country_id.code == 'ES' and customer.zip:
            //     if customer.zip[:2] in ('35', '38'):  # Canary
            //         # [BR-IG-10]-A VAT breakdown (BG-23) with VAT Category code (BT-118) "IGIC" shall not have a VAT
            //         # exemption reason code (BT-121) or VAT exemption reason text (BT-120).
            //         return create_dict(tax_category_code='L')
            //     if customer.zip[:2] in ('51', '52'):
            //         return create_dict(tax_category_code='M')  # Ceuta & Mellila
            // 
            // if supplier.country_id == customer.country_id:
            //     if not tax or tax.amount == 0:
            //         # in theory, you should indicate the precise law article
            //         return create_dict(tax_category_code='E', tax_exemption_reason=_('Articles 226 items 11 to 15 Directive 2006/112/EN'))
            //     else:
            //         return create_dict(tax_category_code='S')  # standard VAT
            // 
            // if supplier.country_id.code in european_economic_area and supplier.vat:
            //     if tax.amount != 0:
            //         # otherwise, the validator will complain because G and K code should be used with 0% tax
            //         return create_dict(tax_category_code='S')
            //     if customer.country_id.code not in european_economic_area:
            //         return create_dict(
            //             tax_category_code='G',
            //             tax_exemption_reason_code='VATEX-EU-G',
            //             tax_exemption_reason=_('Export outside the EU'),
            //         )
            //     if customer.country_id.code in european_economic_area:
            //         return create_dict(
            //             tax_category_code='K',
            //             tax_exemption_reason_code='VATEX-EU-IC',
            //             tax_exemption_reason=_('Intra-Community supply'),
            //         )
            // 
            // if tax.amount != 0:
            //     return create_dict(tax_category_code='S')
            // else:
            //     return create_dict(tax_category_code='E', tax_exemption_reason=_('Articles 226 items 11 to 15 Directive 2006/112/EN'))
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii_tax_extension, FILE: account_edi_common.py) ---
            // def _get_tax_unece_codes(self, customer, supplier, tax):
            // if tax.ubl_cii_tax_category_code:
            //     reason_code = tax.ubl_cii_tax_exemption_reason_code
            //     reason_code = FIX_WRONG_CODES_MAPPING.get(reason_code, reason_code)
            //     tax_exemption_reason = TAX_EXEMPTION_MAPPING.get(reason_code)
            //     return {
            //         'tax_category_code': tax.ubl_cii_tax_category_code,
            //         'tax_exemption_reason_code': reason_code,
            //         'tax_exemption_reason': tax_exemption_reason,
            //     }
            // return super()._get_tax_unece_codes(customer, supplier, tax)
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
            // # Import the embedded PDF in the xml if some are found
            // attachments = self.env['ir.attachment']
            // additional_docs = tree.findall('./{*}AdditionalDocumentReference')
            // for document in additional_docs:
            //     attachment_name = document.find('{*}ID')
            //     attachment_data = document.find('{*}Attachment/{*}EmbeddedDocumentBinaryObject')
            //     if attachment_name is not None \
            //             and attachment_data is not None \
            //             and attachment_data.attrib.get('mimeCode') == 'application/pdf':
            //         text = attachment_data.text
            //         # Normalize the name of the file : some e-fff emitters put the full path of the file
            //         # (Windows or Linux style) and/or the name of the xml instead of the pdf.
            //         # Get only the filename with a pdf extension.
            //         name = (attachment_name.text or 'invoice').split('\\')[-1].split('/')[-1].split('.')[0] + '.pdf'
            //         attachment = self.env['ir.attachment'].create({
            //             'name': name,
            //             'res_id': invoice.id,
            //             'res_model': 'account.move',
            //             'datas': text + '=' * (len(text) % 3),  # Fix incorrect padding
            //             'type': 'binary',
            //             'mimetype': 'application/pdf',
            //         })
            //         # Upon receiving an email (containing an xml) with a configured alias to create invoice, the xml is
            //         # set as the main_attachment. To be rendered in the form view, the pdf should be the main_attachment.
            //         if invoice.message_main_attachment_id and \
            //                 invoice.message_main_attachment_id.name.endswith('.xml') and \
            //                 'pdf' not in invoice.message_main_attachment_id.mimetype:
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

        public async Task<TEntity> ImportDeliveryPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object name, object phone, object email) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_delivery_partner(self, order, name, phone, email):
            // """ Import delivery address from details if not found then log details."""
            // logs = []
            // dest_partner = self.env['res.partner'].with_company(
            //     order.company_id
            // )._retrieve_partner(name=name, phone=phone, email=email)
            // if not dest_partner:
            //     partner_detaits_str = self._get_partner_detail_str(name, phone, email)
            //     logs.append(_("Could not retrieve Delivery Address with Details: { %s }", partner_detaits_str))
            // 
            // return dest_partner, logs
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
            // invoice_line_vals, line_logs = self._import_invoice_lines(invoice, tree, './{*}SupplyChainTradeTransaction/{*}IncludedSupplyChainTradeLineItem', qty_factor)
            // line_vals = allowance_charges_line_vals + invoice_line_vals
            // 
            // invoice_values = {
            //     **invoice_values,
            //     'invoice_line_ids': [Command.create(line_value) for line_value in line_vals],
            // }
            // invoice.write(invoice_values)
            // logs += partner_logs + currency_logs + line_logs + allowance_charges_logs
            // return logs
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _import_fill_invoice(self, invoice, tree, qty_factor):
            // logs = []
            // invoice_values = {}
            // if qty_factor == -1:
            //     logs.append(_("The invoice has been converted into a credit note and the quantities have been reverted."))
            // role = "AccountingCustomer" if invoice.journal_id.type == 'sale' else "AccountingSupplier"
            // partner, partner_logs = self._import_partner(invoice.company_id, **self._import_retrieve_partner_vals(tree, role))
            // # Need to set partner before to compute bank and lines properly
            // invoice.partner_id = partner.id
            // invoice_values['currency_id'], currency_logs = self._import_currency(tree, './/{*}DocumentCurrencyCode')
            // invoice_values['invoice_date'] = tree.findtext('./{*}IssueDate')
            // invoice_values['invoice_date_due'] = self._find_value(('./cbc:DueDate', './/cbc:PaymentDueDate'), tree)
            // # ==== partner_bank_id ====
            // bank_detail_nodes = tree.findall('.//{*}PaymentMeans')
            // bank_details = [bank_detail_node.findtext('{*}PayeeFinancialAccount/{*}ID') for bank_detail_node in bank_detail_nodes]
            // if bank_details:
            //     self._import_partner_bank(invoice, bank_details)
            // 
            // # ==== ref, invoice_origin, narration, payment_reference ====
            // ref = tree.findtext('./{*}ID')
            // if ref and invoice.is_sale_document(include_receipts=True) and invoice.quick_edit_mode:
            //     invoice_values['name'] = ref
            // elif ref:
            //     invoice_values['ref'] = ref
            // invoice_values['invoice_origin'] = tree.findtext('./{*}OrderReference/{*}ID')
            // invoice_values['narration'] = self._import_description(tree, xpaths=['./{*}Note', './{*}PaymentTerms/{*}Note'])
            // invoice_values['payment_reference'] = tree.findtext('./{*}PaymentMeans/{*}PaymentID')
            // 
            // # ==== Delivery ====
            // delivery_date = tree.find('.//{*}Delivery/{*}ActualDeliveryDate')
            // invoice.delivery_date = delivery_date is not None and delivery_date.text
            // 
            // # ==== invoice_incoterm_id ====
            // incoterm_code = tree.findtext('./{*}TransportExecutionTerms/{*}DeliveryTerms/{*}ID')
            // if incoterm_code:
            //     incoterm = self.env['account.incoterms'].search([('code', '=', incoterm_code)], limit=1)
            //     if incoterm:
            //         invoice_values['invoice_incoterm_id'] = incoterm.id
            // 
            // # ==== Document level AllowanceCharge, Prepaid Amounts, Invoice Lines, Payable Rounding Amount ====
            // allowance_charges_line_vals, allowance_charges_logs = self._import_document_allowance_charges(tree, invoice, invoice.journal_id.type, qty_factor)
            // logs += self._import_prepaid_amount(invoice, tree, './{*}LegalMonetaryTotal/{*}PrepaidAmount', qty_factor)
            // line_tag = (
            //     'InvoiceLine'
            //     if invoice.move_type in ('in_invoice', 'out_invoice') or qty_factor == -1
            //     else 'CreditNoteLine'
            // )
            // invoice_line_vals, line_logs = self._import_invoice_lines(invoice, tree, './{*}' + line_tag, qty_factor)
            // rounding_line_vals, rounding_logs = self._import_rounding_amount(invoice, tree, './{*}LegalMonetaryTotal/{*}PayableRoundingAmount', qty_factor)
            // line_vals = allowance_charges_line_vals + invoice_line_vals + rounding_line_vals
            // 
            // invoice_values = {
            //     **invoice_values,
            //     'invoice_line_ids': [Command.create(line_value) for line_value in line_vals],
            // }
            // invoice.write(invoice_values)
            // logs += partner_logs + currency_logs + line_logs + allowance_charges_logs + rounding_logs
            // return logs
            */
            return default;
        }

        public async Task<TEntity> ImportInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object xpath, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_invoice_lines(self, invoice, tree, xpath, qty_factor):
            // logs = []
            // lines_values = []
            // for line_tree in tree.iterfind(xpath):
            //     line_values = self.with_company(invoice.company_id)._retrieve_invoice_line_vals(line_tree, invoice.move_type, qty_factor)
            //     line_values['tax_ids'], tax_logs = self._retrieve_taxes(
            //         invoice, line_values, invoice.journal_id.type,
            //     )
            //     logs += tax_logs
            //     if not line_values['product_uom_id']:
            //         line_values.pop('product_uom_id')  # if no uom, pop it so it's inferred from the product_id
            //     lines_values.append(line_values)
            //     lines_values += self._retrieve_line_charges(invoice, line_values, line_values['tax_ids'])
            // return lines_values, logs
            */
            return default;
        }

        public async Task<TEntity> ImportInvoiceUblCiiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object file_data, object @new) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_invoice_ubl_cii(self, invoice, file_data, new=False):
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
            //     logs = self._import_fill_invoice(invoice, tree, qty_factor)
            // 
            // if invoice:
            //     body = Markup("<strong>%s</strong>") % \
            //         _("Format used to import the invoice: %s",
            //           self.env['ir.model']._get(self._name).name)
            // 
            //     if logs:
            //         body += Markup("<ul>%s</ul>") % \
            //             Markup().join(Markup("<li>%s</li>") % l for l in logs)
            // 
            //     invoice.message_post(body=body)
            // 
            // # For UBL, we should override the computed tax amount if it is less than 0.05 different of the one in the xml.
            // # In order to support use case where the tax total is adapted for rounding purpose.
            // # This has to be done after the first import in order to let Odoo compute the taxes before overriding if needed.
            // with invoice._get_edi_creation() as invoice:
            //     self._correct_invoice_tax_amount(tree, invoice)
            // 
            // attachments = self._import_attachments(invoice, tree)
            // if attachments:
            //     invoice.with_context(no_new_invoice=True).message_post(attachment_ids=attachments.ids)
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ImportOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object xpath) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_order_lines(self, order, tree, xpath):
            // """ Import order lines from xml tree.
            // 
            // :param order: Order to set order line on.
            // :param tree: Xml tree to extract OrderLine from.
            // :param xpath: Xpath for order line items.
            // :return: Logging information related orderlines details.
            // :rtype: List
            // """
            // logs = []
            // lines_values = []
            // for line_tree in tree.iterfind(xpath):
            //     line_values = self._retrieve_line_vals(line_tree)
            //     line_values = {
            //         **line_values,
            //         'product_uom_qty': line_values['quantity'],
            //         'product_uom': line_values['product_uom_id'],
            //     }
            //     del line_values['quantity']
            //     # To do: rename product_uom field to `product_uom_id` of sale.order.line
            //     del line_values['product_uom_id']
            //     if not line_values['product_id']:
            //         logs += [_("Could not retrieve product for line '%s'", line_values['name'])]
            //     # To do: rename tax_id field to `tax_ids` of sale.order.line
            //     line_values['tax_id'], tax_logs = self._retrieve_taxes(
            //         order, line_values, 'sale',
            //     )
            //     logs += tax_logs
            //     lines_values += self._retrieve_line_charges(order, line_values, line_values['tax_id'])
            //     if not line_values['product_uom']:
            //         line_values.pop('product_uom')  # if no uom, pop it so it's inferred from the product_id
            //     lines_values.append(line_values)
            // 
            // return lines_values, logs
            */
            return default;
        }

        public async Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_order_ubl(self, order, file_data):
            // """ Common importing method to extract order data from file_data.
            // 
            // :param order: Order to fill details from file_data.
            // :param file_data: File data to extract order related data from.
            // :return: True if there no exception while extraction.
            // :rtype: Boolean
            // """
            // tree = file_data['xml_tree']
            // 
            // # Update the order.
            // logs = self._import_fill_order(order, tree)
            // if order:
            //     body = Markup("<strong>%s</strong>") % \
            //         _("Format used to import the invoice: %s",
            //           self.env['ir.model']._get(self._name).name)
            //     if logs:
            //         order._create_activity_set_details()
            //         body += Markup("<ul>%s</ul>") % \
            //             Markup().join(Markup("<li>%s</li>") % l for l in logs)
            //     order.message_post(body=body)
            // 
            // lines_with_products = order.order_line.filtered('product_id')
            // # Recompute product price and discount according to sale price
            // lines_with_products._compute_price_unit()
            // lines_with_products._compute_discount()
            // 
            // return True
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
            // bank_details = list(map(sanitize_account_number, bank_details))
            // partner = self.env.company.partner_id if invoice.is_inbound() else invoice.partner_id
            // banks_to_create = []
            // acc_number_partner_bank_dict = {
            //     bank.sanitized_acc_number: bank
            //     for bank in ResPartnerBank.search(
            //         [('company_id', 'in', [False, invoice.company_id.id]), ('acc_number', 'in', bank_details)]
            //     )
            // }
            // for account_number in bank_details:
            //     partner_bank = acc_number_partner_bank_dict.get(account_number, ResPartnerBank)
            //     if partner_bank.partner_id == partner:
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
            // def _import_partner(self, company_id, name, phone, email, vat, country_code=False, peppol_eas=False, peppol_endpoint=False, street=False, street2=False, city=False, zip_code=False):
            // """ Retrieve the partner, if no matching partner is found, create it (only if he has a vat and a name) """
            // logs = []
            // if peppol_eas and peppol_endpoint:
            //     domain = [('peppol_eas', '=', peppol_eas), ('peppol_endpoint', '=', peppol_endpoint)]
            // else:
            //     domain = False
            // partner = self.env['res.partner'] \
            //     .with_company(company_id) \
            //     ._retrieve_partner(name=name, phone=phone, email=email, vat=vat, domain=domain)
            // if not partner and name and vat:
            //     partner_vals = {'name': name, 'email': email, 'phone': phone, 'street': street, 'street2': street2, 'zip': zip_code, 'city': city}
            //     if peppol_eas and peppol_endpoint:
            //         partner_vals.update({'peppol_eas': peppol_eas, 'peppol_endpoint': peppol_endpoint})
            //     country = self.env.ref(f'base.{country_code.lower()}', raise_if_not_found=False) if country_code else False
            //     if country:
            //         partner_vals['country_id'] = country.id
            //     partner = self.env['res.partner'].create(partner_vals)
            //     if vat and self.env['res.partner']._run_vat_test(vat, country, partner.is_company):
            //         partner.vat = vat
            //     logs.append(_("Could not retrieve a partner corresponding to '%s'. A new partner was created.", name))
            // return partner, logs
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_partner(self, company_id, name, phone, email, vat, **kwargs):
            // """ Override of edi.mixin to set current user partner if there is no matching partner
            // found and log details related to partner."""
            // partner, logs = super()._import_partner(company_id, name, phone, email, vat, **kwargs)
            // if not partner:
            //     partner_detaits_str = self._get_partner_detail_str(name, phone, email, vat)
            //     if not vat:
            //         logs.append(_("Insufficient details to extract Customer: { %s }", partner_detaits_str))
            //     else:
            //         logs.append(_("Could not retrive Customer with Details: { %s }", partner_detaits_str))
            // 
            // return partner, logs
            */
            return default;
        }

        public async Task<TEntity> ImportPaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree, object xapth) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_edi_ubl, FILE: sale_edi_common.py) ---
            // def _import_payment_term_id(self, order, tree, xapth):
            // """ Return payment term from given tree. """
            // payment_term_note = self._find_value(xapth, tree)
            // if not payment_term_note:
            //     return False
            // 
            // return self.env['account.payment.term'].search([
            //     *self.env['account.payment.term']._check_company_domain(order.company_id),
            //     ('name', '=', payment_term_note)
            // ], limit=1)
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
            //     'country_code': self._find_value(f'.//ram:{role}/ram:PostalTradeAddress//ram:CountryID', tree),
            // }
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _import_retrieve_partner_vals(self, tree, role):
            // """ Returns a dict of values that will be used to retrieve the partner """
            // return {
            //     'vat': self._find_value(f'.//cac:{role}Party/cac:Party//cbc:CompanyID[string-length(text()) > 5]', tree),
            //     'phone': self._find_value(f'.//cac:{role}Party/cac:Party//cbc:Telephone', tree),
            //     'email': self._find_value(f'.//cac:{role}Party/cac:Party//cbc:ElectronicMail', tree),
            //     'name': self._find_value(f'.//cac:{role}Party/cac:Party//cbc:Name', tree) or
            //             self._find_value(f'.//cac:{role}Party/cac:Party//cbc:RegistrationName', tree),
            //     'country_code': self._find_value(f'.//cac:{role}Party/cac:Party//cac:Country//cbc:IdentificationCode', tree),
            //     'street': self._find_value(f'.//cac:{role}Party/cac:Party//cbc:StreetName', tree),
            //     'street2': self._find_value(f'.//cac:{role}Party/cac:Party//cbc:AdditionalStreetName', tree),
            //     'city': self._find_value(f'.//cac:{role}Party/cac:Party//cbc:CityName', tree),
            //     'zip_code': self._find_value(f'.//cac:{role}Party/cac:Party//cbc:PostalZone', tree),
            // }
            */
            return default;
        }

        public async Task<TEntity> ImportRoundingAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object xpath, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _import_rounding_amount(self, invoice, tree, xpath, qty_factor):
            // """
            // Add an invoice line representing the rounding amount given in the document.
            // - The amount is assumed to be in document currency
            // """
            // logs = []
            // line_vals = []
            // 
            // currency = invoice.currency_id
            // rounding_amount_currency = currency.round(qty_factor * float(tree.findtext(xpath) or 0))
            // 
            // if invoice.currency_id.is_zero(rounding_amount_currency):
            //     return line_vals, logs
            // 
            // inverse_rate = abs(invoice.amount_total_signed) / invoice.amount_total if invoice.amount_total else 0
            // rounding_amount = invoice.company_id.currency_id.round(rounding_amount_currency * inverse_rate)
            // 
            // line_vals.append({
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
            // return line_vals, logs
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsCommonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _invoice_constraints_common(self, invoice):
            // # check that there is a tax on each line
            // for line in invoice.invoice_line_ids.filtered(lambda x: x.display_type not in ('line_note', 'line_section') and x._check_edi_line_tax_required()):
            //     if not line.tax_ids:
            //         return {'tax_on_line': _("Each invoice line should have at least one tax.")}
            // return {}
            */
            return default;
        }

        public async Task<TEntity> IsDocumentAllowanceChargeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py) ---
            // def _is_document_allowance_charge(self, base_line):
            // """ Whether the base line should be treated as a document-level AllowanceCharge. """
            // return base_line['special_type'] == 'early_payment'
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
            // basis_qty = float(self._find_value(xpath_dict['basis_qty'], tree) or 1)
            // 
            // # gross_price_unit (optional)
            // gross_price_unit = None
            // gross_price_unit_node = tree.find(xpath_dict['gross_price_unit'])
            // if gross_price_unit_node is not None:
            //     gross_price_unit = float(gross_price_unit_node.text)
            // 
            // # rebate (optional)
            // # Discount. /!\ as no percent discount can be set on a line, need to infer the percentage
            // # from the amount of the actual amount of the discount (the allowance charge)
            // rebate = 0
            // rebate_node = tree.find(xpath_dict['rebate'])
            // net_price_unit_node = tree.find(xpath_dict['net_price_unit'])
            // if rebate_node is not None:
            //     rebate = float(rebate_node.text)
            // elif net_price_unit_node is not None and gross_price_unit_node is not None:
            //     rebate = float(gross_price_unit_node.text) - float(net_price_unit_node.text)
            // 
            // # net_price_unit (mandatory)
            // net_price_unit = None
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
            // if product and product_uom and product_uom.category_id != product.product_tmpl_id.uom_id.category_id:
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
            // # Charges are collected (they are used to create new lines), Allowances are transformed into discounts
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
            // if delivered_qty * price_unit != 0 and price_subtotal is not None:
            //     currency = self.env.company.currency_id
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

        public async Task<TEntity> RetrieveTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object line_values, object tax_type) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py) ---
            // def _retrieve_taxes(self, record, line_values, tax_type):
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