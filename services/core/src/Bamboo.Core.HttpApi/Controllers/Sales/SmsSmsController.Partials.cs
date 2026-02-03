using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SmsSmsController
    {
        
        [HttpPost]
        [Route("action-set-canceled")]
        public async Task<IActionResult> ActionSetCanceledAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetCanceledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-error")]
        public async Task<IActionResult> ActionSetErrorAsync(SmsSmsSetErrorRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetErrorAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-outgoing")]
        public async Task<IActionResult> ActionSetOutgoingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetOutgoingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("resend-failed")]
        public async Task<IActionResult> ResendFailedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResendFailedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendAsync(SmsSmsSendRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendAsync(input);
            return Ok(result);
        }
    }
}