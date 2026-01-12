using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResConfigSettingsController
    {
        
        [HttpPost]
        [Route("{id}/action-activate-stripe")]
        public async Task<IActionResult> ActionActivateStripeAsync(Guid id)
        {
            var result = await _appService.ActivateStripeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-configure-first-provider")]
        public async Task<IActionResult> ActionConfigureFirstProviderAsync(Guid id)
        {
            var result = await _appService.ConfigureFirstProviderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-crm-assign-leads")]
        public async Task<IActionResult> ActionCrmAssignLeadsAsync(Guid id)
        {
            var result = await _appService.CrmAssignLeadsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-abandoned-cart-mail-template")]
        public async Task<IActionResult> ActionOpenAbandonedCartMailTemplateAsync(Guid id)
        {
            var result = await _appService.OpenAbandonedCartMailTemplateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-blocked-third-party-domains")]
        public async Task<IActionResult> ActionOpenBlockedThirdPartyDomainsAsync(Guid id)
        {
            var result = await _appService.OpenBlockedThirdPartyDomainsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-extra-info")]
        public async Task<IActionResult> ActionOpenExtraInfoAsync(Guid id)
        {
            var result = await _appService.OpenExtraInfoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-peppol-form")]
        public async Task<IActionResult> ActionOpenPeppolFormAsync(Guid id)
        {
            var result = await _appService.OpenPeppolFormAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-robots")]
        public async Task<IActionResult> ActionOpenRobotsAsync(Guid id)
        {
            var result = await _appService.OpenRobotsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-sale-mail-templates")]
        public async Task<IActionResult> ActionOpenSaleMailTemplatesAsync(Guid id)
        {
            var result = await _appService.OpenSaleMailTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-template-user")]
        public async Task<IActionResult> ActionOpenTemplateUserAsync(Guid id)
        {
            var result = await _appService.OpenTemplateUserAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-pos-config-create-new")]
        public async Task<IActionResult> ActionPosConfigCreateNewAsync(Guid id)
        {
            var result = await _appService.PosConfigCreateNewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-update-terms")]
        public async Task<IActionResult> ActionUpdateTermsAsync(Guid id)
        {
            var result = await _appService.UpdateTermsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-in-store-delivery-methods")]
        public async Task<IActionResult> ActionViewInStoreDeliveryMethodsAsync(Guid id)
        {
            var result = await _appService.ViewInStoreDeliveryMethodsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-website-create-new")]
        public async Task<IActionResult> ActionWebsiteCreateNewAsync(Guid id)
        {
            var result = await _appService.WebsiteCreateNewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-account-peppol-configure-services")]
        public async Task<IActionResult> ButtonAccountPeppolConfigureServicesAsync(Guid id)
        {
            var result = await _appService.ButtonAccountPeppolConfigureServicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-deregister-peppol-participant")]
        public async Task<IActionResult> ButtonDeregisterPeppolParticipantAsync(Guid id)
        {
            var result = await _appService.ButtonDeregisterPeppolParticipantAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-migrate-peppol-registration")]
        public async Task<IActionResult> ButtonMigratePeppolRegistrationAsync(Guid id)
        {
            var result = await _appService.ButtonMigratePeppolRegistrationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-peppol-smp-registration")]
        public async Task<IActionResult> ButtonPeppolSmpRegistrationAsync(Guid id)
        {
            var result = await _appService.ButtonPeppolSmpRegistrationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-update-peppol-user-data")]
        public async Task<IActionResult> ButtonUpdatePeppolUserDataAsync(Guid id)
        {
            var result = await _appService.ButtonUpdatePeppolUserDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/cancel")]
        public async Task<IActionResult> CancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/custom-link-action")]
        public async Task<IActionResult> CustomLinkActionAsync(Guid id)
        {
            var result = await _appService.CustomLinkActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/edit-external-header")]
        public async Task<IActionResult> EditExternalHeaderAsync(Guid id)
        {
            var result = await _appService.EditExternalHeaderAsync(id);
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
        [Route("{id}/generate-qr-codes-page")]
        public async Task<IActionResult> GenerateQrCodesPageAsync(Guid id)
        {
            var result = await _appService.GenerateQrCodesPageAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/generate-qr-codes-zip")]
        public async Task<IActionResult> GenerateQrCodesZipAsync(Guid id)
        {
            var result = await _appService.GenerateQrCodesZipAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-config-warning")]
        public async Task<IActionResult> GetConfigWarningAsync(Guid id, [FromBody] ResConfigSettingsGetConfigWarningRequestDto input)
        {
            var result = await _appService.GetConfigWarningAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-option-name")]
        public async Task<IActionResult> GetOptionNameAsync(Guid id, [FromBody] ResConfigSettingsGetOptionNameRequestDto input)
        {
            var result = await _appService.GetOptionNameAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-option-path")]
        public async Task<IActionResult> GetOptionPathAsync(Guid id, [FromBody] ResConfigSettingsGetOptionPathRequestDto input)
        {
            var result = await _appService.GetOptionPathAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-uri")]
        public async Task<IActionResult> GetUriAsync(Guid id)
        {
            var result = await _appService.GetUriAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-values")]
        public async Task<IActionResult> GetValuesAsync(Guid id)
        {
            var result = await _appService.GetValuesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-adv-location")]
        public async Task<IActionResult> OnchangeAdvLocationAsync(Guid id)
        {
            var result = await _appService.OnchangeAdvLocationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-analytic-accounting")]
        public async Task<IActionResult> OnchangeAnalyticAccountingAsync(Guid id)
        {
            var result = await _appService.OnchangeAnalyticAccountingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-module")]
        public async Task<IActionResult> OnchangeModuleAsync(Guid id, [FromBody] ResConfigSettingsOnchangeModuleRequestDto input)
        {
            var result = await _appService.OnchangeModuleAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-module-account-budget")]
        public async Task<IActionResult> OnchangeModuleAccountBudgetAsync(Guid id)
        {
            var result = await _appService.OnchangeModuleAccountBudgetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-company")]
        public async Task<IActionResult> OpenCompanyAsync(Guid id)
        {
            var result = await _appService.OpenCompanyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-default-user")]
        public async Task<IActionResult> OpenDefaultUserAsync(Guid id)
        {
            var result = await _appService.OpenDefaultUserAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-email-layout")]
        public async Task<IActionResult> OpenEmailLayoutAsync(Guid id)
        {
            var result = await _appService.OpenEmailLayoutAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-followup-level-form")]
        public async Task<IActionResult> OpenFollowupLevelFormAsync(Guid id)
        {
            var result = await _appService.OpenFollowupLevelFormAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-mail-templates")]
        public async Task<IActionResult> OpenMailTemplatesAsync(Guid id)
        {
            var result = await _appService.OpenMailTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/pos-open-ui")]
        public async Task<IActionResult> PosOpenUiAsync(Guid id)
        {
            var result = await _appService.PosOpenUiAsync(id);
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
        [Route("{id}/redirect-to-buy-autocomplete-credit")]
        public async Task<IActionResult> RedirectToBuyAutocompleteCreditAsync(Guid id)
        {
            var result = await _appService.RedirectToBuyAutocompleteCreditAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/regenerate-kiosk-key")]
        public async Task<IActionResult> RegenerateKioskKeyAsync(Guid id)
        {
            var result = await _appService.RegenerateKioskKeyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reload-template")]
        public async Task<IActionResult> ReloadTemplateAsync(Guid id)
        {
            var result = await _appService.ReloadTemplateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-account")]
        public async Task<IActionResult> RemoveAccountAsync(Guid id)
        {
            var result = await _appService.RemoveAccountAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-account-chart")]
        public async Task<IActionResult> RemoveAccountChartAsync(Guid id)
        {
            var result = await _appService.RemoveAccountChartAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-all")]
        public async Task<IActionResult> RemoveAllAsync(Guid id)
        {
            var result = await _appService.RemoveAllAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-data")]
        public async Task<IActionResult> RemoveDataAsync(Guid id, [FromBody] ResConfigSettingsRemoveDataRequestDto input)
        {
            var result = await _appService.RemoveDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-expense")]
        public async Task<IActionResult> RemoveExpenseAsync(Guid id)
        {
            var result = await _appService.RemoveExpenseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-inventory")]
        public async Task<IActionResult> RemoveInventoryAsync(Guid id)
        {
            var result = await _appService.RemoveInventoryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-message")]
        public async Task<IActionResult> RemoveMessageAsync(Guid id)
        {
            var result = await _appService.RemoveMessageAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-mrp")]
        public async Task<IActionResult> RemoveMrpAsync(Guid id)
        {
            var result = await _appService.RemoveMrpAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-mrp-bom")]
        public async Task<IActionResult> RemoveMrpBomAsync(Guid id)
        {
            var result = await _appService.RemoveMrpBomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-pos")]
        public async Task<IActionResult> RemovePosAsync(Guid id)
        {
            var result = await _appService.RemovePosAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-product")]
        public async Task<IActionResult> RemoveProductAsync(Guid id)
        {
            var result = await _appService.RemoveProductAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-product-attribute")]
        public async Task<IActionResult> RemoveProductAttributeAsync(Guid id)
        {
            var result = await _appService.RemoveProductAttributeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-project")]
        public async Task<IActionResult> RemoveProjectAsync(Guid id)
        {
            var result = await _appService.RemoveProjectAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-purchase")]
        public async Task<IActionResult> RemovePurchaseAsync(Guid id)
        {
            var result = await _appService.RemovePurchaseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-quality")]
        public async Task<IActionResult> RemoveQualityAsync(Guid id)
        {
            var result = await _appService.RemoveQualityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-quality-setting")]
        public async Task<IActionResult> RemoveQualitySettingAsync(Guid id)
        {
            var result = await _appService.RemoveQualitySettingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-sales")]
        public async Task<IActionResult> RemoveSalesAsync(Guid id)
        {
            var result = await _appService.RemoveSalesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-website")]
        public async Task<IActionResult> RemoveWebsiteAsync(Guid id)
        {
            var result = await _appService.RemoveWebsiteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reset-cat-loc-name")]
        public async Task<IActionResult> ResetCatLocNameAsync(Guid id)
        {
            var result = await _appService.ResetCatLocNameAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-values")]
        public async Task<IActionResult> SetValuesAsync(Guid id)
        {
            var result = await _appService.SetValuesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-access-tokens")]
        public async Task<IActionResult> UpdateAccessTokensAsync(Guid id)
        {
            var result = await _appService.UpdateAccessTokensAsync(id);
            return Ok(result);
        }
    }
}