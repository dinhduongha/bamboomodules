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