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
        [Route("action-join")]
        public async Task<IActionResult> ActionJoinAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.JoinAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-quit")]
        public async Task<IActionResult> ActionQuitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.QuitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-chatbot-scripts")]
        public async Task<IActionResult> ActionViewChatbotScriptsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewChatbotScriptsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-rating")]
        public async Task<IActionResult> ActionViewRatingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRatingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-livechat-info")]
        public async Task<IActionResult> GetLivechatInfoAsync(ImLivechatChannelGetLivechatInfoRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetLivechatInfoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-read")]
        public async Task<IActionResult> WebReadAsync(ImLivechatChannelWebReadRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.WebReadAsync(input);
            return Ok(result);
        }
    }
}