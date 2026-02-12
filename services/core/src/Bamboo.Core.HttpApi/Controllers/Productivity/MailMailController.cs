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
    [Route("api/v1/productivity/MailMail")]
    public partial class MailMailController : AbpController
    {
        protected readonly IMailMailAppService _appService;
        public MailMailController(IMailMailAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-document")]
        public async Task<IActionResult> OpenDocumentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-retry")]
        public async Task<IActionResult> RetryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RetryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-and-close")]
        public async Task<IActionResult> SendAndCloseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendAndCloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mark-outgoing")]
        public async Task<IActionResult> MarkOutgoingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MarkOutgoingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("process-email-queue")]
        public async Task<IActionResult> ProcessEmailQueueAsync([FromBody] MailMailProcessEmailQueueRequestDto input)
        {
            var result = await _appService.ProcessEmailQueueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendAsync([FromBody] MailMailSendRequestDto input)
        {
            var result = await _appService.SendAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-after-commit")]
        public async Task<IActionResult> SendAfterCommitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendAfterCommitAsync(ids);
            return Ok(result);
        }
    }
    
}