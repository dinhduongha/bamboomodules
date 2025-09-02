using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResCurrencyRateController
    {
        
        [HttpPost]
        [Route("{id}/get-rates-for-spreadsheet")]
        public async Task<IActionResult> GetRatesForSpreadsheetAsync(Guid id, [FromBody] ResCurrencyRateGetRatesForSpreadsheetRequestDto input)
        {
            var result = await _appService.GetRatesForSpreadsheetAsync(id, input);
            return Ok(result);
        }
    }
}