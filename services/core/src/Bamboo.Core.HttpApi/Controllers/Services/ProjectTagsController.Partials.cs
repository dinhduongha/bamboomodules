using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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