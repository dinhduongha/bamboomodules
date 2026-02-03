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
        [Route("formbuilder-whitelist")]
        public async Task<IActionResult> FormbuilderWhitelistAsync(IrModelFieldsFormbuilderWhitelistRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormbuilderWhitelistAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-field-help")]
        public async Task<IActionResult> GetFieldHelpAsync(IrModelFieldsGetFieldHelpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFieldHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-field-selection")]
        public async Task<IActionResult> GetFieldSelectionAsync(IrModelFieldsGetFieldSelectionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFieldSelectionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-field-string")]
        public async Task<IActionResult> GetFieldStringAsync(IrModelFieldsGetFieldStringRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFieldStringAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
}