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
    public partial class ResourceCalendarAttendanceAppService
    {

        protected async Task<ResourceCalendarAttendance> CheckDayPeriodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py, METHOD: _check_day_period) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> ComputeDurationDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py, METHOD: _compute_duration_days) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> ComputeDurationHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py, METHOD: _compute_duration_hours) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> CopyAttendanceValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: resource_calendar_attendance.py, METHOD: _copy_attendance_vals) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py, METHOD: _copy_attendance_vals) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> DefaultWorkEntryTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: resource_calendar_attendance.py, METHOD: _default_work_entry_type_id) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> InverseDurationHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py, METHOD: _inverse_duration_hours) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> IsWorkPeriodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: resource_calendar_attendance.py, METHOD: _is_work_period) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py, METHOD: _is_work_period) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResourceCalendarAttendance> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: resource_calendar_attendance.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResourceCalendarAttendance> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: resource_calendar_attendance.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> OnchangeHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py, METHOD: _onchange_hours) ---
            */
            return default;
        }
    }
}