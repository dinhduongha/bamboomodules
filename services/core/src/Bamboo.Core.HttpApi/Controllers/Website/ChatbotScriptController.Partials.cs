using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.ImLivechat
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