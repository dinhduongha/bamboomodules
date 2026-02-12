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
    public partial class AccountTaxAppService
    {

        [ApiModel]
        protected async Task<AccountTax> AdaptPriceUnitToAnotherTaxesInternalAsync(object price_unit, object product, object original_taxes, object new_taxes, object product_uom)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _adapt_price_unit_to_another_taxes) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> AddAccountingDataInBaseLinesTaxDetailsInternalAsync(object base_lines, object company, object include_caba_tags)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_accounting_data_in_base_lines_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> AddAccountingDataToBaseLineTaxDetailsInternalAsync(object base_line, object company, object include_caba_tags)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_accounting_data_to_base_line_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> AddAndRoundRawGrossTotalExcludedAndDiscountInternalAsync(object base_lines, object company, object precision_digits, object apply_strict_tolerance, object in_foreign_currency, object account_discount_base_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_and_round_raw_gross_total_excluded_and_discount) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> AddTaxDetailsInBaseLineInternalAsync(object base_line, object company, object rounding_method)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_tax_details_in_base_line) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> AddTaxDetailsInBaseLinesInternalAsync(object base_lines, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_tax_details_in_base_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> AggregateBaseLineTaxDetailsInternalAsync(object base_line, object grouping_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _aggregate_base_line_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> AggregateBaseLinesAggregatedValuesInternalAsync(object base_lines_aggregated_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _aggregate_base_lines_aggregated_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> AggregateBaseLinesTaxDetailsInternalAsync(object base_lines, object grouping_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _aggregate_base_lines_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> ApplyBaseLinesManualAmountsToReachInternalAsync(object base_lines, object company, object target_base_amount_currency, object target_base_amount, object target_tax_amounts_mapping)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _apply_base_lines_manual_amounts_to_reach) ---
            */
            return default;
        }

        protected async Task<AccountTax> BatchForTaxesComputationInternalAsync(object special_mode, object filter_tax_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _batch_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<AccountTax> CanBeDiscountedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _can_be_discounted) ---
            */
            return default;
        }

        protected async Task<AccountTax> CheckAmountTypeCodeFormulaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_tax_python, FILE: account_tax.py, METHOD: _check_amount_type_code_formula) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> CheckAndNormalizeFormulaInternalAsync(object formula)
        {
            /*
            --- METHOD SOURCE (MODULE: account_tax_python, FILE: account_tax.py, METHOD: _check_and_normalize_formula) ---
            */
            return default;
        }

        protected async Task<AccountTax> CheckChildrenScopeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _check_children_scope) ---
            */
            return default;
        }

        protected async Task<AccountTax> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _check_company_consistency) ---
            */
            return default;
        }

        protected async Task<AccountTax> CheckRepartitionLinesInternalAsync(object lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _check_repartition_lines) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_country_id) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeDisplayAlternativeTaxesFieldInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_display_alternative_taxes_field) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeFormulaDecodedInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_tax_python, FILE: account_tax.py, METHOD: _compute_formula_decoded_info) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeHasNegativeFactorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_has_negative_factor) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeInvoiceRepartitionLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_invoice_repartition_line_ids) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeIsDomesticInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_is_domestic) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeIsUsedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_is_used) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputePriceIncludeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_price_include) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeRefundRepartitionLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_refund_repartition_line_ids) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeRepartitionLinesStrInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_repartition_lines_str) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> ComputeSubsetBaseLinesTotalInternalAsync(object base_lines, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_subset_base_lines_total) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeTaxGroupIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_tax_group_id) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeTaxLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_tax_label) ---
            */
            return default;
        }

        protected async Task<AccountTax> ComputeUblCiiRequiresExemptionReasonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_tax.py, METHOD: _compute_ubl_cii_requires_exemption_reason) ---
            */
            return default;
        }

        protected async Task<AccountTax> ConstrainsCashBasisTransitionAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _constrains_cash_basis_transition_account) ---
            */
            return default;
        }

        protected async Task<AccountTax> ConstrainsNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _constrains_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> DispatchGlobalDiscountLinesInternalAsync(object base_lines, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _dispatch_global_discount_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> DispatchReturnOfMerchandiseLinesInternalAsync(object base_lines, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _dispatch_return_of_merchandise_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> DispatchTaxesIntoNewBaseLinesInternalAsync(object base_lines, object company, object exclude_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _dispatch_taxes_into_new_base_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> DistributeDeltaAmountSmoothlyInternalAsync(object precision_digits, object delta_amount, object target_factors)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _distribute_delta_amount_smoothly) ---
            */
            return default;
        }

        protected async Task<AccountTax> EvalTaxAmountFixedAmountInternalAsync(object batch, object raw_base, object evaluation_context)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_tax_amount_fixed_amount) ---
            --- METHOD SOURCE (MODULE: account_tax_python, FILE: account_tax.py, METHOD: _eval_tax_amount_fixed_amount) ---
            */
            return default;
        }

        protected async Task<AccountTax> EvalTaxAmountFormulaInternalAsync(object raw_base, object evaluation_context)
        {
            /*
            --- METHOD SOURCE (MODULE: account_tax_python, FILE: account_tax.py, METHOD: _eval_tax_amount_formula) ---
            */
            return default;
        }

        protected async Task<AccountTax> EvalTaxAmountPriceExcludedInternalAsync(object batch, object raw_base, object evaluation_context)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_tax_amount_price_excluded) ---
            */
            return default;
        }

        protected async Task<AccountTax> EvalTaxAmountPriceIncludedInternalAsync(object batch, object raw_base, object evaluation_context)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_tax_amount_price_included) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> EvalTaxesComputationPrepareProductDefaultValuesInternalAsync(object field_names)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_default_values) ---
            */
            return default;
        }

        protected async Task<AccountTax> EvalTaxesComputationPrepareProductFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_fields) ---
            --- METHOD SOURCE (MODULE: account_tax_python, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> EvalTaxesComputationPrepareProductUomDefaultValuesInternalAsync(object field_names)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_uom_default_values) ---
            */
            return default;
        }

        protected async Task<AccountTax> EvalTaxesComputationPrepareProductUomFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_uom_fields) ---
            --- METHOD SOURCE (MODULE: account_tax_python, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_uom_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> EvalTaxesComputationPrepareProductUomValuesInternalAsync(object default_product_uom_values, object product_uom)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_uom_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> EvalTaxesComputationPrepareProductValuesInternalAsync(object default_product_values, object product)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_values) ---
            */
            return default;
        }

        protected async Task<AccountTax> EvalTaxesComputationTurnToProductUomValuesInternalAsync(object product_uom)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_turn_to_product_uom_values) ---
            */
            return default;
        }

        protected async Task<AccountTax> EvalTaxesComputationTurnToProductValuesInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_turn_to_product_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> ExcludeTaxGroupsFromTaxTotalsSummaryInternalAsync(object tax_totals, object ids_to_exclude)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _exclude_tax_groups_from_tax_totals_summary) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> ExportBaseLineExtraTaxDataInternalAsync(object base_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _export_base_line_extra_tax_data) ---
            */
            return default;
        }

        protected async Task<AccountTax> FilterTaxesByCompanyInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _filter_taxes_by_company) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> FixBaseLinesTaxDetailsOnManualTaxAmountsInternalAsync(object base_lines, object company, object filter_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _fix_base_lines_tax_details_on_manual_tax_amounts) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> FixTaxIncludedPriceCompanyInternalAsync(object price, object prod_taxes, object line_taxes, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _fix_tax_included_price_company) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> FixTaxIncludedPriceInternalAsync(object price, object prod_taxes, object line_taxes)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _fix_tax_included_price) ---
            */
            return default;
        }

        protected async Task<AccountTax> FlattenTaxesAndSortThemInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _flatten_taxes_and_sort_them) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> GetBaseLineFieldValueFromRecordInternalAsync(object record, object field, object extra_values, object fallback, object from_base_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_base_line_field_value_from_record) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> GetDeltaAmountToReachTargetInternalAsync(object target_amount, object target_currency, object raw_current_amount, object raw_current_amount_precision_digits)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_delta_amount_to_reach_target) ---
            */
            return default;
        }

        protected async Task<AccountTax> GetDescriptionPlaintextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_description_plaintext) ---
            */
            return default;
        }

        protected async Task<AccountTax> GetTaxDetailsInternalAsync(object price_unit, object quantity, object precision_rounding, object rounding_method, object product, object product_uom, object special_mode, object manual_tax_amounts, object filter_tax_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> GetTaxTotalsSummaryInternalAsync(object base_lines, object currency, object company, object cash_rounding)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_tax_totals_summary) ---
            */
            return default;
        }

        protected async Task<AccountTax> HookComputeIsUsedInternalAsync(object taxes_to_compute)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _hook_compute_is_used) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_tax.py, METHOD: _hook_compute_is_used) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_tax.py, METHOD: _hook_compute_is_used) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: account_tax.py, METHOD: _hook_compute_is_used) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> ImportBaseLineExtraTaxDataInternalAsync(object base_line, object extra_tax_data)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _import_base_line_extra_tax_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_tax.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_tax.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_account_tax_python, FILE: account_tax.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> MergeTaxDetailsInternalAsync(object tax_details_1, object tax_details_2)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _merge_tax_details) ---
            */
            return default;
        }

        protected async Task<AccountTax> MessageLogInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _message_log) ---
            */
            return default;
        }

        protected async Task<AccountTax> MessageLogRepartitionLinesInternalAsync(object old_values_str, object new_values_str)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _message_log_repartition_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> NormalizeTargetFactorsInternalAsync(object target_factors)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _normalize_target_factors) ---
            */
            return default;
        }

        protected async Task<AccountTax> OnchangeUblCiiTaxCategoryCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_tax.py, METHOD: _onchange_ubl_cii_tax_category_code) ---
            */
            return default;
        }

        protected async Task<AccountTax> ParseNameSearchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _parse_name_search) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> PartitionBaseLinesTaxesInternalAsync(object base_lines, object partition_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _partition_base_lines_taxes) ---
            */
            return default;
        }

        protected async Task<AccountTax> PrepareBaseLineForTaxesComputationInternalAsync(object record)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_tax.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<AccountTax> PrepareBaseLineGroupingKeyInternalAsync(object base_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_base_line_grouping_key) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_tax.py, METHOD: _prepare_base_line_grouping_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> PrepareBaseLineTaxRepartitionGroupingKeyInternalAsync(object base_line, object base_line_grouping_key, object tax_data, object tax_rep_data)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_base_line_tax_repartition_grouping_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> PrepareBaseLinesForDownPaymentInternalAsync(object base_lines, object company, object exclude_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_base_lines_for_down_payment) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> PrepareDiscountableBaseLinesInternalAsync(object base_lines, object company, object exclude_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_discountable_base_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> PrepareDownPaymentLinesInternalAsync(object base_lines, object company, object amount_type, object amount, object computation_key, object grouping_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_down_payment_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> PrepareGlobalDiscountLinesInternalAsync(object base_lines, object company, object amount_type, object amount, object computation_key, object grouping_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_global_discount_lines) ---
            */
            return default;
        }

        protected async Task<AccountTax> PrepareTaxLineForTaxesComputationInternalAsync(object record)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_tax_line_for_taxes_computation) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_tax.py, METHOD: _prepare_tax_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<AccountTax> PrepareTaxLineRepartitionGroupingKeyInternalAsync(object tax_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_tax_line_repartition_grouping_key) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_tax.py, METHOD: _prepare_tax_line_repartition_grouping_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> PrepareTaxLinesInternalAsync(object base_lines, object company, object tax_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_tax_lines) ---
            */
            return default;
        }

        protected async Task<AccountTax> PropagateExtraTaxesBaseInternalAsync(object tax, object taxes_data, object special_mode)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _propagate_extra_taxes_base) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> ReduceBaseLinesToTargetAmountInternalAsync(object base_lines, object company, object amount_type, object amount, object computation_key, object grouping_function, object aggregate_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _reduce_base_lines_to_target_amount) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> ReduceBaseLinesWithGroupingFunctionInternalAsync(object base_lines, object grouping_function, object aggregate_function, object computation_key)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _reduce_base_lines_with_grouping_function) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> ReverseQuantityBaseLineExtraTaxDataInternalAsync(object extra_tax_data)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _reverse_quantity_base_line_extra_tax_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> RoundBaseLinesTaxDetailsInternalAsync(object base_lines, object company, object tax_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_base_lines_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> RoundRawTaxAmountsInternalAsync(object base_lines_aggregated_values, object company, object precision_digits, object apply_strict_tolerance, object in_foreign_currency)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_raw_tax_amounts) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> RoundRawTotalExcludedInternalAsync(object base_lines, object company, object precision_digits, object apply_strict_tolerance, object in_foreign_currency)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_raw_total_excluded) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> RoundTaxDetailsBaseLinesInternalAsync(object base_lines, object company, object mode)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_tax_details_base_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> RoundTaxDetailsTaxAmountsFromTaxLinesInternalAsync(object base_lines, object company, object tax_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_tax_details_tax_amounts_from_tax_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> RoundTaxDetailsTaxAmountsInternalAsync(object base_lines, object company, object mode)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_tax_details_tax_amounts) ---
            */
            return default;
        }

        protected async Task<AccountTax> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> SearchInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<AccountTax> SearchPriceIncludeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _search_price_include) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> SplitBaseLineInternalAsync(object base_line, object company, object target_factors, object populate_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _split_base_line) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> SplitTaxDataInternalAsync(object base_line, object tax_data, object company, object target_factors)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _split_tax_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> SplitTaxDetailsInternalAsync(object base_line, object company, object target_factors)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _split_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> SquashGlobalDiscountLinesInternalAsync(object base_lines, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _squash_global_discount_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> SquashReturnOfMerchandiseLinesInternalAsync(object base_lines, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _squash_return_of_merchandise_lines) ---
            */
            return default;
        }

        protected async Task<AccountTax> TurnBaseLineIsRefundFlagOffInternalAsync(object base_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _turn_base_line_is_refund_flag_off) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> TurnBaseLinesIsRefundFlagOffInternalAsync(object base_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _turn_base_lines_is_refund_flag_off) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountTax> TurnRemovedTaxesIntoNewBaseLinesInternalAsync(object base_lines, object company, object grouping_function, object aggregate_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _turn_removed_taxes_into_new_base_lines) ---
            */
            return default;
        }

        protected async Task<AccountTax> ValidateRepartitionLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _validate_repartition_lines) ---
            */
            return default;
        }
    }
}