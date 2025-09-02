using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
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
    }
}