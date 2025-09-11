using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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