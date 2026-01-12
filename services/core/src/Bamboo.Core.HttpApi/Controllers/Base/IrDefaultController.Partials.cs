using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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