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
    [Route("api/v1/auth-passkey/AuthPasskeyKeyCreate")]
    public partial class AuthPasskeyKeyCreateController : AbpController
    {
        protected readonly IAuthPasskeyKeyCreateAppService _appService;
        public AuthPasskeyKeyCreateController(IAuthPasskeyKeyCreateAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("make-key")]
        public async Task<IActionResult> MakeKeyAsync([FromBody] AuthPasskeyKeyCreateMakeKeyRequestDto input)
        {
            var result = await _appService.MakeKeyAsync(input);
            return Ok(result);
        }
    }
    
}