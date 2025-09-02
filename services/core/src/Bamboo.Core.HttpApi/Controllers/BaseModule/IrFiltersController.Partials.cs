using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrFiltersController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] IrFiltersCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-or-replace")]
        public async Task<IActionResult> CreateOrReplaceAsync(Guid id, [FromBody] IrFiltersCreateOrReplaceRequestDto input)
        {
            var result = await _appService.CreateOrReplaceAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-filters")]
        public async Task<IActionResult> GetFiltersAsync(Guid id, [FromBody] IrFiltersGetFiltersRequestDto input)
        {
            var result = await _appService.GetFiltersAsync(id, input);
            return Ok(result);
        }
    }
}