using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    public partial class CalendarFiltersController
    {
        
        [HttpPost]
        [Route("{id}/unlink-from-partner-id")]
        public async Task<IActionResult> UnlinkFromPartnerIdAsync(Guid id, [FromBody] CalendarFiltersUnlinkFromPartnerIdRequestDto input)
        {
            var result = await _appService.UnlinkFromPartnerIdAsync(id, input);
            return Ok(result);
        }
    }
}