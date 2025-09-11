using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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