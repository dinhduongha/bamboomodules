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
    public interface IMailActivityAppService : IGenericAppService<MailActivity>
    {
        Task<MailActivity> ActivityFormatAsync(Guid[] ids);
        Task<MailActivity> CancelAsync(Guid[] ids);
        Task<MailActivity> CloseDialogAsync(Guid[] ids);
        Task<MailActivity> CreateCalendarEventAsync(Guid[] ids);
        Task<MailActivity> DoneAsync(Guid[] ids);
        Task<MailActivity> DoneRedirectToOtherAsync(Guid[] ids);
        Task<MailActivity> DoneScheduleNextAsync(Guid[] ids);
        Task<MailActivity> FeedbackAsync(MailActivityFeedbackRequestDto input);
        Task<MailActivity> FeedbackScheduleNextAsync(MailActivityFeedbackScheduleNextRequestDto input);
        Task<MailActivity> GetActivityDataAsync(MailActivityGetActivityDataRequestDto input);
        Task<MailActivity> NotifyAsync(Guid[] ids);
        Task<MailActivity> OpenDocumentAsync(Guid[] ids);
        Task<MailActivity> RescheduleNextweekAsync(Guid[] ids);
        Task<MailActivity> RescheduleTodayAsync(Guid[] ids);
        Task<MailActivity> RescheduleTomorrowAsync(Guid[] ids);
        Task<MailActivity> UnlinkWMeetingAsync(Guid[] ids);
    }
}