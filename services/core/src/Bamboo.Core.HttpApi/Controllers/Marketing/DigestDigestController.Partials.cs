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
        [Route("action-activate")]
        public async Task<IActionResult> ActionActivateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ActivateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-deactivate")]
        public async Task<IActionResult> ActionDeactivateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DeactivateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send")]
        public async Task<IActionResult> ActionSendAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-manual")]
        public async Task<IActionResult> ActionSendManualAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendManualAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-periodicity")]
        public async Task<IActionResult> ActionSetPeriodicityAsync(DigestDigestSetPeriodicityRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetPeriodicityAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-subscribe")]
        public async Task<IActionResult> ActionSubscribeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SubscribeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unsubscribe")]
        public async Task<IActionResult> ActionUnsubscribeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnsubscribeAsync(ids);
            return Ok(result);
        }
    }
}