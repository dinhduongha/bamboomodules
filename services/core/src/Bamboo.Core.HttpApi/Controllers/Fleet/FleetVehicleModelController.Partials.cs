using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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