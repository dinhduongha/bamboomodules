using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PosPaymentMethodController
    {
        
        [HttpPost]
        [Route("action-stripe-key")]
        public async Task<IActionResult> ActionStripeKeyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StripeKeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(PosPaymentMethodCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("force-pdv")]
        public async Task<IActionResult> ForcePdvAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ForcePdvAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-latest-adyen-status")]
        public async Task<IActionResult> GetLatestAdyenStatusAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetLatestAdyenStatusAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-latest-viva-com-status")]
        public async Task<IActionResult> GetLatestVivaComStatusAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetLatestVivaComStatusAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-provider-status")]
        public async Task<IActionResult> GetProviderStatusAsync(PosPaymentMethodGetProviderStatusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetProviderStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-qr-code")]
        public async Task<IActionResult> GetQrCodeAsync(PosPaymentMethodGetQrCodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetQrCodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mp-get-payment-status")]
        public async Task<IActionResult> MpGetPaymentStatusAsync(PosPaymentMethodMpGetPaymentStatusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MpGetPaymentStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mp-payment-intent-cancel")]
        public async Task<IActionResult> MpPaymentIntentCancelAsync(PosPaymentMethodMpPaymentIntentCancelRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MpPaymentIntentCancelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mp-payment-intent-create")]
        public async Task<IActionResult> MpPaymentIntentCreateAsync(PosPaymentMethodMpPaymentIntentCreateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MpPaymentIntentCreateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mp-payment-intent-get")]
        public async Task<IActionResult> MpPaymentIntentGetAsync(PosPaymentMethodMpPaymentIntentGetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MpPaymentIntentGetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pine-labs-cancel-payment-request")]
        public async Task<IActionResult> PineLabsCancelPaymentRequestAsync(PosPaymentMethodPineLabsCancelPaymentRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PineLabsCancelPaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pine-labs-fetch-payment-status")]
        public async Task<IActionResult> PineLabsFetchPaymentStatusAsync(PosPaymentMethodPineLabsFetchPaymentStatusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PineLabsFetchPaymentStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("pine-labs-make-payment-request")]
        public async Task<IActionResult> PineLabsMakePaymentRequestAsync(PosPaymentMethodPineLabsMakePaymentRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PineLabsMakePaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("proxy-adyen-request")]
        public async Task<IActionResult> ProxyAdyenRequestAsync(PosPaymentMethodProxyAdyenRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ProxyAdyenRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("qfpay-sign-request")]
        public async Task<IActionResult> QfpaySignRequestAsync(PosPaymentMethodQfpaySignRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.QfpaySignRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("razorpay-cancel-payment-request")]
        public async Task<IActionResult> RazorpayCancelPaymentRequestAsync(PosPaymentMethodRazorpayCancelPaymentRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RazorpayCancelPaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("razorpay-fetch-payment-status")]
        public async Task<IActionResult> RazorpayFetchPaymentStatusAsync(PosPaymentMethodRazorpayFetchPaymentStatusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RazorpayFetchPaymentStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("razorpay-make-payment-request")]
        public async Task<IActionResult> RazorpayMakePaymentRequestAsync(PosPaymentMethodRazorpayMakePaymentRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RazorpayMakePaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("razorpay-make-refund-request")]
        public async Task<IActionResult> RazorpayMakeRefundRequestAsync(PosPaymentMethodRazorpayMakeRefundRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RazorpayMakeRefundRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-dpopay-request")]
        public async Task<IActionResult> SendDpopayRequestAsync(PosPaymentMethodSendDpopayRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendDpopayRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stripe-capture-payment")]
        public async Task<IActionResult> StripeCapturePaymentAsync(PosPaymentMethodStripeCapturePaymentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.StripeCapturePaymentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stripe-connection-token")]
        public async Task<IActionResult> StripeConnectionTokenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StripeConnectionTokenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stripe-payment-intent")]
        public async Task<IActionResult> StripePaymentIntentAsync(PosPaymentMethodStripePaymentIntentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.StripePaymentIntentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viva-com-get-payment-status")]
        public async Task<IActionResult> VivaComGetPaymentStatusAsync(PosPaymentMethodVivaComGetPaymentStatusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.VivaComGetPaymentStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viva-com-send-payment-cancel")]
        public async Task<IActionResult> VivaComSendPaymentCancelAsync(PosPaymentMethodVivaComSendPaymentCancelRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.VivaComSendPaymentCancelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viva-com-send-payment-request")]
        public async Task<IActionResult> VivaComSendPaymentRequestAsync(PosPaymentMethodVivaComSendPaymentRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.VivaComSendPaymentRequestAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("viva-com-send-refund-request")]
        public async Task<IActionResult> VivaComSendRefundRequestAsync(PosPaymentMethodVivaComSendRefundRequestRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.VivaComSendRefundRequestAsync(input);
            return Ok(result);
        }
    }
}