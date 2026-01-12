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
        [Route("{id}/action-view-statistics")]
        public async Task<IActionResult> ActionViewStatisticsAsync(Guid id)
        {
            var result = await _appService.ViewStatisticsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-visit-page")]
        public async Task<IActionResult> ActionVisitPageAsync(Guid id)
        {
            var result = await _appService.VisitPageAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-visit-page-statistics")]
        public async Task<IActionResult> ActionVisitPageStatisticsAsync(Guid id)
        {
            var result = await _appService.VisitPageStatisticsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/convert-links")]
        public async Task<IActionResult> ConvertLinksAsync(Guid id, [FromBody] LinkTrackerConvertLinksRequestDto input)
        {
            var result = await _appService.ConvertLinksAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-url-from-code")]
        public async Task<IActionResult> GetUrlFromCodeAsync(Guid id, [FromBody] LinkTrackerGetUrlFromCodeRequestDto input)
        {
            var result = await _appService.GetUrlFromCodeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/recent-links")]
        public async Task<IActionResult> RecentLinksAsync(Guid id, [FromBody] LinkTrackerRecentLinksRequestDto input)
        {
            var result = await _appService.RecentLinksAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-or-create")]
        public async Task<IActionResult> SearchOrCreateAsync(Guid id, [FromBody] LinkTrackerSearchOrCreateRequestDto input)
        {
            var result = await _appService.SearchOrCreateAsync(id, input);
            return Ok(result);
        }
    }
}