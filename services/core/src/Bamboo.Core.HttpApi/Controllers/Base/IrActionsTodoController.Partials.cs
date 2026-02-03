using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrActionsTodoController
    {
        
        [HttpPost]
        [Route("action-launch")]
        public async Task<IActionResult> ActionLaunchAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LaunchAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open")]
        public async Task<IActionResult> ActionOpenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("ensure-one-open-todo")]
        public async Task<IActionResult> EnsureOneOpenTodoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.EnsureOneOpenTodoAsync(ids);
            return Ok(result);
        }
    }
}