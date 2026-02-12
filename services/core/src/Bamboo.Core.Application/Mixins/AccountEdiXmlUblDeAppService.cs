using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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

        public AccountEdiXmlUblDeAppService() 
        {

        }

        public async Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _add_invoice_header_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _add_invoice_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _export_invoice_constraints) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _export_invoice_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomizationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object process_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _get_customization_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _get_party_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _ubl_add_values_tax_currency_code) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiXmlUblDeable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_xrechnung.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            */
            return default;
        }
    }
}