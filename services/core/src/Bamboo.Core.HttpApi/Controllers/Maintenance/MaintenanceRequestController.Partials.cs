using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Maintenance
{
    public partial class MaintenanceRequestController
    {
        
        [HttpPost]
        [Route("{id}/activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync(Guid id)
        {
            var result = await _appService.ActivityUpdateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/archive-equipment-request")]
        public async Task<IActionResult> ArchiveEquipmentRequestAsync(Guid id)
        {
            var result = await _appService.ArchiveEquipmentRequestAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-new")]
        public async Task<IActionResult> MessageNewAsync(Guid id, [FromBody] MaintenanceRequestMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reset-equipment-request")]
        public async Task<IActionResult> ResetEquipmentRequestAsync(Guid id)
        {
            var result = await _appService.ResetEquipmentRequestAsync(id);
            return Ok(result);
        }
    }
}