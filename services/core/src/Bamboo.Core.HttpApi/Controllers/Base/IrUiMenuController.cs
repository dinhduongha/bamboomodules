using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/base/IrUiMenu")]
    public partial class IrUiMenuController : AbpController
    {
        protected readonly IIrUiMenuAppService _appService;
        public IrUiMenuController(IIrUiMenuAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-user-roots")]
        public async Task<IActionResult> GetUserRootsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetUserRootsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-menus")]
        public async Task<IActionResult> LoadMenusAsync([FromBody] IrUiMenuLoadMenusRequestDto input)
        {
            var result = await _appService.LoadMenusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-menus-root")]
        public async Task<IActionResult> LoadMenusRootAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LoadMenusRootAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-web-menus")]
        public async Task<IActionResult> LoadWebMenusAsync([FromBody] IrUiMenuLoadWebMenusRequestDto input)
        {
            var result = await _appService.LoadWebMenusAsync(input);
            return Ok(result);
        }
    }
    
}