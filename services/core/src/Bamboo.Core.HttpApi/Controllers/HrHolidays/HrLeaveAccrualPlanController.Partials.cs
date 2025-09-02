using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrHolidays
{
    public partial class HrLeaveAccrualPlanController
    {
        
        [HttpPost]
        [Route("{id}/action-open-accrual-plan-employees")]
        public async Task<IActionResult> ActionOpenAccrualPlanEmployeesAsync(Guid id)
        {
            var result = await _appService.OpenAccrualPlanEmployeesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] HrLeaveAccrualPlanCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
    }
}