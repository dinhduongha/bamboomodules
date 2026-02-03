using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrProfileController
    {
        
        [HttpPost]
        [Route("action-view-speedscope")]
        public async Task<IActionResult> ActionViewSpeedscopeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSpeedscopeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-profiling")]
        public async Task<IActionResult> SetProfilingAsync(IrProfileSetProfilingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetProfilingAsync(input);
            return Ok(result);
        }
    }
}