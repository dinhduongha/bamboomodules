using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProductFeedController
    {
        
        [HttpPost]
        [Route("{id}/action-invalidate-cache")]
        public async Task<IActionResult> ActionInvalidateCacheAsync(Guid id)
        {
            var result = await _appService.InvalidateCacheAsync(id);
            return Ok(result);
        }
    }
}