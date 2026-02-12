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
    [Route("api/v1/website/WebsiteTechnicalPage")]
    public partial class WebsiteTechnicalPageController : AbpController
    {
        protected readonly IWebsiteTechnicalPageAppService _appService;
        public WebsiteTechnicalPageController(IWebsiteTechnicalPageAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-static-routes")]
        public async Task<IActionResult> GetStaticRoutesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetStaticRoutesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenWebsiteUrlAsync(ids);
            return Ok(result);
        }
    }
    
}