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
    [Route("api/v1/base/BaseEnableProfilingWizard")]
    public partial class BaseEnableProfilingWizardController : AbpController
    {
        protected readonly IBaseEnableProfilingWizardAppService _appService;
        public BaseEnableProfilingWizardController(IBaseEnableProfilingWizardAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("submit")]
        public async Task<IActionResult> SubmitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SubmitAsync(ids);
            return Ok(result);
        }
    }
    
}