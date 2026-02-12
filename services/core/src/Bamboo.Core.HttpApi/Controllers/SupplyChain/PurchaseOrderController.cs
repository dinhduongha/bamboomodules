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
    [Route("api/v1/supply-chain/PurchaseOrder")]
    public partial class PurchaseOrderController : AbpController
    {
        protected readonly IPurchaseOrderAppService _appService;
        public PurchaseOrderController(IPurchaseOrderAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-acknowledge")]
        public async Task<IActionResult> AcknowledgeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AcknowledgeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> AddFromCatalogAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-bill-matching")]
        public async Task<IActionResult> BillMatchingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BillMatchingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-compare-alternative-lines")]
        public async Task<IActionResult> CompareAlternativeLinesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CompareAlternativeLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-alternative")]
        public async Task<IActionResult> CreateAlternativeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateAlternativeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-invoice")]
        public async Task<IActionResult> CreateInvoiceAsync([FromBody] PurchaseOrderCreateInvoiceRequestDto input)
        {
            var result = await _appService.CreateInvoiceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-merge")]
        public async Task<IActionResult> MergeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MergeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-business-doc")]
        public async Task<IActionResult> OpenBusinessDocAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenBusinessDocAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-purchase-comparison")]
        public async Task<IActionResult> PurchaseComparisonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PurchaseComparisonAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-purchase-order-suggest")]
        public async Task<IActionResult> PurchaseOrderSuggestAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PurchaseOrderSuggestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-rfq-send")]
        public async Task<IActionResult> RfqSendAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RfqSendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-dropship")]
        public async Task<IActionResult> ViewDropshipAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewDropshipAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-invoice")]
        public async Task<IActionResult> ViewInvoiceAsync([FromBody] PurchaseOrderViewInvoiceRequestDto input)
        {
            var result = await _appService.ViewInvoiceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-productions")]
        public async Task<IActionResult> ViewMrpProductionsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-picking")]
        public async Task<IActionResult> ViewPickingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-repair-orders")]
        public async Task<IActionResult> ViewRepairOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRepairOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-orders")]
        public async Task<IActionResult> ViewSaleOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSaleOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-subcontracting-resupply")]
        public async Task<IActionResult> ViewSubcontractingResupplyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSubcontractingResupplyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-approve")]
        public async Task<IActionResult> ButtonApproveAsync([FromBody] PurchaseOrderButtonApproveRequestDto input)
        {
            var result = await _appService.ButtonApproveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-cancel")]
        public async Task<IActionResult> ButtonCancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-confirm")]
        public async Task<IActionResult> ButtonConfirmAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-draft")]
        public async Task<IActionResult> ButtonDraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-lock")]
        public async Task<IActionResult> ButtonLockAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonLockAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-unlock")]
        public async Task<IActionResult> ButtonUnlockAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonUnlockAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-document-from-attachment")]
        public async Task<IActionResult> CreateDocumentFromAttachmentAsync([FromBody] PurchaseOrderCreateDocumentFromAttachmentRequestDto input)
        {
            var result = await _appService.CreateDocumentFromAttachmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-acknowledge-url")]
        public async Task<IActionResult> GetAcknowledgeUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAcknowledgeUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-confirm-url")]
        public async Task<IActionResult> GetConfirmUrlAsync([FromBody] PurchaseOrderGetConfirmUrlRequestDto input)
        {
            var result = await _appService.GetConfirmUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-localized-date-planned")]
        public async Task<IActionResult> GetLocalizedDatePlannedAsync([FromBody] PurchaseOrderGetLocalizedDatePlannedRequestDto input)
        {
            var result = await _appService.GetLocalizedDatePlannedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-order-timezone")]
        public async Task<IActionResult> GetOrderTimezoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetOrderTimezoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-report-matrixes")]
        public async Task<IActionResult> GetReportMatrixesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetReportMatrixesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-tender-best-lines")]
        public async Task<IActionResult> GetTenderBestLinesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetTenderBestLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-update-url")]
        public async Task<IActionResult> GetUpdateUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetUpdateUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-date-planned")]
        public async Task<IActionResult> OnchangeDatePlannedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeDatePlannedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-partner-id")]
        public async Task<IActionResult> OnchangePartnerIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangePartnerIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-picking-type-id")]
        public async Task<IActionResult> OnchangePickingTypeIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangePickingTypeIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-quotation")]
        public async Task<IActionResult> PrintQuotationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrintQuotationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("retrieve-dashboard")]
        public async Task<IActionResult> RetrieveDashboardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RetrieveDashboardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-reminder-preview")]
        public async Task<IActionResult> SendReminderPreviewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendReminderPreviewAsync(ids);
            return Ok(result);
        }
    }
    
}