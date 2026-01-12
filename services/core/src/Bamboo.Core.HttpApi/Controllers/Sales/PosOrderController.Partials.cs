using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PosOrderController
    {
        
        [HttpPost]
        [Route("{id}/action-create-invoices")]
        public async Task<IActionResult> ActionCreateInvoicesAsync(Guid id)
        {
            var result = await _appService.CreateInvoicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-pos-order-cancel")]
        public async Task<IActionResult> ActionPosOrderCancelAsync(Guid id)
        {
            var result = await _appService.PosOrderCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-pos-order-invoice")]
        public async Task<IActionResult> ActionPosOrderInvoiceAsync(Guid id)
        {
            var result = await _appService.PosOrderInvoiceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-pos-order-paid")]
        public async Task<IActionResult> ActionPosOrderPaidAsync(Guid id)
        {
            var result = await _appService.PosOrderPaidAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-mail")]
        public async Task<IActionResult> ActionSendMailAsync(Guid id)
        {
            var result = await _appService.SendMailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-receipt")]
        public async Task<IActionResult> ActionSendReceiptAsync(Guid id, [FromBody] PosOrderSendReceiptRequestDto input)
        {
            var result = await _appService.SendReceiptAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-self-order-receipt")]
        public async Task<IActionResult> ActionSendSelfOrderReceiptAsync(Guid id, [FromBody] PosOrderSendSelfOrderReceiptRequestDto input)
        {
            var result = await _appService.SendSelfOrderReceiptAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-sent-message-on-sms")]
        public async Task<IActionResult> ActionSentMessageOnSmsAsync(Guid id, [FromBody] PosOrderSentMessageOnSmsRequestDto input)
        {
            var result = await _appService.SentMessageOnSmsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-stock-picking")]
        public async Task<IActionResult> ActionStockPickingAsync(Guid id)
        {
            var result = await _appService.StockPickingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-attendee-list")]
        public async Task<IActionResult> ActionViewAttendeeListAsync(Guid id)
        {
            var result = await _appService.ViewAttendeeListAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-invoice")]
        public async Task<IActionResult> ActionViewInvoiceAsync(Guid id)
        {
            var result = await _appService.ViewInvoiceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-refund-orders")]
        public async Task<IActionResult> ActionViewRefundOrdersAsync(Guid id)
        {
            var result = await _appService.ViewRefundOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-refunded-order")]
        public async Task<IActionResult> ActionViewRefundedOrderAsync(Guid id)
        {
            var result = await _appService.ViewRefundedOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid id)
        {
            var result = await _appService.ViewSaleOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/add-loyalty-history-lines")]
        public async Task<IActionResult> AddLoyaltyHistoryLinesAsync(Guid id, [FromBody] PosOrderAddLoyaltyHistoryLinesRequestDto input)
        {
            var result = await _appService.AddLoyaltyHistoryLinesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/add-payment")]
        public async Task<IActionResult> AddPaymentAsync(Guid id, [FromBody] PosOrderAddPaymentRequestDto input)
        {
            var result = await _appService.AddPaymentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/confirm-coupon-programs")]
        public async Task<IActionResult> ConfirmCouponProgramsAsync(Guid id, [FromBody] PosOrderConfirmCouponProgramsRequestDto input)
        {
            var result = await _appService.ConfirmCouponProgramsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-amount-unpaid")]
        public async Task<IActionResult> GetAmountUnpaidAsync(Guid id)
        {
            var result = await _appService.GetAmountUnpaidAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-and-set-online-payments-data")]
        public async Task<IActionResult> GetAndSetOnlinePaymentsDataAsync(Guid id, [FromBody] PosOrderGetAndSetOnlinePaymentsDataRequestDto input)
        {
            var result = await _appService.GetAndSetOnlinePaymentsDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-order-to-print")]
        public async Task<IActionResult> GetOrderToPrintAsync(Guid id)
        {
            var result = await _appService.GetOrderToPrintAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-preparation-change")]
        public async Task<IActionResult> GetPreparationChangeAsync(Guid id)
        {
            var result = await _appService.GetPreparationChangeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-reference-last-part")]
        public async Task<IActionResult> GetReferenceLastPartAsync(Guid id)
        {
            var result = await _appService.GetReferenceLastPartAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/print-event-badges")]
        public async Task<IActionResult> PrintEventBadgesAsync(Guid id)
        {
            var result = await _appService.PrintEventBadgesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/print-event-tickets")]
        public async Task<IActionResult> PrintEventTicketsAsync(Guid id)
        {
            var result = await _appService.PrintEventTicketsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/read-pos-data")]
        public async Task<IActionResult> ReadPosDataAsync(Guid id, [FromBody] PosOrderReadPosDataRequestDto input)
        {
            var result = await _appService.ReadPosDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/read-pos-data-uuid")]
        public async Task<IActionResult> ReadPosDataUuidAsync(Guid id, [FromBody] PosOrderReadPosDataUuidRequestDto input)
        {
            var result = await _appService.ReadPosDataUuidAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/read-pos-orders")]
        public async Task<IActionResult> ReadPosOrdersAsync(Guid id, [FromBody] PosOrderReadPosOrdersRequestDto input)
        {
            var result = await _appService.ReadPosOrdersAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/refund")]
        public async Task<IActionResult> RefundAsync(Guid id)
        {
            var result = await _appService.RefundAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-from-ui")]
        public async Task<IActionResult> RemoveFromUiAsync(Guid id, [FromBody] PosOrderRemoveFromUiRequestDto input)
        {
            var result = await _appService.RemoveFromUiAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-paid-order-ids")]
        public async Task<IActionResult> SearchPaidOrderIdsAsync(Guid id, [FromBody] PosOrderSearchPaidOrderIdsRequestDto input)
        {
            var result = await _appService.SearchPaidOrderIdsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/sync-from-ui")]
        public async Task<IActionResult> SyncFromUiAsync(Guid id, [FromBody] PosOrderSyncFromUiRequestDto input)
        {
            var result = await _appService.SyncFromUiAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/validate-coupon-programs")]
        public async Task<IActionResult> ValidateCouponProgramsAsync(Guid id, [FromBody] PosOrderValidateCouponProgramsRequestDto input)
        {
            var result = await _appService.ValidateCouponProgramsAsync(id, input);
            return Ok(result);
        }
    }
}