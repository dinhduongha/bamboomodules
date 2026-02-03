using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class GamificationBadgeUserController
    {
        
        [HttpPost]
        [Route("action-open-badge")]
        public async Task<IActionResult> ActionOpenBadgeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenBadgeAsync(ids);
            return Ok(result);
        }
    }
}