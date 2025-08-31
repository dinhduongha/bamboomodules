using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.MassMailing
{
    public partial class MailingListController
    {
        
        [HttpPost]
        [Route("{id}/action-merge")]
        public async Task<IActionResult> ActionMergeAsync(Guid id, [FromBody] MailingListMergeRequestDto input)
        {
            var result = await _appService.MergeAsync(id, input.SrcLists, input.Archive);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-import")]
        public async Task<IActionResult> ActionOpenImportAsync(Guid id)
        {
            var result = await _appService.OpenImportAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-mailing")]
        public async Task<IActionResult> ActionSendMailingAsync(Guid id)
        {
            var result = await _appService.SendMailingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-mailing-sms")]
        public async Task<IActionResult> ActionSendMailingSmsAsync(Guid id)
        {
            var result = await _appService.SendMailingSmsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-contacts")]
        public async Task<IActionResult> ActionViewContactsAsync(Guid id)
        {
            var result = await _appService.ViewContactsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-contacts-blacklisted")]
        public async Task<IActionResult> ActionViewContactsBlacklistedAsync(Guid id)
        {
            var result = await _appService.ViewContactsBlacklistedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-contacts-bouncing")]
        public async Task<IActionResult> ActionViewContactsBouncingAsync(Guid id)
        {
            var result = await _appService.ViewContactsBouncingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-contacts-email")]
        public async Task<IActionResult> ActionViewContactsEmailAsync(Guid id)
        {
            var result = await _appService.ViewContactsEmailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-contacts-opt-out")]
        public async Task<IActionResult> ActionViewContactsOptOutAsync(Guid id)
        {
            var result = await _appService.ViewContactsOptOutAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-contacts-sms")]
        public async Task<IActionResult> ActionViewContactsSmsAsync(Guid id)
        {
            var result = await _appService.ViewContactsSmsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mailings")]
        public async Task<IActionResult> ActionViewMailingsAsync(Guid id)
        {
            var result = await _appService.ViewMailingsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/close-dialog")]
        public async Task<IActionResult> CloseDialogAsync(Guid id)
        {
            var result = await _appService.CloseDialogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] MailingListCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
    }
}