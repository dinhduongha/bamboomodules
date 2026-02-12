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
    [Route("api/v1/website/ChatbotScript")]
    public partial class ChatbotScriptController : AbpController
    {
        protected readonly IChatbotScriptAppService _appService;
        public ChatbotScriptController(IChatbotScriptAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-test-script")]
        public async Task<IActionResult> TestScriptAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TestScriptAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-leads")]
        public async Task<IActionResult> ViewLeadsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-livechat-channels")]
        public async Task<IActionResult> ViewLivechatChannelsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewLivechatChannelsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ChatbotScriptCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
    
}