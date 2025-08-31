using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountRootController
    {
        
        [HttpPost]
        [Route("{id}/browse")]
        public async Task<IActionResult> BrowseAsync(Guid id, [FromBody] AccountRootBrowseRequestDto input)
        {
            var result = await _appService.BrowseAsync(id, input.Ids);
            return Ok(result);
        }
    }
}