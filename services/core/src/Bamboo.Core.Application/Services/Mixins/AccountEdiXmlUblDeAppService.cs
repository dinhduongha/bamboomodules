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
    public class AccountEdiXmlUblDeAppService : ApplicationService, IAccountEdiXmlUblDeAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountEdiXmlUblDeAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
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
            //     'bis3_de_supplier_telephone_required': self._check_required_fields(vals['supplier'], ['phone', 'mobile']),
            //     'bis3_de_supplier_electronic_mail_required': self._check_required_fields(vals['supplier'], 'email'),
            // })
            // 
            // return constraints
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _export_invoice_ecosio_schematrons(self):
            // return {
            //     'invoice': 'de.xrechnung:ubl-invoice:2.2.0',
            //     'credit_note': 'de.xrechnung:ubl-creditnote:2.2.0',
            // }
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

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _export_invoice_vals(self, invoice):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._export_invoice_vals(invoice)
            // vals['vals']['customization_id'] = self._get_customization_ids()['xrechnung']
            // if not vals['vals'].get('buyer_reference'):
            //     vals['vals']['buyer_reference'] = 'N/A'
            // return vals
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPartyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py) ---
            // def _get_partner_party_vals(self, partner, role):
            // # EXTENDS account.edi.xml.ubl_bis3
            // vals = super()._get_partner_party_vals(partner, role)
            // 
            // if not vals.get('endpoint_id') and partner.email:
            //     vals.update({
            //         'endpoint_id': partner.email,
            //         'endpoint_id_attrs': {'schemeID': 'EM'},
            //     })
            // 
            // return vals
            */
            return default;
        }
    }
}