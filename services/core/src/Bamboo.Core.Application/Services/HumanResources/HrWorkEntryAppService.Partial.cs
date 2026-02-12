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
    public partial class HrWorkEntryAppService
    {

        protected async Task<HrWorkEntry> CheckDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _check_duration) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> CheckIfErrorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _check_if_error) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> ComputeConflictInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _compute_conflict) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> ErrorCheckingInternalAsync(object start, object stop, object skip, List<Guid> employee_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _error_checking) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrWorkEntry> FromIntervalsInternalAsync(object intervals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _from_intervals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrWorkEntry> GetLeavesDurationBetweenTwoDatesInternalAsync(Guid employee_id, object date_from, object date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py, METHOD: _get_leaves_duration_between_two_dates) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> GetLeavesEntriesOutsideScheduleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _get_leaves_entries_outside_schedule) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> GetWorkEntryTypeDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _get_work_entry_type_domain) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> MarkAlreadyValidatedDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _mark_already_validated_days) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> MarkConflictingWorkEntriesInternalAsync(object start, object stop)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _mark_conflicting_work_entries) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> MarkLeavesOutsideScheduleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _mark_leaves_outside_schedule) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> OnchangeVersionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _onchange_version_id) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> ResetConflictingStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _reset_conflicting_state) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py, METHOD: _reset_conflicting_state) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrWorkEntry> SetCurrentContractInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _set_current_contract) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> ToIntervalsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _to_intervals) ---
            */
            return default;
        }

        protected async Task<HrWorkEntry> UnlinkExceptValidatedWorkEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: _unlink_except_validated_work_entries) ---
            */
            return default;
        }
    }
}