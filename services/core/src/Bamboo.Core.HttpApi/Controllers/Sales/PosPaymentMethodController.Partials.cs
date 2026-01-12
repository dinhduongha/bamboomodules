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
        [Route("{id}/action-stripe-key")]
        public async Task<IActionResult> ActionStripeKeyAsync(Guid id)
        {
            var result = await _appService.StripeKeyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] PosPaymentMethodCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/force-pdv")]
        public async Task<IActionResult> ForcePdvAsync(Guid id)
        {
            var result = await _appService.ForcePdvAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-latest-adyen-status")]
        public async Task<IActionResult> GetLatestAdyenStatusAsync(Guid id)
        {
            var result = await _appService.GetLatestAdyenStatusAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-latest-viva-com-status")]
        public async Task<IActionResult> GetLatestVivaComStatusAsync(Guid id)
        {
            var result = await _appService.GetLatestVivaComStatusAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-provider-status")]
        public async Task<IActionResult> GetProviderStatusAsync(Guid id, [FromBody] PosPaymentMethodGetProviderStatusRequestDto input)
        {
            var result = await _appService.GetProviderStatusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-qr-code")]
        public async Task<IActionResult> GetQrCodeAsync(Guid id, [FromBody] PosPaymentMethodGetQrCodeRequestDto input)
        {
            var result = await _appService.GetQrCodeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/mp-get-payment-status")]
        public async Task<IActionResult> MpGetPaymentStatusAsync(Guid id, [FromBody] PosPaymentMethodMpGetPaymentStatusRequestDto input)
        {
            var result = await _appService.MpGetPaymentStatusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/mp-payment-intent-cancel")]
        public async Task<IActionResult> MpPaymentIntentCancelAsync(Guid id, [FromBody] PosPaymentMethodMpPaymentIntentCancelRequestDto input)
        {
            var result = await _appService.MpPaymentIntentCancelAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/mp-payment-intent-create")]
        public async Task<IActionResult> MpPaymentIntentCreateAsync(Guid id, [FromBody] PosPaymentMethodMpPaymentIntentCreateRequestDto input)
        {
            var result = await _appService.MpPaymentIntentCreateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/mp-payment-intent-get")]
        public async Task<IActionResult> MpPaymentIntentGetAsync(Guid id, [FromBody] PosPaymentMethodMpPaymentIntentGetRequestDto input)
        {
            var result = await _appService.MpPaymentIntentGetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/pine-labs-cancel-payment-request")]
        public async Task<IActionResult> PineLabsCancelPaymentRequestAsync(Guid id, [FromBody] PosPaymentMethodPineLabsCancelPaymentRequestRequestDto input)
        {
            var result = await _appService.PineLabsCancelPaymentRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/pine-labs-fetch-payment-status")]
        public async Task<IActionResult> PineLabsFetchPaymentStatusAsync(Guid id, [FromBody] PosPaymentMethodPineLabsFetchPaymentStatusRequestDto input)
        {
            var result = await _appService.PineLabsFetchPaymentStatusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/pine-labs-make-payment-request")]
        public async Task<IActionResult> PineLabsMakePaymentRequestAsync(Guid id, [FromBody] PosPaymentMethodPineLabsMakePaymentRequestRequestDto input)
        {
            var result = await _appService.PineLabsMakePaymentRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/proxy-adyen-request")]
        public async Task<IActionResult> ProxyAdyenRequestAsync(Guid id, [FromBody] PosPaymentMethodProxyAdyenRequestRequestDto input)
        {
            var result = await _appService.ProxyAdyenRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/qfpay-sign-request")]
        public async Task<IActionResult> QfpaySignRequestAsync(Guid id, [FromBody] PosPaymentMethodQfpaySignRequestRequestDto input)
        {
            var result = await _appService.QfpaySignRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/razorpay-cancel-payment-request")]
        public async Task<IActionResult> RazorpayCancelPaymentRequestAsync(Guid id, [FromBody] PosPaymentMethodRazorpayCancelPaymentRequestRequestDto input)
        {
            var result = await _appService.RazorpayCancelPaymentRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/razorpay-fetch-payment-status")]
        public async Task<IActionResult> RazorpayFetchPaymentStatusAsync(Guid id, [FromBody] PosPaymentMethodRazorpayFetchPaymentStatusRequestDto input)
        {
            var result = await _appService.RazorpayFetchPaymentStatusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/razorpay-make-payment-request")]
        public async Task<IActionResult> RazorpayMakePaymentRequestAsync(Guid id, [FromBody] PosPaymentMethodRazorpayMakePaymentRequestRequestDto input)
        {
            var result = await _appService.RazorpayMakePaymentRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/razorpay-make-refund-request")]
        public async Task<IActionResult> RazorpayMakeRefundRequestAsync(Guid id, [FromBody] PosPaymentMethodRazorpayMakeRefundRequestRequestDto input)
        {
            var result = await _appService.RazorpayMakeRefundRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-dpopay-request")]
        public async Task<IActionResult> SendDpopayRequestAsync(Guid id, [FromBody] PosPaymentMethodSendDpopayRequestRequestDto input)
        {
            var result = await _appService.SendDpopayRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/stripe-capture-payment")]
        public async Task<IActionResult> StripeCapturePaymentAsync(Guid id, [FromBody] PosPaymentMethodStripeCapturePaymentRequestDto input)
        {
            var result = await _appService.StripeCapturePaymentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/stripe-connection-token")]
        public async Task<IActionResult> StripeConnectionTokenAsync(Guid id)
        {
            var result = await _appService.StripeConnectionTokenAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/stripe-payment-intent")]
        public async Task<IActionResult> StripePaymentIntentAsync(Guid id, [FromBody] PosPaymentMethodStripePaymentIntentRequestDto input)
        {
            var result = await _appService.StripePaymentIntentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/viva-com-get-payment-status")]
        public async Task<IActionResult> VivaComGetPaymentStatusAsync(Guid id, [FromBody] PosPaymentMethodVivaComGetPaymentStatusRequestDto input)
        {
            var result = await _appService.VivaComGetPaymentStatusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/viva-com-send-payment-cancel")]
        public async Task<IActionResult> VivaComSendPaymentCancelAsync(Guid id, [FromBody] PosPaymentMethodVivaComSendPaymentCancelRequestDto input)
        {
            var result = await _appService.VivaComSendPaymentCancelAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/viva-com-send-payment-request")]
        public async Task<IActionResult> VivaComSendPaymentRequestAsync(Guid id, [FromBody] PosPaymentMethodVivaComSendPaymentRequestRequestDto input)
        {
            var result = await _appService.VivaComSendPaymentRequestAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/viva-com-send-refund-request")]
        public async Task<IActionResult> VivaComSendRefundRequestAsync(Guid id, [FromBody] PosPaymentMethodVivaComSendRefundRequestRequestDto input)
        {
            var result = await _appService.VivaComSendRefundRequestAsync(id, input);
            return Ok(result);
        }
    }
}