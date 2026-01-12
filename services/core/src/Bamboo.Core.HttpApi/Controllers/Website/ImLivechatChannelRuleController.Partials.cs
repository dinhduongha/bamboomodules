using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ImLivechatChannelRuleController
    {
        
        [HttpPost]
        [Route("{id}/match-rule")]
        public async Task<IActionResult> MatchRuleAsync(Guid id, [FromBody] ImLivechatChannelRuleMatchRuleRequestDto input)
        {
            var result = await _appService.MatchRuleAsync(id, input);
            return Ok(result);
        }
    }
}