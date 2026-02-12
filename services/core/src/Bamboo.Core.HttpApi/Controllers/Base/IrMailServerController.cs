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
    [Route("api/v1/base/IrMailServer")]
    public partial class IrMailServerController : AbpController
    {
        protected readonly IIrMailServerAppService _appService;
        public IrMailServerController(IIrMailServerAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-retrieve-max-email-size")]
        public async Task<IActionResult> RetrieveMaxEmailSizeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RetrieveMaxEmailSizeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-email")]
        public async Task<IActionResult> SendEmailAsync([FromBody] IrMailServerSendEmailRequestDto input)
        {
            var result = await _appService.SendEmailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("test-smtp-connection")]
        public async Task<IActionResult> TestSmtpConnectionAsync([FromBody] IrMailServerTestSmtpConnectionRequestDto input)
        {
            var result = await _appService.TestSmtpConnectionAsync(input);
            return Ok(result);
        }
    }
    
}