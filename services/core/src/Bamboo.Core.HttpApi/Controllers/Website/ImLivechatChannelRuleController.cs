using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/website/ImLivechatChannelRule")]
    public partial class ImLivechatChannelRuleController : AbpController
    {
        protected readonly IImLivechatChannelRuleAppService _appService;
        public ImLivechatChannelRuleController(IImLivechatChannelRuleAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("match-rule")]
        public async Task<IActionResult> MatchRuleAsync([FromBody] ImLivechatChannelRuleMatchRuleRequestDto input)
        {
            var result = await _appService.MatchRuleAsync(input);
            return Ok(result);
        }
    }
    
}