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