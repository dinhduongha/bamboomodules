using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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