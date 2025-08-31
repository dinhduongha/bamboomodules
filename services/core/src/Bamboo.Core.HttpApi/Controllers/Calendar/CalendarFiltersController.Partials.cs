using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    public partial class CalendarFiltersController
    {
        
        [HttpPost]
        [Route("{id}/unlink-from-partner-id")]
        public async Task<IActionResult> UnlinkFromPartnerIdAsync(Guid id, [FromBody] CalendarFiltersUnlinkFromPartnerIdRequestDto input)
        {
            var result = await _appService.UnlinkFromPartnerIdAsync(id, input.PartnerId);
            return Ok(result);
        }
    }
}