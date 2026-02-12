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
    [Route("api/v1/website/ImLivechatChannelMemberHistory")]
    public partial class ImLivechatChannelMemberHistoryController : AbpController
    {
        protected readonly IImLivechatChannelMemberHistoryAppService _appService;
        public ImLivechatChannelMemberHistoryController(IImLivechatChannelMemberHistoryAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-discuss-channel-view")]
        public async Task<IActionResult> OpenDiscussChannelViewAsync([FromBody] ImLivechatChannelMemberHistoryOpenDiscussChannelViewRequestDto input)
        {
            var result = await _appService.OpenDiscussChannelViewAsync(input);
            return Ok(result);
        }
    }
    
}