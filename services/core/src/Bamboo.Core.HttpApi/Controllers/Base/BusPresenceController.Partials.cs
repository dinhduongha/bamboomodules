using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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