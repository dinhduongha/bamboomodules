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
    [Module("Calendar", Category = "Productivity", Depends = new[] { "base", "mail" })]
    public partial class CalendarRecurrenceAppService : GenericAppService<CalendarRecurrence>, ICalendarRecurrenceAppService
    {
        protected readonly IGoogleCalendarSyncAppService _googleCalendarSyncAppService;
        protected readonly IMicrosoftCalendarSyncAppService _microsoftCalendarSyncAppService;
        public CalendarRecurrenceAppService(IRepository<CalendarRecurrence, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IGoogleCalendarSyncAppService googleCalendarSyncAppService, IMicrosoftCalendarSyncAppService microsoftCalendarSyncAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _googleCalendarSyncAppService = googleCalendarSyncAppService;
            _microsoftCalendarSyncAppService = microsoftCalendarSyncAppService;
        }

        public async Task<CalendarRecurrence> GetRecurrenceNameAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: get_recurrence_name) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}