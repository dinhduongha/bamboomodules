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
        [Route("{id}/action-peppol-ready-moves")]
        public async Task<IActionResult> ActionPeppolReadyMovesAsync(Guid id)
        {
            var result = await _appService.PeppolReadyMovesAsync(id);
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
        [Route("{id}/get-next-bank-cash-default-code")]
        public async Task<IActionResult> GetNextBankCashDefaultCodeAsync(Guid id, [FromBody] AccountJournalGetNextBankCashDefaultCodeRequestDto input)
        {
            var result = await _appService.GetNextBankCashDefaultCodeAsync(id, input);
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
        [Route("{id}/open-payments-action")]
        public async Task<IActionResult> OpenPaymentsActionAsync(Guid id, [FromBody] AccountJournalOpenPaymentsActionRequestDto input)
        {
            var result = await _appService.OpenPaymentsActionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/peppol-get-message-status")]
        public async Task<IActionResult> PeppolGetMessageStatusAsync(Guid id)
        {
            var result = await _appService.PeppolGetMessageStatusAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/peppol-get-new-documents")]
        public async Task<IActionResult> PeppolGetNewDocumentsAsync(Guid id)
        {
            var result = await _appService.PeppolGetNewDocumentsAsync(id);
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