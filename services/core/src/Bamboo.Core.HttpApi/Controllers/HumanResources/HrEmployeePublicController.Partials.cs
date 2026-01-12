using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrEmployeePublicController
    {
        
        [HttpPost]
        [Route("{id}/action-open-courses")]
        public async Task<IActionResult> ActionOpenCoursesAsync(Guid id)
        {
            var result = await _appService.OpenCoursesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-last-month-attendances")]
        public async Task<IActionResult> ActionOpenLastMonthAttendancesAsync(Guid id)
        {
            var result = await _appService.OpenLastMonthAttendancesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-time-off-calendar")]
        public async Task<IActionResult> ActionOpenTimeOffCalendarAsync(Guid id)
        {
            var result = await _appService.OpenTimeOffCalendarAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-time-off-dashboard")]
        public async Task<IActionResult> ActionTimeOffDashboardAsync(Guid id)
        {
            var result = await _appService.TimeOffDashboardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-timesheet-from-employee")]
        public async Task<IActionResult> ActionTimesheetFromEmployeeAsync(Guid id)
        {
            var result = await _appService.TimesheetFromEmployeeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-avatar-card-data")]
        public async Task<IActionResult> GetAvatarCardDataAsync(Guid id, [FromBody] HrEmployeePublicGetAvatarCardDataRequestDto input)
        {
            var result = await _appService.GetAvatarCardDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
    }
}