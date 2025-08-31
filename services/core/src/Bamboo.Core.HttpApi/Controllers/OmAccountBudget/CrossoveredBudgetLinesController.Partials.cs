using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.OmAccountBudget
{
    public partial class CrossoveredBudgetLinesController
    {
        
        [HttpPost]
        [Route("{id}/action-open-budget-entries")]
        public async Task<IActionResult> ActionOpenBudgetEntriesAsync(Guid id)
        {
            var result = await _appService.OpenBudgetEntriesAsync(id);
            return Ok(result);
        }
    }
}