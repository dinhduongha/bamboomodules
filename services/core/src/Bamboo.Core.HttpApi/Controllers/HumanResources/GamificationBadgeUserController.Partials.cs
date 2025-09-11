using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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