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
        [Route("go-to-website")]
        public async Task<IActionResult> GoToWebsiteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GoToWebsiteAsync(ids);
            return Ok(result);
        }
    }
}