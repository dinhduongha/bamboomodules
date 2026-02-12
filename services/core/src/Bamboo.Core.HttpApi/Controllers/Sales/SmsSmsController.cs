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
    [Route("api/v1/sales/SmsSms")]
    public partial class SmsSmsController : AbpController
    {
        protected readonly ISmsSmsAppService _appService;
        public SmsSmsController(ISmsSmsAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-set-canceled")]
        public async Task<IActionResult> SetCanceledAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetCanceledAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-error")]
        public async Task<IActionResult> SetErrorAsync([FromBody] SmsSmsSetErrorRequestDto input)
        {
            var result = await _appService.SetErrorAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-outgoing")]
        public async Task<IActionResult> SetOutgoingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetOutgoingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("resend-failed")]
        public async Task<IActionResult> ResendFailedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResendFailedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendAsync([FromBody] SmsSmsSendRequestDto input)
        {
            var result = await _appService.SendAsync(input);
            return Ok(result);
        }
    }
    
}