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
        [Route("{id}/action-get-share-url")]
        public async Task<IActionResult> ActionGetShareUrlAsync(Guid id, [FromBody] SpreadsheetDashboardShareGetShareUrlRequestDto input)
        {
            var result = await _appService.GetShareUrlAsync(id, input);
            return Ok(result);
        }
    }
}