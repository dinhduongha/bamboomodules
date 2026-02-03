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
        [Route("action-revoke")]
        public async Task<IActionResult> ActionRevokeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RevokeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-audit-trail-during-exception")]
        public async Task<IActionResult> ActionShowAuditTrailDuringExceptionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowAuditTrailDuringExceptionAsync(ids);
            return Ok(result);
        }
    }
}