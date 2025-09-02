using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrExpenseModule
{
    public partial class HrExpenseController
    {
        
        [HttpPost]
        [Route("{id}/action-approve-duplicates")]
        public async Task<IActionResult> ActionApproveDuplicatesAsync(Guid id)
        {
            var result = await _appService.ApproveDuplicatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-get-attachment-view")]
        public async Task<IActionResult> ActionGetAttachmentViewAsync(Guid id)
        {
            var result = await _appService.GetAttachmentViewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-same-receipt-expense-ids")]
        public async Task<IActionResult> ActionShowSameReceiptExpenseIdsAsync(Guid id)
        {
            var result = await _appService.ShowSameReceiptExpenseIdsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-split-wizard")]
        public async Task<IActionResult> ActionSplitWizardAsync(Guid id)
        {
            var result = await _appService.SplitWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-submit-expenses")]
        public async Task<IActionResult> ActionSubmitExpensesAsync(Guid id)
        {
            var result = await _appService.SubmitExpensesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sheet")]
        public async Task<IActionResult> ActionViewSheetAsync(Guid id)
        {
            var result = await _appService.ViewSheetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/attach-document")]
        public async Task<IActionResult> AttachDocumentAsync(Guid id)
        {
            var result = await _appService.AttachDocumentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-amount-not-zero")]
        public async Task<IActionResult> CheckAmountNotZeroAsync(Guid id, [FromBody] HrExpenseCheckAmountNotZeroRequestDto input)
        {
            var result = await _appService.CheckAmountNotZeroAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-expense-from-attachments")]
        public async Task<IActionResult> CreateExpenseFromAttachmentsAsync(Guid id, [FromBody] HrExpenseCreateExpenseFromAttachmentsRequestDto input)
        {
            var result = await _appService.CreateExpenseFromAttachmentsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] HrExpenseGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-expense-attachments")]
        public async Task<IActionResult> GetExpenseAttachmentsAsync(Guid id)
        {
            var result = await _appService.GetExpenseAttachmentsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-expense-dashboard")]
        public async Task<IActionResult> GetExpenseDashboardAsync(Guid id)
        {
            var result = await _appService.GetExpenseDashboardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-expenses-to-submit")]
        public async Task<IActionResult> GetExpensesToSubmitAsync(Guid id)
        {
            var result = await _appService.GetExpensesToSubmitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-new")]
        public async Task<IActionResult> MessageNewAsync(Guid id, [FromBody] HrExpenseMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(id, input);
            return Ok(result);
        }
    }
}