using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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