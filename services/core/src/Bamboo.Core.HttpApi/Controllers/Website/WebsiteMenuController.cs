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
    [Route("api/v1/website/WebsiteMenu")]
    public partial class WebsiteMenuController : AbpController
    {
        protected readonly IWebsiteMenuAppService _appService;
        public WebsiteMenuController(IWebsiteMenuAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-tree")]
        public async Task<IActionResult> GetTreeAsync([FromBody] WebsiteMenuGetTreeRequestDto input)
        {
            var result = await _appService.GetTreeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveAsync([FromBody] WebsiteMenuSaveRequestDto input)
        {
            var result = await _appService.SaveAsync(input);
            return Ok(result);
        }
    }
    
}