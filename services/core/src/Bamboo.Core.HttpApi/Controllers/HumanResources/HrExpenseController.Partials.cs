using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrExpenseController
    {
        
        [HttpPost]
        [Route("{id}/action-approve")]
        public async Task<IActionResult> ActionApproveAsync(Guid id)
        {
            var result = await _appService.ApproveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-approve-duplicates")]
        public async Task<IActionResult> ActionApproveDuplicatesAsync(Guid id)
        {
            var result = await _appService.ApproveDuplicatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-account-move")]
        public async Task<IActionResult> ActionOpenAccountMoveAsync(Guid id)
        {
            var result = await _appService.OpenAccountMoveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-sale-order")]
        public async Task<IActionResult> ActionOpenSaleOrderAsync(Guid id)
        {
            var result = await _appService.OpenSaleOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-split-expense")]
        public async Task<IActionResult> ActionOpenSplitExpenseAsync(Guid id)
        {
            var result = await _appService.OpenSplitExpenseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-pay")]
        public async Task<IActionResult> ActionPayAsync(Guid id)
        {
            var result = await _appService.PayAsync(id);
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
        [Route("{id}/action-refuse")]
        public async Task<IActionResult> ActionRefuseAsync(Guid id)
        {
            var result = await _appService.RefuseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reset")]
        public async Task<IActionResult> ActionResetAsync(Guid id)
        {
            var result = await _appService.ResetAsync(id);
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
        [Route("{id}/action-submit")]
        public async Task<IActionResult> ActionSubmitAsync(Guid id)
        {
            var result = await _appService.SubmitAsync(id);
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
        [Route("{id}/get-expense-dashboard")]
        public async Task<IActionResult> GetExpenseDashboardAsync(Guid id)
        {
            var result = await _appService.GetExpenseDashboardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-new")]
        public async Task<IActionResult> MessageNewAsync(Guid id, [FromBody] HrExpenseMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-activities-and-mails")]
        public async Task<IActionResult> UpdateActivitiesAndMailsAsync(Guid id)
        {
            var result = await _appService.UpdateActivitiesAndMailsAsync(id);
            return Ok(result);
        }
    }
}