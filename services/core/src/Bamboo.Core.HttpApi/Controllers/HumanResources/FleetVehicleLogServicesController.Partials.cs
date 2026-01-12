using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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