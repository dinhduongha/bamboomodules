using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrLeaveAccrualPlanController
    {
        
        [HttpPost]
        [Route("{id}/action-create-accrual-plan-level")]
        public async Task<IActionResult> ActionCreateAccrualPlanLevelAsync(Guid id)
        {
            var result = await _appService.CreateAccrualPlanLevelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-accrual-plan-employees")]
        public async Task<IActionResult> ActionOpenAccrualPlanEmployeesAsync(Guid id)
        {
            var result = await _appService.OpenAccrualPlanEmployeesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-accrual-plan-level")]
        public async Task<IActionResult> ActionOpenAccrualPlanLevelAsync(Guid id, [FromBody] HrLeaveAccrualPlanOpenAccrualPlanLevelRequestDto input)
        {
            var result = await _appService.OpenAccrualPlanLevelAsync(id, input);
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