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
    public partial class HrAttendanceOvertimeRulesetAppService
    {

        protected async Task<HrAttendanceOvertimeRuleset> AttendancesToRegenerateForInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime_ruleset.py, METHOD: _attendances_to_regenerate_for) ---
            */
            return default;
        }

        protected async Task<HrAttendanceOvertimeRuleset> ComputeRulesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime_ruleset.py, METHOD: _compute_rules_count) ---
            */
            return default;
        }
    }
}