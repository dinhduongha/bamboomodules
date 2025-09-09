using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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