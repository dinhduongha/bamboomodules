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
    [Route("api/v1/accounting/AccountLockException")]
    public partial class AccountLockExceptionController : AbpController
    {
        protected readonly IAccountLockExceptionAppService _appService;
        public AccountLockExceptionController(IAccountLockExceptionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-revoke")]
        public async Task<IActionResult> RevokeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RevokeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-audit-trail-during-exception")]
        public async Task<IActionResult> ShowAuditTrailDuringExceptionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowAuditTrailDuringExceptionAsync(ids);
            return Ok(result);
        }
    }
    
}