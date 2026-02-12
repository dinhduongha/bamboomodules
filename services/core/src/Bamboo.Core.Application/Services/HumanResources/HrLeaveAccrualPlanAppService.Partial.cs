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
    public partial class HrLeaveAccrualPlanAppService
    {

        protected async Task<HrLeaveAccrualPlan> ComputeCarryoverDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py, METHOD: _compute_carryover_day) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeEmployeeCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py, METHOD: _compute_employee_count) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeIsBasedOnWorkedTimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py, METHOD: _compute_is_based_on_worked_time) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeLevelCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py, METHOD: _compute_level_count) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeShowTransitionModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py, METHOD: _compute_show_transition_mode) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> PreventUsedPlanUnlinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py, METHOD: _prevent_used_plan_unlink) ---
            */
            return default;
        }
    }
}