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
    [Module("Resource", Category = "Misc", Depends = new[] { "base", "web" })]
    public partial class ResourceCalendarAppService : GenericAppService<ResourceCalendar>, IResourceCalendarAppService
    {

        public ResourceCalendarAppService(IRepository<ResourceCalendar, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<ResourceCalendar> CopyDataAsync(ResourceCalendarCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResourceCalendar> GetWorkDurationDataAsync(ResourceCalendarGetWorkDurationDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: get_work_duration_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResourceCalendar> GetWorkHoursCountAsync(ResourceCalendarGetWorkHoursCountRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: get_work_hours_count) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResourceCalendar> PlanDaysAsync(ResourceCalendarPlanDaysRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: plan_days) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResourceCalendar> PlanHoursAsync(ResourceCalendarPlanHoursRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: plan_hours) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResourceCalendar> SwitchBasedOnDurationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: switch_based_on_duration) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResourceCalendar> SwitchCalendarTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py, METHOD: switch_calendar_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResourceCalendar> TransferLeavesToAsync(ResourceCalendarTransferLeavesToRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource_calendar.py, METHOD: transfer_leaves_to) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}