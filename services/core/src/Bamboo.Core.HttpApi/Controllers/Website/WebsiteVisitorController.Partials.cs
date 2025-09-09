using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    public partial class WebsiteVisitorController
    {
        
        [HttpPost]
        [Route("{id}/action-send-chat-request")]
        public async Task<IActionResult> ActionSendChatRequestAsync(Guid id)
        {
            var result = await _appService.SendChatRequestAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-mail")]
        public async Task<IActionResult> ActionSendMailAsync(Guid id)
        {
            var result = await _appService.SendMailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-sms")]
        public async Task<IActionResult> ActionSendSmsAsync(Guid id)
        {
            var result = await _appService.SendSmsAsync(id);
            return Ok(result);
        }
    }
}