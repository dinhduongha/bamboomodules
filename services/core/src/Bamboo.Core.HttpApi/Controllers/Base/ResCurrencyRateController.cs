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
    [Route("api/v1/base/ResCurrencyRate")]
    public partial class ResCurrencyRateController : AbpController
    {
        protected readonly IResCurrencyRateAppService _appService;
        public ResCurrencyRateController(IResCurrencyRateAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-rates-for-spreadsheet")]
        public async Task<IActionResult> GetRatesForSpreadsheetAsync([FromBody] ResCurrencyRateGetRatesForSpreadsheetRequestDto input)
        {
            var result = await _appService.GetRatesForSpreadsheetAsync(input);
            return Ok(result);
        }
    }
    
}