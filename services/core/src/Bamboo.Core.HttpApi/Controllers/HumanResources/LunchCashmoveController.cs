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
    [Route("api/v1/human-resources/LunchCashmove")]
    public partial class LunchCashmoveController : AbpController
    {
        protected readonly ILunchCashmoveAppService _appService;
        public LunchCashmoveController(ILunchCashmoveAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-wallet-balance")]
        public async Task<IActionResult> GetWalletBalanceAsync([FromBody] LunchCashmoveGetWalletBalanceRequestDto input)
        {
            var result = await _appService.GetWalletBalanceAsync(input);
            return Ok(result);
        }
    }
    
}