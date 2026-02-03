using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ImLivechatChannelMemberHistoryController
    {
        
        [HttpPost]
        [Route("action-open-discuss-channel-view")]
        public async Task<IActionResult> ActionOpenDiscussChannelViewAsync(ImLivechatChannelMemberHistoryOpenDiscussChannelViewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.OpenDiscussChannelViewAsync(input);
            return Ok(result);
        }
    }
}