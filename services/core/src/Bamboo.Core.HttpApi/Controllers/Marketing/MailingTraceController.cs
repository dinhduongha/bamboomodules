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
    [Route("api/v1/marketing/MailingTrace")]
    public partial class MailingTraceController : AbpController
    {
        protected readonly IMailingTraceAppService _appService;
        public MailingTraceController(IMailingTraceAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-view-contact")]
        public async Task<IActionResult> ViewContactAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewContactAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-bounced")]
        public async Task<IActionResult> SetBouncedAsync([FromBody] MailingTraceSetBouncedRequestDto input)
        {
            var result = await _appService.SetBouncedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-canceled")]
        public async Task<IActionResult> SetCanceledAsync([FromBody] MailingTraceSetCanceledRequestDto input)
        {
            var result = await _appService.SetCanceledAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-clicked")]
        public async Task<IActionResult> SetClickedAsync([FromBody] MailingTraceSetClickedRequestDto input)
        {
            var result = await _appService.SetClickedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-failed")]
        public async Task<IActionResult> SetFailedAsync([FromBody] MailingTraceSetFailedRequestDto input)
        {
            var result = await _appService.SetFailedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-opened")]
        public async Task<IActionResult> SetOpenedAsync([FromBody] MailingTraceSetOpenedRequestDto input)
        {
            var result = await _appService.SetOpenedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-replied")]
        public async Task<IActionResult> SetRepliedAsync([FromBody] MailingTraceSetRepliedRequestDto input)
        {
            var result = await _appService.SetRepliedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sent")]
        public async Task<IActionResult> SetSentAsync([FromBody] MailingTraceSetSentRequestDto input)
        {
            var result = await _appService.SetSentAsync(input);
            return Ok(result);
        }
    }
    
}