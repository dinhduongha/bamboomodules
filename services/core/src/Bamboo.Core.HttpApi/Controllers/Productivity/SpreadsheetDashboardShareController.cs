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
    [Route("api/v1/productivity/SpreadsheetDashboardShare")]
    public partial class SpreadsheetDashboardShareController : AbpController
    {
        protected readonly ISpreadsheetDashboardShareAppService _appService;
        public SpreadsheetDashboardShareController(ISpreadsheetDashboardShareAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-get-share-url")]
        public async Task<IActionResult> GetShareUrlAsync([FromBody] SpreadsheetDashboardShareGetShareUrlRequestDto input)
        {
            var result = await _appService.GetShareUrlAsync(input);
            return Ok(result);
        }
    }
    
}