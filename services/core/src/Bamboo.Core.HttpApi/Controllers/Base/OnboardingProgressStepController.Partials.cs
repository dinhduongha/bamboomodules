using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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