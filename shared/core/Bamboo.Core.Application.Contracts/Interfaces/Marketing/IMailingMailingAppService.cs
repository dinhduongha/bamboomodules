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
    public interface IMailingMailingAppService : IGenericAppService<MailingMailing>
    {
        Task<MailingMailing> BuySmsCreditsAsync(Guid[] ids);
        Task<MailingMailing> CancelAsync(Guid[] ids);
        Task<MailingMailing> CompareVersionsAsync(Guid[] ids);
        Task<MailingMailing> ConvertLinksAsync(Guid[] ids);
        Task<MailingMailing> CopyDataAsync(MailingMailingCopyDataRequestDto input);
        Task<MailingMailing> DuplicateAsync(Guid[] ids);
        Task<MailingMailing> FetchFavoritesAsync(MailingMailingFetchFavoritesRequestDto input);
        Task<MailingMailing> GetSmsLinkReplacementsPlaceholdersAsync(Guid[] ids);
        Task<MailingMailing> LaunchAsync(Guid[] ids);
        Task<MailingMailing> PutInQueueAsync(Guid[] ids);
        Task<MailingMailing> RedirectToInvoicedAsync(Guid[] ids);
        Task<MailingMailing> RedirectToLeadsAndOpportunitiesAsync(Guid[] ids);
        Task<MailingMailing> RedirectToQuotationsAsync(Guid[] ids);
        Task<MailingMailing> ReloadAsync(Guid[] ids);
        Task<MailingMailing> RemoveFavoriteAsync(Guid[] ids);
        Task<MailingMailing> RetryFailedAsync(Guid[] ids);
        Task<MailingMailing> RetryFailedSmsAsync(Guid[] ids);
        Task<MailingMailing> ScheduleAsync(Guid[] ids);
        Task<MailingMailing> SelectAsWinnerAsync(Guid[] ids);
        Task<MailingMailing> SendMailAsync(MailingMailingSendMailRequestDto input);
        Task<MailingMailing> SendSmsAsync(MailingMailingSendSmsRequestDto input);
        Task<MailingMailing> SendWinnerMailingAsync(Guid[] ids);
        Task<MailingMailing> SetFavoriteAsync(Guid[] ids);
        Task<MailingMailing> TestAsync(Guid[] ids);
        Task<MailingMailing> UpdateCardsAsync(Guid[] ids);
        Task<MailingMailing> ViewBouncedAsync(Guid[] ids);
        Task<MailingMailing> ViewClickedAsync(Guid[] ids);
        Task<MailingMailing> ViewDeliveredAsync(Guid[] ids);
        Task<MailingMailing> ViewLinkTrackersAsync(Guid[] ids);
        Task<MailingMailing> ViewMailingContactsAsync(Guid[] ids);
        Task<MailingMailing> ViewOpenedAsync(Guid[] ids);
        Task<MailingMailing> ViewRepliedAsync(Guid[] ids);
        Task<MailingMailing> ViewTracesCanceledAsync(Guid[] ids);
        Task<MailingMailing> ViewTracesFailedAsync(Guid[] ids);
        Task<MailingMailing> ViewTracesProcessAsync(Guid[] ids);
        Task<MailingMailing> ViewTracesScheduledAsync(Guid[] ids);
        Task<MailingMailing> ViewTracesSentAsync(Guid[] ids);
    }
}