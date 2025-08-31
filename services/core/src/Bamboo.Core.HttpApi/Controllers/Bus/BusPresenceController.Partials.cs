using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
            var result = await _appService.UpdatePresenceAsync(id, input.InactivityPeriod, input.IdentityField, input.IdentityValue);
            return Ok(result);
        }
    }
}