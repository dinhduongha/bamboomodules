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
        [Route("{id}/arrange-tag-list-by-id")]
        public async Task<IActionResult> ArrangeTagListByIdAsync(Guid id, [FromBody] ProjectTagsArrangeTagListByIdRequestDto input)
        {
            var result = await _appService.ArrangeTagListByIdAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/formatted-read-group")]
        public async Task<IActionResult> FormattedReadGroupAsync(Guid id, [FromBody] ProjectTagsFormattedReadGroupRequestDto input)
        {
            var result = await _appService.FormattedReadGroupAsync(id, input);
            return Ok(result);
        }
    }
}