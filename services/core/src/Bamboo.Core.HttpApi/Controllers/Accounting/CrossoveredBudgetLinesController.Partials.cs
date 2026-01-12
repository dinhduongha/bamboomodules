using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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