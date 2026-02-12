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
    public partial class AccountBankStatementLineAppService
    {

        protected async Task<AccountBankStatementLine> CheckAllowUnlinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _check_allow_unlink) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> CheckAmountsCurrenciesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _check_amounts_currencies) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> ComputeAmountCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _compute_amount_currency) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> ComputeInternalIndexInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _compute_internal_index) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> ComputeIsReconciledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _compute_is_reconciled) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> ComputeRunningBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _compute_running_balance) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> FindOrCreateBankAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _find_or_create_bank_account) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> GetAccountingAmountsAndCurrenciesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _get_accounting_amounts_and_currencies) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> GetDefaultAmlsMatchingDomainInternalAsync(object allow_draft)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _get_default_amls_matching_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountBankStatementLine> GetDefaultJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _get_default_journal) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountBankStatementLine> GetDefaultStatementInternalAsync(Guid journal_id, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _get_default_statement) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> PrepareCounterpartAmountsUsingStLineRateInternalAsync(object currency, object balance, object amount_currency)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _prepare_counterpart_amounts_using_st_line_rate) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> PrepareMoveLineDefaultValsInternalAsync(Guid counterpart_account_id)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _prepare_move_line_default_vals) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> SeekForLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _seek_for_lines) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> SynchronizeFromMovesInternalAsync(object changed_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _synchronize_from_moves) ---
            */
            return default;
        }

        protected async Task<AccountBankStatementLine> SynchronizeToMovesInternalAsync(object changed_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement_line.py, METHOD: _synchronize_to_moves) ---
            */
            return default;
        }
    }
}