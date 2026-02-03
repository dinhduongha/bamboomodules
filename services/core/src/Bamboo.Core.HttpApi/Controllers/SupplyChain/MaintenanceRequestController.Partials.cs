using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MaintenanceRequestController
    {
        
        [HttpPost]
        [Route("activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ActivityUpdateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("archive-equipment-request")]
        public async Task<IActionResult> ArchiveEquipmentRequestAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveEquipmentRequestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync(MaintenanceRequestMessageNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reset-equipment-request")]
        public async Task<IActionResult> ResetEquipmentRequestAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetEquipmentRequestAsync(ids);
            return Ok(result);
        }
    }
}