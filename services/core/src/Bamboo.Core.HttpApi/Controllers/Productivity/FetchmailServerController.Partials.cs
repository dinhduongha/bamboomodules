using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class FetchmailServerController
    {
        
        [HttpPost]
        [Route("button-confirm-login")]
        public async Task<IActionResult> ButtonConfirmLoginAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonConfirmLoginAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fetch-mail")]
        public async Task<IActionResult> FetchMailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.FetchMailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-server-type")]
        public async Task<IActionResult> OnchangeServerTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeServerTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-draft")]
        public async Task<IActionResult> SetDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetDraftAsync(ids);
            return Ok(result);
        }
    }
}