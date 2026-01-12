using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrLeaveTypeController
    {
        
        [HttpPost]
        [Route("{id}/action-see-accrual-plans")]
        public async Task<IActionResult> ActionSeeAccrualPlansAsync(Guid id)
        {
            var result = await _appService.SeeAccrualPlansAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-see-days-allocated")]
        public async Task<IActionResult> ActionSeeDaysAllocatedAsync(Guid id)
        {
            var result = await _appService.SeeDaysAllocatedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-see-group-leaves")]
        public async Task<IActionResult> ActionSeeGroupLeavesAsync(Guid id)
        {
            var result = await _appService.SeeGroupLeavesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-allocation-requirement-edit-validity")]
        public async Task<IActionResult> CheckAllocationRequirementEditValidityAsync(Guid id)
        {
            var result = await _appService.CheckAllocationRequirementEditValidityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] HrLeaveTypeCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-allocation-data")]
        public async Task<IActionResult> GetAllocationDataAsync(Guid id, [FromBody] HrLeaveTypeGetAllocationDataRequestDto input)
        {
            var result = await _appService.GetAllocationDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-allocation-data-request")]
        public async Task<IActionResult> GetAllocationDataRequestAsync(Guid id, [FromBody] HrLeaveTypeGetAllocationDataRequestRequestDto input)
        {
            var result = await _appService.GetAllocationDataRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-accrual-allocation")]
        public async Task<IActionResult> HasAccrualAllocationAsync(Guid id)
        {
            var result = await _appService.HasAccrualAllocationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/requested-display-name")]
        public async Task<IActionResult> RequestedDisplayNameAsync(Guid id)
        {
            var result = await _appService.RequestedDisplayNameAsync(id);
            return Ok(result);
        }
    }
}