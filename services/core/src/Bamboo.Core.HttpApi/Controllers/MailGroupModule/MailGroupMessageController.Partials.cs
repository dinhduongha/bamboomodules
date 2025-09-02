using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MailGroupModule
{
    public partial class MailGroupMessageController
    {
        
        [HttpPost]
        [Route("{id}/action-moderate-accept")]
        public async Task<IActionResult> ActionModerateAcceptAsync(Guid id)
        {
            var result = await _appService.ModerateAcceptAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-moderate-allow")]
        public async Task<IActionResult> ActionModerateAllowAsync(Guid id)
        {
            var result = await _appService.ModerateAllowAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-moderate-ban")]
        public async Task<IActionResult> ActionModerateBanAsync(Guid id)
        {
            var result = await _appService.ModerateBanAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-moderate-ban-with-comment")]
        public async Task<IActionResult> ActionModerateBanWithCommentAsync(Guid id, [FromBody] MailGroupMessageModerateBanWithCommentRequestDto input)
        {
            var result = await _appService.ModerateBanWithCommentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-moderate-reject")]
        public async Task<IActionResult> ActionModerateRejectAsync(Guid id)
        {
            var result = await _appService.ModerateRejectAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-moderate-reject-with-comment")]
        public async Task<IActionResult> ActionModerateRejectWithCommentAsync(Guid id, [FromBody] MailGroupMessageModerateRejectWithCommentRequestDto input)
        {
            var result = await _appService.ModerateRejectWithCommentAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] MailGroupMessageCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
    }
}