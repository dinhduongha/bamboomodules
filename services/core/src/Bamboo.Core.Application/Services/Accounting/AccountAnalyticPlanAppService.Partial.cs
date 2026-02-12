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
    public partial class AccountAnalyticPlanAppService
    {

        protected async Task<AccountAnalyticPlan> AutoInitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _auto_init) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> CalculateDistributionAmountInternalAsync(object amount, object percentage, object total_percentage, object distribution_on_each_plan)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: analytic_account.py, METHOD: _calculate_distribution_amount) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ColumnNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _column_name) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeAllAnalyticAccountCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _compute_all_analytic_account_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeAnalyticAccountCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _compute_analytic_account_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeChildrenCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _compute_children_count) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> ComputeRootIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _compute_root_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> DefaultColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _default_color) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> FindPlanColumnInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _find_plan_column) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> FindRelatedFieldInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _find_related_field) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> GetAllPlansInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _get_all_plans) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> GetApplicabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _get_applicability) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> HierarchyNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _hierarchy_name) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> InverseNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _inverse_name) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> InverseParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _inverse_parent_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> IsSubplanFieldUsedInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _is_subplan_field_used) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> OnchangeParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _onchange_parent_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> SearchRootIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _search_root_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> StrictColumnNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _strict_column_name) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> SyncAllPlanColumnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _sync_all_plan_column) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticPlan> SyncPlanColumnInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: _sync_plan_column) ---
            */
            return default;
        }

        private async Task<AccountAnalyticPlan> _GetAllPlansInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_plan.py, METHOD: __get_all_plans) ---
            */
            return default;
        }
    }
}