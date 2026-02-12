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
    [Route("api/v1/productivity/MailScheduledMessage")]
    public partial class MailScheduledMessageController : AbpController
    {
        protected readonly IMailScheduledMessageAppService _appService;
        public MailScheduledMessageController(IMailScheduledMessageAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("open-edit-form")]
        public async Task<IActionResult> OpenEditFormAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenEditFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("post-message")]
        public async Task<IActionResult> PostMessageAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PostMessageAsync(ids);
            return Ok(result);
        }
    }
    
}