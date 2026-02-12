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
    [Route("api/v1/productivity/MailMessage")]
    public partial class MailMessageController : AbpController
    {
        protected readonly IMailMessageAppService _appService;
        public MailMessageController(IMailMessageAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-document")]
        public async Task<IActionResult> OpenDocumentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cancel-letter")]
        public async Task<IActionResult> CancelLetterAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelLetterAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("export-data")]
        public async Task<IActionResult> ExportDataAsync([FromBody] MailMessageExportDataRequestDto input)
        {
            var result = await _appService.ExportDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fetch")]
        public async Task<IActionResult> FetchAsync([FromBody] MailMessageFetchRequestDto input)
        {
            var result = await _appService.FetchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mark-all-as-read")]
        public async Task<IActionResult> MarkAllAsReadAsync([FromBody] MailMessageMarkAllAsReadRequestDto input)
        {
            var result = await _appService.MarkAllAsReadAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("portal-message-format")]
        public async Task<IActionResult> PortalMessageFormatAsync([FromBody] MailMessagePortalMessageFormatRequestDto input)
        {
            var result = await _appService.PortalMessageFormatAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-letter")]
        public async Task<IActionResult> SendLetterAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendLetterAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-message-done")]
        public async Task<IActionResult> SetMessageDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetMessageDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-message-starred")]
        public async Task<IActionResult> ToggleMessageStarredAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleMessageStarredAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unstar-all")]
        public async Task<IActionResult> UnstarAllAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnstarAllAsync(ids);
            return Ok(result);
        }
    }
    
}