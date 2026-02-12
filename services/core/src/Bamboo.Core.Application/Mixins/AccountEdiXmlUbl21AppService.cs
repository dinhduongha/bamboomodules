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
    public partial class AccountEdiXmlUbl21AppService : ApplicationService, IAccountEdiXmlUbl21AppService
    {

        public AccountEdiXmlUbl21AppService() 
        {

        }

        public async Task<TEntity> AddDocumentAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py, METHOD: _add_document_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_document_currency_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py, METHOD: _add_document_line_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_config_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_delivery_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py, METHOD: _add_invoice_header_nodes) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_header_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_amount_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_item_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePeriodNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py, METHOD: _add_invoice_line_period_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_price_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_tax_category_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_monetary_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_monetary_total_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoicePaymentMeansNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_payment_means_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _add_invoice_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> CanExportSelfbillingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _can_export_selfbilling) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _export_invoice_constraints) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py, METHOD: _export_invoice_filename) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _export_invoice_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_address_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomizationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object process_type) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_customization_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetFinancialAccountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_financial_account_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_21.py, METHOD: _get_invoice_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_line_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _get_party_node) ---
            */
            return default;
        }

        public async Task<TEntity> ImportOrderPaymentTermsIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object tree, object xpath) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _import_order_payment_terms_id) ---
            */
            return default;
        }

        public async Task<TEntity> ImportOrderUblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object file_data, object @new) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _import_order_ubl) ---
            */
            return default;
        }

        public async Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _import_retrieve_partner_vals) ---
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsCenEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _invoice_constraints_cen_en16931_ubl) ---
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsPeppolEn16931UblInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _invoice_constraints_peppol_en16931_ubl) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsCustomerBehindChorusProInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _is_customer_behind_chorus_pro) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveOrderValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object tree) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _retrieve_order_vals) ---
            */
            return default;
        }

        public async Task<TEntity> SetupBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _setup_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxSubtotalTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiXmlUbl21able
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_bis3.py, METHOD: _ubl_default_tax_subtotal_tax_category_grouping_key) ---
            */
            return default;
        }
    }
}