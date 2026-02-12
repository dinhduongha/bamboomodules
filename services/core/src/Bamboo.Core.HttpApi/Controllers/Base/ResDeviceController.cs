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
    [Route("api/v1/base/ResDevice")]
    public partial class ResDeviceController : AbpController
    {
        protected readonly IResDeviceAppService _appService;
        public ResDeviceController(IResDeviceAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("revoke")]
        public async Task<IActionResult> RevokeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RevokeAsync(ids);
            return Ok(result);
        }
    }
    
}