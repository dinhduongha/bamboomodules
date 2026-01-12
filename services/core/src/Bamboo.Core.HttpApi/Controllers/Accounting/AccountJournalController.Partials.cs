using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountJournalController
    {
        
        [HttpPost]
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-checks-to-print")]
        public async Task<IActionResult> ActionChecksToPrintAsync(Guid id)
        {
            var result = await _appService.ChecksToPrintAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-configure-bank-journal")]
        public async Task<IActionResult> ActionConfigureBankJournalAsync(Guid id)
        {
            var result = await _appService.ConfigureBankJournalAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-new")]
        public async Task<IActionResult> ActionCreateNewAsync(Guid id)
        {
            var result = await _appService.CreateNewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-vendor-bill")]
        public async Task<IActionResult> ActionCreateVendorBillAsync(Guid id)
        {
            var result = await _appService.CreateVendorBillAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-post-all-entries")]
        public async Task<IActionResult> ActionPostAllEntriesAsync(Guid id)
        {
            var result = await _appService.PostAllEntriesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-fetch-in-einvoices")]
        public async Task<IActionResult> ButtonFetchInEinvoicesAsync(Guid id)
        {
            var result = await _appService.ButtonFetchInEinvoicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-refresh-out-einvoices-status")]
        public async Task<IActionResult> ButtonRefreshOutEinvoicesStatusAsync(Guid id)
        {
            var result = await _appService.ButtonRefreshOutEinvoicesStatusAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-unsubscribe-from-invoice-notifications")]
        public async Task<IActionResult> ButtonUnsubscribeFromInvoiceNotificationsAsync(Guid id)
        {
            var result = await _appService.ButtonUnsubscribeFromInvoiceNotificationsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] AccountJournalCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-bank-statement")]
        public async Task<IActionResult> CreateBankStatementAsync(Guid id)
        {
            var result = await _appService.CreateBankStatementAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-customer-payment")]
        public async Task<IActionResult> CreateCustomerPaymentAsync(Guid id)
        {
            var result = await _appService.CreateCustomerPaymentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-document-from-attachment")]
        public async Task<IActionResult> CreateDocumentFromAttachmentAsync(Guid id, [FromBody] AccountJournalCreateDocumentFromAttachmentRequestDto input)
        {
            var result = await _appService.CreateDocumentFromAttachmentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-supplier-payment")]
        public async Task<IActionResult> CreateSupplierPaymentAsync(Guid id)
        {
            var result = await _appService.CreateSupplierPaymentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-action")]
        public async Task<IActionResult> OpenActionAsync(Guid id)
        {
            var result = await _appService.OpenActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-action-with-context")]
        public async Task<IActionResult> OpenActionWithContextAsync(Guid id)
        {
            var result = await _appService.OpenWithContextAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-bank-difference-action")]
        public async Task<IActionResult> OpenBankDifferenceActionAsync(Guid id)
        {
            var result = await _appService.OpenBankDifferenceActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-invalid-statements-action")]
        public async Task<IActionResult> OpenInvalidStatementsActionAsync(Guid id)
        {
            var result = await _appService.OpenInvalidStatementsActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-payments-action")]
        public async Task<IActionResult> OpenPaymentsActionAsync(Guid id, [FromBody] AccountJournalOpenPaymentsActionRequestDto input)
        {
            var result = await _appService.OpenPaymentsActionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-bank-account")]
        public async Task<IActionResult> SetBankAccountAsync(Guid id, [FromBody] AccountJournalSetBankAccountRequestDto input)
        {
            var result = await _appService.SetBankAccountAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/show-sequence-holes")]
        public async Task<IActionResult> ShowSequenceHolesAsync(Guid id)
        {
            var result = await _appService.ShowSequenceHolesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/show-unhashed-entries")]
        public async Task<IActionResult> ShowUnhashedEntriesAsync(Guid id)
        {
            var result = await _appService.ShowUnhashedEntriesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/to-check-ids")]
        public async Task<IActionResult> ToCheckIdsAsync(Guid id)
        {
            var result = await _appService.ToCheckIdsAsync(id);
            return Ok(result);
        }
    }
}