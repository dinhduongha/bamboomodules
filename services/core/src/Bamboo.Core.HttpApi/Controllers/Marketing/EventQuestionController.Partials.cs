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
        [Route("{id}/action-event-view")]
        public async Task<IActionResult> ActionEventViewAsync(Guid id)
        {
            var result = await _appService.EventViewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-question-answers")]
        public async Task<IActionResult> ActionViewQuestionAnswersAsync(Guid id)
        {
            var result = await _appService.ViewQuestionAnswersAsync(id);
            return Ok(result);
        }
    }
}