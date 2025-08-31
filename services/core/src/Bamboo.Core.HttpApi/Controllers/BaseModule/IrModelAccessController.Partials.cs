using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrModelAccessController
    {
        
        [HttpPost]
        [Route("{id}/call-cache-clearing-methods")]
        public async Task<IActionResult> CallCacheClearingMethodsAsync(Guid id)
        {
            var result = await _appService.CallCacheClearingMethodsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check")]
        public async Task<IActionResult> CheckAsync(Guid id, [FromBody] IrModelAccessCheckRequestDto input)
        {
            var result = await _appService.CheckAsync(id, input.Model, input.Mode, input.RaiseException);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/group-names-with-access")]
        public async Task<IActionResult> GroupNamesWithAccessAsync(Guid id, [FromBody] IrModelAccessGroupNamesWithAccessRequestDto input)
        {
            var result = await _appService.GroupNamesWithAccessAsync(id, input.ModelName, input.AccessMode);
            return Ok(result);
        }
    }
}