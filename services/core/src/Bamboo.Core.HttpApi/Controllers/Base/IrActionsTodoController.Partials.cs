using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrActionsTodoController
    {
        
        [HttpPost]
        [Route("{id}/action-launch")]
        public async Task<IActionResult> ActionLaunchAsync(Guid id)
        {
            var result = await _appService.LaunchAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open")]
        public async Task<IActionResult> ActionOpenAsync(Guid id)
        {
            var result = await _appService.OpenAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/ensure-one-open-todo")]
        public async Task<IActionResult> EnsureOneOpenTodoAsync(Guid id)
        {
            var result = await _appService.EnsureOneOpenTodoAsync(id);
            return Ok(result);
        }
    }
}