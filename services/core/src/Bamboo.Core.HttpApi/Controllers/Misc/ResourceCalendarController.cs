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
    [Route("api/v1/resource/ResourceCalendar")]
    public partial class ResourceCalendarController : AbpController
    {
        protected readonly IResourceCalendarAppService _appService;
        public ResourceCalendarController(IResourceCalendarAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ResourceCalendarCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-work-duration-data")]
        public async Task<IActionResult> GetWorkDurationDataAsync([FromBody] ResourceCalendarGetWorkDurationDataRequestDto input)
        {
            var result = await _appService.GetWorkDurationDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-work-hours-count")]
        public async Task<IActionResult> GetWorkHoursCountAsync([FromBody] ResourceCalendarGetWorkHoursCountRequestDto input)
        {
            var result = await _appService.GetWorkHoursCountAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("plan-days")]
        public async Task<IActionResult> PlanDaysAsync([FromBody] ResourceCalendarPlanDaysRequestDto input)
        {
            var result = await _appService.PlanDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("plan-hours")]
        public async Task<IActionResult> PlanHoursAsync([FromBody] ResourceCalendarPlanHoursRequestDto input)
        {
            var result = await _appService.PlanHoursAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("switch-based-on-duration")]
        public async Task<IActionResult> SwitchBasedOnDurationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SwitchBasedOnDurationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("switch-calendar-type")]
        public async Task<IActionResult> SwitchCalendarTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SwitchCalendarTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("transfer-leaves-to")]
        public async Task<IActionResult> TransferLeavesToAsync([FromBody] ResourceCalendarTransferLeavesToRequestDto input)
        {
            var result = await _appService.TransferLeavesToAsync(input);
            return Ok(result);
        }
    }
    
}