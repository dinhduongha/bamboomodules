using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrModelController
    {
        
        [HttpPost]
        [Route("{id}/display-name-for")]
        public async Task<IActionResult> DisplayNameForAsync(Guid id, [FromBody] IrModelDisplayNameForRequestDto input)
        {
            var result = await _appService.DisplayNameForAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-authorized-fields")]
        public async Task<IActionResult> GetAuthorizedFieldsAsync(Guid id, [FromBody] IrModelGetAuthorizedFieldsRequestDto input)
        {
            var result = await _appService.GetAuthorizedFieldsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-available-models")]
        public async Task<IActionResult> GetAvailableModelsAsync(Guid id)
        {
            var result = await _appService.GetAvailableModelsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-compatible-form-models")]
        public async Task<IActionResult> GetCompatibleFormModelsAsync(Guid id)
        {
            var result = await _appService.GetCompatibleFormModelsAsync(id);
            return Ok(result);
        }
    }
}