using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventQuestionController
    {
        
        [HttpPost]
        [Route("action-event-view")]
        public async Task<IActionResult> ActionEventViewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.EventViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-question-answers")]
        public async Task<IActionResult> ActionViewQuestionAnswersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewQuestionAnswersAsync(ids);
            return Ok(result);
        }
    }
}