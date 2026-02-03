using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class LinkTrackerController
    {
        
        [HttpPost]
        [Route("action-view-statistics")]
        public async Task<IActionResult> ActionViewStatisticsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewStatisticsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-visit-page")]
        public async Task<IActionResult> ActionVisitPageAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.VisitPageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-visit-page-statistics")]
        public async Task<IActionResult> ActionVisitPageStatisticsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.VisitPageStatisticsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-links")]
        public async Task<IActionResult> ConvertLinksAsync(LinkTrackerConvertLinksRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConvertLinksAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-url-from-code")]
        public async Task<IActionResult> GetUrlFromCodeAsync(LinkTrackerGetUrlFromCodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetUrlFromCodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("recent-links")]
        public async Task<IActionResult> RecentLinksAsync(LinkTrackerRecentLinksRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RecentLinksAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-or-create")]
        public async Task<IActionResult> SearchOrCreateAsync(LinkTrackerSearchOrCreateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SearchOrCreateAsync(input);
            return Ok(result);
        }
    }
}