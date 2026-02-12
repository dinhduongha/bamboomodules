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
    [Route("api/v1/accounting/CrossoveredBudget")]
    public partial class CrossoveredBudgetController : AbpController
    {
        protected readonly ICrossoveredBudgetAppService _appService;
        public CrossoveredBudgetController(ICrossoveredBudgetAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-budget-cancel")]
        public async Task<IActionResult> BudgetCancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BudgetCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-budget-confirm")]
        public async Task<IActionResult> BudgetConfirmAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BudgetConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-budget-done")]
        public async Task<IActionResult> BudgetDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BudgetDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-budget-draft")]
        public async Task<IActionResult> BudgetDraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BudgetDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-budget-validate")]
        public async Task<IActionResult> BudgetValidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BudgetValidateAsync(ids);
            return Ok(result);
        }
    }
    
}