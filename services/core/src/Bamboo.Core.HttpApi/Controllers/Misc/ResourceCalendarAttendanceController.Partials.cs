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
        [Route("{id}/get-week-type")]
        public async Task<IActionResult> GetWeekTypeAsync(Guid id, [FromBody] ResourceCalendarAttendanceGetWeekTypeRequestDto input)
        {
            var result = await _appService.GetWeekTypeAsync(id, input);
            return Ok(result);
        }
    }
}