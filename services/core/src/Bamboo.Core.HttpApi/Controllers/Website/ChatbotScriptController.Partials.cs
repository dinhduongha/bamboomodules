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
        [Route("action-test-script")]
        public async Task<IActionResult> ActionTestScriptAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TestScriptAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-leads")]
        public async Task<IActionResult> ActionViewLeadsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-livechat-channels")]
        public async Task<IActionResult> ActionViewLivechatChannelsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewLivechatChannelsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(ChatbotScriptCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
}