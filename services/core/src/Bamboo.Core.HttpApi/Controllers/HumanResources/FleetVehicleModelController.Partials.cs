using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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