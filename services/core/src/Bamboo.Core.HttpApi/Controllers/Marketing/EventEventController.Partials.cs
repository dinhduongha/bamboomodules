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
        [Route("{id}/action-generate-leads")]
        public async Task<IActionResult> ActionGenerateLeadsAsync(Guid id, [FromBody] EventEventGenerateLeadsRequestDto input)
        {
            var result = await _appService.GenerateLeadsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-invite-contacts")]
        public async Task<IActionResult> ActionInviteContactsAsync(Guid id)
        {
            var result = await _appService.InviteContactsAsync(id);
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
        [Route("{id}/action-mass-mailing-track-speakers")]
        public async Task<IActionResult> ActionMassMailingTrackSpeakersAsync(Guid id)
        {
            var result = await _appService.MassMailingTrackSpeakersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-slot-calendar")]
        public async Task<IActionResult> ActionOpenSlotCalendarAsync(Guid id)
        {
            var result = await _appService.OpenSlotCalendarAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-done")]
        public async Task<IActionResult> ActionSetDoneAsync(Guid id)
        {
            var result = await _appService.SetDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-linked-orders")]
        public async Task<IActionResult> ActionViewLinkedOrdersAsync(Guid id)
        {
            var result = await _appService.ViewLinkedOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] EventEventCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-event-menus")]
        public async Task<IActionResult> CopyEventMenusAsync(Guid id, [FromBody] EventEventCopyEventMenusRequestDto input)
        {
            var result = await _appService.CopyEventMenusAsync(id, input);
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
        [Route("{id}/get-kiosk-url")]
        public async Task<IActionResult> GetKioskUrlAsync(Guid id)
        {
            var result = await _appService.GetKioskUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-slot-tickets-availability-pos")]
        public async Task<IActionResult> GetSlotTicketsAvailabilityPosAsync(Guid id, [FromBody] EventEventGetSlotTicketsAvailabilityPosRequestDto input)
        {
            var result = await _appService.GetSlotTicketsAvailabilityPosAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync(Guid id, [FromBody] EventEventGoogleMapLinkRequestDto input)
        {
            var result = await _appService.GoogleMapLinkAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-booth-menu")]
        public async Task<IActionResult> ToggleBoothMenuAsync(Guid id, [FromBody] EventEventToggleBoothMenuRequestDto input)
        {
            var result = await _appService.ToggleBoothMenuAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-exhibitor-menu")]
        public async Task<IActionResult> ToggleExhibitorMenuAsync(Guid id, [FromBody] EventEventToggleExhibitorMenuRequestDto input)
        {
            var result = await _appService.ToggleExhibitorMenuAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-website-menu")]
        public async Task<IActionResult> ToggleWebsiteMenuAsync(Guid id, [FromBody] EventEventToggleWebsiteMenuRequestDto input)
        {
            var result = await _appService.ToggleWebsiteMenuAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-website-track")]
        public async Task<IActionResult> ToggleWebsiteTrackAsync(Guid id, [FromBody] EventEventToggleWebsiteTrackRequestDto input)
        {
            var result = await _appService.ToggleWebsiteTrackAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-website-track-proposal")]
        public async Task<IActionResult> ToggleWebsiteTrackProposalAsync(Guid id, [FromBody] EventEventToggleWebsiteTrackProposalRequestDto input)
        {
            var result = await _appService.ToggleWebsiteTrackProposalAsync(id, input);
            return Ok(result);
        }
    }
}