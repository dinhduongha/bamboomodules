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
    [Route("api/v1/supply-chain/MaintenanceEquipment")]
    public partial class MaintenanceEquipmentController : AbpController
    {
        protected readonly IMaintenanceEquipmentAppService _appService;
        public MaintenanceEquipmentController(IMaintenanceEquipmentAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-matched-serial")]
        public async Task<IActionResult> OpenMatchedSerialAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenMatchedSerialAsync(ids);
            return Ok(result);
        }
    }
    
}