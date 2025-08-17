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
    [Module("l10n_sg_ubl_pint", Depends = new[] { "account_edi_ubl_cii_tax_extension" })]
    public class AccountEdiXmlPintSgAppService : ApplicationService, IAccountEdiXmlPintSgAppService
    {

        public AccountEdiXmlPintSgAppService() 
        {

        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlPintSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sg_ubl_pint, FILE: account_edi_xml_pint_sg.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // # EXTENDS account_edi_ubl_cii
            // constraints = super()._export_invoice_constraints(invoice, vals)
            // 
            // # Tax category must be filled on the line, with a value from SG categories.
            // for tax_total_val in vals['vals']['tax_total_vals']:
            //     for tax_subtotal_val in tax_total_val.get('tax_subtotal_vals', ()):
            //         if tax_subtotal_val['tax_category_vals']['tax_category_code'] not in SG_TAX_CATEGORIES:
            //             constraints['sg_vat_category_required'] = _("You must set a Singaporean tax category on each taxes of the invoice.")
            // 
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlPintSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sg_ubl_pint, FILE: account_edi_xml_pint_sg.py) ---
            // def _export_invoice_filename(self, invoice):
            // # OVERRIDE account_edi_ubl_cii
            // return f"{invoice.name.replace('/', '_')}_pint_sg.xml"
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlPintSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sg_ubl_pint, FILE: account_edi_xml_pint_sg.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account_edi_ubl_cii
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals'].update({
            //     # see https://docs.peppol.eu/poac/sg/2024-Q2/pint-sg/bis/#_bis_identifiers
            //     'customization_id': self._get_customization_ids()['pint_sg'],
            //     'profile_id': 'urn:peppol:bis:billing',
            //     'uuid': invoice._l10n_sg_get_uuid(),
            // })
            // 
            // if invoice.currency_id != invoice.company_id.currency_id:
            //     # see https://docs.peppol.eu/poac/sg/2024-Q2/pint-sg/bis/#_invoice_totals_in_gst_accounting_currency
            //     vals['vals']['tax_currency_code'] = invoice.company_id.currency_id.name  # accounting currency
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetAdditionalDocumentReferenceListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlPintSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sg_ubl_pint, FILE: account_edi_xml_pint_sg.py) ---
            // def _get_additional_document_reference_list(self, invoice):
            // # EXTENDS account.edi.xml.ubl_20
            // additional_document_reference_list = super()._get_additional_document_reference_list(invoice)
            // if invoice.currency_id != invoice.company_id.currency_id:
            //     amounts_in_accounting_currency = (
            //         ('sgdtotal-excl-gst', invoice.amount_untaxed_signed),
            //         ('sgdtotal-incl-gst', invoice.amount_total_signed),
            //     )
            //     # [BR-53-GST-SG]-If the GST accounting currency code (BT-6-GST) is present, then the Invoice total GST amount (BT-111-GST),
            //     # Invoice total including GST amount and Invoice Total excluding GST amount in accounting currency shall be provided.
            //     additional_document_reference_list.extend([{
            //         'id': invoice.company_id.currency_id.name,
            //         'document_description': amount,
            //         'document_type_code': code,
            //     } for code, amount in amounts_in_accounting_currency])
            // return additional_document_reference_list
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlPintSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sg_ubl_pint, FILE: account_edi_xml_pint_sg.py) ---
            // def _get_invoice_tax_totals_vals_list(self, invoice, taxes_vals):
            // # EXTENDS account_edi_ubl_cii
            // vals_list = super()._get_invoice_tax_totals_vals_list(invoice, taxes_vals)
            // company_currency = invoice.company_id.currency_id
            // if invoice.currency_id != company_currency:
            //     # if company currency != invoice currency, need to add a TaxTotal section
            //     # see https://docs.peppol.eu/poac/sg/2024-Q2/pint-sg/bis/#_invoice_totals_in_gst_accounting_currency
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

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlPintSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sg_ubl_pint, FILE: account_edi_xml_pint_sg.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // # EXTENDS account_edi_ubl_cii
            // vals = super()._get_partner_party_vals(partner, role)
            // 
            // for party_tax_scheme in vals['party_tax_scheme_vals']:
            //     party_tax_scheme['tax_scheme_vals'] = {'id': 'GST'}
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlPintSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_sg_ubl_pint, FILE: account_edi_xml_pint_sg.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS account_edi_ubl_cii
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // for vals in vals_list:
            //     vals['tax_scheme_vals'] = {'id': 'GST'}
            // return vals_list
            */
            return default;
        }
    }
}