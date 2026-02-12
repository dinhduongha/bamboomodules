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
    [Route("api/v1/base/ChangePasswordUser")]
    public partial class ChangePasswordUserController : AbpController
    {
        protected readonly IChangePasswordUserAppService _appService;
        public ChangePasswordUserController(IChangePasswordUserAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("change-password-button")]
        public async Task<IActionResult> ChangePasswordButtonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ChangePasswordButtonAsync(ids);
            return Ok(result);
        }
    }
    
}