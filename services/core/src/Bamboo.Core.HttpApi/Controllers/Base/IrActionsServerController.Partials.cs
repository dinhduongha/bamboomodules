using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrActionsServerController
    {
        
        [HttpPost]
        [Route("action-open-automation")]
        public async Task<IActionResult> ActionOpenAutomationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAutomationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-parent-action")]
        public async Task<IActionResult> ActionOpenParentActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenParentActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-scheduled-action")]
        public async Task<IActionResult> ActionOpenScheduledActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenScheduledActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(IrActionsServerCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-action")]
        public async Task<IActionResult> CreateActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("history-wizard-action")]
        public async Task<IActionResult> HistoryWizardActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.HistoryWizardActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run")]
        public async Task<IActionResult> RunAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RunAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-action")]
        public async Task<IActionResult> UnlinkActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnlinkActionAsync(ids);
            return Ok(result);
        }
    }
}