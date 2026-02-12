using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/bus/BusPresence")]
    public partial class BusPresenceController : AbpController
    {
        protected readonly IBusPresenceAppService _appService;
        public BusPresenceController(IBusPresenceAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-presence")]
        public async Task<IActionResult> UpdatePresenceAsync([FromBody] BusPresenceUpdatePresenceRequestDto input)
        {
            var result = await _appService.UpdatePresenceAsync(input);
            return Ok(result);
        }
    }
    
}