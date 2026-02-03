using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class WebTourTourController
    {
        
        [HttpPost]
        [Route("consume")]
        public async Task<IActionResult> ConsumeAsync(WebTourTourConsumeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConsumeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("export-js-file")]
        public async Task<IActionResult> ExportJsFileAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExportJsFileAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-current-tour")]
        public async Task<IActionResult> GetCurrentTourAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetCurrentTourAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-tour-json-by-name")]
        public async Task<IActionResult> GetTourJsonByNameAsync(WebTourTourGetTourJsonByNameRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetTourJsonByNameAsync(input);
            return Ok(result);
        }
    }
}