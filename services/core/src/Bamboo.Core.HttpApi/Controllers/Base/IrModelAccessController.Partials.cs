using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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
            var result = await _appService.CheckAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/group-names-with-access")]
        public async Task<IActionResult> GroupNamesWithAccessAsync(Guid id, [FromBody] IrModelAccessGroupNamesWithAccessRequestDto input)
        {
            var result = await _appService.GroupNamesWithAccessAsync(id, input);
            return Ok(result);
        }
    }
}