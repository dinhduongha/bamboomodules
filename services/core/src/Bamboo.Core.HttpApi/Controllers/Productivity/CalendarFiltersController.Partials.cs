using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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