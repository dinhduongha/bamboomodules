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
    [Route("api/v1/human-resources/FleetVehicleModel")]
    public partial class FleetVehicleModelController : AbpController
    {
        protected readonly IFleetVehicleModelAppService _appService;
        public FleetVehicleModelController(IFleetVehicleModelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-model-vehicle")]
        public async Task<IActionResult> ModelVehicleAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ModelVehicleAsync(ids);
            return Ok(result);
        }
    }
    
}