using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrCronController
    {
        
        [HttpPost]
        [Route("{id}/method-direct-trigger")]
        public async Task<IActionResult> MethodDirectTriggerAsync(Guid id)
        {
            var result = await _appService.MethodDirectTriggerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle")]
        public async Task<IActionResult> ToggleAsync(Guid id, [FromBody] IrCronToggleRequestDto input)
        {
            var result = await _appService.ToggleAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/try-write")]
        public async Task<IActionResult> TryWriteAsync(Guid id, [FromBody] IrCronTryWriteRequestDto input)
        {
            var result = await _appService.TryWriteAsync(id, input);
            return Ok(result);
        }
    }
}