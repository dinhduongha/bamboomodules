using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountMoveController
    {
        
        [HttpPost]
        [Route("{id}/action-activate-currency")]
        public async Task<IActionResult> ActionActivateCurrencyAsync(Guid id)
        {
            var result = await _appService.ActivateCurrencyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-cancel-peppol-documents")]
        public async Task<IActionResult> ActionCancelPeppolDocumentsAsync(Guid id)
        {
            var result = await _appService.CancelPeppolDocumentsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-debit-note")]
        public async Task<IActionResult> ActionDebitNoteAsync(Guid id)
        {
            var result = await _appService.DebitNoteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-duplicate")]
        public async Task<IActionResult> ActionDuplicateAsync(Guid id)
        {
            var result = await _appService.DuplicateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-force-register-payment")]
        public async Task<IActionResult> ActionForceRegisterPaymentAsync(Guid id)
        {
            var result = await _appService.ForceRegisterPaymentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-invoice-download-pdf")]
        public async Task<IActionResult> ActionInvoiceDownloadPdfAsync(Guid id)
        {
            var result = await _appService.InvoiceDownloadPdfAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-invoice-download-ubl")]
        public async Task<IActionResult> ActionInvoiceDownloadUblAsync(Guid id)
        {
            var result = await _appService.InvoiceDownloadUblAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-invoice-sent")]
        public async Task<IActionResult> ActionInvoiceSentAsync(Guid id)
        {
            var result = await _appService.InvoiceSentAsync(id);
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
        [Route("{id}/action-open-expense-report")]
        public async Task<IActionResult> ActionOpenExpenseReportAsync(Guid id)
        {
            var result = await _appService.OpenExpenseReportAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-post")]
        public async Task<IActionResult> ActionPostAsync(Guid id)
        {
            var result = await _appService.PostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-print-pdf")]
        public async Task<IActionResult> ActionPrintPdfAsync(Guid id)
        {
            var result = await _appService.PrintPdfAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-process-edi-web-services")]
        public async Task<IActionResult> ActionProcessEdiWebServicesAsync(Guid id, [FromBody] AccountMoveProcessEdiWebServicesRequestDto input)
        {
            var result = await _appService.ProcessEdiWebServicesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-purchase-matching")]
        public async Task<IActionResult> ActionPurchaseMatchingAsync(Guid id)
        {
            var result = await _appService.PurchaseMatchingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-register-payment")]
        public async Task<IActionResult> ActionRegisterPaymentAsync(Guid id)
        {
            var result = await _appService.RegisterPaymentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-retry-edi-documents-error")]
        public async Task<IActionResult> ActionRetryEdiDocumentsErrorAsync(Guid id)
        {
            var result = await _appService.RetryEdiDocumentsErrorAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reverse")]
        public async Task<IActionResult> ActionReverseAsync(Guid id)
        {
            var result = await _appService.ReverseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-and-print")]
        public async Task<IActionResult> ActionSendAndPrintAsync(Guid id)
        {
            var result = await _appService.SendAndPrintAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-switch-move-type")]
        public async Task<IActionResult> ActionSwitchMoveTypeAsync(Guid id)
        {
            var result = await _appService.SwitchMoveTypeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-toggle-block-payment")]
        public async Task<IActionResult> ActionToggleBlockPaymentAsync(Guid id)
        {
            var result = await _appService.ToggleBlockPaymentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-update-fpos-values")]
        public async Task<IActionResult> ActionUpdateFposValuesAsync(Guid id)
        {
            var result = await _appService.UpdateFposValuesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-debit-notes")]
        public async Task<IActionResult> ActionViewDebitNotesAsync(Guid id)
        {
            var result = await _appService.ViewDebitNotesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-landed-costs")]
        public async Task<IActionResult> ActionViewLandedCostsAsync(Guid id)
        {
            var result = await _appService.ViewLandedCostsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-payment-transactions")]
        public async Task<IActionResult> ActionViewPaymentTransactionsAsync(Guid id)
        {
            var result = await _appService.ViewPaymentTransactionsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-source-purchase-orders")]
        public async Task<IActionResult> ActionViewSourcePurchaseOrdersAsync(Guid id)
        {
            var result = await _appService.ViewSourcePurchaseOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-source-sale-orders")]
        public async Task<IActionResult> ActionViewSourceSaleOrdersAsync(Guid id)
        {
            var result = await _appService.ViewSourceSaleOrdersAsync(id);
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
        [Route("{id}/action-view-wip-production")]
        public async Task<IActionResult> ActionViewWipProductionAsync(Guid id)
        {
            var result = await _appService.ViewWipProductionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-abandon-cancel-posted-posted-moves")]
        public async Task<IActionResult> ButtonAbandonCancelPostedPostedMovesAsync(Guid id)
        {
            var result = await _appService.ButtonAbandonCancelPostedPostedMovesAsync(id);
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
        [Route("{id}/button-cancel-posted-moves")]
        public async Task<IActionResult> ButtonCancelPostedMovesAsync(Guid id)
        {
            var result = await _appService.ButtonCancelPostedMovesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-create-landed-costs")]
        public async Task<IActionResult> ButtonCreateLandedCostsAsync(Guid id)
        {
            var result = await _appService.ButtonCreateLandedCostsAsync(id);
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
        [Route("{id}/button-force-cancel")]
        public async Task<IActionResult> ButtonForceCancelAsync(Guid id)
        {
            var result = await _appService.ButtonForceCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-hash")]
        public async Task<IActionResult> ButtonHashAsync(Guid id)
        {
            var result = await _appService.ButtonHashAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-process-edi-web-services")]
        public async Task<IActionResult> ButtonProcessEdiWebServicesAsync(Guid id)
        {
            var result = await _appService.ButtonProcessEdiWebServicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-request-cancel")]
        public async Task<IActionResult> ButtonRequestCancelAsync(Guid id)
        {
            var result = await _appService.ButtonRequestCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-set-checked")]
        public async Task<IActionResult> ButtonSetCheckedAsync(Guid id)
        {
            var result = await _appService.ButtonSetCheckedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-move-sequence-chain")]
        public async Task<IActionResult> CheckMoveSequenceChainAsync(Guid id)
        {
            var result = await _appService.CheckMoveSequenceChainAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-move-sent-values")]
        public async Task<IActionResult> ComputeMoveSentValuesAsync(Guid id)
        {
            var result = await _appService.ComputeMoveSentValuesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] AccountMoveCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-currency-rate")]
        public async Task<IActionResult> GetCurrencyRateAsync(Guid id, [FromBody] AccountMoveGetCurrencyRateRequestDto input)
        {
            var result = await _appService.GetCurrencyRateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-extra-print-items")]
        public async Task<IActionResult> GetExtraPrintItemsAsync(Guid id)
        {
            var result = await _appService.GetExtraPrintItemsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-inbound-types")]
        public async Task<IActionResult> GetInboundTypesAsync(Guid id, [FromBody] AccountMoveGetInboundTypesRequestDto input)
        {
            var result = await _appService.GetInboundTypesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-invoice-localisation-fields-required-to-invoice")]
        public async Task<IActionResult> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync(Guid id, [FromBody] AccountMoveGetInvoiceLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            var result = await _appService.GetInvoiceLocalisationFieldsRequiredToInvoiceAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-invoice-types")]
        public async Task<IActionResult> GetInvoiceTypesAsync(Guid id, [FromBody] AccountMoveGetInvoiceTypesRequestDto input)
        {
            var result = await _appService.GetInvoiceTypesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-outbound-types")]
        public async Task<IActionResult> GetOutboundTypesAsync(Guid id, [FromBody] AccountMoveGetOutboundTypesRequestDto input)
        {
            var result = await _appService.GetOutboundTypesAsync(id, input);
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
        [Route("{id}/get-purchase-types")]
        public async Task<IActionResult> GetPurchaseTypesAsync(Guid id, [FromBody] AccountMoveGetPurchaseTypesRequestDto input)
        {
            var result = await _appService.GetPurchaseTypesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-sale-types")]
        public async Task<IActionResult> GetSaleTypesAsync(Guid id, [FromBody] AccountMoveGetSaleTypesRequestDto input)
        {
            var result = await _appService.GetSaleTypesAsync(id, input);
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
        [Route("{id}/invoice-validate-send-email")]
        public async Task<IActionResult> InvoiceValidateSendEmailAsync(Guid id)
        {
            var result = await _appService.InvoiceValidateSendEmailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-entry")]
        public async Task<IActionResult> IsEntryAsync(Guid id)
        {
            var result = await _appService.IsEntryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-inbound")]
        public async Task<IActionResult> IsInboundAsync(Guid id, [FromBody] AccountMoveIsInboundRequestDto input)
        {
            var result = await _appService.IsInboundAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-invoice")]
        public async Task<IActionResult> IsInvoiceAsync(Guid id, [FromBody] AccountMoveIsInvoiceRequestDto input)
        {
            var result = await _appService.IsInvoiceAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-outbound")]
        public async Task<IActionResult> IsOutboundAsync(Guid id, [FromBody] AccountMoveIsOutboundRequestDto input)
        {
            var result = await _appService.IsOutboundAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-purchase-document")]
        public async Task<IActionResult> IsPurchaseDocumentAsync(Guid id, [FromBody] AccountMoveIsPurchaseDocumentRequestDto input)
        {
            var result = await _appService.IsPurchaseDocumentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-sale-document")]
        public async Task<IActionResult> IsSaleDocumentAsync(Guid id, [FromBody] AccountMoveIsSaleDocumentRequestDto input)
        {
            var result = await _appService.IsSaleDocumentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/js-assign-outstanding-line")]
        public async Task<IActionResult> JsAssignOutstandingLineAsync(Guid id, [FromBody] AccountMoveJsAssignOutstandingLineRequestDto input)
        {
            var result = await _appService.JsAssignOutstandingLineAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/js-remove-outstanding-partial")]
        public async Task<IActionResult> JsRemoveOutstandingPartialAsync(Guid id, [FromBody] AccountMoveJsRemoveOutstandingPartialRequestDto input)
        {
            var result = await _appService.JsRemoveOutstandingPartialAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-new")]
        public async Task<IActionResult> MessageNewAsync(Guid id, [FromBody] AccountMoveMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-created-caba-entries")]
        public async Task<IActionResult> OpenCreatedCabaEntriesAsync(Guid id)
        {
            var result = await _appService.OpenCreatedCabaEntriesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-payments")]
        public async Task<IActionResult> OpenPaymentsAsync(Guid id)
        {
            var result = await _appService.OpenPaymentsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-reconcile-view")]
        public async Task<IActionResult> OpenReconcileViewAsync(Guid id)
        {
            var result = await _appService.OpenReconcileViewAsync(id);
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
        [Route("{id}/preview-invoice")]
        public async Task<IActionResult> PreviewInvoiceAsync(Guid id)
        {
            var result = await _appService.PreviewInvoiceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/refresh-invoice-currency-rate")]
        public async Task<IActionResult> RefreshInvoiceCurrencyRateAsync(Guid id)
        {
            var result = await _appService.RefreshInvoiceCurrencyRateAsync(id);
            return Ok(result);
        }
    }
}