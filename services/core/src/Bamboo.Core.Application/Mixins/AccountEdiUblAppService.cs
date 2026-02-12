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
    public partial class AccountEdiUblAppService : ApplicationService, IAccountEdiUblAppService
    {

        public AccountEdiUblAppService() 
        {

        }

        public async Task<TEntity> AddDocumentAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_currency_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_amount_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineGrossSubtotalAndDiscountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_gross_subtotal_and_discount_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_id_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_item_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineNoteNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_note_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLinePeriodNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_period_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_price_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLinePricingReferenceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_pricing_reference_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_tax_category_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_total_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_monetary_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentMonetaryTotalValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_monetary_total_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_tax_grouping_function_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddDocumentTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_document_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceAccountingCustomerPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_accounting_customer_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceAccountingSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_accounting_supplier_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceBaseLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_base_lines_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceConfigValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_config_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceCurrencyValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_currency_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceDeliveryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_delivery_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceExchangeRateNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_exchange_rate_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceHeaderNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_header_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineAmountNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_amount_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineIdNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_id_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineItemNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_item_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineNoteNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_note_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePeriodNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_period_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePriceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_price_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLinePricingReferenceNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_pricing_reference_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxCategoryNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_tax_category_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_monetary_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceMonetaryTotalsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_monetary_totals_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoicePaymentMeansNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_payment_means_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoicePaymentTermsNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_payment_terms_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceSellerSupplierPartyNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_seller_supplier_party_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxGroupingFunctionValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_tax_grouping_function_vals) ---
            */
            return default;
        }

        public async Task<TEntity> AddInvoiceTaxTotalNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_invoice_tax_total_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> AddTaxTotalNodeInCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_node, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _add_tax_total_node_in_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> CorrectInvoiceTaxAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object invoice) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _correct_invoice_tax_amount) ---
            */
            return default;
        }

        public async Task<TEntity> DispatchBaseLinesRecyclingContributionTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _dispatch_base_lines_recycling_contribution_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _export_invoice_constraints) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _export_invoice_filename) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _export_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> FindValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xpath, object tree, object nsmap) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _find_value) ---
            */
            return default;
        }

        public async Task<TEntity> FormatFloatAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object precision_digits) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: format_float) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_address_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_document_allowance_charge_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_document_allowance_charge_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetDocumentLineNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_document_line_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetDocumentNsmapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_document_nsmap) ---
            */
            return default;
        }

        public async Task<TEntity> GetDocumentTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_document_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetDocumentTypeCodeNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_document_type_code_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetFinancialAccountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_financial_account_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetImportDocumentAmountSignInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_import_document_amount_sign) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_invoice_line_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_invoice_line_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_invoice_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetLineDiscountAllowanceChargeNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_line_discount_allowance_charge_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetLineFixedTaxAllowanceChargeNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_line_fixed_tax_allowance_charge_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_line_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartyNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_party_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetPostalAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_postal_address) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_product_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetTagsForDocumentTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_tags_for_document_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_tax_category_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_tax_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxSubtotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_tax_subtotal_node) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxTotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _get_tax_total_node) ---
            */
            return default;
        }

        public async Task<TEntity> ImportFillInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _import_fill_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _import_retrieve_partner_vals) ---
            */
            return default;
        }

        public async Task<TEntity> IsDocumentAllowanceChargeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _is_document_allowance_charge) ---
            */
            return default;
        }

        public async Task<TEntity> SetupBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _setup_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> TurnEmptyingTaxesAsNewBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_ubl_20.py, METHOD: _turn_emptying_taxes_as_new_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesAllowanceChargesDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_allowance_charges_discount) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesAllowanceChargesExciseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_allowance_charges_excise) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesAllowanceChargesRecyclingContributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_allowance_charges_recycling_contribution) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesItemInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_item) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesLineExtensionAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object use_company_currency) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_line_extension_amount) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_price) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesAllowanceChargeEarlyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_allowance_charge_early_payment) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesPayableRoundingAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_payable_rounding_amount) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeCompanyCurrencyIfForeignCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_currency_code_company_currency_if_foreign_currency) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_currency_code_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_currency_code_empty) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_currency_code) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_totals) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data, object vals, object currency) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_default_tax_category_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxSubtotalGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_category_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_default_tax_subtotal_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxSubtotalTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_default_tax_subtotal_tax_category_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxTotalGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_subtotal_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_default_tax_total_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetAllowanceChargeEarlyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object early_payment_values) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_allowance_charge_early_payment) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetAllowanceChargeEarlyPaymentTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_category) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_allowance_charge_early_payment_tax_category_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeExciseNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object excise_values) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_allowance_charge_excise_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeRecyclingContributionNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object recycling_contribution_values) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_allowance_charge_recycling_contribution_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineItemNodeClassifiedTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_category) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_item_node_classified_tax_category_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineItemNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object item_values) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_item_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_category) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_tax_category_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetTaxSubtotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_subtotal) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_tax_subtotal_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetTaxTotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_total) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_tax_total_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetWithholdingTaxTotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_total) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_withholding_tax_total_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblIsEarlyPaymentBaseLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_is_early_payment_base_line) ---
            */
            return default;
        }

        public async Task<TEntity> UblIsExciseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_data) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_is_excise_tax) ---
            */
            return default;
        }

        public async Task<TEntity> UblIsRecyclingContributionTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_data) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_is_recycling_contribution_tax) ---
            */
            return default;
        }

        public async Task<TEntity> UblTurnEmptyingTaxesAsNewBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object vals) where TEntity : IEntity<Guid>, IAccountEdiUblable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_turn_emptying_taxes_as_new_base_lines) ---
            */
            return default;
        }
    }
}