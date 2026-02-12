using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/accounting/AccountCashRounding")]
    public partial class AccountCashRoundingController : AbpController
    {
        protected readonly IAccountCashRoundingAppService _appService;
        public AccountCashRoundingController(IAccountCashRoundingAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("compute-difference")]
        public async Task<IActionResult> ComputeDifferenceAsync([FromBody] AccountCashRoundingComputeDifferenceRequestDto input)
        {
            var result = await _appService.ComputeDifferenceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("round")]
        public async Task<IActionResult> RoundAsync([FromBody] AccountCashRoundingRoundRequestDto input)
        {
            var result = await _appService.RoundAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate-rounding")]
        public async Task<IActionResult> ValidateRoundingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateRoundingAsync(ids);
            return Ok(result);
        }
    }
    
}