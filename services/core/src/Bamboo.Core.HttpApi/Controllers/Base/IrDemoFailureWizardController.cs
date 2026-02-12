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
    [Route("api/v1/base/IrDemoFailureWizard")]
    public partial class IrDemoFailureWizardController : AbpController
    {
        protected readonly IIrDemoFailureWizardAppService _appService;
        public IrDemoFailureWizardController(IIrDemoFailureWizardAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("done")]
        public async Task<IActionResult> DoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoneAsync(ids);
            return Ok(result);
        }
    }
    
}