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
    public partial class HrEmployeePublicAppService
    {

        protected async Task<HrEmployeePublic> ComputeAllocationDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py, METHOD: _compute_allocation_display) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeBadgeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee_public.py, METHOD: _compute_badge_ids) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeChildAllCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _compute_child_all_count) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeChildCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _compute_child_count) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeCountryCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_country_code) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeDepartmentColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py, METHOD: _compute_department_color) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeFromEmployeeInternalAsync(object field_names)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_from_employee) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeHasBadgesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee_public.py, METHOD: _compute_has_badges) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeIsManagerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_is_manager) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeIsUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_is_user) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeLastActivityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_last_activity) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeLeaveManagerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py, METHOD: _compute_leave_manager) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeLeaveStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py, METHOD: _compute_leave_status) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeManagerOnlyFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_manager_only_fields) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeMemberOfDepartmentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_member_of_department) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeNewlyHiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_newly_hired) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputePresenceIconInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_presence_icon) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputePresenceStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _compute_presence_state) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeShowLeavesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py, METHOD: _compute_show_leaves) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrEmployeePublic> GetFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _get_fields) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> GetManagerOnlyFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _get_manager_only_fields) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> GetSelectionHrIconDisplayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _get_selection_hr_icon_display) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> GetValidEmployeeForUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _get_valid_employee_for_user) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> SearchAbsentEmployeeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py, METHOD: _search_absent_employee) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> SearchFilterForExpenseInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee_public.py, METHOD: _search_filter_for_expense) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> SearchNewlyHiredInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _search_newly_hired) ---
            */
            return default;
        }

        protected async Task<HrEmployeePublic> SearchPartOfDepartmentInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: _search_part_of_department) ---
            */
            return default;
        }
    }
}