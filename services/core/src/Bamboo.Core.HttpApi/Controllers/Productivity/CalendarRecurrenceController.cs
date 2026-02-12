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
    [Route("api/v1/productivity/CalendarRecurrence")]
    public partial class CalendarRecurrenceController : AbpController
    {
        protected readonly ICalendarRecurrenceAppService _appService;
        public CalendarRecurrenceController(ICalendarRecurrenceAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-recurrence-name")]
        public async Task<IActionResult> GetRecurrenceNameAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetRecurrenceNameAsync(ids);
            return Ok(result);
        }
    }
    
}