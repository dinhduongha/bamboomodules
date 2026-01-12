using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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