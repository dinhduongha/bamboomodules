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
    [Route("api/v1/productivity/DiscussChannel")]
    public partial class DiscussChannelController : AbpController
    {
        protected readonly IDiscussChannelAppService _appService;
        public DiscussChannelController(IDiscussChannelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-unfollow")]
        public async Task<IActionResult> UnfollowAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnfollowAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-members")]
        public async Task<IActionResult> AddMembersAsync([FromBody] DiscussChannelAddMembersRequestDto input)
        {
            var result = await _appService.AddMembersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-change-description")]
        public async Task<IActionResult> ChannelChangeDescriptionAsync([FromBody] DiscussChannelChannelChangeDescriptionRequestDto input)
        {
            var result = await _appService.ChannelChangeDescriptionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-fetched")]
        public async Task<IActionResult> ChannelFetchedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ChannelFetchedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-join")]
        public async Task<IActionResult> ChannelJoinAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ChannelJoinAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-pin")]
        public async Task<IActionResult> ChannelPinAsync([FromBody] DiscussChannelChannelPinRequestDto input)
        {
            var result = await _appService.ChannelPinAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-rename")]
        public async Task<IActionResult> ChannelRenameAsync([FromBody] DiscussChannelChannelRenameRequestDto input)
        {
            var result = await _appService.ChannelRenameAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-set-custom-name")]
        public async Task<IActionResult> ChannelSetCustomNameAsync([FromBody] DiscussChannelChannelSetCustomNameRequestDto input)
        {
            var result = await _appService.ChannelSetCustomNameAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-help")]
        public async Task<IActionResult> ExecuteCommandHelpAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExecuteCommandHelpAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-history")]
        public async Task<IActionResult> ExecuteCommandHistoryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExecuteCommandHistoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-lead")]
        public async Task<IActionResult> ExecuteCommandLeadAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExecuteCommandLeadAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-leave")]
        public async Task<IActionResult> ExecuteCommandLeaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExecuteCommandLeaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-who")]
        public async Task<IActionResult> ExecuteCommandWhoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExecuteCommandWhoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mention-suggestions")]
        public async Task<IActionResult> GetMentionSuggestionsAsync([FromBody] DiscussChannelGetMentionSuggestionsRequestDto input)
        {
            var result = await _appService.GetMentionSuggestionsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("invite-by-email")]
        public async Task<IActionResult> InviteByEmailAsync([FromBody] DiscussChannelInviteByEmailRequestDto input)
        {
            var result = await _appService.InviteByEmailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("livechat-join-channel-needing-help")]
        public async Task<IActionResult> LivechatJoinChannelNeedingHelpAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LivechatJoinChannelNeedingHelpAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-message-pin")]
        public async Task<IActionResult> SetMessagePinAsync([FromBody] DiscussChannelSetMessagePinRequestDto input)
        {
            var result = await _appService.SetMessagePinAsync(input);
            return Ok(result);
        }
    }
    
}