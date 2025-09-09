using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Fleet
{
    public partial class FleetVehicleAssignationLogController
    {
        
        [HttpPost]
        [Route("{id}/action-get-attachment-view")]
        public async Task<IActionResult> ActionGetAttachmentViewAsync(Guid id)
        {
            var result = await _appService.GetAttachmentViewAsync(id);
            return Ok(result);
        }
    }
}