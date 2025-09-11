using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class DiscussChannelController
    {
        
        [HttpPost]
        [Route("{id}/action-unfollow")]
        public async Task<IActionResult> ActionUnfollowAsync(Guid id)
        {
            var result = await _appService.UnfollowAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/add-members")]
        public async Task<IActionResult> AddMembersAsync(Guid id, [FromBody] DiscussChannelAddMembersRequestDto input)
        {
            var result = await _appService.AddMembersAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/channel-change-description")]
        public async Task<IActionResult> ChannelChangeDescriptionAsync(Guid id, [FromBody] DiscussChannelChannelChangeDescriptionRequestDto input)
        {
            var result = await _appService.ChannelChangeDescriptionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/channel-create")]
        public async Task<IActionResult> ChannelCreateAsync(Guid id, [FromBody] DiscussChannelChannelCreateRequestDto input)
        {
            var result = await _appService.ChannelCreateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/channel-fetched")]
        public async Task<IActionResult> ChannelFetchedAsync(Guid id)
        {
            var result = await _appService.ChannelFetchedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/channel-get")]
        public async Task<IActionResult> ChannelGetAsync(Guid id, [FromBody] DiscussChannelChannelGetRequestDto input)
        {
            var result = await _appService.ChannelGetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/channel-join")]
        public async Task<IActionResult> ChannelJoinAsync(Guid id)
        {
            var result = await _appService.ChannelJoinAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/channel-pin")]
        public async Task<IActionResult> ChannelPinAsync(Guid id, [FromBody] DiscussChannelChannelPinRequestDto input)
        {
            var result = await _appService.ChannelPinAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/channel-rename")]
        public async Task<IActionResult> ChannelRenameAsync(Guid id, [FromBody] DiscussChannelChannelRenameRequestDto input)
        {
            var result = await _appService.ChannelRenameAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/channel-set-custom-name")]
        public async Task<IActionResult> ChannelSetCustomNameAsync(Guid id, [FromBody] DiscussChannelChannelSetCustomNameRequestDto input)
        {
            var result = await _appService.ChannelSetCustomNameAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-group")]
        public async Task<IActionResult> CreateGroupAsync(Guid id, [FromBody] DiscussChannelCreateGroupRequestDto input)
        {
            var result = await _appService.CreateGroupAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/execute-command-help")]
        public async Task<IActionResult> ExecuteCommandHelpAsync(Guid id)
        {
            var result = await _appService.ExecuteCommandHelpAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/execute-command-history")]
        public async Task<IActionResult> ExecuteCommandHistoryAsync(Guid id)
        {
            var result = await _appService.ExecuteCommandHistoryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/execute-command-lead")]
        public async Task<IActionResult> ExecuteCommandLeadAsync(Guid id)
        {
            var result = await _appService.ExecuteCommandLeadAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/execute-command-leave")]
        public async Task<IActionResult> ExecuteCommandLeaveAsync(Guid id)
        {
            var result = await _appService.ExecuteCommandLeaveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/execute-command-who")]
        public async Task<IActionResult> ExecuteCommandWhoAsync(Guid id)
        {
            var result = await _appService.ExecuteCommandWhoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-mention-suggestions")]
        public async Task<IActionResult> GetMentionSuggestionsAsync(Guid id, [FromBody] DiscussChannelGetMentionSuggestionsRequestDto input)
        {
            var result = await _appService.GetMentionSuggestionsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid id)
        {
            var result = await _appService.MessagePostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-message-pin")]
        public async Task<IActionResult> SetMessagePinAsync(Guid id, [FromBody] DiscussChannelSetMessagePinRequestDto input)
        {
            var result = await _appService.SetMessagePinAsync(id, input);
            return Ok(result);
        }
    }
}