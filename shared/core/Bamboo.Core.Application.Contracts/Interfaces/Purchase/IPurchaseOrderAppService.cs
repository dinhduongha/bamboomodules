using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IPurchaseOrderAppService : IGenericApplicationService<PurchaseOrder>
    {
        Task<PurchaseOrder> AddFromCatalogAsync(Guid id);
        Task<PurchaseOrder> BillMatchingAsync(Guid id);
        Task<PurchaseOrder> ButtonApproveAsync(Guid id, PurchaseOrderButtonApproveRequestDto input);
        Task<PurchaseOrder> ButtonCancelAsync(Guid id);
        Task<PurchaseOrder> ButtonConfirmAsync(Guid id);
        Task<PurchaseOrder> ButtonDoneAsync(Guid id);
        Task<PurchaseOrder> ButtonDraftAsync(Guid id);
        Task<PurchaseOrder> ButtonUnlockAsync(Guid id);
        Task<PurchaseOrder> CompareAlternativeLinesAsync(Guid id);
        Task<PurchaseOrder> ConfirmReminderMailAsync(Guid id, PurchaseOrderConfirmReminderMailRequestDto input);
        Task<PurchaseOrder> CreateAlternativeAsync(Guid id);
        Task<PurchaseOrder> CreateInvoiceAsync(Guid id);
        Task<PurchaseOrder> GetConfirmUrlAsync(Guid id, PurchaseOrderGetConfirmUrlRequestDto input);
        Task<PurchaseOrder> GetLocalizedDatePlannedAsync(Guid id, PurchaseOrderGetLocalizedDatePlannedRequestDto input);
        Task<PurchaseOrder> GetOrderTimezoneAsync(Guid id);
        Task<PurchaseOrder> GetReportMatrixesAsync(Guid id);
        Task<PurchaseOrder> GetTenderBestLinesAsync(Guid id);
        Task<PurchaseOrder> GetUpdateUrlAsync(Guid id);
        Task<PurchaseOrder> MergeAsync(Guid id);
        Task<PurchaseOrder> MessagePostAsync(Guid id);
        Task<PurchaseOrder> OnchangeDatePlannedAsync(Guid id);
        Task<PurchaseOrder> OnchangePartnerIdAsync(Guid id);
        Task<PurchaseOrder> OnchangePartnerIdWarningAsync(Guid id);
        Task<PurchaseOrder> OnchangePickingTypeIdAsync(Guid id);
        Task<PurchaseOrder> PrintQuotationAsync(Guid id);
        Task<PurchaseOrder> RetrieveDashboardAsync(Guid id);
        Task<PurchaseOrder> RfqSendAsync(Guid id);
        Task<PurchaseOrder> SendReminderPreviewAsync(Guid id);
        Task<PurchaseOrder> ViewDropshipAsync(Guid id);
        Task<PurchaseOrder> ViewInvoiceAsync(Guid id, PurchaseOrderViewInvoiceRequestDto input);
        Task<PurchaseOrder> ViewMrpProductionsAsync(Guid id);
        Task<PurchaseOrder> ViewPickingAsync(Guid id);
        Task<PurchaseOrder> ViewRepairOrdersAsync(Guid id);
        Task<PurchaseOrder> ViewSaleOrdersAsync(Guid id);
        Task<PurchaseOrder> ViewSubcontractingResupplyAsync(Guid id);
    }
}