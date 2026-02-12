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
    public partial class HrAttendanceOvertimeLineAppService
    {

        protected async Task<HrAttendanceOvertimeLine> ComputeIsManagerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py, METHOD: _compute_is_manager) ---
            */
            return default;
        }

        protected async Task<HrAttendanceOvertimeLine> ComputeManualDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py, METHOD: _compute_manual_duration) ---
            */
            return default;
        }

        protected async Task<HrAttendanceOvertimeLine> ComputeStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py, METHOD: _compute_status) ---
            */
            return default;
        }

        protected async Task<HrAttendanceOvertimeLine> LinkedAttendancesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py, METHOD: _linked_attendances) ---
            */
            return default;
        }
    }
}