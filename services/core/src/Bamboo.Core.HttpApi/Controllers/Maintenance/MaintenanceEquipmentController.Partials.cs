using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Maintenance
{
    public partial class MaintenanceEquipmentController
    {
        
        [HttpPost]
        [Route("{id}/action-open-matched-serial")]
        public async Task<IActionResult> ActionOpenMatchedSerialAsync(Guid id)
        {
            var result = await _appService.OpenMatchedSerialAsync(id);
            return Ok(result);
        }
    }
}