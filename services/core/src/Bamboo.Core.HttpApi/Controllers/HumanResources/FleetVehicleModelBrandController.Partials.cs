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
        [Route("{id}/action-brand-model")]
        public async Task<IActionResult> ActionBrandModelAsync(Guid id)
        {
            var result = await _appService.BrandModelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-brand-form")]
        public async Task<IActionResult> ActionOpenBrandFormAsync(Guid id)
        {
            var result = await _appService.OpenBrandFormAsync(id);
            return Ok(result);
        }
    }
}