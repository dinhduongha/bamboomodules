using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class OnboardingOnboardingController
    {
        
        [HttpPost]
        [Route("{id}/action-close")]
        public async Task<IActionResult> ActionCloseAsync(Guid id)
        {
            var result = await _appService.CloseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-close-panel")]
        public async Task<IActionResult> ActionClosePanelAsync(Guid id, [FromBody] OnboardingOnboardingClosePanelRequestDto input)
        {
            var result = await _appService.ClosePanelAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-close-panel-account-dashboard")]
        public async Task<IActionResult> ActionClosePanelAccountDashboardAsync(Guid id)
        {
            var result = await _appService.ClosePanelAccountDashboardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-close-panel-account-invoice")]
        public async Task<IActionResult> ActionClosePanelAccountInvoiceAsync(Guid id)
        {
            var result = await _appService.ClosePanelAccountInvoiceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-refresh-progress-ids")]
        public async Task<IActionResult> ActionRefreshProgressIdsAsync(Guid id)
        {
            var result = await _appService.RefreshProgressIdsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-toggle-visibility")]
        public async Task<IActionResult> ActionToggleVisibilityAsync(Guid id)
        {
            var result = await _appService.ToggleVisibilityAsync(id);
            return Ok(result);
        }
    }
}