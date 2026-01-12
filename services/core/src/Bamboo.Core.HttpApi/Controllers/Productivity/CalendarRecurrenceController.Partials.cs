using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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