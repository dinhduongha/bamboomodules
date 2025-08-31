using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    public partial class EventMailController
    {
        
        [HttpPost]
        [Route("{id}/execute")]
        public async Task<IActionResult> ExecuteAsync(Guid id)
        {
            var result = await _appService.ExecuteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/run")]
        public async Task<IActionResult> RunAsync(Guid id, [FromBody] EventMailRunRequestDto input)
        {
            var result = await _appService.RunAsync(id, input.Autocommit);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/schedule-communications")]
        public async Task<IActionResult> ScheduleCommunicationsAsync(Guid id, [FromBody] EventMailScheduleCommunicationsRequestDto input)
        {
            var result = await _appService.ScheduleCommunicationsAsync(id, input.Autocommit);
            return Ok(result);
        }
    }
}