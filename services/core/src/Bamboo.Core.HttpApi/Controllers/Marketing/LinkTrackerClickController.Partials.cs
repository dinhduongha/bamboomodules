using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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