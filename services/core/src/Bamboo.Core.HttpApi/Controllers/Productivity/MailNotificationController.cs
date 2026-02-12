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
    [Route("api/v1/productivity/MailNotification")]
    public partial class MailNotificationController : AbpController
    {
        protected readonly IMailNotificationAppService _appService;
        public MailNotificationController(IMailNotificationAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("format-failure-reason")]
        public async Task<IActionResult> FormatFailureReasonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.FormatFailureReasonAsync(ids);
            return Ok(result);
        }
    }
    
}