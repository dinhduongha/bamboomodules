using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteModule
{
    public partial class WebsiteMenuController
    {
        
        [HttpPost]
        [Route("{id}/get-tree")]
        public async Task<IActionResult> GetTreeAsync(Guid id, [FromBody] WebsiteMenuGetTreeRequestDto input)
        {
            var result = await _appService.GetTreeAsync(id, input.WebsiteId, input.MenuId);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/save")]
        public async Task<IActionResult> SaveAsync(Guid id, [FromBody] WebsiteMenuSaveRequestDto input)
        {
            var result = await _appService.SaveAsync(id, input.WebsiteId, input.Data);
            return Ok(result);
        }
    }
}