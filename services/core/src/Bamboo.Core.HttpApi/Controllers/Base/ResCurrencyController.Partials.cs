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
        [Route("amount-to-text")]
        public async Task<IActionResult> AmountToTextAsync(ResCurrencyAmountToTextRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AmountToTextAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compare-amounts")]
        public async Task<IActionResult> CompareAmountsAsync(ResCurrencyCompareAmountsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CompareAmountsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format")]
        public async Task<IActionResult> FormatAsync(ResCurrencyFormatRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormatAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-all-currencies")]
        public async Task<IActionResult> GetAllCurrenciesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAllCurrenciesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-company-currency-for-spreadsheet")]
        public async Task<IActionResult> GetCompanyCurrencyForSpreadsheetAsync(ResCurrencyGetCompanyCurrencyForSpreadsheetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetCompanyCurrencyForSpreadsheetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-zero")]
        public async Task<IActionResult> IsZeroAsync(ResCurrencyIsZeroRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsZeroAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("round")]
        public async Task<IActionResult> RoundAsync(ResCurrencyRoundRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RoundAsync(input);
            return Ok(result);
        }
    }
}