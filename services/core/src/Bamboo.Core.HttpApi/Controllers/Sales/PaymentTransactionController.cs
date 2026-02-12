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
    [Route("api/v1/payment/PaymentTransaction")]
    public partial class PaymentTransactionController : AbpController
    {
        protected readonly IPaymentTransactionAppService _appService;
        public PaymentTransactionController(IPaymentTransactionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-capture")]
        public async Task<IActionResult> CaptureAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CaptureAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-demo-set-canceled")]
        public async Task<IActionResult> DemoSetCanceledAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DemoSetCanceledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-demo-set-done")]
        public async Task<IActionResult> DemoSetDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DemoSetDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-demo-set-error")]
        public async Task<IActionResult> DemoSetErrorAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DemoSetErrorAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-post-process")]
        public async Task<IActionResult> PostProcessAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PostProcessAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refund")]
        public async Task<IActionResult> RefundAsync([FromBody] PaymentTransactionRefundRequestDto input)
        {
            var result = await _appService.RefundAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-invoices")]
        public async Task<IActionResult> ViewInvoicesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewInvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-pos-order")]
        public async Task<IActionResult> ViewPosOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPosOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-refunds")]
        public async Task<IActionResult> ViewRefundsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRefundsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sales-orders")]
        public async Task<IActionResult> ViewSalesOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSalesOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-void")]
        public async Task<IActionResult> VoidAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.VoidAsync(ids);
            return Ok(result);
        }
    }
    
}