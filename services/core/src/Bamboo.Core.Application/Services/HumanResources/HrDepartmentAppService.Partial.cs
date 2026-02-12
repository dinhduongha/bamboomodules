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
    public partial class HrDepartmentAppService
    {

        protected async Task<HrDepartment> CheckParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeExpensesToApproveCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_department.py, METHOD: _compute_expenses_to_approve_count) ---
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeLeaveCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_department.py, METHOD: _compute_leave_count) ---
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeMasterDepartmentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_master_department_id) ---
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeNewApplicantCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_department.py, METHOD: _compute_new_applicant_count) ---
            */
            return default;
        }

        protected async Task<HrDepartment> ComputePlanCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_plan_count) ---
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeRecruitmentStatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_department.py, METHOD: _compute_recruitment_stats) ---
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeTotalEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_total_employee) ---
            */
            return default;
        }

        protected async Task<HrDepartment> GetActionContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_department.py, METHOD: _get_action_context) ---
            */
            return default;
        }

        protected async Task<HrDepartment> SearchCompleteNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _search_complete_name) ---
            */
            return default;
        }

        protected async Task<HrDepartment> SearchHasReadAccessInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _search_has_read_access) ---
            */
            return default;
        }

        protected async Task<HrDepartment> UpdateEmployeeManagerInternalAsync(Guid manager_id)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _update_employee_manager) ---
            */
            return default;
        }
    }
}