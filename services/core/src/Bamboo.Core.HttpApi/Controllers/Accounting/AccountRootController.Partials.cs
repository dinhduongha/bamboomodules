using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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