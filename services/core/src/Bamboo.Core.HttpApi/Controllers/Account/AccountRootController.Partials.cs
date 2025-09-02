using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountRootController
    {
        
        [HttpPost]
        [Route("{id}/browse")]
        public async Task<IActionResult> BrowseAsync(Guid id, [FromBody] AccountRootBrowseRequestDto input)
        {
            var result = await _appService.BrowseAsync(id, input);
            return Ok(result);
        }
    }
}