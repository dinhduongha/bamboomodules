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
        [Route("match-rule")]
        public async Task<IActionResult> MatchRuleAsync(ImLivechatChannelRuleMatchRuleRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MatchRuleAsync(input);
            return Ok(result);
        }
    }
}