using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResCurrencyRateController
    {
        
        [HttpPost]
        [Route("{id}/get-rates-for-spreadsheet")]
        public async Task<IActionResult> GetRatesForSpreadsheetAsync(Guid id, [FromBody] ResCurrencyRateGetRatesForSpreadsheetRequestDto input)
        {
            var result = await _appService.GetRatesForSpreadsheetAsync(id, input.Requests);
            return Ok(result);
        }
    }
}