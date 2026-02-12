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
    [Route("api/v1/website/ForumForum")]
    public partial class ForumForumController : AbpController
    {
        protected readonly IForumForumAppService _appService;
        public ForumForumController(IForumForumAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("go-to-website")]
        public async Task<IActionResult> GoToWebsiteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GoToWebsiteAsync(ids);
            return Ok(result);
        }
    }
    
}