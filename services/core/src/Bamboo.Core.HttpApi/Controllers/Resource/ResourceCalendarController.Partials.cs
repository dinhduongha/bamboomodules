using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    public partial class ResourceCalendarController
    {
        
        [HttpPost]
        [Route("{id}/action-open-contracts")]
        public async Task<IActionResult> ActionOpenContractsAsync(Guid id)
        {
            var result = await _appService.OpenContractsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ResourceCalendarCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-work-duration-data")]
        public async Task<IActionResult> GetWorkDurationDataAsync(Guid id, [FromBody] ResourceCalendarGetWorkDurationDataRequestDto input)
        {
            var result = await _appService.GetWorkDurationDataAsync(id, input.FromDatetime, input.ToDatetime, input.ComputeLeaves, input.Domain);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-work-hours-count")]
        public async Task<IActionResult> GetWorkHoursCountAsync(Guid id, [FromBody] ResourceCalendarGetWorkHoursCountRequestDto input)
        {
            var result = await _appService.GetWorkHoursCountAsync(id, input.StartDt, input.EndDt, input.ComputeLeaves, input.Domain);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/plan-days")]
        public async Task<IActionResult> PlanDaysAsync(Guid id, [FromBody] ResourceCalendarPlanDaysRequestDto input)
        {
            var result = await _appService.PlanDaysAsync(id, input.Days, input.DayDt, input.ComputeLeaves, input.Domain);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/plan-hours")]
        public async Task<IActionResult> PlanHoursAsync(Guid id, [FromBody] ResourceCalendarPlanHoursRequestDto input)
        {
            var result = await _appService.PlanHoursAsync(id, input.Hours, input.DayDt, input.ComputeLeaves, input.Domain, input.Resource);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/switch-calendar-type")]
        public async Task<IActionResult> SwitchCalendarTypeAsync(Guid id)
        {
            var result = await _appService.SwitchCalendarTypeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/transfer-leaves-to")]
        public async Task<IActionResult> TransferLeavesToAsync(Guid id, [FromBody] ResourceCalendarTransferLeavesToRequestDto input)
        {
            var result = await _appService.TransferLeavesToAsync(id, input.OtherCalendar, input.Resources, input.FromDate);
            return Ok(result);
        }
    }
}