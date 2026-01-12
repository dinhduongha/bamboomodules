using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailMailController
    {
        
        [HttpPost]
        [Route("{id}/action-open-document")]
        public async Task<IActionResult> ActionOpenDocumentAsync(Guid id)
        {
            var result = await _appService.OpenDocumentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-retry")]
        public async Task<IActionResult> ActionRetryAsync(Guid id)
        {
            var result = await _appService.RetryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/cancel")]
        public async Task<IActionResult> CancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/mark-outgoing")]
        public async Task<IActionResult> MarkOutgoingAsync(Guid id)
        {
            var result = await _appService.MarkOutgoingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/process-email-queue")]
        public async Task<IActionResult> ProcessEmailQueueAsync(Guid id, [FromBody] MailMailProcessEmailQueueRequestDto input)
        {
            var result = await _appService.ProcessEmailQueueAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send")]
        public async Task<IActionResult> SendAsync(Guid id, [FromBody] MailMailSendRequestDto input)
        {
            var result = await _appService.SendAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-after-commit")]
        public async Task<IActionResult> SendAfterCommitAsync(Guid id)
        {
            var result = await _appService.SendAfterCommitAsync(id);
            return Ok(result);
        }
    }
}