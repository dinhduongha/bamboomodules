using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    public partial class GamificationBadgeUserController
    {
        
        [HttpPost]
        [Route("{id}/action-open-badge")]
        public async Task<IActionResult> ActionOpenBadgeAsync(Guid id)
        {
            var result = await _appService.OpenBadgeAsync(id);
            return Ok(result);
        }
    }
}