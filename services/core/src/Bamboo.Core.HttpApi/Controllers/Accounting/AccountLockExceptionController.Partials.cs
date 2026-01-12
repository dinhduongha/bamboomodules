using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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
    }
}