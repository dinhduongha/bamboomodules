using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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