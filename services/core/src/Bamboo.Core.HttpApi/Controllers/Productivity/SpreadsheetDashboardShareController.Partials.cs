using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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