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
    [Route("api/v1/base/ResUsersApikeysDescription")]
    public partial class ResUsersApikeysDescriptionController : AbpController
    {
        protected readonly IResUsersApikeysDescriptionAppService _appService;
        public ResUsersApikeysDescriptionController(IResUsersApikeysDescriptionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("check-access-make-key")]
        public async Task<IActionResult> CheckAccessMakeKeyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckAccessMakeKeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("make-key")]
        public async Task<IActionResult> MakeKeyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MakeKeyAsync(ids);
            return Ok(result);
        }
    }
    
}