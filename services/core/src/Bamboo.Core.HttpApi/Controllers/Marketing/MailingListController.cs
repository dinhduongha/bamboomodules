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
    [Route("api/v1/marketing/MailingList")]
    public partial class MailingListController : AbpController
    {
        protected readonly IMailingListAppService _appService;
        public MailingListController(IMailingListAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-merge")]
        public async Task<IActionResult> MergeAsync([FromBody] MailingListMergeRequestDto input)
        {
            var result = await _appService.MergeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-import")]
        public async Task<IActionResult> OpenImportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenImportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mailing")]
        public async Task<IActionResult> SendMailingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendMailingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mailing-sms")]
        public async Task<IActionResult> SendMailingSmsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendMailingSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts")]
        public async Task<IActionResult> ViewContactsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewContactsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-blacklisted")]
        public async Task<IActionResult> ViewContactsBlacklistedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewContactsBlacklistedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-bouncing")]
        public async Task<IActionResult> ViewContactsBouncingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewContactsBouncingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-email")]
        public async Task<IActionResult> ViewContactsEmailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewContactsEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-opt-out")]
        public async Task<IActionResult> ViewContactsOptOutAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewContactsOptOutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-contacts-sms")]
        public async Task<IActionResult> ViewContactsSmsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewContactsSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mailings")]
        public async Task<IActionResult> ViewMailingsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMailingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] MailingListCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
    
}