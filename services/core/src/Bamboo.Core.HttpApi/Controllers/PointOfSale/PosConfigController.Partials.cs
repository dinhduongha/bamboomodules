using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
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
        [Route("{id}/execute")]
        public async Task<IActionResult> ExecuteAsync(Guid id)
        {
            var result = await _appService.ExecuteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-categories")]
        public async Task<IActionResult> GetCategoriesAsync(Guid id, [FromBody] PosConfigGetCategoriesRequestDto input)
        {
            var result = await _appService.GetCategoriesAsync(id, input.Categories);
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
        public async Task<IActionResult> GetLimitedPartnersLoadingAsync(Guid id)
        {
            var result = await _appService.GetLimitedPartnersLoadingAsync(id);
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
        [Route("{id}/get-limited-products-loading")]
        public async Task<IActionResult> GetLimitedProductsLoadingAsync(Guid id, [FromBody] PosConfigGetLimitedProductsLoadingRequestDto input)
        {
            var result = await _appService.GetLimitedProductsLoadingAsync(id, input.Fields);
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
        [Route("{id}/get-records")]
        public async Task<IActionResult> GetRecordsAsync(Guid id, [FromBody] PosConfigGetRecordsRequestDto input)
        {
            var result = await _appService.GetRecordsAsync(id, input.Data);
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
        [Route("{id}/load-onboarding-bakery-scenario")]
        public async Task<IActionResult> LoadOnboardingBakeryScenarioAsync(Guid id)
        {
            var result = await _appService.LoadOnboardingBakeryScenarioAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-bar-scenario")]
        public async Task<IActionResult> LoadOnboardingBarScenarioAsync(Guid id)
        {
            var result = await _appService.LoadOnboardingBarScenarioAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-clothes-scenario")]
        public async Task<IActionResult> LoadOnboardingClothesScenarioAsync(Guid id)
        {
            var result = await _appService.LoadOnboardingClothesScenarioAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-onboarding-furniture-scenario")]
        public async Task<IActionResult> LoadOnboardingFurnitureScenarioAsync(Guid id)
        {
            var result = await _appService.LoadOnboardingFurnitureScenarioAsync(id);
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
        public async Task<IActionResult> LoadOnboardingRestaurantScenarioAsync(Guid id)
        {
            var result = await _appService.LoadOnboardingRestaurantScenarioAsync(id);
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
            var result = await _appService.NotifySynchronisationAsync(id, input.SessionId, input.LoginNumber, input.Records);
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
            var result = await _appService.ReadConfigOpenOrdersAsync(id, input.Domain, input.RecordIds);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-customer-display")]
        public async Task<IActionResult> UpdateCustomerDisplayAsync(Guid id, [FromBody] PosConfigUpdateCustomerDisplayRequestDto input)
        {
            var result = await _appService.UpdateCustomerDisplayAsync(id, input.Order, input.AccessToken);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/use-coupon-code")]
        public async Task<IActionResult> UseCouponCodeAsync(Guid id, [FromBody] PosConfigUseCouponCodeRequestDto input)
        {
            var result = await _appService.UseCouponCodeAsync(id, input.Code, input.CreationDate, input.PartnerId, input.PricelistId);
            return Ok(result);
        }
    }
}