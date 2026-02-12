using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/payment/PaymentProvider")]
    public partial class PaymentProviderController : AbpController
    {
        protected readonly IPaymentProviderAppService _appService;
        public PaymentProviderController(IPaymentProviderAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-paypal-create-webhook")]
        public async Task<IActionResult> PaypalCreateWebhookAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PaypalCreateWebhookAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-razorpay-create-webhook")]
        public async Task<IActionResult> RazorpayCreateWebhookAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RazorpayCreateWebhookAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-recompute-pending-msg")]
        public async Task<IActionResult> RecomputePendingMsgAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RecomputePendingMsgAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset-credentials")]
        public async Task<IActionResult> ResetCredentialsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetCredentialsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start-onboarding")]
        public async Task<IActionResult> StartOnboardingAsync([FromBody] PaymentProviderStartOnboardingRequestDto input)
        {
            var result = await _appService.StartOnboardingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stripe-create-webhook")]
        public async Task<IActionResult> StripeCreateWebhookAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StripeCreateWebhookAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stripe-verify-apple-pay-domain")]
        public async Task<IActionResult> StripeVerifyApplePayDomainAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StripeVerifyApplePayDomainAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sync-paymob-payment-methods")]
        public async Task<IActionResult> SyncPaymobPaymentMethodsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SyncPaymobPaymentMethodsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-is-published")]
        public async Task<IActionResult> ToggleIsPublishedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleIsPublishedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-merchant-details")]
        public async Task<IActionResult> UpdateMerchantDetailsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateMerchantDetailsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-payment-methods")]
        public async Task<IActionResult> ViewPaymentMethodsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPaymentMethodsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-immediate-install")]
        public async Task<IActionResult> ButtonImmediateInstallAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonImmediateInstallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-base-url")]
        public async Task<IActionResult> GetBaseUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetBaseUrlAsync(ids);
            return Ok(result);
        }
    }
    
}