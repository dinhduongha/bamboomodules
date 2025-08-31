using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    public partial class ProjectTagsController
    {
        
        [HttpPost]
        [Route("{id}/arrange-tag-list-by-id")]
        public async Task<IActionResult> ArrangeTagListByIdAsync(Guid id, [FromBody] ProjectTagsArrangeTagListByIdRequestDto input)
        {
            var result = await _appService.ArrangeTagListByIdAsync(id, input.TagList, input.IdOrder);
            return Ok(result);
        }
    }
}