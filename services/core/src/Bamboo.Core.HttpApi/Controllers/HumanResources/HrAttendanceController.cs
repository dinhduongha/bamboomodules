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
    [Route("api/v1/human-resources/HrAttendance")]
    public partial class HrAttendanceController : AbpController
    {
        protected readonly IHrAttendanceAppService _appService;
        public HrAttendanceController(IHrAttendanceAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-approve-overtime")]
        public async Task<IActionResult> ApproveOvertimeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ApproveOvertimeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-in-attendance-maps")]
        public async Task<IActionResult> InAttendanceMapsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InAttendanceMapsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-out-attendance-maps")]
        public async Task<IActionResult> OutAttendanceMapsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OutAttendanceMapsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse-overtime")]
        public async Task<IActionResult> RefuseOvertimeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefuseOvertimeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-try-kiosk")]
        public async Task<IActionResult> TryKioskAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TryKioskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-kiosk-url")]
        public async Task<IActionResult> GetKioskUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetKioskUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-demo-data")]
        public async Task<IActionResult> HasDemoDataAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.HasDemoDataAsync(ids);
            return Ok(result);
        }
    }
    
}