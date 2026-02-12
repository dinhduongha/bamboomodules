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
    [Route("api/v1/accounting/AccountAnalyticDistributionModel")]
    public partial class AccountAnalyticDistributionModelController : AbpController
    {
        protected readonly IAccountAnalyticDistributionModelAppService _appService;
        public AccountAnalyticDistributionModelController(IAccountAnalyticDistributionModelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-read-distribution-model")]
        public async Task<IActionResult> ReadDistributionModelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReadDistributionModelAsync(ids);
            return Ok(result);
        }
    }
    
}