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
    [Route("api/v1/productivity/CalendarAttendee")]
    public partial class CalendarAttendeeController : AbpController
    {
        protected readonly ICalendarAttendeeAppService _appService;
        public CalendarAttendeeController(ICalendarAttendeeAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("do-accept")]
        public async Task<IActionResult> DoAcceptAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoAcceptAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-decline")]
        public async Task<IActionResult> DoDeclineAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoDeclineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-tentative")]
        public async Task<IActionResult> DoTentativeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoTentativeAsync(ids);
            return Ok(result);
        }
    }
    
}