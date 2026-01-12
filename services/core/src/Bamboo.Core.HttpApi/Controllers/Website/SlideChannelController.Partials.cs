using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SlideChannelController
    {
        
        [HttpPost]
        [Route("{id}/action-channel-enroll")]
        public async Task<IActionResult> ActionChannelEnrollAsync(Guid id)
        {
            var result = await _appService.ChannelEnrollAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-channel-invite")]
        public async Task<IActionResult> ActionChannelInviteAsync(Guid id)
        {
            var result = await _appService.ChannelInviteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-grant-access")]
        public async Task<IActionResult> ActionGrantAccessAsync(Guid id, [FromBody] SlideChannelGrantAccessRequestDto input)
        {
            var result = await _appService.GrantAccessAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-mass-mailing-attendees")]
        public async Task<IActionResult> ActionMassMailingAttendeesAsync(Guid id)
        {
            var result = await _appService.MassMailingAttendeesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-certified-members")]
        public async Task<IActionResult> ActionRedirectToCertifiedMembersAsync(Guid id)
        {
            var result = await _appService.RedirectToCertifiedMembersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-completed-members")]
        public async Task<IActionResult> ActionRedirectToCompletedMembersAsync(Guid id)
        {
            var result = await _appService.RedirectToCompletedMembersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-engaged-members")]
        public async Task<IActionResult> ActionRedirectToEngagedMembersAsync(Guid id)
        {
            var result = await _appService.RedirectToEngagedMembersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-forum")]
        public async Task<IActionResult> ActionRedirectToForumAsync(Guid id)
        {
            var result = await _appService.RedirectToForumAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-invited-members")]
        public async Task<IActionResult> ActionRedirectToInvitedMembersAsync(Guid id)
        {
            var result = await _appService.RedirectToInvitedMembersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-members")]
        public async Task<IActionResult> ActionRedirectToMembersAsync(Guid id, [FromBody] SlideChannelRedirectToMembersRequestDto input)
        {
            var result = await _appService.RedirectToMembersAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-refuse-access")]
        public async Task<IActionResult> ActionRefuseAccessAsync(Guid id, [FromBody] SlideChannelRefuseAccessRequestDto input)
        {
            var result = await _appService.RefuseAccessAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-request-access")]
        public async Task<IActionResult> ActionRequestAccessAsync(Guid id)
        {
            var result = await _appService.RequestAccessAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-ratings")]
        public async Task<IActionResult> ActionViewRatingsAsync(Guid id)
        {
            var result = await _appService.ViewRatingsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sales")]
        public async Task<IActionResult> ActionViewSalesAsync(Guid id)
        {
            var result = await _appService.ViewSalesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-slides")]
        public async Task<IActionResult> ActionViewSlidesAsync(Guid id)
        {
            var result = await _appService.ViewSlidesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] SlideChannelCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
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