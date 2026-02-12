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
    public partial class ResourceCalendarLeavesAppService : GenericAppService<ResourceCalendarLeaves>, IResourceCalendarLeavesAppService
    {

        public ResourceCalendarLeavesAppService(IRepository<ResourceCalendarLeaves, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<ResourceCalendarLeaves> CheckDatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py, METHOD: check_dates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ResourceCalendarLeaves> CreateAsync(CreateRequestDto<ResourceCalendarLeaves> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ResourceCalendarLeaves> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}