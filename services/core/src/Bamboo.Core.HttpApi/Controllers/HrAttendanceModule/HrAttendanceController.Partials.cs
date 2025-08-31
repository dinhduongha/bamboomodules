using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrAttendanceModule
{
    public partial class HrAttendanceController
    {
        
        [HttpPost]
        [Route("{id}/action-approve-overtime")]
        public async Task<IActionResult> ActionApproveOvertimeAsync(Guid id)
        {
            var result = await _appService.ApproveOvertimeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-in-attendance-maps")]
        public async Task<IActionResult> ActionInAttendanceMapsAsync(Guid id)
        {
            var result = await _appService.InAttendanceMapsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-out-attendance-maps")]
        public async Task<IActionResult> ActionOutAttendanceMapsAsync(Guid id)
        {
            var result = await _appService.OutAttendanceMapsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-refuse-overtime")]
        public async Task<IActionResult> ActionRefuseOvertimeAsync(Guid id)
        {
            var result = await _appService.RefuseOvertimeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-try-kiosk")]
        public async Task<IActionResult> ActionTryKioskAsync(Guid id)
        {
            var result = await _appService.TryKioskAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-kiosk-url")]
        public async Task<IActionResult> GetKioskUrlAsync(Guid id)
        {
            var result = await _appService.GetKioskUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-demo-data")]
        public async Task<IActionResult> HasDemoDataAsync(Guid id)
        {
            var result = await _appService.HasDemoDataAsync(id);
            return Ok(result);
        }
    }
}