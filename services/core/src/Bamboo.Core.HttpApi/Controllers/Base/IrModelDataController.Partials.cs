using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrModelDataController
    {
        
        [HttpPost]
        [Route("check-object-reference")]
        public async Task<IActionResult> CheckObjectReferenceAsync(IrModelDataCheckObjectReferenceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckObjectReferenceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(IrModelDataCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-noupdate")]
        public async Task<IActionResult> ToggleNoupdateAsync(IrModelDataToggleNoupdateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToggleNoupdateAsync(input);
            return Ok(result);
        }
    }
}