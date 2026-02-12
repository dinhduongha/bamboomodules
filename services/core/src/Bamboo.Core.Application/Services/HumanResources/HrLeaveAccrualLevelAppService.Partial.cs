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
    public partial class HrLeaveAccrualLevelAppService
    {

        protected async Task<HrLeaveAccrualLevel> CheckDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _check_dates) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> CheckMaximumLeavesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _check_maximum_leaves) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> CheckWorkedHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_accrual_plan_level.py, METHOD: _check_worked_hours) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeAccrualValidityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_accrual_validity) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeActionWithUnusedAccrualsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_action_with_unused_accruals) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeAddedValueTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_added_value_type) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeCanModifyValueTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_can_modify_value_type) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeCarryoverOptionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_carryover_options) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeFirstMonthDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_first_month_day) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeFrequencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_frequency) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeMaximumLeaveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_maximum_leave) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeMilestoneDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_milestone_date) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeSecondMonthDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_second_month_day) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_sequence) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> ComputeYearlyDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _compute_yearly_day) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> GetHourlyFrequenciesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _get_hourly_frequencies) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_accrual_plan_level.py, METHOD: _get_hourly_frequencies) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> GetLevelTransitionDateInternalAsync(object allocation_start)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _get_level_transition_date) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> GetNextDateInternalAsync(object last_call)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _get_next_date) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> GetPreviousDateInternalAsync(object last_call)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _get_previous_date) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> InverseAddedValueTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _inverse_added_value_type) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> InverseMilestoneDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _inverse_milestone_date) ---
            */
            return default;
        }

        protected async Task<HrLeaveAccrualLevel> SetDayInternalAsync(object day_field, object month_field)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan_level.py, METHOD: _set_day) ---
            */
            return default;
        }
    }
}