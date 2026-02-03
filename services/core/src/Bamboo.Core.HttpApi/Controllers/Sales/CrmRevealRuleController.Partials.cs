using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CrmRevealRuleController
    {
        
        [HttpPost]
        [Route("action-get-lead-tree-view")]
        public async Task<IActionResult> ActionGetLeadTreeViewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetLeadTreeViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-opportunity-tree-view")]
        public async Task<IActionResult> ActionGetOpportunityTreeViewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetOpportunityTreeViewAsync(ids);
            return Ok(result);
        }
    }
}