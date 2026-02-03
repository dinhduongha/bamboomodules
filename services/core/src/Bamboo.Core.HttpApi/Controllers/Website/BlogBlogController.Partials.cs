using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class BlogBlogController
    {
        
        [HttpPost]
        [Route("all-tags")]
        public async Task<IActionResult> AllTagsAsync(BlogBlogAllTagsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AllTagsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
    }
}