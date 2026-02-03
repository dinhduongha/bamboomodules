using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailingTraceController
    {
        
        [HttpPost]
        [Route("action-view-contact")]
        public async Task<IActionResult> ActionViewContactAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewContactAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-bounced")]
        public async Task<IActionResult> SetBouncedAsync(MailingTraceSetBouncedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetBouncedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-canceled")]
        public async Task<IActionResult> SetCanceledAsync(MailingTraceSetCanceledRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetCanceledAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-clicked")]
        public async Task<IActionResult> SetClickedAsync(MailingTraceSetClickedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetClickedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-failed")]
        public async Task<IActionResult> SetFailedAsync(MailingTraceSetFailedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetFailedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-opened")]
        public async Task<IActionResult> SetOpenedAsync(MailingTraceSetOpenedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetOpenedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-replied")]
        public async Task<IActionResult> SetRepliedAsync(MailingTraceSetRepliedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetRepliedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sent")]
        public async Task<IActionResult> SetSentAsync(MailingTraceSetSentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetSentAsync(input);
            return Ok(result);
        }
    }
}