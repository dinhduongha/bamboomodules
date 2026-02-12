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
    public partial class AccountAccountAppService
    {

        protected async Task<AccountAccount> ActionUnmergeGetUserConfirmationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _action_unmerge_get_user_confirmation) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ActionUnmergeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _action_unmerge) ---
            */
            return default;
        }

        protected async Task<AccountAccount> BuildSpreadsheetFormulaDomainInternalAsync(object formula_params, object default_accounts)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py, METHOD: _build_spreadsheet_formula_domain) ---
            */
            return default;
        }

        protected async Task<AccountAccount> CheckAccountCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_account_code) ---
            */
            return default;
        }

        protected async Task<AccountAccount> CheckAccountIsBankJournalBankAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_account_is_bank_journal_bank_account) ---
            */
            return default;
        }

        protected async Task<AccountAccount> CheckAccountTypeSalesPurchaseJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_account_type_sales_purchase_journal) ---
            */
            return default;
        }

        protected async Task<AccountAccount> CheckActionUnmergePossibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_action_unmerge_possible) ---
            */
            return default;
        }

        protected async Task<AccountAccount> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_company_consistency) ---
            */
            return default;
        }

        protected async Task<AccountAccount> CheckJournalConsistencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_journal_consistency) ---
            */
            return default;
        }

        protected async Task<AccountAccount> CheckReconcileInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_reconcile) ---
            */
            return default;
        }

        protected async Task<AccountAccount> CheckUsedAsJournalDefaultDebitCreditAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_used_as_journal_default_debit_credit_account) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeAccountGroupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_account_group) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeAccountRootInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_account_root) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeAccountTagsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_account_tags) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeAccountTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_account_type) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_code) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeCompanyCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_company_currency_id) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeCompanyFiscalCountryCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_company_fiscal_country_code) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeCurrentBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_current_balance) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeIncludeInitialBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_include_initial_balance) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeInternalGroupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_internal_group) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeOpeningDebitCreditInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_opening_debit_credit) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputePlaceholderCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_placeholder_code) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeReconcileInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_reconcile) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeRelatedTaxesAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_related_taxes_amount) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ComputeUsedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_used) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ConstrainsReconcileInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _constrains_reconcile) ---
            */
            return default;
        }

        protected async Task<AccountAccount> EnsureCodeIsUniqueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _ensure_code_is_unique) ---
            */
            return default;
        }

        protected async Task<object> FieldToSqlInternalAsync(string @alias, string field_expr, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        protected async Task<AccountAccount> GetClosestParentAccountInternalAsync(object accounts_to_process, object field_name, object default_value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_closest_parent_account) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAccount> GetDatePeriodBoundariesInternalAsync(object date_period, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: account.py, METHOD: _get_date_period_boundaries) ---
            */
            return default;
        }

        protected async Task<AccountAccount> GetInternalGroupInternalAsync(object account_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_internal_group) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAccount> GetMostFrequentAccountForPartnerInternalAsync(Guid company_id, Guid partner_id, object move_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_most_frequent_account_for_partner) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAccount> GetMostFrequentAccountsForPartnerInternalAsync(Guid company_id, Guid partner_id, object move_type, object filter_never_user_accounts, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_most_frequent_accounts_for_partner) ---
            */
            return default;
        }

        protected async Task<AccountAccount> GetUsedAccountIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_used_account_ids) ---
            */
            return default;
        }

        protected async Task<AccountAccount> InverseCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _inverse_code) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAccount> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_account.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAccount> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_account.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAccount> LoadPrecommitUpdateOpeningMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _load_precommit_update_opening_move) ---
            */
            return default;
        }

        protected async Task<AccountAccount> LoadRecordsWriteInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _load_records_write) ---
            */
            return default;
        }

        protected async Task<AccountAccount> MergeMethodInternalAsync(object destination, object source)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _merge_method) ---
            */
            return default;
        }

        protected async Task<AccountAccount> OnchangeAccountTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _onchange_account_type) ---
            */
            return default;
        }

        protected async Task<AccountAccount> OnchangeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _onchange_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAccount> OrderAccountsByFrequencyForPartnerInternalAsync(Guid company_id, Guid partner_id, object move_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _order_accounts_by_frequency_for_partner) ---
            */
            return default;
        }

        protected async Task<object> OrderToSqlInternalAsync(string order, object query, object @alias, bool reverse)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _order_to_sql) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SearchAccountRootInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_account_root) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SearchCodeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_code) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAccount> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SearchIncludeInitialBalanceInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_include_initial_balance) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SearchInternalGroupInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_internal_group) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAccount> SearchNewAccountCodeInternalAsync(object start_code, object cache)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_new_account_code) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SearchPanelDomainImageInternalAsync(object field_name, object domain, object set_count, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_panel_domain_image) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SearchPlaceholderCodeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_placeholder_code) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SearchUsedInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_used) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SetOpeningBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _set_opening_balance) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SetOpeningCreditInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _set_opening_credit) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SetOpeningDebitCreditInternalAsync(object amount, object field)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _set_opening_debit_credit) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SetOpeningDebitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _set_opening_debit) ---
            */
            return default;
        }

        protected async Task<AccountAccount> SplitCodeNameInternalAsync(object code_name)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _split_code_name) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ToggleReconcileToFalseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _toggle_reconcile_to_false) ---
            */
            return default;
        }

        protected async Task<AccountAccount> ToggleReconcileToTrueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _toggle_reconcile_to_true) ---
            */
            return default;
        }

        protected async Task<AccountAccount> UnlinkExceptContainsJournalItemsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _unlink_except_contains_journal_items) ---
            */
            return default;
        }

        protected async Task<AccountAccount> UnlinkExceptLinkedToFiscalPositionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _unlink_except_linked_to_fiscal_position) ---
            */
            return default;
        }

        protected async Task<AccountAccount> UnlinkExceptLinkedToTaxRepartitionLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _unlink_except_linked_to_tax_repartition_line) ---
            */
            return default;
        }
    }
}