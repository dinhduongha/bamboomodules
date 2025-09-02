using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    public partial class MailingMailingController
    {
        
        [HttpPost]
        [Route("{id}/action-buy-sms-credits")]
        public async Task<IActionResult> ActionBuySmsCreditsAsync(Guid id)
        {
            var result = await _appService.BuySmsCreditsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-compare-versions")]
        public async Task<IActionResult> ActionCompareVersionsAsync(Guid id)
        {
            var result = await _appService.CompareVersionsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-duplicate")]
        public async Task<IActionResult> ActionDuplicateAsync(Guid id)
        {
            var result = await _appService.DuplicateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-fetch-favorites")]
        public async Task<IActionResult> ActionFetchFavoritesAsync(Guid id, [FromBody] MailingMailingFetchFavoritesRequestDto input)
        {
            var result = await _appService.FetchFavoritesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-launch")]
        public async Task<IActionResult> ActionLaunchAsync(Guid id)
        {
            var result = await _appService.LaunchAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-put-in-queue")]
        public async Task<IActionResult> ActionPutInQueueAsync(Guid id)
        {
            var result = await _appService.PutInQueueAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-invoiced")]
        public async Task<IActionResult> ActionRedirectToInvoicedAsync(Guid id)
        {
            var result = await _appService.RedirectToInvoicedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-leads-and-opportunities")]
        public async Task<IActionResult> ActionRedirectToLeadsAndOpportunitiesAsync(Guid id)
        {
            var result = await _appService.RedirectToLeadsAndOpportunitiesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-quotations")]
        public async Task<IActionResult> ActionRedirectToQuotationsAsync(Guid id)
        {
            var result = await _appService.RedirectToQuotationsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reload")]
        public async Task<IActionResult> ActionReloadAsync(Guid id)
        {
            var result = await _appService.ReloadAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-remove-favorite")]
        public async Task<IActionResult> ActionRemoveFavoriteAsync(Guid id)
        {
            var result = await _appService.RemoveFavoriteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-retry-failed")]
        public async Task<IActionResult> ActionRetryFailedAsync(Guid id)
        {
            var result = await _appService.RetryFailedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-retry-failed-sms")]
        public async Task<IActionResult> ActionRetryFailedSmsAsync(Guid id)
        {
            var result = await _appService.RetryFailedSmsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-schedule")]
        public async Task<IActionResult> ActionScheduleAsync(Guid id)
        {
            var result = await _appService.ScheduleAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-select-as-winner")]
        public async Task<IActionResult> ActionSelectAsWinnerAsync(Guid id)
        {
            var result = await _appService.SelectAsWinnerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-mail")]
        public async Task<IActionResult> ActionSendMailAsync(Guid id, [FromBody] MailingMailingSendMailRequestDto input)
        {
            var result = await _appService.SendMailAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-sms")]
        public async Task<IActionResult> ActionSendSmsAsync(Guid id, [FromBody] MailingMailingSendSmsRequestDto input)
        {
            var result = await _appService.SendSmsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-winner-mailing")]
        public async Task<IActionResult> ActionSendWinnerMailingAsync(Guid id)
        {
            var result = await _appService.SendWinnerMailingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-favorite")]
        public async Task<IActionResult> ActionSetFavoriteAsync(Guid id)
        {
            var result = await _appService.SetFavoriteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-test")]
        public async Task<IActionResult> ActionTestAsync(Guid id)
        {
            var result = await _appService.TestAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-update-cards")]
        public async Task<IActionResult> ActionUpdateCardsAsync(Guid id)
        {
            var result = await _appService.UpdateCardsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-bounced")]
        public async Task<IActionResult> ActionViewBouncedAsync(Guid id)
        {
            var result = await _appService.ViewBouncedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-clicked")]
        public async Task<IActionResult> ActionViewClickedAsync(Guid id)
        {
            var result = await _appService.ViewClickedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-delivered")]
        public async Task<IActionResult> ActionViewDeliveredAsync(Guid id)
        {
            var result = await _appService.ViewDeliveredAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-link-trackers")]
        public async Task<IActionResult> ActionViewLinkTrackersAsync(Guid id)
        {
            var result = await _appService.ViewLinkTrackersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mailing-contacts")]
        public async Task<IActionResult> ActionViewMailingContactsAsync(Guid id)
        {
            var result = await _appService.ViewMailingContactsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-opened")]
        public async Task<IActionResult> ActionViewOpenedAsync(Guid id)
        {
            var result = await _appService.ViewOpenedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-replied")]
        public async Task<IActionResult> ActionViewRepliedAsync(Guid id)
        {
            var result = await _appService.ViewRepliedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-traces-canceled")]
        public async Task<IActionResult> ActionViewTracesCanceledAsync(Guid id)
        {
            var result = await _appService.ViewTracesCanceledAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-traces-failed")]
        public async Task<IActionResult> ActionViewTracesFailedAsync(Guid id)
        {
            var result = await _appService.ViewTracesFailedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-traces-process")]
        public async Task<IActionResult> ActionViewTracesProcessAsync(Guid id)
        {
            var result = await _appService.ViewTracesProcessAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-traces-scheduled")]
        public async Task<IActionResult> ActionViewTracesScheduledAsync(Guid id)
        {
            var result = await _appService.ViewTracesScheduledAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-traces-sent")]
        public async Task<IActionResult> ActionViewTracesSentAsync(Guid id)
        {
            var result = await _appService.ViewTracesSentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/convert-links")]
        public async Task<IActionResult> ConvertLinksAsync(Guid id)
        {
            var result = await _appService.ConvertLinksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] MailingMailingCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-sms-link-replacements-placeholders")]
        public async Task<IActionResult> GetSmsLinkReplacementsPlaceholdersAsync(Guid id)
        {
            var result = await _appService.GetSmsLinkReplacementsPlaceholdersAsync(id);
            return Ok(result);
        }
    }
}