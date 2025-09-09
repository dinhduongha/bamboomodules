using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IMailingMailingAppService : IGenericApplicationService<MailingMailing>
    {
        Task<MailingMailing> BuySmsCreditsAsync(Guid id);
        Task<MailingMailing> CancelAsync(Guid id);
        Task<MailingMailing> CompareVersionsAsync(Guid id);
        Task<MailingMailing> ConvertLinksAsync(Guid id);
        Task<MailingMailing> CopyDataAsync(Guid id, MailingMailingCopyDataRequestDto input);
        Task<MailingMailing> DuplicateAsync(Guid id);
        Task<MailingMailing> FetchFavoritesAsync(Guid id, MailingMailingFetchFavoritesRequestDto input);
        Task<MailingMailing> GetSmsLinkReplacementsPlaceholdersAsync(Guid id);
        Task<MailingMailing> LaunchAsync(Guid id);
        Task<MailingMailing> PutInQueueAsync(Guid id);
        Task<MailingMailing> RedirectToInvoicedAsync(Guid id);
        Task<MailingMailing> RedirectToLeadsAndOpportunitiesAsync(Guid id);
        Task<MailingMailing> RedirectToQuotationsAsync(Guid id);
        Task<MailingMailing> ReloadAsync(Guid id);
        Task<MailingMailing> RemoveFavoriteAsync(Guid id);
        Task<MailingMailing> RetryFailedAsync(Guid id);
        Task<MailingMailing> RetryFailedSmsAsync(Guid id);
        Task<MailingMailing> ScheduleAsync(Guid id);
        Task<MailingMailing> SelectAsWinnerAsync(Guid id);
        Task<MailingMailing> SendMailAsync(Guid id, MailingMailingSendMailRequestDto input);
        Task<MailingMailing> SendSmsAsync(Guid id, MailingMailingSendSmsRequestDto input);
        Task<MailingMailing> SendWinnerMailingAsync(Guid id);
        Task<MailingMailing> SetFavoriteAsync(Guid id);
        Task<MailingMailing> TestAsync(Guid id);
        Task<MailingMailing> UpdateCardsAsync(Guid id);
        Task<MailingMailing> ViewBouncedAsync(Guid id);
        Task<MailingMailing> ViewClickedAsync(Guid id);
        Task<MailingMailing> ViewDeliveredAsync(Guid id);
        Task<MailingMailing> ViewLinkTrackersAsync(Guid id);
        Task<MailingMailing> ViewMailingContactsAsync(Guid id);
        Task<MailingMailing> ViewOpenedAsync(Guid id);
        Task<MailingMailing> ViewRepliedAsync(Guid id);
        Task<MailingMailing> ViewTracesCanceledAsync(Guid id);
        Task<MailingMailing> ViewTracesFailedAsync(Guid id);
        Task<MailingMailing> ViewTracesProcessAsync(Guid id);
        Task<MailingMailing> ViewTracesScheduledAsync(Guid id);
        Task<MailingMailing> ViewTracesSentAsync(Guid id);
    }
}