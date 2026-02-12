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
    [Route("api/v1/human-resources/FleetVehicleModelBrand")]
    public partial class FleetVehicleModelBrandController : AbpController
    {
        protected readonly IFleetVehicleModelBrandAppService _appService;
        public FleetVehicleModelBrandController(IFleetVehicleModelBrandAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-brand-model")]
        public async Task<IActionResult> BrandModelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BrandModelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-brand-form")]
        public async Task<IActionResult> OpenBrandFormAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenBrandFormAsync(ids);
            return Ok(result);
        }
    }
    
}