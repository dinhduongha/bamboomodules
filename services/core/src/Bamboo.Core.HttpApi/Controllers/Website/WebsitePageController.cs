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
    [Route("api/v1/website/WebsitePage")]
    public partial class WebsitePageController : AbpController
    {
        protected readonly IWebsitePageAppService _appService;
        public WebsitePageController(IWebsitePageAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-page-debug-view")]
        public async Task<IActionResult> PageDebugViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PageDebugViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("clone-page")]
        public async Task<IActionResult> ClonePageAsync([FromBody] WebsitePageClonePageRequestDto input)
        {
            var result = await _appService.ClonePageAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] WebsitePageCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-website-meta")]
        public async Task<IActionResult> GetWebsiteMetaAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetWebsiteMetaAsync(ids);
            return Ok(result);
        }
    }
    
}