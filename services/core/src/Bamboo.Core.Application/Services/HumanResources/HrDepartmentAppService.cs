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
    [Module("Hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public partial class HrDepartmentAppService : GenericAppService<HrDepartment>, IHrDepartmentAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public HrDepartmentAppService(IRepository<HrDepartment, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<HrDepartment> EmployeeFromDepartmentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: action_employee_from_department) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrDepartment> GetChildrenDepartmentIdsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: get_children_department_ids) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrDepartment> GetDepartmentHierarchyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: get_department_hierarchy) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrDepartment> GetFormviewActionAsync(HrDepartmentGetFormviewActionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: get_formview_action) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrDepartment> OpenAllocationDepartmentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_department.py, METHOD: action_open_allocation_department) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrDepartment> OpenLeaveDepartmentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_department.py, METHOD: action_open_leave_department) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrDepartment> OpenViewChildDepartmentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: action_open_view_child_departments) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrDepartment> PlanFromDepartmentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: action_plan_from_department) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}