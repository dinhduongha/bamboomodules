using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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
    }
}