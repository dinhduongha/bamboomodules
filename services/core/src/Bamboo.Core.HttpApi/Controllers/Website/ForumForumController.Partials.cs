using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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