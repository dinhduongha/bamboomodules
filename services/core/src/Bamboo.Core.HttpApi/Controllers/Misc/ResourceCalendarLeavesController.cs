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
    [Route("api/v1/resource/ResourceCalendarLeaves")]
    public partial class ResourceCalendarLeavesController : AbpController
    {
        protected readonly IResourceCalendarLeavesAppService _appService;
        public ResourceCalendarLeavesController(IResourceCalendarLeavesAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("check-dates")]
        public async Task<IActionResult> CheckDatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckDatesAsync(ids);
            return Ok(result);
        }
    }
    
}