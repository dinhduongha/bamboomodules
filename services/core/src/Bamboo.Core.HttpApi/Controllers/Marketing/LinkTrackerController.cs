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
    [Route("api/v1/marketing/LinkTracker")]
    public partial class LinkTrackerController : AbpController
    {
        protected readonly ILinkTrackerAppService _appService;
        public LinkTrackerController(ILinkTrackerAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-view-statistics")]
        public async Task<IActionResult> ViewStatisticsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewStatisticsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-visit-page")]
        public async Task<IActionResult> VisitPageAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.VisitPageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-visit-page-statistics")]
        public async Task<IActionResult> VisitPageStatisticsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.VisitPageStatisticsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-links")]
        public async Task<IActionResult> ConvertLinksAsync([FromBody] LinkTrackerConvertLinksRequestDto input)
        {
            var result = await _appService.ConvertLinksAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-url-from-code")]
        public async Task<IActionResult> GetUrlFromCodeAsync([FromBody] LinkTrackerGetUrlFromCodeRequestDto input)
        {
            var result = await _appService.GetUrlFromCodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("recent-links")]
        public async Task<IActionResult> RecentLinksAsync([FromBody] LinkTrackerRecentLinksRequestDto input)
        {
            var result = await _appService.RecentLinksAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-or-create")]
        public async Task<IActionResult> SearchOrCreateAsync([FromBody] LinkTrackerSearchOrCreateRequestDto input)
        {
            var result = await _appService.SearchOrCreateAsync(input);
            return Ok(result);
        }
    }
    
}