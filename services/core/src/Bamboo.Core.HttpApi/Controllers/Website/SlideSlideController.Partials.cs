using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SlideSlideController
    {
        
        [HttpPost]
        [Route("action-dislike")]
        public async Task<IActionResult> ActionDislikeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DislikeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-like")]
        public async Task<IActionResult> ActionLikeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LikeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mark-completed")]
        public async Task<IActionResult> ActionMarkCompletedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MarkCompletedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mark-uncompleted")]
        public async Task<IActionResult> ActionMarkUncompletedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MarkUncompletedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-viewed")]
        public async Task<IActionResult> ActionSetViewedAsync(SlideSlideSetViewedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetViewedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-embeds")]
        public async Task<IActionResult> ActionViewEmbedsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewEmbedsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(SlideSlideCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
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
        [Route("get-base-url")]
        public async Task<IActionResult> GetBaseUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetBaseUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
    }
}