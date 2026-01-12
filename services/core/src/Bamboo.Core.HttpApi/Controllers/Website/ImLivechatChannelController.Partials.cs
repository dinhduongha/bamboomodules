using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ImLivechatChannelController
    {
        
        [HttpPost]
        [Route("{id}/action-join")]
        public async Task<IActionResult> ActionJoinAsync(Guid id)
        {
            var result = await _appService.JoinAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-quit")]
        public async Task<IActionResult> ActionQuitAsync(Guid id)
        {
            var result = await _appService.QuitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-chatbot-scripts")]
        public async Task<IActionResult> ActionViewChatbotScriptsAsync(Guid id)
        {
            var result = await _appService.ViewChatbotScriptsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-rating")]
        public async Task<IActionResult> ActionViewRatingAsync(Guid id)
        {
            var result = await _appService.ViewRatingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-livechat-info")]
        public async Task<IActionResult> GetLivechatInfoAsync(Guid id, [FromBody] ImLivechatChannelGetLivechatInfoRequestDto input)
        {
            var result = await _appService.GetLivechatInfoAsync(id, input);
            return Ok(result);
        }
    }
}