using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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