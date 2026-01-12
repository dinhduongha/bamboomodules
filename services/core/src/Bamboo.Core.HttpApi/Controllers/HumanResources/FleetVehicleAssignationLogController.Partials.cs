using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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