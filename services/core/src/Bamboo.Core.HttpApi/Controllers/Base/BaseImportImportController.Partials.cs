using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class BaseImportImportController
    {
        
        [HttpPost]
        [Route("execute-import")]
        public async Task<IActionResult> ExecuteImportAsync(BaseImportImportExecuteImportRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ExecuteImportAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-fields-tree")]
        public async Task<IActionResult> GetFieldsTreeAsync(BaseImportImportGetFieldsTreeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFieldsTreeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-preview")]
        public async Task<IActionResult> ParsePreviewAsync(BaseImportImportParsePreviewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ParsePreviewAsync(input);
            return Ok(result);
        }
    }
}