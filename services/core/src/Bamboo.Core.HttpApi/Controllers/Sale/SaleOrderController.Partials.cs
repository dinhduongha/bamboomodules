using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Sale
{
    public partial class SaleOrderController
    {
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid id)
        {
            var result = await _appService.ConfirmAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-project")]
        public async Task<IActionResult> ActionCreateProjectAsync(Guid id)
        {
            var result = await _appService.CreateProjectAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-draft")]
        public async Task<IActionResult> ActionDraftAsync(Guid id)
        {
            var result = await _appService.DraftAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-lock")]
        public async Task<IActionResult> ActionLockAsync(Guid id)
        {
            var result = await _appService.LockAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-business-doc")]
        public async Task<IActionResult> ActionOpenBusinessDocAsync(Guid id)
        {
            var result = await _appService.OpenBusinessDocAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-declaration-of-intent")]
        public async Task<IActionResult> ActionOpenDeclarationOfIntentAsync(Guid id)
        {
            var result = await _appService.OpenDeclarationOfIntentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-delivery-wizard")]
        public async Task<IActionResult> ActionOpenDeliveryWizardAsync(Guid id)
        {
            var result = await _appService.OpenDeliveryWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-discount-wizard")]
        public async Task<IActionResult> ActionOpenDiscountWizardAsync(Guid id)
        {
            var result = await _appService.OpenDiscountWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-reward-wizard")]
        public async Task<IActionResult> ActionOpenRewardWizardAsync(Guid id)
        {
            var result = await _appService.OpenRewardWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-preview-sale-order")]
        public async Task<IActionResult> ActionPreviewSaleOrderAsync(Guid id)
        {
            var result = await _appService.PreviewSaleOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-quotation-send")]
        public async Task<IActionResult> ActionQuotationSendAsync(Guid id)
        {
            var result = await _appService.QuotationSendAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-quotation-sent")]
        public async Task<IActionResult> ActionQuotationSentAsync(Guid id)
        {
            var result = await _appService.QuotationSentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-recovery-email-send")]
        public async Task<IActionResult> ActionRecoveryEmailSendAsync(Guid id)
        {
            var result = await _appService.RecoveryEmailSendAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-repair")]
        public async Task<IActionResult> ActionShowRepairAsync(Guid id)
        {
            var result = await _appService.ShowRepairAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unlock")]
        public async Task<IActionResult> ActionUnlockAsync(Guid id)
        {
            var result = await _appService.UnlockAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-update-prices")]
        public async Task<IActionResult> ActionUpdatePricesAsync(Guid id)
        {
            var result = await _appService.UpdatePricesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-update-taxes")]
        public async Task<IActionResult> ActionUpdateTaxesAsync(Guid id)
        {
            var result = await _appService.UpdateTaxesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-attendee-list")]
        public async Task<IActionResult> ActionViewAttendeeListAsync(Guid id)
        {
            var result = await _appService.ViewAttendeeListAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-booth-list")]
        public async Task<IActionResult> ActionViewBoothListAsync(Guid id)
        {
            var result = await _appService.ViewBoothListAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-delivery")]
        public async Task<IActionResult> ActionViewDeliveryAsync(Guid id)
        {
            var result = await _appService.ViewDeliveryAsync(id);
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
        public async Task<IActionResult> ActionViewInvoiceAsync(Guid id, [FromBody] SaleOrderViewInvoiceRequestDto input)
        {
            var result = await _appService.ViewInvoiceAsync(id, input.Invoices);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-milestone")]
        public async Task<IActionResult> ActionViewMilestoneAsync(Guid id)
        {
            var result = await _appService.ViewMilestoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-production")]
        public async Task<IActionResult> ActionViewMrpProductionAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-pos-order")]
        public async Task<IActionResult> ActionViewPosOrderAsync(Guid id)
        {
            var result = await _appService.ViewPosOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-project-ids")]
        public async Task<IActionResult> ActionViewProjectIdsAsync(Guid id)
        {
            var result = await _appService.ViewProjectIdsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-purchase-orders")]
        public async Task<IActionResult> ActionViewPurchaseOrdersAsync(Guid id)
        {
            var result = await _appService.ViewPurchaseOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-task")]
        public async Task<IActionResult> ActionViewTaskAsync(Guid id)
        {
            var result = await _appService.ViewTaskAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-timesheet")]
        public async Task<IActionResult> ActionViewTimesheetAsync(Guid id)
        {
            var result = await _appService.ViewTimesheetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-payment-reference-finnish")]
        public async Task<IActionResult> ComputePaymentReferenceFinnishAsync(Guid id, [FromBody] SaleOrderComputePaymentReferenceFinnishRequestDto input)
        {
            var result = await _appService.ComputePaymentReferenceFinnishAsync(id, input.Number);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] SaleOrderCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-document-from-attachment")]
        public async Task<IActionResult> CreateDocumentFromAttachmentAsync(Guid id, [FromBody] SaleOrderCreateDocumentFromAttachmentRequestDto input)
        {
            var result = await _appService.CreateDocumentFromAttachmentAsync(id, input.AttachmentIds);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] SaleOrderGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input.HelpMsg);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-finnish-check-digit")]
        public async Task<IActionResult> GetFinnishCheckDigitAsync(Guid id, [FromBody] SaleOrderGetFinnishCheckDigitRequestDto input)
        {
            var result = await _appService.GetFinnishCheckDigitAsync(id, input.BaseNumber);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-portal-last-transaction")]
        public async Task<IActionResult> GetPortalLastTransactionAsync(Guid id)
        {
            var result = await _appService.GetPortalLastTransactionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-promo-code-error")]
        public async Task<IActionResult> GetPromoCodeErrorAsync(Guid id, [FromBody] SaleOrderGetPromoCodeErrorRequestDto input)
        {
            var result = await _appService.GetPromoCodeErrorAsync(id, input.Delete);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-promo-code-success-message")]
        public async Task<IActionResult> GetPromoCodeSuccessMessageAsync(Guid id, [FromBody] SaleOrderGetPromoCodeSuccessMessageRequestDto input)
        {
            var result = await _appService.GetPromoCodeSuccessMessageAsync(id, input.Delete);
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
        [Route("{id}/get-update-included-pdf-params")]
        public async Task<IActionResult> GetUpdateIncludedPdfParamsAsync(Guid id)
        {
            var result = await _appService.GetUpdateIncludedPdfParamsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
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
        [Route("{id}/number2numeric")]
        public async Task<IActionResult> Number2numericAsync(Guid id, [FromBody] SaleOrderNumber2numericRequestDto input)
        {
            var result = await _appService.Number2numericAsync(id, input.Number);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-order-line")]
        public async Task<IActionResult> OnchangeOrderLineAsync(Guid id)
        {
            var result = await _appService.OnchangeOrderLineAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/payment-action-capture")]
        public async Task<IActionResult> PaymentActionCaptureAsync(Guid id)
        {
            var result = await _appService.PaymentCaptureAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/payment-action-void")]
        public async Task<IActionResult> PaymentActionVoidAsync(Guid id)
        {
            var result = await _appService.PaymentVoidAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/save-included-pdf")]
        public async Task<IActionResult> SaveIncludedPdfAsync(Guid id, [FromBody] SaleOrderSaveIncludedPdfRequestDto input)
        {
            var result = await _appService.SaveIncludedPdfAsync(id, input.SelectedPdf);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/save-new-custom-content")]
        public async Task<IActionResult> SaveNewCustomContentAsync(Guid id, [FromBody] SaleOrderSaveNewCustomContentRequestDto input)
        {
            var result = await _appService.SaveNewCustomContentAsync(id, input.DocumentType, input.FormField, input.Content);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-delivery-line")]
        public async Task<IActionResult> SetDeliveryLineAsync(Guid id, [FromBody] SaleOrderSetDeliveryLineRequestDto input)
        {
            var result = await _appService.SetDeliveryLineAsync(id, input.Carrier, input.Amount);
            return Ok(result);
        }
    }
}