using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/onboarding/OnboardingProgress")]
    public partial class OnboardingProgressController : AbpController
    {
        protected readonly IOnboardingProgressAppService _appService;
        public OnboardingProgressController(IOnboardingProgressAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-close")]
        public async Task<IActionResult> CloseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-visibility")]
        public async Task<IActionResult> ToggleVisibilityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleVisibilityAsync(ids);
            return Ok(result);
        }
    }
    
}