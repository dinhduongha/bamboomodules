using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrLeaveController
    {
        
        [HttpPost]
        [Route("{id}/action-approve")]
        public async Task<IActionResult> ActionApproveAsync(Guid id, [FromBody] HrLeaveApproveRequestDto input)
        {
            var result = await _appService.ApproveAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-back-to-approval")]
        public async Task<IActionResult> ActionBackToApprovalAsync(Guid id)
        {
            var result = await _appService.BackToApprovalAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-documents")]
        public async Task<IActionResult> ActionDocumentsAsync(Guid id)
        {
            var result = await _appService.DocumentsAsync(id);
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
        [Route("{id}/action-reset-confirm")]
        public async Task<IActionResult> ActionResetConfirmAsync(Guid id)
        {
            var result = await _appService.ResetConfirmAsync(id);
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
        public async Task<IActionResult> AddFollowerAsync(Guid id, [FromBody] HrLeaveAddFollowerRequestDto input)
        {
            var result = await _appService.AddFollowerAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] HrLeaveCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync(Guid id, [FromBody] HrLeaveGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync(Guid id, [FromBody] HrLeaveMessageSubscribeRequestDto input)
        {
            var result = await _appService.MessageSubscribeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-pending-requests")]
        public async Task<IActionResult> OpenPendingRequestsAsync(Guid id)
        {
            var result = await _appService.OpenPendingRequestsAsync(id);
            return Ok(result);
        }
    }
}