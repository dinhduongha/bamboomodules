using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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