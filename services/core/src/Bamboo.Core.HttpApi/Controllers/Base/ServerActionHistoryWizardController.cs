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
    [Route("api/v1/base/ServerActionHistoryWizard")]
    public partial class ServerActionHistoryWizardController : AbpController
    {
        protected readonly IServerActionHistoryWizardAppService _appService;
        public ServerActionHistoryWizardController(IServerActionHistoryWizardAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("restore-revision")]
        public async Task<IActionResult> RestoreRevisionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RestoreRevisionAsync(ids);
            return Ok(result);
        }
    }
    
}