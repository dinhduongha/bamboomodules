using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
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
    }
}