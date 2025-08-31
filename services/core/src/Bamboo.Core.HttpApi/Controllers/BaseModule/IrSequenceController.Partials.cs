using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrSequenceController
    {
        
        [HttpPost]
        [Route("{id}/get")]
        public async Task<IActionResult> GetAsync(Guid id, [FromBody] IrSequenceGetRequestDto input)
        {
            var result = await _appService.GetAsync(id, input.Code);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-id")]
        public async Task<IActionResult> GetIdAsync(Guid id, [FromBody] IrSequenceGetIdRequestDto input)
        {
            var result = await _appService.GetIdAsync(id, input.SequenceCodeOrId, input.CodeOrId);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-next-char")]
        public async Task<IActionResult> GetNextCharAsync(Guid id, [FromBody] IrSequenceGetNextCharRequestDto input)
        {
            var result = await _appService.GetNextCharAsync(id, input.NumberNext);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/next-by-code")]
        public async Task<IActionResult> NextByCodeAsync(Guid id, [FromBody] IrSequenceNextByCodeRequestDto input)
        {
            var result = await _appService.NextByCodeAsync(id, input.SequenceCode, input.SequenceDate);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/next-by-id")]
        public async Task<IActionResult> NextByIdAsync(Guid id, [FromBody] IrSequenceNextByIdRequestDto input)
        {
            var result = await _appService.NextByIdAsync(id, input.SequenceDate);
            return Ok(result);
        }
    }
}