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
    [Route("api/v1/human-resources/HrExpense")]
    public partial class HrExpenseController : AbpController
    {
        protected readonly IHrExpenseAppService _appService;
        public HrExpenseController(IHrExpenseAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-approve")]
        public async Task<IActionResult> ApproveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ApproveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-approve-duplicates")]
        public async Task<IActionResult> ApproveDuplicatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ApproveDuplicatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-account-move")]
        public async Task<IActionResult> OpenAccountMoveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAccountMoveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-sale-order")]
        public async Task<IActionResult> OpenSaleOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-split-expense")]
        public async Task<IActionResult> OpenSplitExpenseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenSplitExpenseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-pay")]
        public async Task<IActionResult> PayAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PayAsync(ids);
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
        [Route("action-refuse")]
        public async Task<IActionResult> RefuseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefuseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset")]
        public async Task<IActionResult> ResetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-same-receipt-expense-ids")]
        public async Task<IActionResult> ShowSameReceiptExpenseIdsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowSameReceiptExpenseIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-split-wizard")]
        public async Task<IActionResult> SplitWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SplitWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-submit")]
        public async Task<IActionResult> SubmitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SubmitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("attach-document")]
        public async Task<IActionResult> AttachDocumentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AttachDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-expense-from-attachments")]
        public async Task<IActionResult> CreateExpenseFromAttachmentsAsync([FromBody] HrExpenseCreateExpenseFromAttachmentsRequestDto input)
        {
            var result = await _appService.CreateExpenseFromAttachmentsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] HrExpenseGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-expense-dashboard")]
        public async Task<IActionResult> GetExpenseDashboardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetExpenseDashboardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync([FromBody] HrExpenseMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-activities-and-mails")]
        public async Task<IActionResult> UpdateActivitiesAndMailsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateActivitiesAndMailsAsync(ids);
            return Ok(result);
        }
    }
    
}