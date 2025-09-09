using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Bus
{
    public partial class BusPresenceController
    {
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-presence")]
        public async Task<IActionResult> UpdatePresenceAsync(Guid id, [FromBody] BusPresenceUpdatePresenceRequestDto input)
        {
            var result = await _appService.UpdatePresenceAsync(id, input);
            return Ok(result);
        }
    }
}