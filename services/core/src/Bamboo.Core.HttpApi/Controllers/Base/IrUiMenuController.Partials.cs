using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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
        
        [HttpPost]
        [Route("{id}/search-count")]
        public async Task<IActionResult> SearchCountAsync(Guid id, [FromBody] IrUiMenuSearchCountRequestDto input)
        {
            var result = await _appService.SearchCountAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-fetch")]
        public async Task<IActionResult> SearchFetchAsync(Guid id, [FromBody] IrUiMenuSearchFetchRequestDto input)
        {
            var result = await _appService.SearchFetchAsync(id, input);
            return Ok(result);
        }
    }
}