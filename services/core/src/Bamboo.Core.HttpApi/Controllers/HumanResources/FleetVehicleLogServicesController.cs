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
    [Route("api/v1/human-resources/FleetVehicleLogServices")]
    public partial class FleetVehicleLogServicesController : AbpController
    {
        protected readonly IFleetVehicleLogServicesAppService _appService;
        public FleetVehicleLogServicesController(IFleetVehicleLogServicesAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-account-move")]
        public async Task<IActionResult> OpenAccountMoveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAccountMoveAsync(ids);
            return Ok(result);
        }
    }
    
}