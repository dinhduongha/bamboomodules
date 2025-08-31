using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    public partial class WebsiteRewriteController
    {
        
        [HttpPost]
        [Route("{id}/refresh-routes")]
        public async Task<IActionResult> RefreshRoutesAsync(Guid id)
        {
            var result = await _appService.RefreshRoutesAsync(id);
            return Ok(result);
        }
    }
}