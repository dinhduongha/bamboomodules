using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IPosOrderAppService : IGenericApplicationService<PosOrder>
    {
        Task<PosOrder> AddLoyaltyHistoryLinesAsync(PosOrderAddLoyaltyHistoryLinesRequestDto input);
        Task<PosOrder> AddPaymentAsync(PosOrderAddPaymentRequestDto input);
        Task<PosOrder> ConfirmCouponProgramsAsync(PosOrderConfirmCouponProgramsRequestDto input);
        Task<PosOrder> CreateInvoicesAsync(Guid[] ids);
        Task<PosOrder> GetAmountUnpaidAsync(Guid[] ids);
        Task<PosOrder> GetAndSetOnlinePaymentsDataAsync(PosOrderGetAndSetOnlinePaymentsDataRequestDto input);
        Task<PosOrder> GetOrderToPrintAsync(Guid[] ids);
        Task<PosOrder> GetPreparationChangeAsync(Guid[] ids);
        Task<PosOrder> GetReferenceLastPartAsync(Guid[] ids);
        Task<PosOrder> PosOrderCancelAsync(Guid[] ids);
        Task<PosOrder> PosOrderInvoiceAsync(Guid[] ids);
        Task<PosOrder> PosOrderPaidAsync(Guid[] ids);
        Task<PosOrder> PrintEventBadgesAsync(Guid[] ids);
        Task<PosOrder> PrintEventTicketsAsync(Guid[] ids);
        Task<PosOrder> ReadPosDataAsync(PosOrderReadPosDataRequestDto input);
        Task<PosOrder> ReadPosDataUuidAsync(PosOrderReadPosDataUuidRequestDto input);
        Task<PosOrder> ReadPosOrdersAsync(PosOrderReadPosOrdersRequestDto input);
        Task<PosOrder> RefundAsync(Guid[] ids);
        Task<PosOrder> RemoveFromUiAsync(PosOrderRemoveFromUiRequestDto input);
        Task<PosOrder> SearchPaidOrderIdsAsync(PosOrderSearchPaidOrderIdsRequestDto input);
        Task<PosOrder> SendMailAsync(Guid[] ids);
        Task<PosOrder> SendReceiptAsync(PosOrderSendReceiptRequestDto input);
        Task<PosOrder> SendSelfOrderReceiptAsync(PosOrderSendSelfOrderReceiptRequestDto input);
        Task<PosOrder> SentMessageOnSmsAsync(PosOrderSentMessageOnSmsRequestDto input);
        Task<PosOrder> StockPickingAsync(Guid[] ids);
        Task<PosOrder> SyncFromUiAsync(PosOrderSyncFromUiRequestDto input);
        Task<PosOrder> ValidateCouponProgramsAsync(PosOrderValidateCouponProgramsRequestDto input);
        Task<PosOrder> ViewAttendeeListAsync(Guid[] ids);
        Task<PosOrder> ViewInvoiceAsync(Guid[] ids);
        Task<PosOrder> ViewRefundOrdersAsync(Guid[] ids);
        Task<PosOrder> ViewRefundedOrderAsync(Guid[] ids);
        Task<PosOrder> ViewSaleOrderAsync(Guid[] ids);
    }
}