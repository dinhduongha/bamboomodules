using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventLeadRuleController
    {
        
        [HttpPost]
        [Route("{id}/action-execute-rule")]
        public async Task<IActionResult> ActionExecuteRuleAsync(Guid id)
        {
            var result = await _appService.ExecuteRuleAsync(id);
            return Ok(result);
        }
    }
}