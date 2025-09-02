using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
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