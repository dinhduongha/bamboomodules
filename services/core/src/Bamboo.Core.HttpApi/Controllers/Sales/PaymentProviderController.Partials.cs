using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PaymentProviderController
    {
        
        [HttpPost]
        [Route("{id}/action-paypal-create-webhook")]
        public async Task<IActionResult> ActionPaypalCreateWebhookAsync(Guid id)
        {
            var result = await _appService.PaypalCreateWebhookAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-razorpay-create-webhook")]
        public async Task<IActionResult> ActionRazorpayCreateWebhookAsync(Guid id)
        {
            var result = await _appService.RazorpayCreateWebhookAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-recompute-pending-msg")]
        public async Task<IActionResult> ActionRecomputePendingMsgAsync(Guid id)
        {
            var result = await _appService.RecomputePendingMsgAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reset-credentials")]
        public async Task<IActionResult> ActionResetCredentialsAsync(Guid id)
        {
            var result = await _appService.ResetCredentialsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-start-onboarding")]
        public async Task<IActionResult> ActionStartOnboardingAsync(Guid id, [FromBody] PaymentProviderStartOnboardingRequestDto input)
        {
            var result = await _appService.StartOnboardingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-stripe-create-webhook")]
        public async Task<IActionResult> ActionStripeCreateWebhookAsync(Guid id)
        {
            var result = await _appService.StripeCreateWebhookAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-stripe-verify-apple-pay-domain")]
        public async Task<IActionResult> ActionStripeVerifyApplePayDomainAsync(Guid id)
        {
            var result = await _appService.StripeVerifyApplePayDomainAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-sync-paymob-payment-methods")]
        public async Task<IActionResult> ActionSyncPaymobPaymentMethodsAsync(Guid id)
        {
            var result = await _appService.SyncPaymobPaymentMethodsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-toggle-is-published")]
        public async Task<IActionResult> ActionToggleIsPublishedAsync(Guid id)
        {
            var result = await _appService.ToggleIsPublishedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-update-merchant-details")]
        public async Task<IActionResult> ActionUpdateMerchantDetailsAsync(Guid id)
        {
            var result = await _appService.UpdateMerchantDetailsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-payment-methods")]
        public async Task<IActionResult> ActionViewPaymentMethodsAsync(Guid id)
        {
            var result = await _appService.ViewPaymentMethodsAsync(id);
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
        [Route("{id}/get-base-url")]
        public async Task<IActionResult> GetBaseUrlAsync(Guid id)
        {
            var result = await _appService.GetBaseUrlAsync(id);
            return Ok(result);
        }
    }
}