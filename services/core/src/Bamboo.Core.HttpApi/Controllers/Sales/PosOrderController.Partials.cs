using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.PointOfSale
{
    public partial class PosOrderController
    {
        
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
        [Route("{id}/send-table-count-notification")]
        public async Task<IActionResult> SendTableCountNotificationAsync(Guid id, [FromBody] PosOrderSendTableCountNotificationRequestDto input)
        {
            var result = await _appService.SendTableCountNotificationAsync(id, input);
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