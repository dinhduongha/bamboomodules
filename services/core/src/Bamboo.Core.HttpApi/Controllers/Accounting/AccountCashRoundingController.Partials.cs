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
        [Route("compute-difference")]
        public async Task<IActionResult> ComputeDifferenceAsync(AccountCashRoundingComputeDifferenceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ComputeDifferenceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("round")]
        public async Task<IActionResult> RoundAsync(AccountCashRoundingRoundRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RoundAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate-rounding")]
        public async Task<IActionResult> ValidateRoundingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateRoundingAsync(ids);
            return Ok(result);
        }
    }
}