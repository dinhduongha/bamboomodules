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
        Task<PosOrder> AddLoyaltyHistoryLinesAsync(Guid id, PosOrderAddLoyaltyHistoryLinesRequestDto input);
        Task<PosOrder> AddPaymentAsync(Guid id, PosOrderAddPaymentRequestDto input);
        Task<PosOrder> ConfirmCouponProgramsAsync(Guid id, PosOrderConfirmCouponProgramsRequestDto input);
        Task<PosOrder> CreateInvoicesAsync(Guid id);
        Task<PosOrder> GetAmountUnpaidAsync(Guid id);
        Task<PosOrder> GetAndSetOnlinePaymentsDataAsync(Guid id, PosOrderGetAndSetOnlinePaymentsDataRequestDto input);
        Task<PosOrder> GetOrderToPrintAsync(Guid id);
        Task<PosOrder> GetPreparationChangeAsync(Guid id);
        Task<PosOrder> GetReferenceLastPartAsync(Guid id);
        Task<PosOrder> PosOrderCancelAsync(Guid id);
        Task<PosOrder> PosOrderInvoiceAsync(Guid id);
        Task<PosOrder> PosOrderPaidAsync(Guid id);
        Task<PosOrder> PrintEventBadgesAsync(Guid id);
        Task<PosOrder> PrintEventTicketsAsync(Guid id);
        Task<PosOrder> ReadPosDataAsync(Guid id, PosOrderReadPosDataRequestDto input);
        Task<PosOrder> ReadPosDataUuidAsync(Guid id, PosOrderReadPosDataUuidRequestDto input);
        Task<PosOrder> ReadPosOrdersAsync(Guid id, PosOrderReadPosOrdersRequestDto input);
        Task<PosOrder> RefundAsync(Guid id);
        Task<PosOrder> RemoveFromUiAsync(Guid id, PosOrderRemoveFromUiRequestDto input);
        Task<PosOrder> SearchPaidOrderIdsAsync(Guid id, PosOrderSearchPaidOrderIdsRequestDto input);
        Task<PosOrder> SendMailAsync(Guid id);
        Task<PosOrder> SendReceiptAsync(Guid id, PosOrderSendReceiptRequestDto input);
        Task<PosOrder> SendSelfOrderReceiptAsync(Guid id, PosOrderSendSelfOrderReceiptRequestDto input);
        Task<PosOrder> SentMessageOnSmsAsync(Guid id, PosOrderSentMessageOnSmsRequestDto input);
        Task<PosOrder> StockPickingAsync(Guid id);
        Task<PosOrder> SyncFromUiAsync(Guid id, PosOrderSyncFromUiRequestDto input);
        Task<PosOrder> ValidateCouponProgramsAsync(Guid id, PosOrderValidateCouponProgramsRequestDto input);
        Task<PosOrder> ViewAttendeeListAsync(Guid id);
        Task<PosOrder> ViewInvoiceAsync(Guid id);
        Task<PosOrder> ViewRefundOrdersAsync(Guid id);
        Task<PosOrder> ViewRefundedOrderAsync(Guid id);
        Task<PosOrder> ViewSaleOrderAsync(Guid id);
    }
}