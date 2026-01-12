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
        [Route("{id}/action-close-kiosk-session")]
        public async Task<IActionResult> ActionCloseKioskSessionAsync(Guid id)
        {
            var result = await _appService.CloseKioskSessionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-wizard")]
        public async Task<IActionResult> ActionOpenWizardAsync(Guid id)
        {
            var result = await _appService.OpenWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-pos-config-modal-edit")]
        public async Task<IActionResult> ActionPosConfigModalEditAsync(Guid id)
        {
            var result = await _appService.PosConfigModalEditAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/close-ui")]
        public async Task<IActionResult> CloseUiAsync(Guid id)
        {
            var result = await _appService.CloseUiAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/execute")]
        public async Task<IActionResult> ExecuteAsync(Guid id)
        {
            var result = await _appService.ExecuteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-kiosk-url")]
        public async Task<IActionResult> GetKioskUrlAsync(Guid id)
        {
            var result = await _appService.GetKioskUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-limited-partners-loading")]
        public async Task<IActionResult> GetLimitedPartnersLoadingAsync(Guid id, [FromBody] PosConfigGetLimitedPartnersLoadingRequestDto input)
        {
            var result = await _appService.GetLimitedPartnersLoadingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-limited-product-count")]
        public async Task<IActionResult> GetLimitedProductCountAsync(Guid id)
        {
            var result = await _appService.GetLimitedProductCountAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-pos-kanban-view-state")]
        public async Task<IActionResult> GetPosKanbanViewStateAsync(Guid id)
        {
            var result = await _appService.GetPosKanbanViewStateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-pos-qr-order-data")]
        public async Task<IActionResult> GetPosQrOrderDataAsync(Guid id)
        {
            var result = await _appService.GetPosQrOrderDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-record-by-ref")]
        public async Task<IActionResult> GetRecordByRefAsync(Guid id, [FromBody] PosConfigGetRecordByRefRequestDto input)
        {
            var result = await _appService.GetRecordByRefAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-statistics-for-session")]
        public async Task<IActionResult> GetStatisticsForSessionAsync(Guid id, [FromBody] PosConfigGetStatisticsForSessionRequestDto input)
        {
            var result = await _appService.GetStatisticsForSessionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-valid-self-payment-method")]
        public async Task<IActionResult> HasValidSelfPaymentMethodAsync(Guid id)
        {
            var result = await _appService.HasValidSelfPaymentMethodAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/install-pos-restaurant")]
        public async Task<IActionResult> InstallPosRestaurantAsync(Guid id)
        {
            var result = await _appService.InstallPosRestaurantAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-data-params")]
        public async Task<IActionResult> LoadDataParamsAsync(Guid id)
        {
            var result = await _appService.LoadDataParamsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-demo-data")]
        public async Task<IActionResult> LoadDemoDataAsync(Guid id)
        {
            var result = await _appService.LoadDemoDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-bakery-scenario")]
        public async Task<IActionResult> LoadOnboardingBakeryScenarioAsync(Guid id, [FromBody] PosConfigLoadOnboardingBakeryScenarioRequestDto input)
        {
            var result = await _appService.LoadOnboardingBakeryScenarioAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-bar-scenario")]
        public async Task<IActionResult> LoadOnboardingBarScenarioAsync(Guid id, [FromBody] PosConfigLoadOnboardingBarScenarioRequestDto input)
        {
            var result = await _appService.LoadOnboardingBarScenarioAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-clothes-scenario")]
        public async Task<IActionResult> LoadOnboardingClothesScenarioAsync(Guid id, [FromBody] PosConfigLoadOnboardingClothesScenarioRequestDto input)
        {
            var result = await _appService.LoadOnboardingClothesScenarioAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-furniture-scenario")]
        public async Task<IActionResult> LoadOnboardingFurnitureScenarioAsync(Guid id, [FromBody] PosConfigLoadOnboardingFurnitureScenarioRequestDto input)
        {
            var result = await _appService.LoadOnboardingFurnitureScenarioAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-kiosk-scenario")]
        public async Task<IActionResult> LoadOnboardingKioskScenarioAsync(Guid id)
        {
            var result = await _appService.LoadOnboardingKioskScenarioAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-restaurant-scenario")]
        public async Task<IActionResult> LoadOnboardingRestaurantScenarioAsync(Guid id, [FromBody] PosConfigLoadOnboardingRestaurantScenarioRequestDto input)
        {
            var result = await _appService.LoadOnboardingRestaurantScenarioAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-retail-scenario")]
        public async Task<IActionResult> LoadOnboardingRetailScenarioAsync(Guid id, [FromBody] PosConfigLoadOnboardingRetailScenarioRequestDto input)
        {
            var result = await _appService.LoadOnboardingRetailScenarioAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-self-data")]
        public async Task<IActionResult> LoadSelfDataAsync(Guid id)
        {
            var result = await _appService.LoadSelfDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/notify-synchronisation")]
        public async Task<IActionResult> NotifySynchronisationAsync(Guid id, [FromBody] PosConfigNotifySynchronisationRequestDto input)
        {
            var result = await _appService.NotifySynchronisationAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-existing-session-cb")]
        public async Task<IActionResult> OpenExistingSessionCbAsync(Guid id)
        {
            var result = await _appService.OpenExistingSessionCbAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-opened-rescue-session-form")]
        public async Task<IActionResult> OpenOpenedRescueSessionFormAsync(Guid id)
        {
            var result = await _appService.OpenOpenedRescueSessionFormAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-ui")]
        public async Task<IActionResult> OpenUiAsync(Guid id)
        {
            var result = await _appService.OpenUiAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/preview-self-order-app")]
        public async Task<IActionResult> PreviewSelfOrderAppAsync(Guid id)
        {
            var result = await _appService.PreviewSelfOrderAppAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/read-config-open-orders")]
        public async Task<IActionResult> ReadConfigOpenOrdersAsync(Guid id, [FromBody] PosConfigReadConfigOpenOrdersRequestDto input)
        {
            var result = await _appService.ReadConfigOpenOrdersAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/register-new-device-identifier")]
        public async Task<IActionResult> RegisterNewDeviceIdentifierAsync(Guid id)
        {
            var result = await _appService.RegisterNewDeviceIdentifierAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-customer-display")]
        public async Task<IActionResult> UpdateCustomerDisplayAsync(Guid id, [FromBody] PosConfigUpdateCustomerDisplayRequestDto input)
        {
            var result = await _appService.UpdateCustomerDisplayAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/use-coupon-code")]
        public async Task<IActionResult> UseCouponCodeAsync(Guid id, [FromBody] PosConfigUseCouponCodeRequestDto input)
        {
            var result = await _appService.UseCouponCodeAsync(id, input);
            return Ok(result);
        }
    }
}