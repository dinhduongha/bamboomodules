using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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