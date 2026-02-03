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
        [Route("action-approve")]
        public async Task<IActionResult> ActionApproveAsync(HrLeaveApproveRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ApproveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-back-to-approval")]
        public async Task<IActionResult> ActionBackToApprovalAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BackToApprovalAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-documents")]
        public async Task<IActionResult> ActionDocumentsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DocumentsAsync(ids);
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
        [Route("action-reset-confirm")]
        public async Task<IActionResult> ActionResetConfirmAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetConfirmAsync(ids);
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
        public async Task<IActionResult> AddFollowerAsync(HrLeaveAddFollowerRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AddFollowerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(HrLeaveCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync(HrLeaveGetUnusualDaysRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetUnusualDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync(HrLeaveMessageSubscribeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageSubscribeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-pending-requests")]
        public async Task<IActionResult> OpenPendingRequestsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenPendingRequestsAsync(ids);
            return Ok(result);
        }
    }
}