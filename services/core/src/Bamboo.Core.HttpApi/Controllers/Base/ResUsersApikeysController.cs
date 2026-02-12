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
    [Route("api/v1/base/ResUsersApikeys")]
    public partial class ResUsersApikeysController : AbpController
    {
        protected readonly IResUsersApikeysAppService _appService;
        public ResUsersApikeysController(IResUsersApikeysAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RemoveAsync(ids);
            return Ok(result);
        }
    }
    
}