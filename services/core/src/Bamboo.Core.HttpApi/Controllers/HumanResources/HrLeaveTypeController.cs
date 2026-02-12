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
    [Route("api/v1/human-resources/HrLeaveType")]
    public partial class HrLeaveTypeController : AbpController
    {
        protected readonly IHrLeaveTypeAppService _appService;
        public HrLeaveTypeController(IHrLeaveTypeAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-see-accrual-plans")]
        public async Task<IActionResult> SeeAccrualPlansAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeeAccrualPlansAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-days-allocated")]
        public async Task<IActionResult> SeeDaysAllocatedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeeDaysAllocatedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-group-leaves")]
        public async Task<IActionResult> SeeGroupLeavesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeeGroupLeavesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-allocation-requirement-edit-validity")]
        public async Task<IActionResult> CheckAllocationRequirementEditValidityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckAllocationRequirementEditValidityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] HrLeaveTypeCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-allocation-data")]
        public async Task<IActionResult> GetAllocationDataAsync([FromBody] HrLeaveTypeGetAllocationDataRequestDto input)
        {
            var result = await _appService.GetAllocationDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-allocation-data-request")]
        public async Task<IActionResult> GetAllocationDataRequestAsync([FromBody] HrLeaveTypeGetAllocationDataRequestRequestDto input)
        {
            var result = await _appService.GetAllocationDataRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-accrual-allocation")]
        public async Task<IActionResult> HasAccrualAllocationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.HasAccrualAllocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("requested-display-name")]
        public async Task<IActionResult> RequestedDisplayNameAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RequestedDisplayNameAsync(ids);
            return Ok(result);
        }
    }
    
}