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
        [Route("action-approve")]
        public async Task<IActionResult> ActionApproveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ApproveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-approve-duplicates")]
        public async Task<IActionResult> ActionApproveDuplicatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ApproveDuplicatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-account-move")]
        public async Task<IActionResult> ActionOpenAccountMoveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAccountMoveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-sale-order")]
        public async Task<IActionResult> ActionOpenSaleOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-split-expense")]
        public async Task<IActionResult> ActionOpenSplitExpenseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenSplitExpenseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pay")]
        public async Task<IActionResult> ActionPayAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PayAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-post")]
        public async Task<IActionResult> ActionPostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse")]
        public async Task<IActionResult> ActionRefuseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefuseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset")]
        public async Task<IActionResult> ActionResetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-same-receipt-expense-ids")]
        public async Task<IActionResult> ActionShowSameReceiptExpenseIdsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowSameReceiptExpenseIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-split-wizard")]
        public async Task<IActionResult> ActionSplitWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SplitWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-submit")]
        public async Task<IActionResult> ActionSubmitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SubmitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("attach-document")]
        public async Task<IActionResult> AttachDocumentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AttachDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-expense-from-attachments")]
        public async Task<IActionResult> CreateExpenseFromAttachmentsAsync(HrExpenseCreateExpenseFromAttachmentsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateExpenseFromAttachmentsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(HrExpenseGetEmptyListHelpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-expense-dashboard")]
        public async Task<IActionResult> GetExpenseDashboardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetExpenseDashboardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync(HrExpenseMessageNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-activities-and-mails")]
        public async Task<IActionResult> UpdateActivitiesAndMailsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateActivitiesAndMailsAsync(ids);
            return Ok(result);
        }
    }
}