using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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