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
        [Route("action-open-courses")]
        public async Task<IActionResult> ActionOpenCoursesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenCoursesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-last-month-attendances")]
        public async Task<IActionResult> ActionOpenLastMonthAttendancesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLastMonthAttendancesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-time-off-calendar")]
        public async Task<IActionResult> ActionOpenTimeOffCalendarAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenTimeOffCalendarAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-time-off-dashboard")]
        public async Task<IActionResult> ActionTimeOffDashboardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TimeOffDashboardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-timesheet-from-employee")]
        public async Task<IActionResult> ActionTimesheetFromEmployeeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TimesheetFromEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-avatar-card-data")]
        public async Task<IActionResult> GetAvatarCardDataAsync(HrEmployeePublicGetAvatarCardDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAvatarCardDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
}