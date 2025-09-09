using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Resource
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