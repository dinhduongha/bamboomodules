using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    public partial class LunchCashmoveController
    {
        
        [HttpPost]
        [Route("{id}/get-wallet-balance")]
        public async Task<IActionResult> GetWalletBalanceAsync(Guid id, [FromBody] LunchCashmoveGetWalletBalanceRequestDto input)
        {
            var result = await _appService.GetWalletBalanceAsync(id, input.User, input.IncludeConfig);
            return Ok(result);
        }
    }
}