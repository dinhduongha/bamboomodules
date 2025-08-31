using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteBlog
{
    public partial class BlogBlogController
    {
        
        [HttpPost]
        [Route("{id}/all-tags")]
        public async Task<IActionResult> AllTagsAsync(Guid id, [FromBody] BlogBlogAllTagsRequestDto input)
        {
            var result = await _appService.AllTagsAsync(id, input.Join, input.MinLimit);
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