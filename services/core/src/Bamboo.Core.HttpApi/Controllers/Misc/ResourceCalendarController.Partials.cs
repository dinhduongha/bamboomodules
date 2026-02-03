using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResourceCalendarController
    {
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(ResourceCalendarCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-work-duration-data")]
        public async Task<IActionResult> GetWorkDurationDataAsync(ResourceCalendarGetWorkDurationDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetWorkDurationDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-work-hours-count")]
        public async Task<IActionResult> GetWorkHoursCountAsync(ResourceCalendarGetWorkHoursCountRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetWorkHoursCountAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("plan-days")]
        public async Task<IActionResult> PlanDaysAsync(ResourceCalendarPlanDaysRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PlanDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("plan-hours")]
        public async Task<IActionResult> PlanHoursAsync(ResourceCalendarPlanHoursRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PlanHoursAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("switch-based-on-duration")]
        public async Task<IActionResult> SwitchBasedOnDurationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SwitchBasedOnDurationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("switch-calendar-type")]
        public async Task<IActionResult> SwitchCalendarTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SwitchCalendarTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("transfer-leaves-to")]
        public async Task<IActionResult> TransferLeavesToAsync(ResourceCalendarTransferLeavesToRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.TransferLeavesToAsync(input);
            return Ok(result);
        }
    }
}