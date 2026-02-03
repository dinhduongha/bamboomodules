using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PosConfigController
    {
        
        [HttpPost]
        [Route("action-close-kiosk-session")]
        public async Task<IActionResult> ActionCloseKioskSessionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CloseKioskSessionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-wizard")]
        public async Task<IActionResult> ActionOpenWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-config-modal-edit")]
        public async Task<IActionResult> ActionPosConfigModalEditAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PosConfigModalEditAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("close-ui")]
        public async Task<IActionResult> CloseUiAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CloseUiAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute")]
        public async Task<IActionResult> ExecuteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExecuteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-kiosk-url")]
        public async Task<IActionResult> GetKioskUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetKioskUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-limited-partners-loading")]
        public async Task<IActionResult> GetLimitedPartnersLoadingAsync(PosConfigGetLimitedPartnersLoadingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetLimitedPartnersLoadingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-limited-product-count")]
        public async Task<IActionResult> GetLimitedProductCountAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetLimitedProductCountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-pos-kanban-view-state")]
        public async Task<IActionResult> GetPosKanbanViewStateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPosKanbanViewStateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-pos-qr-order-data")]
        public async Task<IActionResult> GetPosQrOrderDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPosQrOrderDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-record-by-ref")]
        public async Task<IActionResult> GetRecordByRefAsync(PosConfigGetRecordByRefRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetRecordByRefAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-statistics-for-session")]
        public async Task<IActionResult> GetStatisticsForSessionAsync(PosConfigGetStatisticsForSessionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetStatisticsForSessionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-valid-self-payment-method")]
        public async Task<IActionResult> HasValidSelfPaymentMethodAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.HasValidSelfPaymentMethodAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("install-pos-restaurant")]
        public async Task<IActionResult> InstallPosRestaurantAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InstallPosRestaurantAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-data-params")]
        public async Task<IActionResult> LoadDataParamsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LoadDataParamsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-demo-data")]
        public async Task<IActionResult> LoadDemoDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LoadDemoDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-onboarding-bakery-scenario")]
        public async Task<IActionResult> LoadOnboardingBakeryScenarioAsync(PosConfigLoadOnboardingBakeryScenarioRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadOnboardingBakeryScenarioAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-onboarding-bar-scenario")]
        public async Task<IActionResult> LoadOnboardingBarScenarioAsync(PosConfigLoadOnboardingBarScenarioRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadOnboardingBarScenarioAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-onboarding-clothes-scenario")]
        public async Task<IActionResult> LoadOnboardingClothesScenarioAsync(PosConfigLoadOnboardingClothesScenarioRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadOnboardingClothesScenarioAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-onboarding-furniture-scenario")]
        public async Task<IActionResult> LoadOnboardingFurnitureScenarioAsync(PosConfigLoadOnboardingFurnitureScenarioRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadOnboardingFurnitureScenarioAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-onboarding-kiosk-scenario")]
        public async Task<IActionResult> LoadOnboardingKioskScenarioAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LoadOnboardingKioskScenarioAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-onboarding-restaurant-scenario")]
        public async Task<IActionResult> LoadOnboardingRestaurantScenarioAsync(PosConfigLoadOnboardingRestaurantScenarioRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadOnboardingRestaurantScenarioAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-onboarding-retail-scenario")]
        public async Task<IActionResult> LoadOnboardingRetailScenarioAsync(PosConfigLoadOnboardingRetailScenarioRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadOnboardingRetailScenarioAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-self-data")]
        public async Task<IActionResult> LoadSelfDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LoadSelfDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("notify-synchronisation")]
        public async Task<IActionResult> NotifySynchronisationAsync(PosConfigNotifySynchronisationRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.NotifySynchronisationAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-existing-session-cb")]
        public async Task<IActionResult> OpenExistingSessionCbAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenExistingSessionCbAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-opened-rescue-session-form")]
        public async Task<IActionResult> OpenOpenedRescueSessionFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenOpenedRescueSessionFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-ui")]
        public async Task<IActionResult> OpenUiAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenUiAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("preview-self-order-app")]
        public async Task<IActionResult> PreviewSelfOrderAppAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PreviewSelfOrderAppAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("read-config-open-orders")]
        public async Task<IActionResult> ReadConfigOpenOrdersAsync(PosConfigReadConfigOpenOrdersRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ReadConfigOpenOrdersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("register-new-device-identifier")]
        public async Task<IActionResult> RegisterNewDeviceIdentifierAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RegisterNewDeviceIdentifierAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-customer-display")]
        public async Task<IActionResult> UpdateCustomerDisplayAsync(PosConfigUpdateCustomerDisplayRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UpdateCustomerDisplayAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("use-coupon-code")]
        public async Task<IActionResult> UseCouponCodeAsync(PosConfigUseCouponCodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UseCouponCodeAsync(input);
            return Ok(result);
        }
    }
}