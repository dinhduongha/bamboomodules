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
        [Route("action-paypal-create-webhook")]
        public async Task<IActionResult> ActionPaypalCreateWebhookAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PaypalCreateWebhookAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-razorpay-create-webhook")]
        public async Task<IActionResult> ActionRazorpayCreateWebhookAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RazorpayCreateWebhookAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-recompute-pending-msg")]
        public async Task<IActionResult> ActionRecomputePendingMsgAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RecomputePendingMsgAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset-credentials")]
        public async Task<IActionResult> ActionResetCredentialsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetCredentialsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start-onboarding")]
        public async Task<IActionResult> ActionStartOnboardingAsync(PaymentProviderStartOnboardingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.StartOnboardingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stripe-create-webhook")]
        public async Task<IActionResult> ActionStripeCreateWebhookAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StripeCreateWebhookAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stripe-verify-apple-pay-domain")]
        public async Task<IActionResult> ActionStripeVerifyApplePayDomainAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StripeVerifyApplePayDomainAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sync-paymob-payment-methods")]
        public async Task<IActionResult> ActionSyncPaymobPaymentMethodsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SyncPaymobPaymentMethodsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-is-published")]
        public async Task<IActionResult> ActionToggleIsPublishedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleIsPublishedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-merchant-details")]
        public async Task<IActionResult> ActionUpdateMerchantDetailsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateMerchantDetailsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-payment-methods")]
        public async Task<IActionResult> ActionViewPaymentMethodsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPaymentMethodsAsync(ids);
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
        [Route("get-base-url")]
        public async Task<IActionResult> GetBaseUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetBaseUrlAsync(ids);
            return Ok(result);
        }
    }
}