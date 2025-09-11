using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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