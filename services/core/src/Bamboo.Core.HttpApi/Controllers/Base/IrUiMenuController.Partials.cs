using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrUiMenuController
    {
        
        [HttpPost]
        [Route("get-user-roots")]
        public async Task<IActionResult> GetUserRootsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetUserRootsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-menus")]
        public async Task<IActionResult> LoadMenusAsync(IrUiMenuLoadMenusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadMenusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-menus-root")]
        public async Task<IActionResult> LoadMenusRootAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LoadMenusRootAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-web-menus")]
        public async Task<IActionResult> LoadWebMenusAsync(IrUiMenuLoadWebMenusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadWebMenusAsync(input);
            return Ok(result);
        }
    }
}