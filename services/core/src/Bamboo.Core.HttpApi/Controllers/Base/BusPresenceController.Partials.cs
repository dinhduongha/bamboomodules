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
        [Route("init")]
        public async Task<IActionResult> InitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-presence")]
        public async Task<IActionResult> UpdatePresenceAsync(BusPresenceUpdatePresenceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UpdatePresenceAsync(input);
            return Ok(result);
        }
    }
}