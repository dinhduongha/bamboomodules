using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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