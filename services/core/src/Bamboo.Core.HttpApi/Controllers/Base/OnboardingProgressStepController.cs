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
    [Route("api/v1/onboarding/OnboardingProgressStep")]
    public partial class OnboardingProgressStepController : AbpController
    {
        protected readonly IOnboardingProgressStepAppService _appService;
        public OnboardingProgressStepController(IOnboardingProgressStepAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-consolidate-just-done")]
        public async Task<IActionResult> ConsolidateJustDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConsolidateJustDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-just-done")]
        public async Task<IActionResult> SetJustDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetJustDoneAsync(ids);
            return Ok(result);
        }
    }
    
}