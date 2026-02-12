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
    [Route("api/v1/website/SlideSlide")]
    public partial class SlideSlideController : AbpController
    {
        protected readonly ISlideSlideAppService _appService;
        public SlideSlideController(ISlideSlideAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-dislike")]
        public async Task<IActionResult> DislikeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DislikeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-like")]
        public async Task<IActionResult> LikeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LikeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mark-completed")]
        public async Task<IActionResult> MarkCompletedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MarkCompletedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mark-uncompleted")]
        public async Task<IActionResult> MarkUncompletedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MarkUncompletedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-viewed")]
        public async Task<IActionResult> SetViewedAsync([FromBody] SlideSlideSetViewedRequestDto input)
        {
            var result = await _appService.SetViewedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-embeds")]
        public async Task<IActionResult> ViewEmbedsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewEmbedsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] SlideSlideCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
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
        [Route("get-base-url")]
        public async Task<IActionResult> GetBaseUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetBaseUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
    }
    
}