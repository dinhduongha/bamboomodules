using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface ICalendarEventAppService : IGenericApplicationService<CalendarEvent>
    {
        Task<CalendarEvent> ChangeAttendeeStatusAsync(CalendarEventChangeAttendeeStatusRequestDto input);
        Task<CalendarEvent> ClearVideocallLocationAsync(Guid[] ids);
        Task<CalendarEvent> FindPartnerCustomerAsync(Guid[] ids);
        Task<CalendarEvent> GetDefaultDurationAsync(Guid[] ids);
        Task<CalendarEvent> GetDiscussVideocallLocationAsync(Guid[] ids);
        Task<CalendarEvent> GetDisplayTimeTzAsync(CalendarEventGetDisplayTimeTzRequestDto input);
        Task<CalendarEvent> GetNextAlarmDateAsync(CalendarEventGetNextAlarmDateRequestDto input);
        Task<CalendarEvent> GetStateSelectionsAsync(Guid[] ids);
        Task<CalendarEvent> GetUnusualDaysAsync(CalendarEventGetUnusualDaysRequestDto input);
        Task<CalendarEvent> JoinMeetingAsync(CalendarEventJoinMeetingRequestDto input);
        Task<CalendarEvent> JoinVideoCallAsync(Guid[] ids);
        Task<CalendarEvent> MassArchiveAsync(CalendarEventMassArchiveRequestDto input);
        Task<CalendarEvent> MassDeletionAsync(CalendarEventMassDeletionRequestDto input);
        Task<CalendarEvent> OpenCalendarEventAsync(Guid[] ids);
        Task<CalendarEvent> OpenComposerAsync(Guid[] ids);
        Task<CalendarEvent> SendSmsAsync(Guid[] ids);
        Task<CalendarEvent> SendmailAsync(Guid[] ids);
        Task<CalendarEvent> SetDiscussVideocallLocationAsync(Guid[] ids);
        Task<CalendarEvent> UnlinkEventAsync(CalendarEventUnlinkEventRequestDto input);
    }
}