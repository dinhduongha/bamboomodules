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
    [Route("api/v1/website/SlideChannel")]
    public partial class SlideChannelController : AbpController
    {
        protected readonly ISlideChannelAppService _appService;
        public SlideChannelController(ISlideChannelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-channel-enroll")]
        public async Task<IActionResult> ChannelEnrollAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ChannelEnrollAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-channel-invite")]
        public async Task<IActionResult> ChannelInviteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ChannelInviteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-grant-access")]
        public async Task<IActionResult> GrantAccessAsync([FromBody] SlideChannelGrantAccessRequestDto input)
        {
            var result = await _appService.GrantAccessAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mass-mailing-attendees")]
        public async Task<IActionResult> MassMailingAttendeesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MassMailingAttendeesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-certified-members")]
        public async Task<IActionResult> RedirectToCertifiedMembersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToCertifiedMembersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-completed-members")]
        public async Task<IActionResult> RedirectToCompletedMembersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToCompletedMembersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-engaged-members")]
        public async Task<IActionResult> RedirectToEngagedMembersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToEngagedMembersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-forum")]
        public async Task<IActionResult> RedirectToForumAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToForumAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-invited-members")]
        public async Task<IActionResult> RedirectToInvitedMembersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToInvitedMembersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-members")]
        public async Task<IActionResult> RedirectToMembersAsync([FromBody] SlideChannelRedirectToMembersRequestDto input)
        {
            var result = await _appService.RedirectToMembersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse-access")]
        public async Task<IActionResult> RefuseAccessAsync([FromBody] SlideChannelRefuseAccessRequestDto input)
        {
            var result = await _appService.RefuseAccessAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-request-access")]
        public async Task<IActionResult> RequestAccessAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RequestAccessAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-ratings")]
        public async Task<IActionResult> ViewRatingsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRatingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sales")]
        public async Task<IActionResult> ViewSalesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSalesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-slides")]
        public async Task<IActionResult> ViewSlidesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSlidesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] SlideChannelCopyDataRequestDto input)
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
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
    }
    
}