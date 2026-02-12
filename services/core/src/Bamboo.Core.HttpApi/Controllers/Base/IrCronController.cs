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
    [Route("api/v1/base/IrCron")]
    public partial class IrCronController : AbpController
    {
        protected readonly IIrCronAppService _appService;
        public IrCronController(IIrCronAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("method-direct-trigger")]
        public async Task<IActionResult> MethodDirectTriggerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MethodDirectTriggerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle")]
        public async Task<IActionResult> ToggleAsync([FromBody] IrCronToggleRequestDto input)
        {
            var result = await _appService.ToggleAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("try-write")]
        public async Task<IActionResult> TryWriteAsync([FromBody] IrCronTryWriteRequestDto input)
        {
            var result = await _appService.TryWriteAsync(input);
            return Ok(result);
        }
    }
    
}