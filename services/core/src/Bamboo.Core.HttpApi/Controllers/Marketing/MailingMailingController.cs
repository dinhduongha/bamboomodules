using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/MailingMailing")]
    public partial class MailingMailingController : AbpController
    {
        protected readonly IMailingMailingAppService _appService;
        public MailingMailingController(IMailingMailingAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-buy-sms-credits")]
        public async Task<IActionResult> BuySmsCreditsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BuySmsCreditsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-compare-versions")]
        public async Task<IActionResult> CompareVersionsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CompareVersionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-duplicate")]
        public async Task<IActionResult> DuplicateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DuplicateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-fetch-favorites")]
        public async Task<IActionResult> FetchFavoritesAsync([FromBody] MailingMailingFetchFavoritesRequestDto input)
        {
            var result = await _appService.FetchFavoritesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-launch")]
        public async Task<IActionResult> LaunchAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LaunchAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-put-in-queue")]
        public async Task<IActionResult> PutInQueueAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PutInQueueAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-invoiced")]
        public async Task<IActionResult> RedirectToInvoicedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToInvoicedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-leads-and-opportunities")]
        public async Task<IActionResult> RedirectToLeadsAndOpportunitiesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToLeadsAndOpportunitiesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-quotations")]
        public async Task<IActionResult> RedirectToQuotationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToQuotationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reload")]
        public async Task<IActionResult> ReloadAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReloadAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-remove-favorite")]
        public async Task<IActionResult> RemoveFavoriteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RemoveFavoriteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-retry-failed")]
        public async Task<IActionResult> RetryFailedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RetryFailedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-retry-failed-sms")]
        public async Task<IActionResult> RetryFailedSmsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RetryFailedSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-schedule")]
        public async Task<IActionResult> ScheduleAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ScheduleAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-select-as-winner")]
        public async Task<IActionResult> SelectAsWinnerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SelectAsWinnerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mail")]
        public async Task<IActionResult> SendMailAsync([FromBody] MailingMailingSendMailRequestDto input)
        {
            var result = await _appService.SendMailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-sms")]
        public async Task<IActionResult> SendSmsAsync([FromBody] MailingMailingSendSmsRequestDto input)
        {
            var result = await _appService.SendSmsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-winner-mailing")]
        public async Task<IActionResult> SendWinnerMailingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendWinnerMailingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-favorite")]
        public async Task<IActionResult> SetFavoriteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetFavoriteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-test")]
        public async Task<IActionResult> TestAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-cards")]
        public async Task<IActionResult> UpdateCardsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateCardsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-bounced")]
        public async Task<IActionResult> ViewBouncedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewBouncedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-clicked")]
        public async Task<IActionResult> ViewClickedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewClickedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-delivered")]
        public async Task<IActionResult> ViewDeliveredAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewDeliveredAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-link-trackers")]
        public async Task<IActionResult> ViewLinkTrackersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewLinkTrackersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mailing-contacts")]
        public async Task<IActionResult> ViewMailingContactsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMailingContactsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-opened")]
        public async Task<IActionResult> ViewOpenedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewOpenedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-replied")]
        public async Task<IActionResult> ViewRepliedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRepliedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-canceled")]
        public async Task<IActionResult> ViewTracesCanceledAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTracesCanceledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-failed")]
        public async Task<IActionResult> ViewTracesFailedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTracesFailedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-process")]
        public async Task<IActionResult> ViewTracesProcessAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTracesProcessAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-scheduled")]
        public async Task<IActionResult> ViewTracesScheduledAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTracesScheduledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-traces-sent")]
        public async Task<IActionResult> ViewTracesSentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTracesSentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-links")]
        public async Task<IActionResult> ConvertLinksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConvertLinksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] MailingMailingCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-sms-link-replacements-placeholders")]
        public async Task<IActionResult> GetSmsLinkReplacementsPlaceholdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetSmsLinkReplacementsPlaceholdersAsync(ids);
            return Ok(result);
        }
    }
    
}