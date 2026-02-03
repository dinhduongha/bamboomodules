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
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-channel-enroll")]
        public async Task<IActionResult> ActionChannelEnrollAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ChannelEnrollAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-channel-invite")]
        public async Task<IActionResult> ActionChannelInviteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ChannelInviteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-grant-access")]
        public async Task<IActionResult> ActionGrantAccessAsync(SlideChannelGrantAccessRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GrantAccessAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mass-mailing-attendees")]
        public async Task<IActionResult> ActionMassMailingAttendeesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MassMailingAttendeesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-certified-members")]
        public async Task<IActionResult> ActionRedirectToCertifiedMembersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToCertifiedMembersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-completed-members")]
        public async Task<IActionResult> ActionRedirectToCompletedMembersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToCompletedMembersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-engaged-members")]
        public async Task<IActionResult> ActionRedirectToEngagedMembersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToEngagedMembersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-forum")]
        public async Task<IActionResult> ActionRedirectToForumAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToForumAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-invited-members")]
        public async Task<IActionResult> ActionRedirectToInvitedMembersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToInvitedMembersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-members")]
        public async Task<IActionResult> ActionRedirectToMembersAsync(SlideChannelRedirectToMembersRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RedirectToMembersAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse-access")]
        public async Task<IActionResult> ActionRefuseAccessAsync(SlideChannelRefuseAccessRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RefuseAccessAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-request-access")]
        public async Task<IActionResult> ActionRequestAccessAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RequestAccessAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-ratings")]
        public async Task<IActionResult> ActionViewRatingsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRatingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sales")]
        public async Task<IActionResult> ActionViewSalesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSalesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-slides")]
        public async Task<IActionResult> ActionViewSlidesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSlidesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(SlideChannelCopyDataRequestDto input)
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
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
    }
}