using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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