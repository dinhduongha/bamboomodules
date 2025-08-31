using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.LinkTrackerModule
{
    public partial class LinkTrackerClickController
    {
        
        [HttpPost]
        [Route("{id}/add-click")]
        public async Task<IActionResult> AddClickAsync(Guid id, [FromBody] LinkTrackerClickAddClickRequestDto input)
        {
            var result = await _appService.AddClickAsync(id, input.Code);
            return Ok(result);
        }
    }
}