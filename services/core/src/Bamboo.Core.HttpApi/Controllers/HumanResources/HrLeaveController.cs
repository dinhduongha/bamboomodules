using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrLeave")]
    public partial class HrLeaveController : AbpController
    {
        protected readonly IHrLeaveAppService _appService;
        public HrLeaveController(IHrLeaveAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-approve")]
        public async Task<IActionResult> ApproveAsync([FromBody] HrLeaveApproveRequestDto input)
        {
            var result = await _appService.ApproveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-back-to-approval")]
        public async Task<IActionResult> BackToApprovalAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BackToApprovalAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-documents")]
        public async Task<IActionResult> DocumentsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DocumentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse")]
        public async Task<IActionResult> RefuseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefuseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset-confirm")]
        public async Task<IActionResult> ResetConfirmAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ActivityUpdateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-follower")]
        public async Task<IActionResult> AddFollowerAsync([FromBody] HrLeaveAddFollowerRequestDto input)
        {
            var result = await _appService.AddFollowerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] HrLeaveCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync([FromBody] HrLeaveGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync([FromBody] HrLeaveMessageSubscribeRequestDto input)
        {
            var result = await _appService.MessageSubscribeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-pending-requests")]
        public async Task<IActionResult> OpenPendingRequestsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenPendingRequestsAsync(ids);
            return Ok(result);
        }
    }
    
}