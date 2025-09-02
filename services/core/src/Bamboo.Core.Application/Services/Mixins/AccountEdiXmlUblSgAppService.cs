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
    public class AccountEdiXmlUblSgAppService : ApplicationService, IAccountEdiXmlUblSgAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiXmlUblSgAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'eu.peppol.bis3.sg.ubl:invoice:1.0.3',
            //     'credit_note': 'eu.peppol.bis3.sg.ubl:creditnote:1.0.3',
            // }
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _export_invoice_filename(self, invoice):
            // return f"{invoice.name.replace('/', '_')}_sg.xml"
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._export_invoice_vals(invoice)
            // 
            // vals['vals'].update({
            //     'customization_id': self._get_customization_ids()['ubl_sg'],
            // })
            // 
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePaymentMeansValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _get_invoice_payment_means_vals_list(self, invoice):
            // """ https://www.peppolguide.sg/billing/bis/#_payment_means_information
            // """
            // vals_list = super()._get_invoice_payment_means_vals_list(invoice)
            // for vals in vals_list:
            //     vals.update({
            //         'payment_means_code': 54,
            //         'payment_means_code_attrs': {'name': 'Credit Card'},
            //     })
            // 
            // return vals_list
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
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

        public async Task<TEntity> GetTaxCategoryListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object taxes) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _get_tax_category_list(self, customer, supplier, taxes):
            // # OVERRIDE
            // res = []
            // for tax in taxes:
            //     res.append({
            //         'id': self._get_tax_sg_codes(tax),
            //         'percent': tax.amount if tax.amount_type == 'percent' else False,
            //         'tax_scheme_vals': {'id': 'GST'},
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetTaxSgCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax) where TEntity : IEntity<Guid>, IAccountEdiXmlUblSgable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_sg.py) ---
            // def _get_tax_sg_codes(self, tax):
            // """ https://www.peppolguide.sg/billing/bis/#_gst_category_codes
            // """
            // tax_category_code = 'SR'
            // if tax.amount == 0:
            //     tax_category_code = 'ZR'
            // return tax_category_code
            */
            return default;
        }
    }
}