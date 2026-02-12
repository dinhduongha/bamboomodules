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
    [Route("api/v1/base/ResLang")]
    public partial class ResLangController : AbpController
    {
        protected readonly IResLangAppService _appService;
        public ResLangController(IResLangAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-activate-langs")]
        public async Task<IActionResult> ActivateLangsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ActivateLangsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("c-a-c-h-e-d-f-i-e-l-d-s")]
        public async Task<IActionResult> CACHEDFIELDSAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CACHEDFIELDSAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ResLangCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format")]
        public async Task<IActionResult> FormatAsync([FromBody] ResLangFormatRequestDto input)
        {
            var result = await _appService.FormatAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-installed")]
        public async Task<IActionResult> GetInstalledAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetInstalledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-locales-for-spreadsheet")]
        public async Task<IActionResult> GetLocalesForSpreadsheetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetLocalesForSpreadsheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("install-lang")]
        public async Task<IActionResult> InstallLangAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InstallLangAsync(ids);
            return Ok(result);
        }
    }
    
}