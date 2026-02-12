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
    [Route("api/v1/base/IrActionsServer")]
    public partial class IrActionsServerController : AbpController
    {
        protected readonly IIrActionsServerAppService _appService;
        public IrActionsServerController(IIrActionsServerAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-automation")]
        public async Task<IActionResult> OpenAutomationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAutomationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-parent-action")]
        public async Task<IActionResult> OpenParentActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenParentActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-scheduled-action")]
        public async Task<IActionResult> OpenScheduledActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenScheduledActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] IrActionsServerCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-action")]
        public async Task<IActionResult> CreateActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("history-wizard-action")]
        public async Task<IActionResult> HistoryWizardActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.HistoryWizardActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run")]
        public async Task<IActionResult> RunAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RunAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-action")]
        public async Task<IActionResult> UnlinkActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnlinkActionAsync(ids);
            return Ok(result);
        }
    }
    
}