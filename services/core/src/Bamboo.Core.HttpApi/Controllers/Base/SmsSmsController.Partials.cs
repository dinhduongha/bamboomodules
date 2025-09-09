using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Sms
{
    public partial class SmsSmsController
    {
        
        [HttpPost]
        [Route("{id}/action-set-canceled")]
        public async Task<IActionResult> ActionSetCanceledAsync(Guid id)
        {
            var result = await _appService.SetCanceledAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-error")]
        public async Task<IActionResult> ActionSetErrorAsync(Guid id, [FromBody] SmsSmsSetErrorRequestDto input)
        {
            var result = await _appService.SetErrorAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-outgoing")]
        public async Task<IActionResult> ActionSetOutgoingAsync(Guid id)
        {
            var result = await _appService.SetOutgoingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/resend-failed")]
        public async Task<IActionResult> ResendFailedAsync(Guid id)
        {
            var result = await _appService.ResendFailedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send")]
        public async Task<IActionResult> SendAsync(Guid id, [FromBody] SmsSmsSendRequestDto input)
        {
            var result = await _appService.SendAsync(id, input);
            return Ok(result);
        }
    }
}