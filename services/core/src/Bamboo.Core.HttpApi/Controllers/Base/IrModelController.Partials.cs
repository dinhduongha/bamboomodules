using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrModelController
    {
        
        [HttpPost]
        [Route("display-name-for")]
        public async Task<IActionResult> DisplayNameForAsync(IrModelDisplayNameForRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DisplayNameForAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-authorized-fields")]
        public async Task<IActionResult> GetAuthorizedFieldsAsync(IrModelGetAuthorizedFieldsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAuthorizedFieldsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-available-models")]
        public async Task<IActionResult> GetAvailableModelsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAvailableModelsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-compatible-form-models")]
        public async Task<IActionResult> GetCompatibleFormModelsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetCompatibleFormModelsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-searchable-parent-relation")]
        public async Task<IActionResult> HasSearchableParentRelationAsync(IrModelHasSearchableParentRelationRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.HasSearchableParentRelationAsync(input);
            return Ok(result);
        }
    }
}