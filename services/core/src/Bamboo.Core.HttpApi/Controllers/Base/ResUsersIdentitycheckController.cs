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
    [Route("api/v1/base/ResUsersIdentitycheck")]
    public partial class ResUsersIdentitycheckController : AbpController
    {
        protected readonly IResUsersIdentitycheckAppService _appService;
        public ResUsersIdentitycheckController(IResUsersIdentitycheckAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-use-password")]
        public async Task<IActionResult> UsePasswordAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UsePasswordAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run-check")]
        public async Task<IActionResult> RunCheckAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RunCheckAsync(ids);
            return Ok(result);
        }
    }
    
}