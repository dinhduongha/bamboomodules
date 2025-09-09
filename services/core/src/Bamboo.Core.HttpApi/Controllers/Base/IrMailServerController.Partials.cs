using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrMailServerController
    {
        
        [HttpPost]
        [Route("{id}/action-retrieve-max-email-size")]
        public async Task<IActionResult> ActionRetrieveMaxEmailSizeAsync(Guid id)
        {
            var result = await _appService.RetrieveMaxEmailSizeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/build-email")]
        public async Task<IActionResult> BuildEmailAsync(Guid id, [FromBody] IrMailServerBuildEmailRequestDto input)
        {
            var result = await _appService.BuildEmailAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/connect")]
        public async Task<IActionResult> ConnectAsync(Guid id, [FromBody] IrMailServerConnectRequestDto input)
        {
            var result = await _appService.ConnectAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/send-email")]
        public async Task<IActionResult> SendEmailAsync(Guid id, [FromBody] IrMailServerSendEmailRequestDto input)
        {
            var result = await _appService.SendEmailAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/test-smtp-connection")]
        public async Task<IActionResult> TestSmtpConnectionAsync(Guid id, [FromBody] IrMailServerTestSmtpConnectionRequestDto input)
        {
            var result = await _appService.TestSmtpConnectionAsync(id, input);
            return Ok(result);
        }
    }
}