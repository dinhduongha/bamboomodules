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
    public partial class AccountEdiXmlUblDeAppService : ApplicationService, IAccountEdiXmlUblDeAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiXmlUblDeAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _add_invoice_header_nodes(self, document_node, vals):
            // # EXTENDS account.edi.xml.ubl_bis3
            // super()._add_invoice_header_nodes(document_node, vals)
            // if not document_node['cbc:BuyerReference']['_text']:
            //     document_node['cbc:BuyerReference']['_text'] = 'N/A'
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
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

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
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

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_ubl_de.xml"
            */
            return default;
        }

        public async Task<TEntity> GetCustomizationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object process_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _get_customization_id(self, process_type='billing'):
            // if process_type == 'billing':
            //     return 'urn:cen.eu:en16931:2017#compliant#urn:xeinkauf.de:kosit:xrechnung_3.0'
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
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

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _ubl_add_values_tax_currency_code(self, vals):
            // # OVERRIDE account.edi.xml.ubl_bis3
            // self._ubl_add_values_tax_currency_code_empty(vals)
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
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