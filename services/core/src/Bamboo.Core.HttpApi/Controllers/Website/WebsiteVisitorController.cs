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
    [Route("api/v1/website/WebsiteVisitor")]
    public partial class WebsiteVisitorController : AbpController
    {
        protected readonly IWebsiteVisitorAppService _appService;
        public WebsiteVisitorController(IWebsiteVisitorAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-send-chat-request")]
        public async Task<IActionResult> SendChatRequestAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendChatRequestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-mail")]
        public async Task<IActionResult> SendMailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendMailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-sms")]
        public async Task<IActionResult> SendSmsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendSmsAsync(ids);
            return Ok(result);
        }
    }
    
}