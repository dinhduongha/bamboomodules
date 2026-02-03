using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProjectTagsController
    {
        
        [HttpPost]
        [Route("arrange-tag-list-by-id")]
        public async Task<IActionResult> ArrangeTagListByIdAsync(ProjectTagsArrangeTagListByIdRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ArrangeTagListByIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("formatted-read-group")]
        public async Task<IActionResult> FormattedReadGroupAsync(ProjectTagsFormattedReadGroupRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormattedReadGroupAsync(input);
            return Ok(result);
        }
    }
}