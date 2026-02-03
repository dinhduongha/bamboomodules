using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrModuleModuleController
    {
        
        [HttpPost]
        [Route("action-open-install-request")]
        public async Task<IActionResult> ActionOpenInstallRequestAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenInstallRequestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-delivery-methods")]
        public async Task<IActionResult> ActionViewDeliveryMethodsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewDeliveryMethodsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-choose-theme")]
        public async Task<IActionResult> ButtonChooseThemeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonChooseThemeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-immediate-install")]
        public async Task<IActionResult> ButtonImmediateInstallAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonImmediateInstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-immediate-install-app")]
        public async Task<IActionResult> ButtonImmediateInstallAppAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonImmediateInstallAppAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-immediate-uninstall")]
        public async Task<IActionResult> ButtonImmediateUninstallAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonImmediateUninstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-immediate-upgrade")]
        public async Task<IActionResult> ButtonImmediateUpgradeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonImmediateUpgradeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-install")]
        public async Task<IActionResult> ButtonInstallAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonInstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-refresh-theme")]
        public async Task<IActionResult> ButtonRefreshThemeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonRefreshThemeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-remove-theme")]
        public async Task<IActionResult> ButtonRemoveThemeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonRemoveThemeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-reset-state")]
        public async Task<IActionResult> ButtonResetStateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonResetStateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-uninstall")]
        public async Task<IActionResult> ButtonUninstallAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonUninstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-uninstall-wizard")]
        public async Task<IActionResult> ButtonUninstallWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonUninstallWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-upgrade")]
        public async Task<IActionResult> ButtonUpgradeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonUpgradeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-external-dependencies")]
        public async Task<IActionResult> CheckExternalDependenciesAsync(IrModuleModuleCheckExternalDependenciesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckExternalDependenciesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-module-update")]
        public async Task<IActionResult> CheckModuleUpdateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckModuleUpdateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("downstream-dependencies")]
        public async Task<IActionResult> DownstreamDependenciesAsync(IrModuleModuleDownstreamDependenciesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DownstreamDependenciesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-module-info")]
        public async Task<IActionResult> GetModuleInfoAsync(IrModuleModuleGetModuleInfoRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetModuleInfoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-themes-domain")]
        public async Task<IActionResult> GetThemesDomainAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetThemesDomainAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-values-from-terp")]
        public async Task<IActionResult> GetValuesFromTerpAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetValuesFromTerpAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("module-uninstall")]
        public async Task<IActionResult> ModuleUninstallAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ModuleUninstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("more-info")]
        public async Task<IActionResult> MoreInfoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MoreInfoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("next")]
        public async Task<IActionResult> NextAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.NextAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-panel-select-range")]
        public async Task<IActionResult> SearchPanelSelectRangeAsync(IrModuleModuleSearchPanelSelectRangeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SearchPanelSelectRangeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-list")]
        public async Task<IActionResult> UpdateListAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-theme-images")]
        public async Task<IActionResult> UpdateThemeImagesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateThemeImagesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("upstream-dependencies")]
        public async Task<IActionResult> UpstreamDependenciesAsync(IrModuleModuleUpstreamDependenciesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UpstreamDependenciesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-read")]
        public async Task<IActionResult> WebReadAsync(IrModuleModuleWebReadRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.WebReadAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-search-read")]
        public async Task<IActionResult> WebSearchReadAsync(IrModuleModuleWebSearchReadRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.WebSearchReadAsync(input);
            return Ok(result);
        }
    }
}