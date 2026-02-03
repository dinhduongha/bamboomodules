using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class WebsitePageController
    {
        
        [HttpPost]
        [Route("action-page-debug-view")]
        public async Task<IActionResult> ActionPageDebugViewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PageDebugViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("clone-page")]
        public async Task<IActionResult> ClonePageAsync(WebsitePageClonePageRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ClonePageAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(WebsitePageCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-website-meta")]
        public async Task<IActionResult> GetWebsiteMetaAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetWebsiteMetaAsync(ids);
            return Ok(result);
        }
    }
}