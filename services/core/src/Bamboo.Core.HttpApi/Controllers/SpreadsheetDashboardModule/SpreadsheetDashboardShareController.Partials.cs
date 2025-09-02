using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.SpreadsheetDashboardModule
{
    public partial class SpreadsheetDashboardShareController
    {
        
        [HttpPost]
        [Route("{id}/action-get-share-url")]
        public async Task<IActionResult> ActionGetShareUrlAsync(Guid id, [FromBody] SpreadsheetDashboardShareGetShareUrlRequestDto input)
        {
            var result = await _appService.GetShareUrlAsync(id, input);
            return Ok(result);
        }
    }
}