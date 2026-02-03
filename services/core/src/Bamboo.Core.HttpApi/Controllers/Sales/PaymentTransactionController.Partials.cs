using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PaymentTransactionController
    {
        
        [HttpPost]
        [Route("action-capture")]
        public async Task<IActionResult> ActionCaptureAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CaptureAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-demo-set-canceled")]
        public async Task<IActionResult> ActionDemoSetCanceledAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DemoSetCanceledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-demo-set-done")]
        public async Task<IActionResult> ActionDemoSetDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DemoSetDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-demo-set-error")]
        public async Task<IActionResult> ActionDemoSetErrorAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DemoSetErrorAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-post-process")]
        public async Task<IActionResult> ActionPostProcessAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PostProcessAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refund")]
        public async Task<IActionResult> ActionRefundAsync(PaymentTransactionRefundRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RefundAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-invoices")]
        public async Task<IActionResult> ActionViewInvoicesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewInvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-pos-order")]
        public async Task<IActionResult> ActionViewPosOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPosOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-refunds")]
        public async Task<IActionResult> ActionViewRefundsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRefundsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sales-orders")]
        public async Task<IActionResult> ActionViewSalesOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSalesOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-void")]
        public async Task<IActionResult> ActionVoidAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.VoidAsync(ids);
            return Ok(result);
        }
    }
}