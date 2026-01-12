using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrModelFieldsController
    {
        
        [HttpPost]
        [Route("{id}/formbuilder-whitelist")]
        public async Task<IActionResult> FormbuilderWhitelistAsync(Guid id, [FromBody] IrModelFieldsFormbuilderWhitelistRequestDto input)
        {
            var result = await _appService.FormbuilderWhitelistAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-field-help")]
        public async Task<IActionResult> GetFieldHelpAsync(Guid id, [FromBody] IrModelFieldsGetFieldHelpRequestDto input)
        {
            var result = await _appService.GetFieldHelpAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-field-selection")]
        public async Task<IActionResult> GetFieldSelectionAsync(Guid id, [FromBody] IrModelFieldsGetFieldSelectionRequestDto input)
        {
            var result = await _appService.GetFieldSelectionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-field-string")]
        public async Task<IActionResult> GetFieldStringAsync(Guid id, [FromBody] IrModelFieldsGetFieldStringRequestDto input)
        {
            var result = await _appService.GetFieldStringAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
    }
}