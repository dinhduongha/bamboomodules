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
        [Route("action-open-document")]
        public async Task<IActionResult> ActionOpenDocumentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-retry")]
        public async Task<IActionResult> ActionRetryAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RetryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-and-close")]
        public async Task<IActionResult> ActionSendAndCloseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendAndCloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mark-outgoing")]
        public async Task<IActionResult> MarkOutgoingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MarkOutgoingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("process-email-queue")]
        public async Task<IActionResult> ProcessEmailQueueAsync(MailMailProcessEmailQueueRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ProcessEmailQueueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendAsync(MailMailSendRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-after-commit")]
        public async Task<IActionResult> SendAfterCommitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendAfterCommitAsync(ids);
            return Ok(result);
        }
    }
}