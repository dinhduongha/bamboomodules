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
    [Route("api/v1/base/ChangePasswordOwn")]
    public partial class ChangePasswordOwnController : AbpController
    {
        protected readonly IChangePasswordOwnAppService _appService;
        public ChangePasswordOwnController(IChangePasswordOwnAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ChangePasswordAsync(ids);
            return Ok(result);
        }
    }
    
}