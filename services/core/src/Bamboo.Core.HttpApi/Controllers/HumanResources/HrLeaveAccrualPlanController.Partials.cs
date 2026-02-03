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
        [Route("action-create-accrual-plan-level")]
        public async Task<IActionResult> ActionCreateAccrualPlanLevelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateAccrualPlanLevelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-accrual-plan-employees")]
        public async Task<IActionResult> ActionOpenAccrualPlanEmployeesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAccrualPlanEmployeesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-accrual-plan-level")]
        public async Task<IActionResult> ActionOpenAccrualPlanLevelAsync(HrLeaveAccrualPlanOpenAccrualPlanLevelRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.OpenAccrualPlanLevelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(HrLeaveAccrualPlanCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
}