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
        [Route("action-create-invoices")]
        public async Task<IActionResult> ActionCreateInvoicesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateInvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-order-cancel")]
        public async Task<IActionResult> ActionPosOrderCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PosOrderCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-order-invoice")]
        public async Task<IActionResult> ActionPosOrderInvoiceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PosOrderInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pos-order-paid")]
        public async Task<IActionResult> ActionPosOrderPaidAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PosOrderPaidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mail")]
        public async Task<IActionResult> ActionSendMailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendMailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-receipt")]
        public async Task<IActionResult> ActionSendReceiptAsync(PosOrderSendReceiptRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendReceiptAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-self-order-receipt")]
        public async Task<IActionResult> ActionSendSelfOrderReceiptAsync(PosOrderSendSelfOrderReceiptRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendSelfOrderReceiptAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sent-message-on-sms")]
        public async Task<IActionResult> ActionSentMessageOnSmsAsync(PosOrderSentMessageOnSmsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SentMessageOnSmsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stock-picking")]
        public async Task<IActionResult> ActionStockPickingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StockPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-attendee-list")]
        public async Task<IActionResult> ActionViewAttendeeListAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewAttendeeListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-invoice")]
        public async Task<IActionResult> ActionViewInvoiceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-refund-orders")]
        public async Task<IActionResult> ActionViewRefundOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRefundOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-refunded-order")]
        public async Task<IActionResult> ActionViewRefundedOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRefundedOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-loyalty-history-lines")]
        public async Task<IActionResult> AddLoyaltyHistoryLinesAsync(PosOrderAddLoyaltyHistoryLinesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AddLoyaltyHistoryLinesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-payment")]
        public async Task<IActionResult> AddPaymentAsync(PosOrderAddPaymentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AddPaymentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("confirm-coupon-programs")]
        public async Task<IActionResult> ConfirmCouponProgramsAsync(PosOrderConfirmCouponProgramsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConfirmCouponProgramsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-amount-unpaid")]
        public async Task<IActionResult> GetAmountUnpaidAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAmountUnpaidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-and-set-online-payments-data")]
        public async Task<IActionResult> GetAndSetOnlinePaymentsDataAsync(PosOrderGetAndSetOnlinePaymentsDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAndSetOnlinePaymentsDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-order-to-print")]
        public async Task<IActionResult> GetOrderToPrintAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetOrderToPrintAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-preparation-change")]
        public async Task<IActionResult> GetPreparationChangeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPreparationChangeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-reference-last-part")]
        public async Task<IActionResult> GetReferenceLastPartAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetReferenceLastPartAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-event-badges")]
        public async Task<IActionResult> PrintEventBadgesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrintEventBadgesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-event-tickets")]
        public async Task<IActionResult> PrintEventTicketsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrintEventTicketsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("read-pos-data")]
        public async Task<IActionResult> ReadPosDataAsync(PosOrderReadPosDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ReadPosDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("read-pos-data-uuid")]
        public async Task<IActionResult> ReadPosDataUuidAsync(PosOrderReadPosDataUuidRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ReadPosDataUuidAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("read-pos-orders")]
        public async Task<IActionResult> ReadPosOrdersAsync(PosOrderReadPosOrdersRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ReadPosOrdersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("refund")]
        public async Task<IActionResult> RefundAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefundAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("remove-from-ui")]
        public async Task<IActionResult> RemoveFromUiAsync(PosOrderRemoveFromUiRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RemoveFromUiAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-paid-order-ids")]
        public async Task<IActionResult> SearchPaidOrderIdsAsync(PosOrderSearchPaidOrderIdsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SearchPaidOrderIdsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("sync-from-ui")]
        public async Task<IActionResult> SyncFromUiAsync(PosOrderSyncFromUiRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SyncFromUiAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate-coupon-programs")]
        public async Task<IActionResult> ValidateCouponProgramsAsync(PosOrderValidateCouponProgramsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ValidateCouponProgramsAsync(input);
            return Ok(result);
        }
    }
}