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
    public partial class HrLeaveAppService
    {

        protected async Task<HrLeave> ActionUserCancelInternalAsync(object reason)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _action_user_cancel) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: _action_user_cancel) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py, METHOD: _action_user_cancel) ---
            */
            return default;
        }

        protected async Task<HrLeave> ActionValidateInternalAsync(object check_state)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _action_validate) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrLeave> CancelInvalidLeavesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _cancel_invalid_leaves) ---
            */
            return default;
        }

        protected async Task<HrLeave> CancelWorkEntryConflictInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: _cancel_work_entry_conflict) ---
            */
            return default;
        }

        protected async Task<HrLeave> CheckApprovalUpdateInternalAsync(object state, object raise_if_not_possible)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_approval_update) ---
            */
            return default;
        }

        protected async Task<HrLeave> CheckContractsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_contracts) ---
            */
            return default;
        }

        protected async Task<HrLeave> CheckDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_date) ---
            */
            return default;
        }

        protected async Task<HrLeave> CheckDateStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_date_state) ---
            */
            return default;
        }

        protected async Task<HrLeave> CheckDoubleValidationRulesInternalAsync(object employees, object state)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_double_validation_rules) ---
            */
            return default;
        }

        protected async Task<HrLeave> CheckMissingGlobalLeaveTimesheetsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py, METHOD: _check_missing_global_leave_timesheets) ---
            */
            return default;
        }

        protected async Task<HrLeave> CheckOvertimeDeductibleInternalAsync(object leaves)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: _check_overtime_deductible) ---
            */
            return default;
        }

        protected async Task<HrLeave> CheckValidityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_validity) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanApproveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_approve) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanBackToApproveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_back_to_approve) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_cancel) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: _compute_can_cancel) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanRefuseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_refuse) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanValidateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_validate) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDashboardWarningMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_dashboard_warning_message) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDateFromToInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_date_from_to) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDepartmentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_department_id) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_description) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDurationDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_duration_display) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeEmployeeOvertimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: _compute_employee_overtime) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeFromEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_from_employee_id) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeHasMandatoryDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_has_mandatory_day) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeIsHatchedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_is_hatched) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeLastSeveralDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_last_several_days) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeLeaveTypeIncreasesDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_leave_type_increases_duration) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeLeavesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_leaves) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeOvertimeDeductibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: _compute_overtime_deductible) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeRequestHourFromToInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_request_hour_from_to) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeRequestUnitHalfInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_request_unit_half) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeRequestUnitHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_request_unit_hours) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeResourceCalendarIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_resource_calendar_id) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeSupportedAttachmentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_supported_attachment_ids) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeTzInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_tz) ---
            */
            return default;
        }

        protected async Task<HrLeave> ComputeTzMismatchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_tz_mismatch) ---
            */
            return default;
        }

        protected async Task<HrLeave> CreateResourceLeaveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _create_resource_leave) ---
            */
            return default;
        }

        protected async Task<HrLeave> DefaultGetRequestDatesInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _default_get_request_dates) ---
            */
            return default;
        }

        protected async Task<HrLeave> ForceCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _force_cancel) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: _force_cancel) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py, METHOD: _force_cancel) ---
            */
            return default;
        }

        protected async Task<HrLeave> GenerateTimesheetsInternalAsync(object ignored_resource_calendar_leaves)
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py, METHOD: _generate_timesheets) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrLeave> GetDeductibleEmployeeOvertimeInternalAsync(object employees)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: _get_deductible_employee_overtime) ---
            */
            return default;
        }

        protected async Task<HrLeave> GetDurationsInternalAsync(object check_leave_type, object resource_calendar)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_durations) ---
            */
            return default;
        }

        protected async Task<HrLeave> GetEmployeeDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_employee_domain) ---
            */
            return default;
        }

        protected async Task<HrLeave> GetHourFromToInternalAsync(object request_date_from, object request_date_to, object day_period)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_hour_from_to) ---
            */
            return default;
        }

        protected async Task<HrLeave> GetLeavesOnPublicHolidayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_leaves_on_public_holiday) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: _get_leaves_on_public_holiday) ---
            */
            return default;
        }

        protected async Task<HrLeave> GetNextStatesByStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_next_states_by_state) ---
            */
            return default;
        }

        protected async Task<HrLeave> GetOverlappingContractsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_overlapping_contracts) ---
            */
            return default;
        }

        protected async Task<HrLeave> GetRedirectSuggestedCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_redirect_suggested_company) ---
            */
            return default;
        }

        protected async Task<HrLeave> GetResponsibleForApprovalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_responsible_for_approval) ---
            */
            return default;
        }

        protected async Task<HrLeave> GetToCleanActivitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_to_clean_activities) ---
            */
            return default;
        }

        protected async Task<HrLeave> InverseDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _inverse_description) ---
            */
            return default;
        }

        protected async Task<HrLeave> InverseSupportedAttachmentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _inverse_supported_attachment_ids) ---
            */
            return default;
        }

        protected async Task<HrLeave> MoveValidateLeaveToConfirmInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _move_validate_leave_to_confirm) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: _move_validate_leave_to_confirm) ---
            */
            return default;
        }

        protected async Task<HrLeave> NotifyChangeInternalAsync(object message, object subtype_xmlid)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _notify_change) ---
            */
            return default;
        }

        protected async Task<HrLeave> NotifyManagerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _notify_manager) ---
            */
            return default;
        }

        protected async Task<HrLeave> OnchangeHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _onchange_hours) ---
            */
            return default;
        }

        protected async Task<HrLeave> PostLeaveCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _post_leave_cancel) ---
            */
            return default;
        }

        protected async Task<HrLeave> PrepareHolidaysMeetingValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _prepare_holidays_meeting_values) ---
            */
            return default;
        }

        protected async Task<HrLeave> PrepareResourceLeaveValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _prepare_resource_leave_vals) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: _prepare_resource_leave_vals) ---
            */
            return default;
        }

        protected async Task<HrLeave> RegenWorkEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: _regen_work_entries) ---
            */
            return default;
        }

        protected async Task<HrLeave> RemoveResourceLeaveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _remove_resource_leave) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: _remove_resource_leave) ---
            */
            return default;
        }

        protected async Task<HrLeave> SearchDescriptionInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _search_description) ---
            */
            return default;
        }

        protected async Task<HrLeave> SplitLeavesInternalAsync(object split_date_from, object split_date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _split_leaves) ---
            */
            return default;
        }

        protected async Task<HrLeave> TimesheetPrepareLineValuesInternalAsync(object index, object work_hours_data, object day_date, object work_hours_count, object project, object task)
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py, METHOD: _timesheet_prepare_line_values) ---
            */
            return default;
        }

        protected async Task<HrLeave> ToUtcInternalAsync(object date, object hour, object resource)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _to_utc) ---
            */
            return default;
        }

        protected async Task<HrLeave> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<HrLeave> UnlinkIfCorrectStatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _unlink_if_correct_states) ---
            */
            return default;
        }

        protected async Task<HrLeave> UpdateLeavesOvertimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: _update_leaves_overtime) ---
            */
            return default;
        }

        protected async Task<HrLeave> ValidateLeaveRequestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _validate_leave_request) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py, METHOD: _validate_leave_request) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py, METHOD: _validate_leave_request) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py, METHOD: _validate_leave_request) ---
            */
            return default;
        }
    }
}