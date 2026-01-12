using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
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