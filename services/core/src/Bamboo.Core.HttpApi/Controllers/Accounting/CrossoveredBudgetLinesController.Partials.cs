using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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