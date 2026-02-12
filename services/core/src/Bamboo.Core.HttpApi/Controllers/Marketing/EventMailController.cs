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
    [Route("api/v1/marketing/EventMail")]
    public partial class EventMailController : AbpController
    {
        protected readonly IEventMailAppService _appService;
        public EventMailController(IEventMailAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("execute")]
        public async Task<IActionResult> ExecuteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExecuteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run")]
        public async Task<IActionResult> RunAsync([FromBody] EventMailRunRequestDto input)
        {
            var result = await _appService.RunAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("schedule-communications")]
        public async Task<IActionResult> ScheduleCommunicationsAsync([FromBody] EventMailScheduleCommunicationsRequestDto input)
        {
            var result = await _appService.ScheduleCommunicationsAsync(input);
            return Ok(result);
        }
    }
    
}