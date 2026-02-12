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
    [Route("api/v1/accounting/CrossoveredBudgetLines")]
    public partial class CrossoveredBudgetLinesController : AbpController
    {
        protected readonly ICrossoveredBudgetLinesAppService _appService;
        public CrossoveredBudgetLinesController(ICrossoveredBudgetLinesAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-budget-entries")]
        public async Task<IActionResult> OpenBudgetEntriesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenBudgetEntriesAsync(ids);
            return Ok(result);
        }
    }
    
}