using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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