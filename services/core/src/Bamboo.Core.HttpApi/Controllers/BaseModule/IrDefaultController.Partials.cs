using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrDefaultController
    {
        
        [HttpPost]
        [Route("{id}/discard-records")]
        public async Task<IActionResult> DiscardRecordsAsync(Guid id, [FromBody] IrDefaultDiscardRecordsRequestDto input)
        {
            var result = await _appService.DiscardRecordsAsync(id, input.Records);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/discard-values")]
        public async Task<IActionResult> DiscardValuesAsync(Guid id, [FromBody] IrDefaultDiscardValuesRequestDto input)
        {
            var result = await _appService.DiscardValuesAsync(id, input.ModelName, input.FieldName, input.Values);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set")]
        public async Task<IActionResult> SetAsync(Guid id, [FromBody] IrDefaultSetRequestDto input)
        {
            var result = await _appService.SetAsync(id, input.ModelName, input.FieldName, input.Value, input.UserId, input.CompanyId, input.Condition);
            return Ok(result);
        }
    }
}