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
    public interface IPurchaseOrderAppService : IGenericApplicationService<PurchaseOrder>
    {
        Task<PurchaseOrder> AcknowledgeAsync(Guid[] ids);
        Task<PurchaseOrder> AddFromCatalogAsync(Guid[] ids);
        Task<PurchaseOrder> BillMatchingAsync(Guid[] ids);
        Task<PurchaseOrder> ButtonApproveAsync(PurchaseOrderButtonApproveRequestDto input);
        Task<PurchaseOrder> ButtonCancelAsync(Guid[] ids);
        Task<PurchaseOrder> ButtonConfirmAsync(Guid[] ids);
        Task<PurchaseOrder> ButtonDraftAsync(Guid[] ids);
        Task<PurchaseOrder> ButtonLockAsync(Guid[] ids);
        Task<PurchaseOrder> ButtonUnlockAsync(Guid[] ids);
        Task<PurchaseOrder> CompareAlternativeLinesAsync(Guid[] ids);
        Task<PurchaseOrder> CreateAlternativeAsync(Guid[] ids);
        Task<PurchaseOrder> CreateDocumentFromAttachmentAsync(PurchaseOrderCreateDocumentFromAttachmentRequestDto input);
        Task<PurchaseOrder> CreateInvoiceAsync(PurchaseOrderCreateInvoiceRequestDto input);
        Task<PurchaseOrder> GetAcknowledgeUrlAsync(Guid[] ids);
        Task<PurchaseOrder> GetConfirmUrlAsync(PurchaseOrderGetConfirmUrlRequestDto input);
        Task<PurchaseOrder> GetImportTemplatesAsync(Guid[] ids);
        Task<PurchaseOrder> GetLocalizedDatePlannedAsync(PurchaseOrderGetLocalizedDatePlannedRequestDto input);
        Task<PurchaseOrder> GetOrderTimezoneAsync(Guid[] ids);
        Task<PurchaseOrder> GetReportMatrixesAsync(Guid[] ids);
        Task<PurchaseOrder> GetTenderBestLinesAsync(Guid[] ids);
        Task<PurchaseOrder> GetUpdateUrlAsync(Guid[] ids);
        Task<PurchaseOrder> MergeAsync(Guid[] ids);
        Task<PurchaseOrder> MessagePostAsync(Guid[] ids);
        Task<PurchaseOrder> OnchangeDatePlannedAsync(Guid[] ids);
        Task<PurchaseOrder> OnchangePartnerIdAsync(Guid[] ids);
        Task<PurchaseOrder> OnchangePickingTypeIdAsync(Guid[] ids);
        Task<PurchaseOrder> OpenBusinessDocAsync(Guid[] ids);
        Task<PurchaseOrder> PrintQuotationAsync(Guid[] ids);
        Task<PurchaseOrder> PurchaseComparisonAsync(Guid[] ids);
        Task<PurchaseOrder> PurchaseOrderSuggestAsync(Guid[] ids);
        Task<PurchaseOrder> RetrieveDashboardAsync(Guid[] ids);
        Task<PurchaseOrder> RfqSendAsync(Guid[] ids);
        Task<PurchaseOrder> SendReminderPreviewAsync(Guid[] ids);
        Task<PurchaseOrder> ViewDropshipAsync(Guid[] ids);
        Task<PurchaseOrder> ViewInvoiceAsync(PurchaseOrderViewInvoiceRequestDto input);
        Task<PurchaseOrder> ViewMrpProductionsAsync(Guid[] ids);
        Task<PurchaseOrder> ViewPickingAsync(Guid[] ids);
        Task<PurchaseOrder> ViewRepairOrdersAsync(Guid[] ids);
        Task<PurchaseOrder> ViewSaleOrdersAsync(Guid[] ids);
        Task<PurchaseOrder> ViewSubcontractingResupplyAsync(Guid[] ids);
    }
}