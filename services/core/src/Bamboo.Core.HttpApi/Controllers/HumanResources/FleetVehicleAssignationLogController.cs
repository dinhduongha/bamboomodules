using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/FleetVehicleAssignationLog")]
    public partial class FleetVehicleAssignationLogController : AbpController
    {
        protected readonly IFleetVehicleAssignationLogAppService _appService;
        public FleetVehicleAssignationLogController(IFleetVehicleAssignationLogAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-get-attachment-view")]
        public async Task<IActionResult> GetAttachmentViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAttachmentViewAsync(ids);
            return Ok(result);
        }
    }
    
}