using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class WebTourTourController
    {
        
        [HttpPost]
        [Route("{id}/consume")]
        public async Task<IActionResult> ConsumeAsync(Guid id, [FromBody] WebTourTourConsumeRequestDto input)
        {
            var result = await _appService.ConsumeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/export-js-file")]
        public async Task<IActionResult> ExportJsFileAsync(Guid id)
        {
            var result = await _appService.ExportJsFileAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-current-tour")]
        public async Task<IActionResult> GetCurrentTourAsync(Guid id)
        {
            var result = await _appService.GetCurrentTourAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-tour-json-by-name")]
        public async Task<IActionResult> GetTourJsonByNameAsync(Guid id, [FromBody] WebTourTourGetTourJsonByNameRequestDto input)
        {
            var result = await _appService.GetTourJsonByNameAsync(id, input);
            return Ok(result);
        }
    }
}