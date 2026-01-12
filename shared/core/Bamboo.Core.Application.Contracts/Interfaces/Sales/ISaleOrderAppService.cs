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
    public interface ISaleOrderAppService : IGenericApplicationService<SaleOrder>
    {
        Task<SaleOrder> CancelAsync(Guid id);
        Task<SaleOrder> ConfirmAsync(Guid id);
        Task<SaleOrder> CopyDataAsync(Guid id, SaleOrderCopyDataRequestDto input);
        Task<SaleOrder> CreateDocumentFromAttachmentAsync(Guid id, SaleOrderCreateDocumentFromAttachmentRequestDto input);
        Task<SaleOrder> CreateProjectAsync(Guid id);
        Task<SaleOrder> DraftAsync(Guid id);
        Task<SaleOrder> GetEmptyListHelpAsync(Guid id, SaleOrderGetEmptyListHelpRequestDto input);
        Task<SaleOrder> GetPortalLastTransactionAsync(Guid id);
        Task<SaleOrder> GetPromoCodeErrorAsync(Guid id, SaleOrderGetPromoCodeErrorRequestDto input);
        Task<SaleOrder> GetPromoCodeSuccessMessageAsync(Guid id, SaleOrderGetPromoCodeSuccessMessageRequestDto input);
        Task<SaleOrder> GetReportMatrixesAsync(Guid id);
        Task<SaleOrder> GetUpdateIncludedPdfParamsAsync(Guid id);
        Task<SaleOrder> InitAsync(Guid id);
        Task<SaleOrder> LockAsync(Guid id);
        Task<SaleOrder> MessagePostAsync(Guid id);
        Task<SaleOrder> OnchangeOrderLineAsync(Guid id);
        Task<SaleOrder> OpenBusinessDocAsync(Guid id);
        Task<SaleOrder> OpenDeliveryWizardAsync(Guid id);
        Task<SaleOrder> OpenDiscountWizardAsync(Guid id);
        Task<SaleOrder> OpenRewardWizardAsync(Guid id);
        Task<SaleOrder> PaymentCaptureAsync(Guid id);
        Task<SaleOrder> PaymentVoidAsync(Guid id);
        Task<SaleOrder> PreviewSaleOrderAsync(Guid id);
        Task<SaleOrder> QuotationSendAsync(Guid id);
        Task<SaleOrder> QuotationSentAsync(Guid id);
        Task<SaleOrder> RecoveryEmailSendAsync(Guid id);
        Task<SaleOrder> SaveIncludedPdfAsync(Guid id, SaleOrderSaveIncludedPdfRequestDto input);
        Task<SaleOrder> SaveNewCustomContentAsync(Guid id, SaleOrderSaveNewCustomContentRequestDto input);
        Task<SaleOrder> SetDeliveryLineAsync(Guid id, SaleOrderSetDeliveryLineRequestDto input);
        Task<SaleOrder> ShowRepairAsync(Guid id);
        Task<SaleOrder> UnlockAsync(Guid id);
        Task<SaleOrder> UpdatePricesAsync(Guid id);
        Task<SaleOrder> UpdateTaxesAsync(Guid id);
        Task<SaleOrder> ViewAttendeeListAsync(Guid id);
        Task<SaleOrder> ViewBoothListAsync(Guid id);
        Task<SaleOrder> ViewDeliveryAsync(Guid id);
        Task<SaleOrder> ViewDropshipAsync(Guid id);
        Task<SaleOrder> ViewInvoiceAsync(Guid id, SaleOrderViewInvoiceRequestDto input);
        Task<SaleOrder> ViewMilestoneAsync(Guid id);
        Task<SaleOrder> ViewMrpProductionAsync(Guid id);
        Task<SaleOrder> ViewPosOrderAsync(Guid id);
        Task<SaleOrder> ViewProjectIdsAsync(Guid id);
        Task<SaleOrder> ViewPurchaseOrdersAsync(Guid id);
        Task<SaleOrder> ViewTaskAsync(Guid id);
        Task<SaleOrder> ViewTimesheetAsync(Guid id);
    }
}