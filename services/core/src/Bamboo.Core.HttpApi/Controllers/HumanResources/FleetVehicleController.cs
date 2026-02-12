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
    [Route("api/v1/human-resources/FleetVehicle")]
    public partial class FleetVehicleController : AbpController
    {
        protected readonly IFleetVehicleAppService _appService;
        public FleetVehicleController(IFleetVehicleAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("act-show-log-cost")]
        public async Task<IActionResult> ActShowLogCostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ActShowLogCostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-accept-driver-change")]
        public async Task<IActionResult> AcceptDriverChangeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AcceptDriverChangeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-employee")]
        public async Task<IActionResult> OpenEmployeeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-odometer-report")]
        public async Task<IActionResult> OpenOdometerReportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenOdometerReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-email")]
        public async Task<IActionResult> SendEmailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-bills")]
        public async Task<IActionResult> ViewBillsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewBillsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-driver-history")]
        public async Task<IActionResult> CreateDriverHistoryAsync([FromBody] FleetVehicleCreateDriverHistoryRequestDto input)
        {
            var result = await _appService.CreateDriverHistoryAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-assignation-logs")]
        public async Task<IActionResult> OpenAssignationLogsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAssignationLogsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("return-action-to-open")]
        public async Task<IActionResult> ReturnToOpenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReturnToOpenAsync(ids);
            return Ok(result);
        }
    }
    
}