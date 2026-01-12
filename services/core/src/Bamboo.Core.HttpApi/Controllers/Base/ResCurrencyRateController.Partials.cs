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
        [Route("{id}/get-rates-for-spreadsheet")]
        public async Task<IActionResult> GetRatesForSpreadsheetAsync(Guid id, [FromBody] ResCurrencyRateGetRatesForSpreadsheetRequestDto input)
        {
            var result = await _appService.GetRatesForSpreadsheetAsync(id, input);
            return Ok(result);
        }
    }
}