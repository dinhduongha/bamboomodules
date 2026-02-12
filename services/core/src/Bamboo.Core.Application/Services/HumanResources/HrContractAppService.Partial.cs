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
    public partial class HrContractAppService
    {

        protected async Task<HrContract> AssignOpenContractInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _assign_open_contract) ---
            */
            return default;
        }

        protected async Task<HrContract> CancelWorkEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _cancel_work_entries) ---
            */
            return default;
        }

        protected async Task<HrContract> CheckContractsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_contract, FILE: hr_contract.py, METHOD: _check_contracts) ---
            */
            return default;
        }

        protected async Task<HrContract> CheckCurrentContractInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _check_current_contract) ---
            */
            return default;
        }

        protected async Task<HrContract> CheckDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _check_dates) ---
            */
            return default;
        }

        protected async Task<HrContract> ComputeCalendarMismatchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _compute_calendar_mismatch) ---
            */
            return default;
        }

        protected async Task<HrContract> ComputeContractWageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _compute_contract_wage) ---
            */
            return default;
        }

        protected async Task<HrContract> ComputeEmployeeContractInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _compute_employee_contract) ---
            */
            return default;
        }

        protected async Task<HrContract> ComputeStructureTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _compute_structure_type_id) ---
            */
            return default;
        }

        protected async Task<HrContract> ComputeWorkEntrySourceCalendarInvalidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _compute_work_entry_source_calendar_invalid) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrContract> CronGenerateMissingWorkEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _cron_generate_missing_work_entries) ---
            */
            return default;
        }

        protected async Task<HrContract> GenerateWorkEntriesInternalAsync(object date_start, object date_stop, object force)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _generate_work_entries) ---
            */
            return default;
        }

        protected async Task<HrContract> GetAttendanceIntervalsInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_attendance_intervals) ---
            */
            return default;
        }

        protected async Task<HrContract> GetBypassingWorkEntryTypeCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_bypassing_work_entry_type_codes) ---
            */
            return default;
        }

        protected async Task<HrContract> GetContractWageFieldInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _get_contract_wage_field) ---
            */
            return default;
        }

        protected async Task<HrContract> GetContractWageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _get_contract_wage) ---
            */
            return default;
        }

        protected async Task<HrContract> GetContractWorkEntriesValuesInternalAsync(object date_start, object date_stop)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_contract_work_entries_values) ---
            */
            return default;
        }

        protected async Task<HrContract> GetDefaultWorkEntryTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_default_work_entry_type_id) ---
            */
            return default;
        }

        protected async Task<HrContract> GetEmployeeValsToUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _get_employee_vals_to_update) ---
            */
            return default;
        }

        protected async Task<HrContract> GetFieldsThatRecomputeWeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_fields_that_recompute_we) ---
            */
            return default;
        }

        protected async Task<HrContract> GetHrResponsibleDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _get_hr_responsible_domain) ---
            */
            return default;
        }

        protected async Task<HrContract> GetIntervalLeaveWorkEntryTypeInternalAsync(object interval, object leaves, object bypassing_codes)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_interval_leave_work_entry_type) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_contract.py, METHOD: _get_interval_leave_work_entry_type) ---
            */
            return default;
        }

        protected async Task<HrContract> GetIntervalWorkEntryTypeInternalAsync(object interval)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_interval_work_entry_type) ---
            */
            return default;
        }

        protected async Task<HrContract> GetLeaveDomainInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_leave_domain) ---
            */
            return default;
        }

        protected async Task<HrContract> GetLeaveWorkEntryTypeDatesInternalAsync(object leave, object date_from, object date_to, object employee)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_leave_work_entry_type_dates) ---
            */
            return default;
        }

        protected async Task<HrContract> GetLeaveWorkEntryTypeInternalAsync(object leave)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_leave_work_entry_type) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_contract.py, METHOD: _get_leave_work_entry_type) ---
            */
            return default;
        }

        protected async Task<HrContract> GetLeavesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_contract, FILE: hr_contract.py, METHOD: _get_leaves) ---
            */
            return default;
        }

        protected async Task<HrContract> GetLunchIntervalsInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_lunch_intervals) ---
            */
            return default;
        }

        protected async Task<HrContract> GetMoreValsAttendanceIntervalInternalAsync(object interval)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_more_vals_attendance_interval) ---
            */
            return default;
        }

        protected async Task<HrContract> GetMoreValsLeaveIntervalInternalAsync(object interval, object leaves)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_more_vals_leave_interval) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_contract.py, METHOD: _get_more_vals_leave_interval) ---
            */
            return default;
        }

        protected async Task<HrContract> GetResourceCalendarLeavesInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_resource_calendar_leaves) ---
            */
            return default;
        }

        protected async Task<HrContract> GetSalaryCostsFactorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _get_salary_costs_factor) ---
            */
            return default;
        }

        protected async Task<HrContract> GetSubLeaveDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_sub_leave_domain) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_contract.py, METHOD: _get_sub_leave_domain) ---
            */
            return default;
        }

        protected async Task<HrContract> GetValidLeaveIntervalsInternalAsync(object attendances, object interval)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_valid_leave_intervals) ---
            */
            return default;
        }

        protected async Task<HrContract> GetWorkEntriesValuesInternalAsync(object date_start, object date_stop)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _get_work_entries_values) ---
            */
            return default;
        }

        protected async Task<HrContract> IsFullyFlexibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _is_fully_flexible) ---
            */
            return default;
        }

        protected async Task<HrContract> IsStructFromCountryInternalAsync(object country_code)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _is_struct_from_country) ---
            */
            return default;
        }

        protected async Task<HrContract> OnchangeStructureTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _onchange_structure_type_id) ---
            */
            return default;
        }

        protected async Task<HrContract> RecomputeWorkEntriesInternalAsync(object date_from, object date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _recompute_work_entries) ---
            */
            return default;
        }

        protected async Task<HrContract> RemoveWorkEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: _remove_work_entries) ---
            */
            return default;
        }

        protected async Task<HrContract> SafeWriteForCronInternalAsync(object vals, object from_cron)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _safe_write_for_cron) ---
            */
            return default;
        }

        protected async Task<HrContract> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: _track_subtype) ---
            */
            return default;
        }
    }
}