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
    [Route("api/v1/website/BlogPost")]
    public partial class BlogPostController : AbpController
    {
        protected readonly IBlogPostAppService _appService;
        public BlogPostController(IBlogPostAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] BlogPostCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
    
}