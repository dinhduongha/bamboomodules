using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Purchase
{
    public partial class PurchaseOrderController
    {
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-bill-matching")]
        public async Task<IActionResult> ActionBillMatchingAsync(Guid id)
        {
            var result = await _appService.BillMatchingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-compare-alternative-lines")]
        public async Task<IActionResult> ActionCompareAlternativeLinesAsync(Guid id)
        {
            var result = await _appService.CompareAlternativeLinesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-alternative")]
        public async Task<IActionResult> ActionCreateAlternativeAsync(Guid id)
        {
            var result = await _appService.CreateAlternativeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-invoice")]
        public async Task<IActionResult> ActionCreateInvoiceAsync(Guid id)
        {
            var result = await _appService.CreateInvoiceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-merge")]
        public async Task<IActionResult> ActionMergeAsync(Guid id)
        {
            var result = await _appService.MergeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-rfq-send")]
        public async Task<IActionResult> ActionRfqSendAsync(Guid id)
        {
            var result = await _appService.RfqSendAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-dropship")]
        public async Task<IActionResult> ActionViewDropshipAsync(Guid id)
        {
            var result = await _appService.ViewDropshipAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-invoice")]
        public async Task<IActionResult> ActionViewInvoiceAsync(Guid id, [FromBody] PurchaseOrderViewInvoiceRequestDto input)
        {
            var result = await _appService.ViewInvoiceAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-productions")]
        public async Task<IActionResult> ActionViewMrpProductionsAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-picking")]
        public async Task<IActionResult> ActionViewPickingAsync(Guid id)
        {
            var result = await _appService.ViewPickingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-repair-orders")]
        public async Task<IActionResult> ActionViewRepairOrdersAsync(Guid id)
        {
            var result = await _appService.ViewRepairOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sale-orders")]
        public async Task<IActionResult> ActionViewSaleOrdersAsync(Guid id)
        {
            var result = await _appService.ViewSaleOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-subcontracting-resupply")]
        public async Task<IActionResult> ActionViewSubcontractingResupplyAsync(Guid id)
        {
            var result = await _appService.ViewSubcontractingResupplyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-approve")]
        public async Task<IActionResult> ButtonApproveAsync(Guid id, [FromBody] PurchaseOrderButtonApproveRequestDto input)
        {
            var result = await _appService.ButtonApproveAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-cancel")]
        public async Task<IActionResult> ButtonCancelAsync(Guid id)
        {
            var result = await _appService.ButtonCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-confirm")]
        public async Task<IActionResult> ButtonConfirmAsync(Guid id)
        {
            var result = await _appService.ButtonConfirmAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-done")]
        public async Task<IActionResult> ButtonDoneAsync(Guid id)
        {
            var result = await _appService.ButtonDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-draft")]
        public async Task<IActionResult> ButtonDraftAsync(Guid id)
        {
            var result = await _appService.ButtonDraftAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-unlock")]
        public async Task<IActionResult> ButtonUnlockAsync(Guid id)
        {
            var result = await _appService.ButtonUnlockAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/confirm-reminder-mail")]
        public async Task<IActionResult> ConfirmReminderMailAsync(Guid id, [FromBody] PurchaseOrderConfirmReminderMailRequestDto input)
        {
            var result = await _appService.ConfirmReminderMailAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-confirm-url")]
        public async Task<IActionResult> GetConfirmUrlAsync(Guid id, [FromBody] PurchaseOrderGetConfirmUrlRequestDto input)
        {
            var result = await _appService.GetConfirmUrlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-localized-date-planned")]
        public async Task<IActionResult> GetLocalizedDatePlannedAsync(Guid id, [FromBody] PurchaseOrderGetLocalizedDatePlannedRequestDto input)
        {
            var result = await _appService.GetLocalizedDatePlannedAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-order-timezone")]
        public async Task<IActionResult> GetOrderTimezoneAsync(Guid id)
        {
            var result = await _appService.GetOrderTimezoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-report-matrixes")]
        public async Task<IActionResult> GetReportMatrixesAsync(Guid id)
        {
            var result = await _appService.GetReportMatrixesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-tender-best-lines")]
        public async Task<IActionResult> GetTenderBestLinesAsync(Guid id)
        {
            var result = await _appService.GetTenderBestLinesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-update-url")]
        public async Task<IActionResult> GetUpdateUrlAsync(Guid id)
        {
            var result = await _appService.GetUpdateUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid id)
        {
            var result = await _appService.MessagePostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-date-planned")]
        public async Task<IActionResult> OnchangeDatePlannedAsync(Guid id)
        {
            var result = await _appService.OnchangeDatePlannedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-partner-id")]
        public async Task<IActionResult> OnchangePartnerIdAsync(Guid id)
        {
            var result = await _appService.OnchangePartnerIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-partner-id-warning")]
        public async Task<IActionResult> OnchangePartnerIdWarningAsync(Guid id)
        {
            var result = await _appService.OnchangePartnerIdWarningAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-picking-type-id")]
        public async Task<IActionResult> OnchangePickingTypeIdAsync(Guid id)
        {
            var result = await _appService.OnchangePickingTypeIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/print-quotation")]
        public async Task<IActionResult> PrintQuotationAsync(Guid id)
        {
            var result = await _appService.PrintQuotationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/retrieve-dashboard")]
        public async Task<IActionResult> RetrieveDashboardAsync(Guid id)
        {
            var result = await _appService.RetrieveDashboardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-reminder-preview")]
        public async Task<IActionResult> SendReminderPreviewAsync(Guid id)
        {
            var result = await _appService.SendReminderPreviewAsync(id);
            return Ok(result);
        }
    }
}