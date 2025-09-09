using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountBudget
{
    public partial class CrossoveredBudgetController
    {
        
        [HttpPost]
        [Route("{id}/action-budget-cancel")]
        public async Task<IActionResult> ActionBudgetCancelAsync(Guid id)
        {
            var result = await _appService.BudgetCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-budget-confirm")]
        public async Task<IActionResult> ActionBudgetConfirmAsync(Guid id)
        {
            var result = await _appService.BudgetConfirmAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-budget-done")]
        public async Task<IActionResult> ActionBudgetDoneAsync(Guid id)
        {
            var result = await _appService.BudgetDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-budget-draft")]
        public async Task<IActionResult> ActionBudgetDraftAsync(Guid id)
        {
            var result = await _appService.BudgetDraftAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-budget-validate")]
        public async Task<IActionResult> ActionBudgetValidateAsync(Guid id)
        {
            var result = await _appService.BudgetValidateAsync(id);
            return Ok(result);
        }
    }
}