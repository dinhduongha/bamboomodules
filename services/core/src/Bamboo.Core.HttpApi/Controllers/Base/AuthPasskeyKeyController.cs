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
    [Route("api/v1/auth-passkey/AuthPasskeyKey")]
    public partial class AuthPasskeyKeyController : AbpController
    {
        protected readonly IAuthPasskeyKeyAppService _appService;
        public AuthPasskeyKeyController(IAuthPasskeyKeyAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-delete-passkey")]
        public async Task<IActionResult> DeletePasskeyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DeletePasskeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-rename-passkey")]
        public async Task<IActionResult> RenamePasskeyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RenamePasskeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
    
}