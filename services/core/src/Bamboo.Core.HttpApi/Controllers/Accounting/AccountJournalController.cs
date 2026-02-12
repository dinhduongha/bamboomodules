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
    [Route("api/v1/accounting/AccountJournal")]
    public partial class AccountJournalController : AbpController
    {
        protected readonly IAccountJournalAppService _appService;
        public AccountJournalController(IAccountJournalAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-checks-to-print")]
        public async Task<IActionResult> ChecksToPrintAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ChecksToPrintAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-configure-bank-journal")]
        public async Task<IActionResult> ConfigureBankJournalAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfigureBankJournalAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-new")]
        public async Task<IActionResult> CreateNewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateNewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-vendor-bill")]
        public async Task<IActionResult> CreateVendorBillAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateVendorBillAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-post-all-entries")]
        public async Task<IActionResult> PostAllEntriesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PostAllEntriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-fetch-in-einvoices")]
        public async Task<IActionResult> ButtonFetchInEinvoicesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonFetchInEinvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-refresh-out-einvoices-status")]
        public async Task<IActionResult> ButtonRefreshOutEinvoicesStatusAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonRefreshOutEinvoicesStatusAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-unsubscribe-from-invoice-notifications")]
        public async Task<IActionResult> ButtonUnsubscribeFromInvoiceNotificationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonUnsubscribeFromInvoiceNotificationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] AccountJournalCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-bank-statement")]
        public async Task<IActionResult> CreateBankStatementAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateBankStatementAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-customer-payment")]
        public async Task<IActionResult> CreateCustomerPaymentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateCustomerPaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-document-from-attachment")]
        public async Task<IActionResult> CreateDocumentFromAttachmentAsync([FromBody] AccountJournalCreateDocumentFromAttachmentRequestDto input)
        {
            var result = await _appService.CreateDocumentFromAttachmentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-supplier-payment")]
        public async Task<IActionResult> CreateSupplierPaymentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateSupplierPaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-action")]
        public async Task<IActionResult> OpenActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-action-with-context")]
        public async Task<IActionResult> OpenWithContextAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenWithContextAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-bank-difference-action")]
        public async Task<IActionResult> OpenBankDifferenceActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenBankDifferenceActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-invalid-statements-action")]
        public async Task<IActionResult> OpenInvalidStatementsActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenInvalidStatementsActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-payments-action")]
        public async Task<IActionResult> OpenPaymentsActionAsync([FromBody] AccountJournalOpenPaymentsActionRequestDto input)
        {
            var result = await _appService.OpenPaymentsActionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-bank-account")]
        public async Task<IActionResult> SetBankAccountAsync([FromBody] AccountJournalSetBankAccountRequestDto input)
        {
            var result = await _appService.SetBankAccountAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("show-sequence-holes")]
        public async Task<IActionResult> ShowSequenceHolesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowSequenceHolesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("show-unhashed-entries")]
        public async Task<IActionResult> ShowUnhashedEntriesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowUnhashedEntriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("to-check-ids")]
        public async Task<IActionResult> ToCheckIdsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToCheckIdsAsync(ids);
            return Ok(result);
        }
    }
    
}