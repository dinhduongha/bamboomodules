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
    public partial class CalendarAttendeeAppService : GenericAppService<CalendarAttendee>, ICalendarAttendeeAppService
    {

        public CalendarAttendeeAppService(IRepository<CalendarAttendee, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<CalendarAttendee> DoAcceptAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: do_accept) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_attendee.py, METHOD: do_accept) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_attendee.py, METHOD: do_accept) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarAttendee> DoDeclineAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: do_decline) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_attendee.py, METHOD: do_decline) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_attendee.py, METHOD: do_decline) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarAttendee> DoTentativeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: do_tentative) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_attendee.py, METHOD: do_tentative) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_attendee.py, METHOD: do_tentative) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}