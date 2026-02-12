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
    [Route("api/v1/sales/SaleOrder")]
    public partial class SaleOrderController : AbpController
    {
        protected readonly ISaleOrderAppService _appService;
        public SaleOrderController(ISaleOrderAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ConfirmAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-project")]
        public async Task<IActionResult> CreateProjectAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateProjectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-draft")]
        public async Task<IActionResult> DraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-lock")]
        public async Task<IActionResult> LockAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LockAsync(ids);
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
        [Route("action-open-delivery-wizard")]
        public async Task<IActionResult> OpenDeliveryWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenDeliveryWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-discount-wizard")]
        public async Task<IActionResult> OpenDiscountWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenDiscountWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-reward-wizard")]
        public async Task<IActionResult> OpenRewardWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenRewardWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-preview-sale-order")]
        public async Task<IActionResult> PreviewSaleOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PreviewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-quotation-send")]
        public async Task<IActionResult> QuotationSendAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.QuotationSendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-quotation-sent")]
        public async Task<IActionResult> QuotationSentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.QuotationSentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-recovery-email-send")]
        public async Task<IActionResult> RecoveryEmailSendAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RecoveryEmailSendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-repair")]
        public async Task<IActionResult> ShowRepairAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowRepairAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unlock")]
        public async Task<IActionResult> UnlockAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnlockAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-prices")]
        public async Task<IActionResult> UpdatePricesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdatePricesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-update-taxes")]
        public async Task<IActionResult> UpdateTaxesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateTaxesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-attendee-list")]
        public async Task<IActionResult> ViewAttendeeListAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewAttendeeListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-booth-list")]
        public async Task<IActionResult> ViewBoothListAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewBoothListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-delivery")]
        public async Task<IActionResult> ViewDeliveryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewDeliveryAsync(ids);
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
        [Route("action-view-gift-cards")]
        public async Task<IActionResult> ViewGiftCardsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewGiftCardsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-invoice")]
        public async Task<IActionResult> ViewInvoiceAsync([FromBody] SaleOrderViewInvoiceRequestDto input)
        {
            var result = await _appService.ViewInvoiceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-milestone")]
        public async Task<IActionResult> ViewMilestoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMilestoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production")]
        public async Task<IActionResult> ViewMrpProductionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-pos-order")]
        public async Task<IActionResult> ViewPosOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPosOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-project-ids")]
        public async Task<IActionResult> ViewProjectIdsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewProjectIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-purchase-orders")]
        public async Task<IActionResult> ViewPurchaseOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPurchaseOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-timesheet")]
        public async Task<IActionResult> ViewTimesheetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTimesheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] SaleOrderCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-document-from-attachment")]
        public async Task<IActionResult> CreateDocumentFromAttachmentAsync([FromBody] SaleOrderCreateDocumentFromAttachmentRequestDto input)
        {
            var result = await _appService.CreateDocumentFromAttachmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] SaleOrderGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-first-service-line")]
        public async Task<IActionResult> GetFirstServiceLineAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetFirstServiceLineAsync(ids);
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
        [Route("get-portal-last-transaction")]
        public async Task<IActionResult> GetPortalLastTransactionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPortalLastTransactionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-promo-code-error")]
        public async Task<IActionResult> GetPromoCodeErrorAsync([FromBody] SaleOrderGetPromoCodeErrorRequestDto input)
        {
            var result = await _appService.GetPromoCodeErrorAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-promo-code-success-message")]
        public async Task<IActionResult> GetPromoCodeSuccessMessageAsync([FromBody] SaleOrderGetPromoCodeSuccessMessageRequestDto input)
        {
            var result = await _appService.GetPromoCodeSuccessMessageAsync(input);
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
        [Route("get-update-included-pdf-params")]
        public async Task<IActionResult> GetUpdateIncludedPdfParamsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetUpdateIncludedPdfParamsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-sale-order-from-pos")]
        public async Task<IActionResult> LoadSaleOrderFromPosAsync([FromBody] SaleOrderLoadSaleOrderFromPosRequestDto input)
        {
            var result = await _appService.LoadSaleOrderFromPosAsync(input);
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
        [Route("onchange-order-line")]
        public async Task<IActionResult> OnchangeOrderLineAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeOrderLineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("payment-action-capture")]
        public async Task<IActionResult> PaymentCaptureAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PaymentCaptureAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("payment-action-void")]
        public async Task<IActionResult> PaymentVoidAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PaymentVoidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-delivery-line")]
        public async Task<IActionResult> SetDeliveryLineAsync([FromBody] SaleOrderSetDeliveryLineRequestDto input)
        {
            var result = await _appService.SetDeliveryLineAsync(input);
            return Ok(result);
        }
    }
    
}