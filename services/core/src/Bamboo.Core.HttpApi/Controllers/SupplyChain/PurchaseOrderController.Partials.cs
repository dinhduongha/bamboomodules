using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PurchaseOrderController
    {
        
        [HttpPost]
        [Route("action-acknowledge")]
        public async Task<IActionResult> ActionAcknowledgeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AcknowledgeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-bill-matching")]
        public async Task<IActionResult> ActionBillMatchingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BillMatchingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-compare-alternative-lines")]
        public async Task<IActionResult> ActionCompareAlternativeLinesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CompareAlternativeLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-alternative")]
        public async Task<IActionResult> ActionCreateAlternativeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateAlternativeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-invoice")]
        public async Task<IActionResult> ActionCreateInvoiceAsync(PurchaseOrderCreateInvoiceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateInvoiceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-merge")]
        public async Task<IActionResult> ActionMergeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MergeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-business-doc")]
        public async Task<IActionResult> ActionOpenBusinessDocAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenBusinessDocAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-purchase-comparison")]
        public async Task<IActionResult> ActionPurchaseComparisonAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PurchaseComparisonAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-purchase-order-suggest")]
        public async Task<IActionResult> ActionPurchaseOrderSuggestAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PurchaseOrderSuggestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-rfq-send")]
        public async Task<IActionResult> ActionRfqSendAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RfqSendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-dropship")]
        public async Task<IActionResult> ActionViewDropshipAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewDropshipAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-invoice")]
        public async Task<IActionResult> ActionViewInvoiceAsync(PurchaseOrderViewInvoiceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ViewInvoiceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-productions")]
        public async Task<IActionResult> ActionViewMrpProductionsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpProductionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-picking")]
        public async Task<IActionResult> ActionViewPickingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-repair-orders")]
        public async Task<IActionResult> ActionViewRepairOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRepairOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-orders")]
        public async Task<IActionResult> ActionViewSaleOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSaleOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-subcontracting-resupply")]
        public async Task<IActionResult> ActionViewSubcontractingResupplyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSubcontractingResupplyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-approve")]
        public async Task<IActionResult> ButtonApproveAsync(PurchaseOrderButtonApproveRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ButtonApproveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-cancel")]
        public async Task<IActionResult> ButtonCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-confirm")]
        public async Task<IActionResult> ButtonConfirmAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-draft")]
        public async Task<IActionResult> ButtonDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-lock")]
        public async Task<IActionResult> ButtonLockAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonLockAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-unlock")]
        public async Task<IActionResult> ButtonUnlockAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonUnlockAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-document-from-attachment")]
        public async Task<IActionResult> CreateDocumentFromAttachmentAsync(PurchaseOrderCreateDocumentFromAttachmentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateDocumentFromAttachmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-acknowledge-url")]
        public async Task<IActionResult> GetAcknowledgeUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAcknowledgeUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-confirm-url")]
        public async Task<IActionResult> GetConfirmUrlAsync(PurchaseOrderGetConfirmUrlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetConfirmUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-localized-date-planned")]
        public async Task<IActionResult> GetLocalizedDatePlannedAsync(PurchaseOrderGetLocalizedDatePlannedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetLocalizedDatePlannedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-order-timezone")]
        public async Task<IActionResult> GetOrderTimezoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetOrderTimezoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-report-matrixes")]
        public async Task<IActionResult> GetReportMatrixesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetReportMatrixesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-tender-best-lines")]
        public async Task<IActionResult> GetTenderBestLinesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetTenderBestLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-update-url")]
        public async Task<IActionResult> GetUpdateUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetUpdateUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-date-planned")]
        public async Task<IActionResult> OnchangeDatePlannedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeDatePlannedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-partner-id")]
        public async Task<IActionResult> OnchangePartnerIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangePartnerIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-picking-type-id")]
        public async Task<IActionResult> OnchangePickingTypeIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangePickingTypeIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-quotation")]
        public async Task<IActionResult> PrintQuotationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrintQuotationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("retrieve-dashboard")]
        public async Task<IActionResult> RetrieveDashboardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RetrieveDashboardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-reminder-preview")]
        public async Task<IActionResult> SendReminderPreviewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendReminderPreviewAsync(ids);
            return Ok(result);
        }
    }
}