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
    [Route("api/v1/base/IrDefault")]
    public partial class IrDefaultController : AbpController
    {
        protected readonly IIrDefaultAppService _appService;
        public IrDefaultController(IIrDefaultAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("discard-records")]
        public async Task<IActionResult> DiscardRecordsAsync([FromBody] IrDefaultDiscardRecordsRequestDto input)
        {
            var result = await _appService.DiscardRecordsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("discard-values")]
        public async Task<IActionResult> DiscardValuesAsync([FromBody] IrDefaultDiscardValuesRequestDto input)
        {
            var result = await _appService.DiscardValuesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set")]
        public async Task<IActionResult> SetAsync([FromBody] IrDefaultSetRequestDto input)
        {
            var result = await _appService.SetAsync(input);
            return Ok(result);
        }
    }
    
}