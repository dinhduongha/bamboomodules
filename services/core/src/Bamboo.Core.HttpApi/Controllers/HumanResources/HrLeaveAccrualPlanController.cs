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
    [Route("api/v1/human-resources/HrLeaveAccrualPlan")]
    public partial class HrLeaveAccrualPlanController : AbpController
    {
        protected readonly IHrLeaveAccrualPlanAppService _appService;
        public HrLeaveAccrualPlanController(IHrLeaveAccrualPlanAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-create-accrual-plan-level")]
        public async Task<IActionResult> CreateAccrualPlanLevelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateAccrualPlanLevelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-accrual-plan-employees")]
        public async Task<IActionResult> OpenAccrualPlanEmployeesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAccrualPlanEmployeesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-accrual-plan-level")]
        public async Task<IActionResult> OpenAccrualPlanLevelAsync([FromBody] HrLeaveAccrualPlanOpenAccrualPlanLevelRequestDto input)
        {
            var result = await _appService.OpenAccrualPlanLevelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] HrLeaveAccrualPlanCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
    
}