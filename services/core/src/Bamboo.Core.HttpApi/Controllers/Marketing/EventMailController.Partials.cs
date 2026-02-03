using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventMailController
    {
        
        [HttpPost]
        [Route("execute")]
        public async Task<IActionResult> ExecuteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExecuteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run")]
        public async Task<IActionResult> RunAsync(EventMailRunRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RunAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("schedule-communications")]
        public async Task<IActionResult> ScheduleCommunicationsAsync(EventMailScheduleCommunicationsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ScheduleCommunicationsAsync(input);
            return Ok(result);
        }
    }
}