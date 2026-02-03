using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SpreadsheetDashboardShareController
    {
        
        [HttpPost]
        [Route("action-get-share-url")]
        public async Task<IActionResult> ActionGetShareUrlAsync(SpreadsheetDashboardShareGetShareUrlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetShareUrlAsync(input);
            return Ok(result);
        }
    }
}