using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountAnalyticPlanController
    {
        
        [HttpPost]
        [Route("action-view-analytical-accounts")]
        public async Task<IActionResult> ActionViewAnalyticalAccountsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewAnalyticalAccountsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-children-plans")]
        public async Task<IActionResult> ActionViewChildrenPlansAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewChildrenPlansAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-relevant-plans")]
        public async Task<IActionResult> GetRelevantPlansAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetRelevantPlansAsync(ids);
            return Ok(result);
        }
    }
}