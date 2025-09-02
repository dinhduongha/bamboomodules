using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.MailGroupModule
{
    public partial class MailGroupController
    {
        
        [HttpPost]
        [Route("{id}/action-go-to-website")]
        public async Task<IActionResult> ActionGoToWebsiteAsync(Guid id)
        {
            var result = await _appService.GoToWebsiteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-join")]
        public async Task<IActionResult> ActionJoinAsync(Guid id)
        {
            var result = await _appService.JoinAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-leave")]
        public async Task<IActionResult> ActionLeaveAsync(Guid id)
        {
            var result = await _appService.LeaveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-guidelines")]
        public async Task<IActionResult> ActionSendGuidelinesAsync(Guid id, [FromBody] MailGroupSendGuidelinesRequestDto input)
        {
            var result = await _appService.SendGuidelinesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-new")]
        public async Task<IActionResult> MessageNewAsync(Guid id, [FromBody] MailGroupMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid id, [FromBody] MailGroupMessagePostRequestDto input)
        {
            var result = await _appService.MessagePostAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-update")]
        public async Task<IActionResult> MessageUpdateAsync(Guid id, [FromBody] MailGroupMessageUpdateRequestDto input)
        {
            var result = await _appService.MessageUpdateAsync(id, input);
            return Ok(result);
        }
    }
}