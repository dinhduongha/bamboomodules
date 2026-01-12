using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResCurrencyController
    {
        
        [HttpPost]
        [Route("{id}/amount-to-text")]
        public async Task<IActionResult> AmountToTextAsync(Guid id, [FromBody] ResCurrencyAmountToTextRequestDto input)
        {
            var result = await _appService.AmountToTextAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compare-amounts")]
        public async Task<IActionResult> CompareAmountsAsync(Guid id, [FromBody] ResCurrencyCompareAmountsRequestDto input)
        {
            var result = await _appService.CompareAmountsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format")]
        public async Task<IActionResult> FormatAsync(Guid id, [FromBody] ResCurrencyFormatRequestDto input)
        {
            var result = await _appService.FormatAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-company-currency-for-spreadsheet")]
        public async Task<IActionResult> GetCompanyCurrencyForSpreadsheetAsync(Guid id, [FromBody] ResCurrencyGetCompanyCurrencyForSpreadsheetRequestDto input)
        {
            var result = await _appService.GetCompanyCurrencyForSpreadsheetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-zero")]
        public async Task<IActionResult> IsZeroAsync(Guid id, [FromBody] ResCurrencyIsZeroRequestDto input)
        {
            var result = await _appService.IsZeroAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/round")]
        public async Task<IActionResult> RoundAsync(Guid id, [FromBody] ResCurrencyRoundRequestDto input)
        {
            var result = await _appService.RoundAsync(id, input);
            return Ok(result);
        }
    }
}