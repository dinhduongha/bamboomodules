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
    [Route("api/v1/onboarding/OnboardingOnboarding")]
    public partial class OnboardingOnboardingController : AbpController
    {
        protected readonly IOnboardingOnboardingAppService _appService;
        public OnboardingOnboardingController(IOnboardingOnboardingAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-close")]
        public async Task<IActionResult> CloseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-close-panel")]
        public async Task<IActionResult> ClosePanelAsync([FromBody] OnboardingOnboardingClosePanelRequestDto input)
        {
            var result = await _appService.ClosePanelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-close-panel-account-dashboard")]
        public async Task<IActionResult> ClosePanelAccountDashboardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ClosePanelAccountDashboardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-close-panel-account-invoice")]
        public async Task<IActionResult> ClosePanelAccountInvoiceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ClosePanelAccountInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refresh-progress-ids")]
        public async Task<IActionResult> RefreshProgressIdsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefreshProgressIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-visibility")]
        public async Task<IActionResult> ToggleVisibilityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleVisibilityAsync(ids);
            return Ok(result);
        }
    }
    
}