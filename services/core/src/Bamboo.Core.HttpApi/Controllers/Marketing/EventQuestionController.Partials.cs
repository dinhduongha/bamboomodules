using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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