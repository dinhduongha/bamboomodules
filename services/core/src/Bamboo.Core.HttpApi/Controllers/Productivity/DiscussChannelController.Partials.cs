using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class DiscussChannelController
    {
        
        [HttpPost]
        [Route("action-unfollow")]
        public async Task<IActionResult> ActionUnfollowAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnfollowAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-members")]
        public async Task<IActionResult> AddMembersAsync(DiscussChannelAddMembersRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AddMembersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-change-description")]
        public async Task<IActionResult> ChannelChangeDescriptionAsync(DiscussChannelChannelChangeDescriptionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ChannelChangeDescriptionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-fetched")]
        public async Task<IActionResult> ChannelFetchedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ChannelFetchedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-join")]
        public async Task<IActionResult> ChannelJoinAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ChannelJoinAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-pin")]
        public async Task<IActionResult> ChannelPinAsync(DiscussChannelChannelPinRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ChannelPinAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-rename")]
        public async Task<IActionResult> ChannelRenameAsync(DiscussChannelChannelRenameRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ChannelRenameAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("channel-set-custom-name")]
        public async Task<IActionResult> ChannelSetCustomNameAsync(DiscussChannelChannelSetCustomNameRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ChannelSetCustomNameAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-help")]
        public async Task<IActionResult> ExecuteCommandHelpAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExecuteCommandHelpAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-history")]
        public async Task<IActionResult> ExecuteCommandHistoryAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExecuteCommandHistoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-lead")]
        public async Task<IActionResult> ExecuteCommandLeadAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExecuteCommandLeadAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-leave")]
        public async Task<IActionResult> ExecuteCommandLeaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExecuteCommandLeaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute-command-who")]
        public async Task<IActionResult> ExecuteCommandWhoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExecuteCommandWhoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mention-suggestions")]
        public async Task<IActionResult> GetMentionSuggestionsAsync(DiscussChannelGetMentionSuggestionsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetMentionSuggestionsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("invite-by-email")]
        public async Task<IActionResult> InviteByEmailAsync(DiscussChannelInviteByEmailRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.InviteByEmailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("livechat-join-channel-needing-help")]
        public async Task<IActionResult> LivechatJoinChannelNeedingHelpAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LivechatJoinChannelNeedingHelpAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-message-pin")]
        public async Task<IActionResult> SetMessagePinAsync(DiscussChannelSetMessagePinRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetMessagePinAsync(input);
            return Ok(result);
        }
    }
}