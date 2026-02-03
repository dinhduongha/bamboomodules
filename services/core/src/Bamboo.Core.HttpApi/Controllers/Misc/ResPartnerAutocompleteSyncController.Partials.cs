using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResPartnerAutocompleteSyncController
    {
        
        [HttpPost]
        [Route("add-to-queue")]
        public async Task<IActionResult> AddToQueueAsync(ResPartnerAutocompleteSyncAddToQueueRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AddToQueueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("start-sync")]
        public async Task<IActionResult> StartSyncAsync(ResPartnerAutocompleteSyncStartSyncRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.StartSyncAsync(input);
            return Ok(result);
        }
    }
}