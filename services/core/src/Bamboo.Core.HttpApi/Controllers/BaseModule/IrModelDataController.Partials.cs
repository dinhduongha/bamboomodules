using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrModelDataController
    {
        
        [HttpPost]
        [Route("{id}/check-object-reference")]
        public async Task<IActionResult> CheckObjectReferenceAsync(Guid id, [FromBody] IrModelDataCheckObjectReferenceRequestDto input)
        {
            var result = await _appService.CheckObjectReferenceAsync(id, input.Module, input.XmlId, input.RaiseOnAccessError);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] IrModelDataCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-noupdate")]
        public async Task<IActionResult> ToggleNoupdateAsync(Guid id, [FromBody] IrModelDataToggleNoupdateRequestDto input)
        {
            var result = await _appService.ToggleNoupdateAsync(id, input.Model, input.ResId);
            return Ok(result);
        }
    }
}