using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrConfigParameterController
    {
        
        [HttpPost]
        [Route("{id}/get-param")]
        public async Task<IActionResult> GetParamAsync(Guid id, [FromBody] IrConfigParameterGetParamRequestDto input)
        {
            var result = await _appService.GetParamAsync(id, input.Key, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id, [FromBody] IrConfigParameterInitRequestDto input)
        {
            var result = await _appService.InitAsync(id, input.Force);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-param")]
        public async Task<IActionResult> SetParamAsync(Guid id, [FromBody] IrConfigParameterSetParamRequestDto input)
        {
            var result = await _appService.SetParamAsync(id, input.Key, input.Value);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unlink-default-parameters")]
        public async Task<IActionResult> UnlinkDefaultParametersAsync(Guid id)
        {
            var result = await _appService.UnlinkDefaultParametersAsync(id);
            return Ok(result);
        }
    }
}