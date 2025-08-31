using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    public partial class ResourceCalendarAttendanceController
    {
        
        [HttpPost]
        [Route("{id}/get-week-type")]
        public async Task<IActionResult> GetWeekTypeAsync(Guid id, [FromBody] ResourceCalendarAttendanceGetWeekTypeRequestDto input)
        {
            var result = await _appService.GetWeekTypeAsync(id, input.Date);
            return Ok(result);
        }
    }
}