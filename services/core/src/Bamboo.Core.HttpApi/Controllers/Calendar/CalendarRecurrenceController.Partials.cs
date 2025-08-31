using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    public partial class CalendarRecurrenceController
    {
        
        [HttpPost]
        [Route("{id}/get-recurrence-name")]
        public async Task<IActionResult> GetRecurrenceNameAsync(Guid id)
        {
            var result = await _appService.GetRecurrenceNameAsync(id);
            return Ok(result);
        }
    }
}