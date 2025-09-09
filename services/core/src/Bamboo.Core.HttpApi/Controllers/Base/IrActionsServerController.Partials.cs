using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrActionsServerController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] IrActionsServerCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-action")]
        public async Task<IActionResult> CreateActionAsync(Guid id)
        {
            var result = await _appService.CreateActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/run")]
        public async Task<IActionResult> RunAsync(Guid id)
        {
            var result = await _appService.RunAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unlink-action")]
        public async Task<IActionResult> UnlinkActionAsync(Guid id)
        {
            var result = await _appService.UnlinkActionAsync(id);
            return Ok(result);
        }
    }
}