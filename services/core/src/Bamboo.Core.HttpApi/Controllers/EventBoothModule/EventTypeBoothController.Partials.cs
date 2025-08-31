using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothModule
{
    public partial class EventTypeBoothController
    {
        
        [HttpPost]
        [Route("{id}/action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid id, [FromBody] EventTypeBoothConfirmRequestDto input)
        {
            var result = await _appService.ConfirmAsync(id, input.AdditionalValues);
            return Ok(result);
        }
    }
}