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
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class AccountBankStatementAppService
    {

        protected async Task<AccountBankStatement> CheckAttachmentsInternalAsync(object container, object values_list)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _check_attachments) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeBalanceEndInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_balance_end) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeBalanceEndRealInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_balance_end_real) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeBalanceStartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_balance_start) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeDateIndexInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_date_index) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeIsCompleteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_is_complete) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeIsValidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_is_valid) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> ComputeProblemDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _compute_problem_description) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> GetInvalidStatementIdsInternalAsync(object all_statements)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _get_invalid_statement_ids) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> GetStatementValidityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _get_statement_validity) ---
            */
            return default;
        }

        protected async Task<AccountBankStatement> SearchIsValidInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_bank_statement.py, METHOD: _search_is_valid) ---
            */
            return default;
        }
    }
}