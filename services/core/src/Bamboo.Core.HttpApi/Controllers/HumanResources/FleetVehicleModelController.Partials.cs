using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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