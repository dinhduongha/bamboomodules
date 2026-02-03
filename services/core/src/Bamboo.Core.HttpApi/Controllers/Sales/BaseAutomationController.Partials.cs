using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class BaseAutomationController
    {
        
        [HttpPost]
        [Route("action-open-scheduled-action")]
        public async Task<IActionResult> ActionOpenScheduledActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenScheduledActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-rotate-webhook-uuid")]
        public async Task<IActionResult> ActionRotateWebhookUuidAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RotateWebhookUuidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-webhook-logs")]
        public async Task<IActionResult> ActionViewWebhookLogsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewWebhookLogsAsync(ids);
            return Ok(result);
        }
    }
}