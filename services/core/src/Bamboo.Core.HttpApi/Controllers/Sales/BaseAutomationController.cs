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
    [Route("api/v1/sales/BaseAutomation")]
    public partial class BaseAutomationController : AbpController
    {
        protected readonly IBaseAutomationAppService _appService;
        public BaseAutomationController(IBaseAutomationAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-scheduled-action")]
        public async Task<IActionResult> OpenScheduledActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenScheduledActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-rotate-webhook-uuid")]
        public async Task<IActionResult> RotateWebhookUuidAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RotateWebhookUuidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-webhook-logs")]
        public async Task<IActionResult> ViewWebhookLogsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewWebhookLogsAsync(ids);
            return Ok(result);
        }
    }
    
}