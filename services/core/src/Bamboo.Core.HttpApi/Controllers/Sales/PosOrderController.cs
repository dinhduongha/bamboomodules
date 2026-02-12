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
    [Route("api/v1/sales/PosOrder")]
    public partial class PosOrderController : AbpController
    {
        protected readonly IPosOrderAppService _appService;
        public PosOrderController(IPosOrderAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-create-invoices")]
        public async Task<IActionResult> CreateInvoicesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateInvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-order-cancel")]
        public async Task<IActionResult> PosOrderCancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PosOrderCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-order-invoice")]
        public async Task<IActionResult> PosOrderInvoiceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PosOrderInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-order-paid")]
        public async Task<IActionResult> PosOrderPaidAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PosOrderPaidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mail")]
        public async Task<IActionResult> SendMailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendMailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-receipt")]
        public async Task<IActionResult> SendReceiptAsync([FromBody] PosOrderSendReceiptRequestDto input)
        {
            var result = await _appService.SendReceiptAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-self-order-receipt")]
        public async Task<IActionResult> SendSelfOrderReceiptAsync([FromBody] PosOrderSendSelfOrderReceiptRequestDto input)
        {
            var result = await _appService.SendSelfOrderReceiptAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sent-message-on-sms")]
        public async Task<IActionResult> SentMessageOnSmsAsync([FromBody] PosOrderSentMessageOnSmsRequestDto input)
        {
            var result = await _appService.SentMessageOnSmsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stock-picking")]
        public async Task<IActionResult> StockPickingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StockPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-attendee-list")]
        public async Task<IActionResult> ViewAttendeeListAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewAttendeeListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-invoice")]
        public async Task<IActionResult> ViewInvoiceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-refund-orders")]
        public async Task<IActionResult> ViewRefundOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRefundOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-refunded-order")]
        public async Task<IActionResult> ViewRefundedOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRefundedOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ViewSaleOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-loyalty-history-lines")]
        public async Task<IActionResult> AddLoyaltyHistoryLinesAsync([FromBody] PosOrderAddLoyaltyHistoryLinesRequestDto input)
        {
            var result = await _appService.AddLoyaltyHistoryLinesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-payment")]
        public async Task<IActionResult> AddPaymentAsync([FromBody] PosOrderAddPaymentRequestDto input)
        {
            var result = await _appService.AddPaymentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("confirm-coupon-programs")]
        public async Task<IActionResult> ConfirmCouponProgramsAsync([FromBody] PosOrderConfirmCouponProgramsRequestDto input)
        {
            var result = await _appService.ConfirmCouponProgramsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-amount-unpaid")]
        public async Task<IActionResult> GetAmountUnpaidAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAmountUnpaidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-and-set-online-payments-data")]
        public async Task<IActionResult> GetAndSetOnlinePaymentsDataAsync([FromBody] PosOrderGetAndSetOnlinePaymentsDataRequestDto input)
        {
            var result = await _appService.GetAndSetOnlinePaymentsDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-order-to-print")]
        public async Task<IActionResult> GetOrderToPrintAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetOrderToPrintAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-preparation-change")]
        public async Task<IActionResult> GetPreparationChangeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPreparationChangeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-reference-last-part")]
        public async Task<IActionResult> GetReferenceLastPartAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetReferenceLastPartAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-event-badges")]
        public async Task<IActionResult> PrintEventBadgesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrintEventBadgesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-event-tickets")]
        public async Task<IActionResult> PrintEventTicketsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrintEventTicketsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("read-pos-data")]
        public async Task<IActionResult> ReadPosDataAsync([FromBody] PosOrderReadPosDataRequestDto input)
        {
            var result = await _appService.ReadPosDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("read-pos-data-uuid")]
        public async Task<IActionResult> ReadPosDataUuidAsync([FromBody] PosOrderReadPosDataUuidRequestDto input)
        {
            var result = await _appService.ReadPosDataUuidAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("read-pos-orders")]
        public async Task<IActionResult> ReadPosOrdersAsync([FromBody] PosOrderReadPosOrdersRequestDto input)
        {
            var result = await _appService.ReadPosOrdersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("refund")]
        public async Task<IActionResult> RefundAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefundAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("remove-from-ui")]
        public async Task<IActionResult> RemoveFromUiAsync([FromBody] PosOrderRemoveFromUiRequestDto input)
        {
            var result = await _appService.RemoveFromUiAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-paid-order-ids")]
        public async Task<IActionResult> SearchPaidOrderIdsAsync([FromBody] PosOrderSearchPaidOrderIdsRequestDto input)
        {
            var result = await _appService.SearchPaidOrderIdsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sync-from-ui")]
        public async Task<IActionResult> SyncFromUiAsync([FromBody] PosOrderSyncFromUiRequestDto input)
        {
            var result = await _appService.SyncFromUiAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate-coupon-programs")]
        public async Task<IActionResult> ValidateCouponProgramsAsync([FromBody] PosOrderValidateCouponProgramsRequestDto input)
        {
            var result = await _appService.ValidateCouponProgramsAsync(input);
            return Ok(result);
        }
    }
    
}