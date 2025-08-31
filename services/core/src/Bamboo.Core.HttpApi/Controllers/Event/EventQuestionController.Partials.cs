using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    public partial class EventQuestionController
    {
        
        [HttpPost]
        [Route("{id}/action-view-question-answers")]
        public async Task<IActionResult> ActionViewQuestionAnswersAsync(Guid id)
        {
            var result = await _appService.ViewQuestionAnswersAsync(id);
            return Ok(result);
        }
    }
}