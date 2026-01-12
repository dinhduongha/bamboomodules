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
        [Route("{id}/get-user-roots")]
        public async Task<IActionResult> GetUserRootsAsync(Guid id)
        {
            var result = await _appService.GetUserRootsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-menus")]
        public async Task<IActionResult> LoadMenusAsync(Guid id, [FromBody] IrUiMenuLoadMenusRequestDto input)
        {
            var result = await _appService.LoadMenusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-menus-root")]
        public async Task<IActionResult> LoadMenusRootAsync(Guid id)
        {
            var result = await _appService.LoadMenusRootAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/load-web-menus")]
        public async Task<IActionResult> LoadWebMenusAsync(Guid id, [FromBody] IrUiMenuLoadWebMenusRequestDto input)
        {
            var result = await _appService.LoadWebMenusAsync(id, input);
            return Ok(result);
        }
    }
}