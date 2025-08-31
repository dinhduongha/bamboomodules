using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountCashRoundingController
    {
        
        [HttpPost]
        [Route("{id}/compute-difference")]
        public async Task<IActionResult> ComputeDifferenceAsync(Guid id, [FromBody] AccountCashRoundingComputeDifferenceRequestDto input)
        {
            var result = await _appService.ComputeDifferenceAsync(id, input.Currency, input.Amount);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/round")]
        public async Task<IActionResult> RoundAsync(Guid id, [FromBody] AccountCashRoundingRoundRequestDto input)
        {
            var result = await _appService.RoundAsync(id, input.Amount);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/validate-rounding")]
        public async Task<IActionResult> ValidateRoundingAsync(Guid id)
        {
            var result = await _appService.ValidateRoundingAsync(id);
            return Ok(result);
        }
    }
}