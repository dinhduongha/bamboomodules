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
    [Route("api/v1/base/IrModel")]
    public partial class IrModelController : AbpController
    {
        protected readonly IIrModelAppService _appService;
        public IrModelController(IIrModelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("display-name-for")]
        public async Task<IActionResult> DisplayNameForAsync([FromBody] IrModelDisplayNameForRequestDto input)
        {
            var result = await _appService.DisplayNameForAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-authorized-fields")]
        public async Task<IActionResult> GetAuthorizedFieldsAsync([FromBody] IrModelGetAuthorizedFieldsRequestDto input)
        {
            var result = await _appService.GetAuthorizedFieldsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-available-models")]
        public async Task<IActionResult> GetAvailableModelsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAvailableModelsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-compatible-form-models")]
        public async Task<IActionResult> GetCompatibleFormModelsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetCompatibleFormModelsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-searchable-parent-relation")]
        public async Task<IActionResult> HasSearchableParentRelationAsync([FromBody] IrModelHasSearchableParentRelationRequestDto input)
        {
            var result = await _appService.HasSearchableParentRelationAsync(input);
            return Ok(result);
        }
    }
    
}