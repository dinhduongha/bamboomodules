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
    [Route("api/v1/website/BlogBlog")]
    public partial class BlogBlogController : AbpController
    {
        protected readonly IBlogBlogAppService _appService;
        public BlogBlogController(IBlogBlogAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("all-tags")]
        public async Task<IActionResult> AllTagsAsync([FromBody] BlogBlogAllTagsRequestDto input)
        {
            var result = await _appService.AllTagsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
    }
    
}