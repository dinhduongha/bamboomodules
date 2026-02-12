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
    [Route("api/v1/sales/RestaurantFloor")]
    public partial class RestaurantFloorController : AbpController
    {
        protected readonly IRestaurantFloorAppService _appService;
        public RestaurantFloorController(IRestaurantFloorAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("deactivate-floor")]
        public async Task<IActionResult> DeactivateFloorAsync([FromBody] RestaurantFloorDeactivateFloorRequestDto input)
        {
            var result = await _appService.DeactivateFloorAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rename-floor")]
        public async Task<IActionResult> RenameFloorAsync([FromBody] RestaurantFloorRenameFloorRequestDto input)
        {
            var result = await _appService.RenameFloorAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sync-from-ui")]
        public async Task<IActionResult> SyncFromUiAsync([FromBody] RestaurantFloorSyncFromUiRequestDto input)
        {
            var result = await _appService.SyncFromUiAsync(input);
            return Ok(result);
        }
    }
    
}