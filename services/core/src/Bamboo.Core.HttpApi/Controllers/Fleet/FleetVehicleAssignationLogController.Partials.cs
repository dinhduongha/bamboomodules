using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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