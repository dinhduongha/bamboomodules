using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("account_edi_ubl_cii", Depends = new[] { "account" })]
    public class AccountEdiXmlUblANzAppService : ApplicationService, IAccountEdiXmlUblANzAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiXmlUblANzAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'eu.peppol.bis3.aunz.ubl:invoice:1.0.8',
            //     'credit_note': 'eu.peppol.bis3.aunz.ubl:creditnote:1.0.8',
            // }
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

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
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
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
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
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
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
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
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
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUblANzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_a_nz.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // for vals in vals_list:
            //     vals['tax_scheme_vals'] = {'id': 'GST'}
            // return vals_list
            */
            return default;
        }
    }
}