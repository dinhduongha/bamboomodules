using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    public partial class CalendarEventController
    {
        
        [HttpPost]
        [Route("{id}/action-join-meeting")]
        public async Task<IActionResult> ActionJoinMeetingAsync(Guid id, [FromBody] CalendarEventJoinMeetingRequestDto input)
        {
            var result = await _appService.JoinMeetingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-join-video-call")]
        public async Task<IActionResult> ActionJoinVideoCallAsync(Guid id)
        {
            var result = await _appService.JoinVideoCallAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-mass-archive")]
        public async Task<IActionResult> ActionMassArchiveAsync(Guid id, [FromBody] CalendarEventMassArchiveRequestDto input)
        {
            var result = await _appService.MassArchiveAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-mass-deletion")]
        public async Task<IActionResult> ActionMassDeletionAsync(Guid id, [FromBody] CalendarEventMassDeletionRequestDto input)
        {
            var result = await _appService.MassDeletionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-calendar-event")]
        public async Task<IActionResult> ActionOpenCalendarEventAsync(Guid id)
        {
            var result = await _appService.OpenCalendarEventAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-composer")]
        public async Task<IActionResult> ActionOpenComposerAsync(Guid id)
        {
            var result = await _appService.OpenComposerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-sms")]
        public async Task<IActionResult> ActionSendSmsAsync(Guid id)
        {
            var result = await _appService.SendSmsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-sendmail")]
        public async Task<IActionResult> ActionSendmailAsync(Guid id)
        {
            var result = await _appService.SendmailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/change-attendee-status")]
        public async Task<IActionResult> ChangeAttendeeStatusAsync(Guid id, [FromBody] CalendarEventChangeAttendeeStatusRequestDto input)
        {
            var result = await _appService.ChangeAttendeeStatusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/clear-videocall-location")]
        public async Task<IActionResult> ClearVideocallLocationAsync(Guid id)
        {
            var result = await _appService.ClearVideocallLocationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/find-partner-customer")]
        public async Task<IActionResult> FindPartnerCustomerAsync(Guid id)
        {
            var result = await _appService.FindPartnerCustomerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-default-duration")]
        public async Task<IActionResult> GetDefaultDurationAsync(Guid id)
        {
            var result = await _appService.GetDefaultDurationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-discuss-videocall-location")]
        public async Task<IActionResult> GetDiscussVideocallLocationAsync(Guid id)
        {
            var result = await _appService.GetDiscussVideocallLocationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-display-time-tz")]
        public async Task<IActionResult> GetDisplayTimeTzAsync(Guid id, [FromBody] CalendarEventGetDisplayTimeTzRequestDto input)
        {
            var result = await _appService.GetDisplayTimeTzAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-next-alarm-date")]
        public async Task<IActionResult> GetNextAlarmDateAsync(Guid id, [FromBody] CalendarEventGetNextAlarmDateRequestDto input)
        {
            var result = await _appService.GetNextAlarmDateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-state-selections")]
        public async Task<IActionResult> GetStateSelectionsAsync(Guid id)
        {
            var result = await _appService.GetStateSelectionsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync(Guid id, [FromBody] CalendarEventGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-discuss-videocall-location")]
        public async Task<IActionResult> SetDiscussVideocallLocationAsync(Guid id)
        {
            var result = await _appService.SetDiscussVideocallLocationAsync(id);
            return Ok(result);
        }
    }
}