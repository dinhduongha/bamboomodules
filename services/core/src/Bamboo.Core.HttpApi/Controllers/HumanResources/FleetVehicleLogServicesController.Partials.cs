using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    public partial class FleetVehicleLogServicesController
    {
        
        [HttpPost]
        [Route("{id}/action-open-account-move")]
        public async Task<IActionResult> ActionOpenAccountMoveAsync(Guid id)
        {
            var result = await _appService.OpenAccountMoveAsync(id);
            return Ok(result);
        }
    }
}