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
    [Route("api/v1/supply-chain/MaintenanceRequest")]
    public partial class MaintenanceRequestController : AbpController
    {
        protected readonly IMaintenanceRequestAppService _appService;
        public MaintenanceRequestController(IMaintenanceRequestAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ActivityUpdateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("archive-equipment-request")]
        public async Task<IActionResult> ArchiveEquipmentRequestAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveEquipmentRequestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync([FromBody] MaintenanceRequestMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reset-equipment-request")]
        public async Task<IActionResult> ResetEquipmentRequestAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetEquipmentRequestAsync(ids);
            return Ok(result);
        }
    }
    
}