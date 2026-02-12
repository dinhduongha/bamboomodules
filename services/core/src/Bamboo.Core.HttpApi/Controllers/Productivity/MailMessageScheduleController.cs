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
    [Route("api/v1/productivity/MailMessageSchedule")]
    public partial class MailMessageScheduleController : AbpController
    {
        protected readonly IMailMessageScheduleAppService _appService;
        public MailMessageScheduleController(IMailMessageScheduleAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("force-send")]
        public async Task<IActionResult> ForceSendAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ForceSendAsync(ids);
            return Ok(result);
        }
    }
    
}