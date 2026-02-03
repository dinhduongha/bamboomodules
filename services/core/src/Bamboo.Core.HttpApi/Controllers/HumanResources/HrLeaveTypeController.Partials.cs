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
        [Route("action-see-accrual-plans")]
        public async Task<IActionResult> ActionSeeAccrualPlansAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SeeAccrualPlansAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-days-allocated")]
        public async Task<IActionResult> ActionSeeDaysAllocatedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SeeDaysAllocatedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-group-leaves")]
        public async Task<IActionResult> ActionSeeGroupLeavesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SeeGroupLeavesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-allocation-requirement-edit-validity")]
        public async Task<IActionResult> CheckAllocationRequirementEditValidityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckAllocationRequirementEditValidityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(HrLeaveTypeCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-allocation-data")]
        public async Task<IActionResult> GetAllocationDataAsync(HrLeaveTypeGetAllocationDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAllocationDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-allocation-data-request")]
        public async Task<IActionResult> GetAllocationDataRequestAsync(HrLeaveTypeGetAllocationDataRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAllocationDataRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-accrual-allocation")]
        public async Task<IActionResult> HasAccrualAllocationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.HasAccrualAllocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("requested-display-name")]
        public async Task<IActionResult> RequestedDisplayNameAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RequestedDisplayNameAsync(ids);
            return Ok(result);
        }
    }
}