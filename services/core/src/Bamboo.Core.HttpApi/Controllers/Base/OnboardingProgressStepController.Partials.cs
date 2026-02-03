using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class OnboardingProgressStepController
    {
        
        [HttpPost]
        [Route("action-consolidate-just-done")]
        public async Task<IActionResult> ActionConsolidateJustDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConsolidateJustDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-just-done")]
        public async Task<IActionResult> ActionSetJustDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetJustDoneAsync(ids);
            return Ok(result);
        }
    }
}