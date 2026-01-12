using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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