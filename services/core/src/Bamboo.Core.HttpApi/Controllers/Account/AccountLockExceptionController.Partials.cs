using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
{
    public partial class AccountLockExceptionController
    {
        
        [HttpPost]
        [Route("{id}/action-revoke")]
        public async Task<IActionResult> ActionRevokeAsync(Guid id)
        {
            var result = await _appService.RevokeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-audit-trail-during-exception")]
        public async Task<IActionResult> ActionShowAuditTrailDuringExceptionAsync(Guid id)
        {
            var result = await _appService.ShowAuditTrailDuringExceptionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
    }
}