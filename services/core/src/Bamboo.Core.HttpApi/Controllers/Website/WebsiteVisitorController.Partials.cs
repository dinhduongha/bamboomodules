using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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