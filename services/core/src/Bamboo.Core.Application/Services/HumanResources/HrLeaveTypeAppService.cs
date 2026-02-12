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
    [Module("HrHolidays", Category = "HumanResources", Depends = new[] { "hr", "calendar", "resource" })]
    public partial class HrLeaveTypeAppService : GenericAppService<HrLeaveType>, IHrLeaveTypeAppService
    {

        public HrLeaveTypeAppService(IRepository<HrLeaveType, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<HrLeaveType> CheckAllocationRequirementEditValidityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: check_allocation_requirement_edit_validity) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveType> CopyDataAsync(HrLeaveTypeCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveType> GetAllocationDataAsync(HrLeaveTypeGetAllocationDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: get_allocation_data) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_type.py, METHOD: get_allocation_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrLeaveType> GetAllocationDataRequestAsync(HrLeaveTypeGetAllocationDataRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: get_allocation_data_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrLeaveType> HasAccrualAllocationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: has_accrual_allocation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveType> RequestedDisplayNameAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: requested_display_name) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveType> SeeAccrualPlansAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: action_see_accrual_plans) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveType> SeeDaysAllocatedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: action_see_days_allocated) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveType> SeeGroupLeavesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py, METHOD: action_see_group_leaves) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}