using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrConfigParameterController
    {
        
        [HttpPost]
        [Route("get-param")]
        public async Task<IActionResult> GetParamAsync(IrConfigParameterGetParamRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetParamAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync(IrConfigParameterInitRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.InitAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-param")]
        public async Task<IActionResult> SetParamAsync(IrConfigParameterSetParamRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetParamAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-default-parameters")]
        public async Task<IActionResult> UnlinkDefaultParametersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnlinkDefaultParametersAsync(ids);
            return Ok(result);
        }
    }
}