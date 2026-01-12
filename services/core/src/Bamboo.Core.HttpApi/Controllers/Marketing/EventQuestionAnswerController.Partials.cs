using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventQuestionAnswerController
    {
        
        [HttpPost]
        [Route("{id}/action-add-rule-button")]
        public async Task<IActionResult> ActionAddRuleButtonAsync(Guid id)
        {
            var result = await _appService.AddRuleButtonAsync(id);
            return Ok(result);
        }
    }
}