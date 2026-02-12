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
    [Route("api/v1/marketing/EventQuestionAnswer")]
    public partial class EventQuestionAnswerController : AbpController
    {
        protected readonly IEventQuestionAnswerAppService _appService;
        public EventQuestionAnswerController(IEventQuestionAnswerAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-rule-button")]
        public async Task<IActionResult> AddRuleButtonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddRuleButtonAsync(ids);
            return Ok(result);
        }
    }
    
}