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
    public partial class ResourceCalendarAppService
    {

        protected async Task<ResourceCalendar> AttendanceIntervalsBatchInternalAsync(object start_dt, object end_dt, object resources, object domain, object tz, object lunch)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _attendance_intervals_batch) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> CheckAttendanceIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _check_attendance_ids) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> CheckOverlapInternalAsync(List<Guid> attendance_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _check_overlap) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeAssociatedLeavesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _compute_associated_leaves_count) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeAttendanceIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_attendance_ids) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeFlexibleHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_flexible_hours) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeFullTimeRequiredHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_full_time_required_hours) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeGlobalLeaveIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_global_leave_ids) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeHoursPerDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_hours_per_day) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeHoursPerWeekInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: resource_calendar.py, METHOD: _compute_hours_per_week) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_hours_per_week) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeTwoWeeksAttendanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_two_weeks_attendance) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeTwoWeeksExplanationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_two_weeks_explanation) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeTzOffsetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeWorkResourcesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_work_resources_count) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeWorkTimeRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _compute_work_time_rate) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetAttendanceIntervalsDaysDataInternalAsync(object attendance_intervals)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_attendance_intervals_days_data) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetClosestWorkTimeInternalAsync(object dt, object match_end, object resource, object search_range, object compute_leaves)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_closest_work_time) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetDaysPerWeekInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_days_per_week) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetDefaultAttendanceIdsInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_default_attendance_ids) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetGlobalAttendancesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: resource_calendar.py, METHOD: _get_global_attendances) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_global_attendances) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetHoursForDateInternalAsync(object target_date, object day_period)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_hours_for_date) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetHoursPerDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_hours_per_day) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetHoursPerWeekInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_hours_per_week) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetTwoWeeksAttendanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_two_weeks_attendance) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetUnusualDaysInternalAsync(object start_dt, object end_dt, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_unusual_days) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetWorkingHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _get_working_hours) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> HandleFlexibleLeaveIntervalInternalAsync(object dt0, object dt1, object leave)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _handle_flexible_leave_interval) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> InverseFlexibleHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _inverse_flexible_hours) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> InverseTwoWeeksCalendarInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _inverse_two_weeks_calendar) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> LeaveIntervalsBatchInternalAsync(object start_dt, object end_dt, object resources, object domain, object tz)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _leave_intervals_batch) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> LeaveIntervalsInternalAsync(object start_dt, object end_dt, object resource, object domain, object tz)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _leave_intervals) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> OnchangeAttendanceIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _onchange_attendance_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResourceCalendar> SearchWorkTimeRateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _search_work_time_rate) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> UnavailableIntervalsBatchInternalAsync(object start_dt, object end_dt, object resources, object domain, object tz)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _unavailable_intervals_batch) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> UnavailableIntervalsInternalAsync(object start_dt, object end_dt, object resource, object domain, object tz)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _unavailable_intervals) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> WorkIntervalsBatchInternalAsync(object start_dt, object end_dt, object resources, object domain, object tz, object compute_leaves)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _work_intervals_batch) ---
            */
            return default;
        }

        protected async Task<ResourceCalendar> WorksOnDateInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: _works_on_date) ---
            */
            return default;
        }
    }
}