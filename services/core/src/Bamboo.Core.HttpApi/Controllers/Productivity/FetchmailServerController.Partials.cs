using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class FetchmailServerController
    {
        
        [HttpPost]
        [Route("{id}/button-confirm-login")]
        public async Task<IActionResult> ButtonConfirmLoginAsync(Guid id)
        {
            var result = await _appService.ButtonConfirmLoginAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/connect")]
        public async Task<IActionResult> ConnectAsync(Guid id, [FromBody] FetchmailServerConnectRequestDto input)
        {
            var result = await _appService.ConnectAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fetch-mail")]
        public async Task<IActionResult> FetchMailAsync(Guid id, [FromBody] FetchmailServerFetchMailRequestDto input)
        {
            var result = await _appService.FetchMailAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-server-type")]
        public async Task<IActionResult> OnchangeServerTypeAsync(Guid id)
        {
            var result = await _appService.OnchangeServerTypeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-draft")]
        public async Task<IActionResult> SetDraftAsync(Guid id)
        {
            var result = await _appService.SetDraftAsync(id);
            return Ok(result);
        }
    }
}