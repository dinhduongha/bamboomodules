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
    public partial class ResourceCalendarAttendanceAppService : GenericAppService<ResourceCalendarAttendance>, IResourceCalendarAttendanceAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResourceCalendarAttendanceAppService(IRepository<ResourceCalendarAttendance, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        [ApiModel]
        public async Task<ResourceCalendarAttendance> GetWeekTypeAsync(ResourceCalendarAttendanceGetWeekTypeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py, METHOD: get_week_type) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}