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
        [Route("action-crm-assign-leads")]
        public async Task<IActionResult> ActionCrmAssignLeadsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CrmAssignLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-eu-oss-tax-mapping")]
        public async Task<IActionResult> ActionEuOssTaxMappingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.EuOssTaxMappingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-abandoned-cart-mail-template")]
        public async Task<IActionResult> ActionOpenAbandonedCartMailTemplateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAbandonedCartMailTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-blocked-third-party-domains")]
        public async Task<IActionResult> ActionOpenBlockedThirdPartyDomainsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenBlockedThirdPartyDomainsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-cloud-storage-migration-configurations")]
        public async Task<IActionResult> ActionOpenCloudStorageMigrationConfigurationsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenCloudStorageMigrationConfigurationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-extra-info")]
        public async Task<IActionResult> ActionOpenExtraInfoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenExtraInfoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-peppol-form")]
        public async Task<IActionResult> ActionOpenPeppolFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenPeppolFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-product-feeds")]
        public async Task<IActionResult> ActionOpenProductFeedsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenProductFeedsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-robots")]
        public async Task<IActionResult> ActionOpenRobotsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenRobotsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-sale-mail-templates")]
        public async Task<IActionResult> ActionOpenSaleMailTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenSaleMailTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-sms-twilio-account-manage")]
        public async Task<IActionResult> ActionOpenSmsTwilioAccountManageAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenSmsTwilioAccountManageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-template-user")]
        public async Task<IActionResult> ActionOpenTemplateUserAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenTemplateUserAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-config-create-new")]
        public async Task<IActionResult> ActionPosConfigCreateNewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PosConfigCreateNewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-printer-dialog")]
        public async Task<IActionResult> ActionPosPrinterDialogAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PosPrinterDialogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-terms")]
        public async Task<IActionResult> ActionUpdateTermsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateTermsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-delivery-provider-modules")]
        public async Task<IActionResult> ActionViewDeliveryProviderModulesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewDeliveryProviderModulesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-in-store-delivery-methods")]
        public async Task<IActionResult> ActionViewInStoreDeliveryMethodsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewInStoreDeliveryMethodsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-w-payment-start-payment-onboarding")]
        public async Task<IActionResult> ActionWPaymentStartPaymentOnboardingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WPaymentStartPaymentOnboardingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-website-create-new")]
        public async Task<IActionResult> ActionWebsiteCreateNewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WebsiteCreateNewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-disconnect-this-database")]
        public async Task<IActionResult> ButtonDisconnectThisDatabaseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonDisconnectThisDatabaseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-open-peppol-config-wizard")]
        public async Task<IActionResult> ButtonOpenPeppolConfigWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonOpenPeppolConfigWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-peppol-disconnect-branch-from-parent")]
        public async Task<IActionResult> ButtonPeppolDisconnectBranchFromParentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonPeppolDisconnectBranchFromParentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-peppol-register-sender-as-receiver")]
        public async Task<IActionResult> ButtonPeppolRegisterSenderAsReceiverAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonPeppolRegisterSenderAsReceiverAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-reconnect-this-database")]
        public async Task<IActionResult> ButtonReconnectThisDatabaseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonReconnectThisDatabaseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("custom-link-action")]
        public async Task<IActionResult> CustomLinkActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CustomLinkActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("edit-external-header")]
        public async Task<IActionResult> EditExternalHeaderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.EditExternalHeaderAsync(ids);
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
        [Route("generate-qr-codes-page")]
        public async Task<IActionResult> GenerateQrCodesPageAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GenerateQrCodesPageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-qr-codes-zip")]
        public async Task<IActionResult> GenerateQrCodesZipAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GenerateQrCodesZipAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-config-warning")]
        public async Task<IActionResult> GetConfigWarningAsync(ResConfigSettingsGetConfigWarningRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetConfigWarningAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-option-name")]
        public async Task<IActionResult> GetOptionNameAsync(ResConfigSettingsGetOptionNameRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetOptionNameAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-option-path")]
        public async Task<IActionResult> GetOptionPathAsync(ResConfigSettingsGetOptionPathRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetOptionPathAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-pos-qr-stands")]
        public async Task<IActionResult> GetPosQrStandsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPosQrStandsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-uri")]
        public async Task<IActionResult> GetUriAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetUriAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-values")]
        public async Task<IActionResult> GetValuesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetValuesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-adv-location")]
        public async Task<IActionResult> OnchangeAdvLocationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeAdvLocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-analytic-accounting")]
        public async Task<IActionResult> OnchangeAnalyticAccountingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeAnalyticAccountingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-module-account-budget")]
        public async Task<IActionResult> OnchangeModuleAccountBudgetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeModuleAccountBudgetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-company")]
        public async Task<IActionResult> OpenCompanyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenCompanyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-email-layout")]
        public async Task<IActionResult> OpenEmailLayoutAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenEmailLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-followup-level-form")]
        public async Task<IActionResult> OpenFollowupLevelFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenFollowupLevelFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-mail-templates")]
        public async Task<IActionResult> OpenMailTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenMailTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-new-user-default-groups")]
        public async Task<IActionResult> OpenNewUserDefaultGroupsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenNewUserDefaultGroupsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-payment-method-form")]
        public async Task<IActionResult> OpenPaymentMethodFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenPaymentMethodFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pos-close-ui")]
        public async Task<IActionResult> PosCloseUiAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PosCloseUiAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pos-open-ui")]
        public async Task<IActionResult> PosOpenUiAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PosOpenUiAsync(ids);
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
        [Route("redirect-to-buy-autocomplete-credit")]
        public async Task<IActionResult> RedirectToBuyAutocompleteCreditAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToBuyAutocompleteCreditAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("regenerate-kiosk-key")]
        public async Task<IActionResult> RegenerateKioskKeyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RegenerateKioskKeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reload-template")]
        public async Task<IActionResult> ReloadTemplateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReloadTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-values")]
        public async Task<IActionResult> SetValuesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetValuesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-access-tokens")]
        public async Task<IActionResult> UpdateAccessTokensAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateAccessTokensAsync(ids);
            return Ok(result);
        }
    }
}