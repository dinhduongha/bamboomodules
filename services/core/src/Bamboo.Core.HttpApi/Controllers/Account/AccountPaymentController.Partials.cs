using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountPaymentController
    {
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
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
        [Route("{id}/action-refund-wizard")]
        public async Task<IActionResult> ActionRefundWizardAsync(Guid id)
        {
            var result = await _appService.RefundWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reject")]
        public async Task<IActionResult> ActionRejectAsync(Guid id)
        {
            var result = await _appService.RejectAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
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
        [Route("{id}/action-view-refunds")]
        public async Task<IActionResult> ActionViewRefundsAsync(Guid id)
        {
            var result = await _appService.ViewRefundsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-void-check")]
        public async Task<IActionResult> ActionVoidCheckAsync(Guid id)
        {
            var result = await _appService.VoidCheckAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-open-bills")]
        public async Task<IActionResult> ButtonOpenBillsAsync(Guid id)
        {
            var result = await _appService.ButtonOpenBillsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-open-invoices")]
        public async Task<IActionResult> ButtonOpenInvoicesAsync(Guid id)
        {
            var result = await _appService.ButtonOpenInvoicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-open-journal-entry")]
        public async Task<IActionResult> ButtonOpenJournalEntryAsync(Guid id)
        {
            var result = await _appService.ButtonOpenJournalEntryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-open-statement-lines")]
        public async Task<IActionResult> ButtonOpenStatementLinesAsync(Guid id)
        {
            var result = await _appService.ButtonOpenStatementLinesAsync(id);
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
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] AccountPaymentCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-print-checks")]
        public async Task<IActionResult> DoPrintChecksAsync(Guid id)
        {
            var result = await _appService.DoPrintChecksAsync(id);
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
        [Route("{id}/mark-as-sent")]
        public async Task<IActionResult> MarkAsSentAsync(Guid id)
        {
            var result = await _appService.MarkAsSentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/print-checks")]
        public async Task<IActionResult> PrintChecksAsync(Guid id)
        {
            var result = await _appService.PrintChecksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unmark-as-sent")]
        public async Task<IActionResult> UnmarkAsSentAsync(Guid id)
        {
            var result = await _appService.UnmarkAsSentAsync(id);
            return Ok(result);
        }
    }
}