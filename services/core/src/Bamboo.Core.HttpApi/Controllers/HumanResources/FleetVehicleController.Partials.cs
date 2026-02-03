using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class FleetVehicleController
    {
        
        [HttpPost]
        [Route("act-show-log-cost")]
        public async Task<IActionResult> ActShowLogCostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ActShowLogCostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-accept-driver-change")]
        public async Task<IActionResult> ActionAcceptDriverChangeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AcceptDriverChangeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-employee")]
        public async Task<IActionResult> ActionOpenEmployeeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-odometer-report")]
        public async Task<IActionResult> ActionOpenOdometerReportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenOdometerReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-email")]
        public async Task<IActionResult> ActionSendEmailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-bills")]
        public async Task<IActionResult> ActionViewBillsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewBillsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-driver-history")]
        public async Task<IActionResult> CreateDriverHistoryAsync(FleetVehicleCreateDriverHistoryRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateDriverHistoryAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-assignation-logs")]
        public async Task<IActionResult> OpenAssignationLogsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAssignationLogsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("return-action-to-open")]
        public async Task<IActionResult> ReturnActionToOpenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReturnToOpenAsync(ids);
            return Ok(result);
        }
    }
}