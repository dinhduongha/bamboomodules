using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrAttendanceController
    {
        
        [HttpPost]
        [Route("action-approve-overtime")]
        public async Task<IActionResult> ActionApproveOvertimeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ApproveOvertimeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-in-attendance-maps")]
        public async Task<IActionResult> ActionInAttendanceMapsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InAttendanceMapsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-out-attendance-maps")]
        public async Task<IActionResult> ActionOutAttendanceMapsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OutAttendanceMapsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse-overtime")]
        public async Task<IActionResult> ActionRefuseOvertimeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefuseOvertimeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-try-kiosk")]
        public async Task<IActionResult> ActionTryKioskAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TryKioskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-kiosk-url")]
        public async Task<IActionResult> GetKioskUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetKioskUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-demo-data")]
        public async Task<IActionResult> HasDemoDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.HasDemoDataAsync(ids);
            return Ok(result);
        }
    }
}