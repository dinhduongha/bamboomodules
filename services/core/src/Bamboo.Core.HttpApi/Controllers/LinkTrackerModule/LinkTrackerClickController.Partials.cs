using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.LinkTrackerModule
{
    public partial class LinkTrackerClickController
    {
        
        [HttpPost]
        [Route("{id}/add-click")]
        public async Task<IActionResult> AddClickAsync(Guid id, [FromBody] LinkTrackerClickAddClickRequestDto input)
        {
            var result = await _appService.AddClickAsync(id, input);
            return Ok(result);
        }
    }
}