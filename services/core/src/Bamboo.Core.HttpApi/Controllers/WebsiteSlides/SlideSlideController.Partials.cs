using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSlides
{
    public partial class SlideSlideController
    {
        
        [HttpPost]
        [Route("{id}/action-dislike")]
        public async Task<IActionResult> ActionDislikeAsync(Guid id)
        {
            var result = await _appService.DislikeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-like")]
        public async Task<IActionResult> ActionLikeAsync(Guid id)
        {
            var result = await _appService.LikeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-mark-completed")]
        public async Task<IActionResult> ActionMarkCompletedAsync(Guid id)
        {
            var result = await _appService.MarkCompletedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-mark-uncompleted")]
        public async Task<IActionResult> ActionMarkUncompletedAsync(Guid id)
        {
            var result = await _appService.MarkUncompletedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-viewed")]
        public async Task<IActionResult> ActionSetViewedAsync(Guid id, [FromBody] SlideSlideSetViewedRequestDto input)
        {
            var result = await _appService.SetViewedAsync(id, input.QuizAttemptsInc);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-embeds")]
        public async Task<IActionResult> ActionViewEmbedsAsync(Guid id)
        {
            var result = await _appService.ViewEmbedsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] SlideSlideCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
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
        [Route("{id}/message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid id)
        {
            var result = await _appService.MessagePostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync(Guid id)
        {
            var result = await _appService.OpenWebsiteUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
    }
}