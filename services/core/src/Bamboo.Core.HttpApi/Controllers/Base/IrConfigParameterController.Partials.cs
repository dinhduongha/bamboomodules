using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrConfigParameterController
    {
        
        [HttpPost]
        [Route("{id}/get-param")]
        public async Task<IActionResult> GetParamAsync(Guid id, [FromBody] IrConfigParameterGetParamRequestDto input)
        {
            var result = await _appService.GetParamAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id, [FromBody] IrConfigParameterInitRequestDto input)
        {
            var result = await _appService.InitAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-param")]
        public async Task<IActionResult> SetParamAsync(Guid id, [FromBody] IrConfigParameterSetParamRequestDto input)
        {
            var result = await _appService.SetParamAsync(id, input);
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