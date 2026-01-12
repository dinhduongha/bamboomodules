using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class RestaurantFloorController
    {
        
        [HttpPost]
        [Route("{id}/deactivate-floor")]
        public async Task<IActionResult> DeactivateFloorAsync(Guid id, [FromBody] RestaurantFloorDeactivateFloorRequestDto input)
        {
            var result = await _appService.DeactivateFloorAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/rename-floor")]
        public async Task<IActionResult> RenameFloorAsync(Guid id, [FromBody] RestaurantFloorRenameFloorRequestDto input)
        {
            var result = await _appService.RenameFloorAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/sync-from-ui")]
        public async Task<IActionResult> SyncFromUiAsync(Guid id, [FromBody] RestaurantFloorSyncFromUiRequestDto input)
        {
            var result = await _appService.SyncFromUiAsync(id, input);
            return Ok(result);
        }
    }
}