using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrModelDataController
    {
        
        [HttpPost]
        [Route("{id}/check-object-reference")]
        public async Task<IActionResult> CheckObjectReferenceAsync(Guid id, [FromBody] IrModelDataCheckObjectReferenceRequestDto input)
        {
            var result = await _appService.CheckObjectReferenceAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] IrModelDataCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-noupdate")]
        public async Task<IActionResult> ToggleNoupdateAsync(Guid id, [FromBody] IrModelDataToggleNoupdateRequestDto input)
        {
            var result = await _appService.ToggleNoupdateAsync(id, input);
            return Ok(result);
        }
    }
}