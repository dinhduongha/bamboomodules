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
        [Route("{id}/get-latest-viva-wallet-status")]
        public async Task<IActionResult> GetLatestVivaWalletStatusAsync(Guid id)
        {
            var result = await _appService.GetLatestVivaWalletStatusAsync(id);
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
        [Route("{id}/paytm-fetch-payment-status")]
        public async Task<IActionResult> PaytmFetchPaymentStatusAsync(Guid id, [FromBody] PosPaymentMethodPaytmFetchPaymentStatusRequestDto input)
        {
            var result = await _appService.PaytmFetchPaymentStatusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/paytm-make-payment-request")]
        public async Task<IActionResult> PaytmMakePaymentRequestAsync(Guid id, [FromBody] PosPaymentMethodPaytmMakePaymentRequestRequestDto input)
        {
            var result = await _appService.PaytmMakePaymentRequestAsync(id, input);
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
        [Route("{id}/viva-wallet-get-payment-status")]
        public async Task<IActionResult> VivaWalletGetPaymentStatusAsync(Guid id, [FromBody] PosPaymentMethodVivaWalletGetPaymentStatusRequestDto input)
        {
            var result = await _appService.VivaWalletGetPaymentStatusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/viva-wallet-send-payment-cancel")]
        public async Task<IActionResult> VivaWalletSendPaymentCancelAsync(Guid id, [FromBody] PosPaymentMethodVivaWalletSendPaymentCancelRequestDto input)
        {
            var result = await _appService.VivaWalletSendPaymentCancelAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/viva-wallet-send-payment-request")]
        public async Task<IActionResult> VivaWalletSendPaymentRequestAsync(Guid id, [FromBody] PosPaymentMethodVivaWalletSendPaymentRequestRequestDto input)
        {
            var result = await _appService.VivaWalletSendPaymentRequestAsync(id, input);
            return Ok(result);
        }
    }
}