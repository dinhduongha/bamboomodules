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
    [Route("api/v1/productivity/MailTemplate")]
    public partial class MailTemplateController : AbpController
    {
        protected readonly IMailTemplateAppService _appService;
        public MailTemplateController(IMailTemplateAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-mail-preview")]
        public async Task<IActionResult> OpenMailPreviewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenMailPreviewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] MailTemplateCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-action")]
        public async Task<IActionResult> CreateActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-mail")]
        public async Task<IActionResult> SendMailAsync([FromBody] MailTemplateSendMailRequestDto input)
        {
            var result = await _appService.SendMailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-mail-batch")]
        public async Task<IActionResult> SendMailBatchAsync([FromBody] MailTemplateSendMailBatchRequestDto input)
        {
            var result = await _appService.SendMailBatchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-action")]
        public async Task<IActionResult> UnlinkActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnlinkActionAsync(ids);
            return Ok(result);
        }
    }
    
}