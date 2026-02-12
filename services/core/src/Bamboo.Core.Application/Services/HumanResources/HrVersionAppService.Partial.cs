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
    public partial class HrVersionAppService
    {

        protected async Task<HrVersion> CancelWorkEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _cancel_work_entries) ---
            */
            return default;
        }

        protected async Task<HrVersion> CheckContractsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py, METHOD: _check_contracts) ---
            */
            return default;
        }

        protected async Task<HrVersion> CheckDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _check_dates) ---
            */
            return default;
        }

        protected async Task<HrVersion> CheckOverlappingContractInternalAsync(object leave)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py, METHOD: _check_overlapping_contract) ---
            */
            return default;
        }

        protected async Task<HrVersion> CheckSsnidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _check_ssnid) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeAllowedCountryStateIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_allowed_country_state_ids) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeContractWageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_contract_wage) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_dates) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsCurrentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_current) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsCustomJobTitleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_custom_job_title) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsFlexibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_flexible) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsFutureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_future) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsInContractInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_in_contract) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeIsPastInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_past) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeJobTitleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_job_title) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeKmHomeWorkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_km_home_work) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputePartOfDepartmentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_part_of_department) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeStructureTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_structure_type_id) ---
            */
            return default;
        }

        protected async Task<HrVersion> ComputeWorkEntrySourceCalendarInvalidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _compute_work_entry_source_calendar_invalid) ---
            */
            return default;
        }

        protected async Task<HrVersion> CreateAllNewLeaveInternalAsync(object all_new_leave_origin, object all_new_leave_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py, METHOD: _create_all_new_leave) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrVersion> CronGenerateMissingWorkEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _cron_generate_missing_work_entries) ---
            */
            return default;
        }

        protected async Task<HrVersion> DefaultSalaryStructureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _default_salary_structure) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrVersion> DomainCurrentCountriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_version.py, METHOD: _domain_current_countries) ---
            */
            return default;
        }

        protected async Task<HrVersion> GenerateWorkEntriesInternalAsync(object date_start, object date_stop, object force)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _generate_work_entries) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrVersion> GenerateWorkEntriesPostprocessAdaptToCalendarInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _generate_work_entries_postprocess_adapt_to_calendar) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py, METHOD: _generate_work_entries_postprocess_adapt_to_calendar) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrVersion> GenerateWorkEntriesPostprocessInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _generate_work_entries_postprocess) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetAttendanceIntervalsInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_attendance_intervals) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetBypassingWorkEntryTypeCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_bypassing_work_entry_type_codes) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetContractWageFieldInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_contract_wage_field) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetContractWageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_contract_wage) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetDefaultAddressIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_default_address_id) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetDefaultWorkEntryTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_default_work_entry_type_id) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetDefaultWorkEntryTypeOvertimeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_default_work_entry_type_overtime_id) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetFieldsThatRecomputeWeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_fields_that_recompute_we) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetHrResponsibleDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_hr_responsible_domain) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetIntervalLeaveWorkEntryTypeInternalAsync(object interval, object leaves, object bypassing_codes)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_interval_leave_work_entry_type) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py, METHOD: _get_interval_leave_work_entry_type) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetIntervalWorkEntryTypeInternalAsync(object interval)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_interval_work_entry_type) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetLeaveDomainInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_leave_domain) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetLeaveWorkEntryTypeDatesInternalAsync(object leave, object date_from, object date_to, object employee)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_leave_work_entry_type_dates) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetLeaveWorkEntryTypeInternalAsync(object leave)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_leave_work_entry_type) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py, METHOD: _get_leave_work_entry_type) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetLeavesFromValsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py, METHOD: _get_leaves_from_vals) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetLeavesInternalAsync(object extra_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py, METHOD: _get_leaves) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetLunchIntervalsInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_lunch_intervals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrVersion> GetMaritalStatusSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_marital_status_selection) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetMoreValsAttendanceIntervalInternalAsync(object interval)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_more_vals_attendance_interval) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetMoreValsLeaveIntervalInternalAsync(object interval, object leaves)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_more_vals_leave_interval) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py, METHOD: _get_more_vals_leave_interval) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetNormalizedWageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_normalized_wage) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetRealAttendanceWorkEntryValsInternalAsync(object intervals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_real_attendance_work_entry_vals) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetRealAttendancesInternalAsync(object attendances, object leaves, object worked_leaves)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_real_attendances) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetResourceCalendarLeavesInternalAsync(object start_dt, object end_dt)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_resource_calendar_leaves) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetSalaryCostsFactorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_salary_costs_factor) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetSubLeaveDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_sub_leave_domain) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_version.py, METHOD: _get_sub_leave_domain) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetTzInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_tz) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetValidEmployeeForUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_valid_employee_for_user) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetValidLeaveIntervalsInternalAsync(object attendances, object interval)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_valid_leave_intervals) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetVersionWorkEntriesValuesInternalAsync(object date_start, object date_stop)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_version_work_entries_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrVersion> GetVersionsByEmployeeAndDateInternalAsync(object employee_dates)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_version.py, METHOD: _get_versions_by_employee_and_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrVersion> GetWhitelistFieldsFromTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_whitelist_fields_from_template) ---
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_whitelist_fields_from_template) ---
            */
            return default;
        }

        protected async Task<HrVersion> GetWorkEntriesValuesInternalAsync(object date_start, object date_stop)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _get_work_entries_values) ---
            */
            return default;
        }

        protected async Task<HrVersion> InverseJobTitleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _inverse_job_title) ---
            */
            return default;
        }

        protected async Task<HrVersion> InverseKmHomeWorkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _inverse_km_home_work) ---
            */
            return default;
        }

        protected async Task<HrVersion> InverseResourceCalendarIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _inverse_resource_calendar_id) ---
            */
            return default;
        }

        protected async Task<HrVersion> IsFullyFlexibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _is_fully_flexible) ---
            */
            return default;
        }

        protected async Task<HrVersion> IsInContractInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _is_in_contract) ---
            */
            return default;
        }

        protected async Task<HrVersion> IsOverlappingPeriodInternalAsync(object date_from, object date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _is_overlapping_period) ---
            */
            return default;
        }

        protected async Task<HrVersion> IsStructFromCountryInternalAsync(object country_code)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _is_struct_from_country) ---
            */
            return default;
        }

        protected async Task<HrVersion> PopulateAllNewLeaveValsFromSplitLeaveInternalAsync(object all_new_leave_origin, object all_new_leave_vals, object overlapping_contracts, object leave, object leaves_state)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py, METHOD: _populate_all_new_leave_vals_from_split_leave) ---
            */
            return default;
        }

        protected async Task<HrVersion> RecomputeWorkEntriesInternalAsync(object date_from, object date_to)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _recompute_work_entries) ---
            */
            return default;
        }

        protected async Task<HrVersion> RefuseLeaveInternalAsync(object leave, object leaves_state)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py, METHOD: _refuse_leave) ---
            */
            return default;
        }

        protected async Task<HrVersion> RemoveWorkEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: _remove_work_entries) ---
            */
            return default;
        }

        protected async Task<HrVersion> SearchEndDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _search_end_date) ---
            */
            return default;
        }

        protected async Task<HrVersion> SearchPartOfDepartmentInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _search_part_of_department) ---
            */
            return default;
        }

        protected async Task<HrVersion> SearchStartDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _search_start_date) ---
            */
            return default;
        }

        protected async Task<HrVersion> UnlinkExceptLastVersionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _unlink_except_last_version) ---
            */
            return default;
        }
    }
}