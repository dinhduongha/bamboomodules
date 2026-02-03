using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailingMailingController
    {
        
        [HttpPost]
        [Route("action-buy-sms-credits")]
        public async Task<IActionResult> ActionBuySmsCreditsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BuySmsCreditsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-compare-versions")]
        public async Task<IActionResult> ActionCompareVersionsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CompareVersionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-duplicate")]
        public async Task<IActionResult> ActionDuplicateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DuplicateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-fetch-favorites")]
        public async Task<IActionResult> ActionFetchFavoritesAsync(MailingMailingFetchFavoritesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FetchFavoritesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-launch")]
        public async Task<IActionResult> ActionLaunchAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LaunchAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-put-in-queue")]
        public async Task<IActionResult> ActionPutInQueueAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PutInQueueAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-invoiced")]
        public async Task<IActionResult> ActionRedirectToInvoicedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToInvoicedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-leads-and-opportunities")]
        public async Task<IActionResult> ActionRedirectToLeadsAndOpportunitiesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToLeadsAndOpportunitiesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-quotations")]
        public async Task<IActionResult> ActionRedirectToQuotationsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToQuotationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reload")]
        public async Task<IActionResult> ActionReloadAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReloadAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-remove-favorite")]
        public async Task<IActionResult> ActionRemoveFavoriteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RemoveFavoriteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-retry-failed")]
        public async Task<IActionResult> ActionRetryFailedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RetryFailedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-retry-failed-sms")]
        public async Task<IActionResult> ActionRetryFailedSmsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RetryFailedSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-schedule")]
        public async Task<IActionResult> ActionScheduleAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ScheduleAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-select-as-winner")]
        public async Task<IActionResult> ActionSelectAsWinnerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SelectAsWinnerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mail")]
        public async Task<IActionResult> ActionSendMailAsync(MailingMailingSendMailRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendMailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-sms")]
        public async Task<IActionResult> ActionSendSmsAsync(MailingMailingSendSmsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendSmsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-winner-mailing")]
        public async Task<IActionResult> ActionSendWinnerMailingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendWinnerMailingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-favorite")]
        public async Task<IActionResult> ActionSetFavoriteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetFavoriteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-test")]
        public async Task<IActionResult> ActionTestAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-cards")]
        public async Task<IActionResult> ActionUpdateCardsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateCardsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-bounced")]
        public async Task<IActionResult> ActionViewBouncedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewBouncedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-clicked")]
        public async Task<IActionResult> ActionViewClickedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewClickedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-delivered")]
        public async Task<IActionResult> ActionViewDeliveredAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewDeliveredAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-link-trackers")]
        public async Task<IActionResult> ActionViewLinkTrackersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewLinkTrackersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mailing-contacts")]
        public async Task<IActionResult> ActionViewMailingContactsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMailingContactsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-opened")]
        public async Task<IActionResult> ActionViewOpenedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewOpenedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-replied")]
        public async Task<IActionResult> ActionViewRepliedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRepliedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-canceled")]
        public async Task<IActionResult> ActionViewTracesCanceledAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTracesCanceledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-failed")]
        public async Task<IActionResult> ActionViewTracesFailedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTracesFailedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-process")]
        public async Task<IActionResult> ActionViewTracesProcessAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTracesProcessAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-scheduled")]
        public async Task<IActionResult> ActionViewTracesScheduledAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTracesScheduledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-sent")]
        public async Task<IActionResult> ActionViewTracesSentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTracesSentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-links")]
        public async Task<IActionResult> ConvertLinksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConvertLinksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(MailingMailingCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-sms-link-replacements-placeholders")]
        public async Task<IActionResult> GetSmsLinkReplacementsPlaceholdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetSmsLinkReplacementsPlaceholdersAsync(ids);
            return Ok(result);
        }
    }
}