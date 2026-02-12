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
    [Route("api/v1/base/IrModelFields")]
    public partial class IrModelFieldsController : AbpController
    {
        protected readonly IIrModelFieldsAppService _appService;
        public IrModelFieldsController(IIrModelFieldsAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("formbuilder-whitelist")]
        public async Task<IActionResult> FormbuilderWhitelistAsync([FromBody] IrModelFieldsFormbuilderWhitelistRequestDto input)
        {
            var result = await _appService.FormbuilderWhitelistAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-field-help")]
        public async Task<IActionResult> GetFieldHelpAsync([FromBody] IrModelFieldsGetFieldHelpRequestDto input)
        {
            var result = await _appService.GetFieldHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-field-selection")]
        public async Task<IActionResult> GetFieldSelectionAsync([FromBody] IrModelFieldsGetFieldSelectionRequestDto input)
        {
            var result = await _appService.GetFieldSelectionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-field-string")]
        public async Task<IActionResult> GetFieldStringAsync([FromBody] IrModelFieldsGetFieldStringRequestDto input)
        {
            var result = await _appService.GetFieldStringAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
    
}