using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResCurrencyRateController
    {
        
        [HttpPost]
        [Route("get-rates-for-spreadsheet")]
        public async Task<IActionResult> GetRatesForSpreadsheetAsync(ResCurrencyRateGetRatesForSpreadsheetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetRatesForSpreadsheetAsync(input);
            return Ok(result);
        }
    }
}