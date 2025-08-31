using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
            var result = await _appService.SetErrorAsync(id, input.FailureType);
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
            var result = await _appService.SendAsync(id, input.UnlinkFailed, input.UnlinkSent, input.AutoCommit, input.RaiseException);
            return Ok(result);
        }
    }
}