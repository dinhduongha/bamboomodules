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
    [Route("api/v1/base/WizardIrModelMenuCreate")]
    public partial class WizardIrModelMenuCreateController : AbpController
    {
        protected readonly IWizardIrModelMenuCreateAppService _appService;
        public WizardIrModelMenuCreateController(IWizardIrModelMenuCreateAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("menu-create")]
        public async Task<IActionResult> MenuCreateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MenuCreateAsync(ids);
            return Ok(result);
        }
    }
    
}