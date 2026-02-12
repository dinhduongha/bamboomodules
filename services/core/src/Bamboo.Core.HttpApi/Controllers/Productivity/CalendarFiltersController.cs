using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/CalendarFilters")]
    public partial class CalendarFiltersController : AbpController
    {
        protected readonly ICalendarFiltersAppService _appService;
        public CalendarFiltersController(ICalendarFiltersAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("unlink-from-partner-id")]
        public async Task<IActionResult> UnlinkFromPartnerIdAsync([FromBody] CalendarFiltersUnlinkFromPartnerIdRequestDto input)
        {
            var result = await _appService.UnlinkFromPartnerIdAsync(input);
            return Ok(result);
        }
    }
    
}