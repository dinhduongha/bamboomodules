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
    [Route("api/v1/base/ResCurrency")]
    public partial class ResCurrencyController : AbpController
    {
        protected readonly IResCurrencyAppService _appService;
        public ResCurrencyController(IResCurrencyAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("amount-to-text")]
        public async Task<IActionResult> AmountToTextAsync([FromBody] ResCurrencyAmountToTextRequestDto input)
        {
            var result = await _appService.AmountToTextAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compare-amounts")]
        public async Task<IActionResult> CompareAmountsAsync([FromBody] ResCurrencyCompareAmountsRequestDto input)
        {
            var result = await _appService.CompareAmountsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format")]
        public async Task<IActionResult> FormatAsync([FromBody] ResCurrencyFormatRequestDto input)
        {
            var result = await _appService.FormatAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-all-currencies")]
        public async Task<IActionResult> GetAllCurrenciesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAllCurrenciesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-company-currency-for-spreadsheet")]
        public async Task<IActionResult> GetCompanyCurrencyForSpreadsheetAsync([FromBody] ResCurrencyGetCompanyCurrencyForSpreadsheetRequestDto input)
        {
            var result = await _appService.GetCompanyCurrencyForSpreadsheetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-zero")]
        public async Task<IActionResult> IsZeroAsync([FromBody] ResCurrencyIsZeroRequestDto input)
        {
            var result = await _appService.IsZeroAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("round")]
        public async Task<IActionResult> RoundAsync([FromBody] ResCurrencyRoundRequestDto input)
        {
            var result = await _appService.RoundAsync(input);
            return Ok(result);
        }
    }
    
}