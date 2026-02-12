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
    [Route("api/v1/base/IrProfile")]
    public partial class IrProfileController : AbpController
    {
        protected readonly IIrProfileAppService _appService;
        public IrProfileController(IIrProfileAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-view-speedscope")]
        public async Task<IActionResult> ViewSpeedscopeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSpeedscopeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-profiling")]
        public async Task<IActionResult> SetProfilingAsync([FromBody] IrProfileSetProfilingRequestDto input)
        {
            var result = await _appService.SetProfilingAsync(input);
            return Ok(result);
        }
    }
    
}