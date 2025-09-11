using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PaymentTransactionController
    {
        
        [HttpPost]
        [Route("{id}/action-capture")]
        public async Task<IActionResult> ActionCaptureAsync(Guid id)
        {
            var result = await _appService.CaptureAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-demo-set-canceled")]
        public async Task<IActionResult> ActionDemoSetCanceledAsync(Guid id)
        {
            var result = await _appService.DemoSetCanceledAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-demo-set-done")]
        public async Task<IActionResult> ActionDemoSetDoneAsync(Guid id)
        {
            var result = await _appService.DemoSetDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-demo-set-error")]
        public async Task<IActionResult> ActionDemoSetErrorAsync(Guid id)
        {
            var result = await _appService.DemoSetErrorAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-refund")]
        public async Task<IActionResult> ActionRefundAsync(Guid id, [FromBody] PaymentTransactionRefundRequestDto input)
        {
            var result = await _appService.RefundAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-invoices")]
        public async Task<IActionResult> ActionViewInvoicesAsync(Guid id)
        {
            var result = await _appService.ViewInvoicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-pos-order")]
        public async Task<IActionResult> ActionViewPosOrderAsync(Guid id)
        {
            var result = await _appService.ViewPosOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-refunds")]
        public async Task<IActionResult> ActionViewRefundsAsync(Guid id)
        {
            var result = await _appService.ViewRefundsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sales-orders")]
        public async Task<IActionResult> ActionViewSalesOrdersAsync(Guid id)
        {
            var result = await _appService.ViewSalesOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-void")]
        public async Task<IActionResult> ActionVoidAsync(Guid id)
        {
            var result = await _appService.VoidAsync(id);
            return Ok(result);
        }
    }
}