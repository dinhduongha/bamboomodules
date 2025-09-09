using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrDefaultController
    {
        
        [HttpPost]
        [Route("{id}/discard-records")]
        public async Task<IActionResult> DiscardRecordsAsync(Guid id, [FromBody] IrDefaultDiscardRecordsRequestDto input)
        {
            var result = await _appService.DiscardRecordsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/discard-values")]
        public async Task<IActionResult> DiscardValuesAsync(Guid id, [FromBody] IrDefaultDiscardValuesRequestDto input)
        {
            var result = await _appService.DiscardValuesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set")]
        public async Task<IActionResult> SetAsync(Guid id, [FromBody] IrDefaultSetRequestDto input)
        {
            var result = await _appService.SetAsync(id, input);
            return Ok(result);
        }
    }
}