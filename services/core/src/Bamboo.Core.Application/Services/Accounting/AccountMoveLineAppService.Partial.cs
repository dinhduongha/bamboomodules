using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class AccountMoveLineAppService
    {

        protected async Task<AccountMoveLine> AffectTaxReportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _affect_tax_report) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> AllReconciledLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _all_reconciled_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> ApplyIrRulesInternalAsync(object query, object mode)
        {
            /*
            --- METHOD SOURCE (MODULE: accounting_pdf_reports, FILE: account_move_line.py, METHOD: _apply_ir_rules) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckAmlsExigibilityForReconciliationInternalAsync(object shadowed_aml_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_amls_exigibility_for_reconciliation) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckCabaNonCabaSharedTagsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_caba_non_caba_shared_tags) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckConstrainsAccountIdJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_constrains_account_id_journal_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckEdiLineTaxRequiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_edi_line_tax_required) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckOffBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_off_balance) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckPayableReceivableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_payable_receivable) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py, METHOD: _check_payable_receivable) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckReconciliationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_reconciliation) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CheckTaxLockDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_tax_lock_date) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_account_id) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py, METHOD: _compute_account_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAmountCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_amount_currency) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAmountResidualInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_amount_residual) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py, METHOD: _compute_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_balance) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeCumulatedBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_cumulated_balance) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDebitCreditInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_debit_credit) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDiscountAllocationKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_discount_allocation_key) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDiscountAllocationNeededInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_discount_allocation_needed) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeDisplayTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_display_type) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeEpdKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_epd_key) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeEpdNeededInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_epd_needed) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeHasInvalidAnalyticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_has_invalid_analytics) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeIsRefundInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_is_refund) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeIsStornoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_is_storno) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _compute_is_storno) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeNeedVehicleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py, METHOD: _compute_need_vehicle) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeNoFollowupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_no_followup) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_parent_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputePaymentDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_payment_date) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputePriceUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_price_unit) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeProductUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_product_uom_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputePurchaseLineWarnMsgInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _compute_purchase_line_warn_msg) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_quantity) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeReconciledLinesExcludingExchangeDiffIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_reconciled_lines_excluding_exchange_diff_ids) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeReconciledLinesIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_reconciled_lines_ids) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeSaleLineWarnMsgInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _compute_sale_line_warn_msg) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeSameCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_same_currency) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_sequence) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeTaxIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_tax_ids) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeTermKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_term_key) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ComputeTotalsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_totals) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py, METHOD: _compute_totals) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ConditionalAddToComputeInternalAsync(object fname, object condition)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _conditional_add_to_compute) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ConstrainsDeductibleAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _constrains_deductible_amount) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ConstrainsMatchingNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _constrains_matching_number) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CopyDataExtendBusinessFieldsInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _copy_data_extend_business_fields) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _copy_data_extend_business_fields) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _copy_data_extend_business_fields) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> CreateAnalyticLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _create_analytic_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> CreateExchangeDifferenceMovesInternalAsync(object exchange_diff_values_list)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _create_exchange_difference_moves) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> EligibleForStockAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py, METHOD: _eligible_for_stock_account) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py, METHOD: _eligible_for_stock_account) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ExceptHashedEntryLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _except_hashed_entry_lines) ---
            */
            return default;
        }

        protected async Task<object> FieldToSqlInternalAsync(string @alias, string field_expr, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> FilterAmlLotValuationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _filter_aml_lot_valuation) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> FilterReconciledByNumberInternalAsync(Dictionary<string, object> mapping)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _filter_reconciled_by_number) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> FormatAmlNameInternalAsync(object line_name, object move_ref, object move_name)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _format_aml_name) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetAmlValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_aml_values) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetAnalyticDistributionArgumentsInternalAsync(object root_plans)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_analytic_distribution_arguments) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetAssetDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: _get_asset_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> GetAttachmentByRecordInternalAsync(object id_model2attachments, object move_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_attachment_by_record) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py, METHOD: _get_attachment_by_record) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetAttachmentDomainsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_attachment_domains) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py, METHOD: _get_attachment_domains) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetChildLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_child_lines) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetCogsValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _get_cogs_value) ---
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: account_move.py, METHOD: _get_cogs_value) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py, METHOD: _get_cogs_value) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetComputedTaxesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_computed_taxes) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> GetDefaultReadFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_default_read_fields) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetDownpaymentLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_downpayment_lines) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _get_downpayment_lines) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetExchangeAccountInternalAsync(object company, object amount)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_exchange_account) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetExchangeJournalInternalAsync(object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_exchange_journal) ---
            */
            return default;
        }

        protected async Task<object> GetExtraQueryBaseTaxLineMappingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line_tax_details.py, METHOD: _get_extra_query_base_tax_line_mapping) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move_line.py, METHOD: _get_extra_query_base_tax_line_mapping) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetGrossUnitPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py, METHOD: _get_gross_unit_price) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetInstallmentsDataInternalAsync(object payment_currency, object payment_date, object next_payment_date)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_installments_data) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetIntegrityHashFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_integrity_hash_fields) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetInvoicedQtyPerProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_invoiced_qty_per_product) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: account_move.py, METHOD: _get_invoiced_qty_per_product) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetJournalItemsFullNameInternalAsync(object name, object display_name)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_journal_items_full_name) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetLockDateProtectedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_lock_date_protected_fields) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetMatchedMoveIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_matched_move_ids) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetPriceUnitValDifAndRelevantQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: account_move_line.py, METHOD: _get_price_unit_val_dif_and_relevant_qty) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py, METHOD: _get_price_unit_val_dif_and_relevant_qty) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetProductCatalogLinesDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_product_catalog_lines_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<object> GetQueryTaxDetailsFromDomainInternalAsync(object domain, object fallback)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line_tax_details.py, METHOD: _get_query_tax_details_from_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<object> GetQueryTaxDetailsInternalAsync(object table_references, object search_condition, object fallback)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line_tax_details.py, METHOD: _get_query_tax_details) ---
            #endif
            return default;
        }

        protected async Task<AccountMoveLine> GetReconciliationAmlFieldValueInternalAsync(object field, object shadowed_aml_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_reconciliation_aml_field_value) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetResultInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: account_move.py, METHOD: _get_result) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetSectionLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_section_lines) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetSoMappingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py, METHOD: _get_so_mapping_domain) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetSoMappingFromExpenseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py, METHOD: _get_so_mapping_from_expense) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetSoMappingFromProjectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py, METHOD: _get_so_mapping_from_project) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> GetStockMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: account_move_line.py, METHOD: _get_stock_moves) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: account_move_line.py, METHOD: _get_stock_moves) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py, METHOD: _get_stock_moves) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py, METHOD: _get_stock_moves) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> GetTaxExigibleDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_tax_exigible_domain) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_account_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseAmountCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_amount_currency) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseCreditInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_credit) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseDebitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_debit) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseNoFollowupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_no_followup) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> InversePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_partner_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_product_id) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move_line.py, METHOD: _inverse_product_id) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: _inverse_product_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> InverseReconciledLinesIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_reconciled_lines_ids) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> IsLineInSectionInternalAsync(object line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _is_line_in_section) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> OnchangeIsLandedCostsLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py, METHOD: _onchange_is_landed_costs_line) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> OnchangeProductIdLandedCostsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py, METHOD: _onchange_product_id_landed_costs) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> OptimizeReconciliationPlanInternalAsync(object reconciliation_plan, object shadowed_aml_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _optimize_reconciliation_plan) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ParseFlushFnamesInternalAsync(object fnames)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _parse_flush_fnames) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareAnalyticDistributionLineInternalAsync(object distribution, List<Guid> account_ids, object distribution_on_each_plan)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_analytic_distribution_line) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareAnalyticLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_analytic_lines) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _prepare_analytic_lines) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareCreateValuesInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_create_values) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareEdiValsToExportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_edi_vals_to_export) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareExchangeDifferenceMoveValsInternalAsync(object amounts_list, object company, object exchange_date)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_exchange_difference_move_vals) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareFleetLogServiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py, METHOD: _prepare_fleet_log_service) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> PrepareLineValuesForPurchaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _prepare_line_values_for_purchase) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> PrepareMoveLineResidualAmountsInternalAsync(object aml_values, object counterpart_currency, object shadowed_aml_values, object other_aml_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_move_line_residual_amounts) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> PrepareReconciliationAmlsInternalAsync(object values_list, object shadowed_aml_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_reconciliation_amls) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> PrepareReconciliationPlanInternalAsync(object plan, object amls_values_map, object shadowed_aml_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_reconciliation_plan) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> PrepareReconciliationSinglePartialInternalAsync(object debit_values, object credit_values, object shadowed_aml_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_reconciliation_single_partial) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> PreventAutomaticLineDeletionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prevent_automatic_line_deletion) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> QueryGetInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: accounting_pdf_reports, FILE: account_move_line.py, METHOD: _query_get) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconcileMarkedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_marked) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> ReconcilePlanInternalAsync(object reconciliation_plan)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_plan) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconcilePlanWithSyncInternalAsync(object plan_list, object all_amls)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_plan_with_sync) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconcilePostHookInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_post_hook) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconcilePreHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_pre_hook) ---
            */
            return default;
        }

        protected async Task<Dictionary<string, object>> ReconciledByNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconciled_by_number) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ReconciledLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconciled_lines) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> RelatedAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _related_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _related_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _related_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> RoundAnalyticDistributionLineInternalAsync(object analytic_lines_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _round_analytic_distribution_line) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SaleCanBeReinvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _sale_can_be_reinvoice) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py, METHOD: _sale_can_be_reinvoice) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py, METHOD: _sale_can_be_reinvoice) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SaleCreateReinvoiceSaleLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _sale_create_reinvoice_sale_line) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py, METHOD: _sale_create_reinvoice_sale_line) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SaleDetermineOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_sale_expense, FILE: account_move_line.py, METHOD: _sale_determine_order) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _sale_determine_order) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py, METHOD: _sale_determine_order) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: account_move_line.py, METHOD: _sale_determine_order) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SaleGetInvoicePriceInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _sale_get_invoice_price) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SalePrepareSaleLineValuesInternalAsync(object order, object price)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move_line.py, METHOD: _sale_prepare_sale_line_values) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: account_move_line.py, METHOD: _sale_prepare_sale_line_values) ---
            --- METHOD SOURCE (MODULE: sale_expense_margin, FILE: account_move_line.py, METHOD: _sale_prepare_sale_line_values) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> SearchAccountIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _search_account_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SearchJournalGroupIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _search_journal_group_id) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SearchPanelDomainImageInternalAsync(object field_name, object domain, object set_count, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _search_panel_domain_image) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SearchPaymentDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _search_payment_date) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> SyncInvoiceInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _sync_invoice) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> TimesheetDomainGetInvoicedLinesInternalAsync(object sale_line_delivery)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move_line.py, METHOD: _timesheet_domain_get_invoiced_lines) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> UnlinkExceptPostedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _unlink_except_posted) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> UpdateAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _update_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ValidFieldParameterInternalAsync(object field, object name)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _valid_field_parameter) ---
            */
            return default;
        }

        protected async Task<AccountMoveLine> ValidateAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _validate_analytic_distribution) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMoveLine> WhereCalcInternalAsync(object domain, object active_test)
        {
            /*
            --- METHOD SOURCE (MODULE: accounting_pdf_reports, FILE: account_move_line.py, METHOD: _where_calc) ---
            */
            return default;
        }
    }
}