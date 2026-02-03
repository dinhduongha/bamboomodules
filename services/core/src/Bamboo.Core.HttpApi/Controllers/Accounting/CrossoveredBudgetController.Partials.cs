using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CrossoveredBudgetController
    {
        
        [HttpPost]
        [Route("action-budget-cancel")]
        public async Task<IActionResult> ActionBudgetCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BudgetCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-budget-confirm")]
        public async Task<IActionResult> ActionBudgetConfirmAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BudgetConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-budget-done")]
        public async Task<IActionResult> ActionBudgetDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BudgetDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-budget-draft")]
        public async Task<IActionResult> ActionBudgetDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BudgetDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-budget-validate")]
        public async Task<IActionResult> ActionBudgetValidateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BudgetValidateAsync(ids);
            return Ok(result);
        }
    }
}