using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrCronController
    {
        
        [HttpPost]
        [Route("method-direct-trigger")]
        public async Task<IActionResult> MethodDirectTriggerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MethodDirectTriggerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle")]
        public async Task<IActionResult> ToggleAsync(IrCronToggleRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToggleAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("try-write")]
        public async Task<IActionResult> TryWriteAsync(IrCronTryWriteRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.TryWriteAsync(input);
            return Ok(result);
        }
    }
}