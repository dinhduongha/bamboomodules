using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailGroupMessageController
    {
        
        [HttpPost]
        [Route("action-moderate-accept")]
        public async Task<IActionResult> ActionModerateAcceptAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ModerateAcceptAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-allow")]
        public async Task<IActionResult> ActionModerateAllowAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ModerateAllowAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-ban")]
        public async Task<IActionResult> ActionModerateBanAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ModerateBanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-ban-with-comment")]
        public async Task<IActionResult> ActionModerateBanWithCommentAsync(MailGroupMessageModerateBanWithCommentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ModerateBanWithCommentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-reject")]
        public async Task<IActionResult> ActionModerateRejectAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ModerateRejectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-reject-with-comment")]
        public async Task<IActionResult> ActionModerateRejectWithCommentAsync(MailGroupMessageModerateRejectWithCommentRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ModerateRejectWithCommentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(MailGroupMessageCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
}