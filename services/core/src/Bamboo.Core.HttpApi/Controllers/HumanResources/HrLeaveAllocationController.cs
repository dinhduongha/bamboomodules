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
    [Route("api/v1/human-resources/HrLeaveAllocation")]
    public partial class HrLeaveAllocationController : AbpController
    {
        protected readonly IHrLeaveAllocationAppService _appService;
        public HrLeaveAllocationController(IHrLeaveAllocationAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-approve")]
        public async Task<IActionResult> ApproveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ApproveAsync(ids);
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
        [Route("activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ActivityUpdateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-follower")]
        public async Task<IActionResult> AddFollowerAsync([FromBody] HrLeaveAllocationAddFollowerRequestDto input)
        {
            var result = await _appService.AddFollowerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync([FromBody] HrLeaveAllocationMessageSubscribeRequestDto input)
        {
            var result = await _appService.MessageSubscribeAsync(input);
            return Ok(result);
        }
    }
    
}