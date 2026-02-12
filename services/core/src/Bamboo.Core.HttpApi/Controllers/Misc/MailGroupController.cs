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
    [Route("api/v1/MailGroup")]
    public partial class MailGroupController : AbpController
    {
        protected readonly IMailGroupAppService _appService;
        public MailGroupController(IMailGroupAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-close")]
        public async Task<IActionResult> CloseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CloseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-go-to-website")]
        public async Task<IActionResult> GoToWebsiteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GoToWebsiteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-join")]
        public async Task<IActionResult> JoinAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.JoinAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-leave")]
        public async Task<IActionResult> LeaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LeaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open")]
        public async Task<IActionResult> OpenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-guidelines")]
        public async Task<IActionResult> SendGuidelinesAsync([FromBody] MailGroupSendGuidelinesRequestDto input)
        {
            var result = await _appService.SendGuidelinesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync([FromBody] MailGroupMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync([FromBody] MailGroupMessagePostRequestDto input)
        {
            var result = await _appService.MessagePostAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-update")]
        public async Task<IActionResult> MessageUpdateAsync([FromBody] MailGroupMessageUpdateRequestDto input)
        {
            var result = await _appService.MessageUpdateAsync(input);
            return Ok(result);
        }
    }
    
}