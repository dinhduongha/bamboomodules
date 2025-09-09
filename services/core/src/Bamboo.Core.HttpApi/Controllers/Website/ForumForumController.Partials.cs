using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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