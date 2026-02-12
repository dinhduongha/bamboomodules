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
    public partial class AccountAnalyticAccountAppService
    {

        protected async Task<AccountAnalyticAccount> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _check_company_consistency) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeBomCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py, METHOD: _compute_bom_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeDebitCreditBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _compute_debit_credit_balance) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeInvoiceCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_account.py, METHOD: _compute_invoice_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeProductionCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py, METHOD: _compute_production_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeProjectCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: account_analytic_account.py, METHOD: _compute_project_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputePurchaseOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: analytic_account.py, METHOD: _compute_purchase_order_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeVendorBillCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_account.py, METHOD: _compute_vendor_bill_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ComputeWorkorderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: analytic_account.py, METHOD: _compute_workorder_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> PerformAnalyticDistributionInternalAsync(object distribution, object amount, object unit_amount, object lines, object obj, object additive)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: analytic_account.py, METHOD: _perform_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ReadGroupPostprocessAggregateInternalAsync(object aggregate_spec, object raw_values)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _read_group_postprocess_aggregate) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> ReadGroupSelectInternalAsync(object aggregate_spec, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _read_group_select) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> UnlinkExceptAccountInAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: analytic.py, METHOD: _unlink_except_account_in_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> UnlinkExceptExistingTasksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: account_analytic_account.py, METHOD: _unlink_except_existing_tasks) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticAccount> UpdateAccountsInAnalyticLinesInternalAsync(object new_fname, object current_fname, object accounts)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _update_accounts_in_analytic_lines) ---
            */
            return default;
        }
    }
}