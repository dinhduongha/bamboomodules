using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Resource
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