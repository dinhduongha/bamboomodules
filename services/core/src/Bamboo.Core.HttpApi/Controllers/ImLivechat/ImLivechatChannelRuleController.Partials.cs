using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.ImLivechat
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