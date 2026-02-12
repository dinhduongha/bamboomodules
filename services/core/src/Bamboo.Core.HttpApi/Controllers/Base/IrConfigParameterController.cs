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
    [Route("api/v1/base/IrConfigParameter")]
    public partial class IrConfigParameterController : AbpController
    {
        protected readonly IIrConfigParameterAppService _appService;
        public IrConfigParameterController(IIrConfigParameterAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-param")]
        public async Task<IActionResult> GetParamAsync([FromBody] IrConfigParameterGetParamRequestDto input)
        {
            var result = await _appService.GetParamAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] IrConfigParameterInitRequestDto input)
        {
            var result = await _appService.InitAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-param")]
        public async Task<IActionResult> SetParamAsync([FromBody] IrConfigParameterSetParamRequestDto input)
        {
            var result = await _appService.SetParamAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-default-parameters")]
        public async Task<IActionResult> UnlinkDefaultParametersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnlinkDefaultParametersAsync(ids);
            return Ok(result);
        }
    }
    
}