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
    public interface ISaleOrderAppService : IGenericAppService<SaleOrder>
    {
        Task<SaleOrder> CancelAsync(Guid[] ids);
        Task<SaleOrder> ConfirmAsync(Guid[] ids);
        Task<SaleOrder> CopyDataAsync(SaleOrderCopyDataRequestDto input);
        Task<SaleOrder> CreateDocumentFromAttachmentAsync(SaleOrderCreateDocumentFromAttachmentRequestDto input);
        Task<SaleOrder> CreateProjectAsync(Guid[] ids);
        Task<SaleOrder> DraftAsync(Guid[] ids);
        Task<SaleOrder> GetEmptyListHelpAsync(SaleOrderGetEmptyListHelpRequestDto input);
        Task<SaleOrder> GetFirstServiceLineAsync(Guid[] ids);
        Task<SaleOrder> GetImportTemplatesAsync(Guid[] ids);
        Task<SaleOrder> GetPortalLastTransactionAsync(Guid[] ids);
        Task<SaleOrder> GetPromoCodeErrorAsync(SaleOrderGetPromoCodeErrorRequestDto input);
        Task<SaleOrder> GetPromoCodeSuccessMessageAsync(SaleOrderGetPromoCodeSuccessMessageRequestDto input);
        Task<SaleOrder> GetReportMatrixesAsync(Guid[] ids);
        Task<SaleOrder> GetUpdateIncludedPdfParamsAsync(Guid[] ids);
        Task<SaleOrder> LoadSaleOrderFromPosAsync(SaleOrderLoadSaleOrderFromPosRequestDto input);
        Task<SaleOrder> LockAsync(Guid[] ids);
        Task<SaleOrder> MessagePostAsync(Guid[] ids);
        Task<SaleOrder> OnchangeOrderLineAsync(Guid[] ids);
        Task<SaleOrder> OpenBusinessDocAsync(Guid[] ids);
        Task<SaleOrder> OpenDeliveryWizardAsync(Guid[] ids);
        Task<SaleOrder> OpenDiscountWizardAsync(Guid[] ids);
        Task<SaleOrder> OpenRewardWizardAsync(Guid[] ids);
        Task<SaleOrder> PaymentCaptureAsync(Guid[] ids);
        Task<SaleOrder> PaymentVoidAsync(Guid[] ids);
        Task<SaleOrder> PreviewSaleOrderAsync(Guid[] ids);
        Task<SaleOrder> QuotationSendAsync(Guid[] ids);
        Task<SaleOrder> QuotationSentAsync(Guid[] ids);
        Task<SaleOrder> RecoveryEmailSendAsync(Guid[] ids);
        Task<SaleOrder> SetDeliveryLineAsync(SaleOrderSetDeliveryLineRequestDto input);
        Task<SaleOrder> ShowRepairAsync(Guid[] ids);
        Task<SaleOrder> UnlockAsync(Guid[] ids);
        Task<SaleOrder> UpdatePricesAsync(Guid[] ids);
        Task<SaleOrder> UpdateTaxesAsync(Guid[] ids);
        Task<SaleOrder> ViewAttendeeListAsync(Guid[] ids);
        Task<SaleOrder> ViewBoothListAsync(Guid[] ids);
        Task<SaleOrder> ViewDeliveryAsync(Guid[] ids);
        Task<SaleOrder> ViewDropshipAsync(Guid[] ids);
        Task<SaleOrder> ViewGiftCardsAsync(Guid[] ids);
        Task<SaleOrder> ViewInvoiceAsync(SaleOrderViewInvoiceRequestDto input);
        Task<SaleOrder> ViewMilestoneAsync(Guid[] ids);
        Task<SaleOrder> ViewMrpProductionAsync(Guid[] ids);
        Task<SaleOrder> ViewPosOrderAsync(Guid[] ids);
        Task<SaleOrder> ViewProjectIdsAsync(Guid[] ids);
        Task<SaleOrder> ViewPurchaseOrdersAsync(Guid[] ids);
        Task<SaleOrder> ViewTimesheetAsync(Guid[] ids);
    }
}