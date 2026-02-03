using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class FleetVehicleModelBrandController
    {
        
        [HttpPost]
        [Route("action-brand-model")]
        public async Task<IActionResult> ActionBrandModelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BrandModelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-brand-form")]
        public async Task<IActionResult> ActionOpenBrandFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenBrandFormAsync(ids);
            return Ok(result);
        }
    }
}