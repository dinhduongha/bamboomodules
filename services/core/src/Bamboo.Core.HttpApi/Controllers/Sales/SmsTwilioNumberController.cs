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
    [Route("api/v1/sms-twilio/SmsTwilioNumber")]
    public partial class SmsTwilioNumberController : AbpController
    {
        protected readonly ISmsTwilioNumberAppService _appService;
        public SmsTwilioNumberController(ISmsTwilioNumberAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-unlink")]
        public async Task<IActionResult> UnlinkAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnlinkAsync(ids);
            return Ok(result);
        }
    }
    
}