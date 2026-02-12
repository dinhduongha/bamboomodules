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
    [Route("api/v1/human-resources/HrExpenseSheet")]
    public partial class HrExpenseSheetController : AbpController
    {
        protected readonly IHrExpenseSheetAppService _appService;
        public HrExpenseSheetController(IHrExpenseSheetAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-approve-expense-sheets")]
        public async Task<IActionResult> ApproveExpenseSheetsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ApproveExpenseSheetsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-account-moves")]
        public async Task<IActionResult> OpenAccountMovesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAccountMovesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-expense-view")]
        public async Task<IActionResult> OpenExpenseViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenExpenseViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-sale-orders")]
        public async Task<IActionResult> OpenSaleOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenSaleOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse-expense-sheets")]
        public async Task<IActionResult> RefuseExpenseSheetsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefuseExpenseSheetsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-register-payment")]
        public async Task<IActionResult> RegisterPaymentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RegisterPaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset-expense-sheets")]
        public async Task<IActionResult> ResetExpenseSheetsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetExpenseSheetsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sheet-move-post")]
        public async Task<IActionResult> SheetMovePostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SheetMovePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-submit-sheet")]
        public async Task<IActionResult> SubmitSheetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SubmitSheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("activity-update")]
        public async Task<IActionResult> ActivityUpdateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ActivityUpdateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-to-paid")]
        public async Task<IActionResult> SetToPaidAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetToPaidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-to-posted")]
        public async Task<IActionResult> SetToPostedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetToPostedAsync(ids);
            return Ok(result);
        }
    }
    
}