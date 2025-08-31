using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Onboarding
{
    public partial class OnboardingProgressStepController
    {
        
        [HttpPost]
        [Route("{id}/action-consolidate-just-done")]
        public async Task<IActionResult> ActionConsolidateJustDoneAsync(Guid id)
        {
            var result = await _appService.ConsolidateJustDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-just-done")]
        public async Task<IActionResult> ActionSetJustDoneAsync(Guid id)
        {
            var result = await _appService.SetJustDoneAsync(id);
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