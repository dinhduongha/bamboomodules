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
    public partial class AccountLockExceptionAppService
    {

        protected async Task<AccountLockException> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountLockException> ComputeLockDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _compute_lock_dates) ---
            */
            return default;
        }

        protected async Task<AccountLockException> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _compute_state) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountLockException> GetActiveExceptionsDomainInternalAsync(object company, object soft_lock_date_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _get_active_exceptions_domain) ---
            */
            return default;
        }

        protected async Task<AccountLockException> GetAuditTrailDuringExceptionDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _get_audit_trail_during_exception_domain) ---
            */
            return default;
        }

        protected async Task<AccountLockException> InvalidateAffectedUserLockDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _invalidate_affected_user_lock_dates) ---
            */
            return default;
        }

        protected async Task<AccountLockException> RecreateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _recreate) ---
            */
            return default;
        }

        protected async Task<AccountLockException> SearchFiscalyearLockDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _search_fiscalyear_lock_date) ---
            */
            return default;
        }

        protected async Task<AccountLockException> SearchLockDateInternalAsync(object field, object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _search_lock_date) ---
            */
            return default;
        }

        protected async Task<AccountLockException> SearchPurchaseLockDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _search_purchase_lock_date) ---
            */
            return default;
        }

        protected async Task<AccountLockException> SearchSaleLockDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _search_sale_lock_date) ---
            */
            return default;
        }

        protected async Task<AccountLockException> SearchStateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _search_state) ---
            */
            return default;
        }

        protected async Task<AccountLockException> SearchTaxLockDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_lock_exception.py, METHOD: _search_tax_lock_date) ---
            */
            return default;
        }
    }
}