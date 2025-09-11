using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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