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
    [Route("api/v1/resource/ResourceCalendarAttendance")]
    public partial class ResourceCalendarAttendanceController : AbpController
    {
        protected readonly IResourceCalendarAttendanceAppService _appService;
        public ResourceCalendarAttendanceController(IResourceCalendarAttendanceAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-week-type")]
        public async Task<IActionResult> GetWeekTypeAsync([FromBody] ResourceCalendarAttendanceGetWeekTypeRequestDto input)
        {
            var result = await _appService.GetWeekTypeAsync(input);
            return Ok(result);
        }
    }
    
}