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
    public partial class CalendarEventAppService : GenericAppService<CalendarEvent>, ICalendarEventAppService
    {
        protected readonly IGoogleCalendarSyncAppService _googleCalendarSyncAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IMicrosoftCalendarSyncAppService _microsoftCalendarSyncAppService;
        public CalendarEventAppService(IRepository<CalendarEvent, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IGoogleCalendarSyncAppService googleCalendarSyncAppService, IMailThreadAppService mailThreadAppService, IMicrosoftCalendarSyncAppService microsoftCalendarSyncAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _googleCalendarSyncAppService = googleCalendarSyncAppService;
            _mailThreadAppService = mailThreadAppService;
            _microsoftCalendarSyncAppService = microsoftCalendarSyncAppService;
        }

        public async Task<CalendarEvent> ChangeAttendeeStatusAsync(CalendarEventChangeAttendeeStatusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: change_attendee_status) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> ClearVideocallLocationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: clear_videocall_location) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<CalendarEvent> CreateAsync(CreateRequestDto<CalendarEvent> input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: crm, FILE: calendar.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: calendar.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<CalendarEvent> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: crm, FILE: calendar.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: calendar.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<CalendarEvent> FindPartnerCustomerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: find_partner_customer) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CalendarEvent> GetDefaultDurationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_default_duration) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CalendarEvent> GetDiscussVideocallLocationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_discuss_videocall_location) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> GetDisplayTimeTzAsync(CalendarEventGetDisplayTimeTzRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_display_time_tz) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> GetNextAlarmDateAsync(CalendarEventGetNextAlarmDateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_next_alarm_date) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CalendarEvent> GetStateSelectionsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_state_selections) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<CalendarEvent> GetUnusualDaysAsync(CalendarEventGetUnusualDaysRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py, METHOD: get_unusual_days) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> JoinMeetingAsync(CalendarEventJoinMeetingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_join_meeting) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> JoinVideoCallAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_join_video_call) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> MassArchiveAsync(CalendarEventMassArchiveRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_mass_archive) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: action_mass_archive) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: action_mass_archive) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> MassDeletionAsync(CalendarEventMassDeletionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_mass_deletion) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> OpenCalendarEventAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_open_calendar_event) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> OpenComposerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_open_composer) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> SendSmsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_event.py, METHOD: action_send_sms) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> SendmailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_sendmail) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CalendarEvent> SetDiscussVideocallLocationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: set_discuss_videocall_location) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public async Task<CalendarEvent> UnlinkEventAsync(CalendarEventUnlinkEventRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_unlink_event) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<CalendarEvent> input)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}