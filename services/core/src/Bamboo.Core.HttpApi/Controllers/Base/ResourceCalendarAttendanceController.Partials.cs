using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResourceCalendarAttendanceController
    {
        
        [HttpPost]
        [Route("{id}/get-week-type")]
        public async Task<IActionResult> GetWeekTypeAsync(Guid id, [FromBody] ResourceCalendarAttendanceGetWeekTypeRequestDto input)
        {
            var result = await _appService.GetWeekTypeAsync(id, input);
            return Ok(result);
        }
    }
}