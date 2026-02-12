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
    [Route("api/v1/marketing/EventSponsor")]
    public partial class EventSponsorController : AbpController
    {
        protected readonly IEventSponsorAppService _appService;
        public EventSponsorController(IEventSponsorAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetBackendMenuIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-base-url")]
        public async Task<IActionResult> GetBaseUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetBaseUrlAsync(ids);
            return Ok(result);
        }
    }
    
}