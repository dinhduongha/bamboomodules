using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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