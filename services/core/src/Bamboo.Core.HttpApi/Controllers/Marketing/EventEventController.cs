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
    [Route("api/v1/marketing/EventEvent")]
    public partial class EventEventController : AbpController
    {
        protected readonly IEventEventAppService _appService;
        public EventEventController(IEventEventAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-generate-leads")]
        public async Task<IActionResult> GenerateLeadsAsync([FromBody] EventEventGenerateLeadsRequestDto input)
        {
            var result = await _appService.GenerateLeadsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-invite-contacts")]
        public async Task<IActionResult> InviteContactsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InviteContactsAsync(ids);
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
        [Route("action-mass-mailing-track-speakers")]
        public async Task<IActionResult> MassMailingTrackSpeakersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MassMailingTrackSpeakersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-slot-calendar")]
        public async Task<IActionResult> OpenSlotCalendarAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenSlotCalendarAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-done")]
        public async Task<IActionResult> SetDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-linked-orders")]
        public async Task<IActionResult> ViewLinkedOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewLinkedOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] EventEventCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-event-menus")]
        public async Task<IActionResult> CopyEventMenusAsync([FromBody] EventEventCopyEventMenusRequestDto input)
        {
            var result = await _appService.CopyEventMenusAsync(input);
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
        [Route("get-kiosk-url")]
        public async Task<IActionResult> GetKioskUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetKioskUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-slot-tickets-availability-pos")]
        public async Task<IActionResult> GetSlotTicketsAvailabilityPosAsync([FromBody] EventEventGetSlotTicketsAvailabilityPosRequestDto input)
        {
            var result = await _appService.GetSlotTicketsAvailabilityPosAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync([FromBody] EventEventGoogleMapLinkRequestDto input)
        {
            var result = await _appService.GoogleMapLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-booth-menu")]
        public async Task<IActionResult> ToggleBoothMenuAsync([FromBody] EventEventToggleBoothMenuRequestDto input)
        {
            var result = await _appService.ToggleBoothMenuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-exhibitor-menu")]
        public async Task<IActionResult> ToggleExhibitorMenuAsync([FromBody] EventEventToggleExhibitorMenuRequestDto input)
        {
            var result = await _appService.ToggleExhibitorMenuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-website-menu")]
        public async Task<IActionResult> ToggleWebsiteMenuAsync([FromBody] EventEventToggleWebsiteMenuRequestDto input)
        {
            var result = await _appService.ToggleWebsiteMenuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-website-track")]
        public async Task<IActionResult> ToggleWebsiteTrackAsync([FromBody] EventEventToggleWebsiteTrackRequestDto input)
        {
            var result = await _appService.ToggleWebsiteTrackAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-website-track-proposal")]
        public async Task<IActionResult> ToggleWebsiteTrackProposalAsync([FromBody] EventEventToggleWebsiteTrackProposalRequestDto input)
        {
            var result = await _appService.ToggleWebsiteTrackProposalAsync(input);
            return Ok(result);
        }
    }
    
}