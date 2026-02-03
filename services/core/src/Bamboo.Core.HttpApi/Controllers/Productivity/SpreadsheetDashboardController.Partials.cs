using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SpreadsheetDashboardController
    {
        
        [HttpPost]
        [Route("action-toggle-favorite")]
        public async Task<IActionResult> ActionToggleFavoriteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleFavoriteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(SpreadsheetDashboardCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
}