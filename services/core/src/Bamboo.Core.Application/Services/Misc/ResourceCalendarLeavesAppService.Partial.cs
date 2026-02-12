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
    public partial class ResourceCalendarLeavesAppService
    {

        protected async Task<ResourceCalendarLeaves> CheckCompareDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _check_compare_dates) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> ComputeCalendarIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource_calendar_leaves.py, METHOD: _compute_calendar_id) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py, METHOD: _compute_calendar_id) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _compute_company_id) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> ComputeDateToInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py, METHOD: _compute_date_to) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> ConvertTimezoneInternalAsync(object utc_naive_datetime, object tz_from, object tz_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _convert_timezone) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> CopyLeaveValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: resource_calendar_leaves.py, METHOD: _copy_leave_vals) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py, METHOD: _copy_leave_vals) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> EnsureDatetimeInternalAsync(object datetime_representation, object date_format)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _ensure_datetime) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GeneratePublicTimeOffTimesheetsInternalAsync(object employees)
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: _generate_public_time_off_timesheets) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GenerateTimesheeetsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: _generate_timesheeets) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GetDomainInternalAsync(object time_domain_dict)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _get_domain) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GetOverlappingHrLeavesInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: _get_overlapping_hr_leaves) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GetResourceCalendarsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: _get_resource_calendars) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GetTimeDomainDictInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _get_time_domain_dict) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> PreparePublicHolidaysValuesInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _prepare_public_holidays_values) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> ReevaluateLeavesInternalAsync(object time_domain_dict)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _reevaluate_leaves) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> RegenerateHrLeaveTimesheetsOnGtoUnlinkedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: _regenerate_hr_leave_timesheets_on_gto_unlinked) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> TimesheetCreateLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: _timesheet_create_lines) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> TimesheetPrepareLineValuesInternalAsync(object index, Guid employee_id, object work_hours_data, object day_date, object work_hours_count)
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: _timesheet_prepare_line_values) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> WorkTimePerDayInternalAsync(object resource_calendars)
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: _work_time_per_day) ---
            */
            return default;
        }
    }
}