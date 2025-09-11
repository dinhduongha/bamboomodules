using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResourceCalendarLeavesController
    {
        
        [HttpPost]
        [Route("{id}/check-dates")]
        public async Task<IActionResult> CheckDatesAsync(Guid id)
        {
            var result = await _appService.CheckDatesAsync(id);
            return Ok(result);
        }
    }
}