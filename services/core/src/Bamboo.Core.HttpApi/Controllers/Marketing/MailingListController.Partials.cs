using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailingListController
    {
        
        [HttpPost]
        [Route("action-merge")]
        public async Task<IActionResult> ActionMergeAsync(MailingListMergeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MergeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-import")]
        public async Task<IActionResult> ActionOpenImportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenImportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mailing")]
        public async Task<IActionResult> ActionSendMailingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendMailingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mailing-sms")]
        public async Task<IActionResult> ActionSendMailingSmsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendMailingSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts")]
        public async Task<IActionResult> ActionViewContactsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewContactsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-blacklisted")]
        public async Task<IActionResult> ActionViewContactsBlacklistedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewContactsBlacklistedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-bouncing")]
        public async Task<IActionResult> ActionViewContactsBouncingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewContactsBouncingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-email")]
        public async Task<IActionResult> ActionViewContactsEmailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewContactsEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-opt-out")]
        public async Task<IActionResult> ActionViewContactsOptOutAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewContactsOptOutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-sms")]
        public async Task<IActionResult> ActionViewContactsSmsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewContactsSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mailings")]
        public async Task<IActionResult> ActionViewMailingsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMailingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(MailingListCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
}