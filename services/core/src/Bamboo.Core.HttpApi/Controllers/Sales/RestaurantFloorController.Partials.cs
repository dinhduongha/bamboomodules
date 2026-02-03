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
        [Route("deactivate-floor")]
        public async Task<IActionResult> DeactivateFloorAsync(RestaurantFloorDeactivateFloorRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DeactivateFloorAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rename-floor")]
        public async Task<IActionResult> RenameFloorAsync(RestaurantFloorRenameFloorRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RenameFloorAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sync-from-ui")]
        public async Task<IActionResult> SyncFromUiAsync(RestaurantFloorSyncFromUiRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SyncFromUiAsync(input);
            return Ok(result);
        }
    }
}