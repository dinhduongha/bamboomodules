using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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