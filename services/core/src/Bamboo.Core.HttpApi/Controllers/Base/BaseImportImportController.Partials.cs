using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseImport
{
    public partial class BaseImportImportController
    {
        
        [HttpPost]
        [Route("{id}/execute-import")]
        public async Task<IActionResult> ExecuteImportAsync(Guid id, [FromBody] BaseImportImportExecuteImportRequestDto input)
        {
            var result = await _appService.ExecuteImportAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-fields-tree")]
        public async Task<IActionResult> GetFieldsTreeAsync(Guid id, [FromBody] BaseImportImportGetFieldsTreeRequestDto input)
        {
            var result = await _appService.GetFieldsTreeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/parse-preview")]
        public async Task<IActionResult> ParsePreviewAsync(Guid id, [FromBody] BaseImportImportParsePreviewRequestDto input)
        {
            var result = await _appService.ParsePreviewAsync(id, input);
            return Ok(result);
        }
    }
}