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
    public interface IMailActivityAppService : IGenericApplicationService<MailActivity>
    {
        Task<MailActivity> ActivityFormatAsync(Guid id);
        Task<MailActivity> CancelAsync(Guid id);
        Task<MailActivity> CloseDialogAsync(Guid id);
        Task<MailActivity> CreateCalendarEventAsync(Guid id);
        Task<MailActivity> DoneAsync(Guid id);
        Task<MailActivity> DoneRedirectToOtherAsync(Guid id);
        Task<MailActivity> DoneScheduleNextAsync(Guid id);
        Task<MailActivity> FeedbackAsync(Guid id, MailActivityFeedbackRequestDto input);
        Task<MailActivity> FeedbackScheduleNextAsync(Guid id, MailActivityFeedbackScheduleNextRequestDto input);
        Task<MailActivity> GetActivityDataAsync(Guid id, MailActivityGetActivityDataRequestDto input);
        Task<MailActivity> NotifyAsync(Guid id);
        Task<MailActivity> OpenDocumentAsync(Guid id);
        Task<MailActivity> SnoozeAsync(Guid id);
        Task<MailActivity> UnlinkWMeetingAsync(Guid id);
    }
}