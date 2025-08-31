using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    public partial class AccountAnalyticPlanController
    {
        
        [HttpPost]
        [Route("{id}/action-view-analytical-accounts")]
        public async Task<IActionResult> ActionViewAnalyticalAccountsAsync(Guid id)
        {
            var result = await _appService.ViewAnalyticalAccountsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-children-plans")]
        public async Task<IActionResult> ActionViewChildrenPlansAsync(Guid id)
        {
            var result = await _appService.ViewChildrenPlansAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-relevant-plans")]
        public async Task<IActionResult> GetRelevantPlansAsync(Guid id)
        {
            var result = await _appService.GetRelevantPlansAsync(id);
            return Ok(result);
        }
    }
}