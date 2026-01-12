using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ChatbotScriptController
    {
        
        [HttpPost]
        [Route("{id}/action-test-script")]
        public async Task<IActionResult> ActionTestScriptAsync(Guid id)
        {
            var result = await _appService.TestScriptAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-leads")]
        public async Task<IActionResult> ActionViewLeadsAsync(Guid id)
        {
            var result = await _appService.ViewLeadsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-livechat-channels")]
        public async Task<IActionResult> ActionViewLivechatChannelsAsync(Guid id)
        {
            var result = await _appService.ViewLivechatChannelsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ChatbotScriptCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
    }
}