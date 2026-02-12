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
    [Route("api/v1/sales/CrmRevealRule")]
    public partial class CrmRevealRuleController : AbpController
    {
        protected readonly ICrmRevealRuleAppService _appService;
        public CrmRevealRuleController(ICrmRevealRuleAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-get-lead-tree-view")]
        public async Task<IActionResult> GetLeadTreeViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetLeadTreeViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-opportunity-tree-view")]
        public async Task<IActionResult> GetOpportunityTreeViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetOpportunityTreeViewAsync(ids);
            return Ok(result);
        }
    }
    
}