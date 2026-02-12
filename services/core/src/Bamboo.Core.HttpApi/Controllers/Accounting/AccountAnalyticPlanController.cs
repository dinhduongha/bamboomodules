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
    [Route("api/v1/accounting/AccountAnalyticPlan")]
    public partial class AccountAnalyticPlanController : AbpController
    {
        protected readonly IAccountAnalyticPlanAppService _appService;
        public AccountAnalyticPlanController(IAccountAnalyticPlanAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-view-analytical-accounts")]
        public async Task<IActionResult> ViewAnalyticalAccountsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewAnalyticalAccountsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-children-plans")]
        public async Task<IActionResult> ViewChildrenPlansAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewChildrenPlansAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-relevant-plans")]
        public async Task<IActionResult> GetRelevantPlansAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetRelevantPlansAsync(ids);
            return Ok(result);
        }
    }
    
}