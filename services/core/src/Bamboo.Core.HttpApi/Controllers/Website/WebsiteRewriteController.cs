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
    [Route("api/v1/website/WebsiteRewrite")]
    public partial class WebsiteRewriteController : AbpController
    {
        protected readonly IWebsiteRewriteAppService _appService;
        public WebsiteRewriteController(IWebsiteRewriteAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("refresh-routes")]
        public async Task<IActionResult> RefreshRoutesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefreshRoutesAsync(ids);
            return Ok(result);
        }
    }
    
}