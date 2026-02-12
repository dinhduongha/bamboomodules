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
    [Route("api/v1/productivity/CalendarEvent")]
    public partial class CalendarEventController : AbpController
    {
        protected readonly ICalendarEventAppService _appService;
        public CalendarEventController(ICalendarEventAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-join-meeting")]
        public async Task<IActionResult> JoinMeetingAsync([FromBody] CalendarEventJoinMeetingRequestDto input)
        {
            var result = await _appService.JoinMeetingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-join-video-call")]
        public async Task<IActionResult> JoinVideoCallAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.JoinVideoCallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mass-archive")]
        public async Task<IActionResult> MassArchiveAsync([FromBody] CalendarEventMassArchiveRequestDto input)
        {
            var result = await _appService.MassArchiveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mass-deletion")]
        public async Task<IActionResult> MassDeletionAsync([FromBody] CalendarEventMassDeletionRequestDto input)
        {
            var result = await _appService.MassDeletionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-calendar-event")]
        public async Task<IActionResult> OpenCalendarEventAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenCalendarEventAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-composer")]
        public async Task<IActionResult> OpenComposerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenComposerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-sms")]
        public async Task<IActionResult> SendSmsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sendmail")]
        public async Task<IActionResult> SendmailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unlink-event")]
        public async Task<IActionResult> UnlinkEventAsync([FromBody] CalendarEventUnlinkEventRequestDto input)
        {
            var result = await _appService.UnlinkEventAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("change-attendee-status")]
        public async Task<IActionResult> ChangeAttendeeStatusAsync([FromBody] CalendarEventChangeAttendeeStatusRequestDto input)
        {
            var result = await _appService.ChangeAttendeeStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("clear-videocall-location")]
        public async Task<IActionResult> ClearVideocallLocationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ClearVideocallLocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("find-partner-customer")]
        public async Task<IActionResult> FindPartnerCustomerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.FindPartnerCustomerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-default-duration")]
        public async Task<IActionResult> GetDefaultDurationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetDefaultDurationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-discuss-videocall-location")]
        public async Task<IActionResult> GetDiscussVideocallLocationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetDiscussVideocallLocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-display-time-tz")]
        public async Task<IActionResult> GetDisplayTimeTzAsync([FromBody] CalendarEventGetDisplayTimeTzRequestDto input)
        {
            var result = await _appService.GetDisplayTimeTzAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-next-alarm-date")]
        public async Task<IActionResult> GetNextAlarmDateAsync([FromBody] CalendarEventGetNextAlarmDateRequestDto input)
        {
            var result = await _appService.GetNextAlarmDateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-state-selections")]
        public async Task<IActionResult> GetStateSelectionsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetStateSelectionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync([FromBody] CalendarEventGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-discuss-videocall-location")]
        public async Task<IActionResult> SetDiscussVideocallLocationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetDiscussVideocallLocationAsync(ids);
            return Ok(result);
        }
    }
    
}