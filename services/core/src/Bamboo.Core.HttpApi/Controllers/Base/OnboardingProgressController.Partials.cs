using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class OnboardingProgressController
    {
        
        [HttpPost]
        [Route("action-close")]
        public async Task<IActionResult> ActionCloseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-visibility")]
        public async Task<IActionResult> ActionToggleVisibilityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleVisibilityAsync(ids);
            return Ok(result);
        }
    }
}