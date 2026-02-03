using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResourceCalendarAttendanceController
    {
        
        [HttpPost]
        [Route("get-week-type")]
        public async Task<IActionResult> GetWeekTypeAsync(ResourceCalendarAttendanceGetWeekTypeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetWeekTypeAsync(input);
            return Ok(result);
        }
    }
}