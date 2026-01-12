using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResLangController
    {
        
        [HttpPost]
        [Route("{id}/action-activate-langs")]
        public async Task<IActionResult> ActionActivateLangsAsync(Guid id)
        {
            var result = await _appService.ActivateLangsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/c-a-c-h-e-d-f-i-e-l-d-s")]
        public async Task<IActionResult> CACHEDFIELDSAsync(Guid id)
        {
            var result = await _appService.CACHEDFIELDSAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ResLangCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format")]
        public async Task<IActionResult> FormatAsync(Guid id, [FromBody] ResLangFormatRequestDto input)
        {
            var result = await _appService.FormatAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-installed")]
        public async Task<IActionResult> GetInstalledAsync(Guid id)
        {
            var result = await _appService.GetInstalledAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-locales-for-spreadsheet")]
        public async Task<IActionResult> GetLocalesForSpreadsheetAsync(Guid id)
        {
            var result = await _appService.GetLocalesForSpreadsheetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/install-lang")]
        public async Task<IActionResult> InstallLangAsync(Guid id)
        {
            var result = await _appService.InstallLangAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
    }
}