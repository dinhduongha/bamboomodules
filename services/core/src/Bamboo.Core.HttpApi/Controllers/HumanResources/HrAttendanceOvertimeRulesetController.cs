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
    [Route("api/v1/human-resources/HrAttendanceOvertimeRuleset")]
    public partial class HrAttendanceOvertimeRulesetController : AbpController
    {
        protected readonly IHrAttendanceOvertimeRulesetAppService _appService;
        public HrAttendanceOvertimeRulesetController(IHrAttendanceOvertimeRulesetAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-regenerate-overtimes")]
        public async Task<IActionResult> RegenerateOvertimesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RegenerateOvertimesAsync(ids);
            return Ok(result);
        }
    }
    
}