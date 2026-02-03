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
        [Route("action-send-chat-request")]
        public async Task<IActionResult> ActionSendChatRequestAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendChatRequestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mail")]
        public async Task<IActionResult> ActionSendMailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendMailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-sms")]
        public async Task<IActionResult> ActionSendSmsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendSmsAsync(ids);
            return Ok(result);
        }
    }
}