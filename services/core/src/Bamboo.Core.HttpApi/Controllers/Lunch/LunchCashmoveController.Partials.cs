using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    public partial class LunchCashmoveController
    {
        
        [HttpPost]
        [Route("{id}/get-wallet-balance")]
        public async Task<IActionResult> GetWalletBalanceAsync(Guid id, [FromBody] LunchCashmoveGetWalletBalanceRequestDto input)
        {
            var result = await _appService.GetWalletBalanceAsync(id, input);
            return Ok(result);
        }
    }
}