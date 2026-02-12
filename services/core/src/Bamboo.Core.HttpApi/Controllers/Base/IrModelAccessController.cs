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
    [Route("api/v1/base/IrModelAccess")]
    public partial class IrModelAccessController : AbpController
    {
        protected readonly IIrModelAccessAppService _appService;
        public IrModelAccessController(IIrModelAccessAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("call-cache-clearing-methods")]
        public async Task<IActionResult> CallCacheClearingMethodsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CallCacheClearingMethodsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check")]
        public async Task<IActionResult> CheckAsync([FromBody] IrModelAccessCheckRequestDto input)
        {
            var result = await _appService.CheckAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("group-names-with-access")]
        public async Task<IActionResult> GroupNamesWithAccessAsync([FromBody] IrModelAccessGroupNamesWithAccessRequestDto input)
        {
            var result = await _appService.GroupNamesWithAccessAsync(input);
            return Ok(result);
        }
    }
    
}