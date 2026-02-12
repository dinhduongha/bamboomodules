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
    [Route("api/v1/marketing/EventTrack")]
    public partial class EventTrackController : AbpController
    {
        protected readonly IEventTrackAppService _appService;
        public EventTrackController(IEventTrackAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-quiz")]
        public async Task<IActionResult> AddQuizAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddQuizAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-quiz")]
        public async Task<IActionResult> ViewQuizAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewQuizAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetBackendMenuIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-track-speakers-list")]
        public async Task<IActionResult> OpenTrackSpeakersListAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenTrackSpeakersListAsync(ids);
            return Ok(result);
        }
    }
    
}