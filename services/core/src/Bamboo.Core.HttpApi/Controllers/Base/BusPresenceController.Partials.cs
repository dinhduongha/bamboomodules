using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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