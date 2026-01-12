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
        [Route("{id}/add-to-queue")]
        public async Task<IActionResult> AddToQueueAsync(Guid id, [FromBody] ResPartnerAutocompleteSyncAddToQueueRequestDto input)
        {
            var result = await _appService.AddToQueueAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/start-sync")]
        public async Task<IActionResult> StartSyncAsync(Guid id, [FromBody] ResPartnerAutocompleteSyncStartSyncRequestDto input)
        {
            var result = await _appService.StartSyncAsync(id, input);
            return Ok(result);
        }
    }
}