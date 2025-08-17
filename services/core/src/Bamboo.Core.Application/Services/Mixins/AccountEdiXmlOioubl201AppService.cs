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
    [Module("l10n_dk_oioubl", Depends = new[] { "account_edi_ubl_cii", "l10n_dk" })]
    public class AccountEdiXmlOioubl201AppService : ApplicationService, IAccountEdiXmlOioubl201AppService
    {

        public AccountEdiXmlOioubl201AppService() 
        {

        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _export_invoice_constraints(self, invoice, vals):
            // # EXTENDS account.edi.xml.ubl_20
            // constraints = super()._export_invoice_constraints(invoice, vals)
            // 
            // for partner_type in ('supplier', 'customer'):
            //     partner = vals[partner_type]
            //     building_number = tools.street_split(partner.street).get('street_number')
            //     if not building_number:
            //         constraints[f"oioubl201_{partner_type}_building_number_required"] = \
            //                 _("The following partner's street number is missing: %s", partner.display_name)
            //     if partner.country_code == "FR" and not partner.commercial_partner_id.company_registry:
            //         constraints["oioubl201_company_registry_required_for_french_partner"] = \
            //                 _("The company registry is required for french partner: %s", partner.display_name)
            //     constraints[f'oioubl201_{partner_type}_vat_required'] = self._check_required_fields(partner.commercial_partner_id, 'vat')
            // 
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'org.oasis-open:invoice:2.0',
            //     'credit_note': 'org.oasis-open:creditnote:2.0',
            // }
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_oioubl_201.xml"
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_20
            // vals = super()._export_invoice_vals(invoice)
            // vals['PaymentTermsType_template'] = 'l10n_dk_oioubl.oioubl_PaymentTermsType'
            // if self.env.ref('l10n_dk_oioubl.oioubl_PaymentMeansType', raise_if_not_found=False):
            //     vals['PaymentMeansType_template'] = 'l10n_dk_oioubl.oioubl_PaymentMeansType'
            // else:
            //     module = self.env['ir.module.module']._get('l10n_dk_oioubl')
            //     module_url = f"/web#id={module.id}&model={module._name}&view_type=form"
            //     message = _("The payment method in the generated XML may be incorrect. Please update the following module ")
            //     message += Markup("<a href='%s' style='color:#017e84; font-weight: bold;'>(%s)</a>") % (module_url, _("Denmark E-Invoicing"))
            //     invoice.message_post(body=message)
            // vals['vals'].update({
            //     'customization_id': 'OIOUBL-2.01',
            //     # ProfileID is the property that define which documents the company can send and receive
            //     # 'Procurement-BilSim-1.0' is the simplest one: invoice and bill
            //     # https://www.oioubl.info/documents/en/en/Guidelines/OIOUBL_GUIDE_PROFILES.pdf
            //     'profile_id': 'Procurement-BilSim-1.0',
            //     'profile_id_attrs': {
            //         'schemeID': 'urn:oioubl:id:profileid-1.6',
            //         'schemeAgencyID': DANISH_NATIONAL_IT_AND_TELECOM_AGENCY_ID,
            //     }
            // })
            // vals['vals'].setdefault('document_type_code_attrs', {}).update({
            //     'listID': 'urn:oioubl:codelist:invoicetypecode-1.2',
            //     'listAgencyID': DANISH_NATIONAL_IT_AND_TELECOM_AGENCY_ID,
            // })
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyDecimalPlacesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid currency_id) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_currency_decimal_places(self, currency_id):
            // # OIOUBL needs the data to be formated to 2 decimals
            // return 2
            */
            return default;
        }

        public async Task<TEntity> GetDocumentTypeCodeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_document_type_code_vals(self, invoice, invoice_data):
            // # EXTENDS 'account_edi_ubl_cii
            // # http://www.datypic.com/sc/ubl20/e-cbc_DocumentTypeCode.html
            // vals = super()._get_document_type_code_vals(invoice, invoice_data)
            // vals['value'] = "380" if invoice.move_type == 'out_invoice' else "381"
            // vals['attrs']['listAgencyID'] = "6"
            // vals['attrs']['listID'] = "UN/ECE 1001"
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals, object line_extension_amount, object allowance_total_amount, object charge_total_amount) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_invoice_monetary_total_vals(self, invoice, taxes_vals, line_extension_amount, allowance_total_amount, charge_total_amount):
            // # EXTENDS account.edi.xml.ubl_20
            // vals = super()._get_invoice_monetary_total_vals(invoice, taxes_vals, line_extension_amount, allowance_total_amount, charge_total_amount)
            // # In OIOUBL context, tax_exclusive_amount means "tax only"
            // vals['tax_exclusive_amount'] = taxes_vals['tax_amount_currency']
            // if invoice.currency_id.is_zero(vals['prepaid_amount']):
            //     del vals['prepaid_amount']
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // # EXTENDS account.edi.xml.ubl_20
            // vals_list = super()._get_invoice_payment_means_vals_list(invoice)
            // for vals in vals_list:
            //     # Hardcoded 'unknown' for now
            //     # Later on, it would be nice to create a dynamically selected template that would depends on the payment means
            //     vals['payment_means_code'] = PAYMENT_MEANS_CODE['unknown']
            // 
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentTermsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_invoice_payment_terms_vals_list(self, invoice):
            // # OVERRIDES 'account_edi_ubl_cii'
            // if not invoice.invoice_payment_term_id:
            //     return []
            // 
            // sign = 1 if invoice.is_inbound(include_receipts=True) else -1
            // return [
            //     {
            //         'id': line.id,
            //         'amount': sign * line.amount_currency,
            //         'currency_name': line.currency_id.name,
            //         'currency_dp': self._get_currency_decimal_places(line.currency_id),
            //         'note_vals': [{'note_vals': [{'note': html2plaintext(invoice.invoice_payment_term_id.note)}]}],
            //         'settlement_period': {
            //             'start_date': invoice.invoice_date,
            //             'end_date': line.date_maturity,
            //         }
            //     }
            //     for line in invoice.line_ids.filtered(lambda line: line.display_type == 'payment_term').sorted('date_maturity')
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTaxTotalsValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object taxes_vals) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_invoice_tax_totals_vals_list(self, invoice, taxes_vals):
            // # EXTENDS account.edi.xml.ubl_20
            // vals_list = super()._get_invoice_tax_totals_vals_list(invoice, taxes_vals)
            // for tax_total_vals in vals_list:
            //     for subtotal_vals in tax_total_vals.get('tax_subtotal_vals', []):
            //         # https://www.oioubl.info/Classes/en/TaxSubtotal.html
            //         # No 'percent' node in OIOUBL
            //         subtotal_vals.pop('percent', None)
            // 
            //         # TaxCategory https://www.oioubl.info/Classes/en/TaxCategory.html
            //         subtotal_vals['tax_category_vals']['id_attrs'] = {
            //             'schemeID': 'urn:oioubl:id:taxcategoryid-1.3',
            //             'schemeAgencyID': DANISH_NATIONAL_IT_AND_TELECOM_AGENCY_ID,
            //         }
            // 
            //         # TaxCategory id list: https://www.oioubl.info/codelists/en/urn_oioubl_id_taxcategoryid-1.1.html
            //         # The condition prevents the value to be mapped again when the methods is run several time
            //         if subtotal_vals['tax_category_vals']['id'] not in TAX_POSSIBLE_VALUES:
            //             subtotal_vals['tax_category_vals']['id'] = UBL_TO_OIOUBL_TAX_CATEGORY_ID_MAPPING.get(subtotal_vals['tax_category_vals']['id'])
            // 
            //         subtotal_vals['tax_category_vals']['tax_scheme_vals']['name'] = 'VAT'
            //         subtotal_vals['tax_category_vals']['tax_scheme_vals']['id_attrs'] = {'schemeID': 'urn:oioubl:id:taxschemeid-1.5'}
            // 
            //         # /Invoice[1]/cac:TaxTotal[1]/cac:TaxSubtotal[1]/cac:TaxCategory[1]
            //         # [W-LIB230] Name should only be used within NES profiles
            //         # (cbc:Name != '') and not(contains(/doc:Invoice/cbc:ProfileID, 'nesubl.eu'))
            //         if 'name' in subtotal_vals['tax_category_vals']:
            //             del subtotal_vals['tax_category_vals']['name']
            // 
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_partner_address_vals(self, partner):
            // # EXTENDS account.edi.xml.ubl_20
            // vals = super()._get_partner_address_vals(partner)
            // # https://www.oioubl.info/Classes/en/Address.html
            // address = tools.street_split(partner.street)
            // street_name = address.get('street_name')
            // building_number = address.get('street_number')
            // vals.update({
            //     # could be 'UN/CEFACT codeliste 3477' instead of StructuredDK' for partner out of DK
            //     # not implemented yet because `StructuredDK` seems more than enough
            //     'address_format_code': 'StructuredDK',
            //     'address_format_code_attrs': {
            //         'listAgencyID': DANISH_NATIONAL_IT_AND_TELECOM_AGENCY_ID,
            //         'listID': 'urn:oioubl:codelist:addressformatcode-1.1',
            //     },
            //     'street_name': street_name,
            //     'building_number': building_number,
            // })
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyLegalEntityValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_partner_party_legal_entity_vals_list(self, partner):
            // # EXTENDS account.edi.xml.ubl_20
            // vals_list = super()._get_partner_party_legal_entity_vals_list(partner)
            // vat = format_vat_number(partner)
            // schemeID = 'DK:CVR' if vat[:2] == 'DK' else 'ZZZ'
            // for vals in vals_list:
            //     vals.update({
            //         'company_id': vat,
            //         'company_id_attrs': {'schemeID': schemeID},
            //     })
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyTaxSchemeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_partner_party_tax_scheme_vals_list(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_20
            // vals_list = super()._get_partner_party_tax_scheme_vals_list(partner, role)
            // vat = format_vat_number(partner)
            // schemeID = 'DK:SE' if vat[:2] == 'DK' else 'ZZZ'
            // for vals in vals_list:
            //     if partner.vat:
            //         # SE is the danish vat number
            //         # DK:SE indicates we're using it and 'ZZZ' is for international number
            //         # https://www.oioubl.info/Codelists/en/urn_oioubl_scheme_partytaxschemecompanyid-1.1.html
            //         vals.update({
            //             'company_id_attrs': {'schemeID': schemeID},
            //             'company_id': vat,
            //         })
            // 
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_20
            // """ The scheme_id needs to be in letters and the VAT number (if there is one) should be preceded by 2 letters"""
            // vals = super()._get_partner_party_vals(partner, role)
            // if partner.peppol_endpoint and partner.peppol_eas in EAS_SCHEME_ID_MAPPING:
            //     # if we don't know the mapping with real names for the Peppol Endpoint, fallback on VAT simply
            //     endpoint_id = partner.peppol_endpoint
            //     scheme_id = EAS_SCHEME_ID_MAPPING[partner.peppol_eas]
            //     if (scheme_id in ('DK:CVR', 'FR:SIRET') or scheme_id[3:] == 'VAT') and endpoint_id.isnumeric():
            //         endpoint_id = scheme_id[:2] + endpoint_id
            // else:
            //     endpoint_id = format_vat_number(partner)
            //     country_code = endpoint_id[:2]
            //     match country_code:
            //         case 'DK':
            //             scheme_id = 'DK:CVR'
            //         case 'FR':
            //             scheme_id = 'FR:SIRET'
            //             # SIRET is the french company registry
            //             endpoint_id = (partner.company_registry or "").replace(" ", "")
            //         case _:
            //             scheme_id = f'{country_code}:VAT'
            // 
            // vals.update({
            //     # list of possible endpointID available at
            //     # https://www.oioubl.info/documents/en/en/Guidelines/OIOUBL_GUIDE_ENDPOINT.pdf
            //     'endpoint_id': endpoint_id,
            //     'endpoint_id_attrs': {'schemeID': scheme_id},
            // })
            // for party_tax_scheme in vals['party_tax_scheme_vals']:
            //     # the doc says it could be empty but the schematron says otherwise
            //     # https://www.oioubl.info/Classes/en/TaxScheme.html
            //     party_tax_scheme.update({
            //         'tax_scheme_vals': {
            //             'id': 'VAT',
            //             'id_attrs': {'schemeID': 'urn:oioubl:id:taxschemeid-1.5'},
            //             'name': 'VAT',
            //         },
            //     })
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlOioubl201able
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: l10n_dk_oioubl, FILE: account_edi_xml_oioubl_201.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS account.edi.common
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // for vals in vals_list:
            //     # TaxCategory https://www.oioubl.info/Classes/en/TaxCategory.html
            //     vals['id'] = UBL_TO_OIOUBL_TAX_CATEGORY_ID_MAPPING.get(vals['id'])
            //     vals['id_attrs'] = {
            //         'schemeID': 'urn:oioubl:id:taxcategoryid-1.3',
            //         'schemeAgencyID': DANISH_NATIONAL_IT_AND_TELECOM_AGENCY_ID,
            //     }
            //     vals['tax_scheme_vals']['id_attrs'] = {'schemeID': 'urn:oioubl:id:taxschemeid-1.5'}
            //     vals['tax_scheme_vals']['name'] = 'VAT'
            //     # OIOUBL can't contain name for category
            //     # /Invoice[1]/cac:InvoiceLine[1]/cac:Item[1]/cac:ClassifiedTaxCategory[1]
            //     # [W-LIB230] Name should only be used within NES profiles
            //     # (cbc:Name != '') and not(contains(/doc:Invoice/cbc:ProfileID, 'nesubl.eu'))
            //     if 'name' in vals:
            //         del vals['name']
            // 
            // return vals_list
            */
            return default;
        }
    }
}