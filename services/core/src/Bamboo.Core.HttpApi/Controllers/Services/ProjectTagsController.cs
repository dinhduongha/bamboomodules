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
    [Route("api/v1/services/ProjectTags")]
    public partial class ProjectTagsController : AbpController
    {
        protected readonly IProjectTagsAppService _appService;
        public ProjectTagsController(IProjectTagsAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("arrange-tag-list-by-id")]
        public async Task<IActionResult> ArrangeTagListByIdAsync([FromBody] ProjectTagsArrangeTagListByIdRequestDto input)
        {
            var result = await _appService.ArrangeTagListByIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("formatted-read-group")]
        public async Task<IActionResult> FormattedReadGroupAsync([FromBody] ProjectTagsFormattedReadGroupRequestDto input)
        {
            var result = await _appService.FormattedReadGroupAsync(input);
            return Ok(result);
        }
    }
    
}