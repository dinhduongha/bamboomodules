using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventTrackController
    {
        
        [HttpPost]
        [Route("action-add-quiz")]
        public async Task<IActionResult> ActionAddQuizAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddQuizAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-quiz")]
        public async Task<IActionResult> ActionViewQuizAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewQuizAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetBackendMenuIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-track-speakers-list")]
        public async Task<IActionResult> OpenTrackSpeakersListAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenTrackSpeakersListAsync(ids);
            return Ok(result);
        }
    }
}