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
    [Route("api/v1/accounting/AccountPayment")]
    public partial class AccountPaymentController : AbpController
    {
        protected readonly IAccountPaymentAppService _appService;
        public AccountPaymentController(IAccountPaymentAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
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
        [Route("action-open-business-doc")]
        public async Task<IActionResult> OpenBusinessDocAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenBusinessDocAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-expense")]
        public async Task<IActionResult> OpenExpenseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenExpenseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-post")]
        public async Task<IActionResult> PostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refund-wizard")]
        public async Task<IActionResult> RefundWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefundWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reject")]
        public async Task<IActionResult> RejectAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RejectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate")]
        public async Task<IActionResult> ValidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateAsync(ids);
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
        [Route("action-view-refunds")]
        public async Task<IActionResult> ViewRefundsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRefundsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-void-check")]
        public async Task<IActionResult> VoidCheckAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.VoidCheckAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-open-bills")]
        public async Task<IActionResult> ButtonOpenBillsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonOpenBillsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-open-invoices")]
        public async Task<IActionResult> ButtonOpenInvoicesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonOpenInvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-open-journal-entry")]
        public async Task<IActionResult> ButtonOpenJournalEntryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonOpenJournalEntryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-open-statement-lines")]
        public async Task<IActionResult> ButtonOpenStatementLinesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonOpenStatementLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-request-cancel")]
        public async Task<IActionResult> ButtonRequestCancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonRequestCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] AccountPaymentCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-print-checks")]
        public async Task<IActionResult> DoPrintChecksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoPrintChecksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mark-as-sent")]
        public async Task<IActionResult> MarkAsSentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MarkAsSentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-checks")]
        public async Task<IActionResult> PrintChecksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrintChecksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unmark-as-sent")]
        public async Task<IActionResult> UnmarkAsSentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnmarkAsSentAsync(ids);
            return Ok(result);
        }
    }
    
}