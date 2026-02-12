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
    [Route("api/v1/sales/PosPaymentMethod")]
    public partial class PosPaymentMethodController : AbpController
    {
        protected readonly IPosPaymentMethodAppService _appService;
        public PosPaymentMethodController(IPosPaymentMethodAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-stripe-key")]
        public async Task<IActionResult> StripeKeyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StripeKeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] PosPaymentMethodCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("force-pdv")]
        public async Task<IActionResult> ForcePdvAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ForcePdvAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-latest-adyen-status")]
        public async Task<IActionResult> GetLatestAdyenStatusAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetLatestAdyenStatusAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-latest-viva-com-status")]
        public async Task<IActionResult> GetLatestVivaComStatusAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetLatestVivaComStatusAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-provider-status")]
        public async Task<IActionResult> GetProviderStatusAsync([FromBody] PosPaymentMethodGetProviderStatusRequestDto input)
        {
            var result = await _appService.GetProviderStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-qr-code")]
        public async Task<IActionResult> GetQrCodeAsync([FromBody] PosPaymentMethodGetQrCodeRequestDto input)
        {
            var result = await _appService.GetQrCodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mp-get-payment-status")]
        public async Task<IActionResult> MpGetPaymentStatusAsync([FromBody] PosPaymentMethodMpGetPaymentStatusRequestDto input)
        {
            var result = await _appService.MpGetPaymentStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mp-payment-intent-cancel")]
        public async Task<IActionResult> MpPaymentIntentCancelAsync([FromBody] PosPaymentMethodMpPaymentIntentCancelRequestDto input)
        {
            var result = await _appService.MpPaymentIntentCancelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mp-payment-intent-create")]
        public async Task<IActionResult> MpPaymentIntentCreateAsync([FromBody] PosPaymentMethodMpPaymentIntentCreateRequestDto input)
        {
            var result = await _appService.MpPaymentIntentCreateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mp-payment-intent-get")]
        public async Task<IActionResult> MpPaymentIntentGetAsync([FromBody] PosPaymentMethodMpPaymentIntentGetRequestDto input)
        {
            var result = await _appService.MpPaymentIntentGetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pine-labs-cancel-payment-request")]
        public async Task<IActionResult> PineLabsCancelPaymentRequestAsync([FromBody] PosPaymentMethodPineLabsCancelPaymentRequestRequestDto input)
        {
            var result = await _appService.PineLabsCancelPaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pine-labs-fetch-payment-status")]
        public async Task<IActionResult> PineLabsFetchPaymentStatusAsync([FromBody] PosPaymentMethodPineLabsFetchPaymentStatusRequestDto input)
        {
            var result = await _appService.PineLabsFetchPaymentStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pine-labs-make-payment-request")]
        public async Task<IActionResult> PineLabsMakePaymentRequestAsync([FromBody] PosPaymentMethodPineLabsMakePaymentRequestRequestDto input)
        {
            var result = await _appService.PineLabsMakePaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("proxy-adyen-request")]
        public async Task<IActionResult> ProxyAdyenRequestAsync([FromBody] PosPaymentMethodProxyAdyenRequestRequestDto input)
        {
            var result = await _appService.ProxyAdyenRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("qfpay-sign-request")]
        public async Task<IActionResult> QfpaySignRequestAsync([FromBody] PosPaymentMethodQfpaySignRequestRequestDto input)
        {
            var result = await _appService.QfpaySignRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("razorpay-cancel-payment-request")]
        public async Task<IActionResult> RazorpayCancelPaymentRequestAsync([FromBody] PosPaymentMethodRazorpayCancelPaymentRequestRequestDto input)
        {
            var result = await _appService.RazorpayCancelPaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("razorpay-fetch-payment-status")]
        public async Task<IActionResult> RazorpayFetchPaymentStatusAsync([FromBody] PosPaymentMethodRazorpayFetchPaymentStatusRequestDto input)
        {
            var result = await _appService.RazorpayFetchPaymentStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("razorpay-make-payment-request")]
        public async Task<IActionResult> RazorpayMakePaymentRequestAsync([FromBody] PosPaymentMethodRazorpayMakePaymentRequestRequestDto input)
        {
            var result = await _appService.RazorpayMakePaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("razorpay-make-refund-request")]
        public async Task<IActionResult> RazorpayMakeRefundRequestAsync([FromBody] PosPaymentMethodRazorpayMakeRefundRequestRequestDto input)
        {
            var result = await _appService.RazorpayMakeRefundRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-dpopay-request")]
        public async Task<IActionResult> SendDpopayRequestAsync([FromBody] PosPaymentMethodSendDpopayRequestRequestDto input)
        {
            var result = await _appService.SendDpopayRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stripe-capture-payment")]
        public async Task<IActionResult> StripeCapturePaymentAsync([FromBody] PosPaymentMethodStripeCapturePaymentRequestDto input)
        {
            var result = await _appService.StripeCapturePaymentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stripe-connection-token")]
        public async Task<IActionResult> StripeConnectionTokenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StripeConnectionTokenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stripe-payment-intent")]
        public async Task<IActionResult> StripePaymentIntentAsync([FromBody] PosPaymentMethodStripePaymentIntentRequestDto input)
        {
            var result = await _appService.StripePaymentIntentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viva-com-get-payment-status")]
        public async Task<IActionResult> VivaComGetPaymentStatusAsync([FromBody] PosPaymentMethodVivaComGetPaymentStatusRequestDto input)
        {
            var result = await _appService.VivaComGetPaymentStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viva-com-send-payment-cancel")]
        public async Task<IActionResult> VivaComSendPaymentCancelAsync([FromBody] PosPaymentMethodVivaComSendPaymentCancelRequestDto input)
        {
            var result = await _appService.VivaComSendPaymentCancelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viva-com-send-payment-request")]
        public async Task<IActionResult> VivaComSendPaymentRequestAsync([FromBody] PosPaymentMethodVivaComSendPaymentRequestRequestDto input)
        {
            var result = await _appService.VivaComSendPaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viva-com-send-refund-request")]
        public async Task<IActionResult> VivaComSendRefundRequestAsync([FromBody] PosPaymentMethodVivaComSendRefundRequestRequestDto input)
        {
            var result = await _appService.VivaComSendRefundRequestAsync(input);
            return Ok(result);
        }
    }
    
}