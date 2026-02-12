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
    [Route("api/v1/marketing/EventLeadRule")]
    public partial class EventLeadRuleController : AbpController
    {
        protected readonly IEventLeadRuleAppService _appService;
        public EventLeadRuleController(IEventLeadRuleAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-execute-rule")]
        public async Task<IActionResult> ExecuteRuleAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExecuteRuleAsync(ids);
            return Ok(result);
        }
    }
    
}