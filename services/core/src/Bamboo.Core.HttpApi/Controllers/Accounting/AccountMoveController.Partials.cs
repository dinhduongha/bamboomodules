using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountMoveController
    {
        
        [HttpPost]
        [Route("action-activate-currency")]
        public async Task<IActionResult> ActionActivateCurrencyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ActivateCurrencyAsync(ids);
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
        [Route("action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-cancel-peppol-documents")]
        public async Task<IActionResult> ActionCancelPeppolDocumentsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelPeppolDocumentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-debit-note")]
        public async Task<IActionResult> ActionDebitNoteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DebitNoteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-duplicate")]
        public async Task<IActionResult> ActionDuplicateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DuplicateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-force-register-payment")]
        public async Task<IActionResult> ActionForceRegisterPaymentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ForceRegisterPaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-invoice-download-pdf")]
        public async Task<IActionResult> ActionInvoiceDownloadPdfAsync(AccountMoveInvoiceDownloadPdfRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.InvoiceDownloadPdfAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-invoice-download-ubl")]
        public async Task<IActionResult> ActionInvoiceDownloadUblAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InvoiceDownloadUblAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-invoice-sent")]
        public async Task<IActionResult> ActionInvoiceSentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InvoiceSentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-move-download-all")]
        public async Task<IActionResult> ActionMoveDownloadAllAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MoveDownloadAllAsync(ids);
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
        [Route("action-open-expense")]
        public async Task<IActionResult> ActionOpenExpenseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenExpenseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-post")]
        public async Task<IActionResult> ActionPostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-print-pdf")]
        public async Task<IActionResult> ActionPrintPdfAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrintPdfAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-process-edi-web-services")]
        public async Task<IActionResult> ActionProcessEdiWebServicesAsync(AccountMoveProcessEdiWebServicesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ProcessEdiWebServicesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-purchase-matching")]
        public async Task<IActionResult> ActionPurchaseMatchingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PurchaseMatchingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-register-payment")]
        public async Task<IActionResult> ActionRegisterPaymentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RegisterPaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-retry-edi-documents-error")]
        public async Task<IActionResult> ActionRetryEdiDocumentsErrorAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RetryEdiDocumentsErrorAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reverse")]
        public async Task<IActionResult> ActionReverseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReverseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-and-print")]
        public async Task<IActionResult> ActionSendAndPrintAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendAndPrintAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-switch-move-type")]
        public async Task<IActionResult> ActionSwitchMoveTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SwitchMoveTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-block-payment")]
        public async Task<IActionResult> ActionToggleBlockPaymentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleBlockPaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-fpos-values")]
        public async Task<IActionResult> ActionUpdateFposValuesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateFposValuesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate-moves-with-confirmation")]
        public async Task<IActionResult> ActionValidateMovesWithConfirmationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateMovesWithConfirmationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-debit-notes")]
        public async Task<IActionResult> ActionViewDebitNotesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewDebitNotesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-landed-costs")]
        public async Task<IActionResult> ActionViewLandedCostsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewLandedCostsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-payment-transactions")]
        public async Task<IActionResult> ActionViewPaymentTransactionsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPaymentTransactionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-source-pos-orders")]
        public async Task<IActionResult> ActionViewSourcePosOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSourcePosOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-source-purchase-orders")]
        public async Task<IActionResult> ActionViewSourcePurchaseOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSourcePurchaseOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-source-sale-orders")]
        public async Task<IActionResult> ActionViewSourceSaleOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSourceSaleOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-timesheet")]
        public async Task<IActionResult> ActionViewTimesheetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTimesheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-wip-production")]
        public async Task<IActionResult> ActionViewWipProductionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewWipProductionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-abandon-cancel-posted-posted-moves")]
        public async Task<IActionResult> ButtonAbandonCancelPostedPostedMovesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonAbandonCancelPostedPostedMovesAsync(ids);
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
        [Route("button-cancel-posted-moves")]
        public async Task<IActionResult> ButtonCancelPostedMovesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonCancelPostedMovesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-create-landed-costs")]
        public async Task<IActionResult> ButtonCreateLandedCostsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonCreateLandedCostsAsync(ids);
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
        [Route("button-force-cancel")]
        public async Task<IActionResult> ButtonForceCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonForceCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-hash")]
        public async Task<IActionResult> ButtonHashAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonHashAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-process-edi-web-services")]
        public async Task<IActionResult> ButtonProcessEdiWebServicesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonProcessEdiWebServicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-request-cancel")]
        public async Task<IActionResult> ButtonRequestCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonRequestCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-set-checked")]
        public async Task<IActionResult> ButtonSetCheckedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonSetCheckedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-move-sequence-chain")]
        public async Task<IActionResult> CheckMoveSequenceChainAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckMoveSequenceChainAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-selected-moves")]
        public async Task<IActionResult> CheckSelectedMovesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckSelectedMovesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-move-sent-values")]
        public async Task<IActionResult> ComputeMoveSentValuesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ComputeMoveSentValuesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(AccountMoveCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-currency-rate")]
        public async Task<IActionResult> GetCurrencyRateAsync(AccountMoveGetCurrencyRateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetCurrencyRateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-extra-print-items")]
        public async Task<IActionResult> GetExtraPrintItemsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetExtraPrintItemsAsync(ids);
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
        [Route("get-inbound-types")]
        public async Task<IActionResult> GetInboundTypesAsync(AccountMoveGetInboundTypesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetInboundTypesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-invoice-localisation-fields-required-to-invoice")]
        public async Task<IActionResult> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync(AccountMoveGetInvoiceLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetInvoiceLocalisationFieldsRequiredToInvoiceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-invoice-types")]
        public async Task<IActionResult> GetInvoiceTypesAsync(AccountMoveGetInvoiceTypesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetInvoiceTypesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-outbound-types")]
        public async Task<IActionResult> GetOutboundTypesAsync(AccountMoveGetOutboundTypesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetOutboundTypesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-portal-last-transaction")]
        public async Task<IActionResult> GetPortalLastTransactionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPortalLastTransactionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-purchase-types")]
        public async Task<IActionResult> GetPurchaseTypesAsync(AccountMoveGetPurchaseTypesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetPurchaseTypesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-sale-types")]
        public async Task<IActionResult> GetSaleTypesAsync(AccountMoveGetSaleTypesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetSaleTypesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("invoice-validate-send-email")]
        public async Task<IActionResult> InvoiceValidateSendEmailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InvoiceValidateSendEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-entry")]
        public async Task<IActionResult> IsEntryAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.IsEntryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-inbound")]
        public async Task<IActionResult> IsInboundAsync(AccountMoveIsInboundRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsInboundAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-invoice")]
        public async Task<IActionResult> IsInvoiceAsync(AccountMoveIsInvoiceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsInvoiceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-outbound")]
        public async Task<IActionResult> IsOutboundAsync(AccountMoveIsOutboundRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsOutboundAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-purchase-document")]
        public async Task<IActionResult> IsPurchaseDocumentAsync(AccountMoveIsPurchaseDocumentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsPurchaseDocumentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-receipt")]
        public async Task<IActionResult> IsReceiptAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.IsReceiptAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-sale-document")]
        public async Task<IActionResult> IsSaleDocumentAsync(AccountMoveIsSaleDocumentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsSaleDocumentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("js-assign-outstanding-line")]
        public async Task<IActionResult> JsAssignOutstandingLineAsync(AccountMoveJsAssignOutstandingLineRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.JsAssignOutstandingLineAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("js-remove-outstanding-partial")]
        public async Task<IActionResult> JsRemoveOutstandingPartialAsync(AccountMoveJsRemoveOutstandingPartialRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.JsRemoveOutstandingPartialAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync(AccountMoveMessageNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-adjusting-entries")]
        public async Task<IActionResult> OpenAdjustingEntriesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAdjustingEntriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-adjusting-entry-origin-moves")]
        public async Task<IActionResult> OpenAdjustingEntryOriginMovesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAdjustingEntryOriginMovesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-created-caba-entries")]
        public async Task<IActionResult> OpenCreatedCabaEntriesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenCreatedCabaEntriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-payments")]
        public async Task<IActionResult> OpenPaymentsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenPaymentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-reconcile-view")]
        public async Task<IActionResult> OpenReconcileViewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenReconcileViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("payment-action-capture")]
        public async Task<IActionResult> PaymentActionCaptureAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PaymentCaptureAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("payment-action-void")]
        public async Task<IActionResult> PaymentActionVoidAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PaymentVoidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("preview-invoice")]
        public async Task<IActionResult> PreviewInvoiceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PreviewInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reflect-cancelled-sol")]
        public async Task<IActionResult> ReflectCancelledSolAsync(AccountMoveReflectCancelledSolRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ReflectCancelledSolAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("refresh-invoice-currency-rate")]
        public async Task<IActionResult> RefreshInvoiceCurrencyRateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefreshInvoiceCurrencyRateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-moves-checked")]
        public async Task<IActionResult> SetMovesCheckedAsync(AccountMoveSetMovesCheckedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetMovesCheckedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-snailmail-letters")]
        public async Task<IActionResult> UnlinkSnailmailLettersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnlinkSnailmailLettersAsync(ids);
            return Ok(result);
        }
    }
}