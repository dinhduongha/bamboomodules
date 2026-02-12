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
    [Route("api/v1/human-resources/HrAttendanceOvertimeLine")]
    public partial class HrAttendanceOvertimeLineController : AbpController
    {
        protected readonly IHrAttendanceOvertimeLineAppService _appService;
        public HrAttendanceOvertimeLineController(IHrAttendanceOvertimeLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-approve")]
        public async Task<IActionResult> ApproveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ApproveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse")]
        public async Task<IActionResult> RefuseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefuseAsync(ids);
            return Ok(result);
        }
    }
    
}