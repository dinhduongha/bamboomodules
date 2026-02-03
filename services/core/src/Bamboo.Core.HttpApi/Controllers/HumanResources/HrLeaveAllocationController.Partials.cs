using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrLeaveAllocationController
    {
        
        [HttpPost]
        [Route("action-approve")]
        public async Task<IActionResult> ActionApproveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ApproveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse")]
        public async Task<IActionResult> ActionRefuseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefuseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ActivityUpdateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-follower")]
        public async Task<IActionResult> AddFollowerAsync(HrLeaveAllocationAddFollowerRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AddFollowerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync(HrLeaveAllocationMessageSubscribeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageSubscribeAsync(input);
            return Ok(result);
        }
    }
}