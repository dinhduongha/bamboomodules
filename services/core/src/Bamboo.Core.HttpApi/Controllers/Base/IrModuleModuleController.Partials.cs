using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrModuleModuleController
    {
        
        [HttpPost]
        [Route("{id}/action-open-install-request")]
        public async Task<IActionResult> ActionOpenInstallRequestAsync(Guid id)
        {
            var result = await _appService.OpenInstallRequestAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-choose-theme")]
        public async Task<IActionResult> ButtonChooseThemeAsync(Guid id)
        {
            var result = await _appService.ButtonChooseThemeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-immediate-install")]
        public async Task<IActionResult> ButtonImmediateInstallAsync(Guid id)
        {
            var result = await _appService.ButtonImmediateInstallAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-immediate-install-app")]
        public async Task<IActionResult> ButtonImmediateInstallAppAsync(Guid id)
        {
            var result = await _appService.ButtonImmediateInstallAppAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-immediate-uninstall")]
        public async Task<IActionResult> ButtonImmediateUninstallAsync(Guid id)
        {
            var result = await _appService.ButtonImmediateUninstallAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-immediate-upgrade")]
        public async Task<IActionResult> ButtonImmediateUpgradeAsync(Guid id)
        {
            var result = await _appService.ButtonImmediateUpgradeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-install")]
        public async Task<IActionResult> ButtonInstallAsync(Guid id)
        {
            var result = await _appService.ButtonInstallAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-install-cancel")]
        public async Task<IActionResult> ButtonInstallCancelAsync(Guid id)
        {
            var result = await _appService.ButtonInstallCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-refresh-theme")]
        public async Task<IActionResult> ButtonRefreshThemeAsync(Guid id)
        {
            var result = await _appService.ButtonRefreshThemeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-remove-theme")]
        public async Task<IActionResult> ButtonRemoveThemeAsync(Guid id)
        {
            var result = await _appService.ButtonRemoveThemeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-uninstall")]
        public async Task<IActionResult> ButtonUninstallAsync(Guid id)
        {
            var result = await _appService.ButtonUninstallAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-uninstall-cancel")]
        public async Task<IActionResult> ButtonUninstallCancelAsync(Guid id)
        {
            var result = await _appService.ButtonUninstallCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-uninstall-wizard")]
        public async Task<IActionResult> ButtonUninstallWizardAsync(Guid id)
        {
            var result = await _appService.ButtonUninstallWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-upgrade")]
        public async Task<IActionResult> ButtonUpgradeAsync(Guid id)
        {
            var result = await _appService.ButtonUpgradeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-upgrade-cancel")]
        public async Task<IActionResult> ButtonUpgradeCancelAsync(Guid id)
        {
            var result = await _appService.ButtonUpgradeCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-external-dependencies")]
        public async Task<IActionResult> CheckExternalDependenciesAsync(Guid id, [FromBody] IrModuleModuleCheckExternalDependenciesRequestDto input)
        {
            var result = await _appService.CheckExternalDependenciesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/downstream-dependencies")]
        public async Task<IActionResult> DownstreamDependenciesAsync(Guid id, [FromBody] IrModuleModuleDownstreamDependenciesRequestDto input)
        {
            var result = await _appService.DownstreamDependenciesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-module-info")]
        public async Task<IActionResult> GetModuleInfoAsync(Guid id, [FromBody] IrModuleModuleGetModuleInfoRequestDto input)
        {
            var result = await _appService.GetModuleInfoAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-themes-domain")]
        public async Task<IActionResult> GetThemesDomainAsync(Guid id)
        {
            var result = await _appService.GetThemesDomainAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-values-from-terp")]
        public async Task<IActionResult> GetValuesFromTerpAsync(Guid id)
        {
            var result = await _appService.GetValuesFromTerpAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/module-uninstall")]
        public async Task<IActionResult> ModuleUninstallAsync(Guid id)
        {
            var result = await _appService.ModuleUninstallAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/more-info")]
        public async Task<IActionResult> MoreInfoAsync(Guid id)
        {
            var result = await _appService.MoreInfoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/next")]
        public async Task<IActionResult> NextAsync(Guid id)
        {
            var result = await _appService.NextAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-panel-select-range")]
        public async Task<IActionResult> SearchPanelSelectRangeAsync(Guid id, [FromBody] IrModuleModuleSearchPanelSelectRangeRequestDto input)
        {
            var result = await _appService.SearchPanelSelectRangeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-list")]
        public async Task<IActionResult> UpdateListAsync(Guid id)
        {
            var result = await _appService.UpdateListAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-theme-images")]
        public async Task<IActionResult> UpdateThemeImagesAsync(Guid id)
        {
            var result = await _appService.UpdateThemeImagesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/upstream-dependencies")]
        public async Task<IActionResult> UpstreamDependenciesAsync(Guid id, [FromBody] IrModuleModuleUpstreamDependenciesRequestDto input)
        {
            var result = await _appService.UpstreamDependenciesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/web-read")]
        public async Task<IActionResult> WebReadAsync(Guid id, [FromBody] IrModuleModuleWebReadRequestDto input)
        {
            var result = await _appService.WebReadAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/web-search-read")]
        public async Task<IActionResult> WebSearchReadAsync(Guid id, [FromBody] IrModuleModuleWebSearchReadRequestDto input)
        {
            var result = await _appService.WebSearchReadAsync(id, input);
            return Ok(result);
        }
    }
}