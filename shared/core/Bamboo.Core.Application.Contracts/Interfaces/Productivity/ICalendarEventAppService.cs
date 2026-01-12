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
        Task<CalendarEvent> ChangeAttendeeStatusAsync(Guid id, CalendarEventChangeAttendeeStatusRequestDto input);
        Task<CalendarEvent> ClearVideocallLocationAsync(Guid id);
        Task<CalendarEvent> FindPartnerCustomerAsync(Guid id);
        Task<CalendarEvent> GetDefaultDurationAsync(Guid id);
        Task<CalendarEvent> GetDiscussVideocallLocationAsync(Guid id);
        Task<CalendarEvent> GetDisplayTimeTzAsync(Guid id, CalendarEventGetDisplayTimeTzRequestDto input);
        Task<CalendarEvent> GetNextAlarmDateAsync(Guid id, CalendarEventGetNextAlarmDateRequestDto input);
        Task<CalendarEvent> GetStateSelectionsAsync(Guid id);
        Task<CalendarEvent> GetUnusualDaysAsync(Guid id, CalendarEventGetUnusualDaysRequestDto input);
        Task<CalendarEvent> JoinMeetingAsync(Guid id, CalendarEventJoinMeetingRequestDto input);
        Task<CalendarEvent> JoinVideoCallAsync(Guid id);
        Task<CalendarEvent> MassArchiveAsync(Guid id, CalendarEventMassArchiveRequestDto input);
        Task<CalendarEvent> MassDeletionAsync(Guid id, CalendarEventMassDeletionRequestDto input);
        Task<CalendarEvent> OpenCalendarEventAsync(Guid id);
        Task<CalendarEvent> OpenComposerAsync(Guid id);
        Task<CalendarEvent> SendSmsAsync(Guid id);
        Task<CalendarEvent> SendmailAsync(Guid id);
        Task<CalendarEvent> SetDiscussVideocallLocationAsync(Guid id);
        Task<CalendarEvent> UnlinkEventAsync(Guid id, CalendarEventUnlinkEventRequestDto input);
    }
}