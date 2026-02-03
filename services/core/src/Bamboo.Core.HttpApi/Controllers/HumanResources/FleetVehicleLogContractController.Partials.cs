using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class FleetVehicleLogContractController
    {
        
        [HttpPost]
        [Route("action-close")]
        public async Task<IActionResult> ActionCloseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-draft")]
        public async Task<IActionResult> ActionDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-expire")]
        public async Task<IActionResult> ActionExpireAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExpireAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open")]
        public async Task<IActionResult> ActionOpenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAsync(ids);
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
        [Route("compute-next-year-date")]
        public async Task<IActionResult> ComputeNextYearDateAsync(FleetVehicleLogContractComputeNextYearDateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ComputeNextYearDateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run-scheduler")]
        public async Task<IActionResult> RunSchedulerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RunSchedulerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("scheduler-manage-contract-expiration")]
        public async Task<IActionResult> SchedulerManageContractExpirationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SchedulerManageContractExpirationAsync(ids);
            return Ok(result);
        }
    }
}