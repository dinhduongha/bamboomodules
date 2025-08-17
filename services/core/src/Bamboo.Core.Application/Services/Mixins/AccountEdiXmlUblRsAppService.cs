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
    [Module("l10n_rs_edi", Depends = new[] { "account_edi_ubl_cii", "l10n_rs" })]
    public class AccountEdiXmlUblRsAppService : ApplicationService, IAccountEdiXmlUblRsAppService
    {

        public AccountEdiXmlUblRsAppService() 
        {

        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblRsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals'].update({
            //     'customization_id': self._get_customization_ids()['efaktura_rs'],
            //     'billing_reference_vals': self._l10n_rs_get_billing_reference(invoice),
            // })
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetCustomizationIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblRsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_customization_ids(self):
            // vals = super()._get_customization_ids()
            // vals['efaktura_rs'] = 'urn:cen.eu:en16931:2017#compliant#urn:mfin.gov.rs:srbdt:2022#conformant#urn:mfin.gov.rs:srbdtext:2022'
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePeriodValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblRsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_invoice_period_vals_list(self, invoice):
            // # EXTENDS account_edi_ubl_cii
            // vals_list = super()._get_invoice_period_vals_list(invoice)
            // vals_list.append({
            //     'description_code': '0' if invoice.move_type == 'out_refund' else invoice.l10n_rs_tax_date_obligations_code,
            // })
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyIdentificationValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblRsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_partner_party_identification_vals_list(self, partner):
            // vals_list = super()._get_partner_party_identification_vals_list(partner)
            // if partner.country_code == 'RS' and partner.l10n_rs_edi_public_funds:
            //     vals_list.append({
            //         'id': f'JBKJS: {partner.l10n_rs_edi_public_funds}',
            //     })
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblRsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals_list = super()._get_partner_party_legal_entity_vals_list(partner)
            // for vals in vals_list:
            //     vals['company_id'] = partner.l10n_rs_edi_registration_number
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblRsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // # EXTENDS 'account_edi_ubl_cii'
            // vals_list = super()._get_partner_party_tax_scheme_vals_list(partner, role)
            // 
            // for vals in vals_list:
            //     vat_country, vat_number = partner._split_vat(partner.vat)
            //     if vat_country.isnumeric():
            //         vat_country = 'RS'
            //         vat_number = partner.vat
            //     if vat_country == 'RS' and partner.simple_vat_check(vat_country, vat_number):
            //         vals['company_id'] = vat_country + vat_number
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblRsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // vals = super()._get_partner_party_vals(partner, role)
            // vat_country, vat_number = partner._split_vat(partner.vat)
            // if vat_country.isnumeric():
            //     vat_number = partner.vat
            // vals.update({
            //     'endpoint_id': vat_number,
            //     'endpoint_id_attrs': {
            //         'schemeID': '9948',
            //     },
            // })
            // return vals
            */
            return default;
        }

        public async Task<TEntity> L10nRsGetBillingReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblRsable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_rs_edi, FILE: account_edi_xml_ubl_21_rs.py) ---
            // def _l10n_rs_get_billing_reference(self, invoice):
            // # Billing Reference values for Credit Note
            // if invoice.move_type == 'out_refund' and invoice.reversed_entry_id:
            //     return {
            //         'id': invoice.reversed_entry_id.name,
            //         'issue_date': invoice.reversed_entry_id.invoice_date,
            //     }
            // return {}
            */
            return default;
        }
    }
}