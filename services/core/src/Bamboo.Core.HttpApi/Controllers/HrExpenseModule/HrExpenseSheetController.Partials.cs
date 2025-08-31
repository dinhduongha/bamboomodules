using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrExpenseModule
{
    public partial class HrExpenseSheetController
    {
        
        [HttpPost]
        [Route("{id}/action-approve-expense-sheets")]
        public async Task<IActionResult> ActionApproveExpenseSheetsAsync(Guid id)
        {
            var result = await _appService.ApproveExpenseSheetsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-account-moves")]
        public async Task<IActionResult> ActionOpenAccountMovesAsync(Guid id)
        {
            var result = await _appService.OpenAccountMovesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-expense-view")]
        public async Task<IActionResult> ActionOpenExpenseViewAsync(Guid id)
        {
            var result = await _appService.OpenExpenseViewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-sale-orders")]
        public async Task<IActionResult> ActionOpenSaleOrdersAsync(Guid id)
        {
            var result = await _appService.OpenSaleOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-refuse-expense-sheets")]
        public async Task<IActionResult> ActionRefuseExpenseSheetsAsync(Guid id)
        {
            var result = await _appService.RefuseExpenseSheetsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-register-payment")]
        public async Task<IActionResult> ActionRegisterPaymentAsync(Guid id)
        {
            var result = await _appService.RegisterPaymentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reset-expense-sheets")]
        public async Task<IActionResult> ActionResetExpenseSheetsAsync(Guid id)
        {
            var result = await _appService.ResetExpenseSheetsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-sheet-move-post")]
        public async Task<IActionResult> ActionSheetMovePostAsync(Guid id)
        {
            var result = await _appService.SheetMovePostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-submit-sheet")]
        public async Task<IActionResult> ActionSubmitSheetAsync(Guid id)
        {
            var result = await _appService.SubmitSheetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync(Guid id)
        {
            var result = await _appService.ActivityUpdateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-to-paid")]
        public async Task<IActionResult> SetToPaidAsync(Guid id)
        {
            var result = await _appService.SetToPaidAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-to-posted")]
        public async Task<IActionResult> SetToPostedAsync(Guid id)
        {
            var result = await _appService.SetToPostedAsync(id);
            return Ok(result);
        }
    }
}