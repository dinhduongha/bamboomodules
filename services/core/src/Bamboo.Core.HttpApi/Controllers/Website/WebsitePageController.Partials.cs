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
        [Route("{id}/action-page-debug-view")]
        public async Task<IActionResult> ActionPageDebugViewAsync(Guid id)
        {
            var result = await _appService.PageDebugViewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/clone-page")]
        public async Task<IActionResult> ClonePageAsync(Guid id, [FromBody] WebsitePageClonePageRequestDto input)
        {
            var result = await _appService.ClonePageAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] WebsitePageCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-website-meta")]
        public async Task<IActionResult> GetWebsiteMetaAsync(Guid id)
        {
            var result = await _appService.GetWebsiteMetaAsync(id);
            return Ok(result);
        }
    }
}