using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    public partial class FleetVehicleController
    {
        
        [HttpPost]
        [Route("{id}/act-show-log-cost")]
        public async Task<IActionResult> ActShowLogCostAsync(Guid id)
        {
            var result = await _appService.ActShowLogCostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-accept-driver-change")]
        public async Task<IActionResult> ActionAcceptDriverChangeAsync(Guid id)
        {
            var result = await _appService.AcceptDriverChangeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-employee")]
        public async Task<IActionResult> ActionOpenEmployeeAsync(Guid id)
        {
            var result = await _appService.OpenEmployeeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-email")]
        public async Task<IActionResult> ActionSendEmailAsync(Guid id)
        {
            var result = await _appService.SendEmailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-bills")]
        public async Task<IActionResult> ActionViewBillsAsync(Guid id)
        {
            var result = await _appService.ViewBillsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-driver-history")]
        public async Task<IActionResult> CreateDriverHistoryAsync(Guid id, [FromBody] FleetVehicleCreateDriverHistoryRequestDto input)
        {
            var result = await _appService.CreateDriverHistoryAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-assignation-logs")]
        public async Task<IActionResult> OpenAssignationLogsAsync(Guid id)
        {
            var result = await _appService.OpenAssignationLogsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/return-action-to-open")]
        public async Task<IActionResult> ReturnActionToOpenAsync(Guid id)
        {
            var result = await _appService.ReturnToOpenAsync(id);
            return Ok(result);
        }
    }
}