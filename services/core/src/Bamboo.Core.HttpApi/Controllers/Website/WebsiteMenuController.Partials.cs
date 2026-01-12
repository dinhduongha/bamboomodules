using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class WebsiteMenuController
    {
        
        [HttpPost]
        [Route("{id}/get-tree")]
        public async Task<IActionResult> GetTreeAsync(Guid id, [FromBody] WebsiteMenuGetTreeRequestDto input)
        {
            var result = await _appService.GetTreeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/save")]
        public async Task<IActionResult> SaveAsync(Guid id, [FromBody] WebsiteMenuSaveRequestDto input)
        {
            var result = await _appService.SaveAsync(id, input);
            return Ok(result);
        }
    }
}