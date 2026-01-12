using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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