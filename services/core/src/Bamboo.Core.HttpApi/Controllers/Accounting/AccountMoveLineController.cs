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
    [Route("api/v1/accounting/AccountMoveLine")]
    public partial class AccountMoveLineController : AbpController
    {
        protected readonly IAccountMoveLineAppService _appService;
        public AccountMoveLineController(IAccountMoveLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> AddFromCatalogAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-automatic-entry")]
        public async Task<IActionResult> AutomaticEntryAsync([FromBody] AccountMoveLineAutomaticEntryRequestDto input)
        {
            var result = await _appService.AutomaticEntryAsync(input);
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
        [Route("action-payment-items-register-payment")]
        public async Task<IActionResult> PaymentItemsRegisterPaymentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PaymentItemsRegisterPaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-register-payment")]
        public async Task<IActionResult> RegisterPaymentAsync([FromBody] AccountMoveLineRegisterPaymentRequestDto input)
        {
            var result = await _appService.RegisterPaymentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unreconcile-match-entries")]
        public async Task<IActionResult> UnreconcileMatchEntriesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnreconcileMatchEntriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("asset-create")]
        public async Task<IActionResult> AssetCreateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AssetCreateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] AccountMoveLineCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("flush-model")]
        public async Task<IActionResult> FlushModelAsync([FromBody] AccountMoveLineFlushModelRequestDto input)
        {
            var result = await _appService.FlushModelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("flush-recordset")]
        public async Task<IActionResult> FlushRecordsetAsync([FromBody] AccountMoveLineFlushRecordsetRequestDto input)
        {
            var result = await _appService.FlushRecordsetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-column-to-exclude-for-colspan-calculation")]
        public async Task<IActionResult> GetColumnToExcludeForColspanCalculationAsync([FromBody] AccountMoveLineGetColumnToExcludeForColspanCalculationRequestDto input)
        {
            var result = await _appService.GetColumnToExcludeForColspanCalculationAsync(input);
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
        [Route("get-invoice-line-account")]
        public async Task<IActionResult> GetInvoiceLineAccountAsync([FromBody] AccountMoveLineGetInvoiceLineAccountRequestDto input)
        {
            var result = await _appService.GetInvoiceLineAccountAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-parent-section-line")]
        public async Task<IActionResult> GetParentSectionLineAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetParentSectionLineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-section-subtotal")]
        public async Task<IActionResult> GetSectionSubtotalAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetSectionSubtotalAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-views")]
        public async Task<IActionResult> GetViewsAsync([FromBody] AccountMoveLineGetViewsRequestDto input)
        {
            var result = await _appService.GetViewsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("invalidate-model")]
        public async Task<IActionResult> InvalidateModelAsync([FromBody] AccountMoveLineInvalidateModelRequestDto input)
        {
            var result = await _appService.InvalidateModelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("invalidate-recordset")]
        public async Task<IActionResult> InvalidateRecordsetAsync([FromBody] AccountMoveLineInvalidateRecordsetRequestDto input)
        {
            var result = await _appService.InvalidateRecordsetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-asset-category-id")]
        public async Task<IActionResult> OnchangeAssetCategoryIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeAssetCategoryIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-reconcile-view")]
        public async Task<IActionResult> OpenReconcileViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenReconcileViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reconcile")]
        public async Task<IActionResult> ReconcileAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReconcileAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("remove-move-reconcile")]
        public async Task<IActionResult> RemoveMoveReconcileAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RemoveMoveReconcileAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-fetch")]
        public async Task<IActionResult> SearchFetchAsync([FromBody] AccountMoveLineSearchFetchRequestDto input)
        {
            var result = await _appService.SearchFetchAsync(input);
            return Ok(result);
        }
    }
    
}