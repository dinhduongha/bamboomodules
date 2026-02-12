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
    [Route("api/v1/productivity/FetchmailServer")]
    public partial class FetchmailServerController : AbpController
    {
        protected readonly IFetchmailServerAppService _appService;
        public FetchmailServerController(IFetchmailServerAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("button-confirm-login")]
        public async Task<IActionResult> ButtonConfirmLoginAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonConfirmLoginAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fetch-mail")]
        public async Task<IActionResult> FetchMailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.FetchMailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-server-type")]
        public async Task<IActionResult> OnchangeServerTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeServerTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-draft")]
        public async Task<IActionResult> SetDraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetDraftAsync(ids);
            return Ok(result);
        }
    }
    
}