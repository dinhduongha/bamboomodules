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
    [Route("api/v1/website/ImLivechatChannel")]
    public partial class ImLivechatChannelController : AbpController
    {
        protected readonly IImLivechatChannelAppService _appService;
        public ImLivechatChannelController(IImLivechatChannelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-join")]
        public async Task<IActionResult> JoinAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.JoinAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-quit")]
        public async Task<IActionResult> QuitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.QuitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-chatbot-scripts")]
        public async Task<IActionResult> ViewChatbotScriptsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewChatbotScriptsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-rating")]
        public async Task<IActionResult> ViewRatingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRatingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-livechat-info")]
        public async Task<IActionResult> GetLivechatInfoAsync([FromBody] ImLivechatChannelGetLivechatInfoRequestDto input)
        {
            var result = await _appService.GetLivechatInfoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-read")]
        public async Task<IActionResult> WebReadAsync([FromBody] ImLivechatChannelWebReadRequestDto input)
        {
            var result = await _appService.WebReadAsync(input);
            return Ok(result);
        }
    }
    
}