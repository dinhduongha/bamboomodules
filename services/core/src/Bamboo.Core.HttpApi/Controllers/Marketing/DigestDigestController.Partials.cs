using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class DigestDigestController
    {
        
        [HttpPost]
        [Route("{id}/action-activate")]
        public async Task<IActionResult> ActionActivateAsync(Guid id)
        {
            var result = await _appService.ActivateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-deactivate")]
        public async Task<IActionResult> ActionDeactivateAsync(Guid id)
        {
            var result = await _appService.DeactivateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send")]
        public async Task<IActionResult> ActionSendAsync(Guid id)
        {
            var result = await _appService.SendAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-manual")]
        public async Task<IActionResult> ActionSendManualAsync(Guid id)
        {
            var result = await _appService.SendManualAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-periodicity")]
        public async Task<IActionResult> ActionSetPeriodicityAsync(Guid id, [FromBody] DigestDigestSetPeriodicityRequestDto input)
        {
            var result = await _appService.SetPeriodicityAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-subscribe")]
        public async Task<IActionResult> ActionSubscribeAsync(Guid id)
        {
            var result = await _appService.SubscribeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unsubscribe")]
        public async Task<IActionResult> ActionUnsubscribeAsync(Guid id)
        {
            var result = await _appService.UnsubscribeAsync(id);
            return Ok(result);
        }
    }
}