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
        [Route("{id}/action-open-badge")]
        public async Task<IActionResult> ActionOpenBadgeAsync(Guid id)
        {
            var result = await _appService.OpenBadgeAsync(id);
            return Ok(result);
        }
    }
}