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
    [Route("api/v1/base/IrModuleModule")]
    public partial class IrModuleModuleController : AbpController
    {
        protected readonly IIrModuleModuleAppService _appService;
        public IrModuleModuleController(IIrModuleModuleAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-install-request")]
        public async Task<IActionResult> OpenInstallRequestAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenInstallRequestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-delivery-methods")]
        public async Task<IActionResult> ViewDeliveryMethodsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewDeliveryMethodsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-choose-theme")]
        public async Task<IActionResult> ButtonChooseThemeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonChooseThemeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-immediate-install")]
        public async Task<IActionResult> ButtonImmediateInstallAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonImmediateInstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-immediate-install-app")]
        public async Task<IActionResult> ButtonImmediateInstallAppAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonImmediateInstallAppAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-immediate-uninstall")]
        public async Task<IActionResult> ButtonImmediateUninstallAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonImmediateUninstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-immediate-upgrade")]
        public async Task<IActionResult> ButtonImmediateUpgradeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonImmediateUpgradeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-install")]
        public async Task<IActionResult> ButtonInstallAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonInstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-refresh-theme")]
        public async Task<IActionResult> ButtonRefreshThemeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonRefreshThemeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-remove-theme")]
        public async Task<IActionResult> ButtonRemoveThemeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonRemoveThemeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-reset-state")]
        public async Task<IActionResult> ButtonResetStateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonResetStateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-uninstall")]
        public async Task<IActionResult> ButtonUninstallAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonUninstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-uninstall-wizard")]
        public async Task<IActionResult> ButtonUninstallWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonUninstallWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-upgrade")]
        public async Task<IActionResult> ButtonUpgradeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonUpgradeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-external-dependencies")]
        public async Task<IActionResult> CheckExternalDependenciesAsync([FromBody] IrModuleModuleCheckExternalDependenciesRequestDto input)
        {
            var result = await _appService.CheckExternalDependenciesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-module-update")]
        public async Task<IActionResult> CheckModuleUpdateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckModuleUpdateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("downstream-dependencies")]
        public async Task<IActionResult> DownstreamDependenciesAsync([FromBody] IrModuleModuleDownstreamDependenciesRequestDto input)
        {
            var result = await _appService.DownstreamDependenciesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-module-info")]
        public async Task<IActionResult> GetModuleInfoAsync([FromBody] IrModuleModuleGetModuleInfoRequestDto input)
        {
            var result = await _appService.GetModuleInfoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-themes-domain")]
        public async Task<IActionResult> GetThemesDomainAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetThemesDomainAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-values-from-terp")]
        public async Task<IActionResult> GetValuesFromTerpAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetValuesFromTerpAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("module-uninstall")]
        public async Task<IActionResult> ModuleUninstallAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ModuleUninstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("more-info")]
        public async Task<IActionResult> MoreInfoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MoreInfoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("next")]
        public async Task<IActionResult> NextAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.NextAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-panel-select-range")]
        public async Task<IActionResult> SearchPanelSelectRangeAsync([FromBody] IrModuleModuleSearchPanelSelectRangeRequestDto input)
        {
            var result = await _appService.SearchPanelSelectRangeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-list")]
        public async Task<IActionResult> UpdateListAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-theme-images")]
        public async Task<IActionResult> UpdateThemeImagesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateThemeImagesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("upstream-dependencies")]
        public async Task<IActionResult> UpstreamDependenciesAsync([FromBody] IrModuleModuleUpstreamDependenciesRequestDto input)
        {
            var result = await _appService.UpstreamDependenciesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-read")]
        public async Task<IActionResult> WebReadAsync([FromBody] IrModuleModuleWebReadRequestDto input)
        {
            var result = await _appService.WebReadAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-search-read")]
        public async Task<IActionResult> WebSearchReadAsync([FromBody] IrModuleModuleWebSearchReadRequestDto input)
        {
            var result = await _appService.WebSearchReadAsync(input);
            return Ok(result);
        }
    }
    
}