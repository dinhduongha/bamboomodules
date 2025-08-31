using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PartnerAutocomplete
{
    public partial class ResPartnerAutocompleteSyncController
    {
        
        [HttpPost]
        [Route("{id}/add-to-queue")]
        public async Task<IActionResult> AddToQueueAsync(Guid id, [FromBody] ResPartnerAutocompleteSyncAddToQueueRequestDto input)
        {
            var result = await _appService.AddToQueueAsync(id, input.PartnerId);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/start-sync")]
        public async Task<IActionResult> StartSyncAsync(Guid id, [FromBody] ResPartnerAutocompleteSyncStartSyncRequestDto input)
        {
            var result = await _appService.StartSyncAsync(id, input.BatchSize);
            return Ok(result);
        }
    }
}