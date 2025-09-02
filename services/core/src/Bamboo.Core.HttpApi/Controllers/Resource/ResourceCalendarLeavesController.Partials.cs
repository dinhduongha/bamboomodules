using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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