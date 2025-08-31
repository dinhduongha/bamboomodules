using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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