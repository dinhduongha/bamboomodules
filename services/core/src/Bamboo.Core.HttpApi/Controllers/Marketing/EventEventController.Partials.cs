using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventEventController
    {
        
        [HttpPost]
        [Route("action-generate-leads")]
        public async Task<IActionResult> ActionGenerateLeadsAsync(EventEventGenerateLeadsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GenerateLeadsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-invite-contacts")]
        public async Task<IActionResult> ActionInviteContactsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InviteContactsAsync(ids);
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
        [Route("action-mass-mailing-track-speakers")]
        public async Task<IActionResult> ActionMassMailingTrackSpeakersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MassMailingTrackSpeakersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-slot-calendar")]
        public async Task<IActionResult> ActionOpenSlotCalendarAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenSlotCalendarAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-done")]
        public async Task<IActionResult> ActionSetDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-linked-orders")]
        public async Task<IActionResult> ActionViewLinkedOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewLinkedOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(EventEventCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-event-menus")]
        public async Task<IActionResult> CopyEventMenusAsync(EventEventCopyEventMenusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyEventMenusAsync(input);
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
        [Route("get-kiosk-url")]
        public async Task<IActionResult> GetKioskUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetKioskUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-slot-tickets-availability-pos")]
        public async Task<IActionResult> GetSlotTicketsAvailabilityPosAsync(EventEventGetSlotTicketsAvailabilityPosRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetSlotTicketsAvailabilityPosAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync(EventEventGoogleMapLinkRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GoogleMapLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-booth-menu")]
        public async Task<IActionResult> ToggleBoothMenuAsync(EventEventToggleBoothMenuRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToggleBoothMenuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-exhibitor-menu")]
        public async Task<IActionResult> ToggleExhibitorMenuAsync(EventEventToggleExhibitorMenuRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToggleExhibitorMenuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-website-menu")]
        public async Task<IActionResult> ToggleWebsiteMenuAsync(EventEventToggleWebsiteMenuRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToggleWebsiteMenuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-website-track")]
        public async Task<IActionResult> ToggleWebsiteTrackAsync(EventEventToggleWebsiteTrackRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToggleWebsiteTrackAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-website-track-proposal")]
        public async Task<IActionResult> ToggleWebsiteTrackProposalAsync(EventEventToggleWebsiteTrackProposalRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToggleWebsiteTrackProposalAsync(input);
            return Ok(result);
        }
    }
}