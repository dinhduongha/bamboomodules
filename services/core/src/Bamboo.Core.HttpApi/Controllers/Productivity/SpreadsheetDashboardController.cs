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
    [Route("api/v1/productivity/SpreadsheetDashboard")]
    public partial class SpreadsheetDashboardController : AbpController
    {
        protected readonly ISpreadsheetDashboardAppService _appService;
        public SpreadsheetDashboardController(ISpreadsheetDashboardAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-toggle-favorite")]
        public async Task<IActionResult> ToggleFavoriteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleFavoriteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] SpreadsheetDashboardCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
    
}