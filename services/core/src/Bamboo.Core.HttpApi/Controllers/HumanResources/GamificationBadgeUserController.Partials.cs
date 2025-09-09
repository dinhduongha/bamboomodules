using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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