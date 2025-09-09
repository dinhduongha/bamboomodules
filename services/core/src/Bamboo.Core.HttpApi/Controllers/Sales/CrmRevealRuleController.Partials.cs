using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteCrmIapReveal
{
    public partial class CrmRevealRuleController
    {
        
        [HttpPost]
        [Route("{id}/action-get-lead-tree-view")]
        public async Task<IActionResult> ActionGetLeadTreeViewAsync(Guid id)
        {
            var result = await _appService.GetLeadTreeViewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-get-opportunity-tree-view")]
        public async Task<IActionResult> ActionGetOpportunityTreeViewAsync(Guid id)
        {
            var result = await _appService.GetOpportunityTreeViewAsync(id);
            return Ok(result);
        }
    }
}