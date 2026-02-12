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
    public partial class AccountEdiCommonAppService : ApplicationService, IAccountEdiCommonAppService
    {

        public AccountEdiCommonAppService() 
        {

        }

        public async Task<TEntity> AddLogsImportInvoiceUblCiiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_logs) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _add_logs_import_invoice_ubl_cii) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_edi_common.py, METHOD: _add_logs_import_invoice_ubl_cii) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNon0RateTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _check_non_0_rate_tax) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRequiredFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_names, object custom_warning_message) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _check_required_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRequiredTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _check_required_tax) ---
            */
            return default;
        }

        public async Task<TEntity> CorrectInvoiceTaxAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _correct_invoice_tax_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _export_invoice_constraints) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceEcosioSchematronsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _export_invoice_ecosio_schematrons) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _export_invoice_filename) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _export_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ExportInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _export_invoice_vals) ---
            */
            return default;
        }

        public async Task<TEntity> FindValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xpath, object tree, object nsmap) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _find_value) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _find_value) ---
            */
            return default;
        }

        public async Task<TEntity> FormatFloatAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object precision_digits) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: format_float) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyDecimalPlacesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid currency_id) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _get_currency_decimal_places) ---
            */
            return default;
        }

        public async Task<TEntity> GetDocumentAllowanceChargeXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _get_document_allowance_charge_xpaths) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _get_document_allowance_charge_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetExchangedDocumentValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _get_exchanged_document_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetImportDocumentAmountSignInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _get_import_document_amount_sign) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _get_invoice_line_xpaths) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _get_invoice_line_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicingPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _get_invoicing_period) ---
            */
            return default;
        }

        public async Task<TEntity> GetLineXpathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _get_line_xpaths) ---
            */
            return default;
        }

        public async Task<TEntity> GetPostalAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _get_postal_address) ---
            */
            return default;
        }

        public async Task<TEntity> GetScheduledDeliveryTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _get_scheduled_delivery_time) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxCategoryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _get_tax_category_code) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxExemptionReasonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, object supplier, object tax) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _get_tax_exemption_reason) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxNodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _get_tax_nodes) ---
            */
            return default;
        }

        public async Task<TEntity> GetUomUneceCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uom) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _get_uom_unece_code) ---
            */
            return default;
        }

        public async Task<TEntity> ImportAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> ImportCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object xpath) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ImportDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object xpaths) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_description) ---
            */
            return default;
        }

        public async Task<TEntity> ImportDocumentAllowanceChargesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object record, object tax_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_document_allowance_charges) ---
            */
            return default;
        }

        public async Task<TEntity> ImportFillInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _import_fill_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ImportInvoiceUblCiiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object file_data, object @new) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_invoice_ubl_cii) ---
            */
            return default;
        }

        public async Task<TEntity> ImportLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object tree, object xpath, object document_type, object tax_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ImportPartnerBankInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object bank_details) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_partner_bank) ---
            */
            return default;
        }

        public async Task<TEntity> ImportPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object name, object phone, object email, object vat) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ImportPrepaidAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object xpath, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_prepaid_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ImportProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_product) ---
            */
            return default;
        }

        public async Task<TEntity> ImportRetrievePartnerValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object role) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_xml_cii_facturx.py, METHOD: _import_retrieve_partner_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ImportRoundingAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object tree, object xpath, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _import_rounding_amount) ---
            */
            return default;
        }

        public async Task<TEntity> InvoiceConstraintsCommonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _invoice_constraints_common) ---
            */
            return default;
        }

        public async Task<TEntity> LogImportInvoiceUblCiiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object title_logs, object invoice_logs, object attachments) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _log_import_invoice_ubl_cii) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_edi_common.py, METHOD: _log_import_invoice_ubl_cii) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrieveChargeAllowanceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object xpath_dict, object quantity) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _retrieve_charge_allowance_vals) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveFixedTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, object fixed_tax_vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _retrieve_fixed_tax) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveInvoiceLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _retrieve_invoice_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveLineChargesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object line_values, object taxes) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _retrieve_line_charges) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object document_type, object qty_factor) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _retrieve_line_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrieveRebateValInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree, object xpath_dict, object quantity) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _retrieve_rebate_val) ---
            */
            return default;
        }

        public async Task<TEntity> RetrieveTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object line_values, object tax_type, object tax_exigibility) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _retrieve_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesAllowanceChargesDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_allowance_charges_discount) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesAllowanceChargesExciseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_allowance_charges_excise) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesAllowanceChargesRecyclingContributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_allowance_charges_recycling_contribution) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesItemInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_item) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesLineExtensionAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object use_company_currency) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_line_extension_amount) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddBaseLineUblValuesPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_base_line_ubl_values_price) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesAllowanceChargeEarlyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_allowance_charge_early_payment) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesPayableRoundingAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_payable_rounding_amount) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeCompanyCurrencyIfForeignCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_currency_code_company_currency_if_foreign_currency) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_currency_code_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_currency_code_empty) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxCurrencyCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_currency_code) ---
            */
            return default;
        }

        public async Task<TEntity> UblAddValuesTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_add_values_tax_totals) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data, object vals, object currency) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_default_tax_category_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxSubtotalGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_category_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_default_tax_subtotal_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxSubtotalTaxCategoryGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_default_tax_subtotal_tax_category_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblDefaultTaxTotalGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_subtotal_grouping_key, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_default_tax_total_grouping_key) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetAllowanceChargeEarlyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object early_payment_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_allowance_charge_early_payment) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetAllowanceChargeEarlyPaymentTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_category) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_allowance_charge_early_payment_tax_category_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeDiscountNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object discount_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_allowance_charge_discount_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeExciseNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object excise_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_allowance_charge_excise_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineAllowanceChargeRecyclingContributionNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object recycling_contribution_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_allowance_charge_recycling_contribution_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineItemNodeClassifiedTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_category) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_item_node_classified_tax_category_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetLineItemNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object item_values) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_line_item_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetTaxCategoryNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_category) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_tax_category_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetTaxSubtotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_subtotal) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_tax_subtotal_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetTaxTotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_total) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_tax_total_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblGetWithholdingTaxTotalNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tax_total) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_get_withholding_tax_total_node) ---
            */
            return default;
        }

        public async Task<TEntity> UblIsEarlyPaymentBaseLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_is_early_payment_base_line) ---
            */
            return default;
        }

        public async Task<TEntity> UblIsExciseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_data) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_is_excise_tax) ---
            */
            return default;
        }

        public async Task<TEntity> UblIsRecyclingContributionTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_data) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_is_recycling_contribution_tax) ---
            */
            return default;
        }

        public async Task<TEntity> UblTurnEmptyingTaxesAsNewBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object vals) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_ubl.py, METHOD: _ubl_turn_emptying_taxes_as_new_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> tax_ids) where TEntity : IEntity<Guid>, IAccountEdiCommonable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_edi_common.py, METHOD: _validate_taxes) ---
            */
            return default;
        }
    }
}