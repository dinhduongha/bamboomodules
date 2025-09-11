using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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