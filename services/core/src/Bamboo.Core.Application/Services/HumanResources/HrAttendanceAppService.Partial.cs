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
    public partial class HrAttendanceAppService
    {

        protected async Task<HrAttendance> CheckValidityCheckInCheckOutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _check_validity_check_in_check_out) ---
            */
            return default;
        }

        protected async Task<HrAttendance> CheckValidityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _check_validity) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_color) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_date) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeExpectedHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_expected_hours) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeIsManagerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_is_manager) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeLinkedOvertimeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_linked_overtime_ids) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeOvertimeHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_overtime_hours) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeOvertimeStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_overtime_status) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeValidatedOvertimeHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_validated_overtime_hours) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeWorkedHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_worked_hours) ---
            */
            return default;
        }

        protected async Task<HrAttendance> CronAbsenceDetectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _cron_absence_detection) ---
            */
            return default;
        }

        protected async Task<HrAttendance> CronAutoCheckOutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _cron_auto_check_out) ---
            */
            return default;
        }

        protected async Task<HrAttendance> DefaultEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _default_employee) ---
            */
            return default;
        }

        protected async Task<HrAttendance> GetAttendanceByPeriodsByEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_attendance_by_periods_by_employee) ---
            */
            return default;
        }

        protected async Task<HrAttendance> GetDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_dates) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrAttendance> GetDayStartAndDayInternalAsync(object employee, object dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_day_start_and_day) ---
            */
            return default;
        }

        protected async Task<HrAttendance> GetEmployeeCalendarInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_employee_calendar) ---
            */
            return default;
        }

        protected async Task<HrAttendance> GetLocalizedTimesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_localized_times) ---
            */
            return default;
        }

        protected async Task<HrAttendance> GetOvertimesToUpdateDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_overtimes_to_update_domain) ---
            */
            return default;
        }

        protected async Task<HrAttendance> GetWeekDateRangeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_week_date_range) ---
            */
            return default;
        }

        protected async Task<HrAttendance> LinkedOvertimesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _linked_overtimes) ---
            */
            return default;
        }

        protected async Task<HrAttendance> LoadDemoDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _load_demo_data) ---
            */
            return default;
        }

        protected async Task<HrAttendance> ReadGroupEmployeeIdInternalAsync(object resources, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _read_group_employee_id) ---
            */
            return default;
        }

        protected async Task<HrAttendance> UpdateOvertimeInternalAsync(object attendance_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _update_overtime) ---
            */
            return default;
        }
    }
}