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
    [Route("api/v1/accounting/AccountReconcileModelPartnerMapping")]
    public partial class AccountReconcileModelPartnerMappingController : AbpController
    {
        protected readonly IAccountReconcileModelPartnerMappingAppService _appService;
        public AccountReconcileModelPartnerMappingController(IAccountReconcileModelPartnerMappingAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("validate-regex")]
        public async Task<IActionResult> ValidateRegexAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateRegexAsync(ids);
            return Ok(result);
        }
    }
    
}