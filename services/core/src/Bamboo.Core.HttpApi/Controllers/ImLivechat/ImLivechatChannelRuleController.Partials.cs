using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.ImLivechat
{
    public partial class ImLivechatChannelRuleController
    {
        
        [HttpPost]
        [Route("{id}/match-rule")]
        public async Task<IActionResult> MatchRuleAsync(Guid id, [FromBody] ImLivechatChannelRuleMatchRuleRequestDto input)
        {
            var result = await _appService.MatchRuleAsync(id, input.ChannelId, input.Url, input.CountryId);
            return Ok(result);
        }
    }
}