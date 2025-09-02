using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteEventTrack
{
    public partial class EventTrackController
    {
        
        [HttpPost]
        [Route("{id}/action-add-quiz")]
        public async Task<IActionResult> ActionAddQuizAsync(Guid id)
        {
            var result = await _appService.AddQuizAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-quiz")]
        public async Task<IActionResult> ActionViewQuizAsync(Guid id)
        {
            var result = await _appService.ViewQuizAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync(Guid id)
        {
            var result = await _appService.GetBackendMenuIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-track-speakers-list")]
        public async Task<IActionResult> OpenTrackSpeakersListAsync(Guid id)
        {
            var result = await _appService.OpenTrackSpeakersListAsync(id);
            return Ok(result);
        }
    }
}