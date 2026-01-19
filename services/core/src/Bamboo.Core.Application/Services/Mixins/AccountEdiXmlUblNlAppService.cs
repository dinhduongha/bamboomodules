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
    public partial class AccountEdiXmlUblNlAppService : ApplicationService, IAccountEdiXmlUblNlAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiXmlUblNlAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AddInvoicePaymentMeansNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
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
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _add_invoice_tax_total_nodes(self, document_node, vals):
            // # OVERRIDE
            // document_node['cac:TaxTotal'] = [
            //     self._ubl_get_tax_total_node(vals, tax_total)
            //     for tax_total in vals['_ubl_values']['tax_totals_currency'].values()
            // ]
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_nlcius.xml"
            */
            return default;
        }

        public async Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
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

        public async Task<TEntity> GetCustomizationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object process_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_customization_id(self, process_type='billing'):
            // if process_type == 'billing':
            //     return 'urn:cen.eu:en16931:2017#compliant#urn:fdc:nen.nl:nlcius:v1.0'
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _ubl_add_values_tax_currency_code(self, vals):
            // # OVERRIDE account.edi.xml.ubl_bis3
            // self._ubl_add_values_tax_currency_code_empty(vals)
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data, object vals, object currency) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _ubl_default_tax_category_grouping_key(self, base_line, tax_data, vals, currency):
            // # EXTENDS account.edi.xml.ubl_bis3
            // grouping_key = super()._ubl_default_tax_category_grouping_key(base_line, tax_data, vals, currency)
            // if not grouping_key:
            //     return
            // 
            // grouping_key['tax_exemption_reason_code'] = None
            // return grouping_key
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _ubl_get_line_allowance_charge_discount_node(self, vals, discount_values):
            // # EXTENDS account.edi.xml.ubl_bis3
            // discount_node = super()._ubl_get_line_allowance_charge_discount_node(vals, discount_values)
            // discount_node['cbc:AllowanceChargeReasonCode'] = None
            // discount_node['cbc:MultiplierFactorNumeric'] = None
            // discount_node['cbc:BaseAmount'] = None
            // return discount_node
            */
            return default;
        }
    }
}