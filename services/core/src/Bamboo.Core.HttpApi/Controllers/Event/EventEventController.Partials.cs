using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    public partial class EventEventController
    {
        
        [HttpPost]
        [Route("{id}/action-generate-leads")]
        public async Task<IActionResult> ActionGenerateLeadsAsync(Guid id)
        {
            var result = await _appService.GenerateLeadsAsync(id);
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
            var result = await _appService.CopyDataAsync(id, input.Default);
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
        [Route("{id}/google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync(Guid id, [FromBody] EventEventGoogleMapLinkRequestDto input)
        {
            var result = await _appService.GoogleMapLinkAsync(id, input.Zoom);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/mail-attendees")]
        public async Task<IActionResult> MailAttendeesAsync(Guid id, [FromBody] EventEventMailAttendeesRequestDto input)
        {
            var result = await _appService.MailAttendeesAsync(id, input.TemplateId, input.ForceSend, input.FilterFunc);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-booth-menu")]
        public async Task<IActionResult> ToggleBoothMenuAsync(Guid id, [FromBody] EventEventToggleBoothMenuRequestDto input)
        {
            var result = await _appService.ToggleBoothMenuAsync(id, input.Val);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-exhibitor-menu")]
        public async Task<IActionResult> ToggleExhibitorMenuAsync(Guid id, [FromBody] EventEventToggleExhibitorMenuRequestDto input)
        {
            var result = await _appService.ToggleExhibitorMenuAsync(id, input.Val);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-website-menu")]
        public async Task<IActionResult> ToggleWebsiteMenuAsync(Guid id, [FromBody] EventEventToggleWebsiteMenuRequestDto input)
        {
            var result = await _appService.ToggleWebsiteMenuAsync(id, input.Val);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-website-track")]
        public async Task<IActionResult> ToggleWebsiteTrackAsync(Guid id, [FromBody] EventEventToggleWebsiteTrackRequestDto input)
        {
            var result = await _appService.ToggleWebsiteTrackAsync(id, input.Val);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-website-track-proposal")]
        public async Task<IActionResult> ToggleWebsiteTrackProposalAsync(Guid id, [FromBody] EventEventToggleWebsiteTrackProposalRequestDto input)
        {
            var result = await _appService.ToggleWebsiteTrackProposalAsync(id, input.Val);
            return Ok(result);
        }
    }
}