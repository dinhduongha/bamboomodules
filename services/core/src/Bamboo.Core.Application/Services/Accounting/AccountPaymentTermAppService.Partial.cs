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
    public partial class AccountPaymentTermAppService
    {

        protected async Task<AccountPaymentTerm> CheckLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _check_lines) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeDiscountComputationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _compute_discount_computation) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeExampleInvalidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _compute_example_invalid) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeExamplePreviewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _compute_example_preview) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeFiscalCountryCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> ComputeTermsInternalAsync(object date_ref, object currency, object company, object tax_amount, object tax_amount_currency, object sign, object untaxed_amount, object untaxed_amount_currency, object cash_rounding)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _compute_terms) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> DefaultExampleDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _default_example_date) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> DefaultLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _default_line_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountPaymentTerm> GetAmountByDateInternalAsync(object terms)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _get_amount_by_date) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> GetAmountDueAfterDiscountInternalAsync(object total_amount, object untaxed_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _get_amount_due_after_discount) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> GetLastDiscountDateFormattedInternalAsync(object date_ref)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _get_last_discount_date_formatted) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> GetLastDiscountDateInternalAsync(object date_ref)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _get_last_discount_date) ---
            */
            return default;
        }

        protected async Task<AccountPaymentTerm> UnlinkExceptReferencedTermsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment_term.py, METHOD: _unlink_except_referenced_terms) ---
            */
            return default;
        }
    }
}