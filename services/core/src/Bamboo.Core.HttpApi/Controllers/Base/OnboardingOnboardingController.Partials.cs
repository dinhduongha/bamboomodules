using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class OnboardingOnboardingController
    {
        
        [HttpPost]
        [Route("action-close")]
        public async Task<IActionResult> ActionCloseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-close-panel")]
        public async Task<IActionResult> ActionClosePanelAsync(OnboardingOnboardingClosePanelRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ClosePanelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-close-panel-account-dashboard")]
        public async Task<IActionResult> ActionClosePanelAccountDashboardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ClosePanelAccountDashboardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-close-panel-account-invoice")]
        public async Task<IActionResult> ActionClosePanelAccountInvoiceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ClosePanelAccountInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refresh-progress-ids")]
        public async Task<IActionResult> ActionRefreshProgressIdsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefreshProgressIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-visibility")]
        public async Task<IActionResult> ActionToggleVisibilityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleVisibilityAsync(ids);
            return Ok(result);
        }
    }
}