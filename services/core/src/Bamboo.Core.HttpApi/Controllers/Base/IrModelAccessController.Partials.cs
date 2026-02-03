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
        [Route("call-cache-clearing-methods")]
        public async Task<IActionResult> CallCacheClearingMethodsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CallCacheClearingMethodsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check")]
        public async Task<IActionResult> CheckAsync(IrModelAccessCheckRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("group-names-with-access")]
        public async Task<IActionResult> GroupNamesWithAccessAsync(IrModelAccessGroupNamesWithAccessRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GroupNamesWithAccessAsync(input);
            return Ok(result);
        }
    }
}