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
    public partial class CrossoveredBudgetLinesAppService
    {

        protected async Task<CrossoveredBudgetLines> ComputeLineNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: _compute_line_name) ---
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> ComputePercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: _compute_percentage) ---
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> ComputePracticalAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: _compute_practical_amount) ---
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> ComputeTheoriticalAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: _compute_theoritical_amount) ---
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> IsAboveBudgetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: _is_above_budget) ---
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> LineDatesBetweenBudgetDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: _line_dates_between_budget_dates) ---
            */
            return default;
        }

        protected async Task<CrossoveredBudgetLines> MustHaveAnalyticalOrBudgetaryOrBothInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: _must_have_analytical_or_budgetary_or_both) ---
            */
            return default;
        }
    }
}