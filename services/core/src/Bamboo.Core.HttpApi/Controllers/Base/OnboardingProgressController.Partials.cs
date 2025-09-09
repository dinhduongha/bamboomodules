using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    public partial class OnboardingProgressController
    {
        
        [HttpPost]
        [Route("{id}/action-close")]
        public async Task<IActionResult> ActionCloseAsync(Guid id)
        {
            var result = await _appService.CloseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-toggle-visibility")]
        public async Task<IActionResult> ActionToggleVisibilityAsync(Guid id)
        {
            var result = await _appService.ToggleVisibilityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
    }
}