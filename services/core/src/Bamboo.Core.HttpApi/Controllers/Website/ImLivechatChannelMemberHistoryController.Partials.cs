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
        [Route("{id}/action-open-discuss-channel-view")]
        public async Task<IActionResult> ActionOpenDiscussChannelViewAsync(Guid id, [FromBody] ImLivechatChannelMemberHistoryOpenDiscussChannelViewRequestDto input)
        {
            var result = await _appService.OpenDiscussChannelViewAsync(id, input);
            return Ok(result);
        }
    }
}