using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    public partial class FleetVehicleModelController
    {
        
        [HttpPost]
        [Route("{id}/action-model-vehicle")]
        public async Task<IActionResult> ActionModelVehicleAsync(Guid id)
        {
            var result = await _appService.ModelVehicleAsync(id);
            return Ok(result);
        }
    }
}