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
    [Route("api/v1/human-resources/HrEmployeePublic")]
    public partial class HrEmployeePublicController : AbpController
    {
        protected readonly IHrEmployeePublicAppService _appService;
        public HrEmployeePublicController(IHrEmployeePublicAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-courses")]
        public async Task<IActionResult> OpenCoursesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenCoursesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-last-month-attendances")]
        public async Task<IActionResult> OpenLastMonthAttendancesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLastMonthAttendancesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-time-off-calendar")]
        public async Task<IActionResult> OpenTimeOffCalendarAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenTimeOffCalendarAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-time-off-dashboard")]
        public async Task<IActionResult> TimeOffDashboardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TimeOffDashboardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-timesheet-from-employee")]
        public async Task<IActionResult> TimesheetFromEmployeeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TimesheetFromEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-avatar-card-data")]
        public async Task<IActionResult> GetAvatarCardDataAsync([FromBody] HrEmployeePublicGetAvatarCardDataRequestDto input)
        {
            var result = await _appService.GetAvatarCardDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
    
}