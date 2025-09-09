using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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