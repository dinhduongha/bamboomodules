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
    [Route("api/v1/MailGroupMessage")]
    public partial class MailGroupMessageController : AbpController
    {
        protected readonly IMailGroupMessageAppService _appService;
        public MailGroupMessageController(IMailGroupMessageAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-moderate-accept")]
        public async Task<IActionResult> ModerateAcceptAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ModerateAcceptAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-allow")]
        public async Task<IActionResult> ModerateAllowAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ModerateAllowAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-ban")]
        public async Task<IActionResult> ModerateBanAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ModerateBanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-ban-with-comment")]
        public async Task<IActionResult> ModerateBanWithCommentAsync([FromBody] MailGroupMessageModerateBanWithCommentRequestDto input)
        {
            var result = await _appService.ModerateBanWithCommentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-reject")]
        public async Task<IActionResult> ModerateRejectAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ModerateRejectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-moderate-reject-with-comment")]
        public async Task<IActionResult> ModerateRejectWithCommentAsync([FromBody] MailGroupMessageModerateRejectWithCommentRequestDto input)
        {
            var result = await _appService.ModerateRejectWithCommentAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] MailGroupMessageCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
    
}