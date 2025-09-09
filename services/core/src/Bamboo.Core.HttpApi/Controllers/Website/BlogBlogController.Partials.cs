using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteBlog
{
    public partial class BlogBlogController
    {
        
        [HttpPost]
        [Route("{id}/all-tags")]
        public async Task<IActionResult> AllTagsAsync(Guid id, [FromBody] BlogBlogAllTagsRequestDto input)
        {
            var result = await _appService.AllTagsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid id)
        {
            var result = await _appService.MessagePostAsync(id);
            return Ok(result);
        }
    }
}