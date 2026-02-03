using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailGroupController
    {
        
        [HttpPost]
        [Route("action-close")]
        public async Task<IActionResult> ActionCloseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-go-to-website")]
        public async Task<IActionResult> ActionGoToWebsiteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GoToWebsiteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-join")]
        public async Task<IActionResult> ActionJoinAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.JoinAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-leave")]
        public async Task<IActionResult> ActionLeaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LeaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open")]
        public async Task<IActionResult> ActionOpenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-guidelines")]
        public async Task<IActionResult> ActionSendGuidelinesAsync(MailGroupSendGuidelinesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendGuidelinesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync(MailGroupMessageNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync(MailGroupMessagePostRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessagePostAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-update")]
        public async Task<IActionResult> MessageUpdateAsync(MailGroupMessageUpdateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageUpdateAsync(input);
            return Ok(result);
        }
    }
}