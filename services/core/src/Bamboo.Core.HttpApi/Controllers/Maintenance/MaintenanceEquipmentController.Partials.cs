using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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