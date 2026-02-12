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
    [Route("api/v1/base/ResetViewArchWizard")]
    public partial class ResetViewArchWizardController : AbpController
    {
        protected readonly IResetViewArchWizardAppService _appService;
        public ResetViewArchWizardController(IResetViewArchWizardAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("reset-view-button")]
        public async Task<IActionResult> ResetViewButtonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetViewButtonAsync(ids);
            return Ok(result);
        }
    }
    
}