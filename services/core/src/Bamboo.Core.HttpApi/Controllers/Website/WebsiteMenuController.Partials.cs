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
        [Route("get-tree")]
        public async Task<IActionResult> GetTreeAsync(WebsiteMenuGetTreeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetTreeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveAsync(WebsiteMenuSaveRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SaveAsync(input);
            return Ok(result);
        }
    }
}