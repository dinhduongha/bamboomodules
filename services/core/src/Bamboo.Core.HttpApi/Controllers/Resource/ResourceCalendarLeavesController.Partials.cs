using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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