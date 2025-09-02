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
    public class AccountEdiXmlUblNlAppService : ApplicationService, IAccountEdiXmlUblNlAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiXmlUblNlAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'org.simplerinvoicing:invoice:2.0.3.3',
            //     'credit_note': 'org.simplerinvoicing:creditnote:2.0.3.3',
            // }
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

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals']['customization_id'] = self._get_customization_ids()['nlcius']
            // 
            // # [BR-NL-24] Use of previous invoice date ( IssueDate ) is not recommended.
            // # vals['vals'].pop('issue_date')  # careful, this causes other errors from the validator...
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineAllowanceValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object tax_values_list) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_invoice_line_allowance_vals_list(self, line, tax_values_list=None):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_invoice_line_allowance_vals_list(line, tax_values_list=tax_values_list)
            // # [BR-NL-32] Use of Discount reason code ( AllowanceChargeReasonCode ) is not recommended.
            // # [BR-EN-34] Use of Charge reason code ( AllowanceChargeReasonCode ) is not recommended.
            // # Careful! [BR-42]-Each Invoice line allowance (BG-27) shall have an Invoice line allowance reason (BT-139)
            // # or an Invoice line allowance reason code (BT-140).
            // for vals in vals_list:
            //     if vals.get('allowance_charge_reason'):
            //         vals.pop('allowance_charge_reason_code')
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_invoice_payment_means_vals_list(invoice)
            // # [BR-NL-29] The use of a payment means text (cac:PaymentMeans/cbc:PaymentMeansCode/@name) is not recommended
            // for vals in vals_list:
            //     vals.pop('payment_means_code_attrs', None)
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerAddressValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_partner_address_vals(self, partner):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._get_partner_address_vals(partner)
            // # [BR-NL-28] The use of a country subdivision (cac:AccountingCustomerParty/cac:Party/cac:PostalAddress
            // # /cbc:CountrySubentity) is not recommended
            // vals.pop('country_subentity', None)
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUblNlable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_nlcius.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals_list = super()._get_tax_category_list(customer, supplier, taxes)
            // for tax in vals_list:
            //     # [BR-NL-35] The use of a tax exemption reason code (cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory
            //     # /cbc:TaxExemptionReasonCode) is not recommended
            //     tax.pop('tax_exemption_reason_code', None)
            // return vals_list
            */
            return default;
        }
    }
}