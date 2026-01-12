using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountCashRoundingController
    {
        
        [HttpPost]
        [Route("{id}/compute-difference")]
        public async Task<IActionResult> ComputeDifferenceAsync(Guid id, [FromBody] AccountCashRoundingComputeDifferenceRequestDto input)
        {
            var result = await _appService.ComputeDifferenceAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/round")]
        public async Task<IActionResult> RoundAsync(Guid id, [FromBody] AccountCashRoundingRoundRequestDto input)
        {
            var result = await _appService.RoundAsync(id, input);
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