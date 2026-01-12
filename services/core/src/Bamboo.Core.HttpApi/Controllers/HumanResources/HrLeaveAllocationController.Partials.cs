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
        [Route("{id}/action-approve")]
        public async Task<IActionResult> ActionApproveAsync(Guid id)
        {
            var result = await _appService.ApproveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-refuse")]
        public async Task<IActionResult> ActionRefuseAsync(Guid id)
        {
            var result = await _appService.RefuseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-to-confirm")]
        public async Task<IActionResult> ActionSetToConfirmAsync(Guid id)
        {
            var result = await _appService.SetToConfirmAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync(Guid id)
        {
            var result = await _appService.ActivityUpdateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/add-follower")]
        public async Task<IActionResult> AddFollowerAsync(Guid id, [FromBody] HrLeaveAllocationAddFollowerRequestDto input)
        {
            var result = await _appService.AddFollowerAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync(Guid id, [FromBody] HrLeaveAllocationMessageSubscribeRequestDto input)
        {
            var result = await _appService.MessageSubscribeAsync(id, input);
            return Ok(result);
        }
    }
}