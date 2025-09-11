using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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