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
        [Route("{id}/action-crm-assign-leads")]
        public async Task<IActionResult> ActionCrmAssignLeadsAsync(Guid id)
        {
            var result = await _appService.CrmAssignLeadsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-eu-oss-tax-mapping")]
        public async Task<IActionResult> ActionEuOssTaxMappingAsync(Guid id)
        {
            var result = await _appService.EuOssTaxMappingAsync(id);
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
        [Route("{id}/action-open-cloud-storage-migration-configurations")]
        public async Task<IActionResult> ActionOpenCloudStorageMigrationConfigurationsAsync(Guid id)
        {
            var result = await _appService.OpenCloudStorageMigrationConfigurationsAsync(id);
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
        [Route("{id}/action-open-product-feeds")]
        public async Task<IActionResult> ActionOpenProductFeedsAsync(Guid id)
        {
            var result = await _appService.OpenProductFeedsAsync(id);
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
        [Route("{id}/action-open-sms-twilio-account-manage")]
        public async Task<IActionResult> ActionOpenSmsTwilioAccountManageAsync(Guid id)
        {
            var result = await _appService.OpenSmsTwilioAccountManageAsync(id);
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
        [Route("{id}/action-pos-printer-dialog")]
        public async Task<IActionResult> ActionPosPrinterDialogAsync(Guid id)
        {
            var result = await _appService.PosPrinterDialogAsync(id);
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
        [Route("{id}/action-view-delivery-provider-modules")]
        public async Task<IActionResult> ActionViewDeliveryProviderModulesAsync(Guid id)
        {
            var result = await _appService.ViewDeliveryProviderModulesAsync(id);
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
        [Route("{id}/action-w-payment-start-payment-onboarding")]
        public async Task<IActionResult> ActionWPaymentStartPaymentOnboardingAsync(Guid id)
        {
            var result = await _appService.WPaymentStartPaymentOnboardingAsync(id);
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
        [Route("{id}/button-disconnect-this-database")]
        public async Task<IActionResult> ButtonDisconnectThisDatabaseAsync(Guid id)
        {
            var result = await _appService.ButtonDisconnectThisDatabaseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-open-peppol-config-wizard")]
        public async Task<IActionResult> ButtonOpenPeppolConfigWizardAsync(Guid id)
        {
            var result = await _appService.ButtonOpenPeppolConfigWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-peppol-disconnect-branch-from-parent")]
        public async Task<IActionResult> ButtonPeppolDisconnectBranchFromParentAsync(Guid id)
        {
            var result = await _appService.ButtonPeppolDisconnectBranchFromParentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-peppol-register-sender-as-receiver")]
        public async Task<IActionResult> ButtonPeppolRegisterSenderAsReceiverAsync(Guid id)
        {
            var result = await _appService.ButtonPeppolRegisterSenderAsReceiverAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-reconnect-this-database")]
        public async Task<IActionResult> ButtonReconnectThisDatabaseAsync(Guid id)
        {
            var result = await _appService.ButtonReconnectThisDatabaseAsync(id);
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
        [Route("{id}/get-pos-qr-stands")]
        public async Task<IActionResult> GetPosQrStandsAsync(Guid id)
        {
            var result = await _appService.GetPosQrStandsAsync(id);
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
        [Route("{id}/open-new-user-default-groups")]
        public async Task<IActionResult> OpenNewUserDefaultGroupsAsync(Guid id)
        {
            var result = await _appService.OpenNewUserDefaultGroupsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-payment-method-form")]
        public async Task<IActionResult> OpenPaymentMethodFormAsync(Guid id)
        {
            var result = await _appService.OpenPaymentMethodFormAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/pos-close-ui")]
        public async Task<IActionResult> PosCloseUiAsync(Guid id)
        {
            var result = await _appService.PosCloseUiAsync(id);
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