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
        [Route("action-activate-langs")]
        public async Task<IActionResult> ActionActivateLangsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ActivateLangsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("c-a-c-h-e-d-f-i-e-l-d-s")]
        public async Task<IActionResult> CACHEDFIELDSAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CACHEDFIELDSAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(ResLangCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format")]
        public async Task<IActionResult> FormatAsync(ResLangFormatRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormatAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-installed")]
        public async Task<IActionResult> GetInstalledAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetInstalledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-locales-for-spreadsheet")]
        public async Task<IActionResult> GetLocalesForSpreadsheetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetLocalesForSpreadsheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("install-lang")]
        public async Task<IActionResult> InstallLangAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InstallLangAsync(ids);
            return Ok(result);
        }
    }
}