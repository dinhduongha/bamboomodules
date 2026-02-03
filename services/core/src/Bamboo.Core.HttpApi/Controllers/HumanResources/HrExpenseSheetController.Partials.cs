using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrExpenseSheetController
    {
        
        [HttpPost]
        [Route("action-approve-expense-sheets")]
        public async Task<IActionResult> ActionApproveExpenseSheetsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ApproveExpenseSheetsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-account-moves")]
        public async Task<IActionResult> ActionOpenAccountMovesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAccountMovesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-expense-view")]
        public async Task<IActionResult> ActionOpenExpenseViewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenExpenseViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-sale-orders")]
        public async Task<IActionResult> ActionOpenSaleOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenSaleOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse-expense-sheets")]
        public async Task<IActionResult> ActionRefuseExpenseSheetsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefuseExpenseSheetsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-register-payment")]
        public async Task<IActionResult> ActionRegisterPaymentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RegisterPaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset-expense-sheets")]
        public async Task<IActionResult> ActionResetExpenseSheetsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetExpenseSheetsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sheet-move-post")]
        public async Task<IActionResult> ActionSheetMovePostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SheetMovePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-submit-sheet")]
        public async Task<IActionResult> ActionSubmitSheetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SubmitSheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ActivityUpdateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-to-paid")]
        public async Task<IActionResult> SetToPaidAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetToPaidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-to-posted")]
        public async Task<IActionResult> SetToPostedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetToPostedAsync(ids);
            return Ok(result);
        }
    }
}