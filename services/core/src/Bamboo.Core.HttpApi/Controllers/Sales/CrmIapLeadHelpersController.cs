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
    [Route("api/v1/sales/CrmIapLeadHelpers")]
    public partial class CrmIapLeadHelpersController : AbpController
    {
        protected readonly ICrmIapLeadHelpersAppService _appService;
        public CrmIapLeadHelpersController(ICrmIapLeadHelpersAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("lead-vals-from-response")]
        public async Task<IActionResult> LeadValsFromResponseAsync([FromBody] CrmIapLeadHelpersLeadValsFromResponseRequestDto input)
        {
            var result = await _appService.LeadValsFromResponseAsync(input);
            return Ok(result);
        }
    }
    
}