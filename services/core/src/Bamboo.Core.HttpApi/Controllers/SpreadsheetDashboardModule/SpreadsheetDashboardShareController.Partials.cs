using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.SpreadsheetDashboardModule
{
    public partial class SpreadsheetDashboardShareController
    {
        
        [HttpPost]
        [Route("{id}/action-get-share-url")]
        public async Task<IActionResult> ActionGetShareUrlAsync(Guid id, [FromBody] SpreadsheetDashboardShareGetShareUrlRequestDto input)
        {
            var result = await _appService.GetShareUrlAsync(id, input.Vals);
            return Ok(result);
        }
    }
}