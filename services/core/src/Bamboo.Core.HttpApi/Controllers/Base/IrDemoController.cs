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
    [Route("api/v1/base/IrDemo")]
    public partial class IrDemoController : AbpController
    {
        protected readonly IIrDemoAppService _appService;
        public IrDemoController(IIrDemoAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("install-demo")]
        public async Task<IActionResult> InstallDemoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InstallDemoAsync(ids);
            return Ok(result);
        }
    }
    
}