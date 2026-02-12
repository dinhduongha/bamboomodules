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
    public partial class HrLeaveAllocationAppService
    {

        protected async Task<HrLeaveAllocation> ActionValidateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _action_validate) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> AddDaysToAllocationInternalAsync(object current_level, object current_level_maximum_leave, object leaves_taken, object period_start, object period_end)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _add_days_to_allocation) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> AddLastcallsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _add_lastcalls) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> CheckApprovalUpdateInternalAsync(object state, object raise_if_not_possible)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _check_approval_update) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> CheckDateFromDateToInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _check_date_from_date_to) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeAccrualPlanIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_accrual_plan_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeCanApproveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_can_approve) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeCanRefuseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_can_refuse) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeCanValidateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_can_validate) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeDepartmentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_department_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_description) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeDescriptionValidityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_description_validity) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeDurationDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_duration_display) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeHolidayStatusIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_holiday_status_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeIsOfficerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_is_officer) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeLeavesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_leaves) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeManagerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_manager_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeNumberOfDaysDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_number_of_days_display) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeNumberOfDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_number_of_days) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeNumberOfHoursDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_number_of_hours_display) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeOvertimeDeductibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_allocation.py, METHOD: _compute_overtime_deductible) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ComputeTypeRequestUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_type_request_unit) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> DefaultHolidayStatusIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _default_holiday_status_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> DomainEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _domain_employee_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> DomainHolidayStatusIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _domain_holiday_status_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> GetAccrualPlanLevelWorkEntryProrataInternalAsync(object level, object start_period, object start_date, object end_period, object end_date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_accrual_plan_level_work_entry_prorata) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_allocation.py, METHOD: _get_accrual_plan_level_work_entry_prorata) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> GetCarryoverDateInternalAsync(object date_from)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_carryover_date) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> GetCurrentAccrualPlanLevelIdInternalAsync(object date, List<Guid> level_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_current_accrual_plan_level_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> GetFutureLeavesOnInternalAsync(object accrual_date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_future_leaves_on) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> GetNextStatesByStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_next_states_by_state) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> GetRedirectSuggestedCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_redirect_suggested_company) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> GetRequestUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_request_unit) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> GetResponsibleForApprovalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_responsible_for_approval) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> GetTitleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_title) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> InverseAccrualPlanIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _inverse_accrual_plan_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> OnchangeAllocationTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _onchange_allocation_type) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> OnchangeDateFromInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _onchange_date_from) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> OnchangeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _onchange_name) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ProcessAccrualPlanLevelInternalAsync(object level, object start_period, object start_date, object end_period, object end_date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _process_accrual_plan_level) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> ProcessAccrualPlansInternalAsync(object date_to, object force_period, object log)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _process_accrual_plans) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> UnlinkIfCorrectStatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _unlink_if_correct_states) ---
            */
            return default;
        }

        protected async Task<HrLeaveAllocation> UnlinkIfNoLeavesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _unlink_if_no_leaves) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrLeaveAllocation> UpdateAccrualInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _update_accrual) ---
            */
            return default;
        }
    }
}