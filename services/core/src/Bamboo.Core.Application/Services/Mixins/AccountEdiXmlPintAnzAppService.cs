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
    [Module("l10n_anz_ubl_pint", Depends = new[] { "account_edi_ubl_cii_tax_extension" })]
    public class AccountEdiXmlPintAnzAppService : ApplicationService, IAccountEdiXmlPintAnzAppService
    {

        public AccountEdiXmlPintAnzAppService() 
        {

        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlPintAnzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: account_edi_xml_pint_anz.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // # EXTENDS account_edi_ubl_cii
            // constraints = super()._export_invoice_constraints(invoice, vals)
            // 
            // # Tax category must be filled on the line, with a value from SG categories.
            // for tax_total_val in vals['vals']['tax_total_vals']:
            //     for tax_subtotal_val in tax_total_val.get('tax_subtotal_vals', ()):
            //         if tax_subtotal_val['tax_category_vals']['tax_category_code'] not in ANZ_TAX_CATEGORIES:
            //             constraints['sg_vat_category_required'] = _("You must set a tax category on each taxes of the invoice.\nValid categories are: S, E, Z, G, O")
            // 
            // # ALIGNED-IBR-001-AUNZ and ALIGNED-IBR-002-AUNZ
            // for partner_type in ('supplier', 'customer'):
            //     partner = vals[partner_type]
            //     if partner.country_code == 'AU' and partner.peppol_eas != '0151':
            //         constraints[f'au_{partner_type}_eas_0151'] = _("The Peppol EAS must be set to ABN (0151) if the partner country is Australia.")
            //     elif partner.country_code == 'NZ' and partner.peppol_eas != '0088':
            //         constraints[f'nz_{partner_type}_eas_0088'] = _("The Peppol EAS must be set to EAN (0088) if the partner country is New Zealand.")
            // 
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlPintAnzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: account_edi_xml_pint_anz.py) ---
            // def _export_invoice_filename(self, invoice):
            // # EXTENDS account_edi_ubl_cii
            // return f"{invoice.name.replace('/', '_')}_pint_anz.xml"
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlPintAnzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: account_edi_xml_pint_anz.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account_edi_ubl_cii
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals'].update({
            //     # see https://docs.peppol.eu/poac/aunz/pint-aunz/bis/#_identifying_the_a_nz_billing_specialisation
            //     'customization_id': self._get_customization_ids()['pint_anz'],
            //     'profile_id': 'urn:peppol:bis:billing',
            // })
            // 
            // if invoice.currency_id != invoice.company_id.currency_id:
            //     # see https://docs.peppol.eu/poac/aunz/pint-aunz/bis/#_tax_in_accounting_currency
            //     vals['vals']['tax_currency_code'] = invoice.company_id.currency_id.name  # accounting currency
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetCustomizationIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlPintAnzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: account_edi_xml_pint_anz.py) ---
            // def _get_customization_ids(self):
            // vals = super()._get_customization_ids()
            // vals['pint_anz'] = 'urn:peppol:pint:billing-1@aunz-1'
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlPintAnzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: account_edi_xml_pint_anz.py) ---
            // def _get_invoice_tax_totals_vals_list(self, invoice, taxes_vals):
            // vals_list = super()._get_invoice_tax_totals_vals_list(invoice, taxes_vals)
            // company_currency = invoice.company_id.currency_id
            // if invoice.currency_id != company_currency:
            //     # if company currency != invoice currency, need to add a TaxTotal section
            //     # see https://docs.peppol.eu/poac/aunz/pint-aunz/bis/#_tax_in_accounting_currency
            //     tax_totals_vals = {
            //         'currency': company_currency,
            //         'currency_dp': company_currency.decimal_places,
            //         'tax_amount': taxes_vals['tax_amount'],
            //     }
            //     vals_list.append(tax_totals_vals)
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlPintAnzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: account_edi_xml_pint_anz.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_partner_party_legal_entity_vals_list(partner)
            // 
            // for vals in vals_list:
            //     # In both case the scheme must be set to a value that comes from the eas.
            //     if partner.country_code in ('AU', 'NZ'):
            //         vals['company_id_attrs'] = {'schemeID': partner.peppol_eas}
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlPintAnzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: account_edi_xml_pint_anz.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._get_partner_party_vals(partner, role)
            // 
            // for party_tax_scheme in vals['party_tax_scheme_vals']:
            //     party_tax_scheme['tax_scheme_vals'] = {'id': 'GST'}
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlPintAnzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: account_edi_xml_pint_anz.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS account_edi_ubl_cii
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // for vals in vals_list:
            //     vals['tax_scheme_vals'] = {'id': 'GST'}
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetTaxUneceCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiXmlPintAnzable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_anz_ubl_pint, FILE: account_edi_xml_pint_anz.py) ---
            // def _get_tax_unece_codes(self, customer, supplier, tax):
            // """ The GST category must be provided in the file.
            // See https://docs.peppol.eu/poac/aunz/pint-aunz/bis/#_tax_category_code
            // """
            // # OVERRIDE account_edi_ubl_cii
            // if not supplier.vat:
            //     return {
            //         'tax_category_code': 'O',
            //         'tax_exemption_reason_code': False,
            //         'tax_exemption_reason': False,
            //     }  # a business is not registered for GST, the business cannot issue tax invoices. In this case, the GST category code should be O (Outside scope of tax).
            // return super()._get_tax_unece_codes(customer, supplier, tax)
            */
            return default;
        }
    }
}