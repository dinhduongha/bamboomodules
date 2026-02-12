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
    [Route("api/v1/marketing/EventQuestion")]
    public partial class EventQuestionController : AbpController
    {
        protected readonly IEventQuestionAppService _appService;
        public EventQuestionController(IEventQuestionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-event-view")]
        public async Task<IActionResult> EventViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.EventViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-question-answers")]
        public async Task<IActionResult> ViewQuestionAnswersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewQuestionAnswersAsync(ids);
            return Ok(result);
        }
    }
    
}