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
    public class AccountEdiXmlUblANzAppService : ApplicationService, IAccountEdiXmlUblANzAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiXmlUblANzAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _add_invoice_tax_total_nodes(self, document_node, vals):
            // # OVERRIDE
            // document_node['cac:TaxTotal'] = [
            //     self._ubl_get_tax_total_node(vals, tax_total)
            //     for tax_total in vals['_ubl_values']['tax_totals_currency'].values()
            // ]
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_a_nz.xml"
            */
            return default;
        }

        public async Task<TEntity> GetCustomizationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object process_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _get_customization_id(self, process_type='billing'):
            // if process_type == 'billing':
            //     return 'urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:aunz:3.0'
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
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
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _ubl_add_values_tax_currency_code(self, vals):
            // # OVERRIDE account.edi.xml.ubl_bis3
            // self._ubl_add_values_tax_currency_code_empty(vals)
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data, object vals, object currency) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
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
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
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
            */
            return default;
        }
    }
}