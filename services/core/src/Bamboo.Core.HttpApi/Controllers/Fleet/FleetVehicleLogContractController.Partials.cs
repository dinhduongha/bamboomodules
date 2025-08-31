using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    public partial class FleetVehicleLogContractController
    {
        
        [HttpPost]
        [Route("{id}/action-close")]
        public async Task<IActionResult> ActionCloseAsync(Guid id)
        {
            var result = await _appService.CloseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-draft")]
        public async Task<IActionResult> ActionDraftAsync(Guid id)
        {
            var result = await _appService.DraftAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-expire")]
        public async Task<IActionResult> ActionExpireAsync(Guid id)
        {
            var result = await _appService.ExpireAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open")]
        public async Task<IActionResult> ActionOpenAsync(Guid id)
        {
            var result = await _appService.OpenAsync(id);
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
        [Route("{id}/compute-next-year-date")]
        public async Task<IActionResult> ComputeNextYearDateAsync(Guid id, [FromBody] FleetVehicleLogContractComputeNextYearDateRequestDto input)
        {
            var result = await _appService.ComputeNextYearDateAsync(id, input.Strdate);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/run-scheduler")]
        public async Task<IActionResult> RunSchedulerAsync(Guid id)
        {
            var result = await _appService.RunSchedulerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/scheduler-manage-contract-expiration")]
        public async Task<IActionResult> SchedulerManageContractExpirationAsync(Guid id)
        {
            var result = await _appService.SchedulerManageContractExpirationAsync(id);
            return Ok(result);
        }
    }
}