using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountMoveLineController
    {
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-automatic-entry")]
        public async Task<IActionResult> ActionAutomaticEntryAsync(Guid id, [FromBody] AccountMoveLineAutomaticEntryRequestDto input)
        {
            var result = await _appService.AutomaticEntryAsync(id, input);
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
        [Route("{id}/action-payment-items-register-payment")]
        public async Task<IActionResult> ActionPaymentItemsRegisterPaymentAsync(Guid id)
        {
            var result = await _appService.PaymentItemsRegisterPaymentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-register-payment")]
        public async Task<IActionResult> ActionRegisterPaymentAsync(Guid id, [FromBody] AccountMoveLineRegisterPaymentRequestDto input)
        {
            var result = await _appService.RegisterPaymentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unreconcile-match-entries")]
        public async Task<IActionResult> ActionUnreconcileMatchEntriesAsync(Guid id)
        {
            var result = await _appService.UnreconcileMatchEntriesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/asset-create")]
        public async Task<IActionResult> AssetCreateAsync(Guid id)
        {
            var result = await _appService.AssetCreateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] AccountMoveLineCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/flush-model")]
        public async Task<IActionResult> FlushModelAsync(Guid id, [FromBody] AccountMoveLineFlushModelRequestDto input)
        {
            var result = await _appService.FlushModelAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/flush-recordset")]
        public async Task<IActionResult> FlushRecordsetAsync(Guid id, [FromBody] AccountMoveLineFlushRecordsetRequestDto input)
        {
            var result = await _appService.FlushRecordsetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid id)
        {
            var result = await _appService.GetImportTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-invoice-line-account")]
        public async Task<IActionResult> GetInvoiceLineAccountAsync(Guid id, [FromBody] AccountMoveLineGetInvoiceLineAccountRequestDto input)
        {
            var result = await _appService.GetInvoiceLineAccountAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-views")]
        public async Task<IActionResult> GetViewsAsync(Guid id, [FromBody] AccountMoveLineGetViewsRequestDto input)
        {
            var result = await _appService.GetViewsAsync(id, input);
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
        [Route("{id}/invalidate-model")]
        public async Task<IActionResult> InvalidateModelAsync(Guid id, [FromBody] AccountMoveLineInvalidateModelRequestDto input)
        {
            var result = await _appService.InvalidateModelAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/invalidate-recordset")]
        public async Task<IActionResult> InvalidateRecordsetAsync(Guid id, [FromBody] AccountMoveLineInvalidateRecordsetRequestDto input)
        {
            var result = await _appService.InvalidateRecordsetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-asset-category-id")]
        public async Task<IActionResult> OnchangeAssetCategoryIdAsync(Guid id)
        {
            var result = await _appService.OnchangeAssetCategoryIdAsync(id);
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
        [Route("{id}/reconcile")]
        public async Task<IActionResult> ReconcileAsync(Guid id)
        {
            var result = await _appService.ReconcileAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/remove-move-reconcile")]
        public async Task<IActionResult> RemoveMoveReconcileAsync(Guid id)
        {
            var result = await _appService.RemoveMoveReconcileAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-fetch")]
        public async Task<IActionResult> SearchFetchAsync(Guid id, [FromBody] AccountMoveLineSearchFetchRequestDto input)
        {
            var result = await _appService.SearchFetchAsync(id, input);
            return Ok(result);
        }
    }
}