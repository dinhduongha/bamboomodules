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
    [Route("api/v1/human-resources/FleetVehicleLogContract")]
    public partial class FleetVehicleLogContractController : AbpController
    {
        protected readonly IFleetVehicleLogContractAppService _appService;
        public FleetVehicleLogContractController(IFleetVehicleLogContractAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-close")]
        public async Task<IActionResult> CloseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-draft")]
        public async Task<IActionResult> DraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-expire")]
        public async Task<IActionResult> ExpireAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExpireAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open")]
        public async Task<IActionResult> OpenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAsync(ids);
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
        [Route("compute-next-year-date")]
        public async Task<IActionResult> ComputeNextYearDateAsync([FromBody] FleetVehicleLogContractComputeNextYearDateRequestDto input)
        {
            var result = await _appService.ComputeNextYearDateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run-scheduler")]
        public async Task<IActionResult> RunSchedulerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RunSchedulerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("scheduler-manage-contract-expiration")]
        public async Task<IActionResult> SchedulerManageContractExpirationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SchedulerManageContractExpirationAsync(ids);
            return Ok(result);
        }
    }
    
}