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
    public partial class HrEmployeePublicAppService : GenericAppService<HrEmployeePublic>, IHrEmployeePublicAppService
    {

        public HrEmployeePublicAppService(IRepository<HrEmployeePublic, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<HrEmployeePublic> GetAvatarCardDataAsync(HrEmployeePublicGetAvatarCardDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: get_avatar_card_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployeePublic> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployeePublic> OpenCoursesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_employee_public.py, METHOD: action_open_courses) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployeePublic> OpenLastMonthAttendancesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee_public.py, METHOD: action_open_last_month_attendances) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployeePublic> OpenTimeOffCalendarAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py, METHOD: action_open_time_off_calendar) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployeePublic> TimeOffDashboardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py, METHOD: action_time_off_dashboard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployeePublic> TimesheetFromEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee_public.py, METHOD: action_timesheet_from_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}