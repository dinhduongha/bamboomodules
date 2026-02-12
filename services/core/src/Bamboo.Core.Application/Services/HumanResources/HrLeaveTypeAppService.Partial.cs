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
    public partial class HrLeaveTypeAppService
    {

        protected async Task<HrLeaveType> AllocationsCountByLeaveTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _allocations_count_by_leave_type_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> CheckAllowRequestOnTopInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _check_allow_request_on_top) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> CheckElligibleForAccrualRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _check_elligible_for_accrual_rate) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> CheckOverlappingPublicHolidaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _check_overlapping_public_holidays) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeAccrualCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _compute_accrual_count) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeAllocationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _compute_allocation_count) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _compute_country_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_type.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeEligibleForAccrualRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _compute_eligible_for_accrual_rate) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeGroupDaysLeaveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _compute_group_days_leave) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeIsUsedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _compute_is_used) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeLeavesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _compute_leaves) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeValidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _compute_valid) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> GetCarriedOverDaysExpirationDataInternalAsync(object allocations, object target_date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _get_carried_over_days_expiration_data) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> GetClosestExpiringLeavesDateAndCountInternalAsync(object allocations, object remaining_leaves, object target_date)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _get_closest_expiring_leaves_date_and_count) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> LeavesCountByLeaveTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _leaves_count_by_leave_type_id) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> LoadRecordsWriteInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _load_records_write) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrLeaveType> ModelSortingKeyInternalAsync(object leave_type)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _model_sorting_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrLeaveType> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> SearchMaxLeavesInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _search_max_leaves) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrLeaveType> SearchValidInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _search_valid) ---
            */
            return default;
        }

        protected async Task<HrLeaveType> SearchVirtualRemainingLeavesInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: _search_virtual_remaining_leaves) ---
            */
            return default;
        }
    }
}