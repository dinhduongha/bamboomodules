using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseAutomationModule
{
    public partial class BaseAutomationController
    {
        
        [HttpPost]
        [Route("{id}/action-rotate-webhook-uuid")]
        public async Task<IActionResult> ActionRotateWebhookUuidAsync(Guid id)
        {
            var result = await _appService.RotateWebhookUuidAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-webhook-logs")]
        public async Task<IActionResult> ActionViewWebhookLogsAsync(Guid id)
        {
            var result = await _appService.ViewWebhookLogsAsync(id);
            return Ok(result);
        }
    }
}