using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrMailServerController
    {
        
        [HttpPost]
        [Route("action-retrieve-max-email-size")]
        public async Task<IActionResult> ActionRetrieveMaxEmailSizeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RetrieveMaxEmailSizeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("send-email")]
        public async Task<IActionResult> SendEmailAsync(IrMailServerSendEmailRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SendEmailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("test-smtp-connection")]
        public async Task<IActionResult> TestSmtpConnectionAsync(IrMailServerTestSmtpConnectionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.TestSmtpConnectionAsync(input);
            return Ok(result);
        }
    }
}