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
    [Route("api/v1/base-import/BaseImportImport")]
    public partial class BaseImportImportController : AbpController
    {
        protected readonly IBaseImportImportAppService _appService;
        public BaseImportImportController(IBaseImportImportAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("execute-import")]
        public async Task<IActionResult> ExecuteImportAsync([FromBody] BaseImportImportExecuteImportRequestDto input)
        {
            var result = await _appService.ExecuteImportAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-fields-tree")]
        public async Task<IActionResult> GetFieldsTreeAsync([FromBody] BaseImportImportGetFieldsTreeRequestDto input)
        {
            var result = await _appService.GetFieldsTreeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("parse-preview")]
        public async Task<IActionResult> ParsePreviewAsync([FromBody] BaseImportImportParsePreviewRequestDto input)
        {
            var result = await _appService.ParsePreviewAsync(input);
            return Ok(result);
        }
    }
    
}