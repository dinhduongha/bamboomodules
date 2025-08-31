using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteForum
{
    public partial class ForumForumController
    {
        
        [HttpPost]
        [Route("{id}/go-to-website")]
        public async Task<IActionResult> GoToWebsiteAsync(Guid id)
        {
            var result = await _appService.GoToWebsiteAsync(id);
            return Ok(result);
        }
    }
}