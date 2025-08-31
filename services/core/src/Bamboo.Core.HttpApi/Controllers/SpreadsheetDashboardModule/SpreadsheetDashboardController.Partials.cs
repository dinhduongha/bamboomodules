using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.SpreadsheetDashboardModule
{
    public partial class SpreadsheetDashboardController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] SpreadsheetDashboardCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-readonly-dashboard")]
        public async Task<IActionResult> GetReadonlyDashboardAsync(Guid id)
        {
            var result = await _appService.GetReadonlyDashboardAsync(id);
            return Ok(result);
        }
    }
}