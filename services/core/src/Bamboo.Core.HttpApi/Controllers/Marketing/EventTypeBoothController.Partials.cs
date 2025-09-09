using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothModule
{
    public partial class EventTypeBoothController
    {
        
        [HttpPost]
        [Route("{id}/action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid id, [FromBody] EventTypeBoothConfirmRequestDto input)
        {
            var result = await _appService.ConfirmAsync(id, input);
            return Ok(result);
        }
    }
}